﻿Imports BusinessLogicLayer
Partial Class BackUp
    Inherits System.Web.UI.Page

    Protected Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        Dim BackUpRestoreBLL As New BackupRestoreBLL
        BackUpRestoreBLL.doBackup()
        MsgBox("Se realizo Backup de la DB", MsgBoxStyle.Information, "Backup")
    End Sub
End Class
