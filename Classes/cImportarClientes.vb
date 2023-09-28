'Importamos las librerias  
Imports Microsoft.VisualBasic.FileIO
Imports System.Text
Imports System.Net
Imports Newtonsoft.Json
'Imports System.Web.Script.Serialization
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing

Public Class cImportarClientes
    Inherits cEncripta

    'Variables que usaremos en todo el sistema 
    Private URL As String = "https://" + tienda + ".myshopify.com/admin/api/2021-10/customers"
    Private arrayIdMerksystShopify As DataTable = New DataTable("IdMerksystShopify")
    Private tableDatos As DataTable = New DataTable("tableDatos")
    Private tableError As DataTable = New DataTable("tableError")
    Private _host As String
    Private _user As String
    Private _pass As String

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
        tableDatos.Columns.Add("Id")
        tableDatos.Columns.Add("IdShopify")
        tableDatos.Columns.Add("Nombres")
        tableDatos.Columns.Add("Apellidos")
        tableDatos.Columns.Add("Correo")
        tableDatos.Columns.Add("Password")
        tableDatos.Columns.Add("Telefono")
        tableDatos.Columns.Add("Direccion_1")
        tableDatos.Columns.Add("Colonia_1")
        tableDatos.Columns.Add("Ciudad_1")
        tableDatos.Columns.Add("Estado_1")
        tableDatos.Columns.Add("Pais_1")
        tableDatos.Columns.Add("Codigo_postal_1")
        tableDatos.Columns.Add("Tags")
        tableDatos.Columns.Add("Notas")
        tableDatos.Columns.Add("Id_direccion_1")
        tableDatos.Columns.Add("Compania_1")
        tableDatos.Columns.Add("Error")

        tableError.Columns.Add("Id")
        tableError.Columns.Add("Error")
    End Sub

    Public Function cargarArchivo(archivoSeleccionado As String, userD As Image, userA As Image, Blank As Image) As List(Of DataTable)
        Dim fila As Integer = 0
        buscaClienteSQL()
        tableDatos.Rows.Clear()
        tableError.Rows.Clear()
        Dim arrayTables As List(Of DataTable) = New List(Of DataTable)()
        'tableError.Columns.AddRange()  
        'abrimos el archivo seleccionado
        Using reader As New TextFieldParser(archivoSeleccionado)
            ' indicamos cual es el delimitador (coma).
            reader.TextFieldType = FieldType.Delimited
            reader.SetDelimiters(",")
            While Not reader.EndOfData
                Try
                    ' Obtenemos una matriz con los datos existentes en la línea actual.
                    Dim lineaActual As String() = reader.ReadFields()
                    ' si la fila es mayor que 0 entra, esto para asegurarnos que no inprima la cabecera del archivo excel / csv

                    If ((fila > 0) And (lineaActual.Count >= 12)) Then
                        'Asignamos el icono que veremos al principio de la tabla
                        Dim vIcon = Blank
                        'agregamos las variables por linea
                        Dim correo = lineaActual(2)
                        Dim vPassword = "gamesa"
                        Dim tmpIdMerksyst As String = lineaActual(11)
                        'En caso de que el correo este vacio creamos un correo 
                        Dim InicialCorreo = "M"
                        If (lineaActual(0).ToString <> "") Then
                            InicialCorreo = lineaActual(0).ToString.Substring(0, 1)
                        End If
                        If (correo = "") Then
                            correo = InicialCorreo + "." + lineaActual(11).ToString + "@mexicanadeabarrotes.mx"
                        End If
                        'agregamos los ceros al inicio del id de merksist en caso de que no tenga
                        For i As Integer = tmpIdMerksyst.Count To 8
                            tmpIdMerksyst = "0" + tmpIdMerksyst
                        Next
                        lineaActual(2) = correo
                        lineaActual(11) = tmpIdMerksyst

                        Dim tipoMerksyst As String = ""
                        Dim tmpIdShopify As String = ""
                        'revisamos que el cliente este registrado y que almacen tiene
                        Dim tmpTable = arrayIdMerksystShopify.Select("id_Merksyst = '" + tmpIdMerksyst + "'")
                        If (tmpTable IsNot Nothing) Then
                            For Each tmpRow In tmpTable
                                Dim repite = True
                                tmpIdShopify = tmpRow(0)
                                tipoMerksyst = tmpRow(2)
                                For Each tmpDic In BuscarClienteShopify(tmpIdShopify)
                                    If (tmpDic.Key <> "enable") Then
                                        repite = False
                                        correo = tmpDic.Value
                                        If (tipoMerksyst = "Primaria") Then
                                            vIcon = userD
                                            tipoMerksyst = "El cliente ya esta dado de alta"
                                        Else
                                            vIcon = userA
                                            tipoMerksyst = "El cliente se encuentra como alternativo en el No: " + tmpRow(3)
                                        End If
                                    End If
                                Next
                                If (repite = False) Then
                                    Exit For
                                End If
                            Next
                        End If
                        'agregamos a la tabla la informacion
                        tableDatos.Rows.Add(vIcon, tmpIdMerksyst, tmpIdShopify, lineaActual(0), lineaActual(1), correo, vPassword, lineaActual(3), lineaActual(4), lineaActual(5), lineaActual(6), lineaActual(7), lineaActual(8), lineaActual(9), lineaActual(10), lineaActual(12), lineaActual(13), lineaActual(14), tipoMerksyst)
                        If (tipoMerksyst <> "") Then
                            tableError.Rows.Add(tmpIdMerksyst, tipoMerksyst)
                        End If
                    ElseIf (lineaActual.Count < 12) Then
                        'Si el archivo tiene menos columnas muestra el error 
                        'tableError.Columns(1).Width = gridErrores.Width - 100
                        tableError.Rows.Add(Nothing, "El archivo no tiene la cantidad de columnas necesarias")
                        Exit While

                    End If
                    fila = fila + 1
                Catch ex As MalformedLineException
                    'Si existe un error muestra la columna
                    tableError.Rows.Add(Nothing, "La línea actual " & ex.Message & " no es válida.")
                End Try
            End While

        End Using
        arrayTables.Add(tableDatos)
        arrayTables.Add(tableError)

        Return arrayTables
    End Function
    Private Sub buscaClienteSQL()
        'Variables de conexion para sql
        Dim myConn As SqlConnection
        Dim myCmd As SqlCommand
        Dim myReader As SqlDataReader
        arrayIdMerksystShopify.Columns.Clear()

        arrayIdMerksystShopify.Columns.Add("id_Shopify")
        arrayIdMerksystShopify.Columns.Add("id_Merksyst")
        arrayIdMerksystShopify.Columns.Add("Tipo")
        arrayIdMerksystShopify.Columns.Add("Alternativo")
        'creamos la coneccion con la BD principal
        myConn = New SqlConnection("Initial Catalog=TCADBMAS; Data Source=" & Me._host & "; User ID=" & Me._user & "; Password=" & Me._pass & ";")

        'Creamos el comando como consulta
        myCmd = myConn.CreateCommand
        myCmd.CommandText = "(Select distinct id_Shopify, id_Merksyst, 'Primaria' as Tipo,'' as Alternativo from shopify_cliente) Union (Select distinct ss.id_Shopify, ss.id_Merksyst, 'Secundaria' as Tipo, sc.id_Merksyst as Alternativo from shopify_cliente_sucursal as ss INNER JOIN shopify_cliente as sc ON rtrim(ltrim(ss.id_Shopify)) = rtrim(ltrim(sc.id_Shopify)))"

        'abrimos la coneccion
        myConn.Open()
        myReader = myCmd.ExecuteReader() 'Ejecuta la consulta

        'Repetimos mientras exista informacion
        Do While myReader.Read()
            'almacenamos la informacion en una Tabla
            arrayIdMerksystShopify.Rows.Add(myReader.GetString(0).ToString.Trim, myReader.GetString(1).ToString.Trim, myReader.GetString(2).ToString.Trim, myReader.GetString(3).ToString.Trim)
        Loop
        'cerramos la conexion
        myConn.Close()
    End Sub

    Private Function BuscarClienteShopify(idShopify As String) As Dictionary(Of String, String)

        Dim resultDic = New Dictionary(Of String, String)
        Dim URL As String = "https://" + VariablesGlobales.tienda + ".myshopify.com/admin/api/2021-10/customers.json?fields=id,email,state&ids=" + idShopify

        'Variables de conexion propias de VB.net
        Dim myReq As WebRequest
        Dim myResp As HttpWebResponse
        Dim maxFila = 0
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        'Variables que llevan las credenciales de Shopify
        Dim appKey As String = VariablesGlobales.APIKey & ":" & VariablesGlobales.Password
        Dim byteKey As Byte() = Encoding.UTF8.GetBytes(appKey)
        Dim SimpleCredential As NetworkCredential = New NetworkCredential(VariablesGlobales.APIKey, VariablesGlobales.Password)
        appKey = Convert.ToBase64String(byteKey)

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
            'leemos el json que regresa la pagina de shopify
            Dim jsonShopify As String = myreader.ReadToEnd()

            'Convertimos el json a un array que posteriormente vamos a recorrer
            Dim objJson As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(jsonShopify)
            Dim arrayShopify = objJson("customers")
            'Recorremos el array para ver el Id que tenga el cliente
            For Each arrayPartner As Object In arrayShopify
                Dim arrayData As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(arrayPartner.ToString)
                Dim vEmail = arrayData("email")
                If (vEmail <> "") Then
                    resultDic.Add(arrayData("state"), arrayData("email"))
                Else
                    resultDic.Add("", "")
                End If
                'extraemos la informacion que viene de la pagina 
            Next
        Else
            'Si existe error de coneccion lo mostramos
            resultDic.Add("", "")
        End If
        myResp.Close()

        Return resultDic
    End Function

    Public Function guardaShopify(iconE As Image, iconB As Image) As List(Of DataTable)
        Dim arrayTables As List(Of DataTable) = New List(Of DataTable)()
        tableError.Rows.Clear()
        Dim arrayError As Dictionary(Of String, String) = New Dictionary(Of String, String)
        For Each filas In tableDatos.Rows
            If (filas("Error").ToString() = "") Then
                'declaramos variables locales, y le asignamos un valor
                Dim tmpTelefono = Replace(filas("Telefono").ToString(), " ", "")
                Dim idClienteTel = ""
                'Extraemos el Id despues de procesarlo en la funcion
                Dim idClienteEmail = buscarCliente(filas("Correo").ToString(), "")
                'Si el telefono es diferente de nulo, extraemos el Id despues de procesarlo en la funcion
                If (tmpTelefono <> "") Then
                    idClienteTel = buscarCliente("", tmpTelefono)
                End If
                'Si ninguno de los ids, trae un valor enviamos a la funcion de alta, y lo guardamos en Error
                If (idClienteEmail = "" And idClienteTel = "") Then
                    For Each item In insertCliente(filas)
                        If (item.Value <> "") Then
                            arrayError.Add(filas("Id"), item.Value)
                            filas("Icon") = iconE
                        Else
                            filas("Icon") = iconB
                            filas("IdShopify") = item.Key
                        End If
                    Next
                Else
                    Dim Mensaje = "El correo o el telefono corresponden al cliente: " + idClienteEmail + " " + idClienteTel + "(Id Shopify)"
                    filas("Error") = Mensaje
                    arrayError.Add(filas("Id").ToString, Mensaje)
                    filas("Icon") = iconE
                End If
            End If
        Next
        For Each item In arrayError
            tableError.Rows.Add(item.Key, item.Value)
        Next
        arrayTables.Add(tableDatos)
        arrayTables.Add(tableError)
        Return arrayTables
    End Function

    Private Function buscarCliente(correo As String, tel As String)
        Dim IdShopify As String = ""
        Dim tmpUrl = URL + "/search.json?fields=id&query="
        ' si la linea contiene correo, busca por el correo
        If correo <> "" Then
            tmpUrl = tmpUrl & "email:" + correo
        ElseIf tel <> "" Then
            ' si la linea contiene telefono, busca por el telefono
            tmpUrl = tmpUrl & "phone:" + tel
        End If
        Try
            'Variables de conexion propias de VB.net
            Dim myReq As WebRequest
            Dim myResp As HttpWebResponse
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            'Variables que llevan las credenciales de Shopify
            Dim appKey As String = VariablesGlobales.APIKey & ":" & VariablesGlobales.Password
            Dim byteKey As Byte() = Encoding.UTF8.GetBytes(appKey)
            Dim SimpleCredential As NetworkCredential = New NetworkCredential(VariablesGlobales.APIKey, VariablesGlobales.Password)
            appKey = Convert.ToBase64String(byteKey)

            'Asignamos a la variable la la ruta, las credenciales y el tipo
            myReq = WebRequest.Create(tmpUrl)
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
                'leemos el json que regresa la pagina de shopify
                Dim jsonShopify As String = myreader.ReadToEnd()

                'Convertimos el json a un array que posteriormente vamos a recorrer
                Dim objJson As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(jsonShopify)
                Dim arrayShopify = objJson("customers")

                'Recorremos el array para ver el Id que tenga el cliente
                For Each arrayPartner As Object In arrayShopify
                    Dim arrayData As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(arrayPartner.ToString)
                    IdShopify = arrayData("id")
                Next
            End If
            'cerramos la conexion
            myResp.Close()
            myreader.Close()
        Catch ex As WebException
            'Regresamos el Id en blanco
            Return IdShopify
        End Try
        'Regresamos la informacion del IdShopify o en blanco
        Return IdShopify
    End Function


    Private Function insertCliente(fila As DataRow) As Dictionary(Of String, String)
        'declaramos las variables necesarias para array
        Dim arrayData = New Dictionary(Of String, Object)
        Dim arrayCostumer = New Dictionary(Of String, Object)
        Dim arrayAddresses = New Dictionary(Of String, Object)
        Dim arrayAddress = New List(Of Object)
        Dim arrayTags() As String = RTrim(LTrim(fila("Tags").ToString)).Split("|")
        Dim id_mertsyst = fila("Id").ToString

        'convertimos la fila a array
        arrayCostumer.Add("id_mertsyst", id_mertsyst)
        arrayCostumer.Add("first_name", fila("Nombres").ToString)
        arrayCostumer.Add("last_name", fila("Apellidos").ToString)
        arrayCostumer.Add("email", fila("Correo").ToString)
        arrayCostumer.Add("phone", fila("Telefono").ToString)
        arrayCostumer.Add("verified_email", "True")
        arrayCostumer.Add("password", fila("Password").ToString)
        arrayCostumer.Add("password_confirmation", fila("Password").ToString)
        arrayCostumer.Add("newpass", "false")
        arrayCostumer.Add("tags", arrayTags)
        arrayAddresses.Add("address1", fila("Direccion_1").ToString)
        arrayAddresses.Add("address2", fila("Colonia_1").ToString)
        arrayAddresses.Add("city", fila("Ciudad_1").ToString)
        arrayAddresses.Add("province", fila("Estado_1").ToString)
        arrayAddresses.Add("country", fila("Pais_1").ToString)
        arrayAddresses.Add("phone", fila("Telefono").ToString)
        arrayAddresses.Add("zip", fila("Codigo_postal_1").ToString)
        arrayAddresses.Add("last_name", fila("Apellidos").ToString)
        arrayAddresses.Add("first_name", fila("Nombres").ToString)
        arrayAddress.Add(arrayAddresses)
        arrayCostumer.Add("addresses", arrayAddress)
        arrayData.Add("customer", arrayCostumer)

        'Enviar a shopify para guardar
        Return guardarCliente(arrayData, "POST", URL + ".json", id_mertsyst)
    End Function

    Private Function guardarCliente(campo, metodo, pageUrl, id_mertsyst) As Dictionary(Of String, String)
        Dim tmpError As String = ""
        Dim dicError As Dictionary(Of String, String) = New Dictionary(Of String, String)
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
            myReq = WebRequest.Create(pageUrl)
            myReq.Credentials = SimpleCredential
            myReq.Headers.Add("Authorization", "Basic " & appKey)
            myReq.ContentType = "application/json"

            'Indicamos que el metodo (este es determinado por el movimiento, PUT o POST)
            myReq.Method = metodo

            'Encriptamos los datos que estamos enviando
            myReq.ContentLength = data.Length

            Dim stream As Stream = myReq.GetRequestStream()
            stream.Write(data, 0, data.Length)
            stream.Close()


            'Recibimos la respuesta de la pagina de shopify
            myResp = myReq.GetResponse()
            Dim myreader As New StreamReader(myResp.GetResponseStream())

            ' si tiene informacion entra
            If myResp.StatusCode >= 200 And myResp.StatusCode <= 210 Then
                'leemos el json que regresa la pagina de shopify y Convertimos el json a un array que posteriormente vamos a recorrer
                Try
                    Dim objJson As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(myreader.ReadToEnd())
                    Dim arrayShopify = objJson("customer")
                    'Extraemos el id del shopify 
                    IdShopify = arrayShopify("id").ToString()
                Catch ex As Exception
                    tmpError = ex.Message
                End Try
                If (IdShopify <> "") And (tmpError = "") Then
                    'Variables de conexion para sql
                    Dim myConn As SqlConnection
                    Dim myCmd As SqlCommand
                    Dim results As String = ""
                    Try
                        'creamos la coneccion con la BD principal
                        myConn = New SqlConnection("Initial Catalog=TCADBMAS; Data Source=" & _host & "; User ID=" & _user & "; Password=" & _pass & ";")

                        'Creamos el comando como procedimiento almacenado
                        myCmd = myConn.CreateCommand
                        myCmd.CommandType = CommandType.StoredProcedure

                        'Enviamos los parametros
                        myCmd.Parameters.Add(New SqlParameter("@id_Shopify", IdShopify))
                        myCmd.Parameters.Add(New SqlParameter("@id_Merksyst", id_mertsyst))
                        'declaramos una variable de tipo OUTPUT del procedimiento almacenado
                        myCmd.Parameters.Add("@respuesta", SqlDbType.VarChar, 255)
                        myCmd.Parameters("@respuesta").Direction = ParameterDirection.Output
                        myCmd.CommandText = "sp_insertClienteShoppify"
                        'abrimos la coneccion
                        myConn.Open()
                        myCmd.ExecuteNonQuery() ' Ejecuta el procedimiento almacenado 

                        'almacenamos la respuesta que envia el procedimiento
                        Dim resultado As String = myCmd.Parameters("@respuesta").Value
                        'Limpiamos caracteres en blanco y determinamos si existe un error (si trae algun mensaje)
                        If (resultado.Replace(" "c, String.Empty) <> "") Then
                            tmpError = myCmd.Parameters("@respuesta").Value
                        End If
                        'cerramos la conexion
                        myConn.Close()
                    Catch ex As Exception
                        tmpError = "Error al guardar en la DB de Merksyst"
                    End Try
                End If
            Else
                tmpError = "Error en la pagina web"
            End If
            'Cerramos la conexion
            myResp.Close()
            myreader.Close()
        Catch ex As WebException
            tmpError = ex.Message
        End Try
        'agregamos la informacion del id del cliente y el error al diccionario
        dicError.Add(IdShopify, tmpError)
        'regresamos el diccionario
        Return dicError
    End Function

End Class
