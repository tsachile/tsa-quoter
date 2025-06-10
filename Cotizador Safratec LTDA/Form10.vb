Imports MySql.Data.MySqlClient

Public Class Form10
    ' Conexión a la base de datos
    Private ReadOnly cadenaConexion As String = "Server=162.144.3.49; Database=tsachile_cotizador; Uid=tsachile_admin; Pwd=17543593apple"
    Private ReadOnly conex As New MySqlConnection(cadenaConexion)
    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub
    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AjustarEscalaFormulario()
        CargarComboboxes()
        LimpiarControles()

        CalcularTotales()
        ' Para Mayuscula 
        TextBox1.CharacterCasing = CharacterCasing.Upper
        TextBox13.CharacterCasing = CharacterCasing.Upper

        TextBox14.CharacterCasing = CharacterCasing.Upper
        TextBox19.CharacterCasing = CharacterCasing.Upper
        TextBox24.CharacterCasing = CharacterCasing.Upper
        TextBox29.CharacterCasing = CharacterCasing.Upper
        TextBox34.CharacterCasing = CharacterCasing.Upper
        TextBox39.CharacterCasing = CharacterCasing.Upper
        TextBox44.CharacterCasing = CharacterCasing.Upper
        TextBox49.CharacterCasing = CharacterCasing.Upper
        TextBox54.CharacterCasing = CharacterCasing.Upper
        TextBox99.CharacterCasing = CharacterCasing.Upper
        TextBox64.CharacterCasing = CharacterCasing.Upper
        TextBox69.CharacterCasing = CharacterCasing.Upper
        TextBox74.CharacterCasing = CharacterCasing.Upper
        TextBox79.CharacterCasing = CharacterCasing.Upper
        TextBox84.CharacterCasing = CharacterCasing.Upper
        TextBox89.CharacterCasing = CharacterCasing.Upper
        TextBox94.CharacterCasing = CharacterCasing.Upper
        TextBox99.CharacterCasing = CharacterCasing.Upper
        TextBox104.CharacterCasing = CharacterCasing.Upper
        TextBox109.CharacterCasing = CharacterCasing.Upper

        TextBox15.CharacterCasing = CharacterCasing.Upper
        TextBox20.CharacterCasing = CharacterCasing.Upper
        TextBox25.CharacterCasing = CharacterCasing.Upper
        TextBox30.CharacterCasing = CharacterCasing.Upper
        TextBox35.CharacterCasing = CharacterCasing.Upper
        TextBox40.CharacterCasing = CharacterCasing.Upper
        TextBox45.CharacterCasing = CharacterCasing.Upper
        TextBox50.CharacterCasing = CharacterCasing.Upper
        TextBox55.CharacterCasing = CharacterCasing.Upper
        TextBox60.CharacterCasing = CharacterCasing.Upper
        TextBox65.CharacterCasing = CharacterCasing.Upper
        TextBox70.CharacterCasing = CharacterCasing.Upper
        TextBox75.CharacterCasing = CharacterCasing.Upper
        TextBox80.CharacterCasing = CharacterCasing.Upper
        TextBox85.CharacterCasing = CharacterCasing.Upper
        TextBox90.CharacterCasing = CharacterCasing.Upper
        TextBox95.CharacterCasing = CharacterCasing.Upper
        TextBox100.CharacterCasing = CharacterCasing.Upper
        TextBox105.CharacterCasing = CharacterCasing.Upper
        TextBox110.CharacterCasing = CharacterCasing.Upper
    End Sub

    ''' <summary>
    ''' Ajusta la escala del formulario y sus controles a la resolución de la pantalla.
    ''' </summary>
    Private Sub AjustarEscalaFormulario()
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim scaleFactorX As Double = screenWidth / 1920.0
        Dim scaleFactorY As Double = screenHeight / 1080.0

        Me.Width = CInt(Me.Width * scaleFactorX)
        Me.Height = CInt(Me.Height * scaleFactorY)

        For Each ctrl As Control In Me.Controls
            ctrl.Left = CInt(ctrl.Left * scaleFactorX)
            ctrl.Top = CInt(ctrl.Top * scaleFactorY)
            ctrl.Width = CInt(ctrl.Width * scaleFactorX)
            ctrl.Height = CInt(ctrl.Height * scaleFactorY)
        Next
    End Sub

    Private Sub CalcularTotales()
        Dim subtotal As Double = 0

        ' Buscar y sumar los valores de los TextBox desde 18 hasta 113 en pasos de 5
        For i As Integer = 18 To 113 Step 5
            Dim nombreTextBox As String = "TextBox" & i.ToString()
            Dim controles As Control() = Me.Controls.Find(nombreTextBox, True)

            If controles.Length > 0 AndAlso TypeOf controles(0) Is TextBox Then
                Dim tb As TextBox = DirectCast(controles(0), TextBox)
                Dim valor As Double

                If Double.TryParse(tb.Text, valor) Then
                    subtotal += valor
                End If
            End If
        Next

        ' Calcular IVA y Total Bruto
        Dim iva As Double = Math.Round(subtotal * 0.19, 2)
        Dim totalBruto As Double = Math.Round(subtotal + iva, 2)

        ' Mostrar resultados en los TextBox finales
        Dim tbNeto As TextBox = TryCast(Me.Controls.Find("TextBox118", True).FirstOrDefault(), TextBox)
        Dim tbIva As TextBox = TryCast(Me.Controls.Find("TextBox120", True).FirstOrDefault(), TextBox)
        Dim tbBruto As TextBox = TryCast(Me.Controls.Find("TextBox121", True).FirstOrDefault(), TextBox)

        If tbNeto IsNot Nothing Then tbNeto.Text = subtotal.ToString("N2")
        If tbIva IsNot Nothing Then tbIva.Text = iva.ToString("N2")
        If tbBruto IsNot Nothing Then tbBruto.Text = totalBruto.ToString("N2")
    End Sub



    ''' <summary>
    ''' Carga los datos en los ComboBox desde la base de datos.
    ''' </summary>
    Private Sub CargarComboboxes()
        Using cnx As New MySqlConnection(cadenaConexion)
            cnx.Open()
            CargarComboBox("SELECT DISTINCT LUGAR_ENTREGA FROM Lugar", ComboBox1, "LUGAR_ENTREGA", cnx)
            CargarComboBox("SELECT DISTINCT condiciones FROM Pago", ComboBox2, "condiciones", cnx)
            CargarComboBox("SELECT DISTINCT validez FROM Validez", ComboBox3, "validez", cnx)
        End Using
    End Sub

    ''' <summary>
    ''' Método genérico para cargar datos en un ComboBox.
    ''' </summary>
    Private Sub CargarComboBox(query As String, combo As ComboBox, displayMember As String, cnx As MySqlConnection)
        Dim adapter As New MySqlDataAdapter(query, cnx)
        Dim dt As New DataTable()
        adapter.Fill(dt)
        combo.DataSource = dt
        combo.DisplayMember = displayMember
        combo.Refresh()
    End Sub

    ''' <summary>
    ''' Limpia los valores de los controles al cargar el formulario.
    ''' </summary>
    Private Sub LimpiarControles()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        DateTimePicker1.Value = DateTime.Now
        DateTimePicker42.Value = DateTime.Now
    End Sub

#Region "Exportar a Excel segun la planilla de Cotizacion"
    Private Sub BtnExpClp_Click(sender As Object, e As EventArgs) Handles BtnExpClp.Click
    Dim xlibro As Microsoft.Office.Interop.Excel.Application
    Dim strRutaExcel As String

    strRutaExcel = "C:\SOURCESAFRATEC\Planilla de Cotizacion.xlsm"

    xlibro = CreateObject("Excel.Application")
    xlibro.Workbooks.Open(strRutaExcel)

    ' Activamos el libro
    xlibro.Workbooks("Planilla de Cotizacion.xlsm").Activate()

    ' Activamos la hoja especifica del libro  
    xlibro.Sheets("Planilla de Cotizacion (CLP)").Select()

    Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = xlibro.Sheets.Item("Planilla de Cotizacion (CLP)")
    xlibro.Visible = True

    ' Solo enviar datos si los campos no están vacíos
    If TextBox1.Text <> "" Then xlibro.Range("D15").Value = TextBox1.Text ' Razon social
    If TextBox2.Text <> "" Then xlibro.Range("D16").Value = TextBox2.Text ' Atencion
    If TextBox3.Text <> "" Then xlibro.Range("D17").Value = TextBox3.Text ' RUT
    If TextBox4.Text <> "" Then xlibro.Range("D18").Value = TextBox4.Text ' Direccion
    If TextBox5.Text <> "" Then xlibro.Range("D19").Value = TextBox5.Text ' Telefono cliente
    If TextBox6.Text <> "" Then xlibro.Range("D20").Value = TextBox6.Text ' Correo de Cliente

        If TextBox7.Text <> "" Then xlibro.Range("H10").Value = "TSA" + " - " + TextBox7.Text '# de Cotizacion
        If TextBox8.Text <> "" Then xlibro.Range("I16").Value = TextBox8.Text ' Fecha del Dia

    If TextBox9.Text <> "" Then xlibro.Range("I17").Value = TextBox9.Text ' Vendedor
    If TextBox10.Text <> "" Then xlibro.Range("I18").Value = TextBox10.Text ' Correo de Vendedor
    If TextBox11.Text <> "" Then xlibro.Range("I19").Value = TextBox11.Text ' Pagina web
    If TextBox12.Text <> "" Then xlibro.Range("I20").Value = TextBox12.Text ' Telefono vendedor

    If TextBox13.Text <> "" Then xlibro.Range("D21").Value = TextBox13.Text ' Referencia 

    ' Enviar datos solo si hay contenido para cada línea de Materiales
    If TextBox14.Text <> "" Then xlibro.Range("D24").Value = TextBox14.Text ' Descripcion de Materiales
    If TextBox15.Text <> "" Then xlibro.Range("C24").Value = TextBox15.Text ' Codigo del Material
    If TextBox16.Text <> "" Then xlibro.Range("H24").Value = TextBox16.Text ' Cantidad del Material
        If TextBox17.Text <> "" Then xlibro.Range("I24").Value = Val(TextBox17.Text) ' Precio del Material


        If TextBox19.Text <> "" Then xlibro.Range("D25").Value = TextBox19.Text ' Descripcion de Materiales
    If TextBox20.Text <> "" Then xlibro.Range("C25").Value = TextBox20.Text ' Codigo del Material
    If TextBox21.Text <> "" Then xlibro.Range("H25").Value = TextBox21.Text ' Cantidad del Material
        If TextBox22.Text <> "" Then xlibro.Range("I25").Value = Val(TextBox22.Text) ' Precio del Material

        If TextBox24.Text <> "" Then xlibro.Range("D26").Value = TextBox24.Text ' Descripcion de Materiales
    If TextBox25.Text <> "" Then xlibro.Range("C26").Value = TextBox25.Text ' Codigo del Material
    If TextBox26.Text <> "" Then xlibro.Range("H26").Value = TextBox26.Text ' Cantidad del Material
        If TextBox27.Text <> "" Then xlibro.Range("I26").Value = Val(TextBox27.Text) ' Precio del Material


        If TextBox29.Text <> "" Then xlibro.Range("D27").Value = TextBox29.Text ' Descripcion de Materiales
    If TextBox30.Text <> "" Then xlibro.Range("C27").Value = TextBox30.Text ' Codigo del Material
    If TextBox31.Text <> "" Then xlibro.Range("H27").Value = TextBox31.Text ' Cantidad del Material
        If TextBox32.Text <> "" Then xlibro.Range("I27").Value = Val(TextBox32.Text) ' Precio del Material


        If TextBox34.Text <> "" Then xlibro.Range("D28").Value = TextBox34.Text ' Descripcion de Materiales
    If TextBox35.Text <> "" Then xlibro.Range("C28").Value = TextBox35.Text ' Codigo del Material
    If TextBox36.Text <> "" Then xlibro.Range("H28").Value = TextBox36.Text ' Cantidad del Material
        If TextBox37.Text <> "" Then xlibro.Range("I28").Value = Val(TextBox37.Text) ' Precio del Material


        If TextBox39.Text <> "" Then xlibro.Range("D29").Value = TextBox39.Text ' Descripcion de Materiales
    If TextBox40.Text <> "" Then xlibro.Range("C29").Value = TextBox40.Text ' Codigo del Material
    If TextBox41.Text <> "" Then xlibro.Range("H29").Value = TextBox41.Text ' Cantidad del Material
        If TextBox42.Text <> "" Then xlibro.Range("I29").Value = Val(TextBox42.Text) ' Precio del Material


        If TextBox44.Text <> "" Then xlibro.Range("D30").Value = TextBox44.Text ' Descripcion de Materiales
    If TextBox45.Text <> "" Then xlibro.Range("C30").Value = TextBox45.Text ' Codigo del Material
    If TextBox46.Text <> "" Then xlibro.Range("H30").Value = TextBox46.Text ' Cantidad del Material
        If TextBox47.Text <> "" Then xlibro.Range("I30").Value = Val(TextBox47.Text) ' Precio del Material


        If TextBox49.Text <> "" Then xlibro.Range("D31").Value = TextBox49.Text ' Descripcion de Materiales
    If TextBox50.Text <> "" Then xlibro.Range("C31").Value = TextBox50.Text ' Codigo del Material
    If TextBox51.Text <> "" Then xlibro.Range("H31").Value = TextBox51.Text ' Cantidad del Material
        If TextBox52.Text <> "" Then xlibro.Range("I31").Value = Val(TextBox52.Text) ' Precio del Material


        If TextBox54.Text <> "" Then xlibro.Range("D32").Value = TextBox54.Text ' Descripcion de Materiales
    If TextBox55.Text <> "" Then xlibro.Range("C32").Value = TextBox55.Text ' Codigo del Material
    If TextBox56.Text <> "" Then xlibro.Range("H32").Value = TextBox56.Text ' Cantidad del Material
        If TextBox57.Text <> "" Then xlibro.Range("I32").Value = Val(TextBox57.Text) ' Precio del Material


        If TextBox59.Text <> "" Then xlibro.Range("D33").Value = TextBox59.Text ' Descripcion de Materiales
    If TextBox60.Text <> "" Then xlibro.Range("C33").Value = TextBox60.Text ' Codigo del Material
    If TextBox61.Text <> "" Then xlibro.Range("H33").Value = TextBox61.Text ' Cantidad del Material
        If TextBox62.Text <> "" Then xlibro.Range("I33").Value = Val(TextBox62.Text) ' Precio del Material


        If TextBox64.Text <> "" Then xlibro.Range("D34").Value = TextBox64.Text ' Descripcion de Materiales
    If TextBox65.Text <> "" Then xlibro.Range("C34").Value = TextBox65.Text ' Codigo del Material
    If TextBox66.Text <> "" Then xlibro.Range("H34").Value = TextBox66.Text ' Cantidad del Material
        If TextBox67.Text <> "" Then xlibro.Range("I34").Value = Val(TextBox67.Text) ' Precio del Material


        If TextBox69.Text <> "" Then xlibro.Range("D35").Value = TextBox69.Text ' Descripcion de Materiales
    If TextBox70.Text <> "" Then xlibro.Range("C35").Value = TextBox70.Text ' Codigo del Material
    If TextBox71.Text <> "" Then xlibro.Range("H35").Value = TextBox71.Text ' Cantidad del Material
        If TextBox72.Text <> "" Then xlibro.Range("I35").Value = Val(TextBox72.Text) ' Precio del Material


        If TextBox74.Text <> "" Then xlibro.Range("D36").Value = TextBox74.Text ' Descripcion de Materiales
    If TextBox75.Text <> "" Then xlibro.Range("C36").Value = TextBox75.Text ' Codigo del Material
    If TextBox76.Text <> "" Then xlibro.Range("H36").Value = TextBox76.Text ' Cantidad del Material
        If TextBox77.Text <> "" Then xlibro.Range("I36").Value = Val(TextBox77.Text) ' Precio del Material


        If TextBox79.Text <> "" Then xlibro.Range("D37").Value = TextBox79.Text ' Descripcion de Materiales
    If TextBox80.Text <> "" Then xlibro.Range("C37").Value = TextBox80.Text ' Codigo del Material
    If TextBox81.Text <> "" Then xlibro.Range("H37").Value = TextBox81.Text ' Cantidad del Material
        If TextBox82.Text <> "" Then xlibro.Range("I37").Value = Val(TextBox82.Text) ' Precio del Material


        If TextBox84.Text <> "" Then xlibro.Range("D38").Value = TextBox84.Text ' Descripcion de Materiales
    If TextBox85.Text <> "" Then xlibro.Range("C38").Value = TextBox85.Text ' Codigo del Material
    If TextBox86.Text <> "" Then xlibro.Range("H38").Value = TextBox86.Text ' Cantidad del Material
        If TextBox87.Text <> "" Then xlibro.Range("I38").Value = Val(TextBox87.Text) ' Precio del Material


        If TextBox89.Text <> "" Then xlibro.Range("D39").Value = TextBox89.Text ' Descripcion de Materiales
    If TextBox90.Text <> "" Then xlibro.Range("C39").Value = TextBox90.Text ' Codigo del Material
    If TextBox91.Text <> "" Then xlibro.Range("H39").Value = TextBox91.Text ' Cantidad del Material
        If TextBox92.Text <> "" Then xlibro.Range("I39").Value = Val(TextBox92.Text) ' Precio del Material

        If TextBox94.Text <> "" Then xlibro.Range("D40").Value = TextBox94.Text ' Descripcion de Materiales
    If TextBox95.Text <> "" Then xlibro.Range("C40").Value = TextBox95.Text ' Codigo del Material
    If TextBox96.Text <> "" Then xlibro.Range("H40").Value = TextBox96.Text ' Cantidad del Material
        If TextBox97.Text <> "" Then xlibro.Range("I40").Value = Val(TextBox97.Text) ' Precio del Material

        If TextBox99.Text <> "" Then xlibro.Range("D41").Value = TextBox99.Text ' Descripcion de Materiales
    If TextBox100.Text <> "" Then xlibro.Range("C41").Value = TextBox100.Text ' Codigo del Material
    If TextBox101.Text <> "" Then xlibro.Range("H41").Value = TextBox101.Text ' Cantidad del Material
        If TextBox102.Text <> "" Then xlibro.Range("I41").Value = Val(TextBox102.Text) ' Precio del Material

        If TextBox104.Text <> "" Then xlibro.Range("D42").Value = TextBox104.Text ' Descripcion de Materiales
    If TextBox105.Text <> "" Then xlibro.Range("C42").Value = TextBox105.Text ' Codigo del Material
    If TextBox106.Text <> "" Then xlibro.Range("H42").Value = TextBox106.Text ' Cantidad del Material
        If TextBox107.Text <> "" Then xlibro.Range("I42").Value = Val(TextBox107.Text) ' Precio del Material

        If TextBox109.Text <> "" Then xlibro.Range("D43").Value = TextBox109.Text ' Descripcion de Materiales
    If TextBox110.Text <> "" Then xlibro.Range("C43").Value = TextBox110.Text ' Codigo del Material
    If TextBox111.Text <> "" Then xlibro.Range("H43").Value = TextBox111.Text ' Cantidad del Material
        If TextBox112.Text <> "" Then xlibro.Range("I43").Value = Val(TextBox112.Text) ' Precio del Material

        If ComboBox1.Text <> "" Then xlibro.Range("D58").Value = ComboBox1.Text
    If TextBox114.Text <> "" Then xlibro.Range("D59").Value = TextBox114.Text
    If ComboBox2.Text <> "" Then xlibro.Range("D60").Value = ComboBox2.Text
    If ComboBox3.Text <> "" Then xlibro.Range("D61").Value = ComboBox3.Text
End Sub
    Private Sub BtnExpUSD_Click(sender As Object, e As EventArgs) Handles BtnExpUSD.Click
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

        'Ahora podemos llevar el contenido de un textbox a una celda de excel especifica con la siguiente instrucción
        If TextBox1.Text <> "" Then xlibro.Range("D15").Value = TextBox1.Text 'Razon social
        If TextBox2.Text <> "" Then xlibro.Range("D16").Value = TextBox2.Text 'Atencion
        If TextBox3.Text <> "" Then xlibro.Range("D17").Value = TextBox3.Text 'RUT
        If TextBox4.Text <> "" Then xlibro.Range("D18").Value = TextBox4.Text 'Direccion 
        If TextBox5.Text <> "" Then xlibro.Range("D19").Value = TextBox5.Text 'Telefono cliente
        If TextBox6.Text <> "" Then xlibro.Range("D20").Value = TextBox6.Text ' Correo de Cliente

        If TextBox7.Text <> "" Then xlibro.Range("H10").Value = "TSA" + " - " + TextBox7.Text '# de Cotizacion
        If TextBox8.Text <> "" Then xlibro.Range("I16").Value = TextBox8.Text ' Fecha del Dia

        If TextBox9.Text <> "" Then xlibro.Range("I17").Value = TextBox9.Text 'Vendedor
        If TextBox10.Text <> "" Then xlibro.Range("I18").Value = TextBox10.Text 'Correo de Vendedor
        If TextBox11.Text <> "" Then xlibro.Range("I19").Value = TextBox11.Text 'Pagina web
        If TextBox12.Text <> "" Then xlibro.Range("I20").Value = TextBox12.Text 'Telefono vendedor

        If TextBox13.Text <> "" Then xlibro.Range("D21").Value = TextBox13.Text 'Referencia 

        '''' Para primera linea activa de Materiales
        If TextBox14.Text <> "" Then xlibro.Range("D24").Value = TextBox14.Text 'Descripcion de Materiales
        If TextBox15.Text <> "" Then xlibro.Range("C24").Value = TextBox15.Text 'Codigo del Material
        If TextBox16.Text <> "" Then xlibro.Range("H24").Value = TextBox16.Text 'Cantidad del Material
        If TextBox17.Text <> "" Then xlibro.Range("I24").Value = Val(TextBox17.Text) ' Precio del Material

        ' 2 linea de Materiales
        If TextBox19.Text <> "" Then xlibro.Range("D25").Value = TextBox19.Text 'Descripcion de Materiales
        If TextBox20.Text <> "" Then xlibro.Range("C25").Value = TextBox20.Text 'Codigo del Material
        If TextBox21.Text <> "" Then xlibro.Range("H25").Value = TextBox21.Text 'Cantidad del Material
        If TextBox22.Text <> "" Then xlibro.Range("I25").Value = Val(TextBox22.Text) ' Precio del Material

        '3 linea de Materiales
        If TextBox24.Text <> "" Then xlibro.Range("D26").Value = TextBox24.Text 'Descripcion de Materiales
        If TextBox25.Text <> "" Then xlibro.Range("C26").Value = TextBox25.Text 'Codigo del Material
        If TextBox26.Text <> "" Then xlibro.Range("H26").Value = TextBox26.Text 'Cantidad del Material
        If TextBox27.Text <> "" Then xlibro.Range("I26").Value = Val(TextBox27.Text) ' Precio del Material

        '4 linea de Materiales
        If TextBox29.Text <> "" Then xlibro.Range("D27").Value = TextBox29.Text 'Descripcion de Materiales
        If TextBox30.Text <> "" Then xlibro.Range("C27").Value = TextBox30.Text 'Codigo del Material
        If TextBox31.Text <> "" Then xlibro.Range("H27").Value = TextBox31.Text 'Cantidad del Material
        If TextBox32.Text <> "" Then xlibro.Range("I27").Value = Val(TextBox32.Text) ' Precio del Material

        '5 linea de Materiales
        If TextBox34.Text <> "" Then xlibro.Range("D28").Value = TextBox34.Text 'Descripcion de Materiales
        If TextBox35.Text <> "" Then xlibro.Range("C28").Value = TextBox35.Text 'Codigo del Material
        If TextBox36.Text <> "" Then xlibro.Range("H28").Value = TextBox36.Text 'Cantidad del Material
        If TextBox37.Text <> "" Then xlibro.Range("I28").Value = Val(TextBox37.Text) ' Precio del Material

        '6 linea de Materiales
        If TextBox39.Text <> "" Then xlibro.Range("D29").Value = TextBox39.Text 'Descripcion de Materiales
        If TextBox40.Text <> "" Then xlibro.Range("C29").Value = TextBox40.Text 'Codigo del Material
        If TextBox41.Text <> "" Then xlibro.Range("H29").Value = TextBox41.Text 'Cantidad del Material
        If TextBox42.Text <> "" Then xlibro.Range("I29").Value = Val(TextBox42.Text) ' Precio del Material

        '7 linea de Materiales
        If TextBox44.Text <> "" Then xlibro.Range("D30").Value = TextBox44.Text 'Descripcion de Materiales
        If TextBox45.Text <> "" Then xlibro.Range("C30").Value = TextBox45.Text 'Codigo del Material
        If TextBox46.Text <> "" Then xlibro.Range("H30").Value = TextBox46.Text 'Cantidad del Material
        If TextBox47.Text <> "" Then xlibro.Range("I30").Value = Val(TextBox47.Text) ' Precio del Material

        '8 Linea de Materiales
        If TextBox49.Text <> "" Then xlibro.Range("D31").Value = TextBox49.Text 'Descripcion de Materiales
        If TextBox50.Text <> "" Then xlibro.Range("C31").Value = TextBox50.Text 'Codigo del Material
        If TextBox51.Text <> "" Then xlibro.Range("H31").Value = TextBox51.Text 'Cantidad del Material
        If TextBox52.Text <> "" Then xlibro.Range("I31").Value = Val(TextBox52.Text) ' Precio del Material

        '9 linea de Materiales
        If TextBox54.Text <> "" Then xlibro.Range("D32").Value = TextBox54.Text 'Descripcion de Materiales
        If TextBox55.Text <> "" Then xlibro.Range("C32").Value = TextBox55.Text 'Codigo del Material
        If TextBox56.Text <> "" Then xlibro.Range("H32").Value = TextBox56.Text 'Cantidad del Material
        If TextBox57.Text <> "" Then xlibro.Range("I32").Value = Val(TextBox57.Text) ' Precio del Material

        ' 10 Linea de Materiales 
        If TextBox59.Text <> "" Then xlibro.Range("D33").Value = TextBox59.Text 'Descripcion de Materiales
        If TextBox60.Text <> "" Then xlibro.Range("C33").Value = TextBox60.Text 'Codigo del Material
        If TextBox61.Text <> "" Then xlibro.Range("H33").Value = TextBox61.Text 'Cantidad del Material
        If TextBox62.Text <> "" Then xlibro.Range("I33").Value = Val(TextBox62.Text) ' Precio del Material

        ' 11 Linea de Materiales 
        If TextBox64.Text <> "" Then xlibro.Range("D34").Value = TextBox64.Text 'Descripcion de Materiales
        If TextBox65.Text <> "" Then xlibro.Range("C34").Value = TextBox65.Text 'Codigo del Material
        If TextBox66.Text <> "" Then xlibro.Range("H34").Value = TextBox66.Text 'Cantidad del Material
        If TextBox67.Text <> "" Then xlibro.Range("I34").Value = Val(TextBox67.Text) ' Precio del Material

        ' 12 Linea de Materiales 
        If TextBox69.Text <> "" Then xlibro.Range("D35").Value = TextBox69.Text 'Descripcion de Materiales
        If TextBox70.Text <> "" Then xlibro.Range("C35").Value = TextBox70.Text 'Codigo del Material
        If TextBox71.Text <> "" Then xlibro.Range("H35").Value = TextBox71.Text 'Cantidad del Material
        If TextBox72.Text <> "" Then xlibro.Range("I35").Value = Val(TextBox72.Text) ' Precio del Material

        ' 13 Linea de Materiales 
        If TextBox74.Text <> "" Then xlibro.Range("D36").Value = TextBox74.Text 'Descripcion de Materiales
        If TextBox75.Text <> "" Then xlibro.Range("C36").Value = TextBox75.Text 'Codigo del Material
        If TextBox76.Text <> "" Then xlibro.Range("H36").Value = TextBox76.Text 'Cantidad del Material
        If TextBox77.Text <> "" Then xlibro.Range("I36").Value = Val(TextBox77.Text) ' Precio del Material

        ' 14 Linea de Materiales 
        If TextBox79.Text <> "" Then xlibro.Range("D37").Value = TextBox79.Text 'Descripcion de Materiales
        If TextBox80.Text <> "" Then xlibro.Range("C37").Value = TextBox80.Text 'Codigo del Material
        If TextBox81.Text <> "" Then xlibro.Range("H37").Value = TextBox81.Text 'Cantidad del Material
        If TextBox82.Text <> "" Then xlibro.Range("I37").Value = Val(TextBox82.Text) ' Precio del Material

        ' 15 Linea de Materiales 
        If TextBox84.Text <> "" Then xlibro.Range("D38").Value = TextBox84.Text 'Descripcion de Materiales
        If TextBox85.Text <> "" Then xlibro.Range("C38").Value = TextBox85.Text 'Codigo del Material
        If TextBox86.Text <> "" Then xlibro.Range("H38").Value = TextBox86.Text 'Cantidad del Material
        If TextBox87.Text <> "" Then xlibro.Range("I38").Value = Val(TextBox87.Text) ' Precio del Material

        ' 16 Linea de Materiales 
        If TextBox89.Text <> "" Then xlibro.Range("D39").Value = TextBox89.Text 'Descripcion de Materiales
        If TextBox90.Text <> "" Then xlibro.Range("C39").Value = TextBox90.Text 'Codigo del Material
        If TextBox91.Text <> "" Then xlibro.Range("H39").Value = TextBox91.Text 'Cantidad del Material
        If TextBox92.Text <> "" Then xlibro.Range("I39").Value = Val(TextBox92.Text) ' Precio del Material

        ' ComboBox Values
        If ComboBox1.Text <> "" Then xlibro.Range("D58").Value = ComboBox1.Text
        If TextBox114.Text <> "" Then xlibro.Range("D59").Value = TextBox114.Text
        If ComboBox2.Text <> "" Then xlibro.Range("D60").Value = ComboBox2.Text
        'If ComboBox3.Text <> "" Then xlibro.Range("D61").Value = ComboBox3.Text

    End Sub

    Private Sub BtnExpEUR_Click(sender As Object, e As EventArgs) Handles BtnExpEUR.Click
        Dim xlibro As Microsoft.Office.Interop.Excel.Application
        Dim strRutaExcel As String

        strRutaExcel = "C:\SOURCESAFRATEC\Planilla de Cotizacion.xlsm"

        xlibro = CreateObject("Excel.Application")
        xlibro.Workbooks.Open(strRutaExcel)

        ' Activamos el libro
        xlibro.Workbooks("Planilla de Cotizacion.xlsm").Activate()

        ' Activamos la hoja especifica del libro  
        xlibro.Sheets("Planilla de Cotizacion (EUR)").Select()

        Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = xlibro.Sheets.Item("Planilla de Cotizacion (EUR)")
        xlibro.Visible = True

        ' Asignamos los valores de TextBox a las celdas solo si los TextBox no están vacíos
        If TextBox1.Text <> "" Then xlibro.Range("D15").Value = TextBox1.Text 'Razon social
        If TextBox2.Text <> "" Then xlibro.Range("D16").Value = TextBox2.Text 'Atencion
        If TextBox3.Text <> "" Then xlibro.Range("D17").Value = TextBox3.Text 'RUT
        If TextBox4.Text <> "" Then xlibro.Range("D18").Value = TextBox4.Text 'Direccion 
        If TextBox5.Text <> "" Then xlibro.Range("D19").Value = TextBox5.Text 'Telefono cliente
        If TextBox6.Text <> "" Then xlibro.Range("D20").Value = TextBox6.Text ' Correo de Cliente

        If TextBox7.Text <> "" Then xlibro.Range("H10").Value = "TSA" + " - " + TextBox7.Text '# de Cotizacion
        If TextBox8.Text <> "" Then xlibro.Range("I16").Value = TextBox8.Text ' Fecha del Dia

        If TextBox9.Text <> "" Then xlibro.Range("I17").Value = TextBox9.Text 'Vendedor
        If TextBox10.Text <> "" Then xlibro.Range("I18").Value = TextBox10.Text 'Correo de Vendedor
        If TextBox11.Text <> "" Then xlibro.Range("I19").Value = TextBox11.Text 'Pagina web
        If TextBox12.Text <> "" Then xlibro.Range("I20").Value = TextBox12.Text 'Telefono vendedor

        If TextBox13.Text <> "" Then xlibro.Range("D21").Value = TextBox13.Text 'Referencia 

        '''' Para primera linea activa de Materiales
        If TextBox14.Text <> "" Then xlibro.Range("D24").Value = TextBox14.Text 'Descripcion de Materiales
        If TextBox15.Text <> "" Then xlibro.Range("C24").Value = TextBox15.Text 'Codigo del Material
        If TextBox16.Text <> "" Then xlibro.Range("H24").Value = TextBox16.Text 'Cantidad del Material
        If TextBox17.Text <> "" Then xlibro.Range("I24").Value = Val(TextBox17.Text) ' Precio del Material

        ' Repetir el proceso para las siguientes líneas de materiales
        If TextBox19.Text <> "" Then xlibro.Range("D25").Value = TextBox19.Text 'Descripcion de Materiales
        If TextBox20.Text <> "" Then xlibro.Range("C25").Value = TextBox20.Text 'Codigo del Material
        If TextBox21.Text <> "" Then xlibro.Range("H25").Value = TextBox21.Text 'Cantidad del Material
        If TextBox22.Text <> "" Then xlibro.Range("I25").Value = Val(TextBox22.Text) ' Precio del Material

        If TextBox24.Text <> "" Then xlibro.Range("D26").Value = TextBox24.Text 'Descripcion de Materiales
        If TextBox25.Text <> "" Then xlibro.Range("C26").Value = TextBox25.Text 'Codigo del Material
        If TextBox26.Text <> "" Then xlibro.Range("H26").Value = TextBox26.Text 'Cantidad del Material
        If TextBox27.Text <> "" Then xlibro.Range("I26").Value = Val(TextBox27.Text) ' Precio del Material

        If TextBox29.Text <> "" Then xlibro.Range("D27").Value = TextBox29.Text 'Descripcion de Materiales
        If TextBox30.Text <> "" Then xlibro.Range("C27").Value = TextBox30.Text 'Codigo del Material
        If TextBox31.Text <> "" Then xlibro.Range("H27").Value = TextBox31.Text 'Cantidad del Material
        If TextBox32.Text <> "" Then xlibro.Range("I27").Value = Val(TextBox32.Text) ' Precio del Material

        If TextBox34.Text <> "" Then xlibro.Range("D28").Value = TextBox34.Text 'Descripcion de Materiales
        If TextBox35.Text <> "" Then xlibro.Range("C28").Value = TextBox35.Text 'Codigo del Material
        If TextBox36.Text <> "" Then xlibro.Range("H28").Value = TextBox36.Text 'Cantidad del Material
        If TextBox37.Text <> "" Then xlibro.Range("I28").Value = Val(TextBox37.Text) ' Precio del Material

        If TextBox39.Text <> "" Then xlibro.Range("D29").Value = TextBox39.Text 'Descripcion de Materiales
        If TextBox40.Text <> "" Then xlibro.Range("C29").Value = TextBox40.Text 'Codigo del Material
        If TextBox41.Text <> "" Then xlibro.Range("H29").Value = TextBox41.Text 'Cantidad del Material
        If TextBox42.Text <> "" Then xlibro.Range("I29").Value = Val(TextBox42.Text) ' Precio del Material

        If TextBox44.Text <> "" Then xlibro.Range("D30").Value = TextBox44.Text 'Descripcion de Materiales
        If TextBox45.Text <> "" Then xlibro.Range("C30").Value = TextBox45.Text 'Codigo del Material
        If TextBox46.Text <> "" Then xlibro.Range("H30").Value = TextBox46.Text 'Cantidad del Material
        If TextBox47.Text <> "" Then xlibro.Range("I30").Value = Val(TextBox47.Text) ' Precio del Material

        If TextBox49.Text <> "" Then xlibro.Range("D31").Value = TextBox49.Text 'Descripcion de Materiales
        If TextBox50.Text <> "" Then xlibro.Range("C31").Value = TextBox50.Text 'Codigo del Material
        If TextBox51.Text <> "" Then xlibro.Range("H31").Value = TextBox51.Text 'Cantidad del Material
        If TextBox52.Text <> "" Then xlibro.Range("I31").Value = Val(TextBox52.Text) ' Precio del Material

        If TextBox54.Text <> "" Then xlibro.Range("D32").Value = TextBox54.Text 'Descripcion de Materiales
        If TextBox55.Text <> "" Then xlibro.Range("C32").Value = TextBox55.Text 'Codigo del Material
        If TextBox56.Text <> "" Then xlibro.Range("H32").Value = TextBox56.Text 'Cantidad del Material
        If TextBox57.Text <> "" Then xlibro.Range("I32").Value = Val(TextBox57.Text) ' Precio del Material

        If TextBox59.Text <> "" Then xlibro.Range("D33").Value = TextBox59.Text 'Descripcion de Materiales
        If TextBox60.Text <> "" Then xlibro.Range("C33").Value = TextBox60.Text 'Codigo del Material
        If TextBox61.Text <> "" Then xlibro.Range("H33").Value = TextBox61.Text 'Cantidad del Material
        If TextBox62.Text <> "" Then xlibro.Range("I33").Value = Val(TextBox62.Text) ' Precio del Material

        If TextBox64.Text <> "" Then xlibro.Range("D34").Value = TextBox64.Text 'Descripcion de Materiales
        If TextBox65.Text <> "" Then xlibro.Range("C34").Value = TextBox65.Text 'Codigo del Material
        If TextBox66.Text <> "" Then xlibro.Range("H34").Value = TextBox66.Text 'Cantidad del Material
        If TextBox67.Text <> "" Then xlibro.Range("I34").Value = Val(TextBox67.Text) ' Precio del Material

        If TextBox69.Text <> "" Then xlibro.Range("D35").Value = TextBox69.Text 'Descripcion de Materiales
        If TextBox70.Text <> "" Then xlibro.Range("C35").Value = TextBox70.Text 'Codigo del Material
        If TextBox71.Text <> "" Then xlibro.Range("H35").Value = TextBox71.Text 'Cantidad del Material
        If TextBox72.Text <> "" Then xlibro.Range("I35").Value = Val(TextBox72.Text) ' Precio del Material

        If TextBox74.Text <> "" Then xlibro.Range("D36").Value = TextBox74.Text 'Descripcion de Materiales
        If TextBox75.Text <> "" Then xlibro.Range("C36").Value = TextBox75.Text 'Codigo del Material
        If TextBox76.Text <> "" Then xlibro.Range("H36").Value = TextBox76.Text 'Cantidad del Material
        If TextBox77.Text <> "" Then xlibro.Range("I36").Value = Val(TextBox77.Text) ' Precio del Material

        If TextBox79.Text <> "" Then xlibro.Range("D37").Value = TextBox79.Text 'Descripcion de Materiales
        If TextBox80.Text <> "" Then xlibro.Range("C37").Value = TextBox80.Text 'Codigo del Material
        If TextBox81.Text <> "" Then xlibro.Range("H37").Value = TextBox81.Text 'Cantidad del Material
        If TextBox82.Text <> "" Then xlibro.Range("I37").Value = Val(TextBox82.Text) ' Precio del Material

        If TextBox84.Text <> "" Then xlibro.Range("D38").Value = TextBox84.Text 'Descripcion de Materiales
        If TextBox85.Text <> "" Then xlibro.Range("C38").Value = TextBox85.Text 'Codigo del Material
        If TextBox86.Text <> "" Then xlibro.Range("H38").Value = TextBox86.Text 'Cantidad del Material
        If TextBox87.Text <> "" Then xlibro.Range("I38").Value = Val(TextBox87.Text) ' Precio del Material

        If TextBox89.Text <> "" Then xlibro.Range("D39").Value = TextBox89.Text 'Descripcion de Materiales
        If TextBox90.Text <> "" Then xlibro.Range("C39").Value = TextBox90.Text 'Codigo del Material
        If TextBox91.Text <> "" Then xlibro.Range("H39").Value = TextBox91.Text 'Cantidad del Material
        If TextBox92.Text <> "" Then xlibro.Range("I39").Value = Val(TextBox92.Text) ' Precio del Material

        If TextBox94.Text <> "" Then xlibro.Range("D40").Value = TextBox94.Text 'Descripcion de Materiales
        If TextBox95.Text <> "" Then xlibro.Range("C40").Value = TextBox95.Text 'Codigo del Material
        If TextBox96.Text <> "" Then xlibro.Range("H40").Value = TextBox96.Text 'Cantidad del Material
        If TextBox97.Text <> "" Then xlibro.Range("I40").Value = Val(TextBox97.Text) ' Precio del Material

        If TextBox99.Text <> "" Then xlibro.Range("D41").Value = TextBox99.Text 'Descripcion de Materiales
        If TextBox100.Text <> "" Then xlibro.Range("C41").Value = TextBox100.Text 'Codigo del Material
        If TextBox101.Text <> "" Then xlibro.Range("H41").Value = TextBox101.Text 'Cantidad del Material
        If TextBox102.Text <> "" Then xlibro.Range("I41").Value = Val(TextBox102.Text) ' Precio del Material

        If ComboBox1.Text <> "" Then xlibro.Range("D58").Value = ComboBox1.Text
        If ComboBox2.Text <> "" Then xlibro.Range("D59").Value = ComboBox2.Text
        If ComboBox3.Text <> "" Then xlibro.Range("D60").Value = ComboBox3.Text
    End Sub

#End Region
#Region "Para Actulizar cotizaciones "
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Para asegurar que el registo este correcto
        If MessageBox.Show("¿ Seguro que desea Modificar este registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            If TextBox14.Text > "" Then
                CheckBox1.Checked = True
            End If
            If TextBox19.Text > "" Then
                CheckBox2.Checked = True
            End If
            If TextBox24.Text > "" Then
                CheckBox3.Checked = True
            End If
            If TextBox29.Text > "" Then
                CheckBox4.Checked = True
            End If
            If TextBox34.Text > "" Then
                CheckBox5.Checked = True
            End If
            If TextBox39.Text > "" Then
                CheckBox6.Checked = True
            End If
            If TextBox44.Text > "" Then
                CheckBox7.Checked = True
            End If
            If TextBox49.Text > "" Then
                CheckBox8.Checked = True
            End If
            If TextBox54.Text > "" Then
                CheckBox9.Checked = True
            End If
            If TextBox59.Text > "" Then
                CheckBox10.Checked = True
            End If
            If TextBox64.Text > "" Then
                CheckBox11.Checked = True
            End If
            If TextBox69.Text > "" Then
                CheckBox12.Checked = True
            End If
            If TextBox74.Text > "" Then
                CheckBox13.Checked = True
            End If
            If TextBox79.Text > "" Then
                CheckBox14.Checked = True
            End If
            If TextBox84.Text > "" Then
                CheckBox15.Checked = True
            End If
            If TextBox89.Text > "" Then
                CheckBox16.Checked = True
            End If
            If TextBox94.Text > "" Then
                CheckBox17.Checked = True
            End If
            If TextBox99.Text > "" Then
                CheckBox18.Checked = True
            End If
            If TextBox104.Text > "" Then
                CheckBox19.Checked = True
            End If
            If TextBox109.Text > "" Then
                CheckBox20.Checked = True
            End If
        End If
        Me.Hide()

    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()

        Else
            On Error Resume Next
            Dim edicion As String = "UPDATE TSADATACOTIZACION SET Cotizacion= ?Cotizacion, Fecha= ?Fecha, 
            Razon_Social= ?Razonsocial, RUT = ?RUT, Atencion = ?Atencion, Direccion_ate= ?Direccionate, Telefono_ate= ?TelefonoATe, Correo_ate= ?CorreoAte,
            Contacto= ?Contacto, Telefono_cont= ?TelefonoCont, Correo_cont= ?CorreoCont, Pagina_Web= ?WEB, Referencia= ?Referencia, Descripcion_mat= ?Descripcion, 
            Codigo_mat= ?Codigo, Cantidad= ?Cantidad, Precio= ?Precio, Total= ?Total, Moneda= ?Moneda, Linea=?Linea, OC= ?OC, FechaOC=?FechaOC, OC_Items=?Ocitems, Fecha_OC_Items=?FechOCItems, Fecha_Entrega=?Fechaent,
            Fecha_Ent_Items=?FecEntItems WHERE ID= ?ID and Linea=?Linea"

            Dim actualiza As New MySqlCommand(edicion, conex)
            actualiza.Parameters.AddWithValue("?Cotizacion", TextBox7.Text)
            actualiza.Parameters.AddWithValue("?Fecha", TextBox8.Text)
            actualiza.Parameters.AddWithValue("?RazonSocial", TextBox1.Text)
            actualiza.Parameters.AddWithValue("?RUT", TextBox3.Text)
            actualiza.Parameters.AddWithValue("?Atencion", TextBox2.Text)
            actualiza.Parameters.AddWithValue("?Direccionate", TextBox4.Text)
            actualiza.Parameters.AddWithValue("?Telefonoate", TextBox5.Text)
            actualiza.Parameters.AddWithValue("?CorreoAte", TextBox6.Text)
            actualiza.Parameters.AddWithValue("?Contacto", TextBox9.Text)
            actualiza.Parameters.AddWithValue("?TelefonoCont", TextBox12.Text)
            actualiza.Parameters.AddWithValue("?CorreoCont", TextBox10.Text)
            actualiza.Parameters.AddWithValue("?WEB", TextBox11.Text)
            actualiza.Parameters.AddWithValue("?Referencia", TextBox13.Text)
            actualiza.Parameters.AddWithValue("?Descripcion", TextBox14.Text)
            actualiza.Parameters.AddWithValue("?Codigo", TextBox15.Text)
            actualiza.Parameters.AddWithValue("?Cantidad", TextBox16.Text)
            actualiza.Parameters.AddWithValue("?Precio", TextBox17.Text)
            actualiza.Parameters.AddWithValue("?Total", TextBox18.Text)
            actualiza.Parameters.AddWithValue("?Moneda", TextBox143.Text)
            actualiza.Parameters.AddWithValue("?ID", Label2.Text)
            actualiza.Parameters.AddWithValue("?Linea", Label35.Text)
            actualiza.Parameters.AddWithValue("?OC", TextBox122.Text)
            actualiza.Parameters.AddWithValue("?FechaOC", DateTimePicker1.Text)
            actualiza.Parameters.AddWithValue("?Ocitems", TextBox123.Text)
            actualiza.Parameters.AddWithValue("?FechOCItems", DateTimePicker2.Text)
            actualiza.Parameters.AddWithValue("?Fechaent", DateTimePicker42.Text)
            actualiza.Parameters.AddWithValue("?FecEntItems", DateTimePicker22.Text)

            actualiza.Connection.Open()
            actualiza.ExecuteNonQuery()


        End If
    End Sub
    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()

        Else
            On Error Resume Next
            Dim edicion As String = "UPDATE TSADATACOTIZACION SET Cotizacion= ?Cotizacion, Fecha= ?Fecha, 
            Razon_Social= ?Razonsocial, RUT = ?RUT, Atencion = ?Atencion, Direccion_ate= ?Direccionate, Telefono_ate= ?TelefonoATe, Correo_ate= ?CorreoAte,
            Contacto= ?Contacto, Telefono_cont= ?TelefonoCont, Correo_cont= ?CorreoCont, Pagina_Web= ?WEB, Referencia= ?Referencia, Descripcion_mat= ?Descripcion, 
            Codigo_mat= ?Codigo, Cantidad= ?Cantidad, Precio= ?Precio, Total= ?Total, Moneda= ?Moneda, Linea=?Linea, OC= ?OC, FechaOC=?FechaOC, OC_Items=?Ocitems, Fecha_OC_Items=?FechOCItems, Fecha_Entrega=?Fechaent,
            Fecha_Ent_Items=?FecEntItems WHERE ID= ?ID and Linea=?Linea"

            Dim actualiza As New MySqlCommand(edicion, conex)

            actualiza.Parameters.AddWithValue("?Cotizacion", TextBox7.Text)
            actualiza.Parameters.AddWithValue("?Fecha", TextBox8.Text)
            actualiza.Parameters.AddWithValue("?RazonSocial", TextBox1.Text)
            actualiza.Parameters.AddWithValue("?RUT", TextBox3.Text)
            actualiza.Parameters.AddWithValue("?Atencion", TextBox2.Text)
            actualiza.Parameters.AddWithValue("?Direccionate", TextBox4.Text)
            actualiza.Parameters.AddWithValue("?Telefonoate", TextBox5.Text)
            actualiza.Parameters.AddWithValue("?CorreoAte", TextBox6.Text)
            actualiza.Parameters.AddWithValue("?Contacto", TextBox9.Text)
            actualiza.Parameters.AddWithValue("?TelefonoCont", TextBox12.Text)
            actualiza.Parameters.AddWithValue("?CorreoCont", TextBox10.Text)
            actualiza.Parameters.AddWithValue("?WEB", TextBox11.Text)
            actualiza.Parameters.AddWithValue("?Referencia", TextBox13.Text)
            actualiza.Parameters.AddWithValue("?Descripcion", TextBox19.Text)
            actualiza.Parameters.AddWithValue("?Codigo", TextBox20.Text)
            actualiza.Parameters.AddWithValue("?Cantidad", TextBox21.Text)
            actualiza.Parameters.AddWithValue("?Precio", TextBox22.Text)
            actualiza.Parameters.AddWithValue("?Total", TextBox23.Text)
            actualiza.Parameters.AddWithValue("?Moneda", TextBox144.Text)
            actualiza.Parameters.AddWithValue("?ID", Label2.Text)
            actualiza.Parameters.AddWithValue("?Linea", Label36.Text)
            actualiza.Parameters.AddWithValue("?OC", TextBox122.Text)
            actualiza.Parameters.AddWithValue("?FechaOC", DateTimePicker1.Text)
            actualiza.Parameters.AddWithValue("?Ocitems", TextBox124.Text)
            actualiza.Parameters.AddWithValue("?FechOCItems", DateTimePicker3.Text)
            actualiza.Parameters.AddWithValue("?Fechaent", DateTimePicker42.Text)
            actualiza.Parameters.AddWithValue("?FecEntItems", DateTimePicker23.Text)
            actualiza.ExecuteNonQuery()


        End If

    End Sub
    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()

        Else
            On Error Resume Next
            Dim edicion As String = "UPDATE TSADATACOTIZACION SET Cotizacion= ?Cotizacion, Fecha= ?Fecha, 
            Razon_Social= ?Razonsocial, RUT = ?RUT, Atencion = ?Atencion, Direccion_ate= ?Direccionate, Telefono_ate= ?TelefonoATe, Correo_ate= ?CorreoAte,
            Contacto= ?Contacto, Telefono_cont= ?TelefonoCont, Correo_cont= ?CorreoCont, Pagina_Web= ?WEB, Referencia= ?Referencia, Descripcion_mat= ?Descripcion, 
            Codigo_mat= ?Codigo, Cantidad= ?Cantidad, Precio= ?Precio, Total= ?Total, Moneda= ?Moneda, Linea=?Linea, OC= ?OC, FechaOC=?FechaOC, OC_Items=?Ocitems, Fecha_OC_Items=?FechOCItems, Fecha_Entrega=?Fechaent,
            Fecha_Ent_Items=?FecEntItems WHERE ID= ?ID and Linea=?Linea"

            Dim actualiza As New MySqlCommand(edicion, conex)

            actualiza.Parameters.AddWithValue("?Cotizacion", TextBox7.Text)
            actualiza.Parameters.AddWithValue("?Fecha", TextBox8.Text)
            actualiza.Parameters.AddWithValue("?RazonSocial", TextBox1.Text)
            actualiza.Parameters.AddWithValue("?RUT", TextBox3.Text)
            actualiza.Parameters.AddWithValue("?Atencion", TextBox2.Text)
            actualiza.Parameters.AddWithValue("?Direccionate", TextBox4.Text)
            actualiza.Parameters.AddWithValue("?Telefonoate", TextBox5.Text)
            actualiza.Parameters.AddWithValue("?CorreoAte", TextBox6.Text)
            actualiza.Parameters.AddWithValue("?Contacto", TextBox9.Text)
            actualiza.Parameters.AddWithValue("?TelefonoCont", TextBox12.Text)
            actualiza.Parameters.AddWithValue("?CorreoCont", TextBox10.Text)
            actualiza.Parameters.AddWithValue("?WEB", TextBox11.Text)
            actualiza.Parameters.AddWithValue("?Referencia", TextBox13.Text)
            actualiza.Parameters.AddWithValue("?Descripcion", TextBox24.Text)
            actualiza.Parameters.AddWithValue("?Codigo", TextBox25.Text)
            actualiza.Parameters.AddWithValue("?Cantidad", TextBox26.Text)
            actualiza.Parameters.AddWithValue("?Precio", TextBox27.Text)
            actualiza.Parameters.AddWithValue("?Total", TextBox28.Text)
            actualiza.Parameters.AddWithValue("?Moneda", TextBox145.Text)
            actualiza.Parameters.AddWithValue("?ID", Label2.Text)
            actualiza.Parameters.AddWithValue("?Linea", Label37.Text)
            actualiza.Parameters.AddWithValue("?OC", TextBox122.Text)
            actualiza.Parameters.AddWithValue("?FechaOC", DateTimePicker1.Text)
            actualiza.Parameters.AddWithValue("?Ocitems", TextBox125.Text)
            actualiza.Parameters.AddWithValue("?FechOCItems", DateTimePicker4.Text)
            actualiza.Parameters.AddWithValue("?Fechaent", DateTimePicker42.Text)
            actualiza.Parameters.AddWithValue("?FecEntItems", DateTimePicker24.Text)
            actualiza.ExecuteNonQuery()
        End If

    End Sub
    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()

        Else
            On Error Resume Next
            Dim edicion As String = "UPDATE TSADATACOTIZACION SET Cotizacion= ?Cotizacion, Fecha= ?Fecha, 
            Razon_Social= ?Razonsocial, RUT = ?RUT, Atencion = ?Atencion, Direccion_ate= ?Direccionate, Telefono_ate= ?TelefonoATe, Correo_ate= ?CorreoAte,
            Contacto= ?Contacto, Telefono_cont= ?TelefonoCont, Correo_cont= ?CorreoCont, Pagina_Web= ?WEB, Referencia= ?Referencia, Descripcion_mat= ?Descripcion, 
            Codigo_mat= ?Codigo, Cantidad= ?Cantidad, Precio= ?Precio, Total= ?Total, Moneda= ?Moneda, Linea=?Linea, OC= ?OC, FechaOC=?FechaOC, OC_Items=?Ocitems, Fecha_OC_Items=?FechOCItems, Fecha_Entrega=?Fechaent,
            Fecha_Ent_Items=?FecEntItems WHERE ID= ?ID and Linea=?Linea"

            Dim actualiza As New MySqlCommand(edicion, conex)

            actualiza.Parameters.AddWithValue("?Cotizacion", TextBox7.Text)
            actualiza.Parameters.AddWithValue("?Fecha", TextBox8.Text)
            actualiza.Parameters.AddWithValue("?RazonSocial", TextBox1.Text)
            actualiza.Parameters.AddWithValue("?RUT", TextBox3.Text)
            actualiza.Parameters.AddWithValue("?Atencion", TextBox2.Text)
            actualiza.Parameters.AddWithValue("?Direccionate", TextBox4.Text)
            actualiza.Parameters.AddWithValue("?Telefonoate", TextBox5.Text)
            actualiza.Parameters.AddWithValue("?CorreoAte", TextBox6.Text)
            actualiza.Parameters.AddWithValue("?Contacto", TextBox9.Text)
            actualiza.Parameters.AddWithValue("?TelefonoCont", TextBox12.Text)
            actualiza.Parameters.AddWithValue("?CorreoCont", TextBox10.Text)
            actualiza.Parameters.AddWithValue("?WEB", TextBox11.Text)
            actualiza.Parameters.AddWithValue("?Referencia", TextBox13.Text)
            actualiza.Parameters.AddWithValue("?Descripcion", TextBox29.Text)
            actualiza.Parameters.AddWithValue("?Codigo", TextBox30.Text)
            actualiza.Parameters.AddWithValue("?Cantidad", TextBox31.Text)
            actualiza.Parameters.AddWithValue("?Precio", TextBox32.Text)
            actualiza.Parameters.AddWithValue("?Total", TextBox33.Text)
            actualiza.Parameters.AddWithValue("?Moneda", TextBox146.Text)
            actualiza.Parameters.AddWithValue("?ID", Label2.Text)
            actualiza.Parameters.AddWithValue("?Linea", Label38.Text)
            actualiza.Parameters.AddWithValue("?OC", TextBox122.Text)
            actualiza.Parameters.AddWithValue("?FechaOC", DateTimePicker1.Text)
            actualiza.Parameters.AddWithValue("?Ocitems", TextBox126.Text)
            actualiza.Parameters.AddWithValue("?FechOCItems", DateTimePicker5.Text)
            actualiza.Parameters.AddWithValue("?Fechaent", DateTimePicker42.Text)
            actualiza.Parameters.AddWithValue("?FecEntItems", DateTimePicker25.Text)
            actualiza.ExecuteNonQuery()
        End If
    End Sub
    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()

        Else
            On Error Resume Next
            Dim edicion As String = "UPDATE TSADATACOTIZACION SET Cotizacion= ?Cotizacion, Fecha= ?Fecha, 
            Razon_Social= ?Razonsocial, RUT = ?RUT, Atencion = ?Atencion, Direccion_ate= ?Direccionate, Telefono_ate= ?TelefonoATe, Correo_ate= ?CorreoAte,
            Contacto= ?Contacto, Telefono_cont= ?TelefonoCont, Correo_cont= ?CorreoCont, Pagina_Web= ?WEB, Referencia= ?Referencia, Descripcion_mat= ?Descripcion, 
            Codigo_mat= ?Codigo, Cantidad= ?Cantidad, Precio= ?Precio, Total= ?Total, Moneda= ?Moneda, Linea=?Linea, OC= ?OC, FechaOC=?FechaOC, OC_Items=?Ocitems, Fecha_OC_Items=?FechOCItems, Fecha_Entrega=?Fechaent,
            Fecha_Ent_Items=?FecEntItems WHERE ID= ?ID and Linea=?Linea"

            Dim actualiza As New MySqlCommand(edicion, conex)

            actualiza.Parameters.AddWithValue("?Cotizacion", TextBox7.Text)
            actualiza.Parameters.AddWithValue("?Fecha", TextBox8.Text)
            actualiza.Parameters.AddWithValue("?RazonSocial", TextBox1.Text)
            actualiza.Parameters.AddWithValue("?RUT", TextBox3.Text)
            actualiza.Parameters.AddWithValue("?Atencion", TextBox2.Text)
            actualiza.Parameters.AddWithValue("?Direccionate", TextBox4.Text)
            actualiza.Parameters.AddWithValue("?Telefonoate", TextBox5.Text)
            actualiza.Parameters.AddWithValue("?CorreoAte", TextBox6.Text)
            actualiza.Parameters.AddWithValue("?Contacto", TextBox9.Text)
            actualiza.Parameters.AddWithValue("?TelefonoCont", TextBox12.Text)
            actualiza.Parameters.AddWithValue("?CorreoCont", TextBox10.Text)
            actualiza.Parameters.AddWithValue("?WEB", TextBox11.Text)
            actualiza.Parameters.AddWithValue("?Referencia", TextBox13.Text)
            actualiza.Parameters.AddWithValue("?Descripcion", TextBox34.Text)
            actualiza.Parameters.AddWithValue("?Codigo", TextBox35.Text)
            actualiza.Parameters.AddWithValue("?Cantidad", TextBox36.Text)
            actualiza.Parameters.AddWithValue("?Precio", TextBox37.Text)
            actualiza.Parameters.AddWithValue("?Total", TextBox38.Text)
            actualiza.Parameters.AddWithValue("?Moneda", TextBox147.Text)
            actualiza.Parameters.AddWithValue("?ID", Label2.Text)
            actualiza.Parameters.AddWithValue("?Linea", Label39.Text)
            actualiza.Parameters.AddWithValue("?OC", TextBox122.Text)
            actualiza.Parameters.AddWithValue("?FechaOC", DateTimePicker1.Text)
            actualiza.Parameters.AddWithValue("?Ocitems", TextBox127.Text)
            actualiza.Parameters.AddWithValue("?FechOCItems", DateTimePicker6.Text)
            actualiza.Parameters.AddWithValue("?Fechaent", DateTimePicker42.Text)
            actualiza.Parameters.AddWithValue("?FecEntItems", DateTimePicker26.Text)
            actualiza.ExecuteNonQuery()
        End If
    End Sub
    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()

        Else
            On Error Resume Next
            Dim edicion As String = "UPDATE TSADATACOTIZACION SET Cotizacion= ?Cotizacion, Fecha= ?Fecha, 
            Razon_Social= ?Razonsocial, RUT = ?RUT, Atencion = ?Atencion, Direccion_ate= ?Direccionate, Telefono_ate= ?TelefonoATe, Correo_ate= ?CorreoAte,
            Contacto= ?Contacto, Telefono_cont= ?TelefonoCont, Correo_cont= ?CorreoCont, Pagina_Web= ?WEB, Referencia= ?Referencia, Descripcion_mat= ?Descripcion, 
            Codigo_mat= ?Codigo, Cantidad= ?Cantidad, Precio= ?Precio, Total= ?Total, Moneda= ?Moneda, Linea=?Linea, OC= ?OC, FechaOC=?FechaOC, OC_Items=?Ocitems, Fecha_OC_Items=?FechOCItems, Fecha_Entrega=?Fechaent,
            Fecha_Ent_Items=?FecEntItems WHERE ID= ?ID and Linea=?Linea"

            Dim actualiza As New MySqlCommand(edicion, conex)

            actualiza.Parameters.AddWithValue("?Cotizacion", TextBox7.Text)
            actualiza.Parameters.AddWithValue("?Fecha", TextBox8.Text)
            actualiza.Parameters.AddWithValue("?RazonSocial", TextBox1.Text)
            actualiza.Parameters.AddWithValue("?RUT", TextBox3.Text)
            actualiza.Parameters.AddWithValue("?Atencion", TextBox2.Text)
            actualiza.Parameters.AddWithValue("?Direccionate", TextBox4.Text)
            actualiza.Parameters.AddWithValue("?Telefonoate", TextBox5.Text)
            actualiza.Parameters.AddWithValue("?CorreoAte", TextBox6.Text)
            actualiza.Parameters.AddWithValue("?Contacto", TextBox9.Text)
            actualiza.Parameters.AddWithValue("?TelefonoCont", TextBox12.Text)
            actualiza.Parameters.AddWithValue("?CorreoCont", TextBox10.Text)
            actualiza.Parameters.AddWithValue("?WEB", TextBox11.Text)
            actualiza.Parameters.AddWithValue("?Referencia", TextBox13.Text)
            actualiza.Parameters.AddWithValue("?Descripcion", TextBox39.Text)
            actualiza.Parameters.AddWithValue("?Codigo", TextBox40.Text)
            actualiza.Parameters.AddWithValue("?Cantidad", TextBox41.Text)
            actualiza.Parameters.AddWithValue("?Precio", TextBox42.Text)
            actualiza.Parameters.AddWithValue("?Total", TextBox43.Text)
            actualiza.Parameters.AddWithValue("?Moneda", TextBox148.Text)
            actualiza.Parameters.AddWithValue("?ID", Label2.Text)
            actualiza.Parameters.AddWithValue("?Linea", Label40.Text)
            actualiza.Parameters.AddWithValue("?OC", TextBox122.Text)
            actualiza.Parameters.AddWithValue("?FechaOC", DateTimePicker1.Text)
            actualiza.Parameters.AddWithValue("?Ocitems", TextBox128.Text)
            actualiza.Parameters.AddWithValue("?FechOCItems", DateTimePicker7.Text)
            actualiza.Parameters.AddWithValue("?Fechaent", DateTimePicker42.Text)
            actualiza.Parameters.AddWithValue("?FecEntItems", DateTimePicker27.Text)
            actualiza.ExecuteNonQuery()
        End If
    End Sub
    Private Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox7.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()

        Else
            On Error Resume Next
            Dim edicion As String = "UPDATE TSADATACOTIZACION SET Cotizacion= ?Cotizacion, Fecha= ?Fecha, 
            Razon_Social= ?Razonsocial, RUT = ?RUT, Atencion = ?Atencion, Direccion_ate= ?Direccionate, Telefono_ate= ?TelefonoATe, Correo_ate= ?CorreoAte,
            Contacto= ?Contacto, Telefono_cont= ?TelefonoCont, Correo_cont= ?CorreoCont, Pagina_Web= ?WEB, Referencia= ?Referencia, Descripcion_mat= ?Descripcion, 
            Codigo_mat= ?Codigo, Cantidad= ?Cantidad, Precio= ?Precio, Total= ?Total, Moneda= ?Moneda, Linea=?Linea, OC= ?OC, FechaOC=?FechaOC, OC_Items=?Ocitems, Fecha_OC_Items=?FechOCItems, Fecha_Entrega=?Fechaent,
            Fecha_Ent_Items=?FecEntItems WHERE ID= ?ID and Linea=?Linea"
            Dim actualiza As New MySqlCommand(edicion, conex)

            actualiza.Parameters.AddWithValue("?Cotizacion", TextBox7.Text)
            actualiza.Parameters.AddWithValue("?Fecha", TextBox8.Text)
            actualiza.Parameters.AddWithValue("?RazonSocial", TextBox1.Text)
            actualiza.Parameters.AddWithValue("?RUT", TextBox3.Text)
            actualiza.Parameters.AddWithValue("?Atencion", TextBox2.Text)
            actualiza.Parameters.AddWithValue("?Direccionate", TextBox4.Text)
            actualiza.Parameters.AddWithValue("?Telefonoate", TextBox5.Text)
            actualiza.Parameters.AddWithValue("?CorreoAte", TextBox6.Text)
            actualiza.Parameters.AddWithValue("?Contacto", TextBox9.Text)
            actualiza.Parameters.AddWithValue("?TelefonoCont", TextBox12.Text)
            actualiza.Parameters.AddWithValue("?CorreoCont", TextBox10.Text)
            actualiza.Parameters.AddWithValue("?WEB", TextBox11.Text)
            actualiza.Parameters.AddWithValue("?Referencia", TextBox13.Text)
            actualiza.Parameters.AddWithValue("?Descripcion", TextBox44.Text)
            actualiza.Parameters.AddWithValue("?Codigo", TextBox45.Text)
            actualiza.Parameters.AddWithValue("?Cantidad", TextBox46.Text)
            actualiza.Parameters.AddWithValue("?Precio", TextBox47.Text)
            actualiza.Parameters.AddWithValue("?Total", TextBox48.Text)
            actualiza.Parameters.AddWithValue("?Moneda", TextBox149.Text)
            actualiza.Parameters.AddWithValue("?ID", Label2.Text)
            actualiza.Parameters.AddWithValue("?Linea", Label41.Text)
            actualiza.Parameters.AddWithValue("?OC", TextBox122.Text)
            actualiza.Parameters.AddWithValue("?FechaOC", DateTimePicker1.Text)
            actualiza.Parameters.AddWithValue("?Ocitems", TextBox129.Text)
            actualiza.Parameters.AddWithValue("?FechOCItems", DateTimePicker8.Text)
            actualiza.Parameters.AddWithValue("?Fechaent", DateTimePicker42.Text)
            actualiza.Parameters.AddWithValue("?FecEntItems", DateTimePicker28.Text)
            actualiza.ExecuteNonQuery()
        End If
    End Sub

    Private Sub CheckBox8_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox8.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()

        Else
            On Error Resume Next
            Dim edicion As String = "UPDATE TSADATACOTIZACION SET Cotizacion= ?Cotizacion, Fecha= ?Fecha, 
            Razon_Social= ?Razonsocial, RUT = ?RUT, Atencion = ?Atencion, Direccion_ate= ?Direccionate, Telefono_ate= ?TelefonoATe, Correo_ate= ?CorreoAte,
            Contacto= ?Contacto, Telefono_cont= ?TelefonoCont, Correo_cont= ?CorreoCont, Pagina_Web= ?WEB, Referencia= ?Referencia, Descripcion_mat= ?Descripcion, 
            Codigo_mat= ?Codigo, Cantidad= ?Cantidad, Precio= ?Precio, Total= ?Total, Moneda= ?Moneda, Linea=?Linea, OC= ?OC, FechaOC=?FechaOC, OC_Items=?Ocitems, Fecha_OC_Items=?FechOCItems, Fecha_Entrega=?Fechaent,
            Fecha_Ent_Items=?FecEntItems WHERE ID= ?ID and Linea=?Linea"

            Dim actualiza As New MySqlCommand(edicion, conex)

            actualiza.Parameters.AddWithValue("?Cotizacion", TextBox7.Text)
            actualiza.Parameters.AddWithValue("?Fecha", TextBox8.Text)
            actualiza.Parameters.AddWithValue("?RazonSocial", TextBox1.Text)
            actualiza.Parameters.AddWithValue("?RUT", TextBox3.Text)
            actualiza.Parameters.AddWithValue("?Atencion", TextBox2.Text)
            actualiza.Parameters.AddWithValue("?Direccionate", TextBox4.Text)
            actualiza.Parameters.AddWithValue("?Telefonoate", TextBox5.Text)
            actualiza.Parameters.AddWithValue("?CorreoAte", TextBox6.Text)
            actualiza.Parameters.AddWithValue("?Contacto", TextBox9.Text)
            actualiza.Parameters.AddWithValue("?TelefonoCont", TextBox12.Text)
            actualiza.Parameters.AddWithValue("?CorreoCont", TextBox10.Text)
            actualiza.Parameters.AddWithValue("?WEB", TextBox11.Text)
            actualiza.Parameters.AddWithValue("?Referencia", TextBox13.Text)
            actualiza.Parameters.AddWithValue("?Descripcion", TextBox49.Text)
            actualiza.Parameters.AddWithValue("?Codigo", TextBox50.Text)
            actualiza.Parameters.AddWithValue("?Cantidad", TextBox51.Text)
            actualiza.Parameters.AddWithValue("?Precio", TextBox52.Text)
            actualiza.Parameters.AddWithValue("?Total", TextBox53.Text)
            actualiza.Parameters.AddWithValue("?Moneda", TextBox150.Text)
            actualiza.Parameters.AddWithValue("?ID", Label2.Text)
            actualiza.Parameters.AddWithValue("?Linea", Label42.Text)
            actualiza.Parameters.AddWithValue("?OC", TextBox122.Text)
            actualiza.Parameters.AddWithValue("?FechaOC", DateTimePicker1.Text)
            actualiza.Parameters.AddWithValue("?Ocitems", TextBox130.Text)
            actualiza.Parameters.AddWithValue("?FechOCItems", DateTimePicker9.Text)
            actualiza.Parameters.AddWithValue("?Fechaent", DateTimePicker42.Text)
            actualiza.Parameters.AddWithValue("?FecEntItems", DateTimePicker29.Text)

            actualiza.ExecuteNonQuery()
        End If
    End Sub
    Private Sub CheckBox9_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox9.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()

        Else
            On Error Resume Next
            Dim edicion As String = "UPDATE TSADATACOTIZACION SET Cotizacion= ?Cotizacion, Fecha= ?Fecha, 
            Razon_Social= ?Razonsocial, RUT = ?RUT, Atencion = ?Atencion, Direccion_ate= ?Direccionate, Telefono_ate= ?TelefonoATe, Correo_ate= ?CorreoAte,
            Contacto= ?Contacto, Telefono_cont= ?TelefonoCont, Correo_cont= ?CorreoCont, Pagina_Web= ?WEB, Referencia= ?Referencia, Descripcion_mat= ?Descripcion, 
            Codigo_mat= ?Codigo, Cantidad= ?Cantidad, Precio= ?Precio, Total= ?Total, Moneda= ?Moneda, Linea=?Linea, OC= ?OC, FechaOC=?FechaOC, OC_Items=?Ocitems, Fecha_OC_Items=?FechOCItems, Fecha_Entrega=?Fechaent,
            Fecha_Ent_Items=?FecEntItems WHERE ID= ?ID and Linea=?Linea"
            Dim actualiza As New MySqlCommand(edicion, conex)

            actualiza.Parameters.AddWithValue("?Cotizacion", TextBox7.Text)
            actualiza.Parameters.AddWithValue("?Fecha", TextBox8.Text)
            actualiza.Parameters.AddWithValue("?RazonSocial", TextBox1.Text)
            actualiza.Parameters.AddWithValue("?RUT", TextBox3.Text)
            actualiza.Parameters.AddWithValue("?Atencion", TextBox2.Text)
            actualiza.Parameters.AddWithValue("?Direccionate", TextBox4.Text)
            actualiza.Parameters.AddWithValue("?Telefonoate", TextBox5.Text)
            actualiza.Parameters.AddWithValue("?CorreoAte", TextBox6.Text)
            actualiza.Parameters.AddWithValue("?Contacto", TextBox9.Text)
            actualiza.Parameters.AddWithValue("?TelefonoCont", TextBox12.Text)
            actualiza.Parameters.AddWithValue("?CorreoCont", TextBox10.Text)
            actualiza.Parameters.AddWithValue("?WEB", TextBox11.Text)
            actualiza.Parameters.AddWithValue("?Referencia", TextBox13.Text)
            actualiza.Parameters.AddWithValue("?Descripcion", TextBox54.Text)
            actualiza.Parameters.AddWithValue("?Codigo", TextBox55.Text)
            actualiza.Parameters.AddWithValue("?Cantidad", TextBox56.Text)
            actualiza.Parameters.AddWithValue("?Precio", TextBox57.Text)
            actualiza.Parameters.AddWithValue("?Total", TextBox58.Text)
            actualiza.Parameters.AddWithValue("?Moneda", TextBox151.Text)
            actualiza.Parameters.AddWithValue("?ID", Label2.Text)
            actualiza.Parameters.AddWithValue("?Linea", Label43.Text)
            actualiza.Parameters.AddWithValue("?OC", TextBox122.Text)
            actualiza.Parameters.AddWithValue("?FechaOC", DateTimePicker1.Text)
            actualiza.Parameters.AddWithValue("?Ocitems", TextBox131.Text)
            actualiza.Parameters.AddWithValue("?FechOCItems", DateTimePicker10.Text)
            actualiza.Parameters.AddWithValue("?Fechaent", DateTimePicker42.Text)
            actualiza.Parameters.AddWithValue("?FecEntItems", DateTimePicker30.Text)
            actualiza.ExecuteNonQuery()
        End If
    End Sub
    Private Sub CheckBox10_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox10.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()

        Else
            On Error Resume Next
            Dim edicion As String = "UPDATE TSADATACOTIZACION SET Cotizacion= ?Cotizacion, Fecha= ?Fecha, 
            Razon_Social= ?Razonsocial, RUT = ?RUT, Atencion = ?Atencion, Direccion_ate= ?Direccionate, Telefono_ate= ?TelefonoATe, Correo_ate= ?CorreoAte,
            Contacto= ?Contacto, Telefono_cont= ?TelefonoCont, Correo_cont= ?CorreoCont, Pagina_Web= ?WEB, Referencia= ?Referencia, Descripcion_mat= ?Descripcion, 
            Codigo_mat= ?Codigo, Cantidad= ?Cantidad, Precio= ?Precio, Total= ?Total, Moneda= ?Moneda, Linea=?Linea, OC= ?OC, FechaOC=?FechaOC, OC_Items=?Ocitems, Fecha_OC_Items=?FechOCItems, Fecha_Entrega=?Fechaent,
            Fecha_Ent_Items=?FecEntItems WHERE ID= ?ID and Linea=?Linea"

            Dim actualiza As New MySqlCommand(edicion, conex)

            actualiza.Parameters.AddWithValue("?Cotizacion", TextBox7.Text)
            actualiza.Parameters.AddWithValue("?Fecha", TextBox8.Text)
            actualiza.Parameters.AddWithValue("?RazonSocial", TextBox1.Text)
            actualiza.Parameters.AddWithValue("?RUT", TextBox3.Text)
            actualiza.Parameters.AddWithValue("?Atencion", TextBox2.Text)
            actualiza.Parameters.AddWithValue("?Direccionate", TextBox4.Text)
            actualiza.Parameters.AddWithValue("?Telefonoate", TextBox5.Text)
            actualiza.Parameters.AddWithValue("?CorreoAte", TextBox6.Text)
            actualiza.Parameters.AddWithValue("?Contacto", TextBox9.Text)
            actualiza.Parameters.AddWithValue("?TelefonoCont", TextBox12.Text)
            actualiza.Parameters.AddWithValue("?CorreoCont", TextBox10.Text)
            actualiza.Parameters.AddWithValue("?WEB", TextBox11.Text)
            actualiza.Parameters.AddWithValue("?Referencia", TextBox13.Text)
            actualiza.Parameters.AddWithValue("?Descripcion", TextBox59.Text)
            actualiza.Parameters.AddWithValue("?Codigo", TextBox60.Text)
            actualiza.Parameters.AddWithValue("?Cantidad", TextBox61.Text)
            actualiza.Parameters.AddWithValue("?Precio", TextBox62.Text)
            actualiza.Parameters.AddWithValue("?Total", TextBox63.Text)
            actualiza.Parameters.AddWithValue("?Moneda", TextBox152.Text)
            actualiza.Parameters.AddWithValue("?ID", Label2.Text)
            actualiza.Parameters.AddWithValue("?Linea", Label44.Text)
            actualiza.Parameters.AddWithValue("?OC", TextBox122.Text)
            actualiza.Parameters.AddWithValue("?FechaOC", DateTimePicker1.Text)
            actualiza.Parameters.AddWithValue("?Ocitems", TextBox132.Text)
            actualiza.Parameters.AddWithValue("?FechOCItems", DateTimePicker11.Text)
            actualiza.Parameters.AddWithValue("?Fechaent", DateTimePicker42.Text)
            actualiza.Parameters.AddWithValue("?FecEntItems", DateTimePicker31.Text)
            actualiza.ExecuteNonQuery()
        End If
    End Sub
    Private Sub CheckBox11_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox11.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()

        Else
            On Error Resume Next
            Dim edicion As String = "UPDATE TSADATACOTIZACION SET Cotizacion= ?Cotizacion, Fecha= ?Fecha, 
            Razon_Social= ?Razonsocial, RUT = ?RUT, Atencion = ?Atencion, Direccion_ate= ?Direccionate, Telefono_ate= ?TelefonoATe, Correo_ate= ?CorreoAte,
            Contacto= ?Contacto, Telefono_cont= ?TelefonoCont, Correo_cont= ?CorreoCont, Pagina_Web= ?WEB, Referencia= ?Referencia, Descripcion_mat= ?Descripcion, 
            Codigo_mat= ?Codigo, Cantidad= ?Cantidad, Precio= ?Precio, Total= ?Total, Moneda= ?Moneda, Linea=?Linea, OC= ?OC, FechaOC=?FechaOC, OC_Items=?Ocitems, Fecha_OC_Items=?FechOCItems, Fecha_Entrega=?Fechaent,
            Fecha_Ent_Items=?FecEntItems WHERE ID= ?ID and Linea=?Linea"

            Dim actualiza As New MySqlCommand(edicion, conex)

            actualiza.Parameters.AddWithValue("?Cotizacion", TextBox7.Text)
            actualiza.Parameters.AddWithValue("?Fecha", TextBox8.Text)
            actualiza.Parameters.AddWithValue("?RazonSocial", TextBox1.Text)
            actualiza.Parameters.AddWithValue("?RUT", TextBox3.Text)
            actualiza.Parameters.AddWithValue("?Atencion", TextBox2.Text)
            actualiza.Parameters.AddWithValue("?Direccionate", TextBox4.Text)
            actualiza.Parameters.AddWithValue("?Telefonoate", TextBox5.Text)
            actualiza.Parameters.AddWithValue("?CorreoAte", TextBox6.Text)
            actualiza.Parameters.AddWithValue("?Contacto", TextBox9.Text)
            actualiza.Parameters.AddWithValue("?TelefonoCont", TextBox12.Text)
            actualiza.Parameters.AddWithValue("?CorreoCont", TextBox10.Text)
            actualiza.Parameters.AddWithValue("?WEB", TextBox11.Text)
            actualiza.Parameters.AddWithValue("?Referencia", TextBox13.Text)
            actualiza.Parameters.AddWithValue("?Descripcion", TextBox64.Text)
            actualiza.Parameters.AddWithValue("?Codigo", TextBox65.Text)
            actualiza.Parameters.AddWithValue("?Cantidad", TextBox66.Text)
            actualiza.Parameters.AddWithValue("?Precio", TextBox67.Text)
            actualiza.Parameters.AddWithValue("?Total", TextBox68.Text)
            actualiza.Parameters.AddWithValue("?Moneda", TextBox153.Text)
            actualiza.Parameters.AddWithValue("?ID", Label2.Text)
            actualiza.Parameters.AddWithValue("?Linea", Label45.Text)
            actualiza.Parameters.AddWithValue("?OC", TextBox122.Text)
            actualiza.Parameters.AddWithValue("?FechaOC", DateTimePicker1.Text)
            actualiza.Parameters.AddWithValue("?Ocitems", TextBox133.Text)
            actualiza.Parameters.AddWithValue("?FechOCItems", DateTimePicker12.Text)
            actualiza.Parameters.AddWithValue("?Fechaent", DateTimePicker42.Text)
            actualiza.Parameters.AddWithValue("?FecEntItems", DateTimePicker32.Text)
            actualiza.ExecuteNonQuery()
        End If
    End Sub
    Private Sub CheckBox12_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox12.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()

        Else
            On Error Resume Next
            Dim edicion As String = "UPDATE TSADATACOTIZACION SET Cotizacion= ?Cotizacion, Fecha= ?Fecha, 
            Razon_Social= ?Razonsocial, RUT = ?RUT, Atencion = ?Atencion, Direccion_ate= ?Direccionate, Telefono_ate= ?TelefonoATe, Correo_ate= ?CorreoAte,
            Contacto= ?Contacto, Telefono_cont= ?TelefonoCont, Correo_cont= ?CorreoCont, Pagina_Web= ?WEB, Referencia= ?Referencia, Descripcion_mat= ?Descripcion, 
            Codigo_mat= ?Codigo, Cantidad= ?Cantidad, Precio= ?Precio, Total= ?Total, Moneda= ?Moneda, Linea=?Linea, OC= ?OC, FechaOC=?FechaOC, OC_Items=?Ocitems, Fecha_OC_Items=?FechOCItems, Fecha_Entrega=?Fechaent,
            Fecha_Ent_Items=?FecEntItems WHERE ID= ?ID and Linea=?Linea"

            Dim actualiza As New MySqlCommand(edicion, conex)

            actualiza.Parameters.AddWithValue("?Cotizacion", TextBox7.Text)
            actualiza.Parameters.AddWithValue("?Fecha", TextBox8.Text)
            actualiza.Parameters.AddWithValue("?RazonSocial", TextBox1.Text)
            actualiza.Parameters.AddWithValue("?RUT", TextBox3.Text)
            actualiza.Parameters.AddWithValue("?Atencion", TextBox2.Text)
            actualiza.Parameters.AddWithValue("?Direccionate", TextBox4.Text)
            actualiza.Parameters.AddWithValue("?Telefonoate", TextBox5.Text)
            actualiza.Parameters.AddWithValue("?CorreoAte", TextBox6.Text)
            actualiza.Parameters.AddWithValue("?Contacto", TextBox9.Text)
            actualiza.Parameters.AddWithValue("?TelefonoCont", TextBox12.Text)
            actualiza.Parameters.AddWithValue("?CorreoCont", TextBox10.Text)
            actualiza.Parameters.AddWithValue("?WEB", TextBox11.Text)
            actualiza.Parameters.AddWithValue("?Referencia", TextBox13.Text)
            actualiza.Parameters.AddWithValue("?Descripcion", TextBox69.Text)
            actualiza.Parameters.AddWithValue("?Codigo", TextBox70.Text)
            actualiza.Parameters.AddWithValue("?Cantidad", TextBox71.Text)
            actualiza.Parameters.AddWithValue("?Precio", TextBox72.Text)
            actualiza.Parameters.AddWithValue("?Total", TextBox73.Text)
            actualiza.Parameters.AddWithValue("?Moneda", TextBox154.Text)
            actualiza.Parameters.AddWithValue("?ID", Label2.Text)
            actualiza.Parameters.AddWithValue("?Linea", Label46.Text)
            actualiza.Parameters.AddWithValue("?OC", TextBox122.Text)
            actualiza.Parameters.AddWithValue("?FechaOC", DateTimePicker1.Text)
            actualiza.Parameters.AddWithValue("?Ocitems", TextBox134.Text)
            actualiza.Parameters.AddWithValue("?FechOCItems", DateTimePicker13.Text)
            actualiza.Parameters.AddWithValue("?Fechaent", DateTimePicker42.Text)
            actualiza.Parameters.AddWithValue("?FecEntItems", DateTimePicker33.Text)
            actualiza.ExecuteNonQuery()
        End If
    End Sub

    Private Sub CheckBox13_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox13.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()

        Else
            On Error Resume Next
            Dim edicion As String = "UPDATE TSADATACOTIZACION SET Cotizacion= ?Cotizacion, Fecha= ?Fecha, 
            Razon_Social= ?Razonsocial, RUT = ?RUT, Atencion = ?Atencion, Direccion_ate= ?Direccionate, Telefono_ate= ?TelefonoATe, Correo_ate= ?CorreoAte,
            Contacto= ?Contacto, Telefono_cont= ?TelefonoCont, Correo_cont= ?CorreoCont, Pagina_Web= ?WEB, Referencia= ?Referencia, Descripcion_mat= ?Descripcion, 
            Codigo_mat= ?Codigo, Cantidad= ?Cantidad, Precio= ?Precio, Total= ?Total, Moneda= ?Moneda, Linea=?Linea, OC= ?OC, FechaOC=?FechaOC, OC_Items=?Ocitems, Fecha_OC_Items=?FechOCItems, Fecha_Entrega=?Fechaent,
            Fecha_Ent_Items=?FecEntItems WHERE ID= ?ID and Linea=?Linea"
            Dim actualiza As New MySqlCommand(edicion, conex)

            actualiza.Parameters.AddWithValue("?Cotizacion", TextBox7.Text)
            actualiza.Parameters.AddWithValue("?Fecha", TextBox8.Text)
            actualiza.Parameters.AddWithValue("?RazonSocial", TextBox1.Text)
            actualiza.Parameters.AddWithValue("?RUT", TextBox3.Text)
            actualiza.Parameters.AddWithValue("?Atencion", TextBox2.Text)
            actualiza.Parameters.AddWithValue("?Direccionate", TextBox4.Text)
            actualiza.Parameters.AddWithValue("?Telefonoate", TextBox5.Text)
            actualiza.Parameters.AddWithValue("?CorreoAte", TextBox6.Text)
            actualiza.Parameters.AddWithValue("?Contacto", TextBox9.Text)
            actualiza.Parameters.AddWithValue("?TelefonoCont", TextBox12.Text)
            actualiza.Parameters.AddWithValue("?CorreoCont", TextBox10.Text)
            actualiza.Parameters.AddWithValue("?WEB", TextBox11.Text)
            actualiza.Parameters.AddWithValue("?Referencia", TextBox13.Text)
            actualiza.Parameters.AddWithValue("?Descripcion", TextBox74.Text)
            actualiza.Parameters.AddWithValue("?Codigo", TextBox75.Text)
            actualiza.Parameters.AddWithValue("?Cantidad", TextBox76.Text)
            actualiza.Parameters.AddWithValue("?Precio", TextBox77.Text)
            actualiza.Parameters.AddWithValue("?Total", TextBox78.Text)
            actualiza.Parameters.AddWithValue("?Moneda", TextBox155.Text)
            actualiza.Parameters.AddWithValue("?ID", Label2.Text)
            actualiza.Parameters.AddWithValue("?Linea", Label47.Text)
            actualiza.Parameters.AddWithValue("?OC", TextBox122.Text)
            actualiza.Parameters.AddWithValue("?FechaOC", DateTimePicker1.Text)
            actualiza.Parameters.AddWithValue("?Ocitems", TextBox135.Text)
            actualiza.Parameters.AddWithValue("?FechOCItems", DateTimePicker14.Text)
            actualiza.Parameters.AddWithValue("?Fechaent", DateTimePicker42.Text)
            actualiza.Parameters.AddWithValue("?FecEntItems", DateTimePicker34.Text)
            actualiza.ExecuteNonQuery()
        End If
    End Sub
    Private Sub CheckBox14_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox14.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()

        Else
            On Error Resume Next
            Dim edicion As String = "UPDATE TSADATACOTIZACION SET Cotizacion= ?Cotizacion, Fecha= ?Fecha, 
            Razon_Social= ?Razonsocial, RUT = ?RUT, Atencion = ?Atencion, Direccion_ate= ?Direccionate, Telefono_ate= ?TelefonoATe, Correo_ate= ?CorreoAte,
            Contacto= ?Contacto, Telefono_cont= ?TelefonoCont, Correo_cont= ?CorreoCont, Pagina_Web= ?WEB, Referencia= ?Referencia, Descripcion_mat= ?Descripcion, 
            Codigo_mat= ?Codigo, Cantidad= ?Cantidad, Precio= ?Precio, Total= ?Total, Moneda= ?Moneda, Linea=?Linea, OC= ?OC, FechaOC=?FechaOC, OC_Items=?Ocitems, Fecha_OC_Items=?FechOCItems, Fecha_Entrega=?Fechaent,
            Fecha_Ent_Items=?FecEntItems WHERE ID= ?ID and Linea=?Linea"

            Dim actualiza As New MySqlCommand(edicion, conex)

            actualiza.Parameters.AddWithValue("?Cotizacion", TextBox7.Text)
            actualiza.Parameters.AddWithValue("?Fecha", TextBox8.Text)
            actualiza.Parameters.AddWithValue("?RazonSocial", TextBox1.Text)
            actualiza.Parameters.AddWithValue("?RUT", TextBox3.Text)
            actualiza.Parameters.AddWithValue("?Atencion", TextBox2.Text)
            actualiza.Parameters.AddWithValue("?Direccionate", TextBox4.Text)
            actualiza.Parameters.AddWithValue("?Telefonoate", TextBox5.Text)
            actualiza.Parameters.AddWithValue("?CorreoAte", TextBox6.Text)
            actualiza.Parameters.AddWithValue("?Contacto", TextBox9.Text)
            actualiza.Parameters.AddWithValue("?TelefonoCont", TextBox12.Text)
            actualiza.Parameters.AddWithValue("?CorreoCont", TextBox10.Text)
            actualiza.Parameters.AddWithValue("?WEB", TextBox11.Text)
            actualiza.Parameters.AddWithValue("?Referencia", TextBox13.Text)
            actualiza.Parameters.AddWithValue("?Descripcion", TextBox79.Text)
            actualiza.Parameters.AddWithValue("?Codigo", TextBox80.Text)
            actualiza.Parameters.AddWithValue("?Cantidad", TextBox81.Text)
            actualiza.Parameters.AddWithValue("?Precio", TextBox82.Text)
            actualiza.Parameters.AddWithValue("?Total", TextBox83.Text)
            actualiza.Parameters.AddWithValue("?Moneda", TextBox156.Text)
            actualiza.Parameters.AddWithValue("?ID", Label2.Text)
            actualiza.Parameters.AddWithValue("?Linea", Label48.Text)
            actualiza.Parameters.AddWithValue("?OC", TextBox122.Text)
            actualiza.Parameters.AddWithValue("?FechaOC", DateTimePicker1.Text)
            actualiza.Parameters.AddWithValue("?Ocitems", TextBox136.Text)
            actualiza.Parameters.AddWithValue("?FechOCItems", DateTimePicker15.Text)
            actualiza.Parameters.AddWithValue("?Fechaent", DateTimePicker42.Text)
            actualiza.Parameters.AddWithValue("?FecEntItems", DateTimePicker35.Text)
            actualiza.ExecuteNonQuery()
        End If
    End Sub
    Private Sub CheckBox15_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox15.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()

        Else
            On Error Resume Next
            Dim edicion As String = "UPDATE TSADATACOTIZACION SET Cotizacion= ?Cotizacion, Fecha= ?Fecha, 
            Razon_Social= ?Razonsocial, RUT = ?RUT, Atencion = ?Atencion, Direccion_ate= ?Direccionate, Telefono_ate= ?TelefonoATe, Correo_ate= ?CorreoAte,
            Contacto= ?Contacto, Telefono_cont= ?TelefonoCont, Correo_cont= ?CorreoCont, Pagina_Web= ?WEB, Referencia= ?Referencia, Descripcion_mat= ?Descripcion, 
            Codigo_mat= ?Codigo, Cantidad= ?Cantidad, Precio= ?Precio, Total= ?Total, Moneda= ?Moneda, Linea=?Linea, OC= ?OC, FechaOC=?FechaOC, OC_Items=?Ocitems, Fecha_OC_Items=?FechOCItems, Fecha_Entrega=?Fechaent,
            Fecha_Ent_Items=?FecEntItems WHERE ID= ?ID and Linea=?Linea"

            Dim actualiza As New MySqlCommand(edicion, conex)

            actualiza.Parameters.AddWithValue("?Cotizacion", TextBox7.Text)
            actualiza.Parameters.AddWithValue("?Fecha", TextBox8.Text)
            actualiza.Parameters.AddWithValue("?RazonSocial", TextBox1.Text)
            actualiza.Parameters.AddWithValue("?RUT", TextBox3.Text)
            actualiza.Parameters.AddWithValue("?Atencion", TextBox2.Text)
            actualiza.Parameters.AddWithValue("?Direccionate", TextBox4.Text)
            actualiza.Parameters.AddWithValue("?Telefonoate", TextBox5.Text)
            actualiza.Parameters.AddWithValue("?CorreoAte", TextBox6.Text)
            actualiza.Parameters.AddWithValue("?Contacto", TextBox9.Text)
            actualiza.Parameters.AddWithValue("?TelefonoCont", TextBox12.Text)
            actualiza.Parameters.AddWithValue("?CorreoCont", TextBox10.Text)
            actualiza.Parameters.AddWithValue("?WEB", TextBox11.Text)
            actualiza.Parameters.AddWithValue("?Referencia", TextBox13.Text)
            actualiza.Parameters.AddWithValue("?Descripcion", TextBox84.Text)
            actualiza.Parameters.AddWithValue("?Codigo", TextBox85.Text)
            actualiza.Parameters.AddWithValue("?Cantidad", TextBox86.Text)
            actualiza.Parameters.AddWithValue("?Precio", TextBox87.Text)
            actualiza.Parameters.AddWithValue("?Total", TextBox88.Text)
            actualiza.Parameters.AddWithValue("?Moneda", TextBox157.Text)
            actualiza.Parameters.AddWithValue("?ID", Label2.Text)
            actualiza.Parameters.AddWithValue("?Linea", Label49.Text)
            actualiza.Parameters.AddWithValue("?OC", TextBox122.Text)
            actualiza.Parameters.AddWithValue("?FechaOC", DateTimePicker1.Text)
            actualiza.Parameters.AddWithValue("?Ocitems", TextBox137.Text)
            actualiza.Parameters.AddWithValue("?FechOCItems", DateTimePicker16.Text)
            actualiza.Parameters.AddWithValue("?Fechaent", DateTimePicker42.Text)
            actualiza.Parameters.AddWithValue("?FecEntItems", DateTimePicker36.Text)
            actualiza.ExecuteNonQuery()
        End If
    End Sub
    Private Sub CheckBox16_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox16.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()

        Else
            On Error Resume Next
            Dim edicion As String = "UPDATE TSADATACOTIZACION SET Cotizacion= ?Cotizacion, Fecha= ?Fecha, 
            Razon_Social= ?Razonsocial, RUT = ?RUT, Atencion = ?Atencion, Direccion_ate= ?Direccionate, Telefono_ate= ?TelefonoATe, Correo_ate= ?CorreoAte,
            Contacto= ?Contacto, Telefono_cont= ?TelefonoCont, Correo_cont= ?CorreoCont, Pagina_Web= ?WEB, Referencia= ?Referencia, Descripcion_mat= ?Descripcion, 
            Codigo_mat= ?Codigo, Cantidad= ?Cantidad, Precio= ?Precio, Total= ?Total, Moneda= ?Moneda, Linea=?Linea, OC= ?OC, FechaOC=?FechaOC, OC_Items=?Ocitems, Fecha_OC_Items=?FechOCItems, Fecha_Entrega=?Fechaent,
            Fecha_Ent_Items=?FecEntItems WHERE ID= ?ID and Linea=?Linea"

            Dim actualiza As New MySqlCommand(edicion, conex)

            actualiza.Parameters.AddWithValue("?Cotizacion", TextBox7.Text)
            actualiza.Parameters.AddWithValue("?Fecha", TextBox8.Text)
            actualiza.Parameters.AddWithValue("?RazonSocial", TextBox1.Text)
            actualiza.Parameters.AddWithValue("?RUT", TextBox3.Text)
            actualiza.Parameters.AddWithValue("?Atencion", TextBox2.Text)
            actualiza.Parameters.AddWithValue("?Direccionate", TextBox4.Text)
            actualiza.Parameters.AddWithValue("?Telefonoate", TextBox5.Text)
            actualiza.Parameters.AddWithValue("?CorreoAte", TextBox6.Text)
            actualiza.Parameters.AddWithValue("?Contacto", TextBox9.Text)
            actualiza.Parameters.AddWithValue("?TelefonoCont", TextBox12.Text)
            actualiza.Parameters.AddWithValue("?CorreoCont", TextBox10.Text)
            actualiza.Parameters.AddWithValue("?WEB", TextBox11.Text)
            actualiza.Parameters.AddWithValue("?Referencia", TextBox13.Text)
            actualiza.Parameters.AddWithValue("?Descripcion", TextBox89.Text)
            actualiza.Parameters.AddWithValue("?Codigo", TextBox90.Text)
            actualiza.Parameters.AddWithValue("?Cantidad", TextBox91.Text)
            actualiza.Parameters.AddWithValue("?Precio", TextBox92.Text)
            actualiza.Parameters.AddWithValue("?Total", TextBox93.Text)
            actualiza.Parameters.AddWithValue("?Moneda", TextBox158.Text)
            actualiza.Parameters.AddWithValue("?ID", Label2.Text)
            actualiza.Parameters.AddWithValue("?Linea", Label50.Text)
            actualiza.Parameters.AddWithValue("?OC", TextBox122.Text)
            actualiza.Parameters.AddWithValue("?FechaOC", DateTimePicker1.Text)
            actualiza.Parameters.AddWithValue("?Ocitems", TextBox138.Text)
            actualiza.Parameters.AddWithValue("?FechOCItems", DateTimePicker17.Text)
            actualiza.Parameters.AddWithValue("?Fechaent", DateTimePicker42.Text)
            actualiza.Parameters.AddWithValue("?FecEntItems", DateTimePicker37.Text)
            actualiza.ExecuteNonQuery()
        End If
    End Sub
    Private Sub CheckBox17_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox17.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()

        Else
            On Error Resume Next
            Dim edicion As String = "UPDATE TSADATACOTIZACION SET Cotizacion= ?Cotizacion, Fecha= ?Fecha, 
            Razon_Social= ?Razonsocial, RUT = ?RUT, Atencion = ?Atencion, Direccion_ate= ?Direccionate, Telefono_ate= ?TelefonoATe, Correo_ate= ?CorreoAte,
            Contacto= ?Contacto, Telefono_cont= ?TelefonoCont, Correo_cont= ?CorreoCont, Pagina_Web= ?WEB, Referencia= ?Referencia, Descripcion_mat= ?Descripcion, 
            Codigo_mat= ?Codigo, Cantidad= ?Cantidad, Precio= ?Precio, Total= ?Total, Moneda= ?Moneda, Linea=?Linea, OC= ?OC, FechaOC=?FechaOC, OC_Items=?Ocitems, Fecha_OC_Items=?FechOCItems, Fecha_Entrega=?Fechaent,
            Fecha_Ent_Items=?FecEntItems WHERE ID= ?ID and Linea=?Linea"
            Dim actualiza As New MySqlCommand(edicion, conex)

            actualiza.Parameters.AddWithValue("?Cotizacion", TextBox7.Text)
            actualiza.Parameters.AddWithValue("?Fecha", TextBox8.Text)
            actualiza.Parameters.AddWithValue("?RazonSocial", TextBox1.Text)
            actualiza.Parameters.AddWithValue("?RUT", TextBox3.Text)
            actualiza.Parameters.AddWithValue("?Atencion", TextBox2.Text)
            actualiza.Parameters.AddWithValue("?Direccionate", TextBox4.Text)
            actualiza.Parameters.AddWithValue("?Telefonoate", TextBox5.Text)
            actualiza.Parameters.AddWithValue("?CorreoAte", TextBox6.Text)
            actualiza.Parameters.AddWithValue("?Contacto", TextBox9.Text)
            actualiza.Parameters.AddWithValue("?TelefonoCont", TextBox12.Text)
            actualiza.Parameters.AddWithValue("?CorreoCont", TextBox10.Text)
            actualiza.Parameters.AddWithValue("?WEB", TextBox11.Text)
            actualiza.Parameters.AddWithValue("?Referencia", TextBox13.Text)
            actualiza.Parameters.AddWithValue("?Descripcion", TextBox94.Text)
            actualiza.Parameters.AddWithValue("?Codigo", TextBox95.Text)
            actualiza.Parameters.AddWithValue("?Cantidad", TextBox96.Text)
            actualiza.Parameters.AddWithValue("?Precio", TextBox97.Text)
            actualiza.Parameters.AddWithValue("?Total", TextBox98.Text)
            actualiza.Parameters.AddWithValue("?Moneda", TextBox159.Text)
            actualiza.Parameters.AddWithValue("?ID", Label2.Text)
            actualiza.Parameters.AddWithValue("?Linea", Label51.Text)
            actualiza.Parameters.AddWithValue("?OC", TextBox122.Text)
            actualiza.Parameters.AddWithValue("?FechaOC", DateTimePicker1.Text)
            actualiza.Parameters.AddWithValue("?Ocitems", TextBox139.Text)
            actualiza.Parameters.AddWithValue("?FechOCItems", DateTimePicker18.Text)
            actualiza.Parameters.AddWithValue("?Fechaent", DateTimePicker42.Text)
            actualiza.Parameters.AddWithValue("?FecEntItems", DateTimePicker38.Text)
            actualiza.ExecuteNonQuery()
        End If
    End Sub
    '========================================================================================================
    Private Sub CheckBox18_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox18.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()

        Else
            On Error Resume Next
            Dim edicion As String = "UPDATE TSADATACOTIZACION SET Cotizacion= ?Cotizacion, Fecha= ?Fecha, 
            Razon_Social= ?Razonsocial, RUT = ?RUT, Atencion = ?Atencion, Direccion_ate= ?Direccionate, Telefono_ate= ?TelefonoATe, Correo_ate= ?CorreoAte,
            Contacto= ?Contacto, Telefono_cont= ?TelefonoCont, Correo_cont= ?CorreoCont, Pagina_Web= ?WEB, Referencia= ?Referencia, Descripcion_mat= ?Descripcion, 
            Codigo_mat= ?Codigo, Cantidad= ?Cantidad, Precio= ?Precio, Total= ?Total, Moneda= ?Moneda, Linea=?Linea, OC= ?OC, FechaOC=?FechaOC, OC_Items=?Ocitems, Fecha_OC_Items=?FechOCItems, Fecha_Entrega=?Fechaent,
            Fecha_Ent_Items=?FecEntItems WHERE ID= ?ID and Linea=?Linea"

            Dim actualiza As New MySqlCommand(edicion, conex)

            actualiza.Parameters.AddWithValue("?Cotizacion", TextBox7.Text)
            actualiza.Parameters.AddWithValue("?Fecha", TextBox8.Text)
            actualiza.Parameters.AddWithValue("?RazonSocial", TextBox1.Text)
            actualiza.Parameters.AddWithValue("?RUT", TextBox3.Text)
            actualiza.Parameters.AddWithValue("?Atencion", TextBox2.Text)
            actualiza.Parameters.AddWithValue("?Direccionate", TextBox4.Text)
            actualiza.Parameters.AddWithValue("?Telefonoate", TextBox5.Text)
            actualiza.Parameters.AddWithValue("?CorreoAte", TextBox6.Text)
            actualiza.Parameters.AddWithValue("?Contacto", TextBox9.Text)
            actualiza.Parameters.AddWithValue("?TelefonoCont", TextBox12.Text)
            actualiza.Parameters.AddWithValue("?CorreoCont", TextBox10.Text)
            actualiza.Parameters.AddWithValue("?WEB", TextBox11.Text)
            actualiza.Parameters.AddWithValue("?Referencia", TextBox13.Text)
            actualiza.Parameters.AddWithValue("?Descripcion", TextBox99.Text)
            actualiza.Parameters.AddWithValue("?Codigo", TextBox100.Text)
            actualiza.Parameters.AddWithValue("?Cantidad", TextBox101.Text)
            actualiza.Parameters.AddWithValue("?Precio", TextBox102.Text)
            actualiza.Parameters.AddWithValue("?Total", TextBox103.Text)
            actualiza.Parameters.AddWithValue("?Moneda", TextBox160.Text)
            actualiza.Parameters.AddWithValue("?ID", Label2.Text)
            actualiza.Parameters.AddWithValue("?Linea", Label52.Text)
            actualiza.Parameters.AddWithValue("?OC", TextBox122.Text)
            actualiza.Parameters.AddWithValue("?FechaOC", DateTimePicker1.Text)
            actualiza.Parameters.AddWithValue("?Ocitems", TextBox140.Text)
            actualiza.Parameters.AddWithValue("?FechOCItems", DateTimePicker19.Text)
            actualiza.Parameters.AddWithValue("?Fechaent", DateTimePicker42.Text)
            actualiza.Parameters.AddWithValue("?FecEntItems", DateTimePicker39.Text)
            actualiza.ExecuteNonQuery()
        End If
    End Sub
    Private Sub CheckBox19_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox19.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()

        Else
            On Error Resume Next
            Dim edicion As String = "UPDATE TSADATACOTIZACION SET Cotizacion= ?Cotizacion, Fecha= ?Fecha, 
            Razon_Social= ?Razonsocial, RUT = ?RUT, Atencion = ?Atencion, Direccion_ate= ?Direccionate, Telefono_ate= ?TelefonoATe, Correo_ate= ?CorreoAte,
            Contacto= ?Contacto, Telefono_cont= ?TelefonoCont, Correo_cont= ?CorreoCont, Pagina_Web= ?WEB, Referencia= ?Referencia, Descripcion_mat= ?Descripcion, 
            Codigo_mat= ?Codigo, Cantidad= ?Cantidad, Precio= ?Precio, Total= ?Total, Moneda= ?Moneda, Linea=?Linea, OC= ?OC, FechaOC=?FechaOC, OC_Items=?Ocitems, Fecha_OC_Items=?FechOCItems, Fecha_Entrega=?Fechaent,
            Fecha_Ent_Items=?FecEntItems WHERE ID= ?ID and Linea=?Linea"
            Dim actualiza As New MySqlCommand(edicion, conex)

            actualiza.Parameters.AddWithValue("?Cotizacion", TextBox7.Text)
            actualiza.Parameters.AddWithValue("?Fecha", TextBox8.Text)
            actualiza.Parameters.AddWithValue("?RazonSocial", TextBox1.Text)
            actualiza.Parameters.AddWithValue("?RUT", TextBox3.Text)
            actualiza.Parameters.AddWithValue("?Atencion", TextBox2.Text)
            actualiza.Parameters.AddWithValue("?Direccionate", TextBox4.Text)
            actualiza.Parameters.AddWithValue("?Telefonoate", TextBox5.Text)
            actualiza.Parameters.AddWithValue("?CorreoAte", TextBox6.Text)
            actualiza.Parameters.AddWithValue("?Contacto", TextBox9.Text)
            actualiza.Parameters.AddWithValue("?TelefonoCont", TextBox12.Text)
            actualiza.Parameters.AddWithValue("?CorreoCont", TextBox10.Text)
            actualiza.Parameters.AddWithValue("?WEB", TextBox11.Text)
            actualiza.Parameters.AddWithValue("?Referencia", TextBox13.Text)
            actualiza.Parameters.AddWithValue("?Descripcion", TextBox104.Text)
            actualiza.Parameters.AddWithValue("?Codigo", TextBox105.Text)
            actualiza.Parameters.AddWithValue("?Cantidad", TextBox106.Text)
            actualiza.Parameters.AddWithValue("?Precio", TextBox107.Text)
            actualiza.Parameters.AddWithValue("?Total", TextBox108.Text)
            actualiza.Parameters.AddWithValue("?Moneda", TextBox161.Text)
            actualiza.Parameters.AddWithValue("?ID", Label2.Text)
            actualiza.Parameters.AddWithValue("?Linea", Label53.Text)
            actualiza.Parameters.AddWithValue("?OC", TextBox122.Text)
            actualiza.Parameters.AddWithValue("?FechaOC", DateTimePicker1.Text)
            actualiza.Parameters.AddWithValue("?Ocitems", TextBox141.Text)
            actualiza.Parameters.AddWithValue("?FechOCItems", DateTimePicker20.Text)
            actualiza.Parameters.AddWithValue("?Fechaent", DateTimePicker42.Text)
            actualiza.Parameters.AddWithValue("?FecEntItems", DateTimePicker40.Text)
            actualiza.ExecuteNonQuery()
        End If
    End Sub
    Private Sub CheckBox20_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox20.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()

        Else
            On Error Resume Next
            Dim edicion As String = "UPDATE TSADATACOTIZACION SET Cotizacion= ?Cotizacion, Fecha= ?Fecha, 
            Razon_Social= ?Razonsocial, RUT = ?RUT, Atencion = ?Atencion, Direccion_ate= ?Direccionate, Telefono_ate= ?TelefonoATe, Correo_ate= ?CorreoAte,
            Contacto= ?Contacto, Telefono_cont= ?TelefonoCont, Correo_cont= ?CorreoCont, Pagina_Web= ?WEB, Referencia= ?Referencia, Descripcion_mat= ?Descripcion, 
            Codigo_mat= ?Codigo, Cantidad= ?Cantidad, Precio= ?Precio, Total= ?Total, Moneda= ?Moneda, Linea=?Linea, OC= ?OC, FechaOC=?FechaOC, OC_Items=?Ocitems, Fecha_OC_Items=?FechOCItems, Fecha_Entrega=?Fechaent,
            Fecha_Ent_Items=?FecEntItems WHERE ID= ?ID and Linea=?Linea"

            Dim actualiza As New MySqlCommand(edicion, conex)

            actualiza.Parameters.AddWithValue("?Cotizacion", TextBox7.Text)
            actualiza.Parameters.AddWithValue("?Fecha", TextBox8.Text)
            actualiza.Parameters.AddWithValue("?RazonSocial", TextBox1.Text)
            actualiza.Parameters.AddWithValue("?RUT", TextBox3.Text)
            actualiza.Parameters.AddWithValue("?Atencion", TextBox2.Text)
            actualiza.Parameters.AddWithValue("?Direccionate", TextBox4.Text)
            actualiza.Parameters.AddWithValue("?Telefonoate", TextBox5.Text)
            actualiza.Parameters.AddWithValue("?CorreoAte", TextBox6.Text)
            actualiza.Parameters.AddWithValue("?Contacto", TextBox9.Text)
            actualiza.Parameters.AddWithValue("?TelefonoCont", TextBox12.Text)
            actualiza.Parameters.AddWithValue("?CorreoCont", TextBox10.Text)
            actualiza.Parameters.AddWithValue("?WEB", TextBox11.Text)
            actualiza.Parameters.AddWithValue("?Referencia", TextBox13.Text)
            actualiza.Parameters.AddWithValue("?Descripcion", TextBox109.Text)
            actualiza.Parameters.AddWithValue("?Codigo", TextBox110.Text)
            actualiza.Parameters.AddWithValue("?Cantidad", TextBox111.Text)
            actualiza.Parameters.AddWithValue("?Precio", TextBox112.Text)
            actualiza.Parameters.AddWithValue("?Total", TextBox113.Text)
            actualiza.Parameters.AddWithValue("?Moneda", TextBox162.Text)
            actualiza.Parameters.AddWithValue("?ID", Label2.Text)
            actualiza.Parameters.AddWithValue("?Linea", Label54.Text)
            actualiza.Parameters.AddWithValue("?OC", TextBox122.Text)
            actualiza.Parameters.AddWithValue("?FechaOC", DateTimePicker1.Text)
            actualiza.Parameters.AddWithValue("?Ocitems", TextBox142.Text)
            actualiza.Parameters.AddWithValue("?FechOCItems", DateTimePicker21.Text)
            actualiza.Parameters.AddWithValue("?Fechaent", DateTimePicker42.Text)
            actualiza.Parameters.AddWithValue("?FecEntItems", DateTimePicker41.Text)
            actualiza.ExecuteNonQuery()
        End If
    End Sub
#End Region
#Region "Para llamar al evento de form3 para Adquirir los datos del producto seleccionado"
    Private Sub TextBox14_Click(sender As Object, e As EventArgs) Handles TextBox14.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.PictureBox1.Visible = True
        frm.ShowDialog()

    End Sub
    Private Sub TextBox19_Click(sender As Object, e As EventArgs) Handles TextBox19.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.PictureBox2.Visible = True
        frm.ShowDialog()
    End Sub
    Private Sub TextBox24_Click(sender As Object, e As EventArgs) Handles TextBox24.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.PictureBox3.Visible = True
        frm.ShowDialog()
    End Sub
    Private Sub TextBox29_Click(sender As Object, e As EventArgs) Handles TextBox29.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.PictureBox4.Visible = True
        frm.ShowDialog()
    End Sub
    Private Sub TextBox34_Click(sender As Object, e As EventArgs) Handles TextBox34.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.PictureBox5.Visible = True
        frm.ShowDialog()
    End Sub
    Private Sub TextBox39_Click(sender As Object, e As EventArgs) Handles TextBox39.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.PictureBox6.Visible = True
        frm.ShowDialog()
    End Sub

    Private Sub TextBox44_Click(sender As Object, e As EventArgs) Handles TextBox44.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.PictureBox7.Visible = True
        frm.ShowDialog()
    End Sub

    Private Sub TextBox49_Click(sender As Object, e As EventArgs) Handles TextBox49.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.PictureBox8.Visible = True
        frm.ShowDialog()
    End Sub
    Private Sub TextBox54_Click(sender As Object, e As EventArgs) Handles TextBox54.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.PictureBox9.Visible = True
        frm.ShowDialog()
    End Sub

    Private Sub TextBox59_Click(sender As Object, e As EventArgs) Handles TextBox59.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.PictureBox10.Visible = True
        frm.ShowDialog()
    End Sub

    Private Sub TextBox64_Click(sender As Object, e As EventArgs) Handles TextBox64.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.PictureBox11.Visible = True
        frm.ShowDialog()
    End Sub
    Private Sub TextBox69_Click(sender As Object, e As EventArgs) Handles TextBox69.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.PictureBox12.Visible = True
        frm.ShowDialog()
    End Sub
    Private Sub TextBox74_Click(sender As Object, e As EventArgs) Handles TextBox74.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.PictureBox13.Visible = True
        frm.ShowDialog()
    End Sub
    Private Sub TextBox79_Click(sender As Object, e As EventArgs) Handles TextBox79.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.PictureBox14.Visible = True
        frm.ShowDialog()
    End Sub
    Private Sub TextBox84_Click(sender As Object, e As EventArgs) Handles TextBox84.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.PictureBox15.Visible = True
        frm.ShowDialog()
    End Sub

    Private Sub TextBox89_Click(sender As Object, e As EventArgs) Handles TextBox89.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.PictureBox16.Visible = True
        frm.ShowDialog()
    End Sub

    Private Sub TextBox94_Click(sender As Object, e As EventArgs) Handles TextBox94.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.PictureBox17.Visible = True
        frm.ShowDialog()
    End Sub

    Private Sub TextBox99_Click(sender As Object, e As EventArgs) Handles TextBox99.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.PictureBox18.Visible = True
        frm.ShowDialog()
    End Sub
    Private Sub TextBox104_Click(sender As Object, e As EventArgs) Handles TextBox104.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.PictureBox19.Visible = True
        frm.ShowDialog()
    End Sub

    Private Sub TextBox109_Click(sender As Object, e As EventArgs) Handles TextBox109.Click
        Dim frm As New Form3
        AddOwnedForm(frm)
        frm.PictureBox20.Visible = True
        frm.ShowDialog()
    End Sub



#End Region
#Region "PARA AGREGAR LINEAS NUEVAS A COTIZACION YA REALIZADA "
    'CODIGO PARA AGREGAR LINEAS NEW
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MessageBox.Show("¿ Seguro que desea Agregar este registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

            If CheckBox42.Checked = True Then
                Dim Cot As String = TextBox7.Text
                Dim Fec As String = TextBox8.Text
                Dim Raz As String = TextBox1.Text
                Dim RUT As String = TextBox3.Text
                Dim Ate As String = TextBox2.Text
                Dim DirAte As String = TextBox4.Text
                Dim TelAte As String = TextBox5.Text
                Dim CorAte As String = TextBox6.Text
                Dim Ven As String = TextBox9.Text
                Dim TelVen As String = TextBox12.Text
                Dim CorVen As String = TextBox10.Text
                Dim Web As String = TextBox11.Text
                Dim Ref As String = TextBox13.Text

                Dim Descrip As String = TextBox19.Text
                Dim Codi As String = TextBox20.Text
                Dim Cant As String = TextBox21.Text
                Dim Precio As String = TextBox22.Text
                Dim Total As String = TextBox23.Text
                Dim Moneda As String = TextBox144.Text
                Dim ID As String = Label2.Text
                Dim Lin As String = Label36.Text
                Dim OC As String = TextBox122.Text
                Dim FOC As String = DateTimePicker1.Text
                Dim OCitems As String = TextBox124.Text
                Dim FecOcIts As String = DateTimePicker3.Text
                Dim FecEnt As String = DateTimePicker42.Text
                Dim FecEntIts As String = DateTimePicker23.Text

                Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
                Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
                Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
                '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "''" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
                '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

                Dim Seleccion As New MySqlCommand(Agregar, conex)

                Seleccion.Connection.Open()
                Seleccion.ExecuteNonQuery()

            Else CheckBox42.Checked = False

            End If

            If CheckBox43.Checked = True Then
                Dim Cot As String = TextBox7.Text
                Dim Fec As String = TextBox8.Text
                Dim Raz As String = TextBox1.Text
                Dim RUT As String = TextBox3.Text
                Dim Ate As String = TextBox2.Text
                Dim DirAte As String = TextBox4.Text
                Dim TelAte As String = TextBox5.Text
                Dim CorAte As String = TextBox6.Text
                Dim Ven As String = TextBox9.Text
                Dim TelVen As String = TextBox12.Text
                Dim CorVen As String = TextBox10.Text
                Dim Web As String = TextBox11.Text
                Dim Ref As String = TextBox13.Text

                Dim Descrip As String = TextBox24.Text
                Dim Codi As String = TextBox25.Text
                Dim Cant As String = TextBox26.Text
                Dim Precio As String = TextBox27.Text
                Dim Total As String = TextBox28.Text
                Dim Moneda As String = TextBox145.Text
                Dim ID As String = Label2.Text
                Dim Lin As String = Label37.Text
                Dim OC As String = TextBox122.Text
                Dim FOC As String = DateTimePicker1.Text
                Dim OCitems As String = TextBox125.Text
                Dim FecOcIts As String = DateTimePicker4.Text
                Dim FecEnt As String = DateTimePicker42.Text
                Dim FecEntIts As String = DateTimePicker24.Text

                Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
                Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
                Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
                '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "''" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
                '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

                Dim Seleccion As New MySqlCommand(Agregar, conex)

                Seleccion.Connection.Open()
                Seleccion.ExecuteNonQuery()

            Else CheckBox43.Checked = False

            End If

            If CheckBox44.Checked = True Then
                Dim Cot As String = TextBox7.Text
                Dim Fec As String = TextBox8.Text
                Dim Raz As String = TextBox1.Text
                Dim RUT As String = TextBox3.Text
                Dim Ate As String = TextBox2.Text
                Dim DirAte As String = TextBox4.Text
                Dim TelAte As String = TextBox5.Text
                Dim CorAte As String = TextBox6.Text
                Dim Ven As String = TextBox9.Text
                Dim TelVen As String = TextBox12.Text
                Dim CorVen As String = TextBox10.Text
                Dim Web As String = TextBox11.Text
                Dim Ref As String = TextBox13.Text

                Dim Descrip As String = TextBox29.Text
                Dim Codi As String = TextBox30.Text
                Dim Cant As String = TextBox31.Text
                Dim Precio As String = TextBox32.Text
                Dim Total As String = TextBox33.Text
                Dim Moneda As String = TextBox146.Text
                Dim ID As String = Label2.Text
                Dim Lin As String = Label38.Text
                Dim OC As String = TextBox122.Text
                Dim FOC As String = DateTimePicker1.Text
                Dim OCitems As String = TextBox126.Text
                Dim FecOcIts As String = DateTimePicker5.Text
                Dim FecEnt As String = DateTimePicker42.Text
                Dim FecEntIts As String = DateTimePicker25.Text

                Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
                Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
                Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
                '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "''" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
                '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

                Dim Seleccion As New MySqlCommand(Agregar, conex)
                Seleccion.Connection.Open()
                Seleccion.ExecuteNonQuery()

            Else CheckBox44.Checked = False


            End If


            If CheckBox45.Checked = True Then
                Dim Cot As String = TextBox7.Text
                Dim Fec As String = TextBox8.Text
                Dim Raz As String = TextBox1.Text
                Dim RUT As String = TextBox3.Text
                Dim Ate As String = TextBox2.Text
                Dim DirAte As String = TextBox4.Text
                Dim TelAte As String = TextBox5.Text
                Dim CorAte As String = TextBox6.Text
                Dim Ven As String = TextBox9.Text
                Dim TelVen As String = TextBox12.Text
                Dim CorVen As String = TextBox10.Text
                Dim Web As String = TextBox11.Text
                Dim Ref As String = TextBox13.Text

                Dim Descrip As String = TextBox34.Text
                Dim Codi As String = TextBox35.Text
                Dim Cant As String = TextBox36.Text
                Dim Precio As String = TextBox37.Text
                Dim Total As String = TextBox38.Text
                Dim Moneda As String = TextBox147.Text
                Dim ID As String = Label2.Text
                Dim Lin As String = Label39.Text
                Dim OC As String = TextBox122.Text
                Dim FOC As String = DateTimePicker1.Text
                Dim OCitems As String = TextBox127.Text
                Dim FecOcIts As String = DateTimePicker6.Text
                Dim FecEnt As String = DateTimePicker42.Text
                Dim FecEntIts As String = DateTimePicker26.Text

                Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
                Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
                Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
                '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "''" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
                '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

                Dim Seleccion As New MySqlCommand(Agregar, conex)
                Seleccion.Connection.Open()
                Seleccion.ExecuteNonQuery()
            Else CheckBox45.Checked = False

            End If

            If CheckBox46.Checked = True Then
                Dim Cot As String = TextBox7.Text
                Dim Fec As String = TextBox8.Text
                Dim Raz As String = TextBox1.Text
                Dim RUT As String = TextBox3.Text
                Dim Ate As String = TextBox2.Text
                Dim DirAte As String = TextBox4.Text
                Dim TelAte As String = TextBox5.Text
                Dim CorAte As String = TextBox6.Text
                Dim Ven As String = TextBox9.Text
                Dim TelVen As String = TextBox12.Text
                Dim CorVen As String = TextBox10.Text
                Dim Web As String = TextBox11.Text
                Dim Ref As String = TextBox13.Text

                Dim Descrip As String = TextBox39.Text
                Dim Codi As String = TextBox40.Text
                Dim Cant As String = TextBox41.Text
                Dim Precio As String = TextBox42.Text
                Dim Total As String = TextBox43.Text
                Dim Moneda As String = TextBox148.Text
                Dim ID As String = Label2.Text
                Dim Lin As String = Label40.Text
                Dim OC As String = TextBox122.Text
                Dim FOC As String = DateTimePicker1.Text
                Dim OCitems As String = TextBox128.Text
                Dim FecOcIts As String = DateTimePicker7.Text
                Dim FecEnt As String = DateTimePicker42.Text
                Dim FecEntIts As String = DateTimePicker27.Text

                Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
                Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
                Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
                '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "''" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
                '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

                Dim Seleccion As New MySqlCommand(Agregar, conex)
                Seleccion.Connection.Open()
                Seleccion.ExecuteNonQuery()

            Else CheckBox46.Checked = False

            End If

            If CheckBox47.Checked = True Then
                Dim Cot As String = TextBox7.Text
                Dim Fec As String = TextBox8.Text
                Dim Raz As String = TextBox1.Text
                Dim RUT As String = TextBox3.Text
                Dim Ate As String = TextBox2.Text
                Dim DirAte As String = TextBox4.Text
                Dim TelAte As String = TextBox5.Text
                Dim CorAte As String = TextBox6.Text
                Dim Ven As String = TextBox9.Text
                Dim TelVen As String = TextBox12.Text
                Dim CorVen As String = TextBox10.Text
                Dim Web As String = TextBox11.Text
                Dim Ref As String = TextBox13.Text

                Dim Descrip As String = TextBox44.Text
                Dim Codi As String = TextBox45.Text
                Dim Cant As String = TextBox46.Text
                Dim Precio As String = TextBox47.Text
                Dim Total As String = TextBox48.Text
                Dim Moneda As String = TextBox149.Text
                Dim ID As String = Label2.Text
                Dim Lin As String = Label41.Text
                Dim OC As String = TextBox122.Text
                Dim FOC As String = DateTimePicker1.Text
                Dim OCitems As String = TextBox129.Text
                Dim FecOcIts As String = DateTimePicker8.Text
                Dim FecEnt As String = DateTimePicker42.Text
                Dim FecEntIts As String = DateTimePicker28.Text

                Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
                Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
                Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
                '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "''" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
                '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

                Dim Seleccion As New MySqlCommand(Agregar, conex)
                Seleccion.Connection.Open()
                Seleccion.ExecuteNonQuery()

            Else CheckBox47.Checked = False

            End If

            If CheckBox48.Checked = True Then
                Dim Cot As String = TextBox7.Text
                Dim Fec As String = TextBox8.Text
                Dim Raz As String = TextBox1.Text
                Dim RUT As String = TextBox3.Text
                Dim Ate As String = TextBox2.Text
                Dim DirAte As String = TextBox4.Text
                Dim TelAte As String = TextBox5.Text
                Dim CorAte As String = TextBox6.Text
                Dim Ven As String = TextBox9.Text
                Dim TelVen As String = TextBox12.Text
                Dim CorVen As String = TextBox10.Text
                Dim Web As String = TextBox11.Text
                Dim Ref As String = TextBox13.Text

                Dim Descrip As String = TextBox49.Text
                Dim Codi As String = TextBox50.Text
                Dim Cant As String = TextBox51.Text
                Dim Precio As String = TextBox52.Text
                Dim Total As String = TextBox53.Text
                Dim Moneda As String = TextBox150.Text
                Dim ID As String = Label2.Text
                Dim Lin As String = Label42.Text
                Dim OC As String = TextBox122.Text
                Dim FOC As String = DateTimePicker1.Text
                Dim OCitems As String = TextBox130.Text
                Dim FecOcIts As String = DateTimePicker9.Text
                Dim FecEnt As String = DateTimePicker42.Text
                Dim FecEntIts As String = DateTimePicker29.Text

                Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
                Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
                Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
                '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "''" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
                '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

                Dim Seleccion As New MySqlCommand(Agregar, conex)
                Seleccion.Connection.Open()
                Seleccion.ExecuteNonQuery()

            Else CheckBox48.Checked = False

            End If

            If CheckBox49.Checked = True Then
                Dim Cot As String = TextBox7.Text
                Dim Fec As String = TextBox8.Text
                Dim Raz As String = TextBox1.Text
                Dim RUT As String = TextBox3.Text
                Dim Ate As String = TextBox2.Text
                Dim DirAte As String = TextBox4.Text
                Dim TelAte As String = TextBox5.Text
                Dim CorAte As String = TextBox6.Text
                Dim Ven As String = TextBox9.Text
                Dim TelVen As String = TextBox12.Text
                Dim CorVen As String = TextBox10.Text
                Dim Web As String = TextBox11.Text
                Dim Ref As String = TextBox13.Text

                Dim Descrip As String = TextBox54.Text
                Dim Codi As String = TextBox55.Text
                Dim Cant As String = TextBox56.Text
                Dim Precio As String = TextBox57.Text
                Dim Total As String = TextBox58.Text
                Dim Moneda As String = TextBox151.Text
                Dim ID As String = Label2.Text
                Dim Lin As String = Label43.Text
                Dim OC As String = TextBox122.Text
                Dim FOC As String = DateTimePicker1.Text
                Dim OCitems As String = TextBox131.Text
                Dim FecOcIts As String = DateTimePicker10.Text
                Dim FecEnt As String = DateTimePicker42.Text
                Dim FecEntIts As String = DateTimePicker30.Text

                Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
                Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
                Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
                '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "''" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
                '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

                Dim Seleccion As New MySqlCommand(Agregar, conex)
                Seleccion.Connection.Open()
                Seleccion.ExecuteNonQuery()

            Else CheckBox49.Checked = False
            End If

            If CheckBox50.Checked = True Then
                Dim Cot As String = TextBox7.Text
                Dim Fec As String = TextBox8.Text
                Dim Raz As String = TextBox1.Text
                Dim RUT As String = TextBox3.Text
                Dim Ate As String = TextBox2.Text
                Dim DirAte As String = TextBox4.Text
                Dim TelAte As String = TextBox5.Text
                Dim CorAte As String = TextBox6.Text
                Dim Ven As String = TextBox9.Text
                Dim TelVen As String = TextBox12.Text
                Dim CorVen As String = TextBox10.Text
                Dim Web As String = TextBox11.Text
                Dim Ref As String = TextBox13.Text

                Dim Descrip As String = TextBox59.Text
                Dim Codi As String = TextBox60.Text
                Dim Cant As String = TextBox61.Text
                Dim Precio As String = TextBox62.Text
                Dim Total As String = TextBox63.Text
                Dim Moneda As String = TextBox152.Text
                Dim ID As String = Label2.Text
                Dim Lin As String = Label44.Text
                Dim OC As String = TextBox122.Text
                Dim FOC As String = DateTimePicker1.Text
                Dim OCitems As String = TextBox132.Text
                Dim FecOcIts As String = DateTimePicker11.Text
                Dim FecEnt As String = DateTimePicker42.Text
                Dim FecEntIts As String = DateTimePicker31.Text

                Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
                Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
                Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
                '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "''" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
                '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

                Dim Seleccion As New MySqlCommand(Agregar, conex)
                Seleccion.Connection.Open()
                Seleccion.ExecuteNonQuery()
            Else CheckBox50.Checked = False
            End If

            If CheckBox51.Checked = True Then
                Dim Cot As String = TextBox7.Text
                Dim Fec As String = TextBox8.Text
                Dim Raz As String = TextBox1.Text
                Dim RUT As String = TextBox3.Text
                Dim Ate As String = TextBox2.Text
                Dim DirAte As String = TextBox4.Text
                Dim TelAte As String = TextBox5.Text
                Dim CorAte As String = TextBox6.Text
                Dim Ven As String = TextBox9.Text
                Dim TelVen As String = TextBox12.Text
                Dim CorVen As String = TextBox10.Text
                Dim Web As String = TextBox11.Text
                Dim Ref As String = TextBox13.Text

                Dim Descrip As String = TextBox64.Text
                Dim Codi As String = TextBox65.Text
                Dim Cant As String = TextBox66.Text
                Dim Precio As String = TextBox67.Text
                Dim Total As String = TextBox68.Text
                Dim Moneda As String = TextBox153.Text
                Dim ID As String = Label2.Text
                Dim Lin As String = Label45.Text
                Dim OC As String = TextBox122.Text
                Dim FOC As String = DateTimePicker1.Text
                Dim OCitems As String = TextBox133.Text
                Dim FecOcIts As String = DateTimePicker12.Text
                Dim FecEnt As String = DateTimePicker42.Text
                Dim FecEntIts As String = DateTimePicker32.Text
                Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
                Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
                Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
                '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "''" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
                '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

                Dim Seleccion As New MySqlCommand(Agregar, conex)
                Seleccion.Connection.Open()
                Seleccion.ExecuteNonQuery()

            Else CheckBox51.Checked = False

            End If


            If CheckBox52.Checked = True Then
                Dim Cot As String = TextBox7.Text
                Dim Fec As String = TextBox8.Text
                Dim Raz As String = TextBox1.Text
                Dim RUT As String = TextBox3.Text
                Dim Ate As String = TextBox2.Text
                Dim DirAte As String = TextBox4.Text
                Dim TelAte As String = TextBox5.Text
                Dim CorAte As String = TextBox6.Text
                Dim Ven As String = TextBox9.Text
                Dim TelVen As String = TextBox12.Text
                Dim CorVen As String = TextBox10.Text
                Dim Web As String = TextBox11.Text
                Dim Ref As String = TextBox13.Text

                Dim Descrip As String = TextBox69.Text
                Dim Codi As String = TextBox70.Text
                Dim Cant As String = TextBox71.Text
                Dim Precio As String = TextBox72.Text
                Dim Total As String = TextBox73.Text
                Dim Moneda As String = TextBox154.Text
                Dim ID As String = Label2.Text
                Dim Lin As String = Label46.Text
                Dim OC As String = TextBox122.Text
                Dim FOC As String = DateTimePicker1.Text
                Dim OCitems As String = TextBox134.Text
                Dim FecOcIts As String = DateTimePicker13.Text
                Dim FecEnt As String = DateTimePicker42.Text
                Dim FecEntIts As String = DateTimePicker33.Text

                Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
                Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
                Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
                '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "''" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
                '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

                Dim Seleccion As New MySqlCommand(Agregar, conex)
                Seleccion.Connection.Open()
                Seleccion.ExecuteNonQuery()

            Else CheckBox52.Checked = False

            End If

            If CheckBox53.Checked = True Then
                Dim Cot As String = TextBox7.Text
                Dim Fec As String = TextBox8.Text
                Dim Raz As String = TextBox1.Text
                Dim RUT As String = TextBox3.Text
                Dim Ate As String = TextBox2.Text
                Dim DirAte As String = TextBox4.Text
                Dim TelAte As String = TextBox5.Text
                Dim CorAte As String = TextBox6.Text
                Dim Ven As String = TextBox9.Text
                Dim TelVen As String = TextBox12.Text
                Dim CorVen As String = TextBox10.Text
                Dim Web As String = TextBox11.Text
                Dim Ref As String = TextBox13.Text

                Dim Descrip As String = TextBox74.Text
                Dim Codi As String = TextBox75.Text
                Dim Cant As String = TextBox76.Text
                Dim Precio As String = TextBox77.Text
                Dim Total As String = TextBox78.Text
                Dim Moneda As String = TextBox155.Text
                Dim ID As String = Label2.Text
                Dim Lin As String = Label47.Text
                Dim OC As String = TextBox122.Text
                Dim FOC As String = DateTimePicker1.Text
                Dim OCitems As String = TextBox135.Text
                Dim FecOcIts As String = DateTimePicker14.Text
                Dim FecEnt As String = DateTimePicker42.Text
                Dim FecEntIts As String = DateTimePicker34.Text

                Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
                Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
                Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
                '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "''" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
                '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

                Dim Seleccion As New MySqlCommand(Agregar, conex)
                Seleccion.Connection.Open()
                Seleccion.ExecuteNonQuery()

            Else CheckBox53.Checked = False

            End If

            If CheckBox54.Checked = True Then
                Dim Cot As String = TextBox7.Text
                Dim Fec As String = TextBox8.Text
                Dim Raz As String = TextBox1.Text
                Dim RUT As String = TextBox3.Text
                Dim Ate As String = TextBox2.Text
                Dim DirAte As String = TextBox4.Text
                Dim TelAte As String = TextBox5.Text
                Dim CorAte As String = TextBox6.Text
                Dim Ven As String = TextBox9.Text
                Dim TelVen As String = TextBox12.Text
                Dim CorVen As String = TextBox10.Text
                Dim Web As String = TextBox11.Text
                Dim Ref As String = TextBox13.Text

                Dim Descrip As String = TextBox79.Text
                Dim Codi As String = TextBox80.Text
                Dim Cant As String = TextBox81.Text
                Dim Precio As String = TextBox82.Text
                Dim Total As String = TextBox83.Text
                Dim Moneda As String = TextBox156.Text
                Dim ID As String = Label2.Text
                Dim Lin As String = Label48.Text
                Dim OC As String = TextBox122.Text
                Dim FOC As String = DateTimePicker1.Text
                Dim OCitems As String = TextBox136.Text
                Dim FecOcIts As String = DateTimePicker15.Text
                Dim FecEnt As String = DateTimePicker42.Text
                Dim FecEntIts As String = DateTimePicker35.Text

                Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
                Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
                Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
                '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "''" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
                '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

                Dim Seleccion As New MySqlCommand(Agregar, conex)
                Seleccion.Connection.Open()
                Seleccion.ExecuteNonQuery()
            Else CheckBox54.Checked = False

            End If

            If CheckBox55.Checked = True Then
                Dim Cot As String = TextBox7.Text
                Dim Fec As String = TextBox8.Text
                Dim Raz As String = TextBox1.Text
                Dim RUT As String = TextBox3.Text
                Dim Ate As String = TextBox2.Text
                Dim DirAte As String = TextBox4.Text
                Dim TelAte As String = TextBox5.Text
                Dim CorAte As String = TextBox6.Text
                Dim Ven As String = TextBox9.Text
                Dim TelVen As String = TextBox12.Text
                Dim CorVen As String = TextBox10.Text
                Dim Web As String = TextBox11.Text
                Dim Ref As String = TextBox13.Text

                Dim Descrip As String = TextBox84.Text
                Dim Codi As String = TextBox85.Text
                Dim Cant As String = TextBox86.Text
                Dim Precio As String = TextBox87.Text
                Dim Total As String = TextBox88.Text
                Dim Moneda As String = TextBox157.Text
                Dim ID As String = Label2.Text
                Dim Lin As String = Label49.Text
                Dim OC As String = TextBox122.Text
                Dim FOC As String = DateTimePicker1.Text
                Dim OCitems As String = TextBox137.Text
                Dim FecOcIts As String = DateTimePicker16.Text
                Dim FecEnt As String = DateTimePicker42.Text
                Dim FecEntIts As String = DateTimePicker36.Text

                Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
                Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
                Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
                '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "''" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
                '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

                Dim Seleccion As New MySqlCommand(Agregar, conex)
                Seleccion.Connection.Open()
                Seleccion.ExecuteNonQuery()
            Else CheckBox55.Checked = False

            End If

            If CheckBox56.Checked = True Then
                Dim Cot As String = TextBox7.Text
                Dim Fec As String = TextBox8.Text
                Dim Raz As String = TextBox1.Text
                Dim RUT As String = TextBox3.Text
                Dim Ate As String = TextBox2.Text
                Dim DirAte As String = TextBox4.Text
                Dim TelAte As String = TextBox5.Text
                Dim CorAte As String = TextBox6.Text
                Dim Ven As String = TextBox9.Text
                Dim TelVen As String = TextBox12.Text
                Dim CorVen As String = TextBox10.Text
                Dim Web As String = TextBox11.Text
                Dim Ref As String = TextBox13.Text

                Dim Descrip As String = TextBox89.Text
                Dim Codi As String = TextBox90.Text
                Dim Cant As String = TextBox91.Text
                Dim Precio As String = TextBox92.Text
                Dim Total As String = TextBox93.Text
                Dim Moneda As String = TextBox158.Text
                Dim ID As String = Label2.Text
                Dim Lin As String = Label50.Text
                Dim OC As String = TextBox122.Text
                Dim FOC As String = DateTimePicker1.Text
                Dim OCitems As String = TextBox138.Text
                Dim FecOcIts As String = DateTimePicker17.Text
                Dim FecEnt As String = DateTimePicker42.Text
                Dim FecEntIts As String = DateTimePicker37.Text

                Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
                Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
                Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
                '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "''" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
                '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

                Dim Seleccion As New MySqlCommand(Agregar, conex)
                Seleccion.Connection.Open()
                Seleccion.ExecuteNonQuery()
            Else CheckBox56.Checked = False

            End If


            If CheckBox57.Checked = True Then
                Dim Cot As String = TextBox7.Text
                Dim Fec As String = TextBox8.Text
                Dim Raz As String = TextBox1.Text
                Dim RUT As String = TextBox3.Text
                Dim Ate As String = TextBox2.Text
                Dim DirAte As String = TextBox4.Text
                Dim TelAte As String = TextBox5.Text
                Dim CorAte As String = TextBox6.Text
                Dim Ven As String = TextBox9.Text
                Dim TelVen As String = TextBox12.Text
                Dim CorVen As String = TextBox10.Text
                Dim Web As String = TextBox11.Text
                Dim Ref As String = TextBox13.Text

                Dim Descrip As String = TextBox94.Text
                Dim Codi As String = TextBox95.Text
                Dim Cant As String = TextBox96.Text
                Dim Precio As String = TextBox97.Text
                Dim Total As String = TextBox98.Text
                Dim Moneda As String = TextBox159.Text
                Dim ID As String = Label2.Text
                Dim Lin As String = Label51.Text
                Dim OC As String = TextBox122.Text
                Dim FOC As String = DateTimePicker1.Text
                Dim OCitems As String = TextBox139.Text
                Dim FecOcIts As String = DateTimePicker18.Text
                Dim FecEnt As String = DateTimePicker42.Text
                Dim FecEntIts As String = DateTimePicker38.Text

                Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
                Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
                Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
                '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "''" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
                '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

                Dim Seleccion As New MySqlCommand(Agregar, conex)
                Seleccion.Connection.Open()
                Seleccion.ExecuteNonQuery()

            Else CheckBox57.Checked = False

            End If


            If CheckBox58.Checked = True Then
                Dim Cot As String = TextBox7.Text
                Dim Fec As String = TextBox8.Text
                Dim Raz As String = TextBox1.Text
                Dim RUT As String = TextBox3.Text
                Dim Ate As String = TextBox2.Text
                Dim DirAte As String = TextBox4.Text
                Dim TelAte As String = TextBox5.Text
                Dim CorAte As String = TextBox6.Text
                Dim Ven As String = TextBox9.Text
                Dim TelVen As String = TextBox12.Text
                Dim CorVen As String = TextBox10.Text
                Dim Web As String = TextBox11.Text
                Dim Ref As String = TextBox13.Text

                Dim Descrip As String = TextBox99.Text
                Dim Codi As String = TextBox100.Text
                Dim Cant As String = TextBox101.Text
                Dim Precio As String = TextBox102.Text
                Dim Total As String = TextBox103.Text
                Dim Moneda As String = TextBox160.Text
                Dim ID As String = Label2.Text
                Dim Lin As String = Label52.Text
                Dim OC As String = TextBox122.Text
                Dim FOC As String = DateTimePicker1.Text
                Dim OCitems As String = TextBox140.Text
                Dim FecOcIts As String = DateTimePicker19.Text
                Dim FecEnt As String = DateTimePicker42.Text
                Dim FecEntIts As String = DateTimePicker39.Text

                Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
                Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
                Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
                '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "''" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
                '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

                Dim Seleccion As New MySqlCommand(Agregar, conex)
                Seleccion.Connection.Open()
                Seleccion.ExecuteNonQuery()

            Else CheckBox58.Checked = False

            End If


            If CheckBox59.Checked = True Then
                Dim Cot As String = TextBox7.Text
                Dim Fec As String = TextBox8.Text
                Dim Raz As String = TextBox1.Text
                Dim RUT As String = TextBox3.Text
                Dim Ate As String = TextBox2.Text
                Dim DirAte As String = TextBox4.Text
                Dim TelAte As String = TextBox5.Text
                Dim CorAte As String = TextBox6.Text
                Dim Ven As String = TextBox9.Text
                Dim TelVen As String = TextBox12.Text
                Dim CorVen As String = TextBox10.Text
                Dim Web As String = TextBox11.Text
                Dim Ref As String = TextBox13.Text

                Dim Descrip As String = TextBox104.Text
                Dim Codi As String = TextBox105.Text
                Dim Cant As String = TextBox106.Text
                Dim Precio As String = TextBox107.Text
                Dim Total As String = TextBox108.Text
                Dim Moneda As String = TextBox161.Text
                Dim ID As String = Label2.Text
                Dim Lin As String = Label53.Text
                Dim OC As String = TextBox122.Text
                Dim FOC As String = DateTimePicker1.Text
                Dim OCitems As String = TextBox141.Text
                Dim FecOcIts As String = DateTimePicker20.Text
                Dim FecEnt As String = DateTimePicker42.Text
                Dim FecEntIts As String = DateTimePicker40.Text

                Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
                Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
                Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
                '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "''" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
                '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

                Dim Seleccion As New MySqlCommand(Agregar, conex)
                Seleccion.Connection.Open()
                Seleccion.ExecuteNonQuery()

            Else CheckBox59.Checked = False

            End If

            If CheckBox60.Checked = True Then
                Dim Cot As String = TextBox7.Text
                Dim Fec As String = TextBox8.Text
                Dim Raz As String = TextBox1.Text
                Dim RUT As String = TextBox3.Text
                Dim Ate As String = TextBox2.Text
                Dim DirAte As String = TextBox4.Text
                Dim TelAte As String = TextBox5.Text
                Dim CorAte As String = TextBox6.Text
                Dim Ven As String = TextBox9.Text
                Dim TelVen As String = TextBox12.Text
                Dim CorVen As String = TextBox10.Text
                Dim Web As String = TextBox11.Text
                Dim Ref As String = TextBox13.Text

                Dim Descrip As String = TextBox109.Text
                Dim Codi As String = TextBox110.Text
                Dim Cant As String = TextBox111.Text
                Dim Precio As String = TextBox112.Text
                Dim Total As String = TextBox113.Text
                Dim Moneda As String = TextBox162.Text
                Dim ID As String = Label2.Text
                Dim Lin As String = Label54.Text
                Dim OC As String = TextBox122.Text
                Dim FOC As String = DateTimePicker1.Text
                Dim OCitems As String = TextBox142.Text
                Dim FecOcIts As String = DateTimePicker21.Text
                Dim FecEnt As String = DateTimePicker42.Text
                Dim FecEntIts As String = DateTimePicker41.Text

                Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
                Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
                Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
                '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "''" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
                '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

                Dim Seleccion As New MySqlCommand(Agregar, conex)
                Seleccion.Connection.Open()
                Seleccion.ExecuteNonQuery()

            Else CheckBox60.Checked = False

            End If
        End If

        Me.Close()

    End Sub
#End Region
#Region "PARA DEFINICION  "
    Private Sub CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox21.CheckedChanged, CheckBox22.CheckedChanged, CheckBox23.CheckedChanged, CheckBox24.CheckedChanged, CheckBox25.CheckedChanged, CheckBox26.CheckedChanged, CheckBox27.CheckedChanged, CheckBox28.CheckedChanged, CheckBox29.CheckedChanged, CheckBox30.CheckedChanged, CheckBox31.CheckedChanged, CheckBox32.CheckedChanged, CheckBox33.CheckedChanged, CheckBox34.CheckedChanged, CheckBox35.CheckedChanged, CheckBox36.CheckedChanged, CheckBox37.CheckedChanged, CheckBox38.CheckedChanged, CheckBox39.CheckedChanged, CheckBox40.CheckedChanged
        Dim frm As New Form15
        AddOwnedForm(frm)

        Dim checkBox As CheckBox = DirectCast(sender, CheckBox)
        Dim index As Integer = Integer.Parse(checkBox.Name.Replace("CheckBox", ""))

        ' Calcular la posición vertical en función del índice
        frm.Location = New Point(1055, 415 + (index - 21) * 28)

        ' Hacer visibles los botones correspondientes
        Dim startButton As Integer = (index - 21) * 4 + 1

        For i As Integer = startButton To startButton + 3
            Dim btn As Button = DirectCast(frm.Controls("Button" & i), Button)
            btn.Visible = True
        Next

        frm.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'PARA GENERAR ORDEN DE COMPRAR POR ITEMS, FECHA DE ORDEN COMPRA POR ITEMS Y FECHA DE ENTREGA POR ITEMS 
        'PARA TEXTBOX DE ORDEN DE COMPRA POR ITEMS
        TextBox123.Enabled = True
        TextBox124.Enabled = True
        TextBox125.Enabled = True
        TextBox126.Enabled = True
        TextBox127.Enabled = True
        TextBox128.Enabled = True
        TextBox129.Enabled = True
        TextBox130.Enabled = True
        TextBox131.Enabled = True
        TextBox132.Enabled = True
        TextBox133.Enabled = True
        TextBox134.Enabled = True
        TextBox135.Enabled = True
        TextBox136.Enabled = True
        TextBox137.Enabled = True
        TextBox138.Enabled = True
        TextBox139.Enabled = True
        TextBox140.Enabled = True
        TextBox141.Enabled = True
        TextBox142.Enabled = True

        'PARA DATETIMEPICKER FECHA DE OC POR ITEMS
        DateTimePicker2.Enabled = True
        DateTimePicker3.Enabled = True
        DateTimePicker4.Enabled = True
        DateTimePicker5.Enabled = True
        DateTimePicker6.Enabled = True
        DateTimePicker7.Enabled = True
        DateTimePicker8.Enabled = True
        DateTimePicker9.Enabled = True
        DateTimePicker10.Enabled = True
        DateTimePicker11.Enabled = True
        DateTimePicker12.Enabled = True
        DateTimePicker13.Enabled = True
        DateTimePicker14.Enabled = True
        DateTimePicker15.Enabled = True
        DateTimePicker16.Enabled = True
        DateTimePicker17.Enabled = True
        DateTimePicker18.Enabled = True
        DateTimePicker19.Enabled = True
        DateTimePicker20.Enabled = True
        DateTimePicker21.Enabled = True

        'PARA DATETIMEPICKER FECHA DE ENTREGA POR ITEMS
        DateTimePicker22.Enabled = True
        DateTimePicker23.Enabled = True
        DateTimePicker24.Enabled = True
        DateTimePicker25.Enabled = True
        DateTimePicker26.Enabled = True
        DateTimePicker27.Enabled = True
        DateTimePicker28.Enabled = True
        DateTimePicker29.Enabled = True
        DateTimePicker30.Enabled = True
        DateTimePicker31.Enabled = True
        DateTimePicker32.Enabled = True
        DateTimePicker33.Enabled = True
        DateTimePicker34.Enabled = True
        DateTimePicker35.Enabled = True
        DateTimePicker36.Enabled = True
        DateTimePicker37.Enabled = True
        DateTimePicker38.Enabled = True
        DateTimePicker39.Enabled = True
        DateTimePicker40.Enabled = True
        DateTimePicker41.Enabled = True


        'PARA DESACTIVAR TEXTBOX DE OC GENERAL Y DATETIMEPICKRER DE FECHA DE OC GENERAL - FECHA DE ENTREGA GENERAL 
        'AL MOMENTO DE ACTIVAR POR ITEMS 

        TextBox122.Enabled = False
        DateTimePicker1.Enabled = False
        DateTimePicker42.Enabled = False

    End Sub

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) Handles TextBox14.TextChanged
        If TextBox14.Text > "" Then
            TextBox19.Visible = True
            TextBox20.Visible = True
            TextBox21.Visible = True
            TextBox22.Visible = True
            TextBox23.Visible = True

            CheckBox22.Visible = True
            TextBox144.Visible = True
            CheckBox42.Visible = True
            TextBox124.Visible = True

            DateTimePicker3.Visible = True
            DateTimePicker23.Visible = True
        End If
    End Sub

    Private Sub TextBox19_TextChanged(sender As Object, e As EventArgs) Handles TextBox19.TextChanged
        If TextBox19.Text > "" Then
            TextBox24.Visible = True
            TextBox25.Visible = True
            TextBox26.Visible = True
            TextBox27.Visible = True
            TextBox28.Visible = True

            CheckBox23.Visible = True
            TextBox145.Visible = True
            CheckBox43.Visible = True
            TextBox125.Visible = True

            DateTimePicker4.Visible = True
            DateTimePicker24.Visible = True

        End If
    End Sub

    Private Sub TextBox24_TextChanged(sender As Object, e As EventArgs) Handles TextBox24.TextChanged
        If TextBox24.Text > "" Then
            TextBox29.Visible = True
            TextBox30.Visible = True
            TextBox31.Visible = True
            TextBox32.Visible = True
            TextBox33.Visible = True

            CheckBox24.Visible = True
            TextBox146.Visible = True
            CheckBox44.Visible = True
            TextBox126.Visible = True

            DateTimePicker5.Visible = True
            DateTimePicker25.Visible = True

        End If
    End Sub

    Private Sub TextBox29_TextChanged(sender As Object, e As EventArgs) Handles TextBox29.TextChanged
        If TextBox29.Text > "" Then
            TextBox34.Visible = True
            TextBox35.Visible = True
            TextBox36.Visible = True
            TextBox37.Visible = True
            TextBox38.Visible = True

            CheckBox25.Visible = True
            TextBox147.Visible = True
            CheckBox45.Visible = True
            TextBox127.Visible = True

            DateTimePicker6.Visible = True
            DateTimePicker26.Visible = True

        End If
    End Sub

    Private Sub TextBox34_TextChanged(sender As Object, e As EventArgs) Handles TextBox34.TextChanged
        If TextBox34.Text > "" Then
            TextBox39.Visible = True
            TextBox40.Visible = True
            TextBox41.Visible = True
            TextBox42.Visible = True
            TextBox43.Visible = True

            CheckBox26.Visible = True
            TextBox148.Visible = True
            CheckBox46.Visible = True
            TextBox128.Visible = True

            DateTimePicker7.Visible = True
            DateTimePicker27.Visible = True

        End If
    End Sub
    'cambiar desde aca uno hacia rribvba

    Private Sub TextBox39_TextChanged(sender As Object, e As EventArgs) Handles TextBox39.TextChanged
        If TextBox39.Text > "" Then
            TextBox44.Visible = True
            TextBox45.Visible = True
            TextBox46.Visible = True
            TextBox47.Visible = True
            TextBox48.Visible = True

            CheckBox27.Visible = True
            TextBox149.Visible = True
            CheckBox47.Visible = True
            TextBox129.Visible = True

            DateTimePicker8.Visible = True
            DateTimePicker28.Visible = True

        End If
    End Sub

    Private Sub TextBox44_TextChanged(sender As Object, e As EventArgs) Handles TextBox44.TextChanged
        If TextBox44.Text > "" Then
            TextBox49.Visible = True
            TextBox50.Visible = True
            TextBox51.Visible = True
            TextBox52.Visible = True
            TextBox53.Visible = True

            CheckBox28.Visible = True
            TextBox150.Visible = True
            CheckBox48.Visible = True
            TextBox130.Visible = True

            DateTimePicker9.Visible = True
            DateTimePicker29.Visible = True

        End If
    End Sub

    Private Sub TextBox49_TextChanged(sender As Object, e As EventArgs) Handles TextBox49.TextChanged
        If TextBox49.Text > "" Then
            TextBox54.Visible = True
            TextBox55.Visible = True
            TextBox56.Visible = True
            TextBox57.Visible = True
            TextBox58.Visible = True

            CheckBox29.Visible = True
            TextBox151.Visible = True
            CheckBox49.Visible = True
            TextBox131.Visible = True

            DateTimePicker10.Visible = True
            DateTimePicker30.Visible = True

        End If
    End Sub

    Private Sub TextBox54_TextChanged(sender As Object, e As EventArgs) Handles TextBox54.TextChanged
        If TextBox54.Text > "" Then
            TextBox59.Visible = True
            TextBox60.Visible = True
            TextBox61.Visible = True
            TextBox62.Visible = True
            TextBox63.Visible = True

            CheckBox30.Visible = True
            TextBox152.Visible = True
            CheckBox50.Visible = True
            TextBox132.Visible = True

            DateTimePicker11.Visible = True
            DateTimePicker31.Visible = True

        End If
    End Sub

    Private Sub TextBox59_TextChanged(sender As Object, e As EventArgs) Handles TextBox59.TextChanged
        If TextBox59.Text > "" Then
            TextBox64.Visible = True
            TextBox65.Visible = True
            TextBox66.Visible = True
            TextBox67.Visible = True
            TextBox68.Visible = True

            CheckBox31.Visible = True
            TextBox153.Visible = True
            CheckBox51.Visible = True
            TextBox133.Visible = True

            DateTimePicker12.Visible = True
            DateTimePicker32.Visible = True

        End If
    End Sub

    Private Sub TextBox64_TextChanged(sender As Object, e As EventArgs) Handles TextBox64.TextChanged
        If TextBox64.Text > "" Then
            TextBox69.Visible = True
            TextBox70.Visible = True
            TextBox71.Visible = True
            TextBox72.Visible = True
            TextBox73.Visible = True

            CheckBox32.Visible = True
            TextBox154.Visible = True
            CheckBox52.Visible = True
            TextBox134.Visible = True

            DateTimePicker13.Visible = True
            DateTimePicker33.Visible = True

        End If
    End Sub

    Private Sub TextBox69_TextChanged(sender As Object, e As EventArgs) Handles TextBox69.TextChanged
        If TextBox69.Text > "" Then
            TextBox74.Visible = True
            TextBox75.Visible = True
            TextBox76.Visible = True
            TextBox77.Visible = True
            TextBox78.Visible = True

            CheckBox33.Visible = True
            TextBox155.Visible = True
            CheckBox53.Visible = True
            TextBox135.Visible = True

            DateTimePicker14.Visible = True
            DateTimePicker34.Visible = True
        End If

    End Sub

    Private Sub TextBox74_TextChanged(sender As Object, e As EventArgs) Handles TextBox74.TextChanged
        If TextBox74.Text > "" Then
            TextBox79.Visible = True
            TextBox80.Visible = True
            TextBox81.Visible = True
            TextBox82.Visible = True
            TextBox83.Visible = True

            CheckBox34.Visible = True
            TextBox156.Visible = True
            CheckBox54.Visible = True
            TextBox136.Visible = True

            DateTimePicker15.Visible = True
            DateTimePicker35.Visible = True

        End If
    End Sub

    Private Sub TextBox79_TextChanged(sender As Object, e As EventArgs) Handles TextBox79.TextChanged
        If TextBox79.Text > "" Then
            TextBox84.Visible = True
            TextBox85.Visible = True
            TextBox86.Visible = True
            TextBox87.Visible = True
            TextBox88.Visible = True

            CheckBox35.Visible = True
            TextBox157.Visible = True
            CheckBox55.Visible = True
            TextBox137.Visible = True

            DateTimePicker16.Visible = True
            DateTimePicker36.Visible = True

        End If
    End Sub

    Private Sub TextBox84_TextChanged(sender As Object, e As EventArgs) Handles TextBox84.TextChanged
        If TextBox84.Text > "" Then
            TextBox89.Visible = True
            TextBox90.Visible = True
            TextBox91.Visible = True
            TextBox92.Visible = True
            TextBox93.Visible = True

            CheckBox36.Visible = True
            TextBox158.Visible = True
            CheckBox56.Visible = True
            TextBox138.Visible = True

            DateTimePicker17.Visible = True
            DateTimePicker37.Visible = True

        End If
    End Sub

    Private Sub TextBox89_TextChanged(sender As Object, e As EventArgs) Handles TextBox89.TextChanged
        If TextBox89.Text > "" Then
            TextBox94.Visible = True
            TextBox95.Visible = True
            TextBox96.Visible = True
            TextBox97.Visible = True
            TextBox98.Visible = True

            CheckBox37.Visible = True
            TextBox159.Visible = True
            CheckBox57.Visible = True
            TextBox139.Visible = True

            DateTimePicker18.Visible = True
            DateTimePicker38.Visible = True

        End If

    End Sub

    Private Sub TextBox94_TextChanged(sender As Object, e As EventArgs) Handles TextBox94.TextChanged
        If TextBox94.Text > "" Then
            TextBox99.Visible = True
            TextBox100.Visible = True
            TextBox101.Visible = True
            TextBox102.Visible = True
            TextBox103.Visible = True

            CheckBox38.Visible = True
            TextBox160.Visible = True
            CheckBox58.Visible = True
            TextBox140.Visible = True

            DateTimePicker19.Visible = True
            DateTimePicker39.Visible = True

        End If
    End Sub

    Private Sub TextBox99_TextChanged(sender As Object, e As EventArgs) Handles TextBox99.TextChanged
        If TextBox99.Text > "" Then
            TextBox104.Visible = True
            TextBox105.Visible = True
            TextBox106.Visible = True
            TextBox107.Visible = True
            TextBox108.Visible = True

            CheckBox39.Visible = True
            TextBox161.Visible = True
            CheckBox59.Visible = True
            TextBox141.Visible = True

            DateTimePicker20.Visible = True
            DateTimePicker40.Visible = True

        End If
    End Sub

    Private Sub TextBox104_TextChanged(sender As Object, e As EventArgs) Handles TextBox104.TextChanged
        If TextBox104.Text > "" Then
            TextBox109.Visible = True
            TextBox110.Visible = True
            TextBox111.Visible = True
            TextBox112.Visible = True
            TextBox113.Visible = True

            CheckBox40.Visible = True
            TextBox162.Visible = True
            CheckBox60.Visible = True
            TextBox142.Visible = True

            DateTimePicker21.Visible = True
            DateTimePicker41.Visible = True

        End If

    End Sub

#End Region
#Region "Nueva BD para Cotizaciones Aprobadas o OK"
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If MessageBox.Show("¿ Seguro que la Cotizacion esta APROBADA ?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            If TextBox14.Text > "" Then
                CheckBox61.Checked = True
            End If
            If TextBox19.Text > "" Then
                CheckBox62.Checked = True
            End If
            If TextBox24.Text > "" Then
                CheckBox63.Checked = True
            End If
            If TextBox29.Text > "" Then
                CheckBox64.Checked = True
            End If
            If TextBox34.Text > "" Then
                CheckBox65.Checked = True
            End If
            If TextBox39.Text > "" Then
                CheckBox66.Checked = True
            End If
            If TextBox44.Text > "" Then
                CheckBox67.Checked = True
            End If
            If TextBox49.Text > "" Then
                CheckBox68.Checked = True
            End If
            If TextBox54.Text > "" Then
                CheckBox69.Checked = True
            End If
            If TextBox59.Text > "" Then
                CheckBox70.Checked = True
            End If
            If TextBox64.Text > "" Then
                CheckBox71.Checked = True
            End If
            If TextBox69.Text > "" Then
                CheckBox72.Checked = True
            End If
            If TextBox74.Text > "" Then
                CheckBox73.Checked = True
            End If
            If TextBox79.Text > "" Then
                CheckBox74.Checked = True
            End If
            If TextBox84.Text > "" Then
                CheckBox75.Checked = True
            End If
            If TextBox89.Text > "" Then
                CheckBox76.Checked = True
            End If
            If TextBox94.Text > "" Then
                CheckBox77.Checked = True
            End If
            If TextBox99.Text > "" Then
                CheckBox78.Checked = True
            End If
            If TextBox104.Text > "" Then
                CheckBox79.Checked = True
            End If
            If TextBox109.Text > "" Then
                CheckBox80.Checked = True
            End If
        End If

        Me.Close()
        Form8.DGEdicion.Refresh()
        Form8.DGSeguimiento.Refresh()

    End Sub

    Private Sub CheckBox61_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox61.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox14.Text
            Dim Codi As String = TextBox15.Text
            Dim Cant As String = TextBox16.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox17.Text
            Dim Total As String = TextBox18.Text
            Dim Moneda As String = TextBox143.Text
            Dim ID As String = Label2.Text
            Dim Lin As String = Label35.Text
            Dim OC As String = TextBox122.Text
            Dim FOC As String = DateTimePicker1.Text
            Dim OCitems As String = TextBox123.Text
            Dim FecOcIts As String = DateTimePicker2.Text
            Dim FecEnt As String = DateTimePicker41.Text
            Dim FecEntIts As String = DateTimePicker22.Text

            Dim Agregar As String = "INSERT INTO TSADATACOTIZACIONOK (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
            Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
           '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", Me.TextBox15.Text)
            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
    End Sub

    Private Sub CheckBox62_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox62.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox19.Text
            Dim Codi As String = TextBox20.Text
            Dim Cant As String = TextBox21.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox22.Text
            Dim Total As String = TextBox23.Text
            Dim Moneda As String = TextBox144.Text
            Dim ID As String = Label2.Text
            Dim Lin As String = Label36.Text
            Dim OC As String = TextBox122.Text
            Dim FOC As String = DateTimePicker1.Text
            Dim OCitems As String = TextBox124.Text
            Dim FecOcIts As String = DateTimePicker3.Text
            Dim FecEnt As String = DateTimePicker42.Text
            Dim FecEntIts As String = DateTimePicker23.Text

            Dim Agregar As String = "INSERT INTO TSADATACOTIZACIONOK (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
            Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
           '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", Me.TextBox20.Text)
            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
    End Sub

    Private Sub CheckBox63_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox63.CheckedChanged

        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox24.Text
            Dim Codi As String = TextBox25.Text
            Dim Cant As String = TextBox26.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox27.Text
            Dim Total As String = TextBox28.Text
            Dim Moneda As String = TextBox145.Text
            Dim ID As String = Label2.Text
            Dim Lin As String = Label37.Text
            Dim OC As String = TextBox122.Text
            Dim FOC As String = DateTimePicker1.Text
            Dim OCitems As String = TextBox125.Text
            Dim FecOcIts As String = DateTimePicker4.Text
            Dim FecEnt As String = DateTimePicker42.Text
            Dim FecEntIts As String = DateTimePicker24.Text


            Dim Agregar As String = "INSERT INTO TSADATACOTIZACIONOK (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
            Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
           '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", Me.TextBox25.Text)
            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
    End Sub

    Private Sub CheckBox64_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox64.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox29.Text
            Dim Codi As String = TextBox30.Text
            Dim Cant As String = TextBox31.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox32.Text
            Dim Total As String = TextBox33.Text
            Dim Moneda As String = TextBox146.Text
            Dim ID As String = Label2.Text
            Dim Lin As String = Label38.Text
            Dim OC As String = TextBox122.Text
            Dim FOC As String = DateTimePicker1.Text
            Dim OCitems As String = TextBox126.Text
            Dim FecOcIts As String = DateTimePicker5.Text
            Dim FecEnt As String = DateTimePicker42.Text
            Dim FecEntIts As String = DateTimePicker25.Text


            Dim Agregar As String = "INSERT INTO TSADATACOTIZACIONOK (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
            Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
           '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", Me.TextBox30.Text)
            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
    End Sub

    Private Sub CheckBox65_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox65.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox34.Text
            Dim Codi As String = TextBox35.Text
            Dim Cant As String = TextBox36.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox37.Text
            Dim Total As String = TextBox38.Text
            Dim Moneda As String = TextBox147.Text
            Dim ID As String = Label2.Text
            Dim Lin As String = Label39.Text
            Dim OC As String = TextBox122.Text
            Dim FOC As String = DateTimePicker1.Text
            Dim OCitems As String = TextBox127.Text
            Dim FecOcIts As String = DateTimePicker6.Text
            Dim FecEnt As String = DateTimePicker42.Text
            Dim FecEntIts As String = DateTimePicker26.Text



            Dim Agregar As String = "INSERT INTO TSADATACOTIZACIONOK (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
            Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
           '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", Me.TextBox35.Text)
            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
    End Sub

    Private Sub CheckBox66_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox66.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox39.Text
            Dim Codi As String = TextBox40.Text
            Dim Cant As String = TextBox41.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox42.Text
            Dim Total As String = TextBox43.Text
            Dim Moneda As String = TextBox148.Text
            Dim ID As String = Label2.Text
            Dim Lin As String = Label40.Text
            Dim OC As String = TextBox122.Text
            Dim FOC As String = DateTimePicker1.Text
            Dim OCitems As String = TextBox128.Text
            Dim FecOcIts As String = DateTimePicker7.Text
            Dim FecEnt As String = DateTimePicker42.Text
            Dim FecEntIts As String = DateTimePicker27.Text


            Dim Agregar As String = "INSERT INTO TSADATACOTIZACIONOK (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
            Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
           '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", Me.TextBox40.Text)
            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
    End Sub

    Private Sub CheckBox67_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox67.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox44.Text
            Dim Codi As String = TextBox45.Text
            Dim Cant As String = TextBox46.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox47.Text
            Dim Total As String = TextBox48.Text
            Dim Moneda As String = TextBox149.Text
            Dim ID As String = Label2.Text
            Dim Lin As String = Label41.Text
            Dim OC As String = TextBox122.Text
            Dim FOC As String = DateTimePicker1.Text
            Dim OCitems As String = TextBox129.Text
            Dim FecOcIts As String = DateTimePicker8.Text
            Dim FecEnt As String = DateTimePicker42.Text
            Dim FecEntIts As String = DateTimePicker28.Text


            Dim Agregar As String = "INSERT INTO TSADATACOTIZACIONOK (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
            Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
           '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", Me.TextBox45.Text)
            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
    End Sub

    Private Sub CheckBox68_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox68.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox49.Text
            Dim Codi As String = TextBox50.Text
            Dim Cant As String = TextBox51.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox52.Text
            Dim Total As String = TextBox53.Text
            Dim Moneda As String = TextBox150.Text
            Dim ID As String = Label2.Text
            Dim Lin As String = Label42.Text
            Dim OC As String = TextBox122.Text
            Dim FOC As String = DateTimePicker1.Text
            Dim OCitems As String = TextBox130.Text
            Dim FecOcIts As String = DateTimePicker9.Text
            Dim FecEnt As String = DateTimePicker42.Text
            Dim FecEntIts As String = DateTimePicker29.Text


            Dim Agregar As String = "INSERT INTO TSADATACOTIZACIONOK (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
            Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
           '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", Me.TextBox50.Text)
            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
    End Sub

    Private Sub CheckBox69_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox69.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox54.Text
            Dim Codi As String = TextBox55.Text
            Dim Cant As String = TextBox56.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox57.Text
            Dim Total As String = TextBox58.Text
            Dim Moneda As String = TextBox151.Text
            Dim ID As String = Label2.Text
            Dim Lin As String = Label43.Text
            Dim OC As String = TextBox122.Text
            Dim FOC As String = DateTimePicker1.Text
            Dim OCitems As String = TextBox131.Text
            Dim FecOcIts As String = DateTimePicker10.Text
            Dim FecEnt As String = DateTimePicker42.Text
            Dim FecEntIts As String = DateTimePicker30.Text


            Dim Agregar As String = "INSERT INTO TSADATACOTIZACIONOK (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
            Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
           '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", Me.TextBox55.Text)
            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
    End Sub

    Private Sub CheckBox70_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox70.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox59.Text
            Dim Codi As String = TextBox60.Text
            Dim Cant As String = TextBox61.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox62.Text
            Dim Total As String = TextBox63.Text
            Dim Moneda As String = TextBox152.Text
            Dim ID As String = Label2.Text
            Dim Lin As String = Label44.Text
            Dim OC As String = TextBox122.Text
            Dim FOC As String = DateTimePicker1.Text
            Dim OCitems As String = TextBox132.Text
            Dim FecOcIts As String = DateTimePicker11.Text
            Dim FecEnt As String = DateTimePicker42.Text
            Dim FecEntIts As String = DateTimePicker31.Text


            Dim Agregar As String = "INSERT INTO TSADATACOTIZACIONOK (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
            Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
           '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", Me.TextBox60.Text)
            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
    End Sub

    Private Sub CheckBox71_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox71.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text


            Dim Descrip As String = TextBox64.Text
            Dim Codi As String = TextBox65.Text
            Dim Cant As String = TextBox66.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox67.Text
            Dim Total As String = TextBox68.Text
            Dim Moneda As String = TextBox153.Text
            Dim ID As String = Label2.Text
            Dim Lin As String = Label45.Text
            Dim OC As String = TextBox122.Text
            Dim FOC As String = DateTimePicker1.Text
            Dim OCitems As String = TextBox133.Text
            Dim FecOcIts As String = DateTimePicker12.Text
            Dim FecEnt As String = DateTimePicker42.Text
            Dim FecEntIts As String = DateTimePicker32.Text


            Dim Agregar As String = "INSERT INTO TSADATACOTIZACIONOK (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
            Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
           '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", Me.TextBox65.Text)
            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
    End Sub

    Private Sub CheckBox72_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox72.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox69.Text
            Dim Codi As String = TextBox70.Text
            Dim Cant As String = TextBox71.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox72.Text
            Dim Total As String = TextBox73.Text
            Dim Moneda As String = TextBox154.Text
            Dim ID As String = Label2.Text
            Dim Lin As String = Label46.Text
            Dim OC As String = TextBox122.Text
            Dim FOC As String = DateTimePicker1.Text
            Dim OCitems As String = TextBox134.Text
            Dim FecOcIts As String = DateTimePicker13.Text
            Dim FecEnt As String = DateTimePicker42.Text
            Dim FecEntIts As String = DateTimePicker33.Text

            Dim Agregar As String = "INSERT INTO TSADATACOTIZACIONOK (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
            Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
           '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", Me.TextBox70.Text)
            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
    End Sub

    Private Sub CheckBox73_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox73.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox74.Text
            Dim Codi As String = TextBox75.Text
            Dim Cant As String = TextBox76.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox77.Text
            Dim Total As String = TextBox78.Text
            Dim Moneda As String = TextBox155.Text
            Dim ID As String = Label2.Text
            Dim Lin As String = Label47.Text
            Dim OC As String = TextBox122.Text
            Dim FOC As String = DateTimePicker1.Text
            Dim OCitems As String = TextBox135.Text
            Dim FecOcIts As String = DateTimePicker14.Text
            Dim FecEnt As String = DateTimePicker42.Text
            Dim FecEntIts As String = DateTimePicker34.Text

            Dim Agregar As String = "INSERT INTO TSADATACOTIZACIONOK (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
            Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
           '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", Me.TextBox75.Text)
            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
    End Sub

    Private Sub CheckBox74_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox74.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox79.Text
            Dim Codi As String = TextBox80.Text
            Dim Cant As String = TextBox81.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox82.Text
            Dim Total As String = TextBox83.Text
            Dim Moneda As String = TextBox156.Text
            Dim ID As String = Label2.Text
            Dim Lin As String = Label48.Text
            Dim OC As String = TextBox122.Text
            Dim FOC As String = DateTimePicker1.Text
            Dim OCitems As String = TextBox136.Text
            Dim FecOcIts As String = DateTimePicker15.Text
            Dim FecEnt As String = DateTimePicker42.Text
            Dim FecEntIts As String = DateTimePicker35.Text

            Dim Agregar As String = "INSERT INTO TSADATACOTIZACIONOK (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
            Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
           '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", Me.TextBox80.Text)
            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
    End Sub

    Private Sub CheckBox75_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox75.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox84.Text
            Dim Codi As String = TextBox85.Text
            Dim Cant As String = TextBox86.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox87.Text
            Dim Total As String = TextBox88.Text
            Dim Moneda As String = TextBox157.Text
            Dim ID As String = Label2.Text
            Dim Lin As String = Label49.Text
            Dim OC As String = TextBox122.Text
            Dim FOC As String = DateTimePicker1.Text
            Dim OCitems As String = TextBox137.Text
            Dim FecOcIts As String = DateTimePicker16.Text
            Dim FecEnt As String = DateTimePicker42.Text
            Dim FecEntIts As String = DateTimePicker36.Text


            Dim Agregar As String = "INSERT INTO TSADATACOTIZACIONOK (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
            Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
           '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", Me.TextBox85.Text)
            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
    End Sub

    Private Sub CheckBox76_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox76.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text


            Dim Descrip As String = TextBox89.Text
            Dim Codi As String = TextBox90.Text
            Dim Cant As String = TextBox91.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox92.Text
            Dim Total As String = TextBox93.Text
            Dim Moneda As String = TextBox158.Text
            Dim ID As String = Label2.Text
            Dim Lin As String = Label50.Text
            Dim OC As String = TextBox122.Text
            Dim FOC As String = DateTimePicker1.Text
            Dim OCitems As String = TextBox138.Text
            Dim FecOcIts As String = DateTimePicker17.Text
            Dim FecEnt As String = DateTimePicker42.Text
            Dim FecEntIts As String = DateTimePicker37.Text



            Dim Agregar As String = "INSERT INTO TSADATACOTIZACIONOK (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
            Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
           '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", Me.TextBox90.Text)
            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
    End Sub

    Private Sub CheckBox77_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox77.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox94.Text
            Dim Codi As String = TextBox95.Text
            Dim Cant As String = TextBox96.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox97.Text
            Dim Total As String = TextBox98.Text
            Dim Moneda As String = TextBox159.Text
            Dim ID As String = Label2.Text
            Dim Lin As String = Label51.Text
            Dim OC As String = TextBox122.Text
            Dim FOC As String = DateTimePicker1.Text
            Dim OCitems As String = TextBox139.Text
            Dim FecOcIts As String = DateTimePicker18.Text
            Dim FecEnt As String = DateTimePicker42.Text
            Dim FecEntIts As String = DateTimePicker38.Text



            Dim Agregar As String = "INSERT INTO TSADATACOTIZACIONOK (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
            Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
           '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", Me.TextBox95.Text)
            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
    End Sub

    Private Sub CheckBox78_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox78.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox99.Text
            Dim Codi As String = TextBox100.Text
            Dim Cant As String = TextBox101.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox102.Text
            Dim Total As String = TextBox103.Text
            Dim Moneda As String = TextBox160.Text
            Dim ID As String = Label2.Text
            Dim Lin As String = Label52.Text
            Dim OC As String = TextBox122.Text
            Dim FOC As String = DateTimePicker1.Text
            Dim OCitems As String = TextBox140.Text
            Dim FecOcIts As String = DateTimePicker19.Text
            Dim FecEnt As String = DateTimePicker42.Text
            Dim FecEntIts As String = DateTimePicker39.Text


            Dim Agregar As String = "INSERT INTO TSADATACOTIZACIONOK (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
            Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
           '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", Me.TextBox100.Text)
            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
    End Sub

    Private Sub CheckBox79_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox79.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox104.Text
            Dim Codi As String = TextBox105.Text
            Dim Cant As String = TextBox106.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox107.Text
            Dim Total As String = TextBox108.Text
            Dim Moneda As String = TextBox161.Text
            Dim ID As String = Label2.Text
            Dim Lin As String = Label53.Text
            Dim OC As String = TextBox122.Text
            Dim FOC As String = DateTimePicker1.Text
            Dim OCitems As String = TextBox141.Text
            Dim FecOcIts As String = DateTimePicker20.Text
            Dim FecEnt As String = DateTimePicker42.Text
            Dim FecEntIts As String = DateTimePicker40.Text

            Dim Agregar As String = "INSERT INTO TSADATACOTIZACIONOK (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
            Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
           '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", Me.TextBox105.Text)
            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
    End Sub

    Private Sub CheckBox80_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox80.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox109.Text
            Dim Codi As String = TextBox110.Text
            Dim Cant As String = TextBox111.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox112.Text
            Dim Total As String = TextBox113.Text
            Dim Moneda As String = TextBox162.Text
            Dim ID As String = Label2.Text
            Dim Lin As String = Label54.Text
            Dim OC As String = TextBox122.Text
            Dim FOC As String = DateTimePicker1.Text
            Dim OCitems As String = TextBox142.Text
            Dim FecOcIts As String = DateTimePicker21.Text
            Dim FecEnt As String = DateTimePicker42.Text
            Dim FecEntIts As String = DateTimePicker41.Text

            Dim Agregar As String = "INSERT INTO TSADATACOTIZACIONOK (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Total, Moneda, ID, Linea, OC, FechaOC, OC_Items, Fecha_OC_Items, Fecha_Entrega,
            Fecha_Ent_Items) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Lin & "','" & OC & "',
           '" & FOC & "','" & OCitems & "','" & FecOcIts & "','" & FecEnt & "','" & FecEntIts & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", Me.TextBox110.Text)
            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()
        End If


    End Sub

    Private Sub TextBox115_TextChanged(sender As Object, e As EventArgs) Handles TextBox115.TextChanged
        Select Case TextBox115.Text
            Case "CLP"
                BtnExpClp.Visible = True
                BtnExpUSD.Visible = False
                BtnExpEUR.Visible = False
            Case "USD"
                BtnExpClp.Visible = False
                BtnExpUSD.Visible = True
                BtnExpEUR.Visible = False
            Case "EUR"
                BtnExpClp.Visible = False
                BtnExpUSD.Visible = False
                BtnExpEUR.Visible = True
            Case Else
                BtnExpClp.Visible = False
                BtnExpUSD.Visible = False
                BtnExpEUR.Visible = False
        End Select
    End Sub

#End Region
#Region "PARA HABILITAR COTIZACIONES DEFINIDAS"
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'If MessageBox.Show("¿ Seguro quieres habilitar la cotizacion ?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
        ' If TextBox14.Text > "" Then
        ' CheckBox81.Checked = True
        'End If
        'If TextBox19.Text > "" Then
        'CheckBox82.Checked = True
        'End If
        'If T'extBox24.Text > "" Then
        'CheckBox83.Checked = True
        'End If
        'If TextBox29.Text > "" Then
        'CheckBox84.Checked = True
        'End If
        ' If TextBox34.Text > "" Then
        'CheckBox85.Checked = True
        'End If
        'If TextBox39.Text > "" Then
        ' CheckBox86.Checked = True
        'End If
        'If TextBox44.Text > "" Then
        '      CheckBox87.Checked = True
        '   End If
        'If TextBox49.Text > "" Then
        ' CheckBox88.Checked = True
        '       End If
        '  If TextBox54.Text > "" Then
        '   CheckBox89.Checked = True
        '       End If
        'If TextBox59.Text > "" Then
        'CheckBox90.Checked = True
        'End If
        'If TextBox64.Text > "" Then
        ' CheckBox91.Checked = True
        ' End If
        'If TextBox69.Text > "" Then
        'CheckBox92.Checked = True
        'End If
        'If TextBox74.Text > "" Then
        'Che'ckBox93.Checked = True
        'End If
        'If TextBox79.Text > "" Then
        'CheckBox94.Checked = True
        'End If
        'If' TextBox84.Text > "" Then
        '  CheckBox95.Checked = True
        '   End If
        ' If TextBox89.Text > "" Then
        'CheckBox96.Checked = True
        'End If
        '    If TextBox94.Text > "" Then
        ' CheckBox97.Checked = True
        'End If
        'If TextBox99.Text > "" Then
        'CheckBox98.Checked = True
        'End If
        'If TextBox104.Text > "" Then
        'CheckBox99.Checked = True
        'End If
        '  If TextBox109.Text > "" Then
        '         CheckBox100.Checked = True
        ' End If
        '  End If
    End Sub

    Private Sub CheckBox81_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox81.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox14.Text
            Dim Codi As String = TextBox15.Text
            Dim Cant As String = TextBox16.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox17.Text
            Dim Moneda As String = TextBox143.Text
            Dim ID As String = Label2.Text

            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
        Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Moneda, ID) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Moneda & "','" & ID & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
            Dim ELIMINACION As String = ("DELETE FROM TSADATADEFINICION WHERE ID= ?ID")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()
        End If

    End Sub

    Private Sub CheckBox82_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox82.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox19.Text
            Dim Codi As String = TextBox20.Text
            Dim Cant As String = TextBox21.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox22.Text
            Dim Moneda As String = TextBox144.Text
            Dim ID As String = Label2.Text


            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
        Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Moneda, ID) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Moneda & "','" & ID & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
            Dim ELIMINACION As String = ("DELETE FROM TSADATADEFINICION WHERE ID= ?ID")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()
        End If
    End Sub

    Private Sub CheckBox83_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox83.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox24.Text
            Dim Codi As String = TextBox25.Text
            Dim Cant As String = TextBox26.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox27.Text
            Dim Moneda As String = TextBox145.Text
            Dim ID As String = Label2.Text


            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
        Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Moneda, ID) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Moneda & "','" & ID & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
            Dim ELIMINACION As String = ("DELETE FROM TSADATADEFINICION WHERE ID= ?ID")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()
        End If
    End Sub

    Private Sub CheckBox84_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox84.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox29.Text
            Dim Codi As String = TextBox30.Text
            Dim Cant As String = TextBox31.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox32.Text
            Dim Moneda As String = TextBox146.Text
            Dim ID As String = Label2.Text


            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
        Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Moneda, ID) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Moneda & "','" & ID & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
            Dim ELIMINACION As String = ("DELETE FROM TSADATADEFINICION WHERE ID= ?ID")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()
        End If
    End Sub

    Private Sub CheckBox85_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox85.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

             Dim Descrip As String = TextBox34.Text
            Dim Codi As String = TextBox35.Text
            Dim Cant As String = TextBox36.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox37.Text
            Dim Moneda As String = TextBox147.Text
            Dim ID As String = Label2.Text


            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
        Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Moneda, ID) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Moneda & "','" & ID & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
            Dim ELIMINACION As String = ("DELETE FROM TSADATADEFINICION WHERE ID= ?ID")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()
        End If
    End Sub

    Private Sub CheckBox86_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox86.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox39.Text
            Dim Codi As String = TextBox40.Text
            Dim Cant As String = TextBox41.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox42.Text
            Dim Moneda As String = TextBox148.Text
            Dim ID As String = Label2.Text


            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
        Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Moneda, ID) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Moneda & "','" & ID & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
            Dim ELIMINACION As String = ("DELETE FROM TSADATADEFINICION WHERE ID= ?ID")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()
        End If
    End Sub

    Private Sub CheckBox87_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox87.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox44.Text
            Dim Codi As String = TextBox45.Text
            Dim Cant As String = TextBox46.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox47.Text
            Dim Moneda As String = TextBox149.Text
            Dim ID As String = Label2.Text


            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
        Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Moneda, ID) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Moneda & "','" & ID & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
            Dim ELIMINACION As String = ("DELETE FROM TSADATADEFINICION WHERE ID= ?ID")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()
        End If
    End Sub

    Private Sub CheckBox88_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox88.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox49.Text
            Dim Codi As String = TextBox50.Text
            Dim Cant As String = TextBox51.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox52.Text
            Dim Moneda As String = TextBox150.Text
            Dim ID As String = Label2.Text


            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
        Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Moneda, ID) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Moneda & "','" & ID & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
            Dim ELIMINACION As String = ("DELETE FROM TSADATADEFINICION WHERE ID= ?ID")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()
        End If
    End Sub

    Private Sub CheckBox89_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox89.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

             Dim Descrip As String = TextBox54.Text
            Dim Codi As String = TextBox55.Text
            Dim Cant As String = TextBox56.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox57.Text
            Dim Moneda As String = TextBox151.Text
            Dim ID As String = Label2.Text


            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
        Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Moneda, ID) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Moneda & "','" & ID & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
            Dim ELIMINACION As String = ("DELETE FROM TSADATADEFINICION WHERE ID= ?ID")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()
        End If
    End Sub

    Private Sub CheckBox90_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox90.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

             Dim Descrip As String = TextBox59.Text
            Dim Codi As String = TextBox60.Text
            Dim Cant As String = TextBox61.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox62.Text
            Dim Moneda As String = TextBox152.Text
            Dim ID As String = Label2.Text


            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
        Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Moneda, ID) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Moneda & "','" & ID & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
            Dim ELIMINACION As String = ("DELETE FROM TSADATADEFINICION WHERE ID= ?ID")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()
        End If
    End Sub

    Private Sub CheckBox91_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox91.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox64.Text
            Dim Codi As String = TextBox65.Text
            Dim Cant As String = TextBox66.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox67.Text
            Dim Moneda As String = TextBox153.Text
            Dim ID As String = Label2.Text


            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
        Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Moneda, ID) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Moneda & "','" & ID & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
            Dim ELIMINACION As String = ("DELETE FROM TSADATADEFINICION WHERE ID= ?ID")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()
        End If
    End Sub

    Private Sub CheckBox92_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox92.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

             Dim Descrip As String = TextBox69.Text
            Dim Codi As String = TextBox70.Text
            Dim Cant As String = TextBox71.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox72.Text
            Dim Moneda As String = TextBox154.Text
            Dim ID As String = Label2.Text


            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
        Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Moneda, ID) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Moneda & "','" & ID & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
            Dim ELIMINACION As String = ("DELETE FROM TSADATADEFINICION WHERE ID= ?ID")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()
        End If
    End Sub

    Private Sub CheckBox93_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox93.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

              Dim Descrip As String = TextBox74.Text
            Dim Codi As String = TextBox75.Text
            Dim Cant As String = TextBox76.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox77.Text
            Dim Moneda As String = TextBox155.Text
            Dim ID As String = Label2.Text


            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
        Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Moneda, ID) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Moneda & "','" & ID & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
            Dim ELIMINACION As String = ("DELETE FROM TSADATADEFINICION WHERE ID= ?ID")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()
        End If
    End Sub

    Private Sub CheckBox94_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox94.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox79.Text
            Dim Codi As String = TextBox80.Text
            Dim Cant As String = TextBox81.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox82.Text
            Dim Moneda As String = TextBox156.Text
            Dim ID As String = Label2.Text

            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
        Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Moneda, ID) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Moneda & "','" & ID & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
            Dim ELIMINACION As String = ("DELETE FROM TSADATADEFINICION WHERE ID= ?ID")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()
        End If
    End Sub

    Private Sub CheckBox95_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox95.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

             Dim Descrip As String = TextBox84.Text
            Dim Codi As String = TextBox85.Text
            Dim Cant As String = TextBox86.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox87.Text
            Dim Moneda As String = TextBox157.Text
            Dim ID As String = Label2.Text

            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
        Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Moneda, ID) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Moneda & "','" & ID & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
            Dim ELIMINACION As String = ("DELETE FROM TSADATADEFINICION WHERE ID= ?ID")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()
        End If
    End Sub

    Private Sub CheckBox96_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox96.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox89.Text
            Dim Codi As String = TextBox90.Text
            Dim Cant As String = TextBox91.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox92.Text
            Dim Moneda As String = TextBox158.Text
            Dim ID As String = Label2.Text

            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
        Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Moneda, ID) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Moneda & "','" & ID & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
            Dim ELIMINACION As String = ("DELETE FROM TSADATADEFINICION WHERE ID= ?ID")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()
        End If
    End Sub

    Private Sub CheckBox97_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox97.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

             Dim Descrip As String = TextBox94.Text
            Dim Codi As String = TextBox95.Text
            Dim Cant As String = TextBox96.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox97.Text
            Dim Moneda As String = TextBox159.Text
            Dim ID As String = Label2.Text


            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
        Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Moneda, ID) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Moneda & "','" & ID & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
            Dim ELIMINACION As String = ("DELETE FROM TSADATADEFINICION WHERE ID= ?ID")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()
        End If
    End Sub

    Private Sub CheckBox98_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox97.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox99.Text
            Dim Codi As String = TextBox100.Text
            Dim Cant As String = TextBox101.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox102.Text
            Dim Moneda As String = TextBox160.Text
            Dim ID As String = Label2.Text


            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
        Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Moneda, ID) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Moneda & "','" & ID & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
            Dim ELIMINACION As String = ("DELETE FROM TSADATADEFINICION WHERE ID= ?ID")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()
        End If
    End Sub

    Private Sub CheckBox99_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox99.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

            Dim Descrip As String = TextBox104.Text
            Dim Codi As String = TextBox105.Text
            Dim Cant As String = TextBox106.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox107.Text
            Dim Moneda As String = TextBox161.Text
            Dim ID As String = Label2.Text


            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
        Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Moneda, ID) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Moneda & "','" & ID & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
            Dim ELIMINACION As String = ("DELETE FROM TSADATADEFINICION WHERE ID= ?ID")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()
        End If
    End Sub

    Private Sub CheckBox100_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox100.CheckedChanged
        If (Label2.Text = "") Then
            Label2.Select()
        Else
            Dim Cot As String = TextBox7.Text
            Dim Fec As String = TextBox8.Text
            Dim Raz As String = TextBox1.Text
            Dim RUT As String = TextBox3.Text
            Dim Ate As String = TextBox2.Text
            Dim DirAte As String = TextBox4.Text
            Dim TelAte As String = TextBox5.Text
            Dim CorAte As String = TextBox6.Text
            Dim Ven As String = TextBox9.Text
            Dim TelVen As String = TextBox12.Text
            Dim CorVen As String = TextBox10.Text
            Dim Web As String = TextBox11.Text
            Dim Ref As String = TextBox13.Text

             Dim Descrip As String = TextBox109.Text
            Dim Codi As String = TextBox110.Text
            Dim Cant As String = TextBox111.Text
            Dim Margen As String = 0
            Dim Precio As String = TextBox112.Text
            Dim Moneda As String = TextBox162.Text
            Dim ID As String = Label2.Text


            Dim Agregar As String = "INSERT INTO TSADATACOTIZACION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
        Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Margen, Precio, Moneda, ID) VALUES ('" & Cot & "','" & Fec & "','" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "',
           '" & CorVen & "','" & Web & "','" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Margen & "','" & Precio & "','" & Moneda & "','" & ID & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
            Dim ELIMINACION As String = ("DELETE FROM TSADATADEFINICION WHERE ID= ?ID")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?ID", Me.Label2.Text)

            Borrar.ExecuteNonQuery()
        End If
    End Sub

#End Region

End Class