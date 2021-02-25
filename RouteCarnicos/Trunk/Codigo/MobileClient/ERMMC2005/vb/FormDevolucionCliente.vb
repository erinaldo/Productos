Public Class FormDevolucionCliente
    Inherits System.Windows.Forms.Form
    ''Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    'Friend WithEvents ButtonContinuar As System.Windows.Forms.Button

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        oMMDA = paroModuloMovDetActual
        oCliente = paroCliente
        VisitaClave = parsVisitaClave

        Me.ListViewDevoluciones.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        QuitarCtrlSeguimiento()

        If Not IsNothing(Me.MenuItemRegresar) Then MenuItemRegresar.Dispose()
        If Not IsNothing(Me.MainMenu1) Then MainMenu1.Dispose()
        If Not IsNothing(Me.ListViewDevoluciones) Then
            If Me.ListViewDevoluciones.Columns.Count > 0 Then
                Me.ListViewDevoluciones.Columns.Clear()
            End If
            Me.ListViewDevoluciones.Dispose()
        End If
        Me.oCliente = Nothing
        Me.oVista = Nothing
        Me.oMMDA = Nothing
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents ListViewDevoluciones As System.Windows.Forms.ListView
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
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
        Me.MenuItemRegresar.Text = "Regresar"
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
        Me.ButtonEliminar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ButtonEliminar.Location = New System.Drawing.Point(165, 264)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonEliminar.TabIndex = 4
        Me.ButtonEliminar.Text = "ButtonEliminar"
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ButtonRegresar.Location = New System.Drawing.Point(84, 264)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar.TabIndex = 5
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ButtonContinuar.Location = New System.Drawing.Point(3, 264)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuar.TabIndex = 6
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'ListViewDevoluciones
        '
        Me.ListViewDevoluciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewDevoluciones.CheckBoxes = True
        Me.ListViewDevoluciones.FullRowSelect = True
        Me.ListViewDevoluciones.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewDevoluciones.Location = New System.Drawing.Point(5, 17)
        Me.ListViewDevoluciones.Name = "ListViewDevoluciones"
        Me.ListViewDevoluciones.Size = New System.Drawing.Size(230, 244)
        Me.ListViewDevoluciones.TabIndex = 7
        Me.ListViewDevoluciones.View = System.Windows.Forms.View.Details
        '
        'FormDevolucionCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenu1
        Me.Name = "FormDevolucionCliente"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "VARIABLES"
    Private oVista As Vista
    Private oCliente As Cliente
    Private oMMDA As Modulos.GrupoModuloMovDetalle
    Private sFolioItem, sIdItem, VisitaClave As String
    Private blnInicio As Boolean = False
#End Region

#Region "MIS METODOS"
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

    Private Sub LlenarLV()
        oVista.PoblarListView(ListViewDevoluciones, oDBVen, "ListViewDevoluciones", "WHERE Tipo=3 and visita.clienteclave='" & oCliente.ClienteClave & "' AND visita.visitaclave='" & VisitaClave & "' and TransProdId not in (select TransProdId from TrpTpd) ")
        sFolioItem = Nothing
        sIdItem = Nothing
    End Sub

    Private Sub Continuar()
        QuitarCtrlSeguimiento()

        If HaySeleccion(ListViewDevoluciones) Then
            Dim TF As Integer = TipoFaseRegistro(sIdItem)
            If TF = 1 Then
                Dim oFDCD As FormDevolucionClienteDetalle

                If EsConsignacion(sIdItem) Then
                    oFDCD = New FormDevolucionClienteDetalle(sFolioItem, sIdItem, VisitaClave, FormDevolucionClienteDetalle.Movimiento.Modificar, FormDevolucionClienteDetalle.Modo.SoloLectura, oMMDA, False, oCliente)
                    oFDCD.EsConsignacion = True
                Else
                    oFDCD = New FormDevolucionClienteDetalle(sFolioItem, sIdItem, VisitaClave, FormDevolucionClienteDetalle.Movimiento.Modificar, FormDevolucionClienteDetalle.Modo.Modificable, oMMDA, False, oCliente)
                End If
                oFDCD.ShowDialog()
                oFDCD.Dispose()
                oFDCD = Nothing
            Else
                'MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "E0036"), DevuelveDescripcionFase(TF)), MsgBoxStyle.Information)
                MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "E0036"), ValorReferencia.BuscarEquivalente("TRPFASE", TF)), MsgBoxStyle.Information)
                Dim oFDCD As New FormDevolucionClienteDetalle(sFolioItem, sIdItem, VisitaClave, FormDevolucionClienteDetalle.Movimiento.Modificar, FormDevolucionClienteDetalle.Modo.SoloLectura, oMMDA, False, oCliente)
                oFDCD.ShowDialog()
                oFDCD.Dispose()
                oFDCD = Nothing
            End If
        Else
            sFolioItem = Folio.Obtener(oMMDA.ModuloMovDetalleClave)
            If sFolioItem <> "" Then
                Dim oFDCD As New FormDevolucionClienteDetalle(sFolioItem, oApp.KEYGEN(2), VisitaClave, FormDevolucionClienteDetalle.Movimiento.Capturar, FormDevolucionClienteDetalle.Modo.Modificable, oMMDA, True, oCliente)
                oFDCD.ShowDialog()
                oFDCD.Dispose()
                oFDCD = Nothing
            End If
        End If
        Me.Close()
        'LlenarLV()
    End Sub

    Private Function EsConsignacion(ByVal ID As String) As Boolean
        Dim iTrpTpd As Integer = oDBVen.RealizarScalarSQL("SELECT COUNT(*) FROM TrpTpd WHERE TransProdId='" & ID & "'")
        Return (iTrpTpd > 0)
    End Function
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

    Private Function TipoFaseRegistro(ByVal ID As String) As Integer
        Dim DT As DataTable = oDBVen.RealizarConsultaSQL("select tipofase from transprod where transprodid='" & ID & "'", "transprod")
        Dim nTipoFase As Integer = DT.Rows(0).Item(0)
        DT.Dispose()
        Return nTipoFase
    End Function

    'Private Function DevuelveDescripcionFase(ByVal VAVClave As Integer) As String
    '    Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select descripcion from vavdescripcion where varcodigo='TRPFASE' and vavclave=" & VAVClave, "fase")
    '    Return Dt.Rows(0).Item("descripcion")
    'End Function

#End Region

#Region "FormDevolucionCliente"
    Private Sub FormDevolucionCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        ListViewDevoluciones.Activation = oApp.TipoSeleccion
        If Not Vista.Buscar("FormDevolucionCliente", oVista) Then
            Exit Sub
        End If
        oVista.CrearListView(ListViewDevoluciones, "ListViewDevoluciones")
        LlenarLV()
        oVista.ColocarEtiquetasForma(Me)

        With ListViewDevoluciones
            If .Items.Count > 0 Then
                .Focus()
                .Items(0).Selected = True
            Else
                Continuar()
            End If
        End With
        [Global].HabilitarMenuItem(MainMenu1, True)
    End Sub

    Private Sub TerminarVisita()
        ButtonRegresar_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Me.Close()
    End Sub

    Private Sub ListViewDevoluciones_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewDevoluciones.ItemCheck
        If blnInicio Then Exit Sub
        Try
            blnInicio = True
            MarcarElemento(ListViewDevoluciones, e.NewValue, e.Index)
            blnInicio = False
            If e.NewValue = CheckState.Unchecked Then
                'ListViewDevoluciones.Items(ListViewDevoluciones.SelectedIndices(0)).Selected = False
                sFolioItem = Nothing
                sIdItem = Nothing
            Else
                If ListViewDevoluciones.SelectedIndices.Count = 0 Then Exit Sub
                blnInicio = True
                Dim refListViewItemSel As ListViewItem = ListViewDevoluciones.Items(ListViewDevoluciones.SelectedIndices(0))
                sFolioItem = refListViewItemSel.Text
                sIdItem = refListViewItemSel.SubItems(3).Text
                blnInicio = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.Close()
    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        Continuar()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If HaySeleccion(ListViewDevoluciones) Then
            If Not EsConsignacion(sIdItem) Then
                QuitarCtrlSeguimiento()

                Dim oFDCD As New FormDevolucionClienteDetalle(sFolioItem, sIdItem, VisitaClave, FormDevolucionClienteDetalle.Movimiento.Eliminar, FormDevolucionClienteDetalle.Modo.Modificable, oMMDA, False, oCliente)
                oFDCD.ShowDialog()
                oFDCD.Dispose()
                oFDCD = Nothing
                If oVendedor.motconfiguracion.Secuencia Then
                    If ctrlSeguimiento.MenuItemSeleccionado Then
                        Me.Close()
                        Exit Sub
                    Else
                        LlenarLV()
                    End If
                Else
                    LlenarLV()
                End If

                If oVendedor.motconfiguracion.Secuencia Then
                    Me.Controls.Add(ctrlSeguimiento)
                    Me.Panel1.SendToBack()
                    ctrlSeguimiento.CrearMenuItem(Me.MainMenu1)
                    AddHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
                    AddHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
                    ctrlSeguimiento.Iniciar()
                    [Global].HabilitarMenuItem(Me.MainMenu1, True)
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

            Else
                MsgBox(oVista.BuscarMensaje("Mensajes", "E0698"), MsgBoxStyle.Information)
            End If
        Else
            MsgBox(oVista.BuscarMensaje("Mensajes", "E0046"), MsgBoxStyle.Information)
        End If
    End Sub
#End Region

    Private Sub ListViewDevoluciones_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewDevoluciones.ItemActivate
        If blnInicio Then Exit Sub
        Elegir()
    End Sub
    Private Sub Elegir()
        If ListViewDevoluciones.SelectedIndices.Count <= 0 Then Exit Sub
        Dim refListViewItemSel As ListViewItem = ListViewDevoluciones.Items(ListViewDevoluciones.SelectedIndices(0))
        blnInicio = True
        refListViewItemSel.Checked = True
        blnInicio = False
        sFolioItem = refListViewItemSel.Text
        sIdItem = refListViewItemSel.SubItems(3).Text
    End Sub
End Class
