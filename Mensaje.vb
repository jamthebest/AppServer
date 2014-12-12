Public Class Mensaje
    Private Texto As String
    Private Sonido As String
    Private Para As User
    Private De As User

    Public Sub New()
        Texto = ""
        Sonido = Nothing
        Para = New User()
        De = New User()
    End Sub

    Public Sub New(ByVal text As String)
        Texto = text
        Sonido = Nothing
        Para = New User()
        De = New User()
    End Sub

    Public Sub New(ByVal text As String, ByVal para As User, ByVal de As User)
        Texto = text
        Sonido = Nothing
        Me.Para = para
        Me.De = de
    End Sub

    Public Sub New(ByVal text As String, ByVal sonido As String, ByVal para As User, ByVal de As User)
        Texto = text
        Me.Sonido = sonido
        Me.Para = para
        Me.De = de
    End Sub

    Public Property Text() As String
        Get
            Return Texto
        End Get
        Set(ByVal Value As String)
            Texto = Value
        End Set
    End Property

    Public Property Sound() As String
        Get
            Return Sonido
        End Get
        Set(ByVal Value As String)
            Sonido = Value
        End Set
    End Property

    Public Property MessageTo() As User
        Get
            Return Para
        End Get
        Set(ByVal Value As User)
            Para = Value
        End Set
    End Property

    Public Property MessageFrom() As User
        Get
            Return De
        End Get
        Set(ByVal Value As User)
            De = Value
        End Set
    End Property
End Class
