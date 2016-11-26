Public Class ResultDTO
    Enum type
        OK
        LOCKED
        INVALIDA_CREDENTIAL
        CHECKSUM_ERROR
        MAX_ATTEMPTS
        INCOMPLETE_FIELDS
    End Enum

    Private _type As type
    Private _description As String
    Private _keepGoing As Boolean
    Private _value As Object

    Public Sub New(ByRef type As type, descripton As String, keepGoing As Boolean)
        _type = type
        _description = descripton
        _keepGoing = keepGoing
    End Sub

    Public Sub New(ByRef type As type, descripton As String, keepGoing As Boolean, value As Object)
        _type = type
        _description = descripton
        _keepGoing = keepGoing
        _value = value
    End Sub

    ' Descripción del error
    ReadOnly Property description As String
        Get
            Return _description
        End Get
    End Property

    ' Indica si el error es suficientemente crítico como para que no se continue el flujo normal
    ReadOnly Property keepGoing As Boolean
        Get
            Return _keepGoing
        End Get
    End Property

    ' Almacena un objeto que puede ser el resultado de una operación exitosa o fallida, y sobre el que se requiere realizar una operación.
    Property value As Object
        Set(value As Object)
            _value = value
        End Set
        Get
            Return _value
        End Get
    End Property

    ' Informa si el error actual es OK
    Public Function IsValid() As Boolean
        Return IsCurrentError(type.OK)
    End Function

    ' Informa si el error actual coincide con el pasado por parámetro
    Public Function IsCurrentError(ByRef type As type) As Boolean
        Return _type = type
    End Function

End Class
