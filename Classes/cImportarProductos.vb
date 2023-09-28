'Importamos las librerias  
Imports Microsoft.VisualBasic.FileIO
Imports System.IO
Imports System.Text
Imports System.Net
Imports Newtonsoft.Json
'Imports System.Web.Script.Serialization
Imports System.Data.SqlClient
Imports System.Drawing

Public Class cImportarProductos
    Inherits cEncripta

    Private _host As String
    Private _user As String
    Private _pass As String
    Private tableDatos As DataTable = New DataTable("tableDatos")
    Private tableError As DataTable = New DataTable("tableError")

    Public Sub New(host As String, user As String, pass As String)
        Me._host = DecodeBase64ToString(host)
        Me._user = DecodeBase64ToString(user)
        Me._pass = DecodeBase64ToString(pass)
        'Indicamos que usaremos una columna de tipo imagen

        Dim imageColumn As New DataColumn
        imageColumn.ColumnName = "Icon"
        imageColumn.DataType = GetType(Bitmap)

        'Agregamos las cabeceras de la tabla
        tableDatos.Columns.Add(imageColumn)
        tableDatos.Columns.Add("Producto")
        tableDatos.Columns.Add("Descripcion")
        tableDatos.Columns.Add("Marca")
        tableDatos.Columns.Add("Categoria")
        tableDatos.Columns.Add("Estatus")
        tableDatos.Columns.Add("CodigoBarras")
        tableDatos.Columns.Add("Sku")
        tableDatos.Columns.Add("Precio")
        tableDatos.Columns.Add("Unidad")
        tableDatos.Columns.Add("Bebida")
        tableDatos.Columns.Add("Tag")

        tableError.Columns.Add("Id")
        tableError.Columns.Add("Error")
    End Sub

    Public Function cargarArchivo(archivoSeleccionado As String, blank As Image) As List(Of DataTable)
        'abrimos el archivo seleccionado
        Dim fila = 0
        tableDatos.Rows.Clear()
        tableError.Rows.Clear()
        Dim arrayTables As List(Of DataTable) = New List(Of DataTable)()
        Using reader As New TextFieldParser(archivoSeleccionado)
            ' indicamos cual es el delimitador (coma).
            reader.TextFieldType = FieldType.Delimited
            reader.SetDelimiters(",")
            While Not reader.EndOfData
                ' Obtenemos una matriz con los datos existentes en la línea actual.
                Dim lineaActual As String() = reader.ReadFields()
                Try
                    ' si la fila es mayor que 0 entra, esto para asegurarnos que no inprima la cabecera del archivo excel / csv

                    If ((fila > 0) And (lineaActual.Count >= 11)) Then
                        '17
                        'agregamos a la tabla la informacion
                        tableDatos.Rows.Add(blank, lineaActual(0), lineaActual(1), lineaActual(2), lineaActual(3), lineaActual(4), lineaActual(5), lineaActual(6), lineaActual(7), lineaActual(8), lineaActual(9), lineaActual(10))
                    ElseIf (lineaActual.Count < 11) Then
                        'Si el archivo tiene menos columnas muestra el error 
                        tableError.Rows.Add(Nothing, "El archivo no tiene la cantidad de columnas necesarias")
                        Exit While
                    End If
                    fila = fila + 1
                Catch ex As MalformedLineException
                    'Si existe un error muestra la columna
                    tableError.Rows.Add(lineaActual(0), "La línea actual " & ex.Message & " no es válida.")
                End Try
            End While
        End Using
        arrayTables.Add(tableDatos)
        arrayTables.Add(tableError)
        Return arrayTables
    End Function

    Public Function guardaShopify(iconE, iconB) As List(Of DataTable)
        Dim arrayTables As List(Of DataTable) = New List(Of DataTable)()
        tableError.Rows.Clear()
        For Each data As DataRow In tableDatos.Rows
            Dim valor = data("Producto")
            'Revisamos que la variable no sea nulo
            If (Not (IsNothing(valor))) Then
                Dim banError = insertProducto(data)
                'Si existe error cambimos el icono y escribimos en la tabla de error
                If (banError <> "") Then
                    Dim id = data("Sku")
                    data("Icon") = iconE
                    tableError.Rows.Add(id, banError)
                Else
                    'Si no existe error cambimos el icono y establecemos el valor del id de shopify
                    data("icon") = iconB
                End If
            End If
        Next
        arrayTables.Add(tableDatos)
        arrayTables.Add(tableError)
        Return arrayTables
    End Function

    Private Function insertProducto(data As DataRow) As String
        'declaramos las variables necesarias para array
        Dim arrayData = New Dictionary(Of String, Object)
        Dim arrayProduct = New Dictionary(Of String, Object)
        Dim arrayVariant = New List(Of Object)
        Dim arrayVariantes = New Dictionary(Of String, Object)
        Dim arrayOption = New List(Of Object)
        Dim arrayOptiones = New Dictionary(Of String, Object)
        Dim arrayOptiones2 = New Dictionary(Of String, Object)
        Dim arrayOptiones2Val(1) As String
        Dim id_mertsyst = Trim(data(7))
        Dim arrayTags() As String = Trim(data(11)).Split("|")
        Dim unidad = Trim(data(9))

        'convertimos la fila a array

        arrayVariantes.Add("barcode", Trim(data(6)))
        arrayVariantes.Add("sku", id_mertsyst)
        arrayVariantes.Add("price", Trim(data(8)))
        arrayVariantes.Add("title", unidad)
        arrayVariantes.Add("option1", unidad)
        If (Trim(data(10).ToString.ToUpper) = "SI") Then
            arrayVariantes.Add("option2", "BEBIDAS")
        End If
        arrayVariant.Add(arrayVariantes)

        arrayOptiones.Add("name", "Presentación")
        arrayOptiones.Add("position", "1")
        arrayOptiones.Add("values", (unidad))
        If (Trim(data(10).ToString.ToUpper) = "SI") Then
            arrayOptiones2.Add("name", "Clase")
            arrayOptiones2.Add("position", "2")
            arrayOptiones2.Add("values", ("BEBIDAS"))
            arrayOption.Add(arrayOptiones2)
        End If

        arrayOption.Add(arrayOptiones)

        arrayProduct.Add("title", Trim(data(1)))
        arrayProduct.Add("body_html", "<strong>" + Trim(data(2)) + "</strong>")
        arrayProduct.Add("vendor", Trim(data(3)))
        arrayProduct.Add("product_type", Trim(data(4)))
        arrayProduct.Add("options", arrayOption)
        arrayProduct.Add("tags", arrayTags)
        arrayProduct.Add("variants", arrayVariant)
        arrayData.Add("product", arrayProduct)

        'Enviar a shopify para guardar
        Return guardarProducto(arrayData)
    End Function

    Private Function guardarProducto(campo) As String
        Dim URL As String = "https://" + tienda + ".myshopify.com/admin/api/2021-10/products.json"
        Dim tmpError As String = ""
        Dim IdShopify = ""
        'Variables de conexion propias de VB.net
        Dim myReq As WebRequest
        Dim myResp As HttpWebResponse
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        'Variables que llevan las credenciales de Shopify
        Dim appKey As String = VariablesGlobales.APIKey & ":" & VariablesGlobales.Password
        Dim str As String = JsonConvert.SerializeObject(campo)
        Dim data As Byte() = Encoding.UTF8.GetBytes(str)
        Dim byteKey As Byte() = Encoding.UTF8.GetBytes(appKey)
        Dim SimpleCredential As NetworkCredential = New NetworkCredential(VariablesGlobales.APIKey, VariablesGlobales.Password)
        appKey = Convert.ToBase64String(byteKey)
        Try

            'Asignamos a la variable la la ruta, las credenciales y el tipo
            myReq = WebRequest.Create(URL)
            myReq.Credentials = SimpleCredential
            myReq.Headers.Add("Authorization", "Basic " & appKey)
            myReq.ContentType = "application/json"

            'Indicamos que el metodo POST
            myReq.Method = "POST"

            'Encriptamos los datos que estamos enviando
            myReq.ContentLength = data.Length
            Dim stream As Stream = myReq.GetRequestStream()
            stream.Write(data, 0, data.Length)
            stream.Close()

            'Recibimos la respuesta de la pagina de shopify
            myResp = myReq.GetResponse()
            Dim myreader As New StreamReader(myResp.GetResponseStream())
            If myResp.StatusCode >= 200 And myResp.StatusCode <= 210 Then

                Dim objJson As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(myreader.ReadToEnd())
                Dim arrayShopify = objJson("product")
                'Extraemos el id del shopify 
                IdShopify = arrayShopify("id").ToString()
            End If
            'Cerramos la conexion
            myResp.Close()
        Catch ex As WebException
            tmpError = ex.Message
        End Try
        'regresamos el diccionario
        Return tmpError
    End Function
End Class
