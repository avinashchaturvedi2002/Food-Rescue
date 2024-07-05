' Define the connection string and SQL query
Imports MySql.Data.MySqlClient

Public Class AdminEnquiry



    Dim connectionString As String = "server=localhost;user id=root;password=Gj-27052018;database=fr_db"
    Dim query As String = "SELECT enquiryid, enquirysubject, enquirydescription, reply FROM tbl_enquiry"
    Private Sub AdminEnquiry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Create the connection and command objects
        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                ' Open the connection and execute the query
                connection.Open()
                Dim adapter As New MySqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)

                ' Bind the table to the DataGridView
                DataGridView1.DataSource = table

                ' Set the reply column to read-only
                DataGridView1.Columns("reply").ReadOnly = True

                ' Add a text box column for entering the reply
                Dim replyColumn As New DataGridViewTextBoxColumn()
                replyColumn.HeaderText = "Reply"
                replyColumn.Name = "ReplyColumn"
                DataGridView1.Columns.Add(replyColumn)

                ' Handle the CellEndEdit event to update the reply in the database
                AddHandler DataGridView1.CellEndEdit, AddressOf DataGridView1_CellEndEdit
            End Using
        End Using
    End Sub
    ' Define the CellEndEdit event handler
    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs)
        ' Check if the reply column was edited
        If e.ColumnIndex = DataGridView1.Columns("ReplyColumn").Index Then
            ' Get the enquiry ID and reply text
            Dim enquiryId As Integer = CInt(DataGridView1.Rows(e.RowIndex).Cells("enquiryid").Value)
            Dim replyText As String = DataGridView1.Rows(e.RowIndex).Cells("ReplyColumn").Value.ToString()

            ' Update the reply in the database
            Dim connectionString As String = "server=localhost;user id=root;password=Gj-27052018;database=fr_db"
            Dim query As String = "UPDATE tbl_enquiry SET reply = @reply WHERE enquiryid = @id"

            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@reply", replyText)
                    command.Parameters.AddWithValue("@id", enquiryId)
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ah As New Admin_home
        ah.Show()
        Me.Hide()
    End Sub
End Class