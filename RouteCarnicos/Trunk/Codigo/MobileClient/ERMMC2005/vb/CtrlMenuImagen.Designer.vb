<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class CtrlMenuImagen
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        If Not IsNothing(Renglones) Then
            For Each r As Renglon In Renglones
                r.Dispose()
            Next
        End If
        Me.Panel1.Dispose()
        Me.lblMenuActual.Dispose()
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblMenuActual = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.SuspendLayout()
        '
        'lblMenuActual
        '
        Me.lblMenuActual.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblMenuActual.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblMenuActual.Location = New System.Drawing.Point(0, 0)
        Me.lblMenuActual.Name = "lblMenuActual"
        Me.lblMenuActual.Size = New System.Drawing.Size(150, 20)
        Me.lblMenuActual.Text = "Menu 1"
        Me.lblMenuActual.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(0, 23)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(150, 124)
        '
        'CtrlMenuImagen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblMenuActual)
        Me.Name = "CtrlMenuImagen"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblMenuActual As System.Windows.Forms.Label

    Private Sub CtrlMenuImagen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
        SeleccionarCeldaActual()
    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
