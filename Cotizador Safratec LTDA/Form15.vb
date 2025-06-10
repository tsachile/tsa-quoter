Imports MySql.Data.MySqlClient
Public Class Form15
    'Declaro e inicializo objeto para hacer la conexion a mi base datos de cpanel por medio MySQL 
    Public conex As New MySqlConnection("Server = 162.144.3.49; Database = tsachile_cotizador; Uid = tsachile_admin; Pwd = 17543593apple")
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()
            'AGREGAR TOTAL 
        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox14.Text.ToString()
            Dim Codi As String = frm.TextBox15.Text.ToString()
            Dim Cant As String = frm.TextBox16.Text.ToString()
            Dim Precio As String = frm.TextBox17.Text.ToString()
            Dim Total As String = frm.TextBox18.Text.ToString()
            Dim Moneda As String = frm.TextBox143.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)


            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        'Para Agregar en BD TSADATADEFINICIONPRECIO
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()
        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox14.Text.ToString()
            Dim Codi As String = frm.TextBox15.Text.ToString()
            Dim Cant As String = frm.TextBox16.Text.ToString()
            Dim Precio As String = frm.TextBox17.Text.ToString()
            Dim Total As String = frm.TextBox18.Text.ToString()
            Dim Moneda As String = frm.TextBox143.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPRECIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If

        'Para eliminacion de la BD TSADATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox15.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox14.Text.ToString()
            Dim Codi As String = frm.TextBox15.Text.ToString()
            Dim Cant As String = frm.TextBox16.Text.ToString()
            Dim Precio As String = frm.TextBox17.Text.ToString()
            Dim Total As String = frm.TextBox18.Text.ToString()
            Dim Moneda As String = frm.TextBox143.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox14.Text.ToString()
            Dim Codi As String = frm.TextBox15.Text.ToString()
            Dim Cant As String = frm.TextBox16.Text.ToString()
            Dim Precio As String = frm.TextBox17.Text.ToString()
            Dim Total As String = frm.TextBox18.Text.ToString()
            Dim Moneda As String = frm.TextBox143.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONCALIDAD (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox15.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox14.Text.ToString()
            Dim Codi As String = frm.TextBox15.Text.ToString()
            Dim Cant As String = frm.TextBox16.Text.ToString()
            Dim Precio As String = frm.TextBox17.Text.ToString()
            Dim Total As String = frm.TextBox18.Text.ToString()
            Dim Moneda As String = frm.TextBox143.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()


            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox14.Text.ToString()
            Dim Codi As String = frm.TextBox15.Text.ToString()
            Dim Cant As String = frm.TextBox16.Text.ToString()
            Dim Precio As String = frm.TextBox17.Text.ToString()
            Dim Total As String = frm.TextBox18.Text.ToString()
            Dim Moneda As String = frm.TextBox143.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()


            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPLAZO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()
        End If

        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox15.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox14.Text.ToString()
            Dim Codi As String = frm.TextBox15.Text.ToString()
            Dim Cant As String = frm.TextBox16.Text.ToString()
            Dim Precio As String = frm.TextBox17.Text.ToString()
            Dim Total As String = frm.TextBox18.Text.ToString()
            Dim Moneda As String = frm.TextBox143.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()


            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox14.Text.ToString()
            Dim Codi As String = frm.TextBox15.Text.ToString()
            Dim Cant As String = frm.TextBox16.Text.ToString()
            Dim Precio As String = frm.TextBox17.Text.ToString()
            Dim Total As String = frm.TextBox18.Text.ToString()
            Dim Moneda As String = frm.TextBox143.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()


            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONDESISTIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox15.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Me.Close()


    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()
            Dim Moneda As String = frm.TextBox144.Text.ToString()
            Dim Descrip As String = frm.TextBox19.Text.ToString()
            Dim Codi As String = frm.TextBox20.Text.ToString()
            Dim Cant As String = frm.TextBox21.Text.ToString()
            Dim Precio As String = frm.TextBox22.Text.ToString()
            Dim Total As String = frm.TextBox23.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()
            Dim Moneda As String = frm.TextBox144.Text.ToString()
            Dim Descrip As String = frm.TextBox19.Text.ToString()
            Dim Codi As String = frm.TextBox20.Text.ToString()
            Dim Cant As String = frm.TextBox21.Text.ToString()
            Dim Precio As String = frm.TextBox22.Text.ToString()
            Dim Total As String = frm.TextBox23.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPRECIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"



            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox20.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox19.Text.ToString()
            Dim Codi As String = frm.TextBox20.Text.ToString()
            Dim Cant As String = frm.TextBox21.Text.ToString()
            Dim Precio As String = frm.TextBox22.Text.ToString()
            Dim Total As String = frm.TextBox23.Text.ToString()
            Dim Moneda As String = frm.TextBox144.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox19.Text.ToString()
            Dim Codi As String = frm.TextBox20.Text.ToString()
            Dim Cant As String = frm.TextBox21.Text.ToString()
            Dim Precio As String = frm.TextBox22.Text.ToString()
            Dim Total As String = frm.TextBox23.Text.ToString()
            Dim Moneda As String = frm.TextBox144.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONCALIDAD (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox20.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox19.Text.ToString()
            Dim Codi As String = frm.TextBox20.Text.ToString()
            Dim Cant As String = frm.TextBox21.Text.ToString()
            Dim Precio As String = frm.TextBox22.Text.ToString()
            Dim Total As String = frm.TextBox23.Text.ToString()
            Dim Moneda As String = frm.TextBox144.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox19.Text.ToString()
            Dim Codi As String = frm.TextBox20.Text.ToString()
            Dim Cant As String = frm.TextBox21.Text.ToString()
            Dim Precio As String = frm.TextBox22.Text.ToString()
            Dim Total As String = frm.TextBox23.Text.ToString()
            Dim Moneda As String = frm.TextBox144.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPLAZO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox20.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox19.Text.ToString()
            Dim Codi As String = frm.TextBox20.Text.ToString()
            Dim Cant As String = frm.TextBox21.Text.ToString()
            Dim Precio As String = frm.TextBox22.Text.ToString()
            Dim Total As String = frm.TextBox23.Text.ToString()
            Dim Moneda As String = frm.TextBox144.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox19.Text.ToString()
            Dim Codi As String = frm.TextBox20.Text.ToString()
            Dim Cant As String = frm.TextBox21.Text.ToString()
            Dim Precio As String = frm.TextBox22.Text.ToString()
            Dim Total As String = frm.TextBox23.Text.ToString()
            Dim Moneda As String = frm.TextBox144.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONDESISTIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox20.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox24.Text.ToString()
            Dim Codi As String = frm.TextBox25.Text.ToString()
            Dim Cant As String = frm.TextBox26.Text.ToString()
            Dim Precio As String = frm.TextBox27.Text.ToString()
            Dim Total As String = frm.TextBox28.Text.ToString()
            Dim Moneda As String = frm.TextBox145.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
        Dim Fec As String = frm.TextBox8.Text.ToString()
        Dim Raz As String = frm.TextBox1.Text.ToString()
        Dim RUT As String = frm.TextBox3.Text.ToString()
        Dim Ate As String = frm.TextBox2.Text.ToString()
        Dim DirAte As String = frm.TextBox4.Text.ToString()
        Dim TelAte As String = frm.TextBox5.Text.ToString()
        Dim CorAte As String = frm.TextBox6.Text.ToString()
        Dim Ven As String = frm.TextBox9.Text.ToString()
        Dim TelVen As String = frm.TextBox12.Text.ToString()
        Dim CorVen As String = frm.TextBox10.Text.ToString()
        Dim Web As String = frm.TextBox11.Text.ToString()
        Dim Ref As String = frm.TextBox13.Text.ToString()

        Dim Descrip As String = frm.TextBox24.Text.ToString()
        Dim Codi As String = frm.TextBox25.Text.ToString()
        Dim Cant As String = frm.TextBox26.Text.ToString()
            Dim Precio As String = frm.TextBox27.Text.ToString()
            Dim Total As String = frm.TextBox28.Text.ToString()
            Dim Moneda As String = frm.TextBox145.Text.ToString()
        Dim ID As String = frm.Label2.Text.ToString()
        Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPRECIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox25.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox24.Text.ToString()
            Dim Codi As String = frm.TextBox25.Text.ToString()
            Dim Cant As String = frm.TextBox26.Text.ToString()
            Dim Precio As String = frm.TextBox27.Text.ToString()
            Dim Total As String = frm.TextBox28.Text.ToString()
            Dim Moneda As String = frm.TextBox145.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox24.Text.ToString()
            Dim Codi As String = frm.TextBox25.Text.ToString()
            Dim Cant As String = frm.TextBox26.Text.ToString()
            Dim Precio As String = frm.TextBox27.Text.ToString()
            Dim Total As String = frm.TextBox28.Text.ToString()
            Dim Moneda As String = frm.TextBox145.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONCALIDAD (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox25.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox24.Text.ToString()
            Dim Codi As String = frm.TextBox25.Text.ToString()
            Dim Cant As String = frm.TextBox26.Text.ToString()
            Dim Precio As String = frm.TextBox27.Text.ToString()
            Dim Total As String = frm.TextBox28.Text.ToString()
            Dim Moneda As String = frm.TextBox145.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox24.Text.ToString()
            Dim Codi As String = frm.TextBox25.Text.ToString()
            Dim Cant As String = frm.TextBox26.Text.ToString()
            Dim Precio As String = frm.TextBox27.Text.ToString()
            Dim Total As String = frm.TextBox28.Text.ToString()
            Dim Moneda As String = frm.TextBox145.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPLAZO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"
            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox25.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox24.Text.ToString()
            Dim Codi As String = frm.TextBox25.Text.ToString()
            Dim Cant As String = frm.TextBox26.Text.ToString()
            Dim Precio As String = frm.TextBox27.Text.ToString()
            Dim Total As String = frm.TextBox28.Text.ToString()
            Dim Moneda As String = frm.TextBox145.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox24.Text.ToString()
            Dim Codi As String = frm.TextBox25.Text.ToString()
            Dim Cant As String = frm.TextBox26.Text.ToString()
            Dim Precio As String = frm.TextBox27.Text.ToString()
            Dim Total As String = frm.TextBox28.Text.ToString()
            Dim Moneda As String = frm.TextBox145.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONDESISTIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox25.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox29.Text.ToString()
            Dim Codi As String = frm.TextBox30.Text.ToString()
            Dim Cant As String = frm.TextBox31.Text.ToString()
            Dim Precio As String = frm.TextBox32.Text.ToString()
            Dim Total As String = frm.TextBox33.Text.ToString()
            Dim Moneda As String = frm.TextBox146.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox29.Text.ToString()
            Dim Codi As String = frm.TextBox30.Text.ToString()
            Dim Cant As String = frm.TextBox31.Text.ToString()
            Dim Precio As String = frm.TextBox32.Text.ToString()
            Dim Total As String = frm.TextBox33.Text.ToString()
            Dim Moneda As String = frm.TextBox146.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPRECIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"



            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If

        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox30.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox29.Text.ToString()
            Dim Codi As String = frm.TextBox30.Text.ToString()
            Dim Cant As String = frm.TextBox31.Text.ToString()
            Dim Precio As String = frm.TextBox32.Text.ToString()
            Dim Total As String = frm.TextBox33.Text.ToString()
            Dim Moneda As String = frm.TextBox146.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
        Dim Fec As String = frm.TextBox8.Text.ToString()
        Dim Raz As String = frm.TextBox1.Text.ToString()
        Dim RUT As String = frm.TextBox3.Text.ToString()
        Dim Ate As String = frm.TextBox2.Text.ToString()
        Dim DirAte As String = frm.TextBox4.Text.ToString()
        Dim TelAte As String = frm.TextBox5.Text.ToString()
        Dim CorAte As String = frm.TextBox6.Text.ToString()
        Dim Ven As String = frm.TextBox9.Text.ToString()
        Dim TelVen As String = frm.TextBox12.Text.ToString()
        Dim CorVen As String = frm.TextBox10.Text.ToString()
        Dim Web As String = frm.TextBox11.Text.ToString()
        Dim Ref As String = frm.TextBox13.Text.ToString()

        Dim Descrip As String = frm.TextBox29.Text.ToString()
        Dim Codi As String = frm.TextBox30.Text.ToString()
        Dim Cant As String = frm.TextBox31.Text.ToString()
            Dim Precio As String = frm.TextBox32.Text.ToString()
            Dim Total As String = frm.TextBox33.Text.ToString()
            Dim Moneda As String = frm.TextBox146.Text.ToString()
        Dim ID As String = frm.Label2.Text.ToString()
        Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONCALIDAD (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox30.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox29.Text.ToString()
            Dim Codi As String = frm.TextBox30.Text.ToString()
            Dim Cant As String = frm.TextBox31.Text.ToString()
            Dim Precio As String = frm.TextBox32.Text.ToString()
            Dim Total As String = frm.TextBox33.Text.ToString()
            Dim Moneda As String = frm.TextBox146.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox29.Text.ToString()
            Dim Codi As String = frm.TextBox30.Text.ToString()
            Dim Cant As String = frm.TextBox31.Text.ToString()
            Dim Precio As String = frm.TextBox32.Text.ToString()
            Dim Total As String = frm.TextBox33.Text.ToString()
            Dim Moneda As String = frm.TextBox146.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPLAZO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox30.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox29.Text.ToString()
            Dim Codi As String = frm.TextBox30.Text.ToString()
            Dim Cant As String = frm.TextBox31.Text.ToString()
            Dim Precio As String = frm.TextBox32.Text.ToString()
            Dim Total As String = frm.TextBox33.Text.ToString()
            Dim Moneda As String = frm.TextBox146.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox29.Text.ToString()
            Dim Codi As String = frm.TextBox30.Text.ToString()
            Dim Cant As String = frm.TextBox31.Text.ToString()
            Dim Precio As String = frm.TextBox32.Text.ToString()
            Dim Total As String = frm.TextBox33.Text.ToString()
            Dim Moneda As String = frm.TextBox146.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONDESISTIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox30.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox34.Text.ToString()
            Dim Codi As String = frm.TextBox35.Text.ToString()
            Dim Cant As String = frm.TextBox36.Text.ToString()
            Dim Precio As String = frm.TextBox37.Text.ToString()
            Dim Total As String = frm.TextBox38.Text.ToString()
            Dim Moneda As String = frm.TextBox147.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox34.Text.ToString()
            Dim Codi As String = frm.TextBox35.Text.ToString()
            Dim Cant As String = frm.TextBox36.Text.ToString()
            Dim Precio As String = frm.TextBox37.Text.ToString()
            Dim Total As String = frm.TextBox38.Text.ToString()
            Dim Moneda As String = frm.TextBox147.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPRECIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()

        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox35.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox34.Text.ToString()
            Dim Codi As String = frm.TextBox35.Text.ToString()
            Dim Cant As String = frm.TextBox36.Text.ToString()
            Dim Precio As String = frm.TextBox37.Text.ToString()
            Dim Total As String = frm.TextBox38.Text.ToString()
            Dim Moneda As String = frm.TextBox147.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
        Dim Fec As String = frm.TextBox8.Text.ToString()
        Dim Raz As String = frm.TextBox1.Text.ToString()
        Dim RUT As String = frm.TextBox3.Text.ToString()
        Dim Ate As String = frm.TextBox2.Text.ToString()
        Dim DirAte As String = frm.TextBox4.Text.ToString()
        Dim TelAte As String = frm.TextBox5.Text.ToString()
        Dim CorAte As String = frm.TextBox6.Text.ToString()
        Dim Ven As String = frm.TextBox9.Text.ToString()
        Dim TelVen As String = frm.TextBox12.Text.ToString()
        Dim CorVen As String = frm.TextBox10.Text.ToString()
        Dim Web As String = frm.TextBox11.Text.ToString()
        Dim Ref As String = frm.TextBox13.Text.ToString()

        Dim Descrip As String = frm.TextBox34.Text.ToString()
        Dim Codi As String = frm.TextBox35.Text.ToString()
        Dim Cant As String = frm.TextBox36.Text.ToString()
            Dim Precio As String = frm.TextBox37.Text.ToString()
            Dim Total As String = frm.TextBox38.Text.ToString()
            Dim Moneda As String = frm.TextBox147.Text.ToString()
        Dim ID As String = frm.Label2.Text.ToString()
        Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONCALIDAD (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox35.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox34.Text.ToString()
            Dim Codi As String = frm.TextBox35.Text.ToString()
            Dim Cant As String = frm.TextBox36.Text.ToString()
            Dim Precio As String = frm.TextBox37.Text.ToString()
            Dim Total As String = frm.TextBox38.Text.ToString()
            Dim Moneda As String = frm.TextBox147.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox34.Text.ToString()
            Dim Codi As String = frm.TextBox35.Text.ToString()
            Dim Cant As String = frm.TextBox36.Text.ToString()
            Dim Precio As String = frm.TextBox37.Text.ToString()
            Dim Total As String = frm.TextBox38.Text.ToString()
            Dim Moneda As String = frm.TextBox147.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPLAZO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox35.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox34.Text.ToString()
            Dim Codi As String = frm.TextBox35.Text.ToString()
            Dim Cant As String = frm.TextBox36.Text.ToString()
            Dim Precio As String = frm.TextBox37.Text.ToString()
            Dim Total As String = frm.TextBox38.Text.ToString()
            Dim Moneda As String = frm.TextBox147.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox34.Text.ToString()
            Dim Codi As String = frm.TextBox35.Text.ToString()
            Dim Cant As String = frm.TextBox36.Text.ToString()
            Dim Precio As String = frm.TextBox37.Text.ToString()
            Dim Total As String = frm.TextBox38.Text.ToString()
            Dim Moneda As String = frm.TextBox147.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONDESISTIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox35.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox39.Text.ToString()
            Dim Codi As String = frm.TextBox40.Text.ToString()
            Dim Cant As String = frm.TextBox41.Text.ToString()
            Dim Precio As String = frm.TextBox42.Text.ToString()
            Dim Total As String = frm.TextBox43.Text.ToString()
            Dim Moneda As String = frm.TextBox148.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox39.Text.ToString()
            Dim Codi As String = frm.TextBox40.Text.ToString()
            Dim Cant As String = frm.TextBox41.Text.ToString()
            Dim Precio As String = frm.TextBox42.Text.ToString()
            Dim Total As String = frm.TextBox43.Text.ToString()
            Dim Moneda As String = frm.TextBox148.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPRECIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"



            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()
        End If

        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox40.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox39.Text.ToString()
            Dim Codi As String = frm.TextBox40.Text.ToString()
            Dim Cant As String = frm.TextBox41.Text.ToString()
            Dim Precio As String = frm.TextBox42.Text.ToString()
            Dim Total As String = frm.TextBox43.Text.ToString()
            Dim Moneda As String = frm.TextBox148.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox39.Text.ToString()
            Dim Codi As String = frm.TextBox40.Text.ToString()
            Dim Cant As String = frm.TextBox41.Text.ToString()
            Dim Precio As String = frm.TextBox42.Text.ToString()
            Dim Total As String = frm.TextBox43.Text.ToString()
            Dim Moneda As String = frm.TextBox148.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONCALIDAD (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox40.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox39.Text.ToString()
            Dim Codi As String = frm.TextBox40.Text.ToString()
            Dim Cant As String = frm.TextBox41.Text.ToString()
            Dim Precio As String = frm.TextBox42.Text.ToString()
            Dim Total As String = frm.TextBox43.Text.ToString()
            Dim Moneda As String = frm.TextBox148.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox39.Text.ToString()
            Dim Codi As String = frm.TextBox40.Text.ToString()
            Dim Cant As String = frm.TextBox41.Text.ToString()
            Dim Precio As String = frm.TextBox42.Text.ToString()
            Dim Total As String = frm.TextBox43.Text.ToString()
            Dim Moneda As String = frm.TextBox148.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPLAZO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox40.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox39.Text.ToString()
            Dim Codi As String = frm.TextBox40.Text.ToString()
            Dim Cant As String = frm.TextBox41.Text.ToString()
            Dim Precio As String = frm.TextBox42.Text.ToString()
            Dim Total As String = frm.TextBox43.Text.ToString()
            Dim Moneda As String = frm.TextBox148.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox39.Text.ToString()
            Dim Codi As String = frm.TextBox40.Text.ToString()
            Dim Cant As String = frm.TextBox41.Text.ToString()
            Dim Precio As String = frm.TextBox42.Text.ToString()
            Dim Total As String = frm.TextBox43.Text.ToString()
            Dim Moneda As String = frm.TextBox148.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONDESISTIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox40.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox44.Text.ToString()
            Dim Codi As String = frm.TextBox45.Text.ToString()
            Dim Cant As String = frm.TextBox46.Text.ToString()
            Dim Precio As String = frm.TextBox47.Text.ToString()
            Dim Total As String = frm.TextBox48.Text.ToString()
            Dim Moneda As String = frm.TextBox149.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox44.Text.ToString()
            Dim Codi As String = frm.TextBox45.Text.ToString()
            Dim Cant As String = frm.TextBox46.Text.ToString()
            Dim Precio As String = frm.TextBox47.Text.ToString()
            Dim Total As String = frm.TextBox48.Text.ToString()
            Dim Moneda As String = frm.TextBox149.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPRECIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"



            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()
        End If

        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox45.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox44.Text.ToString()
            Dim Codi As String = frm.TextBox45.Text.ToString()
            Dim Cant As String = frm.TextBox46.Text.ToString()
            Dim Precio As String = frm.TextBox47.Text.ToString()
            Dim Total As String = frm.TextBox48.Text.ToString()
            Dim Moneda As String = frm.TextBox149.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox44.Text.ToString()
            Dim Codi As String = frm.TextBox45.Text.ToString()
            Dim Cant As String = frm.TextBox46.Text.ToString()
            Dim Precio As String = frm.TextBox47.Text.ToString()
            Dim Total As String = frm.TextBox48.Text.ToString()
            Dim Moneda As String = frm.TextBox149.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONCALIDAD (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox45.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox44.Text.ToString()
            Dim Codi As String = frm.TextBox45.Text.ToString()
            Dim Cant As String = frm.TextBox46.Text.ToString()
            Dim Precio As String = frm.TextBox47.Text.ToString()
            Dim Total As String = frm.TextBox48.Text.ToString()
            Dim Moneda As String = frm.TextBox149.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox44.Text.ToString()
            Dim Codi As String = frm.TextBox45.Text.ToString()
            Dim Cant As String = frm.TextBox46.Text.ToString()
            Dim Precio As String = frm.TextBox47.Text.ToString()
            Dim Total As String = frm.TextBox48.Text.ToString()
            Dim Moneda As String = frm.TextBox149.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPLAZO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox45.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox44.Text.ToString()
            Dim Codi As String = frm.TextBox45.Text.ToString()
            Dim Cant As String = frm.TextBox46.Text.ToString()
            Dim Precio As String = frm.TextBox47.Text.ToString()
            Dim Total As String = frm.TextBox48.Text.ToString()
            Dim Moneda As String = frm.TextBox149.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox44.Text.ToString()
            Dim Codi As String = frm.TextBox45.Text.ToString()
            Dim Cant As String = frm.TextBox46.Text.ToString()
            Dim Precio As String = frm.TextBox47.Text.ToString()
            Dim Total As String = frm.TextBox48.Text.ToString()
            Dim Moneda As String = frm.TextBox149.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONDESISTIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If

        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox45.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox49.Text.ToString()
            Dim Codi As String = frm.TextBox50.Text.ToString()
            Dim Cant As String = frm.TextBox51.Text.ToString()
            Dim Precio As String = frm.TextBox52.Text.ToString()
            Dim Total As String = frm.TextBox53.Text.ToString()
            Dim Moneda As String = frm.TextBox150.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox49.Text.ToString()
            Dim Codi As String = frm.TextBox50.Text.ToString()
            Dim Cant As String = frm.TextBox51.Text.ToString()
            Dim Precio As String = frm.TextBox52.Text.ToString()
            Dim Total As String = frm.TextBox53.Text.ToString()
            Dim Moneda As String = frm.TextBox150.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPRECIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox50.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox49.Text.ToString()
            Dim Codi As String = frm.TextBox50.Text.ToString()
            Dim Cant As String = frm.TextBox51.Text.ToString()
            Dim Precio As String = frm.TextBox52.Text.ToString()
            Dim Total As String = frm.TextBox53.Text.ToString()
            Dim Moneda As String = frm.TextBox150.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox49.Text.ToString()
            Dim Codi As String = frm.TextBox50.Text.ToString()
            Dim Cant As String = frm.TextBox51.Text.ToString()
            Dim Precio As String = frm.TextBox52.Text.ToString()
            Dim Total As String = frm.TextBox53.Text.ToString()
            Dim Moneda As String = frm.TextBox150.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONCALIDAD (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox50.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button31_Click(sender As Object, e As EventArgs) Handles Button31.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox49.Text.ToString()
            Dim Codi As String = frm.TextBox50.Text.ToString()
            Dim Cant As String = frm.TextBox51.Text.ToString()
            Dim Precio As String = frm.TextBox52.Text.ToString()
            Dim Total As String = frm.TextBox53.Text.ToString()
            Dim Moneda As String = frm.TextBox150.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox49.Text.ToString()
            Dim Codi As String = frm.TextBox50.Text.ToString()
            Dim Cant As String = frm.TextBox51.Text.ToString()
            Dim Precio As String = frm.TextBox52.Text.ToString()
            Dim Total As String = frm.TextBox53.Text.ToString()
            Dim Moneda As String = frm.TextBox150.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPLAZO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox50.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button32_Click(sender As Object, e As EventArgs) Handles Button32.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox49.Text.ToString()
            Dim Codi As String = frm.TextBox50.Text.ToString()
            Dim Cant As String = frm.TextBox51.Text.ToString()
            Dim Precio As String = frm.TextBox52.Text.ToString()
            Dim Total As String = frm.TextBox53.Text.ToString()
            Dim Moneda As String = frm.TextBox150.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox49.Text.ToString()
            Dim Codi As String = frm.TextBox50.Text.ToString()
            Dim Cant As String = frm.TextBox51.Text.ToString()
            Dim Precio As String = frm.TextBox52.Text.ToString()
            Dim Total As String = frm.TextBox53.Text.ToString()
            Dim Moneda As String = frm.TextBox150.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONDESISTIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox50.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button33_Click(sender As Object, e As EventArgs) Handles Button33.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox54.Text.ToString()
            Dim Codi As String = frm.TextBox55.Text.ToString()
            Dim Cant As String = frm.TextBox56.Text.ToString()
            Dim Precio As String = frm.TextBox57.Text.ToString()
            Dim Total As String = frm.TextBox58.Text.ToString()
            Dim Moneda As String = frm.TextBox151.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox54.Text.ToString()
            Dim Codi As String = frm.TextBox55.Text.ToString()
            Dim Cant As String = frm.TextBox56.Text.ToString()
            Dim Precio As String = frm.TextBox57.Text.ToString()
            Dim Total As String = frm.TextBox58.Text.ToString()
            Dim Moneda As String = frm.TextBox151.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPRECIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"



            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox55.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button34_Click(sender As Object, e As EventArgs) Handles Button34.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox54.Text.ToString()
            Dim Codi As String = frm.TextBox55.Text.ToString()
            Dim Cant As String = frm.TextBox56.Text.ToString()
            Dim Precio As String = frm.TextBox57.Text.ToString()
            Dim Total As String = frm.TextBox58.Text.ToString()
            Dim Moneda As String = frm.TextBox151.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()
            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox54.Text.ToString()
            Dim Codi As String = frm.TextBox55.Text.ToString()
            Dim Cant As String = frm.TextBox56.Text.ToString()
            Dim Precio As String = frm.TextBox57.Text.ToString()
            Dim Total As String = frm.TextBox58.Text.ToString()
            Dim Moneda As String = frm.TextBox151.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONCALIDAD (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox55.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button35_Click(sender As Object, e As EventArgs) Handles Button35.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox54.Text.ToString()
            Dim Codi As String = frm.TextBox55.Text.ToString()
            Dim Cant As String = frm.TextBox56.Text.ToString()
            Dim Precio As String = frm.TextBox57.Text.ToString()
            Dim Total As String = frm.TextBox58.Text.ToString()
            Dim Moneda As String = frm.TextBox151.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox54.Text.ToString()
            Dim Codi As String = frm.TextBox55.Text.ToString()
            Dim Cant As String = frm.TextBox56.Text.ToString()
            Dim Precio As String = frm.TextBox57.Text.ToString()
            Dim Total As String = frm.TextBox58.Text.ToString()
            Dim Moneda As String = frm.TextBox151.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPLAZO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox55.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button36_Click(sender As Object, e As EventArgs) Handles Button36.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox54.Text.ToString()
            Dim Codi As String = frm.TextBox55.Text.ToString()
            Dim Cant As String = frm.TextBox56.Text.ToString()
            Dim Precio As String = frm.TextBox57.Text.ToString()
            Dim Total As String = frm.TextBox58.Text.ToString()
            Dim Moneda As String = frm.TextBox151.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox54.Text.ToString()
            Dim Codi As String = frm.TextBox55.Text.ToString()
            Dim Cant As String = frm.TextBox56.Text.ToString()
            Dim Precio As String = frm.TextBox57.Text.ToString()
            Dim Total As String = frm.TextBox58.Text.ToString()
            Dim Moneda As String = frm.TextBox151.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()
            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONDESISTIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox55.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button37_Click(sender As Object, e As EventArgs) Handles Button37.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox59.Text.ToString()
            Dim Codi As String = frm.TextBox60.Text.ToString()
            Dim Cant As String = frm.TextBox61.Text.ToString()
            Dim Precio As String = frm.TextBox62.Text.ToString()
            Dim Total As String = frm.TextBox63.Text.ToString()
            Dim Moneda As String = frm.TextBox152.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox59.Text.ToString()
            Dim Codi As String = frm.TextBox60.Text.ToString()
            Dim Cant As String = frm.TextBox61.Text.ToString()
            Dim Precio As String = frm.TextBox62.Text.ToString()
            Dim Total As String = frm.TextBox63.Text.ToString()
            Dim Moneda As String = frm.TextBox152.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPRECIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox60.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox59.Text.ToString()
            Dim Codi As String = frm.TextBox60.Text.ToString()
            Dim Cant As String = frm.TextBox61.Text.ToString()
            Dim Precio As String = frm.TextBox62.Text.ToString()
            Dim Total As String = frm.TextBox63.Text.ToString()
            Dim Moneda As String = frm.TextBox152.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox59.Text.ToString()
            Dim Codi As String = frm.TextBox60.Text.ToString()
            Dim Cant As String = frm.TextBox61.Text.ToString()
            Dim Precio As String = frm.TextBox62.Text.ToString()
            Dim Total As String = frm.TextBox63.Text.ToString()
            Dim Moneda As String = frm.TextBox152.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONCALIDAD (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox60.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button39_Click(sender As Object, e As EventArgs) Handles Button39.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox59.Text.ToString()
            Dim Codi As String = frm.TextBox60.Text.ToString()
            Dim Cant As String = frm.TextBox61.Text.ToString()
            Dim Precio As String = frm.TextBox62.Text.ToString()
            Dim Total As String = frm.TextBox63.Text.ToString()
            Dim Moneda As String = frm.TextBox152.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox59.Text.ToString()
            Dim Codi As String = frm.TextBox60.Text.ToString()
            Dim Cant As String = frm.TextBox61.Text.ToString()
            Dim Precio As String = frm.TextBox62.Text.ToString()
            Dim Total As String = frm.TextBox63.Text.ToString()
            Dim Moneda As String = frm.TextBox152.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPLAZO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox60.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button40_Click(sender As Object, e As EventArgs) Handles Button40.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox59.Text.ToString()
            Dim Codi As String = frm.TextBox60.Text.ToString()
            Dim Cant As String = frm.TextBox61.Text.ToString()
            Dim Precio As String = frm.TextBox62.Text.ToString()
            Dim Total As String = frm.TextBox63.Text.ToString()
            Dim Moneda As String = frm.TextBox152.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox59.Text.ToString()
            Dim Codi As String = frm.TextBox60.Text.ToString()
            Dim Cant As String = frm.TextBox61.Text.ToString()
            Dim Precio As String = frm.TextBox62.Text.ToString()
            Dim Total As String = frm.TextBox63.Text.ToString()
            Dim Moneda As String = frm.TextBox152.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONDESISTIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox60.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button41_Click(sender As Object, e As EventArgs) Handles Button41.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox64.Text.ToString()
            Dim Codi As String = frm.TextBox65.Text.ToString()
            Dim Cant As String = frm.TextBox66.Text.ToString()
            Dim Precio As String = frm.TextBox67.Text.ToString()
            Dim Total As String = frm.TextBox68.Text.ToString()
            Dim Moneda As String = frm.TextBox153.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox64.Text.ToString()
            Dim Codi As String = frm.TextBox65.Text.ToString()
            Dim Cant As String = frm.TextBox66.Text.ToString()
            Dim Precio As String = frm.TextBox67.Text.ToString()
            Dim Total As String = frm.TextBox68.Text.ToString()
            Dim Moneda As String = frm.TextBox153.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPRECIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"



            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If

        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox65.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button42_Click(sender As Object, e As EventArgs) Handles Button42.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox64.Text.ToString()
            Dim Codi As String = frm.TextBox65.Text.ToString()
            Dim Cant As String = frm.TextBox66.Text.ToString()
            Dim Precio As String = frm.TextBox67.Text.ToString()
            Dim Total As String = frm.TextBox68.Text.ToString()
            Dim Moneda As String = frm.TextBox153.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox64.Text.ToString()
            Dim Codi As String = frm.TextBox65.Text.ToString()
            Dim Cant As String = frm.TextBox66.Text.ToString()
            Dim Precio As String = frm.TextBox67.Text.ToString()
            Dim Total As String = frm.TextBox68.Text.ToString()
            Dim Moneda As String = frm.TextBox153.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONCALIDAD (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If

        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox65.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button43_Click(sender As Object, e As EventArgs) Handles Button43.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox64.Text.ToString()
            Dim Codi As String = frm.TextBox65.Text.ToString()
            Dim Cant As String = frm.TextBox66.Text.ToString()
            Dim Precio As String = frm.TextBox67.Text.ToString()
            Dim Total As String = frm.TextBox68.Text.ToString()
            Dim Moneda As String = frm.TextBox153.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox64.Text.ToString()
            Dim Codi As String = frm.TextBox65.Text.ToString()
            Dim Cant As String = frm.TextBox66.Text.ToString()
            Dim Precio As String = frm.TextBox67.Text.ToString()
            Dim Total As String = frm.TextBox68.Text.ToString()
            Dim Moneda As String = frm.TextBox153.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPLAZO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox65.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button44_Click(sender As Object, e As EventArgs) Handles Button44.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox64.Text.ToString()
            Dim Codi As String = frm.TextBox65.Text.ToString()
            Dim Cant As String = frm.TextBox66.Text.ToString()
            Dim Precio As String = frm.TextBox67.Text.ToString()
            Dim Total As String = frm.TextBox68.Text.ToString()
            Dim Moneda As String = frm.TextBox153.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox64.Text.ToString()
            Dim Codi As String = frm.TextBox65.Text.ToString()
            Dim Cant As String = frm.TextBox66.Text.ToString()
            Dim Precio As String = frm.TextBox67.Text.ToString()
            Dim Total As String = frm.TextBox68.Text.ToString()
            Dim Moneda As String = frm.TextBox153.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONDESISTIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox65.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button45_Click(sender As Object, e As EventArgs) Handles Button45.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox69.Text.ToString()
            Dim Codi As String = frm.TextBox70.Text.ToString()
            Dim Cant As String = frm.TextBox71.Text.ToString()
            Dim Precio As String = frm.TextBox72.Text.ToString()
            Dim Total As String = frm.TextBox73.Text.ToString()
            Dim Moneda As String = frm.TextBox154.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox69.Text.ToString()
            Dim Codi As String = frm.TextBox70.Text.ToString()
            Dim Cant As String = frm.TextBox71.Text.ToString()
            Dim Precio As String = frm.TextBox72.Text.ToString()
            Dim Total As String = frm.TextBox73.Text.ToString()
            Dim Moneda As String = frm.TextBox154.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPRECIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"



            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox70.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button46_Click(sender As Object, e As EventArgs) Handles Button46.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox69.Text.ToString()
            Dim Codi As String = frm.TextBox70.Text.ToString()
            Dim Cant As String = frm.TextBox71.Text.ToString()
            Dim Precio As String = frm.TextBox72.Text.ToString()
            Dim Total As String = frm.TextBox73.Text.ToString()
            Dim Moneda As String = frm.TextBox154.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox69.Text.ToString()
            Dim Codi As String = frm.TextBox70.Text.ToString()
            Dim Cant As String = frm.TextBox71.Text.ToString()
            Dim Precio As String = frm.TextBox72.Text.ToString()
            Dim Total As String = frm.TextBox73.Text.ToString()
            Dim Moneda As String = frm.TextBox154.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONCALIDAD (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox70.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button47_Click(sender As Object, e As EventArgs) Handles Button47.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox69.Text.ToString()
            Dim Codi As String = frm.TextBox70.Text.ToString()
            Dim Cant As String = frm.TextBox71.Text.ToString()
            Dim Precio As String = frm.TextBox72.Text.ToString()
            Dim Total As String = frm.TextBox73.Text.ToString()
            Dim Moneda As String = frm.TextBox154.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
        Dim Fec As String = frm.TextBox8.Text.ToString()
        Dim Raz As String = frm.TextBox1.Text.ToString()
        Dim RUT As String = frm.TextBox3.Text.ToString()
        Dim Ate As String = frm.TextBox2.Text.ToString()
        Dim DirAte As String = frm.TextBox4.Text.ToString()
        Dim TelAte As String = frm.TextBox5.Text.ToString()
        Dim CorAte As String = frm.TextBox6.Text.ToString()
        Dim Ven As String = frm.TextBox9.Text.ToString()
        Dim TelVen As String = frm.TextBox12.Text.ToString()
        Dim CorVen As String = frm.TextBox10.Text.ToString()
        Dim Web As String = frm.TextBox11.Text.ToString()
        Dim Ref As String = frm.TextBox13.Text.ToString()

        Dim Descrip As String = frm.TextBox69.Text.ToString()
        Dim Codi As String = frm.TextBox70.Text.ToString()
        Dim Cant As String = frm.TextBox71.Text.ToString()
            Dim Precio As String = frm.TextBox72.Text.ToString()
            Dim Total As String = frm.TextBox73.Text.ToString()
            Dim Moneda As String = frm.TextBox154.Text.ToString()
        Dim ID As String = frm.Label2.Text.ToString()
        Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPLAZO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox70.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button48_Click(sender As Object, e As EventArgs) Handles Button48.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox69.Text.ToString()
            Dim Codi As String = frm.TextBox70.Text.ToString()
            Dim Cant As String = frm.TextBox71.Text.ToString()
            Dim Precio As String = frm.TextBox72.Text.ToString()
            Dim Total As String = frm.TextBox73.Text.ToString()
            Dim Moneda As String = frm.TextBox154.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox69.Text.ToString()
            Dim Codi As String = frm.TextBox70.Text.ToString()
            Dim Cant As String = frm.TextBox71.Text.ToString()
            Dim Precio As String = frm.TextBox72.Text.ToString()
            Dim Total As String = frm.TextBox73.Text.ToString()
            Dim Moneda As String = frm.TextBox154.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONDESISTIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox70.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button49_Click(sender As Object, e As EventArgs) Handles Button49.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox74.Text.ToString()
            Dim Codi As String = frm.TextBox75.Text.ToString()
            Dim Cant As String = frm.TextBox76.Text.ToString()
            Dim Precio As String = frm.TextBox77.Text.ToString()
            Dim Total As String = frm.TextBox78.Text.ToString()
            Dim Moneda As String = frm.TextBox155.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim seleccion As New MySqlCommand(Agregar, conex)

            seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox74.Text.ToString()
            Dim Codi As String = frm.TextBox75.Text.ToString()
            Dim Cant As String = frm.TextBox76.Text.ToString()
            Dim Precio As String = frm.TextBox77.Text.ToString()
            Dim Total As String = frm.TextBox78.Text.ToString()
            Dim Moneda As String = frm.TextBox155.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPRECIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim seleccion As New MySqlCommand(Agregar, conex)
            seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox75.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button50_Click(sender As Object, e As EventArgs) Handles Button50.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox74.Text.ToString()
            Dim Codi As String = frm.TextBox75.Text.ToString()
            Dim Cant As String = frm.TextBox76.Text.ToString()
            Dim Precio As String = frm.TextBox77.Text.ToString()
            Dim Total As String = frm.TextBox78.Text.ToString()
            Dim Moneda As String = frm.TextBox155.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox74.Text.ToString()
            Dim Codi As String = frm.TextBox75.Text.ToString()
            Dim Cant As String = frm.TextBox76.Text.ToString()
            Dim Precio As String = frm.TextBox77.Text.ToString()
            Dim Total As String = frm.TextBox78.Text.ToString()
            Dim Moneda As String = frm.TextBox155.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONCALIDAD (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox75.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button51_Click(sender As Object, e As EventArgs) Handles Button51.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox74.Text.ToString()
            Dim Codi As String = frm.TextBox75.Text.ToString()
            Dim Cant As String = frm.TextBox76.Text.ToString()
            Dim Precio As String = frm.TextBox77.Text.ToString()
            Dim Total As String = frm.TextBox78.Text.ToString()
            Dim Moneda As String = frm.TextBox155.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox74.Text.ToString()
            Dim Codi As String = frm.TextBox75.Text.ToString()
            Dim Cant As String = frm.TextBox76.Text.ToString()
            Dim Precio As String = frm.TextBox77.Text.ToString()
            Dim Total As String = frm.TextBox78.Text.ToString()
            Dim Moneda As String = frm.TextBox155.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPLAZO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox75.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button52_Click(sender As Object, e As EventArgs) Handles Button52.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox74.Text.ToString()
            Dim Codi As String = frm.TextBox75.Text.ToString()
            Dim Cant As String = frm.TextBox76.Text.ToString()
            Dim Precio As String = frm.TextBox77.Text.ToString()
            Dim Total As String = frm.TextBox78.Text.ToString()
            Dim Moneda As String = frm.TextBox155.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox74.Text.ToString()
            Dim Codi As String = frm.TextBox75.Text.ToString()
            Dim Cant As String = frm.TextBox76.Text.ToString()
            Dim Precio As String = frm.TextBox77.Text.ToString()
            Dim Total As String = frm.TextBox78.Text.ToString()
            Dim Moneda As String = frm.TextBox155.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONDESISTIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox75.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button53_Click(sender As Object, e As EventArgs) Handles Button53.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox79.Text.ToString()
            Dim Codi As String = frm.TextBox80.Text.ToString()
            Dim Cant As String = frm.TextBox81.Text.ToString()
            Dim Precio As String = frm.TextBox82.Text.ToString()
            Dim Total As String = frm.TextBox83.Text.ToString()
            Dim Moneda As String = frm.TextBox156.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox79.Text.ToString()
            Dim Codi As String = frm.TextBox80.Text.ToString()
            Dim Cant As String = frm.TextBox81.Text.ToString()
            Dim Precio As String = frm.TextBox82.Text.ToString()
            Dim Total As String = frm.TextBox83.Text.ToString()
            Dim Moneda As String = frm.TextBox156.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPRECIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"



            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If

        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox80.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button54_Click(sender As Object, e As EventArgs) Handles Button54.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox79.Text.ToString()
            Dim Codi As String = frm.TextBox80.Text.ToString()
            Dim Cant As String = frm.TextBox81.Text.ToString()
            Dim Precio As String = frm.TextBox82.Text.ToString()
            Dim Total As String = frm.TextBox83.Text.ToString()
            Dim Moneda As String = frm.TextBox156.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox79.Text.ToString()
            Dim Codi As String = frm.TextBox80.Text.ToString()
            Dim Cant As String = frm.TextBox81.Text.ToString()
            Dim Precio As String = frm.TextBox82.Text.ToString()
            Dim Total As String = frm.TextBox83.Text.ToString()
            Dim Moneda As String = frm.TextBox156.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONCALIDAD (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox80.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button55_Click(sender As Object, e As EventArgs) Handles Button55.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox79.Text.ToString()
            Dim Codi As String = frm.TextBox80.Text.ToString()
            Dim Cant As String = frm.TextBox81.Text.ToString()
            Dim Precio As String = frm.TextBox82.Text.ToString()
            Dim Total As String = frm.TextBox83.Text.ToString()
            Dim Moneda As String = frm.TextBox156.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox79.Text.ToString()
            Dim Codi As String = frm.TextBox80.Text.ToString()
            Dim Cant As String = frm.TextBox81.Text.ToString()
            Dim Precio As String = frm.TextBox82.Text.ToString()
            Dim Total As String = frm.TextBox83.Text.ToString()
            Dim Moneda As String = frm.TextBox156.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPLAZO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox80.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button56_Click(sender As Object, e As EventArgs) Handles Button56.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox79.Text.ToString()
            Dim Codi As String = frm.TextBox80.Text.ToString()
            Dim Cant As String = frm.TextBox81.Text.ToString()
            Dim Precio As String = frm.TextBox82.Text.ToString()
            Dim Total As String = frm.TextBox83.Text.ToString()
            Dim Moneda As String = frm.TextBox156.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox79.Text.ToString()
            Dim Codi As String = frm.TextBox80.Text.ToString()
            Dim Cant As String = frm.TextBox81.Text.ToString()
            Dim Precio As String = frm.TextBox82.Text.ToString()
            Dim Total As String = frm.TextBox83.Text.ToString()
            Dim Moneda As String = frm.TextBox156.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONDESISTIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox80.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button57_Click(sender As Object, e As EventArgs) Handles Button57.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox84.Text.ToString()
            Dim Codi As String = frm.TextBox85.Text.ToString()
            Dim Cant As String = frm.TextBox86.Text.ToString()
            Dim Precio As String = frm.TextBox87.Text.ToString()
            Dim Total As String = frm.TextBox88.Text.ToString()
            Dim Moneda As String = frm.TextBox157.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()
            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox84.Text.ToString()
            Dim Codi As String = frm.TextBox85.Text.ToString()
            Dim Cant As String = frm.TextBox86.Text.ToString()
            Dim Precio As String = frm.TextBox87.Text.ToString()
            Dim Total As String = frm.TextBox88.Text.ToString()
            Dim Moneda As String = frm.TextBox157.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPRECIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"



            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox85.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button58_Click(sender As Object, e As EventArgs) Handles Button58.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox84.Text.ToString()
            Dim Codi As String = frm.TextBox85.Text.ToString()
            Dim Cant As String = frm.TextBox86.Text.ToString()
            Dim Precio As String = frm.TextBox87.Text.ToString()
            Dim Total As String = frm.TextBox88.Text.ToString()
            Dim Moneda As String = frm.TextBox157.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox84.Text.ToString()
            Dim Codi As String = frm.TextBox85.Text.ToString()
            Dim Cant As String = frm.TextBox86.Text.ToString()
            Dim Precio As String = frm.TextBox87.Text.ToString()
            Dim Total As String = frm.TextBox88.Text.ToString()
            Dim Moneda As String = frm.TextBox157.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONCALIDAD (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox85.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button59_Click(sender As Object, e As EventArgs) Handles Button59.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox84.Text.ToString()
            Dim Codi As String = frm.TextBox85.Text.ToString()
            Dim Cant As String = frm.TextBox86.Text.ToString()
            Dim Precio As String = frm.TextBox87.Text.ToString()
            Dim Total As String = frm.TextBox88.Text.ToString()
            Dim Moneda As String = frm.TextBox157.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox84.Text.ToString()
            Dim Codi As String = frm.TextBox85.Text.ToString()
            Dim Cant As String = frm.TextBox86.Text.ToString()
            Dim Precio As String = frm.TextBox87.Text.ToString()
            Dim Total As String = frm.TextBox88.Text.ToString()
            Dim Moneda As String = frm.TextBox157.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPLAZO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox85.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button60_Click(sender As Object, e As EventArgs) Handles Button60.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox84.Text.ToString()
            Dim Codi As String = frm.TextBox85.Text.ToString()
            Dim Cant As String = frm.TextBox86.Text.ToString()
            Dim Precio As String = frm.TextBox87.Text.ToString()
            Dim Total As String = frm.TextBox88.Text.ToString()
            Dim Moneda As String = frm.TextBox157.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox84.Text.ToString()
            Dim Codi As String = frm.TextBox85.Text.ToString()
            Dim Cant As String = frm.TextBox86.Text.ToString()
            Dim Precio As String = frm.TextBox87.Text.ToString()
            Dim Total As String = frm.TextBox88.Text.ToString()
            Dim Moneda As String = frm.TextBox157.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()
            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONDESISTIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox85.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button61_Click(sender As Object, e As EventArgs) Handles Button61.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox89.Text.ToString()
            Dim Codi As String = frm.TextBox90.Text.ToString()
            Dim Cant As String = frm.TextBox91.Text.ToString()
            Dim Precio As String = frm.TextBox92.Text.ToString()
            Dim Total As String = frm.TextBox93.Text.ToString()
            Dim Moneda As String = frm.TextBox158.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox89.Text.ToString()
            Dim Codi As String = frm.TextBox90.Text.ToString()
            Dim Cant As String = frm.TextBox91.Text.ToString()
            Dim Precio As String = frm.TextBox92.Text.ToString()
            Dim Total As String = frm.TextBox93.Text.ToString()
            Dim Moneda As String = frm.TextBox158.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPRECIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"



            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If

        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox90.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button62_Click(sender As Object, e As EventArgs) Handles Button62.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox89.Text.ToString()
            Dim Codi As String = frm.TextBox90.Text.ToString()
            Dim Cant As String = frm.TextBox91.Text.ToString()
            Dim Precio As String = frm.TextBox92.Text.ToString()
            Dim Total As String = frm.TextBox93.Text.ToString()
            Dim Moneda As String = frm.TextBox158.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox89.Text.ToString()
            Dim Codi As String = frm.TextBox90.Text.ToString()
            Dim Cant As String = frm.TextBox91.Text.ToString()
            Dim Precio As String = frm.TextBox92.Text.ToString()
            Dim Total As String = frm.TextBox93.Text.ToString()
            Dim Moneda As String = frm.TextBox158.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONCALIDAD (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox90.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button63_Click(sender As Object, e As EventArgs) Handles Button63.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox89.Text.ToString()
            Dim Codi As String = frm.TextBox90.Text.ToString()
            Dim Cant As String = frm.TextBox91.Text.ToString()
            Dim Precio As String = frm.TextBox92.Text.ToString()
            Dim Total As String = frm.TextBox93.Text.ToString()
            Dim Moneda As String = frm.TextBox158.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
        Dim Fec As String = frm.TextBox8.Text.ToString()
        Dim Raz As String = frm.TextBox1.Text.ToString()
        Dim RUT As String = frm.TextBox3.Text.ToString()
        Dim Ate As String = frm.TextBox2.Text.ToString()
        Dim DirAte As String = frm.TextBox4.Text.ToString()
        Dim TelAte As String = frm.TextBox5.Text.ToString()
        Dim CorAte As String = frm.TextBox6.Text.ToString()
        Dim Ven As String = frm.TextBox9.Text.ToString()
        Dim TelVen As String = frm.TextBox12.Text.ToString()
        Dim CorVen As String = frm.TextBox10.Text.ToString()
        Dim Web As String = frm.TextBox11.Text.ToString()
        Dim Ref As String = frm.TextBox13.Text.ToString()

        Dim Descrip As String = frm.TextBox89.Text.ToString()
        Dim Codi As String = frm.TextBox90.Text.ToString()
        Dim Cant As String = frm.TextBox91.Text.ToString()
            Dim Precio As String = frm.TextBox92.Text.ToString()
            Dim Total As String = frm.TextBox93.Text.ToString()
            Dim Moneda As String = frm.TextBox158.Text.ToString()
        Dim ID As String = frm.Label2.Text.ToString()
        Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPLAZO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox90.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button64_Click(sender As Object, e As EventArgs) Handles Button64.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox89.Text.ToString()
            Dim Codi As String = frm.TextBox90.Text.ToString()
            Dim Cant As String = frm.TextBox91.Text.ToString()
            Dim Precio As String = frm.TextBox92.Text.ToString()
            Dim Total As String = frm.TextBox93.Text.ToString()
            Dim Moneda As String = frm.TextBox158.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox89.Text.ToString()
            Dim Codi As String = frm.TextBox90.Text.ToString()
            Dim Cant As String = frm.TextBox91.Text.ToString()
            Dim Precio As String = frm.TextBox92.Text.ToString()
            Dim Total As String = frm.TextBox93.Text.ToString()
            Dim Moneda As String = frm.TextBox158.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONDESISTIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox90.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button65_Click(sender As Object, e As EventArgs) Handles Button65.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox94.Text.ToString()
            Dim Codi As String = frm.TextBox95.Text.ToString()
            Dim Cant As String = frm.TextBox96.Text.ToString()
            Dim Precio As String = frm.TextBox97.Text.ToString()
            Dim Total As String = frm.TextBox98.Text.ToString()
            Dim Moneda As String = frm.TextBox159.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox94.Text.ToString()
            Dim Codi As String = frm.TextBox95.Text.ToString()
            Dim Cant As String = frm.TextBox96.Text.ToString()
            Dim Precio As String = frm.TextBox97.Text.ToString()
            Dim Total As String = frm.TextBox98.Text.ToString()
            Dim Moneda As String = frm.TextBox159.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPRECIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox95.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button66_Click(sender As Object, e As EventArgs) Handles Button66.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox94.Text.ToString()
            Dim Codi As String = frm.TextBox95.Text.ToString()
            Dim Cant As String = frm.TextBox96.Text.ToString()
            Dim Precio As String = frm.TextBox97.Text.ToString()
            Dim Total As String = frm.TextBox98.Text.ToString()
            Dim Moneda As String = frm.TextBox159.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox94.Text.ToString()
            Dim Codi As String = frm.TextBox95.Text.ToString()
            Dim Cant As String = frm.TextBox96.Text.ToString()
            Dim Precio As String = frm.TextBox97.Text.ToString()
            Dim Total As String = frm.TextBox98.Text.ToString()
            Dim Moneda As String = frm.TextBox159.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONCALIDAD (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox95.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button67_Click(sender As Object, e As EventArgs) Handles Button67.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox94.Text.ToString()
            Dim Codi As String = frm.TextBox95.Text.ToString()
            Dim Cant As String = frm.TextBox96.Text.ToString()
            Dim Precio As String = frm.TextBox97.Text.ToString()
            Dim Total As String = frm.TextBox98.Text.ToString()
            Dim Moneda As String = frm.TextBox159.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox94.Text.ToString()
            Dim Codi As String = frm.TextBox95.Text.ToString()
            Dim Cant As String = frm.TextBox96.Text.ToString()
            Dim Precio As String = frm.TextBox97.Text.ToString()
            Dim Total As String = frm.TextBox98.Text.ToString()
            Dim Moneda As String = frm.TextBox159.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPLAZO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If

        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox95.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button68_Click(sender As Object, e As EventArgs) Handles Button68.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox94.Text.ToString()
            Dim Codi As String = frm.TextBox95.Text.ToString()
            Dim Cant As String = frm.TextBox96.Text.ToString()
            Dim Precio As String = frm.TextBox97.Text.ToString()
            Dim Total As String = frm.TextBox98.Text.ToString()
            Dim Moneda As String = frm.TextBox159.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox94.Text.ToString()
            Dim Codi As String = frm.TextBox95.Text.ToString()
            Dim Cant As String = frm.TextBox96.Text.ToString()
            Dim Precio As String = frm.TextBox97.Text.ToString()
            Dim Total As String = frm.TextBox98.Text.ToString()
            Dim Moneda As String = frm.TextBox159.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONDESISTIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox95.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button69_Click(sender As Object, e As EventArgs) Handles Button69.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox99.Text.ToString()
            Dim Codi As String = frm.TextBox100.Text.ToString()
            Dim Cant As String = frm.TextBox101.Text.ToString()
            Dim Precio As String = frm.TextBox102.Text.ToString()
            Dim Total As String = frm.TextBox103.Text.ToString()
            Dim Moneda As String = frm.TextBox160.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox99.Text.ToString()
            Dim Codi As String = frm.TextBox100.Text.ToString()
            Dim Cant As String = frm.TextBox101.Text.ToString()
            Dim Precio As String = frm.TextBox102.Text.ToString()
            Dim Total As String = frm.TextBox103.Text.ToString()
            Dim Moneda As String = frm.TextBox160.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPRECIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox100.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button70_Click(sender As Object, e As EventArgs) Handles Button70.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox99.Text.ToString()
            Dim Codi As String = frm.TextBox100.Text.ToString()
            Dim Cant As String = frm.TextBox101.Text.ToString()
            Dim Precio As String = frm.TextBox102.Text.ToString()
            Dim Total As String = frm.TextBox103.Text.ToString()
            Dim Moneda As String = frm.TextBox160.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox99.Text.ToString()
            Dim Codi As String = frm.TextBox100.Text.ToString()
            Dim Cant As String = frm.TextBox101.Text.ToString()
            Dim Precio As String = frm.TextBox102.Text.ToString()
            Dim Total As String = frm.TextBox103.Text.ToString()
            Dim Moneda As String = frm.TextBox160.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONCALIDAD (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If

        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox100.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button71_Click(sender As Object, e As EventArgs) Handles Button71.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox99.Text.ToString()
            Dim Codi As String = frm.TextBox100.Text.ToString()
            Dim Cant As String = frm.TextBox101.Text.ToString()
            Dim Precio As String = frm.TextBox102.Text.ToString()
            Dim Total As String = frm.TextBox103.Text.ToString()
            Dim Moneda As String = frm.TextBox160.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox99.Text.ToString()
            Dim Codi As String = frm.TextBox100.Text.ToString()
            Dim Cant As String = frm.TextBox101.Text.ToString()
            Dim Precio As String = frm.TextBox102.Text.ToString()
            Dim Total As String = frm.TextBox103.Text.ToString()
            Dim Moneda As String = frm.TextBox160.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPLAZO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox100.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button72_Click(sender As Object, e As EventArgs) Handles Button72.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox99.Text.ToString()
            Dim Codi As String = frm.TextBox100.Text.ToString()
            Dim Cant As String = frm.TextBox101.Text.ToString()
            Dim Precio As String = frm.TextBox102.Text.ToString()
            Dim Total As String = frm.TextBox103.Text.ToString()
            Dim Moneda As String = frm.TextBox160.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox99.Text.ToString()
            Dim Codi As String = frm.TextBox100.Text.ToString()
            Dim Cant As String = frm.TextBox101.Text.ToString()
            Dim Precio As String = frm.TextBox102.Text.ToString()
            Dim Total As String = frm.TextBox103.Text.ToString()
            Dim Moneda As String = frm.TextBox160.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONDESISTIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If

        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox100.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button73_Click(sender As Object, e As EventArgs) Handles Button73.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox104.Text.ToString()
            Dim Codi As String = frm.TextBox105.Text.ToString()
            Dim Cant As String = frm.TextBox106.Text.ToString()
            Dim Precio As String = frm.TextBox107.Text.ToString()
            Dim Total As String = frm.TextBox108.Text.ToString()
            Dim Moneda As String = frm.TextBox161.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox104.Text.ToString()
            Dim Codi As String = frm.TextBox105.Text.ToString()
            Dim Cant As String = frm.TextBox106.Text.ToString()
            Dim Precio As String = frm.TextBox107.Text.ToString()
            Dim Total As String = frm.TextBox108.Text.ToString()
            Dim Moneda As String = frm.TextBox161.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPRECIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox105.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button74_Click(sender As Object, e As EventArgs) Handles Button74.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox104.Text.ToString()
            Dim Codi As String = frm.TextBox105.Text.ToString()
            Dim Cant As String = frm.TextBox106.Text.ToString()
            Dim Precio As String = frm.TextBox107.Text.ToString()
            Dim Total As String = frm.TextBox108.Text.ToString()
            Dim Moneda As String = frm.TextBox161.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox104.Text.ToString()
            Dim Codi As String = frm.TextBox105.Text.ToString()
            Dim Cant As String = frm.TextBox106.Text.ToString()
            Dim Precio As String = frm.TextBox107.Text.ToString()
            Dim Total As String = frm.TextBox108.Text.ToString()
            Dim Moneda As String = frm.TextBox161.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONCALIDAD (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox105.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button75_Click(sender As Object, e As EventArgs) Handles Button75.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox104.Text.ToString()
            Dim Codi As String = frm.TextBox105.Text.ToString()
            Dim Cant As String = frm.TextBox106.Text.ToString()
            Dim Precio As String = frm.TextBox107.Text.ToString()
            Dim Total As String = frm.TextBox108.Text.ToString()
            Dim Moneda As String = frm.TextBox161.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox104.Text.ToString()
            Dim Codi As String = frm.TextBox105.Text.ToString()
            Dim Cant As String = frm.TextBox106.Text.ToString()
            Dim Precio As String = frm.TextBox107.Text.ToString()
            Dim Total As String = frm.TextBox108.Text.ToString()
            Dim Moneda As String = frm.TextBox161.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPLAZO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox105.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button76_Click(sender As Object, e As EventArgs) Handles Button76.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox104.Text.ToString()
            Dim Codi As String = frm.TextBox105.Text.ToString()
            Dim Cant As String = frm.TextBox106.Text.ToString()
            Dim Precio As String = frm.TextBox107.Text.ToString()
            Dim Total As String = frm.TextBox108.Text.ToString()
            Dim Moneda As String = frm.TextBox161.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox104.Text.ToString()
            Dim Codi As String = frm.TextBox105.Text.ToString()
            Dim Cant As String = frm.TextBox106.Text.ToString()
            Dim Precio As String = frm.TextBox107.Text.ToString()
            Dim Total As String = frm.TextBox108.Text.ToString()
            Dim Moneda As String = frm.TextBox161.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONDESISTIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If

        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox105.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button77_Click(sender As Object, e As EventArgs) Handles Button77.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox109.Text.ToString()
            Dim Codi As String = frm.TextBox110.Text.ToString()
            Dim Cant As String = frm.TextBox111.Text.ToString()
            Dim Precio As String = frm.TextBox112.Text.ToString()
            Dim Total As String = frm.TextBox113.Text.ToString()
            Dim Moneda As String = frm.TextBox162.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox109.Text.ToString()
            Dim Codi As String = frm.TextBox110.Text.ToString()
            Dim Cant As String = frm.TextBox111.Text.ToString()
            Dim Precio As String = frm.TextBox112.Text.ToString()
            Dim Total As String = frm.TextBox113.Text.ToString()
            Dim Moneda As String = frm.TextBox162.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label1.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPRECIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox110.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button78_Click(sender As Object, e As EventArgs) Handles Button78.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox109.Text.ToString()
            Dim Codi As String = frm.TextBox110.Text.ToString()
            Dim Cant As String = frm.TextBox111.Text.ToString()
            Dim Precio As String = frm.TextBox112.Text.ToString()
            Dim Total As String = frm.TextBox113.Text.ToString()
            Dim Moneda As String = frm.TextBox162.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox109.Text.ToString()
            Dim Codi As String = frm.TextBox110.Text.ToString()
            Dim Cant As String = frm.TextBox111.Text.ToString()
            Dim Precio As String = frm.TextBox112.Text.ToString()
            Dim Total As String = frm.TextBox113.Text.ToString()
            Dim Moneda As String = frm.TextBox162.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label2.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONCALIDAD (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox110.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button79_Click(sender As Object, e As EventArgs) Handles Button79.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox109.Text.ToString()
            Dim Codi As String = frm.TextBox110.Text.ToString()
            Dim Cant As String = frm.TextBox111.Text.ToString()
            Dim Precio As String = frm.TextBox112.Text.ToString()
            Dim Total As String = frm.TextBox113.Text.ToString()
            Dim Moneda As String = frm.TextBox162.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox109.Text.ToString()
            Dim Codi As String = frm.TextBox110.Text.ToString()
            Dim Cant As String = frm.TextBox111.Text.ToString()
            Dim Precio As String = frm.TextBox112.Text.ToString()
            Dim Total As String = frm.TextBox113.Text.ToString()
            Dim Moneda As String = frm.TextBox162.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label3.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONPLAZO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"

            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox110.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Button80_Click(sender As Object, e As EventArgs) Handles Button80.Click
        Dim frm As Form10 = CType(Owner, Form10)
        'Para Agregar a la BD SAFRATECDATADEFINICION
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox109.Text.ToString()
            Dim Codi As String = frm.TextBox110.Text.ToString()
            Dim Cant As String = frm.TextBox111.Text.ToString()
            Dim Precio As String = frm.TextBox112.Text.ToString()
            Dim Total As String = frm.TextBox113.Text.ToString()
            Dim Moneda As String = frm.TextBox162.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICION (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)

            Seleccion.Connection.Open()
            Seleccion.ExecuteNonQuery()
        End If
        '
        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else
            Dim Cot As String = frm.TextBox7.Text.ToString()
            Dim Fec As String = frm.TextBox8.Text.ToString()
            Dim Raz As String = frm.TextBox1.Text.ToString()
            Dim RUT As String = frm.TextBox3.Text.ToString()
            Dim Ate As String = frm.TextBox2.Text.ToString()
            Dim DirAte As String = frm.TextBox4.Text.ToString()
            Dim TelAte As String = frm.TextBox5.Text.ToString()
            Dim CorAte As String = frm.TextBox6.Text.ToString()
            Dim Ven As String = frm.TextBox9.Text.ToString()
            Dim TelVen As String = frm.TextBox12.Text.ToString()
            Dim CorVen As String = frm.TextBox10.Text.ToString()
            Dim Web As String = frm.TextBox11.Text.ToString()
            Dim Ref As String = frm.TextBox13.Text.ToString()

            Dim Descrip As String = frm.TextBox109.Text.ToString()
            Dim Codi As String = frm.TextBox110.Text.ToString()
            Dim Cant As String = frm.TextBox111.Text.ToString()
            Dim Precio As String = frm.TextBox112.Text.ToString()
            Dim Total As String = frm.TextBox113.Text.ToString()
            Dim Moneda As String = frm.TextBox162.Text.ToString()
            Dim ID As String = frm.Label2.Text.ToString()
            Dim Def As String = Label4.Text.ToString()

            Dim Agregar As String = "INSERT INTO TSADATADEFINICIONDESISTIO (Cotizacion, Fecha, Razon_Social, RUT, Atencion, Direccion_ate, Telefono_ate, Correo_ate,
            Contacto, Telefono_cont, Correo_cont, Pagina_Web, Referencia, Descripcion_mat, Codigo_mat, Cantidad, Precio, Total, Moneda, ID, Definicion) VALUES ('" & Cot & "','" & Fec & "',
            '" & Raz & "','" & RUT & "','" & Ate & "','" & DirAte & "','" & TelAte & "','" & CorAte & "','" & Ven & "','" & TelVen & "','" & CorVen & "','" & Web & "',
            '" & Ref & "','" & Descrip & "','" & Codi & "','" & Cant & "','" & Precio & "','" & Total & "','" & Moneda & "','" & ID & "','" & Def & "')"


            Dim Seleccion As New MySqlCommand(Agregar, conex)
            Seleccion.ExecuteNonQuery()
        End If
        'Para eliminacion de la BD SAFRATECDATACOTIZACION

        If (frm.Label2.Text = "") Then
            frm.Label2.Select()

        Else

            Dim ELIMINACION As String = ("DELETE FROM TSADATACOTIZACION WHERE ID= ?ID and Codigo_mat= ?Codigo")
            Dim Borrar As New MySqlCommand(ELIMINACION, conex)

            Borrar.Parameters.AddWithValue("?Codigo", frm.TextBox110.Text)
            Borrar.Parameters.AddWithValue("?ID", frm.Label2.Text)

            Borrar.ExecuteNonQuery()

        End If
        Me.Close()
        frm.Close()
    End Sub

    Private Sub Form15_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class