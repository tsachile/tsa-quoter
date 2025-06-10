Imports System.Diagnostics.Eventing.Reader

Public Class Form4
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ProgressBar1.Value += 1
        ProgressBar1.Text = ProgressBar1.Value.ToString

        If ProgressBar1.Value = 100 Then
            Timer1.Stop()
            Timer2.Start()
        End If

        If Me.ProgressBar1.Value = 10 Then
            Me.Label1.Text = "Cargando  . . ."
        ElseIf Me.ProgressBar1.Value = 20 Then
            Me.Label1.Text = "Preparando Base Datos . . ."
        ElseIf Me.ProgressBar1.Value = 30 Then
            Me.Label1.Text = "Accediendo Cotizador TSA . . ."
        ElseIf Me.ProgressBar1.Value = 40 Then
            Me.Label1.Text = "Listo . . ."
        End If
    End Sub

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProgressBar1.Value = 0
        Timer1.Start()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Stop()
        Me.Close()
        Form5.Show()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class