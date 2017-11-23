Imports BusinessLogicLayer
Imports DataTypeObject
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
        End If
        'PENDING: Aca hay que hacer la llamada al TextWriter
    End Sub


End Class
