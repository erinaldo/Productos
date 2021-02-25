
Public Class FrmSolicitaPacking
    Inherits System.Windows.Forms.Form
    Implements ITeclado

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
    Friend WithEvents lblNota As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblAtiende As System.Windows.Forms.Label
    Friend WithEvents LblInfo As System.Windows.Forms.Label
    Friend WithEvents picKeyboard As System.Windows.Forms.PictureBox
    Friend WithEvents grpAlmacen As System.Windows.Forms.GroupBox
    Friend WithEvents cmbAlmacen As Selling.StoreCombo
    Friend WithEvents GrpSucursal As System.Windows.Forms.GroupBox
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents txtStage As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnStage As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnOk As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSolicitaPacking))
        Me.lblNota = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtClave = New System.Windows.Forms.TextBox()
        Me.LblAtiende = New System.Windows.Forms.Label()
        Me.LblInfo = New System.Windows.Forms.Label()
        Me.picKeyboard = New System.Windows.Forms.PictureBox()
        Me.grpAlmacen = New System.Windows.Forms.GroupBox()
        Me.cmbAlmacen = New Selling.StoreCombo()
        Me.GrpSucursal = New System.Windows.Forms.GroupBox()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.txtStage = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnStage = New Janus.Windows.EditControls.UIButton()
        Me.BtnOk = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton()
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpAlmacen.SuspendLayout()
        Me.GrpSucursal.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblNota
        '
        Me.lblNota.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.lblNota, "lblNota")
        Me.lblNota.ForeColor = System.Drawing.Color.White
        Me.lblNota.Name = "lblNota"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Name = "Label2"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'TxtClave
        '
        resources.ApplyResources(Me.TxtClave, "TxtClave")
        Me.TxtClave.Name = "TxtClave"
        '
        'LblAtiende
        '
        Me.LblAtiende.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.LblAtiende, "LblAtiende")
        Me.LblAtiende.ForeColor = System.Drawing.Color.White
        Me.LblAtiende.Name = "LblAtiende"
        '
        'LblInfo
        '
        resources.ApplyResources(Me.LblInfo, "LblInfo")
        Me.LblInfo.Name = "LblInfo"
        '
        'picKeyboard
        '
        resources.ApplyResources(Me.picKeyboard, "picKeyboard")
        Me.picKeyboard.BackColor = System.Drawing.Color.Transparent
        Me.picKeyboard.Image = Global.Selling.My.Resources.Resources._1403657593_519640_141_Keyboard
        Me.picKeyboard.Name = "picKeyboard"
        Me.picKeyboard.TabStop = False
        '
        'grpAlmacen
        '
        resources.ApplyResources(Me.grpAlmacen, "grpAlmacen")
        Me.grpAlmacen.Controls.Add(Me.cmbAlmacen)
        Me.grpAlmacen.Name = "grpAlmacen"
        Me.grpAlmacen.TabStop = False
        '
        'cmbAlmacen
        '
        resources.ApplyResources(Me.cmbAlmacen, "cmbAlmacen")
        Me.cmbAlmacen.Name = "cmbAlmacen"
        '
        'GrpSucursal
        '
        resources.ApplyResources(Me.GrpSucursal, "GrpSucursal")
        Me.GrpSucursal.Controls.Add(Me.CmbSucursal)
        Me.GrpSucursal.Name = "GrpSucursal"
        Me.GrpSucursal.TabStop = False
        '
        'CmbSucursal
        '
        resources.ApplyResources(Me.CmbSucursal, "CmbSucursal")
        Me.CmbSucursal.Name = "CmbSucursal"
        '
        'txtStage
        '
        resources.ApplyResources(Me.txtStage, "txtStage")
        Me.txtStage.Name = "txtStage"
        Me.txtStage.ReadOnly = True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'BtnStage
        '
        resources.ApplyResources(Me.BtnStage, "BtnStage")
        Me.BtnStage.Image = CType(resources.GetObject("BtnStage.Image"), System.Drawing.Image)
        Me.BtnStage.Name = "BtnStage"
        Me.BtnStage.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnOk
        '
        resources.ApplyResources(Me.BtnOk, "BtnOk")
        Me.BtnOk.BackColor = System.Drawing.SystemColors.Control
        Me.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOk.Image = CType(resources.GetObject("BtnOk.Image"), System.Drawing.Image)
        Me.BtnOk.Name = "BtnOk"
        '
        'BtnCancel
        '
        resources.ApplyResources(Me.BtnCancel, "BtnCancel")
        Me.BtnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Name = "BtnCancel"
        '
        'FrmSolicitaPacking
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnStage)
        Me.Controls.Add(Me.txtStage)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grpAlmacen)
        Me.Controls.Add(Me.GrpSucursal)
        Me.Controls.Add(Me.picKeyboard)
        Me.Controls.Add(Me.LblInfo)
        Me.Controls.Add(Me.LblAtiende)
        Me.Controls.Add(Me.TxtClave)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblNota)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmSolicitaPacking"
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpAlmacen.ResumeLayout(False)
        Me.GrpSucursal.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public AtiendeClave As String = ""
    Public UBCClave As String = ""

    Private SUCClave As String = ""
    Private Cargado As Boolean = False

    Private Cnx As System.Data.SqlClient.SqlConnection
    Private da As System.Data.SqlClient.SqlDataAdapter

    Private ds As DataTable
    Private bError As Boolean = False

    Private AtiendeNombre As String = ""
    Private ReferenciaUsr As String = ""

    Private Sub FrmSolicitaUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With CmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        If ModPOS.SucursalPredeterminada <> "" Then
            CmbSucursal.SelectedValue = ModPOS.SucursalPredeterminada
        End If

        SUCClave = CmbSucursal.SelectedValue

        With cmbAlmacen
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_almsuc"
            .NombreParametro1 = "SUCClave"
            .Parametro1 = SUCClave
            .llenar()
        End With


        Cargado = True

        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Show()
        Me.BringToFront()

    End Sub

    Private Sub FrmSolicitaUsuario_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

 
    Private Sub TxtClave_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClave.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Escape
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                bError = False
                Me.Close()
            Case Is = Keys.Enter
                If UBCClave <> "" Then
                    If TxtClave.Text <> "" Then
                        Dim dt As DataTable
                        dt = ModPOS.Recupera_Tabla("sp_recupera_usuario", "@Usuario", TxtClave.Text.Trim.ToUpper.Replace("'", "''"))
                        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                            AtiendeClave = dt.Rows(0)("USRClave")
                            ReferenciaUsr = dt.Rows(0)("Referencia")
                            AtiendeNombre = dt.Rows(0)("Nombre")
                            dt.Dispose()
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                            bError = False
                        Else
                            LblInfo.Text = "Información: ¡Clave de Usuario No Existe!"
                            bError = True
                            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                        End If
                    Else
                        LblInfo.Text = "Información: ¡Clave de Usuario No es Valida!"
                        bError = True
                        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                    End If
                Else
                    LblInfo.Text = "Información: ¡La ubicación o Stage No es Valida!"
                    bError = True
                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                End If
        End Select
    End Sub


    Private Sub picKeyboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picKeyboard.Click
        If AbrirTeclado(Me) Then
            If TxtClave.Text <> "" Then
                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_recupera_usuario", "@Usuario", TxtClave.Text.Trim.ToUpper.Replace("'", "''"))
                If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                    AtiendeClave = dt.Rows(0)("USRClave")
                    ReferenciaUsr = dt.Rows(0)("Referencia")
                    AtiendeNombre = dt.Rows(0)("Nombre")
                    dt.Dispose()
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    bError = False
                Else
                    LblInfo.Text = "Información: ¡Clave de Usuario No Existe!"
                    bError = True
                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                End If
            Else
                LblInfo.Text = "Información: ¡Clave de Usuario No Valida!"
                bError = True
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            End If
        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            bError = False
            Me.Close()
        End If
    End Sub

    Private Sub Concatenar(dato As String) Implements ITeclado.Concatenar

        If dato = "DESHACER" OrElse dato = "" And TxtClave.TextLength > 0 Then
            TxtClave.Text = TxtClave.Text.Remove(TxtClave.TextLength - 1, 1)
        Else
            TxtClave.Text &= dato
        End If
    End Sub

    Private Sub BtnStage_Click(sender As Object, e As EventArgs) Handles BtnStage.Click
        If Not cmbAlmacen.SelectedValue Is Nothing Then
            Dim a As New FrmConsulta
            a.Campo = "UBCClave"
            a.Campo2 = "Stage"
            ModPOS.ActualizaGrid(False, a.GridConsultaGen, "st_recupera_stage", "@ALMClave", cmbAlmacen.SelectedValue, "@TipoAplicacion", 2)
            a.GridConsultaGen.RootTable.Columns("UBCClave").Visible = False
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                If a.ID <> "" Then
                    Dim dtubc As DataTable = ModPOS.Recupera_Tabla("sp_recupera_ubicacion", "@UBCClave", a.ID)
                    If CInt(dtubc.Rows(0)("Estado")) <> 1 Then
                        LblInfo.Text = "El  Estado del Stage o Ubicación seleccionada debe ser Disponible "
                        UBCClave = ""
                        txtStage.Text = ""
                        dtubc.Dispose()
                        Exit Sub
                    End If
                    dtubc.Dispose()
                    UBCClave = a.ID
                    Me.txtStage.Text = a.ID2
                End If
            End If
            a.Dispose()
        Else
            LblInfo.Text = "No se ha seleccionado un Almacén valido"
            bError = True
        End If

    End Sub

    Private Sub CmbSucursal_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbSucursal.SelectedValueChanged
        If Not CmbSucursal.SelectedValue Is Nothing AndAlso Cargado Then
            With cmbAlmacen
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_almsuc"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = CmbSucursal.SelectedValue
                .llenar()
            End With
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        bError = False
        Me.Close()

    End Sub

    Private Sub Entrar()
        If UBCClave = "" OrElse AtiendeClave = "" Then
            bError = True
        Else

            bError = False
        End If

    End Sub

    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click
        Cursor.Current = Cursors.WaitCursor
        Me.Entrar()
        Cursor.Current = Cursors.Default
    End Sub

End Class


