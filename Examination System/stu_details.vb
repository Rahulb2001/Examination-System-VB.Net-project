Imports System.Data.SqlClient
Public Class stu_details

    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;MultipleActiveResultSets=true;AttachDbFilename=C:\Users\dell\Desktop\exam pics\Exam_Database.mdf;Integrated Security=True;Connect Timeout=30")


    Private Sub stu_details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        r = InputBox("Enter Your Regno Number ")
        con.Open()
        Dim sql1 As String = "select * from registration where regno = '" & r & "'"
        Dim cmd1 As New SqlCommand(sql1, con)
        Dim myreader1 As SqlDataReader
        myreader1 = cmd1.ExecuteReader
        If myreader1.Read() = True Then
            Button1.Enabled = False
            check()
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
                MessageBox.Show("This Student is not yet Approved By the Admin Contact Your Admin For Further Clarification ", "Information")
                ''myreader.Close()
            End If

            con.Close()

        ElseIf myreader1.Read() = False Then
            MessageBox.Show(" Incorrect Regno ", "Information")
            Me.Close()
            Loginform.Show()

        End If
        con.Close()



    End Sub
    Public Sub retr()
        check()
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
            MessageBox.Show("This Student is not yet Approved By the Admin Contact Your Admin For Further Clarification ", "Information")
            ''myreader.Close()
        End If

        con.Close()
    End Sub
    Public Sub check()
        ' con.Open()
        Dim sql As String = "select * from f_result where regno = '" & r & "'"
        Dim cmd As New SqlCommand(sql, con)
        Dim myreader As SqlDataReader
        myreader = cmd.ExecuteReader
        If myreader.Read() = True Then
            Button1.Enabled = False
            MessageBox.Show("You have Already Completed the Examination ,Contact Your Admin ", "Information")
        ElseIf myreader.Read() = False Then
            Button1.Enabled = True
        End If
        con.Close()

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)
        Me.Close()
        Loginform.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        examquestion.Show()
        Me.Close()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
        Loginform.Show()

    End Sub
End Class