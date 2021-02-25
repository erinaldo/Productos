Public Class FrmInterfaz
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents BtnActualizar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInterfaz))
        Me.GrpGeneral = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.BtnActualizar = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.GrpGeneral.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpGeneral
        '
        Me.GrpGeneral.Controls.Add(Me.Label2)
        Me.GrpGeneral.Controls.Add(Me.txtSerie)
        Me.GrpGeneral.Controls.Add(Me.Label1)
        Me.GrpGeneral.Controls.Add(Me.Label11)
        Me.GrpGeneral.Controls.Add(Me.txtFolio)
        Me.GrpGeneral.Controls.Add(Me.cmbTipo)
        Me.GrpGeneral.Location = New System.Drawing.Point(12, 13)
        Me.GrpGeneral.Name = "GrpGeneral"
        Me.GrpGeneral.Size = New System.Drawing.Size(477, 84)
        Me.GrpGeneral.TabIndex = 0
        Me.GrpGeneral.TabStop = False
        Me.GrpGeneral.Text = "Selección de Interfaz"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(158, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 16)
        Me.Label2.TabIndex = 152
        Me.Label2.Text = "Serie"
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(161, 46)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(124, 20)
        Me.txtSerie.TabIndex = 151
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 16)
        Me.Label1.TabIndex = 150
        Me.Label1.Text = "Tipo"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(288, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 16)
        Me.Label11.TabIndex = 149
        Me.Label11.Text = "Folio"
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(291, 46)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(180, 20)
        Me.txtFolio.TabIndex = 148
        '
        'cmbTipo
        '
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Items.AddRange(New Object() {"Traslado ", "Compra", "Dev. Compra", "Recibo de Traslado", "Nota de Cargo", "Dev. Factura", "Transferencia a Bancos", "Factura", "Cobros", "Bonificación", "Pedido", "Cancelación Factura"})
        Me.cmbTipo.Location = New System.Drawing.Point(6, 45)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(149, 21)
        Me.cmbTipo.TabIndex = 147
        '
        'BtnActualizar
        '
        Me.BtnActualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnActualizar.Image = CType(resources.GetObject("BtnActualizar.Image"), System.Drawing.Image)
        Me.BtnActualizar.Location = New System.Drawing.Point(400, 103)
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
        Me.BtnCancelar.Location = New System.Drawing.Point(304, 103)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 4
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmInterfaz
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(497, 150)
        Me.Controls.Add(Me.BtnActualizar)
        Me.Controls.Add(Me.GrpGeneral)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInterfaz"
        Me.Text = "Ejecutar Interfaz"
        Me.GrpGeneral.ResumeLayout(False)
        Me.GrpGeneral.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmInterfaz_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click
        If Not Me.cmbTipo.SelectedItem Is Nothing AndAlso txtFolio.Text <> "" Then
            Dim bErr As Boolean = False
            Select Case CStr(cmbTipo.SelectedItem)
                Case Is = "Traslado "
                    ModPOS.Ejecuta("stpr_GeneracionInterfaces", "@Procedimiento", 1, "@TipoDocumento", 1, "@Folio", txtFolio.Text.Trim)
                    bErr = False
                Case Is = "Compra"
                    ModPOS.Ejecuta("stpr_GeneracionInterfaces", "@Procedimiento", 2, "@TipoDocumento", 2, "@Folio", txtFolio.Text.Trim)
                    bErr = False
                Case Is = "Dev. Compra"
                    ModPOS.Ejecuta("stpr_GeneracionInterfaces", "@Procedimiento", 2, "@TipoDocumento", 10, "@Folio", txtFolio.Text.Trim)
                    bErr = False
                Case Is = "Recibo de Traslado"
                    ModPOS.Ejecuta("stpr_GeneracionInterfaces", "@Procedimiento", 2, "@TipoDocumento", 8, "@Folio", txtFolio.Text.Trim)
                    bErr = False
                Case Is = "Nota de Cargo"
                    If txtSerie.Text = "" Then
                        MessageBox.Show("La Serie es requerida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        bErr = True
                    Else
                        ModPOS.Ejecuta("stpr_GeneracionInterfaces", "@Procedimiento", 3, "@TipoDocumento", 1, "@Folio", txtFolio.Text.Trim, "@Serie", txtSerie.Text.Trim.ToUpper)
                        bErr = False
                    End If
                Case Is = "Dev. Factura"
                    If txtSerie.Text = "" Then
                        MessageBox.Show("La Serie es requerida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        bErr = True
                    Else
                        ModPOS.Ejecuta("stpr_GeneracionInterfaces", "@Procedimiento", 4, "@TipoDocumento", 3, "@Folio", txtFolio.Text.Trim, "@Serie", txtSerie.Text.Trim.ToUpper)
                        bErr = False
                    End If
                Case Is = "Bonificación"
                    If txtSerie.Text = "" Then
                        MessageBox.Show("La Serie es requerida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        bErr = True
                    Else
                        ModPOS.Ejecuta("stpr_GeneracionInterfaces", "@Procedimiento", 4, "@TipoDocumento", 3, "@Folio", txtFolio.Text.Trim, "@Serie", txtSerie.Text.Trim.ToUpper)
                        bErr = False
                    End If
                Case Is = "Transferencia a Bancos"
                    ModPOS.Ejecuta("stpr_GeneracionInterfaces", "@Procedimiento", 5, "@TipoDocumento", 0, "@Folio", txtFolio.Text.Trim)
                    bErr = False
                Case Is = "Factura"
                    If txtSerie.Text = "" Then
                        MessageBox.Show("La Serie es requerida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        bErr = True
                    Else
                        ModPOS.Ejecuta("stpr_GeneracionInterfaces", "@Procedimiento", 9, "@TipoDocumento", 1, "@Folio", txtFolio.Text.Trim, "@Serie", txtSerie.Text.Trim.ToUpper)
                        bErr = False
                    End If
                Case Is = "Cobros"
                    ModPOS.Ejecuta("stpr_GeneracionInterfaces", "@Procedimiento", 8, "@TipoDocumento", 0, "@Folio", txtFolio.Text.Trim)
                    bErr = False

                Case Is = "Pedido"
                    ModPOS.Ejecuta("stpr_GeneracionInterfaces", "@Procedimiento", 7, "@TipoDocumento", 0, "@Folio", txtFolio.Text.Trim)
                    bErr = False

                Case Is = "Cancelación Factura"
                    If txtSerie.Text = "" Then
                        MessageBox.Show("La Serie es requerida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        bErr = True
                    Else
                        ModPOS.Ejecuta("stpr_GeneracionInterfaces", "@Procedimiento", 6, "@TipoDocumento", 0, "@Folio", txtFolio.Text.Trim, "@Serie", txtSerie.Text.Trim.ToUpper)
                        bErr = False
                    End If
            End Select
            If bErr = False Then
                MessageBox.Show("Procedimiento Ejecutado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtFolio.Text = ""
            End If
        Else

            MessageBox.Show("Alguno de los datos No es Valido o es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        bError = True
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        bError = False
        Me.Close()
    End Sub



    Private Sub cmbTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipo.SelectedIndexChanged
        If Not Me.cmbTipo.SelectedItem Is Nothing Then
            Select Case CStr(cmbTipo.SelectedItem)
                Case Is = "Nota de Cargo"
                    txtSerie.Enabled = True

                Case Is = "Dev. Factura"
                    txtSerie.Enabled = True
                Case Is = "Bonificación"
                    txtSerie.Enabled = True
                Case Is = "Factura"
                    txtSerie.Enabled = True
                Case Is = "Cancelación Factura"
                    txtSerie.Enabled = True
                Case Else
                    txtSerie.Text = ""
                    txtSerie.Enabled = False
            End Select
        End If
    End Sub


End Class
