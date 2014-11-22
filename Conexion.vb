Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class Conexion
    Public Shared cnn As New SqlConnection
    Public Shared Function Conectado()
        Try
            cnn = New SqlConnection("Data Source=JAM-PC;Initial Catalog=Proyecto;Integrated Security=True")
            cnn.Open()
            Return True
        Catch ex As Exception
            MsgBox("Error de Conexión: " + ex.Message)
            Return False
        End Try

    End Function

    Public Shared Function Desconectado()
        Try
            If cnn.State = ConnectionState.Open Then
                cnn.Close()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox("Error de Conexión: " + ex.Message)
            Return False
        End Try
    End Function
End Class
