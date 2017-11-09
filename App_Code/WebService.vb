Imports System.Web
Imports System.Web.Services
Imports DataTypeObject
Imports System.Web.Services.Protocols

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WebService
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function HelloWorld() As String
        Return "Hola a todos"
    End Function

    <WebMethod()>
    Public Function CalculateDiscount(listPrice As Integer) As Integer
        Dim finalPrice As Integer
        If listPrice > 500 Then
            finalPrice = 500 * 0.9
        Else
            finalPrice = listPrice
        End If
        Return finalPrice
    End Function


End Class