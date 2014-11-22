﻿Imports System
Imports System.IO
Imports System.Collections
Imports System.Xml.Serialization
Imports System.Data.SqlClient
Imports System.Text
Imports System.Security.Cryptography

Public Class Funciones
    Inherits Conexion
    Dim cmd As New SqlCommand
    Private Key As String 'llave para la encriptación 3DES
    Private IVector() As Byte = {27, 9, 45, 27, 0, 72, 171, 54} 'Vector para encriptación 3DES


    Public Function Validar(ByVal dat As Datos) As Boolean
        SyncLock Me
            Try
                Conectado()
                cmd = New SqlCommand("Validar")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = cnn
                cmd.Parameters.AddWithValue("@user", dat.nomusuario)
                cmd.Parameters.AddWithValue("@pass", dat.passusuario)

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                MsgBox("Error al Validar: " & ex.Message)
                Return False
            Finally
                Desconectado()
            End Try
        End SyncLock
    End Function

    Public Function obtenerClientes(ByVal usuario As User) As ArrayList
        SyncLock Me
            Try
                Conectado()
                cmd = New SqlCommand("obtenerClientes")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = cnn
                cmd.Parameters.AddWithValue("@user", usuario.User)
        
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader
                Dim clientes As New ArrayList
                clientes.Add("Conectados")
                If dr.HasRows = True Then
                    For Each item As System.Data.Common.DbDataRecord In dr
                        clientes.Add(item.GetString(0))
                    Next
                End If
                Desconectado()
        
                Conectado()
                cmd = New SqlCommand("obtenerDesconectados")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = cnn
                cmd.Parameters.AddWithValue("@user", usuario.User)

                Dim dr2 As SqlDataReader
                dr2 = cmd.ExecuteReader
                clientes.Add("Desconectados")
                If dr2.HasRows = True Then
                    For Each item As System.Data.Common.DbDataRecord In dr2
                        clientes.Add(item.GetString(0))
                    Next
                End If

                Return clientes
            Catch ex As Exception
                MsgBox("Error al obtener Clientes: " & ex.Message)
                Return New ArrayList
            Finally
                Desconectado()
            End Try
        End SyncLock
    End Function

    Public Function nuevoCliente(ByVal usuario As Datos) As Boolean
        SyncLock Me
            Try
                Conectado()
                cmd = New SqlCommand("nuevoCliente")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = cnn
                cmd.Parameters.AddWithValue("@user", usuario.nomusuario)
                cmd.Parameters.AddWithValue("@pass", usuario.passusuario)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader
                Return True
            Catch ex As Exception
                MsgBox("Error al crear Cliente: " & ex.Message)
                Return False
            Finally
                Desconectado()
            End Try
        End SyncLock
    End Function

    Public Function cambioEstado(ByVal usuario As User, ByVal estado As Integer) As Boolean
        SyncLock Me
            Try
                Conectado()
                cmd = New SqlCommand("estadoConectado")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = cnn
                cmd.Parameters.AddWithValue("@user", usuario.User)
                cmd.Parameters.AddWithValue("@estado", estado)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader
                Return True
            Catch ex As Exception
                MsgBox("Error al cambiar Estado: " & ex.Message)
                Return False
            Finally
                Desconectado()
            End Try
        End SyncLock
    End Function

    Public Function obtenerMensajes(ByVal usuario As User, ByVal para As User, ByVal contador As Integer) As System.Data.SqlClient.SqlDataReader
        SyncLock Me
            Try
                Conectado()
                cmd = New SqlCommand("obtenerMensajes")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = cnn
                cmd.Parameters.AddWithValue("@de", usuario.User)
                cmd.Parameters.AddWithValue("@para", para.User)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader
                Return dr
            Catch ex As Exception
                MsgBox("Error al cambiar Estado: " & ex.Message)
                Return Nothing
            Finally
                Desconectado()
            End Try
        End SyncLock
    End Function

    Function Serializar(ByVal mensaje As Mensaje, ByVal ruta As String) As String
        SyncLock Me
            If (IO.File.Exists(ruta & ".xml")) Then
                IO.File.Delete(ruta & ".xml")
            End If
            Dim objStreamWriter As New StreamWriter(ruta & ".xml")
            Dim x As New XmlSerializer(mensaje.GetType)
            Try
                x.Serialize(objStreamWriter, mensaje)
            Catch ex As NotImplementedException
                MsgBox("Error al Serializar: " & ex.ToString, MsgBoxStyle.Critical, "Error!")
            Finally
                objStreamWriter.Close()
            End Try
            Return FileToString(ruta & ".xml")
        End SyncLock
    End Function

    Function Serializar(ByVal objeto As Solicitud, ByVal ruta As String) As String
        SyncLock Me
            Try
                If (IO.File.Exists(ruta & ".xml")) Then
                    IO.File.Delete(ruta & ".xml")
                End If
                Dim objStreamWriter As New StreamWriter(ruta & ".xml")
                Dim x As New XmlSerializer(objeto.GetType)
                Try
                    x.Serialize(objStreamWriter, objeto)
                Catch ex As NotImplementedException
                    MsgBox("Error al Serializar: " & ex.ToString, MsgBoxStyle.Critical, "Error!")
                Finally
                    objStreamWriter.Close()
                End Try
            Catch e As Exception
                MsgBox("Error al Serializar: " & e.ToString)
            End Try
            Return FileToString(ruta & ".xml")
        End SyncLock
    End Function

    Public Function DesSerializar(ByVal xml As String) As Mensaje
        SyncLock Me
            Dim mensaje As New Mensaje()
            Dim x As New XmlSerializer(mensaje.GetType)
            'Deserialize text file to a new object.
            Dim objStreamReader As New StreamReader(xmlToFile(xml))
            Try
                mensaje = x.Deserialize(objStreamReader)
            Catch ex As Exception
                MsgBox("Error al DesSerializar: " & ex.ToString)
            Finally
                objStreamReader.Close()
            End Try
            Return mensaje
        End SyncLock
    End Function

    Public Function DesSerializar(ByVal xml As String, ByVal nada As Integer) As Solicitud
        SyncLock Me
            Dim mensaje As New Solicitud()
            Dim x As New XmlSerializer(mensaje.GetType)
            'Deserialize text file to a new object.
            Dim objStreamReader As New StreamReader(xmlToFile(xml))
            Try
                mensaje = x.Deserialize(objStreamReader)
            Catch ex As Exception
                MsgBox("Error al DesSerializar: " & ex.ToString)
            Finally
                objStreamReader.Close()
            End Try
            Return mensaje
        End SyncLock
    End Function

    Private Function xmlToFile(ByVal xml As String) As String
        My.Computer.FileSystem.WriteAllText("Server.xml", xml, False)
        Return "Server.xml"
    End Function

    Private Function FileToString(ByVal ruta As String) As String
        SyncLock Me
            Dim objeto As New StreamReader(ruta)
            Dim sLine As String = ""
            Dim Texto As String = ""
            Try
                Do
                    sLine = objeto.ReadLine()
                    If Not sLine Is Nothing Then
                        Texto &= sLine & vbCrLf
                    End If
                Loop Until sLine Is Nothing
            Catch ex As Exception
                MsgBox("Error al convertir XML a String: " & ex.ToString)
            Finally
                objeto.Close()
            End Try
            Return Texto
        End SyncLock
    End Function

    Public Function FileToByteArray(ByVal _FileName As String) As String
        Return Convert.ToBase64String(System.IO.File.ReadAllBytes(_FileName))
    End Function

    Public Function FileToByteArray2(ByVal _FileName As String) As Byte()
        SyncLock Me
            Dim _Buffer() As Byte = Nothing
            Dim ret As String = ""
            Try
                ' Open file for reading
                Dim _FileStream As New System.IO.FileStream(_FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                ' attach filestream to binary reader
                Dim _BinaryReader As New System.IO.BinaryReader(_FileStream)
                ' get total byte length of the file
                Dim _TotalBytes As Long = New System.IO.FileInfo(_FileName).Length
                Try
                    ' read entire file into buffer
                    _Buffer = _BinaryReader.ReadBytes(CInt(Fix(_TotalBytes)))
                    ret = Convert.ToBase64String(_Buffer)
                    MsgBox(ret)
                Catch _Exception As Exception
                    MsgBox("Error al convertir Audio a Bytes: " & _Exception.ToString)
                Finally
                    ' close file reader
                    _FileStream.Close()
                    _FileStream.Dispose()
                    _BinaryReader.Close()
                End Try
                Return _Buffer
            Catch ex As Exception
                MsgBox("Error al abrir audio: " & ex.ToString)
            End Try
            Return _Buffer
        End SyncLock
    End Function

    Public Function BytesToFile(ByVal bytDataArray As String, ByVal nombre As String, ByVal numero As Integer) As System.IO.FileStream
        SyncLock Me
            Dim fsDataArray As New System.IO.FileStream(nombre & numero & ".mp3", System.IO.FileMode.Create)
            Try
                With fsDataArray
                    .Write(Convert.FromBase64String(bytDataArray), 0, bytDataArray.Length)
                End With
            Catch ex As Exception
                MsgBox("Error al convertir Bytes en Audio: " & ex.ToString)
            Finally
                With fsDataArray
                    .Close() : .Dispose()
                End With
            End Try
            Return fsDataArray
        End SyncLock
    End Function

    'Función que encripta los datos en MD5
    Public Function MD5Encrypt(ByVal texto As String) As String
        SyncLock Me
            Dim encryt As String = ""
            Try
                Dim md5 As MD5CryptoServiceProvider
                Dim bytValue As Byte()
                Dim bytHash As Byte()
                Dim i As Integer

                md5 = New MD5CryptoServiceProvider
                bytValue = System.Text.Encoding.UTF8.GetBytes(texto)
                bytHash = md5.ComputeHash(bytValue)
                md5.Clear()

                For i = 0 To bytHash.Length - 1
                    encryt &= bytHash(i).ToString("x").PadLeft(2, "0")
                Next
            Catch ex As Exception
                MsgBox("Error al encriptar en MD5: " & ex.ToString)
            End Try
            Return encryt
        End SyncLock
    End Function

    'Función que encripta los datos en 3DES
    Public Function encryptString(ByVal str As String) As String
        SyncLock Me
            Dim ITransform As CryptoAPITransform = Nothing
            Dim byteData() As Byte = Nothing
            Try
                Dim enc As New ASCIIEncoding
                byteData = enc.GetBytes(str)
                Dim tDes As New TripleDESCryptoServiceProvider()
                Dim md5 As New MD5CryptoServiceProvider()

                tDes.Key = md5.ComputeHash(enc.GetBytes("JAM")) 'Elige una llave que es la encriptacion en md5 de la palabra JAM
                tDes.IV = IVector

                ITransform = tDes.CreateEncryptor()
            Catch ex As Exception
                MsgBox("Error al encriptar en 3DES: " & ex.ToString)
            End Try
            Return Convert.ToBase64String(ITransform.TransformFinalBlock(byteData, 0, byteData.Length))
        End SyncLock
    End Function

    'Función que desencripta la encriptación 3DES
    Public Function decryptString(ByVal str As String) As String
        SyncLock Me
            Dim ITransform As CryptoAPITransform = Nothing
            Dim encData() As Byte = Nothing
            Try
                Dim enc As New ASCIIEncoding
                Dim md5 As New MD5CryptoServiceProvider()
                Dim byteData() As Byte = enc.GetBytes(str)
                encData = Convert.FromBase64String(str)
                Dim tDes As New TripleDESCryptoServiceProvider()

                tDes.Key = md5.ComputeHash(enc.GetBytes("JAM"))
                tDes.IV = IVector

                ITransform = tDes.CreateDecryptor()
            Catch ex As Exception
                MsgBox("Error al desencriptar: " & ex.ToString)
            End Try
            Return Encoding.ASCII.GetString(ITransform.TransformFinalBlock(encData, 0, encData.Length()))
        End SyncLock
    End Function
End Class