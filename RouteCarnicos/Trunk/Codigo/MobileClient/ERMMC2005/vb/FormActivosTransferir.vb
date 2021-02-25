Public Class FormActivosTransferir
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pariCliente As Cliente, ByVal parsVisitaClave As String, ByVal pariClave As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        oCliente = pariCliente
        ActivoClave = pariClave
        VisitaClave = parsVisitaClave
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MainMenu1 Is Nothing Then
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

        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MainMenu1 Is Nothing Then Me.MainMenu1.Dispose()
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TextBoxComentarioT As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxCliente As System.Windows.Forms.ComboBox
    Friend WithEvents LabelComentario As System.Windows.Forms.Label
    Friend WithEvents LabelCliente As System.Windows.Forms.Label
    Friend WithEvents LabelFecha As System.Windows.Forms.Label
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker
        Me.TextBoxComentarioT = New System.Windows.Forms.TextBox
        Me.ComboBoxCliente = New System.Windows.Forms.ComboBox
        Me.LabelComentario = New System.Windows.Forms.Label
        Me.LabelCliente = New System.Windows.Forms.Label
        Me.LabelFecha = New System.Windows.Forms.Label
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonContinuar = New System.Windows.Forms.Button
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
        Me.Panel1.Controls.Add(Me.dtpFecha)
        Me.Panel1.Controls.Add(Me.TextBoxComentarioT)
        Me.Panel1.Controls.Add(Me.ComboBoxCliente)
        Me.Panel1.Controls.Add(Me.LabelComentario)
        Me.Panel1.Controls.Add(Me.LabelCliente)
        Me.Panel1.Controls.Add(Me.LabelFecha)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'dtpFecha
        '
        Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
        Me.dtpFecha.Enabled = False
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.Location = New System.Drawing.Point(96, 19)
        Me.dtpFecha.MaxDate = New Date(2500, 12, 31, 0, 0, 0, 0)
        Me.dtpFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(128, 22)
        Me.dtpFecha.TabIndex = 16
        Me.dtpFecha.Value = New Date(2005, 12, 31, 0, 0, 0, 0)
        '
        'TextBoxComentarioT
        '
        Me.TextBoxComentarioT.Location = New System.Drawing.Point(9, 96)
        Me.TextBoxComentarioT.Multiline = True
        Me.TextBoxComentarioT.Name = "TextBoxComentarioT"
        Me.TextBoxComentarioT.Size = New System.Drawing.Size(215, 147)
        Me.TextBoxComentarioT.TabIndex = 8
        '
        'ComboBoxCliente
        '
        Me.ComboBoxCliente.Location = New System.Drawing.Point(96, 49)
        Me.ComboBoxCliente.Name = "ComboBoxCliente"
        Me.ComboBoxCliente.Size = New System.Drawing.Size(128, 22)
        Me.ComboBoxCliente.TabIndex = 9
        '
        'LabelComentario
        '
        Me.LabelComentario.Location = New System.Drawing.Point(9, 74)
        Me.LabelComentario.Name = "LabelComentario"
        Me.LabelComentario.Size = New System.Drawing.Size(100, 20)
        Me.LabelComentario.Text = "LabelComentario"
        '
        'LabelCliente
        '
        Me.LabelCliente.Location = New System.Drawing.Point(9, 49)
        Me.LabelCliente.Name = "LabelCliente"
        Me.LabelCliente.Size = New System.Drawing.Size(100, 20)
        Me.LabelCliente.Text = "LabelCliente"
        '
        'LabelFecha
        '
        Me.LabelFecha.Location = New System.Drawing.Point(9, 20)
        Me.LabelFecha.Name = "LabelFecha"
        Me.LabelFecha.Size = New System.Drawing.Size(100, 20)
        Me.LabelFecha.Text = "LabelFecha"
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(89, 262)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar.TabIndex = 14
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(9, 262)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuar.TabIndex = 15
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'FormActivosTransferir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenu1
        Me.Name = "FormActivosTransferir"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "VARIABLES"
    Private oValorRef As ValorReferencia
    Private oCliente As Cliente
    Private oVista As Vista
    Private VisitaClave, ActivoClave As String
    Private bHuboCambios As Boolean
#End Region

#Region "FormActivosTransferir"
    Private Sub FormActivosTransferir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        If Not Vista.Buscar("FormActivosTransferir", oVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        oVista.ColocarEtiquetasForma(Me)
        LlenaCombos()
        AsignaFecha()
        [Global].HabilitarMenuItem(MainMenu1, True)
        Cursor.Current = Cursors.Default
        bHuboCambios = False
        'With DetailViewFecha
        '    If .Items.Count > 0 Then
        '        .Items(0).SetFocus()
        '    End If
        'End With

    End Sub

    Private Sub TerminarVisita()
        ButtonRegresarT_Click(Nothing, Nothing)
    End Sub

    Private Sub ButtonRegresarT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click, MenuItemRegresar.Click
        If bHuboCambios Then
            If MsgBox(oVista.BuscarMensaje("Mensajes", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        Me.Close()
    End Sub

    Private Sub ButtonContinuarT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        Try
            Dim ahorita As DateTime = Now
            'Dim calendario As DateTime = DetailViewFechaT.Items(0).Value
            oDBVen.EjecutarComandoSQL("insert into activoclientehist values('" & ActivoClave & "','" & oApp.KEYGEN(1) & "','" & oCliente.ClienteClave & "'," & UniFechaSQL(ahorita) & ",0,2,1,'" & TextBoxComentarioT.Text & "'," & UniFechaSQL(ahorita) & ",'" & oVendedor.UsuarioId & "',0)")
            oDBVen.EjecutarComandoSQL("insert into activoclientehist values('" & ActivoClave & "','" & oApp.KEYGEN(2) & "','" & ComboBoxCliente.SelectedValue & "'," & UniFechaSQL(ahorita.AddSeconds(1)) & ",1,1,1,'" & TextBoxComentarioT.Text & "'," & UniFechaSQL(ahorita.AddSeconds(1)) & ",'" & oVendedor.UsuarioId & "',0)")
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As SqlServerCe.SqlCeException
            MsgBox("SQL Error: " & ex.Message)
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            Me.Close()
        End Try
    End Sub
#End Region

#Region "MIS METODOS"
    Private Sub LlenaCombos()
        'Combo Cliente
        Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select clienteclave, razonsocial from cliente where clienteclave <> '" & oCliente.ClienteClave & "'", "Cliente")
        Dim arrCliente As New ArrayList
        For Each dr As DataRow In Dt.Rows
            arrCliente.Add(New ComboGeneral(dr("clienteclave"), dr("razonsocial")))
        Next
        Dt.Dispose()
        ComboBoxCliente.DataSource = arrCliente
        ComboBoxCliente.DisplayMember = "Concepto"
        ComboBoxCliente.ValueMember = "Valor"
    End Sub

    Private Sub AsignaFecha()
        Try
            dtpFecha.Value = Now
        Catch ex As SqlServerCe.SqlCeException
            MsgBox("SQL Error: " & ex.Message)
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub
#End Region

    Private Sub TextBoxComentarioT_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxComentarioT.TextChanged, dtpFecha.TextChanged, ComboBoxCliente.TextChanged
        Me.bHuboCambios = True
    End Sub
End Class
