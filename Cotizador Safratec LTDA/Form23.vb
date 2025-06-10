Imports Microsoft.Office.Interop.Excel
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Runtime.InteropServices
Imports System.Text
Imports DataTable = System.Data.DataTable

Public Class Form23
    'Dim cadena2 As String = "Server = 201.148.105.186; Database = safratec_SAFRATECBD; Uid = safratec_admin2022; Pwd = 17543593Apple"
    Dim cadena2 As String = "Server = 162.144.3.49; Database = tsachile_cotizador; Uid = tsachile_admin; Pwd = 17543593apple"
    'Public conex As New MySqlConnection("Server = 201.148.105.186; Database = safratec_SAFRATECBD; Uid = safratec_admin2022; Pwd = 17543593Apple")
    ' Por medio de este objeto voy a enviar todos los comandos de SQL a la tabla por medio de la conexión
    Public comm As New MySqlCommand
    Public conex As New MySqlConnection("Server = 162.144.3.49; Database = tsachile_cotizador; Uid = tsachile_admin; Pwd = 17543593apple")
    ' Cambia esto a tu cadena de conexión a la base de datos MySQL.
    Dim connectionString As String = "Server = 162.144.3.49; Database = tsachile_cotizador; Uid = tsachile_admin; Pwd = 17543593apple"
    Private Sub BtnImportar_Click_1(sender As Object, e As EventArgs) Handles BtnImportar.Click
        ImportarExcel()
    End Sub
    Private Sub ImportarExcel()
        Dim openfiledialog1 As New OpenFileDialog()
        openfiledialog1.Filter = "Excel Files (*.xls, *.xlsx)|*.xls;*.xlsx|All files (*.*)|*.*"
        openfiledialog1.FilterIndex = 2
        openfiledialog1.RestoreDirectory = True

        If openfiledialog1.ShowDialog() = DialogResult.OK Then
            Dim excelApp As Microsoft.Office.Interop.Excel.Application = Nothing
            Dim excelWorkbook As Microsoft.Office.Interop.Excel.Workbook = Nothing
            Dim excelWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = Nothing

            Try
                Dim path As String = openfiledialog1.FileName
                excelApp = New Microsoft.Office.Interop.Excel.Application()
                excelWorkbook = excelApp.Workbooks.Open(path)
                excelWorkSheet = CType(excelWorkbook.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

                Dim dt As New Data.DataTable()
                dt.Columns.Add("Codigo")
                dt.Columns.Add("Descripcion")
                dt.Columns.Add("Unidad")
                dt.Columns.Add("Cantidad")
                dt.Columns.Add("Precio Unitario", GetType(Decimal)) ' Especificamos el tipo de dato
                dt.Columns.Add("Total EXW", GetType(Decimal)) ' Especificamos el tipo de dato
                dt.Columns.Add("TotalEXW + Transporte", GetType(Decimal)) ' Especificamos el tipo de dato
                dt.Columns.Add("Nuevo Precio Unitario", GetType(Decimal)) ' Especificamos el tipo de dato
                dt.Columns.Add("20%", GetType(Decimal)) ' Especificamos el tipo de dato
                dt.Columns.Add("30%", GetType(Decimal)) ' Especificamos el tipo de dato
                dt.Columns.Add("40%", GetType(Decimal)) ' Especificamos el tipo de dato
                dt.Columns.Add("50%", GetType(Decimal)) ' Especificamos el tipo de dato
                dt.Columns.Add("20% $", GetType(Decimal)) ' Especificamos el tipo de dato
                dt.Columns.Add("30% $", GetType(Decimal)) ' Especificamos el tipo de dato
                dt.Columns.Add("40% $", GetType(Decimal)) ' Especificamos el tipo de dato
                dt.Columns.Add("50% $", GetType(Decimal)) ' Especificamos el tipo de dato

                For i As Integer = 2 To excelWorkSheet.UsedRange.Rows.Count
                    Dim dr As DataRow = dt.NewRow()
                    dr("Codigo") = If(excelWorkSheet.Cells(i, 3).Value IsNot Nothing, excelWorkSheet.Cells(i, 3).Value.ToString(), DBNull.Value)
                    dr("Descripcion") = If(excelWorkSheet.Cells(i, 4).Value IsNot Nothing, excelWorkSheet.Cells(i, 4).Value.ToString(), DBNull.Value)
                    dr("Unidad") = If(excelWorkSheet.Cells(i, 5).Value IsNot Nothing, excelWorkSheet.Cells(i, 5).Value.ToString(), DBNull.Value)
                    dr("Cantidad") = If(excelWorkSheet.Cells(i, 6).Value IsNot Nothing, excelWorkSheet.Cells(i, 6).Value, DBNull.Value)
                    dr("Precio Unitario") = If(excelWorkSheet.Cells(i, 7).Value IsNot Nothing, excelWorkSheet.Cells(i, 7).Value, DBNull.Value)
                    dr("Total EXW") = If(excelWorkSheet.Cells(i, 8).Value IsNot Nothing, excelWorkSheet.Cells(i, 8).Value, DBNull.Value)
                    dr("TotalEXW + Transporte") = If(excelWorkSheet.Cells(i, 9).Value IsNot Nothing, excelWorkSheet.Cells(i, 9).Value, DBNull.Value)
                    dr("Nuevo Precio Unitario") = If(excelWorkSheet.Cells(i, 10).Value IsNot Nothing, excelWorkSheet.Cells(i, 10).Value, DBNull.Value)
                    dr("20%") = If(excelWorkSheet.Cells(i, 11).Value IsNot Nothing, excelWorkSheet.Cells(i, 11).Value, DBNull.Value)
                    dr("30%") = If(excelWorkSheet.Cells(i, 12).Value IsNot Nothing, excelWorkSheet.Cells(i, 12).Value, DBNull.Value)
                    dr("40%") = If(excelWorkSheet.Cells(i, 13).Value IsNot Nothing, excelWorkSheet.Cells(i, 13).Value, DBNull.Value)
                    dr("50%") = If(excelWorkSheet.Cells(i, 14).Value IsNot Nothing, excelWorkSheet.Cells(i, 14).Value, DBNull.Value)
                    dr("20% $") = If(excelWorkSheet.Cells(i, 15).Value IsNot Nothing, excelWorkSheet.Cells(i, 15).Value, DBNull.Value)
                    dr("30% $") = If(excelWorkSheet.Cells(i, 16).Value IsNot Nothing, excelWorkSheet.Cells(i, 16).Value, DBNull.Value)
                    dr("40% $") = If(excelWorkSheet.Cells(i, 17).Value IsNot Nothing, excelWorkSheet.Cells(i, 17).Value, DBNull.Value)
                    dr("50% $") = If(excelWorkSheet.Cells(i, 18).Value IsNot Nothing, excelWorkSheet.Cells(i, 18).Value, DBNull.Value)
                    dt.Rows.Add(dr)
                Next

                DGImportar.DataSource = dt
                DGImportar.Columns(4).DefaultCellStyle.Format = "USD #,##0.00"

                DGImportar.Columns(5).DefaultCellStyle.Format = "USD #,##0.00"
                DGImportar.Columns(6).DefaultCellStyle.Format = "USD #,##0.00"
                DGImportar.Columns(7).DefaultCellStyle.Format = "USD #,##0.00"
                DGImportar.Columns(8).DefaultCellStyle.Format = "USD #,##0.00"
                DGImportar.Columns(9).DefaultCellStyle.Format = "USD #,##0.00"
                DGImportar.Columns(10).DefaultCellStyle.Format = "USD #,##0.00"
                DGImportar.Columns(11).DefaultCellStyle.Format = "USD #,##0.00"

                DGImportar.Columns(12).DefaultCellStyle.Format = "$ #,##0.00"
                DGImportar.Columns(13).DefaultCellStyle.Format = "$ #,##0.00"
                DGImportar.Columns(14).DefaultCellStyle.Format = "$ #,##0.00"
                DGImportar.Columns(15).DefaultCellStyle.Format = "$ #,##0.00"

                ' Agrega una columna de checkbox al DataGridView
                Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
                checkBoxColumn.HeaderText = "Seleccionar"
                checkBoxColumn.Name = "checkBoxColumn"
                DGImportar.Columns.Insert(0, checkBoxColumn)

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            Finally
                ' Clean up Excel objects
                If excelWorkSheet IsNot Nothing Then Marshal.ReleaseComObject(excelWorkSheet)
                If excelWorkbook IsNot Nothing Then
                    excelWorkbook.Close(SaveChanges:=False)
                    Marshal.ReleaseComObject(excelWorkbook)
                End If
                If excelApp IsNot Nothing Then
                    excelApp.Quit()
                    Marshal.ReleaseComObject(excelApp)
                End If
            End Try
        End If
    End Sub

    Private Sub Form23_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TxtCot.Text = Format(Now, "yyyyMMdd")
        TxtFecha.Text = Format(Now, "yyyy/MM/dd")
        TxtRazon.Select()

        Using cnx As New MySqlConnection(cadena2)
            Dim conexion2 As New MySqlDataAdapter("select distinct Vendedores,Mail,Telefono,Inicial,Pagina from Vendedores", cnx)
            Dim dtx As New Data.DataTable("Vendedores")
            conexion2.Fill(dtx)
            CboContacto.DataSource = dtx
            CboContacto.DisplayMember = "Vendedores"
            CboContacto.Refresh()

            Dim connection As New MySqlDataAdapter("select distinct LUGAR_ENTREGA,D_entrega from Lugar", cnx)
            Dim dtz As New Data.DataTable("Lugar")
            connection.Fill(dtz)
            CboLugar.DataSource = dtz
            CboLugar.DisplayMember = "LUGAR_ENTREGA"
            CboLugar.Refresh()

            Dim union As New MySqlDataAdapter("select  distinct condiciones from Pago", cnx)
            Dim dth As New Data.DataTable("Pago")
            union.Fill(dth)
            Cbopago.DataSource = dth
            Cbopago.DisplayMember = "condiciones"
            Cbopago.Refresh()

            Dim vans As New MySqlDataAdapter("select distinct validez from Validez", cnx)
            Dim dtk As New Data.DataTable("Validez")
            vans.Fill(dtk)
            CboValidez.DataSource = dtk
            CboValidez.DisplayMember = "validez"
            CboValidez.Refresh()

            Dim trato As New MySqlDataAdapter("Select Distinct Trato from Trato", cnx)
            Dim abc As New Data.DataTable("Trato")
            trato.Fill(abc)
            ComboBox4.DataSource = abc
            ComboBox4.DisplayMember = "Trato"
            ComboBox4.Refresh()

            Dim genero As New MySqlDataAdapter("Select Distinct Genero from Genero", cnx)
            Dim fgd As New Data.DataTable("Genero")
            genero.Fill(fgd)
            ComboBox2.DataSource = fgd
            ComboBox2.DisplayMember = "Genero"
            ComboBox2.Refresh()

            Dim objetivo As New MySqlDataAdapter("Select distinct Objetivo from Objetivo", cnx)
            Dim sss As New Data.DataTable("Objetivo")
            objetivo.Fill(sss)
            ComboBox3.DataSource = sss
            ComboBox3.DisplayMember = "Objetivo"
            ComboBox3.Refresh()

        End Using


        'Para limpiar Combobox y TextBox
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        ComboBox5.Text = ""
        ComboBox6.Text = ""
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
    End Sub
    Private Sub CboContacto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboContacto.SelectedIndexChanged
        Me.TxtphoneV.Text = CType(Me.CboContacto.DataSource, Data.DataTable).Rows(Me.CboContacto.SelectedIndex)("Telefono") 'TELEFONO VENDEDOR
        Me.TxtCorreoV.Text = CType(Me.CboContacto.DataSource, Data.DataTable).Rows(Me.CboContacto.SelectedIndex)("Mail") 'Correo Vendedor
        Me.TxtWeb.Text = CType(Me.CboContacto.DataSource, Data.DataTable).Rows(Me.CboContacto.SelectedIndex)("Pagina") 'PAGINA WEB
        Me.Txtcot2.Text = CType(Me.CboContacto.DataSource, Data.DataTable).Rows(Me.CboContacto.SelectedIndex)("Inicial") 'INICIAL DE VENDEDOR
    End Sub

    Private Sub CboLugar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboLugar.SelectedIndexChanged
        Me.TxtDireccionEntrega.Text = CType(Me.CboLugar.DataSource, Data.DataTable).Rows(Me.CboLugar.SelectedIndex)("D_entrega") ' Direccion entrega
    End Sub

    Private Sub DGVatencion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVatencion.CellContentClick
        'On Error Resume Next
        Dim fila As Integer
        fila = DGVatencion.CurrentRow.Index
        TxtAtencion.Text = Me.DGVatencion.Item(3, fila).Value
        TxtDireccion.Text = Me.DGVatencion.Item(4, fila).Value
        TxtphoneC.Text = Me.DGVatencion.Item(5, fila).Value
        TxtCorreoC.Text = Me.DGVatencion.Item(6, fila).Value
        TextBox163.Text = Me.DGVatencion.Item(0, fila).Value
        TextBox162.Text = Me.DGVatencion.Item(7, fila).Value
        ComboBox3.Text = Me.DGVatencion.Item(8, fila).Value
        ComboBox1.Text = Me.DGVatencion.Item(9, fila).Value
        ComboBox5.Text = Me.DGVatencion.Item(10, fila).Value
        ComboBox2.Text = Me.DGVatencion.Item(11, fila).Value
        ComboBox4.Text = Me.DGVatencion.Item(12, fila).Value

    End Sub

    Private Sub DGRazonSocial_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGRazonSocial.CellContentClick
        'On Error Resume Next
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
    Private Sub TxtRazon_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtRazon.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim Razon As String = TxtRazon.Text.ToString
            Dim sqlcliente As String = " Select * From  Clientes where Razon_Social Like '%" & Razon & "%' "

            Cargar_MySQLCliente(sqlcliente, DGRazonSocial)
        End If
    End Sub

    Private excelApp As Microsoft.Office.Interop.Excel.Application = Nothing
    Private excelWorkbook As Microsoft.Office.Interop.Excel.Workbook = Nothing
    Private excelWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = Nothing

    Private Sub ExportToExcelButton_Click(sender As Object, e As EventArgs) Handles ExportToExcelButton.Click
        Dim selectedRows As New List(Of DataRow)()

        ' Obtener filas seleccionadas
        For Each row As DataGridViewRow In DGImportar.Rows
            Dim checkBoxCell As DataGridViewCheckBoxCell = TryCast(row.Cells("checkBoxColumn"), DataGridViewCheckBoxCell)
            If checkBoxCell IsNot Nothing AndAlso checkBoxCell.Value = True Then
                selectedRows.Add(DirectCast(row.DataBoundItem, DataRowView).Row)
            End If
        Next

        If selectedRows.Count > 0 Then
            ' Crear un nuevo DataTable con las filas seleccionadas
            Dim selectedRowsDataTable As DataTable = selectedRows.CopyToDataTable()

            ' Exportar a Excel
            ExportToExcel(selectedRowsDataTable)
        Else
            MessageBox.Show("No se ha seleccionado ninguna fila para exportar.", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ExportToExcel(dataTable As DataTable)
        Try
            If excelApp Is Nothing Then
                excelApp = New Microsoft.Office.Interop.Excel.Application()
            End If

            excelWorkbook = excelApp.Workbooks.Add()
            excelWorkSheet = CType(excelWorkbook.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

            ' Escribir datos en el archivo de Excel usando StringBuilder
            Dim sb As New StringBuilder()

            For Each row As DataRow In dataTable.Rows
                For i As Integer = 0 To dataTable.Columns.Count - 1
                    sb.Append(row(i).ToString())
                    sb.Append(ControlChars.Tab)
                Next
                sb.AppendLine()
            Next

            ' Escribir datos en Excel
            Dim data As String = sb.ToString()
            Dim clipboardData As IDataObject = New DataObject()
            clipboardData.SetData(DataFormats.Text, data)
            Clipboard.SetDataObject(clipboardData)

            excelWorkSheet.Paste()

            ' Guardar el archivo de Excel
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx"
            saveFileDialog.FilterIndex = 1
            saveFileDialog.RestoreDirectory = True

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                excelWorkbook.SaveAs(saveFileDialog.FileName)
                MessageBox.Show("Los datos se han exportado exitosamente a Excel.", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al exportar a Excel: " & ex.Message, "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
