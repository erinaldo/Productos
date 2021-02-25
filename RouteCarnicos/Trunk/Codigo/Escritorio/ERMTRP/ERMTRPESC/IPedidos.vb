Imports ERMTRPLOG
Imports BASMENLOG

Public Class IPedidos
    Inherits FormasBase.Seleccionar01

    Dim vcConexion As LbConexion.cConexion
    Private oMensaje As CMensaje
    Private vcMultiseleccion As Boolean = True
    Public vcSeleccion As ArrayList
    Private vcFiltro As String = ""
    Private oConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents cbTipoFiltro As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents calFechaIni As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents calFechaFin As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents btFiltrar As Janus.Windows.EditControls.UIButton
    Dim oAcceso As LbAcceso.cAcceso


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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Gridex1_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IPedidos))
        Me.lblFecha = New System.Windows.Forms.Label
        Me.cbTipoFiltro = New Janus.Windows.EditControls.UIComboBox
        Me.calFechaIni = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.calFechaFin = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.btFiltrar = New Janus.Windows.EditControls.UIButton
        CType(Me.Gridex1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Gridex1
        '
        Gridex1_DesignTimeLayout.LayoutString = resources.GetString("Gridex1_DesignTimeLayout.LayoutString")
        Me.Gridex1.DesignTimeLayout = Gridex1_DesignTimeLayout
        Me.Gridex1.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.Gridex1.Location = New System.Drawing.Point(12, 35)
        Me.Gridex1.Size = New System.Drawing.Size(616, 381)
        '
        'BtAceptar
        '
        Me.BtAceptar.Location = New System.Drawing.Point(406, 422)
        '
        'BtCancelar
        '
        Me.BtCancelar.Location = New System.Drawing.Point(518, 422)
        '
        'lblFecha
        '
        Me.lblFecha.BackColor = System.Drawing.Color.Transparent
        Me.lblFecha.Location = New System.Drawing.Point(7, 10)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(118, 20)
        Me.lblFecha.TabIndex = 28
        Me.lblFecha.Text = "Fecha"
        Me.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbTipoFiltro
        '
        Me.cbTipoFiltro.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbTipoFiltro.Location = New System.Drawing.Point(131, 10)
        Me.cbTipoFiltro.Name = "cbTipoFiltro"
        Me.cbTipoFiltro.Size = New System.Drawing.Size(152, 20)
        Me.cbTipoFiltro.TabIndex = 27
        '
        'calFechaIni
        '
        '
        '
        '
        Me.calFechaIni.DropDownCalendar.FirstMonth = New Date(2008, 10, 1, 0, 0, 0, 0)
        Me.calFechaIni.DropDownCalendar.Name = ""
        Me.calFechaIni.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Standard
        Me.calFechaIni.Location = New System.Drawing.Point(289, 10)
        Me.calFechaIni.Name = "calFechaIni"
        Me.calFechaIni.Size = New System.Drawing.Size(128, 20)
        Me.calFechaIni.TabIndex = 25
        '
        'calFechaFin
        '
        '
        '
        '
        Me.calFechaFin.DropDownCalendar.FirstMonth = New Date(2008, 10, 1, 0, 0, 0, 0)
        Me.calFechaFin.DropDownCalendar.Name = ""
        Me.calFechaFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Standard
        Me.calFechaFin.Enabled = False
        Me.calFechaFin.Location = New System.Drawing.Point(423, 10)
        Me.calFechaFin.Name = "calFechaFin"
        Me.calFechaFin.Size = New System.Drawing.Size(128, 20)
        Me.calFechaFin.TabIndex = 26
        '
        'btFiltrar
        '
        Me.btFiltrar.Icon = CType(resources.GetObject("btFiltrar.Icon"), System.Drawing.Icon)
        Me.btFiltrar.Location = New System.Drawing.Point(553, 10)
        Me.btFiltrar.Name = "btFiltrar"
        Me.btFiltrar.Size = New System.Drawing.Size(23, 23)
        Me.btFiltrar.TabIndex = 29
        Me.btFiltrar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'IPedidos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(640, 451)
        Me.Controls.Add(Me.btFiltrar)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.cbTipoFiltro)
        Me.Controls.Add(Me.calFechaIni)
        Me.Controls.Add(Me.calFechaFin)
        Me.Name = "IPedidos"
        Me.Controls.SetChildIndex(Me.Gridex1, 0)
        Me.Controls.SetChildIndex(Me.BtAceptar, 0)
        Me.Controls.SetChildIndex(Me.BtCancelar, 0)
        Me.Controls.SetChildIndex(Me.calFechaFin, 0)
        Me.Controls.SetChildIndex(Me.calFechaIni, 0)
        Me.Controls.SetChildIndex(Me.cbTipoFiltro, 0)
        Me.Controls.SetChildIndex(Me.lblFecha, 0)
        Me.Controls.SetChildIndex(Me.btFiltrar, 0)
        CType(Me.Gridex1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


#Region "Funciones"

    Public Sub Carga_Grid()
        Cursor.Current = Cursors.WaitCursor
        Try

            Dim loPedido As New cTransProd

            'TODO: Agregar Msg a la base datos
            Me.Text = oMensaje.RecuperarDescripcion("ERMTRPESC_IPEDIDOS")

            Gridex1.ClearStructure()
            Dim sFiltroFecha As String = " and " + FiltroFecha("FechaEntrega")

            Dim dt As DataTable = loPedido.ObtenerPedidoFacturar(sFiltroFecha, vcFiltro)

            Gridex1.DataSource = dt
            Gridex1.RetrieveStructure()

            Dim colSelector As New Janus.Windows.GridEX.GridEXColumn
            colSelector.Key = "Seleccion"
            colSelector.ActAsSelector = True
            colSelector.AllowDrag = False
            colSelector.EditType = Janus.Windows.GridEX.EditType.CheckBox
            colSelector.ColumnType = Janus.Windows.GridEX.ColumnType.CheckBox

            Gridex1.RootTable.Columns.Add(colSelector)

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
        Me.lblFecha.Text = oMensaje.RecuperarDescripcion("TRPFechaEntrega")
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
                If vlColumna.Key = "Seleccion" Then
                    vlColumna.Position = 0
                    vlColumna.Caption = ""
                    vlColumna.Width = 50
                Else
                    vlColumna.EditType = Janus.Windows.GridEX.EditType.NoEdit
                    vlColumna.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                    vlColumna.FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox

                    Select Case vlColumna.Key.ToLower
                        Case "razonsocial"
                            vlColumna.Caption = oMensaje.RecuperarDescripcion("XCliente")
                            vlColumna.HeaderToolTip = oMensaje.RecuperarDescripcion("CLI" & vlColumna.Key & "T")
                        Case "nombrecorto"
                            'If bEsquema Then
                            vlColumna.Caption = oMensaje.RecuperarDescripcion("XNombre")
                            vlColumna.HeaderToolTip = oMensaje.RecuperarDescripcion("CLI" & vlColumna.Key & "T")
                            '    vlColumna.Visible = True
                            'Else
                            '    vlColumna.Visible = False
                            'End If
                        Case "folio"
                            vlColumna.Caption = oMensaje.RecuperarDescripcion("XPedido")
                            vlColumna.HeaderToolTip = oMensaje.RecuperarDescripcion("TRP" & vlColumna.Key & "T")
                        Case "fecha"
                            vlColumna.Caption = oMensaje.RecuperarDescripcion("TRP" & vlColumna.Key)
                            vlColumna.HeaderToolTip = oMensaje.RecuperarDescripcion("TRPFECHAHORAALTAT")
                        Case "total", "tipofase"
                            vlColumna.Caption = oMensaje.RecuperarDescripcion("TRP" & vlColumna.Key)
                            vlColumna.HeaderToolTip = oMensaje.RecuperarDescripcion("TRP" & vlColumna.Key & "T")
                    End Select

                End If
            Next

            .Columns("TipoFase").HasValueList = True
            lbGeneral.LlenarColumna(.Columns("TipoFase"), "TRPFASE")

            .Columns("TransProdID").Visible = False

        End With

    End Sub

    Private Sub SeleccionarRegs()
        vcSeleccion = New ArrayList
        Dim checkedRows() As Janus.Windows.GridEX.GridEXRow

        checkedRows = Me.Gridex1.GetCheckedRows()

        If checkedRows.Length > 0 Then

            Dim row As Janus.Windows.GridEX.GridEXRow
            For Each row In checkedRows
                vcSeleccion.Add(CType(row.DataRow, DataRowView).Row)
            Next

        End If

    End Sub

    Public Function Seleccionar(Optional ByVal pvFiltro As String = "", Optional ByVal pvMultiseleccion As Boolean = True) As ArrayList
        vcConexion = LbConexion.cConexion.Instancia
        vcFiltro &= " WHERE " & pvFiltro
        vcMultiseleccion = pvMultiseleccion

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

    Private Sub IPedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
