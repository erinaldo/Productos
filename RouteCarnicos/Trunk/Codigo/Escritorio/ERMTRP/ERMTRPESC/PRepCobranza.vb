Imports BASMENLOG

Public Class PRepCobranza
    Inherits FormasBase.Mantenimiento01

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents btCliente As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebNombreCorto As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents gbRepVenta As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents ebClienteClave As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents chbClienteClave As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ebCliente As Janus.Windows.GridEX.EditControls.EditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btCliente = New Janus.Windows.EditControls.UIButton
        Me.ebNombreCorto = New Janus.Windows.GridEX.EditControls.EditBox
        Me.gbRepVenta = New Janus.Windows.EditControls.UIGroupBox
        Me.ebClienteClave = New Janus.Windows.GridEX.EditControls.EditBox
        Me.chbClienteClave = New Janus.Windows.EditControls.UICheckBox
        Me.ebCliente = New Janus.Windows.GridEX.EditControls.EditBox
        CType(Me.gbRepVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRepVenta.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbLinea
        '
        Me.lbLinea.Location = New System.Drawing.Point(8, 96)
        Me.lbLinea.Name = "lbLinea"
        Me.lbLinea.Size = New System.Drawing.Size(8, 4)
        Me.lbLinea.Visible = False
        '
        'BtAceptar
        '
        Me.BtAceptar.Location = New System.Drawing.Point(396, 80)
        Me.BtAceptar.Name = "BtAceptar"
        '
        'lbClave
        '
        Me.lbClave.Location = New System.Drawing.Point(28, 84)
        Me.lbClave.Name = "lbClave"
        Me.lbClave.Size = New System.Drawing.Size(8, 20)
        Me.lbClave.Visible = False
        '
        'BtCancelar
        '
        Me.BtCancelar.Location = New System.Drawing.Point(508, 80)
        Me.BtCancelar.Name = "BtCancelar"
        '
        'EbClave
        '
        Me.EbClave.Location = New System.Drawing.Point(36, 88)
        Me.EbClave.Name = "EbClave"
        Me.EbClave.Size = New System.Drawing.Size(8, 20)
        Me.EbClave.Visible = False
        '
        'btCliente
        '
        Me.btCliente.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Ellipsis
        Me.btCliente.Location = New System.Drawing.Point(224, 24)
        Me.btCliente.Name = "btCliente"
        Me.btCliente.Size = New System.Drawing.Size(28, 20)
        Me.btCliente.TabIndex = 17
        '
        'ebNombreCorto
        '
        Me.ebNombreCorto.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNombreCorto.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNombreCorto.Enabled = False
        Me.ebNombreCorto.Location = New System.Drawing.Point(252, 24)
        Me.ebNombreCorto.Name = "ebNombreCorto"
        Me.ebNombreCorto.Size = New System.Drawing.Size(340, 20)
        Me.ebNombreCorto.TabIndex = 18
        Me.ebNombreCorto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombreCorto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'gbRepVenta
        '
        Me.gbRepVenta.Controls.Add(Me.ebCliente)
        Me.gbRepVenta.Controls.Add(Me.ebClienteClave)
        Me.gbRepVenta.Controls.Add(Me.chbClienteClave)
        Me.gbRepVenta.Controls.Add(Me.ebNombreCorto)
        Me.gbRepVenta.Controls.Add(Me.btCliente)
        Me.gbRepVenta.Location = New System.Drawing.Point(12, 8)
        Me.gbRepVenta.Name = "gbRepVenta"
        Me.gbRepVenta.Size = New System.Drawing.Size(600, 60)
        Me.gbRepVenta.TabIndex = 19
        Me.gbRepVenta.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'ebClienteClave
        '
        Me.ebClienteClave.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebClienteClave.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebClienteClave.Location = New System.Drawing.Point(140, 24)
        Me.ebClienteClave.Name = "ebClienteClave"
        Me.ebClienteClave.Size = New System.Drawing.Size(84, 20)
        Me.ebClienteClave.TabIndex = 20
        Me.ebClienteClave.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebClienteClave.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'chbClienteClave
        '
        Me.chbClienteClave.Location = New System.Drawing.Point(8, 24)
        Me.chbClienteClave.Name = "chbClienteClave"
        Me.chbClienteClave.Size = New System.Drawing.Size(132, 20)
        Me.chbClienteClave.TabIndex = 19
        Me.chbClienteClave.Text = "chbClienteClave"
        '
        'ebCliente
        '
        Me.ebCliente.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCliente.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCliente.Location = New System.Drawing.Point(592, 24)
        Me.ebCliente.Name = "ebCliente"
        Me.ebCliente.Size = New System.Drawing.Size(4, 20)
        Me.ebCliente.TabIndex = 21
        Me.ebCliente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCliente.Visible = False
        '
        'PRepCobranza
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(624, 112)
        Me.Controls.Add(Me.gbRepVenta)
        Me.Name = "PRepCobranza"
        Me.Controls.SetChildIndex(Me.gbRepVenta, 0)
        Me.Controls.SetChildIndex(Me.EbClave, 0)
        Me.Controls.SetChildIndex(Me.lbClave, 0)
        Me.Controls.SetChildIndex(Me.BtCancelar, 0)
        Me.Controls.SetChildIndex(Me.BtAceptar, 0)
        Me.Controls.SetChildIndex(Me.lbLinea, 0)
        CType(Me.gbRepVenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRepVenta.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Shared gInstance As PRepCobranza = Nothing
    Private oConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private oMensaje As CMensaje = New CMensaje
    Private bClienteCambio As Boolean = False

    Public Shared ReadOnly Property Instance() As PRepCobranza
        Get
            If gInstance Is Nothing OrElse gInstance.IsDisposed Then
                gInstance = New PRepCobranza
            End If
            gInstance.BringToFront()
            Return gInstance
        End Get
    End Property

    Public Sub Inicio(ByVal pvAcceso As LbAcceso.cAcceso)
        Me.ShowDialog()
    End Sub

    Private Sub NGeneral_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

#If DEBUG Then
        '<Quitar>
        oConexion.Conectar("Provider=SQLOLEDB;Data Source=RAMIROLAP;user id=sa;password=dbsa;initial catalog=ROUTE")
        oMensaje = New CMensaje
        oMensaje.LlenarDataSet()
        lbGeneral.cParametros.UsuarioID = "Admin"
        '<\Quitar>
#End If

        Me.Text = oMensaje.RecuperarDescripcion("ERMReportes_PRepCobranza")

        chbClienteClave.Text = oMensaje.RecuperarDescripcion("XCliente")
        BtAceptar.Text = oMensaje.RecuperarDescripcion("btAceptar")
        BtCancelar.Text = oMensaje.RecuperarDescripcion("btCancelar")
        chbClienteClave.Checked = False
        ebClienteClave.Enabled = False
        btCliente.Enabled = False
        ebClienteClave.Text = ""
        ebNombreCorto.Text = ""

        Dim loToolTip As New ToolTip
        'loToolTip.SetToolTip(BtAceptar, oMensaje.RecuperarDescripcion("btAceptarT"))
        'loToolTip.SetToolTip(BtCancelar, oMensaje.RecuperarDescripcion("btCancelarT"))

    End Sub

    Private Sub BtAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAceptar.Click
        Try
            Dim oReporte As New RRepCobranza
            BtAceptar.Enabled = False
            If chbClienteClave.Checked Then
                oReporte.CONSULTAR(ebCliente.Text)
            Else
                oReporte.CONSULTAR("%")
            End If
            BtAceptar.Enabled = True
        Catch ex As LbControlError.cError
            ex.Mostrar()
            BtAceptar.Enabled = True
        End Try
    End Sub

    Private Sub BtCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancelar.Click
        Me.Close()
    End Sub

    Private Sub btCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCliente.Click
        Dim oSeleccionarCliente As New ERMCLIESC.IGeneral
        Dim alClientes As ArrayList

        alClientes = oSeleccionarCliente.Seleccionar("", False)
        If Not alClientes Is Nothing Then
            ebCliente.Text = alClientes(0).ClienteClave
            ebClienteClave.Text = alClientes(0).Clave
            ebNombreCorto.Text = alClientes(0).NombreCorto
            bClienteCambio = False
        End If
    End Sub

    Private Sub chbClienteClave_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbClienteClave.CheckedChanged
        If chbClienteClave.Checked Then
            ebClienteClave.Enabled = True
            btCliente.Enabled = True
        Else
            ebClienteClave.Enabled = False
            btCliente.Enabled = False
        End If
    End Sub

    Private Sub ebClienteClave_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebClienteClave.Validating
        Dim oCliente As New ERMCLILOG.cCliente
        If Not bClienteCambio Then Exit Sub
        If ebClienteClave.Text <> "" Then
            Try
                Dim vlDataTable As New DataTable
                vlDataTable = oCliente.Tabla.Recuperar("Clave='" + ebClienteClave.Text + "'")
                If vlDataTable.Rows.Count = 0 Then
                    MsgBox(oMensaje.RecuperarDescripcion("E0027"), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                    e.Cancel = True
                    Exit Sub
                ElseIf vlDataTable.Rows.Count > 1 Then
                    Dim loClienteIndex As New ERMCLIESC.IGeneral
                    Dim lalArrayList As ArrayList
                    lalArrayList = loClienteIndex.Seleccionar("Clave='" + ebClienteClave.Text + "'", False)
                    If IsNothing(lalArrayList) = False Then
                        vlDataTable = oCliente.Tabla.Recuperar("ClienteClave='" + lalArrayList(0).ClienteClave + "'")
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                End If

                oCliente.Recuperar(vlDataTable.Rows(0)!ClienteClave)
                ebCliente.Text = oCliente.ClienteClave
                ebClienteClave.Text = oCliente.Clave
                ebNombreCorto.Text = oCliente.NombreCorto
            Catch ex As LbControlError.cError
                ex.Mostrar()
                e.Cancel = True
                Exit Sub
            End Try
        Else
            ebNombreCorto.Text = ""
            ebCliente.Text = ""
        End If
        bClienteCambio = False
    End Sub

    Private Sub ebClienteClave_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebClienteClave.TextChanged
        bClienteCambio = True
    End Sub
End Class
