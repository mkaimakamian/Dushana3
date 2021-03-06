﻿Imports BusinessLogicLayer
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

        Else
            txtUsuario.Text = Session("user").name
            If Session("restoreOnly") And HttpContext.Current.Request.Url.AbsolutePath <> "/Restore.aspx" And HttpContext.Current.Request.Url.AbsolutePath <> "/ViewerLog.aspx" Then
                Response.Redirect("Restore.aspx")
            End If

        End If
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Dim logBll As New LogBLL()
        logBll.AddLogInfo("Log out", "El usuario " + Session("user").name + " abandonó la sesión.", Me)
        Session.Clear()
        Response.Redirect("Login.aspx")
    End Sub
End Class

