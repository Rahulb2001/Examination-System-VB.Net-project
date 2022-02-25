Imports System.Data.SqlClient

Public Class Statistics
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\Desktop\exam pics\Exam_Database.mdf;Integrated Security=True;Connect Timeout=30")

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click
        loadgrid()
    End Sub
    Public Sub loadgrid()
        Dim Sql As String = "Select * from f_result where result='FAIL'"
        Dim cmd As New SqlCommand(Sql, con)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        DataGridView2.DataSource = dt
    End Sub

    Private Sub Statistics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadgrid()
        loadgrid1()


    End Sub
    Public Sub loadgrid1()
        Dim Sql As String = "Select * from f_result where result='PASS'"
        Dim cmd As New SqlCommand(Sql, con)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        DataGridView1.DataSource = dt
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click
        loadgrid1()

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
        masterform.Show()

    End Sub
End Class