Public Class User
    Private Usuario As String

    Public Sub New()
        Usuario = ""
    End Sub

    Public Sub New(ByVal user As String)
        Usuario = user
    End Sub

    Public Property User() As String
        Get
            Return Usuario
        End Get
        Set(ByVal Value As String)
            Usuario = Value
        End Set
    End Property
End Class
