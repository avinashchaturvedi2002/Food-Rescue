Imports MySql.Data.MySqlClient

Public Class NGOEnquiry
    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim senderName As String = LoggedInUsername
        Dim receiverName As String = "Admin"
        Dim subject As String = TextBox1.Text
        Dim description As String = RichTextBox1.Text
        Dim status As String = "Pending"
        If String.IsNullOrEmpty(subject) OrElse String.IsNullOrEmpty(description) Then
            ' Display an error message to the user
            MessageBox.Show("Please enter the subject as well as description.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ' Return from the function
            Return
        Else


            'Connect to MySQL database
            Dim connString As String = "server=localhost;user id=root;password=Gj-27052018;database=fr_db;"
            Dim connection As New MySqlConnection(connString)
            connection.Open()

            'Insert a new row into enquiry table
            Dim query As String = "INSERT INTO tbl_enquiry(sendername, receivername, enquirysubject, enquirydescription, status) VALUES (@sender, @receiver, @subject, @description, @status);"
            Dim command As New MySqlCommand(query, connection)
            command.Parameters.AddWithValue("@sender", senderName)
            command.Parameters.AddWithValue("@receiver", receiverName)
            command.Parameters.AddWithValue("@subject", subject)
            command.Parameters.AddWithValue("@description", description)
            command.Parameters.AddWithValue("@status", status)
            command.ExecuteNonQuery()

            'Send email notification to receiver
            'Use your preferred email library or API to send an email with the enquiry details

            connection.Close()
            MsgBox("Enquiry sent successfully.")
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim nh As New NGO_Home
        nh.Show()
        Me.Hide()
    End Sub

    Private Sub NGOEnquiry_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class