Imports DataAccessLayer
Imports DataTypeObject
Imports Helper
Public Class LogInBLL

    Public Sub LogIn(ByRef user As String, ByRef password As String)
        Dim securityHelper As New SecurityHelper()
        Dim logInDto As New LogInDTO()
        Dim logInDal As New LogInDAL()
        Dim result As Boolean

        ' Se instancia el modelo de login
        logInDto.user = user
        logInDto.password = securityHelper.Encrypt(password)

        ' Se procede al logueo
        result = logInDal.LogIn(logInDto)

        If result Then
            ' TODO - Si resulta exitoso el logueo, se debería registrar en sesión (¿tiene sentido una clase de esas características?)
        Else
            ' TODO - devolver mensaje de error indicando que el usuario o password ingresado, es incorrecto 8sin especificar cual)
        End If

    End Sub
End Class