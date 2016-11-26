Imports DataAccessLayer
Imports DataTypeObject
Imports Helper
Public Class LogInBLL

    ' Se encarga de realizar el logueo del usuario
    Public Function LogIn(ByRef user As String, ByRef password As String) As ResultDTO
        Dim result As ResultDTO

        ' El proceso de logueo se basa en el cumplimiento de las reglas de negocio únicamente.
        result = IsValid(user, password)

        ' TODO: Debería devolverse una estructura que el frontend interprete (XML?)... por ahora ErrorDTO
        Return result
    End Function

    ' Valida el cumplimiento de los inputrs y de las reglas de negocio
    Private Function IsValid(ByRef user As String, ByRef password As String) As ResultDTO
        Dim securityHelper As New SecurityHelper()
        Dim logInDto As New LogInDTO()
        Dim logInDal As New LogInDAL()
        Dim userDto As UserDTO

        ' 1. Chequeo de inputs
        If Len(user) = 0 Or Len(password) = 0 Then
            Return New ResultDTO(ResultDTO.type.INCOMPLETE_FIELDS, "Campos incompletos.", False)
        End If

        ' 2. Chequeo de existencia de usuario
        logInDto.user = user
        logInDto.password = securityHelper.Encrypt(password)
        userDto = logInDal.LogIn(logInDto)

        If userDto Is Nothing Then
            ' Si no se pudo recuperar el usuario porque el password falló, entonces se incrementan los riententos.
            ' En caso de que no exista el nombre del usuario, el incremento no tiene efecto alguno.
            logInDal.IncrementRetries(logInDto)
            Return New ResultDTO(ResultDTO.type.INVALIDA_CREDENTIAL, "Credenciales inválidas.", False)
        Else
            ' 3. Chequeo de usuario lockeado
            If userDto.locked Then
                Return New ResultDTO(ResultDTO.type.MAX_ATTEMPTS, "El usuario ha excedido la cantidad de reintentos.", False)
            Else
                logInDal.ResetRetries(logInDto)
                userDto.retries = 0
                Return New ResultDTO(ResultDTO.type.OK, "Ok", True, userDto)
            End If
        End If
    End Function
End Class