Public Class FrmNota
    Inherits System.Windows.Forms.Form

    Public CMDClave As String
    Public DCMClave As String
    Public PROClave As String
    Public Clave As String
    Public Nombre As String
    Private Regis As Double
    Private bActualizar As Boolean
    
    Private Registrados As Integer = 0
    
    Friend WithEvents TxtNota As System.Windows.Forms.TextBox
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblCant As System.Windows.Forms.Label
    Friend WithEvents GrpNota As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label


    

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNota))
        Me.TxtNota = New System.Windows.Forms.TextBox
        Me.LblClave = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblNombre = New System.Windows.Forms.Label
        Me.LblCant = New System.Windows.Forms.Label
        Me.GrpNota = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GrpNota.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtNota
        '
        Me.TxtNota.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNota.Location = New System.Drawing.Point(10, 19)
        Me.TxtNota.Name = "TxtNota"
        Me.TxtNota.Size = New System.Drawing.Size(434, 26)
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
        Me.LblClave.Size = New System.Drawing.Size(358, 24)
        Me.LblClave.TabIndex = 77
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(5, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 24)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "CLAVE:"
        '
        'LblNombre
        '
        Me.LblNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblNombre.BackColor = System.Drawing.Color.Transparent
        Me.LblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblNombre.Location = New System.Drawing.Point(5, 41)
        Me.LblNombre.MinimumSize = New System.Drawing.Size(436, 41)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(449, 41)
        Me.LblNombre.TabIndex = 75
        Me.LblNombre.Text = "PRODUCTO:"
        '
        'LblCant
        '
        Me.LblCant.BackColor = System.Drawing.Color.Transparent
        Me.LblCant.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCant.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblCant.Location = New System.Drawing.Point(115, 47)
        Me.LblCant.Name = "LblCant"
        Me.LblCant.Size = New System.Drawing.Size(98, 23)
        Me.LblCant.TabIndex = 78
        Me.LblCant.Text = "NUM. SERIE:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.LblCant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GrpNota
        '
        Me.GrpNota.Controls.Add(Me.Label4)
        Me.GrpNota.Controls.Add(Me.Label1)
        Me.GrpNota.Controls.Add(Me.TxtNota)
        Me.GrpNota.Controls.Add(Me.LblCant)
        Me.GrpNota.Location = New System.Drawing.Point(2, 79)
        Me.GrpNota.MaximumSize = New System.Drawing.Size(448, 78)
        Me.GrpNota.Name = "GrpNota"
        Me.GrpNota.Size = New System.Drawing.Size(448, 72)
        Me.GrpNota.TabIndex = 79
        Me.GrpNota.TabStop = False
        Me.GrpNota.Text = "Nota"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(2, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 23)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "CARACTERES:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(309, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 13)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "Presione ENTER- Guardar"
        '
        'FrmNota
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(457, 173)
        Me.Controls.Add(Me.GrpNota)
        Me.Controls.Add(Me.LblClave)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblNombre)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmNota"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GrpNota.ResumeLayout(False)
        Me.GrpNota.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub



    Private Sub FrmNota_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen
        LblClave.Text = Clave
        LblNombre.Text = Nombre

        Dim dtNota As DataTable
        dtNota = ModPOS.Recupera_Tabla("sp_recupera_nota_cmd", "@DCMClave", DCMClave)

        If dtNota.Rows.Count > 0 Then
            TxtNota.Text = dtNota.Rows(0)("Nota")
            bActualizar = True
        Else
            bActualizar = False
            TxtNota.Text = ""
        End If
        dtNota.Dispose()

        LblCant.Text = CStr(TxtNota.Text.Length) & "/" & "30"
        TxtNota.Select(TxtNota.TextLength, 0)
    End Sub

    Private Sub TxtSerial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNota.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If bActualizar = True Then
                ModPOS.Ejecuta("sp_actualiza_nota", "@DCMClave", DCMClave, "@Nota", TxtNota.Text.ToUpper.Trim)
            Else
                ModPOS.Ejecuta("sp_inserta_nota", "@DCMClave", DCMClave, "@Nota", TxtNota.Text.ToUpper.Trim)
            End If
            Close()
        ElseIf Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If

    End Sub




    Private Sub TxtNota_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNota.KeyUp
        If TxtNota.Text.Length > 30 Then
            TxtNota.Text = TxtNota.Text.Substring(0, 30)
            TxtNota.Select(TxtNota.TextLength, 0)
        End If
        LblCant.Text = CStr(TxtNota.Text.Length) & "/" & "30"
    End Sub
End Class
