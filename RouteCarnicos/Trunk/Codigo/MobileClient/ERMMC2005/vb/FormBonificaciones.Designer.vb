<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormBonificaciones
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents lblMotivo As System.Windows.Forms.Label
    Friend WithEvents LabelProductoClave As System.Windows.Forms.Label
    Friend WithEvents LabelNombreProducto As System.Windows.Forms.Label
    Friend WithEvents ComboBoxMotivo As System.Windows.Forms.ComboBox
    Friend WithEvents PanelPie As System.Windows.Forms.Panel
    Friend WithEvents LabelTotalImporte As System.Windows.Forms.Label
    Friend WithEvents LabelImporte As System.Windows.Forms.Label

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PanelCambioCantidades = New System.Windows.Forms.Panel
        Me.lblUnidad2 = New System.Windows.Forms.Label
        Me.lblUnidad = New System.Windows.Forms.Label
        Me.PanelPie = New System.Windows.Forms.Panel
        Me.LabelTotalImporte = New System.Windows.Forms.Label
        Me.LabelImporte = New System.Windows.Forms.Label
        Me.ComboBoxMotivo = New System.Windows.Forms.ComboBox
        Me.lblMotivo = New System.Windows.Forms.Label
        Me.LabelProductoClave = New System.Windows.Forms.Label
        Me.LabelNombreProducto = New System.Windows.Forms.Label
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.PanelDescuentos = New System.Windows.Forms.Panel
        Me.LabelPorcentaje = New System.Windows.Forms.Label
        Me.LabelSimboloMoneda = New System.Windows.Forms.Label
        Me.lblDescuento = New System.Windows.Forms.Label
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.txtCantidad1 = New MobileClient.Controles.NumericTextBox(Me.components)
        Me.txtCantidad = New MobileClient.Controles.NumericTextBox(Me.components)
        Me.txtDescuentoImp = New MobileClient.Controles.NumericTextBox(Me.components)
        Me.txtDescuentoPor = New MobileClient.Controles.NumericTextBox(Me.components)
        Me.Panel1.SuspendLayout()
        Me.PanelCambioCantidades.SuspendLayout()
        Me.PanelPie.SuspendLayout()
        Me.PanelDescuentos.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PanelCambioCantidades)
        Me.Panel1.Controls.Add(Me.PanelPie)
        Me.Panel1.Controls.Add(Me.ComboBoxMotivo)
        Me.Panel1.Controls.Add(Me.lblMotivo)
        Me.Panel1.Controls.Add(Me.LabelProductoClave)
        Me.Panel1.Controls.Add(Me.LabelNombreProducto)
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.PanelDescuentos)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(244, 328)
        '
        'PanelCambioCantidades
        '
        Me.PanelCambioCantidades.Controls.Add(Me.txtCantidad1)
        Me.PanelCambioCantidades.Controls.Add(Me.lblUnidad2)
        Me.PanelCambioCantidades.Controls.Add(Me.txtCantidad)
        Me.PanelCambioCantidades.Controls.Add(Me.lblUnidad)
        Me.PanelCambioCantidades.Location = New System.Drawing.Point(0, 96)
        Me.PanelCambioCantidades.Name = "PanelCambioCantidades"
        Me.PanelCambioCantidades.Size = New System.Drawing.Size(244, 89)
        '
        'lblUnidad2
        '
        Me.lblUnidad2.Location = New System.Drawing.Point(6, 32)
        Me.lblUnidad2.Name = "lblUnidad2"
        Me.lblUnidad2.Size = New System.Drawing.Size(110, 20)
        Me.lblUnidad2.Text = "LabelUnidad2"
        '
        'lblUnidad
        '
        Me.lblUnidad.Location = New System.Drawing.Point(6, 3)
        Me.lblUnidad.Name = "lblUnidad"
        Me.lblUnidad.Size = New System.Drawing.Size(110, 20)
        Me.lblUnidad.Text = "lblUnidad"
        '
        'PanelPie
        '
        Me.PanelPie.BackColor = System.Drawing.Color.DarkBlue
        Me.PanelPie.Controls.Add(Me.LabelTotalImporte)
        Me.PanelPie.Controls.Add(Me.LabelImporte)
        Me.PanelPie.Location = New System.Drawing.Point(0, 245)
        Me.PanelPie.Name = "PanelPie"
        Me.PanelPie.Size = New System.Drawing.Size(244, 25)
        '
        'LabelTotalImporte
        '
        Me.LabelTotalImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LabelTotalImporte.ForeColor = System.Drawing.Color.GhostWhite
        Me.LabelTotalImporte.Location = New System.Drawing.Point(113, 3)
        Me.LabelTotalImporte.Name = "LabelTotalImporte"
        Me.LabelTotalImporte.Size = New System.Drawing.Size(126, 19)
        Me.LabelTotalImporte.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelImporte
        '
        Me.LabelImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LabelImporte.ForeColor = System.Drawing.Color.GhostWhite
        Me.LabelImporte.Location = New System.Drawing.Point(0, 3)
        Me.LabelImporte.Name = "LabelImporte"
        Me.LabelImporte.Size = New System.Drawing.Size(107, 19)
        Me.LabelImporte.Text = "LabelImporte"
        '
        'ComboBoxMotivo
        '
        Me.ComboBoxMotivo.Location = New System.Drawing.Point(73, 50)
        Me.ComboBoxMotivo.Name = "ComboBoxMotivo"
        Me.ComboBoxMotivo.Size = New System.Drawing.Size(166, 23)
        Me.ComboBoxMotivo.TabIndex = 12
        '
        'lblMotivo
        '
        Me.lblMotivo.Location = New System.Drawing.Point(1, 53)
        Me.lblMotivo.Name = "lblMotivo"
        Me.lblMotivo.Size = New System.Drawing.Size(74, 20)
        Me.lblMotivo.Text = "LabelMotivo"
        '
        'LabelProductoClave
        '
        Me.LabelProductoClave.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelProductoClave.ForeColor = System.Drawing.Color.MediumBlue
        Me.LabelProductoClave.Location = New System.Drawing.Point(0, 1)
        Me.LabelProductoClave.Name = "LabelProductoClave"
        Me.LabelProductoClave.Size = New System.Drawing.Size(239, 18)
        Me.LabelProductoClave.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelNombreProducto
        '
        Me.LabelNombreProducto.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelNombreProducto.ForeColor = System.Drawing.Color.MediumBlue
        Me.LabelNombreProducto.Location = New System.Drawing.Point(1, 22)
        Me.LabelNombreProducto.Name = "LabelNombreProducto"
        Me.LabelNombreProducto.Size = New System.Drawing.Size(239, 18)
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(7, 268)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuar.TabIndex = 5
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(88, 268)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresar.TabIndex = 6
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'PanelDescuentos
        '
        Me.PanelDescuentos.Controls.Add(Me.LabelPorcentaje)
        Me.PanelDescuentos.Controls.Add(Me.txtDescuentoImp)
        Me.PanelDescuentos.Controls.Add(Me.LabelSimboloMoneda)
        Me.PanelDescuentos.Controls.Add(Me.txtDescuentoPor)
        Me.PanelDescuentos.Controls.Add(Me.lblDescuento)
        Me.PanelDescuentos.Location = New System.Drawing.Point(0, 96)
        Me.PanelDescuentos.Name = "PanelDescuentos"
        Me.PanelDescuentos.Size = New System.Drawing.Size(244, 89)
        '
        'LabelPorcentaje
        '
        Me.LabelPorcentaje.Location = New System.Drawing.Point(110, 3)
        Me.LabelPorcentaje.Name = "LabelPorcentaje"
        Me.LabelPorcentaje.Size = New System.Drawing.Size(28, 20)
        Me.LabelPorcentaje.Text = "%"
        Me.LabelPorcentaje.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelSimboloMoneda
        '
        Me.LabelSimboloMoneda.Location = New System.Drawing.Point(110, 33)
        Me.LabelSimboloMoneda.Name = "LabelSimboloMoneda"
        Me.LabelSimboloMoneda.Size = New System.Drawing.Size(28, 20)
        Me.LabelSimboloMoneda.Text = "LabelSimboloMoneda"
        Me.LabelSimboloMoneda.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDescuento
        '
        Me.lblDescuento.Location = New System.Drawing.Point(6, 3)
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Size = New System.Drawing.Size(88, 20)
        Me.lblDescuento.Text = "LabelDescuento"
        '
        'txtCantidad1
        '
        Me.txtCantidad1.Location = New System.Drawing.Point(139, 30)
        Me.txtCantidad1.Name = "txtCantidad1"
        Me.txtCantidad1.Size = New System.Drawing.Size(99, 23)
        Me.txtCantidad1.TabIndex = 22
        Me.txtCantidad1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(139, 2)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(99, 23)
        Me.txtCantidad.TabIndex = 21
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescuentoImp
        '
        Me.txtDescuentoImp.Location = New System.Drawing.Point(139, 30)
        Me.txtDescuentoImp.Name = "txtDescuentoImp"
        Me.txtDescuentoImp.Size = New System.Drawing.Size(99, 23)
        Me.txtDescuentoImp.TabIndex = 26
        '
        'txtDescuentoPor
        '
        Me.txtDescuentoPor.Location = New System.Drawing.Point(139, 2)
        Me.txtDescuentoPor.Name = "txtDescuentoPor"
        Me.txtDescuentoPor.Size = New System.Drawing.Size(99, 23)
        Me.txtDescuentoPor.TabIndex = 25
        '
        'FormBonificaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(244, 328)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Name = "FormBonificaciones"
        Me.Text = "FormBonificaciones"
        Me.Panel1.ResumeLayout(False)
        Me.PanelCambioCantidades.ResumeLayout(False)
        Me.PanelPie.ResumeLayout(False)
        Me.PanelDescuentos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelDescuentos As System.Windows.Forms.Panel
    Friend WithEvents txtDescuentoImp As MobileClient.Controles.NumericTextBox
    Friend WithEvents LabelSimboloMoneda As System.Windows.Forms.Label
    Friend WithEvents txtDescuentoPor As MobileClient.Controles.NumericTextBox
    Friend WithEvents lblDescuento As System.Windows.Forms.Label
    Friend WithEvents PanelCambioCantidades As System.Windows.Forms.Panel
    Friend WithEvents txtCantidad1 As MobileClient.Controles.NumericTextBox
    Friend WithEvents lblUnidad2 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As MobileClient.Controles.NumericTextBox
    Friend WithEvents lblUnidad As System.Windows.Forms.Label
    Friend WithEvents LabelPorcentaje As System.Windows.Forms.Label
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

End Class
