Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Threading

Public Class Server

    Dim WithEvents WinSockServer1 As New WinSockServer()
    Private demo As Threading.Thread = Nothing
    Private demo1 As Threading.Thread = Nothing
    Private demo2 As Threading.Thread = Nothing
    Private demo3 As Threading.Thread = Nothing
    Private thread As Thread
    Dim IP1 As String
    Dim port1 As String
    Dim texto As String
    Dim texto2 As String
    Dim texto3 As String
    Dim tipo As Boolean
    Private encendido As Boolean = False
    Private tool As ToolTip = New ToolTip()
    Private Mess As Mensaje
    Private mensaje1 As String
    Dim funciones As Funciones = New Funciones()
    Delegate Sub SetTextCallback(ByVal [text1] As String)

    Private Sub GuardarMensaje()
        Me.NuevoMensaje(Mess)
    End Sub

    Private Sub NuevoMensaje(ByVal Message As Mensaje)
        If IsNothing(Message.Sound) Then
            Message.Sound = ""
        End If
        If IsNothing(Message.Text) Then
            Message.Text = ""
        End If
        funciones.nuevoMensaje(Message.MessageFrom.User, Message.MessageTo.User, Message.Text, Message.Sound)
    End Sub

    Private Sub ThreadProcSafe()
        Me.SetText(IP1)
    End Sub

    Private Sub SetText(ByVal [text1] As String)
        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.Lista.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText)
            Me.Invoke(d, New Object() {[text1]})
        Else
            If tipo Then
                Lista.Items.Add(text1)
            Else
                Lista.Items.Remove(text1)
            End If
        End If
    End Sub

    Private Sub ThreadProcSafe1()
        Me.SetText1(texto)
    End Sub

    Private Sub SetText1(ByVal [text1] As String)
        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.txtMensaje.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText1)
            Me.Invoke(d, New Object() {[text1]})
        Else
            Me.txtMensaje.Text = text1
        End If
    End Sub

    Private Sub ThreadProcSafe2()
        Me.SetText2(texto2)
    End Sub

    Private Sub SetText2(ByVal [text] As String)
        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.txtDesencriptado.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText2)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.txtDesencriptado.Text = text
        End If
    End Sub

    Private Sub ThreadProcSafe3()
        Me.SetText3(texto3)
    End Sub

    Private Sub SetText3(ByVal [text1] As String)
        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.Lista.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText3)
            Me.Invoke(d, New Object() {[text1]})
        Else
            txtMD5.Text = text1
        End If
    End Sub

    Private Sub Server_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        funciones.Bitacora("La aplicación Servidor fue abierta")
        Me.txtPuerto.Text = "8050"
        tool.SetToolTip(Me.btnBoton, "Encender")
        tool.SetToolTip(Me.btnBitacora, "Bitácora")
    End Sub

    Private Sub Server_Exit(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        Try
            funciones.Bitacora("La aplicación Servidor fue cerrada")
            Me.WinSockServer1 = Nothing
            End
        Catch ex As Exception
            MsgBox("Error al Salir" & ex.Message)
        End Try
    End Sub

    Private Sub WinSockServer_NuevaConexion(ByVal IDTerminal As System.Net.IPEndPoint) Handles WinSockServer1.NuevaConexion
        'Muestro quien se conecto 

        'WinSockServer1 = New Threading.Thread(New Threading.ThreadStart(WinSockSe ))
        'IP1 = IDTerminal.Address.ToString & ":" & IDTerminal.Port.ToString
        'tipo = True
        'Me.demo = New Threading.Thread(New Threading.ThreadStart(AddressOf Me.ThreadProcSafe))
        'Me.demo.Start()

        'MsgBox("Se ha conectado un nuevo cliente desde la IP= " & IDTerminal.Address.ToString & _
        '                                               ",Puerto = " & IDTerminal.Port)
    End Sub

    Private Sub WinSockServer_ConexionTerminada(ByVal IDTerminal As System.Net.IPEndPoint) Handles WinSockServer1.ConexionTerminada
        'Muestro con quien se termino la conexion 
        'MsgBox("Se ha desconectado el cliente desde la IP= " & IDTerminal.Address.ToString & _
        '                                                    ",Puerto = " & IDTerminal.Port)
        funciones.Bitacora("El usuario " & WinSockServer1.getUser(IDTerminal) & " se desconectó")
        IP1 = WinSockServer1.Cerrar(IDTerminal)
        tipo = False
        funciones.cambioEstado(New User(IP1), 0)
        WinSockServer1.ActualizarListado()
        Me.SetText(IP1)
        'Me.demo = New Threading.Thread(New Threading.ThreadStart(AddressOf Me.ThreadProcSafe))
        'Me.demo.Start()
    End Sub

    Private Sub WinSockServer_DatosRecibidos(ByVal IDTerminal As System.Net.IPEndPoint, ByVal Datos As String) Handles WinSockServer1.DatosRecibidos
        'Muestro quien envio el mensaje 
        'TxtMensaje.Text = TxtMensaje.Text & vbCrLf & "IP(" & IDTerminal.Address.ToString & ":" & IDTerminal.Port & ")" & WinSockServer1.ObtenerDatos(IDTerminal)
        Dim y As String = Datos.Last
        Do While y.Equals("?")
            Datos = Datos.Substring(0, Datos.Length - 1)
            y = Datos.Last
        Loop
        Dim x As String = funciones.decryptString(Datos)
        texto3 = x.Substring(x.IndexOf("?XXXJAMXXX?") + 11)
        x = x.Substring(0, x.IndexOf("?XXXJAMXXX?"))
        Dim sol As Solicitud = funciones.DesSerializar(x, 1)
        texto = Datos
        texto2 = x
        If Not funciones.MD5Encrypt(texto2).Equals(texto3) Then
            MsgBox("Trama Incorrecta!" + vbCrLf + "Error al recibir la trama. La trama ha sido modificada", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Dim solicitud As Solicitud = New Solicitud(sol.TipoSolicitud)
        Select Case sol.TipoSolicitud
            Case 1
                funciones.Bitacora("Intento de logueo con el usuario " & sol.ArgumentosSolicitud.Item(0))
                Dim dat As Datos = New Datos(sol.ArgumentosSolicitud.Item(0), sol.ArgumentosSolicitud.Item(1))
                Dim res As Boolean = funciones.Validar(dat)
                If res Then
                    System.Threading.Thread.Sleep(1000)
                    funciones.Bitacora("Éxito al loguear al usuario " & sol.ArgumentosSolicitud.Item(0))
                    solicitud.MensajeSolicitud = "Exito al hacer login"
                    IP1 = sol.ArgumentosSolicitud.Item(0).ToString
                    WinSockServer1.SetUser(IDTerminal, IP1)
                    tipo = True
                    funciones.cambioEstado(New User(IP1), 1)
                    Me.demo = New Threading.Thread(New Threading.ThreadStart(AddressOf Me.ThreadProcSafe))
                    Me.demo.Start()
                Else
                    funciones.Bitacora("Error al hacer login con el usuario " & sol.ArgumentosSolicitud.Item(0))
                    solicitud.MensajeSolicitud = "Error al hacer login"
                End If

            Case 2
                Dim mensaje As String = funciones.decryptString(sol.MensajeSolicitud)
                texto = sol.MensajeSolicitud
                texto3 = mensaje.Substring(mensaje.IndexOf("?XXXJAMXXX?") + 11)
                mensaje = mensaje.Substring(0, mensaje.IndexOf("?XXXJAMXXX?"))
                texto2 = mensaje
                Dim message As Mensaje = funciones.DesSerializar(mensaje)
                If Not IsNothing(message.Sound) Then
                    If IsNothing(message.Text) Or message.Text.Equals("") Then
                        funciones.Bitacora("El usuario " & message.MessageFrom.User & " envió un mensaje de audio a " & message.MessageTo.User)
                    Else
                        funciones.Bitacora("El usuario " & message.MessageFrom.User & " envió un mensaje de audio y texto a " & message.MessageTo.User)
                    End If
                Else
                    funciones.Bitacora("El usuario " & message.MessageFrom.User & " envió un mensaje de texto a " & message.MessageTo.User)
                End If
                WinSockServer1.SetUser(IDTerminal, message.MessageFrom.User)

                solicitud.MensajeSolicitud = "Mensaje Enviado!"
                solicitud.TipoSolicitud = 5

                Dim soli As Solicitud = New Solicitud(2, sol.MensajeSolicitud)

                WinSockServer1.EnviarDatos(message.MessageTo.User, funciones.Encriptar(soli, "Solicitud"))

                Me.Mess = message
                Me.mensaje1 = mensaje
                Me.thread = New Threading.Thread(New Threading.ThreadStart(AddressOf Me.GuardarMensaje))
                Me.thread.Start()
                'funciones.nuevoMensaje(message.MessageFrom.User, message.MessageTo.User, mensaje)

            Case 3
                funciones.Bitacora("El usuario " & sol.ArgumentosSolicitud.Item(0).ToString & " solicitó el listado de usuarios")
                WinSockServer1.SetUser(IDTerminal, sol.ArgumentosSolicitud.Item(0).ToString)
                solicitud.ArgumentosSolicitud = funciones.obtenerClientes(New User(sol.ArgumentosSolicitud.Item(0).ToString))
                solicitud.MensajeSolicitud = "Usuarios Enviados"
                funciones.Bitacora("Se envió el listado de usuarios a " & sol.ArgumentosSolicitud.Item(0).ToString)

            Case 4
                funciones.Bitacora("El usuario " & sol.ArgumentosSolicitud.Item(0).ToString & " solicitó el historial de mensajes con " & sol.ArgumentosSolicitud.Item(1).ToString)
                WinSockServer1.SetUser(IDTerminal, sol.ArgumentosSolicitud.Item(0).ToString)
                Dim arg As ArrayList = New ArrayList
                arg = funciones.obtenerMensajes(New User(sol.ArgumentosSolicitud.Item(0).ToString), New User(sol.ArgumentosSolicitud.Item(1).ToString))

                solicitud.ArgumentosSolicitud = arg
                solicitud.MensajeSolicitud = "Mensajes Enviados"
                funciones.Bitacora("Se envió el historial de mensajes a " & sol.ArgumentosSolicitud.Item(0).ToString)

            Case Else

        End Select

        Dim xml As String = funciones.Serializar(solicitud, "Solicitud")
        Dim salMd As String = funciones.MD5Encrypt(xml)
        Dim tDes As String = funciones.encryptString(xml & "?XXXJAMXXX?" & salMd)
        Me.txtSalDesencriptado.Text = xml
        Me.txtSalEncriptado.Text = tDes
        Me.txtSalMD5.Text = salMd
        Me.WinSockServer1.EnviarDatos(IDTerminal, tDes)

        'Me.SetText2(texto2)
        'Me.SetText3(texto3)
        'Me.SetText1(texto)

        Me.demo1 = New Threading.Thread(New Threading.ThreadStart(AddressOf Me.ThreadProcSafe1))
        Me.demo1.Start()
        Me.demo2 = New Threading.Thread(New Threading.ThreadStart(AddressOf Me.ThreadProcSafe2))
        Me.demo2.Start()
        Me.demo3 = New Threading.Thread(New Threading.ThreadStart(AddressOf Me.ThreadProcSafe3))
        Me.demo3.Start()

        System.Threading.Thread.Sleep(600)
        If solicitud.TipoSolicitud = 1 Then
            WinSockServer1.ActualizarListado()
        End If

        'Muestro el mensaje recibido 
        ' Call MsgBox(WinSockServer1.ObtenerDatos(IDTerminal))
    End Sub

    Private Sub btnBoton_Click(sender As Object, e As EventArgs) Handles btnBoton.Click
        If Not encendido Then
            funciones.Bitacora("Se encendió el servidor")
            With WinSockServer1
                'Establezco el puerto donde escuchar 
                .PuertoDeEscucha = Me.txtPuerto.Text
                'Comienzo la escucha 
                If .Escuchar() Then
                    encendido = True
                    txtPuerto.Enabled = False
                    tool.SetToolTip(Me.btnBoton, "Apagar")
                    btnBoton.Image = ProyectoServer.My.Resources.Apagar
                End If
            End With
        Else
            funciones.Bitacora("Se apagó el servidor")
            With WinSockServer1
                .Cerrar()
            End With
            encendido = False
            txtPuerto.Enabled = True
            tool.SetToolTip(Me.btnBoton, "Encender")
            btnBoton.Image = ProyectoServer.My.Resources.Encender

        End If
    End Sub

    Private Sub btnBitacora_Click(sender As Object, e As EventArgs) Handles btnBitacora.Click
        Dim bitacora As New Bitacora()
        bitacora.Show()
    End Sub
End Class