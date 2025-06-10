Public Class Form8

    Private Sub contenido()

        Panel1.Visible = False
    End Sub
    Public Sub MOSTRAR()
        'Para Carga de Datos de Cotizaciones 
        On Error Resume Next
        Dim sqlseguimiento8 As String = " Select distinct Cotizacion,Fecha,Atencion FROM TSADATACOTIZACION "
        Cargar_MySQLseguimiento(sqlseguimiento8, DGSeguimiento)
    End Sub


    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        contenido()
        MOSTRAR()
        'RECORDATORIO()
        Label3.Text = DGSeguimiento.RowCount.ToString()

    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Panel1.Visible = False Then
            contenido()

            Panel1.Visible = True

        Else
            Panel1.Visible = False

        End If


    End Sub

#Region "Para filtro de Edición"

    ' Declaramos un temporizador para evitar que la búsqueda se ejecute inmediatamente después de cada cambio de texto
    Private WithEvents TimerBusqueda As New Timer() With {.Interval = 500} ' 500 ms de retraso

    ' Controlador para TextBox de búsqueda única
    Private Sub TextBoxBusqueda_TextChanged(sender As Object, e As EventArgs) Handles TextBoxBusqueda.TextChanged
        ' Reiniciar el temporizador para retrasar la búsqueda
        TimerBusqueda.Stop()
        TimerBusqueda.Start()
    End Sub

    ' Evento del temporizador que se ejecuta después de que el usuario deje de escribir por un tiempo
    Private Sub TimerBusqueda_Tick(sender As Object, e As EventArgs) Handles TimerBusqueda.Tick
        ' Detener el temporizador
        TimerBusqueda.Stop()

        ' Si el TextBox está vacío, limpiar el DataGridView
        If String.IsNullOrEmpty(TextBoxBusqueda.Text) Then
            DGEdicion.DataSource = Nothing
            Exit Sub
        End If

        ' Ejecutar la búsqueda
        EjecutarBusqueda()
    End Sub

    ' Método para ejecutar la búsqueda
    Private Sub EjecutarBusqueda()
        ' Obtener el texto del TextBox
        Dim TextoBusqueda As String = TextBoxBusqueda.Text

        ' Armar la consulta buscando en múltiples columnas
        Dim sql As String = "SELECT DISTINCT Cotizacion, Fecha, Atencion FROM TSADATACOTIZACION WHERE " &
                            "Cotizacion LIKE '%" & TextoBusqueda & "%' OR " &
                            "Fecha LIKE '%" & TextoBusqueda & "%' OR " &
                            "Atencion LIKE '%" & TextoBusqueda & "%'"

        ' Ejecutar la búsqueda con la consulta construida
        Cargar_MySQLseguimiento(sql, DGEdicion)
    End Sub

#End Region


#Region "Para Mostrar otra form con el contenido completo de la cotizacion"

    Private Sub DGSeguimiento_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGSeguimiento.CellContentClick
        On Error Resume Next
        Dim fila As Integer
        fila = DGSeguimiento.CurrentRow.Index
        TxtCotizacion.Text = Me.DGSeguimiento.Item(0, fila).Value
        TxtFecha.Text = Me.DGSeguimiento.Item(1, fila).Value
        'Para busqueda en Seguimiento
        Dim Cotizacion As String = TxtCotizacion.Text.ToString
        Dim Fecha As String = TxtFecha.Text.ToString()

        Dim sqlbusqueda As String = " Select * From  TSADATACOTIZACION Where Cotizacion ='" & Cotizacion & "'and Fecha='" & Fecha & "' "

        'Para Carga de Cotizacion en nuevo formulario para la visualizacion
        Dim frm As New Form10
        AddOwnedForm(frm)

        Cargar_MySQLseguimiento(sqlbusqueda, DGSeguimiento2)

        Dim xtreme As Integer
        xtreme = DGSeguimiento2.CurrentRow.Index
        frm.TextBox1.Text = Me.DGSeguimiento2.Item(2, xtreme).Value 'Razon social
        frm.TextBox2.Text = Me.DGSeguimiento2.Item(4, xtreme).Value 'Atencion
        frm.TextBox3.Text = Me.DGSeguimiento2.Item(3, xtreme).Value 'RUT
        frm.TextBox4.Text = Me.DGSeguimiento2.Item(5, xtreme).Value 'Direccion
        frm.TextBox5.Text = Me.DGSeguimiento2.Item(6, xtreme).Value 'Telefono
        frm.TextBox6.Text = Me.DGSeguimiento2.Item(7, xtreme).Value 'Mail

        frm.TextBox7.Text = Me.DGSeguimiento2.Item(0, xtreme).Value '# Cotizacion

        frm.TextBox8.Text = Me.DGSeguimiento2.Item(1, xtreme).Value 'Fecha
        frm.TextBox9.Text = Me.DGSeguimiento2.Item(8, xtreme).Value 'Vendedor
        frm.TextBox10.Text = Me.DGSeguimiento2.Item(10, xtreme).Value 'Correo
        frm.TextBox11.Text = Me.DGSeguimiento2.Item(11, xtreme).Value 'Pagina Web
        frm.TextBox12.Text = Me.DGSeguimiento2.Item(9, xtreme).Value ' Telefono
        frm.TextBox13.Text = Me.DGSeguimiento2.Item(12, xtreme).Value 'Referencia

        frm.Label2.Text = Me.DGSeguimiento2.Item(20, xtreme).Value 'Codigo Unico ID 

        frm.TextBox122.Text = Me.DGSeguimiento2.Item(22, xtreme).Value 'OC
        frm.DateTimePicker1.Text = Me.DGSeguimiento2.Item(23, xtreme).Value 'Fecha OC
        frm.DateTimePicker42.Text = Me.DGSeguimiento2.Item(26, xtreme).Value 'Fecha de Entrega 

        frm.TextBox14.Text = Me.DGSeguimiento2.Item(13, xtreme).Value 'Descripcion de Material
        frm.TextBox15.Text = Me.DGSeguimiento2.Item(14, xtreme).Value 'Codigo de Material
        frm.TextBox16.Text = Me.DGSeguimiento2.Item(15, xtreme).Value 'Cantidad de Material
        frm.TextBox17.Text = Me.DGSeguimiento2.Item(17, xtreme).Value 'Precio de Material
        frm.TextBox18.Text = Me.DGSeguimiento2.Item(18, xtreme).Value 'Total *
        frm.Label35.Text = Me.DGSeguimiento2.Item(21, xtreme).Value 'Linea *
        frm.TextBox123.Text = Me.DGSeguimiento2.Item(24, xtreme).Value 'OC Items *
        frm.DateTimePicker2.Text = Me.DGSeguimiento2.Item(25, xtreme).Value ' Fecha OC Items *
        frm.TextBox143.Text = Me.DGSeguimiento2.Item(19, xtreme).Value 'Moneda *


        frm.TextBox19.Text = Me.DGSeguimiento2.Item(13, xtreme + 1).Value 'Descripcion de Material
        frm.TextBox20.Text = Me.DGSeguimiento2.Item(14, xtreme + 1).Value 'Codigo de Material
        frm.TextBox21.Text = Me.DGSeguimiento2.Item(15, xtreme + 1).Value 'Cantidad de Material
        frm.TextBox22.Text = Me.DGSeguimiento2.Item(17, xtreme + 1).Value 'Precio de Material
        frm.TextBox23.Text = Me.DGSeguimiento2.Item(18, xtreme + 1).Value 'Total *
        frm.Label36.Text = Me.DGSeguimiento2.Item(21, xtreme + 1).Value 'Linea *
        frm.TextBox124.Text = Me.DGSeguimiento2.Item(24, xtreme + 1).Value 'OC Items *
        frm.DateTimePicker3.Text = Me.DGSeguimiento2.Item(25, xtreme + 1).Value ' Fecha OC Items *
        frm.TextBox144.Text = Me.DGSeguimiento2.Item(19, xtreme + 1).Value 'Moneda *

        frm.TextBox24.Text = Me.DGSeguimiento2.Item(13, xtreme + 2).Value 'Descripcion de Material
        frm.TextBox25.Text = Me.DGSeguimiento2.Item(14, xtreme + 2).Value 'Codigo de Material
        frm.TextBox26.Text = Me.DGSeguimiento2.Item(15, xtreme + 2).Value 'Cantidad de Material
        frm.TextBox27.Text = Me.DGSeguimiento2.Item(17, xtreme + 2).Value 'Precio de Material
        frm.TextBox28.Text = Me.DGSeguimiento2.Item(18, xtreme + 2).Value 'Total *
        frm.Label37.Text = Me.DGSeguimiento2.Item(21, xtreme + 2).Value 'Linea *
        frm.TextBox125.Text = Me.DGSeguimiento2.Item(24, xtreme + 2).Value 'OC Items *
        frm.DateTimePicker4.Text = Me.DGSeguimiento2.Item(25, xtreme + 2).Value ' Fecha OC Items *
        frm.TextBox145.Text = Me.DGSeguimiento2.Item(19, xtreme + 2).Value 'Moneda *

        frm.TextBox29.Text = Me.DGSeguimiento2.Item(13, xtreme + 3).Value 'Descripcion de Material
        frm.TextBox30.Text = Me.DGSeguimiento2.Item(14, xtreme + 3).Value 'Codigo de Material
        frm.TextBox31.Text = Me.DGSeguimiento2.Item(15, xtreme + 3).Value 'Cantidad de Material
        frm.TextBox32.Text = Me.DGSeguimiento2.Item(17, xtreme + 3).Value 'Precio de Material
        frm.TextBox33.Text = Me.DGSeguimiento2.Item(18, xtreme + 3).Value 'Total *
        frm.Label38.Text = Me.DGSeguimiento2.Item(21, xtreme + 3).Value 'Linea *
        frm.TextBox126.Text = Me.DGSeguimiento2.Item(24, xtreme + 3).Value 'OC Items *
        frm.DateTimePicker5.Text = Me.DGSeguimiento2.Item(25, xtreme + 3).Value ' Fecha OC Items *
        frm.TextBox146.Text = Me.DGSeguimiento2.Item(19, xtreme + 3).Value 'Moneda *

        frm.TextBox34.Text = Me.DGSeguimiento2.Item(13, xtreme + 4).Value 'Descripcion de Material
        frm.TextBox35.Text = Me.DGSeguimiento2.Item(14, xtreme + 4).Value 'Codigo de Material
        frm.TextBox36.Text = Me.DGSeguimiento2.Item(15, xtreme + 4).Value 'Cantidad de Material
        frm.TextBox37.Text = Me.DGSeguimiento2.Item(17, xtreme + 4).Value 'Precio de Material
        frm.TextBox38.Text = Me.DGSeguimiento2.Item(18, xtreme + 4).Value 'Total *
        frm.Label39.Text = Me.DGSeguimiento2.Item(21, xtreme + 4).Value 'Linea *
        frm.TextBox127.Text = Me.DGSeguimiento2.Item(24, xtreme + 4).Value 'OC Items *
        frm.DateTimePicker6.Text = Me.DGSeguimiento2.Item(25, xtreme + 4).Value ' Fecha OC Items *
        frm.TextBox147.Text = Me.DGSeguimiento2.Item(19, xtreme + 4).Value 'Moneda *

        frm.TextBox39.Text = Me.DGSeguimiento2.Item(13, xtreme + 5).Value 'Descripcion de Material
        frm.TextBox40.Text = Me.DGSeguimiento2.Item(14, xtreme + 5).Value 'Codigo de Material
        frm.TextBox41.Text = Me.DGSeguimiento2.Item(15, xtreme + 5).Value 'Cantidad de Material
        frm.TextBox42.Text = Me.DGSeguimiento2.Item(17, xtreme + 5).Value 'Precio de Material
        frm.TextBox43.Text = Me.DGSeguimiento2.Item(18, xtreme + 5).Value 'Total *
        frm.Label40.Text = Me.DGSeguimiento2.Item(21, xtreme + 5).Value 'Linea *
        frm.TextBox128.Text = Me.DGSeguimiento2.Item(24, xtreme + 5).Value 'OC Items *
        frm.DateTimePicker7.Text = Me.DGSeguimiento2.Item(25, xtreme + 5).Value ' Fecha OC Items *
        frm.TextBox148.Text = Me.DGSeguimiento2.Item(19, xtreme + 5).Value 'Moneda *

        frm.TextBox44.Text = Me.DGSeguimiento2.Item(13, xtreme + 6).Value 'Descripcion de Material
        frm.TextBox45.Text = Me.DGSeguimiento2.Item(14, xtreme + 6).Value 'Codigo de Material
        frm.TextBox46.Text = Me.DGSeguimiento2.Item(15, xtreme + 6).Value 'Cantidad de Material
        frm.TextBox47.Text = Me.DGSeguimiento2.Item(17, xtreme + 6).Value 'Precio de Material
        frm.TextBox48.Text = Me.DGSeguimiento2.Item(18, xtreme + 6).Value 'Total *
        frm.Label41.Text = Me.DGSeguimiento2.Item(21, xtreme + 6).Value 'Linea *
        frm.TextBox129.Text = Me.DGSeguimiento2.Item(24, xtreme + 6).Value 'OC Items *
        frm.DateTimePicker8.Text = Me.DGSeguimiento2.Item(25, xtreme + 6).Value ' Fecha OC Items *
        frm.TextBox149.Text = Me.DGSeguimiento2.Item(19, xtreme + 6).Value 'Moneda *

        frm.TextBox49.Text = Me.DGSeguimiento2.Item(13, xtreme + 7).Value 'Descripcion de Material
        frm.TextBox50.Text = Me.DGSeguimiento2.Item(14, xtreme + 7).Value 'Codigo de Material
        frm.TextBox51.Text = Me.DGSeguimiento2.Item(15, xtreme + 7).Value 'Cantidad de Material
        frm.TextBox52.Text = Me.DGSeguimiento2.Item(17, xtreme + 7).Value 'Precio de Material
        frm.TextBox53.Text = Me.DGSeguimiento2.Item(18, xtreme + 7).Value 'Total *
        frm.Label42.Text = Me.DGSeguimiento2.Item(21, xtreme + 7).Value 'Linea *
        frm.TextBox130.Text = Me.DGSeguimiento2.Item(24, xtreme + 7).Value 'OC Items *
        frm.DateTimePicker9.Text = Me.DGSeguimiento2.Item(25, xtreme + 7).Value ' Fecha OC Items *
        frm.TextBox150.Text = Me.DGSeguimiento2.Item(19, xtreme + 7).Value 'Moneda *

        frm.TextBox54.Text = Me.DGSeguimiento2.Item(13, xtreme + 8).Value 'Descripcion de Material
        frm.TextBox55.Text = Me.DGSeguimiento2.Item(14, xtreme + 8).Value 'Codigo de Material
        frm.TextBox56.Text = Me.DGSeguimiento2.Item(15, xtreme + 8).Value 'Cantidad de Material
        frm.TextBox57.Text = Me.DGSeguimiento2.Item(17, xtreme + 8).Value 'Precio de Material
        frm.TextBox58.Text = Me.DGSeguimiento2.Item(18, xtreme + 8).Value 'Total *
        frm.Label43.Text = Me.DGSeguimiento2.Item(21, xtreme + 8).Value 'Linea *
        frm.TextBox131.Text = Me.DGSeguimiento2.Item(24, xtreme + 8).Value 'OC Items *
        frm.DateTimePicker10.Text = Me.DGSeguimiento2.Item(25, xtreme + 8).Value ' Fecha OC Items *
        frm.TextBox151.Text = Me.DGSeguimiento2.Item(19, xtreme + 8).Value 'Moneda *

        frm.TextBox59.Text = Me.DGSeguimiento2.Item(13, xtreme + 9).Value 'Descripcion de Material
        frm.TextBox60.Text = Me.DGSeguimiento2.Item(14, xtreme + 9).Value 'Codigo de Material
        frm.TextBox61.Text = Me.DGSeguimiento2.Item(15, xtreme + 9).Value 'Cantidad de Material
        frm.TextBox62.Text = Me.DGSeguimiento2.Item(17, xtreme + 9).Value 'Precio de Material
        frm.TextBox63.Text = Me.DGSeguimiento2.Item(18, xtreme + 9).Value 'Total *
        frm.Label44.Text = Me.DGSeguimiento2.Item(21, xtreme + 9).Value 'Linea *
        frm.TextBox132.Text = Me.DGSeguimiento2.Item(24, xtreme + 9).Value 'OC Items *
        frm.DateTimePicker11.Text = Me.DGSeguimiento2.Item(25, xtreme + 9).Value ' Fecha OC Items *
        frm.TextBox152.Text = Me.DGSeguimiento2.Item(19, xtreme + 9).Value 'Moneda *

        frm.TextBox64.Text = Me.DGSeguimiento2.Item(13, xtreme + 10).Value 'Descripcion de Material
        frm.TextBox65.Text = Me.DGSeguimiento2.Item(14, xtreme + 10).Value 'Codigo de Material
        frm.TextBox66.Text = Me.DGSeguimiento2.Item(15, xtreme + 10).Value 'Cantidad de Material
        frm.TextBox67.Text = Me.DGSeguimiento2.Item(17, xtreme + 10).Value 'Precio de Material
        frm.TextBox68.Text = Me.DGSeguimiento2.Item(18, xtreme + 10).Value 'Total *
        frm.Label45.Text = Me.DGSeguimiento2.Item(21, xtreme + 10).Value 'Linea *
        frm.TextBox133.Text = Me.DGSeguimiento2.Item(24, xtreme + 10).Value 'OC Items *
        frm.DateTimePicker12.Text = Me.DGSeguimiento2.Item(25, xtreme + 10).Value ' Fecha OC Items *
        frm.TextBox153.Text = Me.DGSeguimiento2.Item(19, xtreme + 10).Value 'Moneda *

        frm.TextBox69.Text = Me.DGSeguimiento2.Item(13, xtreme + 11).Value 'Descripcion de Material
        frm.TextBox70.Text = Me.DGSeguimiento2.Item(14, xtreme + 11).Value 'Codigo de Material
        frm.TextBox71.Text = Me.DGSeguimiento2.Item(15, xtreme + 11).Value 'Cantidad de Material
        frm.TextBox72.Text = Me.DGSeguimiento2.Item(17, xtreme + 11).Value 'Precio de Material
        frm.TextBox73.Text = Me.DGSeguimiento2.Item(18, xtreme + 11).Value 'Total *
        frm.Label46.Text = Me.DGSeguimiento2.Item(21, xtreme + 11).Value 'Linea *
        frm.TextBox134.Text = Me.DGSeguimiento2.Item(24, xtreme + 11).Value 'OC Items *
        frm.DateTimePicker13.Text = Me.DGSeguimiento2.Item(25, xtreme + 11).Value ' Fecha OC Items *
        frm.TextBox154.Text = Me.DGSeguimiento2.Item(19, xtreme + 11).Value 'Moneda *

        frm.TextBox74.Text = Me.DGSeguimiento2.Item(13, xtreme + 12).Value 'Descripcion de Material
        frm.TextBox75.Text = Me.DGSeguimiento2.Item(14, xtreme + 12).Value 'Codigo de Material
        frm.TextBox76.Text = Me.DGSeguimiento2.Item(15, xtreme + 12).Value 'Cantidad de Material
        frm.TextBox77.Text = Me.DGSeguimiento2.Item(17, xtreme + 12).Value 'Precio de Material
        frm.TextBox78.Text = Me.DGSeguimiento2.Item(18, xtreme + 12).Value 'Total *
        frm.Label47.Text = Me.DGSeguimiento2.Item(21, xtreme + 12).Value 'Linea *
        frm.TextBox135.Text = Me.DGSeguimiento2.Item(24, xtreme + 12).Value 'OC Items *
        frm.DateTimePicker14.Text = Me.DGSeguimiento2.Item(25, xtreme + 12).Value ' Fecha OC Items *
        frm.TextBox155.Text = Me.DGSeguimiento2.Item(19, xtreme + 12).Value 'Moneda *

        frm.TextBox79.Text = Me.DGSeguimiento2.Item(13, xtreme + 13).Value 'Descripcion de Material
        frm.TextBox80.Text = Me.DGSeguimiento2.Item(14, xtreme + 13).Value 'Codigo de Material
        frm.TextBox81.Text = Me.DGSeguimiento2.Item(15, xtreme + 13).Value 'Cantidad de Material
        frm.TextBox82.Text = Me.DGSeguimiento2.Item(17, xtreme + 13).Value 'Precio de Material
        frm.TextBox83.Text = Me.DGSeguimiento2.Item(18, xtreme + 13).Value 'Total *
        frm.Label48.Text = Me.DGSeguimiento2.Item(21, xtreme + 13).Value 'Linea
        frm.TextBox136.Text = Me.DGSeguimiento2.Item(24, xtreme + 13).Value 'OC Items *
        frm.DateTimePicker15.Text = Me.DGSeguimiento2.Item(25, xtreme + 13).Value ' Fecha OC Items
        frm.TextBox156.Text = Me.DGSeguimiento2.Item(19, xtreme + 13).Value 'Moneda

        frm.TextBox84.Text = Me.DGSeguimiento2.Item(13, xtreme + 14).Value 'Descripcion de Material
        frm.TextBox85.Text = Me.DGSeguimiento2.Item(14, xtreme + 14).Value 'Codigo de Material
        frm.TextBox86.Text = Me.DGSeguimiento2.Item(15, xtreme + 14).Value 'Cantidad de Material
        frm.TextBox87.Text = Me.DGSeguimiento2.Item(17, xtreme + 14).Value 'Precio de Material
        frm.TextBox88.Text = Me.DGSeguimiento2.Item(18, xtreme + 14).Value 'Total *
        frm.Label49.Text = Me.DGSeguimiento2.Item(21, xtreme + 14).Value 'Linea
        frm.TextBox137.Text = Me.DGSeguimiento2.Item(24, xtreme + 14).Value 'OC Items *
        frm.DateTimePicker16.Text = Me.DGSeguimiento2.Item(25, xtreme + 14).Value ' Fecha OC Items
        frm.TextBox157.Text = Me.DGSeguimiento2.Item(19, xtreme + 14).Value 'Moneda

        frm.TextBox89.Text = Me.DGSeguimiento2.Item(13, xtreme + 15).Value 'Descripcion de Material
        frm.TextBox90.Text = Me.DGSeguimiento2.Item(14, xtreme + 15).Value 'Codigo de Material
        frm.TextBox91.Text = Me.DGSeguimiento2.Item(15, xtreme + 15).Value 'Cantidad de Material
        frm.TextBox92.Text = Me.DGSeguimiento2.Item(17, xtreme + 15).Value 'Precio de Material
        frm.TextBox93.Text = Me.DGSeguimiento2.Item(18, xtreme + 15).Value 'Total *
        frm.Label50.Text = Me.DGSeguimiento2.Item(21, xtreme + 15).Value 'Linea
        frm.TextBox138.Text = Me.DGSeguimiento2.Item(24, xtreme + 15).Value 'OC Items *
        frm.DateTimePicker17.Text = Me.DGSeguimiento2.Item(25, xtreme + 15).Value ' Fecha OC Items
        frm.TextBox158.Text = Me.DGSeguimiento2.Item(19, xtreme + 15).Value 'Moneda

        frm.TextBox94.Text = Me.DGSeguimiento2.Item(13, xtreme + 16).Value 'Descripcion de Material
        frm.TextBox95.Text = Me.DGSeguimiento2.Item(14, xtreme + 16).Value 'Codigo de Material
        frm.TextBox96.Text = Me.DGSeguimiento2.Item(15, xtreme + 16).Value 'Cantidad de Material
        frm.TextBox97.Text = Me.DGSeguimiento2.Item(17, xtreme + 16).Value 'Precio de Material
        frm.TextBox98.Text = Me.DGSeguimiento2.Item(18, xtreme + 16).Value 'Total *
        frm.Label51.Text = Me.DGSeguimiento2.Item(21, xtreme + 16).Value 'Linea
        frm.TextBox139.Text = Me.DGSeguimiento2.Item(24, xtreme + 16).Value 'OC Items *
        frm.DateTimePicker18.Text = Me.DGSeguimiento2.Item(25, xtreme + 16).Value ' Fecha OC Items
        frm.TextBox159.Text = Me.DGSeguimiento2.Item(19, xtreme + 16).Value 'Moneda

        frm.TextBox99.Text = Me.DGSeguimiento2.Item(13, xtreme + 17).Value 'Descripcion de Material
        frm.TextBox100.Text = Me.DGSeguimiento2.Item(14, xtreme + 17).Value 'Codigo de Material
        frm.TextBox101.Text = Me.DGSeguimiento2.Item(15, xtreme + 17).Value 'Cantidad de Material
        frm.TextBox102.Text = Me.DGSeguimiento2.Item(17, xtreme + 17).Value 'Precio de Material
        frm.TextBox103.Text = Me.DGSeguimiento2.Item(18, xtreme + 17).Value 'Total *
        frm.Label52.Text = Me.DGSeguimiento2.Item(21, xtreme + 17).Value 'Linea
        frm.TextBox140.Text = Me.DGSeguimiento2.Item(24, xtreme + 17).Value 'OC Items *
        frm.DateTimePicker19.Text = Me.DGSeguimiento2.Item(25, xtreme + 17).Value ' Fecha OC Items
        frm.TextBox160.Text = Me.DGSeguimiento2.Item(19, xtreme + 17).Value 'Moneda

        frm.TextBox104.Text = Me.DGSeguimiento2.Item(13, xtreme + 18).Value 'Descripcion de Material
        frm.TextBox105.Text = Me.DGSeguimiento2.Item(14, xtreme + 18).Value 'Codigo de Material
        frm.TextBox106.Text = Me.DGSeguimiento2.Item(15, xtreme + 18).Value 'Cantidad de Material
        frm.TextBox107.Text = Me.DGSeguimiento2.Item(17, xtreme + 18).Value 'Precio de Material
        frm.TextBox108.Text = Me.DGSeguimiento2.Item(18, xtreme + 18).Value 'Total *
        frm.Label53.Text = Me.DGSeguimiento2.Item(21, xtreme + 18).Value 'Linea
        frm.TextBox141.Text = Me.DGSeguimiento2.Item(24, xtreme + 18).Value 'OC Items *
        frm.DateTimePicker20.Text = Me.DGSeguimiento2.Item(25, xtreme + 18).Value ' Fecha OC Items
        frm.TextBox161.Text = Me.DGSeguimiento2.Item(19, xtreme + 18).Value 'Moneda

        frm.TextBox109.Text = Me.DGSeguimiento2.Item(13, xtreme + 19).Value 'Descripcion de Material
        frm.TextBox110.Text = Me.DGSeguimiento2.Item(14, xtreme + 19).Value 'Codigo de Material
        frm.TextBox111.Text = Me.DGSeguimiento2.Item(15, xtreme + 19).Value 'Cantidad de Material
        frm.TextBox112.Text = Me.DGSeguimiento2.Item(17, xtreme + 19).Value 'Precio de Material
        frm.TextBox113.Text = Me.DGSeguimiento2.Item(18, xtreme + 19).Value 'Total *
        frm.Label54.Text = Me.DGSeguimiento2.Item(21, xtreme + 19).Value 'Linea
        frm.TextBox142.Text = Me.DGSeguimiento2.Item(24, xtreme + 19).Value 'OC Items *
        frm.DateTimePicker21.Text = Me.DGSeguimiento2.Item(25, xtreme + 19).Value ' Fecha OC Items
        frm.TextBox162.Text = Me.DGSeguimiento2.Item(19, xtreme + 19).Value 'Moneda


        frm.Button1.Visible = False
        frm.Button2.Visible = False
        frm.Button4.Visible = False
        frm.Button5.Visible = False

        ' Verificar que la celda seleccionada es válida
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            ' Cargar el valor de la celda en el TextBox143
            frm.TextBox143.Text = DGSeguimiento2.Rows(e.RowIndex).Cells("Moneda").Value.ToString()
            ' Mostrar el botón según el valor del TextBox143
            Select Case frm.TextBox143.Text.Trim().ToUpper()
                Case "CLP"
                    frm.BtnExpClp.Visible = True
                Case "USD"
                    frm.BtnExpUSD.Visible = True
                Case "EUR"
                    frm.BtnExpEUR.Visible = True
            End Select
        End If
        frm.ShowDialog()

    End Sub

    Private Sub DGEdicion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGEdicion.CellContentClick
        On Error Resume Next
        Dim fila As Integer
        fila = DGEdicion.CurrentRow.Index
        TxtCotizacion.Text = Me.DGEdicion.Item(0, fila).Value
        TxtFecha.Text = Me.DGEdicion.Item(1, fila).Value

        'Para busqueda en Seguimiento
        Dim Cotizacion As String = TxtCotizacion.Text.ToString
        Dim Fecha As String = TxtFecha.Text.ToString
        Dim sqlbusqueda2 As String = " Select * From  TSADATACOTIZACION Where Cotizacion ='" & Cotizacion & "'and Fecha='" & Fecha & "' "

        'Para Carga de Cotizacion en nuevo formulario para la visualizacion
        Dim frm As New Form10
        AddOwnedForm(frm)

        Cargar_MySQLseguimiento(sqlbusqueda2, DGSeguimiento2)

        Dim xtreme As Integer
        xtreme = DGSeguimiento2.CurrentRow.Index
        frm.TextBox1.Text = Me.DGSeguimiento2.Item(2, xtreme).Value 'Razon social
        frm.TextBox2.Text = Me.DGSeguimiento2.Item(4, xtreme).Value 'Atencion
        frm.TextBox3.Text = Me.DGSeguimiento2.Item(3, xtreme).Value 'RUT
        frm.TextBox4.Text = Me.DGSeguimiento2.Item(5, xtreme).Value 'Direccion
        frm.TextBox5.Text = Me.DGSeguimiento2.Item(6, xtreme).Value 'Telefono
        frm.TextBox6.Text = Me.DGSeguimiento2.Item(7, xtreme).Value 'Mail

        frm.TextBox7.Text = Me.DGSeguimiento2.Item(0, xtreme).Value '# Cotizacion

        frm.TextBox8.Text = Me.DGSeguimiento2.Item(1, xtreme).Value 'Fecha
        frm.TextBox9.Text = Me.DGSeguimiento2.Item(8, xtreme).Value 'Vendedor
        frm.TextBox10.Text = Me.DGSeguimiento2.Item(10, xtreme).Value 'Correo
        frm.TextBox11.Text = Me.DGSeguimiento2.Item(11, xtreme).Value 'Pagina Web
        frm.TextBox12.Text = Me.DGSeguimiento2.Item(9, xtreme).Value ' Telefono
        frm.TextBox13.Text = Me.DGSeguimiento2.Item(12, xtreme).Value 'Referencia

        frm.Label2.Text = Me.DGSeguimiento2.Item(20, xtreme).Value 'Codigo Unico ID 

        frm.TextBox122.Text = Me.DGSeguimiento2.Item(22, xtreme).Value 'OC
        frm.DateTimePicker1.Text = Me.DGSeguimiento2.Item(23, xtreme).Value 'Fecha OC
        frm.DateTimePicker42.Text = Me.DGSeguimiento2.Item(26, xtreme).Value 'Fecha de Entrega 

        frm.TextBox14.Text = Me.DGSeguimiento2.Item(13, xtreme).Value 'Descripcion de Material
        frm.TextBox15.Text = Me.DGSeguimiento2.Item(14, xtreme).Value 'Codigo de Material
        frm.TextBox16.Text = Me.DGSeguimiento2.Item(15, xtreme).Value 'Cantidad de Material
        frm.TextBox17.Text = Me.DGSeguimiento2.Item(17, xtreme).Value 'Precio de Material
        frm.TextBox18.Text = Me.DGSeguimiento2.Item(18, xtreme).Value 'Total *
        frm.Label35.Text = Me.DGSeguimiento2.Item(21, xtreme).Value 'Linea *
        frm.TextBox123.Text = Me.DGSeguimiento2.Item(24, xtreme).Value 'OC Items *
        frm.DateTimePicker2.Text = Me.DGSeguimiento2.Item(25, xtreme).Value ' Fecha OC Items *
        frm.TextBox143.Text = Me.DGSeguimiento2.Item(19, xtreme).Value 'Moneda *


        frm.TextBox19.Text = Me.DGSeguimiento2.Item(13, xtreme + 1).Value 'Descripcion de Material
        frm.TextBox20.Text = Me.DGSeguimiento2.Item(14, xtreme + 1).Value 'Codigo de Material
        frm.TextBox21.Text = Me.DGSeguimiento2.Item(15, xtreme + 1).Value 'Cantidad de Material
        frm.TextBox22.Text = Me.DGSeguimiento2.Item(17, xtreme + 1).Value 'Precio de Material
        frm.TextBox23.Text = Me.DGSeguimiento2.Item(18, xtreme + 1).Value 'Total *
        frm.Label36.Text = Me.DGSeguimiento2.Item(21, xtreme + 1).Value 'Linea *
        frm.TextBox124.Text = Me.DGSeguimiento2.Item(24, xtreme + 1).Value 'OC Items *
        frm.DateTimePicker3.Text = Me.DGSeguimiento2.Item(25, xtreme + 1).Value ' Fecha OC Items *
        frm.TextBox144.Text = Me.DGSeguimiento2.Item(19, xtreme + 1).Value 'Moneda *

        frm.TextBox24.Text = Me.DGSeguimiento2.Item(13, xtreme + 2).Value 'Descripcion de Material
        frm.TextBox25.Text = Me.DGSeguimiento2.Item(14, xtreme + 2).Value 'Codigo de Material
        frm.TextBox26.Text = Me.DGSeguimiento2.Item(15, xtreme + 2).Value 'Cantidad de Material
        frm.TextBox27.Text = Me.DGSeguimiento2.Item(17, xtreme + 2).Value 'Precio de Material
        frm.TextBox28.Text = Me.DGSeguimiento2.Item(18, xtreme + 2).Value 'Total *
        frm.Label37.Text = Me.DGSeguimiento2.Item(21, xtreme + 2).Value 'Linea *
        frm.TextBox125.Text = Me.DGSeguimiento2.Item(24, xtreme + 2).Value 'OC Items *
        frm.DateTimePicker4.Text = Me.DGSeguimiento2.Item(25, xtreme + 2).Value ' Fecha OC Items *
        frm.TextBox145.Text = Me.DGSeguimiento2.Item(19, xtreme + 2).Value 'Moneda *

        frm.TextBox29.Text = Me.DGSeguimiento2.Item(13, xtreme + 3).Value 'Descripcion de Material
        frm.TextBox30.Text = Me.DGSeguimiento2.Item(14, xtreme + 3).Value 'Codigo de Material
        frm.TextBox31.Text = Me.DGSeguimiento2.Item(15, xtreme + 3).Value 'Cantidad de Material
        frm.TextBox32.Text = Me.DGSeguimiento2.Item(17, xtreme + 3).Value 'Precio de Material
        frm.TextBox33.Text = Me.DGSeguimiento2.Item(18, xtreme + 3).Value 'Total *
        frm.Label38.Text = Me.DGSeguimiento2.Item(21, xtreme + 3).Value 'Linea *
        frm.TextBox126.Text = Me.DGSeguimiento2.Item(24, xtreme + 3).Value 'OC Items *
        frm.DateTimePicker5.Text = Me.DGSeguimiento2.Item(25, xtreme + 3).Value ' Fecha OC Items *
        frm.TextBox146.Text = Me.DGSeguimiento2.Item(19, xtreme + 3).Value 'Moneda *

        frm.TextBox34.Text = Me.DGSeguimiento2.Item(13, xtreme + 4).Value 'Descripcion de Material
        frm.TextBox35.Text = Me.DGSeguimiento2.Item(14, xtreme + 4).Value 'Codigo de Material
        frm.TextBox36.Text = Me.DGSeguimiento2.Item(15, xtreme + 4).Value 'Cantidad de Material
        frm.TextBox37.Text = Me.DGSeguimiento2.Item(17, xtreme + 4).Value 'Precio de Material
        frm.TextBox38.Text = Me.DGSeguimiento2.Item(18, xtreme + 4).Value 'Total *
        frm.Label39.Text = Me.DGSeguimiento2.Item(21, xtreme + 4).Value 'Linea *
        frm.TextBox127.Text = Me.DGSeguimiento2.Item(24, xtreme + 4).Value 'OC Items *
        frm.DateTimePicker6.Text = Me.DGSeguimiento2.Item(25, xtreme + 4).Value ' Fecha OC Items *
        frm.TextBox147.Text = Me.DGSeguimiento2.Item(19, xtreme + 4).Value 'Moneda *

        frm.TextBox39.Text = Me.DGSeguimiento2.Item(13, xtreme + 5).Value 'Descripcion de Material
        frm.TextBox40.Text = Me.DGSeguimiento2.Item(14, xtreme + 5).Value 'Codigo de Material
        frm.TextBox41.Text = Me.DGSeguimiento2.Item(15, xtreme + 5).Value 'Cantidad de Material
        frm.TextBox42.Text = Me.DGSeguimiento2.Item(17, xtreme + 5).Value 'Precio de Material
        frm.TextBox43.Text = Me.DGSeguimiento2.Item(18, xtreme + 5).Value 'Total *
        frm.Label40.Text = Me.DGSeguimiento2.Item(21, xtreme + 5).Value 'Linea *
        frm.TextBox128.Text = Me.DGSeguimiento2.Item(24, xtreme + 5).Value 'OC Items *
        frm.DateTimePicker7.Text = Me.DGSeguimiento2.Item(25, xtreme + 5).Value ' Fecha OC Items *
        frm.TextBox148.Text = Me.DGSeguimiento2.Item(19, xtreme + 5).Value 'Moneda *

        frm.TextBox44.Text = Me.DGSeguimiento2.Item(13, xtreme + 6).Value 'Descripcion de Material
        frm.TextBox45.Text = Me.DGSeguimiento2.Item(14, xtreme + 6).Value 'Codigo de Material
        frm.TextBox46.Text = Me.DGSeguimiento2.Item(15, xtreme + 6).Value 'Cantidad de Material
        frm.TextBox47.Text = Me.DGSeguimiento2.Item(17, xtreme + 6).Value 'Precio de Material
        frm.TextBox48.Text = Me.DGSeguimiento2.Item(18, xtreme + 6).Value 'Total *
        frm.Label41.Text = Me.DGSeguimiento2.Item(21, xtreme + 6).Value 'Linea *
        frm.TextBox129.Text = Me.DGSeguimiento2.Item(24, xtreme + 6).Value 'OC Items *
        frm.DateTimePicker8.Text = Me.DGSeguimiento2.Item(25, xtreme + 6).Value ' Fecha OC Items *
        frm.TextBox149.Text = Me.DGSeguimiento2.Item(19, xtreme + 6).Value 'Moneda *

        frm.TextBox49.Text = Me.DGSeguimiento2.Item(13, xtreme + 7).Value 'Descripcion de Material
        frm.TextBox50.Text = Me.DGSeguimiento2.Item(14, xtreme + 7).Value 'Codigo de Material
        frm.TextBox51.Text = Me.DGSeguimiento2.Item(15, xtreme + 7).Value 'Cantidad de Material
        frm.TextBox52.Text = Me.DGSeguimiento2.Item(17, xtreme + 7).Value 'Precio de Material
        frm.TextBox53.Text = Me.DGSeguimiento2.Item(18, xtreme + 7).Value 'Total *
        frm.Label42.Text = Me.DGSeguimiento2.Item(21, xtreme + 7).Value 'Linea *
        frm.TextBox130.Text = Me.DGSeguimiento2.Item(24, xtreme + 7).Value 'OC Items *
        frm.DateTimePicker9.Text = Me.DGSeguimiento2.Item(25, xtreme + 7).Value ' Fecha OC Items *
        frm.TextBox150.Text = Me.DGSeguimiento2.Item(19, xtreme + 7).Value 'Moneda *

        frm.TextBox54.Text = Me.DGSeguimiento2.Item(13, xtreme + 8).Value 'Descripcion de Material
        frm.TextBox55.Text = Me.DGSeguimiento2.Item(14, xtreme + 8).Value 'Codigo de Material
        frm.TextBox56.Text = Me.DGSeguimiento2.Item(15, xtreme + 8).Value 'Cantidad de Material
        frm.TextBox57.Text = Me.DGSeguimiento2.Item(17, xtreme + 8).Value 'Precio de Material
        frm.TextBox58.Text = Me.DGSeguimiento2.Item(18, xtreme + 8).Value 'Total *
        frm.Label43.Text = Me.DGSeguimiento2.Item(21, xtreme + 8).Value 'Linea *
        frm.TextBox131.Text = Me.DGSeguimiento2.Item(24, xtreme + 8).Value 'OC Items *
        frm.DateTimePicker10.Text = Me.DGSeguimiento2.Item(25, xtreme + 8).Value ' Fecha OC Items *
        frm.TextBox151.Text = Me.DGSeguimiento2.Item(19, xtreme + 8).Value 'Moneda *

        frm.TextBox59.Text = Me.DGSeguimiento2.Item(13, xtreme + 9).Value 'Descripcion de Material
        frm.TextBox60.Text = Me.DGSeguimiento2.Item(14, xtreme + 9).Value 'Codigo de Material
        frm.TextBox61.Text = Me.DGSeguimiento2.Item(15, xtreme + 9).Value 'Cantidad de Material
        frm.TextBox62.Text = Me.DGSeguimiento2.Item(17, xtreme + 9).Value 'Precio de Material
        frm.TextBox63.Text = Me.DGSeguimiento2.Item(18, xtreme + 9).Value 'Total *
        frm.Label44.Text = Me.DGSeguimiento2.Item(21, xtreme + 9).Value 'Linea *
        frm.TextBox132.Text = Me.DGSeguimiento2.Item(24, xtreme + 9).Value 'OC Items *
        frm.DateTimePicker11.Text = Me.DGSeguimiento2.Item(25, xtreme + 9).Value ' Fecha OC Items *
        frm.TextBox152.Text = Me.DGSeguimiento2.Item(19, xtreme + 9).Value 'Moneda *

        frm.TextBox64.Text = Me.DGSeguimiento2.Item(13, xtreme + 10).Value 'Descripcion de Material
        frm.TextBox65.Text = Me.DGSeguimiento2.Item(14, xtreme + 10).Value 'Codigo de Material
        frm.TextBox66.Text = Me.DGSeguimiento2.Item(15, xtreme + 10).Value 'Cantidad de Material
        frm.TextBox67.Text = Me.DGSeguimiento2.Item(17, xtreme + 10).Value 'Precio de Material
        frm.TextBox68.Text = Me.DGSeguimiento2.Item(18, xtreme + 10).Value 'Total *
        frm.Label45.Text = Me.DGSeguimiento2.Item(21, xtreme + 10).Value 'Linea *
        frm.TextBox133.Text = Me.DGSeguimiento2.Item(24, xtreme + 10).Value 'OC Items *
        frm.DateTimePicker12.Text = Me.DGSeguimiento2.Item(25, xtreme + 10).Value ' Fecha OC Items *
        frm.TextBox153.Text = Me.DGSeguimiento2.Item(19, xtreme + 10).Value 'Moneda *

        frm.TextBox69.Text = Me.DGSeguimiento2.Item(13, xtreme + 11).Value 'Descripcion de Material
        frm.TextBox70.Text = Me.DGSeguimiento2.Item(14, xtreme + 11).Value 'Codigo de Material
        frm.TextBox71.Text = Me.DGSeguimiento2.Item(15, xtreme + 11).Value 'Cantidad de Material
        frm.TextBox72.Text = Me.DGSeguimiento2.Item(17, xtreme + 11).Value 'Precio de Material
        frm.TextBox73.Text = Me.DGSeguimiento2.Item(18, xtreme + 11).Value 'Total *
        frm.Label46.Text = Me.DGSeguimiento2.Item(21, xtreme + 11).Value 'Linea *
        frm.TextBox134.Text = Me.DGSeguimiento2.Item(24, xtreme + 11).Value 'OC Items *
        frm.DateTimePicker13.Text = Me.DGSeguimiento2.Item(25, xtreme + 11).Value ' Fecha OC Items *
        frm.TextBox154.Text = Me.DGSeguimiento2.Item(19, xtreme + 11).Value 'Moneda *

        frm.TextBox74.Text = Me.DGSeguimiento2.Item(13, xtreme + 12).Value 'Descripcion de Material
        frm.TextBox75.Text = Me.DGSeguimiento2.Item(14, xtreme + 12).Value 'Codigo de Material
        frm.TextBox76.Text = Me.DGSeguimiento2.Item(15, xtreme + 12).Value 'Cantidad de Material
        frm.TextBox77.Text = Me.DGSeguimiento2.Item(17, xtreme + 12).Value 'Precio de Material
        frm.TextBox78.Text = Me.DGSeguimiento2.Item(18, xtreme + 12).Value 'Total *
        frm.Label47.Text = Me.DGSeguimiento2.Item(21, xtreme + 12).Value 'Linea *
        frm.TextBox135.Text = Me.DGSeguimiento2.Item(24, xtreme + 12).Value 'OC Items *
        frm.DateTimePicker14.Text = Me.DGSeguimiento2.Item(25, xtreme + 12).Value ' Fecha OC Items *
        frm.TextBox155.Text = Me.DGSeguimiento2.Item(19, xtreme + 12).Value 'Moneda *

        frm.TextBox79.Text = Me.DGSeguimiento2.Item(13, xtreme + 13).Value 'Descripcion de Material
        frm.TextBox80.Text = Me.DGSeguimiento2.Item(14, xtreme + 13).Value 'Codigo de Material
        frm.TextBox81.Text = Me.DGSeguimiento2.Item(15, xtreme + 13).Value 'Cantidad de Material
        frm.TextBox82.Text = Me.DGSeguimiento2.Item(17, xtreme + 13).Value 'Precio de Material
        frm.TextBox83.Text = Me.DGSeguimiento2.Item(18, xtreme + 13).Value 'Total *
        frm.Label48.Text = Me.DGSeguimiento2.Item(21, xtreme + 13).Value 'Linea
        frm.TextBox136.Text = Me.DGSeguimiento2.Item(24, xtreme + 13).Value 'OC Items *
        frm.DateTimePicker15.Text = Me.DGSeguimiento2.Item(25, xtreme + 13).Value ' Fecha OC Items
        frm.TextBox156.Text = Me.DGSeguimiento2.Item(19, xtreme + 13).Value 'Moneda

        frm.TextBox84.Text = Me.DGSeguimiento2.Item(13, xtreme + 14).Value 'Descripcion de Material
        frm.TextBox85.Text = Me.DGSeguimiento2.Item(14, xtreme + 14).Value 'Codigo de Material
        frm.TextBox86.Text = Me.DGSeguimiento2.Item(15, xtreme + 14).Value 'Cantidad de Material
        frm.TextBox87.Text = Me.DGSeguimiento2.Item(17, xtreme + 14).Value 'Precio de Material
        frm.TextBox88.Text = Me.DGSeguimiento2.Item(18, xtreme + 14).Value 'Total *
        frm.Label49.Text = Me.DGSeguimiento2.Item(21, xtreme + 14).Value 'Linea
        frm.TextBox137.Text = Me.DGSeguimiento2.Item(24, xtreme + 14).Value 'OC Items *
        frm.DateTimePicker16.Text = Me.DGSeguimiento2.Item(25, xtreme + 14).Value ' Fecha OC Items
        frm.TextBox157.Text = Me.DGSeguimiento2.Item(19, xtreme + 14).Value 'Moneda

        frm.TextBox89.Text = Me.DGSeguimiento2.Item(13, xtreme + 15).Value 'Descripcion de Material
        frm.TextBox90.Text = Me.DGSeguimiento2.Item(14, xtreme + 15).Value 'Codigo de Material
        frm.TextBox91.Text = Me.DGSeguimiento2.Item(15, xtreme + 15).Value 'Cantidad de Material
        frm.TextBox92.Text = Me.DGSeguimiento2.Item(17, xtreme + 15).Value 'Precio de Material
        frm.TextBox93.Text = Me.DGSeguimiento2.Item(18, xtreme + 15).Value 'Total *
        frm.Label50.Text = Me.DGSeguimiento2.Item(21, xtreme + 15).Value 'Linea
        frm.TextBox138.Text = Me.DGSeguimiento2.Item(24, xtreme + 15).Value 'OC Items *
        frm.DateTimePicker17.Text = Me.DGSeguimiento2.Item(25, xtreme + 15).Value ' Fecha OC Items
        frm.TextBox158.Text = Me.DGSeguimiento2.Item(19, xtreme + 15).Value 'Moneda

        frm.TextBox94.Text = Me.DGSeguimiento2.Item(13, xtreme + 16).Value 'Descripcion de Material
        frm.TextBox95.Text = Me.DGSeguimiento2.Item(14, xtreme + 16).Value 'Codigo de Material
        frm.TextBox96.Text = Me.DGSeguimiento2.Item(15, xtreme + 16).Value 'Cantidad de Material
        frm.TextBox97.Text = Me.DGSeguimiento2.Item(17, xtreme + 16).Value 'Precio de Material
        frm.TextBox98.Text = Me.DGSeguimiento2.Item(18, xtreme + 16).Value 'Total *
        frm.Label51.Text = Me.DGSeguimiento2.Item(21, xtreme + 16).Value 'Linea
        frm.TextBox139.Text = Me.DGSeguimiento2.Item(24, xtreme + 16).Value 'OC Items *
        frm.DateTimePicker18.Text = Me.DGSeguimiento2.Item(25, xtreme + 16).Value ' Fecha OC Items
        frm.TextBox159.Text = Me.DGSeguimiento2.Item(19, xtreme + 16).Value 'Moneda

        frm.TextBox99.Text = Me.DGSeguimiento2.Item(13, xtreme + 17).Value 'Descripcion de Material
        frm.TextBox100.Text = Me.DGSeguimiento2.Item(14, xtreme + 17).Value 'Codigo de Material
        frm.TextBox101.Text = Me.DGSeguimiento2.Item(15, xtreme + 17).Value 'Cantidad de Material
        frm.TextBox102.Text = Me.DGSeguimiento2.Item(17, xtreme + 17).Value 'Precio de Material
        frm.TextBox103.Text = Me.DGSeguimiento2.Item(18, xtreme + 17).Value 'Total *
        frm.Label52.Text = Me.DGSeguimiento2.Item(21, xtreme + 17).Value 'Linea
        frm.TextBox140.Text = Me.DGSeguimiento2.Item(24, xtreme + 17).Value 'OC Items *
        frm.DateTimePicker19.Text = Me.DGSeguimiento2.Item(25, xtreme + 17).Value ' Fecha OC Items
        frm.TextBox160.Text = Me.DGSeguimiento2.Item(19, xtreme + 17).Value 'Moneda

        frm.TextBox104.Text = Me.DGSeguimiento2.Item(13, xtreme + 18).Value 'Descripcion de Material
        frm.TextBox105.Text = Me.DGSeguimiento2.Item(14, xtreme + 18).Value 'Codigo de Material
        frm.TextBox106.Text = Me.DGSeguimiento2.Item(15, xtreme + 18).Value 'Cantidad de Material
        frm.TextBox107.Text = Me.DGSeguimiento2.Item(17, xtreme + 18).Value 'Precio de Material
        frm.TextBox108.Text = Me.DGSeguimiento2.Item(18, xtreme + 18).Value 'Total *
        frm.Label53.Text = Me.DGSeguimiento2.Item(21, xtreme + 18).Value 'Linea
        frm.TextBox141.Text = Me.DGSeguimiento2.Item(24, xtreme + 18).Value 'OC Items *
        frm.DateTimePicker20.Text = Me.DGSeguimiento2.Item(25, xtreme + 18).Value ' Fecha OC Items
        frm.TextBox161.Text = Me.DGSeguimiento2.Item(19, xtreme + 18).Value 'Moneda

        frm.TextBox109.Text = Me.DGSeguimiento2.Item(13, xtreme + 19).Value 'Descripcion de Material
        frm.TextBox110.Text = Me.DGSeguimiento2.Item(14, xtreme + 19).Value 'Codigo de Material
        frm.TextBox111.Text = Me.DGSeguimiento2.Item(15, xtreme + 19).Value 'Cantidad de Material
        frm.TextBox112.Text = Me.DGSeguimiento2.Item(17, xtreme + 19).Value 'Precio de Material
        frm.TextBox113.Text = Me.DGSeguimiento2.Item(18, xtreme + 19).Value 'Total *
        frm.Label54.Text = Me.DGSeguimiento2.Item(21, xtreme + 19).Value 'Linea
        frm.TextBox142.Text = Me.DGSeguimiento2.Item(24, xtreme + 19).Value 'OC Items *
        frm.DateTimePicker21.Text = Me.DGSeguimiento2.Item(25, xtreme + 19).Value ' Fecha OC Items
        frm.TextBox162.Text = Me.DGSeguimiento2.Item(19, xtreme + 19).Value 'Moneda

        frm.Button2.Visible = True
        frm.CheckBox21.Visible = True

        ' Verificar que la celda seleccionada es válida
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            ' Cargar el valor de la celda en el TextBox143
            frm.TextBox143.Text = DGSeguimiento2.Rows(e.RowIndex).Cells("Moneda").Value.ToString()
            ' Mostrar el botón según el valor del TextBox143
            Select Case frm.TextBox143.Text.Trim().ToUpper()
                Case "CLP"
                    frm.BtnExpClp.Visible = True
                Case "USD"
                    frm.BtnExpUSD.Visible = True
                Case "EUR"
                    frm.BtnExpEUR.Visible = True
            End Select
        End If
        HabilitarTextBox(frm)
        frm.ShowDialog()
    End Sub
#End Region
    Private Sub HabilitarTextBox(parent As Control)
        For Each ctrl As Control In parent.Controls
            If TypeOf ctrl Is TextBox Then
                DirectCast(ctrl, TextBox).ReadOnly = False
            End If
            ' Llama recursivamente si el control tiene hijos
            If ctrl.HasChildren Then
                HabilitarTextBox(ctrl)
            End If
        Next
    End Sub
End Class