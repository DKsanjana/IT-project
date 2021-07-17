Public Class Login

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "Admin" And TextBox2.Text = "Admin@#123" Then
            MsgBox("Login Successful")
            Me.Hide()
            Form1.Show()
        Else
            MsgBox("Invalid Username and Password")

        End If
    End Sub
End Class