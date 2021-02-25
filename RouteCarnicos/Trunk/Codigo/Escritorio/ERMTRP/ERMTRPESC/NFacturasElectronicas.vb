Imports ERMTRPLOG

Public Class NFacturasElectronicas
    Inherits FormasBase.Browse01

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
    Friend WithEvents btCrear As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btConsultar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btActualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btCancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btImprimir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btXML As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btVerificada As DevComponents.DotNetBar.ButtonItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEx1_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NFacturasElectronicas))
        Me.btCrear = New DevComponents.DotNetBar.ButtonItem
        Me.btConsultar = New DevComponents.DotNetBar.ButtonItem
        Me.btActualizar = New DevComponents.DotNetBar.ButtonItem
        Me.btCancelar = New DevComponents.DotNetBar.ButtonItem
        Me.btImprimir = New DevComponents.DotNetBar.ButtonItem
        Me.btXML = New DevComponents.DotNetBar.ButtonItem
        Me.btVerificada = New DevComponents.DotNetBar.ButtonItem
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btCrear, Me.btConsultar, Me.btCancelar, Me.btImprimir, Me.btXML, Me.btVerificada, Me.btActualizar})
        '
        'GridEx1
        '
        Me.GridEx1.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridEx1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEx1_DesignTimeLayout.LayoutString = resources.GetString("GridEx1_DesignTimeLayout.LayoutString")
        Me.GridEx1.DesignTimeLayout = GridEx1_DesignTimeLayout
        Me.GridEx1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        '
        'btCrear
        '
        Me.btCrear.DisabledImage = CType(resources.GetObject("btCrear.DisabledImage"), System.Drawing.Image)
        Me.btCrear.Icon = CType(resources.GetObject("btCrear.Icon"), System.Drawing.Icon)
        Me.btCrear.Name = "btCrear"
        Me.btCrear.Text = "btCrear"
        '
        'btConsultar
        '
        Me.btConsultar.DisabledImage = CType(resources.GetObject("btConsultar.DisabledImage"), System.Drawing.Image)
        Me.btConsultar.Icon = CType(resources.GetObject("btConsultar.Icon"), System.Drawing.Icon)
        Me.btConsultar.Name = "btConsultar"
        Me.btConsultar.Text = "btConsultar"
        '
        'btActualizar
        '
        Me.btActualizar.Icon = CType(resources.GetObject("btActualizar.Icon"), System.Drawing.Icon)
        Me.btActualizar.Name = "btActualizar"
        Me.btActualizar.Text = "btActualizar"
        '
        'btCancelar
        '
        Me.btCancelar.Icon = CType(resources.GetObject("btCancelar.Icon"), System.Drawing.Icon)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Text = "btCancelar"
        '
        'btImprimir
        '
        Me.btImprimir.Icon = CType(resources.GetObject("btImprimir.Icon"), System.Drawing.Icon)
        Me.btImprimir.Name = "btImprimir"
        Me.btImprimir.Text = "btImprimir"
        '
        'btXML
        '
        Me.btXML.Icon = CType(resources.GetObject("btXML.Icon"), System.Drawing.Icon)
        Me.btXML.Name = "btXML"
        Me.btXML.Text = "btXML"
        '
        'btVerificada
        '
        Me.btVerificada.DisabledImage = CType(resources.GetObject("btVerificada.DisabledImage"), System.Drawing.Image)
        Me.btVerificada.Icon = CType(resources.GetObject("btVerificada.Icon"), System.Drawing.Icon)
        Me.btVerificada.Name = "btVerificada"
        Me.btVerificada.Text = "btVerificada"
        '
        'NFacturasElectronicas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(844, 666)
        Me.Name = "NFacturasElectronicas"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Variables "
    Private Shared oInstance As NFacturasElectronicas = Nothing
    Private oConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private oTransProd As cTransProd
    Private oMensaje As BASMENLOG.CMensaje
    Private sComponente As String = "ERMTRPESC"
    Dim oAcceso As LbAcceso.cAcceso
#End Region

#Region " Metodos "
    Public Shared Function Instance() As NFacturasElectronicas
        If oInstance Is Nothing OrElse oInstance.IsDisposed = True Then
            oInstance = New NFacturasElectronicas
        End If

        Return oInstance
    End Function

    Sub Inicio(ByVal pvAcceso As LbAcceso.cAcceso)
        oAcceso = pvAcceso
        Me.Show()
    End Sub

    Private Sub ConfigurarGrid()
        GridEx1.RootTable.Columns("TransProdId").Visible = False
        GridEx1.RootTable.Columns("TransProdId").ShowInFieldChooser = False
        GridEx1.RootTable.Columns("Folio").Caption = oMensaje.RecuperarDescripcion(oTransProd.Mnemonico & "Folio")
        GridEx1.RootTable.Columns("Folio").HeaderToolTip = oMensaje.RecuperarDescripcion(oTransProd.Mnemonico & "FolioT")
        GridEx1.RootTable.Columns("Folio").HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        GridEx1.RootTable.Columns("FechaHoraAlta").Caption = oMensaje.RecuperarDescripcion(oTransProd.Mnemonico & "FechaFacturacion")
        GridEx1.RootTable.Columns("FechaHoraAlta").HeaderToolTip = oMensaje.RecuperarDescripcion(oTransProd.Mnemonico & "FechaFacturacionT")
        GridEx1.RootTable.Columns("FechaHoraAlta").FormatString = "dd/MM/yyyy hh:mm:ss"
        GridEx1.RootTable.Columns("FechaHoraAlta").HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        GridEx1.RootTable.Columns("FechaHoraAlta").Width = 150
        GridEx1.RootTable.Columns("RazonSocial").Caption = oMensaje.RecuperarDescripcion("TDFRazonSocial")
        GridEx1.RootTable.Columns("RazonSocial").HeaderToolTip = oMensaje.RecuperarDescripcion("TDFRazonSocialT")
        GridEx1.RootTable.Columns("RazonSocial").HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        GridEx1.RootTable.Columns("RazonSocial").Width = 200
        GridEx1.RootTable.Columns("RFC").Caption = oMensaje.RecuperarDescripcion("TDFRFC")
        GridEx1.RootTable.Columns("RFC").HeaderToolTip = oMensaje.RecuperarDescripcion("TDFRFCT")
        GridEx1.RootTable.Columns("RFC").HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        GridEx1.RootTable.Columns("TipoFase").Caption = oMensaje.RecuperarDescripcion(oTransProd.Mnemonico & "TipoFase")
        GridEx1.RootTable.Columns("TipoFase").HeaderToolTip = oMensaje.RecuperarDescripcion(oTransProd.Mnemonico & "TipoFaseT")
        GridEx1.RootTable.Columns("TipoFase").HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        GridEx1.RootTable.Columns("TipoMotivo").Caption = oMensaje.RecuperarDescripcion(oTransProd.Mnemonico & "TipoMotivo")
        GridEx1.RootTable.Columns("TipoMotivo").HeaderToolTip = oMensaje.RecuperarDescripcion(oTransProd.Mnemonico & "TipoMotivoT")
        GridEx1.RootTable.Columns("TipoMotivo").HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        GridEx1.RootTable.Columns("TipoMotivo").Width = 200

        GridEx1.RootTable.Columns("SubEmpresa").Caption = oMensaje.RecuperarDescripcion("SEM" & "NombreEmpresa")
        GridEx1.RootTable.Columns("SubEmpresa").HeaderToolTip = oMensaje.RecuperarDescripcion("SEM" & "NombreEmpresaT")
        GridEx1.RootTable.Columns("SubEmpresa").HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        GridEx1.RootTable.Columns("SubEmpresa").Width = 200


        btCrear.Tooltip = oMensaje.RecuperarDescripcion("btCrear")
        btConsultar.Tooltip = oMensaje.RecuperarDescripcion("btConsultar")
        btCancelar.Tooltip = oMensaje.RecuperarDescripcion("btCancelar")
        btImprimir.Tooltip = oMensaje.RecuperarDescripcion("btImprimir")
        btXML.Tooltip = oMensaje.RecuperarDescripcion("btXML")
        btVerificada.Tooltip = oMensaje.RecuperarDescripcion("btVerificada")
        btActualizar.Tooltip = oMensaje.RecuperarDescripcion("btActualizar")

        If Not oAcceso.Crear Then
            btCrear.Enabled = False
        End If
        If Not oAcceso.Leer Then
            btConsultar.Enabled = False
        End If
        If Not oAcceso.Eliminar Then
            btCancelar.Enabled = False
        End If
        If Not oAcceso.Otros Then
            btXML.Enabled = False
        End If
        If Not oAcceso.Print Then
            btImprimir.Enabled = False
        End If

        Try
            lbGeneral.LlenarConfiguracionGrid(sComponente, Me.Name, GridEx1, oTransProd.NombreTabla)
        Catch ex As LbControlError.cError
            ex.Mostrar()
            Exit Sub
        End Try
    End Sub

    Private Sub LlenarDropDownColumna(ByVal pvColumna As String, ByVal pvValor As String, Optional ByVal pvListaExcluidos As String() = Nothing)
        With GridEx1.RootTable
            .Columns(pvColumna).HasValueList = True
            .Columns(pvColumna).EditType = Janus.Windows.GridEX.EditType.DropDownList
            lbGeneral.LlenarColumna(.Columns(pvColumna), pvValor, Nothing, pvListaExcluidos)
        End With
    End Sub

    Private Sub LlenarDropDownColumna(ByVal pvColumna As String, ByVal pvValor As String, ByVal pvGrupo As String)
        With GridEx1.RootTable
            .Columns(pvColumna).HasValueList = True
            .Columns(pvColumna).EditType = Janus.Windows.GridEX.EditType.DropDownList
            lbGeneral.LlenarColumnaGrupo(.Columns(pvColumna), pvValor, pvGrupo, Nothing)
        End With
    End Sub

    Private Sub LlenarCombos()
        LlenarDropDownColumna("TipoFase", "TRPFASE")
        LlenarDropDownColumna("TipoMotivo", "TRPMOT", "Facturacion Elect")
    End Sub

    Private Sub Actualizar()
        Try
            Dim loDt As DataTable
            Dim sConsulta As String
            sConsulta = "select TRP.TransProdId, TRP.Folio, TRP.FechaHoraAlta, TDF.RazonSocial, TDF.RFC, TRP.TipoFase, (SELECT CASE WHEN TRP.TipoMotivo is NULL THEN '' WHEN TRP.TipoMotivo=0 THEN '' ELSE Cast(TRP.TipoMotivo AS VarChar(5)) END) as TipoMotivo,"
            sConsulta &= "Sem.NombreEmpresa as SubEmpresa, (select top 1 VersionCFD from SEMHist where SEMHist.SubEmpresaId = Sem.SubEmpresaId and SEMHistFechaInicio <= TRP.FechaHoraAlta order by SEMHistFechaInicio desc) as VersionCFD "
            sConsulta &= "from TransProd TRP "
            sConsulta &= "inner join TRPDatoFiscal TDF on TRP.TransProdId = TDF.TransProdId "
            sConsulta &= "inner join SubEmpresa Sem on Sem.SubEmpresaId = Trp.SubEmpresaId "
            'sConsulta &= "inner join (select top 1 * from SEMHist order by SEMHistFechaInicio desc) SMH on SEM.SubEmpresaId = SMH.SubEmpresaId "
            sConsulta &= "where TRP.Tipo = 8 "

            loDt = LbConexion.cConexion.Instancia.EjecutarConsulta(sConsulta)
            loDt.TableName = oTransProd.NombreTabla

            GridEx1.DataSource = loDt
            GridEx1.DataMember = oTransProd.NombreTabla
            LlenarCombos()
        Catch ex As LbControlError.cError
            ex.Mostrar()
        End Try
    End Sub

    Private Sub Consultar()
        Dim lMFacturasElectronicas As New MFacturasElectronicas

        If GridEx1.RowCount > 0 Then
            If (GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Or GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
                oTransProd = Nothing
                oTransProd = New cTransProd

                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                Try
                    oTransProd.Recuperar(GridEx1.GetRow.Cells("TransProdId").Value)
                Catch ex As LbControlError.cError
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    ex.Mostrar()
                    Exit Sub
                End Try

                Try
                    oTransProd.Tabla.Campos("MUsuarioId").Tipo = LbDatos.ETipo.Cadena
                Catch ex As LbControlError.cError
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    oConexion.DeshacerTran()
                    MsgBox(oMensaje.RecuperarDescripcion("BI0003"), MsgBoxStyle.Information, oMensaje.RecuperarDescripcion("XMensajeI"))
                    Exit Sub
                End Try

                Me.Cursor = System.Windows.Forms.Cursors.Default
                lMFacturasElectronicas.LEER(oTransProd)
            End If
        End If

    End Sub

#End Region

#Region " Eventos "
    Private Sub NCargas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

#If DEBUG Then
        oConexion.Conectar("Provider=SQLOLEDB;Data Source=localhost\sql2005;user id=sa;password=Amesol11.;initial catalog=SKPruebas")
        'oConexion.Conectar("Provider=SQLOLEDB;Data Source=PROJAS-PC\SQLServer2008R2;user id=sa;password=Amesol11.;initial catalog=AddendaWalmart")

        oMensaje = New BASMENLOG.CMensaje
        oMensaje.LlenarDataSet()
        'lbGeneral.cParametros.UsuarioID = "2Z+TG+WTW6Q3LGL"

        lbGeneral.cParametros.UsuarioID = "35JFLLL4U+DWSWQ"
        Dim oKeyGen As New lbGeneral.cKeyGen
        oAcceso = New LbAcceso.cAcceso
        oAcceso.Modificar = True
        oAcceso.Leer = True
        oAcceso.Crear = True
        oAcceso.Print = True
        oAcceso.Otros = True
        oAcceso.Eliminar = True
#End If

        oMensaje = New BASMENLOG.CMensaje
        oTransProd = New cTransProd
        Me.Text = oMensaje.RecuperarDescripcion(sComponente & "_" & Me.Name)

        Try
            Actualizar()
            ConfigurarGrid()
        Catch ex As LbControlError.cError
            ex.Mostrar()
        End Try

    End Sub

    Private Sub NGeneral_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            lbGeneral.GrabarConfiguracionGrid(sComponente, Me.Name, GridEx1, oTransProd.NombreTabla)
        Catch ex As LbControlError.cError
            ex.Mostrar()
            Exit Sub
        End Try
    End Sub

    Private Sub GridEX1_FormattingRow(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowLoadEventArgs) Handles GridEx1.FormattingRow
      
        If e.Row.Cells("TipoMotivo").Value Is Nothing Then Exit Sub
        If e.Row.Cells("TipoMotivo").Value.ToString = "" Then Exit Sub

        If (e.Row.Cells("TipoMotivo").Value = "10" And e.Row.Cells("TipoFase").Value <> 0) Or e.Row.Cells("TipoMotivo").Value = "11" Then
            Dim rsRowStyle As New Janus.Windows.GridEX.GridEXFormatStyle
            rsRowStyle.ForeColor = System.Drawing.Color.Red
            e.Row.RowStyle = rsRowStyle
        End If

    End Sub

    Private Sub GridEX1_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridEx1.SelectionChanged
        If GridEx1.RowCount > 0 Then
            If GridEx1.GetRow.Cells("TipoMotivo").Value = "10" Or GridEx1.GetRow.Cells("TipoMotivo").Value = "11" Or GridEx1.GetRow.Cells("TipoFase").Value = 0 Then
                btXML.Enabled = False
            Else
                If oAcceso.Otros Then
                    btXML.Enabled = True
                End If
            End If

            If GridEx1.GetRow.Cells("TipoMotivo").Value = "11" Then
                btVerificada.Enabled = True
            Else
                btVerificada.Enabled = False
            End If
        End If
    End Sub

    Private Sub btCrear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btCrear.Click
        Dim oMFacturasElectronicas As New MFacturasElectronicas
        Dim oParametros As New ERMSEMLOG.cSubEmpresa
        Dim lSubEmpresaInactivas As New System.Collections.Generic.List(Of ERMSEMLOG.cSubEmpresa)
        Dim lSubEmpresa As New System.Collections.Generic.List(Of ERMSEMLOG.cSubEmpresa)
        Dim bComprobantes As Boolean = False
        Dim bArchivoPEM As Boolean = True
        Dim bArchivoCER As Boolean = True
        Dim bFolios As Boolean = False
        Dim oVendedor As New ERMVENLOG.cVendedor
        Dim oFolio As New ERMFOLLOG.cFolio
        Dim strTerminalClave As String
        Dim strVendedorId As String
        Dim sSinArchivoPEM As String = ""
        Dim sSinArchivoCER As String = ""
        Dim sSinFoliosFiscales As String = ""
        Dim sError As String = ""


        lSubEmpresa.Clear()
        Try

            Dim ldtTabla As DataTable = oVendedor.Tabla.Recuperar("USUId='" & lbGeneral.cParametros.UsuarioID & "' AND TipoEstado=1")
            If ldtTabla.Rows.Count > 0 Then
                strTerminalClave = IIf(IsDBNull(ldtTabla.Rows(0)!TerminalClave), "", ldtTabla.Rows(0)!TerminalClave)
                strVendedorId = ldtTabla.Rows(0)!VendedorId


                Dim loVENRUT As New ERMVERLOG.Amesol.CVenRut
                If loVENRUT.TablaNodo.Recuperar("VendedorId='" & strVendedorId & "' AND TipoEstado=1").Rows.Count > 0 Then
                    Throw New LbControlError.cError("E0661")
                End If
            Else
                Throw New LbControlError.cError("E0666")
            End If

            Dim tabla As DataTable = oParametros.RecuperarTabla()
            For Each fila As DataRow In tabla.Rows
                oParametros = New ERMSEMLOG.cSubEmpresa
                oParametros.Recuperar(fila("SubEmpresaId"))
                If oParametros.TipoEstado = 1 Then
                    If oParametros.ComprobanteDig = True Then
                        bComprobantes = True
                        
                        Try
                            If oParametros.FoliosTerminal Then
                                oFolio.ObtenerFolioFiscal(strTerminalClave, Nothing, oParametros.SubEmpresaID, 1)
                            Else
                                oFolio.ObtenerFolioFiscal(Nothing, strVendedorId, oParametros.SubEmpresaID, 1)
                            End If
                            bFolios = True
                        Catch ex As Exception
                            sSinFoliosFiscales += oParametros.NombreEmpresa + ","
                            sError = CType(ex, LbControlError.cError).Codigo
                            Continue For
                        End Try

                        If Not (IsDBNull(oParametros.ArchivoPEM) Or oParametros.ArchivoPEM = "") Then
                            bArchivoPEM = False

                        Else
                            sSinArchivoPEM += oParametros.NombreEmpresa + ","
                        End If

                        If Not (IsDBNull(oParametros.CerBase64) Or oParametros.CerBase64 = "") And Not (IsDBNull(oParametros.ArchivoPEM) Or oParametros.ArchivoPEM = "") Then
                            lSubEmpresa.Add(oParametros)
                        End If

                        If Not (IsDBNull(oParametros.CerBase64) Or oParametros.CerBase64 = "") Then
                            bArchivoCER = False

                        Else
                            sSinArchivoCER += oParametros.NombreEmpresa + ","
                        End If




                    Else
                        lSubEmpresaInactivas.Add(oParametros)
                    End If
                Else
                    lSubEmpresaInactivas.Add(oParametros)
                End If
            Next

            If bComprobantes = False Then
                Throw New LbControlError.cError("I0178")
            End If


            If Not bFolios Then
                'Throw New LbControlError.cError("E0659")
                Throw New LbControlError.cError(sError)
            End If

            'Validar que exista el ArchivoPEM
            If bArchivoPEM Then
                Throw New LbControlError.cError("E0679")
            End If

            If bArchivoCER Then
                Throw New LbControlError.cError("E0841")
            End If

            If sSinArchivoPEM <> "" Then
                sSinArchivoPEM = sSinArchivoPEM.Substring(0, sSinArchivoPEM.Length - 1)
                Try
                    Throw New LbControlError.cError("I0199", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(sSinArchivoPEM, False)})
                Catch ex As LbControlError.cError
                    ex.Mostrar()
                End Try
            End If

            If sSinFoliosFiscales <> "" Then
                sSinFoliosFiscales = sSinFoliosFiscales.Substring(0, sSinFoliosFiscales.Length - 1)
                Try
                    Throw New LbControlError.cError("I0198", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(sSinFoliosFiscales, False)})
                Catch ex As LbControlError.cError
                    ex.Mostrar()
                End Try
            End If


            If sSinArchivoCER <> "" Then
                sSinArchivoCER = sSinArchivoCER.Substring(0, sSinArchivoCER.Length - 1)
                Try
                    Throw New LbControlError.cError("E0840", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(sSinArchivoCER, False)})
                Catch ex As LbControlError.cError
                    ex.Mostrar()
                End Try
            End If

            If lSubEmpresa.Count = 0 Then
                If oParametros.FoliosTerminal Then
                    oFolio.ObtenerFolioFiscal(strTerminalClave, Nothing, oParametros.SubEmpresaID, 1)
                Else
                    oFolio.ObtenerFolioFiscal(Nothing, strVendedorId, oParametros.SubEmpresaID, 1)
                End If
            End If

            For Each tempSubempresa As ERMSEMLOG.cSubEmpresa In lSubEmpresaInactivas
                For Each tempSubempresaInactiva As ERMSEMLOG.cSubEmpresa In lSubEmpresaInactivas
                    Dim fila() As DataRow = tabla.Select("subempresaid='" + tempSubempresaInactiva.SubEmpresaID + "'")

                    If fila.Length > 0 Then
                        tabla.Rows.Remove(fila(0))
                    End If

                Next
            Next

            If lSubEmpresa.Count <> tabla.Rows.Count Then
                Dim sSinFolio As String = ""
                For Each tempSubempresa As ERMSEMLOG.cSubEmpresa In lSubEmpresa
                    Dim fila() As DataRow = tabla.Select("subempresaid='" + tempSubempresa.SubEmpresaID + "'")

                    If fila.Length > 0 Then
                        tabla.Rows.Remove(fila(0))
                    End If

                Next
                For Each fila As DataRow In tabla.Rows
                    sSinFolio += fila("NombreEmpresa") + ","
                Next

                sSinFolio = sSinFolio.Substring(0, sSinFolio.Length - 1)

                Try
                    Throw New LbControlError.cError("I0198", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(sSinFolio, False)})
                Catch ex As LbControlError.cError
                    ex.Mostrar()
                End Try
            End If

            oTransProd = New ERMTRPLOG.cTransProd

            If oMFacturasElectronicas.CREAR(oTransProd, lSubEmpresa.ToArray()) Then
                Dim loDt As DataTable
                Dim sConsulta As String
                sConsulta = "select TRP.TransProdId, TRP.Folio, TRP.FechaHoraAlta, TDF.RazonSocial, TDF.RFC, TRP.TipoFase, (SELECT CASE WHEN TRP.TipoMotivo=0 THEN '' ELSE Cast(TRP.TipoMotivo AS VarChar(5)) END) as TipoMotivo, "
                sConsulta &= "Sem.NombreEmpresa as SubEmpresa, (select top 1 VersionCFD from SEMHist where SEMHist.SubEmpresaId = Sem.SubEmpresaId and SEMHistFechaInicio <= TRP.FechaHoraAlta order by SEMHistFechaInicio desc) as VersionCFD "
                sConsulta &= "from TransProd TRP "
                sConsulta &= "inner join SubEmpresa Sem on Sem.SubEmpresaID = TRP.SubEmpresaID  "
                sConsulta &= "inner join TRPDatoFiscal TDF on TRP.TransProdId = TDF.TransProdId "
                'sConsulta &= "inner join (select top 1 * from SEMHist order by SEMHistFechaInicio desc) SMH on SEM.SubEmpresaId = SMH.SubEmpresaId "
                sConsulta &= "where TRP.TransProdId='" & oTransProd.TransProdID & "' "
                loDt = oConexion.EjecutarConsulta(sConsulta)
                CType(GridEx1.DataSource, DataTable).Rows.Add(New Object() {loDt.Rows(0)!TransProdId, loDt.Rows(0)!Folio, loDt.Rows(0)!FechaHoraAlta, loDt.Rows(0)!RazonSocial, loDt.Rows(0)!RFC, loDt.Rows(0)!TipoFase, loDt.Rows(0)!TipoMotivo, loDt.Rows(0)!SubEmpresa})
                GridEx1.MoveLast()
            End If
        Catch ex As LbControlError.cError
            ex.Mostrar()
        End Try
    End Sub

    Private Sub GridEX1_RowDoubleClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles GridEx1.RowDoubleClick
        If oAcceso.Leer Then
            Call Consultar()
        End If
    End Sub

    Private Sub btActualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btActualizar.Click
        Call Actualizar()
    End Sub

    Private Sub btConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btConsultar.Click
        If oAcceso.Leer Then
            Call Consultar()
        End If
    End Sub

    Private Sub btXML_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btXML.Click
        If GridEx1.GetRow Is Nothing Then Exit Sub
        Dim vcTransprod As New cTransProd
        vcTransprod.Recuperar(GridEx1.GetRow.Cells("TransProdId").Value)
        Dim xml As New PRepXML(vcTransprod)
        xml.ShowDialog()
    End Sub

    Private Sub btVerificada_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btVerificada.Click
        If GridEx1.GetRow Is Nothing Then Exit Sub
        Dim loTransprod As New cTransProd
        loTransprod.Recuperar(GridEx1.GetRow.Cells("TransProdId").Value)
        loTransprod.TipoMotivo = 0
        GridEx1.GetRow.Cells("TipoMotivo").Value = ""
        loTransprod.Grabar()
        oConexion.ConfirmarTran()
        GridEx1.Refresh()
        btVerificada.Enabled = False
        MsgBox(oMensaje.RecuperarDescripcion("I0184", New String() {loTransprod.Folio}), MsgBoxStyle.Information, oMensaje.RecuperarDescripcion("XMensajeI"))
    End Sub

    Private Sub btImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btImprimir.Click
        If GridEx1.GetRow Is Nothing Then Exit Sub
        Dim oRep As New RRepFactElectronica
        oRep.CONSULTAR(GridEx1.GetRow.Cells("TransProdId").Value)
    End Sub

    Private Sub btCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btCancelar.Click
        Dim lMFacturasElectronicas As New MFacturasElectronicas
        Dim dtNotasCredito As New DataTable
        If GridEx1.RowCount > 0 Then
            If (GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Or GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
                oTransProd = Nothing
                oTransProd = New cTransProd

                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

                Try
                    oTransProd.Recuperar(GridEx1.GetRow.Cells("TransProdId").Value)
                Catch ex As LbControlError.cError
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    ex.Mostrar()
                    Exit Sub
                End Try

                If oTransProd.TipoFase = 0 Then


                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    oConexion.DeshacerTran()
                    MsgBox(oMensaje.RecuperarDescripcion("E0043", New String() {lbGeneral.ClaveDescripcionVARValor("TRPFASE", oTransProd.TipoFase)}), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                    Exit Sub

                End If

                Try
                    dtNotasCredito = oTransProd.ObtenerNotaCreditoFactura(oTransProd.TransProdID)
                    If dtNotasCredito.Rows.Count > 0 Then
                        Dim sFolioNotas As String = ""
                        For Each dr As DataRow In dtNotasCredito.Rows
                            sFolioNotas = sFolioNotas + dr("Folio").ToString + " "
                        Next dr
                        Throw New LbControlError.cError("I0204", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(sFolioNotas, False)}, "", "", Me.oConexion)
                    End If
                Catch ex As LbControlError.cError
                    ex.Mostrar()
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    oConexion.DeshacerTran()
                    Exit Sub
                End Try

                Try
                    oTransProd.Tabla.Campos("MUsuarioId").Tipo = LbDatos.ETipo.Cadena
                    oTransProd.Bloquear()
                Catch ex As LbControlError.cError
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    oConexion.DeshacerTran()
                    MsgBox(oMensaje.RecuperarDescripcion("BI0003"), MsgBoxStyle.Information, oMensaje.RecuperarDescripcion("XMensajeI"))
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    Exit Sub
                End Try

                Me.Cursor = System.Windows.Forms.Cursors.Default
                If lMFacturasElectronicas.CANCELAR(oTransProd) Then
                    oTransProd.ModificarEn(GridEx1.DataSource)
                    If GridEx1.GetRow.Cells("TipoMotivo").Value.ToString = "" Then
                        GridEx1.GetRow.Cells("TipoMotivo").Value = ""
                    ElseIf GridEx1.GetRow.Cells("TipoMotivo").Value = "0" Then
                        GridEx1.GetRow.Cells("TipoMotivo").Value = ""
                    End If
                    Dim oTRPDatoFiscal As New ERMTRPLOG.cTRPDatoFiscal(oTransProd)
                    oTRPDatoFiscal.Recuperar(oTransProd.TransProdID)

                    btXML.Enabled = False
                End If
            End If
        End If
    End Sub
#End Region

End Class
