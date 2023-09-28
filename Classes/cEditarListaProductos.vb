
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.FileIO
Imports Newtonsoft.Json

Public Class datosEditaArticulo
    Inherits cEncripta
    Dim _idShopify As String
    Dim _idMerksyst As String
    Dim _Precio As String
    Dim _Empaque As String
    Dim _Etiqueta As String
    Dim _Observacion As String
    Dim _Errores As String
    Dim _Titulo As String
    Dim _Descripcion As String

    Property idShopify As String
        Get
            Return _idShopify
        End Get
        Set(value As String)
            _idShopify = value
        End Set
    End Property

    Property idMerksyst As String
        Get
            Return _idMerksyst
        End Get
        Set(value As String)
            _idMerksyst = value
        End Set
    End Property

    Property Titulo As String
        Get
            Return _Titulo
        End Get
        Set(value As String)
            _Titulo = value
        End Set
    End Property

    Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
        End Set
    End Property

    Property Precio As String
        Get
            Return _Precio
        End Get
        Set(value As String)
            _Precio = value
        End Set
    End Property

    Property Empaque As String
        Get
            Return _Empaque
        End Get
        Set(value As String)
            _Empaque = value
        End Set
    End Property

    Property Etiqueta As String
        Get
            Return _Etiqueta
        End Get
        Set(value As String)
            _Etiqueta = value
        End Set
    End Property

    Property Observacion As String
        Get
            Return _Observacion
        End Get
        Set(value As String)
            _Observacion = value
        End Set
    End Property

    Property Errores As String
        Get
            Return _Errores
        End Get
        Set(value As String)
            _Errores = value
        End Set
    End Property

End Class
Public Class cEditarListaProductos
    Inherits datosEditaArticulo

    Private tableFilter As New DataTable
    Private _host As String
    Private _user As String
    Private _pass As String
    Private tmpEmpaque As String
    Private tmpClase As String
    Public Sub New(host As String, user As String, pass As String)
        Me._host = DecodeBase64ToString(host)
        Me._user = DecodeBase64ToString(user)
        Me._pass = DecodeBase64ToString(pass)
    End Sub

    Public Function listarArticulos(archivoSeleccionado As String) As List(Of datosEditaArticulo)
        Dim fila As Integer = 0
        Dim listResult As List(Of datosEditaArticulo) = New List(Of datosEditaArticulo)()
        'abrimos el archivo seleccionado
        Using reader As New TextFieldParser(archivoSeleccionado)
            ' limpiamos los articulos
            tableFilter.Columns.Clear()
            tableFilter.Columns.Add("Articulo")
            tableFilter.Columns.Add("Empaque")
            BuscarArticulos()
            ' indicamos cual es el delimitador (coma).
            reader.TextFieldType = FieldType.Delimited
            reader.SetDelimiters(",")
            While Not reader.EndOfData
                Try
                    ' Obtenemos una matriz con los datos existentes en la línea actual.
                    Dim lineaActual As String() = reader.ReadFields()
                    Dim columna As Integer = lineaActual.Count()
                    ' si la fila es mayor que 0 entra, esto para asegurarnos que no inprima la cabecera del archivo excel / csv
                    If (fila > 0) Then
                        'agregamos a la tabla la informacion
                        Dim cIdMerksyst = lineaActual(0)
                        Dim cIdShopify = lineaActual(1)
                        Dim cTitulo = ""
                        Dim cDescripcion = ""
                        Dim cPrecio = ""
                        Dim cEmpaque = ""
                        Dim cEtiqueta = ""
                        Dim cObservacion = ""
                        If (columna > 2) Then
                            cTitulo = lineaActual(2)
                        End If
                        If (columna > 3) Then
                            cDescripcion = lineaActual(3)
                        End If
                        If (columna > 4) Then
                            cPrecio = lineaActual(4)
                        End If
                        If (columna > 5) Then
                            cEmpaque = lineaActual(5)
                            cObservacion = revisaEmpaqueMerksyst(lineaActual(0), lineaActual(5))
                        End If
                        If (columna > 6) Then
                            cEtiqueta = lineaActual(6)
                        End If

                        'DataGridView1.Rows.Add(Nothing, , lineaActual(1), "")
                        listResult.Add(New datosEditaArticulo With {
                            .idMerksyst = cIdMerksyst,
                            .idShopify = cIdShopify,
                            .Titulo = cTitulo,
                            .Descripcion = cDescripcion,
                            .Precio = cPrecio,
                            .Empaque = cEmpaque,
                            .Etiqueta = cEtiqueta,
                            .Observacion = cObservacion,
                            .Errores = ""
                                       })
                    End If
                    fila = fila + 1
                Catch ex As MalformedLineException
                    'Si existe un error muestra la columna
                    'MessageBox.Show("La línea actual " & ex.Message & " no es válida.")
                End Try
            End While

        End Using
        Return listResult
    End Function

    Private Sub BuscarArticulos()
        'Variables de conexion para sql
        Dim myConn As SqlConnection
        Dim myCmd As SqlCommand
        Dim myReader As SqlDataReader
        'creamos la coneccion con la BD principal
        myConn = New SqlConnection("Initial Catalog=TCADBMAS; Data Source=" & Me._host & "; User ID=" & Me._user & "; Password=" & Me._pass & ";")
        myCmd = myConn.CreateCommand
        myCmd.CommandText = "Select * from (select art, uds_min as uds from inviar union select art, uds from codbar ) as Codigo order by uds"

        'abrimos la coneccion
        myConn.Open()
        myReader = myCmd.ExecuteReader() 'Ejecuta la consulta
        Do While myReader.Read()
            tableFilter.Rows.Add(myReader.GetString(0).ToString.Trim, myReader.GetString(1).ToString.Trim)
        Loop
        'cerramos la conexion
        myConn.Close()
    End Sub

    Private Function revisaEmpaqueMerksyst(articulo As String, empaque As String) As String
        Dim result As String = ""
        Dim fila As DataRow() = tableFilter.Select("Articulo='" + articulo + "' and Empaque = '" + empaque + "'")
        If (fila.Count() <= 0) Then
            fila = tableFilter.Select("Articulo='" + articulo + "'")
            For Each dato In fila
                result = result + dato.ItemArray(1) + ","
            Next
            result = "No existe ese empaque solo: " + result
        End If

        Return result
    End Function

    Public Function enviaShopify(data As DataGridViewRow, lstEstatus As Dictionary(Of String, String)) As Dictionary(Of String, String)
        Dim arrayError As Dictionary(Of String, String) = New Dictionary(Of String, String)
        Dim idShopify = data.Cells("IdShopify").Value

        Dim UrlUpdate As String = "https://" + tienda + ".myshopify.com/admin/api/2022-04/products/" + idShopify + ".json"
        If (Not (IsNothing(idShopify))) Then
            Dim guardaEmpaque As Boolean = lstEstatus("guardaEmpaque")
            'declaramos las variables necesarias para array
            Dim arrayData = New Dictionary(Of String, Object)
            Dim arrayProduct = New Dictionary(Of String, Object)
            Dim arrayVariantes = New Dictionary(Of String, Object)
            Dim arrayOptiones1 = New Dictionary(Of String, Object)
            Dim arrayOption = New List(Of Object)
            Dim arrayOptiones1Val(1) As String
            Dim arrayVariant = New List(Of Object)

            arrayProduct.Add("id", idShopify)
            If (lstEstatus("Estatus") = "Activo") Then
                arrayProduct.Add("status", "active")
            ElseIf (lstEstatus("Estatus") = "Borrador") Then
                arrayProduct.Add("status", "draft")
            End If

            If (lstEstatus("guardaPrecio") = True Or guardaEmpaque = True) Then
                revisaEmpaques(idShopify)
            End If

            If (lstEstatus("guardaTitulo") = True) Then
                arrayProduct.Add("title", data.Cells("Titulo").Value)
            End If

            If (lstEstatus("guardaDescripcion") = True) Then
                arrayProduct.Add("body_html", data.Cells("Descripcion").Value)
            End If

            'Revisamos el precio
            If (lstEstatus("guardaPrecio") = True) Then
                arrayVariantes.Add("price", data.Cells("Precio").Value)
                If (guardaEmpaque = True) Then
                    If (data.Cells("Observacion").Value = "") Then
                        tmpEmpaque = data.Cells("Empaque").Value
                    End If
                End If
                arrayVariantes.Add("option1", tmpEmpaque)
                If (tmpClase <> "") Then
                    arrayVariantes.Add("option2", tmpClase)
                End If
                arrayVariantes.Add("inventory_policy", "deny")
                arrayVariantes.Add("compare_at_price", "")
                arrayVariantes.Add("fulfillment_service", "manual")
                arrayVariantes.Add("inventory_management", "")
                arrayVariantes.Add("taxable", "false")
                arrayVariantes.Add("sku", data.Cells("idMerksyst").Value)
                arrayVariant.Add(arrayVariantes)
                arrayProduct.Add("variants", arrayVariant)
            End If

            'Agregamos el empaque al articulo 
            If (guardaEmpaque = True) Then
                If (data.Cells("Observacion").Value = "") Then
                    arrayOptiones1.Add("name", "Empaque")
                    arrayOptiones1.Add("position", "1")
                    arrayOptiones1Val(0) = data.Cells("Empaque").Value
                    arrayOptiones1.Add("values", arrayOptiones1Val)
                    arrayOption.Add(arrayOptiones1)
                    arrayProduct.Add("options", arrayOption)
                End If
            End If

            If (lstEstatus("guardaEtiqueta") = True) Then
                Dim arrayTags() As String = RTrim(LTrim(data.Cells("Etiqueta").Value.ToString)).Split("|")
                arrayProduct.Add("tags", arrayTags)
            End If
            arrayData.Add("product", arrayProduct)
            Dim tmpError = guardaShopify(UrlUpdate, arrayData)
            If (tmpError <> "") Then
                arrayError.Add(data.Cells("idMerksyst").Value, tmpError)
            Else
                arrayError.Add("", "")
            End If
        End If
        Return arrayError
    End Function

    Private Function guardaShopify(UrlUpdate As String, arrayData As Dictionary(Of String, Object))
        Dim respuesta As String = ""
        'Variables de conexion propias de VB.net
        Dim myReq As WebRequest
        Dim myResp As HttpWebResponse
        Try
            'Variables que llevan las credenciales de Shopify
            Dim appKey As String = VariablesGlobales.APIKey & ":" & VariablesGlobales.Password
            Dim str As String = JsonConvert.SerializeObject(arrayData)
            Dim data As Byte() = Encoding.UTF8.GetBytes(str)
            Dim byteKey As Byte() = Encoding.UTF8.GetBytes(appKey)
            Dim SimpleCredential As NetworkCredential = New NetworkCredential(VariablesGlobales.APIKey, VariablesGlobales.Password)
            appKey = Convert.ToBase64String(byteKey)
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            'Asignamos a la variable la la ruta, las credenciales y el tipo
            myReq = WebRequest.Create(UrlUpdate)
            myReq.Credentials = SimpleCredential
            myReq.Headers.Add("Authorization", "Basic " & appKey)
            myReq.ContentType = "application/json"

            'Indicamos que el metodo es PUT
            myReq.Method = "PUT"
            myReq.ContentLength = data.Length

            'Encriptamos los datos que estamos enviando
            Dim stream As Stream = myReq.GetRequestStream()
            stream.Write(data, 0, data.Length)
            stream.Close()

            'Recibimos la respuesta de la pagina de shopify
            myResp = myReq.GetResponse()
            Dim myreader As New StreamReader(myResp.GetResponseStream())

            ' si tiene informacion entra
            If myResp.StatusCode >= 200 And myResp.StatusCode <= 210 Then
                'actualizamos la tabla princial
            Else
                respuesta = "Ocurrio un error al actualizar los datos"
            End If
            myResp.Close()
        Catch ex As WebException
            Dim tmpError As String = ""
            If Not ex.Response Is Nothing Then
                Dim data As StreamReader = New StreamReader(ex.Response.GetResponseStream)
                tmpError = data.ReadToEnd
            Else
                tmpError = ex.Message
            End If
            'Dim data As StreamReader = New StreamReader(ex.Response.GetResponseStream)
            respuesta = "Error " & tmpError
        End Try
        Return respuesta
    End Function

    Private Sub revisaEmpaques(idBusca As String)
        tmpEmpaque = ""
        tmpClase = ""
        Dim URL As String = "https://" + tienda + ".myshopify.com/admin/api/2021-10/products/" + idBusca + ".json?fields=id,variants"
        'URL = URL & "?limit=150&ids=7249915412675,6753624359107"

        'Variables de conexion propias de VB.net
        Dim myReq As WebRequest
        Dim myResp As HttpWebResponse

        'Variables que llevan las credenciales de Shopify
        Dim appKey As String = VariablesGlobales.APIKey & ":" & VariablesGlobales.Password
        Dim byteKey As Byte() = Encoding.UTF8.GetBytes(appKey)
        Dim SimpleCredential As NetworkCredential = New NetworkCredential(VariablesGlobales.APIKey, VariablesGlobales.Password)
        appKey = Convert.ToBase64String(byteKey)
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        'Asignamos a la variable la la ruta, las credenciales y el tipo
        myReq = WebRequest.Create(URL)
        myReq.Credentials = SimpleCredential
        myReq.Headers.Add("Authorization", "Basic " & appKey)
        myReq.ContentType = "application/json"

        'Indicamos que el metodo sera de tipo GET
        myReq.Method = "GET"

        'Recibimos la respuesta de la pagina de shopify
        myResp = myReq.GetResponse()
        Dim myreader As New StreamReader(myResp.GetResponseStream())
        ' si tiene informacion entra
        If myResp.StatusCode >= 200 And myResp.StatusCode <= 210 Then
            Dim jsonShopify As String = myreader.ReadToEnd()
            Dim objJson As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(jsonShopify)

            Dim arrayShopify = objJson("product")
            Dim arrayData As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(arrayShopify.ToString)

                'extraemos la informacion que viene de la pagina 
                Dim variants = arrayData("variants")
            For Each arrayVariants As Object In variants
                tmpEmpaque = arrayVariants("option1").ToString
                If (tmpEmpaque = "Default Title") Then
                    tmpEmpaque = ""
                End If
                tmpClase = arrayVariants("option2").ToString()
            Next
        End If
        myResp.Close()
    End Sub

End Class
