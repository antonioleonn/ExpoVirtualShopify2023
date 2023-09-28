'Importamos las librerias de lectura de archivos
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Public Class cTareas
    Public path As String

    Public Sub New(tmpPath As String)
        Me.path = tmpPath
    End Sub
    Public Function leerAutomatico()
        Dim data1 As String = ""
        Dim ListFilas = New List(Of String)
        Dim tmpPath As String = Me.path & "\automatico.txt"

        If My.Computer.FileSystem.FileExists(tmpPath) Then
            Dim leer As New StreamReader(tmpPath) 'leemos el archivo
            data1 = leer.ReadToEnd() 'Guardamos su contenido en una variable
            leer.Close() 'Cerramos el archivo
            'Si el archivo tiene mas de 1 caracter
            If data1.Length > 0 Then
                'Separamos el string en un array linea por linea
                Dim sLineas() As String = data1.Split(Convert.ToChar(Keys.Enter))
                For Each Linea As String In sLineas
                    If (Linea.Length > 0) Then
                        'Guardamos en la variable Servidores, los nombres de los servidores a utilizar
                        ListFilas.Add(Linea)
                    End If

                Next
            End If
        End If
        Return ListFilas
    End Function

    Public Function GuardarAutomatico(data As String) As String
        Dim tmpPath As String = Me.path & "\automatico.txt"
        Try
            Dim fs As FileStream = File.Create(tmpPath) 'Si el archivo no existe, lo creamos
            Dim info As Byte() = New UTF8Encoding(True).GetBytes(data)
            fs.Write(info, 0, info.Length)
            fs.Close() 'Cerramos el archivo 
            Return "Guardado"
        Catch ex As Exception
            Return "Ocurrio un error intente nuevamente"
        End Try
    End Function

End Class
