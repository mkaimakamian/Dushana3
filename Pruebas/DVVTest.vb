Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BusinessLogicLayer
Imports DataAccessLayer
Imports DataTypeObject

<TestClass()> Public Class DVVTest

    <TestMethod()> Public Sub TestDVV()

        Dim CheckDBDAL As New CheckDBDAL
        Dim OriginDVV As dvvDTO
        Dim CalculatedDVV As dvvDTO

        OriginDVV = CheckDBDAL.getDVV
        'Calculo el DVV
        CalculatedDVV = CheckDBDAL.calculateDVV

        Assert.AreEqual(OriginDVV.dvv, CalculatedDVV.dvv, "Deberían ser iguales")
    End Sub

    <TestMethod()> Public Sub TestDVVADetailed()

        Dim DVVBusiness As New CheckDataBaseBLL()
        Dim checkResul As ResultDTO = DVVBusiness.CheckDVVDetailed()

        Assert.IsTrue(checkResul.IsValid(), "Debería ser válido")

    End Sub

End Class