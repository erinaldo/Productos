Imports ERMTRPLOG
Imports BASMENLOG

Public Class IFacturas
    Inherits FormasBase.Seleccionar01

    Dim vcConexion As LbConexion.cConexion
    Private oMensaje As CMensaje
    Private vcMultiseleccion As Boolean = False
    Public vcSeleccion As ArrayList
    Private oConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Dim oAcceso As LbAcceso.cAcceso

#Region "Funciones"

    Public Sub Carga_Grid()
        Cursor.Current = Cursors.WaitCursor
        Try

            Dim loPedido As New cTransProd

            'TODO: Agregar Msg a la base datos
            Me.Text = oMensaje.RecuperarDescripcion("ERMTRPESC_IFacturas")

            'Gridex1.ClearStructure()
            Dim sFiltroFecha As String = " and " + FiltroFecha("TRP.FechaFacturacion")

            Dim dt As DataTable = loPedido.ObtenerFacturasDispNotaCredito(sFiltroFecha)

            Gridex1.DataSource = dt
            'Gridex1.RetrieveStructure()

            ConfigurarGrid()

        Catch ex As LbControlError.cError
            ex.Mostrar()
        Catch ex As Exception
            Dim vlError As New LbControlError.cError("BF0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(ex.Source)}, , ex.Message)
            vlError.Mostrar()
        End Try

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub ConfigurarInterfaz()
        Dim lTootTip As New System.Windows.Forms.ToolTip

        'Titulos Controles
        Me.lblFecha.Text = oMensaje.RecuperarDescripcion("TRPFechaFacturacion")
        lbGeneral.LlenarComboBox(cbTipoFiltro, "BFNUMERI", 1)

        'Titulos Botones
        Me.btAceptar.Text = oMensaje.RecuperarDescripcion("btAceptar")
        Me.BtCancelar.Text = oMensaje.RecuperarDescripcion("btCancelar")

        Dim oToolTip As New ToolTip
        oToolTip.SetToolTip(btAceptar, oMensaje.RecuperarDescripcion("btAceptarT"))
        oToolTip.SetToolTip(btCancelar, oMensaje.RecuperarDescripcion("btCancelarT"))
    End Sub


    Sub ConfigurarGrid()
        Dim vlColumna As Janus.Windows.GridEX.GridEXColumn

        With Gridex1.RootTable
            For Each vlColumna In .Columns
                vlColumna.EditType = Janus.Windows.GridEX.EditType.NoEdit
                vlColumna.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                vlColumna.FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox
                vlColumna.Caption = oMensaje.RecuperarDescripcion(vlColumna.Tag)
                vlColumna.HeaderToolTip = oMensaje.RecuperarDescripcion(vlColumna.Tag & "T")
            Next
            .Columns("TransProdID").Visible = False
        End With

    End Sub

    Private Sub SeleccionarRegs()
        If Gridex1.GetRow Is Nothing Then Exit Sub
        If Gridex1.GetRow.DataRow Is Nothing Then Exit Sub
        vcSeleccion = New ArrayList

        If Gridex1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record Or Gridex1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Then
            vcSeleccion.Add(CType(Gridex1.GetRow.DataRow, DataRowView).Row)
        End If
    End Sub

    Public Function Seleccionar() As ArrayList
        vcConexion = LbConexion.cConexion.Instancia

        If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Return vcSeleccion
        Else
            Return Nothing
        End If

    End Function

    Function FiltroFecha(ByVal campoFecha As String) As String
        Dim sCond As String = ""
        Dim dFechaIni As Date = calFechaIni.Value

        Select Case Integer.Parse(cbTipoFiltro.SelectedValue)
            Case 1 '=
                sCond = " convert(datetime,Convert(varchar(20)," & campoFecha & ",112)) = '" & dFechaIni.Date.ToString("s") & "' "
            Case 2 '<>
                sCond = " convert(datetime,Convert(varchar(20)," & campoFecha & ",112)) <> '" & dFechaIni.Date.ToString("s") & "' "
            Case 3 '>
                sCond = " convert(datetime,Convert(varchar(20)," & campoFecha & ",112)) > '" & dFechaIni.Date.ToString("s") & "' "
            Case 4 '<
                sCond = " convert(datetime,Convert(varchar(20)," & campoFecha & ",112)) < '" & dFechaIni.Date.ToString("s") & "' "
            Case 5 '>=
                sCond = " convert(datetime,Convert(varchar(20)," & campoFecha & ",112)) >= '" & dFechaIni.Date.ToString("s") & "' "
            Case 6 '<=
                sCond = " convert(datetime,Convert(varchar(20)," & campoFecha & ",112)) <= '" & dFechaIni.Date.ToString("s") & "' "
            Case 7 '/
                Dim dFechaFin As Date = calFechaFin.Value
                sCond = " convert(datetime,Convert(varchar(20)," & campoFecha & ",112)) between '" & dFechaIni.Date.ToString("s") & "' and '" & dFechaFin.Date.ToString("s") & "' "
        End Select
        Return sCond
    End Function


#End Region

#Region "Eventos"

    Private Sub IFacturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
        Carga_Grid()

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

    Private Sub cbTipoFiltro_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTipoFiltro.SelectedValueChanged
        calFechaFin.Enabled = (cbTipoFiltro.SelectedValue = 7)
    End Sub

#End Region

    Private Sub btFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFiltrar.Click
        If Integer.Parse(cbTipoFiltro.SelectedValue) = 7 Then
            If calFechaFin.Value.Date <= calFechaIni.Value.Date Then
                MsgBox(oMensaje.RecuperarDescripcion("E0008"), MsgBoxStyle.Information Or MsgBoxStyle.Exclamation, oMensaje.RecuperarDescripcion("XMensajeE"))
                Exit Sub
            End If
        End If
        Carga_Grid()
    End Sub
End Class