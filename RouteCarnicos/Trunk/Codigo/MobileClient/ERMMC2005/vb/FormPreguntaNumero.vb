Public Class FormPreguntaNumero
    Inherits System.Windows.Forms.Form
    Friend WithEvents MainMenuPregunta As System.Windows.Forms.MainMenu

#Region "Buttons ShortCuts"

    'Solo funciona para la SYMBOL
    Public Const BTN_CONTINUAR = 125
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonSalir As System.Windows.Forms.Button
    Private WithEvents DetailViewPregunta As Resco.Controls.DetailView.DetailView
    Private WithEvents DetailViewRespuesta As Resco.Controls.DetailView.DetailView
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
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

    Public Sub New(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String, ByRef paroEncuesta As cEncuesta, ByRef paroPregunta As cPreguntaNumero)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        oCliente = paroCliente
        sVisitaClave = parsVisitaClave
        oPregunta = paroPregunta
        oEncuesta = paroEncuesta
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        oCliente = Nothing
        oEncuesta = Nothing
        oPregunta = Nothing

        If Not Me.DetailViewPregunta Is Nothing Then
            Me.DetailViewPregunta.Items.Clear()
            Me.DetailViewPregunta.Dispose()
            Me.DetailViewPregunta = Nothing
        End If
        If Not Me.DetailViewRespuesta Is Nothing Then
            Me.DetailViewRespuesta.Items.Clear()
            Me.DetailViewRespuesta.Dispose()
            Me.DetailViewRespuesta = Nothing
        End If
        If Not Me.ButtonContinuar Is Nothing Then Me.ButtonContinuar.Dispose()
        If Not Me.ButtonRegresar Is Nothing Then Me.ButtonRegresar.Dispose()
        If Not Me.ButtonSalir Is Nothing Then Me.ButtonSalir.Dispose()

        If Not Me.MenuItemSalir Is Nothing Then Me.MenuItemSalir.Dispose()
        Me.MenuItemSalir = Nothing
        If Not Me.MainMenuPregunta Is Nothing Then Me.MainMenuPregunta.Dispose()
        Me.MainMenuPregunta = Nothing

        If Not Me.pcbIcono Is Nothing Then
            Me.pcbIcono.Image = Nothing
            Me.pcbIcono.Dispose()
            Me.pcbIcono = Nothing
        End If

        'Me.Events.Dispose()
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ItemTextBox1 As Resco.Controls.DetailView.ItemTextBox = New Resco.Controls.DetailView.ItemTextBox
        Me.MainMenuPregunta = New System.Windows.Forms.MainMenu
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pcbIcono = New System.Windows.Forms.PictureBox
        Me.ButtonSalir = New System.Windows.Forms.Button
        Me.DetailViewPregunta = New Resco.Controls.DetailView.DetailView
        Me.DetailViewRespuesta = New Resco.Controls.DetailView.DetailView
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonContinuar = New System.Windows.Forms.Button
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
        Me.Panel1.Controls.Add(Me.DetailViewPregunta)
        Me.Panel1.Controls.Add(Me.DetailViewRespuesta)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
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
        Me.ButtonSalir.TabIndex = 11
        Me.ButtonSalir.Text = "ButtonSalir"
        Me.ButtonSalir.Visible = False
        '
        'DetailViewPregunta
        '
        Me.DetailViewPregunta.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.DetailViewPregunta.ForeColor = System.Drawing.SystemColors.ControlText
        ItemTextBox1.Height = 134
        ItemTextBox1.ItemBorder = Resco.Controls.DetailView.ItemBorder.None
        ItemTextBox1.MultiLine = True
        ItemTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        ItemTextBox1.WordWrap = True
        Me.DetailViewPregunta.Items.Add(ItemTextBox1)
        Me.DetailViewPregunta.LabelWidth = 0
        Me.DetailViewPregunta.Location = New System.Drawing.Point(30, 8)
        Me.DetailViewPregunta.Name = "DetailViewPregunta"
        Me.DetailViewPregunta.SeparatorWidth = 6
        Me.DetailViewPregunta.Size = New System.Drawing.Size(198, 134)
        Me.DetailViewPregunta.TabIndex = 7
        '
        'DetailViewRespuesta
        '
        Me.DetailViewRespuesta.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.DetailViewRespuesta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DetailViewRespuesta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DetailViewRespuesta.LabelWidth = 0
        Me.DetailViewRespuesta.Location = New System.Drawing.Point(5, 148)
        Me.DetailViewRespuesta.Name = "DetailViewRespuesta"
        Me.DetailViewRespuesta.SeparatorWidth = 6
        Me.DetailViewRespuesta.Size = New System.Drawing.Size(224, 28)
        Me.DetailViewRespuesta.TabIndex = 8
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(5, 262)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresar.TabIndex = 9
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(80, 262)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuar.TabIndex = 10
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'MenuItemSalir
        '
        Me.MenuItemSalir.Text = "MenuItemSalir"
        '
        'FormPreguntaNumero
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
        Me.Name = "FormPreguntaNumero"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"
    Private oCliente As Cliente
    Private sVisitaClave As String
    Private refaVista As Vista
    Private oEncuesta As cEncuesta
    Private oPregunta As cPreguntaNumero
    Private bCargando As Boolean
#End Region

#Region "Forma"

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


    Private Sub FormPreguntaNumero_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Me.Mapeo_Teclas(e)
    End Sub

    Private Sub FormPreguntaNumero_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Application.DoEvents()
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        ' Recuperar los demás componentes de la forma
        If Not Vista.Buscar("FormPreguntaNumero", refaVista) Then
            Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If
        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)
        'Application.DoEvents()
        MostrarPregunta()
        Me.KeyPreview = True
        'HabilitarBotones(True)
        With DetailViewRespuesta
            If .Items.Count > 0 Then
                .Items(0).SetFocus()
            End If
        End With

        Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

#End Region

#Region "Eventos Controles"
    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        If ValidarRespuesta() Then
            HabilitarBotones(False)
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Me.DialogResult = Windows.Forms.DialogResult.Yes
        End If
    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        HabilitarBotones(False)
        Me.DialogResult = Windows.Forms.DialogResult.No
    End Sub

    Private Function ValidarRespuesta() As Boolean
        With DetailViewRespuesta
            If .Items.Count > 0 Then
                If Not .Items(0).Value Is Nothing Then
                    Try
                        .Items(0).Value = Double.Parse(.Items(0).Value)
                    Catch ex As Exception
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0553"), MsgBoxStyle.Critical, refaVista.BuscarMensaje("MsgBox", "XMensajeE"))
                        .Items(0).SetFocus()
                        Return False
                    End Try
                End If
            End If
        End With
        Return True
    End Function
#End Region

    Public Sub MostrarPregunta()
        Dim oItemResp As New Resco.Controls.DetailView.ItemTextBox
        bCargando = True
        Me.DetailViewPregunta.Items(0).Text = oPregunta.Descripcion
        Me.DetailViewPregunta.Items(0).TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
        Me.DetailViewPregunta.Items(0).Height = DetailViewPregunta.Height

        oItemResp.DisplayFormat = ""
        oItemResp.Style = Resco.Controls.DetailView.RescoItemStyle.LabelLeft
        oItemResp.LabelAlignment = HorizontalAlignment.Left
        oItemResp.LabelWidth = 0
        If oPregunta.Formato <> String.Empty Then
            oItemResp.DisplayFormat = oPregunta.PrefijoFormato & "{0:" & oPregunta.FormatoNumerico & "}" & oPregunta.SufijoFormato
        End If
        If Not oPregunta.Respuesta Is Nothing Then
            oItemResp.Value = Double.Parse(oPregunta.Respuesta)
        End If
        oItemResp.TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
        oItemResp.Height = DetailViewRespuesta.Height
        oItemResp.Enabled = True
        Me.DetailViewRespuesta.Items.Add(oItemResp)

        'Me.DetailViewRespuesta.Items(0).SetFocus()     

        Me.pcbIcono.Image = oEncuesta.ObtenerIcono()
        bCargando = False
        Me.ButtonRegresar.Enabled = Not (oEncuesta.Preguntas.bPrimerPregunta)
        Me.MenuItemSalir.Enabled = oEncuesta.HabilitarSalir
    End Sub

    Private Sub FormPreguntaNumero_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            If Me.DialogResult = Windows.Forms.DialogResult.Yes Then
                Dim bCont As Boolean = True
                Try
                    Dim nValor As Double = Double.Parse(CType(Me.DetailViewRespuesta.Items(0), Resco.Controls.DetailView.ItemTextBox).Value)
                    If oPregunta.Formato <> "" Then
                        nValor = Double.Parse(Format(nValor, oPregunta.FormatoNumerico))
                    End If
                    oPregunta.Respuesta = nValor
                Catch ex As Exception
                    oPregunta.Respuesta = Nothing
                End Try
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
                Else
                    MsgBox(refaVista.BuscarMensaje("MsgBox", ex.sCVEMensaje), MsgBoxStyle.Critical, refaVista.BuscarMensaje("MsgBox", "XMensajeE"))
                End If
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

    Private Sub ButtonSalir_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSalir.Click, MenuItemSalir.Click
        HabilitarBotones(False)
        oEncuesta.EstadoFin = cEncuesta.EstadoFinalizar.ParcialmenteAplicada
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub DetailViewRespuesta_ItemLostFocus(ByVal sender As Object, ByVal e As Resco.Controls.DetailView.ItemEventArgs) Handles DetailViewRespuesta.ItemLostFocus
        If Not e.item.Value Is Nothing Then
            If Not IsNumeric(e.item.Value) Then
                MsgBox(refaVista.BuscarMensaje("MsgBox", "E0553"), MsgBoxStyle.Critical, refaVista.BuscarMensaje("MsgBox", "XMensajeE"))
                Exit Sub
            End If
            Try
                e.item.Value = Double.Parse(e.item.Value)
            Catch ex As Exception
                MsgBox(refaVista.BuscarMensaje("MsgBox", "E0553"), MsgBoxStyle.Critical, refaVista.BuscarMensaje("MsgBox", "XMensajeE"))
                e.item.SetFocus()
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub DetailViewRespuesta_ItemValidating(ByVal sender As Object, ByVal e As Resco.Controls.DetailView.ValidatingEventArgs) Handles DetailViewRespuesta.ItemValidating
        If Not e.NewValue Is Nothing Then
            If Not IsNumeric(e.NewValue) Then
                MsgBox(refaVista.BuscarMensaje("MsgBox", "E0553"), MsgBoxStyle.Critical, refaVista.BuscarMensaje("MsgBox", "XMensajeE"))
                e.Cancel = True
            End If
        End If
    End Sub

End Class
