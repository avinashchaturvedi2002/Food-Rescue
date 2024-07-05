Imports System.IO
Imports System.Security.Cryptography
Imports MySql.Data.MySqlClient
Imports Mysqlx

Public Class FoodEntry




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SaveImageToDatabase(PictureBox1.Image)
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox5.Text = ""
        ComboBox1.SelectedIndex = -1



    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub FoodEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("K. Narayanpura")
        ComboBox1.Items.Add("White Field")
        ComboBox1.Items.Add("Belandur")
        ComboBox1.Items.Add("Benarghetta")
        ComboBox1.Items.Add("Shivaji Nagar")
        ComboBox1.Items.Add("Hebbal")
        DateTimePicker1.MinDate = DateTime.Now.Date
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim rh As New Restaurant_Home
        rh.Show()
        Me.Hide()
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
        Dim query As String = "INSERT INTO tbl_food (Food, Food_Description, Address, expiry, username, quantity, image) VALUES (@name, @description, @address, @expiry, @un, @qty, @image)"
        Dim conn As New MySqlConnection(connString)
        conn.Open()

        'Insert the food details and image into the table
        Dim cmd As New MySqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@name", Food)
        cmd.Parameters.AddWithValue("@description", Food_Description)
        cmd.Parameters.AddWithValue("@address", Address)
        cmd.Parameters.AddWithValue("@expiry", Expiry)
        cmd.Parameters.AddWithValue("@un", uname)
        cmd.Parameters.AddWithValue("@qty", Quantity)
        cmd.Parameters.AddWithValue("@image", imgData)
        cmd.ExecuteNonQuery()
        MessageBox.Show("Food details saved successfully!")
        ' Close the database connection
        conn.Close()
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




' NGO: View food listing with image


