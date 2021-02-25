Public Class FrmPaquete
    Inherits System.Windows.Forms.Form

    Public Nota, Guia, TipoPaquete As String
    Public numCopias As Integer = 1
    Public lineas As Integer = 0

    Private bError As Boolean = False
    Private Registrados As Integer = 0
    Private olineas As Integer = 0

    Friend WithEvents TxtNota As System.Windows.Forms.TextBox
    Friend WithEvents GrpNota As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblPaquete As System.Windows.Forms.Label
    Friend WithEvents txtPaquete As System.Windows.Forms.TextBox
    Friend WithEvents cmbTipoPaq As Selling.StoreCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumPaq As Janus.Windows.GridEX.EditControls.NumericEditBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPaquete))
        Me.TxtNota = New System.Windows.Forms.TextBox()
        Me.GrpNota = New System.Windows.Forms.GroupBox()
        Me.BtnOK = New Janus.Windows.EditControls.UIButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblCant = New System.Windows.Forms.Label()
        Me.lblPaquete = New System.Windows.Forms.Label()
        Me.txtPaquete = New System.Windows.Forms.TextBox()
        Me.cmbTipoPaq = New Selling.StoreCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumPaq = New Janus.Windows.GridEX.EditControls.NumericEditBox()
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
        Me.TxtNota.TabIndex = 4
        '
        'GrpNota
        '
        Me.GrpNota.Controls.Add(Me.BtnOK)
        Me.GrpNota.Controls.Add(Me.Label4)
        Me.GrpNota.Controls.Add(Me.TxtNota)
        Me.GrpNota.Controls.Add(Me.LblCant)
        Me.GrpNota.Location = New System.Drawing.Point(0, 115)
        Me.GrpNota.Name = "GrpNota"
        Me.GrpNota.Size = New System.Drawing.Size(366, 186)
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
        Me.BtnOK.Location = New System.Drawing.Point(269, 144)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(90, 37)
        Me.BtnOK.TabIndex = 5
        Me.BtnOK.Text = "Aceptar"
        Me.BtnOK.ToolTipText = "Autorizar transacción"
        Me.BtnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(2, 137)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(145, 17)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "CARACTERES:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblCant
        '
        Me.LblCant.BackColor = System.Drawing.Color.Transparent
        Me.LblCant.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.LblCant.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblCant.Location = New System.Drawing.Point(153, 137)
        Me.LblCant.Name = "LblCant"
        Me.LblCant.Size = New System.Drawing.Size(98, 17)
        Me.LblCant.TabIndex = 78
        Me.LblCant.Text = "NUM. SERIE:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.LblCant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPaquete
        '
        Me.lblPaquete.Location = New System.Drawing.Point(3, 77)
        Me.lblPaquete.Name = "lblPaquete"
        Me.lblPaquete.Size = New System.Drawing.Size(74, 16)
        Me.lblPaquete.TabIndex = 137
        Me.lblPaquete.Text = "No. Guia"
        '
        'txtPaquete
        '
        Me.txtPaquete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPaquete.Location = New System.Drawing.Point(104, 74)
        Me.txtPaquete.Name = "txtPaquete"
        Me.txtPaquete.Size = New System.Drawing.Size(253, 21)
        Me.txtPaquete.TabIndex = 3
        '
        'cmbTipoPaq
        '
        Me.cmbTipoPaq.Location = New System.Drawing.Point(104, 12)
        Me.cmbTipoPaq.Name = "cmbTipoPaq"
        Me.cmbTipoPaq.Size = New System.Drawing.Size(253, 21)
        Me.cmbTipoPaq.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 16)
        Me.Label1.TabIndex = 163
        Me.Label1.Text = "Tipo Empaque"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 16)
        Me.Label2.TabIndex = 164
        Me.Label2.Text = "No. Copias"
        '
        'txtNumPaq
        '
        Me.txtNumPaq.Location = New System.Drawing.Point(104, 44)
        Me.txtNumPaq.Name = "txtNumPaq"
        Me.txtNumPaq.Size = New System.Drawing.Size(80, 20)
        Me.txtNumPaq.TabIndex = 2
        Me.txtNumPaq.Text = "1"
        Me.txtNumPaq.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtNumPaq.Value = 1
        Me.txtNumPaq.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'FrmPaquete
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(369, 304)
        Me.Controls.Add(Me.txtNumPaq)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbTipoPaq)
        Me.Controls.Add(Me.lblPaquete)
        Me.Controls.Add(Me.txtPaquete)
        Me.Controls.Add(Me.GrpNota)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPaquete"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Paquete"
        Me.GrpNota.ResumeLayout(False)
        Me.GrpNota.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub FrmPaquete_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmPaquete_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen
        TxtNota.Text = Nota

        olineas = lineas
        LblCant.Text = CStr(TxtNota.Text.Length) & "/" & "500"
        TxtNota.Select(TxtNota.TextLength, 0)


        With cmbTipoPaq
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Paquete"
            .NombreParametro2 = "campo"
            .Parametro2 = "TipoPaquete"
            .llenar()
        End With

    End Sub

    Private Sub TxtSerial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNota.KeyPress

        If Asc(e.KeyChar) = 13 Then
            olineas += 1
            If olineas >= 5 Then
                MessageBox.Show("Solo seran visibles en la factura las primeras 5 lineas", "Advertencia", MessageBoxButtons.OK)
            End If
        ElseIf Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub TxtNota_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNota.KeyUp
        If TxtNota.Text.Length > 500 Then
            TxtNota.Text = TxtNota.Text.Substring(0, 500)
            TxtNota.Select(TxtNota.TextLength, 0)
        End If
        LblCant.Text = CStr(TxtNota.Text.Length) & "/" & "500"
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click

        'valida si el numero de copias es valido
        If txtNumPaq.Text = vbNullString OrElse CInt(txtNumPaq.Text) = 0 Then
            MessageBox.Show("El numero de copias a imprimir no es valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            bError = True
            Exit Sub
        End If

        'valida que este seleccionado el tipo de paquete
        If cmbTipoPaq.SelectedValue Is Nothing Then
            MessageBox.Show("Debe seleccionar un tipo de paquete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            bError = True
            Exit Sub
        End If

      
        bError = False

        Guia = txtPaquete.Text.ToUpper
        Nota = TxtNota.Text
        numCopias = CInt(txtNumPaq.Text)
        TipoPaquete = cmbTipoPaq.SelectedValue
        lineas = olineas
        Me.Close()
    End Sub
End Class
