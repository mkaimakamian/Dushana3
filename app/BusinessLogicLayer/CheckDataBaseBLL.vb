Imports DataAccessLayer
Imports DataTypeObject

Public Class CheckDataBaseBLL
    'Se encarga de verificar el DVV de la base
    Public Function CheckDVV() As ResultDTO
        Dim logBll As New LogBLL()
        Dim CheckDBDAL As New CheckDBDAL
        Dim OriginDVV As dvvDTO
        Dim CalculatedDVV As dvvDTO

        Try
            'Devuelvo el DVV calculado
            OriginDVV = CheckDBDAL.getDVV
            'Calculo el DVV
            CalculatedDVV = CheckDBDAL.calculateDVV

            'Comparo el DVV original contra el que fue calculado
            If OriginDVV.dvv = CalculatedDVV.dvv Then
                logBll.AddLogInfo("Check DVV", "La integridad del DVV esta ok", Me)
                Return New ResultDTO(ResultDTO.type.OK, "DVV Ok")
            Else
                logBll.AddLogCritical("Check DVV", "El DVV fue Corrupto, realizar Restore.", Me)
                Return New ResultDTO(ResultDTO.type.CORRUPTED_DATABASE, "Error en el DVV, DB Corrupta")
            End If
        Catch ex As Exception
            Return New ResultDTO(ResultDTO.type.EXCEPTION, "Se ha producido un error crítico: " + ex.Message)
        End Try
    End Function

    'TODO: iterar el DS que recibo desde la DAL y comprar aentre si los campos de NuevoDH y DHCalculado

End Class
