Public Class FrmMtoPrecio
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
    Friend WithEvents GrpListaPrecio As System.Windows.Forms.GroupBox
    Friend WithEvents BtnExportar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCopiar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnExcepcion As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnImprimir As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridListaPrecio As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoPrecio))
        Me.GrpListaPrecio = New System.Windows.Forms.GroupBox()
        Me.BtnImprimir = New Janus.Windows.EditControls.UIButton()
        Me.btnExcepcion = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnCopiar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.GridListaPrecio = New Janus.Windows.GridEX.GridEX()
        Me.BtnExportar = New Janus.Windows.EditControls.UIButton()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.GrpListaPrecio.SuspendLayout()
        CType(Me.GridListaPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpListaPrecio
        '
        Me.GrpListaPrecio.Controls.Add(Me.BtnImprimir)
        Me.GrpListaPrecio.Controls.Add(Me.btnExcepcion)
        Me.GrpListaPrecio.Controls.Add(Me.BtnCancelar)
        Me.GrpListaPrecio.Controls.Add(Me.BtnCopiar)
        Me.GrpListaPrecio.Controls.Add(Me.BtnEliminar)
        Me.GrpListaPrecio.Controls.Add(Me.GridListaPrecio)
        Me.GrpListaPrecio.Controls.Add(Me.BtnExportar)
        Me.GrpListaPrecio.Controls.Add(Me.BtnAgregar)
        Me.GrpListaPrecio.Controls.Add(Me.BtnModificar)
        Me.GrpListaPrecio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpListaPrecio.Location = New System.Drawing.Point(0, 0)
        Me.GrpListaPrecio.Name = "GrpListaPrecio"
        Me.GrpListaPrecio.Size = New System.Drawing.Size(995, 519)
        Me.GrpListaPrecio.TabIndex = 11
        Me.GrpListaPrecio.TabStop = False
        Me.GrpListaPrecio.Text = "Listas de Precios"
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImprimir.Image = CType(resources.GetObject("BtnImprimir.Image"), System.Drawing.Image)
        Me.BtnImprimir.ImageSize = New System.Drawing.Size(18, 18)
        Me.BtnImprimir.Location = New System.Drawing.Point(418, 483)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(90, 30)
        Me.BtnImprimir.TabIndex = 19
        Me.BtnImprimir.Text = "&Imprimir"
        Me.BtnImprimir.ToolTipText = "Imprime la lista de precios seleccionada"
        Me.BtnImprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnExcepcion
        '
        Me.btnExcepcion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcepcion.Icon = CType(resources.GetObject("btnExcepcion.Icon"), System.Drawing.Icon)
        Me.btnExcepcion.Location = New System.Drawing.Point(514, 483)
        Me.btnExcepcion.Name = "btnExcepcion"
        Me.btnExcepcion.Size = New System.Drawing.Size(90, 30)
        Me.btnExcepcion.TabIndex = 18
        Me.btnExcepcion.Text = "&Excepción"
        Me.btnExcepcion.ToolTipText = "Agrega una Excepción de precio"
        Me.btnExcepcion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(225, 483)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 30)
        Me.BtnCancelar.TabIndex = 15
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCopiar
        '
        Me.BtnCopiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCopiar.Icon = CType(resources.GetObject("BtnCopiar.Icon"), System.Drawing.Icon)
        Me.BtnCopiar.Location = New System.Drawing.Point(610, 483)
        Me.BtnCopiar.Name = "BtnCopiar"
        Me.BtnCopiar.Size = New System.Drawing.Size(90, 30)
        Me.BtnCopiar.TabIndex = 17
        Me.BtnCopiar.Text = "&Copiar"
        Me.BtnCopiar.ToolTipText = "Copia la lista de precios eleccionada"
        Me.BtnCopiar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(321, 483)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(91, 30)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Eliminar lista de precios seleccionada"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridListaPrecio
        '
        Me.GridListaPrecio.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridListaPrecio.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridListaPrecio.ColumnAutoResize = True
        Me.GridListaPrecio.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridListaPrecio.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridListaPrecio.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridListaPrecio.Location = New System.Drawing.Point(7, 15)
        Me.GridListaPrecio.Name = "GridListaPrecio"
        Me.GridListaPrecio.RecordNavigator = True
        Me.GridListaPrecio.Size = New System.Drawing.Size(982, 462)
        Me.GridListaPrecio.TabIndex = 1
        Me.GridListaPrecio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnExportar
        '
        Me.BtnExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExportar.Icon = CType(resources.GetObject("BtnExportar.Icon"), System.Drawing.Icon)
        Me.BtnExportar.Location = New System.Drawing.Point(706, 483)
        Me.BtnExportar.Name = "BtnExportar"
        Me.BtnExportar.Size = New System.Drawing.Size(90, 30)
        Me.BtnExportar.TabIndex = 16
        Me.BtnExportar.Text = "&Exportar"
        Me.BtnExportar.ToolTipText = "Exportar a Excel"
        Me.BtnExportar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(898, 483)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 30)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar nueva lista de precios"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Image = CType(resources.GetObject("BtnModificar.Image"), System.Drawing.Image)
        Me.BtnModificar.Location = New System.Drawing.Point(802, 483)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 30)
        Me.BtnModificar.TabIndex = 14
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar lista de precios seleccionada"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoPrecio
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(995, 519)
        Me.Controls.Add(Me.GrpListaPrecio)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmMtoPrecio"
        Me.Text = "Mantenimiento de Listas de Precio"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpListaPrecio.ResumeLayout(False)
        CType(Me.GridListaPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sListaPrecio As String
    Private sPREClave As String


    Private Sub FrmMtoPrecio_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoPrecio.Dispose()
        ModPOS.MtoPrecio = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoPrecio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor
        ModPOS.ActualizaGrid(True, Me.GridListaPrecio, "sp_muestra_listaprecio", "@COMClave", ModPOS.CompanyActual)
        Me.GridListaPrecio.RootTable.Columns("ID").Visible = False

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub GridListaPrecio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridListaPrecio.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridListaPrecio_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridListaPrecio.SelectionChanged
        If Not GridListaPrecio.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sPREClave = GridListaPrecio.GetValue("ID")
            Me.sListaPrecio = GridListaPrecio.GetValue("Lista")
        Else
            Me.sListaPrecio = ""
            sPREClave = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Precio Is Nothing Then
            ModPOS.Precio = New FrmPrecio
            With ModPOS.Precio
                .Text = "Nueva Lista de Precio"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .ChkEstado.Enabled = False
            End With
        End If
        ModPOS.Precio.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Precio.Show()
        ModPOS.Precio.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificalista()
    End Sub

    Public Sub modificalista()
        If sPREClave <> "" AndAlso sListaPrecio <> "" Then

            If ModPOS.Precio Is Nothing Then

                ModPOS.Precio = New FrmPrecio
                With ModPOS.Precio
                    .Text = "Modificar Lista de Precio"
                    .Padre = "Modificar"

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_precio", "@PREClave", Me.sPREClave)
                    .PREClave = dt.Rows(0)("PREClave")
                    .Grupo = dt.Rows(0)("Grupo")
                    .TipoCanal = dt.Rows(0)("TipoCanal")
                    .ListaPrecio = dt.Rows(0)("ListaPrecio")
                    .Descripcion = dt.Rows(0)("Descripcion")
                    .Estado = dt.Rows(0)("Estado")
                    .Factor = dt.Rows(0)("Factor")
                    .TipoDocumento = IIf(dt.Rows(0)("TipoDocumento").GetType.Name = "DBNull", 0, dt.Rows(0)("TipoDocumento"))

                    dt.Dispose()
                End With
            End If

            ModPOS.Precio.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Precio.Show()
            ModPOS.Precio.BringToFront()

        End If
    End Sub

    Private Sub GridListaPrecio_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridListaPrecio.DoubleClick
        modificalista()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sPREClave <> "" AndAlso sListaPrecio <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la lista de precio: " & sListaPrecio, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim Con As String = ModPOS.BDConexion
                    If ModPOS.SiExite(Con, "sp_listaprecio_vacia", "@PREClave", sPREClave) <> 0 Then
                        MessageBox.Show("La lista de precio seleccionada no puede ser eliminada ya que existen clientes realacionados con dicha lista", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else

                        ModPOS.Ejecuta("sp_elimina_listaprecio", "@PREClave", sPREClave, "@Usuario", ModPOS.UsuarioActual)

                        ModPOS.ActualizaGrid(True, Me.GridListaPrecio, "sp_muestra_listaprecio", "@COMClave", ModPOS.CompanyActual)
                        Me.GridListaPrecio.RootTable.Columns("ID").Visible = False


                    End If


            End Select

        End If
    End Sub

    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        Dim a As New FrmExportaPrice
        a.Titulo = "Exportación de Listas de Precios"
        a.ShowDialog()
    End Sub

    Private Sub BtnCopiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCopiar.Click
        If sPREClave <> "" AndAlso sListaPrecio <> "" Then

            Select Case MessageBox.Show("Se copiara la lista de precio  :" & sListaPrecio, "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                Case DialogResult.Yes

                    ModPOS.Ejecuta("sp_copia_lista", "@PREClave", sPREClave, "@Usuario", ModPOS.UsuarioActual)

                    ModPOS.ActualizaGrid(True, Me.GridListaPrecio, "sp_muestra_listaprecio", "@COMClave", ModPOS.CompanyActual)
                    Me.GridListaPrecio.RootTable.Columns("ID").Visible = False

            End Select

        Else
            MessageBox.Show("Debe seleccionar La lista de precios que desea copiar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnExcepcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcepcion.Click
        If ModPOS.MtoExcepcion Is Nothing Then
            ModPOS.MtoExcepcion = New FrmMtoExcepcion
            With ModPOS.MtoExcepcion
                .StartPosition = FormStartPosition.CenterScreen
            End With
        End If
        ModPOS.MtoExcepcion.StartPosition = FormStartPosition.CenterScreen
        ModPOS.MtoExcepcion.Show()
        ModPOS.MtoExcepcion.BringToFront()
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
      
            Dim a As New MeFiltroPrice
            a.Titulo = "Lista de Precios"
            a.ShowDialog()
            If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                Dim OpenReport As New Report
                Dim pvtaDataSet As New DataSet
                pvtaDataSet.DataSetName = "reportDataSet"
            Dim frmstatusmessage As frmStatus = New frmStatus
            frmstatusmessage.Show("Estamos haciendo magia...")
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_precios", "@SUCClave", a.Origen, "@CTEClave", a.Cliente, "@Lista", a.ListaPrecio, "@Clasificacion", a.Segmento))
            frmstatusmessage.Close()
            OpenReport.PrintPreview("Lista de Precios", "CRListaPrecio.rpt", pvtaDataSet, "")

            End If
            a.Dispose()


    End Sub
End Class
