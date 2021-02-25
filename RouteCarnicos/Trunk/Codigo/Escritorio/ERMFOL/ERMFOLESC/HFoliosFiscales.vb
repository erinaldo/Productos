Imports BASMENLOG
Imports ERMFOLLOG

Public Class HFoliosFiscales
    Inherits System.Windows.Forms.Form

    Public vcFolio As cFolio

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
    Friend WithEvents pnlInferior As System.Windows.Forms.Panel
    Friend WithEvents CtrlFoliosFiscales1 As ERMFOLESC.ctrlFoliosFiscales
    Friend WithEvents btAceptar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(HFoliosFiscales))
        Me.pnlInferior = New System.Windows.Forms.Panel
        Me.btAceptar = New Janus.Windows.EditControls.UIButton
        Me.CtrlFoliosFiscales1 = New ERMFOLESC.ctrlFoliosFiscales
        Me.pnlInferior.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlInferior
        '
        Me.pnlInferior.Controls.Add(Me.btAceptar)
        Me.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInferior.Location = New System.Drawing.Point(0, 536)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(882, 40)
        Me.pnlInferior.TabIndex = 15
        '
        'btAceptar
        '
        Me.btAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btAceptar.Icon = CType(resources.GetObject("btAceptar.Icon"), System.Drawing.Icon)
        Me.btAceptar.Location = New System.Drawing.Point(744, 8)
        Me.btAceptar.Name = "btAceptar"
        Me.btAceptar.Size = New System.Drawing.Size(104, 24)
        Me.btAceptar.TabIndex = 49
        Me.btAceptar.Text = "btAceptar"
        '
        'CtrlFoliosFiscales1
        '
        Me.CtrlFoliosFiscales1.BackColor = System.Drawing.SystemColors.Control
        Me.CtrlFoliosFiscales1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlFoliosFiscales1.Location = New System.Drawing.Point(0, 0)
        Me.CtrlFoliosFiscales1.Name = "CtrlFoliosFiscales1"
        Me.CtrlFoliosFiscales1.Size = New System.Drawing.Size(882, 536)
        Me.CtrlFoliosFiscales1.TabIndex = 16
        '
        'HFoliosFiscales
        '
        Me.AcceptButton = Me.btAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btAceptar
        Me.ClientSize = New System.Drawing.Size(882, 576)
        Me.Controls.Add(Me.CtrlFoliosFiscales1)
        Me.Controls.Add(Me.pnlInferior)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(888, 608)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(888, 608)
        Me.Name = "HFoliosFiscales"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HFoliosFiscales"
        Me.pnlInferior.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAceptar.Click
        Me.Close()
    End Sub

    Private Sub HFoliosFiscales_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim vcMensaje As New CMensaje

        Me.CtrlFoliosFiscales1.CargarHistorico(eModo.Leer, vcFolio, vcMensaje)

        Me.Text = vcMensaje.RecuperarDescripcion("FSHHistorico")
        Me.btAceptar.Text = vcMensaje.RecuperarDescripcion("btSalir")

        Dim vlToolTip As New System.Windows.Forms.ToolTip
        With vlToolTip
            .ShowAlways = True
            .SetToolTip(Me.btAceptar, vcMensaje.RecuperarDescripcion("btSalirT"))
        End With
    End Sub
End Class
