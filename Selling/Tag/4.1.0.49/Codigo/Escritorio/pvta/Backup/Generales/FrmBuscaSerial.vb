Public Class FrmBuscaSerial
    Inherits System.Windows.Forms.Form

  

    Private Serial As String
  
    Friend WithEvents TxtSerial As System.Windows.Forms.TextBox
    Friend WithEvents LblCant As System.Windows.Forms.Label
    Friend WithEvents GrpSerial As System.Windows.Forms.GroupBox
    Friend WithEvents GridSeriales As Janus.Windows.GridEX.GridEX
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBuscaSerial))
        Me.TxtSerial = New System.Windows.Forms.TextBox
        Me.LblCant = New System.Windows.Forms.Label
        Me.GrpSerial = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GridSeriales = New Janus.Windows.GridEX.GridEX
        Me.GrpSerial.SuspendLayout()
        CType(Me.GridSeriales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtSerial
        '
        Me.TxtSerial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSerial.Location = New System.Drawing.Point(89, 19)
        Me.TxtSerial.Name = "TxtSerial"
        Me.TxtSerial.Size = New System.Drawing.Size(357, 20)
        Me.TxtSerial.TabIndex = 74
        '
        'LblCant
        '
        Me.LblCant.BackColor = System.Drawing.Color.Transparent
        Me.LblCant.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCant.ForeColor = System.Drawing.Color.Blue
        Me.LblCant.Location = New System.Drawing.Point(12, 19)
        Me.LblCant.Name = "LblCant"
        Me.LblCant.Size = New System.Drawing.Size(67, 23)
        Me.LblCant.TabIndex = 78
        Me.LblCant.Text = "CLAVE:"
        Me.LblCant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GrpSerial
        '
        Me.GrpSerial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpSerial.Controls.Add(Me.Label1)
        Me.GrpSerial.Controls.Add(Me.TxtSerial)
        Me.GrpSerial.Controls.Add(Me.LblCant)
        Me.GrpSerial.Location = New System.Drawing.Point(2, 4)
        Me.GrpSerial.MinimumSize = New System.Drawing.Size(448, 78)
        Me.GrpSerial.Name = "GrpSerial"
        Me.GrpSerial.Size = New System.Drawing.Size(524, 78)
        Me.GrpSerial.TabIndex = 79
        Me.GrpSerial.TabStop = False
        Me.GrpSerial.Text = "Serial"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(338, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 13)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "Presione ENTER- Buscar"
        '
        'GridSeriales
        '
        Me.GridSeriales.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridSeriales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridSeriales.ColumnAutoResize = True
        Me.GridSeriales.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridSeriales.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridSeriales.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridSeriales.Location = New System.Drawing.Point(2, 84)
        Me.GridSeriales.Name = "GridSeriales"
        Me.GridSeriales.RecordNavigator = True
        Me.GridSeriales.Size = New System.Drawing.Size(451, 233)
        Me.GridSeriales.TabIndex = 80
        Me.GridSeriales.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmBuscaSerial
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(456, 319)
        Me.Controls.Add(Me.GridSeriales)
        Me.Controls.Add(Me.GrpSerial)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(385, 319)
        Me.Name = "FrmBuscaSerial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VERIFICADOR DE GARANTIA"
        Me.GrpSerial.ResumeLayout(False)
        Me.GrpSerial.PerformLayout()
        CType(Me.GridSeriales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub



    Private Sub Serial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub TxtSerial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSerial.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If TxtSerial.Text <> "" Then
                Serial = TxtSerial.Text.ToUpper.Trim.Replace("'", "''")
                ModPOS.ActualizaGrid(False, Me.GridSeriales, "sp_verifica_garantia", "@Serial", Serial)

                Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
                fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridSeriales.RootTable.Columns("Garantia"), Janus.Windows.GridEX.ConditionOperator.Equal, "Expirada")
                fc.FormatStyle.ForeColor = System.Drawing.Color.Red
                GridSeriales.RootTable.FormatConditions.Add(fc)

                If Me.GridSeriales.RowCount = 0 Then
                    MessageBox.Show("¡No fueron encontrados registros que coincidan con el Numero de Serie!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

            End If
        End If
    End Sub





End Class
