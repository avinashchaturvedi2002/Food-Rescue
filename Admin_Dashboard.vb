Imports MySql.Data.MySqlClient

Public Class Admin_Dashboard
    Private Sub Admin_Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connectionString As String = "server=localhost;user id=root;password=Gj-27052018;database=fr_db"
        Dim connection As New MySqlConnection(connectionString)
        Dim command As New MySqlCommand("SELECT COUNT(DISTINCT userid) FROM tbl_users where user_type='Restaurants'", connection)
        Dim queryTotalFood As String = "SELECT SUM(quantity) FROM tbl_food"
        Dim citycount As String = "select count(distinct town) from tbl_users"
        Dim newrequest As String = "Select count(distinct reqid) from tbl_request where status='pending'"
        Dim comprequest As String = "Select count(distinct reqid) from tbl_request where status='accepted'"
        Dim rejrequest As String = "Select count(distinct reqid) from tbl_request where status='rejected'"
        Dim cmdTotalFood As New MySqlCommand(queryTotalFood, connection)
        Dim cmdcity As New MySqlCommand(citycount, connection)
        Dim cmdnewreq As New MySqlCommand(newrequest, connection)
        Dim cmdcompreq As New MySqlCommand(comprequest, connection)
        Dim cmdrejreq As New MySqlCommand(rejrequest, connection)

        connection.Open()

        Dim count As Integer = CInt(command.ExecuteScalar())
        Dim totalFood As Integer = Convert.ToInt32(cmdTotalFood.ExecuteScalar())
        Dim city As Integer = CInt(cmdcity.ExecuteScalar())
        Dim newreq As Integer = CInt(cmdnewreq.ExecuteScalar)
        Dim compreq As Integer = CInt(cmdcompreq.ExecuteScalar)
        Dim rejreq As Integer = CInt(cmdrejreq.ExecuteScalar)


        connection.Close()

        Label7.Text = count
        Label8.Text = totalFood & " KG"
        Label9.Text = city
        Label10.Text = newreq
        Label11.Text = compreq
        Label12.Text = rejreq



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ah As New Admin_home
        ah.Show()
        Me.Hide()
    End Sub
End Class