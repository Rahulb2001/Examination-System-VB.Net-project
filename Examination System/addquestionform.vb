Imports System.Data.SqlClient
Public Class addquestionform
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\Desktop\exam pics\Exam_Database.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
        masterform.Show()


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
            TextBox6.Focus()
            Exit Sub
        End If
        con.Open()
        Dim sc As String = ComboBox1.SelectedItem.ToString
        Dim sem As String = ComboBox2.SelectedItem.ToString
        Dim ans As String = ComboBox3.SelectedItem.ToString
        Dim Sql As String = "insert into question values('" & TextBox1.Text & "','" & sc & "','" & sem & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & ans & "')"
        Dim cmd As New SqlCommand(Sql, con)
        cmd.ExecuteNonQuery()
        MessageBox.Show("Question Added SucessFully .... ", "SuccesssFull", MessageBoxButtons.OK, MessageBoxIcon.Information)
        con.Close()
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
    Public Sub clear()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
    End Sub
    Public Sub qstno()
        con.Open()
        Dim sqlstr As String = " select Max(qno) + 1 from question where course ='" & ComboBox1.SelectedItem & "' and sem='" & ComboBox2.SelectedItem & "' "
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, con)
        Dim dr1 As SqlDataReader = cmd.ExecuteReader
        If dr1.Read Then
            TextBox1.Text = IIf(IsDBNull(dr1(0)), 1, dr1(0))
        End If

        con.Close()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        clear()

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        qstno()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        clear()
        qstno()

    End Sub
End Class