Public Class FrmMtoPrinter
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
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpPrinters As System.Windows.Forms.GroupBox
    Friend WithEvents GridPrinters As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoPrinter))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.GrpPrinters = New System.Windows.Forms.GroupBox()
        Me.GridPrinters = New Janus.Windows.GridEX.GridEX()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GrpPrinters.SuspendLayout()
        CType(Me.GridPrinters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(271, 335)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 15
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Image = CType(resources.GetObject("BtnModificar.Image"), System.Drawing.Image)
        Me.BtnModificar.Location = New System.Drawing.Point(463, 335)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 14
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar impresora seleccionada"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(367, 335)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Eliminar impresora seleccionada"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpPrinters
        '
        Me.GrpPrinters.Controls.Add(Me.BtnCancelar)
        Me.GrpPrinters.Controls.Add(Me.GridPrinters)
        Me.GrpPrinters.Controls.Add(Me.BtnEliminar)
        Me.GrpPrinters.Controls.Add(Me.BtnModificar)
        Me.GrpPrinters.Controls.Add(Me.BtnAgregar)
        Me.GrpPrinters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpPrinters.Location = New System.Drawing.Point(0, 0)
        Me.GrpPrinters.Name = "GrpPrinters"
        Me.GrpPrinters.Size = New System.Drawing.Size(656, 380)
        Me.GrpPrinters.TabIndex = 11
        Me.GrpPrinters.TabStop = False
        Me.GrpPrinters.Text = "Impresoras"
        '
        'GridPrinters
        '
        Me.GridPrinters.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridPrinters.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPrinters.ColumnAutoResize = True
        Me.GridPrinters.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridPrinters.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridPrinters.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridPrinters.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridPrinters.Location = New System.Drawing.Point(7, 15)
        Me.GridPrinters.Name = "GridPrinters"
        Me.GridPrinters.RecordNavigator = True
        Me.GridPrinters.Size = New System.Drawing.Size(642, 314)
        Me.GridPrinters.TabIndex = 1
        Me.GridPrinters.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(559, 335)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar nueva impresora"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoPrinter
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(656, 380)
        Me.Controls.Add(Me.GrpPrinters)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(553, 378)
        Me.Name = "FrmMtoPrinter"
        Me.Text = "Mantenimiento de Impresoras"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpPrinters.ResumeLayout(False)
        CType(Me.GridPrinters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sPrinterSelected As String
   
    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoPrinter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor
        ModPOS.ActualizaGrid(True, Me.GridPrinters, "sp_muestra_impresoras", "@COMClave", ModPOS.CompanyActual)
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub GriPrinters_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridPrinters.SelectionChanged
        If Not GridPrinters.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sPrinterSelected = GridPrinters.GetValue(0)
        Else
            Me.sPrinterSelected = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Printer Is Nothing Then
            ModPOS.Printer = New FrmPrinter
            With ModPOS.Printer
                .Text = "Agregar Impresora"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .ChkEstado.Enabled = False
            End With
        End If
        ModPOS.Printer.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Printer.Show()
        ModPOS.Printer.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificarPrint()
    End Sub

    Public Sub modificarPrint()
        If sPrinterSelected <> "" Then

            If ModPOS.Printer Is Nothing Then

                ModPOS.Printer = New FrmPrinter
                With ModPOS.Printer
                    .Text = "Modificar Impresora"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_impresora", "@Printer", CStr(Me.sPrinterSelected))

                    .PRNClave = dt.Rows(0)("PRNClave")
                    .Referencia = dt.Rows(0)("Referencia")
                    .Estado = dt.Rows(0)("Estado")
                    .Generic = IIf(dt.Rows(0)("Generic"), 1, 0)
                    .SUCClave = IIf(dt.Rows(0)("SUCClave").GetType.Name = "DBNull", "", dt.Rows(0)("SUCClave"))
                    .ESC = IIf(dt.Rows(0)("ESC").GetType.Name = "DBNull", 27, dt.Rows(0)("ESC"))
                    .p = IIf(dt.Rows(0)("p").GetType.Name = "DBNull", 112, dt.Rows(0)("p"))
                    .m = IIf(dt.Rows(0)("m").GetType.Name = "DBNull", 0, dt.Rows(0)("m"))
                    .t1 = IIf(dt.Rows(0)("t1").GetType.Name = "DBNull", 20, dt.Rows(0)("t1"))
                    .t2 = IIf(dt.Rows(0)("t2").GetType.Name = "DBNull", 20, dt.Rows(0)("t2"))
                    dt.Dispose()

                End With
            End If

            ModPOS.Printer.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Printer.Show()
            ModPOS.Printer.BringToFront()

        End If
    End Sub

    Private Sub GridMonedas_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridPrinters.DoubleClick
        modificarPrint()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sPrinterSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la impresora  :" & sPrinterSelected, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim Con As String = ModPOS.BDConexion
                    If ModPOS.SiExite(Con, "sp_impresora_vacia", "@Printer", CStr(sPrinterSelected)) <> 0 Then
                        MessageBox.Show("La Impresora seleccionada no puede ser eliminada ya que existen puntos de venta con dicha impresora", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        ModPOS.Ejecuta("sp_elimina_impresora", "@Printer", sPrinterSelected, "@Usuario", ModPOS.UsuarioActual)

                        ModPOS.ActualizaGrid(True, Me.GridPrinters, "sp_muestra_impresoras", "@COMClave", ModPOS.CompanyActual)
                    End If

                Case DialogResult.No

            End Select
        End If
    End Sub

    Private Sub FrmMtoPrinter_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoPrinter.Dispose()
        ModPOS.MtoPrinter = Nothing

    End Sub
End Class
