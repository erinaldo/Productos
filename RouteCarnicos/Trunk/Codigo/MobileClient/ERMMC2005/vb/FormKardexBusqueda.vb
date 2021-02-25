
Public Class FormKardexBusqueda
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal parTipoBusqueda As TipoBusqueda)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        eTipoBusqueda = parTipoBusqueda
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
        If (Not IsNothing(MenuItemRegresar)) Then
            MenuItemRegresar.Dispose()
            MenuItemRegresar = Nothing
        End If
        If Not Me.MainMenuKardex Is Nothing Then Me.MainMenuKardex.Dispose()
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MainMenuKardex As System.Windows.Forms.MainMenu
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents PanelMovimientos As System.Windows.Forms.Panel
    Friend WithEvents ComboBoxComparaFecha As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxFecha As System.Windows.Forms.CheckBox
    Friend WithEvents PanelBusquedaPro As System.Windows.Forms.Panel
    Friend WithEvents ComboBoxTipoMov As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxComparaMov As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxMov As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxNombre As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxComparaNombre As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxNombre As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxClave As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxComparaClave As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxClave As System.Windows.Forms.CheckBox
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenuKardex = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.PanelMovimientos = New System.Windows.Forms.Panel
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker
        Me.dtpFechaIni = New System.Windows.Forms.DateTimePicker
        Me.ComboBoxComparaFecha = New System.Windows.Forms.ComboBox
        Me.CheckBoxFecha = New System.Windows.Forms.CheckBox
        Me.PanelBusquedaPro = New System.Windows.Forms.Panel
        Me.ComboBoxTipoMov = New System.Windows.Forms.ComboBox
        Me.ComboBoxComparaMov = New System.Windows.Forms.ComboBox
        Me.CheckBoxMov = New System.Windows.Forms.CheckBox
        Me.TextBoxNombre = New System.Windows.Forms.TextBox
        Me.ComboBoxComparaNombre = New System.Windows.Forms.ComboBox
        Me.CheckBoxNombre = New System.Windows.Forms.CheckBox
        Me.TextBoxClave = New System.Windows.Forms.TextBox
        Me.ComboBoxComparaClave = New System.Windows.Forms.ComboBox
        Me.CheckBoxClave = New System.Windows.Forms.CheckBox
        Me.Panel1.SuspendLayout()
        Me.PanelMovimientos.SuspendLayout()
        Me.PanelBusquedaPro.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenuKardex
        '
        Me.MainMenuKardex.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
        Me.Panel1.Controls.Add(Me.PanelMovimientos)
        Me.Panel1.Controls.Add(Me.PanelBusquedaPro)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(83, 262)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresar.TabIndex = 4
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(3, 262)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuar.TabIndex = 5
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'PanelMovimientos
        '
        Me.PanelMovimientos.Controls.Add(Me.dtpFechaFin)
        Me.PanelMovimientos.Controls.Add(Me.dtpFechaIni)
        Me.PanelMovimientos.Controls.Add(Me.ComboBoxComparaFecha)
        Me.PanelMovimientos.Controls.Add(Me.CheckBoxFecha)
        Me.PanelMovimientos.Location = New System.Drawing.Point(0, 2)
        Me.PanelMovimientos.Name = "PanelMovimientos"
        Me.PanelMovimientos.Size = New System.Drawing.Size(240, 227)
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaFin.Enabled = False
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaFin.Location = New System.Drawing.Point(148, 37)
        Me.dtpFechaFin.MaxDate = New Date(2500, 12, 31, 0, 0, 0, 0)
        Me.dtpFechaFin.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(88, 22)
        Me.dtpFechaFin.TabIndex = 14
        Me.dtpFechaFin.Value = New Date(2007, 1, 30, 0, 0, 0, 0)
        '
        'dtpFechaIni
        '
        Me.dtpFechaIni.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaIni.Enabled = False
        Me.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaIni.Location = New System.Drawing.Point(148, 8)
        Me.dtpFechaIni.MaxDate = New Date(2500, 12, 31, 0, 0, 0, 0)
        Me.dtpFechaIni.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaIni.Name = "dtpFechaIni"
        Me.dtpFechaIni.Size = New System.Drawing.Size(88, 22)
        Me.dtpFechaIni.TabIndex = 13
        Me.dtpFechaIni.Value = New Date(2007, 1, 30, 0, 0, 0, 0)
        '
        'ComboBoxComparaFecha
        '
        Me.ComboBoxComparaFecha.Enabled = False
        Me.ComboBoxComparaFecha.Location = New System.Drawing.Point(69, 8)
        Me.ComboBoxComparaFecha.Name = "ComboBoxComparaFecha"
        Me.ComboBoxComparaFecha.Size = New System.Drawing.Size(77, 22)
        Me.ComboBoxComparaFecha.TabIndex = 1
        '
        'CheckBoxFecha
        '
        Me.CheckBoxFecha.Location = New System.Drawing.Point(1, 8)
        Me.CheckBoxFecha.Name = "CheckBoxFecha"
        Me.CheckBoxFecha.Size = New System.Drawing.Size(72, 20)
        Me.CheckBoxFecha.TabIndex = 2
        Me.CheckBoxFecha.Text = "CheckBoxFecha"
        '
        'PanelBusquedaPro
        '
        Me.PanelBusquedaPro.Controls.Add(Me.ComboBoxTipoMov)
        Me.PanelBusquedaPro.Controls.Add(Me.ComboBoxComparaMov)
        Me.PanelBusquedaPro.Controls.Add(Me.CheckBoxMov)
        Me.PanelBusquedaPro.Controls.Add(Me.TextBoxNombre)
        Me.PanelBusquedaPro.Controls.Add(Me.ComboBoxComparaNombre)
        Me.PanelBusquedaPro.Controls.Add(Me.CheckBoxNombre)
        Me.PanelBusquedaPro.Controls.Add(Me.TextBoxClave)
        Me.PanelBusquedaPro.Controls.Add(Me.ComboBoxComparaClave)
        Me.PanelBusquedaPro.Controls.Add(Me.CheckBoxClave)
        Me.PanelBusquedaPro.Location = New System.Drawing.Point(0, 2)
        Me.PanelBusquedaPro.Name = "PanelBusquedaPro"
        Me.PanelBusquedaPro.Size = New System.Drawing.Size(240, 239)
        '
        'ComboBoxTipoMov
        '
        Me.ComboBoxTipoMov.Enabled = False
        Me.ComboBoxTipoMov.Location = New System.Drawing.Point(89, 141)
        Me.ComboBoxTipoMov.Name = "ComboBoxTipoMov"
        Me.ComboBoxTipoMov.Size = New System.Drawing.Size(145, 22)
        Me.ComboBoxTipoMov.TabIndex = 0
        '
        'ComboBoxComparaMov
        '
        Me.ComboBoxComparaMov.Enabled = False
        Me.ComboBoxComparaMov.Location = New System.Drawing.Point(89, 116)
        Me.ComboBoxComparaMov.Name = "ComboBoxComparaMov"
        Me.ComboBoxComparaMov.Size = New System.Drawing.Size(88, 22)
        Me.ComboBoxComparaMov.TabIndex = 1
        '
        'CheckBoxMov
        '
        Me.CheckBoxMov.Location = New System.Drawing.Point(2, 116)
        Me.CheckBoxMov.Name = "CheckBoxMov"
        Me.CheckBoxMov.Size = New System.Drawing.Size(86, 20)
        Me.CheckBoxMov.TabIndex = 2
        Me.CheckBoxMov.Text = "CheckBoxMov"
        '
        'TextBoxNombre
        '
        Me.TextBoxNombre.Enabled = False
        Me.TextBoxNombre.Location = New System.Drawing.Point(89, 88)
        Me.TextBoxNombre.Name = "TextBoxNombre"
        Me.TextBoxNombre.Size = New System.Drawing.Size(145, 21)
        Me.TextBoxNombre.TabIndex = 3
        '
        'ComboBoxComparaNombre
        '
        Me.ComboBoxComparaNombre.Enabled = False
        Me.ComboBoxComparaNombre.Location = New System.Drawing.Point(89, 61)
        Me.ComboBoxComparaNombre.Name = "ComboBoxComparaNombre"
        Me.ComboBoxComparaNombre.Size = New System.Drawing.Size(88, 22)
        Me.ComboBoxComparaNombre.TabIndex = 4
        '
        'CheckBoxNombre
        '
        Me.CheckBoxNombre.Location = New System.Drawing.Point(2, 61)
        Me.CheckBoxNombre.Name = "CheckBoxNombre"
        Me.CheckBoxNombre.Size = New System.Drawing.Size(86, 20)
        Me.CheckBoxNombre.TabIndex = 5
        Me.CheckBoxNombre.Text = "CheckBoxNombre"
        '
        'TextBoxClave
        '
        Me.TextBoxClave.Enabled = False
        Me.TextBoxClave.Location = New System.Drawing.Point(89, 32)
        Me.TextBoxClave.Name = "TextBoxClave"
        Me.TextBoxClave.Size = New System.Drawing.Size(145, 21)
        Me.TextBoxClave.TabIndex = 6
        '
        'ComboBoxComparaClave
        '
        Me.ComboBoxComparaClave.Enabled = False
        Me.ComboBoxComparaClave.Location = New System.Drawing.Point(89, 7)
        Me.ComboBoxComparaClave.Name = "ComboBoxComparaClave"
        Me.ComboBoxComparaClave.Size = New System.Drawing.Size(88, 22)
        Me.ComboBoxComparaClave.TabIndex = 7
        '
        'CheckBoxClave
        '
        Me.CheckBoxClave.Location = New System.Drawing.Point(2, 7)
        Me.CheckBoxClave.Name = "CheckBoxClave"
        Me.CheckBoxClave.Size = New System.Drawing.Size(86, 20)
        Me.CheckBoxClave.TabIndex = 8
        Me.CheckBoxClave.Text = "CheckBoxClave"
        '
        'FormKardexBusqueda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuKardex
        Me.MinimizeBox = False
        Me.Name = "FormKardexBusqueda"
        Me.Panel1.ResumeLayout(False)
        Me.PanelMovimientos.ResumeLayout(False)
        Me.PanelBusquedaPro.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private refaVista As Vista
    Private eTipoBusqueda As TipoBusqueda
    Private condiciones, query As String
    Private blnSeleccionManual As Boolean = False
    Private sProductoClave As String

    Property Cadena() As String
        Get
            Return condiciones
        End Get
        Set(ByVal Value As String)
            condiciones = Value
        End Set
    End Property

    ReadOnly Property FechaIni() As DateTime
        Get
            Return dtpFechaIni.Value
        End Get
    End Property

    Property ProductoClave() As String
        Get
            Return sProductoClave
        End Get
        Set(ByVal Value As String)
            sProductoClave = Value
        End Set
    End Property

#Region "Forma"
    Private Sub FormKardexBusqueda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        ' Recuperar los demás componentes de la forma
        If Not MobileClient.Vista.Buscar("FormKardexBusqueda", refaVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        dtpFechaIni.Value = PrimeraHora(Today)
        dtpFechaFin.Value = PrimeraHora(Today)
        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)
        LlenaCombos()
        Vista()
        Cursor.Current = Cursors.Default

        CheckBoxClave.Focus()

    End Sub
#End Region

    Private Sub Vista()
        PanelBusquedaPro.Visible = eTipoBusqueda = TipoBusqueda.Producto
        PanelMovimientos.Visible = eTipoBusqueda = TipoBusqueda.Movimiento
    End Sub


    Private Sub LlenaCombos()

        If eTipoBusqueda = TipoBusqueda.Producto Then
            'ComboBoxComparaClave
            With ComboBoxComparaClave
                .DataSource = ValorReferencia.RecuperarLista("BFSTRING")
                If .Items.Count > 0 Then
                    .DisplayMember = "Cadena"
                    .ValueMember = "Id"
                    .SelectedIndex = 0
                End If
            End With

            'ComboBoxComparaNombre
            With ComboBoxComparaNombre
                .DataSource = ValorReferencia.RecuperarLista("BFSTRING")
                If .Items.Count > 0 Then
                    .DisplayMember = "Cadena"
                    .ValueMember = "Id"
                    .SelectedIndex = 0
                End If
            End With

            'ComboBoxComparaMov
            With ComboBoxComparaMov
                .DataSource = ValorReferencia.RecuperarLista("BFVARREF")
                If .Items.Count > 0 Then
                    .DisplayMember = "Cadena"
                    .ValueMember = "Id"
                    .SelectedIndex = 0
                End If
            End With

            With ComboBoxTipoMov
                .DataSource = ValorReferencia.RecuperarLista("TRPTIPO")
                If .Items.Count > 0 Then
                    .DisplayMember = "Cadena"
                    .ValueMember = "Id"
                    .SelectedIndex = 0
                End If
            End With
        Else
            blnSeleccionManual = True
            'ComboBoxComparaFecha
            With ComboBoxComparaFecha
                .DataSource = ValorReferencia.RecuperarLista("BFNUMERI")
                If .Items.Count > 0 Then
                    .DisplayMember = "Cadena"
                    .ValueMember = "Id"
                    .SelectedIndex = 0
                End If
            End With
            blnSeleccionManual = False
        End If

    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.Close()
    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        If Not ValidaCampos() Then Exit Sub
        CreaCondiciones()
        If HayRegistros(query) Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0034"))
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        If eTipoBusqueda = TipoBusqueda.Producto Then
            If CheckBoxClave.Checked Then
                If IsNothing(ComboBoxComparaClave.SelectedValue) Or TextBoxClave.Text = "" Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.CheckBoxClave.Text))
                    If IsNothing(ComboBoxComparaClave.SelectedValue) Then
                        ComboBoxComparaClave.Focus()
                    Else
                        TextBoxClave.Focus()
                    End If
                    Return False

                End If
            End If

            If CheckBoxNombre.Checked Then
                If IsNothing(ComboBoxComparaNombre.SelectedValue) Or TextBoxNombre.Text = "" Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.CheckBoxNombre.Text))
                    If IsNothing(ComboBoxComparaNombre.SelectedValue) Then
                        ComboBoxComparaNombre.Focus()
                    Else
                        TextBoxNombre.Focus()
                    End If
                    Return False
                End If
            End If

            If CheckBoxMov.Checked Then
                If IsNothing(ComboBoxComparaMov.SelectedValue) Or IsNothing(ComboBoxTipoMov.SelectedValue) OrElse ComboBoxTipoMov.SelectedValue < 0 Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.CheckBoxMov.Text))
                    If IsNothing(ComboBoxComparaMov.SelectedValue) Then
                        ComboBoxComparaMov.Focus()
                    Else
                        ComboBoxTipoMov.Focus()
                    End If
                    Return False
                End If
            End If
        Else
            If CheckBoxFecha.Checked Then
                If IsNothing(ComboBoxComparaFecha.SelectedValue) Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.CheckBoxFecha.Text))
                    ComboBoxComparaFecha.Focus()
                    Return False
                End If
            End If
        End If

        Return True
    End Function

    Private Function HayRegistros(ByVal s As String) As Boolean
        Dim dt As DataTable = oDBVen.RealizarConsultaSQL(s, "reg")
        If dt.Rows.Count > 0 Then
            dt.Dispose()
            Return True
        End If
        dt.Dispose()
        Return False
    End Function


    Private Sub CheckBoxClave_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxClave.CheckStateChanged
        ComboBoxComparaClave.Enabled = CheckBoxClave.Checked
        TextBoxClave.Enabled = CheckBoxClave.Checked
    End Sub

    Private Sub CheckBoxFecha_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxFecha.CheckStateChanged
        ComboBoxComparaFecha.Enabled = CheckBoxFecha.Checked
        dtpFechaIni.Enabled = CheckBoxFecha.Checked
    End Sub

    Private Sub CheckBoxMov_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxMov.Click
        ComboBoxComparaMov.Enabled = CheckBoxMov.Checked
        ComboBoxTipoMov.Enabled = CheckBoxMov.Checked
    End Sub

    Private Sub CheckBoxNombre_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxNombre.CheckStateChanged
        ComboBoxComparaNombre.Enabled = CheckBoxNombre.Checked
        TextBoxNombre.Enabled = CheckBoxNombre.Checked
    End Sub

    Private Sub ComboBoxComparaFecha_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxComparaFecha.SelectedIndexChanged
        If blnSeleccionManual Then Exit Sub
        If ComboBoxComparaFecha.SelectedValue = 7 Then
            dtpFechaFin.Enabled = True
        Else
            dtpFechaFin.Enabled = False
        End If
    End Sub

    Private Sub CreaCondiciones()
        condiciones = ""
        If eTipoBusqueda = TipoBusqueda.Producto Then
            query = "Select distinct Producto.ProductoClave from Producto inner join inventario on Producto.ProductoClave =Inventario.ProductoClave inner join TransProdDetalle on Producto.ProductoClave =transProdDetalle.ProductoClave inner join TransProd on TransProdDetalle.TransProdID = TransProd.TransProdID "
            If CheckBoxClave.Checked Then
                If condiciones <> "" Then
                    condiciones &= " AND "
                End If
                condiciones &= " Producto.ProductoClave " & Operador(ComboBoxComparaClave.SelectedValue, Me.TextBoxClave.Text, "", TipoDato.Cadena)
            End If

            If CheckBoxNombre.Checked Then
                If condiciones <> "" Then
                    condiciones &= " AND "
                End If
                condiciones &= " Producto.Nombre " & Operador(ComboBoxComparaNombre.SelectedValue, Me.TextBoxNombre.Text, "", TipoDato.Cadena)
            End If
            If CheckBoxMov.Checked Then
                If condiciones <> "" Then
                    condiciones &= " AND "
                End If
                condiciones &= " TransProd.Tipo " & Operador(ComboBoxComparaMov.SelectedValue, ComboBoxTipoMov.SelectedValue, "", TipoDato.Numerico)
            End If

            If condiciones <> "" Then
                query &= " WHERE " & condiciones
            End If
        Else
            query = "select  TransProdDetalle.ProductoClave from transprod inner join TransProdDetalle on TransProd.TransProdID = TransProdDetalle.TransProdID inner join ProductoDetalle on TransProdDetalle.ProductoClave = ProductoDetalle.ProductoClave  and ProductoDetalle.PRUTipoUnidad = TransProdDetalle.TipoUnidad and ProductoDetalle.ProductoDetClave = TransProdDetalle.ProductoClave WHERE TransProdDetalle.ProductoClave='" & ProductoClave & "' AND TransProd.DiaClave in(SELECT DiaClave FROM Agenda) and TipoFase <> 0 and Tipo <> 19"
            If CheckBoxFecha.Checked Then
                condiciones &= " and TransProd.FechaHoraAlta " & Operador(ComboBoxComparaFecha.SelectedValue, dtpFechaIni.Value, dtpFechaFin.Value, TipoDato.Fecha)
            End If

            If condiciones <> "" Then
                query &= condiciones
            End If

        End If

    End Sub

    Public Enum TipoBusqueda
        Producto = 1
        Movimiento
    End Enum

    Private Sub MenuItemRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        ButtonRegresar_Click(Nothing, Nothing)
    End Sub
End Class
