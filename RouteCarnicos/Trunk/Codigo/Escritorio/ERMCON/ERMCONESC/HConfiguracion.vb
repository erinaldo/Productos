Public Class HConfiguracion
    Inherits System.Windows.Forms.Form



#Region " Windows Form Designer generated code "

    Public Sub New(ByRef prConfig As ERMCONLOG.cConfiguracion, ByRef prConexion As LbConexion.cConexion)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Dim vcMensaje As New BASMENLOG.CMensaje  

        Me.Text = vcMensaje.RecuperarDescripcion("ERMCONHESC_HConfiguracion")
        btsalir.Text = vcMensaje.RecuperarDescripcion("BTSalir")
        Dim vista As DataView = New DataView(prConfig.RecuperarHistorialOrdenado)
        vista.Sort = "CONHistFechaInicio DESC"

        Me.GridEX1.DataSource = vista
        Me.GridEX1.RetrieveStructure()

        Dim col As Janus.Windows.GridEX.GridEXColumn
        For Each col In Me.GridEX1.RootTable.Columns
            Select Case col.Key
                Case "CONHistFechaInicio"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHCONHistFechaInicio")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHCONHistFechaInicioT")
                    col.FormatMode = Janus.Windows.GridEX.FormatMode.UseIFormattable
                    col.FormatString = "dd/MM/yyyy HH:mm:ss"
                    col.Width = 120

                Case "TipoLenguaje"
                    'Dim vcVal As New BASVARLOG.cValorReferencia
                    col.Caption = vcMensaje.RecuperarDescripcion("COHTipoLenguaje")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHTipoLenguajeT")
                    col.HasValueList = True
                    lbGeneral.LlenarColumna(col, "BLENGUA")
                    col.Width = 120
                Case "TipoClaveProducto"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHTipoClaveProducto")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHTipoClaveProductoT")
                    col.HasValueList = True
                    lbGeneral.LlenarColumna(col, "TDATO")
                    col.Width = 100
                Case "DigitoClaveProd"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHDigitoClaveProd")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHDigitoClaveProdT")
                    col.Width = 100
                    col.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                    'Case "Promocion"
                    'col.Caption = vcMensaje.RecuperarDescripcion("COHPromocion")
                    ' col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHPromocionT")
                    '  col.Width = 80
                Case "AbonoProgramado"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHAbonoProgramado")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHAbonoProgramadoT")
                    col.Width = 120
                Case "MonedaID"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHMonedaID")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHMonedaIDT")
                    col.HasValueList = True
                    Dim vlDt As DataTable
                    vlDt = prConfig.Monedas.Recuperar()
                    If vlDt.Rows.Count > 0 Then
                        col.ValueList.PopulateValueList(vlDt.DefaultView, "MonedaID", "Nombre")
                    End If
                    col.Width = 100
                Case "FiltroProductos"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHFiltroProductos")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHFiltroProductosT")
                    col.Width = 100
                Case "ClienteVariasRutas"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHClienteVariasRutas")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHClienteVariasRutasT")
                    col.Width = 100
                Case "DiasSurtido"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHDiasSurtido")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHDiasSurtidoT")
                    col.Width = 120
                    col.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                Case "DiasAnteriores"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHDiasAnteriores")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHDiasAnterioresT")
                    col.Width = 120
                    col.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                Case "DiasPosteriores"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHDiasPosteriores")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHDiasPosterioresT")
                    col.Width = 120
                    col.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                Case "Inventario"
                    col.Caption = vcMensaje.RecuperarDescripcion("CohInventario")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("CohInventarioT")
                    col.Width = 90

                Case "CantidadSerAct"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHCantidadSerAct")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHCantidadSerActT")
                    col.Width = 120
                    col.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                Case "DiferenciaPreliqui"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHDiferenciaPreliqui")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHDiferenciaPreliquiT")
                    col.Width = 120
                    col.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                Case "DirInterfaz"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHDirInterfaz")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHDirInterfazT")
                    col.Width = 150
                    col.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                Case "DirectorioSDF"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHDirectorioSDF")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHDirectorioSDFT")
                    col.Width = 150
                    col.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                Case "MFechaHora"
                    col.FormatMode = Janus.Windows.GridEX.FormatMode.UseIFormattable
                    col.FormatString = "dd/MM/yyyy HH:mm:ss"
                    col.Visible = False
                Case "InterfazTXT"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHInterfazTXT")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHInterfazTXTT")
                    col.Width = 80
                Case "DepGarantia"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHDepGarantia")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHDepGarantiaT")
                    col.Width = 80
                Case "CuotasGarantia"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHCuotasGarantia")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHCuotasGarantiaT")
                    col.Width = 120
                    col.FormatString = "N0"
                    'Case "CodigoBarrasCEDI"
                    '    col.Caption = vcMensaje.RecuperarDescripcion("COHCodigoBarrasCEDI")
                    '    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHCodigoBarrasCEDIT")
                    '    col.Width = 100
                Case "CodigoBarrasCliente"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHCodigoBarrasCliente")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHCodigoBarrasClienteT")
                    col.Width = 100
                Case "ContrasenaCliente"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHContrasenaCliente")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHContrasenaClienteT")
                    col.Width = 90
                Case "CambioProducto"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHCambioProducto")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHCambioProductoT")
                    col.Width = 90
                Case "CobrarVentas"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHCobrarVentas")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHCobrarVentasT")
                    col.Width = 90
                Case "ConversionKg"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHConversionKg")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHConversionKgT")
                    col.Width = 90
                Case "IntUnidadVta"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHIntUnidadVta")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHIntUnidadVta")
                    col.Width = 90
                Case "EliminaEnviado"
                    col.Caption = vcMensaje.RecuperarDescripcion("CONEliminaEnviado")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("CONEliminaEnviadoT")
                    col.Width = 90
                    'Case "LimiteCreditoCheque"
                    '    col.Caption = vcMensaje.RecuperarDescripcion("CONLimiteCreditoCheque")
                    '    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("CONLimiteCreditoChequeT")
                    '    col.Width = 90
                Case "TicketConfigurado"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHTicketConfigurado")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHTicketConfiguradoT")
                    col.HasValueList = True
                    lbGeneral.LlenarColumna(col, "TTICKET")
                    col.Width = 90

                Case "TipoIniciarVisita"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHTipoIniciarVisita")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHTipoIniciarVisitaT")
                    col.HasValueList = True
                    lbGeneral.LlenarColumna(col, "TINIVIS")
                    col.Width = 90
                Case "LimiteGPS"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHLimiteGPS")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHLimiteGPST")
                    col.Width = 90
                Case "ClientesVisitados"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHClientesVisitados")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHClientesVisitadosT")
                    col.Width = 90
                Case "DatosCteNuevo"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHDatosCteNuevo")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHDatosCteNuevoT")
                    col.Width = 90
                Case "VenderApartado"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHVenderApartado")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHVenderApartadoT")
                    col.Width = 90
                Case "VentaSinSurtir"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHVentaSinSurtir")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHVentaSinSurtirT")
                    col.Width = 90

                Case "VentaSinSurtir"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHVentaSinSurtir")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHVentaSinSurtirT")
                    col.Width = 90
                Case "SSL"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHSSL")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHSSLT")
                    col.Width = 90

                Case "PagoAutomatico"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHPagoAutomatico")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHPagoAutomaticoT")
                    col.Width = 90
                Case "PreLiquidacion"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHPreLiquidacion")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHPreLiquidacionT")
                    col.Width = 90
                Case "AuditarCarga"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHAuditarCarga")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHAuditarCargaT")
                    col.Width = 90
                Case "ModificarVenta"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHModificarVenta")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHModificarVentaT")
                    col.Width = 90
                Case "MostrarLogo"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHMostrarLogo")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHMostrarLogoT")
                    col.Width = 90
                Case "EnvioParcial"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHEnvioParcial")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHEnvioParcialT")
                    col.Width = 90
                Case "TipoLimiteCredito"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHTipoLimiteCredito")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHTipoLimiteCreditoT")
                    col.HasValueList = True
                    lbGeneral.LlenarColumna(col, "ACTLCRE")
                    col.Width = 120
                Case "PorcentajeRiesgo"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHPorcentajeRiesgo")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHPorcentajeRiesgoT")
                    col.Width = 90
                    col.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                Case "PorcentajeInteres"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHPorcentajeInteres")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHPorcentajeInteresT")
                    col.Width = 90
                    col.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                Case "DecimalesImporte"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHDecimalesImporte")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHDecimalesImporteT")
                    col.Width = 90
                    col.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

                Case "ComprobanteDig"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHComprobanteDig")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHComprobanteDigT")
                    col.Width = 90
                Case "FoliosTerminal"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHFoliosTerminal")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHFoliosTerminalT")
                    col.Width = 90
                    'Case "RFCGenerico"
                    '    col.Caption = vcMensaje.RecuperarDescripcion("COHRFCGenerico")
                    '    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHRFCGenericoT")
                    '    col.Width = 90
                Case "Clave"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHClienteGenerico")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHClienteGenericoT")
                    col.Width = 90
                Case "DirRepMensual"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHDirRepMensual")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHDirRepMensualT")
                    col.Width = 150
                    col.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                Case "ValidaInv"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHValidaInv")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHValidaInvT")
                    col.Width = 90
                Case "AjusteDiferencias"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHAjusteDiferencias")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHAjusteDiferenciasT")
                    col.HasValueList = True
                    lbGeneral.LlenarColumna(col, "TRPTIPO")
                    col.Width = 90
                Case Else
                    col.Visible = False
            End Select
            col.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Next
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
    Friend WithEvents GridEX1 As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btsalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents LbFecha As System.Windows.Forms.Label
    Friend WithEvents LbUsuario As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HConfiguracion))
        Me.GridEX1 = New Janus.Windows.GridEX.GridEX
        Me.Label1 = New System.Windows.Forms.Label
        Me.btsalir = New Janus.Windows.EditControls.UIButton
        Me.LbFecha = New System.Windows.Forms.Label
        Me.LbUsuario = New System.Windows.Forms.Label
        CType(Me.GridEX1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridEX1
        '
        Me.GridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridEX1.GroupByBoxVisible = False
        Me.GridEX1.Location = New System.Drawing.Point(8, 8)
        Me.GridEX1.Name = "GridEX1"
        Me.GridEX1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridEX1.Size = New System.Drawing.Size(840, 368)
        Me.GridEX1.TabIndex = 0
        Me.GridEX1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(12, 284)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 3)
        Me.Label1.TabIndex = 1
        Me.Label1.Visible = False
        '
        'btsalir
        '
        Me.btsalir.Icon = CType(resources.GetObject("btsalir.Icon"), System.Drawing.Icon)
        Me.btsalir.Location = New System.Drawing.Point(744, 408)
        Me.btsalir.Name = "btsalir"
        Me.btsalir.Size = New System.Drawing.Size(104, 24)
        Me.btsalir.TabIndex = 2
        Me.btsalir.Text = "Salir"
        Me.btsalir.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'LbFecha
        '
        Me.LbFecha.Location = New System.Drawing.Point(628, 380)
        Me.LbFecha.Name = "LbFecha"
        Me.LbFecha.Size = New System.Drawing.Size(220, 20)
        Me.LbFecha.TabIndex = 3
        Me.LbFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LbUsuario
        '
        Me.LbUsuario.Location = New System.Drawing.Point(8, 380)
        Me.LbUsuario.Name = "LbUsuario"
        Me.LbUsuario.Size = New System.Drawing.Size(176, 20)
        Me.LbUsuario.TabIndex = 3
        '
        'HConfiguracion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(858, 440)
        Me.Controls.Add(Me.LbFecha)
        Me.Controls.Add(Me.btsalir)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GridEX1)
        Me.Controls.Add(Me.LbUsuario)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "HConfiguracion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HConfiguracion"
        CType(Me.GridEX1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsalir.Click
        Me.Close()
    End Sub

    Private Sub GridEX1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridEX1.SelectionChanged
        If GridEX1.RowCount > 0 Then
            LbUsuario.Text = GridEX1.GetRow.Cells("UsuarioClave").Value
            LbFecha.Text = GridEX1.GetRow.Cells("MFechaHora").Value
        End If
    End Sub

    Private Sub HConfiguracion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
