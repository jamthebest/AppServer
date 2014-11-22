Public Class Solicitud
    'Tipos: 1 = Login, 2 = Mensaje, 3 = ObtenerUsuarios, 4 = NuevoCliente, 5 = Respuesta
    Private tipo As Integer
    Private mensaje As String
    Private argumentos As ArrayList

    Public Sub New()
        tipo = 0
        mensaje = Nothing
        argumentos = Nothing
    End Sub

    Public Sub New(ByVal Tipo As Integer)
        Me.tipo = Tipo
        mensaje = Nothing
        argumentos = Nothing
    End Sub

    Public Sub New(ByVal Tipo As Integer, ByVal Argumentos As ArrayList)
        Me.tipo = Tipo
        mensaje = Nothing
        Me.argumentos = Argumentos
    End Sub

    Public Sub New(ByVal Tipo As Integer, ByVal Mensaje As String)
        Me.tipo = Tipo
        Me.mensaje = Mensaje
        argumentos = Nothing
    End Sub

    Public Sub New(ByVal Tipo As Integer, ByVal Argumentos As ArrayList, ByVal Mensaje As String)
        Me.tipo = Tipo
        Me.mensaje = Mensaje
        Me.argumentos = Argumentos
    End Sub

    Public Property TipoSolicitud() As Integer
        Get
            Return tipo
        End Get
        Set(ByVal value As Integer)
            tipo = value
        End Set
    End Property

    Public Property MensajeSolicitud() As String
        Get
            Return mensaje
        End Get
        Set(ByVal value As String)
            mensaje = value
        End Set
    End Property

    Public Property ArgumentosSolicitud() As ArrayList
        Get
            Return argumentos
        End Get
        Set(ByVal value As ArrayList)
            argumentos = value
        End Set
    End Property
End Class
