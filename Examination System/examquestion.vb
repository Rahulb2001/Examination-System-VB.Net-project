Imports System.Data.SqlClient
Public Class examquestion
    Dim table As New DataTable
    Dim index As Integer
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\Desktop\exam pics\Exam_Database.mdf;Integrated Security=True;Connect Timeout=30")
    Dim d, diff As TimeSpan
    Dim d2 As DateTime

    Private Sub examquestion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.Open()
        Dim sql As String = "select studname,regno,contact_no,gender,course,qualification,approve from registration where regno = '" & r & "'"
        Dim cmd As New SqlCommand(sql, con)
        Dim myreader As SqlDataReader
        myreader = cmd.ExecuteReader
        myreader.Read()
        Label10.Text = myreader("studname")
        Label6.Text = myreader("regno")
        Label7.Text = myreader("course")
        Label8.Text = myreader("qualification")
        Dim se As Integer = myreader("qualification").ToString
        con.Close()

        con.Open()
        Dim sql1 As String = "select qno,question,sem,opA,opB,opC,opD,ans from question where sem ='" & se & "' "
        Dim cmd1 As New SqlCommand(sql1, con)
        Dim myreader1 As SqlDataReader
        myreader1 = cmd1.ExecuteReader
        myreader1.Read()
        Label11.Text = myreader1("qno")
        TextBox1.Text = myreader1("question")
        RadioButton1.Text = myreader1("opA")
        RadioButton2.Text = myreader1("opB")
        RadioButton3.Text = myreader1("opC")
        RadioButton4.Text = myreader1("opD")
        qnum = myreader1("qno").ToString
        se = myreader1("sem").ToString
        ans = myreader1("ans").ToString
        con.Close()
        Dim ca As String = ""

        del()
        If Label11.Text = 1 Then
            marks()

        End If
        If RadioButton1.Checked = True Then
            an = "A"
            Dim qry As String = "insert into result values('" & Label6.Text & "','" & Label7.Text & "','" & Label8.Text & "','" & Label11.Text & "','" & ans & "','" & an & "')"
            con.Open()
            Dim cmd11 As SqlCommand = New SqlCommand(qry, con)
            cmd11.ExecuteNonQuery()
            con.Close()

        ElseIf RadioButton2.Checked = True Then
            an = "B"
            Dim qry As String = "insert into result values('" & Label6.Text & "','" & Label7.Text & "','" & Label8.Text & "','" & Label11.Text & "','" & ans & "','" & an & "')"
            con.Open()
            Dim cmd11 As SqlCommand = New SqlCommand(qry, con)
            cmd11.ExecuteNonQuery()
            con.Close()
        ElseIf RadioButton3.Checked = True Then
            an = "c"
            Dim qry As String = "insert into result values('" & Label6.Text & "','" & Label7.Text & "','" & Label8.Text & "','" & Label11.Text & "','" & ans & "','" & an & "')"
            con.Open()
            Dim cmd11 As SqlCommand = New SqlCommand(qry, con)
            cmd11.ExecuteNonQuery()
            con.Close()
        ElseIf RadioButton4.Checked = True Then
            an = "D"
            Dim qry As String = "insert into result values('" & Label6.Text & "','" & Label7.Text & "','" & Label8.Text & "','" & Label11.Text & "','" & ans & "','" & an & "')"
            con.Open()
            Dim cmd11 As SqlCommand = New SqlCommand(qry, con)
            cmd11.ExecuteNonQuery()
            con.Close()

        End If

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        Me.Close()
        Loginform.Show()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        'marks()
        If Label11.Text = 1 Then
            marks()
        End If
        Dim qno As Integer = Val(Label11.Text + 1)
        con.Open()
        Dim sq As String = "select max(qno) from question where sem ='" & Label8.Text & "'"
        Dim cmd As New SqlCommand(sq, con)
        Dim q As String = cmd.ExecuteScalar().ToString
        If qno = q Then
            submitform.Show()
            Me.Close()
        End If
        con.Close()
        If RadioButton1.Checked = False And RadioButton2.Checked = False And RadioButton3.Checked = False And RadioButton4.Checked = False Then
            MessageBox.Show("Please Select the Answer", "Answer Not Selected ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            con.Open()
            Dim sql1 As String = "select qno,question,sem,opA,opB,opC,opD,ans from question where sem ='" & sem & "' and qno='" & qno & "' "
            Dim cmd1 As New SqlCommand(sql1, con)
            Dim myreader1 As SqlDataReader
            myreader1 = cmd1.ExecuteReader
            myreader1.Read()
            Label11.Text = myreader1("qno")
            TextBox1.Text = myreader1("question")
            RadioButton1.Text = myreader1("opA")
            RadioButton2.Text = myreader1("opB")
            RadioButton3.Text = myreader1("opC")
            RadioButton4.Text = myreader1("opD")
            ans = myreader1("ans").ToString
            con.Close()
        End If
        If qno = q Then
            ' MsgBox("The Question Ends here Please Submit the Answer")
            Button2.Enabled = False
        End If
        marks()


    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim qno As Integer = Val(Label11.Text - 1)
        If qno = 1 Then
            Button1.Enabled = False
            Button2.Enabled = True
        End If
        If RadioButton1.Checked = False And RadioButton2.Checked = False And RadioButton3.Checked = False And RadioButton4.Checked = False Then
            MessageBox.Show("Please Select the Answer", "Answer Not Selected ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            con.Open()
            Dim sql1 As String = "select qno,question,sem,opA,opB,opC,opD,ans from question where sem ='" & sem & "' and qno='" & qno & "' "
            Dim cmd1 As New SqlCommand(sql1, con)
            Dim myreader1 As SqlDataReader
            myreader1 = cmd1.ExecuteReader
            myreader1.Read()
            Label11.Text = myreader1("qno")
            TextBox1.Text = myreader1("question")
            RadioButton1.Text = myreader1("opA")
            RadioButton2.Text = myreader1("opB")
            RadioButton3.Text = myreader1("opC")
            RadioButton4.Text = myreader1("opD")
            ans = myreader1("ans").ToString
            con.Close()
        End If


    End Sub
    Public Sub del()
        Dim qry1 As String = "delete from result where regno ='" & Label6.Text & "'"
        con.Open()
        Dim cmd1 As SqlCommand = New SqlCommand(qry1, con)
        cmd1.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub marks()
        If RadioButton1.Checked = True Then
            an = "A"
            Dim qry As String = "insert into result values('" & Label6.Text & "','" & Label7.Text & "','" & Label8.Text & "','" & Label11.Text & "','" & ans & "','" & an & "')"
            con.Open()
            Dim cmd11 As SqlCommand = New SqlCommand(qry, con)
            cmd11.ExecuteNonQuery()
            con.Close()
        ElseIf RadioButton2.Checked = True Then
            an = "B"
            Dim qry As String = "insert into result values('" & Label6.Text & "','" & Label7.Text & "','" & Label8.Text & "','" & Label11.Text & "','" & ans & "','" & an & "')"
            con.Open()
            Dim cmd11 As SqlCommand = New SqlCommand(qry, con)
            cmd11.ExecuteNonQuery()
            con.Close()
        ElseIf RadioButton3.Checked = True Then
            an = "c"
            Dim qry As String = "insert into result values('" & Label6.Text & "','" & Label7.Text & "','" & Label8.Text & "','" & Label11.Text & "','" & ans & "','" & an & "')"
            con.Open()
            Dim cmd11 As SqlCommand = New SqlCommand(qry, con)
            cmd11.ExecuteNonQuery()
            con.Close()
        ElseIf RadioButton4.Checked = True Then
            an = "D"
            Dim qry As String = "insert into result values('" & Label6.Text & "','" & Label7.Text & "','" & Label8.Text & "','" & Label11.Text & "','" & ans & "','" & an & "')"
            con.Open()
            Dim cmd11 As SqlCommand = New SqlCommand(qry, con)
            cmd11.ExecuteNonQuery()
            con.Close()

        End If
    End Sub
End Class