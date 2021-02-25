Public Class FrmMain
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
    Friend WithEvents Ver As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents JCBMenu As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents Ayuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Ayuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Salir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Salir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents Barras As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Menus As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents STBPrincipal As System.Windows.Forms.StatusBar
    Friend WithEvents StUsuario As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StFecha As System.Windows.Forms.StatusBarPanel
    Friend WithEvents Contenido1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Acercade1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Contenido As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Acercade As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.Ver = New Janus.Windows.UI.CommandBars.UICommand("Ver")
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.JCBMenu = New Janus.Windows.UI.CommandBars.UICommandBar
        Me.Barras = New Janus.Windows.UI.CommandBars.UICommand("Menu")
        Me.Ayuda1 = New Janus.Windows.UI.CommandBars.UICommand("Ayuda")
        Me.Salir1 = New Janus.Windows.UI.CommandBars.UICommand("Salir")
        Me.Menus = New Janus.Windows.UI.CommandBars.UICommand("Menu")
        Me.Ayuda = New Janus.Windows.UI.CommandBars.UICommand("Ayuda")
        Me.Contenido1 = New Janus.Windows.UI.CommandBars.UICommand("Contenido")
        Me.Acercade1 = New Janus.Windows.UI.CommandBars.UICommand("Acercade")
        Me.Salir = New Janus.Windows.UI.CommandBars.UICommand("Salir")
        Me.Contenido = New Janus.Windows.UI.CommandBars.UICommand("Contenido")
        Me.Acercade = New Janus.Windows.UI.CommandBars.UICommand("Acercade")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.STBPrincipal = New System.Windows.Forms.StatusBar
        Me.StUsuario = New System.Windows.Forms.StatusBarPanel
        Me.StFecha = New System.Windows.Forms.StatusBarPanel
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JCBMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.StUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Ver
        '
        Me.Ver.Key = "Ver"
        Me.Ver.Name = "Ver"
        Me.Ver.Shortcut = System.Windows.Forms.Shortcut.ShiftF1
        Me.Ver.Text = "Ver"
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.JCBMenu})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.Menus, Me.Ayuda, Me.Salir, Me.Contenido, Me.Acercade})
        Me.UiCommandManager1.ContainerControl = Me
        Me.UiCommandManager1.Id = New System.Guid("23cd0552-443a-4501-8640-2ecdf9a782d8")
        Me.UiCommandManager1.LeftRebar = Me.LeftRebar1
        Me.UiCommandManager1.RightRebar = Me.RightRebar1
        Me.UiCommandManager1.Tag = Nothing
        Me.UiCommandManager1.TopRebar = Me.TopRebar1
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.UiCommandManager1
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'JCBMenu
        '
        Me.JCBMenu.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu
        Me.JCBMenu.CommandManager = Me.UiCommandManager1
        Me.JCBMenu.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.Barras, Me.Ayuda1, Me.Salir1})
        Me.JCBMenu.Key = "Principal"
        Me.JCBMenu.Location = New System.Drawing.Point(0, 0)
        Me.JCBMenu.Name = "JCBMenu"
        Me.JCBMenu.RowIndex = 0
        Me.JCBMenu.Size = New System.Drawing.Size(792, 26)
        Me.JCBMenu.Text = "Menu Principal"
        '
        'Barras
        '
        Me.Barras.Key = "Menu"
        Me.Barras.Name = "Barras"
        '
        'Ayuda1
        '
        Me.Ayuda1.Key = "Ayuda"
        Me.Ayuda1.Name = "Ayuda1"
        '
        'Salir1
        '
        Me.Salir1.Key = "Salir"
        Me.Salir1.Name = "Salir1"
        '
        'Menus
        '
        Me.Menus.Key = "Menu"
        Me.Menus.Name = "Menus"
        Me.Menus.Text = "Menu"
        Me.Menus.ToolTipText = "Muestra la barra de Menu"
        '
        'Ayuda
        '
        Me.Ayuda.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.Contenido1, Me.Acercade1})
        Me.Ayuda.Key = "Ayuda"
        Me.Ayuda.Name = "Ayuda"
        Me.Ayuda.Text = "Ayuda"
        '
        'Contenido1
        '
        Me.Contenido1.Key = "Contenido"
        Me.Contenido1.Name = "Contenido1"
        '
        'Acercade1
        '
        Me.Acercade1.Key = "Acercade"
        Me.Acercade1.Name = "Acercade1"
        '
        'Salir
        '
        Me.Salir.Key = "Salir"
        Me.Salir.Name = "Salir"
        Me.Salir.Text = "Salir"
        Me.Salir.ToolTipText = "Salir de la aplicación"
        '
        'Contenido
        '
        Me.Contenido.Icon = CType(resources.GetObject("Contenido.Icon"), System.Drawing.Icon)
        Me.Contenido.Key = "Contenido"
        Me.Contenido.Name = "Contenido"
        Me.Contenido.Text = "Cómo"
        '
        'Acercade
        '
        Me.Acercade.Icon = CType(resources.GetObject("Acercade.Icon"), System.Drawing.Icon)
        Me.Acercade.Key = "Acercade"
        Me.Acercade.Name = "Acercade"
        Me.Acercade.Text = "Acerca de Selling"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.UiCommandManager1
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.UiCommandManager1
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.JCBMenu})
        Me.TopRebar1.CommandManager = Me.UiCommandManager1
        Me.TopRebar1.Controls.Add(Me.JCBMenu)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(792, 26)
        '
        'STBPrincipal
        '
        Me.STBPrincipal.Location = New System.Drawing.Point(0, 528)
        Me.STBPrincipal.Name = "STBPrincipal"
        Me.STBPrincipal.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StUsuario, Me.StFecha})
        Me.STBPrincipal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.STBPrincipal.ShowPanels = True
        Me.STBPrincipal.Size = New System.Drawing.Size(792, 38)
        Me.STBPrincipal.TabIndex = 3
        Me.STBPrincipal.Text = "StatusBar1"
        '
        'StUsuario
        '
        Me.StUsuario.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StUsuario.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None
        Me.StUsuario.Icon = CType(resources.GetObject("StUsuario.Icon"), System.Drawing.Icon)
        Me.StUsuario.Name = "StUsuario"
        Me.StUsuario.Text = "Usuario"
        Me.StUsuario.Width = 387
        '
        'StFecha
        '
        Me.StFecha.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StFecha.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None
        Me.StFecha.Name = "StFecha"
        Me.StFecha.Text = "Fecha"
        Me.StFecha.Width = 387
        '
        'Clock
        '
        Me.Clock.Interval = 1000
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(799, 575)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'FrmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 566)
        Me.Controls.Add(Me.STBPrincipal)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TopRebar1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "FrmMain"
        Me.Text = "Selling"
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JCBMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        CType(Me.StUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private SourceToImage As Bitmap

    Dim El_Archivo As String

  

    Private Sub RecuperaFondo()

        Dim DirActual As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(Application.ExecutablePath).Parent
        Dim dir As String = DirActual.FullName()

        dir = dir & "\Selling.jpg"

        'Generar un bitmap para el origen
        Dim SourceImage As Bitmap
        Try
            SourceImage = New Bitmap(dir)


            ' Generar un bitmap para el resultado
            SourceToImage = New Bitmap(SourceImage.Width, SourceImage.Height)

            ' Generar un objeto Gráfico para el Bitmap resultante
            Dim gr_source As Graphics = Graphics.FromImage(SourceToImage)

            ' Copiar la imagen origen al Bitmap destino
            gr_source.DrawImage(SourceImage, 0, 0, _
                SourceToImage.Width, _
                SourceToImage.Height)

            PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage

            'Muestra imagen origen
            PictureBox1.Image = CType(SourceToImage, Image)

            'Liberar recursos
            gr_source.Dispose()

            SourceImage.Dispose()

            Dim imagen As New Drawing.Bitmap(PictureBox1.Image, Me.Width, Me.Height)
            'La cargamos al background
            Me.BackgroundImage = imagen

            Me.PictureBox1.Dock = DockStyle.Fill

        Catch ex As Exception
            MessageBox.Show("No se pudo recuperar la imagen de fondo", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Public Shared Sub Main()
        Application.EnableVisualStyles()
        Application.DoEvents()
        ModPOS.Splash = New FrmSplash
        ModPOS.Splash.ShowDialog()
        ModPOS.Login = New FrmLogin
        ModPOS.Login.ShowDialog()

        If ModPOS.Login.DialogResult = System.Windows.Forms.DialogResult.OK Then
            ModPOS.Login.Dispose()
            ModPOS.Login = Nothing
            If ModPOS.UsuarioLogin <> "" AndAlso ModPOS.BDConexion <> "" AndAlso AccesoAutorizado Then

                If VersionActual <> VersionSelling Then
                    Beep()
                    MessageBox.Show("La Versión actual de su equipo " & VersionSelling & " no corresponde a la del Servidor " & VersionActual & ". Por lo que deberá desintalar la vesión actual y reinstalar la nueva versión, a continuacion se iniciara la descarga", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Dim dtVersion As DataTable
                    Dim sVersionActual As String = ""
                    dtVersion = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@PARClave", "Version", "@COMClave", ModPOS.CompanyActual)
                    If dtVersion.Rows.Count > 0 Then
                        sVersionActual = IIf(dtVersion.Rows(0)("Valor").GetType.Name = "DBNull", "", dtVersion.Rows(0)("Valor"))
                    End If
                    dtVersion.Dispose()

                    Try
                        If Not System.IO.Directory.Exists(sVersionActual) Then
                            MessageBox.Show("No se tiene acceso al directorio( " & sVersionActual & " ) para descargar la versión. Favor de contactar a Soporte Tecnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    Catch ex As Exception
                    End Try

                    Dim sFile As String

                    If sVersionActual.Length <= 3 Then
                        sFile = sVersionActual & "*"
                    ElseIf sVersionActual.Substring(sVersionActual.Length - 1, 1) = "\" Then
                        sFile = sVersionActual & "*"
                    Else
                        sFile = sVersionActual & "\" & "*"
                    End If

                    Dim DirActual As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(Application.ExecutablePath).Parent
                    Dim dir As String = DirActual.FullName()



                    If System.IO.File.Exists(dir & "\analiza.bat ") Then
                        Shell(dir & "\analiza.bat " & sFile, AppWinStyle.NormalFocus, False)
                    Else
                        MessageBox.Show("El archivo " & dir & "\analiza.bat " & " no existe o se cambio de lugar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    Exit Sub
                End If

                ModPOS.MPrincipal = New FrmMain
                ModPOS.MPrincipal.Width = Screen.PrimaryScreen.Bounds.Width
                ModPOS.MPrincipal.Height = Screen.PrimaryScreen.Bounds.Height
                ModPOS.MPrincipal.StartPosition = FormStartPosition.CenterScreen
                ModPOS.MPrincipal.ShowDialog()
            End If
        Else
            ModPOS.Login.Dispose()
            ModPOS.Login = Nothing
        End If


    End Sub

    Private Sub FrmTPDV_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Select Case MessageBox.Show("¿Esta seguro que desea Salir Completamente de la Aplicación?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            Case DialogResult.No
                e.Cancel = True

        End Select
    End Sub

    Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        Dim timeout As Object = recuperaParametro("TimeOut")
        Dim tmp As Integer = IIf(timeout Is Nothing, 0, CInt(timeout))
        ModPOS.myTimeOut = tmp
        RecuperaFondo()

        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@PARClave", "Reemplazo", "@COMClave", ModPOS.CompanyActual)
        If dt.Rows.Count = 0 Then
            cReplace = "-"
        Else
            cReplace = IIf(dt.Rows(0)("Valor").GetType.Name = "DBNull", "", dt.Rows(0)("Valor"))
        End If
        dt.Dispose()

        Barra = New FrmMenu
        Barra.MdiParent = ModPOS.MPrincipal
        Barra.Show()

        Clock.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clock.Tick
        Me.StFecha.Text = DateTime.Today.ToLongDateString & " " & DateTime.Now.ToShortTimeString 'ToString("MMMM dd, yyyy")
    End Sub

    Private Sub JCBMenu_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles JCBMenu.CommandClick
        Select Case e.Command.Key

            Case "Salir"
                Me.Close()

            Case "Menu"
                If Barra Is Nothing Then
                    Barra = New FrmMenu
                    Barra.MdiParent = ModPOS.MPrincipal
                End If
                Barra.Show()


            Case "Acercade"
                Dim msg As New FrmMeMsg
                msg.TxtTiulo = "Acerca De"
                msg.TxtMsg = "Selling® " & ModPOS.Version
                msg.TxtMsg2 = "Todos los derechos reservados 2012 Elephant Works"
                msg.ShowDialog()
                msg.Dispose()
            Case "Contenido"
                Dim El_Archivo As String

                Dim DirActual As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(Application.ExecutablePath).Parent
                Dim dir As String = DirActual.FullName()

                El_Archivo = dir & "\Selling.chm"
                Help.ShowHelp(Me, El_Archivo)
        End Select
    End Sub

    'Private Sub FrmMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
    '    Dim imagen As New Drawing.Bitmap(PictureBox1.Image, Me.Width, Me.Height)
    '    'La cargamos al background
    '    Me.BackgroundImage = imagen
    'End Sub


End Class
