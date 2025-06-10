Imports MySql.Data.MySqlClient
Public Class Form7
    Dim sql As String
    'Declaro e inicializo objeto para hacer la conexion a mi base datos de cpanel por medio MySQL 
    Public conex As New MySqlConnection("Server = 162.144.3.49; Database = tsachile_cotizador; Uid = tsachile_admin; Pwd = 17543593apple")
    ' Por medio de este objeto voy a enviar todos los comandos de SQL a la tabla por medio de la conexión
    Public comm As New MySqlCommand

    Private Const A As String = "INSERT INTO Usuarios(Id, Atencion, Correo, Telefono, Usuario, Contraseña, Iniciales, Prefijo) VALUES ('"

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Trato de abrir la conexión
            conex.Open()
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

        Dim sqlusuario As String = " Select * From  Usuarios "

        Cargar_MySQLCliente(sqlusuario, DGUsuario)
    End Sub

    Private Sub DGUsuario_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGUsuario.CellContentClick
        Dim xtreme As Integer
        xtreme = DGUsuario.CurrentRow.Index
        TextBox1.Text = Me.DGUsuario.Item(0, xtreme).Value
        TextBox2.Text = Me.DGUsuario.Item(1, xtreme).Value
        TextBox4.Text = Me.DGUsuario.Item(2, xtreme).Value
        TextBox5.Text = Me.DGUsuario.Item(3, xtreme).Value
        TextBox6.Text = Me.DGUsuario.Item(4, xtreme).Value
        TextBox7.Text = Me.DGUsuario.Item(5, xtreme).Value
        TextBox8.Text = Me.DGUsuario.Item(6, xtreme).Value
        TextBox3.Text = Me.DGUsuario.Item(7, xtreme).Value

    End Sub
    Private Sub limpiarcampos()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        limpiarcampos()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MessageBox.Show("¿ Seguro que desea insertar este registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            ' para comenzar insertar valores en la data 
            ' Verifico que haya escrito el ISBN (bueno, debería verificarlos todos, pero como esta es la clave principal...)
            If TextBox1.Text = "" Then
                ' Si no lo escribió, mando mensaje de error
                MsgBox("Debe incluir ID")
                TextBox1.Select()
            Else
                'Para asegurar si esta correcto el registro
                If TextBox2.Text > "?" Then


                End If
                ' Si sí lo escribió, comienza la diversión (jeje)
                ' Armo la instrucción INSERT en la variable SQL
                sql = A & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox3.Text & "')"

                ' Asigno la instrucción SQL que se va a ejecutar
                comm.CommandText = sql

                Try
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(Err.Description, MsgBoxStyle.Exclamation, "TSA")
                End Try
            End If
        End If
        limpiarcampos()

        Dim sqlusuario As String = " Select * From  Usuarios "

        Cargar_MySQLCliente(sqlusuario, DGUsuario)
    End Sub
    '=================================================================
    'Para proceso de eliminacion de Usuarios

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If MessageBox.Show("¿ Seguro que desea Eliminar este registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

            If (TextBox1.Text = "") Then
                TextBox1.Select()
            Else
                Dim identificador As Integer

                identificador = Me.TextBox1.Text

                sql = "DELETE FROM Usuarios WHERE ID= " & identificador & " "
                'Asigno la instrucción SQL que se va a ejecutar
                comm.CommandText = sql
                Try
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(Err.Description, MsgBoxStyle.Exclamation, "TSA")
                End Try
            End If
            limpiarcampos()

            Dim sqlusuario As String = " Select * From  Usuarios "

            Cargar_MySQLCliente(sqlusuario, DGUsuario)
        End If
    End Sub
    '======================================================================================
    'PARA ACTUALIZAR O MODIFICAR REGISTRO
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MessageBox.Show("¿ Seguro que desea Modificar este registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then


            If (TextBox1.Text = "") Then
                TextBox1.Select()

            Else
                Dim identificador As Integer
                identificador = Me.TextBox1.Text

                sql = "Update Usuarios Set Atencion ='" & Me.TextBox2.Text & "', Correo= '" & TextBox4.Text & "', Telefono = '" & TextBox5.Text & "', Usuario = '" & TextBox6.Text & "', Contraseña = '" & TextBox7.Text & "', Iniciales = '" & TextBox8.Text & "', Prefijo = '" & TextBox3.Text & "' Where Id= '" & Conversion.Int(identificador) & "'"

                'Asigno la instrucción SQL que se va a ejecutar
                comm.CommandText = sql
                Try
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(Err.Description, MsgBoxStyle.Exclamation, "TSA")
                End Try
            End If

            limpiarcampos()

            Dim sqlusuario As String = " Select * From  Usuarios "

            Cargar_MySQLCliente(sqlusuario, DGUsuario)
        End If
    End Sub
End Class