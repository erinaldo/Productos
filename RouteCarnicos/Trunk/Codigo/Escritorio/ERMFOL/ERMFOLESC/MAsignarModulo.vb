Imports System.Windows.Forms
Imports System.Drawing

Public Class MAsignarModulo
    Inherits FormasBase.Mantenimiento01

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents gbModulos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents tcModulos As System.Windows.Forms.TreeView
    Friend WithEvents gbFolios As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents tcFolios As System.Windows.Forms.TreeView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MAsignarModulo))
        Me.gbModulos = New Janus.Windows.EditControls.UIGroupBox
        Me.tcModulos = New System.Windows.Forms.TreeView
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.gbFolios = New Janus.Windows.EditControls.UIGroupBox
        Me.tcFolios = New System.Windows.Forms.TreeView
        CType(Me.gbModulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbModulos.SuspendLayout()
        CType(Me.gbFolios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFolios.SuspendLayout()
        Me.SuspendLayout()
        '
        'EbClave
        '
        Me.EbClave.Location = New System.Drawing.Point(64, 452)
        Me.EbClave.Size = New System.Drawing.Size(8, 20)
        Me.EbClave.Visible = False
        '
        'lbClave
        '
        Me.lbClave.Location = New System.Drawing.Point(48, 448)
        Me.lbClave.Size = New System.Drawing.Size(12, 20)
        Me.lbClave.Visible = False
        '
        'BtAceptar
        '
        Me.BtAceptar.Location = New System.Drawing.Point(452, 488)
        '
        'BtCancelar
        '
        Me.BtCancelar.Location = New System.Drawing.Point(564, 488)
        '
        'lbLinea
        '
        Me.lbLinea.Location = New System.Drawing.Point(40, 456)
        Me.lbLinea.Size = New System.Drawing.Size(12, 3)
        Me.lbLinea.Visible = False
        '
        'gbModulos
        '
        Me.gbModulos.Controls.Add(Me.tcModulos)
        Me.gbModulos.Location = New System.Drawing.Point(8, 8)
        Me.gbModulos.Name = "gbModulos"
        Me.gbModulos.Size = New System.Drawing.Size(316, 468)
        Me.gbModulos.TabIndex = 17
        Me.gbModulos.Text = "Módulos"
        Me.gbModulos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'tcModulos
        '
        Me.tcModulos.AllowDrop = True
        Me.tcModulos.HideSelection = False
        Me.tcModulos.ImageIndex = 0
        Me.tcModulos.ImageList = Me.ImageList1
        Me.tcModulos.Location = New System.Drawing.Point(12, 24)
        Me.tcModulos.Name = "tcModulos"
        Me.tcModulos.SelectedImageIndex = 0
        Me.tcModulos.Size = New System.Drawing.Size(292, 432)
        Me.tcModulos.TabIndex = 2
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        '
        'gbFolios
        '
        Me.gbFolios.Controls.Add(Me.tcFolios)
        Me.gbFolios.Location = New System.Drawing.Point(352, 8)
        Me.gbFolios.Name = "gbFolios"
        Me.gbFolios.Size = New System.Drawing.Size(316, 468)
        Me.gbFolios.TabIndex = 18
        Me.gbFolios.Text = "Folios"
        Me.gbFolios.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'tcFolios
        '
        Me.tcFolios.AllowDrop = True
        Me.tcFolios.HideSelection = False
        Me.tcFolios.ImageIndex = 0
        Me.tcFolios.ImageList = Me.ImageList1
        Me.tcFolios.Location = New System.Drawing.Point(12, 24)
        Me.tcFolios.Name = "tcFolios"
        Me.tcFolios.SelectedImageIndex = 0
        Me.tcFolios.Size = New System.Drawing.Size(292, 432)
        Me.tcFolios.TabIndex = 5
        '
        'MAsignarModulo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(678, 520)
        Me.Controls.Add(Me.gbFolios)
        Me.Controls.Add(Me.gbModulos)
        Me.Name = "MAsignarModulo"
        Me.Controls.SetChildIndex(Me.EbClave, 0)
        Me.Controls.SetChildIndex(Me.lbClave, 0)
        Me.Controls.SetChildIndex(Me.BtCancelar, 0)
        Me.Controls.SetChildIndex(Me.BtAceptar, 0)
        Me.Controls.SetChildIndex(Me.lbLinea, 0)
        Me.Controls.SetChildIndex(Me.gbModulos, 0)
        Me.Controls.SetChildIndex(Me.gbFolios, 0)
        CType(Me.gbModulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbModulos.ResumeLayout(False)
        CType(Me.gbFolios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFolios.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Variables"
    Private Shared oInstance As MAsignarModulo = Nothing

    Private oConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private oAcceso As LbAcceso.cAcceso
    Private oMensaje As BASMENLOG.CMensaje
    Private oFolio As ERMFOLLOG.cFolio
    Private oModuloTerm As ERMMOTLOG.cModuloTerm
    Private oModuloMov As ERMMOTLOG.cModuloMov
    Private oModuloMovDetalle As ERMMOTLOG.cModuloMovDetalle

    'Private NodeToCancel As TreeNode
    Private NodeToDrag As TreeNode
    Private dragBoxFromMouseDown As Rectangle
    Private screenOffset As Point

    Private bCerrar As Boolean = False
    Private bHuboCambios As Boolean = False
#End Region

#Region "Funciones Generales"
    Public Shared Function Instance() As MAsignarModulo
        If oInstance Is Nothing OrElse oInstance.IsDisposed = True Then
            oInstance = New MAsignarModulo
        End If
        oInstance.BringToFront()
        Return oInstance
    End Function

    Sub Inicio(ByVal pvAcceso As LbAcceso.cAcceso)
        oAcceso = pvAcceso
        oMensaje = New BASMENLOG.CMensaje
        oFolio = New ERMFOLLOG.cFolio
        oModuloTerm = New ERMMOTLOG.cModuloTerm
        oModuloMov = New ERMMOTLOG.cModuloMov
        oModuloMovDetalle = New ERMMOTLOG.cModuloMovDetalle

        tcModulos.Nodes.Clear()
        tcFolios.Nodes.Clear()

        If Me.ShowDialog = Windows.Forms.DialogResult.OK Then
            LbConexion.cConexion.Instancia.ConfirmarTran()
        Else
            LbConexion.cConexion.Instancia.DeshacerTran()
        End If
        Me.Dispose()
    End Sub

    Private Sub MAsignarModulo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
#If DEBUG Then
        'oConexion.Conectar("Provider=SQLOLEDB;Data Source=RAFIKI;user id=sa;password='dbsa';initial catalog=ROUTE")
        oConexion.Conectar("Provider=SQLOLEDB;Data Source=192.168.0.72\sql2008;user id=sa;password=dbsa;initial catalog=jolla2")
        oMensaje = New BASMENLOG.CMensaje
        oMensaje.LlenarDataSet()
        oMensaje = New BASMENLOG.CMensaje
        oFolio = New ERMFOLLOG.cFolio
        oModuloTerm = New ERMMOTLOG.cModuloTerm
        oModuloMov = New ERMMOTLOG.cModuloMov
        oModuloMovDetalle = New ERMMOTLOG.cModuloMovDetalle
        oAcceso = New LbAcceso.cAcceso
        oAcceso.Crear = True
        oAcceso.Eliminar = True
        oAcceso.Modificar = True
        oAcceso.Leer = True
        lbGeneral.cParametros.UsuarioID = "Admin"
#End If

        Call ConfigurarTitulos()
        Call Actualizar()
        If Not oAcceso.Modificar Then
            tcFolios.AllowDrop = False
            BtAceptar.Visible = False
            BtCancelar.Text = oMensaje.RecuperarDescripcion("BTRegresar")
            BtCancelar.Icon = BtAceptar.Icon
            Me.Text = oMensaje.RecuperarDescripcion("ERMFOLESC_CAsignarModulo")
        End If
    End Sub

    Private Sub ConfigurarTitulos()
        Dim vlToolTip As New Windows.Forms.ToolTip

        Me.Text = oMensaje.RecuperarDescripcion("ERMFOLESC_MAsignarModulo")

        gbModulos.Text = oMensaje.RecuperarDescripcion("ERMFOLESC_MAsignarModulo_gbModulos")
        gbFolios.Text = oMensaje.RecuperarDescripcion("ERMFOLESC_MAsignarModulo_gbFolios")

        BtAceptar.Text = oMensaje.RecuperarDescripcion("btAceptar")
        BtCancelar.Text = oMensaje.RecuperarDescripcion("btCancelar")

        vlToolTip.SetToolTip(BtAceptar, oMensaje.RecuperarDescripcion("btAceptarT"))
        If Not oAcceso.Modificar Then
            vlToolTip.SetToolTip(BtCancelar, oMensaje.RecuperarDescripcion("btRegresar"))
        Else
            vlToolTip.SetToolTip(BtCancelar, oMensaje.RecuperarDescripcion("btCancelarT"))
        End If
    End Sub

    Private Sub Actualizar()
        Dim ldtMOD As DataTable
        Dim ldtMOM As DataTable
        Dim ldtMMD As DataTable
        Dim ldtFOL As DataTable


        ldtMOD = oModuloTerm.Tabla.Recuperar("TipoEstado=1 AND Baja=0")
        For Each ldrMOD As DataRow In ldtMOD.Rows
            Dim ltnMODNodo As New TreeNode
            Dim lMODArray(2) As String

            ltnMODNodo.Text = ldrMOD!Nombre
            lMODArray(0) = "MOD"
            lMODArray(1) = ldrMOD!ModuloClave
            lMODArray(2) = ""
            ltnMODNodo.Tag = lMODArray

            ltnMODNodo.ImageIndex = 1
            ltnMODNodo.SelectedImageIndex = 1

            ldtMOM = oModuloMov.Tabla.Recuperar("*", "ModuloClave='" & ldrMOD!ModuloClave & "' AND TipoEstado=1 AND Baja=0")
            For Each ldrMOM As DataRow In ldtMOM.Rows
                Dim ltnMOMNodo As New TreeNode
                Dim lMOMArray(2) As String

                ltnMOMNodo.Text = ldrMOM!Nombre
                lMOMArray(0) = "MOM"
                lMOMArray(1) = ldrMOM!ModuloMovClave
                lMOMArray(2) = ""
                ltnMOMNodo.Tag = lMOMArray

                ltnMOMNodo.ImageIndex = 1
                ltnMOMNodo.SelectedImageIndex = 1

                ldtMMD = oModuloMovDetalle.Tabla.Recuperar("*", "ModuloClave='" & ldrMOD!ModuloClave & "' AND ModuloMovClave='" & ldrMOM!ModuloMovClave & "' AND TipoEstado=1 AND Baja=0")
                For Each ldrMMD As DataRow In ldtMMD.Rows
                    Dim ltnMMDNodo As New TreeNode
                    Dim lMMDArray(2) As String

                    ltnMMDNodo.Text = ldrMMD!Nombre
                    lMMDArray(0) = "MMD"
                    lMMDArray(1) = ldrMMD!ModuloMovDetalleClave
                    lMMDArray(2) = ""
                    ltnMMDNodo.Tag = lMMDArray

                    ltnMMDNodo.ImageIndex = 1
                    ltnMMDNodo.SelectedImageIndex = 1
                    ltnMOMNodo.Nodes.Add(ltnMMDNodo)
                Next
                ltnMODNodo.Nodes.Add(ltnMOMNodo)
            Next
            tcModulos.Nodes.Add(ltnMODNodo)
        Next



        ldtFOL = oFolio.Tabla.Recuperar("TipoEstado=1")
        For Each ldrFOL As DataRow In ldtFOL.Rows
            Dim ltnFOLNodo As New TreeNode
            Dim lFOLArray(2) As String

            ltnFOLNodo.Text = ldrFOL!Descripcion
            lFOLArray(0) = "FOL"
            lFOLArray(1) = ldrFOL!FolioId
            lFOLArray(2) = "N" 'N=No Modificado
            ltnFOLNodo.Tag = lFOLArray

            ltnFOLNodo.ImageIndex = 0
            ltnFOLNodo.SelectedImageIndex = 0

            If Not IsDBNull(ldrFOL!ModuloMovDetalleClave) Then
                Dim ltnMMDNodo As New TreeNode
                Dim ldrMMD As DataRow
                Dim lMMDArray(2) As String

                ldrMMD = oModuloMovDetalle.Tabla.Recuperar("*", "ModuloMovDetalleClave='" & ldrFOL!ModuloMovDetalleClave & "'").Rows(0)

                lMMDArray(0) = "MMD"
                lMMDArray(1) = ldrMMD!ModuloMovDetalleClave
                lMMDArray(2) = "U" 'Ya Existe en DB
                ltnMMDNodo.Tag = lMMDArray
                ltnMMDNodo.Text = ldrMMD!Nombre

                ltnMMDNodo.ImageIndex = 1
                ltnMMDNodo.SelectedImageIndex = 1

                ltnFOLNodo.Nodes.Add(ltnMMDNodo)
            End If
            tcFolios.Nodes.Add(ltnFOLNodo)
        Next

    End Sub
#End Region

#Region "Eventos"
    Private Sub TreesView_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tcModulos.MouseDown, tcFolios.MouseDown
        NodeToDrag = sender.GetNodeAt(e.X, e.Y)
        If Not NodeToDrag Is Nothing Then
            If NodeToDrag.Tag(0) = "MMD" Then
                If sender.Name = "tcFolios" Then
                    If NodeToDrag.Tag(2) = "U" Then
                        dragBoxFromMouseDown = Rectangle.Empty
                        NodeToDrag = Nothing
                    Else
                        Dim dragSize As Size = SystemInformation.DragSize
                        dragBoxFromMouseDown = New Rectangle(New Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize)
                    End If
                Else
                    Dim dragSize As Size = SystemInformation.DragSize
                    dragBoxFromMouseDown = New Rectangle(New Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize)
                End If
            Else
                dragBoxFromMouseDown = Rectangle.Empty
                NodeToDrag = Nothing
            End If
        Else
            dragBoxFromMouseDown = Rectangle.Empty
            NodeToDrag = Nothing
        End If
    End Sub

    Private Sub TreesView_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tcModulos.MouseMove, tcFolios.MouseMove
        If ((e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left) Then
            If (Rectangle.op_Inequality(dragBoxFromMouseDown, Rectangle.Empty) And _
                Not dragBoxFromMouseDown.Contains(e.X, e.Y)) And Not NodeToDrag Is Nothing Then

                screenOffset = SystemInformation.WorkingArea.Location
                sender.DoDragDrop(NodeToDrag, DragDropEffects.All)
                sender.SelectedNode = NodeToDrag
            End If
        End If
    End Sub

    Private Sub TreesView_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tcModulos.DragOver, tcFolios.DragOver
        Dim vlNodoOrigen As TreeNode
        Dim vlNodoDestino As TreeNode
        Dim vlPoint As Point = sender.PointToClient(New Point(e.X, e.Y))

        If Not (e.Data.GetDataPresent(GetType(TreeNode))) Then
            e.Effect = DragDropEffects.None
            Return
        End If

        vlNodoOrigen = e.Data.GetData(GetType(TreeNode))

        If sender.Name = "tcFolios" Then
            vlNodoDestino = sender.GetNodeAt(vlPoint.X, vlPoint.Y)
            If vlNodoDestino Is Nothing Then
                Exit Sub
            End If

            sender.focus()
            If vlNodoDestino.Tag(0) = "FOL" Then
                'vlNodoDestino.Expand()
                sender.SelectedNode = vlNodoDestino
                e.Effect = DragDropEffects.Move
            ElseIf vlNodoDestino.Tag(0) = "MMD" Then
                sender.SelectedNode = vlNodoDestino.Parent
                e.Effect = DragDropEffects.Move
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            vlNodoDestino = tcModulos.Nodes(0)
            sender.SelectedNode = Nothing
            sender.focus()
            If vlNodoDestino.TreeView.Name = "tcModulos" And vlNodoOrigen.TreeView.Name = "tcModulos" Then
                e.Effect = DragDropEffects.None
            Else
                e.Effect = DragDropEffects.Move
            End If
        End If
    End Sub

    Private Sub TreesView_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tcModulos.DragDrop, tcFolios.DragDrop
        Dim vlNodoOrigen As TreeNode
        Dim vlNodoDestino As TreeNode
        Dim vlPoint As Point = sender.PointToClient(New Point(e.X, e.Y))

        If e.Effect <> DragDropEffects.Move Then
            Exit Sub
        End If

        If e.Data.GetDataPresent(GetType(TreeNode)) = False Then
            Exit Sub
        End If
        vlNodoOrigen = e.Data.GetData(GetType(TreeNode))

        If sender.Name = "tcModulos" Then
            Try
                oFolio.Recuperar(vlNodoOrigen.Parent.Tag(1))
                oFolio.Bloquear(lbGeneral.cParametros.UsuarioID)
            Catch ex As LbControlError.cError
                ex.Mostrar()
                Exit Sub
            End Try
            vlNodoOrigen.Parent.Tag(2) = "S"
            vlNodoOrigen.Remove()
        Else
            vlNodoDestino = sender.GetNodeAt(vlPoint.X, vlPoint.Y)
            If vlNodoDestino Is Nothing Then
                Exit Sub
            End If

            If vlNodoOrigen Is vlNodoDestino Then
                Exit Sub
            End If

            If vlNodoDestino.Tag(0) = "MMD" Then
                vlNodoDestino = vlNodoDestino.Parent
            End If

            If vlNodoDestino.Tag(0) = "FOL" Then
                If vlNodoDestino.Nodes.Count > 0 Then
                    If vlNodoDestino.Nodes(0).Tag(1) = vlNodoOrigen.Tag(1) Then
                        MsgBox(oMensaje.RecuperarDescripcion("I0042", New String() {oMensaje.RecuperarDescripcion("XModulo2"), oMensaje.RecuperarDescripcion("XFolio")}), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                    Else
                        MsgBox(oMensaje.RecuperarDescripcion("I0041"), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                    End If
                    Exit Sub
                End If
                Dim vlNodoClone As New TreeNode

                Try
                    oFolio.Recuperar(vlNodoDestino.Tag(1))
                    oFolio.Bloquear(lbGeneral.cParametros.UsuarioID)
                Catch ex As LbControlError.cError
                    ex.Mostrar()
                    Exit Sub
                End Try

                If vlNodoOrigen.TreeView.Name = "tcFolios" Then
                    Try
                        oFolio.Recuperar(vlNodoOrigen.Parent.Tag(1))
                        oFolio.Bloquear(lbGeneral.cParametros.UsuarioID)
                    Catch ex As LbControlError.cError
                        ex.Mostrar()
                        Exit Sub
                    End Try
                End If

                vlNodoClone = vlNodoOrigen.Clone
                vlNodoDestino.Nodes.Add(vlNodoClone)
                vlNodoDestino.Tag(2) = "S"
                vlNodoDestino.Expand()

                If vlNodoOrigen.TreeView.Name = "tcFolios" Then
                    vlNodoOrigen.Parent.Tag(2) = "S"
                    vlNodoOrigen.Remove()
                End If
            End If
        End If
        bHuboCambios = True
    End Sub

    Private Sub TreesView_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tcModulos.MouseUp, tcFolios.MouseUp
        dragBoxFromMouseDown = Rectangle.Empty
    End Sub

    Private Sub TreesView_QueryContinueDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.QueryContinueDragEventArgs) Handles tcModulos.QueryContinueDrag, tcFolios.QueryContinueDrag
        Dim lb As TreeView = CType(sender, System.Windows.Forms.TreeView)

        If Not (lb Is Nothing) Then

            Dim f As Form = lb.FindForm()

            If (((Control.MousePosition.X - screenOffset.X) < f.DesktopBounds.Left) Or _
                ((Control.MousePosition.X - screenOffset.X) > f.DesktopBounds.Right) Or _
                ((Control.MousePosition.Y - screenOffset.Y) < f.DesktopBounds.Top) Or _
                ((Control.MousePosition.Y - screenOffset.Y) > f.DesktopBounds.Bottom)) Then

                e.Action = DragAction.Cancel
            End If
        End If
    End Sub

    Private Sub BtAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAceptar.Click
        Me.DialogResult = Windows.Forms.DialogResult.None

        For Each vlNodo As TreeNode In tcFolios.Nodes
            If vlNodo.Tag(2) = "S" Then
                oFolio.Recuperar(vlNodo.Tag(1))
                If vlNodo.Nodes.Count > 0 Then
                    oFolio.ModuloMovDetalleClave = vlNodo.Nodes(0).Tag(1)
                Else
                    oFolio.ModuloMovDetalleClave = ""
                End If
                oFolio.Grabar()
            End If
        Next

        bCerrar = True
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancelar.Click
        Me.Close()
    End Sub

    Private Sub MGeneral_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not bCerrar Then
            Me.DialogResult = Windows.Forms.DialogResult.None
            If Not bCerrar And bHuboCambios Then
                If (MsgBox(oMensaje.RecuperarDescripcion("BP0001"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, oMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.No) Then
                    Exit Sub
                End If
            End If
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub
#End Region

End Class
