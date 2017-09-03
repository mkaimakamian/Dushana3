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

    ''' <summary>
    ''' Devuelve el detalle de las entidades corruptas
    ''' </summary>
    ''' <returns></returns>
    Public Function CheckDVVDetailed() As ResultDTO
        Dim logBll As New LogBLL()
        Dim CheckDBDAL As New CheckDBDAL
        Dim lstOfDVV As List(Of dvvDTO)
        Dim calculatedDVV As dvvDTO
        Dim lstOfFailed As New List(Of String)

        Try
            'Lista de dígitos verticales
            lstOfDVV = CheckDBDAL.getDVVDetailed

            For Each itemToCheck As dvvDTO In lstOfDVV
                'Calculo el DVV
                calculatedDVV = CheckDBDAL.calculateDVV(itemToCheck.entity)

                If itemToCheck.dvv = calculatedDVV.dvv Then
                    logBll.AddLogInfo("Check DVV", "La integridad del " + itemToCheck.entity + " esta ok", Me)
                Else
                    logBll.AddLogCritical("Check DVV", "La integridad del " + itemToCheck.entity + " requiere restaurar la base de datos.", Me)
                    lstOfFailed.Add(itemToCheck.entity)
                End If
            Next

            'Comparo el DVV original contra el que fue calculado
            If lstOfFailed.Count = 0 Then
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


End Class
