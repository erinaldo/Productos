Public Class FormMensajesTerminal
    Inherits System.Windows.Forms.Form
    Friend WithEvents MainMenuMensajes As System.Windows.Forms.MainMenu

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal parsClienteClave As String, ByVal pardtMensajes As DataTable, ByVal partTipoMensaje As TipoMensaje)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        dtMensajes = pardtMensajes
        sClienteClave = parsClienteClave
        tTipoMensaje = partTipoMensaje
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MainMenuMensajes Is Nothing Then Me.MainMenuMensajes.Dispose()
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenuMensajes = New System.Windows.Forms.MainMenu
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ButtonAceptar = New System.Windows.Forms.Button
        Me.DetailViewMensaje = New Resco.Controls.DetailView.DetailView
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ButtonAceptar)
        Me.Panel1.Controls.Add(Me.DetailViewMensaje)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'ButtonAceptar
        '
        Me.ButtonAceptar.Location = New System.Drawing.Point(4, 262)
        Me.ButtonAceptar.Name = "ButtonAceptar"
        Me.ButtonAceptar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonAceptar.TabIndex = 2
        Me.ButtonAceptar.Text = "ButtonAceptar"
        '
        'DetailViewMensaje
        '
        Me.DetailViewMensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DetailViewMensaje.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DetailViewMensaje.LabelWidth = 108
        Me.DetailViewMensaje.Location = New System.Drawing.Point(4, 6)
        Me.DetailViewMensaje.Name = "DetailViewMensaje"
        Me.DetailViewMensaje.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.TabStrip
        Me.DetailViewMensaje.SeparatorWidth = 4
        Me.DetailViewMensaje.Size = New System.Drawing.Size(232, 252)
        Me.DetailViewMensaje.TabIndex = 3
        '
        'FormMensajesTerminal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Menu = Me.MainMenuMensajes
        Me.Name = "FormMensajesTerminal"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private refaVista As Vista
    Private dtMensajes As DataTable
    Private nIndice As Integer = 0
    Private sClienteClave As String
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonAceptar As System.Windows.Forms.Button
    Friend WithEvents DetailViewMensaje As Resco.Controls.DetailView.DetailView
    Private tTipoMensaje As TipoMensaje
    Private Sub ButtonAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAceptar.Click
        If nIndice <= dtMensajes.Rows.Count - 1 Then
            If tTipoMensaje = TipoMensaje.General Then
                Dim itemCbo As Resco.Controls.DetailView.ItemComboBox = Me.DetailViewMensaje.Items(3)
                MensajesTerminal.CambiarAccion(sClienteClave, dtMensajes.Rows(nIndice)("MDBMensajeID"), itemCbo.SelectedIndex + 1)
            End If
            nIndice = nIndice + 1
            If nIndice > dtMensajes.Rows.Count - 1 Then
                Me.Close()
                Exit Sub
            End If
            SiguienteMensaje()
        Else
            Me.Close()
        End If
    End Sub


    Private Sub FormMensajesTerminal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        ' Recuperar los demás componentes de la forma
        If Not Vista.Buscar("FormMensajesTerminal", refaVista) Then
            Exit Sub
        End If
        If tTipoMensaje = TipoMensaje.Cumpleaños Then
            refaVista.CrearDetailView(Me.DetailViewMensaje, "DetailViewMensajeCumpleaños")
        Else
            refaVista.CrearDetailView(Me.DetailViewMensaje, "DetailViewMensaje")
        End If
        Dim itemTxt As Resco.Controls.DetailView.ItemTextBox = Me.DetailViewMensaje.Items(2)
        With itemTxt
            .WordWrap = True
            .MultiLine = True
            .Height = 72


        End With
        Me.DetailViewMensaje.LabelWidth = 80

        SiguienteMensaje()
        refaVista.ColocarEtiquetasForma(Me)
    End Sub

    Private Sub SiguienteMensaje()
        If tTipoMensaje = TipoMensaje.Cumpleaños Then
            refaVista.PoblarDetailView(DetailViewMensaje, odbVen, "DetailViewMensajeCumpleaños", "WHERE MDBMensaje.MDBMensajeID='" & dtMensajes.Rows(nIndice)("MDBMensajeID") & "'")
        Else
            refaVista.PoblarDetailView(DetailViewMensaje, odbVen, "DetailViewMensaje", "WHERE ClienteMensaje.MDBMensajeID='" & dtMensajes.Rows(nIndice)("MDBMensajeID") & "'")
            Dim itemCbo As Resco.Controls.DetailView.ItemComboBox = Me.DetailViewMensaje.Items(3)
            itemCbo.SelectedIndex = 0
        End If
    End Sub
    Public Enum TipoMensaje
        Cumpleaños = 0
        General
    End Enum

    Private Sub Panel1_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel1.GotFocus

    End Sub
End Class
