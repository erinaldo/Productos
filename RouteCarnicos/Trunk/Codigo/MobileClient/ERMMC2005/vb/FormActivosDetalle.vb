Public Class FormActivosDetalle
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal parsVisitaClave As String, ByVal parsClienteClave As String, Optional ByVal pariClave As String = "")
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        If g_SO = SO.WindowsCE Then
            Call InTheHand.Windows.Forms.ContextMenuHelper.HookAllControls(Me.Controls)
        End If

        'Add any initialization after the InitializeComponent() call
        VisitaClave = parsVisitaClave
        ActivoClave = pariClave
        sClienteClave = parsClienteClave
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.C1FlexGridServicios Is Nothing Then
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

        If Not Me.MenuItem1 Is Nothing Then Me.MenuItem1.Dispose()
        If Not Me.MenuItemEliminar Is Nothing Then Me.MenuItemEliminar.Dispose()
        If Not Me.MenuItemInsertar Is Nothing Then Me.MenuItemInsertar.Dispose()
        If Not Me.MainMenu1 Is Nothing Then Me.MainMenu1.Dispose()
        If Not Me.ContextMenu1 Is Nothing Then Me.ContextMenu1.Dispose()
        If Not Me.C1FlexGridServicios Is Nothing Then Me.C1FlexGridServicios.Dispose()
        Me.C1FlexGridServicios = Nothing
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItemEliminar As System.Windows.Forms.MenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonRegresarA As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuarA As System.Windows.Forms.Button
    Friend WithEvents TabControlActivos As System.Windows.Forms.TabControl
    Friend WithEvents TabPageActivo As System.Windows.Forms.TabPage
    Friend WithEvents ComboBoxAsignacion As System.Windows.Forms.ComboBox
    Friend WithEvents LabelAsignacion As System.Windows.Forms.Label
    Friend WithEvents ComboBoxFase As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxEstado As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxCodB As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNombre As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxTipo As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxClave As System.Windows.Forms.TextBox
    Friend WithEvents LabelFase As System.Windows.Forms.Label
    Friend WithEvents LabelEstado As System.Windows.Forms.Label
    Friend WithEvents LabelCodigoBarras As System.Windows.Forms.Label
    Friend WithEvents LabelNombre As System.Windows.Forms.Label
    Friend WithEvents LabelTipo As System.Windows.Forms.Label
    Friend WithEvents LabelClave As System.Windows.Forms.Label
    Friend WithEvents TabPageDetalle As System.Windows.Forms.TabPage
    Friend WithEvents TextBoxComentario As System.Windows.Forms.TextBox
    Friend WithEvents LabelComentario As System.Windows.Forms.Label
    Friend WithEvents TextBoxAncho As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxAltura As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxProfundidad As System.Windows.Forms.TextBox
    Friend WithEvents LabelProfundidad As System.Windows.Forms.Label
    Friend WithEvents LabelAncho As System.Windows.Forms.Label
    Friend WithEvents LabelAltura As System.Windows.Forms.Label
    Friend WithEvents TabPageServicios As System.Windows.Forms.TabPage
    Friend WithEvents C1FlexGridServicios As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemInsertar As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormActivosDetalle))
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.MenuItemEliminar = New System.Windows.Forms.MenuItem
        Me.MenuItemInsertar = New System.Windows.Forms.MenuItem
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ButtonRegresarA = New System.Windows.Forms.Button
        Me.ButtonContinuarA = New System.Windows.Forms.Button
        Me.TabControlActivos = New System.Windows.Forms.TabControl
        Me.TabPageActivo = New System.Windows.Forms.TabPage
        Me.ComboBoxAsignacion = New System.Windows.Forms.ComboBox
        Me.LabelAsignacion = New System.Windows.Forms.Label
        Me.ComboBoxFase = New System.Windows.Forms.ComboBox
        Me.ComboBoxEstado = New System.Windows.Forms.ComboBox
        Me.TextBoxCodB = New System.Windows.Forms.TextBox
        Me.TextBoxNombre = New System.Windows.Forms.TextBox
        Me.ComboBoxTipo = New System.Windows.Forms.ComboBox
        Me.TextBoxClave = New System.Windows.Forms.TextBox
        Me.LabelFase = New System.Windows.Forms.Label
        Me.LabelEstado = New System.Windows.Forms.Label
        Me.LabelCodigoBarras = New System.Windows.Forms.Label
        Me.LabelNombre = New System.Windows.Forms.Label
        Me.LabelTipo = New System.Windows.Forms.Label
        Me.LabelClave = New System.Windows.Forms.Label
        Me.TabPageDetalle = New System.Windows.Forms.TabPage
        Me.TextBoxComentario = New System.Windows.Forms.TextBox
        Me.LabelComentario = New System.Windows.Forms.Label
        Me.TextBoxAncho = New System.Windows.Forms.TextBox
        Me.TextBoxAltura = New System.Windows.Forms.TextBox
        Me.TextBoxProfundidad = New System.Windows.Forms.TextBox
        Me.LabelProfundidad = New System.Windows.Forms.Label
        Me.LabelAncho = New System.Windows.Forms.Label
        Me.LabelAltura = New System.Windows.Forms.Label
        Me.TabPageServicios = New System.Windows.Forms.TabPage
        Me.C1FlexGridServicios = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.Panel1.SuspendLayout()
        Me.TabControlActivos.SuspendLayout()
        Me.TabPageActivo.SuspendLayout()
        Me.TabPageDetalle.SuspendLayout()
        Me.TabPageServicios.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.Add(Me.MenuItemEliminar)
        Me.ContextMenu1.MenuItems.Add(Me.MenuItemInsertar)
        '
        'MenuItemEliminar
        '
        Me.MenuItemEliminar.Text = "Eliminar"
        '
        'MenuItemInsertar
        '
        Me.MenuItemInsertar.Text = "Insertar fila"
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ButtonRegresarA)
        Me.Panel1.Controls.Add(Me.ButtonContinuarA)
        Me.Panel1.Controls.Add(Me.TabControlActivos)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'ButtonRegresarA
        '
        Me.ButtonRegresarA.Location = New System.Drawing.Point(84, 258)
        Me.ButtonRegresarA.Name = "ButtonRegresarA"
        Me.ButtonRegresarA.Size = New System.Drawing.Size(75, 24)
        Me.ButtonRegresarA.TabIndex = 5
        Me.ButtonRegresarA.Text = "ButtonRegresarA"
        '
        'ButtonContinuarA
        '
        Me.ButtonContinuarA.Location = New System.Drawing.Point(4, 258)
        Me.ButtonContinuarA.Name = "ButtonContinuarA"
        Me.ButtonContinuarA.Size = New System.Drawing.Size(75, 24)
        Me.ButtonContinuarA.TabIndex = 6
        Me.ButtonContinuarA.Text = "ButtonContinuarA"
        '
        'TabControlActivos
        '
        Me.TabControlActivos.Controls.Add(Me.TabPageActivo)
        Me.TabControlActivos.Controls.Add(Me.TabPageDetalle)
        Me.TabControlActivos.Controls.Add(Me.TabPageServicios)
        Me.TabControlActivos.Location = New System.Drawing.Point(0, 0)
        Me.TabControlActivos.Name = "TabControlActivos"
        Me.TabControlActivos.SelectedIndex = 0
        Me.TabControlActivos.Size = New System.Drawing.Size(242, 247)
        Me.TabControlActivos.TabIndex = 4
        '
        'TabPageActivo
        '
        Me.TabPageActivo.Controls.Add(Me.ComboBoxAsignacion)
        Me.TabPageActivo.Controls.Add(Me.LabelAsignacion)
        Me.TabPageActivo.Controls.Add(Me.ComboBoxFase)
        Me.TabPageActivo.Controls.Add(Me.ComboBoxEstado)
        Me.TabPageActivo.Controls.Add(Me.TextBoxCodB)
        Me.TabPageActivo.Controls.Add(Me.TextBoxNombre)
        Me.TabPageActivo.Controls.Add(Me.ComboBoxTipo)
        Me.TabPageActivo.Controls.Add(Me.TextBoxClave)
        Me.TabPageActivo.Controls.Add(Me.LabelFase)
        Me.TabPageActivo.Controls.Add(Me.LabelEstado)
        Me.TabPageActivo.Controls.Add(Me.LabelCodigoBarras)
        Me.TabPageActivo.Controls.Add(Me.LabelNombre)
        Me.TabPageActivo.Controls.Add(Me.LabelTipo)
        Me.TabPageActivo.Controls.Add(Me.LabelClave)
        Me.TabPageActivo.Location = New System.Drawing.Point(4, 25)
        Me.TabPageActivo.Name = "TabPageActivo"
        Me.TabPageActivo.Size = New System.Drawing.Size(234, 218)
        Me.TabPageActivo.Text = "TabPageActivo"
        '
        'ComboBoxAsignacion
        '
        Me.ComboBoxAsignacion.Location = New System.Drawing.Point(112, 161)
        Me.ComboBoxAsignacion.Name = "ComboBoxAsignacion"
        Me.ComboBoxAsignacion.Size = New System.Drawing.Size(104, 23)
        Me.ComboBoxAsignacion.TabIndex = 7
        '
        'LabelAsignacion
        '
        Me.LabelAsignacion.Location = New System.Drawing.Point(8, 161)
        Me.LabelAsignacion.Name = "LabelAsignacion"
        Me.LabelAsignacion.Size = New System.Drawing.Size(100, 22)
        Me.LabelAsignacion.Text = "LabelAsignacion"
        '
        'ComboBoxFase
        '
        Me.ComboBoxFase.Location = New System.Drawing.Point(112, 137)
        Me.ComboBoxFase.Name = "ComboBoxFase"
        Me.ComboBoxFase.Size = New System.Drawing.Size(104, 23)
        Me.ComboBoxFase.TabIndex = 6
        '
        'ComboBoxEstado
        '
        Me.ComboBoxEstado.Location = New System.Drawing.Point(112, 113)
        Me.ComboBoxEstado.Name = "ComboBoxEstado"
        Me.ComboBoxEstado.Size = New System.Drawing.Size(104, 23)
        Me.ComboBoxEstado.TabIndex = 5
        '
        'TextBoxCodB
        '
        Me.TextBoxCodB.Location = New System.Drawing.Point(112, 89)
        Me.TextBoxCodB.Name = "TextBoxCodB"
        Me.TextBoxCodB.Size = New System.Drawing.Size(104, 23)
        Me.TextBoxCodB.TabIndex = 4
        '
        'TextBoxNombre
        '
        Me.TextBoxNombre.Location = New System.Drawing.Point(112, 65)
        Me.TextBoxNombre.Name = "TextBoxNombre"
        Me.TextBoxNombre.Size = New System.Drawing.Size(104, 23)
        Me.TextBoxNombre.TabIndex = 3
        '
        'ComboBoxTipo
        '
        Me.ComboBoxTipo.Location = New System.Drawing.Point(112, 41)
        Me.ComboBoxTipo.Name = "ComboBoxTipo"
        Me.ComboBoxTipo.Size = New System.Drawing.Size(104, 23)
        Me.ComboBoxTipo.TabIndex = 2
        '
        'TextBoxClave
        '
        Me.TextBoxClave.Location = New System.Drawing.Point(112, 17)
        Me.TextBoxClave.Name = "TextBoxClave"
        Me.TextBoxClave.Size = New System.Drawing.Size(104, 23)
        Me.TextBoxClave.TabIndex = 1
        '
        'LabelFase
        '
        Me.LabelFase.Location = New System.Drawing.Point(8, 137)
        Me.LabelFase.Name = "LabelFase"
        Me.LabelFase.Size = New System.Drawing.Size(100, 22)
        Me.LabelFase.Text = "LabelFase"
        '
        'LabelEstado
        '
        Me.LabelEstado.Location = New System.Drawing.Point(8, 113)
        Me.LabelEstado.Name = "LabelEstado"
        Me.LabelEstado.Size = New System.Drawing.Size(100, 22)
        Me.LabelEstado.Text = "LabelEstado"
        '
        'LabelCodigoBarras
        '
        Me.LabelCodigoBarras.Location = New System.Drawing.Point(8, 89)
        Me.LabelCodigoBarras.Name = "LabelCodigoBarras"
        Me.LabelCodigoBarras.Size = New System.Drawing.Size(100, 20)
        Me.LabelCodigoBarras.Text = "LabelCodigoBarras"
        '
        'LabelNombre
        '
        Me.LabelNombre.Location = New System.Drawing.Point(8, 65)
        Me.LabelNombre.Name = "LabelNombre"
        Me.LabelNombre.Size = New System.Drawing.Size(100, 20)
        Me.LabelNombre.Text = "LabelNombre"
        '
        'LabelTipo
        '
        Me.LabelTipo.Location = New System.Drawing.Point(8, 41)
        Me.LabelTipo.Name = "LabelTipo"
        Me.LabelTipo.Size = New System.Drawing.Size(100, 20)
        Me.LabelTipo.Text = "LabelTipo"
        '
        'LabelClave
        '
        Me.LabelClave.Location = New System.Drawing.Point(8, 17)
        Me.LabelClave.Name = "LabelClave"
        Me.LabelClave.Size = New System.Drawing.Size(100, 20)
        Me.LabelClave.Text = "LabelClave"
        '
        'TabPageDetalle
        '
        Me.TabPageDetalle.Controls.Add(Me.TextBoxComentario)
        Me.TabPageDetalle.Controls.Add(Me.LabelComentario)
        Me.TabPageDetalle.Controls.Add(Me.TextBoxAncho)
        Me.TabPageDetalle.Controls.Add(Me.TextBoxAltura)
        Me.TabPageDetalle.Controls.Add(Me.TextBoxProfundidad)
        Me.TabPageDetalle.Controls.Add(Me.LabelProfundidad)
        Me.TabPageDetalle.Controls.Add(Me.LabelAncho)
        Me.TabPageDetalle.Controls.Add(Me.LabelAltura)
        Me.TabPageDetalle.Location = New System.Drawing.Point(4, 25)
        Me.TabPageDetalle.Name = "TabPageDetalle"
        Me.TabPageDetalle.Size = New System.Drawing.Size(234, 218)
        Me.TabPageDetalle.Text = "TabPageDetalle"
        '
        'TextBoxComentario
        '
        Me.TextBoxComentario.Location = New System.Drawing.Point(8, 109)
        Me.TextBoxComentario.Multiline = True
        Me.TextBoxComentario.Name = "TextBoxComentario"
        Me.TextBoxComentario.Size = New System.Drawing.Size(208, 100)
        Me.TextBoxComentario.TabIndex = 11
        '
        'LabelComentario
        '
        Me.LabelComentario.Location = New System.Drawing.Point(8, 89)
        Me.LabelComentario.Name = "LabelComentario"
        Me.LabelComentario.Size = New System.Drawing.Size(100, 20)
        Me.LabelComentario.Text = "LabelComentario"
        '
        'TextBoxAncho
        '
        Me.TextBoxAncho.Location = New System.Drawing.Point(112, 41)
        Me.TextBoxAncho.Name = "TextBoxAncho"
        Me.TextBoxAncho.Size = New System.Drawing.Size(104, 23)
        Me.TextBoxAncho.TabIndex = 9
        Me.TextBoxAncho.Text = "0"
        '
        'TextBoxAltura
        '
        Me.TextBoxAltura.Location = New System.Drawing.Point(112, 17)
        Me.TextBoxAltura.Name = "TextBoxAltura"
        Me.TextBoxAltura.Size = New System.Drawing.Size(104, 23)
        Me.TextBoxAltura.TabIndex = 8
        Me.TextBoxAltura.Text = "0"
        '
        'TextBoxProfundidad
        '
        Me.TextBoxProfundidad.Location = New System.Drawing.Point(112, 65)
        Me.TextBoxProfundidad.Name = "TextBoxProfundidad"
        Me.TextBoxProfundidad.Size = New System.Drawing.Size(104, 23)
        Me.TextBoxProfundidad.TabIndex = 10
        Me.TextBoxProfundidad.Text = "0"
        '
        'LabelProfundidad
        '
        Me.LabelProfundidad.Location = New System.Drawing.Point(8, 66)
        Me.LabelProfundidad.Name = "LabelProfundidad"
        Me.LabelProfundidad.Size = New System.Drawing.Size(100, 20)
        Me.LabelProfundidad.Text = "LabelProfundidad"
        '
        'LabelAncho
        '
        Me.LabelAncho.Location = New System.Drawing.Point(8, 42)
        Me.LabelAncho.Name = "LabelAncho"
        Me.LabelAncho.Size = New System.Drawing.Size(104, 20)
        Me.LabelAncho.Text = "LabelAncho"
        '
        'LabelAltura
        '
        Me.LabelAltura.Location = New System.Drawing.Point(8, 18)
        Me.LabelAltura.Name = "LabelAltura"
        Me.LabelAltura.Size = New System.Drawing.Size(100, 20)
        Me.LabelAltura.Text = "LabelAltura"
        '
        'TabPageServicios
        '
        Me.TabPageServicios.Controls.Add(Me.C1FlexGridServicios)
        Me.TabPageServicios.Location = New System.Drawing.Point(4, 25)
        Me.TabPageServicios.Name = "TabPageServicios"
        Me.TabPageServicios.Size = New System.Drawing.Size(234, 218)
        Me.TabPageServicios.Text = "TabPageServicios"
        '
        'C1FlexGridServicios
        '
        Me.C1FlexGridServicios.AllowEditing = True
        Me.C1FlexGridServicios.AutoResize = True
        Me.C1FlexGridServicios.AutoSearchDelay = 1
        Me.C1FlexGridServicios.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.C1FlexGridServicios.Clip = ""
        Me.C1FlexGridServicios.ClipSeparators = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13)
        Me.C1FlexGridServicios.Col = 0
        Me.C1FlexGridServicios.ColSel = 0
        Me.C1FlexGridServicios.ComboList = Nothing
        Me.C1FlexGridServicios.ContextMenu = Me.ContextMenu1
        Me.C1FlexGridServicios.EditMask = Nothing
        Me.C1FlexGridServicios.ExtendLastCol = False
        Me.C1FlexGridServicios.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.C1FlexGridServicios.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.C1FlexGridServicios.LeftCol = 1
        Me.C1FlexGridServicios.Location = New System.Drawing.Point(8, 17)
        Me.C1FlexGridServicios.Name = "C1FlexGridServicios"
        Me.C1FlexGridServicios.Redraw = True
        Me.C1FlexGridServicios.Row = 0
        Me.C1FlexGridServicios.RowSel = 0
        Me.C1FlexGridServicios.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.C1FlexGridServicios.ScrollTrack = True
        Me.C1FlexGridServicios.ShowCursor = False
        Me.C1FlexGridServicios.ShowSort = True
        Me.C1FlexGridServicios.Size = New System.Drawing.Size(224, 196)
        Me.C1FlexGridServicios.StyleInfo = resources.GetString("C1FlexGridServicios.StyleInfo")
        Me.C1FlexGridServicios.SupportInfo = "lgADAWcBgAFeAHsBcACaAK8AEgFiAZkAdQDPAOMAowD6AJcAnQAvAboAnABrAJMAWAG5AJ8ABwECAWQAB" & _
            "AGfAG0AGwH9AAUB2ACjAA=="
        Me.C1FlexGridServicios.TabIndex = 2
        Me.C1FlexGridServicios.TopRow = 1
        '
        'FormActivosDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenu1
        Me.Name = "FormActivosDetalle"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.TabControlActivos.ResumeLayout(False)
        Me.TabPageActivo.ResumeLayout(False)
        Me.TabPageDetalle.ResumeLayout(False)
        Me.TabPageServicios.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

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

#Region "FormActivosDetalle"
    Private Sub FormActivosDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        If Not Vista.Buscar("FormActivosDetalle", oVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        Nuevo = True
        oVista.ColocarEtiquetasForma(Me)
        PreparaFlexGrid()
        LlenaCombos()
        Cerrar = True
        If ActivoClave <> "" Then
            Nuevo = False
            LlenaDetalles()
            LlenaServicios()
            TextBoxClave.ReadOnly = True
        End If
        'CompletaFlexGrid()
        If C1FlexGridServicios.Rows.Count = 1 Then
            C1FlexGridServicios.Rows.Count = 2
        End If
        Cambios = False
        [Global].HabilitarMenuItem(MainMenu1, True)
        Cursor.Current = Cursors.Default
        If ActivoClave <> "" Then
            ComboBoxTipo.Focus()
        Else
            TextBoxClave.Focus()
        End If
    End Sub

    Private Sub TerminarVisita()
        ButtonRegresarA_Click(Nothing, Nothing)
    End Sub

#End Region

#Region "VARIABLES y CONSTANTES"
    Private oVista As Vista
    Private oValorRef As ValorReferencia
    Private Nuevo, Cambios, Cerrar As Boolean
    Private ActivoClave, VisitaClave, sClienteClave, sActivoClienteHistID As String
    Private Const Filas = 10
#End Region

#Region "FUNCIONES"
    Private Function ObtieneActivoServicioId(ByVal FG As C1.Win.C1FlexGrid.C1FlexGrid) As String
        Dim i As Integer = 1
        Dim Claves As String = ""
        For i = 1 To FG.Rows.Count - 1
            If FG.Item(i, 4) <> "" Then
                Claves &= "'" & FG.Item(i, 4) & "',"
            End If
        Next
        If Claves <> "" Then
            Claves = Microsoft.VisualBasic.Left(Claves, Claves.Length - 1)
        End If
        Return Claves
    End Function

    Private Function ValidaCampos() As Boolean
        If Nuevo Then
            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select activoclave from activo where activoclave='" & TextBoxClave.Text & "'", "Clave")
            If Dt.Rows.Count > 0 Then
                Dt.Dispose()
                MsgBox(oVista.BuscarMensaje("Mensajes", "BE0002"), MsgBoxStyle.Information)
                TextBoxClave.Focus()
                Return False
            End If
            Dt.Dispose()
        End If
        If TextBoxClave.Text = "" Then
            MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "BE0001"), LabelClave.Text), MsgBoxStyle.Information)
            TextBoxClave.Focus()
            Return False
        End If
        If IsNothing(ComboBoxTipo.SelectedValue) Then
            MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "BE0001"), LabelTipo.Text), MsgBoxStyle.Information)
            ComboBoxTipo.Focus()
            Return False
        End If
        If TextBoxNombre.Text = "" Then
            MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "BE0001"), LabelNombre.Text), MsgBoxStyle.Information)
            TextBoxNombre.Focus()
            Return False
        End If
        If IsNothing(ComboBoxEstado.SelectedValue) Then
            MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "BE0001"), LabelEstado.Text), MsgBoxStyle.Information)
            ComboBoxEstado.Focus()
            Return False
        End If
        If IsNothing(ComboBoxFase.SelectedValue) Then
            MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "BE0001"), LabelFase.Text), MsgBoxStyle.Information)
            ComboBoxFase.Focus()
            Return False
        End If
        If IsNothing(ComboBoxAsignacion.SelectedValue) Then
            MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "BE0001"), LabelAsignacion.Text), MsgBoxStyle.Information)
            ComboBoxAsignacion.Focus()
            Return False
        End If
        If Not IsNumeric(TextBoxAltura.Text) Then
            MsgBox(oVista.BuscarMensaje("Mensajes", "E0012"), MsgBoxStyle.Information)
            TextBoxAltura.Focus()
            Return False
        End If
        If Not IsNumeric(TextBoxAncho.Text) Then
            MsgBox(oVista.BuscarMensaje("Mensajes", "E0012"), MsgBoxStyle.Information)
            TextBoxAncho.Focus()
            Return False
        End If
        If Not IsNumeric(TextBoxProfundidad.Text) Then
            MsgBox(oVista.BuscarMensaje("Mensajes", "E0012"), MsgBoxStyle.Information)
            TextBoxProfundidad.Focus()
            Return False
        End If
        With C1FlexGridServicios
            Dim i As Integer
            For i = 1 To .Rows.Count - 1
                If Not validarFechaServicio(i) Then
                    Cerrar = False
                    .StartEditing(i, 0)
                    Return False
                ElseIf EsFechaValida(.Item(i, 0)) And .Item(i, 1) = "" Then
                    MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "BE0001"), .Cols(1).Caption))
                    Cerrar = False
                    If TabControlActivos.SelectedIndex <> 2 Then
                        Ir_A(2)
                    End If
                    .StartEditing(i, 1)
                    Return False
                End If
            Next
        End With
        Return True
    End Function

    'Private Function RegistroNuevo(ByVal ASI As String) As Boolean
    '    Dim Dt As DataTable = odbVen.RealizarConsultaSQL("select activoclave from activoservicio where activoclave='" & ActivoClave & "' and activoservicioid='" & ASI & "'", "RegistroNuevo")
    '    If Dt.Rows.Count = 0 Then
    '        Return True
    '    End If
    '    Return False
    'End Function

    Private Function GuardaDetalles() As Boolean
        Try
            Cerrar = True
            If Not ValidaCampos() Then
                Cerrar = False
                Me.Transaccion.Rollback()
                Return False
            End If

            Dim Query As String = String.Empty
            Dim Query2 As String = String.Empty
            If Nuevo Then
                Query = "insert into activo values('" & TextBoxClave.Text & "','" & TextBoxCodB.Text & "','" & TextBoxNombre.Text & "'," & ComboBoxTipo.SelectedValue & "," & ComboBoxEstado.SelectedValue & "," & ComboBoxFase.SelectedValue & "," & TextBoxAltura.Text & "," & TextBoxAncho.Text & "," & TextBoxProfundidad.Text & ",'" & TextBoxComentario.Text & "'," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "',0) "
                Query2 = "insert into activoClienteHist(ActivoClave,ActivoClienteHistID,ClienteClave,fecha,TipoEstado,TipoMotivo,Asignacion,Comentario,MFechaHora,MUsuarioID) values('" & TextBoxClave.Text & "','" & oApp.KEYGEN(1) & "','" & sClienteClave & "'," & UniFechaSQL(Now) & ",1,1," & Me.ComboBoxAsignacion.SelectedValue & ",null," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "')"
            Else
                Query = "update activo set nombre='" & TextBoxNombre.Text & "', tipo=" & ComboBoxTipo.SelectedValue & ", tipofase=" & ComboBoxFase.SelectedValue & ", tipoestado=" & ComboBoxEstado.SelectedValue & ", idelectronico='" & TextBoxCodB.Text & "', altura=" & TextBoxAltura.Text & ", ancho=" & TextBoxAncho.Text & ", profundidad=" & TextBoxProfundidad.Text & ", comentario='" & TextBoxComentario.Text & "', mfechahora=" & UniFechaSQL(Now) & ", musuarioid='" & oVendedor.UsuarioId & "',Enviado=0 where activoclave='" & ActivoClave & "'"
                Query2 = "update activoClienteHist set Asignacion=" & Me.ComboBoxAsignacion.SelectedValue & ", fecha=" & UniFechaSQL(Now) & ", mfechahora=" & UniFechaSQL(Now) & ", musuarioid='" & oVendedor.UsuarioId & "',Enviado=0 where activoclave='" & ActivoClave & "' and ActivoClienteHistID='" & sActivoClienteHistID & "' "
            End If

            If oDBVen.EjecutarComandoSQL(Query) = 0 Then
                MsgBox("El activo no se pudo guardar")
                Me.Transaccion.Rollback()
                Return False
            End If
            If Query2 <> String.Empty Then
                If oDBVen.EjecutarComandoSQL(Query2) = 0 Then
                    MsgBox("El activo no se pudo asignar")
                    Me.Transaccion.Rollback()
                    Return False
                End If
            End If
            Return True
        Catch ex As SqlServerCe.SqlCeException
            MsgBox("SQL Error: " & ex.Message, MsgBoxStyle.Information)
            Me.Transaccion.Rollback()
            Return False
        Catch ex As Exception
            MsgBox("SQL Error: " & ex.Message, MsgBoxStyle.Information)
            Me.Transaccion.Rollback()
            Return False
        End Try
    End Function
#End Region

#Region "MIS METODOS"
    Private Sub CompletaFlexGrid()
        Dim i As Integer
        With C1FlexGridServicios
            i = .Rows.Count
            If i < Filas Then
                .Rows.Count = Filas
            End If
        End With
    End Sub

    Private Sub LlenaCombos()
        Try
            Dim arrGral As New ArrayList
            Dim aValores As ArrayList = ValorReferencia.RecuperarLista("ACITIPO")
            If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
                For Each refDesc As ValorReferencia.Descripcion In aValores
                    arrGral.Add(New ComboGeneral(refDesc.Id, refDesc.Cadena))
                Next
                'For Each dr As DataRow In ValorReferencia.RecuperarLista("ACITIPO").Rows
                '    arrGral.Add(New ComboGeneral(dr(0), dr(1)))
                'Next
                ComboBoxTipo.DataSource = arrGral
                ComboBoxTipo.DisplayMember = "Concepto"
                ComboBoxTipo.ValueMember = "Valor"
            End If
            Dim arrGral2 As New ArrayList
            aValores = ValorReferencia.RecuperarLista("EDOREG")
            If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
                For Each refDesc As ValorReferencia.Descripcion In aValores
                    arrGral2.Add(New ComboGeneral(refDesc.Id, refDesc.Cadena))
                Next
                'For Each dr As DataRow In ValorReferencia.RecuperarLista("EDOREG").Rows
                '    arrGral2.Add(New ComboGeneral(dr(0), dr(1)))
                'Next
                ComboBoxEstado.DataSource = arrGral2
                ComboBoxEstado.DisplayMember = "Concepto"
                ComboBoxEstado.ValueMember = "Valor"
                ComboBoxEstado.SelectedValue = "1"
            End If
            Dim arrGral3 As New ArrayList
            aValores = ValorReferencia.RecuperarLista("ACIFASE")
            If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
                For Each refDesc As ValorReferencia.Descripcion In aValores
                    arrGral3.Add(New ComboGeneral(refDesc.Id, refDesc.Cadena))
                Next
                'For Each dr As DataRow In ValorReferencia.RecuperarLista("ACIFASE").Rows
                '    arrGral3.Add(New ComboGeneral(dr(0), dr(1)))
                'Next
                ComboBoxFase.DataSource = arrGral3
                ComboBoxFase.DisplayMember = "Concepto"
                ComboBoxFase.ValueMember = "Valor"
            End If
            Dim arrGral4 As New ArrayList
            aValores = ValorReferencia.RecuperarLista("ACHASIG")
            If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
                For Each refDesc As ValorReferencia.Descripcion In aValores
                    arrGral4.Add(New ComboGeneral(refDesc.Id, refDesc.Cadena))
                Next
                ComboBoxAsignacion.DataSource = arrGral4
                ComboBoxAsignacion.DisplayMember = "Concepto"
                ComboBoxAsignacion.ValueMember = "Valor"
                ComboBoxAsignacion.SelectedIndex = 0
            End If
            aValores = Nothing
            'With ComboBoxAsignacion
            '    .DataSource = ValorReferencia.RecuperarLista("ACHASIG")
            '    .DisplayMember = "Descripcion"
            '    .ValueMember = "VAVClave"
            '    .SelectedIndex = 0
            'End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Ir_A(ByVal Indice As Integer)
        TabControlActivos.SelectedIndex = Indice
    End Sub

    Private Sub PreparaFlexGrid()
        Dim Tipos As String = ""
        Dim ValoresTipo As New Hashtable
        With C1FlexGridServicios
            .Cols.Fixed = 0
            .Cols.Count = 5
            .ClipSeparators = vbTab + vbLf
            .Cols(0).Caption = oVista.BuscarMensaje("C1FlexGridServicios", "Fecha")
            .Cols(0).Width = 70
            '.Cols(0).DataType = GetType(Date)
            .Cols(0).EditMask = "99/99/9999"
            .Cols(0).AllowResizing = False
            .Cols(1).Caption = oVista.BuscarMensaje("C1FlexGridServicios", "Tipo")
            .Cols(1).Width = 130
            'Dim aRows As DataRowCollection = ValorReferencia.RecuperarLista("ASCTIPO", Tipos).Rows
            'For Each dr As DataRow In aRows
            '    ValoresTipo.Add(dr(0), dr(1))
            'Next
            Dim aValores As ArrayList = ValorReferencia.RecuperarLista("ASCTIPO")
            If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
                For Each refDesc As ValorReferencia.Descripcion In aValores
                    ValoresTipo.Add(refDesc.Id, refDesc.Cadena)
                Next
                .Cols(1).DataMap = ValoresTipo
            End If
            aValores = Nothing
            .Cols(1).AllowResizing = False
            .Cols(2).Caption = oVista.BuscarMensaje("C1FlexGridServicios", "Concepto")
            .Cols(2).Width = 80
            .Cols(3).Caption = oVista.BuscarMensaje("C1FlexGridServicios", "Comentario")
            .Cols(3).Width = 100
            .Cols(4).Width = 0
            .Cols(4).AllowEditing = False
            .Cols(3).AllowResizing = False
        End With
    End Sub

    Private Sub LimpiaDetalles()
        TextBoxClave.Text = ""
        If ComboBoxTipo.Items.Count > 0 Then
            ComboBoxTipo.SelectedIndex = 0
        End If
        TextBoxNombre.Text = ""
        TextBoxCodB.Text = ""
        TextBoxAltura.Text = "0"
        TextBoxAncho.Text = "0"
        TextBoxProfundidad.Text = "0"
        If ComboBoxEstado.Items.Count > 0 Then
            ComboBoxEstado.SelectedValue = "1"
        End If
        If ComboBoxFase.Items.Count > 0 Then
            ComboBoxFase.SelectedIndex = 0
        End If
        If ComboBoxAsignacion.Items.Count > 0 Then
            ComboBoxAsignacion.SelectedIndex = 0
        End If
        TextBoxComentario.Text = ""
        Cambios = False
    End Sub

    Private Sub LlenaDetalles()
        Try
            LimpiaDetalles()
            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select tipo, idelectronico, nombre, altura, ancho,profundidad, activo.tipoestado, activo.tipofase, asignacion, activo.comentario,ActivoClienteHistID from activo inner join ActivoClienteHist on Activo.ActivoClave = ActivoClienteHist.ActivoClave Where Fecha in(select max(fecha) from activoclientehist where activoclave=activo.activoclave) and Activo.ActivoClave ='" & ActivoClave & "'", "Detalles")
            Dim Dr As DataRow = Dt.Rows(0)
            TextBoxClave.Text = ActivoClave
            ComboBoxTipo.SelectedValue = Dr("tipo").ToString
            TextBoxNombre.Text = Dr("nombre")
            TextBoxCodB.Text = Dr("idelectronico")
            TextBoxAltura.Text = Dr("altura")
            TextBoxAncho.Text = Dr("ancho")
            TextBoxProfundidad.Text = Dr("profundidad")
            ComboBoxEstado.SelectedValue = Dr("tipoestado").ToString
            ComboBoxFase.SelectedValue = Dr("tipofase").ToString
            ComboBoxAsignacion.SelectedValue = IIf(IsDBNull(Dr("asignacion")), "1", Dr("asignacion").ToString)
            TextBoxComentario.Text = Dr("comentario")
            sActivoClienteHistID = Dr("ActivoClienteHistID")
            Cambios = False
            Dt.Dispose()
        Catch ex As SqlServerCe.SqlCeException
            MsgBox("SQL Error: " & ex.Message, MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("SQL Error: " & ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub LimpiaServicios()
        C1FlexGridServicios.Rows.Count = 1
    End Sub

    Private Sub LlenaServicios()
        LimpiaServicios()
        With C1FlexGridServicios
            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select activoservicioid, fechaservicio, tipo, concepto, comentario from activoservicio where activoclave='" & ActivoClave & "'", "servicios")
            Dim i As Integer = 1
            For Each Dr As DataRow In Dt.Rows
                .AddItem(CDate(Dr("fechaservicio")).ToString("dd/MM/yyyy") + vbTab + Dr("tipo").ToString + vbTab + Dr("concepto").ToString + vbTab + Dr("comentario").ToString + vbTab + Dr("activoservicioid").ToString)
            Next
            Dt.Dispose()
        End With
    End Sub

    Private Function GuardaServicios() As Boolean
        Try
            With C1FlexGridServicios
                'Se eliminan los registros que ya no son necesarios
                Dim Claves As String = ObtieneActivoServicioId(C1FlexGridServicios)
                If Claves <> "" Then
                    oDBVen.EjecutarComandoSQL("delete from activoservicio where activoclave='" & ActivoClave & "' and activoservicioid not in (" & Claves & ")")
                Else
                    oDBVen.EjecutarComandoSQL("delete from activoservicio where activoclave='" & ActivoClave & "'")
                End If
                'Guardo los campos
                Dim i As Integer, clave As String
                For i = 1 To .Rows.Count - 1
                    If Not (IsNothing(.Item(i, 0)) OrElse .Item(i, 0).ToString.Replace("/", "").Trim = String.Empty) AndAlso EsFechaValida(.Item(i, 0)) Then
                        If Not validarFechaServicio(i) Then
                            Me.Transaccion.Rollback()
                            .StartEditing(i, 0)
                            Return False
                        End If

                        clave = .Item(i, 4)
                        If clave = "" Then 'Insertar
                            If ActivoClave = "" Then
                                ActivoClave = Me.TextBoxClave.Text
                            End If
                            ' LMFM
                            'Dim sFecha As String() = .Item(i, 0).ToString().Split("/")
                            'Dim fechaS As DateTime = New DateTime(Convert.ToInt32(sFecha(2)), Convert.ToInt32(sFecha(1)), Convert.ToInt32(sFecha(0)))
                            Dim fechaS As DateTime = ConvertirFecha(.Item(i, 0).ToString())
                            oDBVen.EjecutarComandoSQL("insert into activoservicio values('" & ActivoClave & "','" & oApp.KEYGEN(i) & "'," & UniFechaSQL(fechaS) & "," & .Item(i, 1) & ",'" & .Item(i, 2) & "','" & .Item(i, 3) & "'," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "',0)")
                        Else 'Actualizar
                            Dim fechaS As DateTime = ConvertirFecha(.Item(i, 0).ToString())
                            oDBVen.EjecutarComandoSQL("update activoservicio set fechaservicio=" & UniFechaSQL(fechaS) & ", tipo=" & .Item(i, 1) & ", concepto='" & .Item(i, 2) & "', comentario='" & .Item(i, 3) & "', mfechahora=" & UniFechaSQL(Now) & ", musuarioid='" & oVendedor.UsuarioId & "',Enviado=0 where activoclave='" & ActivoClave & "' and activoservicioid='" & clave & "'")
                        End If
                    End If
                Next
            End With
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As SqlServerCe.SqlCeException
            MsgBox("SQL Error: " & ex.Message, MsgBoxStyle.Information)
            Me.Transaccion.Rollback()
            Return False
        Catch ex As Exception
            MsgBox("SQL Error: " & ex.Message, MsgBoxStyle.Information)
            Me.Transaccion.Rollback()
            Return False
        End Try
        Return True
    End Function

    Private Function EsFechaValida(ByVal pvFecha As String) As Boolean
        Try
            'Para verificar que el formato de la fecha sea dd/mm/yyyy
            Dim sFecha As String() = pvFecha.Split("/")
            Dim dFecha As DateTime = New DateTime(Convert.ToInt32(sFecha(2)), Convert.ToInt32(sFecha(1)), Convert.ToInt32(sFecha(0)))
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function ConvertirFecha(ByVal pvFecha As String) As Date
        Try
            'Para verificar que el formato de la fecha sea dd/mm/yyyy
            Dim sFecha As String() = pvFecha.Split("/")
            Dim dFecha As DateTime = New DateTime(Convert.ToInt32(sFecha(2)), Convert.ToInt32(sFecha(1)), Convert.ToInt32(sFecha(0)))
            Return dFecha
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function validarFechaServicio(ByVal pRow As Integer) As Boolean
        With C1FlexGridServicios
            If Not (IsNothing(.Item(pRow, 0)) OrElse .Item(pRow, 0).ToString.Replace("/", "").Trim = String.Empty) Then
                If Not EsFechaValida(.Item(pRow, 0)) Then
                    MessageBox.Show(oVista.BuscarMensaje("Mensajes", "E0601"), "")
                    Cerrar = False
                    If TabControlActivos.SelectedIndex <> 2 Then
                        TabControlActivos.SelectedIndex = 2
                    End If
                    Return False
                End If
                If ConvertirFecha(.Item(pRow, 0)) < DateSerial(1900, 1, 1) Then
                    MsgBox(oVista.BuscarMensaje("Mensajes", "E0352").Replace("$0$", "01/01/1900"))
                    Cerrar = False
                    If TabControlActivos.SelectedIndex <> 2 Then
                        TabControlActivos.SelectedIndex = 2
                    End If
                    Return False
                End If

                Cambios = True
            End If
        End With

        Return True
    End Function

#End Region

#Region "TabPageActivo"
    Private Sub TextBoxClave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    TextBoxClave.TextChanged, TextBoxNombre.TextChanged, TextBoxCodB.TextChanged, TextBoxAltura.TextChanged, _
    TextBoxAncho.TextChanged, TextBoxProfundidad.TextChanged, TextBoxComentario.TextChanged
        Cambios = True
    End Sub

    Private Sub ComboBoxTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ComboBoxTipo.SelectedIndexChanged, ComboBoxEstado.SelectedIndexChanged, ComboBoxFase.SelectedIndexChanged, ComboBoxAsignacion.SelectedIndexChanged
        Cambios = True
    End Sub

    Private Sub TextBoxAltura_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxAltura.LostFocus
        If TextBoxAltura.Text = "" OrElse Not IsNumeric(TextBoxAltura.Text) Then
            TextBoxAltura.Text = "0"
        End If
    End Sub

    Private Sub TextBoxAncho_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxAncho.LostFocus
        If TextBoxAncho.Text = "" OrElse Not IsNumeric(TextBoxAncho.Text) Then
            TextBoxAncho.Text = "0"
        End If
    End Sub

    Private Sub TextBoxProfundidad_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxProfundidad.LostFocus
        If TextBoxProfundidad.Text = "" OrElse Not IsNumeric(TextBoxProfundidad.Text) Then
            TextBoxProfundidad.Text = "0"
        End If
    End Sub

    Private Sub ButtonContinuarA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuarA.Click
        If oDBVen.oConexion.State = ConnectionState.Closed Then
            oDBVen.oConexion.Open()
        End If
        Me.Transaccion = oDBVen.oConexion.BeginTransaction()

        If GuardaDetalles() Then
            If GuardaServicios() Then
                Me.Transaccion.Commit()
            End If
        End If

        Me.Transaccion.Dispose()
        Me.Transaccion = Nothing
        If Cerrar Then Me.Close()
    End Sub

    Private Sub ButtonRegresarA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresarA.Click
        If Cambios Then
            If MsgBox(oVista.BuscarMensaje("Mensajes", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
                Me.Close()
            End If
            'Dim res As Object
            'res = MsgBox(oVista.BuscarMensaje("Mensajes", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation)
            'If res = vbYes Then
            '    Me.Close()
            'End If
        Else
            Me.Close()
        End If
    End Sub

#End Region

#Region "TabPageServicios"
    Private Sub MenuItemInsertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemInsertar.Click
        Cambios = True
        C1FlexGridServicios.Rows.Count += 1
        C1FlexGridServicios.StartEditing(C1FlexGridServicios.Rows.Count - 1, 0)
    End Sub

    Private Sub MenuItemEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemEliminar.Click
        Try
            Dim irow As Integer
            If C1FlexGridServicios.RowSel <= 0 Then Exit Sub
            irow = C1FlexGridServicios.RowSel

            With C1FlexGridServicios
                If .Rows.Count > 1 Then
                    .FinishEditing()
                    Cambios = True
                    .RemoveItem(irow)
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub C1FlexGridServicios_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGridServicios.AfterEdit
        With C1FlexGridServicios
            Select Case e.Col
                Case 3
                    If Not IsNothing(.Item(e.Row, 0)) AndAlso .Row = .Rows.Count - 1 Then
                        .Rows.Count += 1
                        .StartEditing(.Rows.Count - 1, 0)
                    End If
                    If Not IsNothing(C1FlexGridServicios.Item(e.Row, e.Col)) Then
                        If C1FlexGridServicios.Item(e.Row, e.Col) <> "" Then Cambios = True
                    End If
                Case 0
                    If Not validarFechaServicio(e.Row) Then
                        e.Cancel = True
                        C1FlexGridServicios.Select(e.Row, 0)
                        C1FlexGridServicios.Focus()
                    End If
                Case Else
                    If Not IsNothing(C1FlexGridServicios.Item(e.Row, e.Col)) Then
                        If C1FlexGridServicios.Item(e.Row, e.Col) <> "" Then Cambios = True
                    End If
            End Select
        End With
    End Sub
    Private Sub C1FlexGridServicios_StartEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGridServicios.StartEdit
        With C1FlexGridServicios
            Select Case e.Col

                Case 0
                    .SetData(e.Row, 0, " ")

            End Select
        End With
    End Sub
#End Region

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        ButtonRegresarA_Click(Nothing, Nothing)
    End Sub

    Private Sub TabControlActivos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControlActivos.SelectedIndexChanged
        Select Case TabControlActivos.SelectedIndex
            Case 0
                Me.TextBoxClave.SelectAll()
                Me.TextBoxClave.Focus()
            Case 1
                Me.TextBoxAltura.SelectAll()
                Me.TextBoxAltura.Focus()
            Case 2 : Me.C1FlexGridServicios.Focus()
        End Select
    End Sub


End Class
