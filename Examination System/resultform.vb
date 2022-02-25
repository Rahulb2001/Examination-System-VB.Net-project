Imports System.Data.SqlClient
Public Class resultform
    Dim sm, tm As Integer
    Dim nam, regno, course, semester, marks_scored, total_marks, percentage, grade, result As String

    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\Desktop\exam pics\Exam_Database.mdf;Integrated Security=True;Connect Timeout=30")

    Private Sub PictureBox2_Click_1(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
        Loginform.Show()

    End Sub

    Private Sub resultform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rr = InputBox("PLEASE ENTER YOUR REGNO")
        Dim sqlstr As String = "select regno from result where regno ='" & rr & "'"
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, con)
        Dim dr1 As SqlDataReader = cmd.ExecuteReader
        If dr1.Read Then
            Me.Hide()
        Else
            MessageBox.Show("Entered Regno is incorrect", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            End
        End If
        con.Close()
        show_details()
        show_details_1()
        show_details_2()
        show_details_3()
        show_details_4()
        fresult()
    End Sub
    Public Sub show_details()
        con.Open()
        Dim sql As String = "select studname,regno from registration where regno = '" & rr & "'"
        Dim cmd As New SqlCommand(sql, con)
        Dim myreader As SqlDataReader
        myreader = cmd.ExecuteReader
        myreader.Read()
        Label24.Text = myreader("studname")
        nam = myreader("studname").ToString
        Label3.Text = myreader("regno")
        regno = myreader("regno").ToString
        con.Close()
    End Sub
    Public Sub fshow()
        con.Open()
        Dim sql As String = "select name,regno,course,semester,marks_scored,total_marks,percentage,grade,result from f_result where regno = '" & rr & "'"
        Dim cmd As New SqlCommand(sql, con)
        Dim myreader As SqlDataReader
        myreader = cmd.ExecuteReader
        myreader.Read()


    End Sub
    Public Sub show_details_1()
        con.Open()
        Dim sql As String = "select course,sem from result where regno = '" & rr & "'"
        Dim cmd As New SqlCommand(sql, con)
        Dim myreader As SqlDataReader
        myreader = cmd.ExecuteReader
        myreader.Read()
        Label5.Text = myreader("course")
        course = myreader("course").ToString
        Label7.Text = myreader("sem")
        semester = myreader("sem").ToString
        con.Close()
    End Sub
    Public Sub show_details_2()
        con.Open()
        Dim sql As String = "select count(*)as aa from result where crc_ans=answer and regno = '" & rr & "'"
        Dim cmd As New SqlCommand(sql, con)
        Dim myreader As SqlDataReader
        myreader = cmd.ExecuteReader
        myreader.Read()
        Label9.Text = myreader("aa").ToString
        sm = myreader("aa").ToString
        marks_scored = myreader("aa").ToString
        con.Close()
    End Sub
    Public Sub show_details_3()
        con.Open()
        Dim sql As String = "select count(*)as tq from result where regno = '" & rr & "'"
        Dim cmd As New SqlCommand(sql, con)
        Dim myreader As SqlDataReader
        myreader = cmd.ExecuteReader
        myreader.Read()
        Label11.Text = myreader("tq").ToString
        tm = myreader("tq").ToString
        total_marks = myreader("tq").ToString
        con.Close()
    End Sub
    Public Sub show_details_4()
        Dim avg As Integer
        avg = sm / tm * 100
        Label26.Text = avg
        percentage = Label26.Text

        'Dim grade As String
        If avg > 90 Then
            Label13.Text = "A+"
            grade = "A+"
            Label15.Text = "PASS"
        ElseIf avg >= 90 Then
            Label13.Text = "A"
            grade = "A"
            Label15.Text = "PASS"
        ElseIf avg >= 80 Then
            Label13.Text = "B+"
            grade = "B+"
            Label15.Text = "PASS"
        ElseIf avg >= 70 Then
            Label13.Text = "B"
            grade = "B"
            Label15.Text = "PASS"
        ElseIf avg >= 60 Then
            Label13.Text = "c"
            grade = "C"
            Label15.Text = "PASS"
        Else
            Label13.Text = "c"
            grade = "C"
            Label15.Text = "FAIL"
        End If
        result = Label15.Text
    End Sub
    Public Sub fresult()
        con.Open()
        Dim qry As String = "insert into f_result values('" & nam & "','" & regno & "','" & course & "','" & semester & "','" & marks_scored & "','" & total_marks & "','" & percentage & "','" & grade & "','" & result & "')"
        Dim cmd1 As SqlCommand = New SqlCommand(qry, con)
        cmd1.ExecuteNonQuery()
        con.Close()
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) 
        Me.Close()
        Form1.Show()
    End Sub
End Class