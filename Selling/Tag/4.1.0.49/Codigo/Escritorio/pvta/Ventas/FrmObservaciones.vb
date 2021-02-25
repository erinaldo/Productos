Public Class FrmObservaciones
    Inherits System.Windows.Forms.Form

    Public Nota As String
    Private Registrados As Integer = 0
    Public TotalCaracteres As Integer = 500
    Public MaxLineas As Integer = 0
    Public lineas As Integer = 0

    Private olineas As Integer = 0

    Friend WithEvents TxtNota As System.Windows.Forms.TextBox
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents GrpNota As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblCant As System.Windows.Forms.Label




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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmObservaciones))
        Me.TxtNota = New System.Windows.Forms.TextBox
        Me.LblClave = New System.Windows.Forms.Label
        Me.GrpNota = New System.Windows.Forms.GroupBox
        Me.BtnOK = New Janus.Windows.EditControls.UIButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.LblCant = New System.Windows.Forms.Label
        Me.GrpNota.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtNota
        '
        Me.TxtNota.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNota.Location = New System.Drawing.Point(5, 18)
        Me.TxtNota.Multiline = True
        Me.TxtNota.Name = "TxtNota"
        Me.TxtNota.Size = New System.Drawing.Size(357, 101)
        Me.TxtNota.TabIndex = 74
        '
        'LblClave
        '
        Me.LblClave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblClave.BackColor = System.Drawing.Color.Transparent
        Me.LblClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblClave.Location = New System.Drawing.Point(89, 8)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(270, 24)
        Me.LblClave.TabIndex = 77
        '
        'GrpNota
        '
        Me.GrpNota.Controls.Add(Me.BtnOK)
        Me.GrpNota.Controls.Add(Me.Label4)
        Me.GrpNota.Controls.Add(Me.TxtNota)
        Me.GrpNota.Controls.Add(Me.LblCant)
        Me.GrpNota.Location = New System.Drawing.Point(2, 3)
        Me.GrpNota.Name = "GrpNota"
        Me.GrpNota.Size = New System.Drawing.Size(366, 167)
        Me.GrpNota.TabIndex = 79
        Me.GrpNota.TabStop = False
        Me.GrpNota.Text = "Nota"
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Location = New System.Drawing.Point(269, 125)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(90, 37)
        Me.BtnOK.TabIndex = 82
        Me.BtnOK.Text = "Aceptar"
        Me.BtnOK.ToolTipText = "Autorizar transacción"
        Me.BtnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(2, 132)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(145, 22)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "CARACTERES:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblCant
        '
        Me.LblCant.BackColor = System.Drawing.Color.Transparent
        Me.LblCant.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCant.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblCant.Location = New System.Drawing.Point(153, 132)
        Me.LblCant.Name = "LblCant"
        Me.LblCant.Size = New System.Drawing.Size(98, 22)
        Me.LblCant.TabIndex = 78
        Me.LblCant.Text = "NUM. SERIE:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.LblCant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmObservaciones
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(369, 174)
        Me.Controls.Add(Me.GrpNota)
        Me.Controls.Add(Me.LblClave)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(385, 213)
        Me.MinimizeBox = False
        Me.Name = "FrmObservaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Obseraciones"
        Me.GrpNota.ResumeLayout(False)
        Me.GrpNota.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub



    Private Sub FrmObservaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen
        TxtNota.Text = Nota

        olineas = lineas
        LblCant.Text = CStr(TxtNota.Text.Length) & "/" & CStr(TotalCaracteres)
        TxtNota.Select(TxtNota.TextLength, 0)
    End Sub

    Private Sub TxtSerial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNota.KeyPress

        If Asc(e.KeyChar) = 13 Then
            If MaxLineas < olineas Then
                olineas += 1
                If olineas >= 5 Then
                    MessageBox.Show("Solo seran visibles en la factura las primeras 5 lineas", "Advertencia", MessageBoxButtons.OK)
                End If
            Else
                Me.Close()
            End If
        ElseIf Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub TxtNota_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNota.KeyUp
        If TxtNota.Text.Length > TotalCaracteres Then
            TxtNota.Text = TxtNota.Text.Substring(0, TotalCaracteres)
            TxtNota.Select(TxtNota.TextLength, 0)
        End If
        LblCant.Text = CStr(TxtNota.Text.Length) & "/" & CStr(TotalCaracteres)
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        Nota = TxtNota.Text
        lineas = olineas
        Me.Close()
    End Sub
End Class
