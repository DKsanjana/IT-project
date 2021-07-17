Imports System.Data.SqlClient
Public Class Form5
    Dim con As SqlConnection = New SqlConnection(My.Settings.AdminDatabaseConnectionString)
    'Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim cmdT As New SqlCommand
    Dim bio As String
    Dim phy As String
    Dim chem As String
    Dim It As String
    Dim Agri As String
    Dim other As String

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        checkResult()
        setdata()
        Me.Close()

    End Sub

    Public Sub checkResult()
        If RadioButton1.Checked Then
            bio = "A"

        ElseIf RadioButton2.Checked Then
            bio = "B"

        ElseIf RadioButton3.Checked Then
            bio = "C"
        ElseIf RadioButton4.Checked Then
            bio = "S"
        ElseIf RadioButton5.Checked Then
            bio = "F"
        End If

        If RadioButton7.Checked Then
            phy = "A"

        ElseIf RadioButton9.Checked Then
            phy = "B"

        ElseIf RadioButton10.Checked Then
            phy = "C"
        ElseIf RadioButton8.Checked Then
            phy = "S"
        ElseIf RadioButton6.Checked Then
            phy = "F"
        End If

        If RadioButton12.Checked Then
            chem = "A"

        ElseIf RadioButton14.Checked Then
            chem = "B"

        ElseIf RadioButton15.Checked Then
            chem = "C"
        ElseIf RadioButton13.Checked Then
            chem = "S"
        ElseIf RadioButton11.Checked Then
            chem = "F"
        End If

        If RadioButton22.Checked Then
            It = "A"

        ElseIf RadioButton24.Checked Then
            It = "B"

        ElseIf RadioButton25.Checked Then
            It = "C"
        ElseIf RadioButton23.Checked Then
            It = "S"
        ElseIf RadioButton21.Checked Then
            It = "F"
        End If

        If RadioButton32.Checked Then
            Agri = "A"
        ElseIf RadioButton34.Checked Then
            Agri = "B"
        ElseIf RadioButton35.Checked Then
            Agri = "C"
        ElseIf RadioButton33.Checked Then
            Agri = "S"
        ElseIf RadioButton31.Checked Then
            Agri = "F"
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
        Form1.Bio(Form1.NicNo.Text, Form1.Name.Text, bio, phy, chem, It, Agri, TextBox1.Text + "(" + other + ")", Form1.TextBox1.Text)

    End Sub

    Public Sub Pdis_data()




        If con.State = ConnectionState.Open Then

            con.Close()
        End If
        'con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\acer\Desktop\Projects\Visual basic\IT project\IT project\AdminDatabase.mdf;Integrated Security=True;User Instance=True"

        con.Open()



        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = " select * from Bio "
        cmd.ExecuteNonQuery()

        Dim dt As New DataTable()
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)
        Form1.DataGridView1.DataSource = dt

    End Sub
End Class