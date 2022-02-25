Imports System.Data.SqlClient

Public Class view_employee
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\Desktop\exam pics\Exam_Database.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub view_employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadgrid()

    End Sub
    Public Sub loadgrid()
        Dim Sql As String = "Select * from employee"
        Dim cmd As New SqlCommand(Sql, con)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        DataGridView1.DataSource = dt
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Len(Trim(TextBox1.Text)) = 0 Then
            MessageBox.Show("Please Type the Employee Number  ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextBox1.Focus()
            Exit Sub
        End If
        con.Open()

        Dim sql As String = "select emp_name,addr,gen,contact,username,password from employee where emp_no = '" & TextBox1.Text & "'"
        Dim cmd As New SqlCommand(sql, con)
        Dim myreader As SqlDataReader
        myreader = cmd.ExecuteReader
        myreader.Read()
        TextBox2.Text = myreader("emp_name")
        TextBox3.Text = myreader("addr")
        TextBox4.Text = myreader("gen")
        TextBox5.Text = myreader("contact")
        TextBox6.Text = myreader("username")
        TextBox7.Text = myreader("password")
        con.Close()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
        masterform.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Len(Trim(TextBox1.Text)) = 0 Then
            MessageBox.Show("Incomplete information ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextBox1.Focus()
            Exit Sub
        End If
        If Len(Trim(TextBox2.Text)) = 0 Then
            MessageBox.Show("Incomplete information ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextBox2.Focus()
            Exit Sub
        End If
        If Len(Trim(TextBox3.Text)) = 0 Then
            MessageBox.Show("Incomplete information ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextBox3.Focus()
            Exit Sub
        End If
        If Len(Trim(TextBox4.Text)) = 0 Then
            MessageBox.Show("Incomplete information ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextBox4.Focus()
            Exit Sub
        End If
        If Len(Trim(TextBox5.Text)) = 0 Then
            MessageBox.Show("Incomplete information ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextBox5.Focus()
            Exit Sub
        End If
        If Len(Trim(TextBox6.Text)) = 0 Then
            MessageBox.Show("Incomplete information ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextBox5.Focus()
            Exit Sub
        End If
        If Len(Trim(TextBox7.Text)) = 0 Then
            MessageBox.Show("Incomplete information ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextBox5.Focus()
            Exit Sub
        End If
        con.Open()
        Dim Sql As String = "update employee set emp_no = '" & TextBox1.Text & "',emp_name = '" & TextBox2.Text & "',addr = '" & TextBox3.Text & "',gen = '" & TextBox4.Text & "',contact = '" & TextBox5.Text & "',username = '" & TextBox6.Text & "',password = '" & TextBox7.Text & "' where emp_no = '" & TextBox1.Text & "'"
        Dim cmd As New SqlCommand(Sql, con)
        cmd.ExecuteNonQuery()
        MessageBox.Show("Successfully updated SucessFully .... ", "SuccesssFull", MessageBoxButtons.OK, MessageBoxIcon.Information)
        con.Close()
        loadgrid()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim q As Integer = InputBox("Please Enter the Employee Id ")
        If (MsgBox("Do you want to Delete this Employee ", vbYesNo + vbQuestion) = vbYes) Then
            con.Open()
            cmd = New SqlCommand("delete employee where emp_no ='" & q & "'", con)
            cmd.ExecuteNonQuery()
            con.Close()
            MsgBox("Employee Sucessfully Removed ", vbInformation)
            loadgrid()
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
        End If
    End Sub
End Class