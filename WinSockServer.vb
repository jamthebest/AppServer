Imports System
Imports System.Threading
Imports System.Net.Sockets
Imports System.IO
Imports System.Text
Imports System.Collections

Public Class WinSockServer

#Region "ESTRUCTURAS"
    Private Structure InfoDeUnCliente
        'Esta estructura permite guardar la información sobre un cliente 
        Public Socket As Socket 'Socket utilizado para mantener la conexion con el cliente 
        Public Thread As Thread 'Thread utilizado para escuchar al cliente 
        Public UltimosDatosRecibidos As String 'Ultimos datos enviados por el cliente 
        Public User As String
    End Structure
#End Region


#Region "VARIABLES"
    Private tcpLsn As TcpListener
    Private Clientes As New Hashtable() 'Aqui se guarda la informacion de todos los clientes conectados 
    Private tcpThd As Thread
    Private IDClienteActual As Net.IPEndPoint 'Ultimo cliente conectado 
    Private m_PuertoDeEscucha As String
#End Region


#Region "EVENTOS"
    Public Event NuevaConexion(ByVal IDTerminal As Net.IPEndPoint)
    Public Event DatosRecibidos(ByVal IDTerminal As Net.IPEndPoint, ByVal Datos As String)
    Public Event ConexionTerminada(ByVal IDTerminal As Net.IPEndPoint)
#End Region


#Region "PROPIEDADES"
    Property PuertoDeEscucha() As String
        Get
            PuertoDeEscucha = m_PuertoDeEscucha
        End Get
        Set(ByVal Value As String)
            m_PuertoDeEscucha = Value
        End Set
    End Property
#End Region


#Region "METODOS"
    Public Sub SetUser(ByVal id As Net.IPEndPoint, ByVal usuario As String)
        Try
            Dim user As InfoDeUnCliente = Clientes(id)
            user.User = usuario
            Clientes.Remove(id)
            Clientes.Add(id, user)
            'user = Clientes(id)
            'CType(Clientes(id), InfoDeUnCliente).User = usuario
        Catch e As Exception
            MsgBox("Error en la solicitud!" & vbCrLf & e.Message)
        End Try
    End Sub

    Public Function getUser(ByVal id As Net.IPEndPoint) As String
        Dim Cliente As InfoDeUnCliente = Clientes(id)
        Return Cliente.User
    End Function

    Public Sub ActualizarListado()
        Try
            Dim InfoClienteActual As InfoDeUnCliente
            Dim funciones As New Funciones()
            'Recorro todos los clientes y voy cerrando las conexiones 
            For Each InfoClienteActual In Clientes.Values
                If Not IsNothing(InfoClienteActual.User) Then
                    Dim Solicitud As New Solicitud(3)
                    Solicitud.ArgumentosSolicitud = funciones.obtenerClientes(New User(InfoClienteActual.User))
                    Solicitud.MensajeSolicitud = "Usuarios Enviados"
                    Call EnviarDatos(InfoClienteActual.Socket.RemoteEndPoint, funciones.Encriptar(Solicitud, "Solicitud"))
                End If
            Next
        Catch e As Exception
            MsgBox("Error al actualizar listado!" & vbCrLf & e.Message)
        End Try
    End Sub

    Public Function Escuchar() As Boolean
        Try
            tcpLsn = New TcpListener(PuertoDeEscucha)
            'Inicio la escucha 
            tcpLsn.Start()
            'Creo un thread para que se quede escuchando la llegada de un cliente 
            tcpThd = New Thread(AddressOf EsperarCliente)
            tcpThd.Start()
            Return True
        Catch e As Exception
            MsgBox("Error al encender el Servidor: " & e.Message)
        End Try
        Return False
    End Function

    Public Function ObtenerDatos(ByVal IDCliente As Net.IPEndPoint) As String
        Try
            Dim InfoClienteSolicitado As InfoDeUnCliente
            'Obtengo la informacion del cliente solicitado 
            InfoClienteSolicitado = Clientes(IDCliente)
            ObtenerDatos = InfoClienteSolicitado.UltimosDatosRecibidos
        Catch e As Exception
            MsgBox("Error al obtener datos!" & vbCrLf & e.Message)
        End Try
        Return Nothing
    End Function

    Public Function Cerrar(ByVal IDCliente As Net.IPEndPoint) As String
        Try
            Dim InfoClienteActual As InfoDeUnCliente
            'Obtengo la informacion del cliente solicitado 
            InfoClienteActual = Clientes(IDCliente)
            'Cierro la conexion con el cliente 
            If Not IsNothing(InfoClienteActual.Socket) Then
                InfoClienteActual.Socket.Close()
            End If
            Clientes.Remove(IDCliente)
            Return InfoClienteActual.User
        Catch e As Exception
            MsgBox("Error al cerrar socket!" & vbCrLf & e.Message)
        End Try
        Return ""
    End Function

    Public Sub Cerrar()
        Try
            Dim InfoClienteActual As InfoDeUnCliente
            'Recorro todos los clientes y voy cerrando las conexiones 
            For Each InfoClienteActual In Clientes.Values
                Call Cerrar(InfoClienteActual.Socket.RemoteEndPoint)
            Next
            tcpThd.Suspend()
            tcpLsn.Stop()
        Catch ex As Exception
            MsgBox("Error al Cerrar Conexiones" & ex.Message)
        End Try
    End Sub

    Public Sub EnviarDatos(ByVal user As String, ByVal datos As String)
        SyncLock Me
            Try
                Dim Cliente As InfoDeUnCliente
                For Each Cliente In Clientes.Values
                    If Cliente.User.Equals(user) Then
                        EnviarDatos(Cliente.Socket.RemoteEndPoint, datos)
                    End If
                Next
            Catch e As Exception
                MsgBox("Error al Enviar Datos: " & e.Message)
            End Try
        End SyncLock
    End Sub

    Public Sub EnviarDatos(ByVal IDCliente As Net.IPEndPoint, ByVal Datos As String)
        Try
            If Clientes.ContainsKey(IDCliente) Then
                Dim mens As String = Datos & "?"
                Dim mensaje As String = mens
                While Encoding.ASCII.GetBytes(mens).Length > 1024
                    mens = mens.Substring(0, mens.Length - 1024)
                End While

                'MsgBox("Tamaño: " & Encoding.ASCII.GetBytes(mensaje).Length)
                While (Encoding.ASCII.GetBytes(mens).Length < 1024)
                    mens = mens & "?"
                    mensaje = mensaje & "?"
                End While
                'MsgBox("Tamaño: " & Encoding.ASCII.GetBytes(mensaje).Length)

                Dim Cliente As InfoDeUnCliente

                'Obtengo la informacion del cliente al que se le quiere enviar el mensaje 
                Cliente = Clientes(IDCliente)
                'Le envio el mensaje 
                Cliente.Socket.Send(Encoding.ASCII.GetBytes(mensaje))
            End If
        Catch e As Exception
            MsgBox("Error al Enviar Datos!" & vbCrLf & e.Message)
        End Try
    End Sub

    Public Sub EnviarDatos(ByVal Datos As String)
        Dim Cliente As InfoDeUnCliente
        'Recorro todos los clientes conectados, y les envio el mensaje recibido 
        'en el parametro Datos 
        For Each Cliente In Clientes.Values
            EnviarDatos(Cliente.Socket.RemoteEndPoint, Datos)
        Next
    End Sub

#End Region


#Region "FUNCIONES PRIVADAS"
    Private Sub EsperarCliente()
        Dim InfoClienteActual As InfoDeUnCliente = Nothing
        With InfoClienteActual
            While True
                'Cuando se recibe la conexion, guardo la informacion del cliente 
                'Guardo el Socket que utilizo para mantener la conexion con el cliente 
                .Socket = tcpLsn.AcceptSocket() 'Se queda esperando la conexion de un cliente 
                'Guardo el el RemoteEndPoint, que utilizo para identificar al cliente 
                IDClienteActual = .Socket.RemoteEndPoint
                'Creo un Thread para que se encargue de escuchar los mensaje del cliente 
                .Thread = New Thread(AddressOf LeerSocket)
                'Agrego la informacion del cliente al HashArray Clientes, donde esta la 
                'informacion de todos estos 
                SyncLock Me
                    Clientes.Add(IDClienteActual, InfoClienteActual)
                End SyncLock
                'Genero el evento Nueva conexion 
                RaiseEvent NuevaConexion(IDClienteActual)
                'Inicio el thread encargado de escuchar los mensajes del cliente 
                .Thread.Start()
            End While
        End With
    End Sub

    Private Sub LeerSocket()
        Dim IDReal As Net.IPEndPoint 'ID del cliente que se va a escuchar 
        Dim Recibir() As Byte 'Array utilizado para recibir los datos que llegan 
        Dim InfoClienteActual As InfoDeUnCliente 'Informacion del cliente que se va escuchar 
        Dim Ret As Integer = 0
        IDReal = IDClienteActual
        InfoClienteActual = Clientes(IDReal)
        With InfoClienteActual
            While True
                If .Socket.Connected Then
                    Recibir = New Byte(1023) {}
                    Try
                        Dim men As String = ""
                        'Me quedo esperando a que llegue un mensaje desde el cliente 
                        Do
                            Ret = .Socket.Receive(Recibir, Recibir.Length, SocketFlags.None)
                            men &= Encoding.ASCII.GetString(Recibir)
                            'MsgBox(men.Length & ">= 266240")
                        Loop While Not men.Last.ToString.Equals("?") And men.Length < 300000

                        If Ret > 0 Then
                            'Guardo el mensaje recibido 
                            .UltimosDatosRecibidos = Encoding.ASCII.GetString(Encoding.ASCII.GetBytes(men))
                            Clientes(IDReal) = InfoClienteActual
                            'Genero el evento de la recepcion del mensaje 
                            RaiseEvent DatosRecibidos(IDReal, .UltimosDatosRecibidos)
                        Else
                            'Genero el evento de la finalizacion de la conexion 
                            RaiseEvent ConexionTerminada(IDReal)
                            Exit While
                        End If
                    Catch e As Exception
                        If Not .Socket.Connected Then
                            'Genero el evento de la finalizacion de la conexion 
                            RaiseEvent ConexionTerminada(IDReal)
                            Exit While
                        End If
                    End Try
                End If
            End While
            Call CerrarThread(IDReal)
        End With
    End Sub

    Private Sub CerrarThread(ByVal IDCliente As Net.IPEndPoint)
        Dim InfoClienteActual As InfoDeUnCliente
        'Cierro el thread que se encargaba de escuchar al cliente especificado 
        InfoClienteActual = Clientes(IDCliente)
        Try
            InfoClienteActual.Thread.Abort()
        Catch e As Exception
            SyncLock Me
                'Elimino el cliente del HashArray que guarda la informacion de los clientes 
                Clientes.Remove(IDCliente)
            End SyncLock
        End Try
    End Sub
#End Region
End Class
