﻿Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BusinessLogicLayer
Imports DataAccessLayer
Imports DataTypeObject

<TestClass()> Public Class LoginTest

    ' Se ejecuta siempre antes de cada método... y pone a 0 los datos del logueo
    <TestInitialize()> Public Sub Inicializar()
        Dim dal As New LogInDAL()
        Dim login As New LogInDTO()
        login.user = "Admin"
        dal.UnlockUser(login)
    End Sub


    <TestMethod()> Public Sub LoginOk()

        ' Prueba que se logue el usuario admin
        Dim login As New LogInBLL
        Dim result As ResultDTO
        result = login.LogIn("Admin", "Admin")

        ' Asserts de algunas cosas como para tener una idea somera del funcionamiento
        Assert.AreEqual("Ok", result.description)
        Assert.IsTrue(result.IsValid())
        Assert.AreEqual(CType(result.value, UserDTO).name, "Admin")
        Assert.AreEqual(CType(result.value, UserDTO).retries, 0)
    End Sub

    <TestMethod()> Public Sub LoginFail()

        ' Prueba que no logue el usuario admin
        Dim login As New LogInBLL
        Dim result As ResultDTO
        result = login.LogIn("Admin", "xxxx")

        ' Asserts de algunas cosas como para tener una idea somera del funcionamiento
        Assert.AreEqual("Credenciales inválidas.", result.description)
        Assert.IsFalse(result.IsValid())
        Assert.IsNull(result.value)        
    End Sub

    <TestMethod()> Public Sub LoginLocked()

        ' Prueba el locked
        Dim login As New LogInBLL
        Dim result As ResultDTO
        login.LogIn("Admin", "xxxx")

        ' Usuario debería poder continuar reintentando
        result = login.LogIn("Admin", "xxxx")
        Assert.IsTrue(result.IsCurrentError(ResultDTO.type.INVALID_CREDENTIAL))

        ' Usuario Lockeado
        result = login.LogIn("Admin", "xxxx")
        Assert.IsTrue(result.IsCurrentError(ResultDTO.type.MAX_ATTEMPTS))
    End Sub

    <TestMethod()> Public Sub LoginRetries()

        ' Prueba el locked
        Dim login As New LogInBLL
        Dim result As ResultDTO
        login.LogIn("Admin", "xxxx")

        ' Usuario debería poder continuar reintentando
        result = login.LogIn("Admin", "xxxx")
        Assert.IsTrue(result.IsCurrentError(ResultDTO.type.INVALID_CREDENTIAL))

        ' Usuario Lockeado
        result = login.LogIn("Admin", "Admin")
        Assert.IsTrue(result.IsCurrentError(ResultDTO.type.OK))
    End Sub
End Class