
Public Class FrmSolicitaCliente
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GrpCliente As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAbrir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents LstDomicilio As System.Windows.Forms.ListBox
    Friend WithEvents BtnBuscaCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents BtnContinuar As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblNota As System.Windows.Forms.Label
    Friend WithEvents TxtNota As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSaldo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtDias As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtLimite As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSolicitaCliente))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.GrpCliente = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtSaldo = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtDias = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtLimite = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.LblNota = New System.Windows.Forms.Label
        Me.TxtNota = New System.Windows.Forms.TextBox
        Me.BtnContinuar = New Janus.Windows.EditControls.UIButton
        Me.BtnAbrir = New Janus.Windows.EditControls.UIButton
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.LstDomicilio = New System.Windows.Forms.ListBox
        Me.BtnBuscaCte = New Janus.Windows.EditControls.UIButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.GrpCliente.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Name = "Label2"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Name = "Label5"
        '
        'GrpCliente
        '
        resources.ApplyResources(Me.GrpCliente, "GrpCliente")
        Me.GrpCliente.Controls.Add(Me.Label7)
        Me.GrpCliente.Controls.Add(Me.Label6)
        Me.GrpCliente.Controls.Add(Me.Label4)
        Me.GrpCliente.Controls.Add(Me.txtSaldo)
        Me.GrpCliente.Controls.Add(Me.txtDias)
        Me.GrpCliente.Controls.Add(Me.txtLimite)
        Me.GrpCliente.Controls.Add(Me.LblNota)
        Me.GrpCliente.Controls.Add(Me.TxtNota)
        Me.GrpCliente.Controls.Add(Me.BtnContinuar)
        Me.GrpCliente.Controls.Add(Me.BtnAbrir)
        Me.GrpCliente.Controls.Add(Me.BtnAgregar)
        Me.GrpCliente.Controls.Add(Me.LstDomicilio)
        Me.GrpCliente.Controls.Add(Me.BtnBuscaCte)
        Me.GrpCliente.Controls.Add(Me.Label3)
        Me.GrpCliente.Controls.Add(Me.TxtClave)
        Me.GrpCliente.Name = "GrpCliente"
        Me.GrpCliente.TabStop = False
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'txtSaldo
        '
        resources.ApplyResources(Me.txtSaldo, "txtSaldo")
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtSaldo.Value = 0
        Me.txtSaldo.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'txtDias
        '
        resources.ApplyResources(Me.txtDias, "txtDias")
        Me.txtDias.Name = "txtDias"
        Me.txtDias.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtDias.Value = 0
        Me.txtDias.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'txtLimite
        '
        resources.ApplyResources(Me.txtLimite, "txtLimite")
        Me.txtLimite.Name = "txtLimite"
        Me.txtLimite.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtLimite.Value = 0
        Me.txtLimite.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'LblNota
        '
        resources.ApplyResources(Me.LblNota, "LblNota")
        Me.LblNota.Name = "LblNota"
        '
        'TxtNota
        '
        resources.ApplyResources(Me.TxtNota, "TxtNota")
        Me.TxtNota.Name = "TxtNota"
        '
        'BtnContinuar
        '
        resources.ApplyResources(Me.BtnContinuar, "BtnContinuar")
        Me.BtnContinuar.Icon = CType(resources.GetObject("BtnContinuar.Icon"), System.Drawing.Icon)
        Me.BtnContinuar.Name = "BtnContinuar"
        Me.BtnContinuar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAbrir
        '
        resources.ApplyResources(Me.BtnAbrir, "BtnAbrir")
        Me.BtnAbrir.Icon = CType(resources.GetObject("BtnAbrir.Icon"), System.Drawing.Icon)
        Me.BtnAbrir.Name = "BtnAbrir"
        Me.BtnAbrir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        resources.ApplyResources(Me.BtnAgregar, "BtnAgregar")
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LstDomicilio
        '
        resources.ApplyResources(Me.LstDomicilio, "LstDomicilio")
        Me.LstDomicilio.Name = "LstDomicilio"
        '
        'BtnBuscaCte
        '
        Me.BtnBuscaCte.Image = CType(resources.GetObject("BtnBuscaCte.Image"), System.Drawing.Image)
        resources.ApplyResources(Me.BtnBuscaCte, "BtnBuscaCte")
        Me.BtnBuscaCte.Name = "BtnBuscaCte"
        Me.BtnBuscaCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
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
        'FrmSolicitaCliente
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.GrpCliente)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmSolicitaCliente"
        Me.GrpCliente.ResumeLayout(False)
        Me.GrpCliente.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Cnx As System.Data.SqlClient.SqlConnection
    Private da As System.Data.SqlClient.SqlDataAdapter

    Private ds As DataTable
    Private bError As Boolean = False
    Private bModifico As Boolean = False


    Public CreditoGeneral As String = ""
    Public ClienteInicial As String
    Public ValidaCredito As Boolean = False
    Public ClienteClave As String = ""
    Public ClienteNombre As String = ""
    Public ClienteLimiteCredito As Double
    Public ClienteSaldo As Double
    Public Nota As String = ""

    Private Sub FrmSolicitaCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Show()
        Me.BringToFront()
    End Sub

    Private Sub FrmSolicitaCliente_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Public Function recuperaCliente(ByVal sClave As String) As Boolean
        Dim dtCliente As DataTable = ModPOS.SiExisteRecupera("sp_consulta_clientedomicilio", "@Cliente", sClave, "@COMClave", ModPOS.CompanyActual)
        If Not dtCliente Is Nothing Then
            ClienteClave = dtCliente.Rows(0)("CTEClave")
            TxtClave.Text = dtCliente.Rows(0)("Clave")
            LstDomicilio.Items.Clear()
            LstDomicilio.Items.Add(dtCliente.Rows(0)("RazonSocial"))
            LstDomicilio.Items.Add("RFC: " & CStr(dtCliente.Rows(0)("id_Fiscal")))
            LstDomicilio.Items.Add(dtCliente.Rows(0)("Calle"))
            LstDomicilio.Items.Add(dtCliente.Rows(0)("Domicilio1"))
            LstDomicilio.Items.Add(dtCliente.Rows(0)("Domicilio2"))
            ClienteNombre = dtCliente.Rows(0)("RazonSocial")
            ClienteLimiteCredito = dtCliente.Rows(0)("LimiteCredito")
            ClienteSaldo = dtCliente.Rows(0)("Saldo")
            txtLimite.Text = ClienteLimiteCredito
            txtDias.Text = dtCliente.Rows(0)("DiasCredito")
            txtSaldo.Text = ClienteSaldo
            dtCliente.Dispose()
            Return True
        Else
            MessageBox.Show("El Cliente seleccionado no cuenta con domicilio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtClave.Text = ""
            LstDomicilio.Items.Clear()
            ClienteNombre = ""
            ClienteClave = ""
            ClienteLimiteCredito = 0
            ClienteSaldo = 0
            txtLimite.Text = ClienteLimiteCredito
            txtDias.Text = 0
            txtSaldo.Text = ClienteSaldo
            Return False
        End If

    End Function


    Private Sub BtnBuscaCte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaCte.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_cliente"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.CompaniaRequerido = True
        a.OcultaID = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                recuperaCliente(a.Descripcion)
            End If
        Else
            ClienteClave = ""
            ClienteLimiteCredito = 0
            ClienteSaldo = 0
            txtLimite.Text = ClienteLimiteCredito
            txtDias.Text = 0
            txtSaldo.Text = ClienteSaldo
        End If
        a.Dispose()
        TxtNota.Focus()
    End Sub

    Private Sub BtnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAbrir.Click
        If ClienteClave <> "" Then
            modificarCTE()
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Cliente Is Nothing Then
            ModPOS.Cliente = New FrmCliente
            With ModPOS.Cliente
                .Text = "Agregar Cliente"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .UiTabSaldos.Enabled = False
            End With
        End If
        ModPOS.Cliente.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Cliente.Show()
        ModPOS.Cliente.BringToFront()
    End Sub

    Public Sub modificarCTE()
        If ModPOS.Cliente Is Nothing Then
            ModPOS.Cliente = New FrmCliente
            With ModPOS.Cliente
                .Text = "Modificar Cliente"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Modificar"
                .TxtClave.ReadOnly = True

                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", ClienteClave)
                .TipoOrigen = IIf(dt.Rows(0)("TipoOrigen").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoOrigen"))
                .RegFiscal = IIf(dt.Rows(0)("NumRegIdTrib").GetType.Name = "DBNull", "", dt.Rows(0)("NumRegIdTrib"))
                .CTEClave = dt.Rows(0)("CTEClave")
                .TPersona = dt.Rows(0)("TPersona")
                .Clave = dt.Rows(0)("Clave")
                .NombreCorto = dt.Rows(0)("NombreCorto")
                .RazonSocial = dt.Rows(0)("RazonSocial")
                .RFC = dt.Rows(0)("id_Fiscal")
                .CURP = dt.Rows(0)("CURP")
                .TipoCanal = IIf(dt.Rows(0)("TipoCanal").GetType.Name = "DBNull", 0, dt.Rows(0)("TipoCanal"))
                .listaPrecio = IIf(dt.Rows(0)("PREClave").GetType.Name = "DBNull", "", dt.Rows(0)("PREClave"))
                .Responsable = IIf(dt.Rows(0)("Responsable").GetType.Name = "DBNull", 0, dt.Rows(0)("Responsable"))
                .CtaContable = IIf(dt.Rows(0)("CtaContable").GetType.Name = "DBNull", "", dt.Rows(0)("CtaContable"))

                .FechaReg = dt.Rows(0)("FechaRegistro")
                .Estado = dt.Rows(0)("Estado")
                .Alterno = IIf(dt.Rows(0)("Alterno").GetType.Name = "DBNull", "", dt.Rows(0)("Alterno"))
                .GLN = IIf(dt.Rows(0)("GLN").GetType.Name = "DBNull", "", dt.Rows(0)("GLN"))
                .Ramo = IIf(dt.Rows(0)("Ramo").GetType.Name = "DBNull", 0, dt.Rows(0)("Ramo"))
                .DesglosaIVA = dt.Rows(0)("DesglosaIVA")
                .ImprimirFac = IIf(dt.Rows(0)("ImprimirFac").GetType.Name = "DBNull", True, dt.Rows(0)("ImprimirFac"))
                .Facturable = IIf(dt.Rows(0)("facturable").GetType.Name = "DBNull", True, dt.Rows(0)("facturable"))
              
                .TipoImpuesto = dt.Rows(0)("TipoImpuesto")
                .LCredito = dt.Rows(0)("LimiteCredito")
                .DiasCredito = dt.Rows(0)("DiasCredito")

                .PaisF = dt.Rows(0)("Pais")
                .EntidadF = dt.Rows(0)("Entidad")
                .MnpioF = dt.Rows(0)("Municipio")
                .ColoniaF = dt.Rows(0)("Colonia")
                .CalleF = dt.Rows(0)("Calle")
                .LocalidadF = dt.Rows(0)("Localidad")
                .referenciaF = dt.Rows(0)("referencia")
                .noExteriorF = dt.Rows(0)("noExterior")
                .noInteriorF = dt.Rows(0)("noInterior")
                .codigoPostalF = dt.Rows(0)("codigoPostal")
                .ZonaVentaF = IIf(dt.Rows(0)("ZonaVenta").GetType.Name = "DBNull", 0, dt.Rows(0)("ZonaVenta"))
                .ZonaRepartoF = IIf(dt.Rows(0)("ZonaReparto").GetType.Name = "DBNull", 0, dt.Rows(0)("ZonaReparto"))

                .Contacto = dt.Rows(0)("Contacto")
                .Tel1 = dt.Rows(0)("Tel1")
                .Tel2 = dt.Rows(0)("Tel2")
                .email = dt.Rows(0)("Email")

                .Saldo = dt.Rows(0)("Saldo")
                .CreditoDisponible = dt.Rows(0)("Disponible")

                .DCTEClaveFiscal = IIf(dt.Rows(0)("DCTEClave").GetType.Name = "DBNull", "", dt.Rows(0)("DCTEClave"))

                .DescuentoDirecto = IIf(dt.Rows(0)("DescuentoDirecto").GetType.Name = "DBNull", -1, dt.Rows(0)("DescuentoDirecto"))
                .DescuentoPostVenta = IIf(dt.Rows(0)("DescuentoPostVenta").GetType.Name = "DBNull", -1, dt.Rows(0)("DescuentoPostVenta"))
                .Vendedor = IIf(dt.Rows(0)("Vendedor").GetType.Name = "DBNull", "", dt.Rows(0)("Vendedor"))
                .ClienteSAP = IIf(dt.Rows(0)("ClienteSAP").GetType.Name = "DBNull", "", dt.Rows(0)("ClienteSAP"))
                .UsoCFDI = IIf(dt.Rows(0)("UsoCFDI").GetType.Name = "DBNull", "G03", dt.Rows(0)("UsoCFDI"))
                .AccesoWeb = IIf(dt.Rows(0)("AccesoWeb").GetType.Name = "DBNull", False, dt.Rows(0)("AccesoWeb"))
                .Password = IIf(dt.Rows(0)("Password").GetType.Name = "DBNull", "", dt.Rows(0)("Password"))
                .CtaMaestra = IIf(dt.Rows(0)("CtaMaestra").GetType.Name = "DBNull", dt.Rows(0)("CTEClave"), dt.Rows(0)("CtaMaestra"))
               
                dt.Dispose()

            End With
        End If

        ModPOS.Cliente.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Cliente.Show()
        ModPOS.Cliente.BringToFront()
        bModifico = True
    End Sub

    Private Sub TxtClave_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClave.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Right
                Dim a As New MeSearch
                a.ProcedimientoAlmacenado = "sp_search_cliente"
                a.TablaCmb = "Cliente"
                a.CampoCmb = "Filtro"
                a.OcultaID = True
                a.BusquedaInicial = True
                a.CompaniaRequerido = True
                a.Busqueda = TxtClave.Text.Trim.ToUpper
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    If Not a.valor Is Nothing Then
                        recuperaCliente(a.Descripcion)
                    End If
                Else
                    ClienteClave = ""
                    ClienteLimiteCredito = 0
                    ClienteSaldo = 0
                    txtLimite.Text = ClienteLimiteCredito
                    txtDias.Text = 0
                    txtSaldo.Text = ClienteSaldo
                End If
                a.Dispose()
            Case Is = Keys.Escape
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                bError = False
                Me.Close()
            Case Is = Keys.Enter
                If TxtClave.Text <> "" Then
                    If recuperaCliente(TxtClave.Text.Trim.ToUpper.Replace("'", "''")) = True Then

                        If CreditoGeneral = ClienteClave Then
                            TxtNota.Focus()
                            bError = False
                        ElseIf ClienteInicial = ClienteClave Then
                            ClienteClave = ""
                            MessageBox.Show("El cliente seleccionado debe ser diferente al cliente predeterminado o general", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            TxtClave.Text = ""
                            LstDomicilio.Items.Clear()
                            ClienteClave = ""
                            ClienteNombre = ""
                            ClienteLimiteCredito = 0
                            ClienteSaldo = 0
                            txtLimite.Text = ClienteLimiteCredito
                            txtDias.Text = 0
                            txtSaldo.Text = ClienteSaldo
                            bError = True
                            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                        Else
                            If ValidaCredito Then
                                If (ClienteLimiteCredito - ClienteSaldo) > 0 Then
                                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                                    bError = False
                                Else
                                    MessageBox.Show("El cliente no cuenta con limite de crédito disponible", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                    bError = True
                                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                                End If
                            Else
                                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                                bError = False
                            End If
                        End If
                    Else
                        bError = True
                        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                    End If
                Else
                    ClienteClave = ""
                    MessageBox.Show("Información: ¡Clave de Cliente No Valida!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bError = True
                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                End If
        End Select

    End Sub

    Private Sub BtnContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnContinuar.Click
        If bModifico Then
            If TxtClave.Text <> "" Then
                recuperaCliente(TxtClave.Text.Trim.ToUpper.Replace("'", "''"))
            End If
            bModifico = False
        End If

        If ClienteClave <> "" Then
            If CreditoGeneral = ClienteClave Then
                bError = False
                Me.DialogResult = System.Windows.Forms.DialogResult.OK

                If TxtNota.Text = "" Then
                    MessageBox.Show("El campo Nota es requerido para indicar el nombre del cliente de credito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bError = True
                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Else
                    Nota = TxtNota.Text.ToUpper.Trim
                End If

            ElseIf ClienteInicial = ClienteClave Then
                ClienteClave = ""
                MessageBox.Show("El cliente seleccionado debe ser diferente al cliente predeterminado o general", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bError = True
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                TxtClave.Text = ""
                LstDomicilio.Items.Clear()
                ClienteClave = ""
                ClienteNombre = ""
                ClienteLimiteCredito = 0
                ClienteSaldo = 0
            Else
                If ValidaCredito Then
                    If (ClienteLimiteCredito - ClienteSaldo) > 0 Then
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        bError = False
                    Else
                        MessageBox.Show("El cliente no cuenta con crédito ó ha sobrepasado su limite disponible", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        bError = True
                        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                    End If
                Else
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    bError = False
                End If
            End If
        Else
            MessageBox.Show("No existe un cliente seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bError = True
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub BtnCtrl_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnAbrir.KeyUp, BtnAgregar.KeyUp, BtnBuscaCte.KeyUp, BtnContinuar.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Escape
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                bError = False
                Me.Close()
        End Select
    End Sub

    Private Sub TxtNota_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNota.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If TxtNota.Text = "" Then
                    bError = True
                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Else
                    Nota = TxtNota.Text.ToUpper.Trim
                    bError = False
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            Case Is = Keys.Escape

                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel

                bError = False
                Me.Close()
        End Select
    End Sub

  
End Class


