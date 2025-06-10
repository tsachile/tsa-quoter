Imports System.Reflection.Emit
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form20
    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.Text = Format(CType(Me.TextBox1.Text, Decimal), "$ #,#0.00")
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        TextBox2.Text = Format(CType(Me.TextBox2.Text, Decimal), "$ #,#0.00")
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        TextBox3.Text = Format(CType(Me.TextBox3.Text, Decimal), "$ #,#0.00")
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        TextBox4.Text = Format(CType(Me.TextBox4.Text, Decimal), "$ #,#0.00")
    End Sub

    Private Sub Form20_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ANALISIS GENERAL
        Label30.Text = Label12.Text
        Label32.Text = Label20.Text
        Label35.Text = Label28.Text

        TextBox5.Text = Label30.Text
        TextBox6.Text = Label32.Text
        TextBox7.Text = Label35.Text

        Label37.Text = Val(Label30.Text) + Val(Label32.Text) + Val(Label35.Text)
        TextBox4.Text = Label37.Text

        'PARA CALCULOS PORCENTUALES
        Dim totalA As Double = 0
        totalA = (Val(Label30.Text) / Val(Label37.Text))
        Dim totalB As Double = 0
        totalB = (Val(Label32.Text) / Val(Label37.Text))
        Dim totalC As Double = 0
        totalC = (Val(Label35.Text) / Val(Label37.Text))

        Label38.Text = Format(totalA, "0.00%")
        Label39.Text = Format(totalB, "0.00%")
        Label40.Text = Format(totalC, "0.00%")

        Chart4.Series.Clear()
        Chart4.Series.Add("TENDENCIAS")

        Chart4.Series("TENDENCIAS").ChartType = SeriesChartType.Pie
        Chart4.Series("TENDENCIAS").Points.AddXY((Label31.Text & " " & Label38.Text), Val(Label30.Text))
        Chart4.Series("TENDENCIAS").Points.AddXY((Label33.Text & " " & Label39.Text), Val(Label32.Text))
        Chart4.Series("TENDENCIAS").Points.AddXY((Label34.Text & " " & Label40.Text), Val(Label35.Text))

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        TextBox5.Text = Format(CType(Me.TextBox5.Text, Decimal), "$ #,#0.00")
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        TextBox6.Text = Format(CType(Me.TextBox6.Text, Decimal), "$ #,#0.00")

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        TextBox7.Text = Format(CType(Me.TextBox7.Text, Decimal), "$ #,#0.00")

    End Sub
End Class