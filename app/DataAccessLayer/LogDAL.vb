Imports DataTypeObject
Public Class LogDAL

    ' Busca los logs que se corresponden con los criterios
    Public Function GetLogs(level As String, ByRef since As String, ByRef until As String, ByRef entity As String) As List(Of LogDTO)
        Dim dbsql As New DBSql
        Dim sql As String
        Dim reader As List(Of List(Of String))
        Dim result As New List(Of LogDTO)

        Dim dateCriterion As String = ""
        Dim entityCriterion As String = ""

        If Len(since) > 0 And Len(until) > 0 Then
            dateCriterion = " AND created BETWEEN convert(datetime, '" + since + "', 103) AND convert(datetime,'" + until + "', 103)"

        ElseIf Len(since) > 0 And Len(until) = 0 Then
            dateCriterion = " AND created >= convert(datetime,'" + since + "', 103)"

        ElseIf Len(since) = 0 And Len(until) > 0 Then
            dateCriterion = " AND created <= convert(datetime,'" + until + "', 103)"
        End If

        If Len(entityCriterion) > 0 Then
            entityCriterion = " AND entity = '" + entity + "'"
        End If

        sql = "SELECT * FROM logs WHERE loglevel >= " + level + entityCriterion + dateCriterion
        reader = dbsql.ExecuteReader(sql)

        If reader.Count > 0 Then
            For i As Integer = 0 To reader.Count - 1
                result.Add(Resolve(reader.Item(i)))
            Next
        End If

        Return result
    End Function

    Public Sub SaveLog(ByRef log As LogDTO)
        Dim dbsql As New DBSql
        Dim sql As String
        sql = "INSERT INTO logs (loglevel, action, description, entity, created) "
        sql += " VALUES ("
        sql += CStr(log.logLevel) + ", "
        sql += "'" + log.action + "' , "
        sql += "'" + log.description + "' , "
        sql += "'" + log.entity + "' , "
        sql += "GETDATE()"
        sql += "); SELECT @@IDENTITY"
        log.id = dbsql.ExecuteNonQuery(sql)
    End Sub

    Public Sub DeleteLogs()
        Dim dbsql As New DBSql
        dbsql.ExecuteNonQuery("TRUNCATE TABLE logs")
    End Sub

    Private Function Resolve(ByRef item As List(Of String)) As LogDTO
        Dim result As New LogDTO()
        result.id = item.Item(0)
        result.logLevel = CInt(item.Item(1))
        result.action = item.Item(2)
        result.description = item.Item(3)
        result.entity = item.Item(4)
        result.created = item.Item(5)
        Return result
    End Function
End Class
