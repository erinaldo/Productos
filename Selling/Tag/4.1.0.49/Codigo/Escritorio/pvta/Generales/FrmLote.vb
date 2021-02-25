Public Class FrmLote
    Inherits System.Windows.Forms.Form

    Public DOCClave As String
    Public TipoDoc As Integer
    Public TipoMov As Integer
    Public PROClave As String
    Public CantXRegistrar As Double
    Public Clave As String
    Public Nombre As String
    '1: Venta 2:Devolucion

    Private Lote As String
    Private Cantidad As Double
    Private Registrados As Double = 0
    
    Friend WithEvents TxtLote As System.Windows.Forms.TextBox
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblCant As System.Windows.Forms.Label
    Friend WithEvents GrpSerial As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblCantidad As System.Windows.Forms.Label
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLote))
        Me.TxtLote = New System.Windows.Forms.TextBox
        Me.LblClave = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblNombre = New System.Windows.Forms.Label
        Me.LblCant = New System.Windows.Forms.Label
        Me.GrpSerial = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.LblCantidad = New System.Windows.Forms.Label
        Me.GrpSerial.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtLote
        '
        Me.TxtLote.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtLote.Location = New System.Drawing.Point(69, 19)
        Me.TxtLote.Name = "TxtLote"
        Me.TxtLote.Size = New System.Drawing.Size(280, 20)
        Me.TxtLote.TabIndex = 74
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
        Me.LblClave.Size = New System.Drawing.Size(362, 24)
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
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(452, 38)
        Me.LblNombre.TabIndex = 75
        Me.LblNombre.Text = "PRODUCTO:"
        '
        'LblCant
        '
        Me.LblCant.BackColor = System.Drawing.Color.Transparent
        Me.LblCant.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCant.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblCant.Location = New System.Drawing.Point(-5, 44)
        Me.LblCant.Name = "LblCant"
        Me.LblCant.Size = New System.Drawing.Size(67, 23)
        Me.LblCant.TabIndex = 78
        Me.LblCant.Text = "CANT:"
        Me.LblCant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GrpSerial
        '
        Me.GrpSerial.Controls.Add(Me.Label1)
        Me.GrpSerial.Controls.Add(Me.TxtCantidad)
        Me.GrpSerial.Controls.Add(Me.Label3)
        Me.GrpSerial.Controls.Add(Me.TxtLote)
        Me.GrpSerial.Controls.Add(Me.LblCant)
        Me.GrpSerial.Location = New System.Drawing.Point(2, 107)
        Me.GrpSerial.MaximumSize = New System.Drawing.Size(448, 78)
        Me.GrpSerial.MinimumSize = New System.Drawing.Size(448, 78)
        Me.GrpSerial.Name = "GrpSerial"
        Me.GrpSerial.Size = New System.Drawing.Size(448, 78)
        Me.GrpSerial.TabIndex = 79
        Me.GrpSerial.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(225, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 13)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "Presione ENTER- Guardar"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCantidad.Location = New System.Drawing.Point(69, 47)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(55, 20)
        Me.TxtCantidad.TabIndex = 80
        Me.TxtCantidad.Text = "0.00"
        Me.TxtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCantidad.Value = 0
        Me.TxtCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(-5, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 23)
        Me.Label3.TabIndex = 79
        Me.Label3.Text = "LOTE:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(-3, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(208, 24)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "CANTIDAD POR REGISTRAR:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblCantidad
        '
        Me.LblCantidad.BackColor = System.Drawing.Color.Transparent
        Me.LblCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCantidad.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblCantidad.Location = New System.Drawing.Point(210, 86)
        Me.LblCantidad.Name = "LblCantidad"
        Me.LblCantidad.Size = New System.Drawing.Size(165, 24)
        Me.LblCantidad.TabIndex = 82
        Me.LblCantidad.Text = "CANT:"
        Me.LblCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmLote
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(461, 194)
        Me.Controls.Add(Me.LblCantidad)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GrpSerial)
        Me.Controls.Add(Me.LblClave)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblNombre)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(385, 209)
        Me.Name = "FrmLote"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GrpSerial.ResumeLayout(False)
        Me.GrpSerial.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub



    Private Sub FrmLote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen
        LblClave.Text = Clave
        LblNombre.Text = Nombre
        LblCantidad.Text = CStr(Registrados) & "/" & CStr(CantXRegistrar)
    End Sub

    Private Sub TxtSerial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLote.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TxtCantidad.Focus()
        End If
    End Sub

    Private Sub TxtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantidad.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If TxtLote.Text <> "" AndAlso CDbl(TxtCantidad.Text) > 0 AndAlso (CDbl(TxtCantidad.Text) + Registrados) <= CantXRegistrar Then
                Lote = TxtLote.Text.ToUpper.Trim
                Cantidad = CDbl(TxtCantidad.Text)

                If ModPOS.SiExite(ModPOS.BDConexion, "sp_busca_lote", "@DOCClave", DOCClave, "TipoDoc", TipoDoc, "@PROClave", PROClave, "TipoMov", TipoMov, "@Lote", Lote) = 0 Then
                    ModPOS.Ejecuta("sp_inserta_lote", "@DOCClave", DOCClave, "TipoDoc", TipoDoc, "@PROClave", PROClave, "TipoMov", TipoMov, "@Lote", Lote, "@Cantidad", 1, "@Usuario", ModPOS.UsuarioActual)
                Else
                    ModPOS.Ejecuta("sp_actualiza_lote", "@DOCClave", DOCClave, "TipoDoc", TipoDoc, "@PROClave", PROClave, "TipoMov", TipoMov, "@Lote", Lote, "@Cantidad", 1, "@Usuario", ModPOS.UsuarioActual)
                End If

                TxtLote.Text = ""
                TxtLote.Focus()

                Registrados += Cantidad
                LblCantidad.Text = CStr(Registrados) & "/" & CStr(CantXRegistrar)
                Cantidad = 0

                If Registrados = CantXRegistrar Then
                    Close()
                End If

            Else
                MessageBox.Show("¡Verifique el Lote y Cantidad que desea registrar!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        End If
    End Sub
End Class
