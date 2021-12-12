Imports System.Data.SqlClient
Public Class AddEmployeeForm
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\Desktop\exam pics\Exam_Database.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
        masterform.Show()
    End Sub
    Public Sub empno()
        con.Open()
        Dim sqlstr As String = " select Max(emp_no) + 1 from employee "
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, con)
        Dim dr1 As SqlDataReader = cmd.ExecuteReader
        If dr1.Read Then
            TextBox1.Text = IIf(IsDBNull(dr1(0)), 1, dr1(0))
        End If

        con.Close()
    End Sub

    Private Sub AddEmployeeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        empno()

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
        If RadioButton1.Checked = False And RadioButton2.Checked = False Then
            MessageBox.Show("Incomplete information ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Dim gen As String = ""
        If RadioButton1.Checked = True Then
            gen = "Male"
        ElseIf RadioButton2.Checked = True Then
            gen = "Female"
        End If
        Dim sqlstr As String = "insert into employee values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & DateTimePicker1.Value & "','" & DateTimePicker2.Value & "','" & TextBox3.Text & "','" & gen & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "')"
        con.Open()
        Dim cmd1 As SqlCommand = New SqlCommand(sqlstr, con)
        cmd1.ExecuteNonQuery()
        con.Close()
        pass()
        MessageBox.Show("Sucessfully added New Employee ", "Sucessfully", MessageBoxButtons.OK, MessageBoxIcon.Information)
        TextBox2.Text = ""
        TextBox1.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        RadioButton1.Checked = False

        RadioButton2.Checked = False
    End Sub
    Public Sub clear()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        RadioButton1.Checked = False

        RadioButton2.Checked = False
    End Sub
    Public Sub pass()
        Dim s As String = "Staff"
        Dim sqlstr As String = "insert into password values('" & s & "','" & TextBox5.Text & "','" & TextBox6.Text & "')"
        con.Open()
        Dim cmd1 As SqlCommand = New SqlCommand(sqlstr, con)
        cmd1.ExecuteNonQuery()
        con.Close()

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        clear()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        clear()
        empno()

    End Sub
End Class