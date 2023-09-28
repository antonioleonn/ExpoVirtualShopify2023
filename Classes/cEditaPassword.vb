Imports System.Data.SqlClient
Imports System.Net
Imports System.Text
Imports System.IO
Imports Newtonsoft.Json
Public Class cEditaPassword
    Public Function guardaPassword(txtPass As String, tmpIdCliente As String) As String
        Dim result As String = ""
        Try
            Dim arrayData = New Dictionary(Of String, Object)
            Dim jsonResult As New List(Of Object)
            Dim arrayCostumer = New Dictionary(Of String, Object)
            Dim URL = "https://" + tienda + ".myshopify.com/admin/api/2022-01/customers/" + tmpIdCliente + ".json"
            arrayData.Add("customer", arrayCostumer)
            arrayCostumer.Add("password", txtPass)
            arrayCostumer.Add("password_confirmation", txtPass)
            jsonResult.Add(arrayData)
            For Each campo As Object In jsonResult
                'Variables de conexion propias de VB.net
                Dim myReq As WebRequest
                Dim myResp As HttpWebResponse


                'Variables que llevan las credenciales de Shopify
                Dim appKey As String = VariablesGlobales.APIKey & ":" & VariablesGlobales.Password
                Dim str As String = JsonConvert.SerializeObject(campo)
                Dim data As Byte() = Encoding.UTF8.GetBytes(str)
                Dim byteKey As Byte() = Encoding.UTF8.GetBytes(appKey)
                Dim SimpleCredential As NetworkCredential = New NetworkCredential(VariablesGlobales.APIKey, VariablesGlobales.Password)
                appKey = Convert.ToBase64String(byteKey)

                'Asignamos a la variable la la ruta, las credenciales y el tipo
                myReq = WebRequest.Create(URL)
                myReq.Credentials = SimpleCredential
                myReq.Headers.Add("Authorization", "Basic " & appKey)
                myReq.ContentType = "application/json"

                'Indicamos que el metodo sera de tipo PUT
                myReq.Method = "PUT"
                'Encriptamos los datos que estamos enviando
                myReq.ContentLength = data.Length

                Dim stream As Stream = myReq.GetRequestStream()
                stream.Write(data, 0, data.Length)
                stream.Close()

                stream.Close()
                myResp = myReq.GetResponse()
                Dim myreader As New StreamReader(myResp.GetResponseStream())
                If myResp.StatusCode <= 200 Or myResp.StatusCode >= 210 Then
                    result = "Error al actualizar el password"
                End If
                myResp.Close()
            Next
        Catch ex As WebException
            Dim data As StreamReader = New StreamReader(ex.Response.GetResponseStream)
            result = "Error: " & data.ReadToEnd
        End Try
        Return result
    End Function
End Class
