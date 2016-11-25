Imports DataAccessLayer
Imports DataTypeObject
Imports Helper
Public Class LogInBLL

    Public Function LogIn(ByRef user As String, ByRef password As String) As ErrorDTO
        Dim result As ErrorDTO

        result = IsValid(user, password)

        If result.IsValid Then
            ' Se reinician los reintentos porque se loguea adecuadamente
            ' COMPLETAR

        Else
            If result.IsCurrentError(ErrorDTO.type.INVALIDA_CREDENTIAL) Then
                ' Si el error es de credencial, entonces hay que incrementar la cantidad de reintentos
                ' COMPLETAR
            End If
        End If

        ' Debería devolverse una estructura que devuelva el frontend como, por ejemplo, un array (o un ErrorDTO, como en este momento)
        Return result
    End Function

    ' Comprueba que las condiciones de logueo se cumplan
    Private Function IsValid(ByRef user As String, ByRef password As String) As ErrorDTO
        Dim securityHelper As New SecurityHelper()
        Dim logInDto As New LogInDTO()
        Dim logInDal As New LogInDAL()
        Dim result As UserDTO

        ' 1. Datos en blanco
        If Len(user) = 0 Or Len(password) = 0 Then
            Return New ErrorDTO(ErrorDTO.type.INCOMPLETE_FIELDS, "Campos incompletos.", True)
        End If

        ' 2. Credenciales válidas
        logInDto.user = user
        logInDto.password = securityHelper.Encrypt(password)
        result = logInDal.LogIn(logInDto)

        If result Is Nothing Then
            Return New ErrorDTO(ErrorDTO.type.INVALIDA_CREDENTIAL, "Credenciales inválidas.", True)
        Else
            ' 3. Usuario habilitado
            If result.locked Then
                Return New ErrorDTO(ErrorDTO.type.MAX_ATTEMPTS, "El usuario ha excedido la cantidad de reintentos.", True)
            End If
        End If

        Return New ErrorDTO(ErrorDTO.type.OK, "Ok", True)
    End Function
End Class