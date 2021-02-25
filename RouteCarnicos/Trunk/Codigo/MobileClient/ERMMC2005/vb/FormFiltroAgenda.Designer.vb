<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormFiltroAgenda
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
        Me.CheckBoxCanjes = New System.Windows.Forms.CheckBox
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.DateTimeFechaFin = New System.Windows.Forms.DateTimePicker
        Me.DateTimeFechaInicio = New System.Windows.Forms.DateTimePicker
        Me.LabelFechaInicio = New System.Windows.Forms.Label
        Me.LabelFechaFin = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CheckBoxCanjes)
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
        Me.Panel1.Controls.Add(Me.DateTimeFechaFin)
        Me.Panel1.Controls.Add(Me.DateTimeFechaInicio)
        Me.Panel1.Controls.Add(Me.LabelFechaInicio)
        Me.Panel1.Controls.Add(Me.LabelFechaFin)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'CheckBoxCanjes
        '
        Me.CheckBoxCanjes.Location = New System.Drawing.Point(20, 140)
        Me.CheckBoxCanjes.Name = "CheckBoxCanjes"
        Me.CheckBoxCanjes.Size = New System.Drawing.Size(200, 20)
        Me.CheckBoxCanjes.TabIndex = 17
        Me.CheckBoxCanjes.Text = "CheckBoxCanjes"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(20, 217)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuar.TabIndex = 15
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'DateTimeFechaFin
        '
        Me.DateTimeFechaFin.CustomFormat = "dd/MM/yyyy"
        Me.DateTimeFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimeFechaFin.Location = New System.Drawing.Point(20, 99)
        Me.DateTimeFechaFin.Name = "DateTimeFechaFin"
        Me.DateTimeFechaFin.Size = New System.Drawing.Size(200, 22)
        Me.DateTimeFechaFin.TabIndex = 14
        Me.DateTimeFechaFin.Value = New Date(2006, 9, 7, 0, 0, 0, 0)
        '
        'DateTimeFechaInicio
        '
        Me.DateTimeFechaInicio.CustomFormat = "dd/MM/yyyy"
        Me.DateTimeFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimeFechaInicio.Location = New System.Drawing.Point(20, 51)
        Me.DateTimeFechaInicio.Name = "DateTimeFechaInicio"
        Me.DateTimeFechaInicio.Size = New System.Drawing.Size(200, 22)
        Me.DateTimeFechaInicio.TabIndex = 13
        Me.DateTimeFechaInicio.Value = New Date(2006, 9, 7, 0, 0, 0, 0)
        '
        'LabelFechaInicio
        '
        Me.LabelFechaInicio.Location = New System.Drawing.Point(20, 32)
        Me.LabelFechaInicio.Name = "LabelFechaInicio"
        Me.LabelFechaInicio.Size = New System.Drawing.Size(100, 20)
        Me.LabelFechaInicio.Text = "LabelFechaInicio"
        '
        'LabelFechaFin
        '
        Me.LabelFechaFin.Location = New System.Drawing.Point(20, 82)
        Me.LabelFechaFin.Name = "LabelFechaFin"
        Me.LabelFechaFin.Size = New System.Drawing.Size(100, 20)
        Me.LabelFechaFin.Text = "LabelFechaFin"
        '
        'FormFiltroAgenda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.mainMenu1
        Me.Name = "FormFiltroAgenda"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Public Sub New(ByVal parbNuevo As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'blnNuevo = parbNuevo
    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CheckBoxCanjes As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents DateTimeFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimeFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelFechaInicio As System.Windows.Forms.Label
    Friend WithEvents LabelFechaFin As System.Windows.Forms.Label
End Class
