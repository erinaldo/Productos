Imports System.Data.SqlServerCe

Public Class FormDepositos
    Inherits System.Windows.Forms.Form
    Private Const ConstMenuRegresar = 0
    Private ValoresTipoPago As New Hashtable
    Private strEstatusModificado As String = "," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "' "
    Private bHuboCambios As Boolean
    Private eModo As Modo
    Private blnSeleccionManual As Boolean = False
    Private bValidarCambios As Boolean = True
    Private strDepKeyActual As String
    Public ImporteAnt As Decimal

    Public Enum Modo
        Crear = 1
        Modificar = 2
        Cancelar = 3
        Vacio = 4
    End Enum


    Protected tTipoOpcion As ServicesCentral.TiposOpcionesMenuDia
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabControlAplicacion As System.Windows.Forms.TabControl
    Friend WithEvents TabPageDepositos As System.Windows.Forms.TabPage
    Friend WithEvents ListViewMenu As System.Windows.Forms.ListView
    Friend WithEvents LabelMenu As System.Windows.Forms.Label
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents TabPageDetalle As System.Windows.Forms.TabPage
    Friend WithEvents TextBoxTotal As System.Windows.Forms.TextBox
    Friend WithEvents LabelTotal As System.Windows.Forms.Label
    Friend WithEvents ButtonContinuar1 As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar1 As System.Windows.Forms.Button
    Friend WithEvents TextBoxFicha As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxBanco As System.Windows.Forms.ComboBox
    Friend WithEvents LabelFicha As System.Windows.Forms.Label
    Friend WithEvents LabelBanco As System.Windows.Forms.Label
    Friend WithEvents LabelFechaDeposito As System.Windows.Forms.Label
    Friend WithEvents C1FlexGridAbonos As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
#Region "Propiedades"
    Public Property OpcionSeleccionada() As ServicesCentral.TiposOpcionesMenuDia
        Get
            Return tTipoOpcion
        End Get
        Set(ByVal Value As ServicesCentral.TiposOpcionesMenuDia)
            tTipoOpcion = Value
        End Set
    End Property

    Public Property Transaccion() As SqlCeTransaction
        Get
            Return oDBVen.Transaccion
        End Get
        Set(ByVal Value As SqlCeTransaction)
            oDBVen.Transaccion = Value
        End Set
    End Property
#End Region

    Private refaVista As Vista

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        ListViewMenu.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        ListViewMenu.Activation = oApp.TipoSeleccion

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MainMenuDia Is Nothing Then Me.MainMenuDia.Dispose()
        If Not Me.C1FlexGridAbonos Is Nothing Then Me.C1FlexGridAbonos.Dispose()
        Me.C1FlexGridAbonos = Nothing
        If Not Me.ComboBoxBanco Is Nothing Then
            Me.ComboBoxBanco.DataSource = Nothing
            Me.ComboBoxBanco.Dispose()
        End If
        If Me.ListViewMenu.Columns.Count > 0 Then
            Me.ListViewMenu.Columns.Clear()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents MainMenuDia As System.Windows.Forms.MainMenu
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDepositos))
        Me.MainMenuDia = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TabControlAplicacion = New System.Windows.Forms.TabControl
        Me.TabPageDepositos = New System.Windows.Forms.TabPage
        Me.ListViewMenu = New System.Windows.Forms.ListView
        Me.LabelMenu = New System.Windows.Forms.Label
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.TabPageDetalle = New System.Windows.Forms.TabPage
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker
        Me.TextBoxTotal = New System.Windows.Forms.TextBox
        Me.LabelTotal = New System.Windows.Forms.Label
        Me.ButtonContinuar1 = New System.Windows.Forms.Button
        Me.ButtonRegresar1 = New System.Windows.Forms.Button
        Me.TextBoxFicha = New System.Windows.Forms.TextBox
        Me.ComboBoxBanco = New System.Windows.Forms.ComboBox
        Me.LabelFicha = New System.Windows.Forms.Label
        Me.LabelBanco = New System.Windows.Forms.Label
        Me.LabelFechaDeposito = New System.Windows.Forms.Label
        Me.C1FlexGridAbonos = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.Panel1.SuspendLayout()
        Me.TabControlAplicacion.SuspendLayout()
        Me.TabPageDepositos.SuspendLayout()
        Me.TabPageDetalle.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenuDia
        '
        Me.MainMenuDia.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TabControlAplicacion)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'TabControlAplicacion
        '
        Me.TabControlAplicacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlAplicacion.Controls.Add(Me.TabPageDepositos)
        Me.TabControlAplicacion.Controls.Add(Me.TabPageDetalle)
        Me.TabControlAplicacion.Dock = System.Windows.Forms.DockStyle.None
        Me.TabControlAplicacion.Location = New System.Drawing.Point(0, 0)
        Me.TabControlAplicacion.Name = "TabControlAplicacion"
        Me.TabControlAplicacion.SelectedIndex = 0
        Me.TabControlAplicacion.Size = New System.Drawing.Size(242, 295)
        Me.TabControlAplicacion.TabIndex = 1
        '
        'TabPageDepositos
        '
        Me.TabPageDepositos.Controls.Add(Me.ListViewMenu)
        Me.TabPageDepositos.Controls.Add(Me.LabelMenu)
        Me.TabPageDepositos.Controls.Add(Me.ButtonContinuar)
        Me.TabPageDepositos.Controls.Add(Me.ButtonRegresar)
        Me.TabPageDepositos.Controls.Add(Me.ButtonEliminar)
        Me.TabPageDepositos.Location = New System.Drawing.Point(0, 0)
        Me.TabPageDepositos.Name = "TabPageDepositos"
        Me.TabPageDepositos.Size = New System.Drawing.Size(242, 272)
        Me.TabPageDepositos.Text = "TabPageDepositos"
        '
        'ListViewMenu
        '
        Me.ListViewMenu.CheckBoxes = True
        Me.ListViewMenu.FullRowSelect = True
        Me.ListViewMenu.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewMenu.Location = New System.Drawing.Point(4, 20)
        Me.ListViewMenu.Name = "ListViewMenu"
        Me.ListViewMenu.Size = New System.Drawing.Size(225, 210)
        Me.ListViewMenu.TabIndex = 0
        Me.ListViewMenu.View = System.Windows.Forms.View.Details
        '
        'LabelMenu
        '
        Me.LabelMenu.Location = New System.Drawing.Point(4, 2)
        Me.LabelMenu.Name = "LabelMenu"
        Me.LabelMenu.Size = New System.Drawing.Size(230, 20)
        Me.LabelMenu.Text = "LabelMenu"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(4, 236)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuar.TabIndex = 2
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(81, 236)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar.TabIndex = 3
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(157, 236)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonEliminar.TabIndex = 4
        Me.ButtonEliminar.Text = "ButtonEliminar"
        '
        'TabPageDetalle
        '
        Me.TabPageDetalle.Controls.Add(Me.dtpFecha)
        Me.TabPageDetalle.Controls.Add(Me.TextBoxTotal)
        Me.TabPageDetalle.Controls.Add(Me.LabelTotal)
        Me.TabPageDetalle.Controls.Add(Me.ButtonContinuar1)
        Me.TabPageDetalle.Controls.Add(Me.ButtonRegresar1)
        Me.TabPageDetalle.Controls.Add(Me.TextBoxFicha)
        Me.TabPageDetalle.Controls.Add(Me.ComboBoxBanco)
        Me.TabPageDetalle.Controls.Add(Me.LabelFicha)
        Me.TabPageDetalle.Controls.Add(Me.LabelBanco)
        Me.TabPageDetalle.Controls.Add(Me.LabelFechaDeposito)
        Me.TabPageDetalle.Controls.Add(Me.C1FlexGridAbonos)
        Me.TabPageDetalle.Location = New System.Drawing.Point(0, 0)
        Me.TabPageDetalle.Name = "TabPageDetalle"
        Me.TabPageDetalle.Size = New System.Drawing.Size(234, 269)
        Me.TabPageDetalle.Text = "TabPageDetalle"
        '
        'dtpFecha
        '
        Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.Location = New System.Drawing.Point(112, 4)
        Me.dtpFecha.MaxDate = New Date(2500, 12, 31, 0, 0, 0, 0)
        Me.dtpFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(117, 22)
        Me.dtpFecha.TabIndex = 0
        Me.dtpFecha.Value = New Date(2007, 1, 30, 0, 0, 0, 0)
        '
        'TextBoxTotal
        '
        Me.TextBoxTotal.Enabled = False
        Me.TextBoxTotal.Location = New System.Drawing.Point(140, 209)
        Me.TextBoxTotal.Name = "TextBoxTotal"
        Me.TextBoxTotal.Size = New System.Drawing.Size(90, 21)
        Me.TextBoxTotal.TabIndex = 1
        '
        'LabelTotal
        '
        Me.LabelTotal.Location = New System.Drawing.Point(64, 211)
        Me.LabelTotal.Name = "LabelTotal"
        Me.LabelTotal.Size = New System.Drawing.Size(72, 16)
        Me.LabelTotal.Text = "LabelTotal"
        '
        'ButtonContinuar1
        '
        Me.ButtonContinuar1.Location = New System.Drawing.Point(4, 236)
        Me.ButtonContinuar1.Name = "ButtonContinuar1"
        Me.ButtonContinuar1.Size = New System.Drawing.Size(75, 24)
        Me.ButtonContinuar1.TabIndex = 3
        Me.ButtonContinuar1.Text = "ButtonContinuar1"
        '
        'ButtonRegresar1
        '
        Me.ButtonRegresar1.Location = New System.Drawing.Point(83, 236)
        Me.ButtonRegresar1.Name = "ButtonRegresar1"
        Me.ButtonRegresar1.Size = New System.Drawing.Size(75, 24)
        Me.ButtonRegresar1.TabIndex = 4
        Me.ButtonRegresar1.Text = "ButtonRegresar1"
        '
        'TextBoxFicha
        '
        Me.TextBoxFicha.Location = New System.Drawing.Point(112, 56)
        Me.TextBoxFicha.Name = "TextBoxFicha"
        Me.TextBoxFicha.Size = New System.Drawing.Size(117, 21)
        Me.TextBoxFicha.TabIndex = 5
        '
        'ComboBoxBanco
        '
        Me.ComboBoxBanco.Location = New System.Drawing.Point(112, 30)
        Me.ComboBoxBanco.Name = "ComboBoxBanco"
        Me.ComboBoxBanco.Size = New System.Drawing.Size(117, 22)
        Me.ComboBoxBanco.TabIndex = 6
        '
        'LabelFicha
        '
        Me.LabelFicha.Location = New System.Drawing.Point(8, 56)
        Me.LabelFicha.Name = "LabelFicha"
        Me.LabelFicha.Size = New System.Drawing.Size(96, 24)
        Me.LabelFicha.Text = "LabelFicha"
        '
        'LabelBanco
        '
        Me.LabelBanco.Location = New System.Drawing.Point(8, 30)
        Me.LabelBanco.Name = "LabelBanco"
        Me.LabelBanco.Size = New System.Drawing.Size(96, 24)
        Me.LabelBanco.Text = "LabelBanco"
        '
        'LabelFechaDeposito
        '
        Me.LabelFechaDeposito.Location = New System.Drawing.Point(8, 8)
        Me.LabelFechaDeposito.Name = "LabelFechaDeposito"
        Me.LabelFechaDeposito.Size = New System.Drawing.Size(96, 24)
        Me.LabelFechaDeposito.Text = "LabelFechaDeposito"
        '
        'C1FlexGridAbonos
        '
        Me.C1FlexGridAbonos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.C1FlexGridAbonos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.C1FlexGridAbonos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.C1FlexGridAbonos.Location = New System.Drawing.Point(5, 80)
        Me.C1FlexGridAbonos.Name = "C1FlexGridAbonos"
        Me.C1FlexGridAbonos.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FlexGridAbonos.Size = New System.Drawing.Size(224, 123)
        Me.C1FlexGridAbonos.StyleInfo = resources.GetString("C1FlexGridAbonos.StyleInfo")
        Me.C1FlexGridAbonos.SupportInfo = "qQBTATUBpADkAIABoAAlAeIA1AB9AKcAuwCfAJsABgE5AfMAEgFlAREB5AAzAEAA/QB4AFoAEwEFASEBC" & _
            "AFEAOkAMQGwAA=="
        Me.C1FlexGridAbonos.TabIndex = 10
        '
        'FormDepositos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuDia
        Me.MinimizeBox = False
        Me.Name = "FormDepositos"
        Me.Panel1.ResumeLayout(False)
        Me.TabControlAplicacion.ResumeLayout(False)
        Me.TabPageDepositos.ResumeLayout(False)
        Me.TabPageDetalle.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FormDepositos_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        If Not Me.Transaccion Is Nothing Then Me.Transaccion.Dispose()
        Me.Transaccion = Nothing
    End Sub

    Private Sub FormMenuDia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        If Not Vista.Buscar("FormDepositos", refaVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If

        blnSeleccionManual = True

        refaVista.CrearListView(ListViewMenu, "ListViewDepositos")
        refaVista.PoblarListView(ListViewMenu, oDBVen, "ListViewDepositos", "")
        refaVista.ColocarEtiquetasForma(Me)
        Application.DoEvents()
        PreparaCampos()

        eModo = Modo.Vacio

        blnSeleccionManual = False

        LlenaComboBanco()

        If ListViewMenu.Items.Count > 0 Then
            ListViewMenu.Items(0).Selected = True
            ListViewMenu.Focus()
        Else
            eModo = Modo.Crear
            Me.TabControlAplicacion.SelectedIndex = 1
        End If

        Me.bHuboCambios = False
        bValidarCambios = True

        Cursor.Current = Cursors.Default
    End Sub


    Public Sub Configurar_Grid()

        With C1FlexGridAbonos
            .ClipSeparators = vbTab + vbLf
            .Cols.Count = 6
            .Cols.Fixed = 0
            .Cols(0).Name = ""
            .Cols(0).DataType = GetType(Boolean)
            .Cols(0).Width = 18

            .Cols(1).Name = "AbonoID"
            .Cols(1).Caption = "AbonoID"
            .Cols(1).Width = 18
            .Cols(1).Visible = False
            .Cols(1).AllowEditing = False

            .Cols(2).Name = "AbonoDetalleID"
            .Cols(2).Caption = "AbonoDetalleID"
            .Cols(2).Width = 18
            .Cols(2).Visible = False
            .Cols(2).AllowEditing = False

            .Cols(3).Name = "FormaPago"
            .Cols("FormaPago").Caption = refaVista.BuscarMensaje("GridDepositos", "GridFormaPago")
            .Cols(3).AllowEditing = False
            .Cols(3).DataMap = ValoresTipoPago
            .Cols(3).Width = 60

            .Cols(4).Width = 70
            .Cols(4).Name = "Importe"
            .Cols("Importe").Caption = refaVista.BuscarMensaje("GridDepositos", "GridImporte")
            .Cols(4).DataType = GetType(Double)
            .Cols(4).AllowEditing = True

            .Cols(5).Width = 70
            .Cols(5).AllowEditing = False
            .Cols(5).DataType = GetType(Double)
            .Cols(5).Name = "Saldo"
            .Cols("Saldo").Caption = refaVista.BuscarMensaje("GridDepositos", "GridSaldo")


        End With
    End Sub

    Private Sub LlenaComboBanco()
        Dim arrCon As New ArrayList
        Dim aValores As ArrayList = ValorReferencia.RecuperarLista("TBANCO")
        If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
            For Each refDesc As ValorReferencia.Descripcion In aValores
                arrCon.Add(New CConceptos(refDesc.Id, refDesc.Cadena))
            Next
            'For Each dr As DataRow In ValorReferencia.RecuperarLista("TBANCO").Rows
            '    arrCon.Add(New CConceptos(dr(0), dr(1)))
            'Next
            ComboBoxBanco.DataSource = arrCon
            ComboBoxBanco.DisplayMember = "Concepto"
            ComboBoxBanco.ValueMember = "Valor"
        End If
        aValores = Nothing
    End Sub


    Private Sub BuscaAbonos(Optional ByVal Filtro As String = "")
        Try
            Dim Query As String = ""

            Select Case eModo
                Case Modo.Crear
                    Query = "Select ABNId, ABDId,TipoPago,SaldoDeposito as Importe,SaldoDeposito  from ABNDetalle where SaldoDeposito>0 "

                Case Modo.Cancelar
                    Query = "Select A.ABNId, A.ABDId,TipoPago,D.Importe as Importe,A.SaldoDeposito  from ABNDetalle A inner join AbdDep D  on (A.ABNID=D.ABNID  and A.ABDID=D.ABDID) " & Filtro

                Case Modo.Modificar
                    Query = "Select A.ABNId, A.ABDId,TipoPago,D.Importe as Importe, A.SaldoDeposito+D.Importe as Saldo  from ABNDetalle A inner join AbdDep D  on (A.ABNID=D.ABNID  and A.ABDID=D.ABDID)" & Filtro

            End Select

            C1FlexGridAbonos.Rows.Count = 1

            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL(Query, "ABNDetalle")

            For Each dr As DataRow In Dt.Rows

                If eModo = Modo.Modificar Or eModo = Modo.Cancelar Then
                    C1FlexGridAbonos.AddItem("1" + vbTab + dr(0).ToString + vbTab + dr(1).ToString + vbTab + dr(2).ToString + vbTab + dr(3).ToString + vbTab + dr(4).ToString)
                Else
                    C1FlexGridAbonos.AddItem("0" + vbTab + dr(0).ToString + vbTab + dr(1).ToString + vbTab + dr(2).ToString + vbTab + dr(3).ToString + vbTab + dr(4).ToString)
                End If

            Next
            Dt.Dispose()

        Catch ex As SqlServerCe.SqlCeException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PreparaCampos()
        Dim Motivos As String = "" 'Motivos de la improductividad
        'El combobox de motivos
        Dim aValores As ArrayList = ValorReferencia.RecuperarLista("PAGO")
        If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
            For Each refDesc As ValorReferencia.Descripcion In aValores
                ValoresTipoPago.Add(refDesc.Id, refDesc.Cadena)
            Next
        End If
        aValores = Nothing
        'For Each dr As DataRow In ValorReferencia.RecuperarLista("PAGO").Rows
        '    ValoresTipoPago.Add(dr(0), dr(1))
        'Next
    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click

        OpcionSeleccionada = ServicesCentral.TiposOpcionesMenuDia.NoDefinido
        If bHuboCambios Then
            If MsgBox(refaVista.BuscarMensaje("Mensajes", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        Close()

    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click

        Revisar_Accion()
        Me.TabControlAplicacion.SelectedIndex = 1

    End Sub

    Public Sub Revisar_Accion()

        If Not RevisarElementoMarcado(ListViewMenu) Then
            eModo = Modo.Crear
        Else
            eModo = Modo.Modificar
            strDepKeyActual = ListViewMenu.Items(ListViewMenu.SelectedIndices.Item(0)).SubItems(3).Text
        End If

    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click

        Me.OpcionSeleccionada = ServicesCentral.TiposOpcionesMenuDia.NoDefinido
        If bHuboCambios Then
            If MsgBox(refaVista.BuscarMensaje("Mensajes", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        Me.Close()

    End Sub


    Private Sub TabControlAplicacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControlAplicacion.SelectedIndexChanged

        If eModo <> Modo.Cancelar Then
            Revisar_Accion()
        End If

        If TabControlAplicacion.SelectedIndex = 1 Then
            bValidarCambios = False
            'LlenaComboBanco()
            Configurar_Grid()

            If eModo = Modo.Crear Then

                Limpiar_Campos()
                dtpFecha.Value = Now

                BuscaAbonos()
                Activar_Campos(True)

            ElseIf eModo = Modo.Modificar Then

                Buscar_Deposito(strDepKeyActual)
                Activar_Campos(True)
                BuscaAbonos(" Where DepID='" & strDepKeyActual & "'")

            ElseIf eModo = Modo.Cancelar Then

                Buscar_Deposito(strDepKeyActual)
                Activar_Campos(False)
                BuscaAbonos(" Where DepID='" & strDepKeyActual & "'")

            End If

            ComboBoxBanco.Focus()
            bValidarCambios = True
            'bHuboCambios = False

        End If

    End Sub


    Public Sub Activar_Campos(ByVal Activo As Boolean, Optional ByVal Desactivar_Botones As Boolean = True)
        dtpFecha.Enabled = Activo
        TextBoxFicha.Enabled = Activo
        'TextBoxTotal.Enabled = Activo
        ComboBoxBanco.Enabled = Activo
        C1FlexGridAbonos.Enabled = Activo

    End Sub

    Public Sub Buscar_Deposito(ByVal strDeposito As String)
        Dim Query As String
        Query = "Select DEPId, TipoBanco, FechaCreacion, FechaDeposito, Ficha, Total from Deposito Where DepID='" & strDeposito & "'"
        Dim Dt As DataTable = oDBVen.RealizarConsultaSQL(Query, "ABNDetalle")
        For Each dr As DataRow In Dt.Rows
            TextBoxTotal.Text = dr("Total")
            TextBoxFicha.Text = dr("Ficha")
            Dim Item As CConceptos
            For cont As Integer = 0 To Me.ComboBoxBanco.Items.Count - 1
                Item = Me.ComboBoxBanco.Items(cont)
                If Item.Valor = dr("TipoBanco") Then
                    ComboBoxBanco.SelectedIndex = cont
                End If
            Next
            dtpFecha.Value = dr("FechaDeposito")
            'dteFecha.DateTimeStyle = Resco.Controls.DetailView.RescoDateTimePickerStyle.Date
        Next
        Dt.Dispose()
    End Sub


    Public Sub Limpiar_Campos()

        Me.TextBoxFicha.Text = ""
        Me.TextBoxTotal.Text = 0
        Me.ComboBoxBanco.SelectedIndex = -1


    End Sub



    Public Sub Sumar_Total()

        Dim i As Integer
        Dim iTotal As Decimal = 0
        Dim iImp As Decimal = 0

        For i = 1 To C1FlexGridAbonos.Rows.Count - 1
            If C1FlexGridAbonos.Item(i, 0) Then
                If Not C1FlexGridAbonos.Item(i, "Importe") Is Nothing Then
                    If IsNumeric(C1FlexGridAbonos.Item(i, "Importe")) Then
                        iImp = C1FlexGridAbonos.Item(i, "Importe")
                    End If
                End If

                iTotal = iTotal + iImp
            End If
        Next
        Me.TextBoxTotal.Text = iTotal
    End Sub

    Private Sub ButtonContinuar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar1.Click
        Sumar_Total()
        If ValidaCampos() Then
            Select Case eModo
                Case Modo.Crear
                    If Agregar_Deposito() Then
                        Me.Close()
                    End If
                Case Modo.Modificar
                    If Actualiza_Deposito() Then
                        Me.Close()
                    End If
                Case Modo.Cancelar
                    If Elimina_Deposito() Then
                        Me.Close()
                    End If
            End Select
        End If
    End Sub

    Public Function Actualiza_Deposito() As Boolean

        Try
            '//Grabar la información del Deposito en Deposito

            Dim strSQL As New System.Text.StringBuilder
            Dim iAbnID As String = ""
            Dim iAbnDetID As String = ""
            Dim dblImporte As Decimal = 0
            Dim dblSaldo As Decimal = 0

            'dteFecha.DateTimeStyle = Resco.Controls.DetailView.RescoDateTimePickerStyle.Date

            If oDBVen.oConexion.State = ConnectionState.Closed Then
                oDBVen.oConexion.Open()
            End If
            Transaccion = oDBVen.oConexion.BeginTransaction()

            With strSQL

                .Append("Update Deposito ")
                .Append("SET TipoBanco=" & ComboBoxBanco.SelectedValue)
                .Append(",FechaCreacion=" & UniFechaSQL(PrimeraHora(Now)))
                .Append(",FechaDeposito=" & UniFechaSQL(dtpFecha.Value))
                .Append(",Ficha='" & TextBoxFicha.Text & "'")
                .Append(",Total=" & TextBoxTotal.Text)
                .Append(",MFechaHora=" & UniFechaSQL(Now))
                .Append(",MUsuarioID='" & oVendedor.UsuarioId & "'")
                .Append(",Enviado=0")
                .Append(" Where DepID='" & strDepKeyActual & "'")

            End With

            oDBVen.EjecutarComandoSQL(strSQL.ToString)
            '//Eliminar todos los abonos para volverlos a crear            

            Dim strSQL2 As New System.Text.StringBuilder

            With strSQL2

                .Append("Delete from  ABDDep where DepID='")
                .Append(Me.strDepKeyActual & "'")

            End With

            oDBVen.EjecutarComandoSQL(strSQL2.ToString)

            '//Guardar la información del detalle del importe AbonoDeposito

            For cont As Integer = 1 To C1FlexGridAbonos.Rows.Count - 1

                iAbnID = C1FlexGridAbonos.Item(cont, 1)
                iAbnDetID = C1FlexGridAbonos.Item(cont, 2)
                dblImporte = CType(C1FlexGridAbonos.Item(cont, 4), Double)
                dblSaldo = CType(C1FlexGridAbonos.Item(cont, 5), Double)

                If CType(C1FlexGridAbonos.Item(cont, 0), Boolean) Then

                    Dim strSQL1 As New System.Text.StringBuilder

                    With strSQL1

                        .Append("Insert into AbdDep")
                        .Append("(DEPId, ABNId, ABDId, Importe, MFechaHora, MUsuarioID)")
                        .Append("Values('" & strDepKeyActual & "'")
                        .Append(",'" & iAbnID & "'")
                        .Append(",'" & iAbnDetID & "'")
                        .Append("," & dblImporte)
                        .Append(strEstatusModificado & ")")

                    End With

                    oDBVen.EjecutarComandoSQL(strSQL1.ToString)

                End If

                Dim strSQL3 As New System.Text.StringBuilder

                If CType(C1FlexGridAbonos.Item(cont, 0), Boolean) Then
                    dblSaldo -= dblImporte
                End If

                '//Actualizar el Saldo del ABONO
                With strSQL3

                    .Append(" Update AbnDetalle ")
                    .Append(" Set SaldoDeposito=" & dblSaldo)
                    .Append(",MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 Where ABNId='" & iAbnID & "' and ABDId='" & iAbnDetID & "'")

                End With

                oDBVen.EjecutarComandoSQL(strSQL3.ToString)


            Next

            Transaccion.Commit()

        Catch ex As SqlServerCe.SqlCeException
            Transaccion.Rollback()
            MsgBox(ex.Message)
            Return False
        Catch ex As Exception
            Transaccion.Rollback()
            MsgBox(ex.Message)
            Return False
        End Try
        Transaccion.Dispose()
        Transaccion = Nothing
        Return True

    End Function

    Public Function Elimina_Deposito() As Boolean

        Try
            If oDBVen.oConexion.State = ConnectionState.Closed Then
                oDBVen.oConexion.Open()
            End If
            Transaccion = oDBVen.oConexion.BeginTransaction()
            '//Grabar la información del Deposito en Deposito
            Dim strSQL As New System.Text.StringBuilder
            Dim iAbnID As String = ""
            Dim iAbnDetID As String = ""
            Dim dblImporte As Decimal = 0

            '//Guardar la información del detalle del importe AbonoDeposito

            For cont As Integer = 1 To C1FlexGridAbonos.Rows.Count - 1

                iAbnID = C1FlexGridAbonos.Item(cont, 1)
                iAbnDetID = C1FlexGridAbonos.Item(cont, 2)
                dblImporte = CType(C1FlexGridAbonos.Item(cont, 4), Double)

                Dim strSQL1 As New System.Text.StringBuilder

                With strSQL1
                    .Append("Delete from AbdDep where DepID='")
                    .Append(Me.strDepKeyActual & "'")
                End With


                oDBVen.EjecutarComandoSQL(strSQL1.ToString)

                Dim strSQL2 As New System.Text.StringBuilder

                '//Actualizar el Saldo del ABONO
                With strSQL2

                    .Append(" Update AbnDetalle ")
                    .Append(" Set SaldoDeposito=SaldoDeposito+" & dblImporte)
                    .Append(",MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 Where ABNId='" & iAbnID & "' and ABDId='" & iAbnDetID & "'")

                End With

                oDBVen.EjecutarComandoSQL(strSQL2.ToString)

            Next


            '//Borrar el registro padre
            With strSQL
                .Append("Delete from  Deposito where DepID='")
                .Append(Me.strDepKeyActual & "'")
            End With

            oDBVen.EjecutarComandoSQL(strSQL.ToString)

            Transaccion.Commit()

        Catch ex As SqlServerCe.SqlCeException
            Transaccion.Rollback()
            MsgBox(ex.Message)
            Return False
        Catch ex As Exception
            Transaccion.Rollback()
            MsgBox(ex.Message)
            Return False
        End Try
        Transaccion.Dispose()
        Transaccion = Nothing
        Return True

    End Function

    Public Function Agregar_Deposito() As Boolean

        Try

            '//Grabar la información del Deposito en Deposito

            If oDBVen.oConexion.State = ConnectionState.Closed Then
                oDBVen.oConexion.Open()
            End If

            Transaccion = oDBVen.oConexion.BeginTransaction()

            Dim strSQL As New System.Text.StringBuilder
            Dim iDepKey As String
            Dim iAbnID As String = ""
            Dim iAbnDetID As String = ""
            Dim dblImporte As Decimal = 0

            iDepKey = oApp.KEYGEN(100)

            With strSQL

                .Append("Insert into Deposito ")
                .Append("(DEPId, DiaClave, TipoBanco, FechaCreacion, FechaDeposito, Ficha, Total, MFechaHora, MUsuarioID)")
                .Append(" Values('" & iDepKey & "'")
                .Append(",'" & oDia.DiaActual & "'")
                .Append("," & ComboBoxBanco.SelectedValue)
                .Append("," & UniFechaSQL(PrimeraHora(Now)))
                .Append("," & UniFechaSQL(dtpFecha.Value))
                .Append(",'" & Me.TextBoxFicha.Text & "'")
                .Append("," & Me.TextBoxTotal.Text)
                .Append(strEstatusModificado & ")")

            End With

            oDBVen.EjecutarComandoSQL(strSQL.ToString)
            '//Guardar la información del detalle del importe AbonoDeposito

            For cont As Integer = 1 To C1FlexGridAbonos.Rows.Count - 1

                If CType(C1FlexGridAbonos.Item(cont, 0), Boolean) Then

                    iAbnID = C1FlexGridAbonos.Item(cont, 1)
                    iAbnDetID = C1FlexGridAbonos.Item(cont, 2)
                    dblImporte = CType(C1FlexGridAbonos.Item(cont, 4), Double)

                    Dim strSQL1 As New System.Text.StringBuilder

                    With strSQL1
                        .Append("Insert into AbdDep")
                        .Append("(DEPId, ABNId, ABDId, Importe, MFechaHora, MUsuarioID)")
                        .Append("Values('" & iDepKey & "'")
                        .Append(",'" & iAbnID & "'")
                        .Append(",'" & iAbnDetID & "'")
                        .Append("," & dblImporte)
                        .Append(strEstatusModificado & ")")
                    End With

                    oDBVen.EjecutarComandoSQL(strSQL1.ToString)

                    Dim strSQL2 As New System.Text.StringBuilder

                    '//Actualizar el Saldo del ABONO
                    With strSQL2
                        .Append(" Update AbnDetalle ")
                        .Append(" Set SaldoDeposito=SaldoDeposito-" & dblImporte)
                        .Append(",MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 Where ABNId='" & iAbnID & "' and ABDId='" & iAbnDetID & "'")
                    End With

                    oDBVen.EjecutarComandoSQL(strSQL2.ToString)

                End If
            Next

            Transaccion.Commit()
        Catch ex As SqlServerCe.SqlCeException
            Transaccion.Rollback()
            Transaccion.Dispose()
            Transaccion = Nothing
            MsgBox(ex.Message)
            Return False
        Catch ex As Exception
            Transaccion.Rollback()
            Transaccion.Dispose()
            Transaccion = Nothing
            MsgBox(ex.Message)
            Return False
        End Try
        Transaccion.Dispose()
        Transaccion = Nothing
        Return True

    End Function

    Private Sub ButtonRegresar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar1.Click
        If eModo = Modo.Cancelar Then
            Me.Close()
            Exit Sub
        End If

        If bHuboCambios Then
            If MsgBox(refaVista.BuscarMensaje("Mensajes", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        Me.Close()
    End Sub


    Private Sub HuboCambios(ByVal sender As System.Object, ByVal e As System.EventArgs)

        bHuboCambios = True

    End Sub


    Private Sub ListViewMenu_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewMenu.ItemCheck

        Try
            If blnSeleccionManual Then Exit Sub
            blnSeleccionManual = True
            MarcarElemento(Me.ListViewMenu, e.NewValue, e.Index)
            blnSeleccionManual = False
            If Me.ListViewMenu.SelectedIndices.Count <= 0 Then Exit Sub
            If e.NewValue = CheckState.Unchecked Then
                blnSeleccionManual = True
                Me.ListViewMenu.Items(Me.ListViewMenu.SelectedIndices(0)).Selected = False
                blnSeleccionManual = False
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ListViewMenu_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewMenu.SelectedIndexChanged

        Try
            If blnSeleccionManual Then Exit Sub
            If Me.ListViewMenu.SelectedIndices.Count <= 0 Then Exit Sub
            blnSeleccionManual = True
            MarcarElemento(Me.ListViewMenu, CheckState.Checked, Me.ListViewMenu.SelectedIndices(0))
            blnSeleccionManual = False

        Catch ex As Exception

        End Try

    End Sub

    Private Function ValidaCampos() As Boolean

        If eModo = Modo.Cancelar Then
            Return True
        End If

        If Not IsDate(dtpFecha.Value) Or dtpFecha.Value < "01/01/1980" Then

            MsgBox(SustituyeCampo(refaVista.BuscarMensaje("Mensajes", "BE0001"), LabelFechaDeposito.Text), MsgBoxStyle.Information, "Amesol Route")
            Me.dtpFecha.Focus()
            Return False

        ElseIf Me.ComboBoxBanco.SelectedIndex = -1 Then

            MsgBox(SustituyeCampo(refaVista.BuscarMensaje("Mensajes", "BE0001"), LabelBanco.Text), MsgBoxStyle.Information, "Amesol Route")
            ComboBoxBanco.Focus()
            Return False

        ElseIf Me.TextBoxFicha.Text = "" Then

            MsgBox(SustituyeCampo(refaVista.BuscarMensaje("Mensajes", "BE0001"), LabelFicha.Text), MsgBoxStyle.Information, "Amesol Route")
            Me.TextBoxFicha.Focus()
            Return False

        End If

        If RevisarGrid_Seleccion() Then

            MsgBox(refaVista.BuscarMensaje("Mensajes", "E0046"), MsgBoxStyle.Information, "Amesol Route")
            Me.C1FlexGridAbonos.Focus()
            Return False

        End If

        Return True
    End Function

    Public Function RevisarGrid_Seleccion() As Boolean

        Dim iCont As Integer = 0

        For cont As Integer = 1 To C1FlexGridAbonos.Rows.Count - 1

            If CType(C1FlexGridAbonos.Item(cont, 0), Boolean) Then

                iCont += 1

            End If

        Next

        Return iCont = 0

    End Function

    Private Sub C1FlexGridAbonos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1FlexGridAbonos.Click
        Sumar_Total()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click

        If RevisarElementoMarcado2(ListViewMenu) Then



            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select enviado  from Deposito where DepID= '" & ListViewMenu.Items(ListViewMenu.SelectedIndices.Item(0)).SubItems(3).Text & "'", "Consulta")
            If Not IsDBNull(Dt.Rows(0)("enviado")) AndAlso Dt.Rows(0)("enviado") Then
                MsgBox(refaVista.BuscarMensaje("Mensajes", "E0596"), MsgBoxStyle.Information)
            Else


                eModo = Modo.Cancelar
                strDepKeyActual = ListViewMenu.Items(ListViewMenu.SelectedIndices.Item(0)).SubItems(3).Text
                Me.TabControlAplicacion.SelectedIndex = 1
            End If
            Dt.Dispose()
        Else

            MsgBox(refaVista.BuscarMensaje("Mensajes", "E0046"), MsgBoxStyle.Information, "Amesol Route")
            Me.C1FlexGridAbonos.Focus()

        End If

    End Sub

    Private Sub C1FlexGridAbonos_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGridAbonos.AfterEdit
        Dim colActual As Byte
        Dim rowActual As Byte

        Dim Importe As Decimal
        Dim Saldo As Decimal

        colActual = e.Col
        rowActual = e.Row

        If e.Col = 0 Then
            Sumar_Total()
        End If

        C1FlexGridAbonos.Refresh()

        If e.Col = 4 Then

            Importe = C1FlexGridAbonos.Item(e.Row, 4)
            Saldo = C1FlexGridAbonos.Item(e.Row, 5)

            If Importe > Saldo Then

                MsgBox(refaVista.BuscarMensaje("Mensajes", "E0038"), MsgBoxStyle.Information, "Amesol Route")
                C1FlexGridAbonos.Item(e.Row, 4) = ImporteAnt
                e.Cancel = True

            End If

            If Importe <= 0 Then

                MsgBox(refaVista.BuscarMensaje("Mensajes", "E0041"), MsgBoxStyle.Information, "Amesol Route")
                C1FlexGridAbonos.Item(e.Row, 4) = ImporteAnt
                e.Cancel = True

            End If

            bHuboCambios = True

        End If


    End Sub

    Public Class CConceptos
        Private Con As String
        Private Val As String

        Public Sub New(ByVal v As String, ByVal c As String)
            MyBase.New()
            Me.Val = v
            Me.Con = c
        End Sub

        Public ReadOnly Property Concepto() As String
            Get
                Return Con
            End Get
        End Property

        Public ReadOnly Property Valor() As String
            Get
                Return Val
            End Get
        End Property
    End Class

    Private Sub C1FlexGridAbonos_StartEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGridAbonos.StartEdit

        If e.Col = 4 Then
            ImporteAnt = C1FlexGridAbonos.Item(e.Row, 4)
        End If

    End Sub

    Private Sub dtpFecha_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles dtpFecha.TextChanged, ComboBoxBanco.TextChanged, TextBoxFicha.TextChanged, TextBoxTotal.TextChanged
        If bValidarCambios Then bHuboCambios = True

    End Sub

End Class


