Imports Microsoft.VisualBasic.ApplicationServices
Imports MySql.Data.MySqlClient

Public Class ViewFoodReq


    Private Sub LoadRequests()
        Dim connString As String = "server=localhost;user id=root;password=Gj-27052018;database=fr_db;"
        Dim conn As MySqlConnection = New MySqlConnection(connString)

        Try
            conn.Open()
            Dim username As String = LoggedInUsername ' The ID of the user to retrieve requests for
            Dim query As String = "SELECT * FROM tbl_request WHERE restun = '" & username & "'"
            Dim cmd As MySqlCommand = New MySqlCommand(query, conn)
            Dim da As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            da.Fill(dt)
            DataGridView1.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try



    End Sub

    Private Sub ViewFoodReq_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRequests()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        ' Check if the cell clicked is the "Accept" button column
        If e.ColumnIndex = DataGridView1.Columns("AcceptButtonColumn").Index AndAlso e.RowIndex >= 0 Then
            Dim requestID As String = DataGridView1.Rows(e.RowIndex).Cells("reqid").Value
            Dim connString As String = "server=localhost;user id=root;password=Gj-27052018;database=fr_db;"
            Dim conn As MySqlConnection = New MySqlConnection(connString)

            Try
                conn.Open()
                Dim query As String = "UPDATE tbl_request SET status = 'Accepted' WHERE reqid = @requestid"
                Dim cmd As MySqlCommand = New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@requestid", requestID)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Request accepted successfully.")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                conn.Close()
            End Try
        ElseIf e.ColumnIndex = DataGridView1.Columns("RejectColumn").Index AndAlso e.RowIndex >= 0 Then
            Dim requestID As String = DataGridView1.Rows(e.RowIndex).Cells("reqid").Value
            Dim connString As String = "server=localhost;user id=root;password=Gj-27052018;database=fr_db;"
            Dim conn1 As MySqlConnection = New MySqlConnection(connString)
            Try
                conn1.Open()
                Dim query As String = "UPDATE tbl_request SET status = 'Rejected' WHERE reqid = @requestid"
                Dim cmd As MySqlCommand = New MySqlCommand(query, conn1)
                cmd.Parameters.AddWithValue("@requestid", requestID)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Request rejected successfully.")

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rh As New Restaurant_Home
        rh.Show()
        Me.Hide()
    End Sub
End Class