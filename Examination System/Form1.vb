Public Class Form1


    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click

        Me.Close()

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Loginform.Show()
        Me.Hide()


    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Registration_Form.Show()
        Me.Hide()

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        result2form.Show()
        Me.Hide()
    End Sub
End Class
