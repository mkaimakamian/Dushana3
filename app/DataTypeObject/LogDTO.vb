Public Class LogDTO
    ' Modela el registro de log

    Enum level
        DEBUG = 1
        WARNING = 2
        CRITICAL = 3
        INFO = 4
    End Enum

    Private _id As Integer
    Private _logLevel As Integer
    Private _action As String
    Private _description As String
    Private _entity As String
    Private _created As String

    Public Sub New()
    End Sub

    Public Sub New(ByRef loglevel As String, ByRef action As String, ByRef description As String, ByRef entity As String)
        _logLevel = loglevel
        _action = action
        _description = description
        _entity = entity
        ' La fecha es agregada por la base de datos para evitar problemas de incompatibilidad
    End Sub


    Property id As Integer
        Set(value As Integer)
            _id = value
        End Set
        Get
            Return _id
        End Get
    End Property

    Property logLevel As Integer
        Set(value As Integer)
            _logLevel = value
        End Set
        Get
            Return _logLevel
        End Get
    End Property

    Property action As String
        Set(value As String)
            _action = value
        End Set
        Get
            Return _action
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

    Property entity As String
        Set(value As String)
            _entity = value
        End Set
        Get
            Return _entity
        End Get
    End Property

    Property created As String
        Set(value As String)
            _created = value
        End Set
        Get
            Return _created
        End Get
    End Property
End Class
