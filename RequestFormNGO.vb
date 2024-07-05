Imports System.IO
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class RequestFormNGO
    Private Sub RequestFormNGO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtFood.Text = foodname
        TxtFoodDesc.Text = fooddesc
        TextBox3.Text = town
        DateTimePicker1.Text = expiry
        TextBox5.Text = restname
        TextBox1.Text = listqty

        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        DateTimePicker1.ShowUpDown = True

        ' Establish a connection to the MySQL database
        Dim connectionString As String = "server=localhost;user id=root;password=Gj-27052018;database=fr_db"
        Dim connection As New MySqlConnection(connectionString)
        connection.Open()

        ' Define a MySqlCommand object to execute the SELECT statement to retrieve the image data
        Dim command As New MySqlCommand("SELECT image FROM tbl_food WHERE username = @un and Food_Description = @fd", connection)
        command.Parameters.AddWithValue("@un", restname)
        command.Parameters.AddWithValue("@fd", fooddesc)


        Dim reader As MySqlDataReader = command.ExecuteReader()
        If reader.Read() Then
            ' Convert the image data to an Image object
            Dim imgData As Byte() = DirectCast(reader("image"), Byte())
            Dim ms As New MemoryStream(imgData)
            Dim img As Image = Image.FromStream(ms)

            ' Display the image in a PictureBox control
            PictureBox1.Image = img
        End If





    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim qty As String = TxtQty.Text
        Dim rid As String = Guid.NewGuid().ToString()
        Dim connectionString As String = "server=localhost;user id=root;password=Gj-27052018;database=fr_db"
        Dim selectQuery As String = "SELECT phone, email, town FROM tbl_users WHERE username = @LoggedInUsername"
        Dim insertQuery As String = "INSERT INTO tbl_request (reqid, foodname, restun, date, ngoun, ngophone, ngomail, ngoadd, quantity, lstqty, status) VALUES (@rid, @foodname, @restname, @expiry, @LoggedInUsername, @Phone, @Email, @Town, @qty, @lqt, 'pending')"



        Using connection As New MySqlConnection(connectionString)
            connection.Open()
            Using connection2 As New MySqlConnection(connectionString)
                connection2.Open()

                'Retrieve the user's information from the "user" table
                Using selectCommand As New MySqlCommand(selectQuery, connection)
                    selectCommand.Parameters.AddWithValue("@LoggedInUsername", LoggedInUsername)

                    Using reader As MySqlDataReader = selectCommand.ExecuteReader()
                        If reader.Read() Then
                            Dim phone As String = reader.GetString("phone")
                            Dim email As String = reader.GetString("email")
                            Dim town As String = reader.GetString("town")


                            'Insert the user's information into the "new_table" table
                            Using insertCommand As New MySqlCommand(insertQuery, connection2)
                                insertCommand.Parameters.AddWithValue("@foodname", foodname)
                                insertCommand.Parameters.AddWithValue("@restname", restname)
                                insertCommand.Parameters.AddWithValue("@expiry", expiry)
                                insertCommand.Parameters.AddWithValue("@LoggedInUsername", LoggedInUsername)
                                insertCommand.Parameters.AddWithValue("@Phone", phone)
                                insertCommand.Parameters.AddWithValue("@Email", email)
                                insertCommand.Parameters.AddWithValue("@Town", town)
                                insertCommand.Parameters.AddWithValue("@qty", qty)
                                insertCommand.Parameters.AddWithValue("@rid", rid)
                                insertCommand.Parameters.AddWithValue("@lqt", listqty)


                                If (insertCommand.ExecuteNonQuery() = 1) Then
                                    MessageBox.Show("Request Sent!!")
                                End If
                            End Using
                        End If
                    End Using

                End Using

            End Using
        End Using

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Ng As New FoodReqByNGO
        Ng.Show()
        Me.Hide()
    End Sub

    Private Sub TxtQty_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtQty.Leave
        ' Validate email address
        Dim listedQuantity As Integer = Integer.Parse(TextBox1.Text)
        Dim userInputQuantity As Integer

        If Integer.TryParse(TxtQty.Text, userInputQuantity) Then
            ' The user's input is a valid integer
            If userInputQuantity > listedQuantity Then
                ' The user's input is greater than the listed quantity, display an error message
                MessageBox.Show("Please enter a quantity less than or equal to the listed quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' Reset the text box value to empty
                TxtQty.Text = ""
                TxtQty.Focus()
            End If
        Else
            ' The user's input is not a valid integer, display an error message
            MessageBox.Show("Please enter a valid integer quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ' Reset the text box value to empty
            TxtQty.Text = ""
            TxtQty.Focus()
        End If
    End Sub

    Private Sub TxtFood_TextChanged(sender As Object, e As EventArgs) Handles TxtFood.TextChanged

    End Sub
End Class