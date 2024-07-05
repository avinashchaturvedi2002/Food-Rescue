Imports MySql.Data.MySqlClient

Public Class RestDashboard
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        Dim fd As New Food_data()
        fd.Show()
        Me.Hide()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub RestDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim connStr As String = "server=localhost;user id=root;password=Gj-27052018;database=fr_db"
        Dim conn As New MySqlConnection(connStr)
        Dim cmd1 As New MySqlCommand()
        Dim cmd2 As New MySqlCommand()
        Dim un As String = LoggedInUsername
        ' Set the SQL query to retrieve the total quantity of food taken away for a specific restaurant
        cmd1.CommandText = "SELECT SUM(Quantity) AS TotalQuantity FROM tbl_request WHERE restun = @un AND status='Accepted'"
        cmd1.Parameters.AddWithValue("@un", un)
        cmd2.CommandText = "SELECT SUM(quantity) AS TotalListedQuantity FROM tbl_food WHERE username = @un"
        cmd2.Parameters.AddWithValue("@un", un)

        ' Set up the SQL command and data adapter
        cmd1.Connection = conn
        cmd2.Connection = conn
        ' Open the database connection and execute the SQL command
        conn.Open()
        Dim totalQuantity As String = cmd1.ExecuteScalar() & "kg"
        Dim totallistedQuantity As String = cmd2.ExecuteScalar() & "kg"

        ' Display the total quantity in a message box
        Label4.Text = totalQuantity
        Label1.Text = totallistedQuantity

        conn.Close()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rh As New Restaurant_Home
        rh.Show()
        Me.Hide()
    End Sub


End Class