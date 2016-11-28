Imports BusinessLogicLayer
Imports DataTypeObject
Partial Class LogIn
    Inherits System.Web.UI.Page

    Protected Sub BtnAccess_Click(sender As Object, e As EventArgs) Handles BtnAccess.Click

        Dim loginBll As New LogInBLL()
        Dim result As ResultDTO
        result = loginBll.LogIn(TxtUser.Text, TxtPassword.Text)

        If result.IsValid() Then
            Session("user") = result.value
            Response.Redirect("Home.aspx")
        Else
            MsgBox(result.description, vbOKOnly, "Error")
        End If
    End Sub
End Class
