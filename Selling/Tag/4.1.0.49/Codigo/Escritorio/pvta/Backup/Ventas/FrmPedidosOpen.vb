Public Class FrmPedidosOpen
    Inherits System.Windows.Forms.Form

    Public dtVenta As DataTable
    Public VENClave As String
    Public Folio As String
    Public Cliente As String
    Public RazonSocial As String
    Public Cajero As String
    Public NombreUsuario As String
    Public Saldo As Double
    Public Total As Double
    Public Tipo As Integer
    Public Estado As Integer
    Public Limite As Double
    Public Dias As Integer
    Public SaldoCliente As Double
    Public AlmacenSurtido As String

    Friend WithEvents BtnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents GridPedidos As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPedidosOpen))
        Me.GridPedidos = New Janus.Windows.GridEX.GridEX
        Me.BtnAceptar = New Janus.Windows.EditControls.UIButton
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton
        CType(Me.GridPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridPedidos
        '
        Me.GridPedidos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridPedidos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPedidos.ColumnAutoResize = True
        Me.GridPedidos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridPedidos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridPedidos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridPedidos.GroupByBoxVisible = False
        Me.GridPedidos.Location = New System.Drawing.Point(2, 6)
        Me.GridPedidos.Name = "GridPedidos"
        Me.GridPedidos.RecordNavigator = True
        Me.GridPedidos.Size = New System.Drawing.Size(749, 385)
        Me.GridPedidos.TabIndex = 3
        Me.GridPedidos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnAceptar.Image = CType(resources.GetObject("BtnAceptar.Image"), System.Drawing.Image)
        Me.BtnAceptar.Location = New System.Drawing.Point(661, 397)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAceptar.TabIndex = 84
        Me.BtnAceptar.Text = "&Aceptar"
        Me.BtnAceptar.ToolTipText = "Guardar cambios"
        Me.BtnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(565, 398)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancel.TabIndex = 83
        Me.BtnCancel.Text = "&Salir"
        Me.BtnCancel.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmPedidosOpen
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(753, 441)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.GridPedidos)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(367, 386)
        Me.Name = "FrmPedidosOpen"
        Me.Text = "Consulta "
        CType(Me.GridPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmPedidosOpen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GridPedidos.DataSource = dtVenta
        GridPedidos.RetrieveStructure()
        GridPedidos.AutoSizeColumns()
        GridPedidos.RootTable.Columns("VENClave").Visible = False
        GridPedidos.RootTable.Columns("Cliente").Visible = False
        GridPedidos.RootTable.Columns("Cajero").Visible = False
        GridPedidos.RootTable.Columns("Tipo").Visible = False
        GridPedidos.RootTable.Columns("Estado").Visible = False
        Me.GridPedidos.RootTable.Columns("Total").Visible = False
        Me.GridPedidos.RootTable.Columns("Saldo").Visible = False
        Me.GridPedidos.RootTable.Columns("LimiteCredito").Visible = False
        Me.GridPedidos.RootTable.Columns("DiasCredito").Visible = False
        Me.GridPedidos.RootTable.Columns("SaldoCliente").Visible = False
        Me.GridPedidos.RootTable.Columns("ALMClave").Visible = False

        Me.GridPedidos.RootTable.Columns("Fecha").Width = 60
        Me.GridPedidos.RootTable.Columns("Clave").Width = 70
        Me.GridPedidos.RootTable.Columns("RazonSocial").Width = 230
        Me.GridPedidos.RootTable.Columns("Folio").Width = 50
        Me.GridPedidos.RootTable.Columns("NombreUsuario").Width = 100

    End Sub

    Private Sub agregar()
        If Not GridPedidos.GetValue(0) Is Nothing Then
            VENClave = GridPedidos.GetValue("VENClave")
            Folio = GridPedidos.GetValue("Folio")
            Cliente = GridPedidos.GetValue("Cliente")
            RazonSocial = GridPedidos.GetValue("RazonSocial")
            Cajero = GridPedidos.GetValue("Cajero")
            NombreUsuario = GridPedidos.GetValue("NombreUsuario")
            Saldo = GridPedidos.GetValue("Saldo")
            Total = GridPedidos.GetValue("Total")
            Tipo = GridPedidos.GetValue("Tipo")
            Estado = GridPedidos.GetValue("Estado")

            Limite = GridPedidos.GetValue("LimiteCredito")
            Dias = GridPedidos.GetValue("DiasCredito")
            SaldoCliente = GridPedidos.GetValue("SaldoCliente")


            If GridPedidos.GetValue("ALMClave").GetType.Name = "DBNull" Then
                AlmacenSurtido = ""
            Else
                AlmacenSurtido = GridPedidos.GetValue("ALMClave")
            End If


        Else
            VENClave = ""
            MessageBox.Show("Debe seleccionar un elemento de la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        agregar()
    End Sub

    Private Sub GridPedidos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridPedidos.DoubleClick
        agregar()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

End Class
