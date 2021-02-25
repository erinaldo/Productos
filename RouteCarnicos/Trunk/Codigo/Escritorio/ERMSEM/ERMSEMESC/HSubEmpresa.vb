Public Class HSubEmpresa

    Public Sub New(ByRef prConfig As ERMSEMLOG.cSubEmpresa, ByRef prConexion As LbConexion.cConexion)
        MyBase.New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim vcMensaje As New BASMENLOG.CMensaje

        Me.Text = vcMensaje.RecuperarDescripcion("ERMCONHESC_HConfiguracion")
        btsalir.Text = vcMensaje.RecuperarDescripcion("BTSalir")
        Dim vista As DataView = New DataView(prConfig.RecuperarHistorialOrdenado)
        vista.Sort = "SEMHistFechaInicio DESC"

        Me.GridEX1.DataSource = vista
        Me.GridEX1.RetrieveStructure()

        Dim col As Janus.Windows.GridEX.GridEXColumn
        For Each col In Me.GridEX1.RootTable.Columns
            col.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            Select Case col.Key

                Case "SubEmpresaId"
                    col.Visible = False
                Case "SEMHistFechaInicio"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHCONHistFechaInicio")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHCONHistFechaInicioT")
                    col.FormatMode = Janus.Windows.GridEX.FormatMode.UseIFormattable
                    col.FormatString = "dd/MM/yyyy HH:mm:ss"
                    col.Width = 120
                Case "ClienteClave"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHClienteGenerico")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHClienteGenericoT")
                    col.Width = 90
                Case "ComprobanteDig"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHComprobanteDig")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHComprobanteDigT")
                    col.Width = 90
                Case "FoliosTerminal"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHFoliosTerminal")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHFoliosTerminalT")
                    col.Width = 90
                Case "DirRepMensual"
                    col.Caption = vcMensaje.RecuperarDescripcion("COHDirRepMensual")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("COHDirRepMensualT")
                    col.Width = 150
                    col.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                Case "DirDocXML"

                    col.Visible = False
                Case "DirArchivosFacElec"
                    col.Visible = False
                Case "ContrasenaClave"
                    col.Visible = False
                Case "ArchivoPEM"
                    col.Visible = False
                Case "CerBase64"
                    col.Visible = False
                Case "MFechaHora"
                    col.Visible = False
                Case "MUsuarioID"
                    col.Visible = False
                Case "ProveedorTimbre"
                    col.Visible = False
                Case "CustomerKey"
                    col.Visible = False
                Case "ServidorTimbre"
                    col.Visible = False
                Case "ServidorCancelacion"
                    col.Visible = False
                Case "AchivoPFX64"
                    col.Visible = False
                Case "VersionCFD"
                    col.Caption = vcMensaje.RecuperarDescripcion("SEMVersionCFD")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("SEMVersionCFDT")
                    col.HasValueList = True
                    lbGeneral.LlenarColumna(col, "VERFACTE")
                Case "FormatoFactura"
                    col.Caption = vcMensaje.RecuperarDescripcion("SEMFormatoFacturas")
                    col.HeaderToolTip = vcMensaje.RecuperarDescripcion("SEMFormatoFacturas")
                    col.HasValueList = True
                    lbGeneral.LlenarColumna(col, "FRMFAC")
            End Select

        Next

        Me.GridEX1.RootTable.Columns("ComprobanteDig").Position = 3
        Me.GridEX1.RootTable.Columns("FoliosTerminal").Position = 4
        Me.GridEX1.RootTable.Columns("DirRepMensual").Position = 5
        Me.GridEX1.RootTable.Columns("ClienteClave").Position = 6

    End Sub

    Private Sub GridEX1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridEX1.SelectionChanged
        If GridEX1.RowCount > 0 Then
            LbUsuario.Text = GridEX1.GetRow.Cells("MUsuarioID").Value
            LbFecha.Text = GridEX1.GetRow.Cells("MFechaHora").Value
        End If
    End Sub

    Private Sub btsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsalir.Click
        Me.Close()
    End Sub
End Class