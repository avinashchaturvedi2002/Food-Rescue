Imports Microsoft.VisualBasic.ApplicationServices
Imports MySql.Data.MySqlClient

Public Class ngodashboard
    Private Sub ngodashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connStr As String = "server=localhost;user id=root;password=Gj-27052018;database=fr_db"
        Dim conn As New MySqlConnection(connStr)
        Dim cmd1 As New MySqlCommand()
        Dim cmd2 As New MySqlCommand()
        Dim un As String = LoggedInUsername
        ' Set the SQL query to retrieve the total quantity of food taken away for a specific restaurant
        cmd1.CommandText = "SELECT SUM(Quantity) AS TotalQuantity FROM tbl_request WHERE ngoun = @un AND status='Accepted'"
        cmd1.Parameters.AddWithValue("@un", un)
        cmd2.CommandText = "SELECT COUNT(DISTINCT restun) AS restaurantcount FROM tbl_request WHERE status='accepted'"
        cmd2.Parameters.AddWithValue("@un", un)

        ' Set up the SQL command and data adapter
        cmd1.Connection = conn
        cmd2.Connection = conn
        ' Open the database connection and execute the SQL command
        conn.Open()
        Dim totalQuantity As String = cmd1.ExecuteScalar() & "kg"
        Dim restcount As String = cmd2.ExecuteScalar()

        ' Display the total quantity in a message box
        Label5.Text = totalQuantity
        Label6.Text = restcount

        conn.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim nh As New NGO_Home
        nh.Show()
        Me.Hide()
    End Sub


End Class