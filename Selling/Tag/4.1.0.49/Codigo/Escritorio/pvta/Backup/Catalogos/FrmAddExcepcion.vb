Public Class FrmAddExcepcion
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
    Friend WithEvents GrpDescuento As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbTipoSector As Selling.StoreCombo
    Friend WithEvents LblUnidadVenta As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbDescuento As Selling.StoreCombo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GridExcepcion As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnAdd As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnDel As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddExcepcion))
        Me.GrpDescuento = New System.Windows.Forms.GroupBox
        Me.btnAdd = New Janus.Windows.EditControls.UIButton
        Me.BtnDel = New Janus.Windows.EditControls.UIButton
        Me.GridExcepcion = New Janus.Windows.GridEX.GridEX
        Me.cmbDescuento = New Selling.StoreCombo
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.cmbTipoSector = New Selling.StoreCombo
        Me.LblUnidadVenta = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.GrpDescuento.SuspendLayout()
        CType(Me.GridExcepcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpDescuento
        '
        Me.GrpDescuento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDescuento.Controls.Add(Me.btnAdd)
        Me.GrpDescuento.Controls.Add(Me.BtnDel)
        Me.GrpDescuento.Controls.Add(Me.GridExcepcion)
        Me.GrpDescuento.Controls.Add(Me.cmbDescuento)
        Me.GrpDescuento.Controls.Add(Me.PictureBox1)
        Me.GrpDescuento.Controls.Add(Me.PictureBox2)
        Me.GrpDescuento.Controls.Add(Me.cmbTipoSector)
        Me.GrpDescuento.Controls.Add(Me.LblUnidadVenta)
        Me.GrpDescuento.Controls.Add(Me.Label5)
        Me.GrpDescuento.Location = New System.Drawing.Point(7, 7)
        Me.GrpDescuento.Name = "GrpDescuento"
        Me.GrpDescuento.Size = New System.Drawing.Size(650, 307)
        Me.GrpDescuento.TabIndex = 0
        Me.GrpDescuento.TabStop = False
        Me.GrpDescuento.Text = "Excepción"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(518, 10)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(59, 30)
        Me.btnAdd.TabIndex = 103
        Me.btnAdd.ToolTipText = "Agrega nuevo excepción"
        Me.btnAdd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnDel
        '
        Me.BtnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDel.Image = CType(resources.GetObject("BtnDel.Image"), System.Drawing.Image)
        Me.BtnDel.Location = New System.Drawing.Point(583, 10)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(59, 30)
        Me.BtnDel.TabIndex = 104
        Me.BtnDel.ToolTipText = "Elimina la excepción seleccionada"
        Me.BtnDel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridExcepcion
        '
        Me.GridExcepcion.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridExcepcion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridExcepcion.ColumnAutoResize = True
        Me.GridExcepcion.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridExcepcion.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridExcepcion.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridExcepcion.Location = New System.Drawing.Point(5, 43)
        Me.GridExcepcion.Name = "GridExcepcion"
        Me.GridExcepcion.RecordNavigator = True
        Me.GridExcepcion.Size = New System.Drawing.Size(637, 258)
        Me.GridExcepcion.TabIndex = 102
        Me.GridExcepcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbDescuento
        '
        Me.cmbDescuento.Location = New System.Drawing.Point(388, 17)
        Me.cmbDescuento.Name = "cmbDescuento"
        Me.cmbDescuento.Size = New System.Drawing.Size(120, 21)
        Me.cmbDescuento.TabIndex = 100
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(54, 21)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 90
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(357, 22)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.TabIndex = 89
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'cmbTipoSector
        '
        Me.cmbTipoSector.Location = New System.Drawing.Point(76, 19)
        Me.cmbTipoSector.Name = "cmbTipoSector"
        Me.cmbTipoSector.Size = New System.Drawing.Size(241, 21)
        Me.cmbTipoSector.TabIndex = 84
        '
        'LblUnidadVenta
        '
        Me.LblUnidadVenta.Location = New System.Drawing.Point(6, 22)
        Me.LblUnidadVenta.Name = "LblUnidadVenta"
        Me.LblUnidadVenta.Size = New System.Drawing.Size(76, 15)
        Me.LblUnidadVenta.TabIndex = 86
        Me.LblUnidadVenta.Text = "Tipo Sector"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(323, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 15)
        Me.Label5.TabIndex = 101
        Me.Label5.Text = "Descuento"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(471, 320)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 2
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnAgregar.Icon = CType(resources.GetObject("BtnAgregar.Icon"), System.Drawing.Icon)
        Me.BtnAgregar.Location = New System.Drawing.Point(567, 320)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 1
        Me.BtnAgregar.Text = "&Aceptar"
        Me.BtnAgregar.ToolTipText = "Guardar cambios"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmAddExcepcion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(661, 361)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpDescuento)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(677, 400)
        Me.Name = "FrmAddExcepcion"
        Me.Text = "Excepción de descuento por sector"
        Me.GrpDescuento.ResumeLayout(False)
        CType(Me.GridExcepcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public TipoDescuento As Integer '1:Directo 2:PostVenta

    Public dtDescuento As DataTable

    Private alerta(1) As PictureBox
    Private reloj As parpadea

    Private Sub FrmAddExcepcion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        

        With Me.cmbTipoSector
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sector"
            .NombreParametro1 = "COMClave"
            .Parametro1 = ModPOS.CompanyActual
            .llenar()
        End With

        With Me.cmbDescuento
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            If TipoDescuento = 1 Then
                .Parametro2 = "DescuentoDirecto"
            Else
                .Parametro2 = "DescuentoPostVenta"
            End If
            .llenar()
        End With


        GridExcepcion.DataSource = dtDescuento
        GridExcepcion.RetrieveStructure(True)
        GridExcepcion.GroupByBoxVisible = False
        GridExcepcion.RootTable.Columns("TipoSector").Visible = False
        GridExcepcion.RootTable.Columns("TipoDescuento").Visible = False
        GridExcepcion.RootTable.Columns("Update").Visible = False
        GridExcepcion.RootTable.Columns("Baja").Visible = False

        Dim fc0 As Janus.Windows.GridEX.GridEXFormatCondition
        fc0 = New Janus.Windows.GridEX.GridEXFormatCondition(GridExcepcion.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc0.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc0.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridExcepcion.RootTable.FormatConditions.Add(fc0)



    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.cmbTipoSector.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        
        If Me.cmbDescuento.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If
    End Function

    
 
    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Me.validaForm Then
            Dim foundRows() As Data.DataRow
            foundRows = dtDescuento.Select("TipoSector = " & CStr(cmbTipoSector.SelectedValue) & " and Baja=0 ")

            If foundRows.Length = 0 Then
                Dim row1 As DataRow
                row1 = dtDescuento.NewRow()
                'declara el nombre de la fila

                row1.Item("Sector") = cmbTipoSector.SelectedItem(1)
                row1.Item("Descuento") = cmbDescuento.SelectedItem(1)
                row1.Item("TipoSector") = cmbTipoSector.SelectedValue
                row1.Item("TipoDescuento") = cmbDescuento.SelectedValue
                row1.Item("Update") = 1
                row1.Item("Baja") = 0
                dtDescuento.Rows.Add(row1)
            Else
                Beep()
                MessageBox.Show("¡La excepción que intenta agregar ya existe para el cliente actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If
        Else
            Beep()
            MessageBox.Show("¡Algunos de los datos no son validos o son requeridos!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If GridExcepcion.RowCount >= 0 AndAlso GridExcepcion.GetValue("Baja") = 0 Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la excepción: " & GridExcepcion.GetValue("Sector") & ", " & GridExcepcion.GetValue("Descuento"), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As Data.DataRow
                    foundRows = dtDescuento.Select("TipoSector = " & CStr(GridExcepcion.GetValue("TipoSector")) & " and Baja=0 and TipoDescuento = " & CStr(GridExcepcion.GetValue("TipoDescuento")))
                    If foundRows.Length = 1 Then
                        foundRows(0)("Baja") = 1
                    End If
            End Select
        End If
    End Sub
End Class
