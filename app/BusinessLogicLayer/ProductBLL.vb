Imports DataAccessLayer
Imports DataTypeObject
Public Class ProductBLL

    Public Function GetProducts() As ResultDTO
        Dim productDal As New ProductDAL()
        Dim logBll As New LogBLL()

        Try
            Dim result As New ResultDTO(ResultDTO.type.OK, "Ok", productDal.GetProducts(), True)
            logBll.AddLogInfo("Get products", "Listado de productos", Me)
            Return result
        Catch ex As Exception
            Return New ResultDTO(ResultDTO.type.EXCEPTION, "Se ha producido un error crítico: " + ex.Message)
        End Try

    End Function

    Public Function GetProduct(ByRef id As Integer) As ResultDTO
        Dim productDal As New ProductDAL()
        Dim logBll As New LogBLL()
        Dim product As ProductDTO

        product = productDal.GetProduct(id)
        If IsNothing(product) Then
            logBll.AddLogWarn("Get product", "Búsqueda del producto inexistente (id " + CStr(id) + ")", Me)
        Else
            logBll.AddLogInfo("Get product", "Búsqueda del producto " + product.name + " (id " + CStr(id) + ")", Me)
        End If

        Return New ResultDTO(ResultDTO.type.OK, "Ok", product, True)
    End Function
End Class
