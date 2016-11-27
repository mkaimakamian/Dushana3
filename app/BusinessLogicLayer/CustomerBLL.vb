Imports DataAccessLayer
Imports DataTypeObject
Public Class CustomerBLL

    Public Function GetCustomers() As ResultDTO
        Dim customerDal As New CustomerDAL()
        Dim logBll As New LogBLL()
        Try
            Dim result As New ResultDTO(ResultDTO.type.OK, "Ok", customerDal.GetCustomers(), True)
            logBll.AddLogInfo("Get customers", "Listado de clientes", Me)
            Return result
        Catch ex As Exception
            Return New ResultDTO(ResultDTO.type.EXCEPTION, "Se ha producido un error crítico: " + ex.Message)
        End Try
    End Function

    Public Function GetCustomer(ByRef id As Integer) As ResultDTO
        Dim customerDal As New CustomerDAL()
        Dim logBll As New LogBLL()
        Dim customer As CustomerDTO

        customer = customerDal.GetCustomer(id)
        If IsNothing(customer) Then
            logBll.AddLogWarn("Get customer", "Búsqueda del cliente inexistente (id " + CStr(id) + ")", Me)
        Else
            logBll.AddLogInfo("Get customer", "Búsqueda del cliente " + customer.name + " " + customer.surname + " (id " + CStr(id) + ")", Me)
        End If

        Return New ResultDTO(ResultDTO.type.OK, "Ok", customer, True)
    End Function
End Class
