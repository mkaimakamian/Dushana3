Imports DataTypeObject
Public Class CustomerDAL

    Public Function GetCustomers()
        Return ListOfCustomers()
    End Function

    Public Function GetCustomer(ByRef id As Integer) As CustomerDTO
        Dim result As List(Of CustomerDTO)
        result = ListOfCustomers()

        For Each customer As CustomerDTO In result
            If customer.id = id Then
                Return customer
            End If
        Next

        Return Nothing
    End Function

    Private Function ListOfCustomers() As List(Of CustomerDTO)
        Dim result As New List(Of CustomerDTO)
        result.Add(New CustomerDTO(1, "Alberto", "Gonzales", New Date(1981, 11, 17), "M"))
        result.Add(New CustomerDTO(2, "Agustín", "Correa", New Date(1983, 12, 1), "M"))
        result.Add(New CustomerDTO(3, "Juana", "Molina", New Date(1984, 9, 4), "F"))
        result.Add(New CustomerDTO(4, "Laura", "Martínez", New Date(1986, 7, 30), "F"))
        result.Add(New CustomerDTO(5, "Bárbara", "Monte", New Date(1990, 6, 28), "F"))
        result.Add(New CustomerDTO(6, "Claudia", "Terremoto", New Date(1995, 5, 9), "F"))
        Return result
    End Function
End Class
