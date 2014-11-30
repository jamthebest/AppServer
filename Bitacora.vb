Public Class Bitacora
    Private funciones As New Funciones()

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub Bitacora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim log As ArrayList = funciones.getBitacora()
        For Each item As String In log
            Me.lstBitacora.Items.Add(item)
        Next
        Me.btnSalir.Focus()
    End Sub
End Class