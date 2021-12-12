Imports System.Data.SqlClient
Public Class edit_update_question
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\Desktop\exam pics\Exam_Database.mdf;Integrated Security=True;Connect Timeout=30")

    Private Sub edit_update_question_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadgrid()
    End Sub
    Public Sub loadgrid()
        Dim Sql As String = "Select qno,question,opA,opB,opC,opD,ans from question"
        Dim cmd As New SqlCommand(Sql, con)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        DataGridView1.DataSource = dt
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
        masterform.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Len(Trim(TextBox1.Text)) = 0 Then
            MessageBox.Show("Please Type the Question Number  ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextBox1.Focus()
            Exit Sub
        End If
        con.Open()

        Dim sql As String = "select question,opA,opB,opC,opD from question where qno = '" & TextBox1.Text & "'"
        Dim cmd As New SqlCommand(sql, con)
        Dim myreader As SqlDataReader
        myreader = cmd.ExecuteReader
        myreader.Read()
        TextBox2.Text = myreader("question")
        TextBox3.Text = myreader("opA")
        TextBox4.Text = myreader("opB")
        TextBox5.Text = myreader("opC")
        TextBox6.Text = myreader("opD")

        ' ComboBox1.SelectedItem = myreader("course")
        'ComboBox2.SelectedItem = myreader("sem")
        'ComboBox3.SelectedItem = myreader("ans")
        con.Close()

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text.Trim() = "" Then
            MessageBox.Show("Please Select the Course ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextBox5.Focus()
            Exit Sub
        End If
        If ComboBox2.Text.Trim() = "" Then
            MessageBox.Show("Please select the Semester ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextBox5.Focus()
            Exit Sub
        End If

        If ComboBox3.Text.Trim() = "" Then
            MessageBox.Show("Please Select the Correct Answer ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextBox5.Focus()
            Exit Sub
        End If
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
        con.Open()
        Dim sc As String = ComboBox1.SelectedItem.ToString
        Dim sem As String = ComboBox2.SelectedItem.ToString
        Dim ans As String = ComboBox3.SelectedItem.ToString
        Dim Sql As String = "update question set qno = '" & TextBox1.Text & "',course = '" & sc & "',sem = '" & sem & "',question = '" & TextBox2.Text & "',opA = '" & TextBox3.Text & "',opB = '" & TextBox4.Text & "',opC = '" & TextBox5.Text & "',opD = '" & TextBox6.Text & "',ans = '" & ans & "' where qno = '" & TextBox1.Text & "'"
        Dim cmd As New SqlCommand(Sql, con)
        cmd.ExecuteNonQuery()
        MessageBox.Show("Question updated SucessFully .... ", "SuccesssFull", MessageBoxButtons.OK, MessageBoxIcon.Information)
        con.Close()
        loadgrid()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim q As Integer = InputBox("Please Enter the Question No ")
        If (MsgBox("Do you want to Delete this Question ", vbYesNo + vbQuestion) = vbYes) Then
            con.Open()
            cmd = New SqlCommand("delete question where qno ='" & q & "'", con)
            cmd.ExecuteNonQuery()
            con.Close()
            MsgBox("Question Sucessfully Deleted ", vbInformation)
            loadgrid()
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            ComboBox1.SelectedIndex = -1
            ComboBox2.SelectedIndex = -1
            ComboBox3.SelectedIndex = -1


        End If
    End Sub
End Class