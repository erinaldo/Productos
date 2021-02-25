Public Class FrmZoom
    Inherits System.Windows.Forms.Form

    ' Declaraciones del API para 32 bits
    Private Declare Function GetWindowLong Lib "user32" Alias "GetWindowLongA" _
        (ByVal hwnd As Integer, ByVal nIndex As Integer) As Integer
    Private Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" _
           (ByVal hwnd As Integer, ByVal nIndex As Integer, _
            ByVal dwNewLong As Integer) As Integer
    Private Declare Function SetWindowPos Lib "user32" _
        (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, _
         ByVal X As Integer, ByVal Y As Integer, _
         ByVal cX As Integer, ByVal cY As Integer, _
         ByVal wFlags As Integer) As Integer

    ' Constantes para usar con el API
    Const GWL_STYLE As Integer = (-16)
    Const WS_THICKFRAME As Integer = &H40000 ' Con borde redimensionable
    Const SWP_DRAWFRAME As Integer = &H20
    Const SWP_NOMOVE As Integer = &H2
    Const SWP_NOSIZE As Integer = &H1
    Const SWP_NOZORDER As Integer = &H4

    

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
    Friend WithEvents TxtZoom As System.Windows.Forms.TextBox
    Friend WithEvents TrcZoom As System.Windows.Forms.TrackBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TxtZoom = New System.Windows.Forms.TextBox
        Me.TrcZoom = New System.Windows.Forms.TrackBar
        CType(Me.TrcZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtZoom
        '
        Me.TxtZoom.Location = New System.Drawing.Point(10, 9)
        Me.TxtZoom.Name = "TxtZoom"
        Me.TxtZoom.ReadOnly = True
        Me.TxtZoom.Size = New System.Drawing.Size(47, 20)
        Me.TxtZoom.TabIndex = 4
        Me.TxtZoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TrcZoom
        '
        Me.TrcZoom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TrcZoom.Location = New System.Drawing.Point(12, 35)
        Me.TrcZoom.Maximum = 50
        Me.TrcZoom.Minimum = 1
        Me.TrcZoom.Name = "TrcZoom"
        Me.TrcZoom.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrcZoom.Size = New System.Drawing.Size(45, 262)
        Me.TrcZoom.TabIndex = 3
        Me.TrcZoom.Value = 1
        '
        'FrmZoom
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(74, 309)
        Me.Controls.Add(Me.TxtZoom)
        Me.Controls.Add(Me.TrcZoom)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(80, 173)
        Me.Name = "FrmZoom"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Zoom"
        CType(Me.TrcZoom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private Sub FrmZoom_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        ModPos.Zoom.Dispose()
        ModPos.Zoom = Nothing
    End Sub


    
    Private Sub FrmZoom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.TrcZoom.Value = ModPos.EscalaActual
        Me.TxtZoom.Text = CStr(100 * ModPos.EscalaActual) & "%"
    End Sub

    Private Sub TrcZoom_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrcZoom.Scroll
        Dim NuevaEscala, px, py As Integer
        NuevaEscala = Me.TrcZoom.Value
        ModPos.EscalaActual = NuevaEscala
        Me.TxtZoom.Text = CStr(100 * NuevaEscala) & "%"

        With ModPos.Superficie
            .Width = (.Width / .Escala) * NuevaEscala
            .Height = (.Height / .Escala) * NuevaEscala
            .Escala = NuevaEscala
            .CambioTamaño = True
        End With

        If ModPos.numEst_Vector > 0 Then
            Dim i As Integer = 0
            Dim Style As Integer
            While i < ModPos.numEst_Vector
                Style = GetWindowLong(ModPos.vector(i).Handle.ToInt32, GWL_STYLE)
                If (Style And WS_THICKFRAME) = WS_THICKFRAME Then
                    ' Si ya lo tiene, lo quita
                    Style = Style Xor WS_THICKFRAME
                    SetWindowLong(ModPos.vector(i).Handle.ToInt32, GWL_STYLE, Style)
                    SetWindowPos(ModPos.vector(i).Handle.ToInt32, Me.Handle.ToInt32, 0, 0, 0, 0, SWP_NOZORDER Or SWP_NOSIZE Or SWP_NOMOVE Or SWP_DRAWFRAME)
                End If

                ModPos.vector(i).Width = (ModPos.vector(i).Width / ModPos.vector(i).Escala) * NuevaEscala
                ModPos.vector(i).Height = (ModPos.vector(i).Height / ModPos.vector(i).Escala) * NuevaEscala
                px = (ModPos.vector(i).Location.X / ModPos.vector(i).Escala) * NuevaEscala
                py = (ModPos.vector(i).Location.Y / ModPos.vector(i).Escala) * NuevaEscala
                ModPos.vector(i).Location = New Point(px, py)
                ModPos.vector(i).Escala = NuevaEscala
                i += 1
            End While

        End If
        ModPos.Superficie.Refresh()

    End Sub
End Class
