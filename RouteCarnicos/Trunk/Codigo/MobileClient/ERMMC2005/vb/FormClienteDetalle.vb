Imports System.Data.SqlServerCe
Public Class FormClienteDetalle
#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New(ByVal paroStatus As eStatus)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        If g_SO = SO.WindowsCE Then
            Call InTheHand.Windows.Forms.ContextMenuHelper.HookAllControls(Me.Controls)
        End If

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        DetailViewCliente.Text = "DetailViewCliente"
        DetailViewCliente.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)

        DetailViewDomPuntoE.Text = "DetailViewDomicilios"
        DetailViewDomPuntoE.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)

        DetailViewDomFiscal.Text = "DetailViewDomicilios"
        DetailViewDomFiscal.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)

        oStatus = paroStatus
        Me.DialogResult = Windows.Forms.DialogResult.Cancel

    End Sub


#End Region

#Region "VARIABLES Y CONSTANTES"

    Private Const ConstTabPageGenerales = 0
    Private Const ConstTabPageDetalles = 1
    Private Const ConstTabPageConfiguracion = 2
    Private Const ConstTabPageCredito = 3

    Private oStatus As eStatus
    Private bEditando As Boolean = False
    Private bCambioManual As Boolean = False
    Private bHuboCambios As Boolean = False

    Private eVistaAgenda As ServicesCentral.TiposVistasAgendas = ServicesCentral.TiposVistasAgendas.ClientesNoVisitados
    Private refaVista As Vista
    Private bIniciando As Boolean = True
    Private bLlenando As Boolean = True
    Private iSegundos As Integer
    Private dFechaReferencia As DateTime = Now
    Private bLeerCodigoCliente As Boolean = False
    Private bLeerContrasenaCliente As Boolean = False
    Friend bCodigoLeido As Boolean = False
    Dim oDtDom As DataTable
    Private sRFC As String = ""
#End Region


#Region " Eventos y procedimientos del manejo de la Agenda "

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        If bEditando Then
            If MsgBox(refaVista.BuscarMensaje("Mensajes", "BP0001"), MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


#End Region

#Region " Eventos y procedimientos del manejo del Detalle del Cliente "

    Private Sub ConfigurarTabConfiguracion()
        Dim bEnabled As Boolean = False
        If oStatus = eStatus.Existente Then
            Me.LlenarCreditosPendientes()
            bEnabled = Not Me.EsClienteNuevo(oAgenda.ClienteActual.Clave)
        End If
        If (oStatus = eStatus.Existente And bEditando) Or oStatus = eStatus.Nuevo Then
            Me.CheckBoxExclusividad.Enabled = True
            Me.dtVig.Enabled = Me.CheckBoxExclusividad.Checked
        Else
            Me.CheckBoxExclusividad.Enabled = False
            Me.dtVig.Enabled = False
        End If
        Me.btActivos.Enabled = bEnabled
        Me.btCompra.Enabled = bEnabled
        Me.btEnvase.Enabled = bEnabled
        Me.btEsquemas.Enabled = bEnabled
    End Sub

    Private Sub MostrarDetalleCliente()
        LimpiarDetailView(DetailViewCliente)
        refaVista.PoblarDetailView(DetailViewCliente, oDBVen, "DetailViewCliente", "WHERE ClienteClave='" & oAgenda.ClienteActual.ClienteClave & "'")
        refaVista.PoblarDetailView(Me.DetailViewDomPuntoE, oDBVen, "DetailViewDomicilios", "WHERE ClienteClave='" & oAgenda.ClienteActual.ClienteClave & "' AND Tipo=" & TipoDomicilio.PuntoEntrega)
        refaVista.PoblarDetailView(Me.DetailViewDomFiscal, oDBVen, "DetailViewDomicilios", "WHERE ClienteClave='" & oAgenda.ClienteActual.ClienteClave & "' AND Tipo=" & TipoDomicilio.Fiscal)

        CType(DetailViewCliente.Items("DesgloseImpuesto"), Resco.Controls.DetailView.ItemCheckBox).Checked = oAgenda.ClienteActual.DesgloseImpuesto
        Me.CheckBoxExclusividad.Checked = oAgenda.ClienteActual.Exclusividad
        Me.CheckBoxPrestamoEnvases.Checked = oAgenda.ClienteActual.Prestamo

        Me.dtVig.Value = IIf(IsDBNull(oAgenda.ClienteActual.VigExclusividad) OrElse oAgenda.ClienteActual.VigExclusividad < DateSerial(1900, 1, 1), DateSerial(1900, 1, 1), oAgenda.ClienteActual.VigExclusividad)
        Me.TabControlDetalles.SelectedIndex = ConstTabPageGenerales
    End Sub
    Dim iDomicilioActual As String

    'Private Sub ComboBoxTipoDomicilio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If bCambioManual Then Exit Sub
    '    If iDomicilioActual = Nothing Then Exit Sub
    '    If iDomicilioActual = Me.ComboBoxTipoDomicilio.SelectedValue Then Exit Sub
    '    If Not bIniciando Then
    '        'If bEditando Then
    '        'If Not (txtCalle.Text = "" And txtNumero.Text = "" And txtColonia.Text = "" And txtCodigoPostal.Text = "" And txtPoblacion.Text = "" And txtEntidad.Text = "" And txtPais.Text = "" And txtInterior.Text = "") Then
    '        If Not MostrarDomicilio(Me.ComboBoxTipoDomicilio.SelectedValue) Then
    '            Me.ComboBoxTipoDomicilio.SelectedValue = iDomicilioActual
    '        End If
    '        'End If
    '        'Else
    '        'MostrarDomicilio(Me.ComboBoxTipoDomicilio.SelectedValue)
    '        'End If

    '    End If
    '    'If bEditando Then

    '    '    If ComboBoxTipoDomicilio.SelectedIndex = 0 Then
    '    '        txtCalle.Enabled = False
    '    '        txtNumero.Enabled = False
    '    '        txtColonia.Enabled = False
    '    '        txtCodigoPostal.Enabled = False
    '    '        txtPoblacion.Enabled = False
    '    '        txtEntidad.Enabled = False
    '    '        txtPais.Enabled = False
    '    '    Else
    '    '        txtCalle.Enabled = True
    '    '        txtNumero.Enabled = True
    '    '        txtColonia.Enabled = True
    '    '        txtCodigoPostal.Enabled = True
    '    '        txtPoblacion.Enabled = True
    '    '        txtEntidad.Enabled = True
    '    '        txtPais.Enabled = True
    '    '    End If
    '    'End If
    'End Sub

    'Private Function MostrarDomicilio(ByVal parsTipoDomicilio As String) As Boolean
    '    Try
    '        If bEditando Then
    '            Dim iTipoDom As Integer
    '            If ComboBoxTipoDomicilio.SelectedValue = 1 Then
    '                iTipoDom = 2
    '            Else
    '                iTipoDom = 1
    '            End If
    '            bCambioManual = True
    '            'iDomicilioActual = iTipoDom
    '            If ValidaCampos(1) Then


    '                If oDtDom.Select(" tipo=" & iTipoDom).Length > 0 Then
    '                    If oDtDom.Rows(0)("Tipo") = iTipoDom Then
    '                        oDtDom.Rows(0)("Calle") = txtCallePE.Text
    '                        oDtDom.Rows(0)("Numero") = txtNumeroPE.Text
    '                        oDtDom.Rows(0)("Colonia") = txtColoniaPE.Text
    '                        oDtDom.Rows(0)("CodigoPostal") = txtCodigoPostalPE.Text
    '                        oDtDom.Rows(0)("Poblacion") = txtPoblacionPE.Text
    '                        oDtDom.Rows(0)("Entidad") = txtEntidadPE.Text
    '                        oDtDom.Rows(0)("Pais") = txtPaisPE.Text
    '                        oDtDom.Rows(0)("NumInt") = txtInteriorPE.Text
    '                        oDtDom.Rows(0)("referenciaDom") = txtReferenciaPE.Text
    '                    Else
    '                        oDtDom.Rows(1)("Calle") = txtCallePE.Text
    '                        oDtDom.Rows(1)("Numero") = txtNumeroPE.Text
    '                        oDtDom.Rows(1)("Colonia") = txtColoniaPE.Text
    '                        oDtDom.Rows(1)("CodigoPostal") = txtCodigoPostalPE.Text
    '                        oDtDom.Rows(1)("Poblacion") = txtPoblacionPE.Text
    '                        oDtDom.Rows(1)("Entidad") = txtEntidadPE.Text
    '                        oDtDom.Rows(1)("Pais") = txtPaisPE.Text
    '                        oDtDom.Rows(1)("NumInt") = txtInteriorPE.Text
    '                        oDtDom.Rows(1)("referenciaDom") = txtReferenciaPE.Text
    '                    End If
    '                Else
    '                    oDtDom.Rows.Add(New Object() {ComboBoxTipoDomicilio.SelectedValue, txtCalle.Text, txtNumero.Text, txtColonia.Text, txtCodigoPostal.Text, txtPoblacion.Text, txtEntidad.Text, txtPais.Text, txtInterior.Text, txtReferencia.Text})

    '                    'Me.txtNumero.Text = IIf(IsDBNull(oDr("Numero")), Nothing, oDr("Numero"))
    '                    'Me.txtColonia.Text = IIf(IsDBNull(oDr("Colonia")), Nothing, oDr("Colonia"))
    '                    'Me.txtCodigoPostal.Text = IIf(IsDBNull(oDr("CodigoPostal")), Nothing, oDr("CodigoPostal"))
    '                    'Me.txtPoblacion.Text = IIf(IsDBNull(oDr("Poblacion")), Nothing, oDr("Poblacion"))
    '                    'Me.txtEntidad.Text = oDr("Entidad")
    '                    'Me.txtPais.Text = oDr("Pais")
    '                    'Me.txtInterior.Text = IIf(IsDBNull(oDr("NumInt")), Nothing, oDr("NumInt"))
    '                    'Me.txtReferencia.Text = IIf(IsDBNull(oDr("ReferenciaDom")), Nothing, oDr("ReferenciaDom"))
    '                End If

    '                If ComboBoxTipoDomicilio.SelectedValue = 1 Then
    '                    iTipoDom = 2
    '                Else
    '                    iTipoDom = 1
    '                End If
    '                Me.LlenarCampos(1)
    '                iDomicilioActual = ComboBoxTipoDomicilio.SelectedValue
    '                bCambioManual = False
    '                Return True
    '            Else
    '                bCambioManual = False
    '                Return False
    '            End If
    '            bCambioManual = False
    '        Else
    '            Me.DetailViewDomPuntoE.ClearContents()
    '            iDomicilioActual = ComboBoxTipoDomicilio.SelectedValue
    '            refaVista.PoblarDetailView(Me.DetailViewDomPuntoE, oDBVen, "DetailViewDomicilios", "WHERE ClienteClave='" & oAgenda.ClienteActual.ClienteClave & "' AND Tipo=" & parsTipoDomicilio)
    '            bCambioManual = False
    '            Return True
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "MostrarDomicilio")
    '    End Try
    '    Return False
    'End Function

    Private Sub TabControlDetalles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControlDetalles.SelectedIndexChanged

        If Me.TabControlDetalles.SelectedIndex = ConstTabPageDetalles Then

            If bEditando Then
                If Not Me.ValidaCampos(ConstTabPageGenerales) Then
                    Me.TabControlDetalles.SelectedIndex = ConstTabPageGenerales
                Else
                    'DetailViewDomicilios.Items(1).Text = "12"
                    Me.txtCallePE.Focus()
                    'DetailViewDomicilios.Focus()
                End If
            End If
        ElseIf Me.TabControlDetalles.SelectedIndex = ConstTabPageConfiguracion Then
            Me.ConfigurarTabConfiguracion()
        ElseIf Me.TabControlDetalles.SelectedIndex = 0 Then

            txtRazonSocial.Focus()

        End If

    End Sub

    'Private Sub CrearClienteTemporal()
    '    If oDtDom.Select(" tipo=" & ComboBoxTipoDomicilio.SelectedValue).Length > 0 Then
    '        If oDtDom.Rows(0)("Tipo") = ComboBoxTipoDomicilio.SelectedValue Then
    '            oDtDom.Rows(0)("Calle") = txtCallePE.Text
    '            oDtDom.Rows(0)("Numero") = txtNumeroPE.Text
    '            oDtDom.Rows(0)("Colonia") = txtColoniaPE.Text
    '            oDtDom.Rows(0)("CodigoPostal") = txtCodigoPostalPE.Text
    '            oDtDom.Rows(0)("Poblacion") = txtPoblacionPE.Text
    '            oDtDom.Rows(0)("Entidad") = txtEntidadPE.Text
    '            oDtDom.Rows(0)("Pais") = txtPaisPE.Text
    '            oDtDom.Rows(0)("NumInt") = txtInteriorPE.Text
    '            oDtDom.Rows(0)("referenciaDom") = txtReferenciaPE.Text
    '        Else
    '            oDtDom.Rows(1)("Calle") = txtCallePE.Text
    '            oDtDom.Rows(1)("Numero") = txtNumeroPE.Text
    '            oDtDom.Rows(1)("Colonia") = txtColoniaPE.Text
    '            oDtDom.Rows(1)("CodigoPostal") = txtCodigoPostalPE.Text
    '            oDtDom.Rows(1)("Poblacion") = txtPoblacionPE.Text
    '            oDtDom.Rows(1)("Entidad") = txtEntidadPE.Text
    '            oDtDom.Rows(1)("Pais") = txtPaisPE.Text
    '            oDtDom.Rows(1)("NumInt") = txtInteriorPE.Text
    '            oDtDom.Rows(1)("referenciaDom") = txtReferenciaPE.Text
    '        End If
    '    Else
    '        oDtDom.Rows.Add(New Object() {ComboBoxTipoDomicilio.SelectedValue, txtCalle.Text, txtNumero.Text, txtColonia.Text, txtCodigoPostal.Text, txtPoblacion.Text, txtEntidad.Text, txtPais.Text, txtInterior.Text, txtReferencia.Text})
    '    End If
    '    If oDtDom.Select(" tipo=1").Length = 0 And CheckBoxDesglose.Checked Then
    '        MsgBox(SustituyeCampo(refaVista.BuscarMensaje("Mensajes", "E0018"), DirectCast(ComboBoxTipoDomicilio.Items(0), ComboGeneral).Concepto), MsgBoxStyle.Information)
    '        Exit Sub
    '    End If
    'End Sub

    Private Sub ButtonClienteContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClienteContinuar.Click
        ' Recuperar el modulo
        If bEditando Then
            If Me.TabControlDetalles.SelectedIndex = ConstTabPageGenerales Then
                If Me.ValidaCampos(ConstTabPageGenerales) Then
                    Me.TabControlDetalles.SelectedIndex = ConstTabPageDetalles
                    Me.txtCallePE.Focus()
                Else
                    Exit Sub
                End If
            ElseIf Me.TabControlDetalles.SelectedIndex = ConstTabPageDetalles Then
                If Me.ValidaCampos(ConstTabPageDetalles) Then

                    Me.TabControlDetalles.SelectedIndex = ConstTabPageConfiguracion
                    Me.CheckBoxExclusividad.Focus()
                Else
                    Exit Sub
                End If
            ElseIf Me.TabControlDetalles.SelectedIndex = ConstTabPageConfiguracion Then
                If oStatus = eStatus.Existente Then
                    If Me.ValidaCampos(ConstTabPageDetalles) Then
                        Me.TabControlDetalles.SelectedIndex = ConstTabPageCredito
                        Me.txtCantidad.Focus()
                    Else
                        'Me.TabControlDetalles.SelectedIndex = ConstTabPageDetalles
                        Exit Sub
                    End If
                Else

                    If CheckBoxDesglose.Checked AndAlso (DatosCapturadosDomFiscal() = False) Then
                        MsgBox(SustituyeCampo(refaVista.BuscarMensaje("Mensajes", "E0018"), ValorReferencia.BuscarEquivalente("DOMTIPO", TipoDomicilio.Fiscal)), MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    If Me.ValidaCampos(ConstTabPageGenerales) Then
                        If Me.ValidaCampos(ConstTabPageDetalles) Then
                            Me.GuardarCliente()
                            Me.DialogResult = Windows.Forms.DialogResult.OK
                            Me.Close()
                            Exit Sub
                        Else
                            'Me.TabControlDetalles.SelectedIndex = ConstTabPageDetalles
                            Exit Sub
                        End If
                    Else
                        Me.TabControlDetalles.SelectedIndex = ConstTabPageGenerales
                        Exit Sub
                    End If
                End If

            ElseIf Me.TabControlDetalles.SelectedIndex = ConstTabPageCredito Then
                If Me.ValidaCampos(ConstTabPageGenerales) Then
                    If Me.ValidaCampos(ConstTabPageDetalles) Then
                        Me.GuardarCliente()
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                        Exit Sub
                    Else
                        'Me.TabControlDetalles.SelectedIndex = ConstTabPageDetalles
                        Exit Sub
                    End If
                Else
                    Me.TabControlDetalles.SelectedIndex = ConstTabPageGenerales
                    Exit Sub
                End If
            End If
            If oConHist.Campos("DatosCteNuevo") = False Then
                Me.GuardarCliente()
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Else
            Me.DialogResult = Windows.Forms.DialogResult.OK
            'If Not IsNothing(oDtDomicilios) Then oDtDomicilios.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub ButtonClienteRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClienteRegresar.Click
        'If Me.TabControlDetalles.SelectedIndex = Me.ConstTabPageGenerales Then
        If bHuboCambios Then
            If MsgBox(refaVista.BuscarMensaje("Mensajes", "BP0002"), MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        'End If
        If Not IsNothing(oDtDom) Then oDtDom.Dispose()
        Me.Close()
    End Sub

    Private Sub ButtonClienteEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClienteEditar.Click
        If oConHist.Campos("DatosCteNuevo") = False Then
            Me.ButtonClienteContinuar.Text = refaVista.BuscarMensaje("Mensajes", "BTGuardar")
        End If

        If oStatus = eStatus.Existente AndAlso Not bEditando Then
            'Me.ComboBoxTipoDomicilio.SelectedIndex = 1
            If oDtDom.Select("Tipo=1").Length > 0 Then
                Me.txtRazonSocial.Enabled = False
                Me.txtNombreCorto.Enabled = False
            Else
                Me.txtRazonSocial.Enabled = True
                Me.txtNombreCorto.Enabled = True
            End If
            Me.txtRFC.Enabled = oVendedor.EditarDatosFiscal
            CheckBoxDesglose.Enabled = oVendedor.EditarDatosFiscal
            Panel2.Visible = True
            PanelDomPuntoE.Visible = True

            Me.ButtonClienteEditar.Visible = False
            Me.ButtonClienteRegresar.Visible = True
            bIniciando = True
            Me.LlenarCampos(0)
            Me.PanelDomFiscal.Enabled = oVendedor.EditarDatosFiscal
            Me.LlenarCampos(1)
            Me.LlenarCampos(2)
            bEditando = True
            bIniciando = False
            Me.MostrarCamposNuevo(True)
            Me.TabPageConfiguracion.Text = refaVista.BuscarMensaje("Mensajes", "XConsultar")
            Me.CheckBoxPrestamoEnvases.Enabled = oAgenda.ClienteActual.Clave.StartsWith("NUEVO")
        End If
    End Sub

#End Region

#Region " Funciones privadas de la forma "

    Private Sub DesmarcarTodosMenus(ByVal refparMenuItem As MenuItem)
        Dim refMenuItem As MenuItem
        For Each refMenuItem In refparMenuItem.MenuItems
            refMenuItem.Checked = False
        Next
    End Sub


    Private Function PoblarMenuAgendas(ByRef refparMenuItem As MenuItem, ByRef refparaVista As Vista, ByVal parsClaveElemento As String) As Boolean
        Try
            Dim DataTableModulos As DataTable
            DataTableModulos = oDBVen.RealizarConsultaSQL("SELECT ModuloClave FROM ModuloTerm WHERE Tipo=" & ServicesCentral.TiposAmbitosModulos.Visitas, "Agenda")
            If DataTableModulos.Rows.Count = 0 Then
                Exit Try
            End If
            Dim refDataRow As DataRow
            Dim aModulos As New ArrayList
            For Each refDataRow In DataTableModulos.Rows
                aModulos.Add(refDataRow("ModuloClave"))
            Next
            DataTableModulos.Dispose()
            Return refparaVista.CrearMenuFiltro(refparMenuItem, oDBVen, parsClaveElemento, aModulos, "ModuloClave", "Nombre")
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "PoblarMenuAgendas")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "PoblarMenuAgendas")
        End Try
        Return False
    End Function

#End Region

#Region "Funciones LGutierrez Jul/06"

#Region "FUNCIONES"
    Private Function ObtenerConsecutivoNuevo() As String
        Dim sQuery As String = "select max(clave) from cliente where clave like 'NUEVO%'"
        Dim oDt As DataTable = oDBVen.RealizarConsultaSQL(sQuery, "Nuevo")
        If IsDBNull(oDt.Rows(0)(0)) Then
            oDt.Dispose()
            Return "001"
        Else
            Dim sNuevo As String = oDt.Rows(0)(0)
            sNuevo = sNuevo.Replace("NUEVO", "")
            Dim iLong As Integer = sNuevo.Length
            sNuevo = CInt(sNuevo) + 1
            sNuevo = sNuevo.PadLeft(iLong, "0")
            oDt.Dispose()
            Return sNuevo
        End If
    End Function

    Private Function ExisteCliente(ByVal pvClienteClave As String) As Boolean
        Return oDBVen.RealizarConsultaSQL("SELECT ClienteClave FROM Cliente WHERE ClienteClave='" & pvClienteClave & "'", "ExisteCliente").Rows.Count > 0
    End Function

    Private Function ExisteDomicilio(ByVal pvClienteClave As String, ByVal pvTipo As Integer) As Boolean
        Return oDBVen.RealizarConsultaSQL("SELECT ClienteClave FROM ClienteDomicilio WHERE ClienteClave='" & pvClienteClave & "' AND Tipo=" & pvTipo, "ExisteDomicilio").Rows.Count > 0
    End Function

    Private Function ValidaCampos(ByVal pvIndice As Integer) As Boolean
        If pvIndice = ConstTabPageGenerales Then 'General
            If Me.txtRazonSocial.Text = String.Empty Then
                MsgBox(SustituyeCampo(refaVista.BuscarMensaje("Mensajes", "BE0001"), Me.lbRazonSocial.Text), MsgBoxStyle.Information)
                Me.txtRazonSocial.Focus()
                Return False
            End If
            If txtRFC.Text = "" Then
                MsgBox(SustituyeCampo(refaVista.BuscarMensaje("Mensajes", "BE0001"), Me.lbRFC.Text), MsgBoxStyle.Information)
                Me.txtRFC.Focus()
                Return False
            End If
            Return True
        ElseIf pvIndice = ConstTabPageDetalles Then 'Domicilio
            If Me.txtCallePE.Text = String.Empty Then
                MsgBox(SustituyeCampo(refaVista.BuscarMensaje("Mensajes", "BE0001"), Me.lbCalle.Text), MsgBoxStyle.Information)
                Me.TabControlDetalles.SelectedIndex = ConstTabPageDetalles
                Me.TabControlDomicilios.SelectedIndex = 0
                Me.txtCallePE.Focus()
                Return False
            ElseIf Me.txtPoblacionPE.Text = String.Empty Then
                MsgBox(SustituyeCampo(refaVista.BuscarMensaje("Mensajes", "BE0001"), Me.lbPoblacion.Text), MsgBoxStyle.Information)
                Me.TabControlDetalles.SelectedIndex = ConstTabPageDetalles
                Me.TabControlDomicilios.SelectedIndex = 0
                Me.txtPoblacionPE.Focus()
                Return False
            ElseIf Me.txtPaisPE.Text = String.Empty Then
                MsgBox(SustituyeCampo(refaVista.BuscarMensaje("Mensajes", "BE0001"), Me.lbPais.Text), MsgBoxStyle.Information)
                Me.TabControlDetalles.SelectedIndex = ConstTabPageDetalles
                Me.TabControlDomicilios.SelectedIndex = 0
                Me.txtPaisPE.Focus()
                Return False
            End If

            If (Me.CheckBoxDesglose.Checked) OrElse (Not IsNothing(oDtDom) AndAlso oDtDom.Select("Tipo = 1").Length) OrElse (DatosCapturadosDomFiscal()) Then
                If Me.txtCalleFiscal.Text = String.Empty Then
                    MsgBox(SustituyeCampo(refaVista.BuscarMensaje("Mensajes", "BE0001"), Me.LbCalle2.Text), MsgBoxStyle.Information)
                    Me.TabControlDetalles.SelectedIndex = ConstTabPageDetalles
                    Me.TabControlDomicilios.SelectedIndex = 1
                    Me.txtCalleFiscal.Focus()
                    Return False
                ElseIf Me.txtCodigoPostalFiscal.Text = String.Empty Then
                    MsgBox(SustituyeCampo(refaVista.BuscarMensaje("Mensajes", "BE0001"), Me.lbCodigoPostal2.Text), MsgBoxStyle.Information)
                    Me.TabControlDetalles.SelectedIndex = ConstTabPageDetalles
                    Me.TabControlDomicilios.SelectedIndex = 1
                    Me.txtCodigoPostalFiscal.Focus()
                    Return False
                ElseIf Me.txtPoblacionFiscal.Text = String.Empty Then
                    MsgBox(SustituyeCampo(refaVista.BuscarMensaje("Mensajes", "BE0001"), Me.lbPoblacion2.Text), MsgBoxStyle.Information)
                    Me.TabControlDetalles.SelectedIndex = ConstTabPageDetalles
                    Me.TabControlDomicilios.SelectedIndex = 1
                    Me.txtPoblacionFiscal.Focus()
                    Return False
                ElseIf Me.txtEntidadFiscal.Text = String.Empty Then
                    MsgBox(SustituyeCampo(refaVista.BuscarMensaje("Mensajes", "BE0001"), Me.lbEntidad2.Text), MsgBoxStyle.Information)
                    Me.TabControlDetalles.SelectedIndex = ConstTabPageDetalles
                    Me.TabControlDomicilios.SelectedIndex = 1
                    Me.txtEntidadFiscal.Focus()
                    Return False
                ElseIf Me.txtPaisFiscal.Text = String.Empty Then
                    MsgBox(SustituyeCampo(refaVista.BuscarMensaje("Mensajes", "BE0001"), Me.lbPais2.Text), MsgBoxStyle.Information)
                    Me.TabControlDetalles.SelectedIndex = ConstTabPageDetalles
                    Me.TabControlDomicilios.SelectedIndex = 1
                    Me.txtPaisFiscal.Focus()
                    Return False
                End If
            End If

            Return True
        End If
    End Function

    Private Function DatosCapturadosDomFiscal() As Boolean
        If Not (txtCalleFiscal.Text = "" And txtNumeroFiscal.Text = "" And txtColoniaFiscal.Text = "" And txtCodigoPostalFiscal.Text = "" And txtPoblacionFiscal.Text = "" And txtEntidadFiscal.Text = "" And txtPaisFiscal.Text = "" And txtInteriorFiscal.Text = "" And txtReferenciaFiscal.Text = "") Then
            Return True
        End If
        Return False
    End Function
#End Region

#Region "METODOS"

    Private Sub CargarAgenda()
        If Not Vista.Buscar("FormClientes", refaVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If

        'refaVista.CrearListView(ListViewAgenda, "ListViewAgenda")
        refaVista.CrearDetailView(DetailViewCliente, "DetailViewCliente")
        refaVista.CrearDetailView(DetailViewDomPuntoE, "DetailViewDomicilios")
        refaVista.CrearDetailView(DetailViewDomFiscal, "DetailViewDomicilios")

        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)


        Dim arrTpoDom As New ArrayList
        Dim aValores As ArrayList = ValorReferencia.RecuperarLista("DOMTIPO")
        If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
            For Each refDesc As ValorReferencia.Descripcion In aValores
                arrTpoDom.Add(New ComboGeneral(refDesc.Id, refDesc.Cadena))
            Next
        End If
        aValores = Nothing
        'ComboBoxTipoDomicilio.DataSource = arrTpoDom
        'ComboBoxTipoDomicilio.DisplayMember = "Concepto"
        'ComboBoxTipoDomicilio.ValueMember = "Valor"


    End Sub

    Private Sub GuardarCliente()
        'CrearClienteTemporal()
        Dim sQuery As String = String.Empty
        If oStatus = eStatus.Existente Then
            sQuery = "UPDATE Cliente SET IdElectronico=" & IIf(Me.txtCodigoBarras.Text = "", "null", "'" & Me.txtCodigoBarras.Text & "'") & ", IdFiscal='" & Me.txtRFC.Text.Replace("-", "") & "', RazonSocial='" & Me.txtRazonSocial.Text & "', NombreContacto='" & Me.txtContacto.Text & "', TelefonoContacto='" & Me.txtTelefono.Text & "', DesgloseImpuesto=" & IIf(Me.CheckBoxDesglose.Checked, "1", "0") & ", FechaRegistroSistema=" & UniFechaSQL(dtpFechaRegistro.Value) & ", FechaNacimiento=" & IIf(dtpFechaNac.Value <= DateSerial(1900, 1, 1), "null", UniFechaSQL(dtpFechaNac.Value)) & ", NombreCorto='" & Me.txtNombreCorto.Text & "',Prestamo=" & IIf(Me.CheckBoxPrestamoEnvases.Checked, "1", "0") & ",Exclusividad =" & IIf(Me.CheckBoxExclusividad.Checked, "1", "0") & ",VigExclusividad=" & IIf(Not Me.CheckBoxExclusividad.Checked, "null", UniFechaSQL(Me.dtVig.Value)) & " ,Enviado=0,MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' WHERE ClienteClave='" & oAgenda.ClienteActual.ClienteClave & "'"
            oDBVen.EjecutarComandoSQL(sQuery)

            'Domicilio PuntoEntrega
            If Me.ExisteDomicilio(oAgenda.ClienteActual.ClienteClave, TipoDomicilio.PuntoEntrega) Then
                sQuery = "UPDATE ClienteDomicilio SET Calle='" & Me.txtCallePE.Text & "', Numero='" & txtNumeroPE.Text & "', Colonia='" & Me.txtColoniaPE.Text & "', CodigoPostal='" & Me.txtCodigoPostalPE.Text & "', Poblacion='" & Me.txtPoblacionPE.Text & "', Entidad='" & Me.txtEntidadPE.Text & "', Pais='" & Me.txtPaisPE.Text & "', numint='" & Me.txtInteriorPE.Text & "', ReferenciaDom='" & Me.txtReferenciaPE.Text & "', MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioId='" & oVendedor.UsuarioId & "', Enviado=0 WHERE ClienteClave='" & oAgenda.ClienteActual.ClienteClave & "' AND Tipo=" & TipoDomicilio.PuntoEntrega
            Else
                sQuery = "INSERT INTO ClienteDomicilio VALUES('" & oAgenda.ClienteActual.ClienteClave & "','" & oApp.KEYGEN(0) & "'," & TipoDomicilio.PuntoEntrega & ",'" & Me.txtCallePE.Text & "','" & Me.txtNumeroPE.Text & "','" & Me.txtInteriorPE.Text & "','" & Me.txtCodigoPostalPE.Text & "','" & Me.txtReferenciaPE.Text & "','" & Me.txtColoniaPE.Text & "',null,'" & Me.txtPoblacionPE.Text & "','" & Me.txtEntidadPE.Text & "','" & Me.txtPaisPE.Text & "',null,null, " & UniFechaSQL(Now) & ", '" & oVendedor.UsuarioId & "',0)"
            End If
            oDBVen.EjecutarComandoSQL(sQuery)

            'Domicilio Fiscal
            If DatosCapturadosDomFiscal() Then
                If Me.ExisteDomicilio(oAgenda.ClienteActual.ClienteClave, TipoDomicilio.Fiscal) Then
                    sQuery = "UPDATE ClienteDomicilio SET Calle='" & Me.txtCalleFiscal.Text & "', Numero='" & txtNumeroFiscal.Text & "', Colonia='" & Me.txtColoniaFiscal.Text & "', CodigoPostal='" & Me.txtCodigoPostalFiscal.Text & "', Poblacion='" & Me.txtPoblacionFiscal.Text & "', Entidad='" & Me.txtEntidadFiscal.Text & "', Pais='" & Me.txtPaisFiscal.Text & "', numint='" & Me.txtInteriorFiscal.Text & "', ReferenciaDom='" & Me.txtReferenciaFiscal.Text & "', MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioId='" & oVendedor.UsuarioId & "', Enviado=0 WHERE ClienteClave='" & oAgenda.ClienteActual.ClienteClave & "' AND Tipo=" & TipoDomicilio.Fiscal
                Else
                    sQuery = "INSERT INTO ClienteDomicilio VALUES('" & oAgenda.ClienteActual.ClienteClave & "','" & oApp.KEYGEN(0) & "'," & TipoDomicilio.Fiscal & ",'" & Me.txtCalleFiscal.Text & "','" & Me.txtNumeroFiscal.Text & "','" & Me.txtInteriorFiscal.Text & "','" & Me.txtCodigoPostalFiscal.Text & "','" & Me.txtReferenciaFiscal.Text & "','" & Me.txtColoniaFiscal.Text & "',null,'" & Me.txtPoblacionFiscal.Text & "','" & Me.txtEntidadFiscal.Text & "','" & Me.txtPaisFiscal.Text & "',null,null, " & UniFechaSQL(Now) & ", '" & oVendedor.UsuarioId & "',0)"
                End If
                oDBVen.EjecutarComandoSQL(sQuery)
            End If
        Else
            Dim sClienteClave As String = oApp.KEYGEN(1)
            sQuery = "INSERT INTO Cliente VALUES('" & sClienteClave & "',NULL,'" & Me.txtClave.Text & "','" & Me.txtCodigoBarras.Text & "','" & Me.txtRFC.Text.Replace("-", "") & "','" & Me.txtRazonSocial.Text & "',1,1,'" & Me.txtContacto.Text & "','" & Me.txtTelefono.Text & "'," & UniFechaSQL(dtpFechaRegistro.Value) & "," & IIf(Me.dtpFechaNac.Value <= DateSerial(1900, 1, 1), "null", UniFechaSQL(dtpFechaNac.Value)) & ",0,'" & Me.txtNombreCorto.Text & "',1,0,0," & IIf(Me.CheckBoxPrestamoEnvases.Checked, "1", "0") & ", " & IIf(Me.CheckBoxExclusividad.Checked, "1", "0") & "," & IIf(Not CheckBoxExclusividad.Checked, "null", UniFechaSQL(Me.dtVig.Value)) & ",0,0,1,0,0," & UniFechaSQL(New Date(9999, 12, 31)) & ",0,0,1," & UniFechaSQL(Now) & ", '" & oVendedor.UsuarioId & "',0,0," & IIf(Me.CheckBoxDesglose.Checked, "1", "0") & ",0)"
            oDBVen.EjecutarComandoSQL(sQuery)
            'Guardar Domicilio PuntoEntrega
            sQuery = "INSERT INTO ClienteDomicilio VALUES('" & sClienteClave & "','" & oApp.KEYGEN(0) & "'," & TipoDomicilio.PuntoEntrega & ",'" & txtCallePE.Text & "','" & txtNumeroPE.Text & "','" & txtInteriorPE.Text & "','" & txtCodigoPostalPE.Text & "','" & txtReferenciaPE.Text & "','" & txtColoniaPE.Text & "',null,'" & txtPoblacionPE.Text & "','" & txtEntidadPE.Text & "','" & txtPaisPE.Text & "',null,null, " & UniFechaSQL(Now) & ", '" & oVendedor.UsuarioId & "',0)"
            oDBVen.EjecutarComandoSQL(sQuery)
            'Guardar Domicilio Fiscal
            If DatosCapturadosDomFiscal() Then
                sQuery = "INSERT INTO ClienteDomicilio VALUES('" & sClienteClave & "','" & oApp.KEYGEN(0) & "'," & TipoDomicilio.Fiscal & ",'" & txtCalleFiscal.Text & "','" & txtNumeroFiscal.Text & "','" & txtInteriorFiscal.Text & "','" & txtCodigoPostalFiscal.Text & "','" & txtReferenciaFiscal.Text & "','" & txtColoniaFiscal.Text & "',null,'" & txtPoblacionFiscal.Text & "','" & txtEntidadFiscal.Text & "','" & txtPaisFiscal.Text & "',null,null, " & UniFechaSQL(Now) & ", '" & oVendedor.UsuarioId & "',0)"
                oDBVen.EjecutarComandoSQL(sQuery)
            End If

            sQuery = "INSERT INTO ClienteEsquema VALUES('" & sClienteClave & "','" & Me.ObtenerEsquemaNuevo & "'," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "',0,0)"
            oDBVen.EjecutarComandoSQL(sQuery)
            sQuery = "INSERT INTO CLIFormaVenta VALUES('" & sClienteClave & "',1,0,0,0,0,0,1,1," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "',0)"
            oDBVen.EjecutarComandoSQL(sQuery)
            sQuery = "INSERT INTO CFVHist VALUES('" & sClienteClave & "',1," & UniFechaSQL(Now) & ",0,0,0,0,1," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "',0)"
            oDBVen.EjecutarComandoSQL(sQuery)
            sQuery = "INSERT INTO CenCli Select CENClave,'" & sClienteClave & "',Puntos,IniAplicacion, FinAplicacion, getdate(),'" & oVendedor.UsuarioId & "',0 from CENClienteNuevo "
            oDBVen.EjecutarComandoSQL(sQuery)
            Dim sFrecuenciaClave As String = oDBVen.EjecutarCmdScalarStrSQL("Select FrecuenciaClave from Agenda where RUTClave='" & oAgenda.RutaActual.RUTClave & "'")
            sQuery = "INSERT INTO Agenda Values('" & oDia.DiaActual & "','" & oVendedor.VendedorId & "','" & sFrecuenciaClave & "','" & oAgenda.RutaActual.RUTClave & "',0,'" & sClienteClave & "',0," & ServicesCentral.TiposVistasAgendas.ClientesNoVisitados & ")"
            oDBVen.EjecutarComandoSQL(sQuery)
        End If
    End Sub

    Private Sub MostrarCamposNuevo(ByVal pvValor As Boolean)
        Me.DetailViewCliente.Visible = Not pvValor
        Me.DetailViewDomPuntoE.Visible = Not pvValor
        Me.DetailViewDomFiscal.Visible = Not pvValor
        For Each oControl As Control In Me.TabPageGeneral.Controls
            If TypeOf oControl Is TextBox OrElse TypeOf oControl Is Label Then
                oControl.Visible = pvValor
            End If
        Next
        dtpFechaNac.Visible = pvValor
        dtpFechaRegistro.Visible = pvValor
        PanelDomPuntoE.Visible = pvValor
        PanelDomFiscal.Visible = pvValor

        Me.LabelCliente.Visible = True
        Me.TabControlDetalles.SelectedIndex = ConstTabPageGenerales
    End Sub

    Private Sub LlenarCampos(ByVal pvIndice As Integer)
        If pvIndice = 0 Then
            Dim sQuery As String = "SELECT * FROM Cliente WHERE ClienteClave='" & oAgenda.ClienteActual.ClienteClave & "'"
            Dim oDr As DataRow = oDBVen.RealizarConsultaSQL(sQuery, "LlenarCampos0").Rows(0)
            Me.txtClave.Text = oDr("Clave")
            Me.txtCodigoBarras.Text = IIf(IsDBNull(oDr("IdElectronico")), Nothing, oDr("IdElectronico"))
            Me.txtNombreCorto.Text = IIf(IsDBNull(oDr("NombreCorto")), Nothing, oDr("NombreCorto"))
            Me.txtRFC.Text = IIf(IsDBNull(oDr("IDFiscal")), Nothing, oDr("IDFiscal"))
            Me.txtRazonSocial.Text = oDr("RazonSocial")
            dtpFechaRegistro.Value = oDr("FechaRegistroSistema")
            dtpFechaNac.Value = IIf(IsDBNull(oDr("FechaNacimiento")), DateSerial(1900, 1, 1), oDr("FechaNacimiento"))
            Me.txtContacto.Text = IIf(IsDBNull(oDr("NombreContacto")), Nothing, oDr("NombreContacto"))
            Me.txtTelefono.Text = IIf(IsDBNull(oDr("TelefonoContacto")), Nothing, oDr("TelefonoContacto"))
            Me.CheckBoxDesglose.Checked = (oDr("DesgloseImpuesto"))
        ElseIf pvIndice = 1 Then
            'If oStatus = eStatus.Nuevo Then
            '    Me.LimpiarCampos(pvIndice)
            '    Exit Sub
            'End If
            'Dim sQuery As String = "SELECT * FROM ClienteDomicilio WHERE ClienteClave='" & oAgenda.ClienteActual.ClienteClave & "'"
            'Dim oDtDom As DataTable = oDBVen.RealizarConsultaSQL(sQuery, "LlenarCampos1")
            If Not IsNothing(oDtDom) AndAlso oDtDom.Rows.Count > 0 Then
                If oDtDom.Select(" tipo= " & TipoDomicilio.PuntoEntrega).Length > 0 Then
                    Dim oDr As DataRow = oDtDom.Select(" tipo= " & TipoDomicilio.PuntoEntrega)(0)
                    Me.txtCallePE.Text = IIf(IsDBNull(oDr("Calle")), Nothing, oDr("Calle"))
                    Me.txtNumeroPE.Text = IIf(IsDBNull(oDr("Numero")), Nothing, oDr("Numero"))
                    Me.txtColoniaPE.Text = IIf(IsDBNull(oDr("Colonia")), Nothing, oDr("Colonia"))
                    Me.txtCodigoPostalPE.Text = IIf(IsDBNull(oDr("CodigoPostal")), Nothing, oDr("CodigoPostal"))
                    Me.txtPoblacionPE.Text = IIf(IsDBNull(oDr("Poblacion")), Nothing, oDr("Poblacion"))
                    Me.txtEntidadPE.Text = oDr("Entidad")
                    Me.txtPaisPE.Text = oDr("Pais")
                    Me.txtInteriorPE.Text = IIf(IsDBNull(oDr("NumInt")), Nothing, oDr("NumInt"))
                    Me.txtReferenciaPE.Text = IIf(IsDBNull(oDr("ReferenciaDom")), Nothing, oDr("ReferenciaDom"))
                End If
                If oDtDom.Select(" tipo= " & TipoDomicilio.Fiscal).Length > 0 Then
                    Dim oDr As DataRow = oDtDom.Select(" tipo= " & TipoDomicilio.Fiscal)(0)
                    Me.txtCalleFiscal.Text = IIf(IsDBNull(oDr("Calle")), Nothing, oDr("Calle"))
                    Me.txtNumeroFiscal.Text = IIf(IsDBNull(oDr("Numero")), Nothing, oDr("Numero"))
                    Me.txtColoniaFiscal.Text = IIf(IsDBNull(oDr("Colonia")), Nothing, oDr("Colonia"))
                    Me.txtCodigoPostalFiscal.Text = IIf(IsDBNull(oDr("CodigoPostal")), Nothing, oDr("CodigoPostal"))
                    Me.txtPoblacionFiscal.Text = IIf(IsDBNull(oDr("Poblacion")), Nothing, oDr("Poblacion"))
                    Me.txtEntidadFiscal.Text = oDr("Entidad")
                    Me.txtPaisFiscal.Text = oDr("Pais")
                    Me.txtInteriorFiscal.Text = IIf(IsDBNull(oDr("NumInt")), Nothing, oDr("NumInt"))
                    Me.txtReferenciaFiscal.Text = IIf(IsDBNull(oDr("ReferenciaDom")), Nothing, oDr("ReferenciaDom"))
                End If
            End If
            'oDtDom.Dispose()
        ElseIf pvIndice = 2 Then
            Me.CheckBoxExclusividad.Enabled = True
            If Me.CheckBoxExclusividad.Checked = True Then
                Me.dtVig.Enabled = True
            Else
                Me.dtVig.Enabled = False
            End If
        End If
    End Sub

    Private Sub LimpiarCampos(ByVal pvIndice As Integer)
        If pvIndice = 0 Then
            For Each oControl As Control In Me.Panel2.Controls
                If TypeOf oControl Is TextBox Then
                    oControl.Text = String.Empty
                End If
            Next
            dtpFechaNac.Value = PrimeraHora(Today)
            dtpFechaRegistro.Value = Today
        ElseIf pvIndice = 1 Then
            For Each oControl As Control In Me.PanelDomPuntoE.Controls
                If TypeOf oControl Is TextBox Then
                    oControl.Text = String.Empty
                End If
            Next
        End If
    End Sub

    Private Function ObtenerEsquemaNuevo() As String
        Return oDBVen.RealizarConsultaSQL("SELECT EsquemaId FROM Esquema WHERE Clave='NVO001'", "ObtenerEsquemaNuevo").Rows(0)(0)
    End Function
#End Region

#Region "EVENTOS"

    Private Sub txtCalle_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If bEditando Then
            bHuboCambios = True
        End If
    End Sub
#End Region

    Public Enum eStatus
        Nuevo = 1
        Existente = 2
    End Enum

#End Region

#Region "TabPageConfiguracion"
    Private Sub LlenarCreditosPendientes()
        Dim tipoTRP = "1"
        If Not (oConHist.Campos("CobrarVentas")) Then
            tipoTRP = "8"
        End If
        Dim oDt As DataTable = oDBVen.RealizarConsultaSQL("SELECT TP.Saldo FROM TransProd TP INNER JOIN Visita V ON TP.VisitaClave=V.VisitaClave AND TP.DiaClave=V.DiaClave AND V.ClienteClave='" & oAgenda.ClienteActual.ClienteClave & "' AND TP.Tipo=" & tipoTRP & " AND TP.TipoFase<>0 and TP.Saldo>0", "Creditos")
        If oDt.Rows.Count = 0 Then
            Me.txtCantidad.Text = 0
            Me.txtImporte.Text = FormatNumber(0, 2, , , TriState.True)

        Else
            Me.txtCantidad.Text = oDt.Rows.Count
            Dim dImporte As Double = 0
            For Each oDr As DataRow In oDt.Rows
                dImporte += oDr("Saldo")
            Next
            Me.txtImporte.Text = FormatNumber(dImporte, 2, , , TriState.True)
        End If
        oDt = oDBVen.RealizarConsultaSQL("SELECT * FROM cliente  where ClienteClave='" & oAgenda.ClienteActual.ClienteClave & "'", "Creditos")
        If oDt.Rows.Count = 0 Then
            txtFechaFactura.Text = ""
            txtSaldoCliente.Text = ""
        Else
            If IsDBNull(oDt.Rows(0)("FechaFactura")) Or oDt.Rows(0)("FechaFactura") Is Nothing Then
                txtFechaFactura.Text = ""
            Else
                txtFechaFactura.Text = oDt.Rows(0)("FechaFactura")
            End If

            txtSaldoCliente.Text = oDt.Rows(0)("SaldoEfectivo")
        End If
        oDt.Dispose()
    End Sub

    Private Sub btActivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btActivos.Click
        Dim oConfigCliente As New FormConfiguracionCliente(oAgenda.ClienteActual.ClienteClave, FormConfiguracionCliente.OpcionAVer.ActivosPrestados)
        oConfigCliente.ShowDialog()
        oConfigCliente.Dispose()
    End Sub

    Private Sub btEnvase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEnvase.Click
        Dim oConfigCliente As New FormConfiguracionCliente(oAgenda.ClienteActual.ClienteClave, FormConfiguracionCliente.OpcionAVer.PrestamoDeEnvase)
        oConfigCliente.ShowDialog()
        oConfigCliente.Dispose()
    End Sub

    Private Sub btCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCompra.Click
        Dim oConfigCliente As New FormConfiguracionCliente(oAgenda.ClienteActual.ClienteClave, FormConfiguracionCliente.OpcionAVer.PromedioDeCompra)
        oConfigCliente.ShowDialog()
        oConfigCliente.Dispose()
    End Sub

    Private Sub btEsquemas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEsquemas.Click
        Dim oConfigCliente As New FormConfiguracionCliente(oAgenda.ClienteActual.ClienteClave, FormConfiguracionCliente.OpcionAVer.EsquemasDeCliente, bEditando)
        oConfigCliente.ShowDialog()
        oConfigCliente.Dispose()
    End Sub

    Private Function EsClienteNuevo(ByVal pvClave As String) As Boolean
        If pvClave <> String.Empty Then
            Return IIf(pvClave.StartsWith("NUEVO"), True, False)
        End If
        Return True
    End Function

#End Region


    Private Sub TabPageDomicilios_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPageDomicilios.Click
        txtCallePE.Focus()
    End Sub

    Private Sub TabPageGeneral_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPageGeneral.Click
        Me.txtRazonSocial.Focus()
    End Sub

    Private Sub CheckBoxExclusividad_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxExclusividad.CheckStateChanged
        If (oStatus = eStatus.Existente And bEditando) Or oStatus = eStatus.Nuevo Then
            If Me.CheckBoxExclusividad.Checked Then
                Me.dtVig.Enabled = True
            Else
                Me.dtVig.Enabled = False
            End If
        End If
    End Sub

    Private Sub FormClienteDetalle_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        If Not Vista.Buscar("FormClienteDetalle", refaVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        'Dim arrTpoDom As New ArrayList
        'Dim aValores As ArrayList = ValorReferencia.RecuperarLista("DOMTIPO")
        'For Each refDesc As ValorReferencia.Descripcion In aValores
        '    arrTpoDom.Add(New ComboGeneral(refDesc.Id, refDesc.Cadena))
        'Next
        'aValores = Nothing
        'ComboBoxTipoDomicilio.DataSource = arrTpoDom
        'ComboBoxTipoDomicilio.DisplayMember = "Concepto"
        'ComboBoxTipoDomicilio.ValueMember = "Valor"
        refaVista.ColocarEtiquetasForma(Me)
        Me.LbCalle2.Text = lbCalle.Text
        Me.lbNumero2.Text = lbNumero.Text
        Me.lbInterior2.Text = lbInterior.Text
        Me.lbColonia2.Text = lbColonia.Text
        Me.lbCodigoPostal2.Text = lbCodigoPostal.Text
        Me.lbReferencia2.Text = lbReferencia.Text
        Me.lbPoblacion2.Text = lbPoblacion.Text
        Me.lbEntidad2.Text = lbEntidad.Text
        Me.lbPais2.Text = lbPais.Text

        Me.TabPageFiscal.Text = ValorReferencia.BuscarEquivalente2("DOMTIPO", TipoDomicilio.Fiscal)
        Me.TabPagePuntoE.Text = ValorReferencia.BuscarEquivalente2("DOMTIPO", TipoDomicilio.PuntoEntrega)

        Me.LimpiarCampos(0)
        Me.LimpiarCampos(1)

        If oStatus = eStatus.Existente Then
            oAgenda.ClienteActual.Recuperar()
            Me.MostrarCamposNuevo(False)
            refaVista.CrearDetailView(DetailViewCliente, "DetailViewCliente")
            DetailViewCliente.Items("DesgloseImpuesto").Tag = "<*>"
            refaVista.CrearDetailView(DetailViewDomPuntoE, "DetailViewDomicilios")
            refaVista.CrearDetailView(DetailViewDomFiscal, "DetailViewDomicilios")
            MostrarDetalleCliente()
            Me.ButtonClienteRegresar.Visible = False
            Me.ButtonClienteEditar.Visible = True
            Me.txtRazonSocial.Focus()
            Panel2.Visible = False
            PanelDomPuntoE.Visible = False

            Dim sQuery As String = "SELECT tipo,calle,numero,colonia,codigopostal,poblacion,entidad,pais,numint,referenciadom FROM ClienteDomicilio WHERE ClienteClave='" & oAgenda.ClienteActual.ClienteClave & "'"
            oDtDom = oDBVen.RealizarConsultaSQL(sQuery, "LlenarCampos1")

            Me.TabPageConfiguracion.Text = refaVista.BuscarMensaje("Mensajes", "XConsulta")

        Else
            bEditando = True
            Me.ButtonClienteRegresar.Visible = True
            Me.ButtonClienteEditar.Visible = False
            Me.txtClave.Text = "NUEVO" & Me.ObtenerConsecutivoNuevo
            Me.CheckBoxExclusividad.Checked = False
            Me.CheckBoxPrestamoEnvases.Checked = True
            Me.dtVig.Value = DateSerial(1900, 1, 1)
            Me.MostrarCamposNuevo(True)
            Me.txtRazonSocial.Focus()
            Panel2.Visible = True
            PanelDomPuntoE.Visible = True
            bCambioManual = True
            'ComboBoxTipoDomicilio.SelectedIndex = 1
            TabControlDetalles.TabPages.RemoveAt(3)
            Me.TabControlDetalles.SelectedIndex = 0
            'Dim sQuery As String = "SELECT tipo,calle,numero,colonia,codigopostal,poblacion,entidad,pais,numint,referenciadom FROM ClienteDomicilio WHERE ClienteClave is null"
            'oDtDom = oDBVen.RealizarConsultaSQL(sQuery, "LlenarCampos1")

            Me.TabPageConfiguracion.Text = refaVista.BuscarMensaje("Mensajes", "XConfiguracion")
            Me.CheckBoxPrestamoEnvases.Enabled = True
        End If
        Me.ConfigurarTabConfiguracion()
        iDomicilioActual = 2
        'Me.ComboBoxTipoDomicilio.SelectedIndex = 1

        bIniciando = False
        Cursor.Current = Cursors.Default
        bCambioManual = False
    End Sub



    Private Sub CAMBIOS(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCallePE.TextChanged, txtCantidad.TextChanged, txtClave.TextChanged, txtCodigoBarras.TextChanged, txtCodigoPostalPE.TextChanged, txtColoniaPE.TextChanged, txtContacto.TextChanged, txtEntidadPE.TextChanged, txtFechaFactura.TextChanged, txtImporte.TextChanged, txtInteriorPE.TextChanged, txtNombreCorto.TextChanged, txtNombreCorto.TextChanged, txtNumeroPE.TextChanged, txtNumeroPE.TextChanged, txtPaisPE.TextChanged, txtPoblacionPE.TextChanged, txtRazonSocial.TextChanged, txtReferenciaPE.TextChanged, txtSaldoCliente.TextChanged, txtTelefono.TextChanged, CheckBoxDesglose.CheckStateChanged, CheckBoxExclusividad.CheckStateChanged, CheckBoxPrestamoEnvases.CheckStateChanged

        If Not bIniciando Then
            bHuboCambios = True
        End If
    End Sub

    Private Sub txtRFC_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRFC.TextChanged
        If Not bIniciando Then
            bHuboCambios = True
            Dim cadena As String = Me.txtRFC.Text.Replace("-", "")
            If cadena.Length > 14 Then
                txtRFC.Text = sRFC
                MsgBox(SustituirValoresMensaje(refaVista.BuscarMensaje("Mensajes", "E0718"), New String() {Me.lbRFC.Text, "14"}))
            Else
                sRFC = txtRFC.Text
            End If
        End If
    End Sub

    Private Enum TipoDomicilio
        Fiscal = 1
        PuntoEntrega = 2
    End Enum
End Class