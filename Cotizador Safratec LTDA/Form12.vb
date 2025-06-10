
Public Class Form12
    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Para calculo de Luminarias a lo ancho del galpon 
        Dim ancho As String
        ancho = (Val(TextBox12.Text / TextBox2.Text) * Val(TextBox1.Text)) ^ 0.5
        TextBox14.Text = ancho
        Me.TextBox14.Text = Format(Val(CDec(TextBox14.Text)), "##,##0.00")
        'para calculo de luminarias a lo largo del galpon
        Dim largo As String
        largo = Val(TextBox14.Text * TextBox2.Text) / Val(TextBox1.Text)
        TextBox15.Text = largo
        Me.TextBox15.Text = Format(Val(CDec(TextBox15.Text)), "##,##0.00")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Para calcular distribucion de luminarias segun la dimensiones y posicion de la lamparas en el galpon
        Dim DPL1L As String
        DPL1L = Val(TextBox1.Text / TextBox14.Text / 2) * Val(TextBox16.Text / TextBox17.Text)
        TextBox18.Text = DPL1L
        Me.TextBox18.Text = Format(Val(CDec(TextBox18.Text)), "##,##0.00")

        Dim DPL2L As String
        DPL2L = Val(TextBox2.Text / TextBox15.Text / 2) * Val(TextBox23.Text / TextBox22.Text)
        TextBox19.Text = DPL2L
        Me.TextBox19.Text = Format(Val(CDec(TextBox19.Text)), "##,##0.00")

        'Para distancias entre columnas y filas
        Dim DEC As String
        DEC = Val((TextBox1.Text - (TextBox18.Text * 2)) / Val(TextBox14.Text - 1))
        TextBox20.Text = DEC
        Me.TextBox20.Text = Format(Val(CDec(TextBox20.Text)), "##,##0.00")

        Dim DEF As String
        DEF = Val((TextBox2.Text - (TextBox19.Text * 2)) / Val(TextBox15.Text - 1))
        TextBox21.Text = DEF
        Me.TextBox21.Text = Format(Val(CDec(TextBox21.Text)), "##,##0.00")

        'Para calculos de ts y cables de luminarias
        Dim CANTS As String
        CANTS = Val(TextBox14.Text * TextBox15.Text) + Val(TextBox14.Text)
        TextBox24.Text = CANTS
        Me.TextBox24.Text = Format(Val(CDec(TextBox24.Text)), "##,##0.00")

        Dim LARCAB As String
        LARCAB = Val(TextBox21.Text - (0.1 * 2))
        TextBox25.Text = LARCAB
        Me.TextBox25.Text = Format(Val(CDec(TextBox25.Text)), "##,##0.00")

        Dim CANCAB As String
        CANCAB = Val(TextBox15.Text - 1) * Val(TextBox14.Text)
        TextBox26.Text = CANCAB
        Me.TextBox26.Text = Format(Val(CDec(TextBox26.Text)), "##,##0.00")

        Dim larcabpf As String
        larcabpf = Val(TextBox19.Text - (0.1 * 2))
        TextBox27.Text = larcabpf
        Me.TextBox27.Text = Format(Val(CDec(TextBox27.Text)), "##,##0.00")

        Me.TextBox28.Text = Val(TextBox14.Text)

        Me.TextBox29.Text = Val(TextBox14.Text - 1)

        Dim LarCAbTs As String
        LarCAbTs = Val(TextBox20.Text - (0.1 * 2))
        TextBox30.Text = LarCAbTs
        Me.TextBox30.Text = Format(Val(CDec(TextBox30.Text)), "##,##0.00")
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim frm As Form11 = CType(Owner, Form11)
        'secuencia de rellenar formularios anterior y completar datos de calculos faltantes
        frm.TextBox18.Text = TextBox14.Text.ToString()
        frm.TextBox19.Text = TextBox15.Text.ToString()
        frm.TextBox28.Text = TextBox19.Text.ToString()
        frm.TextBox29.Text = TextBox18.Text.ToString()
        frm.TextBox30.Text = TextBox20.Text.ToString()
        frm.TextBox31.Text = TextBox21.Text.ToString()
        frm.TextBox47.Text = TextBox24.Text.ToString()
        frm.TextBox33.Text = TextBox25.Text.ToString()
        frm.TextBox34.Text = TextBox26.Text.ToString()
        frm.TextBox35.Text = TextBox27.Text.ToString()
        frm.TextBox32.Text = TextBox28.Text.ToString()
        frm.TextBox36.Text = TextBox29.Text.ToString()
        frm.TextBox37.Text = TextBox30.Text.ToString()
        frm.TextBox38.Text = TextBox31.Text.ToString()
        frm.TextBox39.Text = TextBox32.Text.ToString()
        Me.Hide()
    End Sub

    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label36.Text = TextBox1.Text.ToString()
        Label36.Visible = True
    End Sub
End Class