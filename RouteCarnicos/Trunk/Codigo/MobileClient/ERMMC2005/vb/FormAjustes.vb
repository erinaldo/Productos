Public Class FormAjustes
    Inherits System.Windows.Forms.Form
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        ListViewAjustes.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)

        If Not IsNothing(Me.MenuItemRegresar) Then MenuItemRegresar.Dispose()
        If Not IsNothing(Me.MainMenu1) Then MainMenu1.Dispose()
        If Not IsNothing(Me.ListViewAjustes) Then
            If Me.ListViewAjustes.Columns.Count > 0 Then
                Me.ListViewAjustes.Columns.Clear()
            End If
            Me.ListViewAjustes.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents ListViewAjustes As System.Windows.Forms.ListView

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.ListViewAjustes = New System.Windows.Forms.ListView
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ButtonEliminar)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
        Me.Panel1.Controls.Add(Me.ListViewAjustes)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(163, 262)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonEliminar.TabIndex = 4
        Me.ButtonEliminar.Text = "ButtonEliminar"
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(83, 262)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar.TabIndex = 5
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(4, 262)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuar.TabIndex = 6
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'ListViewAjustes
        '
        Me.ListViewAjustes.CheckBoxes = True
        Me.ListViewAjustes.FullRowSelect = True
        Me.ListViewAjustes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewAjustes.Location = New System.Drawing.Point(4, 8)
        Me.ListViewAjustes.Name = "ListViewAjustes"
        Me.ListViewAjustes.Size = New System.Drawing.Size(232, 247)
        Me.ListViewAjustes.TabIndex = 7
        Me.ListViewAjustes.View = System.Windows.Forms.View.Details
        '
        'FormAjustes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenu1
        Me.Name = "FormAjustes"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "VARIABLES"
    Private oVista As Vista
    Private sFolioItem, sIdItem As String
    Private blnSeleccionManual As Boolean = False
#End Region

#Region "FUNCIONES"
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

    Private Function HayPedidosActivos() As Boolean
        Try
            Dim s As String = "select transprodid from transprod where tipo=1 and tipofase=1"
            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL(s, "pedidos_activos")
            If Dt.Rows.Count = 0 Then
                Dt.Dispose()
                Return False
            Else
                Dt.Dispose()
                Return True
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Function DevuelveTipoFase(ByVal transprodid As String) As Integer
        Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select tipofase from transprod where transprodid='" & transprodid & "'", "query")
        Dim nTipoFase As Integer = Dt.Rows(0).Item("TipoFase")
        Dt.Dispose()
        Return nTipoFase
    End Function

    Private Function DevuelveDescripcionFase(ByVal VAVClave As Integer) As String
        Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select descripcion from vavdescripcion where varcodigo='TRPFASE' and vavclave=" & VAVClave, "fase")
        Dim sDescripcion As String = Dt.Rows(0).Item("descripcion")
        Dt.Dispose()
        Return sDescripcion
    End Function

#End Region

#Region "MIS METODOS"
    Private Sub LlenarLV()
        oVista.PoblarListView(ListViewAjustes, odbVen, "ListViewAjustes", "")
        sFolioItem = Nothing
        sIdItem = Nothing
    End Sub

    Private Sub Continuar()
        If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta Then
            If HayPedidosActivos() Then
                MsgBox(oVista.BuscarMensaje("Mensajes", "E0081"), MsgBoxStyle.Information)
                Exit Sub
            End If
        End If
        If HaySeleccion(ListViewAjustes) Then
            With ListViewAjustes
                Dim TF As Integer = DevuelveTipoFase(sIdItem)
                If TF = 1 Then
                    Dim oFAD As New FormAjustesDetalle(sFolioItem, sIdItem, FormAjustesDetalle.Movimiento.Modificar, FormAjustesDetalle.Modo.Modificable, False)
                    oFAD.ShowDialog()
                    oFAD.Dispose()
                    oFAD = Nothing
                Else
                    MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "E0047"), DevuelveDescripcionFase(TF)), MsgBoxStyle.Information)
                    Dim oFAD As New FormAjustesDetalle(sFolioItem, sIdItem, FormAjustesDetalle.Movimiento.Modificar, FormAjustesDetalle.Modo.SoloLectura, False)
                    oFAD.ShowDialog()
                    oFAD.Dispose()
                    oFAD = Nothing
                End If
                'LlenarLV()
            End With
            Me.Close()
        Else
            Dim sFolio As String = String.Empty
            sFolio = Folio.Obtener(, ServicesCentral.TiposModulosMovDet.Ajustes)
            If sFolio <> "" Then
                Dim oFAD As New FormAjustesDetalle(sFolio, oApp.KEYGEN(1), FormAjustesDetalle.Movimiento.Capturar, FormAjustesDetalle.Modo.Modificable, True)
                oFAD.ShowDialog()
                oFAD.Dispose()
                oFAD = Nothing
                'LlenarLV()
                'If ListViewAjustes.Items.Count = 0 Then
                Me.Close()
                'End If
            End If
        End If
    End Sub

#End Region

#Region "FormAjustes"
    Private Sub FormAjustes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        ListViewAjustes.Activation = oApp.TipoSeleccion
        If Not Vista.Buscar("FormAjustes", oVista) Then
            Exit Sub
        End If
        oVista.CrearListView(ListViewAjustes, "ListViewAjustes")
        LlenarLV()
        oVista.ColocarEtiquetasForma(Me)

        With ListViewAjustes
            If .Items.Count > 0 Then
                '.Items(0).Selected = True
                .Focus()
            Else
                Continuar()
            End If
        End With
    End Sub

    Private Sub ListViewAjustes_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewAjustes.ItemCheck
        Try
            If blnSeleccionManual Then Exit Sub
            blnSeleccionManual = True
            MarcarElemento(ListViewAjustes, e.NewValue, e.Index)
            blnSeleccionManual = False
            If ListViewAjustes.SelectedIndices.Count <= 0 Then Exit Sub
            If e.NewValue = CheckState.Unchecked Then
                blnSeleccionManual = True
                ListViewAjustes.Items(ListViewAjustes.SelectedIndices(0)).Selected = False
                blnSeleccionManual = False
                sFolioItem = Nothing
                sIdItem = Nothing
            Else
                sFolioItem = ListViewAjustes.Items(ListViewAjustes.SelectedIndices(0)).Text
                sIdItem = ListViewAjustes.Items(ListViewAjustes.SelectedIndices(0)).SubItems(3).Text
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ListViewAjustes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewAjustes.SelectedIndexChanged
        If blnSeleccionManual Then Exit Sub
        Try
            If ListViewAjustes.SelectedIndices.Count <= 0 Then Exit Sub
            blnSeleccionManual = True
            MarcarElemento(ListViewAjustes, CheckState.Checked, ListViewAjustes.SelectedIndices(0))
            blnSeleccionManual = False
            sFolioItem = ListViewAjustes.Items(ListViewAjustes.SelectedIndices(0)).Text
            sIdItem = ListViewAjustes.Items(ListViewAjustes.SelectedIndices(0)).SubItems(3).Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        Continuar()
    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.Close()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If HaySeleccion(ListViewAjustes) Then

            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select enviado from transprod where transprodid='" & sIdItem & "'", "Consulta")
            If Not IsDBNull(Dt.Rows(0)("enviado")) AndAlso Dt.Rows(0)("enviado") Then
                MsgBox(oVista.BuscarMensaje("Mensajes", "E0596"), MsgBoxStyle.Information)
            Else

                With ListViewAjustes
                    Dim oFAD As New FormAjustesDetalle(sFolioItem, sIdItem, FormAjustesDetalle.Movimiento.Eliminar, FormAjustesDetalle.Modo.Modificable, False)
                    oFAD.ShowDialog()
                    oFAD.Dispose()
                    oFAD = Nothing
                    LlenarLV()
                End With
            End If
            Dt.Dispose()
        Else
            MsgBox(oVista.BuscarMensaje("Mensajes", "E0046"), MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Me.Close()
    End Sub
#End Region


End Class
