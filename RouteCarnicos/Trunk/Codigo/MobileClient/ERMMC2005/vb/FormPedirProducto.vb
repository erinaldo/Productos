Imports System.Data.SqlServerCe

Public Class FormPedirProducto
    Inherits System.Windows.Forms.Form

#Region "Constantes"
    Private Const ConstPosTabPageUnidades = 0
    Private Const ConstPosTabPageConsultas = 1

    Private Const ConstPosClaveProductoLista = 0
    Private Const ConstPosIdProductoLista = 1
#End Region

#Region "Variables"
    Private tOpcionCapturaActual As tOpcionCaptura = tOpcionCaptura.GuardarDetalle

    Protected bPermitirConsultarProductos As Boolean
    Protected bMostrarExistencia As Boolean = False
    Protected bExistenciaSugerida As Boolean = False

    'Protected restbProductoError As RescoItemNumeric
    Protected bCargandoArbol As Boolean = False
    Protected sTransProdId As String
    Protected sTransProdIDs As String
    Protected sFiltroProductos As String
    Protected sFiltroProductosIncluyeTabla As String
    Protected sFiltroEsquema As String
    Protected iPartida As Integer
    Protected sFolioActual As String
    Protected sVisitaActual As String
    Protected oCliente As Cliente
    Protected oModuloMovDet As Modulos.GrupoModuloMovDetalle
    Protected oListasPrecios As ListasPreciosCliente
    Protected oProducto As Producto
    Protected tTipoTransProd As ServicesCentral.TiposTransProd
    Protected tTipoMovimiento As ServicesCentral.TiposMovimientos
    Protected tTipoVerificacionInventario As Inventario.TiposVerificacionInventario = Inventario.TiposVerificacionInventario.NoVerificar
    Protected sEsquemasID As String = String.Empty
    Protected tTipoIndice As ServicesCentral.TiposModulos = ServicesCentral.TiposModulos.NoDefinido
    Protected oImpuesto As Impuesto
    Public iIndiceInicial As Integer = 1
    Public fParent As Object
    Public iIndiceMaximo As Integer = 0
    Private blnSalir As Boolean = True

    Private bCargandoCombo As Boolean = True
    Private lDTProductoPrestamoCli As DataTable
#End Region

#Region "Propiedades"


    Public Property PermitirConsultarProductos() As Boolean
        Get
            Return bPermitirConsultarProductos
        End Get
        Set(ByVal Value As Boolean)
            bPermitirConsultarProductos = Value
        End Set
    End Property

    Public Property MostrarExistencia() As Boolean
        Get
            Return bMostrarExistencia
        End Get
        Set(ByVal Value As Boolean)
            bMostrarExistencia = Value
        End Set
    End Property
    Public Property TransProdId() As String
        Get
            Return sTransProdId
        End Get
        Set(ByVal Value As String)
            sTransProdId = Value
        End Set
    End Property
    Public Property TransProdIds() As String
        Get
            Return sTransProdIDs
        End Get
        Set(ByVal Value As String)
            sTransProdIDs = Value
        End Set
    End Property
    Public Property EsquemasID() As String
        Get
            Return sEsquemasID
        End Get
        Set(ByVal Value As String)
            sEsquemasID = Value
        End Set
    End Property
    Public Property Partida() As Integer
        Get
            Return iPartida
        End Get
        Set(ByVal Value As Integer)
            iPartida = Value
        End Set
    End Property
    Public Property FolioActual() As String
        Get
            Return sFolioActual
        End Get
        Set(ByVal Value As String)
            sFolioActual = Value
        End Set
    End Property
    Public Property VisitaActual() As String
        Get
            Return sVisitaActual
        End Get
        Set(ByVal Value As String)
            sVisitaActual = Value
        End Set
    End Property
    Public Property ClienteActual() As Cliente
        Get
            Return oCliente
        End Get
        Set(ByVal Value As Cliente)
            oCliente = Value
        End Set
    End Property
    Public Property ModuloMovDetalle() As Modulos.GrupoModuloMovDetalle
        Get
            Return oModuloMovDet
        End Get
        Set(ByVal Value As Modulos.GrupoModuloMovDetalle)
            oModuloMovDet = Value
        End Set
    End Property
    Public Property ListasPrecios() As ListasPreciosCliente
        Get
            Return oListasPrecios
        End Get
        Set(ByVal Value As ListasPreciosCliente)
            oListasPrecios = Value
        End Set
    End Property
    Public Property Producto() As Producto
        Get
            Return oProducto
        End Get
        Set(ByVal Value As Producto)
            oProducto = Value
        End Set
    End Property
    Public Property TipoTransProd() As ServicesCentral.TiposTransProd
        Get
            Return tTipoTransProd
        End Get
        Set(ByVal Value As ServicesCentral.TiposTransProd)
            tTipoTransProd = Value
        End Set
    End Property
    Public Property TipoMovimiento() As ServicesCentral.TiposMovimientos
        Get
            Return tTipoMovimiento
        End Get
        Set(ByVal Value As ServicesCentral.TiposMovimientos)
            tTipoMovimiento = Value
        End Set
    End Property
    Public Property TipoVerificacionInventario() As Inventario.TiposVerificacionInventario
        Get
            Return tTipoVerificacionInventario
        End Get
        Set(ByVal Value As Inventario.TiposVerificacionInventario)
            tTipoVerificacionInventario = Value
        End Set
    End Property

    Public Property FiltroProductos() As String
        Get
            Return sFiltroProductos
        End Get
        Set(ByVal Value As String)
            sFiltroProductos = Value
        End Set
    End Property
    Public Property FiltroProductosIncluyeTabla() As String
        Get
            Return sFiltroProductosIncluyeTabla
        End Get
        Set(ByVal Value As String)
            sFiltroProductosIncluyeTabla = Value
        End Set
    End Property
    Public Property TipoIndice() As ServicesCentral.TiposModulos
        Get
            Return tTipoIndice
        End Get
        Set(ByVal Value As ServicesCentral.TiposModulos)
            tTipoIndice = Value
        End Set
    End Property
    Public Property Impuestos() As Impuesto
        Get
            Return oImpuesto
        End Get
        Set(ByVal value As Impuesto)
            oImpuesto = value
        End Set
    End Property
    Public Property DTProductoPrestamoCli() As DataTable
        Get
            Return lDTProductoPrestamoCli
        End Get
        Set(ByVal value As DataTable)
            lDTProductoPrestamoCli = value.Copy
        End Set
    End Property
#End Region

    Private bNuevoMovimiento As Boolean
    Friend WithEvents LabelProductoClave As System.Windows.Forms.Label
    Friend WithEvents fgSKU As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ButtonTerminar As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents LabelNombreProducto As System.Windows.Forms.Label
    Friend WithEvents fgProductos As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents PanelPrincipal As System.Windows.Forms.Panel
    Friend WithEvents PanelCaptura As System.Windows.Forms.Panel
    Friend WithEvents PanelFiltro As System.Windows.Forms.Panel
    Friend WithEvents ButtonContFiltro As System.Windows.Forms.Button
    Friend WithEvents ButtonMasInfo As System.Windows.Forms.Button
    Friend WithEvents TextBoxClaveFil As System.Windows.Forms.TextBox
    Friend WithEvents ButtonFiltrar As System.Windows.Forms.Button
    Friend WithEvents TextBoxNombreFil As System.Windows.Forms.TextBox
    Friend WithEvents PanelUnidades As ContenedorUnidades

    Public Event GuardarDetalle(ByRef refparoFormPedirProducto As FormPedirProducto)

    Public Event GuardarSKU(ByVal parsSKU As String)
    'Public Event PoblarProductosEquivalentes(ByRef refparoFormPedirProducto As FormPedirProducto)

    Public Event PoblarListaProductos(ByRef refparoFormPedirProducto As FormPedirProducto, ByVal aListaEsquemas As ArrayList)
    'Public Event MostrarProductosSigRango(ByRef refparoFormPedirProducto As FormPedirProducto)

    Public Event CrearGridProductos(ByRef refparoFlexGrid As C1.Win.C1FlexGrid.C1FlexGrid)

    Public refaVista As Vista

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()


        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        'Me.DetailViewUnidades.Text = "ListViewMovimientos"
        Me.fgProductos.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)

        Me.fgSKU.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)

        Me.PermitirConsultarProductos = True
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not IsNothing(PanelUnidades) Then
            'PanelUnidades.Controls.Clear()
            PanelUnidades.Dispose()
        End If
        If Not IsNothing(Me.ButtonContFiltro) Then Me.ButtonContFiltro.Dispose()
        If Not IsNothing(Me.ButtonMasInfo) Then Me.ButtonMasInfo.Dispose()
        If Not IsNothing(Me.MenuItemOpciones) Then Me.MenuItemOpciones.Dispose()
        If Not IsNothing(Me.MainMenuPrincipal) Then Me.MainMenuPrincipal.Dispose()
        If Not IsNothing(Me.ButtonTerminar) Then Me.ButtonTerminar.Dispose()
        If Not IsNothing(lDTProductoPrestamoCli) Then
            lDTProductoPrestamoCli.Dispose()
            lDTProductoPrestamoCli = Nothing
        End If
        If Not IsNothing(Me.fgProductos) Then
            Me.fgProductos.Dispose()
            Me.fgProductos = Nothing
        End If
        If Not IsNothing(Me.fgSKU) Then
            Me.fgSKU.Dispose()
            Me.fgSKU = Nothing
        End If
        If Not IsNothing(Me.PanelCaptura) Then Me.PanelCaptura.Dispose()
        If Not IsNothing(Me.PanelFiltro) Then Me.PanelFiltro.Dispose()
        TransProdId = Nothing
        FolioActual = Nothing
        ClienteActual = Nothing
        VisitaActual = Nothing
        'If Not IsNothing(ListasPrecios) Then ListasPrecios.ListasPrecios.Clear()
        'ListasPrecios.ListasPrecios = Nothing
        ListasPrecios = Nothing
        TipoTransProd = Nothing
        TipoMovimiento = Nothing
        ModuloMovDetalle = Nothing
        Partida = Nothing
        Producto = Nothing
        MyBase.Dispose(disposing)
    End Sub

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents MainMenuPrincipal As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItemOpciones As System.Windows.Forms.MenuItem
    Friend WithEvents InputPanelPedirProducto As Microsoft.WindowsCE.Forms.InputPanel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPedirProducto))
        Me.InputPanelPedirProducto = New Microsoft.WindowsCE.Forms.InputPanel
        Me.MainMenuPrincipal = New System.Windows.Forms.MainMenu
        Me.MenuItemOpciones = New System.Windows.Forms.MenuItem
        Me.fgSKU = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.ButtonTerminar = New System.Windows.Forms.Button
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.fgProductos = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.LabelProductoClave = New System.Windows.Forms.Label
        Me.LabelNombreProducto = New System.Windows.Forms.Label
        Me.PanelPrincipal = New System.Windows.Forms.Panel
        Me.PanelCaptura = New System.Windows.Forms.Panel
        Me.PanelUnidades = New MobileClient.FormPedirProducto.ContenedorUnidades
        Me.PanelFiltro = New System.Windows.Forms.Panel
        Me.ButtonFiltrar = New System.Windows.Forms.Button
        Me.TextBoxNombreFil = New System.Windows.Forms.TextBox
        Me.TextBoxClaveFil = New System.Windows.Forms.TextBox
        Me.ButtonContFiltro = New System.Windows.Forms.Button
        Me.ButtonMasInfo = New System.Windows.Forms.Button
        Me.PanelPrincipal.SuspendLayout()
        Me.PanelCaptura.SuspendLayout()
        Me.PanelFiltro.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenuPrincipal
        '
        Me.MainMenuPrincipal.MenuItems.Add(Me.MenuItemOpciones)
        '
        'MenuItemOpciones
        '
        Me.MenuItemOpciones.Text = "MenuItemOpciones"
        '
        'fgSKU
        '
        Me.fgSKU.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.fgSKU.AllowEditing = False
        Me.fgSKU.AutoResize = False
        Me.fgSKU.AutoSearchDelay = 2
        Me.fgSKU.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.fgSKU.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fgSKU.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fgSKU.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.fgSKU.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.fgSKU.Location = New System.Drawing.Point(3, 143)
        Me.fgSKU.Name = "fgSKU"
        Me.fgSKU.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgSKU.Size = New System.Drawing.Size(235, 118)
        Me.fgSKU.StyleInfo = resources.GetString("fgSKU.StyleInfo")
        Me.fgSKU.SupportInfo = "rABvAf4AmwClAHUB7wCLAAABYgByAMoA1ADHAA4BsgB1AGgAkQD+APUAVwDEANAA7QA="
        Me.fgSKU.TabIndex = 16
        '
        'ButtonTerminar
        '
        Me.ButtonTerminar.Location = New System.Drawing.Point(4, 264)
        Me.ButtonTerminar.Name = "ButtonTerminar"
        Me.ButtonTerminar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonTerminar.TabIndex = 7
        Me.ButtonTerminar.Text = "ButtonContinuar"
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(84, 264)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresar.TabIndex = 4
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'fgProductos
        '
        Me.fgProductos.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.fgProductos.AllowEditing = False
        Me.fgProductos.AutoResize = False
        Me.fgProductos.AutoSearchDelay = 2
        Me.fgProductos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.fgProductos.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fgProductos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fgProductos.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.fgProductos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.fgProductos.Location = New System.Drawing.Point(3, 35)
        Me.fgProductos.Name = "fgProductos"
        Me.fgProductos.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgProductos.Size = New System.Drawing.Size(237, 229)
        Me.fgProductos.StyleInfo = resources.GetString("fgProductos.StyleInfo")
        Me.fgProductos.SupportInfo = "aQAlAYYB2ADPACgBbQCNAGsA/wAPAQMBfwD2ACgBfQDhAJYABgGMAGsAegDAAIsAkAA/ANoATAC4AH0A"
        Me.fgProductos.TabIndex = 15
        '
        'LabelProductoClave
        '
        Me.LabelProductoClave.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelProductoClave.ForeColor = System.Drawing.Color.MediumBlue
        Me.LabelProductoClave.Location = New System.Drawing.Point(0, 3)
        Me.LabelProductoClave.Name = "LabelProductoClave"
        Me.LabelProductoClave.Size = New System.Drawing.Size(239, 18)
        Me.LabelProductoClave.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelNombreProducto
        '
        Me.LabelNombreProducto.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelNombreProducto.ForeColor = System.Drawing.Color.MediumBlue
        Me.LabelNombreProducto.Location = New System.Drawing.Point(1, 24)
        Me.LabelNombreProducto.Name = "LabelNombreProducto"
        Me.LabelNombreProducto.Size = New System.Drawing.Size(239, 18)
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.Controls.Add(Me.PanelCaptura)
        Me.PanelPrincipal.Controls.Add(Me.PanelFiltro)
        Me.PanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.PanelPrincipal.Name = "PanelPrincipal"
        Me.PanelPrincipal.Size = New System.Drawing.Size(242, 295)
        '
        'PanelCaptura
        '
        Me.PanelCaptura.Controls.Add(Me.PanelUnidades)
        Me.PanelCaptura.Controls.Add(Me.ButtonTerminar)
        Me.PanelCaptura.Controls.Add(Me.ButtonRegresar)
        Me.PanelCaptura.Controls.Add(Me.fgSKU)
        Me.PanelCaptura.Controls.Add(Me.LabelProductoClave)
        Me.PanelCaptura.Controls.Add(Me.LabelNombreProducto)
        Me.PanelCaptura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelCaptura.Location = New System.Drawing.Point(0, 0)
        Me.PanelCaptura.Name = "PanelCaptura"
        Me.PanelCaptura.Size = New System.Drawing.Size(242, 295)
        '
        'PanelUnidades
        '
        Me.PanelUnidades.AutoScroll = True
        Me.PanelUnidades.Location = New System.Drawing.Point(4, 45)
        Me.PanelUnidades.Name = "PanelUnidades"
        Me.PanelUnidades.Size = New System.Drawing.Size(234, 95)
        '
        'PanelFiltro
        '
        Me.PanelFiltro.Controls.Add(Me.ButtonFiltrar)
        Me.PanelFiltro.Controls.Add(Me.TextBoxNombreFil)
        Me.PanelFiltro.Controls.Add(Me.TextBoxClaveFil)
        Me.PanelFiltro.Controls.Add(Me.ButtonContFiltro)
        Me.PanelFiltro.Controls.Add(Me.ButtonMasInfo)
        Me.PanelFiltro.Controls.Add(Me.fgProductos)
        Me.PanelFiltro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelFiltro.Location = New System.Drawing.Point(0, 0)
        Me.PanelFiltro.Name = "PanelFiltro"
        Me.PanelFiltro.Size = New System.Drawing.Size(242, 295)
        '
        'ButtonFiltrar
        '
        Me.ButtonFiltrar.Location = New System.Drawing.Point(222, 8)
        Me.ButtonFiltrar.Name = "ButtonFiltrar"
        Me.ButtonFiltrar.Size = New System.Drawing.Size(20, 21)
        Me.ButtonFiltrar.TabIndex = 24
        Me.ButtonFiltrar.Text = "..."
        '
        'TextBoxNombreFil
        '
        Me.TextBoxNombreFil.Location = New System.Drawing.Point(104, 7)
        Me.TextBoxNombreFil.Name = "TextBoxNombreFil"
        Me.TextBoxNombreFil.Size = New System.Drawing.Size(117, 21)
        Me.TextBoxNombreFil.TabIndex = 23
        '
        'TextBoxClaveFil
        '
        Me.TextBoxClaveFil.Location = New System.Drawing.Point(3, 7)
        Me.TextBoxClaveFil.Name = "TextBoxClaveFil"
        Me.TextBoxClaveFil.Size = New System.Drawing.Size(100, 21)
        Me.TextBoxClaveFil.TabIndex = 22
        '
        'ButtonContFiltro
        '
        Me.ButtonContFiltro.Location = New System.Drawing.Point(2, 267)
        Me.ButtonContFiltro.Name = "ButtonContFiltro"
        Me.ButtonContFiltro.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContFiltro.TabIndex = 21
        Me.ButtonContFiltro.Text = "ButtonContFiltro"
        '
        'ButtonMasInfo
        '
        Me.ButtonMasInfo.Location = New System.Drawing.Point(82, 267)
        Me.ButtonMasInfo.Name = "ButtonMasInfo"
        Me.ButtonMasInfo.Size = New System.Drawing.Size(74, 24)
        Me.ButtonMasInfo.TabIndex = 20
        Me.ButtonMasInfo.Text = "LinkDetalles"
        '
        'FormPedirProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuPrincipal
        Me.MinimizeBox = False
        Me.Name = "FormPedirProducto"
        Me.PanelPrincipal.ResumeLayout(False)
        Me.PanelCaptura.ResumeLayout(False)
        Me.PanelFiltro.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Funciones y eventos generales de la forma "
    Private Sub FormPedirProducto_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        If Not IsNothing(fgProductos.DataSource) Then
            CType(fgProductos.DataSource, DataTable).Dispose()
        End If
        fgProductos.Dispose()
    End Sub

    Private Sub FormMovProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        If Not Vista.Buscar("FormPedirProducto", refaVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        Me.refaVista.ColocarEtiquetasForma(Me)
        Me.fgProductos.Visible = True
        Me.PanelPrincipal.Visible = True
        Me.ButtonContFiltro.Text = Me.ButtonTerminar.Text
        'Me.ListViewListaProd.Visible = False
        RaiseEvent CrearGridProductos(Me.fgProductos)
        fgProductos.Rows.Count = 1


        ' Determinar si se verifica el inventario
        If (Me.TipoTransProd = ServicesCentral.TiposTransProd.Cargas And Me.Partida <> 0) Then
            Me.TipoVerificacionInventario = Inventario.TiposVerificacionInventario.ValidarExistenciaCarga
        ElseIf oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion AndAlso TipoTransProd = ServicesCentral.TiposTransProd.CambioDeProducto And TipoMovimiento = ServicesCentral.TiposMovimientos.Salida Then
            Me.TipoVerificacionInventario = Inventario.TiposVerificacionInventario.ValidarExistenciaDisponibleDifNoDisponible
        Else
            Me.TipoVerificacionInventario = Inventario.DeterminarValidacionInventario(Me.TipoMovimiento, Me.TipoTransProd)
        End If

        If Me.Partida <> 0 Or Not Me.PermitirConsultarProductos Then
            ' Modificar movimiento
            'Me.EstablecerEstadoTabPageProductos(TiposEstadosTabPageProductos.NoMostrar)
            Me.PanelCaptura.Visible = True
            Me.PanelFiltro.Visible = False
        Else
            Me.ButtonRegresar.Location = New System.Drawing.Point(Me.ButtonTerminar.Location.X + Me.ButtonTerminar.Size.Width + 4, Me.ButtonRegresar.Location.Y)
        End If
        'If Me.TipoTransProd = ServicesCentral.TiposTransProd.MovSinInvEV Or Me.TipoTransProd = ServicesCentral.TiposTransProd.Pedido Or Me.TipoTransProd = ServicesCentral.TiposTransProd.VentaConsignacion Then
        '    DetailViewUnidades.Height = 115
        'Else
        '    DetailViewUnidades.Height = 135
        'End If

        If Me.Producto.ProductoClave <> String.Empty Then
            Try
                Me.PanelFiltro.Visible = False
                Me.PanelCaptura.Visible = True
            Catch ex As Exception

            End Try
            'Crear el DetailView con las unidades definidas
            If Me.CrearDetailViewUnidades_ArbolSKU() Then
                If Me.PanelUnidades.Visible Then
                    Me.EstablecerFocoPrimeraUnidad()
                End If
            Else
                'Me.EstablecerEstadoTabPageProductos(TiposEstadosTabPageProductos.Mostrar)
                'Me.PanelCaptura.Visible = True
                'Me.PanelCaptura.Visible = False
            End If
        Else
            sFiltroProductos = String.Empty
            sFiltroProductosIncluyeTabla = String.Empty
            sFiltroEsquema = String.Empty

            RaiseEvent PoblarListaProductos(Me, Nothing)
            'Me.EstablecerEstadoTabPageProductos(TiposEstadosTabPageProductos.Mostrar)

            Me.PanelFiltro.Visible = True
            Me.PanelCaptura.Visible = False
        End If
        '[Global].EscalarDetailView(DetailViewUnidades)

        Cursor.Current = Cursors.Default
    End Sub

    'Private Sub EstablecerEstadoTabPageProductos(ByVal partEstado As TiposEstadosTabPageProductos)
    '    ' Invalidar el boton de busqueda
    '    Select Case partEstado
    '        Case TiposEstadosTabPageProductos.Mostrar
    '            If Me.TabControlProducto.TabPages.Count = 1 Then
    '                Me.TabControlProducto.TabPages.Add(Me.TabPageProducto)
    '            End If
    '        Case TiposEstadosTabPageProductos.NoMostrar
    '            Me.TabControlProducto.TabPages.RemoveAt(ConstPosTabPageConsultas)
    '    End Select
    'End Sub

    Private Sub TerminarCaptura()
        Select Case tOpcionCapturaActual
            Case tOpcionCaptura.GuardarDetalle
                RaiseEvent GuardarDetalle(Me)
                If blnSalir Then
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                    Exit Sub
                End If
                'If (PermitirConsultarProductos) Then
                '    Me.Producto.ProductoClave = String.Empty
                '    Me.LabelNombreProducto.Text = String.Empty
                '    Me.Partida = 0
                '    Me.DetailViewUnidades.Items.Clear()
                '    Me.TabControlProducto.SelectedIndex = ConstPosTabPageConsultas
                '    Me.LabelPre.Text = String.Empty
                '    If fgProductos.Visible Then
                '        Me.fgProductos.Focus()
                '        If Me.fgProductos.Rows.Count > 0 And Me.fgProductos.Row > 0 Then
                '            Me.fgProductos.Select(1, 1)
                '        End If
                '    End If
                'Else
                '    Me.DialogResult = Windows.Forms.DialogResult.OK
                '    Me.Close()
                '    Exit Sub
                'End If
        End Select
    End Sub

    Private Sub CrearProductoNegado()
        Try
            Dim oProductoNegado As New ProductoNegado
            With oProductoNegado
                .TransProdId = Me.TransProdId
                .ProductoClave = Me.Producto.ProductoClave
                '.TipoUnidad = restbProductoError.TipoUnidad
                '.Cantidad = CDbl(restbProductoError.Text)
                .Insertar()
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ConfiguraGridSKU()
        With fgSKU
            .Redraw = False
            Dim f As Drawing.Font = .Font
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Styles.Normal.Trimming = Drawing.StringTrimming.EllipsisCharacter
            .Cols.Fixed = 0
            .Cols.Count = 3
            .Cols(0).Caption = refaVista.BuscarMensaje("MsgBoxVarios", "XUnidad")
            .Cols(0).Name = "Unidad"
            .Cols(0).TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
            .Cols(1).Width = 30
#End If
            .Cols(1).Caption = refaVista.BuscarMensaje("MsgBoxVarios", "MDBExistencia")
            .Cols(1).Name = "Existencia"
            .Cols(1).Width = 80
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
            .Cols(1).Width = 130
#End If
            .Cols(1).TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
            .Cols(2).Caption = refaVista.BuscarMensaje("MsgBoxVarios", "XSKU")
            .Cols(2).Name = "SKU"
            .Cols(2).Width = 300
            .Cols(2).TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
            .Rows.Count = 1
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .ExtendLastCol = True
            .Styles.Normal.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            ' initialize outline tree
            .Tree.Column = 0
            .Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.SimpleLeaf
            .AutoResize = True
            .Redraw = True
        End With
    End Sub

    Private Sub MenuItemOpciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemOpciones.Click
        If Me.PanelPrincipal.Visible Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            Me.PanelPrincipal.Visible = True
        End If
    End Sub

    'Private Function VerificarInventario(ByRef refparProducto As RescoItemNumeric, Optional ByRef refparoDatatableInventario As DataTable = Nothing) As Boolean
    '    Dim dExistencia As Decimal = 0
    '    Dim sMensaje As String = ""
    '    Dim dCantidad As Decimal
    '    Try
    '        If refparProducto.Text = "" Then
    '            refparProducto.Text = 0
    '        End If
    '        dCantidad = CDec(refparProducto.Text) - refparProducto.ValorAnterior
    '        If Me.TipoVerificacionInventario <> Inventario.TiposVerificacionInventario.ValidarExistenciaCarga Then
    '            If dCantidad <= 0 Then Return True
    '        Else
    '            'Si la cantidad es mayor a 0 tambien se sale porque la cantidad ya se sumo temporalmente en el refparoDataTableInventario
    '            'Además que para la carga solo se verifica cuando la cantidad es negativa
    '            If dCantidad >= 0 Then Return True
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation)
    '        Exit Function
    '    End Try
    '    Select Case Me.TipoVerificacionInventario
    '        Case Inventario.TiposVerificacionInventario.NoVerificar
    '            Exit Select
    '        Case Inventario.TiposVerificacionInventario.ValidarExistencia
    '            If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
    '                If Not Inventario.ValidarExistenciaDifNoDiponibleDec(Me.Producto.ProductoClave, refparProducto.TipoUnidad, dCantidad, dExistencia, sMensaje) Then
    '                    MsgBox(refaVista.BuscarMensaje("MsgBoxVarios", "MsgBoxNoExistencia") & " " & sMensaje, MsgBoxStyle.Information)
    '                    restbProductoError = refparProducto
    '                    If dExistencia > 0 Then
    '                        refparProducto.NumericValue = dExistencia
    '                        bExistenciaSugerida = True
    '                    Else
    '                        bExistenciaSugerida = False
    '                    End If
    '                    Return False
    '                End If
    '            Else
    '                If Not Inventario.ValidarExistencia(Me.Producto.ProductoClave, refparProducto.TipoUnidad, dCantidad, dExistencia, sMensaje) Then
    '                    MsgBox(refaVista.BuscarMensaje("MsgBoxVarios", "MsgBoxNoExistencia") & " " & sMensaje, MsgBoxStyle.Information)
    '                    restbProductoError = refparProducto
    '                    If dExistencia > 0 Then
    '                        refparProducto.NumericValue = dExistencia
    '                        bExistenciaSugerida = True
    '                    Else
    '                        bExistenciaSugerida = False
    '                    End If
    '                    Return False
    '                End If
    '            End If

    '        Case Inventario.TiposVerificacionInventario.ValidarExistenciaDisponible, Inventario.TiposVerificacionInventario.ValidarExistenciaDescarga
    '            If IsNothing(refparoDatatableInventario) Then
    '                If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
    '                    If Not Inventario.ValidarExistenciaDifNoDiponibleDec(Me.Producto.ProductoClave, refparProducto.TipoUnidad, dCantidad, dExistencia, sMensaje) Then
    '                        MsgBox(refaVista.BuscarMensaje("MsgBoxVarios", "MsgBoxNoExistencia") & " " & sMensaje, MsgBoxStyle.Information)
    '                        restbProductoError = refparProducto
    '                        If dExistencia > 0 Then
    '                            refparProducto.NumericValue = dExistencia
    '                            bExistenciaSugerida = True
    '                        Else
    '                            bExistenciaSugerida = False
    '                        End If
    '                        Return False
    '                    End If
    '                Else
    '                    If Not Inventario.ValidarExistenciaDisponibleDec(Me.Producto.ProductoClave, refparProducto.TipoUnidad, dCantidad, dExistencia, sMensaje) Then
    '                        MsgBox(refaVista.BuscarMensaje("MsgBoxVarios", "MsgBoxNoExistencia") & " " & sMensaje, MsgBoxStyle.Information)
    '                        restbProductoError = refparProducto
    '                        If dExistencia > 0 Then
    '                            refparProducto.NumericValue = dExistencia
    '                            bExistenciaSugerida = True
    '                        Else
    '                            bExistenciaSugerida = False
    '                        End If
    '                        Return False
    '                    End If
    '                End If

    '            Else
    '                If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
    '                    If Not Inventario.ValidarExistenciaDifNoDiponibleDec(Me.Producto.ProductoClave, refparProducto.TipoUnidad, dCantidad, dExistencia, refparoDatatableInventario, sMensaje) Then
    '                        MsgBox(refaVista.BuscarMensaje("MsgBoxVarios", "MsgBoxNoExistencia") & " " & sMensaje, MsgBoxStyle.Information)
    '                        restbProductoError = refparProducto
    '                        If dExistencia > 0 Then
    '                            refparProducto.NumericValue = dExistencia
    '                            bExistenciaSugerida = True
    '                        Else
    '                            bExistenciaSugerida = False
    '                        End If
    '                        Return False
    '                    End If
    '                Else

    '                    If Not Me.ClienteActual Is Nothing AndAlso (Me.ClienteActual.Prestamo And Me.TipoTransProd = ServicesCentral.TiposTransProd.Pedido And oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta) Then
    '                        Dim DtProducto As DataTable
    '                        DtProducto = oDBVen.RealizarConsultaSQL("select Contenido,Venta,Factor,Prestamo from producto P inner join ProductoDetalle PD on P.ProductoClave=PD.ProductoClave where P.ProductoClave ='" & Producto.ProductoClave & "' and PD.PRUTipoUnidad='" & refparProducto.TipoUnidad & "'", "ProductoDetalle")
    '                        Dim iTipoUnidad As Integer = refparProducto.TipoUnidad

    '                        If DtProducto.Rows(0).Item("Contenido") = True And DtProducto.Rows(0).Item("venta") = True Then
    '                            Dim row As DataRow() = Me.DTProductoPrestamoCli.Select("productoclave='" & Me.Producto.ProductoClave & "'")
    '                            Dim iSaldo As Integer = 0

    '                            If row.Length > 0 Then iSaldo = row(0)("Saldo")

    '                            If iSaldo < (dCantidad * DtProducto.Rows(0).Item("Factor")) Then 'validar inventario con nuevas cantidades
    '                                Dim iActulizaInventario As MobileClient.ActualizarInventario = ActualizarInventario.NoActualizaInventario
    '                                If (dCantidad * DtProducto.Rows(0).Item("Factor")) - iSaldo > 0 Then
    '                                    iActulizaInventario = ActualizarInventario.ActualizaInventarioCantidadModificada
    '                                End If
    '                                ProductoPrestamoCli.ActulizarProductoPrestamoCliDT(Me.ClienteActual.ClienteClave, Producto.ProductoClave, dCantidad, refparProducto.TipoUnidad, 2, Me.TipoTransProd, 1, Me.DTProductoPrestamoCli, iActulizaInventario)
    '                                dCantidad = (dCantidad * DtProducto.Rows(0).Item("Factor")) - iSaldo
    '                                iTipoUnidad = ProductoPrestamoCli.PRUTipoUnidadMinima(Me.Producto.ProductoClave)
    '                            Else
    '                                Return True 'No se valida el inventario
    '                            End If
    '                        End If

    '                        If Not Inventario.ValidarExistenciaDisponibleDec(Me.Producto.ProductoClave, iTipoUnidad, dCantidad, dExistencia, refparoDatatableInventario, sMensaje) Then
    '                            MsgBox(refaVista.BuscarMensaje("MsgBoxVarios", "MsgBoxNoExistencia") & " " & sMensaje, MsgBoxStyle.Information)
    '                            restbProductoError = refparProducto
    '                            If dExistencia > 0 Then
    '                                refparProducto.NumericValue = dExistencia
    '                                bExistenciaSugerida = True
    '                            Else
    '                                bExistenciaSugerida = False
    '                            End If
    '                            Return False
    '                        End If
    '                    Else
    '                        If Not Inventario.ValidarExistenciaDisponibleDec(Me.Producto.ProductoClave, refparProducto.TipoUnidad, dCantidad, dExistencia, refparoDatatableInventario, sMensaje) Then
    '                            MsgBox(refaVista.BuscarMensaje("MsgBoxVarios", "MsgBoxNoExistencia") & " " & sMensaje, MsgBoxStyle.Information)
    '                            restbProductoError = refparProducto
    '                            If dExistencia > 0 Then
    '                                refparProducto.NumericValue = dExistencia
    '                                bExistenciaSugerida = True
    '                            Else
    '                                bExistenciaSugerida = False
    '                            End If
    '                            Return False
    '                        End If

    '                    End If

    '                End If

    '            End If
    '        Case Inventario.TiposVerificacionInventario.ValidarExistenciaNoDisponible
    '            If IsNothing(refparoDatatableInventario) Then
    '                If Not Inventario.ValidarExistenciaNoDisponible(Me.Producto.ProductoClave, refparProducto.TipoUnidad, dCantidad, dExistencia, sMensaje) Then
    '                    MsgBox(refaVista.BuscarMensaje("MsgBoxVarios", "MsgBoxNoExistencia") & " " & sMensaje, MsgBoxStyle.Information)
    '                    restbProductoError = refparProducto
    '                    If dExistencia > 0 Then
    '                        refparProducto.NumericValue = dExistencia
    '                        bExistenciaSugerida = True
    '                    Else
    '                        bExistenciaSugerida = False
    '                    End If
    '                    Return False
    '                End If
    '            Else
    '                If Not Inventario.ValidarExistenciaNoDisponible(Me.Producto.ProductoClave, refparProducto.TipoUnidad, dCantidad, refparoDatatableInventario) Then
    '                    MsgBox(refaVista.BuscarMensaje("MsgBoxVarios", "MsgBoxNoExistencia") & " " & sMensaje, MsgBoxStyle.Information)
    '                    restbProductoError = refparProducto
    '                    If dExistencia > 0 Then
    '                        refparProducto.NumericValue = dExistencia
    '                        bExistenciaSugerida = True
    '                    Else
    '                        bExistenciaSugerida = False
    '                    End If
    '                    Return False
    '                End If
    '            End If
    '        Case Inventario.TiposVerificacionInventario.ValidarExistenciaCarga
    '            If (dCantidad < 0) Then
    '                dCantidad = dCantidad * -1
    '                If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then

    '                    If IsNothing(refparoDatatableInventario) Then
    '                        If Not Inventario.ValidarExistenciaDifNoDiponibleDec(Me.Producto.ProductoClave, refparProducto.TipoUnidad, dCantidad, dExistencia, sMensaje) Then
    '                            MsgBox(refaVista.BuscarMensaje("MsgBoxVarios", "MsgBoxNoExistencia") & " " & sMensaje, MsgBoxStyle.Information)
    '                            restbProductoError = refparProducto
    '                            If dExistencia > 0 Then
    '                                refparProducto.NumericValue = dExistencia
    '                                bExistenciaSugerida = True
    '                            Else
    '                                bExistenciaSugerida = False
    '                            End If
    '                            Return False
    '                        End If
    '                    Else
    '                        If Not Inventario.ValidarExistenciaDifNoDiponibleDec(Me.Producto.ProductoClave, refparProducto.TipoUnidad, dCantidad, dExistencia, refparoDatatableInventario, sMensaje) Then
    '                            MsgBox(refaVista.BuscarMensaje("MsgBoxVarios", "MsgBoxNoExistencia") & " " & sMensaje, MsgBoxStyle.Information)
    '                            restbProductoError = refparProducto
    '                            If dExistencia > 0 Then
    '                                refparProducto.NumericValue = dExistencia
    '                                bExistenciaSugerida = True
    '                            Else
    '                                bExistenciaSugerida = False
    '                            End If
    '                            Return False
    '                        End If
    '                    End If

    '                Else
    '                    If IsNothing(refparoDatatableInventario) Then
    '                        If Not Inventario.ValidarExistenciaDisponibleDec(Me.Producto.ProductoClave, refparProducto.TipoUnidad, dCantidad, dExistencia, sMensaje) Then
    '                            MsgBox(refaVista.BuscarMensaje("MsgBoxVarios", "MsgBoxNoExistencia") & " " & sMensaje, MsgBoxStyle.Information)
    '                            restbProductoError = refparProducto
    '                            If dExistencia > 0 Then
    '                                refparProducto.NumericValue = dExistencia
    '                                bExistenciaSugerida = True
    '                            Else
    '                                bExistenciaSugerida = False
    '                            End If
    '                            Return False
    '                        End If
    '                    Else
    '                        If Not Inventario.ValidarExistenciaDisponibleDec(Me.Producto.ProductoClave, refparProducto.TipoUnidad, dCantidad, dExistencia, refparoDatatableInventario, sMensaje) Then
    '                            MsgBox(refaVista.BuscarMensaje("MsgBoxVarios", "MsgBoxNoExistencia") & " " & sMensaje, MsgBoxStyle.Information)
    '                            restbProductoError = refparProducto
    '                            If dExistencia > 0 Then
    '                                refparProducto.NumericValue = dExistencia
    '                                bExistenciaSugerida = True
    '                            Else
    '                                bExistenciaSugerida = False
    '                            End If
    '                            Return False
    '                        End If
    '                    End If
    '                End If

    '            End If
    '        Case Inventario.TiposVerificacionInventario.ValidarExistenciaDisponibleDifNoDisponible

    '            If IsNothing(refparoDatatableInventario) Then

    '                If Not Inventario.ValidarExistenciaDisponibleDec(Me.Producto.ProductoClave, refparProducto.TipoUnidad, dCantidad, dExistencia, sMensaje) Then
    '                    If oConHist.Campos("VenderApartado") = True Then
    '                        If MsgBox(refaVista.BuscarMensaje("MsgBoxVarios", "P0087"), MsgBoxStyle.YesNo) = MsgBoxResult.No Then
    '                            restbProductoError = refparProducto
    '                            If dExistencia > 0 Then
    '                                refparProducto.NumericValue = dExistencia
    '                                bExistenciaSugerida = True
    '                            Else
    '                                bExistenciaSugerida = False
    '                            End If
    '                            Return False
    '                        End If
    '                        If Not Inventario.ValidarExistenciaDifNoDiponibleDec(Me.Producto.ProductoClave, refparProducto.TipoUnidad, dCantidad, dExistencia, sMensaje) Then
    '                            MsgBox(refaVista.BuscarMensaje("MsgBoxVarios", "MsgBoxNoExistencia") & " " & sMensaje, MsgBoxStyle.Information)
    '                            restbProductoError = refparProducto
    '                            If dExistencia > 0 Then
    '                                refparProducto.NumericValue = dExistencia
    '                                bExistenciaSugerida = True
    '                            Else
    '                                bExistenciaSugerida = False
    '                            End If
    '                            Return False
    '                        Else
    '                            If MsgBox(refaVista.BuscarMensaje("MsgBoxVarios", "P0087"), MsgBoxStyle.YesNo) = MsgBoxResult.No Then
    '                                restbProductoError = refparProducto
    '                                If dExistencia > 0 Then
    '                                    refparProducto.NumericValue = dExistencia
    '                                    bExistenciaSugerida = True
    '                                Else
    '                                    bExistenciaSugerida = False
    '                                End If
    '                                Return False
    '                            End If
    '                        End If
    '                    Else
    '                        MsgBox(refaVista.BuscarMensaje("MsgBoxVarios", "MsgBoxNoExistencia") & " " & sMensaje, MsgBoxStyle.Information)
    '                        restbProductoError = refparProducto
    '                        If dExistencia > 0 Then
    '                            refparProducto.NumericValue = dExistencia
    '                            bExistenciaSugerida = True
    '                        Else
    '                            bExistenciaSugerida = False
    '                        End If
    '                        Return False
    '                    End If

    '                End If


    '            Else

    '                If Not Inventario.ValidarExistenciaDisponibleDec(Me.Producto.ProductoClave, refparProducto.TipoUnidad, dCantidad, dExistencia, refparoDatatableInventario, sMensaje) Then
    '                    If oConHist.Campos("VenderApartado") = True Then

    '                        If Not Inventario.ValidarExistenciaDifNoDiponibleDec(Me.Producto.ProductoClave, refparProducto.TipoUnidad, dCantidad, dExistencia, refparoDatatableInventario, sMensaje) Then
    '                            MsgBox(refaVista.BuscarMensaje("MsgBoxVarios", "MsgBoxNoExistencia") & " " & sMensaje, MsgBoxStyle.Information)
    '                            restbProductoError = refparProducto
    '                            If dExistencia > 0 Then
    '                                refparProducto.NumericValue = dExistencia
    '                                bExistenciaSugerida = True
    '                            Else
    '                                bExistenciaSugerida = False
    '                            End If
    '                            Return False
    '                        Else
    '                            If MsgBox(refaVista.BuscarMensaje("MsgBoxVarios", "P0087"), MsgBoxStyle.YesNo) = MsgBoxResult.No Then
    '                                restbProductoError = refparProducto
    '                                If dExistencia > 0 Then
    '                                    refparProducto.NumericValue = dExistencia
    '                                    bExistenciaSugerida = True
    '                                Else
    '                                    bExistenciaSugerida = False
    '                                End If
    '                                Return False
    '                            End If
    '                        End If
    '                    Else
    '                        MsgBox(refaVista.BuscarMensaje("MsgBoxVarios", "MsgBoxNoExistencia") & " " & sMensaje, MsgBoxStyle.Information)
    '                        restbProductoError = refparProducto
    '                        If dExistencia > 0 Then
    '                            refparProducto.NumericValue = dExistencia
    '                            bExistenciaSugerida = True
    '                        Else
    '                            bExistenciaSugerida = False
    '                        End If
    '                        Return False
    '                    End If

    '                End If


    '            End If


    '    End Select
    '    Return True
    'End Function

#End Region

#Region " Tab de consulta de productos "


    Private Sub MostrarDetalleProducto(ByRef refparoFlexGrid As C1.Win.C1FlexGrid.C1FlexGrid)
        If refparoFlexGrid.Row > 0 Then
            Dim iRowActual As Integer
            iRowActual = refparoFlexGrid.Row
            Cursor.Current = Cursors.WaitCursor
            Dim r As C1.Win.C1FlexGrid.Row
            r = refparoFlexGrid.Rows(refparoFlexGrid.Row)
            Me.Producto.ProductoClave = refparoFlexGrid.GetData(refparoFlexGrid.Row, 0)

            Dim sMensaje As String = String.Empty

            sMensaje = Me.Producto.ProductoClave & vbCrLf
            sMensaje &= refparoFlexGrid.GetData(refparoFlexGrid.Row, 1) & vbCrLf

            Dim dtUnidades As DataTable = oDBVen.RealizarConsultaSQL("Select PRUTipoUnidad from ProductoUnidad where ProductoClave = '" & Me.Producto.ProductoClave & "' and TipoEstado = 1 ", "Unidades")

            If dtUnidades.Rows.Count > 0 Then
                Dim sMensajePrecios As String = String.Empty
                Dim sMensajeExistencias As String = String.Empty

                Dim dtPrecios As DataTable
                If Not IsNothing(Me.ListasPrecios) AndAlso Me.ListasPrecios.ListasPrecios.Count > 0 Then
                    dtPrecios = Me.ListasPrecios.ObtenerPrecioProd(Me.Producto.ProductoClave)
                End If
                For Each drUnidad As DataRow In dtUnidades.Rows
                    'Dim sUnidad As String = ValorReferencia.BuscarEquivalente("UNIDADV", drUnidad("PRUTipoUnidad")) & ": "
                    If Not IsNothing(dtPrecios) AndAlso dtPrecios.Rows.Count > 0 Then
                        'Se toma la moneda del primer registro ya que se supone que todas son iguales
                        Dim dtMoneda As DataTable = oDBVen.RealizarConsultaSQL("Select TipoCodigo,Simbolo from Moneda where MonedaID='" & dtPrecios.Rows(0)("MonedaID") & "'", "Moneda")
                        If dtMoneda.Rows.Count > 0 Then
                            For Each precio As DataRow In dtPrecios.Rows
                                Dim nImpuesto As Decimal = 0
                                Dim aImpuestos As New ArrayList
                                If Not IsNothing(oImpuesto) Then
                                    oImpuesto.Buscar(Me.Producto.ProductoClave, oCliente.TipoImpuesto, aImpuestos)
                                    nImpuesto = oImpuesto.Calcular(aImpuestos, precio("Precio"), precio("Precio"))
                                End If
                                sMensajePrecios &= ValorReferencia.BuscarEquivalente("UCOBRA", precio("UnidadCobranza")) & ": " & dtMoneda.Rows(0)("Simbolo") & Format(precio("Precio") + nImpuesto, "#,##0.00") & " " & ValorReferencia.BuscarEquivalente("CDGOMON", dtMoneda.Rows(0)("TipoCodigo")) & " (" & precio("minimo") & "-" & precio("maximo") & ")" & vbCrLf
                            Next
                        End If
                        If Not IsNothing(dtMoneda) Then dtMoneda.Dispose()
                        'Else
                        'sMensajePrecios &= sUnidad & refaVista.BuscarMensaje("MsgBoxVarios", "XNA") & vbCrLf
                        'End If
                        If Not IsNothing(dtPrecios) Then
                            dtPrecios.Dispose()
                        End If
                        'Else
                        '    sMensajePrecios &= sUnidad & refaVista.BuscarMensaje("MsgBoxVarios", "XNA") & vbCrLf
                    End If

                    Dim nExistencia As Double = oDBVen.EjecutarCmdScalardblSQL("Select Round(sum(Disponible - Apartado),2) from SKUInventario where ProductoClave ='" & Me.Producto.ProductoClave & "' and TipoUnidad = " & drUnidad("PRUTipoUnidad") & " and Round((Disponible-Apartado),2)>0 ")
                    Dim nPiezas As Double = oDBVen.EjecutarCmdScalardblSQL("Select Round(sum(Cantidad - Apartado1),2) from SKUInventario where ProductoClave ='" & Me.Producto.ProductoClave & "' and TipoUnidad = " & drUnidad("PRUTipoUnidad") & " and Round((Cantidad-Apartado1),2)>0 ")
                    sMensajeExistencias &= refaVista.BuscarMensaje("MsgBoxVarios", "MDBExistencia") & " " & ValorReferencia.BuscarEquivalente("UNIDADV", drUnidad("PRUTipoUnidad")) & ": " & RedondeoAritmetico(nExistencia, 2) & vbCrLf
                    sMensajeExistencias &= refaVista.BuscarMensaje("MsgBoxVarios", "MDBExistencia") & " " & refaVista.BuscarMensaje("MsgBoxVarios", "XElemento") & ": " & RedondeoAritmetico(nPiezas, 2) & vbCrLf

                Next
                sMensaje &= sMensajePrecios & sMensajeExistencias
                If Not IsNothing(dtPrecios) Then dtPrecios.Dispose()
            Else
                sMensaje &= "Sin unidades" & vbCrLf
            End If

            Cursor.Current = Cursors.Default
            MsgBox(sMensaje, MsgBoxStyle.Information)
            refparoFlexGrid.Focus()
        End If
    End Sub

    Private Sub CapturarCantidades()

    End Sub

    Private Sub fgProductos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles fgProductos.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                'TODO: Prueba Captura
                ProponerProducto()
                'CapturarCantidades()
            Case Keys.Space
                MostrarDetalleProducto(Me.fgProductos)
        End Select
    End Sub

#End Region

#Region "Tipos"
    Private Enum tOpcionCaptura
        NoDefinida
        GuardarDetalle
        RegistroProductosNegados
    End Enum

    Private Enum TiposEstadosTabPageProductos
        NoMostrar = 0
        Mostrar = 1
    End Enum
#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub MostrarError(ByVal pvCodigo)
        MsgBox(Me.refaVista.BuscarMensaje("MsgBoxVarios", pvCodigo), MsgBoxStyle.Exclamation)
    End Sub

    Public Shared Function sortUnidades() As IComparer
        Return CType(New sortDataRowsUnidades(), IComparer)
    End Function

    Private Class sortDataRowsUnidades : Implements IComparer
        Function Compare(ByVal a As Object, ByVal b As Object) As Integer Implements IComparer.Compare
            Dim c1 As DataRow = CType(a, DataRow)
            Dim c2 As DataRow = CType(b, DataRow)

            If (c1("TipoUnidad") < c2("TipoUnidad")) Then
                Return 1
            End If

            If (c1("TipoUnidad") > c2("TipoUnidad")) Then
                Return -1
            Else
                Return 0
            End If
        End Function
    End Class

    Private Sub ButtonMasInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMasInfo.Click
        MostrarDetalleProducto(Me.fgProductos)
    End Sub

    Private Sub ButtonContFiltro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonContFiltro.Click
        ProponerProducto()
    End Sub

    Private Sub ButtonFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFiltrar.Click
        Dim sFiltroAnterior As String = FiltroProductosIncluyeTabla
        FiltroProductosIncluyeTabla = String.Empty
        FiltroProductos = String.Empty

        If Trim(Me.TextBoxClaveFil.Text) <> "" Then
            FiltroProductosIncluyeTabla &= " and PRO.ProductoClave like '%" & Me.TextBoxClaveFil.Text & "%' "
            FiltroProductos &= " and ProductoClave like '%" & Me.TextBoxClaveFil.Text & "%' "
        End If

        If Trim(Me.TextBoxNombreFil.Text) <> "" Then
            FiltroProductosIncluyeTabla &= " and PRO.Nombre like '%" & Me.TextBoxNombreFil.Text & "%' "
            FiltroProductos &= " and Nombre like '%" & Me.TextBoxNombreFil.Text & "%' "
        End If
        If sFiltroAnterior <> FiltroProductosIncluyeTabla Then
            RaiseEvent PoblarListaProductos(Me, Nothing)
        End If
    End Sub

    Private Sub TextBoxClaveFil_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxClaveFil.GotFocus
        Me.TextBoxClaveFil.SelectAll()
    End Sub

    Private Sub TextBoxNombreFil_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxNombreFil.GotFocus
        Me.TextBoxNombreFil.SelectAll()
    End Sub

    Private Sub TextBoxClaveFil_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxClaveFil.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Enter)
                ButtonFiltrar_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub TextBoxNombreFil_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxNombreFil.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Enter)
                ButtonFiltrar_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub fgSKU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles fgSKU.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Enter)
                If fgSKU.Row > 0 Then
                    If fgSKU.Rows(fgSKU.Row).Node.Level = 0 Then Exit Sub
                    Dim sSku As String = String.Empty
                    sSku = Me.fgSKU.Item(Me.fgSKU.Row, "SKU")
                    RaiseEvent GuardarSKU(sSku)
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                    Exit Sub
                End If
        End Select
    End Sub

#Region "PanelUnidades"

    Public Class ContenedorUnidades
        Inherits Panel
        Implements IDisposable

        Public Event TerminoCaptura()

        Protected iControlActual As Integer

        Public Sub AgregarItem(ByVal parItemUnidad As ItemUnidad)
            parItemUnidad.ContenedorUnidadesPadre = Me
            parItemUnidad.Width = Me.Width

#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
            parItemUnidad.Height = 92
#Else
            parItemUnidad.Height = 46
#End If


            parItemUnidad.Location = New Drawing.Point(0, parItemUnidad.IndiceRenglon * parItemUnidad.Height)
            Me.Controls.Add(parItemUnidad)
        End Sub

        Public Sub SeleccionarPrimerItem()
            If Me.Controls.Count > 0 Then
                CType(Me.Controls(0), ItemUnidad).NumericCantidad.Focus()
                iControlActual = 0
            End If

        End Sub

        Public Sub SeleccionarSiguienteItem(ByVal pariIndiceItemActual As Integer)
            If Me.Controls.Count > pariIndiceItemActual + 1 Then
                CType(Controls(pariIndiceItemActual + 1), ItemUnidad).NumericCantidad.Focus()
            Else
                RaiseEvent TerminoCaptura()
            End If
        End Sub

        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Dim i As Integer = 0
                For i = 0 To Me.Controls.Count - 1
                    Me.Controls(i).Dispose()
                Next
                ' TODO: free unmanaged resources when explicitly called
            End If

            ' TODO: free shared unmanaged resources
        End Sub
    End Class

    Public Class ItemUnidad
        Inherits Panel
        Implements IDisposable

        Protected cContenedorUnidades As ContenedorUnidades
        Protected iTipoUnidad As Integer
        Protected iFactor As Integer
        Protected sTransProdDetalleID As String
        Protected sValorAnterior As String
        Protected sValorAnteriorCantidad As Decimal
        Protected dExistencia As Decimal
        Protected dExistenciaCantidad As Decimal
        Protected lblUnidad As Label
        Protected lblUnidad2 As Label
        Protected WithEvents txtCantidad As Controles.NumericTextBox
        Protected WithEvents txtCantidad1 As Controles.NumericTextBox
        Private _separacionX As Integer
        Private _separacionY As Integer
        Private _indiceRenglon As Integer

        Public Property ContenedorUnidadesPadre() As ContenedorUnidades
            Get
                Return cContenedorUnidades
            End Get
            Set(ByVal Value As ContenedorUnidades)
                cContenedorUnidades = Value
            End Set
        End Property


        Public ReadOnly Property LabelUnidad() As Label
            Get
                Return lblUnidad
            End Get
        End Property

        Public ReadOnly Property LabelUnidad2() As Label
            Get
                Return lblUnidad2
            End Get
        End Property

        Public ReadOnly Property NumericCantidad() As Controles.NumericTextBox
            Get
                Return txtCantidad
            End Get
        End Property

        Public ReadOnly Property NumericCantidad1() As Controles.NumericTextBox
            Get
                Return txtCantidad1
            End Get
        End Property


        Public Property TipoUnidad() As Integer
            Get
                Return iTipoUnidad
            End Get
            Set(ByVal Value As Integer)
                iTipoUnidad = Value
            End Set
        End Property
        Public Property Factor() As Integer
            Get
                Return iFactor
            End Get
            Set(ByVal Value As Integer)
                iFactor = Value
            End Set
        End Property
        Public Property TransProdDetalleID() As String
            Get
                Return sTransProdDetalleID
            End Get
            Set(ByVal Value As String)
                sTransProdDetalleID = Value
            End Set
        End Property
        Public Property ValorAnterior() As String
            Get
                Return sValorAnterior
            End Get
            Set(ByVal Value As String)
                sValorAnterior = Value
            End Set
        End Property
        Public Property ValorAnteriorCantidad() As Decimal
            Get
                Return sValorAnteriorCantidad
            End Get
            Set(ByVal Value As Decimal)
                sValorAnteriorCantidad = Value
            End Set
        End Property

        Public Property Existencia() As Decimal
            Get
                Return dExistencia
            End Get
            Set(ByVal Value As Decimal)
                dExistencia = Value
            End Set
        End Property
        Public Property ExistenciaCantidad() As Decimal
            Get
                Return dExistenciaCantidad
            End Get
            Set(ByVal Value As Decimal)
                dExistenciaCantidad = Value
            End Set
        End Property

        Public Property SeparacionX() As Integer
            Get
                Return _separacionX
            End Get
            Set(ByVal Value As Integer)
                _separacionX = Value
            End Set
        End Property

        Public Property SeparacionY() As Integer
            Get
                Return _separacionY
            End Get
            Set(ByVal Value As Integer)
                _separacionY = Value
            End Set
        End Property

        Public Property IndiceRenglon() As Integer
            Get
                Return _indiceRenglon
            End Get
            Set(ByVal Value As Integer)
                _indiceRenglon = Value
            End Set
        End Property


        Public Sub New(ByVal pIndiceRenglon As Integer)
            _indiceRenglon = pIndiceRenglon
        End Sub


        Public Sub AddItem()

            lblUnidad = New Label
            Me.Controls.Add(lblUnidad)
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
            lblUnidad.Height = lblUnidad.Height * 2

#End If
            lblUnidad.Size = New Drawing.Size((Me.Width / 2), lblUnidad.Height)

            txtCantidad = New Controles.NumericTextBox
            Me.Controls.Add(txtCantidad)
            txtCantidad.Size = New Drawing.Size((Me.Width / 2) - 1, txtCantidad.Height)
            txtCantidad.Location = New Drawing.Point(0, lblUnidad.Location.Y + lblUnidad.Size.Height + 2)
            txtCantidad.Formato = "##0.00"

            lblUnidad2 = New Label
            lblUnidad2.TextAlign = Drawing.ContentAlignment.TopLeft
            lblUnidad2.Font = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
            lblUnidad2.Height = lblUnidad2.Height * 2
#End If
            Me.Controls.Add(lblUnidad2)

            lblUnidad2.Size = New Drawing.Size((Me.Width / 2) - 1, lblUnidad2.Height)
            lblUnidad2.Location = New Drawing.Point((Me.Width / 2) + 1, lblUnidad.Location.Y)

            txtCantidad1 = New Controles.NumericTextBox
            Me.Controls.Add(txtCantidad1)
            txtCantidad1.Size = New Drawing.Size((Me.Width / 2) - 1, txtCantidad1.Height)
            txtCantidad1.Location = New Drawing.Point((Me.Width / 2) + 1, lblUnidad2.Location.Y + lblUnidad2.Size.Height + 2)
            txtCantidad1.Formato = "##0.##"

        End Sub

        Private disposedValue As Boolean = False        ' To detect redundant calls


        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    Me.LabelUnidad.Dispose()
                    Me.txtCantidad.Dispose()
                    Me.LabelUnidad2.Dispose()
                    Me.txtCantidad1.Dispose()
                    Me.ContenedorUnidadesPadre = Nothing

                    ' TODO: free unmanaged resources when explicitly called
                End If

                ' TODO: free shared unmanaged resources
            End If
            Me.disposedValue = True
        End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub


        Private Sub txtCantidad_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidad.DoubleClick
            txtCantidad.Select(0, txtCantidad.Text)
        End Sub

        'Private Sub txtCantidad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidad.LostFocus
        '    If txtCantidad.DecimalValue > 0 AndAlso txtCantidad1.DecimalValue = 0 Then
        '        txtCantidad1.DecimalValue = 1
        '    End If
        'End Sub

        Private Sub txtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
            Select Case e.KeyChar
                Case Microsoft.VisualBasic.ChrW(Keys.Enter)
                    txtCantidad1.Focus()
            End Select
        End Sub

        Private Sub txtCantidad1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad1.KeyPress
            Select Case e.KeyChar
                Case Microsoft.VisualBasic.ChrW(Keys.Enter)
                    ContenedorUnidadesPadre.SeleccionarSiguienteItem(_indiceRenglon)
            End Select
        End Sub


        'Private Sub txtCantidad1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidad1.LostFocus
        '    If txtCantidad.DecimalValue > 0 AndAlso txtCantidad1.DecimalValue = 0 Then
        '        txtCantidad1.DecimalValue = 1
        '    End If
        'End Sub
    End Class

#End Region

#Region " Tab de Captura de Unidades y Cantidades "

    Private Function CrearDetailViewUnidades_ArbolSKU() As Boolean
        Try
            If Not Me.Producto.Buscar() Then
                Me.MostrarError("MsgBoxNoExisteProducto")
                Return False
                'If Not Me.PermitirConsultarProductos Then
                '    Return False
                'Else

                '    Me.EstablecerEstadoTabPageProductos(TiposEstadosTabPageProductos.Mostrar)
                'End If
                Exit Try
            End If

            Me.Producto.Recuperar()
            Me.LabelProductoClave.Text = Me.Producto.ProductoClave
            Me.LabelNombreProducto.Text = Me.Producto.Nombre
            Me.PanelUnidades.Controls.Clear()

            Dim dtProductos As DataTable = oDBVen.RealizarConsultaSQL("Select CodigoSKU,  TipoUnidad, Disponible, Apartado,0.00 as ValorActual, 0.00 as Cantidad1, Cantidad, Apartado1, '' as TransProdDetalleID from skuinventario where ProductoClave = '" & Me.Producto.ProductoClave & "' and (Round((Disponible-Apartado),2)>0 AND Round((Cantidad-Apartado1),2)>0) ", "SKUInventario")
            Dim dtProductosCapturados As DataTable
            If sTransProdId = "" Then
                dtProductosCapturados = oDBVen.RealizarConsultaSQL("Select TransProdID,CodigoSKU, TipoUnidad, 0 as Disponible, 0 as Apartado, Cantidad as ValorActual,Cantidad1,TransProdDetalleID from TransProdDetalle where TransProdID in (" & Me.TransProdIds & ") and ProductoClave = '" & Me.Producto.ProductoClave & "' and (CodigoSKU = '' or CodigoSKU is null) ", "SKUInventario")
            Else
                dtProductosCapturados = oDBVen.RealizarConsultaSQL("Select TransProdID,CodigoSKU, TipoUnidad, 0 as Disponible, 0 as Apartado, Cantidad as ValorActual,Cantidad1,TransProdDetalleID from TransProdDetalle where TransProdID = '" & Me.TransProdId & "' and ProductoClave = '" & Me.Producto.ProductoClave & "' and (CodigoSKU = '' or CodigoSKU is null) ", "SKUInventario")
            End If


            Dim drUnidad() As DataRow
            For Each dr As DataRow In dtProductosCapturados.Rows
                drUnidad = dtProductos.Select("CodigoSKU = '' and TipoUnidad=" & dr("TipoUnidad"))
                If drUnidad.Length <= 0 Then
                    Dim drPro As DataRow = dtProductos.Rows.Add()
                    drPro("CodigoSKU") = ""
                    drPro("TipoUnidad") = dr("TipoUnidad")
                    drPro("Disponible") = 0
                    drPro("Apartado") = 0
                    drPro("ValorActual") = dr("ValorActual")
                    drPro("Cantidad1") = dr("Cantidad1")
                    drPro("Cantidad") = 0
                    drPro("Apartado1") = 0
                    drPro("TransProdDetalleID") = dr("TransProdDetalleID")
                Else
                    drUnidad(0)("ValorActual") = dr("ValorActual")
                    drUnidad(0)("Cantidad1") = dr("Cantidad1")
                    drUnidad(0)("TransProdDetalleID") = dr("TransProdDetalleID")
                End If
                Me.TransProdId = dr("TransProdID")
            Next

            Dim drSKU As DataRow() = dtProductos.Select("CodigoSKU <>''", "TipoUnidad, CodigoSKU")
            Dim drUnidades As DataRow() = dtProductos.Select("CodigoSKU = ''")

            Dim blnUnidades = False, blnSKU As Boolean = False

            If drUnidades.Length > 0 Then
                If drSKU.Length <= 0 Then
                    PanelUnidades.Visible = True
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
                    PanelUnidades.Size = New Drawing.Size(PanelUnidades.Size.Width, 382)
                    PanelUnidades.Top -= 10
#Else
                    PanelUnidades.Size = New Drawing.Size(PanelUnidades.Size.Width, 191)
#End If

                    fgSKU.Visible = False
                    blnUnidades = True
                Else
                    blnUnidades = True
                End If
            End If

            If drSKU.Length > 0 Then
                If drUnidades.Length <= 0 Then
                    PanelUnidades.Visible = False
                    fgSKU.Visible = True
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
                    fgSKU.Size = New Drawing.Size(fgSKU.Size.Width, 382)
#Else
                    fgSKU.Size = New Drawing.Size(fgSKU.Size.Width, 191)
#End If

                    fgSKU.Location = New System.Drawing.Point(2, 45)
                    blnSKU = True
                Else
                    blnSKU = True
                End If
            End If
            Array.Sort(drUnidades, sortUnidades)

            If blnUnidades Then
                ' Agregar las columnas, colocar el nombre del campo como columna
                Dim refDataRow As DataRow
                Dim iIndiceControl As Integer = 0
                For Each refDataRow In drUnidades
                    Dim TextBoxNuevo As New ItemUnidad(iIndiceControl)
                    Me.PanelUnidades.AgregarItem(TextBoxNuevo)
                    iIndiceControl += 1
                    TextBoxNuevo.AddItem()
                    With TextBoxNuevo
                        .LabelUnidad.ForeColor = System.Drawing.Color.DarkBlue
                        '.LabelWidth = 130
                        .LabelUnidad.Font = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                        .LabelUnidad.TextAlign = HorizontalAlignment.Left
                        '.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop
                        .NumericCantidad.Font = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                        .NumericCantidad.Maximo = 9999999
                        .NumericCantidad1.Font = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                        .NumericCantidad1.Maximo = 9999999

                        .LabelUnidad2.ForeColor = System.Drawing.Color.DarkBlue
                        .LabelUnidad2.Text = refaVista.BuscarMensaje("MsgBoxVarios", "XElemento") & " (" & RedondeoAritmetico((refDataRow("Cantidad") - refDataRow("Apartado1")), 2) & ")"

                        '.TextForeColor = System.Drawing.Color.Black
                        '.NumericCantidad= "{0:#,##0.00}"
                        '.NumericCantidad.Increment = 0
                        '.NumericCantidad.d = 2
                        '.Increment = 0
                        '.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat
                        '.NumericCantidad.tex= HorizontalAlignment.Right
                        '.Height = (PubcAlturaItemsDetailView + 5) * IIf(bEscalarDV, nFactorH, 1)
                        .Enabled = True
                        .Visible = True
                        .TipoUnidad = refDataRow("TipoUnidad")
                        .Factor = 1
                        .LabelUnidad.Text = ValorReferencia.BuscarEquivalente("UNIDADV", .TipoUnidad) & " (" & RedondeoAritmetico((refDataRow("Disponible") - refDataRow("Apartado")), 2) & ")"
                        .NumericCantidad.DecimalValue = Format(refDataRow("ValorActual"), "##0.##")
                        .NumericCantidad1.DecimalValue = Format(refDataRow("Cantidad1"), "##0.##")
                        .ValorAnterior = refDataRow("ValorActual")
                        .ValorAnteriorCantidad = refDataRow("Cantidad1")
                        .Existencia = RedondeoAritmetico((refDataRow("Disponible") - refDataRow("Apartado")), 2)
                        .ExistenciaCantidad = RedondeoAritmetico((refDataRow("Cantidad") - refDataRow("Apartado1")), 2)
                        .TransProdDetalleID = refDataRow("TransProdDetalleID")
                    End With
                Next
            End If

            If blnSKU Then
                ConfiguraGridSKU()
                fgSKU.Rows.Count = 1
                Dim iUnidadV As Integer = 0
                fgSKU.Redraw = False
                Dim r As C1.Win.C1FlexGrid.Row
                For Each dr As DataRow In drSKU
                    If iUnidadV <> dr("TipoUnidad").ToString Then
                        iUnidadV = dr("TipoUnidad").ToString
                        r = fgSKU.Rows.Add
                        r.IsNode = True
                        r.Node.Level = 0
                        fgSKU.Item(r.Index, 0) = ValorReferencia.BuscarEquivalente("UNIDADV", dr("TipoUnidad"))

                    End If
                    Dim r2 As C1.Win.C1FlexGrid.Row = fgSKU.Rows.Add
                    r2.IsNode = True
                    r2.Node.Level = 1
                    With fgSKU
                        .Item(r2.Index, 1) = RedondeoAritmetico(dr("Disponible"), 2)
                        .Item(r2.Index, 2) = dr("CodigoSKU")
                    End With
                Next
                'For i As Integer = 1 To fgMovimientos.Rows.Count - 1
                '    fgMovimientos.Rows(i).Node.Collapsed = True
                'Next
                fgSKU.Redraw = True
            End If
            If Not IsNothing(dtProductos) Then
                dtProductos.Dispose()
            End If
            If Not IsNothing(dtProductosCapturados) Then
                dtProductosCapturados.Dispose()
            End If

            Return True
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "CrearDetailViewUnidades")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "CrearDetailViewUnidades")
        End Try
        Return False
    End Function


    Private Sub EstablecerFocoPrimeraUnidad()
        Me.PanelUnidades.SeleccionarPrimerItem()
    End Sub


    Private Sub ProponerProducto()

        If Me.fgProductos.Row > 0 Then
            Dim r As C1.Win.C1FlexGrid.Row
            r = fgProductos.Rows(fgProductos.Row)
            Me.Producto.ProductoClave = Me.fgProductos.GetData(fgProductos.Row, 0)
        End If
        If Me.Producto.ProductoClave = "" Then Exit Sub
        Me.LabelProductoClave.Text = Me.Producto.ProductoClave
        Me.LabelNombreProducto.Text = Me.Producto.Nombre
        Me.PanelCaptura.Visible = True
        Me.PanelFiltro.Visible = False
        Me.Partida = 0
        If Me.CrearDetailViewUnidades_ArbolSKU() Then
            If Me.PanelUnidades.Visible Then
                Me.EstablecerFocoPrimeraUnidad()
            End If
        End If
    End Sub


    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        tOpcionCapturaActual = tOpcionCaptura.NoDefinida

        If Me.ValidarInventarioProductos() OrElse (Me.TipoIndice = ServicesCentral.TiposModulos.Preventa AndAlso (Not IsNothing(oAgenda.RutaActual)) AndAlso oAgenda.RutaActual.Inventario = True) Then
            tOpcionCapturaActual = tOpcionCaptura.GuardarDetalle
            Me.TerminarCaptura()
        End If
    End Sub

    Private Sub ButtonTerminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonTerminar.Click
        blnSalir = True
        ButtonContinuar_Click(Nothing, Nothing)
    End Sub

    Private Function VerificarTipoClaveProducto(ByRef pvTipoClave As Integer, ByRef pvEspacios As Integer) As Boolean
        'AgregarLogging("Verificar la configuración para el tipo de clave del producto", "VerificarTipoClaveProducto", AMESOLLogging.AMESOLLog.TipoLog.Funciones)
        pvTipoClave = oConHist.Campos("TipoClaveProducto")
        pvEspacios = oConHist.Campos("DigitoClaveProd")
        Return True
        'Dim sQuery As String = "SELECT TipoClaveProducto, DigitoClaveProd FROM CONHist ORDER BY CONHistFechaInicio DESC"
        'Dim oDt As DataTable = oDBVen.RealizarConsultaSQL(sQuery, "VTCP")
        'If oDt.Rows.Count > 0 Then
        '    pvTipoClave = oDt.Rows(0)("TipoClaveProducto")
        '    pvEspacios = oDt.Rows(0)("DigitoClaveProd")
        '    Return True
        'End If
        'Return False
    End Function

    'Private Sub DetailViewUnidades_ItemGotFocus(ByVal sender As Object, ByVal e As Resco.Controls.DetailView.ItemEventArgs) Handles DetailViewUnidades.ItemGotFocus
    '    ObtenerPrecio()
    'End Sub
    'Private Sub DetailViewUnidades_ItemGotFocus(ByVal sender As Object, ByVal e As Resco.Controls.DetailView.ItemEventArgs) Handles DetailViewUnidades.ItemGotFocus
    '    Dim refProducto As RescoItemNumeric = e.item
    '    refProducto.SelectionStart = 0
    '    refProducto.SelectionLength = Len(refProducto.Text)
    'End Sub


    Private Sub DetailViewUnidades_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'Select Case e.KeyChar
        '    Case Microsoft.VisualBasic.ChrW(Keys.Escape)
        '        Me.ButtonTerminar_Click(Nothing, Nothing)
        '        'Me.DialogResult = Windows.Forms.DialogResult.Cancel
        '        'Me.Close()
        '    Case Microsoft.VisualBasic.ChrW(Keys.Enter)
        '        tOpcionCapturaActual = tOpcionCaptura.NoDefinida
        '        Dim refProducto As RescoItemNumeric = Me.DetailViewUnidades.SelectedItem
        '        If IsNothing(refProducto) Then Exit Sub
        '        'ConvertirUnidades(refProducto.Index)
        '        Dim blnInventario As Boolean = False
        '        If Not IsNothing(oAgenda) Then
        '            blnInventario = oAgenda.RutaActual.Inventario
        '        End If

        '        'If Me.VerificarInventario(refProducto) OrElse (Me.TipoIndice = ServicesCentral.TiposModulos.Preventa And blnInventario = True) Then
        '        If refProducto.Index < Me.DetailViewUnidades.Items.Count - 1 Then
        '            refProducto = Me.DetailViewUnidades.Items(refProducto.Index + 1)
        '            Me.DetailViewUnidades.SelectedItem = refProducto
        '        Else
        '          
        '        End If
        '    Case Else
        'End Select
        ''If Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
        ''    e.Handled = False
        ''Else
        ''    e.Handled = True
        ''End If
    End Sub

    Private Sub PanelUnidades_TerminoCaptura() Handles PanelUnidades.TerminoCaptura
        Me.ButtonContinuar_Click(Nothing, Nothing)
    End Sub

    'Actualmente solo para Venta y Descarga
    Private Function ValidarInventarioProductos() As Boolean
        If Me.PanelUnidades.Controls.Count <= 0 Then
            Return True
        End If

        For Each refProducto As ItemUnidad In Me.PanelUnidades.Controls
            If refProducto.NumericCantidad.DecimalValue <> 0 Or refProducto.NumericCantidad1.DecimalValue <> 0 Then
                If refProducto.NumericCantidad.DecimalValue = 0 Then
                    MsgBox(refaVista.BuscarMensaje("MsgBoxVarios", "E0607").Replace("$0$", refProducto.LabelUnidad.Text), MsgBoxStyle.Information)
                    refProducto.NumericCantidad.Focus()

                    Return False
                ElseIf refProducto.NumericCantidad1.DecimalValue = 0 Then
                    MsgBox(refaVista.BuscarMensaje("MsgBoxVarios", "E0607").Replace("$0$", refProducto.LabelUnidad2.Text), MsgBoxStyle.Information)
                    refProducto.NumericCantidad1.Focus()
                    Return False
                Else
                    If (refProducto.NumericCantidad.DecimalValue - refProducto.ValorAnterior) > 0 Or (refProducto.NumericCantidad1.DecimalValue - refProducto.ValorAnteriorCantidad) > 0 Then
                        Select Case SKUInventario.ValidarExistenciaDisponible("", Me.Producto.ProductoClave, refProducto.TipoUnidad, refProducto.NumericCantidad.DecimalValue - refProducto.ValorAnterior, refProducto.NumericCantidad1.DecimalValue - refProducto.ValorAnteriorCantidad)
                            Case SKUInventario.TipoExistencia.Cantidad
                                MsgBox(refaVista.BuscarMensaje("MsgBoxVarios", "E0741"), MsgBoxStyle.Information)
                                refProducto.NumericCantidad.DecimalValue = refProducto.Existencia + refProducto.ValorAnterior
                                refProducto.NumericCantidad.Focus()
                                Return False

                            Case SKUInventario.TipoExistencia.Unidad
                                MsgBox(refaVista.BuscarMensaje("MsgBoxVarios", "E0741"), MsgBoxStyle.Information)
                                refProducto.NumericCantidad1.DecimalValue = refProducto.ExistenciaCantidad + refProducto.ValorAnteriorCantidad
                                refProducto.NumericCantidad1.Focus()
                                Return False

                        End Select
                    End If
                End If
            End If
        Next

        Return True
    End Function

    'Private Function ConvertirUnidades(ByVal pariIndex As Integer) As Boolean
    '    'If bEnter Then Exit Function
    '    'bEnter = True
    '    Dim refProducto As RescoItemNumeric
    '    Dim refProductoAnterior As RescoItemNumeric
    '    Dim iFix As Integer = 0
    '    Dim iMod As Integer = 0
    '    If pariIndex <= 0 Then Exit Function
    '    refProducto = Me.DetailViewUnidades.Items(pariIndex)
    '    If pariIndex - 1 >= 0 Then
    '        refProductoAnterior = Me.DetailViewUnidades.Items(pariIndex - 1)
    '    End If
    '    Dim cantidad As Integer = IIf(refProducto.Text = "", 0, refProducto.Text)

    '    If Fix(CInt(cantidad) / CInt(refProductoAnterior.Factor)) > 0 Then
    '        iFix = Fix(CInt(cantidad) / CInt(refProductoAnterior.Factor))
    '        iMod = CInt(cantidad) Mod CInt(refProductoAnterior.Factor)
    '        refProducto.Value = iMod
    '        If (iFix + refProductoAnterior.Value) <= 999999 Then
    '            refProductoAnterior.Value += iFix
    '            'refProducto.cambioUnidades = True
    '        End If
    '    End If
    '    'bEnter = False
    '    Return True
    'End Function
#End Region

End Class
