Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BusinessLogicLayer
Imports DataTypeObject

<TestClass()> Public Class ProductTest

    <TestMethod()> Public Sub GetProducts()
        Dim result As ResultDTO
        Dim productBll As New ProductBLL()
        result = productBll.GetProducts()

        ' Para constatar la cantidad, chequear la clase ProductDal
        Assert.AreEqual(CType(result.value, List(Of ProductDTO)).Count, 5)
    End Sub

    <TestMethod()> Public Sub GetProduct()
        Dim result As ResultDTO
        Dim productBll As New ProductBLL()
        result = productBll.GetProduct(1)
        Assert.AreEqual(CType(result.value, ProductDTO).name, "Peeling", "El producto debería ser Peeling.")
    End Sub

    <TestMethod()> Public Sub GetInexistentProduct()
        Dim result As ResultDTO
        Dim productBll As New ProductBLL()
        result = productBll.GetProduct(100)
        Assert.IsNull(result.value, "El producto no debería existir")
    End Sub
End Class