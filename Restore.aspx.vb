Imports BusinessLogicLayer
Partial Class Restore
    Inherits System.Web.UI.Page

    Protected Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        Dim BackUpRestoreBLL As New BackupRestoreBLL
        BackUpRestoreBLL.doRestore()
        MsgBox("Se realizo Restore de la DB", MsgBoxStyle.Information, "Restore")
    End Sub
End Class
