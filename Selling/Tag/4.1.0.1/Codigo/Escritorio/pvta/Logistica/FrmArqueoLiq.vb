Public Class FrmArqueoLiq
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnOk As Janus.Windows.EditControls.UIButton
    Friend WithEvents LBTitulo As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LbFecha As System.Windows.Forms.Label
    Friend WithEvents lblTotalLiquidar As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtDenominacion As System.Windows.Forms.TextBox
    Friend WithEvents CmbTipo As Selling.StoreCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnTC As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LblDenominacion As System.Windows.Forms.Label
    Friend WithEvents CtxDocumentos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TxtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cmbFormaPago As Selling.StoreCombo
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents CmbBanco As Selling.StoreCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtImporte As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents LblFaltante As System.Windows.Forms.Label
    Friend WithEvents GridEfectivo As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmArqueoLiq))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnOk = New Janus.Windows.EditControls.UIButton
        Me.LBTitulo = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GridEfectivo = New Janus.Windows.GridEX.GridEX
        Me.LbFecha = New System.Windows.Forms.Label
        Me.lblTotalLiquidar = New System.Windows.Forms.Label
        Me.lblTotal = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtDenominacion = New System.Windows.Forms.TextBox
        Me.CmbTipo = New Selling.StoreCombo
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnTC = New Janus.Windows.EditControls.UIButton
        Me.CtxDocumentos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.LblDenominacion = New System.Windows.Forms.Label
        Me.TxtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.cmbFormaPago = New Selling.StoreCombo
        Me.TxtReferencia = New System.Windows.Forms.TextBox
        Me.CmbBanco = New Selling.StoreCombo
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtImporte = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.LblFaltante = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridEfectivo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Name = "Label2"
        '
        'BtnOk
        '
        Me.BtnOk.BackColor = System.Drawing.SystemColors.Control
        Me.BtnOk.Image = CType(resources.GetObject("BtnOk.Image"), System.Drawing.Image)
        resources.ApplyResources(Me.BtnOk, "BtnOk")
        Me.BtnOk.Name = "BtnOk"
        '
        'LBTitulo
        '
        Me.LBTitulo.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.LBTitulo, "LBTitulo")
        Me.LBTitulo.ForeColor = System.Drawing.Color.White
        Me.LBTitulo.Name = "LBTitulo"
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.GridEfectivo)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'GridEfectivo
        '
        resources.ApplyResources(Me.GridEfectivo, "GridEfectivo")
        Me.GridEfectivo.ColumnAutoResize = True
        Me.GridEfectivo.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridEfectivo.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridEfectivo.Name = "GridEfectivo"
        Me.GridEfectivo.RecordNavigator = True
        Me.GridEfectivo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LbFecha
        '
        Me.LbFecha.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.LbFecha, "LbFecha")
        Me.LbFecha.ForeColor = System.Drawing.Color.White
        Me.LbFecha.Name = "LbFecha"
        '
        'lblTotalLiquidar
        '
        resources.ApplyResources(Me.lblTotalLiquidar, "lblTotalLiquidar")
        Me.lblTotalLiquidar.Name = "lblTotalLiquidar"
        '
        'lblTotal
        '
        resources.ApplyResources(Me.lblTotal, "lblTotal")
        Me.lblTotal.Name = "lblTotal"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'TxtDenominacion
        '
        resources.ApplyResources(Me.TxtDenominacion, "TxtDenominacion")
        Me.TxtDenominacion.Name = "TxtDenominacion"
        '
        'CmbTipo
        '
        resources.ApplyResources(Me.CmbTipo, "CmbTipo")
        Me.CmbTipo.Name = "CmbTipo"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        resources.ApplyResources(Me.BtnCancelar, "BtnCancelar")
        Me.BtnCancelar.Name = "BtnCancelar"
        '
        'BtnTC
        '
        resources.ApplyResources(Me.BtnTC, "BtnTC")
        Me.BtnTC.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDownButton
        Me.BtnTC.ContextMenuStrip = Me.CtxDocumentos
        Me.BtnTC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnTC.Name = "BtnTC"
        Me.BtnTC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'CtxDocumentos
        '
        Me.CtxDocumentos.Name = "CtxDocumentos"
        Me.CtxDocumentos.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        resources.ApplyResources(Me.CtxDocumentos, "CtxDocumentos")
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'LblDenominacion
        '
        resources.ApplyResources(Me.LblDenominacion, "LblDenominacion")
        Me.LblDenominacion.Name = "LblDenominacion"
        '
        'TxtCantidad
        '
        resources.ApplyResources(Me.TxtCantidad, "TxtCantidad")
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtCantidad.Value = 0
        Me.TxtCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'cmbFormaPago
        '
        resources.ApplyResources(Me.cmbFormaPago, "cmbFormaPago")
        Me.cmbFormaPago.Name = "cmbFormaPago"
        '
        'TxtReferencia
        '
        resources.ApplyResources(Me.TxtReferencia, "TxtReferencia")
        Me.TxtReferencia.Name = "TxtReferencia"
        '
        'CmbBanco
        '
        resources.ApplyResources(Me.CmbBanco, "CmbBanco")
        Me.CmbBanco.BackColor = System.Drawing.SystemColors.Window
        Me.CmbBanco.Name = "CmbBanco"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'TxtImporte
        '
        resources.ApplyResources(Me.TxtImporte, "TxtImporte")
        Me.TxtImporte.Name = "TxtImporte"
        Me.TxtImporte.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtImporte.Value = 0
        Me.TxtImporte.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'LblFaltante
        '
        resources.ApplyResources(Me.LblFaltante, "LblFaltante")
        Me.LblFaltante.ForeColor = System.Drawing.Color.Red
        Me.LblFaltante.Name = "LblFaltante"
        '
        'FrmArqueoLiq
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.TxtDenominacion)
        Me.Controls.Add(Me.LblFaltante)
        Me.Controls.Add(Me.TxtImporte)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtReferencia)
        Me.Controls.Add(Me.CmbBanco)
        Me.Controls.Add(Me.cmbFormaPago)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BtnTC)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.TxtCantidad)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblDenominacion)
        Me.Controls.Add(Me.CmbTipo)
        Me.Controls.Add(Me.lblTotalLiquidar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LbFecha)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LBTitulo)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmArqueoLiq"
        Me.ShowInTaskbar = False
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridEfectivo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public TotalLiquidar As Double
    Public LIQClave As String
    Public Fase As Integer
    Public Faltante, Registrado As Double

    Private dtMonto As DataTable
    Private bError As Boolean = False
    Private bload As Boolean = False

    Private TipoCambio As Double
    Private MONClave As String
    Private Importe As Double

    Private Sub FrmArqueoLiq_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmArqueoLiq_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LbFecha.Text = DateTime.Today.ToLongDateString

        Dim dt As DataTable
        Dim i As Integer

        dt = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                    Case "Moneda"
                        MONClave = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                        Exit For
                End Select
            Next
        End With
        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MONClave)
        BtnTC.Text = dt.Rows(0)("Referencia")
        TipoCambio = dt.Rows(0)("TipoCambio")
        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_muestra_monedas", Nothing)
        For i = 0 To dt.Rows.Count - 1
            Me.CtxDocumentos.Items.Add(dt.Rows(i)("Referencia"))
        Next
        dt.Dispose()

        With cmbFormaPago
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Pago"
            .NombreParametro2 = "campo"
            .Parametro2 = "Forma"
            .llenar()
        End With

        With CmbBanco
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_bancos"
            .llenar()
        End With

        With Me.CmbTipo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "Tabla"
            .Parametro1 = "Liquidacion"
            .NombreParametro2 = "Campo"
            .Parametro2 = "TipoDenominacion"
            .llenar()
        End With


        dtMonto = ModPOS.CrearTabla("MonedaDetalle", _
                  "MONClave", "System.String", _
                  "FormaPago", "System.Int32", _
                  "MND", "System.String", _
                  "TipoDenominacion", "System.Int32", _
                  "Tipo", "System.String", _
                  "TipoBanco", "System.String", _
                  "Banco", "System.String", _
                  "Denominacion", "System.Double", _
                  "Referencia", "System.String", _
                  "Cantidad", "System.Int32", _
                  "T.Cambio", "System.Double", _
                  "Importe", "System.Double")


        GridEfectivo.DataSource = dtMonto
        GridEfectivo.RetrieveStructure(True)
        GridEfectivo.GroupByBoxVisible = False
        GridEfectivo.RootTable.Columns("MONClave").Visible = False
        GridEfectivo.RootTable.Columns("TipoDenominacion").Visible = False
        GridEfectivo.RootTable.Columns("TipoBanco").Visible = False
        GridEfectivo.RootTable.Columns("FormaPago").Visible = False

        GridEfectivo.CurrentTable.Columns("MND").Selectable = False
        GridEfectivo.CurrentTable.Columns("Tipo").Selectable = False
        GridEfectivo.CurrentTable.Columns("Banco").Selectable = False
        GridEfectivo.CurrentTable.Columns("Denominacion").Selectable = False
        GridEfectivo.CurrentTable.Columns("Referencia").Selectable = False
        GridEfectivo.CurrentTable.Columns("Cantidad").Selectable = False
        GridEfectivo.CurrentTable.Columns("T.Cambio").Selectable = False
        GridEfectivo.CurrentTable.Columns("Importe").Selectable = False


        If cmbFormaPago.SelectedValue = 1 Then

            CmbTipo.Enabled = True
            TxtDenominacion.Enabled = True
            TxtCantidad.Enabled = True

            CmbBanco.Enabled = False
            TxtReferencia.Enabled = False
            TxtImporte.Enabled = False

        Else

            CmbTipo.Enabled = False
            TxtDenominacion.Enabled = False
            TxtCantidad.Enabled = False

            CmbBanco.Enabled = True
            TxtReferencia.Enabled = True
            TxtImporte.Enabled = True
        End If

        lblTotalLiquidar.Text = "Total a Liquidar " & Format(CStr(ModPOS.Redondear(TotalLiquidar, 2)), "Currency")

        lblTotal.Text = "Total Registrado " & Format(CStr(0.0), "Currency")

        LblFaltante.Text = "Faltante " & Format(CStr(ModPOS.Redondear(TotalLiquidar, 2)), "Currency")

        bload = True


        If TotalLiquidar < 0 Then
            CmbTipo.Enabled = False
            TxtDenominacion.Enabled = False
            TxtCantidad.Enabled = False
            CmbBanco.Enabled = False
            TxtReferencia.Enabled = False
            TxtImporte.Enabled = False
            Registrado = 0
        End If

    End Sub

    Private Sub BtnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If TotalLiquidar > 0 Then
            If Registrado > TotalLiquidar Then
                Beep()
                MessageBox.Show("¡El importe registrado es mayor al total a liquidar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            If Registrado < TotalLiquidar Then
                If MessageBox.Show("El importe registrado es menor al total a liquidar. ¿Desea continuar y cerrar la liquidación con Faltante?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                    bError = True
                    Exit Sub
                End If

                'Inserta detalle de liquidacion

                Dim foundRows() As System.Data.DataRow
                foundRows = dtMonto.Select(" Importe > 0.0 ")

                If foundRows.Length <> 0 Then
                    'inserta denominaciones

                    Dim z As Integer
                    For z = 0 To foundRows.GetUpperBound(0)
                        ModPOS.Ejecuta("sp_inserta_liqDetalle", _
                        "@LIQClave", LIQClave, _
                        "@MONClave", foundRows(z)("MONClave"), _
                        "@TipoCambio", foundRows(z)("T.Cambio"), _
                        "@FormaPago", foundRows(z)("FormaPago"), _
                        "@TipoDenominacion", foundRows(z)("TipoDenominacion"), _
                        "@TipoBanco", foundRows(z)("TipoBanco"), _
                        "@Denominacion", foundRows(z)("Denominacion"), _
                        "@Referencia", foundRows(z)("Referencia"), _
                        "@Cantidad", foundRows(z)("Cantidad"), _
                        "@Importe", foundRows(z)("Importe"))
                    Next

                End If


            End If
        End If
        'Actualiza liquidacion
        ModPOS.Ejecuta("sp_actualiza_liquidacion", "@LIQClave", LIQClave, "@Liquidacion", TotalLiquidar, "@Saldo", TotalLiquidar - Registrado, "@Fase", 2, "@Usuario", ModPOS.UsuarioActual)
        Fase = 2
        bError = False
        Me.Close()
    End Sub


    Private Sub Ctrls_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnOk.KeyUp, GridEfectivo.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Escape
                bError = False
                Close()
        End Select
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        bError = False
        Close()
    End Sub

    Private Sub BtnTC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTC.Click
        BtnTC.ContextMenuStrip.Show(BtnTC, New Point(0, 0), ToolStripDropDownDirection.AboveRight)
    End Sub

    Private Sub CtxDocumentos_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles CtxDocumentos.ItemClicked
        BtnTC.Text = e.ClickedItem.Text
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_tipocambio", "@Moneda", e.ClickedItem.Text)
        MONClave = dt.Rows(0)("MONClave")
        TipoCambio = dt.Rows(0)("TipoCambio")
        dt.Dispose()
        SendKeys.Send("{TAB}")

    End Sub

    Private Sub recuperaDenominacion(ByVal sMoneda As String, ByVal iTipoDenominacion As Integer, ByVal sReferencia As String)
        If iTipoDenominacion > -1 Then
            Dim dtDenominacion As DataTable = ModPOS.SiExisteRecupera("sp_recupera_denominacion", _
            "@MONClave", sMoneda, _
            "@TipoDenominacion", iTipoDenominacion, _
            "@Referencia", sReferencia.Trim.ToUpper)

            If Not dtDenominacion Is Nothing Then

                Importe = dtDenominacion.Rows(0)("Importe")

                dtDenominacion.Dispose()
                Me.LblDenominacion.Text = CStr(Importe)
                CmbTipo.Enabled = False
            Else
                LblDenominacion.Text = ""
                TxtDenominacion.Text = ""
                Importe = 0
                TxtDenominacion.Focus()
                MessageBox.Show("No se encontro una denominación que corresponda a la moneda y tipo de denominación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            Beep()
            MessageBox.Show("¡El tipo de denominación es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub TxtDenominacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDenominacion.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.TxtCantidad.Focus()
        End If
    End Sub

    Private Sub TxtDenominacion_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDenominacion.Leave
        If Not TxtDenominacion.Text = vbNullString Then
            recuperaDenominacion(MONClave, IIf(CmbTipo.SelectedValue Is Nothing, -1, CmbTipo.SelectedValue), TxtDenominacion.Text.Trim.ToUpper)
        End If
    End Sub

    Private Sub reiniciaValores()
        Importe = 0
        TxtDenominacion.Text = ""
        LblDenominacion.Text = ""
        TxtCantidad.Text = ""
        TxtReferencia.Text = ""
        TxtImporte.Text = ""

        If cmbFormaPago.SelectedValue = 1 Then
            CmbTipo.Enabled = True
        End If

        Registrado = GridEfectivo.GetTotal(GridEfectivo.CurrentTable.Columns("Importe"), Janus.Windows.GridEX.AggregateFunction.Sum)
        Faltante = TotalLiquidar - Registrado

        lblTotal.Text = "Total Registrado " & Format(CStr(ModPOS.Redondear(Registrado, 2)), "Currency")
        LblFaltante.Text = "Faltante " & Format(CStr(ModPOS.Redondear(Faltante, 2)), "Currency")
       
    End Sub

    Public Sub AddDenominacion()

        If Not cmbFormaPago.SelectedValue Is Nothing Then

            Dim foundRows() As Data.DataRow

            If cmbFormaPago.SelectedValue = 1 Then ' Si es Efectivo

                If Not CmbTipo.SelectedValue Is Nothing Then

                    If Importe > 0 Then

                        foundRows = dtMonto.Select(" FormaPago = " & CStr(cmbFormaPago.SelectedValue) & " and MONClave Like '" & MONClave & "' and TipoDenominacion = " & CStr(CmbTipo.SelectedValue) & " and Denominacion = " & CStr(Importe))

                        If foundRows.Length = 0 Then ' Si es la primera vez que se agrega

                            If CInt(TxtCantidad.Text) > 0 Then
                                Dim row1 As DataRow
                                row1 = dtMonto.NewRow()
                                'declara el nombre de la fila

                                row1.Item("MONClave") = MONClave
                                row1.Item("FormaPago") = cmbFormaPago.SelectedValue 'Efectivo o Documentos
                                row1.Item("MND") = BtnTC.Text
                                row1.Item("TipoDenominacion") = CmbTipo.SelectedValue
                                row1.Item("Tipo") = CmbTipo.SelectedItem(1)
                                row1.Item("Denominacion") = Importe ' Denominacion de la moneda o importe del documento
                                row1.Item("Cantidad") = CInt(TxtCantidad.Text)
                                row1.Item("T.Cambio") = TipoCambio ' Guarda 1 cuanod es documento
                                row1.Item("Importe") = (Importe * TipoCambio) * CInt(TxtCantidad.Text) ' Importe de moneda o importe del documento

                                dtMonto.Rows.Add(row1)
                                'agrega la fila completo a la tabla
                            Else
                                Beep()
                                MessageBox.Show("¡No se ha especificado la cantidad a agregar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            End If
                        ElseIf CInt(TxtCantidad.Text) = 0 Then 'Elimina
                            dtMonto.Rows.Remove(foundRows(0))
                        Else
                            foundRows(0)("Cantidad") = CInt(TxtCantidad.Text)
                            foundRows(0)("Importe") = (Importe * TipoCambio) * CInt(TxtCantidad.Text)
                        End If

                        reiniciaValores()
                    Else
                        Beep()
                        MessageBox.Show("¡No se ha especificado la denominación que se desea agregar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                Else
                    Beep()
                    MessageBox.Show("¡No se ha especificado el tipo de la denominación que se desea agregar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Else ' Seccion para otros documentos
                If Not CmbBanco.SelectedValue Is Nothing Then
                    If TxtReferencia.TextLength >= 4 Then
                        foundRows = dtMonto.Select(" FormaPago = " & CStr(cmbFormaPago.SelectedValue) & " and MONClave Like '" & MONClave & "' and TipoBanco like '" & CStr(CmbBanco.SelectedValue) & "' and Referencia like '" & TxtReferencia.Text.Trim.ToUpper & "'")

                        If foundRows.Length = 0 Then ' Si es la primera vez que se agrega

                            If CDbl(TxtImporte.Text) > 0.0 Then
                                Dim row1 As DataRow
                                row1 = dtMonto.NewRow()
                                'declara el nombre de la fila

                                row1.Item("MONClave") = MONClave
                                row1.Item("FormaPago") = cmbFormaPago.SelectedValue 'Efectivo o Documentos
                                row1.Item("TipoBanco") = CmbBanco.SelectedValue
                                row1.Item("Tipo") = cmbFormaPago.SelectedItem(1)
                                row1.Item("MND") = BtnTC.Text
                                row1.Item("Referencia") = TxtReferencia.Text.ToUpper.Trim
                                'row1.Item("Tipo") = CmbTipo.SelectedItem(1)
                                row1.Item("Banco") = CmbBanco.SelectedItem(1)
                                row1.Item("Denominacion") = CDbl(TxtImporte.Text) ' Denominacion de la moneda o importe del documento
                                row1.Item("Cantidad") = 1
                                row1.Item("T.Cambio") = TipoCambio ' Guarda 1 cuanod es documento
                                row1.Item("Importe") = CDbl(TxtImporte.Text) * TipoCambio ' Importe de moneda o importe del documento

                                dtMonto.Rows.Add(row1)
                                'agrega la fila completo a la tabla
                            Else
                                Beep()
                                MessageBox.Show("¡No se ha especificado el Importe a agregar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            End If
                        ElseIf CDbl(TxtImporte.Text) = 0.0 Then 'Elimina
                            dtMonto.Rows.Remove(foundRows(0))
                        Else
                            foundRows(0)("Denominacion") = CDbl(TxtImporte.Text)
                            foundRows(0)("Importe") = CDbl(TxtImporte.Text) * TipoCambio
                        End If
                        reiniciaValores()
                    Else
                        Beep()
                        MessageBox.Show("La referencia debe contener al menos 4 digitos o caracteres. Ejemplo: Ultimos digitos de Tarjeta o Cuenta Bancaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                Else
                    Beep()
                    MessageBox.Show("¡No se ha especificado el Banco!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            End If
        Else
            Beep()
            MessageBox.Show("¡No se ha especificado la Forma de Pago que desea agregar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub


    Private Sub TxtCantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtDenominacion.Focus()
        End If
    End Sub

    Private Sub TxtCantidad_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCantidad.Leave
        If TxtCantidad.Text <> "" AndAlso IsNumeric(TxtCantidad.Text) Then
            If CInt(TxtCantidad.Text) >= 0 Then
                AddDenominacion()
            Else
                Beep()
                MessageBox.Show("¡La cantidad debe ser mayor o igual a cero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub

   
    Private Sub cmbFormaPago_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFormaPago.SelectedIndexChanged
        If bload = True Then
            If cmbFormaPago.SelectedValue = 1 Then

                CmbTipo.Enabled = True
                TxtDenominacion.Enabled = True
                TxtCantidad.Enabled = True

                CmbBanco.Enabled = False
                TxtReferencia.Enabled = False
                TxtImporte.Enabled = False

                
            Else

                CmbTipo.Enabled = False
                TxtDenominacion.Enabled = False
                TxtCantidad.Enabled = False

                CmbBanco.Enabled = True
                TxtReferencia.Enabled = True
                TxtImporte.Enabled = True
            End If

            Importe = 0
            TxtDenominacion.Text = ""
            LblDenominacion.Text = ""
            TxtCantidad.Text = ""

            TxtReferencia.Text = ""
            TxtImporte.Text = ""

        End If
    End Sub

    Private Sub TxtImporte_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtImporte.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtReferencia.Focus()
        End If
    End Sub

    Private Sub TxtImporte_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtImporte.Leave
        If TxtImporte.Text <> "" AndAlso IsNumeric(TxtImporte.Text) Then
            If CDbl(TxtImporte.Text) >= 0.0 Then
                AddDenominacion()
            Else
                Beep()
                MessageBox.Show("¡El importe debe ser mayor o igual a cero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub

    Private Sub TxtReferencia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtReferencia.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.TxtImporte.Focus()
        End If
    End Sub
End Class


