Public Class LogInDTO
    ' Modelado del log in
    Private _user As String
    Private _password As String

    Property user As String
        Get
            Return _user
        End Get
        Set(value As String)
            _user = value
        End Set
    End Property

    Property password As String
        Get
            Return _password
        End Get
        Set(value As String)
            _password = value
        End Set
    End Property
End Class