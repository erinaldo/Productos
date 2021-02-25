Public Class FormRutas
    Inherits System.Windows.Forms.Form
    Friend WithEvents PanelLista As System.Windows.Forms.Panel
    Friend WithEvents ButtonContinuarLista As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresarLista As System.Windows.Forms.Button

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        ListViewRutas.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        ListViewRutas.Activation = oApp.TipoSeleccion

        Me.RutaActual = New Ruta
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not IsNothing(Me.ListViewRutas) Then
            If Me.ListViewRutas.Columns.Count > 0 Then
                Me.ListViewRutas.Columns.Clear()
            End If
            Me.ListViewRutas.Dispose()
        End If
        If Not IsNothing(Me.MenuItemRegresar) Then MenuItemRegresar.Dispose()
        If Not IsNothing(Me.MainMenuAgenda) Then MainMenuAgenda.Dispose()
        RutaActual = Nothing
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ListViewRutas As System.Windows.Forms.ListView
    Friend WithEvents MainMenuAgenda As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents LabelAgenda As System.Windows.Forms.Label
    Friend WithEvents LabelReferencia As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.PanelLista = New System.Windows.Forms.Panel
        Me.LabelAgenda = New System.Windows.Forms.Label
        Me.LabelReferencia = New System.Windows.Forms.Label
        Me.ListViewRutas = New System.Windows.Forms.ListView
        Me.ButtonContinuarLista = New System.Windows.Forms.Button
        Me.ButtonRegresarLista = New System.Windows.Forms.Button
        Me.MainMenuAgenda = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.PanelLista.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelLista
        '
        Me.PanelLista.Controls.Add(Me.LabelAgenda)
        Me.PanelLista.Controls.Add(Me.LabelReferencia)
        Me.PanelLista.Controls.Add(Me.ListViewRutas)
        Me.PanelLista.Controls.Add(Me.ButtonContinuarLista)
        Me.PanelLista.Controls.Add(Me.ButtonRegresarLista)
        Me.PanelLista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelLista.Location = New System.Drawing.Point(0, 0)
        Me.PanelLista.Name = "PanelLista"
        Me.PanelLista.Size = New System.Drawing.Size(242, 295)
        '
        'LabelAgenda
        '
        Me.LabelAgenda.Location = New System.Drawing.Point(8, 3)
        Me.LabelAgenda.Name = "LabelAgenda"
        Me.LabelAgenda.Size = New System.Drawing.Size(230, 16)
        Me.LabelAgenda.Text = "LabelAgenda"
        '
        'LabelReferencia
        '
        Me.LabelReferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelReferencia.ForeColor = System.Drawing.Color.Blue
        Me.LabelReferencia.Location = New System.Drawing.Point(8, 6)
        Me.LabelReferencia.Name = "LabelReferencia"
        Me.LabelReferencia.Size = New System.Drawing.Size(116, 16)
        Me.LabelReferencia.Text = "Pedidos del Martes"
        '
        'ListViewRutas
        '
        Me.ListViewRutas.CheckBoxes = True
        Me.ListViewRutas.FullRowSelect = True
        Me.ListViewRutas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewRutas.Location = New System.Drawing.Point(8, 22)
        Me.ListViewRutas.Name = "ListViewRutas"
        Me.ListViewRutas.Size = New System.Drawing.Size(225, 237)
        Me.ListViewRutas.TabIndex = 2
        Me.ListViewRutas.View = System.Windows.Forms.View.Details
        '
        'ButtonContinuarLista
        '
        Me.ButtonContinuarLista.Location = New System.Drawing.Point(8, 262)
        Me.ButtonContinuarLista.Name = "ButtonContinuarLista"
        Me.ButtonContinuarLista.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuarLista.TabIndex = 3
        Me.ButtonContinuarLista.Text = "ButtonContinuarLista"
        '
        'ButtonRegresarLista
        '
        Me.ButtonRegresarLista.Location = New System.Drawing.Point(88, 262)
        Me.ButtonRegresarLista.Name = "ButtonRegresarLista"
        Me.ButtonRegresarLista.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresarLista.TabIndex = 4
        Me.ButtonRegresarLista.Text = "ButtonRegresarLista"
        '
        'MainMenuAgenda
        '
        Me.MainMenuAgenda.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'FormRutas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelLista)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuAgenda
        Me.MinimizeBox = False
        Me.Name = "FormRutas"
        Me.Text = "Amesol Route"
        Me.PanelLista.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private refaVista As Vista
    Private bIniciando As Boolean = False
    Private oRutaActual As Ruta

    Public Property RutaActual() As Ruta
        Get
            Return oRutaActual
        End Get
        Set(ByVal Value As Ruta)
            oRutaActual = Value
        End Set
    End Property

#Region " Eventos generales de la forma "
    Private Sub FormRutas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        bIniciando = True
        If Not Vista.Buscar("FormRutas", refaVista) Then
            Exit Sub
        End If

        refaVista.CrearListView(ListViewRutas, "ListViewRutas")

        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)

        LabelReferencia.Text = oDia.Referencia
        ' Poblar el menú de clientes
        Dim sCondicion As String = "WHERE DiaClave='" & oDia.DiaActual & "'"
        Me.refaVista.PoblarListView(Me.ListViewRutas, oDBVen, "ListViewRutas", sCondicion)

        If Me.ListViewRutas.Items.Count <= 0 Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0152"), MsgBoxStyle.Information)
            ButtonContinuarLista.Enabled = False
        Else
            ButtonContinuarLista.Enabled = True
        End If

        bIniciando = False

        With ListViewRutas
            If .Items.Count > 0 Then
                .Items(0).Selected = True
                .Focus()
            Else
                ButtonContinuarLista.Focus()
            End If
        End With

    End Sub
#End Region

    Private Function HaySeleccion(ByVal LV As ListView) As Boolean
        If LV.Items.Count > 0 Then
            Dim i As Integer
            For i = 0 To LV.Items.Count - 1
                If LV.Items(i).Checked Then
                    Return True
                End If
            Next
        End If
        Return False
    End Function

    Private Sub ButtonContinuarLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuarLista.Click
        'If ListViewRutas.SelectedIndices.Count = 0 Then
        '    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0160"), MsgBoxStyle.Information)
        '    Exit Sub
        'End If
        bIniciando = True
        If Not Me.HaySeleccion(Me.ListViewRutas) Then 'RevisarElementoMarcado(ListViewRutas) Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0160"), MsgBoxStyle.Information)
            Exit Sub
        End If
        bIniciando = False
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ButtonRegresarLista_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRegresarLista.Click
        Me.Close()
    End Sub

    Private Sub ListViewRutas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewRutas.SelectedIndexChanged
        If bIniciando Then Exit Sub
        If ListViewRutas.SelectedIndices.Count <= 0 Then Exit Sub
        bIniciando = True
        MarcarElemento(ListViewRutas, CheckState.Checked, ListViewRutas.SelectedIndices(0))
        bIniciando = False
        Dim refListViewItemSel As ListViewItem = ListViewRutas.Items(ListViewRutas.SelectedIndices(0))
        ' La clave del cliente siempre debe estar en el primer elemento del ListView
        Me.RutaActual.RUTClave = refListViewItemSel.Text
        Me.RutaActual.Recuperar()
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Me.Close()
    End Sub

    Private Sub ListViewRutas_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewRutas.ItemCheck
        'MarcarElemento(ListViewRutas, e.NewValue, e.Index)
        If bIniciando Then Exit Sub
        bIniciando = True
        MarcarElemento(ListViewRutas, e.NewValue, e.Index)
        bIniciando = False
        If ListViewRutas.SelectedIndices.Count <= 0 Then Exit Sub
        Dim refListViewItemSel As ListViewItem = ListViewRutas.Items(ListViewRutas.SelectedIndices(0))
        ' La clave del cliente siempre debe estar en el primer elemento del ListView
        Me.RutaActual.RUTClave = refListViewItemSel.Text
        Me.RutaActual.Recuperar()
        'If e.NewValue = CheckState.Unchecked Then
        '    bIniciando = True
        '    ListViewRutas.Items(ListViewRutas.SelectedIndices(0)).Selected = False
        '    bIniciando = False
        'End If
    End Sub

End Class
