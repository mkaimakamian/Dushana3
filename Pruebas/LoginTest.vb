Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BusinessLogicLayer
Imports DataTypeObject

<TestClass()> Public Class LoginTest

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

        ' Prueba que se logue el usuario admin
        Dim login As New LogInBLL
        Dim result As ResultDTO
        result = login.LogIn("Admin", "xxxx")

        ' Asserts de algunas cosas como para tener una idea somera del funcionamiento
        Assert.AreEqual("Credenciales inválidas.", result.description)
        Assert.IsFalse(result.IsValid())
        Assert.IsNull(result.value)        
    End Sub
End Class