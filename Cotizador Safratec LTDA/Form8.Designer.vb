<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form8
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form8))
        Me.Panelseg1 = New System.Windows.Forms.Panel()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DGSeguimiento2 = New System.Windows.Forms.DataGridView()
        Me.TxtFecha = New System.Windows.Forms.TextBox()
        Me.TxtCotizacion = New System.Windows.Forms.TextBox()
        Me.DGSeguimiento = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DGEdicion = New System.Windows.Forms.DataGridView()
        Me.TextBoxBusqueda = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panelseg1.SuspendLayout()
        CType(Me.DGSeguimiento2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGSeguimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.DGEdicion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panelseg1
        '
        Me.Panelseg1.Controls.Add(Me.DateTimePicker2)
        Me.Panelseg1.Controls.Add(Me.Label4)
        Me.Panelseg1.Controls.Add(Me.Label3)
        Me.Panelseg1.Controls.Add(Me.DGSeguimiento2)
        Me.Panelseg1.Controls.Add(Me.TxtFecha)
        Me.Panelseg1.Controls.Add(Me.TxtCotizacion)
        Me.Panelseg1.Controls.Add(Me.DGSeguimiento)
        Me.Panelseg1.Controls.Add(Me.Label2)
        Me.Panelseg1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panelseg1.Location = New System.Drawing.Point(0, 0)
        Me.Panelseg1.Name = "Panelseg1"
        Me.Panelseg1.Size = New System.Drawing.Size(1130, 263)
        Me.Panelseg1.TabIndex = 0
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(935, 5)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(93, 20)
        Me.DateTimePicker2.TabIndex = 43
        Me.DateTimePicker2.Value = New Date(2023, 8, 17, 0, 0, 0, 0)
        Me.DateTimePicker2.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(977, 233)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "# Cotizaciones"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Blue
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(1060, 230)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 24)
        Me.Label3.TabIndex = 39
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DGSeguimiento2
        '
        Me.DGSeguimiento2.AllowUserToAddRows = False
        Me.DGSeguimiento2.AllowUserToDeleteRows = False
        Me.DGSeguimiento2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGSeguimiento2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGSeguimiento2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGSeguimiento2.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DGSeguimiento2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGSeguimiento2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DGSeguimiento2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGSeguimiento2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGSeguimiento2.ColumnHeadersHeight = 25
        Me.DGSeguimiento2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGSeguimiento2.EnableHeadersVisualStyles = False
        Me.DGSeguimiento2.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGSeguimiento2.Location = New System.Drawing.Point(900, 88)
        Me.DGSeguimiento2.Name = "DGSeguimiento2"
        Me.DGSeguimiento2.ReadOnly = True
        Me.DGSeguimiento2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGSeguimiento2.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGSeguimiento2.RowHeadersVisible = False
        Me.DGSeguimiento2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGSeguimiento2.Size = New System.Drawing.Size(163, 105)
        Me.DGSeguimiento2.TabIndex = 38
        Me.DGSeguimiento2.Visible = False
        '
        'TxtFecha
        '
        Me.TxtFecha.Location = New System.Drawing.Point(928, 62)
        Me.TxtFecha.Name = "TxtFecha"
        Me.TxtFecha.Size = New System.Drawing.Size(100, 20)
        Me.TxtFecha.TabIndex = 37
        Me.TxtFecha.Visible = False
        '
        'TxtCotizacion
        '
        Me.TxtCotizacion.Location = New System.Drawing.Point(928, 36)
        Me.TxtCotizacion.Name = "TxtCotizacion"
        Me.TxtCotizacion.Size = New System.Drawing.Size(100, 20)
        Me.TxtCotizacion.TabIndex = 36
        Me.TxtCotizacion.Visible = False
        '
        'DGSeguimiento
        '
        Me.DGSeguimiento.AllowUserToAddRows = False
        Me.DGSeguimiento.AllowUserToDeleteRows = False
        Me.DGSeguimiento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGSeguimiento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGSeguimiento.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGSeguimiento.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DGSeguimiento.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGSeguimiento.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DGSeguimiento.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGSeguimiento.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGSeguimiento.ColumnHeadersHeight = 25
        Me.DGSeguimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGSeguimiento.EnableHeadersVisualStyles = False
        Me.DGSeguimiento.GridColor = System.Drawing.Color.Teal
        Me.DGSeguimiento.Location = New System.Drawing.Point(313, 36)
        Me.DGSeguimiento.Name = "DGSeguimiento"
        Me.DGSeguimiento.ReadOnly = True
        Me.DGSeguimiento.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGSeguimiento.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGSeguimiento.RowHeadersVisible = False
        Me.DGSeguimiento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGSeguimiento.Size = New System.Drawing.Size(188, 144)
        Me.DGSeguimiento.TabIndex = 35
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Seguimiento de Cotizacion"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.DGEdicion)
        Me.Panel1.Controls.Add(Me.TextBoxBusqueda)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 286)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 227)
        Me.Panel1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "N° Cotizacion, Fecha, Atencion"
        '
        'DGEdicion
        '
        Me.DGEdicion.AllowUserToAddRows = False
        Me.DGEdicion.AllowUserToDeleteRows = False
        Me.DGEdicion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGEdicion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGEdicion.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DGEdicion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGEdicion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DGEdicion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGEdicion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DGEdicion.ColumnHeadersHeight = 25
        Me.DGEdicion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGEdicion.EnableHeadersVisualStyles = False
        Me.DGEdicion.GridColor = System.Drawing.Color.Teal
        Me.DGEdicion.Location = New System.Drawing.Point(313, 40)
        Me.DGEdicion.Name = "DGEdicion"
        Me.DGEdicion.ReadOnly = True
        Me.DGEdicion.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGEdicion.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DGEdicion.RowHeadersVisible = False
        Me.DGEdicion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGEdicion.Size = New System.Drawing.Size(315, 125)
        Me.DGEdicion.TabIndex = 36
        '
        'TextBoxBusqueda
        '
        Me.TextBoxBusqueda.ForeColor = System.Drawing.Color.LightSlateGray
        Me.TextBoxBusqueda.Location = New System.Drawing.Point(12, 18)
        Me.TextBoxBusqueda.Name = "TextBoxBusqueda"
        Me.TextBoxBusqueda.Size = New System.Drawing.Size(183, 20)
        Me.TextBoxBusqueda.TabIndex = 1
        Me.TextBoxBusqueda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(0, 263)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(1130, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "     Edicion"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Form8
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1130, 646)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Panelseg1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form8"
        Me.Text = "Seguimiento de Cotizacion"
        Me.Panelseg1.ResumeLayout(False)
        Me.Panelseg1.PerformLayout()
        CType(Me.DGSeguimiento2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGSeguimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DGEdicion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panelseg1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TextBoxBusqueda As TextBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents DGSeguimiento As DataGridView
    Friend WithEvents DGEdicion As DataGridView
    Friend WithEvents TxtFecha As TextBox
    Friend WithEvents TxtCotizacion As TextBox
    Friend WithEvents DGSeguimiento2 As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Button2 As Button
    Friend WithEvents Label1 As Label
End Class
