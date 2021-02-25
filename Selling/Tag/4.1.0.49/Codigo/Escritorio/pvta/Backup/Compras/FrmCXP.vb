Public Class FrmCXP
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
    Friend WithEvents GrpTickets As System.Windows.Forms.GroupBox
    Friend WithEvents GridCxP As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnPago As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtCompany As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Clock As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCXP))
        Me.GrpTickets = New System.Windows.Forms.GroupBox
        Me.GridCxP = New Janus.Windows.GridEX.GridEX
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.BtnPago = New Janus.Windows.EditControls.UIButton
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton
        Me.TxtCompany = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.GrpTickets.SuspendLayout()
        CType(Me.GridCxP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpTickets
        '
        Me.GrpTickets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpTickets.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpTickets.Controls.Add(Me.GridCxP)
        Me.GrpTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTickets.ForeColor = System.Drawing.Color.Black
        Me.GrpTickets.Location = New System.Drawing.Point(7, 32)
        Me.GrpTickets.Name = "GrpTickets"
        Me.GrpTickets.Size = New System.Drawing.Size(785, 391)
        Me.GrpTickets.TabIndex = 0
        Me.GrpTickets.TabStop = False
        Me.GrpTickets.Text = "Cuentas por Pagar"
        '
        'GridCxP
        '
        Me.GridCxP.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridCxP.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCxP.ColumnAutoResize = True
        Me.GridCxP.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridCxP.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridCxP.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridCxP.GroupByBoxVisible = False
        Me.GridCxP.Location = New System.Drawing.Point(7, 21)
        Me.GridCxP.Name = "GridCxP"
        Me.GridCxP.RecordNavigator = True
        Me.GridCxP.Size = New System.Drawing.Size(772, 364)
        Me.GridCxP.TabIndex = 4
        Me.GridCxP.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Clock
        '
        Me.Clock.Interval = 1000
        '
        'BtnPago
        '
        Me.BtnPago.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPago.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPago.Image = CType(resources.GetObject("BtnPago.Image"), System.Drawing.Image)
        Me.BtnPago.Location = New System.Drawing.Point(703, 429)
        Me.BtnPago.Name = "BtnPago"
        Me.BtnPago.Size = New System.Drawing.Size(90, 37)
        Me.BtnPago.TabIndex = 1
        Me.BtnPago.Text = "F5- Pagar"
        Me.BtnPago.ToolTipText = "Registrar Pago"
        Me.BtnPago.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(511, 429)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 7
        Me.BtnSalir.Text = "ESC- Salir"
        Me.BtnSalir.ToolTipText = "Salir"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtCompany
        '
        Me.TxtCompany.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCompany.Enabled = False
        Me.TxtCompany.Location = New System.Drawing.Point(136, 8)
        Me.TxtCompany.Name = "TxtCompany"
        Me.TxtCompany.ReadOnly = True
        Me.TxtCompany.Size = New System.Drawing.Size(535, 20)
        Me.TxtCompany.TabIndex = 98
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(20, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 15)
        Me.Label1.TabIndex = 97
        Me.Label1.Text = "Compañia"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(607, 429)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 100
        Me.BtnCancelar.Text = "F6- Cancelar"
        Me.BtnCancelar.ToolTipText = "Cancelar Pagos"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmCXP
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(799, 473)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.TxtCompany)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnPago)
        Me.Controls.Add(Me.BtnSalir)
        Me.Controls.Add(Me.GrpTickets)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmCXP"
        Me.Text = "Cuentas por Pagar"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpTickets.ResumeLayout(False)
        CType(Me.GridCxP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private PRVClave As String = ""
    Private sRazonSocial As String = ""
    Private bLoad As Boolean = False

    Public Sub RecuperaFolios()
        
        
        Cursor.Current = Cursors.WaitCursor
        ModPOS.ActualizaGrid(False, Me.GridCxP, "sp_obtener_cxp", "@COMClave", ModPOS.CompanyActual)
        Me.GridCxP.RootTable.Columns("PRVClave").Visible = False
        GridCxP.AutoSizeColumns()

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Pagar()
        If PRVClave <> "" Then
            Dim a As New FrmPagoCXP
            a.PRVClave = PRVClave
            a.sRazonSocial = Me.sRazonSocial
            a.ShowDialog()
            a.Dispose()
        End If
    End Sub

    Private Sub FrmCXP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.TxtCompany.Text = ModPOS.CompanyName

        
        bLoad = True

        RecuperaFolios()
    End Sub

    Private Sub FrmCXP_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.CxP.Dispose()
        ModPOS.CxP = Nothing
    End Sub

    Private Sub BtnPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPago.Click
        Pagar()
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub GridCxP_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridCxP.DoubleClick
        Pagar()
    End Sub


    Private Sub Controls_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, BtnPago.KeyUp, BtnSalir.KeyUp, GridCxP.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Escape
                BtnSalir.PerformClick()
            Case Is = Keys.F5
                Me.BtnPago.PerformClick()
            Case Is = Keys.F6
                Me.BtnCancelar.PerformClick()
        End Select
    End Sub



    Private Sub GridCxP_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridCxP.SelectionChanged
        If Not GridCxP.GetValue("PRVClave") Is Nothing Then
            Me.PRVClave = GridCxP.GetValue("PRVClave")
            sRazonSocial = GridCxP.GetValue("RazonSocial")
        Else
            Me.PRVClave = ""
            sRazonSocial = ""
        End If

    End Sub

    Private Sub BtnCancelar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Dim a As New FrmCancelacion
        a.ShowDialog()
        a.Dispose()
    End Sub


   
End Class
