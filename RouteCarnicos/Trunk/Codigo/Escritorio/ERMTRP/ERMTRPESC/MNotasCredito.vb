Imports ERMTRPLOG
Imports BASMENLOG
Imports lbGeneral
Imports System.Collections.Generic

Public Class MNotasCredito

#Region " Variables "
    Private tModo As eModo
    Private oTransProd As New cTransProd
    Private oTRPDatoFiscal As cTRPDatoFiscal
    Private oAlmacen As New ERMALMLOG.cAlmacen
    Private oProducto As New ERMPROLOG.cProducto
    Private oMensaje As New CMensaje
    Private bHuboCambios As Boolean = False
    Private bCerrar As Boolean = False
    Private oConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private sComponente As String = "ERMTRPESC"
    Private htCampos As Hashtable = New Hashtable(20)
    Private htElemInterfaz As Hashtable = New Hashtable(10)
    Private bModificarTransProd As Boolean = False
    Private sNombre As String
    Private bModificandoDatos As Boolean = False
    Private oCliente As New ERMCLILOG.cCliente
    Private oConfiguracion As New ERMCONLOG.cConfiguracion
    Private oSubEmpresa As New ERMSEMLOG.cSubEmpresa
    Private oVendedor As New ERMVENLOG.cVendedor
    Private bEditarDatos As Boolean = False
    Private sFacturaId As String
    Private dFechaFactura As Date
    Private sEsquemaId As String
    Private sClienteClave As String
    Private nImporteNCR As Double
    Private nDescuentoNCR As Double
    Private nSubtotalNCR As Double
    Private nImpuestoNCR As Double
    Private nTotalNCR As Double
    Private nTotalFAC As Double
    Private nTotalDES As Double
    Private nTotalDEV As Double
    'Private nSubtotalDisp As Decimal
    'Private nImpuestoDisp As Decimal
    Private nSubtotalFactura As Double
    Private nSubtotalDev As Double
    Private nTotalFactura As Double
    Private nSaldoFactura As Double
    Private dtProductosDesc As DataTable
    Private dtProductoDesc As DataTable

    Dim strTerminalClave As String
    Dim strVendedorId As String
    Dim bIniciando As Boolean
#End Region

#Region " Métodos y Funciones "

    Public Function CREAR(ByRef prTransProd As cTransProd, ByVal SubEmpresasValidas() As ERMSEMLOG.cSubEmpresa) As Boolean
        Dim oFolio As New ERMFOLLOG.cFolio

        bIniciando = True
        'ebFolioFactura.Enabled = False
        'btBuscarFactura.Enabled = False

        dtProductoDesc = prTransProd.ObtenerProductoDescuento()
        If dtProductoDesc.Rows.Count = 0 Then
            Throw New LbControlError.cError("E0800")
        End If

        oConfiguracion.Recuperar()
        LlenarCbSubEmpresa(SubEmpresasValidas)
        cbSubEmpresa.SelectedIndex = 0
        oSubEmpresa.Recuperar(cbSubEmpresa.SelectedValue)


        Dim ldtTabla As DataTable = oVendedor.Tabla.Recuperar("USUId='" & lbGeneral.cParametros.UsuarioID & "' AND TipoEstado=1")
        If ldtTabla.Rows.Count > 0 Then
            strTerminalClave = ldtTabla.Rows(0)!TerminalClave
            strVendedorId = ldtTabla.Rows(0)!VendedorId
            bEditarDatos = ldtTabla.Rows(0)!EditarDatosFiscal

            Dim loVENRUT As New ERMVERLOG.Amesol.CVenRut
            If loVENRUT.TablaNodo.Recuperar("VendedorId='" & strVendedorId & "' AND TipoEstado=1").Rows.Count > 0 Then
                Throw New LbControlError.cError("E0798", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("XNotaCredito", True)})
            End If
        Else
            Throw New LbControlError.cError("E0797", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("XNotaCredito", True)})
        End If


        If oSubEmpresa.FoliosTerminal Then
            cbFolio.DataSource = oFolio.ObtenerFolioFiscal(strTerminalClave, Nothing, oSubEmpresa.SubEmpresaID, 2)
        Else
            cbFolio.DataSource = oFolio.ObtenerFolioFiscal(Nothing, strVendedorId, oSubEmpresa.SubEmpresaID, 2)
        End If
        'cbFolio.DataMember = "FolioFiscal"
        cbFolio.ValueMember = "FolioIdFOSId"
        cbFolio.DisplayMember = "Folio"
        cbFolio.SelectedValue = CType(cbFolio.DataSource, DataTable).Rows(0)!FolioIdFOSId
        ebFolioDatos.Text = CType(cbFolio.DataSource, DataTable).Rows(0)!Folio

        tModo = eModo.Crear
        oTransProd = prTransProd

        sNombre = Me.Name
        Me.Text = oMensaje.RecuperarDescripcion(sComponente & "_" & sNombre & "C")
        bIniciando = False
        Return IniciarPantalla()
    End Function

    Private Sub LlenarCbSubEmpresa()
        Dim subempresa As New ERMSEMLOG.cSubEmpresa()
        For Each R As DataRow In subempresa.RecuperarTabla().Rows
            cbSubEmpresa.Items.Add(R!NombreEmpresa, R!SubEmpresaID)
        Next
    End Sub

    Private Sub LlenarCbSubEmpresa(ByVal SubEmpresasValidas() As ERMSEMLOG.cSubEmpresa)
        For Each R As ERMSEMLOG.cSubEmpresa In SubEmpresasValidas
            cbSubEmpresa.Items.Add(R.NombreEmpresa, R.SubEmpresaID)
        Next
    End Sub

    Public Function CANCELAR(ByRef prTransProd As cTransProd) As Boolean
        tModo = eModo.Cancelar
        oTransProd = prTransProd
        oConfiguracion.Recuperar()

        sNombre = Me.Name
        Me.Text = oMensaje.RecuperarDescripcion(sComponente & "_" & sNombre & "CA")

        oTRPDatoFiscal = New cTRPDatoFiscal(oTransProd)
        LlenarCbSubEmpresa()
        bIniciando = True
        cbSubEmpresa.SelectedValue = oTransProd.SubEmpresaId
        bIniciando = False

        oTRPDatoFiscal.Recuperar(oTransProd.TransProdID)

        Return IniciarPantalla()
    End Function

    Public Function LEER(ByRef prTransProd As cTransProd) As Boolean
        tModo = eModo.Leer
        oTransProd = prTransProd
        oConfiguracion.Recuperar()

        sNombre = Me.Name
        Me.Text = oMensaje.RecuperarDescripcion(sComponente & "_" & sNombre & "L")

        oTRPDatoFiscal = New cTRPDatoFiscal(oTransProd)
        LlenarCbSubEmpresa()
        bIniciando = True
        cbSubEmpresa.SelectedValue = oTransProd.SubEmpresaId
        bIniciando = False
        oTRPDatoFiscal.Recuperar(oTransProd.TransProdID)
        Return IniciarPantalla()
    End Function

    Private Sub HabilitarDatosFiscal(ByVal bHabilitar As Boolean)
        ebRazonSocial.Enabled = bHabilitar
        ebRFC.Enabled = bHabilitar
        ebCalle.Enabled = bHabilitar
        ebExterior.Enabled = bHabilitar
        ebInterior.Enabled = bHabilitar
        ebColonia.Enabled = bHabilitar
        ebCodigoPostal.Enabled = bHabilitar
        ebReferencia.Enabled = bHabilitar
        ebLocalidad.Enabled = bHabilitar
        ebMunicipio.Enabled = bHabilitar
        ebEntidad.Enabled = bHabilitar
        ebPais.Enabled = bHabilitar
    End Sub

    Private Sub HabilitarDatosNota(ByVal bHabilitar As Boolean)
        cbSubEmpresa.Enabled = bHabilitar
        cbFolio.Enabled = bHabilitar
        ebFolioFactura.Enabled = bHabilitar
        btBuscarFactura.Enabled = bHabilitar
        cbTipoNota.Enabled = bHabilitar
        btMetodoPago.Enabled = bHabilitar
    End Sub

    Private Function IniciarPantalla() As Boolean
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        CrearObjetosCamposLogicos()
        CrearObjetosInterfaz()
        ConfigurarInterfaz()

        Me.TpDatosFiscales.Text = oMensaje.RecuperarDescripcion("XDatosFiscales")
        Me.TpGenerales.Text = oMensaje.RecuperarDescripcion("XGenerales")
        ebPorcDescuento.Enabled = False

        If tModo = eModo.Crear Then
            ebFecha.Text = oConexion.ObtenerFecha.ToShortDateString
            HabilitarDatosFiscal(bEditarDatos)
            HabilitarDatosNota(True)
        ElseIf tModo = eModo.Leer Then
            HabilitarDatosFiscal(False)
            HabilitarDatosNota(False)
        ElseIf tModo = eModo.Cancelar Then
            HabilitarDatosFiscal(False)
            HabilitarDatosNota(False)
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
        bHuboCambios = False

        If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
            oConexion.ConfirmarTran()
            Return True
        Else
            oConexion.DeshacerTran()
            Return False
        End If
    End Function

    Private Sub CrearObjetosCamposLogicos()
        CrearCampoLogico("SEM", "NombreEmpresa", CType(Me.lbSubEmpresa, Control), CType(Me.cbSubEmpresa, Control), True)
        CrearCampoLogico(oTransProd.Mnemonico, "Folio", CType(Me.lbFolio, Control), CType(Me.cbFolio, Control), True, "", True)
        CrearCampoLogico(oTransProd.Mnemonico, "Fecha", CType(Me.lbFecha, Control), CType(Me.ebFecha, Control), True)
        CrearCampoLogico(oTransProd.Mnemonico, "FacturaId", CType(Me.lbFactura, Control), CType(Me.ebFolioFactura, Control), True)
        CrearCampoLogico("TDF", "TipoNotaCredito", CType(Me.lbTipoNota, Control), CType(Me.cbTipoNota, Control), True)
        CrearCampoLogico("TPE", "DescuentoPor", CType(Me.lbPorcDescuento, Control), CType(Me.ebPorcDescuento, Control), True)

        CrearCampoLogico("TR", "PFolio", CType(Me.lbFolioDatos, Control), CType(Me.ebFolioDatos, Control), True)
        CrearCampoLogico("X", "Cliente", CType(Me.lbClienteDatos, Control), CType(Me.ebClienteDatos, Control), True)
        CrearCampoLogico("CLI", "RazonSocial", CType(Me.lbRazonSocial, Control), CType(Me.ebRazonSocial, Control), True)
        CrearCampoLogico("CLI", "IdFiscal", CType(Me.lbRFC, Control), CType(Me.ebRFC, Control), True)
        CrearCampoLogico("CLD", "Calle", CType(Me.lbCalle, Control), CType(Me.ebCalle, Control), True)
        CrearCampoLogico("CLD", "Numero", CType(Me.lbExterior, Control), CType(Me.ebExterior, Control))
        CrearCampoLogico("CLD", "NumInt", CType(Me.lbInterior, Control), CType(Me.ebInterior, Control))
        CrearCampoLogico("CLD", "Colonia", CType(Me.lbColonia, Control), CType(Me.ebColonia, Control))
        CrearCampoLogico("CLD", "CodigoPostal", CType(Me.lbCodigoPostal, Control), CType(Me.ebCodigoPostal, Control), True)
        CrearCampoLogico("CLD", "ReferenciaDom", CType(Me.lbReferencia, Control), CType(Me.ebReferencia, Control))
        CrearCampoLogico("CLD", "Localidad", CType(Me.lbLocalidad, Control), CType(Me.ebLocalidad, Control))
        CrearCampoLogico("CLD", "Poblacion", CType(Me.lbMunicipio, Control), CType(Me.ebMunicipio, Control), True)
        CrearCampoLogico("CLD", "Entidad", CType(Me.lbEntidad, Control), CType(Me.ebEntidad, Control), True)
        CrearCampoLogico("CLD", "Pais", CType(Me.lbPais, Control), CType(Me.ebPais, Control), True)
    End Sub

    Private Function CrearCampoLogico(ByVal pvMnemonico As String, ByVal pvCampo As String, ByRef prCtrlEtiqueta As System.Windows.Forms.Control, ByRef prCtrlCaptura As System.Windows.Forms.Control, Optional ByVal pvRequerido As Boolean = False, Optional ByVal pvValorReferencia As String = "", Optional ByVal pvLlave As Boolean = False) As ManejoCampoLogico
        Dim oCL As ManejoCampoLogico
        oCL = New ManejoCampoLogico(pvMnemonico, pvCampo, prCtrlEtiqueta, prCtrlCaptura, pvRequerido, pvValorReferencia, pvLlave)
        htCampos.Add(oCL.Campo, oCL)
        oCL.CtrlCaptura.Tag = oCL
        Return oCL
    End Function

    Private Sub CrearObjetosInterfaz()
        'aqui se agregan los botones, etc
        Dim oEI As ManejoElementoInterfaz


        oEI = New ManejoElementoInterfaz(sComponente & "_" & Me.Name & "_gbP", CType(Me.gbProductos, Control), True, False)
        htElemInterfaz.Add(oEI.Nombre, oEI)

        oEI = New ManejoElementoInterfaz("XTotalFacturado", CType(Me.lbTotalFAC, Control), True, False)
        htElemInterfaz.Add(oEI.Nombre, oEI)
        oEI = New ManejoElementoInterfaz("XSaldoDisponible", CType(Me.lbTotalDisp, Control), True, False)
        htElemInterfaz.Add(oEI.Nombre, oEI)
        oEI = New ManejoElementoInterfaz("XImporte", CType(Me.lbImporte, Control), True, False)
        htElemInterfaz.Add(oEI.Nombre, oEI)
        oEI = New ManejoElementoInterfaz("XDescuento", CType(Me.lbDescuento, Control), True, False)
        htElemInterfaz.Add(oEI.Nombre, oEI)
        oEI = New ManejoElementoInterfaz("XSubtotal", CType(Me.lbSubtotal, Control), True, False)
        htElemInterfaz.Add(oEI.Nombre, oEI)
        oEI = New ManejoElementoInterfaz("XImpuesto", CType(Me.lbImpuesto, Control), True, False)
        htElemInterfaz.Add(oEI.Nombre, oEI)
        oEI = New ManejoElementoInterfaz("XTotal", CType(Me.lbTotal, Control), True, False)
        htElemInterfaz.Add(oEI.Nombre, oEI)

        oEI = New ManejoElementoInterfaz("BTAceptar", CType(Me.BtAceptar, Control))
        htElemInterfaz.Add(oEI.Nombre, oEI)
        oEI = New ManejoElementoInterfaz("BTCancelar", CType(Me.BtCancelar, Control))
        htElemInterfaz.Add(oEI.Nombre, oEI)
    End Sub

    Private Sub ConfigurarInterfaz()
        Dim oEI As ManejoElementoInterfaz
        Dim oCL As ManejoCampoLogico
        Dim lToolTip As New System.Windows.Forms.ToolTip

        'Titulos Controles
        For Each oCL In htCampos.Values
            oCL.FijarTexto(oMensaje)
            oCL.FijarTooltip(oMensaje, lToolTip)
            oCL.CargarValorReferencia()
        Next
        lToolTip.SetToolTip(ebRazonSocial, "CLIRazonSocial")

        'Titulos Botones
        For Each oEI In htElemInterfaz.Values
            oEI.FijarTexto(oMensaje)
            oEI.FijarTooltip(oMensaje, lToolTip)
        Next

        lbGeneral.LlenarComboBox(cbTipoNota, "TIPNOT")
        ConfiguraGrid()

        bHuboCambios = False
    End Sub

    Public Sub ConfiguraGrid()
        Select Case tModo
            Case eModo.Crear
                PonerTitulosGrid()
            Case eModo.Leer, eModo.Cancelar
                CargarDatos()
                PonerTitulosGrid()
                ActualizarGridProductos()
        End Select
    End Sub

    Private Sub PonerTitulosGrid()
        With grProductos.RootTable
            For Each lColumna As Janus.Windows.GridEX.GridEXColumn In .Columns
                lColumna.Caption = oMensaje.RecuperarDescripcion(lColumna.Tag)
                lColumna.HeaderToolTip = oMensaje.RecuperarDescripcion(lColumna.Tag & "T")
                lColumna.EditType = Janus.Windows.GridEX.EditType.NoEdit
            Next
        End With
        lbGeneral.LlenarColumna(grProductos.RootTable.Columns("TipoUnidad"), "UNIDADV")
    End Sub

    Private Sub CargarDatos()
        bIniciando = True
        Dim dtFactura As DataTable
        dtFactura = oTransProd.ObtenerFacturaNotaCredito(oTransProd.FacturaID)
        If dtFactura.Rows.Count > 0 Then
            Dim nTipoNota As Short = oConexion.EjecutarConsulta("select TipoNotaCredito from TRPDatoFiscal where TransProdID = '" & oTransProd.TransProdID & "'").Rows(0)!TipoNotaCredito
            sClienteClave = dtFactura.Rows(0)("ClienteClave")
            RecuperarDatosCliente()

            With oTransProd
                Me.cbFolio.Text = .Folio
                Me.ebFolioDatos.Text = .Folio
                Me.ebFecha.Text = .FechaHoraAlta
                Me.ebFolioFactura.Text = dtFactura.Rows(0)("Folio")
                Me.ebTotalFAC.Text = dtFactura.Rows(0)("TotalFAC")
                Me.ebTotalDisp.Text = dtFactura.Rows(0)("Disponible")
                If nTipoNota = 1 Then
                    Me.ebPorcDescuento.Value = .DescVendPor / 100
                End If
                Me.cbTipoNota.SelectedValue = nTipoNota

                If Not IsNothing(oTRPDatoFiscal.MetodoPago) AndAlso oTRPDatoFiscal.MetodoPago.Length > 0 Then
                    Dim Metodos As String() = oTRPDatoFiscal.MetodoPago.Split(",")
                    Dim Bancos As String()
                    If Not IsNothing(oTRPDatoFiscal.Banco) AndAlso oTRPDatoFiscal.Banco.Length > 0 Then
                        Bancos = oTRPDatoFiscal.Banco.Split(",")
                    End If
                    Dim Cuentas As String()
                    If Not IsNothing(oTRPDatoFiscal.NumCtaPago) AndAlso oTRPDatoFiscal.NumCtaPago.Length > 0 Then
                        Cuentas = oTRPDatoFiscal.NumCtaPago.Split(",")
                    End If

                    Dim aMetodos As New ArrayList
                    Dim sBanco As String = String.Empty
                    Dim sCuenta As String = String.Empty
                    Dim indice As Integer = 0
                    For Each sMetodo As String In Metodos
                        sBanco = String.Empty
                        sCuenta = String.Empty
                        If (Not IsNothing(Bancos) AndAlso indice < Bancos.Length) Then
                            sBanco = Bancos(indice)
                        End If
                        If (Not IsNothing(Cuentas) AndAlso indice < Cuentas.Length) Then
                            sCuenta = Cuentas(indice)
                        End If
                        Dim oMetodo As New IMetodosPago.MetodoPago(sMetodo, IIf(sBanco = "*", "", sBanco), IIf(sCuenta = "*", "", sCuenta))
                        aMetodos.Add(oMetodo)
                        indice += 1
                    Next
                    grMetodosPago.DataSource = aMetodos
                End If

                grProductos.DataSource = oTransProd.ObtenerProductoNotaCredito(.TransProdID)

                ebImporte.Text = .SubTDetalle + .DescuentoImp
                ebDescuento.Text = .DescuentoImp
                ebSubTotal.Text = .SubTotal
                ebImpuesto.Text = oTransProd.dValido(.Impuesto, True)
                ebTotal.Text = .Total
            End With
        End If
        bIniciando = False
    End Sub

    Private Sub RecuperarDatosCliente()
        Dim i As Integer = 0
        Call LimpiarDatosCliente()
        oCliente.Recuperar(sClienteClave)

        ebClienteDatos.Text = oCliente.Clave & " - " & oCliente.NombreCorto
        ebRazonSocial.Text = oCliente.RazonSocial
        ebRFC.Text = oCliente.IdFiscal
        Me.ebLocalidad.Text = oCliente.ClienteDomicilio(0).Localidad.ToString

        For i = 0 To oCliente.ClienteDomicilio.Conteo - 1
            With oCliente.ClienteDomicilio(i)
                If .Tipo = 1 Then
                    ebCalle.Text = .Calle
                    ebExterior.Text = .Numero
                    ebInterior.Text = .NumInt
                    ebColonia.Text = .Colonia
                    ebEntidad.Text = .Entidad
                    ebMunicipio.Text = .Poblacion
                    ebPais.Text = .Pais
                    ebCodigoPostal.Text = .CodigoPostal
                    ebReferencia.Text = .ReferenciaDom
                    Me.ebLocalidad.Text = .Localidad
                    Exit For
                End If
            End With
        Next

        ''Complemento
        'Dim oAddenda As ERMADDLOG.cAddenda = New ERMADDLOG.cAddenda()
        'Dim dtCamposSolicitados As DataTable = oAddenda.ObtenerSolicitadosCliente(oCliente.ClienteClave)
        'If (dtCamposSolicitados.Rows.Count > 0) Then
        '    Dim dtCapturados As DataTable = oTransProd.AddendaFactura.ToDataTable
        '    Dim icont As Integer = dtCamposSolicitados.Rows.Count
        '    TpComplemento.Visible = True
        '    Dim PosX As Integer = 11
        '    Dim PosY As Integer = 8
        '    Dim drs() As DataRow
        '    For Each dr As DataRow In dtCamposSolicitados.Rows
        '        Dim ctrl As New CtrlCampos
        '        ctrl.AgregarCampo(dr("Valor"), dr("ADDDID"), dr("Requerido"))
        '        ctrl.TabIndex = icont
        '        drs = dtCapturados.Select("ADDDID='" & dr("ADDDID") & "'")
        '        If drs.Length > 0 Then
        '            ctrl.Valor = drs(0)("Valor")
        '        End If
        '        TabControlPanel3.Controls.Add(ctrl)
        '        ctrl.Dock = DockStyle.Top
        '        ctrl.Enabled = (tModo = eModo.Crear)
        '        icont -= 1
        '    Next
        'Else
        '    TpComplemento.Visible = False
        'End If
        'dtCamposSolicitados.Dispose()

        If tModo = eModo.Crear Then
            HabilitarDatosFiscal(bEditarDatos)
        End If
    End Sub

    Private Sub ValidarFactura()
        Dim i As Integer = 0
        Dim sFolioFactura As String
        Dim sConsulta As String

        sFolioFactura = lbGeneral.ValidaFormatoSQLString(ebFolioFactura.Text)
        'sConsulta = "select FAC.TransProdID, VIS.ClienteClave, FAC.Folio, FAC.FechaFacturacion, FAC.Subtotal as SubtotalFAC, FAC.Impuesto as ImpuestoFAC, FAC.Total as TotalFAC, "
        'sConsulta &= "isnull((select SUM(Subtotal) from TransProd NCR where NCR.FacturaID = FAC.TransProdId and NCR.Tipo = 10 and NCR.TipoFase <> 0), 0) as SubtotalDES, "
        'sConsulta &= "isnull((select SUM(Impuesto) from TransProd NCR where NCR.FacturaID = FAC.TransProdId and NCR.Tipo = 10 and NCR.TipoFase <> 0), 0) as ImpuestoDES, "
        'sConsulta &= "isnull((select SUM(Total) from TransProd NCR where NCR.FacturaID = FAC.TransProdId and NCR.Tipo = 10 and NCR.TipoFase <> 0), 0) as TotalDES "
        'sConsulta &= "from TransProd FAC "
        'sConsulta &= "inner join Visita VIS on FAC.VisitaClave = VIS.VisitaClave and FAC.DiaClave = VIS.DiaClave "
        'sConsulta &= "where FAC.Tipo = 8 and FAC.TipoFase <> 0 and FAC.Folio = '" & sFolioFactura & "' "

        sConsulta = "select FAC.TransProdID, VIS.ClienteClave, FAC.Folio, FAC.FechaFacturacion, FAC.FechaHoraAlta, FAC.Subtotal, FAC.Total as TotalFAC, "
        sConsulta &= "isnull((select SUM(Total) from TransProd NCR inner join TRPDatoFiscal TDF on NCR.TransProdID = TDF.TransProdID where NCR.FacturaID = FAC.TransProdId and NCR.Tipo = 10 and NCR.TipoFase <> 0 and TDF.TipoNotaCredito = 1), 0) as TotalDES, "
        sConsulta &= "isnull((select SUM(Total) from TransProd NCR inner join TRPDatoFiscal TDF on NCR.TransProdID = TDF.TransProdID where NCR.FacturaID = FAC.TransProdId and NCR.Tipo = 10 and NCR.TipoFase <> 0 and TDF.TipoNotaCredito = 2), 0) as TotalDEV "
        'sConsulta &= "isnull((select SUM(Subtotal) from TransProd NCR inner join TRPDatoFiscal TDF on NCR.TransProdID = TDF.TransProdID where NCR.FacturaID = FAC.TransProdId and NCR.Tipo = 10 and NCR.TipoFase <> 0 and TDF.TipoNotaCredito = 2), 0) as SubtotalDEV "
        sConsulta &= "from TransProd FAC "
        sConsulta &= "inner join Visita VIS on FAC.VisitaClave = VIS.VisitaClave and FAC.DiaClave = VIS.DiaClave "
        sConsulta &= "where FAC.Tipo = 8 and FAC.TipoFase <> 0 and FAC.Folio = '" & sFolioFactura & "' "

        Dim dtFactura As DataTable
        dtFactura = oTransProd.Tabla.Conexion.EjecutarConsulta(sConsulta)
        If dtFactura.Rows.Count <= 0 Then
            Throw New LbControlError.cError("BE0003", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(lbFactura.Text)})
        Else
            nSaldoFactura = dtFactura.Rows(0)("TotalFAC") - dtFactura.Rows(0)("TotalDES") - dtFactura.Rows(0)("TotalDEV")
            If Math.Round(nSaldoFactura, 0) > 0 Then
                nTotalFactura = dtFactura.Rows(0)("TotalFAC") - dtFactura.Rows(0)("TotalDEV")
                nSubtotalDev = oTransProd.ObtenerSubtotalDevoluciones(sFacturaId, sClienteClave, dFechaFactura)
                nSubtotalFactura = dtFactura.Rows(0)("Subtotal") - nSubtotalDev

                sFacturaId = dtFactura.Rows(0)("TransProdId")
                sClienteClave = dtFactura.Rows(0)("ClienteClave")
                nTotalFAC = dtFactura.Rows(0)("TotalFAC")
                nTotalDES = dtFactura.Rows(0)("TotalDES")
                nTotalDEV = dtFactura.Rows(0)("TotalDEV")
                'nSubtotalDisp = nTotalFAC - nTotalDEV
                'nImpuestoDisp = dtFactura.Rows(0)("ImpuestoFAC") - dtFactura.Rows(0)("ImpuestoDES")
                ebFolioFactura.Text = dtFactura.Rows(0)("Folio")
                ebTotalFAC.Text = nTotalFactura
                'ebTotalDES.Text = nTotalDES + nTotalDEV
                ebTotalDisp.Text = nSaldoFactura
                RecuperarDatosCliente()
                LlenarGridProductos()
                ReiniciarTotales()
            Else
                'TODO: Mensaje no hay disponible
                Throw New LbControlError.cError("NoHayDisponible")
            End If
        End If
    End Sub

    Private Sub ValidarCampo(ByVal pvCampo As String)
        Dim oCL As ManejoCampoLogico = htCampos(pvCampo)
        If oCL.Requerido Then
            If oCL.CtrlCaptura.GetType Is GetType(Janus.Windows.EditControls.UIComboBox) Then
                With CType(oCL.CtrlCaptura, Janus.Windows.EditControls.UIComboBox)
                    If .SelectedValue Is Nothing Then
                        oCL.CtrlCaptura.Focus()
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(oCL.CtrlEtiqueta.Text)})
                    End If
                End With
            ElseIf oCL.CtrlCaptura.GetType Is GetType(Janus.Windows.GridEX.EditControls.EditBox) Then
                With CType(oCL.CtrlCaptura, Janus.Windows.GridEX.EditControls.EditBox)
                    If .Text = "" Then
                        oCL.CtrlCaptura.Focus()
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(oCL.CtrlEtiqueta.Text)})
                    End If


                End With
            ElseIf oCL.CtrlCaptura.GetType Is GetType(Janus.Windows.GridEX.EditControls.NumericEditBox) Then
                With CType(oCL.CtrlCaptura, Janus.Windows.GridEX.EditControls.NumericEditBox)
                    If .Value Is Nothing Then
                        oCL.CtrlCaptura.Focus()
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(oCL.CtrlEtiqueta.Text)})
                    End If
                    If UCase(pvCampo) = UCase("DescuentoPor").ToString Then
                        If cbTipoNota.SelectedValue = 1 And .Value = 0 Then
                            oCL.CtrlCaptura.Focus()
                            Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(oCL.CtrlEtiqueta.Text)})
                        End If
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub ActualizarGridProductos()
        If cbTipoNota.SelectedValue = 1 Then 'Devolucion
            grProductos.RootTable.Columns("Disponible").Visible = False
            grProductos.RootTable.Columns("Devolucion").Visible = False
            grProductos.RootTable.Columns("TipoUnidad").Visible = False
            grProductos.RootTable.Columns("Precio").Visible = False
            grProductos.RootTable.Columns("Subtotal").Visible = False
            grProductos.RootTable.Columns("Descuento").Visible = False
            Me.lbImporte.Visible = False
            Me.ebImporte.Visible = False
            Me.lbDescuento.Visible = False
            Me.ebDescuento.Visible = False
        Else
            grProductos.RootTable.Columns("Disponible").Visible = True
            grProductos.RootTable.Columns("Devolucion").Visible = True
            grProductos.RootTable.Columns("TipoUnidad").Visible = True
            grProductos.RootTable.Columns("Precio").Visible = True
            grProductos.RootTable.Columns("Subtotal").Visible = True
            grProductos.RootTable.Columns("Descuento").Visible = True
            Me.lbImporte.Visible = True
            Me.ebImporte.Visible = True
            Me.lbDescuento.Visible = True
            Me.ebDescuento.Visible = True
        End If
    End Sub

    Private Sub LlenarGridProductos()
        Dim dtProducto As DataTable
        If cbTipoNota.SelectedValue = 2 Then 'Devolucion
            dtProducto = oTransProd.ObtenerProductoFactura(sFacturaId)
            grProductos.RootTable.Columns("Devolucion").EditType = Janus.Windows.GridEX.EditType.TextBox
            grProductos.DataSource = dtProducto
        ElseIf cbTipoNota.SelectedValue = 1 Then 'Descuento
            dtProductosDesc = oTransProd.ObtenerProductoFacturaDescuento(sFacturaId)
            grProductos.RootTable.Columns("Devolucion").EditType = Janus.Windows.GridEX.EditType.NoEdit
            dtProductoDesc = oTransProd.ObtenerProductoDescuento()
            grProductos.DataSource = dtProductoDesc
        End If
    End Sub

#End Region

#Region " Eventos "

    Private Sub cbFolio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFolio.SelectedIndexChanged
        ebFolioDatos.Text = cbFolio.SelectedItem.Text
    End Sub

    Private Sub ebFolioFactura_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebFolioFactura.Validated
        If ebFolioFactura.Text <> "" Then
            Try
                ValidarFactura()
                epErrores.SetError(btBuscarFactura, "")
            Catch ex As LbControlError.cError
                epErrores.SetError(btBuscarFactura, ex.Mensaje)
                oCliente.Limpiar()
            End Try
        Else
            Call LimpiarDatosCliente()
            epErrores.SetError(btBuscarFactura, oMensaje.RecuperarDescripcion("BE0001 ", New String() {oMensaje.RecuperarDescripcion("TRPFacturaId")}))
        End If
        bHuboCambios = True
    End Sub

    Sub LimpiarDatosCliente()
        ebRazonSocial.Text = ""
        ebRFC.Text = ""
        ebCalle.Text = ""
        ebExterior.Text = ""
        ebInterior.Text = ""
        ebColonia.Text = ""
        ebEntidad.Text = ""
        ebMunicipio.Text = ""
        ebLocalidad.Text = ""
        ebPais.Text = ""
        ebCodigoPostal.Text = ""
        ebReferencia.Text = ""
        ebRazonSocial.Enabled = False
        ebRFC.Enabled = False
        ebCalle.Enabled = False
        ebExterior.Enabled = False
        ebInterior.Enabled = False
        ebColonia.Enabled = False
        ebCodigoPostal.Enabled = False
        ebReferencia.Enabled = False
        ebLocalidad.Enabled = False
        ebMunicipio.Enabled = False
        ebEntidad.Enabled = False
        ebPais.Enabled = False
    End Sub

    Private Sub ReiniciarTotales()
        nImporteNCR = 0
        nDescuentoNCR = 0
        nSubtotalNCR = 0
        nImpuestoNCR = 0
        nTotalNCR = 0

        ebPorcDescuento.Value = 0
        ebImporte.Text = nImporteNCR
        ebDescuento.Text = nDescuentoNCR
        ebSubTotal.Text = nSubtotalNCR
        ebImpuesto.Text = oTransProd.dValido(nImpuestoNCR, True)
        ebTotal.Text = nTotalNCR
    End Sub

    Private Sub cbSubEmpresa_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSubEmpresa.SelectedValueChanged
        If Not bIniciando Then
            oSubEmpresa.Recuperar(cbSubEmpresa.SelectedValue)
            Dim oFolio As New ERMFOLLOG.cFolio

            If oSubEmpresa.FoliosTerminal Then
                cbFolio.DataSource = oFolio.ObtenerFolioFiscal(strTerminalClave, Nothing, oSubEmpresa.SubEmpresaID, 2)
            Else
                cbFolio.DataSource = oFolio.ObtenerFolioFiscal(Nothing, strVendedorId, oSubEmpresa.SubEmpresaID, 2)
            End If
            cbFolio.SelectedValue = CType(cbFolio.DataSource, DataTable).Rows(0)!FolioIdFOSId
            ebFolioDatos.Text = CType(cbFolio.DataSource, DataTable).Rows(0)!Folio

            ConfiguraGrid()
        End If
    End Sub

    Private Sub cbTipoNota_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTipoNota.SelectedValueChanged
        If bIniciando Then Exit Sub
        ebPorcDescuento.Enabled = (cbTipoNota.SelectedValue = 1)
        ebPorcDescuento.Text = 0
        ebTotalFAC.Text = nTotalFactura
        'ebTotalDES.Text = nTotalDES
        ebTotalDisp.Text = nSaldoFactura
        ReiniciarTotales()
        LlenarGridProductos()
        ActualizarGridProductos()
        epErrores.SetError(cbTipoNota, "")
    End Sub

    Private Sub ControlesActivo_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFolio.Validated, ebFecha.Validated, cbTipoNota.Validated, ebFolioDatos.Validated, ebRazonSocial.Validated, ebRFC.Validated, ebCalle.Validated, ebExterior.Validated, ebInterior.Validated, ebColonia.Validated, ebCodigoPostal.Validated, ebReferencia.Validated, ebLocalidad.Validated, ebMunicipio.Validated, ebEntidad.Validated, ebPais.Validated, cbSubEmpresa.Validated
        Dim oCL As ManejoCampoLogico
        oCL = CType(sender.tag, ManejoCampoLogico)

        If oCL.Requerido Then
            If sender.GetType Is GetType(Janus.Windows.EditControls.UIComboBox) Then
                With CType(sender, Janus.Windows.EditControls.UIComboBox)
                    If .SelectedValue Is Nothing Then
                        epErrores.SetError(sender, oMensaje.RecuperarDescripcion("BE0001", New String() {oCL.CtrlEtiqueta.Text}))
                        Exit Sub
                    End If
                End With
            ElseIf sender.GetType Is GetType(Janus.Windows.GridEX.EditControls.EditBox) Then
                With CType(sender, Janus.Windows.GridEX.EditControls.EditBox)
                    If .Text = "" Then
                        epErrores.SetError(sender, oMensaje.RecuperarDescripcion("BE0001", New String() {oCL.CtrlEtiqueta.Text}))
                        Exit Sub
                    End If

                    Select Case UCase(.Name).ToString
                        Case UCase("ebRFC").ToString
                            Dim rfcValidar As String = .Text
                            If rfcValidar.Replace("-", "").ToString.Length > 13 Then
                                epErrores.SetError(sender, oMensaje.RecuperarDescripcion("E0718", New String() {"RFC", "14"}))
                                Exit Sub
                            End If
                    End Select

                End With
            ElseIf sender.GetType Is GetType(Janus.Windows.GridEX.EditControls.NumericEditBox) Then
                With CType(sender, Janus.Windows.GridEX.EditControls.NumericEditBox)
                    If .Value Is Nothing Then
                        epErrores.SetError(sender, oMensaje.RecuperarDescripcion("BE0001", New String() {oCL.CtrlEtiqueta.Text}))
                        Exit Sub
                    End If
                End With
            End If
            epErrores.SetError(sender, "")
        End If

        bHuboCambios = True
    End Sub

    Private Function CrearAgendaVendedor(ByVal pvDiaClave As String, ByVal pvVendedorId As String, ByVal pvClienteClave As String) As Boolean
        Dim sCmd As String = "select count(*) from AgendaVendedor where DiaClave = '" + pvDiaClave + "' and VendedorId = '" + pvVendedorId + "' and ClienteClave = '" + pvClienteClave + "'"
        If Convert.ToInt32(oConexion.EjecutarComandoScalar(sCmd)) = 0 Then
            sCmd = "select isnull(MAX(Orden), 0) + 1 as Orden from AgendaVendedor where DiaClave = '" + pvDiaClave + "' and VendedorId = '" + pvVendedorId + "'"
            Dim nOrden As Integer = Convert.ToInt32(oConexion.EjecutarComandoScalar(sCmd))

            sCmd = "select ALM.Clave from VENCentroDistHist VCH "
            sCmd += "inner join Almacen ALM on VCH.AlmacenId = ALM.AlmacenID "
            sCmd += "where VCH.VendedorId = '" + pvVendedorId + "' and GETDATE() between VCH.VCHFechaInicial and VCH.FechaFinal "
            Dim sCEDI As String = Convert.ToString(oConexion.EjecutarComandoScalar(sCmd))

            sCmd = "insert into AgendaVendedor (DiaClave, VendedorId, FrecuenciaClave, RUTClave, Orden, ClienteClave, ClaveCEDI) "
            sCmd += "values ('" + pvDiaClave + "', '" + pvVendedorId + "', 'FRECPV', 'RUTF00', " + nOrden.ToString() + " , '" + pvClienteClave + "', '" + sCEDI + "') "
            Return (Convert.ToInt32(oConexion.EjecutarComando(sCmd)) > 0)
        End If
        Return True
    End Function

    Private Sub BtAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAceptar.Click
        Me.DialogResult = Windows.Forms.DialogResult.None
        Me.Cursor = Cursors.WaitCursor
        BtAceptar.Enabled = False
        BtCancelar.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Try
            Select Case tModo
                Case eModo.Crear
                    oTransProd.Limpiar()
                    'Valida los campos requeridos
                    Dim lsCamposValidar As String() = {"NombreEmpresa", "Folio", "FacturaId", "TipoNotaCredito", "DescuentoPor"}
                    Try
                        For Each lsCampo As String In lsCamposValidar
                            ValidarCampo(lsCampo)
                        Next
                    Catch ex As LbControlError.cError
                        TabFacturacion.SelectedTab = TpGenerales
                        MsgBox(ex.Mensaje, MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                        Exit Sub
                    End Try

                    'Valida que tenga pedidos asignados
                    'If grProductos.RowCount <= 0 Then
                    '    TabFacturacion.SelectedTab = TpGenerales
                    '    MsgBox(oMensaje.RecuperarDescripcion("E0062"), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                    '    Exit Sub
                    'Else
                    Dim bHayProductoSeleccionado As Boolean = False
                    For Each rwProducto As Janus.Windows.GridEX.GridEXRow In grProductos.GetRows
                        If rwProducto.Cells("Devolucion").Value > 0 Then bHayProductoSeleccionado = True
                    Next
                    If Not bHayProductoSeleccionado Then
                        TabFacturacion.SelectedTab = TpGenerales
                        MsgBox(oMensaje.RecuperarDescripcion("E0794"), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                        Exit Sub
                    End If
                    'End If

                    'Valida que el Usuario que genera la factura tenga un vendedor asignado y no existan registros en VENRUT
                    Dim ldtTabla As DataTable = oVendedor.Tabla.Recuperar("USUId='" & lbGeneral.cParametros.UsuarioID & "' AND TipoEstado=1")
                    If ldtTabla.Rows.Count <= 0 Then
                        MsgBox(oMensaje.RecuperarDescripcion("E0797", New String() {oMensaje.RecuperarDescripcion("XNotaCredito")}), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                        Exit Sub
                    End If

                    Dim lsVendedorId As String = ldtTabla.Rows(0)!VendedorId
                    Dim oVENRUT As New ERMVERLOG.Amesol.CVenRut
                    If oVENRUT.TablaNodo.Recuperar("VendedorId='" & lsVendedorId & "' AND TipoEstado=1").Rows.Count > 0 Then
                        MsgBox(oMensaje.RecuperarDescripcion("E0798", New String() {oMensaje.RecuperarDescripcion("XNotaCredito")}), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                        Exit Sub
                    End If

                    'Validar que se haya seleccionado el metodo de pago para las versiones 2.2 y 3.1
                    If oSubEmpresa.VersionCFD = 3 Or oSubEmpresa.VersionCFD = 4 Then
                        If grMetodosPago.RowCount <= 0 Then
                            MsgBox(oMensaje.RecuperarDescripcion("E0867", New String() {lbMetodoPago.Text}), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                            Exit Sub
                        End If
                    End If

                    'Valida que los Impuestos no hayan cambiado y si VigenciaImpuesto es así, los recalcula
                    Dim lnSubTotal As Double = 0
                    Dim lnImpuesto As Double = 0
                    Dim lnTotal As Double = 0
                    Dim lbImpuestosMod As Boolean = False
                    Dim lsTransProdId As String = lbGeneral.cKeyGen.KEYGEN(0)

                    'For Each lrRow As Janus.Windows.GridEX.GridEXRow In grProductos.GetRows
                    '    Dim loTransProd As New ERMTRPLOG.cTransProd
                    '    loTransProd.Recuperar(lrRow.Cells("TransProdId").Value)
                    '    If loTransProd.VigenciaImpuesto(oConexion.ObtenerFecha) Then
                    '        lbImpuestosMod = True
                    '    End If

                    '    lnSubTotal += loTransProd.SubTotal
                    '    lnImpuesto += loTransProd.Impuesto
                    '    lnTotal += loTransProd.Total

                    '    'Modificar los Pedidos
                    '    loTransProd.FacturaID = lsTransProdId
                    '    loTransProd.TipoFase = 3
                    '    loTransProd.FechaFacturacion = oConexion.ObtenerFecha
                    '    loTransProd.Grabar()
                    'Next

                    'If lbImpuestosMod Then
                    '    MsgBox(oMensaje.RecuperarDescripcion("I0002"), MsgBoxStyle.Information, oMensaje.RecuperarDescripcion("XMensajeI"))
                    'End If

                    'Validar Ruta Tempora
                    Dim loRuta As New ERMRUTLOG.cRuta
                    Dim lsRUTClave As String = "RUTF00"
                    If Not loRuta.Existe(lsRUTClave) Then
                        loRuta.RUTClave = lsRUTClave
                        loRuta.Descripcion = "Ruta de Facturación en Escritorio"
                        loRuta.Tipo = 2
                        loRuta.TipoEstado = 1
                        loRuta.Inventario = False
                        loRuta.Insertar()
                        loRuta.Grabar()
                    End If

                    'Valida Dia
                    Dim loDia As New ERMDIALOG.CDiaTrabajo
                    Dim lsDiaClave As String = oConexion.ObtenerFecha.ToString("dd/MM/yyyy")
                    If Not loDia.Existe(oConexion.ObtenerFecha.ToString("dd/MM/yyyy")) Then
                        loDia.DiaClave = lsDiaClave
                        loDia.Referencia = oConexion.ObtenerFecha.ToString("dddd")
                        loDia.Estado = 1
                        loDia.FechaCaptura = oConexion.ObtenerFecha
                        loDia.Insertar()
                        loDia.Grabar()
                    End If

                    'Valida Visita
                    Dim lsVisitaClave As String = lbGeneral.cKeyGen.KEYGEN(0)
                    Dim ldtVisita As DataTable = oConexion.EjecutarConsulta("SELECT * FROM Visita WHERE DiaClave='" & lsDiaClave & "' AND ClienteClave='" & oCliente.ClienteClave & "'")
                    If ldtVisita.Rows.Count <= 0 Then
                        lsVisitaClave = lbGeneral.cKeyGen.KEYGEN(0)
                        oConexion.EjecutarComando("INSERT INTO Visita (VisitaClave, DiaClave, ClienteClave, VendedorId, RUTClave, Numero, FechaHoraInicial, FechaHoraFinal, TipoEstado, FueraFrecuencia, CodigoLeido, MFechaHora, MUsuarioId) Values ('" & lsVisitaClave & "','" & lsDiaClave & "','" & oCliente.ClienteClave & "', '" & lsVendedorId & "', '" & lsRUTClave & "', 1, GETDATE(), GETDATE(), 1, 0, 0, GETDATE(), '" & lbGeneral.cParametros.UsuarioID & "')")
                    Else
                        lsVisitaClave = ldtVisita.Rows(0)!VisitaClave
                    End If

                    'Validar Frecuencia 
                    Dim oFrecuencia As ERMFRELOG.cFrecuencia = New ERMFRELOG.cFrecuencia
                    If Not oFrecuencia.Existe("FRECPV") Then
                        oFrecuencia.FrecuenciaClave = "FRECPV"
                        oFrecuencia.Descripcion = "Frecuencia de ventas en mostrador"
                        oFrecuencia.Tipo = 1
                        oFrecuencia.FechaInicio = oConexion.ObtenerFecha()
                        oFrecuencia.FechaFinal = New System.DateTime(9999, 1, 1)
                        oFrecuencia.UnidadInicio = 1
                        oFrecuencia.Repeticion = 6
                        oFrecuencia.Intervalo = 1
                        oFrecuencia.MUsuarioID = lbGeneral.cParametros.UsuarioID
                        oFrecuencia.Insertar()
                        oFrecuencia.Grabar()
                    End If


                    'Validar AgendaVendedor
                    CrearAgendaVendedor(lsDiaClave, lsVendedorId, oCliente.ClienteClave)



                    'Genera Nota de credito
                    oTransProd.TransProdID = lsTransProdId
                    oTransProd.VisitaClave = lsVisitaClave
                    oTransProd.DiaClave = lsDiaClave
                    oTransProd.Folio = cbFolio.SelectedItem.Text
                    oTransProd.Tipo = 10
                    oTransProd.TipoFase = 1
                    oTransProd.FechaHoraAlta = oConexion.ObtenerFecha
                    oTransProd.FechaCaptura = oConexion.ObtenerFecha.Date
                    oTransProd.FechaFacturacion = oConexion.ObtenerFecha.Date
                    If cbTipoNota.SelectedValue = 1 Then
                        oTransProd.DescVendPor = ebPorcDescuento.Value * 100
                    End If
                    oTransProd.DescuentoImp = nDescuentoNCR
                    oTransProd.SubTDetalle = nSubtotalNCR
                    oTransProd.SubTotal = nSubtotalNCR
                    oTransProd.Impuesto = nImpuestoNCR
                    oTransProd.Total = nTotalNCR
                    oTransProd.Saldo = 0
                    oTransProd.SubEmpresaId = Me.cbSubEmpresa.SelectedValue
                    oTransProd.FacturaID = sFacturaId
                    oTransProd.Insertar()


                    Dim bImpuestoGlb As Boolean = False
                    Dim sFiltro As String = ""
                    sFiltro = " TRP.FacturaId = '" + sFacturaId + "'"

                    Dim sCmd As String
                    sCmd = "select isnull(sum(case when TDI.ImpuestoPU is null or TDI.ImpDesGlb is null then 1 else 0 end), 0) as Nulos "
                    sCmd &= "from TransProd TRP "
                    sCmd &= "inner join TPDImpuesto TDI on TRP.TransProdID = TDI.TransProdID "
                    sCmd &= "where " & sFiltro & " and TRP.Tipo = 1 "
                    bImpuestoGlb = (LbConexion.cConexion.Instancia.EjecutarComandoScalar(sCmd) = 0)


                    'Insertar productos a la nota de credito
                    For Each rwProducto As Janus.Windows.GridEX.GridEXRow In grProductos.GetRows
                        If rwProducto.Cells("Devolucion").Value > 0 Then
                            Dim oTransProdDet As New ERMTRPLOG.cTransProdDetalle(oTransProd)
                            oTransProdDet.TransProdDetalleID = lbGeneral.cKeyGen.KEYGEN(0)
                            oTransProdDet.ProductoClave = rwProducto.Cells("ProductoClave").Value
                            oTransProdDet.TipoUnidad = rwProducto.Cells("TipoUnidad").Value
                            oTransProdDet.Partida = 1
                            oTransProdDet.Promocion = 0
                            oTransProdDet.Cantidad = rwProducto.Cells("Devolucion").Value
                            oTransProdDet.Precio = rwProducto.Cells("Precio").Value
                            oTransProdDet.DescuentoImp = rwProducto.Cells("Descuento").Value
                            oTransProdDet.Subtotal = rwProducto.Cells("SubTotal").Value - rwProducto.Cells("Descuento").Value
                            If cbTipoNota.SelectedValue = 1 Then
                                oTransProdDet.Impuesto = 0
                                For Each drProd As DataRow In dtProductosDesc.Rows
                                    oTransProdDet.Impuesto += oTransProdDet.CalcularImpuesto(oCliente, oTransProdDet, drProd("ProductoClave"), drProd("Subtotal") * ebPorcDescuento.Value, drProd("Subtotal") * ebPorcDescuento.Value)
                                Next
                            Else
                                oTransProdDet.Impuesto = oTransProdDet.CalcularImpuesto(oCliente, oTransProdDet) 'rwProducto.Cells("Impuesto").Value
                            End If
                            oTransProdDet.Total = rwProducto.Cells("Total").Value
                            oTransProdDet.Insertar(New String() {"TransProdDetalleID", "ProductoClave", "TipoUnidad", "Cantidad", "DescuentoImp", "SubTotal", "Precio", "Total"})
                            oTransProd.TransProdDetalle.Insertar(oTransProdDet)
                        End If
                    Next

                    oTransProd.Grabar()

                    Dim lsFolioId As String = CType(cbFolio.DataSource, DataTable).Select("FolioIdFOSId='" & cbFolio.SelectedValue & "'")(0)!FolioId
                    Dim lsFOSId As String = CType(cbFolio.DataSource, DataTable).Select("FolioIdFOSId='" & cbFolio.SelectedValue & "'")(0)!FOSId
                    Dim lsNumCertificado As String = CType(cbFolio.DataSource, DataTable).Select("FolioIdFOSId='" & cbFolio.SelectedValue & "'")(0)!NumCertificado
                    Dim lsCentroExpID As String = CType(cbFolio.DataSource, DataTable).Select("FolioIdFOSId='" & cbFolio.SelectedValue & "'")(0)!CentroExpID
                    Dim lsSerie As String = CType(cbFolio.DataSource, DataTable).Select("FolioIdFOSId='" & cbFolio.SelectedValue & "'")(0)!Serie
                    Dim lnAprobacion As Integer = CType(cbFolio.DataSource, DataTable).Select("FolioIdFOSId='" & cbFolio.SelectedValue & "'")(0)!Aprobacion
                    Dim lnAnioAprobacion As Integer = CType(cbFolio.DataSource, DataTable).Select("FolioIdFOSId='" & cbFolio.SelectedValue & "'")(0)!AnioAprobacion
                    Dim loCentroExpEm As New ERMCEELOG.CCentroExp
                    Dim loCentroExpEx As New ERMCEELOG.CCentroExp

                    loCentroExpEm.Recuperar(lsCentroExpID)
                    If loCentroExpEm.Tipo = 1 And loCentroExpEm.NumCertificado = lsNumCertificado Then 'Sucursal
                        Dim lsCentroExpPadreId As String = loCentroExpEm.CentroExpPadreID
                        loCentroExpEm.Limpiar()
                        loCentroExpEm.Recuperar(lsCentroExpPadreId)
                        loCentroExpEx.Recuperar(lsCentroExpID)
                    Else 'Matriz
                        loCentroExpEx.Limpiar()
                        loCentroExpEx = loCentroExpEm
                    End If

                    'Graba Folio
                    Dim loFolio As New ERMFOLLOG.cFolio
                    loFolio.Recuperar(lsFolioId)
                    loFolio.Bloquear(lbGeneral.cParametros.UsuarioID)
                    loFolio.FOS(lsFOSId).Usados += 1
                    loFolio.Grabar()

                    Dim bSalir As Boolean = False

                    'Graba Dato Fiscal
                    oTRPDatoFiscal = New ERMTRPLOG.cTRPDatoFiscal(oTransProd)
                    oTRPDatoFiscal.FolioId = lsFolioId
                    oTRPDatoFiscal.FOSId = lsFOSId
                    oTRPDatoFiscal.NumCertificado = lsNumCertificado
                    oTRPDatoFiscal.Serie = lsSerie


                    oTRPDatoFiscal.Aprobacion = lnAprobacion
                    oTRPDatoFiscal.AnioAprobacion = lnAnioAprobacion


                    oTRPDatoFiscal.RazonSocial = ebRazonSocial.Text
                    oTRPDatoFiscal.RFC = ebRFC.Text.Replace("-", "")
                    oTRPDatoFiscal.TelefonoContacto = oCliente.TelefonoContacto
                    oTRPDatoFiscal.Calle = ebCalle.Text
                    oTRPDatoFiscal.NumExt = ebExterior.Text
                    oTRPDatoFiscal.NumInt = ebInterior.Text
                    oTRPDatoFiscal.Colonia = ebColonia.Text
                    oTRPDatoFiscal.CodigoPostal = ebCodigoPostal.Text
                    oTRPDatoFiscal.ReferenciaDom = ebReferencia.Text
                    oTRPDatoFiscal.Localidad = ebLocalidad.Text
                    oTRPDatoFiscal.Municipio = ebMunicipio.Text
                    oTRPDatoFiscal.Entidad = ebEntidad.Text
                    oTRPDatoFiscal.Pais = ebPais.Text
                    oTRPDatoFiscal.CadenaOriginal = " "
                    oTRPDatoFiscal.SelloDigital = " "
                    oTRPDatoFiscal.TelefonoEm = oSubEmpresa.Telefono
                    oTRPDatoFiscal.RFCEm = loCentroExpEm.RFC
                    oTRPDatoFiscal.NombreEm = loCentroExpEm.Nombre
                    oTRPDatoFiscal.CalleEm = loCentroExpEm.Calle
                    oTRPDatoFiscal.NumExtEm = loCentroExpEm.NumExt
                    oTRPDatoFiscal.NumIntEm = loCentroExpEm.NumInt
                    oTRPDatoFiscal.ColoniaEm = loCentroExpEm.Colonia
                    oTRPDatoFiscal.LocalidadEm = loCentroExpEm.Localidad
                    oTRPDatoFiscal.ReferenciaDomEm = loCentroExpEm.ReferenciaDom
                    oTRPDatoFiscal.MunicipioEm = loCentroExpEm.Municipio
                    oTRPDatoFiscal.RegionEm = loCentroExpEm.Entidad
                    oTRPDatoFiscal.PaisEm = loCentroExpEm.Pais
                    oTRPDatoFiscal.CodigoPostalEm = loCentroExpEm.CodigoPostal
                    oTRPDatoFiscal.CalleEx = loCentroExpEx.Calle
                    oTRPDatoFiscal.NumExtEx = loCentroExpEx.NumExt
                    oTRPDatoFiscal.NumIntEx = loCentroExpEx.NumInt
                    oTRPDatoFiscal.ColoniaEx = loCentroExpEx.Colonia
                    oTRPDatoFiscal.CodigoPostalEx = loCentroExpEx.CodigoPostal
                    oTRPDatoFiscal.ReferenciaDomEx = loCentroExpEx.ReferenciaDom
                    oTRPDatoFiscal.LocalidadEx = loCentroExpEx.Localidad
                    oTRPDatoFiscal.MunicipioEx = loCentroExpEx.Municipio
                    oTRPDatoFiscal.EntidadEx = loCentroExpEx.Entidad
                    oTRPDatoFiscal.PaisEx = loCentroExpEx.Pais
                    oTRPDatoFiscal.TipoNotaCredito = cbTipoNota.SelectedValue
                    Dim lnTipoVersion As String

                    'If (oSubEmpresa.VersionCFD = 1) Then
                    lnTipoVersion = lbGeneral.ClaveDescripcionVARValor("VERFACTE", oSubEmpresa.VersionCFD)
                    'Else
                    '    lnTipoVersion = lbGeneral.ClaveDescripcionVARValor("VERFACTE", 2)
                    'End If


                    oTRPDatoFiscal.TipoVersion = lnTipoVersion
                    oTRPDatoFiscal.TipoVersion = lnTipoVersion
                    If grMetodosPago.RowCount > 0 Then
                        Dim sMetodos As String = String.Empty
                        Dim sBancos As String = String.Empty
                        Dim sCuentas As String = String.Empty

                        For Each oMetodo As IMetodosPago.MetodoPago In grMetodosPago.DataSource
                            sMetodos += oMetodo.Metodo + ","
                            sBancos += IIf(oMetodo.Banco = "", "*", oMetodo.Banco) + ","
                            sCuentas += IIf(oMetodo.Cuenta = "", "*", oMetodo.Cuenta) + ","
                        Next

                        If sMetodos.Length > 0 Then
                            sMetodos = sMetodos.Substring(0, sMetodos.Length - 1)
                        End If
                        If sBancos.Length > 0 Then
                            sBancos = sBancos.Substring(0, sBancos.Length - 1)
                        End If

                        If sCuentas.Length > 0 Then
                            sCuentas = sCuentas.Substring(0, sCuentas.Length - 1)
                        End If

                        oTRPDatoFiscal.MetodoPago = sMetodos
                        oTRPDatoFiscal.NumCtaPago = sCuentas
                        oTRPDatoFiscal.Banco = sBancos
                    End If

                    oTRPDatoFiscal.Insertar(New String() {"FolioId", "FOSId", "NumCertificado", "Serie", "Aprobacion", "AnioAprobacion", "RazonSocial", "RFC", "TipoNotaCredito"})
                    oTRPDatoFiscal.Grabar()

                    'Grabar Cadena Original y Sello Digital
                    oTransProd.vgTRPDatoFiscal = oTRPDatoFiscal
                    Dim lsCadenaOriginal As String = ""


             
                    If oSubEmpresa.VersionCFD = 1 Or oSubEmpresa.VersionCFD = 3 Then
                        lsCadenaOriginal = oTransProd.CrearCadenaOriginalE(False, bImpuestoGlb)
                    Else
                        lsCadenaOriginal = oTransProd.CrearCadenaOriginalEV3(False, bImpuestoGlb)
                    End If



                    lsCadenaOriginal = lsCadenaOriginal.Replace("&", "&amp;")
                    lsCadenaOriginal = lsCadenaOriginal.Replace("""", "&quot;")
                    lsCadenaOriginal = lsCadenaOriginal.Replace("<", "&lt;")
                    lsCadenaOriginal = lsCadenaOriginal.Replace(">", "&gt;")
                    lsCadenaOriginal = lsCadenaOriginal.Replace("'", "&#36;")
                    Dim lsSelloDigital As String = ""
                    Try
                        lsSelloDigital = oTransProd.CrearSelloDigital(lsCadenaOriginal, Me.cbSubEmpresa.SelectedValue)
                    Catch ex As LbControlError.cError
                        ex.Mostrar()
                    End Try
                    oTRPDatoFiscal.CadenaOriginal = lsCadenaOriginal
                    oTRPDatoFiscal.SelloDigital = lsSelloDigital
                    oTRPDatoFiscal.Grabar()



                    If oSubEmpresa.VersionCFD = 1 Then

                        'Imprimir Nota
                        If MsgBox(oMensaje.RecuperarDescripcion("P0221", New String() {oMensaje.RecuperarDescripcion("XNotaCredito")}), MsgBoxStyle.YesNo, oMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.Yes Then
                            Dim oRep As New RRepFactElectronica
                            oRep.CONSULTAR(oTransProd.TransProdID)
                        End If

                        ''Generar XML
                        Me.Cursor = Cursors.Default
                        If MsgBox(oMensaje.RecuperarDescripcion("P0119"), MsgBoxStyle.YesNo, oMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.Yes Then
                            Dim xml As New PRepXML(oTransProd)
                            xml.ShowDialog()
                        End If

                    ElseIf oSubEmpresa.VersionCFD = 3 Then

                        Try
                            Me.Cursor = Cursors.Default
                            Dim oXML As cTransProd.cXML
                            oTransProd.GenerarSoloXML(oXML, oTransProd, oTransProd.obtenerDirDocXML(oTransProd.SubEmpresaId), False, "", True)
                            If Not oXML Is Nothing Then
                                Dim oRep As New RRepFactElectronica
                                Dim oReporte As CrystalDecisions.CrystalReports.Engine.ReportClass = oRep.CrearReporte(oTransProd.TransProdID)
                                oReporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, System.IO.Path.Combine(oXML.Ruta, System.IO.Path.GetFileNameWithoutExtension(oXML.NombreArchivo) + ".pdf"))
                                oTransProd.EnviarXML(oTransProd, oXML.Ruta, oXML.NombreArchivo, False, "")

                                'Imprimir Nota
                                If MsgBox(oMensaje.RecuperarDescripcion("P0221", New String() {oMensaje.RecuperarDescripcion("XNotaCredito")}), MsgBoxStyle.YesNo, oMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.Yes Then
                                    oRep.CONSULTAR(oTransProd.TransProdID)
                                End If
                            End If
                        Catch ex As LbControlError.cError
                            ex.Mostrar()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                        'ElseIf oSubEmpresa.VersionCFD = 2 Then
                        '    Dim oCfdi As ERMTRPLOG.CFDi

                        '    Try
                        '        oTransProd.GenerarXMLVersion3(oTransProd, oTransProd.obtenerDirDocXML(oTransProd.SubEmpresaId), False, "", "", oCfdi, False)
                        '    Catch ex As LbControlError.cError
                        '        ex.Mostrar()
                        '    End Try

                        '    If Not oCfdi Is Nothing Then
                        '        oTRPDatoFiscal.NoCertificadoSAT = oCfdi.TimbreFiscal.noCertificadoSAT
                        '        oTRPDatoFiscal.FechaTimbrado = oCfdi.TimbreFiscal.FechaTimbrado
                        '        'oCfdi.TimbreFiscal.selloCFD
                        '        oTRPDatoFiscal.SelloSAT = oCfdi.TimbreFiscal.selloSAT
                        '        oTRPDatoFiscal.UUID = oCfdi.TimbreFiscal.UUID
                        '        oTRPDatoFiscal.VersionTFD = oCfdi.TimbreFiscal.version
                        '        oTRPDatoFiscal.CadenaOriginalTFD = oTransProd.CrearCadenaOriginalSello(oCfdi.TimbreFiscal)
                        '        Dim sInutil As String = oTransProd.CrearSelloDigital(oTRPDatoFiscal.CadenaOriginalTFD, oSubEmpresa.SubEmpresaID)
                        '        oTRPDatoFiscal.Grabar()
                        '        oConexion.ConfirmarTran()
                        '        Me.Cursor = Cursors.Default
                        '        If MsgBox(oMensaje.RecuperarDescripcion("P0221", New String() {oMensaje.RecuperarDescripcion("XNotaCredito")}), MsgBoxStyle.YesNo, oMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.Yes Then
                        '            Dim oRep As New RRepFactElectronica
                        '            oRep.CONSULTAR(oTransProd.TransProdID)
                        '        End If

                        '        Me.DialogResult = Windows.Forms.DialogResult.OK
                        '        bCerrar = True
                        '        Me.Close()
                        '    End If

                        '    Exit Sub
                        'Else
                        '    Dim oCfdi As ERMTRPLOG.CFDi
                        '    Dim oXML As cTransProd.cXML
                        '    Try
                        '        Me.Cursor = Cursors.Default
                        '        oTransProd.GenerarSoloXMLVersion3(oXML, oTransProd, oTransProd.obtenerDirDocXML(oTransProd.SubEmpresaId), oCfdi, False, "", False, True)
                        '    Catch ex As LbControlError.cError
                        '        ex.Mostrar()
                        '    End Try

                        '    If Not oCfdi Is Nothing Then
                        '        oTRPDatoFiscal.NoCertificadoSAT = oCfdi.TimbreFiscal.noCertificadoSAT
                        '        oTRPDatoFiscal.FechaTimbrado = oCfdi.TimbreFiscal.FechaTimbrado
                        '        'oCfdi.TimbreFiscal.selloCFD
                        '        oTRPDatoFiscal.SelloSAT = oCfdi.TimbreFiscal.selloSAT
                        '        oTRPDatoFiscal.UUID = oCfdi.TimbreFiscal.UUID
                        '        oTRPDatoFiscal.VersionTFD = oCfdi.TimbreFiscal.version
                        '        oTRPDatoFiscal.CadenaOriginalTFD = oTransProd.CrearCadenaOriginalSello(oCfdi.TimbreFiscal)
                        '        Dim sInutil As String = oTransProd.CrearSelloDigital(oTRPDatoFiscal.CadenaOriginalTFD, oSubEmpresa.SubEmpresaID)
                        '        oTRPDatoFiscal.Grabar()

                        '        Try
                        '            If Not oXML Is Nothing Then
                        '                Dim oRep As New RRepFactElectronica
                        '                Dim oReporte As CrystalDecisions.CrystalReports.Engine.ReportClass = oRep.CrearReporte(oTransProd.TransProdID)
                        '                oReporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, System.IO.Path.Combine(oXML.Ruta, System.IO.Path.GetFileNameWithoutExtension(oXML.NombreArchivo) + ".pdf"))
                        '                oTransProd.EnviarXML(oTransProd, oXML.Ruta, oXML.NombreArchivo, False, "")
                        '            End If
                        '        Catch ex As LbControlError.cError
                        '            ex.Mostrar()
                        '        Catch ex As Exception
                        '            MsgBox(ex.Message)
                        '        End Try

                        '        Me.DialogResult = Windows.Forms.DialogResult.OK
                        '        bCerrar = True
                        '        Me.Close()
                        '    Else
                        '        oConexion.DeshacerTran()
                        '    End If

                        '    Exit Sub
                    End If
                    oConexion.ConfirmarTran()

                Case eModo.Cancelar
                    oSubEmpresa.Recuperar(oTransProd.SubEmpresaId, oTransProd.FechaHoraAlta)


                    'If (oSubEmpresa.VersionCFD = 2 Or oSubEmpresa.VersionCFD = 4) Then
                    '    Try
                    '        Dim oSubEmpresaActual As New ERMSEMLOG.cSubEmpresa()
                    '        oSubEmpresaActual.Recuperar(oTransProd.SubEmpresaId, LbConexion.cConexion.Instancia.ObtenerFecha)
                    '        oTransProd.CancelarCFDV3Soap(oTRPDatoFiscal.RFCEm, oTRPDatoFiscal.UUID, oSubEmpresaActual)
                    '    Catch ex As CFDiException
                    '        If (ex.Codigo = 202) Then
                    '            MsgBox(oMensaje.RecuperarDescripcion("E0860").Replace("$0$", oMensaje.RecuperarDescripcion("XNotaCredito")).Replace("$1$", ex.Codigo + " " + ex.Message))
                    '        Else
                    '            MsgBox(oMensaje.RecuperarDescripcion("E0860").Replace("$0$", oMensaje.RecuperarDescripcion("XNotaCredito")).Replace("$1$", ex.Codigo + " " + ex.Message))

                    '            Exit Sub
                    '        End If
                    '    End Try



                    'End If


                    oTransProd.TipoFase = 0
                    oTransProd.FechaCancelacion = oConexion.ObtenerFecha
                    oTransProd.Grabar()

                    If (oSubEmpresa.VersionCFD = 2 Or oSubEmpresa.VersionCFD = 4) Then
                        oTRPDatoFiscal.Grabar()
                    End If

                    oConexion.ConfirmarTran()
            End Select
        Catch ex As LbControlError.cError

            ex.Mostrar()
            Exit Sub
        Catch ExcW As CFDiException
            oConexion.DeshacerTran()

            MsgBox(oMensaje.RecuperarDescripcion("E0842").Replace("$0$", oMensaje.RecuperarDescripcion("XNotaCredito")).Replace("$1$", ExcW.Codigo + " " + ExcW.Message))
            bCerrar = True
            Me.Close()
            Exit Sub
        Catch ExcW As System.Net.WebException
            oConexion.DeshacerTran()

            MsgBox(oMensaje.RecuperarDescripcion("E0843"))

            Exit Sub
        Catch ex As Exception
            oConexion.DeshacerTran()
            MsgBox(ex.Message)
            bCerrar = True
            Me.Close()
            Exit Sub
        Finally
            BtAceptar.Enabled = True
            BtCancelar.Enabled = True
            Me.Cursor = Cursors.Default
        End Try

        Me.DialogResult = Windows.Forms.DialogResult.OK
        bCerrar = True
        Me.Close()
    End Sub

    Private Sub BtCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancelar.Click
        Me.Close()
    End Sub

    Private Sub MGeneral_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not bCerrar Then
            Me.DialogResult = Windows.Forms.DialogResult.None
            If tModo = eModo.Crear Or tModo = eModo.Modificar Then
                If Not bCerrar And bHuboCambios Then
                    If (MsgBox(oMensaje.RecuperarDescripcion("BP0001"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, oMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.No) Then
                        Exit Sub
                    End If
                End If
            End If
            oTransProd.Limpiar()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub
#End Region

    Private Sub MNotasCredito_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TabFacturacion.SelectedTabIndex = 0
    End Sub

    'Private Sub LimpiarCliente()
    '    ebFolioFactura.Enabled = False
    '    btBuscarFactura.Enabled = False
    '    ebFolioFactura.Text = ""
    'End Sub   

    Private Sub btBuscarFactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBuscarFactura.Click
        Dim oIndice As New ERMTRPESC.IFacturas
        Dim oArray As ArrayList = oIndice.Seleccionar()
        If Not oArray Is Nothing AndAlso oArray.Count > 0 Then
            Dim drFactura As DataRow = oArray(0)

            sFacturaId = drFactura("TransProdId")
            sClienteClave = drFactura("ClienteClave")
            dFechaFactura = drFactura("FechaHoraAlta")
            nTotalFAC = drFactura("TotalFAC")
            nTotalDES = drFactura("TotalDES")
            nTotalDEV = drFactura("TotalDEV")

            nSubtotalDev = oTransProd.ObtenerSubtotalDevoluciones(sFacturaId, sClienteClave, dFechaFactura)

            'nSubtotalDisp = nTotalFAC - nTotalDEV
            'nImpuestoDisp = drFactura("ImpuestoFAC") - drFactura("ImpuestoDES")            
            nTotalFactura = nTotalFAC - nTotalDEV
            nSubtotalFactura = drFactura("SubtotalFAC") - nSubtotalDev
            nSaldoFactura = nTotalFAC - nTotalDEV - nTotalDES

            ebFolioFactura.Text = drFactura("Folio")
            ebTotalFAC.Text = nTotalFactura
            ebTotalDisp.Text = nSaldoFactura
            RecuperarDatosCliente()
            LlenarGridProductos()
            ReiniciarTotales()

            epErrores.SetError(btBuscarFactura, "")
        End If
    End Sub
  
    Private Sub grProductos_UpdatingCell(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.UpdatingCellEventArgs) Handles grProductos.UpdatingCell
        If e.Column.Key = "Devolucion" Then
            If e.Value Is DBNull.Value OrElse e.Value < 0 Then
                e.Value = e.InitialValue
                Exit Sub
            End If

            If e.Value > grProductos.GetValue("Disponible") Then
                MsgBox(oMensaje.RecuperarDescripcion("E0302"), MsgBoxStyle.Information Or MsgBoxStyle.Exclamation, oMensaje.RecuperarDescripcion("XMensajeE"))
                e.Value = e.InitialValue
                Exit Sub
            End If

            Dim nPrecio As Double
            Dim nDscto As Double
            'Dim nImpto As Decimal
            Dim nSubtotal As Double
            Dim nDescuento As Double
            Dim nImpuesto As Double
            Dim nTotal As Double

            nPrecio = grProductos.GetValue("Precio")
            nDscto = grProductos.GetValue("DescuentoVta") / grProductos.GetValue("Vendido")
            'nImpto = grProductos.GetValue("ImpuestoVta") / grProductos.GetValue("Vendido")
            nSubtotal = nPrecio * e.Value
            nDescuento = nDscto * e.Value
            If (cbTipoNota.SelectedValue = 1) Then
                nImpuesto = cTransProdDetalle.CalcularImpuesto(oCliente, grProductos.GetValue("ProductoClave"), nSubtotal - nDescuento, False)
            Else
                nImpuesto = cTransProdDetalle.CalcularImpuesto(oCliente, grProductos.GetValue("ProductoClave"), nSubtotal - nDescuento)
            End If
            nTotal = nSubtotal - nDescuento

            If (Math.Round(nSaldoFactura, 2) - Math.Round((nTotalNCR - grProductos.GetValue("Total") - grProductos.GetValue("Impuesto") + nTotal + nImpuesto), 2)) < 0 Then
                MsgBox(oMensaje.RecuperarDescripcion("E0801"), MsgBoxStyle.Information Or MsgBoxStyle.Exclamation, oMensaje.RecuperarDescripcion("XMensajeE"))
                e.Value = e.InitialValue
                Exit Sub
            End If

            nImporteNCR -= grProductos.GetValue("Subtotal")
            nDescuentoNCR -= grProductos.GetValue("Descuento")
            nImpuestoNCR -= grProductos.GetValue("Impuesto")
            nSubtotalNCR -= grProductos.GetValue("Total")

            'nSubto

            grProductos.SetValue("SubTotal", nSubtotal)
            grProductos.SetValue("Descuento", nDescuento)
            grProductos.SetValue("Impuesto", nImpuesto)
            grProductos.SetValue("Total", nTotal)

            'ebSubTotal.Text = nSubtotalNCR + nImpuestoGrl

            nImporteNCR += nSubtotal
            nDescuentoNCR += nDescuento
            nSubtotalNCR += nTotal
            nImpuestoNCR += nImpuesto
            nTotalNCR = nSubtotalNCR + nImpuestoNCR

            ebImporte.Text = nImporteNCR
            ebDescuento.Text = nDescuentoNCR
            ebSubTotal.Text = nSubtotalNCR
            ebImpuesto.Text = oTransProd.dValido(nImpuestoNCR, True)
            ebTotal.Text = nTotalNCR

            'ebTotalDES.Text = nTotalDES + nSubtotalNCR
            'ebTotalDisp.Text = nTotalDisp - nSubtotalNCR
        End If
    End Sub

    Private Sub ebPorcDescuento_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebPorcDescuento.Validating
        If ebPorcDescuento.Value > 100 Or ebPorcDescuento.Value < 0 Then
            e.Cancel = True
            Exit Sub
        End If

        If Math.Round(nTotalFactura * ebPorcDescuento.Value, 2) > Math.Round(nSaldoFactura, 2) Then
            MsgBox(oMensaje.RecuperarDescripcion("E0799"), MsgBoxStyle.Information Or MsgBoxStyle.Exclamation, oMensaje.RecuperarDescripcion("XMensajeE"))
            e.Cancel = True
            Exit Sub
        End If
        
        nImporteNCR = nSubtotalFactura * ebPorcDescuento.Value
        nSubtotalNCR = nSubtotalFactura * ebPorcDescuento.Value
        nImpuestoNCR = 0
        For Each drProd As DataRow In dtProductosDesc.Rows
            nImpuestoNCR += cTransProdDetalle.CalcularImpuesto(oCliente, drProd("ProductoClave"), drProd("Subtotal") * ebPorcDescuento.Value, True)
        Next
        'nImpuestoNCR = nImpuestoDisp * ebPorcDescuento.Value
        nTotalNCR = nSubtotalNCR + nImpuestoNCR

        For Each rwProducto As Janus.Windows.GridEX.GridEXRow In grProductos.GetRows
            rwProducto.BeginEdit()
            rwProducto.Cells("Devolucion").Value = 1
            rwProducto.Cells("Precio").Value = nSubtotalNCR
            rwProducto.Cells("Subtotal").Value = nSubtotalNCR
            rwProducto.Cells("Total").Value = nSubtotalNCR
            rwProducto.EndEdit()
        Next

        ebImporte.Text = nImporteNCR
        ebSubTotal.Text = nSubtotalNCR
        ebImpuesto.Text = oTransProd.dValido(nImpuestoNCR, True)
        ebTotal.Text = nTotalNCR
    End Sub

    Private Sub btMetodoPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btMetodoPago.Click
        Dim oMetodoPago As New IMetodosPago
        Dim aMetodos As IList(Of IMetodosPago.MetodoPago) = oMetodoPago.SeleccionarMetodosCuentas(oCliente.ClienteClave, IIf(grMetodosPago.RowCount <= 0, Nothing, grMetodosPago.DataSource))
        If Not IsNothing(aMetodos) AndAlso aMetodos.Count > 0 Then
            grMetodosPago.DataSource = aMetodos
        End If
    End Sub


End Class
