Public Class FormGrupos
    Inherits System.Windows.Forms.Form
    Friend WithEvents LabelGrupo As System.Windows.Forms.Label
    Friend WithEvents ListBoxGrupos As System.Windows.Forms.ListBox
    Friend WithEvents ButtonX As System.Windows.Forms.Button
    Friend WithEvents ButtonOK As System.Windows.Forms.Button

    Public sClaveGrupo As String

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.LabelGrupo = New System.Windows.Forms.Label
        Me.ListBoxGrupos = New System.Windows.Forms.ListBox
        Me.ButtonX = New System.Windows.Forms.Button
        Me.ButtonOK = New System.Windows.Forms.Button
        '
        'LabelGrupo
        '
        Me.LabelGrupo.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular)
        Me.LabelGrupo.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelGrupo.Location = New System.Drawing.Point(4, 8)
        Me.LabelGrupo.Size = New System.Drawing.Size(180, 16)
        Me.LabelGrupo.Text = "LabelGrupo"
        '
        'ListBoxGrupos
        '
        Me.ListBoxGrupos.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular)
        Me.ListBoxGrupos.Location = New System.Drawing.Point(4, 28)
        Me.ListBoxGrupos.Size = New System.Drawing.Size(184, 82)
        '
        'ButtonX
        '
        Me.ButtonX.Location = New System.Drawing.Point(80, 116)
        Me.ButtonX.Text = "ButtonX"
        '
        'ButtonOK
        '
        Me.ButtonOK.Location = New System.Drawing.Point(4, 116)
        Me.ButtonOK.Text = "ButtonOK"
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        '
        'FormGrupos
        '
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(192, 140)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.ButtonX)
        Me.Controls.Add(Me.ListBoxGrupos)
        Me.Controls.Add(Me.LabelGrupo)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Text = "Amesol Route"

    End Sub

#End Region

    Private Sub ListBoxGrupos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxGrupos.SelectedIndexChanged
        sClaveGrupo = ListBoxGrupos.SelectedValue
    End Sub

    Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
        If ListBoxGrupos.SelectedIndex <> -1 Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Else
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub ButtonX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

End Class
