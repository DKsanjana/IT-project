Imports System.Data.SqlClient
Public Class HNDQS

    Private Sub HNDQS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim con As SqlConnection = New SqlConnection(My.Settings.AdminDatabaseConnectionString)
        'Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim Search As String

        Search = "HND-QS"

        'con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\acer\Desktop\Projects\Visual basic\IT project\IT project\AdminDatabase.mdf;Integrated Security=True;User Instance=True"


        If con.State = ConnectionState.Open Then

            con.Close()
        End If
        con.Open()

        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = " select * from StudentData where [Course Name]='" + Search + "' "
        cmd.ExecuteNonQuery()

        Dim dt As New DataTable()
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)
        DataGridView1.DataSource = dt

    End Sub
End Class