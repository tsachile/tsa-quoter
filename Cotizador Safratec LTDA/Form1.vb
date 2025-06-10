Imports System.IO
Imports System.Net
Imports System.Net.WebRequestMethods
Imports System.Runtime.InteropServices
Imports System.Windows.Forms.VisualStyles.VisualStyleElement


Public Class Form1
#Region "FUNCIONALIDADES DEL FORMULARIO"
    'RESIZE DEL FORMULARIO- CAMBIAR TAMAÑO
    Dim cGrip As Integer = 10

    Protected Overrides Sub WndProc(ByRef m As Message)
        If (m.Msg = 132) Then
            Dim pos As Point = New Point((m.LParam.ToInt32 And 65535), (m.LParam.ToInt32 + 16))
            pos = Me.PointToClient(pos)
            If ((pos.X _
                        >= (Me.ClientSize.Width - cGrip)) _
                        AndAlso (pos.Y _
                        >= (Me.ClientSize.Height - cGrip))) Then
                m.Result = CType(17, IntPtr)
                Return
            End If
        End If
        MyBase.WndProc(m)
    End Sub
    '----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
    Dim sizeGripRectangle As Rectangle
    Dim tolerance As Integer = 15

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        MyBase.OnSizeChanged(e)
        Dim region = New Region(New Rectangle(0, 0, Me.ClientRectangle.Width, Me.ClientRectangle.Height))
        sizeGripRectangle = New Rectangle((Me.ClientRectangle.Width - tolerance), (Me.ClientRectangle.Height - tolerance), tolerance, tolerance)
        region.Exclude(sizeGripRectangle)
        Me.PanelContenedor.Region = region
        Me.Invalidate()
    End Sub

    '----------------COLOR Y GRIP DE RECTANGULO INFERIOR
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim blueBrush As SolidBrush = New SolidBrush(Color.FromArgb(244, 244, 244))
        e.Graphics.FillRectangle(blueBrush, sizeGripRectangle)
        MyBase.OnPaint(e)
        ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle)
    End Sub
#End Region

#Region "Movilidad"
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub
#End Region

    Private Sub AbrirFormEnPanel(ByVal Formhijo As Object)

        If Me.PanelContenedor2.Controls.Count > 0 Then Me.PanelContenedor2.Controls.RemoveAt(0)
        Dim fh As Form = TryCast(Formhijo, Form)
        fh.TopLevel = False
        fh.FormBorderStyle = FormBorderStyle.None
        fh.Dock = DockStyle.Fill
        Me.PanelContenedor2.Controls.Add(fh)
        Me.PanelContenedor2.Tag = fh
        fh.Show()

    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Application.Exit()

    End Sub

    Private Sub BtnMaximizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMaximizar.Click
        BtnMaximizar.Visible = False
        BtnRestaurar.Visible = True
        Me.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub BtnRestaurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRestaurar.Click
        BtnRestaurar.Visible = False
        BtnMaximizar.Visible = True
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub BtnMinimizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMinimizar.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PanelBarraTitulo_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanelBarraTitulo.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
    Private Sub BtnMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMenu.Click

        If Panelmenu.Visible = False Then

            Panelmenu.Visible = True
        Else
            Panelmenu.Visible = False
        End If
    End Sub

    Private Sub hidesubmenu()
        PanelCotizacion.Visible = False
        PanelszAMBLED.Visible = False

    End Sub
    Private Sub showsubmenu(ByVal submenu As Panel)
        If submenu.Visible = False Then
            hidesubmenu()
            submenu.Visible = True
        Else
            submenu.Visible = False
        End If
    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        hidesubmenu()
        Timer1.Enabled = True
        AbrirFormEnPanel(New Form16)
        'MEJORAS PARA FORM
        Me.Text = String.Empty
        Me.ControlBox = False
        Me.DoubleBuffered = True
        Me.MaximizedBounds = Screen.PrimaryScreen.WorkingArea

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

    End Sub


    Private Sub BtnCotizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCotizacion.Click
        showsubmenu(PanelCotizacion)
    End Sub

    Public Sub BtnCotizacionSafratec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCotizacionSafratec.Click
        AbrirFormEnPanel(New Form2)
        ' Mostrar todos los elementos en ComboBox
        Form2.ComboBox6.Items.Clear()
        Form2.ComboBox6.Items.Add("CLP")
        Form2.ComboBox6.Items.Add("USD")
        Form2.ComboBox6.Items.Add("EUR")
    End Sub

    Public Sub BtnCotizacionMario_Click(sender As Object, e As EventArgs) Handles BtnCotizacionMario.Click
        AbrirFormEnPanel(New Form2MC)

    End Sub

    Private Sub BtnDataCotizacion_Click(sender As Object, e As EventArgs) Handles BtnDataCotizacion.Click
        AbrirFormEnPanel(New Form25)

    End Sub

    Private Sub BtnUsuario_Click(sender As Object, e As EventArgs) Handles BtnUsuario.Click
        AbrirFormEnPanel(New Form7)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AbrirFormEnPanel(New Form8)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label5.Text = DateTime.Now.ToString("HH:mm:ss")

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AbrirFormEnPanel(New Form11)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        showsubmenu(PanelszAMBLED)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        AbrirFormEnPanel(New Form14)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.GroupBox7.Visible = True
        'frm.Label36.Visible = True
        'frm.TxtUSDEUR.Visible = True
        frm.Label20.Visible = True
        frm.ComboBox1.Visible = True
        frm.ShowDialog()
    End Sub


    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        AbrirFormEnPanel(New Form17)
    End Sub
    Private Sub AbrirFormularioConControles(ByVal Formhijo2 As Object)
        If Me.PanelContenedor2.Controls.Count > 0 Then Me.PanelContenedor2.Controls.RemoveAt(0)
        Dim fh As Form = TryCast(Formhijo2, Form)
        fh.TopLevel = False
        fh.FormBorderStyle = FormBorderStyle.None
        fh.Dock = DockStyle.Fill
        Me.PanelContenedor.Controls.Add(fh)
        Me.PanelContenedor.Tag = fh
        fh.Show()
    End Sub
    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        AbrirFormEnPanel(Form2)
        ' Mostrar solo "EUR" en ComboBox
        Form2.ComboBox6.Items.Clear()
        Form2.ComboBox6.Items.Add("EUR")
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        AbrirFormEnPanel(New Form16)

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        AbrirFormEnPanel(New Form22)
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If WindowState = FormWindowState.Maximized Then
            FormBorderStyle = FormBorderStyle.None
        Else
            FormBorderStyle = FormBorderStyle.Sizable
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        AbrirFormEnPanel(New Form23)
    End Sub

End Class

