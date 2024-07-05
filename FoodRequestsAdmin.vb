Imports MySql.Data.MySqlClient

Public Class FoodRequestsAdmin
    Private Sub FoodRequestsAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conn As New MySqlConnection("server=localhost;user id=root;password=Gj-27052018;database=fr_db")
        Dim cmd As New MySqlCommand("SELECT foodname, quantity, lstqty, status, ngoun, restun FROM tbl_request", conn)
        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable()

        ' Fill the DataTable with the data from the database
        da.Fill(dt)

        ' Set the DataGridView's data source to the DataTable
        DataGridView1.DataSource = dt

        ' Allow the user to edit the data in the DataGridView
        DataGridView1.ReadOnly = False

        ' Set the DataGridView's columns to read-only except for the "status" column
        For Each col As DataGridViewColumn In DataGridView1.Columns
            If col.Name <> "status" Then
                col.ReadOnly = True
            End If
        Next

        ' Allow the user to delete rows in the DataGridView
        DataGridView1.AllowUserToDeleteRows = True

        ' Allow the user to add new rows in the DataGridView
        DataGridView1.AllowUserToAddRows = True

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ah As New Admin_home
        ah.Show()
        Me.Hide()
    End Sub
End Class