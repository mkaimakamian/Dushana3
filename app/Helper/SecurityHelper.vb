Imports System.Security.Cryptography
Imports System.Text
Public Class SecurityHelper
    'Se encarga de aplicar la encriptación md5
    Public Function Encrypt(ByRef value As String) As String
        Dim Bytes() As Byte
        Dim sb As New StringBuilder()

        If String.IsNullOrEmpty(value) Then
            Throw New ArgumentNullException
        End If

        Bytes = Encoding.Default.GetBytes(value)
        Bytes = MD5.Create().ComputeHash(Bytes)

        For x As Integer = 0 To Bytes.Length - 1
            sb.Append(Bytes(x).ToString("x2"))
        Next

        Return sb.ToString()
    End Function
End Class