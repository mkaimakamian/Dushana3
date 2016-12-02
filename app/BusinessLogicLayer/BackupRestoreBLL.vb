Imports DataAccessLayer

Public Class BackupRestoreBLL

    Public Sub doBackup()
        Dim LogBLL As New LogBLL
        Dim BackUpRestoreDAL As New BackUpRestoreDAL
        Dim result As Object

        result = BackUpRestoreDAL.doBackup()

        If result = True Then
            LogBLL.AddLogInfo("Backup", "Se realizo Backup de la DB", Me)
        Else
            LogBLL.AddLogCritical("Backup", "No se pudo realizar BackUp.", Me)
        End If

    End Sub

    Public Sub doRestore()
        Dim LogBLL As New LogBLL
        Dim BackUpRestoreDAL As New BackUpRestoreDAL
        Dim result As Object

        result = BackUpRestoreDAL.doRestore()

        If result = True Then
            LogBLL.AddLogInfo("Restore", "Se realizo Restore de la DB", Me)
        Else
            LogBLL.AddLogCritical("Backup", "No se pudo realizar Restore.", Me)
        End If

    End Sub

End Class
