Public Class FrmPicture
    Inherits System.Windows.Forms.Form

    Public url_imagen As String
    Public arrayFoto(0) As Foto
    Public Padre As String = ""
    Private sPROClave As String
    Private sClave As String
    Private sNombre As String
    Private iAvanceMenu As Integer
    Private PictureSelected As String
    Private ultimaX, indiceSelected As Integer
    Private indice As Integer = 0
    Private SourceToImage As Bitmap
    'Private img As Image

    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnIzqMenu As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnDerMenu As Janus.Windows.EditControls.UIButton
    Friend WithEvents pnlMenu As System.Windows.Forms.Panel
    Friend WithEvents btnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnRemover As Janus.Windows.EditControls.UIButton



    Public WriteOnly Property NombreProducto() As String
        Set(ByVal Value As String)
            sNombre = Value
        End Set
    End Property

    Public WriteOnly Property ClaveProducto() As String
        Set(ByVal Value As String)
            sClave = Value
        End Set
    End Property

    Public WriteOnly Property PROClave() As String
        Set(ByVal Value As String)
            sPROClave = Value
        End Set
    End Property

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents PicProducto As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPicture))
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.PicProducto = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnIzqMenu = New Janus.Windows.EditControls.UIButton()
        Me.btnDerMenu = New Janus.Windows.EditControls.UIButton()
        Me.pnlMenu = New System.Windows.Forms.Panel()
        Me.btnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.btnRemover = New Janus.Windows.EditControls.UIButton()
        CType(Me.PicProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblNombre
        '
        Me.LblNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblNombre.BackColor = System.Drawing.Color.Transparent
        Me.LblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombre.ForeColor = System.Drawing.Color.Black
        Me.LblNombre.Location = New System.Drawing.Point(7, 37)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(558, 30)
        Me.LblNombre.TabIndex = 42
        Me.LblNombre.Text = "PRODUCTO:"
        '
        'PicProducto
        '
        Me.PicProducto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicProducto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicProducto.Location = New System.Drawing.Point(5, 70)
        Me.PicProducto.Name = "PicProducto"
        Me.PicProducto.Size = New System.Drawing.Size(560, 346)
        Me.PicProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicProducto.TabIndex = 54
        Me.PicProducto.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(7, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 30)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "CLAVE:"
        '
        'LblClave
        '
        Me.LblClave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblClave.BackColor = System.Drawing.Color.Transparent
        Me.LblClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClave.ForeColor = System.Drawing.Color.Black
        Me.LblClave.Location = New System.Drawing.Point(107, 7)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(411, 30)
        Me.LblClave.TabIndex = 56
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(183, 517)
        Me.BtnCancelar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 137
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Guardar cambios"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Icon = CType(resources.GetObject("BtnGuardar.Icon"), System.Drawing.Icon)
        Me.BtnGuardar.Location = New System.Drawing.Point(474, 516)
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 138
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnIzqMenu)
        Me.GroupBox1.Controls.Add(Me.btnDerMenu)
        Me.GroupBox1.Controls.Add(Me.pnlMenu)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(5, 418)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(560, 92)
        Me.GroupBox1.TabIndex = 141
        Me.GroupBox1.TabStop = False
        '
        'btnIzqMenu
        '
        Me.btnIzqMenu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIzqMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIzqMenu.Icon = CType(resources.GetObject("btnIzqMenu.Icon"), System.Drawing.Icon)
        Me.btnIzqMenu.ImageVerticalAlignment = Janus.Windows.EditControls.ImageVerticalAlignment.TopOfText
        Me.btnIzqMenu.Location = New System.Drawing.Point(3, 11)
        Me.btnIzqMenu.Name = "btnIzqMenu"
        Me.btnIzqMenu.Size = New System.Drawing.Size(50, 75)
        Me.btnIzqMenu.TabIndex = 61
        Me.btnIzqMenu.ToolTipText = "Anterior"
        Me.btnIzqMenu.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnDerMenu
        '
        Me.btnDerMenu.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDerMenu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDerMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDerMenu.Icon = CType(resources.GetObject("btnDerMenu.Icon"), System.Drawing.Icon)
        Me.btnDerMenu.Location = New System.Drawing.Point(506, 11)
        Me.btnDerMenu.Name = "btnDerMenu"
        Me.btnDerMenu.Size = New System.Drawing.Size(50, 75)
        Me.btnDerMenu.TabIndex = 60
        Me.btnDerMenu.ToolTipText = "Siguiente"
        Me.btnDerMenu.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'pnlMenu
        '
        Me.pnlMenu.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMenu.AutoScroll = True
        Me.pnlMenu.Location = New System.Drawing.Point(56, 11)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Size = New System.Drawing.Size(447, 77)
        Me.pnlMenu.TabIndex = 0
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregar.Icon = CType(resources.GetObject("btnAgregar.Icon"), System.Drawing.Icon)
        Me.btnAgregar.Location = New System.Drawing.Point(376, 516)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.btnAgregar.TabIndex = 142
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.ToolTipText = "Agrega nueva Imagen al producto actual"
        Me.btnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnRemover
        '
        Me.btnRemover.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemover.Icon = CType(resources.GetObject("btnRemover.Icon"), System.Drawing.Icon)
        Me.btnRemover.Location = New System.Drawing.Point(280, 516)
        Me.btnRemover.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnRemover.Name = "btnRemover"
        Me.btnRemover.Size = New System.Drawing.Size(90, 37)
        Me.btnRemover.TabIndex = 143
        Me.btnRemover.Text = "Remover"
        Me.btnRemover.ToolTipText = "Remueve la Imagen seleccionada del producto actual"
        Me.btnRemover.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmPicture
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(572, 556)
        Me.Controls.Add(Me.btnRemover)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.LblClave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PicProducto)
        Me.Controls.Add(Me.LblNombre)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(450, 552)
        Me.Name = "FrmPicture"
        Me.Text = "Visor de Imagen"
        CType(Me.PicProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim picFoto As Foto
        picFoto = sender
        PictureSelected = picFoto.IMGClave
        indiceSelected = picFoto.indice
        PicProducto.Image = picFoto.Image

        PicProducto.SizeMode = PictureBoxSizeMode.Zoom
    End Sub

    Private Sub RecuperaImagenProducto(ByVal sPROClave As String)
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim dr As System.Data.SqlClient.SqlDataReader
        Dim myCommand As System.Data.SqlClient.SqlCommand

        Try
            Cnx = New System.Data.SqlClient.SqlConnection
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MessageBox.Show("No se puede conectar a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        myCommand = New System.Data.SqlClient.SqlCommand("sp_recupera_imagenes", Cnx)
        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.Parameters.Add("@PROClave", SqlDbType.VarChar).Value = sPROClave
        myCommand.CommandTimeout = ModPOS.myTimeOut
        '  myCommand.Parameters.Add("@Perfil", SqlDbType.VarChar).Value = sperfil

        dr = myCommand.ExecuteReader()

        Dim y As Integer
        ultimaX = 2
        y = 2


        While dr.Read

            arrayFoto(indice) = New Foto(dr("IMGClave"))

            arrayFoto(indice).Nuevo = False
            arrayFoto(indice).SizeMode = PictureBoxSizeMode.StretchImage
            arrayFoto(indice).Width = 90
            arrayFoto(indice).Height = 60
            arrayFoto(indice).Location = New Point(ultimaX, y)
            arrayFoto(indice).indice = indice

            If Not dr("Imagen") Is System.DBNull.Value Then
                arrayFoto(indice).Image = ModPOS.RecuperaImagen(url_imagen & CStr(dr("Imagen")))
                arrayFoto(indice).NombreImagen = CStr(dr("Imagen"))
            End If

            ultimaX += 95
            pnlMenu.Controls.Add(arrayFoto(indice))
            AddHandler arrayFoto(indice).Click, AddressOf Menu_Click
            indice += 1
            ReDim Preserve arrayFoto(indice)

        End While

        myCommand.Dispose()
        dr.Close()

        pnlMenu.HorizontalScroll.Enabled = False
        pnlMenu.HorizontalScroll.Visible = False
        iAvanceMenu = pnlMenu.HorizontalScroll.LargeChange

        If arrayFoto(0) IsNot Nothing Then
            PictureSelected = arrayFoto(0).IMGClave
            indiceSelected = arrayFoto(0).indice
            PicProducto.Image = arrayFoto(0).Image
        End If

    End Sub

    Private Sub FrmPicture_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        PicProducto.Image = Nothing
    End Sub

    Private Sub FrmPicture_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LblClave.Text = sClave
        LblNombre.Text = "PRODUCTO: " & sNombre
        RecuperaImagenProducto(sPROClave)

    End Sub

    Private Sub btnIzqMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIzqMenu.Click
        If pnlMenu.HorizontalScroll.Value > 0 AndAlso (pnlMenu.HorizontalScroll.Value - iAvanceMenu) >= pnlMenu.HorizontalScroll.Minimum Then
            pnlMenu.HorizontalScroll.Value -= iAvanceMenu
        Else
            pnlMenu.HorizontalScroll.Value = pnlMenu.HorizontalScroll.Minimum
        End If
    End Sub

    Private Sub btnDerMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDerMenu.Click
        If (pnlMenu.HorizontalScroll.Value + iAvanceMenu) <= pnlMenu.HorizontalScroll.Maximum Then
            pnlMenu.HorizontalScroll.Value += iAvanceMenu
        Else
            pnlMenu.HorizontalScroll.Value = pnlMenu.HorizontalScroll.Maximum
        End If
    End Sub

    Private Sub ObtenerResultado(ByVal FileImage As String, ByVal iEstado As Integer)

     
        Dim sIMGClave As String
        If iEstado = 1 Then
        sIMGClave = ModPOS.obtenerLlave
        Else
            sIMGClave = arrayFoto(indiceSelected).IMGClave
        End If

        Dim FileName As String = Application.StartupPath & "\Temp\" & sIMGClave & ".jpg"

        'Copia la imagen del archivo
        Try
            My.Computer.FileSystem.CopyFile(FileImage, FileName, True)
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try

      
        If iEstado = 1 Then
            arrayFoto(indice) = New Foto(sIMGClave)

            arrayFoto(indice).Nuevo = True
            arrayFoto(indice).SizeMode = PictureBoxSizeMode.StretchImage
            arrayFoto(indice).Width = 90
            arrayFoto(indice).Height = 60
            arrayFoto(indice).Location = New Point(ultimaX, 2)
            arrayFoto(indice).indice = indice

            arrayFoto(indice).Image = ModPOS.RecuperaImagen(FileName)
            arrayFoto(indice).NombreImagen = sIMGClave & ".jpg"
            PicProducto.SizeMode = PictureBoxSizeMode.Zoom
            PicProducto.Image = arrayFoto(indiceSelected).Image
         
            ultimaX += 95
            pnlMenu.Controls.Add(arrayFoto(indice))
            AddHandler arrayFoto(indice).Click, AddressOf Menu_Click
            indice += 1
            ReDim Preserve arrayFoto(indice)
        Else
            arrayFoto(indiceSelected).Estado = iEstado
            arrayFoto(indiceSelected).Image = RecuperaImagen(FileName)
            arrayFoto(indiceSelected).NombreImagen = sIMGClave & ".jpg"
            PicProducto.SizeMode = PictureBoxSizeMode.Zoom
            PicProducto.Image = arrayFoto(indiceSelected).Image
        End If



    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim curFileName As String = ""


        'buscamos la imagen a grabar
        Try
            Dim openDlg As OpenFileDialog = New OpenFileDialog
            openDlg.Filter = "Todos los archivos JPG|*.JPG"
            ' Dim filter As String = openDlg.Filter
            openDlg.Title = "Abrir un Archivo de Imágen"
            If (openDlg.ShowDialog() = DialogResult.OK) Then
                curFileName = openDlg.FileName
                ObtenerResultado(curFileName, 1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnRemover_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemover.Click
        Select Case MessageBox.Show("Se eliminara la imagen seleccionada", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            Case DialogResult.Yes
                arrayFoto(indiceSelected).Estado = 0
                arrayFoto(indiceSelected).Image = Nothing
                PicProducto.Image = Nothing
        End Select
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If arrayFoto(0) IsNot Nothing Then
            If ModPOS.Producto IsNot Nothing Then
                ModPOS.Producto.ActualizaImagenes(arrayFoto)

            End If
        End If
        Me.Close()
    End Sub

    Private Sub PicProducto_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PicProducto.DoubleClick
        If Padre = "Producto" Then
            Dim curFileName As String = ""
            'buscamos la imagen a grabar
            Try
                Dim openDlg As OpenFileDialog = New OpenFileDialog
                openDlg.Filter = "Todos los archivos de Imágen|*.JPG"
                ' Dim filter As String = openDlg.Filter
                openDlg.Title = "Abrir un Archivo de Imágen"
                If (openDlg.ShowDialog() = DialogResult.OK) Then
                    curFileName = openDlg.FileName

                    If PicProducto.Image Is Nothing Then
                        ObtenerResultado(curFileName, 1)

                    Else
                        ObtenerResultado(curFileName, 2)
                    End If


                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub FrmPicture_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        PicProducto.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub


   

    'Generate new image dimensions
    'Public Function GenerateImageDimensions(ByVal currW As Integer, ByVal currH As Integer, ByVal destW As Integer, ByVal destH As Integer) As Size
    '    'double to hold the final multiplier to use when scaling the image
    '    Dim multiplier As Double = 0

    '    'string for holding layout
    '    Dim layout As String

    '    'determine if it's Portrait or Landscape
    '    If currH > currW Then
    '        layout = "portrait"
    '    Else
    '        layout = "landscape"
    '    End If

    '    Select Case layout.ToLower()
    '        Case "portrait"
    '            'calculate multiplier on heights
    '            If destH > destW Then
    '                multiplier = CDbl(destW) / CDbl(currW)
    '            Else

    '                multiplier = CDbl(destH) / CDbl(currH)
    '            End If
    '            Exit Select
    '        Case "landscape"
    '            'calculate multiplier on widths
    '            If destH > destW Then
    '                multiplier = CDbl(destW) / CDbl(currW)
    '            Else

    '                multiplier = CDbl(destH) / CDbl(currH)
    '            End If
    '            Exit Select
    '    End Select

    '    'return the new image dimensions
    '    Return New Size(CInt((currW * multiplier)), CInt((currH * multiplier)))
    'End Function

    ''Resize the image
    'Private Sub SetImage(ByVal pb As PictureBox)
    '    Try
    '        'create a temp image

    '        'calculate the size of the image
    '        Dim imgSize As Size = GenerateImageDimensions(img.Width, img.Height, pb.Width, pb.Height)

    '        'create a new Bitmap with the proper dimensions
    '        Dim finalImg As New Bitmap(img, imgSize.Width, imgSize.Height)

    '        'create a new Graphics object from the image
    '        Dim gfx As Graphics = Graphics.FromImage(img)

    '        'clean up the image (take care of any image loss from resizing)
    '        gfx.InterpolationMode = Drawing2D.InterpolationMode.Bicubic 
    '        'empty the PictureBox
    '        pb.Image = Nothing

    '        'center the new image
    '        pb.SizeMode = PictureBoxSizeMode.CenterImage

    '        'set the new image
    '        pb.Image = finalImg
    '    Catch e As System.Exception
    '        MessageBox.Show(e.Message)
    '    End Try
    'End Sub



End Class
