Imports BASMENLOG
Imports System.Collections.Generic

Public Class IMetodosPago
    Inherits FormasBase.Seleccionar01

    Public Class MetodoPago
        Private _Metodo As String
        Private _Banco As String
        Private _Cuenta As String
        Private _TipoMetodo As Integer
        Private _TipoBanco As Object

        Public Property Metodo() As String
            Get
                Return _Metodo
            End Get
            Set(ByVal value As String)
                _Metodo = value
            End Set
        End Property
        Public Property Banco() As String
            Get
                Return _Banco
            End Get
            Set(ByVal value As String)
                _Banco = value
            End Set
        End Property


        Public Property Cuenta() As String
            Get
                Return _Cuenta
            End Get
            Set(ByVal value As String)
                _Cuenta = value
            End Set
        End Property

        Public Property TipoMetodo() As Integer
            Get
                Return _TipoMetodo
            End Get
            Set(ByVal value As Integer)
                _TipoMetodo = value
            End Set
        End Property

        Public Property TipoBanco() As Object
            Get
                Return _TipoBanco
            End Get
            Set(ByVal value As Object)
                _TipoBanco = value
            End Set
        End Property
        Public Sub New(ByVal pMetodo As String, ByVal pTipoMetodo As Integer, ByVal pBanco As String, ByVal pTipoBanco As Object, ByVal pCuenta As String)
            _Metodo = pMetodo
            _Banco = pBanco
            _Cuenta = pCuenta
            _TipoMetodo = pTipoMetodo
            _TipoBanco = pTipoBanco
        End Sub

        Public Sub New(ByVal pMetodo As String, ByVal pBanco As String, ByVal pCuenta As String)
            _Metodo = pMetodo
            _Banco = pBanco
            _Cuenta = pCuenta
        End Sub

    End Class
    Private oMensaje As CMensaje
    Private oConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private aSeleccion As New Collections.Generic.List(Of MetodoPago)
    Private sClienteClave As String
    Private bIncluirCuentas As Boolean
    'Private sSeleccion As String = String.Empty
    Private aMetodosSeleccionados As Collections.Generic.IList(Of MetodoPago)
    Private iTipoNoIdentificado As Integer
    Dim htEfectivo As Hashtable

    Private Sub ConfigurarInterfaz()
        Dim lTootTip As New System.Windows.Forms.ToolTip
        Me.Text = oMensaje.RecuperarDescripcion("ERMTRPESC_IMetodosPago")

        ConfigurarGrid()

        'Titulos Botones
        Me.btAceptar.Text = oMensaje.RecuperarDescripcion("btAceptar")
        Me.BtCancelar.Text = oMensaje.RecuperarDescripcion("btCancelar")

        Dim oToolTip As New ToolTip
        oToolTip.SetToolTip(btAceptar, oMensaje.RecuperarDescripcion("btAceptarT"))
        oToolTip.SetToolTip(btCancelar, oMensaje.RecuperarDescripcion("btCancelarT"))
    End Sub

    Private Sub ConfigurarGrid()
        Gridex1.RootTable.Columns("TipoMetodo").Caption = oMensaje.RecuperarDescripcion("TDFMetodoPago")
        Gridex1.RootTable.Columns("TipoMetodo").HeaderToolTip = oMensaje.RecuperarDescripcion("TDFMetodoPagoT")

        lbGeneral.LlenarColumna(Gridex1.RootTable.Columns("TipoMetodo"), "PAGO")
        lbGeneral.LlenarColumna(Gridex1.Tables("MetodosPago_BancosCuentas").Columns("TipoBanco"), "TBANCO")

        grCapturaMetodosPago.RootTable.Columns("TipoMetodo").Caption = oMensaje.RecuperarDescripcion("TDFMetodoPago")
        grCapturaMetodosPago.RootTable.Columns("TipoMetodo").HeaderToolTip = oMensaje.RecuperarDescripcion("TDFMetodoPagoT")
        grCapturaMetodosPago.RootTable.Columns("Cuenta").Caption = oMensaje.RecuperarDescripcion("TDFNumerosCuenta")
        grCapturaMetodosPago.RootTable.Columns("Cuenta").HeaderToolTip = oMensaje.RecuperarDescripcion("TDFNumerosCuentaT")
        grCapturaMetodosPago.RootTable.Columns("TipoBanco").Caption = oMensaje.RecuperarDescripcion("TDFBanco")
        grCapturaMetodosPago.RootTable.Columns("TipoBanco").HeaderToolTip = oMensaje.RecuperarDescripcion("TDFBancoT")

        lbGeneral.LlenarColumnaActivos(grCapturaMetodosPago.RootTable.Columns("TipoMetodo"), "PAGO")
        lbGeneral.LlenarColumnaActivos(grCapturaMetodosPago.RootTable.Columns("TipoBanco"), "TBANCO")
    End Sub

    Private Sub LlenarGrid()
        Dim sConsulta As String = String.Empty

        If (bIncluirCuentas) Then

            sConsulta = "Select cast(0 as bit) as Selector, cast(Tipo as int) as TipoMetodo, CASE WHEN TipoBanco =0 THEN null ELSE TipoBanco END as TipoBanco, Cuenta from ClientePago CLP inner join VARValor VAV on VAV.VARCodigo = 'PAGO' and  CLP.Tipo = VAV.VAVClave and VAV.Estado = 1 where TipoEstado = 1 and ClienteClave='" + sClienteClave + "' "
            Dim dtBancosCuentas As DataTable = oConexion.EjecutarConsulta(sConsulta)
            If dtBancosCuentas.Rows.Count <= 0 Then
                Gridex1.Visible = False
                grCapturaMetodosPago.Visible = True
                btEliminar.Visible = True
                btCrear.Visible = True

                If Not IsNothing(aMetodosSeleccionados) Then
                    Dim dr As DataRow
                    For Each oMetodo As MetodoPago In aMetodosSeleccionados
                        dr = dtBancosCuentas.NewRow()
                        dr("TipoMetodo") = oMetodo.TipoMetodo
                        dr("Cuenta") = oMetodo.Cuenta
                        dr("TipoBanco") = oMetodo.TipoBanco
                        dtBancosCuentas.Rows.Add(dr)
                    Next
                    dtBancosCuentas.AcceptChanges()
                End If
                grCapturaMetodosPago.DataSource = dtBancosCuentas
                btCrear_Click(Nothing, Nothing)
            Else
                Gridex1.Visible = True
                grCapturaMetodosPago.Visible = False
                btEliminar.Visible = False
                btCrear.Visible = False
                sConsulta = "select cast(VAD.VAVClave as int) as TipoMetodo from VAVDescripcion VAD inner join VARValor VAV on VAD.VARCodigo = VAV.VARCodigo and VAD.VAVClave = VAV.VAVClave where VAV.Estado = 1 and VAD.VARCodigo = 'PAGO' and VADTipoLenguaje = '" & lbGeneral.cParametros.Lenguaje & "' "
                Dim dsMetodos As New DataSet
                Dim dtMetodos As DataTable = oConexion.EjecutarConsulta(sConsulta)
                dtMetodos.TableName = "MetodosPago"
                dsMetodos.Tables.Add(dtMetodos)
                Gridex1.RootTable.Columns("Selector").Visible = False
                Gridex1.Hierarchical = True

                For Each dr As DataRow In dtBancosCuentas.Select("(TipoBanco is null or TipoBanco=0) and (Cuenta is null or Cuenta = '')")
                    dtBancosCuentas.Rows.Remove(dr)
                Next

                For Each dr As DataRow In dtMetodos.Rows
                    Dim drNoDefinido As DataRow = dtBancosCuentas.NewRow
                    drNoDefinido("Selector") = False
                    drNoDefinido("TipoMetodo") = dr("TipoMetodo")
                    drNoDefinido("Cuenta") = oMensaje.RecuperarDescripcion("XNoIdentificado")
                    dtBancosCuentas.Rows.Add(drNoDefinido)
                Next


                If Not IsNothing(aMetodosSeleccionados) AndAlso aMetodosSeleccionados.Count > 0 Then
                    Dim drs As DataRow()
                    For Each oMetodo As MetodoPago In aMetodosSeleccionados
                        If htEfectivo.ContainsKey(oMetodo.TipoMetodo.ToString) OrElse oMetodo.TipoMetodo = iTipoNoIdentificado OrElse (oMetodo.Cuenta = "" And oMetodo.Banco = "") Then
                            drs = dtBancosCuentas.Select("TipoMetodo=" + oMetodo.TipoMetodo.ToString())
                            If drs.Length > 0 Then
                                drs(0)("Selector") = True
                            End If
                        Else
                            If oMetodo.Cuenta <> "" And oMetodo.Banco <> "" Then
                                drs = dtBancosCuentas.Select("TipoMetodo=" + oMetodo.TipoMetodo.ToString() + " and Cuenta='" + IIf(oMetodo.Cuenta.ToString() = "*", "", oMetodo.Cuenta.ToString()) + "'  and TipoBanco=" + oMetodo.TipoBanco.ToString)
                            ElseIf oMetodo.Cuenta = "" And oMetodo.Banco <> "" Then
                                drs = dtBancosCuentas.Select("TipoMetodo=" + oMetodo.TipoMetodo.ToString() + " and TipoBanco=" + oMetodo.TipoBanco.ToString)
                            Else
                                drs = dtBancosCuentas.Select("TipoMetodo=" + oMetodo.TipoMetodo.ToString() + " and Cuenta='" + IIf(oMetodo.Cuenta.ToString() = "*", "", oMetodo.Cuenta.ToString()) + "' ")
                            End If
                            If drs.Length > 0 Then
                                drs(0)("Selector") = True
                            End If
                        End If
                        'dtBancosCuentas.Select("TipoMetodo=" + oMetodo.TipoMetodo + " and  TipoBanco = " + oMetodo.TipoBanco + " and Cuenta='" + oMetodo.Cuenta + "'")
                    Next
                End If

                dtBancosCuentas.AcceptChanges()
                dtBancosCuentas.TableName = "BancosCuentas"
                dsMetodos.Tables.Add(dtBancosCuentas)
                dsMetodos.Relations.Add("MetodosPago_BancosCuentas", dsMetodos.Tables("MetodosPago").Columns("TipoMetodo"), dsMetodos.Tables("BancosCuentas").Columns("TipoMetodo"))

                Gridex1.DataSource = dsMetodos
                Gridex1.DataMember = "MetodosPago"
                Gridex1.ExpandRecords()

            End If
        End If
    End Sub

    Public Function SeleccionarMetodosCuentas(ByVal clienteClave As String, ByVal pMetodosSeleccionados As Collections.Generic.List(Of MetodoPago)) As Collections.Generic.IList(Of MetodoPago)
        sClienteClave = clienteClave
        bIncluirCuentas = True

        aMetodosSeleccionados = pMetodosSeleccionados

        If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Return aSeleccion
        Else
            Return Nothing
        End If
    End Function

    Private Sub SeleccionarRegs()

        If Gridex1.Visible Then
            If bIncluirCuentas Then
                Dim sBanco As String
                Dim sCuenta As String

                For Each row2 As Janus.Windows.GridEX.GridEXRow In Gridex1.GetRows
                    For Each row As Janus.Windows.GridEX.GridEXRow In row2.GetChildRows
                        If row.Cells("Selector").Value = True Then
                            If (htEfectivo.ContainsKey(row.Parent.Cells("TipoMetodo").Value.ToString) OrElse (row.Parent.Cells("TipoMetodo").Value = iTipoNoIdentificado)) Then
                                sBanco = ""
                                sCuenta = ""
                            Else
                                sBanco = row.Cells("TipoBanco").Text
                                sCuenta = row.Cells("Cuenta").Text
                            End If

                            Dim oMetodo As New MetodoPago(row.Parent.Cells("TipoMetodo").Text, row.Parent.Cells("TipoMetodo").Value, sBanco, row.Cells("TipoBanco").Value, sCuenta)
                            aSeleccion.Add(oMetodo)
                        End If
                    Next
                Next
            End If
        Else 'si se capturan los datos
            Dim sBanco As String
            Dim sCuenta As String

            For Each row As Janus.Windows.GridEX.GridEXRow In grCapturaMetodosPago.GetRows
                If ((htEfectivo.ContainsKey(row.Cells("TipoMetodo").Value.ToString)) OrElse (row.Cells("TipoMetodo").Value = iTipoNoIdentificado)) Then
                    sBanco = ""
                    sCuenta = ""
                Else
                    sBanco = row.Cells("TipoBanco").Text
                    sCuenta = row.Cells("Cuenta").Text
                End If

                Dim oMetodo As New MetodoPago(row.Cells("TipoMetodo").Text, row.Cells("TipoMetodo").Value, sBanco, row.Cells("TipoBanco").Value, sCuenta)
                aSeleccion.Add(oMetodo)
            Next
        End If

    End Sub

    Private Sub IMetodosPago_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '#If DEBUG Then
        '        'oConexion.Conectar("Provider=SQLOLEDB.1;Persist Security Info=True;User ID=sa;password=dbsa;Initial Catalog=LACTIGURT230;Data Source=localhost\sqlexpress")
        '        oConexion.Conectar("Provider=SQLOLEDB.1;Persist Security Info=True;User ID=sa;password=dbsa;Initial Catalog=route;Data Source=rafiki")
        '        oMensaje = New BASMENLOG.CMensaje
        '        oMensaje.LlenarDataSet()
        '        'lbGeneral.cParametros.UsuarioID = "Admin"
        '        lbGeneral.cParametros.UsuarioID = "26PKB2C2AHNRELF"
        '        Dim oKeyGen As New lbGeneral.cKeyGen
        '        oAcceso = New LbAcceso.cAcceso 'LbAcceso.cAcceso
        '        oAcceso.Modificar = False
        '        oAcceso.Leer = True
        '        oAcceso.Crear = True
        '        oAcceso.Print = False
        '        oAcceso.Otros = False

        '#End If

        oMensaje = New BASMENLOG.CMensaje

        ConfigurarInterfaz()

        Dim htIndefinido As Hashtable = lbGeneral.ValoresDescripcionVARValor("PAGO", "NI")

        For Each Key As Integer In htIndefinido.Keys
            iTipoNoIdentificado = Key
        Next

        htEfectivo = lbGeneral.ValoresDescripcionVARValor("PAGO", "E")

        LlenarGrid()

    End Sub

    Private Sub BtAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAceptar.Click
        SeleccionarRegs()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btEliminar.Click
        If (grCapturaMetodosPago.RowCount = 0) Then
            Exit Sub
        End If

        grCapturaMetodosPago.CancelCurrentEdit()
        If (grCapturaMetodosPago.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
            Call DeshabilitaCrear(grCapturaMetodosPago)
        ElseIf (grCapturaMetodosPago.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
            grCapturaMetodosPago.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
            grCapturaMetodosPago.Delete()
            grCapturaMetodosPago.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
        End If

    End Sub

    Private Sub grCapturaMetodosPago_AddingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grCapturaMetodosPago.AddingRecord
        If IsDBNull(grCapturaMetodosPago.CurrentRow().Cells("TipoMetodo").Value) Then
            MsgBox(oMensaje.RecuperarDescripcion("BE0001").Replace("$0$", oMensaje.RecuperarDescripcion("TDFMetodoPago")))
            e.Cancel = True
        Else
            Dim dtBancosCuentas As DataTable = grCapturaMetodosPago.DataSource

            If (htEfectivo.ContainsKey(grCapturaMetodosPago.CurrentRow().Cells("TipoMetodo").Value.ToString) Or grCapturaMetodosPago.CurrentRow().Cells("TipoMetodo").Value = iTipoNoIdentificado) Then
                If dtBancosCuentas.Select("TipoMetodo = " + grCapturaMetodosPago.CurrentRow().Cells("TipoMetodo").Value.ToString).Length > 0 Then
                    MsgBox(oMensaje.RecuperarDescripcion("BE0002"))
                    e.Cancel = True
                End If
            ElseIf (grCapturaMetodosPago.CurrentRow.Cells("Cuenta").Text <> "" And grCapturaMetodosPago.CurrentRow.Cells("TipoBanco").Text <> "") Then
                If dtBancosCuentas.Select("TipoMetodo=" + grCapturaMetodosPago.CurrentRow.Cells("TipoMetodo").Value.ToString + " and Cuenta ='" + grCapturaMetodosPago.CurrentRow.Cells("Cuenta").Value.ToString + "' and TipoBanco=" + grCapturaMetodosPago.CurrentRow.Cells("TipoBanco").Value.ToString).Length > 1 Then
                    MsgBox(oMensaje.RecuperarDescripcion("BE0002"))
                    e.Cancel = True
                End If
            ElseIf (grCapturaMetodosPago.CurrentRow.Cells("Cuenta").Text = "") Then
                MsgBox(oMensaje.RecuperarDescripcion("BE0001").Replace("$0$", oMensaje.RecuperarDescripcion("TDFNumerosCuenta")))
                e.Cancel = True
            Else
                If dtBancosCuentas.Select("TipoMetodo=" + grCapturaMetodosPago.CurrentRow.Cells("TipoMetodo").Value.ToString + " and Cuenta='" + grCapturaMetodosPago.CurrentRow.Cells("Cuenta").Value.ToString + "'").Length > 0 Then
                    MsgBox(oMensaje.RecuperarDescripcion("BE0002"))
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub grCapturaMetodosPago_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grCapturaMetodosPago.CellEdited
        If e.Column.Key = "TipoMetodo" Then
            If (Not IsNothing(grCapturaMetodosPago.CurrentRow.Cells("TipoMetodo").Value)) AndAlso (Not IsDBNull(grCapturaMetodosPago.CurrentRow.Cells("TipoMetodo").Value)) AndAlso (htEfectivo.ContainsKey(grCapturaMetodosPago.CurrentRow.Cells("TipoMetodo").Value.ToString) OrElse grCapturaMetodosPago.CurrentRow.Cells("TipoMetodo").Value = iTipoNoIdentificado) Then
                grCapturaMetodosPago.CurrentRow.Cells("Cuenta").Value = ""
                grCapturaMetodosPago.CurrentRow.Cells("TipoBanco").Value = DBNull.Value
                grCapturaMetodosPago.RootTable.Columns("Cuenta").EditType = Janus.Windows.GridEX.EditType.NoEdit
                grCapturaMetodosPago.RootTable.Columns("TipoBanco").EditType = Janus.Windows.GridEX.EditType.NoEdit
            ElseIf (Not IsNothing(grCapturaMetodosPago.CurrentRow.Cells("Cuenta").Value)) AndAlso (Not IsDBNull(grCapturaMetodosPago.CurrentRow.Cells("Cuenta").Value)) AndAlso (grCapturaMetodosPago.CurrentRow.Cells("Cuenta").Value.ToString.ToUpper = "NO IDENTIFICADO") Then
                grCapturaMetodosPago.CurrentRow.Cells("TipoBanco").Value = DBNull.Value
                grCapturaMetodosPago.RootTable.Columns("TipoBanco").EditType = Janus.Windows.GridEX.EditType.NoEdit
                grCapturaMetodosPago.RootTable.Columns("Cuenta").EditType = Janus.Windows.GridEX.EditType.TextBox
            Else
                grCapturaMetodosPago.RootTable.Columns("Cuenta").EditType = Janus.Windows.GridEX.EditType.TextBox
                grCapturaMetodosPago.RootTable.Columns("TipoBanco").EditType = Janus.Windows.GridEX.EditType.DropDownList
            End If
        ElseIf e.Column.Key = "Cuenta" Then
            If (Not IsNothing(grCapturaMetodosPago.CurrentRow.Cells("Cuenta").Value)) AndAlso (Not IsDBNull(grCapturaMetodosPago.CurrentRow.Cells("Cuenta").Value)) AndAlso (grCapturaMetodosPago.CurrentRow.Cells("Cuenta").Value.ToString.ToUpper = "NO IDENTIFICADO") Then
                grCapturaMetodosPago.CurrentRow.Cells("TipoBanco").Value = DBNull.Value
                grCapturaMetodosPago.RootTable.Columns("TipoBanco").EditType = Janus.Windows.GridEX.EditType.NoEdit
                grCapturaMetodosPago.RootTable.Columns("Cuenta").EditType = Janus.Windows.GridEX.EditType.TextBox
            Else
                grCapturaMetodosPago.RootTable.Columns("TipoBanco").EditType = Janus.Windows.GridEX.EditType.DropDownList
                grCapturaMetodosPago.RootTable.Columns("Cuenta").EditType = Janus.Windows.GridEX.EditType.TextBox
            End If
        End If
    End Sub


    Private Sub grCapturaMetodosPago_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grCapturaMetodosPago.SelectionChanged
        With grCapturaMetodosPago
            If Not (.GetRow Is Nothing) Then
                'If (.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
                If (Not IsNothing(.GetRow.Cells("TipoMetodo").Value) AndAlso Not IsDBNull(.GetRow.Cells("TipoMetodo").Value) AndAlso (htEfectivo.ContainsKey(.GetRow.Cells("TipoMetodo").Value.ToString) OrElse .GetRow.Cells("TipoMetodo").Value = iTipoNoIdentificado)) Then
                    .RootTable.Columns("TipoBanco").EditType = Janus.Windows.GridEX.EditType.NoEdit
                    .RootTable.Columns("Cuenta").EditType = Janus.Windows.GridEX.EditType.NoEdit
                ElseIf Not IsNothing(.GetRow.Cells("Cuenta").Value) AndAlso Not IsDBNull(.GetRow.Cells("TipoMetodo").Value) AndAlso (.GetRow.Cells("Cuenta").Value.ToString.ToUpper() = "NO IDENTIFICADO") Then
                    .RootTable.Columns("TipoBanco").EditType = Janus.Windows.GridEX.EditType.NoEdit
                    .RootTable.Columns("Cuenta").EditType = Janus.Windows.GridEX.EditType.TextBox
                Else
                    .RootTable.Columns("TipoBanco").EditType = Janus.Windows.GridEX.EditType.DropDownList
                    .RootTable.Columns("Cuenta").EditType = Janus.Windows.GridEX.EditType.TextBox
                End If
                'Else
                '    If .GetRow.DataRow.Row.RowState = DataRowState.Added Then
                '        .RootTable.Columns("Clave").EditType = Janus.Windows.GridEX.EditType.TextBox
                '    Else
                '        .RootTable.Columns("Clave").EditType = Janus.Windows.GridEX.EditType.NoEdit
                '    End If
                'End If
            End If
        End With

        'If grPromocionDetalle.RowCount > 0 AndAlso Not grPromocionDetalle.GetRow Is Nothing AndAlso (vcModo = eModo.Crear Or vcModo = eModo.Modificar Or vcModo = eModo.Copiar) Then
        '    If (grPromocionDetalle.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
        '        btPMDEliminar.Enabled = False
        '    Else
        '        If grPromocionDetalle.GetRow.DataRow.Row.RowState = DataRowState.Added And vcPromocion.TipoEstado = 1 Then
        '            btPMDEliminar.Enabled = True
        '        Else
        '            btPMDEliminar.Enabled = False
        '        End If
        '    End If
        'Else
        '    btPMDEliminar.Enabled = False
        'End If
        'vcEsquemaId = lbGeneral.ChkDbNull(grPromocionDetalle.GetValue("EsquemaId"))
    End Sub

    'Private bCancelando As Boolean = False

    Private Sub grCapturaMetodosPago_UpdatingCell(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.UpdatingCellEventArgs) Handles grCapturaMetodosPago.UpdatingCell
        If e.Column.Key.ToUpper = "CUENTA" Then
            If Not IsDBNull(e.Value) AndAlso Not IsNothing(e.Value) Then
                'If bCancelando Then Exit Sub
                'bCancelando = True
                If (Not IsNumeric(e.Value)) AndAlso e.Value.ToString().ToUpper <> "NO IDENTIFICADO" Then
                    MsgBox(oMensaje.RecuperarDescripcion("E0884"))
                    e.Cancel = True
                End If
            End If
        End If
        'bCancelando = False
    End Sub

    Private Sub grCapturaMetodosPago_UpdatingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grCapturaMetodosPago.UpdatingRecord
        If IsDBNull(grCapturaMetodosPago.CurrentRow().Cells("TipoMetodo").Value) Then
            MsgBox(oMensaje.RecuperarDescripcion("BE0001").Replace("$0$", oMensaje.RecuperarDescripcion("TDFMetodoPago")))
            e.Cancel = True
        Else
            Dim dtBancosCuentas As DataTable = grCapturaMetodosPago.DataSource

            If (htEfectivo.ContainsKey(grCapturaMetodosPago.CurrentRow().Cells("TipoMetodo").Value.ToString) Or grCapturaMetodosPago.CurrentRow().Cells("TipoMetodo").Value = iTipoNoIdentificado) Then
                If dtBancosCuentas.Select("TipoMetodo = " + grCapturaMetodosPago.CurrentRow().Cells("TipoMetodo").Value.ToString).Length > 1 Then
                    MsgBox(oMensaje.RecuperarDescripcion("BE0002"))
                    e.Cancel = True
                End If
            ElseIf (grCapturaMetodosPago.CurrentRow.Cells("Cuenta").Text <> "" And grCapturaMetodosPago.CurrentRow.Cells("TipoBanco").Text <> "") Then
                For Each renglon As Janus.Windows.GridEX.GridEXRow In grCapturaMetodosPago.GetRows
                    If renglon.Position <> grCapturaMetodosPago.CurrentRow.Position AndAlso renglon.Cells("TipoMetodo").Value = grCapturaMetodosPago.CurrentRow.Cells("TipoMetodo").Value AndAlso renglon.Cells("Cuenta").Value = grCapturaMetodosPago.CurrentRow.Cells("Cuenta").Value AndAlso renglon.Cells("TipoBanco").Value = grCapturaMetodosPago.CurrentRow.Cells("TipoBanco").Value Then
                        MsgBox(oMensaje.RecuperarDescripcion("BE0002"))
                        e.Cancel = True
                    End If
                Next
            ElseIf (grCapturaMetodosPago.CurrentRow.Cells("Cuenta").Text = "") Then
                MsgBox(oMensaje.RecuperarDescripcion("BE0001").Replace("$0$", oMensaje.RecuperarDescripcion("TDFNumerosCuenta")))
                e.Cancel = True
            Else
                For Each renglon As Janus.Windows.GridEX.GridEXRow In grCapturaMetodosPago.GetRows
                    If renglon.Position <> grCapturaMetodosPago.CurrentRow.Position AndAlso renglon.Cells("TipoMetodo").Value = grCapturaMetodosPago.CurrentRow.Cells("TipoMetodo").Value AndAlso renglon.Cells("Cuenta").Value = grCapturaMetodosPago.CurrentRow.Cells("Cuenta").Value Then
                        MsgBox(oMensaje.RecuperarDescripcion("BE0002"))
                        e.Cancel = True
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub btCrear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCrear.Click
        grCapturaMetodosPago.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
        grCapturaMetodosPago.Col = 0
        grCapturaMetodosPago.MoveToNewRecord()
        grCapturaMetodosPago.Focus()
    End Sub

    Private Sub DeshabilitaCrear(ByRef peGridEx As Janus.Windows.GridEX.GridEX)
        If peGridEx.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True Then
            If (peGridEx.GetRow.RowType = Janus.Windows.GridEX.RowType.Record Or peGridEx.DataChanged = False) Then
                peGridEx.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                If (peGridEx.Row = 0) Then
                    Try
                        peGridEx.MoveLast()
                    Catch ex As Exception

                    End Try

                End If
            End If
        End If
    End Sub
End Class