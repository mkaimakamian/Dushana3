Imports DataTypeObject

Public Class LogInDAL

    Public Function LogIn(ByRef userLogin As LogInDTO) As UserDTO
        Dim dbsql As New DBSql
        Dim sql As String
        Dim reader As List(Of List(Of String))
        sql = "SELECT * FROM users WHERE name = '" + userLogin.user + "' AND password = '" + userLogin.password + "'"
        reader = dbsql.ExecuteReader(sql)

        If reader.Count > 0 Then
            Return Resolve(reader.First)
        Else
            Return Nothing
        End If
    End Function

    Private Function Resolve(ByRef item As List(Of String)) As UserDTO
        Dim result As New UserDTO
        result.user = CInt(item.Item(0))
        result.locked = CBool(item.Item(1))
        result.retries = CInt(item.Item(2))
        Return result
    End Function
End Class