﻿Public Class submitform
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        resultform.Show()
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Loginform.Show()
        Me.Close()

    End Sub
End Class