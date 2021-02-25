Public Class FormMenuModulos
    Inherits System.Windows.Forms.Form

    Private Const ConstPosNombreMov = 0
    Private Const ConstPosClaveMov = 1

    Private Const ConstPosTabModulosMov = 0
    Private Const ConstPosTabModulosMovDet = 1

    Protected oModuloMovActual As Modulos.GrupoModuloMov
    Protected oModuloMovDetalleActual As Modulos.GrupoModuloMovDetalle
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

    Public Property ModuloMovActual() As Modulos.GrupoModuloMov
        Get
            Return oModuloMovActual
        End Get
        Set(ByVal Value As Modulos.GrupoModuloMov)
            oModuloMovActual = Value
        End Set
    End Property
    Public Property ModuloMovDetalleActual() As Modulos.GrupoModuloMovDetalle
        Get
            Return oModuloMovDetalleActual
        End Get
        Set(ByVal Value As Modulos.GrupoModuloMovDetalle)
            oModuloMovDetalleActual = Value
        End Set
    End Property

    Private refaVista As Vista
    Friend WithEvents PanelTransacciones As System.Windows.Forms.Panel
    Friend WithEvents CtrlMenuTransacciones As MobileClient.CtrlMenuImagen
    Friend WithEvents ButtonTransContinuar As System.Windows.Forms.Button
    Friend WithEvents ButtonTransRegresar As System.Windows.Forms.Button
    Friend WithEvents PanelMovimientos As System.Windows.Forms.Panel
    Friend WithEvents CtrlMenuMovimientos As MobileClient.CtrlMenuImagen
    Friend WithEvents ButtonMovContinuar As System.Windows.Forms.Button
    Friend WithEvents ButtonMovRegresar As System.Windows.Forms.Button
    Friend WithEvents lnkMasInfo As System.Windows.Forms.LinkLabel
    Friend WithEvents LabelClienteActual As System.Windows.Forms.Label

    Private blnIniciando As Boolean
#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        blnIniciando = True
        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

        CtrlMenuTransacciones.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        'ListViewTransacciones.Activation = oApp.TipoSeleccion

        CtrlMenuTransacciones.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        'ListViewMovimientos.Activation = oApp.TipoSeleccion

        Me.ModuloMovActual = New Modulos.GrupoModuloMov
        Me.ModuloMovDetalleActual = New Modulos.GrupoModuloMovDetalle

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not IsNothing(MenuItemRegresar) Then MenuItemRegresar.Dispose()
        If Not IsNothing(MainMenuVisita) Then MainMenuVisita.Dispose()
        If Not IsNothing(CtrlMenuMovimientos) Then CtrlMenuMovimientos.Dispose()
        If Not IsNothing(CtrlMenuTransacciones) Then CtrlMenuTransacciones.Dispose()
        If Not IsNothing(ModuloMovActual) Then ModuloMovActual = Nothing
        If Not IsNothing(ModuloMovDetalleActual) Then ModuloMovDetalleActual = Nothing
        MyBase.Dispose(disposing)
    End Sub

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents InputPanelVisita As Microsoft.WindowsCE.Forms.InputPanel
    Friend WithEvents MainMenuVisita As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.InputPanelVisita = New Microsoft.WindowsCE.Forms.InputPanel
        Me.MainMenuVisita = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lnkMasInfo = New System.Windows.Forms.LinkLabel
        Me.LabelClienteActual = New System.Windows.Forms.Label
        Me.PanelTransacciones = New System.Windows.Forms.Panel
        Me.CtrlMenuTransacciones = New MobileClient.CtrlMenuImagen
        Me.ButtonTransContinuar = New System.Windows.Forms.Button
        Me.ButtonTransRegresar = New System.Windows.Forms.Button
        Me.PanelMovimientos = New System.Windows.Forms.Panel
        Me.CtrlMenuMovimientos = New MobileClient.CtrlMenuImagen
        Me.ButtonMovContinuar = New System.Windows.Forms.Button
        Me.ButtonMovRegresar = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.PanelTransacciones.SuspendLayout()
        Me.PanelMovimientos.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenuVisita
        '
        Me.MainMenuVisita.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lnkMasInfo)
        Me.Panel1.Controls.Add(Me.LabelClienteActual)
        Me.Panel1.Controls.Add(Me.PanelTransacciones)
        Me.Panel1.Controls.Add(Me.PanelMovimientos)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'lnkMasInfo
        '
        Me.lnkMasInfo.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Underline)
        Me.lnkMasInfo.ForeColor = System.Drawing.Color.Navy
        Me.lnkMasInfo.Location = New System.Drawing.Point(136, 21)
        Me.lnkMasInfo.Name = "lnkMasInfo"
        Me.lnkMasInfo.Size = New System.Drawing.Size(96, 20)
        Me.lnkMasInfo.TabIndex = 4
        Me.lnkMasInfo.Text = "lnkMasInfo"
        Me.lnkMasInfo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelClienteActual
        '
        Me.LabelClienteActual.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelClienteActual.ForeColor = System.Drawing.Color.Navy
        Me.LabelClienteActual.Location = New System.Drawing.Point(1, 1)
        Me.LabelClienteActual.Name = "LabelClienteActual"
        Me.LabelClienteActual.Size = New System.Drawing.Size(236, 16)
        Me.LabelClienteActual.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PanelTransacciones
        '
        Me.PanelTransacciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelTransacciones.Controls.Add(Me.CtrlMenuTransacciones)
        Me.PanelTransacciones.Controls.Add(Me.ButtonTransContinuar)
        Me.PanelTransacciones.Controls.Add(Me.ButtonTransRegresar)
        Me.PanelTransacciones.Location = New System.Drawing.Point(0, 41)
        Me.PanelTransacciones.Name = "PanelTransacciones"
        Me.PanelTransacciones.Size = New System.Drawing.Size(242, 254)
        '
        'CtrlMenuTransacciones
        '
        Me.CtrlMenuTransacciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrlMenuTransacciones.BackColor = System.Drawing.Color.White
        Me.CtrlMenuTransacciones.Location = New System.Drawing.Point(7, 3)
        Me.CtrlMenuTransacciones.Name = "CtrlMenuTransacciones"
        Me.CtrlMenuTransacciones.Size = New System.Drawing.Size(227, 215)
        Me.CtrlMenuTransacciones.TabIndex = 7
        '
        'ButtonTransContinuar
        '
        Me.ButtonTransContinuar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonTransContinuar.Location = New System.Drawing.Point(10, 223)
        Me.ButtonTransContinuar.Name = "ButtonTransContinuar"
        Me.ButtonTransContinuar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonTransContinuar.TabIndex = 5
        Me.ButtonTransContinuar.Text = "ButtonTransContinuar"
        '
        'ButtonTransRegresar
        '
        Me.ButtonTransRegresar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonTransRegresar.Location = New System.Drawing.Point(89, 223)
        Me.ButtonTransRegresar.Name = "ButtonTransRegresar"
        Me.ButtonTransRegresar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonTransRegresar.TabIndex = 6
        Me.ButtonTransRegresar.Text = "ButtonTransRegresar"
        '
        'PanelMovimientos
        '
        Me.PanelMovimientos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelMovimientos.Controls.Add(Me.CtrlMenuMovimientos)
        Me.PanelMovimientos.Controls.Add(Me.ButtonMovContinuar)
        Me.PanelMovimientos.Controls.Add(Me.ButtonMovRegresar)
        Me.PanelMovimientos.Location = New System.Drawing.Point(0, 41)
        Me.PanelMovimientos.Name = "PanelMovimientos"
        Me.PanelMovimientos.Size = New System.Drawing.Size(242, 250)
        Me.PanelMovimientos.Visible = False
        '
        'CtrlMenuMovimientos
        '
        Me.CtrlMenuMovimientos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrlMenuMovimientos.BackColor = System.Drawing.Color.White
        Me.CtrlMenuMovimientos.Location = New System.Drawing.Point(7, 3)
        Me.CtrlMenuMovimientos.Name = "CtrlMenuMovimientos"
        Me.CtrlMenuMovimientos.Size = New System.Drawing.Size(225, 215)
        Me.CtrlMenuMovimientos.TabIndex = 4
        '
        'ButtonMovContinuar
        '
        Me.ButtonMovContinuar.Location = New System.Drawing.Point(7, 223)
        Me.ButtonMovContinuar.Name = "ButtonMovContinuar"
        Me.ButtonMovContinuar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonMovContinuar.TabIndex = 1
        Me.ButtonMovContinuar.Text = "ButtonMovContinuar"
        '
        'ButtonMovRegresar
        '
        Me.ButtonMovRegresar.Location = New System.Drawing.Point(86, 223)
        Me.ButtonMovRegresar.Name = "ButtonMovRegresar"
        Me.ButtonMovRegresar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonMovRegresar.TabIndex = 2
        Me.ButtonMovRegresar.Text = "ButtonMovRegresar"
        '
        'FormMenuModulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuVisita
        Me.MinimizeBox = False
        Me.Name = "FormMenuModulos"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.PanelTransacciones.ResumeLayout(False)
        Me.PanelMovimientos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub FormMenuModulos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarMenuImagen(CtrlMenuMovimientos)
        [Global].EscalarMenuImagen(CtrlMenuTransacciones)
        [Global].EscalarForma(Me)
        If Not Vista.Buscar("FormMenuModulos", refaVista) Then
            Exit Sub
        End If
        'refaVista.CrearListView(ListViewTransacciones, "ListViewTransacciones")
        Me.LabelClienteActual.Text = oAgenda.ClienteActual.Clave & "-" & IIf(oAgenda.ClienteActual.RazonSocial.Trim = "", oAgenda.ClienteActual.NombreCorto, oAgenda.ClienteActual.RazonSocial.Trim)
        PoblarTransacciones()

        blnIniciando = False
        Dim iNumMaxMov As Integer = oDBVen.EjecutarCmdScalarIntSQL("SELECT count(*) as total FROM ModuloMovDetalle group by ModuloMovClave order by total desc ")
        CtrlMenuMovimientos.NumColumnas = 3
        CtrlMenuMovimientos.NumRenglones = Math.Ceiling(iNumMaxMov / 3)
        CtrlMenuMovimientos.CrearGrid()


        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)
        If Not IsNothing(Me.ModuloMovDetalleActual.ModuloMovDetalleClave) Then
            ProponerPrimerItem()
            ButtonTransContinuar_Click(Nothing, Nothing)
        Else
            With CtrlMenuTransacciones
                If Not IsNothing(CtrlMenuTransacciones.CeldaActual) > 0 Then
                    .Focus()
                Else
                    Me.ButtonTransContinuar.Focus()
                End If
            End With
        End If
        [Global].EscalarFuente(Me)
    End Sub

    Private Sub PoblarTransacciones()
        Dim dt As DataTable = oDBVen.RealizarConsultaSQL("SELECT TipoIndice,Nombre,ModuloMovClave FROM ModuloMov Where ModuloClave='" & oVendedor.ClaveModulo & "' order by orden ", "Transacciones")
        Dim i As Integer = 0
        CtrlMenuTransacciones.NumColumnas = 3
        CtrlMenuTransacciones.NumRenglones = Math.Ceiling(dt.Rows.Count / 3)
        CtrlMenuTransacciones.CrearGrid()
        For Each dr As DataRow In dt.Rows
            If Not IsNothing(htImagenes("MT" & dr("tipoIndice"))) Then
                CtrlMenuTransacciones.Celdas(i).SetValores(New System.Drawing.Bitmap(CType(htImagenes("MT" & dr("tipoIndice")), System.Drawing.Bitmap)), dr("TipoIndice"), dr("Nombre"), dr("ModuloMovClave"))
            Else
                CtrlMenuTransacciones.Celdas(i).SetValores(New System.Drawing.Bitmap(CType(htImagenes("MG0"), System.Drawing.Bitmap)), dr("TipoIndice"), dr("Nombre"), dr("ModuloMovClave"))
            End If
            i += 1
        Next

        dt.Dispose()
    End Sub

    Private Sub PoblarMovimientos(ByVal parsClaveTransaccion As String)
        Dim dt As DataTable = oDBVen.RealizarConsultaSQL("SELECT case When MMD.TipoIndice = 21 Then 7 Else MMD.TipoIndice End AS TipoIndice,MMD.Nombre,MMD.ModuloMovDetalleClave FROM ModuloMovDetalle MMD inner join MmdMcn MM on MM.ModuloMovDetalleClave =MMD.ModuloMovDetalleClave and MM.MCNClave ='" & oVendedor.MCNClave & "' WHERE MMD.ModuloClave='" & oVendedor.ClaveModulo & "' AND MMD.ModuloMovClave='" & parsClaveTransaccion & "' ORDER BY Orden", "Transacciones")
        Dim i As Integer = 0
        'CtrlMenuMovimientos.Dispose()
        'CtrlMenuMovimientos.NumColumnas = 3
        'CtrlMenuMovimientos.NumRenglones = Math.Ceiling(dt.Rows.Count / 3)
        'CtrlMenuMovimientos.CrearGrid()
        CtrlMenuMovimientos.NumCeldasSeleccionables = dt.Rows.Count
        CtrlMenuMovimientos.LimpiarCeldas()
        For Each dr As DataRow In dt.Rows
            If Not IsNothing(htImagenes("MM" & dr("tipoIndice"))) Then
                CtrlMenuMovimientos.Celdas(i).SetValores(New System.Drawing.Bitmap(CType(htImagenes("MM" & dr("tipoIndice")), System.Drawing.Bitmap)), dr("TipoIndice"), dr("Nombre"), dr("ModuloMovDetalleClave"))
            Else
                CtrlMenuMovimientos.Celdas(i).SetValores(New System.Drawing.Bitmap(CType(htImagenes("MG0"), System.Drawing.Bitmap)), dr("TipoIndice"), dr("Nombre"), dr("ModuloMovDetalleClave"))
            End If
            i += 1
        Next
        dt.Dispose()
    End Sub

    Private Sub ProponerPrimerItem()
        If Me.PanelTransacciones.Visible Then
            If Me.ModuloMovActual.ModuloMovClave Is Nothing Then
                CtrlMenuTransacciones.SeleccionarCeldaActual(0, 0)
            Else
                CtrlMenuTransacciones.SeleccionarCeldaActual(CtrlMenuTransacciones.CeldasPorTipo(Me.ModuloMovActual.TipoModuloMov).IndiceRen, CtrlMenuTransacciones.CeldasPorTipo(Me.ModuloMovActual.TipoModuloMov).IndiceCol)
            End If
        Else
            If Me.ModuloMovDetalleActual.ModuloMovDetalleClave Is Nothing Then
                CtrlMenuMovimientos.SeleccionarCeldaActual(0, 0)
            Else
                If Not IsNothing(CtrlMenuMovimientos.CeldasPorTipo(Me.ModuloMovDetalleActual.TipoModuloMovDetalle)) Then
                    CtrlMenuMovimientos.SeleccionarCeldaActual(CtrlMenuMovimientos.CeldasPorTipo(Me.ModuloMovDetalleActual.TipoModuloMovDetalle).IndiceRen, CtrlMenuMovimientos.CeldasPorTipo(Me.ModuloMovDetalleActual.TipoModuloMovDetalle).IndiceCol)
                End If
            End If
        End If
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Me.Close()
    End Sub

#Region " TabPageTransacciones "

    Private Sub ButtonTransRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTransRegresar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ButtonTransContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTransContinuar.Click
        MostrarMenuMovimientos()
    End Sub

    Private Sub CtrlMenuTransacciones_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrlMenuTransacciones.DoubleClick
        MostrarMenuMovimientos()
    End Sub

    Private Sub CtrlMenuTransacciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CtrlMenuTransacciones.KeyDown
        If e.KeyCode = Keys.Return Then
            MostrarMenuMovimientos()
        End If
    End Sub
#End Region

#Region " TabPageMovimientos "

    Private Sub CtrlMenuMovimientos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CtrlMenuMovimientos.KeyDown
        If e.KeyCode = Keys.Return Then
            AceptarModulo()
        End If
    End Sub

    Private Sub CtrlMenuMovimientos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrlMenuMovimientos.DoubleClick
        AceptarModulo()
    End Sub

    Private Sub ButtonMovContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMovContinuar.Click
        AceptarModulo()
    End Sub

    Private Sub ButtonMovRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMovRegresar.Click
        Me.PanelTransacciones.Visible = True
        Me.PanelMovimientos.Visible = False

        With CtrlMenuTransacciones
            If Not IsNothing(.CeldaActual) > 0 Then
                .Focus()
            End If
        End With
    End Sub

    Private Sub MostrarMenuMovimientos()
        If blnIniciando Then Exit Sub
        Dim sClaveTransaccion As String = CtrlMenuTransacciones.CeldaActual.ModuloClave
        PoblarMovimientos(sClaveTransaccion)
        ' si tiene subelementos
        If Me.CtrlMenuMovimientos.NumCeldasSeleccionables > 0 Then
            Me.PanelMovimientos.Visible = True
            Me.PanelTransacciones.Visible = False
            Me.ProponerPrimerItem()

            With CtrlMenuMovimientos
                If Not IsNothing(.CeldaActual) > 0 Then
                    .Focus()
                End If
            End With

        Else
            AceptarModulo()
        End If
    End Sub

    Private Sub AceptarModulo()
        Try
            ' Obtener Modulo
            'Dim refListViewItem As ListViewItem
            ' Identificar el ID de movimiento a realizar
            If Not IsNothing(Me.CtrlMenuTransacciones.CeldaActual) Then
                ' Obtener ModuloMov
                ' Recuperar el ModuloMov
                Me.ModuloMovActual.ModuloClave = oVendedor.ClaveModulo
                Me.ModuloMovActual.ModuloMovClave = Me.CtrlMenuTransacciones.CeldaActual.ModuloClave
                Me.ModuloMovActual.Recuperar()
                ' Recuperar el ModuloMovDetalle
                If Not IsNothing(Me.CtrlMenuMovimientos.CeldaActual) Then
                    'refListViewItem = Me.ListViewMovimientos.Items(Me.ListViewMovimientos.SelectedIndices(0))
                    Me.ModuloMovDetalleActual.Recuperar(Me.CtrlMenuMovimientos.CeldaActual.ModuloClave)
                End If
            End If
            'FormProcesando.PubSubTitulo(Me.ModuloMovActual.Nombre)
            'FormProcesando.PubSubInformar(refaVista.BuscarMensaje("Procesando", "Cargando"), Me.ModuloMovDetalleActual.Nombre)
            oFormCargando.Informar(Me.CtrlMenuMovimientos.CeldaActual.TipoIndice, "MM", Me.CtrlMenuMovimientos.lblMenuActual.Text)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "AceptarModulo")
        End Try
    End Sub

#End Region

    Private Sub FormMenuModulos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.D4 And e.Modifiers = Keys.Control) Or e.KeyCode = Keys.F4 Then
            Dim oFormListasPrecios As New FormListasPrecios
            oFormListasPrecios.ShowDialog()
            oFormListasPrecios.Dispose()
        End If
    End Sub
    Public Enum TipoCarga
        CargaReparto = 0
        CargaCanje
    End Enum

    Private Sub lnkMasInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMasInfo.Click
        Dim oFormClienteDetalle As New FormClienteDetalle(FormClienteDetalle.eStatus.Existente)
        oFormClienteDetalle.ShowDialog()
        oAgenda.ClienteActual.Recuperar()
        oFormClienteDetalle.Dispose()
        oFormClienteDetalle = Nothing
    End Sub
End Class
