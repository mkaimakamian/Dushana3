Public Class UserDTO
    ' Modelado del usuario

    ' No se incluye el password para evitar que siempre se transporte y se exponga.
    Private _name As String
    Private _locked As Boolean
    Private _retries As Integer
    Private _verified As Boolean
    Private _type As String

    Property name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Property locked As Boolean
        Get
            Return _locked
        End Get
        Set(value As Boolean)
            _locked = value
        End Set
    End Property

    Property retries As Integer
        Get
            Return _retries
        End Get
        Set(value As Integer)
            _retries = value
        End Set
    End Property

    Property verified As Boolean
        Get
            Return _verified
        End Get
        Set(value As Boolean)
            _verified = value
        End Set
    End Property

    Property type As String
        Get
            Return _type
        End Get
        Set(value As String)
            _type = value
        End Set
    End Property
End Class
