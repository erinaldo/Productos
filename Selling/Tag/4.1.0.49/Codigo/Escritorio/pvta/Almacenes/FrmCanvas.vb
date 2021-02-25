
Public Class FrmCanvas
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
    Friend WithEvents CtxEstructura As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemReSize As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemRotar As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemCopy As System.Windows.Forms.MenuItem
    Friend WithEvents CtxSuperficie As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemZoom As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemDelete As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemPegar As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.CtxEstructura = New System.Windows.Forms.ContextMenu()
        Me.MenuItemReSize = New System.Windows.Forms.MenuItem()
        Me.MenuItemRotar = New System.Windows.Forms.MenuItem()
        Me.MenuItemCopy = New System.Windows.Forms.MenuItem()
        Me.MenuItemDelete = New System.Windows.Forms.MenuItem()
        Me.CtxSuperficie = New System.Windows.Forms.ContextMenu()
        Me.MenuItemZoom = New System.Windows.Forms.MenuItem()
        Me.MenuItemPegar = New System.Windows.Forms.MenuItem()
        Me.SuspendLayout()
        '
        'CtxEstructura
        '
        Me.CtxEstructura.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemReSize, Me.MenuItemRotar, Me.MenuItemCopy, Me.MenuItemDelete})
        '
        'MenuItemReSize
        '
        Me.MenuItemReSize.Index = 0
        Me.MenuItemReSize.Text = "&Redimensionar"
        '
        'MenuItemRotar
        '
        Me.MenuItemRotar.Index = 1
        Me.MenuItemRotar.Text = "R&otar"
        '
        'MenuItemCopy
        '
        Me.MenuItemCopy.Index = 2
        Me.MenuItemCopy.Text = "&Copiar      "
        '
        'MenuItemDelete
        '
        Me.MenuItemDelete.Index = 3
        Me.MenuItemDelete.Text = "&Eliminar"
        '
        'CtxSuperficie
        '
        Me.CtxSuperficie.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemZoom, Me.MenuItemPegar})
        '
        'MenuItemZoom
        '
        Me.MenuItemZoom.Index = 0
        Me.MenuItemZoom.Text = "&Zoom"
        '
        'MenuItemPegar
        '
        Me.MenuItemPegar.Index = 1
        Me.MenuItemPegar.Text = "&Pegar"
        '
        'FrmCanvas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1036, 780)
        Me.ContextMenu = Me.CtxSuperficie
        Me.Cursor = System.Windows.Forms.Cursors.Cross
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCanvas"
        Me.ShowInTaskbar = False
        Me.Text = "FrmCanvas"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********* atributos del objeto*********+
    Public ALMClave As String
    Public Stage As String = ""
    Public Referencia As String
    Public Nombre As String
    Public SUCClave As String
    Public BloqueoVta As Boolean
    Public Predeterminado As Boolean
    Public Escala As Double
    Public Largo As Double
    Public Ancho As Double
    Public Alto As Double
    Public TipoSurtido As Integer
    ' Public CapacidadCarga As Double
    Public Estado As Integer
    Public Baja As Boolean

    '*******variables para mover las estructuras*****
    Private DX, DY As Integer
    Private CrearEstructura As Boolean
    Public CambioTamaño As Boolean

    Private sControl As String = ""

    '****variables para graficos****
    Private Grafico As Graphics
    Private Lapiz As Pen
    Private Punto1 As Point
    Public Punto2 As Point

    Private Sub FrmCanvas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Combierte a la forma actual en superficie de dibujo
        Grafico = Graphics.FromHwnd(Superficie.Handle)

        'Define la pluma para dibujo
        Lapiz = New Pen(Color.Gray, 1)

        Punto1 = New Point(0, 0)
        Punto2 = New Point(0, 0)

        Me.Location = New Point(10, 10)

    End Sub

    Private Sub FrmCanvas_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If ModPOS.Almacen_Activo = "" Then
            ModPOS.Superficie.Dispose()
            ModPOS.Superficie = Nothing
        Else
            Beep()
            Select Case MessageBox.Show("Se encuentra un almacén abierto. ¿Desea cerrarlo y guardar los cambios?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    ModPOS.Graba_Layout_Activo()
                    ModPOS.Almacen_Activo = ""

                    ModPOS.Superficie.Dispose()
                    ModPOS.Superficie = Nothing

                Case DialogResult.No
                    e.Cancel = True
            End Select


        End If

    End Sub

    Private Sub FrmCanvas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case Me.sControl
            Case "Ctrl"
                If e.KeyCode = Keys.C And ModPOS.Est_Selected > -1 Then
                    Me.sControl = "CtrlC"
                ElseIf e.KeyCode = Keys.V Then
                    Me.sControl = "CtrlV"
                Else
                    Me.sControl = ""
                End If
            Case ""
                If e.KeyCode = Keys.ControlKey Then
                    Me.sControl = "Ctrl"
                ElseIf e.KeyCode = Keys.Delete And ModPOS.Est_Selected > -1 Then
                    Me.sControl = "Delete"
                End If
        End Select



    End Sub

    Private Sub FrmCanvas_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp

        Select Case Me.sControl
            Case "CtrlC"
                ModPOS.CopiaEstructura(ModPOS.vector(ModPOS.Est_Selected), 1)
                Me.sControl = ""
            Case "CtrlV"
                If ModPOS.numEst_CpyVector > -1 Then
                    ModPOS.PegaEstructura(Me.Punto2)
                    Me.Refresh()
                End If
                Me.sControl = ""

            Case "Delete"
                Beep()
                Select Case MessageBox.Show("Se eliminara la estructura de almacenaje : " & ModPOS.vector(ModPOS.Est_Selected).Name & " - " & ModPOS.vector(ModPOS.Est_Selected).Clave, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    Case DialogResult.Yes
                        Dim Con As String = ModPOS.BDConexion
                        If ModPOS.SiExite(Con, "sp_estructura_vacia", "@Estructura", ModPOS.vector(ModPOS.Est_Selected).Name) <> 0 Then
                            MessageBox.Show("La estructura seleccionada no puede ser eliminada ya que existen ubicaciones ocupadas o apartadas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            ModPOS.Ejecuta("sp_elimina_estructura", "@Estructura", ModPOS.vector(ModPOS.Est_Selected).Name, "@Usuario", ModPOS.UsuarioActual)
                            ModPOS.vector(ModPOS.Est_Selected).Visible = False
                        End If

                    Case DialogResult.No
                End Select

                Me.sControl = ""
        End Select


    End Sub

    Private Sub FrmCanvas_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        'Dim i As Integer

        If e.Button = MouseButtons.Right Then

        Else
            Punto1.X = e.X
            Punto1.Y = e.Y
            If ModPOS.Est_Selected > -1 Then
                ModPOS.vector(ModPOS.Est_Selected).Selected = False
                ModPOS.vector(ModPOS.Est_Selected).BackColor = Color.FromArgb(ModPOS.vector(ModPOS.Est_Selected).Color)
                With ModPOS.Principal
                    .Copiar.Enabled = Janus.Windows.UI.InheritableBoolean.False
                    .CopiarN.Enabled = Janus.Windows.UI.InheritableBoolean.False
                    .Rotar.Enabled = Janus.Windows.UI.InheritableBoolean.False
                    .Eliminar.Enabled = Janus.Windows.UI.InheritableBoolean.False
                    .Fila.Enabled = Janus.Windows.UI.InheritableBoolean.False
                    .Columna.Enabled = Janus.Windows.UI.InheritableBoolean.False
                    .EliminarColumna.Enabled = Janus.Windows.UI.InheritableBoolean.False
                    .EliminarFila.Enabled = Janus.Windows.UI.InheritableBoolean.False
                    .Largo.Enabled = Janus.Windows.UI.InheritableBoolean.False
                End With
            End If
        End If
        CrearEstructura = False
    End Sub

    Private Sub FrmCanvas_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        Dim Ancho, Largo As Integer
        Punto2.X = e.X
        Punto2.Y = e.Y

        With ModPOS.Principal
            .StPanel1.Text = "Almacén: " & Me.Nombre
            .StPanel2.Text = "Largo: " & CStr(ModPOS.Redondear(Me.Largo, 2)) & " Ancho: " & CStr(ModPOS.Redondear(Me.Ancho, 2))
            .StPanel3.Text = "X: " & CStr(ModPOS.Redondear(Punto2.X / ModPOS.EscalaActual, 2)) & " Y: " & CStr(ModPOS.Redondear(Punto2.Y / ModPOS.EscalaActual, 2))
        End With

        If e.Button = MouseButtons.Left Then
            ModPOS.Superficie.Refresh()
            ' largo es igual al width y ancho es igual al height
            Largo = System.Math.Abs(Punto2.X - Punto1.X)
            Ancho = System.Math.Abs(Punto2.Y - Punto1.Y)

            ModPOS.Principal.StPanel2.Text = "Largo: " & CStr(ModPOS.Redondear(Largo / ModPOS.EscalaActual, 2)) & " Ancho: " & CStr(ModPOS.Redondear(Ancho / ModPOS.EscalaActual, 2))
            Grafico.DrawRectangle(Lapiz, Punto1.X, Punto1.Y, Largo, Ancho)


            If Ancho = 0 Or Largo = 0 Then
                CrearEstructura = False
            Else : CrearEstructura = True

            End If
        End If
    End Sub

    Private Sub FrmCanvas_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp

        ModPOS.Superficie.Refresh()

        If CrearEstructura Then

            Me.NuevaEstructura(Punto1, Punto2)

            'Se actualiza el indice que indica la estructura seleccionada.
            ModPOS.Est_Selected = ModPOS.numEst_Vector - 1

            ModPOS.Estructuras = New FrmEstructura

            With ModPOS.Estructuras
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .UiTabPageUbc.Enabled = False
                .Text = "Nueva Estructura de Almacenaje"
                .StartPosition = FormStartPosition.CenterScreen
                .MdiParent = ModPOS.Principal
                .Clave = ModPOS.vector(ModPOS.Est_Selected).Name
                .dLargo = ModPOS.vector(ModPOS.Est_Selected).Largo
                .dAncho = ModPOS.vector(ModPOS.Est_Selected).Ancho
                .dX = ModPOS.vector(ModPOS.Est_Selected).OrigenX
                .dY = ModPOS.vector(ModPOS.Est_Selected).OrigenY
                .sAlmacen = ModPOS.Almacen_Activo
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub FrmCanvas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.DoubleClick
        If ModPOS.CrearAlm Is Nothing Then
           
           
            ModPOS.CrearAlm = New FrmCrearAlm
            ModPOS.CrearAlm.MdiParent = ModPOS.Principal
            ModPOS.CrearAlm.Text = "Modificar Almacén"
            ModPOS.CrearAlm.Padre = "Modificar"
            ModPOS.CrearAlm.TxtClave.Enabled = False

           

            With ModPOS.CrearAlm

                .ALMClave = Me.ALMClave
                .Clave = Me.Referencia
                .Nombre = Me.Nombre
                .Estado = Me.Estado
                .SUCClave = Me.SUCClave
                .Alto = Me.Alto
                .Largo = Me.Largo
                .Ancho = Me.Ancho
                .Escala = Me.Escala
                .BloqueoVta = Me.BloqueoVta
                .Predeterminado = Me.Predeterminado
                .TipoSurtido = Me.TipoSurtido
                .Stage = Me.stage

            End With
        End If
        ModPOS.CrearAlm.StartPosition = FormStartPosition.CenterScreen
        ModPOS.CrearAlm.Show()
        ModPOS.CrearAlm.BringToFront()

    End Sub

    '***********Eventos de las estructuras**********

    Public Sub Control_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        ' Cuando se pulsa con el ratón
        DX = e.X
        DY = e.Y

        If ModPOS.Est_Selected > -1 Then
            ModPOS.vector(ModPOS.Est_Selected).Selected = False
            ModPOS.vector(ModPOS.Est_Selected).BackColor = Color.FromArgb(ModPOS.vector(ModPOS.Est_Selected).Color)
        End If

        CType(sender, Estructura).Selected = True

        ModPOS.Est_Selected = CType(sender, Estructura).Indice
        CType(sender, Estructura).BringToFront()
        CType(sender, Estructura).BackColor = System.Drawing.Color.LightSteelBlue
        'ModPOS.redrawClave(CType(sender, Estructura), CType(sender, Estructura).Clave)

        With ModPOS.Principal
            .Copiar.Enabled = Janus.Windows.UI.InheritableBoolean.True
            .CopiarN.Enabled = Janus.Windows.UI.InheritableBoolean.True
            .Rotar.Enabled = Janus.Windows.UI.InheritableBoolean.True
            .Eliminar.Enabled = Janus.Windows.UI.InheritableBoolean.True
            .Fila.Enabled = Janus.Windows.UI.InheritableBoolean.True
            .Columna.Enabled = Janus.Windows.UI.InheritableBoolean.True
            .EliminarColumna.Enabled = Janus.Windows.UI.InheritableBoolean.True
            .EliminarFila.Enabled = Janus.Windows.UI.InheritableBoolean.True
            .Largo.Enabled = Janus.Windows.UI.InheritableBoolean.True
        End With
    End Sub

    Public Sub Control_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        ' Cuando se mueve el ratón y se pulsa el botón izquierdo... mover el control
        If e.Button = MouseButtons.Left Then
            CType(sender, Estructura).Left = e.X + CType(sender, Estructura).Left - DX
            CType(sender, Estructura).Top = e.Y + CType(sender, Estructura).Top - DY
            CType(sender, Estructura).OrigenX = CType(sender, Estructura).Location.X / ModPOS.EscalaActual
            CType(sender, Estructura).OrigenY = CType(sender, Estructura).Location.Y / ModPOS.EscalaActual

            ModPOS.Principal.StPanel3.Text = "X: " & CStr(ModPOS.Redondear(CType(sender, Estructura).OrigenX, 2)) & " Y: " & CStr(ModPOS.Redondear(CType(sender, Estructura).OrigenY, 2))
            CType(sender, Estructura).CambioPosicion = True
        End If

    End Sub

    Public Sub Control_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(sender, Estructura).BackColor = System.Drawing.Color.LightSteelBlue
        'ModPOS.redrawClave(CType(sender, Estructura), CType(sender, Estructura).Name)
        'CType(sender, Estructura).Refresh()
        With ModPOS.Principal
            .StPanel1.Text = "Estructura: " & CType(sender, Estructura).Clave
            .StPanel2.Text = "Largo: " & CStr(ModPOS.Redondear(CType(sender, Estructura).Largo, 2)) & " Ancho: " & CStr(ModPOS.Redondear(CType(sender, Estructura).Ancho, 2))
            .StPanel3.Text = "X: " & CStr(ModPOS.Redondear(CType(sender, Estructura).OrigenX, 2)) & " Y: " & CStr(ModPOS.Redondear(CType(sender, Estructura).OrigenY, 2))
        End With
    End Sub

    Public Sub Control_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        'Se actualiza el indice que indica la estructura seleccionada.
        ModPOS.Est_Selected = CType(sender, Estructura).Indice
        'verifica si la estructura ya se encuentra abierta.

        If ModPOS.Estructuras Is Nothing Then
            ModPOS.Estructuras = New FrmEstructura
            'inicializa estructura
            With ModPOS.Estructuras
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Modificar"
                .UiTabPageUbc.Enabled = True
                .Text = "Modificar Estructura de Almacenaje"
                .StartPosition = FormStartPosition.CenterScreen
                .MdiParent = ModPOS.Principal
                .sAlmacen = Me.ALMClave
                .Clave = CStr(CType(sender, Estructura).Name)
                .sArea = CStr(CType(sender, Estructura).AREClave)
                .iTESTClave = CInt(CType(sender, Estructura).TSTClave)
                .iTipoAplicacion = CInt(CType(sender, Estructura).TipoAplicacion)
                .sColoca = CType(sender, Estructura).PasilloColoca
                .sRecoge = CType(sender, Estructura).PasilloRecoge
                .iRotacion = CType(sender, Estructura).TipoRotacion

                .ID = CStr(CType(sender, Estructura).Clave)
                .dAlto = CStr(CType(sender, Estructura).Alto)
                .dLargo = CStr(CType(sender, Estructura).Largo)
                .dAncho = CType(sender, Estructura).Ancho
                .dX = CType(sender, Estructura).OrigenX
                .dY = CType(sender, Estructura).OrigenY
                .iColumna = CStr(CType(sender, Estructura).Columnas)
                .iNiveles = CInt(CType(sender, Estructura).Niveles)
                .iColor = CType(sender, Estructura).Color
                .Rotada = CType(sender, Estructura).Rotada
                .iformaEnvioInicial = CType(sender, Estructura).formaEnvioInicial
                .iformaEnviofinal = CType(sender, Estructura).formaEnvioFinal
                .iSecuenciaRecoleccion = CType(sender, Estructura).SecuenciaRecoleccion
                .Show()
                .BringToFront()

            End With
        Else
            With ModPOS.Estructuras
                .StartPosition = FormStartPosition.CenterScreen
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Public Sub Control_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim rotada As Boolean
        rotada = CType(sender, Estructura).Rotada
        If rotada Then
            ModPOS.Principal.StPanel2.Text = "Largo: " & CStr(ModPOS.Redondear(CType(sender, Estructura).Height / ModPOS.EscalaActual, 2)) & " Ancho: " & CStr(ModPOS.Redondear(CType(sender, Estructura).Width / ModPOS.EscalaActual, 2))
            CType(sender, Estructura).Largo = CDbl(CType(sender, Estructura).Height / ModPOS.EscalaActual)
            CType(sender, Estructura).Ancho = CDbl(CType(sender, Estructura).Width / ModPOS.EscalaActual)
        Else
            ModPOS.Principal.StPanel2.Text = "Largo: " & CStr(ModPOS.Redondear(CType(sender, Estructura).Width / ModPOS.EscalaActual, 2)) & " Ancho: " & CStr(ModPOS.Redondear(CType(sender, Estructura).Height / ModPOS.EscalaActual, 2))
            CType(sender, Estructura).Largo = CDbl(CType(sender, Estructura).Width / ModPOS.EscalaActual)
            CType(sender, Estructura).Ancho = CDbl(CType(sender, Estructura).Height / ModPOS.EscalaActual)
        End If
        CType(sender, Estructura).CambioTamaño = True
    End Sub

    Public Sub Control_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not CType(sender, Estructura).Selected Then
            CType(sender, Estructura).BackColor = Color.FromArgb(CType(sender, Estructura).Color)
        End If
        ' ModPOS.redrawClave(CType(sender, Estructura), CType(sender, Estructura).Name)
    End Sub

    Public Sub NuevaEstructura(ByVal p1 As Point, ByVal p2 As Point)
        Dim ESTClave As String
        
        ESTClave = ModPOS.obtenerLlave

        If ModPOS.numEst_Vector >= 2 Then
            ReDim Preserve vector(vector.Length)
        End If

        ModPOS.vector(ModPOS.numEst_Vector) = New Estructura(ESTClave, p1, p2)

        Me.Controls.Add(ModPOS.vector(ModPOS.numEst_Vector))

        AddHandler ModPOS.vector(ModPOS.numEst_Vector).MouseDown, AddressOf Me.Control_MouseDown
        AddHandler ModPOS.vector(ModPOS.numEst_Vector).MouseMove, AddressOf Me.Control_MouseMove
        AddHandler ModPOS.vector(ModPOS.numEst_Vector).MouseEnter, AddressOf Me.Control_MouseEnter
        AddHandler ModPOS.vector(ModPOS.numEst_Vector).SizeChanged, AddressOf Me.Control_SizeChanged
        AddHandler ModPOS.vector(ModPOS.numEst_Vector).DoubleClick, AddressOf Me.Control_DoubleClick
        AddHandler ModPOS.vector(ModPOS.numEst_Vector).MouseLeave, AddressOf Me.Control_MouseLeave


        ModPOS.numEst_Vector += 1
    End Sub

    Public Sub NuevaEstructura(ByVal Clave As String, ByVal Color As Integer, ByVal X As Double, ByVal Y As Double, ByVal W As Integer, ByVal H As Integer, ByVal R As Boolean)

        If ModPOS.numEst_Vector >= 2 Then
            ReDim Preserve vector(vector.Length)
        End If

        ModPOS.vector(ModPOS.numEst_Vector) = New Estructura(Clave, Color, X, Y, W, H, R)



        Me.Controls.Add(ModPOS.vector(ModPOS.numEst_Vector))

        AddHandler ModPOS.vector(ModPOS.numEst_Vector).MouseDown, AddressOf Me.Control_MouseDown
        AddHandler ModPOS.vector(ModPOS.numEst_Vector).MouseMove, AddressOf Me.Control_MouseMove
        AddHandler ModPOS.vector(ModPOS.numEst_Vector).MouseEnter, AddressOf Me.Control_MouseEnter
        AddHandler ModPOS.vector(ModPOS.numEst_Vector).SizeChanged, AddressOf Me.Control_SizeChanged
        AddHandler ModPOS.vector(ModPOS.numEst_Vector).DoubleClick, AddressOf Me.Control_DoubleClick
        AddHandler ModPOS.vector(ModPOS.numEst_Vector).MouseLeave, AddressOf Me.Control_MouseLeave


        ModPOS.numEst_Vector += 1
    End Sub

  
    Private Sub MenuItemReSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemReSize.Click
        ModPOS.CambiarEstilo(ModPOS.vector(ModPOS.Est_Selected))
    End Sub

    Private Sub MenuItemRotar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRotar.Click
        ModPOS.RotarEstructura(ModPOS.vector(ModPOS.Est_Selected))
    End Sub

    Private Sub MenuItemCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemCopy.Click
        ModPOS.CopiaEstructura(ModPOS.vector(ModPOS.Est_Selected), 1)
        ModPOS.Principal.Pegar.Enabled = Janus.Windows.UI.InheritableBoolean.True

    End Sub

    Private Sub CtxSuperficie_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CtxSuperficie.Popup
        If ModPOS.numEst_CpyVector = -1 Then
            CtxSuperficie.MenuItems.Item(1).Enabled = False
        Else
            CtxSuperficie.MenuItems.Item(1).Enabled = True
        End If
    End Sub

    Private Sub MenuItemZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemZoom.Click
        If ModPOS.Zoom Is Nothing Then
            ModPOS.Zoom = New FrmZoom
            ModPOS.Zoom.MdiParent = ModPOS.Principal
        End If
        ModPOS.Zoom.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Zoom.Show()
        ModPOS.Zoom.BringToFront()

        ModPOS.Zoom.Location = Me.Punto2
    End Sub

    Private Sub MenuItemPegar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemPegar.Click
        ModPOS.PegaEstructura(Me.Punto2)
        Me.Refresh()
        ModPOS.Principal.Pegar.Enabled = Janus.Windows.UI.InheritableBoolean.False
    End Sub

    Private Sub MenuItemDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemDelete.Click
        Beep()
        Select Case MessageBox.Show("Se eliminara la estructura de almacenaje : " & ModPOS.vector(ModPOS.Est_Selected).Clave, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            Case DialogResult.Yes
                Dim Con As String = ModPOS.BDConexion
                If ModPOS.SiExite(Con, "sp_estructura_vacia", "@Estructura", ModPOS.vector(ModPOS.Est_Selected).Name) <> 0 Then
                    MessageBox.Show("La estructura seleccionada no puede ser eliminada ya que existen ubicaciones ocupadas o apartadas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    ModPOS.Ejecuta("sp_elimina_estructura", "@Estructura", ModPOS.vector(ModPOS.Est_Selected).Name, "@Usuario", ModPOS.UsuarioActual)
                    ModPOS.vector(ModPOS.Est_Selected).Visible = False
                End If

            Case DialogResult.No
        End Select
    End Sub

End Class
