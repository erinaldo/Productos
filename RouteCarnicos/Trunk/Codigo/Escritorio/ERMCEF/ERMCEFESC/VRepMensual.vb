Public Class VRepMensual
    Inherits System.Windows.Forms.Form
    Public vgDatos As ERMCEFLOG.cRepMensualHacienda

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
    Friend WithEvents ebContenedor As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents pnlBoton As System.Windows.Forms.Panel
    Friend WithEvents btGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btGuardarComo As Janus.Windows.EditControls.UIButton
    Friend WithEvents btCancelar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VRepMensual))
        Me.ebContenedor = New Janus.Windows.GridEX.EditControls.EditBox
        Me.pnlBoton = New System.Windows.Forms.Panel
        Me.btGuardar = New Janus.Windows.EditControls.UIButton
        Me.btCancelar = New Janus.Windows.EditControls.UIButton
        Me.btGuardarComo = New Janus.Windows.EditControls.UIButton
        Me.pnlBoton.SuspendLayout()
        Me.SuspendLayout()
        '
        'ebContenedor
        '
        Me.ebContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ebContenedor.Location = New System.Drawing.Point(0, 0)
        Me.ebContenedor.Multiline = True
        Me.ebContenedor.Name = "ebContenedor"
        Me.ebContenedor.ReadOnly = True
        Me.ebContenedor.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ebContenedor.Size = New System.Drawing.Size(624, 398)
        Me.ebContenedor.TabIndex = 0
        Me.ebContenedor.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebContenedor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'pnlBoton
        '
        Me.pnlBoton.Controls.Add(Me.btGuardarComo)
        Me.pnlBoton.Controls.Add(Me.btGuardar)
        Me.pnlBoton.Controls.Add(Me.btCancelar)
        Me.pnlBoton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBoton.Location = New System.Drawing.Point(0, 398)
        Me.pnlBoton.Name = "pnlBoton"
        Me.pnlBoton.Size = New System.Drawing.Size(624, 40)
        Me.pnlBoton.TabIndex = 1
        '
        'btGuardar
        '
        Me.btGuardar.Icon = CType(resources.GetObject("btGuardar.Icon"), System.Drawing.Icon)
        Me.btGuardar.Location = New System.Drawing.Point(259, 8)
        Me.btGuardar.Name = "btGuardar"
        Me.btGuardar.Size = New System.Drawing.Size(104, 24)
        Me.btGuardar.TabIndex = 37
        Me.btGuardar.Text = "btGuardar"
        Me.btGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btCancelar
        '
        Me.btCancelar.CausesValidation = False
        Me.btCancelar.Icon = CType(resources.GetObject("btCancelar.Icon"), System.Drawing.Icon)
        Me.btCancelar.Location = New System.Drawing.Point(504, 8)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(104, 24)
        Me.btCancelar.TabIndex = 38
        Me.btCancelar.Text = "btCancelar"
        Me.btCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btGuardarComo
        '
        Me.btGuardarComo.Icon = CType(resources.GetObject("btGuardarComo.Icon"), System.Drawing.Icon)
        Me.btGuardarComo.Location = New System.Drawing.Point(381, 8)
        Me.btGuardarComo.Name = "btGuardarComo"
        Me.btGuardarComo.Size = New System.Drawing.Size(104, 24)
        Me.btGuardarComo.TabIndex = 46
        Me.btGuardarComo.Text = "btGuardarComo"
        Me.btGuardarComo.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'VRepMensual
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(624, 438)
        Me.Controls.Add(Me.ebContenedor)
        Me.Controls.Add(Me.pnlBoton)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "VRepMensual"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "VRepMensual"
        Me.pnlBoton.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub VRepMensual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim vcMensaje As New BASMENLOG.CMensaje
        Me.btGuardar.Text = vcMensaje.RecuperarDescripcion("BtGuardar")
        Me.btGuardar.ToolTipText = vcMensaje.RecuperarDescripcion("BtAceptarT")
        Me.btCancelar.Text = vcMensaje.RecuperarDescripcion("BtCancelar")
        Me.btCancelar.ToolTipText = vcMensaje.RecuperarDescripcion("BtCancelarT")
        Me.btGuardarComo.Text = vcMensaje.RecuperarDescripcion("BtGuardarComo")
        Me.btGuardarComo.ToolTipText = vcMensaje.RecuperarDescripcion("BtGuardarComoT")

        Dim vlColeccion As ArrayList = vgDatos.Coleccion
        Me.Text = vgDatos.FILE_NAME
        If Not vlColeccion Is Nothing Then
            For Each vlRen As ERMCEFLOG.cRepMensualRenglones In vlColeccion
                Me.ebContenedor.Text &= vlRen.dameRenglon & vbCrLf
            Next
        End If
    End Sub

    Private Sub btCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancelar.Click
        Me.Close()
    End Sub

    Private Sub btGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGuardar.Click
        vgDatos.generarArchivo()
        Me.Close()
    End Sub

    Private Sub btGuardarComo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGuardarComo.Click
        Dim FBD As New FolderBrowserDialog
        FBD.SelectedPath = vgDatos.PATH

        If FBD.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If vgDatos.PATH <> FBD.SelectedPath Then
                vgDatos.PATH = FBD.SelectedPath
                vgDatos.generarArchivo()
            End If
            Me.Close()
        End If
    End Sub
End Class
