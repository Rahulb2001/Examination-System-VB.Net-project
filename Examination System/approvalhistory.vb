Imports System.Data.SqlClient
Public Class approvalhistory
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\Desktop\exam pics\Exam_Database.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub approvalhistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadrecord()
        loadrecord1()
    End Sub
    Public Sub loadrecord()
        Dim i As Integer = 0
        approvedstudentlist.Rows.Clear()
        con.Open()
        cmd = New SqlCommand("select * from registration where approve not in ('No')", con)
        dr = cmd.ExecuteReader
        While dr.Read
            i += 1
            approvedstudentlist.Rows.Add(dr.Item("stdno").ToString, i, dr.Item("studname"), dr.Item("gender").ToString, dr.Item("course"), dr.Item("qualification"), dr.Item("dob"), dr.Item("approve"))

        End While
        dr.Close()
        con.Close()
        Label2.Text = "(" & approvedstudentlist.Rows.Count & ") Record Found "
    End Sub
    Public Sub loadrecord1()
        Dim i As Integer = 0
        notapprovedlist.Rows.Clear()
        con.Open()
        cmd = New SqlCommand("select * from registration where approve not in ('yes')", con)
        dr = cmd.ExecuteReader
        While dr.Read
            i += 1
            notapprovedlist.Rows.Add(dr.Item("stdno").ToString, i, dr.Item("studname"), dr.Item("gender").ToString, dr.Item("course"), dr.Item("qualification"), dr.Item("dob"), dr.Item("approve"))

        End While
        dr.Close()
        con.Close()
        Label3.Text = "(" & notapprovedlist.Rows.Count & ") Record Found "
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()

    End Sub
End Class