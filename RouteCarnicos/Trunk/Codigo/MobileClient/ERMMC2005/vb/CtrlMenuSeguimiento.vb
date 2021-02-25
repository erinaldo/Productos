Imports System.IO
Imports System.Drawing

Public Class CtrlMenuSeguimiento
    Implements IDisposable

#Region "VARIABLES"
    Private iContador As Integer
    Private iCeldaInicial As Integer
    Private iCeldaSeleccionada As Integer
    Private iCeldaActual As Integer
    Private iCeldaAnterior As Integer
    Private bIniciando As Boolean
    Private bOcultado As Boolean
    Private bDobleClick As Boolean
    Private bTerminarVisita As Boolean
    Private bImproductividad As Boolean
    Private bMenuItemSeleccionado As Boolean
    Private bFueraSecuencia As Boolean
    Private sModuloMovDetalleClaveMenuItem As String
    Private Renglon As renglonSeguimiento
    Private cMOTConfiguracion As MOTConfiguracion
    Private hActividades As Hashtable
    Private LMenuItem As MenuItem
    Private bIncluido As Boolean = False
    Private bMasInfo As Boolean = False
#End Region

    Public Event NuevaSeleccion()
    Public Event TerminarVisitaMenu()

#Region "PROPIEDADES"
    Public ReadOnly Property Incluido()
        Get
            Return bIncluido
        End Get
    End Property

    Private ReadOnly Property AltoCtrl() As Integer
        Get
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
            Return 72 * nFactorH
#Else
            Return 36 * nFactorH
#End If




        End Get
    End Property

    Public ReadOnly Property NumCeldas() As Integer
        Get
            Return PicContenedor.Width / Me.PicContenedor.Height
        End Get
    End Property

    Public ReadOnly Property Ancho() As Integer
        Get
            Return Me.PicContenedor.Width / (PicContenedor.Width / Me.PicContenedor.Height)
        End Get
    End Property

    Public ReadOnly Property Alto() As Integer
        Get
            Return Me.PicContenedor.Height
        End Get
    End Property

    Public Property CeldaActual() As Integer
        Get
            Return Me.iCeldaActual
        End Get
        Set(ByVal value As Integer)
            Me.iCeldaActual = value
        End Set
    End Property

    Public Property TerminarVisita() As Boolean
        Get
            Return Me.bTerminarVisita
        End Get
        Set(ByVal value As Boolean)
            bTerminarVisita = value
        End Set
    End Property

    Public Property Improductividad() As Boolean
        Get
            Return bImproductividad
        End Get
        Set(ByVal value As Boolean)
            bImproductividad = value
        End Set
    End Property

    Public Property dobleclick() As Boolean
        Get
            Return bDobleClick
        End Get
        Set(ByVal value As Boolean)
            bDobleClick = value
        End Set
    End Property

    Public Property MOTConfiguracion() As MOTConfiguracion
        Get
            Return Me.cMOTConfiguracion
        End Get
        Set(ByVal value As MOTConfiguracion)
            Me.cMOTConfiguracion = value
        End Set
    End Property

    Public Property CeldaSeleccionada() As Integer
        Get
            Return Me.iCeldaSeleccionada
        End Get
        Set(ByVal value As Integer)
            Me.iCeldaSeleccionada = value
        End Set
    End Property

    Public Property celdaInicial() As Integer
        Get
            Return Me.iCeldaInicial
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then Exit Property
            If value >= Renglon.Celdas.Length Then Exit Property

            Me.iCeldaInicial = value

        End Set
    End Property

    Public Property contador() As Integer
        Get
            Return iContador
        End Get
        Set(ByVal value As Integer)
            iContador = value
        End Set
    End Property

    Public ReadOnly Property Indice() As Integer
        Get
            If Me.Renglon.Celdas Is Nothing Then Return 0

            Return Me.Renglon.Celdas.Length
        End Get
    End Property

    Public Property MenuItemSeleccionado() As Boolean
        Get
            Return Me.bMenuItemSeleccionado
        End Get
        Set(ByVal value As Boolean)
            Me.bMenuItemSeleccionado = value
        End Set
    End Property

    Public Property ModuloMovDetalleClaveMenuItem() As String
        Get
            Return Me.sModuloMovDetalleClaveMenuItem
        End Get
        Set(ByVal value As String)
            Me.sModuloMovDetalleClaveMenuItem = value
        End Set
    End Property

    Public Property FueraSecuencia() As Boolean
        Get
            Return Me.bFueraSecuencia
        End Get
        Set(ByVal value As Boolean)
            Me.bFueraSecuencia = value
        End Set
    End Property

    Public Property MasInfo() As Boolean
        Get
            Return bMasInfo
        End Get
        Set(ByVal value As Boolean)
            bMasInfo = value
        End Set
    End Property

#End Region

#Region "EVENTOS"
    Private Sub MenuPresionado(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MenuItemSeleccionado = True
        Me.bFueraSecuencia = True
        Me.bDobleClick = False
        Me.TerminarVisita = False
        Me.MasInfo = False

        Me.ModuloMovDetalleClaveMenuItem = CType(Me.hActividades.Item(CType(sender, MenuItem).Text), ArrayList).Item(0)

        RaiseEvent TerminarVisitaMenu()
    End Sub

    Private Sub TerminarVisitaMenuItem(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.TerminarVisita = True
        Me.MenuItemSeleccionado = False
        Me.bDobleClick = False
        Me.MasInfo = False

        RaiseEvent TerminarVisitaMenu()
    End Sub

    Private Sub MasInfoMenuItem(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.MenuItemSeleccionado = True
        Me.bFueraSecuencia = True
        Me.bDobleClick = False
        Me.TerminarVisita = False
        Me.MasInfo = True

        RaiseEvent TerminarVisitaMenu()
    End Sub
#End Region

#Region "FUNCIONES"
    Private Sub QuitarEventosMenuItem()

        Dim cantMenu As Integer = LMenuItem.MenuItems.Count - 1
        For x As Integer = 0 To cantMenu

            Dim MIModulo As MenuItem = LMenuItem.MenuItems(cantMenu - x)
            If MIModulo.Text = "Terminar Visita" Then
                RemoveHandler MIModulo.Click, AddressOf TerminarVisitaMenuItem
                LMenuItem.MenuItems.Remove(MIModulo)
                MIModulo.Dispose()
                MIModulo = Nothing

            ElseIf MIModulo.Text = "Más Info" Then
                RemoveHandler MIModulo.Click, AddressOf MasInfoMenuItem
                LMenuItem.MenuItems.Remove(MIModulo)
                MIModulo.Dispose()
                MIModulo = Nothing

            ElseIf MIModulo.Text = "-" Then
                MIModulo.Dispose()
                MIModulo = Nothing

            Else
                Dim cantModulos As Integer = MIModulo.MenuItems.Count - 1
                For i As Integer = 0 To cantModulos

                    Dim MIActividad As System.Windows.Forms.MenuItem
                    MIActividad = MIModulo.MenuItems(cantModulos - i)
                    RemoveHandler MIActividad.Click, AddressOf MenuPresionado
                    MIModulo.MenuItems.Remove(MIActividad)
                    MIActividad.Dispose()
                    MIActividad = Nothing

                Next

                LMenuItem.MenuItems.Remove(MIModulo)
                MIModulo.Dispose()
                MIModulo = Nothing
                cantModulos = Nothing

            End If
        Next

    End Sub

    Public Sub QuitarMenuItem(ByRef parMenuItem As MainMenu)
        TimerOcultar.Enabled = False
        TimerToolTip.Enabled = False

        parMenuItem.MenuItems.Remove(LMenuItem)
        bIncluido = False
    End Sub

    Public Sub CrearMenuItem(ByRef parMenuItem As MainMenu)
        For Each MI As MenuItem In LMenuItem.MenuItems
            Select Case MI.Text
                Case "Terminar Visita"
                    If ctrlSeguimiento.MostrarTerminar Then
                        MI.Enabled = True
                    Else
                        MI.Enabled = False
                    End If
                Case "Más Info", "-"
                Case Else
                    If MOTConfiguracion.SecuenciaObligatoria = False Or Me.cicloTerminado = True Then
                        MI.Enabled = True
                    Else
                        MI.Enabled = False
                    End If
            End Select
        Next

        parMenuItem.MenuItems.Add(LMenuItem)
        [Global].HabilitarMenuItem(parMenuItem, False)
        bIncluido = True
    End Sub

    Private Sub CrearMenuItem()
        Dim _Menu As New MenuOpciones

        Me.LMenuItem = New System.Windows.Forms.MenuItem
        LMenuItem.Text = "Menu"

        Dim MenuItemTerminar As New System.Windows.Forms.MenuItem
        MenuItemTerminar.Text = "Terminar Visita"
        LMenuItem.MenuItems.Add(MenuItemTerminar)
        AddHandler MenuItemTerminar.Click, AddressOf TerminarVisitaMenuItem

        Dim MenuItemBarra As New System.Windows.Forms.MenuItem
        MenuItemBarra.Text = "-"
        LMenuItem.MenuItems.Add(MenuItemBarra)

        Dim MenuItemInfo As New System.Windows.Forms.MenuItem
        MenuItemInfo.Text = "Más Info"
        LMenuItem.MenuItems.Add(MenuItemInfo)
        AddHandler MenuItemInfo.Click, AddressOf MasInfoMenuItem

        Dim MenuItemBarra2 As New System.Windows.Forms.MenuItem
        MenuItemBarra2.Text = "-"
        LMenuItem.MenuItems.Add(MenuItemBarra2)

        'If MOTConfiguracion.SecuenciaObligatoria = False Then
        For Each NombreModulo As String In _Menu.NombresModulos
            Dim MenuModulo As New System.Windows.Forms.MenuItem
            MenuModulo.Text = NombreModulo
            LMenuItem.MenuItems.Add(MenuModulo)

            For Each nombreActividad As String In _Menu.coleccionNombresxModulo(NombreModulo)
                Dim menuItemActividad As New MenuItem
                menuItemActividad.Text = nombreActividad
                MenuModulo.MenuItems.Add(menuItemActividad)

                AddHandler menuItemActividad.Click, AddressOf MenuPresionado

                menuItemActividad.Dispose()
                menuItemActividad = Nothing
            Next

            MenuModulo.Dispose()
            MenuModulo = Nothing
        Next
        'End If

        hActividades = _Menu.HahsActividades.Clone

        MenuItemTerminar.Dispose()
        MenuItemTerminar = Nothing
        MenuItemBarra.Dispose()
        MenuItemBarra = Nothing
        MenuItemBarra2.Dispose()
        MenuItemBarra2 = Nothing
        _Menu.Dispose()
        _Menu = Nothing
    End Sub

    Private Sub DibujaFlecha(ByVal pvPic As PictureBox, ByVal pvColor As Color, ByVal pvImg As Image)
        Dim G As Graphics
        G = Graphics.FromImage(pvPic.Image)
        G.Clear(pvColor)

        Using sb As New System.Drawing.SolidBrush(pvColor)
            G.FillRectangle(sb, 0, 0, 30, AltoCtrl)
        End Using

        Dim imageAttr As Imaging.ImageAttributes = New Imaging.ImageAttributes()
        Dim bmp As Bitmap = New Bitmap(pvImg)
        imageAttr.SetColorKey(bmp.GetPixel(0, 0), bmp.GetPixel(0, 0))

        'G.DrawImage(pvImg, New Rectangle(((pvPic.Width - 16) / 2), ((AltoCtrl - 16) / 2), 16 * nFactorH, 16 * nFactorH), 0, 0, 16, 16, GraphicsUnit.Pixel, imageAttr)
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
        pvPic.SizeMode = PictureBoxSizeMode.StretchImage
        G.DrawImage(pvImg, New Rectangle(12 * nFactorImg, 18 * nFactorImg, 32 * nFactorH, 32 * nFactorH), 0, 0, 32, 32, GraphicsUnit.Pixel, imageAttr)
#Else
G.DrawImage(pvImg, New Rectangle(6 * nFactorImg, 9 * nFactorImg, 16 * nFactorH, 16 * nFactorH), 0, 0, 16, 16, GraphicsUnit.Pixel, imageAttr)
#End If


        pvPic.Refresh()
        G.Dispose()
        G = Nothing
        imageAttr = Nothing
        bmp.Dispose()
        bmp = Nothing
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.PicContenedor.Image = New Bitmap(Me.Width, Me.Height)

        Me.PicIzq.Image = New Bitmap(Me.PicIzq.Width, Me.PicIzq.Height)
        DibujaFlecha(Me.PicIzq, System.Drawing.SystemColors.Control, CType(htImagenes("BT1"), System.Drawing.Bitmap))
        Me.PicDer.Image = New Bitmap(Me.PicDer.Width, Me.PicDer.Height)
        DibujaFlecha(Me.PicDer, System.Drawing.SystemColors.Control, CType(htImagenes("BT2"), System.Drawing.Bitmap))

        Me.PicOcultar.Image = New Bitmap(Me.Width, Me.Height)
        Me.bOcultado = True
    End Sub

    Public Sub Iniciar()
        TimerOcultar.Enabled = True
        Me.Height = AltoCtrl
        Me.PicDer.Visible = True
        Me.PicIzq.Visible = True
        Me.PicContenedor.Visible = True
        Me.PicOcultar.Visible = False

        Me.bOcultado = False
        Me.dobleclick = False
        Me.TerminarVisita = False
        Me.MenuItemSeleccionado = False
        Me.Improductividad = False

        Me.contador = 5
        ctrlSeguimiento.Location = New System.Drawing.Point(3, Me.Location.Y)
        ctrlSeguimiento.Size = New System.Drawing.Size((Me.Width * nFactorW) - 2, Me.Height * nFactorH)
        TimerOcultar_Tick(Nothing, Nothing)
    End Sub

    Public Sub CargarImagenes(ByVal parNemonicoImagen As String)
        Dim iIndex As Integer

        Dim dt As DataTable = oDBVen.RealizarConsultaSQL("SELECT MM.ModuloMovDetalleClave, MM.nombreActividad as nombre, MM.TipoIndice FROM MOTConfiguracion " & _
        "INNER JOIN MmdMcn MM ON MOTConfiguracion.MCNClave = MM.MCNClave " & _
        "where (MM.secuencia <> 0) and MOTConfiguracion.MCNClave = '" & oVendedor.MCNClave & "' order by MM.Secuencia", "Vendedor")

        Renglon = New renglonSeguimiento(0)
        For iIndex = 0 To dt.Rows.Count - 1
            Dim celda As New CeldaSeguimiento

            If Not IsNothing(htImagenes(parNemonicoImagen & dt.Rows(iIndex).Item("TipoIndice"))) Then 'Si existe la imagen
                celda.Celda.Imagen = CType(htImagenes(parNemonicoImagen & dt.Rows(iIndex).Item("TipoIndice")), System.Drawing.Bitmap).Clone
            ElseIf dt.Rows(iIndex).Item("TipoIndice") = 21 AndAlso Not IsNothing(htImagenes(parNemonicoImagen & "7")) Then 'Si es cobranza poner imagen de cuentas por cobrar indice 7
                celda.Celda.Imagen = CType(htImagenes(parNemonicoImagen & "7"), System.Drawing.Bitmap).Clone
            Else
                celda.Celda.Imagen = CType(htImagenes("MG0"), System.Drawing.Bitmap).Clone
            End If

            celda.ModuloMovDetalleClave = dt.Rows(iIndex).Item("ModuloMovDetalleClave")
            celda.Nombre = dt.Rows(iIndex).Item("Nombre")
            celda.Celda.IndiceCol = iIndex
            celda.Celda.IndiceRen = 1

            If iIndex = 0 Then
                celda.Celda.Activo = True
            Else
                celda.Celda.Activo = False
            End If

            celda.Celda.Tamaño = New Size(Alto, Alto)
            Renglon.AddCelda(celda)
        Next

        dt.Dispose()
        dt = Nothing
        iIndex = Nothing

        'celdaInicial = 0
        'CeldaSeleccionada = 0
        'iCeldaActual = 0

        CrearMenuItem()
    End Sub

    Private Sub Dibujar(ByRef pic As PictureBox)
        pic.Refresh()

    End Sub

    Private Sub Dibuja(ByVal lienzo As Graphics)

        If Me.celdaInicial >= Me.Renglon.Celdas.Length Then Exit Sub
        lienzo.Clear(System.Drawing.SystemColors.Control)
        Dim x As Integer = 0
        Dim y As Integer = 0

        Using sb As New System.Drawing.SolidBrush(System.Drawing.SystemColors.Control)
            lienzo.FillRectangle(sb, 0, 0, Ancho, Alto)
        End Using

        For Each lc As CeldaSeguimiento In Renglon.Celdas
            lc.Celda.Activo = False
        Next

        Dim imageAttr As Imaging.ImageAttributes = New Imaging.ImageAttributes()
        For cont As Integer = Me.celdaInicial To (NumCeldas + celdaInicial)
            If cont < Renglon.Celdas.Length Then

                Dim celda As CeldaSeguimiento = Renglon.Celdas(cont)
                Dim bmp As Bitmap = New Bitmap(celda.Celda.Imagen)
                imageAttr.SetColorKey(bmp.GetPixel(0, 0), bmp.GetPixel(0, 0))

                Dim lcoorX, lcoorY As Integer
                If cont = CeldaSeleccionada Then
                    lcoorX = x
                    lcoorY = 0
                    celda.Celda.Posicion = New Point(lcoorX, lcoorY)
                    celda.Celda.Activo = True
                    'Using oPen As New Drawing.Pen(Color.DarkGray, 2)
                    '    lienzo.DrawRectangle(oPen, lcoorX, lcoorY, Me.Ancho - 3, Alto - 3)
                    'End Using
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
                    lienzo.DrawImage(celda.Celda.Imagen, New Rectangle(celda.Celda.Posicion.X * nFactorW + 15, celda.Celda.Posicion.Y * nFactorH + 15, Ancho / 1.5, Alto / 1.5), 0, 0, 72, 72, GraphicsUnit.Pixel, imageAttr)
                    'lienzo.DrawImage(celda.Celda.Imagen, New Rectangle(celda.Celda.Posicion.X * nFactorW, celda.Celda.Posicion.Y * nFactorH, Ancho, Alto), 0, 0, 72, 72, GraphicsUnit.Pixel, imageAttr)
#Else
                    lienzo.DrawImage(celda.Celda.Imagen, New Rectangle(celda.Celda.Posicion.X * nFactorW, celda.Celda.Posicion.Y * nFactorH, Ancho, Alto), 0, 0, 72, 72, GraphicsUnit.Pixel, imageAttr)
#End If

                Else
                    lcoorX = x + (Ancho / 2) - (Alto / 3)
                    lcoorY = (Alto / 2) - (Alto / 3)
                    celda.Celda.Posicion = New Point(lcoorX, lcoorY)
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
                    lienzo.DrawImage(celda.Celda.Imagen, New Rectangle(celda.Celda.Posicion.X * nFactorW + 15, celda.Celda.Posicion.Y * nFactorH + 15, Ancho / 1.5 - 12, Alto / 1.5 - 12), 0, 0, 72, 72, GraphicsUnit.Pixel, imageAttr)
                    'lienzo.DrawImage(celda.Celda.Imagen, New Rectangle(celda.Celda.Posicion.X * nFactorW, celda.Celda.Posicion.Y * nFactorH, Ancho - 24, Alto - 24), 0, 0, 72, 72, GraphicsUnit.Pixel, imageAttr)
#Else
                    lienzo.DrawImage(celda.Celda.Imagen, New Rectangle(celda.Celda.Posicion.X * nFactorW, celda.Celda.Posicion.Y * nFactorH, Ancho - 12, Alto - 12), 0, 0, 72, 72, GraphicsUnit.Pixel, imageAttr)
#End If

                End If

                x += Ancho
                lcoorX = Nothing
                lcoorY = Nothing
                bmp.Dispose()
                bmp = Nothing
            End If
        Next

        imageAttr = Nothing
        x = Nothing
        y = Nothing

    End Sub

    Public Function ModuloMovDetalleClaveSiguiente() As String
        If Me.CeldaSeleccionada < 0 Then Return Nothing
        If Me.CeldaSeleccionada + 1 >= Me.Renglon.Celdas.Length Then Return Nothing

        Return Me.Renglon.Celdas((Me.CeldaSeleccionada + 1)).ModuloMovDetalleClave
    End Function

    Public Function ModuloMovDetalleClaveAnterior() As String
        If Me.CeldaSeleccionada < 0 Then Return Nothing
        If Me.CeldaSeleccionada - 1 > Me.Renglon.Celdas.Length Then Return Nothing

        Return Me.Renglon.Celdas((Me.CeldaSeleccionada - 1)).ModuloMovDetalleClave
    End Function

    Public Function ModuloMovDetalleClaveActual() As String
        If Me.CeldaSeleccionada < 0 Then Return Nothing
        If MenuItemSeleccionado Then Return Nothing
        If Me.CeldaSeleccionada >= Me.Renglon.Celdas.Length Then Return Nothing

        Return Me.Renglon.Celdas(Me.CeldaSeleccionada).ModuloMovDetalleClave
    End Function

    Public Function MostrarTerminar() As Boolean

        If Me.MOTConfiguracion.SecuenciaObligatoria Then
            If Me.MOTConfiguracion.TerminarSecuencia Then
                Return True
            ElseIf Me.ModuloMovDetalleClaveSiguiente Is Nothing Then
                Return True
            ElseIf cicloTerminado Then
                Return True
            End If
        Else
            Return True

        End If

        Return False
    End Function

    Public Sub AgregarControl(ByRef pvForma As Form)
        Dim posicion As Integer
        If Posicionar(pvForma.Controls, posicion) Then
            ctrlSeguimiento.Dock = DockStyle.None
            ctrlSeguimiento.Location = New System.Drawing.Point(2, posicion)
        Else
            ctrlSeguimiento.Dock = DockStyle.Top
        End If

        ctrlSeguimiento.Size = New System.Drawing.Size(pvForma.Width, 36)
        pvForma.Controls.Add(ctrlSeguimiento)
        ctrlSeguimiento.BringToFront()
        ctrlSeguimiento.Show()
        ctrlSeguimiento.realizada = True
    End Sub

    Public Property realizada() As Boolean
        Get
            If Me.CeldaActual < 0 Then Return True

            For i As Integer = 0 To Me.Renglon.Celdas.Length - 1
                If i = Me.CeldaActual Then
                    Return Me.Renglon.Celdas(i).realizada
                End If
            Next

            Return True
        End Get
        Set(ByVal value As Boolean)
            If Me.CeldaActual < 0 Then Exit Property

            For i As Integer = 0 To Me.Renglon.Celdas.Length - 1
                If i = Me.CeldaActual Then
                    Me.Renglon.Celdas(i).realizada = value
                    Exit For
                End If
            Next
        End Set
    End Property

    Public Property cicloTerminado() As Boolean
        Get
            For i As Integer = 0 To Me.Renglon.Celdas.Length - 1
                If Me.Renglon.Celdas(i).realizada = False Then
                    Return False
                End If
            Next
            Return True
        End Get
        Set(ByVal value As Boolean)
            For i As Integer = 0 To Me.Renglon.Celdas.Length - 1
                Me.Renglon.Celdas(i).realizada = value
            Next
        End Set
    End Property

    Private Sub Escribir(ByVal pic As PictureBox, ByVal pvTexto As String)
        Try
            Dim grafico As Graphics

            grafico = Graphics.FromImage(pic.Image)
            grafico.Clear(System.Drawing.SystemColors.Control)
            Dim tam As Single = 10 * nFactorH
            Dim miFont As New System.Drawing.Font("Tahoma", tam, System.Drawing.FontStyle.Bold)
            Dim pincel As New SolidBrush(Color.Black)
            Dim textoSize As SizeF = grafico.MeasureString(pvTexto, miFont)

            grafico.DrawString(pvTexto, miFont, pincel, (pic.Width - textoSize.Width) / 2, 0)

            If bOcultado Then
                Dim img As Image = CType(htImagenes("BT3"), System.Drawing.Bitmap).Clone
                Dim bmp As Bitmap = New Bitmap(img)

                Using sb As New System.Drawing.SolidBrush(System.Drawing.SystemColors.Control)
                    grafico.FillRectangle(sb, 0, 0, Me.PicOcultar.Height, Me.PicOcultar.Width)
                End Using

                Dim imageAttr As Imaging.ImageAttributes = New Imaging.ImageAttributes()
                imageAttr.SetColorKey(bmp.GetPixel(0, 0), bmp.GetPixel(0, 0))
                grafico.DrawImage(img, New Rectangle(Me.PicOcultar.Width - 15, 0, 8 * nFactorH, 9 * nFactorH), 0, 0, 8, 9, GraphicsUnit.Pixel, imageAttr)

                img.Dispose()
                img = Nothing
                bmp.Dispose()
                bmp = Nothing
                imageAttr = Nothing
            End If

            pic.Refresh()
            grafico.Dispose()
            grafico = Nothing
            miFont.Dispose()
            miFont = Nothing
            pincel.Dispose()
            pincel = Nothing
            textoSize = Nothing
            tam = Nothing



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private ReadOnly Property VentaImproductiva(ByVal pvModuloMovDetalle As String) As Boolean
        Get
            If Me.Improductividad Then
                Dim lModuloMovDetActual As New Modulos.GrupoModuloMovDetalle
                lModuloMovDetActual.Recuperar(pvModuloMovDetalle)
                Select Case lModuloMovDetActual.TipoModuloMovDetalle
                    Case ServicesCentral.TiposModulosMovDet.Pedido
                        Return True
                End Select
            End If

            Return False
        End Get
    End Property

#End Region

#Region "BOTONES"

    Private Sub PicContenedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PicContenedor.Click
        If Fix(Control.MousePosition.X / AltoCtrl) - 1 + Me.celdaInicial >= Renglon.Celdas.Length Then Exit Sub

        Me.PicOcultar.Dock = DockStyle.Top
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
        Me.PicOcultar.Height = 32 * nFactorH
#Else
Me.PicOcultar.Height = 16 * nFactorH
#End If


        For i As Integer = 0 To Me.Renglon.Celdas.Length - 1
            If i = Fix(Control.MousePosition.X / AltoCtrl) - 1 + Me.celdaInicial Then
                Escribir(Me.PicOcultar, Me.Renglon.Celdas(i).Nombre)
                Exit For
            End If
        Next

        Me.PicOcultar.Visible = True
        Me.TimerToolTip.Enabled = True
    End Sub

    Private Sub PicContenedor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PicContenedor.DoubleClick
        Me.contador = 0
        Me.PicOcultar.Visible = False

        If Fix(Control.MousePosition.X / Alto) - 1 + Me.celdaInicial >= Renglon.Celdas.Length Then Exit Sub

        If Not CType(Renglon.Celdas(Fix(Control.MousePosition.X / AltoCtrl) - 1 + Me.celdaInicial), CeldaSeguimiento).realizada Then
            If (Fix(Control.MousePosition.X / AltoCtrl) + Me.celdaInicial) - 1 = Me.CeldaActual Then Exit Sub
            If MOTConfiguracion.SecuenciaObligatoria Then
                If (Fix(Control.MousePosition.X / AltoCtrl) + Me.celdaInicial) - 1 > (Me.CeldaActual + 1) Then
                    Exit Sub
                End If
            End If
        End If

        bDobleClick = True
        Me.MenuItemSeleccionado = False
        Me.TerminarVisita = False
        Me.iCeldaActual = Me.CeldaSeleccionada

        RaiseEvent NuevaSeleccion()
    End Sub

    Private Sub PicContenedor_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicContenedor.MouseUp
        Me.contador = 0

        If Fix(e.X / AltoCtrl) + Me.celdaInicial >= Renglon.Celdas.Length Then Exit Sub
        'If VentaImproductiva(CType(renglon.Celdas(Fix(Control.MousePosition.X / AltoCtrl) - 1 + Me.celdaInicial), CeldaSeguimiento).ModuloMovDetalleClave) Then Exit Sub

        If Not CType(Renglon.Celdas(Fix(e.X / AltoCtrl) + Me.celdaInicial), CeldaSeguimiento).realizada Then
            If (Fix(e.X / AltoCtrl) + Me.celdaInicial) <> Me.CeldaActual Then
                If MOTConfiguracion.SecuenciaObligatoria Then
                    If (Fix(e.X / AltoCtrl) + Me.celdaInicial) > (Me.CeldaActual + 1) Then
                        Exit Sub
                    End If
                End If
            End If
        End If

        CeldaSeleccionada = Fix(e.X / AltoCtrl) + Me.celdaInicial
        Dibujar(Me.PicContenedor)
    End Sub

    Private Sub Pic_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicIzq.MouseDown, PicDer.MouseDown
        'CType(sender, PictureBox).BackColor = Color.Silver
        Me.contador = 0
        Dim LImagen As Image
        If CType(sender, PictureBox).Name = "PicIzq" Then
            LImagen = CType(htImagenes("BT1"), System.Drawing.Bitmap).Clone
        Else
            LImagen = CType(htImagenes("BT2"), System.Drawing.Bitmap).Clone
        End If

        DibujaFlecha(CType(sender, PictureBox), Color.DarkGray, LImagen)
        LImagen.Dispose()
        LImagen = Nothing
    End Sub

    Private Sub Pic_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicIzq.MouseUp, PicDer.MouseUp
        Dim LImagen As Image
        If CType(sender, PictureBox).Name = "PicIzq" Then
            LImagen = CType(htImagenes("BT1"), System.Drawing.Bitmap).Clone
            If Me.celdaInicial > 0 Then Me.celdaInicial -= 1
        Else
            LImagen = CType(htImagenes("BT2"), System.Drawing.Bitmap).Clone
            If Me.celdaInicial < Me.Renglon.Celdas.Length - 1 Then Me.celdaInicial += 1
        End If
        DibujaFlecha(CType(sender, PictureBox), System.Drawing.SystemColors.Control, LImagen)

        Me.contador = 0
        Dibujar(Me.PicContenedor)

        LImagen.Dispose()
        LImagen = Nothing
    End Sub

    Private Sub PicOcultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PicOcultar.Click
        If Me.bOcultado = False Then Exit Sub

        Me.PicDer.Visible = True
        Me.PicIzq.Visible = True
        Me.PicContenedor.Visible = True
        Me.PicOcultar.Visible = False
        Me.Height = AltoCtrl
        bOcultado = False
        contador = 0
        Me.celdaInicial = Me.CeldaActual
        Me.CeldaSeleccionada = Me.CeldaActual

        Dibujar(Me.PicContenedor)
        Me.TimerToolTip.Enabled = True
    End Sub

#End Region

    Private Sub TimerOcultar_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerOcultar.Tick
        If bOcultado = True Then Exit Sub

        contador += 1
        If contador > 3 Then
            bOcultado = True

#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
            Me.Height = 32 * nFactorH
#Else
            Me.Height = 16 * nFactorH
#End If

            Me.PicDer.Visible = False
            Me.PicIzq.Visible = False
            Me.PicContenedor.Visible = False
            Me.PicOcultar.Dock = DockStyle.Fill
            Me.PicOcultar.Visible = True
            Escribir(Me.PicOcultar, sNombreActividad)
        End If
    End Sub

    Public Sub RefrescaEscribe()
        Escribir(Me.PicOcultar, sNombreActividad)
    End Sub

#Region "CLASES"

    Private Class CeldaSeguimiento
        Implements IDisposable

        Private _Celda As CtrlMenuImagen.Celda
        Private _ModuloMovDetalleClave As String
        Private _Nombre As String
        Private _realizada As Boolean

        Sub New()
            _Celda = New CtrlMenuImagen.Celda
        End Sub

        Public Property Celda() As CtrlMenuImagen.Celda
            Get
                Return _Celda
            End Get
            Set(ByVal value As CtrlMenuImagen.Celda)
                Me._Celda = value
            End Set
        End Property

        Public Property ModuloMovDetalleClave() As String
            Get
                Return Me._ModuloMovDetalleClave
            End Get
            Set(ByVal value As String)
                Me._ModuloMovDetalleClave = value
            End Set
        End Property

        Public Property Nombre() As String
            Get
                Return Me._Nombre
            End Get
            Set(ByVal value As String)
                Me._Nombre = value
            End Set
        End Property

        Public Property realizada() As Boolean
            Get
                Return _realizada
            End Get
            Set(ByVal value As Boolean)
                _realizada = value
            End Set
        End Property


        Private disposedValue As Boolean = False        ' Para detectar llamadas redundantes

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: Liberar recursos no administrados cuando se llamen explícitamente
                    _Celda.Dispose()
                    _Celda = Nothing
                    Me._ModuloMovDetalleClave = Nothing
                    Me._Nombre = Nothing
                    _realizada = Nothing

                End If

                ' TODO: Liberar recursos no administrados compartidos

            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' Visual Basic agregó este código para implementar correctamente el modelo descartable.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' No cambie este código. Coloque el código de limpieza en Dispose (ByVal que se dispone como Boolean).
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    Private Class renglonSeguimiento
        Implements IDisposable

        Private _CeldasRenglon As CeldaSeguimiento() 'System.Collections.Generic.List(Of CeldaSeguimiento)
        Private _indiceRenglon As Integer

        Public Property Celdas() As CeldaSeguimiento()
            Get
                Return _CeldasRenglon
            End Get
            Set(ByVal Value As CeldaSeguimiento())
                _CeldasRenglon = Value
            End Set
        End Property

        Public Property Celdas(ByVal index As Integer) As CeldaSeguimiento
            Get
                Return _CeldasRenglon(index)
            End Get
            Set(ByVal Value As CeldaSeguimiento)
                _CeldasRenglon(index) = Value
            End Set
        End Property

        Public Sub New(ByVal pIndiceRenglon As Integer)
            _indiceRenglon = pIndiceRenglon
        End Sub

        Public Sub AddCelda(ByVal pCelda As CeldaSeguimiento)
            Dim i As Integer

            If _CeldasRenglon Is Nothing Then
                i = 0
                ReDim _CeldasRenglon(0)
            Else
                i = _CeldasRenglon.Length
                ReDim Preserve _CeldasRenglon(i)
            End If
            pCelda.Celda.Posicion = New Point((i * pCelda.Celda.Tamaño.Width), (_indiceRenglon * pCelda.Celda.Tamaño.Height))
            'pCelda.Celda.control.BackColor = _colorFondo
            _CeldasRenglon(i) = pCelda
        End Sub

        Private disposedValue As Boolean = False        ' Para detectar llamadas redundantes

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: Liberar recursos no administrados cuando se llamen explícitamente
                    For Each c As CeldaSeguimiento In _CeldasRenglon
                        c.Dispose()
                        c = Nothing
                    Next

                    Me._CeldasRenglon = Nothing
                    _indiceRenglon = Nothing
                End If

                ' TODO: Liberar recursos no administrados compartidos

            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' Visual Basic agregó este código para implementar correctamente el modelo descartable.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' No cambie este código. Coloque el código de limpieza en Dispose (ByVal que se dispone como Boolean).
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    Private Class MenuOpciones
        Implements IDisposable

        Private hashActividades As Hashtable
        Private hashModulos As Hashtable

        Public ReadOnly Property HahsActividades() As Hashtable
            Get
                Return hashActividades
            End Get
        End Property

        Public ReadOnly Property ExisteActividad(ByVal pvValor As String) As Boolean
            Get
                Return Me.hashActividades.ContainsKey(pvValor)
            End Get
        End Property

        Public ReadOnly Property ExisteModulo(ByVal pvValor As String) As Boolean
            Get
                Return Me.hashModulos.ContainsKey(pvValor)
            End Get
        End Property

        Public ReadOnly Property ModuloMovDetalleClave(ByVal nombre As String) As String
            Get
                Return CType(hashActividades.Item(nombre), ArrayList).Item(0).ToString
            End Get
        End Property

        Public ReadOnly Property NombresActividadesColeccion() As ArrayList
            Get
                Dim coleccion As New ArrayList

                For Each nombre As String In hashActividades.Keys
                    coleccion.Add(nombre)
                Next

                Return coleccion
            End Get
        End Property

        Public ReadOnly Property NombresModulos() As ArrayList
            Get
                Dim coleccion As New ArrayList

                For Each nombre As String In Me.hashModulos.Keys
                    coleccion.Add(nombre)
                Next

                Return coleccion
            End Get
        End Property

        Public ReadOnly Property coleccionNombresxModulo(ByVal pvNombreModulo As String) As ArrayList
            Get
                Return Me.hashModulos.Item(pvNombreModulo)
            End Get
        End Property

        Sub New()
            CargarMenuOpciones()

        End Sub

        Private Sub CargarMenuOpciones()
            Dim dt As DataTable = oDBVen.RealizarConsultaSQL("select mmd.modulomovdetalleclave,mmd.nombre as nombreActividad,mmd.tipoindice, mv.nombre as nombreModulo " & _
            "from modulomovdetalle mmd inner join modulomov mv on mv.modulomovclave = mmd.modulomovclave " & _
            "inner join vendedor v on v.moduloclave = mv.moduloclave " & _
            "inner join mmdmcn mm on mmd.modulomovdetalleclave = mm.modulomovdetalleclave order by secuencia,mv.orden,mmd.orden", "MenuOpciones")

            hashActividades = New Hashtable
            hashModulos = New Hashtable

            For Each row As DataRow In dt.Rows
                Dim contenido As New ArrayList
                contenido.Add(row("modulomovdetalleclave"))
                contenido.Add(row("nombreActividad"))
                contenido.Add(row("tipoindice"))
                contenido.Add(row("nombreModulo"))

                hashActividades.Add(row("nombreActividad"), contenido)

                If hashModulos.ContainsKey(row("nombreModulo")) Then
                    Dim lColeccion As ArrayList = hashModulos.Item(row("nombreModulo"))
                    lColeccion.Add(row("nombreActividad"))
                    lColeccion = Nothing
                Else
                    Dim lColeccion As New ArrayList
                    lColeccion.Add(row("nombreActividad"))
                    hashModulos.Add(row("nombreModulo"), lColeccion)
                    lColeccion = Nothing
                End If

                contenido = Nothing
            Next

            dt.Dispose()
            dt = Nothing

        End Sub



        Private disposedValue As Boolean = False        ' Para detectar llamadas redundantes

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: Liberar recursos no administrados cuando se llamen explícitamente
                    hashActividades = Nothing
                    hashModulos = Nothing
                End If

                ' TODO: Liberar recursos no administrados compartidos

            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' Visual Basic agregó este código para implementar correctamente el modelo descartable.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' No cambie este código. Coloque el código de limpieza en Dispose (ByVal que se dispone como Boolean).
            hashActividades = Nothing
            hashModulos = Nothing

            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

#End Region

    Protected Overrides Sub Finalize()

        MyBase.Finalize()
    End Sub

    Private Sub TimerToolTip_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerToolTip.Tick
        Me.PicOcultar.Visible = False
        Me.TimerToolTip.Enabled = False
    End Sub

    Private Sub PicContenedor_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PicContenedor.Paint
        Dibuja(e.Graphics)
    End Sub
End Class
