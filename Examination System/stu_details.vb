Imports System.Data.SqlClient
Public Class stu_details

    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\Desktop\exam pics\Exam_Database.mdf;Integrated Security=True;Connect Timeout=30")


    Private Sub stu_details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        r = InputBox("Enter Your Regno Number ")
        con.Open()
        Dim sql As String = "select studname,regno,contact_no,gender,course,qualification,approve from registration where regno = '" & r & "'"
        Dim cmd As New SqlCommand(sql, con)
        Dim myreader As SqlDataReader
        myreader = cmd.ExecuteReader
        myreader.Read()
        Label8.Text = myreader("studname")
        Label9.Text = myreader("regno")
        Label10.Text = myreader("contact_no")
        Label11.Text = myreader("gender")
        Label12.Text = myreader("course")
        Label13.Text = myreader("approve")
        Label15.Text = myreader("qualification")
        Module1.sem = myreader("qualification").ToString
        Module1.course = myreader("course").ToString



        Dim spr As String = myreader("approve").ToString
        'Label14.Text = spr
        If spr = "No" Then
            Button1.Enabled = False
            MessageBox.Show("Student not yet Approved", "Information")

        End If

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
        Loginform.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        examquestion.Show()
        Me.Close()

    End Sub
End Class