Imports BusinessLogicLayer
Imports DataTypeObject
Partial Class LogIn
    Inherits System.Web.UI.Page

    Protected Sub BtnAccess_Click(sender As Object, e As EventArgs) Handles BtnAccess.Click

        Dim LogInBLL As New LogInBLL()
        Dim result As ResultDTO
        Dim CheckDataBaseBLL As New CheckDataBaseBLL
        Dim dvResultDTO As ResultDTO

        result = LogInBLL.LogIn(TxtUser.Text, TxtPassword.Text)

        If result.IsValid() Then
            Session("user") = result.value
            dvResultDTO = CheckDataBaseBLL.CheckDVVDetailed

            If dvResultDTO.IsCurrentError(ResultDTO.type.CORRUPTED_DATABASE) Then
                If result.value.type = 1 Then
                    Session("restoreOnly") = True
                    Response.Redirect("Restore.aspx")
                Else
                    MsgBox(dvResultDTO.description, vbOKOnly, "Error")
                End If
            Else
                Response.Redirect("Home.aspx")
            End If

        Else
            MsgBox(result.description, vbOKOnly, "Error")
        End If

    End Sub

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
        Session.Clear()
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
End Class
