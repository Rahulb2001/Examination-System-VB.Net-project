Imports System.Data.SqlClient

Public Class Loginform
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\Desktop\exam pics\Exam_Database.mdf;Integrated Security=True;Connect Timeout=30")
    Dim sqlstr As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Form1.Show()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        masterform.writetextboxtolabel(TextBox1.Text)
        If Len(Trim(TextBox1.Text)) = 0 Then
            MessageBox.Show("Please Enter the Username Correctly", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextBox1.Focus()
            Exit Sub
        End If


        If Len(Trim(ComboBox1.Text)) = 0 Then
            MessageBox.Show("Please Select the usertype Correctly", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If Len(Trim(TextBox2.Text)) = 0 Then
            MessageBox.Show("Please Enter the Password Correctly", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextBox1.Focus()
            Exit Sub
        End If
        valid()

        sqlstr = "select * from password where u_rname ='" & TextBox1.Text & "' And password='" & TextBox2.Text & "' And type='" & ComboBox1.SelectedItem & "'"
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, con)
        Dim dr1 As SqlDataReader = cmd.ExecuteReader
        If dr1.Read Then
            Me.Hide()
            If ComboBox1.SelectedItem = "Admin" Then
                masterform.Show()
            ElseIf ComboBox1.SelectedItem = "Student" Then
                stu_details.Show()
            ElseIf ComboBox1.SelectedItem = "Teacher" Then
                masterform.Show()
            End If
        Else
            MessageBox.Show("Entered Username or password is incorrect", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        con.Close()
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.SelectedIndex = -1
    End Sub
    Public Sub valid()
        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zAZ0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        If TextBox1.Text = pattern Then
            MessageBox.Show("Invalid Character", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextBox1.Focus()

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        masterform.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "Student" Then
            Label2.Text = "Regno"
        Else
            Label2.Text = "Username"
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Loginform_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class