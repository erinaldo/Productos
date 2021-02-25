Public Class FormEncuestasNoAplicadas
    Inherits System.Windows.Forms.Form
    Friend WithEvents MainMenuEncuesta As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem

#Region "Buttons ShortCuts"

    'Solo funciona para la SYMBOL
    Public Const BTN_CONTINUAR = 125
    Friend WithEvents MenuItemContinuar As System.Windows.Forms.MenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonCancelar As System.Windows.Forms.Button
    Friend WithEvents TextBoxFecha As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCliente As System.Windows.Forms.TextBox
    Friend WithEvents LabelFecha As System.Windows.Forms.Label
    Friend WithEvents LabelCliente As System.Windows.Forms.Label
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents ListViewEncuestas As System.Windows.Forms.ListView
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
    Private refaVista As Vista
    Private blnSeleccionManual As Boolean = False
    'Private oEnc As cEncuesta
    'Dim aVisitadas As New ArrayList
    'Dim nPregActual As Long = -1
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        oCliente = paroCliente
        sVisitaClave = parsVisitaClave
        With ListViewEncuestas
            .Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
            .Activation = oApp.TipoSeleccion
            '.CheckBoxes = True
        End With
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Me.ListViewEncuestas.Columns.Count > 0 Then
            If oVendedor.motconfiguracion.Secuencia Then
                RemoveHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
                RemoveHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
                ctrlSeguimiento.QuitarMenuItem(Me.MainMenuEncuesta)
                Me.Controls.Remove(ctrlSeguimiento)
            Else
                For Each ctrl As Control In Me.Controls
                    If ctrl.Name = "lbNombreActividad" Then
                        Me.Controls.Remove(ctrl)
                        ctrl.Dispose()
                        ctrl = Nothing
                        Exit For
                    End If
                Next
            End If
        End If

        Me.MenuItemContinuar.Dispose()
        Me.MenuItemRegresar.Dispose()
        Me.MainMenuEncuesta.Dispose()
        If Me.ListViewEncuestas.Columns.Count > 0 Then
            Me.ListViewEncuestas.Columns.Clear()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenuEncuesta = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.MenuItemContinuar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ButtonCancelar = New System.Windows.Forms.Button
        Me.TextBoxFecha = New System.Windows.Forms.TextBox
        Me.TextBoxCliente = New System.Windows.Forms.TextBox
        Me.LabelFecha = New System.Windows.Forms.Label
        Me.LabelCliente = New System.Windows.Forms.Label
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.ListViewEncuestas = New System.Windows.Forms.ListView
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenuEncuesta
        '
        Me.MainMenuEncuesta.MenuItems.Add(Me.MenuItemRegresar)
        Me.MainMenuEncuesta.MenuItems.Add(Me.MenuItemContinuar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'MenuItemContinuar
        '
        Me.MenuItemContinuar.Text = "MenuItemContinuar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ButtonCancelar)
        Me.Panel1.Controls.Add(Me.TextBoxFecha)
        Me.Panel1.Controls.Add(Me.TextBoxCliente)
        Me.Panel1.Controls.Add(Me.LabelFecha)
        Me.Panel1.Controls.Add(Me.LabelCliente)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
        Me.Panel1.Controls.Add(Me.ListViewEncuestas)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'ButtonCancelar
        '
        Me.ButtonCancelar.Location = New System.Drawing.Point(160, 264)
        Me.ButtonCancelar.Name = "ButtonCancelar"
        Me.ButtonCancelar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonCancelar.TabIndex = 8
        Me.ButtonCancelar.Text = "ButtonCancelar"
        '
        'TextBoxFecha
        '
        Me.TextBoxFecha.Enabled = False
        Me.TextBoxFecha.Location = New System.Drawing.Point(112, 41)
        Me.TextBoxFecha.Name = "TextBoxFecha"
        Me.TextBoxFecha.Size = New System.Drawing.Size(120, 23)
        Me.TextBoxFecha.TabIndex = 9
        '
        'TextBoxCliente
        '
        Me.TextBoxCliente.Enabled = False
        Me.TextBoxCliente.Location = New System.Drawing.Point(112, 17)
        Me.TextBoxCliente.Name = "TextBoxCliente"
        Me.TextBoxCliente.Size = New System.Drawing.Size(120, 23)
        Me.TextBoxCliente.TabIndex = 10
        '
        'LabelFecha
        '
        Me.LabelFecha.Location = New System.Drawing.Point(8, 41)
        Me.LabelFecha.Name = "LabelFecha"
        Me.LabelFecha.Size = New System.Drawing.Size(100, 20)
        Me.LabelFecha.Text = "LabelFecha"
        '
        'LabelCliente
        '
        Me.LabelCliente.Location = New System.Drawing.Point(8, 17)
        Me.LabelCliente.Name = "LabelCliente"
        Me.LabelCliente.Size = New System.Drawing.Size(100, 20)
        Me.LabelCliente.Text = "LabelCliente"
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(84, 264)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar.TabIndex = 13
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(8, 264)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuar.TabIndex = 14
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'ListViewEncuestas
        '
        Me.ListViewEncuestas.FullRowSelect = True
        Me.ListViewEncuestas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewEncuestas.Location = New System.Drawing.Point(8, 65)
        Me.ListViewEncuestas.Name = "ListViewEncuestas"
        Me.ListViewEncuestas.Size = New System.Drawing.Size(224, 198)
        Me.ListViewEncuestas.TabIndex = 15
        Me.ListViewEncuestas.View = System.Windows.Forms.View.Details
        '
        'FormEncuestasNoAplicadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuEncuesta
        Me.MinimizeBox = False
        Me.Name = "FormEncuestasNoAplicadas"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Metodos"
    Private Sub HabilitarBotones(ByVal bHabilitar As Boolean)
        Me.ButtonCancelar.Enabled = bHabilitar
        Me.ButtonContinuar.Enabled = bHabilitar
        Me.ButtonRegresar.Enabled = bHabilitar
        Me.MenuItemContinuar.Enabled = bHabilitar
        Me.MenuItemRegresar.Enabled = bHabilitar
    End Sub

    Private Sub LlenarDatosCliente()
        Me.TextBoxCliente.Text = oCliente.RazonSocial
        Me.TextBoxFecha.Text = Now.ToShortDateString
    End Sub

    Private Sub Continuar()
        Try
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Application.DoEvents()
            Dim refListViewItemSel As ListViewItem
            If ListViewEncuestas.SelectedIndices.Count > 0 Then
                refListViewItemSel = ListViewEncuestas.Items(ListViewEncuestas.SelectedIndices(0))
                Dim oEncuestas As New FormasEncuestas
                HabilitarBotones(False)
                If oEncuestas.EjecutarEncuesta(oCliente, sVisitaClave, refListViewItemSel.SubItems(1).Text, refListViewItemSel.SubItems(2).Text, refListViewItemSel.SubItems(3).Text, refListViewItemSel.SubItems(4).Text, 0, True) Then
                    Dim sFiltro As String
                    sFiltro = String.Format(" and CEC.ClienteClave = '{0}' where CEN.CENClave not in(select ENC.CENClave from Encuesta ENC WHERE VisitaClave = '{1}' and DiaClave='{2}') OR CEN.Tipo = 3 ", oCliente.ClienteClave, sVisitaClave, oDia.DiaActual)
                    refaVista.PoblarListView(ListViewEncuestas, oDBVen, "ListViewEncuestas", sFiltro)
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "I0040"), MsgBoxStyle.Information, refaVista.BuscarMensaje("MsgBox", "XMensajeI"))

                    If ListViewEncuestas.Items.Count > 0 Then
                        HabilitarBotones(True)
                        ListViewEncuestas.Items(0).Selected = True
                        ListViewEncuestas.Focus()
                    Else
                        Me.Close()
                    End If
                End If
            Else
                'Crear un mensaje que indique que se debe seleccionar una encuesta
                MsgBox(refaVista.BuscarMensaje("MsgBox", "E0351"), MsgBoxStyle.Critical, refaVista.BuscarMensaje("MsgBox", "XMensajeE"))
            End If
        Catch ex As CEstado
            HabilitarBotones(True)
            MsgBox(refaVista.BuscarMensaje("MsgBox", ex.sCVEMensaje), MsgBoxStyle.Critical, refaVista.BuscarMensaje("MsgBox", "XMensajeE"))
        End Try
        Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
#End Region

#Region "Forma"
    Private Sub FormEncuestasNoAplicadas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)

        If oVendedor.motconfiguracion.Secuencia Then
            ctrlSeguimiento.AgregarControl(Me)
            Me.Panel1.SendToBack()
            ctrlSeguimiento.CrearMenuItem(Me.MainMenuEncuesta)
            AddHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
            AddHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
        End If

        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)

        If oVendedor.motconfiguracion.Secuencia Then
            ctrlSeguimiento.Iniciar()
        Else
            Dim lbNombreActividad As New Label
            lbNombreActividad.BackColor = System.Drawing.SystemColors.Control
            lbNombreActividad.Dock = System.Windows.Forms.DockStyle.Top
            Dim tam As Single = 10 * nFactorH
            lbNombreActividad.Font = New System.Drawing.Font("Tahoma", tam!, System.Drawing.FontStyle.Bold)
            UbicarTitulo(lbNombreActividad, Me.Controls)
            lbNombreActividad.Name = "lbNombreActividad"
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
            lbNombreActividad.Size = New System.Drawing.Size((Me.Width * nFactorW) - 5, 32 * nFactorH) 
#Else
            lbNombreActividad.Size = New System.Drawing.Size((Me.Width * nFactorW) - 5, 16 * nFactorH)
#End If
            lbNombreActividad.Text = sNombreActividad
            lbNombreActividad.TextAlign = System.Drawing.ContentAlignment.TopCenter
            Me.Controls.Add(lbNombreActividad)
            lbNombreActividad.BringToFront()
            tam = Nothing
        End If

        Cursor.Current = Cursors.Default
        ' Recuperar los demás componentes de la forma
        If Not Vista.Buscar("FormEncuestasNoAplicadas", refaVista) Then
            Exit Sub
        End If
        refaVista.CrearListView(ListViewEncuestas, "ListViewEncuestas")
        Dim sFiltro As String
        sFiltro = String.Format(" and CEC.ClienteClave = '{0}' where CEN.CENClave not in(select ENC.CENClave from Encuesta ENC WHERE VisitaClave = '{1}' and DiaClave='{2}') OR CEN.Tipo = 3 ", oCliente.ClienteClave, sVisitaClave, oDia.DiaActual)
        refaVista.PoblarListView(ListViewEncuestas, oDBVen, "ListViewEncuestas", sFiltro)
        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)
        LlenarDatosCliente()

        Me.KeyPreview = True

        If ListViewEncuestas.Items.Count > 0 Then
            ListViewEncuestas.Items(0).Selected = True
            ListViewEncuestas.Focus()
        End If
        [Global].HabilitarMenuItem(MainMenuEncuesta, True)
    End Sub

    Private Sub TerminarVisita()
        MenuItemRegresar_Click(Nothing, Nothing)
    End Sub
#End Region

#Region "ListView"
    Private Sub ListViewEncuestas_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewEncuestas.ItemCheck
        If blnSeleccionManual Then Exit Sub
        blnSeleccionManual = True
        MarcarElemento(ListViewEncuestas, e.NewValue, e.Index)
        blnSeleccionManual = False
        If ListViewEncuestas.SelectedIndices.Count <= 0 Then Exit Sub
        If e.NewValue = CheckState.Unchecked Then
            blnSeleccionManual = True
            ListViewEncuestas.Items(ListViewEncuestas.SelectedIndices(0)).Selected = False
            blnSeleccionManual = False
        End If
    End Sub

    Private Sub ListViewEncuestas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewEncuestas.SelectedIndexChanged
        If blnSeleccionManual Then Exit Sub
        If ListViewEncuestas.SelectedIndices.Count <= 0 Then Exit Sub
        blnSeleccionManual = True
        MarcarElemento(ListViewEncuestas, CheckState.Checked, ListViewEncuestas.SelectedIndices(0))
        blnSeleccionManual = False
    End Sub
#End Region

#Region "Eventos Controles"
    Private Sub ButtonRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.Close()
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Me.Close()
    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        Continuar()
    End Sub

#End Region

    Private Sub ButtonCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancelar.Click
        Try
            Dim refListViewItemSel As ListViewItem
            Dim sComando As String
            Dim sENCId As String
            If ListViewEncuestas.SelectedIndices.Count > 0 Then
                sENCId = oApp.KEYGEN(1)
                refListViewItemSel = ListViewEncuestas.Items(ListViewEncuestas.SelectedIndices(0))
                sComando = String.Format("insert into Encuesta (ENCId, CENClave, VisitaClave, DiaClave, Fase, Fecha, HoraInicio, HoraFin, MFechaHora, MUsuarioId,Enviado) values('{0}','{1}','{2}','{3}',{4},{5},getdate(),getdate(),getdate(),'{6}',0)", sENCId, refListViewItemSel.SubItems(1).Text, sVisitaClave, oDia.DiaActual, 0, UniFechaSQL(PrimeraHora(Now)), oVendedor.UsuarioId)
                oDBVen.EjecutarComandoSQL(sComando)
                Dim sFiltro As String
                sFiltro = String.Format(" and CEC.ClienteClave = '{0}' where CEN.CENClave not in(select ENC.CENClave from Encuesta ENC WHERE VisitaClave = '{1}' and DiaClave='{2}')", oCliente.ClienteClave, sVisitaClave, oDia.DiaActual)
                refaVista.PoblarListView(ListViewEncuestas, oDBVen, "ListViewEncuestas", sFiltro)
            Else
                'Crear un mensaje que indique que se debe seleccionar una encuesta
                MsgBox(refaVista.BuscarMensaje("MsgBox", "E0351"), MsgBoxStyle.Critical, refaVista.BuscarMensaje("MsgBox", "XMensajeE"))
            End If
        Catch ex As CEstado
            MsgBox(refaVista.BuscarMensaje("MsgBox", ex.sCVEMensaje), MsgBoxStyle.Critical, refaVista.BuscarMensaje("MsgBox", "XMensajeE"))
        End Try
    End Sub

    Private Sub MenuItemContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemContinuar.Click
        Continuar()
    End Sub

End Class
