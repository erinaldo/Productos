Public Class FormActivosAsignar
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String, ByVal parbAsignado As Boolean, ByVal parsClave As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        oCliente = paroCliente
        sVisitaClave = parsVisitaClave
        sActivoClave = parsClave
        If parbAsignado Then
            eEstado = tEstado.Modificando
        Else
            eEstado = tEstado.Navegando
        End If
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MenuItemRegresar Is Nothing Then
            If oVendedor.motconfiguracion.Secuencia Then
                If Not ctrlSeguimiento.Parent Is Nothing Then
                    RemoveHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
                    RemoveHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
                    ctrlSeguimiento.QuitarMenuItem(Me.MainMenu1)
                    Me.Controls.Remove(ctrlSeguimiento)
                End If
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

        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MainMenu1 Is Nothing Then Me.MainMenu1.Dispose()
        If Me.ListViewActivos.Columns.Count > 0 Then
            Me.ListViewActivos.Columns.Clear()
        End If
#If MOD_TERM <> "PALM" Then
        If Not bScanner Is Nothing Then bScanner.Dispose()
        bScanner = Nothing
#End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents PanelDetalle As System.Windows.Forms.Panel
    Friend WithEvents TextBoxComentarioAs As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxMotivo As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxEstadoAs As System.Windows.Forms.ComboBox
    Friend WithEvents LabelComentario As System.Windows.Forms.Label
    Friend WithEvents LabelMotivo As System.Windows.Forms.Label
    Friend WithEvents LabelEstado As System.Windows.Forms.Label
    Friend WithEvents LabelFecha As System.Windows.Forms.Label
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents PanelVista As System.Windows.Forms.Panel
    Friend WithEvents TextBoxIDElectronico As System.Windows.Forms.TextBox
    Friend WithEvents ListViewActivos As System.Windows.Forms.ListView
    Friend WithEvents ButtonRegresarV As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuarV As System.Windows.Forms.Button
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.PanelDetalle = New System.Windows.Forms.Panel
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker
        Me.TextBoxComentarioAs = New System.Windows.Forms.TextBox
        Me.ComboBoxMotivo = New System.Windows.Forms.ComboBox
        Me.ComboBoxEstadoAs = New System.Windows.Forms.ComboBox
        Me.LabelComentario = New System.Windows.Forms.Label
        Me.LabelMotivo = New System.Windows.Forms.Label
        Me.LabelEstado = New System.Windows.Forms.Label
        Me.LabelFecha = New System.Windows.Forms.Label
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.PanelVista = New System.Windows.Forms.Panel
        Me.TextBoxIDElectronico = New System.Windows.Forms.TextBox
        Me.ButtonRegresarV = New System.Windows.Forms.Button
        Me.ButtonContinuarV = New System.Windows.Forms.Button
        Me.ListViewActivos = New System.Windows.Forms.ListView
        Me.PanelDetalle.SuspendLayout()
        Me.PanelVista.SuspendLayout()
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
        'PanelDetalle
        '
        Me.PanelDetalle.Controls.Add(Me.dtpFecha)
        Me.PanelDetalle.Controls.Add(Me.TextBoxComentarioAs)
        Me.PanelDetalle.Controls.Add(Me.ComboBoxMotivo)
        Me.PanelDetalle.Controls.Add(Me.ComboBoxEstadoAs)
        Me.PanelDetalle.Controls.Add(Me.LabelComentario)
        Me.PanelDetalle.Controls.Add(Me.LabelMotivo)
        Me.PanelDetalle.Controls.Add(Me.LabelEstado)
        Me.PanelDetalle.Controls.Add(Me.LabelFecha)
        Me.PanelDetalle.Controls.Add(Me.ButtonRegresar)
        Me.PanelDetalle.Controls.Add(Me.ButtonContinuar)
        Me.PanelDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelDetalle.Location = New System.Drawing.Point(0, 0)
        Me.PanelDetalle.Name = "PanelDetalle"
        Me.PanelDetalle.Size = New System.Drawing.Size(242, 295)
        '
        'dtpFecha
        '
        Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
        Me.dtpFecha.Enabled = False
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.Location = New System.Drawing.Point(102, 42)
        Me.dtpFecha.MaxDate = New Date(2500, 12, 31, 0, 0, 0, 0)
        Me.dtpFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(131, 22)
        Me.dtpFecha.TabIndex = 13
        Me.dtpFecha.Value = New Date(2007, 1, 30, 0, 0, 0, 0)
        '
        'TextBoxComentarioAs
        '
        Me.TextBoxComentarioAs.Location = New System.Drawing.Point(8, 118)
        Me.TextBoxComentarioAs.Multiline = True
        Me.TextBoxComentarioAs.Name = "TextBoxComentarioAs"
        Me.TextBoxComentarioAs.Size = New System.Drawing.Size(224, 141)
        Me.TextBoxComentarioAs.TabIndex = 15
        '
        'ComboBoxMotivo
        '
        Me.ComboBoxMotivo.Location = New System.Drawing.Point(102, 69)
        Me.ComboBoxMotivo.Name = "ComboBoxMotivo"
        Me.ComboBoxMotivo.Size = New System.Drawing.Size(131, 22)
        Me.ComboBoxMotivo.TabIndex = 14
        '
        'ComboBoxEstadoAs
        '
        Me.ComboBoxEstadoAs.Location = New System.Drawing.Point(102, 16)
        Me.ComboBoxEstadoAs.Name = "ComboBoxEstadoAs"
        Me.ComboBoxEstadoAs.Size = New System.Drawing.Size(131, 22)
        Me.ComboBoxEstadoAs.TabIndex = 12
        '
        'LabelComentario
        '
        Me.LabelComentario.Location = New System.Drawing.Point(8, 96)
        Me.LabelComentario.Name = "LabelComentario"
        Me.LabelComentario.Size = New System.Drawing.Size(100, 20)
        Me.LabelComentario.Text = "LabelComentario"
        '
        'LabelMotivo
        '
        Me.LabelMotivo.Location = New System.Drawing.Point(8, 70)
        Me.LabelMotivo.Name = "LabelMotivo"
        Me.LabelMotivo.Size = New System.Drawing.Size(100, 20)
        Me.LabelMotivo.Text = "LabelMotivo"
        '
        'LabelEstado
        '
        Me.LabelEstado.Location = New System.Drawing.Point(8, 20)
        Me.LabelEstado.Name = "LabelEstado"
        Me.LabelEstado.Size = New System.Drawing.Size(100, 20)
        Me.LabelEstado.Text = "LabelEstado"
        '
        'LabelFecha
        '
        Me.LabelFecha.Location = New System.Drawing.Point(8, 44)
        Me.LabelFecha.Name = "LabelFecha"
        Me.LabelFecha.Size = New System.Drawing.Size(100, 20)
        Me.LabelFecha.Text = "LabelFecha"
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(88, 262)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar.TabIndex = 18
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(8, 262)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuar.TabIndex = 19
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'PanelVista
        '
        Me.PanelVista.Controls.Add(Me.TextBoxIDElectronico)
        Me.PanelVista.Controls.Add(Me.ButtonRegresarV)
        Me.PanelVista.Controls.Add(Me.ButtonContinuarV)
        Me.PanelVista.Controls.Add(Me.ListViewActivos)
        Me.PanelVista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelVista.Location = New System.Drawing.Point(0, 0)
        Me.PanelVista.Name = "PanelVista"
        Me.PanelVista.Size = New System.Drawing.Size(242, 295)
        '
        'TextBoxIDElectronico
        '
        Me.TextBoxIDElectronico.Location = New System.Drawing.Point(4, 240)
        Me.TextBoxIDElectronico.Name = "TextBoxIDElectronico"
        Me.TextBoxIDElectronico.Size = New System.Drawing.Size(230, 21)
        Me.TextBoxIDElectronico.TabIndex = 23
        '
        'ButtonRegresarV
        '
        Me.ButtonRegresarV.Location = New System.Drawing.Point(86, 264)
        Me.ButtonRegresarV.Name = "ButtonRegresarV"
        Me.ButtonRegresarV.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresarV.TabIndex = 20
        Me.ButtonRegresarV.Text = "ButtonRegresarV"
        '
        'ButtonContinuarV
        '
        Me.ButtonContinuarV.Location = New System.Drawing.Point(4, 264)
        Me.ButtonContinuarV.Name = "ButtonContinuarV"
        Me.ButtonContinuarV.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuarV.TabIndex = 21
        Me.ButtonContinuarV.Text = "ButtonContinuarV"
        '
        'ListViewActivos
        '
        Me.ListViewActivos.CheckBoxes = True
        Me.ListViewActivos.FullRowSelect = True
        Me.ListViewActivos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewActivos.Location = New System.Drawing.Point(4, 17)
        Me.ListViewActivos.Name = "ListViewActivos"
        Me.ListViewActivos.Size = New System.Drawing.Size(230, 220)
        Me.ListViewActivos.TabIndex = 22
        Me.ListViewActivos.View = System.Windows.Forms.View.Details
        '
        'FormActivosAsignar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelVista)
        Me.Controls.Add(Me.PanelDetalle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenu1
        Me.Name = "FormActivosAsignar"
        Me.PanelDetalle.ResumeLayout(False)
        Me.PanelVista.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim bLectorActivo As Boolean = False

#If MOD_TERM <> "PALM" Then
    Private Sub FormActivosAsignar_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If eEstado = tEstado.Navegando Then
            Try
                bScanner.Terminate_Scanner()
                bLectorActivo = False
            Catch ex As Exception
                MsgBox("Error while stopping the scanner:" & ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub
#End If

    Private Sub FormActivosAsignar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        [Global].ObtenerFactores(Me)

        If oVendedor.motconfiguracion.Secuencia Then
            ctrlSeguimiento.AgregarControl(Me)
            Me.PanelDetalle.SendToBack()
            Me.PanelVista.SendToBack()
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

        If Not Vista.Buscar("FormActivosAsignar", oVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        oVista.ColocarEtiquetasForma(Me)
        oVista.CrearListView(ListViewActivos, "ListViewActivos")
#If MOD_TERM <> "PALM" Then
        If eEstado = tEstado.Navegando Then
            If Not bLectorActivo Then
                Select Case oApp.ModeloTerminal
                    Case "Generico"

                    Case "SymbolC9090", "SymbolMC50", "SymbolMC70"
                        Try
                            bScanner.Inicialize_Scanner(HANDHELD.SO.SymbolPCMC50)
                            bLectorActivo = True
                        Catch ex As Exception
                            MsgBox("Error while starting the scanner:" & ex.Message, MsgBoxStyle.Critical)
                        End Try
                    Case "HHP7600"
                        bScanner.Inicialize_Scanner(HANDHELD.SO.HHP7600)
                        bLectorActivo = True
                    Case "HHP7900"
                        bScanner.Inicialize_Scanner(HANDHELD.SO.HHP7900)
                        bLectorActivo = True
                    Case "HHPWM6"
                        bScanner.Inicialize_Scanner(HANDHELD.SO.HHPWM6)
                        bLectorActivo = True
                    Case "IntermecCN3"
                        bScanner.Inicialize_Scanner(HANDHELD.SO.IntermecCN3)
                        bLectorActivo = True
                    Case "SymbolMC55"
                        bScanner.Inicialize_Scanner(HANDHELD.SO.SymbolMC55)
                        bLectorActivo = True
                End Select
            End If
        End If
#End If
        LlenaCombos()
        dtpFecha.Value = Now
        VistaActual()
        Fin = True
        Cambios = False
        [Global].HabilitarMenuItem(MainMenu1, True)
        Cursor.Current = Cursors.Default
        ComboBoxEstadoAs.Focus()

    End Sub

    Private Sub TerminarVisita()
        MenuItemRegresar_Click(Nothing, Nothing)
    End Sub

#Region "VARIABLES"
    Private oValorRef As ValorReferencia
    Private oVista As Vista
    Private oCliente As Cliente
    Private sVisitaClave, sActivoClave, ACHId As String
    Private Asignado, Fin, Cambios As Boolean
    Private EstadoIni As Integer
    Private eEstado As tEstado
#If MOD_TERM <> "PALM" Then
    Private WithEvents bScanner As New HANDHELD.CScanner
#End If
#End Region

#Region "Propiedades"
    Public Property Transaccion() As SqlServerCe.SqlCeTransaction
        Get
            Return oDBVen.Transaccion
        End Get
        Set(ByVal Value As SqlServerCe.SqlCeTransaction)
            oDBVen.Transaccion = Value
        End Set
    End Property
#End Region

#Region "MIS METODOS"

    Private Sub VistaActual()
        Dim sFolio As String = String.Empty
        Select Case eEstado
            Case tEstado.Navegando
                PanelVista.Visible = True
                PanelDetalle.Visible = False
                oVista.PoblarListView(ListViewActivos, oDBVen, "ListViewActivos", "")
            Case tEstado.Modificando
                PanelVista.Visible = False
                PanelDetalle.Visible = True
                LlenaCampos()
        End Select

    End Sub


    Private Function ObtieneItemActivo(ByVal LV As ListView) As ListViewItem
        Dim i As Integer
        For i = 0 To LV.Items.Count - 1
            If LV.Items(i).Checked Then
                Return LV.Items(i)
            End If
        Next
        Return Nothing
    End Function
    Private Sub LlenaCombos()
        'Combo Estado (Asignar)
        Dim arrEdoAs As New ArrayList
        Dim aValores As ArrayList = ValorReferencia.RecuperarLista("EDOREG")
        If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
            For Each refDesc As ValorReferencia.Descripcion In aValores
                arrEdoAs.Add(New ComboGeneral(refDesc.Id, refDesc.Cadena))
            Next
            'For Each dr As DataRow In ValorReferencia.RecuperarLista("EDOREG").Rows
            '    arrEdoAs.Add(New ComboGeneral(dr(0), dr(1)))
            'Next
            ComboBoxEstadoAs.DataSource = arrEdoAs
            ComboBoxEstadoAs.DisplayMember = "Concepto"
            ComboBoxEstadoAs.ValueMember = "Valor"
            ComboBoxEstadoAs.SelectedValue = "1"
        End If
        'Combo Motivo
        Dim arrMot As New ArrayList
        aValores = ValorReferencia.RecuperarLista("ACIMOT")
        If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
            For Each refDesc As ValorReferencia.Descripcion In aValores
                arrMot.Add(New ComboGeneral(refDesc.Id, refDesc.Cadena))
            Next
            'For Each dr As DataRow In ValorReferencia.RecuperarLista("ACIMOT").Rows
            '    arrMot.Add(New ComboGeneral(dr(0), dr(1)))
            'Next
            ComboBoxMotivo.DataSource = arrMot
            ComboBoxMotivo.DisplayMember = "Concepto"
            ComboBoxMotivo.ValueMember = "Valor"
        End If
        aValores = Nothing
    End Sub

    Private Sub LlenaCampos()
        Dim w2 As New System.Text.StringBuilder
        w2.Append("select activoclientehist.activoclientehistid, activoclientehist.tipoestado, activoclientehist.fecha, activoclientehist.tipomotivo, activoclientehist.comentario ")
        w2.Append("from activo, activoclientehist ")
        w2.Append("where(activo.activoclave = activoclientehist.activoclave) ")
        w2.Append("and activo.activoclave='" & sActivoClave & "' ")
        w2.Append("and activoclientehist.tipoestado=1 ")
        w2.Append("and activoclientehist.activoclientehistid in ")
        w2.Append("(select activoclientehistid from activoclientehist where fecha in (select max(fecha) from activoclientehist where activoclave=activo.activoclave and clienteclave='" & oCliente.ClienteClave & "'))")
        Dim Dt As DataTable = oDBVen.RealizarConsultaSQL(w2.ToString, "Asignar2")
        w2 = Nothing
        If Dt.Rows.Count > 0 Then
            Dim Dr As DataRow = Dt.Rows(0)
            ACHId = Dr(0).ToString
            ComboBoxEstadoAs.SelectedValue = Dr(1).ToString
            EstadoIni = Dr(1)
            dtpFecha.Value = Dr(2)
            ComboBoxMotivo.SelectedValue = Dr(3).ToString
            TextBoxComentarioAs.Text = Dr(4).ToString
        End If
        Dt.Dispose()
    End Sub

    Private Sub LimpiaCampos()
        dtpFecha.Value = Now
        ComboBoxMotivo.SelectedIndex = 0
        TextBoxComentarioAs.Text = ""
    End Sub

    Public Function ActivoAutomatico(ByVal parsIDElectronico As String) As Boolean
        If parsIDElectronico = String.Empty Then Return True

        Me.TextBoxIDElectronico.Text = parsIDElectronico
        Dim bEncontrado As Boolean = False


        Dim refListViewItem As ListViewItem
        For Each refListViewItem In Me.ListViewActivos.Items
            If refListViewItem.SubItems(5).Text = parsIDElectronico Then
                sActivoClave = refListViewItem.SubItems(0).Text

                refListViewItem.Selected = True
                refListViewItem.Checked = True

                bEncontrado = True
                Return True
                Exit For
            End If
        Next

        MsgBox(oVista.BuscarMensaje("Mensajes", "E0386"), MsgBoxStyle.Critical)
        Return False

    End Function

#End Region

#Region "Eventos"
    Private Sub TextBoxComentarioAs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxComentarioAs.TextChanged, dtpFecha.TextChanged
        Cambios = True
    End Sub

    Private Sub ComboBoxMotivo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxMotivo.SelectedIndexChanged
        Cambios = True
    End Sub

    Private Sub DetailViewFechaAs_ItemChanged(ByVal sender As Object, ByVal e As Resco.Controls.DetailView.ItemEventArgs)
        Cambios = True
    End Sub

    Private Sub ComboBoxEstadoAs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxEstadoAs.SelectedIndexChanged
        Cambios = True
        If Fin Then LimpiaCampos()
    End Sub

    Private Sub ButtonRegresarAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        If Cambios Then
            If MsgBox(oVista.BuscarMensaje("Mensajes", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        Me.Close()
    End Sub

    Private Sub ButtonContinuarAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        Dim bCerrar As Boolean = True
        Try
            Dim s As String
            If IsNothing(ComboBoxEstadoAs.SelectedValue) Then
                MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "BE0001"), LabelEstado.Text), MsgBoxStyle.Information)
                ComboBoxEstadoAs.Focus()
                bCerrar = False
                Exit Sub
            End If
            If IsNothing(ComboBoxMotivo.SelectedValue) Then
                MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "BE0001"), LabelMotivo.Text), MsgBoxStyle.Information)
                ComboBoxMotivo.Focus()
                bCerrar = False
                Exit Sub
            End If
            If Asignado AndAlso EstadoIni = ComboBoxEstadoAs.SelectedValue Then
                s = "update activoclientehist set fecha=" & UniFechaSQL(Now) & ", tipomotivo=" & ComboBoxMotivo.SelectedValue & ", comentario='" & TextBoxComentarioAs.Text & "', mfechahora=" & UniFechaSQL(Now) & ", musuarioid='" & oVendedor.UsuarioId & "',Enviado =0 where activoclave='" & sActivoClave & "' and activoclientehistid='" & ACHId & "'"
            Else
                s = "insert into activoclientehist values('" & sActivoClave & "','" & oApp.KEYGEN(1) & "','" & oCliente.ClienteClave & "'," & UniFechaSQL(Now) & "," & ComboBoxEstadoAs.SelectedValue & "," & ComboBoxMotivo.SelectedValue & ",2,'" & TextBoxComentarioAs.Text & "'," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "',0)"
            End If
            If oDBVen.EjecutarComandoSQL(s) = 0 Then
                MsgBox("La asignación del activo no se realizó")
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As SqlServerCe.SqlCeException
            MsgBox("SQL Error: " & ex.Message, MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Information)
        Finally
            If bCerrar Then
                Me.Close()
            End If
        End Try
    End Sub

    Private Sub ButtonContinuarV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonContinuarV.Click
        Cursor.Current = Cursors.WaitCursor
        Dim lvItem As ListViewItem = ObtieneItemActivo(ListViewActivos)
        If IsNothing(lvItem) Then
            MsgBox(oVista.BuscarMensaje("Mensajes", "E0024"), MsgBoxStyle.Information)
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        sActivoClave = lvItem.Text
        Dim iTipoEstado As Integer = oDBVen.EjecutarCmdScalarIntSQL("Select TipoEstado from Activo where ActivoClave ='" & sActivoClave & "'")
        If iTipoEstado = 0 Then
            If MsgBox(oVista.BuscarMensaje("Mensajes", "E0074"), MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Cursor.Current = Cursors.Default
                Exit Sub
            Else
                oDBVen.EjecutarComandoSQL("Update Activo set TipoEstado = 1,MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID='" & oVendedor.UsuarioId & "' where ActivoClave ='" & sActivoClave & "'")
            End If
        End If
        oDBVen.EjecutarComandoSQL("insert into activoclientehist values('" & sActivoClave & "','" & oApp.KEYGEN(1) & "','" & oCliente.ClienteClave & "'," & UniFechaSQL(Now) & ",1,1,2,null," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "',0)")
        Cursor.Current = Cursors.Default
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ButtonRegresarV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRegresarV.Click
        Me.Close()
    End Sub

    Private Sub TextBoxIDElectronico_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxIDElectronico.GotFocus
        Dim iSeleccionados As Integer
        Dim iIndice As Integer = 0
        For iSeleccionados = 0 To Me.ListViewActivos.SelectedIndices.Count - 1
            iIndice = Me.ListViewActivos.SelectedIndices(iSeleccionados)
            Me.ListViewActivos.Items(iIndice).Checked = False
            Me.ListViewActivos.Items(iIndice).Selected = False
        Next
    End Sub

    Private Sub TextBoxIDElectronico_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxIDElectronico.LostFocus
        If Not ActivoAutomatico(TextBoxIDElectronico.Text) Then
            Me.TextBoxIDElectronico.Text = String.Empty
        Else
            ButtonContinuarV_Click(Nothing, Nothing)
        End If
    End Sub
#End Region

    Public Enum tEstado
        Navegando = 1
        Modificando
    End Enum

#If MOD_TERM <> "PALM" Then
    Private Sub bScanner_Data_Scanned(ByVal Data As String) Handles bScanner.Data_Scanned
        If Not ActivoAutomatico(Data) Then
            Me.TextBoxIDElectronico.Text = String.Empty
        Else
            ButtonContinuarV_Click(Nothing, Nothing)
        End If
    End Sub
#End If

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        If eEstado = tEstado.Modificando Then
            ButtonRegresarAs_Click(Nothing, Nothing)
        Else
            ButtonRegresarV_Click(Nothing, Nothing)
        End If
    End Sub
End Class
