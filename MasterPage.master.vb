Imports BusinessLogicLayer
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Private Sub MasterPage_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsNothing(Session("user")) Then
            ' Si no se encuentra la información del usuario, entonces se considera una maniobra extraña y 
            ' se redirige a la página de login
            Dim logBll As New LogBLL()
            logBll.AddLogCritical("Acceso", "Posible ataque - acceso sin user en sesión.", Me)
            MsgBox("Acceso ilegal.", vbOKOnly, "Acceso prohibido")
            Response.Redirect("LogIn.aspx")
        End If

    End Sub

End Class

