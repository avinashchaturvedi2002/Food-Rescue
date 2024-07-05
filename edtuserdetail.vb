Imports System.Net
Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class edtuserdetail
    Private Sub edtuserdetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = user_type
        TextBox2.Text = usrname
        TextBox3.Text = email
        TextBox4.Text = usernamepb
        TextBox5.Text = password
        TextBox6.Text = userid
        TextBox7.Text = phone
        ComboBox1.Text = town

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim user_type As String = TextBox1.Text
        Dim username As String = TextBox4.Text
        Dim email As String = TextBox3.Text
        Dim password As String = TextBox5.Text
        Dim userid As String = TextBox6.Text
        Dim town As String = ComboBox1.Text
        Dim phone As String = TextBox7.Text
        Dim name As String = TextBox2.Text

        Dim conn As MySqlConnection = New MySqlConnection("server=localhost;user=root;password=Gj-27052018;database=fr_db")

        conn.Open()
        'prepare the SQL query to update donor details in the users table
        Dim query As String = "UPDATE tbl_users SET user_type= @ut, name=@name, email=@email, password=@pwd, userid=@uid, phone=@phone, town=@town WHERE username=@username"
        Dim cmd As MySqlCommand = New MySqlCommand(query, conn)
        'set the parameters for the SQL query
        cmd.Parameters.AddWithValue("@ut", user_type)
        cmd.Parameters.AddWithValue("@name", name)
        cmd.Parameters.AddWithValue("@email", email)
        cmd.Parameters.AddWithValue("@pwd", password)
        cmd.Parameters.AddWithValue("@username", username)
        cmd.Parameters.AddWithValue("@phone", phone)
        cmd.Parameters.AddWithValue("@town", town)
        cmd.Parameters.AddWithValue("@uid", userid)
        'execute the SQL query to update the donor details
        cmd.ExecuteNonQuery()
        MessageBox.Show("Donor details updated successfully.")

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim mng As New mngfooddonor
        mng.Show()
        Me.Hide()
    End Sub
End Class