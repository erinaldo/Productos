Public Class DClienteProducto
    Inherits FormasBase.FrmBase

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents btAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents lbLinea As System.Windows.Forms.Label
    Friend WithEvents grProductoPrestamo As Janus.Windows.GridEX.GridEX
    Friend WithEvents lbCliente As System.Windows.Forms.Label
    Friend WithEvents ebNombre As Janus.Windows.GridEX.EditControls.EditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim grProductoPrestamo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DClienteProducto))
        Me.grProductoPrestamo = New Janus.Windows.GridEX.GridEX
        Me.lbCliente = New System.Windows.Forms.Label
        Me.btAceptar = New Janus.Windows.EditControls.UIButton
        Me.lbLinea = New System.Windows.Forms.Label
        Me.ebNombre = New Janus.Windows.GridEX.EditControls.EditBox
        CType(Me.grProductoPrestamo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grProductoPrestamo
        '
        Me.grProductoPrestamo.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        grProductoPrestamo_DesignTimeLayout.LayoutString = resources.GetString("grProductoPrestamo_DesignTimeLayout.LayoutString")
        Me.grProductoPrestamo.DesignTimeLayout = grProductoPrestamo_DesignTimeLayout
        Me.grProductoPrestamo.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grProductoPrestamo.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.grProductoPrestamo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grProductoPrestamo.GroupByBoxVisible = False
        Me.grProductoPrestamo.Location = New System.Drawing.Point(8, 36)
        Me.grProductoPrestamo.Name = "grProductoPrestamo"
        Me.grProductoPrestamo.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grProductoPrestamo.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grProductoPrestamo.Size = New System.Drawing.Size(692, 372)
        Me.grProductoPrestamo.TabIndex = 506
        Me.grProductoPrestamo.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation
        Me.grProductoPrestamo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbCliente
        '
        Me.lbCliente.BackColor = System.Drawing.Color.Transparent
        Me.lbCliente.Location = New System.Drawing.Point(8, 8)
        Me.lbCliente.Name = "lbCliente"
        Me.lbCliente.Size = New System.Drawing.Size(132, 20)
        Me.lbCliente.TabIndex = 508
        Me.lbCliente.Text = "Cliente"
        Me.lbCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btAceptar
        '
        Me.btAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btAceptar.Icon = CType(resources.GetObject("btAceptar.Icon"), System.Drawing.Icon)
        Me.btAceptar.Location = New System.Drawing.Point(592, 432)
        Me.btAceptar.Name = "btAceptar"
        Me.btAceptar.Size = New System.Drawing.Size(104, 24)
        Me.btAceptar.TabIndex = 509
        Me.btAceptar.Text = "Aceptar"
        Me.btAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'lbLinea
        '
        Me.lbLinea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbLinea.Location = New System.Drawing.Point(8, 420)
        Me.lbLinea.Name = "lbLinea"
        Me.lbLinea.Size = New System.Drawing.Size(692, 2)
        Me.lbLinea.TabIndex = 510
        '
        'ebNombre
        '
        Me.ebNombre.Enabled = False
        Me.ebNombre.Location = New System.Drawing.Point(144, 8)
        Me.ebNombre.Name = "ebNombre"
        Me.ebNombre.Size = New System.Drawing.Size(428, 20)
        Me.ebNombre.TabIndex = 511
        Me.ebNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'DClienteProducto
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(710, 460)
        Me.Controls.Add(Me.ebNombre)
        Me.Controls.Add(Me.lbLinea)
        Me.Controls.Add(Me.btAceptar)
        Me.Controls.Add(Me.lbCliente)
        Me.Controls.Add(Me.grProductoPrestamo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DClienteProducto"
        CType(Me.grProductoPrestamo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Variables"
    Private oMensaje As New BASMENLOG.CMensaje
#End Region

#Region " Funciones "
    Public Sub CONSULTAR(ByRef prCliente As ERMCLILOG.cCliente)
        Dim sQuery As String
        sQuery = "SELECT TP.FechaCaptura, TD.ProductoClave , PR.Nombre, 0 as Prestamo, TD.Cantidad as Devolucion "
        sQuery = sQuery & "FROM Visita as VS, TransProd as TP, TransProdDetalle as TD, Producto as PR "
        sQuery = sQuery & "WHERE TP.VisitaClave=VS.VisitaClave AND TP.DiaClave=VS.DiaClave "
        sQuery = sQuery & "  AND TD.TransProdId=TP.TransProdId "
        sQuery = sQuery & "  AND PR.ProductoClave=TD.ProductoClave "
        sQuery = sQuery & "  AND TP.Tipo=15 AND VS.ClienteClave='" & lbGeneral.ValidaFormatoSQLString(prCliente.ClienteClave) & "' "
        sQuery = sQuery & "UNION "
        sQuery = sQuery & "SELECT TP.FechaCaptura, PP.ProductoDetClave, PR.Nombre, PP.CantidadPrestada as Prestamo, 0 as Devolucion "
        sQuery = sQuery & "FROM Visita as VS, TransProd as TP, TransProdDetalle as TD, ProductoPrestamo as PP, ProductoDetalle as PD, Producto as PR "
        sQuery = sQuery & "WHERE TP.VisitaClave=VS.VisitaClave AND TP.DiaClave=VS.DiaClave "
        sQuery = sQuery & "  AND TD.TransProdId=TP.TransProdId "
        sQuery = sQuery & "  AND PP.TransProdId=TD.TransProdId AND PP.TransProdDetalleId=TD.TransProdDetalleId AND PP.ProductoClave=TD.ProductoClave AND PP.PRUTipoUnidad=TD.TipoUnidad  "
        sQuery = sQuery & "  AND PD.ProductoClave=PP.ProductoClave AND PD.PRUTipoUnidad=PP.PRUTipoUnidad AND PD.ProductoDetClave=PP.ProductoDetClave "
        sQuery = sQuery & "  AND PR.ProductoClave=PD.ProductoDetClave "
        sQuery = sQuery & "  AND TP.Tipo=1 AND TP.TipoFase<>0 AND VS.ClienteClave='" & lbGeneral.ValidaFormatoSQLString(prCliente.ClienteClave) & "'"


        Dim ldt As DataTable = LbConexion.cConexion.Instancia.EjecutarConsulta(sQuery)
        Me.Text = oMensaje.RecuperarDescripcion("ERMCLIESC_DClienteProducto")
        ConfigurarTitulos()
        ConfigurarGrid()

        ebNombre.Text = prCliente.NombreCorto

        grProductoPrestamo.DataSource = ldt
        Me.ShowDialog()
    End Sub

    Private Sub ConfigurarTitulos()
        Dim vlToolTip As New ToolTip
        Me.btAceptar.Text = oMensaje.RecuperarDescripcion("btSalir")

        With vlToolTip
            .ShowAlways = True
            .SetToolTip(Me.btAceptar, oMensaje.RecuperarDescripcion("btSalirT"))
        End With
    End Sub

    Private Sub ConfigurarGrid()
        grProductoPrestamo.BuiltInTexts.Item(Janus.Windows.GridEX.GridEXBuiltInText.CalendarTodayButton) = oMensaje.RecuperarDescripcion("XAhora")
        grProductoPrestamo.BuiltInTexts.Item(Janus.Windows.GridEX.GridEXBuiltInText.CalendarNoneButton) = oMensaje.RecuperarDescripcion("XNinguna")

        grProductoPrestamo.RootTable.Columns("FechaCaptura").Caption = oMensaje.RecuperarDescripcion("XFecha")
        grProductoPrestamo.RootTable.Columns("FechaCaptura").HeaderToolTip = oMensaje.RecuperarDescripcion("XFecha")
        grProductoPrestamo.RootTable.Columns("ProductoClave").Caption = oMensaje.RecuperarDescripcion("PROProductoClave")
        grProductoPrestamo.RootTable.Columns("ProductoClave").HeaderToolTip = oMensaje.RecuperarDescripcion("PROProductoClaveT")
        grProductoPrestamo.RootTable.Columns("Nombre").Caption = oMensaje.RecuperarDescripcion("PRONombre")
        grProductoPrestamo.RootTable.Columns("Nombre").HeaderToolTip = oMensaje.RecuperarDescripcion("PRONombreT")
        grProductoPrestamo.RootTable.Columns("Prestamo").Caption = oMensaje.RecuperarDescripcion("XPrestamos")
        grProductoPrestamo.RootTable.Columns("Prestamo").HeaderToolTip = oMensaje.RecuperarDescripcion("XPrestamos")
        grProductoPrestamo.RootTable.Columns("Devolucion").Caption = oMensaje.RecuperarDescripcion("XDevoluciones")
        grProductoPrestamo.RootTable.Columns("Devolucion").HeaderToolTip = oMensaje.RecuperarDescripcion("XDevoluciones")
    End Sub
#End Region

    Private Sub btAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAceptar.Click
        Me.Close()
    End Sub
End Class
