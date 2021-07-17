Imports System.Data.SqlClient
Public Class Form6
    Dim con As SqlConnection = New SqlConnection(My.Settings.AdminDatabaseConnectionString)
    'Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim cmdT As New SqlCommand
    Dim Maths As String
    Dim Science As String
    Dim Sinhala As String
    Dim English As String
    Dim History As String
    Dim Buddhism As String
    Dim bucketS1 As String
    Dim buckets2 As String
    Dim bucket3 As String

    Dim i As String




    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ''insertData()
        checkResult()
        setdata()

        Me.Close()

    End Sub

    Public Sub Pdis_data()

       
        

        If con.State = ConnectionState.Open Then

            con.Close()
        End If
        'con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\acer\Desktop\Projects\Visual basic\IT project\IT project\AdminDatabase.mdf;Integrated Security=True;User Instance=True"

        con.Open()
        


        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = " select * from [OL Results] "
        cmd.ExecuteNonQuery()

        Dim dt As New DataTable()
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)
        Form1.DataGridView1.DataSource = dt

    End Sub

    Public Sub insertData()


        checkResult()



        If con.State = ConnectionState.Open Then

            con.Close()
        End If
        'con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\acer\Desktop\Projects\Visual basic\IT project\IT project\AdminDatabase.mdf;Integrated Security=True;User Instance=True"

        con.Open()



        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = " insert into [OL Results] values('" + Form1.NicNo.Text + "','" + Form1.Name.Text + "','" + Maths + "','" + Science + "','" + English + "','" + Sinhala + "','" + Buddhism + "','" + History + "','" + bucketS1 + "','" + buckets2 + "','" + bucket3 + "','" + Maths + "') "

        cmd.ExecuteNonQuery()

    End Sub

    Public Sub checkResult()
        If RadioButton1.Checked Then
            Maths = "A"

        ElseIf RadioButton2.Checked Then
            Maths = "B"

        ElseIf RadioButton3.Checked Then
            Maths = "C"
        ElseIf RadioButton4.Checked Then
            Maths = "S"
        ElseIf RadioButton5.Checked Then
            Maths = "F"
        End If


        If RadioButton7.Checked Then
            Science = "A"

        ElseIf RadioButton9.Checked Then
            Science = "B"

        ElseIf RadioButton10.Checked Then
            Science = "C"
        ElseIf RadioButton8.Checked Then
            Science = "S"
        ElseIf RadioButton6.Checked Then
            Science = "F"
        End If

        If RadioButton12.Checked Then
            Sinhala = "A"

        ElseIf RadioButton14.Checked Then
            Sinhala = "B"

        ElseIf RadioButton15.Checked Then
            Sinhala = "C"
        ElseIf RadioButton13.Checked Then
            Sinhala = "S"
        ElseIf RadioButton11.Checked Then
            Sinhala = "F"
        End If

        If RadioButton17.Checked Then
            English = "A"

        ElseIf RadioButton19.Checked Then
            English = "B"

        ElseIf RadioButton20.Checked Then
            English = "C"
        ElseIf RadioButton18.Checked Then
            English = "S"
        ElseIf RadioButton16.Checked Then
            English = "F"
        End If


        If RadioButton22.Checked Then
            History = "A"

        ElseIf RadioButton24.Checked Then
            History = "B"

        ElseIf RadioButton25.Checked Then
            History = "C"
        ElseIf RadioButton23.Checked Then
            History = "S"
        ElseIf RadioButton21.Checked Then
            History = "F"
        End If

        If RadioButton27.Checked Then
            Buddhism = "A"

        ElseIf RadioButton29.Checked Then
            Buddhism = "B"

        ElseIf RadioButton30.Checked Then
            Buddhism = "C"
        ElseIf RadioButton28.Checked Then
            Buddhism = "S"
        ElseIf RadioButton26.Checked Then
            Buddhism = "F"
        End If

        If RadioButton32.Checked Then
            bucketS1 = "A"

        ElseIf RadioButton34.Checked Then
            bucketS1 = "B"

        ElseIf RadioButton35.Checked Then
            bucketS1 = "C"
        ElseIf RadioButton33.Checked Then
            bucketS1 = "S"
        ElseIf RadioButton31.Checked Then
            bucketS1 = "F"
        End If


        If RadioButton37.Checked Then
            buckets2 = "A"

        ElseIf RadioButton39.Checked Then
            buckets2 = "B"

        ElseIf RadioButton40.Checked Then
            buckets2 = "C"
        ElseIf RadioButton38.Checked Then
            buckets2 = "S"
        ElseIf RadioButton36.Checked Then
            buckets2 = "F"
        End If


        If RadioButton42.Checked Then
            bucket3 = "A"

        ElseIf RadioButton44.Checked Then
            bucket3 = "B"

        ElseIf RadioButton45.Checked Then
            bucket3 = "C"
        ElseIf RadioButton43.Checked Then
            bucket3 = "S"
        ElseIf RadioButton41.Checked Then
            bucket3 = "F"
        End If

    End Sub

    Public Sub setdata()
        Form1.OLResult(Form1.NicNo.Text, Form1.Name.Text, Maths, Science, English, Sinhala, Buddhism, History, ComboBox1.Text + "(" + bucketS1 + ")", ComboBox2.Text + "(" + buckets2 + ")", ComboBox3.Text + "(" + bucket3 + ")", Form1.TextBox2.Text)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class