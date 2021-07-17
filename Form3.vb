Imports System.Data.SqlClient
Public Class Form3
    Dim con As SqlConnection = New SqlConnection(My.Settings.AdminDatabaseConnectionString)
    'Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim cmdT As New SqlCommand
    Dim sinhala As String
    Dim BC As String
    Dim Econ As String
    Dim Geo As String
    Dim IT As String
    Dim logic As String
    Dim Art As String
    Dim other As String

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        checkResult()
        setdata()
        Me.Close()

    End Sub

    Public Sub checkResult()
        If RadioButton1.Checked Then
            sinhala = "A"

        ElseIf RadioButton2.Checked Then
            sinhala = "B"

        ElseIf RadioButton3.Checked Then
            sinhala = "C"
        ElseIf RadioButton4.Checked Then
            sinhala = "S"
        ElseIf RadioButton5.Checked Then
            sinhala = "F"
        End If


        If RadioButton7.Checked Then
            BC = "A"

        ElseIf RadioButton9.Checked Then
            BC = "B"

        ElseIf RadioButton10.Checked Then
            BC = "C"
        ElseIf RadioButton8.Checked Then
            BC = "S"
        ElseIf RadioButton6.Checked Then
            BC = "F"
        End If


        If RadioButton12.Checked Then
            Econ = "A"
        ElseIf RadioButton14.Checked Then
            Econ = "B"

        ElseIf RadioButton15.Checked Then
            Econ = "C"
        ElseIf RadioButton13.Checked Then
            Econ = "S"
        ElseIf RadioButton11.Checked Then
            Econ = "F"
        End If

        If RadioButton17.Checked Then
            Geo = "A"
        ElseIf RadioButton19.Checked Then
            Geo = "B"
        ElseIf RadioButton20.Checked Then
            Geo = "C"
        ElseIf RadioButton18.Checked Then
            Geo = "S"
        ElseIf RadioButton16.Checked Then
            Geo = "F"
        End If


        If RadioButton17.Checked Then
            Geo = "A"
        ElseIf RadioButton19.Checked Then
            Geo = "B"
        ElseIf RadioButton20.Checked Then
            Geo = "C"
        ElseIf RadioButton18.Checked Then
            Geo = "S"
        ElseIf RadioButton16.Checked Then
            Geo = "F"
        End If

        If RadioButton22.Checked Then
            IT = "A"
        ElseIf RadioButton24.Checked Then
            IT = "B"
        ElseIf RadioButton25.Checked Then
            IT = "C"
        ElseIf RadioButton23.Checked Then
            IT = "S"
        ElseIf RadioButton21.Checked Then
            IT = "F"
        End If

        If RadioButton27.Checked Then
            logic = "A"
        ElseIf RadioButton29.Checked Then
            logic = "B"
        ElseIf RadioButton30.Checked Then
            logic = "C"
        ElseIf RadioButton28.Checked Then
            logic = "S"
        ElseIf RadioButton26.Checked Then
            logic = "F"
        End If


        If RadioButton32.Checked Then
            Art = "A"
        ElseIf RadioButton34.Checked Then
            Art = "B"
        ElseIf RadioButton35.Checked Then
            Art = "C"
        ElseIf RadioButton33.Checked Then
            Art = "S"
        ElseIf RadioButton31.Checked Then
            Art = "F"
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
        Form1.AlArts(Form1.NicNo.Text, Form1.Name.Text, sinhala, BC, logic, Art, Econ, Geo, IT, TextBox1.Text + "(" + other + ")", Form1.TextBox1.Text)

    End Sub

    Public Sub Pdis_data()




        If con.State = ConnectionState.Open Then

            con.Close()
        End If
        'con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\acer\Desktop\Projects\Visual basic\IT project\IT project\AdminDatabase.mdf;Integrated Security=True;User Instance=True"

        con.Open()



        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = " select * from Arts "
        cmd.ExecuteNonQuery()

        Dim dt As New DataTable()
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)
        Form1.DataGridView1.DataSource = dt

    End Sub
End Class