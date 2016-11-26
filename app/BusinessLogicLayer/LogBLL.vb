Imports DataAccessLayer
Imports DataTypeObject
Public Class LogBLL

    ' Obtiene los logs
    Public Function GetLog(ByRef since As String, ByRef until As String, level As LogCriteria.level) As ResultDTO
        Dim logDal As New LogDAL()
        Dim logs As List(Of LogDTO)
        Dim result As ResultDTO

        Try
            result = IsValid(since, until)

            If result.IsValid() Then
                Dim criteria = New LogCriteria(since, until, level)
                logs = logDal.GetLog(criteria)
                Return New ResultDTO(ResultDTO.type.OK, "Ok", logs, True)
            Else
                Return result
            End If

        Catch ex As Exception
            Return New ResultDTO(ResultDTO.type.EXCEPTION, "Se ha producido un error crítico: " + ex.Message)
        End Try

    End Function

    ' Crea un log
    Public Sub Log(ByRef loggeable As ILoggeable)
    End Sub

    ' Valida los inputs y reglas de negocio
    Private Function IsValid(ByRef since As String, ByRef until As String) As ResultDTO

    End Function
End Class
