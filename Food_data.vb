Imports MySql.Data.MySqlClient
Imports System.Text

Public Class Food_data
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conn As New MySqlConnection("server=localhost;port=3306;username=root;password=Gj-27052018;database=fr_db")
        Dim command As New MySqlCommand("SELECT * FROM tbl_food", conn)
        Dim cmd As New MySqlCommand("SELECT * FROM tbl_food", conn)
        Dim reader As MySqlDataReader

        Try
            conn.Open()
            reader = cmd.ExecuteReader()

            If reader.HasRows Then
                ' Clear existing controls from the table layout panel
                TableLayoutPanel1.Controls.Clear()

                ' Add column bold headers to the table layout panel 
                Dim headerFood As New Label With {.Text = "Food", .Dock = DockStyle.Fill}
                headerFood.Font = New Font(headerFood.Font, FontStyle.Bold)

                Dim headerFoodDesc As New Label() With {.Text = "Food Description", .Dock = DockStyle.Fill}
                headerFoodDesc.Font = New Font(headerFoodDesc.Font, FontStyle.Bold)

                Dim headerAddress As New Label() With {.Text = "Address", .Dock = DockStyle.Fill}
                headerAddress.Font = New Font(headerAddress.Font, FontStyle.Bold)

                Dim headerExpiry As New Label() With {.Text = "Expiry", .Dock = DockStyle.Fill}
                headerExpiry.Font = New Font(headerExpiry.Font, FontStyle.Bold)

                Dim headerUsername As New Label() With {.Text = "Username", .Dock = DockStyle.Fill}
                headerUsername.Font = New Font(headerUsername.Font, FontStyle.Bold)

                Dim headerquantity As New Label With {.Text = "Food", .Dock = DockStyle.Fill}
                headerquantity.Font = New Font(headerquantity.Font, FontStyle.Bold)

                TableLayoutPanel1.Controls.Add(headerFood, 0, 0)
                TableLayoutPanel1.Controls.Add(headerFoodDesc, 1, 0)
                TableLayoutPanel1.Controls.Add(headerAddress, 2, 0)
                TableLayoutPanel1.Controls.Add(headerExpiry, 3, 0)
                TableLayoutPanel1.Controls.Add(headerUsername, 4, 0)
                TableLayoutPanel1.Controls.Add(headerquantity, 5, 0)

                ' Add data rows to the table layout panel
                Dim row As Integer = 1
                While reader.Read()
                    Dim foodLabel As New Label() With {.Text = reader("Food"), .Dock = DockStyle.Fill}
                    Dim foodDescLabel As New Label() With {.Text = reader("food_description"), .Dock = DockStyle.Fill}
                    Dim addressLabel As New Label() With {.Text = reader("address"), .Dock = DockStyle.Fill}
                    Dim expiryLabel As New Label() With {.Text = reader("Expiry"), .Dock = DockStyle.Fill}
                    Dim UsernameLabel As New Label() With {.Text = reader("Username"), .Dock = DockStyle.Fill}
                    Dim quantityLabel As New Label() With {.Text = reader("quantity"), .Dock = DockStyle.Fill}
                    TableLayoutPanel1.Controls.Add(foodLabel, 0, row)
                    TableLayoutPanel1.Controls.Add(foodDescLabel, 1, row)
                    TableLayoutPanel1.Controls.Add(addressLabel, 2, row)
                    TableLayoutPanel1.Controls.Add(expiryLabel, 3, row)
                    TableLayoutPanel1.Controls.Add(UsernameLabel, 4, row)
                    TableLayoutPanel1.Controls.Add(quantityLabel, 5, row)
                    row += 1
                End While
            Else
                MessageBox.Show("No records found.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub Food_data_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class