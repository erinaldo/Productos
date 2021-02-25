Public Class FrmEditAbono
    Inherits System.Windows.Forms.Form

    Public ABNClave As String
    Private clave As String
    Private CAJClave As String
    Private Banco As String
    Private Terminal As String
    Private MetodoPago As Integer

    Private bError As Boolean = False

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
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents LblBanco As System.Windows.Forms.Label
    Friend WithEvents CmbBanco As Selling.StoreCombo
    Friend WithEvents lblTerminal As System.Windows.Forms.Label
    Friend WithEvents cmbTerminal As Selling.StoreCombo
    Friend WithEvents LblAbono As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnActualizar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEditAbono))
        Me.GrpGeneral = New System.Windows.Forms.GroupBox()
        Me.BtnActualizar = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.LblBanco = New System.Windows.Forms.Label()
        Me.CmbBanco = New Selling.StoreCombo()
        Me.lblTerminal = New System.Windows.Forms.Label()
        Me.cmbTerminal = New Selling.StoreCombo()
        Me.LblAbono = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GrpGeneral.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpGeneral
        '
        Me.GrpGeneral.Controls.Add(Me.PictureBox2)
        Me.GrpGeneral.Controls.Add(Me.PictureBox1)
        Me.GrpGeneral.Controls.Add(Me.LblAbono)
        Me.GrpGeneral.Controls.Add(Me.lblTerminal)
        Me.GrpGeneral.Controls.Add(Me.cmbTerminal)
        Me.GrpGeneral.Controls.Add(Me.LblBanco)
        Me.GrpGeneral.Controls.Add(Me.CmbBanco)
        Me.GrpGeneral.Location = New System.Drawing.Point(12, 13)
        Me.GrpGeneral.Name = "GrpGeneral"
        Me.GrpGeneral.Size = New System.Drawing.Size(468, 126)
        Me.GrpGeneral.TabIndex = 0
        Me.GrpGeneral.TabStop = False
        Me.GrpGeneral.Text = "Datos"
        '
        'BtnActualizar
        '
        Me.BtnActualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnActualizar.Image = CType(resources.GetObject("BtnActualizar.Image"), System.Drawing.Image)
        Me.BtnActualizar.Location = New System.Drawing.Point(390, 148)
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Size = New System.Drawing.Size(90, 37)
        Me.BtnActualizar.TabIndex = 3
        Me.BtnActualizar.Text = "Ejecutar"
        Me.BtnActualizar.ToolTipText = "Ejecuta procedimiento seleccionado"
        Me.BtnActualizar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnCancelar.Location = New System.Drawing.Point(294, 148)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 4
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblBanco
        '
        Me.LblBanco.AutoSize = True
        Me.LblBanco.Location = New System.Drawing.Point(19, 64)
        Me.LblBanco.Name = "LblBanco"
        Me.LblBanco.Size = New System.Drawing.Size(38, 13)
        Me.LblBanco.TabIndex = 82
        Me.LblBanco.Text = "Banco"
        '
        'CmbBanco
        '
        Me.CmbBanco.BackColor = System.Drawing.SystemColors.Window
        Me.CmbBanco.Location = New System.Drawing.Point(22, 90)
        Me.CmbBanco.Name = "CmbBanco"
        Me.CmbBanco.Size = New System.Drawing.Size(181, 21)
        Me.CmbBanco.TabIndex = 81
        '
        'lblTerminal
        '
        Me.lblTerminal.AutoSize = True
        Me.lblTerminal.Location = New System.Drawing.Point(236, 65)
        Me.lblTerminal.Name = "lblTerminal"
        Me.lblTerminal.Size = New System.Drawing.Size(50, 13)
        Me.lblTerminal.TabIndex = 86
        Me.lblTerminal.Text = "Terminal "
        '
        'cmbTerminal
        '
        Me.cmbTerminal.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTerminal.Location = New System.Drawing.Point(239, 90)
        Me.cmbTerminal.Name = "cmbTerminal"
        Me.cmbTerminal.Size = New System.Drawing.Size(181, 21)
        Me.cmbTerminal.TabIndex = 85
        '
        'LblAbono
        '
        Me.LblAbono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAbono.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblAbono.Location = New System.Drawing.Point(19, 30)
        Me.LblAbono.Name = "LblAbono"
        Me.LblAbono.Size = New System.Drawing.Size(401, 15)
        Me.LblAbono.TabIndex = 87
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(84, 64)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(23, 21)
        Me.PictureBox1.TabIndex = 88
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(292, 65)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(23, 21)
        Me.PictureBox2.TabIndex = 89
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'FrmEditAbono
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(487, 195)
        Me.Controls.Add(Me.BtnActualizar)
        Me.Controls.Add(Me.GrpGeneral)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEditAbono"
        Me.Text = "Modifica Abono"
        Me.GrpGeneral.ResumeLayout(False)
        Me.GrpGeneral.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ActMetodoPago(ByVal metodo As Integer)

        Select Case metodo
            'Case Is = 1
            '    LblBanco.Visible = False
            '    CmbBanco.Visible = False



            '    lblTerminal.Visible = False
            '    cmbTerminal.Visible = False
            '    cmbTerminal.SelectedValue = 0

            Case 2, 3
                LblBanco.Visible = True
                CmbBanco.Visible = True


                lblTerminal.Visible = True
                cmbTerminal.Visible = True
                cmbTerminal.SelectedValue = 0

            Case Is = 4
                LblBanco.Visible = True
                CmbBanco.Visible = True

             

                lblTerminal.Visible = False
                cmbTerminal.Visible = False
                cmbTerminal.SelectedValue = 0
            Case 5, 6
                LblBanco.Visible = True
                CmbBanco.Visible = True

              

                lblTerminal.Visible = False
                cmbTerminal.Visible = False
                cmbTerminal.SelectedValue = 0
                'Case Else
                '    LblBanco.Visible = False
                '    CmbBanco.Visible = False



                '    lblTerminal.Visible = False
                '    cmbTerminal.Visible = False
                '    cmbTerminal.SelectedValue = 0
        End Select


    End Sub


    Private Sub FrmEditAbono_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click
        If Not CmbBanco.SelectedValue Is Nothing Then

            Select Case MetodoPago
                Case 2, 3
                    If cmbTerminal.SelectedValue Is Nothing Then
                        MessageBox.Show("La Terminal No es Valida o es requerida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        bError = True
                        Exit Sub
                    Else
                        Terminal = cmbTerminal.SelectedValue
                    End If
            End Select

            Banco = CmbBanco.SelectedValue

            ModPOS.Ejecuta("st_actualiza_abono", "@ABNClave", ABNClave, "@BNKClave", Banco, "@TERClave", Terminal)

            bError = False
            Me.Close()
        Else
            bError = True
            MessageBox.Show("El banco No es Valido o es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        bError = False
        Me.Close()
    End Sub

    Private Sub FrmEditAbono_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim dt As DataTable

        dt = Recupera_Tabla("st_recupera_abono", "@ABNClave", ABNClave)
        clave = IIf(dt.Rows(0)("Clave").GetType.Name <> "DBNull", dt.Rows(0)("Clave"), "")
        MetodoPago = dt.Rows(0)("TipoPago")
        CAJClave = dt.Rows(0)("CAJClave")
        Banco = IIf(dt.Rows(0)("BNKClave").GetType.Name <> "DBNull", dt.Rows(0)("BNKClave"), "")
        Terminal = IIf(dt.Rows(0)("TERClave").GetType.Name <> "DBNull", dt.Rows(0)("TERClave"), "")
        dt.Dispose()

        LblAbono.Text = "Folio: " & clave

        With CmbBanco
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_bancos"
            .llenar()
        End With
        CmbBanco.SelectedValue = Banco

        If MetodoPago = 2 OrElse MetodoPago = 3 Then
            With cmbTerminal
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "st_filtra_terminal"
                .NombreParametro1 = "CAJClave"
                .Parametro1 = CAJClave
                .llenar()
            End With
            cmbTerminal.SelectedValue = Terminal
        Else
            cmbTerminal.Visible = False
            lblTerminal.Visible = False
        End If


    End Sub
End Class
