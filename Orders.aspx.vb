Imports BusinessLogicLayer
Imports DataTypeObject
Partial Class Orders
    Inherits System.Web.UI.Page

    Private Sub Orders_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim productBll As New ProductBLL()
        Dim productList As New List(Of ProductDTO)
        Dim result As ResultDTO
        result = productBll.GetProducts()

        For Each Product As ProductDTO In result.value
            productList.Add(Product)
        Next

        ListBox1.DataTextField = "name"
        ListBox1.DataSource = productList
        ListBox1.DataBind()
    End Sub


    'TODO: No me toma el selected Item
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListBox2.DataTextField = "name"
        ListBox2.Items.Add(ListBox1.SelectedItem)
    End Sub


    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Billing As New BillingDTO
        Dim MiWebService As New WebService

        For Each Product As ProductDTO In ListBox2.Items
            Billing.products.Add(Product)
        Next

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
