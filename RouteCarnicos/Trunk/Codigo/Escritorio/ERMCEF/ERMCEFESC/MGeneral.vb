Imports ERMCEFLOG
Imports BASMENLOG
Imports lbGeneral

Public Enum eModo
    Crear
    Modificar
    Eliminar
    Leer
End Enum

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
    Friend WithEvents ebNumCertificado As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbNumCertificado As System.Windows.Forms.Label
    Friend WithEvents cbFechaInicial As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents LbFechaInicial As System.Windows.Forms.Label
    Friend WithEvents cbFechaFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents lbFechaFinal As System.Windows.Forms.Label
    Friend WithEvents ebConfirmar As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbConfirmar As System.Windows.Forms.Label
    Friend WithEvents epErrores As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ebNumCertificado = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbNumCertificado = New System.Windows.Forms.Label
        Me.cbFechaInicial = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.LbFechaInicial = New System.Windows.Forms.Label
        Me.cbFechaFinal = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.lbFechaFinal = New System.Windows.Forms.Label
        Me.epErrores = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lbConfirmar = New System.Windows.Forms.Label
        Me.ebConfirmar = New Janus.Windows.GridEX.EditControls.EditBox
        CType(Me.epErrores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EbClave
        '
        Me.EbClave.Location = New System.Drawing.Point(48, 96)
        Me.EbClave.Size = New System.Drawing.Size(12, 20)
        Me.EbClave.TabIndex = 10
        Me.EbClave.Visible = False
        '
        'lbClave
        '
        Me.lbClave.Location = New System.Drawing.Point(32, 96)
        Me.lbClave.Size = New System.Drawing.Size(12, 20)
        Me.lbClave.TabIndex = 9
        Me.lbClave.Visible = False
        '
        'BtAceptar
        '
        Me.BtAceptar.Location = New System.Drawing.Point(396, 100)
        Me.BtAceptar.TabIndex = 11
        '
        'BtCancelar
        '
        Me.BtCancelar.Location = New System.Drawing.Point(508, 100)
        Me.BtCancelar.TabIndex = 12
        '
        'lbLinea
        '
        Me.lbLinea.Location = New System.Drawing.Point(12, 88)
        Me.lbLinea.TabIndex = 8
        '
        'ebNumCertificado
        '
        Me.ebNumCertificado.Location = New System.Drawing.Point(152, 16)
        Me.ebNumCertificado.MaxLength = 20
        Me.ebNumCertificado.Name = "ebNumCertificado"
        Me.ebNumCertificado.Size = New System.Drawing.Size(128, 20)
        Me.ebNumCertificado.TabIndex = 1
        Me.ebNumCertificado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumCertificado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbNumCertificado
        '
        Me.lbNumCertificado.BackColor = System.Drawing.Color.Transparent
        Me.lbNumCertificado.Location = New System.Drawing.Point(16, 16)
        Me.lbNumCertificado.Name = "lbNumCertificado"
        Me.lbNumCertificado.Size = New System.Drawing.Size(132, 20)
        Me.lbNumCertificado.TabIndex = 0
        Me.lbNumCertificado.Text = "lbNumCertificado"
        Me.lbNumCertificado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbFechaInicial
        '
        Me.cbFechaInicial.CustomFormat = "dd/MM/yyyy"
        '
        '
        '
        Me.cbFechaInicial.DropDownCalendar.FirstMonth = New Date(2006, 7, 1, 0, 0, 0, 0)
        Me.cbFechaInicial.DropDownCalendar.Name = ""
        Me.cbFechaInicial.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFechaInicial.Location = New System.Drawing.Point(152, 48)
        Me.cbFechaInicial.MinDate = New Date(2000, 2, 1, 0, 0, 0, 0)
        Me.cbFechaInicial.Name = "cbFechaInicial"
        Me.cbFechaInicial.Size = New System.Drawing.Size(128, 20)
        Me.cbFechaInicial.TabIndex = 5
        Me.cbFechaInicial.Tag = ""
        Me.cbFechaInicial.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'LbFechaInicial
        '
        Me.LbFechaInicial.Location = New System.Drawing.Point(16, 48)
        Me.LbFechaInicial.Name = "LbFechaInicial"
        Me.LbFechaInicial.Size = New System.Drawing.Size(132, 20)
        Me.LbFechaInicial.TabIndex = 4
        Me.LbFechaInicial.Text = "LbFechaInicial"
        Me.LbFechaInicial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbFechaFinal
        '
        Me.cbFechaFinal.CustomFormat = "dd/MM/yyyy"
        '
        '
        '
        Me.cbFechaFinal.DropDownCalendar.FirstMonth = New Date(2006, 7, 1, 0, 0, 0, 0)
        Me.cbFechaFinal.DropDownCalendar.Name = ""
        Me.cbFechaFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFechaFinal.Location = New System.Drawing.Point(432, 48)
        Me.cbFechaFinal.MinDate = New Date(1000, 2, 1, 0, 0, 0, 0)
        Me.cbFechaFinal.Name = "cbFechaFinal"
        Me.cbFechaFinal.Size = New System.Drawing.Size(128, 20)
        Me.cbFechaFinal.TabIndex = 7
        Me.cbFechaFinal.Tag = ""
        Me.cbFechaFinal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'lbFechaFinal
        '
        Me.lbFechaFinal.Location = New System.Drawing.Point(296, 48)
        Me.lbFechaFinal.Name = "lbFechaFinal"
        Me.lbFechaFinal.Size = New System.Drawing.Size(132, 20)
        Me.lbFechaFinal.TabIndex = 6
        Me.lbFechaFinal.Text = "lbFechaFinal"
        Me.lbFechaFinal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'epErrores
        '
        Me.epErrores.ContainerControl = Me
        '
        'lbConfirmar
        '
        Me.lbConfirmar.BackColor = System.Drawing.Color.Transparent
        Me.lbConfirmar.Location = New System.Drawing.Point(296, 16)
        Me.lbConfirmar.Name = "lbConfirmar"
        Me.lbConfirmar.Size = New System.Drawing.Size(132, 20)
        Me.lbConfirmar.TabIndex = 2
        Me.lbConfirmar.Text = "lbConfirmar"
        Me.lbConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebConfirmar
        '
        Me.ebConfirmar.Enabled = False
        Me.ebConfirmar.Location = New System.Drawing.Point(432, 16)
        Me.ebConfirmar.MaxLength = 20
        Me.ebConfirmar.Name = "ebConfirmar"
        Me.ebConfirmar.Size = New System.Drawing.Size(128, 20)
        Me.ebConfirmar.TabIndex = 3
        Me.ebConfirmar.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebConfirmar.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'MGeneral
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(624, 132)
        Me.Controls.Add(Me.cbFechaFinal)
        Me.Controls.Add(Me.lbFechaFinal)
        Me.Controls.Add(Me.cbFechaInicial)
        Me.Controls.Add(Me.LbFechaInicial)
        Me.Controls.Add(Me.ebConfirmar)
        Me.Controls.Add(Me.ebNumCertificado)
        Me.Controls.Add(Me.lbConfirmar)
        Me.Controls.Add(Me.lbNumCertificado)
        Me.Name = "MGeneral"
        Me.Controls.SetChildIndex(Me.EbClave, 0)
        Me.Controls.SetChildIndex(Me.lbClave, 0)
        Me.Controls.SetChildIndex(Me.BtCancelar, 0)
        Me.Controls.SetChildIndex(Me.BtAceptar, 0)
        Me.Controls.SetChildIndex(Me.lbLinea, 0)
        Me.Controls.SetChildIndex(Me.lbNumCertificado, 0)
        Me.Controls.SetChildIndex(Me.lbConfirmar, 0)
        Me.Controls.SetChildIndex(Me.ebNumCertificado, 0)
        Me.Controls.SetChildIndex(Me.ebConfirmar, 0)
        Me.Controls.SetChildIndex(Me.LbFechaInicial, 0)
        Me.Controls.SetChildIndex(Me.cbFechaInicial, 0)
        Me.Controls.SetChildIndex(Me.lbFechaFinal, 0)
        Me.Controls.SetChildIndex(Me.cbFechaFinal, 0)
        CType(Me.epErrores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Variables "
    Private tModo As eModo
    Private oCertificadoFolio As cCertificadoFolio
    Private oMensaje As New CMensaje
    Private oConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private sComponente As String = "ERMCEFESC"
    Private bHuboCambios As Boolean = False
    Private bCerrar As Boolean = False

    Private htCampos As Hashtable = New Hashtable(20)
    Private htElemInterfaz As Hashtable = New Hashtable(10)

    Private dtFechaFinalInicial As Date
#End Region

#Region " Métodos y Funciones "
    Public Function CREAR(ByRef prCertificadoFolio As cCertificadoFolio) As Boolean
        tModo = eModo.Crear
        oCertificadoFolio = prCertificadoFolio
        Me.Text = oMensaje.RecuperarDescripcion(sComponente & "_" & Me.Name & "C")
        ebConfirmar.Enabled = False
        Return IniciarPantalla()
    End Function

    Public Function MODIFICAR(ByRef prCertificadoFolio As cCertificadoFolio) As Boolean
        tModo = eModo.Modificar
        oCertificadoFolio = prCertificadoFolio
        Me.Text = oMensaje.RecuperarDescripcion(sComponente & "_" & Me.Name & "M")

        Return IniciarPantalla()
    End Function

    Public Function ELIMINAR(ByRef prCertificadoFolio As cCertificadoFolio) As Boolean
        tModo = eModo.Eliminar
        oCertificadoFolio = prCertificadoFolio
        Me.Text = oMensaje.RecuperarDescripcion(sComponente & "_" & Me.Name & "E")

        Return IniciarPantalla()
    End Function

    Public Function LEER(ByRef prCertificadoFolio As cCertificadoFolio) As Boolean
        tModo = eModo.Leer
        oCertificadoFolio = prCertificadoFolio
        Me.Text = oMensaje.RecuperarDescripcion(sComponente & "_" & Me.Name & "L")
        BtAceptar.Visible = False
        BtCancelar.Text = oMensaje.RecuperarDescripcion("BTRegresar")
        BtCancelar.Icon = BtAceptar.Icon
        BtCancelar.ToolTipText = oMensaje.RecuperarDescripcion("BTRegresar")

        Return IniciarPantalla()
    End Function

    Private Function IniciarPantalla() As Boolean
        CrearObjetosCamposLogicos()
        CrearObjetosInterfaz()
        ConfigurarInterfaz()
        lbConfirmar.Text = oMensaje.RecuperarDescripcion("XConfirmar") + " " + lbNumCertificado.Text

        If tModo = eModo.Modificar Then
            dtFechaFinalInicial = oCertificadoFolio.FechaFinal

            'MsgBox(oMensaje.RecuperarDescripcion("I0169", New String() {LbFechaInicial.Text}), MsgBoxStyle.Information, oMensaje.RecuperarDescripcion("XMensajeI"))
            'cbFechaInicial.Enabled = False
        End If

        If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
            oConexion.ConfirmarTran()
            Return True
        Else
            oConexion.DeshacerTran()
            Return False
        End If
    End Function

    Private Sub CrearObjetosCamposLogicos()
        CrearCampoLogico("NumCertificado", CType(Me.lbNumCertificado, System.Windows.Forms.Control), CType(Me.ebNumCertificado, System.Windows.Forms.Control), True, "", True)
        CrearCampoLogico("Confirmar", CType(Me.lbConfirmar, System.Windows.Forms.Control), CType(Me.ebConfirmar, System.Windows.Forms.Control), True, "", True)
        CrearCampoLogico("FechaInicial", CType(Me.LbFechaInicial, System.Windows.Forms.Control), CType(Me.cbFechaInicial, System.Windows.Forms.Control), True)
        CrearCampoLogico("FechaFinal", CType(Me.lbFechaFinal, System.Windows.Forms.Control), CType(Me.cbFechaFinal, System.Windows.Forms.Control), True)
    End Sub

    Private Sub CrearObjetosInterfaz()
        'aqui se agregan los botones, etc
        Dim oEI As ManejoElementoInterfaz
        oEI = New ManejoElementoInterfaz("BTAceptar", CType(Me.BtAceptar, System.Windows.Forms.Control))
        htElemInterfaz.Add(oEI.Nombre, oEI)
        oEI = New ManejoElementoInterfaz("BTCancelar", CType(Me.BtCancelar, System.Windows.Forms.Control))
        htElemInterfaz.Add(oEI.Nombre, oEI)
    End Sub

    Private Function CrearCampoLogico(ByVal pvCampo As String, ByRef prCtrlEtiqueta As System.Windows.Forms.Control, ByRef prCtrlCaptura As System.Windows.Forms.Control, Optional ByVal pvRequerido As Boolean = False, Optional ByVal pvValorReferencia As String = "", Optional ByVal pvLlave As Boolean = False) As ManejoCampoLogico
        Dim oCL As ManejoCampoLogico

        oCL = New ManejoCampoLogico(oCertificadoFolio.Mnemonico, pvCampo, prCtrlEtiqueta, prCtrlCaptura, pvRequerido, pvValorReferencia, pvLlave)
        htCampos.Add(oCL.Campo, oCL)
        oCL.CtrlCaptura.Tag = oCL
        Return oCL
    End Function

    Private Sub LimpiarControles()
        For Each oCL As ManejoCampoLogico In htCampos.Values
            Select Case oCL.CtrlCaptura.GetType.Name
                Case "EditBox"
                    oCL.CtrlCaptura.Text = ""
            End Select
        Next
    End Sub

    Private Sub PonerFoco(ByVal pvNombreCampo As String)
        Try
            Dim oCL As ManejoCampoLogico = htCampos(pvNombreCampo)
            If (Not oCL Is Nothing) Then
                oCL.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ConfigurarInterfaz()
        Dim oCL As ManejoCampoLogico
        Dim oei As ManejoElementoInterfaz
        Dim lTootTip As New System.Windows.Forms.ToolTip

        'Titulos Controles
        For Each oCL In htCampos.Values
            oCL.FijarTexto(oMensaje)
            oCL.FijarTooltip(oMensaje, lTootTip)
            oCL.CargarValorReferencia()
        Next
        cbFechaInicial.TodayButtonText = oMensaje.RecuperarDescripcion("XAhora")
        cbFechaFinal.TodayButtonText = oMensaje.RecuperarDescripcion("XAhora")

        'Titulos Botones
        If tModo <> eModo.Leer Then
            For Each oei In htElemInterfaz.Values
                oei.FijarTexto(oMensaje)
                oei.FijarTooltip(oMensaje, lTootTip)
            Next
        End If

        If tModo = eModo.Crear Then
            LimpiarControles()
        Else
            CargarDatos()
        End If

        If tModo = eModo.Crear Then
            Me.cbFechaInicial.Value = oConexion.ObtenerFecha.Date
            Me.cbFechaFinal.Value = oConexion.ObtenerFecha.Date.AddYears(2)
        ElseIf tModo = eModo.Eliminar Or tModo = eModo.Leer Then
            ebNumCertificado.Enabled = False
            cbFechaInicial.Enabled = False
            cbFechaFinal.Enabled = False
        End If

        Me.ebNumCertificado.Focus()

        bHuboCambios = False
    End Sub

    Private Sub CargarDatos()
        With oCertificadoFolio
            Me.ebNumCertificado.Text = .NumCertificado
            Me.ebConfirmar.Text = .NumCertificado
            Me.cbFechaInicial.Value = .FechaInicial
            Me.cbFechaFinal.Value = .FechaFinal
        End With
        Me.ebNumCertificado.Enabled = False
    End Sub

#End Region

#Region " Eventos "
    Private Sub MGeneral_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not bCerrar And bHuboCambios Then
            Me.DialogResult = Windows.Forms.DialogResult.None

            If MsgBox(oMensaje.RecuperarDescripcion("BP0001"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, oMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.Yes Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Else
                e.Cancel = False
            End If
        End If
    End Sub

    Private Sub ControlesArticulo_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebNumCertificado.Validated, cbFechaInicial.Validated, cbFechaFinal.Validated
        Dim oCL As ManejoCampoLogico
        oCL = CType(sender.tag, ManejoCampoLogico)

        oCertificadoFolio.SetCampo(oCL.Campo, oCL.ObtenValorControl(sender))

        Dim pvCampos() As String = {oCL.Campo}
        Try
            If sender.Name = "ebNumCertificado" And Me.ebNumCertificado.Text = "" Then
                Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(lbNumCertificado.Text)}, "NumCertificado")
            End If

            If sender.Name = "cbFechaFinal" And tModo = eModo.Modificar Then
                If cbFechaFinal.Value < oConexion.ObtenerFecha.Date Then
                    Throw New LbControlError.cError("E0440", , sender.Name)
                End If
            End If
            If sender.Name = "cbFechaInicial" Or sender.Name = "cbFechaFinal" Then
                If Me.cbFechaFinal.Value <= Me.cbFechaInicial.Value Then
                    Throw New LbControlError.cError("E0008", , sender.Name)
                Else
                    epErrores.SetError(cbFechaInicial, "")
                    epErrores.SetError(cbFechaFinal, "")
                End If
            End If

            If sender.Name = "cbFechaFinal" And tModo = eModo.Modificar Then
                Dim ccert As New ERMCEFLOG.cCertificadoFolio
                If cbFechaFinal.Value < dtFechaFinalInicial And ccert.ExisteFosHist(Me.oCertificadoFolio.NumCertificado) > 0 Then
                    If MsgBox(oMensaje.RecuperarDescripcion("P0111"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, oMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.No Then
                        cbFechaFinal.Value = dtFechaFinalInicial 'oCertificadoFolio.FechaFinal
                    End If
                End If
            End If

            oCertificadoFolio.ValidarCampos(pvCampos)
        Catch ex As LbControlError.cError
            epErrores.SetError(sender, ex.Mensaje)
            Exit Sub
        End Try
        epErrores.SetError(sender, "")
    End Sub

    Private Sub ControlesArticulo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebNumCertificado.TextChanged, cbFechaInicial.ValueChanged, cbFechaFinal.ValueChanged, ebConfirmar.TextChanged
        bHuboCambios = True
        If tModo = eModo.Crear And CType(sender, Control).Name = "ebNumCertificado" Then
            ebConfirmar.Enabled = True
        End If

    End Sub

    Private Sub BtAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAceptar.Click
        Me.DialogResult = Windows.Forms.DialogResult.None

        Select Case tModo
            Case eModo.Crear
                Try
                    If Me.ebNumCertificado.Text = "" Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(lbNumCertificado.Text)}, "NumCertificado")
                    End If
                    With oCertificadoFolio
                        .NumCertificado = Me.ebNumCertificado.Text
                        .FechaInicial = Me.cbFechaInicial.Value
                        .FechaFinal = Me.cbFechaFinal.Value
                    End With

                    Dim aCampos() As String = {"NumCertificado", "FechaInicial", "FechaFinal"}
                    oCertificadoFolio.ValidarClase(aCampos)

                    If Me.cbFechaFinal.Value <= Me.cbFechaInicial.Value Then
                        Throw New LbControlError.cError("E0008", , "FechaFinal")
                    End If
                    If (ebNumCertificado.Text <> ebConfirmar.Text) Then
                        Throw New LbControlError.cError("E0701", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(lbNumCertificado.Text)}, "NumCertificado")
                    End If
                    oCertificadoFolio.Insertar()
                    oCertificadoFolio.Grabar()
                Catch ex As LbControlError.cError
                    ex.Mostrar()
                    PonerFoco(ex.Source)
                    oConexion.DeshacerTran()
                    Exit Sub
                End Try
            Case eModo.Modificar
                Try
                    If cbFechaFinal.Value < oConexion.ObtenerFecha.Date Then
                        Throw New LbControlError.cError("E0440", , "FechaFinal")
                    End If

                    If Me.cbFechaFinal.Value <= Me.cbFechaInicial.Value Then
                        Throw New LbControlError.cError("E0008", , "FechaFinal")
                    End If

                    With oCertificadoFolio
                        .NumCertificado = Me.ebNumCertificado.Text
                        .FechaInicial = Me.cbFechaInicial.Value
                        .FechaFinal = Me.cbFechaFinal.Value
                    End With

                    Dim aCampos() As String = {"NumCertificado", "FechaInicial", "FechaFinal"}
                    oCertificadoFolio.ValidarClase(aCampos)

                    oCertificadoFolio.Grabar()
                Catch ex As LbControlError.cError
                    ex.Mostrar()
                    PonerFoco(ex.Source)
                    oConexion.DeshacerTran()
                    Exit Sub
                End Try
            Case eModo.Eliminar
                Try
                    Dim certF As New cCertificadoFolio
                    If (certF.ExisteFosHist(oCertificadoFolio.NumCertificado)) = 0 And (certF.ExisteCentroExp(oCertificadoFolio.NumCertificado)) = 0 Then
                        oCertificadoFolio.Eliminar()
                        oCertificadoFolio.Grabar()
                    Else
                        MsgBox(oMensaje.RecuperarDescripcion("E0641"), MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                Catch ex As LbControlError.cError
                    ex.Mostrar()
                    PonerFoco(ex.Source)
                    oConexion.DeshacerTran()
                    Exit Sub
                End Try
        End Select

        Me.DialogResult = Windows.Forms.DialogResult.OK
        bCerrar = True
        Me.Close()
    End Sub

    Private Sub BtCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancelar.Click
        Me.Close()
    End Sub

#End Region

End Class
