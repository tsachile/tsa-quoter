Public Class Form18
    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Me.Close()

    End Sub

    Private Sub Form18_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Obtener la resolución de la pantalla
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height

        ' Escala basada en la resolución de diseño (por ejemplo, 1920x1080)
        Dim baseWidth As Integer = 1920
        Dim baseHeight As Integer = 1080

        Dim scaleFactorX As Double = screenWidth / baseWidth
        Dim scaleFactorY As Double = screenHeight / baseHeight

        ' Escalar el formulario
        Me.Width = CInt(Me.Width * scaleFactorX)
        Me.Height = CInt(Me.Height * scaleFactorY)

        ' Escalar cada control dentro del formulario
        For Each ctrl As Control In Me.Controls
            ctrl.Left = CInt(ctrl.Left * scaleFactorX)
            ctrl.Top = CInt(ctrl.Top * scaleFactorY)
            ctrl.Width = CInt(ctrl.Width * scaleFactorX)
            ctrl.Height = CInt(ctrl.Height * scaleFactorY)
        Next
        Dim razon As String = Me.txtrazon.Text.ToString

        Dim codigo As String = Me.txtcodigo.Text.ToString

        Dim sqli As String = " Select * From INFORMEVENTA Where Razon_Social ='" & razon & "'and Codigo='" & codigo & "' "

        Cargar_MySQL(sqli, DataGridInforme)
        DataGridInforme.Columns(4).DefaultCellStyle.Format = "##0"
        DataGridInforme.Columns(5).DefaultCellStyle.Format = "CLP ##0"
        DataGridInforme.Columns(6).DefaultCellStyle.Format = "CLP ##0"
        DataGridInforme.Columns(7).DefaultCellStyle.Format = "CLP ##0"


    End Sub

    Private Sub DataGridInforme_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub DataGridInforme_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridInforme.CellContentClick

    End Sub
End Class