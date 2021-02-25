Public Class FrmSplashRedondeo
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnOk As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    Friend WithEvents PicRedondeo As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSplashRedondeo))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton
        Me.BtnOk = New Janus.Windows.EditControls.UIButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.PicRedondeo = New System.Windows.Forms.PictureBox
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.PicRedondeo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Name = "Label2"
        '
        'BtnCancel
        '
        Me.BtnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        resources.ApplyResources(Me.BtnCancel, "BtnCancel")
        Me.BtnCancel.Name = "BtnCancel"
        '
        'BtnOk
        '
        Me.BtnOk.BackColor = System.Drawing.SystemColors.Control
        Me.BtnOk.Image = CType(resources.GetObject("BtnOk.Image"), System.Drawing.Image)
        resources.ApplyResources(Me.BtnOk, "BtnOk")
        Me.BtnOk.Name = "BtnOk"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Name = "Label5"
        '
        'PicRedondeo
        '
        resources.ApplyResources(Me.PicRedondeo, "PicRedondeo")
        Me.PicRedondeo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicRedondeo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicRedondeo.Name = "PicRedondeo"
        Me.PicRedondeo.TabStop = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Name = "Label3"
        '
        'FrmSplashRedondeo
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PicRedondeo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmSplashRedondeo"
        Me.ShowInTaskbar = False
        CType(Me.PicRedondeo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public url_imagen As String = ""
    Public VENClave As String
    Public Total, Importe As Double



    Private SourceToImage As Bitmap

    Public ReadOnly Property ImpRedondeo() As Double
        Get
            ImpRedondeo = Importe
        End Get
    End Property

    Private Sub RecuperaImagenProducto(ByVal File As String)
        'Generar un bitmap para el origen
        Dim SourceImage As Bitmap
        Try
            SourceImage = New Bitmap(File)


            ' Generar un bitmap para el resultado
            SourceToImage = New Bitmap(SourceImage.Width, SourceImage.Height)

            ' Generar un objeto Gráfico para el Bitmap resultante
            Dim gr_source As Graphics = Graphics.FromImage(SourceToImage)

            ' Copiar la imagen origen al Bitmap destino
            gr_source.DrawImage(SourceImage, 0, 0, _
                SourceToImage.Width, _
                SourceToImage.Height)

            PicRedondeo.SizeMode = PictureBoxSizeMode.CenterImage

            'Muestra imagen origen
            PicRedondeo.Image = CType(SourceToImage, Image)

            'Liberar recursos
            gr_source.Dispose()

            SourceImage.Dispose()

        Catch ex As Exception
            MessageBox.Show("No se pudo recuperar la imagen del producto", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub FrmSplashVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        Dim dt As DataTable

        dt = ModPOS.Recupera_Tabla("sp_recupera_total", "@VENClave", VENClave)
        Total = dt.Rows(0)("Total")
        dt.Dispose()

        Dim dTotal As Double
        dTotal = Redondear(Total, 0)

        Importe = dTotal - Total

        'recupera subtotal, aplica redondeo y actualiza total y actualiza importe redondeo


        If url_imagen <> "" Then
            Me.RecuperaImagenProducto(url_imagen)
        End If

        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Show()
        Me.BringToFront()

    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Ejecuta("sp_aplica_redondeo", "@Redondeo", Importe, "@VENClave", VENClave)
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Importe = 0
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class


