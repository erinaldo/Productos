
Public Class FrmObtieneAfiliado
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
    Friend WithEvents BtnIngresar As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblNota As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmObtieneAfiliado))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblNota = New System.Windows.Forms.Label()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.BtnIngresar = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.IndianRed
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.IndianRed
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Name = "Label2"
        '
        'LblNota
        '
        resources.ApplyResources(Me.LblNota, "LblNota")
        Me.LblNota.Name = "LblNota"
        '
        'TxtCliente
        '
        resources.ApplyResources(Me.TxtCliente, "TxtCliente")
        Me.TxtCliente.Name = "TxtCliente"
        '
        'BtnIngresar
        '
        resources.ApplyResources(Me.BtnIngresar, "BtnIngresar")
        Me.BtnIngresar.Name = "BtnIngresar"
        Me.BtnIngresar.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Blue
        Me.BtnIngresar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.IndianRed
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Name = "Label3"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.IndianRed
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Name = "Label5"
        '
        'FrmObtieneAfiliado
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LblNota)
        Me.Controls.Add(Me.TxtCliente)
        Me.Controls.Add(Me.BtnIngresar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmObtieneAfiliado"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private bError As Boolean = False

    Public CTEClave As String
  
    Private Sub FrmObtieneAfiliado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Show()
        Me.BringToFront()
    End Sub

    Private Sub FrmObtieneAfiliado_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub


    Private Sub BtnIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIngresar.Click
        If TxtCliente.Text <> "" Then

            If TxtCliente.Text.ToUpper.Trim = "12345" Then
                CTEClave = "12345"
                bError = False
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                Dim dt As DataTable
                dt = ModPOS.SiExisteRecupera("sp_recupera_clavecte", "@Clave", TxtCliente.Text.Trim.ToUpper.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual)
                If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                    CTEClave = dt.Rows(0)("CTEClave")
                    bError = False
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MessageBox.Show("No se encontro registro que coincida con el Número de Cliente proporcionado", "Error", MessageBoxButtons.OK)
                    bError = True
                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                End If
            End If

        Else
            MessageBox.Show("Debes escribir tu Número de Cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            bError = True
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub TxtCliente_Click(sender As Object, e As EventArgs) Handles TxtCliente.Click

        Dim a As New FrmTecladoNum
        a.Text = "Cliente"
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Me.TxtCliente.Text = CStr(a.Cantidad)
            BtnIngresar.PerformClick()
        End If
     End Sub

End Class


