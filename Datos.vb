Public Class Datos
    Dim usuario As String
    Dim contraseña As String


    Public Property nomusuario()
        Get
            Return usuario
        End Get
        Set(ByVal value)
            usuario = value
        End Set
    End Property

    Public Property passusuario()
        Get
            Return contraseña
        End Get
        Set(ByVal value)
            contraseña = value
        End Set
    End Property

    Public Sub New(ByVal usuario As String, ByVal contraseña As String)
        nomusuario = usuario
        passusuario = contraseña
    End Sub

    Public Sub New()
    End Sub
End Class
