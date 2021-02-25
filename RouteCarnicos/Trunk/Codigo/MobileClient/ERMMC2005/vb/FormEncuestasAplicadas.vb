Public Class FormEncuestasAplicadas
    Inherits System.Windows.Forms.Form
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents MainMenuEncuesta As System.Windows.Forms.MainMenu

#Region "Buttons ShortCuts"

    'Solo funciona para la SYMBOL
    Public Const BTN_CONTINUAR = 125
    Friend WithEvents MenuItemContinuar As System.Windows.Forms.MenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ListViewEncuestas As System.Windows.Forms.ListView
    Friend WithEvents LabelSeleccionarEncuesta As System.Windows.Forms.Label
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
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
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.MainMenuEncuesta = New System.Windows.Forms.MainMenu
        Me.MenuItemContinuar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ListViewEncuestas = New System.Windows.Forms.ListView
        Me.LabelSeleccionarEncuesta = New System.Windows.Forms.Label
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'MainMenuEncuesta
        '
        Me.MainMenuEncuesta.MenuItems.Add(Me.MenuItemRegresar)
        Me.MainMenuEncuesta.MenuItems.Add(Me.MenuItemContinuar)
        '
        'MenuItemContinuar
        '
        Me.MenuItemContinuar.Text = "MenuItemContinuar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ListViewEncuestas)
        Me.Panel1.Controls.Add(Me.LabelSeleccionarEncuesta)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'ListViewEncuestas
        '
        Me.ListViewEncuestas.FullRowSelect = True
        Me.ListViewEncuestas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewEncuestas.Location = New System.Drawing.Point(6, 29)
        Me.ListViewEncuestas.Name = "ListViewEncuestas"
        Me.ListViewEncuestas.Size = New System.Drawing.Size(224, 229)
        Me.ListViewEncuestas.TabIndex = 4
        Me.ListViewEncuestas.View = System.Windows.Forms.View.Details
        '
        'LabelSeleccionarEncuesta
        '
        Me.LabelSeleccionarEncuesta.Location = New System.Drawing.Point(6, 7)
        Me.LabelSeleccionarEncuesta.Name = "LabelSeleccionarEncuesta"
        Me.LabelSeleccionarEncuesta.Size = New System.Drawing.Size(224, 20)
        Me.LabelSeleccionarEncuesta.Text = "LabelSeleccionarEncuesta"
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(86, 262)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresar.TabIndex = 6
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(6, 262)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuar.TabIndex = 7
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'FormEncuestasAplicadas
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
        Me.Name = "FormEncuestasAplicadas"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Forma"

    Private Sub FormPreguntaNumero_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Me.Mapeo_Teclas(e)
    End Sub

    Private Sub FormEncuestasAplicadas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Recuperar los demás componentes de la forma
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        If Not Vista.Buscar("FormEncuestasAplicadas", refaVista) Then
            Exit Sub
        End If
        refaVista.CrearListView(ListViewEncuestas, "ListViewEncuestas")
        refaVista.PoblarListView(ListViewEncuestas, oDBVen, "ListViewEncuestas", " and CEC.ClienteClave = '" & oCliente.ClienteClave & "' where VisitaClave = '" & sVisitaClave & "' and DiaClave='" & oDia.DiaActual & "'")
        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)
        Me.KeyPreview = True

        If ListViewEncuestas.Items.Count > 0 Then
            ListViewEncuestas.Items(0).Selected = True
            ListViewEncuestas.Focus()
        Else
            Continuar()
        End If
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

    Private Sub MenuItemContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemContinuar.Click
        Continuar()
    End Sub

    Private Sub HabilitarBotones(ByVal bHabilitar As Boolean)
        Me.ButtonContinuar.Enabled = bHabilitar
        Me.ButtonRegresar.Enabled = bHabilitar
        Me.MenuItemContinuar.Enabled = bHabilitar
        Me.MenuItemRegresar.Enabled = bHabilitar
    End Sub

    Private Sub Continuar()
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Try
            Dim refListViewItemSel As ListViewItem
            If ListViewEncuestas.SelectedIndices.Count > 0 Then
                refListViewItemSel = ListViewEncuestas.Items(ListViewEncuestas.SelectedIndices(0))
                If refListViewItemSel.SubItems(3).Text <> 0 Then
                    Dim oEncuestas As New FormasEncuestas
                    Me.HabilitarBotones(False)
                    If oEncuestas.EjecutarEncuesta(oCliente, sVisitaClave, refListViewItemSel.SubItems(1).Text, refListViewItemSel.SubItems(4).Text, refListViewItemSel.SubItems(5).Text, refListViewItemSel.SubItems(8).Text, refListViewItemSel.SubItems(3).Text, , refListViewItemSel.SubItems(6).Text) Then
                        Me.Close()
                        'refaVista.PoblarListView(ListViewEncuestas, oDBVen, "ListViewEncuestas", " and CEC.ClienteClave = '" & oCliente.ClienteClave & "' where VisitaClave = '" & sVisitaClave & "' and DiaClave='" & oDia.DiaActual & "'")
                        'MsgBox(refaVista.BuscarMensaje("MsgBox", "I0040"), MsgBoxStyle.Information, refaVista.BuscarMensaje("MsgBox", "XMensajeI"))

                        'If ListViewEncuestas.Items.Count > 0 Then
                        '    ListViewEncuestas.Focus()
                        '    ListViewEncuestas.Items(0).Selected = True
                        'End If
                    End If
                Else
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0350"), MsgBoxStyle.Critical, refaVista.BuscarMensaje("MsgBox", "XMensajeE"))
                End If
            Else
                Dim oFormEncuestasNoAplicadas As New FormEncuestasNoAplicadas(oCliente, sVisitaClave)
                oFormEncuestasNoAplicadas.ShowDialog()
                oFormEncuestasNoAplicadas.Dispose()
                oFormEncuestasNoAplicadas = Nothing
                Me.Close()
                'refaVista.PoblarListView(ListViewEncuestas, oDBVen, "ListViewEncuestas", " and CEC.ClienteClave = '" & oCliente.ClienteClave & "' where VisitaClave = '" & sVisitaClave & "' and DiaClave='" & oDia.DiaActual & "'")
            End If
        Catch ex As CEstado
            MsgBox(refaVista.BuscarMensaje("MsgBox", ex.sCVEMensaje), MsgBoxStyle.Critical, refaVista.BuscarMensaje("MsgBox", "XMensajeE"))
        End Try
    End Sub

End Class
