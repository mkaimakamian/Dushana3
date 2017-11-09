Public Class BillingDTO
    ' Modelado del objecto facturacion
    Private _products As List(Of ProductDTO)
    Private _listTotal As Integer
    Private _discount As String
    Private _finalPrice As Integer

    Property products As List(Of ProductDTO)
        Get
            Return _products
        End Get
        Set(value As List(Of ProductDTO))
            _products = value
        End Set
    End Property

    Property listTotal As Integer
        Get
            Return _listTotal
        End Get
        Set(value As Integer)
            _listTotal = value
        End Set
    End Property

    Property finalPrice As Integer
        Get
            Return _finalPrice
        End Get
        Set(value As Integer)
            _finalPrice = value
        End Set
    End Property

    Property discount As String
        Get
            Return _discount
        End Get
        Set(value As String)
            _discount = value
        End Set
    End Property
End Class
