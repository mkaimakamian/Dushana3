Public Class CustomerDTO

    Private _id As Integer
    Private _name As String
    Private _surname As String
    Private _birth As String
    Private _gender As String

    Public Sub New(ByRef id As Integer, ByRef name As String, ByRef surname As String, ByRef birth As String, ByRef gender As String)
        _id = id
        _name = name
        _surname = surname
        _birth = birth
        _gender = gender
    End Sub


    Property id As Integer
        Set(value As Integer)
            _id = id
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

    Property surname As String
        Set(value As String)
            _surname = value
        End Set
        Get
            Return _surname
        End Get
    End Property

    Property birth As String
        Set(value As String)
            _birth = value
        End Set
        Get
            Return _birth
        End Get
    End Property

    Property gender As String
        Set(value As String)
            _gender = value
        End Set
        Get
            Return _gender
        End Get
    End Property

End Class
