Imports System.Data.SqlClient
Public Class Form4
    Dim con As SqlConnection = New SqlConnection(My.Settings.AdminDatabaseConnectionString)
    'Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim cmdT As New SqlCommand
    Dim Sct As String
    Dim ET As String
    Dim Bst As String
    Dim Agri As String
    Dim ICT As String
    Dim Econ As String
    Dim other As String

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        checkResult()
        setdata()
        Me.Close()

    End Sub

    Public Sub checkResult()

        If RadioButton1.Checked Then
            Sct = "A"

        ElseIf RadioButton2.Checked Then
            Sct = "B"

        ElseIf RadioButton3.Checked Then
            Sct = "C"
        ElseIf RadioButton4.Checked Then
            Sct = "S"
        ElseIf RadioButton5.Checked Then
            Sct = "F"
        End If

        If RadioButton7.Checked Then
            ET = "A"

        ElseIf RadioButton9.Checked Then
            ET = "B"

        ElseIf RadioButton10.Checked Then
            ET = "C"
        ElseIf RadioButton8.Checked Then
            ET = "S"
        ElseIf RadioButton6.Checked Then
            ET = "F"
        End If

        If RadioButton12.Checked Then
            Bst = "A"

        ElseIf RadioButton14.Checked Then
            Bst = "B"

        ElseIf RadioButton15.Checked Then
            Bst = "C"
        ElseIf RadioButton13.Checked Then
            Bst = "S"
        ElseIf RadioButton11.Checked Then
            Bst = "F"
        End If

        If RadioButton17.Checked Then
            Agri = "A"

        ElseIf RadioButton19.Checked Then
            Agri = "B"

        ElseIf RadioButton20.Checked Then
            Agri = "C"
        ElseIf RadioButton18.Checked Then
            Agri = "S"
        ElseIf RadioButton16.Checked Then
            Agri = "F"
        End If

        If RadioButton22.Checked Then
            ICT = "A"

        ElseIf RadioButton24.Checked Then
            ICT = "B"

        ElseIf RadioButton25.Checked Then
            ICT = "C"
        ElseIf RadioButton23.Checked Then
            ICT = "S"
        ElseIf RadioButton21.Checked Then
            ICT = "F"
        End If

        If RadioButton32.Checked Then
            Econ = "A"

        ElseIf RadioButton34.Checked Then
            Econ = "B"

        ElseIf RadioButton35.Checked Then
            Econ = "C"
        ElseIf RadioButton33.Checked Then
            Econ = "S"
        ElseIf RadioButton31.Checked Then
            Econ = "F"
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
        Form1.Altech(Form1.NicNo.Text, Form1.Name.Text, Sct, ET, Bst, Agri, ICT, Econ, TextBox1.Text + "(" + other + ")", Form1.TextBox1.Text)

    End Sub

    Public Sub Pdis_data()




        If con.State = ConnectionState.Open Then

            con.Close()
        End If
        'con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\acer\Desktop\Projects\Visual basic\IT project\IT project\AdminDatabase.mdf;Integrated Security=True;User Instance=True"

        con.Open()



        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = " select * from Technology "
        cmd.ExecuteNonQuery()

        Dim dt As New DataTable()
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)
        Form1.DataGridView1.DataSource = dt

    End Sub
End Class