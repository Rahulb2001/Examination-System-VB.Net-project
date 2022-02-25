Imports System.Data.SqlClient

Public Class masterform
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\Desktop\exam pics\Exam_Database.mdf;Integrated Security=True;Connect Timeout=30")
    Dim q As String = ""
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
        Loginform.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Registration_Form.Show()

    End Sub
    Public Sub writetextboxtolabel(ByVal txt As String)
        Label3.Text = txt
    End Sub

    Private Sub masterform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label4.Text = DateTime.Now.ToString
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub ApproveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApproveToolStripMenuItem.Click
        approvalformstu.Show()

    End Sub

    Private Sub HistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistoryToolStripMenuItem.Click
        approvalhistory.Show()

    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        Me.Close()
        Loginform.Show()

    End Sub

    Private Sub ADDQuestionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ADDQuestionToolStripMenuItem.Click
        Me.Close()
        addquestionform.Show()

    End Sub

    Private Sub ViewEditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewEditToolStripMenuItem.Click
        edit_update_question.Show()

    End Sub

    Private Sub AddStaffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddStaffToolStripMenuItem.Click
        AddEmployeeForm.Show()
        Me.Close()

    End Sub

    Private Sub ViewStaffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewStaffToolStripMenuItem.Click
        view_employee.Show()
        Me.Close()

    End Sub

    Private Sub ExamPasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExamPasswordToolStripMenuItem.Click
        forgetPass.Show()
        Me.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        approvalformstu.Show()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        addquestionform.Show()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        AddEmployeeForm.Show()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        changepass.Show()
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        result2form.Show()

    End Sub
    Sub delete()
        q = InputBox("Enter the Registration No ")
        If (MsgBox("Do you want to Delete this Student ", vbYesNo + vbQuestion) = vbYes) Then
            con.Open()
            cmd = New SqlCommand("delete from registration where regno ='" & q & "'", con)
            cmd.ExecuteNonQuery()
            con.Close()
            delete1()
            delete2()
            MsgBox("Student Sucessfully Removed ", vbInformation)
        End If
    End Sub
    Sub delete1()
        con.Open()
        cmd = New SqlCommand("delete from password where u_rname ='" & q & "'", con)
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
    Sub delete2()
        con.Open()
        cmd = New SqlCommand("delete from f_result where regno ='" & q & "'", con)
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        delete()
    End Sub

    Private Sub MasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MasterToolStripMenuItem.Click
        student_Details.Show()
        'Me.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        approvalhistory.Show()
        ' Me.Close()

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Loginform.Show()

        Me.Close()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        student_Details.Show()
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) 

    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        Statistics.Show()

    End Sub

    Private Sub ResultToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResultToolStripMenuItem.Click
        result2form.Show()
        Me.Hide()

    End Sub
End Class