Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Imports MySql.Data.MySqlClient


Public Class Form2MC
    Private Const S As String = "INSERT INTO SAFRATECDATACOTIZACION(Cotizacion,Fecha,Razon_Social,RUT,Atencion,Direccion_ate,Telefono_ate,Correo_ate,Contacto,Telefono_cont,Correo_cont,Pagina_web,Referencia,Descripcion_Mat,Codigo_Mat,Cantidad,Margen,Precio,Moneda,ID,Linea) VALUES ('"
    Private Const A As String = "INSERT INTO Atenciones(Razon_Social,RUT,Atencion,Direccion,Telefono,Correo) VALUES ('"

    Dim sql As String

    Dim cadena2 As String = "Server = 201.148.105.186; Database = safratec_SAFRATECBD; Uid = safratec_admin2022; Pwd = 17543593Apple"
    'Declaro e inicializo objeto para hacer la conexion a mi base datos de cpanel por medio MySQL 
    Public conex As New MySqlConnection("Server = 201.148.105.186; Database = safratec_SAFRATECBD; Uid = safratec_admin2022; Pwd = 17543593Apple")
    ' Por medio de este objeto voy a enviar todos los comandos de SQL a la tabla por medio de la conexión
    Public comm As New MySqlCommand
    Private Sub Form2MC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            NumericUpDown1.Text = ""
            NumericUpDown2.Text = ""
            NumericUpDown3.Text = ""
            NumericUpDown4.Text = ""
            NumericUpDown5.Text = ""
            NumericUpDown6.Text = ""
            NumericUpDown7.Text = ""
            NumericUpDown8.Text = ""
            NumericUpDown9.Text = ""
            NumericUpDown10.Text = ""
            NumericUpDown11.Text = ""
            NumericUpDown12.Text = ""
            NumericUpDown13.Text = ""
            NumericUpDown14.Text = ""
            NumericUpDown15.Text = ""
            NumericUpDown16.Text = ""
            NumericUpDown17.Text = ""
            NumericUpDown18.Text = ""
            NumericUpDown19.Text = ""
            NumericUpDown20.Text = ""


        Panel2.Width = 1185


        Try
            ' Trato de abrir la conexión
            conex.Open()
            ' Inicializo el objeto Command
            comm.Connection = conex
            comm.CommandType = CommandType.Text

        Catch ex As Exception
            If Err.Number = 5 Then
                MsgBox("No se pudo encontrar el archivo de la base de datos", MsgBoxStyle.Exclamation, "SAFRATEC")
                End
            Else
                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "SAFRATEC")
            End If
        End Try

        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-CL")
        'System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yy"
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text > "" Then
            TextBox5.Visible = True
            TextBox6.Visible = True
            NumericUpDown2.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = True
            'CheckBox2.Visible = True
            'CheckBox3.Visible = True
            BD1.Checked = True

        End If
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


    Private Sub DGVatencion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        Dim fila As Integer
        fila = DGVatencion.CurrentRow.Index
        TxtAtencion.Text = Me.DGVatencion.Item(3, fila).Value
        TxtDireccion.Text = Me.DGVatencion.Item(4, fila).Value
        TxtphoneC.Text = Me.DGVatencion.Item(5, fila).Value
        TxtCorreoC.Text = Me.DGVatencion.Item(6, fila).Value
    End Sub

    Private Sub DGRazonSocial_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGRazonSocial.CellContentClick
        Dim xtreme As Integer
        xtreme = DGRazonSocial.CurrentRow.Index
        TxtRazon.Text = Me.DGRazonSocial.Item(0, xtreme).Value
        TxtRut.Text = Me.DGRazonSocial.Item(1, xtreme).Value
        Form3.TxtrazonEspejo.Text = Me.DGRazonSocial.Item(0, xtreme).Value

        DGVatencion.Visible = True
        Dim porrazon As String = TxtRazon.Text.ToString

        Dim porrut As String = TxtRut.Text.ToString

        Dim sql As String = " Select * From Atenciones Where Razon_Social ='" & porrazon & "'and RUT='" & porrut & "' "

        Cargar_MySQL(sql, DGVatencion)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        If TextBox5.Text > "" Then
            TextBox9.Visible = True
            TextBox10.Visible = True
            NumericUpDown3.Visible = True
            TextBox11.Visible = True
            TextBox12.Visible = True
            'CheckBox4.Visible = True
        End If
    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        If TextBox9.Text > "" Then
            TextBox13.Visible = True
            TextBox14.Visible = True
            NumericUpDown4.Visible = True
            TextBox15.Visible = True
            TextBox16.Visible = True
            'CheckBox5.Visible = True

        End If
    End Sub

    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles TextBox13.TextChanged
        If TextBox13.Text > "" Then
            TextBox17.Visible = True
            TextBox18.Visible = True
            NumericUpDown5.Visible = True
            TextBox19.Visible = True
            TextBox20.Visible = True
            'CheckBox6.Visible = True

        End If
    End Sub

    Private Sub TextBox17_TextChanged(sender As Object, e As EventArgs) Handles TextBox17.TextChanged
        If TextBox17.Text > "" Then
            TextBox21.Visible = True
            TextBox22.Visible = True
            NumericUpDown6.Visible = True
            TextBox23.Visible = True
            TextBox24.Visible = True
            'CheckBox7.Visible = True

        End If
    End Sub

    Private Sub TextBox21_TextChanged(sender As Object, e As EventArgs) Handles TextBox21.TextChanged
        If TextBox21.Text > "" Then
            TextBox25.Visible = True
            TextBox26.Visible = True
            NumericUpDown7.Visible = True
            TextBox27.Visible = True
            TextBox28.Visible = True
            'CheckBox8.Visible = True

        End If
    End Sub

    Private Sub TextBox25_TextChanged(sender As Object, e As EventArgs) Handles TextBox25.TextChanged
        If TextBox25.Text > "" Then
            TextBox29.Visible = True
            TextBox30.Visible = True
            NumericUpDown8.Visible = True
            TextBox31.Visible = True
            TextBox32.Visible = True
            'CheckBox9.Visible = True

        End If
    End Sub

    Private Sub TextBox29_TextChanged(sender As Object, e As EventArgs) Handles TextBox29.TextChanged
        If TextBox29.Text > "" Then
            TextBox33.Visible = True
            TextBox34.Visible = True
            NumericUpDown9.Visible = True
            TextBox35.Visible = True
            TextBox36.Visible = True
            'CheckBox10.Visible = True

        End If
    End Sub

    Private Sub TextBox33_TextChanged(sender As Object, e As EventArgs) Handles TextBox33.TextChanged
        If TextBox33.Text > "" Then
            TextBox37.Visible = True
            TextBox38.Visible = True
            NumericUpDown10.Visible = True
            TextBox39.Visible = True
            TextBox40.Visible = True
            'CheckBox11.Visible = True

        End If
    End Sub
    Private Sub TextBox37_TextChanged(sender As Object, e As EventArgs) Handles TextBox37.TextChanged
        If TextBox37.Text > "" Then
            TextBox62.Visible = True
            TextBox63.Visible = True
            NumericUpDown11.Visible = True
            TextBox64.Visible = True
            TextBox65.Visible = True
            'CheckBox12.Visible = True

        End If
    End Sub
    Private Sub TextBox62_TextChanged(sender As Object, e As EventArgs) Handles TextBox62.TextChanged
        If TextBox62.Text > "" Then
            TextBox66.Visible = True
            TextBox67.Visible = True
            NumericUpDown12.Visible = True
            TextBox68.Visible = True
            TextBox69.Visible = True
            CheckBox13.Visible = True
        End If
    End Sub
    Private Sub TextBox66_TextChanged(sender As Object, e As EventArgs) Handles TextBox66.TextChanged
        If TextBox66.Text > "" Then
            TextBox70.Visible = True
            TextBox71.Visible = True
            NumericUpDown13.Visible = True
            TextBox72.Visible = True
            TextBox73.Visible = True
            CheckBox14.Visible = True
        End If
    End Sub
    Private Sub TextBox70_TextChanged(sender As Object, e As EventArgs) Handles TextBox70.TextChanged
        If TextBox70.Text > "" Then
            TextBox74.Visible = True
            TextBox75.Visible = True
            NumericUpDown14.Visible = True
            TextBox76.Visible = True
            TextBox77.Visible = True
            CheckBox15.Visible = True
        End If
    End Sub
    Private Sub TextBox74_TextChanged(sender As Object, e As EventArgs) Handles TextBox74.TextChanged
        If TextBox74.Text > "" Then
            TextBox78.Visible = True
            TextBox79.Visible = True
            NumericUpDown15.Visible = True
            TextBox80.Visible = True
            TextBox81.Visible = True
            CheckBox16.Visible = True
        End If
    End Sub
    Private Sub TextBox78_TextChanged(sender As Object, e As EventArgs) Handles TextBox78.TextChanged
        If TextBox78.Text > "" Then
            TextBox82.Visible = True
            TextBox83.Visible = True
            NumericUpDown16.Visible = True
            TextBox84.Visible = True
            TextBox85.Visible = True
            CheckBox17.Visible = True
        End If
    End Sub
    Private Sub TextBox82_TextChanged(sender As Object, e As EventArgs) Handles TextBox82.TextChanged
        If TextBox82.Text > "" Then
            TextBox86.Visible = True
            TextBox87.Visible = True
            NumericUpDown17.Visible = True
            TextBox88.Visible = True
            TextBox89.Visible = True
            CheckBox18.Visible = True
        End If
    End Sub
    Private Sub TextBox86_TextChanged(sender As Object, e As EventArgs) Handles TextBox86.TextChanged
        If TextBox86.Text > "" Then
            TextBox90.Visible = True
            TextBox91.Visible = True
            NumericUpDown18.Visible = True
            TextBox92.Visible = True
            TextBox93.Visible = True
            CheckBox19.Visible = True
        End If
    End Sub
    Private Sub TextBox90_TextChanged(sender As Object, e As EventArgs) Handles TextBox90.TextChanged
        If TextBox90.Text > "" Then
            TextBox94.Visible = True
            TextBox95.Visible = True
            NumericUpDown19.Visible = True
            TextBox96.Visible = True
            TextBox97.Visible = True
            CheckBox20.Visible = True
        End If
    End Sub
    Private Sub TextBox94_TextChanged(sender As Object, e As EventArgs) Handles TextBox94.TextChanged
        If TextBox94.Text > "" Then
            TextBox98.Visible = True
            TextBox99.Visible = True
            NumericUpDown20.Visible = True
            TextBox100.Visible = True
            TextBox101.Visible = True
            CheckBox21.Visible = True
        End If
    End Sub

#Region "Para calculo de precios"
    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox4_Click(sender As Object, e As EventArgs) Handles TextBox4.Click
        Dim precio As String
        precio = Val(TextBox41.Text) / Val((100 - TextBox3.Text) / 100)
        TextBox4.Text = precio

        Dim total As String
        total = Val(TextBox4.Text) * Val(NumericUpDown1.Text)
        TextBox52.Text = total

        Me.TextBox4.Text = Format(Val(TextBox4.Text), "#,##0.00")
        Me.TextBox52.Text = Format(Val(TextBox52.Text), "#,##0.00")
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub TextBox8_Click(sender As Object, e As EventArgs) Handles TextBox8.Click
        Dim precio As String
        precio = Val(TextBox42.Text) / Val((100 - TextBox7.Text) / 100)
        TextBox8.Text = precio

        Dim total As String
        total = Val(TextBox8.Text) * Val(NumericUpDown2.Text)
        TextBox53.Text = total

        Me.TextBox8.Text = Format(Val(TextBox8.Text), "#,##0.00")
        Me.TextBox53.Text = Format(Val(TextBox53.Text), "#,##0.00")
    End Sub

    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs) Handles TextBox12.TextChanged

    End Sub

    Private Sub TextBox12_Click(sender As Object, e As EventArgs) Handles TextBox12.Click
        Dim precio As String
        precio = Val(TextBox43.Text) / Val((100 - TextBox11.Text) / 100)
        TextBox12.Text = precio

        Dim total As String
        total = Val(TextBox12.Text) * Val(NumericUpDown3.Text)
        TextBox54.Text = total

        Me.TextBox12.Text = Format(Val(TextBox12.Text), "#,##0.00")
        Me.TextBox54.Text = Format(Val(TextBox54.Text), "#,##0.00")
    End Sub

    Private Sub TextBox16_TextChanged(sender As Object, e As EventArgs) Handles TextBox16.TextChanged

    End Sub

    Private Sub TextBox16_Click(sender As Object, e As EventArgs) Handles TextBox16.Click
        Dim precio As String
        precio = Val(TextBox44.Text) / Val((100 - TextBox15.Text) / 100)
        TextBox16.Text = precio

        Dim total As String
        total = Val(TextBox16.Text) * Val(NumericUpDown4.Text)
        TextBox55.Text = total

        Me.TextBox16.Text = Format(Val(TextBox16.Text), "#,##0.00")
        Me.TextBox55.Text = Format(Val(TextBox55.Text), "#,##0.00")
    End Sub

    Private Sub TextBox20_TextChanged(sender As Object, e As EventArgs) Handles TextBox20.TextChanged

    End Sub

    Private Sub TextBox20_Click(sender As Object, e As EventArgs) Handles TextBox20.Click
        Dim precio As String
        precio = Val(TextBox45.Text) / Val((100 - TextBox19.Text) / 100)
        TextBox20.Text = precio

        Dim total As String
        total = Val(TextBox20.Text) * Val(NumericUpDown5.Text)
        TextBox56.Text = total

        Me.TextBox20.Text = Format(Val(TextBox20.Text), "#,##0.00")
        Me.TextBox56.Text = Format(Val(TextBox56.Text), "#,##0.00")
    End Sub

    Private Sub TextBox24_TextChanged(sender As Object, e As EventArgs) Handles TextBox24.TextChanged

    End Sub

    Private Sub TextBox24_Click(sender As Object, e As EventArgs) Handles TextBox24.Click
        Dim precio As String
        precio = Val(TextBox46.Text) / Val((100 - TextBox23.Text) / 100)
        TextBox24.Text = precio

        Dim total As String
        total = Val(TextBox24.Text) * Val(NumericUpDown6.Text)
        TextBox57.Text = total

        Me.TextBox24.Text = Format(Val(TextBox24.Text), "#,##0.00")
        Me.TextBox57.Text = Format(Val(TextBox57.Text), "#,##0.00")
    End Sub

    Private Sub TextBox28_TextChanged(sender As Object, e As EventArgs) Handles TextBox28.TextChanged

    End Sub

    Private Sub TextBox28_Click(sender As Object, e As EventArgs) Handles TextBox28.Click
        Dim precio As String
        precio = Val(TextBox47.Text) / Val((100 - TextBox27.Text) / 100)
        TextBox28.Text = precio

        Dim total As String
        total = Val(TextBox28.Text) * Val(NumericUpDown7.Text)
        TextBox58.Text = total

        Me.TextBox28.Text = Format(Val(TextBox28.Text), "#,##0.00")
        Me.TextBox58.Text = Format(Val(TextBox58.Text), "#,##0.00")
    End Sub

    Private Sub TextBox32_TextChanged(sender As Object, e As EventArgs) Handles TextBox32.TextChanged

    End Sub

    Private Sub TextBox32_Click(sender As Object, e As EventArgs) Handles TextBox32.Click
        Dim precio As String
        precio = Val(TextBox48.Text) / Val((100 - TextBox31.Text) / 100)
        TextBox32.Text = precio

        Dim total As String
        total = Val(TextBox32.Text) * Val(NumericUpDown8.Text)
        TextBox59.Text = total

        Me.TextBox32.Text = Format(Val(TextBox32.Text), "#,##0.00")
        Me.TextBox59.Text = Format(Val(TextBox59.Text), "#,##0.00")
    End Sub

    Private Sub TextBox36_TextChanged(sender As Object, e As EventArgs) Handles TextBox36.TextChanged

    End Sub

    Private Sub TextBox36_Click(sender As Object, e As EventArgs) Handles TextBox36.Click
        Dim precio As String
        precio = Val(TextBox49.Text) / Val((100 - TextBox35.Text) / 100)
        TextBox36.Text = precio

        Dim total As String
        total = Val(TextBox36.Text) * Val(NumericUpDown9.Text)
        TextBox60.Text = total

        Me.TextBox36.Text = Format(Val(TextBox36.Text), "#,##0.00")
        Me.TextBox60.Text = Format(Val(TextBox60.Text), "#,##0.00")
    End Sub

    Private Sub TextBox40_TextChanged(sender As Object, e As EventArgs) Handles TextBox40.TextChanged

    End Sub

    Private Sub TextBox40_Click(sender As Object, e As EventArgs) Handles TextBox40.Click
        Dim precio As String
        precio = Val(TextBox50.Text) / Val((100 - TextBox39.Text) / 100)
        TextBox40.Text = precio

        Dim total As String
        total = Val(TextBox40.Text) * Val(NumericUpDown10.Text)
        TextBox61.Text = total

        Me.TextBox40.Text = Format(Val(TextBox40.Text), "#,##0.00")
        Me.TextBox61.Text = Format(Val(TextBox61.Text), "#,##0.00")
    End Sub
    Private Sub TextBox65_TextChanged(sender As Object, e As EventArgs) Handles TextBox65.TextChanged

    End Sub

    Private Sub TextBox65_Click(sender As Object, e As EventArgs) Handles TextBox65.Click
        Dim precio As String
        precio = Val(TextBox102.Text) / Val((100 - TextBox64.Text) / 100)
        TextBox65.Text = precio

        Dim total As String
        total = Val(TextBox65.Text) * Val(NumericUpDown11.Text)
        TextBox112.Text = total

        Me.TextBox65.Text = Format(Val(TextBox65.Text), "#,##0.00")
        Me.TextBox112.Text = Format(Val(TextBox112.Text), "#,##0.00")
    End Sub

    Private Sub TextBox69_TextChanged(sender As Object, e As EventArgs) Handles TextBox69.TextChanged

    End Sub

    Private Sub TextBox69_Click(sender As Object, e As EventArgs) Handles TextBox69.Click
        Dim precio As String
        precio = Val(TextBox103.Text) / Val((100 - TextBox68.Text) / 100)
        TextBox69.Text = precio

        Dim total As String
        total = Val(TextBox69.Text) * Val(NumericUpDown12.Text)
        TextBox113.Text = total

        Me.TextBox69.Text = Format(Val(TextBox69.Text), "#,##0.00")
        Me.TextBox113.Text = Format(Val(TextBox113.Text), "#,##0.00")
    End Sub

    Private Sub TextBox73_TextChanged(sender As Object, e As EventArgs) Handles TextBox73.TextChanged

    End Sub

    Private Sub TextBox73_Click(sender As Object, e As EventArgs) Handles TextBox73.Click
        Dim precio As String
        precio = Val(TextBox104.Text) / Val((100 - TextBox72.Text) / 100)
        TextBox73.Text = precio

        Dim total As String
        total = Val(TextBox73.Text) * Val(NumericUpDown13.Text)
        TextBox114.Text = total

        Me.TextBox73.Text = Format(Val(TextBox73.Text), "#,##0.00")
        Me.TextBox114.Text = Format(Val(TextBox114.Text), "#,##0.00")
    End Sub
    Private Sub TextBox77_TextChanged(sender As Object, e As EventArgs) Handles TextBox77.TextChanged

    End Sub

    Private Sub TextBox77_Click(sender As Object, e As EventArgs) Handles TextBox77.Click
        Dim precio As String
        precio = Val(TextBox105.Text) / Val((100 - TextBox76.Text) / 100)
        TextBox77.Text = precio

        Dim total As String
        total = Val(TextBox77.Text) * Val(NumericUpDown14.Text)
        TextBox115.Text = total

        Me.TextBox77.Text = Format(Val(TextBox77.Text), "#,##0.00")
        Me.TextBox115.Text = Format(Val(TextBox115.Text), "#,##0.00")
    End Sub
    Private Sub TextBox81_TextChanged(sender As Object, e As EventArgs) Handles TextBox81.TextChanged

    End Sub

    Private Sub TextBox81_Click(sender As Object, e As EventArgs) Handles TextBox81.Click
        Dim precio As String
        precio = Val(TextBox106.Text) / Val((100 - TextBox80.Text) / 100)
        TextBox81.Text = precio

        Dim total As String
        total = Val(TextBox81.Text) * Val(NumericUpDown15.Text)
        TextBox116.Text = total

        Me.TextBox81.Text = Format(Val(TextBox81.Text), "#,##0.00")
        Me.TextBox116.Text = Format(Val(TextBox116.Text), "#,##0.00")
    End Sub
    Private Sub TextBox85_TextChanged(sender As Object, e As EventArgs) Handles TextBox85.TextChanged

    End Sub

    Private Sub TextBox85_Click(sender As Object, e As EventArgs) Handles TextBox85.Click
        Dim precio As String
        precio = Val(TextBox107.Text) / Val((100 - TextBox84.Text) / 100)
        TextBox85.Text = precio

        Dim total As String
        total = Val(TextBox85.Text) * Val(NumericUpDown16.Text)
        TextBox117.Text = total

        Me.TextBox85.Text = Format(Val(TextBox85.Text), "#,##0.00")
        Me.TextBox117.Text = Format(Val(TextBox117.Text), "#,##0.00")
    End Sub
    Private Sub TextBox89_TextChanged(sender As Object, e As EventArgs) Handles TextBox89.TextChanged

    End Sub

    Private Sub TextBox89_Click(sender As Object, e As EventArgs) Handles TextBox89.Click
        Dim precio As String
        precio = Val(TextBox108.Text) / Val((100 - TextBox88.Text) / 100)
        TextBox89.Text = precio

        Dim total As String
        total = Val(TextBox89.Text) * Val(NumericUpDown17.Text)
        TextBox118.Text = total

        Me.TextBox89.Text = Format(Val(TextBox89.Text), "#,##0.00")
        Me.TextBox118.Text = Format(Val(TextBox118.Text), "#,##0.00")
    End Sub
    Private Sub TextBox93_TextChanged(sender As Object, e As EventArgs) Handles TextBox93.TextChanged

    End Sub

    Private Sub TextBox93_Click(sender As Object, e As EventArgs) Handles TextBox93.Click
        Dim precio As String
        precio = Val(TextBox109.Text) / Val((100 - TextBox92.Text) / 100)
        TextBox93.Text = precio

        Dim total As String
        total = Val(TextBox93.Text) * Val(NumericUpDown18.Text)
        TextBox119.Text = total

        Me.TextBox93.Text = Format(Val(TextBox93.Text), "#,##0.00")
        Me.TextBox119.Text = Format(Val(TextBox119.Text), "#,##0.00")
    End Sub
    Private Sub TextBox97_TextChanged(sender As Object, e As EventArgs) Handles TextBox97.TextChanged

    End Sub

    Private Sub TextBox97_Click(sender As Object, e As EventArgs) Handles TextBox97.Click
        Dim precio As String
        precio = Val(TextBox110.Text) / Val((100 - TextBox96.Text) / 100)
        TextBox97.Text = precio

        Dim total As String
        total = Val(TextBox97.Text) * Val(NumericUpDown19.Text)
        TextBox120.Text = total

        Me.TextBox97.Text = Format(Val(TextBox97.Text), "#,##0.00")
        Me.TextBox120.Text = Format(Val(TextBox120.Text), "#,##0.00")
    End Sub
    Private Sub TextBox101_TextChanged(sender As Object, e As EventArgs) Handles TextBox101.TextChanged

    End Sub

    Private Sub TextBox101_Click(sender As Object, e As EventArgs) Handles TextBox101.Click
        Dim precio As String
        precio = Val(TextBox111.Text) / Val((100 - TextBox100.Text) / 100)
        TextBox101.Text = precio

        Dim total As String
        total = Val(TextBox101.Text) * Val(NumericUpDown20.Text)
        TextBox121.Text = total

        Me.TextBox101.Text = Format(Val(TextBox101.Text), "#,##0.00")
        Me.TextBox121.Text = Format(Val(TextBox121.Text), "#,##0.00")
    End Sub
    Private Sub BtnCambio_Click(sender As Object, e As EventArgs) Handles BtnCambio.Click
        Panel2.Width = 1205
        TextBox51.Visible = True
    End Sub

#End Region

#Region "Cambio Monetario"
    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            Dim Moneda As String
            Moneda = Val(TextBox4.Text) * Val(TextBox51.Text)
            TextBox4.Text = Moneda
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            Dim Moneda As String
            Moneda = Val(TextBox8.Text) * Val(TextBox51.Text)
            TextBox8.Text = Moneda
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = True Then
            Dim Moneda As String
            Moneda = Val(TextBox12.Text) * Val(TextBox51.Text)
            TextBox12.Text = Moneda
        End If
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        If CheckBox5.Checked = True Then
            Dim Moneda As String
            Moneda = Val(TextBox16.Text) * Val(TextBox51.Text)
            TextBox16.Text = Moneda
        End If
    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged
        If CheckBox6.Checked = True Then
            Dim Moneda As String
            Moneda = Val(TextBox20.Text) * Val(TextBox51.Text)
            TextBox20.Text = Moneda
        End If
    End Sub

    Private Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox7.CheckedChanged
        If CheckBox7.Checked = True Then
            Dim Moneda As String
            Moneda = Val(TextBox24.Text) * Val(TextBox51.Text)
            TextBox24.Text = Moneda
        End If
    End Sub

    Private Sub CheckBox8_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox8.CheckedChanged
        If CheckBox8.Checked = True Then
            Dim Moneda As String
            Moneda = Val(TextBox28.Text) * Val(TextBox51.Text)
            TextBox28.Text = Moneda
        End If
    End Sub

    Private Sub CheckBox9_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox9.CheckedChanged
        If CheckBox9.Checked = True Then
            Dim Moneda As String
            Moneda = Val(TextBox32.Text) * Val(TextBox51.Text)
            TextBox32.Text = Moneda
        End If
    End Sub

    Private Sub CheckBox10_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox10.CheckedChanged
        If CheckBox10.Checked = True Then
            Dim Moneda As String
            Moneda = Val(TextBox36.Text) * Val(TextBox51.Text)
            TextBox36.Text = Moneda
        End If
    End Sub

    Private Sub CheckBox11_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox11.CheckedChanged
        If CheckBox11.Checked = True Then
            Dim Moneda As String
            Moneda = Val(TextBox40.Text) * Val(TextBox51.Text)
            TextBox40.Text = Moneda
        End If
    End Sub
    Private Sub CheckBox12_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox12.CheckedChanged
        If CheckBox12.Checked = True Then
            Dim Moneda As String
            Moneda = Val(TextBox65.Text) * Val(TextBox51.Text)
            TextBox65.Text = Moneda
        End If
    End Sub
    Private Sub CheckBox13_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox13.CheckedChanged
        If CheckBox13.Checked = True Then
            Dim Moneda As String
            Moneda = Val(TextBox69.Text) * Val(TextBox51.Text)
            TextBox69.Text = Moneda
        End If
    End Sub
    Private Sub CheckBox14_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox14.CheckedChanged
        If CheckBox14.Checked = True Then
            Dim Moneda As String
            Moneda = Val(TextBox73.Text) * Val(TextBox51.Text)
            TextBox73.Text = Moneda
        End If
    End Sub
    Private Sub CheckBox15_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox15.CheckedChanged
        If CheckBox15.Checked = True Then
            Dim Moneda As String
            Moneda = Val(TextBox77.Text) * Val(TextBox51.Text)
            TextBox77.Text = Moneda
        End If
    End Sub
    Private Sub CheckBox16_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox16.CheckedChanged
        If CheckBox16.Checked = True Then
            Dim Moneda As String
            Moneda = Val(TextBox81.Text) * Val(TextBox51.Text)
            TextBox81.Text = Moneda
        End If
    End Sub
    Private Sub CheckBox17_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox17.CheckedChanged
        If CheckBox17.Checked = True Then
            Dim Moneda As String
            Moneda = Val(TextBox85.Text) * Val(TextBox51.Text)
            TextBox85.Text = Moneda
        End If
    End Sub
    Private Sub CheckBox18_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox18.CheckedChanged
        If CheckBox18.Checked = True Then
            Dim Moneda As String
            Moneda = Val(TextBox89.Text) * Val(TextBox51.Text)
            TextBox89.Text = Moneda
        End If
    End Sub
    Private Sub CheckBox19_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox19.CheckedChanged
        If CheckBox19.Checked = True Then
            Dim Moneda As String
            Moneda = Val(TextBox93.Text) * Val(TextBox51.Text)
            TextBox93.Text = Moneda
        End If
    End Sub
    Private Sub CheckBox20_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox20.CheckedChanged
        If CheckBox20.Checked = True Then
            Dim Moneda As String
            Moneda = Val(TextBox97.Text) * Val(TextBox51.Text)
            TextBox97.Text = Moneda
        End If
    End Sub
    Private Sub CheckBox21_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox21.CheckedChanged
        If CheckBox21.Checked = True Then
            Dim Moneda As String
            Moneda = Val(TextBox101.Text) * Val(TextBox51.Text)
            TextBox101.Text = Moneda
        End If
    End Sub
#End Region

#Region "Para exportar @ SAFRATEC"
    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportarMario.Click
        Dim xlibro As Microsoft.Office.Interop.Excel.Application
        Dim strRutaExcel As String

        strRutaExcel = "C:\SOURCESAFRATEC\Planilla de Cotizacion.xlsm"

        xlibro = CreateObject("Excel.Application")
        xlibro.Workbooks.Open(strRutaExcel)

        'Activamos el libro
        xlibro.Workbooks("Planilla de Cotizacion.xlsm").Activate()

        'Activamos la hoja especifica del libro  
        xlibro.Sheets("Planilla de Cotizacion MC").Select()

        Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = xlibro.Sheets.Item("Planilla de Cotizacion MC")
        xlibro.Visible = True

        'Ahora podemos llevar el contenido de un textbox a una celda de excel expecifica copn la siguiente instrucción

        xlibro.Range("D15").Value = TxtRazon.Text 'Razon social
        xlibro.Range("D16").Value = TxtAtencion.Text 'Atencion
        xlibro.Range("D17").Value = TxtRut.Text 'RUT
        xlibro.Range("D18").Value = TxtDireccion.Text 'Direccion 
        xlibro.Range("D19").Value = TxtphoneC.Text 'Telefono cliente
        xlibro.Range("D20").Value = TxtCorreoC.Text ' Correo de Cliente

        xlibro.Range("H10").Value = "N#  " + TxtCot.Text + Txtcot2.Text + Txtcot3.Text '# de Cotizacion
        xlibro.Range("I16").Value = TxtFecha.Text ' Fecha del Dia
        'xlibro.Range("H13").Value = CboContacto.Text 'Vendedor


        xlibro.Range("I17").Value = CboContacto.Text 'Vendedor
        xlibro.Range("I18").Value = TxtCorreoV.Text 'Correo de Vendedor
        xlibro.Range("I19").Value = TxtWeb.Text 'Pagina web
        xlibro.Range("I20").Value = TxtphoneV.Text 'Telefono vendedor

        xlibro.Range("D21").Value = TxtReferencia.Text 'Referencia 


        '''' Para primera linea activa de Materiales
        xlibro.Range("D24").Value = TextBox1.Text 'Descripcion de Materiales
        xlibro.Range("C24").Value = TextBox2.Text 'Codigo del Material
        xlibro.Range("H24").Value = NumericUpDown1.Text 'Cantidad del Material
        xlibro.Range("I24").Value = TextBox4.Text ' Precio del Material
        xlibro.Range("M24").Value = TextBox41.Text 'Costo de Defontana
        xlibro.Range("N24").Value = TextBox3.Text 'Margen (%)
        xlibro.Range("J24").Value = TextBox52.Text 'Total
        xlibro.Range("O24").Value = TextBox122.Text 'Para costo de Reposicion articulos de GSI

        ' 2 linea de Materiales
        xlibro.Range("D25").Value = TextBox5.Text 'Descripcion de Materiales
        xlibro.Range("C25").Value = TextBox6.Text 'Codigo del Material
        xlibro.Range("H25").Value = NumericUpDown2.Text 'Cantidad del Material
        xlibro.Range("I25").Value = TextBox8.Text ' Precio del Material
        xlibro.Range("M25").Value = TextBox42.Text 'Costo de Defontana
        xlibro.Range("N25").Value = TextBox7.Text 'Margen (%)
        xlibro.Range("J25").Value = TextBox53.Text 'Total
        xlibro.Range("O25").Value = TextBox123.Text 'Para costo de Reposicion articulos de GSI

        '3 linea de Materiales
        xlibro.Range("D26").Value = TextBox9.Text 'Descripcion de Materiales
        xlibro.Range("C26").Value = TextBox10.Text 'Codigo del Material
        xlibro.Range("H26").Value = NumericUpDown3.Text 'Cantidad del Material
        xlibro.Range("I26").Value = TextBox12.Text ' Precio del Material
        xlibro.Range("M26").Value = TextBox43.Text 'Costo de Defontana
        xlibro.Range("N26").Value = TextBox11.Text 'Margen (%)
        xlibro.Range("J26").Value = TextBox54.Text 'Total
        xlibro.Range("O26").Value = TextBox124.Text 'Para costo de Reposicion articulos de GSI

        '4 linea de Materiales
        xlibro.Range("D27").Value = TextBox13.Text 'Descripcion de Materiales
        xlibro.Range("C27").Value = TextBox14.Text 'Codigo del Material
        xlibro.Range("H27").Value = NumericUpDown4.Text 'Cantidad del Material
        xlibro.Range("I27").Value = TextBox16.Text ' Precio del Material
        xlibro.Range("M27").Value = TextBox44.Text 'Costo de Defontana
        xlibro.Range("N27").Value = TextBox15.Text 'Margen (%)
        xlibro.Range("J27").Value = TextBox55.Text 'Total
        xlibro.Range("O27").Value = TextBox125.Text 'Para costo de Reposicion articulos de GSI

        '5 linea de Materiales
        xlibro.Range("D28").Value = TextBox17.Text 'Descripcion de Materiales
        xlibro.Range("C28").Value = TextBox18.Text 'Codigo del Material
        xlibro.Range("H28").Value = NumericUpDown5.Text 'Cantidad del Material
        xlibro.Range("I28").Value = TextBox20.Text ' Precio del Material
        xlibro.Range("M28").Value = TextBox45.Text 'Costo de Defontana
        xlibro.Range("N28").Value = TextBox19.Text 'Margen (%)
        xlibro.Range("J28").Value = TextBox56.Text 'Total
        xlibro.Range("O28").Value = TextBox126.Text 'Para costo de Reposicion articulos de GSI

        '6 linea de Materiales
        xlibro.Range("D29").Value = TextBox21.Text 'Descripcion de Materiales
        xlibro.Range("C29").Value = TextBox22.Text 'Codigo del Material
        xlibro.Range("H29").Value = NumericUpDown6.Text 'Cantidad del Material
        xlibro.Range("I29").Value = TextBox24.Text ' Precio del Material
        xlibro.Range("M29").Value = TextBox46.Text 'Costo de Defontana
        xlibro.Range("N29").Value = TextBox23.Text 'Margen (%)
        xlibro.Range("J29").Value = TextBox57.Text 'Total
        xlibro.Range("O29").Value = TextBox127.Text 'Para costo de Reposicion articulos de GSI

        '7 linea de Materiales
        xlibro.Range("D30").Value = TextBox25.Text 'Descripcion de Materiales
        xlibro.Range("C30").Value = TextBox26.Text 'Codigo del Material
        xlibro.Range("H30").Value = NumericUpDown7.Text 'Cantidad del Material
        xlibro.Range("I30").Value = TextBox28.Text ' Precio del Material
        xlibro.Range("M30").Value = TextBox47.Text 'Costo de Defontana
        xlibro.Range("N30").Value = TextBox27.Text 'Margen (%)
        xlibro.Range("J30").Value = TextBox58.Text 'Total
        xlibro.Range("O30").Value = TextBox128.Text 'Para costo de Reposicion articulos de GSI

        '8 Linea de Materiles
        xlibro.Range("D31").Value = TextBox29.Text 'Descripcion de Materiales
        xlibro.Range("C31").Value = TextBox30.Text 'Codigo del Material
        xlibro.Range("H31").Value = NumericUpDown8.Text 'Cantidad del Material
        xlibro.Range("I31").Value = TextBox32.Text ' Precio del Material
        xlibro.Range("M31").Value = TextBox48.Text 'Costo de Defontana
        xlibro.Range("N31").Value = TextBox31.Text 'Margen (%)
        xlibro.Range("J31").Value = TextBox59.Text 'Total
        xlibro.Range("O31").Value = TextBox129.Text 'Para costo de Reposicion articulos de GSI

        '9 linea de Materiales
        xlibro.Range("D32").Value = TextBox33.Text 'Descripcion de Materiales
        xlibro.Range("C32").Value = TextBox34.Text 'Codigo del Material
        xlibro.Range("H32").Value = NumericUpDown9.Text 'Cantidad del Material
        xlibro.Range("I32").Value = TextBox36.Text ' Precio del Material
        xlibro.Range("M32").Value = TextBox49.Text 'Costo de Defontana
        xlibro.Range("N32").Value = TextBox35.Text 'Margen (%)
        xlibro.Range("J32").Value = TextBox60.Text 'Total
        xlibro.Range("O32").Value = TextBox130.Text 'Para costo de Reposicion articulos de GSI

        ' 10 Linea de Materiales 
        xlibro.Range("D33").Value = TextBox37.Text 'Descripcion de Materiales
        xlibro.Range("C33").Value = TextBox38.Text 'Codigo del Material
        xlibro.Range("H33").Value = NumericUpDown10.Text 'Cantidad del Material
        xlibro.Range("I33").Value = TextBox40.Text ' Precio del Material
        xlibro.Range("M33").Value = TextBox50.Text 'Costo de Defontana
        xlibro.Range("N33").Value = TextBox39.Text 'Margen (%)
        xlibro.Range("J33").Value = TextBox61.Text 'Total
        xlibro.Range("O33").Value = TextBox131.Text 'Para costo de Reposicion articulos de GSI

        ' 11 Linea de Materiales 
        xlibro.Range("D34").Value = TextBox62.Text 'Descripcion de Materiales
        xlibro.Range("C34").Value = TextBox63.Text 'Codigo del Material
        xlibro.Range("H34").Value = NumericUpDown11.Text 'Cantidad del Material
        xlibro.Range("I34").Value = TextBox65.Text ' Precio del Material
        xlibro.Range("M34").Value = TextBox102.Text 'Costo de Defontana
        xlibro.Range("N34").Value = TextBox64.Text 'Margen (%)
        xlibro.Range("J34").Value = TextBox112.Text 'Total
        xlibro.Range("O34").Value = TextBox132.Text 'Para costo de Reposicion articulos de GSI

        ' 12 Linea de Materiales 
        xlibro.Range("D35").Value = TextBox66.Text 'Descripcion de Materiales
        xlibro.Range("C35").Value = TextBox67.Text 'Codigo del Material
        xlibro.Range("H35").Value = NumericUpDown12.Text 'Cantidad del Material
        xlibro.Range("I35").Value = TextBox69.Text ' Precio del Material
        xlibro.Range("M35").Value = TextBox103.Text 'Costo de Defontana
        xlibro.Range("N35").Value = TextBox68.Text 'Margen (%)
        xlibro.Range("J35").Value = TextBox113.Text 'Total
        xlibro.Range("O35").Value = TextBox133.Text 'Para costo de Reposicion articulos de GSI

        ' 13 Linea de Materiales 
        xlibro.Range("D36").Value = TextBox70.Text 'Descripcion de Materiales
        xlibro.Range("C36").Value = TextBox71.Text 'Codigo del Material
        xlibro.Range("H36").Value = NumericUpDown13.Text 'Cantidad del Material
        xlibro.Range("I36").Value = TextBox73.Text ' Precio del Material
        xlibro.Range("M36").Value = TextBox104.Text 'Costo de Defontana
        xlibro.Range("N36").Value = TextBox72.Text 'Margen (%)
        xlibro.Range("J36").Value = TextBox114.Text 'Total
        xlibro.Range("O36").Value = TextBox134.Text 'Para costo de Reposicion articulos de GSI

        ' 14 Linea de Materiales 
        xlibro.Range("D37").Value = TextBox74.Text 'Descripcion de Materiales
        xlibro.Range("C37").Value = TextBox75.Text 'Codigo del Material
        xlibro.Range("H37").Value = NumericUpDown14.Text 'Cantidad del Material
        xlibro.Range("I37").Value = TextBox77.Text ' Precio del Material
        xlibro.Range("M37").Value = TextBox105.Text 'Costo de Defontana
        xlibro.Range("N37").Value = TextBox76.Text 'Margen (%)
        xlibro.Range("J37").Value = TextBox115.Text 'Total
        xlibro.Range("O37").Value = TextBox135.Text 'Para costo de Reposicion articulos de GSI

        ' 15 Linea de Materiales 
        xlibro.Range("D38").Value = TextBox78.Text 'Descripcion de Materiales
        xlibro.Range("C38").Value = TextBox79.Text 'Codigo del Material
        xlibro.Range("H38").Value = NumericUpDown15.Text 'Cantidad del Material
        xlibro.Range("I38").Value = TextBox81.Text ' Precio del Material
        xlibro.Range("M38").Value = TextBox106.Text 'Costo de Defontana
        xlibro.Range("N38").Value = TextBox80.Text 'Margen (%)
        xlibro.Range("J38").Value = TextBox116.Text 'Total
        xlibro.Range("O38").Value = TextBox136.Text 'Para costo de Reposicion articulos de GSI

        ' 16 Linea de Materiales 
        xlibro.Range("D39").Value = TextBox82.Text 'Descripcion de Materiales
        xlibro.Range("C39").Value = TextBox82.Text 'Codigo del Material
        xlibro.Range("H39").Value = NumericUpDown16.Text 'Cantidad del Material
        xlibro.Range("I39").Value = TextBox85.Text ' Precio del Material
        xlibro.Range("M39").Value = TextBox107.Text 'Costo de Defontana
        xlibro.Range("N39").Value = TextBox84.Text 'Margen (%)
        xlibro.Range("J39").Value = TextBox117.Text 'Total
        xlibro.Range("O39").Value = TextBox137.Text 'Para costo de Reposicion articulos de GSI

        ' 17 Linea de Materiales 
        xlibro.Range("D40").Value = TextBox86.Text 'Descripcion de Materiales
        xlibro.Range("C40").Value = TextBox87.Text 'Codigo del Material
        xlibro.Range("H40").Value = NumericUpDown17.Text 'Cantidad del Material
        xlibro.Range("I40").Value = TextBox89.Text ' Precio del Material
        xlibro.Range("M40").Value = TextBox108.Text 'Costo de Defontana
        xlibro.Range("N40").Value = TextBox88.Text 'Margen (%)
        xlibro.Range("J40").Value = TextBox118.Text 'Total
        xlibro.Range("O40").Value = TextBox138.Text 'Para costo de Reposicion articulos de GSI

        ' 18 Linea de Materiales 
        xlibro.Range("D41").Value = TextBox90.Text 'Descripcion de Materiales
        xlibro.Range("C41").Value = TextBox91.Text 'Codigo del Material
        xlibro.Range("H41").Value = NumericUpDown18.Text 'Cantidad del Material
        xlibro.Range("I41").Value = TextBox93.Text ' Precio del Material
        xlibro.Range("M41").Value = TextBox109.Text 'Costo de Defontana
        xlibro.Range("N41").Value = TextBox92.Text 'Margen (%)
        xlibro.Range("J41").Value = TextBox119.Text 'Total
        xlibro.Range("O41").Value = TextBox139.Text 'Para costo de Reposicion articulos de GSI

        ' 19 Linea de Materiales 
        xlibro.Range("D42").Value = TextBox94.Text 'Descripcion de Materiales
        xlibro.Range("C42").Value = TextBox95.Text 'Codigo del Material
        xlibro.Range("H42").Value = NumericUpDown19.Text 'Cantidad del Material
        xlibro.Range("I42").Value = TextBox97.Text ' Precio del Material
        xlibro.Range("M42").Value = TextBox110.Text 'Costo de Defontana
        xlibro.Range("N42").Value = TextBox96.Text 'Margen (%)
        xlibro.Range("J42").Value = TextBox120.Text 'Total
        xlibro.Range("O42").Value = TextBox140.Text 'Para costo de Reposicion articulos de GSI

        ' 20 Linea de Materiales 
        xlibro.Range("D43").Value = TextBox98.Text 'Descripcion de Materiales
        xlibro.Range("C43").Value = TextBox99.Text 'Codigo del Material
        xlibro.Range("H43").Value = NumericUpDown20.Text 'Cantidad del Material
        xlibro.Range("I43").Value = TextBox101.Text ' Precio del Material
        xlibro.Range("M43").Value = TextBox111.Text 'Costo de Defontana
        xlibro.Range("N43").Value = TextBox100.Text 'Margen (%)
        xlibro.Range("J43").Value = TextBox121.Text 'Total
        xlibro.Range("O43").Value = TextBox141.Text 'Para costo de Reposicion articulos de GSI

        xlibro.Range("D47").Value = CboLugar.Text
        xlibro.Range("D48").Value = TxtPlazo.Text
        xlibro.Range("D49").Value = Cbopago.Text
        xlibro.Range("D50").Value = CboValidez.Text

    End Sub

    Private Sub TextBox51_TextChanged(sender As Object, e As EventArgs) Handles TextBox51.TextChanged

    End Sub


#End Region

#Region "guardar base datos SAFRATEC"
    Private Sub BD1_CheckedChanged(sender As Object, e As EventArgs) Handles BD1.CheckedChanged
        ' para comenzar insertar valores en la data 
        ' Verifico que haya escrito el ISBN (bueno, debería verificarlos todos, pero como esta es la clave principal...)
        If TxtCot.Text = "" Then
            ' Si no lo escribió, mando mensaje de error
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            ' Si sí lo escribió, comienza la diversión (jeje)
            ' Armo la instrucción INSERT en la variable SQL

            sql = S & (TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & TxtFecha.Text & "','" & TxtRazon.Text & "','" & TxtRut.Text & "','" & TxtAtencion.Text & "','" & TxtDireccion.Text & "','" & TxtphoneC.Text & "','" & TxtCorreoC.Text & "','" & CboContacto.Text & "','" & TxtphoneV.Text & "','" & TxtCorreoV.Text & "','" & TxtWeb.Text & "','" & TxtReferencia.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & NumericUpDown1.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & Label29.Text & "','" & ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & Label49.Text & "')"

            ' Asigno la instrucción SQL que se va a ejecutar
            comm.CommandText = sql

            Try
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "SAFRATEC")
            End Try
        End If
    End Sub

    Private Sub BD2_CheckedChanged(sender As Object, e As EventArgs) Handles BD2.CheckedChanged
        ' para comenzar insertar valores en la data 
        ' Verifico que haya escrito el ISBN (bueno, debería verificarlos todos, pero como esta es la clave principal...)
        If TxtCot.Text = "" Then
            ' Si no lo escribió, mando mensaje de error
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            ' Si sí lo escribió, comienza la diversión (jeje)
            ' Armo la instrucción INSERT en la variable SQL

            sql = S & (TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & TxtFecha.Text & "','" & TxtRazon.Text & "','" & TxtRut.Text & "','" & TxtAtencion.Text & "','" & TxtDireccion.Text & "','" & TxtphoneC.Text & "','" & TxtCorreoC.Text & "','" & CboContacto.Text & "','" & TxtphoneV.Text & "','" & TxtCorreoV.Text & "','" & TxtWeb.Text & "','" & TxtReferencia.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & NumericUpDown2.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & Label30.Text & "','" & ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & Label50.Text & "')"

            ' Asigno la instrucción SQL que se va a ejecutar
            comm.CommandText = sql

            Try
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "SAFRATEC")
            End Try
        End If
    End Sub

    Private Sub BD3_CheckedChanged(sender As Object, e As EventArgs) Handles BD3.CheckedChanged
        ' para comenzar insertar valores en la data 
        ' Verifico que haya escrito el ISBN (bueno, debería verificarlos todos, pero como esta es la clave principal...)
        If TxtCot.Text = "" Then
            ' Si no lo escribió, mando mensaje de error
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            ' Si sí lo escribió, comienza la diversión (jeje)
            ' Armo la instrucción INSERT en la variable SQL

            sql = S & (TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & TxtFecha.Text & "','" & TxtRazon.Text & "','" & TxtRut.Text & "','" & TxtAtencion.Text & "','" & TxtDireccion.Text & "','" & TxtphoneC.Text & "','" & TxtCorreoC.Text & "','" & CboContacto.Text & "','" & TxtphoneV.Text & "','" & TxtCorreoV.Text & "','" & TxtWeb.Text & "','" & TxtReferencia.Text & "','" & TextBox9.Text & "','" & TextBox10.Text & "','" & NumericUpDown3.Text & "','" & TextBox11.Text & "','" & TextBox12.Text & "','" & Label31.Text & "','" & ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & Label51.Text & "')"

            ' Asigno la instrucción SQL que se va a ejecutar
            comm.CommandText = sql

            Try
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "SAFRATEC")
            End Try
        End If
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
        ' para comenzar insertar valores en la data 
        ' Verifico que haya escrito el ISBN (bueno, debería verificarlos todos, pero como esta es la clave principal...)
        If TxtCot.Text = "" Then
            ' Si no lo escribió, mando mensaje de error
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            ' Si sí lo escribió, comienza la diversión (jeje)
            ' Armo la instrucción INSERT en la variable SQL

            sql = S & (TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & TxtFecha.Text & "','" & TxtRazon.Text & "','" & TxtRut.Text & "','" & TxtAtencion.Text & "','" & TxtDireccion.Text & "','" & TxtphoneC.Text & "','" & TxtCorreoC.Text & "','" & CboContacto.Text & "','" & TxtphoneV.Text & "','" & TxtCorreoV.Text & "','" & TxtWeb.Text & "','" & TxtReferencia.Text & "','" & TextBox13.Text & "','" & TextBox14.Text & "','" & NumericUpDown4.Text & "','" & TextBox15.Text & "','" & TextBox16.Text & "','" & Label32.Text & "','" & ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & Label52.Text & "')"

            ' Asigno la instrucción SQL que se va a ejecutar
            comm.CommandText = sql

            Try
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "SAFRATEC")
            End Try
        End If
    End Sub

    Private Sub BD5_CheckedChanged(sender As Object, e As EventArgs) Handles BD5.CheckedChanged
        ' para comenzar insertar valores en la data 
        ' Verifico que haya escrito el ISBN (bueno, debería verificarlos todos, pero como esta es la clave principal...)
        If TxtCot.Text = "" Then
            ' Si no lo escribió, mando mensaje de error
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            ' Si sí lo escribió, comienza la diversión (jeje)
            ' Armo la instrucción INSERT en la variable SQL

            sql = S & (TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & TxtFecha.Text & "','" & TxtRazon.Text & "','" & TxtRut.Text & "','" & TxtAtencion.Text & "','" & TxtDireccion.Text & "','" & TxtphoneC.Text & "','" & TxtCorreoC.Text & "','" & CboContacto.Text & "','" & TxtphoneV.Text & "','" & TxtCorreoV.Text & "','" & TxtWeb.Text & "','" & TxtReferencia.Text & "','" & TextBox17.Text & "','" & TextBox18.Text & "','" & NumericUpDown5.Text & "','" & TextBox19.Text & "','" & TextBox20.Text & "','" & Label33.Text & "','" & ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & Label53.Text & "')"

            ' Asigno la instrucción SQL que se va a ejecutar
            comm.CommandText = sql

            Try
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "SAFRATEC")
            End Try
        End If
    End Sub

    Private Sub BD6_CheckedChanged(sender As Object, e As EventArgs) Handles BD6.CheckedChanged
        ' para comenzar insertar valores en la data 
        ' Verifico que haya escrito el ISBN (bueno, debería verificarlos todos, pero como esta es la clave principal...)
        If TxtCot.Text = "" Then
            ' Si no lo escribió, mando mensaje de error
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            ' Si sí lo escribió, comienza la diversión (jeje)
            ' Armo la instrucción INSERT en la variable SQL

            sql = S & (TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & TxtFecha.Text & "','" & TxtRazon.Text & "','" & TxtRut.Text & "','" & TxtAtencion.Text & "','" & TxtDireccion.Text & "','" & TxtphoneC.Text & "','" & TxtCorreoC.Text & "','" & CboContacto.Text & "','" & TxtphoneV.Text & "','" & TxtCorreoV.Text & "','" & TxtWeb.Text & "','" & TxtReferencia.Text & "','" & TextBox21.Text & "','" & TextBox22.Text & "','" & NumericUpDown6.Text & "','" & TextBox23.Text & "','" & TextBox24.Text & "','" & Label34.Text & "','" & ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & Label54.Text & "')"

            ' Asigno la instrucción SQL que se va a ejecutar
            comm.CommandText = sql

            Try
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "SAFRATEC")
            End Try
        End If
    End Sub

    Private Sub BD7_CheckedChanged(sender As Object, e As EventArgs) Handles BD7.CheckedChanged
        ' para comenzar insertar valores en la data 
        ' Verifico que haya escrito el ISBN (bueno, debería verificarlos todos, pero como esta es la clave principal...)
        If TxtCot.Text = "" Then
            ' Si no lo escribió, mando mensaje de error
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            ' Si sí lo escribió, comienza la diversión (jeje)
            ' Armo la instrucción INSERT en la variable SQL

            sql = S & (TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & TxtFecha.Text & "','" & TxtRazon.Text & "','" & TxtRut.Text & "','" & TxtAtencion.Text & "','" & TxtDireccion.Text & "','" & TxtphoneC.Text & "','" & TxtCorreoC.Text & "','" & CboContacto.Text & "','" & TxtphoneV.Text & "','" & TxtCorreoV.Text & "','" & TxtWeb.Text & "','" & TxtReferencia.Text & "','" & TextBox25.Text & "','" & TextBox26.Text & "','" & NumericUpDown7.Text & "','" & TextBox27.Text & "','" & TextBox28.Text & "','" & Label35.Text & "','" & ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & Label55.Text & "')"

            ' Asigno la instrucción SQL que se va a ejecutar
            comm.CommandText = sql

            Try
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "SAFRATEC")
            End Try
        End If
    End Sub

    Private Sub BD8_CheckedChanged(sender As Object, e As EventArgs) Handles BD8.CheckedChanged
        ' para comenzar insertar valores en la data 
        ' Verifico que haya escrito el ISBN (bueno, debería verificarlos todos, pero como esta es la clave principal...)
        If TxtCot.Text = "" Then
            ' Si no lo escribió, mando mensaje de error
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            ' Si sí lo escribió, comienza la diversión (jeje)
            ' Armo la instrucción INSERT en la variable SQL

            sql = S & (TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & TxtFecha.Text & "','" & TxtRazon.Text & "','" & TxtRut.Text & "','" & TxtAtencion.Text & "','" & TxtDireccion.Text & "','" & TxtphoneC.Text & "','" & TxtCorreoC.Text & "','" & CboContacto.Text & "','" & TxtphoneV.Text & "','" & TxtCorreoV.Text & "','" & TxtWeb.Text & "','" & TxtReferencia.Text & "','" & TextBox29.Text & "','" & TextBox30.Text & "','" & NumericUpDown8.Text & "','" & TextBox31.Text & "','" & TextBox32.Text & "','" & Label36.Text & "','" & ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & Label56.Text & "')"

            ' Asigno la instrucción SQL que se va a ejecutar
            comm.CommandText = sql

            Try
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "SAFRATEC")
            End Try
        End If
    End Sub

    Private Sub BD9_CheckedChanged(sender As Object, e As EventArgs) Handles BD9.CheckedChanged
        ' para comenzar insertar valores en la data 
        ' Verifico que haya escrito el ISBN (bueno, debería verificarlos todos, pero como esta es la clave principal...)
        If TxtCot.Text = "" Then
            ' Si no lo escribió, mando mensaje de error
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            ' Si sí lo escribió, comienza la diversión (jeje)
            ' Armo la instrucción INSERT en la variable SQL

            sql = S & (TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & TxtFecha.Text & "','" & TxtRazon.Text & "','" & TxtRut.Text & "','" & TxtAtencion.Text & "','" & TxtDireccion.Text & "','" & TxtphoneC.Text & "','" & TxtCorreoC.Text & "','" & CboContacto.Text & "','" & TxtphoneV.Text & "','" & TxtCorreoV.Text & "','" & TxtWeb.Text & "','" & TxtReferencia.Text & "','" & TextBox33.Text & "','" & TextBox34.Text & "','" & NumericUpDown9.Text & "','" & TextBox35.Text & "','" & TextBox36.Text & "','" & Label37.Text & "','" & ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & Label57.Text & "')"

            ' Asigno la instrucción SQL que se va a ejecutar
            comm.CommandText = sql

            Try
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "SAFRATEC")
            End Try
        End If
    End Sub

    Private Sub BD10_CheckedChanged(sender As Object, e As EventArgs) Handles BD10.CheckedChanged
        ' para comenzar insertar valores en la data 
        ' Verifico que haya escrito el ISBN (bueno, debería verificarlos todos, pero como esta es la clave principal...)
        If TxtCot.Text = "" Then
            ' Si no lo escribió, mando mensaje de error
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            ' Si sí lo escribió, comienza la diversión (jeje)
            ' Armo la instrucción INSERT en la variable SQL

            sql = S & (TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & TxtFecha.Text & "','" & TxtRazon.Text & "','" & TxtRut.Text & "','" & TxtAtencion.Text & "','" & TxtDireccion.Text & "','" & TxtphoneC.Text & "','" & TxtCorreoC.Text & "','" & CboContacto.Text & "','" & TxtphoneV.Text & "','" & TxtCorreoV.Text & "','" & TxtWeb.Text & "','" & TxtReferencia.Text & "','" & TextBox37.Text & "','" & TextBox38.Text & "','" & NumericUpDown10.Text & "','" & TextBox39.Text & "','" & TextBox40.Text & "','" & Label38.Text & "','" & ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & Label58.Text & "')"

            ' Asigno la instrucción SQL que se va a ejecutar
            comm.CommandText = sql

            Try
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "SAFRATEC")
            End Try
        End If
    End Sub
    Private Sub BD11_CheckedChanged(sender As Object, e As EventArgs) Handles BD11.CheckedChanged
        ' para comenzar insertar valores en la data 
        ' Verifico que haya escrito el ISBN (bueno, debería verificarlos todos, pero como esta es la clave principal...)
        If TxtCot.Text = "" Then
            ' Si no lo escribió, mando mensaje de error
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            ' Si sí lo escribió, comienza la diversión (jeje)
            ' Armo la instrucción INSERT en la variable SQL

            sql = S & (TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & TxtFecha.Text & "','" & TxtRazon.Text & "','" & TxtRut.Text & "','" & TxtAtencion.Text & "','" & TxtDireccion.Text & "','" & TxtphoneC.Text & "','" & TxtCorreoC.Text & "','" & CboContacto.Text & "','" & TxtphoneV.Text & "','" & TxtCorreoV.Text & "','" & TxtWeb.Text & "','" & TxtReferencia.Text & "','" & TextBox62.Text & "','" & TextBox63.Text & "','" & NumericUpDown11.Text & "','" & TextBox64.Text & "','" & TextBox65.Text & "','" & Label39.Text & "','" & ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & Label59.Text & "')"

            ' Asigno la instrucción SQL que se va a ejecutar
            comm.CommandText = sql

            Try
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "SAFRATEC")
            End Try
        End If
    End Sub
    Private Sub BD12_CheckedChanged(sender As Object, e As EventArgs) Handles BD12.CheckedChanged
        ' para comenzar insertar valores en la data 
        ' Verifico que haya escrito el ISBN (bueno, debería verificarlos todos, pero como esta es la clave principal...)
        If TxtCot.Text = "" Then
            ' Si no lo escribió, mando mensaje de error
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            ' Si sí lo escribió, comienza la diversión (jeje)
            ' Armo la instrucción INSERT en la variable SQL

            sql = S & (TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & TxtFecha.Text & "','" & TxtRazon.Text & "','" & TxtRut.Text & "','" & TxtAtencion.Text & "','" & TxtDireccion.Text & "','" & TxtphoneC.Text & "','" & TxtCorreoC.Text & "','" & CboContacto.Text & "','" & TxtphoneV.Text & "','" & TxtCorreoV.Text & "','" & TxtWeb.Text & "','" & TxtReferencia.Text & "','" & TextBox66.Text & "','" & TextBox67.Text & "','" & NumericUpDown12.Text & "','" & TextBox68.Text & "','" & TextBox69.Text & "','" & Label40.Text & "','" & ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & Label60.Text & "')"

            ' Asigno la instrucción SQL que se va a ejecutar
            comm.CommandText = sql

            Try
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "SAFRATEC")
            End Try
        End If
    End Sub
    Private Sub BD13_CheckedChanged(sender As Object, e As EventArgs) Handles BD13.CheckedChanged
        ' para comenzar insertar valores en la data 
        ' Verifico que haya escrito el ISBN (bueno, debería verificarlos todos, pero como esta es la clave principal...)
        If TxtCot.Text = "" Then
            ' Si no lo escribió, mando mensaje de error
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            ' Si sí lo escribió, comienza la diversión (jeje)
            ' Armo la instrucción INSERT en la variable SQL

            sql = S & (TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & TxtFecha.Text & "','" & TxtRazon.Text & "','" & TxtRut.Text & "','" & TxtAtencion.Text & "','" & TxtDireccion.Text & "','" & TxtphoneC.Text & "','" & TxtCorreoC.Text & "','" & CboContacto.Text & "','" & TxtphoneV.Text & "','" & TxtCorreoV.Text & "','" & TxtWeb.Text & "','" & TxtReferencia.Text & "','" & TextBox70.Text & "','" & TextBox71.Text & "','" & NumericUpDown13.Text & "','" & TextBox72.Text & "','" & TextBox73.Text & "','" & Label41.Text & "','" & ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & Label61.Text & "')"

            ' Asigno la instrucción SQL que se va a ejecutar
            comm.CommandText = sql

            Try
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "SAFRATEC")
            End Try
        End If
    End Sub
    Private Sub BD14_CheckedChanged(sender As Object, e As EventArgs) Handles BD14.CheckedChanged
        ' para comenzar insertar valores en la data 
        ' Verifico que haya escrito el ISBN (bueno, debería verificarlos todos, pero como esta es la clave principal...)
        If TxtCot.Text = "" Then
            ' Si no lo escribió, mando mensaje de error
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            ' Si sí lo escribió, comienza la diversión (jeje)
            ' Armo la instrucción INSERT en la variable SQL

            sql = S & (TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & TxtFecha.Text & "','" & TxtRazon.Text & "','" & TxtRut.Text & "','" & TxtAtencion.Text & "','" & TxtDireccion.Text & "','" & TxtphoneC.Text & "','" & TxtCorreoC.Text & "','" & CboContacto.Text & "','" & TxtphoneV.Text & "','" & TxtCorreoV.Text & "','" & TxtWeb.Text & "','" & TxtReferencia.Text & "','" & TextBox74.Text & "','" & TextBox75.Text & "','" & NumericUpDown14.Text & "','" & TextBox76.Text & "','" & TextBox77.Text & "','" & Label42.Text & "','" & ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & Label62.Text & "')"

            ' Asigno la instrucción SQL que se va a ejecutar
            comm.CommandText = sql

            Try
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "SAFRATEC")
            End Try
        End If
    End Sub
    Private Sub BD15_CheckedChanged(sender As Object, e As EventArgs) Handles BD15.CheckedChanged
        ' para comenzar insertar valores en la data 
        ' Verifico que haya escrito el ISBN (bueno, debería verificarlos todos, pero como esta es la clave principal...)
        If TxtCot.Text = "" Then
            ' Si no lo escribió, mando mensaje de error
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            ' Si sí lo escribió, comienza la diversión (jeje)
            ' Armo la instrucción INSERT en la variable SQL

            sql = S & (TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & TxtFecha.Text & "','" & TxtRazon.Text & "','" & TxtRut.Text & "','" & TxtAtencion.Text & "','" & TxtDireccion.Text & "','" & TxtphoneC.Text & "','" & TxtCorreoC.Text & "','" & CboContacto.Text & "','" & TxtphoneV.Text & "','" & TxtCorreoV.Text & "','" & TxtWeb.Text & "','" & TxtReferencia.Text & "','" & TextBox78.Text & "','" & TextBox79.Text & "','" & NumericUpDown15.Text & "','" & TextBox80.Text & "','" & TextBox81.Text & "','" & Label43.Text & "','" & ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & Label63.Text & "')"

            ' Asigno la instrucción SQL que se va a ejecutar
            comm.CommandText = sql

            Try
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "SAFRATEC")
            End Try
        End If
    End Sub
    Private Sub BD16_CheckedChanged(sender As Object, e As EventArgs) Handles BD16.CheckedChanged
        ' para comenzar insertar valores en la data 
        ' Verifico que haya escrito el ISBN (bueno, debería verificarlos todos, pero como esta es la clave principal...)
        If TxtCot.Text = "" Then
            ' Si no lo escribió, mando mensaje de error
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            ' Si sí lo escribió, comienza la diversión (jeje)
            ' Armo la instrucción INSERT en la variable SQL

            sql = S & (TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & TxtFecha.Text & "','" & TxtRazon.Text & "','" & TxtRut.Text & "','" & TxtAtencion.Text & "','" & TxtDireccion.Text & "','" & TxtphoneC.Text & "','" & TxtCorreoC.Text & "','" & CboContacto.Text & "','" & TxtphoneV.Text & "','" & TxtCorreoV.Text & "','" & TxtWeb.Text & "','" & TxtReferencia.Text & "','" & TextBox82.Text & "','" & TextBox83.Text & "','" & NumericUpDown16.Text & "','" & TextBox84.Text & "','" & TextBox85.Text & "','" & Label44.Text & "','" & ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & Label64.Text & "')"

            ' Asigno la instrucción SQL que se va a ejecutar
            comm.CommandText = sql

            Try
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "SAFRATEC")
            End Try
        End If
    End Sub
    Private Sub BD17_CheckedChanged(sender As Object, e As EventArgs) Handles BD17.CheckedChanged
        ' para comenzar insertar valores en la data 
        ' Verifico que haya escrito el ISBN (bueno, debería verificarlos todos, pero como esta es la clave principal...)
        If TxtCot.Text = "" Then
            ' Si no lo escribió, mando mensaje de error
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            ' Si sí lo escribió, comienza la diversión (jeje)
            ' Armo la instrucción INSERT en la variable SQL

            sql = S & (TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & TxtFecha.Text & "','" & TxtRazon.Text & "','" & TxtRut.Text & "','" & TxtAtencion.Text & "','" & TxtDireccion.Text & "','" & TxtphoneC.Text & "','" & TxtCorreoC.Text & "','" & CboContacto.Text & "','" & TxtphoneV.Text & "','" & TxtCorreoV.Text & "','" & TxtWeb.Text & "','" & TxtReferencia.Text & "','" & TextBox86.Text & "','" & TextBox87.Text & "','" & NumericUpDown17.Text & "','" & TextBox88.Text & "','" & TextBox89.Text & "','" & Label45.Text & "','" & ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & Label65.Text & "')"

            ' Asigno la instrucción SQL que se va a ejecutar
            comm.CommandText = sql

            Try
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "SAFRATEC")
            End Try
        End If
    End Sub
    Private Sub BD18_CheckedChanged(sender As Object, e As EventArgs) Handles BD18.CheckedChanged
        ' para comenzar insertar valores en la data 
        ' Verifico que haya escrito el ISBN (bueno, debería verificarlos todos, pero como esta es la clave principal...)
        If TxtCot.Text = "" Then
            ' Si no lo escribió, mando mensaje de error
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            ' Si sí lo escribió, comienza la diversión (jeje)
            ' Armo la instrucción INSERT en la variable SQL

            sql = S & (TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & TxtFecha.Text & "','" & TxtRazon.Text & "','" & TxtRut.Text & "','" & TxtAtencion.Text & "','" & TxtDireccion.Text & "','" & TxtphoneC.Text & "','" & TxtCorreoC.Text & "','" & CboContacto.Text & "','" & TxtphoneV.Text & "','" & TxtCorreoV.Text & "','" & TxtWeb.Text & "','" & TxtReferencia.Text & "','" & TextBox90.Text & "','" & TextBox91.Text & "','" & NumericUpDown18.Text & "','" & TextBox92.Text & "','" & TextBox93.Text & "''" & Label46.Text & "','" & ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & Label66.Text & "')"

            ' Asigno la instrucción SQL que se va a ejecutar
            comm.CommandText = sql

            Try
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "SAFRATEC")
            End Try
        End If
    End Sub
    Private Sub BD19_CheckedChanged(sender As Object, e As EventArgs) Handles BD19.CheckedChanged
        ' para comenzar insertar valores en la data 
        ' Verifico que haya escrito el ISBN (bueno, debería verificarlos todos, pero como esta es la clave principal...)
        If TxtCot.Text = "" Then
            ' Si no lo escribió, mando mensaje de error
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            ' Si sí lo escribió, comienza la diversión (jeje)
            ' Armo la instrucción INSERT en la variable SQL

            sql = S & (TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & TxtFecha.Text & "','" & TxtRazon.Text & "','" & TxtRut.Text & "','" & TxtAtencion.Text & "','" & TxtDireccion.Text & "','" & TxtphoneC.Text & "','" & TxtCorreoC.Text & "','" & CboContacto.Text & "','" & TxtphoneV.Text & "','" & TxtCorreoV.Text & "','" & TxtWeb.Text & "','" & TxtReferencia.Text & "','" & TextBox94.Text & "','" & TextBox95.Text & "','" & NumericUpDown19.Text & "','" & TextBox96.Text & "','" & TextBox97.Text & "','" & Label47.Text & "','" & ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & Label67.Text & "')"

            ' Asigno la instrucción SQL que se va a ejecutar
            comm.CommandText = sql

            Try
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "SAFRATEC")
            End Try
        End If
    End Sub
    Private Sub BD20_CheckedChanged(sender As Object, e As EventArgs) Handles BD20.CheckedChanged
        ' para comenzar insertar valores en la data 
        ' Verifico que haya escrito el ISBN (bueno, debería verificarlos todos, pero como esta es la clave principal...)
        If TxtCot.Text = "" Then
            ' Si no lo escribió, mando mensaje de error
            MsgBox("Debe incluir # Cotizacion")
            TxtCot.Select()
        Else
            ' Si sí lo escribió, comienza la diversión (jeje)
            ' Armo la instrucción INSERT en la variable SQL

            sql = S & (TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & TxtFecha.Text & "','" & TxtRazon.Text & "','" & TxtRut.Text & "','" & TxtAtencion.Text & "','" & TxtDireccion.Text & "','" & TxtphoneC.Text & "','" & TxtCorreoC.Text & "','" & CboContacto.Text & "','" & TxtphoneV.Text & "','" & TxtCorreoV.Text & "','" & TxtWeb.Text & "','" & TxtReferencia.Text & "','" & TextBox98.Text & "','" & TextBox99.Text & "','" & NumericUpDown20.Text & "','" & TextBox100.Text & "','" & TextBox101.Text & "','" & Label48.Text & "','" & ("SAFRATEC" & TxtCot.Text & Txtcot2.Text & Txtcot3.Text) & "','" & Label68.Text & "')"

            ' Asigno la instrucción SQL que se va a ejecutar
            comm.CommandText = sql

            Try
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "SAFRATEC")
            End Try
        End If
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        ' para comenzar insertar valores en la data 
        ' Verifico que haya escrito el ISBN (bueno, debería verificarlos todos, pero como esta es la clave principal...)
        If TxtRut.Text = "" Then
            ' Si no lo escribió, mando mensaje de error
            MsgBox("Debe incluir RUT")
            TxtRut.Select()
        Else
            'Para asegurar si esta correcto el registro
            If TxtAtencion.Text > "" Then
                If MessageBox.Show("¿ Seguro que desea insertar este registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then


                    ' Si sí lo escribió, comienza la diversión (jeje)
                    ' Armo la instrucción INSERT en la variable SQL
                    sql = A & TxtRazon.Text & "','" & TxtRut.Text & "','" & TxtAtencion.Text & "','" & TxtDireccion.Text & "','" & TxtphoneC.Text & "','" & TxtCorreoC.Text & "')"

                    ' Asigno la instrucción SQL que se va a ejecutar
                    comm.CommandText = sql

                    Try
                        comm.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(Err.Description, MsgBoxStyle.Exclamation, "SAFRATEC")
                    End Try
                End If
            End If
        End If

    End Sub
#End Region

#Region "Para Exportar con descuento por items Mario Correa"

    Private Sub CheckBox22_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox22.CheckedChanged
        If CheckBox22.Checked = True Then
            BtnExportarMarioDesc.Visible = True
            CheckBox23.Checked = False
        Else CheckBox22.Checked = False
            BtnExportarMarioDesc.Visible = False
        End If
    End Sub

    Private Sub BtnExportarMarioDesc_Click(sender As Object, e As EventArgs) Handles BtnExportarMarioDesc.Click
        Dim xlibro As Microsoft.Office.Interop.Excel.Application
        Dim strRutaExcel As String

        strRutaExcel = "C:\SOURCESAFRATEC\Planilla de Cotizacion.xlsm"

        xlibro = CreateObject("Excel.Application")
        xlibro.Workbooks.Open(strRutaExcel)

        'Activamos el libro
        xlibro.Workbooks("Planilla de Cotizacion.xlsm").Activate()

        'Activamos la hoja especifica del libro  
        xlibro.Sheets("Planilla de Cotizacion MC Desc").Select()

        Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = xlibro.Sheets.Item("Planilla de Cotizacion MC Desc")
        xlibro.Visible = True
        'Ahora podemos llevar el contenido de un textbox a una celda de excel expecifica copn la siguiente instrucción

        xlibro.Range("D15").Value = TxtRazon.Text 'Razon social
        xlibro.Range("D16").Value = TxtAtencion.Text 'Atencion
        xlibro.Range("D17").Value = TxtRut.Text 'RUT
        xlibro.Range("D18").Value = TxtDireccion.Text 'Direccion 
        xlibro.Range("D19").Value = TxtphoneC.Text 'Telefono cliente
        xlibro.Range("D20").Value = TxtCorreoC.Text ' Correo de Cliente

        xlibro.Range("I10").Value = "N#  " + TxtCot.Text + Txtcot2.Text + Txtcot3.Text '# de Cotizacion
        xlibro.Range("J16").Value = TxtFecha.Text ' Fecha del Dia
        'xlibro.Range("H13").Value = CboContacto.Text 'Vendedor


        xlibro.Range("J17").Value = CboContacto.Text 'Vendedor
        xlibro.Range("J18").Value = TxtCorreoV.Text 'Correo de Vendedor
        xlibro.Range("J19").Value = TxtWeb.Text 'Pagina web
        xlibro.Range("J20").Value = TxtphoneV.Text 'Telefono vendedor

        xlibro.Range("D21").Value = TxtReferencia.Text 'Referencia 


        '''' Para primera linea activa de Materiales
        xlibro.Range("D24").Value = TextBox1.Text 'Descripcion de Materiales
        xlibro.Range("C24").Value = TextBox2.Text 'Codigo del Material
        xlibro.Range("I24").Value = NumericUpDown1.Text 'Cantidad del Material
        xlibro.Range("J24").Value = TextBox4.Text ' Precio del Material
        xlibro.Range("N24").Value = TextBox41.Text 'Costo de Defontana
        xlibro.Range("O24").Value = TextBox3.Text 'Margen (%)
        xlibro.Range("K24").Value = TextBox52.Text 'Total
        xlibro.Range("P24").Value = TextBox122.Text 'Para costo de Reposicion articulos de GSI

        ' 2 linea de Materiales
        xlibro.Range("D25").Value = TextBox5.Text 'Descripcion de Materiales
        xlibro.Range("C25").Value = TextBox6.Text 'Codigo del Material
        xlibro.Range("I25").Value = NumericUpDown2.Text 'Cantidad del Material
        xlibro.Range("J25").Value = TextBox8.Text ' Precio del Material
        xlibro.Range("N25").Value = TextBox42.Text 'Costo de Defontana
        xlibro.Range("O25").Value = TextBox7.Text 'Margen (%)
        xlibro.Range("K25").Value = TextBox53.Text 'Total
        xlibro.Range("P25").Value = TextBox123.Text 'Para costo de Reposicion articulos de GSI

        '3 linea de Materiales
        xlibro.Range("D26").Value = TextBox9.Text 'Descripcion de Materiales
        xlibro.Range("C26").Value = TextBox10.Text 'Codigo del Material
        xlibro.Range("I26").Value = NumericUpDown3.Text 'Cantidad del Material
        xlibro.Range("J26").Value = TextBox12.Text ' Precio del Material
        xlibro.Range("N26").Value = TextBox43.Text 'Costo de Defontana
        xlibro.Range("O26").Value = TextBox11.Text 'Margen (%)
        xlibro.Range("K26").Value = TextBox54.Text 'Total
        xlibro.Range("P26").Value = TextBox124.Text 'Para costo de Reposicion articulos de GSI

        '4 linea de Materiales
        xlibro.Range("D27").Value = TextBox13.Text 'Descripcion de Materiales
        xlibro.Range("C27").Value = TextBox14.Text 'Codigo del Material
        xlibro.Range("I27").Value = NumericUpDown4.Text 'Cantidad del Material
        xlibro.Range("J27").Value = TextBox16.Text ' Precio del Material
        xlibro.Range("N27").Value = TextBox44.Text 'Costo de Defontana
        xlibro.Range("O27").Value = TextBox15.Text 'Margen (%)
        xlibro.Range("K27").Value = TextBox55.Text 'Total
        xlibro.Range("P27").Value = TextBox125.Text 'Para costo de Reposicion articulos de GSI

        '5 linea de Materiales
        xlibro.Range("D28").Value = TextBox17.Text 'Descripcion de Materiales
        xlibro.Range("C28").Value = TextBox18.Text 'Codigo del Material
        xlibro.Range("I28").Value = NumericUpDown5.Text 'Cantidad del Material
        xlibro.Range("J28").Value = TextBox20.Text ' Precio del Material
        xlibro.Range("N28").Value = TextBox45.Text 'Costo de Defontana
        xlibro.Range("O28").Value = TextBox19.Text 'Margen (%)
        xlibro.Range("K28").Value = TextBox56.Text 'Total
        xlibro.Range("P28").Value = TextBox126.Text 'Para costo de Reposicion articulos de GSI

        '6 linea de Materiales
        xlibro.Range("D29").Value = TextBox21.Text 'Descripcion de Materiales
        xlibro.Range("C29").Value = TextBox22.Text 'Codigo del Material
        xlibro.Range("I29").Value = NumericUpDown6.Text 'Cantidad del Material
        xlibro.Range("J29").Value = TextBox24.Text ' Precio del Material
        xlibro.Range("N29").Value = TextBox46.Text 'Costo de Defontana
        xlibro.Range("O29").Value = TextBox23.Text 'Margen (%)
        xlibro.Range("K29").Value = TextBox57.Text 'Total
        xlibro.Range("P29").Value = TextBox127.Text 'Para costo de Reposicion articulos de GSI

        '7 linea de Materiales
        xlibro.Range("D30").Value = TextBox25.Text 'Descripcion de Materiales 
        xlibro.Range("C30").Value = TextBox26.Text 'Codigo del Material
        xlibro.Range("I30").Value = NumericUpDown7.Text 'Cantidad del Material
        xlibro.Range("J30").Value = TextBox28.Text ' Precio del Material
        xlibro.Range("N30").Value = TextBox47.Text 'Costo de Defontana
        xlibro.Range("O30").Value = TextBox27.Text 'Margen (%)
        xlibro.Range("K30").Value = TextBox58.Text 'Total
        xlibro.Range("P30").Value = TextBox128.Text 'Para costo de Reposicion articulos de GSI

        '8 Linea de Materiles
        xlibro.Range("D31").Value = TextBox29.Text 'Descripcion de Materiales
        xlibro.Range("C31").Value = TextBox30.Text 'Codigo del Material
        xlibro.Range("I31").Value = NumericUpDown8.Text 'Cantidad del Material
        xlibro.Range("J31").Value = TextBox32.Text ' Precio del Material
        xlibro.Range("N31").Value = TextBox48.Text 'Costo de Defontana
        xlibro.Range("O31").Value = TextBox31.Text 'Margen (%)
        xlibro.Range("K31").Value = TextBox59.Text 'Total
        xlibro.Range("P31").Value = TextBox129.Text 'Para costo de Reposicion articulos de GSI

        '9 linea de Materiales
        xlibro.Range("D32").Value = TextBox33.Text 'Descripcion de Materiales
        xlibro.Range("C32").Value = TextBox34.Text 'Codigo del Material
        xlibro.Range("I32").Value = NumericUpDown9.Text 'Cantidad del Material
        xlibro.Range("J32").Value = TextBox36.Text ' Precio del Material
        xlibro.Range("N32").Value = TextBox49.Text 'Costo de Defontana
        xlibro.Range("O32").Value = TextBox35.Text 'Margen (%)
        xlibro.Range("K32").Value = TextBox60.Text 'Total
        xlibro.Range("P32").Value = TextBox130.Text 'Para costo de Reposicion articulos de GSI

        ' 10 Linea de Materiales 
        xlibro.Range("D33").Value = TextBox37.Text 'Descripcion de Materiales
        xlibro.Range("C33").Value = TextBox38.Text 'Codigo del Material
        xlibro.Range("I33").Value = NumericUpDown10.Text 'Cantidad del Material
        xlibro.Range("J33").Value = TextBox40.Text ' Precio del Material
        xlibro.Range("N33").Value = TextBox50.Text 'Costo de Defontana
        xlibro.Range("O33").Value = TextBox39.Text 'Margen (%)
        xlibro.Range("K33").Value = TextBox61.Text 'Total
        xlibro.Range("P33").Value = TextBox131.Text 'Para costo de Reposicion articulos de GSI

        ' 11 Linea de Materiales 
        xlibro.Range("D34").Value = TextBox62.Text 'Descripcion de Materiales
        xlibro.Range("C34").Value = TextBox63.Text 'Codigo del Material
        xlibro.Range("I34").Value = NumericUpDown11.Text 'Cantidad del Material
        xlibro.Range("J34").Value = TextBox65.Text ' Precio del Material
        xlibro.Range("N34").Value = TextBox102.Text 'Costo de Defontana
        xlibro.Range("O34").Value = TextBox64.Text 'Margen (%)
        xlibro.Range("K34").Value = TextBox112.Text 'Total
        xlibro.Range("P34").Value = TextBox132.Text 'Para costo de Reposicion articulos de GSI

        ' 12 Linea de Materiales 
        xlibro.Range("D35").Value = TextBox66.Text 'Descripcion de Materiales
        xlibro.Range("C35").Value = TextBox67.Text 'Codigo del Material
        xlibro.Range("I35").Value = NumericUpDown12.Text 'Cantidad del Material
        xlibro.Range("J35").Value = TextBox69.Text ' Precio del Material
        xlibro.Range("N35").Value = TextBox103.Text 'Costo de Defontana
        xlibro.Range("O35").Value = TextBox68.Text 'Margen (%)
        xlibro.Range("K35").Value = TextBox113.Text 'Total
        xlibro.Range("P35").Value = TextBox133.Text 'Para costo de Reposicion articulos de GSI

        ' 13 Linea de Materiales 
        xlibro.Range("D36").Value = TextBox70.Text 'Descripcion de Materiales
        xlibro.Range("C36").Value = TextBox71.Text 'Codigo del Material
        xlibro.Range("I36").Value = NumericUpDown13.Text 'Cantidad del Material
        xlibro.Range("J36").Value = TextBox73.Text ' Precio del Material
        xlibro.Range("N36").Value = TextBox104.Text 'Costo de Defontana
        xlibro.Range("O36").Value = TextBox72.Text 'Margen (%)
        xlibro.Range("K36").Value = TextBox114.Text 'Total
        xlibro.Range("P36").Value = TextBox134.Text 'Para costo de Reposicion articulos de GSI

        ' 14 Linea de Materiales 
        xlibro.Range("D37").Value = TextBox74.Text 'Descripcion de Materiales
        xlibro.Range("C37").Value = TextBox75.Text 'Codigo del Material
        xlibro.Range("I37").Value = NumericUpDown14.Text 'Cantidad del Material
        xlibro.Range("J37").Value = TextBox77.Text ' Precio del Material
        xlibro.Range("N37").Value = TextBox105.Text 'Costo de Defontana
        xlibro.Range("O37").Value = TextBox76.Text 'Margen (%)
        xlibro.Range("K37").Value = TextBox115.Text 'Total
        xlibro.Range("P37").Value = TextBox135.Text 'Para costo de Reposicion articulos de GSI

        ' 15 Linea de Materiales 
        xlibro.Range("D38").Value = TextBox78.Text 'Descripcion de Materiales
        xlibro.Range("C38").Value = TextBox79.Text 'Codigo del Material
        xlibro.Range("I38").Value = NumericUpDown15.Text 'Cantidad del Material
        xlibro.Range("J38").Value = TextBox81.Text ' Precio del Material
        xlibro.Range("N38").Value = TextBox106.Text 'Costo de Defontana
        xlibro.Range("O38").Value = TextBox80.Text 'Margen (%)
        xlibro.Range("K38").Value = TextBox116.Text 'Total
        xlibro.Range("P38").Value = TextBox136.Text 'Para costo de Reposicion articulos de GSI

        ' 16 Linea de Materiales 
        xlibro.Range("D39").Value = TextBox82.Text 'Descripcion de Materiales
        xlibro.Range("C39").Value = TextBox83.Text 'Codigo del Material
        xlibro.Range("I39").Value = NumericUpDown16.Text 'Cantidad del Material
        xlibro.Range("J39").Value = TextBox85.Text ' Precio del Material
        xlibro.Range("N39").Value = TextBox107.Text 'Costo de Defontana
        xlibro.Range("O39").Value = TextBox84.Text 'Margen (%)
        xlibro.Range("K39").Value = TextBox117.Text 'Total
        xlibro.Range("P39").Value = TextBox137.Text 'Para costo de Reposicion articulos de GSI

        ' 17 Linea de Materiales 
        xlibro.Range("D40").Value = TextBox86.Text 'Descripcion de Materiales
        xlibro.Range("C40").Value = TextBox87.Text 'Codigo del Material
        xlibro.Range("I40").Value = NumericUpDown17.Text 'Cantidad del Material
        xlibro.Range("J40").Value = TextBox89.Text ' Precio del Material
        xlibro.Range("N40").Value = TextBox108.Text 'Costo de Defontana
        xlibro.Range("O40").Value = TextBox88.Text 'Margen (%)
        xlibro.Range("K40").Value = TextBox118.Text 'Total
        xlibro.Range("P40").Value = TextBox138.Text 'Para costo de Reposicion articulos de GSI

        ' 18 Linea de Materiales 
        xlibro.Range("D41").Value = TextBox90.Text 'Descripcion de Materiales
        xlibro.Range("C41").Value = TextBox91.Text 'Codigo del Material
        xlibro.Range("I41").Value = NumericUpDown18.Text 'Cantidad del Material
        xlibro.Range("J41").Value = TextBox93.Text ' Precio del Material
        xlibro.Range("N41").Value = TextBox109.Text 'Costo de Defontana
        xlibro.Range("O41").Value = TextBox92.Text 'Margen (%)
        xlibro.Range("K41").Value = TextBox119.Text 'Total
        xlibro.Range("P41").Value = TextBox139.Text 'Para costo de Reposicion articulos de GSI

        ' 19 Linea de Materiales 
        xlibro.Range("D42").Value = TextBox94.Text 'Descripcion de Materiales
        xlibro.Range("C42").Value = TextBox95.Text 'Codigo del Material
        xlibro.Range("I42").Value = NumericUpDown19.Text 'Cantidad del Material
        xlibro.Range("J42").Value = TextBox97.Text ' Precio del Material
        xlibro.Range("N42").Value = TextBox110.Text 'Costo de Defontana
        xlibro.Range("O42").Value = TextBox96.Text 'Margen (%)
        xlibro.Range("K42").Value = TextBox120.Text 'Total
        xlibro.Range("P42").Value = TextBox140.Text 'Para costo de Reposicion articulos de GSI

        ' 20 Linea de Materiales 
        xlibro.Range("D43").Value = TextBox98.Text 'Descripcion de Materiales
        xlibro.Range("C43").Value = TextBox99.Text 'Codigo del Material
        xlibro.Range("I43").Value = NumericUpDown20.Text 'Cantidad del Material
        xlibro.Range("J43").Value = TextBox101.Text ' Precio del Material
        xlibro.Range("N43").Value = TextBox111.Text 'Costo de Defontana
        xlibro.Range("O43").Value = TextBox100.Text 'Margen (%)
        xlibro.Range("K43").Value = TextBox121.Text 'Total
        xlibro.Range("P43").Value = TextBox141.Text 'Para costo de Reposicion articulos de GSI

        xlibro.Range("D47").Value = CboLugar.Text
        xlibro.Range("D48").Value = TxtPlazo.Text
        xlibro.Range("D49").Value = Cbopago.Text
        xlibro.Range("D50").Value = CboValidez.Text


    End Sub


#End Region

#Region "Para exportar a planilla de cotizacion descuento total mario correa"
    Private Sub BtnExportarMarioDesT_Click(sender As Object, e As EventArgs) Handles BtnExportarMarioDesT.Click
        Dim xlibro As Microsoft.Office.Interop.Excel.Application
        Dim strRutaExcel As String

        strRutaExcel = "C:\SOURCESAFRATEC\Planilla de Cotizacion.xlsm"

        xlibro = CreateObject("Excel.Application")
        xlibro.Workbooks.Open(strRutaExcel)

        'Activamos el libro
        xlibro.Workbooks("Planilla de Cotizacion.xlsm").Activate()

        'Activamos la hoja especifica del libro  
        xlibro.Sheets("Planilla de Cotizacion MC DesT").Select()

        Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = xlibro.Sheets.Item("Planilla de Cotizacion MC DesT")
        xlibro.Visible = True
        'Ahora podemos llevar el contenido de un textbox a una celda de excel expecifica copn la siguiente instrucción

        xlibro.Range("D15").Value = TxtRazon.Text 'Razon social
        xlibro.Range("D16").Value = TxtAtencion.Text 'Atencion
        xlibro.Range("D17").Value = TxtRut.Text 'RUT
        xlibro.Range("D18").Value = TxtDireccion.Text 'Direccion 
        xlibro.Range("D19").Value = TxtphoneC.Text 'Telefono cliente
        xlibro.Range("D20").Value = TxtCorreoC.Text ' Correo de Cliente

        xlibro.Range("H10").Value = "N#  " + TxtCot.Text + Txtcot2.Text + Txtcot3.Text '# de Cotizacion
        xlibro.Range("I16").Value = TxtFecha.Text ' Fecha del Dia
        'xlibro.Range("H13").Value = CboContacto.Text 'Vendedor


        xlibro.Range("I17").Value = CboContacto.Text 'Vendedor
        xlibro.Range("I18").Value = TxtCorreoV.Text 'Correo de Vendedor
        xlibro.Range("I19").Value = TxtWeb.Text 'Pagina web
        xlibro.Range("I20").Value = TxtphoneV.Text 'Telefono vendedor

        xlibro.Range("D21").Value = TxtReferencia.Text 'Referencia 


        '''' Para primera linea activa de Materiales
        xlibro.Range("D24").Value = TextBox1.Text 'Descripcion de Materiales
        xlibro.Range("C24").Value = TextBox2.Text 'Codigo del Material
        xlibro.Range("H24").Value = NumericUpDown1.Text 'Cantidad del Material
        xlibro.Range("I24").Value = TextBox4.Text ' Precio del Material
        xlibro.Range("M24").Value = TextBox41.Text 'Costo de Defontana
        xlibro.Range("N24").Value = TextBox3.Text 'Margen (%)
        xlibro.Range("J24").Value = TextBox52.Text 'Total
        xlibro.Range("O24").Value = TextBox122.Text 'Para costo de Reposicion articulos de GSI

        ' 2 linea de Materiales
        xlibro.Range("D25").Value = TextBox5.Text 'Descripcion de Materiales
        xlibro.Range("C25").Value = TextBox6.Text 'Codigo del Material
        xlibro.Range("H25").Value = NumericUpDown2.Text 'Cantidad del Material
        xlibro.Range("I25").Value = TextBox8.Text ' Precio del Material
        xlibro.Range("M25").Value = TextBox42.Text 'Costo de Defontana
        xlibro.Range("N25").Value = TextBox7.Text 'Margen (%)
        xlibro.Range("J25").Value = TextBox53.Text 'Total
        xlibro.Range("O25").Value = TextBox123.Text 'Para costo de Reposicion articulos de GSI

        '3 linea de Materiales
        xlibro.Range("D26").Value = TextBox9.Text 'Descripcion de Materiales
        xlibro.Range("C26").Value = TextBox10.Text 'Codigo del Material
        xlibro.Range("H26").Value = NumericUpDown3.Text 'Cantidad del Material
        xlibro.Range("I26").Value = TextBox12.Text ' Precio del Material
        xlibro.Range("M26").Value = TextBox43.Text 'Costo de Defontana
        xlibro.Range("N26").Value = TextBox11.Text 'Margen (%)
        xlibro.Range("J26").Value = TextBox54.Text 'Total
        xlibro.Range("O26").Value = TextBox124.Text 'Para costo de Reposicion articulos de GSI

        '4 linea de Materiales
        xlibro.Range("D27").Value = TextBox13.Text 'Descripcion de Materiales
        xlibro.Range("C27").Value = TextBox14.Text 'Codigo del Material
        xlibro.Range("H27").Value = NumericUpDown4.Text 'Cantidad del Material
        xlibro.Range("I27").Value = TextBox16.Text ' Precio del Material
        xlibro.Range("M27").Value = TextBox44.Text 'Costo de Defontana
        xlibro.Range("N27").Value = TextBox15.Text 'Margen (%)
        xlibro.Range("J27").Value = TextBox55.Text 'Total
        xlibro.Range("O27").Value = TextBox125.Text 'Para costo de Reposicion articulos de GSI

        '5 linea de Materiales
        xlibro.Range("D28").Value = TextBox17.Text 'Descripcion de Materiales
        xlibro.Range("C28").Value = TextBox18.Text 'Codigo del Material
        xlibro.Range("H28").Value = NumericUpDown5.Text 'Cantidad del Material
        xlibro.Range("I28").Value = TextBox20.Text ' Precio del Material
        xlibro.Range("M28").Value = TextBox45.Text 'Costo de Defontana
        xlibro.Range("N28").Value = TextBox19.Text 'Margen (%)
        xlibro.Range("J28").Value = TextBox56.Text 'Total
        xlibro.Range("O28").Value = TextBox126.Text 'Para costo de Reposicion articulos de GSI

        '6 linea de Materiales
        xlibro.Range("D29").Value = TextBox21.Text 'Descripcion de Materiales
        xlibro.Range("C29").Value = TextBox22.Text 'Codigo del Material
        xlibro.Range("H29").Value = NumericUpDown6.Text 'Cantidad del Material
        xlibro.Range("I29").Value = TextBox24.Text ' Precio del Material
        xlibro.Range("M29").Value = TextBox46.Text 'Costo de Defontana
        xlibro.Range("N29").Value = TextBox23.Text 'Margen (%)
        xlibro.Range("J29").Value = TextBox57.Text 'Total
        xlibro.Range("O29").Value = TextBox127.Text 'Para costo de Reposicion articulos de GSI

        '7 linea de Materiales
        xlibro.Range("D30").Value = TextBox25.Text 'Descripcion de Materiales
        xlibro.Range("C30").Value = TextBox26.Text 'Codigo del Material
        xlibro.Range("H30").Value = NumericUpDown7.Text 'Cantidad del Material
        xlibro.Range("I30").Value = TextBox28.Text ' Precio del Material
        xlibro.Range("M30").Value = TextBox47.Text 'Costo de Defontana
        xlibro.Range("N30").Value = TextBox27.Text 'Margen (%)
        xlibro.Range("J30").Value = TextBox58.Text 'Total
        xlibro.Range("O30").Value = TextBox128.Text 'Para costo de Reposicion articulos de GSI

        '8 Linea de Materiles
        xlibro.Range("D31").Value = TextBox29.Text 'Descripcion de Materiales
        xlibro.Range("C31").Value = TextBox30.Text 'Codigo del Material
        xlibro.Range("H31").Value = NumericUpDown8.Text 'Cantidad del Material
        xlibro.Range("I31").Value = TextBox32.Text ' Precio del Material
        xlibro.Range("M31").Value = TextBox48.Text 'Costo de Defontana
        xlibro.Range("N31").Value = TextBox31.Text 'Margen (%)
        xlibro.Range("J31").Value = TextBox59.Text 'Total
        xlibro.Range("O31").Value = TextBox129.Text 'Para costo de Reposicion articulos de GSI

        '9 linea de Materiales
        xlibro.Range("D32").Value = TextBox33.Text 'Descripcion de Materiales
        xlibro.Range("C32").Value = TextBox34.Text 'Codigo del Material
        xlibro.Range("H32").Value = NumericUpDown9.Text 'Cantidad del Material
        xlibro.Range("I32").Value = TextBox36.Text ' Precio del Material
        xlibro.Range("M32").Value = TextBox49.Text 'Costo de Defontana
        xlibro.Range("N32").Value = TextBox35.Text 'Margen (%)
        xlibro.Range("J32").Value = TextBox60.Text 'Total
        xlibro.Range("O32").Value = TextBox130.Text 'Para costo de Reposicion articulos de GSI

        ' 10 Linea de Materiales 
        xlibro.Range("D33").Value = TextBox37.Text 'Descripcion de Materiales
        xlibro.Range("C33").Value = TextBox38.Text 'Codigo del Material
        xlibro.Range("H33").Value = NumericUpDown10.Text 'Cantidad del Material
        xlibro.Range("I33").Value = TextBox40.Text ' Precio del Material
        xlibro.Range("M33").Value = TextBox50.Text 'Costo de Defontana
        xlibro.Range("N33").Value = TextBox39.Text 'Margen (%)
        xlibro.Range("J33").Value = TextBox61.Text 'Total
        xlibro.Range("O33").Value = TextBox131.Text 'Para costo de Reposicion articulos de GSI

        ' 11 Linea de Materiales 
        xlibro.Range("D34").Value = TextBox62.Text 'Descripcion de Materiales
        xlibro.Range("C34").Value = TextBox63.Text 'Codigo del Material
        xlibro.Range("H34").Value = NumericUpDown11.Text 'Cantidad del Material
        xlibro.Range("I34").Value = TextBox65.Text ' Precio del Material
        xlibro.Range("M34").Value = TextBox102.Text 'Costo de Defontana
        xlibro.Range("N34").Value = TextBox64.Text 'Margen (%)
        xlibro.Range("J34").Value = TextBox112.Text 'Total
        xlibro.Range("O34").Value = TextBox132.Text 'Para costo de Reposicion articulos de GSI

        ' 12 Linea de Materiales 
        xlibro.Range("D35").Value = TextBox66.Text 'Descripcion de Materiales
        xlibro.Range("C35").Value = TextBox67.Text 'Codigo del Material
        xlibro.Range("H35").Value = NumericUpDown12.Text 'Cantidad del Material
        xlibro.Range("I35").Value = TextBox69.Text ' Precio del Material
        xlibro.Range("M35").Value = TextBox103.Text 'Costo de Defontana
        xlibro.Range("N35").Value = TextBox68.Text 'Margen (%)
        xlibro.Range("J35").Value = TextBox113.Text 'Total
        xlibro.Range("O35").Value = TextBox133.Text 'Para costo de Reposicion articulos de GSI

        ' 13 Linea de Materiales 
        xlibro.Range("D36").Value = TextBox70.Text 'Descripcion de Materiales
        xlibro.Range("C36").Value = TextBox71.Text 'Codigo del Material
        xlibro.Range("H36").Value = NumericUpDown13.Text 'Cantidad del Material
        xlibro.Range("I36").Value = TextBox73.Text ' Precio del Material
        xlibro.Range("M36").Value = TextBox104.Text 'Costo de Defontana
        xlibro.Range("N36").Value = TextBox72.Text 'Margen (%)
        xlibro.Range("J36").Value = TextBox114.Text 'Total
        xlibro.Range("O36").Value = TextBox134.Text 'Para costo de Reposicion articulos de GSI

        ' 14 Linea de Materiales 
        xlibro.Range("D37").Value = TextBox74.Text 'Descripcion de Materiales
        xlibro.Range("C37").Value = TextBox75.Text 'Codigo del Material
        xlibro.Range("H37").Value = NumericUpDown14.Text 'Cantidad del Material
        xlibro.Range("I37").Value = TextBox77.Text ' Precio del Material
        xlibro.Range("M37").Value = TextBox105.Text 'Costo de Defontana
        xlibro.Range("N37").Value = TextBox76.Text 'Margen (%)
        xlibro.Range("J37").Value = TextBox115.Text 'Total
        xlibro.Range("O37").Value = TextBox135.Text 'Para costo de Reposicion articulos de GSI

        ' 15 Linea de Materiales 
        xlibro.Range("D38").Value = TextBox78.Text 'Descripcion de Materiales
        xlibro.Range("C38").Value = TextBox79.Text 'Codigo del Material
        xlibro.Range("H38").Value = NumericUpDown15.Text 'Cantidad del Material
        xlibro.Range("I38").Value = TextBox81.Text ' Precio del Material
        xlibro.Range("M38").Value = TextBox106.Text 'Costo de Defontana
        xlibro.Range("N38").Value = TextBox80.Text 'Margen (%)
        xlibro.Range("J38").Value = TextBox116.Text 'Total
        xlibro.Range("O38").Value = TextBox136.Text 'Para costo de Reposicion articulos de GSI

        ' 16 Linea de Materiales 
        xlibro.Range("D39").Value = TextBox82.Text 'Descripcion de Materiales
        xlibro.Range("C39").Value = TextBox82.Text 'Codigo del Material
        xlibro.Range("H39").Value = NumericUpDown16.Text 'Cantidad del Material
        xlibro.Range("I39").Value = TextBox85.Text ' Precio del Material
        xlibro.Range("M39").Value = TextBox107.Text 'Costo de Defontana
        xlibro.Range("N39").Value = TextBox84.Text 'Margen (%)
        xlibro.Range("J39").Value = TextBox117.Text 'Total
        xlibro.Range("O39").Value = TextBox137.Text 'Para costo de Reposicion articulos de GSI

        ' 17 Linea de Materiales 
        xlibro.Range("D40").Value = TextBox86.Text 'Descripcion de Materiales
        xlibro.Range("C40").Value = TextBox87.Text 'Codigo del Material
        xlibro.Range("H40").Value = NumericUpDown17.Text 'Cantidad del Material
        xlibro.Range("I40").Value = TextBox89.Text ' Precio del Material
        xlibro.Range("M40").Value = TextBox108.Text 'Costo de Defontana
        xlibro.Range("N40").Value = TextBox88.Text 'Margen (%)
        xlibro.Range("J40").Value = TextBox118.Text 'Total
        xlibro.Range("O40").Value = TextBox138.Text 'Para costo de Reposicion articulos de GSI

        ' 18 Linea de Materiales 
        xlibro.Range("D41").Value = TextBox90.Text 'Descripcion de Materiales
        xlibro.Range("C41").Value = TextBox91.Text 'Codigo del Material
        xlibro.Range("H41").Value = NumericUpDown18.Text 'Cantidad del Material
        xlibro.Range("I41").Value = TextBox93.Text ' Precio del Material
        xlibro.Range("M41").Value = TextBox109.Text 'Costo de Defontana
        xlibro.Range("N41").Value = TextBox92.Text 'Margen (%)
        xlibro.Range("J41").Value = TextBox119.Text 'Total
        xlibro.Range("O41").Value = TextBox139.Text 'Para costo de Reposicion articulos de GSI

        ' 19 Linea de Materiales 
        xlibro.Range("D42").Value = TextBox94.Text 'Descripcion de Materiales
        xlibro.Range("C42").Value = TextBox95.Text 'Codigo del Material
        xlibro.Range("H42").Value = NumericUpDown19.Text 'Cantidad del Material
        xlibro.Range("I42").Value = TextBox97.Text ' Precio del Material
        xlibro.Range("M42").Value = TextBox110.Text 'Costo de Defontana
        xlibro.Range("N42").Value = TextBox96.Text 'Margen (%)
        xlibro.Range("J42").Value = TextBox120.Text 'Total
        xlibro.Range("O42").Value = TextBox140.Text 'Para costo de Reposicion articulos de GSI

        ' 20 Linea de Materiales 
        xlibro.Range("D43").Value = TextBox98.Text 'Descripcion de Materiales
        xlibro.Range("C43").Value = TextBox99.Text 'Codigo del Material
        xlibro.Range("H43").Value = NumericUpDown20.Text 'Cantidad del Material
        xlibro.Range("I43").Value = TextBox101.Text ' Precio del Material
        xlibro.Range("M43").Value = TextBox111.Text 'Costo de Defontana
        xlibro.Range("N43").Value = TextBox100.Text 'Margen (%)
        xlibro.Range("J43").Value = TextBox121.Text 'Total
        xlibro.Range("O43").Value = TextBox141.Text 'Para costo de Reposicion articulos de GSI

        xlibro.Range("D47").Value = CboLugar.Text
        xlibro.Range("D48").Value = TxtPlazo.Text
        xlibro.Range("D49").Value = Cbopago.Text
        xlibro.Range("D50").Value = CboValidez.Text
    End Sub

    Private Sub CheckBox23_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox23.CheckedChanged
        If CheckBox23.Checked = True Then
            BtnExportarMarioDesT.Visible = True
            CheckBox22.Checked = False
        Else CheckBox23.Checked = False
            BtnExportarMarioDesT.Visible = False
        End If
    End Sub

    Private Sub TxtRazon_TextChanged(sender As Object, e As EventArgs) Handles TxtRazon.TextChanged

    End Sub

    Private Sub BtnExportarMarioDesT_KeyDown(sender As Object, e As KeyEventArgs) Handles BtnExportarMarioDesT.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim Razon As String = TxtRazon.Text.ToString
            Dim sqlcliente As String = " Select * From  Clientes where Razon_Social Like '%" & Razon & "%' "

            Cargar_MySQLCliente(sqlcliente, DGRazonSocial)
        End If
    End Sub

    Private Sub TxtRazon_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtRazon.KeyUp
        If e.KeyCode = Keys.Enter Then
            Dim Razon As String = TxtRazon.Text.ToString
            Dim sqlcliente As String = " Select * From  Clientes where Razon_Social Like '%" & Razon & "%' "

            Cargar_MySQLCliente(sqlcliente, DGRazonSocial)
        End If
    End Sub

    Private Sub DGVatencion_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DGVatencion.CellContentClick
        Dim fila As Integer
        fila = DGVatencion.CurrentRow.Index
        TxtAtencion.Text = Me.DGVatencion.Item(3, fila).Value
        TxtDireccion.Text = Me.DGVatencion.Item(4, fila).Value
        TxtphoneC.Text = Me.DGVatencion.Item(5, fila).Value
        TxtCorreoC.Text = Me.DGVatencion.Item(6, fila).Value
    End Sub

#End Region
End Class