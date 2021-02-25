
Public Class FormUsuario
    Inherits System.Windows.Forms.Form
#If MOD_TERM <> "PALM" Then
    Private WithEvents bScanner As HANDHELD.CScanner
#End If
    Private bLector As Boolean = False
    Public refaVista As Vista

    Public ReadOnly Property Clave() As String
        Get
            Return DetailViewRegistro.Items("TextBoxUsuario").Text
        End Get
    End Property

    Public ReadOnly Property Contrasena() As String
        Get
            Return DetailViewRegistro.Items("TextBoxContrasena").Text
        End Get
    End Property

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If Not IsNothing(Me.MenuItemActualizar) Then MenuItemActualizar.Dispose()
            If Not IsNothing(Me.MenuItemEliminar) Then MenuItemEliminar.Dispose()
            If Not IsNothing(Me.MenuItemEliminarTodo) Then MenuItemEliminarTodo.Dispose()
            If Not IsNothing(Me.MenuItemOpciones) Then MenuItemOpciones.Dispose()
            If Not IsNothing(Me.MainMenuRegistro) Then MainMenuRegistro.Dispose()
            If Not IsNothing(DetailViewRegistro) Then DetailViewRegistro.Dispose()
            If Not IsNothing(PictureBoxFondo2) Then PictureBoxFondo2.Dispose()
            If Not IsNothing(PictureBox1) Then PictureBox1.Dispose()
        Catch ex As Exception

        End Try


        MyBase.Dispose(disposing)
    End Sub

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LabelBienvenido As System.Windows.Forms.Label
    Private WithEvents DetailViewRegistro As Resco.Controls.DetailView.DetailView
    Friend WithEvents ButtonEntrar As System.Windows.Forms.Button
    Friend WithEvents ButtonSalir As System.Windows.Forms.Button
    Friend WithEvents PanelRegistro As System.Windows.Forms.Panel
    Friend WithEvents PictureBoxFondo2 As System.Windows.Forms.PictureBox
    Friend WithEvents MainMenuRegistro As System.Windows.Forms.MainMenu
    Friend WithEvents InputPanelRegistro As Microsoft.WindowsCE.Forms.InputPanel
    Friend WithEvents MenuItemOpciones As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemEliminarTodo As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemEliminar As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemInterrogacion As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemAcercaDe As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemActualizar As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormUsuario))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PanelRegistro = New System.Windows.Forms.Panel
        Me.LabelBienvenido = New System.Windows.Forms.Label
        Me.ButtonEntrar = New System.Windows.Forms.Button
        Me.ButtonSalir = New System.Windows.Forms.Button
        Me.DetailViewRegistro = New Resco.Controls.DetailView.DetailView
        Me.MainMenuRegistro = New System.Windows.Forms.MainMenu
        Me.MenuItemOpciones = New System.Windows.Forms.MenuItem
        Me.MenuItemActualizar = New System.Windows.Forms.MenuItem
        Me.MenuItemEliminarTodo = New System.Windows.Forms.MenuItem
        Me.MenuItemEliminar = New System.Windows.Forms.MenuItem
        Me.MenuItemInterrogacion = New System.Windows.Forms.MenuItem
        Me.MenuItemAcercaDe = New System.Windows.Forms.MenuItem
        Me.InputPanelRegistro = New Microsoft.WindowsCE.Forms.InputPanel
        Me.PictureBoxFondo2 = New System.Windows.Forms.PictureBox
        Me.PanelRegistro.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(17, 28)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(192, 76)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'PanelRegistro
        '
        Me.PanelRegistro.BackColor = System.Drawing.Color.White
        Me.PanelRegistro.Controls.Add(Me.PictureBox1)
        Me.PanelRegistro.Controls.Add(Me.LabelBienvenido)
        Me.PanelRegistro.Controls.Add(Me.ButtonEntrar)
        Me.PanelRegistro.Controls.Add(Me.ButtonSalir)
        Me.PanelRegistro.Controls.Add(Me.DetailViewRegistro)
        Me.PanelRegistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelRegistro.Location = New System.Drawing.Point(0, 0)
        Me.PanelRegistro.Name = "PanelRegistro"
        Me.PanelRegistro.Size = New System.Drawing.Size(240, 292)
        '
        'LabelBienvenido
        '
        Me.LabelBienvenido.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LabelBienvenido.ForeColor = System.Drawing.Color.DarkMagenta
        Me.LabelBienvenido.Location = New System.Drawing.Point(18, 128)
        Me.LabelBienvenido.Name = "LabelBienvenido"
        Me.LabelBienvenido.Size = New System.Drawing.Size(196, 24)
        Me.LabelBienvenido.Text = "LabelBienvenido"
        Me.LabelBienvenido.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ButtonEntrar
        '
        Me.ButtonEntrar.Location = New System.Drawing.Point(16, 230)
        Me.ButtonEntrar.Name = "ButtonEntrar"
        Me.ButtonEntrar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonEntrar.TabIndex = 2
        Me.ButtonEntrar.Text = "ButtonEntrar"
        '
        'ButtonSalir
        '
        Me.ButtonSalir.Location = New System.Drawing.Point(96, 230)
        Me.ButtonSalir.Name = "ButtonSalir"
        Me.ButtonSalir.Size = New System.Drawing.Size(74, 24)
        Me.ButtonSalir.TabIndex = 3
        Me.ButtonSalir.Text = "ButtonSalir"
        '
        'DetailViewRegistro
        '
        Me.DetailViewRegistro.BackColor = System.Drawing.Color.WhiteSmoke
        Me.DetailViewRegistro.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DetailViewRegistro.LabelWidth = 100
        Me.DetailViewRegistro.Location = New System.Drawing.Point(15, 170)
        Me.DetailViewRegistro.Name = "DetailViewRegistro"
        Me.DetailViewRegistro.SeparatorWidth = 6
        Me.DetailViewRegistro.Size = New System.Drawing.Size(204, 40)
        Me.DetailViewRegistro.TabIndex = 4
        '
        'MainMenuRegistro
        '
        Me.MainMenuRegistro.MenuItems.Add(Me.MenuItemOpciones)
        Me.MainMenuRegistro.MenuItems.Add(Me.MenuItemInterrogacion)
        '
        'MenuItemOpciones
        '
        Me.MenuItemOpciones.MenuItems.Add(Me.MenuItemActualizar)
        Me.MenuItemOpciones.MenuItems.Add(Me.MenuItemEliminarTodo)
        Me.MenuItemOpciones.MenuItems.Add(Me.MenuItemEliminar)
        Me.MenuItemOpciones.Text = "MenuItemOpciones"
        '
        'MenuItemActualizar
        '
        Me.MenuItemActualizar.Text = "MenuItemActualizar"
        '
        'MenuItemEliminarTodo
        '
        Me.MenuItemEliminarTodo.Text = "MenuItemEliminarTodo"
        '
        'MenuItemEliminar
        '
        Me.MenuItemEliminar.Text = "MenuItemEliminar"
        '
        'MenuItemInterrogacion
        '
        Me.MenuItemInterrogacion.MenuItems.Add(Me.MenuItemAcercaDe)
        Me.MenuItemInterrogacion.Text = "MenuItemInterrogacion"
        '
        'MenuItemAcercaDe
        '
        Me.MenuItemAcercaDe.Text = "Acerca De"
        '
        'PictureBoxFondo2
        '
        Me.PictureBoxFondo2.Image = CType(resources.GetObject("PictureBoxFondo2.Image"), System.Drawing.Image)
        Me.PictureBoxFondo2.Location = New System.Drawing.Point(-4, 0)
        Me.PictureBoxFondo2.Name = "PictureBoxFondo2"
        Me.PictureBoxFondo2.Size = New System.Drawing.Size(244, 272)
        Me.PictureBoxFondo2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'FormUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(240, 292)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelRegistro)
        Me.Controls.Add(Me.PictureBoxFondo2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuRegistro
        Me.MinimizeBox = False
        Me.Name = "FormUsuario"
        Me.Text = "Amesol Route"
        Me.PanelRegistro.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Private Sub FormUsuario_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    'ProponerPrimerItem()
    'End Sub
    Private Sub ActivarScanner()
        'If oModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Cargas Then
#If MOD_TERM <> "PALM" Then
        If Not bLector Then
            Select Case oApp.ModeloTerminal
                Case "Generico"

                Case "SymbolC9090", "SymbolMC50", "SymbolMC70"
                    Try
                        bScanner.Inicialize_Scanner(HANDHELD.SO.SymbolPCMC50)
                        bLector = True
                    Catch ex As Exception
                        MsgBox("Error while starting the scanner:" & ex.Message, MsgBoxStyle.Critical)
                    End Try
                Case "HHP7600"
                    bScanner.Inicialize_Scanner(HANDHELD.SO.HHP7600)
                    bLector = True
                Case "HHP7900"
                    bScanner.Inicialize_Scanner(HANDHELD.SO.HHP7900)
                    bLector = True
                Case "HHPWM6"
                    bScanner.Inicialize_Scanner(HANDHELD.SO.HHPWM6)
                    bLector = True
                Case "IntermecCN3"
                    bScanner.Inicialize_Scanner(HANDHELD.SO.IntermecCN3)
                    bLector = True
                Case "SymbolMC55"
                    bScanner.Inicialize_Scanner(HANDHELD.SO.SymbolMC55)
                    bLector = True
            End Select
        End If
#End If
        'End If
    End Sub

    Private Sub DesactivarScanner()
        'If oModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Cargas Then
#If MOD_TERM <> "PALM" Then
        Try
            bScanner.Terminate_Scanner()
            bLector = False
        Catch ex As Exception
            MsgBox("Error while stopping the scanner:" & ex.Message, MsgBoxStyle.Critical)
        End Try
#End If
        'End If
    End Sub

    Private Sub FormRegistro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        ' Crear los componentes en pantalla
        If Not Vista.Buscar("FormRegistro", refaVista) Then
            Exit Sub
        End If
#If MOD_TERM <> "PALM" Then
        bScanner = New HANDHELD.CScanner
#End If
        ActivarScanner()
        DesactivarScanner()


        refaVista.CrearDetailView(DetailViewRegistro, "DetailViewRegistro")
        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos
        refaVista.ColocarEtiquetasForma(Me)
        MostrarValoresUsuario()
        'LabelVersion.Text = "MobileClient v" & PubsVersion
        Me.ProponerPrimerItem()

    End Sub

    Private Sub MostrarValoresUsuario()
        ' Asignar el password al textbox
        Dim refTextBox As Resco.Controls.DetailView.ItemTextBox
        refTextBox = DetailViewRegistro.Items("TextBoxContrasena")
        refTextBox.PasswordChar = "*"
        refTextBox.Text = oApp.Contrasena
        ' Asignar el id de usuario al textbox
        refTextBox = DetailViewRegistro.Items("TextBoxUsuario")
        refTextBox.Text = oApp.Usuario.Clave
        refTextBox.MultiLine = False
    End Sub

    Private Sub Salir()
        If MsgBox(refaVista.BuscarMensaje("MsgBox", "SeguroSalir"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.PanelRegistro.Visible = False
            Me.Refresh()
            FormProcesando.PubSubInformar(refaVista.BuscarMensaje("ProcesandoRegistro", "Saliendo"))
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            Me.ProponerPrimerItem()
        End If
    End Sub

    Private Sub ProponerPrimerItem()
        If IsNothing(DetailViewRegistro) Then Exit Sub
        Dim refTextBox As Resco.Controls.DetailView.ItemTextBox
        ' Proponer el primer elemento
        refTextBox = DetailViewRegistro.Items("TextBoxUsuario")
        Me.DetailViewRegistro.SelectedItem = refTextBox
        refTextBox.SetFocus()
    End Sub

    Private Sub TerminarForma()
        If oApp.Usuario.Clave <> Me.Clave Then
            If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0108"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                ProponerPrimerItem()
                Exit Sub
            End If
        End If
        FormProcesando.PubSubInformar(refaVista.BuscarMensaje("ProcesandoRegistro", "Verificando"))
        Me.DialogResult = Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub ButtonSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSalir.Click
        Me.Salir()
    End Sub

    Private Sub ButtonEntrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEntrar.Click
        Me.TerminarForma()
    End Sub

    Private Sub MenuItemActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemActualizar.Click
        PanelRegistro.Enabled = True
        Try
            Me.Refresh()
            Dim FormComApp As New FormComunicacion(ServicesCentral.TiposBase.Aplicacion)
            If FormComApp.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ' Cargar los arreglos con los mensajes de estados
                ValorReferencia.Llenar()
                ' Cargar las vistas a memoria
                Vista.Llenar()
                If Vista.Buscar("FormRegistro", refaVista) Then
                    refaVista.ColocarEtiquetasForma(Me)
                    Me.Refresh()
                End If
                Vista.Buscar("FormGlobal", gVista)
            End If
            FormComApp.Dispose()
            FormComApp = Nothing
            MostrarValoresUsuario()
        Catch ExcA As Exception
            MsgBox(ExcA.Message, MsgBoxStyle.Critical)
        End Try
        PanelRegistro.Enabled = True
        Me.Refresh()
    End Sub

    Private Sub DetailViewRegistro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DetailViewRegistro.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Enter)
                e.Handled = True
                Dim refTextBox As Resco.Controls.DetailView.ItemTextBox = Me.DetailViewRegistro.SelectedItem
                If IsNothing(refTextBox) Then
                    Me.TerminarForma()
                    Exit Sub
                End If
                If refTextBox.Index < Me.DetailViewRegistro.Items.Count - 1 Then
                    refTextBox = Me.DetailViewRegistro.Items(refTextBox.Index + 1)
                    Me.DetailViewRegistro.SelectedItem = refTextBox
                Else
                    Me.TerminarForma()
                End If
            Case Microsoft.VisualBasic.ChrW(Keys.Escape)
                e.Handled = True
                Me.Salir()
        End Select

    End Sub

    Private Sub MenuItemEliminarTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemEliminarTodo.Click
        FormProcesando.PubSubTitulo("")
        FormProcesando.PubSubInformar(refaVista.BuscarMensaje("MsgBox", "I0123"), "")
        Dim usuTmp As New Usuario()
        FormProcesando.PubSubEstado(refaVista.BuscarMensaje("ProcesandoRegistro", "Verificando"))
        If usuTmp.Recuperar(Clave, Contrasena) Then
            If System.IO.File.Exists(oApp.RutaTrabajo & "\" & usuTmp.UsuarioId & ".sdf") Then
                oVendedor = New Vendedor(usuTmp)
                If oVendedor.AbrirDB() Then
                    oVendedor.RecuperarParametros(True)
                    Dim AObj As Object = oDBVen.EjecutarCmdScalarObjSQL("Select VEJFechaInicial From VendedorJornada Where VendedorId='" & oVendedor.VendedorId & "' and FechaFinal IS NULL")
                    If Not Convert.ToBoolean(oConHist.Campos("EliminaEnviado")) Then
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0551"), MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    If Not IsNothing(AObj) And Not IsDBNull(AObj) Then
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0490").Replace("$0$", AObj.ToString()), MsgBoxStyle.Information)
                        Exit Sub
                    End If
                End If
            Else
                FormProcesando.PubSubInformar()
                Exit Sub
            End If
        Else
            MsgBox(refaVista.BuscarMensaje("MsgBox", "NoValido"), MsgBoxStyle.Information Or MsgBoxStyle.SystemModal)
            FormProcesando.PubSubInformar()
            Exit Sub
        End If
        FormProcesando.PubSubInformar(refaVista.BuscarMensaje("MsgBox", "I0123"), "")
        If (Not HayDatoSinDescargar()) Then

            If (MsgBox(refaVista.BuscarMensaje("MsgBox", "P0077"), MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Question) = MsgBoxResult.Yes) Then
                FormProcesando.PubSubInformar(refaVista.BuscarMensaje("MsgBox", "I0124"), "")
                Dim fallo As Boolean = False
                If Not System.IO.File.Exists(oApp.RutaTrabajo & "\" & oApp.ClaveTerminal & ".sdf") Then
                    fallo = True
                End If
                If Not fallo Then
                    Dim oAppVer As New VersionesLicencias
                    Dim sUsuario As String = ""
                    Dim DataTableDatos As DataTable = oAppVer.RealizarConsultaSQL("SELECT USUId,Clave,Nombre,PERClave FROM Usuario WHERE Clave='" & oApp.Usuario.Clave & "'", "Usuario", oApp.ClaveTerminal & ".sdf")

                    If DataTableDatos.Rows.Count = 1 Then
                        With DataTableDatos.Rows(0)
                            sUsuario = .Item("USUId")
                        End With
                        DataTableDatos.Dispose()
                    End If
                    DataTableDatos.Dispose()

                    System.IO.File.Delete(oApp.RutaTrabajo & "\" & sUsuario & ".sdf")
                    System.IO.File.Delete(oApp.RutaTrabajo & "\" & sUsuario & ".xml")
                    _BorrarArchivo = oApp.RutaTrabajo & "\" & oApp.ClaveTerminal
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "I0110"), MsgBoxStyle.Information)
                End If
                _ReIniciarRoute = True
                Me.Close()
            End If
        Else
            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0549"), MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub MenuItemEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemEliminar.Click
        FormProcesando.PubSubTitulo("")

        Dim usuTmp As New Usuario()
        FormProcesando.PubSubEstado(refaVista.BuscarMensaje("ProcesandoRegistro", "Verificando"))
        If usuTmp.Recuperar(Clave, Contrasena) Then
            If System.IO.File.Exists(oApp.RutaTrabajo & "\" & usuTmp.UsuarioId & ".sdf") Then
                oVendedor = New Vendedor(usuTmp)
                If oVendedor.AbrirDB() Then
                    oVendedor.RecuperarParametros(True)
                    Dim AObj As Object = oDBVen.EjecutarCmdScalarObjSQL("Select VEJFechaInicial From VendedorJornada Where VendedorId='" & oVendedor.VendedorId & "' and FechaFinal IS NULL")
                    If Not Convert.ToBoolean(oConHist.Campos("EliminaEnviado")) Then
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0551"), MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    If Not IsNothing(AObj) And Not IsDBNull(AObj) Then
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0490").Replace("$0$", AObj.ToString()), MsgBoxStyle.Information)
                        Exit Sub
                    End If
                End If
            Else
                FormProcesando.PubSubInformar()
                Exit Sub
            End If
        Else
            MsgBox(refaVista.BuscarMensaje("MsgBox", "NoValido"), MsgBoxStyle.Information Or MsgBoxStyle.SystemModal)
            FormProcesando.PubSubInformar()
            Exit Sub
        End If
        FormProcesando.PubSubInformar(refaVista.BuscarMensaje("MsgBox", "I0123"), "")
        If (Not HayDatoSinDescargar()) Then

            Dim fallo As Boolean = False
            If Not System.IO.File.Exists(oApp.RutaTrabajo & "\" & oApp.ClaveTerminal & ".sdf") Then
                fallo = True
            End If
            If Not fallo Then
                Dim oAppVer As New VersionesLicencias
                Dim sUsuario As String = ""
                Dim DataTableDatos As DataTable = oAppVer.RealizarConsultaSQL("SELECT USUId,Clave,Nombre,PERClave FROM Usuario WHERE Clave='" & oApp.Usuario.Clave & "'", "Usuario", oApp.ClaveTerminal & ".sdf")

                If DataTableDatos.Rows.Count = 1 Then
                    With DataTableDatos.Rows(0)
                        sUsuario = .Item("USUId")
                    End With
                    DataTableDatos.Dispose()
                End If
                DataTableDatos.Dispose()

                If Not System.IO.File.Exists(oApp.RutaTrabajo & "\" & sUsuario & ".sdf") Then
                    fallo = True
                Else
                    FormProcesando.PubSubInformar(refaVista.BuscarMensaje("MsgBox", "I0111"), "")
                    EliminarTodosEnviados()
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "I0110"), MsgBoxStyle.Information)
                End If
            End If
        Else
            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0549"))
        End If

    End Sub
    Public Shared Sub EliminarTodosEnviados()
        EliminarDatosEnviados()
        oVendedor.CerrarDB()
    End Sub
    Private Sub MenuItemAcercaDe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemAcercaDe.Click
        Dim AcercaDe As New FormAcercaDe
        AcercaDe.ShowDialog()
        AcercaDe.Dispose()
        AcercaDe = Nothing
    End Sub
End Class
