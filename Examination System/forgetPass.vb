Imports System.Data.SqlClient
Public Class forgetPass
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\Desktop\exam pics\Exam_Database.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "Student" Then
            Label3.Text = "Regno"
        ElseIf ComboBox1.SelectedItem = "Teacher" Then
            Label3.Text = "Username"
        ElseIf ComboBox1.SelectedItem = "Admin" Then
            Label3.Text = "Username"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Len(Trim(TextBox1.Text)) = 0 Then
            MessageBox.Show("Please Type the Employee Number  ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextBox1.Focus()
            Exit Sub
        End If
        con.Open()

        Dim sql As String = "select password from password where u_rname ='" & TextBox1.Text & "'"
        Dim cmd As New SqlCommand(sql, con)
        Dim myreader As SqlDataReader
        myreader = cmd.ExecuteReader
        myreader.Read()
        TextBox2.Text = myreader("password")
        con.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
        masterform.Show()

    End Sub
End Class