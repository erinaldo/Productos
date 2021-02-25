Public Class FrmMtoTicket
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpUnidades As System.Windows.Forms.GroupBox
    Friend WithEvents GridTickets As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoTicket))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton
        Me.GrpUnidades = New System.Windows.Forms.GroupBox
        Me.GridTickets = New Janus.Windows.GridEX.GridEX
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.GrpUnidades.SuspendLayout()
        CType(Me.GridTickets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(271, 337)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 15
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Image = CType(resources.GetObject("BtnModificar.Image"), System.Drawing.Image)
        Me.BtnModificar.Location = New System.Drawing.Point(463, 338)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 14
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar Ticket seleccionado"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(367, 337)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Eliminar Ticket seleccionado"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpUnidades
        '
        Me.GrpUnidades.Controls.Add(Me.BtnCancelar)
        Me.GrpUnidades.Controls.Add(Me.GridTickets)
        Me.GrpUnidades.Controls.Add(Me.BtnEliminar)
        Me.GrpUnidades.Controls.Add(Me.BtnModificar)
        Me.GrpUnidades.Controls.Add(Me.BtnAgregar)
        Me.GrpUnidades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpUnidades.Location = New System.Drawing.Point(0, 0)
        Me.GrpUnidades.Name = "GrpUnidades"
        Me.GrpUnidades.Size = New System.Drawing.Size(656, 380)
        Me.GrpUnidades.TabIndex = 11
        Me.GrpUnidades.TabStop = False
        Me.GrpUnidades.Text = "Formatos de Tickets"
        '
        'GridTickets
        '
        Me.GridTickets.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridTickets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridTickets.ColumnAutoResize = True
        Me.GridTickets.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridTickets.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridTickets.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridTickets.Location = New System.Drawing.Point(7, 15)
        Me.GridTickets.Name = "GridTickets"
        Me.GridTickets.RecordNavigator = True
        Me.GridTickets.Size = New System.Drawing.Size(642, 317)
        Me.GridTickets.TabIndex = 1
        Me.GridTickets.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(559, 337)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar nuevo Ticket"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoTicket
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(656, 380)
        Me.Controls.Add(Me.GrpUnidades)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(553, 378)
        Me.Name = "FrmMtoTicket"
        Me.Text = "Mantenimiento de Tickets"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpUnidades.ResumeLayout(False)
        CType(Me.GridTickets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sTicketSelected As String
    Private sNombre As String

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoTicket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor
        Try
            ModPOS.ActualizaGrid(True, Me.GridTickets, "sp_muestra_tickets", "@COMClave", ModPOS.CompanyActual)
            Me.GridTickets.RootTable.Columns("ID").Visible = False
        Catch z As Exception
        End Try

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub GridTickets_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridTickets.SelectionChanged
        If Not GridTickets.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sTicketSelected = GridTickets.GetValue(0)
            Me.sNombre = GridTickets.GetValue("Clave")
        Else
            Me.sTicketSelected = ""
            Me.sNombre = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Ticket Is Nothing Then
            ModPOS.Ticket = New FrmTicket
            With ModPOS.Ticket
                .Text = "Agregar Ticket"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .ChkEstado.Enabled = False
            End With
        End If
        ModPOS.Ticket.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Ticket.Show()
        ModPOS.Ticket.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificaTicket()
    End Sub

    Public Sub modificaTicket()
        If sTicketSelected <> "" Then

            If ModPOS.Ticket Is Nothing Then

                ModPOS.Ticket = New FrmTicket
                With ModPOS.Ticket
                    .Text = "Modificar Ticket"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    .TxtClave.ReadOnly = True

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_ticket", "@TIKClave", Me.sTicketSelected)

                    .TIKClave = dt.Rows(0)("TIKClave")
                    .Clave = dt.Rows(0)("Clave")
                    .Nombre = dt.Rows(0)("Nombre")
                    .Tipo = dt.Rows(0)("Tipo")
                    .FontName = dt.Rows(0)("FontName")
                    .FontSize = dt.Rows(0)("FontSize")
                    .MaxChar = dt.Rows(0)("MaxChar")
                    .url_imagen = dt.Rows(0)("url_imagen")
                    .Estado = dt.Rows(0)("Estado")
                    .SUCClave = IIf(dt.Rows(0)("SUCClave").GetType.Name = "DBNull", "", dt.Rows(0)("SUCClave"))
                    dt.Dispose()

                End With
            End If

            ModPOS.Ticket.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Ticket.Show()
            ModPOS.Ticket.BringToFront()

        End If
    End Sub

    Private Sub GridImpuestos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridTickets.DoubleClick
        modificaTicket()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sTicketSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el Ticket: " & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim Con As String = ModPOS.BDConexion
                    If ModPOS.SiExite(Con, "sp_ticket_vacio", "@TIKClave", CStr(sTicketSelected)) <> 0 Then
                        MessageBox.Show("El Ticket seleccionadO no puede ser eliminado ya que existen puntos de venta con dicho ticket", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else

                        ModPOS.Ejecuta("sp_elimina_ticket", "@TIKClave", sTicketSelected, "@Usuario", ModPOS.UsuarioActual)
                        ModPOS.ActualizaGrid(True, Me.GridTickets, "sp_muestra_tickets", "@COMClave", ModPOS.CompanyActual)
                        Me.GridTickets.RootTable.Columns("ID").Visible = False

                    End If

                Case DialogResult.No

            End Select
        End If
    End Sub

    Private Sub FrmMtoTicket_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoTicket.Dispose()
        ModPOS.MtoTicket = Nothing

    End Sub
End Class
