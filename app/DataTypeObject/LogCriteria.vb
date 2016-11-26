Public Class LogCriteria

    Enum level
        INFO
        WARNING
        CRITICAL
    End Enum

    Private _since As String
    Private _until As String
    Private _type As level

    Public Sub New(ByRef since As String, ByRef until As String, level As level)
        _since = since
        _until = until
        _type = level
    End Sub
End Class
