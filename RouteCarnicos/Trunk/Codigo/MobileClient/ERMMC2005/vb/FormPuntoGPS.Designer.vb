<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormPuntoGPS
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
#If SO_WCE = 0 Then
        If Not IsNothing(Me.oGPS) Then oGPS = Nothing
#End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPuntoGPS))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.LabelTitulo = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.LabelEstado = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.TextBoxLongitud = New System.Windows.Forms.TextBox
        Me.LabelStatus = New System.Windows.Forms.Label
        Me.LabelSatelites = New System.Windows.Forms.Label
        Me.LabelLongitud = New System.Windows.Forms.Label
        Me.LabelLatitud = New System.Windows.Forms.Label
        Me.LabelFechaHora = New System.Windows.Forms.Label
        Me.TextBoxLatitud = New System.Windows.Forms.TextBox
        Me.TimerGPS = New System.Windows.Forms.Timer
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Panel3)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel2.Controls.Add(Me.LabelTitulo)
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.Name = "Panel2"
        '
        'LabelTitulo
        '
        resources.ApplyResources(Me.LabelTitulo, "LabelTitulo")
        Me.LabelTitulo.BackColor = System.Drawing.Color.SteelBlue
        Me.LabelTitulo.ForeColor = System.Drawing.Color.White
        Me.LabelTitulo.Name = "LabelTitulo"
        '
        'Panel3
        '
        resources.ApplyResources(Me.Panel3, "Panel3")
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.Panel6)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.TextBoxLongitud)
        Me.Panel3.Controls.Add(Me.LabelStatus)
        Me.Panel3.Controls.Add(Me.LabelSatelites)
        Me.Panel3.Controls.Add(Me.LabelLongitud)
        Me.Panel3.Controls.Add(Me.LabelLatitud)
        Me.Panel3.Controls.Add(Me.LabelFechaHora)
        Me.Panel3.Controls.Add(Me.TextBoxLatitud)
        Me.Panel3.Name = "Panel3"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel6.Controls.Add(Me.LabelEstado)
        resources.ApplyResources(Me.Panel6, "Panel6")
        Me.Panel6.Name = "Panel6"
        '
        'LabelEstado
        '
        Me.LabelEstado.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.LabelEstado, "LabelEstado")
        Me.LabelEstado.ForeColor = System.Drawing.Color.White
        Me.LabelEstado.Name = "LabelEstado"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.Panel4, "Panel4")
        Me.Panel4.Name = "Panel4"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.Panel5, "Panel5")
        Me.Panel5.Name = "Panel5"
        '
        'TextBoxLongitud
        '
        resources.ApplyResources(Me.TextBoxLongitud, "TextBoxLongitud")
        Me.TextBoxLongitud.Name = "TextBoxLongitud"
        Me.TextBoxLongitud.ReadOnly = True
        Me.TextBoxLongitud.TabStop = False
        '
        'LabelStatus
        '
        Me.LabelStatus.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.LabelStatus, "LabelStatus")
        Me.LabelStatus.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LabelStatus.Name = "LabelStatus"
        '
        'LabelSatelites
        '
        Me.LabelSatelites.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.LabelSatelites, "LabelSatelites")
        Me.LabelSatelites.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LabelSatelites.Name = "LabelSatelites"
        '
        'LabelLongitud
        '
        Me.LabelLongitud.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.LabelLongitud, "LabelLongitud")
        Me.LabelLongitud.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LabelLongitud.Name = "LabelLongitud"
        '
        'LabelLatitud
        '
        Me.LabelLatitud.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.LabelLatitud, "LabelLatitud")
        Me.LabelLatitud.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LabelLatitud.Name = "LabelLatitud"
        '
        'LabelFechaHora
        '
        Me.LabelFechaHora.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.LabelFechaHora, "LabelFechaHora")
        Me.LabelFechaHora.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LabelFechaHora.Name = "LabelFechaHora"
        '
        'TextBoxLatitud
        '
        resources.ApplyResources(Me.TextBoxLatitud, "TextBoxLatitud")
        Me.TextBoxLatitud.Name = "TextBoxLatitud"
        Me.TextBoxLatitud.ReadOnly = True
        Me.TextBoxLatitud.TabStop = False
        '
        'TimerGPS
        '
        '
        'FormPuntoGPS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        resources.ApplyResources(Me, "$this")
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MinimizeBox = False
        Me.Name = "FormPuntoGPS"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LabelSatelites As System.Windows.Forms.Label
    Friend WithEvents LabelStatus As System.Windows.Forms.Label
    Friend WithEvents LabelFechaHora As System.Windows.Forms.Label
    Friend WithEvents LabelLongitud As System.Windows.Forms.Label
    Friend WithEvents TextBoxLongitud As System.Windows.Forms.TextBox
    Friend WithEvents LabelLatitud As System.Windows.Forms.Label
    Friend WithEvents TextBoxLatitud As System.Windows.Forms.TextBox
    Friend WithEvents TimerGPS As System.Windows.Forms.Timer
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents LabelTitulo As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents LabelEstado As System.Windows.Forms.Label
End Class
