Imports DataTypeObject
Public Class ProductDAL

    Public Function GetProducts() As List(Of ProductDTO)
        Return ListOfProducts()
    End Function

    Public Function GetProduct(ByRef id As Integer) As ProductDTO
        Dim result As List(Of ProductDTO)
        result = ListOfProducts()

        For Each customer As ProductDTO In result
            If customer.id = id Then
                Return customer
            End If
        Next

        Return Nothing
    End Function

    Private Function ListOfProducts() As List(Of ProductDTO)
        Dim result As New List(Of ProductDTO)
        result.Add(New ProductDTO(1, "Peeling", "El peeling consigue una disminución de las arrugas, una piel rejuvenecida y bien hidratada, con una secreción correcta de grasa y una buena consistencia y luminosidad.", 300))
        result.Add(New ProductDTO(2, "Drenaje linfático", "El drenaje linfático manual es una técnica de masoterapia terapéutica.", 250))
        result.Add(New ProductDTO(3, "Masajes descontracturantes", "Masajes.", 400))
        result.Add(New ProductDTO(4, "Depilación definitiva", "Depilación definitiva.", 275))
        result.Add(New ProductDTO(5, "Cavitación", "Tratamiento médico de estética que consiste en aplicar ultrasonidos en determinadas zonas del cuerpo para eliminar la grasa en ellas localizadas.", 425))
        Return result
    End Function
End Class
