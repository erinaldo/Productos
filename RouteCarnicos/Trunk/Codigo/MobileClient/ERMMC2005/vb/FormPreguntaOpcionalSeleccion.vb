Public Class FormPreguntaOpcionalSeleccion
    Inherits System.Windows.Forms.Form
    Friend WithEvents MainMenuPregunta As System.Windows.Forms.MainMenu

#Region "Buttons ShortCuts"

    'Solo funciona para la SYMBOL
    Public Const BTN_CONTINUAR = 125
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Private WithEvents DetailViewPregunta As Resco.Controls.DetailView.DetailView
    Friend WithEvents ListViewOpciones As System.Windows.Forms.ListView
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

#Region "Variables"
    Private oCliente As Cliente
    Private sVisitaClave As String
    Private oPregunta As cPreguntaOpcional
    Private oEncuesta As cEncuesta
    Private refaVista As Vista
    'Private blnSeleccionManual As Boolean = False
    Private bCargando As Boolean
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String, ByRef paroEncuesta As cEncuesta, ByRef paroPregunta As cPreguntaOpcional)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        oCliente = paroCliente
        sVisitaClave = parsVisitaClave
        oEncuesta = paroEncuesta
        oPregunta = paroPregunta
        With ListViewOpciones
            .Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
            .Activation = oApp.TipoSeleccion
            .CheckBoxes = True
        End With
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        oCliente = Nothing
        oEncuesta = Nothing
        oPregunta = Nothing
        If Not Me.MenuItemSalir Is Nothing Then Me.MenuItemSalir.Dispose()
        If Not Me.MainMenuPregunta Is Nothing Then Me.MainMenuPregunta.Dispose()
        If Not Me.ListViewOpciones Is Nothing Then
            If Me.ListViewOpciones.Columns.Count Then
                Me.ListViewOpciones.Columns.Clear()
            End If
        End If
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
        Dim ItemTextBox1 As Resco.Controls.DetailView.ItemTextBox = New Resco.Controls.DetailView.ItemTextBox
        Me.MainMenuPregunta = New System.Windows.Forms.MainMenu
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pcbIcono = New System.Windows.Forms.PictureBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.DetailViewPregunta = New Resco.Controls.DetailView.DetailView
        Me.ListViewOpciones = New System.Windows.Forms.ListView
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
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.DetailViewPregunta)
        Me.Panel1.Controls.Add(Me.ListViewOpciones)
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
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(155, 262)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(74, 24)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "ButtonSalir"
        Me.Button1.Visible = False
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
        Me.DetailViewPregunta.TabIndex = 5
        '
        'ListViewOpciones
        '
        Me.ListViewOpciones.CheckBoxes = True
        Me.ListViewOpciones.FullRowSelect = True
        Me.ListViewOpciones.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListViewOpciones.Location = New System.Drawing.Point(5, 68)
        Me.ListViewOpciones.Name = "ListViewOpciones"
        Me.ListViewOpciones.Size = New System.Drawing.Size(224, 192)
        Me.ListViewOpciones.TabIndex = 6
        Me.ListViewOpciones.View = System.Windows.Forms.View.Details
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(5, 262)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresar.TabIndex = 7
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(80, 262)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuar.TabIndex = 8
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'MenuItemSalir
        '
        Me.MenuItemSalir.Text = "MenuItemSalir"
        '
        'FormPreguntaOpcionalSeleccion
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
        Me.Name = "FormPreguntaOpcionalSeleccion"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

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
        Button1.Enabled = bHabilitar
    End Sub

    Private Sub FormPreguntaOpcionalSeleccion_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp

        Static bActivo As Boolean = False

        Mapeo_Teclas(e)

        If e.KeyCode = 40 Then
            bActivo = True
        End If

        If (e.KeyCode = Keys.Space Or e.KeyCode = Keys.Enter) And (Not bActivo) Then
            If ListViewOpciones.Items.Count > 0 Then
                ListViewOpciones.Items(ListViewOpciones.SelectedIndices(0)).Checked = Not ListViewOpciones.Items(ListViewOpciones.SelectedIndices(0)).Checked
            End If
        End If

    End Sub

    Private Sub FormPreguntaOpcionalSeleccion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Application.DoEvents()

        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)

        ' Recuperar los demás componentes de la forma
        If Not Vista.Buscar("FormPreguntaOpcionalSeleccion", refaVista) Then
            Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If
        bCargando = True
        refaVista.CrearListView(ListViewOpciones, "ListViewOpciones")
        refaVista.PoblarListView(ListViewOpciones, oDBVen, "ListViewOpciones", " where CENClave = '" & oPregunta.CENClave & "' and CEPNumero = " & oPregunta.CEPNumero & " and CROId = '" & oPregunta.CROId & "' ")
        Dim ancho As Integer = Integer.MinValue
        Using ctrl As New Control()
            Dim g As System.Drawing.Graphics = ctrl.CreateGraphics()
            Dim aAn As Integer
            For Each i As ListViewItem In ListViewOpciones.Items
                aAn = g.MeasureString(i.Text, ListViewOpciones.Font).Width
                If aAn > ancho Then
                    ancho = aAn
                End If
            Next
            g.Dispose()
            ctrl.Dispose()
        End Using

        For Each col As ColumnHeader In ListViewOpciones.Columns
            If col.Width > 0 Then
                col.Width = ancho + 50
                Exit For
            End If
        Next

        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)
        'Application.DoEvents()
        MostrarPregunta()
        bCargando = False
        Me.KeyPreview = True
        'Me.HabilitarBotones(True)

        ListViewOpciones.Activation = ItemActivation.OneClick

        If ListViewOpciones.Items.Count > 0 Then
            ListViewOpciones.Focus()
            ListViewOpciones.Items(0).Selected = True
        End If

        Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
#End Region

#Region "Eventos Controles"
    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        HabilitarBotones(False)
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Me.DialogResult = Windows.Forms.DialogResult.Yes
    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        HabilitarBotones(False)
        Me.DialogResult = Windows.Forms.DialogResult.No
        'Me.Close()
    End Sub

    Private Sub MenuItemSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        HabilitarBotones(False)
        oEncuesta.EstadoFin = cEncuesta.EstadoFinalizar.ParcialmenteAplicada
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
#End Region

#Region "ListView"
    Private Sub ListViewOpciones_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewOpciones.ItemCheck
        If bCargando Then Exit Sub
        Dim ItemSel As ListViewItem
        ItemSel = ListViewOpciones.Items(e.Index)
        'blnSeleccionManual = True
        'ItemSel.Selected = True
        'blnSeleccionManual = False
        If e.NewValue = CheckState.Checked Then
            oPregunta.AgregarOpcion(ItemSel.SubItems(1).Text)
        Else
            oPregunta.EliminarOpcion(ItemSel.SubItems(1).Text)
        End If
    End Sub
#End Region

    Public Sub MostrarPregunta()
        Dim sCOOId As String
        Me.DetailViewPregunta.Items(0).Text = oPregunta.Descripcion
        Me.DetailViewPregunta.Items(0).TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
        Me.DetailViewPregunta.Items(0).Height = DetailViewPregunta.Height

        For Each sCOOId In oPregunta.Respuestas.Keys
            For i As Integer = 0 To Me.ListViewOpciones.Items.Count - 1
                If Me.ListViewOpciones.Items(i).SubItems(1).Text = sCOOId Then
                    Me.ListViewOpciones.Items(i).Checked = True
                End If
            Next
        Next

        Me.pcbIcono.Image = oEncuesta.ObtenerIcono()
        ListViewOpciones.Focus()
        If ListViewOpciones.Items.Count > 0 Then
            ListViewOpciones.Items(0).Selected = True
        End If
        Me.ButtonRegresar.Enabled = Not (oEncuesta.Preguntas.bPrimerPregunta)
        Me.MenuItemSalir.Enabled = oEncuesta.HabilitarSalir
    End Sub

    Private Sub FormPreguntaOpcionalSeleccion_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
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


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, MenuItemSalir.Click
        HabilitarBotones(False)
        oEncuesta.EstadoFin = cEncuesta.EstadoFinalizar.ParcialmenteAplicada
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

End Class
