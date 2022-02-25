Public Class submitform
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        resultform.Show()
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) 
        Loginform.Show()
        Me.Close()

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
        Loginform.Show()
    End Sub
End Class