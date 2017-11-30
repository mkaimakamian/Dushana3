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

        Dim fecha As XmlAttribute = doc.CreateAttribute("fecha")
        fecha.Value = Date.Now.ToString("dd/MM/yyyy")
        VentaNode.Attributes.Append(fecha)

        Dim cliente As XmlElement = doc.CreateElement("cliente")
        Dim clienteNombre As XmlAttribute = doc.CreateAttribute("nombre")
        clienteNombre.Value = Session("User").name
        cliente.Attributes.Append(clienteNombre)


        Dim ServiciosNode As XmlNode = doc.CreateNode(XmlNodeType.Element, "Servicios", "")
        For Each P As ProductDTO In Billing.products
            Dim ProductoNode As XmlNode = doc.CreateNode(XmlNodeType.Element, "Producto", "")

            Dim id As XmlElement = doc.CreateElement("id")
            Dim idTexto As XmlText = doc.CreateTextNode(P.id)
            id.AppendChild(idTexto)

            Dim nombre As XmlElement = doc.CreateElement("nombre")
            Dim nombreTexto As XmlText = doc.CreateTextNode(P.name)
            nombre.AppendChild(nombreTexto)

            Dim descripcion As XmlElement = doc.CreateElement("descripcion")
            Dim descripcionTexto As XmlText = doc.CreateTextNode(P.description)
            descripcion.AppendChild(descripcionTexto)

            Dim precio As XmlElement = doc.CreateElement("precio")
            Dim precioTexto As XmlText = doc.CreateTextNode(P.prices)
            precio.AppendChild(precioTexto)

            ProductoNode.AppendChild(id)
            ProductoNode.AppendChild(nombre)
            ProductoNode.AppendChild(descripcion)
            ProductoNode.AppendChild(precio)

            ServiciosNode.AppendChild(ProductoNode)
        Next
        Dim FacturacionNode As XmlNode = doc.CreateNode(XmlNodeType.Element, "Facturacion", "")

        Dim totalLista As XmlElement = doc.CreateElement("totalLista")
        Dim totalListaTexto As XmlText = doc.CreateTextNode(Billing.listTotal)
        totalLista.AppendChild(totalListaTexto)

        Dim Bonificacion As XmlElement = doc.CreateElement("bonificacion")
        Dim BonificacionTexto As XmlText = doc.CreateTextNode(Billing.discount)
        Bonificacion.AppendChild(BonificacionTexto)

        Dim totalFinal As XmlElement = doc.CreateElement("totalFinal")
        Dim totalFinalTexto As XmlText = doc.CreateTextNode(Billing.finalPrice)
        totalFinal.AppendChild(totalFinalTexto)

        FacturacionNode.AppendChild(totalLista)
        FacturacionNode.AppendChild(Bonificacion)
        FacturacionNode.AppendChild(totalFinal)

        cliente.AppendChild(ServiciosNode)
        cliente.AppendChild(FacturacionNode)
        VentaNode.AppendChild(cliente)

        doc.Item("dushana").AppendChild(VentaNode)
        Reader.Close()
        doc.Save(Server.MapPath("ventas.xml"))
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
