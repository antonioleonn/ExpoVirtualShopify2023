'Importamos las librerias de lectura de archivos
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Public Class cServidorPrincipalDatos
    'Declaramos las propiedades a utilizar
    Inherits cEncripta

    Private _host As String
    Private _user As String
    Private _pass As String

    Public Property host As String
        Get
            Return _host
        End Get
        Set(value As String)
            _host = value
        End Set
    End Property

    Public Property user As String
        Get
            Return _user
        End Get
        Set(value As String)
            _user = value
        End Set
    End Property

    Public Property pass As String
        Get
            Return _pass
        End Get
        Set(value As String)
            _pass = value
        End Set
    End Property
End Class
Public Class cServidorPrincipal
    Inherits cServidorPrincipalDatos
    Public path As String

    Public Sub New(tmpPath As String)
        Me.path = tmpPath
    End Sub

    Public Function revisarConeccion(nomFile As String) As Boolean
        Dim result = True
        Dim tmpPath = Me.path & "\" & nomFile
        If Not File.Exists(tmpPath) Then
            Dim fs As FileStream = File.Create(tmpPath)
            fs.Close()
        End If
        Dim leer As New StreamReader(tmpPath)
        Dim data1 As String = leer.ReadToEnd()
        leer.Close()
        If data1 = "" Then
            result = False
        Else
            Dim testArray() As String = Split(data1, Convert.ToChar(Keys.Tab))
            Me.host = testArray(0)
            Me.user = testArray(1)
            Me.pass = testArray(2)
        End If
        Return result
    End Function

    Public Sub guardaConeccion(nomFile As String, tmpHost As String, tmpUser As String, tmpPass As String)
        Dim data1 As String = ""
        Dim tmpPath = Me.path & "\" & nomFile
        'Si el archivo existe, entramos
        If My.Computer.FileSystem.FileExists(tmpPath) Then
            Dim leer As New StreamReader(tmpPath) 'leemos el archivo
            data1 = leer.ReadToEnd() 'Guardamos su contenido en una variable
            leer.Close() 'Cerramos el archivo
            If (data1.Length > 0) Then
                'Si la variable tiene uno o mas caracteres, agregamos un enter 
                data1 = data1 + Convert.ToChar(Keys.Enter)
            End If
        End If
        Dim fs As FileStream = File.Create(tmpPath) 'Si el archivo no existe, lo creamos
        'Concatemanos todo en una sola linea, los datos los codificamos, e insertamos un tabulador como separador
        Dim cadena = data1 +
            EncodeStrToBase64(tmpHost) + Convert.ToChar(Keys.Tab) +
            EncodeStrToBase64(tmpUser) + Convert.ToChar(Keys.Tab) +
            EncodeStrToBase64(tmpPass) + Convert.ToChar(Keys.Tab)
        ' Agregamos la informacion al archivo de texto
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(cadena)
        fs.Write(info, 0, info.Length)
        fs.Close() 'Cerramos el archivo
    End Sub

End Class
