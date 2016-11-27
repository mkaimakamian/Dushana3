Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BusinessLogicLayer
Imports DataTypeObject

<TestClass()> Public Class CustomerTest

    <TestMethod()> Public Sub GetCustomers()
        Dim result As ResultDTO
        Dim customersBll As New CustomerBLL()
        result = customersBll.GetCustomers()

        ' Para constatar la cantidad, chequear la clase CustomerDal
        Assert.AreEqual(CType(result.value, List(Of CustomerDTO)).Count, 6)
    End Sub

    <TestMethod()> Public Sub GetCustomer()
        Dim result As ResultDTO
        Dim customersBll As New CustomerBLL()
        result = customersBll.GetCustomer(1)
        Assert.AreEqual(CType(result.value, CustomerDTO).name, "Alberto", "El usuario debería llamarse Alberto")
    End Sub

    <TestMethod()> Public Sub GetInexistentCustomer()
        Dim result As ResultDTO
        Dim customersBll As New CustomerBLL()
        result = customersBll.GetCustomer(100)
        Assert.IsNull(result.value, "El usuario no debería existir")
    End Sub
End Class