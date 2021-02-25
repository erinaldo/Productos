Imports System.Data.SqlServerCe
Imports System.Collections.Generic


Public Class FormVisitas
    Inherits System.Windows.Forms.Form

    Private iConsecutivoMercadeo As Integer = 1
    Private oCliente As Cliente
    Private sVisitaClave As String
    Protected refTreeNodeSeleccionado As TreeNode
    Private bSeleccionando As Boolean = False

    Public Property Cliente() As Cliente
        Get
            Return oCliente
        End Get
        Set(ByVal Value As Cliente)
            oCliente = Value
        End Set
    End Property
    Public Property VisitaClave() As String
        Get
            Return sVisitaClave
        End Get
        Set(ByVal Value As String)
            sVisitaClave = Value
        End Set
    End Property

    Private refaVista As Vista
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonNuevaVisita As System.Windows.Forms.Button
    Friend WithEvents TreeViewVisitas As System.Windows.Forms.TreeView
    Friend WithEvents LabelVisitas As System.Windows.Forms.Label
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents ButtonDetalles As System.Windows.Forms.Button
    Friend WithEvents LabelClienteActual As System.Windows.Forms.Label

    Private bIniciando As Boolean = True

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

        'Me.DetailViewDetalle.Text = "DetailViewDetalle"
        'Me.DetailViewDetalle.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)

        Me.TreeViewVisitas.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)

        Me.Cliente = New Cliente

        Me.VisitaClave = ""

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not IsNothing(ImageListAgenda) Then
            ImageListAgenda.Images.Clear()
            ImageListAgenda.Dispose()
            ImageListAgenda = Nothing
        End If

        If Not IsNothing(TreeViewVisitas) Then TreeViewVisitas.Dispose()
        If Not IsNothing(ContextMenuVisitas) Then ContextMenuVisitas.Dispose()
        If Not IsNothing(MenuItemDetalles) Then MenuItemDetalles.Dispose()
        If Not IsNothing(MenuItemNuevo) Then MenuItemNuevo.Dispose()
        If Not IsNothing(MenuItemRegresar) Then MenuItemRegresar.Dispose()
        If Not IsNothing(Me.MainMenuAgenda) Then Me.MainMenuAgenda.Dispose()

        VisitaClave = Nothing
        MyBase.Dispose(disposing)
    End Sub

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents MainMenuAgenda As System.Windows.Forms.MainMenu
    Friend WithEvents InputPanelAgenda As Microsoft.WindowsCE.Forms.InputPanel
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents ImageListAgenda As System.Windows.Forms.ImageList
    Friend WithEvents MenuItemNuevo As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemDetalles As System.Windows.Forms.MenuItem
    Friend WithEvents ContextMenuVisitas As System.Windows.Forms.ContextMenu
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormVisitas))
        Me.ContextMenuVisitas = New System.Windows.Forms.ContextMenu
        Me.MenuItemNuevo = New System.Windows.Forms.MenuItem
        Me.MenuItemDetalles = New System.Windows.Forms.MenuItem
        Me.ImageListAgenda = New System.Windows.Forms.ImageList
        Me.MainMenuAgenda = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.InputPanelAgenda = New Microsoft.WindowsCE.Forms.InputPanel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LabelClienteActual = New System.Windows.Forms.Label
        Me.ButtonNuevaVisita = New System.Windows.Forms.Button
        Me.TreeViewVisitas = New System.Windows.Forms.TreeView
        Me.LabelVisitas = New System.Windows.Forms.Label
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.ButtonDetalles = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuVisitas
        '
        Me.ContextMenuVisitas.MenuItems.Add(Me.MenuItemNuevo)
        Me.ContextMenuVisitas.MenuItems.Add(Me.MenuItemDetalles)
        '
        'MenuItemNuevo
        '
        Me.MenuItemNuevo.Text = "MenuItemNuevo"
        '
        'MenuItemDetalles
        '
        Me.MenuItemDetalles.Text = "MenuItemDetalles"
        Me.ImageListAgenda.Images.Clear()
        Me.ImageListAgenda.Images.Add(CType(resources.GetObject("resource"), System.Drawing.Image))
        Me.ImageListAgenda.Images.Add(CType(resources.GetObject("resource1"), System.Drawing.Image))
        '
        'MainMenuAgenda
        '
        Me.MainMenuAgenda.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LabelClienteActual)
        Me.Panel1.Controls.Add(Me.ButtonNuevaVisita)
        Me.Panel1.Controls.Add(Me.TreeViewVisitas)
        Me.Panel1.Controls.Add(Me.LabelVisitas)
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
        Me.Panel1.Controls.Add(Me.ButtonDetalles)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'LabelClienteActual
        '
        Me.LabelClienteActual.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelClienteActual.ForeColor = System.Drawing.Color.Navy
        Me.LabelClienteActual.Location = New System.Drawing.Point(1, 5)
        Me.LabelClienteActual.Name = "LabelClienteActual"
        Me.LabelClienteActual.Size = New System.Drawing.Size(236, 16)
        Me.LabelClienteActual.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ButtonNuevaVisita
        '
        Me.ButtonNuevaVisita.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonNuevaVisita.Location = New System.Drawing.Point(162, 262)
        Me.ButtonNuevaVisita.Name = "ButtonNuevaVisita"
        Me.ButtonNuevaVisita.Size = New System.Drawing.Size(74, 24)
        Me.ButtonNuevaVisita.TabIndex = 30
        Me.ButtonNuevaVisita.Text = "ButtonNuevaVisita"
        '
        'TreeViewVisitas
        '
        Me.TreeViewVisitas.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TreeViewVisitas.ContextMenu = Me.ContextMenuVisitas
        Me.TreeViewVisitas.ImageIndex = 0
        Me.TreeViewVisitas.ImageList = Me.ImageListAgenda
        Me.TreeViewVisitas.Location = New System.Drawing.Point(4, 48)
        Me.TreeViewVisitas.Name = "TreeViewVisitas"
        Me.TreeViewVisitas.SelectedImageIndex = 1
        Me.TreeViewVisitas.Size = New System.Drawing.Size(232, 209)
        Me.TreeViewVisitas.TabIndex = 31
        '
        'LabelVisitas
        '
        Me.LabelVisitas.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LabelVisitas.Location = New System.Drawing.Point(4, 29)
        Me.LabelVisitas.Name = "LabelVisitas"
        Me.LabelVisitas.Size = New System.Drawing.Size(230, 16)
        Me.LabelVisitas.Text = "LabelVisitas"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonContinuar.Location = New System.Drawing.Point(4, 262)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuar.TabIndex = 33
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'ButtonDetalles
        '
        Me.ButtonDetalles.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonDetalles.Location = New System.Drawing.Point(83, 262)
        Me.ButtonDetalles.Name = "ButtonDetalles"
        Me.ButtonDetalles.Size = New System.Drawing.Size(74, 24)
        Me.ButtonDetalles.TabIndex = 34
        Me.ButtonDetalles.Text = "ButtonDetalles"
        '
        'FormVisitas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuAgenda
        Me.MinimizeBox = False
        Me.Name = "FormVisitas"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Eventos generales de la forma "

    Private Sub FormVisitas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        If Not Vista.Buscar("FormVisitas", refaVista) Then
            Exit Sub
        End If
        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)
        Me.LlenarTreeView()
        'Me.LlenarTreeViewVisitas()
        'Me.TabControlVisitas.SelectedIndex = ConstTabPageVisitas
        Me.bIniciando = False

        Me.LabelClienteActual.Text = oAgenda.ClienteActual.Clave & "-" & IIf(oAgenda.ClienteActual.RazonSocial.Trim = "", oAgenda.ClienteActual.NombreCorto, oAgenda.ClienteActual.RazonSocial.Trim)

        With Me.TreeViewVisitas
            If .GetNodeCount(True) > 0 Then
                .SelectedNode = .Nodes(0)
                .Focus()
            End If
        End With



    End Sub

#End Region

    Private Sub LlenarTreeView()
        Dim oDt As DataTable = oDBVen.RealizarConsultaSQL("SELECT VisitaClave, Numero, FechaHoraInicial, FechaHoraFinal, TipoEstado FROM Visita WHERE ClienteClave = '" & Me.Cliente.ClienteClave & "' AND DiaClave='" & oDia.DiaActual & "' AND (Enviado=0 or Enviado is null) AND TipoEstado =1 ORDER BY VisitaClave", "ObtieneVisita")
        Me.TreeViewVisitas.Nodes.Clear()
        Dim i As Integer = 0
        For Each oDr As DataRow In oDt.Rows
            Me.TreeViewVisitas.Nodes.Add(refaVista.BuscarMensaje("MsgBox", "NombreVisitas") & " " & oDr("Numero").ToString)
            Me.TreeViewVisitas.Nodes(i).Tag = oDr("VisitaClave")
            Me.TreeViewVisitas.Nodes(i).Nodes.Add(refaVista.BuscarMensaje("MsgBox", "HoraInicial") & ": " & Format(oDr("FechaHoraInicial"), "hh:mm:ss tt"))
            Me.TreeViewVisitas.Nodes(i).Nodes.Add(refaVista.BuscarMensaje("MsgBox", "HoraFinal") & ": " & Format(oDr("FechaHoraFinal"), "hh:mm:ss tt"))
            Me.TreeViewVisitas.Nodes(i).Nodes.Add(refaVista.BuscarMensaje("MsgBox", "TipoEstado") & ": " & ValorReferencia.BuscarEquivalente("EDOREG", oDr("TipoEstado")))
            i += 1
        Next
        oDt.Dispose()
        Me.TreeViewVisitas.Refresh()
        'Me.TreeViewVisitas.ExpandAll()
        Me.TreeViewVisitas.CollapseAll()
    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        If RecuperarVisitaSeleccionada() Then
            FormProcesando.PubSubTitulo(refaVista.BuscarMensaje("Procesando", "Titulo"))
            FormProcesando.PubSubInformar(refaVista.BuscarMensaje("Procesando", "Recuperando"), Me.refTreeNodeSeleccionado.Text)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Function RecuperarVisitaSeleccionada() As Boolean
        If Me.refTreeNodeSeleccionado Is Nothing Then
            If Me.TreeViewVisitas.Nodes.Count <> 0 Then
                If MsgBox(refaVista.BuscarMensaje("MsgBox", "CrearVisita"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                    TreeViewVisitas.Focus()
                    Return False
                End If
            End If
            FormProcesando.PubSubTitulo(refaVista.BuscarMensaje("Procesando", "Titulo"))
            FormProcesando.PubSubInformar(refaVista.BuscarMensaje("Procesando", "Creando"))
            ' Crear una nueva visita
            Return False
        Else
            Me.VisitaClave = refTreeNodeSeleccionado.Tag
            Return True
        End If
        Return False
    End Function

    Private Sub Nueva()
        FormProcesando.PubSubTitulo(refaVista.BuscarMensaje("Procesando", "Titulo"))
        FormProcesando.PubSubInformar(refaVista.BuscarMensaje("Procesando", "Creando"))
        Me.DialogResult = Windows.Forms.DialogResult.Ignore
        'Me.Close()
    End Sub

    Private Sub TreeViewVisitas_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeViewVisitas.AfterSelect
        If Not bSeleccionando Then
            ' Buscar el nodo raíz para obtener el folio de la visita
            Dim refTreeNode As TreeNode = e.Node
            If Not refTreeNode Is Nothing Then
                Me.TreeViewVisitas.SelectedNode = Nothing
                Do While (Not (refTreeNode.Parent Is Nothing))
                    refTreeNode = refTreeNode.Parent
                Loop
                Me.refTreeNodeSeleccionado = refTreeNode
                Me.refTreeNodeSeleccionado.ExpandAll()
                Me.TreeViewVisitas.Refresh()
                bSeleccionando = True
                Me.TreeViewVisitas.SelectedNode = Me.refTreeNodeSeleccionado
                bSeleccionando = False
            End If
        End If
    End Sub

    Private Sub MenuItemNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemNuevo.Click
        Me.Nueva()
    End Sub

    Private Sub MenuItemDetalles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemDetalles.Click
        Dim oVisitaDetalle As New FormVisitaDetalle(Me.refTreeNodeSeleccionado.Tag)
        oVisitaDetalle.ShowDialog()
        oVisitaDetalle.Dispose()
    End Sub

    Private Sub MenuItemCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not Me.refTreeNodeSeleccionado Is Nothing Then
            If MsgBox(refaVista.BuscarMensaje("MsgBox", "CancelarVisita"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Me.VisitaClave = refTreeNodeSeleccionado.Tag
                Me.DialogResult = Windows.Forms.DialogResult.Abort
                Me.Close()
            End If
        End If
    End Sub

    Private Sub ContextMenuVisitas_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenuVisitas.Popup
        Me.ContextMenuVisitas.MenuItems.Clear()
        Me.ContextMenuVisitas.MenuItems.Add(Me.MenuItemNuevo)
        If Not Me.TreeViewVisitas.SelectedNode Is Nothing Then
            Me.ContextMenuVisitas.MenuItems.Add(Me.MenuItemDetalles)
        End If
    End Sub

    Private Sub ButtonDetalles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDetalles.Click
        If Not bIniciando Then
            If Not Me.refTreeNodeSeleccionado Is Nothing Then
                Dim oVisitaDetalle As New FormVisitaDetalle(Me.refTreeNodeSeleccionado.Tag)
                oVisitaDetalle.ShowDialog()
                oVisitaDetalle.Dispose()
            Else
                MsgBox(refaVista.BuscarMensaje("MsgBox", "ElegirVisita"), MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub ButtonNuevaVisita_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevaVisita.Click
        Me.Nueva()
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
