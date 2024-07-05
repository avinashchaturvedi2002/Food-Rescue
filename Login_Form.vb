Imports System.Security.Cryptography.X509Certificates
Imports MySql.Data.MySqlClient
Public Class Login_Form



    Private Sub Login_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RadioButton1.Checked = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()

    End Sub
    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        Dim username As String = TextBox1.Text
        ' check if the username is empty
        ' check if the textbox contains the default value "username"
        If username.Trim().ToLower() = "username" Or username.Trim() = "" Then


            TextBox1.Text = ""


        End If

    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave

        '
        Dim username As String = TextBox1.Text

        If username.Trim().ToLower() = "username" Or username.Trim() = "" Then


            TextBox1.Text = "username"


        End If

    End Sub

    Private Sub TextBox2_Enter(sender As Object, e As EventArgs) Handles TextBox2.Enter

        ' when textbox password has focus
        Dim pass As String = TextBox2.Text
        If pass.Trim().ToLower() = "password" Or pass.Trim() = "" Then

            ' clear the textbox text
            TextBox2.Text = ""


        End If

    End Sub

    Private Sub TextBox2_Leave(sender As Object, e As EventArgs) Handles TextBox2.Leave

        ' when textbox password lost focus
        Dim pass As String = TextBox2.Text
        If pass.Trim().ToLower() = "password" Or pass.Trim() = "" Then

            ' set the textbox text
            TextBox2.Text = "password"



        End If

    End Sub



    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoggedInUsername = TextBox1.Text
        Dim conn As New MY_CONNECTION()
        Dim adapter As New MySqlDataAdapter()
        Dim table As New DataTable()
        Dim command As New MySqlCommand("SELECT `username`, `password`, `user_type` FROM `tbl_users` WHERE `username` = @usn AND `password` = @pass AND `user_type` = @ut", conn.getConnection())

        command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = TextBox1.Text
        command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = TextBox2.Text
        If RadioButton1.Checked = True Then
            command.Parameters.Add("@ut", MySqlDbType.VarChar).Value = RadioButton1.Text
        ElseIf RadioButton2.Checked = True Then
            command.Parameters.Add("@ut", MySqlDbType.VarChar).Value = RadioButton2.Text
        ElseIf RadioButton3.Checked = True Then
            command.Parameters.Add("@ut", MySqlDbType.VarChar).Value = RadioButton3.Text
        Else
            MsgBox("Select User Type")
        End If

        If TextBox1.Text.Trim() = "" Or TextBox2.Text.Trim().ToLower() = "username" Then

            MessageBox.Show("Enter Your Username To Login", "Missing Username", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf TextBox2.Text.Trim() = "" Or TextBox2.Text.Trim().ToLower() = "password" Then

            MessageBox.Show("Enter Your Password To Login", "Missing Password", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Else

            adapter.SelectCommand = command
            adapter.Fill(table)

            If (table.Rows.Count > 0) And (RadioButton1.Checked = True) Then

                Me.Hide()
                Dim mainAppForm As New Restaurant_Home()
                mainAppForm.Show()

            ElseIf (table.Rows.Count > 0) And (RadioButton2.Checked = True) Then

                Me.Hide()
                Dim mainAppForm As New NGO_Home()
                mainAppForm.Show()

            ElseIf (table.Rows.Count > 0) And (RadioButton3.Checked = True) Then

                Me.Hide()
                Dim mainAppForm As New Admin_home()
                mainAppForm.Show()

            Else

                MessageBox.Show("This Username Or/And Password Doesn't Exists", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If

        End If




    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Dim r_form As New Register_Form()
        r_form.Show()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim rf As New Register_Form
        rf.Show()
        Me.Hide()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class