﻿Imports DataTypeObject
Imports DataAccessLayer
Imports System.Data.SqlClient

Public Class LogInDAL

    ' Busca al usuario que se corresponde con las credenciales provistas
    Public Function LogIn(ByRef userLogin As LogInDTO) As UserDTO
        Dim dbsql As New DBSql
        Dim sql As String
        Dim reader As List(Of List(Of String))

        sql = "SELECT name, locked, retries, CASE WHEN hdigit =  BINARY_CHECKSUM(name, password, type) then 1 ELSE 0 END verified, type FROM users "
        sql += "WHERE name = '" + userLogin.user + "' AND password = '" + userLogin.password + "'"

        reader = dbsql.ExecuteReader(sql)

        If reader.Count > 0 Then
            Return Resolve(reader.First)
        Else
            Return Nothing
        End If
    End Function

    ' Busca al usuario que se corresponde con las credenciales provistas
    Public Function GetUser(ByRef userLogin As LogInDTO) As UserDTO
        Dim dbsql As New DBSql
        Dim sql As String
        Dim reader As List(Of List(Of String))

        sql = "SELECT name, locked, retries, CASE WHEN hdigit =  BINARY_CHECKSUM(name, password, type) then 1 ELSE 0 END verified, type FROM users "
        sql += "WHERE name = '" + userLogin.user + "'"
        reader = dbsql.ExecuteReader(sql)

        If reader.Count > 0 Then
            Return Resolve(reader.First)
        Else
            Return Nothing
        End If
    End Function

    ' Incrementa en uno los reintentos de logueo
    Public Sub IncrementRetries(ByRef userLogin As LogInDTO)
        Dim dbsql As New DBSql
        Dim sql As String
        Dim result As Object

        sql = "UPDATE users SET retries = retries + 1 WHERE name = '" + userLogin.user + "'"
        result = dbsql.ExecuteNonQuery(sql)
    End Sub

    ' Resetea los reintentos
    Public Sub ResetRetries(ByRef userLogin As LogInDTO)
        Dim dbsql As New DBSql
        Dim sql As String

        sql = "UPDATE users SET retries = 0 WHERE name = '" + userLogin.user + "'"
        dbsql.ExecuteNonQuery(sql)
    End Sub

    ' Lockea al usuario
    Public Sub LockUser(ByRef userLogin As LogInDTO)
        Dim dbsql As New DBSql
        Dim sql As String

        sql = "UPDATE users SET locked = 1 WHERE name = '" + userLogin.user + "'"
        dbsql.ExecuteNonQuery(sql)
    End Sub

    ' Deslockea al usuario y resetea los retries
    Public Sub UnlockUser(ByRef userLogin As LogInDTO)
        Dim dbsql As New DBSql
        Dim sql As String

        sql = "UPDATE users SET locked = 0, retries = 0 WHERE name = '" + userLogin.user + "'"
        dbsql.ExecuteNonQuery(sql)
    End Sub

    Private Function Resolve(ByRef item As List(Of String)) As UserDTO
        Dim result As New UserDTO
        result.name = CStr(item.Item(0))
        result.locked = CBool(item.Item(1))
        result.retries = CInt(item.Item(2))
        result.verified = CBool(item.Item(3))
        result.type = item.Item(4)
        Return result
    End Function
End Class