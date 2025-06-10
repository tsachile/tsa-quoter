Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.Text


Public Class Form2
    Public Function EjecutarConsulta(query As String) As DataTable
        Dim dt As New DataTable()

        Try
            ' Crear conexión y comando SQL
            Using conex As New MySqlConnection("Server=162.144.3.49;Database=tsachile_cotizador;Uid=tsachile_admin;Pwd=17543593apple")
                Using comm As New MySqlCommand(query, conex)
                    ' Adaptador para ejecutar la consulta y llenar el DataTable
                    Using adaptador As New MySqlDataAdapter(comm)
                        conex.Open()
                        adaptador.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error en la consulta: " & ex.Message)
        End Try

        ' Devolver los datos obtenidos
        Return dt
    End Function

    Dim cadena2 As String = "Server = 162.144.3.49; Database = tsachile_cotizador; Uid = tsachile_admin; Pwd = 17543593apple"
    ' Por medio de este objeto voy a enviar todos los comandos de SQL a la tabla por medio de la conexión
    Public comm As New MySqlCommand
    Public conex As New MySqlConnection("Server = 162.144.3.49; Database = tsachile_cotizador; Uid = tsachile_admin; Pwd = 17543593apple")
    ' Cambia esto a tu cadena de conexión a la base de datos MySQL.
    Dim connectionString As String = "Server = 162.144.3.49; Database = tsachile_cotizador; Uid = tsachile_admin; Pwd = 17543593apple"

    Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text > "" Then
            TextBox5.Visible = True
            TextBox6.Visible = True
            NumericUpDown2.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = True
            TextBox143.Visible = True
            TextBox186.Visible = True
            TextBox206.Visible = True
            TextBox53.Visible = True
        End If
    End Sub

    Private Sub TextBox1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox1.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.TxtrazonEspejo.Text = TxtRazon.Text
        frm.TextBox13.Text = TxtUSDEUR.Text
        frm.TextBox14.Text = ComboBox6.Text
        frm.Ok1.Visible = True
        frm.ShowDialog()

    End Sub

    Private Function QuitarTildes(texto As String) As String
        Dim textoNormalizado As String = texto.Normalize(NormalizationForm.FormD)
        Dim resultado As New StringBuilder()

        For Each c As Char In textoNormalizado
            If CharUnicodeInfo.GetUnicodeCategory(c) <> UnicodeCategory.NonSpacingMark Then
                resultado.Append(c)
            End If
        Next

        Return resultado.ToString()
    End Function
    Private Sub Textos_TextChanged(sender As Object, e As EventArgs)
        Dim ctrl = TryCast(sender, Control)
        If ctrl Is Nothing Then Exit Sub

        Dim original = ctrl.Text
        Dim sinTildes = QuitarTildes(original)

        If original <> sinTildes Then
            Dim cursorPos As Integer = 0

            If TypeOf ctrl Is TextBox Then
                cursorPos = DirectCast(ctrl, TextBox).SelectionStart
                ctrl.Text = sinTildes
                DirectCast(ctrl, TextBox).SelectionStart = cursorPos
            ElseIf TypeOf ctrl Is ComboBox Then
                cursorPos = DirectCast(ctrl, ComboBox).SelectionStart
                ctrl.Text = sinTildes
                DirectCast(ctrl, ComboBox).SelectionStart = cursorPos
            End If
        End If
    End Sub
    Private Sub AsignarEventosQuitarTildes(ctrlContainer As Control)
        For Each ctrl As Control In ctrlContainer.Controls
            If TypeOf ctrl Is TextBox OrElse (TypeOf ctrl Is ComboBox AndAlso DirectCast(ctrl, ComboBox).DropDownStyle = ComboBoxStyle.DropDown) Then
                AddHandler ctrl.TextChanged, AddressOf Textos_TextChanged
            End If

            ' Si el control contiene otros controles (como Panel, GroupBox, etc.)
            If ctrl.HasChildren Then
                AsignarEventosQuitarTildes(ctrl)
            End If
        Next
    End Sub


    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Asignar el manejador a todos los TextBox y ComboBox del formulario
        AsignarEventosQuitarTildes(Me)
        'Nuevo evento 
        DGRazonSocial.ColumnHeadersVisible = False
        DGRazonSocial.RowHeadersVisible = False

        ' Desactivar la actualización de la UI para mejorar el rendimiento
        Me.SuspendLayout()

        ' Configuración de las fechas
        TxtCot.Text = Format(Now, "yyyyMMdd")
        TxtFecha.Text = Format(Now, "yyyy/MM/dd")
        TxtRazon.Select()

        ' Usar una sola conexión y adaptador de datos
        Using cnx As New MySqlConnection(cadena2)
            cnx.Open() ' Abre la conexión al principio

            ' Usar un solo MySqlDataAdapter para obtener todos los datos
            Dim consulta As String = "
            SELECT DISTINCT Vendedores, Mail, Telefono, Inicial, Pagina FROM Vendedores;
            SELECT DISTINCT LUGAR_ENTREGA, D_entrega FROM Lugar;
            SELECT DISTINCT condiciones FROM Pago;
            SELECT DISTINCT validez FROM Validez;
            SELECT DISTINCT Trato FROM Trato;
            SELECT DISTINCT Genero FROM Genero;
            SELECT DISTINCT Objetivo FROM Objetivo;
        "

            ' Llenar todas las tablas con el adaptador
            Dim adapter As New MySqlDataAdapter(consulta, cnx)
            Dim ds As New DataSet()
            adapter.Fill(ds)

            ' Asignar los DataTables a los ComboBox correspondientes
            CboContacto.DataSource = ds.Tables(0)
            CboContacto.DisplayMember = "Vendedores"

            CboLugar.DataSource = ds.Tables(1)
            CboLugar.DisplayMember = "LUGAR_ENTREGA"

            Cbopago.DataSource = ds.Tables(2)
            Cbopago.DisplayMember = "condiciones"

            CboValidez.DataSource = ds.Tables(3)
            CboValidez.DisplayMember = "validez"

            ComboBox4.DataSource = ds.Tables(4)
            ComboBox4.DisplayMember = "Trato"

            ComboBox2.DataSource = ds.Tables(5)
            ComboBox2.DisplayMember = "Genero"

            ComboBox3.DataSource = ds.Tables(6)
            ComboBox3.DisplayMember = "Objetivo"

            ' Llenar ComboBox6 con las opciones de moneda
            ComboBox6.Items.Add("CLP")
            ComboBox6.Items.Add("USD")
            ComboBox6.Items.Add("EUR")

            ' Limpiar los ComboBox y TextBox de manera eficiente
            Dim controlsToClear As Control() = {ComboBox1, ComboBox2, ComboBox3, ComboBox4, ComboBox5, ComboBox6,
                                            TxtRazon, CboContacto, CboLugar, Cbopago, CboValidez, TxtWeb, TxtRut,
                                            TxtphoneV, TxtCorreoV, Txtcot2, TxtDireccionEntrega, TxtDireccion,
                                            TxtphoneC, TxtCorreoC, NumericUpDown1, NumericUpDown2, NumericUpDown3,
                                            NumericUpDown4, NumericUpDown5, NumericUpDown6, NumericUpDown7, NumericUpDown8,
                                            NumericUpDown9, NumericUpDown10, NumericUpDown11, NumericUpDown12, NumericUpDown13,
                                            NumericUpDown14, NumericUpDown15, NumericUpDown16, NumericUpDown17, NumericUpDown18,
                                            NumericUpDown19, NumericUpDown20}

            For Each ctrl As Control In controlsToClear
                If TypeOf ctrl Is ComboBox Then
                    CType(ctrl, ComboBox).Text = ""
                ElseIf TypeOf ctrl Is TextBox Then
                    CType(ctrl, TextBox).Text = ""
                ElseIf TypeOf ctrl Is NumericUpDown Then
                    CType(ctrl, NumericUpDown).Value = CType(ctrl, NumericUpDown).Minimum
                End If
            Next

            ' Reactivar la actualización de la UI
            Me.ResumeLayout()

        End Using

        'Para Mayuscula ebn ciertos TEXTBOX
        'TextBox1.CharacterCasing = CharacterCasing.Upper
        TxtRazon.CharacterCasing = CharacterCasing.Upper
        TextBox162.CharacterCasing = CharacterCasing.Upper
        TxtDireccion.CharacterCasing = CharacterCasing.Upper
        TxtReferencia.CharacterCasing = CharacterCasing.Upper
        TxtPlazo.CharacterCasing = CharacterCasing.Upper
        'Texbox solo numero

    End Sub
    Private Sub TxtUSDEUR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtUSDEUR.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)

        ' Permitir solo dígitos, control y un único separador decimal
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso
        (e.KeyChar <> "."c AndAlso e.KeyChar <> ","c) Then

            e.Handled = True
        End If

        ' Evitar múltiples puntos o comas
        If (e.KeyChar = "."c OrElse e.KeyChar = ","c) AndAlso txt.Text.Contains(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub CargarDatos()
        Dim Razon As String = TxtRazon.Text.Trim()

        ' Evita consultar si el texto está vacío
        If Razon = "" Then
            DGRazonSocial.DataSource = Nothing
            Return
        End If

        ' Construcción de la consulta SQL
        Dim sqlcliente As String = "SELECT RUT, Razon_Social FROM Clientes WHERE Razon_Social LIKE '%" & Razon & "%'"

        ' Ejecuta la consulta y asigna los datos al DataGridView
        Cargar_MySQLCliente(sqlcliente, DGRazonSocial)

    End Sub


    Private Sub CboContacto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboContacto.SelectedIndexChanged
        Me.TxtphoneV.Text = CType(Me.CboContacto.DataSource, DataTable).Rows(Me.CboContacto.SelectedIndex)("Telefono") 'TELEFONO VENDEDOR
        Me.TxtCorreoV.Text = CType(Me.CboContacto.DataSource, DataTable).Rows(Me.CboContacto.SelectedIndex)("Mail") 'Correo Vendedor
        Me.TxtWeb.Text = CType(Me.CboContacto.DataSource, DataTable).Rows(Me.CboContacto.SelectedIndex)("Pagina") 'PAGINA WEB
        Me.Txtcot2.Text = CType(Me.CboContacto.DataSource, DataTable).Rows(Me.CboContacto.SelectedIndex)("Inicial") 'INICIAL DE VENDEDOR
    End Sub

    Private Sub CboLugar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboLugar.SelectedIndexChanged
        Me.TxtDireccionEntrega.Text = CType(Me.CboLugar.DataSource, DataTable).Rows(Me.CboLugar.SelectedIndex)("D_entrega") ' Direccion entrega
    End Sub
    Private Sub DGRazonSocial_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGRazonSocial.CellContentClick
        Try
            ' Verificar si hay una fila seleccionada
            If DGRazonSocial.CurrentRow Is Nothing Then Exit Sub

            ' Obtener el índice de la fila actual
            Dim xtreme As Integer = DGRazonSocial.CurrentRow.Index

            ' Verificar si las celdas no están vacías antes de asignar valores
            If DGRazonSocial.Item(0, xtreme).Value IsNot Nothing Then
                TxtRazon.Text = DGRazonSocial.Item(0, xtreme).Value.ToString()
            Else
                TxtRazon.Text = ""
            End If

            If DGRazonSocial.Item(1, xtreme).Value IsNot Nothing Then
                TxtRut.Text = DGRazonSocial.Item(1, xtreme).Value.ToString()
            Else
                TxtRut.Text = ""
            End If

            ' Obtener valores seleccionados
            Dim porrazon As String = TxtRazon.Text.Trim()
            Dim porrut As String = TxtRut.Text.Trim()

            ' Si los valores están vacíos, salir del método
            If String.IsNullOrEmpty(porrazon) OrElse String.IsNullOrEmpty(porrut) Then Exit Sub

            ' Construir consulta SQL sin parámetros
            Dim sql As String = "SELECT DISTINCT Atencion, Direccion, Telefono, Correo, Cargo, Objeto, Tipo, Clase, Genero, Trato FROM Atenciones WHERE Razon_Social = '" & porrazon & "' AND RUT = '" & porrut & "'"

            ' Limpiar TxtAtencion y los demás controles antes de llenar el ComboBox
            TxtAtencion.Text = ""
            TxtDireccion.Text = ""
            TxtphoneC.Text = ""
            TxtCorreoC.Text = ""
            ComboBox4.Text = ""
            TextBox162.Text = ""
            ComboBox2.Text = ""

            ' Llenar el ComboBox con los resultados de la consulta
            LlenarComboBox(sql, TxtAtencion)

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    ' Método para llenar el ComboBox con los resultados de la consulta
    Private Sub LlenarComboBox(query As String, combo As ComboBox)
        Try
            ' Limpiar el DataSource antes de asignar nuevos datos
            combo.DataSource = Nothing

            ' Ejecutar la consulta SQL y obtener resultados
            Dim dt As DataTable = EjecutarConsulta(query)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then Exit Sub

            ' Asignar el DataTable como DataSource para evitar errores
            combo.DataSource = dt
            combo.DisplayMember = "Atencion"
            combo.ValueMember = "Direccion"

            ' Dejar el ComboBox sin selección
            combo.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show("Error al llenar el ComboBox: " & ex.Message)
        End Try
    End Sub

    ' Evento cuando cambia la selección en el ComboBox TxtAtencion
    Private Sub TxtAtencion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TxtAtencion.SelectedIndexChanged
        Try
            ' Verificar si hay una selección válida en el ComboBox
            If TxtAtencion.SelectedIndex >= 0 AndAlso TxtAtencion.DataSource IsNot Nothing Then
                ' Obtener el DataTable del ComboBox
                Dim dt As DataTable = CType(TxtAtencion.DataSource, DataTable)

                ' Llenar los controles con los valores correspondientes
                TxtDireccion.Text = dt.Rows(TxtAtencion.SelectedIndex)("Direccion").ToString()
                TxtphoneC.Text = dt.Rows(TxtAtencion.SelectedIndex)("Telefono").ToString()
                TxtCorreoC.Text = dt.Rows(TxtAtencion.SelectedIndex)("Correo").ToString()
                ComboBox4.Text = dt.Rows(TxtAtencion.SelectedIndex)("Trato").ToString()
                TextBox162.Text = dt.Rows(TxtAtencion.SelectedIndex)("Cargo").ToString()
                ComboBox2.Text = dt.Rows(TxtAtencion.SelectedIndex)("Genero").ToString()
                ComboBox3.Text = dt.Rows(TxtAtencion.SelectedIndex)("Objeto").ToString()
                ComboBox1.Text = dt.Rows(TxtAtencion.SelectedIndex)("Tipo").ToString()
                ComboBox5.Text = dt.Rows(TxtAtencion.SelectedIndex)("Clase").ToString()
            Else
                ' Si no hay selección, dejar los controles en blanco
                TxtDireccion.Text = ""
                TxtphoneC.Text = ""
                TxtCorreoC.Text = ""
                ComboBox4.Text = ""
                TextBox162.Text = ""
                ComboBox2.Text = ""
                ComboBox1.Text = ""
                ComboBox3.Text = ""
                ComboBox5.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show("Error al seleccionar la atención: " & ex.Message)
        End Try
    End Sub


    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        If TextBox5.Text > "" Then
            TextBox9.Visible = True
            TextBox10.Visible = True
            NumericUpDown3.Visible = True
            TextBox11.Visible = True
            TextBox12.Visible = True
            TextBox144.Visible = True
            TextBox187.Visible = True
            TextBox207.Visible = True
            TextBox54.Visible = True
        End If
    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        If TextBox9.Text > "" Then
            TextBox13.Visible = True
            TextBox14.Visible = True
            NumericUpDown4.Visible = True
            TextBox15.Visible = True
            TextBox16.Visible = True
            TextBox145.Visible = True
            TextBox188.Visible = True
            TextBox208.Visible = True
            TextBox55.Visible = True
        End If
    End Sub

    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles TextBox13.TextChanged
        If TextBox13.Text > "" Then
            TextBox17.Visible = True
            TextBox18.Visible = True
            NumericUpDown5.Visible = True
            TextBox19.Visible = True
            TextBox20.Visible = True
            TextBox146.Visible = True
            TextBox189.Visible = True
            TextBox209.Visible = True
            TextBox56.Visible = True
        End If
    End Sub

    Private Sub TextBox17_TextChanged(sender As Object, e As EventArgs) Handles TextBox17.TextChanged
        If TextBox17.Text > "" Then
            TextBox21.Visible = True
            TextBox22.Visible = True
            NumericUpDown6.Visible = True
            TextBox23.Visible = True
            TextBox24.Visible = True
            TextBox147.Visible = True
            TextBox190.Visible = True
            TextBox210.Visible = True
            TextBox57.Visible = True

        End If
    End Sub

    Private Sub TextBox21_TextChanged(sender As Object, e As EventArgs) Handles TextBox21.TextChanged
        If TextBox21.Text > "" Then
            TextBox25.Visible = True
            TextBox26.Visible = True
            NumericUpDown7.Visible = True
            TextBox27.Visible = True
            TextBox28.Visible = True
            TextBox148.Visible = True
            TextBox191.Visible = True
            TextBox211.Visible = True
            TextBox58.Visible = True
        End If
    End Sub

    Private Sub TextBox25_TextChanged(sender As Object, e As EventArgs) Handles TextBox25.TextChanged
        If TextBox25.Text > "" Then
            TextBox29.Visible = True
            TextBox30.Visible = True
            NumericUpDown8.Visible = True
            TextBox31.Visible = True
            TextBox32.Visible = True
            TextBox149.Visible = True
            TextBox192.Visible = True
            TextBox212.Visible = True
            TextBox59.Visible = True
        End If
    End Sub

    Private Sub TextBox29_TextChanged(sender As Object, e As EventArgs) Handles TextBox29.TextChanged
        If TextBox29.Text > "" Then
            TextBox33.Visible = True
            TextBox34.Visible = True
            NumericUpDown9.Visible = True
            TextBox35.Visible = True
            TextBox36.Visible = True
            TextBox150.Visible = True
            TextBox193.Visible = True
            TextBox213.Visible = True
            TextBox60.Visible = True
        End If
    End Sub

    Private Sub TextBox33_TextChanged(sender As Object, e As EventArgs) Handles TextBox33.TextChanged
        If TextBox33.Text > "" Then
            TextBox37.Visible = True
            TextBox38.Visible = True
            NumericUpDown10.Visible = True
            TextBox39.Visible = True
            TextBox40.Visible = True
            TextBox151.Visible = True
            TextBox194.Visible = True
            TextBox214.Visible = True
            TextBox61.Visible = True
        End If
    End Sub


    Private Sub TextBox37_TextChanged(sender As Object, e As EventArgs) Handles TextBox37.TextChanged
        If TextBox37.Text > "" Then
            TextBox62.Visible = True
            TextBox63.Visible = True
            NumericUpDown11.Visible = True
            TextBox64.Visible = True
            TextBox65.Visible = True
            TextBox152.Visible = True
            TextBox195.Visible = True
            TextBox215.Visible = True
            TextBox112.Visible = True

        End If
    End Sub
    Private Sub TextBox62_TextChanged(sender As Object, e As EventArgs) Handles TextBox62.TextChanged
        If TextBox62.Text > "" Then
            TextBox66.Visible = True
            TextBox67.Visible = True
            NumericUpDown12.Visible = True
            TextBox68.Visible = True
            TextBox69.Visible = True
            TextBox153.Visible = True
            TextBox196.Visible = True
            TextBox216.Visible = True
            TextBox113.Visible = True
        End If
    End Sub
    Private Sub TextBox66_TextChanged(sender As Object, e As EventArgs) Handles TextBox66.TextChanged
        If TextBox66.Text > "" Then
            TextBox70.Visible = True
            TextBox71.Visible = True
            NumericUpDown13.Visible = True
            TextBox72.Visible = True
            TextBox73.Visible = True
            TextBox154.Visible = True
            TextBox197.Visible = True
            TextBox217.Visible = True
            TextBox114.Visible = True
        End If
    End Sub
    Private Sub TextBox70_TextChanged(sender As Object, e As EventArgs) Handles TextBox70.TextChanged
        If TextBox70.Text > "" Then
            TextBox74.Visible = True
            TextBox75.Visible = True
            NumericUpDown14.Visible = True
            TextBox76.Visible = True
            TextBox77.Visible = True
            TextBox155.Visible = True
            TextBox198.Visible = True
            TextBox218.Visible = True
            TextBox115.Visible = True
        End If
    End Sub
    Private Sub TextBox74_TextChanged(sender As Object, e As EventArgs) Handles TextBox74.TextChanged
        If TextBox74.Text > "" Then
            TextBox78.Visible = True
            TextBox79.Visible = True
            NumericUpDown15.Visible = True
            TextBox80.Visible = True
            TextBox81.Visible = True
            TextBox156.Visible = True
            TextBox199.Visible = True
            TextBox219.Visible = True
            TextBox116.Visible = True
        End If
    End Sub
    Private Sub TextBox78_TextChanged(sender As Object, e As EventArgs) Handles TextBox78.TextChanged
        If TextBox78.Text > "" Then
            TextBox82.Visible = True
            TextBox83.Visible = True
            NumericUpDown16.Visible = True
            TextBox84.Visible = True
            TextBox85.Visible = True
            TextBox157.Visible = True
            TextBox200.Visible = True
            TextBox220.Visible = True
            TextBox117.Visible = True
        End If
    End Sub
    Private Sub TextBox82_TextChanged(sender As Object, e As EventArgs) Handles TextBox82.TextChanged
        If TextBox82.Text > "" Then
            TextBox86.Visible = True
            TextBox87.Visible = True
            NumericUpDown17.Visible = True
            TextBox88.Visible = True
            TextBox89.Visible = True
            TextBox158.Visible = True
            TextBox201.Visible = True
            TextBox221.Visible = True
            TextBox118.Visible = True
        End If
    End Sub
    Private Sub TextBox86_TextChanged(sender As Object, e As EventArgs) Handles TextBox86.TextChanged
        If TextBox86.Text > "" Then
            TextBox90.Visible = True
            TextBox91.Visible = True
            NumericUpDown18.Visible = True
            TextBox92.Visible = True
            TextBox93.Visible = True
            TextBox159.Visible = True
            TextBox202.Visible = True
            TextBox222.Visible = True
            TextBox119.Visible = True
        End If
    End Sub
    Private Sub TextBox90_TextChanged(sender As Object, e As EventArgs) Handles TextBox90.TextChanged
        If TextBox90.Text > "" Then
            TextBox94.Visible = True
            TextBox95.Visible = True
            NumericUpDown19.Visible = True
            TextBox96.Visible = True
            TextBox97.Visible = True
            TextBox160.Visible = True
            TextBox203.Visible = True
            TextBox223.Visible = True
            TextBox120.Visible = True
        End If
    End Sub
    Private Sub TextBox94_TextChanged(sender As Object, e As EventArgs) Handles TextBox94.TextChanged
        If TextBox94.Text > "" Then
            TextBox98.Visible = True
            TextBox99.Visible = True
            NumericUpDown20.Visible = True
            TextBox100.Visible = True
            TextBox101.Visible = True
            TextBox161.Visible = True
            TextBox204.Visible = True
            TextBox224.Visible = True
            TextBox121.Visible = True
        End If
    End Sub
    Private Sub TextBox5_Click(sender As Object, e As EventArgs) Handles TextBox5.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.TxtrazonEspejo.Text = TxtRazon.Text
        frm.TextBox13.Text = TxtUSDEUR.Text
        frm.TextBox14.Text = ComboBox6.Text
        frm.Ok2.Visible = True
        frm.ShowDialog()
    End Sub
    Private Sub TextBox9_Click(sender As Object, e As EventArgs) Handles TextBox9.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.TxtrazonEspejo.Text = TxtRazon.Text
        frm.TextBox13.Text = TxtUSDEUR.Text
        frm.TextBox14.Text = ComboBox6.Text
        frm.Ok3.Visible = True
        frm.ShowDialog()
    End Sub

    Private Sub TextBox13_Click(sender As Object, e As EventArgs) Handles TextBox13.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.TxtrazonEspejo.Text = TxtRazon.Text
        frm.TextBox13.Text = TxtUSDEUR.Text
        frm.TextBox14.Text = ComboBox6.Text
        frm.Ok4.Visible = True
        frm.ShowDialog()
    End Sub
    Private Sub TextBox17_Click(sender As Object, e As EventArgs) Handles TextBox17.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.TxtrazonEspejo.Text = TxtRazon.Text
        frm.TextBox13.Text = TxtUSDEUR.Text
        frm.TextBox14.Text = ComboBox6.Text
        frm.Ok5.Visible = True
        frm.ShowDialog()
    End Sub

    Private Sub TextBox21_Click(sender As Object, e As EventArgs) Handles TextBox21.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.TxtrazonEspejo.Text = TxtRazon.Text
        frm.TextBox13.Text = TxtUSDEUR.Text
        frm.TextBox14.Text = ComboBox6.Text
        frm.Ok6.Visible = True
        frm.ShowDialog()
    End Sub

    Private Sub TextBox25_Click(sender As Object, e As EventArgs) Handles TextBox25.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.TxtrazonEspejo.Text = TxtRazon.Text
        frm.TextBox13.Text = TxtUSDEUR.Text
        frm.TextBox14.Text = ComboBox6.Text
        frm.Ok7.Visible = True
        frm.ShowDialog()
    End Sub

    Private Sub TextBox29_Click(sender As Object, e As EventArgs) Handles TextBox29.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.TxtrazonEspejo.Text = TxtRazon.Text
        frm.TextBox13.Text = TxtUSDEUR.Text
        frm.TextBox14.Text = ComboBox6.Text
        frm.Ok8.Visible = True
        frm.ShowDialog()
    End Sub

    Private Sub TextBox33_Click(sender As Object, e As EventArgs) Handles TextBox33.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.TxtrazonEspejo.Text = TxtRazon.Text
        frm.TextBox13.Text = TxtUSDEUR.Text
        frm.TextBox14.Text = ComboBox6.Text
        frm.Ok9.Visible = True
        frm.ShowDialog()
    End Sub
    Private Sub TextBox37_Click(sender As Object, e As EventArgs) Handles TextBox37.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.TxtrazonEspejo.Text = TxtRazon.Text
        frm.TextBox13.Text = TxtUSDEUR.Text
        frm.TextBox14.Text = ComboBox6.Text
        frm.Ok10.Visible = True
        frm.ShowDialog()
    End Sub
    Private Sub TextBox62_Click(sender As Object, e As EventArgs) Handles TextBox62.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.TxtrazonEspejo.Text = TxtRazon.Text
        frm.TextBox13.Text = TxtUSDEUR.Text
        frm.TextBox14.Text = ComboBox6.Text
        frm.Ok11.Visible = True
        frm.ShowDialog()
    End Sub
    Private Sub TextBox66_Click(sender As Object, e As EventArgs) Handles TextBox66.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.TxtrazonEspejo.Text = TxtRazon.Text
        frm.TextBox13.Text = TxtUSDEUR.Text
        frm.TextBox14.Text = ComboBox6.Text
        frm.Ok12.Visible = True
        frm.ShowDialog()
    End Sub
    Private Sub TextBox70_Click(sender As Object, e As EventArgs) Handles TextBox70.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.TxtrazonEspejo.Text = TxtRazon.Text
        frm.TextBox13.Text = TxtUSDEUR.Text
        frm.TextBox14.Text = ComboBox6.Text
        frm.Ok13.Visible = True
        frm.ShowDialog()
    End Sub
    Private Sub TextBox74_Click(sender As Object, e As EventArgs) Handles TextBox74.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.TxtrazonEspejo.Text = TxtRazon.Text
        frm.TextBox13.Text = TxtUSDEUR.Text
        frm.TextBox14.Text = ComboBox6.Text
        frm.Ok14.Visible = True
        frm.ShowDialog()
    End Sub
    Private Sub TextBox78_Click(sender As Object, e As EventArgs) Handles TextBox78.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.TxtrazonEspejo.Text = TxtRazon.Text
        frm.TextBox13.Text = TxtUSDEUR.Text
        frm.TextBox14.Text = ComboBox6.Text
        frm.Ok15.Visible = True
        frm.ShowDialog()
    End Sub
    Private Sub TextBox82_Click(sender As Object, e As EventArgs) Handles TextBox82.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.TxtrazonEspejo.Text = TxtRazon.Text
        frm.TextBox13.Text = TxtUSDEUR.Text
        frm.TextBox14.Text = ComboBox6.Text
        frm.Ok16.Visible = True
        frm.ShowDialog()
    End Sub
    Private Sub TextBox86_Click(sender As Object, e As EventArgs) Handles TextBox86.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.TxtrazonEspejo.Text = TxtRazon.Text
        frm.TextBox13.Text = TxtUSDEUR.Text
        frm.TextBox14.Text = ComboBox6.Text
        frm.Ok17.Visible = True
        frm.ShowDialog()
    End Sub
    Private Sub TextBox90_Click(sender As Object, e As EventArgs) Handles TextBox90.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.TxtrazonEspejo.Text = TxtRazon.Text
        frm.TextBox13.Text = TxtUSDEUR.Text
        frm.TextBox14.Text = ComboBox6.Text
        frm.Ok18.Visible = True
        frm.ShowDialog()
    End Sub
    Private Sub TextBox94_Click(sender As Object, e As EventArgs) Handles TextBox94.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.TxtrazonEspejo.Text = TxtRazon.Text
        frm.TextBox13.Text = TxtUSDEUR.Text
        frm.TextBox14.Text = ComboBox6.Text
        frm.Ok19.Visible = True
        frm.ShowDialog()
    End Sub
    Private Sub TextBox98_Click(sender As Object, e As EventArgs) Handles TextBox98.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.TxtrazonEspejo.Text = TxtRazon.Text
        frm.TextBox13.Text = TxtUSDEUR.Text
        frm.TextBox14.Text = ComboBox6.Text
        frm.ok20.Visible = True
        frm.ShowDialog()
    End Sub
#Region "Para exportar @ SAFRATEC"
    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportarCLP.Click
        Dim xlibro As Microsoft.Office.Interop.Excel.Application
        Dim strRutaExcel As String

        strRutaExcel = "C:\SOURCESAFRATEC\Planilla de Cotizacion.xlsm"

        xlibro = CreateObject("Excel.Application")
        xlibro.Workbooks.Open(strRutaExcel)

        'Activamos el libro
        xlibro.Workbooks("Planilla de Cotizacion.xlsm").Activate()

        'Activamos la hoja especifica del libro  
        xlibro.Sheets("Planilla de Cotizacion (CLP)").Select()

        Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = xlibro.Sheets.Item("Planilla de Cotizacion (CLP)")
        xlibro.Visible = True

        'Ahora podemos llevar el contenido de un textbox a una celda de excel expecifica copn la siguiente instrucción
        If TxtRazon.Text <> "" Then xlibro.Range("D15").Value = TxtRazon.Text 'Razon social
        If TxtAtencion.Text <> "" Then xlibro.Range("D16").Value = TxtAtencion.Text 'Atencion
        If TxtRut.Text <> "" Then xlibro.Range("D17").Value = TxtRut.Text 'RUT
        If TxtDireccion.Text <> "" Then xlibro.Range("D18").Value = TxtDireccion.Text 'Direccion 
        If TxtphoneC.Text <> "" Then xlibro.Range("D19").Value = TxtphoneC.Text 'Telefono cliente
        If TxtCorreoC.Text <> "" Then xlibro.Range("D20").Value = TxtCorreoC.Text ' Correo de Cliente

        If TxtCot.Text <> "" And Txtcot2.Text <> "" And Txtcot3.Text <> "" Then
            xlibro.Range("H10").Value = "TSA - " + TxtCot.Text + Txtcot2.Text + Txtcot3.Text '# de Cotizacion
        End If

        If TxtFecha.Text <> "" Then xlibro.Range("I16").Value = TxtFecha.Text ' Fecha del Dia
        If CboContacto.Text <> "" Then xlibro.Range("I17").Value = CboContacto.Text 'Vendedor
        If TxtCorreoV.Text <> "" Then xlibro.Range("I18").Value = TxtCorreoV.Text 'Correo de Vendedor
        If TxtWeb.Text <> "" Then xlibro.Range("I19").Value = TxtWeb.Text 'Pagina web
        If TxtphoneV.Text <> "" Then xlibro.Range("I20").Value = TxtphoneV.Text 'Telefono vendedor

        If TxtReferencia.Text <> "" Then xlibro.Range("D21").Value = TxtReferencia.Text 'Referencia 

        ' Para primera linea activa de Materiales
        If TextBox1.Text <> "" Then xlibro.Range("D24").Value = TextBox1.Text 'Descripcion de Materiales
        If TextBox2.Text <> "" Then xlibro.Range("C24").Value = TextBox2.Text 'Codigo del Material
        If NumericUpDown1.Text <> "0" And NumericUpDown1.Text <> "" Then xlibro.Range("H24").Value = NumericUpDown1.Text 'Cantidad del Material
        If TextBox41.Text <> "" Then xlibro.Range("M24").Value = TextBox41.Text 'Costo de Defontana
        If TextBox3.Text <> "" Then xlibro.Range("N24").Value = TextBox3.Text 'Margen (%)
        If TextBox122.Text <> "" Then xlibro.Range("O24").Value = TextBox122.Text 'Para costo de Reposicion articulos de GSI

        ' 2 linea de Materiales
        If TextBox5.Text <> "" Then xlibro.Range("D25").Value = TextBox5.Text 'Descripcion de Materiales
        If TextBox6.Text <> "" Then xlibro.Range("C25").Value = TextBox6.Text 'Codigo del Material
        If NumericUpDown2.Text <> "0" And NumericUpDown2.Text <> "" Then xlibro.Range("H25").Value = NumericUpDown2.Text 'Cantidad del Material
        If TextBox42.Text <> "" Then xlibro.Range("M25").Value = TextBox42.Text 'Costo de Defontana
        If TextBox7.Text <> "" Then xlibro.Range("N25").Value = TextBox7.Text 'Margen (%)
        If TextBox123.Text <> "" Then xlibro.Range("O25").Value = TextBox123.Text 'Para costo de Reposicion articulos de GSI

        ' 3 linea de Materiales
        If TextBox9.Text <> "" Then xlibro.Range("D26").Value = TextBox9.Text 'Descripcion de Materiales
        If TextBox10.Text <> "" Then xlibro.Range("C26").Value = TextBox10.Text 'Codigo del Material
        If NumericUpDown3.Text <> "0" And NumericUpDown3.Text <> "" Then xlibro.Range("H26").Value = NumericUpDown3.Text 'Cantidad del Material
        If TextBox43.Text <> "" Then xlibro.Range("M26").Value = TextBox43.Text 'Costo de Defontana
        If TextBox11.Text <> "" Then xlibro.Range("N26").Value = TextBox11.Text 'Margen (%)
        If TextBox124.Text <> "" Then xlibro.Range("O26").Value = TextBox124.Text 'Para costo de Reposicion articulos de GSI

        ' 4 linea de Materiales
        If TextBox13.Text <> "" Then xlibro.Range("D27").Value = TextBox13.Text 'Descripcion de Materiales
        If TextBox14.Text <> "" Then xlibro.Range("C27").Value = TextBox14.Text 'Codigo del Material
        If NumericUpDown4.Text <> "0" And NumericUpDown4.Text <> "" Then xlibro.Range("H27").Value = NumericUpDown4.Text 'Cantidad del Material
        If TextBox44.Text <> "" Then xlibro.Range("M27").Value = TextBox44.Text 'Costo de Defontana
        If TextBox15.Text <> "" Then xlibro.Range("N27").Value = TextBox15.Text 'Margen (%)
        If TextBox125.Text <> "" Then xlibro.Range("O27").Value = TextBox125.Text 'Para costo de Reposicion articulos de GSI

        ' 5 linea de Materiales
        If TextBox17.Text <> "" Then xlibro.Range("D28").Value = TextBox17.Text 'Descripcion de Materiales
        If TextBox18.Text <> "" Then xlibro.Range("C28").Value = TextBox18.Text 'Codigo del Material
        If NumericUpDown5.Text <> "0" And NumericUpDown5.Text <> "" Then xlibro.Range("H28").Value = NumericUpDown5.Text 'Cantidad del Material
        If TextBox45.Text <> "" Then xlibro.Range("M28").Value = TextBox45.Text 'Costo de Defontana
        If TextBox19.Text <> "" Then xlibro.Range("N28").Value = TextBox19.Text 'Margen (%)
        If TextBox126.Text <> "" Then xlibro.Range("O28").Value = TextBox126.Text 'Para costo de Reposicion articulos de GSI

        ' 6 linea de Materiales
        If TextBox21.Text <> "" Then xlibro.Range("D29").Value = TextBox21.Text 'Descripcion de Materiales
        If TextBox22.Text <> "" Then xlibro.Range("C29").Value = TextBox22.Text 'Codigo del Material
        If NumericUpDown6.Text <> "0" And NumericUpDown6.Text <> "" Then xlibro.Range("H29").Value = NumericUpDown6.Text 'Cantidad del Material
        If TextBox46.Text <> "" Then xlibro.Range("M29").Value = TextBox46.Text 'Costo de Defontana
        If TextBox23.Text <> "" Then xlibro.Range("N29").Value = TextBox23.Text 'Margen (%)
        If TextBox127.Text <> "" Then xlibro.Range("O29").Value = TextBox127.Text 'Para costo de Reposicion articulos de GSI

        ' 7 linea de Materiales
        If TextBox25.Text <> "" Then xlibro.Range("D30").Value = TextBox25.Text 'Descripcion de Materiales
        If TextBox26.Text <> "" Then xlibro.Range("C30").Value = TextBox26.Text 'Codigo del Material
        If NumericUpDown7.Text <> "0" And NumericUpDown7.Text <> "" Then xlibro.Range("H30").Value = NumericUpDown7.Text 'Cantidad del Material
        If TextBox47.Text <> "" Then xlibro.Range("M30").Value = TextBox47.Text 'Costo de Defontana
        If TextBox27.Text <> "" Then xlibro.Range("N30").Value = TextBox27.Text 'Margen (%)
        If TextBox128.Text <> "" Then xlibro.Range("O30").Value = TextBox128.Text 'Para costo de Reposicion articulos de GSI

        ' 8 Linea de Materiales
        If TextBox29.Text <> "" Then xlibro.Range("D31").Value = TextBox29.Text 'Descripcion de Materiales
        If TextBox30.Text <> "" Then xlibro.Range("C31").Value = TextBox30.Text 'Codigo del Material
        If NumericUpDown8.Text <> "0" And NumericUpDown8.Text <> "" Then xlibro.Range("H31").Value = NumericUpDown8.Text 'Cantidad del Material
        If TextBox48.Text <> "" Then xlibro.Range("M31").Value = TextBox48.Text 'Costo de Defontana
        If TextBox31.Text <> "" Then xlibro.Range("N31").Value = TextBox31.Text 'Margen (%)
        If TextBox129.Text <> "" Then xlibro.Range("O31").Value = TextBox129.Text 'Para costo de Reposicion articulos de GSI

        ' 9 linea de Materiales
        If TextBox33.Text <> "" Then xlibro.Range("D32").Value = TextBox33.Text 'Descripcion de Materiales
        If TextBox34.Text <> "" Then xlibro.Range("C32").Value = TextBox34.Text 'Codigo del Material
        If NumericUpDown9.Text <> "0" And NumericUpDown9.Text <> "" Then xlibro.Range("H32").Value = NumericUpDown9.Text 'Cantidad del Material
        If TextBox49.Text <> "" Then xlibro.Range("M32").Value = TextBox49.Text 'Costo de Defontana
        If TextBox35.Text <> "" Then xlibro.Range("N32").Value = TextBox35.Text 'Margen (%)
        If TextBox130.Text <> "" Then xlibro.Range("O32").Value = TextBox130.Text 'Para costo de Reposicion articulos de GSI

        ' 10 Linea de Materiales
        If TextBox37.Text <> "" Then xlibro.Range("D33").Value = TextBox37.Text 'Descripcion de Materiales
        If TextBox38.Text <> "" Then xlibro.Range("C33").Value = TextBox38.Text 'Codigo del Material
        If NumericUpDown10.Text <> "0" And NumericUpDown10.Text <> "" Then xlibro.Range("H33").Value = NumericUpDown10.Text 'Cantidad del Material
        If TextBox50.Text <> "" Then xlibro.Range("M33").Value = TextBox50.Text 'Costo de Defontana
        If TextBox39.Text <> "" Then xlibro.Range("N33").Value = TextBox39.Text 'Margen (%)
        If TextBox131.Text <> "" Then xlibro.Range("O33").Value = TextBox131.Text 'Para costo de Reposicion articulos de GSI

        ' 11 Linea de Materiales
        If TextBox62.Text <> "" Then xlibro.Range("D34").Value = TextBox62.Text 'Descripcion de Materiales
        If TextBox63.Text <> "" Then xlibro.Range("C34").Value = TextBox63.Text 'Codigo del Material
        If NumericUpDown11.Text <> "0" And NumericUpDown11.Text <> "" Then xlibro.Range("H34").Value = NumericUpDown11.Text 'Cantidad del Material
        If TextBox102.Text <> "" Then xlibro.Range("M34").Value = TextBox102.Text 'Costo de Defontana
        If TextBox64.Text <> "" Then xlibro.Range("N34").Value = TextBox64.Text 'Margen (%)
        If TextBox112.Text <> "" Then xlibro.Range("J34").Value = TextBox112.Text 'Total
        If TextBox132.Text <> "" Then xlibro.Range("O34").Value = TextBox132.Text 'Para costo de Reposicion articulos de GSI

        ' 12 Linea de Materiales
        If TextBox66.Text <> "" Then xlibro.Range("D35").Value = TextBox66.Text 'Descripcion de Materiales
        If TextBox67.Text <> "" Then xlibro.Range("C35").Value = TextBox67.Text 'Codigo del Material
        If NumericUpDown12.Text <> "0" And NumericUpDown12.Text <> "" Then xlibro.Range("H35").Value = NumericUpDown12.Text 'Cantidad del Material
        If TextBox103.Text <> "" Then xlibro.Range("M35").Value = TextBox103.Text 'Costo de Defontana
        If TextBox68.Text <> "" Then xlibro.Range("N35").Value = TextBox68.Text 'Margen (%)
        If TextBox133.Text <> "" Then xlibro.Range("O35").Value = TextBox133.Text 'Para costo de Reposicion articulos de GSI

        ' 13 Linea de Materiales 
        If TextBox70.Text <> "" Then xlibro.Range("D36").Value = TextBox70.Text 'Descripcion de Materiales
        If TextBox71.Text <> "" Then xlibro.Range("C36").Value = TextBox71.Text 'Codigo del Material
        If NumericUpDown13.Text <> "0" And NumericUpDown13.Text <> "" Then xlibro.Range("H36").Value = NumericUpDown13.Text 'Cantidad del Material
        If TextBox104.Text <> "" Then xlibro.Range("M36").Value = TextBox104.Text 'Costo de Defontana
        If TextBox72.Text <> "" Then xlibro.Range("N36").Value = TextBox72.Text 'Margen (%)
        If TextBox114.Text <> "" Then xlibro.Range("J36").Value = TextBox114.Text 'Total
        If TextBox134.Text <> "" Then xlibro.Range("O36").Value = TextBox134.Text 'Para costo de Reposicion articulos de GSI

        ' 14 Linea de Materiales
        If TextBox74.Text <> "" Then xlibro.Range("D37").Value = TextBox74.Text 'Descripcion de Materiales
        If TextBox75.Text <> "" Then xlibro.Range("C37").Value = TextBox75.Text 'Codigo del Material
        If NumericUpDown14.Text <> "0" And NumericUpDown14.Text <> "" Then xlibro.Range("H37").Value = NumericUpDown14.Text 'Cantidad del Material
        If TextBox105.Text <> "" Then xlibro.Range("M37").Value = TextBox105.Text 'Costo de Defontana
        If TextBox76.Text <> "" Then xlibro.Range("N37").Value = TextBox76.Text 'Margen (%)
        If TextBox135.Text <> "" Then xlibro.Range("O37").Value = TextBox135.Text 'Para costo de Reposicion articulos de GSI

        ' 15 Linea de Materiales
        If TextBox78.Text <> "" Then xlibro.Range("D38").Value = TextBox78.Text 'Descripcion de Materiales
        If TextBox79.Text <> "" Then xlibro.Range("C38").Value = TextBox79.Text 'Codigo del Material
        If NumericUpDown15.Text <> "0" And NumericUpDown15.Text <> "" Then xlibro.Range("H38").Value = NumericUpDown15.Text 'Cantidad del Materia
        If TextBox106.Text <> "" Then xlibro.Range("M38").Value = TextBox106.Text 'Costo de Defontana
        If TextBox80.Text <> "" Then xlibro.Range("N38").Value = TextBox80.Text 'Margen (%)
        If TextBox136.Text <> "" Then xlibro.Range("O38").Value = TextBox136.Text 'Para costo de Reposicion articulos de GSI

        ' 16 Linea de Materiales
        If TextBox82.Text <> "" Then xlibro.Range("D39").Value = TextBox82.Text 'Descripcion de Materiales
        If TextBox83.Text <> "" Then xlibro.Range("C39").Value = TextBox83.Text 'Codigo del Material
        If NumericUpDown16.Text <> "0" And NumericUpDown16.Text <> "" Then xlibro.Range("H39").Value = NumericUpDown16.Text 'Cantidad del Material
        If TextBox107.Text <> "" Then xlibro.Range("M39").Value = TextBox107.Text 'Costo de Defontana
        If TextBox84.Text <> "" Then xlibro.Range("N39").Value = TextBox84.Text 'Margen (%)
        If TextBox137.Text <> "" Then xlibro.Range("O39").Value = TextBox137.Text 'Para costo de Reposicion articulos de GSI

        ' 17 Linea de Materiales
        If TextBox86.Text <> "" Then xlibro.Range("D40").Value = TextBox86.Text 'Descripcion de Materiales
        If TextBox87.Text <> "" Then xlibro.Range("C40").Value = TextBox87.Text 'Codigo del Material
        If NumericUpDown17.Text <> "0" And NumericUpDown17.Text <> "" Then xlibro.Range("H40").Value = NumericUpDown17.Text 'Cantidad del Material
        If TextBox108.Text <> "" Then xlibro.Range("M40").Value = TextBox108.Text 'Costo de Defontana
        If TextBox88.Text <> "" Then xlibro.Range("N40").Value = TextBox88.Text 'Margen (%)
        If TextBox138.Text <> "" Then xlibro.Range("O40").Value = TextBox138.Text 'Para costo de Reposicion articulos de GSI

        ' 18 Linea de Materiales
        If TextBox90.Text <> "" Then xlibro.Range("D41").Value = TextBox90.Text 'Descripcion de Materiales
        If TextBox91.Text <> "" Then xlibro.Range("C41").Value = TextBox91.Text 'Codigo del Material
        If NumericUpDown18.Text <> "0" And NumericUpDown18.Text <> "" Then xlibro.Range("H41").Value = NumericUpDown18.Text 'Cantidad del Material
        If TextBox109.Text <> "" Then xlibro.Range("M41").Value = TextBox109.Text 'Costo de Defontana
        If TextBox92.Text <> "" Then xlibro.Range("N41").Value = TextBox92.Text 'Margen (%)
        If TextBox139.Text <> "" Then xlibro.Range("O41").Value = TextBox139.Text 'Para costo de Reposicion articulos de GSI

        ' 19 Linea de Materiales
        If TextBox94.Text <> "" Then xlibro.Range("D42").Value = TextBox94.Text 'Descripcion de Materiales
        If TextBox95.Text <> "" Then xlibro.Range("C42").Value = TextBox95.Text 'Codigo del Material
        If NumericUpDown19.Text <> "0" And NumericUpDown19.Text <> "" Then xlibro.Range("H42").Value = NumericUpDown19.Text 'Cantidad del Material
        If TextBox110.Text <> "" Then xlibro.Range("M42").Value = TextBox110.Text 'Costo de Defontana
        If TextBox96.Text <> "" Then xlibro.Range("N42").Value = TextBox96.Text 'Margen (%)
        If TextBox140.Text <> "" Then xlibro.Range("O42").Value = TextBox140.Text 'Para costo de Reposicion articulos de GSI

        ' 20 Linea de Materiales
        If TextBox98.Text <> "" Then xlibro.Range("D43").Value = TextBox98.Text 'Descripcion de Materiales
        If TextBox99.Text <> "" Then xlibro.Range("C43").Value = TextBox99.Text 'Codigo del Material
        If NumericUpDown20.Text <> "0" And NumericUpDown20.Text <> "" Then xlibro.Range("H43").Value = NumericUpDown20.Text 'Cantidad del Material
        If TextBox111.Text <> "" Then xlibro.Range("M43").Value = TextBox111.Text 'Costo de Defontana
        If TextBox100.Text <> "" Then xlibro.Range("N43").Value = TextBox100.Text 'Margen (%)
        If TextBox141.Text <> "" Then xlibro.Range("O43").Value = TextBox141.Text 'Para costo de Reposicion articulos de GSI

        ' Final de la escritura en Excel.
        If CboLugar.Text <> "" Then xlibro.Range("D54").Value = CboLugar.Text
        If TxtPlazo.Text <> "" Then xlibro.Range("D55").Value = TxtPlazo.Text
        If Cbopago.Text <> "" Then xlibro.Range("D56").Value = Cbopago.Text
        If CboValidez.Text <> "" Then xlibro.Range("D57").Value = CboValidez.Text


    End Sub
    Private Sub BtnExportarUSD_Click(sender As Object, e As EventArgs) Handles BtnExportarUSD.Click
        Dim xlibro As Microsoft.Office.Interop.Excel.Application
        Dim strRutaExcel As String

        strRutaExcel = "C:\SOURCESAFRATEC\Planilla de Cotizacion.xlsm"

        xlibro = CreateObject("Excel.Application")
        xlibro.Workbooks.Open(strRutaExcel)

        'Activamos el libro
        xlibro.Workbooks("Planilla de Cotizacion.xlsm").Activate()

        'Activamos la hoja especifica del libro  
        xlibro.Sheets("Planilla de Cotizacion (USD)").Select()

        Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = xlibro.Sheets.Item("Planilla de Cotizacion (USD)")
        xlibro.Visible = True

        'Ahora podemos llevar el contenido de un textbox a una celda de excel expecifica copn la siguiente instrucción

        If TxtRazon.Text <> "" Then xlibro.Range("D15").Value = TxtRazon.Text 'Razon social
        If TxtAtencion.Text <> "" Then xlibro.Range("D16").Value = TxtAtencion.Text 'Atencion
        If TxtRut.Text <> "" Then xlibro.Range("D17").Value = TxtRut.Text 'RUT
        If TxtDireccion.Text <> "" Then xlibro.Range("D18").Value = TxtDireccion.Text 'Direccion
        If TxtphoneC.Text <> "" Then xlibro.Range("D19").Value = TxtphoneC.Text 'Telefono cliente
        If TxtCorreoC.Text <> "" Then xlibro.Range("D20").Value = TxtCorreoC.Text ' Correo de Cliente

        If TxtCot.Text <> "" Then xlibro.Range("H10").Value = "TSA - " + TxtCot.Text + Txtcot2.Text + Txtcot3.Text '# de Cotizacion
        If TxtFecha.Text <> "" Then xlibro.Range("I16").Value = TxtFecha.Text ' Fecha del Dia

        If CboContacto.Text <> "" Then xlibro.Range("I17").Value = CboContacto.Text 'Vendedor
        If TxtCorreoV.Text <> "" Then xlibro.Range("I18").Value = TxtCorreoV.Text 'Correo de Vendedor
        If TxtWeb.Text <> "" Then xlibro.Range("I19").Value = TxtWeb.Text 'Pagina web
        If TxtphoneV.Text <> "" Then xlibro.Range("I20").Value = TxtphoneV.Text 'Telefono vendedor

        If TxtReferencia.Text <> "" Then xlibro.Range("D21").Value = TxtReferencia.Text 'Referencia

        ' Para primera linea activa de Materiales
        If TextBox1.Text <> "" Then xlibro.Range("D24").Value = TextBox1.Text 'Descripcion de Materiales
        If TextBox2.Text <> "" Then xlibro.Range("C24").Value = TextBox2.Text 'Codigo del Material
        If NumericUpDown1.Text <> "0" And NumericUpDown1.Text <> "" Then xlibro.Range("H24").Value = NumericUpDown1.Text 'Cantidad del Material
        If TextBox41.Text <> "" Then xlibro.Range("M24").Value = TextBox41.Text 'Costo de Defontana
        If TextBox3.Text <> "" Then xlibro.Range("N24").Value = TextBox3.Text 'Margen (%)
        If TextBox122.Text <> "" Then xlibro.Range("O24").Value = TextBox122.Text 'Para costo de Reposicion articulos de GSI

        ' 2 linea de Materiales
        If TextBox5.Text <> "" Then xlibro.Range("D25").Value = TextBox5.Text 'Descripcion de Materiales
        If TextBox6.Text <> "" Then xlibro.Range("C25").Value = TextBox6.Text 'Codigo del Material
        If NumericUpDown2.Text <> "0" And NumericUpDown2.Text <> "" Then xlibro.Range("H25").Value = NumericUpDown2.Text 'Cantidad del Material
        If TextBox42.Text <> "" Then xlibro.Range("M25").Value = TextBox42.Text 'Costo de Defontana
        If TextBox7.Text <> "" Then xlibro.Range("N25").Value = TextBox7.Text 'Margen (%)
        If TextBox123.Text <> "" Then xlibro.Range("O25").Value = TextBox123.Text 'Para costo de Reposicion articulos de GSI

        ' 3 linea de Materiales
        If TextBox9.Text <> "" Then xlibro.Range("D26").Value = TextBox9.Text 'Descripcion de Materiales
        If TextBox10.Text <> "" Then xlibro.Range("C26").Value = TextBox10.Text 'Codigo del Material
        If NumericUpDown3.Text <> "0" And NumericUpDown3.Text <> "" Then xlibro.Range("H26").Value = NumericUpDown3.Text 'Cantidad del Material
        If TextBox43.Text <> "" Then xlibro.Range("M26").Value = TextBox43.Text 'Costo de Defontana
        If TextBox11.Text <> "" Then xlibro.Range("N26").Value = TextBox11.Text 'Margen (%)
        If TextBox124.Text <> "" Then xlibro.Range("O26").Value = TextBox124.Text 'Para costo de Reposicion articulos de GSI

        ' 4 linea de Materiales
        If TextBox13.Text <> "" Then xlibro.Range("D27").Value = TextBox13.Text 'Descripcion de Materiales
        If TextBox14.Text <> "" Then xlibro.Range("C27").Value = TextBox14.Text 'Codigo del Material
        If NumericUpDown4.Text <> "0" And NumericUpDown4.Text <> "" Then xlibro.Range("H27").Value = NumericUpDown4.Text 'Cantidad del Material
        If TextBox44.Text <> "" Then xlibro.Range("M27").Value = TextBox44.Text 'Costo de Defontana
        If TextBox15.Text <> "" Then xlibro.Range("N27").Value = TextBox15.Text 'Margen (%)
        If TextBox125.Text <> "" Then xlibro.Range("O27").Value = TextBox125.Text 'Para costo de Reposicion articulos de GSI

        ' 5 linea de Materiales
        If TextBox17.Text <> "" Then xlibro.Range("D28").Value = TextBox17.Text 'Descripcion de Materiales
        If TextBox18.Text <> "" Then xlibro.Range("C28").Value = TextBox18.Text 'Codigo del Material
        If NumericUpDown5.Text <> "0" And NumericUpDown5.Text <> "" Then xlibro.Range("H28").Value = NumericUpDown5.Text 'Cantidad del Material
        If TextBox45.Text <> "" Then xlibro.Range("M28").Value = TextBox45.Text 'Costo de Defontana
        If TextBox19.Text <> "" Then xlibro.Range("N28").Value = TextBox19.Text 'Margen (%)
        If TextBox126.Text <> "" Then xlibro.Range("O28").Value = TextBox126.Text 'Para costo de Reposicion articulos de GSI

        ' 6 linea de Materiales
        If TextBox21.Text <> "" Then xlibro.Range("D29").Value = TextBox21.Text 'Descripcion de Materiales
        If TextBox22.Text <> "" Then xlibro.Range("C29").Value = TextBox22.Text 'Codigo del Material
        If NumericUpDown6.Text <> "0" And NumericUpDown6.Text <> "" Then xlibro.Range("H29").Value = NumericUpDown6.Text 'Cantidad del Material
        If TextBox46.Text <> "" Then xlibro.Range("M29").Value = TextBox46.Text 'Costo de Defontana
        If TextBox23.Text <> "" Then xlibro.Range("N29").Value = TextBox23.Text 'Margen (%)
        If TextBox127.Text <> "" Then xlibro.Range("O29").Value = TextBox127.Text 'Para costo de Reposicion articulos de GSI

        ' 7 linea de Materiales
        If TextBox25.Text <> "" Then xlibro.Range("D30").Value = TextBox25.Text 'Descripcion de Materiales
        If TextBox26.Text <> "" Then xlibro.Range("C30").Value = TextBox26.Text 'Codigo del Material
        If NumericUpDown7.Text <> "0" And NumericUpDown7.Text <> "" Then xlibro.Range("H30").Value = NumericUpDown7.Text 'Cantidad del Material
        If TextBox47.Text <> "" Then xlibro.Range("M30").Value = TextBox47.Text 'Costo de Defontana
        If TextBox27.Text <> "" Then xlibro.Range("N30").Value = TextBox27.Text 'Margen (%)
        If TextBox128.Text <> "" Then xlibro.Range("O30").Value = TextBox128.Text 'Para costo de Reposicion articulos de GSI

        ' 8 Linea de Materiles
        If TextBox29.Text <> "" Then xlibro.Range("D31").Value = TextBox29.Text 'Descripcion de Materiales
        If TextBox30.Text <> "" Then xlibro.Range("C31").Value = TextBox30.Text 'Codigo del Material
        If NumericUpDown8.Text <> "0" And NumericUpDown8.Text <> "" Then xlibro.Range("H31").Value = NumericUpDown8.Text 'Cantidad del Material
        If TextBox48.Text <> "" Then xlibro.Range("M31").Value = TextBox48.Text 'Costo de Defontana
        If TextBox31.Text <> "" Then xlibro.Range("N31").Value = TextBox31.Text 'Margen (%)
        If TextBox129.Text <> "" Then xlibro.Range("O31").Value = TextBox129.Text 'Para costo de Reposicion articulos de GSI

        ' 9 linea de Materiales
        If TextBox33.Text <> "" Then xlibro.Range("D32").Value = TextBox33.Text 'Descripcion de Materiales
        If TextBox34.Text <> "" Then xlibro.Range("C32").Value = TextBox34.Text 'Codigo del Material
        If NumericUpDown9.Text <> "0" And NumericUpDown9.Text <> "" Then xlibro.Range("H32").Value = NumericUpDown9.Text 'Cantidad del Material
        If TextBox49.Text <> "" Then xlibro.Range("M32").Value = TextBox49.Text 'Costo de Defontana
        If TextBox35.Text <> "" Then xlibro.Range("N32").Value = TextBox35.Text 'Margen (%)
        If TextBox130.Text <> "" Then xlibro.Range("O32").Value = TextBox130.Text 'Para costo de Reposicion articulos de GSI

        ' 10 Linea de Materiales
        If TextBox37.Text <> "" Then xlibro.Range("D33").Value = TextBox37.Text 'Descripcion de Materiales
        If TextBox38.Text <> "" Then xlibro.Range("C33").Value = TextBox38.Text 'Codigo del Material
        If NumericUpDown10.Text <> "0" And NumericUpDown10.Text <> "" Then xlibro.Range("H33").Value = NumericUpDown10.Text 'Cantidad del Material
        If TextBox50.Text <> "" Then xlibro.Range("M33").Value = TextBox50.Text 'Costo de Defontana
        If TextBox39.Text <> "" Then xlibro.Range("N33").Value = TextBox39.Text 'Margen (%)
        If TextBox131.Text <> "" Then xlibro.Range("O33").Value = TextBox131.Text 'Para costo de Reposicion articulos de GSI

        ' 11 Linea de Materiales
        If TextBox62.Text <> "" Then xlibro.Range("D34").Value = TextBox62.Text 'Descripcion de Materiales
        If TextBox63.Text <> "" Then xlibro.Range("C34").Value = TextBox63.Text 'Codigo del Material
        If NumericUpDown11.Text <> "0" And NumericUpDown11.Text <> "" Then xlibro.Range("H34").Value = NumericUpDown11.Text 'Cantidad del Material
        If TextBox102.Text <> "" Then xlibro.Range("M34").Value = TextBox102.Text 'Costo de Defontana
        If TextBox64.Text <> "" Then xlibro.Range("N34").Value = TextBox64.Text 'Margen (%)
        If TextBox132.Text <> "" Then xlibro.Range("O34").Value = TextBox132.Text 'Para costo de Reposicion articulos de GSI

        ' 12 Linea de Materiales
        If TextBox66.Text <> "" Then xlibro.Range("D35").Value = TextBox66.Text 'Descripcion de Materiales
        If TextBox67.Text <> "" Then xlibro.Range("C35").Value = TextBox67.Text 'Codigo del Material
        If NumericUpDown12.Text <> "0" And NumericUpDown12.Text <> "" Then xlibro.Range("H35").Value = NumericUpDown12.Text 'Cantidad del Material
        If TextBox103.Text <> "" Then xlibro.Range("M35").Value = TextBox103.Text 'Costo de Defontana
        If TextBox68.Text <> "" Then xlibro.Range("N35").Value = TextBox68.Text 'Margen (%)
        If TextBox133.Text <> "" Then xlibro.Range("O35").Value = TextBox133.Text 'Para costo de Reposicion articulos de GSI

        ' 13 Linea de Materiales
        If TextBox70.Text <> "" Then xlibro.Range("D36").Value = TextBox70.Text 'Descripcion de Materiales
        If TextBox71.Text <> "" Then xlibro.Range("C36").Value = TextBox71.Text 'Codigo del Material
        If NumericUpDown13.Text <> "0" And NumericUpDown13.Text <> "" Then xlibro.Range("H36").Value = NumericUpDown13.Text 'Cantidad del Material
        If TextBox104.Text <> "" Then xlibro.Range("M36").Value = TextBox104.Text 'Costo de Defontana
        If TextBox72.Text <> "" Then xlibro.Range("N36").Value = TextBox72.Text 'Margen (%)
        If TextBox134.Text <> "" Then xlibro.Range("O36").Value = TextBox134.Text 'Para costo de Reposicion articulos de GSI

        ' 14 Linea de Materiales
        If TextBox74.Text <> "" Then xlibro.Range("D37").Value = TextBox74.Text 'Descripcion de Materiales
        If TextBox75.Text <> "" Then xlibro.Range("C37").Value = TextBox75.Text 'Codigo del Material
        If NumericUpDown14.Text <> "0" And NumericUpDown14.Text <> "" Then xlibro.Range("H37").Value = NumericUpDown14.Text 'Cantidad del Material
        If TextBox105.Text <> "" Then xlibro.Range("M37").Value = TextBox105.Text 'Costo de Defontana
        If TextBox76.Text <> "" Then xlibro.Range("N37").Value = TextBox76.Text 'Margen (%)
        If TextBox135.Text <> "" Then xlibro.Range("O37").Value = TextBox135.Text 'Para costo de Reposicion articulos de GSI

        ' 15 Linea de Materiales
        If TextBox78.Text <> "" Then xlibro.Range("D38").Value = TextBox78.Text 'Descripcion de Materiales
        If TextBox79.Text <> "" Then xlibro.Range("C38").Value = TextBox79.Text 'Codigo del Material
        If NumericUpDown15.Text <> "0" And NumericUpDown15.Text <> "" Then xlibro.Range("H38").Value = NumericUpDown15.Text 'Cantidad del Material
        If TextBox106.Text <> "" Then xlibro.Range("M38").Value = TextBox106.Text 'Costo de Defontana
        If TextBox80.Text <> "" Then xlibro.Range("N38").Value = TextBox80.Text 'Margen (%)
        If TextBox136.Text <> "" Then xlibro.Range("O38").Value = TextBox136.Text 'Para costo de Reposicion articulos de GSI

        ' 16 Linea de Materiales
        If TextBox82.Text <> "" Then xlibro.Range("D39").Value = TextBox82.Text 'Descripcion de Materiales
        If TextBox83.Text <> "" Then xlibro.Range("C39").Value = TextBox83.Text 'Codigo del Material
        If NumericUpDown16.Text <> "0" And NumericUpDown16.Text <> "" Then xlibro.Range("H39").Value = NumericUpDown16.Text 'Cantidad del Material
        If TextBox107.Text <> "" Then xlibro.Range("M39").Value = TextBox107.Text 'Costo de Defontana
        If TextBox84.Text <> "" Then xlibro.Range("N39").Value = TextBox84.Text 'Margen (%)
        If TextBox137.Text <> "" Then xlibro.Range("O39").Value = TextBox137.Text 'Para costo de Reposicion articulos de GSI

        ' 17 Linea de Materiales
        If TextBox86.Text <> "" Then xlibro.Range("D40").Value = TextBox86.Text 'Descripcion de Materiales
        If TextBox87.Text <> "" Then xlibro.Range("C40").Value = TextBox87.Text 'Codigo del Material
        If NumericUpDown17.Text <> "0" And NumericUpDown17.Text <> "" Then xlibro.Range("H40").Value = NumericUpDown17.Text 'Cantidad del Material
        If TextBox108.Text <> "" Then xlibro.Range("M40").Value = TextBox108.Text 'Costo de Defontana
        If TextBox88.Text <> "" Then xlibro.Range("N40").Value = TextBox88.Text 'Margen (%)
        If TextBox138.Text <> "" Then xlibro.Range("O40").Value = TextBox138.Text 'Para costo de Reposicion articulos de GSI

        ' 18 Linea de Materiales
        If TextBox90.Text <> "" Then xlibro.Range("D41").Value = TextBox90.Text 'Descripcion de Materiales
        If TextBox91.Text <> "" Then xlibro.Range("C41").Value = TextBox91.Text 'Codigo del Material
        If NumericUpDown18.Text <> "0" And NumericUpDown18.Text <> "" Then xlibro.Range("H41").Value = NumericUpDown18.Text 'Cantidad del Material
        If TextBox109.Text <> "" Then xlibro.Range("M41").Value = TextBox109.Text 'Costo de Defontana
        If TextBox92.Text <> "" Then xlibro.Range("N41").Value = TextBox92.Text 'Margen (%)
        If TextBox139.Text <> "" Then xlibro.Range("O41").Value = TextBox139.Text 'Para costo de Reposicion articulos de GSI

        ' 19 Linea de Materiales
        If TextBox94.Text <> "" Then xlibro.Range("D42").Value = TextBox94.Text 'Descripcion de Materiales
        If TextBox95.Text <> "" Then xlibro.Range("C42").Value = TextBox95.Text 'Codigo del Material
        If NumericUpDown19.Text <> "0" And NumericUpDown19.Text <> "" Then xlibro.Range("H42").Value = NumericUpDown19.Text 'Cantidad del Material
        If TextBox110.Text <> "" Then xlibro.Range("M42").Value = TextBox110.Text 'Costo de Defontana
        If TextBox96.Text <> "" Then xlibro.Range("N42").Value = TextBox96.Text 'Margen (%)
        If TextBox140.Text <> "" Then xlibro.Range("O42").Value = TextBox140.Text 'Para costo de Reposicion articulos de GSI

        '20 Linea de Materiales
        If TextBox98.Text <> "" Then xlibro.Range("D43").Value = TextBox98.Text 'Descripcion de Materiales
        If TextBox99.Text <> "" Then xlibro.Range("C43").Value = TextBox99.Text 'Codigo del Material
        If NumericUpDown20.Text <> "0" And NumericUpDown20.Text <> "" Then xlibro.Range("H43").Value = NumericUpDown20.Text 'Cantidad del Material
        If TextBox111.Text <> "" Then xlibro.Range("M43").Value = TextBox111.Text 'Costo de Defontana
        If TextBox100.Text <> "" Then xlibro.Range("N43").Value = TextBox100.Text 'Margen (%)
        If TextBox141.Text <> "" Then xlibro.Range("O43").Value = TextBox141.Text 'Para costo de Reposicion articulos de GSI

        If CboLugar.Text <> "" Then xlibro.Range("D54").Value = CboLugar.Text
        If TxtPlazo.Text <> "" Then xlibro.Range("D55").Value = TxtPlazo.Text
        If Cbopago.Text <> "" Then xlibro.Range("D56").Value = Cbopago.Text
        If CboValidez.Text <> "" Then xlibro.Range("D57").Value = CboValidez.Text

    End Sub
    Private Sub BtnExportarEUR_Click(sender As Object, e As EventArgs) Handles BtnExportarEUR.Click
        Dim xlibro As Microsoft.Office.Interop.Excel.Application
        Dim strRutaExcel As String

        strRutaExcel = "C:\SOURCESAFRATEC\Planilla de Cotizacion.xlsm"

        xlibro = CreateObject("Excel.Application")
        xlibro.Workbooks.Open(strRutaExcel)

        'Activamos el libro
        xlibro.Workbooks("Planilla de Cotizacion.xlsm").Activate()

        'Activamos la hoja especifica del libro  
        xlibro.Sheets("Planilla de Cotizacion (EUR)").Select()

        Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = xlibro.Sheets.Item("Planilla de Cotizacion (EUR)")
        xlibro.Visible = True

        If TxtRazon.Text <> "" Then xlibro.Range("D15").Value = TxtRazon.Text 'Razon social
        If TxtAtencion.Text <> "" Then xlibro.Range("D16").Value = TxtAtencion.Text 'Atencion
        If TxtRut.Text <> "" Then xlibro.Range("D17").Value = TxtRut.Text 'RUT
        If TxtDireccion.Text <> "" Then xlibro.Range("D18").Value = TxtDireccion.Text 'Direccion 
        If TxtphoneC.Text <> "" Then xlibro.Range("D19").Value = TxtphoneC.Text 'Telefono cliente
        If TxtCorreoC.Text <> "" Then xlibro.Range("D20").Value = TxtCorreoC.Text ' Correo de Cliente

        If TxtCot.Text <> "" And Txtcot2.Text <> "" And Txtcot3.Text <> "" Then
            xlibro.Range("H10").Value = "TSA - " + TxtCot.Text + Txtcot2.Text + Txtcot3.Text '# de Cotizacion
        End If

        If TxtFecha.Text <> "" Then xlibro.Range("I16").Value = TxtFecha.Text ' Fecha del Dia

        If CboContacto.Text <> "" Then xlibro.Range("I17").Value = CboContacto.Text 'Vendedor
        If TxtCorreoV.Text <> "" Then xlibro.Range("I18").Value = TxtCorreoV.Text 'Correo de Vendedor
        If TxtWeb.Text <> "" Then xlibro.Range("I19").Value = TxtWeb.Text 'Pagina web
        If TxtphoneV.Text <> "" Then xlibro.Range("I20").Value = TxtphoneV.Text 'Telefono vendedor

        If TxtReferencia.Text <> "" Then xlibro.Range("D21").Value = TxtReferencia.Text 'Referencia 

        ' Para primera linea activa de Materiales
        If TextBox1.Text <> "" Then xlibro.Range("D24").Value = TextBox1.Text 'Descripcion de Materiales
        If TextBox2.Text <> "" Then xlibro.Range("C24").Value = TextBox2.Text 'Codigo del Material
        If NumericUpDown1.Text <> "0" And NumericUpDown1.Text <> "" Then xlibro.Range("H24").Value = NumericUpDown1.Text 'Cantidad del Material
        If TextBox41.Text <> "" Then xlibro.Range("M24").Value = TextBox41.Text 'Costo de Defontana
        If TextBox3.Text <> "" Then xlibro.Range("N24").Value = TextBox3.Text 'Margen (%)
        If TextBox122.Text <> "" Then xlibro.Range("O24").Value = TextBox122.Text 'Para costo de Reposicion articulos de GSI

        ' 2 linea de Materiales
        If TextBox5.Text <> "" Then xlibro.Range("D25").Value = TextBox5.Text 'Descripcion de Materiales
        If TextBox6.Text <> "" Then xlibro.Range("C25").Value = TextBox6.Text 'Codigo del Material
        If NumericUpDown2.Text <> "0" And NumericUpDown2.Text <> "" Then xlibro.Range("H25").Value = NumericUpDown2.Text 'Cantidad del Material
        If TextBox42.Text <> "" Then xlibro.Range("M25").Value = TextBox42.Text 'Costo de Defontana
        If TextBox7.Text <> "" Then xlibro.Range("N25").Value = TextBox7.Text 'Margen (%)
        If TextBox123.Text <> "" Then xlibro.Range("O25").Value = TextBox123.Text 'Para costo de Reposicion articulos de GSI

        ' 3 linea de Materiales
        If TextBox9.Text <> "" Then xlibro.Range("D26").Value = TextBox9.Text 'Descripcion de Materiales
        If TextBox10.Text <> "" Then xlibro.Range("C26").Value = TextBox10.Text 'Codigo del Material
        If NumericUpDown3.Text <> "0" And NumericUpDown3.Text <> "" Then xlibro.Range("H26").Value = NumericUpDown3.Text 'Cantidad del Material
        If TextBox43.Text <> "" Then xlibro.Range("M26").Value = TextBox43.Text 'Costo de Defontana
        If TextBox11.Text <> "" Then xlibro.Range("N26").Value = TextBox11.Text 'Margen (%)
        If TextBox124.Text <> "" Then xlibro.Range("O26").Value = TextBox124.Text 'Para costo de Reposicion articulos de GSI

        ' 4 linea de Materiales
        If TextBox13.Text <> "" Then xlibro.Range("D27").Value = TextBox13.Text 'Descripcion de Materiales
        If TextBox14.Text <> "" Then xlibro.Range("C27").Value = TextBox14.Text 'Codigo del Material
        If NumericUpDown4.Text <> "0" And NumericUpDown4.Text <> "" Then xlibro.Range("H27").Value = NumericUpDown4.Text 'Cantidad del Material
        If TextBox44.Text <> "" Then xlibro.Range("M27").Value = TextBox44.Text 'Costo de Defontana
        If TextBox15.Text <> "" Then xlibro.Range("N27").Value = TextBox15.Text 'Margen (%)
        If TextBox125.Text <> "" Then xlibro.Range("O27").Value = TextBox125.Text 'Para costo de Reposicion articulos de GSI

        ' 5 linea de Materiales
        If TextBox17.Text <> "" Then xlibro.Range("D28").Value = TextBox17.Text 'Descripcion de Materiales
        If TextBox18.Text <> "" Then xlibro.Range("C28").Value = TextBox18.Text 'Codigo del Material
        If NumericUpDown5.Text <> "0" And NumericUpDown5.Text <> "" Then xlibro.Range("H28").Value = NumericUpDown5.Text 'Cantidad del Material
        If TextBox45.Text <> "" Then xlibro.Range("M28").Value = TextBox45.Text 'Costo de Defontana
        If TextBox19.Text <> "" Then xlibro.Range("N28").Value = TextBox19.Text 'Margen (%)
        If TextBox126.Text <> "" Then xlibro.Range("O28").Value = TextBox126.Text 'Para costo de Reposicion articulos de GSI

        ' 6 linea de Materiales
        If TextBox21.Text <> "" Then xlibro.Range("D29").Value = TextBox21.Text 'Descripcion de Materiales
        If TextBox22.Text <> "" Then xlibro.Range("C29").Value = TextBox22.Text 'Codigo del Material
        If NumericUpDown6.Text <> "0" And NumericUpDown6.Text <> "" Then xlibro.Range("H29").Value = NumericUpDown6.Text 'Cantidad del Material
        If TextBox46.Text <> "" Then xlibro.Range("M29").Value = TextBox46.Text 'Costo de Defontana
        If TextBox23.Text <> "" Then xlibro.Range("N29").Value = TextBox23.Text 'Margen (%)
        If TextBox127.Text <> "" Then xlibro.Range("O29").Value = TextBox127.Text 'Para costo de Reposicion articulos de GSI

        ' 7 linea de Materiales
        If TextBox25.Text <> "" Then xlibro.Range("D30").Value = TextBox25.Text 'Descripcion de Materiales
        If TextBox26.Text <> "" Then xlibro.Range("C30").Value = TextBox26.Text 'Codigo del Material
        If NumericUpDown7.Text <> "0" And NumericUpDown7.Text <> "" Then xlibro.Range("H30").Value = NumericUpDown7.Text 'Cantidad del Material
        If TextBox47.Text <> "" Then xlibro.Range("M30").Value = TextBox47.Text 'Costo de Defontana
        If TextBox27.Text <> "" Then xlibro.Range("N30").Value = TextBox27.Text 'Margen (%)
        If TextBox128.Text <> "" Then xlibro.Range("O30").Value = TextBox128.Text 'Para costo de Reposicion articulos de GSI

        ' 8 Linea de Materiales
        If TextBox29.Text <> "" Then xlibro.Range("D31").Value = TextBox29.Text 'Descripcion de Materiales
        If TextBox30.Text <> "" Then xlibro.Range("C31").Value = TextBox30.Text 'Codigo del Material
        If NumericUpDown8.Text <> "0" And NumericUpDown8.Text <> "" Then xlibro.Range("H31").Value = NumericUpDown8.Text 'Cantidad del Material
        If TextBox48.Text <> "" Then xlibro.Range("M31").Value = TextBox48.Text 'Costo de Defontana
        If TextBox31.Text <> "" Then xlibro.Range("N31").Value = TextBox31.Text 'Margen (%)
        If TextBox129.Text <> "" Then xlibro.Range("O31").Value = TextBox129.Text 'Para costo de Reposicion articulos de GSI

        ' 9 linea de Materiales
        If TextBox33.Text <> "" Then xlibro.Range("D32").Value = TextBox33.Text 'Descripcion de Materiales
        If TextBox34.Text <> "" Then xlibro.Range("C32").Value = TextBox34.Text 'Codigo del Material
        If NumericUpDown9.Text <> "0" And NumericUpDown9.Text <> "" Then xlibro.Range("H32").Value = NumericUpDown9.Text 'Cantidad del Material
        If TextBox49.Text <> "" Then xlibro.Range("M32").Value = TextBox49.Text 'Costo de Defontana
        If TextBox35.Text <> "" Then xlibro.Range("N32").Value = TextBox35.Text 'Margen (%)
        If TextBox130.Text <> "" Then xlibro.Range("O32").Value = TextBox130.Text 'Para costo de Reposicion articulos de GSI

        ' 10 Linea de Materiales
        If TextBox37.Text <> "" Then xlibro.Range("D33").Value = TextBox37.Text 'Descripcion de Materiales
        If TextBox38.Text <> "" Then xlibro.Range("C33").Value = TextBox38.Text 'Codigo del Material
        If NumericUpDown10.Text <> "0" And NumericUpDown10.Text <> "" Then xlibro.Range("H33").Value = NumericUpDown10.Text 'Cantidad del Material
        If TextBox50.Text <> "" Then xlibro.Range("M33").Value = TextBox50.Text 'Costo de Defontana
        If TextBox39.Text <> "" Then xlibro.Range("N33").Value = TextBox39.Text 'Margen (%)
        If TextBox131.Text <> "" Then xlibro.Range("O33").Value = TextBox131.Text 'Para costo de Reposicion articulos de GSI

        ' 11 Linea de Materiales
        If TextBox62.Text <> "" Then xlibro.Range("D34").Value = TextBox62.Text 'Descripcion de Materiales
        If TextBox63.Text <> "" Then xlibro.Range("C34").Value = TextBox63.Text 'Codigo del Material
        If NumericUpDown11.Text <> "0" And NumericUpDown11.Text <> "" Then xlibro.Range("H34").Value = NumericUpDown11.Text 'Cantidad del Material
        If TextBox102.Text <> "" Then xlibro.Range("M34").Value = TextBox102.Text 'Costo de Defontana
        If TextBox64.Text <> "" Then xlibro.Range("N34").Value = TextBox64.Text 'Margen (%)
        If TextBox132.Text <> "" Then xlibro.Range("O34").Value = TextBox132.Text 'Para costo de Reposicion articulos de GSI

        ' 12 Linea de Materiales
        If TextBox66.Text <> "" Then xlibro.Range("D35").Value = TextBox66.Text 'Descripcion de Materiales
        If TextBox67.Text <> "" Then xlibro.Range("C35").Value = TextBox67.Text 'Codigo del Material
        If NumericUpDown12.Text <> "0" And NumericUpDown12.Text <> "" Then xlibro.Range("H35").Value = NumericUpDown12.Text 'Cantidad del Material
        If TextBox103.Text <> "" Then xlibro.Range("M35").Value = TextBox103.Text 'Costo de Defontana
        If TextBox68.Text <> "" Then xlibro.Range("N35").Value = TextBox68.Text 'Margen (%)
        If TextBox133.Text <> "" Then xlibro.Range("O35").Value = TextBox133.Text 'Para costo de Reposicion articulos de GSI

        ' 13 Linea de Materiales
        If TextBox70.Text <> "" Then xlibro.Range("D36").Value = TextBox70.Text 'Descripcion de Materiales
        If TextBox71.Text <> "" Then xlibro.Range("C36").Value = TextBox71.Text 'Codigo del Material
        If NumericUpDown13.Text <> "0" And NumericUpDown13.Text <> "" Then xlibro.Range("H36").Value = NumericUpDown13.Text 'Cantidad del Material
        If TextBox104.Text <> "" Then xlibro.Range("M36").Value = TextBox104.Text 'Costo de Defontana
        If TextBox72.Text <> "" Then xlibro.Range("N36").Value = TextBox72.Text 'Margen (%)
        If TextBox134.Text <> "" Then xlibro.Range("O36").Value = TextBox134.Text 'Para costo de Reposicion articulos de GSI

        ' 14 Linea de Materiales
        If TextBox74.Text <> "" Then xlibro.Range("D37").Value = TextBox74.Text 'Descripcion de Materiales
        If TextBox75.Text <> "" Then xlibro.Range("C37").Value = TextBox75.Text 'Codigo del Material
        If NumericUpDown14.Text <> "0" And NumericUpDown14.Text <> "" Then xlibro.Range("H37").Value = NumericUpDown14.Text 'Cantidad del Material
        If TextBox105.Text <> "" Then xlibro.Range("M37").Value = TextBox105.Text 'Costo de Defontana
        If TextBox76.Text <> "" Then xlibro.Range("N37").Value = TextBox76.Text 'Margen (%)
        If TextBox135.Text <> "" Then xlibro.Range("O37").Value = TextBox135.Text 'Para costo de Reposicion articulos de GSI

        ' 15 Linea de Materiales
        If TextBox78.Text <> "" Then xlibro.Range("D38").Value = TextBox78.Text 'Descripcion de Materiales
        If TextBox79.Text <> "" Then xlibro.Range("C38").Value = TextBox79.Text 'Codigo del Material
        If NumericUpDown15.Text <> "0" And NumericUpDown15.Text <> "" Then xlibro.Range("H38").Value = NumericUpDown15.Text 'Cantidad del Material
        If TextBox106.Text <> "" Then xlibro.Range("M38").Value = TextBox106.Text 'Costo de Defontana
        If TextBox80.Text <> "" Then xlibro.Range("N38").Value = TextBox80.Text 'Margen (%)
        If TextBox136.Text <> "" Then xlibro.Range("O38").Value = TextBox136.Text 'Para costo de Reposicion articulos de GSI

        ' 16 Linea de Materiales
        If TextBox82.Text <> "" Then xlibro.Range("D39").Value = TextBox82.Text 'Descripcion de Materiales
        If TextBox83.Text <> "" Then xlibro.Range("C39").Value = TextBox83.Text 'Codigo del Material
        If NumericUpDown16.Text <> "0" And NumericUpDown16.Text <> "" Then xlibro.Range("H39").Value = NumericUpDown16.Text 'Cantidad del Material
        If TextBox107.Text <> "" Then xlibro.Range("M39").Value = TextBox107.Text 'Costo de Defontana
        If TextBox84.Text <> "" Then xlibro.Range("N39").Value = TextBox84.Text 'Margen (%)
        If TextBox137.Text <> "" Then xlibro.Range("O39").Value = TextBox137.Text 'Para costo de Reposicion articulos de GSI

        ' 17 Linea de Materiales
        If TextBox86.Text <> "" Then xlibro.Range("D40").Value = TextBox86.Text 'Descripcion de Materiales
        If TextBox87.Text <> "" Then xlibro.Range("C40").Value = TextBox87.Text 'Codigo del Material
        If NumericUpDown17.Text <> "0" And NumericUpDown17.Text <> "" Then xlibro.Range("H40").Value = NumericUpDown17.Text 'Cantidad del Material
        If TextBox108.Text <> "" Then xlibro.Range("M40").Value = TextBox108.Text 'Costo de Defontana
        If TextBox88.Text <> "" Then xlibro.Range("N40").Value = TextBox88.Text 'Margen (%)
        If TextBox138.Text <> "" Then xlibro.Range("O40").Value = TextBox138.Text 'Para costo de Reposicion articulos de GSI

        ' 18 Linea de Materiales
        If TextBox90.Text <> "" Then xlibro.Range("D41").Value = TextBox90.Text 'Descripcion de Materiales
        If TextBox91.Text <> "" Then xlibro.Range("C41").Value = TextBox91.Text 'Codigo del Material
        If NumericUpDown18.Text <> "0" And NumericUpDown18.Text <> "" Then xlibro.Range("H41").Value = NumericUpDown18.Text 'Cantidad del Material
        If TextBox109.Text <> "" Then xlibro.Range("M41").Value = TextBox109.Text 'Costo de Defontana
        If TextBox92.Text <> "" Then xlibro.Range("N41").Value = TextBox92.Text 'Margen (%)
        If TextBox139.Text <> "" Then xlibro.Range("O41").Value = TextBox139.Text 'Para costo de Reposicion articulos de GSI

        ' 19 Linea de Materiales
        If TextBox94.Text <> "" Then xlibro.Range("D42").Value = TextBox94.Text 'Descripcion de Materiales
        If TextBox95.Text <> "" Then xlibro.Range("C42").Value = TextBox95.Text 'Codigo del Material
        If NumericUpDown19.Text <> "0" And NumericUpDown19.Text <> "" Then xlibro.Range("H42").Value = NumericUpDown19.Text 'Cantidad del Material
        If TextBox110.Text <> "" Then xlibro.Range("M42").Value = TextBox110.Text 'Costo de Defontana
        If TextBox96.Text <> "" Then xlibro.Range("N42").Value = TextBox96.Text 'Margen (%)
        If TextBox140.Text <> "" Then xlibro.Range("O42").Value = TextBox140.Text 'Para costo de Reposicion articulos de GSI

        ' 20 Linea de Materiales
        If TextBox98.Text <> "" Then xlibro.Range("D43").Value = TextBox98.Text 'Descripcion de Materiales
        If TextBox99.Text <> "" Then xlibro.Range("C43").Value = TextBox99.Text 'Codigo del Material
        If NumericUpDown20.Text <> "0" And NumericUpDown20.Text <> "" Then xlibro.Range("H43").Value = NumericUpDown20.Text 'Cantidad del Material
        If TextBox111.Text <> "" Then xlibro.Range("M43").Value = TextBox111.Text 'Costo de Defontana
        If TextBox100.Text <> "" Then xlibro.Range("N43").Value = TextBox100.Text 'Margen (%)
        If TextBox141.Text <> "" Then xlibro.Range("O43").Value = TextBox141.Text 'Para costo de Reposicion articulos de GSI

        If CboLugar.Text <> "" Then xlibro.Range("D54").Value = CboLugar.Text 'Lugar
        If TxtPlazo.Text <> "" Then xlibro.Range("D55").Value = TxtPlazo.Text 'Plazo
        If Cbopago.Text <> "" Then xlibro.Range("D56").Value = Cbopago.Text 'Forma de pago
        If CboValidez.Text <> "" Then xlibro.Range("D57").Value = CboValidez.Text 'Validez

    End Sub

#End Region
#Region "Guardar base datos SAFRATEC"
    Private Sub BD1_CheckedChanged(sender As Object, e As EventArgs) Handles BD1.CheckedChanged
        If TxtCot.Text = "" Then
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else

            Dim Cot As String = (TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Fec As String = TxtFecha.Value.ToString("yyyy-MM-dd")
            Dim Raz As String = TxtRazon.Text
            Dim RUT As String = TxtRut.Text
            Dim Ate As String = TxtAtencion.Text
            Dim DirAte As String = TxtDireccion.Text
            Dim TelAte As String = TxtphoneC.Text
            Dim CorAte As String = TxtCorreoC.Text
            Dim Ven As String = CboContacto.Text
            Dim TelVen As String = TxtphoneV.Text
            Dim CorVen As String = TxtCorreoV.Text
            Dim Web As String = TxtWeb.Text
            Dim Ref As String = TxtReferencia.Text

            Dim Descrip As String = TextBox1.Text
            Dim Codi As String = TextBox2.Text
            Dim Cant As String = NumericUpDown1.Text
            Dim Mar As String = TextBox3.Text
            Dim Precio As String = TextBox4.Text
            Dim Total As String = TextBox52.Text
            Dim Moneda As String = TextBox164.Text
            Dim ID As String = ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Lin As String = Label49.Text

            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "'
            ,'" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Mar & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()


        End If

        'Para actualizacion de codigo de Cliente 
        Dim actu As String = "UPDATE DATACODCLIENTE SET Codigo= ?Cod, Descripcion= ?Descrip, CODCLIENTE= ?CodCliente where RAZON= ?Razon and Codigo=?Cod"
        Dim abc As New MySqlCommand(actu, conex)

        abc.Parameters.AddWithValue("?Cod", TextBox2.Text)
        abc.Parameters.AddWithValue("?Descrip", TextBox1.Text)
        abc.Parameters.AddWithValue("?Razon", TxtRazon.Text)
        abc.Parameters.AddWithValue("?CodCliente", TextBox142.Text)

        abc.ExecuteNonQuery()

    End Sub

    Private Sub BD2_CheckedChanged(sender As Object, e As EventArgs) Handles BD2.CheckedChanged
        ' para comenzar insertar valores en la data 
        ' Verifico que haya escrito el ISBN (bueno, debería verificarlos todos, pero como esta es la clave principal...)
        If TxtCot.Text = "" Then
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            On Error Resume Next
            Dim Cot As String = (TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Fec As String = TxtFecha.Value.ToString("yyyy-MM-dd")
            Dim Raz As String = TxtRazon.Text
            Dim RUT As String = TxtRut.Text
            Dim Ate As String = TxtAtencion.Text
            Dim DirAte As String = TxtDireccion.Text
            Dim TelAte As String = TxtphoneC.Text
            Dim CorAte As String = TxtCorreoC.Text
            Dim Ven As String = CboContacto.Text
            Dim TelVen As String = TxtphoneV.Text
            Dim CorVen As String = TxtCorreoV.Text
            Dim Web As String = TxtWeb.Text
            Dim Ref As String = TxtReferencia.Text

            Dim Descrip As String = TextBox5.Text
            Dim Codi As String = TextBox6.Text
            Dim Cant As String = NumericUpDown2.Text
            Dim Mar As String = TextBox7.Text
            Dim Precio As String = TextBox8.Text
            Dim Total As String = TextBox53.Text
            Dim Moneda As String = TextBox165.Text
            Dim ID As String = ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Lin As String = Label50.Text
            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "'
            ,'" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Mar & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()

        End If

        'Para actualizacion de codigo de Cliente 
        Dim actu As String = "UPDATE DATACODCLIENTE SET Codigo= ?Cod, Descripcion= ?Descrip, CODCLIENTE= ?CodCliente where RAZON= ?Razon and Codigo=?Cod"
        Dim abc As New MySqlCommand(actu, conex)

        abc.Parameters.AddWithValue("?Cod", TextBox6.Text)
        abc.Parameters.AddWithValue("?Descrip", TextBox5.Text)
        abc.Parameters.AddWithValue("?Razon", TxtRazon.Text)
        abc.Parameters.AddWithValue("?CodCliente", TextBox143.Text)

        abc.ExecuteNonQuery()
    End Sub

    Private Sub BD3_CheckedChanged(sender As Object, e As EventArgs) Handles BD3.CheckedChanged
        If TxtCot.Text = "" Then
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            On Error Resume Next
            Dim Cot As String = (TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Fec As String = TxtFecha.Value.ToString("yyyy-MM-dd")
            Dim Raz As String = TxtRazon.Text
            Dim RUT As String = TxtRut.Text
            Dim Ate As String = TxtAtencion.Text
            Dim DirAte As String = TxtDireccion.Text
            Dim TelAte As String = TxtphoneC.Text
            Dim CorAte As String = TxtCorreoC.Text
            Dim Ven As String = CboContacto.Text
            Dim TelVen As String = TxtphoneV.Text
            Dim CorVen As String = TxtCorreoV.Text
            Dim Web As String = TxtWeb.Text
            Dim Ref As String = TxtReferencia.Text

            Dim Descrip As String = TextBox9.Text
            Dim Codi As String = TextBox10.Text
            Dim Cant As String = NumericUpDown3.Text
            Dim Mar As String = TextBox11.Text
            Dim Precio As String = TextBox12.Text
            Dim Total As String = TextBox54.Text
            Dim Moneda As String = TextBox166.Text
            Dim ID As String = ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Lin As String = Label51.Text

            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "'
            ,'" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Mar & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()

        End If
        'Para actualizacion de codigo de Cliente 
        Dim actu As String = "UPDATE DATACODCLIENTE SET Codigo= ?Cod, Descripcion= ?Descrip, CODCLIENTE= ?CodCliente where RAZON= ?Razon and Codigo=?Cod"
        Dim abc As New MySqlCommand(actu, conex)

        abc.Parameters.AddWithValue("?Cod", TextBox10.Text)
        abc.Parameters.AddWithValue("?Descrip", TextBox9.Text)
        abc.Parameters.AddWithValue("?Razon", TxtRazon.Text)
        abc.Parameters.AddWithValue("?CodCliente", TextBox144.Text)

        abc.ExecuteNonQuery()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        'Para asegurar si esta correcto el registro
        If TxtCot.Text + Txtcot2.Text + Txtcot3.Text > "" Then
            If MessageBox.Show("¿ Seguro que desea insertar este registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

                If TextBox1.Text > "" Then
                    BD1.Checked = True
                End If
                If TextBox5.Text > "" Then
                    BD2.Checked = True
                End If
                If TextBox9.Text > "" Then
                    BD3.Checked = True
                End If
                If TextBox13.Text > "" Then
                    BD4.Checked = True
                End If
                If TextBox17.Text > "" Then
                    BD5.Checked = True
                End If
                If TextBox21.Text > "" Then
                    BD6.Checked = True
                End If
                If TextBox25.Text > "" Then
                    BD7.Checked = True
                End If
                If TextBox29.Text > "" Then
                    BD8.Checked = True
                End If
                If TextBox33.Text > "" Then
                    BD9.Checked = True
                End If
                If TextBox37.Text > "" Then
                    BD10.Checked = True
                End If
                If TextBox62.Text > "" Then
                    BD11.Checked = True
                End If
                If TextBox66.Text > "" Then
                    BD12.Checked = True
                End If
                If TextBox70.Text > "" Then
                    BD13.Checked = True
                End If
                If TextBox74.Text > "" Then
                    BD14.Checked = True
                End If
                If TextBox78.Text > "" Then
                    BD15.Checked = True
                End If
                If TextBox82.Text > "" Then
                    BD16.Checked = True
                End If
                If TextBox86.Text > "" Then
                    BD17.Checked = True
                End If
                If TextBox90.Text > "" Then
                    BD18.Checked = True
                End If
                If TextBox94.Text > "" Then
                    BD19.Checked = True
                End If
                If TextBox98.Text > "" Then
                    BD20.Checked = True
                End If
            End If
        End If

    End Sub

    Private Sub BD4_CheckedChanged(sender As Object, e As EventArgs) Handles BD4.CheckedChanged
        If TxtCot.Text = "" Then
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            On Error Resume Next
            Dim Cot As String = (TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Fec As String = TxtFecha.Value.ToString("yyyy-MM-dd")
            Dim Raz As String = TxtRazon.Text
            Dim RUT As String = TxtRut.Text
            Dim Ate As String = TxtAtencion.Text
            Dim DirAte As String = TxtDireccion.Text
            Dim TelAte As String = TxtphoneC.Text
            Dim CorAte As String = TxtCorreoC.Text
            Dim Ven As String = CboContacto.Text
            Dim TelVen As String = TxtphoneV.Text
            Dim CorVen As String = TxtCorreoV.Text
            Dim Web As String = TxtWeb.Text
            Dim Ref As String = TxtReferencia.Text

            Dim Descrip As String = TextBox13.Text
            Dim Codi As String = TextBox14.Text
            Dim Cant As String = NumericUpDown4.Text
            Dim Mar As String = TextBox15.Text
            Dim Precio As String = TextBox16.Text
            Dim Total As String = TextBox55.Text
            Dim Moneda As String = TextBox167.Text
            Dim ID As String = ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Lin As String = Label52.Text

            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "'
            ,'" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Mar & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()

        End If
        'Para actualizacion de codigo de Cliente 
        Dim actu As String = "UPDATE DATACODCLIENTE SET Codigo= ?Cod, Descripcion= ?Descrip, CODCLIENTE= ?CodCliente where RAZON= ?Razon and Codigo=?Cod"
        Dim abc As New MySqlCommand(actu, conex)

        abc.Parameters.AddWithValue("?Cod", TextBox14.Text)
        abc.Parameters.AddWithValue("?Descrip", TextBox13.Text)
        abc.Parameters.AddWithValue("?Razon", TxtRazon.Text)
        abc.Parameters.AddWithValue("?CodCliente", TextBox145.Text)

        abc.ExecuteNonQuery()
    End Sub

    Private Sub BD5_CheckedChanged(sender As Object, e As EventArgs) Handles BD5.CheckedChanged
        If TxtCot.Text = "" Then
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            On Error Resume Next
            Dim Cot As String = (TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Fec As String = TxtFecha.Value.ToString("yyyy-MM-dd")
            Dim Raz As String = TxtRazon.Text
            Dim RUT As String = TxtRut.Text
            Dim Ate As String = TxtAtencion.Text
            Dim DirAte As String = TxtDireccion.Text
            Dim TelAte As String = TxtphoneC.Text
            Dim CorAte As String = TxtCorreoC.Text
            Dim Ven As String = CboContacto.Text
            Dim TelVen As String = TxtphoneV.Text
            Dim CorVen As String = TxtCorreoV.Text
            Dim Web As String = TxtWeb.Text
            Dim Ref As String = TxtReferencia.Text

            Dim Descrip As String = TextBox17.Text
            Dim Codi As String = TextBox18.Text
            Dim Cant As String = NumericUpDown5.Text
            Dim Mar As String = TextBox19.Text
            Dim Precio As String = TextBox20.Text
            Dim Total As String = TextBox56.Text
            Dim Moneda As String = TextBox168.Text
            Dim ID As String = ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Lin As String = Label53.Text

            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "'
            ,'" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Mar & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()

        End If
        'Para actualizacion de codigo de Cliente 
        Dim actu As String = "UPDATE DATACODCLIENTE SET Codigo= ?Cod, Descripcion= ?Descrip, CODCLIENTE= ?CodCliente where RAZON= ?Razon and Codigo=?Cod"
        Dim abc As New MySqlCommand(actu, conex)

        abc.Parameters.AddWithValue("?Cod", TextBox18.Text)
        abc.Parameters.AddWithValue("?Descrip", TextBox17.Text)
        abc.Parameters.AddWithValue("?Razon", TxtRazon.Text)
        abc.Parameters.AddWithValue("?CodCliente", TextBox146.Text)

        abc.ExecuteNonQuery()
    End Sub

    Private Sub BD6_CheckedChanged(sender As Object, e As EventArgs) Handles BD6.CheckedChanged
        If TxtCot.Text = "" Then
            ' Si no lo escribió, mando mensaje de error
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            On Error Resume Next
            Dim Cot As String = (TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Fec As String = TxtFecha.Value.ToString("yyyy-MM-dd")
            Dim Raz As String = TxtRazon.Text
            Dim RUT As String = TxtRut.Text
            Dim Ate As String = TxtAtencion.Text
            Dim DirAte As String = TxtDireccion.Text
            Dim TelAte As String = TxtphoneC.Text
            Dim CorAte As String = TxtCorreoC.Text
            Dim Ven As String = CboContacto.Text
            Dim TelVen As String = TxtphoneV.Text
            Dim CorVen As String = TxtCorreoV.Text
            Dim Web As String = TxtWeb.Text
            Dim Ref As String = TxtReferencia.Text

            Dim Descrip As String = TextBox21.Text
            Dim Codi As String = TextBox22.Text
            Dim Cant As String = NumericUpDown6.Text
            Dim Mar As String = TextBox23.Text
            Dim Precio As String = TextBox24.Text
            Dim Total As String = TextBox57.Text
            Dim Moneda As String = TextBox169.Text
            Dim ID As String = ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Lin As String = Label54.Text

            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "'
            ,'" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Mar & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()

        End If
        'Para actualizacion de codigo de Cliente 
        Dim actu As String = "UPDATE DATACODCLIENTE SET Codigo= ?Cod, Descripcion= ?Descrip, CODCLIENTE= ?CodCliente where RAZON= ?Razon and Codigo=?Cod"
        Dim abc As New MySqlCommand(actu, conex)

        abc.Parameters.AddWithValue("?Cod", TextBox22.Text)
        abc.Parameters.AddWithValue("?Descrip", TextBox21.Text)
        abc.Parameters.AddWithValue("?Razon", TxtRazon.Text)
        abc.Parameters.AddWithValue("?CodCliente", TextBox147.Text)

        abc.ExecuteNonQuery()
    End Sub

    Private Sub BD7_CheckedChanged(sender As Object, e As EventArgs) Handles BD7.CheckedChanged
        If TxtCot.Text = "" Then
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            On Error Resume Next
            Dim Cot As String = (TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Fec As String = TxtFecha.Value.ToString("yyyy-MM-dd")
            Dim Raz As String = TxtRazon.Text
            Dim RUT As String = TxtRut.Text
            Dim Ate As String = TxtAtencion.Text
            Dim DirAte As String = TxtDireccion.Text
            Dim TelAte As String = TxtphoneC.Text
            Dim CorAte As String = TxtCorreoC.Text
            Dim Ven As String = CboContacto.Text
            Dim TelVen As String = TxtphoneV.Text
            Dim CorVen As String = TxtCorreoV.Text
            Dim Web As String = TxtWeb.Text
            Dim Ref As String = TxtReferencia.Text

            Dim Descrip As String = TextBox25.Text
            Dim Codi As String = TextBox26.Text
            Dim Cant As String = NumericUpDown7.Text
            Dim Mar As String = TextBox27.Text
            Dim Precio As String = TextBox28.Text
            Dim Total As String = TextBox58.Text
            Dim Moneda As String = TextBox170.Text
            Dim ID As String = ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Lin As String = Label55.Text

            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "'
            ,'" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Mar & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()


        End If
        'Para actualizacion de codigo de Cliente 
        Dim actu As String = "UPDATE DATACODCLIENTE SET Codigo= ?Cod, Descripcion= ?Descrip, CODCLIENTE= ?CodCliente where RAZON= ?Razon and Codigo=?Cod"
        Dim abc As New MySqlCommand(actu, conex)

        abc.Parameters.AddWithValue("?Cod", TextBox26.Text)
        abc.Parameters.AddWithValue("?Descrip", TextBox25.Text)
        abc.Parameters.AddWithValue("?Razon", TxtRazon.Text)
        abc.Parameters.AddWithValue("?CodCliente", TextBox148.Text)

        abc.ExecuteNonQuery()
    End Sub

    Private Sub BD8_CheckedChanged(sender As Object, e As EventArgs) Handles BD8.CheckedChanged
        If TxtCot.Text = "" Then
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            On Error Resume Next
            Dim Cot As String = (TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Fec As String = TxtFecha.Value.ToString("yyyy-MM-dd")
            Dim Raz As String = TxtRazon.Text
            Dim RUT As String = TxtRut.Text
            Dim Ate As String = TxtAtencion.Text
            Dim DirAte As String = TxtDireccion.Text
            Dim TelAte As String = TxtphoneC.Text
            Dim CorAte As String = TxtCorreoC.Text
            Dim Ven As String = CboContacto.Text
            Dim TelVen As String = TxtphoneV.Text
            Dim CorVen As String = TxtCorreoV.Text
            Dim Web As String = TxtWeb.Text
            Dim Ref As String = TxtReferencia.Text

            Dim Descrip As String = TextBox29.Text
            Dim Codi As String = TextBox30.Text
            Dim Cant As String = NumericUpDown8.Text
            Dim Mar As String = TextBox31.Text
            Dim Precio As String = TextBox32.Text
            Dim Total As String = TextBox59.Text
            Dim Moneda As String = TextBox171.Text
            Dim ID As String = ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Lin As String = Label56.Text

            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "'
            ,'" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Mar & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()

        End If


        'Para actualizacion de codigo de Cliente 
        Dim actu As String = "UPDATE DATACODCLIENTE SET Codigo= ?Cod, Descripcion= ?Descrip, CODCLIENTE= ?CodCliente where RAZON= ?Razon and Codigo=?Cod"
        Dim abc As New MySqlCommand(actu, conex)

        abc.Parameters.AddWithValue("?Cod", TextBox30.Text)
        abc.Parameters.AddWithValue("?Descrip", TextBox29.Text)
        abc.Parameters.AddWithValue("?Razon", TxtRazon.Text)
        abc.Parameters.AddWithValue("?CodCliente", TextBox149.Text)

        abc.ExecuteNonQuery()
    End Sub

    Private Sub BD9_CheckedChanged(sender As Object, e As EventArgs) Handles BD9.CheckedChanged
        If TxtCot.Text = "" Then
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            On Error Resume Next
            Dim Cot As String = (TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Fec As String = TxtFecha.Value.ToString("yyyy-MM-dd")
            Dim Raz As String = TxtRazon.Text
            Dim RUT As String = TxtRut.Text
            Dim Ate As String = TxtAtencion.Text
            Dim DirAte As String = TxtDireccion.Text
            Dim TelAte As String = TxtphoneC.Text
            Dim CorAte As String = TxtCorreoC.Text
            Dim Ven As String = CboContacto.Text
            Dim TelVen As String = TxtphoneV.Text
            Dim CorVen As String = TxtCorreoV.Text
            Dim Web As String = TxtWeb.Text
            Dim Ref As String = TxtReferencia.Text

            Dim Descrip As String = TextBox33.Text
            Dim Codi As String = TextBox34.Text
            Dim Cant As String = NumericUpDown9.Text
            Dim Mar As String = TextBox35.Text
            Dim Precio As String = TextBox36.Text
            Dim Total As String = TextBox60.Text
            Dim Moneda As String = TextBox172.Text
            Dim ID As String = ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Lin As String = Label57.Text

            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "'
            ,'" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Mar & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()

        End If
        'Para actualizacion de codigo de Cliente 
        Dim actu As String = "UPDATE DATACODCLIENTE SET Codigo= ?Cod, Descripcion= ?Descrip, CODCLIENTE= ?CodCliente where RAZON= ?Razon and Codigo=?Cod"
        Dim abc As New MySqlCommand(actu, conex)

        abc.Parameters.AddWithValue("?Cod", TextBox34.Text)
        abc.Parameters.AddWithValue("?Descrip", TextBox33.Text)
        abc.Parameters.AddWithValue("?Razon", TxtRazon.Text)
        abc.Parameters.AddWithValue("?CodCliente", TextBox150.Text)

        abc.ExecuteNonQuery()
    End Sub

    Private Sub BD10_CheckedChanged(sender As Object, e As EventArgs) Handles BD10.CheckedChanged
        If TxtCot.Text = "" Then
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            On Error Resume Next
            Dim Cot As String = (TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Fec As String = TxtFecha.Value.ToString("yyyy-MM-dd")
            Dim Raz As String = TxtRazon.Text
            Dim RUT As String = TxtRut.Text
            Dim Ate As String = TxtAtencion.Text
            Dim DirAte As String = TxtDireccion.Text
            Dim TelAte As String = TxtphoneC.Text
            Dim CorAte As String = TxtCorreoC.Text
            Dim Ven As String = CboContacto.Text
            Dim TelVen As String = TxtphoneV.Text
            Dim CorVen As String = TxtCorreoV.Text
            Dim Web As String = TxtWeb.Text
            Dim Ref As String = TxtReferencia.Text

            Dim Descrip As String = TextBox37.Text
            Dim Codi As String = TextBox38.Text
            Dim Cant As String = NumericUpDown10.Text
            Dim Mar As String = TextBox39.Text
            Dim Precio As String = TextBox40.Text
            Dim Total As String = TextBox61.Text
            Dim Moneda As String = TextBox173.Text
            Dim ID As String = ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Lin As String = Label58.Text

            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "'
            ,'" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Mar & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()

        End If
        'Para actualizacion de codigo de Cliente 
        Dim actu As String = "UPDATE DATACODCLIENTE SET Codigo= ?Cod, Descripcion= ?Descrip, CODCLIENTE= ?CodCliente where RAZON= ?Razon and Codigo=?Cod"
        Dim abc As New MySqlCommand(actu, conex)

        abc.Parameters.AddWithValue("?Cod", TextBox38.Text)
        abc.Parameters.AddWithValue("?Descrip", TextBox37.Text)
        abc.Parameters.AddWithValue("?Razon", TxtRazon.Text)
        abc.Parameters.AddWithValue("?CodCliente", TextBox151.Text)

        abc.ExecuteNonQuery()
    End Sub
    Private Sub BD11_CheckedChanged(sender As Object, e As EventArgs) Handles BD11.CheckedChanged
        If TxtCot.Text = "" Then
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            On Error Resume Next
            Dim Cot As String = (TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Fec As String = TxtFecha.Value.ToString("yyyy-MM-dd")
            Dim Raz As String = TxtRazon.Text
            Dim RUT As String = TxtRut.Text
            Dim Ate As String = TxtAtencion.Text
            Dim DirAte As String = TxtDireccion.Text
            Dim TelAte As String = TxtphoneC.Text
            Dim CorAte As String = TxtCorreoC.Text
            Dim Ven As String = CboContacto.Text
            Dim TelVen As String = TxtphoneV.Text
            Dim CorVen As String = TxtCorreoV.Text
            Dim Web As String = TxtWeb.Text
            Dim Ref As String = TxtReferencia.Text
            Dim Descrip As String = TextBox62.Text
            Dim Codi As String = TextBox63.Text
            Dim Cant As String = NumericUpDown11.Text
            Dim Mar As String = TextBox64.Text
            Dim Precio As String = TextBox65.Text
            Dim Total As String = TextBox112.Text
            Dim Moneda As String = TextBox174.Text
            Dim ID As String = ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Lin As String = Label59.Text

            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "'
            ,'" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Mar & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()

        End If
        'Para actualizacion de codigo de Cliente 
        Dim actu As String = "UPDATE DATACODCLIENTE SET Codigo= ?Cod, Descripcion= ?Descrip, CODCLIENTE= ?CodCliente where RAZON= ?Razon and Codigo=?Cod"
        Dim abc As New MySqlCommand(actu, conex)

        abc.Parameters.AddWithValue("?Cod", TextBox63.Text)
        abc.Parameters.AddWithValue("?Descrip", TextBox62.Text)
        abc.Parameters.AddWithValue("?Razon", TxtRazon.Text)
        abc.Parameters.AddWithValue("?CodCliente", TextBox152.Text)

        abc.ExecuteNonQuery()
    End Sub
    Private Sub BD12_CheckedChanged(sender As Object, e As EventArgs) Handles BD12.CheckedChanged
        If TxtCot.Text = "" Then
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            On Error Resume Next
            Dim Cot As String = (TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Fec As String = TxtFecha.Value.ToString("yyyy-MM-dd")
            Dim Raz As String = TxtRazon.Text
            Dim RUT As String = TxtRut.Text
            Dim Ate As String = TxtAtencion.Text
            Dim DirAte As String = TxtDireccion.Text
            Dim TelAte As String = TxtphoneC.Text
            Dim CorAte As String = TxtCorreoC.Text
            Dim Ven As String = CboContacto.Text
            Dim TelVen As String = TxtphoneV.Text
            Dim CorVen As String = TxtCorreoV.Text
            Dim Web As String = TxtWeb.Text
            Dim Ref As String = TxtReferencia.Text

            Dim Descrip As String = TextBox66.Text
            Dim Codi As String = TextBox67.Text
            Dim Cant As String = NumericUpDown12.Text
            Dim Mar As String = TextBox68.Text
            Dim Precio As String = TextBox69.Text
            Dim Total As String = TextBox113.Text
            Dim Moneda As String = TextBox175.Text
            Dim ID As String = ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Lin As String = Label60.Text

            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "'
            ,'" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Mar & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()

        End If
        'Para actualizacion de codigo de Cliente 
        Dim actu As String = "UPDATE DATACODCLIENTE SET Codigo= ?Cod, Descripcion= ?Descrip, CODCLIENTE= ?CodCliente where RAZON= ?Razon and Codigo=?Cod"
        Dim abc As New MySqlCommand(actu, conex)

        abc.Parameters.AddWithValue("?Cod", TextBox67.Text)
        abc.Parameters.AddWithValue("?Descrip", TextBox66.Text)
        abc.Parameters.AddWithValue("?Razon", TxtRazon.Text)
        abc.Parameters.AddWithValue("?CodCliente", TextBox153.Text)

        abc.ExecuteNonQuery()
    End Sub
    Private Sub BD13_CheckedChanged(sender As Object, e As EventArgs) Handles BD13.CheckedChanged

        If TxtCot.Text = "" Then
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            On Error Resume Next
            Dim Cot As String = (TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Fec As String = TxtFecha.Value.ToString("yyyy-MM-dd")
            Dim Raz As String = TxtRazon.Text
            Dim RUT As String = TxtRut.Text
            Dim Ate As String = TxtAtencion.Text
            Dim DirAte As String = TxtDireccion.Text
            Dim TelAte As String = TxtphoneC.Text
            Dim CorAte As String = TxtCorreoC.Text
            Dim Ven As String = CboContacto.Text
            Dim TelVen As String = TxtphoneV.Text
            Dim CorVen As String = TxtCorreoV.Text
            Dim Web As String = TxtWeb.Text
            Dim Ref As String = TxtReferencia.Text

            Dim Descrip As String = TextBox70.Text
            Dim Codi As String = TextBox71.Text
            Dim Cant As String = NumericUpDown13.Text
            Dim Mar As String = TextBox72.Text
            Dim Precio As String = TextBox73.Text
            Dim Total As String = TextBox114.Text
            Dim Moneda As String = TextBox176.Text
            Dim ID As String = ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Lin As String = Label61.Text

            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "'
            ,'" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Mar & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()


        End If
        'Para actualizacion de codigo de Cliente 
        Dim actu As String = "UPDATE DATACODCLIENTE SET Codigo= ?Cod, Descripcion= ?Descrip, CODCLIENTE= ?CodCliente where RAZON= ?Razon and Codigo=?Cod"
        Dim abc As New MySqlCommand(actu, conex)

        abc.Parameters.AddWithValue("?Cod", TextBox71.Text)
        abc.Parameters.AddWithValue("?Descrip", TextBox70.Text)
        abc.Parameters.AddWithValue("?Razon", TxtRazon.Text)
        abc.Parameters.AddWithValue("?CodCliente", TextBox154.Text)

        abc.ExecuteNonQuery()
    End Sub
    Private Sub BD14_CheckedChanged(sender As Object, e As EventArgs) Handles BD14.CheckedChanged
        If TxtCot.Text = "" Then
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            On Error Resume Next
            Dim Cot As String = (TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Fec As String = TxtFecha.Value.ToString("yyyy-MM-dd")
            Dim Raz As String = TxtRazon.Text
            Dim RUT As String = TxtRut.Text
            Dim Ate As String = TxtAtencion.Text
            Dim DirAte As String = TxtDireccion.Text
            Dim TelAte As String = TxtphoneC.Text
            Dim CorAte As String = TxtCorreoC.Text
            Dim Ven As String = CboContacto.Text
            Dim TelVen As String = TxtphoneV.Text
            Dim CorVen As String = TxtCorreoV.Text
            Dim Web As String = TxtWeb.Text
            Dim Ref As String = TxtReferencia.Text

            Dim Descrip As String = TextBox74.Text
            Dim Codi As String = TextBox75.Text
            Dim Cant As String = NumericUpDown14.Text
            Dim Mar As String = TextBox76.Text
            Dim Precio As String = TextBox77.Text
            Dim Total As String = TextBox115.Text
            Dim Moneda As String = TextBox177.Text
            Dim ID As String = ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Lin As String = Label62.Text

            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "'
            ,'" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Mar & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()

        End If
        'Para actualizacion de codigo de Cliente 
        Dim actu As String = "UPDATE DATACODCLIENTE SET Codigo= ?Cod, Descripcion= ?Descrip, CODCLIENTE= ?CodCliente where RAZON= ?Razon and Codigo=?Cod"
        Dim abc As New MySqlCommand(actu, conex)

        abc.Parameters.AddWithValue("?Cod", TextBox75.Text)
        abc.Parameters.AddWithValue("?Descrip", TextBox74.Text)
        abc.Parameters.AddWithValue("?Razon", TxtRazon.Text)
        abc.Parameters.AddWithValue("?CodCliente", TextBox155.Text)

        abc.ExecuteNonQuery()
    End Sub
    Private Sub BD15_CheckedChanged(sender As Object, e As EventArgs) Handles BD15.CheckedChanged
        If TxtCot.Text = "" Then
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            On Error Resume Next
            Dim Cot As String = (TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Fec As String = TxtFecha.Value.ToString("yyyy-MM-dd")
            Dim Raz As String = TxtRazon.Text
            Dim RUT As String = TxtRut.Text
            Dim Ate As String = TxtAtencion.Text
            Dim DirAte As String = TxtDireccion.Text
            Dim TelAte As String = TxtphoneC.Text
            Dim CorAte As String = TxtCorreoC.Text
            Dim Ven As String = CboContacto.Text
            Dim TelVen As String = TxtphoneV.Text
            Dim CorVen As String = TxtCorreoV.Text
            Dim Web As String = TxtWeb.Text
            Dim Ref As String = TxtReferencia.Text

            Dim Descrip As String = TextBox78.Text
            Dim Codi As String = TextBox79.Text
            Dim Cant As String = NumericUpDown15.Text
            Dim Mar As String = TextBox80.Text
            Dim Precio As String = TextBox81.Text
            Dim Total As String = TextBox116.Text
            Dim Moneda As String = TextBox178.Text
            Dim ID As String = ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Lin As String = Label63.Text
            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "'
            ,'" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Mar & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()

        End If
        'Para actualizacion de codigo de Cliente 
        Dim actu As String = "UPDATE DATACODCLIENTE SET Codigo= ?Cod, Descripcion= ?Descrip, CODCLIENTE= ?CodCliente where RAZON= ?Razon and Codigo=?Cod"
        Dim abc As New MySqlCommand(actu, conex)

        abc.Parameters.AddWithValue("?Cod", TextBox79.Text)
        abc.Parameters.AddWithValue("?Descrip", TextBox78.Text)
        abc.Parameters.AddWithValue("?Razon", TxtRazon.Text)
        abc.Parameters.AddWithValue("?CodCliente", TextBox156.Text)

        abc.ExecuteNonQuery()
    End Sub
    Private Sub BD16_CheckedChanged(sender As Object, e As EventArgs) Handles BD16.CheckedChanged
        If TxtCot.Text = "" Then
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            On Error Resume Next
            Dim Cot As String = (TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Fec As String = TxtFecha.Value.ToString("yyyy-MM-dd")
            Dim Raz As String = TxtRazon.Text
            Dim RUT As String = TxtRut.Text
            Dim Ate As String = TxtAtencion.Text
            Dim DirAte As String = TxtDireccion.Text
            Dim TelAte As String = TxtphoneC.Text
            Dim CorAte As String = TxtCorreoC.Text
            Dim Ven As String = CboContacto.Text
            Dim TelVen As String = TxtphoneV.Text
            Dim CorVen As String = TxtCorreoV.Text
            Dim Web As String = TxtWeb.Text
            Dim Ref As String = TxtReferencia.Text

            Dim Descrip As String = TextBox82.Text
            Dim Codi As String = TextBox83.Text
            Dim Cant As String = NumericUpDown16.Text
            Dim Mar As String = TextBox84.Text
            Dim Precio As String = TextBox85.Text
            Dim Total As String = TextBox117.Text
            Dim Moneda As String = TextBox179.Text
            Dim ID As String = ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Lin As String = Label64.Text
            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "'
            ,'" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Mar & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()

        End If
        'Para actualizacion de codigo de Cliente 
        Dim actu As String = "UPDATE DATACODCLIENTE SET Codigo= ?Cod, Descripcion= ?Descrip, CODCLIENTE= ?CodCliente where RAZON= ?Razon and Codigo=?Cod"
        Dim abc As New MySqlCommand(actu, conex)

        abc.Parameters.AddWithValue("?Cod", TextBox83.Text)
        abc.Parameters.AddWithValue("?Descrip", TextBox82.Text)
        abc.Parameters.AddWithValue("?Razon", TxtRazon.Text)
        abc.Parameters.AddWithValue("?CodCliente", TextBox157.Text)

        abc.ExecuteNonQuery()
    End Sub
    Private Sub BD17_CheckedChanged(sender As Object, e As EventArgs) Handles BD17.CheckedChanged
        If TxtCot.Text = "" Then
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            On Error Resume Next
            Dim Cot As String = (TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Fec As String = TxtFecha.Value.ToString("yyyy-MM-dd")
            Dim Raz As String = TxtRazon.Text
            Dim RUT As String = TxtRut.Text
            Dim Ate As String = TxtAtencion.Text
            Dim DirAte As String = TxtDireccion.Text
            Dim TelAte As String = TxtphoneC.Text
            Dim CorAte As String = TxtCorreoC.Text
            Dim Ven As String = CboContacto.Text
            Dim TelVen As String = TxtphoneV.Text
            Dim CorVen As String = TxtCorreoV.Text
            Dim Web As String = TxtWeb.Text
            Dim Ref As String = TxtReferencia.Text

            Dim Descrip As String = TextBox86.Text
            Dim Codi As String = TextBox87.Text
            Dim Cant As String = NumericUpDown17.Text
            Dim Mar As String = TextBox88.Text
            Dim Precio As String = TextBox89.Text
            Dim Total As String = TextBox118.Text
            Dim Moneda As String = TextBox180.Text
            Dim ID As String = ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Lin As String = Label65.Text

            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "'
            ,'" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Mar & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()

        End If
        'Para actualizacion de codigo de Cliente 
        Dim actu As String = "UPDATE DATACODCLIENTE SET Codigo= ?Cod, Descripcion= ?Descrip, CODCLIENTE= ?CodCliente where RAZON= ?Razon and Codigo=?Cod"
        Dim abc As New MySqlCommand(actu, conex)

        abc.Parameters.AddWithValue("?Cod", TextBox87.Text)
        abc.Parameters.AddWithValue("?Descrip", TextBox86.Text)
        abc.Parameters.AddWithValue("?Razon", TxtRazon.Text)
        abc.Parameters.AddWithValue("?CodCliente", TextBox158.Text)

        abc.ExecuteNonQuery()
    End Sub
    Private Sub BD18_CheckedChanged(sender As Object, e As EventArgs) Handles BD18.CheckedChanged
        If TxtCot.Text = "" Then
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            On Error Resume Next
            Dim Cot As String = (TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Fec As String = TxtFecha.Value.ToString("yyyy-MM-dd")
            Dim Raz As String = TxtRazon.Text
            Dim RUT As String = TxtRut.Text
            Dim Ate As String = TxtAtencion.Text
            Dim DirAte As String = TxtDireccion.Text
            Dim TelAte As String = TxtphoneC.Text
            Dim CorAte As String = TxtCorreoC.Text
            Dim Ven As String = CboContacto.Text
            Dim TelVen As String = TxtphoneV.Text
            Dim CorVen As String = TxtCorreoV.Text
            Dim Web As String = TxtWeb.Text
            Dim Ref As String = TxtReferencia.Text

            Dim Descrip As String = TextBox90.Text
            Dim Codi As String = TextBox91.Text
            Dim Cant As String = NumericUpDown18.Text
            Dim Mar As String = TextBox92.Text
            Dim Precio As String = TextBox93.Text
            Dim Total As String = TextBox119.Text
            Dim Moneda As String = TextBox181.Text
            Dim ID As String = ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Lin As String = Label66.Text

            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "'
            ,'" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Mar & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()

        End If
        'Para actualizacion de codigo de Cliente 
        Dim actu As String = "UPDATE DATACODCLIENTE SET Codigo= ?Cod, Descripcion= ?Descrip, CODCLIENTE= ?CodCliente where RAZON= ?Razon and Codigo=?Cod"
        Dim abc As New MySqlCommand(actu, conex)

        abc.Parameters.AddWithValue("?Cod", TextBox91.Text)
        abc.Parameters.AddWithValue("?Descrip", TextBox90.Text)
        abc.Parameters.AddWithValue("?Razon", TxtRazon.Text)
        abc.Parameters.AddWithValue("?CodCliente", TextBox159.Text)

        abc.ExecuteNonQuery()
    End Sub
    Private Sub BD19_CheckedChanged(sender As Object, e As EventArgs) Handles BD19.CheckedChanged
        If TxtCot.Text = "" Then
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            On Error Resume Next
            Dim Cot As String = (TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Fec As String = TxtFecha.Value.ToString("yyyy-MM-dd")
            Dim Raz As String = TxtRazon.Text
            Dim RUT As String = TxtRut.Text
            Dim Ate As String = TxtAtencion.Text
            Dim DirAte As String = TxtDireccion.Text
            Dim TelAte As String = TxtphoneC.Text
            Dim CorAte As String = TxtCorreoC.Text
            Dim Ven As String = CboContacto.Text
            Dim TelVen As String = TxtphoneV.Text
            Dim CorVen As String = TxtCorreoV.Text
            Dim Web As String = TxtWeb.Text
            Dim Ref As String = TxtReferencia.Text

            Dim Descrip As String = TextBox94.Text
            Dim Codi As String = TextBox95.Text
            Dim Cant As String = NumericUpDown19.Text
            Dim Mar As String = TextBox96.Text
            Dim Precio As String = TextBox97.Text
            Dim Total As String = TextBox120.Text
            Dim Moneda As String = TextBox182.Text
            Dim ID As String = ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Lin As String = Label67.Text

            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "'
            ,'" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Mar & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()

        End If
        'Para actualizacion de codigo de Cliente 
        Dim actu As String = "UPDATE DATACODCLIENTE SET Codigo= ?Cod, Descripcion= ?Descrip, CODCLIENTE= ?CodCliente where RAZON= ?Razon and Codigo=?Cod"
        Dim abc As New MySqlCommand(actu, conex)

        abc.Parameters.AddWithValue("?Cod", TextBox95.Text)
        abc.Parameters.AddWithValue("?Descrip", TextBox94.Text)
        abc.Parameters.AddWithValue("?Razon", TxtRazon.Text)
        abc.Parameters.AddWithValue("?CodCliente", TextBox160.Text)

        abc.ExecuteNonQuery()
    End Sub
    Private Sub BD20_CheckedChanged(sender As Object, e As EventArgs) Handles BD20.CheckedChanged
        If TxtCot.Text = "" Then
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            On Error Resume Next
            Dim Cot As String = (TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Fec As String = TxtFecha.Value.ToString("yyyy-MM-dd")
            Dim Raz As String = TxtRazon.Text
            Dim RUT As String = TxtRut.Text
            Dim Ate As String = TxtAtencion.Text
            Dim DirAte As String = TxtDireccion.Text
            Dim TelAte As String = TxtphoneC.Text
            Dim CorAte As String = TxtCorreoC.Text
            Dim Ven As String = CboContacto.Text
            Dim TelVen As String = TxtphoneV.Text
            Dim CorVen As String = TxtCorreoV.Text
            Dim Web As String = TxtWeb.Text
            Dim Ref As String = TxtReferencia.Text

            Dim Descrip As String = TextBox98.Text
            Dim Codi As String = TextBox99.Text
            Dim Cant As String = NumericUpDown20.Text
            Dim Mar As String = TextBox100.Text
            Dim Precio As String = TextBox101.Text
            Dim Total As String = TextBox121.Text
            Dim Moneda As String = TextBox183.Text
            Dim ID As String = ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text)
            Dim Lin As String = Label68.Text
            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "'
            ,'" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Mar & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()


        End If
        'Para actualizacion de codigo de Cliente 
        Dim actu As String = "UPDATE DATACODCLIENTE SET Codigo= ?Cod, Descripcion= ?Descrip, CODCLIENTE= ?CodCliente where RAZON= ?Razon and Codigo=?Cod"
        Dim abc As New MySqlCommand(actu, conex)

        abc.Parameters.AddWithValue("?Cod", TextBox99.Text)
        abc.Parameters.AddWithValue("?Descrip", TextBox98.Text)
        abc.Parameters.AddWithValue("?Razon", TxtRazon.Text)
        abc.Parameters.AddWithValue("?CodCliente", TextBox161.Text)

        abc.ExecuteNonQuery()
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If TxtRut.Text = "" Then
            ' Si no lo escribió, mando mensaje de error
            MsgBox("Debe incluir RUT")
            TxtRut.Select()
        Else
            'Para asegurar si esta correcto el registro
            If TxtAtencion.Text > "" Then
                If MessageBox.Show("¿ Seguro que desea insertar este registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

                    On Error Resume Next
                    Dim Raz As String = TxtRazon.Text
                    Dim RUT As String = TxtRut.Text
                    Dim Ate As String = TxtAtencion.Text
                    Dim DirAte As String = TxtDireccion.Text
                    Dim TelAte As String = TxtphoneC.Text
                    Dim CorAte As String = TxtCorreoC.Text
                    Dim Car As String = TextBox162.Text
                    Dim Obj As String = ComboBox3.Text
                    Dim Tip As String = ComboBox1.Text
                    Dim Cla As String = ComboBox5.Text
                    Dim Gen As String = ComboBox2.Text
                    Dim Tra As String = ComboBox4.Text

                    Dim Agregar As String = "INSERT INTO Atenciones (Razon_Social,RUT,Atencion,Direccion,Telefono,Correo,Cargo,Objeto,Tipo,Clase,Genero,Trato) VALUES ('" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "'
                    ,'" & TelAte & "','" & CorAte & "','" & Car & "','" & Obj & "','" & Tip & "','" & Cla & "','" & Gen & "','" & Tra & "')"

                    Dim Seleccion As New MySqlCommand(Agregar, conex)
                    Seleccion.Connection.Open()
                    Seleccion.ExecuteNonQuery()

                    Seleccion.Connection.Close()

                End If
            End If

        End If

    End Sub


#End Region
#Region "PARA PLANILLA DE COTIZACION CLIENTE"
    Private Sub BtnexpAgrosuperAriztia_Click(sender As Object, e As EventArgs) Handles BtnexpAgrosuperAriztiaCLP.Click
        Dim xlibro As Microsoft.Office.Interop.Excel.Application
        Dim strRutaExcel As String

        strRutaExcel = "C:\SOURCESAFRATEC\Planilla de Cotizacion.xlsm"

        xlibro = CreateObject("Excel.Application")
        xlibro.Workbooks.Open(strRutaExcel)

        'Activamos el libro
        xlibro.Workbooks("Planilla de Cotizacion.xlsm").Activate()

        'Activamos la hoja especifica del libro  
        xlibro.Sheets("Planilla de Cot Cliente (CLP) ").Select()

        Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = xlibro.Sheets.Item("Planilla de Cot Cliente (CLP) ")
        xlibro.Visible = True

        ' Razon social
        If TxtRazon.Text <> "" Then xlibro.Range("D15").Value = TxtRazon.Text
        ' Atencion
        If TxtAtencion.Text <> "" Then xlibro.Range("D16").Value = TxtAtencion.Text
        ' RUT
        If TxtRut.Text <> "" Then xlibro.Range("D17").Value = TxtRut.Text
        ' Direccion
        If TxtDireccion.Text <> "" Then xlibro.Range("D18").Value = TxtDireccion.Text
        ' Telefono cliente
        If TxtphoneC.Text <> "" Then xlibro.Range("D19").Value = TxtphoneC.Text
        ' Correo de Cliente
        If TxtCorreoC.Text <> "" Then xlibro.Range("D20").Value = TxtCorreoC.Text

        ' # de Cotizacion
        If TxtCot.Text <> "" Or Txtcot2.Text <> "" Or Txtcot3.Text <> "" Then
            xlibro.Range("I10").Value = "TSA - " + TxtCot.Text + Txtcot2.Text + Txtcot3.Text
        End If

        ' Fecha del Dia
        If TxtFecha.Text <> "" Then xlibro.Range("J16").Value = TxtFecha.Text
        ' Vendedor
        If CboContacto.Text <> "" Then xlibro.Range("J17").Value = CboContacto.Text
        ' Correo de Vendedor
        If TxtCorreoV.Text <> "" Then xlibro.Range("J18").Value = TxtCorreoV.Text
        ' Pagina web
        If TxtWeb.Text <> "" Then xlibro.Range("J19").Value = TxtWeb.Text
        ' Telefono vendedor
        If TxtphoneV.Text <> "" Then xlibro.Range("J20").Value = TxtphoneV.Text

        ' Referencia
        If TxtReferencia.Text <> "" Then xlibro.Range("D21").Value = TxtReferencia.Text

        ' Para primera linea activa de Materiales
        If TextBox1.Text <> "" Then xlibro.Range("D24").Value = TextBox1.Text ' Descripcion de Materiales
        If TextBox2.Text <> "" Then xlibro.Range("C24").Value = TextBox2.Text ' Codigo del Material
        If TextBox142.Text <> "" Then xlibro.Range("H24").Value = TextBox142.Text ' Codigo Cliente
        If NumericUpDown1.Text <> "0" And NumericUpDown1.Text <> "" Then xlibro.Range("I24").Value = NumericUpDown1.Text 'Cantidad del Material
        If TextBox41.Text <> "" Then xlibro.Range("N24").Value = TextBox41.Text ' Costo de Defontana
        If TextBox3.Text <> "" Then xlibro.Range("O24").Value = TextBox3.Text ' Margen (%)
        If TextBox122.Text <> "" Then xlibro.Range("P24").Value = TextBox122.Text ' Para costo de Reposicion articulos de GSI

        ' 2da linea de Materiales
        If TextBox5.Text <> "" Then xlibro.Range("D25").Value = TextBox5.Text ' Descripcion de Materiales
        If TextBox6.Text <> "" Then xlibro.Range("C25").Value = TextBox6.Text ' Codigo del Material
        If TextBox143.Text <> "" Then xlibro.Range("H25").Value = TextBox143.Text ' Codigo Cliente
        If NumericUpDown2.Text <> "0" And NumericUpDown2.Text <> "" Then xlibro.Range("I25").Value = NumericUpDown2.Text 'Cantidad del Material
        If TextBox42.Text <> "" Then xlibro.Range("N25").Value = TextBox42.Text ' Costo de Defontana
        If TextBox7.Text <> "" Then xlibro.Range("O25").Value = TextBox7.Text ' Margen (%)
        If TextBox123.Text <> "" Then xlibro.Range("P25").Value = TextBox123.Text ' Para costo de Reposicion articulos de GSI

        ' 3ra linea de Materiales
        If TextBox9.Text <> "" Then xlibro.Range("D26").Value = TextBox9.Text ' Descripcion de Materiales
        If TextBox10.Text <> "" Then xlibro.Range("C26").Value = TextBox10.Text ' Codigo del Material
        If TextBox144.Text <> "" Then xlibro.Range("H26").Value = TextBox144.Text ' Codigo Cliente
        If NumericUpDown3.Text <> "0" And NumericUpDown3.Text <> "" Then xlibro.Range("I26").Value = NumericUpDown3.Text 'Cantidad del Material
        If TextBox43.Text <> "" Then xlibro.Range("N26").Value = TextBox43.Text ' Costo de Defontana
        If TextBox11.Text <> "" Then xlibro.Range("O26").Value = TextBox11.Text ' Margen (%)
        If TextBox124.Text <> "" Then xlibro.Range("P26").Value = TextBox124.Text ' Para costo de Reposicion articulos de GSI

        ' 4ta linea de Materiales
        If TextBox13.Text <> "" Then xlibro.Range("D27").Value = TextBox13.Text ' Descripcion de Materiales
        If TextBox14.Text <> "" Then xlibro.Range("C27").Value = TextBox14.Text ' Codigo del Material
        If TextBox145.Text <> "" Then xlibro.Range("H27").Value = TextBox145.Text ' Codigo Cliente
        If NumericUpDown4.Text <> "0" And NumericUpDown4.Text <> "" Then xlibro.Range("I27").Value = NumericUpDown4.Text 'Cantidad del Material
        If TextBox44.Text <> "" Then xlibro.Range("N27").Value = TextBox44.Text ' Costo de Defontana
        If TextBox15.Text <> "" Then xlibro.Range("O27").Value = TextBox15.Text ' Margen (%)
        If TextBox125.Text <> "" Then xlibro.Range("P27").Value = TextBox125.Text ' Para costo de Reposicion articulos de GSI

        ' 5ta linea de Materiales
        If TextBox17.Text <> "" Then xlibro.Range("D28").Value = TextBox17.Text ' Descripcion de Materiales
        If TextBox18.Text <> "" Then xlibro.Range("C28").Value = TextBox18.Text ' Codigo del Material
        If TextBox146.Text <> "" Then xlibro.Range("H28").Value = TextBox146.Text ' Codigo Cliente
        If NumericUpDown5.Text <> "0" And NumericUpDown5.Text <> "" Then xlibro.Range("I28").Value = NumericUpDown5.Text 'Cantidad del Material
        If TextBox45.Text <> "" Then xlibro.Range("N28").Value = TextBox45.Text ' Costo de Defontana
        If TextBox19.Text <> "" Then xlibro.Range("O28").Value = TextBox19.Text ' Margen (%)
        If TextBox126.Text <> "" Then xlibro.Range("P28").Value = TextBox126.Text ' Para costo de Reposicion articulos de GSI

        ' 6ta linea de Materiales
        If TextBox21.Text <> "" Then xlibro.Range("D29").Value = TextBox21.Text ' Descripcion de Materiales
        If TextBox22.Text <> "" Then xlibro.Range("C29").Value = TextBox22.Text ' Codigo del Material
        If TextBox147.Text <> "" Then xlibro.Range("H29").Value = TextBox147.Text ' Codigo Cliente
        If NumericUpDown6.Text <> "0" And NumericUpDown6.Text <> "" Then xlibro.Range("I29").Value = NumericUpDown6.Text 'Cantidad del Material
        If TextBox46.Text <> "" Then xlibro.Range("N29").Value = TextBox46.Text ' Costo de Defontana
        If TextBox23.Text <> "" Then xlibro.Range("O29").Value = TextBox23.Text ' Margen (%)
        If TextBox127.Text <> "" Then xlibro.Range("P29").Value = TextBox127.Text ' Para costo de Reposicion articulos de GSI

        ' 7ma linea de Materiales
        If TextBox25.Text <> "" Then xlibro.Range("D30").Value = TextBox25.Text ' Descripcion de Materiales
        If TextBox26.Text <> "" Then xlibro.Range("C30").Value = TextBox26.Text ' Codigo del Material
        If TextBox148.Text <> "" Then xlibro.Range("H30").Value = TextBox148.Text ' Codigo Cliente
        If NumericUpDown7.Text <> "0" And NumericUpDown7.Text <> "" Then xlibro.Range("I30").Value = NumericUpDown7.Text 'Cantidad del Material
        If TextBox47.Text <> "" Then xlibro.Range("N30").Value = TextBox47.Text ' Costo de Defontana
        If TextBox27.Text <> "" Then xlibro.Range("O30").Value = TextBox27.Text ' Margen (%)
        If TextBox128.Text <> "" Then xlibro.Range("P30").Value = TextBox128.Text ' Para costo de Reposicion articulos de GSI

        ' 8va linea de Materiales
        If TextBox29.Text <> "" Then xlibro.Range("D31").Value = TextBox29.Text ' Descripcion de Materiales
        If TextBox30.Text <> "" Then xlibro.Range("C31").Value = TextBox30.Text ' Codigo del Material
        If TextBox149.Text <> "" Then xlibro.Range("H31").Value = TextBox149.Text ' Codigo Cliente
        If NumericUpDown8.Text <> "0" And NumericUpDown8.Text <> "" Then xlibro.Range("I31").Value = NumericUpDown8.Text 'Cantidad del Material
        If TextBox48.Text <> "" Then xlibro.Range("N31").Value = TextBox48.Text ' Costo de Defontana
        If TextBox31.Text <> "" Then xlibro.Range("O31").Value = TextBox31.Text ' Margen (%)
        If TextBox129.Text <> "" Then xlibro.Range("P31").Value = TextBox129.Text ' Para costo de Reposicion articulos de GSI

        ' 9na linea de Materiales
        If TextBox33.Text <> "" Then xlibro.Range("D32").Value = TextBox33.Text ' Descripcion de Materiales
        If TextBox34.Text <> "" Then xlibro.Range("C32").Value = TextBox34.Text ' Codigo del Material
        If TextBox150.Text <> "" Then xlibro.Range("H32").Value = TextBox150.Text ' Codigo Cliente
        If NumericUpDown9.Text <> "0" And NumericUpDown9.Text <> "" Then xlibro.Range("I32").Value = NumericUpDown9.Text 'Cantidad del Material
        If TextBox49.Text <> "" Then xlibro.Range("N32").Value = TextBox49.Text ' Costo de Defontana
        If TextBox35.Text <> "" Then xlibro.Range("O32").Value = TextBox35.Text ' Margen (%)
        If TextBox130.Text <> "" Then xlibro.Range("P32").Value = TextBox130.Text ' Para costo de Reposicion articulos de GSI

        ' 10ma linea de Materiales
        If TextBox37.Text <> "" Then xlibro.Range("D33").Value = TextBox37.Text ' Descripcion de Materiales
        If TextBox38.Text <> "" Then xlibro.Range("C33").Value = TextBox38.Text ' Codigo del Material
        If TextBox151.Text <> "" Then xlibro.Range("H33").Value = TextBox151.Text ' Codigo Cliente
        If NumericUpDown10.Text <> "0" And NumericUpDown10.Text <> "" Then xlibro.Range("I33").Value = NumericUpDown10.Text 'Cantidad del Material
        If TextBox50.Text <> "" Then xlibro.Range("N33").Value = TextBox50.Text ' Costo de Defontana
        If TextBox39.Text <> "" Then xlibro.Range("O33").Value = TextBox39.Text ' Margen (%)
        If TextBox131.Text <> "" Then xlibro.Range("P33").Value = TextBox131.Text ' Para costo de Reposicion articulos de GSI

        ' 11ra linea de Materiales
        If TextBox62.Text <> "" Then xlibro.Range("D34").Value = TextBox62.Text ' Descripcion de Materiales
        If TextBox63.Text <> "" Then xlibro.Range("C34").Value = TextBox63.Text ' Codigo del Material
        If TextBox152.Text <> "" Then xlibro.Range("H34").Value = TextBox152.Text ' Codigo Cliente
        If NumericUpDown11.Text <> "0" And NumericUpDown11.Text <> "" Then xlibro.Range("I34").Value = NumericUpDown11.Text 'Cantidad del Material
        If TextBox102.Text <> "" Then xlibro.Range("N34").Value = TextBox102.Text ' Costo de Defontana
        If TextBox64.Text <> "" Then xlibro.Range("O34").Value = TextBox64.Text ' Margen (%)
        If TextBox132.Text <> "" Then xlibro.Range("P34").Value = TextBox132.Text ' Para costo de Reposicion articulos de GSI

        ' 12da linea de Materiales
        If TextBox66.Text <> "" Then xlibro.Range("D35").Value = TextBox66.Text ' Descripcion de Materiales
        If TextBox67.Text <> "" Then xlibro.Range("C35").Value = TextBox67.Text ' Codigo del Material
        If TextBox153.Text <> "" Then xlibro.Range("H35").Value = TextBox153.Text ' Codigo Cliente
        If NumericUpDown12.Text <> "0" And NumericUpDown12.Text <> "" Then xlibro.Range("I35").Value = NumericUpDown12.Text 'Cantidad del Material
        If TextBox103.Text <> "" Then xlibro.Range("N35").Value = TextBox103.Text ' Costo de Defontana
        If TextBox68.Text <> "" Then xlibro.Range("O35").Value = TextBox68.Text ' Margen (%)
        If TextBox133.Text <> "" Then xlibro.Range("P35").Value = TextBox133.Text ' Para costo de Reposicion articulos de GSI

        ' 13ra linea de Materiales
        If TextBox70.Text <> "" Then xlibro.Range("D36").Value = TextBox70.Text ' Descripcion de Materiales
        If TextBox71.Text <> "" Then xlibro.Range("C36").Value = TextBox71.Text ' Codigo del Material
        If TextBox154.Text <> "" Then xlibro.Range("H36").Value = TextBox154.Text ' Codigo Cliente
        If NumericUpDown13.Text <> "0" And NumericUpDown13.Text <> "" Then xlibro.Range("I36").Value = NumericUpDown13.Text 'Cantidad del Material
        If TextBox104.Text <> "" Then xlibro.Range("N36").Value = TextBox104.Text ' Costo de Defontana
        If TextBox72.Text <> "" Then xlibro.Range("O36").Value = TextBox72.Text ' Margen (%)
        If TextBox134.Text <> "" Then xlibro.Range("P36").Value = TextBox134.Text ' Para costo de Reposicion articulos de GSI

        ' 14ta linea de Materiales
        If TextBox74.Text <> "" Then xlibro.Range("D37").Value = TextBox74.Text ' Descripcion de Materiales
        If TextBox75.Text <> "" Then xlibro.Range("C37").Value = TextBox75.Text ' Codigo del Material
        If TextBox155.Text <> "" Then xlibro.Range("H37").Value = TextBox155.Text ' Codigo Cliente
        If NumericUpDown14.Text <> "0" And NumericUpDown14.Text <> "" Then xlibro.Range("I37").Value = NumericUpDown14.Text 'Cantidad del Material
        If TextBox105.Text <> "" Then xlibro.Range("N37").Value = TextBox105.Text ' Costo de Defontana
        If TextBox76.Text <> "" Then xlibro.Range("O37").Value = TextBox76.Text ' Margen (%)
        If TextBox135.Text <> "" Then xlibro.Range("P37").Value = TextBox135.Text ' Para costo de Reposicion articulos de GSI

        ' 15ta linea de Materiales
        If TextBox78.Text <> "" Then xlibro.Range("D38").Value = TextBox78.Text ' Descripcion de Materiales
        If TextBox79.Text <> "" Then xlibro.Range("C38").Value = TextBox79.Text ' Codigo del Material
        If TextBox156.Text <> "" Then xlibro.Range("H38").Value = TextBox156.Text ' Codigo Cliente
        If NumericUpDown15.Text <> "0" And NumericUpDown15.Text <> "" Then xlibro.Range("I38").Value = NumericUpDown15.Text 'Cantidad del Material
        If TextBox106.Text <> "" Then xlibro.Range("N38").Value = TextBox106.Text ' Costo de Defontana
        If TextBox80.Text <> "" Then xlibro.Range("O38").Value = TextBox80.Text ' Margen (%)
        If TextBox136.Text <> "" Then xlibro.Range("P38").Value = TextBox136.Text ' Para costo de Reposicion articulos de GSI

        ' 16ta linea de Materiales
        If TextBox82.Text <> "" Then xlibro.Range("D39").Value = TextBox82.Text ' Descripcion de Materiales
        If TextBox83.Text <> "" Then xlibro.Range("C39").Value = TextBox83.Text ' Codigo del Material
        If TextBox157.Text <> "" Then xlibro.Range("H39").Value = TextBox157.Text ' Codigo Cliente
        If NumericUpDown16.Text <> "0" And NumericUpDown16.Text <> "" Then xlibro.Range("I39").Value = NumericUpDown16.Text 'Cantidad del Material
        If TextBox107.Text <> "" Then xlibro.Range("N39").Value = TextBox107.Text ' Costo de Defontana
        If TextBox84.Text <> "" Then xlibro.Range("O39").Value = TextBox84.Text ' Margen (%)
        If TextBox137.Text <> "" Then xlibro.Range("P39").Value = TextBox137.Text ' Para costo de Reposicion articulos de GSI

        ' 17ma linea de Materiales
        If TextBox86.Text <> "" Then xlibro.Range("D40").Value = TextBox86.Text ' Descripcion de Materiales
        If TextBox87.Text <> "" Then xlibro.Range("C40").Value = TextBox87.Text ' Codigo del Material
        If TextBox158.Text <> "" Then xlibro.Range("H40").Value = TextBox158.Text ' Codigo Cliente
        If NumericUpDown17.Text <> "0" And NumericUpDown17.Text <> "" Then xlibro.Range("I40").Value = NumericUpDown17.Text 'Cantidad del Material
        If TextBox108.Text <> "" Then xlibro.Range("N40").Value = TextBox108.Text ' Costo de Defontana
        If TextBox88.Text <> "" Then xlibro.Range("O40").Value = TextBox88.Text ' Margen (%)
        If TextBox138.Text <> "" Then xlibro.Range("P40").Value = TextBox138.Text ' Para costo de Reposicion articulos de GSI

        ' 18va linea de Materiales
        If TextBox90.Text <> "" Then xlibro.Range("D41").Value = TextBox90.Text ' Descripcion de Materiales
        If TextBox91.Text <> "" Then xlibro.Range("C41").Value = TextBox91.Text ' Codigo del Material
        If TextBox159.Text <> "" Then xlibro.Range("H41").Value = TextBox159.Text ' Codigo Cliente
        If NumericUpDown18.Text <> "0" And NumericUpDown18.Text <> "" Then xlibro.Range("I41").Value = NumericUpDown18.Text 'Cantidad del Material
        If TextBox109.Text <> "" Then xlibro.Range("N41").Value = TextBox109.Text ' Costo de Defontana
        If TextBox92.Text <> "" Then xlibro.Range("O41").Value = TextBox92.Text ' Margen (%)
        If TextBox139.Text <> "" Then xlibro.Range("P41").Value = TextBox139.Text ' Para costo de Reposicion articulos de GSI

        ' 19na linea de Materiales
        If TextBox94.Text <> "" Then xlibro.Range("D42").Value = TextBox94.Text ' Descripcion de Materiales
        If TextBox95.Text <> "" Then xlibro.Range("C42").Value = TextBox95.Text ' Codigo del Material
        If TextBox160.Text <> "" Then xlibro.Range("H42").Value = TextBox160.Text ' Codigo Cliente
        If NumericUpDown19.Text <> "0" And NumericUpDown19.Text <> "" Then xlibro.Range("I42").Value = NumericUpDown19.Text 'Cantidad del Material
        If TextBox110.Text <> "" Then xlibro.Range("N42").Value = TextBox110.Text ' Costo de Defontana
        If TextBox96.Text <> "" Then xlibro.Range("O42").Value = TextBox96.Text ' Margen (%)
        If TextBox140.Text <> "" Then xlibro.Range("P42").Value = TextBox140.Text ' Para costo de Reposicion articulos de GSI

        ' 20ma linea de Materiales
        If TextBox98.Text <> "" Then xlibro.Range("D43").Value = TextBox98.Text ' Descripcion de Materiales
        If TextBox99.Text <> "" Then xlibro.Range("C43").Value = TextBox99.Text ' Codigo del Material
        If TextBox161.Text <> "" Then xlibro.Range("H43").Value = TextBox161.Text ' Codigo Cliente
        If NumericUpDown20.Text <> "0" And NumericUpDown20.Text <> "" Then xlibro.Range("I43").Value = NumericUpDown20.Text 'Cantidad del Material
        If TextBox111.Text <> "" Then xlibro.Range("N43").Value = TextBox111.Text ' Costo de Defontana
        If TextBox100.Text <> "" Then xlibro.Range("O43").Value = TextBox100.Text ' Margen (%)
        If TextBox141.Text <> "" Then xlibro.Range("P43").Value = TextBox141.Text ' Para costo de Reposicion articulos de GSI

        ' Finalizando con los valores de lugar, plazo, pago, validez
        If CboLugar.Text <> "" Then xlibro.Range("D58").Value = CboLugar.Text
        If TxtPlazo.Text <> "" Then xlibro.Range("D59").Value = TxtPlazo.Text
        If Cbopago.Text <> "" Then xlibro.Range("D60").Value = Cbopago.Text
        If CboValidez.Text <> "" Then xlibro.Range("D61").Value = CboValidez.Text

    End Sub
    Private Sub BtnexpAgrosuperAriztiaUSD_Click(sender As Object, e As EventArgs) Handles BtnexpAgrosuperAriztiaUSD.Click
        Dim xlibro As Microsoft.Office.Interop.Excel.Application
        Dim strRutaExcel As String

        strRutaExcel = "C:\SOURCESAFRATEC\Planilla de Cotizacion.xlsm"

        xlibro = CreateObject("Excel.Application")
        xlibro.Workbooks.Open(strRutaExcel)

        'Activamos el libro
        xlibro.Workbooks("Planilla de Cotizacion.xlsm").Activate()

        'Activamos la hoja especifica del libro  
        xlibro.Sheets("Planilla de Cot Cliente (USD)").Select()

        Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = xlibro.Sheets.Item("Planilla de Cot Cliente (USD)")
        xlibro.Visible = True

        ' Validaciones para evitar celdas vacías
        If TxtRazon.Text <> "" Then xlibro.Range("D15").Value = TxtRazon.Text 'Razon social
        If TxtAtencion.Text <> "" Then xlibro.Range("D16").Value = TxtAtencion.Text 'Atencion
        If TxtRut.Text <> "" Then xlibro.Range("D17").Value = TxtRut.Text 'RUT
        If TxtDireccion.Text <> "" Then xlibro.Range("D18").Value = TxtDireccion.Text 'Direccion
        If TxtphoneC.Text <> "" Then xlibro.Range("D19").Value = TxtphoneC.Text 'Telefono cliente
        If TxtCorreoC.Text <> "" Then xlibro.Range("D20").Value = TxtCorreoC.Text 'Correo de Cliente

        If TxtCot.Text <> "" And Txtcot2.Text <> "" And Txtcot3.Text <> "" Then
            xlibro.Range("I10").Value = "TSA - " + TxtCot.Text + Txtcot2.Text + Txtcot3.Text '# de Cotizacion
        End If

        If TxtFecha.Text <> "" Then xlibro.Range("J16").Value = TxtFecha.Text 'Fecha del Dia

        If CboContacto.Text <> "" Then xlibro.Range("J17").Value = CboContacto.Text 'Vendedor
        If TxtCorreoV.Text <> "" Then xlibro.Range("J18").Value = TxtCorreoV.Text 'Correo de Vendedor
        If TxtWeb.Text <> "" Then xlibro.Range("J19").Value = TxtWeb.Text 'Pagina web
        If TxtphoneV.Text <> "" Then xlibro.Range("J20").Value = TxtphoneV.Text 'Telefono vendedor

        If TxtReferencia.Text <> "" Then xlibro.Range("D21").Value = TxtReferencia.Text 'Referencia

        ' Asignación de valores con comprobación de vacíos
        If TxtRazon.Text <> "" Then xlibro.Range("D15").Value = TxtRazon.Text 'Razon social
        If TxtAtencion.Text <> "" Then xlibro.Range("D16").Value = TxtAtencion.Text 'Atencion
        If TxtRut.Text <> "" Then xlibro.Range("D17").Value = TxtRut.Text 'RUT
        If TxtDireccion.Text <> "" Then xlibro.Range("D18").Value = TxtDireccion.Text 'Direccion
        If TxtphoneC.Text <> "" Then xlibro.Range("D19").Value = TxtphoneC.Text 'Telefono cliente
        If TxtCorreoC.Text <> "" Then xlibro.Range("D20").Value = TxtCorreoC.Text ' Correo de Cliente

        If TxtCot.Text <> "" And Txtcot2.Text <> "" And Txtcot3.Text <> "" Then xlibro.Range("I10").Value = "TSA - " + TxtCot.Text + Txtcot2.Text + Txtcot3.Text ' # de Cotizacion
        If TxtFecha.Text <> "" Then xlibro.Range("J16").Value = TxtFecha.Text ' Fecha del Dia

        If CboContacto.Text <> "" Then xlibro.Range("J17").Value = CboContacto.Text 'Vendedor
        If TxtCorreoV.Text <> "" Then xlibro.Range("J18").Value = TxtCorreoV.Text 'Correo de Vendedor
        If TxtWeb.Text <> "" Then xlibro.Range("J19").Value = TxtWeb.Text 'Pagina web
        If TxtphoneV.Text <> "" Then xlibro.Range("J20").Value = TxtphoneV.Text 'Telefono vendedor

        If TxtReferencia.Text <> "" Then xlibro.Range("D21").Value = TxtReferencia.Text 'Referencia

        ' Para las líneas de materiales, verificamos cada campo antes de asignar el valor
        If TextBox1.Text <> "" Then xlibro.Range("D24").Value = TextBox1.Text 'Descripcion de Materiales
        If TextBox2.Text <> "" Then xlibro.Range("C24").Value = TextBox2.Text 'Codigo del Material
        If TextBox142.Text <> "" Then xlibro.Range("H24").Value = TextBox142.Text 'Codigo Cliente
        If NumericUpDown1.Text <> "0" And NumericUpDown1.Text <> "" Then xlibro.Range("I24").Value = NumericUpDown1.Text 'Cantidad del Material
        If TextBox41.Text <> "" Then xlibro.Range("N24").Value = TextBox41.Text 'Costo de Defontana
        If TextBox3.Text <> "" Then xlibro.Range("O24").Value = TextBox3.Text 'Margen (%)
        If TextBox122.Text <> "" Then xlibro.Range("P24").Value = TextBox122.Text 'Para costo de Reposicion articulos de GSI

        ' 2da línea de Materiales
        If TextBox5.Text <> "" Then xlibro.Range("D25").Value = TextBox5.Text 'Descripcion de Materiales
        If TextBox6.Text <> "" Then xlibro.Range("C25").Value = TextBox6.Text 'Codigo del Material
        If TextBox143.Text <> "" Then xlibro.Range("H25").Value = TextBox143.Text 'Codigo Cliente
        If NumericUpDown2.Text <> "0" And NumericUpDown2.Text <> "" Then xlibro.Range("I25").Value = NumericUpDown2.Text 'Cantidad del Material
        If TextBox42.Text <> "" Then xlibro.Range("N25").Value = TextBox42.Text 'Costo de Defontana
        If TextBox7.Text <> "" Then xlibro.Range("O25").Value = TextBox7.Text 'Margen (%)
        If TextBox123.Text <> "" Then xlibro.Range("P25").Value = TextBox123.Text 'Para costo de Reposicion articulos de GSI

        ' 3ra línea de Materiales
        If TextBox9.Text <> "" Then xlibro.Range("D26").Value = TextBox9.Text 'Descripcion de Materiales
        If TextBox10.Text <> "" Then xlibro.Range("C26").Value = TextBox10.Text 'Codigo del Material
        If TextBox144.Text <> "" Then xlibro.Range("H26").Value = TextBox144.Text 'Codigo Cliente
        If NumericUpDown3.Text <> "0" And NumericUpDown3.Text <> "" Then xlibro.Range("I26").Value = NumericUpDown3.Text 'Cantidad del Material
        If TextBox43.Text <> "" Then xlibro.Range("N26").Value = TextBox43.Text 'Costo de Defontana
        If TextBox11.Text <> "" Then xlibro.Range("O26").Value = TextBox11.Text 'Margen (%)
        If TextBox124.Text <> "" Then xlibro.Range("P26").Value = TextBox124.Text 'Para costo de Reposicion articulos de GSI

        ' 4ta línea de Materiales
        If TextBox13.Text <> "" Then xlibro.Range("D27").Value = TextBox13.Text 'Descripcion de Materiales
        If TextBox14.Text <> "" Then xlibro.Range("C27").Value = TextBox14.Text 'Codigo del Material
        If TextBox145.Text <> "" Then xlibro.Range("H27").Value = TextBox145.Text 'Codigo Cliente
        If NumericUpDown4.Text <> "0" And NumericUpDown4.Text <> "" Then xlibro.Range("I27").Value = NumericUpDown4.Text 'Cantidad del Material
        If TextBox44.Text <> "" Then xlibro.Range("N27").Value = TextBox44.Text 'Costo de Defontana
        If TextBox15.Text <> "" Then xlibro.Range("O27").Value = TextBox15.Text 'Margen (%)
        If TextBox125.Text <> "" Then xlibro.Range("P27").Value = TextBox125.Text 'Para costo de Reposicion articulos de GSI

        ' 5ta línea de Materiales
        If TextBox17.Text <> "" Then xlibro.Range("D28").Value = TextBox17.Text 'Descripcion de Materiales
        If TextBox18.Text <> "" Then xlibro.Range("C28").Value = TextBox18.Text 'Codigo del Material
        If TextBox146.Text <> "" Then xlibro.Range("H28").Value = TextBox146.Text 'Codigo Cliente
        If NumericUpDown5.Text <> "0" And NumericUpDown5.Text <> "" Then xlibro.Range("I28").Value = NumericUpDown5.Text 'Cantidad del Material
        If TextBox45.Text <> "" Then xlibro.Range("N28").Value = TextBox45.Text 'Costo de Defontana
        If TextBox19.Text <> "" Then xlibro.Range("O28").Value = TextBox19.Text 'Margen (%)
        If TextBox126.Text <> "" Then xlibro.Range("P28").Value = TextBox126.Text 'Para costo de Reposicion articulos de GSI

        ' 6ta línea de Materiales
        If TextBox21.Text <> "" Then xlibro.Range("D29").Value = TextBox21.Text 'Descripcion de Materiales
        If TextBox22.Text <> "" Then xlibro.Range("C29").Value = TextBox22.Text 'Codigo del Material
        If TextBox147.Text <> "" Then xlibro.Range("H29").Value = TextBox147.Text 'Codigo Cliente
        If NumericUpDown6.Text <> "0" And NumericUpDown6.Text <> "" Then xlibro.Range("I29").Value = NumericUpDown6.Text 'Cantidad del Material
        If TextBox46.Text <> "" Then xlibro.Range("N29").Value = TextBox46.Text 'Costo de Defontana
        If TextBox23.Text <> "" Then xlibro.Range("O29").Value = TextBox23.Text 'Margen (%)
        If TextBox127.Text <> "" Then xlibro.Range("P29").Value = TextBox127.Text 'Para costo de Reposicion articulos de GSI

        ' 7ma línea de Materiales
        If TextBox25.Text <> "" Then xlibro.Range("D30").Value = TextBox25.Text 'Descripcion de Materiales
        If TextBox26.Text <> "" Then xlibro.Range("C30").Value = TextBox26.Text 'Codigo del Material
        If TextBox148.Text <> "" Then xlibro.Range("H30").Value = TextBox148.Text 'Codigo Cliente
        If NumericUpDown7.Text <> "0" And NumericUpDown7.Text <> "" Then xlibro.Range("I30").Value = NumericUpDown7.Text 'Cantidad del Material
        If TextBox47.Text <> "" Then xlibro.Range("N30").Value = TextBox47.Text 'Costo de Defontana
        If TextBox27.Text <> "" Then xlibro.Range("O30").Value = TextBox27.Text 'Margen (%)
        If TextBox128.Text <> "" Then xlibro.Range("P30").Value = TextBox128.Text 'Para costo de Reposicion articulos de GSI

        ' 8 Linea de Materiales
        If TextBox29.Text <> "" Then xlibro.Range("D31").Value = TextBox29.Text 'Descripcion de Materiales
        If TextBox30.Text <> "" Then xlibro.Range("C31").Value = TextBox30.Text 'Codigo del Material
        If TextBox149.Text <> "" Then xlibro.Range("H31").Value = TextBox149.Text 'Codigo Cliente
        If NumericUpDown8.Text <> "0" And NumericUpDown8.Text <> "" Then xlibro.Range("I31").Value = NumericUpDown8.Text 'Cantidad del Material
        If TextBox48.Text <> "" Then xlibro.Range("N31").Value = TextBox48.Text 'Costo de Defontana
        If TextBox31.Text <> "" Then xlibro.Range("O31").Value = TextBox31.Text 'Margen (%)
        If TextBox129.Text <> "" Then xlibro.Range("P31").Value = TextBox129.Text 'Para costo de Reposicion articulos de GSI

        ' 9 Linea de Materiales
        If TextBox33.Text <> "" Then xlibro.Range("D32").Value = TextBox33.Text 'Descripcion de Materiales
        If TextBox34.Text <> "" Then xlibro.Range("C32").Value = TextBox34.Text 'Codigo del Material
        If TextBox150.Text <> "" Then xlibro.Range("H32").Value = TextBox150.Text 'Codigo Cliente
        If NumericUpDown9.Text <> "0" And NumericUpDown9.Text <> "" Then xlibro.Range("I32").Value = NumericUpDown9.Text 'Cantidad del Material
        If TextBox49.Text <> "" Then xlibro.Range("N32").Value = TextBox49.Text 'Costo de Defontana
        If TextBox35.Text <> "" Then xlibro.Range("O32").Value = TextBox35.Text 'Margen (%)
        If TextBox130.Text <> "" Then xlibro.Range("P32").Value = TextBox130.Text 'Para costo de Reposicion articulos de GSI

        ' 10 Linea de Materiales
        If TextBox37.Text <> "" Then xlibro.Range("D33").Value = TextBox37.Text 'Descripcion de Materiales
        If TextBox38.Text <> "" Then xlibro.Range("C33").Value = TextBox38.Text 'Codigo del Material
        If TextBox151.Text <> "" Then xlibro.Range("H33").Value = TextBox151.Text 'Codigo Cliente
        If NumericUpDown10.Text <> "0" And NumericUpDown10.Text <> "" Then xlibro.Range("I33").Value = NumericUpDown10.Text 'Cantidad del Material
        If TextBox50.Text <> "" Then xlibro.Range("N33").Value = TextBox50.Text 'Costo de Defontana
        If TextBox39.Text <> "" Then xlibro.Range("O33").Value = TextBox39.Text 'Margen (%)
        If TextBox131.Text <> "" Then xlibro.Range("P33").Value = TextBox131.Text 'Para costo de Reposicion articulos de GSI

        ' 11 Linea de Materiales
        If TextBox62.Text <> "" Then xlibro.Range("D34").Value = TextBox62.Text 'Descripcion de Materiales
        If TextBox63.Text <> "" Then xlibro.Range("C34").Value = TextBox63.Text 'Codigo del Material
        If TextBox152.Text <> "" Then xlibro.Range("H34").Value = TextBox152.Text 'Codigo Cliente
        If NumericUpDown11.Text <> "0" And NumericUpDown11.Text <> "" Then xlibro.Range("I34").Value = NumericUpDown11.Text 'Cantidad del Material
        If TextBox102.Text <> "" Then xlibro.Range("N34").Value = TextBox102.Text 'Costo de Defontana
        If TextBox64.Text <> "" Then xlibro.Range("O34").Value = TextBox64.Text 'Margen (%)
        If TextBox132.Text <> "" Then xlibro.Range("P34").Value = TextBox132.Text 'Para costo de Reposicion articulos de GSI

        ' 12 Linea de Materiales
        If TextBox66.Text <> "" Then xlibro.Range("D35").Value = TextBox66.Text 'Descripcion de Materiales
        If TextBox67.Text <> "" Then xlibro.Range("C35").Value = TextBox67.Text 'Codigo del Material
        If TextBox153.Text <> "" Then xlibro.Range("H35").Value = TextBox153.Text 'Codigo Cliente
        If NumericUpDown12.Text <> "0" And NumericUpDown12.Text <> "" Then xlibro.Range("I35").Value = NumericUpDown12.Text 'Cantidad del Material
        If TextBox103.Text <> "" Then xlibro.Range("N35").Value = TextBox103.Text 'Costo de Defontana
        If TextBox68.Text <> "" Then xlibro.Range("O35").Value = TextBox68.Text 'Margen (%)
        If TextBox133.Text <> "" Then xlibro.Range("P35").Value = TextBox133.Text 'Para costo de Reposicion articulos de GSI

        ' 13 Linea de Materiales
        If TextBox70.Text <> "" Then xlibro.Range("D36").Value = TextBox70.Text 'Descripcion de Materiales
        If TextBox71.Text <> "" Then xlibro.Range("C36").Value = TextBox71.Text 'Codigo del Material
        If TextBox154.Text <> "" Then xlibro.Range("H36").Value = TextBox154.Text 'Codigo Cliente
        If NumericUpDown13.Text <> "0" And NumericUpDown13.Text <> "" Then xlibro.Range("I36").Value = NumericUpDown13.Text 'Cantidad del Material
        If TextBox104.Text <> "" Then xlibro.Range("N36").Value = TextBox104.Text 'Costo de Defontana
        If TextBox72.Text <> "" Then xlibro.Range("O36").Value = TextBox72.Text 'Margen (%)
        If TextBox134.Text <> "" Then xlibro.Range("P34").Value = TextBox134.Text 'Para costo de Reposicion articulos de GSI

        ' 14 Linea de Materiales
        If TextBox74.Text <> "" Then xlibro.Range("D37").Value = TextBox74.Text 'Descripcion de Materiales
        If TextBox75.Text <> "" Then xlibro.Range("C37").Value = TextBox75.Text 'Codigo del Material
        If TextBox155.Text <> "" Then xlibro.Range("H37").Value = TextBox155.Text 'Codigo Cliente
        If NumericUpDown14.Text <> "0" And NumericUpDown14.Text <> "" Then xlibro.Range("I37").Value = NumericUpDown14.Text 'Cantidad del Material
        If TextBox105.Text <> "" Then xlibro.Range("N37").Value = TextBox105.Text 'Costo de Defontana
        If TextBox76.Text <> "" Then xlibro.Range("O37").Value = TextBox76.Text 'Margen (%)
        If TextBox135.Text <> "" Then xlibro.Range("P37").Value = TextBox135.Text 'Para costo de Reposicion articulos de GSI

        ' 15 Linea de Materiales
        If TextBox78.Text <> "" Then xlibro.Range("D38").Value = TextBox78.Text 'Descripcion de Materiales
        If TextBox79.Text <> "" Then xlibro.Range("C38").Value = TextBox79.Text 'Codigo del Material
        If TextBox156.Text <> "" Then xlibro.Range("H38").Value = TextBox156.Text 'Codigo Cliente
        If NumericUpDown15.Text <> "0" And NumericUpDown15.Text <> "" Then xlibro.Range("I38").Value = NumericUpDown15.Text 'Cantidad del Material
        If TextBox106.Text <> "" Then xlibro.Range("N38").Value = TextBox106.Text 'Costo de Defontana
        If TextBox80.Text <> "" Then xlibro.Range("O38").Value = TextBox80.Text 'Margen (%)
        If TextBox136.Text <> "" Then xlibro.Range("P38").Value = TextBox136.Text 'Para costo de Reposicion articulos de GSI

        ' 16 Linea de Materiales
        If TextBox82.Text <> "" Then xlibro.Range("D39").Value = TextBox82.Text 'Descripcion de Materiales
        If TextBox83.Text <> "" Then xlibro.Range("C39").Value = TextBox83.Text 'Codigo del Material
        If TextBox157.Text <> "" Then xlibro.Range("H39").Value = TextBox157.Text 'Codigo Cliente
        If NumericUpDown16.Text <> "0" And NumericUpDown16.Text <> "" Then xlibro.Range("I39").Value = NumericUpDown16.Text 'Cantidad del Material
        If TextBox107.Text <> "" Then xlibro.Range("N39").Value = TextBox107.Text 'Costo de Defontana
        If TextBox84.Text <> "" Then xlibro.Range("O39").Value = TextBox84.Text 'Margen (%)
        If TextBox137.Text <> "" Then xlibro.Range("P39").Value = TextBox137.Text 'Para costo de Reposicion articulos de GSI

        ' 17 Linea de Materiales
        If TextBox86.Text <> "" Then xlibro.Range("D40").Value = TextBox86.Text 'Descripcion de Materiales
        If TextBox87.Text <> "" Then xlibro.Range("C40").Value = TextBox87.Text 'Codigo del Material
        If TextBox158.Text <> "" Then xlibro.Range("H40").Value = TextBox158.Text 'Codigo Cliente
        If NumericUpDown17.Text <> "0" And NumericUpDown17.Text <> "" Then xlibro.Range("I40").Value = NumericUpDown17.Text 'Cantidad del Material
        If TextBox108.Text <> "" Then xlibro.Range("N40").Value = TextBox108.Text 'Costo de Defontana
        If TextBox88.Text <> "" Then xlibro.Range("O40").Value = TextBox88.Text 'Margen (%)
        If TextBox138.Text <> "" Then xlibro.Range("P40").Value = TextBox138.Text 'Para costo de Reposicion articulos de GSI

        ' 18 Linea de Materiales
        If TextBox90.Text <> "" Then xlibro.Range("D41").Value = TextBox90.Text 'Descripcion de Materiales
        If TextBox91.Text <> "" Then xlibro.Range("C41").Value = TextBox91.Text 'Codigo del Material
        If TextBox159.Text <> "" Then xlibro.Range("H41").Value = TextBox159.Text 'Codigo Cliente
        If NumericUpDown18.Text <> "0" And NumericUpDown18.Text <> "" Then xlibro.Range("I41").Value = NumericUpDown18.Text 'Cantidad del Material
        If TextBox109.Text <> "" Then xlibro.Range("N41").Value = TextBox109.Text 'Costo de Defontana
        If TextBox92.Text <> "" Then xlibro.Range("O41").Value = TextBox92.Text 'Margen (%)
        If TextBox139.Text <> "" Then xlibro.Range("P41").Value = TextBox139.Text 'Para costo de Reposicion articulos de GSI

        ' 19 Linea de Materiales
        If TextBox94.Text <> "" Then xlibro.Range("D42").Value = TextBox94.Text 'Descripcion de Materiales
        If TextBox95.Text <> "" Then xlibro.Range("C42").Value = TextBox95.Text 'Codigo del Material
        If TextBox160.Text <> "" Then xlibro.Range("H42").Value = TextBox160.Text 'Codigo Cliente
        If NumericUpDown19.Text <> "0" And NumericUpDown19.Text <> "" Then xlibro.Range("I42").Value = NumericUpDown19.Text 'Cantidad del Material
        If TextBox110.Text <> "" Then xlibro.Range("N42").Value = TextBox110.Text 'Costo de Defontana
        If TextBox96.Text <> "" Then xlibro.Range("O42").Value = TextBox96.Text 'Margen (%)
        If TextBox140.Text <> "" Then xlibro.Range("P42").Value = TextBox140.Text 'Para costo de Reposicion articulos de GSI


        ' 20ma línea de Materiales 
        If TextBox98.Text <> "" Then xlibro.Range("D43").Value = TextBox98.Text 'Descripcion de Materiales
        If TextBox99.Text <> "" Then xlibro.Range("C43").Value = TextBox99.Text 'Codigo del Material
        If TextBox161.Text <> "" Then xlibro.Range("H43").Value = TextBox161.Text 'Codigo Cliente
        If NumericUpDown20.Text <> "0" And NumericUpDown20.Text <> "" Then xlibro.Range("I43").Value = NumericUpDown20.Text 'Cantidad del Material
        If TextBox111.Text <> "" Then xlibro.Range("N43").Value = TextBox111.Text 'Costo de Defontana
        If TextBox100.Text <> "" Then xlibro.Range("O43").Value = TextBox100.Text 'Margen (%)
        If TextBox141.Text <> "" Then xlibro.Range("P43").Value = TextBox141.Text 'Para costo de Reposicion articulos de GSI

        ' Datos adicionales
        If CboLugar.Text <> "" Then xlibro.Range("D58").Value = CboLugar.Text
        If TxtPlazo.Text <> "" Then xlibro.Range("D59").Value = TxtPlazo.Text
        If Cbopago.Text <> "" Then xlibro.Range("D60").Value = Cbopago.Text
        If CboValidez.Text <> "" Then xlibro.Range("D61").Value = CboValidez.Text
    End Sub
    Private Sub BtnexpAgrosuperAriztiaEUR_Click(sender As Object, e As EventArgs) Handles BtnexpAgrosuperAriztiaEUR.Click
        Dim xlibro As Microsoft.Office.Interop.Excel.Application
        Dim strRutaExcel As String

        strRutaExcel = "C:\SOURCESAFRATEC\Planilla de Cotizacion.xlsm"

        xlibro = CreateObject("Excel.Application")
        xlibro.Workbooks.Open(strRutaExcel)

        'Activamos el libro
        xlibro.Workbooks("Planilla de Cotizacion.xlsm").Activate()

        'Activamos la hoja especifica del libro  
        xlibro.Sheets("Planilla de Cot Cliente (EUR)").Select()

        Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = xlibro.Sheets.Item("Planilla de Cot Cliente (EUR)")
        xlibro.Visible = True

        ' Validaciones para evitar celdas vacías
        If TxtRazon.Text <> "" Then xlibro.Range("D15").Value = TxtRazon.Text 'Razon social
        If TxtAtencion.Text <> "" Then xlibro.Range("D16").Value = TxtAtencion.Text 'Atencion
        If TxtRut.Text <> "" Then xlibro.Range("D17").Value = TxtRut.Text 'RUT
        If TxtDireccion.Text <> "" Then xlibro.Range("D18").Value = TxtDireccion.Text 'Direccion
        If TxtphoneC.Text <> "" Then xlibro.Range("D19").Value = TxtphoneC.Text 'Telefono cliente
        If TxtCorreoC.Text <> "" Then xlibro.Range("D20").Value = TxtCorreoC.Text 'Correo de Cliente

        If TxtCot.Text <> "" And Txtcot2.Text <> "" And Txtcot3.Text <> "" Then
            xlibro.Range("I10").Value = "TSA - " + TxtCot.Text + Txtcot2.Text + Txtcot3.Text '# de Cotizacion
        End If

        If TxtFecha.Text <> "" Then xlibro.Range("J16").Value = TxtFecha.Text 'Fecha del Dia

        If CboContacto.Text <> "" Then xlibro.Range("J17").Value = CboContacto.Text 'Vendedor
        If TxtCorreoV.Text <> "" Then xlibro.Range("J18").Value = TxtCorreoV.Text 'Correo de Vendedor
        If TxtWeb.Text <> "" Then xlibro.Range("J19").Value = TxtWeb.Text 'Pagina web
        If TxtphoneV.Text <> "" Then xlibro.Range("J20").Value = TxtphoneV.Text 'Telefono vendedor

        If TxtReferencia.Text <> "" Then xlibro.Range("D21").Value = TxtReferencia.Text 'Referencia

        ' Asignación de valores con comprobación de vacíos
        If TxtRazon.Text <> "" Then xlibro.Range("D15").Value = TxtRazon.Text 'Razon social
        If TxtAtencion.Text <> "" Then xlibro.Range("D16").Value = TxtAtencion.Text 'Atencion
        If TxtRut.Text <> "" Then xlibro.Range("D17").Value = TxtRut.Text 'RUT
        If TxtDireccion.Text <> "" Then xlibro.Range("D18").Value = TxtDireccion.Text 'Direccion
        If TxtphoneC.Text <> "" Then xlibro.Range("D19").Value = TxtphoneC.Text 'Telefono cliente
        If TxtCorreoC.Text <> "" Then xlibro.Range("D20").Value = TxtCorreoC.Text ' Correo de Cliente

        If TxtCot.Text <> "" And Txtcot2.Text <> "" And Txtcot3.Text <> "" Then xlibro.Range("I10").Value = "TSA - " + TxtCot.Text + Txtcot2.Text + Txtcot3.Text ' # de Cotizacion
        If TxtFecha.Text <> "" Then xlibro.Range("J16").Value = TxtFecha.Text ' Fecha del Dia

        If CboContacto.Text <> "" Then xlibro.Range("J17").Value = CboContacto.Text 'Vendedor
        If TxtCorreoV.Text <> "" Then xlibro.Range("J18").Value = TxtCorreoV.Text 'Correo de Vendedor
        If TxtWeb.Text <> "" Then xlibro.Range("J19").Value = TxtWeb.Text 'Pagina web
        If TxtphoneV.Text <> "" Then xlibro.Range("J20").Value = TxtphoneV.Text 'Telefono vendedor

        If TxtReferencia.Text <> "" Then xlibro.Range("D21").Value = TxtReferencia.Text 'Referencia

        ' Para las líneas de materiales, verificamos cada campo antes de asignar el valor
        If TextBox1.Text <> "" Then xlibro.Range("D24").Value = TextBox1.Text 'Descripcion de Materiales
        If TextBox2.Text <> "" Then xlibro.Range("C24").Value = TextBox2.Text 'Codigo del Material
        If TextBox142.Text <> "" Then xlibro.Range("H24").Value = TextBox142.Text 'Codigo Cliente
        If NumericUpDown1.Text <> "0" And NumericUpDown1.Text <> "" Then xlibro.Range("I24").Value = NumericUpDown1.Text 'Cantidad del Material
        If TextBox41.Text <> "" Then xlibro.Range("N24").Value = TextBox41.Text 'Costo de Defontana
        If TextBox3.Text <> "" Then xlibro.Range("O24").Value = TextBox3.Text 'Margen (%)
        If TextBox122.Text <> "" Then xlibro.Range("P24").Value = TextBox122.Text 'Para costo de Reposicion articulos de GSI

        ' 2da línea de Materiales
        If TextBox5.Text <> "" Then xlibro.Range("D25").Value = TextBox5.Text 'Descripcion de Materiales
        If TextBox6.Text <> "" Then xlibro.Range("C25").Value = TextBox6.Text 'Codigo del Material
        If TextBox143.Text <> "" Then xlibro.Range("H25").Value = TextBox143.Text 'Codigo Cliente
        If NumericUpDown2.Text <> "0" And NumericUpDown2.Text <> "" Then xlibro.Range("I25").Value = NumericUpDown2.Text 'Cantidad del Material
        If TextBox42.Text <> "" Then xlibro.Range("N25").Value = TextBox42.Text 'Costo de Defontana
        If TextBox7.Text <> "" Then xlibro.Range("O25").Value = TextBox7.Text 'Margen (%)
        If TextBox123.Text <> "" Then xlibro.Range("P25").Value = TextBox123.Text 'Para costo de Reposicion articulos de GSI

        ' 3ra línea de Materiales
        If TextBox9.Text <> "" Then xlibro.Range("D26").Value = TextBox9.Text 'Descripcion de Materiales
        If TextBox10.Text <> "" Then xlibro.Range("C26").Value = TextBox10.Text 'Codigo del Material
        If TextBox144.Text <> "" Then xlibro.Range("H26").Value = TextBox144.Text 'Codigo Cliente
        If NumericUpDown3.Text <> "0" And NumericUpDown3.Text <> "" Then xlibro.Range("I26").Value = NumericUpDown3.Text 'Cantidad del Material
        If TextBox43.Text <> "" Then xlibro.Range("N26").Value = TextBox43.Text 'Costo de Defontana
        If TextBox11.Text <> "" Then xlibro.Range("O26").Value = TextBox11.Text 'Margen (%)
        If TextBox124.Text <> "" Then xlibro.Range("P26").Value = TextBox124.Text 'Para costo de Reposicion articulos de GSI

        ' 4ta línea de Materiales
        If TextBox13.Text <> "" Then xlibro.Range("D27").Value = TextBox13.Text 'Descripcion de Materiales
        If TextBox14.Text <> "" Then xlibro.Range("C27").Value = TextBox14.Text 'Codigo del Material
        If TextBox145.Text <> "" Then xlibro.Range("H27").Value = TextBox145.Text 'Codigo Cliente
        If NumericUpDown4.Text <> "0" And NumericUpDown4.Text <> "" Then xlibro.Range("I27").Value = NumericUpDown4.Text 'Cantidad del Material
        If TextBox44.Text <> "" Then xlibro.Range("N27").Value = TextBox44.Text 'Costo de Defontana
        If TextBox15.Text <> "" Then xlibro.Range("O27").Value = TextBox15.Text 'Margen (%)
        If TextBox125.Text <> "" Then xlibro.Range("P27").Value = TextBox125.Text 'Para costo de Reposicion articulos de GSI

        ' 5ta línea de Materiales
        If TextBox17.Text <> "" Then xlibro.Range("D28").Value = TextBox17.Text 'Descripcion de Materiales
        If TextBox18.Text <> "" Then xlibro.Range("C28").Value = TextBox18.Text 'Codigo del Material
        If TextBox146.Text <> "" Then xlibro.Range("H28").Value = TextBox146.Text 'Codigo Cliente
        If NumericUpDown5.Text <> "0" And NumericUpDown5.Text <> "" Then xlibro.Range("I28").Value = NumericUpDown5.Text 'Cantidad del Material
        If TextBox45.Text <> "" Then xlibro.Range("N28").Value = TextBox45.Text 'Costo de Defontana
        If TextBox19.Text <> "" Then xlibro.Range("O28").Value = TextBox19.Text 'Margen (%)
        If TextBox126.Text <> "" Then xlibro.Range("P28").Value = TextBox126.Text 'Para costo de Reposicion articulos de GSI

        ' 6ta línea de Materiales
        If TextBox21.Text <> "" Then xlibro.Range("D29").Value = TextBox21.Text 'Descripcion de Materiales
        If TextBox22.Text <> "" Then xlibro.Range("C29").Value = TextBox22.Text 'Codigo del Material
        If TextBox147.Text <> "" Then xlibro.Range("H29").Value = TextBox147.Text 'Codigo Cliente
        If NumericUpDown6.Text <> "0" And NumericUpDown6.Text <> "" Then xlibro.Range("I29").Value = NumericUpDown6.Text 'Cantidad del Material
        If TextBox46.Text <> "" Then xlibro.Range("N29").Value = TextBox46.Text 'Costo de Defontana
        If TextBox23.Text <> "" Then xlibro.Range("O29").Value = TextBox23.Text 'Margen (%)
        If TextBox127.Text <> "" Then xlibro.Range("P29").Value = TextBox127.Text 'Para costo de Reposicion articulos de GSI

        ' 7ma línea de Materiales
        If TextBox25.Text <> "" Then xlibro.Range("D30").Value = TextBox25.Text 'Descripcion de Materiales
        If TextBox26.Text <> "" Then xlibro.Range("C30").Value = TextBox26.Text 'Codigo del Material
        If TextBox148.Text <> "" Then xlibro.Range("H30").Value = TextBox148.Text 'Codigo Cliente
        If NumericUpDown7.Text <> "0" And NumericUpDown7.Text <> "" Then xlibro.Range("I30").Value = NumericUpDown7.Text 'Cantidad del Material
        If TextBox47.Text <> "" Then xlibro.Range("N30").Value = TextBox47.Text 'Costo de Defontana
        If TextBox27.Text <> "" Then xlibro.Range("O30").Value = TextBox27.Text 'Margen (%)
        If TextBox128.Text <> "" Then xlibro.Range("P30").Value = TextBox128.Text 'Para costo de Reposicion articulos de GSI

        ' 8 Linea de Materiales
        If TextBox29.Text <> "" Then xlibro.Range("D31").Value = TextBox29.Text 'Descripcion de Materiales
        If TextBox30.Text <> "" Then xlibro.Range("C31").Value = TextBox30.Text 'Codigo del Material
        If TextBox149.Text <> "" Then xlibro.Range("H31").Value = TextBox149.Text 'Codigo Cliente
        If NumericUpDown8.Text <> "0" And NumericUpDown8.Text <> "" Then xlibro.Range("I31").Value = NumericUpDown8.Text 'Cantidad del Material
        If TextBox48.Text <> "" Then xlibro.Range("N31").Value = TextBox48.Text 'Costo de Defontana
        If TextBox31.Text <> "" Then xlibro.Range("O31").Value = TextBox31.Text 'Margen (%)
        If TextBox129.Text <> "" Then xlibro.Range("P31").Value = TextBox129.Text 'Para costo de Reposicion articulos de GSI

        ' 9 Linea de Materiales
        If TextBox33.Text <> "" Then xlibro.Range("D32").Value = TextBox33.Text 'Descripcion de Materiales
        If TextBox34.Text <> "" Then xlibro.Range("C32").Value = TextBox34.Text 'Codigo del Material
        If TextBox150.Text <> "" Then xlibro.Range("H32").Value = TextBox150.Text 'Codigo Cliente
        If NumericUpDown9.Text <> "0" And NumericUpDown9.Text <> "" Then xlibro.Range("I32").Value = NumericUpDown9.Text 'Cantidad del Material
        If TextBox49.Text <> "" Then xlibro.Range("N32").Value = TextBox49.Text 'Costo de Defontana
        If TextBox35.Text <> "" Then xlibro.Range("O32").Value = TextBox35.Text 'Margen (%)
        If TextBox130.Text <> "" Then xlibro.Range("P32").Value = TextBox130.Text 'Para costo de Reposicion articulos de GSI

        ' 10 Linea de Materiales
        If TextBox37.Text <> "" Then xlibro.Range("D33").Value = TextBox37.Text 'Descripcion de Materiales
        If TextBox38.Text <> "" Then xlibro.Range("C33").Value = TextBox38.Text 'Codigo del Material
        If TextBox151.Text <> "" Then xlibro.Range("H33").Value = TextBox151.Text 'Codigo Cliente
        If NumericUpDown10.Text <> "0" And NumericUpDown10.Text <> "" Then xlibro.Range("I33").Value = NumericUpDown10.Text 'Cantidad del Material
        If TextBox50.Text <> "" Then xlibro.Range("N33").Value = TextBox50.Text 'Costo de Defontana
        If TextBox39.Text <> "" Then xlibro.Range("O33").Value = TextBox39.Text 'Margen (%)
        If TextBox131.Text <> "" Then xlibro.Range("P33").Value = TextBox131.Text 'Para costo de Reposicion articulos de GSI

        ' 11 Linea de Materiales
        If TextBox62.Text <> "" Then xlibro.Range("D34").Value = TextBox62.Text 'Descripcion de Materiales
        If TextBox63.Text <> "" Then xlibro.Range("C34").Value = TextBox63.Text 'Codigo del Material
        If TextBox152.Text <> "" Then xlibro.Range("H34").Value = TextBox152.Text 'Codigo Cliente
        If NumericUpDown11.Text <> "0" And NumericUpDown11.Text <> "" Then xlibro.Range("I34").Value = NumericUpDown11.Text 'Cantidad del Material
        If TextBox102.Text <> "" Then xlibro.Range("N34").Value = TextBox102.Text 'Costo de Defontana
        If TextBox64.Text <> "" Then xlibro.Range("O34").Value = TextBox64.Text 'Margen (%)
        If TextBox132.Text <> "" Then xlibro.Range("P34").Value = TextBox132.Text 'Para costo de Reposicion articulos de GSI

        ' 12 Linea de Materiales
        If TextBox66.Text <> "" Then xlibro.Range("D35").Value = TextBox66.Text 'Descripcion de Materiales
        If TextBox67.Text <> "" Then xlibro.Range("C35").Value = TextBox67.Text 'Codigo del Material
        If TextBox153.Text <> "" Then xlibro.Range("H35").Value = TextBox153.Text 'Codigo Cliente
        If NumericUpDown12.Text <> "0" And NumericUpDown12.Text <> "" Then xlibro.Range("I35").Value = NumericUpDown12.Text 'Cantidad del Material
        If TextBox103.Text <> "" Then xlibro.Range("N35").Value = TextBox103.Text 'Costo de Defontana
        If TextBox68.Text <> "" Then xlibro.Range("O35").Value = TextBox68.Text 'Margen (%)
        If TextBox133.Text <> "" Then xlibro.Range("P35").Value = TextBox133.Text 'Para costo de Reposicion articulos de GSI

        ' 13 Linea de Materiales
        If TextBox70.Text <> "" Then xlibro.Range("D36").Value = TextBox70.Text 'Descripcion de Materiales
        If TextBox71.Text <> "" Then xlibro.Range("C36").Value = TextBox71.Text 'Codigo del Material
        If TextBox154.Text <> "" Then xlibro.Range("H36").Value = TextBox154.Text 'Codigo Cliente
        If NumericUpDown13.Text <> "0" And NumericUpDown13.Text <> "" Then xlibro.Range("I36").Value = NumericUpDown13.Text 'Cantidad del Material
        If TextBox104.Text <> "" Then xlibro.Range("N36").Value = TextBox104.Text 'Costo de Defontana
        If TextBox72.Text <> "" Then xlibro.Range("O36").Value = TextBox72.Text 'Margen (%)
        If TextBox134.Text <> "" Then xlibro.Range("P34").Value = TextBox134.Text 'Para costo de Reposicion articulos de GSI

        ' 14 Linea de Materiales
        If TextBox74.Text <> "" Then xlibro.Range("D37").Value = TextBox74.Text 'Descripcion de Materiales
        If TextBox75.Text <> "" Then xlibro.Range("C37").Value = TextBox75.Text 'Codigo del Material
        If TextBox155.Text <> "" Then xlibro.Range("H37").Value = TextBox155.Text 'Codigo Cliente
        If NumericUpDown14.Text <> "0" And NumericUpDown14.Text <> "" Then xlibro.Range("I37").Value = NumericUpDown14.Text 'Cantidad del Material
        If TextBox105.Text <> "" Then xlibro.Range("N37").Value = TextBox105.Text 'Costo de Defontana
        If TextBox76.Text <> "" Then xlibro.Range("O37").Value = TextBox76.Text 'Margen (%)
        If TextBox135.Text <> "" Then xlibro.Range("P37").Value = TextBox135.Text 'Para costo de Reposicion articulos de GSI

        ' 15 Linea de Materiales
        If TextBox78.Text <> "" Then xlibro.Range("D38").Value = TextBox78.Text 'Descripcion de Materiales
        If TextBox79.Text <> "" Then xlibro.Range("C38").Value = TextBox79.Text 'Codigo del Material
        If TextBox156.Text <> "" Then xlibro.Range("H38").Value = TextBox156.Text 'Codigo Cliente
        If NumericUpDown15.Text <> "0" And NumericUpDown15.Text <> "" Then xlibro.Range("I38").Value = NumericUpDown15.Text 'Cantidad del Material
        If TextBox106.Text <> "" Then xlibro.Range("N38").Value = TextBox106.Text 'Costo de Defontana
        If TextBox80.Text <> "" Then xlibro.Range("O38").Value = TextBox80.Text 'Margen (%)
        If TextBox136.Text <> "" Then xlibro.Range("P38").Value = TextBox136.Text 'Para costo de Reposicion articulos de GSI

        ' 16 Linea de Materiales
        If TextBox82.Text <> "" Then xlibro.Range("D39").Value = TextBox82.Text 'Descripcion de Materiales
        If TextBox83.Text <> "" Then xlibro.Range("C39").Value = TextBox83.Text 'Codigo del Material
        If TextBox157.Text <> "" Then xlibro.Range("H39").Value = TextBox157.Text 'Codigo Cliente
        If NumericUpDown16.Text <> "0" And NumericUpDown16.Text <> "" Then xlibro.Range("I39").Value = NumericUpDown16.Text 'Cantidad del Material
        If TextBox107.Text <> "" Then xlibro.Range("N39").Value = TextBox107.Text 'Costo de Defontana
        If TextBox84.Text <> "" Then xlibro.Range("O39").Value = TextBox84.Text 'Margen (%)
        If TextBox137.Text <> "" Then xlibro.Range("P39").Value = TextBox137.Text 'Para costo de Reposicion articulos de GSI

        ' 17 Linea de Materiales
        If TextBox86.Text <> "" Then xlibro.Range("D40").Value = TextBox86.Text 'Descripcion de Materiales
        If TextBox87.Text <> "" Then xlibro.Range("C40").Value = TextBox87.Text 'Codigo del Material
        If TextBox158.Text <> "" Then xlibro.Range("H40").Value = TextBox158.Text 'Codigo Cliente
        If NumericUpDown17.Text <> "0" And NumericUpDown17.Text <> "" Then xlibro.Range("I40").Value = NumericUpDown17.Text 'Cantidad del Material
        If TextBox108.Text <> "" Then xlibro.Range("N40").Value = TextBox108.Text 'Costo de Defontana
        If TextBox88.Text <> "" Then xlibro.Range("O40").Value = TextBox88.Text 'Margen (%)
        If TextBox138.Text <> "" Then xlibro.Range("P40").Value = TextBox138.Text 'Para costo de Reposicion articulos de GSI

        ' 18 Linea de Materiales
        If TextBox90.Text <> "" Then xlibro.Range("D41").Value = TextBox90.Text 'Descripcion de Materiales
        If TextBox91.Text <> "" Then xlibro.Range("C41").Value = TextBox91.Text 'Codigo del Material
        If TextBox159.Text <> "" Then xlibro.Range("H41").Value = TextBox159.Text 'Codigo Cliente
        If NumericUpDown18.Text <> "0" And NumericUpDown18.Text <> "" Then xlibro.Range("I41").Value = NumericUpDown18.Text 'Cantidad del Material
        If TextBox109.Text <> "" Then xlibro.Range("N41").Value = TextBox109.Text 'Costo de Defontana
        If TextBox92.Text <> "" Then xlibro.Range("O41").Value = TextBox92.Text 'Margen (%)
        If TextBox139.Text <> "" Then xlibro.Range("P41").Value = TextBox139.Text 'Para costo de Reposicion articulos de GSI

        ' 19 Linea de Materiales
        If TextBox94.Text <> "" Then xlibro.Range("D42").Value = TextBox94.Text 'Descripcion de Materiales
        If TextBox95.Text <> "" Then xlibro.Range("C42").Value = TextBox95.Text 'Codigo del Material
        If TextBox160.Text <> "" Then xlibro.Range("H42").Value = TextBox160.Text 'Codigo Cliente
        If NumericUpDown19.Text <> "0" And NumericUpDown19.Text <> "" Then xlibro.Range("I42").Value = NumericUpDown19.Text 'Cantidad del Material
        If TextBox110.Text <> "" Then xlibro.Range("N42").Value = TextBox110.Text 'Costo de Defontana
        If TextBox96.Text <> "" Then xlibro.Range("O42").Value = TextBox96.Text 'Margen (%)
        If TextBox140.Text <> "" Then xlibro.Range("P42").Value = TextBox140.Text 'Para costo de Reposicion articulos de GSI


        ' 20ma línea de Materiales 
        If TextBox98.Text <> "" Then xlibro.Range("D43").Value = TextBox98.Text 'Descripcion de Materiales
        If TextBox99.Text <> "" Then xlibro.Range("C43").Value = TextBox99.Text 'Codigo del Material
        If TextBox161.Text <> "" Then xlibro.Range("H43").Value = TextBox161.Text 'Codigo Cliente
        If NumericUpDown20.Text <> "0" And NumericUpDown20.Text <> "" Then xlibro.Range("I43").Value = NumericUpDown20.Text 'Cantidad del Material
        If TextBox111.Text <> "" Then xlibro.Range("N43").Value = TextBox111.Text 'Costo de Defontana
        If TextBox100.Text <> "" Then xlibro.Range("O43").Value = TextBox100.Text 'Margen (%)
        If TextBox141.Text <> "" Then xlibro.Range("P43").Value = TextBox141.Text 'Para costo de Reposicion articulos de GSI

        ' Datos adicionales
        If CboLugar.Text <> "" Then xlibro.Range("D58").Value = CboLugar.Text
        If TxtPlazo.Text <> "" Then xlibro.Range("D59").Value = TxtPlazo.Text
        If Cbopago.Text <> "" Then xlibro.Range("D60").Value = Cbopago.Text
        If CboValidez.Text <> "" Then xlibro.Range("D61").Value = CboValidez.Text

    End Sub


#End Region
#Region "Para Nuevos datos para la atencion"
    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        'Para búsqueda de variables
        Using cxx As New MySqlConnection(cadena2)
            Dim query As String = "SELECT DISTINCT Tipo FROM Partes WHERE Objetivo = '" & Me.ComboBox3.Text.Replace("'", "''") & "'"
            Dim ooo As New MySqlDataAdapter(query, cxx)
            Dim aaa As New DataTable("Parte")
            ooo.Fill(aaa)
            ComboBox1.DataSource = aaa
            ComboBox1.DisplayMember = "Tipo"
            ComboBox1.Refresh()
        End Using
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Using vbc As New MySqlConnection(cadena2)
            Dim query As String = "SELECT DISTINCT Clase FROM Tipo WHERE Tipo = '" & Me.ComboBox1.Text.Replace("'", "''") & "'"
            Dim ppp As New MySqlDataAdapter(query, vbc)
            Dim qqq As New DataTable("Tipo")
            ppp.Fill(qqq)
            ComboBox5.DataSource = qqq
            ComboBox5.DisplayMember = "Clase"
            ComboBox5.Refresh()
        End Using
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        'Para actualizar o modificar atenciones
        If MessageBox.Show("¿Seguro que desea Modificar este registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            If TxtRazon.Text = "" Then
                TxtRazon.Select()
            Else
                On Error Resume Next
                Dim edicion As String = "UPDATE Atenciones SET Razon_Social = '" & TxtRazon.Text.Replace("'", "''") & "', RUT = '" & TxtRut.Text.Replace("'", "''") & "', Atencion = '" & TxtAtencion.Text.Replace("'", "''") & "', Direccion_ate = '" & TxtDireccion.Text.Replace("'", "''") & "', Telefono_ate = '" & TxtphoneC.Text.Replace("'", "''") & "', Correo_ate = '" & TxtCorreoC.Text.Replace("'", "''") & "', Cargo = '" & TextBox162.Text.Replace("'", "''") & "', Objeto = '" & ComboBox3.Text.Replace("'", "''") & "', Tipo = '" & ComboBox1.Text.Replace("'", "''") & "', Clase = '" & ComboBox5.Text.Replace("'", "''") & "', Genero = '" & ComboBox2.Text.Replace("'", "''") & "', Trato = '" & ComboBox4.Text.Replace("'", "''") & "' WHERE ID = '" & TextBox163.Text.Replace("'", "''") & "'"

                Using actualiza As New MySqlCommand(edicion, conex)
                    actualiza.Connection.Open()
                    actualiza.ExecuteNonQuery()
                End Using
            End If
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If MessageBox.Show("¿Seguro que desea Eliminar este registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            If TxtRazon.Text = "" Then
                TxtRazon.Select()
            Else
                Dim ELIMINACION As String = "DELETE FROM Atenciones WHERE ID = '" & TextBox163.Text.Replace("'", "''") & "'"

                Using Borrar As New MySqlCommand(ELIMINACION, conex)
                    Borrar.Connection.Open()
                    Borrar.ExecuteNonQuery()
                End Using
            End If
        End If
    End Sub

#End Region

#Region "Para calculo de Precio Automatico"
    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        On Error Resume Next
        If TextBox41.Text = "" Then
            TextBox3.Text = ""
        Else
            Dim precio As String
            precio = Val(TextBox41.Text) / Val((100 - TextBox3.Text) / 100)
            TextBox4.Text = precio

            Dim total As String
            total = Val(TextBox4.Text) * Val(NumericUpDown1.Text)
            TextBox52.Text = total
            ' Formatear el resultado
            TextBox4.Text = Format(Double.Parse(TextBox4.Text), "#,##0.00")
            TextBox52.Text = Format(Double.Parse(TextBox52.Text), "#,##0.00")

        End If
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        On Error Resume Next
        If TextBox42.Text = "" Then
            TextBox7.Text = ""
        Else
            Dim precio As String
            precio = Val(TextBox42.Text) / Val((100 - TextBox7.Text) / 100)
            TextBox8.Text = precio

            Dim total As String
            total = Val(TextBox8.Text) * Val(NumericUpDown2.Text)
            TextBox53.Text = total

            Me.TextBox8.Text = Format(Val(TextBox8.Text), "#,##0.00")
            Me.TextBox53.Text = Format(Val(TextBox53.Text), "#,##0.00")
        End If
    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged
        On Error Resume Next
        If TextBox43.Text = "" Then
            TextBox11.Text = ""
        Else
            Dim precio As String
            precio = Val(TextBox43.Text) / Val((100 - TextBox11.Text) / 100)
            TextBox12.Text = precio

            Dim total As String
            total = Val(TextBox12.Text) * Val(NumericUpDown3.Text)
            TextBox54.Text = total

            Me.TextBox12.Text = Format(Val(TextBox12.Text), "#,##0.00")
            Me.TextBox54.Text = Format(Val(TextBox54.Text), "#,##0.00")
        End If

    End Sub

    Private Sub TextBox15_TextChanged(sender As Object, e As EventArgs) Handles TextBox15.TextChanged
        On Error Resume Next
        If TextBox44.Text = "" Then
            TextBox15.Text = ""
        Else
            Dim precio As String
            precio = Val(TextBox44.Text) / Val((100 - TextBox15.Text) / 100)
            TextBox16.Text = precio

            Dim total As String
            total = Val(TextBox16.Text) * Val(NumericUpDown4.Text)
            TextBox55.Text = total

            Me.TextBox16.Text = Format(Val(TextBox16.Text), "#,##0.00")
            Me.TextBox55.Text = Format(Val(TextBox55.Text), "#,##0.00")
        End If


    End Sub

    Private Sub TextBox19_TextChanged(sender As Object, e As EventArgs) Handles TextBox19.TextChanged
        On Error Resume Next
        If TextBox45.Text = "" Then
            TextBox19.Text = ""
        Else
            Dim precio As String
            precio = Val(TextBox45.Text) / Val((100 - TextBox19.Text) / 100)
            TextBox20.Text = precio

            Dim total As String
            total = Val(TextBox20.Text) * Val(NumericUpDown5.Text)
            TextBox56.Text = total

            Me.TextBox20.Text = Format(Val(TextBox20.Text), "#,##0.00")
            Me.TextBox56.Text = Format(Val(TextBox56.Text), "#,##0.00")
        End If

    End Sub

    Private Sub TextBox23_TextChanged(sender As Object, e As EventArgs) Handles TextBox23.TextChanged
        On Error Resume Next
        If TextBox46.Text = "" Then
            TextBox23.Text = ""
        Else
            Dim precio As String
            precio = Val(TextBox46.Text) / Val((100 - TextBox23.Text) / 100)
            TextBox24.Text = precio

            Dim total As String
            total = Val(TextBox24.Text) * Val(NumericUpDown6.Text)
            TextBox57.Text = total

            Me.TextBox24.Text = Format(Val(TextBox24.Text), "#,##0.00")
            Me.TextBox57.Text = Format(Val(TextBox57.Text), "#,##0.00")
        End If

    End Sub

    Private Sub TextBox27_TextChanged(sender As Object, e As EventArgs) Handles TextBox27.TextChanged
        On Error Resume Next
        If TextBox47.Text = "" Then
            TextBox27.Text = ""
        Else
            Dim precio As String
            precio = Val(TextBox47.Text) / Val((100 - TextBox27.Text) / 100)
            TextBox28.Text = precio

            Dim total As String
            total = Val(TextBox28.Text) * Val(NumericUpDown7.Text)
            TextBox58.Text = total

            Me.TextBox28.Text = Format(Val(TextBox28.Text), "#,##0.00")
            Me.TextBox58.Text = Format(Val(TextBox58.Text), "#,##0.00")
        End If
    End Sub

    Private Sub TextBox31_TextChanged(sender As Object, e As EventArgs) Handles TextBox31.TextChanged
        On Error Resume Next
        If TextBox48.Text = "" Then
            TextBox31.Text = ""
        Else
            Dim precio As String
            precio = Val(TextBox48.Text) / Val((100 - TextBox31.Text) / 100)
            TextBox32.Text = precio

            Dim total As String
            total = Val(TextBox32.Text) * Val(NumericUpDown8.Text)
            TextBox59.Text = total

            Me.TextBox32.Text = Format(Val(TextBox32.Text), "#,##0.00")
            Me.TextBox59.Text = Format(Val(TextBox59.Text), "#,##0.00")
        End If
    End Sub

    Private Sub TextBox35_TextChanged(sender As Object, e As EventArgs) Handles TextBox35.TextChanged
        On Error Resume Next
        If TextBox49.Text = "" Then
            TextBox35.Text = ""
        Else
            Dim precio As String
            precio = Val(TextBox49.Text) / Val((100 - TextBox35.Text) / 100)
            TextBox36.Text = precio

            Dim total As String
            total = Val(TextBox36.Text) * Val(NumericUpDown9.Text)
            TextBox60.Text = total

            Me.TextBox36.Text = Format(Val(TextBox36.Text), "#,##0.00")
            Me.TextBox60.Text = Format(Val(TextBox60.Text), "#,##0.00")
        End If
    End Sub

    Private Sub TextBox39_TextChanged(sender As Object, e As EventArgs) Handles TextBox39.TextChanged
        On Error Resume Next
        If TextBox50.Text = "" Then
            TextBox39.Text = ""
        Else
            Dim precio As String
            precio = Val(TextBox50.Text) / Val((100 - TextBox39.Text) / 100)
            TextBox40.Text = precio

            Dim total As String
            total = Val(TextBox40.Text) * Val(NumericUpDown10.Text)
            TextBox61.Text = total

            Me.TextBox40.Text = Format(Val(TextBox40.Text), "#,##0.00")
            Me.TextBox61.Text = Format(Val(TextBox61.Text), "#,##0.00")
        End If
    End Sub

    Private Sub TextBox64_TextChanged(sender As Object, e As EventArgs) Handles TextBox64.TextChanged
        On Error Resume Next
        If TextBox102.Text = "" Then
            TextBox64.Text = ""
        Else
            Dim precio As String
            precio = Val(TextBox102.Text) / Val((100 - TextBox64.Text) / 100)
            TextBox65.Text = precio

            Dim total As String
            total = Val(TextBox65.Text) * Val(NumericUpDown11.Text)
            TextBox112.Text = total

            Me.TextBox65.Text = Format(Val(TextBox65.Text), "#,##0.00")
            Me.TextBox112.Text = Format(Val(TextBox112.Text), "#,##0.00")
        End If

    End Sub

    Private Sub TextBox68_TextChanged(sender As Object, e As EventArgs) Handles TextBox68.TextChanged
        On Error Resume Next
        If TextBox103.Text = "" Then
            TextBox68.Text = ""
        Else
            Dim precio As String
            precio = Val(TextBox103.Text) / Val((100 - TextBox68.Text) / 100)
            TextBox69.Text = precio

            Dim total As String
            total = Val(TextBox69.Text) * Val(NumericUpDown12.Text)
            TextBox113.Text = total

            Me.TextBox69.Text = Format(Val(TextBox69.Text), "#,##0.00")
            Me.TextBox113.Text = Format(Val(TextBox113.Text), "#,##0.00")
        End If

    End Sub

    Private Sub TextBox72_TextChanged(sender As Object, e As EventArgs) Handles TextBox72.TextChanged
        On Error Resume Next
        If TextBox104.Text = "" Then
            TextBox72.Text = ""
        Else
            Dim precio As String
            precio = Val(TextBox104.Text) / Val((100 - TextBox72.Text) / 100)
            TextBox73.Text = precio

            Dim total As String
            total = Val(TextBox73.Text) * Val(NumericUpDown13.Text)
            TextBox114.Text = total

            Me.TextBox73.Text = Format(Val(TextBox73.Text), "#,##0.00")
            Me.TextBox114.Text = Format(Val(TextBox114.Text), "#,##0.00")
        End If
    End Sub

    Private Sub TextBox76_TextChanged(sender As Object, e As EventArgs) Handles TextBox76.TextChanged
        On Error Resume Next
        If TextBox105.Text = "" Then
            TextBox76.Text = ""
        Else
            Dim precio As String
            precio = Val(TextBox105.Text) / Val((100 - TextBox76.Text) / 100)
            TextBox77.Text = precio

            Dim total As String
            total = Val(TextBox77.Text) * Val(NumericUpDown14.Text)
            TextBox115.Text = total

            Me.TextBox77.Text = Format(Val(TextBox77.Text), "#,##0.00")
            Me.TextBox115.Text = Format(Val(TextBox115.Text), "#,##0.00")
        End If
    End Sub

    Private Sub TextBox80_TextChanged(sender As Object, e As EventArgs) Handles TextBox80.TextChanged
        On Error Resume Next
        If TextBox106.Text = "" Then
            TextBox80.Text = ""
        Else
            Dim precio As String
            precio = Val(TextBox106.Text) / Val((100 - TextBox80.Text) / 100)
            TextBox81.Text = precio

            Dim total As String
            total = Val(TextBox81.Text) * Val(NumericUpDown15.Text)
            TextBox116.Text = total

            Me.TextBox81.Text = Format(Val(TextBox81.Text), "#,##0.00")
            Me.TextBox116.Text = Format(Val(TextBox116.Text), "#,##0.00")
        End If
    End Sub

    Private Sub TextBox84_TextChanged(sender As Object, e As EventArgs) Handles TextBox84.TextChanged
        On Error Resume Next
        If TextBox107.Text = "" Then
            TextBox84.Text = ""
        Else
            Dim precio As String
            precio = Val(TextBox107.Text) / Val((100 - TextBox84.Text) / 100)
            TextBox85.Text = precio

            Dim total As String
            total = Val(TextBox85.Text) * Val(NumericUpDown16.Text)
            TextBox117.Text = total


            Me.TextBox85.Text = Format(Val(TextBox85.Text), "#,##0.00")
            Me.TextBox117.Text = Format(Val(TextBox117.Text), "#,##0.00")
        End If
    End Sub

    Private Sub TextBox88_TextChanged(sender As Object, e As EventArgs) Handles TextBox88.TextChanged
        On Error Resume Next
        If TextBox108.Text = "" Then
            TextBox88.Text = ""
        Else
            Dim precio As String
            precio = Val(TextBox108.Text) / Val((100 - TextBox88.Text) / 100)
            TextBox89.Text = precio

            Dim total As String
            total = Val(TextBox89.Text) * Val(NumericUpDown17.Text)
            TextBox118.Text = total


            Me.TextBox89.Text = Format(Val(TextBox89.Text), "#,##0.00")
            Me.TextBox118.Text = Format(Val(TextBox118.Text), "#,##0.00")
        End If
    End Sub

    Private Sub TextBox92_TextChanged(sender As Object, e As EventArgs) Handles TextBox92.TextChanged
        On Error Resume Next
        If TextBox109.Text = "" Then
            TextBox92.Text = ""
        Else
            Dim precio As String
            precio = Val(TextBox109.Text) / Val((100 - TextBox92.Text) / 100)
            TextBox93.Text = precio

            Dim total As String
            total = Val(TextBox93.Text) * Val(NumericUpDown18.Text)
            TextBox119.Text = total

            Me.TextBox93.Text = Format(Val(TextBox93.Text), "#,##0.00")
            Me.TextBox119.Text = Format(Val(TextBox119.Text), "#,##0.00")
        End If


    End Sub

    Private Sub TextBox96_TextChanged(sender As Object, e As EventArgs) Handles TextBox96.TextChanged
        On Error Resume Next
        If TextBox110.Text = "" Then
            TextBox96.Text = ""
        Else
            Dim precio As String
            precio = Val(TextBox110.Text) / Val((100 - TextBox96.Text) / 100)
            TextBox97.Text = precio

            Dim total As String
            total = Val(TextBox97.Text) * Val(NumericUpDown19.Text)
            TextBox120.Text = total

            Me.TextBox97.Text = Format(Val(TextBox97.Text), "#,##0.00")
            Me.TextBox120.Text = Format(Val(TextBox120.Text), "#,##0.00")
        End If
    End Sub

    Private Sub TextBox100_TextChanged(sender As Object, e As EventArgs) Handles TextBox100.TextChanged
        On Error Resume Next
        If TextBox111.Text = "" Then
            TextBox100.Text = ""
        Else
            Dim precio As String
            precio = Val(TextBox111.Text) / Val((100 - TextBox100.Text) / 100)
            TextBox101.Text = precio

            Dim total As String
            total = Val(TextBox101.Text) * Val(NumericUpDown20.Text)
            TextBox121.Text = total

            Me.TextBox101.Text = Format(Val(TextBox101.Text), "#,##0.00")
            Me.TextBox121.Text = Format(Val(TextBox121.Text), "#,##0.00")
        End If
    End Sub


#End Region
#Region "PARA CALCULO DE MARGEN CON PRECIO SUGERIDO"
    Private Sub TextBox185_TextChanged(sender As Object, e As EventArgs) Handles TextBox185.TextChanged
        If TextBox41.Text = "" Then
        Else
            Dim utilidad As Double
            utilidad = (1 - (Val(TextBox41.Text) / Val(TextBox185.Text)))
            TextBox205.Text = FormatPercent(utilidad)

        End If
    End Sub

    Private Sub TextBox186_TextChanged(sender As Object, e As EventArgs) Handles TextBox186.TextChanged
        If TextBox42.Text = "" Then
        Else
            Dim utilidad As Double
            utilidad = (1 - (Val(TextBox42.Text) / Val(TextBox186.Text)))
            TextBox206.Text = FormatPercent(utilidad)

        End If

    End Sub

    Private Sub TextBox187_TextChanged(sender As Object, e As EventArgs) Handles TextBox187.TextChanged
        If TextBox43.Text = "" Then
        Else
            Dim utilidad As Double
            utilidad = (1 - (Val(TextBox43.Text) / Val(TextBox187.Text)))
            TextBox207.Text = FormatPercent(utilidad)

        End If
    End Sub

    Private Sub TextBox188_TextChanged(sender As Object, e As EventArgs) Handles TextBox188.TextChanged
        If TextBox44.Text = "" Then
        Else
            Dim utilidad As Double
            utilidad = (1 - (Val(TextBox44.Text) / Val(TextBox188.Text)))
            TextBox208.Text = FormatPercent(utilidad)

        End If
    End Sub

    Private Sub TextBox189_TextChanged(sender As Object, e As EventArgs) Handles TextBox189.TextChanged
        If TextBox45.Text = "" Then
        Else
            Dim utilidad As Double
            utilidad = (1 - (Val(TextBox45.Text) / Val(TextBox189.Text)))
            TextBox209.Text = FormatPercent(utilidad)

        End If
    End Sub

    Private Sub TextBox190_TextChanged(sender As Object, e As EventArgs) Handles TextBox190.TextChanged
        If TextBox46.Text = "" Then
        Else
            Dim utilidad As Double
            utilidad = (1 - (Val(TextBox46.Text) / Val(TextBox190.Text)))
            TextBox210.Text = FormatPercent(utilidad)

        End If
    End Sub

    Private Sub TextBox191_TextChanged(sender As Object, e As EventArgs) Handles TextBox191.TextChanged
        If TextBox47.Text = "" Then
        Else
            Dim utilidad As Double
            utilidad = (1 - (Val(TextBox47.Text) / Val(TextBox191.Text)))
            TextBox211.Text = FormatPercent(utilidad)

        End If
    End Sub

    Private Sub TextBox192_TextChanged(sender As Object, e As EventArgs) Handles TextBox192.TextChanged
        If TextBox48.Text = "" Then
        Else
            Dim utilidad As Double
            utilidad = (1 - (Val(TextBox48.Text) / Val(TextBox192.Text)))
            TextBox212.Text = FormatPercent(utilidad)

        End If
    End Sub

    Private Sub TextBox193_TextChanged(sender As Object, e As EventArgs) Handles TextBox193.TextChanged
        If TextBox49.Text = "" Then
        Else
            Dim utilidad As Double
            utilidad = (1 - (Val(TextBox49.Text) / Val(TextBox193.Text)))
            TextBox213.Text = FormatPercent(utilidad)

        End If
    End Sub

    Private Sub TextBox194_TextChanged(sender As Object, e As EventArgs) Handles TextBox194.TextChanged
        If TextBox50.Text = "" Then
        Else
            Dim utilidad As Double
            utilidad = (1 - (Val(TextBox50.Text) / Val(TextBox194.Text)))
            TextBox214.Text = FormatPercent(utilidad)

        End If
    End Sub

    Private Sub TextBox195_TextChanged(sender As Object, e As EventArgs) Handles TextBox195.TextChanged
        If TextBox102.Text = "" Then
        Else
            Dim utilidad As Double
            utilidad = (1 - (Val(TextBox102.Text) / Val(TextBox195.Text)))
            TextBox215.Text = FormatPercent(utilidad)

        End If
    End Sub

    Private Sub TextBox196_TextChanged(sender As Object, e As EventArgs) Handles TextBox196.TextChanged
        If TextBox103.Text = "" Then
        Else
            Dim utilidad As Double
            utilidad = (1 - (Val(TextBox103.Text) / Val(TextBox196.Text)))
            TextBox216.Text = FormatPercent(utilidad)

        End If
    End Sub

    Private Sub TextBox197_TextChanged(sender As Object, e As EventArgs) Handles TextBox197.TextChanged
        If TextBox104.Text = "" Then
        Else
            Dim utilidad As Double
            utilidad = (1 - (Val(TextBox104.Text) / Val(TextBox197.Text)))
            TextBox217.Text = FormatPercent(utilidad)

        End If
    End Sub

    Private Sub TextBox198_TextChanged(sender As Object, e As EventArgs) Handles TextBox198.TextChanged
        If TextBox105.Text = "" Then
        Else
            Dim utilidad As Double
            utilidad = (1 - (Val(TextBox105.Text) / Val(TextBox198.Text)))
            TextBox218.Text = FormatPercent(utilidad)

        End If
    End Sub

    Private Sub TextBox199_TextChanged(sender As Object, e As EventArgs) Handles TextBox199.TextChanged
        If TextBox106.Text = "" Then
        Else
            Dim utilidad As Double
            utilidad = (1 - (Val(TextBox106.Text) / Val(TextBox199.Text)))
            TextBox219.Text = FormatPercent(utilidad)

        End If
    End Sub

    Private Sub TextBox200_TextChanged(sender As Object, e As EventArgs) Handles TextBox200.TextChanged
        If TextBox107.Text = "" Then
        Else
            Dim utilidad As Double
            utilidad = (1 - (Val(TextBox107.Text) / Val(TextBox200.Text)))
            TextBox220.Text = FormatPercent(utilidad)

        End If
    End Sub

    Private Sub TextBox201_TextChanged(sender As Object, e As EventArgs) Handles TextBox201.TextChanged
        If TextBox108.Text = "" Then
        Else
            Dim utilidad As Double
            utilidad = (1 - (Val(TextBox108.Text) / Val(TextBox201.Text)))
            TextBox221.Text = FormatPercent(utilidad)

        End If
    End Sub

    Private Sub TextBox202_TextChanged(sender As Object, e As EventArgs) Handles TextBox202.TextChanged
        If TextBox109.Text = "" Then
        Else
            Dim utilidad As Double
            utilidad = (1 - (Val(TextBox109.Text) / Val(TextBox202.Text)))
            TextBox222.Text = FormatPercent(utilidad)

        End If
    End Sub

    Private Sub TextBox203_TextChanged(sender As Object, e As EventArgs) Handles TextBox203.TextChanged
        If TextBox110.Text = "" Then
        Else
            Dim utilidad As Double
            utilidad = (1 - (Val(TextBox110.Text) / Val(TextBox203.Text)))
            TextBox223.Text = FormatPercent(utilidad)

        End If
    End Sub

    Private Sub TextBox204_TextChanged(sender As Object, e As EventArgs) Handles TextBox204.TextChanged
        If TextBox111.Text = "" Then
        Else
            Dim utilidad As Double
            utilidad = (1 - (Val(TextBox111.Text) / Val(TextBox204.Text)))
            TextBox224.Text = FormatPercent(utilidad)

        End If
    End Sub
    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs) Handles TextBox52.TextChanged, TextBox53.TextChanged, TextBox54.TextChanged, TextBox55.TextChanged, TextBox56.TextChanged, TextBox57.TextChanged, TextBox58.TextChanged, TextBox59.TextChanged, TextBox60.TextChanged, TextBox61.TextChanged, TextBox112.TextChanged, TextBox113.TextChanged, TextBox114.TextChanged, TextBox115.TextChanged, TextBox116.TextChanged, TextBox117.TextChanged, TextBox118.TextChanged, TextBox119.TextChanged, TextBox120.TextChanged, TextBox121.TextChanged
        ' Declaración de variables
        Dim total As Double = 0.0
        Dim textBoxes() As TextBox = {TextBox52, TextBox53, TextBox54, TextBox55, TextBox56, TextBox57, TextBox58, TextBox59, TextBox60, TextBox61, TextBox112, TextBox113, TextBox114, TextBox115, TextBox116, TextBox117, TextBox118, TextBox119, TextBox120, TextBox121}

        ' Iterar sobre los TextBox y sumar sus valores
        For Each tb As TextBox In textBoxes
            Dim value As Double = 0.0
            Double.TryParse(tb.Text, value)
            total += value
        Next

        ' Asignar el total al TextBox226
        TextBox226.Text = total.ToString()
        Me.TextBox226.Text = Format(Val(TextBox226.Text), "#,##0.00")
        Label35.Text = TextBox164.Text

    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged
        If ComboBox6 IsNot Nothing AndAlso TxtRut IsNot Nothing Then
            ' Visibilidad basada en la selección de ComboBox6
            Select Case ComboBox6.Text
                Case "CLP"
                    BtnExportarCLP.Visible = True
                    BtnExportarUSD.Visible = False
                    BtnExportarEUR.Visible = False
                    TxtUSDEUR.Visible = True
                    Label36.Visible = True
                Case "USD"
                    BtnExportarCLP.Visible = False
                    BtnExportarUSD.Visible = True
                    BtnExportarEUR.Visible = False
                    TxtUSDEUR.Visible = True
                    Label36.Visible = True
                Case "EUR"
                    BtnExportarCLP.Visible = False
                    BtnExportarUSD.Visible = False
                    BtnExportarEUR.Visible = True
                    TxtUSDEUR.Visible = True
                    Label36.Visible = True

                Case Else
                    BtnExportarCLP.Visible = False
                    BtnExportarUSD.Visible = False
                    BtnExportarEUR.Visible = False
                    TxtUSDEUR.Visible = False
                    Label36.Visible = True

            End Select

            ' Visibilidad basada en TxtRut.Text
            Select Case TxtRut.Text
                Case "88.680.500-4", "82.366.700-0", "82.557.000-4", "77.835.800-K", "96.590.000-4", "85.120.400-8", "76.614.620-1"
                    Select Case ComboBox6.Text
                        Case "CLP"
                            BtnexpAgrosuperAriztiaCLP.Visible = True
                            BtnexpAgrosuperAriztiaUSD.Visible = False
                            BtnexpAgrosuperAriztiaEUR.Visible = False
                        Case "USD"
                            BtnexpAgrosuperAriztiaCLP.Visible = False
                            BtnexpAgrosuperAriztiaUSD.Visible = True
                            BtnexpAgrosuperAriztiaEUR.Visible = False
                        Case "EUR"
                            BtnexpAgrosuperAriztiaCLP.Visible = False
                            BtnexpAgrosuperAriztiaUSD.Visible = False
                            BtnexpAgrosuperAriztiaEUR.Visible = True
                    End Select
                Case Else
                    ' Desactivar BtnexpAgrosuperAriztia independientemente de la selección ComboBox6
                    BtnexpAgrosuperAriztiaCLP.Visible = False
                    BtnexpAgrosuperAriztiaUSD.Visible = False
                    BtnexpAgrosuperAriztiaEUR.Visible = False
            End Select
        End If

    End Sub
    ' Agrega un Timer en el formulario y configúralo: 
    ' Interval = 300 (milisegundos) y Enabled = False

    Private Sub TxtRazon_TextChanged(sender As Object, e As EventArgs) Handles TxtRazon.TextChanged
        TimerBusqueda.Stop() ' Detiene el timer para evitar consultas innecesarias
        TimerBusqueda.Start() ' Inicia el timer cuando el usuario escribe
    End Sub

    Private Sub TimerBusqueda_Tick(sender As Object, e As EventArgs) Handles TimerBusqueda.Tick
        TimerBusqueda.Stop() ' Detiene el timer al iniciar la búsqueda

        Dim Razon As String = TxtRazon.Text.Trim()

        ' Evita consultar si está vacío
        If Razon = "" Then
            DGRazonSocial.DataSource = Nothing
            Return
        End If

        ' Construcción de la consulta SQL
        Dim sqlcliente As String = "SELECT * FROM Clientes WHERE Razon_Social LIKE '%" & Razon & "%' " & " UNION " &
                                   "SELECT * FROM ClienteNODEF WHERE `Razon Social` LIKE '%" & Razon & "%'"

        ' Ejecuta la consulta
        Cargar_MySQLCliente(sqlcliente, DGRazonSocial)
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        If TxtRazon.Text <> "" Then
            Dim Raz As String = TxtRazon.Text
            Dim RUT As String = TxtRut.Text

            ' Corregida la sintaxis: doble comilla simple al final eliminada
            Dim Agregar As String = "INSERT INTO ClienteNODEF (`Razon Social`, `RUT`) VALUES ('" & Raz & "', '" & RUT & "')"

            Try
                Dim Seleccion As New MySqlCommand(Agregar, conex)
                Seleccion.Connection.Open()
                Seleccion.ExecuteNonQuery()
                Seleccion.Connection.Close()

                MessageBox.Show("Cliente agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error al agregar cliente: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Por favor ingrese la razón social.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


#End Region
End Class



