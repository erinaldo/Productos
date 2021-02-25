<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormPedirFechaActual
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.mainMenu1 Is Nothing Then Me.mainMenu1.Dispose()
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Private mainMenu1 As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker
        Me.dtpHora = New System.Windows.Forms.DateTimePicker
        Me.LabelMensaje = New System.Windows.Forms.Label
        Me.mcFechaActual = New System.Windows.Forms.MonthCalendar
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtpFecha)
        Me.Panel1.Controls.Add(Me.dtpHora)
        Me.Panel1.Controls.Add(Me.LabelMensaje)
        Me.Panel1.Controls.Add(Me.mcFechaActual)
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'dtpFecha
        '
        Me.dtpFecha.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpFecha.CalendarFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.Location = New System.Drawing.Point(20, 29)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.ShowUpDown = True
        Me.dtpFecha.Size = New System.Drawing.Size(199, 24)
        Me.dtpFecha.TabIndex = 21
        '
        'dtpHora
        '
        Me.dtpHora.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.dtpHora.CalendarFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.dtpHora.CustomFormat = ""
        Me.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpHora.Location = New System.Drawing.Point(20, 222)
        Me.dtpHora.Name = "dtpHora"
        Me.dtpHora.ShowUpDown = True
        Me.dtpHora.Size = New System.Drawing.Size(199, 24)
        Me.dtpHora.TabIndex = 19
        '
        'LabelMensaje
        '
        Me.LabelMensaje.Location = New System.Drawing.Point(20, 6)
        Me.LabelMensaje.Name = "LabelMensaje"
        Me.LabelMensaje.Size = New System.Drawing.Size(199, 20)
        Me.LabelMensaje.Text = "LabelMensaje"
        '
        'mcFechaActual
        '
        Me.mcFechaActual.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mcFechaActual.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.mcFechaActual.Location = New System.Drawing.Point(23, 56)
        Me.mcFechaActual.Name = "mcFechaActual"
        Me.mcFechaActual.ShowToday = False
        Me.mcFechaActual.Size = New System.Drawing.Size(192, 165)
        Me.mcFechaActual.TabIndex = 17
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(20, 256)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuar.TabIndex = 15
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(2, 214)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(239, 8)
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'FormPedirFechaActual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.mainMenu1
        Me.MinimizeBox = False
        Me.Name = "FormPedirFechaActual"
        Me.Text = "FormPedirFechaActual"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents mcFechaActual As System.Windows.Forms.MonthCalendar
    Friend WithEvents dtpHora As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelMensaje As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
