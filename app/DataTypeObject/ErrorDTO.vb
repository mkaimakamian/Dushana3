Public Class ErrorDTO
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

    Public Sub New(ByRef type As type, descripton As String, keepGoing As Boolean)
        _type = type
        _description = descripton
        _keepGoing = keepGoing
    End Sub

    ' Informa si el error actual es OK
    Public Function IsValid() As Boolean
        Return IsCurrentError(type.OK)
    End Function

    ' Informa si el error actual coincide con el pasado por parámetro
    Public Function IsCurrentError(ByRef type As type) As Boolean
        Return _type = type
    End Function

End Class
