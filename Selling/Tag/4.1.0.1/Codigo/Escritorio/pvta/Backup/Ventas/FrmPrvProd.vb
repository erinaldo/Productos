
Public Class FrmPrvProd
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
    Friend WithEvents GrpCliente As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscaPrv As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtDescuento As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrvProd))
        Me.GrpCliente = New System.Windows.Forms.GroupBox
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtDescuento = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.BtnBuscaPrv = New Janus.Windows.EditControls.UIButton
        Me.TxtRazonSocial = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.GrpCliente.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpCliente
        '
        resources.ApplyResources(Me.GrpCliente, "GrpCliente")
        Me.GrpCliente.Controls.Add(Me.ChkEstado)
        Me.GrpCliente.Controls.Add(Me.Label2)
        Me.GrpCliente.Controls.Add(Me.Label1)
        Me.GrpCliente.Controls.Add(Me.TxtDescuento)
        Me.GrpCliente.Controls.Add(Me.Label11)
        Me.GrpCliente.Controls.Add(Me.BtnBuscaPrv)
        Me.GrpCliente.Controls.Add(Me.TxtRazonSocial)
        Me.GrpCliente.Controls.Add(Me.Label3)
        Me.GrpCliente.Controls.Add(Me.TxtClave)
        Me.GrpCliente.Name = "GrpCliente"
        Me.GrpCliente.TabStop = False
        '
        'ChkEstado
        '
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        resources.ApplyResources(Me.ChkEstado, "ChkEstado")
        Me.ChkEstado.Name = "ChkEstado"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSteelBlue
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSteelBlue
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'TxtDescuento
        '
        resources.ApplyResources(Me.TxtDescuento, "TxtDescuento")
        Me.TxtDescuento.Name = "TxtDescuento"
        Me.TxtDescuento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtDescuento.Value = 0
        Me.TxtDescuento.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'BtnBuscaPrv
        '
        Me.BtnBuscaPrv.Image = CType(resources.GetObject("BtnBuscaPrv.Image"), System.Drawing.Image)
        resources.ApplyResources(Me.BtnBuscaPrv, "BtnBuscaPrv")
        Me.BtnBuscaPrv.Name = "BtnBuscaPrv"
        Me.BtnBuscaPrv.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtRazonSocial
        '
        resources.ApplyResources(Me.TxtRazonSocial, "TxtRazonSocial")
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.ReadOnly = True
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
        'BtnGuardar
        '
        resources.ApplyResources(Me.BtnGuardar, "BtnGuardar")
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        resources.ApplyResources(Me.BtnCancelar, "BtnCancelar")
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmPrvProd
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.GrpCliente)
        Me.Name = "FrmPrvProd"
        Me.GrpCliente.ResumeLayout(False)
        Me.GrpCliente.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Cnx As System.Data.SqlClient.SqlConnection
    Private da As System.Data.SqlClient.SqlDataAdapter

    Private ds As DataTable
    Private bError As Boolean = False

    Public PROClave As String
    Public PRVClave As String = ""
    Public Estado As Integer
    Public Clave As String = ""
    Public Descuento As Double = 0
    Public RazonSocial As String = ""

    Public Padre As String

    Private Sub FrmPrvProd_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.PrvProd.Dispose()
        ModPOS.PrvProd = Nothing
    End Sub

    Private Sub FrmPrvProd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TxtClave.Text = Clave
        TxtDescuento.Text = Descuento
        TxtRazonSocial.Text = RazonSocial

        If Padre = "Modificar" Then
            TxtDescuento.Focus()
            ChkEstado.Estado = Estado
        End If
    End Sub

    Private Sub FrmPrvProde_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub BtnBuscaPrv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaPrv.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_proveedor"
        a.TablaCmb = "Proveedor"
        a.CampoCmb = "Filtro"
        a.NumColDes = 2
        a.NumColDes2 = 4
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            PRVClave = a.valor
            TxtClave.Text = a.Descripcion
            TxtRazonSocial.Text = a.Descripcion2
            TxtDescuento.Focus()
        End If
        a.Dispose()
    End Sub

    Private Sub TxtClave_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClave.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If TxtClave.Text <> "" Then
                    Dim dtProveedor As DataTable

                    dtProveedor = ModPOS.SiExisteRecupera("sp_search_proveedor", "@Campo", 1, "@Busqueda", TxtClave.Text.Trim.ToUpper.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual)
                    If Not dtProveedor Is Nothing AndAlso dtProveedor.Rows.Count > 0 Then

                        PRVClave = dtProveedor.Rows(0)("ID")
                        TxtClave.Text = dtProveedor.Rows(0)("Clave")
                        TxtRazonSocial.Text = dtProveedor.Rows(0)("Razón Social")
                        TxtClave.Focus()
                        dtProveedor.Dispose()
                    Else
                        MessageBox.Show("Información: ¡Clave de Proveedor No Existe!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    PRVClave = ""
                    TxtClave.Text = ""
                    TxtRazonSocial.Text = ""
                    MessageBox.Show("Información: ¡Clave de Proveedor No Valida!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bError = True
                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                End If
        End Select
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Select Case Me.Padre
            Case "Agregar"
                If ModPOS.SiExite(ModPOS.BDConexion, "sp_existe_prvprod", "@PROClave", PROClave, "@PRVClave", PRVClave) = 0 Then
                    Descuento = IIf(TxtDescuento.Text = "", 0, Math.Abs(CDbl(TxtDescuento.Text)))

                    ModPOS.Ejecuta("sp_inserta_prvprod", _
                    "@PRVClave", PRVClave, _
                    "@PROClave", PROClave, _
                    "@Descuento", Descuento, _
                    "@Usuario", ModPOS.UsuarioActual)

                    ChkEstado.Estado = 1

                    If Not ModPOS.Producto Is Nothing Then
                        ModPOS.ActualizaGrid(True, ModPOS.Producto.GridPrv, "sp_muestra_prvpro", "@PROClave", PROClave)
                        ModPOS.Producto.GridPrv.RootTable.Columns("ID").Visible = False
                        ModPOS.Producto.GridPrv.RootTable.Columns("iEstado").Visible = False
                    End If
                Else
                    MessageBox.Show("El proveedor que intenta agregar ya existe para el producto actual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                Padre = "Modificar"

            Case "Modificar"
                If Not ( _
                    Descuento = Math.Abs(CDbl(TxtDescuento.Text)) AndAlso Estado = Me.ChkEstado.GetEstado) Then

                    Descuento = IIf(TxtDescuento.Text = "", 0, Math.Abs(CDbl(TxtDescuento.Text)))

                    Estado = Me.ChkEstado.GetEstado

                    ModPOS.Ejecuta("sp_modifica_prvprod", _
                                    "@PRVClave", PRVClave, _
                                    "@PROClave", PROClave, _
                                    "@Descuento", Descuento, _
                                    "@Estado", Estado, _
                                    "@Usuario", ModPOS.UsuarioActual)

                    If Not ModPOS.Producto Is Nothing Then
                        ModPOS.ActualizaGrid(True, ModPOS.Producto.GridPrv, "sp_muestra_prvpro", "@PROClave", PROClave)
                        ModPOS.Producto.GridPrv.RootTable.Columns("ID").Visible = False
                        ModPOS.Producto.GridPrv.RootTable.Columns("iEstado").Visible = False
                    End If

                    Me.Close()
                End If
        End Select
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub
End Class


