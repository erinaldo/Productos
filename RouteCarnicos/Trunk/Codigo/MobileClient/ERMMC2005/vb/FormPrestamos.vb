Public Class FormPrestamos
    Inherits System.Windows.Forms.Form

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
        QuitarCtrlSeguimiento()

        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MainMenu1 Is Nothing Then Me.MainMenu1.Dispose()
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents ListViewPedidos As System.Windows.Forms.ListView
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.ListViewPedidos = New System.Windows.Forms.ListView
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
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
        Me.Panel1.Controls.Add(Me.ListViewPedidos)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(85, 264)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar.TabIndex = 3
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(5, 264)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuar.TabIndex = 4
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'ListViewPedidos
        '
        Me.ListViewPedidos.CheckBoxes = True
        Me.ListViewPedidos.FullRowSelect = True
        Me.ListViewPedidos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewPedidos.Location = New System.Drawing.Point(5, 17)
        Me.ListViewPedidos.Name = "ListViewPedidos"
        Me.ListViewPedidos.Size = New System.Drawing.Size(228, 244)
        Me.ListViewPedidos.TabIndex = 5
        Me.ListViewPedidos.View = System.Windows.Forms.View.Details
        '
        'FormPrestamos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenu1
        Me.Name = "FormPrestamos"
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
    Private blnSeleccionManual As Boolean = False
    Private bHayCambios As Boolean
#End Region

#Region "METODOS"
    Private Sub LlenarLV()
        If oDBVen.RealizarConsultaSQL("SELECT clienteclave FROM Cliente WHERE ClienteClave='" & oCliente.ClienteClave & "' AND Prestamo=1", "LlenarLV").Rows.Count = 0 Then
            MsgBox(oVista.BuscarMensaje("Mensajes", "E0340"), MsgBoxStyle.Information)
            Me.Close()
            Exit Sub
        End If
        oVista.PoblarListView(Me.ListViewPedidos, oDBVen, "ListViewPedidos", "WHERE Transprod.tipo=1 AND Transprod.tipopedido <> 0 AND Transprod.tipopedido <> 2 AND TransProd.TipoFase<>0 AND Visita.clienteclave='" & oCliente.ClienteClave & "' AND Visita.visitaclave='" & sVisitaClave & "'")
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

    Private Sub SeleccionarElementoMarcado(ByRef LV As ListView, ByVal iIndice As Integer)
        With LV
            If .Items.Count > 0 Then
                For i As Integer = 0 To .Items.Count - 1
                    If i = iIndice Then
                        .Items(i).Selected = True
                    Else
                        .Items(i).Checked = False
                    End If
                Next
            End If
        End With
    End Sub
#End Region

#Region "FUNCIONES"
    Private Sub QuitarCtrlSeguimiento()
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
    End Sub

    Private Function HaySeleccion(ByVal LV As ListView) As Boolean
        If LV.Items.Count > 0 Then
            Dim i As Integer
            For i = 0 To LV.Items.Count - 1
                If LV.Items(i).Checked Then
                    sTransProdId = Me.ListViewPedidos.Items(i).SubItems(4).Text
                    Return True
                End If
            Next
        End If
        sTransProdId = String.Empty
        Return False
    End Function
#End Region

#Region "EVENTOS"
    Private Sub FormPrestamos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        Me.ListViewPedidos.Activation = oApp.TipoSeleccion
        bHayCambios = False
        If Not Vista.Buscar("FormPrestamos", oVista) Then
            Exit Sub
        End If
        oVista.CrearListView(Me.ListViewPedidos, "ListViewPedidos")
        oVista.ColocarEtiquetasForma(Me)
        LlenarLV()
        sTransProdId = String.Empty
        bFin = True

        With ListViewPedidos
            If .Items.Count > 0 Then
                .Items(0).Selected = True
                .Focus()
            Else
                MsgBox(oVista.BuscarMensaje("Mensajes", "E0557"), MsgBoxStyle.Information)
                Me.Close()
            End If
        End With
        bHayCambios = False
        [Global].HabilitarMenuItem(Me.MainMenu1, True)
    End Sub

    Private Sub TerminarVisita()
        ButtonRegresar_Click(Nothing, Nothing)
    End Sub

    Private Sub Salir()
        If bHayCambios Then
            If MsgBox(oVista.BuscarMensaje("Mensajes", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.Salir()
    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        If Me.ListViewPedidos.Items.Count > 0 Then
            If HaySeleccion(Me.ListViewPedidos) Then
                QuitarCtrlSeguimiento()

                Dim oPrestamosDetalle As New FormPrestamosDetalle(sTransProdId, oVista, oCliente.ClienteClave)
                oPrestamosDetalle.ShowDialog()
                'Me.LlenarLV()
                oPrestamosDetalle.Dispose()
                Me.Close()
            Else
                MsgBox(oVista.BuscarMensaje("Mensajes", "E0046"), MsgBoxStyle.Information)
            End If
        Else
            MsgBox(oVista.BuscarMensaje("Mensajes", "E0046"), MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub ListViewPedidos_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewPedidos.ItemCheck
        If blnSeleccionManual Then Exit Sub
        blnSeleccionManual = True
        MarcarElemento(ListViewPedidos, e.NewValue, e.Index)
        blnSeleccionManual = False
        If ListViewPedidos.SelectedIndices.Count <= 0 Then Exit Sub
        If e.NewValue = CheckState.Unchecked Then
            blnSeleccionManual = True
            ListViewPedidos.Items(ListViewPedidos.SelectedIndices(0)).Selected = False
            sTransProdId = String.Empty
            blnSeleccionManual = False
        Else
            sTransProdId = Me.ListViewPedidos.Items(Me.ListViewPedidos.SelectedIndices(0)).SubItems(4).Text
        End If
        bHayCambios = True
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Me.Salir()
    End Sub
#End Region

    Private Sub ListViewPedidos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewPedidos.SelectedIndexChanged
        If blnSeleccionManual Then Exit Sub
        If ListViewPedidos.SelectedIndices.Count <= 0 Then Exit Sub
        blnSeleccionManual = True
        MarcarElemento(ListViewPedidos, CheckState.Checked, ListViewPedidos.SelectedIndices(0))
        blnSeleccionManual = False
        bHayCambios = True
    End Sub
End Class
