﻿Imports DataTypeObject

Public Class CheckDBDAL

    'Obtengo el DVV guardado en la Base
    Public Function getDVV() As dvvDTO
        Dim dbsql As New DBSql
        Dim sql As String
        Dim reader As List(Of List(Of String))
        sql = "SELECT * FROM dvv"
        reader = dbsql.ExecuteReader(sql)

        If reader.Count > 0 Then
            Return ResolveDVV(reader.First)
        Else
            Return Nothing
        End If

    End Function

    'Calculo el DVV
    Public Function calculateDVV() As dvvDTO
        Dim dbsql As New DBSql
        Dim sql As String
        Dim reader As List(Of List(Of String))
        sql = "SELECT CHECKSUM_AGG(v.lala) FROM  (SELECT BINARY_CHECKSUM(name, password, type) lala FROM users) v"
        reader = dbsql.ExecuteReader(sql)

        If reader.Count > 0 Then
            Return ResolveDVV(reader.First)
        Else
            Return Nothing
        End If

    End Function

    Private Function ResolveDVH(ByRef item As List(Of String)) As dvhDTO
        Dim result As New dvhDTO
        result.name = CStr(item.Item(0))
        result.newDvh = CInt(item.Item(2))
        result.dvh = CInt(item.Item(1))
        Return result
    End Function

    Private Function ResolveDVV(ByRef item As List(Of String)) As dvvDTO
        Dim result As New dvvDTO
        result.dvv = CStr(item.Item(0))
        Return result
    End Function



End Class

