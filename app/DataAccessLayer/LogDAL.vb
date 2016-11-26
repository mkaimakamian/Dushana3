Imports DataTypeObject
Public Class LogDAL

    ' Busca al usuario que se corresponde con las credenciales provistas
    Public Function GetLog(ByRef criteria As LogCriteria) As List(Of LogDTO)
        Dim dbsql As New DBSql
        Dim sql As String
        Dim reader As List(Of List(Of String))
        Dim result As New List(Of LogDTO)

        sql = "SELECT * FROM log WHERE level = '" + criteria.level + "' AND time BETWEEN '" + criteria.since + "' AND '" + criteria.until + "' "
        reader = dbsql.ExecuteReader(sql)

        If reader.Count > 0 Then
            For i As Integer = 0 To reader.Count - 1
                result.Add(Resolve(reader.Item(i)))
            Next
        End If

        Return result
    End Function

    Private Function Resolve(ByRef item As List(Of String)) As LogDTO
        Dim result As New LogDTO
        'result.name = CStr(item.Item(0))
        'result.locked = CBool(item.Item(2))
        'result.retries = CInt(item.Item(3))
        Return result
    End Function
End Class
