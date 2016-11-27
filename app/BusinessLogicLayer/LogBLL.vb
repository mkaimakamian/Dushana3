Imports DataAccessLayer
Imports DataTypeObject
Public Class LogBLL

    ' Obtiene los logs
    Public Function GetLog(ByRef level As String, ByRef Optional since As String = Nothing, ByRef Optional until As String = Nothing, ByRef Optional entity As String = Nothing) As ResultDTO
        Dim logDal As New LogDAL()
        Dim logs As List(Of LogDTO)

        Try
            logs = logDal.GetLogs(level, since, until, entity)
            Return New ResultDTO(ResultDTO.type.OK, "Ok", logs, True)

        Catch ex As Exception
            Return New ResultDTO(ResultDTO.type.EXCEPTION, "Se ha producido un error crítico: " + ex.Message)
        End Try

    End Function

    ' Crea un log de nivel info
    Public Sub AddLogInfo(ByRef action As String, ByRef description As String, ByRef entity As Object)
        CreateLog(LogDTO.level.INFO, action, description, entity.GetType().ToString())
    End Sub

    ' Crea un log de nivel warn
    Public Sub AddLogWarn(ByRef action As String, ByRef description As String, ByRef entity As Object)
        CreateLog(LogDTO.level.WARNING, action, description, entity.GetType().ToString())
    End Sub

    ' Crea un log de nivel critical
    Public Sub AddLogCritical(ByRef action As String, ByRef description As String, ByRef entity As Object)
        CreateLog(LogDTO.level.CRITICAL, action, description, entity.GetType().ToString())
    End Sub

    ' Crea un log de nivel debug
    Public Sub AddLogDebug(ByRef action As String, ByRef description As String, ByRef entity As Object)
        CreateLog(LogDTO.level.DEBUG, action, description, entity.GetType().ToString())
    End Sub

    Private Sub CreateLog(ByRef loglevel As String, ByRef action As String, ByRef description As String, ByRef entity As String)
        Dim logDal As New LogDAL()
        Dim logDto As New LogDTO(loglevel, action, description, entity)
        logDal.SaveLog(logDto)
    End Sub
End Class
