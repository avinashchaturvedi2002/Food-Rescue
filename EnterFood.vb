Imports MySql.Data.MySqlClient
Imports System.IO

Public Class EnterFood
    Private Sub EnterFood_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = food
        TextBox2.Text = food_desc
        ComboBox1.Text = address
        DateTimePicker1.Text = expiry
        PictureBox1.Image = image
        TextBox5.Text = quantity
        DateTimePicker1.MinDate = DateTime.Now.Date
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SaveImageToDatabase(PictureBox1.Image)
    End Sub
    Private Sub SaveImageToDatabase(image As Image)
        ' Convert the image to byte array
        Dim ms As New MemoryStream()
        image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
        Dim imgData As Byte() = ms.ToArray()

        ' Connect to the MySQL database
        Dim uname As String = LoggedInUsername
        Dim Food As String = TextBox1.Text
        Dim Food_Description As String = TextBox2.Text
        Dim Address As String = ComboBox1.Text
        Dim Quantity As Integer = TextBox5.Text
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy/MM/dd"
        Dim Expiry As String = DateTimePicker1.Text
        Dim connString As String = "server=localhost;user id=root;password=Gj-27052018;database=fr_db"
        Dim query As String = "update tbl_food set Food = @name, Food_Description= @description, Address= @address, expiry=@expiry,  quantity=@qty, image=@image where username = @un"
        Dim conn As New MySqlConnection(connString)
        conn.Open()

        'Insert the food details and image into the table
        Dim cmd As New MySqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@name", Food)
        cmd.Parameters.AddWithValue("@description", Food_Description)
        cmd.Parameters.AddWithValue("@address", Address)
        cmd.Parameters.AddWithValue("@expiry", Expiry)
        cmd.Parameters.AddWithValue("@un", username)
        cmd.Parameters.AddWithValue("@qty", Quantity)
        cmd.Parameters.AddWithValue("@image", imgData)
        cmd.ExecuteNonQuery()
        MessageBox.Show("Food details updated successfully!")
        ' Close the database connection
        conn.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "Image Files (*.jpg, *.jpeg, *.png)|*.jpg; *.jpeg; *.png"
        If ofd.ShowDialog() = DialogResult.OK Then
            Dim img As Image = Image.FromFile(ofd.FileName)
            PictureBox1.Image = Image.FromFile(ofd.FileName)
            ' Save the image to the database

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fd As New FoodDetails
        fd.Show()
        Me.Hide()
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub
    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        ' Allow only digits and control characters in the text box
        If (Not Char.IsDigit(e.KeyChar)) AndAlso (Not Char.IsControl(e.KeyChar)) Then
            e.Handled = True ' Ignore non-numeric characters
        End If
    End Sub

    Private Sub TextBox5_Leave(sender As Object, e As EventArgs) Handles TextBox5.Leave
        ' Parse the input value and validate it
        Dim input As String = TextBox5.Text
        Dim value As Integer

        If Integer.TryParse(input, value) Then
            ' The input is a valid integer
        Else
            ' The input is not a valid integer, display an error message
            MessageBox.Show("Please enter a valid integer value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ' Reset the text box value to empty
            TextBox5.Text = ""
            TextBox5.Focus()
        End If
    End Sub

End Class