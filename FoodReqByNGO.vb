
Imports System.Security.Cryptography
Imports MySql.Data.MySqlClient

Public Class FoodReqByNGO

    ' Connection string for connecting to MySQL database
    Dim connectionString As String = "server=localhost;user id=root;password=Gj-27052018;database=fr_db"

    ' Load all events from event table in MySQL database
    Private Function GetFoodData(ByVal filter As String) As DataTable
        Dim connString As String = "server=localhost;user id=root;password=Gj-27052018;database=fr_db;"
        Dim conn As MySqlConnection = New MySqlConnection(connString)
        Dim dt As New DataTable
        Dim sql As String = "SELECT * FROM tbl_food"

        If filter <> "All" Then
            sql &= " WHERE Address='" & filter & "'"
        End If

        Dim cmd As New MySqlCommand(sql, conn)
        Dim da As New MySqlDataAdapter(cmd)
        da.Fill(dt)

        Return dt
    End Function


    ' Register for an event


    ' Load all events when the form loads


    ' Handle the event of selecting a row in the DataGridView
    Private Sub DataGridViewEvents_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridViewFood.SelectionChanged
        ' Get the selected row
        Dim row As DataGridViewRow = DataGridViewFood.CurrentRow

        ' Set the text boxes to the values of the selected row

    End Sub



    Private Sub Foodrequestngo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("K. Narayanpura")
        ComboBox1.Items.Add("White Field")
        ComboBox1.Items.Add("Belandur")
        ComboBox1.Items.Add("Benarghetta")
        ComboBox1.Items.Add("Shivaji Nagar")
        ComboBox1.Items.Add("Hebbal")
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    ' Handle the event of clicking the register button


    Private Sub DataGridViewFood_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewFood.CellContentClick
        With DataGridViewFood
            foodname = .Rows(.CurrentCell.RowIndex).Cells(1).Value.ToString
            fooddesc = .Rows(.CurrentCell.RowIndex).Cells(2).Value.ToString
            town = .Rows(.CurrentCell.RowIndex).Cells(3).Value.ToString
            expiry = .Rows(.CurrentCell.RowIndex).Cells(4).Value.ToString
            restname = .Rows(.CurrentCell.RowIndex).Cells(5).Value.ToString
            listqty = .Rows(.CurrentCell.RowIndex).Cells(6).Value.ToString
            RequestFormNGO.Show()
        End With
        Me.Enabled = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim nh As New NGO_Home
        nh.Show()
        Me.Hide()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim filter As String = ComboBox1.SelectedItem.ToString()
        DataGridViewFood.DataSource = GetFoodData(filter)
    End Sub


End Class
