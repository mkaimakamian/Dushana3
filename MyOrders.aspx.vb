Imports System.Xml

Partial Class MyOrders
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim miDoc As New XmlDocument()
            Dim miLector As New XmlTextReader(Server.MapPath("ventas.xml"))
            miLector.WhitespaceHandling = WhitespaceHandling.None
            miDoc.Load(miLector)
            Session.Add("Ventas", miDoc)

            Dim n As Integer
            For n = 0 To miDoc.DocumentElement.ChildNodes.Count - 1
                dropFechas.Items.Add(miDoc.DocumentElement.ChildNodes(n).Attributes(0).Value)

                'Filtrar por usuario: Session("user").name
                'dropFechas.Items.Add(miDoc.DocumentElement.ChildNodes(n).ChildNodes(1).InnerText)
            Next
            miLector.Close()

            PrintSells(0)
        End If


        'Dim lector As New XmlTextReader(Server.MapPath("ventas.xml"))
        'Dim n As Integer

        'While lector.Read()
        '    Response.Write(lector.NodeType.ToString() + ": " + lector.Name + ":" + lector.Value + "<br/>")
        '    If lector.HasAttributes Then
        '        For n = 0 To lector.AttributeCount - 1
        '            lector.MoveToAttribute(n)
        '            Response.Write("<b>" + lector.NodeType.ToString() + ": " + lector.Name + ":" + lector.Value + "<br/><br/>")
        '        Next
        '        lector.MoveToElement()
        '    End If
        'End While
        'lector.Close()
    End Sub

    Protected Sub dropFechas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dropFechas.SelectedIndexChanged
        PrintSells(dropFechas.SelectedIndex)
    End Sub

    Private Sub PrintSells(ByRef index As Integer)
        Dim miDoc As New XmlDocument
        miDoc = Session("Ventas")
        Response.Write(miDoc.DocumentElement.ChildNodes(index).InnerXml)
    End Sub


End Class
