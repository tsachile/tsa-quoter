Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class Form3
     Private Sub BtnCerrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnCerrar.Click
        Me.Close()

    End Sub
#Region "Drag Form - Arrastrar/ mover Formulario"

    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub

    Private Sub Panel3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel3.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
    Private Sub Form3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
#End Region
    Private Sub DataGridDefontana_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridDefontana.CellContentClick
        On Error Resume Next
        Dim fila As Integer = DataGridDefontana.CurrentRow.Index

        ' Obtener valores de las celdas en la fila seleccionada
        Txtdescripcion.Text = Me.DataGridDefontana.Item(1, fila).Value
        TextBox3.Text = Me.DataGridDefontana.Item(10, fila).Value ' Costo de GSI
        Txtmph.Text = Me.DataGridDefontana.Item(4, fila).Value
        Txtcvh.Text = Me.DataGridDefontana.Item(5, fila).Value
        Txtrvh.Text = Me.DataGridDefontana.Item(6, fila).Value
        Txtfuv.Text = Me.DataGridDefontana.Item(7, fila).Value
        Txtpmv.Text = Me.DataGridDefontana.Item(8, fila).Value
        Txtcv.Text = Me.DataGridDefontana.Item(9, fila).Value
        TxtCostoDefontana.Text = Me.DataGridDefontana.Item(3, fila).Value
        txtstock.Text = Me.DataGridDefontana.Item(2, fila).Value

        'Dim precioreposicion As String = Val(TextBox3.Text)
        Dim precioreposicion As String = Me.DataGridDefontana.Item(10, fila).Value
        TxtReposicion.Text = precioreposicion

        TxtReposicionOK.Text = TxtCostoDefontana.Text
        TxtCodigoOK.Text = Me.DataGridDefontana.Item(0, fila).Value
        TxtDescripcionOK.Text = Txtdescripcion.Text
        TextBox1.Text = Me.DataGridDefontana.Item(10, fila).Value
        'TextBox1.Text = TxtReposicion.Text

        ' Cargar datos por cliente
        Dim porcliente As String = Me.TxtrazonEspejo.Text.ToString
        Dim pordescripcion As String = Me.Txtdescripcion.Text.ToString

        Dim sql As String = "Select * From DATAPORCLIENTE Where cliente ='" & porcliente & "' and descripcion='" & pordescripcion & "'"

        Cargar_MySQL(sql, DataGridView1)

        DataGridView1.Columns(7).DefaultCellStyle.Format = "CLP #,##0.00"
        DataGridView1.Columns(8).DefaultCellStyle.Format = "CLP #,##0.00"
        DataGridView1.Columns(3).DefaultCellStyle.Format = "0%"

        DataGridView1.Visible = True

        ' Cargar código cliente
        Dim RAZON As String = TxtrazonEspejo.Text.ToString()
        Dim DESCRIPCION As String = Txtdescripcion.Text.ToString()

        Dim sqlcodcliente As String = "Select * FROM DATACODCLIENTE Where RAZON= '" & RAZON & "' and Descripcion = '" & DESCRIPCION & "'"

        Cargar_MySQL(sqlcodcliente, DataGridView2)

        '=============================================================================PARA BUSCAR EN DATA DE IMAGEN POR ID, CODIGO TSA===============================================================================================================
        Dim DESCRIP As String = TxtDescripcionOK.Text.ToString
        Dim CODTSA As String = TxtCodigoOK.Text.ToString

        Dim SQLXTREME As String = " SELECT * FROM TSADATAIMAGEN WHERE Descripcion_TSA = '" & DESCRIP & "' AND Codigo_TSA = '" & CODTSA & "' "

        Cargar_MySQL5(SQLXTREME, DGG2)

        If DGG2.Rows.Count > 0 AndAlso DGG2.CurrentRow IsNot Nothing Then
            TextBox11.Text = DGG2.CurrentRow.Cells("ID").Value.ToString()
            TextBox5.Text = DGG2.CurrentRow.Cells("Descripcion_TSA").Value.ToString()
            TextBox6.Text = DGG2.CurrentRow.Cells("Codigo_TSA").Value.ToString()
            TextBox7.Text = DGG2.CurrentRow.Cells("Descripcion_GSI").Value.ToString()
            TextBox8.Text = DGG2.CurrentRow.Cells("Codigo_GSI_OLD").Value.ToString()
            TextBox9.Text = DGG2.CurrentRow.Cells("Codigo_GSI_MEDIUM").Value.ToString()
            TextBox10.Text = DGG2.CurrentRow.Cells("Codigo_GSI").Value.ToString()
            PtbImagen.Image = Image.FromStream(New MemoryStream(CType(DGG2.CurrentRow.Cells("IMAGEN").Value, Byte())))
        Else
            LimpiarCampos()
        End If

        'CONDICION PARA SEGUN SE APLIQUE LA MONEDA EN SU DEFECTO CLP, USD, EUR
        ' Variables para los valores ingresados por el usuario
        Dim tasaCambio As Double
        Dim costoReposicion As Double
        Dim cantidadReposicion As Double
        Dim valorTextBox13 As Double
        Dim valorTextBox1 As Double
        Dim valorTxtReposicionOK As Double
        Dim valorTXTUSDEUR As Double

        ' Verificar si TextBox13.Text o TxtUSDEUR.Text es un número válido
        If Not Double.TryParse(TextBox13.Text, valorTextBox13) AndAlso Not Double.TryParse(TxtUSDEUR.Text, valorTXTUSDEUR) Then
            MessageBox.Show("Por favor, ingrese un valor numérico válido en Tasa de Cambio o Valor TXTUSDEUR.")
            Exit Sub
        End If

        ' Verificar si TextBox1.Text es un número válido
        If Not Double.TryParse(TextBox1.Text, valorTextBox1) Then
            MessageBox.Show("Por favor, ingrese un valor numérico válido en Costo de Reposicion.")
            Exit Sub
        End If

        ' Verificar si TxtReposicionOK.Text es un número válido
        If Not Double.TryParse(TxtReposicionOK.Text, valorTxtReposicionOK) Then
            MessageBox.Show("Por favor, ingrese un valor numérico válido en Cantidad de Reposicion.")
            Exit Sub
        End If

        ' Realizar cálculos según la moneda seleccionada
        Select Case ComboBox1.Text.ToUpper()
            Case "CLP"
                ' Realizar el cálculo para CLP
                If valorTextBox13 <> 0 Then
                    TextBox12.Text = (valorTextBox13 * valorTextBox1).ToString()
                ElseIf valorTXTUSDEUR <> 0 Then
                    TextBox12.Text = (valorTextBox1 * valorTXTUSDEUR).ToString()
                End If
            Case "USD", "EUR"
                ' Realizar el cálculo para USD o EUR
                If valorTextBox13 <> 0 Then
                    TextBox12.Text = (valorTxtReposicionOK / valorTextBox13).ToString()
                ElseIf valorTXTUSDEUR <> 0 Then
                    TextBox12.Text = (valorTxtReposicionOK / valorTXTUSDEUR).ToString()
                End If
        End Select
        Select Case TextBox14.Text.ToUpper()
            Case "CLP"
                ' Realizar el cálculo para CLP
                If valorTextBox13 <> 0 Then
                    TextBox12.Text = (valorTextBox13 * valorTextBox1).ToString()
                ElseIf valorTXTUSDEUR <> 0 Then
                    TextBox12.Text = (valorTextBox1 * valorTXTUSDEUR).ToString()
                End If
            Case "USD", "EUR"
                ' Realizar el cálculo para USD o EUR
                If valorTextBox13 <> 0 Then
                    TextBox12.Text = (valorTxtReposicionOK / valorTextBox13).ToString()
                ElseIf valorTXTUSDEUR <> 0 Then
                    TextBox12.Text = (valorTxtReposicionOK / valorTXTUSDEUR).ToString()
                End If
        End Select
    End Sub
    'PARA LIMPIAR SI NO HAY NADA RELACIONADO CON EL PRODUCTO
    Private Sub LimpiarCampos()
        TextBox11.Text = String.Empty
        TextBox5.Text = String.Empty
        TextBox6.Text = String.Empty
        TextBox7.Text = String.Empty
        TextBox8.Text = String.Empty
        TextBox9.Text = String.Empty
        TextBox10.Text = String.Empty
        PtbImagen.Image = Nothing
    End Sub


    Private Sub DataGridAgromarau_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridAgromarau.CellContentClick
        On Error Resume Next
        Dim fila As Integer
        fila = DataGridAgromarau.CurrentRow.Index
        Txtdescripcion.Text = Me.DataGridAgromarau.Item(3, fila).Value
        TextBox3.Text = Me.DataGridAgromarau.Item(4, fila).Value

        Dim precio As String
        precio = Me.DataGridAgromarau.Item(4, fila).Value
        TxtReposicion.Text = precio

        'TxtReposicion.Text = Format(Val(TxtReposicion.Text), "#.#0,0")

        TxtReposicionOK.Text = TxtReposicion.Text

        TxtCodigoOK.Text = Me.DataGridAgromarau.Item(2, fila).Value
        TxtDescripcionOK.Text = Txtdescripcion.Text

        ' Variables para los valores ingresados por el usuario
        Dim valorTextBox13 As Double
        Dim valorTextBox3 As Double
        Dim valorTxtReposicionOK As Double
        Dim valorTXTUSDEUR As Double

        ' Verificar si TextBox13.Text o TxtUSDEUR.Text es un número válido
        If Not Double.TryParse(TextBox13.Text, valorTextBox13) AndAlso Not Double.TryParse(TxtUSDEUR.Text, valorTXTUSDEUR) Then
            MessageBox.Show("Por favor, ingrese un valor numérico válido en Tasa de Cambio o Valor TXTUSDEUR.")
            Exit Sub
        End If

        ' Verificar si TextBox1.Text es un número válido
        If Not Double.TryParse(TextBox3.Text, valorTextBox3) Then
            MessageBox.Show("Por favor, ingrese un valor numérico válido en Costo de Reposición.")
            Exit Sub
        End If

        ' Realizar cálculos según la moneda seleccionada
        Dim resultado As Double

        Select Case ComboBox1.Text.ToUpper()
            Case "CLP"
                ' Realizar el cálculo para CLP
                If valorTextBox13 <> 0 Then
                    resultado = valorTextBox13 * valorTextBox3
                ElseIf valorTXTUSDEUR <> 0 Then
                    resultado = valorTextBox3 * valorTXTUSDEUR
                End If
        End Select

        ' Mostrar el resultado si es diferente de cero
        If resultado <> 0 Then
            TextBox12.Text = resultado.ToString()
        Else
            MessageBox.Show("No se ha podido realizar el cálculo para la moneda seleccionada.")
        End If

    End Sub
    Private Sub Txtmph_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Txtmph.TextChanged
        Me.Txtmph.Text = Format(Txtmph.Text, "Percent")
    End Sub

    Private Sub Txtcv_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Txtcv.TextChanged
        Me.Txtcv.Text = Format(Txtcv.Text, "Percent")
    End Sub

#Region "Para eventos de compratir entre formulario hijo a formulario padre "
    Private Sub Ok1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Ok1.Click
        Dim frm As Form2 = CType(Owner, Form2)
        frm.TextBox1.Text = TxtDescripcionOK.Text.ToString()
        frm.TextBox2.Text = TxtCodigoOK.Text.ToString()
        frm.TextBox41.Text = TxtReposicionOK.Text.ToString()
        frm.TextBox122.Text = TextBox1.Text.ToString()
        frm.TextBox164.Text = LabelOK.Text
        frm.TextBox164.Visible = True

        On Error Resume Next
        Dim xtra As Integer
        xtra = DataGridView2.CurrentRow.Index
        TextBox4.Text = Me.DataGridView2.Item(2, xtra).Value

        frm.TextBox142.Text = TextBox4.Text.ToString()
        Me.Hide()
    End Sub

    Private Sub Ok2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Ok2.Click
        Dim frm As Form2 = CType(Owner, Form2)
        frm.TextBox5.Text = TxtDescripcionOK.Text.ToString()
        frm.TextBox6.Text = TxtCodigoOK.Text.ToString()
        frm.TextBox42.Text = TxtReposicionOK.Text.ToString()
        frm.TextBox123.Text = TextBox1.Text.ToString()
        frm.TextBox165.Text = LabelOK.Text
        frm.TextBox165.Visible = True

        On Error Resume Next
        Dim xtra As Integer
        xtra = DataGridView2.CurrentRow.Index
        TextBox4.Text = Me.DataGridView2.Item(2, xtra).Value

        frm.TextBox143.Text = TextBox4.Text.ToString()

        Me.Hide()
    End Sub

    Private Sub Ok3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Ok3.Click
        Dim frm As Form2 = CType(Owner, Form2)
        frm.TextBox9.Text = TxtDescripcionOK.Text.ToString()
        frm.TextBox10.Text = TxtCodigoOK.Text.ToString()
        frm.TextBox43.Text = TxtReposicionOK.Text.ToString()
        frm.TextBox124.Text = TextBox1.Text.ToString()
        frm.TextBox166.Text = LabelOK.Text
        frm.TextBox166.Visible = True

        On Error Resume Next
        Dim xtra As Integer
        xtra = DataGridView2.CurrentRow.Index
        TextBox4.Text = Me.DataGridView2.Item(2, xtra).Value

        frm.TextBox144.Text = TextBox4.Text.ToString()

        Me.Hide()
    End Sub

    Private Sub Ok4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Ok4.Click
        Dim frm As Form2 = CType(Owner, Form2)
        frm.TextBox13.Text = TxtDescripcionOK.Text.ToString()
        frm.TextBox14.Text = TxtCodigoOK.Text.ToString()
        frm.TextBox44.Text = TxtReposicionOK.Text.ToString()
        frm.TextBox125.Text = TextBox1.Text.ToString()
        frm.TextBox167.Text = LabelOK.Text
        frm.TextBox167.Visible = True


        On Error Resume Next
        Dim xtra As Integer
        xtra = DataGridView2.CurrentRow.Index
        TextBox4.Text = Me.DataGridView2.Item(2, xtra).Value

        frm.TextBox145.Text = TextBox4.Text.ToString()
        Me.Hide()
    End Sub

    Private Sub Ok5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Ok5.Click
        Dim frm As Form2 = CType(Owner, Form2)
        frm.TextBox17.Text = TxtDescripcionOK.Text.ToString()
        frm.TextBox18.Text = TxtCodigoOK.Text.ToString()
        frm.TextBox45.Text = TxtReposicionOK.Text.ToString()
        frm.TextBox126.Text = TextBox1.Text.ToString()
        frm.TextBox168.Text = LabelOK.Text
        frm.TextBox168.Visible = True

        On Error Resume Next
        Dim xtra As Integer
        xtra = DataGridView2.CurrentRow.Index
        TextBox4.Text = Me.DataGridView2.Item(2, xtra).Value

        frm.TextBox146.Text = TextBox4.Text.ToString()
        Me.Hide()
    End Sub

    Private Sub Ok6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Ok6.Click
        Dim frm As Form2 = CType(Owner, Form2)
        frm.TextBox21.Text = TxtDescripcionOK.Text.ToString()
        frm.TextBox22.Text = TxtCodigoOK.Text.ToString()
        frm.TextBox46.Text = TxtReposicionOK.Text.ToString()
        frm.TextBox127.Text = TextBox1.Text.ToString()
        frm.TextBox169.Text = LabelOK.Text
        frm.TextBox169.Visible = True


        On Error Resume Next
        Dim xtra As Integer
        xtra = DataGridView2.CurrentRow.Index
        TextBox4.Text = Me.DataGridView2.Item(2, xtra).Value

        frm.TextBox147.Text = TextBox4.Text.ToString()
        Me.Hide()
    End Sub

    Private Sub Ok7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Ok7.Click
        Dim frm As Form2 = CType(Owner, Form2)
        frm.TextBox25.Text = TxtDescripcionOK.Text.ToString()
        frm.TextBox26.Text = TxtCodigoOK.Text.ToString()
        frm.TextBox47.Text = TxtReposicionOK.Text.ToString()
        frm.TextBox128.Text = TextBox1.Text.ToString()
        frm.TextBox170.Text = LabelOK.Text
        frm.TextBox170.Visible = True


        On Error Resume Next
        Dim xtra As Integer
        xtra = DataGridView2.CurrentRow.Index
        TextBox4.Text = Me.DataGridView2.Item(2, xtra).Value

        frm.TextBox148.Text = TextBox4.Text.ToString()
        Me.Hide()
    End Sub

    Private Sub Ok8_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Ok8.Click
        Dim frm As Form2 = CType(Owner, Form2)
        frm.TextBox29.Text = TxtDescripcionOK.Text.ToString()
        frm.TextBox30.Text = TxtCodigoOK.Text.ToString()
        frm.TextBox48.Text = TxtReposicionOK.Text.ToString()
        frm.TextBox129.Text = TextBox1.Text.ToString()
        frm.TextBox171.Text = LabelOK.Text
        frm.TextBox171.Visible = True


        On Error Resume Next
        Dim xtra As Integer
        xtra = DataGridView2.CurrentRow.Index
        TextBox4.Text = Me.DataGridView2.Item(2, xtra).Value

        frm.TextBox149.Text = TextBox4.Text.ToString()
        Me.Hide()
    End Sub

    Private Sub Ok9_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Ok9.Click
        Dim frm As Form2 = CType(Owner, Form2)
        frm.TextBox33.Text = TxtDescripcionOK.Text.ToString()
        frm.TextBox34.Text = TxtCodigoOK.Text.ToString()
        frm.TextBox49.Text = TxtReposicionOK.Text.ToString()
        frm.TextBox130.Text = TextBox1.Text.ToString()
        frm.TextBox172.Text = LabelOK.Text
        frm.TextBox172.Visible = True

        On Error Resume Next
        Dim xtra As Integer
        xtra = DataGridView2.CurrentRow.Index
        TextBox4.Text = Me.DataGridView2.Item(2, xtra).Value

        frm.TextBox150.Text = TextBox4.Text.ToString()
        Me.Hide()
    End Sub

    Private Sub Ok10_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Ok10.Click
        Dim frm As Form2 = CType(Owner, Form2)
        frm.TextBox37.Text = TxtDescripcionOK.Text.ToString()
        frm.TextBox38.Text = TxtCodigoOK.Text.ToString()
        frm.TextBox50.Text = TxtReposicionOK.Text.ToString()
        frm.TextBox131.Text = TextBox1.Text.ToString()
        frm.TextBox173.Text = LabelOK.Text
        frm.TextBox173.Visible = True


        On Error Resume Next
        Dim xtra As Integer
        xtra = DataGridView2.CurrentRow.Index
        TextBox4.Text = Me.DataGridView2.Item(2, xtra).Value

        frm.TextBox151.Text = TextBox4.Text.ToString()
        Me.Hide()


    End Sub
    Private Sub Ok11_Click(sender As Object, e As EventArgs) Handles Ok11.Click
        Dim frm As Form2 = CType(Owner, Form2)
        frm.TextBox62.Text = TxtDescripcionOK.Text.ToString()
        frm.TextBox63.Text = TxtCodigoOK.Text.ToString()
        frm.TextBox102.Text = TxtReposicionOK.Text.ToString()
        frm.TextBox132.Text = TextBox1.Text.ToString()
        frm.TextBox174.Text = LabelOK.Text
        frm.TextBox174.Visible = True


        On Error Resume Next
        Dim xtra As Integer
        xtra = DataGridView2.CurrentRow.Index
        TextBox4.Text = Me.DataGridView2.Item(2, xtra).Value

        frm.TextBox152.Text = TextBox4.Text.ToString()
        Me.Hide()
    End Sub

    Private Sub Ok12_Click(sender As Object, e As EventArgs) Handles Ok12.Click
        Dim frm As Form2 = CType(Owner, Form2)
        frm.TextBox66.Text = TxtDescripcionOK.Text.ToString()
        frm.TextBox67.Text = TxtCodigoOK.Text.ToString()
        frm.TextBox103.Text = TxtReposicionOK.Text.ToString()
        frm.TextBox133.Text = TextBox1.Text.ToString()
        frm.TextBox175.Text = LabelOK.Text
        frm.TextBox175.Visible = True


        On Error Resume Next
        Dim xtra As Integer
        xtra = DataGridView2.CurrentRow.Index
        TextBox4.Text = Me.DataGridView2.Item(2, xtra).Value

        frm.TextBox153.Text = TextBox4.Text.ToString()
        Me.Hide()
    End Sub

    Private Sub Ok13_Click(sender As Object, e As EventArgs) Handles Ok13.Click
        Dim frm As Form2 = CType(Owner, Form2)
        frm.TextBox70.Text = TxtDescripcionOK.Text.ToString()
        frm.TextBox71.Text = TxtCodigoOK.Text.ToString()
        frm.TextBox104.Text = TxtReposicionOK.Text.ToString()
        frm.TextBox134.Text = TextBox1.Text.ToString()
        frm.TextBox176.Text = LabelOK.Text
        frm.TextBox176.Visible = True


        On Error Resume Next
        Dim xtra As Integer
        xtra = DataGridView2.CurrentRow.Index
        TextBox4.Text = Me.DataGridView2.Item(2, xtra).Value

        frm.TextBox154.Text = TextBox4.Text.ToString()
        Me.Hide()
    End Sub

    Private Sub Ok14_Click(sender As Object, e As EventArgs) Handles Ok14.Click
        Dim frm As Form2 = CType(Owner, Form2)
        frm.TextBox74.Text = TxtDescripcionOK.Text.ToString()
        frm.TextBox75.Text = TxtCodigoOK.Text.ToString()
        frm.TextBox105.Text = TxtReposicionOK.Text.ToString()
        frm.TextBox135.Text = TextBox1.Text.ToString()
        frm.TextBox177.Text = LabelOK.Text
        frm.TextBox177.Visible = True


        On Error Resume Next
        Dim xtra As Integer
        xtra = DataGridView2.CurrentRow.Index
        TextBox4.Text = Me.DataGridView2.Item(2, xtra).Value

        frm.TextBox155.Text = TextBox4.Text.ToString()
        Me.Hide()
    End Sub

    Private Sub Ok15_Click(sender As Object, e As EventArgs) Handles Ok15.Click
        Dim frm As Form2 = CType(Owner, Form2)
        frm.TextBox78.Text = TxtDescripcionOK.Text.ToString()
        frm.TextBox79.Text = TxtCodigoOK.Text.ToString()
        frm.TextBox106.Text = TxtReposicionOK.Text.ToString()
        frm.TextBox136.Text = TextBox1.Text.ToString()
        frm.TextBox178.Text = LabelOK.Text
        frm.TextBox178.Visible = True


        On Error Resume Next
        Dim xtra As Integer
        xtra = DataGridView2.CurrentRow.Index
        TextBox4.Text = Me.DataGridView2.Item(2, xtra).Value

        frm.TextBox156.Text = TextBox4.Text.ToString()
        Me.Hide()
    End Sub

    Private Sub Ok16_Click(sender As Object, e As EventArgs) Handles Ok16.Click
        Dim frm As Form2 = CType(Owner, Form2)
        frm.TextBox82.Text = TxtDescripcionOK.Text.ToString()
        frm.TextBox83.Text = TxtCodigoOK.Text.ToString()
        frm.TextBox107.Text = TxtReposicionOK.Text.ToString()
        frm.TextBox137.Text = TextBox1.Text.ToString()
        frm.TextBox179.Text = LabelOK.Text
        frm.TextBox179.Visible = True


        On Error Resume Next
        Dim xtra As Integer
        xtra = DataGridView2.CurrentRow.Index
        TextBox4.Text = Me.DataGridView2.Item(2, xtra).Value

        frm.TextBox157.Text = TextBox4.Text.ToString()
        Me.Hide()
    End Sub

    Private Sub Ok17_Click(sender As Object, e As EventArgs) Handles Ok17.Click
        Dim frm As Form2 = CType(Owner, Form2)
        frm.TextBox86.Text = TxtDescripcionOK.Text.ToString()
        frm.TextBox87.Text = TxtCodigoOK.Text.ToString()
        frm.TextBox108.Text = TxtReposicionOK.Text.ToString()
        frm.TextBox138.Text = TextBox1.Text.ToString()
        frm.TextBox180.Text = LabelOK.Text
        frm.TextBox180.Visible = True


        On Error Resume Next
        Dim xtra As Integer
        xtra = DataGridView2.CurrentRow.Index
        TextBox4.Text = Me.DataGridView2.Item(2, xtra).Value

        frm.TextBox158.Text = TextBox4.Text.ToString()
        Me.Hide()
    End Sub

    Private Sub Ok18_Click(sender As Object, e As EventArgs) Handles Ok18.Click
        Dim frm As Form2 = CType(Owner, Form2)
        frm.TextBox90.Text = TxtDescripcionOK.Text.ToString()
        frm.TextBox91.Text = TxtCodigoOK.Text.ToString()
        frm.TextBox109.Text = TxtReposicionOK.Text.ToString()
        frm.TextBox139.Text = TextBox1.Text.ToString()
        frm.TextBox181.Text = LabelOK.Text
        frm.TextBox181.Visible = True


        On Error Resume Next
        Dim xtra As Integer
        xtra = DataGridView2.CurrentRow.Index
        TextBox4.Text = Me.DataGridView2.Item(2, xtra).Value

        frm.TextBox159.Text = TextBox4.Text.ToString()
        Me.Hide()
    End Sub

    Private Sub Ok19_Click(sender As Object, e As EventArgs) Handles Ok19.Click
        Dim frm As Form2 = CType(Owner, Form2)
        frm.TextBox94.Text = TxtDescripcionOK.Text.ToString()
        frm.TextBox95.Text = TxtCodigoOK.Text.ToString()
        frm.TextBox110.Text = TxtReposicionOK.Text.ToString()
        frm.TextBox140.Text = TextBox1.Text.ToString()
        frm.TextBox182.Text = LabelOK.Text
        frm.TextBox182.Visible = True


        On Error Resume Next
        Dim xtra As Integer
        xtra = DataGridView2.CurrentRow.Index
        TextBox4.Text = Me.DataGridView2.Item(2, xtra).Value

        frm.TextBox160.Text = TextBox4.Text.ToString()
        Me.Hide()
    End Sub

    Private Sub ok20_Click(sender As Object, e As EventArgs) Handles ok20.Click
        Dim frm As Form2 = CType(Owner, Form2)
        frm.TextBox98.Text = TxtDescripcionOK.Text.ToString()
        frm.TextBox99.Text = TxtCodigoOK.Text.ToString()
        frm.TextBox111.Text = TxtReposicionOK.Text.ToString()
        frm.TextBox141.Text = TextBox1.Text.ToString()
        frm.TextBox183.Text = LabelOK.Text
        frm.TextBox183.Visible = True


        On Error Resume Next
        Dim xtra As Integer
        xtra = DataGridView2.CurrentRow.Index
        TextBox4.Text = Me.DataGridView2.Item(2, xtra).Value

        frm.TextBox161.Text = TextBox4.Text.ToString()
        Me.Hide()
    End Sub

#End Region
    Private Sub TxtReposicion_TextChanged(sender As Object, e As EventArgs) Handles TxtReposicion.TextChanged

    End Sub
#Region "Para cambio de Costo Unitario , Precio de Reposicion de GSI , Precio Rotecna y Precio Mario"
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            TxtReposicionOK.Text = TxtCostoDefontana.Text
            Label3.Text = "CLP"
            Label3.Visible = True
            LabelOK.Text = Label3.Text
            Label5.Visible = True
            Label5.Text = LabelOK.Text
        End If
        VerificarPLDED()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            TxtReposicionOK.Text = TxtReposicion.Text
            Label4.Text = "USD"
            Label4.Visible = True
            LabelOK.Text = Label4.Text
            Label5.Visible = True
            Label5.Text = LabelOK.Text
        End If
        VerificarPLDED()
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked Then
            TxtReposicionOK.Text = TextBox12.Text
            Label18.Text = TextBox14.Text
            Label18.Visible = True
            LabelOK.Text = Label18.Text
            Label5.Visible = True
            Label5.Text = LabelOK.Text
        End If
        VerificarPLDED()
    End Sub

    Private Sub VerificarPLDED()
        If TxtCodigoOK.Text.StartsWith("PLDED") Then
            Label4.Text = "EUR"
            LabelOK.Text = Label4.Text
        End If
    End Sub

#End Region
#Region "Para nuevo evento de agregar en segumiento de cotizacion"
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim frm As Form10 = CType(Owner, Form10)
        frm.TextBox14.Text = TxtDescripcionOK.Text
        frm.TextBox15.Text = TxtCodigoOK.Text
        frm.TextBox17.Text = TxtReposicionOK.Text
        frm.TextBox143.Text = LabelOK.Text

        Me.Hide()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim frm As Form10 = CType(Owner, Form10)
        frm.TextBox19.Text = TxtDescripcionOK.Text
        frm.TextBox20.Text = TxtCodigoOK.Text
        frm.TextBox22.Text = TxtReposicionOK.Text
        frm.TextBox144.Text = LabelOK.Text
        Me.Hide()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim frm As Form10 = CType(Owner, Form10)
        frm.TextBox24.Text = TxtDescripcionOK.Text
        frm.TextBox25.Text = TxtCodigoOK.Text
        frm.TextBox27.Text = TxtReposicionOK.Text
        frm.TextBox145.Text = LabelOK.Text
        Me.Hide()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Dim frm As Form10 = CType(Owner, Form10)
        frm.TextBox29.Text = TxtDescripcionOK.Text
        frm.TextBox30.Text = TxtCodigoOK.Text
        frm.TextBox32.Text = TxtReposicionOK.Text
        frm.TextBox146.Text = LabelOK.Text
        Me.Hide()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Dim frm As Form10 = CType(Owner, Form10)
        frm.TextBox34.Text = TxtDescripcionOK.Text
        frm.TextBox35.Text = TxtCodigoOK.Text
        frm.TextBox37.Text = TxtReposicionOK.Text
        frm.TextBox147.Text = LabelOK.Text
        Me.Hide()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Dim frm As Form10 = CType(Owner, Form10)
        frm.TextBox39.Text = TxtDescripcionOK.Text
        frm.TextBox40.Text = TxtCodigoOK.Text
        frm.TextBox42.Text = TxtReposicionOK.Text
        frm.TextBox148.Text = LabelOK.Text
        Me.Hide()
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Dim frm As Form10 = CType(Owner, Form10)
        frm.TextBox44.Text = TxtDescripcionOK.Text
        frm.TextBox45.Text = TxtCodigoOK.Text
        frm.TextBox47.Text = TxtReposicionOK.Text
        frm.TextBox149.Text = LabelOK.Text
        Me.Hide()
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Dim frm As Form10 = CType(Owner, Form10)
        frm.TextBox49.Text = TxtDescripcionOK.Text
        frm.TextBox50.Text = TxtCodigoOK.Text
        frm.TextBox52.Text = TxtReposicionOK.Text
        frm.TextBox150.Text = LabelOK.Text
        Me.Hide()
    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        Dim frm As Form10 = CType(Owner, Form10)
        frm.TextBox54.Text = TxtDescripcionOK.Text
        frm.TextBox55.Text = TxtCodigoOK.Text
        frm.TextBox57.Text = TxtReposicionOK.Text
        frm.TextBox151.Text = LabelOK.Text
        Me.Hide()
    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click
        Dim frm As Form10 = CType(Owner, Form10)
        frm.TextBox59.Text = TxtDescripcionOK.Text
        frm.TextBox60.Text = TxtCodigoOK.Text
        frm.TextBox62.Text = TxtReposicionOK.Text
        frm.TextBox152.Text = LabelOK.Text
        Me.Hide()
    End Sub

    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click
        Dim frm As Form10 = CType(Owner, Form10)
        frm.TextBox64.Text = TxtDescripcionOK.Text
        frm.TextBox65.Text = TxtCodigoOK.Text
        frm.TextBox67.Text = TxtReposicionOK.Text
        frm.TextBox153.Text = LabelOK.Text
        Me.Hide()
    End Sub

    Private Sub PictureBox12_Click(sender As Object, e As EventArgs) Handles PictureBox12.Click
        Dim frm As Form10 = CType(Owner, Form10)
        frm.TextBox69.Text = TxtDescripcionOK.Text
        frm.TextBox70.Text = TxtCodigoOK.Text
        frm.TextBox72.Text = TxtReposicionOK.Text
        frm.TextBox154.Text = LabelOK.Text
        Me.Hide()
    End Sub

    Private Sub PictureBox13_Click(sender As Object, e As EventArgs) Handles PictureBox13.Click
        Dim frm As Form10 = CType(Owner, Form10)
        frm.TextBox74.Text = TxtDescripcionOK.Text
        frm.TextBox75.Text = TxtCodigoOK.Text
        frm.TextBox77.Text = TxtReposicionOK.Text
        frm.TextBox155.Text = LabelOK.Text
        Me.Hide()
    End Sub

    Private Sub PictureBox14_Click(sender As Object, e As EventArgs) Handles PictureBox14.Click
        Dim frm As Form10 = CType(Owner, Form10)
        frm.TextBox79.Text = TxtDescripcionOK.Text
        frm.TextBox80.Text = TxtCodigoOK.Text
        frm.TextBox82.Text = TxtReposicionOK.Text
        frm.TextBox156.Text = LabelOK.Text
        Me.Hide()
    End Sub

    Private Sub PictureBox15_Click(sender As Object, e As EventArgs) Handles PictureBox15.Click
        Dim frm As Form10 = CType(Owner, Form10)
        frm.TextBox84.Text = TxtDescripcionOK.Text
        frm.TextBox85.Text = TxtCodigoOK.Text
        frm.TextBox87.Text = TxtReposicionOK.Text
        frm.TextBox157.Text = LabelOK.Text
        Me.Hide()
    End Sub

    Private Sub PictureBox16_Click(sender As Object, e As EventArgs) Handles PictureBox16.Click
        Dim frm As Form10 = CType(Owner, Form10)
        frm.TextBox89.Text = TxtDescripcionOK.Text
        frm.TextBox90.Text = TxtCodigoOK.Text
        frm.TextBox92.Text = TxtReposicionOK.Text
        frm.TextBox158.Text = LabelOK.Text
        Me.Hide()
    End Sub

    Private Sub PictureBox17_Click(sender As Object, e As EventArgs) Handles PictureBox17.Click
        Dim frm As Form10 = CType(Owner, Form10)
        frm.TextBox94.Text = TxtDescripcionOK.Text
        frm.TextBox95.Text = TxtCodigoOK.Text
        frm.TextBox97.Text = TxtReposicionOK.Text
        frm.TextBox159.Text = LabelOK.Text
        Me.Hide()
    End Sub

    Private Sub PictureBox18_Click(sender As Object, e As EventArgs) Handles PictureBox18.Click
        Dim frm As Form10 = CType(Owner, Form10)
        frm.TextBox99.Text = TxtDescripcionOK.Text
        frm.TextBox100.Text = TxtCodigoOK.Text
        frm.TextBox102.Text = TxtReposicionOK.Text
        frm.TextBox160.Text = LabelOK.Text
        Me.Hide()

    End Sub

    Private Sub PictureBox19_Click(sender As Object, e As EventArgs) Handles PictureBox19.Click
        Dim frm As Form10 = CType(Owner, Form10)
        frm.TextBox104.Text = TxtDescripcionOK.Text
        frm.TextBox105.Text = TxtCodigoOK.Text
        frm.TextBox107.Text = TxtReposicionOK.Text
        frm.TextBox161.Text = LabelOK.Text
        Me.Hide()
    End Sub

    Private Sub PictureBox20_Click(sender As Object, e As EventArgs) Handles PictureBox20.Click
        Dim frm As Form10 = CType(Owner, Form10)
        frm.TextBox109.Text = TxtDescripcionOK.Text
        frm.TextBox110.Text = TxtCodigoOK.Text
        frm.TextBox112.Text = TxtReposicionOK.Text
        frm.TextBox162.Text = LabelOK.Text
        Me.Hide()
    End Sub

    Private Sub txtprecioconsulta_Click(sender As Object, e As EventArgs) Handles txtprecioconsulta.Click

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New Form18
        AddOwnedForm(frm)
        frm.txtrazon.Text = TxtrazonEspejo.Text
        frm.txtcodigo.Text = TxtCodigoOK.Text
        frm.ShowDialog()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Obtener la resolución de la pantalla
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height

        ' Escala basada en la resolución de diseño (por ejemplo, 1920x1080)
        Dim baseWidth As Integer = 1920
        Dim baseHeight As Integer = 1080

        Dim scaleFactorX As Double = screenWidth / baseWidth
        Dim scaleFactorY As Double = screenHeight / baseHeight

        ' Escalar el formulario
        Me.Width = CInt(Me.Width * scaleFactorX)
        Me.Height = CInt(Me.Height * scaleFactorY)

        ' Escalar cada control dentro del formulario
        For Each ctrl As Control In Me.Controls
            ctrl.Left = CInt(ctrl.Left * scaleFactorX)
            ctrl.Top = CInt(ctrl.Top * scaleFactorY)
            ctrl.Width = CInt(ctrl.Width * scaleFactorX)
            ctrl.Height = CInt(ctrl.Height * scaleFactorY)
        Next
        Txtdescripcion.Select()
        'Para Mayuscula ebn ciertos TEXTBOX
        'TextBox1.CharacterCasing = CharacterCasing.Upper
        Txtdescripcion.CharacterCasing = CharacterCasing.Upper
        TxtfiltroDefontana.CharacterCasing = CharacterCasing.Upper
        TxtfiltroAgromarau.CharacterCasing = CharacterCasing.Upper

    End Sub

    Private Sub txtmargenconsulta_TextChanged(sender As Object, e As EventArgs) Handles txtmargenconsulta.TextChanged
        On Error Resume Next
        If TxtReposicionOK.Text = "" Then
            ' txtmargenconsulta.Text = ""
        Else
            Dim precio As String
            precio = Val(TxtReposicionOK.Text) / Val((100 - txtmargenconsulta.Text) / 100)
            txtprecioconsulta.Text = precio

            Me.txtprecioconsulta.Text = Format(Val(txtprecioconsulta.Text), "#,##0.00")
        End If
    End Sub

#End Region
    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim frm As New Form22
        AddOwnedForm(frm)

        frm.ShowDialog()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Visibilidad basada en la selección de ComboBox6
        Select Case ComboBox1.Text
            Case "CLP", "USD", "EUR"
                Label36.Visible = True
                TxtUSDEUR.Visible = True
        End Select
    End Sub
#Region "Busqueda Interactiva"

    ' Declarar los Timers a nivel de clase
    Private WithEvents debounceTimer As New System.Windows.Forms.Timer()
    Private _timerDefontana As System.Windows.Forms.Timer
    Private _timerAgromarau As System.Windows.Forms.Timer

    ' Ajustar el tamaño de los DataGridView
    Private Sub AjustarTamanosGrids()
        ' Establecer el tamaño para DataGridDefontana y DataGridAgromarau
        DataGridDefontana.Size = New Size(1105, 140)
        DataGridAgromarau.Size = New Size(1105, 140)
    End Sub

    ' Manejar el evento TextChanged para Txtdescripcion con debounce
    Private Sub Txtdescripcion_TextChanged(sender As Object, e As EventArgs) Handles Txtdescripcion.TextChanged
        ' Reiniciar el Timer cada vez que se escribe
        debounceTimer.Stop()
        debounceTimer.Start()

        ' Verificar si Txtdescripcion está vacío y ocultar los DataGridView
        If String.IsNullOrWhiteSpace(Txtdescripcion.Text) Then
            DataGridDefontana.Visible = False
            DataGridAgromarau.Visible = False
            DataGridView3.Visible = False
        Else
            DataGridDefontana.Visible = True
            DataGridAgromarau.Visible = True
            DataGridView3.Visible = True
        End If
    End Sub

    ' Cuando el Timer expira, actualizar los DataGridView
    Private Sub debounceTimer_Tick(sender As Object, e As EventArgs) Handles debounceTimer.Tick
        debounceTimer.Stop() ' Detener el Timer para evitar ejecuciones repetidas
        ActualizarGrids()    ' Llamar a la función principal
    End Sub

    ' Función que actualiza los DataGridView
    Private Sub ActualizarGrids()
        ' Validar si el texto está vacío
        If String.IsNullOrWhiteSpace(Txtdescripcion.Text) Then
            DataGridDefontana.Visible = False
            DataGridAgromarau.Visible = False
            DataGridView3.Visible = False
            Return
        End If

        Dim Descripcion As String = Txtdescripcion.Text

        ' Ajustar el tamaño de los grids antes de realizar las actualizaciones
        AjustarTamanosGrids()

        ' Suspender la actualización visual para acelerar el proceso
        DataGridDefontana.SuspendLayout()
        DataGridAgromarau.SuspendLayout()
        DataGridView3.SuspendLayout()

        ' Consultas optimizadas (LIMIT 100 para mejorar el rendimiento)
        Dim sql2 As String = $"SELECT * FROM DATA WHERE Descripcion LIKE '%{Descripcion}%' LIMIT 100"
        Dim sql4 As String = $"SELECT * FROM GSI WHERE DESCRIPCION LIKE '%{Descripcion}%' LIMIT 100"
        Dim sqlcruces As String = $"SELECT * FROM TSADATACRUCES WHERE Descripcion LIKE '%{Descripcion}%' LIMIT 100"

        ' Cargar los datos en los DataGridView
        Cargar_MySQL2(sql2, DataGridDefontana)
        Cargar_MySQL4(sql4, DataGridAgromarau)
        Cargar_MySQL4(sqlcruces, DataGridView3)

        ' Ocultar las columnas que no deseas mostrar en DataGridDefontana
        For Each col As DataGridViewColumn In DataGridDefontana.Columns
            If col.Name <> "Codigo" AndAlso col.Name <> "Descripcion" AndAlso col.Name <> "Saldo" AndAlso col.Name <> "Costo Unitario" Then
                col.Visible = False
            Else
                col.Visible = True
            End If
        Next

        ' Mostrar u ocultar los DataGridView según si tienen filas
        DataGridDefontana.Visible = (DataGridDefontana.Rows.Count > 0)
        DataGridAgromarau.Visible = (DataGridAgromarau.Rows.Count > 0)
        DataGridView3.Visible = (DataGridView3.Rows.Count > 0)

        ' Reanudar la actualización visual
        DataGridDefontana.ResumeLayout()
        DataGridAgromarau.ResumeLayout()
        DataGridView3.ResumeLayout()
    End Sub

    ' Manejo de los eventos TextChanged para los filtros con debounce
    Private Sub TxtfiltroDefontana_TextChanged(sender As Object, e As EventArgs) Handles TxtfiltroDefontana.TextChanged
        If _timerDefontana Is Nothing Then
            _timerDefontana = New System.Windows.Forms.Timer()
            _timerDefontana.Interval = 500 ' Establece el retraso de 500ms
            AddHandler _timerDefontana.Tick, AddressOf TimerDefontana_Tick
        Else
            _timerDefontana.Stop() ' Detén el temporizador si está en ejecución
        End If
        _timerDefontana.Start() ' Inicia el temporizador

        ' Verificar si TxtfiltroDefontana está vacío y ocultar DataGridDefontana
        If String.IsNullOrWhiteSpace(TxtfiltroDefontana.Text) Then
            DataGridDefontana.Visible = False
        Else
            DataGridDefontana.Visible = True
        End If
    End Sub

    Private Sub TxtfiltroAgromarau_TextChanged(sender As Object, e As EventArgs) Handles TxtfiltroAgromarau.TextChanged
        If _timerAgromarau Is Nothing Then
            _timerAgromarau = New System.Windows.Forms.Timer()
            _timerAgromarau.Interval = 500 ' Establece el retraso de 500ms
            AddHandler _timerAgromarau.Tick, AddressOf TimerAgromarau_Tick
        Else
            _timerAgromarau.Stop() ' Detén el temporizador si está en ejecución
        End If
        _timerAgromarau.Start() ' Inicia el temporizador

        ' Verificar si TxtfiltroAgromarau está vacío y ocultar DataGridAgromarau
        If String.IsNullOrWhiteSpace(TxtfiltroAgromarau.Text) Then
            DataGridAgromarau.Visible = False
        Else
            DataGridAgromarau.Visible = True
        End If
    End Sub

    ' Manejadores de los eventos Tick para realizar las búsquedas
    Private Sub TimerDefontana_Tick(sender As Object, e As EventArgs)
        _timerDefontana.Stop() ' Detener el temporizador
        RealizarBusquedaDefontana(TxtfiltroDefontana.Text.Trim()) ' Realizar la búsqueda
    End Sub

    Private Sub TimerAgromarau_Tick(sender As Object, e As EventArgs)
        _timerAgromarau.Stop() ' Detener el temporizador
        RealizarBusquedaAgromarau(TxtfiltroAgromarau.Text.Trim()) ' Realizar la búsqueda
    End Sub

    ' Realizar búsqueda para Defontana
    Private Sub RealizarBusquedaDefontana(filtro As String)
        If String.IsNullOrWhiteSpace(filtro) Then Exit Sub ' Evita ejecutar la consulta si el filtro está vacío
        ' Construye la consulta SQL con concatenación
        Dim sql2 As String = "SELECT * FROM DATA WHERE Codigo LIKE '%" & filtro & "%' OR Descripcion LIKE '%" & filtro & "%'"
        ' Ocultar las columnas que no deseas mostrar en DataGridDefontana
        For Each col As DataGridViewColumn In DataGridDefontana.Columns
            If col.Name <> "Codigo" AndAlso col.Name <> "Descripcion" AndAlso col.Name <> "Saldo" AndAlso col.Name <> "Costo Unitario" Then
                col.Visible = False
            Else
                col.Visible = True
            End If
        Next


        ' Cargar los datos de manera asíncrona
        Cargar_MySQL2(sql2, DataGridDefontana)
    End Sub

    ' Realizar búsqueda para Agromarau
    Private Sub RealizarBusquedaAgromarau(filtro As String)
        If String.IsNullOrWhiteSpace(filtro) Then Exit Sub ' Evita ejecutar la consulta si el filtro está vacío
        ' Construye la consulta SQL con concatenación
        Dim sql2 As String = "SELECT * FROM GSI WHERE DESCRIPCION LIKE '%" & filtro & "%' OR Codigo_New LIKE '%" & filtro & "%'"

        ' Cargar los datos de manera asíncrona
        Cargar_MySQL4(sql2, DataGridAgromarau)
    End Sub



#End Region


End Class


