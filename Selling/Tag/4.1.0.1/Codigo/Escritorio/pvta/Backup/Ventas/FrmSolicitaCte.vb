
Public Class FrmSolicitaCte
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
    Friend WithEvents GrpCliente As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnContinuar As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblNota As System.Windows.Forms.Label
    Friend WithEvents TxtNota As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSolicitaCte))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.GrpCliente = New System.Windows.Forms.GroupBox
        Me.LblNota = New System.Windows.Forms.Label
        Me.TxtNota = New System.Windows.Forms.TextBox
        Me.BtnContinuar = New Janus.Windows.EditControls.UIButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.GrpCliente.SuspendLayout()
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
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Name = "Label5"
        '
        'GrpCliente
        '
        resources.ApplyResources(Me.GrpCliente, "GrpCliente")
        Me.GrpCliente.Controls.Add(Me.LblNota)
        Me.GrpCliente.Controls.Add(Me.TxtNota)
        Me.GrpCliente.Controls.Add(Me.BtnContinuar)
        Me.GrpCliente.Controls.Add(Me.Label3)
        Me.GrpCliente.Name = "GrpCliente"
        Me.GrpCliente.TabStop = False
        '
        'LblNota
        '
        resources.ApplyResources(Me.LblNota, "LblNota")
        Me.LblNota.Name = "LblNota"
        '
        'TxtNota
        '
        resources.ApplyResources(Me.TxtNota, "TxtNota")
        Me.TxtNota.Name = "TxtNota"
        '
        'BtnContinuar
        '
        resources.ApplyResources(Me.BtnContinuar, "BtnContinuar")
        Me.BtnContinuar.Icon = CType(resources.GetObject("BtnContinuar.Icon"), System.Drawing.Icon)
        Me.BtnContinuar.Name = "BtnContinuar"
        Me.BtnContinuar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'FrmSolicitaCte
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.GrpCliente)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmSolicitaCte"
        Me.GrpCliente.ResumeLayout(False)
        Me.GrpCliente.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private bError As Boolean = False
    Public Nota As String = ""

    Private Sub FrmSolicitaCte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Show()
        Me.BringToFront()
    End Sub

    Private Sub FrmSolicitaCte_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

 
    Private Sub BtnContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnContinuar.Click
        If TxtNota.Text = "" Then
            MessageBox.Show("El campo Nota es requerido para indicar el nombre del cliente de credito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bError = True
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Else
            Nota = TxtNota.Text.ToUpper.Trim
            bError = False
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub BtnCtrl_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnContinuar.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Escape
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                bError = False
                Me.Close()
        End Select
    End Sub

    Private Sub TxtNota_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNota.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If TxtNota.Text = "" Then
                    bError = True
                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Else
                    Nota = TxtNota.Text.ToUpper.Trim
                    bError = False
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            Case Is = Keys.Escape

                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel

                bError = False
                Me.Close()
        End Select
    End Sub

End Class


