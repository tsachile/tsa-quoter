Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Windows.Forms

Public Class Form22
    Public conex As New MySqlConnection("Server = 162.144.3.49; Database = tsachile_cotizador; Uid = tsachile_admin; Pwd = 17543593apple")

    Private Sub Form22_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql2 As String = " Select * From TSADATACRUCES "
        Cargar_MySQL2(sql2, DataGridCruces)

    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs)
        Me.Close()

    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim filtro As String = TextBox1.Text.Trim()

        If filtro.Length > 0 Then
            ' Consulta para la tabla TSADATAIMAGEN
            Dim sqlImagen As String = "SELECT * FROM TSADATAIMAGEN WHERE Descripcion_TSA LIKE '%" & filtro & "%' OR Codigo_TSA LIKE '%" & filtro & "%'"
            Cargar_MySQL2(sqlImagen, DGImagen)

            ' Consulta para la tabla TSADATACRUCES
            Dim sqlCruces As String = "SELECT * FROM TSADATACRUCES WHERE Descripcion LIKE '%" & filtro & "%' OR Codigo LIKE '%" & filtro & "%'"
            Cargar_MySQL2(sqlCruces, DataGridCruces)
        End If
    End Sub



    Private Sub DataGridCruces_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridCruces.CellContentClick
        On Error Resume Next
        Dim fila As Integer
        fila = DataGridCruces.CurrentRow.Index

        TextBox1.Text = Me.DataGridCruces.Item(1, fila).Value 'Descripcion TSA
        TextBox5.Text = Me.DataGridCruces.Item(1, fila).Value 'Descripcion TSA
        TextBox6.Text = Me.DataGridCruces.Item(0, fila).Value 'Codigo TSA
        TextBox7.Text = Me.DataGridCruces.Item(5, fila).Value 'Descripcion GSI
        TextBox8.Text = Me.DataGridCruces.Item(2, fila).Value 'Codigo Gsi OLD
        TextBox9.Text = Me.DataGridCruces.Item(3, fila).Value 'Codigo Gsi Med
        TextBox10.Text = Me.DataGridCruces.Item(4, fila).Value 'Codigo Gsi 
    End Sub
#Region "Imagenes"
    Private Sub PtbImagen_Click(sender As Object, e As EventArgs) Handles PtbImagen.Click
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Title = "Seleccione una imagen"
            openFileDialog.Filter = "Imagenes JPG|*.jpg|Imagenes JPEG|*.jpeg|Imagenes PNG|*.png"

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                PtbImagen.ImageLocation = openFileDialog.FileName
                PtbImagen.SizeMode = PictureBoxSizeMode.StretchImage
            End If
        End Using
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim DESCRIPTSA As String = TextBox5.Text
        Dim CODTSA As String = TextBox6.Text
        Dim DESCRIPGSI As String = TextBox7.Text
        Dim CODGSIOLD As String = TextBox8.Text
        Dim CODGSIMED As String = TextBox9.Text
        Dim CODGSI As String = TextBox10.Text
        Dim img As Image = PtbImagen.Image

        Try
            Using conn As New MySqlConnection("Server = 162.144.3.49; Database = tsachile_cotizador; Uid = tsachile_admin; Pwd = 17543593apple")
                conn.Open()
                Dim sql As String = "INSERT INTO TSADATAIMAGEN (Descripcion_TSA, Codigo_TSA, Descripcion_GSI, Codigo_GSI_OLD, Codigo_GSI_MEDIUM, Codigo_GSI, IMAGEN) " &
                            "VALUES ('" & DESCRIPTSA & "', '" & CODTSA & "', '" & DESCRIPGSI & "', '" & CODGSIOLD & "', '" & CODGSIMED & "', '" & CODGSI & "', "

                If img IsNot Nothing Then
                    Dim ms As New MemoryStream()
                    img.Save(ms, img.RawFormat)
                    Dim imgData As Byte() = ms.ToArray()
                    Dim hexImage As String = BitConverter.ToString(imgData).Replace("-", "") ' Convertir a hexadecimal

                    sql &= "0x" & hexImage & ")" ' Almacenar como BLOB hexadecimal
                Else
                    sql &= "NULL)"
                End If

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Imagen guardada correctamente en la base de datos.")
        Catch ex As Exception
            MessageBox.Show("Error al guardar la imagen: " & ex.Message)
        End Try

    End Sub


    'Private Sub DGImagen_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DGImagen.DataError
    ' Manejar el error de datos en la DataGridView
    ' e.ThrowException = False
    ' e.Cancel = False
    '  End Sub

#End Region
End Class