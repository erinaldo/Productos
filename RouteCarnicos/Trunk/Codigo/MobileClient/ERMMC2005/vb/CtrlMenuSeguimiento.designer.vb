<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class CtrlMenuSeguimiento
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        QuitarEventosMenuItem()
        Me.TimerOcultar.Dispose()
        Me.TimerOcultar = Nothing
        Me.TimerToolTip.Dispose()
        Me.TimerToolTip = Nothing
        Me.PicDer.Dispose()
        Me.PicDer = Nothing
        Me.PicIzq.Dispose()
        Me.PicIzq = Nothing
        Me.PicContenedor.Dispose()
        Me.PicContenedor = Nothing
        Me.PicOcultar.Dispose()
        Me.PicOcultar = Nothing

        iCeldaInicial = Nothing
        iCeldaSeleccionada = Nothing
        iContador = Nothing
        iCeldaAnterior = Nothing
        iCeldaActual = Nothing
        bIniciando = Nothing
        bOcultado = Nothing
        bDobleClick = Nothing
        bTerminarVisita = Nothing
        hActividades = Nothing
        ModuloMovDetalleClaveMenuItem = Nothing
        MenuItemSeleccionado = Nothing
        bImproductividad = Nothing

        If Not Me.Renglon Is Nothing Then
            Me.Renglon.Dispose()
            Me.Renglon = Nothing
        End If
        If Not Me.cMOTConfiguracion Is Nothing Then
            Me.cMOTConfiguracion.Dispose()
            Me.cMOTConfiguracion = Nothing
        End If
        If Not Me.LMenuItem Is Nothing Then
            Me.LMenuItem.Dispose()
            Me.LMenuItem = Nothing
        End If

        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        If Not IsNothing(Me.Renglon) Then
            For Each r As CeldaSeguimiento In Me.Renglon.Celdas
                r.Dispose()
            Next
        End If

        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PicContenedor = New System.Windows.Forms.PictureBox
        Me.TimerOcultar = New System.Windows.Forms.Timer
        Me.PicIzq = New System.Windows.Forms.PictureBox
        Me.PicDer = New System.Windows.Forms.PictureBox
        Me.PicOcultar = New System.Windows.Forms.PictureBox
        Me.TimerToolTip = New System.Windows.Forms.Timer
        Me.SuspendLayout()
        '
        'PicContenedor
        '
        Me.PicContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PicContenedor.Location = New System.Drawing.Point(30, 0)
        Me.PicContenedor.Name = "PicContenedor"
        Me.PicContenedor.Size = New System.Drawing.Size(180, 36)
        '
        'TimerOcultar
        '
        Me.TimerOcultar.Interval = 1000
        '
        'PicIzq
        '
        Me.PicIzq.Dock = System.Windows.Forms.DockStyle.Left
        Me.PicIzq.Location = New System.Drawing.Point(0, 0)
        Me.PicIzq.Name = "PicIzq"
        Me.PicIzq.Size = New System.Drawing.Size(30, 36)
        Me.PicIzq.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        '
        'PicDer
        '
        Me.PicDer.Dock = System.Windows.Forms.DockStyle.Right
        Me.PicDer.Location = New System.Drawing.Point(210, 0)
        Me.PicDer.Name = "PicDer"
        Me.PicDer.Size = New System.Drawing.Size(30, 36)
        Me.PicDer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        '
        'PicOcultar
        '
        Me.PicOcultar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PicOcultar.Location = New System.Drawing.Point(30, 0)
        Me.PicOcultar.Name = "PicOcultar"
        Me.PicOcultar.Size = New System.Drawing.Size(180, 36)
        '
        'TimerToolTip
        '
        Me.TimerToolTip.Interval = 800
        '
        'CtrlMenuSeguimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.PicOcultar)
        Me.Controls.Add(Me.PicContenedor)
        Me.Controls.Add(Me.PicIzq)
        Me.Controls.Add(Me.PicDer)
        Me.Name = "CtrlMenuSeguimiento"
        Me.Size = New System.Drawing.Size(240, 36)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PicContenedor As System.Windows.Forms.PictureBox
    Friend WithEvents TimerOcultar As System.Windows.Forms.Timer
    Friend WithEvents PicIzq As System.Windows.Forms.PictureBox
    Friend WithEvents PicDer As System.Windows.Forms.PictureBox
    Friend WithEvents PicOcultar As System.Windows.Forms.PictureBox
    Friend WithEvents TimerToolTip As System.Windows.Forms.Timer

End Class
