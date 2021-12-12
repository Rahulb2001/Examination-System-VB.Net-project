Imports System.Data.SqlClient
Public Class student_Details
    Dim rr As String = ""
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\Desktop\exam pics\Exam_Database.mdf;Integrated Security=True;Connect Timeout=30")

    Private Sub student_Details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rr = InputBox("Enter the Regno of The Student")
        con.Open()
        Dim sql As String = "select studname,regno,adddress,contact_no,gender,course,qualification,dob from registration where regno = '" & rr & "'"
        Dim cmd As New SqlCommand(sql, con)
        Dim myreader As SqlDataReader
        myreader = cmd.ExecuteReader
        myreader.Read()
        Label15.Text = myreader("studname")
        Label16.Text = myreader("regno")
        Label17.Text = myreader("adddress")
        Label18.Text = myreader("contact_no")
        Label19.Text = myreader("gender")
        Label20.Text = myreader("course")
        Label21.Text = myreader("qualification")
        ' Label22.Text = myreader("dob")
        con.Close()
        marks()

    End Sub
    Sub marks()
        con.Open()
        Dim sql As String = "select regno,marks_scored,total_marks,percentage,grade,result from f_result where regno = '" & rr & "'"
        Dim cmd As New SqlCommand(sql, con)
        Dim myreader As SqlDataReader
        myreader = cmd.ExecuteReader
        myreader.Read()
        Label22.Text = myreader("percentage")
        Label23.Text = myreader("marks_scored")
        Label24.Text = myreader("total_marks")
        Label25.Text = myreader("grade")
        Label26.Text = myreader("result")
        con.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()

    End Sub
End Class