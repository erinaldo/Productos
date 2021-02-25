Imports ERMCONLOG
Imports System.Collections.Generic

Public Class MCriterioCobranza

    Private bHuboCambios As Boolean = False
    Private bCargando As Boolean = False
    Private bCerrar As Boolean = False
    Private oMensaje As New BASMENLOG.CMensaje()
    Private oConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private oAcceso As LbAcceso.cAcceso
    Private sUsuario As String
    Private oCCOVta As ERMCONLOG.cCriterioCobranza
    Private oCCOFac As ERMCONLOG.cCriterioCobranza
    Private bNuevoVta As Boolean = False
    Private bNuevoFac As Boolean = False
    Private Shared vgInstance As MCriterioCobranza = Nothing
    Private oConfig As ERMCONLOG.cConfiguracion

    Public Shared Function Instance() As MCriterioCobranza
        If vgInstance Is Nothing OrElse vgInstance.IsDisposed = True Then
            vgInstance = New MCriterioCobranza
        End If
        Return vgInstance
    End Function

    Public Sub Inicio(ByVal pvAcceso As LbAcceso.cAcceso)
        bCargando = True
        sUsuario = pvAcceso.MUsuarioId
        oAcceso = pvAcceso
        oCCOVta = New ERMCONLOG.cCriterioCobranza
        oCCOFac = New ERMCONLOG.cCriterioCobranza
        oMensaje = New BASMENLOG.CMensaje
        oConfig = New ERMCONLOG.cConfiguracion
        Me.ShowDialog()
        Me.Dispose()
    End Sub

    Private Sub ConfigurarTitulos()
        Dim sNemonico As String = "MCN"

        Me.Text = oMensaje.RecuperarDescripcion("ERMCONESC_MCriterioCobranza")

        tpVenta.Text = oMensaje.RecuperarDescripcion("XVenta")
        lbNoAsignadasVta.Text = oMensaje.RecuperarDescripcion("XNoAsignadas")
        lbAsignadasVta.Text = oMensaje.RecuperarDescripcion("XAsignadas")

        tpFactura.Text = oMensaje.RecuperarDescripcion("XFactura")
        lbNoAsignadasFac.Text = oMensaje.RecuperarDescripcion("XNoAsignadas")
        lbAsignadasFac.Text = oMensaje.RecuperarDescripcion("XAsignadas")

        ToolTip1.SetToolTip(btAsignarVta, oMensaje.RecuperarDescripcion("BTAsignarT"))
        ToolTip1.SetToolTip(btDesasignarVta, oMensaje.RecuperarDescripcion("BTDesasignarT"))
        ToolTip1.SetToolTip(btArribaVta, oMensaje.RecuperarDescripcion("BTArribaT"))
        ToolTip1.SetToolTip(btAbajoVta, oMensaje.RecuperarDescripcion("BTAbajoT"))

        ToolTip1.SetToolTip(btAsignarFac, oMensaje.RecuperarDescripcion("BTAsignarT"))
        ToolTip1.SetToolTip(btDesasignarFac, oMensaje.RecuperarDescripcion("BTDesasignarT"))
        ToolTip1.SetToolTip(btArribaFac, oMensaje.RecuperarDescripcion("BTArribaT"))
        ToolTip1.SetToolTip(btAbajoFac, oMensaje.RecuperarDescripcion("BTAbajoT"))

        Me.btAceptar.Text = oMensaje.RecuperarDescripcion("BTAceptar")
        ToolTip1.SetToolTip(btAceptar, oMensaje.RecuperarDescripcion("BTAceptarT"))

        Me.btCancelar.Text = oMensaje.RecuperarDescripcion("BTCancelar")
        ToolTip1.SetToolTip(btCancelar, oMensaje.RecuperarDescripcion("BTCancelarT"))
    End Sub

    Private Sub ConfigurarGrid()
        'Venta
        grdNoAsignadasVta.RootTable.Columns("TipoCriterio").Caption = oMensaje.RecuperarDescripcion("CCDTipoCriterio")
        grdAsignadasVta.RootTable.Columns("TipoCriterio").Caption = oMensaje.RecuperarDescripcion("CCDTipoCriterio")
        grdAsignadasVta.RootTable.Columns("Ordenacion").Caption = oMensaje.RecuperarDescripcion("CCDOrdenacion")
        grdNoAsignadasVta.RootTable.Columns("TipoCriterio").HeaderToolTip = oMensaje.RecuperarDescripcion("CCDTipoCriterioT")
        grdAsignadasVta.RootTable.Columns("TipoCriterio").HeaderToolTip = oMensaje.RecuperarDescripcion("CCDTipoCriterioT")
        grdAsignadasVta.RootTable.Columns("Ordenacion").HeaderToolTip = oMensaje.RecuperarDescripcion("CCDOrdenacionT")

        lbGeneral.LlenarColumna(grdNoAsignadasVta.RootTable.Columns("TipoCriterio"), "TIPCRI")
        lbGeneral.LlenarColumna(grdAsignadasVta.RootTable.Columns("TipoCriterio"), "TIPCRI")
        lbGeneral.LlenarColumna(grdAsignadasVta.RootTable.Columns("Ordenacion"), "TIPORD")

        'Factura
        grdNoAsignadasFac.RootTable.Columns("TipoCriterio").Caption = oMensaje.RecuperarDescripcion("CCDTipoCriterio")
        grdAsignadasFac.RootTable.Columns("TipoCriterio").Caption = oMensaje.RecuperarDescripcion("CCDTipoCriterio")
        grdAsignadasFac.RootTable.Columns("Ordenacion").Caption = oMensaje.RecuperarDescripcion("CCDOrdenacion")
        grdNoAsignadasFac.RootTable.Columns("TipoCriterio").HeaderToolTip = oMensaje.RecuperarDescripcion("CCDTipoCriterioT")
        grdAsignadasFac.RootTable.Columns("TipoCriterio").HeaderToolTip = oMensaje.RecuperarDescripcion("CCDTipoCriterioT")
        grdAsignadasFac.RootTable.Columns("Ordenacion").HeaderToolTip = oMensaje.RecuperarDescripcion("CCDOrdenacionT")

        lbGeneral.LlenarColumna(grdNoAsignadasFac.RootTable.Columns("TipoCriterio"), "TIPCRI")
        lbGeneral.LlenarColumna(grdAsignadasFac.RootTable.Columns("TipoCriterio"), "TIPCRI")
        lbGeneral.LlenarColumna(grdAsignadasFac.RootTable.Columns("Ordenacion"), "TIPORD")

    End Sub

    Private Sub RecuperarDatos()
        'Venta
        If Not oCCOVta.RecuperaAsignado(True) Then
            oCCOVta.CriterioCobranzaId = lbGeneral.cKeyGen.KEYGEN(Now.Second)
            oCCOVta.CobrarVentas = True
            bNuevoVta = True
        End If

        Dim dtVtaNo As DataTable = oCCOVta.ObtenerCriteriosNoAsignados(True)
        grdNoAsignadasVta.DataSource = dtVtaNo

        Dim dtVta As DataTable = oCCOVta.CriterioCobranzaDet.ObtenerDataTable  'oCCOVta.ObtenerCriteriosAsignados()
        'Dim dvVta As New DataView(dtVta)
        'dvVta.Sort = "Prioridad"
        grdAsignadasVta.DataSource = dtVta
        grdAsignadasVta.DataMember = "CriterioCobranza"

        'Factura
        If Not oCCOFac.RecuperaAsignado(False) Then
            oCCOFac.CriterioCobranzaId = lbGeneral.cKeyGen.KEYGEN(Now.Second)
            oCCOFac.CobrarVentas = False
            bNuevoFac = True
        End If

        Dim dtFacNo As DataTable = oCCOFac.ObtenerCriteriosNoAsignados(False)
        grdNoAsignadasFac.DataSource = dtFacNo

        Dim dtFac As DataTable = oCCOFac.CriterioCobranzaDet.ObtenerDataTable 'oCCOFac.ObtenerCriteriosAsignados()
        grdAsignadasFac.DataSource = dtFac
        grdAsignadasFac.DataMember = "CriterioCobranza"
    End Sub

    Private Sub HabilitarCampos()
        If oConfig.CobrarVentas Then
            'Ventas
            Me.TabControlPanel2.Enabled = False
            Me.TabControlPanel1.Enabled = True
            Me.tbCriterioCobranza.SelectedTabIndex = 0

            btAsignarVta.Enabled = (CType(grdNoAsignadasVta.DataSource, DataTable).Rows.Count > 0)
            btDesasignarVta.Enabled = (CType(grdAsignadasVta.DataSource, DataTable).Rows.Count > 0)
            btArribaVta.Enabled = (CType(grdAsignadasVta.DataSource, DataTable).Rows.Count > 0)
            btAbajoVta.Enabled = (CType(grdAsignadasVta.DataSource, DataTable).Rows.Count > 0)
        Else
            'Facturas
            Me.TabControlPanel1.Enabled = False
            Me.TabControlPanel2.Enabled = True
            Me.tbCriterioCobranza.SelectedTabIndex = 1

            btAsignarFac.Enabled = (CType(grdNoAsignadasFac.DataSource, DataTable).Rows.Count > 0)
            btDesasignarFac.Enabled = (CType(grdAsignadasFac.DataSource, DataTable).Rows.Count > 0)
            btArribaFac.Enabled = (CType(grdAsignadasFac.DataSource, DataTable).Rows.Count > 0)
            btAbajoFac.Enabled = (CType(grdAsignadasFac.DataSource, DataTable).Rows.Count > 0)
        End If
    End Sub

    Private Sub Asignar(ByRef grdNoAsignadas As Janus.Windows.GridEX.GridEX, ByRef oCCO As cCriterioCobranza)
        Try
            If (grdNoAsignadas.SelectedItems.Count > 0) Then
                Dim aCriterios As New ArrayList
                For Each i As Janus.Windows.GridEX.GridEXSelectedItem In grdNoAsignadas.SelectedItems()
                    Dim oCCD As New cCriterioCobranzaDet(oCCO)
                    oCCD.CriterioCobranzaDetId = lbGeneral.cKeyGen.KEYGEN(Now.Second)
                    oCCD.TipoCriterio = grdNoAsignadas.GetRow(i.Position).Cells("TipoCriterio").Value 'CType(grdNoAsignadas.DataSource, DataTable).Rows(i.Position)("TipoCriterio")
                    oCCD.Ordenacion = 1
                    oCCD.Prioridad = oCCO.CriterioCobranzaDet.SiguienteOrden
                    oCCD.Insertar(New String() {"TipoCriterio", "Ordenacion", "Prioridad"})
                    oCCO.CriterioCobranzaDet.Insertar(oCCD)
                    aCriterios.Add(oCCD.TipoCriterio)
                Next

                For Each nTipoCrit As Integer In aCriterios
                    For Each oRow As DataRow In CType(grdNoAsignadas.DataSource, DataTable).Rows
                        If oRow("TipoCriterio") = nTipoCrit Then
                            CType(grdNoAsignadas.DataSource, DataTable).Rows.Remove(oRow)
                            Exit For
                        End If
                    Next
                Next

                bHuboCambios = True
                HabilitarCampos()
            End If
        Catch ex As LbControlError.cError
            ex.Mostrar()
        End Try
    End Sub

    Private Sub Desasignar(ByRef grdAsignadas As Janus.Windows.GridEX.GridEX, ByRef grdNoAsignadas As Janus.Windows.GridEX.GridEX, ByRef oCCO As cCriterioCobranza)
        If (grdAsignadas.SelectedItems.Count > 0) Then
            Dim aCriterios As New ArrayList
            For Each i As Janus.Windows.GridEX.GridEXSelectedItem In grdAsignadas.SelectedItems()
                Dim sId As String = grdAsignadas.GetRow(i.Position).Cells("CriterioCobranzaDetId").Value
                oCCO.CriterioCobranzaDet(sId).Eliminar()
                aCriterios.Add(grdAsignadas.GetRow(i.Position).Cells("TipoCriterio").Value)
            Next

            For Each nTipoCrit As Integer In aCriterios
                Dim drNoAsi As DataRow = CType(grdNoAsignadas.DataSource, DataTable).NewRow
                drNoAsi("TipoCriterio") = nTipoCrit
                For Each oRow As DataRow In CType(grdAsignadas.DataSource, DataTable).Rows
                    If oRow("TipoCriterio") = nTipoCrit Then
                        CType(grdAsignadas.DataSource, DataTable).Rows.Remove(oRow)
                        Exit For
                    End If
                Next
                CType(grdNoAsignadas.DataSource, DataTable).Rows.Add(drNoAsi)
            Next

            bHuboCambios = True
            HabilitarCampos()
        End If
    End Sub

    Private Sub Mover(ByRef grdAsignadas As Janus.Windows.GridEX.GridEX, ByRef oCCO As cCriterioCobranza, ByVal bArriba As Boolean)
        If (grdAsignadas.SelectedItems.Count > 0) Then
            Dim vlPosAnterior As Integer
            Dim vlPosNueva As Integer

            vlPosAnterior = grdAsignadas.SelectedItems(0).GetRow.AbsolutePosition - 1

            If (bArriba And vlPosAnterior > 0) Or (Not bArriba And vlPosAnterior < grdAsignadas.GetRows.Length - 1) Then
                vlPosNueva = IIf(bArriba, vlPosAnterior - 1, vlPosAnterior + 1)

                Dim sCCDArribaId As String = grdAsignadas.GetRows(IIf(bArriba, vlPosAnterior, vlPosNueva)).DataRow.Row!CriterioCobranzaDetId
                Dim sCCDAbajoId As String = grdAsignadas.GetRows(IIf(bArriba, vlPosNueva, vlPosAnterior)).DataRow.Row!CriterioCobranzaDetId

                Dim nNvaArriba As Integer = oCCO.CriterioCobranzaDet(sCCDAbajoId).Prioridad
                Dim nNvaAbajo As Integer = oCCO.CriterioCobranzaDet(sCCDArribaId).Prioridad

                oCCO.CriterioCobranzaDet(sCCDArribaId).Prioridad = nNvaArriba
                oCCO.CriterioCobranzaDet(sCCDAbajoId).Prioridad = nNvaAbajo

                For Each dr As Janus.Windows.GridEX.GridEXRow In grdAsignadas.GetRows
                    If dr.DataRow.Row!CriterioCobranzaDetId = sCCDAbajoId Then
                        grdAsignadas.GetRows(dr.AbsolutePosition - 1).DataRow.Row!Prioridad = nNvaAbajo
                        Exit For
                    End If
                Next

                For Each dr As Janus.Windows.GridEX.GridEXRow In grdAsignadas.GetRows
                    If dr.DataRow.Row!CriterioCobranzaDetId = sCCDArribaId Then
                        grdAsignadas.GetRows(dr.AbsolutePosition - 1).DataRow.Row!Prioridad = nNvaArriba
                        Exit For
                    End If
                Next

                grdAsignadas.Row = vlPosNueva
                grdAsignadas.Select()

                bHuboCambios = True
            End If
        End If
    End Sub

    Private Function ValidarDetalle() As Boolean
        Dim nTab As Integer = IIf(oConfig.CobrarVentas, 0, 1)
        Try
            If oConfig.CobrarVentas Then
                oCCOVta.Validar()
            Else
                oCCOFac.Validar()
            End If
        Catch ex As LbControlError.cError
            ex.Mostrar()
            Me.tbCriterioCobranza.SelectedTabIndex = nTab
            Me.tbCriterioCobranza.Select()
            Return False
        End Try

        Return True
    End Function

    Private Sub MCriterioCobranza_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not bCerrar And bHuboCambios Then

            Me.DialogResult = Windows.Forms.DialogResult.None
            If MsgBox(oMensaje.RecuperarDescripcion("BP0001"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, oMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.Yes Then
                oConexion.DeshacerTran()
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub MCriterioCobranza_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
#If DEBUG Then
        oConexion.Conectar("Provider=SQLOLEDB;Data Source=192.168.0.71\sql2008;user id=sa;password=dbsa.;initial catalog=Mayoreo3.10.0")
        'vcIniciando = True
        sUsuario = "Admin"
        'vcConfig = New ERMCONLOG.cConfiguracion
        oMensaje = New BASMENLOG.CMensaje
        oAcceso = New LbAcceso.cAcceso
        oMensaje.LlenarDataSet()
        oAcceso.Crear = True
        oAcceso.Modificar = True
        oAcceso.Leer = True
        oCCOVta = New ERMCONLOG.cCriterioCobranza
        oCCOFac = New ERMCONLOG.cCriterioCobranza
        oConfig = New ERMCONLOG.cConfiguracion
        bCargando = True
        lbGeneral.cParametros.UsuarioID = "Admin"
#End If

        oConfig.Recuperar()
        ConfigurarTitulos()
        ConfigurarGrid()
        'LlenarGridNoAsignadas()
        RecuperarDatos()
        HabilitarCampos()
        'CargarGrid()
        bHuboCambios = False
        bCargando = False
    End Sub

    Private Sub btAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAceptar.Click
        If Not ValidarDetalle() Then Exit Sub
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        'Venta
        If oConfig.CobrarVentas Then
            If Not bNuevoVta Then
                oCCOVta.Grabar()
            Else
                oCCOVta.Insertar()
                oCCOVta.Grabar()
            End If
            'Factura
        Else
            If Not bNuevoFac Then
                oCCOFac.Grabar()
            Else
                oCCOFac.Insertar()
                oCCOFac.Grabar()
            End If
        End If
        oConexion.ConfirmarTran()

        bCerrar = True
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Close()
    End Sub

    Private Sub btCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancelar.Click
        Me.Close()
    End Sub

    Private Sub btAsignarVta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAsignarVta.Click
        Asignar(grdNoAsignadasVta, oCCOVta)
    End Sub

    Private Sub btDesasignarVta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDesasignarVta.Click
        Desasignar(grdAsignadasVta, grdNoAsignadasVta, oCCOVta)
    End Sub

    Private Sub btArribaVta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btArribaVta.Click
        Mover(grdAsignadasVta, oCCOVta, True)
    End Sub

    Private Sub btAbajoVta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAbajoVta.Click
        Mover(grdAsignadasVta, oCCOVta, False)
    End Sub

    Private Sub btAsignarFac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAsignarFac.Click
        Asignar(grdNoAsignadasFac, oCCOFac)
    End Sub

    Private Sub btDesasignarFac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDesasignarFac.Click
        Desasignar(grdAsignadasFac, grdNoAsignadasFac, oCCOFac)
    End Sub

    Private Sub btArribaFac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btArribaFac.Click
        Mover(grdAsignadasFac, oCCOFac, True)
    End Sub

    Private Sub btAbajoFac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAbajoFac.Click
        Mover(grdAsignadasFac, oCCOFac, False)
    End Sub

    Private Sub grdAsignadasVta_UpdatingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdAsignadasVta.UpdatingRecord
        If Not IsNothing(grdAsignadasVta.GetValue("CriterioCobranzaDetId")) Then
            oCCOVta.CriterioCobranzaDet(grdAsignadasVta.GetValue("CriterioCobranzaDetId")).Ordenacion = grdAsignadasVta.GetValue("Ordenacion")
        End If
        bHuboCambios = True
    End Sub

    Private Sub grdAsignadasFac_UpdatingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdAsignadasFac.UpdatingRecord
        If Not IsNothing(grdAsignadasFac.GetValue("CriterioCobranzaDetId")) Then
            oCCOFac.CriterioCobranzaDet(grdAsignadasFac.GetValue("CriterioCobranzaDetId")).Ordenacion = grdAsignadasFac.GetValue("Ordenacion")
        End If
        bHuboCambios = True
    End Sub
End Class