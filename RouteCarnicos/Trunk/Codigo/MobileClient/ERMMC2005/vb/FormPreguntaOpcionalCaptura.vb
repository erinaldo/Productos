Public Class FormPreguntaOpcionalCaptura
    Inherits System.Windows.Forms.Form
    Friend WithEvents MainMenuPregunta As System.Windows.Forms.MainMenu

#Region "Buttons ShortCuts"

    'Solo funciona para la SYMBOL
    Public Const BTN_CONTINUAR = 125  'SoftKey 1 (Tecla de un punto verde)
    Public Const BTN_BACK = 126
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonSalir As System.Windows.Forms.Button
    Private WithEvents DetailViewPregunta As Resco.Controls.DetailView.DetailView
    Private WithEvents DetailViewOpciones As Resco.Controls.DetailView.DetailView
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents pcbIcono As System.Windows.Forms.PictureBox
    Friend WithEvents MenuTooltip As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemSalir As System.Windows.Forms.MenuItem
    'SoftKey 2 (Tecla de un punto rojo)
    Public Const BTN_TAB = 10

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

    Public Sub New(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String, ByRef paroEncuesta As cEncuesta, ByRef paroPregunta As cPreguntaOpcional)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        'If g_SO = SO.WindowsCE Then
        '    Call InTheHand.Windows.Forms.ContextMenuHelper.HookAllControls(Me.Controls)
        'End If
        oCliente = paroCliente
        sVisitaClave = parsVisitaClave
        oPregunta = paroPregunta
        oEncuesta = paroEncuesta
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        oCliente = Nothing
        oEncuesta = Nothing
        oPregunta = Nothing
        If Not MenuItemSalir Is Nothing Then Me.MenuItemSalir.Dispose()
        If Not Me.MainMenuPregunta Is Nothing Then Me.MainMenuPregunta.Dispose()
        If Not Me.MenuTooltip Is Nothing Then Me.MenuTooltip.Dispose()
        If Not Me.DetailViewOpciones Is Nothing Then
            Me.DetailViewOpciones.Items.Clear()
            Me.DetailViewOpciones.Dispose()
            Me.DetailViewOpciones = Nothing
        End If
        If Not Me.DetailViewPregunta Is Nothing Then
            Me.DetailViewPregunta.Items.Clear()
            Me.DetailViewPregunta.Dispose()
            Me.DetailViewPregunta = Nothing
        End If
        If Not Me.pcbIcono Is Nothing Then
            Me.pcbIcono.Image = Nothing
            Me.pcbIcono.Dispose()
            Me.pcbIcono = Nothing
        End If
        Me.Events.Dispose()
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ItemTextBox1 As Resco.Controls.DetailView.ItemTextBox = New Resco.Controls.DetailView.ItemTextBox
        Me.MainMenuPregunta = New System.Windows.Forms.MainMenu
        Me.MenuItemSalir = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pcbIcono = New System.Windows.Forms.PictureBox
        Me.ButtonSalir = New System.Windows.Forms.Button
        Me.DetailViewPregunta = New Resco.Controls.DetailView.DetailView
        Me.DetailViewOpciones = New Resco.Controls.DetailView.DetailView
        Me.MenuTooltip = New System.Windows.Forms.ContextMenu
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenuPregunta
        '
        Me.MainMenuPregunta.MenuItems.Add(Me.MenuItemSalir)
        '
        'MenuItemSalir
        '
        Me.MenuItemSalir.Text = "MenuItemSalir"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pcbIcono)
        Me.Panel1.Controls.Add(Me.ButtonSalir)
        Me.Panel1.Controls.Add(Me.DetailViewPregunta)
        Me.Panel1.Controls.Add(Me.DetailViewOpciones)
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
        Me.ButtonSalir.TabIndex = 10
        Me.ButtonSalir.Text = "ButtonSalir"
        Me.ButtonSalir.Visible = False
        '
        'DetailViewPregunta
        '
        Me.DetailViewPregunta.ForeColor = System.Drawing.SystemColors.ControlText
        ItemTextBox1.Height = 56
        ItemTextBox1.ItemBorder = Resco.Controls.DetailView.ItemBorder.None
        ItemTextBox1.MultiLine = True
        ItemTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        ItemTextBox1.WordWrap = True
        Me.DetailViewPregunta.Items.Add(ItemTextBox1)
        Me.DetailViewPregunta.LabelWidth = 0
        Me.DetailViewPregunta.Location = New System.Drawing.Point(30, 8)
        Me.DetailViewPregunta.Name = "DetailViewPregunta"
        Me.DetailViewPregunta.SeparatorWidth = 6
        Me.DetailViewPregunta.Size = New System.Drawing.Size(198, 56)
        Me.DetailViewPregunta.TabIndex = 6
        '
        'DetailViewOpciones
        '
        Me.DetailViewOpciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DetailViewOpciones.ContextMenu = Me.MenuTooltip
        Me.DetailViewOpciones.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DetailViewOpciones.LabelWidth = 0
        Me.DetailViewOpciones.Location = New System.Drawing.Point(5, 68)
        Me.DetailViewOpciones.Name = "DetailViewOpciones"
        Me.DetailViewOpciones.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.TabStrip
        Me.DetailViewOpciones.SeparatorWidth = 6
        Me.DetailViewOpciones.Size = New System.Drawing.Size(224, 192)
        Me.DetailViewOpciones.TabIndex = 7
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Enabled = False
        Me.ButtonRegresar.Location = New System.Drawing.Point(5, 262)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresar.TabIndex = 8
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(80, 262)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuar.TabIndex = 9
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'FormPreguntaOpcionalCaptura
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
        Me.Name = "FormPreguntaOpcionalCaptura"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"
    Private oCliente As Cliente
    Private sVisitaClave As String
    Private oPregunta As cPreguntaOpcional
    Private oEncuesta As cEncuesta
    Private refaVista As Vista
    Private bCargando As Boolean
    Private bAgregarDiag As Boolean
#End Region

#Region "Forma"

    Private Sub FormPreguntaOpcionalCaptura_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Mapeo_Teclas(e)
    End Sub

    Private Sub FormPreguntaOpcionalCaptura_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Application.DoEvents()

        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)

        ' Recuperar los demás componentes de la forma
        If Not Vista.Buscar("FormPreguntaOpcionalCaptura", refaVista) Then
            Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If
        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)
        'Application.DoEvents()
        MostrarPregunta()

        Me.KeyPreview = True
        'Me.HabilitarBotones(True)

        If Me.DetailViewOpciones.Items.All.Length > 0 Then
            Me.DetailViewOpciones.SelectedItem = Me.DetailViewOpciones.Items(0)
        End If
        Resco.Controls.DetailView.DetailView.KeyNavigation = True
        With DetailViewOpciones
            If .Items.Count > 0 Then
                .Items(0).SetFocus()
            End If
        End With
        Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

#End Region

#Region "Eventos Controles"
    Private Sub ButtonRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        HabilitarBotones(False)
        Me.DialogResult = Windows.Forms.DialogResult.No
    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        If ValidarRespuesta() Then
            HabilitarBotones(False)
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Me.DialogResult = Windows.Forms.DialogResult.Yes
        End If
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

        LlenarOpciones()
        Me.pcbIcono.Image = oEncuesta.ObtenerIcono()
        Me.DetailViewOpciones.Focus()
        bCargando = False
        Me.ButtonRegresar.Enabled = Not (oEncuesta.Preguntas.bPrimerPregunta)
        Me.MenuItemSalir.Enabled = oEncuesta.HabilitarSalir
    End Sub

    'Private Sub LlenarOpciones()
    '    For Each drOpc As DataRow In oPregunta.Opciones.Rows
    '        Dim oItem As Resco.Controls.DetailView.Item
    '        If oPregunta.TipoSeleccion = 2 Then 'Texto
    '            oItem = New Resco.Controls.DetailView.ItemTextBox
    '            If oPregunta.TipoLimite = 2 Then
    '                CType(oItem, Resco.Controls.DetailView.ItemTextBox).MaxLength = oPregunta.Maximo
    '            End If
    '        Else
    '            oItem = New Resco.Controls.DetailView.ItemNumeric
    '            CType(oItem, Resco.Controls.DetailView.ItemNumeric).Increment = 10
    '            If oPregunta.TipoLimite = 2 Then
    '                CType(oItem, Resco.Controls.DetailView.ItemNumeric).Minimum = oPregunta.Minimo
    '                CType(oItem, Resco.Controls.DetailView.ItemNumeric).Maximum = oPregunta.Maximo
    '            Else
    '                CType(oItem, Resco.Controls.DetailView.ItemNumeric).Minimum = Decimal.MinValue
    '                CType(oItem, Resco.Controls.DetailView.ItemNumeric).Maximum = Decimal.MaxValue
    '            End If
    '        End If

    '        oItem.Style = Resco.Controls.DetailView.RescoItemStyle.LabelLeft
    '        oItem.LabelAlignment = HorizontalAlignment.Left
    '        If oPregunta.TipoSeleccion = 2 Then 'Texto
    '            oItem.LabelWidth = 80
    '        Else 'Numero
    '            oItem.LabelWidth = 160
    '        End If
    '        oItem.LabelFont = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
    '        oItem.Label = drOpc("Descripcion")
    '        oItem.TextFont = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular)
    '        oItem.Enabled = True
    '        oItem.Tag = drOpc("COOId")
    '        Me.DetailViewOpciones.Items.Add(oItem)
    '        If oPregunta.Respuestas.Contains(oItem.Tag) Then
    '            oItem.Value = oPregunta.Respuestas(oItem.Tag)
    '        Else
    '            If oPregunta.TipoSeleccion = 3 Then 'Texto
    '                oItem.Value = Nothing
    '            End If
    '        End If
    '    Next
    'End Sub

    Private Sub LlenarOpciones()
        For Each drOpc As DataRow In oPregunta.Opciones.Rows
            Dim oItem As New Resco.Controls.DetailView.ItemTextBox
            If oPregunta.TipoSeleccion = 2 Then 'Texto
                If oPregunta.TipoLimite1 = 2 Then
                    oItem.MaxLength = oPregunta.Maximo1
                End If
            End If

            oItem.DisplayFormat = ""

            oItem.Style = Resco.Controls.DetailView.RescoItemStyle.LabelLeft
            oItem.LabelAlignment = HorizontalAlignment.Left
            If oPregunta.TipoSeleccion = 2 Then 'Texto
                oItem.LabelWidth = 120
            Else 'Numero
                oItem.LabelWidth = 160
                If oPregunta.Formato <> String.Empty Then
                    oItem.DisplayFormat = oPregunta.PrefijoFormato & "{0:" & oPregunta.FormatoNumerico & "}" & oPregunta.SufijoFormato
                End If
            End If
            oItem.LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
            oItem.Label = drOpc("Descripcion")
            oItem.TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
            oItem.Enabled = True
            oItem.Tag = drOpc("COOId")
            Me.DetailViewOpciones.Items.Add(oItem)
            If oPregunta.Respuestas.Contains(oItem.Tag) Then
                oItem.Value = oPregunta.Respuestas(oItem.Tag)
            End If
        Next
    End Sub

    Private Function ValidarRespuesta() As Boolean
        If oPregunta.TipoSeleccion = 3 Then
            With DetailViewOpciones
                If .Items.Count > 0 Then
                    For Each oItem As Resco.Controls.DetailView.Item In DetailViewOpciones.Items
                        If Not oItem.Value Is Nothing Then
                            Try
                                oItem.Value = Double.Parse(oItem.Value)
                            Catch ex As Exception
                                MsgBox(refaVista.BuscarMensaje("MsgBox", "E0553"), MsgBoxStyle.Critical, refaVista.BuscarMensaje("MsgBox", "XMensajeE"))
                                oItem.SetFocus()
                                Return False
                            End Try
                        End If
                    Next
                End If
            End With
        End If
        Return True
    End Function

    Private Sub FormPreguntaOpcionalCaptura_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            If Me.DialogResult = Windows.Forms.DialogResult.Yes Then
                Dim bCont As Boolean = True
                oPregunta.ValidarRespuesta()
                If oPregunta.Confirmacion Then
                    bCont = (MsgBox(refaVista.BuscarMensaje("MsgBox", "P0049"), MsgBoxStyle.YesNo, refaVista.BuscarMensaje("MsgBox", "XMensajeP")) = MsgBoxResult.Yes)
                End If
                If bCont Then
                    oPregunta.ClienteClave = oCliente.ClienteClave
                    oEncuesta.Preguntas.PreguntaActual.Insertar(oEncuesta.ENCId, oEncuesta.Preguntas.nOrdenActual, 1)
                    oEncuesta.Preguntas.PuntosNvo += CType(oEncuesta.Preguntas.PreguntaActual, cPreguntaOpcional).PuntosNvo
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
                If ex.sCVEMensaje = "E0311" Then
                    MsgBox(SustituirValoresMensaje(refaVista.BuscarMensaje("MsgBox", ex.sCVEMensaje), New String() {oPregunta.Minimo, oPregunta.Maximo}), MsgBoxStyle.Critical, refaVista.BuscarMensaje("MsgBox", "XMensajeE"))
                ElseIf ex.sCVEMensaje = "E0309" Then
                    MsgBox(SustituirValoresMensaje(refaVista.BuscarMensaje("MsgBox", ex.sCVEMensaje), New String() {oPregunta.Minimo1, oPregunta.Maximo1}), MsgBoxStyle.Critical, refaVista.BuscarMensaje("MsgBox", "XMensajeE"))
                ElseIf ex.sCVEMensaje = "E0554" Then
                    MsgBox(SustituirValoresMensaje(refaVista.BuscarMensaje("MsgBox", ex.sCVEMensaje), New String() {oPregunta.Formato}), MsgBoxStyle.Critical, refaVista.BuscarMensaje("MsgBox", "XMensajeE"))
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

    Private Sub ButtonSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSalir.Click, MenuItemSalir.Click
        HabilitarBotones(False)
        oEncuesta.EstadoFin = cEncuesta.EstadoFinalizar.ParcialmenteAplicada
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub


    Private Sub DetailViewOpciones_ItemChanged(ByVal sender As Object, ByVal e As Resco.Controls.DetailView.ItemEventArgs) Handles DetailViewOpciones.ItemChanged
        If bAgregarDiag Then
            e.item.Value &= "/"
        End If
    End Sub

    Private Sub DetailViewOpciones_ItemLostFocus(ByVal sender As Object, ByVal e As Resco.Controls.DetailView.ItemEventArgs) Handles DetailViewOpciones.ItemLostFocus
        Dim sError As String
        Try
            If oPregunta.TipoSeleccion = 2 Then
                If e.item.Text <> "" Then
                    oPregunta.AgregarOpcion(e.item.Tag, e.item.Text)
                Else
                    oPregunta.EliminarOpcion(e.item.Tag)
                End If
            Else
                If IsNumeric(e.item.Value) Then
                    Try
                        e.item.Value = Format(Double.Parse(e.item.Value), oPregunta.FormatoNumerico)
                        oPregunta.AgregarOpcion(e.item.Tag, Double.Parse(e.item.Value))
                    Catch ex As Exception
                        sError = refaVista.BuscarMensaje("MsgBox", "E0553")
                        MsgBox(sError, MsgBoxStyle.Critical, refaVista.BuscarMensaje("MsgBox", "XMensajeE"))
                        e.item.ErrorMessage = sError
                        oPregunta.EliminarOpcion(e.item.Tag)
                        e.item.SetFocus()
                        Exit Sub
                    End Try
                Else
                    oPregunta.EliminarOpcion(e.item.Tag)
                End If
            End If
            e.item.ErrorMessage = ""
        Catch ex As CEstado
            If ex.sCVEMensaje = "E0309" Then
                sError = SustituirValoresMensaje(refaVista.BuscarMensaje("MsgBox", ex.sCVEMensaje), New String() {oPregunta.Minimo1, oPregunta.Maximo1})
            ElseIf ex.sCVEMensaje = "E0554" Then
                sError = SustituirValoresMensaje(refaVista.BuscarMensaje("MsgBox", ex.sCVEMensaje), New String() {oPregunta.Formato})
            Else
                sError = refaVista.BuscarMensaje("MsgBox", ex.sCVEMensaje)
            End If
            MsgBox(sError, MsgBoxStyle.Critical, refaVista.BuscarMensaje("MsgBox", "XMensajeE"))
            e.item.ErrorMessage = sError
        End Try
    End Sub

    Private Sub DetailViewOpciones_ItemValidating(ByVal sender As Object, ByVal e As Resco.Controls.DetailView.ValidatingEventArgs) Handles DetailViewOpciones.ItemValidating
        If oPregunta.TipoSeleccion = 3 Then 'Numerico
            If Not e.NewValue Is Nothing Then
                If Not IsNumeric(e.NewValue) Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0553"), MsgBoxStyle.Critical, refaVista.BuscarMensaje("MsgBox", "XMensajeE"))
                    e.Cancel = True
                End If
            End If
        ElseIf oPregunta.TipoConversion = 4 Then 'Fecha
            Dim sValor As String = ""
            Dim sAnterior As String = ""
            If Not e.NewValue Is Nothing Then
                sValor = e.NewValue.ToString
            End If
            If Not e.OldValue Is Nothing Then
                sAnterior = e.OldValue.ToString
            End If
            bAgregarDiag = ((sValor.Length = 2 Or sValor.Length = 5) And sValor.Length > sAnterior.Length)
        End If
    End Sub

    Private Sub DetailViewOpciones_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DetailViewOpciones.MouseDown
        Try
            Dim oPoint As New System.Drawing.Point(e.X, e.Y)
            Dim oItem As Resco.Controls.DetailView.Item
            If Not CType(sender, Resco.Controls.DetailView.DetailView).GetItemAtPoint(oPoint) Is Nothing Then
                oItem = CType(sender, Resco.Controls.DetailView.DetailView).GetItemAtPoint(oPoint).item
                LlenarMenuToolTip(CType(oItem, Resco.Controls.DetailView.ItemTextBox).Label)
            Else
                MenuTooltip.MenuItems.Clear()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarMenuToolTip(ByVal pvMensaje As String)
        Dim mnItem As System.Windows.Forms.MenuItem = New System.Windows.Forms.MenuItem()
        mnItem.Text = pvMensaje
        mnItem.Enabled = True

        MenuTooltip.MenuItems.Clear()
        MenuTooltip.MenuItems.Add(mnItem)
    End Sub

End Class
