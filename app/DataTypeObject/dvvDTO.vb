Public Class dvvDTO
    'Modelado del DVV

    Private _entity As String
    Private _dvv As String

    Property entity As String
        Get
            Return _entity
        End Get
        Set(value As String)
            _entity = value
        End Set
    End Property

    Property dvv As String
        Get
            Return _dvv
        End Get
        Set(value As String)
            _dvv = value
        End Set
    End Property
End Class
