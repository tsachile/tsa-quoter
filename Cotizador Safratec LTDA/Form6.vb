Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Reflection.Emit
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms.DataVisualization.Charting
Imports MySql.Data.MySqlClient
Public Class Form6
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
    Sub MOSTRAR()
        'Para Carga de Datos de Cotizaciones 
        On Error Resume Next
        Dim sqlseguimiento As String = " Select Cotizacion, Fecha, Razon_Social, Atencion, Definicion, (Cantidad*Precio) as Total, Moneda FROM TSADATADEFINICION ORDER BY Fecha"

        Cargar_MySQLseguimiento(sqlseguimiento, DGSeguimiento)
        'PARA CALCULO DE SUMA DE TOTALES EN UN TEXTBOX 
        '
        Dim totalA As Double = 0
        Dim totalB As Double = 0
        Dim totalC As Double = 0

        For Each fila As DataGridViewRow In DGSeguimiento.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalA += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalB += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalC += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        TextBox1.Text = Format(totalA, "$ #,#0.00")
        Label24.Text = totalA

        TextBox2.Text = Format(totalB, "USD #,#0.00")
        Label25.Text = totalB

        TextBox4.Text = Format(totalC, "EUR #,#0.00")
        Label26.Text = totalC

        DGSeguimiento.Columns(1).DefaultCellStyle.Format = "dd/MM/yyyy"

    End Sub
    Sub MOSTRAR2()
        'Para Carga de Datos de Cotizaciones 
        On Error Resume Next

        Dim sqlseguimiento2 As String = " Select distinct Cotizacion,Fecha,Atencion,Definicion FROM TSADATADEFINICION ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimiento2, DGSeguimiento2)
        DGSeguimiento.Columns(1).DefaultCellStyle.Format = "dd/MM/yyyy"
    End Sub
    Sub OK()
        'Para Carga Datos de Cotizaciones Aprobadas
        On Error Resume Next
        Dim sqlok As String = "Select Distinct Cotizacion, Fecha, Atencion, OC, OC_Items, (Cantidad*Precio) as Total, Moneda  FROM TSADATACOTIZACIONOK ORDER BY Fecha"

        Cargar_MySQLseguimiento(sqlok, DGOK)
        'PARA CALCULO DE SUMA DE TOTALES EN UN TEXTBOX 
        '
        Dim totalD As Double = 0
        Dim totalE As Double = 0
        Dim totalF As Double = 0

        For Each fila As DataGridViewRow In DGOK.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalD += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalE += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalF += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        TextBox5.Text = Format(totalD, "$ #,#0.00")
        Label30.Text = totalD
        TextBox6.Text = Format(totalE, "USD #,#0.00")
        Label31.Text = totalE
        TextBox7.Text = Format(totalF, "EUR #,#0.00")
        Label32.Text = totalF

        DGOK.Columns(1).DefaultCellStyle.Format = "dd/MM/yyyy"
    End Sub
    Sub OK2()
        'Para Carga Datos de Cotizaciones Aprobadas
        On Error Resume Next
        Dim sqlok As String = "Select Distinct Cotizacion, Fecha, Atencion, OC, OC_Items FROM TSADATACOTIZACIONOK ORDER BY Fecha"

        Cargar_MySQLseguimiento(sqlok, DGOK2)
        DGOK2.Columns(1).DefaultCellStyle.Format = "dd/MM/yyyy"
    End Sub
    Sub PORDEFINIR()
        'Para Carga de Datos de Cotizaciones 
        On Error Resume Next
        Dim sqlseguimiento As String = " Select distinct Cotizacion,Fecha,Atencion,(Cantidad*Precio) as Total, Moneda FROM TSADATACOTIZACION ORDER BY Fecha"
        Cargar_MySQLseguimiento(sqlseguimiento, DataGridView1)

        DataGridView1.Columns(17).DefaultCellStyle.Format = "#.#,#"
        Dim totalG As Double = 0
        Dim totalH As Double = 0
        Dim totalI As Double = 0

        For Each fila As DataGridViewRow In DataGridView1.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalG += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalH += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalI += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        TextBox8.Text = Format(totalG, "$ #,#0.00")
        Label35.Text = totalG
        TextBox9.Text = Format(totalH, "USD #,#0.00")
        Label36.Text = totalH
        TextBox10.Text = Format(totalI, "EUR #,#0.00")
        Label37.Text = totalI
        DataGridView1.Columns(1).DefaultCellStyle.Format = "dd/MM/yyyy"
    End Sub
    Sub PORDEFINIR2()
        'Para Carga de Datos de Cotizaciones 
        On Error Resume Next
        Dim sqlseguimiento As String = " Select distinct Cotizacion,Fecha,Atencion FROM TSADATACOTIZACION ORDER BY Fecha"
        Cargar_MySQLseguimiento(sqlseguimiento, DataGridView2)
        'DataGridView2.Columns(1).DefaultCellStyle.Format = "dd/MM/yyyy"
    End Sub
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateInicio2.Text = Now()
        DateInicio.Text = Now()
        DateFinal.Text = Now()

        MOSTRAR()
        MOSTRAR2()

        OK()
        OK2()

        PORDEFINIR()
        PORDEFINIR2()
        Label5.Text = DGSeguimiento2.RowCount.ToString()
        Label7.Text = DGOK2.RowCount.ToString()
        Label10.Text = DataGridView2.RowCount.ToString

        Label14.Text = (Val(Label5.Text) + Val(Label7.Text) + Val(Label10.Text)).ToString

    End Sub
    Sub ESTEMES()

        DateInicio.Value = New DateTime(Date.Now.Year, Date.Now.Month, 1)
        DateFinal.Value = Date.Now()
        '==================================DEFINIDAS====================================================
        Dim sqlseguimiento2 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICION WHERE Fecha 
        BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimiento2, DGSeguimiento2)

        Dim sqlseguimiento As String = "Select Cotizacion, Fecha, Atencion, Definicion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICION WHERE Fecha BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimiento, DGSeguimiento)
        Dim totalA As Double = 0
        Dim totalB As Double = 0
        Dim totalC As Double = 0

        For Each fila As DataGridViewRow In DGSeguimiento.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalA += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalB += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalC += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        TextBox1.Text = Format(totalA, "$ #,#0.00")
        Label24.Text = totalA

        TextBox2.Text = Format(totalB, "USD #,#0.00")
        Label25.Text = totalB

        TextBox4.Text = Format(totalC, "EUR #,#0.00")
        Label26.Text = totalC

        Label5.Text = DGSeguimiento2.RowCount.ToString()
        '===========================================APROBADAS============================================================
        Dim sqlok2 As String = "Select Distinct Cotizacion, Fecha, Atencion, OC, OC_Items FROM TSADATACOTIZACIONOK WHERE Fecha 
        BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlok2, DGOK2)

        Dim sqlok As String = "Select Distinct Cotizacion, Fecha, Atencion, OC, OC_Items, (Cantidad*Precio) as Total, Moneda  FROM TSADATACOTIZACIONOK
        WHERE Fecha BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha"

        Cargar_MySQLseguimiento(sqlok, DGOK)
        'PARA CALCULO DE SUMA DE TOTALES EN UN TEXTBOX 
        '
        Dim totalD As Double = 0
        Dim totalE As Double = 0
        Dim totalF As Double = 0

        For Each fila As DataGridViewRow In DGOK.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalD += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalE += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalF += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        TextBox5.Text = Format(totalD, "$ #,#0.00")
        Label30.Text = totalD
        TextBox6.Text = Format(totalE, "USD #,#0.00")
        Label31.Text = totalE
        TextBox7.Text = Format(totalF, "EUR #,#0.00")
        Label32.Text = totalF

        '=================================================POR DEFINIR==========================================================
        Dim sqlpordefinir As String = " Select distinct Cotizacion,Fecha,Atencion FROM TSADATACOTIZACION WHERE Fecha 
        BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha"

        Cargar_MySQLseguimiento(sqlpordefinir, DataGridView2)

        Dim sqlpordefinir2 As String = " Select distinct Cotizacion,Fecha,Atencion,(Cantidad*Precio) as Total, Moneda FROM TSADATACOTIZACION WHERE Fecha 
        BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlpordefinir2, DataGridView1)

        Dim totalG As Double = 0
        Dim totalH As Double = 0
        Dim totalI As Double = 0

        For Each fila As DataGridViewRow In DataGridView1.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalG += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalH += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalI += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        TextBox8.Text = Format(totalG, "$ #,#0.00")
        Label35.Text = totalG
        TextBox9.Text = Format(totalH, "USD #,#0.00")
        Label36.Text = totalH
        TextBox10.Text = Format(totalI, "EUR #,#0.00")
        Label37.Text = totalI

        Label7.Text = DGOK2.RowCount.ToString()
        Label10.Text = DataGridView2.RowCount.ToString

        Label14.Text = (Val(Label5.Text) + Val(Label7.Text) + Val(Label10.Text)).ToString


    End Sub
    Sub Days7()
        DateInicio.Value = DateTime.Today.AddDays(-7)
        DateFinal.Value = DateTime.Now()
        '==================================DEFINIDAS====================================================
        Dim sqlseguimiento2 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICION WHERE Fecha 
        BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimiento2, DGSeguimiento2)

        Dim sqlseguimiento As String = "Select Cotizacion, Fecha, Atencion, Definicion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICION WHERE Fecha BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimiento, DGSeguimiento)
        Dim totalA As Double = 0
        Dim totalB As Double = 0
        Dim totalC As Double = 0

        For Each fila As DataGridViewRow In DGSeguimiento.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalA += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalB += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalC += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        TextBox1.Text = Format(totalA, "$ #,#0.00")
        Label24.Text = totalA

        TextBox2.Text = Format(totalB, "USD #,#0.00")
        Label25.Text = totalB

        TextBox4.Text = Format(totalC, "EUR #,#0.00")
        Label26.Text = totalC

        Label5.Text = DGSeguimiento2.RowCount.ToString()
        '===========================================APROBADAS============================================================
        Dim sqlok2 As String = "Select Distinct Cotizacion, Fecha, Atencion, OC, OC_Items FROM TSADATACOTIZACIONOK WHERE Fecha 
        BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlok2, DGOK2)

        Dim sqlok As String = "Select Distinct Cotizacion, Fecha, Atencion, OC, OC_Items, (Cantidad*Precio) as Total, Moneda  FROM TSADATACOTIZACIONOK
        WHERE Fecha BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha"

        Cargar_MySQLseguimiento(sqlok, DGOK)
        'PARA CALCULO DE SUMA DE TOTALES EN UN TEXTBOX 
        '
        Dim totalD As Double = 0
        Dim totalE As Double = 0
        Dim totalF As Double = 0

        For Each fila As DataGridViewRow In DGOK.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalD += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalE += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalF += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        TextBox5.Text = Format(totalD, "$ #,#0.00")
        Label30.Text = totalD
        TextBox6.Text = Format(totalE, "USD #,#0.00")
        Label31.Text = totalE
        TextBox7.Text = Format(totalF, "EUR #,#0.00")
        Label32.Text = totalF

        '=================================================POR DEFINIR==========================================================
        Dim sqlpordefinir As String = " Select distinct Cotizacion,Fecha,Atencion FROM TSADATACOTIZACION WHERE Fecha 
        BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha"

        Cargar_MySQLseguimiento(sqlpordefinir, DataGridView2)

        Dim sqlpordefinir2 As String = " Select distinct Cotizacion,Fecha,Atencion,(Cantidad*Precio) as Total, Moneda FROM TSADATACOTIZACION WHERE Fecha 
        BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlpordefinir2, DataGridView1)

        Dim totalG As Double = 0
        Dim totalH As Double = 0
        Dim totalI As Double = 0

        For Each fila As DataGridViewRow In DataGridView1.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalG += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalH += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalI += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        TextBox8.Text = Format(totalG, "$ #,#0.00")
        Label35.Text = totalG
        TextBox9.Text = Format(totalH, "USD #,#0.00")
        Label36.Text = totalH
        TextBox10.Text = Format(totalI, "EUR #,#0.00")
        Label37.Text = totalI

        Label7.Text = DGOK2.RowCount.ToString()
        Label10.Text = DataGridView2.RowCount.ToString

        Label14.Text = (Val(Label5.Text) + Val(Label7.Text) + Val(Label10.Text)).ToString
    End Sub
    Sub Days30()

        DateInicio.Value = DateTime.Today.AddDays(-30)
        DateFinal.Value = DateTime.Now()
        '==================================DEFINIDAS====================================================
        Dim sqlseguimiento2 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICION WHERE Fecha 
        BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimiento2, DGSeguimiento2)

        Dim sqlseguimiento As String = "Select Cotizacion, Fecha, Atencion, Definicion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICION WHERE Fecha BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimiento, DGSeguimiento)
        Dim totalA As Double = 0
        Dim totalB As Double = 0
        Dim totalC As Double = 0

        For Each fila As DataGridViewRow In DGSeguimiento.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalA += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalB += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalC += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        TextBox1.Text = Format(totalA, "$ #,#0.00")
        Label24.Text = totalA

        TextBox2.Text = Format(totalB, "USD #,#0.00")
        Label25.Text = totalB

        TextBox4.Text = Format(totalC, "EUR #,#0.00")
        Label26.Text = totalC

        Label5.Text = DGSeguimiento2.RowCount.ToString()
        '===========================================APROBADAS============================================================
        Dim sqlok2 As String = "Select Distinct Cotizacion, Fecha, Atencion, OC, OC_Items FROM TSADATACOTIZACIONOK WHERE Fecha 
        BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlok2, DGOK2)

        Dim sqlok As String = "Select Distinct Cotizacion, Fecha, Atencion, OC, OC_Items, (Cantidad*Precio) as Total, Moneda  FROM TSADATACOTIZACIONOK
        WHERE Fecha BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha"

        Cargar_MySQLseguimiento(sqlok, DGOK)
        'PARA CALCULO DE SUMA DE TOTALES EN UN TEXTBOX 
        '
        Dim totalD As Double = 0
        Dim totalE As Double = 0
        Dim totalF As Double = 0

        For Each fila As DataGridViewRow In DGOK.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalD += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalE += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalF += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        TextBox5.Text = Format(totalD, "$ #,#0.00")
        Label30.Text = totalD
        TextBox6.Text = Format(totalE, "USD #,#0.00")
        Label31.Text = totalE
        TextBox7.Text = Format(totalF, "EUR #,#0.00")
        Label32.Text = totalF

        '=================================================POR DEFINIR==========================================================
        Dim sqlpordefinir As String = " Select distinct Cotizacion,Fecha,Atencion FROM TSADATACOTIZACION WHERE Fecha 
        BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha"

        Cargar_MySQLseguimiento(sqlpordefinir, DataGridView2)

        Dim sqlpordefinir2 As String = " Select distinct Cotizacion,Fecha,Atencion,(Cantidad*Precio) as Total, Moneda FROM TSADATACOTIZACION WHERE Fecha 
        BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlpordefinir2, DataGridView1)

        Dim totalG As Double = 0
        Dim totalH As Double = 0
        Dim totalI As Double = 0

        For Each fila As DataGridViewRow In DataGridView1.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalG += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalH += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalI += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        TextBox8.Text = Format(totalG, "$ #,#0.00")
        Label35.Text = totalG
        TextBox9.Text = Format(totalH, "USD #,#0.00")
        Label36.Text = totalH
        TextBox10.Text = Format(totalI, "EUR #,#0.00")
        Label37.Text = totalI

        Label7.Text = DGOK2.RowCount.ToString()
        Label10.Text = DataGridView2.RowCount.ToString

        Label14.Text = (Val(Label5.Text) + Val(Label7.Text) + Val(Label10.Text)).ToString
    End Sub
    Sub Year()
        DateInicio.Value = New DateTime(DateTime.Now.Year, 1, 1)
        DateFinal.Value = DateTime.Now()
        '==================================DEFINIDAS====================================================
        Dim sqlseguimiento2 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICION WHERE Fecha 
        BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimiento2, DGSeguimiento2)

        Dim sqlseguimiento As String = "Select Cotizacion, Fecha, Atencion, Definicion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICION WHERE Fecha BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimiento, DGSeguimiento)
        Dim totalA As Double = 0
        Dim totalB As Double = 0
        Dim totalC As Double = 0

        For Each fila As DataGridViewRow In DGSeguimiento.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalA += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalB += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalC += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        TextBox1.Text = Format(totalA, "$ #,#0.00")
        Label24.Text = totalA

        TextBox2.Text = Format(totalB, "USD #,#0.00")
        Label25.Text = totalB

        TextBox4.Text = Format(totalC, "EUR #,#0.00")
        Label26.Text = totalC

        Label5.Text = DGSeguimiento2.RowCount.ToString()
        '===========================================APROBADAS============================================================
        Dim sqlok2 As String = "Select Distinct Cotizacion, Fecha, Atencion, OC, OC_Items FROM TSADATACOTIZACIONOK WHERE Fecha 
        BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlok2, DGOK2)



        Dim sqlok As String = "Select Distinct Cotizacion, Fecha, Atencion, OC, OC_Items, (Cantidad*Precio) as Total, Moneda  FROM TSADATACOTIZACIONOK
        WHERE Fecha BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha"

        Cargar_MySQLseguimiento(sqlok, DGOK)
        'PARA CALCULO DE SUMA DE TOTALES EN UN TEXTBOX 
        '
        Dim totalD As Double = 0
        Dim totalE As Double = 0
        Dim totalF As Double = 0

        For Each fila As DataGridViewRow In DGOK.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalD += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalE += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalF += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        TextBox5.Text = Format(totalD, "$ #,#0.00")
        Label30.Text = totalD
        TextBox6.Text = Format(totalE, "USD #,#0.00")
        Label31.Text = totalE
        TextBox7.Text = Format(totalF, "EUR #,#0.00")
        Label32.Text = totalF

        '=================================================POR DEFINIR==========================================================
        Dim sqlpordefinir As String = " Select distinct Cotizacion,Fecha,Atencion FROM TSADATACOTIZACION WHERE Fecha 
        BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha"

        Cargar_MySQLseguimiento(sqlpordefinir, DataGridView2)

        Dim sqlpordefinir2 As String = " Select distinct Cotizacion,Fecha,Atencion,(Cantidad*Precio) as Total, Moneda FROM TSADATACOTIZACION WHERE Fecha 
        BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlpordefinir2, DataGridView1)

        Dim totalG As Double = 0
        Dim totalH As Double = 0
        Dim totalI As Double = 0

        For Each fila As DataGridViewRow In DataGridView1.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalG += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalH += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalI += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        TextBox8.Text = Format(totalG, "$ #,#0.00")
        Label35.Text = totalG
        TextBox9.Text = Format(totalH, "USD #,#0.00")
        Label36.Text = totalH
        TextBox10.Text = Format(totalI, "EUR #,#0.00")
        Label37.Text = totalI

        Label7.Text = DGOK2.RowCount.ToString()
        Label10.Text = DataGridView2.RowCount.ToString

        Label14.Text = (Val(Label5.Text) + Val(Label7.Text) + Val(Label10.Text)).ToString

    End Sub
    Sub CustomFecha()
        DateInicio.Value = DateInicio.Value
        DateFinal.Value = DateFinal.Value
        '==================================DEFINIDAS====================================================
        Dim sqlseguimiento2 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICION WHERE Fecha 
        BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimiento2, DGSeguimiento2)

        Dim sqlseguimiento As String = "Select Cotizacion, Fecha, Atencion, Definicion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICION WHERE Fecha BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimiento, DGSeguimiento)
        Dim totalA As Double = 0
        Dim totalB As Double = 0
        Dim totalC As Double = 0

        For Each fila As DataGridViewRow In DGSeguimiento.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalA += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalB += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalC += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        TextBox1.Text = Format(totalA, "$ #,#0.00")
        Label24.Text = totalA

        TextBox2.Text = Format(totalB, "USD #,#0.00")
        Label25.Text = totalB

        TextBox4.Text = Format(totalC, "EUR #,#0.00")
        Label26.Text = totalC

        Label5.Text = DGSeguimiento2.RowCount.ToString()
        '===========================================APROBADAS============================================================
        Dim sqlok2 As String = "Select Distinct Cotizacion, Fecha, Atencion, OC, OC_Items FROM TSADATACOTIZACIONOK WHERE Fecha 
        BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlok2, DGOK2)

        Dim sqlok As String = "Select Distinct Cotizacion, Fecha, Atencion, OC, OC_Items, (Cantidad*Precio) as Total, Moneda  FROM TSADATACOTIZACIONOK
        WHERE Fecha BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha"

        Cargar_MySQLseguimiento(sqlok, DGOK)
        'PARA CALCULO DE SUMA DE TOTALES EN UN TEXTBOX 
        '
        Dim totalD As Double = 0
        Dim totalE As Double = 0
        Dim totalF As Double = 0

        For Each fila As DataGridViewRow In DGOK.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalD += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalE += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalF += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        TextBox5.Text = Format(totalD, "$ #,#0.00")
        Label30.Text = totalD
        TextBox6.Text = Format(totalE, "USD #,#0.00")
        Label31.Text = totalE
        TextBox7.Text = Format(totalF, "EUR #,#0.00")
        Label32.Text = totalF

        '=================================================POR DEFINIR==========================================================
        Dim sqlpordefinir As String = " Select distinct Cotizacion,Fecha,Atencion FROM TSADATACOTIZACION WHERE Fecha 
        BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha"

        Cargar_MySQLseguimiento(sqlpordefinir, DataGridView2)

        Dim sqlpordefinir2 As String = " Select distinct Cotizacion,Fecha,Atencion,(Cantidad*Precio) as Total, Moneda FROM TSADATACOTIZACION WHERE Fecha 
        BETWEEN '" & DateInicio.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlpordefinir2, DataGridView1)

        Dim totalG As Double = 0
        Dim totalH As Double = 0
        Dim totalI As Double = 0

        For Each fila As DataGridViewRow In DataGridView1.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalG += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalH += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalI += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        TextBox8.Text = Format(totalG, "$ #,#0.00")
        Label35.Text = totalG
        TextBox9.Text = Format(totalH, "USD #,#0.00")
        Label36.Text = totalH
        TextBox10.Text = Format(totalI, "EUR #,#0.00")
        Label37.Text = totalI

        Label7.Text = DGOK2.RowCount.ToString()
        Label10.Text = DataGridView2.RowCount.ToString

        Label14.Text = (Val(Label5.Text) + Val(Label7.Text) + Val(Label10.Text)).ToString

    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        'PARA SEGMENTACION DE TIEMPO Y CALCULOS DE DIAS MESES Y AÑOS 
        Calcular_Fechas()
        CustomFecha()

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        'PARA LLAMAR FORMULARIO DE DASHBOARD
        Dim frm As New Form20
        AddOwnedForm(frm)
        frm.Label5.Text = TextBox1.Text
        frm.Label7.Text = TextBox2.Text
        frm.Label9.Text = TextBox4.Text
        'PARA DEFINIDAS
        'PARA DONUTS
        frm.Chart1.Series.Clear()
        frm.Chart1.Series.Add("PERDIDAS CLP")

        frm.Chart1.Series("PERDIDAS CLP").ChartType = SeriesChartType.Doughnut
        frm.Chart1.Series("PERDIDAS CLP").Points.AddXY(Label15.Text, Val(Label24.Text))
        frm.Chart1.Series("PERDIDAS CLP").Points.AddXY(Label16.Text, Val(Label27.Text))
        frm.Chart1.Series("PERDIDAS CLP").Points.AddXY(Label17.Text, Val(Label28.Text))

        frm.Label12.Text = Val(Label24.Text) + Val(Label27.Text) + Val(Label28.Text)

        frm.TextBox1.Text = frm.Label12.Text

        'PARA APROBADAS
        frm.Label13.Text = TextBox5.Text
        frm.Label15.Text = TextBox6.Text
        frm.Label17.Text = TextBox7.Text
        'PARA DONUTS
        frm.Chart2.Series.Clear()
        frm.Chart2.Series.Add("APROBADAS CLP")

        frm.Chart2.Series("APROBADAS CLP").ChartType = SeriesChartType.Doughnut

        frm.Chart2.Series("APROBADAS CLP").Points.AddXY(Label20.Text, Val(Label30.Text))
        frm.Chart2.Series("APROBADAS CLP").Points.AddXY(Label19.Text, Val(Label33.Text))
        frm.Chart2.Series("APROBADAS CLP").Points.AddXY(Label18.Text, Val(Label34.Text))

        frm.Label20.Text = Val(Label30.Text) + Val(Label33.Text) + Val(Label34.Text)

        frm.TextBox2.Text = frm.Label20.Text

        'PARA PENDIENTES
        frm.Label21.Text = TextBox8.Text
        frm.Label23.Text = TextBox9.Text
        frm.Label25.Text = TextBox10.Text
        'PARA DONUTS
        frm.Chart3.Series.Clear()
        frm.Chart3.Series.Add("PENDIENTES CLP")

        frm.Chart3.Series("PENDIENTES CLP").ChartType = SeriesChartType.Doughnut

        frm.Chart3.Series("PENDIENTES CLP").Points.AddXY(Label23.Text, Val(Label35.Text))
        frm.Chart3.Series("PENDIENTES CLP").Points.AddXY(Label22.Text, Val(Label38.Text))
        frm.Chart3.Series("PENDIENTES CLP").Points.AddXY(Label21.Text, Val(Label39.Text))

        frm.Label28.Text = Val(Label35.Text) + Val(Label38.Text) + Val(Label39.Text)

        frm.TextBox3.Text = frm.Label28.Text

        frm.ShowDialog()



    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Label27.Text = Val(TextBox11.Text) * Val(Label25.Text)
        Label28.Text = Val(TextBox12.Text) * Val(Label26.Text)
        Label33.Text = Val(TextBox11.Text) * Val(Label31.Text)
        Label34.Text = Val(TextBox12.Text) * Val(Label32.Text)
        Label38.Text = Val(TextBox11.Text) * Val(Label36.Text)
        Label39.Text = Val(TextBox12.Text) * Val(Label37.Text)

        Label95.Text = Val(TextBox11.Text) * Val(Label86.Text)
        Label112.Text = Val(TextBox12.Text) * Val(Label104.Text)
        Label96.Text = Val(TextBox11.Text) * Val(Label87.Text)
        Label113.Text = Val(TextBox12.Text) * Val(Label105.Text)
        Label97.Text = Val(TextBox11.Text) * Val(Label88.Text)
        Label114.Text = Val(TextBox12.Text) * Val(Label106.Text)
        Label98.Text = Val(TextBox11.Text) * Val(Label89.Text)
        Label115.Text = Val(TextBox12.Text) * Val(Label107.Text)
        Label99.Text = Val(TextBox11.Text) * Val(Label90.Text)
        Label116.Text = Val(TextBox12.Text) * Val(Label108.Text)
        Label100.Text = Val(TextBox11.Text) * Val(Label91.Text)
        Label117.Text = Val(TextBox12.Text) * Val(Label109.Text)
        Label101.Text = Val(TextBox11.Text) * Val(Label92.Text)
        Label118.Text = Val(TextBox12.Text) * Val(Label110.Text)
        Label102.Text = Val(TextBox11.Text) * Val(Label93.Text)
        Label119.Text = Val(TextBox12.Text) * Val(Label111.Text)

        Label156.Text = Val(TextBox11.Text) * Val(Label148.Text)
        Label173.Text = Val(TextBox12.Text) * Val(Label165.Text)
        Label157.Text = Val(TextBox11.Text) * Val(Label149.Text)
        Label174.Text = Val(TextBox12.Text) * Val(Label166.Text)
        Label158.Text = Val(TextBox11.Text) * Val(Label150.Text)
        Label175.Text = Val(TextBox12.Text) * Val(Label167.Text)
        Label159.Text = Val(TextBox11.Text) * Val(Label151.Text)
        Label176.Text = Val(TextBox12.Text) * Val(Label168.Text)
        Label160.Text = Val(TextBox11.Text) * Val(Label152.Text)
        Label177.Text = Val(TextBox12.Text) * Val(Label169.Text)
        Label161.Text = Val(TextBox11.Text) * Val(Label153.Text)
        Label178.Text = Val(TextBox12.Text) * Val(Label170.Text)
        Label162.Text = Val(TextBox11.Text) * Val(Label154.Text)
        Label179.Text = Val(TextBox12.Text) * Val(Label171.Text)
        Label163.Text = Val(TextBox11.Text) * Val(Label155.Text)
        Label180.Text = Val(TextBox12.Text) * Val(Label172.Text)

        Label217.Text = Val(TextBox11.Text) * Val(Label209.Text)
        Label234.Text = Val(TextBox12.Text) * Val(Label226.Text)
        Label218.Text = Val(TextBox11.Text) * Val(Label210.Text)
        Label235.Text = Val(TextBox12.Text) * Val(Label227.Text)
        Label219.Text = Val(TextBox11.Text) * Val(Label211.Text)
        Label236.Text = Val(TextBox12.Text) * Val(Label228.Text)
        Label220.Text = Val(TextBox11.Text) * Val(Label212.Text)
        Label237.Text = Val(TextBox12.Text) * Val(Label229.Text)
        Label221.Text = Val(TextBox11.Text) * Val(Label213.Text)
        Label238.Text = Val(TextBox12.Text) * Val(Label230.Text)
        Label222.Text = Val(TextBox11.Text) * Val(Label214.Text)
        Label239.Text = Val(TextBox12.Text) * Val(Label231.Text)
        Label223.Text = Val(TextBox11.Text) * Val(Label215.Text)
        Label240.Text = Val(TextBox12.Text) * Val(Label232.Text)
        Label224.Text = Val(TextBox11.Text) * Val(Label216.Text)
        Label241.Text = Val(TextBox12.Text) * Val(Label233.Text)
        '==============POR PRECIO==========================================
        Label328.Text = Val(TextBox11.Text) * Val(Label320.Text)
        Label329.Text = Val(TextBox11.Text) * Val(Label321.Text)
        Label330.Text = Val(TextBox11.Text) * Val(Label322.Text)
        Label331.Text = Val(TextBox11.Text) * Val(Label323.Text)
        Label332.Text = Val(TextBox11.Text) * Val(Label324.Text)
        Label333.Text = Val(TextBox11.Text) * Val(Label325.Text)
        Label334.Text = Val(TextBox11.Text) * Val(Label326.Text)
        Label335.Text = Val(TextBox11.Text) * Val(Label327.Text)

        Label344.Text = Val(TextBox12.Text) * Val(Label336.Text)
        Label345.Text = Val(TextBox12.Text) * Val(Label337.Text)
        Label346.Text = Val(TextBox12.Text) * Val(Label338.Text)
        Label347.Text = Val(TextBox12.Text) * Val(Label339.Text)
        Label348.Text = Val(TextBox12.Text) * Val(Label340.Text)
        Label349.Text = Val(TextBox12.Text) * Val(Label341.Text)
        Label350.Text = Val(TextBox12.Text) * Val(Label342.Text)
        Label351.Text = Val(TextBox12.Text) * Val(Label343.Text)

        '==============DESISTIO============================================
        Label376.Text = Val(TextBox11.Text) * Val(Label368.Text)
        Label377.Text = Val(TextBox11.Text) * Val(Label369.Text)
        Label378.Text = Val(TextBox11.Text) * Val(Label370.Text)
        Label379.Text = Val(TextBox11.Text) * Val(Label371.Text)
        Label380.Text = Val(TextBox11.Text) * Val(Label372.Text)
        Label381.Text = Val(TextBox11.Text) * Val(Label373.Text)
        Label382.Text = Val(TextBox11.Text) * Val(Label374.Text)
        Label383.Text = Val(TextBox11.Text) * Val(Label375.Text)

        Label392.Text = Val(TextBox12.Text) * Val(Label384.Text)
        Label393.Text = Val(TextBox12.Text) * Val(Label385.Text)
        Label394.Text = Val(TextBox12.Text) * Val(Label386.Text)
        Label395.Text = Val(TextBox12.Text) * Val(Label387.Text)
        Label396.Text = Val(TextBox12.Text) * Val(Label388.Text)
        Label397.Text = Val(TextBox12.Text) * Val(Label389.Text)
        Label398.Text = Val(TextBox12.Text) * Val(Label390.Text)
        Label399.Text = Val(TextBox12.Text) * Val(Label391.Text)

        '==============CALIDAD=============================================
        Label424.Text = Val(TextBox11.Text) * Val(Label416.Text)
        Label425.Text = Val(TextBox11.Text) * Val(Label417.Text)
        Label426.Text = Val(TextBox11.Text) * Val(Label418.Text)
        Label427.Text = Val(TextBox11.Text) * Val(Label419.Text)
        Label428.Text = Val(TextBox11.Text) * Val(Label420.Text)
        Label429.Text = Val(TextBox11.Text) * Val(Label421.Text)
        Label430.Text = Val(TextBox11.Text) * Val(Label422.Text)
        Label431.Text = Val(TextBox11.Text) * Val(Label423.Text)

        Label440.Text = Val(TextBox12.Text) * Val(Label432.Text)
        Label441.Text = Val(TextBox12.Text) * Val(Label433.Text)
        Label442.Text = Val(TextBox12.Text) * Val(Label434.Text)
        Label443.Text = Val(TextBox12.Text) * Val(Label435.Text)
        Label444.Text = Val(TextBox12.Text) * Val(Label436.Text)
        Label445.Text = Val(TextBox12.Text) * Val(Label437.Text)
        Label446.Text = Val(TextBox12.Text) * Val(Label438.Text)
        Label447.Text = Val(TextBox12.Text) * Val(Label439.Text)

        '===============PLAZO=============================================
        Label472.Text = Val(TextBox11.Text) * Val(Label464.Text)
        Label473.Text = Val(TextBox11.Text) * Val(Label465.Text)
        Label474.Text = Val(TextBox11.Text) * Val(Label466.Text)
        Label475.Text = Val(TextBox11.Text) * Val(Label467.Text)
        Label476.Text = Val(TextBox11.Text) * Val(Label468.Text)
        Label477.Text = Val(TextBox11.Text) * Val(Label469.Text)
        Label478.Text = Val(TextBox11.Text) * Val(Label470.Text)
        Label479.Text = Val(TextBox11.Text) * Val(Label471.Text)

        Label488.Text = Val(TextBox12.Text) * Val(Label480.Text)
        Label489.Text = Val(TextBox12.Text) * Val(Label481.Text)
        Label490.Text = Val(TextBox12.Text) * Val(Label482.Text)
        Label491.Text = Val(TextBox12.Text) * Val(Label483.Text)
        Label492.Text = Val(TextBox12.Text) * Val(Label484.Text)
        Label493.Text = Val(TextBox12.Text) * Val(Label485.Text)
        Label494.Text = Val(TextBox12.Text) * Val(Label486.Text)
        Label495.Text = Val(TextBox12.Text) * Val(Label487.Text)

        PictureBox5.Visible = False

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ESTEMES()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Days7()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Days30()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Year()
    End Sub

#Region "PARA MOSTRAR COTIZACIONES "
    Private Sub DGSeguimiento2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGSeguimiento2.CellContentClick

        '===================================================TERMINAR CODIGO PARA MOSTRAR COTIZACION SEGUN LA NECESIDADES =================================================================

        On Error Resume Next
        Dim fila As Integer
        fila = DGSeguimiento2.CurrentRow.Index
        TxtCotizacion.Text = Me.DGSeguimiento2.Item(0, fila).Value
        TxtFecha.Text = Me.DGSeguimiento2.Item(1, fila).Value
        'Para busqueda en Seguimiento
        Dim Cotizacion As String = TxtCotizacion.Text.ToString
        Dim Fecha As String = TxtFecha.Text.ToString()

        Dim sqlbusqueda As String = " Select * From  TSADATADEFINICION Where Cotizacion ='" & Cotizacion & "'and Fecha='" & Fecha & "' "

        'Para Carga de Cotizacion en nuevo formulario para la visualizacion
        Dim frm As New Form10
        AddOwnedForm(frm)

        Cargar_MySQLseguimiento(sqlbusqueda, DGSeguimiento)

        Dim xtreme As Integer
        xtreme = DGSeguimiento.CurrentRow.Index
        frm.TextBox1.Text = Me.DGSeguimiento.Item(2, xtreme).Value 'Razon social
        frm.TextBox2.Text = Me.DGSeguimiento.Item(4, xtreme).Value 'Atencion
        frm.TextBox3.Text = Me.DGSeguimiento.Item(3, xtreme).Value 'RUT
        frm.TextBox4.Text = Me.DGSeguimiento.Item(5, xtreme).Value 'Direccion
        frm.TextBox5.Text = Me.DGSeguimiento.Item(6, xtreme).Value 'Telefono
        frm.TextBox6.Text = Me.DGSeguimiento.Item(7, xtreme).Value 'Mail

        frm.TextBox7.Text = Me.DGSeguimiento.Item(0, xtreme).Value '# Cotizacion

        frm.TextBox8.Text = Me.DGSeguimiento.Item(1, xtreme).Value 'Fecha
        frm.TextBox9.Text = Me.DGSeguimiento.Item(8, xtreme).Value 'Vendedor
        frm.TextBox10.Text = Me.DGSeguimiento.Item(10, xtreme).Value 'Correo
        frm.TextBox11.Text = Me.DGSeguimiento.Item(11, xtreme).Value 'Pagina Web
        frm.TextBox12.Text = Me.DGSeguimiento.Item(9, xtreme).Value ' Telefono
        frm.TextBox13.Text = Me.DGSeguimiento.Item(12, xtreme).Value 'Referencia

        frm.Label2.Text = Me.DGSeguimiento.Item(19, xtreme).Value 'Codigo Unico ID

        frm.TextBox122.Text = Me.DGSeguimiento.Item(21, xtreme).Value 'OC
        frm.DateTimePicker1.Text = Me.DGSeguimiento.Item(22, xtreme).Value 'Fecha OC

        frm.TextBox14.Text = Me.DGSeguimiento.Item(13, xtreme).Value 'Descripcion de Material
        frm.TextBox15.Text = Me.DGSeguimiento.Item(14, xtreme).Value 'Codigo de Material
        frm.TextBox16.Text = Me.DGSeguimiento.Item(15, xtreme).Value 'Cantidad de Material
        frm.TextBox17.Text = Me.DGSeguimiento.Item(17, xtreme).Value 'Precio de Material
        frm.TextBox123.Text = Me.DGSeguimiento.Item(23, xtreme).Value 'OC Items
        frm.DateTimePicker2.Text = Me.DGSeguimiento.Item(24, xtreme).Value ' Fecha OC Items
        frm.TextBox143.Text = Me.DGSeguimiento.Item(18, xtreme).Value 'Moneda
        frm.DateTimePicker42.Text = Me.DGSeguimiento2.Item(25, xtreme).Value 'Fecha de Entrega

        frm.TextBox19.Text = Me.DGSeguimiento.Item(13, xtreme + 1).Value 'Descripcion de Material
        frm.TextBox20.Text = Me.DGSeguimiento.Item(14, xtreme + 1).Value 'Codigo de Material
        frm.TextBox21.Text = Me.DGSeguimiento.Item(15, xtreme + 1).Value 'Cantidad de Material
        frm.TextBox22.Text = Me.DGSeguimiento.Item(17, xtreme + 1).Value 'Precio de Material
        frm.TextBox124.Text = Me.DGSeguimiento.Item(23, xtreme + 1).Value 'OC Items
        frm.DateTimePicker3.Text = Me.DGSeguimiento.Item(24, xtreme + 1).Value ' Fecha OC Items
        frm.TextBox144.Text = Me.DGSeguimiento.Item(18, xtreme + 1).Value 'Moneda

        frm.TextBox24.Text = Me.DGSeguimiento2.Item(13, xtreme + 2).Value 'Descripcion de Material
        frm.TextBox25.Text = Me.DGSeguimiento2.Item(14, xtreme + 2).Value 'Codigo de Material
        frm.TextBox26.Text = Me.DGSeguimiento2.Item(15, xtreme + 2).Value 'Cantidad de Material
        frm.TextBox27.Text = Me.DGSeguimiento2.Item(17, xtreme + 2).Value 'Precio de Material
        frm.TextBox125.Text = Me.DGSeguimiento2.Item(23, xtreme + 2).Value 'OC Items
        frm.DateTimePicker4.Text = Me.DGSeguimiento2.Item(24, xtreme + 2).Value ' Fecha OC Items
        frm.TextBox145.Text = Me.DGSeguimiento2.Item(18, xtreme + 2).Value 'Moneda

        frm.TextBox29.Text = Me.DGSeguimiento2.Item(13, xtreme + 3).Value 'Descripcion de Material
        frm.TextBox30.Text = Me.DGSeguimiento2.Item(14, xtreme + 3).Value 'Codigo de Material
        frm.TextBox31.Text = Me.DGSeguimiento2.Item(15, xtreme + 3).Value 'Cantidad de Material
        frm.TextBox32.Text = Me.DGSeguimiento2.Item(17, xtreme + 3).Value 'Precio de Material
        frm.TextBox126.Text = Me.DGSeguimiento2.Item(23, xtreme + 3).Value 'OC Items
        frm.DateTimePicker5.Text = Me.DGSeguimiento2.Item(24, xtreme + 3).Value ' Fecha OC Items
        frm.TextBox146.Text = Me.DGSeguimiento2.Item(18, xtreme + 3).Value 'Moneda

        frm.TextBox34.Text = Me.DGSeguimiento2.Item(13, xtreme + 4).Value 'Descripcion de Material
        frm.TextBox35.Text = Me.DGSeguimiento2.Item(14, xtreme + 4).Value 'Codigo de Material
        frm.TextBox36.Text = Me.DGSeguimiento2.Item(15, xtreme + 4).Value 'Cantidad de Material
        frm.TextBox37.Text = Me.DGSeguimiento2.Item(17, xtreme + 4).Value 'Precio de Material
        frm.TextBox127.Text = Me.DGSeguimiento2.Item(23, xtreme + 4).Value 'OC Items
        frm.DateTimePicker6.Text = Me.DGSeguimiento2.Item(24, xtreme + 4).Value ' Fecha OC Items
        frm.TextBox147.Text = Me.DGSeguimiento2.Item(18, xtreme + 4).Value 'Moneda

        frm.TextBox39.Text = Me.DGSeguimiento2.Item(13, xtreme + 5).Value 'Descripcion de Material
        frm.TextBox40.Text = Me.DGSeguimiento2.Item(14, xtreme + 5).Value 'Codigo de Material
        frm.TextBox41.Text = Me.DGSeguimiento2.Item(15, xtreme + 5).Value 'Cantidad de Material
        frm.TextBox42.Text = Me.DGSeguimiento2.Item(17, xtreme + 5).Value 'Precio de Material
        frm.TextBox128.Text = Me.DGSeguimiento2.Item(23, xtreme + 5).Value 'OC Items
        frm.DateTimePicker7.Text = Me.DGSeguimiento2.Item(24, xtreme + 5).Value ' Fecha OC Items
        frm.TextBox148.Text = Me.DGSeguimiento2.Item(18, xtreme + 5).Value 'Moneda

        frm.TextBox44.Text = Me.DGSeguimiento2.Item(13, xtreme + 6).Value 'Descripcion de Material
        frm.TextBox45.Text = Me.DGSeguimiento2.Item(14, xtreme + 6).Value 'Codigo de Material
        frm.TextBox46.Text = Me.DGSeguimiento2.Item(15, xtreme + 6).Value 'Cantidad de Material
        frm.TextBox47.Text = Me.DGSeguimiento2.Item(17, xtreme + 6).Value 'Precio de Material
        frm.TextBox129.Text = Me.DGSeguimiento2.Item(23, xtreme + 6).Value 'OC Items
        frm.DateTimePicker8.Text = Me.DGSeguimiento2.Item(24, xtreme + 6).Value ' Fecha OC Items
        frm.TextBox149.Text = Me.DGSeguimiento2.Item(18, xtreme + 6).Value 'Moneda

        frm.TextBox49.Text = Me.DGSeguimiento2.Item(13, xtreme + 7).Value 'Descripcion de Material
        frm.TextBox50.Text = Me.DGSeguimiento2.Item(14, xtreme + 7).Value 'Codigo de Material
        frm.TextBox51.Text = Me.DGSeguimiento2.Item(15, xtreme + 7).Value 'Cantidad de Material
        frm.TextBox52.Text = Me.DGSeguimiento2.Item(17, xtreme + 7).Value 'Precio de Material
        frm.TextBox130.Text = Me.DGSeguimiento2.Item(23, xtreme + 7).Value 'OC Items
        frm.DateTimePicker9.Text = Me.DGSeguimiento2.Item(24, xtreme + 7).Value ' Fecha OC Items
        frm.TextBox150.Text = Me.DGSeguimiento2.Item(18, xtreme + 7).Value 'Moneda

        frm.TextBox54.Text = Me.DGSeguimiento2.Item(13, xtreme + 8).Value 'Descripcion de Material
        frm.TextBox55.Text = Me.DGSeguimiento2.Item(14, xtreme + 8).Value 'Codigo de Material
        frm.TextBox56.Text = Me.DGSeguimiento2.Item(15, xtreme + 8).Value 'Cantidad de Material
        frm.TextBox57.Text = Me.DGSeguimiento2.Item(17, xtreme + 8).Value 'Precio de Material
        frm.TextBox131.Text = Me.DGSeguimiento2.Item(23, xtreme + 8).Value 'OC Items
        frm.DateTimePicker10.Text = Me.DGSeguimiento2.Item(24, xtreme + 8).Value ' Fecha OC Items
        frm.TextBox151.Text = Me.DGSeguimiento2.Item(18, xtreme + 8).Value 'Moneda

        frm.TextBox59.Text = Me.DGSeguimiento2.Item(13, xtreme + 9).Value 'Descripcion de Material
        frm.TextBox60.Text = Me.DGSeguimiento2.Item(14, xtreme + 9).Value 'Codigo de Material
        frm.TextBox61.Text = Me.DGSeguimiento2.Item(15, xtreme + 9).Value 'Cantidad de Material
        frm.TextBox62.Text = Me.DGSeguimiento2.Item(17, xtreme + 9).Value 'Precio de Material
        frm.TextBox132.Text = Me.DGSeguimiento2.Item(23, xtreme + 9).Value 'OC Items
        frm.DateTimePicker11.Text = Me.DGSeguimiento2.Item(24, xtreme + 9).Value ' Fecha OC Items
        frm.TextBox152.Text = Me.DGSeguimiento2.Item(18, xtreme + 9).Value 'Moneda

        frm.TextBox64.Text = Me.DGSeguimiento2.Item(13, xtreme + 10).Value 'Descripcion de Material
        frm.TextBox65.Text = Me.DGSeguimiento2.Item(14, xtreme + 10).Value 'Codigo de Material
        frm.TextBox66.Text = Me.DGSeguimiento2.Item(15, xtreme + 10).Value 'Cantidad de Material
        frm.TextBox67.Text = Me.DGSeguimiento2.Item(17, xtreme + 10).Value 'Precio de Material
        frm.TextBox133.Text = Me.DGSeguimiento2.Item(23, xtreme + 10).Value 'OC Items
        frm.DateTimePicker12.Text = Me.DGSeguimiento2.Item(24, xtreme + 10).Value ' Fecha OC Items
        frm.TextBox153.Text = Me.DGSeguimiento2.Item(18, xtreme + 10).Value 'Moneda

        frm.TextBox69.Text = Me.DGSeguimiento2.Item(13, xtreme + 11).Value 'Descripcion de Material
        frm.TextBox70.Text = Me.DGSeguimiento2.Item(14, xtreme + 11).Value 'Codigo de Material
        frm.TextBox71.Text = Me.DGSeguimiento2.Item(15, xtreme + 11).Value 'Cantidad de Material
        frm.TextBox72.Text = Me.DGSeguimiento2.Item(17, xtreme + 11).Value 'Precio de Material
        frm.TextBox134.Text = Me.DGSeguimiento2.Item(23, xtreme + 11).Value 'OC Items
        frm.DateTimePicker13.Text = Me.DGSeguimiento2.Item(24, xtreme + 11).Value ' Fecha OC Items
        frm.TextBox154.Text = Me.DGSeguimiento2.Item(18, xtreme + 11).Value 'Moneda

        frm.TextBox74.Text = Me.DGSeguimiento2.Item(13, xtreme + 12).Value 'Descripcion de Material
        frm.TextBox75.Text = Me.DGSeguimiento2.Item(14, xtreme + 12).Value 'Codigo de Material
        frm.TextBox76.Text = Me.DGSeguimiento2.Item(15, xtreme + 12).Value 'Cantidad de Material
        frm.TextBox77.Text = Me.DGSeguimiento2.Item(17, xtreme + 12).Value 'Precio de Material
        frm.TextBox135.Text = Me.DGSeguimiento2.Item(23, xtreme + 12).Value 'OC Items
        frm.DateTimePicker14.Text = Me.DGSeguimiento2.Item(24, xtreme + 12).Value ' Fecha OC Items
        frm.TextBox155.Text = Me.DGSeguimiento2.Item(18, xtreme + 12).Value 'Moneda

        frm.TextBox79.Text = Me.DGSeguimiento2.Item(13, xtreme + 13).Value 'Descripcion de Material
        frm.TextBox80.Text = Me.DGSeguimiento2.Item(14, xtreme + 13).Value 'Codigo de Material
        frm.TextBox81.Text = Me.DGSeguimiento2.Item(15, xtreme + 13).Value 'Cantidad de Material
        frm.TextBox82.Text = Me.DGSeguimiento2.Item(17, xtreme + 13).Value 'Precio de Material
        frm.DateTimePicker15.Text = Me.DGSeguimiento2.Item(24, xtreme + 13).Value ' Fecha OC Items
        frm.TextBox156.Text = Me.DGSeguimiento2.Item(18, xtreme + 13).Value 'Moneda

        frm.TextBox84.Text = Me.DGSeguimiento2.Item(13, xtreme + 14).Value 'Descripcion de Material
        frm.TextBox85.Text = Me.DGSeguimiento2.Item(14, xtreme + 14).Value 'Codigo de Material
        frm.TextBox86.Text = Me.DGSeguimiento2.Item(15, xtreme + 14).Value 'Cantidad de Material
        frm.TextBox87.Text = Me.DGSeguimiento2.Item(17, xtreme + 14).Value 'Precio de Material
        frm.DateTimePicker16.Text = Me.DGSeguimiento2.Item(24, xtreme + 14).Value ' Fecha OC Items
        frm.TextBox157.Text = Me.DGSeguimiento2.Item(18, xtreme + 14).Value 'Moneda

        frm.TextBox89.Text = Me.DGSeguimiento2.Item(13, xtreme + 15).Value 'Descripcion de Material
        frm.TextBox90.Text = Me.DGSeguimiento2.Item(14, xtreme + 15).Value 'Codigo de Material
        frm.TextBox91.Text = Me.DGSeguimiento2.Item(15, xtreme + 15).Value 'Cantidad de Material
        frm.TextBox92.Text = Me.DGSeguimiento2.Item(17, xtreme + 15).Value 'Precio de Material
        frm.DateTimePicker17.Text = Me.DGSeguimiento2.Item(24, xtreme + 15).Value ' Fecha OC Items
        frm.TextBox158.Text = Me.DGSeguimiento2.Item(18, xtreme + 15).Value 'Moneda

        frm.TextBox94.Text = Me.DGSeguimiento2.Item(13, xtreme + 16).Value 'Descripcion de Material
        frm.TextBox95.Text = Me.DGSeguimiento2.Item(14, xtreme + 16).Value 'Codigo de Material
        frm.TextBox96.Text = Me.DGSeguimiento2.Item(15, xtreme + 16).Value 'Cantidad de Material
        frm.TextBox97.Text = Me.DGSeguimiento2.Item(17, xtreme + 16).Value 'Precio de Material
        frm.DateTimePicker18.Text = Me.DGSeguimiento2.Item(24, xtreme + 16).Value ' Fecha OC Items
        frm.TextBox159.Text = Me.DGSeguimiento2.Item(18, xtreme + 16).Value 'Moneda

        frm.TextBox99.Text = Me.DGSeguimiento2.Item(13, xtreme + 17).Value 'Descripcion de Material
        frm.TextBox100.Text = Me.DGSeguimiento2.Item(14, xtreme + 17).Value 'Codigo de Material
        frm.TextBox101.Text = Me.DGSeguimiento2.Item(15, xtreme + 17).Value 'Cantidad de Material
        frm.TextBox102.Text = Me.DGSeguimiento2.Item(17, xtreme + 17).Value 'Precio de Material
        frm.DateTimePicker19.Text = Me.DGSeguimiento2.Item(24, xtreme + 17).Value ' Fecha OC Items
        frm.TextBox160.Text = Me.DGSeguimiento2.Item(18, xtreme + 17).Value 'Moneda

        frm.TextBox104.Text = Me.DGSeguimiento2.Item(13, xtreme + 18).Value 'Descripcion de Material
        frm.TextBox105.Text = Me.DGSeguimiento2.Item(14, xtreme + 18).Value 'Codigo de Material
        frm.TextBox106.Text = Me.DGSeguimiento2.Item(15, xtreme + 18).Value 'Cantidad de Material
        frm.TextBox107.Text = Me.DGSeguimiento2.Item(17, xtreme + 18).Value 'Precio de Material
        frm.DateTimePicker20.Text = Me.DGSeguimiento2.Item(24, xtreme + 18).Value ' Fecha OC Items
        frm.TextBox161.Text = Me.DGSeguimiento2.Item(18, xtreme + 18).Value 'Moneda

        frm.TextBox109.Text = Me.DGSeguimiento2.Item(13, xtreme + 19).Value 'Descripcion de Material
        frm.TextBox110.Text = Me.DGSeguimiento2.Item(14, xtreme + 19).Value 'Codigo de Material
        frm.TextBox111.Text = Me.DGSeguimiento2.Item(15, xtreme + 19).Value 'Cantidad de Material
        frm.TextBox112.Text = Me.DGSeguimiento2.Item(17, xtreme + 19).Value 'Precio de Material
        frm.DateTimePicker21.Text = Me.DGSeguimiento2.Item(24, xtreme + 19).Value ' Fecha OC Items
        frm.TextBox162.Text = Me.DGSeguimiento2.Item(18, xtreme + 19).Value 'Moneda
        'transfieran los valores si los campos no están vacíos

        frm.Button1.Visible = False
        frm.Button2.Visible = False
        frm.BtnExpClp.Visible = False
        frm.Button4.Visible = False
        frm.Button5.Visible = False
        frm.Button3.Visible = True

        '===================================PARA DEFINICION =========================================
        frm.CheckBox21.Visible = False
        frm.CheckBox22.Visible = False
        frm.CheckBox23.Visible = False
        frm.CheckBox24.Visible = False
        frm.CheckBox25.Visible = False
        frm.CheckBox26.Visible = False
        frm.CheckBox27.Visible = False
        frm.CheckBox28.Visible = False
        frm.CheckBox29.Visible = False
        frm.CheckBox30.Visible = False
        frm.CheckBox31.Visible = False
        frm.CheckBox32.Visible = False
        frm.CheckBox33.Visible = False
        frm.CheckBox34.Visible = False
        frm.CheckBox35.Visible = False
        frm.CheckBox36.Visible = False
        frm.CheckBox37.Visible = False
        frm.CheckBox38.Visible = False
        frm.CheckBox39.Visible = False
        frm.CheckBox40.Visible = False
        '=================================PARA AGREGAR===========================================
        frm.CheckBox41.Visible = False
        frm.CheckBox42.Visible = False
        frm.CheckBox43.Visible = False
        frm.CheckBox44.Visible = False
        frm.CheckBox45.Visible = False
        frm.CheckBox46.Visible = False
        frm.CheckBox47.Visible = False
        frm.CheckBox48.Visible = False
        frm.CheckBox49.Visible = False
        frm.CheckBox50.Visible = False
        frm.CheckBox51.Visible = False
        frm.CheckBox52.Visible = False
        frm.CheckBox53.Visible = False
        frm.CheckBox54.Visible = False
        frm.CheckBox55.Visible = False
        frm.CheckBox56.Visible = False
        frm.CheckBox57.Visible = False
        frm.CheckBox58.Visible = False
        frm.CheckBox59.Visible = False
        frm.CheckBox60.Visible = False

        frm.ShowDialog()
    End Sub

#End Region
#Region "NUEVA PARTE DE CALCULO DE INTERVALOS DE FECHAS POR FORMULA"
    Sub INTERVALOS()
        DateFinal2.Value = DateFinal2.Value
        DateFinal3.Value = DateFinal3.Value
        '==================================DEFINIDAS====================================================
        Dim sqlseguimiento3 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICION WHERE Fecha 
        BETWEEN '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal2.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "
        Cargar_MySQLseguimiento(sqlseguimiento3, DGSeguimiento3)

        Dim sql2 As String = "Select Cotizacion, Fecha, Atencion, Definicion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICION WHERE Fecha BETWEEN '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal2.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sql2, DGS2)
        Dim totalx As Double = 0
        Dim totalv As Double = 0
        Dim totalz As Double = 0

        For Each fila As DataGridViewRow In DGS2.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalx += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalv += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalz += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label68.Text = Format(totalx, "$ #,#0.00")
        Label78.Text = totalx
        Label86.Text = totalx
        Label104.Text = totalz
        Label121.Text = (Val(Label78.Text) + Val(Label95.Text) + Val(Label112.Text)).ToString

        '=====================================APROBADAS==========================================
        Dim sqlOK3 As String = "Select Distinct Cotizacion, Fecha, Atencion, OC, OC_Items FROM TSADATACOTIZACIONOK WHERE Fecha 
        BETWEEN '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal2.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlOK3, DGOK3)

        Dim sql31 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATACOTIZACIONOK WHERE Fecha BETWEEN '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal2.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sql31, DGOK31)
        Dim totalQ1 As Double = 0
        Dim totalW2 As Double = 0
        Dim totalE3 As Double = 0

        For Each fila As DataGridViewRow In DGOK31.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalQ1 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalW2 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalE3 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label139.Text = totalQ1
        Label148.Text = totalW2
        Label165.Text = totalE3
        Label182.Text = (Val(Label139.Text) + Val(Label156.Text) + Val(Label173.Text)).ToString
        '============================================POR DEFINIR===========================================
        Dim sqlPD1 As String = "Select distinct Cotizacion, Fecha, Atencion FROM TSADATACOTIZACION WHERE Fecha BETWEEN 
        '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal2.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha"

        Cargar_MySQLseguimiento(sqlPD1, DGPD1)
        Dim sql11 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATACOTIZACION WHERE Fecha BETWEEN '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal2.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sql11, DGPD11)

        Dim totalQ01 As Double = 0
        Dim totalW01 As Double = 0
        Dim totalE01 As Double = 0

        For Each fila As DataGridViewRow In DGPD11.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalQ01 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalW01 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalE01 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label200.Text = totalQ01
        Label209.Text = totalW01
        Label226.Text = totalE01
        Label243.Text = (Val(Label200.Text) + Val(Label217.Text) + Val(Label234.Text)).ToString
    End Sub
    Sub INTERVALO2()
        DateFinal3.Value = DateFinal3.Value
        DateFinal4.Value = DateFinal4.Value
        Dim sqlseguimiento4 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICION WHERE Fecha 
        BETWEEN '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimiento4, DGSeguimiento4)

        Dim sql4 As String = "Select Cotizacion, Fecha, Atencion, Definicion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICION WHERE Fecha BETWEEN '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sql4, DGS4)
        Dim totalt As Double = 0
        Dim totalO As Double = 0
        Dim totalP As Double = 0

        For Each fila As DataGridViewRow In DGS4.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalt += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalO += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalP += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label69.Text = Format(totalt, "$ #,#0.00")
        Label79.Text = totalt
        Label87.Text = totalO
        Label105.Text = totalP

        Label122.Text = (Val(Label79.Text) + Val(Label96.Text) + Val(Label113.Text)).ToString
        '=====================================APROBADAS==========================================
        Dim sqlOK4 As String = "Select Distinct Cotizacion, Fecha, Atencion, OC, OC_Items FROM TSADATACOTIZACIONOK WHERE Fecha 
        BETWEEN '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlOK4, DGOK4)
        Dim sql41 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATACOTIZACIONOK WHERE Fecha BETWEEN '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sql41, DGOK41)
        Dim totalQ4 As Double = 0
        Dim totalW5 As Double = 0
        Dim totalE6 As Double = 0

        For Each fila As DataGridViewRow In DGOK41.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalQ4 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalW5 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalE6 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label140.Text = totalQ4
        Label149.Text = totalW5
        Label166.Text = totalE6
        Label183.Text = (Val(Label140.Text) + Val(Label157.Text) + Val(Label174.Text)).ToString
        '============================================POR DEFINIR===========================================
        Dim sqlPD2 As String = "Select distinct Cotizacion, Fecha, Atencion FROM TSADATACOTIZACION WHERE Fecha BETWEEN 
        '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha"

        Cargar_MySQLseguimiento(sqlPD2, DGPD2)
        Dim sql21 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATACOTIZACION WHERE Fecha BETWEEN '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sql21, DGPD21)

        Dim totalQ02 As Double = 0
        Dim totalW02 As Double = 0
        Dim totalE02 As Double = 0

        For Each fila As DataGridViewRow In DGPD21.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalQ02 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalW02 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalE02 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label201.Text = totalQ02
        Label210.Text = totalW02
        Label227.Text = totalE02
        Label244.Text = (Val(Label201.Text) + Val(Label218.Text) + Val(Label235.Text)).ToString
    End Sub
    Sub INTERVALO3()
        DateFinal4.Value = DateFinal4.Value
        DateFinal5.Value = DateFinal5.Value
        Dim sqlseguimiento5 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICION WHERE Fecha 
        BETWEEN '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimiento5, DGSEguimiento5)

        Dim sql5 As String = "Select Cotizacion, Fecha, Atencion, Definicion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICION WHERE Fecha BETWEEN '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sql5, DGS5)
        Dim totalP As Double = 0
        Dim totala As Double = 0
        Dim totalb As Double = 0

        For Each fila As DataGridViewRow In DGS5.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalP += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totala += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalb += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label70.Text = Format(totalP, "$ #,#0.00")
        Label80.Text = totalP
        Label88.Text = totala
        Label106.Text = totalb
        Label123.Text = (Val(Label80.Text) + Val(Label97.Text) + Val(Label114.Text)).ToString
        '=====================================APROBADAS==========================================
        Dim sqlOK5 As String = "Select Distinct Cotizacion, Fecha, Atencion, OC, OC_Items FROM TSADATACOTIZACIONOK WHERE Fecha 
        BETWEEN '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlOK5, DGOK5)
        Dim sql51 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATACOTIZACIONOK WHERE Fecha BETWEEN '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sql51, DGOK51)
        Dim totalQ7 As Double = 0
        Dim totalW8 As Double = 0
        Dim totalE9 As Double = 0

        For Each fila As DataGridViewRow In DGOK51.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalQ7 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalW8 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalE9 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label141.Text = totalQ7
        Label150.Text = totalW8
        Label167.Text = totalE9
        Label184.Text = (Val(Label141.Text) + Val(Label158.Text) + Val(Label175.Text)).ToString
        '============================================POR DEFINIR===========================================
        Dim sqlPD3 As String = "Select distinct Cotizacion, Fecha, Atencion FROM TSADATACOTIZACION WHERE Fecha BETWEEN 
        '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha"

        Cargar_MySQLseguimiento(sqlPD3, DGPD3)
        Dim sql31 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATACOTIZACION WHERE Fecha BETWEEN '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sql31, DGPD31)

        Dim totalQ03 As Double = 0
        Dim totalW03 As Double = 0
        Dim totalE03 As Double = 0

        For Each fila As DataGridViewRow In DGPD31.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalQ03 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalW03 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalE03 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label202.Text = totalQ03
        Label211.Text = totalW03
        Label228.Text = totalE03
        Label245.Text = (Val(Label202.Text) + Val(Label219.Text) + Val(Label236.Text)).ToString
    End Sub
    Sub INTERVALO4()
        DateFinal5.Value = DateFinal5.Value
        DateFinal6.Value = DateFinal6.Value
        Dim sqlseguimiento6 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICION WHERE Fecha 
        BETWEEN '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimiento6, DGSeguimiento6)

        Dim sql6 As String = "Select Cotizacion, Fecha, Atencion, Definicion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICION WHERE Fecha BETWEEN '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sql6, DGS6)
        Dim totalI As Double = 0
        Dim totaln As Double = 0
        Dim totalr As Double = 0

        For Each fila As DataGridViewRow In DGS6.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalI += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totaln += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalr += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label71.Text = Format(totalI, "$ #,#0.00")
        Label81.Text = totalI
        Label89.Text = totaln
        Label107.Text = totalr
        Label124.Text = (Val(Label81.Text) + Val(Label98.Text) + Val(Label115.Text)).ToString
        '=====================================APROBADAS==========================================
        Dim sqlOK6 As String = "Select Distinct Cotizacion, Fecha, Atencion, OC, OC_Items FROM TSADATACOTIZACIONOK WHERE Fecha 
        BETWEEN '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlOK6, DGOK6)
        Dim sql61 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATACOTIZACIONOK WHERE Fecha BETWEEN '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sql61, DGOK61)
        Dim totalQ10 As Double = 0
        Dim totalW11 As Double = 0
        Dim totalE12 As Double = 0

        For Each fila As DataGridViewRow In DGOK61.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalQ10 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalW11 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalE12 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label142.Text = totalQ10
        Label151.Text = totalW11
        Label168.Text = totalE12
        Label185.Text = (Val(Label142.Text) + Val(Label159.Text) + Val(Label176.Text)).ToString
        '============================================POR DEFINIR===========================================
        Dim sqlPD4 As String = "Select distinct Cotizacion, Fecha, Atencion FROM TSADATACOTIZACION WHERE Fecha BETWEEN 
        '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha"

        Cargar_MySQLseguimiento(sqlPD4, DGPD4)
        Dim sql41 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATACOTIZACION WHERE Fecha BETWEEN '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sql41, DGPD41)

        Dim totalQ04 As Double = 0
        Dim totalW04 As Double = 0
        Dim totalE04 As Double = 0

        For Each fila As DataGridViewRow In DGPD41.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalQ04 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalW04 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalE04 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label203.Text = totalQ04
        Label212.Text = totalW04
        Label229.Text = totalE04
        Label246.Text = (Val(Label203.Text) + Val(Label220.Text) + Val(Label237.Text)).ToString
    End Sub

    Sub INTERVALO5()
        DateFinal6.Value = DateFinal6.Value
        DateFinal7.Value = DateFinal7.Value
        Dim sqlseguimiento7 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICION WHERE Fecha 
        BETWEEN '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimiento7, DGSeguimiento7)

        Dim sql7 As String = "Select Cotizacion, Fecha, Atencion, Definicion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICION WHERE Fecha BETWEEN '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sql7, DGS7)
        Dim totalH As Double = 0
        Dim totalk As Double = 0
        Dim totalj As Double = 0

        For Each fila As DataGridViewRow In DGS7.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalH += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalk += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalj += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label72.Text = Format(totalH, "$ #,#0.00")
        Label82.Text = totalH
        Label90.Text = totalk
        Label108.Text = totalj
        Label125.Text = (Val(Label82.Text) + Val(Label99.Text) + Val(Label116.Text)).ToString
        '=====================================APROBADAS==========================================
        Dim sqlOK7 As String = "Select Distinct Cotizacion, Fecha, Atencion, OC, OC_Items FROM TSADATACOTIZACIONOK WHERE Fecha 
        BETWEEN '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlOK7, DGOK7)
        Dim sql71 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATACOTIZACIONOK WHERE Fecha BETWEEN '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sql71, DGOK71)
        Dim totalQ13 As Double = 0
        Dim totalW14 As Double = 0
        Dim totalE15 As Double = 0

        For Each fila As DataGridViewRow In DGOK71.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalQ13 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalW14 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalE15 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label143.Text = totalQ13
        Label152.Text = totalW14
        Label169.Text = totalE15
        Label186.Text = (Val(Label143.Text) + Val(Label160.Text) + Val(Label177.Text)).ToString
        '============================================POR DEFINIR===========================================
        Dim sqlPD5 As String = "Select distinct Cotizacion, Fecha, Atencion FROM TSADATACOTIZACION WHERE Fecha BETWEEN 
        '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha"

        Cargar_MySQLseguimiento(sqlPD5, DGPD5)
        Dim sql51 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATACOTIZACION WHERE Fecha BETWEEN '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sql51, DGPD51)

        Dim totalQ05 As Double = 0
        Dim totalW05 As Double = 0
        Dim totalE05 As Double = 0

        For Each fila As DataGridViewRow In DGPD51.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalQ05 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalW05 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalE05 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label204.Text = totalQ05
        Label213.Text = totalW05
        Label230.Text = totalE05
        Label247.Text = (Val(Label204.Text) + Val(Label221.Text) + Val(Label238.Text)).ToString
    End Sub
    Sub INTERVALO6()
        DateFinal7.Value = DateFinal7.Value
        DateFinal8.Value = DateFinal8.Value
        Dim sqlseguimiento8 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICION WHERE Fecha 
        BETWEEN '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimiento8, DGSeguimiento8)

        Dim sql8 As String = "Select Cotizacion, Fecha, Atencion, Definicion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICION WHERE Fecha BETWEEN '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sql8, DGS8)
        Dim totalT As Double = 0
        Dim totalvv As Double = 0
        Dim totalza As Double = 0

        For Each fila As DataGridViewRow In DGS8.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalT += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalvv += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalza += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label73.Text = Format(totalT, "$ #,#0.00")
        Label83.Text = totalT
        Label91.Text = totalvv
        Label109.Text = totalza
        Label126.Text = (Val(Label83.Text) + Val(Label100.Text) + Val(Label117.Text)).ToString
        '=====================================APROBADAS==========================================
        Dim sqlOK8 As String = "Select Distinct Cotizacion, Fecha, Atencion, OC, OC_Items FROM TSADATACOTIZACIONOK WHERE Fecha 
        BETWEEN '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlOK8, DGOK8)
        Dim sql81 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATACOTIZACIONOK WHERE Fecha BETWEEN '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sql81, DGOK81)
        Dim totalQ16 As Double = 0
        Dim totalW17 As Double = 0
        Dim totalE18 As Double = 0

        For Each fila As DataGridViewRow In DGOK71.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalQ16 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalW17 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalE18 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label144.Text = totalQ16
        Label153.Text = totalW17
        Label170.Text = totalE18
        Label187.Text = (Val(Label144.Text) + Val(Label161.Text) + Val(Label178.Text)).ToString
        '============================================POR DEFINIR===========================================
        Dim sqlPD6 As String = "Select distinct Cotizacion, Fecha, Atencion FROM TSADATACOTIZACION WHERE Fecha BETWEEN 
        '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha"

        Cargar_MySQLseguimiento(sqlPD6, DGPD6)
        Dim sql61 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATACOTIZACION WHERE Fecha BETWEEN '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sql61, DGPD61)

        Dim totalQ06 As Double = 0
        Dim totalW06 As Double = 0
        Dim totalE06 As Double = 0

        For Each fila As DataGridViewRow In DGPD61.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalQ06 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalW06 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalE06 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label205.Text = totalQ06
        Label214.Text = totalW06
        Label231.Text = totalE06
        Label248.Text = (Val(Label205.Text) + Val(Label222.Text) + Val(Label239.Text)).ToString
    End Sub
    Sub INTERVALO7()
        DateFinal8.Value = DateFinal8.Value
        DateFinal9.Value = DateFinal9.Value
        Dim sqlseguimiento9 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICION WHERE Fecha 
        BETWEEN '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimiento9, DGSeguimiento9)

        Dim sql9 As String = "Select Cotizacion, Fecha, Atencion, Definicion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICION WHERE Fecha BETWEEN '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sql9, DGS9)
        Dim totalW As Double = 0
        Dim totalve As Double = 0
        Dim totalzy As Double = 0

        For Each fila As DataGridViewRow In DGS9.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalW += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalve += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalzy += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label74.Text = Format(totalW, "$ #,#0.00")
        Label84.Text = totalW
        Label92.Text = totalve
        Label110.Text = totalzy
        Label127.Text = (Val(Label84.Text) + Val(Label101.Text) + Val(Label118.Text)).ToString
        '=====================================APROBADAS==========================================
        Dim sqlOK9 As String = "Select Distinct Cotizacion, Fecha, Atencion, OC, OC_Items FROM TSADATACOTIZACIONOK WHERE Fecha 
        BETWEEN '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlOK9, DGOK9)
        Dim sql91 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATACOTIZACIONOK WHERE Fecha BETWEEN '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sql91, DGOK91)
        Dim totalQ19 As Double = 0
        Dim totalW20 As Double = 0
        Dim totalE21 As Double = 0

        For Each fila As DataGridViewRow In DGOK91.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalQ19 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalW20 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalE21 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label145.Text = totalQ19
        Label154.Text = totalW20
        Label171.Text = totalE21
        Label188.Text = (Val(Label145.Text) + Val(Label162.Text) + Val(Label179.Text)).ToString
        '============================================POR DEFINIR===========================================
        Dim sqlPD7 As String = "Select distinct Cotizacion, Fecha, Atencion FROM TSADATACOTIZACION WHERE Fecha BETWEEN 
        '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha"

        Cargar_MySQLseguimiento(sqlPD7, DGPD7)
        Dim sql71 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATACOTIZACION WHERE Fecha BETWEEN '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sql71, DGPD71)

        Dim totalQ07 As Double = 0
        Dim totalW07 As Double = 0
        Dim totalE07 As Double = 0

        For Each fila As DataGridViewRow In DGPD71.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalQ07 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalW07 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalE07 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label206.Text = totalQ07
        Label215.Text = totalW07
        Label232.Text = totalE07
        Label249.Text = (Val(Label206.Text) + Val(Label223.Text) + Val(Label240.Text)).ToString
    End Sub
    Sub INTERVALO8()
        DateFinal9.Value = DateFinal9.Value
        DTP1.Value = DTP1.Value
        Dim sqlseguimiento10 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICION WHERE Fecha 
        BETWEEN '" & DTP1.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimiento10, DGSeguimiento10)

        Dim sql10 As String = "Select Cotizacion, Fecha, Atencion, Definicion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICION WHERE Fecha BETWEEN '" & DTP1.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sql10, DGS10)
        Dim totalG As Double = 0
        Dim totalvd As Double = 0
        Dim totalzw As Double = 0

        For Each fila As DataGridViewRow In DGS10.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalG += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalvd += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalzw += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label75.Text = Format(totalG, "$ #,#0.00")
        Label85.Text = totalG
        Label93.Text = totalvd
        Label111.Text = totalzw
        Label128.Text = (Val(Label85.Text) + Val(Label102.Text) + Val(Label119.Text)).ToString
        '=====================================APROBADAS==========================================
        Dim sqlOK10 As String = "Select Distinct Cotizacion, Fecha, Atencion, OC, OC_Items FROM TSADATACOTIZACIONOK WHERE Fecha 
        BETWEEN '" & DTP1.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlOK10, DGOK10)
        Dim sql101 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATACOTIZACIONOK WHERE Fecha BETWEEN '" & DTP1.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sql101, DGOK101)
        Dim totalQ22 As Double = 0
        Dim totalW23 As Double = 0
        Dim totalE24 As Double = 0

        For Each fila As DataGridViewRow In DGOK101.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalQ22 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalW23 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalE24 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label146.Text = totalQ22
        Label155.Text = totalW23
        Label172.Text = totalE24
        Label189.Text = (Val(Label146.Text) + Val(Label163.Text) + Val(Label180.Text)).ToString
        '============================================POR DEFINIR===========================================
        Dim sqlPD8 As String = "Select distinct Cotizacion, Fecha, Atencion FROM TSADATACOTIZACION WHERE Fecha BETWEEN 
        '" & DTP1.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha"

        Cargar_MySQLseguimiento(sqlPD8, DGPD8)
        Dim sql81 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATACOTIZACION WHERE Fecha BETWEEN '" & DTP1.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sql81, DGPD81)

        Dim totalQ08 As Double = 0
        Dim totalW08 As Double = 0
        Dim totalE08 As Double = 0

        For Each fila As DataGridViewRow In DGPD81.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalQ08 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalW08 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalE08 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label207.Text = totalQ08
        Label216.Text = totalW08
        Label233.Text = totalE08
        Label250.Text = (Val(Label207.Text) + Val(Label224.Text) + Val(Label241.Text)).ToString
    End Sub
    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Dim frm As New Form21
        AddOwnedForm(frm)
        frm.Chart1.Series.Clear()
        frm.Chart1.Series.Add("N# COTIZACIONES PERDIDAS")
        frm.Chart1.Series("N# COTIZACIONES PERDIDAS").ChartType = SeriesChartType.Column
        'frm.Chart1.Series("N# COTIZACIONES PERDIDAS").Points.AddXY(Label59.Text, Val(Label67.Text))
        'frm.Chart1.Series("N# COTIZACIONES PERDIDAS").Points.AddXY(Label58.Text, Val(Label66.Text))
        frm.Chart1.Series("N# COTIZACIONES PERDIDAS").Points.AddXY(Label57.Text, Val(Label65.Text))
        frm.Chart1.Series("N# COTIZACIONES PERDIDAS").Points.AddXY(Label56.Text, Val(Label64.Text))
        frm.Chart1.Series("N# COTIZACIONES PERDIDAS").Points.AddXY(Label55.Text, Val(Label63.Text))
        frm.Chart1.Series("N# COTIZACIONES PERDIDAS").Points.AddXY(Label44.Text, Val(Label62.Text))
        frm.Chart1.Series("N# COTIZACIONES PERDIDAS").Points.AddXY(Label43.Text, Val(Label61.Text))
        frm.Chart1.Series("N# COTIZACIONES PERDIDAS").Points.AddXY(Label42.Text, Val(Label60.Text))
        frm.Chart1.Series("N# COTIZACIONES PERDIDAS").IsValueShownAsLabel = True
        frm.Chart1.Series("N# COTIZACIONES PERDIDAS").LabelBackColor = System.Drawing.Color.Azure
        'frm.Chart1.Series("N# COTIZACIONES PERDIDAS").Label

        frm.Chart1.Series.Add("N# COT PERD POR PRECIO")
        frm.Chart1.Series("N# COT PERD POR PRECIO").ChartType = SeriesChartType.Column
        'frm.Chart1.Series("N# COT PERD POR PRECIO").Points.AddXY(Label59.Text, Val(Label279.Text))
        'frm.Chart1.Series("N# COT PERD POR PRECIO").Points.AddXY(Label58.Text, Val(Label278.Text))
        frm.Chart1.Series("N# COT PERD POR PRECIO").Points.AddXY(Label57.Text, Val(Label277.Text))
        frm.Chart1.Series("N# COT PERD POR PRECIO").Points.AddXY(Label56.Text, Val(Label276.Text))
        frm.Chart1.Series("N# COT PERD POR PRECIO").Points.AddXY(Label55.Text, Val(Label275.Text))
        frm.Chart1.Series("N# COT PERD POR PRECIO").Points.AddXY(Label44.Text, Val(Label274.Text))
        frm.Chart1.Series("N# COT PERD POR PRECIO").Points.AddXY(Label43.Text, Val(Label273.Text))
        frm.Chart1.Series("N# COT PERD POR PRECIO").Points.AddXY(Label42.Text, Val(Label272.Text))
        frm.Chart1.Series("N# COT PERD POR PRECIO").IsValueShownAsLabel = True
        frm.Chart1.Series("N# COT PERD POR PRECIO").LabelBackColor = System.Drawing.Color.Azure

        frm.Chart1.Series.Add("N# COT PERD DESISTIO")
        frm.Chart1.Series("N# COT PERD DESISTIO").ChartType = SeriesChartType.Column
        'frm.Chart1.Series("N# COT PERD DESISTIO").Points.AddXY(Label59.Text, Val(Label287.Text))
        'frm.Chart1.Series("N# COT PERD DESISTIO").Points.AddXY(Label58.Text, Val(Label286.Text))
        frm.Chart1.Series("N# COT PERD DESISTIO").Points.AddXY(Label57.Text, Val(Label285.Text))
        frm.Chart1.Series("N# COT PERD DESISTIO").Points.AddXY(Label56.Text, Val(Label284.Text))
        frm.Chart1.Series("N# COT PERD DESISTIO").Points.AddXY(Label55.Text, Val(Label283.Text))
        frm.Chart1.Series("N# COT PERD DESISTIO").Points.AddXY(Label44.Text, Val(Label282.Text))
        frm.Chart1.Series("N# COT PERD DESISTIO").Points.AddXY(Label43.Text, Val(Label281.Text))
        frm.Chart1.Series("N# COT PERD DESISTIO").Points.AddXY(Label42.Text, Val(Label280.Text))
        frm.Chart1.Series("N# COT PERD DESISTIO").IsValueShownAsLabel = True
        frm.Chart1.Series("N# COT PERD DESISTIO").LabelBackColor = System.Drawing.Color.Azure

        frm.Chart1.Series.Add("N# COT PERD POR CALIDAD")
        frm.Chart1.Series("N# COT PERD POR CALIDAD").ChartType = SeriesChartType.Column
        'frm.Chart1.Series("N# COT PERD POR CALIDAD").Points.AddXY(Label59.Text, Val(Label303.Text))
        'frm.Chart1.Series("N# COT PERD POR CALIDAD").Points.AddXY(Label58.Text, Val(Label302.Text))
        frm.Chart1.Series("N# COT PERD POR CALIDAD").Points.AddXY(Label57.Text, Val(Label301.Text))
        frm.Chart1.Series("N# COT PERD POR CALIDAD").Points.AddXY(Label56.Text, Val(Label300.Text))
        frm.Chart1.Series("N# COT PERD POR CALIDAD").Points.AddXY(Label55.Text, Val(Label299.Text))
        frm.Chart1.Series("N# COT PERD POR CALIDAD").Points.AddXY(Label44.Text, Val(Label298.Text))
        frm.Chart1.Series("N# COT PERD POR CALIDAD").Points.AddXY(Label43.Text, Val(Label297.Text))
        frm.Chart1.Series("N# COT PERD POR CALIDAD").Points.AddXY(Label42.Text, Val(Label296.Text))
        frm.Chart1.Series("N# COT PERD POR CALIDAD").IsValueShownAsLabel = True
        frm.Chart1.Series("N# COT PERD POR CALIDAD").LabelBackColor = System.Drawing.Color.Azure

        frm.Chart1.Series.Add("N# COT PERD POR PLAZO")
        frm.Chart1.Series("N# COT PERD POR PLAZO").ChartType = SeriesChartType.Column
        'frm.Chart1.Series("N# COT PERD POR PLAZO").Points.AddXY(Label59.Text, Val(Label295.Text))
        ' frm.Chart1.Series("N# COT PERD POR PLAZO").Points.AddXY(Label58.Text, Val(Label294.Text))
        frm.Chart1.Series("N# COT PERD POR PLAZO").Points.AddXY(Label57.Text, Val(Label293.Text))
        frm.Chart1.Series("N# COT PERD POR PLAZO").Points.AddXY(Label56.Text, Val(Label292.Text))
        frm.Chart1.Series("N# COT PERD POR PLAZO").Points.AddXY(Label55.Text, Val(Label291.Text))
        frm.Chart1.Series("N# COT PERD POR PLAZO").Points.AddXY(Label44.Text, Val(Label290.Text))
        frm.Chart1.Series("N# COT PERD POR PLAZO").Points.AddXY(Label43.Text, Val(Label289.Text))
        frm.Chart1.Series("N# COT PERD POR PLAZO").Points.AddXY(Label42.Text, Val(Label288.Text))
        frm.Chart1.Series("N# COT PERD POR PLAZO").IsValueShownAsLabel = True
        frm.Chart1.Series("N# COT PERD POR PLAZO").LabelBackColor = System.Drawing.Color.Azure

        frm.Chart1.Series.Add("N# COTIZACIONES GANADAS")
        frm.Chart1.Series("N# COTIZACIONES GANADAS").ChartType = SeriesChartType.Column
        'frm.Chart1.Series("N# COTIZACIONES GANADAS").Points.AddXY(Label59.Text, Val(Label137.Text))
        'frm.Chart1.Series("N# COTIZACIONES GANADAS").Points.AddXY(Label58.Text, Val(Label136.Text))
        frm.Chart1.Series("N# COTIZACIONES GANADAS").Points.AddXY(Label57.Text, Val(Label135.Text))
        frm.Chart1.Series("N# COTIZACIONES GANADAS").Points.AddXY(Label56.Text, Val(Label134.Text))
        frm.Chart1.Series("N# COTIZACIONES GANADAS").Points.AddXY(Label55.Text, Val(Label133.Text))
        frm.Chart1.Series("N# COTIZACIONES GANADAS").Points.AddXY(Label44.Text, Val(Label132.Text))
        frm.Chart1.Series("N# COTIZACIONES GANADAS").Points.AddXY(Label43.Text, Val(Label131.Text))
        frm.Chart1.Series("N# COTIZACIONES GANADAS").Points.AddXY(Label42.Text, Val(Label130.Text))
        frm.Chart1.Series("N# COTIZACIONES GANADAS").IsValueShownAsLabel = True
        frm.Chart1.Series("N# COTIZACIONES GANADAS").LabelBackColor = System.Drawing.Color.Azure

        frm.Chart1.Series.Add("N# COTIZACIONES POR DEFINIR")
        frm.Chart1.Series("N# COTIZACIONES POR DEFINIR").ChartType = SeriesChartType.Column
        'frm.Chart1.Series("N# COTIZACIONES POR DEFINIR").Points.AddXY(Label59.Text, Val(Label198.Text))
        ' frm.Chart1.Series("N# COTIZACIONES POR DEFINIR").Points.AddXY(Label58.Text, Val(Label197.Text))
        frm.Chart1.Series("N# COTIZACIONES POR DEFINIR").Points.AddXY(Label57.Text, Val(Label196.Text))
        frm.Chart1.Series("N# COTIZACIONES POR DEFINIR").Points.AddXY(Label56.Text, Val(Label195.Text))
        frm.Chart1.Series("N# COTIZACIONES POR DEFINIR").Points.AddXY(Label55.Text, Val(Label194.Text))
        frm.Chart1.Series("N# COTIZACIONES POR DEFINIR").Points.AddXY(Label44.Text, Val(Label193.Text))
        frm.Chart1.Series("N# COTIZACIONES POR DEFINIR").Points.AddXY(Label43.Text, Val(Label192.Text))
        frm.Chart1.Series("N# COTIZACIONES POR DEFINIR").Points.AddXY(Label42.Text, Val(Label191.Text))
        frm.Chart1.Series("N# COTIZACIONES POR DEFINIR").IsValueShownAsLabel = True
        frm.Chart1.Series("N# COTIZACIONES POR DEFINIR").LabelBackColor = System.Drawing.Color.Azure

        frm.Chart1.Series.Add("N# COTIZACIONES ENVIADAS")
        frm.Chart1.Series("N# COTIZACIONES ENVIADAS").ChartType = SeriesChartType.Column
        'frm.Chart1.Series("N# COTIZACIONES ENVIADAS").Points.AddXY(Label59.Text, Val(Label259.Text))
        'frm.Chart1.Series("N# COTIZACIONES ENVIADAS").Points.AddXY(Label58.Text, Val(Label258.Text))
        frm.Chart1.Series("N# COTIZACIONES ENVIADAS").Points.AddXY(Label57.Text, Val(Label257.Text))
        frm.Chart1.Series("N# COTIZACIONES ENVIADAS").Points.AddXY(Label56.Text, Val(Label256.Text))
        frm.Chart1.Series("N# COTIZACIONES ENVIADAS").Points.AddXY(Label55.Text, Val(Label255.Text))
        frm.Chart1.Series("N# COTIZACIONES ENVIADAS").Points.AddXY(Label44.Text, Val(Label254.Text))
        frm.Chart1.Series("N# COTIZACIONES ENVIADAS").Points.AddXY(Label43.Text, Val(Label253.Text))
        frm.Chart1.Series("N# COTIZACIONES ENVIADAS").Points.AddXY(Label42.Text, Val(Label252.Text))
        frm.Chart1.Series("N# COTIZACIONES ENVIADAS").IsValueShownAsLabel = True
        frm.Chart1.Series("N# COTIZACIONES ENVIADAS").LabelBackColor = System.Drawing.Color.Azure

        '====================================== VALOR ==========================================================
        frm.Chart2.Series.Clear()
        frm.Chart2.Series.Add("VALOR TOTAL PERDIDAS")
        frm.Chart2.Series("VALOR TOTAL PERDIDAS").ChartType = SeriesChartType.Column
        'frm.Chart2.Series("VALOR TOTAL PERDIDAS").Points.AddXY(Label59.Text, Val(Label128.Text))
        'frm.Chart2.Series("VALOR TOTAL PERDIDAS").Points.AddXY(Label58.Text, Val(Label127.Text))
        frm.Chart2.Series("VALOR TOTAL PERDIDAS").Points.AddXY(Label57.Text, Val(Label126.Text))
        frm.Chart2.Series("VALOR TOTAL PERDIDAS").Points.AddXY(Label56.Text, Val(Label125.Text))
        frm.Chart2.Series("VALOR TOTAL PERDIDAS").Points.AddXY(Label55.Text, Val(Label124.Text))
        frm.Chart2.Series("VALOR TOTAL PERDIDAS").Points.AddXY(Label44.Text, Val(Label123.Text))
        frm.Chart2.Series("VALOR TOTAL PERDIDAS").Points.AddXY(Label43.Text, Val(Label122.Text))
        frm.Chart2.Series("VALOR TOTAL PERDIDAS").Points.AddXY(Label42.Text, Val(Label121.Text))
        frm.Chart2.Series("VALOR TOTAL PERDIDAS").IsValueShownAsLabel = True
        frm.Chart2.Series("VALOR TOTAL PERDIDAS").LabelFormat = "$ #,#0.00"
        frm.Chart2.Series("VALOR TOTAL PERDIDAS").LabelBackColor = System.Drawing.Color.Azure

        frm.Chart2.Series.Add("VALOR TOTAL PERD POR PRECIO")
        frm.Chart2.Series("VALOR TOTAL PERD POR PRECIO").ChartType = SeriesChartType.Column
        'frm.Chart2.Series("VALOR TOTAL PERD POR PRECIO").Points.AddXY(Label59.Text, Val(Label359.Text))
        'frm.Chart2.Series("VALOR TOTAL PERD POR PRECIO").Points.AddXY(Label58.Text, Val(Label358.Text))
        frm.Chart2.Series("VALOR TOTAL PERD POR PRECIO").Points.AddXY(Label57.Text, Val(Label357.Text))
        frm.Chart2.Series("VALOR TOTAL PERD POR PRECIO").Points.AddXY(Label56.Text, Val(Label356.Text))
        frm.Chart2.Series("VALOR TOTAL PERD POR PRECIO").Points.AddXY(Label55.Text, Val(Label355.Text))
        frm.Chart2.Series("VALOR TOTAL PERD POR PRECIO").Points.AddXY(Label44.Text, Val(Label354.Text))
        frm.Chart2.Series("VALOR TOTAL PERD POR PRECIO").Points.AddXY(Label43.Text, Val(Label353.Text))
        frm.Chart2.Series("VALOR TOTAL PERD POR PRECIO").Points.AddXY(Label42.Text, Val(Label352.Text))
        frm.Chart2.Series("VALOR TOTAL PERD POR PRECIO").IsValueShownAsLabel = True
        frm.Chart2.Series("VALOR TOTAL PERD POR PRECIO").LabelFormat = "$ #,##0.00"
        frm.Chart2.Series("VALOR TOTAL PERD POR PRECIO").LabelBackColor = System.Drawing.Color.Azure

        frm.Chart2.Series.Add("VALOR TOTAL PERD DESISTIO")
        frm.Chart2.Series("VALOR TOTAL PERD DESISTIO").ChartType = SeriesChartType.Column
        'frm.Chart2.Series("VALOR TOTAL PERD DESISTIO").Points.AddXY(Label59.Text, Val(Label407.Text))
        'frm.Chart2.Series("VALOR TOTAL PERD DESISTIO").Points.AddXY(Label58.Text, Val(Label406.Text))
        frm.Chart2.Series("VALOR TOTAL PERD DESISTIO").Points.AddXY(Label57.Text, Val(Label405.Text))
        frm.Chart2.Series("VALOR TOTAL PERD DESISTIO").Points.AddXY(Label56.Text, Val(Label404.Text))
        frm.Chart2.Series("VALOR TOTAL PERD DESISTIO").Points.AddXY(Label55.Text, Val(Label403.Text))
        frm.Chart2.Series("VALOR TOTAL PERD DESISTIO").Points.AddXY(Label44.Text, Val(Label402.Text))
        frm.Chart2.Series("VALOR TOTAL PERD DESISTIO").Points.AddXY(Label43.Text, Val(Label401.Text))
        frm.Chart2.Series("VALOR TOTAL PERD DESISTIO").Points.AddXY(Label42.Text, Val(Label400.Text))
        frm.Chart2.Series("VALOR TOTAL PERD DESISTIO").IsValueShownAsLabel = True
        frm.Chart2.Series("VALOR TOTAL PERD DESISTIO").LabelFormat = "$ #,##0.00"
        frm.Chart2.Series("VALOR TOTAL PERD DESISTIO").LabelBackColor = System.Drawing.Color.Azure

        frm.Chart2.Series.Add("VALOR TOTAL PERD POR CALIDAD")
        frm.Chart2.Series("VALOR TOTAL PERD POR CALIDAD").ChartType = SeriesChartType.Column
        'frm.Chart2.Series("VALOR TOTAL PERD POR CALIDAD").Points.AddXY(Label59.Text, Val(Label455.Text))
        'frm.Chart2.Series("VALOR TOTAL PERD POR CALIDAD").Points.AddXY(Label58.Text, Val(Label454.Text))
        frm.Chart2.Series("VALOR TOTAL PERD POR CALIDAD").Points.AddXY(Label57.Text, Val(Label453.Text))
        frm.Chart2.Series("VALOR TOTAL PERD POR CALIDAD").Points.AddXY(Label56.Text, Val(Label452.Text))
        frm.Chart2.Series("VALOR TOTAL PERD POR CALIDAD").Points.AddXY(Label55.Text, Val(Label451.Text))
        frm.Chart2.Series("VALOR TOTAL PERD POR CALIDAD").Points.AddXY(Label44.Text, Val(Label450.Text))
        frm.Chart2.Series("VALOR TOTAL PERD POR CALIDAD").Points.AddXY(Label43.Text, Val(Label449.Text))
        frm.Chart2.Series("VALOR TOTAL PERD POR CALIDAD").Points.AddXY(Label42.Text, Val(Label448.Text))
        frm.Chart2.Series("VALOR TOTAL PERD POR CALIDAD").IsValueShownAsLabel = True
        frm.Chart2.Series("VALOR TOTAL PERD POR CALIDAD").LabelFormat = "$ #,##0.00"
        frm.Chart2.Series("VALOR TOTAL PERD POR CALIDAD").LabelBackColor = System.Drawing.Color.Azure

        frm.Chart2.Series.Add("VALOR TOTAL PERD POR PLAZO")
        frm.Chart2.Series("VALOR TOTAL PERD POR PLAZO").ChartType = SeriesChartType.Column
        'frm.Chart2.Series("VALOR TOTAL PERD POR PLAZO").Points.AddXY(Label59.Text, Val(Label503.Text))
        'frm.Chart2.Series("VALOR TOTAL PERD POR PLAZO").Points.AddXY(Label58.Text, Val(Label502.Text))
        frm.Chart2.Series("VALOR TOTAL PERD POR PLAZO").Points.AddXY(Label57.Text, Val(Label501.Text))
        frm.Chart2.Series("VALOR TOTAL PERD POR PLAZO").Points.AddXY(Label56.Text, Val(Label500.Text))
        frm.Chart2.Series("VALOR TOTAL PERD POR PLAZO").Points.AddXY(Label55.Text, Val(Label499.Text))
        frm.Chart2.Series("VALOR TOTAL PERD POR PLAZO").Points.AddXY(Label44.Text, Val(Label498.Text))
        frm.Chart2.Series("VALOR TOTAL PERD POR PLAZO").Points.AddXY(Label43.Text, Val(Label497.Text))
        frm.Chart2.Series("VALOR TOTAL PERD POR PLAZO").Points.AddXY(Label42.Text, Val(Label496.Text))
        frm.Chart2.Series("VALOR TOTAL PERD POR PLAZO").IsValueShownAsLabel = True
        frm.Chart2.Series("VALOR TOTAL PERD POR PLAZO").LabelFormat = "$ #,##0.00"
        frm.Chart2.Series("VALOR TOTAL PERD POR PLAZO").LabelBackColor = System.Drawing.Color.Azure

        frm.Chart2.Series.Add("VALOR TOTAL GANADAS")
        frm.Chart2.Series("VALOR TOTAL GANADAS").ChartType = SeriesChartType.Column
        'frm.Chart2.Series("VALOR TOTAL GANADAS").Points.AddXY(Label59.Text, Val(Label189.Text))
        'frm.Chart2.Series("VALOR TOTAL GANADAS").Points.AddXY(Label58.Text, Val(Label188.Text))
        frm.Chart2.Series("VALOR TOTAL GANADAS").Points.AddXY(Label57.Text, Val(Label187.Text))
        frm.Chart2.Series("VALOR TOTAL GANADAS").Points.AddXY(Label56.Text, Val(Label186.Text))
        frm.Chart2.Series("VALOR TOTAL GANADAS").Points.AddXY(Label55.Text, Val(Label185.Text))
        frm.Chart2.Series("VALOR TOTAL GANADAS").Points.AddXY(Label44.Text, Val(Label184.Text))
        frm.Chart2.Series("VALOR TOTAL GANADAS").Points.AddXY(Label43.Text, Val(Label183.Text))
        frm.Chart2.Series("VALOR TOTAL GANADAS").Points.AddXY(Label42.Text, Val(Label182.Text))
        frm.Chart2.Series("VALOR TOTAL GANADAS").IsValueShownAsLabel = True
        frm.Chart2.Series("VALOR TOTAL GANADAS").LabelFormat = "$ #,#0.00"
        frm.Chart2.Series("VALOR TOTAL GANADAS").LabelBackColor = System.Drawing.Color.Azure

        frm.Chart2.Series.Add("VALOR TOTAL POR DEFINIR")
        frm.Chart2.Series("VALOR TOTAL POR DEFINIR").ChartType = SeriesChartType.Column
        'frm.Chart2.Series("VALOR TOTAL POR DEFINIR").Points.AddXY(Label59.Text, Val(Label250.Text))
        'frm.Chart2.Series("VALOR TOTAL POR DEFINIR").Points.AddXY(Label58.Text, Val(Label249.Text))
        frm.Chart2.Series("VALOR TOTAL POR DEFINIR").Points.AddXY(Label57.Text, Val(Label248.Text))
        frm.Chart2.Series("VALOR TOTAL POR DEFINIR").Points.AddXY(Label56.Text, Val(Label247.Text))
        frm.Chart2.Series("VALOR TOTAL POR DEFINIR").Points.AddXY(Label55.Text, Val(Label246.Text))
        frm.Chart2.Series("VALOR TOTAL POR DEFINIR").Points.AddXY(Label44.Text, Val(Label245.Text))
        frm.Chart2.Series("VALOR TOTAL POR DEFINIR").Points.AddXY(Label43.Text, Val(Label244.Text))
        frm.Chart2.Series("VALOR TOTAL POR DEFINIR").Points.AddXY(Label42.Text, Val(Label243.Text))
        frm.Chart2.Series("VALOR TOTAL POR DEFINIR").IsValueShownAsLabel = True
        frm.Chart2.Series("VALOR TOTAL POR DEFINIR").LabelFormat = "$ #,#0.00"
        frm.Chart2.Series("VALOR TOTAL POR DEFINIR").LabelBackColor = System.Drawing.Color.Azure

        frm.Chart2.Series.Add("VALOR TOTAL ENVIADAS")
        frm.Chart2.Series("VALOR TOTAL ENVIADAS").ChartType = SeriesChartType.Column
        'frm.Chart2.Series("VALOR TOTAL ENVIADAS").Points.AddXY(Label59.Text, Val(Label311.Text))
        'frm.Chart2.Series("VALOR TOTAL ENVIADAS").Points.AddXY(Label58.Text, Val(Label310.Text))
        frm.Chart2.Series("VALOR TOTAL ENVIADAS").Points.AddXY(Label57.Text, Val(Label309.Text))
        frm.Chart2.Series("VALOR TOTAL ENVIADAS").Points.AddXY(Label56.Text, Val(Label308.Text))
        frm.Chart2.Series("VALOR TOTAL ENVIADAS").Points.AddXY(Label55.Text, Val(Label307.Text))
        frm.Chart2.Series("VALOR TOTAL ENVIADAS").Points.AddXY(Label44.Text, Val(Label306.Text))
        frm.Chart2.Series("VALOR TOTAL ENVIADAS").Points.AddXY(Label43.Text, Val(Label305.Text))
        frm.Chart2.Series("VALOR TOTAL ENVIADAS").Points.AddXY(Label42.Text, Val(Label304.Text))
        frm.Chart2.Series("VALOR TOTAL ENVIADAS").IsValueShownAsLabel = True
        frm.Chart2.Series("VALOR TOTAL ENVIADAS").LabelFormat = "$ #,#0.00"
        frm.Chart2.Series("VALOR TOTAL ENVIADAS").LabelBackColor = System.Drawing.Color.Azure

        'PREGUNTASYRESPUESTAS
        frm.TextBox1.Text = " 1.- En el tramo de tiempo que va entre el " + " " + Label59.Text + " " + " (incluido) y el" + " " + Label58.Text + " " + " (incluido), cuantas cotizaciones fueron enviadas ?"
        frm.Label2.Text = Val(Label259.Text) + Val(Label258.Text)

        frm.TextBox2.Text = " 2.- Del total de cotizaciones enviadas en el tramo de tiempo que va entre el" + " " + Label59.Text + " " + "(incluido) y el" + " " + Label58.Text + " " +
        " (incluido), cuantas cotizaciones SI han sido definidas a la fecha de hoy " + " " + DateInicio2.Text + "?" + " " + "Esta fechas puede ser definida en cualquier momento entre 
        el día de hoy el algún día posterior al día del inicio del período en análisis."
        frm.Label3.Text = Val(Label66.Text) + Val(Label136.Text) + Val(Label67.Text) + Val(Label137.Text)

        frm.TextBox3.Text = " 3.- Del total de cotizaciones enviadas en el tramo de tiempo que va entre el" + " " + Label59.Text + " " + "(incluido) y el" + " " + Label58.Text + " (incluido), cuantas cotizaciones NO han sido definidas
        a la fecha de hoy " + " " + DateInicio2.Text + "?" + " " + "Esta fechas puede ser definida en cualquier momento entre el día de hoy el algún día posterior al día del inicio del período en análisis."
        frm.Label4.Text = Val(Label198.Text) + Val(Label197.Text)

        frm.TextBox4.Text = "4.- Del total de cotizaciones enviadas en el tramo de tiempo que va entre el" + " " + Label59.Text + " " + "(incluido) y el" + " " + Label58.Text + " " +
        "(incluido), cuantas cotizaciones han sido definidas como perdidas a la fecha de hoy" + " " + DateInicio2.Text + "?" + " " + "Esta fechas puede ser definida en cualquier momento entre el día de hoy el algún día posterior al
        día del inicio del período en análisis."
        frm.Label5.Text = Val(Label66.Text) + Val(Label67.Text)

        frm.TextBox5.Text = "5.- Del total de cotizaciones enviadas en el tramo de tiempo que va entre el" + " " + Label59.Text + " " + "(incluido) y el" + " " + Label58.Text + " 
        (incluido), cuantas cotizaciones han sido definidas como ganadas a la fecha de hoy" + " " + DateInicio2.Text + "?" + " " + "Esta fechas puede ser definida en cualquier momento entre el día de hoy el algún día posterior al
        día del inicio del período en análisis."
        frm.Label6.Text = Val(Label136.Text) + Val(Label137.Text)

        frm.TextBox6.Text = "6.- Del total de cotizaciones enviadas en el tramo de tiempo que va entre el" + " " + Label59.Text + " " + "(incluido) y el" + " " + Label58.Text + "
        (incluido), cuantas cotizaciones de las que han sido definidas como perdidas, han sido perdidas por precio a la fecha de hoy" + " " + DateInicio2.Text + "?" + " " + "Esta fechas puede ser definida en cualquier momento entre el día de hoy 
        el algún día posterior al día del inicio del período en análisis."
        frm.Label7.Text = Val(Label278.Text) + Val(Label279.Text)

        frm.TextBox7.Text = "7.- Del total de cotizaciones enviadas en el tramo de tiempo que va entre el" + " " + Label59.Text + " " + "(incluido) y el" + " " + Label58.Text + "
        (incluido), cuantas cotizaciones de las que han sido definidas como perdidas, han sido perdidas por calidad a la fecha de hoy" + " " + DateInicio2.Text + "?" + " " + "Esta fechas puede ser definida en cualquier momento entre el día de hoy 
        el algún día posterior al día del inicio del período en análisis."
        frm.Label8.Text = Val(Label302.Text) + Val(Label303.Text)

        frm.TextBox8.Text = "8.- Del total de cotizaciones enviadas en el tramo de tiempo que va entre el" + " " + Label59.Text + " " + "(incluido) y el" + " " + Label58.Text + "
        (incluido), cuantas cotizaciones de las que han sido definidas como perdidas, han sido perdidas por plazo a la fecha de hoy" + " " + DateInicio2.Text + "?" + " " + "Esta fechas puede ser definida en cualquier momento entre el día de hoy 
        el algún día posterior al día del inicio del período en análisis."
        frm.Label9.Text = Val(Label295.Text) + Val(Label294.Text)

        frm.TextBox9.Text = "9.- Del total de cotizaciones enviadas en el tramo de tiempo que va entre el" + " " + Label59.Text + " " + "(incluido) y el" + " " + Label58.Text + "
        (incluido), cuantas cotizaciones de las que han sido definidas como perdidas, han sido perdidas por desistio a la fecha de hoy" + " " + DateInicio2.Text + "?" + " " + "Esta fechas puede ser definida en cualquier momento entre el día de hoy 
        el algún día posterior al día del inicio del período en análisis."
        frm.Label10.Text = Val(Label286.Text) + Val(Label287.Text)

        frm.ShowDialog()


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        ' Obtener la fecha actual
        Dim fechaActual As Date = Date.Now

        ' Definir la fecha más antigua (por ejemplo, 6 meses + 1 mes hacia atrás desde la fecha actual)
        Dim fechaAntigua As Date = fechaActual.AddMonths(-7)

        ' Definir el intervalo de meses
        Dim intervalo As Integer = 1 ' Intervalo de 1 mes

        ' Mostrar la fecha actual en un Label
        Label58.Text = fechaActual.ToString("dd-MM-yyyy")

        ' Asignar las fechas a las etiquetas en orden cronológico
        Label504.Text = fechaAntigua.AddMonths(intervalo * 0).ToString("dd-MM-yyyy")
        Label42.Text = fechaAntigua.AddMonths(intervalo * 1).ToString("dd-MM-yyyy")
        Label43.Text = fechaAntigua.AddMonths(intervalo * 2).ToString("dd-MM-yyyy")
        Label44.Text = fechaAntigua.AddMonths(intervalo * 3).ToString("dd-MM-yyyy")
        Label55.Text = fechaAntigua.AddMonths(intervalo * 4).ToString("dd-MM-yyyy")
        Label56.Text = fechaAntigua.AddMonths(intervalo * 5).ToString("dd-MM-yyyy")
        Label57.Text = fechaAntigua.AddMonths(intervalo * 6).ToString("dd-MM-yyyy")



        DateFinal2.Text = Label42.Text
        DateFinal3.Text = Label43.Text
        DateFinal4.Text = Label44.Text
        DateFinal5.Text = Label55.Text
        DateFinal6.Text = Label56.Text
        DateFinal7.Text = Label57.Text
        DateFinal8.Text = Label58.Text
        'DateFinal9.Text = Label59.Text
        DTP1.Text = Label504.Text

        INTERVALOS()
        INTERVALO2()
        INTERVALO3()
        INTERVALO4()
        INTERVALO5()
        INTERVALO6()
        INTERVALO7()
        INTERVALO8()

        '========================= PARA NUMERO DE COTIZACIONES PERDIDAS SEGUN EL INTERVALO=================================
        Label60.Text = DGSeguimiento3.RowCount.ToString()
        Label61.Text = DGSeguimiento4.RowCount.ToString()
        Label62.Text = DGSEguimiento5.RowCount.ToString()
        Label63.Text = DGSeguimiento6.RowCount.ToString()
        Label64.Text = DGSeguimiento7.RowCount.ToString()
        Label65.Text = DGSeguimiento8.RowCount.ToString()
        Label66.Text = DGSeguimiento9.RowCount.ToString()
        Label67.Text = DGSeguimiento10.RowCount.ToString()

        '=========================== PARA NUMERO DE COTIZACION GANADAS ====================================
        Label130.Text = DGOK3.RowCount.ToString()
        Label131.Text = DGOK4.RowCount.ToString()
        Label132.Text = DGOK5.RowCount.ToString()
        Label133.Text = DGOK6.RowCount.ToString()
        Label134.Text = DGOK7.RowCount.ToString()
        Label135.Text = DGOK8.RowCount.ToString()
        Label136.Text = DGOK9.RowCount.ToString()
        Label137.Text = DGOK10.RowCount.ToString()
        '=========================== PARA NUMERO DE COTIZACIONES POR DEFINIR =======================================
        Label191.Text = DGPD1.RowCount.ToString()
        Label192.Text = DGPD2.RowCount.ToString()
        Label193.Text = DGPD3.RowCount.ToString()
        Label194.Text = DGPD4.RowCount.ToString()
        Label195.Text = DGPD5.RowCount.ToString()
        Label196.Text = DGPD6.RowCount.ToString()
        Label197.Text = DGPD7.RowCount.ToString()
        Label198.Text = DGPD8.RowCount.ToString()

        '========================== PARA NUMERO TOTAL DE COTIZACIONES ENVIADAS ======================================
        Label252.Text = Val(Label60.Text) + Val(Label130.Text) + Val(Label191.Text)
        Label253.Text = Val(Label61.Text) + Val(Label131.Text) + Val(Label192.Text)
        Label254.Text = Val(Label62.Text) + Val(Label132.Text) + Val(Label193.Text)
        Label255.Text = Val(Label63.Text) + Val(Label133.Text) + Val(Label194.Text)
        Label256.Text = Val(Label64.Text) + Val(Label134.Text) + Val(Label195.Text)
        Label257.Text = Val(Label65.Text) + Val(Label135.Text) + Val(Label196.Text)
        Label258.Text = Val(Label66.Text) + Val(Label136.Text) + Val(Label197.Text)
        Label259.Text = Val(Label67.Text) + Val(Label137.Text) + Val(Label198.Text)
        '======================PARA CONTAR FILAS SEGUN UN CRITERIO SEGUN DEFINICION ==============================

        PERDIDAS1()
        PERDIDAS2()
        PERDIDAS3()
        PERDIDAS4()
        PERDIDAS5()
        PERDIDAS6()
        PERDIDAS7()
        PERDIDAS8()

        'POR PRECIO
        Label272.Text = DGP1.RowCount.ToString()
        Label273.Text = DGP2.RowCount.ToString()
        Label274.Text = DGP3.RowCount.ToString()
        Label275.Text = DGP4.RowCount.ToString()
        Label276.Text = DGP5.RowCount.ToString()
        Label277.Text = DGP6.RowCount.ToString()
        Label278.Text = DGP7.RowCount.ToString()
        Label279.Text = DGP8.RowCount.ToString()

        'POR DESISTIO
        Label280.Text = DGD1.RowCount.ToString()
        Label281.Text = DGD2.RowCount.ToString()
        Label282.Text = DGD3.RowCount.ToString()
        Label283.Text = DGD4.RowCount.ToString()
        Label284.Text = DGD5.RowCount.ToString()
        Label285.Text = DGD6.RowCount.ToString()
        Label286.Text = DGD7.RowCount.ToString()
        Label287.Text = DGD8.RowCount.ToString()

        'POR CALIDAD
        Label296.Text = DGC1.RowCount.ToString()
        Label297.Text = DGC2.RowCount.ToString()
        Label298.Text = DGC3.RowCount.ToString()
        Label299.Text = DGC4.RowCount.ToString()
        Label300.Text = DGC5.RowCount.ToString()
        Label301.Text = DGC6.RowCount.ToString()
        Label302.Text = DGC7.RowCount.ToString()
        Label303.Text = DGC8.RowCount.ToString()

        'POR PLAZO
        Label288.Text = DGPL1.RowCount.ToString()
        Label289.Text = DGPL2.RowCount.ToString()
        Label290.Text = DGPL3.RowCount.ToString()
        Label291.Text = DGPL4.RowCount.ToString()
        Label292.Text = DGPL5.RowCount.ToString()
        Label293.Text = DGPL6.RowCount.ToString()
        Label294.Text = DGPL7.RowCount.ToString()
        Label295.Text = DGPL8.RowCount.ToString()

        '============================PARA TOTAL DE COTIZACIONES ENVIADAS CON VALOR
        Label304.Text = Val(Label121.Text) + Val(Label182.Text) + Val(Label243.Text)
        Label305.Text = Val(Label122.Text) + Val(Label183.Text) + Val(Label244.Text)
        Label306.Text = Val(Label123.Text) + Val(Label184.Text) + Val(Label245.Text)
        Label307.Text = Val(Label124.Text) + Val(Label185.Text) + Val(Label246.Text)
        Label308.Text = Val(Label125.Text) + Val(Label186.Text) + Val(Label247.Text)
        Label309.Text = Val(Label126.Text) + Val(Label187.Text) + Val(Label248.Text)
        Label310.Text = Val(Label127.Text) + Val(Label188.Text) + Val(Label249.Text)
        Label311.Text = Val(Label128.Text) + Val(Label189.Text) + Val(Label250.Text)

    End Sub

#End Region
#Region "PARA CALCULO DE COTIZACIONES PERDIDAS POR DEFINICION (SEGUN PRECIO, CALIDAD, PLAZO, DESISTIO) "
    Sub PERDIDAS1()
        DateFinal2.Value = DateFinal2.Value
        DateFinal3.Value = DateFinal3.Value
        'PERDIDAS POR PRECIO
        Dim sqlseguimientop1 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONPRECIO WHERE Fecha 
        BETWEEN '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal2.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientop1, DGP1)

        'PERDIDAS POR DESISTIO
        Dim sqlseguimientod1 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONDESISTIO WHERE Fecha 
        BETWEEN '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal2.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientod1, DGD1)

        'PERDIDAS POR CALIDAD
        Dim sqlseguimientoc1 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONCALIDAD WHERE Fecha 
        BETWEEN '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal2.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientoc1, DGC1)

        'PERDIDAS POR PLAZO
        Dim sqlseguimientopl1 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONPLAZO WHERE Fecha 
        BETWEEN '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal2.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientopl1, DGPL1)

        '==========================================================VALOR=================================================================
        Dim sqlPPP1 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONPRECIO WHERE Fecha BETWEEN '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal2.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPP1, DGP11)

        Dim totalPCLP1 As Double = 0
        Dim totalPUSD1 As Double = 0
        Dim totalPEUR1 As Double = 0

        For Each fila As DataGridViewRow In DGP11.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP1 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD1 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR1 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label312.Text = totalPCLP1
        Label320.Text = totalPUSD1
        Label336.Text = totalPEUR1
        Label352.Text = (Val(Label312.Text) + Val(Label328.Text) + Val(Label344.Text)).ToString

        Dim sqlPPD1 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONDESISTIO WHERE Fecha BETWEEN '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal2.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPD1, DGD11)

        Dim totalPCLP2 As Double = 0
        Dim totalPUSD2 As Double = 0
        Dim totalPEUR2 As Double = 0

        For Each fila As DataGridViewRow In DGD11.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP2 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD2 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR2 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label360.Text = totalPCLP2
        Label368.Text = totalPUSD2
        Label384.Text = totalPEUR2
        Label400.Text = (Val(Label360.Text) + Val(Label376.Text) + Val(Label392.Text)).ToString

        Dim sqlPPC1 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONCALIDAD WHERE Fecha BETWEEN '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal2.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPC1, DGC11)

        Dim totalPCLP3 As Double = 0
        Dim totalPUSD3 As Double = 0
        Dim totalPEUR3 As Double = 0

        For Each fila As DataGridViewRow In DGC11.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP3 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD3 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR3 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label408.Text = totalPCLP3
        Label416.Text = totalPUSD3
        Label432.Text = totalPEUR3
        Label448.Text = (Val(Label408.Text) + Val(Label424.Text) + Val(Label440.Text)).ToString

        Dim sqlPPPL1 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONPLAZO WHERE Fecha BETWEEN '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal2.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPPL1, DGPL11)

        Dim totalPCLP4 As Double = 0
        Dim totalPUSD4 As Double = 0
        Dim totalPEUR4 As Double = 0

        For Each fila As DataGridViewRow In DGPL11.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP4 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD4 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR4 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label456.Text = totalPCLP4
        Label464.Text = totalPUSD4
        Label480.Text = totalPEUR4
        Label496.Text = (Val(Label456.Text) + Val(Label472.Text) + Val(Label488.Text)).ToString

    End Sub

    Sub PERDIDAS2()
        DateFinal3.Value = DateFinal3.Value
        DateFinal4.Value = DateFinal4.Value
        'PERDIDAS POR PRECIO
        Dim sqlseguimientop2 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONPRECIO WHERE Fecha 
        BETWEEN '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientop2, DGP2)

        'PERDIDAS POR DESISTIO
        Dim sqlseguimientod2 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONDESISTIO WHERE Fecha 
        BETWEEN '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientod2, DGD2)

        'PERDIDAS POR CALIDAD
        Dim sqlseguimientoc2 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONCALIDAD WHERE Fecha 
        BETWEEN '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientoc2, DGC2)

        'PERDIDAS POR PLAZO
        Dim sqlseguimientopl2 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONPLAZO WHERE Fecha 
        BETWEEN '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientopl2, DGPL2)

        '==========================================================VALOR=================================================================
        Dim sqlPPP2 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONPRECIO WHERE Fecha BETWEEN '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPP2, DGP22)

        Dim totalPCLP11 As Double = 0
        Dim totalPUSD11 As Double = 0
        Dim totalPEUR11 As Double = 0

        For Each fila As DataGridViewRow In DGP22.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP11 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD11 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR11 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label313.Text = totalPCLP11
        Label321.Text = totalPUSD11
        Label337.Text = totalPEUR11
        Label353.Text = (Val(Label313.Text) + Val(Label329.Text) + Val(Label345.Text)).ToString

        Dim sqlPPD2 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONDESISTIO WHERE Fecha BETWEEN '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPD2, DGD22)

        Dim totalPCLP22 As Double = 0
        Dim totalPUSD22 As Double = 0
        Dim totalPEUR22 As Double = 0

        For Each fila As DataGridViewRow In DGD22.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP22 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD22 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR22 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label361.Text = totalPCLP22
        Label369.Text = totalPUSD22
        Label385.Text = totalPEUR22
        Label401.Text = (Val(Label361.Text) + Val(Label377.Text) + Val(Label393.Text)).ToString

        Dim sqlPPC2 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONCALIDAD WHERE Fecha BETWEEN '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPC2, DGC22)

        Dim totalPCLP33 As Double = 0
        Dim totalPUSD33 As Double = 0
        Dim totalPEUR33 As Double = 0

        For Each fila As DataGridViewRow In DGC22.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP33 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD33 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR33 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label409.Text = totalPCLP33
        Label417.Text = totalPUSD33
        Label433.Text = totalPEUR33
        Label449.Text = (Val(Label409.Text) + Val(Label425.Text) + Val(Label441.Text)).ToString

        Dim sqlPPPL2 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONPLAZO WHERE Fecha BETWEEN '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal3.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPPL2, DGPL22)

        Dim totalPCLP44 As Double = 0
        Dim totalPUSD44 As Double = 0
        Dim totalPEUR44 As Double = 0

        For Each fila As DataGridViewRow In DGPL22.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP44 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD44 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR44 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label457.Text = totalPCLP44
        Label465.Text = totalPUSD44
        Label481.Text = totalPEUR44
        Label497.Text = (Val(Label457.Text) + Val(Label473.Text) + Val(Label489.Text)).ToString

    End Sub
    Sub PERDIDAS3()
        DateFinal4.Value = DateFinal4.Value
        DateFinal5.Value = DateFinal5.Value
        'PERDIDAS POR PRECIO
        Dim sqlseguimientop3 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONPRECIO WHERE Fecha 
        BETWEEN '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientop3, DGP3)

        'PERDIDAS POR DESISTIO
        Dim sqlseguimientod3 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONDESISTIO WHERE Fecha 
        BETWEEN '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientod3, DGD3)

        'PERDIDAS POR CALIDAD
        Dim sqlseguimientoc3 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONCALIDAD WHERE Fecha 
        BETWEEN '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientoc3, DGC3)

        'PERDIDAS POR PLAZO
        Dim sqlseguimientopl3 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONPLAZO WHERE Fecha 
        BETWEEN '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientopl3, DGPL3)

        '==========================================================VALOR=================================================================
        Dim sqlPPP3 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONPRECIO WHERE Fecha BETWEEN '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPP3, DGP33)

        Dim totalPCLP111 As Double = 0
        Dim totalPUSD111 As Double = 0
        Dim totalPEUR111 As Double = 0

        For Each fila As DataGridViewRow In DGP33.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP111 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD111 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR111 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label314.Text = totalPCLP111
        Label322.Text = totalPUSD111
        Label338.Text = totalPEUR111
        Label354.Text = (Val(Label314.Text) + Val(Label330.Text) + Val(Label346.Text)).ToString

        Dim sqlPPD3 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONDESISTIO WHERE Fecha BETWEEN '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPD3, DGD33)

        Dim totalPCLP222 As Double = 0
        Dim totalPUSD222 As Double = 0
        Dim totalPEUR222 As Double = 0

        For Each fila As DataGridViewRow In DGD33.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP222 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD222 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR222 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label362.Text = totalPCLP222
        Label370.Text = totalPUSD222
        Label386.Text = totalPEUR222
        Label402.Text = (Val(Label362.Text) + Val(Label378.Text) + Val(Label394.Text)).ToString

        Dim sqlPPC3 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONCALIDAD WHERE Fecha BETWEEN '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPC3, DGC33)

        Dim totalPCLP333 As Double = 0
        Dim totalPUSD333 As Double = 0
        Dim totalPEUR333 As Double = 0

        For Each fila As DataGridViewRow In DGC33.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP333 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD333 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR333 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label410.Text = totalPCLP333
        Label418.Text = totalPUSD333
        Label434.Text = totalPEUR333
        Label450.Text = (Val(Label410.Text) + Val(Label426.Text) + Val(Label442.Text)).ToString

        Dim sqlPPPL3 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONPLAZO WHERE Fecha BETWEEN '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal4.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPPL3, DGPL33)

        Dim totalPCLP444 As Double = 0
        Dim totalPUSD444 As Double = 0
        Dim totalPEUR444 As Double = 0

        For Each fila As DataGridViewRow In DGPL33.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP444 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD444 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR444 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label458.Text = totalPCLP444
        Label466.Text = totalPUSD444
        Label482.Text = totalPEUR444
        Label498.Text = (Val(Label458.Text) + Val(Label474.Text) + Val(Label490.Text)).ToString

    End Sub
    Sub PERDIDAS4()
        DateFinal5.Value = DateFinal5.Value
        DateFinal6.Value = DateFinal6.Value
        'PERDIDAS POR PRECIO
        Dim sqlseguimientop4 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONPRECIO WHERE Fecha 
        BETWEEN '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientop4, DGP4)

        'PERDIDAS POR DESISTIO
        Dim sqlseguimientod4 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONDESISTIO WHERE Fecha 
        BETWEEN '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientod4, DGD4)

        'PERDIDAS POR CALIDAD
        Dim sqlseguimientoc4 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONCALIDAD WHERE Fecha 
        BETWEEN '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientoc4, DGC4)

        'PERDIDAS POR PLAZO
        Dim sqlseguimientopl4 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONPLAZO WHERE Fecha 
        BETWEEN '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientopl4, DGPL4)

        '==========================================================VALOR=================================================================
        Dim sqlPPP4 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONPRECIO WHERE Fecha BETWEEN '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPP4, DGP44)

        Dim totalPCLP12 As Double = 0
        Dim totalPUSD13 As Double = 0
        Dim totalPEUR14 As Double = 0

        For Each fila As DataGridViewRow In DGP44.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP12 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD13 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR14 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label315.Text = totalPCLP12
        Label323.Text = totalPUSD13
        Label339.Text = totalPEUR14
        Label355.Text = (Val(Label315.Text) + Val(Label331.Text) + Val(Label347.Text)).ToString

        Dim sqlPPD4 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONDESISTIO WHERE Fecha BETWEEN '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPD4, DGD44)

        Dim totalPCLP28 As Double = 0
        Dim totalPUSD25 As Double = 0
        Dim totalPEUR26 As Double = 0

        For Each fila As DataGridViewRow In DGD44.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP28 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD25 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR26 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label363.Text = totalPCLP28
        Label371.Text = totalPUSD25
        Label387.Text = totalPEUR26
        Label403.Text = (Val(Label363.Text) + Val(Label379.Text) + Val(Label395.Text)).ToString

        Dim sqlPPC4 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONCALIDAD WHERE Fecha BETWEEN '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPC4, DGC44)

        Dim totalPCLP37 As Double = 0
        Dim totalPUSD38 As Double = 0
        Dim totalPEUR39 As Double = 0

        For Each fila As DataGridViewRow In DGC44.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP37 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD38 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR39 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label411.Text = totalPCLP37
        Label419.Text = totalPUSD38
        Label435.Text = totalPEUR39
        Label451.Text = (Val(Label411.Text) + Val(Label427.Text) + Val(Label443.Text)).ToString

        Dim sqlPPPL4 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONPLAZO WHERE Fecha BETWEEN '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal5.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPPL4, DGPL44)

        Dim totalPCLP46 As Double = 0
        Dim totalPUSD47 As Double = 0
        Dim totalPEUR48 As Double = 0

        For Each fila As DataGridViewRow In DGPL44.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP46 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD47 += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR48 += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label459.Text = totalPCLP46
        Label467.Text = totalPUSD47
        Label483.Text = totalPEUR48
        Label499.Text = (Val(Label459.Text) + Val(Label475.Text) + Val(Label491.Text)).ToString
    End Sub
    Sub PERDIDAS5()
        DateFinal6.Value = DateFinal6.Value
        DateFinal7.Value = DateFinal7.Value
        'PERDIDAS POR PRECIO
        Dim sqlseguimientop5 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONPRECIO WHERE Fecha 
        BETWEEN '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientop5, DGP5)

        'PERDIDAS POR DESISTIO
        Dim sqlseguimientod5 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONDESISTIO WHERE Fecha 
        BETWEEN '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientod5, DGD5)

        'PERDIDAS POR CALIDAD
        Dim sqlseguimientoc5 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONCALIDAD WHERE Fecha 
        BETWEEN '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientoc5, DGC5)

        'PERDIDAS POR PLAZO
        Dim sqlseguimientopl5 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONPLAZO WHERE Fecha 
        BETWEEN '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientopl5, DGPL5)

        '==========================================================VALOR=================================================================
        Dim sqlPPP5 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONPRECIO WHERE Fecha BETWEEN '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPP5, DGP55)

        Dim totalPCLP1a As Double = 0
        Dim totalPUSD1b As Double = 0
        Dim totalPEUR1c As Double = 0

        For Each fila As DataGridViewRow In DGP55.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP1a += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD1b += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR1c += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label316.Text = totalPCLP1a
        Label324.Text = totalPUSD1b
        Label340.Text = totalPEUR1c
        Label356.Text = (Val(Label316.Text) + Val(Label332.Text) + Val(Label348.Text)).ToString

        Dim sqlPPD5 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONDESISTIO WHERE Fecha BETWEEN '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPD5, DGD55)

        Dim totalPCLP2a As Double = 0
        Dim totalPUSD2b As Double = 0
        Dim totalPEUR2c As Double = 0

        For Each fila As DataGridViewRow In DGD55.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP2a += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD2b += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR2c += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label364.Text = totalPCLP2a
        Label372.Text = totalPUSD2b
        Label388.Text = totalPEUR2c
        Label404.Text = (Val(Label364.Text) + Val(Label380.Text) + Val(Label396.Text)).ToString

        Dim sqlPPC5 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONCALIDAD WHERE Fecha BETWEEN '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPC5, DGC55)

        Dim totalPCLP3a As Double = 0
        Dim totalPUSD3b As Double = 0
        Dim totalPEUR3c As Double = 0

        For Each fila As DataGridViewRow In DGC55.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP3a += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD3b += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR3c += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label412.Text = totalPCLP3a
        Label420.Text = totalPUSD3b
        Label436.Text = totalPEUR3c
        Label452.Text = (Val(Label412.Text) + Val(Label428.Text) + Val(Label444.Text)).ToString

        Dim sqlPPPL5 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONPLAZO WHERE Fecha BETWEEN '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal6.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPPL5, DGPL55)

        Dim totalPCLP4a As Double = 0
        Dim totalPUSD4b As Double = 0
        Dim totalPEUR4c As Double = 0

        For Each fila As DataGridViewRow In DGPL55.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP4a += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD4b += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR4c += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label460.Text = totalPCLP4a
        Label468.Text = totalPUSD4b
        Label484.Text = totalPEUR4c
        Label500.Text = (Val(Label460.Text) + Val(Label476.Text) + Val(Label492.Text)).ToString
    End Sub
    Sub PERDIDAS6()
        DateFinal7.Value = DateFinal7.Value
        DateFinal8.Value = DateFinal8.Value
        'PERDIDAS POR PRECIO
        Dim sqlseguimientop6 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONPRECIO WHERE Fecha 
        BETWEEN '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientop6, DGP6)

        'PERDIDAS POR DESISTIO
        Dim sqlseguimientod6 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONDESISTIO WHERE Fecha 
        BETWEEN '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientod6, DGD6)

        'PERDIDAS POR CALIDAD
        Dim sqlseguimientoc6 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONCALIDAD WHERE Fecha 
        BETWEEN '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientoc6, DGC6)

        'PERDIDAS POR PLAZO
        Dim sqlseguimientopl6 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONPLAZO WHERE Fecha 
        BETWEEN '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientopl6, DGPL6)

        '==========================================================VALOR=================================================================
        Dim sqlPPP6 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONPRECIO WHERE Fecha BETWEEN '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPP6, DGP66)

        Dim totalPCLP1r As Double = 0
        Dim totalPUSD1t As Double = 0
        Dim totalPEUR1s As Double = 0

        For Each fila As DataGridViewRow In DGP66.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP1r += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD1t += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR1s += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label317.Text = totalPCLP1r
        Label325.Text = totalPUSD1t
        Label341.Text = totalPEUR1s
        Label357.Text = (Val(Label317.Text) + Val(Label333.Text) + Val(Label349.Text)).ToString

        Dim sqlPPD6 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONDESISTIO WHERE Fecha BETWEEN '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPD6, DGD66)

        Dim totalPCLP2r As Double = 0
        Dim totalPUSD2t As Double = 0
        Dim totalPEUR2s As Double = 0

        For Each fila As DataGridViewRow In DGD66.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP2r += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD2t += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR2s += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label365.Text = totalPCLP2r
        Label373.Text = totalPUSD2t
        Label389.Text = totalPEUR2s
        Label405.Text = (Val(Label365.Text) + Val(Label381.Text) + Val(Label397.Text)).ToString

        Dim sqlPPC6 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONCALIDAD WHERE Fecha BETWEEN '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPC6, DGC66)

        Dim totalPCLP3r As Double = 0
        Dim totalPUSD3t As Double = 0
        Dim totalPEUR3s As Double = 0

        For Each fila As DataGridViewRow In DGC66.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP3r += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD3t += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR3s += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label413.Text = totalPCLP3r
        Label421.Text = totalPUSD3t
        Label437.Text = totalPEUR3s
        Label453.Text = (Val(Label413.Text) + Val(Label429.Text) + Val(Label445.Text)).ToString

        Dim sqlPPPL6 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONPLAZO WHERE Fecha BETWEEN '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal7.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPPL6, DGPL66)

        Dim totalPCLP4r As Double = 0
        Dim totalPUSD4t As Double = 0
        Dim totalPEUR4s As Double = 0

        For Each fila As DataGridViewRow In DGPL66.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP4r += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD4t += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR4s += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label461.Text = totalPCLP4r
        Label469.Text = totalPUSD4t
        Label485.Text = totalPEUR4s
        Label501.Text = (Val(Label461.Text) + Val(Label477.Text) + Val(Label493.Text)).ToString
    End Sub
    Sub PERDIDAS7()
        DateFinal8.Value = DateFinal8.Value
        DateFinal9.Value = DateFinal9.Value
        'PERDIDAS POR PRECIO
        Dim sqlseguimientop7 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONPRECIO WHERE Fecha 
        BETWEEN '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientop7, DGP7)

        'PERDIDAS POR DESISTIO
        Dim sqlseguimientod7 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONDESISTIO WHERE Fecha 
        BETWEEN '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientod7, DGD7)

        'PERDIDAS POR CALIDAD
        Dim sqlseguimientoc7 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONCALIDAD WHERE Fecha 
        BETWEEN '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientoc7, DGC7)

        'PERDIDAS POR PLAZO
        Dim sqlseguimientopl7 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONPLAZO WHERE Fecha 
        BETWEEN '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientopl7, DGPL7)


        '==========================================================VALOR=================================================================
        Dim sqlPPP7 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONPRECIO WHERE Fecha BETWEEN '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPP7, DGP77)

        Dim totalPCLP1q As Double = 0
        Dim totalPUSD1w As Double = 0
        Dim totalPEUR1e As Double = 0

        For Each fila As DataGridViewRow In DGP77.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP1q += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD1w += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR1e += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label318.Text = totalPCLP1q
        Label326.Text = totalPUSD1w
        Label342.Text = totalPEUR1e
        Label358.Text = (Val(Label318.Text) + Val(Label334.Text) + Val(Label350.Text)).ToString

        Dim sqlPPD7 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONDESISTIO WHERE Fecha BETWEEN '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPD7, DGD77)

        Dim totalPCLP2q As Double = 0
        Dim totalPUSD2w As Double = 0
        Dim totalPEUR2e As Double = 0

        For Each fila As DataGridViewRow In DGD77.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP2q += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD2w += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR2e += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label366.Text = totalPCLP2q
        Label374.Text = totalPUSD2w
        Label390.Text = totalPEUR2e
        Label406.Text = (Val(Label366.Text) + Val(Label382.Text) + Val(Label398.Text)).ToString

        Dim sqlPPC7 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONCALIDAD WHERE Fecha BETWEEN '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPC7, DGC77)

        Dim totalPCLP3q As Double = 0
        Dim totalPUSD3w As Double = 0
        Dim totalPEUR3e As Double = 0

        For Each fila As DataGridViewRow In DGC77.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP3q += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD3w += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR3e += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label414.Text = totalPCLP3q
        Label422.Text = totalPUSD3w
        Label438.Text = totalPEUR3e
        Label454.Text = (Val(Label414.Text) + Val(Label430.Text) + Val(Label446.Text)).ToString

        Dim sqlPPPL7 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONPLAZO WHERE Fecha BETWEEN '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal8.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPPL7, DGPL77)

        Dim totalPCLP4q As Double = 0
        Dim totalPUSD4w As Double = 0
        Dim totalPEUR4e As Double = 0

        For Each fila As DataGridViewRow In DGPL77.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP4q += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD4w += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR4e += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label462.Text = totalPCLP4q
        Label470.Text = totalPUSD4w
        Label486.Text = totalPEUR4e
        Label502.Text = (Val(Label462.Text) + Val(Label478.Text) + Val(Label494.Text)).ToString
    End Sub
    Sub PERDIDAS8()
        DateFinal9.Value = DateFinal9.Value
        DTP1.Value = DTP1.Value
        'PERDIDAS POR PRECIO
        Dim sqlseguimientop8 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONPRECIO WHERE Fecha 
        BETWEEN '" & DTP1.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientop8, DGP8)

        'PERDIDAS POR DESISTIO
        Dim sqlseguimientod8 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONDESISTIO WHERE Fecha 
        BETWEEN '" & DTP1.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientod8, DGD8)

        'PERDIDAS POR CALIDAD
        Dim sqlseguimientoc8 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONCALIDAD WHERE Fecha 
        BETWEEN '" & DTP1.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientoc8, DGC8)

        'PERDIDAS POR PLAZO
        Dim sqlseguimientopl8 As String = " Select Distinct Cotizacion
        ,Fecha, Atencion,Definicion FROM TSADATADEFINICIONPLAZO WHERE Fecha 
        BETWEEN '" & DTP1.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlseguimientopl8, DGPL8)

        '==========================================================VALOR=================================================================
        Dim sqlPPP8 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONPRECIO WHERE Fecha BETWEEN '" & DTP1.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPP8, DGP88)

        Dim totalPCLP1f As Double = 0
        Dim totalPUSD1g As Double = 0
        Dim totalPEUR1h As Double = 0

        For Each fila As DataGridViewRow In DGP88.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP1f += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD1g += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR1h += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label319.Text = totalPCLP1f
        Label327.Text = totalPUSD1g
        Label343.Text = totalPEUR1h
        Label359.Text = (Val(Label319.Text) + Val(Label335.Text) + Val(Label351.Text)).ToString

        Dim sqlPPD8 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONDESISTIO WHERE Fecha BETWEEN '" & DTP1.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPD8, DGD88)

        Dim totalPCLP2f As Double = 0
        Dim totalPUSD2g As Double = 0
        Dim totalPEUR2h As Double = 0

        For Each fila As DataGridViewRow In DGD88.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP2f += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD2g += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR2h += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label367.Text = totalPCLP2f
        Label375.Text = totalPUSD2g
        Label391.Text = totalPEUR2h
        Label407.Text = (Val(Label367.Text) + Val(Label383.Text) + Val(Label399.Text)).ToString

        Dim sqlPPC8 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONCALIDAD WHERE Fecha BETWEEN '" & DTP1.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPC8, DGC88)

        Dim totalPCLP3f As Double = 0
        Dim totalPUSD3g As Double = 0
        Dim totalPEUR3h As Double = 0

        For Each fila As DataGridViewRow In DGC88.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP3f += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD3g += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR3h += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label415.Text = totalPCLP3f
        Label423.Text = totalPUSD3g
        Label439.Text = totalPEUR3h
        Label455.Text = (Val(Label415.Text) + Val(Label431.Text) + Val(Label447.Text)).ToString

        Dim sqlPPPL8 As String = "Select Cotizacion, Fecha, Atencion, (Cantidad*Precio) as Total, Moneda
        FROM TSADATADEFINICIONPLAZO WHERE Fecha BETWEEN '" & DTP1.Value.ToString("yyyy-MM-dd") & "' AND '" & DateFinal9.Value.ToString("yyyy-MM-dd") & "' ORDER BY Fecha "

        Cargar_MySQLseguimiento(sqlPPPL8, DGPL88)

        Dim totalPCLP4f As Double = 0
        Dim totalPUSD4g As Double = 0
        Dim totalPEUR4h As Double = 0

        For Each fila As DataGridViewRow In DGPL88.Rows
            If fila.Cells("Total").Value Is Nothing Then
                Exit Sub
            ElseIf fila.Cells("Moneda").Value = "CLP" Then
                totalPCLP4f += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "USD" Then
                totalPUSD4g += Convert.ToDouble(fila.Cells("Total").Value)
            ElseIf fila.Cells("Moneda").Value = "EUR" Then
                totalPEUR4h += Convert.ToDouble(fila.Cells("Total").Value)
            End If
        Next
        Label463.Text = totalPCLP4f
        Label471.Text = totalPUSD4g
        Label487.Text = totalPEUR4h
        Label503.Text = (Val(Label463.Text) + Val(Label479.Text) + Val(Label495.Text)).ToString
    End Sub
#End Region
End Class