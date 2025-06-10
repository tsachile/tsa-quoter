
'Libreria MySQL
Imports MySql.Data.MySqlClient
':::Libreria necesaria para usar MemoryStream
Imports System.IO
Module Conexiones
    '>>>> CONEXION EN LINEA A CPANEL MYSQL
    Dim con2 As New MySqlConnection("Server = 162.144.3.49; Database = tsachile_cotizador; Uid = tsachile_admin; Pwd = 17543593apple")
#Region "Filtros  MySQL"
    Sub Cargar_MySQL(ByVal Sql As String, ByVal Tabla As DataGridView)
        ':::Creamos nuestro objeto SQLiteDataAdapte, el cual recibe dos parametros
        ':::La conexion y la consulta SQL
        Dim Da As New MySqlDataAdapter(Sql, con2)
        ':::Creamos nuestro DataTable para almacenar el resultado
        Dim Dt As New DataTable
        ':::Llenamos nuestro DataTable con el resultado de la consulta
        Da.Fill(Dt)
        ':::Asignamos a nuestro DataGridView el DataTable para mostrar los registros
        Tabla.DataSource = Dt

    End Sub
    Sub Cargar_MySQL2(ByVal Sql2 As String, ByVal Tabla As DataGridView)
        ':::Creamos nuestro objeto SQLiteDataAdapte, el cual recibe dos parametros
        ':::La conexion y la consulta SQL
        Dim Da As New MySqlDataAdapter(Sql2, con2)
        ':::Creamos nuestro DataTable para almacenar el resultado
        Dim Dt As New DataTable
        ':::Llenamos nuestro DataTable con el resultado de la consulta
        Da.Fill(Dt)
        ':::Asignamos a nuestro DataGridView el DataTable para mostrar los registros
        Tabla.DataSource = Dt

    End Sub
    Sub Cargar_MySQL3(ByVal Sql3 As String, ByVal Tabla As DataGridView)
        ':::Creamos nuestro objeto SQLiteDataAdapte, el cual recibe dos parametros
        ':::La conexion y la consulta SQL
        Dim Da As New MySqlDataAdapter(Sql3, con2)
        ':::Creamos nuestro DataTable para almacenar el resultado
        Dim Dt As New DataTable
        ':::Llenamos nuestro DataTable con el resultado de la consulta
        Da.Fill(Dt)
        ':::Asignamos a nuestro DataGridView el DataTable para mostrar los registros
        Tabla.DataSource = Dt

    End Sub
    Sub Cargar_MySQL4(ByVal Sql4 As String, ByVal Tabla As DataGridView)
        ':::Creamos nuestro objeto SQLiteDataAdapte, el cual recibe dos parametros
        ':::La conexion y la consulta SQL
        Dim Da As New MySqlDataAdapter(Sql4, con2)
        ':::Creamos nuestro DataTable para almacenar el resultado
        Dim Dt As New DataTable
        ':::Llenamos nuestro DataTable con el resultado de la consulta
        Da.Fill(Dt)
        ':::Asignamos a nuestro DataGridView el DataTable para mostrar los registros
        Tabla.DataSource = Dt

    End Sub
    Sub Cargar_MySQL5(ByVal Sql5 As String, ByVal Tabla As DataGridView)
        ':::Creamos nuestro objeto SQLiteDataAdapte, el cual recibe dos parametros
        ':::La conexion y la consulta SQL
        Dim Da As New MySqlDataAdapter(Sql5, con2)
        ':::Creamos nuestro DataTable para almacenar el resultado
        Dim Dt As New DataTable
        ':::Llenamos nuestro DataTable con el resultado de la consulta
        Da.Fill(Dt)
        ':::Asignamos a nuestro DataGridView el DataTable para mostrar los registros
        Tabla.DataSource = Dt

    End Sub
    Sub Cargar_MySQLCliente(ByVal Sqlcliente As String, ByVal Tabla As DataGridView)
        ':::Creamos nuestro objeto SQLiteDataAdapte, el cual recibe dos parametros
        ':::La conexion y la consulta SQL
        Dim Da As New MySqlDataAdapter(Sqlcliente, con2)
        ':::Creamos nuestro DataTable para almacenar el resultado
        Dim Dt As New DataTable
        ':::Llenamos nuestro DataTable con el resultado de la consulta
        Da.Fill(Dt)
        ':::Asignamos a nuestro DataGridView el DataTable para mostrar los registros
        Tabla.DataSource = Dt

    End Sub
    Sub Cargar_MySQLCotizacion(ByVal Sqlcotizacion As String, ByVal Tabla As DataGridView)
        ':::Creamos nuestro objeto SQLiteDataAdapte, el cual recibe dos parametros
        ':::La conexion y la consulta SQL
        Dim Da As New MySqlDataAdapter(Sqlcotizacion, con2)
        ':::Creamos nuestro DataTable para almacenar el resultado
        Dim Dt As New DataTable
        ':::Llenamos nuestro DataTable con el resultado de la consulta
        Da.Fill(Dt)
        ':::Asignamos a nuestro DataGridView el DataTable para mostrar los registros
        Tabla.DataSource = Dt
    End Sub

    Sub Cargar_MySQLUsuario(ByVal SqlUsuario As String, ByVal Tabla As DataGridView)
        ':::Creamos nuestro objeto SQLiteDataAdapte, el cual recibe dos parametros
        ':::La conexion y la consulta SQL
        Dim Da As New MySqlDataAdapter(SqlUsuario, con2)
        ':::Creamos nuestro DataTable para almacenar el resultado
        Dim Dt As New DataTable
        ':::Llenamos nuestro DataTable con el resultado de la consulta
        Da.Fill(Dt)
        ':::Asignamos a nuestro DataGridView el DataTable para mostrar los registros
        Tabla.DataSource = Dt
    End Sub
    Sub Cargar_MySQLseguimiento(ByVal Sqlseguimiento As String, ByVal Tabla As DataGridView)
        ':::Creamos nuestro objeto SQLiteDataAdapte, el cual recibe dos parametros
        ':::La conexion y la consulta SQL
        Dim Da As New MySqlDataAdapter(Sqlseguimiento, con2)
        ':::Creamos nuestro DataTable para almacenar el resultado
        Dim Dt As New DataTable
        ':::Llenamos nuestro DataTable con el resultado de la consulta
        Da.Fill(Dt)
        ':::Asignamos a nuestro DataGridView el DataTable para mostrar los registros
        Tabla.DataSource = Dt
    End Sub
    Sub Cargar_MySQLEdicion(ByVal SqlEdicion As String, ByVal Tabla As DataGridView)
        ':::Creamos nuestro objeto SQLiteDataAdapte, el cual recibe dos parametros
        ':::La conexion y la consulta SQL
        Dim Da As New MySqlDataAdapter(SqlEdicion, con2)
        ':::Creamos nuestro DataTable para almacenar el resultado
        Dim Dt As New DataTable
        ':::Llenamos nuestro DataTable con el resultado de la consulta
        Da.Fill(Dt)
        ':::Asignamos a nuestro DataGridView el DataTable para mostrar los registros
        Tabla.DataSource = Dt
    End Sub
    Sub Cargar_MySQLszAMB(ByVal SqlszAMB As String, ByVal Tabla As DataGridView)
        ':::Creamos nuestro objeto SQLiteDataAdapte, el cual recibe dos parametros
        ':::La conexion y la consulta SQL
        Dim Da As New MySqlDataAdapter(SqlszAMB, con2)
        ':::Creamos nuestro DataTable para almacenar el resultado
        Dim Dt As New DataTable
        ':::Llenamos nuestro DataTable con el resultado de la consulta
        Da.Fill(Dt)
        ':::Asignamos a nuestro DataGridView el DataTable para mostrar los registros
        Tabla.DataSource = Dt
    End Sub
    Sub Cargar_MySQLDEF(ByVal SqlDEF As String, ByVal Tabla As DataGridView)
        ':::Creamos nuestro objeto SQLiteDataAdapte, el cual recibe dos parametros
        ':::La conexion y la consulta SQL
        Dim Da As New MySqlDataAdapter(SqlDEF, con2)
        ':::Creamos nuestro DataTable para almacenar el resultado
        Dim Dt As New DataTable
        ':::Llenamos nuestro DataTable con el resultado de la consulta
        Da.Fill(Dt)
        ':::Asignamos a nuestro DataGridView el DataTable para mostrar los registros
        Tabla.DataSource = Dt
    End Sub
    Sub Cargar_MySQLIMG(ByVal SqlIMG As String, ByVal Tabla As DataGridView)
        ':::Creamos nuestro objeto SQLiteDataAdapte, el cual recibe dos parametros
        ':::La conexion y la consulta SQL
        Dim Da As New MySqlDataAdapter(SqlIMG, con2)
        ':::Creamos nuestro DataTable para almacenar el resultado
        Dim Dt As New DataTable
        ':::Llenamos nuestro DataTable con el resultado de la consulta
        Da.Fill(Dt)
        ':::Asignamos a nuestro DataGridView el DataTable para mostrar los registros
        Tabla.DataSource = Dt
    End Sub

    ':::Procedimiento para agregar, modificar y eliminar en MySQL
    Sub Operaciones_MySQL(ByVal sql As String, ByVal imagen As PictureBox)
        ':::Creamos una variable de tipo MemoryStram
        Dim MS As New MemoryStream
        ':::Guardamos en la variable MS el contenido del PictureBox
        imagen.Image.Save(MS, imagen.Image.RawFormat)
        ':::Pasamos a Byte nuestra imagen
        Dim Imagenes() As Byte = MS.GetBuffer

        ':::Declaramos nuestro objeto de tipo SQLiteCommand para ejecutar la consulta
        Dim cmd As New MySqlCommand(sql, con2)
        ':::Agregamos el parametro de nuestra varible imagenes que es de tipo Byte
        cmd.Parameters.AddWithValue("@imagen", Imagenes)
        Try
            ':::Abrimos nuestra conexion
            con2.Open()
            ':::Ejecutamos la consulta
            cmd.ExecuteNonQuery()
            ':::Cerramos nuestra conexion
            con2.Close()
            MsgBox("Operación realizada con exito", MsgBoxStyle.Information, "TSA")
        Catch ex As Exception
            MsgBox("No se pueden guardar los registro por: " & ex.Message, MsgBoxStyle.Critical, "TSA")
        End Try
    End Sub


#End Region
End Module
