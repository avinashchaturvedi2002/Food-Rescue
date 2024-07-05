
Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing

Public Class Admin_home
    Dim totalRestaurants As Integer
    Dim totalFoodListed As Integer
    Dim totalRequestsAccepted As Integer
    Dim totalFoodTakeaway As Integer
    Dim totalCities As Integer
    Dim totalNewRequests As Integer
    Dim totalRejectedRequests As Integer

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim ad As New Admin_Dashboard
        ad.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click


    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Admin_home_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim don As New mngfooddonor
        don.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim fda As New FoodDetails
        fda.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Dim freq As New FoodRequestsAdmin
        freq.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Dim enq As New AdminEnquiry
        enq.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click




        Dim connectionString As String = "Server=localhost;Database=fr_db;Uid=root;Pwd=Gj-27052018;"
        Dim connection As New MySqlConnection(connectionString)

        Try
            connection.Open()

            ' Retrieve total number of restaurants from user table
            Dim userQuery As String = "SELECT COUNT(*) FROM tbl_users WHERE user_type = 'Restaurants'"
            Dim userCommand As New MySqlCommand(userQuery, connection)
            totalRestaurants = CInt(userCommand.ExecuteScalar())

            ' Retrieve total food listed from food table
            Dim foodQuery As String = "SELECT SUM(quantity) FROM tbl_food"
            Dim foodCommand As New MySqlCommand(foodQuery, connection)
            totalFoodListed = CInt(foodCommand.ExecuteScalar())

            ' Retrieve Request Accepted from request table
            Dim requestQuery As String = "SELECT COUNT(*) FROM tbl_request WHERE status = 'Accepted'"
            Dim requestCommand As New MySqlCommand(requestQuery, connection)
            totalRequestsAccepted = CInt(requestCommand.ExecuteScalar())

            ' Retrieve total food takeaway from request table
            Dim foodTakeawayQuery As String = "SELECT SUM(lstqty) FROM tbl_request WHERE status = 'Accepted'"
            Dim foodTakeawayCommand As New MySqlCommand(foodTakeawayQuery, connection)
            totalFoodTakeaway = CInt(foodTakeawayCommand.ExecuteScalar())

            ' Retrieve total number of cities from city table
            Dim cityQuery As String = "SELECT  COUNT(DISTINCT town) FROM tbl_users"
            Dim cityCommand As New MySqlCommand(cityQuery, connection)
            totalCities = CInt(cityCommand.ExecuteScalar())

            ' Retrieve new food requests from request table
            Dim newRequestQuery As String = "SELECT COUNT(*) FROM tbl_request WHERE status = 'Pending'"
            Dim newRequestCommand As New MySqlCommand(newRequestQuery, connection)
            totalNewRequests = CInt(newRequestCommand.ExecuteScalar())

            ' Retrieve rejected requests from request table
            Dim rejectedRequestQuery As String = "SELECT COUNT(*) FROM tbl_request WHERE status = 'Rejected'"
            Dim rejectedRequestCommand As New MySqlCommand(rejectedRequestQuery, connection)
            totalRejectedRequests = CInt(rejectedRequestCommand.ExecuteScalar())

            ' Create the report
            Dim pd As New PrintDocument()
            AddHandler pd.PrintPage, AddressOf PrintPage
            pd.Print()

            ' Print the report

            connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try




    End Sub

    Private Sub PrintPage(ByVal sender As Object, e As PrintPageEventArgs)

        ' Define the font and brush for text
        Dim font As New Font("Arial", 12, FontStyle.Regular)
        Dim brush As New SolidBrush(Color.Black)

        ' Define the header text and position
        Dim headerText As String = "Food Request System Report"
        Dim headerX As Single = e.MarginBounds.X + (e.MarginBounds.Width / 2) - (e.Graphics.MeasureString(headerText, font).Width / 2)
        Dim headerY As Single = e.MarginBounds.Y
        e.Graphics.DrawString(headerText, font, brush, headerX, headerY)

        ' Define the line separator
        Dim linePen As New Pen(Color.Black, 1)
        Dim separatorY As Single = e.MarginBounds.Y + 50
        e.Graphics.DrawLine(linePen, e.MarginBounds.X, separatorY, e.MarginBounds.X + e.MarginBounds.Width, separatorY)

        ' Define the report text and position
        Dim reportText As String = "Total Number of Restaurants: " & totalRestaurants.ToString() & vbCrLf & "Total Food Listed: " & totalFoodListed.ToString() & vbCrLf & "Total Requests Accepted: " & totalRequestsAccepted.ToString() & vbCrLf & "Total Food Takeaway: " & totalFoodTakeaway.ToString() & vbCrLf & "Total Number of Cities: " & totalCities.ToString() & vbCrLf & "New Food Requests: " & totalNewRequests.ToString() & vbCrLf & "Rejected Requests: " & totalRejectedRequests.ToString()
        Dim reportX As Single = e.MarginBounds.X
        Dim reportY As Single = separatorY + 50
        e.Graphics.DrawString(reportText, font, brush, reportX, reportY)

        ' Add a border to the report
        Dim borderPen As New Pen(Color.Black, 2)
        e.Graphics.DrawRectangle(borderPen, e.MarginBounds)

        ' Dispose of objects
        font.Dispose()
        brush.Dispose()
        linePen.Dispose()
        borderPen.Dispose()
    End Sub












    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub PictureBox6_Click_1(sender As Object, e As EventArgs) Handles PictureBox6.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim lgin As New Login_Form
        lgin.Show()
        Me.Hide()
    End Sub
End Class

