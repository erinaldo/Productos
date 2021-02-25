Public Class FrmMenuT
    Inherits System.Windows.Forms.Form
    Public ActivarCotizacion As Boolean = True
    Public TipoDocumento As Integer
    Public NewTipoDocumento As Integer = 0


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
    Friend WithEvents BtnBarTrans As Janus.Windows.ButtonBar.ButtonBar

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ButtonBarGroup1 As Janus.Windows.ButtonBar.ButtonBarGroup = New Janus.Windows.ButtonBar.ButtonBarGroup
        Dim ButtonBarItem1 As Janus.Windows.ButtonBar.ButtonBarItem = New Janus.Windows.ButtonBar.ButtonBarItem
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMenuT))
        Dim ButtonBarItem2 As Janus.Windows.ButtonBar.ButtonBarItem = New Janus.Windows.ButtonBar.ButtonBarItem
        Dim ButtonBarItem3 As Janus.Windows.ButtonBar.ButtonBarItem = New Janus.Windows.ButtonBar.ButtonBarItem
        Dim ButtonBarItem4 As Janus.Windows.ButtonBar.ButtonBarItem = New Janus.Windows.ButtonBar.ButtonBarItem
        Me.BtnBarTrans = New Janus.Windows.ButtonBar.ButtonBar
        CType(Me.BtnBarTrans, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnBarTrans
        '
        Me.BtnBarTrans.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ButtonBarGroup1.ImageAlignment = Janus.Windows.ButtonBar.Alignment.Far
        ButtonBarItem1.Icon = CType(resources.GetObject("ButtonBarItem1.Icon"), System.Drawing.Icon)
        ButtonBarItem1.ImageAlignment = Janus.Windows.ButtonBar.Alignment.Far
        ButtonBarItem1.Key = "Contado"
        ButtonBarItem1.Text = "VTA. CONTADO"
        ButtonBarItem1.ToolTipText = "Convertir a Venta de Contado"
        ButtonBarItem2.Icon = CType(resources.GetObject("ButtonBarItem2.Icon"), System.Drawing.Icon)
        ButtonBarItem2.Key = "Cotizacion"
        ButtonBarItem2.Text = "COTIZACIÓN"
        ButtonBarItem2.ToolTipText = "Convertir a Cotización"
        ButtonBarItem3.Icon = CType(resources.GetObject("ButtonBarItem3.Icon"), System.Drawing.Icon)
        ButtonBarItem3.Key = "Credito"
        ButtonBarItem3.Text = "VTA. CRÉDITO"
        ButtonBarItem3.ToolTipText = "Convertir a Venta a Crédito"
        ButtonBarItem4.Icon = CType(resources.GetObject("ButtonBarItem4.Icon"), System.Drawing.Icon)
        ButtonBarItem4.Key = "Apartado"
        ButtonBarItem4.Text = "APARTADO"
        ButtonBarItem4.ToolTipText = "Convertir a Apartado"
        ButtonBarGroup1.Items.AddRange(New Janus.Windows.ButtonBar.ButtonBarItem() {ButtonBarItem1, ButtonBarItem2, ButtonBarItem3, ButtonBarItem4})
        ButtonBarGroup1.Key = "Group1"
        ButtonBarGroup1.Text = "CONVERTIR A:"
        Me.BtnBarTrans.Groups.AddRange(New Janus.Windows.ButtonBar.ButtonBarGroup() {ButtonBarGroup1})
        Me.BtnBarTrans.Location = New System.Drawing.Point(0, 0)
        Me.BtnBarTrans.Name = "BtnBarTrans"
        Me.BtnBarTrans.SelectionArea = Janus.Windows.ButtonBar.SelectionArea.FullItem
        Me.BtnBarTrans.Size = New System.Drawing.Size(167, 350)
        Me.BtnBarTrans.TabIndex = 0
        Me.BtnBarTrans.Text = "ButtonBar1"
        Me.BtnBarTrans.VisualStyle = Janus.Windows.ButtonBar.VisualStyle.Office2007
        Me.BtnBarTrans.VisualStyleAreas.BackgroundStyle = Janus.Windows.ButtonBar.VisualStyle.Office2007
        Me.BtnBarTrans.VisualStyleAreas.ControlBorderStyle = Janus.Windows.ButtonBar.VisualStyle.Office2007
        Me.BtnBarTrans.VisualStyleAreas.GroupsStyle = Janus.Windows.ButtonBar.VisualStyle.Office2007
        Me.BtnBarTrans.VisualStyleAreas.ItemsStyle = Janus.Windows.ButtonBar.VisualStyle.Office2007
        '
        'FrmMenuT
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(167, 350)
        Me.Controls.Add(Me.BtnBarTrans)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMenuT"
        CType(Me.BtnBarTrans, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub BtnBarTrans_ItemClick(ByVal sender As System.Object, ByVal e As Janus.Windows.ButtonBar.ItemEventArgs) Handles BtnBarTrans.ItemClick
        Select Case e.Item.Key
            Case "Contado"
                NewTipoDocumento = 1
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Case "Cotizacion"
                NewTipoDocumento = 2
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Case "Credito"
                NewTipoDocumento = 3
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Case "Apartado"
                NewTipoDocumento = 4
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Select
    End Sub

    Private Sub FrmMenuT_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.BtnBarTrans.Groups(0).Items("Cotizacion").Enabled = ActivarCotizacion

        Select Case TipoDocumento
            Case 1
                Me.BtnBarTrans.Groups(0).Items("Contado").Enabled = False
            Case 2
                Me.BtnBarTrans.Groups(0).Items("Cotizacion").Enabled = False
            Case 3
                Me.BtnBarTrans.Groups(0).Items("Credito").Enabled = False
            Case 4
                Me.BtnBarTrans.Groups(0).Items("Apartado").Enabled = False
        End Select



    End Sub
End Class
