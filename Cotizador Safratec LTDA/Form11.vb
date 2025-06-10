
Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement


Public Class Form11
    Private Const S As String = "INSERT INTO TSADATACOTIZACION(Cotizacion,Fecha,Razon_Social,RUT,Atencion,Direccion_ate,Telefono_ate,Correo_ate,Contacto,Telefono_cont,Correo_cont,Pagina_web,Referencia,Descripcion_Mat,Codigo_Mat,Cantidad,Margen,Precio, Moneda, ID) VALUES ('"
    Private Const A As String = "INSERT INTO Atenciones(Razon_Social,RUT,Atencion,Direccion,Telefono,Correo) VALUES ('"
    Private Const O As String = "INSERT INTO DATAszAMBLED(Cotizacion,Fecha,RazonSocial,RUT,Atencion,Direccion,Telefono,Correo,Vendedor,TelefonoV,CorreoV,PaginaWeb,Referencia,TipoAnimal,AlturaalHombro,AlturaalaCumbrera,AlturaalaCercha,Ancho,Largo,CieloRazo,CantidaddePasillos,AnchodePasillo,CantidaddeBaterias,AlturadeBateria,AnchodelaBateria,DistanciaentreCerchas,Materialdelacercha,MaterialdelPiso,MaterialdelaPared,MaterialdelTecho,Nidos,AnchodeNido,LargodelNido,Slat,AnchodeSlat,LargodeSlat,TipoLuminaria,ModeloLuminaria,DescripciondeLuminarias,CantidadLuminaria,NumerodeFilaLuminarias,NumerodeColumnaLuminaria,Dimensiones,Angulo,Power,EMaxima,EMinima,EPromedio,Uniformidad,Temperatura,MF,ObjetivoIluminacion,EstimacionLux,DistanciaentreParedFrontal,DistanciaentreparedLateral,DistanciaentreColumnas,Distanciaentrefila,TipodeCable,LargodecableentreLuminaria,Cantidaddecablesentreluminarias,lardecableentreparedfrontalyprilum,cantidaddeTs,TipodeTs,Cantidaddecableentreparedfrontalyprilumcol,Cantidaddecablesentretsfrontales,LargoentreTsFrontales,Largocabledecontaredenchufem,Largocabledecontaredenchufeh,Dimmer,Descripcion) VALUES('"
    Dim sql As String
    Dim cadena2 As String = "Server = 162.144.3.49; Database = tsachile_cotizador; Uid = tsachile_admin; Pwd = 17543593apple"
    'Declaro e inicializo objeto para hacer la conexion a mi base datos de cpanel por medio MySQL 
    Public conex As New MySqlConnection("Server = 162.144.3.49; Database = tsachile_cotizador; Uid = tsachile_admin; Pwd = 17543593apple")
    ' Por medio de este objeto voy a enviar todos los comandos de SQL a la tabla por medio de la conexión
    Public comm As New MySqlCommand

    Private Sub TxtRazon_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtRazon.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim Razon As String = TxtRazon.Text.ToString
            Dim sqlcliente As String = " Select * From  Clientes where Razon_Social Like '%" & Razon & "%' "

            Cargar_MySQLCliente(sqlcliente, DGRazonSocial)
        End If
    End Sub

    Private Sub DGRazonSocial_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGRazonSocial.CellContentClick
        Dim xtreme As Integer
        xtreme = DGRazonSocial.CurrentRow.Index
        TxtRazon.Text = Me.DGRazonSocial.Item(0, xtreme).Value
        TxtRut.Text = Me.DGRazonSocial.Item(1, xtreme).Value

        DGVatencion.Visible = True

        Dim porrazon As String = TxtRazon.Text.ToString

        Dim porrut As String = TxtRut.Text.ToString

        Dim sql As String = " Select * From Atenciones Where Razon_Social ='" & porrazon & "'and RUT='" & porrut & "' "

        Cargar_MySQL(sql, DGVatencion)
    End Sub

    Private Sub DGVatencion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVatencion.CellContentClick
        Dim fila As Integer
        fila = DGVatencion.CurrentRow.Index
        TxtAtencion.Text = Me.DGVatencion.Item(3, fila).Value
        TxtDireccion.Text = Me.DGVatencion.Item(4, fila).Value
        TxtphoneC.Text = Me.DGVatencion.Item(5, fila).Value
        TxtCorreoC.Text = Me.DGVatencion.Item(6, fila).Value
    End Sub

    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'Abrir la conexión
            If conex.State = ConnectionState.Closed Then
                conex.Open()

            End If
            ' Inicializo el objeto Command
            comm.Connection = conex
            comm.CommandType = CommandType.Text

        Catch ex As Exception
            If Err.Number = 5 Then
                MsgBox("No se pudo encontrar el archivo de la base de datos", MsgBoxStyle.Exclamation, "SAFRATEC")
                End
            Else
                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "TSA")
            End If
        End Try

        TxtFecha.Text = Format(Now, "dd/MM/yyyy")
        TxtCot.Text = Format(Now, "yyyyMMdd")
        Using cnx As New MySqlConnection(cadena2)
            Dim conexion2 As New MySqlDataAdapter("select distinct Vendedores,Mail,Telefono,Inicial,Pagina from Vendedores", cnx)
            Dim dtx As New DataTable("Vendedores")
            conexion2.Fill(dtx)
            CboContacto.DataSource = dtx
            CboContacto.DisplayMember = "Vendedores"
            CboContacto.Refresh()

            Dim connection As New MySqlDataAdapter("select distinct LUGAR_ENTREGA,D_entrega from Lugar", cnx)
            Dim dtz As New DataTable("Lugar")
            connection.Fill(dtz)
            CboLugar.DataSource = dtz
            CboLugar.DisplayMember = "LUGAR_ENTREGA"
            CboLugar.Refresh()

            Dim union As New MySqlDataAdapter("select  distinct condiciones from Pago", cnx)
            Dim dth As New DataTable("Pago")
            union.Fill(dth)
            Cbopago.DataSource = dth
            Cbopago.DisplayMember = "condiciones"
            Cbopago.Refresh()

            Dim vans As New MySqlDataAdapter("select distinct validez from Validez", cnx)
            Dim dtk As New DataTable("Validez")
            vans.Fill(dtk)
            CboValidez.DataSource = dtk
            CboValidez.DisplayMember = "validez"
            CboValidez.Refresh()

            Dim xtreme As New MySqlDataAdapter("select distinct TipoAnimal from Tipoanimal", cnx)
            Dim xts As New DataTable("Tipoanimal")
            xtreme.Fill(xts)
            ComboBox1.DataSource = xts
            ComboBox1.DisplayMember = "TipoAnimal"
            ComboBox1.Refresh()

            Dim vxz As New MySqlDataAdapter("select distinct Tipo,ID from TipoL ", cnx)
            Dim xxx As New DataTable("TipoL")
            vxz.Fill(xxx)
            ComboBox2.DataSource = xxx
            ComboBox2.DisplayMember = "Tipo"
            ComboBox2.Refresh()


            Dim aaa As New MySqlDataAdapter("select distinct Modelo,Descripcion,Precio from Dimmer", cnx)
            Dim aaz As New DataTable("Dimmer")
            aaa.Fill(aaz)
            ComboBox3.DataSource = aaz
            ComboBox3.DisplayMember = "Modelo"
            ComboBox3.Refresh()

        End Using

        'Para limpiar Combobox y TextBox
        TxtRazon.Text = ""
        CboContacto.Text = ""
        CboLugar.Text = ""
        Cbopago.Text = ""
        CboValidez.Text = ""
        TxtWeb.Text = ""
        TxtRut.Text = ""
        TxtphoneV.Text = ""
        TxtCorreoV.Text = ""
        Txtcot2.Text = ""
        TxtDireccionEntrega.Text = ""
        TxtDireccion.Text = ""
        TxtphoneC.Text = ""
        TxtCorreoC.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        ComboBox5.Text = ""
        ComboBox7.Text = ""
        TextBox24.Text = ""
        TextBox40.Text = ""
        TextBox41.Text = ""
        TextBox45.Text = ""
        TextBox46.Text = ""
        TextBox48.Text = ""
        TextBox50.Text = ""
        TextBox51.Text = ""
        TextBox53.Text = ""
        TextBox54.Text = ""
        TextBox49.Text = ""




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

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        'Para busquedad segun el combobox anterior por tipo de luminarias
        Using cnx As New MySqlConnection(cadena2)
            Dim vxy As New MySqlDataAdapter("select Tipo,Modelo,Dimensiones,Angulo,power,cct,tipoc,Descripcioncable,Descripcion,Tconector,Precio,CodigoCableHem,TcableHembra,DescripcionTS From Tipoluminarias  WHERE  Tipo= '" & ComboBox2.Text & "'", cnx)
            Dim xxz As New DataTable("Tipoluminarias")
            vxy.Fill(xxz)
            ComboBox4.DataSource = xxz
            ComboBox4.DisplayMember = "Modelo"
            ComboBox4.Refresh()
            'para Activacion de Factor de mantenimiento de 0.8
            If ComboBox4.Text > "" Then
                TextBox25.Text = 0.8
            End If
            Me.TextBox49.Text = CType(Me.ComboBox2.DataSource, DataTable).Rows(Me.ComboBox2.SelectedIndex)("ID") 'Id de Tabla TipoL

        End Using

    End Sub
#Region "Para Habilitacion de Botones para las proformas invoice segun el modelo"
    Private Sub TextBox49_TextChanged(sender As Object, e As EventArgs) Handles TextBox49.TextChanged
        'If TextBox49.SelectedText = "1" Then
        'Button3.Visible = True
        'Else
        'Button3.Visible = False

        'End If
        'If TextBox49.SelectedText = "2" Then
        'Button6.Visible = True
        'Else
        'Button6.Visible = False
        'End If
    End Sub
#End Region
    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        Me.TextBox40.Text = CType(Me.ComboBox4.DataSource, DataTable).Rows(Me.ComboBox4.SelectedIndex)("Dimensiones")
        Me.TextBox41.Text = CType(Me.ComboBox4.DataSource, DataTable).Rows(Me.ComboBox4.SelectedIndex)("Angulo")
        Me.TextBox45.Text = CType(Me.ComboBox4.DataSource, DataTable).Rows(Me.ComboBox4.SelectedIndex)("power")
        Me.TextBox24.Text = CType(Me.ComboBox4.DataSource, DataTable).Rows(Me.ComboBox4.SelectedIndex)("cct")
        Me.TextBox46.Text = CType(Me.ComboBox4.DataSource, DataTable).Rows(Me.ComboBox4.SelectedIndex)("tipoc")
        Me.TextBox50.Text = CType(Me.ComboBox4.DataSource, DataTable).Rows(Me.ComboBox4.SelectedIndex)("Descripcion")
        Me.TextBox51.Text = CType(Me.ComboBox4.DataSource, DataTable).Rows(Me.ComboBox4.SelectedIndex)("Modelo")
        Me.TextBox53.Text = CType(Me.ComboBox4.DataSource, DataTable).Rows(Me.ComboBox4.SelectedIndex)("tipoc")
        Me.TextBox54.Text = CType(Me.ComboBox4.DataSource, DataTable).Rows(Me.ComboBox4.SelectedIndex)("Tconector")
        Me.TextBox55.Text = CType(Me.ComboBox4.DataSource, DataTable).Rows(Me.ComboBox4.SelectedIndex)("Precio")
        Me.TextBox58.Text = CType(Me.ComboBox4.DataSource, DataTable).Rows(Me.ComboBox4.SelectedIndex)("Descripcioncable")
        Me.TextBox53.Text = CType(Me.ComboBox4.DataSource, DataTable).Rows(Me.ComboBox4.SelectedIndex)("CodigoCableHem")
        Me.TextBox60.Text = CType(Me.ComboBox4.DataSource, DataTable).Rows(Me.ComboBox4.SelectedIndex)("TcableHembra")
        Me.TextBox61.Text = CType(Me.ComboBox4.DataSource, DataTable).Rows(Me.ComboBox4.SelectedIndex)("DescripcionTS")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Para comunicacion entre formulario padre e hijo
        Dim frm As New Form12
        AddOwnedForm(frm)
        frm.TextBox1.Text = TextBox4.Text
        frm.TextBox2.Text = TextBox5.Text
        frm.TextBox3.Text = TextBox1.Text
        frm.TextBox4.Text = TextBox2.Text
        frm.TextBox5.Text = TextBox3.Text
        frm.TextBox6.Text = TextBox7.Text
        frm.TextBox7.Text = TextBox8.Text
        frm.TextBox8.Text = TextBox9.Text
        frm.TextBox9.Text = TextBox10.Text
        frm.TextBox10.Text = TextBox11.Text
        frm.TextBox11.Text = TextBox12.Text
        frm.TextBox12.Text = TextBox17.Text
        frm.TextBox13.Text = TextBox26.Text
        frm.ShowDialog()


    End Sub


#Region "PARA EXPORTAR A PLANILLA DE PROFORMA INVOICE MUSHROOM Y TUBOS"
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim xlibro As Microsoft.Office.Interop.Excel.Application
        Dim strRutaExcel As String

        strRutaExcel = "C:\SOURCESAFRATEC\PROFORMA INVOICE szAMB.xlsm"

        xlibro = CreateObject("Excel.Application")
        xlibro.Workbooks.Open(strRutaExcel)

        'Activamos el libro
        xlibro.Workbooks("PROFORMA INVOICE szAMB.xlsm").Activate()
        'Activamos la hoja especifica del libro  
        xlibro.Sheets("Quoting Request").Select()

        Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = xlibro.Sheets.Item("Quoting Request")
        xlibro.Visible = True

        'Ahora podemos llevar el contenido de un textbox a una celda de excel expecifica copn la siguiente instrucción

        xlibro.Range("D6").Value = TxtFecha.Text 'Para fecha de Proforma
        xlibro.Range("D7").Value = "N#  " + TxtCot.Text + Txtcot2.Text + Txtcot3.Text '# de Cotizacion
        xlibro.Range("D5").Value = TxtReferencia.Text 'Referencia del cliente

        '''' Para primera linea activa de Materiales
        xlibro.Range("C15").Value = ComboBox4.Text 'modelo de Luminaria segun codigo
        xlibro.Range("D15").Value = TextBox50.Text 'Para descripcion de la luminaria
        xlibro.Range("F15").Value = "PCS"
        xlibro.Range("G15").Value = TextBox17.Text
        '''' Para segunda Linea
        xlibro.Range("C16").Value = TextBox53.Text + " " + TextBox39.Text + " " + "meters long" 'Para tipo de Cable segun el tamaño
        xlibro.Range("D16").Value = TextBox60.Text + " " + TextBox39.Text + " " + "meters long"
        xlibro.Range("F16").Value = "PCS"
        xlibro.Range("G16").Value = 1
        ''''Para tercera linea 
        xlibro.Range("C17").Value = TextBox46.Text + " " + TextBox33.Text + " " + "meters long" 'Para cantidad de cable entre lamparas
        xlibro.Range("D17").Value = TextBox58.Text + " " + TextBox33.Text + " " + "meters long"
        xlibro.Range("F17").Value = "PCS"
        xlibro.Range("G17").Value = TextBox34.Text
        ''''Para Cuarta linea
        xlibro.Range("C18").Value = TextBox46.Text + " " + TextBox37.Text + " " + "meters long" 'Para cantidad
        xlibro.Range("D18").Value = TextBox58.Text + " " + TextBox37.Text + " " + "meters long"
        xlibro.Range("F18").Value = "PCS"
        xlibro.Range("G18").Value = TextBox36.Text
        ''''Para Quinta linea
        xlibro.Range("C19").Value = TextBox46.Text + " " + TextBox35.Text + " " + "meters Long" 'Para tipo de cable
        xlibro.Range("D19").Value = TextBox58.Text + " " + TextBox35.Text + " " + "meters long"
        xlibro.Range("F19").Value = "PCS"
        xlibro.Range("G19").Value = TextBox32.Text
        ''''Para sexta linea
        xlibro.Range("C20").Value = TextBox62.Text + " " + TextBox38.Text + " " + "meters Long"
        xlibro.Range("D20").Value = TextBox59.Text + " " + TextBox38.Text + " " + "meters Long"
        xlibro.Range("F20").Value = "PCS"
        xlibro.Range("G20").Value = 2
        ''''Para Septima linea
        xlibro.Range("D21").Value = TextBox61.Text
        xlibro.Range("F21").Value = "PCS"
        xlibro.Range("G21").Value = TextBox47.Text
        ''''Octava linea
        xlibro.Range("C22").Value = ComboBox3.Text 'Tipo de Dimmer
        xlibro.Range("D22").Value = TextBox48.Text
        xlibro.Range("F22").Value = "PCS"
        xlibro.Range("G22").Value = 1
        ''''Novena linea
        xlibro.Range("C23").Value = "Shipping fee"
        xlibro.Range("D23").Value = "CIF to San Antonio Seaport"
        xlibro.Range("F23").Value = "UN"
        xlibro.Range("G23").Value = 1

        'Para agregar valores a los items
        xlibro.Range("B15").Value = 1
        xlibro.Range("B16").Value = 2
        xlibro.Range("B17").Value = 3
        xlibro.Range("B18").Value = 4
        xlibro.Range("B19").Value = 5
        xlibro.Range("B20").Value = 6
        xlibro.Range("B21").Value = 7
        xlibro.Range("B22").Value = 8
        xlibro.Range("B23").Value = 9

        'Para calculo de Precios de planilla invoice
        'xlibro.Range("H16").Value = (-0.00008 * Val(TextBox38.Text) ^ 6) + (0.0034 * Val(TextBox38.Text) ^ 5) - (0.0544 * Val(TextBox38.Text) ^ 4) + (0.4055 * Val(TextBox38.Text) ^ 3) - (1.3875 * Val(TextBox38.Text) ^ 2) + (3.9142 * (TextBox38.Text)) + 2.2294
        xlibro.Range("H16").Value = ((2.1119 * Val(TextBox38.Text)) + 2.7298) - 0.9
        xlibro.Range("H17").Value = (2.1119 * Val(TextBox33.Text)) + 2.7298
        xlibro.Range("H18").Value = (2.1119 * Val(TextBox37.Text)) + 2.7298
        xlibro.Range("H19").Value = (2.1119 * Val(TextBox35.Text)) + 2.7298
        xlibro.Range("H20").Value = 0
        xlibro.Range("H21").Value = TextBox55.Text
        xlibro.Range("H22").Value = TextBox56.Text
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim xlibro As Microsoft.Office.Interop.Excel.Application
        Dim strRutaExcel As String

        strRutaExcel = "C:\SOURCESAFRATEC\PROFORMA INVOICE szAMB.xlsm"

        xlibro = CreateObject("Excel.Application")
        xlibro.Workbooks.Open(strRutaExcel)

        'Activamos el libro
        xlibro.Workbooks("PROFORMA INVOICE szAMB.xlsm").Activate()
        'Activamos la hoja especifica del libro  
        xlibro.Sheets("Quoting Request Ts").Select()

        Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = xlibro.Sheets.Item("Quoting Request Ts")
        xlibro.Visible = True

        'Ahora podemos llevar el contenido de un textbox a una celda de excel expecifica copn la siguiente instrucción

        xlibro.Range("D6").Value = TxtFecha.Text 'Para fecha de Proforma
        xlibro.Range("D7").Value = "N#  " + TxtCot.Text + Txtcot2.Text + Txtcot3.Text '# de Cotizacion
        xlibro.Range("D5").Value = TxtReferencia.Text 'Referencia del cliente

        '''' Para primera linea activa de Materiales
        xlibro.Range("C15").Value = ComboBox4.Text 'modelo de Luminaria segun codigo
        xlibro.Range("D15").Value = TextBox50.Text 'Para descripcion de la luminaria
        xlibro.Range("F15").Value = "PCS"
        xlibro.Range("G15").Value = TextBox17.Text
        '''' Para segunda Linea
        xlibro.Range("C16").Value = TextBox53.Text + " " + TextBox39.Text + " " + "meters long" 'Para tipo de Cable segun el tamaño
        xlibro.Range("D16").Value = TextBox60.Text + " " + TextBox39.Text + " " + "meters long"
        xlibro.Range("F16").Value = "PCS"
        xlibro.Range("G16").Value = 1
        ''''Para tercera linea 
        xlibro.Range("C17").Value = TextBox46.Text + " " + TextBox33.Text + " " + "meters long" 'Para cantidad de cable entre lamparas
        xlibro.Range("D17").Value = TextBox58.Text + " " + TextBox33.Text + " " + "meters long"
        xlibro.Range("F17").Value = "PCS"
        xlibro.Range("G17").Value = TextBox34.Text
        ''''Para Cuarta linea
        xlibro.Range("C18").Value = TextBox46.Text + " " + TextBox37.Text + " " + "meters long" 'Para cantidad
        xlibro.Range("D18").Value = TextBox58.Text + " " + TextBox37.Text + " " + "meters long"
        xlibro.Range("F18").Value = "PCS"
        xlibro.Range("G18").Value = TextBox36.Text
        ''''Para Quinta linea
        xlibro.Range("C19").Value = TextBox46.Text + " " + TextBox35.Text + " " + "meters Long" 'Para tipo de cable
        xlibro.Range("D19").Value = TextBox58.Text + " " + TextBox35.Text + " " + "meters long"
        xlibro.Range("F19").Value = "PCS"
        xlibro.Range("G19").Value = TextBox32.Text
        ''''Para sexta linea
        xlibro.Range("C20").Value = TextBox62.Text + " " + TextBox38.Text + " " + "meters Long"
        xlibro.Range("D20").Value = TextBox59.Text + " " + TextBox38.Text + " " + "meters Long"
        xlibro.Range("F20").Value = "PCS"
        xlibro.Range("G20").Value = 2
        ''''Para Septima linea
        xlibro.Range("D21").Value = TextBox61.Text
        xlibro.Range("F21").Value = "PCS"
        xlibro.Range("G21").Value = TextBox47.Text
        ''''Octava linea
        xlibro.Range("C22").Value = ComboBox3.Text 'Tipo de Dimmer
        xlibro.Range("D22").Value = TextBox48.Text
        xlibro.Range("F22").Value = "PCS"
        xlibro.Range("G22").Value = 1
        ''''Novena linea
        xlibro.Range("C23").Value = "Shipping fee"
        xlibro.Range("D23").Value = "CIF to San Antonio Seaport"
        xlibro.Range("F23").Value = "UN"
        xlibro.Range("G23").Value = 1

        'Para agregar valores a los items
        xlibro.Range("B15").Value = 1
        xlibro.Range("B16").Value = 2
        xlibro.Range("B17").Value = 3
        xlibro.Range("B18").Value = 4
        xlibro.Range("B19").Value = 5
        xlibro.Range("B20").Value = 6
        xlibro.Range("B21").Value = 7
        xlibro.Range("B22").Value = 8
        xlibro.Range("B23").Value = 9

        'Para calculo de Precios de planilla invoice
        'xlibro.Range("H16").Value = (-0.00008 * Val(TextBox38.Text) ^ 6) + (0.0034 * Val(TextBox38.Text) ^ 5) - (0.0544 * Val(TextBox38.Text) ^ 4) + (0.4055 * Val(TextBox38.Text) ^ 3) - (1.3875 * Val(TextBox38.Text) ^ 2) + (3.9142 * (TextBox38.Text)) + 2.2294
        xlibro.Range("H16").Value = ((2.1119 * Val(TextBox38.Text)) + 2.7298) - 0.9
        xlibro.Range("H17").Value = (2.1119 * Val(TextBox33.Text)) + 2.7298
        xlibro.Range("H18").Value = (2.1119 * Val(TextBox37.Text)) + 2.7298
        xlibro.Range("H19").Value = (2.1119 * Val(TextBox35.Text)) + 2.7298
        xlibro.Range("H20").Value = 0
        xlibro.Range("H21").Value = TextBox55.Text
        xlibro.Range("H22").Value = TextBox56.Text
    End Sub

#End Region
    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        Me.TextBox48.Text = CType(Me.ComboBox3.DataSource, DataTable).Rows(Me.ComboBox3.SelectedIndex)("Descripcion")
        Me.TextBox56.Text = CType(Me.ComboBox3.DataSource, DataTable).Rows(Me.ComboBox3.SelectedIndex)("Precio")


    End Sub

#Region "Para Exportar a la Planilla de Iluminacion  Planilla iluminacion LED szAMB.xlsm"
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim xlibro As Microsoft.Office.Interop.Excel.Application
        Dim strRutaExcel As String

        strRutaExcel = "C:\SOURCESAFRATEC\Planilla iluminacion LED szAMB.xlsm"

        xlibro = CreateObject("Excel.Application")
        xlibro.Workbooks.Open(strRutaExcel)

        'Activamos el libro
        xlibro.Workbooks("Planilla iluminacion LED szAMB.xlsm").Activate()
        'Activamos la hoja especifica del libro  
        xlibro.Sheets("Mushroom (5w+10w)").Select()

        Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = xlibro.Sheets.Item("Mushroom (5w+10w)")
        xlibro.Visible = True

        'Ahora podemos llevar el contenido de un textbox a una celda de excel expecifica copn la siguiente instrucción
        xlibro.Range("D9").Value = TxtRazon.Text 'Razon social
        xlibro.Range("D10").Value = TxtAtencion.Text 'Atencion
        xlibro.Range("D11").Value = TxtRut.Text 'RUT
        xlibro.Range("D12").Value = TxtDireccion.Text 'Direccion 
        xlibro.Range("D13").Value = TxtphoneC.Text 'Telefono cliente
        xlibro.Range("D14").Value = TxtCorreoC.Text ' Correo de Cliente

        xlibro.Range("I8").Value = "N#  " + TxtCot.Text + Txtcot2.Text + Txtcot3.Text '# de Cotizacion
        xlibro.Range("J10").Value = TxtFecha.Text ' Fecha del Dia

        xlibro.Range("J11").Value = CboContacto.Text 'Vendedor
        xlibro.Range("J12").Value = TxtCorreoV.Text 'Correo de Vendedor
        xlibro.Range("J13").Value = TxtWeb.Text 'Pagina web
        xlibro.Range("J14").Value = TxtphoneV.Text 'Telefono vendedor

        xlibro.Range("G69").Value = TxtReferencia.Text 'Referencia 

        'Para agregar Datos de formulario szAMB
        xlibro.Range("E73").Value = TextBox5.Text + " mts" 'Largo del Galpon
        xlibro.Range("E74").Value = TextBox4.Text + " mts" 'Ancho del Galpon
        xlibro.Range("E75").Value = TextBox1.Text + " mts" 'Altura al Hombro
        xlibro.Range("E76").Value = TextBox2.Text + " mts" 'Altura a la Cumbrera
        xlibro.Range("E77").Value = TextBox3.Text + " mts" 'Altura a la Cercha
        xlibro.Range("E78").Value = ComboBox5.Text  'opcion si hay cilelo razo (si/no)
        xlibro.Range("E79").Value = TextBox12.Text + " mts" 'Distancia entra las cerchas
        xlibro.Range("E80").Value = TextBox13.Text 'tipo material de la cercha
        xlibro.Range("E81").Value = TextBox14.Text 'material del piso
        xlibro.Range("E82").Value = TextBox15.Text 'material de la pared
        xlibro.Range("E83").Value = TextBox16.Text 'material del techo

        xlibro.Range("E87").Value = TextBox17.Text 'Cantidad de luminarias
        xlibro.Range("E88").Value = TextBox18.Text ' cantidad Transversal
        xlibro.Range("E89").Value = TextBox19.Text 'Cantidad Longitud
        xlibro.Range("E90").Value = TextBox26.Text 'Objetivo de Iluminacion

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim xlibro As Microsoft.Office.Interop.Excel.Application
        Dim strRutaExcel As String

        strRutaExcel = "C:\SOURCESAFRATEC\Planilla iluminacion LED szAMB.xlsm"

        xlibro = CreateObject("Excel.Application")
        xlibro.Workbooks.Open(strRutaExcel)

        'Activamos el libro
        xlibro.Workbooks("Planilla iluminacion LED szAMB.xlsm").Activate()
        'Activamos la hoja especifica del libro  
        xlibro.Sheets("Mushroom (5w+10w) Acc (2)").Select()

        Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = xlibro.Sheets.Item("Mushroom (5w+10w) Acc (2)")
        xlibro.Visible = True

        'Ahora podemos llevar el contenido de un textbox a una celda de excel expecifica copn la siguiente instrucción
        xlibro.Range("D9").Value = TxtRazon.Text 'Razon social
        xlibro.Range("D10").Value = TxtAtencion.Text 'Atencion
        xlibro.Range("D11").Value = TxtRut.Text 'RUT
        xlibro.Range("D12").Value = TxtDireccion.Text 'Direccion 
        xlibro.Range("D13").Value = TxtphoneC.Text 'Telefono cliente
        xlibro.Range("D14").Value = TxtCorreoC.Text ' Correo de Cliente

        xlibro.Range("I8").Value = "N#  " + TxtCot.Text + Txtcot2.Text + Txtcot3.Text '# de Cotizacion
        xlibro.Range("J10").Value = TxtFecha.Text ' Fecha del Dia

        xlibro.Range("J11").Value = CboContacto.Text 'Vendedor
        xlibro.Range("J12").Value = TxtCorreoV.Text 'Correo de Vendedor
        xlibro.Range("J13").Value = TxtWeb.Text 'Pagina web
        xlibro.Range("J14").Value = TxtphoneV.Text 'Telefono vendedor

        xlibro.Range("G69").Value = TxtReferencia.Text 'Referencia 

        'Para agregar Datos de formulario szAMB
        xlibro.Range("E73").Value = TextBox5.Text + " mts" 'Largo del Galpon
        xlibro.Range("E74").Value = TextBox4.Text + " mts" 'Ancho del Galpon
        xlibro.Range("E75").Value = TextBox1.Text + " mts" 'Altura al Hombro
        xlibro.Range("E76").Value = TextBox2.Text + " mts" 'Altura a la Cumbrera
        xlibro.Range("E77").Value = TextBox3.Text + " mts" 'Altura a la Cercha
        xlibro.Range("E78").Value = ComboBox5.Text  'opcion si hay cielo razo (si/no)
        xlibro.Range("E79").Value = TextBox7.Text + " mts" 'Cantidad de Pasillos
        xlibro.Range("E80").Value = TextBox8.Text + " mts" 'Ancho de Pasillo
        xlibro.Range("E81").Value = TextBox9.Text 'Cantidad de Baterias
        xlibro.Range("E82").Value = TextBox10.Text + " mts" 'Altura de Bateria
        xlibro.Range("E83").Value = TextBox11.Text + " mts" 'Ancho de Bateria
        xlibro.Range("E84").Value = TextBox12.Text + " mts" 'Distancia entre Cerchas
        xlibro.Range("E85").Value = TextBox13.Text 'Material de la cercha
        xlibro.Range("E86").Value = TextBox14.Text 'Material del piso
        xlibro.Range("E87").Value = TextBox15.Text 'Material de la Pared
        xlibro.Range("E88").Value = TextBox16.Text 'Material del techo

        xlibro.Range("E92").Value = TextBox17.Text 'Cantidad de luminarias
        xlibro.Range("E93").Value = TextBox18.Text ' cantidad Transversal
        xlibro.Range("E94").Value = TextBox19.Text 'Cantidad Longitud
        xlibro.Range("E95").Value = TextBox26.Text 'Objetivo de Iluminacion

    End Sub
#End Region
#Region "Para Guardar en BDSAFRATEC- DATAszAMBLED"
    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        'Para asegurar si esta correcto el registro
        If TxtCot.Text + Txtcot2.Text + Txtcot3.Text > "" Then
            If MessageBox.Show("¿ Seguro que desea insertar este registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then


                ' para comenzar insertar valores en la data 
                ' Verifico que haya escrito el ISBN (bueno, debería verificarlos todos, pero como esta es la clave principal...)
                If TxtCot.Text = "" Then
                    ' Si no lo escribió, mando mensaje de error
                    MsgBox("Debe incluir # Cotizacion")
                    TxtCot.Select()
                Else
                    ' Si sí lo escribió, comienza la diversión (jeje)
                    ' Armo la instrucción INSERT en la variable SQL

                    sql = O & (TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & TxtFecha.Text & "','" & TxtRazon.Text & "','" & TxtRut.Text & "','" & TxtAtencion.Text & "','" & TxtDireccion.Text & "','" & TxtphoneC.Text & "','" & TxtCorreoC.Text & "','" & CboContacto.Text & "','" & TxtphoneV.Text & "','" & TxtCorreoV.Text & "','" & TxtWeb.Text & "','" & TxtReferencia.Text & "','" & ComboBox1.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & ComboBox5.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "','" & TextBox10.Text & "','" & TextBox11.Text & "','" & TextBox12.Text & "','" & TextBox13.Text & "','" & TextBox14.Text & "','" & TextBox15.Text & "','" & TextBox16.Text & "','" & ComboBox6.Text & "','" & TextBox6.Text & "','" & TextBox42.Text & "','" & ComboBox7.Text & "','" & TextBox44.Text & "','" & TextBox43.Text & "','" & ComboBox2.Text & "','" & ComboBox4.Text & "','" & TextBox57.Text & "','" & TextBox17.Text & "','" & TextBox18.Text & "','" & TextBox19.Text & "','" & TextBox40.Text & "','" & TextBox41.Text & "','" & TextBox45.Text & "','" & TextBox20.Text & "','" & TextBox21.Text & "','" & TextBox22.Text & "','" & TextBox23.Text & "','" & TextBox24.Text & "','" & TextBox25.Text & "','" & TextBox26.Text & "','" & TextBox27.Text & "','" & TextBox28.Text & "','" & TextBox29.Text & "','" & TextBox30.Text & "','" & TextBox31.Text & "','" & TextBox46.Text & "','" & TextBox33.Text & "','" & TextBox34.Text & "','" & TextBox35.Text & "','" & TextBox47.Text & "','" & TextBox54.Text & "','" & TextBox32.Text & "','" & TextBox36.Text & "','" & TextBox37.Text & "','" & TextBox38.Text & "','" & TextBox39.Text & "','" & ComboBox3.Text & "','" & TextBox48.Text & "')"

                    ' Asigno la instrucción SQL que se va a ejecutar
                    comm.CommandText = sql

                    Try
                        comm.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(Err.Description, MsgBoxStyle.Exclamation, "TSA")
                    End Try
                End If
            End If
        End If


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub



#End Region
End Class