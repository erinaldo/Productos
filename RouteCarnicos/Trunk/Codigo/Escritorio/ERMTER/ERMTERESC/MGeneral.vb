Imports BASMENLOG
Imports ERMTERLOG

Public Class MGeneral
    Inherits FormasBase.Mantenimiento01

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
    Friend WithEvents lbFase As System.Windows.Forms.Label
    Friend WithEvents cbFase As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lbDescripcion As System.Windows.Forms.Label
    Friend WithEvents lbNoSerie As System.Windows.Forms.Label
    Friend WithEvents lbComentario As System.Windows.Forms.Label
    Friend WithEvents ebDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNoSerie As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebComentario As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents chkGPS As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents epErrores As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.lbFase = New System.Windows.Forms.Label
        Me.cbFase = New Janus.Windows.EditControls.UIComboBox
        Me.lbDescripcion = New System.Windows.Forms.Label
        Me.lbNoSerie = New System.Windows.Forms.Label
        Me.lbComentario = New System.Windows.Forms.Label
        Me.ebDescripcion = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebNoSerie = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebComentario = New Janus.Windows.GridEX.EditControls.EditBox
        Me.epErrores = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.chkGPS = New Janus.Windows.EditControls.UICheckBox
        CType(Me.epErrores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EbClave
        '
        Me.EbClave.Size = New System.Drawing.Size(148, 20)
        '
        'BtAceptar
        '
        Me.BtAceptar.Location = New System.Drawing.Point(388, 152)
        Me.BtAceptar.TabIndex = 6
        '
        'BtCancelar
        '
        Me.BtCancelar.Location = New System.Drawing.Point(500, 152)
        Me.BtCancelar.TabIndex = 7
        '
        'lbLinea
        '
        Me.lbLinea.Location = New System.Drawing.Point(8, 140)
        '
        'lbFase
        '
        Me.lbFase.Location = New System.Drawing.Point(320, 12)
        Me.lbFase.Name = "lbFase"
        Me.lbFase.Size = New System.Drawing.Size(132, 20)
        Me.lbFase.TabIndex = 17
        Me.lbFase.Text = "Fase"
        Me.lbFase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbFase
        '
        Me.cbFase.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbFase.Location = New System.Drawing.Point(456, 12)
        Me.cbFase.Name = "cbFase"
        Me.cbFase.Size = New System.Drawing.Size(148, 20)
        Me.cbFase.TabIndex = 2
        Me.cbFase.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lbDescripcion
        '
        Me.lbDescripcion.Location = New System.Drawing.Point(12, 38)
        Me.lbDescripcion.Name = "lbDescripcion"
        Me.lbDescripcion.Size = New System.Drawing.Size(132, 20)
        Me.lbDescripcion.TabIndex = 19
        Me.lbDescripcion.Text = "Descripción"
        Me.lbDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbNoSerie
        '
        Me.lbNoSerie.Location = New System.Drawing.Point(12, 64)
        Me.lbNoSerie.Name = "lbNoSerie"
        Me.lbNoSerie.Size = New System.Drawing.Size(132, 20)
        Me.lbNoSerie.TabIndex = 20
        Me.lbNoSerie.Text = "Número de Serie"
        Me.lbNoSerie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbComentario
        '
        Me.lbComentario.Location = New System.Drawing.Point(12, 90)
        Me.lbComentario.Name = "lbComentario"
        Me.lbComentario.Size = New System.Drawing.Size(132, 20)
        Me.lbComentario.TabIndex = 21
        Me.lbComentario.Text = "Comentario"
        Me.lbComentario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebDescripcion
        '
        Me.ebDescripcion.Location = New System.Drawing.Point(148, 38)
        Me.ebDescripcion.MaxLength = 32
        Me.ebDescripcion.Name = "ebDescripcion"
        Me.ebDescripcion.Size = New System.Drawing.Size(456, 20)
        Me.ebDescripcion.TabIndex = 3
        Me.ebDescripcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDescripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebNoSerie
        '
        Me.ebNoSerie.Enabled = False
        Me.ebNoSerie.Location = New System.Drawing.Point(148, 64)
        Me.ebNoSerie.MaxLength = 20
        Me.ebNoSerie.Name = "ebNoSerie"
        Me.ebNoSerie.Size = New System.Drawing.Size(312, 20)
        Me.ebNoSerie.TabIndex = 4
        Me.ebNoSerie.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNoSerie.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebComentario
        '
        Me.ebComentario.Location = New System.Drawing.Point(148, 90)
        Me.ebComentario.MaxLength = 64
        Me.ebComentario.Multiline = True
        Me.ebComentario.Name = "ebComentario"
        Me.ebComentario.Size = New System.Drawing.Size(456, 40)
        Me.ebComentario.TabIndex = 5
        Me.ebComentario.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebComentario.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'epErrores
        '
        Me.epErrores.ContainerControl = Me
        '
        'chkGPS
        '
        Me.chkGPS.Location = New System.Drawing.Point(500, 61)
        Me.chkGPS.Name = "chkGPS"
        Me.chkGPS.Size = New System.Drawing.Size(104, 23)
        Me.chkGPS.TabIndex = 22
        Me.chkGPS.Text = "GPS"
        Me.chkGPS.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'MGeneral
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(618, 184)
        Me.Controls.Add(Me.chkGPS)
        Me.Controls.Add(Me.ebComentario)
        Me.Controls.Add(Me.ebNoSerie)
        Me.Controls.Add(Me.ebDescripcion)
        Me.Controls.Add(Me.lbComentario)
        Me.Controls.Add(Me.lbNoSerie)
        Me.Controls.Add(Me.lbDescripcion)
        Me.Controls.Add(Me.cbFase)
        Me.Controls.Add(Me.lbFase)
        Me.Name = "MGeneral"
        Me.Controls.SetChildIndex(Me.lbFase, 0)
        Me.Controls.SetChildIndex(Me.cbFase, 0)
        Me.Controls.SetChildIndex(Me.EbClave, 0)
        Me.Controls.SetChildIndex(Me.lbClave, 0)
        Me.Controls.SetChildIndex(Me.BtCancelar, 0)
        Me.Controls.SetChildIndex(Me.BtAceptar, 0)
        Me.Controls.SetChildIndex(Me.lbLinea, 0)
        Me.Controls.SetChildIndex(Me.lbDescripcion, 0)
        Me.Controls.SetChildIndex(Me.lbNoSerie, 0)
        Me.Controls.SetChildIndex(Me.lbComentario, 0)
        Me.Controls.SetChildIndex(Me.ebDescripcion, 0)
        Me.Controls.SetChildIndex(Me.ebNoSerie, 0)
        Me.Controls.SetChildIndex(Me.ebComentario, 0)
        Me.Controls.SetChildIndex(Me.chkGPS, 0)
        CType(Me.epErrores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Dim vgModo As eModo
    Dim vcTerminal As cTerminal
    Dim vgUsuarioID As String
    Dim vgCerrar As Boolean = False
    Public vcMensaje As CMensaje
    Private vlHuboCambios As Boolean = False
    Private vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia

    Function CREAR(ByRef prTerminal As cTerminal, ByVal pvUsuarioID As String) As Boolean
        vgModo = eModo.Crear
        vcTerminal = prTerminal
        vgUsuarioID = pvUsuarioID

        ConfigurarTitulos()


        Me.Text = vcMensaje.RecuperarDescripcion("ERMTERESC_MGeneralC")

        If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
            vcConexion.ConfirmarTran()
            Return True
        Else
            vcConexion.DeshacerTran()
            Return False
        End If
    End Function
    Dim vcLoading As Boolean = False
    Function MODIFICAR(ByRef prTerminal As cTerminal, ByVal pvUsuarioID As String) As Boolean
        vcLoading = True
        vgModo = eModo.Modificar
        vcTerminal = prTerminal
        vgUsuarioID = pvUsuarioID

        ConfigurarTitulos()

        Me.Text = vcMensaje.RecuperarDescripcion("ERMTERESC_MGeneralM")
        vcLoading = False
        If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
            vcConexion.ConfirmarTran()
            Return True
        Else
            vcConexion.DeshacerTran()
            Return False
        End If
    End Function
    Function Consultar(ByRef prTerminal As cTerminal, ByVal pvUsuarioID As String) As Boolean
        vgModo = eModo.Leer
        vcTerminal = prTerminal
        vgUsuarioID = pvUsuarioID

        ConfigurarTitulos()
        Me.Text = vcMensaje.RecuperarDescripcion("XConsultar") + " " + vcMensaje.RecuperarDescripcion("ERMTERESC_NGeneral")
        BtAceptar.Visible = False
        BtCancelar.Text = vcMensaje.RecuperarDescripcion("BTRegresar")
        BtCancelar.Icon = BtAceptar.Icon
        BtCancelar.ToolTipText = vcMensaje.RecuperarDescripcion("BTRegresar")

        Dim excep As New ArrayList
        excep.Add("BtCancelar")
        DeshabilitarControles(Me, excep)

        Me.ShowDialog()

        
    End Function
    Private Sub DeshabilitarControles(ByVal ctrl As Control, ByVal excep As ArrayList)
        If Not excep.Contains(ctrl.Name) Then
            If ctrl.GetType.Namespace = "Janus.Windows.GridEX" Then
                DirectCast(ctrl, Janus.Windows.GridEX.GridEX).AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If

            If ctrl.Controls.Count > 0 Then
                For Each ctrls As Control In ctrl.Controls
                    DeshabilitarControles(ctrls, excep)
                Next
            Else
                ctrl.Enabled = False
            End If
        End If


    End Sub
    Private Sub LimpiarCampos()
        EbClave.Text = ""
        cbFase.SelectedValue = 1
        ebDescripcion.Text = ""
        ebNoSerie.Text = ""
        ebComentario.Text = ""
        chkGPS.Checked = False
    End Sub

    Private Sub LlenarCampos()
        EbClave.Text = vcTerminal.TerminalClave        
        cbFase.SelectedValue = vcTerminal.TipoFase
        ebDescripcion.Text = vcTerminal.Descripcion
        ebNoSerie.Text = vcTerminal.NumeroSerie
        ebComentario.Text = vcTerminal.Comentario
        chkGPS.Checked = vcTerminal.GPS
        EbClave.Enabled = False
    End Sub

    Private Sub ConfigurarTitulos()
        vcMensaje = New CMensaje
        Me.lbClave.Text = vcMensaje.RecuperarDescripcion("TERTerminalClave")
        Me.lbFase.Text = vcMensaje.RecuperarDescripcion("TERTipoFase")
        Me.lbDescripcion.Text = vcMensaje.RecuperarDescripcion("TERDescripcion")
        Me.lbNoSerie.Text = vcMensaje.RecuperarDescripcion("TERNumeroSerie")
        Me.lbComentario.Text = vcMensaje.RecuperarDescripcion("TERComentario")
        Me.chkGPS.Text = vcMensaje.RecuperarDescripcion("TERGps")

        'Poner en el Tag el Nombre del Campo en la BD
        Me.EbClave.Tag = "TerminalClave"
        Me.cbFase.Tag = "TipoFase"
        Me.ebDescripcion.Tag = "Descripcion"
        Me.ebNoSerie.Tag = "NumeroSerie"
        Me.ebComentario.Tag = "Comentario"
        Me.chkGPS.Tag = "GPS"

        Dim vlToolTip As New ToolTip

        With vlToolTip
            .ShowAlways = True
            .SetToolTip(Me.EbClave, vcMensaje.RecuperarDescripcion("TERTerminalClaveT"))
            .SetToolTip(Me.cbFase, vcMensaje.RecuperarDescripcion("TERTipoFaseT"))
            .SetToolTip(Me.ebDescripcion, vcMensaje.RecuperarDescripcion("TERDescripcionT"))
            .SetToolTip(Me.ebNoSerie, vcMensaje.RecuperarDescripcion("TERNumeroSerieT"))
            .SetToolTip(Me.ebComentario, vcMensaje.RecuperarDescripcion("TERComentarioT"))
            .SetToolTip(Me.BtAceptar, vcMensaje.RecuperarDescripcion("BTAceptarT"))
            .SetToolTip(Me.chkGPS, vcMensaje.RecuperarDescripcion("TERGpsT"))
            If vgModo <> eModo.Leer Then .SetToolTip(Me.BtCancelar, vcMensaje.RecuperarDescripcion("BTCancelarT"))
        End With



        Me.BtAceptar.Text = vcMensaje.RecuperarDescripcion("BTAceptar")
        Me.BtCancelar.Text = vcMensaje.RecuperarDescripcion("BTCancelar")

        If vgModo = eModo.Crear Then
            Me.EbClave.Enabled = True
            LlenarCbTipo()
            LimpiarCampos()
            QuitarEstadoAsignado()
        ElseIf vgModo = eModo.Modificar Or vgModo = eModo.Leer Then            
            LlenarCbTipo()
            LimpiarCampos()
            LlenarCampos()
            QuitarEstadoAsignado()
        End If

        vlHuboCambios = False
    End Sub

    Private Sub QuitarEstadoAsignado()       
        For Each vlItem As Janus.Windows.EditControls.UIComboBoxItem In cbFase.Items
            If vlItem.Value = 3 Then
                If CInt(vgModo) And 1 Then
                    ' crear
                    cbFase.Items.Remove(vlItem)
                ElseIf CInt(vgModo) And 3 Then
                    ' modificar
                    If Not vlItem.Value = cbFase.SelectedValue Then
                        cbFase.Items.Remove(vlItem)
                    End If
                Else
                    ' leer
                    cbFase.Enabled = False
                End If
                Exit Sub
            End If
            
        Next
    End Sub

    Private Sub BtAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAceptar.Click

        Me.DialogResult = Windows.Forms.DialogResult.None

        Select Case vgModo
            Case eModo.Crear
                Try
                    If EbClave.Text <> "" Then
                        If vcTerminal.Existe(EbClave.Text) Then
                            MsgBox(vcMensaje.RecuperarDescripcion("BE0002"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                            EbClave.Focus()
                            Exit Sub
                        End If
                    End If

                    If vcTerminal.Insertar(Me.EbClave.Text, Me.cbFase.SelectedValue, Me.ebDescripcion.Text, Me.ebNoSerie.Text, Me.ebComentario.Text, Me.chkGPS.Checked, vgUsuarioID) Then
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                    Else
                        Exit Sub
                    End If
                Catch ex As LbControlError.cError
                    ex.Mostrar()
                    PonerFoco(ex.Source)
                    Exit Sub
                End Try
            Case eModo.Modificar
                Try
                    With vcTerminal
                        .TipoFase = cbFase.SelectedValue
                        .Descripcion = ebDescripcion.Text
                        .NumeroSerie = ebNoSerie.Text
                        .Comentario = ebComentario.Text
                        .GPS = chkGPS.Checked
                    End With
                    vcTerminal.MUsuarioID = vgUsuarioID
                    If vcTerminal.Grabar() Then
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                    Else
                        Exit Sub
                    End If
                Catch ex As LbControlError.cError
                    ex.Mostrar()
                    PonerFoco(ex.Source)
                    Exit Sub
                End Try
        End Select

        vgCerrar = True
        Me.Close()
    End Sub

    Private Sub PonerFoco(ByVal pvNombreCampo As String)
        Select Case pvNombreCampo
            Case "TerminalClave"
                Me.EbClave.Focus()
            Case "TipoFase"
                Me.cbFase.Focus()
            Case "Descripcion"
                Me.ebDescripcion.Focus()
            Case "NumeroSerie"
                Me.ebNoSerie.Focus()
            Case "Comentario"
                Me.ebComentario.Focus()
        End Select
    End Sub

    Private Sub LlenarCbTipo()
        lbGeneral.LlenarComboBox(cbFase, "TERFASE")
    End Sub

    Private Sub BtCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancelar.Click
        Me.Close()
    End Sub

    Private Sub MGeneral_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not vgCerrar And vlHuboCambios Then            

            Me.DialogResult = Windows.Forms.DialogResult.None

            If MsgBox(vcMensaje.RecuperarDescripcion("BP0001"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, vcMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.Yes Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Else
                e.Cancel = False
            End If
        End If
    End Sub

#Region "Validaciones Campos"
    Private Sub EbRequeridos_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EbClave.Validated
        Try
            If sender.Text = "" Then
                epErrores.SetError(sender, vcMensaje.RecuperarDescripcion("BE0001", New String() {vcMensaje.RecuperarDescripcion("TER" & sender.tag)}))
                Exit Sub
            End If
            If UCase(sender.name) = UCase("ebClave") Then
                If vcTerminal.Existe(EbClave.Text) Then
                    If Me.vlHuboCambios Then
                        epErrores.SetError(sender, vcMensaje.RecuperarDescripcion("BE0002"))
                        Exit Sub
                    End If
                End If
            End If
            epErrores.SetError(sender, "")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EbNumericos_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFase.Validated
        Try
            If sender.value < 0 Then
                epErrores.SetError(sender, vcMensaje.RecuperarDescripcion("E0007"))
                Exit Sub
            End If
            epErrores.SetError(sender, "")
        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Sub Controles_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EbClave.TextChanged, cbFase.SelectedValueChanged, ebDescripcion.TextChanged, ebNoSerie.TextChanged, ebComentario.TextChanged
        vlHuboCambios = True
        If sender.name = "cbFase" And vgModo = eModo.Modificar And vcLoading = False Then
            If vcTerminal.TipoFase = 1 And cbFase.SelectedValue <> 1 Then

                Dim config As New ERMSEMLOG.cSubEmpresa
                Dim dtSubEmpresas As DataTable = config.RecuperarTabla()
                For Each row As DataRow In dtSubEmpresas.Rows
                    config.Recuperar(row("SubEmpresaID"))

                    If (config.FoliosTerminal And config.ComprobanteDig) Then
                        If vcTerminal.FoliosAsignados(row("SubEmpresaID")) Then
                            If MsgBox(vcMensaje.RecuperarDescripcion("P0115"), MsgBoxStyle.YesNo Or MsgBoxStyle.Question, vcMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.Yes Then
                                MsgBox(vcMensaje.RecuperarDescripcion("I0172"), MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, vcMensaje.RecuperarDescripcion("XMensajeI"))
                            Else
                                cbFase.SelectedValue = 1
                            End If
                        End If
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub cbFase_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbFase.SelectedIndexChanged

    End Sub

    Private Sub MGeneral_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If vgModo = eModo.Leer Then BtCancelar.Focus()
    End Sub
End Class

Public Enum eModo
    Crear = 1
    Modificar = 2
    Leer = 3
End Enum

