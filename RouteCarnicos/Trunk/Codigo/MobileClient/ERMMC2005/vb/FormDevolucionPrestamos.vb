Public Class FormDevolucionPrestamos
    Inherits System.Windows.Forms.Form
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents ListViewDevoluciones As System.Windows.Forms.ListView
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        oMMDA = paroModuloMovDetActual
        oCliente = paroCliente
        sVisitaClave = parsVisitaClave
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If oVendedor.motconfiguracion.Secuencia Then
            If Not ctrlSeguimiento.Parent Is Nothing Then
                RemoveHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
                RemoveHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
                ctrlSeguimiento.QuitarMenuItem(Me.MainMenu1)
                Me.Controls.Remove(ctrlSeguimiento)
            End If
        Else
            If Not Me.MenuItemRegresar Is Nothing Then
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

        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MainMenu1 Is Nothing Then Me.MainMenu1.Dispose()
        If Not Me.ListViewDevoluciones Is Nothing Then
            If Me.ListViewDevoluciones.Columns.Count > 0 Then
                Me.ListViewDevoluciones.Columns.Clear()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.ListViewDevoluciones = New System.Windows.Forms.ListView
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
        Me.Panel1.Controls.Add(Me.ListViewDevoluciones)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(163, 264)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonEliminar.TabIndex = 4
        Me.ButtonEliminar.Text = "ButtonEliminar"
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(83, 264)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar.TabIndex = 5
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(3, 264)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuar.TabIndex = 6
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'ListViewDevoluciones
        '
        Me.ListViewDevoluciones.CheckBoxes = True
        Me.ListViewDevoluciones.FullRowSelect = True
        Me.ListViewDevoluciones.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewDevoluciones.Location = New System.Drawing.Point(4, 17)
        Me.ListViewDevoluciones.Name = "ListViewDevoluciones"
        Me.ListViewDevoluciones.Size = New System.Drawing.Size(232, 244)
        Me.ListViewDevoluciones.TabIndex = 7
        Me.ListViewDevoluciones.View = System.Windows.Forms.View.Details
        '
        'FormDevolucionPrestamos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenu1
        Me.Name = "FormDevolucionPrestamos"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "VARIABLES"
    Private oVista As Vista
    Private oCliente As Cliente
    Private oMMDA As Modulos.GrupoModuloMovDetalle
    Private sVisitaClave, sTransProdId As String
    Private bFin As Boolean = False
#End Region

#Region "METODOS"
    Private Sub LlenarLV()
        oVista.PoblarListView(Me.ListViewDevoluciones, odbVen, "ListViewDevoluciones", " AND V.ClienteClave='" & oCliente.ClienteClave & "'")
        sTransProdId = String.Empty
    End Sub

    Private Sub MarcarElementoSeleccionado(ByRef LV As ListView)
        With LV
            If .SelectedIndices.Count > 0 Then
                For i As Integer = 0 To .Items.Count - 1
                    If i = .SelectedIndices(0) Then
                        .Items(i).Checked = True
                    Else
                        .Items(i).Checked = False
                    End If
                Next
            End If
        End With
    End Sub

    Private Sub SeleccionarElementoMarcado(ByRef LV As ListView)
        With LV
            If .Items.Count > 0 Then
                For i As Integer = 0 To .Items.Count - 1
                    If .Items(i).Checked Then
                        .Items(i).Selected = True
                        Exit For
                    End If
                Next
            End If
        End With
    End Sub

    Private Sub Continuar()
        If oVendedor.motconfiguracion.Secuencia Then
            If Not ctrlSeguimiento.Parent Is Nothing Then
                RemoveHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
                RemoveHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
                ctrlSeguimiento.QuitarMenuItem(Me.MainMenu1)
                Me.Controls.Remove(ctrlSeguimiento)
            End If
        Else
            If Not Me.MenuItemRegresar Is Nothing Then
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

        If Me.HaySeleccion(Me.ListViewDevoluciones) Then
            sTransProdId = Me.ObtenerTransProdId
            Dim oFormDetalle As New FormDevolucionPrestamosDetalle(sTransProdId, oVista, oCliente, sVisitaClave, "", eModo.Modificar)
            oFormDetalle.ShowDialog()
            oFormDetalle.Dispose()
            'Me.LlenarLV()
        Else
            sTransProdId = oApp.KEYGEN(0)
            Dim sFolio As String = Folio.Obtener(, ServicesCentral.TiposModulosMovDet.DevolucionPrestamos)
            If sFolio <> "" Then
                Dim oFormDetalle As New FormDevolucionPrestamosDetalle(sTransProdId, oVista, oCliente, sVisitaClave, sFolio, eModo.Nuevo)
                oFormDetalle.ShowDialog()
                oFormDetalle.Dispose()
                'Me.LlenarLV()
            End If
        End If
        Me.Close()
    End Sub
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

    Private Function ObtenerTransProdId() As String
        With Me.ListViewDevoluciones
            For i As Integer = 0 To .Items.Count - 1
                If .Items(i).Checked Then
                    Return .Items(i).SubItems(2).Text
                End If
            Next
        End With
        Return ""
    End Function
#End Region

#Region "EVENTOS"
    Private Sub FormDevolucionPrestamos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)

        If oVendedor.motconfiguracion.Secuencia Then
            ctrlSeguimiento.AgregarControl(Me)
            Me.Panel1.SendToBack()
            ctrlSeguimiento.CrearMenuItem(Me.MainMenu1)
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

        Me.ListViewDevoluciones.Activation = oApp.TipoSeleccion
        If Not Vista.Buscar("FormDevolucionPrestamos", oVista) Then
            Exit Sub
        End If
        oVista.CrearListView(Me.ListViewDevoluciones, "ListViewDevoluciones")
        LlenarLV()
        oVista.ColocarEtiquetasForma(Me)
        sTransProdId = String.Empty
        bFin = True

        With ListViewDevoluciones
            If .Items.Count > 0 Then
                .Items(0).Selected = True
                .Focus()
            Else
                Continuar()
            End If
        End With
        [Global].HabilitarMenuItem(MainMenu1, True)
    End Sub

    Private Sub TerminarVisita()
        MenuItemRegresar_Click(Nothing, Nothing)
    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.Close()
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Me.Close()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If Me.HaySeleccion(Me.ListViewDevoluciones) Then
            sTransProdId = Me.ObtenerTransProdId
            Dim oFormDetalle As New FormDevolucionPrestamosDetalle(sTransProdId, oVista, oCliente, sVisitaClave, "", eModo.Eliminar)
            oFormDetalle.ShowDialog()
            oFormDetalle.Dispose()
            Me.LlenarLV()
        Else
            MsgBox(oVista.BuscarMensaje("Mensajes", "E0046"), MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        Continuar()
    End Sub

    Private Sub ListViewDevoluciones_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewDevoluciones.ItemCheck
        If Not bFin Then Exit Sub
        Me.SeleccionarElementoMarcado(Me.ListViewDevoluciones)
    End Sub

    Private Sub ListViewDevoluciones_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewDevoluciones.ItemActivate
        If Not bFin Then Exit Sub
        Me.MarcarElementoSeleccionado(Me.ListViewDevoluciones)
    End Sub

#End Region

End Class
