Public Class BackUpRestoreDAL

    Public Function doBackup() As Object
        Dim dbsql As New DBSql
        Dim sql As String
        Dim result As Object

        sql = "BACKUP DATABASE LPPA TO DISK = 'C:\LPPA\Dushana\Backup\LPPA.BAK'"
        Return result = dbsql.ExecuteNonQuery(sql)
    End Function

    Public Function doRestore() As Object
        Dim dbsql As New DBSql
        Dim sql As String
        Dim result As Object

        sql = "USE MASTER RESTORE DATABASE LPPA FROM DISK = 'C:\LPPA\Dushana\Backup\LPPA.BAK' WITH REPLACE"
        Return result = dbsql.ExecuteNonQuery(sql)
    End Function

End Class
