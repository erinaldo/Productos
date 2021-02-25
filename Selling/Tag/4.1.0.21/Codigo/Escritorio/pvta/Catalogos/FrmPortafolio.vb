Public Class FrmPortafolio
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents BtnElimina As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GrpModificador As System.Windows.Forms.GroupBox
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents BtnNuevo As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtCompany As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPortafolio))
        Me.GrpModificador = New System.Windows.Forms.GroupBox
        Me.TxtCompany = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.LblNombre = New System.Windows.Forms.Label
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.LblClave = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GrpDetalle = New System.Windows.Forms.GroupBox
        Me.BtnNuevo = New Janus.Windows.EditControls.UIButton
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX
        Me.BtnElimina = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.GrpModificador.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpModificador
        '
        Me.GrpModificador.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpModificador.Controls.Add(Me.TxtCompany)
        Me.GrpModificador.Controls.Add(Me.Label16)
        Me.GrpModificador.Controls.Add(Me.PictureBox1)
        Me.GrpModificador.Controls.Add(Me.ChkEstado)
        Me.GrpModificador.Controls.Add(Me.PictureBox2)
        Me.GrpModificador.Controls.Add(Me.TxtNombre)
        Me.GrpModificador.Controls.Add(Me.LblNombre)
        Me.GrpModificador.Controls.Add(Me.TxtClave)
        Me.GrpModificador.Controls.Add(Me.LblClave)
        Me.GrpModificador.Controls.Add(Me.Label4)
        Me.GrpModificador.Location = New System.Drawing.Point(5, 7)
        Me.GrpModificador.Name = "GrpModificador"
        Me.GrpModificador.Size = New System.Drawing.Size(780, 100)
        Me.GrpModificador.TabIndex = 1
        Me.GrpModificador.TabStop = False
        Me.GrpModificador.Text = "Modificador de Portafolio"
        '
        'TxtCompany
        '
        Me.TxtCompany.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCompany.Enabled = False
        Me.TxtCompany.Location = New System.Drawing.Point(98, 19)
        Me.TxtCompany.Name = "TxtCompany"
        Me.TxtCompany.ReadOnly = True
        Me.TxtCompany.Size = New System.Drawing.Size(529, 20)
        Me.TxtCompany.TabIndex = 137
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(13, 22)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(80, 15)
        Me.Label16.TabIndex = 136
        Me.Label16.Text = "Compañia"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(394, 46)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'ChkEstado
        '
        Me.ChkEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(639, 18)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(72, 22)
        Me.ChkEstado.TabIndex = 56
        Me.ChkEstado.Text = "Activo"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(632, 77)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 29
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'TxtNombre
        '
        Me.TxtNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNombre.Location = New System.Drawing.Point(98, 72)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(529, 20)
        Me.TxtNombre.TabIndex = 2
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(13, 75)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(80, 15)
        Me.LblNombre.TabIndex = 26
        Me.LblNombre.Text = "Descripción"
        '
        'TxtClave
        '
        Me.TxtClave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtClave.Location = New System.Drawing.Point(98, 45)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(291, 20)
        Me.TxtClave.TabIndex = 1
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(13, 48)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 15)
        Me.LblClave.TabIndex = 24
        Me.LblClave.Text = "Clave"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(412, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 15)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Max. 20 Caracteres"
        '
        'GrpDetalle
        '
        Me.GrpDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDetalle.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpDetalle.Controls.Add(Me.BtnNuevo)
        Me.GrpDetalle.Controls.Add(Me.GridDetalle)
        Me.GrpDetalle.Controls.Add(Me.BtnElimina)
        Me.GrpDetalle.Location = New System.Drawing.Point(5, 112)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(780, 365)
        Me.GrpDetalle.TabIndex = 2
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "Productos"
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnNuevo.Image = CType(resources.GetObject("BtnNuevo.Image"), System.Drawing.Image)
        Me.BtnNuevo.Location = New System.Drawing.Point(684, 15)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(90, 30)
        Me.BtnNuevo.TabIndex = 2
        Me.BtnNuevo.Text = "&Agregar"
        Me.BtnNuevo.ToolTipText = "Agrega productos al portafolio"
        Me.BtnNuevo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridDetalle
        '
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.Location = New System.Drawing.Point(7, 15)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(671, 342)
        Me.GridDetalle.TabIndex = 1
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnElimina
        '
        Me.BtnElimina.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnElimina.Image = CType(resources.GetObject("BtnElimina.Image"), System.Drawing.Image)
        Me.BtnElimina.Location = New System.Drawing.Point(684, 51)
        Me.BtnElimina.Name = "BtnElimina"
        Me.BtnElimina.Size = New System.Drawing.Size(90, 30)
        Me.BtnElimina.TabIndex = 4
        Me.BtnElimina.Text = "&Remover"
        Me.BtnElimina.ToolTipText = "Remueve detalle seleccionado"
        Me.BtnElimina.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(695, 483)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 8
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(598, 483)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 9
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmPortafolio
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 526)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpModificador)
        Me.Controls.Add(Me.GrpDetalle)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmPortafolio"
        Me.Text = "Portafolio"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpModificador.ResumeLayout(False)
        Me.GrpModificador.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDetalle.ResumeLayout(False)
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String

    Public PORClave As String
    Public Clave As String
    Public Descripcion As String
    Public Estado As Integer = 1

    Private sClave As String = ""
    Private iBaja As Integer

    Private alerta(1) As PictureBox
    Private reloj As parpadea
    Private bCargado As Boolean = False

    Private dtDetalle As DataTable


#Region "Metodos Internos"

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.TxtClave.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtClave.Text.Length > 20 Then
            Me.TxtClave.Text = Me.TxtClave.Text.Substring(0, 20)
        End If

        If Me.TxtNombre.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtNombre.Text.Length > 50 Then
            Me.TxtNombre.Text = Me.TxtNombre.Text.Substring(0, 50)

        End If


        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_pk", "@tabla", "Portafolio", "@Clave", UCase(Trim(Me.TxtClave.Text)), "@COMClave", ModPOS.CompanyActual) > 0 Then
                Beep()
                MessageBox.Show("La Clave que intenta agregar ya existe en el sistema para otro modificador de producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                reloj = New parpadea(Me.alerta(0))
                reloj.Enabled = True
                reloj.Start()
                Return False
            Else
                While i < Me.alerta.Length
                    Me.alerta(i).Visible = False
                    i += 1
                End While
                Return True
            End If
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function

  
    Private Sub Reinicializa()
        PORClave = ModPOS.obtenerLlave
        Clave = ""
        Descripcion = ""
        Estado = 1

        TxtClave.Text = ""
        TxtNombre.Text = ""
        ChkEstado.Estado = Estado

        dtDetalle = ModPOS.CrearTabla("Modificador", _
                "DMDClave", "System.String", _
                "Orden", "System.Int32", _
                "Descripción", "System.String", _
                "Estado", "System.String", _
                "iEstado", "System.Int32", _
                "Nuevo", "System.Int32", _
                "Update", "System.Int32", _
                "Baja", "System.Int32")

        GridDetalle.DataSource = dtDetalle
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("DMDClave").Visible = False
        GridDetalle.RootTable.Columns("iEstado").Visible = False
        GridDetalle.RootTable.Columns("Nuevo").Visible = False
        GridDetalle.RootTable.Columns("Update").Visible = False
        GridDetalle.RootTable.Columns("Baja").Visible = False

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridDetalle.RootTable.FormatConditions.Add(fc)

    End Sub

    Public Sub AddNuevoProducto(ByVal sPROClave As String, ByVal sClave As String, ByVal sNombre As String, ByVal dCantidad As Double)

        Dim foundRows() As Data.DataRow
        foundRows = dtDetalle.Select("Clave = '" & Clave & "'")

        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtDetalle.NewRow()
            'declara el nombre de la fila

            Dim iOrden As Integer

            If IsNumeric(dtDetalle.Compute("MAX(Orden)", "")) Then
                iOrden = dtDetalle.Compute("MAX(Orden)", "") + 1
            Else
                iOrden = 1
            End If

            row1.Item("DPOClave") = ModPOS.obtenerLlave
            row1.Item("PROClave") = sPROClave
            row1.Item("Orden") = iOrden
            row1.Item("Cantidad") = dCantidad
            row1.Item("Clave") = sClave
            row1.Item("Nombre") = sNombre
            row1.Item("Nuevo") = 1
            row1.Item("Update") = 0
            row1.Item("Baja") = 0
            dtDetalle.Rows.Add(row1)
            'agrega la fila completo a la tabla
        Else
            MessageBox.Show("El producto que intenta agregar ya existe para el portafolio actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub



#End Region


    Private Sub FrmPortafolio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor


        Me.TxtCompany.Text = ModPOS.CompanyName

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2

        Dim Cnx As String

        Cnx = ModPOS.BDConexion


        Me.TxtClave.Text = Clave
        TxtNombre.Text = Descripcion
        ChkEstado.Estado = Estado

        If Padre = "Agregar" Then

            PORClave = ModPOS.obtenerLlave
            dtDetalle = ModPOS.CrearTabla("Modificador", _
                    "DPOClave", "System.String", _
                    "PROClave", "System.String", _
                    "Orden", "System.Int32", _
                    "Cantidad", "System.Double", _
                    "Clave", "System.String", _
                    "Nombre", "System.String", _
                    "Nuevo", "System.Int32", _
                    "Update", "System.Int32", _
                    "Baja", "System.Int32")
        Else
            dtDetalle = ModPOS.Recupera_Tabla("sp_muestra_portafoliodetalle", "@PORClave", PORClave)
        End If

        GridDetalle.DataSource = dtDetalle
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("DPOClave").Visible = False
        GridDetalle.RootTable.Columns("PROClave").Visible = False
        GridDetalle.RootTable.Columns("Nuevo").Visible = False
        GridDetalle.RootTable.Columns("Update").Visible = False
        GridDetalle.RootTable.Columns("Baja").Visible = False
        GridDetalle.RootTable.Columns("Clave").Selectable = False
        GridDetalle.RootTable.Columns("Nombre").Selectable = False

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridDetalle.RootTable.FormatConditions.Add(fc)


        bCargado = True


        Cursor.Current = Cursors.Default

    End Sub

    Private Sub FrmPortafolio_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not ModPOS.MtoPortafolio Is Nothing Then
            ModPOS.MtoPortafolio.ActGrid()
        End If
        ModPOS.Portafolio.Dispose()
        ModPOS.Portafolio = Nothing
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        If ModPOS.AddPortafolio Is Nothing Then
            ModPOS.AddPortafolio = New FrmAddPortafolio
            With ModPOS.AddPortafolio
                .StartPosition = FormStartPosition.CenterScreen
            End With
        End If
        ModPOS.AddPortafolio.StartPosition = FormStartPosition.CenterScreen
        ModPOS.AddPortafolio.Show()
        ModPOS.AddPortafolio.BringToFront()
    End Sub


    Private Sub BtnElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnElimina.Click
        If sClave <> "" Then
            Beep()
            Select Case MessageBox.Show("Se removera el producto: " & sClave & " del portafolio Actual", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtDetalle.Select("Clave = '" & sClave & "'")

                    If foundRows.Length <> 0 Then
                        foundRows(0)("Baja") = 1
                    End If
            End Select
        End If
    End Sub

    Private Sub GridDetalle_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridDetalle.CellEdited
        If GridDetalle.CurrentColumn.Caption = "Orden" Then
            If IsNumeric(GridDetalle.GetValue("Orden")) AndAlso GridDetalle.GetValue("Orden") > 0 Then
                GridDetalle.SetValue("Update", 1)
            Else
                GridDetalle.SetValue("Orden", 1)
            End If
        End If

        If GridDetalle.CurrentColumn.Caption = "Cantidad" Then
            If IsNumeric(GridDetalle.GetValue("Cantidad")) AndAlso GridDetalle.GetValue("Cantidad") > 0 Then
                GridDetalle.SetValue("Update", 1)
            Else
                GridDetalle.SetValue("Cantidad", 1)
            End If
        End If
    End Sub

    Private Sub GridDetalle_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridDetalle.SelectionChanged
        If Not Me.GridDetalle.GetValue(0) Is Nothing Then
            Me.BtnElimina.Enabled = True
            Me.iBaja = GridDetalle.GetValue("Baja")
            Me.sClave = GridDetalle.GetValue("Clave")
        Else
            Me.iBaja = -1
            Me.sClave = ""
            Me.BtnElimina.Enabled = False
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub


    Private Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            Dim foundRows() As System.Data.DataRow

            Select Case Me.Padre
                Case "Agregar"

                    Clave = UCase(Trim(Me.TxtClave.Text))
                    Descripcion = Trim(Me.TxtNombre.Text)
                    Estado = ChkEstado.GetEstado

                    ModPOS.Ejecuta("sp_inserta_portafolio", _
                    "@PORClave", PORClave, _
                    "@Clave", Clave, _
                    "@Descripcion", Descripcion, _
                    "@COMClave", ModPOS.CompanyActual, _
                    "@Usuario", ModPOS.UsuarioActual)


                    foundRows = dtDetalle.Select(" Nuevo = 1 and Baja = 0 ")

                    If foundRows.Length <> 0 Then

                        Dim z As Integer

                        For z = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("sp_inserta_portafoliodet", _
                            "@DPOClave", foundRows(z)("DPOClave"), _
                            "@PORClave", PORClave, _
                            "@PROClave", foundRows(z)("PROClave"), _
                            "@Cantidad", foundRows(z)("Cantidad"), _
                            "@Orden", foundRows(z)("Orden"), _
                            "@Usuario", ModPOS.UsuarioActual)

                        Next
                    End If


                    foundRows = dtDetalle.Select(" Nuevo = 0 and Update=1 and Baja=0")

                    If foundRows.Length <> 0 Then

                        Dim z As Integer

                        For z = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("sp_actualiza_portafoliodet", _
                            "@DPOClave", foundRows(z)("DPOClave"), _
                            "@PORClave", PORClave, _
                            "@Cantidad", foundRows(z)("Cantidad"), _
                            "@Orden", foundRows(z)("Orden"), _
                            "@Usuario", ModPOS.UsuarioActual)

                        Next
                    End If


                    foundRows = dtDetalle.Select(" Nuevo = 0 and Baja= 1")

                    If foundRows.Length <> 0 Then

                        Dim z As Integer

                        For z = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("sp_elimina_portafoliodet", _
                            "@DPOClave", foundRows(z)("DPOClave"), _
                            "@PORClave", PORClave)

                        Next
                    End If

                    Reinicializa()


                Case "Modificar"
                    If Not (Descripcion = UCase(Trim(Me.TxtNombre.Text)) AndAlso Estado = ChkEstado.GetEstado) Then

                        Me.Descripcion = UCase(Trim(Me.TxtNombre.Text))
                        Me.Estado = Me.ChkEstado.GetEstado


                        ModPOS.Ejecuta("sp_actualiza_portafolio", _
                        "@PORClave", PORClave, _
                        "@Estado", Estado, _
                        "@Descripcion", Descripcion, _
                        "@Usuario", ModPOS.UsuarioActual, _
                        "@COMClave", ModPOS.CompanyActual)

                    End If

                    foundRows = dtDetalle.Select(" Nuevo = 1 and Baja = 0 ")

                    If foundRows.Length <> 0 Then

                        Dim z As Integer

                        For z = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("sp_inserta_portafoliodet", _
                            "@DPOClave", foundRows(z)("DPOClave"), _
                            "@PORClave", PORClave, _
                            "@PROClave", foundRows(z)("PROClave"), _
                            "@Cantidad", foundRows(z)("Cantidad"), _
                            "@Orden", foundRows(z)("Orden"), _
                            "@Usuario", ModPOS.UsuarioActual)

                        Next
                    End If


                    foundRows = dtDetalle.Select(" Nuevo = 0 and Update=1 and Baja=0")

                    If foundRows.Length <> 0 Then

                        Dim z As Integer

                        For z = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("sp_actualiza_portafoliodet", _
                          "@DPOClave", foundRows(z)("DPOClave"), _
                          "@PORClave", PORClave, _
                          "@Cantidad", foundRows(z)("Cantidad"), _
                          "@Orden", foundRows(z)("Orden"), _
                          "@Usuario", ModPOS.UsuarioActual)

                        Next
                    End If


                    foundRows = dtDetalle.Select(" Nuevo = 0 and Baja= 1")

                    If foundRows.Length <> 0 Then

                        Dim z As Integer

                        For z = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("sp_elimina_portafoliodet", _
                             "@DPOClave", foundRows(z)("DPOClave"), _
                             "@PORClave", PORClave)


                        Next
                    End If

                    Me.Close()

            End Select

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
