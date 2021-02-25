Public Class FrmAperturaSimple
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
    Friend WithEvents BtnOk As Janus.Windows.EditControls.UIButton
    Friend WithEvents LbNombre As System.Windows.Forms.Label
    Friend WithEvents LBTitulo As System.Windows.Forms.Label
    Friend WithEvents LbClave As System.Windows.Forms.Label
    Friend WithEvents LbUsuario As System.Windows.Forms.Label
    Friend WithEvents LbFecha As System.Windows.Forms.Label
    Friend WithEvents lblEfectivo As System.Windows.Forms.Label
    Friend WithEvents lblOtros As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents TxtEfectivo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtDocumentos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAperturaSimple))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LbNombre = New System.Windows.Forms.Label
        Me.BtnOk = New Janus.Windows.EditControls.UIButton
        Me.LBTitulo = New System.Windows.Forms.Label
        Me.LbClave = New System.Windows.Forms.Label
        Me.LbUsuario = New System.Windows.Forms.Label
        Me.LbFecha = New System.Windows.Forms.Label
        Me.lblEfectivo = New System.Windows.Forms.Label
        Me.lblOtros = New System.Windows.Forms.Label
        Me.lblTotal = New System.Windows.Forms.Label
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.TxtEfectivo = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtDocumentos = New Janus.Windows.GridEX.EditControls.NumericEditBox
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
        'LbNombre
        '
        resources.ApplyResources(Me.LbNombre, "LbNombre")
        Me.LbNombre.Name = "LbNombre"
        '
        'BtnOk
        '
        Me.BtnOk.BackColor = System.Drawing.SystemColors.Control
        Me.BtnOk.Image = CType(resources.GetObject("BtnOk.Image"), System.Drawing.Image)
        resources.ApplyResources(Me.BtnOk, "BtnOk")
        Me.BtnOk.Name = "BtnOk"
        '
        'LBTitulo
        '
        Me.LBTitulo.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.LBTitulo, "LBTitulo")
        Me.LBTitulo.ForeColor = System.Drawing.Color.White
        Me.LBTitulo.Name = "LBTitulo"
        '
        'LbClave
        '
        resources.ApplyResources(Me.LbClave, "LbClave")
        Me.LbClave.Name = "LbClave"
        '
        'LbUsuario
        '
        resources.ApplyResources(Me.LbUsuario, "LbUsuario")
        Me.LbUsuario.Name = "LbUsuario"
        '
        'LbFecha
        '
        resources.ApplyResources(Me.LbFecha, "LbFecha")
        Me.LbFecha.Name = "LbFecha"
        '
        'lblEfectivo
        '
        resources.ApplyResources(Me.lblEfectivo, "lblEfectivo")
        Me.lblEfectivo.Name = "lblEfectivo"
        '
        'lblOtros
        '
        resources.ApplyResources(Me.lblOtros, "lblOtros")
        Me.lblOtros.Name = "lblOtros"
        '
        'lblTotal
        '
        resources.ApplyResources(Me.lblTotal, "lblTotal")
        Me.lblTotal.Name = "lblTotal"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        resources.ApplyResources(Me.BtnCancelar, "BtnCancelar")
        Me.BtnCancelar.Name = "BtnCancelar"
        '
        'TxtEfectivo
        '
        resources.ApplyResources(Me.TxtEfectivo, "TxtEfectivo")
        Me.TxtEfectivo.Name = "TxtEfectivo"
        Me.TxtEfectivo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtEfectivo.Value = 0
        Me.TxtEfectivo.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'txtDocumentos
        '
        resources.ApplyResources(Me.txtDocumentos, "txtDocumentos")
        Me.txtDocumentos.Name = "txtDocumentos"
        Me.txtDocumentos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtDocumentos.Value = 0
        Me.txtDocumentos.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'FrmAperturaSimple
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.txtDocumentos)
        Me.Controls.Add(Me.TxtEfectivo)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblOtros)
        Me.Controls.Add(Me.lblEfectivo)
        Me.Controls.Add(Me.LbFecha)
        Me.Controls.Add(Me.LbUsuario)
        Me.Controls.Add(Me.LbClave)
        Me.Controls.Add(Me.LBTitulo)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.LbNombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmAperturaSimple"
        Me.ShowInTaskbar = False
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Public Impresora As String
    Public Generic As Boolean
    Public Recibo As String

    Public Accion As String
    Public CAJClave As String
    Public Total, Efectivo, Otros As Double
    Public IDCorte As String

    Public Cajon As Boolean = False

    Private Sub creaDetalle(ByVal Tipo As Integer)

        Efectivo = TxtEfectivo.Text

        If Efectivo > 0 Then

            ModPOS.Ejecuta("sp_inserta_corteDetalle", _
                            "@IDCorte", IDCorte, _
                            "@Tipo", Tipo, _
                            "@TipoImporte", 1, _
                            "@Cantidad", 1, _
                            "@Denominacion", 1, _
                            "@Importe", Efectivo)

        End If

        
        Otros = txtDocumentos.Text

        If Otros > 0 Then
            
            ModPOS.Ejecuta("sp_inserta_corteDetalle", _
                            "@IDCorte", IDCorte, _
                            "@Tipo", Tipo, _
                            "@TipoImporte", 3, _
                            "@Cantidad", 1, _
                            "@Importe", Otros)
           
        End If
    End Sub

    Private Sub FrmAperturaSimple_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LbFecha.Text = DateTime.Today.ToLongDateString

        Dim dtCaja As DataTable = ModPOS.SiExisteRecupera("sp_recupera_caja", "@Caja", Me.CAJClave)

        If Not dtCaja Is Nothing Then
            LbClave.Text = "Clave: " & dtCaja.Rows(0)("Clave")
            LbNombre.Text = "Nombre: " & dtCaja.Rows(0)("Nombre")
        End If

        Dim dtUsuario As DataTable = ModPOS.SiExisteRecupera("sp_recupera_UsuarioActual", "@Usuario", ModPOS.UsuarioActual)

        If Not dtUsuario Is Nothing Then
            LbUsuario.Text = "Usuario: " & dtUsuario.Rows(0)("Nombre")
        End If

        If Cajon = True Then
            AbrirCajon(Impresora)
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click

        If Accion = "Apertura" Then
            If IDCorte <> "" Then
                ModPOS.Ejecuta("sp_cierra_corteCaja", "@ID", IDCorte, "@CAJClave", CAJClave, "@Saldo", Total, "@Usuario", ModPOS.UsuarioActual)
                creaDetalle(2)
            End If
            IDCorte = ModPOS.obtenerLlave
            ModPOS.Ejecuta("sp_crea_corteCaja", "@ID", IDCorte, "@CAJClave", CAJClave, "@Saldo", Total, "@Usuario", ModPOS.UsuarioActual)
            creaDetalle(1)
            Dim StopPrint As Boolean = False

            Dim sPrintMessage As String = "¿Desea Imprimir la Apertura de Caja?"
            Do
                Select Case MessageBox.Show(sPrintMessage, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes
                        imprimeTicketApertura(IDCorte, Impresora, Generic, Recibo)
                        sPrintMessage = "¿Desea Reimprimir la Apertura de Caja?"
                    Case Else
                        StopPrint = True
                End Select
            Loop While Not StopPrint


        Else
            ModPOS.Ejecuta("sp_cierra_corteCaja", "@ID", IDCorte, "@CAJClave", CAJClave, "@Saldo", Total, "@Usuario", ModPOS.UsuarioActual)
            creaDetalle(2)

            Dim StopPrint As Boolean = False

            Dim sPrintMessage As String = "¿Desea Imprimir el Corte de Caja?"
            Do
                Select Case MessageBox.Show(sPrintMessage, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes
                        imprimeTicketCierre(IDCorte, Impresora, Generic, Recibo)
                        sPrintMessage = "¿Desea Reimprimir el Corte de Caja?"
                    Case Else
                        StopPrint = True
                End Select
            Loop While Not StopPrint

        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TxtEfectivo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtEfectivo.Leave
        Efectivo = TxtEfectivo.Text
        Otros = txtDocumentos.Text
        Total = Efectivo + Otros
        lblTotal.Text = "Total " & Format(CStr(ModPOS.Redondear(Total, 2)), "Currency")
    End Sub

    Private Sub txtDocumentos_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDocumentos.Leave
        Efectivo = TxtEfectivo.Text
        Otros = txtDocumentos.Text
        Total = Efectivo + Otros
        lblTotal.Text = "Total " & Format(CStr(ModPOS.Redondear(Total, 2)), "Currency")
    End Sub

End Class


