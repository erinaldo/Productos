
Public Class FrmSolicitaNegado
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSimilares As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnBuscar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnNegado As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblExistencia As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSolicitaNegado))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblExistencia = New System.Windows.Forms.Label()
        Me.btnSimilares = New Janus.Windows.EditControls.UIButton()
        Me.btnBuscar = New Janus.Windows.EditControls.UIButton()
        Me.btnNegado = New Janus.Windows.EditControls.UIButton()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Name = "Label2"
        '
        'lblExistencia
        '
        Me.lblExistencia.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.lblExistencia, "lblExistencia")
        Me.lblExistencia.ForeColor = System.Drawing.Color.White
        Me.lblExistencia.Name = "lblExistencia"
        '
        'btnSimilares
        '
        resources.ApplyResources(Me.btnSimilares, "btnSimilares")
        Me.btnSimilares.Icon = CType(resources.GetObject("btnSimilares.Icon"), System.Drawing.Icon)
        Me.btnSimilares.Name = "btnSimilares"
        Me.btnSimilares.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.btnSimilares.Office2007CustomColor = System.Drawing.Color.IndianRed
        Me.btnSimilares.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnBuscar
        '
        resources.ApplyResources(Me.btnBuscar, "btnBuscar")
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Office2007CustomColor = System.Drawing.Color.IndianRed
        Me.btnBuscar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnNegado
        '
        resources.ApplyResources(Me.btnNegado, "btnNegado")
        Me.btnNegado.Name = "btnNegado"
        Me.btnNegado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmSolicitaNegado
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.btnNegado)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.lblExistencia)
        Me.Controls.Add(Me.btnSimilares)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmSolicitaNegado"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private bError As Boolean = False
    Public Accion As String = ""
    Public PROClave As String

    Private Sub FrmSolicitaNegado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Show()
        Me.BringToFront()
    End Sub

    Private Sub FrmSolicitaNegado_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub


    Private Sub btSimilares_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimilares.Click

        Accion = "Similares"

        'If TxtNota.Text = "" Then
        MessageBox.Show("No se encontraron productos similares", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    bError = True
        '    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        'Else
        '    Nota = TxtNota.Text.ToUpper.Trim
        bError = False
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        'End If
    End Sub

  
   
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        Accion = "Buscar"

        'If TxtNota.Text = "" Then
        MessageBox.Show("No se encontraron productos disponibles en otra Sucursal", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    bError = True
        '    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        'Else
        '    Nota = TxtNota.Text.ToUpper.Trim
        bError = False
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        'End If
    End Sub

    Private Sub btnNegado_Click(sender As Object, e As EventArgs) Handles btnNegado.Click

        Accion = "Negado"

       
        bError = False
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        'End If
    End Sub
End Class


