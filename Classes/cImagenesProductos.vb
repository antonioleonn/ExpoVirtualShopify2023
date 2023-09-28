
Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class cImagenesProductos

    Private _maxProductos As Integer
    Private _cuentaProductos As Integer = 0
    Private _UltimoProducto = 0
    Private IdShopify = 0


    Public Function ListarImagenes(tmpIdShopify As String) As DataTable
        IdShopify = tmpIdShopify
        Dim tableFilter As DataTable = New DataTable
        tableFilter.Columns.Add("id")
        tableFilter.Columns.Add("rsc")
        Dim URL As String = "https://" + tienda + ".myshopify.com/admin/api/2021-10/products/" + IdShopify + "/images.json?limit=150&since_id=" + _UltimoProducto.ToString

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
            Dim arrayShopify = objJson("images")
            'Recorremos el array para ver el Id que tenga el cliente
            For Each arrayImg As Object In arrayShopify
                Dim arrayData As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(arrayImg.ToString)
                tableFilter.Rows.Add(arrayData("id"), arrayData("src"))
            Next
        End If
        myResp.Close()
        Return tableFilter
    End Function

    Public Function mostrarArticulos(direccion As String) As Bitmap

        Dim siteUri As New Uri(direccion)
        Dim tClient As WebClient = New WebClient
        Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(siteUri)))
        Return tImage
    End Function

    Public Function ImageToBase64(image As Image, format As Imaging.ImageFormat) As String
        Using ms As New MemoryStream()
            ' Convert Image to byte[]  
            image.Save(ms, format)
            Dim imageBytes As Byte() = ms.ToArray()

            ' Convert byte[] to Base64 String  
            Dim base64String As String = Convert.ToBase64String(imageBytes)
            Return base64String
        End Using
    End Function

    Public Function guardaArchivo(attachment As String, fileName As String) As String

        'declaramos las variables necesarias para array
        Dim URL = "https://" + tienda + ".myshopify.com/admin/api/2022-01/products/" + IdShopify + "/images.json"
        Dim arrayData = New Dictionary(Of String, Object)
        Dim arrayImage = New Dictionary(Of String, Object)
        Dim result = ""

        arrayImage.Add("filename", fileName)
        arrayImage.Add("attachment", attachment)
        arrayData.Add("image", arrayImage)

        'Variables de conexion propias de VB.net
        Dim myReq As WebRequest
        Dim myResp As HttpWebResponse

        'Variables que llevan las credenciales de Shopify
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        Dim appKey As String = VariablesGlobales.APIKey & ":" & VariablesGlobales.Password
        Dim str As String = JsonConvert.SerializeObject(arrayData)
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

            'Indicamos que el metodo es POST
            myReq.Method = "POST"

            'Encriptamos los datos que estamos enviando
            myReq.ContentLength = data.Length
            Dim stream As Stream = myReq.GetRequestStream()
            stream.Write(data, 0, data.Length)
            stream.Close()

            'Recibimos la respuesta de la pagina de shopify
            myResp = myReq.GetResponse()
            Dim myreader As New StreamReader(myResp.GetResponseStream())

            ' si tiene informacion entra
            If myResp.StatusCode < 200 Or myResp.StatusCode > 210 Then
                result = "Ocurrio un error al guardar en shopify"
            End If
            myResp.Close()
        Catch ex As WebException
            Dim tmpErrorWeb As StreamReader = New StreamReader(ex.Response.GetResponseStream)
            result = tmpErrorWeb.ReadToEnd
        End Try

        Return result
    End Function

    Public Function eliminaImagen(idShopify As String, idValor As String)

        'declaramos las variables necesarias para array
        Dim URL = "https://" + tienda + ".myshopify.com/admin/api/2022-01/products/" + idShopify + "/images/" + idValor + ".json"
        Dim result = ""

        'Variables de conexion propias de VB.net
        Dim myReq As WebRequest
        Dim myResp As HttpWebResponse

        'Variables que llevan las credenciales de Shopify
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        'Variables que llevan las credenciales de Shopify
        Dim appKey As String = VariablesGlobales.APIKey & ":" & VariablesGlobales.Password
        Dim byteKey As Byte() = Encoding.UTF8.GetBytes(appKey)
        Dim SimpleCredential As NetworkCredential = New NetworkCredential(VariablesGlobales.APIKey, VariablesGlobales.Password)
        appKey = Convert.ToBase64String(byteKey)

        Try
            'Asignamos a la variable la la ruta, las credenciales y el tipo
            myReq = WebRequest.Create(URL)
            myReq.Credentials = SimpleCredential
            myReq.Headers.Add("Authorization", "Basic " & appKey)
            myReq.ContentType = "application/json"

            'Indicamos que el metodo es DELETE
            myReq.Method = "DELETE"

            'Recibimos la respuesta de la pagina de shopify
            myResp = myReq.GetResponse()
            Dim myreader As New StreamReader(myResp.GetResponseStream())

            ' si tiene informacion entra
            If myResp.StatusCode < 200 Or myResp.StatusCode > 210 Then
                result = "Ocurrio un error al guardar en shopify"
            End If
            myResp.Close()
        Catch ex As WebException
            Dim tmpErrorWeb As StreamReader = New StreamReader(ex.Response.GetResponseStream)
            result = tmpErrorWeb.ReadToEnd
        End Try

        Return result

    End Function

End Class
