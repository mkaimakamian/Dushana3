Public Class UserDTO
    ' Modelado del log in
    Private _user As String
    Private _locked As Boolean
    Private _retries As Integer

    Property user As String
        Get
            Return _user
        End Get
        Set(value As String)
            _user = value
        End Set
    End Property

    Property locked As String
        Get
            Return _locked
        End Get
        Set(value As String)
            _locked = value
        End Set
    End Property

    Property retries As String
        Get
            Return _retries
        End Get
        Set(value As String)
            _retries = value
        End Set
    End Property
End Class
