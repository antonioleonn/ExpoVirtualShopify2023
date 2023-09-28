Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Public Class cServidoresSecundariosDatos
    'Declaramos las propiedades a utilizar
    Inherits cEncripta
    Implements iDatosHost

    Private _host As String
    Private _user As String
    Private _pass As String
    Private _sAlmacen As String

    Public Property host As String Implements iDatosHost.host
        Get
            Return _host
        End Get
        Set(value As String)
            _host = value
        End Set
    End Property

    Public Property user As String Implements iDatosHost.user
        Get
            Return _user
        End Get
        Set(value As String)
            _user = value
        End Set
    End Property

    Public Property pass As String Implements iDatosHost.pass
        Get
            Return _pass
        End Get
        Set(value As String)
            _pass = value
        End Set
    End Property

    Public Property sAlmacen As String Implements iDatosHost.sAlmacen
        Get
            Return _sAlmacen
        End Get
        Set(value As String)
            _sAlmacen = value
        End Set
    End Property

End Class

Public Class cServidoresSecundarios
    Inherits cServidoresSecundariosDatos

    Public path As String
    Public ListServidores As New List(Of cServidoresSecundariosDatos)()

    Public Sub New(tmpPath As String)
        Me.path = tmpPath
    End Sub

    Public Sub guardarCambios(movimiento As String, idSeleccion As Integer)
        If (movimiento = "ALTA") Then
            'Si el movimiento es alta, agregamos una nueva linea al archivo
            ListServidores.Add(New cServidoresSecundariosDatos() With {
                        .host = Me.host,
                        .user = Me.user,
                        .pass = Me.pass,
                        .sAlmacen = Me.sAlmacen})
        ElseIf (movimiento = "MODIFICACION") Then
            'Si el movimiento es Modicicacion, agregamos modificamos la linea que enviamos
            ListServidores(idSeleccion) = New cServidoresSecundariosDatos() With {
                        .host = Me.host,
                        .user = Me.user,
                        .pass = Me.pass,
                        .sAlmacen = Me.sAlmacen}
        ElseIf (movimiento = "BORRAR") Then
            'Si el movimiento es Modicicacion, quitamos la linea que indicamos
            ListServidores.RemoveAt(idSeleccion)
        End If

        'Declaramos las variables
        Dim path As String = IO.Directory.GetCurrentDirectory() & "\conn_s.conf"
        Dim guardarLineas As String = ""
        'Repetimos por cada linea en el servidor, y la partimos por un enter
        For Each item In ListServidores
            guardarLineas = guardarLineas +
                item.host + Convert.ToChar(Keys.Tab) +
                item.user + Convert.ToChar(Keys.Tab) +
                item.pass + Convert.ToChar(Keys.Tab) +
                item.sAlmacen + Convert.ToChar(Keys.Tab) +
                Convert.ToChar(Keys.Enter)
        Next
        Dim fs As FileStream = File.Create(path) 'Si el archivo no existe, lo creamos
        'guardamos la informacion en el achivo
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(guardarLineas)
        fs.Write(info, 0, info.Length)
        fs.Close() 'Cerramos el archivo 
    End Sub

    Public Function leerArchivo() As List(Of cServidoresSecundariosDatos)
        ListServidores.Clear() 'Limpiamos la lista
        'declaramos las variables
        Dim data1 As String = ""
        Dim tmpPath As String = Me.path & "\conn_s.conf"
        If My.Computer.FileSystem.FileExists(tmpPath) Then
            Dim leer As New StreamReader(tmpPath) 'leemos el archivo
            data1 = leer.ReadToEnd() 'Guardamos su contenido en una variable
            leer.Close() 'Cerramos el archivo
        End If
        'Si tiene informacion Leemos las lineas y las guardamos en la lista
        If data1.Length > 0 Then
            'Separamos el string en un array linea por linea
            Dim sLineas() As String = data1.Split(Convert.ToChar(Keys.Enter))
            For Each Linea As String In sLineas
                Dim arrayCelda() As String = Linea.Split(Convert.ToChar(Keys.Tab))
                If (Linea.Length > 0) Then
                    'Guardamos en la variable Servidores, los nombres de los servidores a utilizar
                    ListServidores.Add(New cServidoresSecundariosDatos() With {
                        .host = arrayCelda(0),
                        .user = arrayCelda(1),
                        .pass = arrayCelda(2),
                        .sAlmacen = arrayCelda(3)})
                End If
            Next
        End If
        ListServidores.Sort(Function(x, y) x.sAlmacen.CompareTo(y.sAlmacen))
        Return ListServidores
    End Function
End Class
