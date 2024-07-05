Imports Microsoft.VisualBasic.ApplicationServices
Imports MySql.Data.MySqlClient
Imports Mysqlx

Public Class reqdetngo
    Private Sub reqdetngo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("All")
        ComboBox1.Items.Add("Accepted")
        ComboBox1.Items.Add("Rejected")
        ComboBox1.Items.Add("Pending")
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim connString As String = "server=localhost;user id=root;password=Gj-27052018;database=fr_db;"
        Dim conn As MySqlConnection = New MySqlConnection(connString)
        Dim status As String = ComboBox1.SelectedItem.ToString()
        Dim username As String = LoggedInUsername
        If status = "All" Then
            'Show all requests
            Dim query As String = "SELECT restun,foodname,lstqty,quantity,status FROM tbl_request WHERE ngoun = '" & username & "'"
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        ElseIf status = "Pending" Then
            Dim query As String = "SELECT restun,foodname,lstqty,quantity,status FROM tbl_request WHERE ngoun = '" & username & "' AND status = 'pending'"
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        ElseIf status = "Accepted" Then
            Dim query As String = "SELECT restun,foodname,lstqty,quantity,status FROM tbl_request WHERE ngoun = '" & username & "' AND status = 'accepted'"
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table

        Else
            'Show requests by status
            Dim query As String = "SELECT restun,foodname,lstqty,quantity,status FROM tbl_request WHERE ngoun = '" & username & "' AND status = '" & status & "'"
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim nh As New NGO_Home
        nh.Show()
        Me.Hide()
    End Sub


End Class