Imports System.Data.SqlClient
Module Module1
    Public cmd As New SqlCommand
    Public dr As SqlDataReader
    Public da As SqlDataAdapter
    Public struser As String = "Rahul"
    Public connectionstring As String
    Public con As New SqlConnection(connectionstring)
    Public i As Integer
    Public n As String = ""
    Public utype As String = "rahul"
    Public str As String = ""
    Public ds As New DataSet
    Public id As Double
    Dim gen As String = ""
    Public r As String = ""
    Public sem As String = ""
    Public course As String = ""
    Public se As Integer
    Public qnum As Integer
    Public qn As String
    Public ans As String = ""
    Public an As String = ""
    Public d1 As DateTime
    Public rr As String = ""


End Module
