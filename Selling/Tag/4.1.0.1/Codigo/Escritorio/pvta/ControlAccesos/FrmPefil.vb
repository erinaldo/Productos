Public Class FrmPerfil
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
    Friend WithEvents GrpSinAsignar As System.Windows.Forms.GroupBox
    Friend WithEvents GrpAsignados As System.Windows.Forms.GroupBox
    Friend WithEvents cmdTodosIzq As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmdUnoIzq As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmdTodosDer As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmdUnoDer As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnOk As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents TvAsignado As System.Windows.Forms.TreeView
    Friend WithEvents TvDisponible As System.Windows.Forms.TreeView
    Friend WithEvents ChkAjusta As Selling.ChkStatus
    Friend WithEvents ChkEstado As Selling.ChkStatus
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPerfil))
        Me.GrpSinAsignar = New System.Windows.Forms.GroupBox()
        Me.TvDisponible = New System.Windows.Forms.TreeView()
        Me.TvAsignado = New System.Windows.Forms.TreeView()
        Me.GrpAsignados = New System.Windows.Forms.GroupBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.cmdTodosIzq = New Janus.Windows.EditControls.UIButton()
        Me.cmdUnoIzq = New Janus.Windows.EditControls.UIButton()
        Me.cmdTodosDer = New Janus.Windows.EditControls.UIButton()
        Me.cmdUnoDer = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnOk = New Janus.Windows.EditControls.UIButton()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TxtClave = New System.Windows.Forms.TextBox()
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.ChkAjusta = New Selling.ChkStatus(Me.components)
        Me.GrpSinAsignar.SuspendLayout()
        Me.GrpAsignados.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpSinAsignar
        '
        Me.GrpSinAsignar.Controls.Add(Me.TvDisponible)
        Me.GrpSinAsignar.Location = New System.Drawing.Point(10, 110)
        Me.GrpSinAsignar.Name = "GrpSinAsignar"
        Me.GrpSinAsignar.Size = New System.Drawing.Size(220, 282)
        Me.GrpSinAsignar.TabIndex = 4
        Me.GrpSinAsignar.TabStop = False
        Me.GrpSinAsignar.Text = "Actividades Disponibles"
        '
        'TvDisponible
        '
        Me.TvDisponible.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TvDisponible.Location = New System.Drawing.Point(5, 18)
        Me.TvDisponible.Name = "TvDisponible"
        Me.TvDisponible.Size = New System.Drawing.Size(209, 259)
        Me.TvDisponible.TabIndex = 57
        '
        'TvAsignado
        '
        Me.TvAsignado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TvAsignado.Location = New System.Drawing.Point(6, 18)
        Me.TvAsignado.Name = "TvAsignado"
        Me.TvAsignado.Size = New System.Drawing.Size(209, 259)
        Me.TvAsignado.TabIndex = 11
        '
        'GrpAsignados
        '
        Me.GrpAsignados.Controls.Add(Me.TvAsignado)
        Me.GrpAsignados.Controls.Add(Me.PictureBox3)
        Me.GrpAsignados.Location = New System.Drawing.Point(269, 110)
        Me.GrpAsignados.Name = "GrpAsignados"
        Me.GrpAsignados.Size = New System.Drawing.Size(221, 282)
        Me.GrpAsignados.TabIndex = 9
        Me.GrpAsignados.TabStop = False
        Me.GrpAsignados.Text = "Actividades Asignadas"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(107, 2)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox3.TabIndex = 57
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'cmdTodosIzq
        '
        Me.cmdTodosIzq.Image = CType(resources.GetObject("cmdTodosIzq.Image"), System.Drawing.Image)
        Me.cmdTodosIzq.Location = New System.Drawing.Point(234, 290)
        Me.cmdTodosIzq.Name = "cmdTodosIzq"
        Me.cmdTodosIzq.Size = New System.Drawing.Size(30, 30)
        Me.cmdTodosIzq.TabIndex = 8
        Me.cmdTodosIzq.ToolTipText = "Remover todas las actividades de la asignación"
        '
        'cmdUnoIzq
        '
        Me.cmdUnoIzq.Image = CType(resources.GetObject("cmdUnoIzq.Image"), System.Drawing.Image)
        Me.cmdUnoIzq.Location = New System.Drawing.Point(234, 260)
        Me.cmdUnoIzq.Name = "cmdUnoIzq"
        Me.cmdUnoIzq.Size = New System.Drawing.Size(30, 30)
        Me.cmdUnoIzq.TabIndex = 7
        Me.cmdUnoIzq.ToolTipText = "Remover la actividad seleccionada de la asignación"
        '
        'cmdTodosDer
        '
        Me.cmdTodosDer.Image = CType(resources.GetObject("cmdTodosDer.Image"), System.Drawing.Image)
        Me.cmdTodosDer.Location = New System.Drawing.Point(234, 231)
        Me.cmdTodosDer.Name = "cmdTodosDer"
        Me.cmdTodosDer.Size = New System.Drawing.Size(30, 30)
        Me.cmdTodosDer.TabIndex = 6
        Me.cmdTodosDer.ToolTipText = "Asignar todas las actividades"
        '
        'cmdUnoDer
        '
        Me.cmdUnoDer.Image = CType(resources.GetObject("cmdUnoDer.Image"), System.Drawing.Image)
        Me.cmdUnoDer.Location = New System.Drawing.Point(234, 201)
        Me.cmdUnoDer.Name = "cmdUnoDer"
        Me.cmdUnoDer.Size = New System.Drawing.Size(30, 30)
        Me.cmdUnoDer.TabIndex = 5
        Me.cmdUnoDer.ToolTipText = "Asignar actividad seleccionada"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(291, 411)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 11
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnOk
        '
        Me.BtnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOk.Image = CType(resources.GetObject("BtnOk.Image"), System.Drawing.Image)
        Me.BtnOk.Location = New System.Drawing.Point(397, 411)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(90, 37)
        Me.BtnOk.TabIndex = 10
        Me.BtnOk.Text = "&Aceptar"
        Me.BtnOk.ToolTipText = "Guardar cambios"
        Me.BtnOk.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(120, 45)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(233, 20)
        Me.TxtNombre.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(7, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 21)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Nombre"
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(7, 22)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(83, 22)
        Me.LblClave.TabIndex = 29
        Me.LblClave.Text = "Clave"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(260, 22)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 31
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(360, 45)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 14)
        Me.PictureBox2.TabIndex = 33
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'TxtClave
        '
        Me.TxtClave.Enabled = False
        Me.TxtClave.Location = New System.Drawing.Point(120, 22)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(120, 20)
        Me.TxtClave.TabIndex = 1
        '
        'ChkEstado
        '
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(422, 0)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(59, 22)
        Me.ChkEstado.TabIndex = 56
        Me.ChkEstado.Text = "Activo"
        '
        'ChkAjusta
        '
        Me.ChkAjusta.Location = New System.Drawing.Point(120, 71)
        Me.ChkAjusta.Name = "ChkAjusta"
        Me.ChkAjusta.Size = New System.Drawing.Size(144, 22)
        Me.ChkAjusta.TabIndex = 57
        Me.ChkAjusta.Text = "Ajusta Existencia"
        '
        'FrmPerfil
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(513, 460)
        Me.Controls.Add(Me.ChkAjusta)
        Me.Controls.Add(Me.ChkEstado)
        Me.Controls.Add(Me.TxtClave)
        Me.Controls.Add(Me.TxtNombre)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblClave)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.GrpSinAsignar)
        Me.Controls.Add(Me.GrpAsignados)
        Me.Controls.Add(Me.cmdTodosIzq)
        Me.Controls.Add(Me.cmdUnoIzq)
        Me.Controls.Add(Me.cmdTodosDer)
        Me.Controls.Add(Me.cmdUnoDer)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnOk)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPerfil"
        Me.Text = "FrmPefil"
        Me.GrpSinAsignar.ResumeLayout(False)
        Me.GrpAsignados.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Padre As String
    Public PERClave As String
    Public Nombre As String
    Public Estado As Integer
    Public Ajusta As Integer

    Public sITMKey As String = ""
    Public sNombre As String = ""
    Public iEstado As Integer = 1

    Private alerta(2) As PictureBox
    Private reloj As parpadea


    Private dataSetAsignados As Data.DataSet
    Private dataSetDisponibles As Data.DataSet

    Private Sub CrearNodosDisponibles(ByVal indicePadre As Integer, ByVal nodePadre As TreeNode)

        Dim dataViewHijos As DataView

        dataViewHijos = New DataView(dataSetDisponibles.Tables("Disponibles"))
        dataViewHijos.RowFilter = dataSetDisponibles.Tables("Disponibles").Columns("IdentificadorPadre").ColumnName + " = " + indicePadre.ToString()

        ' Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
        For Each dataRowCurrent As DataRowView In dataViewHijos

            Dim nuevoNodo As New TreeNode
            nuevoNodo.Text = dataRowCurrent("NombreNodo").ToString().Trim()
            nuevoNodo.Tag = dataRowCurrent("IdentificadorNodo").ToString().Trim()
            ' si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
            ' del primer nivel que no dependen de otro nodo.
            If nodePadre Is Nothing Then
                TvDisponible.Nodes.Add(nuevoNodo)
                ' Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.
                CrearNodosDisponibles(Int32.Parse(dataRowCurrent("IdentificadorNodo").ToString()), nuevoNodo)
            Else
                ' se añade el nuevo nodo al nodo padre.

                nodePadre.Nodes.Add(nuevoNodo)
            End If

        Next dataRowCurrent

    End Sub

    Private Sub CrearNodosAsignados(ByVal indicePadre As Integer, ByVal nodePadre As TreeNode)

        Dim dataViewHijos As DataView


        ' Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
        dataViewHijos = New DataView(dataSetAsignados.Tables("Asignados"))
        dataViewHijos.RowFilter = dataSetAsignados.Tables("Asignados").Columns("IdentificadorPadre").ColumnName + " = " + indicePadre.ToString()

        ' Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
        For Each dataRowCurrent As DataRowView In dataViewHijos

            Dim nuevoNodo As New TreeNode
            nuevoNodo.Text = dataRowCurrent("NombreNodo").ToString().Trim()
            nuevoNodo.Tag = dataRowCurrent("IdentificadorNodo").ToString().Trim()
            ' si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
            ' del primer nivel que no dependen de otro nodo.
            If nodePadre Is Nothing Then
                TvAsignado.Nodes.Add(nuevoNodo)

                ' Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.
                CrearNodosAsignados(Int32.Parse(dataRowCurrent("IdentificadorNodo").ToString()), nuevoNodo)
            Else
                ' se añade el nuevo nodo al nodo padre.

                nodePadre.Nodes.Add(nuevoNodo)
            End If

        Next dataRowCurrent

    End Sub

    Private Sub actualizaTreeDisponibles()
        dataSetDisponibles = ModPOS.recuperaTabla_DTS("sp_filtra_item", "Disponibles", "@Perfil", Me.sITMKey)
        CrearNodosDisponibles(0, Nothing)
        dataSetDisponibles.Dispose()
    End Sub

    Private Sub actualizaTreeAsignados()
        dataSetAsignados = ModPOS.recuperaTabla_DTS("sp_filtra_peritem", "Asignados", "@Perfil", Me.sITMKey)
        CrearNodosAsignados(0, Nothing)
        dataSetAsignados.Dispose()
    End Sub

    Private Sub moverDerecha(ByRef node As TreeNode)
        If node.Nodes.Count > 0 Then
            Dim tvNodo As TreeNode
            Do
                For Each tvNodo In node.Nodes
                    If Not tvNodo Is Nothing Then
                        TvDisponible.Nodes.Remove(tvNodo)
                        TvAsignado.Nodes(node.Index).Nodes.Add(tvNodo)
                    End If
                Next
            Loop While node.Nodes.Count > 0
        End If
    End Sub

    Private Sub moverIzquierda(ByRef node As TreeNode)
        If node.Nodes.Count > 0 Then
            Dim tvNodo As TreeNode
            Do
                For Each tvNodo In node.Nodes
                    If Not tvNodo Is Nothing Then
                        TvAsignado.Nodes.Remove(tvNodo)
                        TvDisponible.Nodes(node.Index).Nodes.Add(tvNodo)
                    End If
                Next
            Loop While node.Nodes.Count > 0
        End If
    End Sub

    Private Sub addAsignados(ByRef node As TreeNode)
        If node.Nodes.Count > 0 Then
            Dim tvNodo As TreeNode
            For Each tvNodo In node.Nodes
                ModPOS.Ejecuta("sp_inserta_PERItem", "@Perfil", Me.TxtClave.Text, "@Item", tvNodo.Tag)
            Next
        End If
    End Sub

    Private Sub Selecciones(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles cmdUnoDer.Click, cmdTodosDer.Click, cmdUnoIzq.Click, cmdTodosIzq.Click
       
        Dim tvNodo As TreeNode
        Dim Index As Integer

        If sender Is cmdUnoDer Then
            If Not TvDisponible.SelectedNode Is Nothing AndAlso Not TvDisponible.SelectedNode.Parent Is Nothing Then
                tvNodo = TvDisponible.SelectedNode
                Index = TvDisponible.SelectedNode.Parent.Index
                TvDisponible.Nodes.Remove(tvNodo)
                TvAsignado.Nodes(Index).Nodes.Add(tvNodo)
            End If

        ElseIf sender Is cmdTodosDer Then
            Dim nodoPadre As TreeNode
            For Each nodoPadre In TvDisponible.Nodes
                moverDerecha(nodoPadre)
            Next

        ElseIf sender Is cmdUnoIzq Then
            If Not TvAsignado.SelectedNode Is Nothing AndAlso Not TvAsignado.SelectedNode.Parent Is Nothing Then
                tvNodo = TvAsignado.SelectedNode
                Index = TvAsignado.SelectedNode.Parent.Index
                TvAsignado.Nodes.Remove(tvNodo)
                TvDisponible.Nodes(Index).Nodes.Add(tvNodo)
            End If

        ElseIf sender Is cmdTodosIzq Then
            Dim nodoPadre As TreeNode
            For Each nodoPadre In TvAsignado.Nodes
                moverIzquierda(nodoPadre)
            Next
        End If
    End Sub

    Private Sub FrmPerfil_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Perfil.Dispose()
        ModPOS.Perfil = Nothing
    End Sub

    Private Sub FrmPerfil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3


        Me.ChkEstado.Estado = Me.iEstado
        Me.TxtClave.Text = Me.sITMKey
        Me.TxtNombre.Text = Me.sNombre
        ChkAjusta.Estado = Ajusta

        actualizaTreeDisponibles()
        actualizaTreeAsignados()

    End Sub

    Private Sub reinicializa()
        sITMKey = ""
        sNombre = ""
        iEstado = 1
        ChkAjusta.Estado = 0
        Me.ChkEstado.Estado = Me.iEstado
        Me.TxtClave.Text = Me.sITMKey
        Me.TxtNombre.Text = Me.sNombre

    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If Me.validaForm Then
            Select Case Me.Padre
                Case "Nuevo"

                    Me.Nombre = UCase(Trim(Me.TxtNombre.Text))
                    Me.Estado = 1
                    Ajusta = ChkAjusta.GetEstado
                    ModPOS.Ejecuta("sp_inserta_perfil", "@Nombre", Nombre, "@Ajusta", Ajusta, "@Estado", Estado, "@Usuario", ModPOS.UsuarioActual)
                    Me.TxtClave.Text = Me.recuperaClave(Me.Nombre)


                    Dim nodoPadre As TreeNode
                    For Each nodoPadre In TvAsignado.Nodes
                        addAsignados(nodoPadre)
                    Next

                    reinicializa()

                Case "Modificar"

                    Me.PERClave = UCase(Trim(Me.TxtClave.Text))
                    Me.Nombre = UCase(Trim(Me.TxtNombre.Text))
                    Me.Estado = ChkEstado.GetEstado

                    If Not (Me.Nombre = Me.sNombre And Me.Estado = Me.iEstado And Ajusta = ChkAjusta.GetEstado) Then
                        Ajusta = ChkAjusta.GetEstado
                        ModPOS.Ejecuta("sp_actualiza_perfil", "@Clave", PERClave, "@Nombre", Nombre, "@Ajusta", Ajusta, "@Estado", Estado, "@Usuario", ModPOS.UsuarioActual)
                    End If

                    ModPOS.Ejecuta("sp_elimina_PERItem", "@Perfil", Me.PERClave)

                    Dim nodoPadre As TreeNode

                    For Each nodoPadre In TvAsignado.Nodes
                        addAsignados(nodoPadre)
                    Next

                    Close()
            End Select
            ModPOS.MtoPerfil.actualiza_Grid()
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0
        Dim existeNombre As Integer

        If Me.TxtNombre.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtNombre.Text.Length > 40 Then
            Me.TxtNombre.Text = Me.TxtNombre.Text.Substring(0, 40)

        End If


        'If LstAsignados.Items.Count = 0 Then
        '    i += 1
        '    reloj = New parpadea(Me.alerta(2))
        '    reloj.Enabled = True
        '    reloj.Start()
        'End If

        If i > 0 Then
            Return False
        Else
            Dim Con As String = ModPOS.BDConexion

            existeNombre = ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Perfil", "@clave", UCase(Trim(Me.TxtNombre.Text)), "@COMClave", ModPOS.CompanyActual)
            If (Me.Padre = "Nuevo" AndAlso existeNombre > 0) OrElse (Me.Padre = "Modificar" AndAlso existeNombre > 0 AndAlso Me.TxtNombre.Text <> Me.sNombre) Then
                Beep()
                MessageBox.Show("El Nombre que intenta agregar ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                reloj = New parpadea(Me.alerta(0))
                reloj.Enabled = True
                reloj.Start()
                Return False
            Else
                While i < Me.alerta.Length
                    Me.alerta(i).Visible = False
                    i += 1
                End While
                Return True
            End If
        End If

    End Function


    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Function recuperaClave(ByVal Nombre As String) As String
        Dim dt As DataTable
        Dim Clave As String

        dt = ModPOS.Recupera_Tabla("sp_recupera_perfil", "@Nombre", Me.Nombre)

        Clave = dt.Rows(0)("PERClave")
        dt.Dispose()


        Return (Clave)
    End Function



End Class
