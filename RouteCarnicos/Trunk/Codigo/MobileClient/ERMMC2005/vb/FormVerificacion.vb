Public Class FormVerificacion
    Inherits System.Windows.Forms.Form

    Private bEscalado As Boolean = False

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        Me.DialogResult = Windows.Forms.DialogResult.Yes
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MainMenuVerificacion Is Nothing Then Me.MainMenuVerificacion.Dispose()
        MyBase.Dispose(disposing)
    End Sub

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents PanelConexion As System.Windows.Forms.Panel
    Friend WithEvents DetailViewDatosConexion As Resco.Controls.DetailView.DetailView
    Friend WithEvents ButtonConectar As System.Windows.Forms.Button
    Friend WithEvents ButtonSalir As System.Windows.Forms.Button
    Friend WithEvents MainMenuVerificacion As System.Windows.Forms.MainMenu
    Friend WithEvents InputPanelVerificacion As Microsoft.WindowsCE.Forms.InputPanel
    Friend WithEvents LabelMensaje As System.Windows.Forms.Label
    Friend WithEvents PictureBoxLogoERM As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormVerificacion))
        Me.PanelConexion = New System.Windows.Forms.Panel
        Me.LabelMensaje = New System.Windows.Forms.Label
        Me.PictureBoxLogoERM = New System.Windows.Forms.PictureBox
        Me.DetailViewDatosConexion = New Resco.Controls.DetailView.DetailView
        Me.ButtonConectar = New System.Windows.Forms.Button
        Me.ButtonSalir = New System.Windows.Forms.Button
        Me.MainMenuVerificacion = New System.Windows.Forms.MainMenu
        Me.InputPanelVerificacion = New Microsoft.WindowsCE.Forms.InputPanel
        Me.PanelConexion.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelConexion
        '
        Me.PanelConexion.BackColor = System.Drawing.Color.Snow
        Me.PanelConexion.Controls.Add(Me.LabelMensaje)
        Me.PanelConexion.Controls.Add(Me.PictureBoxLogoERM)
        Me.PanelConexion.Controls.Add(Me.DetailViewDatosConexion)
        Me.PanelConexion.Controls.Add(Me.ButtonConectar)
        Me.PanelConexion.Controls.Add(Me.ButtonSalir)
        Me.PanelConexion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelConexion.Location = New System.Drawing.Point(0, 0)
        Me.PanelConexion.Name = "PanelConexion"
        Me.PanelConexion.Size = New System.Drawing.Size(242, 295)
        '
        'LabelMensaje
        '
        Me.LabelMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelMensaje.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelMensaje.Location = New System.Drawing.Point(22, 101)
        Me.LabelMensaje.Name = "LabelMensaje"
        Me.LabelMensaje.Size = New System.Drawing.Size(204, 20)
        Me.LabelMensaje.Text = "Server Data:"
        '
        'PictureBoxLogoERM
        '
        Me.PictureBoxLogoERM.Image = CType(resources.GetObject("PictureBoxLogoERM.Image"), System.Drawing.Image)
        Me.PictureBoxLogoERM.Location = New System.Drawing.Point(26, 16)
        Me.PictureBoxLogoERM.Name = "PictureBoxLogoERM"
        Me.PictureBoxLogoERM.Size = New System.Drawing.Size(192, 80)
        Me.PictureBoxLogoERM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'DetailViewDatosConexion
        '
        Me.DetailViewDatosConexion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DetailViewDatosConexion.LabelWidth = 100
        Me.DetailViewDatosConexion.Location = New System.Drawing.Point(22, 122)
        Me.DetailViewDatosConexion.Name = "DetailViewDatosConexion"
        Me.DetailViewDatosConexion.SeparatorWidth = 4
        Me.DetailViewDatosConexion.Size = New System.Drawing.Size(204, 116)
        Me.DetailViewDatosConexion.TabIndex = 2
        '
        'ButtonConectar
        '
        Me.ButtonConectar.Location = New System.Drawing.Point(26, 242)
        Me.ButtonConectar.Name = "ButtonConectar"
        Me.ButtonConectar.Size = New System.Drawing.Size(68, 24)
        Me.ButtonConectar.TabIndex = 3
        Me.ButtonConectar.Text = "Connect"
        '
        'ButtonSalir
        '
        Me.ButtonSalir.Location = New System.Drawing.Point(98, 242)
        Me.ButtonSalir.Name = "ButtonSalir"
        Me.ButtonSalir.Size = New System.Drawing.Size(68, 24)
        Me.ButtonSalir.TabIndex = 4
        Me.ButtonSalir.Text = "Exit"
        '
        'FormVerificacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelConexion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(0, 20)
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuVerificacion
        Me.MinimizeBox = False
        Me.Name = "FormVerificacion"
        Me.PanelConexion.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub LlenarComboTerminal()
        Dim oItem As Resco.Controls.DetailView.ItemComboBox
        oItem = DetailViewDatosConexion.Items("ComboBoxTerminal")
        oItem.Add("Generico")
        oItem.Add("HHP7600")
        oItem.Add("HHP7900")
        oItem.Add("HHPWM6")
        oItem.Add("IntermecCN3")
        oItem.Add("SymbolC9090")
        oItem.Add("SymbolMC35")
        oItem.Add("SymbolMC50")
        oItem.Add("SymbolMC70")
        oItem.Add("SymbolMC55")
    End Sub

    Private Sub CrearItemDetailView(ByRef prDetailView As Resco.Controls.DetailView.DetailView, ByVal pvTipoControl As ServicesCentral.TiposControlDetalle, ByVal pvNombre As String, ByVal pvTipoEdicion As ServicesCentral.TiposEdicion, ByVal pvTipoVisible As ServicesCentral.TiposVisible, ByVal pvTexto As String, ByVal pvTipoAlineacion As ServicesCentral.TiposAlineacion, Optional ByVal pvPasswordChar As String = "")
        Select Case pvTipoControl
            Case ServicesCentral.TiposControlDetalle.Etiqueta
                Dim ItemNuevo As New Resco.Controls.DetailView.Item
                ItemNuevo.LabelForeColor = System.Drawing.Color.DarkBlue
                ItemNuevo.LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
                ItemNuevo.LabelAlignment = HorizontalAlignment.Left
                ItemNuevo.TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                ItemNuevo.TextForeColor = System.Drawing.Color.Black
                ItemNuevo.Name = pvNombre
                ItemNuevo.Enabled = (pvTipoEdicion = ServicesCentral.TiposEdicion.Editar)
                ItemNuevo.Visible = (pvTipoVisible = ServicesCentral.TiposVisible.Visible)
                ItemNuevo.ItemBorder = Resco.Controls.DetailView.ItemBorder.Underline
                ItemNuevo.TextAlign = [Global].ObtenerAlineacion(pvTipoAlineacion)
                ItemNuevo.Label = pvTexto
                ItemNuevo.Height = PubcAlturaItemsDetailView * IIf(bEscalarDV, nFactorH, 1)
                ItemNuevo.Tag = ""
                prDetailView.Items.Add(ItemNuevo)
            Case ServicesCentral.TiposControlDetalle.Texto
                Dim TextBoxNuevo As New Resco.Controls.DetailView.ItemTextBox
                TextBoxNuevo.LabelForeColor = System.Drawing.Color.DarkBlue
                TextBoxNuevo.LabelAlignment = HorizontalAlignment.Left
                TextBoxNuevo.TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                TextBoxNuevo.TextForeColor = System.Drawing.Color.Black
                TextBoxNuevo.Name = pvNombre
                TextBoxNuevo.Enabled = (pvTipoEdicion = ServicesCentral.TiposEdicion.Editar)
                If TextBoxNuevo.Enabled Then
                    TextBoxNuevo.TextBackColor = System.Drawing.Color.Aqua
                    TextBoxNuevo.LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                    TextBoxNuevo.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat
                Else
                    TextBoxNuevo.LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
                    TextBoxNuevo.ItemBorder = Resco.Controls.DetailView.ItemBorder.Underline
                End If
                'TextBoxNuevo.MaxLength = pvAncho
                TextBoxNuevo.Visible = (pvTipoVisible = ServicesCentral.TiposVisible.Visible)
                TextBoxNuevo.TextAlign = [Global].ObtenerAlineacion(pvTipoAlineacion)
                TextBoxNuevo.Label = pvTexto
                TextBoxNuevo.Height = PubcAlturaItemsDetailView * IIf(bEscalarDV, nFactorH, 1)
                TextBoxNuevo.Tag = ""
                If pvPasswordChar <> "" Then
                    TextBoxNuevo.PasswordChar = pvPasswordChar
                End If
                prDetailView.Items.Add(TextBoxNuevo)
            Case ServicesCentral.TiposControlDetalle.Logico
                Dim CheckBoxNuevo As New Resco.Controls.DetailView.ItemCheckBox
                CheckBoxNuevo.LabelForeColor = System.Drawing.Color.DarkBlue
                CheckBoxNuevo.LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                CheckBoxNuevo.LabelAlignment = [Global].ObtenerAlineacion(pvTipoAlineacion)
                CheckBoxNuevo.Label = pvTexto
                CheckBoxNuevo.TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                CheckBoxNuevo.TextForeColor = System.Drawing.Color.Black
                CheckBoxNuevo.Name = pvNombre
                CheckBoxNuevo.Enabled = (pvTipoEdicion = ServicesCentral.TiposEdicion.Editar)
                CheckBoxNuevo.Visible = (pvTipoVisible = ServicesCentral.TiposVisible.Visible)
                CheckBoxNuevo.ItemBorder = Resco.Controls.DetailView.ItemBorder.Underline
                CheckBoxNuevo.QuickChange = True
                CheckBoxNuevo.Checked = True
                'CheckBoxNuevo.CheckState = CheckState.Checked
                CheckBoxNuevo.ThreeState = False
                'CheckBoxNuevo.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop
                'CheckBoxNuevo.LabelHeight = 0
                CheckBoxNuevo.Height = PubcAlturaItemsDetailView * IIf(bEscalarDV, nFactorH, 1)
                CheckBoxNuevo.Tag = ""
                prDetailView.Items.Add(CheckBoxNuevo)
            Case ServicesCentral.TiposControlDetalle.Salto
                Dim PageBreakNuevo As New Resco.Controls.DetailView.ItemPageBreak
                PageBreakNuevo.Text = pvTexto
                PageBreakNuevo.TextAlign = [Global].ObtenerAlineacion(pvTipoAlineacion)
                PageBreakNuevo.TextFont = New System.Drawing.Font("Verdana", IIf(8.0! * nFactorFont < 7.0, 7.0, 8.0! * nFactorFont), System.Drawing.FontStyle.Regular)
                PageBreakNuevo.LabelFont = New System.Drawing.Font("Verdana", IIf(8.0! * nFactorFont < 7.0, 7.0, 8.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                PageBreakNuevo.Tag = PubcMarcaSaltos
                prDetailView.Items.Add(PageBreakNuevo)
            Case ServicesCentral.TiposControlDetalle.Numerico
                Dim NumericoNuevo As New Resco.Controls.DetailView.ItemNumeric
                NumericoNuevo.Text = pvTexto
                NumericoNuevo.TextAlign = [Global].ObtenerAlineacion(pvTipoAlineacion)
                NumericoNuevo.TextFont = New System.Drawing.Font("Verdana", IIf(8.0! * nFactorFont < 7.0, 7.0, 8.0! * nFactorFont), System.Drawing.FontStyle.Regular)
                NumericoNuevo.LabelFont = New System.Drawing.Font("Verdana", IIf(8.0! * nFactorFont < 7.0, 7.0, 8.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                NumericoNuevo.LabelForeColor = System.Drawing.Color.DarkBlue
                NumericoNuevo.LabelAlignment = HorizontalAlignment.Left
                NumericoNuevo.Tag = "Numeric"
                NumericoNuevo.DecimalPlaces = 2
                NumericoNuevo.ItemBorder = Resco.Controls.DetailView.ItemBorder.Underline
                NumericoNuevo.Maximum = 100
                NumericoNuevo.Minimum = 0
                NumericoNuevo.NumericValue = 0
                If NumericoNuevo.Enabled Then
                    NumericoNuevo.TextBackColor = System.Drawing.Color.Aqua
                    NumericoNuevo.LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                    NumericoNuevo.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat
                Else
                    NumericoNuevo.LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
                    NumericoNuevo.ItemBorder = Resco.Controls.DetailView.ItemBorder.Underline
                End If
                NumericoNuevo.Name = pvNombre
                NumericoNuevo.Label = pvTexto
                NumericoNuevo.Height = PubcAlturaItemsDetailView * IIf(bEscalarDV, nFactorH, 1)
                NumericoNuevo.Visible = (pvTipoVisible = ServicesCentral.TiposVisible.Visible)
                prDetailView.Items.Add(NumericoNuevo)
            Case ServicesCentral.TiposControlDetalle.Combo
                Dim ComboNuevo As New Resco.Controls.DetailView.ItemComboBox
                ComboNuevo.LabelForeColor = System.Drawing.Color.DarkBlue
                ComboNuevo.LabelAlignment = HorizontalAlignment.Left
                ComboNuevo.TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                ComboNuevo.TextForeColor = System.Drawing.Color.Black
                ComboNuevo.Name = pvNombre
                ComboNuevo.Enabled = (pvTipoEdicion = ServicesCentral.TiposEdicion.Editar)
                If ComboNuevo.Enabled Then
                    ComboNuevo.TextBackColor = System.Drawing.Color.Aqua
                    ComboNuevo.LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                    ComboNuevo.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat
                Else
                    ComboNuevo.LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
                    ComboNuevo.ItemBorder = Resco.Controls.DetailView.ItemBorder.Underline
                End If
                ComboNuevo.Visible = (pvTipoVisible = ServicesCentral.TiposVisible.Visible)
                ComboNuevo.TextAlign = [Global].ObtenerAlineacion(pvTipoAlineacion)
                ComboNuevo.Label = pvTexto
                ComboNuevo.Height = PubcAlturaItemsDetailView * IIf(bEscalarDV, nFactorH, 1)
                ComboNuevo.DropDownStyle = Resco.Controls.DetailView.RescoComboBoxStyle.DropDownList
                ComboNuevo.Tag = "Combo"
                prDetailView.Items.Add(ComboNuevo)
            Case ServicesCentral.TiposControlDetalle.Fecha
                Dim FechaNuevo As New Resco.Controls.DetailView.ItemDateTime
                FechaNuevo.TextAlign = [Global].ObtenerAlineacion(pvTipoAlineacion)
                FechaNuevo.TextFont = New System.Drawing.Font("Verdana", IIf(8.0! * nFactorFont < 7.0, 7.0, 8.0! * nFactorFont), System.Drawing.FontStyle.Regular)
                FechaNuevo.LabelFont = New System.Drawing.Font("Verdana", IIf(8.0! * nFactorFont < 7.0, 7.0, 8.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                FechaNuevo.LabelForeColor = System.Drawing.Color.DarkBlue
                FechaNuevo.LabelAlignment = HorizontalAlignment.Left
                FechaNuevo.Tag = "TimeDate"
                FechaNuevo.ItemBorder = Resco.Controls.DetailView.ItemBorder.Underline
                If FechaNuevo.Enabled Then
                    FechaNuevo.TextBackColor = System.Drawing.Color.Aqua
                    FechaNuevo.LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                    FechaNuevo.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat
                Else
                    FechaNuevo.LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
                    FechaNuevo.ItemBorder = Resco.Controls.DetailView.ItemBorder.Underline
                End If
                FechaNuevo.Format = oApp.FormatoFecha
                FechaNuevo.DateTimeStyle = Resco.Controls.DetailView.RescoDateTimePickerStyle.Date
                FechaNuevo.Name = pvNombre
                FechaNuevo.Label = pvTexto
                FechaNuevo.Height = PubcAlturaItemsDetailView * IIf(bEscalarDV, nFactorH, 1)
                FechaNuevo.Visible = (pvTipoVisible = ServicesCentral.TiposVisible.Visible)
                prDetailView.Items.Add(FechaNuevo)
        End Select
    End Sub

    Private Sub FormVerificacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not bEscalado Then
            [Global].ObtenerFactores(Me)
            [Global].EscalarFuente(Me)
            [Global].EscalarForma(Me)
            CrearItemDetailView(DetailViewDatosConexion, ServicesCentral.TiposControlDetalle.Texto, "TextBoxServidor", ServicesCentral.TiposEdicion.Editar, ServicesCentral.TiposVisible.Visible, "Server:", ServicesCentral.TiposAlineacion.Izquierda)
            CrearItemDetailView(DetailViewDatosConexion, ServicesCentral.TiposControlDetalle.Texto, "TextBoxUsuario", ServicesCentral.TiposEdicion.Editar, ServicesCentral.TiposVisible.Visible, "User:", ServicesCentral.TiposAlineacion.Izquierda)
            CrearItemDetailView(DetailViewDatosConexion, ServicesCentral.TiposControlDetalle.Texto, "TextBoxContrasena", ServicesCentral.TiposEdicion.Editar, ServicesCentral.TiposVisible.Visible, "Password:", ServicesCentral.TiposAlineacion.Izquierda, "*")
            CrearItemDetailView(DetailViewDatosConexion, ServicesCentral.TiposControlDetalle.Texto, "TextBoxServicio", ServicesCentral.TiposEdicion.Editar, ServicesCentral.TiposVisible.Visible, "Service:", ServicesCentral.TiposAlineacion.Izquierda)
            CrearItemDetailView(DetailViewDatosConexion, ServicesCentral.TiposControlDetalle.Combo, "ComboBoxTerminal", ServicesCentral.TiposEdicion.Editar, ServicesCentral.TiposVisible.Visible, "Terminal:", ServicesCentral.TiposAlineacion.Izquierda)
            CrearItemDetailView(DetailViewDatosConexion, ServicesCentral.TiposControlDetalle.Logico, "CheckBoxWireless", ServicesCentral.TiposEdicion.Editar, ServicesCentral.TiposVisible.Visible, "Wireless:", ServicesCentral.TiposAlineacion.Izquierda)
            bEscalado = True
        End If

        LlenarComboTerminal()
        ' Inicializar los controles con las variables
        DetailViewDatosConexion.Items("TextBoxServidor").Text = oApp.Servidor.Trim
        DetailViewDatosConexion.Items("TextBoxUsuario").Text = oApp.Usuario.Clave.Trim
        DetailViewDatosConexion.Items("TextBoxContrasena").Text = oApp.Contrasena.Trim
        DetailViewDatosConexion.Items("TextBoxServicio").Text = oApp.URL.Trim
        DetailViewDatosConexion.Items("ComboBoxTerminal").Value = oApp.ModeloTerminal.Trim
        CType(DetailViewDatosConexion.Items("CheckBoxWireless"), Resco.Controls.DetailView.ItemCheckBox).Checked = oApp.UsarWireless
        With DetailViewDatosConexion
            If .Items.Count > 0 Then
                .Items(0).SetFocus()
            Else
                ButtonConectar.Focus()
            End If
        End With
    End Sub

    Private Sub ButtonConectar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonConectar.Click
        Me.Refresh()
        oApp.Servidor = DetailViewDatosConexion.Items("TextBoxServidor").Text.Trim
        oApp.Usuario.Clave = DetailViewDatosConexion.Items("TextBoxUsuario").Text.Trim
        oApp.Contrasena = DetailViewDatosConexion.Items("TextBoxContrasena").Text.Trim
        oApp.URL = DetailViewDatosConexion.Items("TextBoxServicio").Text.Trim
        oApp.ModeloTerminal = DetailViewDatosConexion.Items("ComboBoxTerminal").Value
        oApp.UsarWireless = CType(DetailViewDatosConexion.Items("CheckBoxWireless"), Resco.Controls.DetailView.ItemCheckBox).Checked
        oApp.ContraseniaAseguramiento = "123"
        oApp.AseguramientoVisita = True
        'oApp.GuardarConfiguracion()
        Me.DialogResult = Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub ButtonSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSalir.Click
        ' Cancelar el diálogo y salir
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FormVerificacion_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        PanelConexion.Visible = False
        Me.Refresh()
    End Sub
End Class
