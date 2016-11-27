Public Class ProductDTO

    Private _id As Integer
    Private _name As String
    Private _description As String
    Private _price As Integer

    Public Sub New(ByRef id As Integer, ByRef name As String, ByRef description As String, ByRef price As Double)
        _id = id
        _name = name
        _description = description
        _price = price
    End Sub

    Property id As Integer
        Set(value As Integer)
            _id = value
        End Set
        Get
            Return _id
        End Get
    End Property

    Property name As String
        Set(value As String)
            _name = value
        End Set
        Get
            Return _name
        End Get
    End Property

    Property description As String
        Set(value As String)
            _description = value
        End Set
        Get
            Return _description
        End Get
    End Property

    Property prices As Integer
        Set(value As Integer)
            _price = value
        End Set
        Get
            Return _price
        End Get
    End Property
End Class
