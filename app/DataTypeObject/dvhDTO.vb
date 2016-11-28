Public Class dvhDTO
    Private _name As String
    Private _dvh As Integer
    Private _newDvh As Integer

    Property name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Property dvh As Integer
        Get
            Return _dvh
        End Get
        Set(value As Integer)
            _dvh = value
        End Set
    End Property

    Property newDvh As Integer
        Get
            Return _newDvh
        End Get
        Set(value As Integer)
            _newDvh = value
        End Set
    End Property

End Class
