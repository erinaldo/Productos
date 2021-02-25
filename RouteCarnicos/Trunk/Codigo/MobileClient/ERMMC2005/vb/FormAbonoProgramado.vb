Public Class FormAbonoProgramado
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pvVisitaClave As String, ByVal pvClienteClave As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        'oVista = pvVista
        sVisitaClave = pvVisitaClave
        sClienteClave = pvClienteClave
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MainMenu1 Is Nothing Then Me.MainMenu1.Dispose()
        If Me.ListViewAbonos.Columns.Count > 0 Then
            Me.ListViewAbonos.Columns.Clear()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents ListViewAbonos As System.Windows.Forms.ListView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.ListViewAbonos = New System.Windows.Forms.ListView
        Me.Panel1 = New System.Windows.Forms.Panel
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
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(5, 262)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuar.TabIndex = 7
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(82, 262)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar.TabIndex = 6
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(161, 262)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonEliminar.TabIndex = 5
        Me.ButtonEliminar.Text = "ButtonEliminar"
        '
        'ListViewAbonos
        '
        Me.ListViewAbonos.CheckBoxes = True
        Me.ListViewAbonos.FullRowSelect = True
        Me.ListViewAbonos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewAbonos.Location = New System.Drawing.Point(5, 3)
        Me.ListViewAbonos.Name = "ListViewAbonos"
        Me.ListViewAbonos.Size = New System.Drawing.Size(228, 251)
        Me.ListViewAbonos.TabIndex = 4
        Me.ListViewAbonos.View = System.Windows.Forms.View.Details
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ListViewAbonos)
        Me.Panel1.Controls.Add(Me.ButtonEliminar)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'FormAbonoProgramado
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenu1
        Me.Name = "FormAbonoProgramado"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "VARIABLES"
    Private oVista As Vista
    Private bFin As Boolean = False
    Private sVisitaClave As String = String.Empty
    Private sClienteClave As String = String.Empty
    Private sABPId As String = String.Empty
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

    Private Function ValidaVisita(ByVal LV As ListView) As Boolean
        For i As Integer = 0 To LV.Items.Count - 1
            If LV.Items(i).Checked Then
                If LV.Items(i).SubItems(3).Text = sVisitaClave Then
                    Return True
                Else
                    Return False
                End If
            End If
        Next
    End Function
#End Region

#Region "METODOS"
    Private Sub LlenarLV()
        oVista.PoblarListView(Me.ListViewAbonos, oDBVen, "ListViewAbonos", " AND Visita.ClienteClave='" & sClienteClave & "' AND Visita.VendedorId='" & oVendedor.VendedorId & "' ")
        sABPId = String.Empty
    End Sub

    Private Sub MarcarElementoSeleccionado(ByRef LV As ListView)
        With LV
            If .SelectedIndices.Count > 0 Then
                For i As Integer = 0 To .Items.Count - 1
                    If i = .SelectedIndices(0) Then
                        .Items(i).Checked = True
                        sABPId = .Items(i).SubItems(2).Text
                    Else
                        .Items(i).Checked = False
                    End If
                Next
            End If
        End With
    End Sub

    Private Sub SeleccionarElementoMarcado(ByRef LV As ListView, ByVal iIndice As Integer)
        With LV
            If .Items.Count > 0 Then
                For i As Integer = 0 To .Items.Count - 1
                    If i = iIndice Then
                        .Items(i).Selected = True
                        sABPId = .Items(i).SubItems(2).Text
                    Else
                        .Items(i).Checked = False
                        .Items(i).Selected = False
                    End If
                Next
            End If
        End With
    End Sub

    Private Sub SeleccionarTodosElementos(ByRef LV As ListView, ByVal bValor As Boolean)
        With LV
            For i As Integer = 0 To .Items.Count - 1
                .Items(i).Checked = bValor
            Next
        End With
    End Sub

    Private Sub Continuar()
        If Me.HaySeleccion(Me.ListViewAbonos) Then
            If Me.ValidaVisita(Me.ListViewAbonos) Then
                Dim oForma As New FormAbonoProgramadoDetalle(sVisitaClave, FormAbonoProgramadoDetalle.eModo.Modificar, sABPId)
                oForma.ShowDialog()
                'LlenarLV()
                oForma.Dispose()
                oForma = Nothing
                Me.Close()
            Else
                MsgBox("No corresponde a la visita actual")
            End If
        Else
            Dim oForma As New FormAbonoProgramadoDetalle(sVisitaClave, FormAbonoProgramadoDetalle.eModo.Nuevo)
            oForma.ShowDialog()
            'LlenarLV()
            oForma.Dispose()
            oForma = Nothing
            Me.Close()
        End If
    End Sub
#End Region

#Region "EVENTOS"
    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        Continuar()
    End Sub

    Private Sub FormAbonoProgramado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        Me.ListViewAbonos.Activation = oApp.TipoSeleccion
        If Not Vista.Buscar("FormAbonoProgramado", oVista) Then
            Exit Sub
        End If
        oVista.ColocarEtiquetasForma(Me)
        oVista.CrearListView(Me.ListViewAbonos, "ListViewAbonos")
        LlenarLV()


        If ListViewAbonos.Items.Count > 0 Then
            ListViewAbonos.Items(0).Selected = True
            ListViewAbonos.Focus()
        Else
            Continuar()
        End If

        bFin = True

    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.Close()
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Me.Close()
    End Sub

    Private Sub ListViewAbonos_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewAbonos.ItemActivate
        If Not bFin Then Exit Sub
        Me.MarcarElementoSeleccionado(Me.ListViewAbonos)
    End Sub

    Private Sub ListViewAbonos_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewAbonos.ItemCheck
        If Not bFin Then Exit Sub
        'Me.SeleccionarTodosElementos(Me.ListViewAbonos, False)
        Me.SeleccionarElementoMarcado(Me.ListViewAbonos, e.Index)
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If Me.HaySeleccion(Me.ListViewAbonos) Then
            If Me.ValidaVisita(Me.ListViewAbonos) Then
                Dim oForma As New FormAbonoProgramadoDetalle(sVisitaClave, FormAbonoProgramadoDetalle.eModo.Eliminar, sABPId)
                oForma.ShowDialog()
                oForma.Dispose()
                LlenarLV()
            Else
                MsgBox("No corresponde a la visita actual")
            End If
        Else
            MsgBox(oVista.BuscarMensaje("Mensajes", "E0046"), MsgBoxStyle.Information)
        End If
    End Sub

#End Region

  
End Class
