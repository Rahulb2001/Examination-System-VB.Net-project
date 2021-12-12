Imports System.Data.SqlClient
Public Class changepass

    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\Desktop\exam pics\Exam_Database.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim p1 As String = TextBox2.Text
        Dim p2 As String = TextBox3.Text

        If p1 = p2 Then
            con.Open()
            Dim Sql1 As String = "update password set type = '" & ComboBox1.SelectedItem & "', password = '" & TextBox3.Text & "'where u_rname ='" & TextBox4.Text & "'"
            Dim cmd1 As New SqlCommand(Sql1, con)
            cmd1.ExecuteNonQuery()
            MessageBox.Show("Password Successfully updated ", "SuccesssFull", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'con.Close()
        Else
            MsgBox("Entered Password is not Matching ")

        End If
        con.Close()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        ComboBox1.SelectedIndex = -1





    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "Student" Then
            Label3.Text = "Regno"
        ElseIf ComboBox1.SelectedItem = "Teacher" Then
            Label3.Text = "Username"
        ElseIf ComboBox1.SelectedItem = "Admin" Then
            Label3.Text = "Username"
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
        masterform.Show()

    End Sub
End Class