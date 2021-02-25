Public Class FormSolicitudes
    Inherits System.Windows.Forms.Form
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabControlSolicitud As System.Windows.Forms.TabControl
    Friend WithEvents TabPageSolicitud As System.Windows.Forms.TabPage
    Friend WithEvents ButtonRegresarS As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuarS As System.Windows.Forms.Button
    Friend WithEvents ListViewSolicitud As System.Windows.Forms.ListView
    Friend WithEvents TabPageDetalle As System.Windows.Forms.TabPage
    Friend WithEvents TextBoxComentario As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxConcepto As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxArea As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxPeticion As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxFolio As System.Windows.Forms.TextBox
    Friend WithEvents LabelComentario As System.Windows.Forms.Label
    Friend WithEvents LabelConcepto As System.Windows.Forms.Label
    Friend WithEvents LabelArea As System.Windows.Forms.Label
    Friend WithEvents LabelPeticion As System.Windows.Forms.Label
    Friend WithEvents LabelFolio As System.Windows.Forms.Label
    Friend WithEvents ButtonRegresarD As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuarD As System.Windows.Forms.Button
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents MenuItemEliminar As System.Windows.Forms.MenuItem

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal parsCliente As Cliente, ByVal parsVisitaClave As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        With ListViewSolicitud
            .Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
            .Activation = oApp.TipoSeleccion
            .CheckBoxes = True
        End With

        oCliente = parsCliente
        VisitaClave = parsVisitaClave
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Me.ListViewSolicitud.Columns.Count > 0 Then
            If oVendedor.motconfiguracion.Secuencia Then
                RemoveHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
                RemoveHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
                ctrlSeguimiento.QuitarMenuItem(Me.MainMenu1)
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

        If Not Me.MenuItem1 Is Nothing Then Me.MenuItem1.Dispose()
        If Not Me.MenuItemEliminar Is Nothing Then Me.MenuItemEliminar.Dispose()
        If Not Me.MainMenu1 Is Nothing Then Me.MainMenu1.Dispose()
        If Not Me.ContextMenu1 Is Nothing Then Me.ContextMenu1.Dispose()
        If Me.ListViewSolicitud.Columns.Count > 0 Then
            Me.ListViewSolicitud.Columns.Clear()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.MenuItemEliminar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TabControlSolicitud = New System.Windows.Forms.TabControl
        Me.TabPageSolicitud = New System.Windows.Forms.TabPage
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.ButtonRegresarS = New System.Windows.Forms.Button
        Me.ButtonContinuarS = New System.Windows.Forms.Button
        Me.ListViewSolicitud = New System.Windows.Forms.ListView
        Me.TabPageDetalle = New System.Windows.Forms.TabPage
        Me.TextBoxComentario = New System.Windows.Forms.TextBox
        Me.TextBoxConcepto = New System.Windows.Forms.TextBox
        Me.ComboBoxArea = New System.Windows.Forms.ComboBox
        Me.ComboBoxPeticion = New System.Windows.Forms.ComboBox
        Me.TextBoxFolio = New System.Windows.Forms.TextBox
        Me.LabelComentario = New System.Windows.Forms.Label
        Me.LabelConcepto = New System.Windows.Forms.Label
        Me.LabelArea = New System.Windows.Forms.Label
        Me.LabelPeticion = New System.Windows.Forms.Label
        Me.LabelFolio = New System.Windows.Forms.Label
        Me.ButtonRegresarD = New System.Windows.Forms.Button
        Me.ButtonContinuarD = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.TabControlSolicitud.SuspendLayout()
        Me.TabPageSolicitud.SuspendLayout()
        Me.TabPageDetalle.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = "MenuItemRegresar"
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.Add(Me.MenuItemEliminar)
        '
        'MenuItemEliminar
        '
        Me.MenuItemEliminar.Text = "MenuItemEliminar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TabControlSolicitud)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'TabControlSolicitud
        '
        Me.TabControlSolicitud.Controls.Add(Me.TabPageSolicitud)
        Me.TabControlSolicitud.Controls.Add(Me.TabPageDetalle)
        Me.TabControlSolicitud.Location = New System.Drawing.Point(0, 0)
        Me.TabControlSolicitud.Name = "TabControlSolicitud"
        Me.TabControlSolicitud.SelectedIndex = 0
        Me.TabControlSolicitud.Size = New System.Drawing.Size(242, 293)
        Me.TabControlSolicitud.TabIndex = 3
        '
        'TabPageSolicitud
        '
        Me.TabPageSolicitud.Controls.Add(Me.ButtonEliminar)
        Me.TabPageSolicitud.Controls.Add(Me.ButtonRegresarS)
        Me.TabPageSolicitud.Controls.Add(Me.ButtonContinuarS)
        Me.TabPageSolicitud.Controls.Add(Me.ListViewSolicitud)
        Me.TabPageSolicitud.Location = New System.Drawing.Point(4, 25)
        Me.TabPageSolicitud.Name = "TabPageSolicitud"
        Me.TabPageSolicitud.Size = New System.Drawing.Size(234, 264)
        Me.TabPageSolicitud.Text = "TabPageSolicitud"
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(160, 235)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonEliminar.TabIndex = 3
        Me.ButtonEliminar.Text = "ButtonEliminar"
        '
        'ButtonRegresarS
        '
        Me.ButtonRegresarS.Location = New System.Drawing.Point(84, 235)
        Me.ButtonRegresarS.Name = "ButtonRegresarS"
        Me.ButtonRegresarS.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresarS.TabIndex = 0
        Me.ButtonRegresarS.Text = "ButtonRegresarS"
        '
        'ButtonContinuarS
        '
        Me.ButtonContinuarS.Location = New System.Drawing.Point(8, 235)
        Me.ButtonContinuarS.Name = "ButtonContinuarS"
        Me.ButtonContinuarS.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuarS.TabIndex = 1
        Me.ButtonContinuarS.Text = "ButtonContinuarS"
        '
        'ListViewSolicitud
        '
        Me.ListViewSolicitud.CheckBoxes = True
        Me.ListViewSolicitud.ContextMenu = Me.ContextMenu1
        Me.ListViewSolicitud.FullRowSelect = True
        Me.ListViewSolicitud.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewSolicitud.Location = New System.Drawing.Point(8, 16)
        Me.ListViewSolicitud.Name = "ListViewSolicitud"
        Me.ListViewSolicitud.Size = New System.Drawing.Size(224, 218)
        Me.ListViewSolicitud.TabIndex = 2
        Me.ListViewSolicitud.View = System.Windows.Forms.View.Details
        '
        'TabPageDetalle
        '
        Me.TabPageDetalle.Controls.Add(Me.TextBoxComentario)
        Me.TabPageDetalle.Controls.Add(Me.TextBoxConcepto)
        Me.TabPageDetalle.Controls.Add(Me.ComboBoxArea)
        Me.TabPageDetalle.Controls.Add(Me.ComboBoxPeticion)
        Me.TabPageDetalle.Controls.Add(Me.TextBoxFolio)
        Me.TabPageDetalle.Controls.Add(Me.LabelComentario)
        Me.TabPageDetalle.Controls.Add(Me.LabelConcepto)
        Me.TabPageDetalle.Controls.Add(Me.LabelArea)
        Me.TabPageDetalle.Controls.Add(Me.LabelPeticion)
        Me.TabPageDetalle.Controls.Add(Me.LabelFolio)
        Me.TabPageDetalle.Controls.Add(Me.ButtonRegresarD)
        Me.TabPageDetalle.Controls.Add(Me.ButtonContinuarD)
        Me.TabPageDetalle.Location = New System.Drawing.Point(4, 25)
        Me.TabPageDetalle.Name = "TabPageDetalle"
        Me.TabPageDetalle.Size = New System.Drawing.Size(234, 264)
        Me.TabPageDetalle.Text = "TabPageDetalle"
        '
        'TextBoxComentario
        '
        Me.TextBoxComentario.Location = New System.Drawing.Point(112, 144)
        Me.TextBoxComentario.Multiline = True
        Me.TextBoxComentario.Name = "TextBoxComentario"
        Me.TextBoxComentario.Size = New System.Drawing.Size(112, 84)
        Me.TextBoxComentario.TabIndex = 4
        '
        'TextBoxConcepto
        '
        Me.TextBoxConcepto.Location = New System.Drawing.Point(112, 112)
        Me.TextBoxConcepto.Name = "TextBoxConcepto"
        Me.TextBoxConcepto.Size = New System.Drawing.Size(112, 23)
        Me.TextBoxConcepto.TabIndex = 3
        '
        'ComboBoxArea
        '
        Me.ComboBoxArea.Location = New System.Drawing.Point(112, 80)
        Me.ComboBoxArea.Name = "ComboBoxArea"
        Me.ComboBoxArea.Size = New System.Drawing.Size(112, 23)
        Me.ComboBoxArea.TabIndex = 2
        '
        'ComboBoxPeticion
        '
        Me.ComboBoxPeticion.Location = New System.Drawing.Point(112, 48)
        Me.ComboBoxPeticion.Name = "ComboBoxPeticion"
        Me.ComboBoxPeticion.Size = New System.Drawing.Size(112, 23)
        Me.ComboBoxPeticion.TabIndex = 1
        '
        'TextBoxFolio
        '
        Me.TextBoxFolio.Enabled = False
        Me.TextBoxFolio.Location = New System.Drawing.Point(112, 16)
        Me.TextBoxFolio.Name = "TextBoxFolio"
        Me.TextBoxFolio.Size = New System.Drawing.Size(112, 23)
        Me.TextBoxFolio.TabIndex = 0
        '
        'LabelComentario
        '
        Me.LabelComentario.Location = New System.Drawing.Point(8, 144)
        Me.LabelComentario.Name = "LabelComentario"
        Me.LabelComentario.Size = New System.Drawing.Size(100, 20)
        Me.LabelComentario.Text = "LabelComentario"
        '
        'LabelConcepto
        '
        Me.LabelConcepto.Location = New System.Drawing.Point(8, 112)
        Me.LabelConcepto.Name = "LabelConcepto"
        Me.LabelConcepto.Size = New System.Drawing.Size(100, 20)
        Me.LabelConcepto.Text = "LabelConcepto"
        '
        'LabelArea
        '
        Me.LabelArea.Location = New System.Drawing.Point(8, 80)
        Me.LabelArea.Name = "LabelArea"
        Me.LabelArea.Size = New System.Drawing.Size(100, 20)
        Me.LabelArea.Text = "LabelArea"
        '
        'LabelPeticion
        '
        Me.LabelPeticion.Location = New System.Drawing.Point(8, 48)
        Me.LabelPeticion.Name = "LabelPeticion"
        Me.LabelPeticion.Size = New System.Drawing.Size(100, 20)
        Me.LabelPeticion.Text = "LabelPeticion"
        '
        'LabelFolio
        '
        Me.LabelFolio.Location = New System.Drawing.Point(8, 16)
        Me.LabelFolio.Name = "LabelFolio"
        Me.LabelFolio.Size = New System.Drawing.Size(100, 20)
        Me.LabelFolio.Text = "LabelFolio"
        '
        'ButtonRegresarD
        '
        Me.ButtonRegresarD.Location = New System.Drawing.Point(88, 235)
        Me.ButtonRegresarD.Name = "ButtonRegresarD"
        Me.ButtonRegresarD.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresarD.TabIndex = 6
        Me.ButtonRegresarD.Text = "ButtonRegresarD"
        '
        'ButtonContinuarD
        '
        Me.ButtonContinuarD.Location = New System.Drawing.Point(8, 235)
        Me.ButtonContinuarD.Name = "ButtonContinuarD"
        Me.ButtonContinuarD.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuarD.TabIndex = 5
        Me.ButtonContinuarD.Text = "ButtonContinuarD"
        '
        'FormSolicitudes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenu1
        Me.Name = "FormSolicitudes"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.TabControlSolicitud.ResumeLayout(False)
        Me.TabPageSolicitud.ResumeLayout(False)
        Me.TabPageDetalle.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private VisitaClave As String
    Private bCambios, blnSeleccionManual, Nuevo, bContinuar As Boolean
    Private ClicBtn As Boolean = False
    Private Fin As Boolean = False
    Private oCliente As Cliente
    Private oVista As Vista
    Private SOLId As String
    Private bCargando As Boolean = True

    Private Sub FormSolicitudes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
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

        If Not Vista.Buscar("FormSolicitudes", oVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        Fin = True
        PreparaCombos()
        oVista.CrearListView(ListViewSolicitud, "ListViewSolicitud")
        oVista.PoblarListView(ListViewSolicitud, oDBVen, "ListViewSolicitud", " where visitaclave='" & VisitaClave & "' and diaclave='" & oDia.DiaActual & "'")
        oVista.ColocarEtiquetasForma(Me)
        Me.ButtonEliminar.Text = MenuItemEliminar.Text
        Application.DoEvents()
        Nuevo = True
        blnSeleccionManual = False

        With ListViewSolicitud
            If .Items.Count > 0 Then
                .Items(0).Selected = True
                .Focus()
            Else
                'Me.ButtonContinuarS.Focus()
                ClicBtn = True
                CONTINUAR()
            End If
        End With
        bCargando = False
        bCambios = False
        bContinuar = True
        [Global].HabilitarMenuItem(Me.MainMenu1, True)
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub TerminarVisita()
        ButtonRegresarD_Click(Nothing, Nothing)
    End Sub


    Private Sub PreparaCombos()
        Dim Area As New ArrayList
        Dim Peticion As New ArrayList
        'Combobox de área
        Dim aValores As ArrayList = ValorReferencia.RecuperarLista("SOLTAREA")
        If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
            For Each refDesc As ValorReferencia.Descripcion In aValores
                Area.Add(New ClaseTmp(refDesc.Id, refDesc.Cadena))
            Next
            'For Each dr As DataRow In ValorReferencia.RecuperarLista("SOLTAREA").Rows
            '    Area.Add(New ClaseTmp(dr(0), dr(1)))
            'Next
            ComboBoxArea.DataSource = Area
            ComboBoxArea.DisplayMember = "Descripcion"
            ComboBoxArea.ValueMember = "Valor"
        End If
        'Combobox de petición
        aValores = ValorReferencia.RecuperarLista("SOLPETIC")
        If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
            For Each refDesc As ValorReferencia.Descripcion In aValores
                Peticion.Add(New ClaseTmp(refDesc.Id, refDesc.Cadena))
            Next
            'For Each dr As DataRow In ValorReferencia.RecuperarLista("SOLPETIC").Rows
            '    Peticion.Add(New ClaseTmp(dr(0), dr(1)))
            'Next
            ComboBoxPeticion.DataSource = Peticion
            ComboBoxPeticion.DisplayMember = "Descripcion"
            ComboBoxPeticion.ValueMember = "Valor"
        End If
        aValores = Nothing
    End Sub

    Private Sub ButtonRegresarS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresarS.Click
        Me.Close()

    End Sub

    Private Sub ListViewSolicitud_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewSolicitud.SelectedIndexChanged
        Try
            If blnSeleccionManual Then Exit Sub
            If ListViewSolicitud.SelectedIndices.Count <= 0 Then Exit Sub
            blnSeleccionManual = True
            MarcarElemento(ListViewSolicitud, CheckState.Checked, ListViewSolicitud.SelectedIndices(0))
            blnSeleccionManual = False

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ListViewSolicitud_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewSolicitud.ItemCheck
        Try
            If blnSeleccionManual Then Exit Sub
            blnSeleccionManual = True
            MarcarElemento(ListViewSolicitud, e.NewValue, e.Index)
            blnSeleccionManual = False
            If ListViewSolicitud.SelectedIndices.Count <= 0 Then Exit Sub
            If e.NewValue = CheckState.Unchecked Then
                blnSeleccionManual = True
                ListViewSolicitud.Items(ListViewSolicitud.SelectedIndices(0)).Selected = False
                blnSeleccionManual = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

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

    Private Function ObtieneSOLId(ByVal LV As ListView) As String
        Dim i As Integer
        For i = 0 To LV.Items.Count - 1
            If LV.Items(i).Checked Then
                Return LV.Items(i).SubItems(2).Text
            End If
        Next
        Return ""
    End Function

    Private Function ObtieneFolio(ByVal LV As ListView) As String
        Dim i As Integer
        For i = 0 To LV.Items.Count - 1
            If LV.Items(i).Checked Then
                Return LV.Items(i).Text
            End If
        Next
        Return ""
    End Function

    Private Sub ButtonRegresarD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresarD.Click
        If bCambios Then
            If MsgBox(oVista.BuscarMensaje("Mensajes", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        ClicBtn = True
        REGRESAR()

    End Sub

    Private Sub REGRESAR()
        If ClicBtn Then
            Me.Close()
        Else
            Ir_A(0)
        End If
    End Sub

    Private Sub LimpiaDetalles()
        If Not Fin Then Exit Sub
        TextBoxFolio.Text = ""
        If ComboBoxArea.Items.Count > 0 Then ComboBoxArea.SelectedIndex = 0
        If ComboBoxPeticion.Items.Count > 0 Then ComboBoxPeticion.SelectedIndex = 0
        TextBoxConcepto.Text = ""
        TextBoxComentario.Text = ""
    End Sub

    Private Sub Ir_A(ByVal Indice As Integer)
        If Not Fin Then Exit Sub
        Select Case Indice
            Case 0
                LimpiaDetalles()
                oVista.PoblarListView(ListViewSolicitud, odbVen, "ListViewSolicitud", " where visitaclave='" & VisitaClave & "' and diaclave='" & oDia.DiaActual & "'")
                'TabPageDetalle.Enabled = False
                'TabPageSolicitud.Enabled = True

                With ListViewSolicitud
                    If .Items.Count > 0 Then
                        .Items(0).Selected = True
                        .Focus()
                    End If
                End With


                Nuevo = True
            Case 1
                'TabPageDetalle.Enabled = True
                'TabPageSolicitud.Enabled = False
                ComboBoxPeticion.Focus()
        End Select
        bCambios = False
        If ClicBtn Then TabControlSolicitud.SelectedIndex = Indice
        ClicBtn = False
    End Sub

    Private Sub ButtonContinuarS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuarS.Click
        ClicBtn = True
        CONTINUAR()
    End Sub

    Private Sub CONTINUAR()
        If HaySeleccion(ListViewSolicitud) Then
            SOLId = ObtieneSOLId(ListViewSolicitud)
            Dim Dt As DataTable = odbVen.RealizarConsultaSQL("select folio, tipopeticion, tipoarea,concepto, comentario from solicitud where solid='" & SOLId & "'", "soicitud")
            For Each dr As DataRow In Dt.Rows
                TextBoxFolio.Text = dr(0).ToString
                ComboBoxPeticion.SelectedValue = dr(1).ToString
                ComboBoxArea.SelectedValue = dr(2).ToString
                TextBoxConcepto.Text = dr(3).ToString
                TextBoxComentario.Text = dr(4).ToString
                Nuevo = False
                Exit For
            Next
            Dt.Dispose()
            Ir_A(1)
        Else
            LimpiaDetalles()
            TextBoxFolio.Text = Folio.Obtener(, ServicesCentral.TiposModulosMovDet.Solicitudes)
            If Me.TextBoxFolio.Text <> "" Then
                Ir_A(1)
            End If
        End If
    End Sub

    Private Sub TextBoxConcepto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxConcepto.TextChanged
        bCambios = True
    End Sub

    Private Sub TextBoxComentario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxComentario.TextChanged
        bCambios = True
    End Sub

    Private Sub ComboBoxArea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxArea.SelectedIndexChanged
        bCambios = True
    End Sub

    Private Sub ComboBoxPeticion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxPeticion.SelectedIndexChanged
        bCambios = True
    End Sub

    Private Sub ButtonContinuarD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuarD.Click
        If Not ValidaCampos() Then Exit Sub
        Try
            ClicBtn = True
            Dim s As String
            If Nuevo Then
                Dim sFolio As String
                SOLId = oApp.KEYGEN(1)
                sFolio = Folio.Obtener(, ServicesCentral.TiposModulosMovDet.Solicitudes)
                s = "insert into solicitud values('" & SOLId & "','" & sFolio & "','" & VisitaClave & "','" & oDia.DiaActual & "'," & ComboBoxArea.SelectedValue & "," & ComboBoxPeticion.SelectedValue & "," & UniFechaSQL(Now) & ",'" & TextBoxConcepto.Text & "',1," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "','" & TextBoxComentario.Text & "',0)"
                If odbVen.EjecutarComandoSQL(s) > 0 Then
                    Folio.Confirmar(, ServicesCentral.TiposModulosMovDet.Solicitudes)
                Else
                    MsgBox("La solicitud no se pudo guardar")
                End If
                'Ir_A(0)
                Me.Close()
            Else
                s = "update solicitud set tipopeticion=" & ComboBoxPeticion.SelectedValue & ", tipoarea=" & ComboBoxArea.SelectedValue & ", concepto='" & TextBoxConcepto.Text & "', comentario='" & TextBoxComentario.Text & "', mfechahora=" & UniFechaSQL(Now) & ", musuarioid='" & oVendedor.UsuarioId & "',Enviado=0 where solid='" & SOLId & "'"
                If odbVen.EjecutarComandoSQL(s) = 0 Then
                    MsgBox("La solicitud no se pudo guardar")
                End If
                'Ir_A(0)
                Me.Close()
            End If
        Catch ex As SqlServerCe.SqlCeException
            MsgBox("SQL Error: " & ex.Message)
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        If IsNothing(ComboBoxPeticion.SelectedValue) Then
            MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "BE0001"), LabelPeticion.Text), MsgBoxStyle.Information)
            ComboBoxPeticion.Focus()
            Return False
        ElseIf IsNothing(ComboBoxArea.SelectedValue) Then
            MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "BE0001"), LabelArea.Text), MsgBoxStyle.Information)
            ComboBoxArea.Focus()
            Return False
        ElseIf TextBoxConcepto.Text = "" Then
            MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "BE0001"), LabelConcepto.Text), MsgBoxStyle.Information)
            TextBoxConcepto.Focus()
            Return False
        ElseIf TextBoxFolio.Text = "" Then
            MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "BE0001"), LabelFolio.Text), MsgBoxStyle.Information)
            Return False
        End If
        Return True
    End Function

    Private Sub MenuItemEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemEliminar.Click
        Try
            If ListViewSolicitud.Items.Count = 0 Then Exit Sub
            Dim s As String = "delete from solicitud where solid='" & ObtieneSOLId(ListViewSolicitud) & "'"
            If odbVen.EjecutarComandoSQL(s) > 0 Then
                oVista.PoblarListView(ListViewSolicitud, oDBVen, "ListViewSolicitud", " where visitaclave='" & VisitaClave & "' and diaclave='" & oDia.DiaActual & "'")
            Else
                MsgBox("No se pudo eliminar la solicitud")
            End If
        Catch ex As SqlServerCe.SqlCeException
            MsgBox("SQL Error: " & ex.Message)
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub TabControlSolicitud_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControlSolicitud.SelectedIndexChanged
        If bCargando Then Exit Sub
        If ClicBtn Then Exit Sub
        If TabControlSolicitud.SelectedIndex = 1 Then
            If bContinuar Then
                CONTINUAR()
                ComboBoxPeticion.Focus()
                bContinuar = True
            End If
        Else
            If bCambios Then
                If MsgBox(oVista.BuscarMensaje("Mensajes", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.No Then
                    bContinuar = False
                    Me.TabControlSolicitud.SelectedIndex = 1
                    bContinuar = True
                    Exit Sub
                End If
            End If

            REGRESAR()

            With ListViewSolicitud
                If .Items.Count > 0 Then
                    .Items(0).Selected = True
                    .Focus()
                Else
                    Me.ButtonContinuarS.Focus()
                End If
            End With
        End If

    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        If TabControlSolicitud.SelectedIndex = 0 Then
            ButtonRegresarS_Click(Nothing, Nothing)
        Else
            ButtonRegresarD_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        MenuItemEliminar_Click(Nothing, Nothing)
    End Sub

End Class

Public Class ClaseTmp
    Private Desc As String
    Private Val As String

    Public Sub New(ByVal v As String, ByVal d As String)
        MyBase.New()
        Me.Desc = d
        Me.Val = v
    End Sub

    Public ReadOnly Property Descripcion() As String
        Get
            Return Desc
        End Get
    End Property

    Public ReadOnly Property Valor() As String
        Get
            Return Val
        End Get
    End Property


End Class