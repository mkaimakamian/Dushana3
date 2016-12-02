Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BusinessLogicLayer
Imports DataAccessLayer
Imports DataTypeObject
Imports Helper

<TestClass()> Public Class LoginTest

    ' Se ejecuta siempre antes de cada método... y pone a 0 los datos del logueo
    <TestInitialize()> Public Sub Inicializar()
        Dim dal As New LogInDAL()
        Dim login As New LogInDTO()
        login.user = "admin"
        dal.UnlockUser(login)
    End Sub


    <TestMethod()> Public Sub LoginOk()

        ' Prueba que se logue el usuario admin
        Dim login As New LogInBLL
        Dim result As ResultDTO
        result = login.LogIn("admin", "Admin")

        ' Asserts de algunas cosas como para tener una idea somera del funcionamiento
        Assert.AreEqual("Ok", result.description)
        Assert.IsTrue(result.IsValid())
        Assert.AreEqual(CType(result.value, UserDTO).name, "admin")
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
        login.LogIn("admin", "xxxx")

        ' Usuario debería poder continuar reintentando
        result = login.LogIn("admin", "xxxx")
        Assert.IsTrue(result.IsCurrentError(ResultDTO.type.INVALID_CREDENTIAL))

        ' Usuario Lockeado
        result = login.LogIn("admin", "xxxx")
        Assert.IsTrue(result.IsCurrentError(ResultDTO.type.MAX_ATTEMPTS))
    End Sub

    <TestMethod()> Public Sub LoginRetries()

        ' Prueba el locked
        Dim login As New LogInBLL
        Dim result As ResultDTO
        login.LogIn("admin", "xxxx")

        ' Usuario debería poder continuar reintentando
        result = login.LogIn("admin", "xxxx")
        Assert.IsTrue(result.IsCurrentError(ResultDTO.type.INVALID_CREDENTIAL))

        ' Usuario Lockeado
        result = login.LogIn("admin", "Admin")
        Assert.IsTrue(result.IsCurrentError(ResultDTO.type.OK))
    End Sub

    <TestMethod()> Public Sub TestHashing()

        Dim securityHelper As New SecurityHelper()
        Dim p1 As String = securityHelper.Encrypt("Admin")
        Dim p2 As String = securityHelper.Encrypt("Usuario")
        Dim p3 As String = securityHelper.Encrypt("Ssabato")

    End Sub

End Class