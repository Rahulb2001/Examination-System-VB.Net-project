Imports System.Data.SqlClient
Public Class approvalformstu
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\Desktop\exam pics\Exam_Database.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub approvalformstu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadrecord()
    End Sub
    Public Sub loadrecord()
        Dim i As Integer = 0
        DataGridView1.Rows.Clear()
        con.Open()
        cmd = New SqlCommand("select * from registration where approve not in ('yes')", con)
        dr = cmd.ExecuteReader
        While dr.Read
            i += 1
            DataGridView1.Rows.Add(dr.Item("stdno").ToString, i, dr.Item("studname"), dr.Item("gender").ToString, dr.Item("course"), dr.Item("qualification"), dr.Item("dob"), "Yes")

        End While
        dr.Close()
        con.Close()
        Label2.Text = "(" & DataGridView1.Rows.Count & ") Record Found "
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim colname As String = DataGridView1.Columns(e.ColumnIndex).Name
        If (colname = "Column8") Then
            If (MsgBox("Do you want approve this student", vbYesNo + vbQuestion) = vbYes) Then
                con.Open()
                cmd = New SqlCommand("Update registration set approve = 'Yes' where stdno='" & id & "'", con)
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("Student approved Sucessfully", vbInformation)
                loadrecord()

            End If
        End If
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Dim i As Integer = DataGridView1.CurrentRow.Index
        id = DataGridView1.Item(0, i).Value
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()

    End Sub
End Class