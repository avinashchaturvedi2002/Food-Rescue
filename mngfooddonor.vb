Imports MySql.Data.MySqlClient

Public Class mngfooddonor
    Private Sub mngfooddonor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connectionString As String = "server=localhost;user id=root;password=Gj-27052018;database=fr_db"
        Dim connection As New MySqlConnection(connectionString)
        Dim query As String = "SELECT * FROM tbl_users WHERE user_type = 'Restaurants'"
        Dim command As New MySqlCommand(query, connection)
        Dim adapter As New MySqlDataAdapter(command)
        Dim dataTable As New DataTable()
        adapter.Fill(dataTable)
        dataGridView.DataSource = dataTable
        Dim editButton As New DataGridViewButtonColumn()
        editButton.HeaderText = "Edit"
        editButton.Text = "Edit"
        editButton.UseColumnTextForButtonValue = True
        dataGridView.Columns.Add(editButton)

        Dim deleteButton As New DataGridViewButtonColumn()
        deleteButton.HeaderText = "Delete"
        deleteButton.Text = "Delete"
        deleteButton.UseColumnTextForButtonValue = True





    End Sub
    Private Sub dataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView.CellContentClick
        With dataGridView
            user_type = .Rows(.CurrentCell.RowIndex).Cells(0).Value.ToString
            usrname = .Rows(.CurrentCell.RowIndex).Cells(1).Value.ToString
            email = .Rows(.CurrentCell.RowIndex).Cells(2).Value.ToString
            usernamepb = .Rows(.CurrentCell.RowIndex).Cells(3).Value.ToString
            password = .Rows(.CurrentCell.RowIndex).Cells(4).Value.ToString
            userid = .Rows(.CurrentCell.RowIndex).Cells(5).Value.ToString
            town = .Rows(.CurrentCell.RowIndex).Cells(6).Value.ToString
            phone = .Rows(.CurrentCell.RowIndex).Cells(7).Value.ToString
            Dim edtusr As New edtuserdetail
            edtusr.Show()
            Me.Hide()


        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ah As New Admin_home
        ah.Show()
        Me.Hide()
    End Sub
End Class