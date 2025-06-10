Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.Office.Interop
Imports MySql.Data.MySqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class Form17
    Private Const A As String = "INSERT INTO Atenciones(Razon_Social,RUT,Atencion,Direccion,Telefono,Correo,Cargo,Objeto,Tipo,Clase,Genero,Trato) VALUES ('"

    Dim cadena2 As String = "Server = 162.144.3.49; Database = tsachile_cotizador; Uid = tsachile_admin; Pwd = 17543593apple"
    'Declaro e inicializo objeto para hacer la conexion a mi base datos de cpanel por medio MySQL 
    Public conex As New MySqlConnection("Server = 162.144.3.49; Database = tsachile_cotizador; Uid = tsachile_admin; Pwd = 17543593apple")
    ' Por medio de este objeto voy a enviar todos los comandos de SQL a la tabla por medio de la conexión
    Public comm As New MySqlCommand
    Dim sql As String
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        ' para comenzar insertar valores en la data 
        ' Verifico que haya escrito el ISBN (bueno, debería verificarlos todos, pero como esta es la clave principal...)
        If TextBox2.Text = "" Then
            ' Si no lo escribió, mando mensaje de error
            MsgBox("Debe incluir RUT")
            TextBox2.Select()
        Else
            'Para asegurar si esta correcto el registro
            If TextBox3.Text > "" Then
                If MessageBox.Show("¿ Seguro que desea insertar este registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then


                    ' Si sí lo escribió, comienza la diversión (jeje)
                    ' Armo la instrucción INSERT en la variable SQL
                    sql = A & ComboBox1.Text & " ','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "',
                         '" & TextBox6.Text & "','" & TextBox7.Text & "','" & ComboBox4.Text & "',
                    '" & ComboBox5.Text & "','" & ComboBox6.Text & "','" & ComboBox3.Text & "','" & ComboBox2.Text & "')"

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
        CRM()

    End Sub
    Sub CRM()
        'Para Carga de Datos de CRM
        On Error Resume Next
        Dim sqlCRM As String = " Select * FROM Atenciones ORDER BY Razon_Social"
        'Dim sqlCRM As String = " Select Distinct Razon_Social, RUT, Atencion FROM Atenciones ORDER BY Razon_Social"

        Cargar_MySQLseguimiento(sqlCRM, DGCRM)
    End Sub
    Private Sub Form17_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                MsgBox("No se pudo encontrar el archivo de la base de datos", MsgBoxStyle.Exclamation, "TSA")
                End
            Else
                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "TSA")
            End If
        End Try
        CRM()
        Using cnx As New MySqlConnection(cadena2)
            Dim conexion2 As New MySqlDataAdapter("select distinct Razon_Social, RUT from Clientes ORDER BY Razon_Social", cnx)
            Dim dtx As New DataTable("Clientes")
            conexion2.Fill(dtx)
            ComboBox1.DataSource = dtx
            ComboBox1.DisplayMember = "Razon_Social"
            ComboBox1.Refresh()

            Dim trato As New MySqlDataAdapter("Select Distinct Trato from Trato", cnx)
            Dim abc As New DataTable("Trato")
            trato.Fill(abc)
            ComboBox2.DataSource = abc
            ComboBox2.DisplayMember = "Trato"
            ComboBox2.Refresh()

            Dim genero As New MySqlDataAdapter("Select Distinct Genero from Genero", cnx)
            Dim fgd As New DataTable("Genero")
            genero.Fill(fgd)
            ComboBox3.DataSource = fgd
            ComboBox3.DisplayMember = "Genero"
            ComboBox3.Refresh()

            Dim objetivo As New MySqlDataAdapter("Select distinct Objetivo from Objetivo", cnx)
            Dim sss As New DataTable("Objetivo")
            objetivo.Fill(sss)
            ComboBox4.DataSource = sss
            ComboBox4.DisplayMember = "Objetivo"
            ComboBox4.Refresh()

            ComboBox1.Text = ""
            ComboBox2.Text = ""
            ComboBox3.Text = ""
            ComboBox4.Text = ""
            ComboBox5.Text = ""
            ComboBox6.Text = ""

            TextBox2.Text = ""
        End Using

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Me.TextBox2.Text = CType(Me.ComboBox1.DataSource, DataTable).Rows(Me.ComboBox1.SelectedIndex)("RUT") 'RUT
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim Razon As String = TextBox1.Text.ToString
            Dim sqlcliente As String = " Select * From  Atenciones where Razon_Social Like '%" & Razon & "%' "

            Cargar_MySQLCliente(sqlcliente, DGCRM)
        End If
    End Sub

    Private Sub DGCRM_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGCRM.CellContentClick
        On Error Resume Next
        Dim xtreme As Integer
        xtreme = DGCRM.CurrentRow.Index
        TextBox2.Text = Me.DGCRM.Item(2, xtreme).Value 'RUT
        TextBox3.Text = Me.DGCRM.Item(3, xtreme).Value 'ATENCION
        TextBox4.Text = Me.DGCRM.Item(4, xtreme).Value 'DIRECCION
        TextBox5.Text = Me.DGCRM.Item(5, xtreme).Value 'TELEFONO
        TextBox6.Text = Me.DGCRM.Item(6, xtreme).Value 'CORREO
        TextBox7.Text = Me.DGCRM.Item(7, xtreme).Value 'CARGO
        TextBox8.Text = Me.DGCRM.Item(0, xtreme).Value 'ID

        ComboBox1.Text = Me.DGCRM.Item(1, xtreme).Value ' RAZON SOCIAL
        ComboBox2.Text = Me.DGCRM.Item(12, xtreme).Value 'TRATO
        ComboBox3.Text = Me.DGCRM.Item(11, xtreme).Value 'GENERO
        ComboBox4.Text = Me.DGCRM.Item(8, xtreme).Value ' OBJETO
        ComboBox5.Text = Me.DGCRM.Item(9, xtreme).Value 'TIPO
        ComboBox6.Text = Me.DGCRM.Item(10, xtreme).Value 'CLASE

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        Using cxx As New MySqlConnection(cadena2)
            Dim ooo As New MySqlDataAdapter("Select Distinct Objetivo, Tipo From Partes WHERE Objetivo= '" & Me.ComboBox4.Text & "' ", cxx)
            Dim aaa As New DataTable("Parte")
            ooo.Fill(aaa)
            ComboBox5.DataSource = aaa
            ComboBox5.DisplayMember = "Tipo"
            ComboBox5.Refresh()
        End Using
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        Using vbc As New MySqlConnection(cadena2)
            Dim ppp As New MySqlDataAdapter("Select Distinct Objetivo, Tipo, Clase From Tipo WHERE Tipo= '" & Me.ComboBox5.Text & "' ", vbc)
            Dim qqq As New DataTable("Tipo")
            ppp.Fill(qqq)
            ComboBox6.DataSource = qqq
            ComboBox6.DisplayMember = "Clase"
            ComboBox6.Refresh()
        End Using
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        'Para actualizar o modificar atenciones 
        If MessageBox.Show("¿ Seguro que desea Modificar este registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            If (ComboBox1.Text = "") Then
                ComboBox1.Select()
            Else

                sql = "Update Atenciones Set Razon_Social ='" & Me.ComboBox1.Text & "', RUT= '" & TextBox2.Text & "', Atencion= '" & TextBox3.Text & "',
                Direccion = '" & TextBox4.Text & "', Telefono = '" & TextBox5.Text & "',
                Correo = '" & TextBox6.Text & "', Cargo = '" & TextBox7.Text & "', 
                Objeto = '" & ComboBox4.Text & "', tipo = '" & ComboBox5.Text & "', Clase = '" & ComboBox6.Text & "' , Genero = '" & ComboBox3.Text & "' , 
                Trato = '" & ComboBox2.Text & "'
                Where ID = '" & TextBox8.Text & "' "

                'Asigno la instrucción SQL que se va a ejecutar
                comm.CommandText = sql
                Try
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(Err.Description, MsgBoxStyle.Exclamation, "TSA")
                End Try
            End If
        End If
        CRM()

    End Sub


    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If MessageBox.Show("¿ Seguro que desea Eliminar este registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            If (ComboBox1.Text = "") Then
                ComboBox1.Select()
            Else
                Dim identificador As Integer

                identificador = Me.TextBox8.Text

                sql = "DELETE FROM Atenciones WHERE ID= " & identificador & " "
                'Asigno la instrucción SQL que se va a ejecutar
                comm.CommandText = sql
                Try
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(Err.Description, MsgBoxStyle.Exclamation, "TSA")
                End Try
            End If
        End If
        CRM()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'PARA EXPORTAR A EXCEL
        Try
            If ((DGCRM.Columns.Count = 0) Or (DGCRM.Rows.Count = 0)) Then
                Exit Sub
            End If

            'Creando Dataset para Exportar
            Dim dset As New DataSet
            'Agregar tabla al Dataset
            dset.Tables.Add()
            'AGregar Columna a la tabla
            For i As Integer = 0 To DGCRM.ColumnCount - 1
                dset.Tables(0).Columns.Add(DGCRM.Columns(i).HeaderText)
            Next
            'Agregar filas a la tabla
            Dim dr1 As DataRow
            For i As Integer = 0 To DGCRM.RowCount - 1
                dr1 = dset.Tables(0).NewRow
                For j As Integer = 0 To DGCRM.Columns.Count - 1
                    dr1(j) = DGCRM.Rows(i).Cells(j).Value
                Next
                dset.Tables(0).Rows.Add(dr1)
            Next

            Dim aplicacion As New Microsoft.Office.Interop.Excel.Application
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

            wBook = aplicacion.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            Dim dt As System.Data.DataTable = dset.Tables(0)
            Dim dc As System.Data.DataColumn
            Dim dr As System.Data.DataRow
            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0

            For Each dc In dt.Columns
                colIndex = colIndex + 1
                aplicacion.Cells(1, colIndex) = dc.ColumnName
            Next

            For Each dr In dt.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In dt.Columns
                    colIndex = colIndex + 1
                    aplicacion.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)

                Next
            Next
            'Configurar la orientacion de la  hoja y el tamaño
            wSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
            wSheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLegal
            'Configurar con negrilla la cabecera y tenga autofit
            wSheet.Rows.Item(1).Font.Bold = 1
            wSheet.Columns.AutoFit()


            Dim strFileName As String = "C:\Documents and Settings\All Users\Escritorio\CRM TSA SPA.xlsx"

            Dim blnFileOpen As Boolean = False
            Try
                Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(strFileName)
                fileTemp.Close()
            Catch ex As Exception
                blnFileOpen = False
            End Try

            If System.IO.File.Exists(strFileName) Then
                System.IO.File.Delete(strFileName)
            End If
            MessageBox.Show("El documento fue exportado correctamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            wBook.SaveAs(strFileName)
            aplicacion.Workbooks.Open(strFileName)
            aplicacion.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "CRM TSA SPA", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class