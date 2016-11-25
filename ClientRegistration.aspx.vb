
Partial Class ClientRegistration
    Inherits System.Web.UI.Page
    Protected Sub BtnAccess_Click(sender As Object, e As EventArgs) Handles BtnAccess.Click

        ' Validacion rudimentaria
        If Len(TxtUser.Text) = 0 And Len(TxtPassword.Text) = 0 Then
            ' TODO - MOSTRAR MENSAJE DE ERROR
        Else
            ' Se asignan los datos a la variable de sesion y se envian
            Session("user") = TxtUser.Text
            Session("password") = TxtPassword.Text

            ' TODO - No se si se importa la clase LigInBLL o si se tiene que hacer redirect a otra página que se encargue de llamar a la clase en cuestión
            'Response.Redirect()
        End If
    End Sub
End Class
