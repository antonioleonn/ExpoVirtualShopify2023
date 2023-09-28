Imports System.Text

Public Class cEncripta
    Public Function DecodeBase64ToString(valor As String) As String
        Dim myBase64ret As Byte() = Convert.FromBase64String(valor)
        Dim myStr As String = Encoding.UTF8.GetString(myBase64ret)
        Return myStr
    End Function
    Public Function EncodeStrToBase64(valor As String) As String
        Dim myByte As Byte() = Encoding.UTF8.GetBytes(valor)
        Dim myBase64 As String = Convert.ToBase64String(myByte)
        Return myBase64
    End Function

End Class
