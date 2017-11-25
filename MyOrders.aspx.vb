Imports System.Xml
Imports System.Xml.XPath

Partial Class MyOrders
    Inherits System.Web.UI.Page
    Public sellTable As String


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim docum As New XPathDocument(Server.MapPath("ventas.xml"))
            Dim nav As XPathNavigator
            Dim ite As XPathNodeIterator

            nav = docum.CreateNavigator
            Session.Add("Ventas", docum)
            ite = nav.Select("dushana/venta/@fecha")

            While ite.MoveNext
                dropFechas.Items.Add(ite.Current.Value)
            End While

            PrintSells(dropFechas.SelectedValue)
        End If

    End Sub

    Protected Sub dropFechas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dropFechas.SelectedIndexChanged
        PrintSells(dropFechas.SelectedValue)
    End Sub

    Private Sub PrintSells(ByRef selectedDate As String)

        Dim miDoc As XPathDocument = Session("Ventas")
        Dim nav As XPathNavigator = miDoc.CreateNavigator()

        Dim servicesNav As XPathNavigator = nav.SelectSingleNode("dushana/venta[@fecha='" + selectedDate + "']/cliente[@nombre='" + Session("user").name + "']")

        sellTable += "Fecha seleccionada: " + selectedDate + "</p>"
        sellTable += "<b>Productos</b> </p>"

        If IsNothing(servicesNav) Then
            sellTable = "No se han efectuado compras en el día de la fecha."
            Return
        End If

        For Each productNav As XPathNavigator In servicesNav.Select("servicios/producto")
            sellTable += "<b>Código&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>&nbsp;" + productNav.SelectSingleNode("id").Value + "</br>"
            sellTable += "<b>Tratamiento:</b>&nbsp;" + productNav.SelectSingleNode("nombre").Value + "</br>"
            sellTable += "<b>Descripción&nbsp;:</b>&nbsp;" + productNav.SelectSingleNode("descripcion").Value + "</br>"
            sellTable += "<b>Precio&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>&nbsp;" + productNav.SelectSingleNode("precio").Value + "</br>"
            sellTable += "</p></p>"
        Next
        sellTable += "</p></p>"
        sellTable += "--------------------"
        sellTable += "</p></p>"
        sellTable += "Total parcial:&nbsp;" + servicesNav.SelectSingleNode("facturacion/totalLista").Value + "</br>"
        sellTable += "Bonificación:&nbsp;&nbsp;" + servicesNav.SelectSingleNode("facturacion/bonificacion").Value + "</br>"
        sellTable += "Total final:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + servicesNav.SelectSingleNode("facturacion/totalFinal").Value + "</br>"


    End Sub
End Class
