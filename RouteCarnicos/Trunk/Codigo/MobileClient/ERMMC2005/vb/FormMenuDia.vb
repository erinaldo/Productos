
Public Class FormMenuDia
    Inherits System.Windows.Forms.Form

    Private Const ConstMenuRegresar = 0

    Protected tTipoOpcion As ServicesCentral.TiposOpcionesMenuDia
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents CtrlMenuDia As MobileClient.CtrlMenuImagen

    Public Property OpcionSeleccionada() As ServicesCentral.TiposOpcionesMenuDia
        Get
            Return tTipoOpcion
        End Get
        Set(ByVal Value As ServicesCentral.TiposOpcionesMenuDia)
            tTipoOpcion = Value
        End Set
    End Property

    Private refaVista As Vista

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        CtrlMenuDia.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        'ListViewMenu.Activation = oApp.TipoSeleccion

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MainMenuDia Is Nothing Then Me.MainMenuDia.Dispose()
        If Not Me.CtrlMenuDia Is Nothing Then Me.CtrlMenuDia.Dispose()
        MyBase.Dispose(disposing)
    End Sub

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents MainMenuDia As System.Windows.Forms.MainMenu
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenuDia = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.CtrlMenuDia = New MobileClient.CtrlMenuImagen
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenuDia
        '
        Me.MainMenuDia.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CtrlMenuDia)
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'CtrlMenuDia
        '
        Me.CtrlMenuDia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrlMenuDia.BackColor = System.Drawing.Color.White
        Me.CtrlMenuDia.Location = New System.Drawing.Point(3, 3)
        Me.CtrlMenuDia.Name = "CtrlMenuDia"
        Me.CtrlMenuDia.Size = New System.Drawing.Size(235, 257)
        Me.CtrlMenuDia.TabIndex = 4
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(5, 262)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuar.TabIndex = 6
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(84, 262)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresar.TabIndex = 7
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'FormMenuDia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuDia
        Me.MinimizeBox = False
        Me.Name = "FormMenuDia"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FormMenuDia_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        refaVista = Nothing
    End Sub

    Private Sub FormMenuDia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarMenuImagen(CtrlMenuDia)
        [Global].EscalarForma(Me)

        If Not Vista.Buscar("FormMenuDia", refaVista) Then
            Exit Sub
        End If
        refaVista.PoblarCtlMenuImagen(CtrlMenuDia, "MD", "ListViewMenu")
        refaVista.ColocarEtiquetasForma(Me)

        With CtrlMenuDia
            If .Renglones.Length > 0 Then
                .Focus()
            Else
                Me.ButtonContinuar.Focus()
            End If
        End With
        CtrlMenuDia.Focus()
        [Global].EscalarFuente(Me)
        'MemoriaTexto("FormMenuDia")
    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.OpcionSeleccionada = ServicesCentral.TiposOpcionesMenuDia.NoDefinido
        Me.Close()
    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        SeleccionarOpcion()
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Me.OpcionSeleccionada = ServicesCentral.TiposOpcionesMenuDia.NoDefinido
        Me.Close()
    End Sub

    'Private Sub ListViewMenu_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If ListViewMenu.SelectedIndices.Count = 0 Then
    '        Exit Sub
    '    End If
    '    Me.OpcionSeleccionada = ListViewMenu.Items(ListViewMenu.SelectedIndices(0)).ImageIndex
    'End Sub

    

    Private Sub SeleccionarOpcion()
        If IsNothing(Me.CtrlMenuDia.CeldaActual) Then Exit Sub

        Me.OpcionSeleccionada = Me.CtrlMenuDia.CeldaActual.TipoIndice
        If Me.OpcionSeleccionada = ServicesCentral.TiposOpcionesMenuVendedor.NoDefinido Then
            If Not refaVista.BuscarMenuItemDefault("ListViewMenu", Me.OpcionSeleccionada) Then
                Exit Sub
            End If
        End If

        'FormProcesando.PubSubTitulo(refaVista.BuscarMensaje("Procesando", "Titulo"))
        'FormProcesando.PubSubInformar(refaVista.BuscarMensaje("Procesando", "Cargando"), CtrlMenuDia.CeldaActual.control.Tag)
        oFormCargando.Informar(Me.OpcionSeleccionada, "MD", Me.CtrlMenuDia.lblMenuActual.Text)
        Me.Close()
    End Sub

    Private Sub CtrlMenuDia_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrlMenuDia.DoubleClick
        SeleccionarOpcion()
    End Sub

    Private Sub CtrlMenuDia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CtrlMenuDia.KeyDown
        If e.KeyCode = Keys.Return Then
            SeleccionarOpcion()
        End If
    End Sub
End Class
