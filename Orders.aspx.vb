Imports BusinessLogicLayer
Imports DataTypeObject
Imports System.Xml

Partial Class Orders
    Inherits System.Web.UI.Page
    Dim productList As New List(Of ProductDTO)
    Dim Carrito As New List(Of ProductDTO)

    Public Sub getProductList()
        Dim productBll As New ProductBLL()

        Dim result As ResultDTO
        result = productBll.GetProducts()

        For Each Product As ProductDTO In result.value
            productList.Add(Product)
        Next
    End Sub

    Private Sub Orders_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            getProductList()

            ListBox1.DataTextField = "name"
            ListBox1.DataSource = productList
            ListBox1.DataBind()
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        getProductList()

        For Each producto As ProductDTO In productList
            If producto.name = ListBox1.SelectedItem.Value Then
                Carrito.Add(producto)
                ListBox2.Items.Add(producto.name)
            End If
        Next

        ListBox2.DataTextField = "name"
    End Sub

    Sub AppendXML(Billing As BillingDTO)
        Dim Reader As New XmlTextReader(Server.MapPath("ventas.xml"))
        Dim doc As New XmlDocument

        doc.Load(Reader)

        Dim VentaNode As XmlNode = doc.CreateNode(XmlNodeType.Element, "Venta", "")

        Dim fecha As XmlElement = doc.CreateElement("fecha")
        Dim fechaTexto As XmlText = doc.CreateTextNode(Date.Now)
        fecha.AppendChild(fechaTexto)

        Dim cliente As XmlElement = doc.CreateElement("clienteNombre")
        Dim clienteTexto As XmlText = doc.CreateTextNode(Session("User"))
        fecha.AppendChild(fechaTexto)

        Dim ServiciosNode As XmlNode = doc.CreateNode(XmlNodeType.Element, "Servicios", "")
        For Each P As ProductDTO In Billing.products
            Dim ProductoNode As XmlNode = doc.CreateNode(XmlNodeType.Element, "Producto", "")

            Dim id As XmlElement = doc.CreateElement("id")
            Dim idTexto As XmlText = doc.CreateTextNode(P.id)
            fecha.AppendChild(idTexto)


            Dim nombre As XmlElement = doc.CreateElement("nombre")
            Dim nombreTexto As XmlText = doc.CreateTextNode(P.name)
            fecha.AppendChild(nombreTexto)


            Dim descripcion As XmlElement = doc.CreateElement("descripcion")
            Dim descripcionTexto As XmlText = doc.CreateTextNode(P.description)
            fecha.AppendChild(descripcionTexto)


            Dim precio As XmlElement = doc.CreateElement("precio")
            Dim precioTexto As XmlText = doc.CreateTextNode(P.prices)
            fecha.AppendChild(precioTexto)

            doc.Item("ventas.xml").AppendChild(ProductoNode)

        Next
        doc.Item("ventas.xml").AppendChild(ServiciosNode)

        Dim FacturacionNode As XmlNode = doc.CreateNode(XmlNodeType.Element, "Facturacion", "")

        Dim totalLista As XmlElement = doc.CreateElement("totaLista")
        Dim totalListaTexto As XmlText = doc.CreateTextNode(Billing.listTotal)
        fecha.AppendChild(totalListaTexto)

        Dim Bonificacion As XmlElement = doc.CreateElement("bonificacion")
        Dim BonificacionTexto As XmlText = doc.CreateTextNode(Billing.discount)
        fecha.AppendChild(BonificacionTexto)

        Dim totalFinal As XmlElement = doc.CreateElement("totaFinal")
        Dim totalFinalTexto As XmlText = doc.CreateTextNode(Billing.finalPrice)
        fecha.AppendChild(totalFinalTexto)

        doc.Item("ventas.xml").AppendChild(FacturacionNode)

        doc.Item("ventas.xml").AppendChild(VentaNode)

    End Sub


    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Billing As New BillingDTO
        Dim MiWebService As New WebService

        getProductList()
        Billing.products = productList

        For Each Product As ProductDTO In Billing.products
            Billing.listTotal = Billing.listTotal + Product.prices
        Next

        Billing.finalPrice = MiWebService.CalculateDiscount(Billing.listTotal)

        If Billing.listTotal > 500 Then
            Billing.discount = "10%"
        Else
            Billing.discount = "0%"
        End If

        AppendXML(Billing)

    End Sub


End Class
