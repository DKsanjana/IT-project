Imports System.Data.SqlClient



Public Class Form1
    'Dim con As String = System.Configuration.ConfigurationManager.ConnectionString("").Connec
    Dim con As SqlConnection = New SqlConnection(My.Settings.AdminDatabaseConnectionString)
    'Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim cmds As New SqlCommand
    Dim maths
    Dim i As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\acer\Desktop\Projects\Visual basic\IT project\IT project\AdminDatabase.mdf;Integrated Security=True;User Instance=True"
        If con.State = ConnectionState.Open Then

            con.Close()
        End If
        con.Open()
        dis_data()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submit_btn.Click

        Try
            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = " insert into StudentData values('" + NicNo.Text + " ','" + Name.Text + "','" + initials.Text + "','" + address.Text + "','" + birthday.Text + "','" + Email.Text + "','" + sex.Text + "','" + Distric.Text + "','" + Contact.Text + "','" + Course.Text + "') "


            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Please check the data you have entered.Maybe relavant ID is already taken ")

        End Try
       

        ''Form6.insertData()
        ''Form6.Close()

        MsgBox("added")

        ClearData()

        dis_data()

        ResultStore()



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form2.Show()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Form3.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form7.Show()


    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Form5.Show()


    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Form4.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Form6.Show()
    End Sub

    Public Sub dis_data()
        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = " select * from StudentData "
        cmd.ExecuteNonQuery()

        Dim dt As New DataTable()
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)
        DataGridView1.DataSource = dt

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Try

            If con.State = ConnectionState.Open Then

                con.Close()
            End If
            con.Open()

            i = DataGridView1.SelectedCells.Item(0).Value.ToString()



            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = " select * from StudentData where id= '" + i + "' "
            cmd.ExecuteNonQuery()

            Dim dt As New DataTable()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)

            Dim dr As SqlClient.SqlDataReader
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While dr.Read

                NicNo.Text = dr.GetString(0).ToString()
                Name.Text = dr.GetString(1).ToString()
                initials.Text = dr.GetString(2).ToString()
                address.Text = dr.GetString(3).ToString()
                birthday.Text = dr.GetString(4).ToString()
                Email.Text = dr.GetString(5).ToString()
                sex.Text = dr.GetString(6).ToString()
                Distric.Text = dr.GetString(7).ToString()
                Contact.Text = dr.GetString(8).ToString()
                Course.Text = dr.GetString(9).ToString()

            End While

        Catch ex As Exception

        End Try

       
    End Sub

    Private Sub updateBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles updateBtn.Click
        If con.State = ConnectionState.Open Then

            con.Close()
        End If
        con.Open()

        Try
            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = " update StudentData set [Course Name]='" + Course.Text + "',Name='" + Name.Text + "',Address='" + address.Text + "',DOB='" + birthday.Text + "',Email='" + Email.Text + "',Sex='" + sex.Text + "',[Administrative Distric]='" + Distric.Text + "',[Contact Number]='" + Contact.Text + "',[Name Denoted by initials]='" + initials.Text + "',ID='" + NicNo.Text + "' where id= '" + i + "' "
            cmd.ExecuteNonQuery()
        Catch ex As Exception


        End Try
        

        dis_data()

    End Sub

    
    Private Sub deletebtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deletebtn.Click
        If con.State = ConnectionState.Open Then

            con.Close()
        End If
        con.Open()

        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = " delete from StudentData where id= '" + i + "' "
        cmd.ExecuteNonQuery()

        dis_data()
    End Sub

    Private Sub searchbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles searchbtn.Click
        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = " select * from StudentData where ID='" + NicNo.Text + "' "
        cmd.ExecuteNonQuery()

        Dim dt As New DataTable()
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)
        DataGridView1.DataSource = dt
    End Sub

    Private Sub Disbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Disbtn.Click

        If con.State = ConnectionState.Open Then

            con.Close()
        End If
        con.Open()

        dis_data()

        ClearData()


    End Sub

    Public Sub ClearData()
        NicNo.Text = " "
        Name.Text = " "
        initials.Text = " "
        address.Text = " "
        birthday.Text = " "
        Email.Text = " "
        sex.Text = " "
        Contact.Text = " "
        Course.Text = " "
        Distric.Text = " "
    End Sub

    Private Sub IT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IT.Click
        DataView.Show()
    End Sub

    Private Sub Engi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Engi.Click
        HNDE.Show()

    End Sub

    Private Sub Agri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        HNDA.Show()

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Public Sub Pdis_data()
        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = " select * from [Part TIme Student Data] "
        cmd.ExecuteNonQuery()

        Dim dt As New DataTable()
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)
        DataGridView1.DataSource = dt

    End Sub

    Private Sub PrtTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrtTime.Click
        Pdis_data()

    End Sub

    Private Sub SubPTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubPTime.Click

        Try
            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = " insert into StudentData values('" + NicNo.Text + " ','" + Name.Text + "','" + initials.Text + "','" + address.Text + "','" + birthday.Text + "','" + Email.Text + "','" + sex.Text + "','" + Distric.Text + "','" + Contact.Text + "','" + Course.Text + "') "


        Catch ex As Exception
            MsgBox("Something went wrong.Please check your data")

        End Try
        MsgBox("Successfully added")



        cmd.ExecuteNonQuery()



        cmds = con.CreateCommand()
        cmds.CommandType = CommandType.Text
        cmds.CommandText = " insert into [Part TIme Student Data] values('" + NicNo.Text + " ','" + Name.Text + "','" + Waddress.Text + "','" + Employment.Text + "','" + DOA.Text + "','" + BR.Text + "','" + BRN.Text + "','" + post.Text + "','" + EpfNo.Text + "') "

        cmds.ExecuteNonQuery()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Form6.Pdis_data()

    End Sub



    Dim a, b, c, d, e, f, g, h, j, k, l, m

    Public Sub OLResult(ByVal Id As String, ByVal name As String, ByVal Maths As String, ByVal Science As String, ByVal English As String, ByVal Sinhala As String, ByVal Buddhism As String, ByVal History As String, ByVal Buckets1 As String, ByVal BucketS2 As String, ByVal Bucket3 As String, ByVal indexNO As String)

        a = Id
        b = name
        c = Maths
        d = Science
        e = English
        f = Sinhala
        g = Buddhism
        h = History
        j = Buckets1
        k = BucketS2
        l = Bucket3
        m = indexNO


    End Sub




    Dim o, p, q, r, s, t, u, v
    Public Sub AlMAths(ByVal ID As String, ByVal Name As String, ByVal Cmaths As String, ByVal phy As String, ByVal chem As String, ByVal It As String, ByVal other As String, ByVal indexNo As String)
        o = ID
        p = Name
        q = Cmaths
        r = phy
        s = chem
        t = It
        u = other
        v = indexNo
    End Sub

    Dim ide, Na, si, buc, lo, ar, ec, ge, itt, ot, ind As String

    Public Sub AlArts(ByVal ID As String, ByVal Name As String, ByVal Sinhala As String, ByVal bc As String, ByVal logic As String, ByVal art As String, ByVal econ As String, ByVal geo As String, ByVal IT As String, ByVal other As String, ByVal indexNo As String)
        ide = ID
        Na = Name
        si = Sinhala
        buc = bc
        lo = logic
        ar = art
        ec = econ
        ge = geo
        itt = IT
        ot = other
        ind = indexNo

    End Sub

    Dim idn, nam, sct, eng, bct, ag, ict, ecn, oth, indx
    Public Sub Altech(ByVal ID As String, ByVal Name As String, ByVal St As String, ByVal Et As String, ByVal bt As String, ByVal agri As String, ByVal it As String, ByVal econ As String, ByVal other As String, ByVal index As String)
        idn = ID
        nam = Name
        sct = St
        eng = Et
        bct = bt
        ag = agri
        ict = it
        ecn = econ
        oth = other
        indx = index


    End Sub

    Dim indt, nme, bi, ph, ch, itct, agr, othr, indxt
    Public Sub Bio(ByVal ID As String, ByVal Name As String, ByVal bio As String, ByVal phy As String, ByVal chem As String, ByVal it As String, ByVal agri As String, ByVal other As String, ByVal indexNo As String)
        indt = ID
        nme = Name
        bi = bio
        ph = phy
        ch = chem
        itct = it
        agr = agri
        othr = other
        indxt = indexNo

    End Sub


    Dim identi, nmme, ecne, acn, busi, ite, othre, indexno
    Public Sub Commerce(ByVal ID As String, ByVal Name As String, ByVal econ As String, ByVal Account As String, ByVal bs As String, ByVal it As String, ByVal other As String, ByVal index As String)
        identi = ID
        nmme = Name
        ecne = econ
        acn = Account
        busi = bs
        ite = it
        othre = other
        indexno = index

    End Sub




    Public Sub ResultStore()
        If con.State = ConnectionState.Open Then

            con.Close()
        End If
        'con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\acer\Desktop\Projects\Visual basic\IT project\IT project\AdminDatabase.mdf;Integrated Security=True;User Instance=True"

        con.Open()


        Try
            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = " insert into [OL Results] values('" + a + "','" + b + "','" + c + "','" + d + "','" + e + "','" + f + "','" + g + "','" + h + "','" + j + "','" + k + "','" + l + "','" + m + "') "

            cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
        

        Try
            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = " insert into Maths values('" + o + "','" + p + "','" + q + "','" + r + "','" + s + "','" + t + "','" + u + "','" + v + "') "

            cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
        


        Try
            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = " insert into Arts values('" + ide + "','" + Na + "','" + si + "','" + buc + "','" + lo + "','" + ar + "','" + ec + "','" + ge + "','" + itt + "','" + ot + "','" + ind + "') "

            cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try

        Try
            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = " insert into Technology values('" + idn + "','" + nam + "','" + sct + "','" + eng + "','" + bct + "','" + ag + "','" + ict + "','" + ecn + "','" + oth + "','" + indx + "') "

            cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
        


        Try
            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = " insert into Bio values('" + indt + "','" + nme + "','" + bi + "','" + ph + "','" + ch + "','" + itct + "','" + agr + "','" + othr + "','" + indxt + "') "

            cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try



        Try
            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = " insert into Commerce values('" + identi + "','" + nmme + "','" + ecne + "','" + acn + "','" + busi + "','" + ite + "','" + othre + "','" + indexno + "') "

            cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
        
       

        OLResult("", "", "", "", "", "", "", "", "", "", "", "")
        AlMAths("", "", "", "", "", "", "", "")
        AlArts("", "", "", "", "", "", "", "", "", "", "")
        Altech("", "", "", "", "", "", "", "", "", "")
        Bio("", "", "", "", "", "", "", "", "")



    End Sub


    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Form2.Pdis_data()

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Form7.Pdis_data()

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Form3.Pdis_data()

    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Form4.Pdis_data()

    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Form5.Pdis_data()

    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        HNDEng.Show()

    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        HNDEC.Show()

    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        HNDEM.Show()

    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        HNDQS.Show()

    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        HNDM.Show()

    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        HNDT.Show()

    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        HNDA.Show()

    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        HNDBA.Show()

    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        HNDFT.Show()

    End Sub

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        HNDTHM.Show()

    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        HNDEB.Show()

    End Sub

    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
        HNDBF.Show()

    End Sub

    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click
        Login.Close()

    End Sub
End Class
