Imports DataAccessLayer
Imports DataTypeObject
Imports Helper
Public Class LogInBLL
    Const MAX_RETRIES = 3

    ' Se encarga de realizar el logueo del usuario
    Public Function LogIn(ByRef user As String, ByRef password As String) As ResultDTO
        Dim result As ResultDTO
        Try
            ' El proceso de logueo se basa en el cumplimiento de las reglas de negocio únicamente.
            result = IsValid(user, password)

            ' TODO: Debería devolverse una estructura que el frontend interprete (XML?)... por ahora ErrorDTO
            Return result
        Catch ex As Exception
            Return New ResultDTO(ResultDTO.type.EXCEPTION, "Se ha producido un error crítico: " + ex.Message)
        End Try

    End Function

    ' Valida el cumplimiento de los inputrs y de las reglas de negocio
    Private Function IsValid(ByRef user As String, ByRef password As String) As ResultDTO
        Dim securityHelper As New SecurityHelper()
        Dim logInDto As New LogInDTO()
        Dim logInDal As New LogInDAL()
        Dim userDto As UserDTO
        Dim logBll As New LogBLL()

        ' 1. Chequeo de inputs
        If Len(user) = 0 Or Len(password) = 0 Then
            'logBll.LogInfo()

            Return New ResultDTO(ResultDTO.type.INCOMPLETE_FIELDS, "Campos incompletos.")
        End If

        ' 2. Chequeo de existencia de usuario
        logInDto.user = user
            logInDto.password = securityHelper.Encrypt(password)
            userDto = logInDal.LogIn(logInDto)

        ' No se encontró el usuario para la combinación name + password... pero aún así puede existir el username y deben incrementarse los reintentos.
        If IsNothing(userDto) Then
            ' Se busca el usuario pero sin usar el password
            userDto = logInDal.GetUser(logInDto)

            'Si existe, entonces se debe incrementar los reintentos y eventualmente lockearlo si los excedió
            If Not IsNothing(userDto) Then
                logInDal.IncrementRetries(logInDto)
                userDto.retries += 1

                If userDto.retries = MAX_RETRIES Then
                    logInDal.LockUser(logInDto)
                    Return New ResultDTO(ResultDTO.type.MAX_ATTEMPTS, "Credenciales inválidas: el usuario ha excedido la cantidad de reintentos.")
                End If
            End If

            Return New ResultDTO(ResultDTO.type.INVALID_CREDENTIAL, "Credenciales inválidas.")
        Else
            ' 3. Chequeo de usuario lockeado
            If userDto.locked Then
                Return New ResultDTO(ResultDTO.type.MAX_ATTEMPTS, "El usuario ha excedido la cantidad de reintentos.")
            Else
                logInDal.ResetRetries(logInDto)
                userDto.retries = 0
                Return New ResultDTO(ResultDTO.type.OK, "Ok", userDto, True)
            End If
        End If
    End Function
End Class