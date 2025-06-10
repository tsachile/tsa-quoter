Imports System.Runtime.InteropServices
Imports System.Data
Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class Form5
    Dim conexion As New MySqlConnection("Server = 162.144.3.49; Database = tsachile_cotizador; Uid = tsachile_admin; Pwd = 17543593apple")
    Dim cadena As String = "Server = 162.144.3.49; Database = tsachile_cotizador; Uid = tsachile_admin; Pwd = 17543593apple"

#Region "Close and Minimize Form - Cerrar y Minimizar Formulario"
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Application.Exit()
    End Sub

    Private Sub BtnMinimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
#End Region

#Region "Drag Form - Arrastrar/ mover Formulario"

    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub

    Private Sub titleBar_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles titleBar.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
    Private Sub Form5_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
#End Region
#Region "Customize Controls - Personalizar Controles"
    Private Sub CustomizeComponents()
        Txtcontraseña.UseSystemPasswordChar = True
    End Sub
#End Region
    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CustomizeComponents()
        Using conex As New MySqlConnection(cadena)
            Dim user As New MySqlDataAdapter("Select distinct Id, Atencion, Correo, Telefono, Usuario, Contraseña, Iniciales, Prefijo from Usuarios", conex)
            Dim abc As New DataTable("Atencion")
            user.Fill(abc)
            ComboBox1.DataSource = abc
            ComboBox1.DisplayMember = "Atencion"
            ComboBox1.Refresh()
        End Using

        'PARA LIMPIAR CONTROLES 
        ComboBox1.Text = ""
        Txtusuario.Text = ""
        Txtcontraseña.Text = ""

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Txtcontraseña.UseSystemPasswordChar = False
        Else
            Txtcontraseña.UseSystemPasswordChar = True

        End If
    End Sub
#Region "para busqueda de datos de usuario y contraseña"
    Private Sub BtnIngresar_Click(sender As Object, e As EventArgs) Handles BtnIngresar.Click
        If Txtusuario.Text = Nothing Or Txtcontraseña.Text = Nothing Then
            Label3.Visible = True
        Else
            If conexion.State = ConnectionState.Closed Then
                conexion.Open()

            End If
            Dim cmd As New MySqlCommand("SELECT Id,Atencion,Correo,Telefono,Usuario,Contraseña,Iniciales, Prefijo FROM Usuarios WHERE Usuario= '" & Txtusuario.Text & "'  and Contraseña= '" & Txtcontraseña.Text & "'", conexion)
            cmd.Parameters.AddWithValue("@1", MySqlDbType.VarChar).Value = Txtusuario.Text
            cmd.Parameters.AddWithValue("@2", MySqlDbType.VarChar).Value = Txtcontraseña.Text
            Dim reader As MySqlDataReader = cmd.ExecuteReader

            If reader.Read() Then
                Form19.Show()
                Form19.Label2.Text = Convert.ToString(reader("Prefijo"))
                'Form19.Label2.Text = Convert.ToString(reader("Nombre") & " " & reader("Apellido"))

                'Form1.Show()
                Form1.Label4.Visible = True
                Form1.Label1.Visible = True
                Form1.Label2.Visible = True
                Form1.Label3.Visible = True

                Me.Hide()
                'Form1.Label4.Text = Convert.ToString(reader("Iniciales"))
                Form1.Label1.Text = Convert.ToString(reader("Atencion"))
                Form1.Label2.Text = Convert.ToString(reader("Correo"))
                Form1.Label3.Text = Convert.ToString(reader("Telefono"))

            Else
                reader.Close()
                Label1.Visible = True

            End If
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Me.Txtusuario.Text = CType(Me.ComboBox1.DataSource, DataTable).Rows(Me.ComboBox1.SelectedIndex)("Usuario") 'ATENCION DE ENCARGADO
        ' Centrar el texto

    End Sub

#End Region

End Class