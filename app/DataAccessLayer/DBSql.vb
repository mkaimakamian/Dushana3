Imports System.Data
Imports System.Data.SqlClient

Public Class DBSql
    Private connStr = "Data Source=DESKTOP-89RB8TN\SQLEXPRESS;Initial Catalog=LPPA;Integrated Security=True"
    ' Private connStr = "Data Source=.\UAI_EXPRESS; Initial Catalog=LPPA; Integrated Security=True"

    Public Function ExecuteNonQuery(ByRef sql As String)
        Dim connection As New SqlConnection(connStr)
        Dim command As New SqlCommand(sql, connection)
        Dim result As Integer

        connection.Open()
        result = command.ExecuteScalar()
        connection.Close()

        Return result
    End Function


    Public Function ExecuteReader(ByRef sql As String) As List(Of List(Of String))
        Dim connection As New SqlConnection(connStr)
        Dim command As New SqlCommand(sql, connection)
        Dim reader As SqlDataReader
        Dim result As New List(Of List(Of String))

        connection.Open()
        reader = command.ExecuteReader()

        If reader.HasRows Then
            Do While reader.Read()
                result.Add(Resolve(reader))
            Loop
        End If

        connection.Close()
        Return result
    End Function

    ' Devuelve una lista de cadenas de texto respetando el orden de  los campos
    Private Function Resolve(ByRef reader As SqlDataReader) As List(Of String)
        Dim result As New List(Of String)

        For i As Integer = 0 To reader.FieldCount - 1
            result.Add(reader.Item(i).ToString())
        Next

        Return result
    End Function
End Class