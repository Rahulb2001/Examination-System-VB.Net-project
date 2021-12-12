Imports System.Data.SqlClient

Public Class result2form
    Dim regno As String

    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\Desktop\exam pics\Exam_Database.mdf;Integrated Security=True;Connect Timeout=30")

    Private Sub result2form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        regno = InputBox("Please Enter the Regno ")
        con.Open()
        Dim sql As String = "select name,regno,course,semester,marks_scored,total_marks,percentage,grade,result from f_result where regno = '" & regno & "'"
        Dim cmd As New SqlCommand(sql, con)
        Dim myreader As SqlDataReader
        myreader = cmd.ExecuteReader
        myreader.Read()
        Label11.Text = myreader("name")
        Label12.Text = myreader("regno")
        Label13.Text = myreader("course")
        Label14.Text = myreader("semester")
        Label15.Text = myreader("marks_scored")
        Label16.Text = myreader("total_marks")
        Label18.Text = myreader("percentage")
        Label19.Text = myreader("grade")
        Label20.Text = myreader("result")
        con.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
        Form1.Show()

    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class