Public Class FrmPrinter
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
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpPrinter As System.Windows.Forms.GroupBox
    Friend WithEvents ChkGeneric As Selling.ChkStatus
    Friend WithEvents CmbImpresora As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GrpClas As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAgregarLinea As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridLineas As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnEliminaLinea As Janus.Windows.EditControls.UIButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtt2 As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtt1 As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtm As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtp As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtESC As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents btnTest As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkEstado As Selling.ChkStatus
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrinter))
        Me.GrpPrinter = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CmbImpresora = New System.Windows.Forms.ComboBox()
        Me.ChkGeneric = New Selling.ChkStatus(Me.components)
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.GrpClas = New System.Windows.Forms.GroupBox()
        Me.BtnAgregarLinea = New Janus.Windows.EditControls.UIButton()
        Me.GridLineas = New Janus.Windows.GridEX.GridEX()
        Me.BtnEliminaLinea = New Janus.Windows.EditControls.UIButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnTest = New Janus.Windows.EditControls.UIButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtt2 = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtt1 = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtm = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtp = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtESC = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.GrpPrinter.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpClas.SuspendLayout()
        CType(Me.GridLineas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpPrinter
        '
        Me.GrpPrinter.Controls.Add(Me.PictureBox2)
        Me.GrpPrinter.Controls.Add(Me.CmbSucursal)
        Me.GrpPrinter.Controls.Add(Me.Label12)
        Me.GrpPrinter.Controls.Add(Me.CmbImpresora)
        Me.GrpPrinter.Controls.Add(Me.ChkGeneric)
        Me.GrpPrinter.Controls.Add(Me.ChkEstado)
        Me.GrpPrinter.Controls.Add(Me.PictureBox1)
        Me.GrpPrinter.Controls.Add(Me.LblClave)
        Me.GrpPrinter.Location = New System.Drawing.Point(7, 7)
        Me.GrpPrinter.Name = "GrpPrinter"
        Me.GrpPrinter.Size = New System.Drawing.Size(526, 119)
        Me.GrpPrinter.TabIndex = 1
        Me.GrpPrinter.TabStop = False
        Me.GrpPrinter.Text = "Impresora"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(321, 18)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox2.TabIndex = 120
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Location = New System.Drawing.Point(93, 17)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(227, 21)
        Me.CmbSucursal.TabIndex = 118
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(7, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 18)
        Me.Label12.TabIndex = 119
        Me.Label12.Text = "Sucursal"
        '
        'CmbImpresora
        '
        Me.CmbImpresora.FormattingEnabled = True
        Me.CmbImpresora.Location = New System.Drawing.Point(93, 57)
        Me.CmbImpresora.Name = "CmbImpresora"
        Me.CmbImpresora.Size = New System.Drawing.Size(269, 21)
        Me.CmbImpresora.TabIndex = 58
        '
        'ChkGeneric
        '
        Me.ChkGeneric.Location = New System.Drawing.Point(93, 87)
        Me.ChkGeneric.Name = "ChkGeneric"
        Me.ChkGeneric.Size = New System.Drawing.Size(137, 23)
        Me.ChkGeneric.TabIndex = 57
        Me.ChkGeneric.Text = "Imprimir doble linea"
        '
        'ChkEstado
        '
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(335, 16)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(66, 22)
        Me.ChkEstado.TabIndex = 56
        Me.ChkEstado.Text = "Activo"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(367, 60)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(7, 60)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 14)
        Me.LblClave.TabIndex = 24
        Me.LblClave.Text = "Referencia"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(349, 412)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 3
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(444, 412)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpClas
        '
        Me.GrpClas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpClas.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpClas.Controls.Add(Me.BtnAgregarLinea)
        Me.GrpClas.Controls.Add(Me.GridLineas)
        Me.GrpClas.Controls.Add(Me.BtnEliminaLinea)
        Me.GrpClas.Location = New System.Drawing.Point(8, 190)
        Me.GrpClas.MinimumSize = New System.Drawing.Size(525, 214)
        Me.GrpClas.Name = "GrpClas"
        Me.GrpClas.Size = New System.Drawing.Size(525, 214)
        Me.GrpClas.TabIndex = 4
        Me.GrpClas.TabStop = False
        Me.GrpClas.Text = "Lineas de Producto para Impresión de Comandas"
        '
        'BtnAgregarLinea
        '
        Me.BtnAgregarLinea.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregarLinea.Image = CType(resources.GetObject("BtnAgregarLinea.Image"), System.Drawing.Image)
        Me.BtnAgregarLinea.Location = New System.Drawing.Point(429, 16)
        Me.BtnAgregarLinea.Name = "BtnAgregarLinea"
        Me.BtnAgregarLinea.Size = New System.Drawing.Size(90, 30)
        Me.BtnAgregarLinea.TabIndex = 2
        Me.BtnAgregarLinea.Text = "&Agregar"
        Me.BtnAgregarLinea.ToolTipText = "Agrega registro de clasificación de producto"
        Me.BtnAgregarLinea.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridLineas
        '
        Me.GridLineas.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridLineas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridLineas.ColumnAutoResize = True
        Me.GridLineas.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridLineas.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridLineas.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridLineas.Location = New System.Drawing.Point(7, 15)
        Me.GridLineas.Name = "GridLineas"
        Me.GridLineas.RecordNavigator = True
        Me.GridLineas.Size = New System.Drawing.Size(416, 193)
        Me.GridLineas.TabIndex = 1
        Me.GridLineas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnEliminaLinea
        '
        Me.BtnEliminaLinea.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminaLinea.Image = CType(resources.GetObject("BtnEliminaLinea.Image"), System.Drawing.Image)
        Me.BtnEliminaLinea.Location = New System.Drawing.Point(429, 49)
        Me.BtnEliminaLinea.Name = "BtnEliminaLinea"
        Me.BtnEliminaLinea.Size = New System.Drawing.Size(90, 30)
        Me.BtnEliminaLinea.TabIndex = 4
        Me.BtnEliminaLinea.Text = "&Eliminar "
        Me.BtnEliminaLinea.ToolTipText = "Elimina la linea seleccionada"
        Me.BtnEliminaLinea.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnTest)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtt2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtt1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtm)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtp)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtESC)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 132)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(525, 47)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Secuencia de Apertura de Cajón"
        '
        'btnTest
        '
        Me.btnTest.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTest.Appearance = Janus.Windows.UI.Appearance.Flat
        Me.btnTest.Icon = CType(resources.GetObject("btnTest.Icon"), System.Drawing.Icon)
        Me.btnTest.Location = New System.Drawing.Point(428, 13)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(90, 30)
        Me.btnTest.TabIndex = 34
        Me.btnTest.Text = "Probar"
        Me.btnTest.ToolTipText = "m (pin 2 usar 0, 48 y pin 5 usar 1. 49), t1 (0 a 255), t2 (0 a 255)"
        Me.btnTest.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(304, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 15)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "t2"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtt2
        '
        Me.txtt2.Location = New System.Drawing.Point(342, 19)
        Me.txtt2.Name = "txtt2"
        Me.txtt2.Size = New System.Drawing.Size(40, 20)
        Me.txtt2.TabIndex = 32
        Me.txtt2.Text = "20"
        Me.txtt2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtt2.Value = 20
        Me.txtt2.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(231, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 15)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "t1"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtt1
        '
        Me.txtt1.Location = New System.Drawing.Point(261, 19)
        Me.txtt1.Name = "txtt1"
        Me.txtt1.Size = New System.Drawing.Size(41, 20)
        Me.txtt1.TabIndex = 30
        Me.txtt1.Text = "20"
        Me.txtt1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtt1.Value = 20
        Me.txtt1.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(157, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 15)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "m"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtm
        '
        Me.txtm.Location = New System.Drawing.Point(187, 19)
        Me.txtm.Name = "txtm"
        Me.txtm.Size = New System.Drawing.Size(40, 20)
        Me.txtm.TabIndex = 28
        Me.txtm.Text = "0"
        Me.txtm.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtm.Value = 0
        Me.txtm.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(89, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 15)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "p"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtp
        '
        Me.txtp.Location = New System.Drawing.Point(111, 19)
        Me.txtp.Name = "txtp"
        Me.txtp.Size = New System.Drawing.Size(41, 20)
        Me.txtp.TabIndex = 26
        Me.txtp.Text = "112"
        Me.txtp.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtp.Value = 112
        Me.txtp.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 15)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "ESC"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtESC
        '
        Me.txtESC.Location = New System.Drawing.Point(43, 19)
        Me.txtESC.Name = "txtESC"
        Me.txtESC.Size = New System.Drawing.Size(41, 20)
        Me.txtESC.TabIndex = 6
        Me.txtESC.Text = "27"
        Me.txtESC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtESC.Value = 27
        Me.txtESC.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'FrmPrinter
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(541, 456)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GrpClas)
        Me.Controls.Add(Me.GrpPrinter)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPrinter"
        Me.Text = "Impresora"
        Me.GrpPrinter.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpClas.ResumeLayout(False)
        CType(Me.GridLineas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String
    Public PRNClave As String
    Public SUCClave As String = ""
    Public Referencia As String = ""
    Public Estado As Integer
    Public Generic As Integer

    Public ESC, p, m, t1, t2 As Integer

    Private dtLineas As DataTable
    Private sReferencia As String
    Private iBaja As Integer

    Private alerta(2) As PictureBox
    Private reloj As parpadea

    Public Sub AddClase(ByVal iCLAClave As Integer, ByVal sClave As String, ByVal sNombre As String)

        Dim foundRows() As Data.DataRow
        foundRows = dtLineas.Select("CLAClave = " & iCLAClave & " and Baja = 0")

        If foundRows.Length = 0 Then

            foundRows = dtLineas.Select("Clave = '" & Trim(sClave) & "' and Baja = 0")
            If foundRows.Length = 0 Then

                Dim row1 As DataRow
                row1 = dtLineas.NewRow()
                'declara el nombre de la fila

                row1.Item("CLAClave") = iCLAClave
                row1.Item("Clave") = sClave
                row1.Item("Nombre") = sNombre
                row1.Item("Nuevo") = 1
                row1.Item("Baja") = 0

                dtLineas.Rows.Add(row1)
                'agrega la fila completo a la tabla
            End If
        End If
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        Dim TxtNombre As String = ""
        If CmbImpresora.SelectedItem Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        Else
            TxtNombre = CmbImpresora.SelectedItem
        End If


        If Me.CmbSucursal.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If


        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" OrElse (Me.Padre = "Modificar" AndAlso TxtNombre <> Referencia) Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Printer", "@clave", UCase(Trim(TxtNombre)), "@COMClave", ModPOS.CompanyActual) > 0 Then
                Beep()
                MessageBox.Show("La Referencia que intenta agregar ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                reloj = New parpadea(Me.alerta(0))
                reloj.Enabled = True
                reloj.Start()
                Return False
            Else
                While i < Me.alerta.Length - 1
                    Me.alerta(i).Visible = False
                    i += 1
                End While
                Return True
            End If
        Else
            While i < Me.alerta.Length - 1
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function

    Private Sub FrmPrinter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2

        With CmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With


        Dim pd As New System.Drawing.Printing.PrintDocument

        Dim Impresoras As String
        Dim s_Default_Printer As String

        ' Default printer       
        If Referencia = "" Then
            s_Default_Printer = pd.PrinterSettings.PrinterName
        Else
            s_Default_Printer = Referencia
        End If

        ' recorre las impresoras instaladas   
        For Each Impresoras In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            CmbImpresora.Items.Add(Impresoras.ToString)
        Next
        ' selecciona la impresora predeterminada   
        CmbImpresora.Text = s_Default_Printer


        If Padre = "Agregar" Then

            PRNClave = ModPOS.obtenerLlave

            dtLineas = ModPOS.CrearTabla("Clasificacion", _
            "CLAClave", "System.Int32", _
            "Clave", "System.String", _
            "Nombre", "System.String", _
            "Nuevo", "System.Int32", _
            "Baja", "System.Int32")
        Else
            dtLineas = ModPOS.Recupera_Tabla("sp_muestra_print_clases", "@PRNClave", PRNClave)
        End If

        GridLineas.DataSource = dtLineas
        GridLineas.RetrieveStructure(True)
        GridLineas.GroupByBoxVisible = False
        GridLineas.RootTable.Columns("CLAClave").Visible = False
        GridLineas.RootTable.Columns("Nuevo").Visible = False
        GridLineas.RootTable.Columns("Baja").Visible = False

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridLineas.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridLineas.RootTable.FormatConditions.Add(fc)

        ChkEstado.Estado = Estado

        ChkGeneric.Estado = Generic

        CmbSucursal.SelectedValue = SUCClave


        txtESC.Text = ESC
        txtp.Text = p
        txtm.Text = m
        txtt1.Text = t1
        txtt2.Text = t2

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then

            Dim foundRows() As System.Data.DataRow

            Select Case Me.Padre
                Case "Agregar"

                    Referencia = CmbImpresora.SelectedItem
                    Generic = ChkGeneric.GetEstado
                    SUCClave = CmbSucursal.SelectedValue

                    ESC = txtESC.Text
                    p = txtp.Text
                    m = txtm.Text
                    t1 = txtt1.Text
                    t2 = txtt2.Text


                    ModPOS.Ejecuta("sp_inserta_impresora", _
                    "@PRNClave", PRNClave, _
                    "@Referencia", Referencia, _
                    "@Generic", Generic, _
                    "@SUCClave", SUCClave, _
                    "@ESC", ESC, _
                    "@p", p, _
                    "@m", m, _
                    "@t1", t1, _
                    "@t2", t2, _
                    "@Usuario", ModPOS.UsuarioActual)

                    foundRows = dtLineas.Select(" Nuevo = 1 and Baja = 0 ")

                    If foundRows.Length <> 0 Then
                        'inserta metodos de pago

                        Dim z As Integer

                        For z = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("sp_inserta_ClasPrint", _
                            "@PRNClave", PRNClave, _
                            "@CLAClave", foundRows(z)("CLAClave"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    If Not ModPOS.MtoPrinter Is Nothing Then
                        ModPOS.ActualizaGrid(True, ModPOS.MtoPrinter.GridPrinters, "sp_muestra_impresoras", "@COMClave", ModPOS.CompanyActual)
                    End If

                Case "Modificar"
                    If Not (Generic = ChkGeneric.GetEstado AndAlso _
                    Estado = ChkEstado.GetEstado AndAlso _
                    Referencia = CmbImpresora.SelectedItem AndAlso _
                    ESC = txtESC.Text AndAlso _
                    p = txtp.Text AndAlso _
                    m = txtm.Text AndAlso _
                    t1 = txtt1.Text AndAlso _
                    t2 = txtt2.Text AndAlso _
                    SUCClave = CmbSucursal.SelectedValue) Then

                        Referencia = CmbImpresora.SelectedItem
                        Estado = ChkEstado.GetEstado
                        Generic = ChkGeneric.GetEstado
                        SUCClave = CmbSucursal.SelectedValue
                        ESC = txtESC.Text
                        p = txtp.Text
                        m = txtm.Text
                        t1 = txtt1.Text
                        t2 = txtt2.Text


                        ModPOS.Ejecuta("sp_actualiza_impresora", _
                        "@Referencia", Referencia, _
                        "@Generic", Generic, _
                        "@SUCClave", SUCClave, _
                        "@Estado", Estado, _
                        "@PRNClave", PRNClave, _
                        "@ESC", ESC, _
                        "@p", p, _
                        "@m", m, _
                        "@t1", t1, _
                        "@t2", t2, _
                        "@Usuario", ModPOS.UsuarioActual)

                        If Not ModPOS.MtoPrinter Is Nothing Then
                            ModPOS.ActualizaGrid(True, ModPOS.MtoPrinter.GridPrinters, "sp_muestra_impresoras", "@COMClave", ModPOS.CompanyActual)
                        End If
                    End If

                    foundRows = dtLineas.Select(" Baja = 1 ")

                    If foundRows.Length <> 0 Then
                        Dim z As Integer
                        For z = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("sp_elimina_ClasPrint", _
                            "@PRNClave", PRNClave, _
                            "@CLAClave", foundRows(z)("CLAClave"))
                        Next
                    End If

                    foundRows = dtLineas.Select(" Nuevo = 1 and Baja = 0")

                    If foundRows.Length <> 0 Then
                        'actualiza denominaciones
                        Dim z As Integer
                        For z = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("sp_inserta_ClasPrint", _
                            "@PRNClave", PRNClave, _
                            "@CLAClave", foundRows(z)("CLAClave"), _
                            "@Usuario", ModPOS.UsuarioActual)

                        Next
                    End If

            End Select
            Me.Close()
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub FrmPrinter_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Printer.Dispose()
        ModPOS.Printer = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnAgregarLinea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarLinea.Click
        If ModPOS.AddClasPrint Is Nothing Then
            ModPOS.AddClasPrint = New FrmAddClasPrint
            With ModPOS.AddClasPrint
                .StartPosition = FormStartPosition.CenterScreen
                .SUCClave = SUCClave
            End With
        End If
        ModPOS.AddClasPrint.StartPosition = FormStartPosition.CenterScreen
        ModPOS.AddClasPrint.Show()
        ModPOS.AddClasPrint.BringToFront()
    End Sub

    Private Sub BtnEliminaLinea_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEliminaLinea.Click
        If sReferencia <> "" Then
            Beep()
            Select Case MessageBox.Show("Se removera la Linea :" & sReferencia & " de la Impresora Actual", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtLineas.Select("Clave = '" & sReferencia & "'")

                    If foundRows.Length <> 0 Then
                        foundRows(0)("Baja") = 1
                    End If
            End Select
        End If
    End Sub

    Private Sub GridLineas_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridLineas.SelectionChanged
        If Not Me.GridLineas.GetValue(0) Is Nothing Then
            Me.BtnEliminaLinea.Enabled = True
            Me.iBaja = GridLineas.GetValue("Baja")
            Me.sReferencia = GridLineas.GetValue("Clave")
        Else
            Me.iBaja = -1
            Me.sReferencia = ""
            Me.BtnEliminaLinea.Enabled = False
        End If

    End Sub



    Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
        If validaForm() Then
            Dim ESC, p, m, t1, t2 As Integer
            ESC = txtESC.Text
            p = txtp.Text
            m = txtm.Text
            t1 = txtt1.Text
            t2 = txtt2.Text
            Dim drawer As String = Chr(ESC) & Chr(p) & Chr(m) & Chr(t1) & Chr(t2)
            RawPrinterHelper.SendStringToPrinter(CmbImpresora.SelectedItem, drawer)
        End If
    End Sub
End Class
