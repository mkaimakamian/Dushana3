Imports BusinessLogicLayer
Imports DataTypeObject

Partial Class ProductList
    Inherits System.Web.UI.Page

    Private Sub ProductList_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        If IsNothing(Session("user")) Then
            ' Si no hay usuario en sessión, redirige al login
            Response.Redirect("LogIn.aspx")
        Else
            Dim productBll As New ProductBLL()
            Dim result As ResultDTO
            result = productBll.GetProducts()
            ProductGridView.DataSource = result.value
            ProductGridView.DataBind()

            'ProductGridView.Columns(0).HeaderText = "Id"
            'ProductGridView.Columns(1).HeaderText = "Nombre"
            'ProductGridView.Columns(2).HeaderText = "Descripción"
            'ProductGridView.Columns(3).HeaderText = "Precion ($Ar)"
        End If
    End Sub
End Class
