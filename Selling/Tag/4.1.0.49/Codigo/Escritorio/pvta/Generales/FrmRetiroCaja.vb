Public Class FrmRetiroCaja
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
    Friend WithEvents lblRetiro As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnOk As Janus.Windows.EditControls.UIButton
    Friend WithEvents LBTitulo As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LbFecha As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblEfectivo As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtMotivo As System.Windows.Forms.TextBox
    Friend WithEvents CmbTipo As Selling.StoreCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnTC As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GridRetiro As Janus.Windows.GridEX.GridEX
    Friend WithEvents lblTotalRetirar As System.Windows.Forms.Label
    Friend WithEvents lblRetirar As System.Windows.Forms.Label
    Friend WithEvents CtxDocumentos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents GridCaja As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRetiroCaja))
        Me.lblRetiro = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnOk = New Janus.Windows.EditControls.UIButton()
        Me.LBTitulo = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnTC = New Janus.Windows.EditControls.UIButton()
        Me.CtxDocumentos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.GridCaja = New Janus.Windows.GridEX.GridEX()
        Me.LbFecha = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblEfectivo = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtMotivo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GridRetiro = New Janus.Windows.GridEX.GridEX()
        Me.lblTotalRetirar = New System.Windows.Forms.Label()
        Me.lblRetirar = New System.Windows.Forms.Label()
        Me.CmbTipo = New Selling.StoreCombo()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GridRetiro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblRetiro
        '
        Me.lblRetiro.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.lblRetiro, "lblRetiro")
        Me.lblRetiro.ForeColor = System.Drawing.Color.White
        Me.lblRetiro.Name = "lblRetiro"
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
        resources.ApplyResources(Me.BtnOk, "BtnOk")
        Me.BtnOk.BackColor = System.Drawing.SystemColors.Control
        Me.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOk.Image = CType(resources.GetObject("BtnOk.Image"), System.Drawing.Image)
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
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.BtnTC)
        Me.GroupBox1.Controls.Add(Me.GridCaja)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
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
        'GridCaja
        '
        resources.ApplyResources(Me.GridCaja, "GridCaja")
        Me.GridCaja.ColumnAutoResize = True
        Me.GridCaja.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridCaja.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridCaja.Name = "GridCaja"
        Me.GridCaja.RecordNavigator = True
        Me.GridCaja.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LbFecha
        '
        Me.LbFecha.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.LbFecha, "LbFecha")
        Me.LbFecha.ForeColor = System.Drawing.Color.White
        Me.LbFecha.Name = "LbFecha"
        '
        'lblTotal
        '
        resources.ApplyResources(Me.lblTotal, "lblTotal")
        Me.lblTotal.Name = "lblTotal"
        '
        'lblEfectivo
        '
        resources.ApplyResources(Me.lblEfectivo, "lblEfectivo")
        Me.lblEfectivo.Name = "lblEfectivo"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'TxtMotivo
        '
        resources.ApplyResources(Me.TxtMotivo, "TxtMotivo")
        Me.TxtMotivo.Name = "TxtMotivo"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'btnAgregar
        '
        resources.ApplyResources(Me.btnAgregar, "btnAgregar")
        Me.btnAgregar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.Icon = CType(resources.GetObject("btnAgregar.Icon"), System.Drawing.Icon)
        Me.btnAgregar.Name = "btnAgregar"
        '
        'GroupBox2
        '
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.GridRetiro)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'GridRetiro
        '
        Me.GridRetiro.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        resources.ApplyResources(Me.GridRetiro, "GridRetiro")
        Me.GridRetiro.ColumnAutoResize = True
        Me.GridRetiro.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridRetiro.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridRetiro.Name = "GridRetiro"
        Me.GridRetiro.RecordNavigator = True
        Me.GridRetiro.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblTotalRetirar
        '
        resources.ApplyResources(Me.lblTotalRetirar, "lblTotalRetirar")
        Me.lblTotalRetirar.Name = "lblTotalRetirar"
        '
        'lblRetirar
        '
        resources.ApplyResources(Me.lblRetirar, "lblRetirar")
        Me.lblRetirar.Name = "lblRetirar"
        '
        'CmbTipo
        '
        resources.ApplyResources(Me.CmbTipo, "CmbTipo")
        Me.CmbTipo.Name = "CmbTipo"
        '
        'FrmRetiroCaja
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblTotalRetirar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.lblRetirar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblEfectivo)
        Me.Controls.Add(Me.CmbTipo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtMotivo)
        Me.Controls.Add(Me.LbFecha)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LBTitulo)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblRetiro)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmRetiroCaja"
        Me.ShowInTaskbar = False
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.GridRetiro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public bRetiroProgramado As Boolean = False

    Public FondoCaja As Decimal
    Public SUCClave As String
    Public ALMClave As String
    Public CAJClave As String
    Public Referencia As String
    'Public MontoEfectivo As Double = 0
    'Public MontoCheques As Double = 0
    'Public MontoVales As Double = 0
    'Public retiroEfectivo As Double = 0
    'Public retiroCheques As Double = 0
    'Public retiroVales As Double = 0
    Public Cajon As Boolean = False
    Public Impresora As String
    Public Generic As Boolean
    Public Ticket As String

    Private IDCorte As String
    Private Cajero As String
    Private Autorizo As String
    Private Motivo As String
    Private Total, Efectivo As Decimal
    Private dtMonto, dtRetiro, dtRetiroDetalle As DataTable
    Private bError As Boolean = False
    Private Tipo As Integer

    Private Moneda, MonedaBase As String
    Private MonedaRef, MonRefBase As String
    Private MonedaDesc, MonedaDescBase As String
    Private TipoCambio, TipoCambioBase As Decimal
    Private InterfazSalida As String


    Private Function imprimeTicketRetiro(ByVal IDRetiro As String, ByVal Folio As String, ByVal Efectivo As Double, ByVal Impresora As String, ByVal Generic As Boolean, ByVal Ticket As String, ByVal MON As String, ByVal iCopias As Integer) As Boolean
        Dim dTotal As Double

        Dim Tickets As Imprimir = New Imprimir 'PrintTicket.Ticket()
        Tickets.Generic = Generic
        Dim dtTicket, dtDetalle As DataTable
        dtTicket = ModPOS.SiExisteRecupera("sp_recupera_ticket", "@TIKClave", Ticket)

        If Not dtTicket Is Nothing Then
            Tickets.MaxCharLine = dtTicket.Rows(0)("MaxChar")
            Tickets.LetraSize = dtTicket.Rows(0)("FontSize")
            Tickets.LetraName = dtTicket.Rows(0)("FontName")
            dtTicket.Dispose()
        End If

        'Encabezado
        Tickets.AddHeaderLine("RETIRO DE CAJA", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)

        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
        'de que al final de cada linea agrega una linea punteada "==========" 
        Tickets.AddHeaderLine("Folio: " & Folio, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("CAJERO: " & Cajero, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("AUTORIZO: " & Autorizo, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("MOTIVO: " & Motivo, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("FECHA: " & DateTime.Now.ToShortDateString() & " " & DateTime.Now.ToShortTimeString(), 0, Imprimir.Alinear.Izquierda)


        Dim lineasImpresas As Integer = 10

        dtDetalle = ModPOS.SiExisteRecupera("st_recupera_retirodet", "@IDRetiro", IDRetiro)

        If Not dtDetalle Is Nothing Then
            If dtDetalle.Rows.Count > 0 Then
                Tickets.AddHeaderLine("*** DETALLE REGISTRADO ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
                Tickets.AddHeaderItem("CANT. ", "DENOMINACION", "IMPORTE", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Derecha)
                Dim i As Integer
                For i = 0 To dtDetalle.Rows.Count - 1
                    Tickets.AddHeaderItem(CStr(IIf(dtDetalle.Rows(i)("Cantidad").GetType.Name = "DBNull", 1, dtDetalle.Rows(i)("Cantidad"))), CStr(IIf(dtDetalle.Rows(i)("Denominacion").GetType.Name = "DBNull", "Efectivo", dtDetalle.Rows(i)("Denominacion"))), Strings.Format(Redondear(dtDetalle.Rows(i)("Importe"), 2).ToString, "Currency"), Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
                    lineasImpresas += 1
                Next
                Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
                lineasImpresas += 4
            End If
            dtDetalle.Dispose()
        End If


        'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion 
        'del producto y el tercero es el precio 

        If Efectivo > 0 Then
            Tickets.AddItemRecibo("Efectivo", "", Efectivo)
            dTotal += Efectivo
        End If

        Tickets.AddTotalTicket(dTotal, Imprimir.FontEstilo.Negrita, MON)

        Dim q As Integer
        For q = 1 To iCopias
            Tickets.PrintTicket(Impresora, lineasImpresas, 0)
        Next

    End Function

    Private Sub FrmRetiroCaja_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub CtxDocumentos_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles CtxDocumentos.ItemClicked
        BtnTC.Text = e.ClickedItem.Text

        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_tipocambio", "@Moneda", e.ClickedItem.Text)
        Moneda = dt.Rows(0)("MONClave")
        MonedaRef = dt.Rows(0)("Referencia")
        MonedaDesc = dt.Rows(0)("Descripcion")
        TipoCambio = dt.Rows(0)("TipoCambio")
        dt.Dispose()

        dtMonto = ModPOS.Recupera_Tabla("sp_recupera_monto", "@MONClave", Moneda)

        GridCaja.DataSource = dtMonto
        GridCaja.RetrieveStructure(True)
        GridCaja.GroupByBoxVisible = False
        GridCaja.RootTable.Columns("Valor").Visible = False
        GridCaja.CurrentTable.Columns("Tipo").Selectable = False
        GridCaja.CurrentTable.Columns("Importe").Selectable = False
        GridCaja.CurrentTable.Columns("Monto").Selectable = False

        lblEfectivo.Text = "Total Efectivo (" & MonedaRef & ")"
        Efectivo = 0
        lblTotal.Text = Format(CStr(ModPOS.Redondear(Efectivo, 2)), "Currency")
        SendKeys.Send("{TAB}")

    End Sub

    Private Sub FrmRetiroCaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LbFecha.Text = DateTime.Today.ToLongDateString
        Dim i As Integer
        Dim dt As DataTable

        dt = ModPOS.Recupera_Tabla("sp_busca_corteCaja", "@CAJClave", CAJClave)
        If dt.Rows.Count > 0 Then
            IDCorte = dt.Rows(0)("ID")
        End If
        dt.Dispose()

        dtRetiroDetalle = ModPOS.CrearTabla("RetiroCajaDetalle", _
                                                 "TipoImporte", "System.Int32", _
                                                 "Cantidad", "System.Int32", _
                                                 "Denominacion", "System.Decimal", _
                                                 "Importe", "System.Decimal", _
                                                 "MONClave", "System.String", _
                                                 "TipoCambio", "System.Decimal")


        dtRetiro = ModPOS.CrearTabla("RetiroCaja", _
                                         "MONClave", "System.String", _
                                         "MON", "System.String", _
                                         "TipoCambio", "System.Decimal", _
                                         "Importe", "System.Decimal", _
                                         "SaldoBase", "System.Decimal")

        GridRetiro.DataSource = dtRetiro
        GridRetiro.RetrieveStructure(True)
        GridRetiro.GroupByBoxVisible = False
        GridRetiro.RootTable.Columns("MONClave").Visible = False
        GridRetiro.RootTable.Columns("SaldoBase").Visible = False

        dt = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                    Case "Moneda"
                        Moneda = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                    Case "InterfazSalida"
                        InterfazSalida = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                End Select
            Next
        End With
        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_muestra_monedas", Nothing)
        For i = 0 To dt.Rows.Count - 1
            Me.CtxDocumentos.Items.Add(dt.Rows(i)("Referencia"))
        Next
        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
        MonedaBase = Moneda
        TipoCambioBase = dt.Rows(0)("TipoCambio")
        MonRefBase = dt.Rows(0)("Referencia")
        MonedaDescBase = dt.Rows(0)("Descripcion")
        dt.Dispose()

        MonedaRef = MonRefBase
        TipoCambio = TipoCambioBase
        MonedaDesc = MonedaDescBase

        lblEfectivo.Text = "Total Efectivo (" & MonedaRef & ")"
        lblTotalRetirar.Text = "Total a Retirar (" & MonRefBase & ")"

        BtnTC.Text = MonRefBase



        With Me.CmbTipo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "Tabla"
            .Parametro1 = "RetiroCaja"
            .NombreParametro2 = "Campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        If bRetiroProgramado = True Then
            CmbTipo.SelectedValue = 3
            TxtMotivo.Text = "Retiro Programado"
            CmbTipo.Enabled = False
            TxtMotivo.Enabled = False
            lblRetiro.Text = ""
        End If

        Dim dtUsuario As DataTable = ModPOS.SiExisteRecupera("sp_recupera_UsuarioActual", "@Usuario", ModPOS.UsuarioActual)

        If Not dtUsuario Is Nothing Then
            Cajero = dtUsuario.Rows(0)("Nombre")
        End If

        dtMonto = ModPOS.Recupera_Tabla("sp_recupera_monto", "@MONClave", Moneda)

        GridCaja.DataSource = dtMonto
        GridCaja.RetrieveStructure(True)
        GridCaja.GroupByBoxVisible = False
        GridCaja.RootTable.Columns("Valor").Visible = False
        GridCaja.CurrentTable.Columns("Tipo").Selectable = False
        GridCaja.CurrentTable.Columns("Importe").Selectable = False
        GridCaja.CurrentTable.Columns("Monto").Selectable = False






    End Sub


    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        bError = False
        If TxtMotivo.Text = "" Then
            MessageBox.Show("Debe especificar un motivo para el retiro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bError = True
            Exit Sub
        Else
            Motivo = TxtMotivo.Text.ToUpper.Trim
        End If

        If CmbTipo.SelectedValue Is Nothing Then
            Tipo = 1
        Else
            Tipo = CmbTipo.SelectedValue
        End If


        If dtRetiro.Rows.Count = 0 Then
            MessageBox.Show("Debe agregar el importe a Retirar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bError = True
            Exit Sub
        End If


        Dim UsuarioAutoriza As String = ""

        If bError = False And Total > 0 Then
            Dim a As New MeAutorizacion
            a.Sucursal = SUCClave
            a.MontodeAutorizacion = Total
            a.StartPosition = FormStartPosition.CenterScreen
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                If a.Autorizado Then
                    UsuarioAutoriza = a.Autoriza
                Else
                    bError = True
                    MessageBox.Show("El retiro no ha sido autorizado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                bError = True
                MessageBox.Show("El retiro no ha sido autorizado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            bError = True
            MessageBox.Show("El retiro no ha sido autorizado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        'Guarda Registro de Retiro
        If bError = False And Total > 0 Then

            Dim dtUsuario As DataTable = ModPOS.SiExisteRecupera("sp_recupera_UsuarioActual", "@Usuario", UsuarioAutoriza)
            If Not dtUsuario Is Nothing Then
                Autorizo = dtUsuario.Rows(0)("Nombre")
            End If

            If Cajon = True Then
                AbrirCajon(Impresora)
            End If

            Dim i As Integer
            Dim bimprimir As Boolean = False
            Select Case MessageBox.Show("¿Desea Imprimir Recibo de Retiro de Caja", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    bimprimir = True
            End Select

            Dim Folio As String
            Dim IDRetiro As String
            Dim j As Integer

            Dim foundRows() As System.Data.DataRow


            For i = 0 To dtRetiro.Rows.Count - 1

                Folio = ObtenerFolioRetiro(CAJClave, Referencia)



                If Efectivo > 0 Then

                    IDRetiro = ModPOS.obtenerLlave

                    ModPOS.Ejecuta("sp_inserta_retiro", _
                                   "@IDRetiro", IDRetiro, _
                                  "@CAJClave", CAJClave, _
                                  "@Folio", Folio, _
                                  "@Usuario", UsuarioAutoriza, _
                                  "@Importe", dtRetiro.Rows(i)("Importe"), _
                                  "@MONClave", dtRetiro.Rows(i)("MONClave"), _
                                  "@TipoCambio", dtRetiro.Rows(i)("TipoCambio"), _
                                  "@Motivo", Motivo, _
                                  "@Tipo", 1, _
                                  "@TipoMotivo", Tipo)


                    foundRows = dtRetiroDetalle.Select("MONClave = '" & dtRetiro.Rows(i)("MONClave") & "'")

                    If foundRows.GetLength(0) > 0 Then
                        For j = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("st_inserta_retiroDetalle", _
                                            "@IDRetiro", IDRetiro, _
                                            "@TipoImporte", foundRows(j)("TipoImporte"), _
                                            "@Cantidad", foundRows(j)("Cantidad"), _
                                            "@Denominacion", foundRows(j)("Denominacion"), _
                                            "@Importe", foundRows(j)("Importe"), _
                                            "@MONClave", foundRows(j)("MONClave"), _
                                            "@TipoCambio", foundRows(j)("TipoCambio"))

                        Next

                    End If

                End If

                If InterfazSalida <> "" AndAlso (Tipo = 1 OrElse Tipo = 5) Then
                    Dim dtInterfaz As DataTable = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "Gastos", "@COMClave", ModPOS.CompanyActual)
                    If dtInterfaz.Rows.Count > 0 Then
                        Dim sFecha As String = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")
                        ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", Folio, "@TipoDocumento", 1, "@Path", InterfazSalida, "@Fecha", sFecha, "@Tipo", 1)
                    End If
                End If

                If bimprimir = True Then
                    imprimeTicketRetiro(IDRetiro, Folio, dtRetiro.Rows(i)("Importe"), Impresora, Generic, Ticket, dtRetiro.Rows(i)("MON"), 2)

                End If
            Next

            'Inserta Retiro Detalle




        End If
        Me.Close()
    End Sub


    Private Sub GridCaja_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridCaja.CellEdited
        If GridCaja.CurrentColumn.Caption = "Cantidad" Then
            If IsNumeric(GridCaja.GetValue("Cantidad")) Then
                Dim Actual As Decimal
                Actual = GridCaja.GetValue("Valor") * Math.Abs(CDbl(GridCaja.GetValue("Cantidad")))
                GridCaja.SetValue("Monto", Actual)
            Else
                GridCaja.SetValue("Cantidad", 0)
            End If
        End If
    End Sub


    Private Sub GridCaja_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridCaja.RecordUpdated
        Efectivo = GridCaja.GetTotal(GridCaja.CurrentTable.Columns("Monto"), Janus.Windows.GridEX.AggregateFunction.Sum)
        lblTotal.Text = Format(CStr(ModPOS.Redondear(Efectivo, 2)), "Currency")
    End Sub

    Private Sub Ctrls_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnOk.KeyUp, GridCaja.KeyUp, BtnTC.KeyUp, btnAgregar.KeyUp, GridRetiro.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Escape
                If bRetiroProgramado = False Then
                    bError = False
                    Close()
                End If
        End Select
    End Sub

  
    Private Sub BtnTC_Click(sender As Object, e As EventArgs) Handles BtnTC.Click
        BtnTC.ContextMenuStrip.Show(BtnTC, New Point(0, 0), ToolStripDropDownDirection.AboveRight)
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If Efectivo = 0 Then
            MessageBox.Show("El importe a retirar debe ser mayor a cero", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else

            Dim dEfectivo, dSaldoBase As Decimal
            Dim dt As DataTable = Recupera_Tabla("st_recupera_efectivo_mon", "@IDCorte", IDCorte, "@COMClave", ModPOS.CompanyActual, "@MONClave", Moneda)

            If dt.Rows.Count > 0 Then
                dEfectivo = dt.Rows(0)("Efectivo")
                dSaldoBase = dt.Rows(0)("SaldoBase")

                If bRetiroProgramado = True Then
                    dEfectivo -= dt.Rows(0)("Fondo")
                    dSaldoBase -= dt.Rows(0)("FondoBase")
                End If


            End If
            dt.Dispose()

            If dEfectivo >= Efectivo Then


                Dim foundRows() As System.Data.DataRow
                foundRows = dtRetiro.Select("MONClave = '" & Moneda & "'")
                If foundRows.Length = 0 Then
                    Dim row1 As DataRow
                    row1 = dtRetiro.NewRow()
                    'declara el nombre de la fila
                    row1.Item("MONClave") = Moneda
                    row1.Item("MON") = MonedaRef
                    row1.Item("TipoCambio") = TipoCambio
                    row1.Item("Importe") = Efectivo
                    row1.Item("SaldoBase") = Efectivo * TipoCambio
                    dtRetiro.Rows.Add(row1)
                Else
                    foundRows(0)("Importe") = Efectivo
                    foundRows(0)("SaldoBase") = Efectivo * TipoCambio
                End If

                'Agregar detalle


                Dim i As Integer
                Dim foundRows2() As DataRow

               
                foundRows2 = dtMonto.Select("Monto > 0")
                If foundRows2.GetLength(0) > 0 Then


                    foundRows = dtRetiroDetalle.Select("MONClave = '" & Moneda & "'")
                    If foundRows.GetLength(0) > 0 Then
                        Dim j As Integer
                        For j = 0 To foundRows.GetUpperBound(0)
                            dtRetiroDetalle.Rows.Remove(foundRows(j))
                        Next

                    End If
                   
                    For i = 0 To foundRows2.GetUpperBound(0)

                        Dim row1 As DataRow
                        row1 = dtRetiroDetalle.NewRow()
                        'declara el nombre de la fila
                        row1.Item("TipoImporte") = 1
                        row1.Item("Cantidad") = CInt(foundRows2(i)("Cantidad"))
                        row1.Item("Denominacion") = CDbl(foundRows2(i)("Valor"))
                        row1.Item("Importe") = CDbl(foundRows2(i)("Monto"))
                        row1.Item("MONClave") = Moneda
                        row1.Item("TipoCambio") = TipoCambio
                        dtRetiroDetalle.Rows.Add(row1)

                    Next
                End If


                    dtRetiro.AcceptChanges()
                    Total = GridRetiro.GetTotal(GridRetiro.CurrentTable.Columns("SaldoBase"), Janus.Windows.GridEX.AggregateFunction.Sum)
                    lblRetirar.Text = Format(CStr(ModPOS.Redondear(Total, 2)), "Currency")
                Else
                    MessageBox.Show("El importe en " & MonedaDesc & " a retirar excede el efectivo en caja", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

            End If
    End Sub
End Class


