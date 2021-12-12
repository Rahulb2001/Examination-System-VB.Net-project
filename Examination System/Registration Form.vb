Imports System.Data.SqlClient
Public Class Registration_Form
    Dim con_str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\Desktop\exam pics\Exam_Database.mdf;Integrated Security=True;Connect Timeout=30"
    Dim con As New SqlConnection(con_str)
    Dim cmd As New SqlCommand
    Dim adapter As New SqlDataAdapter
    Dim ap As String = ""
    ' Dim psw As New Random
    ' Dim st As String = (psw.Next(1, 100000))
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        ' Form1.Show()
    End Sub
    'Public Sub random()
    'Dim psw As New Random
    'Dim st As Integer = (psw.Next(1, 10000))
    'MessageBox.Show(st)
    '    End Sub
    Private Sub Registration_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        data()
        TextBox2.Focus()
    End Sub

    Sub data()
        con.Open()
        Dim sqlstr As String = "select Max(stdno) + 1 from registration"
        Dim cmd As SqlCommand = New SqlCommand(Sqlstr, con)
        Dim dr1 As SqlDataReader = cmd.ExecuteReader

        If dr1.Read Then
            ap = IIf(IsDBNull(dr1(0)), 1, dr1(0))

        End If

        con.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click


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
            TextBox6.Focus()
            Exit Sub
        End If

        If Len(Trim(TextBox6.Text)) = 0 Then
            MessageBox.Show("Incomplete information ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextBox6.Focus()
            Exit Sub
        End If
        Dim gen As String = ""
        If RadioButton1.Checked Then
            gen = "Male"
        ElseIf RadioButton2.Checked Then
            gen = "Female"
        End If
        Dim sqlstr As String = "insert into registration values('" & ap & "','" & TextBox2.Text & "','" & TextBox6.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & gen & "','" & ComboBox1.SelectedItem & "','" & ComboBox2.SelectedItem & "','" & DateTimePicker1.Value & "','" & "No" & "','" & 0 & "','" & TextBox5.Text & "')"
        con.Open()
        Dim cmd1 As SqlCommand = New SqlCommand(sqlstr, con)
        cmd1.ExecuteNonQuery()
        con.Close()
        pass()
        '  MessageBox.Show("Please Note/Remember your password for the Further Use Ahead  " + st, "Password", MessageBoxButtons.OK, MessageBoxIcon.Information)
        MessageBox.Show("Student Sucessfully Registered ", " Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        'TextBox1.Clear()
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1

    End Sub
    Public Sub pass()
        Dim s As String = "Student"
        Dim sqlstr As String = "insert into password values('" & s & "','" & TextBox6.Text & "','" & TextBox5.Text & "')"
        con.Open()
        Dim cmd1 As SqlCommand = New SqlCommand(sqlstr, con)
        cmd1.ExecuteNonQuery()
        con.Close()
    End Sub
    ' Sub validation()
    'If TextBox1.Text = "" And TextBox2.Text = "" And TextBox3.Text = "" And TextBox4.Text = "" And TextBox5.Text = "" Then
    '       MessageBox.Show("Please Enter All the Details", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    'End If
    'End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox6.Clear()
        TextBox5.Clear()
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
    End Sub
End Class