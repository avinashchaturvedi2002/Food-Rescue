Imports System.IO
Imports MySql.Data.MySqlClient

Public Class FoodDetails
    Private Sub mngfooddonor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connectionString As String = "server=localhost;user id=root;password=Gj-27052018;database=fr_db"
        Dim connection As New MySqlConnection(connectionString)
        Dim query As String = "SELECT * FROM tbl_food"
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


            If Not IsDBNull(.Rows(.CurrentCell.RowIndex).Cells("Image").Value) Then
                Dim imageData As Byte() = DirectCast(.Rows(.CurrentCell.RowIndex).Cells("Image").Value, Byte())
                Dim ms As New MemoryStream(imageData)
                image = Image.FromStream(ms)
            End If

            food = .Rows(.CurrentCell.RowIndex).Cells(0).Value.ToString
            food_desc = .Rows(.CurrentCell.RowIndex).Cells(1).Value.ToString
            address = .Rows(.CurrentCell.RowIndex).Cells(2).Value.ToString
            expiry = .Rows(.CurrentCell.RowIndex).Cells(3).Value.ToString
            username = .Rows(.CurrentCell.RowIndex).Cells(4).Value.ToString
            quantity = .Rows(.CurrentCell.RowIndex).Cells(5).Value.ToString

            Dim etfood As New EnterFood
            etfood.Show()
            Me.Hide()


        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ah As New Admin_home
        ah.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class