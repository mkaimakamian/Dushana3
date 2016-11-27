Imports DataAccessLayer
Imports DataTypeObject
Public Class LogBLL

    ' Obtiene los logs
    Public Function GetLog(ByRef since As String, ByRef until As String, level As String, ByRef entity As String) As ResultDTO
        Dim logDal As New LogDAL()
        Dim logs As List(Of LogDTO)

        Try

            logs = logDal.GetLog(since, until, level, entity)
            Return New ResultDTO(ResultDTO.type.OK, "Ok", logs, True)

        Catch ex As Exception
            Return New ResultDTO(ResultDTO.type.EXCEPTION, "Se ha producido un error crítico: " + ex.Message)
        End Try

    End Function

    ' Crea un log
    Public Sub LogInfo(ByRef action As String, ByRef description As String, level As String, ByRef entity As String)
    End Sub
End Class
