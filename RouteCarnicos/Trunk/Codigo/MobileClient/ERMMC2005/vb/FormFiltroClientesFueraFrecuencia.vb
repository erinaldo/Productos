Imports System.Data.SqlServerCe


Public Class FormFiltroClientesFueraFrecuencia

#Region "PROPIEDADES"
    Public Property RutaActual() As Ruta
        Get
            Return oRutaActual
        End Get
        Set(ByVal Value As Ruta)
            oRutaActual = Value
        End Set
    End Property

    Public Property ClienteActual() As Cliente
        Get
            Return oClienteActual
        End Get
        Set(ByVal Value As Cliente)
            oClienteActual = Value
        End Set
    End Property

#End Region

#Region "VARIABLES Y CONSTANTES"
    Private Const ConstTabFiltros = 0
    Private Const ConstTabClientes = 1

    Private oRutaActual As Ruta
    Private oClienteActual As Cliente

    Private bCambioManual As Boolean = False
    Private bHuboCambios As Boolean = False

    Private refaVista As Vista
    Private bIniciando As Boolean = True
    Private bLlenando As Boolean = True
    Private iSegundos As Integer
    Private dFechaReferencia As DateTime = Now
    Public bLeerContrasenaCliente As Boolean = False
    Friend bCodigoLeido As Boolean = False
    Private bClienteSeleccionado As Boolean = False
#End Region

#Region " Eventos generales de la forma "

    Private Sub FormAgenda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        If Not Vista.Buscar("FormFiltroClientesFueraFre", refaVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        refaVista.ColocarEtiquetasForma(Me)
        Me.CheckBoxClave.Text = refaVista.BuscarMensaje("MsgBox", "Clave")
        Me.CheckBoxNombre.Text = refaVista.BuscarMensaje("MsgBox", "Contacto")
        Me.CheckBoxRazonSocial.Text = refaVista.BuscarMensaje("MsgBox", "RazonSocial")
        Me.CheckBoxDomicilio.Text = refaVista.BuscarMensaje("MsgBox", "Domicilio")
        InicializarGrid()
        Me.bLeerContrasenaCliente = oConHist.Campos("ContrasenaCliente")
        LabelTiempo.Text = Format(PrimeraHora(Now), oApp.FormatoFecha)
        LlenaCombos()
        Me.PonerFocusAColumna("RazonSocial")
        bIniciando = False
        Cursor.Current = Cursors.Default
    End Sub

#End Region

    Private Sub LlenaCombos()
        'ComboBoxComparaClave
        With ComboBoxComparaClave
            .DataSource = ValorReferencia.RecuperarLista("BFSTRING")
            If .Items.Count > 0 Then
                .DisplayMember = "Cadena"
                .ValueMember = "Id"
                .SelectedIndex = 0
            End If
        End With

        'ComboBoxComparaNombre
        With ComboBoxComparaNombre
            .DataSource = ValorReferencia.RecuperarLista("BFSTRING")
            If .Items.Count > 0 Then
                .DisplayMember = "Cadena"
                .ValueMember = "Id"
                .SelectedIndex = 0
            End If
        End With

        'ComboBoxComparaRazonSocial
        With ComboBoxComparaRazonSocial
            .DataSource = ValorReferencia.RecuperarLista("BFSTRING")
            If .Items.Count > 0 Then
                .DisplayMember = "Cadena"
                .ValueMember = "Id"
                .SelectedIndex = 0
            End If
        End With

        'ComboBoxComparaDomicilio
        With ComboBoxComparaDom
            .DataSource = ValorReferencia.RecuperarLista("BFSTRING")
            If .Items.Count > 0 Then
                .DisplayMember = "Cadena"
                .ValueMember = "Id"
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Function ValidaCampos() As Boolean
        If CheckBoxClave.Checked Then
            If IsNothing(ComboBoxComparaClave.SelectedValue) Or TextBoxClave.Text = "" Then
                MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.CheckBoxClave.Text))
                If IsNothing(ComboBoxComparaClave.SelectedValue) Then
                    ComboBoxComparaClave.Focus()
                Else
                    TextBoxClave.Focus()
                End If
                Return False
            End If
        End If

        If CheckBoxNombre.Checked Then
            If IsNothing(ComboBoxComparaNombre.SelectedValue) Or TextBoxNombre.Text = "" Then
                MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.CheckBoxNombre.Text))
                If IsNothing(ComboBoxComparaNombre.SelectedValue) Then
                    ComboBoxComparaNombre.Focus()
                Else
                    TextBoxNombre.Focus()
                End If
                Return False
            End If
        End If

        If CheckBoxRazonSocial.Checked Then
            If IsNothing(ComboBoxComparaRazonSocial.SelectedValue) Or TextBoxRazonSocial.Text = "" Then
                MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.CheckBoxRazonSocial.Text))
                If IsNothing(ComboBoxComparaRazonSocial.SelectedValue) Then
                    ComboBoxComparaRazonSocial.Focus()
                Else
                    TextBoxRazonSocial.Focus()
                End If
                Return False
            End If
        End If

        If CheckBoxDomicilio.Checked Then
            If IsNothing(ComboBoxComparaDom.SelectedValue) Or TextBoxDomicilio.Text = "" Then
                MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.CheckBoxDomicilio.Text))
                If IsNothing(ComboBoxComparaDom.SelectedValue) Then
                    ComboBoxComparaDom.Focus()
                Else
                    TextBoxDomicilio.Focus()
                End If
                Return False
            End If
        End If

        Return True
    End Function

#Region " Eventos y procedimientos del manejo de la Agenda "

    Private Sub ButtonAgendaContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgendaContinuar.Click

        Dim indiceCliente As Integer = Me.FlexGridClientes.Row
        If indiceCliente <> -1 Then
            If oApp.ExigirSecuenciaClientes Then
                Dim odtOrden As DataTable = oDBVen.RealizarConsultaSQL("Select Orden from agenda where DiaClave='" & oDia.DiaActual & "' And RUTClave='" & oRutaActual.RUTClave & "' AND ClienteClave='" & Me.FlexGridClientes.GetData(indiceCliente, "ClienteClave") & "' and Visitado = 2", "OrdenCliente")
                If odtOrden.Rows.Count > 0 Then
                    Dim odtOrdenMenor As DataTable = oDBVen.RealizarConsultaSQL("Select Cliente.clave, Orden from agenda inner join Cliente on Cliente.CLienteClave = Agenda.ClienteCLave where DiaClave='" & oDia.DiaActual & "' And RUTClave='" & oRutaActual.RUTClave & "' AND Agenda.ClienteClave<>'" & Me.FlexGridClientes.GetData(indiceCliente, "ClienteClave") & "' and Visitado = 2 and orden <=" & odtOrden.Rows(0)(0), "OrdenCliente")
                    If odtOrdenMenor.Rows.Count > 0 Then
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0431").Replace("$0$", Me.FlexGridClientes.GetData(indiceCliente, "Clave")).Replace("$1$", odtOrdenMenor.Rows(0)(0)), MsgBoxStyle.Information)
                        Me.FlexGridClientes.Focus()
                        Exit Sub
                    End If
                    odtOrdenMenor.Dispose()
                End If
                odtOrden.Dispose()
            End If
            If Me.bLeerContrasenaCliente AndAlso oApp.AseguramientoVisita Then
                Me.MostrarPanelContrasena(True)
            Else
                MostrarDetalleCliente()
            End If

        Else
            MsgBox(refaVista.BuscarMensaje("MsgBox", "Elige"), MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub

    Private Sub ButtonAgendaRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgendaRegresar.Click
        Me.TabControlClientesFueraFrecuencia.SelectedIndex = 0
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub InicializarGrid()
        With FlexGridClientes
            With Me.FlexGridClientes
                .Redraw = False
                .DataSource = Nothing
                .AutoResize = False
                '.DataSource = oDt
                .Rows.Count = 1
                .Cols.Fixed = 0
                .Cols(0).Visible = False
                .Cols(1).Caption = refaVista.BuscarMensaje("MsgBox", "Clave")
                .Cols(1).Width = 80
                .Cols(1).AllowEditing = False
                .Cols(2).Caption = refaVista.BuscarMensaje("MsgBox", "RazonSocial")
                .Cols(2).Width = 160
                .Cols(2).AllowEditing = False
                .Cols(3).Caption = refaVista.BuscarMensaje("MsgBox", "Contacto")
                .Cols(3).Width = 160
                .Cols(3).AllowEditing = False
                .Cols(4).Visible = False
                .KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
                .KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None
                .Redraw = True
            End With
        End With
    End Sub
    Private Sub MostrarClientes(ByVal parsFiltros As String)
        bLlenando = True
        Me.BorrarPatron()

        Dim sQuery As New Text.StringBuilder
        sQuery.Append("SELECT AGN.ClienteClave, CLI.Clave, CLI.RazonSocial, CLI.NombreContacto, CLI.IdElectronico FROM Agenda AGN INNER JOIN Cliente CLI ON AGN.ClienteClave = CLI.ClienteClave ")
        If CheckBoxDomicilio.Checked Then
            sQuery.Append("INNER JOIN ClienteDomicilio CLD ON AGN.ClienteClave = CLD.ClienteClave ")
        End If
        sQuery.Append("WHERE AGN.ClienteClave not in(Select ClienteClave from Agenda where DiaClave='" & oDia.DiaActual & "') and AGN.RUTClave='" & oRutaActual.RUTClave & "' ")
        sQuery.Append(parsFiltros & " ")
        sQuery.Append("group by AGN.ClienteClave, CLI.Clave, CLI.RazonSocial, CLI.NombreContacto, CLI.IdElectronico ")

        Dim oDt As DataTable = oDBVen.RealizarConsultaSQL(sQuery.ToString, "ObtenerDatos")

        If oDt.Rows.Count <= 0 Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0034"), MsgBoxStyle.Information)
            InicializarGrid()
            Exit Sub
        End If

        Try
            Me.TabControlClientesFueraFrecuencia.SelectedIndex = 1
            With Me.FlexGridClientes
                .Redraw = False
                .DataSource = Nothing
                .AutoResize = False
                .DataSource = oDt
                .Cols.Fixed = 0
                .Cols(0).Visible = False
                .Cols(1).Caption = refaVista.BuscarMensaje("MsgBox", "Clave")
                .Cols(1).Width = 80
                .Cols(1).AllowEditing = False
                .Cols(2).Caption = refaVista.BuscarMensaje("MsgBox", "RazonSocial")
                .Cols(2).Width = 160
                .Cols(2).AllowEditing = False
                .Cols(3).Caption = refaVista.BuscarMensaje("MsgBox", "Contacto")
                .Cols(3).Width = 160
                .Cols(3).AllowEditing = False
                .Cols(4).Visible = False
                .KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
                .KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None
                .Redraw = True
            End With
        Catch ex As Exception
            'MsgBox(ex.Message)
            oDt.Dispose()
        End Try
        SeleccionarClienteActual()
        Me.PonerFocusAColumna("RazonSocial")
        'End If
        bLlenando = False
    End Sub

#End Region

#Region " Eventos y procedimientos del manejo del Detalle del Cliente "

    Private Sub MostrarDetalleCliente()
        If bClienteSeleccionado Then
            Exit Sub
        End If
        Dim i As Integer = Me.FlexGridClientes.Row
        If i <= -1 Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "Elige"), MsgBoxStyle.Information)
            Exit Sub
        End If
        bClienteSeleccionado = True
        Me.FlexGridClientes.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None
        Me.FlexGridClientes.AutoSearchDelay = 100000
        Me.ClienteActual.ClienteClave = Me.FlexGridClientes.Item(i, "ClienteClave")
        Me.ClienteActual.Recuperar()
        FormProcesando.PubSubTitulo(refaVista.BuscarMensaje("ProcesandoAgenda", "Titulo"))
        FormProcesando.PubSubInformar(refaVista.BuscarMensaje("ProcesandoAgenda", "Buscando"))
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


#End Region

#Region " Funciones privadas de la forma "

    Private Sub DesmarcarTodosMenus(ByVal refparMenuItem As MenuItem)
        Dim refMenuItem As MenuItem
        For Each refMenuItem In refparMenuItem.MenuItems
            refMenuItem.Checked = False
        Next
    End Sub

    Private Sub SeleccionarClienteActual()
        If IsNothing(Me.ClienteActual) Then Exit Sub

        If Me.ClienteActual.ClienteClave = String.Empty Then
            Exit Sub
        End If

        Dim i As Integer = Me.EncontrarElemento(Me.ClienteActual.ClienteClave, Me.FlexGridClientes.Cols("ClienteClave").Index)
        If i <> -1 Then
            CTEActual = Me.ClienteActual.ClienteClave
            Me.FlexGridClientes.Row = i
        End If
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

#Region "METODOS"

    'Private Sub CargarAgenda()
    '    ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys

    '    'MostrarClienteActual()
    'End Sub

    Private Function ObtenerEsquemaNuevo() As String
        Return oDBVen.RealizarConsultaSQL("SELECT EsquemaId FROM Esquema WHERE Clave='NVO001'", "ObtenerEsquemaNuevo").Rows(0)(0)
    End Function
#End Region

#End Region

    Private Function EncontrarElemento(ByVal pvObjetoBuscado As Object, ByVal iColumna As Integer, Optional ByVal iFilaInicio As Integer = 1, Optional ByVal pvWrap As Boolean = True) As Integer
        Return Me.FlexGridClientes.FindRow(pvObjetoBuscado, iFilaInicio, iColumna, pvWrap)
    End Function

    Private Sub FlexGridClientes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FlexGridClientes.KeyPress
        If DateDiff(DateInterval.Second, dFechaReferencia, Now) > Me.FlexGridClientes.AutoSearchDelay Then
            Me.BorrarPatron()
        End If
        dFechaReferencia = Now
        If Me.FlexGridClientes.ColSel <> 0 AndAlso (Char.IsLetterOrDigit(e.KeyChar) OrElse Asc(e.KeyChar) = 32) Then
            Me.txtPatron.Text &= e.KeyChar
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If FlexGridClientes.Col = 0 Then Exit Sub
            If FlexGridClientes.Row > 0 Then
                Me.ClienteActual.ClienteClave = Me.FlexGridClientes.Item(Me.FlexGridClientes.Row, "ClienteClave")
                CTEActual = Me.ClienteActual.ClienteClave
                Me.bCodigoLeido = False
                ButtonAgendaContinuar_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub BorrarPatron()
        Me.txtPatron.Text = String.Empty
    End Sub

    Private Sub PonerFocusAColumna(ByVal pvIndiceColumna As Integer)
        Try
            Me.FlexGridClientes.Focus()
            Me.FlexGridClientes.Col = pvIndiceColumna
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PonerFocusAColumna(ByVal pvNombreColumna As String)
        Try
            Me.FlexGridClientes.Focus()
            Me.FlexGridClientes.Col = Me.FlexGridClientes.Cols(pvNombreColumna).Index
        Catch ex As Exception

        End Try
    End Sub

    Private Function ContrasenaCorrecta(ByVal pvContrasena As String, ByVal pvClienteClave As String) As Boolean
        Dim sContrasena As String = Trim(Format(oDia.FechaCaptura, "ddMMyyyy") & pvClienteClave.ToUpper & Me.RutaActual.RUTClave.ToUpper)
        Return (Trim(pvContrasena.ToUpper) = sContrasena.Replace("-", ""))
    End Function

    Private Sub MostrarPanelContrasena(ByVal pvMostrar As Boolean)
        With Me.PanelContrasena
            If pvMostrar Then
                Me.Panel1.Visible = False
                .Visible = True
                Me.textContrasena.Text = String.Empty
                Me.textContrasena.Focus()
            Else
                Me.Panel1.Visible = True
                .Visible = False
            End If
        End With
    End Sub

    Private Sub ButtonAceptarContrasena_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonAceptarContrasena.Click
        If AceptarContrasena() Then
            MostrarDetalleCliente()
        End If
    End Sub

    Private Sub ButtonCancelarContrasena_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCancelarContrasena.Click
        Me.MostrarPanelContrasena(False)
    End Sub

    Private Sub textContrasena_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles textContrasena.KeyDown
        If e.KeyCode = Keys.Enter Then
            If AceptarContrasena() Then
                MostrarDetalleCliente()
            End If
        End If
    End Sub

    Private Function AceptarContrasena() As Boolean
        Dim indiceCliente As Integer = Me.FlexGridClientes.Row
        If Not Me.ContrasenaCorrecta(Me.textContrasena.Text, Me.FlexGridClientes.GetData(indiceCliente, "Clave").ToString) Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0210"), MsgBoxStyle.Critical, "Amesol Route")
            Me.MostrarPanelContrasena(False)
            Return False
        End If
        Me.MostrarPanelContrasena(False)
        Return True
    End Function

    Private Sub CheckBoxClave_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxClave.CheckStateChanged
        ComboBoxComparaClave.Enabled = CheckBoxClave.Checked
        TextBoxClave.Enabled = CheckBoxClave.Checked
    End Sub

    Private Sub CheckBoxDomicilio_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxDomicilio.CheckStateChanged
        ComboBoxComparaDom.Enabled = CheckBoxDomicilio.Checked
        TextBoxDomicilio.Enabled = CheckBoxDomicilio.Checked
    End Sub

    Private Sub CheckBoxNombre_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxNombre.CheckStateChanged
        ComboBoxComparaNombre.Enabled = CheckBoxNombre.Checked
        TextBoxNombre.Enabled = CheckBoxNombre.Checked
    End Sub

    Private Sub CheckBoxRazonSocial_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxRazonSocial.CheckStateChanged
        ComboBoxComparaRazonSocial.Enabled = CheckBoxRazonSocial.Checked
        TextBoxRazonSocial.Enabled = CheckBoxRazonSocial.Checked
    End Sub

    Private Sub ButtonFiltroContinuar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonFiltroContinuar.Click
        If Not ValidaCampos() Then Exit Sub
        Dim sCondiciones As String = String.Empty
        sCondiciones = CreaCondiciones()
        MostrarClientes(sCondiciones)

    End Sub
    Private Function CreaCondiciones() As String
        Dim sResultado As String = String.Empty
        If CheckBoxClave.Checked Then
            sResultado &= " AND "
            sResultado &= " CLI.Clave " & Operador(ComboBoxComparaClave.SelectedValue, Me.TextBoxClave.Text, Nothing, TipoDato.Cadena)
        End If

        If CheckBoxRazonSocial.Checked Then
            sResultado &= " AND "
            sResultado &= " CLI.RazonSocial " & Operador(ComboBoxComparaRazonSocial.SelectedValue, Me.TextBoxRazonSocial.Text, Nothing, TipoDato.Cadena)
        End If

        If CheckBoxNombre.Checked Then
            sResultado &= " AND "
            sResultado &= " CLI.NombreContacto " & Operador(ComboBoxComparaNombre.SelectedValue, Me.TextBoxNombre.Text, Nothing, TipoDato.Cadena)
        End If

        If CheckBoxDomicilio.Checked Then
            sResultado &= " AND "
            sResultado &= " CLD.Calle " & Operador(ComboBoxComparaDom.SelectedValue, Me.TextBoxDomicilio.Text, Nothing, TipoDato.Cadena)
        End If

        Return sResultado
    End Function

    Private Sub ButtonFiltroRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonFiltroRegresar.Click
        Me.Close()
        CTEActual = String.Empty
    End Sub
End Class