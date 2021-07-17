Imports System.Data.SqlClient
Public Class Form7
    Dim con As SqlConnection = New SqlConnection(My.Settings.AdminDatabaseConnectionString)
    ' Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim cmdT As New SqlCommand
    Dim economics, accounting, BS, it, other As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        checkResult()
        setdata()
        Me.Close()

    End Sub



    Public Sub checkResult()
        If RadioButton1.Checked Then
            economics = "A"

        ElseIf RadioButton2.Checked Then
            economics = "B"

        ElseIf RadioButton3.Checked Then
            economics = "C"
        ElseIf RadioButton4.Checked Then
            economics = "S"
        ElseIf RadioButton5.Checked Then
            economics = "F"
        End If

        If RadioButton7.Checked Then
            accounting = "A"

        ElseIf RadioButton9.Checked Then
            accounting = "B"

        ElseIf RadioButton10.Checked Then
            accounting = "C"
        ElseIf RadioButton8.Checked Then
            accounting = "S"
        ElseIf RadioButton6.Checked Then
            accounting = "F"
        End If

        If RadioButton12.Checked Then
            BS = "A"

        ElseIf RadioButton14.Checked Then
            BS = "B"

        ElseIf RadioButton15.Checked Then
            BS = "C"
        ElseIf RadioButton13.Checked Then
            BS = "S"
        ElseIf RadioButton11.Checked Then
            BS = "F"
        End If

        If RadioButton22.Checked Then
            it = "A"

        ElseIf RadioButton24.Checked Then
            it = "B"

        ElseIf RadioButton25.Checked Then
            it = "C"
        ElseIf RadioButton23.Checked Then
            it = "S"
        ElseIf RadioButton21.Checked Then
            it = "F"
        End If

        If RadioButton37.Checked Then
            other = "A"
        ElseIf RadioButton39.Checked Then
            other = "B"
        ElseIf RadioButton40.Checked Then
            other = "C"
        ElseIf RadioButton38.Checked Then
            other = "S"
        ElseIf RadioButton36.Checked Then
            other = "F"
        End If

    End Sub

    Public Sub setdata()
        Form1.Commerce(Form1.NicNo.Text, Form1.Name.Text, economics, accounting, BS, it, TextBox1.Text + "(" + other + ")", Form1.TextBox1.Text)

    End Sub
    Public Sub Pdis_data()




        If con.State = ConnectionState.Open Then

            con.Close()
        End If
        'con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\acer\Desktop\Projects\Visual basic\IT project\IT project\AdminDatabase.mdf;Integrated Security=True;User Instance=True"

        con.Open()



        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = " select * from Commerce "
        cmd.ExecuteNonQuery()

        Dim dt As New DataTable()
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)
        Form1.DataGridView1.DataSource = dt

    End Sub

   
End Class