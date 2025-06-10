Public Class Form9
    Private aIndex As Byte = nIdex
    Private Altura As Integer = 100
    Dim x As Integer = 0

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Location = New Point(Screen.PrimaryScreen.Bounds.Width - 300, Screen.PrimaryScreen.Bounds.Height)
        If nIdex < 3 Then
            nIdex += 1
        Else
            nIdex = 1
        End If
        If aIndex = 1 Then
            Altura = 100
        ElseIf aIndex = 2 Then
            Altura = 180
        ElseIf aIndex = 3 Then
            Altura = 260
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Opacity = 0 Then
            Close()
        End If
        'Opacidad
        If x = 200 Then
            Opacity -= 0.01
        End If
        If Not Location.Y = Screen.PrimaryScreen.WorkingArea.Height - Altura Then
            Location = New Point(Location.X, Location.Y - 2)
        End If

        'Opacidad
        If Not x = 200 Then
            x += 1
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
'==========MODULO PARA CREAR NOTIFICACIONES PUSH PARA ALERTA DE SEGUIMIENTO DE COTIZACIONES===================================
Public Module General
    Public nIdex As Byte = 1
    Enum Estado
        [Ok]

    End Enum
    Public Sub GetForm(estado As Estado, mensaje As String)
        Dim frm As New Form9
        frm.Label1.Text = mensaje
        If estado = Estado.Ok Then
            frm.PictureBox1.Image = My.Resources.Imagen1
            'ElseIf estado = Estado.Error Then
            'frm.PictureBox1.Image = My.Resources.Error_96px
            'ElseIf estado = Estado.Critical Then
            'frm.PictureBox1.Image = My.Resources.HighPriority_96px
        End If
        frm.Show()
    End Sub
End Module