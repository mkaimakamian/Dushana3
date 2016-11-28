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

            Return result
        Catch ex As Exception
            Return New ResultDTO(ResultDTO.type.EXCEPTION, "Se ha producido un error crítico: " + ex.Message)
        End Try

    End Function

    ' Valida el cumplimiento de los inputs y de las reglas de negocio
    Private Function IsValid(ByRef user As String, ByRef password As String) As ResultDTO
        Dim securityHelper As New SecurityHelper()
        Dim logInDto As New LogInDTO()
        Dim logInDal As New LogInDAL()
        Dim userDto As UserDTO
        Dim logBll As New LogBLL()

        ' 1. Chequeo de inputs
        If Len(user) = 0 Or Len(password) = 0 Then
            logBll.AddLogWarn("LogIn", "Campos incompletos.", Me)
            Return New ResultDTO(ResultDTO.type.INCOMPLETE_FIELDS, "Campos incompletos.")
        End If

        ' 2. Chequeo de existencia de usuario
        logInDto.user = user
        logInDto.password = securityHelper.Encrypt(password)
        userDto = logInDal.LogIn(logInDto)

        ' No se encontró el usuario para la combinación name + password... pero aún así puede existir el username y 
        ' deben incrementarse los reintentos.
        If IsNothing(userDto) Then
            ' Se busca el usuario pero sin usar el password
            userDto = logInDal.GetUser(logInDto)

            'Si existe, entonces se debe incrementar los reintentos y eventualmente lockearlo si los excedió
            If Not IsNothing(userDto) Then
                logInDal.IncrementRetries(logInDto)
                userDto.retries += 1

                If userDto.retries = MAX_RETRIES Then
                    logInDal.LockUser(logInDto)
                    logBll.AddLogWarn("LogIn", "El usuario " + logInDto.user + " alcanzó los reintentos permitidos.", Me)
                    Return New ResultDTO(ResultDTO.type.MAX_ATTEMPTS, "Credenciales inválidas: el usuario ha excedido la cantidad de reintentos.")
                Else
                    logBll.AddLogWarn("LogIn", "Se intentó acceder con el usuario " + logInDto.user + ". Reintentos: " + CStr(userDto.retries), Me)
                    Return New ResultDTO(ResultDTO.type.INVALID_CREDENTIAL, "Credenciales inválidas.")
                End If
            Else
                logBll.AddLogWarn("LogIn", "Se intentó acceder con el usuario inexistente " + logInDto.user, Me)
                Return New ResultDTO(ResultDTO.type.INVALID_CREDENTIAL, "Credenciales inválidas.")
            End If
        Else
            ' 3. Chequeo de inconsistencia
            If Not userDto.verified Then
                logBll.AddLogCritical("LogIn", "Inconsistencia en los datos del usuario " + userDto.name + ".", Me)
                Return New ResultDTO(ResultDTO.type.CHECKSUM_ERROR, "El registro se encuentra corrupto.")
            End If

            ' 4. Chequeo de usuario lockeado
            If userDto.locked Then
                logBll.AddLogWarn("LogIn", "El usuario ha excedido la cantidad de reintentos.", Me)
                Return New ResultDTO(ResultDTO.type.MAX_ATTEMPTS, "El usuario ha excedido la cantidad de reintentos.")
            Else
                logInDal.ResetRetries(logInDto)
                userDto.retries = 0
                logBll.AddLogInfo("LogIn", "El usuaro " + userDto.name + " se ha logueado exitosamente.", Me)
                Return New ResultDTO(ResultDTO.type.OK, "Ok", userDto, True)
            End If
        End If
    End Function
End Class