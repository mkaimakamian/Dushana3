Imports BusinessLogicLayer
Imports DataTypeObject
Partial Class LogIn
    Inherits System.Web.UI.Page

    Protected Sub BtnAccess_Click(sender As Object, e As EventArgs) Handles BtnAccess.Click

        Dim CheckDataBaseBLL As New CheckDataBaseBLL
        Dim dvResultDTO As ResultDTO
        dvResultDTO = CheckDataBaseBLL.CheckDVV

        If dvResultDTO.IsCurrentError(ResultDTO.type.CORRUPTED_DATABASE) Then
            Response.Redirect("Restore.aspx")
        Else
            Dim LogInBLL As New LogInBLL()
            Dim result As ResultDTO
            result = LogInBLL.LogIn(TxtUser.Text, TxtPassword.Text)

            If result.IsValid() Then
                Session("user") = result.value
                Response.Redirect("Home.aspx")
            Else
                MsgBox(result.description, vbOKOnly, "Error")
            End If
        End If
    End Sub

End Class
