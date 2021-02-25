Public Class FrmAddAccesos
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
    Friend WithEvents GrpAlm As System.Windows.Forms.GroupBox
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents ChkListSuc As System.Windows.Forms.CheckedListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddAccesos))
        Me.GrpAlm = New System.Windows.Forms.GroupBox()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.ChkListSuc = New System.Windows.Forms.CheckedListBox()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox()
        Me.GrpAlm.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpAlm
        '
        Me.GrpAlm.Controls.Add(Me.BtnCancelar)
        Me.GrpAlm.Controls.Add(Me.ChkListSuc)
        Me.GrpAlm.Controls.Add(Me.BtnGuardar)
        Me.GrpAlm.Controls.Add(Me.ChkMarcaTodos)
        Me.GrpAlm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpAlm.Location = New System.Drawing.Point(0, 0)
        Me.GrpAlm.Name = "GrpAlm"
        Me.GrpAlm.Size = New System.Drawing.Size(688, 358)
        Me.GrpAlm.TabIndex = 0
        Me.GrpAlm.TabStop = False
        Me.GrpAlm.Text = "Sucursales"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(489, 314)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 27
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkListSuc
        '
        Me.ChkListSuc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkListSuc.Location = New System.Drawing.Point(13, 34)
        Me.ChkListSuc.Name = "ChkListSuc"
        Me.ChkListSuc.Size = New System.Drawing.Size(662, 274)
        Me.ChkListSuc.TabIndex = 7
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(585, 314)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 26
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Enabled = False
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(17, 13)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(112, 22)
        Me.ChkMarcaTodos.TabIndex = 6
        Me.ChkMarcaTodos.Text = "Marcar Todos"
        '
        'FrmAddAccesos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(688, 358)
        Me.Controls.Add(Me.GrpAlm)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(853, 713)
        Me.MinimumSize = New System.Drawing.Size(580, 364)
        Me.Name = "FrmAddAccesos"
        Me.Text = "Accesos a Sucursales"
        Me.GrpAlm.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public USRClave As String
    Private dtSubClass As DataTable


    Private Sub FrmAddAccesos_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.AddAccesos.Dispose()
        ModPOS.AddAccesos = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub ChkMarcaTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMarcaTodos.CheckedChanged
        Dim i As Integer
        If ChkMarcaTodos.Checked Then
            For i = 0 To ChkListSuc.Items.Count - 1
                ChkListSuc.SetItemCheckState(i, CheckState.Checked)
            Next
        Else
            For i = 0 To ChkListSuc.Items.Count - 1
                ChkListSuc.SetItemCheckState(i, CheckState.Unchecked)
            Next
        End If
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim i As Integer
        Dim sSUCClave As String
        Dim sNombre As String
        If ChkListSuc.CheckedItems.Count > 0 Then
            For i = 0 To Me.ChkListSuc.CheckedItems.Count - 1
                sSUCClave = dtSubClass.Rows(ChkListSuc.CheckedIndices(i)).ItemArray(0)
                sNombre = dtSubClass.Rows(ChkListSuc.CheckedIndices(i)).ItemArray(1)
                ModPOS.Usuarios.updateAlmacenes(sSUCClave, sNombre)
            Next
        End If
        Me.Close()
    End Sub

    Private Sub FrmAddAccesos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtSubClass = ModPOS.Recupera_Tabla("sp_recupera_AccesoSucursal")
        If dtSubClass.Rows.Count > 0 Then
            Me.ChkListSuc.DataSource = dtSubClass
            Me.ChkListSuc.DisplayMember = dtSubClass.Columns(1).ColumnName
            Me.ChkListSuc.ValueMember = dtSubClass.Columns(0).ColumnName
            ChkMarcaTodos.Enabled = True
        Else
            MsgBox("No se encontró ningún elemento.", MsgBoxStyle.Information, "Información")
        End If
    End Sub
End Class
