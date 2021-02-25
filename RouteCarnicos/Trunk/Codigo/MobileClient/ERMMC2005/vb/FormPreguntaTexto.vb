Public Class FormPreguntaTexto
    Inherits System.Windows.Forms.Form
    Friend WithEvents MainMenuPregunta As System.Windows.Forms.MainMenu

#Region "Buttons ShortCuts"

    'Solo funciona para la SYMBOL
    Public Const BTN_CONTINUAR = 125
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonSalir As System.Windows.Forms.Button
    Private WithEvents DetailViewRespuesta As Resco.Controls.DetailView.DetailView
    Private WithEvents DetailViewPregunta As Resco.Controls.DetailView.DetailView
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents LabelMascara As System.Windows.Forms.Label
    Friend WithEvents TextBoxRespuesta As System.Windows.Forms.TextBox
    Friend WithEvents pcbIcono As System.Windows.Forms.PictureBox
    Friend WithEvents MenuItemSalir As System.Windows.Forms.MenuItem
    'SoftKey 1 (Tecla de un punto verde)
    Public Const BTN_BACK = 126       'SoftKey 2 (Tecla de un punto rojo)

    Private Sub Mapeo_Teclas(ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case BTN_CONTINUAR
                ButtonContinuar_Click(Me, Nothing)
            Case BTN_BACK
                ButtonRegresar_Click(Me, Nothing)
        End Select
    End Sub

#End Region

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String, ByRef paroEncuesta As cEncuesta, ByRef paroPregunta As cPreguntaTexto)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        oCliente = paroCliente
        sVisitaClave = parsVisitaClave
        oEncuesta = paroEncuesta
        oPregunta = paroPregunta
        Me.HabilitarBotones(False)
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        oCliente = Nothing
        oEncuesta = Nothing
        oPregunta = Nothing
        If Not Me.MenuItemSalir Is Nothing Then Me.MenuItemSalir.Dispose()
        If Not Me.MainMenuPregunta Is Nothing Then Me.MainMenuPregunta.Dispose()
        If Not Me.pcbIcono Is Nothing Then
            Me.pcbIcono.Image = Nothing
            Me.pcbIcono.Dispose()
            Me.pcbIcono = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ItemDateTime2 As Resco.Controls.DetailView.ItemDateTime = New Resco.Controls.DetailView.ItemDateTime
        Dim ItemTextBox2 As Resco.Controls.DetailView.ItemTextBox = New Resco.Controls.DetailView.ItemTextBox
        Me.MainMenuPregunta = New System.Windows.Forms.MainMenu
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pcbIcono = New System.Windows.Forms.PictureBox
        Me.ButtonSalir = New System.Windows.Forms.Button
        Me.DetailViewRespuesta = New Resco.Controls.DetailView.DetailView
        Me.DetailViewPregunta = New Resco.Controls.DetailView.DetailView
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.LabelMascara = New System.Windows.Forms.Label
        Me.TextBoxRespuesta = New System.Windows.Forms.TextBox
        Me.MenuItemSalir = New System.Windows.Forms.MenuItem
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenuPregunta
        '
        Me.MainMenuPregunta.MenuItems.Add(Me.MenuItemSalir)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pcbIcono)
        Me.Panel1.Controls.Add(Me.ButtonSalir)
        Me.Panel1.Controls.Add(Me.DetailViewRespuesta)
        Me.Panel1.Controls.Add(Me.DetailViewPregunta)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
        Me.Panel1.Controls.Add(Me.LabelMascara)
        Me.Panel1.Controls.Add(Me.TextBoxRespuesta)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'pcbIcono
        '
        Me.pcbIcono.Location = New System.Drawing.Point(5, 8)
        Me.pcbIcono.Name = "pcbIcono"
        Me.pcbIcono.Size = New System.Drawing.Size(24, 24)
        Me.pcbIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'ButtonSalir
        '
        Me.ButtonSalir.Location = New System.Drawing.Point(155, 262)
        Me.ButtonSalir.Name = "ButtonSalir"
        Me.ButtonSalir.Size = New System.Drawing.Size(74, 24)
        Me.ButtonSalir.TabIndex = 13
        Me.ButtonSalir.Text = "ButtonSalir"
        Me.ButtonSalir.Visible = False
        '
        'DetailViewRespuesta
        '
        Me.DetailViewRespuesta.ForeColor = System.Drawing.SystemColors.ControlText
        ItemDateTime2.DateTimeStyle = Resco.Controls.DetailView.RescoDateTimePickerStyle.[Date]
        ItemDateTime2.Height = 20
        ItemDateTime2.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat
        ItemDateTime2.NoneText = ""
        Me.DetailViewRespuesta.Items.Add(ItemDateTime2)
        Me.DetailViewRespuesta.LabelWidth = 0
        Me.DetailViewRespuesta.Location = New System.Drawing.Point(51, 133)
        Me.DetailViewRespuesta.Name = "DetailViewRespuesta"
        Me.DetailViewRespuesta.SeparatorWidth = 6
        Me.DetailViewRespuesta.Size = New System.Drawing.Size(136, 24)
        Me.DetailViewRespuesta.TabIndex = 8
        '
        'DetailViewPregunta
        '
        Me.DetailViewPregunta.ForeColor = System.Drawing.SystemColors.ControlText
        ItemTextBox2.Height = 92
        ItemTextBox2.ItemBorder = Resco.Controls.DetailView.ItemBorder.None
        ItemTextBox2.MultiLine = True
        ItemTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        ItemTextBox2.WordWrap = True
        Me.DetailViewPregunta.Items.Add(ItemTextBox2)
        Me.DetailViewPregunta.LabelWidth = 0
        Me.DetailViewPregunta.Location = New System.Drawing.Point(30, 8)
        Me.DetailViewPregunta.Name = "DetailViewPregunta"
        Me.DetailViewPregunta.SeparatorWidth = 6
        Me.DetailViewPregunta.Size = New System.Drawing.Size(198, 100)
        Me.DetailViewPregunta.TabIndex = 6
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(5, 262)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresar.TabIndex = 10
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(80, 262)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuar.TabIndex = 11
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'LabelMascara
        '
        Me.LabelMascara.Location = New System.Drawing.Point(80, 214)
        Me.LabelMascara.Name = "LabelMascara"
        Me.LabelMascara.Size = New System.Drawing.Size(88, 16)
        Me.LabelMascara.Text = "LabelMascara"
        Me.LabelMascara.Visible = False
        '
        'TextBoxRespuesta
        '
        Me.TextBoxRespuesta.Location = New System.Drawing.Point(5, 114)
        Me.TextBoxRespuesta.MaxLength = 100
        Me.TextBoxRespuesta.Multiline = True
        Me.TextBoxRespuesta.Name = "TextBoxRespuesta"
        Me.TextBoxRespuesta.Size = New System.Drawing.Size(224, 75)
        Me.TextBoxRespuesta.TabIndex = 12
        '
        'MenuItemSalir
        '
        Me.MenuItemSalir.Text = "MenuItemSalir"
        '
        'FormPreguntaTexto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuPregunta
        Me.MinimizeBox = False
        Me.Name = "FormPreguntaTexto"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"
    Private oCliente As Cliente
    Private sVisitaClave As String
    Private oEncuesta As cEncuesta
    Private oPregunta As cPreguntaTexto
    Private refaVista As Vista
    Private bCargando As Boolean
#End Region

#Region "Forma"

    Private Sub FormPreguntaTexto_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Mapeo_Teclas(e)
    End Sub
    Private Sub FormPreguntaTexto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Application.DoEvents()

            [Global].ObtenerFactores(Me)
            [Global].EscalarFuente(Me)
            [Global].EscalarForma(Me)
            ' Recuperar los demás componentes de la forma
            If Not Vista.Buscar("FormPreguntaTexto", refaVista) Then
                Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If
            ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
            refaVista.ColocarEtiquetasForma(Me)
            'Application.DoEvents()
            MostrarPregunta()
            'Me.KeyPreview = True
            Me.HabilitarBotones(True)
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

        Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
#End Region

#Region "Eventos Controles"
    Private Sub ButtonRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        HabilitarBotones(False)
        Me.DialogResult = Windows.Forms.DialogResult.No
        'Me.Close()
    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        HabilitarBotones(False)
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Me.DialogResult = Windows.Forms.DialogResult.Yes
    End Sub

    Private Sub MenuItemSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        HabilitarBotones(False)
        oEncuesta.EstadoFin = cEncuesta.EstadoFinalizar.ParcialmenteAplicada
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

#End Region

    Private Sub HabilitarBotones(ByVal bHabilitar As Boolean)
        ButtonContinuar.Enabled = bHabilitar
        MenuItemSalir.Enabled = bHabilitar And oEncuesta.HabilitarSalir
        If bHabilitar Then
            ButtonRegresar.Enabled = (bHabilitar And Not (oEncuesta.Preguntas.bPrimerPregunta))
        Else
            ButtonRegresar.Enabled = bHabilitar
        End If
        ButtonSalir.Enabled = bHabilitar
    End Sub


    Public Sub MostrarPregunta()
        bCargando = True
        Me.DetailViewPregunta.Items(0).Text = oPregunta.Descripcion
        Me.DetailViewPregunta.Items(0).TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
        Me.DetailViewPregunta.Items(0).Height = DetailViewPregunta.Height
        Me.DetailViewRespuesta.Items(0).TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
        Me.DetailViewRespuesta.Items(0).Height = DetailViewRespuesta.Height

        If oPregunta.TipoConversion = 4 Then 'Fecha
            Me.DetailViewRespuesta.Visible = True
            Me.TextBoxRespuesta.Visible = False
        Else
            Me.TextBoxRespuesta.Visible = True
            Me.DetailViewRespuesta.Visible = False
        End If
        If oPregunta.TipoLimite = 2 Then 'Validar limites
            Me.TextBoxRespuesta.MaxLength = oPregunta.Maximo
        End If
        If oPregunta.TipoConversion = 4 Then 'Fecha
            Me.DetailViewRespuesta.Items(0).Value = oPregunta.Respuesta
            Me.DetailViewRespuesta.Items(0).SetFocus()
        Else
            Me.TextBoxRespuesta.Text = oPregunta.Respuesta
            Me.TextBoxRespuesta.Focus()
        End If
        Me.pcbIcono.Image = oEncuesta.ObtenerIcono()
        bCargando = False
        Me.ButtonRegresar.Enabled = Not (oEncuesta.Preguntas.bPrimerPregunta)
        Me.MenuItemSalir.Enabled = oEncuesta.HabilitarSalir
    End Sub

    Private Sub FormPreguntaTexto_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            If Me.DialogResult = Windows.Forms.DialogResult.Yes Then
                Dim bCont As Boolean = True
                If oPregunta.TipoConversion = 4 Then 'Fecha
                    oPregunta.Respuesta = Me.DetailViewRespuesta.Items(0).Value
                Else
                    oPregunta.Respuesta = Me.TextBoxRespuesta.Text
                End If
                oPregunta.ValidarRespuesta()
                If oPregunta.Confirmacion Then
                    bCont = (MsgBox(refaVista.BuscarMensaje("MsgBox", "P0049"), MsgBoxStyle.YesNo, refaVista.BuscarMensaje("MsgBox", "XMensajeP")) = MsgBoxResult.Yes)
                End If
                If bCont Then
                    oEncuesta.Preguntas.PreguntaActual.Insertar(oEncuesta.ENCId, oEncuesta.Preguntas.nOrdenActual, 1)
                    oEncuesta.Preguntas.SiguientePregunta()
                Else
                    Cursor.Current = Cursors.Default
                    e.Cancel = True
                    HabilitarBotones(True)
                End If
            ElseIf Me.DialogResult = Windows.Forms.DialogResult.No Or Me.DialogResult = Windows.Forms.DialogResult.Cancel Then
                oEncuesta.Preguntas.AnteriorPregunta()
            End If
        Catch ex As CEstado
            Cursor.Current = Cursors.Default
            If Not oEncuesta.Preguntas.bFinEncuesta Then
                If ex.sCVEMensaje = "E0309" Then
                    MsgBox(SustituirValoresMensaje(refaVista.BuscarMensaje("MsgBox", ex.sCVEMensaje), New String() {oPregunta.Minimo, oPregunta.Maximo}), MsgBoxStyle.Critical, refaVista.BuscarMensaje("MsgBox", "XMensajeE"))
                ElseIf ex.sCVEMensaje = "E0554" Then
                    MsgBox(SustituirValoresMensaje(refaVista.BuscarMensaje("MsgBox", ex.sCVEMensaje), New String() {oPregunta.Mascara}), MsgBoxStyle.Critical, refaVista.BuscarMensaje("MsgBox", "XMensajeE"))
                Else
                    MsgBox(refaVista.BuscarMensaje("MsgBox", ex.sCVEMensaje), MsgBoxStyle.Critical, refaVista.BuscarMensaje("MsgBox", "XMensajeE"))
                End If
                TextBoxRespuesta.Focus()
                e.Cancel = True
                HabilitarBotones(True)
            End If
        End Try
    End Sub

    Private Sub DetailViewPregunta_ItemValidating(ByVal sender As Object, ByVal e As Resco.Controls.DetailView.ValidatingEventArgs) Handles DetailViewPregunta.ItemValidating
        If Not bCargando Then
            e.Cancel = True
        End If
    End Sub

    Private Sub ButtonSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSalir.Click, MenuItemSalir.Click
        HabilitarBotones(False)
        oEncuesta.EstadoFin = cEncuesta.EstadoFinalizar.ParcialmenteAplicada
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub TextBoxRespuesta_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBoxRespuesta.Validating
        Try
            Dim sValor As String = TextBoxRespuesta.Text
            If sValor <> "" Then
                oPregunta.ValidarFormatoTexto(sValor)
                TextBoxRespuesta.Text = sValor
            End If
        Catch ex As CEstado
            If ex.sCVEMensaje = "E0554" Then
                Dim sError As String = SustituirValoresMensaje(refaVista.BuscarMensaje("MsgBox", ex.sCVEMensaje), New String() {oPregunta.Mascara})
                MsgBox(sError, MsgBoxStyle.Critical, refaVista.BuscarMensaje("MsgBox", "XMensajeE"))
                e.Cancel = True
            End If
        End Try
    End Sub
End Class
