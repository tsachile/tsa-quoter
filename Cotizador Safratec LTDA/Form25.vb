Imports Microsoft.Office.Interop
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Reflection.Emit

Public Class Form25
    Dim conexion As New MySqlConnection("Server = 162.144.3.49; Database = tsachile_cotizador; Uid = tsachile_admin; Pwd = 17543593apple")
#Region "Calculo de Fecha"
    Sub Calcular_Fechas()
        ':::Obtenemos las fechas en formato DATE
        ':::Observese que al final del valor despues de Value agrego ToShortDateString, esto con el fin de que me tome
        ':::Solo el valor de la fecha y me omita el valor de la hora
        Dim Fechainicio As Date = DateInicio.Value.ToShortDateString
        Dim FechaFinal As Date = DateFinal.Value.ToShortDateString

        ':::Calculamos la diferencia de dias entre las 2 fechas
        Label54.Text = DateDiff(DateInterval.Day, Fechainicio, FechaFinal)

        ':::Calculamos la diferencia de meses entre las 2 fechas
        Label53.Text = DateDiff(DateInterval.Month, Fechainicio, FechaFinal)

        ':::Calculamos la diferencia de años entre las 2 fechas
        Label52.Text = DateDiff(DateInterval.Year, Fechainicio, FechaFinal)

        ':::Calculamos la fecha inicio sumando los dias indicados
        Label51.Text = Fechainicio.AddDays(NudFechaInicio.Value)

        ':::Calculamos la fecha final restando los dias indicados, observese que le agregue un signo menos
        ':::Al valor obtenido del control NudFechaFinal
        Label50.Text = FechaFinal.AddDays(-NudFechaFinal.Value)
    End Sub
#End Region
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ' Datos de conexión
            Dim servidor As String = "162.144.3.49"
            Dim usuario As String = "tsachile_admin"
            Dim password As String = "17543593apple"
            Dim basedatos As String = "tsachile_cotizador"

            ' Conectar a MySQL
            Dim cadenaConexion As String = $"Server={servidor};Database={basedatos};Uid={usuario};Pwd={password};"
            Dim dt1 As New DataTable()
            Dim dt2 As New DataTable()
            Dim dt3 As New DataTable()

            Using conexion As New MySqlConnection(cadenaConexion)
                conexion.Open()

                ' Rellenar las tablas
                LlenarDataTable(conexion, "SELECT * FROM TSADATACOTIZACION", dt1)
                LlenarDataTable(conexion, "SELECT * FROM TSADATACOTIZACIONOK", dt2)
                LlenarDataTable(conexion, "SELECT * FROM TSADATADEFINICION", dt3)
            End Using

            ' Exportar a Excel
            ExportarMultiplesTablasAExcel(dt1, "TSADATACOTIZACION", dt2, "TSADATACOTIZACIONOK", dt3, "TSADATADEFINICION")

        Catch ex As MySqlException
            MessageBox.Show($"Error de MySQL: {ex.Message}")
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}")
        End Try
    End Sub

    ' Función para llenar un DataTable desde MySQL
    Private Sub LlenarDataTable(conexion As MySqlConnection, consulta As String, dt As DataTable)
        Using adaptador As New MySqlDataAdapter(consulta, conexion)
            adaptador.Fill(dt)
        End Using
    End Sub

    ' Exportar múltiples tablas a Excel
    Private Sub ExportarMultiplesTablasAExcel(dt1 As DataTable, nombreHoja1 As String,
                                              dt2 As DataTable, nombreHoja2 As String,
                                              dt3 As DataTable, nombreHoja3 As String)
        Dim xlApp As New Excel.Application()
        Dim xlWorkbook As Excel.Workbook = xlApp.Workbooks.Add()

        ' Exportar cada DataTable a una hoja
        ExportarAHojaExcel(xlWorkbook, dt1, nombreHoja1)
        ExportarAHojaExcel(xlWorkbook, dt2, nombreHoja2)
        ExportarAHojaExcel(xlWorkbook, dt3, nombreHoja3)

        ' Obtener ruta del escritorio del usuario
        Dim rutaEscritorio As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Dim rutaCarpeta As String = Path.Combine(rutaEscritorio, "Dashboard de Cotizaciones")

        ' Crear la carpeta si no existe
        If Not Directory.Exists(rutaCarpeta) Then
            Directory.CreateDirectory(rutaCarpeta)
        End If

        ' Ruta del archivo Excel
        Dim rutaArchivo As String = Path.Combine(rutaCarpeta, "Analisis de Cotizacion.xlsx")
        xlWorkbook.SaveAs(rutaArchivo)

        ' Limpiar y cerrar
        xlWorkbook.Close(False)
        xlApp.Quit()

        MessageBox.Show($"Exportación exitosa: {rutaArchivo}")

        ReleaseObject(xlWorkbook)
        ReleaseObject(xlApp)
    End Sub

    ' Exportar una DataTable a una hoja específica con zoom al 80%
    Private Sub ExportarAHojaExcel(xlWorkbook As Excel.Workbook, dt As DataTable, nombreHoja As String)
        ' Crear una nueva hoja
        Dim xlWorksheet As Excel.Worksheet = CType(xlWorkbook.Sheets.Add(), Excel.Worksheet)
        xlWorksheet.Name = nombreHoja

        ' Establecer el zoom al 80%
        xlWorksheet.Application.ActiveWindow.Zoom = 80

        ' Agregar encabezados
        For i As Integer = 0 To dt.Columns.Count - 1
            xlWorksheet.Cells(1, i + 1) = dt.Columns(i).ColumnName
        Next

        ' Agregar datos en bloque (mejor rendimiento)
        Dim datos(dt.Rows.Count - 1, dt.Columns.Count - 1) As Object
        For fila As Integer = 0 To dt.Rows.Count - 1
            For col As Integer = 0 To dt.Columns.Count - 1
                datos(fila, col) = dt.Rows(fila)(col)
            Next
        Next

        ' Insertar datos en un solo paso
        If dt.Rows.Count > 0 Then
            Dim rangoInicio As Excel.Range = CType(xlWorksheet.Cells(2, 1), Excel.Range)
            Dim rangoFin As Excel.Range = CType(xlWorksheet.Cells(dt.Rows.Count + 1, dt.Columns.Count), Excel.Range)
            Dim rango As Excel.Range = xlWorksheet.Range(rangoInicio, rangoFin)
            rango.Value = datos
        End If

        ' Liberar memoria
        ReleaseObject(xlWorksheet)
    End Sub

    ' Liberar objetos COM
    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            If obj IsNot Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error al liberar objeto: {ex.Message}")
        Finally
            obj = Nothing
            GC.Collect()
        End Try
    End Sub
    Sub MOSTRAR(ByVal tabla As String, ByVal dataGrid As DataGridView, ByVal tieneDefinicion As Boolean)
        Try
            ' Validar que el DataGridView no sea nulo
            If dataGrid Is Nothing Then
                MessageBox.Show("El DataGridView es nulo.")
                Exit Sub
            End If

            ' Construir columnas dinámicamente
            Dim columnasBase As String = " Distinct Cotizacion, Fecha, Razon_Social, Atencion"
            If tieneDefinicion Then
                columnasBase &= ", Definicion"
            End If

            ' Consulta principal para mostrar datos en el DataGridView
            Dim sqlSeguimiento As String = $"SELECT {columnasBase},SUM(Total) AS Total, Moneda " &
                                       $"FROM {tabla} " &
                                       $"GROUP BY Cotizacion, Moneda " &
                                       $"ORDER BY Cotizacion ASC"

            ' Cargar datos al DataGridView
            Cargar_MySQLseguimiento(sqlSeguimiento, dataGrid)

            ' Verificar si se cargaron datos
            If dataGrid.Rows.Count = 0 Then
                MessageBox.Show("No se encontraron datos para mostrar.")
                Exit Sub
            End If

            ' Inicializar acumuladores por moneda
            Dim totalCLP As Double = 0
            Dim totalUSD As Double = 0
            Dim totalEUR As Double = 0

            ' Consulta SQL para obtener los totales por moneda
            Dim sqlTotal As String = $"SELECT SUM(Total) AS Total, Moneda FROM {tabla} GROUP BY Moneda"
            Dim dtTotales As DataTable = ObtenerDatos(sqlTotal)

            ' Calcular totales por moneda
            For Each fila As DataRow In dtTotales.Rows
                Dim moneda As String = fila("Moneda").ToString().Trim().ToUpper()
                Dim total As Double

                If Double.TryParse(fila("Total").ToString(), total) Then
                    Select Case moneda
                        Case "CLP" : totalCLP += total
                        Case "USD" : totalUSD += total
                        Case "EUR" : totalEUR += total
                    End Select
                End If
            Next

            ' Formato de cultura para separación de miles con coma y decimales con punto
            Dim cultura As New Globalization.CultureInfo("es-CL")

            ' Mostrar los totales en los labels correspondientes
            If dataGrid.Equals(DGSeguimiento) Then
                Label24.Text = totalCLP.ToString("C0", cultura)
                Label25.Text = "USD " & totalUSD.ToString("N2", cultura)
                Label26.Text = "EUR " & totalEUR.ToString("N2", cultura)

            ElseIf dataGrid.Equals(DGOK2) Then
                Label30.Text = totalCLP.ToString("C0", cultura)
                Label31.Text = "USD " & totalUSD.ToString("N2", cultura)
                Label32.Text = "EUR " & totalEUR.ToString("N2", cultura)

            ElseIf dataGrid.Equals(DataGridView2) Then
                Label35.Text = totalCLP.ToString("C0", cultura)
                Label36.Text = "USD " & totalUSD.ToString("N2", cultura)
                Label37.Text = "EUR " & totalEUR.ToString("N2", cultura)
            End If

            ' Formatear columna Fecha si existe
            If dataGrid.Columns.Contains("Fecha") Then
                dataGrid.Columns("Fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
            End If

        Catch ex As Exception
            MessageBox.Show($"Error en MOSTRAR(): {ex.Message}{vbCrLf}{ex.StackTrace}")
        End Try
    End Sub



    Function ObtenerDatos(ByVal consulta As String) As DataTable
        Dim dt As New DataTable()
        Try
            Using cmd As New MySqlCommand(consulta, conexion)
                conexion.Open()
                dt.Load(cmd.ExecuteReader())
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener datos: " & ex.Message)
        Finally
            conexion.Close()
        End Try
        Return dt
    End Function

    ' Evento para formatear la columna "Total" (solo cuando sea necesario)
    Private Sub DGSeguimiento_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGSeguimiento.CellFormatting
        Try
            If DGSeguimiento.Columns(e.ColumnIndex).Name = "Total" AndAlso e.Value IsNot Nothing Then
                e.Value = Format(e.Value, "#,##0.00")
                e.FormattingApplied = True
            End If
        Catch ex As Exception
            MessageBox.Show($"Error en CellFormatting: {ex.Message}")
        End Try
    End Sub
    ' Llamadas a la función para cada tabla
    Sub MostrarTSADATADEFINICION()
        MOSTRAR("TSADATADEFINICION", DGSeguimiento, True)
    End Sub

    Sub MostrarTSADATACOTIZACIONOK()
        MOSTRAR("TSADATACOTIZACIONOK", DGOK2, False)
    End Sub

    Sub MostrarTSADATACOTIZACION()
        MOSTRAR("TSADATACOTIZACION", DataGridView2, False)
    End Sub


    Private Sub Form25_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarTSADATACOTIZACION()
        MostrarTSADATACOTIZACIONOK()
        MostrarTSADATADEFINICION()

        Label5.Text = DGSeguimiento.RowCount.ToString()
        Label9.Text = DGOK2.RowCount.ToString()
        Label10.Text = DataGridView2.RowCount.ToString()
        Label14.Text = (Val(Label5.Text) + Val(Label9.Text) + Val(Label10.Text)).ToString()

        Calcular_Fechas()
        DateInicio.Text = Now()
        DateFinal.Text = Now()
    End Sub
    ' Función para cargar datos y calcular totales
    Sub CargarYCalcular(sql As String, dgv As DataGridView, ByRef totalCLP As Double, ByRef totalUSD As Double, ByRef totalEUR As Double)
        Cargar_MySQLseguimiento(sql, dgv)

        For Each fila As DataGridViewRow In dgv.Rows
            If fila.IsNewRow Then Continue For

            Dim total As Double = 0
            If fila.Cells("Total").Value IsNot Nothing AndAlso Double.TryParse(fila.Cells("Total").Value.ToString(), total) Then
                Select Case fila.Cells("Moneda").Value?.ToString().Trim()
                    Case "CLP"
                        totalCLP += total
                    Case "USD"
                        totalUSD += total
                    Case "EUR"
                        totalEUR += total
                    Case Else
                        'MessageBox.Show("Moneda desconocida para la cotización: " & fila.Cells("Cotizacion").Value?.ToString())
                End Select
            Else
                MessageBox.Show("Valor no válido en la celda Total para la cotización: " & fila.Cells("Cotizacion").Value?.ToString())
            End If
        Next
    End Sub

    ' Subrutina que carga la información y realiza el cálculo para un rango de fechas específico
    Sub FECHA(ByVal fechaInicio As DateTime, ByVal fechaFin As DateTime)
        ' ================================== SECCIÓN: DEFINIDAS ==================================
        Dim sqlDefinidasSimple As String = "SELECT DISTINCT Cotizacion, Fecha, Atencion, Definicion FROM TSADATADEFINICION WHERE Fecha BETWEEN '" & fechaInicio.ToString("yyyy-MM-dd") & "' AND '" & fechaFin.ToString("yyyy-MM-dd") & "' ORDER BY Fecha"
        Cargar_MySQLseguimiento(sqlDefinidasSimple, DGSeguimiento)

        Dim sqlDefinidas As String = "SELECT Cotizacion, Fecha, Atencion, Definicion, (Cantidad * Precio) AS Total, Moneda FROM TSADATADEFINICION WHERE Fecha BETWEEN '" & fechaInicio.ToString("yyyy-MM-dd") & "' AND '" & fechaFin.ToString("yyyy-MM-dd") & "' ORDER BY Fecha"

        Dim totalA As Double = 0, totalB As Double = 0, totalC As Double = 0
        CargarYCalcular(sqlDefinidas, DGSeguimiento, totalA, totalB, totalC)

        ' Actualiza los Labels con los totales
        Label24.Text = Format(totalA, "$ #,#0.00")
        Label25.Text = Format(totalB, "USD #,#0.00")
        Label26.Text = Format(totalC, "EUR #,#0.00")
        Label5.Text = DGSeguimiento.RowCount.ToString()

        ' ================================== SECCIÓN: APROBADAS ==================================
        Dim sqlAprobadasSimple As String = "SELECT DISTINCT Cotizacion, Fecha, Atencion, OC, OC_Items FROM TSADATACOTIZACIONOK WHERE Fecha BETWEEN '" & fechaInicio.ToString("yyyy-MM-dd") & "' AND '" & fechaFin.ToString("yyyy-MM-dd") & "' ORDER BY Fecha"
        Cargar_MySQLseguimiento(sqlAprobadasSimple, DGOK2)

        Dim sqlAprobadas As String = "SELECT DISTINCT Cotizacion, Fecha, Atencion, OC, OC_Items, (Cantidad * Precio) AS Total, Moneda FROM TSADATACOTIZACIONOK WHERE Fecha BETWEEN '" & fechaInicio.ToString("yyyy-MM-dd") & "' AND '" & fechaFin.ToString("yyyy-MM-dd") & "' ORDER BY Fecha"

        Dim totalD As Double = 0, totalE As Double = 0, totalF As Double = 0
        CargarYCalcular(sqlAprobadas, DGOK2, totalD, totalE, totalF)

        ' Actualiza los Labels con los totales
        Label30.Text = Format(totalD, "$ #,#0.00")
        Label31.Text = Format(totalE, "USD #,#0.00")
        Label32.Text = Format(totalF, "EUR #,#0.00")

        ' ================================== SECCIÓN: POR DEFINIR ==================================
        Dim sqlPorDefinirSimple As String = "SELECT DISTINCT Cotizacion, Fecha, Atencion FROM TSADATACOTIZACION WHERE Fecha BETWEEN '" & fechaInicio.ToString("yyyy-MM-dd") & "' AND '" & fechaFin.ToString("yyyy-MM-dd") & "' ORDER BY Fecha"
        Cargar_MySQLseguimiento(sqlPorDefinirSimple, DataGridView2)

        Dim sqlPorDefinir As String = "SELECT DISTINCT Cotizacion, Fecha, Atencion, (Cantidad * Precio) AS Total, Moneda FROM TSADATACOTIZACION WHERE Fecha BETWEEN '" & fechaInicio.ToString("yyyy-MM-dd") & "' AND '" & fechaFin.ToString("yyyy-MM-dd") & "' ORDER BY Fecha"

        Dim totalG As Double = 0, totalH As Double = 0, totalI As Double = 0
        CargarYCalcular(sqlPorDefinir, DataGridView2, totalG, totalH, totalI)

        ' Actualiza los Labels con los totales
        Label35.Text = Format(totalG, "$ #,#0.00")
        Label36.Text = Format(totalH, "USD #,#0.00")
        Label37.Text = Format(totalI, "EUR #,#0.00")

        ' Actualiza los contadores totales
        Label9.Text = DGOK2.RowCount.ToString()
        Label10.Text = DataGridView2.RowCount.ToString()
        Label14.Text = (Val(Label5.Text) + Val(Label9.Text) + Val(Label10.Text)).ToString()
    End Sub

    ' Subrutina para calcular el rango de fechas según la opción seleccionada
    Sub DaysRange(ByVal range As String)
        Dim fechaInicio As DateTime
        Dim fechaFin As DateTime = DateTime.Now()

        Select Case range
            Case "LAST7DAYS"
                fechaInicio = DateTime.Today.AddDays(-7)
            Case "LAST30DAYS"
                fechaInicio = DateTime.Today.AddDays(-30)
            Case "THISMONTH"
                fechaInicio = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
            Case "THISYEAR"
                fechaInicio = New DateTime(DateTime.Now.Year, 1, 1)
            Case "CUSTOM"
                ' Aquí puedes permitir que el usuario ingrese un rango personalizado
                ' fechaInicio = CustomStartDate
                ' fechaFin = CustomEndDate
                ' Asume que el usuario proporciona fechas adecuadas.
                Return
            Case Else
                fechaInicio = DateTime.Today.AddDays(-30)
        End Select

        ' Llama a FECHA con las fechas correspondientes
        FECHA(fechaInicio, fechaFin)
    End Sub

    ' ========================= Botón para Últimos 7 días =========================
    Private Sub ButtonLast7Days_Click(sender As Object, e As EventArgs) Handles ButtonLast7Days.Click
        DaysRange("LAST7DAYS")
        Calcular_Fechas()
    End Sub

    ' ========================= Botón para Últimos 30 días =========================
    Private Sub ButtonLast30Days_Click(sender As Object, e As EventArgs) Handles ButtonLast30Days.Click
        DaysRange("LAST30DAYS")
        Calcular_Fechas()
    End Sub

    ' ========================= Botón para Este mes =========================
    Private Sub ButtonThisMonth_Click(sender As Object, e As EventArgs) Handles ButtonThisMonth.Click
        DaysRange("THISMONTH")
        Calcular_Fechas()
    End Sub

    ' ========================= Botón para Este año =========================
    Private Sub ButtonThisYear_Click(sender As Object, e As EventArgs) Handles ButtonThisYear.Click
        DaysRange("THISYEAR")
        Calcular_Fechas()
    End Sub

    ' ========================= Botón para rango personalizado =========================
    Private Sub ButtonCustom_Click(sender As Object, e As EventArgs) Handles ButtonCustom.Click
        ' Aquí puedes agregar lógica para seleccionar un rango de fechas personalizado
        ' Por ejemplo, mostrar un cuadro de diálogo para que el usuario ingrese las fechas

        ' Supón que el usuario ingresa fechas personalizadas en DateInicio y DateFinal
        Dim fechaInicio As DateTime = DateInicio.Value
        Dim fechaFin As DateTime = DateFinal.Value

        ' Llama a FECHA con las fechas personalizadas
        FECHA(fechaInicio, fechaFin)
        Calcular_Fechas()

    End Sub


End Class