Public Class FrmSerial
    Inherits System.Windows.Forms.Form

    Public TipoDoc As Integer
    Public TipoMov As Integer
    Public DOCClave As String
    Public PROClave As String
    Public Clave As String
    Public Nombre As String
    Public Cantidad As Double
    Public Dias As Integer

    '1: Venta 2:Devolucion

    Private Serial As String
    Private Registrados As Double = 0
    Private Regis As Double = 1

    Friend WithEvents TxtSerial As System.Windows.Forms.TextBox
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblCant As System.Windows.Forms.Label
    Friend WithEvents GrpSerial As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

    
    Public ReadOnly Property NumSerialRegistrados() As Double
        Get
            NumSerialRegistrados = Registrados
        End Get
    End Property


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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSerial))
        Me.TxtSerial = New System.Windows.Forms.TextBox
        Me.LblClave = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblNombre = New System.Windows.Forms.Label
        Me.LblCant = New System.Windows.Forms.Label
        Me.GrpSerial = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GrpSerial.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtSerial
        '
        Me.TxtSerial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSerial.Location = New System.Drawing.Point(140, 19)
        Me.TxtSerial.Name = "TxtSerial"
        Me.TxtSerial.Size = New System.Drawing.Size(292, 20)
        Me.TxtSerial.TabIndex = 74
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
        Me.LblClave.Size = New System.Drawing.Size(347, 24)
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
        Me.LblNombre.Size = New System.Drawing.Size(436, 41)
        Me.LblNombre.TabIndex = 75
        Me.LblNombre.Text = "PRODUCTO:"
        '
        'LblCant
        '
        Me.LblCant.BackColor = System.Drawing.Color.Transparent
        Me.LblCant.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCant.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblCant.Location = New System.Drawing.Point(115, 46)
        Me.LblCant.Name = "LblCant"
        Me.LblCant.Size = New System.Drawing.Size(317, 23)
        Me.LblCant.TabIndex = 78
        Me.LblCant.Text = "NUM. SERIE:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.LblCant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GrpSerial
        '
        Me.GrpSerial.Controls.Add(Me.Label4)
        Me.GrpSerial.Controls.Add(Me.Label3)
        Me.GrpSerial.Controls.Add(Me.TxtSerial)
        Me.GrpSerial.Controls.Add(Me.LblCant)
        Me.GrpSerial.Location = New System.Drawing.Point(2, 82)
        Me.GrpSerial.MaximumSize = New System.Drawing.Size(448, 78)
        Me.GrpSerial.Name = "GrpSerial"
        Me.GrpSerial.Size = New System.Drawing.Size(439, 72)
        Me.GrpSerial.TabIndex = 79
        Me.GrpSerial.TabStop = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Location = New System.Drawing.Point(6, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 23)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "REGISTRO:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(10, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 23)
        Me.Label3.TabIndex = 80
        Me.Label3.Text = "NUM. SERIE:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(309, 157)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 13)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "Presione ENTER- Guardar"
        '
        'FrmSerial
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(446, 173)
        Me.Controls.Add(Me.GrpSerial)
        Me.Controls.Add(Me.LblClave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblNombre)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSerial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GrpSerial.ResumeLayout(False)
        Me.GrpSerial.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub



    Private Sub Serial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen
        LblClave.Text = Clave
        LblNombre.Text = Nombre
        LblCant.Text = CStr(Regis) & "/" & CStr(Cantidad)


    End Sub

    Private Sub TxtSerial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSerial.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If TxtSerial.Text <> "" Then
                Serial = TxtSerial.Text.ToUpper.Trim
                If ModPOS.SiExite(ModPOS.BDConexion, "sp_busca_serial", "@DOCClave", DOCClave, "@PROClave", PROClave, "@Serial", Serial, "@TipoDoc", TipoDoc, "@TipoMov", TipoMov) = 0 Then
                    ModPOS.Ejecuta("sp_inserta_serial", "@DOCClave", DOCClave, "@PROClave", PROClave, "@Serial", Serial, "@Dias", Dias, "@TipoDoc", TipoDoc, "@TipoMov", TipoMov, "@Usuario", ModPOS.UsuarioActual)
                    TxtSerial.Text = ""
                    If Regis = Cantidad Then
                        Registrados = Regis
                        Close()
                    Else
                        Regis += 1
                        LblCant.Text = CStr(Regis) & "/" & CStr(Cantidad)
                    End If
                Else
                    MessageBox.Show("¡Numero de Serie Ya registrado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("¡Debe registrar un Numero de Serie!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        End If
    End Sub



    
End Class
