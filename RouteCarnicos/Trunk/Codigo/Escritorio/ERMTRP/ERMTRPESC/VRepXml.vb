Imports System.IO
Imports System.Xml
Public Class VRepXml

    Private sRuta As String
    Private Sub VRepXml_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim WebBrowser1 As New WebBrowser()
        WebBrowser1.Url = New Uri(sRuta)
        WebBrowser1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        WebBrowser1.Location = New System.Drawing.Point(10, 12)
        WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        WebBrowser1.Name = "WebBrowser1"
        WebBrowser1.Size = New System.Drawing.Size(592, 192)

        Me.Controls.Add(WebBrowser1)

        Me.Text = sRuta

        Dim vcMensaje As New BASMENLOG.CMensaje
        btRegresar.Text = vcMensaje.RecuperarDescripcion("btregresar")
        btRegresar.ToolTipText = vcMensaje.RecuperarDescripcion("btregresar")

    End Sub

    Public Sub New(ByVal pRuta As String)
        sRuta = pRuta
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub btRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRegresar.Click
        Me.Close()
    End Sub
End Class