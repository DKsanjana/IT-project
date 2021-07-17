Imports System.Data.SqlClient
Public Class Form2
    Dim con As SqlConnection = New SqlConnection(My.Settings.AdminDatabaseConnectionString)
    'Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim cmdT As New SqlCommand
    Dim Cmaths As String
    Dim physics As String
    Dim Chemistry As String
    Dim It As String
    Dim other As String
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        checkResult()
        setdata()


        Me.Close()
    End Sub

    Public Sub checkResult()
        If RadioButton1.Checked Then
            Cmaths = "A"

        ElseIf RadioButton2.Checked Then
            Cmaths = "B"

        ElseIf RadioButton3.Checked Then
            Cmaths = "C"
        ElseIf RadioButton4.Checked Then
            Cmaths = "S"
        ElseIf RadioButton5.Checked Then
            Cmaths = "F"
        End If

        If RadioButton7.Checked Then
            physics = "A"

        ElseIf RadioButton9.Checked Then
            physics = "B"

        ElseIf RadioButton10.Checked Then
            physics = "C"
        ElseIf RadioButton8.Checked Then
            physics = "S"
        ElseIf RadioButton6.Checked Then
            physics = "F"
        End If

        If RadioButton12.Checked Then
            Chemistry = "A"

        ElseIf RadioButton14.Checked Then
            Chemistry = "B"

        ElseIf RadioButton15.Checked Then
            Chemistry = "C"
        ElseIf RadioButton13.Checked Then
            Chemistry = "S"
        ElseIf RadioButton11.Checked Then
            Chemistry = "F"
        End If

        If RadioButton17.Checked Then
            It = "A"

        ElseIf RadioButton19.Checked Then
            It = "B"

        ElseIf RadioButton20.Checked Then
            It = "C"
        ElseIf RadioButton18.Checked Then
            It = "S"
        ElseIf RadioButton16.Checked Then
            It = "F"
        End If

        If RadioButton22.Checked Then
            other = "A"

        ElseIf RadioButton24.Checked Then
            other = "B"

        ElseIf RadioButton25.Checked Then
            other = "C"
        ElseIf RadioButton23.Checked Then
            other = "S"
        ElseIf RadioButton21.Checked Then
            other = "F"
        End If

    End Sub


    Public Sub insertData()


        checkResult()



        If con.State = ConnectionState.Open Then

            con.Close()
        End If
        ' con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\acer\Desktop\Projects\Visual basic\IT project\IT project\AdminDatabase.mdf;Integrated Security=True;User Instance=True"

        con.Open()



        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = " insert into Maths values('" + Form1.NicNo.Text + "','" + Form1.Name.Text + "','" + Cmaths + "','" + physics + "','" + Chemistry + "','" + It + "','" + other + "','" + Form1.TextBox1.Text + "') "

        cmd.ExecuteNonQuery()

    End Sub

    Public Sub Pdis_data()




        If con.State = ConnectionState.Open Then

            con.Close()
        End If
        'con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\acer\Desktop\Projects\Visual basic\IT project\IT project\AdminDatabase.mdf;Integrated Security=True;User Instance=True"

        con.Open()



        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = " select * from Maths "
        cmd.ExecuteNonQuery()

        Dim dt As New DataTable()
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)
        Form1.DataGridView1.DataSource = dt

    End Sub

    Public Sub setdata()
        Form1.AlMAths(Form1.NicNo.Text, Form1.Name.Text, Cmaths, physics, Chemistry, It, TextBox1.Text + "(" + other + ")", Form1.TextBox1.Text)

    End Sub

End Class