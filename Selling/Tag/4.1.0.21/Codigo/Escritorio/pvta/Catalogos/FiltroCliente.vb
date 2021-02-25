Public Class FiltroCliente
    Inherits System.Windows.Forms.Form

    Private ZonaReparto As Integer = -1
    Private USRClave As String = ""
    Private Sucursal As Integer
    Public Titulo As String
    Private Todos As Integer
    Private bError As Boolean = False

    ' Public Reporte As String

    Private alerta(2) As PictureBox

    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents BtnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbVendedor As Selling.StoreCombo
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents chkVendedor As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbZonaReparto As Selling.StoreCombo

    Private reloj As parpadea

    Public ReadOnly Property SucursalOrigen() As Integer
        Get
            SucursalOrigen = Sucursal
        End Get
    End Property

    Public ReadOnly Property Vendedor() As String
        Get
            Vendedor = USRClave
        End Get
    End Property


    Public ReadOnly Property Zona() As Integer
        Get
            Zona = ZonaReparto
        End Get
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
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FiltroCliente))
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ChkTodos = New System.Windows.Forms.CheckBox()
        Me.BtnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.cmbVendedor = New Selling.StoreCombo()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.chkVendedor = New System.Windows.Forms.CheckBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.cmbZonaReparto = New Selling.StoreCombo()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(277, 181)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "&Salir"
        Me.BtnCancel.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(437, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(22, 19)
        Me.PictureBox1.TabIndex = 73
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cmbZonaReparto)
        Me.GroupBox2.Controls.Add(Me.PictureBox2)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 124)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(456, 45)
        Me.GroupBox2.TabIndex = 73
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Zona de Reparto"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(56, -2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(19, 21)
        Me.PictureBox2.TabIndex = 73
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.CmbSucursal.Location = New System.Drawing.Point(79, 11)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(355, 21)
        Me.CmbSucursal.TabIndex = 38
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "Sucursal"
        '
        'ChkTodos
        '
        Me.ChkTodos.AutoSize = True
        Me.ChkTodos.Checked = True
        Me.ChkTodos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkTodos.Location = New System.Drawing.Point(7, 103)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(94, 17)
        Me.ChkTodos.TabIndex = 75
        Me.ChkTodos.Text = "Mostrar Todos"
        Me.ChkTodos.UseVisualStyleBackColor = True
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAceptar.Image = CType(resources.GetObject("BtnAceptar.Image"), System.Drawing.Image)
        Me.BtnAceptar.Location = New System.Drawing.Point(373, 180)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAceptar.TabIndex = 76
        Me.BtnAceptar.Text = "&Aceptar"
        Me.BtnAceptar.ToolTipText = "Guardar cambios"
        Me.BtnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmbVendedor
        '
        Me.cmbVendedor.Location = New System.Drawing.Point(79, 71)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(298, 21)
        Me.cmbVendedor.TabIndex = 104
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(8, 74)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(74, 15)
        Me.Label35.TabIndex = 103
        Me.Label35.Text = "Vendedor"
        '
        'chkVendedor
        '
        Me.chkVendedor.AutoSize = True
        Me.chkVendedor.Checked = True
        Me.chkVendedor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkVendedor.Location = New System.Drawing.Point(7, 43)
        Me.chkVendedor.Name = "chkVendedor"
        Me.chkVendedor.Size = New System.Drawing.Size(131, 17)
        Me.chkVendedor.TabIndex = 105
        Me.chkVendedor.Text = "Todos los vendedores"
        Me.chkVendedor.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(54, 71)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(19, 21)
        Me.PictureBox3.TabIndex = 86
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'cmbZonaReparto
        '
        Me.cmbZonaReparto.BackColor = System.Drawing.SystemColors.Window
        Me.cmbZonaReparto.ItemHeight = 13
        Me.cmbZonaReparto.Location = New System.Drawing.Point(6, 18)
        Me.cmbZonaReparto.Name = "cmbZonaReparto"
        Me.cmbZonaReparto.Size = New System.Drawing.Size(441, 21)
        Me.cmbZonaReparto.TabIndex = 89
        '
        'FiltroCliente
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(466, 220)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.chkVendedor)
        Me.Controls.Add(Me.cmbVendedor)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.ChkTodos)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CmbSucursal)
        Me.Controls.Add(Me.BtnCancel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(457, 186)
        Me.Name = "FiltroCliente"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub FiltroCliente_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0


        If Me.CmbSucursal.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If ChkTodos.Checked = False AndAlso cmbZonaReparto.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If chkVendedor.Checked = False AndAlso cmbVendedor.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If


        If i > 0 Then
            Return False
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        bError = False
        Me.Close()
    End Sub

    Private Sub FiltroCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen


        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3

        With CmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "Responsable"
            .llenar()
        End With


        With Me.cmbVendedor
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "st_recupera_usr_vendedor"
            .llenar()
        End With


        With cmbZonaReparto
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref_concat"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "ZonaReparto"
            .llenar()
        End With

        If chkVendedor.Checked = True Then

            cmbVendedor.Enabled = False
        Else
            cmbVendedor.Enabled = True
        End If

        Me.Text = Titulo

    End Sub

 
    Private Sub ChkTodos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkTodos.CheckedChanged
        If ChkTodos.Checked = False Then
            cmbZonaReparto.Enabled = True
        Else
            cmbZonaReparto.Enabled = False
        End If
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If validaForm() Then
            Sucursal = CmbSucursal.SelectedValue

            If chkVendedor.Checked = True Then
                USRClave = ""
            Else
                USRClave = cmbVendedor.SelectedValue
            End If

            If ChkTodos.Checked Then
                ZonaReparto = -1
            Else
                ZonaReparto = cmbZonaReparto.SelectedValue
            End If

            bError = False
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Else
            bError = True
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub chkVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chkVendedor.CheckedChanged
        If chkVendedor.Checked = True Then

            cmbVendedor.Enabled = False
        Else
            cmbVendedor.Enabled = True
        End If
    End Sub

 
End Class
