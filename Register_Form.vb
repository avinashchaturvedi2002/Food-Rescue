Imports MySql.Data.MySqlClient
Imports Mysqlx
Imports System.Net.Mail
Imports System.Text.RegularExpressions
Imports System.Data.SqlClient


Public Class Register_Form
    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Register_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("K. Narayanpura")
        ComboBox1.Items.Add("White Field")
        ComboBox1.Items.Add("Belandur")
        ComboBox1.Items.Add("Benarghetta")
        ComboBox1.Items.Add("Shivaji Nagar")
        ComboBox1.Items.Add("Hebbal")
        RadioButton1.Checked = True

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim utype As String
        Dim userID As String = Guid.NewGuid().ToString()
        If RadioButton1.Checked = True Then
            utype = RadioButton1.Text
        Else
            utype = RadioButton2.Text
        End If
        Dim name As String = TextBox1.Text
        Dim username As String = TextBox4.Text
        Dim email As String = TextBox3.Text
        Dim password As String = TextBox5.Text
        Dim cpassword As String = TextBox6.Text
        Dim town As String = ComboBox1.Text
        Dim phone As String = TextBox7.Text
        If name.Trim() = "" Or username.Trim() = "" Or email.Trim() = "" Or password.Trim() = "" Then

            MessageBox.Show("One Or More Fields Are Empty", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        ElseIf Not String.Equals(password, cpassword) Then

            MessageBox.Show("Wrong Confirmation Password", "password Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf usernameExist(username) Then

            MessageBox.Show("This Username Already Exists, Choose Another One", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        ElseIf emailExist(username) Then

            MessageBox.Show("An account is already registered with same mail", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else


            Dim conn As New MY_CONNECTION()
            Dim command As New MySqlCommand("INSERT INTO `tbl_users`(`userid`, `user_type`, `name`, `email`, `username`, `password`, `town`, `phone`) VALUES (@uid, @ut, @nm, @mail, @usn, @pass, @twn, @phn)", conn.getConnection)
            command.Parameters.Add("@uid", MySqlDbType.VarChar).Value = userID
            command.Parameters.Add("@ut", MySqlDbType.VarChar).Value = utype
            command.Parameters.Add("@nm", MySqlDbType.VarChar).Value = name
            command.Parameters.Add("@mail", MySqlDbType.VarChar).Value = email
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password
            command.Parameters.Add("@twn", MySqlDbType.VarChar).Value = town
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone





            conn.openConnection()
            'conn1.openConnection()


            If (command.ExecuteNonQuery() = 1) Then 'And (command1.ExecuteNonQuery() = 1) Then

                MessageBox.Show("Registration Completed Successfully", "User Added", MessageBoxButtons.OK, MessageBoxIcon.Information)
                conn.closeConnection()
                'conn1.closeConnection()




            Else

                MessageBox.Show("Something Happen", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.closeConnection()
                'conn1.closeConnection()





            End If


        End If






    End Sub
    Public Function usernameExist(ByVal username As String) As Boolean

        Dim con As New MY_CONNECTION()
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter()
        Dim command As New MySqlCommand("SELECT * FROM `tbl_users` WHERE `username` = @usn", con.getConnection())
        command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username

        adapter.SelectCommand = command
        adapter.Fill(table)

        ' if the username exist return true
        If table.Rows.Count > 0 Then

            Return True

            ' if not return false  
        Else

            Return False

        End If

    End Function

    Public Function emailExist(ByVal email As String) As Boolean

        Dim con As New MY_CONNECTION()
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter()
        Dim command As New MySqlCommand("SELECT * FROM `tbl_users` WHERE `email` = @mail", con.getConnection())
        command.Parameters.Add("@mail", MySqlDbType.VarChar).Value = email

        adapter.SelectCommand = command
        adapter.Fill(table)

        ' if the username exist return true
        If table.Rows.Count > 0 Then

            Return True

            ' if not return false  
        Else

            Return False

        End If

    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Dim login As New Login_Form
        login.Show()
    End Sub



    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        ' Allow only letters and spaces
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = " " Then
            e.Handled = True
            MessageBox.Show("Please enter only letters and spaces", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub



    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub



    Private Sub TextBox7_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox7.Leave
        ' Validate phone number
        Dim phonePattern As String = "^\d{10}$"
        If Not Regex.IsMatch(TextBox7.Text.Trim(), phonePattern) Then
            MessageBox.Show("Please enter a 10-digit phone number", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox7.Focus()
        End If
    End Sub



    Private Sub TextBox3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.Leave
        ' Validate email address
        Dim emailPattern As String = "^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$"
        If Not Regex.IsMatch(TextBox3.Text.Trim(), emailPattern) Then
            MessageBox.Show("Please enter a valid email address", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Focus()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim fp As New Form1
        fp.Show()
        Me.Hide()
    End Sub

    Private Sub TextBox5_Leave(sender As Object, ByVal e As System.EventArgs) Handles TextBox5.Leave

        Dim password As String = TextBox5.Text


        ' Check if password is at least 8 characters long
        If password.Length < 8 Then
            MessageBox.Show("Password must be at least 8 characters long.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox5.Focus()
            Return
        End If

        ' Check if password has a capital letter
        If Not password.Any(Function(c) Char.IsUpper(c)) Then
            MessageBox.Show("Password must have at least one capital letter.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox5.Focus()
            Return
        End If

        ' Check if password has a special character
        If Not password.Any(Function(c) Not Char.IsLetterOrDigit(c)) Then
            MessageBox.Show("Password must have at least one special character.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox5.Focus()
            Return
        End If

        ' Password is valid

    End Sub


End Class