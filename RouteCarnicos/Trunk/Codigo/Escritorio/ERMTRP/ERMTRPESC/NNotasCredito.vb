Imports ERMTRPLOG

Public Class NNotasCredito
    'Inherits FormasBase.Browse01


#Region " Variables "
    Private Shared oInstance As NNotasCredito = Nothing
    Private oConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private oTransProd As cTransProd
    Private oMensaje As BASMENLOG.CMensaje
    Private sComponente As String = "ERMTRPESC"
    Dim oAcceso As LbAcceso.cAcceso
#End Region

#Region " Metodos "
    Public Shared Function Instance() As NNotasCredito
        If oInstance Is Nothing OrElse oInstance.IsDisposed = True Then
            oInstance = New NNotasCredito
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
        'GridEx1.RootTable.Columns("UUID").Caption = oMensaje.RecuperarDescripcion("TDFUUID")
        'GridEx1.RootTable.Columns("UUID").HeaderToolTip = oMensaje.RecuperarDescripcion("TDFUUID")
        'GridEx1.RootTable.Columns("UUID").HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        'GridEx1.RootTable.Columns("UUID").Width = 230
        GridEx1.RootTable.Columns("FechaHoraAlta").Caption = oMensaje.RecuperarDescripcion(oTransProd.Mnemonico & "Fecha")
        GridEx1.RootTable.Columns("FechaHoraAlta").HeaderToolTip = oMensaje.RecuperarDescripcion(oTransProd.Mnemonico & "FechaT")
        GridEx1.RootTable.Columns("FechaHoraAlta").FormatString = "dd/MM/yyyy hh:mm:ss"
        GridEx1.RootTable.Columns("FechaHoraAlta").HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        GridEx1.RootTable.Columns("FechaHoraAlta").Width = 150
        GridEx1.RootTable.Columns("Total").Caption = oMensaje.RecuperarDescripcion("TRPTotal")
        GridEx1.RootTable.Columns("Total").HeaderToolTip = oMensaje.RecuperarDescripcion("TRPTotal")
        GridEx1.RootTable.Columns("Total").HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        GridEx1.RootTable.Columns("RazonSocial").Caption = oMensaje.RecuperarDescripcion("TDFRazonSocial")
        GridEx1.RootTable.Columns("RazonSocial").HeaderToolTip = oMensaje.RecuperarDescripcion("TDFRazonSocialT")
        GridEx1.RootTable.Columns("RazonSocial").HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        GridEx1.RootTable.Columns("RazonSocial").Width = 200
        GridEx1.RootTable.Columns("RFC").Caption = oMensaje.RecuperarDescripcion("TDFRFC")
        GridEx1.RootTable.Columns("RFC").HeaderToolTip = oMensaje.RecuperarDescripcion("TDFRFCT")
        GridEx1.RootTable.Columns("RFC").HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        GridEx1.RootTable.Columns("TipoNotaCredito").Caption = oMensaje.RecuperarDescripcion("TDFTipoNotaCredito")
        GridEx1.RootTable.Columns("TipoNotaCredito").HeaderToolTip = oMensaje.RecuperarDescripcion("TDFTipoNotaCreditoT")
        GridEx1.RootTable.Columns("TipoNotaCredito").HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        GridEx1.RootTable.Columns("TipoNotaCredito").Width = 200
        GridEx1.RootTable.Columns("TipoFase").Caption = oMensaje.RecuperarDescripcion(oTransProd.Mnemonico & "TipoFase")
        GridEx1.RootTable.Columns("TipoFase").HeaderToolTip = oMensaje.RecuperarDescripcion(oTransProd.Mnemonico & "TipoFaseT")
        GridEx1.RootTable.Columns("TipoFase").HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center


        'GridEx1.RootTable.Columns("TipoMotivo").Caption = oMensaje.RecuperarDescripcion(oTransProd.Mnemonico & "TipoMotivo")
        'GridEx1.RootTable.Columns("TipoMotivo").HeaderToolTip = oMensaje.RecuperarDescripcion(oTransProd.Mnemonico & "TipoMotivoT")
        'GridEx1.RootTable.Columns("TipoMotivo").HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        'GridEx1.RootTable.Columns("TipoMotivo").Width = 200

        'GridEx1.RootTable.Columns("SubEmpresa").Caption = oMensaje.RecuperarDescripcion("SEM" & "NombreEmpresa")
        'GridEx1.RootTable.Columns("SubEmpresa").HeaderToolTip = oMensaje.RecuperarDescripcion("SEM" & "NombreEmpresaT")
        'GridEx1.RootTable.Columns("SubEmpresa").HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        'GridEx1.RootTable.Columns("SubEmpresa").Width = 200

        btCrear.Tooltip = oMensaje.RecuperarDescripcion("btCrear")
        btConsultar.Tooltip = oMensaje.RecuperarDescripcion("btConsultar")
        btCancelar.Tooltip = oMensaje.RecuperarDescripcion("btCancelar")
        btImprimir.Tooltip = oMensaje.RecuperarDescripcion("btImprimir")
        btXML.Tooltip = oMensaje.RecuperarDescripcion("btXML")
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
            '.Columns(pvColumna).EditType = Janus.Windows.GridEX.EditType.DropDownList
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
        LlenarDropDownColumna("TipoNotaCredito", "TIPNOT")
        LlenarDropDownColumna("TipoFase", "TRPFASE")
    End Sub

    Private Sub Actualizar()
        Try
            Dim loDt As DataTable
            Dim sConsulta As String
            sConsulta = "select TRP.TransProdId, TRP.Folio, TDF.UUID, TRP.FechaHoraAlta, TRP.Total, TDF.RazonSocial, TDF.RFC, TDF.TipoNotaCredito, "
            sConsulta &= "TRP.TipoFase, SMH.VersionCFD "
            sConsulta &= "from TransProd TRP "
            sConsulta &= "inner join TRPDatoFiscal TDF on TRP.TransProdId = TDF.TransProdId "
            sConsulta &= "inner join SubEmpresa Sem on Sem.SubEmpresaId = Trp.SubEmpresaId "
            sConsulta &= "inner join (select top 1 * from SEMHist order by SEMHistFechaInicio desc) SMH on SEM.SubEmpresaId = SMH.SubEmpresaId "
            sConsulta &= "where TRP.Tipo = 10 "

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
        Dim lMNotasCredito As New MNotasCredito

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
                lMNotasCredito.LEER(oTransProd)
            End If
        End If

    End Sub

#End Region

#Region " Eventos "

    'Private Sub NNotasCredito_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '    MsgBox("Closing")
    'End Sub
    Private Sub NCargas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

#If DEBUG Then
        oConexion.Conectar("Provider=SQLOLEDB;Data Source=192.168.0.183\sql2008;user id=sa;password=dbsa;initial catalog=Panque31703")
        'oConexion.Conectar("Provider=SQLOLEDB;Data Source=localhost;user id=sa;password=Sql2008;initial catalog=Altenia")
        oMensaje = New BASMENLOG.CMensaje
        oMensaje.LlenarDataSet()
        'lbGeneral.cParametros.UsuarioID = "Admin"

        lbGeneral.cParametros.UsuarioID = "FacElec"
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

    'Private Sub GridEX1_FormattingRow(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowLoadEventArgs) Handles GridEx1.FormattingRow
    '    If e.Row.Cells("TipoMotivo").Value = Nothing OrElse e.Row.Cells("TipoMotivo").Value.ToString = "" Then Exit Sub

    '    If (e.Row.Cells("TipoMotivo").Value = "10" And e.Row.Cells("TipoFase").Value <> 0) Or e.Row.Cells("TipoMotivo").Value = "11" Then
    '        Dim rsRowStyle As New Janus.Windows.GridEX.GridEXFormatStyle
    '        rsRowStyle.ForeColor = System.Drawing.Color.Red
    '        e.Row.RowStyle = rsRowStyle
    '    End If
    'End Sub

    Private Sub GridEX1_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridEx1.SelectionChanged
        If GridEx1.RowCount > 0 Then
            'If GridEx1.GetRow.Cells("TipoMotivo").Value = "10" Or GridEx1.GetRow.Cells("TipoMotivo").Value = "11" Or GridEx1.GetRow.Cells("TipoFase").Value = 0 Then
            '    btXML.Enabled = False
            'Else
            If oAcceso.Otros Then
                btXML.Enabled = True
            End If
            'End If
        End If
    End Sub

    Private Sub btCrear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btCrear.Click
        Dim oMNotasCredito As New MNotasCredito
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

        lSubEmpresa.Clear()
        Try
            Dim ldtTabla As DataTable = oVendedor.Tabla.Recuperar("USUId='" & lbGeneral.cParametros.UsuarioID & "' AND TipoEstado=1")
            If ldtTabla.Rows.Count > 0 Then
                strTerminalClave = ldtTabla.Rows(0)!TerminalClave
                strVendedorId = ldtTabla.Rows(0)!VendedorId

                Dim loVENRUT As New ERMVERLOG.Amesol.CVenRut
                If loVENRUT.TablaNodo.Recuperar("VendedorId='" & strVendedorId & "' AND TipoEstado=1").Rows.Count > 0 Then
                    Throw New LbControlError.cError("E0798", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("XNotaCredito", True)})
                End If
            Else
                Throw New LbControlError.cError("E0797", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("XNotaCredito", True)})
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
                                oFolio.ObtenerFolioFiscal(strTerminalClave, Nothing, oParametros.SubEmpresaID, 2)
                            Else
                                oFolio.ObtenerFolioFiscal(Nothing, strVendedorId, oParametros.SubEmpresaID, 2)
                            End If
                            bFolios = True
                        Catch ex As Exception
                            sSinFoliosFiscales += oParametros.NombreEmpresa + ","
                            Continue For
                        End Try

                        If Not (IsDBNull(oParametros.ArchivoPEM) Or oParametros.ArchivoPEM = "") Then
                            bArchivoPEM = False

                        Else
                            sSinArchivoPEM += oParametros.NombreEmpresa + ","
                        End If

                        If Not (IsDBNull(oParametros.ArchivoPEM) Or oParametros.ArchivoPEM = "") And Not (IsDBNull(oParametros.CerBase64) Or oParametros.CerBase64 = "") Then
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
                Throw New LbControlError.cError("E0659")
            End If
            'Validar que exista el ArchivoPEM
            If bArchivoPEM Then
                Throw New LbControlError.cError("E0793")
            End If

            If bArchivoCER Then
                Throw New LbControlError.cError("E0841")
            End If


            If sSinArchivoPEM <> "" Then
                sSinArchivoPEM = sSinArchivoPEM.Substring(0, sSinArchivoPEM.Length - 1)
                Try
                    Throw New LbControlError.cError("I0203", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(sSinArchivoPEM, False)})
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
                    oFolio.ObtenerFolioFiscal(strTerminalClave, Nothing, oParametros.SubEmpresaID, 2)
                Else
                    oFolio.ObtenerFolioFiscal(Nothing, strVendedorId, oParametros.SubEmpresaID, 2)
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
            If oMNotasCredito.CREAR(oTransProd, lSubEmpresa.ToArray()) Then
                Call Actualizar()
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
        If (GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Or GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
            Dim vcTransprod As New cTransProd
            vcTransprod.Recuperar(GridEx1.GetRow.Cells("TransProdId").Value)
            Dim xml As New PRepXML(vcTransprod)
            xml.ShowDialog()
        End If
    End Sub

    Private Sub btImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btImprimir.Click
        If GridEx1.GetRow Is Nothing Then Exit Sub
        If (GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Or GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
            Dim oRep As New RRepFactElectronica
            oRep.CONSULTAR(GridEx1.GetRow.Cells("TransProdId").Value)
        End If
    End Sub

    Private Sub btCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btCancelar.Click
        Dim lMNotasCredito As New MNotasCredito

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
                    oTransProd.Tabla.Campos("MUsuarioId").Tipo = LbDatos.ETipo.Cadena
                    oTransProd.Bloquear()
                Catch ex As LbControlError.cError
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    oConexion.DeshacerTran()
                    MsgBox(oMensaje.RecuperarDescripcion("BI0003"), MsgBoxStyle.Information, oMensaje.RecuperarDescripcion("XMensajeI"))
                    Exit Sub
                End Try

                Me.Cursor = System.Windows.Forms.Cursors.Default
                If lMNotasCredito.CANCELAR(oTransProd) Then
                    oTransProd.ModificarEn(GridEx1.DataSource)
                    'If GridEx1.GetRow.Cells("TipoMotivo").Value.ToString = "" Then
                    '    GridEx1.GetRow.Cells("TipoMotivo").Value = ""
                    'ElseIf GridEx1.GetRow.Cells("TipoMotivo").Value = "0" Then
                    '    GridEx1.GetRow.Cells("TipoMotivo").Value = ""
                    'End If
                    Dim oTRPDatoFiscal As New ERMTRPLOG.cTRPDatoFiscal(oTransProd)
                    oTRPDatoFiscal.Recuperar(oTransProd.TransProdID)

                    btXML.Enabled = False
                End If
            End If
        End If
    End Sub

    

#End Region
End Class