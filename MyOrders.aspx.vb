Imports System.Xml
Imports System.Xml.XPath

Partial Class MyOrders
    Inherits System.Web.UI.Page

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
        Dim ite As XPathNodeIterator = nav.Select("dushana/venta[@fecha='" + selectedDate + "']")

        While ite.MoveNext
            Response.Write(ite.Current.Value)
        End While
    End Sub
End Class
