Imports System.IO
Imports System.Collections.Generic
Imports System.Data

Enum enActivo
    Asginados
    NoAsignados
    PorFiltro
End Enum

Enum Reporte
    TiemposEnRutaSuKarne = 67
End Enum

Partial Class FiltrosWEB
    Inherits System.Web.UI.Page

#Region "Variables"
    Dim chbRuta As Boolean
    Dim boolTodos As Boolean = False
    Dim fecha1 As Date
    Dim fecha2 As Date
    Dim IntCommandTimeOut As Integer
    Dim UsuarioID As String

#End Region

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Mensaje As New DBConexion.cMensaje

        If Not IsNothing(Session("_TimeOut")) Then
            IntCommandTimeOut = Session("_TimeOut")
        End If

        UsuarioID = Session("UsuarioID")
        Session.Clear()
        Session("UsuarioID") = UsuarioID
        If IntCommandTimeOut > 0 Then
            Session("_TimeOut") = IntCommandTimeOut
        End If
        'Session.Timeout = 8000
        'Try

        '    If (Me.Request.UrlReferrer.ToString().Substring(Me.Request.UrlReferrer.ToString().Length - "MenuBase.aspx".Length, "MenuBase.aspx".Length) = "MenuBase.aspx") Then

        '    ElseIf (Me.Request.UrlReferrer.ToString().Substring(Me.Request.UrlReferrer.ToString().Length - "Filtros.aspx".Length, "Filtros.aspx".Length) = "Filtros.aspx") Then

        '    Else
        '        Response.Redirect("Login.aspx")
        '    End If

        'Catch
        '    Response.Redirect("Login.aspx")
        'End Try


        '#If DEBUG Then
        Session("lenguaje") = DBConexion.cMensaje.ObtenerLenguaje

        If Not Page.IsPostBack Then
            Dim ins As New DBConexion.cConexionSQL
            Dim con As String() = ConfigurationManager.ConnectionStrings("ROUTEConnectionString").ConnectionString.ToUpper.Split(";")
            For i As Integer = 0 To con.Length - 1
                If con(i).StartsWith("CONNECTION TIMEOUT") Then
                    Session("_TimeOut") = con(i).Split("=")(1)
                End If
            Next
            IntCommandTimeOut = Session("_TimeOut")


            lbReporteW.Text = mensaje.RecuperarDescripcion("XAReporteWEB")
            Label6.Text = mensaje.RecuperarDescripcion("CRNFormato")
            Label2.Text = mensaje.RecuperarDescripcion("XREPORTE")
            chboxVendedor.Text = mensaje.RecuperarDescripcion("XVendedor")
            chboxFecha.Text = mensaje.RecuperarDescripcion("XFecha")
            chboxRuta.Text = mensaje.RecuperarDescripcion("XRuta")
            'ChecktodasRutas.Text = mensaje.RecuperarDescripcion("Xtodos")
            'CheckTodosClientes.Text = mensaje.RecuperarDescripcion("Xtodos")
            Label1.Text = mensaje.RecuperarDescripcion("XGruposCliente")
            Label3.Text = mensaje.RecuperarDescripcion("XClientes")
            Label5.Text = mensaje.RecuperarDescripcion("IMEEsquemaProductoID")
            Label7.Text = mensaje.RecuperarDescripcion("XActivos")
            btnContinuar.Text = mensaje.RecuperarDescripcion("BTcontinuar")
            btnContinuar.ToolTip = mensaje.RecuperarDescripcion("BTcontinuar")
            'btnRegresar.Text = mensaje.RecuperarDescripcion("BTregresar")
            'btnRegresar.ToolTip = mensaje.RecuperarDescripcion("BTregresar")
            chboxDetallado.Text = mensaje.RecuperarDescripcion("Xdetallado")
            chboxGeneral.Text = mensaje.RecuperarDescripcion("Xgeneral")
            ChBoxCentroDistribucion.Text = mensaje.RecuperarDescripcion("XCentroDistribucion")
            chboxAsignados.Text = mensaje.RecuperarDescripcion("XAsignados")
            chboxNoAsignados.Text = mensaje.RecuperarDescripcion("XnoAsignados")
            chboxPorFiltro.Text = mensaje.RecuperarDescripcion("XPorFiltro")

            'ins.Desconectar()
            'ins.Conectar(ConfigurationManager.ConnectionStrings("ROUTEConnectionString").ConnectionString)

            txtFInicio.Text = Date.Today.ToString("dd/MM/yyyy")
            txtFFinal.Text = Date.Today.ToString("dd/MM/yyyy")

            Me.LabelDegustacion.Text = mensaje.RecuperarDescripcion("XDegustacion")
            Me.LabelChequesDevueltos.Text = mensaje.RecuperarDescripcion("XChequesDevueltos")
            Me.LabelComision.Text = mensaje.RecuperarDescripcion("XComision")
            'obtener reportes ... en ddlReporte ....


            'tvEsquema .RootTable.Columns("Nombre").Caption = mensaje.RecuperarDescripcion("XGruposCliente")

            'tvEsquema .BuiltInTexts(Janus.Web.GridEX.GridEXBuiltInText.EmptyGridInfo) = mensaje.RecuperarDescripcion("XNoExistenRegistros")
            'CType(tvEsquema .PageNavigatorSettings.BottomPageNavigatorPanels(0), Janus.Web.GridEX.GridEXPageNavigatorItemCountPanel).ItemsText = mensaje.RecuperarDescripcion("XRegistroDe")
            'CType(tvEsquema .PageNavigatorSettings.BottomPageNavigatorPanels(3), Janus.Web.GridEX.GridEXPageNavigatorPreviousPagePanel).PreviousPageText = mensaje.RecuperarDescripcion("BTAnterior")
            'CType(tvEsquema .PageNavigatorSettings.BottomPageNavigatorPanels(4), Janus.Web.GridEX.GridEXPageNavigatorPageSelectorDropDownPanel).PagesSelectorText = mensaje.RecuperarDescripcion("XPaginaDe")
            'CType(tvEsquema .PageNavigatorSettings.BottomPageNavigatorPanels(5), Janus.Web.GridEX.GridEXPageNavigatorNextPagePanel).NextPageText = mensaje.RecuperarDescripcion("BTSiguiente")


            GridEXCliente.RootTable.Columns("Clave").Caption = mensaje.RecuperarDescripcion("CLIClave")
            GridEXCliente.RootTable.Columns("RazonSocial").Caption = mensaje.RecuperarDescripcion("XCliente")

            GridEXCliente.BuiltInTexts(Janus.Web.GridEX.GridEXBuiltInText.EmptyGridInfo) = mensaje.RecuperarDescripcion("XNoExistenRegistros")
            CType(GridEXCliente.PageNavigatorSettings.BottomPageNavigatorPanels(0), Janus.Web.GridEX.GridEXPageNavigatorItemCountPanel).ItemsText = mensaje.RecuperarDescripcion("XRegistroDe")
            CType(GridEXCliente.PageNavigatorSettings.BottomPageNavigatorPanels(3), Janus.Web.GridEX.GridEXPageNavigatorPreviousPagePanel).PreviousPageText = mensaje.RecuperarDescripcion("BTAnterior")
            CType(GridEXCliente.PageNavigatorSettings.BottomPageNavigatorPanels(4), Janus.Web.GridEX.GridEXPageNavigatorPageSelectorDropDownPanel).PagesSelectorText = mensaje.RecuperarDescripcion("XPaginaDe")
            CType(GridEXCliente.PageNavigatorSettings.BottomPageNavigatorPanels(5), Janus.Web.GridEX.GridEXPageNavigatorNextPagePanel).NextPageText = mensaje.RecuperarDescripcion("BTSiguiente")

            UpdatePanel8.Update()


            GridEXActivos.RootTable.Columns("ActivoClave").Caption = mensaje.RecuperarDescripcion("ACIActivoClave")
            GridEXActivos.RootTable.Columns("IdElectronico").Caption = mensaje.RecuperarDescripcion("ACIIdElectronico")

            GridEXActivos.BuiltInTexts(Janus.Web.GridEX.GridEXBuiltInText.EmptyGridInfo) = mensaje.RecuperarDescripcion("XNoExistenRegistros")
            CType(GridEXActivos.PageNavigatorSettings.BottomPageNavigatorPanels(0), Janus.Web.GridEX.GridEXPageNavigatorItemCountPanel).ItemsText = mensaje.RecuperarDescripcion("XRegistroDe")
            CType(GridEXActivos.PageNavigatorSettings.BottomPageNavigatorPanels(3), Janus.Web.GridEX.GridEXPageNavigatorPreviousPagePanel).PreviousPageText = mensaje.RecuperarDescripcion("BTAnterior")
            CType(GridEXActivos.PageNavigatorSettings.BottomPageNavigatorPanels(4), Janus.Web.GridEX.GridEXPageNavigatorPageSelectorDropDownPanel).PagesSelectorText = mensaje.RecuperarDescripcion("XPaginaDe")
            CType(GridEXActivos.PageNavigatorSettings.BottomPageNavigatorPanels(5), Janus.Web.GridEX.GridEXPageNavigatorNextPagePanel).NextPageText = mensaje.RecuperarDescripcion("BTSiguiente")


            GridEXProducto.RootTable.Columns("Clave").Caption = mensaje.RecuperarDescripcion("ESQClave")
            GridEXProducto.RootTable.Columns("Nombre").Caption = mensaje.RecuperarDescripcion("ESQNombre")

            GridEXProducto.BuiltInTexts(Janus.Web.GridEX.GridEXBuiltInText.EmptyGridInfo) = mensaje.RecuperarDescripcion("XNoExistenRegistros")
            CType(GridEXProducto.PageNavigatorSettings.BottomPageNavigatorPanels(0), Janus.Web.GridEX.GridEXPageNavigatorItemCountPanel).ItemsText = mensaje.RecuperarDescripcion("XRegistroDe")
            CType(GridEXProducto.PageNavigatorSettings.BottomPageNavigatorPanels(3), Janus.Web.GridEX.GridEXPageNavigatorPreviousPagePanel).PreviousPageText = mensaje.RecuperarDescripcion("BTAnterior")
            CType(GridEXProducto.PageNavigatorSettings.BottomPageNavigatorPanels(4), Janus.Web.GridEX.GridEXPageNavigatorPageSelectorDropDownPanel).PagesSelectorText = mensaje.RecuperarDescripcion("XPaginaDe")
            CType(GridEXProducto.PageNavigatorSettings.BottomPageNavigatorPanels(5), Janus.Web.GridEX.GridEXPageNavigatorNextPagePanel).NextPageText = mensaje.RecuperarDescripcion("BTSiguiente")
            UpdatePanel10.Update()
            GridEXRuta.RootTable.Columns("RUTClave").Caption = mensaje.RecuperarDescripcion("XRuta")
            GridEXRuta.RootTable.Columns("Descripcion").Caption = mensaje.RecuperarDescripcion("ACTMENDescripcionClave")

            GridEXRuta.BuiltInTexts(Janus.Web.GridEX.GridEXBuiltInText.EmptyGridInfo) = mensaje.RecuperarDescripcion("XNoExistenRegistros")
            CType(GridEXRuta.PageNavigatorSettings.BottomPageNavigatorPanels(0), Janus.Web.GridEX.GridEXPageNavigatorItemCountPanel).ItemsText = mensaje.RecuperarDescripcion("XRegistroDe")
            CType(GridEXRuta.PageNavigatorSettings.BottomPageNavigatorPanels(3), Janus.Web.GridEX.GridEXPageNavigatorPreviousPagePanel).PreviousPageText = mensaje.RecuperarDescripcion("BTAnterior")
            CType(GridEXRuta.PageNavigatorSettings.BottomPageNavigatorPanels(4), Janus.Web.GridEX.GridEXPageNavigatorPageSelectorDropDownPanel).PagesSelectorText = mensaje.RecuperarDescripcion("XPaginaDe")
            CType(GridEXRuta.PageNavigatorSettings.BottomPageNavigatorPanels(5), Janus.Web.GridEX.GridEXPageNavigatorNextPagePanel).NextPageText = mensaje.RecuperarDescripcion("BTSiguiente")
            If (ddlReporte.Items.Count <= 0) Then
                Dim datRep As Data.DataTable = ins.EjecutarConsulta("SELECT VAD.VAVClave, VAD.Descripcion FROM VAVDescripcion VAD INNER JOIN VARValor VAV ON VAV.VARCodigo=VAD.VARCodigo AND VAV.VAVClave=VAD.VAVClave AND VAV.Estado=1 WHERE VAD.VARCodigo = 'REPORTEW' and VAD.VAVClave <> 0 and VAD.VADTipoLenguaje ='" + Session("lenguaje") + "' order by VAD.Descripcion ") 'order by (convert(int,VAD.VAVClave)) ")

                'For i As Integer = 0 To datRep.Rows.Count - 1
                '    ddlReporte.Items.Add(datRep.Rows(i)(0).ToString)


                'Next
                datRep.TableName = "Reportes"
                ddlReporte.DataTextField = "Descripcion"
                ddlReporte.DataValueField = "VAVClave"
                ddlReporte.DataSource = datRep
                ddlReporte.DataMember = "Reportes"
                ddlReporte.DataBind()
                'UpdatePanel2.Update()
            End If
            Dim vcUsuario As New DBManager.cUsuario
            vcUsuario.Recuperar(UsuarioID)
            Dim oAEliminar As New ArrayList()
            Dim vlTablaPermiso As Data.DataTable
            Dim vlPermiso As String
            For i As Integer = 0 To ddlReporte.Items.Count - 1
                vlPermiso = ""
                vlTablaPermiso = ins.EjecutarConsulta("select * from intusu where permiso like '%E%' and USUId='" & vcUsuario.USUId & "' AND ACTId = '" + "ReporteW" & ddlReporte.Items(i).Value + "' AND INTTipoInterfaz=3")
                If vlTablaPermiso.Rows.Count > 0 Then
                    vlPermiso = vlTablaPermiso.Rows(0)!Permiso
                Else
                    vlTablaPermiso = ins.EjecutarConsulta("select * from intper where permiso like '%E%' and PERClave='" & vcUsuario.PERClave & "' AND ACTId='" & "ReporteW" & ddlReporte.Items(i).Value & "' AND INTTipoInterfaz=3")
                    If vlTablaPermiso.Rows.Count > 0 Then
                        vlPermiso = vlTablaPermiso.Rows(0)!Permiso
                    Else
                        vlPermiso = ""
                    End If
                End If
                If vlPermiso.Trim = "" Then
                    oAEliminar.Add(i)

                End If


            Next
            For i As Integer = oAEliminar.Count - 1 To 0 Step -1
                ddlReporte.Items.RemoveAt(oAEliminar(i).ToString)
            Next

            ddlReporte_SelectedIndexChanged(ddlReporte, New System.EventArgs)

            If (DdlFormato.Items.Count <= 0) Then
                Dim datRep As Data.DataTable = ins.EjecutarConsulta("SELECT VAD.VAVClave, VAD.Descripcion FROM VAVDescripcion VAD INNER JOIN VARValor VAV ON VAV.VARCodigo=VAD.VARCodigo AND VAV.VAVClave=VAD.VAVClave AND VAV.Estado=1 WHERE VAD.VARCodigo = 'FormatPR' and VAD.VAVClave <> 0 and VAD.VADTipoLenguaje ='" + Session("lenguaje") + "' order by (convert(int,VAD.VAVClave)) ")

                'For i As Integer = 0 To datRep.Rows.Count - 1
                '    ddlReporte.Items.Add(datRep.Rows(i)(0).ToString)


                'Next
                datRep.TableName = "Formatos"
                DdlFormato.DataTextField = "Descripcion"
                DdlFormato.DataValueField = "VAVClave"
                DdlFormato.DataSource = datRep
                DdlFormato.DataMember = "Formatos"
                DdlFormato.DataBind()
                'UpdatePanel2.Update()
            End If

            If (DdlCentroDistribucion.Items.Count <= 0) Then

                Dim datRep As Data.DataTable = ins.EjecutarConsulta("select clave+' '+nombre as texto,clave from almacen where tipo =1")

                'For i As Integer = 0 To datRep.Rows.Count - 1
                '    ddlReporte.Items.Add(datRep.Rows(i)(0).ToString)


                'Next
                datRep.TableName = "Centros"
                DdlCentroDistribucion.DataTextField = "texto"
                DdlCentroDistribucion.DataValueField = "clave"
                DdlCentroDistribucion.DataSource = datRep
                DdlCentroDistribucion.DataMember = "Centros"
                DdlCentroDistribucion.DataBind()

            End If

            'obtener vendedores ... en ddlVendedor ...
            LlenarVendedor()
            'If (ddlVendedor.Items.Count <= 0) Then
            '    Dim datVen As Data.DataTable = ins.EjecutarConsulta("SELECT [VendedorId],[Nombre] FROM [Vendedor] ORDER BY [Nombre]")
            '    For i As Integer = 0 To datVen.Rows.Count - 1
            '        Dim lsItem As New System.Web.UI.WebControls.ListItem
            '        lsItem.Value = datVen.Rows(i)(0).ToString
            '        lsItem.Text = datVen.Rows(i)(1).ToString
            '        'ddlVendedor.Items.Add(datVen.Rows(i)(0).ToString)
            '        ddlVendedor.Items.Add(lsItem)
            '    Next
            'End If

            'obtener operaciones .... en ddlFecha
            If (ddlFecha.Items.Count <= 0) Then
                Dim datFec As Data.DataTable = ins.EjecutarConsulta("SELECT [Descripcion] FROM [VAVDescripcion] WHERE [VARCodigo] ='BFNUMERI' AND [VADTipoLenguaje] = '" + Session("lenguaje") + "'")
                For i As Integer = 0 To datFec.Rows.Count - 1
                    ddlFecha.Items.Add(datFec.Rows(i)(0).ToString)
                Next
            End If


            If (ddlFecha.Items.Count <= 0) Then
                Dim datFec As Data.DataTable = ins.EjecutarConsulta("SELECT [Descripcion] FROM [VAVDescripcion] WHERE [VARCodigo] ='BFNUMERI' AND [VADTipoLenguaje] = '" + Session("lenguaje") + "'")
                For i As Integer = 0 To datFec.Rows.Count - 1
                    ddlFecha.Items.Add(datFec.Rows(i)(0).ToString)
                Next
            End If

            Dim Dt As Data.DataTable = ins.EjecutarConsulta("Select RutClave,Descripcion from Ruta ", "Ruta")
            Session("tblRutas") = Dt

            'Me.GridView1.DataSource = Dt
            'Me.GridView1.DataBind()

            GridEXRuta.DataSource = Dt
            GridEXRuta.DataBind()

            '--- llenar el treeview --------------------

            Dim dat As Data.DataTable = ins.EjecutarConsulta("Select Nombre, EsquemaID From Esquema where EsquemaIDPadre is null and tipo =1 ", "Esquema")
            Dim nodoTodos As New TreeNode(mensaje.RecuperarDescripcion("Xtodos"))

            For i As Integer = 0 To dat.Rows.Count - 1
                Dim nodoPadre As New TreeNode()
                nodoPadre.Text = dat.Rows(i)(0).ToString()
                nodoPadre.Value = dat.Rows(i)(1).ToString()
                'llamar a la funcion para obtener a los hijos...
                nodoPadre = ChildTree(nodoPadre, dat, i)
                nodoTodos.ChildNodes.Add(nodoPadre)

            Next
            tvEsquema.Nodes.Add(nodoTodos)

            'CConexion.chkConexion()
            tvEsquema.Nodes(0).Select()
            tvEsquema_SelectedNodeChanged(tvEsquema, New System.EventArgs)

            UpdatePanel8.Update()

            '--- llenar Grid de Productos ---
            dat = New Data.DataTable
            dat = ins.EjecutarConsulta("SELECT EsquemaId, Clave, Nombre FROM Esquema where tipoestado=1 and tipo=2")
            'dat = ins.EjecutarConsulta("SELECT EsquemaId, Clave, Nombre FROM Esquema where tipoestado=1 and tipo=1")
            Session("tblProductos") = dat
            GridEXProducto.DataSource = dat
            GridEXProducto.DataBind()

            UpdatePanel10.Update()
            'GridEXProducto.UnCheckAllRecords()

            '--- Llenar Grid de Activos ---
            dat = New Data.DataTable
            dat = ins.EjecutarConsulta("SELECT ActivoClave, IdElectronico FROM Activo")
            Session("tblActivos") = dat
            GridEXActivos.DataSource = dat
            GridEXActivos.DataBind()
            UpdatePanel11.Update()

            LlenarTreeViewEncuestas(ins)
        End If
        'GridEXCliente.visible = False
        If Not (Page.ClientScript.IsClientScriptBlockRegistered("hideCalendarScript")) Then
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "hideCalendarScript", "function hideCalendar(calExtender) { calExtender.hide();document.focus();}", True)
        End If
    End Sub

    Public Sub LlenarTreeViewEncuestas(ByRef oCnn As DBConexion.cConexionSQL)

        Dim dtTipoEncuesta As DataTable = oCnn.EjecutarConsulta("SELECT VAVClave, Descripcion FROM VAVDescripcion WHERE VARCodigo = 'TENC' AND VADTipoLenguaje = '" + Session("lenguaje") + "'")
        Dim dtEncuestas As DataTable
        For Each drTipo As DataRow In dtTipoEncuesta.Rows
            Dim oNodo As New TreeNode(drTipo("Descripcion"))
            dtEncuestas = oCnn.EjecutarConsulta("SELECT CENClave, Descripcion FROM ConfigEncuesta WHERE Tipo = " & drTipo("VAVClave"))
            For Each drEncuesta As DataRow In dtEncuestas.Rows
                Dim oNodoHijo As New TreeNode()
                oNodoHijo.Text = drEncuesta("CENClave") & "-" & drEncuesta("Descripcion")
                oNodoHijo.Value = drEncuesta("CENClave")
                oNodo.ChildNodes.Add(oNodoHijo)
            Next
            tvEncuesta.Nodes.Add(oNodo)
        Next

        tvEncuesta.ExpandAll()
        tvEncuesta.Nodes(0).Select()
        tvEncuesta_SelectedNodeChanged(tvEncuesta, New System.EventArgs)

        UpdatePanel12.Update()
    End Sub

    'Private Function ChildTreeEncuesta(ByVal root As TreeNode, ByVal datTemp As Data.DataTable, ByVal ind As Integer) As TreeNode
    '    Dim dat As Data.DataTable = oEsquema.TablaNodo.Recuperar("EsquemaIDPadre = '" & datTemp.Rows(ind)(1).ToString() & "' and tipo = 1", "Nombre, EsquemaID")
    '    For i As Integer = 0 To dat.Rows.Count - 1
    '        Dim child As New TreeNode()
    '        child.Text = dat.Rows(i)(0).ToString()
    '        child.Value = dat.Rows(i)(1).ToString()
    '        Try
    '            child = ChildTree(oEsquema, child, dat, i)
    '        Catch ex As Exception

    '        End Try
    '        root.ChildNodes.Add(child)
    '    Next
    '    Return root
    'End Function

    Public Function EsquemaRecuperarTreeDataSet() As DataSet
        Dim vlds As New DataSet
        Dim vlmaxEsquemas As Integer

        Dim vldr As DataRelation
        Dim ins As New DBConexion.cConexionSQL
        Dim strSQL As String = " Select * from Esquema where Tipo=1"
        Dim TblInicial As New DataTable
        TblInicial = ins.EjecutarConsulta(strSQL)
        TblInicial.TableName = "EsquemaRaiz"
        vlds.Tables.Add(TblInicial)


        Dim Tbl As New DataTable
        Dim str As New Text.StringBuilder
        str.AppendLine("Select * from Esquema where Tipo=1")
        Tbl = ins.EjecutarConsulta(str.ToString)
        Tbl.TableName = "CentroExp" & 0
        vlds.Tables.Add(Tbl)

        vldr = New DataRelation("SubCentroExp" & 0, vlds.Tables(0).Columns("EsquemaID"), vlds.Tables(1).Columns("EsquemaIDPadre"), False)
        vlds.Relations.Add(vldr)

        Session("MaxEsquemas") = vlmaxEsquemas
        Return vlds
    End Function
    Protected Sub ddlReporte_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Habilitar o Deshabilitar chboxDetallado o chboxGeneral
        If lbError.Text <> "" Then
            lbError.Text = ""
            UpdatePanel6.Update()
        End If

        chboxDetallado.Visible = False
        chboxGeneral.Visible = False
        chboxAsignados.Visible = False
        chboxNoAsignados.Visible = False
        chboxPorFiltro.Visible = False

        If ddlReporte.SelectedValue = 40 Then
            chboxAsignados.Visible = True
            chboxNoAsignados.Visible = True
            chboxPorFiltro.Visible = True

            If chboxAsignados.Checked = False And chboxNoAsignados.Checked = False And chboxPorFiltro.Checked = False Then
                chboxAsignados.Checked = True
                chboxDetallado.Checked = False
                chboxGeneral.Checked = False
            End If
        ElseIf (ddlReporte.SelectedValue <= 3 OrElse ddlReporte.SelectedValue = 37 OrElse ddlReporte.SelectedValue = 14 OrElse ddlReporte.SelectedValue = 20 OrElse ddlReporte.SelectedValue = 21 OrElse ddlReporte.SelectedValue = 24 OrElse ddlReporte.SelectedValue = 25 OrElse ddlReporte.SelectedValue = 38 OrElse ddlReporte.SelectedValue = 45 OrElse ddlReporte.SelectedValue = 47) Then
            chboxDetallado.Visible = True
            chboxGeneral.Visible = True

            If chboxDetallado.Checked = False And chboxGeneral.Checked = False Then
                chboxDetallado.Checked = True
                chboxAsignados.Checked = False
                chboxNoAsignados.Checked = False
                chboxPorFiltro.Checked = False
            End If
        End If

        UpdatePanel2.Update()
        'Deshabilitar ddlVendedor y centros si selecciona Configuracion de premios
        If (ddlReporte.SelectedValue = 7 OrElse ddlReporte.SelectedValue = 8 OrElse ddlReporte.SelectedValue = 10 OrElse ddlReporte.SelectedValue = 22 OrElse ddlReporte.SelectedValue = 24 OrElse ddlReporte.SelectedValue = 28 OrElse ddlReporte.SelectedValue = 29 OrElse ddlReporte.SelectedValue = 30 OrElse ddlReporte.SelectedValue = 51 OrElse ddlReporte.SelectedValue = 52 OrElse ddlReporte.SelectedValue = 55 OrElse ddlReporte.SelectedValue = 56 OrElse ddlReporte.SelectedValue = 53 OrElse ddlReporte.SelectedValue = 107 OrElse (ddlReporte.SelectedValue = 40 And (chboxNoAsignados.Checked = True Or chboxPorFiltro.Checked = True)) OrElse ddlReporte.SelectedValue = 57) Then

            If ChBoxCentroDistribucion.Visible Or PanelCentroDistribucion.Visible Then
                ChBoxCentroDistribucion.Visible = False
                PanelCentroDistribucion.Visible = False
                UpdatePanel7.Update()
            End If
            If PanelVendedor.Visible Or chboxVendedor.Visible Or chboxVendedor.Checked Then
                PanelVendedor.Visible = False
                chBoxVendedorActivo.Enabled = False
                chBoxVendedorActivo.Checked = False
                chboxVendedor.Visible = False
                chboxVendedor.Checked = False
                UpdatePanel3.Update()
            End If



        ElseIf (ddlReporte.SelectedValue = 26 Or ddlReporte.SelectedValue = 25 Or ddlReporte.SelectedValue = 33 Or ddlReporte.SelectedValue = Reporte.TiemposEnRutaSuKarne) Then
            If chboxVendedor.Visible = False Or PanelVendedor.Visible = False Or chboxVendedor.Enabled Or chboxVendedor.Checked = False Then
                chboxVendedor.Checked = True
                chboxVendedor.Visible = True
                chboxVendedor.Enabled = False
                chBoxVendedorActivo.Enabled = True
                PanelVendedor.Visible = True
                UpdatePanel3.Update()
            End If

        Else
            If chboxVendedor.Visible = False Or chboxVendedor.Enabled = False Or chboxVendedor.Checked Or PanelVendedor.Visible Then
                chboxVendedor.Enabled = True
                chboxVendedor.Checked = True
                chboxVendedor.Visible = True
                chBoxVendedorActivo.Enabled = True
                PanelVendedor.Visible = True
                UpdatePanel3.Update()
            End If
        End If

        'Centro de distribucion
        If (ddlReporte.SelectedValue = 8 OrElse ddlReporte.SelectedValue = 36 OrElse ddlReporte.SelectedValue = 49 OrElse ddlReporte.SelectedValue = 51 OrElse ddlReporte.SelectedValue = 52 OrElse ddlReporte.SelectedValue = 53 OrElse (ddlReporte.SelectedValue = 40 And (chboxNoAsignados.Checked = True Or chboxPorFiltro.Checked = True))) Then
            If ChBoxCentroDistribucion.Visible Or ChBoxCentroDistribucion.Checked Or PanelCentroDistribucion.Visible Then
                ChBoxCentroDistribucion.Visible = False
                ChBoxCentroDistribucion.Checked = False
                PanelCentroDistribucion.Visible = False
                UpdatePanel7.Update()
            End If
        ElseIf (ddlReporte.SelectedValue = 28 OrElse ddlReporte.SelectedValue = 29 OrElse ddlReporte.SelectedValue = 30 OrElse ddlReporte.SelectedValue = 55 OrElse ddlReporte.SelectedValue = 56 OrElse ddlReporte.SelectedValue = 107) Then
            If ChBoxCentroDistribucion.Enabled Or ChBoxCentroDistribucion.Visible = False Or ChBoxCentroDistribucion.Checked = False Or PanelCentroDistribucion.Visible = False Then
                ChBoxCentroDistribucion.Visible = True
                ChBoxCentroDistribucion.Enabled = False
                ChBoxCentroDistribucion.Checked = True
                PanelCentroDistribucion.Visible = True
                UpdatePanel7.Update()
            End If
        Else
            If ChBoxCentroDistribucion.Enabled = False Or ChBoxCentroDistribucion.Visible = False Or ChBoxCentroDistribucion.Checked Or PanelCentroDistribucion.Visible Then
                ChBoxCentroDistribucion.Visible = True
                ChBoxCentroDistribucion.Checked = False
                PanelCentroDistribucion.Visible = False
                ChBoxCentroDistribucion.Enabled = True
                UpdatePanel7.Update()
            End If
        End If

        'Habilitar Fecha .....
        'txtFInicio.Visible = False
        If (ddlReporte.SelectedValue = 7 OrElse ddlReporte.SelectedValue = 40 OrElse ddlReporte.SelectedValue = 54 OrElse ddlReporte.SelectedValue = 107) Then
            If chboxFecha.Checked Or chboxFecha.Visible Or ddlFecha.Visible Or txtFInicio.Visible Or txtFFinal.Visible Or txtFFinal.Visible Then
                chboxFecha.Checked = False
                chboxFecha.Visible = False
                ddlFecha.Visible = False
                txtFInicio.Visible = False
                txtFFinal.Visible = False
                Label4.Visible = chboxFecha.Visible
                UpdatePanel4.Update()
            End If
        ElseIf ddlReporte.SelectedValue = 39 OrElse ddlReporte.SelectedValue = 50 OrElse ddlReporte.SelectedValue = 59 OrElse ddlReporte.SelectedValue = 48 Then
            If ddlFecha.SelectedIndex <> 0 Or ddlFecha.Visible = False Or txtFInicio.Visible = False Or txtFFinal.Visible Or chboxFecha.Visible Or chboxFecha.Checked = False Or chboxFecha.Enabled Or ddlFecha.Enabled = True Then
                ddlFecha.SelectedIndex = 0
                ddlFecha.Visible = True
                ddlFecha.Enabled = False
                txtFInicio.Visible = True
                txtFFinal.Visible = False
                chboxFecha.Visible = True
                chboxFecha.Enabled = False
                chboxFecha.Checked = True
                Label4.Visible = chboxFecha.Visible
                UpdatePanel4.Update()
            End If
        ElseIf ddlReporte.SelectedValue = 56 Then
            chboxFecha.Visible = True
            chboxFecha.Checked = True
            chboxFecha.Enabled = False
            ddlFecha.Visible = True
            ddlFecha.SelectedIndex = 0
            ddlFecha.Enabled = False
            txtFInicio.Visible = True
            txtFInicio.Enabled = True
            txtFFinal.Visible = False
            txtFFinal.Enabled = False
            UpdatePanel4.Update()
            'UpdatePanel6.Update()
        ElseIf ddlReporte.SelectedValue = 24 Then
            chboxFecha.Visible = True
            chboxFecha.Checked = False
            chboxFecha.Enabled = True
            ddlFecha.Visible = True
            ddlFecha.SelectedIndex = 0
            ddlFecha.Enabled = False
            txtFInicio.Visible = True
            txtFInicio.Enabled = False
            txtFFinal.Visible = False
            txtFFinal.Enabled = False
            UpdatePanel4.Update()
            'UpdatePanel6.Update()
        ElseIf ddlReporte.SelectedValue = 60 Or ddlReporte.SelectedValue = 62 Then
            If ddlFecha.SelectedIndex <> 0 Or ddlFecha.Visible = False Or txtFInicio.Visible = False Or txtFFinal.Visible Or chboxFecha.Visible = False Or chboxFecha.Checked Or chboxFecha.Enabled = False Or ddlFecha.Enabled = True Then
                chboxFecha.Visible = True
                chboxFecha.Enabled = True
                chboxFecha.Checked = True
                ddlFecha.SelectedIndex = 0
                ddlFecha.Visible = True
                ddlFecha.Enabled = False
                txtFInicio.Visible = True
                txtFFinal.Visible = False
                Label4.Visible = chboxFecha.Visible
                UpdatePanel4.Update()
            End If
            If ddlReporte.SelectedValue = 62 Then
                chboxFecha.Enabled = False
            End If
        ElseIf ddlReporte.SelectedValue = 44 Or ddlReporte.SelectedValue = 55 Then
            ' Validacion para el reporte 44 Ventas con Saldos            
            Dim item As System.Web.UI.WebControls.ListItem = ddlFecha.Items.FindByValue("igual")

            If chboxFecha.Enabled = True Or ddlFecha.SelectedIndex <> 0 Or txtFInicio.Visible = False Or ddlFecha.Visible = False Or chboxFecha.Checked = False Or chboxFecha.Visible = False Or chboxFecha.Enabled = False Or ddlFecha.Enabled = True Then
                ddlFecha.SelectedIndex = 0
                ddlFecha_SelectedIndexChanged(ddlFecha, New System.EventArgs)
                txtFInicio.Visible = True
                ddlFecha.Visible = True
                ddlFecha.Enabled = False
                chboxFecha.Checked = True
                chboxFecha.Visible = True
                chboxFecha.Enabled = False
                Label4.Visible = chboxFecha.Visible
                UpdatePanel4.Update()
            End If

        ElseIf ddlReporte.SelectedValue = 48 Then 'Liquidacion DISPOSUR y Modelo
            If txtFInicio.Text <> Date.Today.ToString("dd/MM/yyyy") Or ddlFecha.SelectedIndex <> 0 Or ddlFecha.Visible = False Or txtFInicio.Visible = False Or txtFFinal.Visible Or chboxFecha.Visible = False Or chboxFecha.Checked = False Or chboxFecha.Enabled Or ddlFecha.Enabled = False Then
                ddlFecha.SelectedIndex = 0
                ddlFecha.Visible = True
                ddlFecha.Enabled = True
                txtFInicio.Visible = True
                txtFInicio.Text = Date.Today.ToString("dd/MM/yyyy")
                txtFFinal.Visible = False
                chboxFecha.Visible = True
                chboxFecha.Enabled = False
                chboxFecha.Checked = True
                Label4.Visible = chboxFecha.Visible
                UpdatePanel4.Update()
            End If
        Else
            If chboxFecha.Visible = False Or chboxFecha.Checked = False Then
                chboxFecha.Visible = True
                chboxFecha.Checked = True
                UpdatePanel4.Update()
            End If

            If (chboxFecha.Checked = True) Then
                If ddlReporte.SelectedValue = 26 OrElse ddlReporte.SelectedValue = 25 OrElse ddlReporte.SelectedValue = 8 Then
                    If ddlFecha.SelectedIndex <> 6 Or ddlFecha.Visible = False Or txtFInicio.Visible = False Or txtFFinal.Visible = False Or chboxFecha.Enabled = False Or ddlFecha.Enabled = True Or chboxFecha.Checked = False Then
                        ddlFecha.SelectedIndex = 6
                        ddlFecha.Visible = True
                        ddlFecha.Enabled = False
                        txtFInicio.Visible = True
                        txtFFinal.Visible = True
                        txtFInicio.Enabled = True
                        chboxFecha.Enabled = True
                        chboxFecha.Checked = True
                        Label4.Visible = chboxFecha.Visible
                        UpdatePanel4.Update()
                    End If
                Else
                    If ddlFecha.SelectedIndex = 6 Then
                        If chboxFecha.Checked = False Or txtFFinal.Visible = False Or ddlFecha.Visible = False Or txtFInicio.Visible = False Or chboxFecha.Enabled = False Or ddlFecha.Enabled = False Or chboxFecha.Checked = False Then
                            txtFFinal.Visible = True
                            ddlFecha.Visible = True
                            chboxFecha.Checked = True
                            ddlFecha.Enabled = True
                            txtFInicio.Visible = True
                            txtFInicio.Enabled = True
                            chboxFecha.Enabled = True
                            Label4.Visible = chboxFecha.Visible
                            UpdatePanel4.Update()
                        End If
                    Else
                        If chboxFecha.Checked = False Or txtFFinal.Visible Or ddlFecha.Visible = False Or txtFInicio.Visible = False Or chboxFecha.Enabled = False Or ddlFecha.Enabled = False Or chboxFecha.Checked = False Then
                            txtFFinal.Visible = False
                            chboxFecha.Checked = True
                            ddlFecha.Visible = True
                            ddlFecha.Enabled = True
                            txtFInicio.Visible = True
                            txtFInicio.Enabled = True
                            chboxFecha.Enabled = True
                            Label4.Visible = chboxFecha.Visible
                            UpdatePanel4.Update()
                        End If
                    End If

                End If


            End If

        End If


        'Habilitar Ruta .......
        If (ddlReporte.SelectedValue = 7 OrElse ddlReporte.SelectedValue = 4 OrElse ddlReporte.SelectedValue = 8 Or ddlReporte.SelectedValue = 10 Or ddlReporte.SelectedValue = 18 Or ddlReporte.SelectedValue = 19 Or ddlReporte.SelectedValue = 20 OrElse ddlReporte.SelectedValue = 22 OrElse ddlReporte.SelectedValue = 24 OrElse ddlReporte.SelectedValue = 26 OrElse ddlReporte.SelectedValue = 27 OrElse ddlReporte.SelectedValue = 28 OrElse ddlReporte.SelectedValue = 35 OrElse ddlReporte.SelectedValue = 39 OrElse (ddlReporte.SelectedValue = 40 And (chboxNoAsignados.Checked = True Or chboxPorFiltro.Checked = True)) OrElse ddlReporte.SelectedValue = 42 OrElse ddlReporte.SelectedValue = 43 OrElse ddlReporte.SelectedValue = 44 OrElse ddlReporte.SelectedValue = 47 OrElse ddlReporte.SelectedValue = 48 OrElse ddlReporte.SelectedValue = 50 OrElse ddlReporte.SelectedValue = 55 OrElse ddlReporte.SelectedValue = 56 OrElse ddlReporte.SelectedValue = 57 OrElse ddlReporte.SelectedValue = 60 OrElse ddlReporte.SelectedValue = 62 OrElse ddlReporte.SelectedValue = Reporte.TiemposEnRutaSuKarne OrElse ddlReporte.SelectedValue = 107) Then
            If chboxRuta.Visible Or GridEXRuta.Visible Then
                chboxRuta.Visible = False
                GridEXRuta.Visible = False
                UpdatePanel5.Update()
            End If
        Else
            If chboxRuta.Visible = False Or (GridEXRuta.Visible = False And chboxRuta.Checked = True) Then
                chboxRuta.Visible = True
                If (chboxRuta.Checked = True) Then
                    GridEXRuta.Visible = True
                End If
                UpdatePanel5.Update()
            End If
        End If

        'Habilitar Clientes...
        If (ddlReporte.SelectedValue = 46 Or ddlReporte.SelectedValue = 45 Or ddlReporte.SelectedValue = 38 Or ddlReporte.SelectedValue = 30 Or ddlReporte.SelectedValue = 23 Or ddlReporte.SelectedValue = 3 Or ddlReporte.SelectedValue = 4 Or ddlReporte.SelectedValue = 8 Or ddlReporte.SelectedValue = 9 Or ddlReporte.SelectedValue = 14 Or ddlReporte.SelectedValue = 18 Or ddlReporte.SelectedValue = 19 Or ddlReporte.SelectedValue = 16 Or ddlReporte.SelectedValue = 20 Or ddlReporte.SelectedValue = 22 Or ddlReporte.SelectedValue = 24 Or ddlReporte.SelectedValue = 25 Or ddlReporte.SelectedValue = 26 Or ddlReporte.SelectedValue = 28 Or ddlReporte.SelectedValue = 29 Or ddlReporte.SelectedValue = 31 Or ddlReporte.SelectedValue = 33 Or ddlReporte.SelectedValue = 32 Or ddlReporte.SelectedValue = 34 Or ddlReporte.SelectedValue = 35 Or ddlReporte.SelectedValue = 36 OrElse ddlReporte.SelectedValue = 39 OrElse (ddlReporte.SelectedValue = 40 And (chboxNoAsignados.Checked = True Or chboxPorFiltro.Checked = True)) OrElse ddlReporte.SelectedValue = 42 OrElse ddlReporte.SelectedValue = 43 OrElse ddlReporte.SelectedValue = 48 OrElse ddlReporte.SelectedValue = 50 OrElse ddlReporte.SelectedValue = 51 OrElse ddlReporte.SelectedValue = 52 OrElse ddlReporte.SelectedValue = 53 OrElse ddlReporte.SelectedValue = 54 OrElse ddlReporte.SelectedValue = 55 OrElse ddlReporte.SelectedValue = 56 OrElse ddlReporte.SelectedValue = 57 OrElse ddlReporte.SelectedValue = 60 OrElse ddlReporte.SelectedValue = 62 OrElse ddlReporte.SelectedValue = Reporte.TiemposEnRutaSuKarne OrElse ddlReporte.SelectedValue = 107) Then
            If Pnlclientes.Visible Then
                Pnlclientes.Visible = False
                UpdatePanel8.Update()
            End If
            If PanelEsquemas.Visible Or Label1.Visible Then
                PanelEsquemas.Visible = False

                Label1.Visible = False
                UpdatePanel1.Update()
            End If
        ElseIf ddlReporte.SelectedValue = 58 Then
            If Pnlclientes.Visible = True Then
                Pnlclientes.Visible = False
                UpdatePanel8.Update()
            End If
            If PanelEsquemas.Visible = False Or Label1.Visible = False Then
                PanelEsquemas.Visible = True
                Label1.Visible = True
                UpdatePanel1.Update()
            End If
        Else
            If Pnlclientes.Visible = False Then
                Pnlclientes.Visible = True
                UpdatePanel8.Update()
            End If
            If PanelEsquemas.Visible = False Or Label1.Visible = False Then
                PanelEsquemas.Visible = True
                Label1.Visible = True
                UpdatePanel1.Update()
            End If

        End If

        'Habilitar Activos
        If ddlReporte.SelectedValue = 40 And chboxPorFiltro.Checked = True Then
            If Label7.Visible = False Or GridEXActivos.Visible = False Then
                Label7.Visible = True
                GridEXActivos.Visible = True
                UpdatePanel11.Update()
            End If
        Else
            If Label7.Visible Or GridEXActivos.Visible Then
                Label7.Visible = False
                GridEXActivos.Visible = False
                UpdatePanel11.Update()
            End If
        End If

        'Habilita Esquemas por Producto
        If (ddlReporte.SelectedValue = 30 OrElse ddlReporte.SelectedValue = 54) Then
            If GridEXProducto.Visible = False Or Label5.Visible = False Then
                GridEXProducto.Visible = True
                Label5.Visible = True
                UpdatePanel10.Update()
            End If
        Else
            If GridEXProducto.Visible Or Label5.Visible Then
                GridEXProducto.Visible = False
                Label5.Visible = False
                UpdatePanel10.Update()
            End If
        End If

        'Habilitar Valores Reporte
        If (ddlReporte.SelectedValue = 26 Or ddlReporte.SelectedValue = 35) Then
            If PanelLiquidacion.Visible = False Then
                PanelLiquidacion.Visible = True
                UpdatePanel9.Update()
            End If
        Else
            If PanelLiquidacion.Visible Then
                PanelLiquidacion.Visible = False
                UpdatePanel9.Update()
            End If
        End If

        'Habilitar encuestas
        If ddlReporte.SelectedValue = 51 Then
            PanelEncuestas.Visible = True
            UpdatePanel12.Update()
        Else
            If PanelEncuestas.Visible = True Then
                PanelEncuestas.Visible = False
                UpdatePanel12.Update()
            End If
        End If

        'If PanelEsquemas.Visible And Not IsNothing(tvEsquema.SelectedNode) Then
        '    tvEsquema_SelectedNodeChanged(tvEsquema, New System.EventArgs)
        'End If

        'If tvEsquema .Visible And Not IsNothing(tvEsquema .SelectedItems) Then
        'tvEsquema _SelectionChanged(tvEsquema , New System.EventArgs)
        'End If

        'Seleccionar formato
        If ddlReporte.SelectedValue = 51 Or ddlReporte.SelectedValue = 57 Or ddlReporte.SelectedValue = 58 Then
            If DdlFormato.Items.Count > 0 Then
                DdlFormato.Items(5).Enabled = True
            End If
            DdlFormato.SelectedValue = 7
            DdlFormato.Enabled = False
        ElseIf ddlReporte.SelectedValue = 52 Then
            DdlFormato.SelectedValue = 5
            DdlFormato.Enabled = False
        Else
            If DdlFormato.Items.Count > 0 Then
                DdlFormato.Items(5).Enabled = False
            End If
            DdlFormato.SelectedValue = 1
            DdlFormato.Enabled = True
        End If

    End Sub


    Protected Sub chboxFecha_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If lbError.Text <> "" Then
            lbError.Text = ""
            UpdatePanel6.Update()
        End If

        If (chboxFecha.Checked = True) Then
            ddlFecha.Visible = True
            txtFInicio.Visible = True
            txtFInicio.Enabled = True
            Label4.Visible = True
            If ddlReporte.SelectedValue = 25 OrElse ddlReporte.SelectedValue = 8 Then
                ddlFecha.SelectedIndex = 6
                ddlFecha.Enabled = False
            ElseIf ddlReporte.SelectedValue = 39 OrElse ddlReporte.SelectedValue = 60 OrElse ddlReporte.SelectedValue = 24 OrElse ddlReporte.SelectedValue = 62 Then
                ddlFecha.SelectedIndex = 0
                ddlFecha.Enabled = False
            End If

            If (ddlFecha.SelectedIndex = 6) Then
                txtFFinal.Visible = True
            Else
                txtFFinal.Visible = False
            End If
        Else
            ddlFecha.Visible = False
            txtFInicio.Visible = False
            txtFFinal.Visible = False
            Label4.Visible = False
        End If
        UpdatePanel4.Update()

    End Sub

    Protected Sub chboxRuta_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If lbError.Text <> "" Then
            lbError.Text = ""
            UpdatePanel6.Update()
        End If
        If (chboxRuta.Checked = True) Then
            'GridView1.visible = True
            'ChecktodasRutas.visible = True
            GridEXRuta.Visible = True
        Else
            'GridView1.visible = False
            'ChecktodasRutas.visible = False
            GridEXRuta.Visible = False
        End If
        'If PanelEsquemas.Visible And Not IsNothing(tvEsquema.SelectedNode) Then
        '    tvEsquema_SelectedNodeChanged(tvEsquema, New System.EventArgs)
        'End If
        'If PanelEsquemas.Visible And Not IsNothing(tvEsquema.SelectedItems) Then
        'tvEsquema(_SelectionChanged(tvEsquema, New System.EventArgs))
        'End If
        UpdatePanel5.Update()
        UpdatePanel1.Update()
    End Sub

    'Protected Sub chbTodosRuta_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    lbError.Text = ""
    '    Dim dt As Data.DataTable = Session("tblRutas")
    '    For i As Integer = 0 To dt.Rows.Count - 1
    '        dt.Rows(i)("checks") = ChecktodasRutas.Checked
    '    Next
    '    GridView1.DataSource = dt
    '    GridView1.DataBind()
    '    UpdatePanel5.Update()
    'End Sub

    'Protected Sub chbTodosCliente_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    lbError.Text = ""
    '    Dim dt As Data.DataTable = Session("tblClientes")
    '    For i As Integer = 0 To dt.Rows.Count - 1
    '        dt.Rows(i)("checks") = CheckTodosClientes.Checked
    '    Next
    '    GridView2.DataSource = dt
    '    GridView2.DataBind()
    '    UpdatePanel8.Update()
    'End Sub

    'Protected Sub chbTodosProductos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    lbError.Text = ""
    '    Dim dt As Data.DataTable = Session("tblProductos")
    '    For i As Integer = 0 To dt.Rows.Count - 1
    '        dt.Rows(i)("checks") = CheckTodosProductos.Checked
    '    Next
    '    GridView3.DataSource = dt
    '    GridView3.DataBind()
    '    'UpdatePanel8.Update()
    'End Sub



    'Protected Sub tvEsquema_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    'otra manera ...
    '    Dim ins As New dbconexion.cConexionSQL()
    '    ins.Conectar(ConfigurationManager.ConnectionStrings("ROUTEConnectionString").ConnectionString)

    '    Dim mensaje As New BASMENLOG.CMensaje(ins)
    '    mensaje.LlenarDataSet(Session("lenguaje"))

    '    mensaje.RecuperarDescripcion("XREPORTE")
    '    'GuardaChecksRutas()
    '    Dim dat As Data.DataTable
    '    Dim aRutas As ArrayList = GetRutas()
    '    Dim sRutas As String = ""
    '    If aRutas.Count > 0 Then
    '        For Each sRuta As String In aRutas
    '            If sRutas = "" Then
    '                sRutas = "'" & sRuta & "'"
    '            Else
    '                sRutas = sRutas & ",'" & sRuta & "'"
    '            End If
    '        Next
    '    End If

    '    If (tvEsquema.SelectedNode.Text = mensaje.RecuperarDescripcion("XTodos")) Then
    '        If aRutas.Count > 0 Then
    '            dat = ins.EjecutarConsulta("SELECT distinct c.ClienteClave,c.Clave,C.RazonSocial  FROM Cliente C inner join ClienteEsquema D on C.ClienteClave = D.ClienteClave inner join esquema E on D.EsquemaID = E.EsquemaID and E.tipo=1 inner join Secuencia S on S.ClienteClave=C.ClienteClave AND S.RUTClave IN (" & sRutas & ")")
    '        Else
    '            dat = ins.EjecutarConsulta("SELECT distinct c.ClienteClave,c.Clave,C.RazonSocial  FROM Cliente C inner join ClienteEsquema D on C.ClienteClave = D.ClienteClave inner join esquema E on D.EsquemaID = E.EsquemaID and E.tipo=1")
    '        End If
    '    Else
    '        If aRutas.Count > 0 Then
    '            dat = ins.EjecutarConsulta("SELECT distinct c.ClienteClave,c.Clave,C.RazonSocial FROM Cliente C inner join ClienteEsquema D on C.ClienteClave = D.ClienteClave inner join esquema E on D.EsquemaID = E.EsquemaID and E.tipo=1 inner join Secuencia S on S.ClienteClave=C.ClienteClave AND S.RUTClave IN (" & sRutas & ") WHERE E.EsquemaID ='" & tvEsquema.SelectedNode.Value & "'")
    '        Else
    '            dat = ins.EjecutarConsulta("SELECT distinct c.ClienteClave,c.Clave,C.RazonSocial FROM Cliente C inner join ClienteEsquema D on C.ClienteClave = D.ClienteClave inner join esquema E on D.EsquemaID = E.EsquemaID and E.tipo=1 WHERE E.EsquemaID ='" & tvEsquema.SelectedNode.Value & "'")
    '        End If
    '    End If
    '    'dat.Columns.Add(New Data.DataColumn("checks", GetType(Boolean)))
    '    Session("tblClientes") = dat
    '    'GridView2.Columns(2).HeaderText = mensaje.RecuperarDescripcion("Xcliente")
    '    'GridView2.PageIndex = 0
    '    'GridView2.DataSource = dat
    '    'GridView2.DataBind()
    '    If (dat.Rows.Count > 0) Then
    '        GridEXCliente.visible = True
    '        Label3.visible = True
    '    Else
    '        GridEXCliente.visible = False
    '        Label3.visible = False
    '    End If
    '    GridEXCliente.DataSource = dat
    '    GridEXCliente.DataBind()
    '    UpdatePanel8.Update()
    '    If dat.Rows.Count = 0 Then
    '        Dim strError As String = ins.EjecutarComandoScalar("SELECT Descripcion from mendetalle where menclave = 'E0485' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
    '        lbError.Text = strError
    '        'CheckTodosClientes.Visible = False
    '    Else
    '        lbError.Text = String.Empty
    '        'CheckTodosClientes.Visible = True
    '        'CheckTodosClientes.Checked = False
    '    End If
    '    ins.Desconectar()
    '    'UpdatePanel8.Update()
    '    UpdatePanel9.Update()
    '    UpdatePanel1.Update()
    'End Sub

    Protected Sub ddlFecha_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If lbError.Text <> "" Then
            lbError.Text = ""
            UpdatePanel6.Update()
        End If
        If (ddlFecha.SelectedIndex = 6) Then
            txtFFinal.Enabled = True
            txtFFinal.Visible = True
            UpdatePanel4.Update()
        Else
            If txtFFinal.Visible = True Then
                txtFFinal.Visible = False
                UpdatePanel4.Update()
            End If
        End If
    End Sub

    Protected Sub chboxVendedor_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If (chboxVendedor.Checked) Then
            Me.chBoxVendedorActivo.Checked = False
            PanelVendedor.Visible = True
        Else
            PanelVendedor.Visible = False
        End If
        UpdatePanel3.Update()
        If lbError.Text <> "" Then
            lbError.Text = ""
            UpdatePanel6.Update()
        End If
    End Sub
    Protected Sub chboxVendedorActivo_checkedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LlenarVendedor()
    End Sub
    Private Sub LlenarVendedor()
        Dim ins As New DBConexion.cConexionSQL
        
        If (ddlVendedor.Items.Count > 0) Then
            ddlVendedor.Controls.Clear()
            ddlVendedor.Items.Clear()
        End If

        Dim condicion As String = " where TipoEstado = 1 "
        If Me.chBoxVendedorActivo.Checked Then condicion = ""

        Dim datVen As Data.DataTable = ins.EjecutarConsulta("SELECT [VendedorId],[Nombre] FROM [Vendedor] " & condicion & " ORDER BY [Nombre]")
        For i As Integer = 0 To datVen.Rows.Count - 1
            Dim lsItem As New System.Web.UI.WebControls.ListItem
            lsItem.Value = datVen.Rows(i)(0).ToString
            lsItem.Text = datVen.Rows(i)(1).ToString
            'ddlVendedor.Items.Add(datVen.Rows(i)(0).ToString)
            ddlVendedor.Items.Add(lsItem)
        Next

        UpdatePanel3.Update()
    End Sub
    Protected Sub chboxDetallado_CheckedChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        If lbError.Text <> "" Then
            lbError.Text = ""
            UpdatePanel6.Update()
        End If
        If Not chboxDetallado.Checked And Not chboxGeneral.Checked Then
            chboxGeneral.Checked = True
            UpdatePanel2.Update()
        End If
    End Sub

    Protected Sub chboxGeneral_CheckedChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        If lbError.Text <> "" Then
            lbError.Text = ""
            UpdatePanel6.Update()
        End If
        If Not chboxGeneral.Checked And Not chboxDetallado.Checked Then
            chboxDetallado.Checked = True
            UpdatePanel2.Update()
        End If
    End Sub


    Protected Sub ddlVendedor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If lbError.Text <> "" Then
            lbError.Text = ""
            UpdatePanel6.Update()
        End If
    End Sub

    Protected Sub txtFInicio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If lbError.Text <> "" Then
            lbError.Text = ""
            UpdatePanel6.Update()
        End If
    End Sub

    Protected Sub txtFFinal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If lbError.Text <> "" Then
            lbError.Text = ""
            UpdatePanel6.Update()
        End If
    End Sub

    Protected Sub ChBoxCentroDistribucion_CheckedChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        If lbError.Text <> "" Then
            lbError.Text = ""
            UpdatePanel6.Update()
        End If
        If (ChBoxCentroDistribucion.Checked) Then
            PanelCentroDistribucion.Visible = True
        Else
            PanelCentroDistribucion.Visible = False
        End If
        UpdatePanel7.Update()
    End Sub

    Protected Sub btnContinuar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Session("bloqueado") Then

            'GuardaChecksRutas()
            'GuardaChecksClientes()
            'GuardaChecksProductos()

            Dim ins As New DBConexion.cConexionSQL
            Dim oMensaje As New DBConexion.cMensaje
            Dim sReporte As String = ddlReporte.Text
            Dim sVendedor As String = ddlVendedor.Text
            Dim aRutas As ArrayList = GetRutas()
            Dim aClientes As ArrayList = GetClientes()
            Dim aActivos As ArrayList = GetActivos()
            Dim aProductos As ArrayList = GetProductos()
            Dim aProductosClave As ArrayList = GetClaveProductos()
            Dim bCorrecto As Boolean = True
            Dim sCondicion As String

            lbError.Text = ""
            Session("Nombre") = ddlReporte.SelectedItem.Text
            Session("Formato") = DdlFormato.SelectedValue
            If chboxVendedor.Checked Then
                'sCondicion = "where VEN.Nombre = '" + sVendedor + "'"
                sCondicion = "where VEN.VendedorId = '" + sVendedor + "'"
            Else
                sCondicion = "where 1 = 1 "
            End If

            If Not CheckFechasFormato(ins) Then
                Session("bloqueado") = False
                GoTo terminar
            End If
            If ddlReporte.SelectedValue <> 18 Then
                If Not CheckFechas() Then
                    Session("bloqueado") = False
                    GoTo terminar
                End If

            End If

            '''''filtros
            ' ''*****************************************************
            If (chboxFecha.Checked) Then
                Session("RangoFechas") = ObtenerRangoFechas()
            Else
                Session("RangoFechas") = ""
            End If
            If (chboxVendedor.Checked) Then
                Session("Vendedor") = ddlVendedor.SelectedItem.Text
                Session("VendedorId") = ddlVendedor.SelectedItem.Value
            Else
                Session("Vendedor") = ""
                Session("VendedorId") = ""
            End If
            If (aRutas.Count > 0) Then
                Session("Ruta") = ""
                For Each sRuta As String In aRutas
                    If Session("Ruta") = "" Then
                        Session("Ruta") = sRuta
                    Else
                        Session("Ruta") = Session("Ruta") & "," & sRuta
                    End If
                Next
            Else
                Session("Ruta") = ""
            End If
            If (aProductos.Count > 0) Then
                Session("Producto") = ""
                For Each sProducto As String In aProductosClave
                    If Session("Producto") = "" Then
                        Session("Producto") = sProducto
                    Else
                        Session("Producto") = Session("Producto") & "," & sProducto
                    End If
                Next
            Else
                Session("Producto") = ""
            End If
            If Me.ChBoxCentroDistribucion.Checked Then
                Session("CEDI") = Me.DdlCentroDistribucion.SelectedItem.Text
            Else
                Session("CEDI") = ""
            End If

            ' ''*****************************************************

            Select Case ddlReporte.SelectedValue
                Case 1 'Facturas
                    If ConsultaFacturas(ins, chboxDetallado.Checked, sCondicion, aRutas, aClientes, chboxFecha.Checked) Then
                        Session("NumReporte") = 1
                        If (chboxDetallado.Checked) Then
                            Session("TipoReporte") = "Detallado"
                            Session("Nombre") += " " & oMensaje.RecuperarDescripcion("XDetallado")
                        ElseIf (chboxGeneral.Checked) Then
                            Session("TipoReporte") = "General"
                            Session("Nombre") += " " & oMensaje.RecuperarDescripcion("XGeneral")
                        Else
                            Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0493' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                            lbError.Text = strError

                            Session("bloqueado") = False
                            GoTo terminar
                        End If
                        'dtConsulta = ins.EjecutarConsulta(Session("Query"))
                        'dtConsulta = Session("DataTable")
                        'If (dtConsulta.Rows.Count > 0) Then
                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 2 'Pedidos
                    Session("ConversionKg") = ins.EjecutarConsulta("Select top 1 ConversionKg From ConHist Order By MFechaHora Desc").Rows(0)("ConversionKg")
                    If ConsultaPedidos(ins, chboxDetallado.Checked, Session("ConversionKg"), sCondicion, aRutas, aClientes, chboxFecha.Checked) Then
                        Session("NumReporte") = 2
                        If (chboxDetallado.Checked) Then
                            Session("TipoReporte") = "Detallado"
                            Session("Nombre") += " " & oMensaje.RecuperarDescripcion("XDetallado")
                        ElseIf (chboxGeneral.Checked) Then
                            Session("TipoReporte") = "General"
                            Session("Nombre") += " " & oMensaje.RecuperarDescripcion("XGeneral")
                        Else
                            Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0493' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                            lbError.Text = strError
                            Session("bloqueado") = False
                            GoTo terminar
                        End If
                        'dtConsulta = ins.EjecutarConsulta(Session("Query"))
                        'dtConsulta = Session("DataTable")
                        'If (dtConsulta.Rows.Count > 0) Then
                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 3 'Reporte Efectividad por ruta ---------------------------------------------------------
                    If ConsultaEfectividadPorRuta(ins, chboxDetallado.Checked, sCondicion, aRutas, chboxFecha.Checked) Then
                        Session("NumReporte") = 3
                        If (chboxDetallado.Checked) Then
                            Session("TipoReporte") = "Detallado"
                            Session("Nombre") += " " & oMensaje.RecuperarDescripcion("XDetallado")
                        ElseIf (chboxGeneral.Checked) Then
                            Session("TipoReporte") = "General"
                            Session("Nombre") += " " & oMensaje.RecuperarDescripcion("XGeneral")
                        Else
                            Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0493' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                            lbError.Text = strError
                            Session("bloqueado") = False
                            GoTo terminar
                        End If
                        'dtConsulta = ins.EjecutarConsulta(Session("Query"))
                        'dtConsulta = Session("DataTable")
                        'If (dtConsulta.Rows.Count > 0) Then
                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 4 'Reporte Gastos de Venta ---------------------------------------------------------
                    If ConsultaGastosDelVendedor(ins, sCondicion, chboxFecha.Checked) Then
                        Session("NumReporte") = 4
                        'dtConsulta = ins.EjecutarConsulta(Session("Query"))
                        'dtConsulta = Session("DataTable")
                        'If (dtConsulta.Rows.Count > 0) Then
                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 5 'Reporte de Solicitudes ---------------------------------------------------------
                    Session("NumReporte") = 5
                    If (chboxRuta.Checked) Then
                        If (aRutas.Count = 0) Then
                            Dim strError As String = ins.EjecutarComandoScalar("SELECT Descripcion from mendetalle where menclave = 'BE0001' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                            Dim a As String() = strError.Split("$0$")
                            lbError.Text = a(0) + "ruta" + a(2)
                            Session("bloqueado") = False
                            GoTo terminar
                        End If
                    End If
                    If (bCorrecto) Then
                        If ConsultaSolicitudes(ins, sCondicion, aRutas, aClientes, chboxFecha.Checked) Then
                            'Response.Redirect("Solicitudes.aspx")
                        Else
                            Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                            lbError.Text = strError
                            Session("bloqueado") = False
                            GoTo terminar
                        End If
                    End If

                Case 6 'Canjes
                    If ConsultaCanjes(ins, sCondicion, aRutas, aClientes, chboxFecha.Checked) Then
                        Session("NumReporte") = 6
                        'dtConsulta = ins.EjecutarConsulta(Session("Query"))
                        'If (dtConsulta.Rows.Count > 0) Then
                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 7 'Saldos De Clientes
                    If ConsultaSaldosDeClientes(ins, sCondicion, aRutas, aClientes, chboxFecha.Checked) Then
                        Session("NumReporte") = 7
                        'dtConsulta = ins.EjecutarConsulta(Session("Query"))
                        'If (dtConsulta.Rows.Count > 0) Then
                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 8 'Premios
                    sCondicion = ""
                    If ConsultaConfiguracionDePremios(ins, sCondicion, chboxFecha.Checked) Then
                        Session("NumReporte") = 8
                        'dtConsulta = ins.EjecutarConsulta(Session("Query"))
                        'If (dtConsulta.Rows.Count > 0) Then
                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 9 'Tiempos en Ruta
                    If ConsultaTiemposEnRuta(ins, sCondicion, aRutas, chboxFecha.Checked) Then
                        Session("NumReporte") = 9
                        'dtConsulta = ins.EjecutarConsulta(Session("Query"))
                        'If (dtConsulta.Rows.Count > 0) Then
                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 10 'Devoluciones y Cambios por Cliente
                    Session("ConversionKg") = ins.EjecutarConsulta("Select top 1 ConversionKg From ConHist Order By MFechaHora Desc").Rows(0)("ConversionKg")
                    If ConsultaDevolucionesCambiosCliente(ins, Session("ConversionKg"), sCondicion, aClientes, chboxFecha.Checked) Then
                        Session("NumReporte") = 10
                        Session("RangoFechas") = ""
                        Session("RangoFechas") = ObtenerRangoFechas()
                        'dtConsulta = ins.EjecutarConsulta(Session("Query"))
                        'If (dtConsulta.Rows.Count > 0) Then
                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 14 'Venta Esquema
                    Session("ConversionKg") = ins.EjecutarConsulta("Select top 1 ConversionKg From ConHist Order By MFechaHora Desc").Rows(0)("ConversionKg")
                    If ConsultaVentasPorEsquema(ins, Session("ConversionKg"), sCondicion, aRutas, chboxFecha.Checked) Then
                        Session("NumReporte") = 14
                        If (chboxDetallado.Checked) Then
                            Session("TipoReporte") = "Detallado"
                            Session("Nombre") += " " & oMensaje.RecuperarDescripcion("XDetallado")
                        ElseIf (chboxGeneral.Checked) Then
                            Session("TipoReporte") = "General"
                            Session("Nombre") += " " & oMensaje.RecuperarDescripcion("XGeneral")
                        Else
                            Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0493' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                            lbError.Text = strError
                            Session("bloqueado") = False
                            GoTo terminar
                        End If

                        'dtConsulta = ins.EjecutarConsulta(Session("Query"))
                        'If (dtConsulta.Rows.Count > 0) Then
                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 16 'Ventas Totales por Ruta
                    Session("ConversionKg") = ins.EjecutarConsulta("Select top 1 ConversionKg From ConHist Order By MFechaHora Desc").Rows(0)("ConversionKg")
                    If ConsultaVentasTotalesPorRuta(ins, Session("ConversionKg"), sCondicion, aRutas, chboxFecha.Checked) Then
                        Session("NumReporte") = 16
                        'Dim dat As Data.DataTable = ins.EjecutarConsulta(Session("Query"))
                        'If (dat.Rows.Count > 0) Then
                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 17 'Ventas Por Cliente
                    Session("ConversionKg") = ins.EjecutarConsulta("Select top 1 ConversionKg From ConHist Order By MFechaHora Desc").Rows(0)("ConversionKg")
                    If ConsultaVentasPorCliente(ins, Session("ConversionKg"), sCondicion, aRutas, aClientes, chboxFecha.Checked) Then

                        Session("NumReporte") = 17
                        'dtConsulta = ins.EjecutarConsulta(Session("Query"))

                        'Session("TablaReporte") = dtConsulta
                        'If (dtConsulta.Rows.Count > 0) Then
                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If
                Case 18 'Cargas
                    If ConsultaCargas(ins, sCondicion, chboxFecha.Checked) Then
                        Session("NumReporte") = 18
                        'dtConsulta = ins.EjecutarConsulta(Session("Query"))
                        'If (dtConsulta.Rows.Count > 0) Then
                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If
                Case 19 'Liquidacion
                    If ConsultaLiquidacion(ins, sCondicion, aRutas, aClientes, chboxFecha.Checked) Then
                        Session("NumReporte") = 19
                        If (chboxVendedor.Checked) Then
                            Session("USUClave") = ins.EjecutarComandoScalar("select Clave from Usuario where USUId = (select top 1 USUId from Vendedor where VendedorId = '" & Session("VendedorId") & "' and TipoEstado = 1 and Baja = 0)")
                        Else
                            Session("USUClave") = ""
                        End If
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If
                Case 20
                    If (chboxDetallado.Checked) Then
                        Session("TipoReporte") = "Detallado"
                        Session("Nombre") += " " & oMensaje.RecuperarDescripcion("XDetallado")
                    ElseIf (chboxGeneral.Checked) Then
                        Session("TipoReporte") = "General"
                        Session("Nombre") += " " & oMensaje.RecuperarDescripcion("XGeneral")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0493' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If
                    If ConsultaMovSinInSinVis(ins) Then
                        Session("NumReporte") = 20
                        'dtConsulta = ins.EjecutarConsulta(Session("Query"))
                        'Session("TablaReporte") = dtConsulta
                        'If (dtConsulta.Rows.Count > 0) Then
                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If
                Case 21
                    If ConsultaMovSinInEnVis(ins, chboxDetallado.Checked, sCondicion, aRutas, aClientes, chboxFecha.Checked) Then
                        Session("NumReporte") = 21
                        If (chboxDetallado.Checked) Then
                            Session("TipoReporte") = "Detallado"
                            Session("Nombre") += " " & oMensaje.RecuperarDescripcion("XDetallado")
                        ElseIf (chboxGeneral.Checked) Then
                            Session("TipoReporte") = "General"
                            Session("Nombre") += " " & oMensaje.RecuperarDescripcion("XGeneral")
                        Else
                            Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0493' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                            lbError.Text = strError
                            Session("bloqueado") = False
                            GoTo terminar
                        End If
                        'dtConsulta = ins.EjecutarConsulta(Session("Query"))
                        'If (dtConsulta.Rows.Count > 0) Then
                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        ' Session("Query")
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 22
                    If ConsultaProduccion(ins) Then
                        Session("NumReporte") = 22
                        'dtConsulta = ins.EjecutarConsulta(Session("Query"))
                        'Session("TablaReporte") = dtConsulta
                        'If (dtConsulta.Rows.Count > 0) Then
                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If
                Case 23
                    If ConsultaEncuesta(ins, sCondicion, aClientes) Then
                        Session("NumReporte") = 23

                        Dim aClaveCtes As ArrayList = GetClaveClientes()
                        Dim sClientes As String = String.Empty
                        For Each sClien As String In aClaveCtes
                            sClientes &= sClien & ","
                        Next

                        If sClientes.Length > 0 Then
                            Session("FiltroClientes") = Left(sClientes, sClientes.Length - 1)
                        Else
                            Session("FiltroClientes") = ""
                        End If


                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If
                Case 24
                    If ConsultaVentasPorVendedor(ins, chboxDetallado.Checked) Then
                        Session("NumReporte") = 24
                        If (chboxDetallado.Checked) Then
                            Session("TipoReporte") = "Detallado"
                            Session("Nombre") += " " & oMensaje.RecuperarDescripcion("XDetallado")
                        ElseIf (chboxGeneral.Checked) Then
                            Session("TipoReporte") = "General"
                            Session("Nombre") += " " & oMensaje.RecuperarDescripcion("XGeneral")
                        Else
                            Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0493' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                            lbError.Text = strError
                            Session("bloqueado") = False
                            GoTo terminar
                        End If
                        'dtConsulta = ins.EjecutarConsulta(Session("Query"))
                        'Session("TablaReporte") = dtConsulta
                        'If (dtConsulta.Rows.Count > 0) Then
                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 25 'Reporte Efectividad por ruta (Lactigurth)---------------------------------------------------------
                    If ConsultaEfectividadPorRutaLactigurth(ins, chboxDetallado.Checked, sCondicion, aRutas, chboxFecha.Checked) Then
                        Session("NumReporte") = 25
                        If (chboxDetallado.Checked) Then
                            Session("TipoReporte") = "Detallado"
                            Session("Nombre") += " " & oMensaje.RecuperarDescripcion("XDetallado")
                        ElseIf (chboxGeneral.Checked) Then
                            Session("TipoReporte") = "General"
                            Session("Nombre") += " " & oMensaje.RecuperarDescripcion("XGeneral")
                        Else
                            Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0493' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                            lbError.Text = strError
                            Session("bloqueado") = False
                            GoTo terminar
                        End If
                        'dtConsulta = ins.EjecutarConsulta(Session("Query"))
                        'If (dtConsulta.Rows.Count > 0) Then
                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 26 'Liquidación Lactigurth
                    If Me.txtDegustacion.Text = "" Then Me.txtDegustacion.Text = "0.00"
                    If Me.txtChequesDevueltos.Text = "" Then Me.txtChequesDevueltos.Text = "0.00"
                    If Me.txtComision.Text = "" Then Me.txtComision.Text = "0.00"

                    If (Not IsNumeric(txtDegustacion.Text)) Then
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0613' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError.Replace("$0$", LabelDegustacion.Text)
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                    If (Not IsNumeric(txtChequesDevueltos.Text)) Then
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0613' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError.Replace("$0$", LabelChequesDevueltos.Text)
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                    If (Not IsNumeric(txtComision.Text)) Then
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0613' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError.Replace("$0$", LabelComision.Text)
                        GoTo terminar
                    End If

                    If CType(txtComision.Text, Double) > 100 Then
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0049' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Me.txtComision.Focus()
                        GoTo terminar
                    End If

                    If CType(txtComision.Text, Double) < 0 Then
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0336' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError.Replace("$0$", LabelComision.Text)
                        Me.txtComision.Focus()
                        GoTo terminar
                    End If

                    If (ConsultaLiquidacionLactigurth(ins, sCondicion)) Then

                        Session("NumReporte") = 26
                        'dtConsulta = ins.EjecutarConsulta(Session("Gastos"))
                        'dtConsulta = ins.EjecutarConsulta(Session("CobranzaCheques"))
                        'If (dtConsulta.Rows.Count > 0) Then
                        'Response.Redirect("Solicitudes.aspx")
                        'Else
                        '    Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        '    lbError.Text = strError
                        '    GoTo terminar
                        'End If
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        GoTo terminar
                    End If
                Case 27 'Devoluciones y Cambios por Vendedor
                    If ConsultaDevolucionesCambiosVendedor(ins, sCondicion, aClientes, chboxFecha.Checked) Then
                        Session("NumReporte") = 27
                        Session("RangoFechas") = ""
                        Session("RangoFechas") = ObtenerRangoFechas()
                        'dtConsulta = ins.EjecutarConsulta(Session("Query"))
                        'Session("TablaReporte") = dtConsulta
                        'If (dtConsulta.Rows.Count > 0) Then
                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        GoTo terminar
                    End If
                Case 28 'Suma por Ruta
                    If ConsultaSumaPorRuta(ins, sCondicion, chboxFecha.Checked) Then
                        Session("NumReporte") = 28
                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        GoTo terminar
                    End If
                Case 29 'Agrupador por Familia
                    If ConsultaAgrupadoPorFamilia(ins, sCondicion, aRutas, chboxFecha.Checked) Then
                        Session("NumReporte") = 29
                        Session("RangoFechas") = ""
                        Session("RangoFechas") = ObtenerRangoFechas()
                        'dtConsulta = ins.EjecutarConsulta(Session("Query"))
                        'Session("TablaReporte") = dtConsulta
                        'If (dtConsulta.Rows.Count > 0) Then
                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        GoTo terminar
                    End If
                Case 30 'Detallado por Familia
                    If ConsultaDetalladoxFamilia(ins, aRutas, aProductos, aClientes, chboxFecha.Checked) Then
                        Session("NumReporte") = 30

                        Dim sRutas As String = String.Empty
                        For Each sRut As String In aRutas
                            sRutas &= sRut & ","
                        Next

                        If sRutas.Length > 0 Then
                            Dim ob As Object = ins.EjecutarComandoScalar("SELECT Count(*) FROM Ruta WHERE RUTClave not in ('" + sRutas.Substring(0, sRutas.Length - 1).Replace(",", "','") + "')")
                            If (Convert.ToUInt32(ob) > 0) Then
                                Session("FiltroRutas") = Left(sRutas, sRutas.Length - 1)
                            Else
                                Session("FiltroRutas") = "Todas las Rutas"
                            End If
                        Else
                            Session("FiltroRutas") = String.Empty
                        End If
                        Dim aClaveCtes As ArrayList = GetClaveClientes()
                        Dim sClientes As String = String.Empty
                        For Each sClien As String In aClaveCtes
                            sClientes &= sClien & ","
                        Next

                        If sClientes.Length > 0 Then
                            Dim ob As Object

                            If (tvEsquema.SelectedNode.Text = oMensaje.RecuperarDescripcion("XTodos")) Then
                                If aRutas.Count > 0 Then
                                    ob = ins.EjecutarComandoScalar("SELECT Count(distinct c.ClienteClave)  FROM Cliente C inner join ClienteEsquema D on C.ClienteClave = D.ClienteClave inner join esquema E on D.EsquemaID = E.EsquemaID and E.tipo=1 inner join Secuencia S on S.ClienteClave=C.ClienteClave AND S.RUTClave IN (" & sRutas & ")")
                                Else
                                    ob = ins.EjecutarComandoScalar("SELECT Count(distinct c.ClienteClave) FROM Cliente C inner join ClienteEsquema D on C.ClienteClave = D.ClienteClave inner join esquema E on D.EsquemaID = E.EsquemaID and E.tipo=1")
                                End If
                            Else
                                If aRutas.Count > 0 Then
                                    ob = ins.EjecutarComandoScalar("SELECT Count(distinct c.ClienteClave) FROM Cliente C inner join ClienteEsquema D on C.ClienteClave = D.ClienteClave inner join esquema E on D.EsquemaID = E.EsquemaID and E.tipo=1 inner join Secuencia S on S.ClienteClave=C.ClienteClave AND S.RUTClave IN (" & sRutas & ") WHERE E.EsquemaID ='" & tvEsquema.SelectedNode.Value & "'")
                                Else
                                    ob = ins.EjecutarComandoScalar("SELECT Count(distinct c.ClienteClave) FROM Cliente C inner join ClienteEsquema D on C.ClienteClave = D.ClienteClave inner join esquema E on D.EsquemaID = E.EsquemaID and E.tipo=1 WHERE E.EsquemaID ='" & tvEsquema.SelectedNode.Value & "'")
                                End If
                            End If

                            If (Convert.ToUInt32(ob) > 0) Then
                                Session("FiltroClientes") = Left(sClientes, sClientes.Length - 1)
                            Else
                                Session("FiltroClientes") = "Todos los Clientes"
                            End If

                        Else
                            Session("FiltroClientes") = String.Empty
                        End If

                        Dim sEsquemas As String = String.Empty
                        Dim esquemanombre As New ArrayList
                        Dim drs As Janus.Web.GridEX.GridEXRow() = GridEXProducto.GetCheckedRows
                        For Each fila As Janus.Web.GridEX.GridEXRow In drs
                            esquemanombre.Add(fila.Cells("Nombre").Value)
                        Next

                        For i As Integer = 0 To aProductos.Count - 1
                            sEsquemas &= aProductos(i) & " " & esquemanombre(i) & ","
                        Next
                        If sEsquemas.Length > 0 Then
                            Session("FiltroEsquemas") = Left(sEsquemas, sEsquemas.Length - 1)
                        Else
                            Session("FiltroEsquemas") = String.Empty
                        End If

                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        GoTo terminar
                    End If
                Case 31 'Reporte de Promociones
                    Dim bCobrarVentas As Boolean = ins.EjecutarConsulta("Select top 1 CobrarVentas From ConHist Order By MFechaHora Desc").Rows(0)("CobrarVentas")

                    If ConsultaPromociones(ins, sCondicion, bCobrarVentas, aRutas, chboxFecha.Checked) Then
                        Session("NumReporte") = 31
                        Try
                            Session("Nombre") = ins.EjecutarConsulta("select nombreempresa from configuracion").Rows(0)("NombreEmpresa") + vbCrLf + Session("Nombre")
                        Catch ex As Exception

                        End Try
                        Dim sRutas As String = String.Empty
                        For Each sRut As String In aRutas
                            sRutas &= sRut & ","
                        Next
                        If sRutas.Length > 0 Then
                            Session("FiltroRutas") = Left(sRutas, sRutas.Length - 1)
                        Else
                            Session("FiltroRutas") = String.Empty
                        End If

                        Session("Anios") = ""
                        If chboxFecha.Checked Then
                            If ddlFecha.SelectedIndex = 6 Then 'kuando seleccionen "ENTRE" fecha1 y fecha2
                                Dim iAnio As Integer = txtFInicio.Text.Split("/")(2)
                                While iAnio <= txtFFinal.Text.Split("/")(2)
                                    If Session("Anios") = "" Then
                                        Session("Anios") = Trim(Str(iAnio))
                                    Else
                                        Session("Anios") = Session("Anios") & "," & iAnio
                                    End If
                                    iAnio += 1
                                End While
                            Else
                                Session("Anios") = txtFInicio.Text.Split("/")(2)
                            End If
                        Else
                            Session("Anios") = Now.Year
                        End If

                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        GoTo terminar
                    End If
                Case 32 'Reporte de Venta Diario
                    If ConsultaVentaDiario(ins, sCondicion, aRutas, chboxFecha.Checked) Then
                        Session("NumReporte") = 32

                        Dim sRutas As String = String.Empty
                        For Each sRut As String In aRutas
                            sRutas &= sRut & ","
                        Next
                        If sRutas.Length > 0 Then
                            Session("FiltroRutas") = Left(sRutas, sRutas.Length - 1)
                        Else
                            Session("FiltroRutas") = String.Empty
                        End If

                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        GoTo terminar
                    End If
                Case 33 'Diario de actividades
                    If ConsultaDiarioActividades(ins, aRutas, chboxFecha.Checked) Then
                        Session("NumReporte") = 33
                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        GoTo terminar
                    End If
                Case 34 'Reporte indicadores venta
                    If ConsultaIndicadorVenta(ins, sCondicion, aRutas, aClientes, chboxFecha.Checked) Then
                        Session("NumReporte") = 34
                        Dim sRutas As String = String.Empty
                        For Each sRut As String In aRutas
                            sRutas &= sRut & ","
                        Next
                        If sRutas.Length > 0 Then
                            Session("FiltroRutas") = Left(sRutas, sRutas.Length - 1)
                        Else
                            Session("FiltroRutas") = String.Empty
                        End If

                        Try
                            Session("Nombre") = ins.EjecutarConsulta("select nombreempresa from configuracion").Rows(0)("NombreEmpresa") + vbCrLf + Session("Nombre")
                        Catch ex As Exception

                        End Try

                        'dtConsulta = ins.EjecutarConsulta(Session("Query"))
                        'Session("TablaReporte") = dtConsulta
                        'If (dtConsulta.Rows.Count > 0) Then
                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        GoTo terminar
                    End If

                Case 35 'Liquidación Pascual Boing

                    If Me.txtComision.Text = "" Then Me.txtComision.Text = "0.00"

                    If (Not IsNumeric(txtComision.Text)) Then
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0613' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError.Replace("$0$", LabelComision.Text)
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                    If CType(txtComision.Text, Double) > 100 Then
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0049' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        Me.txtComision.Focus()
                        GoTo terminar
                    End If

                    If CType(txtComision.Text, Double) < 0 Then
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0336' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError.Replace("$0$", LabelComision.Text)
                        Me.txtComision.Focus()
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                    If ConsultaLiquidacionPascual(ins, sCondicion, chboxFecha.Checked) Then
                        Session("NumReporte") = 35

                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If
                Case 36 'Productos Otorgados Promocion
                    If ConsultaProductosOtorgadosPromocion(ins, sCondicion, aRutas, chboxFecha.Checked) Then
                        Session("NumReporte") = 36

                        Dim sRutas As String = String.Empty
                        For Each sRut As String In aRutas
                            sRutas &= sRut & ","
                        Next

                        If sRutas.Length > 0 Then
                            Dim ob As Object = ins.EjecutarComandoScalar("SELECT Count(*) FROM Ruta WHERE RUTClave not in ('" + sRutas.Substring(0, sRutas.Length - 1).Replace(",", "','") + "')")
                            If (Convert.ToUInt32(ob) > 0) Then
                                Session("FiltroRutas") = Left(sRutas, sRutas.Length - 1)
                            Else
                                Session("FiltroRutas") = "Todas las Rutas"
                            End If
                        Else
                            Session("FiltroRutas") = String.Empty
                        End If
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 37 'Ventas GAT
                    If ConsultaVentasGat(ins, chboxDetallado.Checked, sCondicion, aRutas, aClientes, chboxFecha.Checked) Then
                        Session("NumReporte") = 37
                        If (chboxDetallado.Checked) Then
                            Session("TipoReporte") = "Detallado"
                            Session("Nombre") += " " & oMensaje.RecuperarDescripcion("XDetallado")
                        ElseIf (chboxGeneral.Checked) Then
                            Session("TipoReporte") = "General"
                            Session("Nombre") += " " & oMensaje.RecuperarDescripcion("XGeneral")
                        Else
                            Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0493' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                            lbError.Text = strError
                            Session("bloqueado") = False
                            GoTo terminar
                        End If
                        'dtConsulta = ins.EjecutarConsulta(Session("Query"))
                        'dtConsulta = Session("DataTable")
                        'If (dtConsulta.Rows.Count > 0) Then
                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 38 'Ventas El Panque
                    If ConsultaVentasElPanque(ins, chboxDetallado.Checked, sCondicion, aRutas, chboxFecha.Checked) Then
                        Session("NumReporte") = 38
                        If (chboxDetallado.Checked) Then
                            Session("TipoReporte") = "Detallado"
                            Session("Nombre") += " " & oMensaje.RecuperarDescripcion("XDetallado")
                        ElseIf (chboxGeneral.Checked) Then
                            Session("TipoReporte") = "General"
                            Session("Nombre") += " " & oMensaje.RecuperarDescripcion("XGeneral")
                        Else
                            Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0493' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                            lbError.Text = strError
                            Session("bloqueado") = False
                            GoTo terminar
                        End If
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 39 'Liquidación Bajo Cero

                    If ConsultaLiquidacionBajoCero(ins, sCondicion, chboxFecha.Checked) Then
                        Session("NumReporte") = 39

                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 40 'Activos Bajo Cero
                    Dim enTipoActivo As enActivo

                    If chboxAsignados.Checked Then enTipoActivo = enActivo.Asginados
                    If chboxNoAsignados.Checked Then enTipoActivo = enActivo.NoAsignados
                    If chboxPorFiltro.Checked Then enTipoActivo = enActivo.PorFiltro

                    If ConsultaActivosBajoCero(ins, enTipoActivo, sCondicion, aRutas, aClientes, aActivos) Then
                        Session("NumReporte") = 40

                        Dim aClaveCtes As ArrayList = GetClaveClientes()
                        Dim sClientes As String = String.Empty
                        For Each sClien As String In aClaveCtes
                            sClientes &= sClien & ","
                        Next

                        If sClientes.Length > 0 Then
                            Session("FiltroClientes") = Left(sClientes, sClientes.Length - 1)
                        Else
                            Session("FiltroClientes") = ""
                        End If

                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 41 'Mercadeo Bajo Cero
                    If ConsultaMercadeoBajoCero(ins, sCondicion, aRutas, aClientes) Then
                        Session("NumReporte") = 41
                        Dim aClaveCtes As ArrayList = GetClaveClientes()
                        Dim sClientes As String = String.Empty
                        For Each sClien As String In aClaveCtes
                            sClientes &= sClien & ","
                        Next

                        If sClientes.Length > 0 Then
                            Session("FiltroClientes") = Left(sClientes, sClientes.Length - 1)
                        Else
                            Session("FiltroClientes") = ""
                        End If
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 42 'Tiempos en Ruta (Mayoreo Cárdenas)
                    If ConsultaTiemposEnRutaMayoreo(ins, sCondicion, aRutas, chboxFecha.Checked) Then
                        Session("NumReporte") = 42
                        'dtConsulta = ins.EjecutarConsulta(Session("Query"))
                        'If (dtConsulta.Rows.Count > 0) Then
                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 43 'Facturacion Electronica
                    If ConsultaFacturacionElectronica(ins, sCondicion, aRutas, chboxFecha.Checked) Then
                        Session("NumReporte") = 43
                        'dtConsulta = ins.EjecutarConsulta(Session("Query"))
                        'If (dtConsulta.Rows.Count > 0) Then
                        'Response.Redirect("Solicitudes.aspx")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If
                Case 44 'Ventas con Saldo                    
                    If ConsultaVentaSaldo(ins, chboxDetallado.Checked, aClientes, sCondicion, chboxFecha.Checked) Then
                        Session("NumReporte") = 44
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If
                Case 45 'Venta Esquema (Panque)
                    Session("ConversionKg") = ins.EjecutarConsulta("Select top 1 ConversionKg From ConHist Order By MFechaHora Desc").Rows(0)("ConversionKg")
                    If ConsultaVentasPorEsquemaPanque(ins, Session("ConversionKg"), sCondicion, aRutas, aProductos, chboxFecha.Checked) Then
                        Session("NumReporte") = 45
                        If (chboxDetallado.Checked) Then
                            Session("TipoReporte") = "Detallado"
                            Session("Nombre") += " " & oMensaje.RecuperarDescripcion("XDetallado")
                        ElseIf (chboxGeneral.Checked) Then
                            Session("TipoReporte") = "General"
                            Session("Nombre") += " " & oMensaje.RecuperarDescripcion("XGeneral")
                        Else
                            Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0493' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                            lbError.Text = strError
                            Session("bloqueado") = False
                            GoTo terminar
                        End If
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If
                Case 46 'Clientes por Ruta (Panque)
                    If ConsultaClientesPorRutaPanque(ins, sCondicion, aRutas, chboxFecha.Checked) Then
                        Session("NumReporte") = 46
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 47 'Consignacion
                    Session("ConversionKg") = ins.EjecutarConsulta("Select top 1 ConversionKg From ConHist Order By MFechaHora Desc").Rows(0)("ConversionKg")
                    If ConsultaConsignacion(ins, chboxDetallado.Checked, Session("ConversionKg"), sCondicion, aRutas, aClientes, chboxFecha.Checked) Then
                        Session("NumReporte") = 47

                        Dim aClaveCtes As ArrayList = GetClaveClientes()
                        Dim sClientes As String = String.Empty
                        For Each sClien As String In aClaveCtes
                            sClientes &= sClien & ","
                        Next

                        If sClientes.Length > 0 Then
                            Session("FiltroClientes") = Left(sClientes, sClientes.Length - 1)
                        Else
                            Session("FiltroClientes") = ""
                        End If


                        If (chboxDetallado.Checked) Then
                            Session("TipoReporte") = "Detallado"
                            Session("Nombre") += " " & oMensaje.RecuperarDescripcion("XDetallado")
                        ElseIf (chboxGeneral.Checked) Then
                            Session("TipoReporte") = "General"
                            Session("Nombre") += " " & oMensaje.RecuperarDescripcion("XGeneral")
                        End If
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError

                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 48 'Liquidacion Poblana
                    If ConsultaLiquidacionPoblana(ins, sCondicion) Then
                        Session("NumReporte") = 48
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If
                Case 49 'Devoluciones y Cambios (DISPOSUR)
                    If ConsultaDevolucionesCambiosDISPOSUR(ins, aClientes, sCondicion, chboxFecha.Checked, aRutas) Then
                        Session("NumReporte") = 49
                        Session("ConversionKg") = ins.EjecutarConsulta("Select top 1 ConversionKg From ConHist Order By MFechaHora Desc").Rows(0)("ConversionKg")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If
                Case 50 'Cuotas de Ventas (DISPOSUR)
                    If ConsultaCuotasVentaDISPOSUR(ins, sCondicion, chboxFecha.Checked) Then
                        Session("NumReporte") = 50
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 51 'Exportar encuestas aplicadas
                    If ConsultaExportarEncuestas(ins, aRutas) Then
                        'lbError.Text = "Se genero el archivo .CSV"
                        'Session("bloqueado") = False
                        'GoTo terminar
                        Session("NumReporte") = 51
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If
                Case 52 'Reporte de Clientes no Visitados
                    If ConsultaClientesNoVisitados(ins, aRutas, chboxFecha.Checked) Then
                        Session("NumReporte") = 52
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If
                Case 53 'Puntos de Recorrido
                    If ConsultaPuntosRecorrido(ins, aRutas, chboxFecha.Checked) Then
                        Session("NumReporte") = 53
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If
                Case 54 'Sugerido de Carga por Reparto
                    Session("ConversionKg") = ins.EjecutarConsulta("Select top 1 ConversionKg From ConHist Order By MFechaHora Desc").Rows(0)("ConversionKg")

                    Dim sEsquemas As String = String.Empty
                    Dim aEsquemas As ArrayList = New ArrayList
                    Dim drs As Janus.Web.GridEX.GridEXRow() = GridEXProducto.GetCheckedRows
                    For Each fila As Janus.Web.GridEX.GridEXRow In drs
                        sEsquemas &= fila.Cells("Clave").Value & "-" & fila.Cells("Nombre").Value & ", "
                        aEsquemas.Add(fila.Cells("EsquemaId").Value)
                    Next
                    If sEsquemas.Length > 0 Then
                        Session("FiltroEsquemas") = Left(sEsquemas, sEsquemas.Length - 2)
                    Else
                        Session("FiltroEsquemas") = String.Empty
                    End If

                    If ConsultaSugeridoCargaPorReparto(ins, Session("ConversionKg"), sCondicion, aRutas, aEsquemas) Then
                        Session("NumReporte") = 54
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 55 'ConsultaInventarioDeProductoTerminadoPanque
                    If Me.ConsultaInventarioDeProductoTerminadoPanque(ins, sCondicion, chboxFecha.Checked) Then
                        Session("NumReporte") = 55
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 56 'Devoluciones Y Frio (Panque)
                    If ConsultaDevolucionesFrioPanque(ins, sCondicion, aRutas, chboxFecha.Checked) Then
                        Session("NumReporte") = 56
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 57 'Resumen de ventas por ruta y vendedor
                    If ConsultaResumenVentasRutaVendedor(ins, sCondicion) Then
                        Session("NumReporte") = 57
                        Session("NombreEmpresa") = ins.EjecutarConsulta("select NombreEmpresa from Configuracion").Rows(0)("NombreEmpresa")
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 58 'Resumen de ventas por cliente
                    Dim sEsquemaId As String = ""
                    Dim sNombreEsquema As String = ""
                    If Not tvEsquema.SelectedNode Is Nothing Then
                        If tvEsquema.SelectedNode.Value <> oMensaje.RecuperarDescripcion("XTodos") Then
                            sEsquemaId = tvEsquema.SelectedNode.Value
                            sNombreEsquema = ins.EjecutarComandoScalar("select convert(varchar(16), Clave) + ' - ' + convert(varchar(32), Nombre) as NombreEsquema from Esquema where EsquemaId = '" & sEsquemaId & "'")
                        End If
                    End If

                    If ConsultaResumenVentasCliente(ins, sCondicion, aRutas, sEsquemaId) Then
                        Session("NumReporte") = 58
                        Session("NombreEmpresa") = ins.EjecutarConsulta("select NombreEmpresa from Configuracion").Rows(0)("NombreEmpresa")
                        Session("NombreEsquema") = sNombreEsquema
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 59 'Saldos por Cliente
                    If ConsultaSaldosPorCliente(ins, sCondicion, aRutas, aClientes) Then
                        Session("NumReporte") = 59
                        Dim aClaveCtes As ArrayList = GetClaveClientes()
                        Dim sClientes As String = String.Empty
                        For Each sClien As String In aClaveCtes
                            sClientes &= sClien & ","
                        Next
                        If sClientes.Length > 0 Then
                            Session("FiltroClientes") = Left(sClientes, sClientes.Length - 1)
                        Else
                            Session("FiltroClientes") = ""
                        End If
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 60 'Liquidación Modelo
                    If ConsultaLiquidacionModelo(ins, sCondicion) Then
                        Session("NumReporte") = 60
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If
                Case 62
                    If ConsultaLiquidacionSuKarne(ins, sCondicion) Then
                        Session("NumReporte") = 62
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If

                Case 67 'Tiempos en Ruta SuKarne
                    If ConsultaTiemposEnRutaSuKarne(ins, sCondicion, aRutas, chboxFecha.Checked) Then
                        Session("NumReporte") = 67
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If
                Case 62
                    If ConsultaLiquidacionSuKarne(ins, sCondicion) Then
                        Session("NumReporte") = 62
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If
                Case 107
                    If ConsultaFolios(ins) Then
                        Session("NumReporte") = 107
                    Else
                        Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0034' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                        lbError.Text = strError
                        Session("bloqueado") = False
                        GoTo terminar
                    End If
            End Select


            Dim Ticks As Long = DateTime.Now.Ticks
            Dim dtReportes As New Data.DataTable
            If IsNothing(Session("DTReportes")) Then
                dtReportes.Columns.Add("Nombre")
                dtReportes.Columns.Add("ID")
                dtReportes.Columns.Add("sig")
            Else
                dtReportes = Session("DTReportes")
            End If
            Dim row As Data.DataRow = dtReportes.NewRow()
            row("Nombre") = Session("Nombre")
            row("ID") = Ticks.ToString
            row("sig") = ""
            If dtReportes.Rows.IndexOf(row) = -1 Then
                dtReportes.Rows.Add(row)
            End If

            Session("DTReportes") = dtReportes

            UpdatePanel9.Update()
            'Response.Redirect("Solicitudes.aspx")

            If Session("Formato") <> 1 Then


                If Not (Page.ClientScript.IsClientScriptBlockRegistered("popup")) Then
                    Dim ScriptBlock As String = "<script language=""JavaScript"">"
                    ScriptBlock += " function popup()"
                    'ScriptBlock += " { window.open('Frames.aspx','min" + Rnd.Next.ToString() + "','fullscreen=yes, scrollbars=auto'); }; "
                    ScriptBlock += " { window.open('intermedio.aspx?id=" + DateTime.Now.Ticks.ToString() + "','Reportes','dependent=yes,resizable=yes, directories=no, menubar=no, personalbar=no, status=no,alwaysRaised=yes, toolbar=no,z-lock=yes'); }; "

                    ScriptBlock += "</script>"
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "popup", ScriptBlock)
                End If
            Else
                If Not (Page.ClientScript.IsClientScriptBlockRegistered("popup")) Then

                    Dim ScriptBlock As String = "<script language=""JavaScript"">"
                    ScriptBlock += " function popup()"
                    'ScriptBlock += " { window.open('Frames.aspx','min" + Rnd.Next.ToString() + "','fullscreen=yes, scrollbars=auto'); }; "
                    'ScriptBlock += " { window.open('solicitudes.aspx?id=" + DateTime.Now.Ticks.ToString() + "')}; "
                    ScriptBlock += " { window.open('solicitudes.aspx?id=" + DateTime.Now.Ticks.ToString() + "','Reportes','dependent=no,resizable=yes, directories=no, menubar=no, personalbar=no, status=yes,alwaysRaised=yes, toolbar=no,z-lock=no,scrollbars=yes '); }; "
                    'ScriptBlock += " { window.open('solicitudes.aspx?id=" + DateTime.Now.Ticks.ToString() + "','Reportes','dependent=yes,resizable=yes, directories=no, menubar=no, personalbar=no, status=yes,alwaysRaised=yes, toolbar=no,z-lock=yes,scrollbars=yes '); }; "

                    ScriptBlock += "</script>"
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "popup", ScriptBlock)
                End If
            End If
            litPopUp.Text = "<script language=""JavaScript"">popup();</script>"
            Session("Bloqueado") = True
terminar:

        End If
    End Sub

    Private Function BuscarEsquemasHijos(ByVal ins As DBConexion.cConexionSQL, ByVal sEsquemaIdPadre As String, ByRef aEsquemasHijos As ArrayList) As Boolean
        Dim sConsulta As String = ""
        Dim dtEsquemas As DataTable = Nothing
        If aEsquemasHijos Is Nothing Then aEsquemasHijos = New ArrayList
        sConsulta = "select EsquemaId from Esquema where EsquemaIdPadre = '" & sEsquemaIdPadre & "'"
        dtEsquemas = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        For Each drEsquema As DataRow In dtEsquemas.Rows
            aEsquemasHijos.Add(drEsquema("EsquemaId"))
            BuscarEsquemasHijos(ins, drEsquema("EsquemaId"), aEsquemasHijos)
        Next
    End Function

    'Private Sub CopiarSessiones(ByVal num As String)
    '    Session("Nombre" + num.ToString) = Session("Nombre")
    '    Session("Formato" + num.ToString) = Session("Formato")
    '    Session("NumReporte" + num.ToString) = Session("NumReporte")
    '    Session("Query" + num.ToString) = Session("Query")
    '    Session("RangoFechas" + num.ToString) = Session("RangoFechas")
    '    Session("CEDI" + num.ToString) = Session("CEDI")
    '    Session("Vendedor" + num.ToString) = Session("Vendedor")
    '    Session("Ruta" + num.ToString) = Session("Ruta")
    '    Session("FiltroRutas" + num.ToString) = Session("FiltroRutas")
    '    Session("TipoReporte" + num.ToString) = Session("TipoReporte")
    '    Session("VendedorId" + num.ToString) = Session("VendedorId")
    '    Session("Producto" + num.ToString) = Session("Producto")
    '    Session("ConversionKg" + num.ToString) = Session("ConversionKg")
    '    Session("FiltroClientes" + num.ToString) = Session("FiltroClientes")
    '    Session("FiltroEsquemas" + num.ToString) = Session("FiltroEsquemas")
    '    Session("Anios" + num.ToString) = Session("Anios")
    '    Session("DataTable" + num.ToString) = Session("DataTable")
    '    Session("TotalClientes" + num.ToString) = Session("TotalClientes")
    '    Session("TotalVisitados" + num.ToString) = Session("TotalVisitados")
    '    Session("TotalVisitadosSinVenta" + num.ToString) = Session("TotalVisitadosSinVenta")
    '    Session("TotalEncuestas" + num.ToString) = Session("TotalEncuestas")
    '    Session("TotalVisitadosAEncuestar" + num.ToString) = Session("TotalVisitadosAEncuestar")
    '    Session("Tiempos" + num.ToString) = Session("Tiempos")
    '    Session("ClientesNoVisitados" + num.ToString) = Session("ClientesNoVisitados")
    '    Session("ClientesVisitados" + num.ToString) = Session("ClientesVisitados")
    '    Session("ClientesVisitadosConVenta" + num.ToString) = Session("ClientesVisitadosConVenta")
    '    Session("ClientesVisitadosSinVenta" + num.ToString) = Session("ClientesVisitadosSinVenta")
    '    Session("ImproductividadVenta" + num.ToString) = Session("ImproductividadVenta")
    '    Session("EncuestasAplicadas" + num.ToString) = Session("EncuestasAplicadas")
    '    Session("EncuestasNoAplicadas" + num.ToString) = Session("EncuestasNoAplicadas")
    '    Session("ClientesEncuestados" + num.ToString) = Session("ClientesEncuestados")
    '    Session("ClientesNoEncuestados" + num.ToString) = Session("ClientesNoEncuestados")
    '    Session("CodigosLeidos" + num.ToString) = Session("CodigosLeidos")
    '    Session("Query2" + num.ToString) = Session("Query2")
    '    Session("CodigosNoLeidos" + num.ToString) = Session("CodigosNoLeidos")
    '    Session("ProductoNegado" + num.ToString) = Session("ProductoNegado")
    '    Session("ImproductividadProducto" + num.ToString) = Session("ImproductividadProducto")
    '    Session("MotivosImproductividad" + num.ToString) = Session("MotivosImproductividad")
    '    Session("ClientesProductoNegado" + num.ToString) = Session("ClientesProductoNegado")
    '    Session("ClientesImproductividadProducto" + num.ToString) = Session("ClientesImproductividadProducto")
    '    Session("FechaInicial" + num.ToString) = Session("FechaInicial")
    '    Session("FechaFinal" + num.ToString) = Session("FechaFinal")
    '    Session("TotalClientesVisitados" + num.ToString) = Session("TotalClientesVisitados")
    '    Session("Query3" + num.ToString) = Session("Query3")
    '    Session("Query4" + num.ToString) = Session("Query4")
    '    Session("Query5" + num.ToString) = Session("Query5")
    '    Session("VentasProductos" + num.ToString) = Session("VentasProductos")
    '    Session("CobranzaCheques" + num.ToString) = Session("CobranzaCheques")
    '    Session("Gastos" + num.ToString) = Session("Gastos")
    '    Session("Creditos" + num.ToString) = Session("Creditos")
    '    Session("CobranzaAnteriores" + num.ToString) = Session("CobranzaAnteriores")
    '    Session("DevolucionMala" + num.ToString) = Session("DevolucionMala")
    '    Session("Degustacion" + num.ToString) = Session("Degustacion")
    '    Session("ChequesDevueltos" + num.ToString) = Session("ChequesDevueltos")
    '    Session("TotalEfectivo" + num.ToString) = Session("TotalEfectivo")
    '    Session("TotalCalculoComision" + num.ToString) = Session("TotalCalculoComision")
    '    Session("PorcentajeComision" + num.ToString) = Session("PorcentajeComision")
    '    Session("DataTable1" + num.ToString) = Session("DataTable1")
    '    Session("DataTable2" + num.ToString) = Session("DataTable2")
    '    Session("Visitados" + num.ToString) = Session("Visitados")
    '    Session("NoVisitados" + num.ToString) = Session("NoVisitados")
    '    Session("Totales" + num.ToString) = Session("Totales")
    '    Session("Cuotas" + num.ToString) = Session("Cuotas")
    '    Session("VentasProductos" + num.ToString) = Session("VentasProductos")
    '    Session("Embalajes" + num.ToString) = Session("Embalajes")
    '    Session("ProdAcum" + num.ToString) = Session("ProdAcum")
    '    Session("SaldosVentas") = Session("SaldosVentas")

    'End Sub
    'Protected Sub GridView3_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
    '    Dim dt As Data.DataTable = Session("tblProductos")
    '    GuardaChecksProductos()
    '    GridView3.DataSource = dt
    '    GridView3.PageIndex = e.NewPageIndex
    '    GridView3.DataBind()
    '    'UpdatePanel10.Update()
    'End Sub

    'Protected Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
    '    Dim dt As Data.DataTable = Session("tblClientes")
    '    GuardaChecksClientes()
    '    GridView2.DataSource = dt
    '    GridView2.PageIndex = e.NewPageIndex
    '    GridView2.DataBind()
    '    UpdatePanel8.Update()
    'End Sub

    'Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
    '    Dim dt As Data.DataTable = Session("tblRutas")
    '    GuardaChecksRutas()
    '    Me.GridView1.DataSource = dt

    '    Me.GridView1.PageIndex = e.NewPageIndex
    '    Me.GridView1.DataBind()
    '    UpdatePanel5.Update()
    'End Sub

    Protected Sub GridEXRuta_RowCheckedChanged(ByVal sender As Object, ByVal e As Janus.Web.GridEX.RowCheckedChangedEventArgs) Handles GridEXRuta.RowCheckedChanged
        If Not tvEsquema.SelectedNode Is Nothing Then


            tvEsquema.Nodes.Clear()
            Dim mensaje As New DBConexion.cMensaje
            Dim ins As New DBConexion.cConexionSQL
            Session("lenguaje") = DBConexion.cMensaje.ObtenerLenguaje

            Dim dat As Data.DataTable = ins.EjecutarConsulta("Select Nombre, EsquemaID from Esquema where EsquemaIDPadre is null and tipo =1 ", "Esquema")
            Dim nodoTodos As New TreeNode(mensaje.RecuperarDescripcion("Xtodos"))

            For i As Integer = 0 To dat.Rows.Count - 1
                Dim nodoPadre As New TreeNode()
                nodoPadre.Text = dat.Rows(i)(0).ToString()
                nodoPadre.Value = dat.Rows(i)(1).ToString()
                'llamar a la funcion para obtener a los hijos...
                nodoPadre = ChildTree(nodoPadre, dat, i)
                nodoTodos.ChildNodes.Add(nodoPadre)

            Next
            tvEsquema.Nodes.Add(nodoTodos)

            'CConexion.chkConexion()


            tvEsquema_SelectedNodeChanged(tvEsquema, New System.EventArgs)

        End If
    End Sub

    Protected Sub chboxAsignados_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not chboxAsignados.Checked Then Exit Sub

        ChBoxCentroDistribucion.Visible = True
        ChBoxCentroDistribucion.Checked = False
        PanelCentroDistribucion.Visible = False
        UpdatePanel7.Update()

        chboxVendedor.Visible = True
        chboxVendedor.Checked = False
        PanelVendedor.Visible = False
        UpdatePanel3.Update()
        UpdatePanel7.Update()

        Panel1.Visible = True
        UpdatePanel1.Update()

        chboxRuta.Visible = True
        If (chboxRuta.Checked = True) Then
            GridEXRuta.Visible = True
        End If
        UpdatePanel5.Update()

        Pnlclientes.Visible = True
        'PanelEsquemas.Visible = True
        Label1.Visible = True
        UpdatePanel8.Update()

        'If PanelEsquemas.Visible And Not IsNothing(tvEsquema.SelectedNode) Then
        '    tvEsquema_SelectedNodeChanged(tvEsquema, New System.EventArgs)
        'End If
        If PanelEsquemas.Visible And Not IsNothing(tvEsquema.SelectedNode) Then
            'tvEsquema(_SelectionChanged(tvEsquema, New System.EventArgs))
        End If
        UpdatePanel1.Update()

        Label7.Visible = False
        GridEXActivos.Visible = False
        UpdatePanel11.Update()
    End Sub

    Protected Sub chboxNoAsignados_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not chboxNoAsignados.Checked Then Exit Sub

        ChBoxCentroDistribucion.Visible = False
        ChBoxCentroDistribucion.Checked = False
        PanelCentroDistribucion.Visible = False
        UpdatePanel7.Update()

        PanelVendedor.Visible = False
        chboxVendedor.Visible = False
        chboxVendedor.Checked = False
        UpdatePanel3.Update()
        UpdatePanel7.Update()

        chboxRuta.Visible = False
        GridEXRuta.Visible = False
        UpdatePanel5.Update()

        Panel1.Visible = False
        UpdatePanel1.Update()

        Pnlclientes.Visible = False
        'PanelEsquemas.Visible = False
        Label1.Visible = False
        UpdatePanel8.Update()

        'If PanelEsquemas.Visible And Not IsNothing(tvEsquema.SelectedNode) Then
        '    tvEsquema_SelectedNodeChanged(tvEsquema, New System.EventArgs)
        'End If
        If PanelEsquemas.Visible And Not IsNothing(tvEsquema.SelectedNode) Then
            'tvEsquema(_SelectionChanged(tvEsquema, New System.EventArgs))
        End If
        UpdatePanel1.Update()

        Label7.Visible = False
        GridEXActivos.Visible = False
        UpdatePanel11.Update()

    End Sub

    Protected Sub chboxPorFiltro_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not chboxPorFiltro.Checked Then Exit Sub

        ChBoxCentroDistribucion.Visible = False
        ChBoxCentroDistribucion.Checked = False
        PanelCentroDistribucion.Visible = False
        UpdatePanel7.Update()

        PanelVendedor.Visible = False
        chboxVendedor.Visible = False
        chboxVendedor.Checked = False
        UpdatePanel3.Update()
        UpdatePanel7.Update()

        Panel1.Visible = False
        UpdatePanel1.Update()

        chboxRuta.Visible = False
        GridEXRuta.Visible = False
        UpdatePanel5.Update()

        Pnlclientes.Visible = False
        'PanelEsquemas.Visible = False
        Label1.Visible = False
        UpdatePanel8.Update()

        If PanelEsquemas.Visible And Not IsNothing(tvEsquema.SelectedNode) Then
            ' tvEsquema_SelectedNodeChanged(tvEsquema, New System.EventArgs)
        End If

        UpdatePanel1.Update()

        Label7.Visible = True
        GridEXActivos.Visible = True
        UpdatePanel11.Update()
    End Sub

#End Region

#Region "Metodos Generales"
    Private Function ChildTree(ByVal root As TreeNode, ByVal datTemp As Data.DataTable, ByVal ind As Integer) As TreeNode
        Dim ins As New DBConexion.cConexionSQL
        Dim dat As Data.DataTable = ins.EjecutarConsulta("Select Nombre, EsquemaID from Esquema where EsquemaIDPadre = '" & datTemp.Rows(ind)(1).ToString() & "' and tipo = 1 ", "Esquema")
        For i As Integer = 0 To dat.Rows.Count - 1
            Dim child As New TreeNode()
            child.Text = dat.Rows(i)(0).ToString()
            child.Value = dat.Rows(i)(1).ToString()
            Try
                child = ChildTree(child, dat, i)
            Catch ex As Exception

            End Try
            root.ChildNodes.Add(child)
        Next
        Return root
    End Function

    Public Sub CambioRutaCliente(ByVal sender As Object, ByVal e As System.EventArgs)
        If lbError.Text <> "" Then
            lbError.Text = ""
            UpdatePanel6.Update()
        End If

    End Sub

    Function GetRutas() As ArrayList
        Dim rutasA As New ArrayList
        'If chboxRuta.Checked Then
        '    Dim dt As Data.DataTable = Session("tblRutas")
        '    If Not dt Is Nothing Then
        '        For Each fila As Data.DataRow In dt.Rows
        '            If IIf(fila("checks") Is DBNull.Value, False, fila("checks")) Then
        '                Dim strTemp As String = fila(0).ToString()
        '                rutasA.Add(strTemp)
        '            End If
        '        Next
        '    End If
        'End If

        If chboxRuta.Checked Then
            Dim drs As Janus.Web.GridEX.GridEXRow() = GridEXRuta.GetCheckedRows
            For Each fila As Janus.Web.GridEX.GridEXRow In drs
                rutasA.Add(fila.Cells("RUTClave").Value)
            Next
        End If
        Return rutasA
    End Function

    Function GetClientes() As ArrayList
        Dim clientes As New ArrayList
        'If Pnlclientes.visible Then
        '    Dim dt As Data.DataTable = Session("tblClientes")
        '    If Not dt Is Nothing Then
        '        For Each fila As Data.DataRow In dt.Rows
        '            If IIf(fila("checks") Is DBNull.Value, False, fila("checks")) Then
        '                'Dim strTemp As String = fila(1).ToString()
        '                Dim strTemp As String = fila(0).ToString()
        '                clientes.Add(strTemp)
        '            End If
        '        Next
        '    End If
        'End If

        If Pnlclientes.Visible Then
            Dim drs As Janus.Web.GridEX.GridEXRow() = GridEXCliente.GetCheckedRows
            For Each fila As Janus.Web.GridEX.GridEXRow In drs
                clientes.Add(fila.Cells("ClienteClave").Value)
            Next
        End If
        Return clientes
    End Function

    Function GetClaveClientes() As ArrayList
        Dim clientes As New ArrayList
        If Pnlclientes.Visible Then
            Dim drs As Janus.Web.GridEX.GridEXRow() = GridEXCliente.GetCheckedRows
            For Each fila As Janus.Web.GridEX.GridEXRow In drs
                clientes.Add(fila.Cells("Clave").Value)
            Next
        End If
        Return clientes
    End Function

    Function GetActivos() As ArrayList
        Dim Activos As New ArrayList

        If GridEXActivos.Visible Then
            Dim drs As Janus.Web.GridEX.GridEXRow() = GridEXActivos.GetCheckedRows
            For Each fila As Janus.Web.GridEX.GridEXRow In drs
                Activos.Add(fila.Cells("ActivoClave").Value)
            Next
        End If
        Return Activos
    End Function

    Function GetProductos() As ArrayList
        Dim ProductosA As New ArrayList

        'Dim dt As Data.DataTable = Session("tblProductos")
        'If Not dt Is Nothing Then
        '    For Each fila As Data.DataRow In dt.Rows
        '        If IIf(fila("checks") Is DBNull.Value, False, fila("checks")) Then
        '            Dim strTemp As String = fila(0).ToString()
        '            ProductosA.Add(strTemp)
        '        End If
        '    Next
        'End If

        Dim drs As Janus.Web.GridEX.GridEXRow() = GridEXProducto.GetCheckedRows
        For Each fila As Janus.Web.GridEX.GridEXRow In drs
            ProductosA.Add(fila.Cells("EsquemaId").Value)
        Next

        Return ProductosA
    End Function

    Function GetClaveProductos() As ArrayList
        Dim ProductosA As New ArrayList

        Dim drs As Janus.Web.GridEX.GridEXRow() = GridEXProducto.GetCheckedRows
        For Each fila As Janus.Web.GridEX.GridEXRow In drs
            ProductosA.Add(fila.Cells("Clave").Value)
        Next

        Return ProductosA
    End Function

    Function CheckFechasFormato(ByVal ins As DBConexion.cConexionSQL) As Boolean
        'Dim formato As Date
        Dim mensaje As New DBConexion.cMensaje
        Dim sFecha As String()
        Dim dFecha As Date

        If ddlFecha.SelectedIndex = 6 Then
            sFecha = txtFInicio.Text.Split("/")
            Try
                dFecha = New Date(sFecha(2), sFecha(1), sFecha(0))
            Catch ex As Exception
                lbError.Text = mensaje.RecuperarDescripcion("Xformatofecha")

                Return False
                Exit Function
            End Try
            sFecha = txtFFinal.Text.Split("/")
            Try
                dFecha = New Date(sFecha(2), sFecha(1), sFecha(0))
            Catch ex As Exception
                lbError.Text = mensaje.RecuperarDescripcion("Xformatofecha")
                Return False
                Exit Function
            End Try
        Else
            sFecha = txtFInicio.Text.Split("/")
            Try
                dFecha = New Date(sFecha(2), sFecha(1), sFecha(0))
            Catch ex As Exception
                lbError.Text = mensaje.RecuperarDescripcion("Xformatofecha")
                Return False
                Exit Function
            End Try
        End If
        Return True
    End Function

    Function CheckFechas() As Boolean
        If Not chboxFecha.Checked Then Return True

        If ddlFecha.SelectedIndex = 6 Then
            Dim sFecha As String()
            sFecha = txtFInicio.Text.Split("/")
            fecha1 = New Date(sFecha(2), sFecha(1), sFecha(0)) 'txtFInicio.Text
            sFecha = txtFFinal.Text.Split("/")
            fecha2 = New Date(sFecha(2), sFecha(1), sFecha(0)) 'txtFFinal.Text
            Dim ins As New DBConexion.cConexionSQL

            If (fecha1 < fecha2) Then
                If (fecha2 > Date.Now) Then
                    '--System.Diagnostics.Debug.WriteLine("La fecha no puede ser mayor a la actual", MsgBoxStyle.Exclamation, "Error")
                    Dim strError As String = ins.EjecutarComandoScalar("SELECT Descripcion from mendetalle where menclave = 'E0087' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                    Dim stringFinal As String = ins.EjecutarComandoScalar("SELECT Descripcion from mendetalle where menclave = 'CADFechaFinal' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                    strError = strError.Replace("$0$", stringFinal)
                    lbError.Text = strError
                Else

                    Return True
                End If
            Else
                Dim strError As String = ins.EjecutarComandoScalar("select Descripcion from mendetalle where menclave = 'E0008' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
                lbError.Text = strError
            End If

        Else
            Return True
        End If
        Return False
    End Function

    Function ObtenerRangoFechas() As String
        Dim RangoFechas As String = String.Empty

        If (chboxFecha.Checked = False) Then
            RangoFechas = ""
        ElseIf ddlFecha.SelectedIndex = 6 Then 'kuando seleccionen "ENTRE" fecha1 y fecha2
            If (CheckFechas()) Then
                RangoFechas = Me.txtFInicio.Text & " - " & Me.txtFFinal.Text
            End If
        ElseIf ddlFecha.SelectedIndex = 0 Then
            RangoFechas = Me.txtFInicio.Text
        ElseIf ddlFecha.SelectedIndex = 1 Then
            RangoFechas += Me.ddlFecha.SelectedItem.ToString & " a " & Me.txtFInicio.Text
        ElseIf ddlFecha.SelectedIndex = 2 Then
            RangoFechas = Me.ddlFecha.SelectedItem.ToString & " " & Me.txtFInicio.Text
        ElseIf ddlFecha.SelectedIndex = 3 Then
            RangoFechas = Me.ddlFecha.SelectedItem.ToString & " " & Me.txtFInicio.Text
        ElseIf ddlFecha.SelectedIndex = 4 Then
            RangoFechas = Me.ddlFecha.SelectedItem.ToString & " " & Me.txtFInicio.Text
        ElseIf ddlFecha.SelectedIndex = 5 Then
            RangoFechas = Me.ddlFecha.SelectedItem.ToString & " " & Me.txtFInicio.Text
        End If

        Return RangoFechas
    End Function

    'Private Sub GuardaChecksRutas()
    '    Dim dt As Data.DataTable = Session("tblRutas")
    '    Dim indFila As Integer = GridView1.PageIndex * GridView1.PageSize
    '    For i As Integer = 0 To GridView1.Rows.Count - 1
    '        dt.Rows(i + indFila)("checks") = CType(GridView1.Rows(i).Cells(0).FindControl("RowLevelCheckBox"), CheckBox).Checked

    '    Next
    'End Sub

    'Private Sub GuardaChecksClientes()
    '    Dim dt As Data.DataTable = Session("tblClientes")
    '    Dim indFila As Integer = GridView2.PageIndex * GridView2.PageSize
    '    For i As Integer = 0 To GridView2.Rows.Count - 1
    '        dt.Rows(i + indFila)("checks") = CType(GridView2.Rows(i).Cells(0).FindControl("RowLevel"), CheckBox).Checked
    '    Next
    'End Sub

    'Private Sub GuardaChecksProductos()
    '    Dim dt As Data.DataTable = Session("tblProductos")
    '    Dim indFila As Integer = GridView3.PageIndex * GridView3.PageSize
    '    For i As Integer = 0 To GridView3.Rows.Count - 1
    '        dt.Rows(i + indFila)("checks") = CType(GridView3.Rows(i).Cells(0).FindControl("RowLevel"), CheckBox).Checked
    '    Next
    'End Sub

    Public Function ArchivoConsultaReporte(ByVal pvTipoReporte As Integer, ByVal pvParametros As Hashtable, ByVal pvConsultas As Hashtable) As Boolean
        Try
            Dim DataSetConfig As New DataSet("Reporte")
            ' Crear las tablas 
            'General
            Dim DataTableGeneral As New DataTable("General")
            DataTableGeneral.Columns.Add("TipoReporte", System.Type.GetType("System.Int16"))
            DataSetConfig.Tables.Add(DataTableGeneral)

            Dim refDataRowNueva As DataRow
            refDataRowNueva = DataTableGeneral.NewRow()
            refDataRowNueva("TipoReporte") = pvTipoReporte
            DataTableGeneral.Rows.Add(refDataRowNueva)

            'Parametros
            Dim DataTableParametros As New DataTable("Parametros")
            For Each sKey As String In pvParametros.Keys
                DataTableParametros.Columns.Add(sKey, System.Type.GetType("System.String"))
            Next
            DataSetConfig.Tables.Add(DataTableParametros)

            refDataRowNueva = DataTableParametros.NewRow()
            For Each sKey As String In pvParametros.Keys
                refDataRowNueva(sKey) = pvConsultas(sKey)
            Next
            DataTableParametros.Rows.Add(refDataRowNueva)

            'Consultas
            Dim DataTableConsultas As New DataTable("Consultas")
            For Each sKey As String In pvConsultas.Keys
                DataTableConsultas.Columns.Add(sKey, System.Type.GetType("System.String"))
            Next
            DataSetConfig.Tables.Add(DataTableConsultas)

            refDataRowNueva = DataTableConsultas.NewRow()
            For Each sKey As String In pvConsultas.Keys
                refDataRowNueva(sKey) = pvConsultas(sKey)
            Next
            DataTableConsultas.Rows.Add(refDataRowNueva)



            ' Verificar que exista el directorio
            If Not Directory.Exists(Server.MapPath("Consultas")) Then
                Directory.CreateDirectory(Server.MapPath("Consultas"))
            End If
            ' Escribir el contenido del dataset en XML 
            'DateTime.Now.Ticks.ToString()
            Dim XmlTextWriterDicc As New System.Xml.XmlTextWriter(Server.MapPath("Consultas\" & DateTime.Now.Ticks.ToString()), System.Text.Encoding.Unicode)
            ' Escribir en el archivo XML
            DataSetConfig.WriteXml(XmlTextWriterDicc, XmlWriteMode.IgnoreSchema)
            ' Cerrar el flujo XML
            XmlTextWriterDicc.Close()
            DataTableGeneral.Dispose()
            DataTableParametros.Dispose()
            DataTableConsultas.Dispose()
            DataSetConfig.Dispose()
            Return True
            'Catch ExcA As XmlException
            '    MsgBox(ExcA.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "Guardar")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "Guardar")
        End Try
        Return False
    End Function

#End Region

#Region "Consultas"
    Private Function ConsultaVentasPorEsquemaPanque(ByVal ins As DBConexion.cConexionSQL, ByVal pvConversionKg As Boolean, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvProductos As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        Dim sCondicionEsquema As String = "where 1=1 "
        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "TRP.FechaHoraalta")
        End If
        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "VIS.RUTClave")
        pvCondicion = strWhereCentrosDistribucion(pvCondicion, "ALN.Clave")
        sCondicionEsquema = strWhereEsquema(sCondicionEsquema, pvProductos, "ESQ.EsquemaID")

        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("declare @CobrarVentas as bit ")
        sConsulta.AppendLine("set @CobrarVentas = (select top 1 CobrarVentas from ConHist order by CONHistFechaInicio desc) ")
        sConsulta.AppendLine("declare @Tipo smallint ")
        sConsulta.AppendLine("if @CobrarVentas = 1 ")
        sConsulta.AppendLine("set @Tipo=1 ")
        sConsulta.AppendLine("else ")
        sConsulta.AppendLine("set @Tipo=8 ")

        sConsulta.AppendLine("if (select object_id('tempdb..#VentaEsquemaPanque')) is not null drop table #VentaEsquemaPanque ")
        sConsulta.AppendLine("select * into #VentaEsquemaPanque from ( ")
        sConsulta.AppendLine("select ALN.Clave as ALNClave, ALN.Clave + ' ' + ALN.Nombre as CEDI, VEN.Nombre as Vendedor, VIS.RUTClave, ")
        sConsulta.AppendLine("(select Descripcion from dbo.Ruta where (RUTClave = VIS.RUTClave)) as Ruta, ")
        sConsulta.AppendLine("convert(datetime, convert(varchar(20), TRP.FechaHoraAlta, 112)) as Fecha, TRP.TransProdID, TPD.ProductoClave, ")
        sConsulta.AppendLine("(select Nombre from dbo.Producto where (ProductoClave = TPD.ProductoClave)) as Producto, TPD.TipoUnidad, TPD.Cantidad as CantidadVenta, ")
        sConsulta.AppendLine("TPD.Subtotal as ImporteVenta, 0 as CantidadDevolucion, 0 as ImporteDevolucion, 0 as CantidadCambio, 0 as ImporteCambio ")
        sConsulta.AppendLine("from TransProd TRP ")
        sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ")
        sConsulta.AppendLine("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave ")
        sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI from AgendaVendedor) AGV on AGV.DiaClave = TRP.DiaClave and AGV.VendedorId = VIS.VendedorID ")
        sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorID ")
        sConsulta.AppendLine(pvCondicion & " ")
        sConsulta.AppendLine("and TRP.Tipo = @Tipo and TRP.TipoFase<>0 and tpd.promocion<>2 ")
        sConsulta.AppendLine("union all ")
        sConsulta.AppendLine("select ALN.Clave as ALNClave, ALN.Clave + ' ' + ALN.Nombre as CEDI, ")
        sConsulta.AppendLine("VEN.Nombre as Vendedor, VIS.RUTClave, ")
        sConsulta.AppendLine("(select Descripcion from dbo.Ruta  where (RUTClave = VIS.RUTClave)) as Ruta, ")
        sConsulta.AppendLine("convert(datetime, convert(varchar(20), TRP.FechaHoraAlta, 112)) as Expr1, TRP.TransProdID, TPD.ProductoClave, ")
        sConsulta.AppendLine("(select Nombre from dbo.Producto where (ProductoClave = TPD.ProductoClave)) as Producto, TPD.TipoUnidad, 0 as Expr2, 0 as Expr3, TPD.Cantidad, ")
        sConsulta.AppendLine("TPD.Cantidad * isnull ((select top 1 Precio from dbo.PrecioProductoVig where (TRP.FechaHoraAlta between PPVFechaInicio and FechaFin) and (ProductoClave = TPD.ProductoClave) and (PRUTipoUnidad= TPD.TipoUnidad) order by MFechaHora asc), 0) as Importe, ")
        sConsulta.AppendLine("0 as Expr4, 0 as Expr5 ")
        sConsulta.AppendLine("from TransProd TRP ")
        sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ")
        sConsulta.AppendLine("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave ")
        sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI from AgendaVendedor) AGV on AGV.DiaClave = TRP.DiaClave and AGV.VendedorId = VIS.VendedorID ")
        sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorID ")
        sConsulta.AppendLine(pvCondicion & " ")
        sConsulta.AppendLine("and TRP.Tipo = 3 and TRP.TipoFase = 1 and (TPD.PROMOCION<>2 OR TPD.PROMOCION IS NULL) ")
        sConsulta.AppendLine("union all ")
        sConsulta.AppendLine("select ALN.Clave as ALNClave, ALN.Clave + ' ' + ALN.Nombre as CEDI, VEN.Nombre as Vendedor, VIS.RUTClave, ")
        sConsulta.AppendLine("(select Descripcion from dbo.Ruta where (RUTClave = VIS.RUTClave)) as Ruta, ")
        sConsulta.AppendLine("convert(datetime, convert(varchar(20), TRP.FechaHoraAlta, 112)) as Expr1, TRP.TransProdID, TPD.ProductoClave, ")
        sConsulta.AppendLine("(select Nombre from dbo.Producto where (ProductoClave = TPD.ProductoClave)) as Producto, TPD.TipoUnidad, 0 as Expr2, 0 as Expr3, 0 as Expr4, 0 as Expr5, TPD.Cantidad, TPD.SubTotal as Importe ")
        sConsulta.AppendLine("from TransProd TRP ")
        sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ")
        sConsulta.AppendLine("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave ")
        sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI from AgendaVendedor) AGV on AGV.DiaClave = TRP.DiaClave and AGV.VendedorId = VIS.VendedorID ")
        sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorID ")
        sConsulta.AppendLine(pvCondicion & " ")
        sConsulta.AppendLine("and TRP.Tipo = 9 and TRP.TipoFase = 1 and TRP.TipoMovimiento = 1 and (TPD.PROMOCION<>2 OR TPD.PROMOCION IS NULL)")
        sConsulta.AppendLine(")as t1 ")

        If pvConversionKg Then
            sConsulta.AppendLine("select VRE.ALNClave, VRE.CEDI, PRO.ProductoClave as Clave, ESQ.Clave + '-' + ESQ.Nombre as Esquema, VRE.Fecha, VRE.Vendedor, ")
            sConsulta.AppendLine("VRE.RutClave as Ruta, isnull(VRE.Ruta, '') as RutaNombre, VRE.Producto, ")
            sConsulta.AppendLine("(select top 1 VAD.Descripcion from VAVDescripcion VAD where VAD.VARCodigo = 'UNIDADV' and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' and VAD.VAVClave = VRE.TipoUnidad) as Unidad, ")
            sConsulta.AppendLine("sum(VRE.CantidadVenta) as VentaCant, sum(VRE.CantidadVenta * PRD.Factor) as VentaCantUnit, isnull(sum(VRE.CantidadVenta * PRU.KgLts), 0) as VentaKg, ")
            sConsulta.AppendLine("sum(VRE.ImporteVenta) as VentaDinero, sum(VRE.CantidadDevolucion) as DevolucionCant, sum(VRE.CantidadDevolucion * PRD.Factor) as DevolucionCantUnit, ")
            sConsulta.AppendLine("isnull(sum(VRE.CantidadDevolucion * PRU.KgLts), 0) as DevolucionKg, sum(VRE.ImporteDevolucion) as DevolucionDinero, ")
            sConsulta.AppendLine("sum(VRE.CantidadCambio) as CambioCant, sum(VRE.CantidadCambio * PRD.Factor) as CambioCantUnit, ")
            sConsulta.AppendLine("isnull(sum(VRE.CantidadCambio * PRU.KgLts), 0) as CambioKg, sum(VRE.ImporteCambio) as CambioDinero ")
            sConsulta.AppendLine("from #VentaEsquemaPanque VRE ")
            sConsulta.AppendLine("inner join Producto PRO on VRE.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRO.ProductoClave = PRD.ProductoClave and VRE.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
            sConsulta.AppendLine("inner join ProductoEsquema PRS on PRS.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join Esquema ESQ on ESQ.EsquemaId = PRS.EsquemaId ")
            sConsulta.AppendLine("inner join ProductoUnidad PRU on PRU.ProductoClave = PRD.ProductoClave and PRU.PRUTipoUnidad = PRD.PRUTipoUnidad ")
            sConsulta.AppendLine(sCondicionEsquema & " ")
            sConsulta.AppendLine("group by VRE.Fecha, VRE.Vendedor, VRE.RutClave, VRE.Ruta, VRE.Producto, VRE.TipoUnidad, ESQ.Clave + '-' + ESQ.Nombre, PRO.ProductoClave, VRE.CEDI, VRE.ALNClave ")
        Else
            sConsulta.AppendLine("select VRE.ALNClave, VRE.CEDI, PRO.ProductoClave as clave, ESQ.Clave + '-' + ESQ.Nombre as Esquema, VRE.Fecha, VRE.Vendedor, VRE.RutClave as Ruta, ")
            sConsulta.AppendLine("isnull(VRE.Ruta, '') as RutaNombre, VRE.Producto, ")
            sConsulta.AppendLine("(select top 1 VAD.Descripcion from VAVDescripcion VAD where VAD.VARCodigo = 'UNIDADV' and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' and VAD.VAVClave = VRE.TipoUnidad) as Unidad, ")
            sConsulta.AppendLine("sum(VRE.CantidadVenta) as VentaCant, sum(VRE.CantidadVenta * PRD.Factor) as VentaCantUnit, sum(VRE.ImporteVenta) as VentaDinero, ")
            sConsulta.AppendLine("sum(VRE.CantidadDevolucion) as DevolucionCant, sum(VRE.CantidadDevolucion * PRD.Factor) as DevolucionCantUnit, sum(VRE.ImporteDevolucion) as DevolucionDinero, ")
            sConsulta.AppendLine("sum(VRE.CantidadCambio) as CambioCant, sum(VRE.CantidadCambio * PRD.Factor) as CambioCantUnit, sum(VRE.ImporteCambio) as CambioDinero ")
            sConsulta.AppendLine("from #VentaEsquemaPanque VRE ")
            sConsulta.AppendLine("inner join Producto PRO on VRE.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRO.ProductoClave = PRD.ProductoClave and VRE.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
            sConsulta.AppendLine("inner join ProductoEsquema PRS on PRS.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join Esquema ESQ on ESQ.EsquemaId = PRS.EsquemaId ")
            sConsulta.AppendLine(sCondicionEsquema & " ")
            sConsulta.AppendLine("group by VRE.Fecha, VRE.Vendedor, VRE.RutClave, VRE.Ruta, VRE.Producto, VRE.TipoUnidad, ESQ.Clave + '-' + ESQ.Nombre, PRO.ProductoClave, VRE.CEDI, VRE.ALNClave ")
        End If
        sConsulta.AppendLine("drop table #VentaEsquemaPanque ")
        sConsulta.AppendLine("set nocount off ")

        'Session("Query") = sConsulta.ToString
        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        Return True
    End Function

    Private Function ConsultaClientesPorRutaPanque(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder

        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "FNG.Fecha")
        End If
        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "RUT.RUTClave")
        pvCondicion = strWhereCentrosDistribucion(pvCondicion, "ALM.Clave")
        sConsulta.AppendLine("declare @fechahoy as datetime")
        sConsulta.AppendLine("set @fechahoy = getdate()")
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("SELECT AlmacenId, ALMClave, ALMNombre, VendedorId, VENNombre, Fecha, RUTClave, RUTDescripcion, FechaInicio, Orden, ")
        sConsulta.AppendLine("CLIClave, RazonSocial, NombreContacto, ")
        sConsulta.AppendLine("SUBSTRING((CLD.Calle + ' ' + (SELECT CASE WHEN CLD.Numero IS NULL THEN '' ELSE CLD.Numero END) + ' '),1,26) AS Domicilio, ")
        sConsulta.AppendLine("SUBSTRING(CLD.Colonia,1,12) AS Colonia, TelefonoContacto, SUBSTRING(CLD.Poblacion,1,17) AS Poblacion, CLD.Entidad ")
        sConsulta.AppendLine("FROM ")
        sConsulta.AppendLine("( ")
        sConsulta.AppendLine("SELECT distinct ALM.AlmacenId, ALM.Clave AS ALMClave, ALM.Nombre AS ALMNombre, VEN.VendedorId, VEN.Nombre AS VENNombre, FNG.Fecha, ")
        sConsulta.AppendLine("RUT.RUTClave, RUT.Descripcion AS RUTDescripcion, FRE.FechaInicio, ")
        sConsulta.AppendLine("(SELECT TOP 1 ClienteDomicilioId FROM ClienteDomicilio CLD1 WHERE CLD1.Tipo=2 AND CLD1.ClienteClave=CLI.ClienteClave ORDER BY CLD1.MFechaHora desc) as ClienteDomicilioId, ")
        sConsulta.AppendLine("SEC.Orden, CLI.Clave AS CLIClave, CLI.ClienteClave, SUBSTRING(CLI.RazonSocial,1,40) AS RazonSocial, SUBSTRING(CLI.NombreContacto,1,27) AS NombreContacto, CLI.TelefonoContacto ")
        sConsulta.AppendLine("FROM Esquema ESQ ")
        sConsulta.AppendLine("INNER JOIN VendedorEsquema VEE ON VEE.EsquemaId=ESQ.EsquemaId AND VEE.TipoEstado=1 ")
        sConsulta.AppendLine("INNER JOIN Vendedor VEN ON VEN.VendedorId=VEE.VendedorId AND VEN.TipoEstado=1 AND VEN.Baja=0 ")
        sConsulta.AppendLine("INNER JOIN (SELECT VCH.VendedorId, MAX(VCHFechaInicial) AS VCHFechaInicial FROM VENCentroDistHist VCH ")
        sConsulta.AppendLine("INNER JOIN Almacen ALM ON ALM.AlmacenId=VCH.AlmacenId AND ALM.Tipo=1 ")
        sConsulta.AppendLine("GROUP BY VCH.VendedorId) VCH1 ON VCH1.VendedorId=VEN.VendedorId ")
        sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCH ON VCH.VendedorId=VCH1.VendedorId AND VCH.VCHFechaInicial=VCH1.VCHFechaInicial ")
        sConsulta.AppendLine("INNER JOIN Almacen ALM ON ALM.AlmacenId=VCH.AlmacenId ")
        sConsulta.AppendLine("INNER JOIN VENRUT VER ON VER.VendedorId=VEN.VendedorId AND VER.TipoEstado=1 ")
        sConsulta.AppendLine("INNER JOIN Ruta RUT ON RUT.RUTClave=VER.RUTClave AND RUT.TipoEstado=1 ")
        sConsulta.AppendLine("INNER JOIN ClienteEsquema CLE ON CLE.EsquemaId=ESQ.EsquemaId AND CLE.TipoEstado=1 ")
        sConsulta.AppendLine("INNER JOIN Cliente CLI ON CLI.ClienteClave=CLE.ClienteClave ")
        sConsulta.AppendLine("INNER JOIN ClienteDomicilio CLD ON CLD.ClienteClave=CLI.ClienteClave AND CLD.Tipo=2 ")
        sConsulta.AppendLine("INNER JOIN Secuencia SEC ON SEC.ClienteClave=CLE.ClienteClave AND SEC.RUTClave=RUT.RUTClave AND SEC.Orden>0 ")
        sConsulta.AppendLine("INNER JOIN Frecuencia FRE ON FRE.FrecuenciaClave=SEC.FrecuenciaClave ")
        sConsulta.AppendLine("INNER JOIN FNGeneraDias(@fechahoy) FNG ON FNG.FrecuenciaClave=FRE.FrecuenciaClave ")
        sConsulta.AppendLine(pvCondicion & " ")
        sConsulta.AppendLine("AND ESQ.Tipo=1 AND ESQ.TipoEstado=1 ")
        sConsulta.AppendLine(") AS Resultado ")
        sConsulta.AppendLine("INNER JOIN ClienteDomicilio CLD ON CLD.ClienteClave=Resultado.ClienteClave AND CLD.ClienteDomicilioId=Resultado.ClienteDomicilioID ")
        sConsulta.AppendLine("ORDER BY Resultado.Orden ")
        sConsulta.AppendLine("set nocount off ")

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        Return True
    End Function

    Private Function ConsultaIndicadorVenta(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvClientes As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        ''       pvCondicion = pvCondicion.Replace("where", " and ")
        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "Vis.FechaHoraInicial")
        End If
        pvCondicion = strWhereClientes(pvCondicion, pvClientes, "Vis.clienteclave")
        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "R.rutclave")
        pvCondicion = strWhereCentrosDistribucion(pvCondicion, "AL.clave")
        '--Gastos del vendedor
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        'sConsulta.AppendLine("select  CONVERT(VARCHAR,Vis.fechahorainicial,103) as fecha,VEN.NOMBRE as vendedor,R.DESCRIPCION as ruta, (select count(distinct ag.clienteclave) from agendavendedor ag where Vis.vendedorid=Ag.vendedorid and Vis.DIaclave=Ag.DIaclave and Vis.rutclave=Ag.rutclave ) as itinerario,count(distinct vis.clienteclave)-count(distinct visFuera.clienteclave) as Visitados,cast(count(distinct vis.clienteclave)-count(distinct visFuera.clienteclave) as decimal(10,5))/cast((select count(distinct ag.clienteclave) from agendavendedor ag where Vis.vendedorid=Ag.vendedorid and Vis.DIaclave=Ag.DIaclave and Vis.rutclave=Ag.rutclave )as decimal(10,5))*100 as Eficiencia ,count(distinct t.clienteclave)as visitadosventa,cast(count(distinct t.clienteclave) as decimal(10,5))/(select count(distinct ag.clienteclave) from agendavendedor ag where Vis.vendedorid=Ag.vendedorid and Vis.DIaclave=Ag.DIaclave and Vis.rutclave=Ag.rutclave )*100 as efectividad,(select count(distinct ag.clienteclave) from agendavendedor ag where Vis.vendedorid=Ag.vendedorid and Vis.DIaclave=Ag.DIaclave and Vis.rutclave=Ag.rutclave )-(count(distinct vis.clienteclave)-count(distinct visFuera.clienteclave)) as novisitados,count(distinct visFuera.clienteclave) as fuerafrecuencia,count(distinct tfuera.clienteclave)as fuerafrecuenciaV, sum(t.total)/CASE WHEN count(distinct tFUERA.clienteclave)=0 THEN 1 ELSE count(distinct tFUERA.clienteclave) END   as totalventa FROM VISITA VIS inner join vendedor Ven on Ven.vendedorid=vis.vendedorid INNER JOIN VENCENTRODISTHIST VENCEDI ON VENCEDI.VENDEDORID=VEN.VENDEDORID AND Vis.FechaHoraInicial BETWEEN VENCEDI.VCHFECHAINICIAL AND VENCEDI.FECHAFINAL INNER JOIN ALMACEN AL ON AL.ALMACENID=VENCEDI.ALMACENID inner join ruta R on R.rutclave=vis.rutclave  left join transprod t  on vis.visitaclave=t.visitaclave and  vis.fuerafrecuencia=0 and vis.diaclave=t.diaclave and t.tipo=1 and t.tipofase<>0 left join visita visFuera on visFUERA.fuerafrecuencia=1 and R.rutclave=visFUERA.rutclave and CONVERT(VARCHAR,Vis.fechahorainicial,103)=CONVERT(VARCHAR,Visfuera.fechahorainicial,103) and vis.vendedorid=visfuera.vendedorid left join transprod tfuera on visfuera.visitaclave=tfuera.visitaclave and tfuera.tipo=1 and tfuera.tipofase<>0    ")
        'sConsulta.AppendLine(" " + pvCondicion)

        'sConsulta.AppendLine("select  fecha, vendedor, ruta, sum(itinerario) as itinerario, sum(Visitados) as Visitados, ")
        'sConsulta.AppendLine("sum(Eficiencia) as Eficiencia, sum(visitadosventa) as visitadosventa, sum(efectividad) as efectividad, sum(novisitados) as novisitados, ")
        'sConsulta.AppendLine("sum(fuerafrecuencia) as fuerafrecuencia, sum(fuerafrecuenciaV) as fuerafrecuenciaV, isnull(sum(totalventa ),0) as totalventa  ")
        'sConsulta.AppendLine("FROM ( select  CONVERT(VARCHAR,Vis.fechahorainicial,103) as fecha, ")
        'sConsulta.AppendLine("VEN.NOMBRE as vendedor,R.DESCRIPCION as ruta,  ")
        'sConsulta.AppendLine("(	select count(distinct ag.clienteclave)  ")
        'sConsulta.AppendLine("from agendavendedor ag  ")
        'sConsulta.AppendLine("where Vis.vendedorid=Ag.vendedorid and Vis.DIaclave=Ag.DIaclave and Vis.rutclave=Ag.rutclave ) as itinerario, ")
        'sConsulta.AppendLine("count(distinct vis.clienteclave) as Visitados, ")
        'sConsulta.AppendLine("cast(count(distinct vis.clienteclave) as decimal(10,5))/cast(( ")
        'sConsulta.AppendLine("select count(distinct ag.clienteclave)  ")
        'sConsulta.AppendLine("from agendavendedor ag  ")
        'sConsulta.AppendLine("where Vis.vendedorid=Ag.vendedorid and Vis.DIaclave=Ag.DIaclave and Vis.rutclave=Ag.rutclave )as decimal(10,5))*100 as Eficiencia , ")
        'sConsulta.AppendLine("count(distinct t.clienteclave)as visitadosventa, ")
        'sConsulta.AppendLine("cast(count(distinct t.clienteclave) as decimal(10,5))/( ")
        'sConsulta.AppendLine("select count(distinct ag.clienteclave)  ")
        'sConsulta.AppendLine("from agendavendedor ag ")
        'sConsulta.AppendLine("where Vis.vendedorid=Ag.vendedorid and Vis.DIaclave=Ag.DIaclave and Vis.rutclave=Ag.rutclave )*100 as efectividad, ")
        'sConsulta.AppendLine("(	select count(distinct ag.clienteclave) ")
        'sConsulta.AppendLine("from agendavendedor ag  ")
        'sConsulta.AppendLine("where Vis.vendedorid=Ag.vendedorid and Vis.DIaclave=Ag.DIaclave and Vis.rutclave=Ag.rutclave )-(count(distinct vis.clienteclave)) as novisitados, ")

        sConsulta.AppendLine("select  fecha, vendedor, ruta, sum(itinerario) as itinerario, sum(Visitados) as Visitados, ")
        sConsulta.AppendLine("sum(Eficiencia) as Eficiencia, 	sum(visitadosventa) as visitadosventa, 	sum(efectividad) as efectividad, ")
        sConsulta.AppendLine("sum(novisitados) as novisitados, sum(fuerafrecuencia) as fuerafrecuencia, sum(fuerafrecuenciaV) as fuerafrecuenciaV, sum(totalventa ) as totalventa  ")
        sConsulta.AppendLine("FROM ( select  fecha, vendedor, ruta, itinerario, Visitados, ")
        sConsulta.AppendLine("case itinerario when 0 then 0 else  (Eficiencia / cast(itinerario as decimal(10,5)))*100 end as Eficiencia, ")
        sConsulta.AppendLine("visitadosventa, case itinerario when 0 then 0 else efectividad / cast(itinerario as decimal(10,5))*100 end as efectividad, ")
        sConsulta.AppendLine("case itinerario when 0 then 0 else cast(itinerario as decimal(10,5)) - novisitados end as novisitados, ")
        sConsulta.AppendLine("fuerafrecuencia, fuerafrecuenciaV, isnull(totalventa,0) as totalventa, diaclave, vendedorid, rutclave ")
        sConsulta.AppendLine("FROM ( select  CONVERT(VARCHAR,Vis.fechahorainicial,103) as fecha, VEN.NOMBRE as vendedor, R.DESCRIPCION as ruta, ")
        sConsulta.AppendLine("(select count(distinct ag.clienteclave) from agendavendedor ag where Vis.vendedorid=Ag.vendedorid and Vis.DIaclave=Ag.DIaclave and Vis.rutclave=Ag.rutclave ) as itinerario, ")
        sConsulta.AppendLine("count(distinct vis.clienteclave) as Visitados, cast(count(distinct vis.clienteclave) as decimal(10,5)) as Eficiencia , ")
        sConsulta.AppendLine("count(distinct t.clienteclave)as visitadosventa, cast(count(distinct t.clienteclave) as decimal(10,5)) as efectividad, (count(distinct vis.clienteclave)) as novisitados, ")
        sConsulta.AppendLine("(0) as fuerafrecuencia, ")
        sConsulta.AppendLine("(0)as fuerafrecuenciaV,  ")
        sConsulta.AppendLine("sum(t.total)   as totalventa , vis.diaclave,vis.vendedorid,vis.rutclave ")
        sConsulta.AppendLine("FROM VISITA VIS inner join vendedor Ven on Ven.vendedorid=vis.vendedorid  ")
        sConsulta.AppendLine("INNER JOIN VENCENTRODISTHIST VENCEDI ON VENCEDI.VENDEDORID=VEN.VENDEDORID AND Vis.FechaHoraInicial  ")
        sConsulta.AppendLine("BETWEEN VENCEDI.VCHFECHAINICIAL AND VENCEDI.FECHAFINAL  ")
        sConsulta.AppendLine("INNER JOIN ALMACEN AL ON AL.ALMACENID=VENCEDI.ALMACENID  ")
        sConsulta.AppendLine("inner join ruta R on R.rutclave=vis.rutclave   ")
        sConsulta.AppendLine("left join transprod t  on vis.visitaclave=t.visitaclave and  vis.diaclave=t.diaclave and t.tipo=1 and t.tipofase<>0  ")
        sConsulta.AppendLine(" " + pvCondicion)
        sConsulta.AppendLine(" and vis.fuerafrecuencia=0 ")
        sConsulta.AppendLine("GROUP BY  CONVERT(VARCHAR,Vis.fechahorainicial,103),ven.nombre,r.descripcion,vis.diaclave,vis.vendedorid,vis.rutclave  ")
        sConsulta.AppendLine(")as Tabla UNION ALL ")
        sConsulta.AppendLine("select  CONVERT(VARCHAR,Vis.fechahorainicial,103) as fecha, ")
        sConsulta.AppendLine("VEN.NOMBRE as vendedor,R.DESCRIPCION as ruta,  ")
        sConsulta.AppendLine("(0) as itinerario,(0) as Visitados,(0) as Eficiencia ,(0)as visitadosventa,	(0) as efectividad,	(0) as novisitados, ")
        sConsulta.AppendLine("count(distinct VIS.clienteclave) as fuerafrecuencia, count(distinct t.clienteclave)as fuerafrecuenciaV,  ")
        sConsulta.AppendLine("(0) as totalventa , vis.diaclave,vis.vendedorid,vis.rutclave ")
        sConsulta.AppendLine("FROM VISITA VIS  ")
        sConsulta.AppendLine("inner join vendedor Ven on Ven.vendedorid=vis.vendedorid  ")
        sConsulta.AppendLine("INNER JOIN VENCENTRODISTHIST VENCEDI ON VENCEDI.VENDEDORID=VEN.VENDEDORID AND Vis.FechaHoraInicial  ")
        sConsulta.AppendLine("BETWEEN VENCEDI.VCHFECHAINICIAL AND VENCEDI.FECHAFINAL  ")
        sConsulta.AppendLine("INNER JOIN ALMACEN AL ON AL.ALMACENID=VENCEDI.ALMACENID  ")
        sConsulta.AppendLine("inner join ruta R on R.rutclave=vis.rutclave ")
        sConsulta.AppendLine("left join transprod t  on vis.visitaclave=t.visitaclave and   vis.diaclave=t.diaclave and t.tipo=1 and t.tipofase<>0 ")
        sConsulta.AppendLine(" " + pvCondicion)
        sConsulta.AppendLine(" and vis.fuerafrecuencia=1 ")
        sConsulta.AppendLine("GROUP BY  CONVERT(VARCHAR,Vis.fechahorainicial,103),ven.nombre,r.descripcion,vis.diaclave,vis.vendedorid,vis.rutclave ) AS T ")
        sConsulta.AppendLine("GROUP BY  fecha,vendedor,ruta, diaclave,vendedorid,rutclave ")
        'sConsulta.AppendLine(" ")
        'sConsulta.AppendLine(" GROUP BY  CONVERT(VARCHAR,Vis.fechahorainicial,103),ven.nombre,r.descripcion,vis.diaclave,vis.vendedorid,vis.rutclave ")

        pvCondicion = sConsulta.ToString()

        'Session("Query") = sConsulta.ToString
        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        Return True
    End Function

    Private Function ConsultaFacturas(ByVal ins As dbconexion.cConexionSQL, ByVal pvDetallado As Boolean, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvClientes As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "TRP.FechaHoraAlta")
        End If
        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "RUT.RUTClave")
        pvCondicion = strWhereCentrosDistribucion(pvCondicion, "ALN.Clave")
        'pvCondicion = strWhereClientes(pvCondicion, pvClientes, "CLI.RazonSocial")
        pvCondicion = strWhereClientes(pvCondicion, pvClientes, "CLI.ClienteClave")
        If pvDetallado Then
            'Se guardan en una temporal los TransProdDetalle con el descuento del cliente calculado, para solo llamar la funcion 1 vez y se tarde menos
            'Cuando se Cambien los filtros a las claves los inner join de esta consulta se pueden disminuir
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("SET NOCOUNT ON if (select object_id('tempdb..#Tmp1')) is not null drop table #Tmp1 ")
            sConsulta.AppendLine("Select TPD.TransProdID,TPD.TransProdDetalleID,TPD.ProductoClave,TipoUnidad,Precio,Cantidad,TPD.Promocion, TPD.DescuentoImp,TPD.Subtotal,TPD.Impuesto, ")
            sConsulta.AppendLine("(SELECT (CASE WHEN sum(DesImporte) IS NULL THEN 0 ELSE sum(DesImporte) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) as DescuentoCliente, ")
            sConsulta.AppendLine("(SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE sum(DesImpuesto) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) as DescuentoClienteImpuesto ")
            sConsulta.AppendLine("into #Tmp1 ")
            sConsulta.AppendLine("from TransProdDetalle TPD inner join TransProd TRP on TPD.TransProdID = TRP.TransProdID and TRP.Tipo = 1 and TRP.TipoFase = 3 ")
            sConsulta.AppendLine("inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave ")
            sConsulta.AppendLine("inner join Cliente CLI on CLI.ClienteClave = TRP.ClienteClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
            'sConsulta.AppendLine("inner join AgendaVendedor AGV on TRP.DiaClave = AGV.DiaClave and VEN.VendedorId = AGV.VendedorId  and VIS.ClienteClave = AGV.ClienteClave and VIS.RUTClave = AGV.RUTClave  ")
            sConsulta.AppendLine("inner join Ruta RUT on VIS.RUTClave = RUT.RUTClave ")
            'sConsulta.AppendLine(pvCondicion)

            sConsulta.AppendLine("select TRP.FechaCaptura as Fecha, VEN.Nombre AS Vendedor, RUT.RUTClave + ' ' + RUT.Descripcion as Ruta, TRP.Folio, TRP.TransProdID, CLI.RazonSocial +' '+cli.nombrecontacto AS Cliente, TPD.ProductoClave AS Clave, PRO.Nombre AS Producto, VAD.Descripcion AS Unidad, ")
            sConsulta.AppendLine("TPD.Precio as PrecioU, ALN.Clave + ' ' + ALN.Nombre as CEDI, sum(TPD.Cantidad) AS Cant, ")
            'sConsulta.AppendLine("sum(case when TPD.Promocion = 1 then TPD.Subtotal else TPD.Precio * TPD.Cantidad end) as SubTotal, ")
            sConsulta.AppendLine("sum(TPD.Precio * TPD.Cantidad) as SubTotal, ")
            sConsulta.AppendLine("sum(DescuentoCliente) as DescuentoCliente, sum(((TPD.SubTotal - DescuentoCliente) * TRP2.DescVendPor / 100)) as DescVend, sum(TPD.DescuentoImp) as DescProducto,")
            sConsulta.AppendLine("sum(TPD.Impuesto - DescuentoClienteImpuesto- ((TPD.Impuesto - DescuentoClienteImpuesto) * TRP2.DescVendPor / 100)) as Impuesto, ")
            sConsulta.AppendLine("sum((TPD.SubTotal - DescuentoCliente - ((TPD.SubTotal-DescuentoCliente) * TRP2.DescVendPor / 100) ) + ((TPD.Impuesto - DescuentoClienteImpuesto) - ((TPD.Impuesto-DescuentoClienteImpuesto) * TRP2.DescVendPor / 100))) as Total ")
            sConsulta.AppendLine("from TransProd TRP inner join TransProd TRP2 on TRP.TransProdId = TRP2.FacturaId ")
            sConsulta.AppendLine("inner join Cliente CLI on CLI.ClienteClave = TRP2.ClienteClave ")
            sConsulta.AppendLine("inner join #Tmp1 TPD on TRP2.TransProdId = TPD.TransProdId ")
            sConsulta.AppendLine("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VARCodigo = 'UNIDADV' and VAD.VAVClave = TPD.TipoUnidad and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' ")
            sConsulta.AppendLine("inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join vencentrodisthist hist on hist.vendedorid=VEN.VendedorId and vchfechainicial<=TRP.FechaCaptura and fechafinal>TRP.FechaCaptura ")
            sConsulta.AppendLine("inner join  Almacen ALN on hist.almacenid = ALN.almacenid ")
            sConsulta.AppendLine("inner join Ruta RUT on VIS.RUTClave = RUT.RUTClave  ")
            sConsulta.AppendLine(pvCondicion & " and TRP.tipo = 8 and TRP.tipofase <> 0 ")
            sConsulta.AppendLine("group by TRP.FechaCaptura,VEN.Nombre, RUT.RUTClave + ' ' + RUT.Descripcion, TRP.Folio, TRP.TransProdID, CLI.RazonSocial,cli.nombrecontacto, TPD.ProductoClave ,PRO.Nombre , VAD.Descripcion ,TPD.Promocion,TPD.Precio, ALN.Clave + ' ' + ALN.Nombre ")
            sConsulta.AppendLine("SET NOCOUNT OFF ")
            'Sin Descuentos
            'sConsulta.AppendLine("select distinct TRP.FechaCaptura as Fecha, VEN.Nombre AS Vendedor, RUT.RUTClave + ' ' + RUT.Descripcion as Ruta, ")
            'sConsulta.AppendLine("TRP.Folio, CLI.RazonSocial AS Cliente, TPD.ProductoClave AS Clave, PRO.Nombre AS Producto, VAD.Descripcion AS Unidad, ")
            'sConsulta.AppendLine("TPD.Precio AS PrecioU, ALN.Clave + ' ' + ALN.Nombre as CEDI, TPD.Cantidad AS Cant, TPD.Precio * TPD.Cantidad as SubTotal, ")
            'sConsulta.AppendLine("TPD.DescuentoImp + (TPD.SubTotal * case when DES.ValorAplicacion is null then 0 else DES.ValorAplicacion end / 100) as DescuentoCliente, ")
            'sConsulta.AppendLine("(TPD.SubTotal * TRP2.DescVendPor / 100) as DescVend, ")
            'sConsulta.AppendLine("TPD.Impuesto - (TPD.Impuesto * case when DES.ValorAplicacion is null then 0 else DES.ValorAplicacion end / 100) - (TPD.Impuesto * TRP2.DescVendPor / 100) - (TPD.Impuesto * TRP2.Bonificacion / TRP2.SubTotal) as Impuesto, ")
            'sConsulta.AppendLine("(TPD.SubTotal - (TPD.SubTotal * case when DES.ValorAplicacion is null then 0 else DES.ValorAplicacion end / 100) - (TPD.SubTotal * TRP2.DescVendPor / 100) - (TPD.SubTotal * TRP2.Bonificacion / TRP2.SubTotal)) + ")
            'sConsulta.AppendLine("(TPD.Impuesto - (TPD.Impuesto * case when DES.ValorAplicacion is null then 0 else DES.ValorAplicacion end / 100) - (TPD.Impuesto * TRP2.DescVendPor / 100) - (TPD.Impuesto * TRP2.Bonificacion / TRP2.Subtotal)) as Total, ")
            'sConsulta.AppendLine("isnull((select top 1 Importe from PromocionRegla PRR ")
            'sConsulta.AppendLine("inner join Promocion PRM on PRM.PromocionClave = PRR.PromocionClave and TPD.Cantidad >= PRR.Minimo and TPD.Cantidad <= PRR.Maximo ")
            'sConsulta.AppendLine("and TRP2.FechaCaptura > PRM.FechaInicial and TRP2.FechaCaptura < PRM.FechaFinal ")
            'sConsulta.AppendLine("inner join PromocionProducto PRP on TPD.ProductoClave = PRP.ProductoClave and PRP.PromocionClave = PRM.PromocionClave), 0) as Bonificacion ")
            'sConsulta.AppendLine("from TransProd TRP ")
            'sConsulta.AppendLine("inner join TransProd TRP2 on TRP.TransProdId = TRP2.FacturaId ")
            'sConsulta.AppendLine("inner join Cliente CLI on CLI.ClienteClave = TRP2.ClienteClave ")
            'sConsulta.AppendLine("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ")
            'sConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VARCodigo = 'UNIDADV' and VAD.VAVClave = TPD.TipoUnidad and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' ")
            'sConsulta.AppendLine("inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave ")
            'sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
            'sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI from AgendaVendedor) AGV on TRP2.DiaClave = AGV.DiaClave and VEN.VendedorId = AGV.VendedorId ")
            'sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            'sConsulta.AppendLine("inner join Ruta RUT on VIS.RUTClave = RUT.RUTClave ")
            'sConsulta.AppendLine("left join DesCliente DSC on TRP2.ClienteClave = DSC.ClienteClave ")
            'sConsulta.AppendLine("left join Descuento DES on DSC.DescuentoClave = DES.DescuentoClave ")
            'sConsulta.AppendLine(pvCondicion & " and TRP.tipo = 8 and TRP.tipofase <> 0 ")
        Else
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct TRP.TransProdId, TRP.FechaCaptura as Fecha, VEN.Nombre as Vendedor, RUT.RUTClave + ' ' + RUT.Descripcion as Ruta, ")
            sConsulta.AppendLine("TRP.Folio, CLI.RazonSocial+' '+cli.nombrecontacto as Cliente, CLI.Clave AS Clave, sum(TRP.Total) as Total, ALN.Clave + ' ' + ALN.Nombre as CEDI ")
            sConsulta.AppendLine("from TransProd TRP ")
            sConsulta.AppendLine("inner join TransProd TRP2 on TRP.TransProdId = TRP2.FacturaId ")
            sConsulta.AppendLine("inner join Cliente CLI on CLI.ClienteClave = TRP2.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join vencentrodisthist hist on hist.vendedorid=VEN.VendedorId and vchfechainicial<=TRP.FechaCaptura and fechafinal>TRP.FechaCaptura ")
            sConsulta.AppendLine("inner join  Almacen ALN on hist.almacenid = ALN.almacenid ")
            sConsulta.AppendLine("inner join Ruta RUT on VIS.RUTClave = RUT.RUTClave ")
            sConsulta.AppendLine(pvCondicion & " and TRP.Tipo = 8 and TRP.TipoFase <> 0 ")
            sConsulta.AppendLine("group by TRP.FechaCaptura, VEN.Nombre, RUT.RUTClave + ' ' + RUT.Descripcion, TRP.Folio, TRP.TransProdId, CLI.RazonSocial ,cli.nombrecontacto, CLI.Clave , ALN.Clave + ' ' + ALN.Nombre ")
        End If

        'Session("Query") = sConsulta.ToString
        '-----------------------------------------
        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt
        '-----------------------------------------

        'Query 2    
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("select CEDI, Clave, Producto, Unidad, sum(Cantidad) as Cantidad, ")
        sConsulta.AppendLine("sum((SubTotal - DescuentoCliente -((SubTotal - DescuentoCliente) * DescVendPor / 100)) + (Impuesto - DescuentoClienteImpuesto -((Impuesto - DescuentoClienteImpuesto) * DescVendPor / 100))) as Total ")
        sConsulta.AppendLine("FROM ")
        sConsulta.AppendLine("( ")
        sConsulta.AppendLine("select ALN.Clave + ' ' + ALN.Nombre as CEDI, TPD.ProductoClave as Clave, ")
        sConsulta.AppendLine("PRO.Nombre as Producto, VAD.Descripcion as Unidad, TPD.Cantidad, TPD.SubTotal, TRP2.DescVendPor, TPD.Impuesto, ")
        sConsulta.AppendLine("(SELECT (CASE WHEN sum(DesImporte) IS NULL THEN 0 ELSE sum(DesImporte) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TRP2.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) as DescuentoCliente, ")
        sConsulta.AppendLine("(SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE sum(DesImpuesto) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TRP2.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) as DescuentoClienteImpuesto ")
        sConsulta.AppendLine("from TransProd TRP ")
        sConsulta.AppendLine("inner join TransProd TRP2 on TRP.TransProdId = TRP2.FacturaId ")
        sConsulta.AppendLine("inner join Cliente CLI on CLI.ClienteClave = TRP2.ClienteClave ")
        sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP2.TransProdId = TPD.TransProdId ")
        sConsulta.AppendLine("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ")
        sConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VARCodigo = 'UNIDADV' and VAD.VAVClave = TPD.TipoUnidad and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' ")
        sConsulta.AppendLine("inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
        sConsulta.AppendLine("inner join Ruta RUT on VIS.RUTClave = RUT.RUTClave ")
        'sConsulta.AppendLine("inner join AgendaVendedor AGV on TRP.DiaClave = AGV.DiaClave and VEN.VendedorId = AGV.VendedorId  and VIS.ClienteClave = AGV.ClienteClave and VIS.RUTClave = AGV.RUTClave  ")
        'sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
        sConsulta.AppendLine("inner join vencentrodisthist hist on hist.vendedorid=VEN.VendedorId and vchfechainicial<=TRP.FechaCaptura and fechafinal>TRP.FechaCaptura ")
        sConsulta.AppendLine("inner join  Almacen ALN on hist.almacenid = ALN.almacenid ")
        sConsulta.AppendLine(pvCondicion & " and TRP.Tipo = 8 and TRP.TipoFase <> 0 ")
        sConsulta.AppendLine(") as Resultado ")
        sConsulta.AppendLine("group by CEDI, Clave, Producto , Unidad ")
        Session("Query2") = sConsulta.ToString

        Return True
    End Function

    Private Function ConsultaPedidos(ByVal ins As DBConexion.cConexionSQL, ByVal pvDetallado As Boolean, ByVal pvConversionKg As Boolean, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvClientes As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        Dim sCondicionALN As String = ""
        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "TRP.FechaHoraAlta")
        End If
        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "VIS.RUTClave")
        pvCondicion = strWhereClientes(pvCondicion, pvClientes, "CLI.ClienteClave")
        If (ChBoxCentroDistribucion.Checked) Then
            sCondicionALN = "where ALN.Clave = '" + DdlCentroDistribucion.SelectedValue + "' "
        End If

        If pvDetallado Then
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("set nocount on ")
            sConsulta.AppendLine("select FechaCaptura as Fecha, VENNombre as Vendedor, RUTClave + ' ' + RUTDescripcion as Ruta, ")
            sConsulta.AppendLine("TMP.TransProdID,Folio, RazonSocial as Cliente, ProductoClave as Clave, PRONombre as Producto, Unidad, ")
            If pvConversionKg Then
                sConsulta.AppendLine("TMP.KgLts, ")
            End If
            sConsulta.AppendLine("Precio as PrecioU, ALNClave + ' ' + ALNNombre as CEDI, Cantidad as Cant, TPDSubtotal as SubTotal, DescuentoImp as DescProducto, ")
            sConsulta.AppendLine("DescuentoCliente, ((TPDSubTotal - DescuentoCliente-DescuentoImp ) * DescVendPor / 100) as DescVend, ")
            sConsulta.AppendLine("Impuesto - (Impuesto * DescVendPor / 100)  as Impuesto, ")
            sConsulta.AppendLine("((TPDSubTotal - DescuentoImp - DescuentoCliente) - ((TPDSubTotal - DescuentoCliente - DescuentoImp ) * DescVendPor / 100) + (Impuesto - (Impuesto * DescVendPor / 100))) as Total ")
            sConsulta.AppendLine("from (")
            sConsulta.AppendLine("select TMP.DiaClave, TMP.FechaCaptura, TMP.TransProdID,TMP.Folio, TMP.DescVendPor, ")
            sConsulta.AppendLine("TMP.TRPSubtotal, TMP.ClienteClave, TMP.RazonSocial, TMP.ProductoClave, TMP.Precio, ")
            sConsulta.AppendLine("TMP.Cantidad, TMP.DescuentoCliente, TMP.DescuentoImp, TMP.TPDSubtotal, TMP.Impuesto, TMP.TipoUnidad, ")
            If pvConversionKg Then
                sConsulta.AppendLine("TMP.KgLts, ")
            End If
            sConsulta.AppendLine("TMP.PRONombre, TMP.Unidad, TMP.RutClave, TMP.VendedorId, TMP.VENNombre, ")
            sConsulta.AppendLine("ALN.Clave as ALNClave, ALN.Nombre as ALNNombre, RUT.Descripcion as RUTDescripcion ")
            sConsulta.AppendLine("from (")
            sConsulta.AppendLine("select TRP.DiaClave, TRP.FechaCaptura, TRP.TransProdID,TRP.Folio, TRP.DescVendPor, TRP.Subtotal as TRPSubtotal, TRP.ClienteClave, ")
            sConsulta.AppendLine("CLI.RazonSocial+' '+cli.nombrecontacto as razonsocial, TPD.ProductoClave, TPD.Precio, TPD.Cantidad, TPD.DescuentoImp, ")
            If pvConversionKg Then
                sConsulta.AppendLine("PRU.KgLts * TPD.Cantidad as KgLts, ")
            End If
            sConsulta.AppendLine("(TPD.Precio * TPD.Cantidad) as TPDSubTotal, ")
            sConsulta.AppendLine("(SELECT (CASE WHEN sum(DesImporte) IS NULL THEN 0 ELSE sum(DesImporte) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) as DescuentoCliente, ")
            sConsulta.AppendLine("(TPD.Impuesto - (SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE sum(DesImpuesto) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId)) as Impuesto, ")
            sConsulta.AppendLine("TPD.TipoUnidad, PRO.Nombre as PRONombre, ")
            sConsulta.AppendLine("VAD.Descripcion as Unidad, VIS.RutClave, VEN.VendedorId, VEN.Nombre as VENNombre ")
            sConsulta.AppendLine("from TransProd TRP ")
            sConsulta.AppendLine("inner join Cliente CLI on CLI.ClienteClave = TRP.ClienteClave ")
            sConsulta.AppendLine("inner join TransProdDetalle TPD on TPD.TransProdId = TRP.TransProdId ")
            sConsulta.AppendLine("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ")
            If pvConversionKg Then
                sConsulta.AppendLine("inner join ProductoUnidad PRU on PRU.ProductoClave=PRO.ProductoClave and PRU.PRUTipoUnidad=TPD.TipoUnidad ")
            End If
            sConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VARCodigo = 'UNIDADV' and VAD.VAVClave = TPD.TipoUnidad and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' ")
            sConsulta.AppendLine("inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine(pvCondicion & " and TRP.Tipo = 1 and TRP.TipoFase <> 0 ")
            sConsulta.AppendLine(") TMP ")
            sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI, RUTClave from AgendaVendedor) AGV on TMP.DiaClave = AGV.DiaClave and TMP.VendedorId = AGV.VendedorId and AGV.RUTClave = TMP.RUTClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Ruta RUT on TMP.RUTClave = RUT.RUTClave ")
            sConsulta.AppendLine(sCondicionALN & ") TMP ")
            sConsulta.AppendLine("set nocount off ")
        Else
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("set nocount on ")
            sConsulta.AppendLine("select distinct FechaCaptura as Fecha, VENNombre as Vendedor, RutClave + ' ' + RUTDescripcion as Ruta, ")
            sConsulta.AppendLine("TMP.TransProdId, Folio, CLIRazonSocial as Cliente, CLIClave as Clave, ALNClave + ' ' + ALNNombre as CEDI, Total ")
            sConsulta.AppendLine("from (")
            sConsulta.AppendLine("select TMP.FechaCaptura, TMP.Folio, TMP.TransProdId, TMP.Total, TMP.DiaClave, TMP.CLIRazonSocial, TMP.CLIClave, TMP.VENNombre, ")
            sConsulta.AppendLine("TMP.VendedorID, TMP.RutClave, TMP.RUTDescripcion, ALN.Clave as ALNClave, ALN.Nombre as ALNNombre ")
            sConsulta.AppendLine("from (")
            sConsulta.AppendLine("select TRP.FechaCaptura, TRP.Folio, TRP.TransProdId, TRP.Total, TRP.DiaClave, CLI.RazonSocial +' '+cli.nombrecontacto as CLIRazonSocial, CLI.Clave as CLIClave, ")
            sConsulta.AppendLine("VEN.Nombre as VENNombre, VEN.VendedorID, RUT.RutClave, RUT.Descripcion as RUTDescripcion ")
            sConsulta.AppendLine("from TransProd TRP ")
            sConsulta.AppendLine("inner join Cliente CLI on CLI.ClienteClave = TRP.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on VIS.RUTClave = RUT.RUTClave ")
            sConsulta.AppendLine(pvCondicion & " and TRP.Tipo = 1 and TRP.TipoFase <> 0 ")
            sConsulta.AppendLine(") TMP ")
            sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI, RUTClave from AgendaVendedor) AGV on TMP.DiaClave = AGV.DiaClave and TMP.VendedorId = AGV.VendedorId and AGV.RUTClave = TMP.RUTClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine(sCondicionALN & ") TMP ")
            sConsulta.AppendLine("set nocount off ")
        End If

        'Session("Query") = sConsulta.ToString

        Dim dt As Data.DataTable
        'System.Diagnostics.Debug.WriteLine(sConsulta.ToString)
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt
        'System.Diagnostics.Debug.WriteLine(dt.Rows.Count)

        'Query 2
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("select CEDI, Clave, Producto, Unidad, ")
        If pvConversionKg Then
            sConsulta.AppendLine("sum(KgLts) as KgLts, ")
        End If
        sConsulta.AppendLine("sum(Cantidad) as Cantidad, sum(Total) as Total ")
        sConsulta.AppendLine("from(	select ClienteClave, (ALNClave + ' ' + ALNNombre) as CEDI, ProductoClave as Clave, ")
        sConsulta.AppendLine("PRONombre as Producto, Unidad, ")
        If pvConversionKg Then
            sConsulta.AppendLine("KgLts, ")
        End If
        sConsulta.AppendLine("Cantidad, TPDTotal as Total ")
        sConsulta.AppendLine("from (")
        sConsulta.AppendLine("select TMP.ProductoClave, TMP.Cantidad, ")
        If pvConversionKg Then
            sConsulta.AppendLine("TMP.KgLts, ")
        End If
        sConsulta.AppendLine("(SubTotal - DescuentoCliente -((SubTotal - DescuentoCliente) * DescVendPor / 100)) + (Impuesto - DescuentoClienteImpuesto -((Impuesto - DescuentoClienteImpuesto) * DescVendPor / 100)) as TPDtotal, ")
        sConsulta.AppendLine("TMP.Impuesto, TMP.DescVendPor,TMP.DiaClave, TMP.ClienteClave, TMP.PRONombre, TMP.Unidad, ")
        sConsulta.AppendLine("TMP.VendedorId, ALN.Clave as ALNClave, ALN.Nombre as ALNNombre ")
        sConsulta.AppendLine("from (")
        sConsulta.AppendLine("select TPD.ProductoClave, TPD.Cantidad, TPD.Impuesto, TRP.DescVendPor, TPD.SubTotal, ")
        If pvConversionKg Then
            sConsulta.AppendLine("PRU.KgLts * TPD.Cantidad as KgLts, ")
        End If
        sConsulta.AppendLine("(SELECT (CASE WHEN sum(DesImporte) IS NULL THEN 0 ELSE sum(DesImporte) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) as DescuentoCliente, ")
        sConsulta.AppendLine("(SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE sum(DesImpuesto) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) as DescuentoClienteImpuesto, ")
        sConsulta.AppendLine("TRP.DiaClave, TRP.ClienteClave, PRO.Nombre as PRONombre, VAD.Descripcion as Unidad, VEN.VendedorId, RUT.RUTClave ")
        sConsulta.AppendLine("from TransProdDetalle TPD ")
        sConsulta.AppendLine("inner join TransProd TRP on TRP.TransProdId = TPD.TransProdId ")
        sConsulta.AppendLine("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ")
        If pvConversionKg Then
            sConsulta.AppendLine("inner join ProductoUnidad PRU on PRU.ProductoClave=PRO.ProductoClave and PRU.PRUTipoUnidad=TPD.TipoUnidad ")
        End If
        sConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VARCodigo = 'UNIDADV' and VAD.VAVClave = TPD.TipoUnidad and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' ")
        sConsulta.AppendLine("inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave ")
        sConsulta.AppendLine("inner join Cliente CLI on CLI.ClienteClave = TRP.ClienteClave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
        sConsulta.AppendLine("inner join Ruta RUT on VIS.RUTClave = RUT.RUTClave ")
        sConsulta.AppendLine(pvCondicion & " and TRP.Tipo = 1 and TRP.TipoFase <> 0 ")
        sConsulta.AppendLine(") TMP ")
        sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI, RUTClave from AgendaVendedor) AGV on TMP.DiaClave = AGV.DiaClave and TMP.VendedorId = AGV.VendedorId and AGV.RUTClave = TMP.RUTClave ")
        sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
        sConsulta.AppendLine(sCondicionALN & ") TMP ")
        sConsulta.AppendLine(") as t1 group by CEDI, Clave, Producto, Unidad ")
        sConsulta.AppendLine("set nocount off ")

        Session("Query2") = sConsulta.ToString

        Return True
    End Function

    Private Function ConsultaEfectividadPorRuta(ByVal ins As DBConexion.cConexionSQL, ByVal pvDetallado As Boolean, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "Dia.FechaCaptura")
        End If
        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "RUT.RUTClave")
        pvCondicion = strWhereCentrosDistribucion(pvCondicion, "ALN.Clave")
        'ActualizarArchivo("")

        If pvDetallado Then
            '--Query Principal
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct ALN.Nombre as Almacen, DIA.FechaCaptura, VEN.VendedorId, VEN.Nombre as Vendedor, RUT.RUTClave, ")
            sConsulta.AppendLine("RUT.Descripcion as Ruta, ALN.Clave as AlmacenId, Dia.DiaClave ")
            sConsulta.AppendLine("from (select distinct DiaClave, VendedorId, RUTClave, ClaveCEDI from AgendaVendedor) AGV ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)

            Dim dt As Data.DataTable
            dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
            If dt.Rows.Count = 0 Then
                Return False
            End If
            Session("DataTable") = dt

            sConsulta = New StringBuilder
            '--Tiempos
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select AGV.ClaveCEDI as AlmacenId, VIS.DiaClave, VIS.VendedorId, VIS.RUTClave, ")
            sConsulta.AppendLine("min(VIS.FechaHoraInicial) as HoraInicial, max(VIS.FechaHoraFinal) as HoraFinal, ")
            sConsulta.AppendLine("datediff(second, min(VIS.FechaHoraInicial), max(VIS.FechaHoraFinal)) as TiempoRecorrido, ")
            sConsulta.AppendLine("sum(datediff(second, VIS.FechaHoraInicial, VIS.FechaHoraFinal)) as TiempoVisita ")
            sConsulta.AppendLine("from Visita VIS ")
            sConsulta.AppendLine("inner Join (select distinct DiaClave, VendedorId, RUTClave, ClienteClave, ClaveCEDI from AgendaVendedor) AGV ")
            sConsulta.AppendLine("on VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorId and VIS.RUTClave = AGV.RUTClave and VIS.ClienteClave = AGV.ClienteClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, VIS.DiaClave, VIS.VendedorId, VIS.RUTClave ")
            Session("Tiempos") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--TotalClientes
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RutClave, isnull(count(distinct AGV.ClienteClave), 0) as TotalCliente ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RutClave ")
            Session("TotalClientes") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesNoVisitados
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CLI.ClienteClave, CLI.RazonSocial as Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("and CLI.ClienteClave not in ( ")
            sConsulta.AppendLine("select ClienteClave from Visita VIS where VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorId and VIS.RUTClave = AGV.RUTClave) ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("order by Nombre ")
            Session("ClientesNoVisitados") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesVisitados en Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CLI.ClienteClave, CLI.RazonSocial as Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and AGV.VendedorId = VIS.VendedorId and AGV.RutClave = VIS.RutClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("order by Nombre ")

            Session("ClientesVisitados") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesVisitados Fuera de Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CLI.ClienteClave, CLI.RazonSocial as Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and AGV.VendedorId = VIS.VendedorId and AGV.RutClave = VIS.RutClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("order by Nombre ")
            Session("ClientesVisitadosFA") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--TotalVisitados
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RutClave, ")
            sConsulta.AppendLine("isnull(count(distinct VIS.ClienteClave), 0) as TotalCliente ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and AGV.DiaClave = VIS.DiaClave and AGV.VendedorId = VIS.VendedorId and AGV.RutClave = VIS.RutClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RutClave ")
            Session("TotalVisitados") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesVisitadosConVenta en Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CLI.ClienteClave, CLI.RazonSocial as Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente Cli on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave and TRP.Tipo = 1 and TRP.TipoFase <> 0 ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("Order By Nombre ")
            Session("ClientesVisitadosConVenta") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesVisitadosConVenta Fuera de Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CLI.ClienteClave, CLI.RazonSocial as Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente Cli on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave and TRP.Tipo = 1 and TRP.TipoFase <> 0 ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("Order By Nombre ")
            Session("ClientesVisitadosConVentaFA") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesVisitadosSinVenta en Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CLI.ClienteClave, CLI.RazonSocial as Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("and not VIS.VisitaClave in (select TRP.VisitaClave from TransProd TRP where TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave and TRP.Tipo = 1 and TRP.TipoFase <> 0) ")
            'sConsulta.AppendLine("and not VIS.ClienteClave in (select VIS1.ClienteClave from Visita VIS1 inner join TransProd TRP on VIS1.VisitaClave = TRP.VisitaClave and AGV.DiaClave = TRP.DiaClave and TRP.Tipo = 1 and TRP.TipoFase <> 0) ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("order by Nombre ")
            Session("ClientesVisitadosSinVenta") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesVisitadosSinVenta Fuera de Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CLI.ClienteClave, CLI.RazonSocial as Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("and not VIS.VisitaClave in (select TRP.VisitaClave from TransProd TRP where TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave and TRP.Tipo = 1 and TRP.TipoFase <> 0) ")
            'sConsulta.AppendLine("and not VIS.ClienteClave in (select VIS1.ClienteClave from Visita VIS1 inner join TransProd TRP on VIS1.VisitaClave = TRP.VisitaClave and AGV.DiaClave = TRP.DiaClave and TRP.Tipo = 1 and TRP.TipoFase <> 0) ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("order by Nombre ")
            Session("ClientesVisitadosSinVentaFA") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--TotalVisitadosSinVenta
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            sConsulta.AppendLine("isnull(count(distinct AGV.ClienteClave), 0) - isnull(count(distinct(case when TRP.VisitaClave is null then null else VIS.ClienteClave end)), 0) as TotalCliente ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("left join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave and VIS.ClienteClave = AGV.ClienteClave and TRP.Tipo = 1 and TRP.TipoFase <> 0 ")
            sConsulta.AppendLine("left join ImproductividadVenta IMV on IMV.VisitaClave = VIS.VisitaClave and IMV.DiaClave = VIS.DiaClave and not VIS.VisitaClave is null ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            Session("TotalVisitadosSinVenta") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ImproductividadVenta en Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CLI.ClienteClave, CLI.RazonSocial as Nombre, ")
            sConsulta.AppendLine("(select Descripcion from VAVDescripcion where VarCodigo = 'Motimpro' and VAVClave=IMV.TipoMotivo and VADTipoLenguaje = '" & Session("lenguaje") & "') as Motivo, ")
            sConsulta.AppendLine("AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join ImproductividadVenta IMV on IMV.VisitaClave = VIS.VisitaClave and IMV.DiaClave = VIS.DiaClave ")
            sConsulta.AppendLine("and not VIS.VisitaClave in (select VIS1.VisitaClave from Visita VIS1 inner join TransProd TRP on VIS1.VisitaClave = TRP.VisitaClave and AGV.DiaClave = TRP.DiaClave and TRP.Tipo = 1 and TRP.TipoFase <> 0) ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("order by Nombre ")
            Session("ImproductividadVenta") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ImproductividadVenta Fuera de Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CLI.ClienteClave, CLI.RazonSocial as Nombre, ")
            sConsulta.AppendLine("(select Descripcion from VAVDescripcion where VarCodigo = 'Motimpro' and VAVClave=IMV.TipoMotivo and VADTipoLenguaje = '" & Session("lenguaje") & "') as Motivo, ")
            sConsulta.AppendLine("AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join ImproductividadVenta IMV on IMV.VisitaClave = VIS.VisitaClave and IMV.DiaClave = VIS.DiaClave ")
            sConsulta.AppendLine("and not VIS.VisitaClave in (select VIS1.VisitaClave from Visita VIS1 inner join TransProd TRP on VIS1.VisitaClave = TRP.VisitaClave and AGV.DiaClave = TRP.DiaClave and TRP.Tipo = 1 and TRP.TipoFase <> 0) ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("order by Nombre ")
            Session("ImproductividadVentaFA") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--TotalEncuestas
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, isnull(count(distinct CEC.CENClave), 0) as TotalEncuesta ")
            sConsulta.AppendLine("from CenCli CEC ")
            sConsulta.AppendLine("inner join AgendaVendedor AGV on CEC.ClienteClave = AGV.ClienteClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            Session("TotalEncuestas") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--EncuestasAplicadas en Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CEN.Descripcion as Encuesta, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join Encuesta ENC on Enc.VisitaClave = VIS.VisitaClave and Enc.DiaClave = VIS.DiaClave ")
            sConsulta.AppendLine("inner join ConfigEncuesta CEN on CEN.CENClave = ENC.CENClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            Session("EncuestasAplicadas") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--EncuestasAplicadas Fuera de Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CEN.Descripcion as Encuesta, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join Encuesta ENC on Enc.VisitaClave = VIS.VisitaClave and Enc.DiaClave = VIS.DiaClave ")
            sConsulta.AppendLine("inner join ConfigEncuesta CEN on CEN.CENClave = ENC.CENClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            Session("EncuestasAplicadasFA") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--EncuestasNoAplicadas En Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CEN.Descripcion as Encuesta, AGV.RUTClave, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from CenCli CEC ")
            sConsulta.AppendLine("inner join AgendaVendedor AGV on CEC.ClienteClave = AGV.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join ConfigEncuesta CEN on CEN.CenClave = CEC.CenClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine(" AND CEC.CENClave not in ( ")
            sConsulta.AppendLine("select distinct CEN.CENClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV1 ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV1.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV1.DiaClave and VIS.VendedorId = AGV1.VendedorID and VIS.RUTClave = AGV1.RUTClave ")
            sConsulta.AppendLine("inner join Encuesta ENC on Enc.VisitaClave = VIS.VisitaClave and Enc.DiaClave = VIS.DiaClave ")
            sConsulta.AppendLine("inner join ConfigEncuesta CEN on CEN.CENClave = ENC.CENClave ")
            sConsulta.AppendLine("where AGV.DiaClave = AGV1.DiaClave and AGV.VendedorId = AGV1.VendedorId and AGV.RutClave = AGV1.RutClave) ")
            Session("EncuestasNoAplicadas") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--EncuestasNoAplicadas Fuera de Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CEN.Descripcion as Encuesta, AGV.RUTClave, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from CenCli CEC ")
            sConsulta.AppendLine("inner join AgendaVendedor AGV on CEC.ClienteClave = AGV.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join ConfigEncuesta CEN on CEN.CenClave = CEC.CenClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine(" AND CEC.CENClave not in ( ")
            sConsulta.AppendLine("select distinct CEN.CENClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV1 ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV1.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV1.DiaClave and VIS.VendedorId = AGV1.VendedorID and VIS.RUTClave = AGV1.RUTClave ")
            sConsulta.AppendLine("inner join Encuesta ENC on Enc.VisitaClave = VIS.VisitaClave and Enc.DiaClave = VIS.DiaClave ")
            sConsulta.AppendLine("inner join ConfigEncuesta CEN on CEN.CENClave = ENC.CENClave ")
            sConsulta.AppendLine("where AGV.DiaClave = AGV1.DiaClave and AGV.VendedorId = AGV1.VendedorId and AGV.RutClave = AGV1.RutClave) ")
            Session("EncuestasNoAplicadasFA") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--TotalVisitadosAEncuestar
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RutClave, ")
            sConsulta.AppendLine("isnull(count(distinct VIS.ClienteClave), 0) as TotalCliente ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join CenCli CEC on AGV.ClienteClave = CEC.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and AGV.DiaClave = VIS.DiaClave and AGV.VendedorId = VIS.VendedorId and AGV.RutClave = VIS.RutClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RutClave ")
            Session("TotalVisitadosAEncuestar") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesEncuestados en Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CLI.ClienteClave, CLI.RazonSocial as Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join Encuesta ENC on Enc.VisitaClave = VIS.VisitaClave and Enc.DiaClave = VIS.DiaClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("order by Nombre ")
            Session("ClientesEncuestados") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesEncuestados Fuera de Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CLI.ClienteClave, CLI.RazonSocial as Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join Encuesta ENC on Enc.VisitaClave = VIS.VisitaClave and Enc.DiaClave = VIS.DiaClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("order by Nombre ")
            Session("ClientesEncuestadosFA") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesNoEncuestados en Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CLI.ClienteClave, CLI.RazonSocial as Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join CenCli CEC on CLI.ClienteClave = CEC.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("and CLI.ClienteClave not in( ")
            sConsulta.AppendLine("select distinct CLI1.ClienteClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV1 ")
            sConsulta.AppendLine("inner join Cliente CLI1 on AGV1.ClienteClave = CLI1.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS1 on CLI1.ClienteClave = VIS1.ClienteClave and VIS1.DiaClave = AGV1.DiaClave ")
            sConsulta.AppendLine("and VIS1.VendedorId = AGV1.VendedorID and VIS1.RUTClave = AGV1.RUTClave ")
            sConsulta.AppendLine("inner join Encuesta ENC on Enc.VisitaClave = VIS1.VisitaClave and Enc.DiaClave = VIS1.DiaClave ")
            sConsulta.AppendLine("where AGV.DiaClave = AGV1.DiaClave and AGV.VendedorId = AGV1.VendedorId and AGV.RutClave = AGV1.RutClave) ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("order by Nombre ")
            Session("ClientesNoEncuestados") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesNoEncuestados Fuera de Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CLI.ClienteClave, CLI.RazonSocial as Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join CenCli CEC on CLI.ClienteClave = CEC.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("and CLI.ClienteClave not in( ")
            sConsulta.AppendLine("select distinct CLI1.ClienteClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV1 ")
            sConsulta.AppendLine("inner join Cliente CLI1 on AGV1.ClienteClave = CLI1.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS1 on CLI1.ClienteClave = VIS1.ClienteClave and VIS1.DiaClave = AGV1.DiaClave ")
            sConsulta.AppendLine("and VIS1.VendedorId = AGV1.VendedorID and VIS1.RUTClave = AGV1.RUTClave ")
            sConsulta.AppendLine("inner join Encuesta ENC on Enc.VisitaClave = VIS1.VisitaClave and Enc.DiaClave = VIS1.DiaClave ")
            sConsulta.AppendLine("where AGV.DiaClave = AGV1.DiaClave and AGV.VendedorId = AGV1.VendedorId and AGV.RutClave = AGV1.RutClave) ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("order by Nombre ")
            Session("ClientesNoEncuestadosFA") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--CodigosLeidos en Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CLI.ClienteClave, CLI.RazonSocial as Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave and VIS.CodigoLeido = 1 ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("order by Nombre ")
            Session("CodigosLeidos") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--CodigosLeidos Fuera de Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CLI.ClienteClave, CLI.RazonSocial as Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave and VIS.CodigoLeido = 1 ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("order by Nombre ")
            Session("CodigosLeidosFA") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--CodigosNoLeidos en Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CLI.ClienteClave, CLI.RazonSocial as Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave and VIS.CodigoLeido = 0 ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("order by Nombre ")
            Session("CodigosNoLeidos") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--CodigosNoLeidos Fuera de Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CLI.ClienteClave, CLI.RazonSocial as Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave and VIS.CodigoLeido = 0 ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("order by Nombre ")
            Session("CodigosNoLeidosFA") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ProductoNegado en Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select PRO.Nombre, sum(PRD.Factor * PRG.Cantidad) as Cantidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("inner join ProductoNegado PRG on TRP.TransProdId = PRG.TransProdId AND PRG.PromocionClave is null ")
            sConsulta.AppendLine("inner join Producto PRO on PRG.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRO.ProductoClave = PRD.ProductoClave and PRD.PRUTipoUnidad = PRG.TipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by PRO.Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            Session("ProductoNegado") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ProductoNegado Fuera de Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select PRO.Nombre, sum(PRD.Factor * PRG.Cantidad) as Cantidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("inner join ProductoNegado PRG on TRP.TransProdId = PRG.TransProdId AND PRG.PromocionClave is null  ")
            sConsulta.AppendLine("inner join Producto PRO on PRG.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRO.ProductoClave = PRD.ProductoClave and PRD.PRUTipoUnidad = PRG.TipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by PRO.Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            Session("ProductoNegadoFA") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ImproductividadProducto en Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct PRO.Nombre, ")
            sConsulta.AppendLine("(select Descripcion from VAVDescripcion where VarCodigo = 'Motimpro' and VAVClave = IMR.TipoMotivo and VADTipoLenguaje = '" & Session("lenguaje") & "') as Motivo, ")
            sConsulta.AppendLine("sum(IMR.Cantidad) as Cantidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join ImproductividadProd IMR on IMR.VisitaClave = VIS.VisitaClave and IMR.DiaClave = AGV.DiaClave ")
            sConsulta.AppendLine("inner join Producto PRO on IMR.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by PRO.Nombre, IMR.TipoMotivo, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            Session("ImproductividadProducto") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ImproductividadProducto Fuera de Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct PRO.Nombre, ")
            sConsulta.AppendLine("(select Descripcion from VAVDescripcion where VarCodigo = 'Motimpro' and VAVClave = IMR.TipoMotivo and VADTipoLenguaje = '" & Session("lenguaje") & "') as Motivo, ")
            sConsulta.AppendLine("sum(IMR.Cantidad) as Cantidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join ImproductividadProd IMR on IMR.VisitaClave = VIS.VisitaClave and IMR.DiaClave = AGV.DiaClave ")
            sConsulta.AppendLine("inner join Producto PRO on IMR.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by PRO.Nombre, IMR.TipoMotivo, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            Session("ImproductividadProductoFA") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--MotivosImproductividad en Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct (select Descripcion from VAVDescripcion where VarCodigo = 'Motimpro' and VAVClave = IMR.TipoMotivo and VADTipoLenguaje = '" & Session("lenguaje") & "') as Motivo, ")
            sConsulta.AppendLine("sum(IMR.Cantidad) as Cantidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join ImproductividadProd IMR on IMR.VisitaClave = VIS.VisitaClave and IMR.DiaClave = AGV.DiaClave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by IMR.TipoMotivo, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            Session("MotivosImproductividad") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--MotivosImproductividad Fuera de Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct (select Descripcion from VAVDescripcion where VarCodigo = 'Motimpro' and VAVClave = IMR.TipoMotivo and VADTipoLenguaje = '" & Session("lenguaje") & "') as Motivo, ")
            sConsulta.AppendLine("sum(IMR.Cantidad) as Cantidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join ImproductividadProd IMR on IMR.VisitaClave = VIS.VisitaClave and IMR.DiaClave = AGV.DiaClave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by IMR.TipoMotivo, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            Session("MotivosImproductividadFA") = sConsulta.ToString

            '--Producto Promocional no Entregado en Agenda
            sConsulta = New StringBuilder
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select PRO.Nombre, sum(PRD.Factor * PRG.Cantidad) as Cantidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("inner join ProductoNegado PRG on TRP.TransProdId = PRG.TransProdId AND not PRG.PromocionClave is null ")
            sConsulta.AppendLine("inner join Producto PRO on PRG.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRO.ProductoClave = PRD.ProductoClave and PRD.PRUTipoUnidad = PRG.TipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by PRO.Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            Session("ProductoPromoNoEntregado") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--Producto Promocional no Entregado Fuera de Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select PRO.Nombre, sum(PRD.Factor * PRG.Cantidad) as Cantidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("inner join ProductoNegado PRG on TRP.TransProdId = PRG.TransProdId AND not PRG.PromocionClave is null  ")
            sConsulta.AppendLine("inner join Producto PRO on PRG.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRO.ProductoClave = PRD.ProductoClave and PRD.PRUTipoUnidad = PRG.TipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by PRO.Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            Session("ProductoPromoNoEntregadoFA") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--Total Producto Promocional 
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, sum(PRD.Factor * TPD.Cantidad) as TotalCliente ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave and TRP.Tipo = 1 AND TRP.TipoFase <>0 ")
            sConsulta.AppendLine("inner join TransprodDetalle TPD on TPD.TransProdId = TRP.TransProdId AND TPD.Promocion  = 2 ")
            sConsulta.AppendLine("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRO.ProductoClave = PRD.ProductoClave and PRD.PRUTipoUnidad = TPD.TipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            Session("TotalProductoPromocional") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--Total Producto Promocional FUERA AGENDA
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, sum(PRD.Factor * TPD.Cantidad) as TotalCliente ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave and TRP.Tipo = 1 AND TRP.TipoFase <>0 ")
            sConsulta.AppendLine("inner join TransprodDetalle TPD on TPD.TransProdId = TRP.TransProdId AND TPD.Promocion  = 2 ")
            sConsulta.AppendLine("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRO.ProductoClave = PRD.ProductoClave and PRD.PRUTipoUnidad = TPD.TipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103)  ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            Session("TotalProductoPromocionalFA") = sConsulta.ToString


            sConsulta = New StringBuilder
            '--ClientesProductoNegado en Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select CLI.RazonSocial as Cliente, PRO.Nombre as Producto, ")
            sConsulta.AppendLine("(select Descripcion from VAVDescripcion where VarCodigo = 'UNIDADV' and VAVClave = PRG.TipoUnidad and VADTipoLenguaje = '" & Session("lenguaje") & "') as Unidad, ")
            sConsulta.AppendLine("sum(PRG.Cantidad) as Cantidad, ")
            sConsulta.AppendLine("sum(PRD.Factor * PRG.Cantidad) as CantidadUnitaria, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("inner join ProductoNegado PRG on TRP.TransProdId = PRG.TransProdId AND PRG.PromocionClave is null ")
            sConsulta.AppendLine("inner join Producto PRO on PRG.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRO.ProductoClave = PRD.ProductoClave and PRD.PRUTipoUnidad = PRG.TipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by CLI.RazonSocial, PRO.Nombre, PRG.TipoUnidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("order by CLI.RazonSocial, PRO.Nombre, PRG.TipoUnidad ")
            Session("ClientesProductoNegado") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesProductoNegado Fuera de Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select CLI.RazonSocial as Cliente, PRO.Nombre as Producto, ")
            sConsulta.AppendLine("(select Descripcion from VAVDescripcion where VarCodigo = 'UNIDADV' and VAVClave = PRG.TipoUnidad and VADTipoLenguaje = '" & Session("lenguaje") & "') as Unidad, ")
            sConsulta.AppendLine("sum(PRG.Cantidad) as Cantidad, ")
            sConsulta.AppendLine("sum(PRD.Factor * PRG.Cantidad) as CantidadUnitaria, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("inner join ProductoNegado PRG on TRP.TransProdId = PRG.TransProdId AND PRG.PromocionClave is null ")
            sConsulta.AppendLine("inner join Producto PRO on PRG.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRO.ProductoClave = PRD.ProductoClave and PRD.PRUTipoUnidad = PRG.TipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by CLI.RazonSocial, PRO.Nombre, PRG.TipoUnidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("order by CLI.RazonSocial, PRO.Nombre, PRG.TipoUnidad ")
            Session("ClientesProductoNegadoFA") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesImproductividadProducto en Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select CLI.RazonSocial as Cliente, PRO.Nombre as Producto, ")
            sConsulta.AppendLine("sum(IMR.Cantidad) as Cantidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave=AGV.RUTClave ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join ImproductividadProd IMR on IMR.VisitaClave = VIS.VisitaClave and IMR.DiaClave = AGV.DiaClave ")
            sConsulta.AppendLine("inner join Producto PRO on IMR.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by CLI.RazonSocial, PRO.Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            Session("ClientesImproductividadProducto") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesImproductividadProducto Fuera de Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select CLI.RazonSocial as Cliente, PRO.Nombre as Producto, ")
            sConsulta.AppendLine("sum(IMR.Cantidad) as Cantidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave=AGV.RUTClave ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join ImproductividadProd IMR on IMR.VisitaClave = VIS.VisitaClave and IMR.DiaClave = AGV.DiaClave ")
            sConsulta.AppendLine("inner join Producto PRO on IMR.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by CLI.RazonSocial, PRO.Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            Session("ClientesImproductividadProductoFA") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--Clientes Producto Promocional No Entregado en Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select CLI.RazonSocial as Cliente, PRO.Nombre as Producto, ")
            sConsulta.AppendLine("(select Descripcion from VAVDescripcion where VarCodigo = 'UNIDADV' and VAVClave = PRG.TipoUnidad and VADTipoLenguaje = '" & Session("lenguaje") & "') as Unidad, ")
            sConsulta.AppendLine("sum(PRG.Cantidad) as Cantidad, ")
            sConsulta.AppendLine("sum(PRD.Factor * PRG.Cantidad) as CantidadUnitaria, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("inner join ProductoNegado PRG on TRP.TransProdId = PRG.TransProdId AND not PRG.PromocionClave is null ")
            sConsulta.AppendLine("inner join Producto PRO on PRG.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRO.ProductoClave = PRD.ProductoClave and PRD.PRUTipoUnidad = PRG.TipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by CLI.RazonSocial, PRO.Nombre, PRG.TipoUnidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("order by CLI.RazonSocial, PRO.Nombre, PRG.TipoUnidad ")
            Session("ClientesProductoPNE") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--Clientes Producto Promocional No Entregado Fuera de Agenda
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select CLI.RazonSocial as Cliente, PRO.Nombre as Producto, ")
            sConsulta.AppendLine("(select Descripcion from VAVDescripcion where VarCodigo = 'UNIDADV' and VAVClave = PRG.TipoUnidad and VADTipoLenguaje = '" & Session("lenguaje") & "') as Unidad, ")
            sConsulta.AppendLine("sum(PRG.Cantidad) as Cantidad, ")
            sConsulta.AppendLine("sum(PRD.Factor * PRG.Cantidad) as CantidadUnitaria, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("inner join ProductoNegado PRG on TRP.TransProdId = PRG.TransProdId  AND not PRG.PromocionClave is null  ")
            sConsulta.AppendLine("inner join Producto PRO on PRG.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRO.ProductoClave = PRD.ProductoClave and PRD.PRUTipoUnidad = PRG.TipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by CLI.RazonSocial, PRO.Nombre, PRG.TipoUnidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("order by CLI.RazonSocial, PRO.Nombre, PRG.TipoUnidad ")
            Session("ClientesProductoPNEFA") = sConsulta.ToString

        Else
            sConsulta = New StringBuilder
            '--Query Principal
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct ALN.Clave + ' ' + ALN.Nombre as Almacen, DIA.FechaCaptura, VEN.Nombre as Vendedor, RUT.Rutclave + ' ' + RUT.Descripcion as Ruta, ")
            sConsulta.AppendLine("ALN.Clave as ClaveCEDI, Dia.DiaClave, VEN.VendedorId, RUT.RUTClave ")
            sConsulta.AppendLine("from (select distinct DiaClave, VendedorId, RUTClave, ClaveCEDI from AgendaVendedor) AGV ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave=DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave " & pvCondicion)

            Dim dt As Data.DataTable
            dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
            If dt.Rows.Count = 0 Then
                Return False
            End If
            Session("DataTable") = dt

            sConsulta = New StringBuilder
            '--Tiempos
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, VIS.DiaClave, VIS.VendedorId, VIS.RUTClave, ")
            sConsulta.AppendLine("datediff(second,min(VIS.FechaHoraInicial),max(VIS.FechaHoraFinal)) as TiempoRecorrido, ")
            sConsulta.AppendLine("sum(datediff(second, VIS.FechaHoraInicial, VIS.FechaHoraFinal)) as TiempoVisita ")
            sConsulta.AppendLine("from Visita VIS ")
            sConsulta.AppendLine("inner join AgendaVendedor AGV on VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorId and VIS.RUTClave = AGV.RUTClave and Vis.ClienteClave = AGV.ClienteClave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave=DIA.DIAClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave " & pvCondicion)

            sConsulta.AppendLine("group by AGV.ClaveCEDI, VIS.DiaClave, VIS.VendedorId, VIS.RUTClave ")
            Session("Tiempos") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesVisitados
            sConsulta.AppendLine("select ClaveCEDI, DiaClave, VendedorId, RutClave,SUM(TotalClientes) as TotalClientes, SUM(EnAgendaVisitados) as EnAgendaVisitados, SUM(FueraAgendaVisitados) as FueraAgendaVisitados ")
            sConsulta.AppendLine("FROM ")
            sConsulta.AppendLine("(select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            sConsulta.AppendLine("isnull(count(distinct AGV.ClienteClave), 0) as TotalClientes, ")
            sConsulta.AppendLine("EnAgendaVisitados=0, FueraAgendaVisitados=0 ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave=DIA.DIAClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave " & pvCondicion)
            sConsulta.AppendLine(" and AGV.ClienteClave not in ( ")
            sConsulta.AppendLine("select ClienteClave from Visita VIS where VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorId and VIS.RUTClave = AGV.RUTClave) ")
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RutClave ")
            sConsulta.AppendLine("union all ")
            sConsulta.AppendLine("select ClaveCEDI, DiaClave, VendedorId, RutClave, TotalClientes=0, SUM(EnAgendaVisitados) as EnAgendaVisitados, SUM(FueraAgendaVisitados) as FueraAgendaVisitados ")
            sConsulta.AppendLine("FROM ")
            sConsulta.AppendLine("(select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RutClave, ")
            sConsulta.AppendLine("(SELECT count(distinct VIS.ClienteClave) FROM Visita VIS ")
            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("WHERE (AGV.ClienteClave = VIS.ClienteClave And AGV.DiaClave = VIS.DiaClave And AGV.VendedorId = VIS.VendedorId And AGV.RutClave = VIS.RutClave) ")
            sConsulta.AppendLine(") as EnAgendaVisitados, ")
            sConsulta.AppendLine("(SELECT count(distinct VIS.ClienteClave) FROM Visita VIS ")
            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("WHERE (AGV.ClienteClave = VIS.ClienteClave And AGV.DiaClave = VIS.DiaClave And AGV.VendedorId = VIS.VendedorId And AGV.RutClave = VIS.RutClave) ")
            sConsulta.AppendLine(") as FueraAgendaVisitados ")
            sConsulta.AppendLine("FROM AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave=DIA.DIAClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RutClave, AGV.ClienteClave ")
            sConsulta.AppendLine(") as Resultado ")
            sConsulta.AppendLine("group by ClaveCEDI, DiaClave, VendedorId, RutClave ")
            sConsulta.AppendLine(") as Resultado ")
            sConsulta.AppendLine("group by ClaveCEDI, DiaClave, VendedorId, RutClave ")
            Session("ClientesVisitados") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesVisitadosConVenta
            sConsulta.AppendLine("select ClaveCEDI, DiaClave, VendedorId, RUTClave, sum(ClientesVisitados) as ClientesVisitados, ")
            sConsulta.AppendLine("sum(ClientesVisitadosEnAgenda) as ClientesVisitadosEnAgenda, sum(ClientesConVentaEnAgenda) as ClientesConVentaEnAgenda, ")
            sConsulta.AppendLine("sum(ClientesSinVentaEnAgenda) as ClientesSinVentaEnAgenda, sum(ClientesVisitadosFueraAgenda) as ClientesVisitadosFueraAgenda, ")
            sConsulta.AppendLine("sum(ClientesConVentaFueraAgenda) as ClientesConVentaFueraAgenda, sum(ClientesSinVentaFueraAgenda) as ClientesSinVentaFueraAgenda ")
            sConsulta.AppendLine("FROM ")
            sConsulta.AppendLine("(select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            sConsulta.AppendLine("isnull(count(distinct CLI.ClienteClave), 0) as ClientesVisitados, ")
            sConsulta.AppendLine("ClientesVisitadosEnAgenda=0, ClientesConVentaEnAgenda=0, ClientesSinVentaEnAgenda=0, ClientesVisitadosFueraAgenda=0, ClientesConVentaFueraAgenda=0, ClientesSinVentaFueraAgenda=0 ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave ")

            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave ")


            sConsulta.AppendLine("left join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave and TRP.Tipo = 1 and TRP.TipoFase <> 0 " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("union all ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ClientesVisitados=0,")
            sConsulta.AppendLine("isnull(count(distinct CLI.ClienteClave), 0) as ClientesVisitadosEnAgenda, ")
            sConsulta.AppendLine("isnull(count(distinct(case when TRP.VisitaClave is null then null else VIS.ClienteClave end)), 0) as ClientesConVentaEnAgenda, ")
            sConsulta.AppendLine("ClientesSinVentaEnAgenda=0, ClientesVisitadosFueraAgenda=0, ClientesConVentaFueraAgenda=0, ClientesSinVentaFueraAgenda=0 ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")

            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave ")

            sConsulta.AppendLine("left join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave and TRP.Tipo = 1 and TRP.TipoFase <> 0 " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("union all ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            sConsulta.AppendLine("ClientesVisitados=0, ClientesVisitadosEnAgenda=0, ClientesConVentaEnAgenda=0, ")
            sConsulta.AppendLine("isnull(count(distinct CLI.ClienteClave), 0) as ClientesSinVentaEnAgenda, ")
            sConsulta.AppendLine("ClientesVisitadosFueraAgenda=0, ClientesConVentaFueraAgenda=0, ClientesSinVentaFueraAgenda=0 ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")

            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave " & pvCondicion)

            sConsulta.AppendLine("and not VIS.VisitaClave in (select VIS1.VisitaClave from Visita VIS1 inner join TransProd TRP on VIS1.VisitaClave = TRP.VisitaClave and AGV.DiaClave = TRP.DiaClave and TRP.Tipo = 1 and TRP.TipoFase <> 0) ")
            sConsulta.AppendLine("and not VIS.ClienteClave in (select distinct(VIS1.ClienteClave) from Visita VIS1 inner join TransProd TRP on VIS1.VisitaClave = TRP.VisitaClave and AGV.DiaClave = TRP.DiaClave and TRP.Tipo = 1 and TRP.TipoFase <> 0) ")

            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("union all ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            sConsulta.AppendLine("ClientesVisitados=0, ClientesVisitadosEnAgenda=0, ClientesConVentaEnAgenda=0, ClientesSinVentaEnAgenda=0, ")
            sConsulta.AppendLine("isnull(count(distinct CLI.ClienteClave), 0) as ClientesVisitadosFueraAgenda, ")
            sConsulta.AppendLine("isnull(count(distinct(case when TRP.VisitaClave is null then null else VIS.ClienteClave end)), 0) as ClientesConVentaFueraAgenda, ")
            sConsulta.AppendLine("ClientesSinVentaFueraAgenda=0 ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")

            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave ")

            sConsulta.AppendLine("left join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave and TRP.Tipo = 1 and TRP.TipoFase <> 0 " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("union all ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            sConsulta.AppendLine("ClientesVisitados=0, ClientesVisitadosEnAgenda=0, ClientesConVentaEnAgenda=0, ClientesSinVentaEnAgenda=0, ClientesVisitadosFueraAgenda=0, ClientesConVentaFueraAgenda=0, ")
            sConsulta.AppendLine("isnull(count(distinct CLI.ClienteClave), 0) as ClientesSinVentaFueraAgenda ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")

            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave " & pvCondicion)

            sConsulta.AppendLine("and not VIS.VisitaClave in (select VIS1.VisitaClave from Visita VIS1 inner join TransProd TRP on VIS1.VisitaClave = TRP.VisitaClave and AGV.DiaClave = TRP.DiaClave and TRP.Tipo = 1 and TRP.TipoFase <> 0) ")
            sConsulta.AppendLine("and not VIS.ClienteClave in (select distinct(VIS1.ClienteClave) from Visita VIS1 inner join TransProd TRP on VIS1.VisitaClave = TRP.VisitaClave and AGV.DiaClave = TRP.DiaClave and TRP.Tipo = 1 and TRP.TipoFase <> 0) ")

            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine(") as resultado ")
            sConsulta.AppendLine("group by ClaveCEDI, DiaClave, VendedorId, RUTClave ")
            Session("ClientesVisitadosConVenta") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ImproductividadVenta
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select ClaveCEDI, DiaClave, VendedorId, RUTClave, sum(ClientesNoVenta) as ClientesNoVenta, ")
            sConsulta.AppendLine("sum(ClientesImproductivoEnAgenda) as ClientesImproductivoEnAgenda, sum(ClientesImproductivoFueraAgenda) as ClientesImproductivoFueraAgenda ")
            sConsulta.AppendLine("FROM ")
            sConsulta.AppendLine("(select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            sConsulta.AppendLine("isnull(count(distinct AGV.ClienteClave), 0) as ClientesNoVenta, ")
            sConsulta.AppendLine("ClientesImproductivoEnAgenda=0, ClientesImproductivoFueraAgenda=0 ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave ")

            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave " & pvCondicion)

            sConsulta.AppendLine("and not VIS.VisitaClave in (select VIS1.VisitaClave from Visita VIS1 inner join TransProd TRP on VIS1.VisitaClave = TRP.VisitaClave and AGV.DiaClave = TRP.DiaClave and TRP.Tipo = 1 and TRP.TipoFase <> 0) ")
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("union all ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ClientesNoVenta=0, ")
            sConsulta.AppendLine("isnull(count(distinct(case when (TRP.VisitaClave is null and not IMV.VisitaClave is null) then VIS.ClienteClave else null end)), 0) as ClientesImproductivoEnAgenda, ")
            sConsulta.AppendLine("ClientesImproductivoFueraAgenda = 0 ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")

            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave ")

            sConsulta.AppendLine("left join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave and VIS.ClienteClave = AGV.ClienteClave and TRP.Tipo = 1 and TRP.TipoFase <> 0 ")
            sConsulta.AppendLine("left join ImproductividadVenta IMV on IMV.VisitaClave = VIS.VisitaClave and IMV.DiaClave = VIS.DiaClave and not VIS.VisitaClave is null " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("union all ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ClientesNoVenta=0, ClientesImproductivoEnAgenda=0, ")
            sConsulta.AppendLine("isnull(count(distinct(case when (TRP.VisitaClave is null and not IMV.VisitaClave is null) then VIS.ClienteClave else null end)), 0) as ClientesImproductivoFueraAgenda ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")

            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave ")

            sConsulta.AppendLine("left join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave and VIS.ClienteClave = AGV.ClienteClave and TRP.Tipo = 1 and TRP.TipoFase <> 0 ")
            sConsulta.AppendLine("left join ImproductividadVenta IMV on IMV.VisitaClave = VIS.VisitaClave and IMV.DiaClave = VIS.DiaClave and not VIS.VisitaClave is null " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine(") as Resultado ")
            sConsulta.AppendLine("group by ClaveCEDI, DiaClave, VendedorId, RUTClave ")
            Session("ImproductividadVenta") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--EncuestasAplicadas
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select ClaveCEDI, DiaClave, VendedorId, RUTClave, sum(TotalEncuestas) as TotalEncuestas, ")
            sConsulta.AppendLine("sum(TotalEncuestasEnAgenda) as TotalEncuestasEnAgenda, sum(TotalAplicadasEnAgenda) as TotalAplicadasEnAgenda, ")
            sConsulta.AppendLine("sum(TotalEncuestasFueraAgenda) as TotalEncuestasFueraAgenda, sum(TotalAplicadasFueraAgenda) as TotalAplicadasFueraAgenda ")
            sConsulta.AppendLine("FROM ")
            sConsulta.AppendLine("(select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            sConsulta.AppendLine("isnull(count(distinct CEC.CENClave), 0) as TotalEncuestas, ")
            sConsulta.AppendLine("TotalEncuestasEnAgenda=0, TotalEncuestasFueraAgenda=0, TotalAplicadasEnAgenda=0, TotalAplicadasFueraAgenda=0 ")
            sConsulta.AppendLine("from CenCli CEC ")
            sConsulta.AppendLine("inner join AgendaVendedor AGV on AGV.ClienteClave = CEC.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on VIS.ClienteClave = CEC.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")

            sConsulta.AppendLine("inner join Dia on AGV.DiaClave=DIA.DIAClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave " & pvCondicion)

            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("union all ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, TotalEncuestas=0, ")
            sConsulta.AppendLine("isnull(count(distinct CEC.CENClave), 0) as TotalEncuestasEnAgenda, TotalEncuestasFueraAgenda=0, ")
            sConsulta.AppendLine("isnull(count(distinct ENC.CENClave), 0) as TotalAplicadasEnAgenda, TotalAplicadasFueraAgenda=0 ")
            sConsulta.AppendLine("from CenCli CEC ")
            sConsulta.AppendLine("inner join AgendaVendedor AGV on AGV.ClienteClave = CEC.ClienteClave ")
            sConsulta.AppendLine("inner join (SELECT VIS.VisitaClave, VIS.ClienteClave, VIS.DiaClave, VIS.VendedorId, VIS.RUTClave FROM Visita VIS ")
            sConsulta.AppendLine("inner JOIN Dia ON VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("group by VIS.VisitaClave, VIS.ClienteClave, VIS.DiaClave, VIS.VendedorId, VIS.RUTClave ")
            sConsulta.AppendLine(") as VIS ON CEC.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("left join Encuesta ENC on ENC.VisitaClave = VIS.VisitaClave and ENC.DiaClave = VIS.DiaClave ")

            sConsulta.AppendLine("inner join Dia on AGV.DiaClave=DIA.DIAClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave " & pvCondicion)

            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("union all ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, TotalEncuestas=0, ")
            sConsulta.AppendLine("TotalEncuestasEnAgenda=0, isnull(count(distinct CEC.CENClave), 0) as TotalEncuestasFueraAgenda, ")
            sConsulta.AppendLine("TotalAplicadasEnAgenda=0, isnull(count(distinct ENC.CENClave), 0) as TotalAplicadasFueraAgenda ")
            sConsulta.AppendLine("from CenCli CEC ")
            sConsulta.AppendLine("inner join AgendaVendedor AGV on AGV.ClienteClave = CEC.ClienteClave ")
            sConsulta.AppendLine("inner join (SELECT VIS.VisitaClave, VIS.ClienteClave, VIS.DiaClave, VIS.VendedorId, VIS.RUTClave FROM Visita VIS ")
            sConsulta.AppendLine("inner JOIN Dia ON VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("group by VIS.VisitaClave, VIS.ClienteClave, VIS.DiaClave, VIS.VendedorId, VIS.RUTClave ")
            sConsulta.AppendLine(") as VIS ON CEC.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("left join Encuesta ENC on ENC.VisitaClave = VIS.VisitaClave and ENC.DiaClave = VIS.DiaClave ")

            sConsulta.AppendLine("inner join Dia on AGV.DiaClave=DIA.DIAClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave " & pvCondicion)

            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine(") as Resultado ")
            sConsulta.AppendLine("group by ClaveCEDI, DiaClave, VendedorId, RUTClave ")
            Session("EncuestasAplicadas") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesEncuestados
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select ClaveCEDI, DiaClave, VendedorId, RUTClave, sum(TotalClientes) as TotalClientes, ")
            sConsulta.AppendLine("sum(TotalClientesEnAgenda) as TotalClientesEnAgenda, sum(TotalEncuestadosEnAgenda) as TotalEncuestadosEnAgenda, ")
            sConsulta.AppendLine("sum(TotalClientesFueraAgenda) as TotalClientesFueraAgenda, sum(TotalEncuestadosFueraAgenda) as TotalEncuestadosFueraAgenda ")
            sConsulta.AppendLine("FROM ")
            sConsulta.AppendLine("(select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            sConsulta.AppendLine("isnull(count(distinct CEC.ClienteClave), 0) as TotalClientes, ")
            sConsulta.AppendLine("TotalClientesEnAgenda=0, TotalEncuestadosEnAgenda=0, TotalClientesFueraAgenda=0, TotalEncuestadosFueraAgenda=0 ")
            sConsulta.AppendLine("from CenCli CEC ")
            sConsulta.AppendLine("inner join AgendaVendedor AGV on AGV.ClienteClave = CEC.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CEC.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave ")

            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave ")

            sConsulta.AppendLine("left join Encuesta ENC on ENC.VisitaClave = VIS.VisitaClave and ENC.DiaClave = VIS.DiaClave " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("union all ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, TotalClientes=0, ")
            sConsulta.AppendLine("isnull(count(distinct CEC.ClienteClave), 0) as TotalClientesEnAgenda, ")
            sConsulta.AppendLine("isnull(count(distinct(case when ENC.ENCId is null then null else VIS.ClienteClave end)), 0) as TotalEncuestadosEnAgenda, ")
            sConsulta.AppendLine("TotalClientesFueraAgenda=0, TotalEncuestadosFueraAgenda=0 ")
            sConsulta.AppendLine("from CenCli CEC ")
            sConsulta.AppendLine("inner join AgendaVendedor AGV on AGV.ClienteClave = CEC.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CEC.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")

            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave ")

            sConsulta.AppendLine("left join Encuesta ENC on ENC.VisitaClave = VIS.VisitaClave and ENC.DiaClave = VIS.DiaClave " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("union all ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, TotalClientes=0, ")
            sConsulta.AppendLine("TotalClientesEnAgenda=0, TotalEncuestadosEnAgenda=0, ")
            sConsulta.AppendLine("isnull(count(distinct CEC.ClienteClave), 0) as TotalClientesFueraAgenda, ")
            sConsulta.AppendLine("isnull(count(distinct(case when ENC.ENCId is null then null else VIS.ClienteClave end)), 0) as TotalEncuestadosFueraAgenda ")
            sConsulta.AppendLine("from CenCli CEC ")
            sConsulta.AppendLine("inner join AgendaVendedor AGV on AGV.ClienteClave = CEC.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CEC.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")

            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave ")

            sConsulta.AppendLine("left join Encuesta ENC on ENC.VisitaClave = VIS.VisitaClave and ENC.DiaClave = VIS.DiaClave " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine(") as Resultado ")
            sConsulta.AppendLine("group by ClaveCEDI, DiaClave, VendedorId, RUTClave ")
            Session("ClientesEncuestados") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--CodigosLeidos
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select ClaveCEDI, DiaClave, VendedorId, RUTClave, sum(ClientesVisitados) as ClientesVisitados, ")
            sConsulta.AppendLine("sum(ClientesVisitadosEnAgenda) as ClientesVisitadosEnAgenda, sum(ClientesLeidosEnAgenda) as ClientesLeidosEnAgenda, ")
            sConsulta.AppendLine("sum(ClientesVisitadosFueraAgenda) as ClientesVisitadosFueraAgenda, sum(ClientesLeidosFueraAgenda) as ClientesLeidosFueraAgenda ")
            sConsulta.AppendLine("FROM ")
            sConsulta.AppendLine("(select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            sConsulta.AppendLine("isnull(count(distinct VIS.ClienteClave), 0) as ClientesVisitados, ")
            sConsulta.AppendLine("ClientesVisitadosEnAgenda=0, ClientesLeidosEnAgenda=0, ClientesVisitadosFueraAgenda=0, ClientesLeidosFueraAgenda=0 ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave ")

            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave " & pvCondicion)

            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("union all ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ClientesVisitados=0, ")
            sConsulta.AppendLine("isnull(count(distinct VIS.ClienteClave), 0) as ClientesVisitadosEnAgenda, ")
            sConsulta.AppendLine("isnull(count(distinct(case when VIS.CodigoLeido = 1 then VIS.ClienteClave else null end)), 0) as ClientesLeidosEnAgenda, ")
            sConsulta.AppendLine("ClientesVisitadosFueraAgenda=0, ClientesLeidosFueraAgenda=0 ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")

            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave " & pvCondicion)

            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("union all ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ClientesVisitados=0, ")
            sConsulta.AppendLine("ClientesVisitadosEnAgenda=0, ClientesLeidosEnAgenda=0, ")
            sConsulta.AppendLine("isnull(count(distinct VIS.ClienteClave), 0) as ClientesVisitadosFueraAgenda, ")
            sConsulta.AppendLine("isnull(count(distinct(case when VIS.CodigoLeido = 1 then VIS.ClienteClave else null end)), 0) as ClientesLeidosFueraAgenda ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")

            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave " & pvCondicion)

            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine(") as Resultado ")
            sConsulta.AppendLine("group by ClaveCEDI, DiaClave, VendedorId, RUTClave ")
            Session("CodigosLeidos") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ProductoNegado
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select ClaveCEDI, DiaClave, VendedorId, RUTClave, sum(TotalNegado) as TotalNegado, sum(TotalNegadoEnAgenda) as TotalNegadoEnAgenda, ")
            sConsulta.AppendLine("sum(TotalImproductivoEnAgenda) as TotalImproductivoEnAgenda, sum(TotalNegadoFueraAgenda) as TotalNegadoFueraAgenda, ")
            sConsulta.AppendLine("sum(TotalImproductivoFueraAgenda) as TotalImproductivoFueraAgenda ")
            sConsulta.AppendLine("from ")
            sConsulta.AppendLine("(select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            sConsulta.AppendLine("isnull(sum(PRD.Factor * PRG.Cantidad), 0) as TotalNegado, TotalNegadoEnAgenda=0, TotalImproductivoEnAgenda=0, ")
            sConsulta.AppendLine("TotalNegadoFueraAgenda=0, TotalImproductivoFueraAgenda=0 ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave ")

            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave ")

            sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("inner join ProductoNegado PRG on TRP.TransProdId = PRG.TransProdId and PRG.PromocionClave is null ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRG.ProductoClave = PRD.ProductoClave ")
            sConsulta.AppendLine("and PRD.PRUTipoUnidad = PRG.TipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("union all ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, TotalNegado=0, ")
            sConsulta.AppendLine("isnull(sum(PRD.Factor * PRG.Cantidad), 0) as TotalNegadoEnAgenda, TotalImproductivoEnAgenda=0, ")
            sConsulta.AppendLine("TotalNegadoFueraAgenda=0, TotalImproductivoFueraAgenda=0 ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")

            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave ")

            sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("inner join ProductoNegado PRG on TRP.TransProdId = PRG.TransProdId AND PRG.PromocionClave is null ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRG.ProductoClave = PRD.ProductoClave ")
            sConsulta.AppendLine("and PRD.PRUTipoUnidad = PRG.TipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("union all ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, TotalNegado=0, TotalNegadoEnAgenda=0, ")
            sConsulta.AppendLine("isnull(sum(IMR.Cantidad), 0) as TotalImproductivoEnAgenda, TotalNegadoFueraAgenda=0, TotalImproductivoFueraAgenda=0 ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")

            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave ")

            sConsulta.AppendLine("inner join ImproductividadProd IMR on IMR.VisitaClave = VIS.VisitaClave and IMR.DiaClave = AGV.DiaClave " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("union all ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, TotalNegado=0, ")
            sConsulta.AppendLine("TotalNegadoEnAgenda=0, TotalImproductivoEnAgenda=0, ")
            sConsulta.AppendLine("isnull(sum(PRD.Factor * PRG.Cantidad), 0) as TotalNegadoFueraAgenda, TotalImproductivoFueraAgenda=0 ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")

            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave ")

            sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("inner join ProductoNegado PRG on TRP.TransProdId = PRG.TransProdId AND PRG.PromocionClave is null ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRG.ProductoClave = PRD.ProductoClave ")
            sConsulta.AppendLine("and PRD.PRUTipoUnidad = PRG.TipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("union all ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, TotalNegado=0, TotalNegadoEnAgenda=0, ")
            sConsulta.AppendLine("TotalImproductivoEnAgenda=0, TotalNegadoFueraAgenda=0, isnull(sum(IMR.Cantidad), 0) as TotalImproductivoFueraAgenda ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave  AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")

            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave ")

            sConsulta.AppendLine("inner join ImproductividadProd IMR on IMR.VisitaClave = VIS.VisitaClave and IMR.DiaClave = AGV.DiaClave " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine(") as Resultado ")
            sConsulta.AppendLine("group by ClaveCEDI, DiaClave, VendedorId, RUTClave ")
            Session("ProductoNegado") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--Producto Promocional no Entregado
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select ClaveCEDI, DiaClave, VendedorId, RUTClave, sum(TotalNegado) as TotalNegado, sum(TotalNegadoEnAgenda) as TotalNegadoEnAgenda, ")
            sConsulta.AppendLine("sum(TotalImproductivoEnAgenda) as TotalImproductivoEnAgenda, sum(TotalNegadoFueraAgenda) as TotalNegadoFueraAgenda, ")
            sConsulta.AppendLine("sum(TotalImproductivoFueraAgenda) as TotalImproductivoFueraAgenda ")
            sConsulta.AppendLine("from( ")

            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            sConsulta.AppendLine("isnull(sum(PRD.Factor * PRG.Cantidad), 0) as TotalNegado, TotalNegadoEnAgenda=0, TotalImproductivoEnAgenda=0, ")
            sConsulta.AppendLine("TotalNegadoFueraAgenda=0, TotalImproductivoFueraAgenda=0 ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave ")
            sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("inner join ProductoNegado PRG on TRP.TransProdId = PRG.TransProdId and not PRG.PromocionClave is null ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRG.ProductoClave = PRD.ProductoClave ")
            sConsulta.AppendLine("and PRD.PRUTipoUnidad = PRG.TipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")

            sConsulta.AppendLine("union all ")

            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, TotalNegado=0, ")
            sConsulta.AppendLine("isnull(sum(PRD.Factor * PRG.Cantidad), 0) as TotalNegadoEnAgenda, TotalImproductivoEnAgenda=0, ")
            sConsulta.AppendLine("TotalNegadoFueraAgenda=0, TotalImproductivoFueraAgenda=0 ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave ")
            sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("inner join ProductoNegado PRG on TRP.TransProdId = PRG.TransProdId AND not PRG.PromocionClave is null ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRG.ProductoClave = PRD.ProductoClave ")
            sConsulta.AppendLine("and PRD.PRUTipoUnidad = PRG.TipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")

            sConsulta.AppendLine("union all ")

            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, TotalNegado=0, ")
            sConsulta.AppendLine("TotalNegadoEnAgenda=0, TotalImproductivoEnAgenda=0, ")
            sConsulta.AppendLine("isnull(sum(PRD.Factor * PRG.Cantidad), 0) as TotalNegadoFueraAgenda, TotalImproductivoFueraAgenda=0 ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave ")
            sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("inner join ProductoNegado PRG on TRP.TransProdId = PRG.TransProdId AND not PRG.PromocionClave is null ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRG.ProductoClave = PRD.ProductoClave ")
            sConsulta.AppendLine("and PRD.PRUTipoUnidad = PRG.TipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")

            sConsulta.AppendLine("union all ")

            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, TotalNegado=0, ")
            sConsulta.AppendLine("TotalNegadoEnAgenda=0, isnull(sum(PRD.Factor * TPD.Cantidad), 0) as TotalImproductivoEnAgenda, ")
            sConsulta.AppendLine("TotalNegadoFueraAgenda=0, TotalImproductivoFueraAgenda=0 ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103)  = Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave ")
            sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave and TRP.tipo = 1 and TRP.TipoFase <>0 ")
            sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId and TPD.Promocion = 2 ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on TPD.ProductoClave = PRD.ProductoClave  ")
            sConsulta.AppendLine("and PRD.PRUTipoUnidad = TPD.TipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")

            sConsulta.AppendLine("union all ")

            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, TotalNegado=0, ")
            sConsulta.AppendLine("TotalNegadoEnAgenda=0,  TotalImproductivoEnAgenda=0, ")
            sConsulta.AppendLine("TotalNegadoFueraAgenda=0, isnull(sum(PRD.Factor * TPD.Cantidad), 0) as TotalImproductivoFueraAgenda ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),VIS.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave ")
            sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave and TRP.tipo = 1 and TRP.TipoFase <>0 ")
            sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId and TPD.Promocion = 2 ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on TPD.ProductoClave = PRD.ProductoClave  ")
            sConsulta.AppendLine("and PRD.PRUTipoUnidad = TPD.TipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")


            sConsulta.AppendLine(") as Resultado ")
            sConsulta.AppendLine("group by ClaveCEDI, DiaClave, VendedorId, RUTClave ")
            Session("ProductoPromoNoEntregado") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesProductoNegado
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("set nocount on ")
            sConsulta.AppendLine("if (select object_id('tempdb..#Tmp1')) is not null drop table #Tmp1 ")
            sConsulta.AppendLine("select * into #Tmp1 from ( ")
            sConsulta.AppendLine("SELECT AGV.ClaveCEDI, VIS.VisitaClave, VIS.ClienteClave, VIS.DiaClave, VIS.VendedorId, VIS.RUTClave, VIS.FechaHoraInicial ")
            sConsulta.AppendLine("FROM AgendaVendedor AGV ")
            sConsulta.AppendLine("INNER JOIN Visita VIS ON AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")

            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave " & pvCondicion)

            sConsulta.AppendLine(") as Resultado ")
            sConsulta.AppendLine("select ClaveCEDI, DiaClave, VendedorId, RUTClave, ")
            sConsulta.AppendLine("sum(TotalNegadoEnAgenda) as TotalNegadoEnAgenda, sum(TotalImproductivoEnAgenda) as TotalImproductivoEnAgenda, ")
            sConsulta.AppendLine("sum(TotalNegadoFueraAgenda) as TotalNegadoFueraAgenda, sum(TotalImproductivoFueraAgenda) as TotalImproductivoFueraAgenda ")
            sConsulta.AppendLine("FROM ")
            sConsulta.AppendLine("(select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            sConsulta.AppendLine("isnull(count(distinct AGV.ClienteClave), 0) as TotalNegadoEnAgenda, ")
            sConsulta.AppendLine("TotalImproductivoEnAgenda=0, ")
            sConsulta.AppendLine("TotalNegadoFueraAgenda=0, TotalImproductivoFueraAgenda=0 ")
            sConsulta.AppendLine("from #Tmp1 as AGV ")
            sConsulta.AppendLine("INNER JOIN Dia ON AGV.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),AGV.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join TransProd TRP on AGV.VisitaClave = TRP.VisitaClave and AGV.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("inner join ProductoNegado PRG on TRP.TransProdId = PRG.TransProdId AND PRG.PromocionClave is null ")
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("union all ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            sConsulta.AppendLine("TotalNegadoEnAgenda=0, ")
            sConsulta.AppendLine("isnull(count(distinct(case when IMR.VisitaClave is null then null else AGV.ClienteClave end)), 0) as TotalImproductivoEnAgenda, ")
            sConsulta.AppendLine("TotalNegadoFueraAgenda=0, TotalImproductivoFueraAgenda=0 ")
            sConsulta.AppendLine("from #Tmp1 as AGV ")
            sConsulta.AppendLine("INNER JOIN Dia ON AGV.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),AGV.FechaHoraInicial,103) ")
            'sConsulta.AppendLine("inner join TransProd TRP on AGV.VisitaClave = TRP.VisitaClave and AGV.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("inner join ImproductividadProd IMR on IMR.VisitaClave = AGV.VisitaClave and IMR.DiaClave = AGV.DiaClave ")
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("union all ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            sConsulta.AppendLine("TotalNegadoEnAgenda=0, TotalImproductivoEnAgenda=0, ")
            sConsulta.AppendLine("isnull(count(distinct AGV.ClienteClave), 0) as TotalNegadoFueraAgenda, ")
            sConsulta.AppendLine("TotalImproductivoFueraAgenda=0 ")
            sConsulta.AppendLine("from #Tmp1 as AGV ")
            sConsulta.AppendLine("INNER JOIN Dia ON AGV.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),AGV.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join TransProd TRP on AGV.VisitaClave = TRP.VisitaClave and AGV.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("inner join ProductoNegado PRG on TRP.TransProdId = PRG.TransProdId AND PRG.PromocionClave is null ")
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("union all ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            sConsulta.AppendLine("TotalNegadoEnAgenda=0, TotalImproductivoEnAgenda=0, ")
            sConsulta.AppendLine("TotalNegadoFueraAgenda=0, ")
            sConsulta.AppendLine("isnull(count(distinct(case when IMR.VisitaClave is null then null else AGV.ClienteClave end)), 0) as TotalImproductivoFueraAgenda ")
            sConsulta.AppendLine("from #Tmp1 as AGV ")
            sConsulta.AppendLine("INNER JOIN Dia ON AGV.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),AGV.FechaHoraInicial,103) ")
            'sConsulta.AppendLine("inner join TransProd TRP on AGV.VisitaClave = TRP.VisitaClave and AGV.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("inner join ImproductividadProd IMR on IMR.VisitaClave = AGV.VisitaClave and IMR.DiaClave = AGV.DiaClave ")
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine(") as Resultado ")
            sConsulta.AppendLine("group by ClaveCEDI, DiaClave, VendedorId, RUTClave ")
            sConsulta.AppendLine("drop table #Tmp1 ")
            sConsulta.AppendLine("set nocount off ")
            Session("ClientesProductoNegado") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--Clientes Producto Promocional No Entregado
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("set nocount on ")
            sConsulta.AppendLine("if (select object_id('tempdb..#Tmp1')) is not null drop table #Tmp1 ")
            sConsulta.AppendLine("select * into #Tmp1 from ( ")
            sConsulta.AppendLine("SELECT AGV.ClaveCEDI, VIS.VisitaClave, VIS.ClienteClave, VIS.DiaClave, VIS.VendedorId, VIS.RUTClave, VIS.FechaHoraInicial ")
            sConsulta.AppendLine("FROM AgendaVendedor AGV ")
            sConsulta.AppendLine("INNER JOIN Visita VIS ON AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")

            sConsulta.AppendLine("INNER JOIN Dia ON VIS.DiaClave=DIA.DiaClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave " & pvCondicion)

            sConsulta.AppendLine(") as Resultado ")

            sConsulta.AppendLine("select ClaveCEDI, DiaClave, VendedorId, RUTClave, ")
            sConsulta.AppendLine("sum(TotalNegadoEnAgenda) as TotalNegadoEnAgenda, sum(TotalImproductivoEnAgenda) as TotalImproductivoEnAgenda, ")
            sConsulta.AppendLine("sum(TotalNegadoFueraAgenda) as TotalNegadoFueraAgenda, sum(TotalImproductivoFueraAgenda) as TotalImproductivoFueraAgenda ")
            sConsulta.AppendLine("FROM ")

            sConsulta.AppendLine("(select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            sConsulta.AppendLine("isnull(count(distinct AGV.ClienteClave), 0) as TotalNegadoEnAgenda, ")
            sConsulta.AppendLine("TotalImproductivoEnAgenda=0, ")
            sConsulta.AppendLine("TotalNegadoFueraAgenda=0, TotalImproductivoFueraAgenda=0 ")
            sConsulta.AppendLine("from #Tmp1 as AGV ")
            sConsulta.AppendLine("INNER JOIN Dia ON AGV.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),AGV.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join TransProd TRP on AGV.VisitaClave = TRP.VisitaClave and AGV.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("inner join ProductoNegado PRG on TRP.TransProdId = PRG.TransProdId AND Not PRG.PromocionClave is null ")
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")

            sConsulta.AppendLine("union all ")

            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            sConsulta.AppendLine("TotalNegadoEnAgenda=0, TotalImproductivoEnAgenda=0, ")
            sConsulta.AppendLine("isnull(count(distinct AGV.ClienteClave), 0) as TotalNegadoFueraAgenda, ")
            sConsulta.AppendLine("TotalImproductivoFueraAgenda=0 ")
            sConsulta.AppendLine("from #Tmp1 as AGV ")
            sConsulta.AppendLine("INNER JOIN Dia ON AGV.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),AGV.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join TransProd TRP on AGV.VisitaClave = TRP.VisitaClave and AGV.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("inner join ProductoNegado PRG on TRP.TransProdId = PRG.TransProdId AND not PRG.PromocionClave is null ")
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")

            sConsulta.AppendLine("union all ")

            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            sConsulta.AppendLine("TotalNegadoEnAgenda=0,isnull(count(distinct AGV.ClienteClave), 0) as TotalImproductivoEnAgenda, ")
            sConsulta.AppendLine("TotalNegadoFueraAgenda=0, ")
            sConsulta.AppendLine("TotalImproductivoFueraAgenda=0 ")
            sConsulta.AppendLine("from #Tmp1 as AGV ")
            sConsulta.AppendLine("INNER JOIN Dia ON AGV.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),AGV.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join TransProd TRP on AGV.VisitaClave = TRP.VisitaClave and AGV.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId and TPD.Promocion = 2 ")
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")

            sConsulta.AppendLine("union all ")

            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            sConsulta.AppendLine("TotalNegadoEnAgenda=0, TotalImproductivoEnAgenda=0, ")
            sConsulta.AppendLine("TotalNegadoFueraAgenda=0, ")
            sConsulta.AppendLine("isnull(count(distinct AGV.ClienteClave), 0) as TotalImproductivoFueraAgenda ")
            sConsulta.AppendLine("from #Tmp1 as AGV ")
            sConsulta.AppendLine("INNER JOIN Dia ON AGV.DiaClave=DIA.DiaClave AND Convert(varchar(20),DIA.FechaCaptura,103) <> Convert(varchar(20),AGV.FechaHoraInicial,103) ")
            sConsulta.AppendLine("inner join TransProd TRP on AGV.VisitaClave = TRP.VisitaClave and AGV.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId and TPD.Promocion = 2 ")
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")

            sConsulta.AppendLine(") as Resultado ")
            sConsulta.AppendLine("group by ClaveCEDI, DiaClave, VendedorId, RUTClave ")
            sConsulta.AppendLine("drop table #Tmp1 ")
            sConsulta.AppendLine("set nocount off ")
            Session("ClientesProductoPromoNoEntregado") = sConsulta.ToString
        End If
        Return True
    End Function

    Private Function ConsultaEfectividadPorRutaLactigurth(ByVal ins As DBConexion.cConexionSQL, ByVal pvDetallado As Boolean, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        Dim pvCondicionClientes As String

        pvCondicionClientes = pvCondicion
        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "Dia.FechaCaptura")
            pvCondicionClientes = strWhereFecha(pvCondicionClientes, "Dia.FechaCaptura")
        End If
        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "RUT.RUTClave")
        pvCondicion = strWhereCentrosDistribucion(pvCondicion, "ALN.Clave")
        pvCondicionClientes = strWhereCentrosDistribucion(pvCondicionClientes, "ALN.Clave")

        Select Case ddlFecha.SelectedIndex
            Case 0 '=
                Session("FechaInicial") = txtFInicio.Text
                Session("FechaFinal") = txtFInicio.Text
            Case 1 '<>
                Session("FechaInicial") = txtFInicio.Text
                Session("FechaFinal") = txtFInicio.Text
            Case 2 '>
                Session("FechaInicial") = txtFInicio.Text
                Session("FechaFinal") = txtFInicio.Text
            Case 3 '<
                Session("FechaInicial") = txtFInicio.Text
                Session("FechaFinal") = txtFInicio.Text
            Case 4 '>=
                Session("FechaInicial") = txtFInicio.Text
                Session("FechaFinal") = txtFInicio.Text
            Case 5 '<=
                Session("FechaInicial") = txtFInicio.Text
                Session("FechaFinal") = txtFInicio.Text
            Case 6 '/
                Session("FechaInicial") = txtFInicio.Text
                Session("FechaFinal") = txtFFinal.Text
        End Select

        If pvDetallado Then
            '--Query (ReporteEfectividadXRutaDet)
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct ALN.Nombre as Almacen, DIA.FechaCaptura, VEN.VendedorId, VEN.Nombre as Vendedor, RUT.RUTClave, ")
            sConsulta.AppendLine("RUT.Descripcion as Ruta, ALN.Clave as AlmacenId, Dia.DiaClave ")
            sConsulta.AppendLine("from (select distinct DiaClave, VendedorId, RUTClave, ClaveCEDI from AgendaVendedor) AGV ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            'Session("Query") = sConsulta.ToString

            Dim dt As Data.DataTable
            dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
            If dt.Rows.Count = 0 Then
                Return False
            End If
            Session("DataTable") = dt

            sConsulta = New StringBuilder
            '--Tiempos
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select AGV.ClaveCEDI as AlmacenId, VIS.DiaClave, VIS.VendedorId, VIS.RUTClave, ")
            sConsulta.AppendLine("min(VIS.FechaHoraInicial) as HoraInicial, max(VIS.FechaHoraFinal) as HoraFinal, ")
            sConsulta.AppendLine("datediff(second, min(VIS.FechaHoraInicial), max(VIS.FechaHoraFinal)) as TiempoRecorrido, ")
            sConsulta.AppendLine("sum(datediff(second, VIS.FechaHoraInicial, VIS.FechaHoraFinal)) as TiempoVisita ")
            sConsulta.AppendLine("from Visita VIS ")
            sConsulta.AppendLine("inner Join (select distinct DiaClave, VendedorId, RUTClave, ClienteClave, ClaveCEDI from AgendaVendedor) AGV ")
            sConsulta.AppendLine("on VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorId and VIS.RUTClave = AGV.RUTClave and VIS.ClienteClave = AGV.ClienteClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, VIS.DiaClave, VIS.VendedorId, VIS.RUTClave ")
            Session("Tiempos") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--TotalVisitados
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RutClave, ")
            sConsulta.AppendLine("isnull(count(distinct VIS.ClienteClave), 0) as TotalCliente ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and AGV.DiaClave = VIS.DiaClave and AGV.VendedorId = VIS.VendedorId and AGV.RutClave = VIS.RutClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RutClave ")
            Session("TotalVisitados") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesVisitadosConVenta
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CLI.ClienteClave, CLI.RazonSocial as Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente Cli on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave ")
            sConsulta.AppendLine("and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("and TRP.Tipo = 1 and TRP.TipoFase <> 0 ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("Order By Nombre ")
            Session("ClientesVisitadosConVenta") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesVisitadosSinVenta
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CLI.ClienteClave, CLI.RazonSocial as Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("and not VIS.VisitaClave in (select TRP.VisitaClave from TransProd TRP where TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave and TRP.Tipo = 1 and TRP.TipoFase <> 0) ")
            sConsulta.AppendLine("and not VIS.ClienteClave in (select VIS1.ClienteClave from Visita VIS1 inner join TransProd TRP on VIS1.VisitaClave = TRP.VisitaClave and AGV.DiaClave = TRP.DiaClave and TRP.Tipo = 1 and TRP.TipoFase <> 0) ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("order by Nombre ")
            Session("ClientesVisitadosSinVenta") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--TotalVisitadosSinVenta
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            sConsulta.AppendLine("isnull(count(distinct AGV.ClienteClave), 0) - isnull(count(distinct(case when TRP.VisitaClave is null then null else VIS.ClienteClave end)), 0) as TotalCliente ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("left join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave and VIS.ClienteClave = AGV.ClienteClave and TRP.Tipo = 1 and TRP.TipoFase <> 0 ")
            sConsulta.AppendLine("left join ImproductividadVenta IMV on IMV.VisitaClave = VIS.VisitaClave and IMV.DiaClave = VIS.DiaClave and not VIS.VisitaClave is null ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            Session("TotalVisitadosSinVenta") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ImproductividadVenta
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CLI.ClienteClave, CLI.RazonSocial as Nombre, ")
            sConsulta.AppendLine("(select Descripcion from VAVDescripcion where VarCodigo = 'Motimpro' and VAVClave=IMV.TipoMotivo and VADTipoLenguaje = '" & Session("lenguaje") & "') as Motivo, ")
            sConsulta.AppendLine("AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join ImproductividadVenta IMV on IMV.VisitaClave = VIS.VisitaClave and IMV.DiaClave = VIS.DiaClave ")
            sConsulta.AppendLine("and not VIS.ClienteClave in (select VIS1.ClienteClave from Visita VIS1 inner join TransProd TRP on VIS1.VisitaClave = TRP.VisitaClave and AGV.DiaClave = TRP.DiaClave and TRP.Tipo = 1 and TRP.TipoFase <> 0) ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("order by Nombre ")
            Session("ImproductividadVenta") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--TotalVisitadosAEncuestar
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RutClave, ")
            sConsulta.AppendLine("isnull(count(distinct VIS.ClienteClave), 0) as TotalCliente ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join CenCli CEC on AGV.ClienteClave = CEC.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and convert(datetime,agv.diaclave,103) = VIS.DiaClave and AGV.VendedorId = VIS.VendedorId and AGV.RutClave = VIS.RutClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RutClave ")
            Session("TotalVisitadosAEncuestar") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesEncuestados
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CLI.ClienteClave, CLI.RazonSocial as Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join Encuesta ENC on Enc.VisitaClave = VIS.VisitaClave and Enc.DiaClave = VIS.DiaClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("order by Nombre ")
            Session("ClientesEncuestados") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesNoEncuestados
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CLI.ClienteClave, CLI.RazonSocial as Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join CenCli CEC on CLI.ClienteClave = CEC.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("and CLI.ClienteClave not in( ")
            sConsulta.AppendLine("select distinct CLI1.ClienteClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV1 ")
            sConsulta.AppendLine("inner join Cliente CLI1 on AGV1.ClienteClave = CLI1.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS1 on CLI1.ClienteClave = VIS1.ClienteClave and VIS1.DiaClave = AGV1.DiaClave ")
            sConsulta.AppendLine("and VIS1.VendedorId = AGV1.VendedorID and VIS1.RUTClave = AGV1.RUTClave ")
            sConsulta.AppendLine("inner join Encuesta ENC on Enc.VisitaClave = VIS1.VisitaClave and Enc.DiaClave = VIS1.DiaClave ")
            sConsulta.AppendLine("where AGV.DiaClave = AGV1.DiaClave and AGV.VendedorId = AGV1.VendedorId and AGV.RutClave = AGV1.RutClave) ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("order by Nombre ")
            Session("ClientesNoEncuestados") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--CodigosLeidos
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CLI.ClienteClave, CLI.RazonSocial as Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave and VIS.CodigoLeido = 1 ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("order by Nombre ")
            Session("CodigosLeidos") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--CodigosNoLeidos
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CLI.ClienteClave, CLI.RazonSocial as Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave and VIS.CodigoLeido = 0 ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("order by Nombre ")
            Session("CodigosNoLeidos") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ProductoNegado
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select PRO.Nombre, sum(PRD.Factor * PRG.Cantidad) as Cantidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("inner join ProductoNegado PRG on TRP.TransProdId = PRG.TransProdId ")
            sConsulta.AppendLine("inner join Producto PRO on PRG.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRO.ProductoClave = PRD.ProductoClave and PRD.PRUTipoUnidad = PRG.TipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by PRO.Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            Session("ProductoNegado") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ImproductividadProducto
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct PRO.Nombre, ")
            sConsulta.AppendLine("(select Descripcion from VAVDescripcion where VarCodigo = 'Motimpro' and VAVClave = IMR.TipoMotivo and VADTipoLenguaje = '" & Session("lenguaje") & "') as Motivo, ")
            sConsulta.AppendLine("sum(IMR.Cantidad) as Cantidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join ImproductividadProd IMR on IMR.VisitaClave = VIS.VisitaClave and IMR.DiaClave = AGV.DiaClave ")
            sConsulta.AppendLine("inner join Producto PRO on IMR.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by PRO.Nombre, IMR.TipoMotivo, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            Session("ImproductividadProducto") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--MotivosImproductividad
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct (select Descripcion from VAVDescripcion where VarCodigo = 'Motimpro' and VAVClave = IMR.TipoMotivo and VADTipoLenguaje = '" & Session("lenguaje") & "') as Motivo, ")
            sConsulta.AppendLine("sum(IMR.Cantidad) as Cantidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join ImproductividadProd IMR on IMR.VisitaClave = VIS.VisitaClave and IMR.DiaClave = AGV.DiaClave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by IMR.TipoMotivo, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            Session("MotivosImproductividad") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesProductoNegado
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select CLI.RazonSocial as Cliente, PRO.Nombre as Producto, ")
            sConsulta.AppendLine("(select Descripcion from VAVDescripcion where VarCodigo = 'UNIDADV' and VAVClave = PRG.TipoUnidad and VADTipoLenguaje = '" & Session("lenguaje") & "') as Unidad, ")
            sConsulta.AppendLine("sum(PRG.Cantidad) as Cantidad, ")
            sConsulta.AppendLine("sum(PRD.Factor * PRG.Cantidad) as CantidadUnitaria, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("inner join ProductoNegado PRG on TRP.TransProdId = PRG.TransProdId ")
            sConsulta.AppendLine("inner join Producto PRO on PRG.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRO.ProductoClave = PRD.ProductoClave and PRD.PRUTipoUnidad = PRG.TipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by CLI.RazonSocial, PRO.Nombre, PRG.TipoUnidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("order by CLI.RazonSocial, PRO.Nombre, PRG.TipoUnidad ")
            Session("ClientesProductoNegado") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesImproductividadProducto
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select CLI.RazonSocial as Cliente, PRO.Nombre as Producto, ")
            sConsulta.AppendLine("sum(IMR.Cantidad) as Cantidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave=AGV.RUTClave ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join ImproductividadProd IMR on IMR.VisitaClave = VIS.VisitaClave and IMR.DiaClave = AGV.DiaClave ")
            sConsulta.AppendLine("inner join Producto PRO on IMR.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave " & pvCondicion)
            sConsulta.AppendLine("group by CLI.RazonSocial, PRO.Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            Session("ClientesImproductividadProducto") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--TotalClientes
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select isnull(count(distinct AGV.ClienteClave), 0) as TotalCliente ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId " & pvCondicionClientes)
            Session("TotalClientes") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--Total Clientes Visitados
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select isnull(count(distinct AGV.ClienteClave), 0) as TotalCliente ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("and CLI.ClienteClave in ( ")
            sConsulta.AppendLine("select ClienteClave from Visita VIS where VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorId and VIS.RUTClave = AGV.RUTClave) ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId " & pvCondicionClientes)
            Session("TotalClientesVisitados") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesNoVisitados
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CLI.ClienteClave, CLI.RazonSocial as Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("and CLI.ClienteClave not in ( ")
            sConsulta.AppendLine("select ClienteClave from Visita VIS where VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorId and VIS.RUTClave = AGV.RUTClave) ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId " & pvCondicionClientes)
            sConsulta.AppendLine("order by Nombre ")
            Session("ClientesNoVisitados") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--Clientes Visitados
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct CLI.ClienteClave, CLI.RazonSocial as Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("and CLI.ClienteClave in ( ")
            sConsulta.AppendLine("select ClienteClave from Visita VIS where VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorId and VIS.RUTClave = AGV.RUTClave) ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId " & pvCondicionClientes)
            sConsulta.AppendLine("order by Nombre ")
            Session("ClientesVisitados") = sConsulta.ToString

        Else
            sConsulta = New StringBuilder
            '--Query
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select distinct ALN.Clave + ' ' + ALN.Nombre as Almacen, DIA.FechaCaptura, VEN.Nombre as Vendedor, RUT.Rutclave + ' ' + RUT.Descripcion as Ruta, ")
            sConsulta.AppendLine("ALN.Clave as ClaveCEDI, Dia.DiaClave, VEN.VendedorId, RUT.RUTClave ")
            sConsulta.AppendLine("from (select distinct DiaClave, VendedorId, RUTClave, ClaveCEDI from AgendaVendedor) AGV ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI=ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave=DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave=RUT.RUTClave " & pvCondicion)
            'Session("Query") = sConsulta.ToString

            Dim dt As Data.DataTable
            dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
            If dt.Rows.Count = 0 Then
                Return False
            End If
            Session("DataTable") = dt

            sConsulta = New StringBuilder
            '--Tiempos
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, VIS.DiaClave, VIS.VendedorId, VIS.RUTClave, ")
            sConsulta.AppendLine("datediff(second,min(VIS.FechaHoraInicial),max(VIS.FechaHoraFinal)) as TiempoRecorrido, ")
            sConsulta.AppendLine("sum(datediff(second, VIS.FechaHoraInicial, VIS.FechaHoraFinal)) as TiempoVisita ")
            sConsulta.AppendLine("from Visita VIS ")
            sConsulta.AppendLine("inner join AgendaVendedor AGV on VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorId and VIS.RUTClave = AGV.RUTClave and Vis.ClienteClave = AGV.ClienteClave ")
            sConsulta.AppendLine("group by AGV.ClaveCEDI, VIS.DiaClave, VIS.VendedorId, VIS.RUTClave ")
            Session("Tiempos") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesVisitadosConVenta
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            sConsulta.AppendLine("isnull(count(distinct CLI.ClienteClave), 0) as ClientesVisitados, ")
            sConsulta.AppendLine("isnull(count(distinct(case when TRP.VisitaClave is null then null else VIS.ClienteClave end)), 0) as ClientesConVenta ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("left join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave and TRP.Tipo = 1 and TRP.TipoFase <> 0 ")
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            Session("ClientesVisitadosConVenta") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ImproductividadVenta
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            sConsulta.AppendLine("isnull(count(distinct AGV.ClienteClave), 0) - isnull(count(distinct(case when TRP.VisitaClave is null then null else VIS.ClienteClave end)), 0) as ClientesNoVenta, ")
            sConsulta.AppendLine("isnull(count(distinct(case when (TRP.VisitaClave is null and not IMV.VisitaClave is null) then VIS.ClienteClave else null end)), 0) as ClientesImproductivo ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("left join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave and VIS.ClienteClave = AGV.ClienteClave and TRP.Tipo = 1 and TRP.TipoFase <> 0 ")
            sConsulta.AppendLine("left join ImproductividadVenta IMV on IMV.VisitaClave = VIS.VisitaClave and IMV.DiaClave = VIS.DiaClave and not VIS.VisitaClave is null ")
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            Session("ImproductividadVenta") = sConsulta.ToString
            sConsulta = New StringBuilder

            sConsulta = New StringBuilder
            '--ClientesEncuestados
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            sConsulta.AppendLine("isnull(count(distinct CEC.ClienteClave), 0) as TotalClientes, ")
            sConsulta.AppendLine("isnull(count(distinct(case when ENC.ENCId is null then null else VIS.ClienteClave end)), 0) as TotalEncuestados ")
            sConsulta.AppendLine("from CenCli CEC ")
            sConsulta.AppendLine("inner join AgendaVendedor AGV on AGV.ClienteClave = CEC.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on CEC.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("left join Encuesta ENC on ENC.VisitaClave = VIS.VisitaClave and ENC.DiaClave = VIS.DiaClave ")
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            Session("ClientesEncuestados") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--CodigosLeidos
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            sConsulta.AppendLine("isnull(count(distinct VIS.ClienteClave), 0) as ClientesVisitados, ")
            sConsulta.AppendLine("isnull(count(distinct(case when VIS.CodigoLeido = 1 then VIS.ClienteClave else null end)), 0) as ClientesLeidos ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            Session("CodigosLeidos") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ProductoNegado
            'sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            'sConsulta.AppendLine("isnull(sum(PRD.Factor * PRG.Cantidad), 0) as TotalNegado, ")
            'sConsulta.AppendLine("isnull(sum(IMR.Cantidad), 0) as TotalImproductivo ")
            'sConsulta.AppendLine("from AgendaVendedor AGV ")
            'sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            'sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ")
            'sConsulta.AppendLine("inner join ProductoNegado PRG on TRP.TransProdId = PRG.TransProdId ")
            'sConsulta.AppendLine("inner join ProductoDetalle PRD on PRG.ProductoClave = PRD.ProductoClave ")
            'sConsulta.AppendLine("and PRD.PRUTipoUnidad = PRG.TipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
            'sConsulta.AppendLine("full outer join ImproductividadProd IMR on IMR.VisitaClave = VIS.VisitaClave and IMR.DiaClave = AGV.DiaClave ")
            'sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            'Session("ProductoNegado") = sConsulta.ToString

            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select ClaveCEDI, DiaClave, VendedorId, RUTClave, sum(TotalNegado) as TotalNegado, sum(TotalImproductivo) as TotalImproductivo from ")
            sConsulta.AppendLine("( ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            sConsulta.AppendLine("isnull(sum(PRD.Factor * PRG.Cantidad), 0) as TotalNegado, TotalImproductivo=0 ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("inner join ProductoNegado PRG on TRP.TransProdId = PRG.TransProdId ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRG.ProductoClave = PRD.ProductoClave ")
            sConsulta.AppendLine("and PRD.PRUTipoUnidad = PRG.TipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine("union all ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, TotalNegado=0, ")
            sConsulta.AppendLine("isnull(sum(IMR.Cantidad), 0) as TotalImproductivo ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join ImproductividadProd IMR on IMR.VisitaClave = VIS.VisitaClave and IMR.DiaClave = AGV.DiaClave ")
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            sConsulta.AppendLine(") as Resultado ")
            sConsulta.AppendLine("group by ClaveCEDI, DiaClave, VendedorId, RUTClave ")
            Session("ProductoNegado") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesProductoNegado
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ")
            sConsulta.AppendLine("isnull(count(distinct AGV.ClienteClave), 0) as TotalNegado, ")
            sConsulta.AppendLine("isnull(count(distinct(case when IMR.VisitaClave is null then null else VIS.ClienteClave end)), 0) as TotalImproductivo ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("inner join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("inner join ProductoNegado PRG on TRP.TransProdId = PRG.TransProdId ")
            sConsulta.AppendLine("full outer join ImproductividadProd IMR on IMR.VisitaClave = VIS.VisitaClave and IMR.DiaClave = AGV.DiaClave ")
            sConsulta.AppendLine("group by AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ")
            Session("ClientesProductoNegado") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--TotalClientes
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select isnull(count(distinct AGV.ClienteClave), 0) as TotalClientes, isnull(count(distinct VIS.ClienteClave), 0) as TotalVisitados ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("left join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and AGV.DiaClave = VIS.DiaClave and AGV.VendedorId = VIS.VendedorId and AGV.RutClave = VIS.RutClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId " & pvCondicionClientes)
            Session("TotalClientes") = sConsulta.ToString

            sConsulta = New StringBuilder
            '--ClientesVisitados
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("select AGV.DiaClave, isnull(count(distinct AGV.ClienteClave), 0) as TotalClientes, isnull(count(distinct VIS.ClienteClave), 0) as TotalVisitados ")
            sConsulta.AppendLine("from AgendaVendedor AGV ")
            sConsulta.AppendLine("left join Visita VIS on AGV.ClienteClave = VIS.ClienteClave and AGV.DiaClave = VIS.DiaClave and AGV.VendedorId = VIS.VendedorId and AGV.RutClave = VIS.RutClave ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = DIA.DIAClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId " & pvCondicionClientes)
            sConsulta.AppendLine("group by AGV.DiaClave ")
            Session("ClientesVisitados") = sConsulta.ToString


        End If
        Return True
    End Function

    Private Function ConsultaGastosDelVendedor(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "GAS.Fecha")
        End If
        pvCondicion = strWhereCentrosDistribucion(pvCondicion, "ALN.Clave")
        '--Gastos del vendedor
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("select distinct ALN.Clave + ' ' + ALN.Nombre as CEDI, GAS.Fecha, VEN.Nombre as Vendedor, GAS.Folio, ")
        sConsulta.AppendLine("VAD.Descripcion as Concepto, GAS.Importe as SubTotal, GAS.Impuesto, GAS.Total, GAS.Porcentaje, GAS.Comentario ")
        sConsulta.AppendLine("from Gasto GAS ")
        sConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VARcodigo = 'GASTIPO' and VAD.VAVclave = GAS.TipoConcepto and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' ")
        sConsulta.AppendLine("inner join Vendedor VEN on VEN.VendedorId = GAS.VendedorId ")
        sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI from AgendaVendedor) AGV on GAS.DiaClave = AGV.DiaClave and GAS.VendedorId = AGV.VendedorId  ")
        sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave " & pvCondicion)
        'Session("Query") = sConsulta.ToString
        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        Return True
    End Function

    Private Function ConsultaSolicitudes(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvClientes As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "SOL.FechaHora")
        End If
        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "RUT.RUTClave")
        pvCondicion = strWhereClientes(pvCondicion, pvClientes, "CLI.ClienteClave")

        'sConsulta.AppendLine("select ALN.Clave + ' ' + ALN.Nombre as CEDI, VEN.Nombre as Vendedor, RUT.RUTClave, RUT.Descripcion, ")
        'sConsulta.AppendLine("CLI.RazonSocial, SOL.Folio, VAD.descripcion as Peticion, VAD2.Descripcion as Area, SOL.Concepto, SOL.FechaHora as Fecha ")
        'sConsulta.AppendLine("from Solicitud SOL ")
        'sConsulta.AppendLine("inner join Visita VIS on SOL.VisitaClave = VIS.VisitaClave ")
        'sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
        'sConsulta.AppendLine("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ")
        'sConsulta.AppendLine("inner join Ruta RUT on RUT.RUTClave = VIS.RUTClave ")
        'sConsulta.AppendLine("inner join VAVDescripcion VAD on SOL.TipoPeticion = VAD.VAVClave and VAD.VARCodigo = 'solpetic' and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' ")
        'sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI from AgendaVendedor) AGV on VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorId ")
        'sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
        'sConsulta.AppendLine("inner join VAVDescripcion VAD2 on SOL.TipoArea = VAD2.VAVClave and VAD2.VARCodigo = 'soltarea' and VAD2.VADTipoLenguaje = '" & Session("lenguaje") & "' ")
        'sConsulta.AppendLine(pvCondicion)
        'Session("Query") = sConsulta.ToString

        'Dim dtConsulta As Data.DataTable = ins.EjecutarConsulta(Session("Query"))
        'If (dtConsulta.Rows.Count > 0) Then
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("select distinct ALN.Clave + ' ' + ALN.Nombre as CEDI, VEN.Nombre as Vendedor, RUT.RUTClave, RUT.Descripcion, ")
        sConsulta.AppendLine("CLI.Clave+'-'+CLI.RazonSocial as RazonSocial, SOL.Folio, SOL.Comentario as Peticion, VAD2.Descripcion as Area, SOL.Concepto, SOL.FechaHora as Fecha ")
        sConsulta.AppendLine("from Solicitud SOL ")
        sConsulta.AppendLine("inner join Visita VIS on SOL.VisitaClave = VIS.VisitaClave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
        sConsulta.AppendLine("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ")
        sConsulta.AppendLine("inner join Ruta RUT on RUT.RUTClave = VIS.RUTClave ")
        sConsulta.AppendLine("inner join VAVDescripcion VAD on SOL.TipoPeticion = VAD.VAVClave and VAD.VARCodigo = 'solpetic' and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' ")
        sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI from AgendaVendedor) AGV on VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorId ")
        sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
        sConsulta.AppendLine("inner join VAVDescripcion VAD2 on SOL.TipoArea = VAD2.VAVClave and VAD2.VARCodigo = 'soltarea' and VAD2.VADTipoLenguaje = '" & Session("lenguaje") & "' ")
        sConsulta.AppendLine(pvCondicion)
        'Session("Query") = sConsulta.ToString

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("select distinct ALN.Clave + ' ' + ALN.Nombre as CEDI, VAD2.Descripcion as Area, SOL.Concepto, count(*) as Cantidad ")
        sConsulta.AppendLine("from Solicitud SOL ")
        sConsulta.AppendLine("inner join Visita VIS on SOL.VisitaClave = VIS.VisitaClave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
        sConsulta.AppendLine("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ")
        sConsulta.AppendLine("inner join Ruta RUT on RUT.RUTClave = VIS.RUTClave ")
        sConsulta.AppendLine("inner join VAVDescripcion VAD on SOL.TipoPeticion = VAD.VAVClave and VAD.VARCodigo = 'solpetic' and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' ")
        sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI from AgendaVendedor) AGV on VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorId ")
        sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
        sConsulta.AppendLine("inner join VAVDescripcion VAD2 on SOL.TipoArea = VAD2.VAVClave and VAD2.VARCodigo = 'soltarea' and VAD2.VADTipoLenguaje = '" & Session("lenguaje") & "' ")
        sConsulta.AppendLine(pvCondicion & " ")
        sConsulta.AppendLine("group by VAD2.Descripcion, SOL.Concepto, ALN.Clave, ALN.Nombre ")
        Session("Query2") = sConsulta.ToString

        Return True
        'End If
        'Return False
    End Function

    Private Function ConsultaCanjes(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvClientes As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "VCA.Fecha")
        End If
        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "VCA.RutaClave")
        pvCondicion = strWhereCentrosDistribucion(pvCondicion, "VCA.Clave")
        pvCondicion = strWhereClientes(pvCondicion, pvClientes, "VCA.ClienteClave")
        pvCondicion = pvCondicion.Replace("VEN.VendedorId", "VCA.VendedorId")

        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("select *, (select Nombre from Producto PRO where PRO.ProductoClave = CAP.ProductoClave) as Producto ")
        sConsulta.AppendLine("from vw_Canjes VCA ")
        sConsulta.AppendLine("inner join CadPro CAP on VCA.CanClave = CAP.CanClave and VCA.PRUTipoUnidad = CAP.PRUTipoUnidad ")
        sConsulta.AppendLine(pvCondicion)
        'Session("Query") = sConsulta.ToString

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        Return True
    End Function

    Private Function ConsultaSaldosDeClientes(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvClientes As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "PUN.Fecha")
        End If
        'pvCondicion = strWhereRutas(pvCondicion, pvRutas, "RUT.RUTClave")
        pvCondicion = strWhereClientes(pvCondicion, pvClientes, "CLI.ClienteClave")
        pvCondicion = strWhereCentrosDistribucion(pvCondicion, "ALN.Clave")

        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("select distinct ALN.Clave + ' ' + ALN.Nombre as CEDI, VEN.Nombre as Vendedor, ")
        sConsulta.AppendLine("CLI.RazonSocial as Cliente, isnull(PUN.Saldo1, 0) as SaldoEncuesta, ")
        sConsulta.AppendLine("isnull((PUN.Saldo + ( ")
        sConsulta.AppendLine("select isnull(sum(CAR.Cantidad),0) as Cantidad1 ")
        sConsulta.AppendLine("from CliCap CLA ")
        sConsulta.AppendLine("inner join CadPro CAP on CLA.CANClave = CAP.CANClave and CLA.FechaInicial = CAP.FechaInicial and CLA.Rango1 = CAP.Rango1 and CLA.ProductoClave = CAP.ProductoClave ")
        sConsulta.AppendLine("inner join CADRango CAR on CAP.CANClave = CAR.CANClave and CAP.FechaInicial = CAR.FechaInicial and CAP.Rango1 = CAR.Rango1 ")
        sConsulta.AppendLine("where CLA.ClienteClave = CLI.ClienteClave))- PUN.Saldo1, 0) as SaldoVenta, ")
        sConsulta.AppendLine("isnull(PUN.Saldo + ")
        sConsulta.AppendLine("(select isnull(sum(CAR.Cantidad),0) as Cantidad1 ")
        sConsulta.AppendLine("from CliCap CLA ")
        sConsulta.AppendLine("inner join CadPro CAP on CLA.CANClave = CAP.CANClave and CLA.FechaInicial = CAP.FechaInicial and CLA.Rango1 = CAP.Rango1 and CLA.ProductoClave = CAP.ProductoClave ")
        sConsulta.AppendLine("inner join CADRango CAR on CAP.CANClave = CAR.CANClave and CAP.FechaInicial = CAR.FechaInicial and CAP.Rango1 = CAR.Rango1 ")
        sConsulta.AppendLine("where CLA.ClienteClave = CLI.ClienteClave), 0) as SaldoAcumulado, ")
        sConsulta.AppendLine("isnull( ")
        sConsulta.AppendLine("(select isnull(sum(CAR.Cantidad),0) as Cantidad1 ")
        sConsulta.AppendLine("from CliCap CLA ")
        sConsulta.AppendLine("inner join CadPro CAP on CLA.CANClave = CAP.CANClave and CLA.FechaInicial = CAP.FechaInicial and CLA.Rango1 = CAP.Rango1 and CLA.ProductoClave = CAP.ProductoClave ")
        sConsulta.AppendLine("inner join CADRango CAR on CAP.CANClave = CAR.CANClave and CAP.FechaInicial = CAR.FechaInicial and CAP.Rango1 = CAR.Rango1 ")
        sConsulta.AppendLine("where CLA.ClienteClave = CLI.ClienteClave), 0) as SaldoUtilizado, ")
        sConsulta.AppendLine("isnull(PUN.Saldo, 0) as SaldoPorUtilizar ")
        sConsulta.AppendLine("from Cliente CLI ")
        sConsulta.AppendLine("inner join Punto PUN on PUN.ClienteClave = CLI.ClienteClave ")
        sConsulta.AppendLine("inner join Visita VIS on VIS.ClienteClave = CLI.ClienteClave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorID = VEN.VendedorID ")
        sConsulta.AppendLine("inner join Ruta RUT on VIS.RUTClave = RUT.RUTClave ")
        sConsulta.AppendLine("inner join Secuencia SEC on SEC.ClienteClave = CLI.ClienteClave ")
        sConsulta.AppendLine("inner join VenRut VER on SEC.RutClave = VER.RutClave ")
        sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClienteClave, ClaveCEDI from AgendaVendedor) AGV on VIS.DiaClave = AGV.DiaClave and VEN.VendedorId = AGV.VendedorId and VIS.ClienteClave = AGV.ClienteClave ")
        sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
        sConsulta.AppendLine(pvCondicion)
        'Session("Query") = sConsulta.ToString

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        Return True
    End Function

    Private Function ConsultaConfiguracionDePremios(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        If pvFecha Then
            pvCondicion = strWhereFechaPremios(pvCondicion)
        End If

        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("select VAD.Descripcion as Unidad, CAN.Nombre as Canje, CAD.fechainicial, CAD.FechaFinal, CAR.Rango1 as Minimo, ")
        sConsulta.AppendLine("CAR.Rango2 as Maximo, CAR.Cantidad as Puntos, PRO.Nombre as Producto, CAP.Cantidad ")
        sConsulta.AppendLine("from Canje CAN ")
        sConsulta.AppendLine("inner join CANDetalleVig CAD on CAN.CanClave = CAD.CanClave ")
        sConsulta.AppendLine("inner join CADRango CAR on CAN.CanClave = CAR.CanClave and CAD.FechaInicial = CAR.FechaInicial ")
        sConsulta.AppendLine("inner join CadPro CAP on CAN.CanClave = CAP.CanClave and CAD.FechaInicial = CAP.FechaInicial and CAR.Rango1 = CAP.Rango1 ")
        sConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VARCodigo = 'UNIDADV' and VAD.VAVCLAVE = CAP.PRUTipoUnidad and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' ")
        sConsulta.AppendLine("inner join Producto PRO on CAP.ProductoClave = PRO.ProductoClave ")
        sConsulta.AppendLine(pvCondicion)
        'Session("Query") = sConsulta.ToString
        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        Return True
    End Function

    Private Function ConsultaTiemposEnRuta(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvFecha As Boolean) As Boolean

        Dim sConsulta As New StringBuilder
        Dim sCondicionKm As String = ""

        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "RUT.RUTClave")
        pvCondicion = strWhereCentrosDistribucion(pvCondicion, "ALN.Clave")
        sCondicionKm = pvCondicion
        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "Dia.FechaCaptura")
            sCondicionKm = strWhereFecha(sCondicionKm, "CAV.FechaHoraInicial")
        End If

        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("if (select object_id('tempdb..#TmpTiempos')) is not null drop table #TmpTiempos ")
        sConsulta.AppendLine("select * into #TmpTiempos from( ")
        sConsulta.AppendLine("select case when VEN.JornadaTrabajo = 1 then isnull(VEJ.VEJFechaInicial,VIS.FechaHoraInicial) else VIS.FechaHoraInicial end as HoraInicialJornada, case when VEN.JornadaTrabajo = 1 then isnull(VEJ.FechaFinal,VIS.FechaHoraFinal) else VIS.FechaHoraFinal end as HoraFinalJornada, VIS.VisitaClave, VIS.DiaClave, VIS.ClienteClave, VIS.VendedorId, VIS.RutClave, VIS.FechaHoraInicial, VIS.FechaHoraFinal, VIS.CodigoLeido, ")
        sConsulta.AppendLine("CLI.Clave as CLIClave, CLI.RazonSocial +' - '+cli.nombrecontacto as CLIRazonSocial, RUT.Descripcion as RUTDescripcion,  AGV.Orden as SECOrden, VEN.Nombre as VENNombre, ")
        sConsulta.AppendLine("ALN.Clave as ALNClave, ALN.Nombre as ALNNombre, VEN.Kilometraje ")
        sConsulta.AppendLine("from Visita VIS ")
        sConsulta.AppendLine("INNER JOIN Dia  ON Dia.DiaClave = VIS.DiaClave ")
        sConsulta.AppendLine("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ")
        sConsulta.AppendLine("left join Ruta RUT on RUT.RUTClave = VIS.RUTClave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
        sConsulta.AppendLine("left join VendedorJornada VEJ on VEN.VendedorId = VEJ.VendedorId and VIS.DiaClave = VEJ.DiaClave AND VEJ.DiaClave is not null  ")
        sConsulta.AppendLine("left join AgendaVendedor AGV on VIS.VendedorId = AGV.VendedorId and VIS.DiaClave = AGV.DiaClave and  AGV.ClienteClave = VIS.ClienteClave ")
        sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCH ON VCH.VendedorId = VEN.VendedorID AND Dia.FechaCaptura BETWEEN VCH.VCHFechaInicial AND VCH.FechaFinal ")
        sConsulta.AppendLine("left join Almacen ALN on VCH.AlmacenId = ALN.AlmacenID  ")
        sConsulta.AppendLine(pvCondicion & " ")
        sConsulta.AppendLine(")as t1 ")
        sConsulta.AppendLine("select Kilometraje,HoraInicialJornada,HoraFinalJornada,VENNombre as Vendedor, convert(datetime,convert(varchar(20), FechaHoraInicial, 112)) as Fecha, RUTClave + ' ' + RUTDescripcion as Ruta, ")
        sConsulta.AppendLine("max(SECOrden) as Secuencia, CLIClave as Clave, CLIRazonSocial as NombreCliente, CodigoNoLeido=(select case when CodigoLeido=0 then '*' else '' end), ")
        sConsulta.AppendLine("ImpCodigoNoLeido=(select case when CodigoLeido=0 then 1 else 0 end), ")
        sConsulta.AppendLine("0 as MinutosTransito, FechaHoraInicial as HoraInicio, FechaHoraFinal as HoraFin, datediff(s, FechaHoraInicial, FechaHoraFinal) as MinutosVisita, ")
        sConsulta.AppendLine("(select top 1 case when count(*) > 0 then 'SI' else 'NO' end from TransProd TRP where TRP.Tipo = 1 and TRP.TipoFase <> 0 and TRP.VisitaClave = TMP.VisitaClave and TRP.ClienteClave = TMP.ClienteClave) as Venta, ")
        sConsulta.AppendLine("convert(varchar(25), isnull((select VAD.Descripcion from ImproductividadVenta IMV inner join VAVDescripcion VAD on IMV.TipoMotivo = VAD.VAVClave and VAD.VARCodigo = 'MOTIMPRO' and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' where IMV.VisitaClave = TMP.VisitaClave AND IMV.DIACLAVE=TMP.DIACLAVE), 0)) as Concepto, ")
        sConsulta.AppendLine("(select sum(TRP.Total) from TransProd TRP where TRP.Tipo = 1 and TRP.TipoFase <> 0 and TRP.VisitaClave = TMP.VisitaClave and TRP.ClienteClave = TMP.ClienteClave) as TotalVenta, ")
        sConsulta.AppendLine("ALNClave + ' ' + ALNNombre as CEDI ")
        sConsulta.AppendLine("from #TmpTiempos TMP ")
        sConsulta.AppendLine("group by HoraInicialJornada,HoraFinalJornada,ALNClave, ALNNombre, VisitaClave, VENNombre, FechaHoraInicial, RUTClave, ClienteClave, CodigoLeido, ")
        sConsulta.AppendLine("CLIRazonSocial, FechaHoraInicial, FechaHoraFinal, ClienteClave, CLIClave, RUTClave, RUTDescripcion,TMP.DIACLAVE, Kilometraje ")
        sConsulta.AppendLine("order by ALNClave, VENNombre, RUTClave, FechaHoraInicial ")
        sConsulta.AppendLine("drop table #TmpTiempos ")
        sConsulta.AppendLine("set nocount off ")
        'Session("Query") = sConsulta.ToString

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("select ALN.Clave + ' ' + ALN.Nombre as CEDI, VEN.Nombre as Vendedor, RUT.RUTClave + ' ' + RUT.Descripcion as Ruta, ")
        sConsulta.AppendLine("convert(datetime, convert(varchar(20), FechaHoraInicial, 112)) as Fecha, CAV.KmInicial, CAV.KmFinal, CAV.Placa ")
        sConsulta.AppendLine("from CamionVendedor CAV ")
        sConsulta.AppendLine("inner join Vendedor VEN on CAV.VendedorId = VEN.VendedorId ")
        sConsulta.AppendLine("inner join (select distinct VendedorId, RUTClave, ClaveCEDI from AgendaVendedor) AGV on CAV.VendedorId = AGV.VendedorId ")
        sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
        sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave ")
        sConsulta.AppendLine(sCondicionKm & " ")
        sConsulta.AppendLine("set nocount off ")
        Session("Kilometraje") = sConsulta.ToString

        '--Query 2
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SELECT V.Nombre as Vendedor, SUM(SINVENTA) as SINVENTA ,SUM (VISITADOS)+SUM(NOVISITADOS) as TotalCLientes ,SUM (VISITADOS) AS VISITADOS, SUM(NOVISITADOS) as NOVISITADOS, ")
        sConsulta.AppendLine("CASE WHEN CAST((sum(T.NOVISITADOS+ T.VISITADOS)) AS FLOAT) = 0 THEN 0 ELSE (CAST(sum(T.VISITADOS) AS FLOAT) /CAST((sum(T.NOVISITADOS + T.VISITADOS)) AS FLOAT))*100 END AS VISITAEfectiva ,")
        sConsulta.AppendLine("CASE WHEN sum(t.VISITADOS) = 0 THEN 0 ELSE CAST((sum(t.VISITADOS - t.SINVENTA)) AS FLOAT)/CAST(sum(t.VISITADOS) AS FLOAT)*100 END  AS EfectividadCompra ,")
        sConsulta.AppendLine(" t.RutClave+' '+r.Descripcion as Ruta,Cedi")
        sConsulta.AppendLine("		FROM ( ")
        sConsulta.AppendLine("								select VIS.RutClave, VIS.VendedorId,  VIS.DiaClave, Aln.Clave+' '+ALn.Nombre as Cedi,")
        sConsulta.AppendLine("								COUNT(DISTINCT AGV.ClienteClave) as VISITADOS, 0 as NOVISITADOS, 0 as SINVENTA ")
        sConsulta.AppendLine("								from Visita VIS  ")
        sConsulta.AppendLine("								inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId  ")
        sConsulta.AppendLine("								inner join Dia on DIA.DiaClave=VIS.DiaClave AND convert(varchar(20), DIA.FechaCaptura, 101)=convert(varchar(20), VIS.FechaHoraInicial, 101)  ")
        sConsulta.AppendLine("								INNER JOIN AgendaVendedor AGV ON AGV.DiaClave = VIS.DiaClave AND AGV.ClienteClave = VIS.ClienteClave AND AGV.RUTClave = VIS.RUTClave AND AGV.VendedorId = VIS.VendedorID  ")
        sConsulta.AppendLine("								INNER JOIN Ruta RUT ON RUT.RUTClave = AGV.RUTClave  ")
        sConsulta.AppendLine("								INNER JOIN Almacen ALN ON ALN.Clave = AGV.ClaveCEDI  ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine("								GROUP BY VIS.RutClave, VIS.VendedorId,  VIS.DiaClave ,Aln.Clave,ALn.Nombre")
        sConsulta.AppendLine("								Union ")
        sConsulta.AppendLine("								SELECT AGV.RutClave, AGV.VendedorId,  AGV.DiaClave, Aln.Clave+' '+ALn.Nombre as Cedi,")
        sConsulta.AppendLine("								0 as VISITADOS, COUNT(DISTINCT AGV.ClienteClave) as NOVISITADOS, 0 AS SINVENTA ")
        sConsulta.AppendLine("								FROM AgendaVendedor AGV ")
        sConsulta.AppendLine("								INNER JOIN Dia ON Dia.DiaClave = AGV.DiaClave ")
        sConsulta.AppendLine("								LEFT JOIN Visita VIS ON VIS.RUTClave = AGV.RUTClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorID = AGV.VendedorId AND VIS.ClienteClave = AGV.ClienteClave ")
        sConsulta.AppendLine("								INNER JOIN Ruta RUT ON RUT.RUTClave = AGV.RUTClave ")
        sConsulta.AppendLine("								INNER JOIN Almacen ALN ON ALN.Clave = AGV.ClaveCEDI ")
        sConsulta.AppendLine("								INNER JOIN Vendedor VEN ON VEN.VendedorID = AGV.VendedorId ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine("								AND VIS.ClienteClave IS NULL ")
        sConsulta.AppendLine("								GROUP BY AGV.RutClave, AGV.VendedorId,  AGV.DiaClave ,Aln.Clave,ALn.Nombre")
        sConsulta.AppendLine("								UNION ")
        sConsulta.AppendLine("								SELECT AGV.RutClave, AGV.VendedorId,  AGV.DiaClave, Aln.Clave+' '+ALn.Nombre as Cedi,")
        sConsulta.AppendLine("								0 AS VISITADOS, 0 AS NOVISITADOS, COUNT (DISTINCT AGV.ClienteClave)as SINVENTA ")
        sConsulta.AppendLine("								FROM AgendaVendedor AGV ")
        sConsulta.AppendLine("								INNER JOIN Dia ON Dia.DiaClave = AGV.DiaClave ")
        sConsulta.AppendLine("								INNER JOIN Visita VIS ON VIS.RUTClave = AGV.RUTClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorID = AGV.VendedorId AND VIS.ClienteClave = AGV.ClienteClave ")
        sConsulta.AppendLine("								INNER JOIN Ruta RUT ON RUT.RUTClave = VIS.RUTClave ")
        sConsulta.AppendLine("								INNER JOIN Almacen ALN ON ALN.Clave = AGV.ClaveCEDI ")
        sConsulta.AppendLine("								INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorId ")
        sConsulta.AppendLine("								LEFT JOIN TransProd TRP ON TRP.VisitaClave = VIS.VisitaClave AND TRP.DiaClave = VIS.DiaClave AND TRP.Tipo = 1 AND TRP.TipoFase <>0 ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine("								AND TRP.TransProdID IS NULL ")
        sConsulta.AppendLine("								GROUP BY AGV.RutClave, AGV.VendedorId,  AGV.DiaClave ,Aln.Clave,ALn.Nombre")
        sConsulta.AppendLine("		) AS T ")
        sConsulta.AppendLine("inner join vendedor v on T.VendedorId=v.VendedorId")
        sConsulta.AppendLine("inner join ruta r on T.rutclave = r.rutclave")
        sConsulta.AppendLine("		GROUP BY t.RutClave, T.VendedorId ,V.Nombre,r.Descripcion ,t.cedi")
        sConsulta.AppendLine("")



        sConsulta.AppendLine("set nocount off ")
        Session("Query2") = sConsulta.ToString

        '--Query 3
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("SELECT VEN.Nombre AS Vendedor, RES.SINVENTA AS SinVenta ,RES.NOVISITADOS + RES.VISITADOS AS TotalClientes, ")
        sConsulta.AppendLine("RES.NOVISITADOS  ,RES.VISITADOS, ")
        sConsulta.AppendLine("CASE WHEN CAST((RES.NOVISITADOS + RES.VISITADOS) AS FLOAT) = 0 THEN 0 ELSE (CAST(RES.VISITADOS AS FLOAT) /CAST((RES.NOVISITADOS + RES.VISITADOS) AS FLOAT))*100 END AS VISITAEfectiva, ")
        sConsulta.AppendLine("CASE WHEN RES.VISITADOS = 0 THEN 0 ELSE CAST((RES.VISITADOS - RES.SINVENTA) AS FLOAT)/CAST(RES.VISITADOS AS FLOAT)*100 END  AS EfectividadCompra, ")
        sConsulta.AppendLine("RUT.RUTClave + ' '+ RUT.Descripcion AS Ruta, ALN.Clave + ' ' + ALN.Nombre as CEDI ")
        sConsulta.AppendLine("FROM ( ")
        sConsulta.AppendLine("SELECT RutClave, VendedorId,  DiaClave, SUM (VISITADOS) AS VISITADOS, SUM(NOVISITADOS) as NOVISITADOS, SUM(SINVENTA) as SINVENTA ")
        sConsulta.AppendLine("FROM ( ")
        sConsulta.AppendLine("SELECT VIS.RutClave, VIS.VendedorId,  VIS.DiaClave, ")
        sConsulta.AppendLine("COUNT(DISTINCT VIS.ClienteClave) as VISITADOS, 0 as NOVISITADOS, 0 as SINVENTA ")
        sConsulta.AppendLine("from Visita VIS  ")
        sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId  ")
        sConsulta.AppendLine("inner join Dia on DIA.DiaClave=VIS.DiaClave AND convert(varchar(20), DIA.FechaCaptura, 101)=convert(varchar(20), VIS.FechaHoraInicial, 101)  ")
        sConsulta.AppendLine("LEFT JOIN AgendaVendedor AGV ON AGV.DiaClave = VIS.DiaClave AND AGV.ClienteClave = VIS.ClienteClave AND AGV.RUTClave = VIS.RUTClave AND AGV.VendedorId = VIS.VendedorID  ")
        sConsulta.AppendLine("INNER JOIN Ruta RUT ON RUT.RUTClave = VIS.RUTClave  ")
        sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCH ON VCH.VendedorId = VEN.VendedorID AND Dia.FechaCaptura BETWEEN VCH.VCHFechaInicial AND VCH.FechaFinal ")
        sConsulta.AppendLine("left join Almacen ALN on VCH.AlmacenId = ALN.AlmacenID ")
        sConsulta.AppendLine(pvCondicion & " ")
        sConsulta.AppendLine("AND AGV.ClienteClave IS NULL ")
        sConsulta.AppendLine("GROUP BY VIS.RutClave, VIS.VendedorId,  VIS.DiaClave ")
        sConsulta.AppendLine("Union  ")
        sConsulta.AppendLine("SELECT VIS.RutClave, VIS.VendedorId,  VIS.DiaClave, ")
        sConsulta.AppendLine("0 AS VISITADOS, 0 AS NOVISITADOS, COUNT (DISTINCT VIS.ClienteClave)as SINVENTA ")
        sConsulta.AppendLine("FROM Visita VIS  ")
        sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId  ")
        sConsulta.AppendLine("inner join Dia on DIA.DiaClave=VIS.DiaClave AND convert(varchar(20), DIA.FechaCaptura, 101)=convert(varchar(20), VIS.FechaHoraInicial, 101)  ")
        sConsulta.AppendLine("LEFT JOIN AgendaVendedor AGV ON AGV.DiaClave = VIS.DiaClave AND AGV.ClienteClave = VIS.ClienteClave AND AGV.RUTClave = VIS.RUTClave AND AGV.VendedorId = VIS.VendedorID  ")
        sConsulta.AppendLine("LEFT JOIN TransProd TRP ON TRP.VisitaClave = VIS.VisitaClave AND TRP.DiaClave = VIS.DiaClave AND TRP.Tipo = 1 AND TRP.TipoFase <>0 ")
        sConsulta.AppendLine("INNER JOIN Ruta RUT ON RUT.RUTClave = VIS.RUTClave ")
        sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCH ON VCH.VendedorId = VEN.VendedorID AND Dia.FechaCaptura BETWEEN VCH.VCHFechaInicial AND VCH.FechaFinal ")
        sConsulta.AppendLine("left join Almacen ALN on VCH.AlmacenId = ALN.AlmacenID ")
        sConsulta.AppendLine(pvCondicion & " ")
        sConsulta.AppendLine("AND AGV.ClienteClave IS NULL AND TRP.TransProdID IS NULL  ")
        sConsulta.AppendLine("GROUP BY VIS.RutClave, VIS.VendedorId,  VIS.DiaClave ")
        sConsulta.AppendLine(") AS T ")
        sConsulta.AppendLine("GROUP BY RutClave, VendedorId,  DiaClave ")
        sConsulta.AppendLine(") AS RES ")
        sConsulta.AppendLine("INNER JOIN Vendedor VEN ON VEN.VendedorID = RES.VendedorID  ")
        sConsulta.AppendLine("INNER JOIN (SELECT DISTINCT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor) AGV on RES.VendedorId = AGV.VendedorId and RES.DiaClave = AGV.DiaClave ")
        sConsulta.AppendLine("INNER JOIN Ruta RUT ON RUT.RUTClave = RES.RUTClave  ")
        sConsulta.AppendLine("INNER JOIN Almacen ALN on AGV.ClaveCEDI  = ALN.Clave ")
        sConsulta.AppendLine("set nocount off ")
        Session("Query3") = sConsulta.ToString
        Return True


    End Function

    Private Function ConsultaTiemposEnRutaSuKarne(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvFecha As Boolean) As Boolean

        Dim sConsulta As New StringBuilder
        Dim sCondicionKm As String = ""

        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "RUT.RUTClave")
        pvCondicion = strWhereCentrosDistribucion(pvCondicion, "ALN.Clave")
        sCondicionKm = pvCondicion
        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "Dia.FechaCaptura")
            sCondicionKm = strWhereFecha(sCondicionKm, "CAV.FechaHoraInicial", True)
        End If

        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("if (select object_id('tempdb..#TmpTiempos')) is not null drop table #TmpTiempos ")
        sConsulta.AppendLine("select * into #TmpTiempos from( ")
        sConsulta.AppendLine("select case when VEN.JornadaTrabajo = 1 then isnull(VEJ.VEJFechaInicial,VIS.FechaHoraInicial) else VIS.FechaHoraInicial end as HoraInicialJornada, case when VEN.JornadaTrabajo = 1 then isnull(VEJ.FechaFinal,VIS.FechaHoraFinal) else VIS.FechaHoraFinal end as HoraFinalJornada, VIS.VisitaClave, VIS.DiaClave, VIS.ClienteClave, VIS.VendedorId, VIS.RutClave, VIS.FechaHoraInicial, VIS.FechaHoraFinal, VIS.CodigoLeido, ")
        sConsulta.AppendLine("CLI.Clave as CLIClave, CLI.RazonSocial +' - '+cli.nombrecontacto as CLIRazonSocial, RUT.Descripcion as RUTDescripcion,  AGV.Orden as SECOrden, VEN.Nombre as VENNombre, ")
        sConsulta.AppendLine("ALN.Clave as ALNClave, ALN.Nombre as ALNNombre, VEN.Kilometraje ")
        sConsulta.AppendLine("from Visita VIS ")
        sConsulta.AppendLine("INNER JOIN Dia  ON Dia.DiaClave = VIS.DiaClave ")
        sConsulta.AppendLine("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ")
        sConsulta.AppendLine("left join Ruta RUT on RUT.RUTClave = VIS.RUTClave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
        sConsulta.AppendLine("left join VendedorJornada VEJ on VEN.VendedorId = VEJ.VendedorId and VIS.DiaClave = VEJ.DiaClave AND VEJ.DiaClave is not null  ")
        sConsulta.AppendLine("left join AgendaVendedor AGV on VIS.VendedorId = AGV.VendedorId and VIS.DiaClave = AGV.DiaClave and  AGV.ClienteClave = VIS.ClienteClave ")
        sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCH ON VCH.VendedorId = VEN.VendedorID AND Dia.FechaCaptura BETWEEN VCH.VCHFechaInicial AND VCH.FechaFinal ")
        sConsulta.AppendLine("left join Almacen ALN on VCH.AlmacenId = ALN.AlmacenID  ")
        sConsulta.AppendLine(pvCondicion & " and RUT.RUTClave <>'RUT001' ")
        sConsulta.AppendLine(")as t1 ")
        sConsulta.AppendLine("select Kilometraje,HoraInicialJornada,HoraFinalJornada,VENNombre as Vendedor, convert(datetime,convert(varchar(20), FechaHoraInicial, 112)) as Fecha, RUTClave + ' ' + RUTDescripcion as Ruta, ")
        sConsulta.AppendLine("max(SECOrden) as Secuencia, CLIClave as Clave, CLIRazonSocial as NombreCliente, CodigoNoLeido=(select case when CodigoLeido=0 then '*' else '' end), ")
        sConsulta.AppendLine("ImpCodigoNoLeido=(select case when CodigoLeido=0 then 1 else 0 end), ")
        sConsulta.AppendLine("0 as MinutosTransito, FechaHoraInicial as HoraInicio, FechaHoraFinal as HoraFin, datediff(s, FechaHoraInicial, FechaHoraFinal) as MinutosVisita, ")
        sConsulta.AppendLine("(select top 1 case when count(*) > 0 then 'SI' else 'NO' end from TransProd TRP where TRP.Tipo = 1 and TRP.TipoFase <> 0 and TRP.VisitaClave = TMP.VisitaClave and TRP.ClienteClave = TMP.ClienteClave) as Venta, ")
        sConsulta.AppendLine("(select top 1 case when count(*) > 0 then 'SI' else 'NO' end from TransProd TRP where TRP.Tipo = 1 and TRP.TipoFase <> 0 and TRP.VisitaClave1 = TMP.VisitaClave and TRP.ClienteClave = TMP.ClienteClave) as Surtido, ")
        sConsulta.AppendLine("convert(varchar(25), isnull((select VAD.Descripcion from ImproductividadVenta IMV inner join VAVDescripcion VAD on IMV.TipoMotivo = VAD.VAVClave and VAD.VARCodigo = 'MOTIMPRO' and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' where IMV.VisitaClave = TMP.VisitaClave AND IMV.DIACLAVE=TMP.DIACLAVE), 0)) as Concepto, ")
        sConsulta.AppendLine("(select sum(TRP.Total*TRP.TipoCambio) from TransProd TRP where TRP.Tipo = 1 and TRP.TipoFase <> 0 and TRP.VisitaClave = TMP.VisitaClave and TRP.ClienteClave = TMP.ClienteClave) as TotalVenta, ")
        sConsulta.AppendLine("ALNClave + ' ' + ALNNombre as CEDI ")
        sConsulta.AppendLine("from #TmpTiempos TMP ")
        sConsulta.AppendLine("group by HoraInicialJornada,HoraFinalJornada,ALNClave, ALNNombre, VisitaClave, VENNombre, FechaHoraInicial, RUTClave, ClienteClave, CodigoLeido, ")
        sConsulta.AppendLine("CLIRazonSocial, FechaHoraInicial, FechaHoraFinal, ClienteClave, CLIClave, RUTClave, RUTDescripcion,TMP.DIACLAVE, Kilometraje ")
        sConsulta.AppendLine("order by ALNClave, VENNombre, RUTClave, FechaHoraInicial ")
        sConsulta.AppendLine("drop table #TmpTiempos ")
        sConsulta.AppendLine("set nocount off ")
        'Session("Query") = sConsulta.ToString

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("select ALN.Clave + ' ' + ALN.Nombre as CEDI, VEN.Nombre as Vendedor, RUT.RUTClave + ' ' + RUT.Descripcion as Ruta, ")
        sConsulta.AppendLine("convert(datetime, convert(varchar(20), FechaHoraInicial, 112)) as Fecha, CAV.KmInicial, CAV.KmFinal, CAV.Placa ")
        sConsulta.AppendLine("from CamionVendedor CAV ")
        sConsulta.AppendLine("inner join Vendedor VEN on CAV.VendedorId = VEN.VendedorId ")
        sConsulta.AppendLine("inner join (select distinct VendedorId, RUTClave, ClaveCEDI from AgendaVendedor) AGV on CAV.VendedorId = AGV.VendedorId ")
        sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
        sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave ")
        sConsulta.AppendLine(sCondicionKm & " and RUT.RUTClave <>'RUT001' ")
        sConsulta.AppendLine("set nocount off ")
        Session("Kilometraje") = sConsulta.ToString

        '--Query 2
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SELECT V.Nombre as Vendedor, SUM(SINVENTA) as SINVENTA ,SUM (VISITADOS)+SUM(NOVISITADOS) as TotalCLientes ,SUM (VISITADOS) AS VISITADOS, SUM(NOVISITADOS) as NOVISITADOS, ")
        sConsulta.AppendLine("CASE WHEN CAST((sum(T.NOVISITADOS+ T.VISITADOS)) AS FLOAT) = 0 THEN 0 ELSE (CAST(sum(T.VISITADOS) AS FLOAT) /CAST((sum(T.NOVISITADOS + T.VISITADOS)) AS FLOAT))*100 END AS VISITAEfectiva ,")
        sConsulta.AppendLine("CASE WHEN sum(t.VISITADOS) = 0 THEN 0 ELSE CAST((sum(t.VISITADOS - t.SINVENTA)) AS FLOAT)/CAST(sum(t.VISITADOS) AS FLOAT)*100 END  AS EfectividadCompra ,")
        sConsulta.AppendLine(" t.RutClave+' '+r.Descripcion as Ruta,Cedi")
        sConsulta.AppendLine("		FROM ( ")
        sConsulta.AppendLine("								select VIS.RutClave, VIS.VendedorId,  VIS.DiaClave, Aln.Clave+' '+ALn.Nombre as Cedi,")
        sConsulta.AppendLine("								COUNT(DISTINCT AGV.ClienteClave) as VISITADOS, 0 as NOVISITADOS, 0 as SINVENTA ")
        sConsulta.AppendLine("								from Visita VIS  ")
        sConsulta.AppendLine("								inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId  ")
        sConsulta.AppendLine("								inner join Dia on DIA.DiaClave=VIS.DiaClave AND convert(varchar(20), DIA.FechaCaptura, 101)=convert(varchar(20), VIS.FechaHoraInicial, 101)  ")
        sConsulta.AppendLine("								INNER JOIN AgendaVendedor AGV ON AGV.DiaClave = VIS.DiaClave AND AGV.ClienteClave = VIS.ClienteClave AND AGV.RUTClave = VIS.RUTClave AND AGV.VendedorId = VIS.VendedorID  ")
        sConsulta.AppendLine("								INNER JOIN Ruta RUT ON RUT.RUTClave = AGV.RUTClave  ")
        sConsulta.AppendLine("								INNER JOIN Almacen ALN ON ALN.Clave = AGV.ClaveCEDI  ")
        sConsulta.AppendLine(pvCondicion & " and RUT.RUTClave <>'RUT001' ")
        sConsulta.AppendLine("								GROUP BY VIS.RutClave, VIS.VendedorId,  VIS.DiaClave ,Aln.Clave,ALn.Nombre")
        sConsulta.AppendLine("								Union ")
        sConsulta.AppendLine("								SELECT AGV.RutClave, AGV.VendedorId,  AGV.DiaClave, Aln.Clave+' '+ALn.Nombre as Cedi,")
        sConsulta.AppendLine("								0 as VISITADOS, COUNT(DISTINCT AGV.ClienteClave) as NOVISITADOS, 0 AS SINVENTA ")
        sConsulta.AppendLine("								FROM AgendaVendedor AGV ")
        sConsulta.AppendLine("								INNER JOIN Dia ON Dia.DiaClave = AGV.DiaClave ")
        sConsulta.AppendLine("								LEFT JOIN Visita VIS ON VIS.RUTClave = AGV.RUTClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorID = AGV.VendedorId AND VIS.ClienteClave = AGV.ClienteClave ")
        sConsulta.AppendLine("								INNER JOIN Ruta RUT ON RUT.RUTClave = AGV.RUTClave ")
        sConsulta.AppendLine("								INNER JOIN Almacen ALN ON ALN.Clave = AGV.ClaveCEDI ")
        sConsulta.AppendLine("								INNER JOIN Vendedor VEN ON VEN.VendedorID = AGV.VendedorId ")
        sConsulta.AppendLine(pvCondicion & " and RUT.RUTClave <>'RUT001' ")
        sConsulta.AppendLine("								AND VIS.ClienteClave IS NULL ")
        sConsulta.AppendLine("								GROUP BY AGV.RutClave, AGV.VendedorId,  AGV.DiaClave ,Aln.Clave,ALn.Nombre")
        sConsulta.AppendLine("								UNION ")
        sConsulta.AppendLine("								SELECT AGV.RutClave, AGV.VendedorId,  AGV.DiaClave, Aln.Clave+' '+ALn.Nombre as Cedi,")
        sConsulta.AppendLine("								0 AS VISITADOS, 0 AS NOVISITADOS, COUNT (DISTINCT AGV.ClienteClave)as SINVENTA ")
        sConsulta.AppendLine("								FROM AgendaVendedor AGV ")
        sConsulta.AppendLine("								INNER JOIN Dia ON Dia.DiaClave = AGV.DiaClave ")
        sConsulta.AppendLine("								INNER JOIN Visita VIS ON VIS.RUTClave = AGV.RUTClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorID = AGV.VendedorId AND VIS.ClienteClave = AGV.ClienteClave ")
        sConsulta.AppendLine("								INNER JOIN Ruta RUT ON RUT.RUTClave = VIS.RUTClave ")
        sConsulta.AppendLine("								INNER JOIN Almacen ALN ON ALN.Clave = AGV.ClaveCEDI ")
        sConsulta.AppendLine("								INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorId ")
        sConsulta.AppendLine("								LEFT JOIN TransProd TRP ON TRP.VisitaClave = VIS.VisitaClave AND TRP.DiaClave = VIS.DiaClave AND TRP.Tipo = 1 AND TRP.TipoFase <>0 ")
        sConsulta.AppendLine(pvCondicion & " and RUT.RUTClave <>'RUT001' ")
        sConsulta.AppendLine("								AND TRP.TransProdID IS NULL ")
        sConsulta.AppendLine("								GROUP BY AGV.RutClave, AGV.VendedorId,  AGV.DiaClave ,Aln.Clave,ALn.Nombre")
        sConsulta.AppendLine("		) AS T ")
        sConsulta.AppendLine("inner join vendedor v on T.VendedorId=v.VendedorId")
        sConsulta.AppendLine("inner join ruta r on T.rutclave = r.rutclave")
        sConsulta.AppendLine("		GROUP BY t.RutClave, T.VendedorId ,V.Nombre,r.Descripcion ,t.cedi")
        sConsulta.AppendLine("")



        sConsulta.AppendLine("set nocount off ")
        Session("Query2") = sConsulta.ToString

        '--Query 3
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("SELECT VEN.Nombre AS Vendedor, RES.SINVENTA AS SinVenta ,RES.NOVISITADOS + RES.VISITADOS AS TotalClientes, ")
        sConsulta.AppendLine("RES.NOVISITADOS  ,RES.VISITADOS, ")
        sConsulta.AppendLine("CASE WHEN CAST((RES.NOVISITADOS + RES.VISITADOS) AS FLOAT) = 0 THEN 0 ELSE (CAST(RES.VISITADOS AS FLOAT) /CAST((RES.NOVISITADOS + RES.VISITADOS) AS FLOAT))*100 END AS VISITAEfectiva, ")
        sConsulta.AppendLine("CASE WHEN RES.VISITADOS = 0 THEN 0 ELSE CAST((RES.VISITADOS - RES.SINVENTA) AS FLOAT)/CAST(RES.VISITADOS AS FLOAT)*100 END  AS EfectividadCompra, ")
        sConsulta.AppendLine("RUT.RUTClave + ' '+ RUT.Descripcion AS Ruta, ALN.Clave + ' ' + ALN.Nombre as CEDI ")
        sConsulta.AppendLine("FROM ( ")
        sConsulta.AppendLine("SELECT RutClave, VendedorId,  DiaClave, SUM (VISITADOS) AS VISITADOS, SUM(NOVISITADOS) as NOVISITADOS, SUM(SINVENTA) as SINVENTA ")
        sConsulta.AppendLine("FROM ( ")
        sConsulta.AppendLine("SELECT VIS.RutClave, VIS.VendedorId,  VIS.DiaClave, ")
        sConsulta.AppendLine("COUNT(DISTINCT VIS.ClienteClave) as VISITADOS, 0 as NOVISITADOS, 0 as SINVENTA ")
        sConsulta.AppendLine("from Visita VIS  ")
        sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId  ")
        sConsulta.AppendLine("inner join Dia on DIA.DiaClave=VIS.DiaClave AND convert(varchar(20), DIA.FechaCaptura, 101)=convert(varchar(20), VIS.FechaHoraInicial, 101)  ")
        sConsulta.AppendLine("LEFT JOIN AgendaVendedor AGV ON AGV.DiaClave = VIS.DiaClave AND AGV.ClienteClave = VIS.ClienteClave AND AGV.RUTClave = VIS.RUTClave AND AGV.VendedorId = VIS.VendedorID  ")
        sConsulta.AppendLine("INNER JOIN Ruta RUT ON RUT.RUTClave = VIS.RUTClave  ")
        sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCH ON VCH.VendedorId = VEN.VendedorID AND Dia.FechaCaptura BETWEEN VCH.VCHFechaInicial AND VCH.FechaFinal ")
        sConsulta.AppendLine("left join Almacen ALN on VCH.AlmacenId = ALN.AlmacenID ")
        sConsulta.AppendLine(pvCondicion & " and RUT.RUTClave <>'RUT001' ")
        sConsulta.AppendLine("AND AGV.ClienteClave IS NULL ")
        sConsulta.AppendLine("GROUP BY VIS.RutClave, VIS.VendedorId,  VIS.DiaClave ")
        sConsulta.AppendLine("Union  ")
        sConsulta.AppendLine("SELECT VIS.RutClave, VIS.VendedorId,  VIS.DiaClave, ")
        sConsulta.AppendLine("0 AS VISITADOS, 0 AS NOVISITADOS, COUNT (DISTINCT VIS.ClienteClave)as SINVENTA ")
        sConsulta.AppendLine("FROM Visita VIS  ")
        sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId  ")
        sConsulta.AppendLine("inner join Dia on DIA.DiaClave=VIS.DiaClave AND convert(varchar(20), DIA.FechaCaptura, 101)=convert(varchar(20), VIS.FechaHoraInicial, 101)  ")
        sConsulta.AppendLine("LEFT JOIN AgendaVendedor AGV ON AGV.DiaClave = VIS.DiaClave AND AGV.ClienteClave = VIS.ClienteClave AND AGV.RUTClave = VIS.RUTClave AND AGV.VendedorId = VIS.VendedorID  ")
        sConsulta.AppendLine("LEFT JOIN TransProd TRP ON TRP.VisitaClave = VIS.VisitaClave AND TRP.DiaClave = VIS.DiaClave AND TRP.Tipo = 1 AND TRP.TipoFase <>0 ")
        sConsulta.AppendLine("INNER JOIN Ruta RUT ON RUT.RUTClave = VIS.RUTClave ")
        sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCH ON VCH.VendedorId = VEN.VendedorID AND Dia.FechaCaptura BETWEEN VCH.VCHFechaInicial AND VCH.FechaFinal ")
        sConsulta.AppendLine("left join Almacen ALN on VCH.AlmacenId = ALN.AlmacenID ")
        sConsulta.AppendLine(pvCondicion & " and RUT.RUTClave <>'RUT001' ")
        sConsulta.AppendLine("AND AGV.ClienteClave IS NULL AND TRP.TransProdID IS NULL  ")
        sConsulta.AppendLine("GROUP BY VIS.RutClave, VIS.VendedorId,  VIS.DiaClave ")
        sConsulta.AppendLine(") AS T ")
        sConsulta.AppendLine("GROUP BY RutClave, VendedorId,  DiaClave ")
        sConsulta.AppendLine(") AS RES ")
        sConsulta.AppendLine("INNER JOIN Vendedor VEN ON VEN.VendedorID = RES.VendedorID  ")
        sConsulta.AppendLine("INNER JOIN (SELECT DISTINCT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor) AGV on RES.VendedorId = AGV.VendedorId and RES.DiaClave = AGV.DiaClave ")
        sConsulta.AppendLine("INNER JOIN Ruta RUT ON RUT.RUTClave = RES.RUTClave  ")
        sConsulta.AppendLine("INNER JOIN Almacen ALN on AGV.ClaveCEDI  = ALN.Clave ")
        sConsulta.AppendLine("set nocount off ")
        Session("Query3") = sConsulta.ToString
        Return True


    End Function

    Private Function ConsultaFacturacionElectronica(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "VIS.FechaHoraInicial")
        End If
        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "RUT.RUTClave")
        pvCondicion = strWhereCentrosDistribucion(pvCondicion, "ALN.Clave")

        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine(" select aln.nombre as cedi,ven.nombre as vendedor,fac.fechahoraalta as fecha,dat.serie,substring(fac.folio,len(serie)+1,len(fac.folio)) as folio,cli.clave + ' ' +dat.razonsocial as cliente,  ")
        sConsulta.AppendLine(" dat.rfc,dat.numcertificado,dat.AnioAprobacion,dat.Aprobacion,fac.total, ")
        sConsulta.AppendLine(String.Format("(SELECT Descripcion FROM VAVDescripcion VAD WHERE VAD.VAVClave = fac.TipoFase AND VAD.VADTipoLenguaje = '{0}' AND VAD.VARCodigo = 'TRPFASE') AS fase,", Session("lenguaje")))
        sConsulta.AppendLine(String.Format("(SELECT Descripcion FROM VAVDescripcion VAD WHERE VAD.VAVClave = fac.TipoMotivo AND VAD.VADTipoLenguaje = '{0}' AND VAD.VARCodigo = 'TRPMOT') AS Motivo,", Session("lenguaje")))
        sConsulta.AppendLine(String.Format("(CASE WHEN fac.TipoMotivo = 11 OR fac.TipoMotivo = 10  THEN (SELECT Descripcion FROM MENDetalle WHERE MenClave = 'XERROR' AND MEDTipoLenguaje = '{0}') ELSE '' END) AS error", Session("lenguaje")))
        sConsulta.AppendLine(" from transprod fac  ")
        sConsulta.AppendLine(" inner join trpdatofiscal dat on fac.transprodid=dat.transprodid ")
        sConsulta.AppendLine(" inner join visita vis on vis.diaclave=fac.diaclave and fac.visitaclave=VIS.VISITACLAVE ")
        sConsulta.AppendLine(" inner join vendedor ven on ven.vendedorid=vis.vendedorid ")
        sConsulta.AppendLine(" inner join  (select distinct DiaClave, VendedorId, ClaveCEDI from AgendaVendedor) age on VIS.VendedorId = AGe.VendedorId and VIS.DiaClave = AGe.DiaClave ")
        sConsulta.AppendLine(" inner join almacen aln on aln.clave = age.clavecedi ")
        sConsulta.AppendLine(" inner join transprod trp on fac.transprodid=trp.facturaid ")
        sConsulta.AppendLine(" inner join cliente cli on cli.clienteclave=trp.clienteclave ")
        sConsulta.AppendLine(pvCondicion + " and fac.tipo=8 and fac.tipofase<>0 ")
        sConsulta.AppendLine(" order by fac.FechaHoraAlta, Serie, fac.Folio ")
        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)

        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt
        Return True
    End Function

    Private Function ConsultaTiemposEnRutaMayoreo(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "VIS.FechaHoraInicial")
        End If
        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "RUT.RUTClave")
        pvCondicion = strWhereCentrosDistribucion(pvCondicion, "ALN.Clave")

        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("if (select object_id('tempdb..#TmpTiempos')) is not null drop table #TmpTiempos ")
        sConsulta.AppendLine("select * into #TmpTiempos from( ")
        sConsulta.AppendLine("select case when VEN.JornadaTrabajo = 1 then isnull(VEJ.VEJFechaInicial,VIS.FechaHoraInicial) else VIS.FechaHoraInicial end as HoraInicialJornada, case when VEN.JornadaTrabajo = 1 then isnull(VEJ.FechaFinal,VIS.FechaHoraFinal) else VIS.FechaHoraFinal end as HoraFinalJornada, VIS.VisitaClave, VIS.DiaClave, VIS.ClienteClave, VIS.VendedorId, VIS.RutClave, VIS.FechaHoraInicial, VIS.FechaHoraFinal, VIS.CodigoLeido, ")
        sConsulta.AppendLine("CLI.Clave as CLIClave, CLI.RazonSocial +' - '+cli.nombrecontacto as CLIRazonSocial, SEC.Orden as SECOrden, VEN.Nombre as VENNombre, ")
        sConsulta.AppendLine("ALN.Clave as ALNClave, ALN.Nombre as ALNNombre ")
        sConsulta.AppendLine("from Visita VIS ")
        sConsulta.AppendLine("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ")
        'sConsulta.AppendLine("left join Ruta RUT on RUT.RUTClave = VIS.RUTClave ")
        sConsulta.AppendLine("left join Secuencia SEC on SEC.RUTClave = VIS.RUTClave and SEC.ClienteClave = CLI.ClienteClave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
        sConsulta.AppendLine("left join VendedorJornada VEJ on VEN.VendedorId = VEJ.VendedorId and VIS.DiaClave = VEJ.DiaClave AND VEJ.DiaClave is not null  ")
        sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI from AgendaVendedor) AGV on VIS.VendedorId = AGV.VendedorId and VIS.DiaClave = AGV.DiaClave ")
        sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
        sConsulta.AppendLine(pvCondicion & " ")
        sConsulta.AppendLine(")as t1 ")
        sConsulta.AppendLine("select HoraInicialJornada,HoraFinalJornada,VENNombre as Vendedor, convert(datetime, convert(varchar(20), FechaHoraInicial, 112)) as Fecha, RUTClave as Ruta, ")
        sConsulta.AppendLine("max(SECOrden) as Secuencia, CLIClave as Clave, CLIRazonSocial as NombreCliente, CodigoNoLeido=(select case when CodigoLeido=0 then '*' else '' end), ")
        sConsulta.AppendLine("ImpCodigoNoLeido=(select case when CodigoLeido=0 then 1 else 0 end), ")
        sConsulta.AppendLine("0 as MinutosTransito, FechaHoraInicial as HoraInicio, FechaHoraFinal as HoraFin, datediff(s, FechaHoraInicial, FechaHoraFinal) as MinutosVisita, ")
        sConsulta.AppendLine("(select top 1 case when count(*) > 0 then 'SI' else 'NO' end from TransProd TRP where TRP.Tipo = 21 and TRP.TipoFase <> 0 and TRP.VisitaClave = TMP.VisitaClave and TRP.ClienteClave = TMP.ClienteClave) as Venta, ")
        sConsulta.AppendLine("convert(varchar(25), isnull((select VAD.Descripcion from ImproductividadVenta IMV inner join VAVDescripcion VAD on IMV.TipoMotivo = VAD.VAVClave and VAD.VARCodigo = 'MOTIMPRO' and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' where IMV.VisitaClave = TMP.VisitaClave AND IMV.DIACLAVE=TMP.DIACLAVE), 0)) as Concepto, ")
        sConsulta.AppendLine("(select sum(TRP.Total) from TransProd TRP where TRP.Tipo = 21 and TRP.TipoFase <> 0 and TRP.VisitaClave = TMP.VisitaClave and TRP.ClienteClave = TMP.ClienteClave) as TotalVenta, ")
        sConsulta.AppendLine("ALNClave + ' ' + ALNNombre as CEDI ")
        sConsulta.AppendLine("from #TmpTiempos TMP ")
        sConsulta.AppendLine("group by HoraInicialJornada,HoraFinalJornada,ALNClave, ALNNombre, VisitaClave, VENNombre, FechaHoraInicial, RUTClave, ClienteClave, CodigoLeido, ")
        sConsulta.AppendLine("CLIRazonSocial, FechaHoraInicial, FechaHoraFinal, ClienteClave, CLIClave, RUTClave, TMP.DIACLAVE ")
        sConsulta.AppendLine("order by ALNClave, VENNombre, RUTClave, FechaHoraInicial ")
        sConsulta.AppendLine("drop table #TmpTiempos ")
        sConsulta.AppendLine("set nocount off ")
        'Session("Query") = sConsulta.ToString

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        '--Query 2
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("if (select object_id('tempdb..#TmpTiempos')) is not null drop table #TmpTiempos ")
        sConsulta.AppendLine("select * into #TmpTiempos from( ")
        sConsulta.AppendLine("select convert(varchar(20), FechaHoraInicial, 112) as Fecha, VIS.VisitaClave, VIS.DiaClave, VIS.ClienteClave as VISClienteClave, VIS.VendedorId, VIS.RutClave, ")
        sConsulta.AppendLine("TRP.ClienteClave as TRPClienteClave, VEN.Nombre as VENNombre, ALN.Clave as ALNClave, ALN.Nombre as ALNNombre ")
        sConsulta.AppendLine("from Visita VIS ")
        sConsulta.AppendLine("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ")
        sConsulta.AppendLine("left join TransProd TRP on TRP.Tipo = 21 and TRP.TipoFase <> 0 and TRP.VisitaClave = VIS.VisitaClave and TRP.ClienteClave = CLI.ClienteClave ")
        sConsulta.AppendLine("left join Secuencia SEC on SEC.RUTClave = VIS.RUTClave and SEC.ClienteClave = CLI.ClienteClave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
        sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI from AgendaVendedor) AGV on VIS.VendedorId = AGV.VendedorId and VIS.DiaClave = AGV.DiaClave ")
        sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
        sConsulta.AppendLine("inner join Dia on DIA.DiaClave=VIS.DiaClave AND convert(varchar(20), DIA.FechaCaptura, 101)=convert(varchar(20), VIS.FechaHoraInicial, 101) ")
        sConsulta.AppendLine(pvCondicion & " ")
        sConsulta.AppendLine(")as t1 ")
        sConsulta.AppendLine("if (select object_id('tempdb..#TmpTiempos2')) is not null drop table #TmpTiempos2 ")
        sConsulta.AppendLine("select * into #TmpTiempos2 from( ")
        sConsulta.AppendLine("select distinct TMP.Fecha, TMP.VisitaClave, TMP.DiaClave, TMP.VISClienteClave, TMP.VendedorId, TMP.RutClave, TMP.TRPClienteClave, ")
        sConsulta.AppendLine("TMP.VENNombre, TMP.ALNClave, TMP.ALNNombre, NoVIS.ClienteClave as NoVISClienteClave ")
        sConsulta.AppendLine("from #TmpTiempos TMP ")
        sConsulta.AppendLine("inner join agendavendedor NoVIS on TMP.VendedorId = NoVis.VendedorId and TMP.DiaClave = NoVis.DiaClave ")
        sConsulta.AppendLine(")as t2 ")
        sConsulta.AppendLine("Select VENNombre AS Vendedor, convert(datetime, Fecha) as Fecha, count(distinct VISClienteClave) - count(distinct TRPClienteClave) as SinVenta, ")
        sConsulta.AppendLine("count(distinct NoVISClienteClave) as TotalClientes, ")
        'sConsulta.AppendLine("(select count(distinct AGENDA.ClienteClave) from agendavendedor agenda ")
        'sConsulta.AppendLine("where  agenda.diaclave in (select diaclave from #TmpTiempos2) ")
        'sConsulta.AppendLine("and agenda.vendedorid=#TmpTiempos2.vendedorid and AGENDA.CLIENTECLAVE not in ( ")
        'sConsulta.AppendLine("select VISClienteClave from #TmpTiempos2 temp ")
        'sConsulta.AppendLine("where temp.VendedorId = agENDA.VendedorId and agENDA.rutclave=temp.rutclave) ")
        'sConsulta.AppendLine("AND AGENDA.CLIENTECLAVE NOT IN (select distinct vis.clienteclave from visita vis where VIS.VendedorId = agENDA.VendedorId ")
        'sConsulta.AppendLine(" " + strWhereFecha("", "VIS.FECHAHORAINICIAL") + " ")
        'sConsulta.AppendLine("and agENDA.rutclave=vis.rutclave )) as 'NOVISITADOS', 
        sConsulta.AppendLine("count(distinct NoVISClienteClave) - count(distinct VISClienteClave) as 'NOVISITADOS', ")
        sConsulta.AppendLine("count(distinct VISClienteClave) as 'VISITADOS', ")
        sConsulta.AppendLine("((count(distinct VISClienteClave) + .0) / count(distinct NoVISClienteClave)) * 100 as 'VISITAEfectiva', ")
        sConsulta.AppendLine("((count(distinct TRPClienteClave) + .0) / count(distinct VISClienteClave)) * 100 as 'EfectividadCompra', ")
        sConsulta.AppendLine("ALNClave + ' ' + ALNNombre as CEDI ")
        sConsulta.AppendLine("from #TmpTiempos2 ")
        sConsulta.AppendLine("group by ALNClave, ALNNombre, VENNombre, #TmpTiempos2.VendedorId, Fecha ")
        sConsulta.AppendLine("order by ALNClave, VENNombre, convert(datetime, Fecha) ")
        sConsulta.AppendLine("drop table #TmpTiempos ")
        sConsulta.AppendLine("drop table #TmpTiempos2 ")
        sConsulta.AppendLine("set nocount off ")
        Session("Query2") = sConsulta.ToString

        '--Query 3
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("if (select object_id('tempdb..#TmpTiempos')) is not null drop table #TmpTiempos ")
        sConsulta.AppendLine("select * into #TmpTiempos from( ")
        sConsulta.AppendLine("select convert(varchar(20), FechaHoraInicial, 112) as Fecha, VIS.VisitaClave, VIS.DiaClave, VIS.ClienteClave as VISClienteClave, VIS.VendedorId, VIS.RutClave, TRP.ClienteClave as TRPClienteClave, ")
        sConsulta.AppendLine("VEN.Nombre as VENNombre, ALN.Clave as ALNClave, ALN.Nombre as ALNNombre ")
        sConsulta.AppendLine("from Visita VIS ")
        sConsulta.AppendLine("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ")
        sConsulta.AppendLine("left join TransProd TRP on TRP.Tipo = 21 and TRP.TipoFase <> 0 and TRP.VisitaClave = VIS.VisitaClave and TRP.ClienteClave = CLI.ClienteClave ")
        sConsulta.AppendLine("left join Secuencia SEC on SEC.RUTClave = VIS.RUTClave and SEC.ClienteClave = CLI.ClienteClave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
        sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI from AgendaVendedor) AGV on VIS.VendedorId = AGV.VendedorId and VIS.DiaClave = AGV.DiaClave ")
        sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
        sConsulta.AppendLine("inner join Dia on DIA.DiaClave=VIS.DiaClave AND convert(varchar(20), DIA.FechaCaptura, 101)<>convert(varchar(20), VIS.FechaHoraInicial, 101) ")
        sConsulta.AppendLine(pvCondicion & " ")
        sConsulta.AppendLine(")as t1 ")
        'sConsulta.AppendLine("if (select object_id('tempdb..#TmpTiempos2')) is not null drop table #TmpTiempos2 ")
        'sConsulta.AppendLine("select * into #TmpTiempos2 from( ")
        'sConsulta.AppendLine("select distinct TMP.Fecha, TMP.VisitaClave, TMP.DiaClave, TMP.VISClienteClave, TMP.VendedorId, TMP.RutClave, TMP.TRPClienteClave, ")
        'sConsulta.AppendLine("TMP.VENNombre, TMP.ALNClave, TMP.ALNNombre, NoVIS.ClienteClave as NoVISClienteClave ")
        'sConsulta.AppendLine("from #TmpTiempos TMP ")
        'sConsulta.AppendLine("inner join agendavendedor NoVIS on TMP.VendedorId = NoVis.VendedorId and TMP.DiaClave = NoVis.DiaClave ")
        'sConsulta.AppendLine(")as t2 ")
        'sConsulta.AppendLine("Select VENNombre AS Vendedor, convert(datetime, Fecha) as Fecha, count(distinct VISClienteClave) - count(distinct TRPClienteClave) as SinVenta, ")
        'sConsulta.AppendLine("count(distinct NoVISClienteClave) as TotalClientes, (select count(distinct AGENDA.ClienteClave) ")
        'sConsulta.AppendLine("from agendavendedor agenda where  agenda.diaclave in (select diaclave from #TmpTiempos2) ")
        'sConsulta.AppendLine("and agenda.vendedorid=#TmpTiempos2.vendedorid and AGENDA.CLIENTECLAVE not in ( ")
        'sConsulta.AppendLine("select VISClienteClave from #TmpTiempos2 temp where temp.VendedorId = agENDA.VendedorId and agENDA.rutclave=temp.rutclave) ")
        'sConsulta.AppendLine("AND AGENDA.CLIENTECLAVE NOT IN (select distinct vis.clienteclave from visita vis where VIS.VendedorId = agENDA.VendedorId ")
        'sConsulta.AppendLine(" " + strWhereFecha("", "VIS.FECHAHORAINICIAL") + " ")
        'sConsulta.AppendLine("and agENDA.rutclave=vis.rutclave )) as 'NOVISITADOS', ")
        'sConsulta.AppendLine("count(distinct VISClienteClave) as 'VISITADOS', ")
        'sConsulta.AppendLine("((count(distinct VISClienteClave) + .0) / count(distinct NoVISClienteClave)) * 100 as 'VISITAEfectiva', ")
        'sConsulta.AppendLine("((count(distinct TRPClienteClave) + .0) / count(distinct VISClienteClave)) * 100 as 'EfectividadCompra', ")
        sConsulta.AppendLine("Select VENNombre AS Vendedor, convert(datetime, Fecha) as Fecha, ")
        sConsulta.AppendLine("count(distinct VISClienteClave) - count(distinct TRPClienteClave) as SinVenta, 0 as TotalClientes, ")
        sConsulta.AppendLine("0 as 'NOVISITADOS', count(distinct VISClienteClave) as 'VISITADOS', 0 as 'VISITAEfectiva', ")
        sConsulta.AppendLine("((count(distinct TRPClienteClave) + .0) / count(distinct VISClienteClave)) * 100 as 'EfectividadCompra', ")
        sConsulta.AppendLine("ALNClave + ' ' + ALNNombre as CEDI ")
        sConsulta.AppendLine("from #TmpTiempos ")
        sConsulta.AppendLine("group by ALNClave, ALNNombre, VENNombre, #TmpTiempos.VendedorId, Fecha ")
        sConsulta.AppendLine("order by ALNClave, VENNombre, convert(datetime, Fecha) ")
        sConsulta.AppendLine("drop table #TmpTiempos ")
        'sConsulta.AppendLine("drop table #TmpTiempos2 ")
        sConsulta.AppendLine("set nocount off ")
        Session("Query3") = sConsulta.ToString


        Return True
    End Function

    Private Function ConsultaDevolucionesCambiosCliente(ByVal ins As DBConexion.cConexionSQL, ByVal pvConversionKg As Boolean, ByVal pvCondicion As String, ByVal pvClientes As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "TRP.FechaHoraAlta")
        End If
        pvCondicion = strWhereCentrosDistribucion(pvCondicion, "ALN.Clave")
        pvCondicion = strWhereClientes(pvCondicion, pvClientes, "CLI.ClienteClave")

        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("select ALN.Clave + ' ' + ALN.Nombre as CEDI, TRP.FechaHoraAlta, CLI.Clave as ClienteClave, CLI.RazonSocial, TPD.ProductoClave, ")
        sConsulta.AppendLine("PRO.Nombre as ProductoNombre, VAD.Descripcion as Unidad, PRD.Factor,  PPV.Precio, ")
        sConsulta.AppendLine("case TRP.Tipo when 3 then TPD.Cantidad else 0 end 'CantidadDevuelta', ")
        If pvConversionKg Then
            sConsulta.AppendLine("case TRP.Tipo when 3 then TPD.Cantidad * PRU.KgLts else 0 end 'KgLtCantidadDevuelta', ")
        End If
        sConsulta.AppendLine("case TRP.Tipo when 3 then TPD.Cantidad * PPV.Precio else 0 end 'ImporteDevuelto', ")
        sConsulta.AppendLine("case TRP.Tipo when 9 then TPD.Cantidad else 0 end 'CantidadCambiada', ")
        If pvConversionKg Then
            sConsulta.AppendLine("case TRP.Tipo when 9 then TPD.Cantidad * PRU.KgLts else 0 end 'KgLtCantidadCambiada', ")
        End If
        sConsulta.AppendLine("case TRP.Tipo when 9 then TPD.Cantidad * PPV.Precio else 0 end 'ImporteCambiado', ")
        sConsulta.AppendLine("case TRP.Tipo when 3 then TPD.Cantidad * PRD.Factor else 0 end 'UnidadesDevueltas', ")
        sConsulta.AppendLine("case TRP.Tipo when 9 then TPD.Cantidad * PRD.Factor else 0 end 'UnidadesCambiadas' ")
        sConsulta.AppendLine("from TransProd TRP ")
        sConsulta.AppendLine("inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ")
        sConsulta.AppendLine("inner join Cliente CLI on CLI.ClienteClave = VIS.ClienteClave ")
        sConsulta.AppendLine("inner join TransProdDetalle TPD on TPD.TransProdID = TRP.TransProdID ")
        sConsulta.AppendLine("inner join Producto PRO on PRO.ProductoClave = TPD.ProductoClave ")
        sConsulta.AppendLine("inner join ProductoDetalle PRD on PRD.ProductoClave= PRO.ProductoClave and PRD.PRUTipoUnidad = TPD.TipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
        If pvConversionKg Then
            sConsulta.AppendLine("inner join ProductoUnidad PRU on PRU.ProductoClave = PRD.ProductoClave and PRU.PRUTipoUnidad = PRD.PRUTipoUnidad ")
        End If
        sConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VAVClave = TPD.TipoUnidad and VAD.VARCodigo = 'UNIDADV' and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' ")
        sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorID = VEN.VendedorID ")
        sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI from AgendaVendedor) AGV on TRP.DiaClave = AGV.DiaClave and VEN.VendedorId = AGV.VendedorId ")
        sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
        sConsulta.AppendLine("inner join PrecioProductoVig PPV on PPV.ProductoClave = TPD.ProductoClave and PPV.PRUTipoUnidad = TPD.TipoUnidad and TRP.FechaHoraAlta >= PPV.PPVFechaInicio and TRP.FechaHoraAlta <= PPV.FechaFin ")
        sConsulta.AppendLine("and PPV.PrecioClave = ( select TOP 1 PE.PrecioClave ")
        sConsulta.AppendLine("from precioclienteesquema PE ")
        sConsulta.AppendLine("where PE.Esquemaid in (select EsquemaId from clienteesquema where ClienteClave = CLI.ClienteClave) ")
        sConsulta.AppendLine("AND PE.ModuloMovDetalleClave in ( ")
        sConsulta.AppendLine("select ModuloMovDetalleClave from modulomovdetalle where tipoindice = 9 and tipotransprod = 1 and tipoestado = 1)) ")
        sConsulta.AppendLine(pvCondicion & " and (TRP.Tipo = 3 Or (TRP.Tipo = 9 And TRP.FacturaID Is Not null)) ")
        'Session("Query") = sConsulta.ToString

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt
        Return True
    End Function

    Private Function ConsultaVentasPorEsquema(ByVal ins As DBConexion.cConexionSQL, ByVal pvConversionKg As Boolean, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "TRP.FechaHoraalta")
        End If
        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "VIS.RUTClave")
        pvCondicion = strWhereCentrosDistribucion(pvCondicion, "ALN.Clave")

        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("declare @CobrarVentas as bit ")
        sConsulta.AppendLine("set @CobrarVentas = (select top 1 CobrarVentas from ConHist order by CONHistFechaInicio desc) ")
        sConsulta.AppendLine("declare @TiposFase table(Fase smallint) ")
        sConsulta.AppendLine("insert into @TiposFase values(1) ")
        sConsulta.AppendLine("insert into @TiposFase values(2) ")
        sConsulta.AppendLine("if @CobrarVentas = 1 ")
        sConsulta.AppendLine("begin insert into @TiposFase values(3) end ")
        sConsulta.AppendLine("if (select object_id('tempdb..#VentaEsquema')) is not null drop table #VentaEsquema ")
        sConsulta.AppendLine("select * into #VentaEsquema from ( ")
        sConsulta.AppendLine("select ALN.Clave as ALNClave, ALN.Clave + ' ' + ALN.Nombre as CEDI, VEN.Nombre as Vendedor, VIS.RUTClave, ")
        sConsulta.AppendLine("(select Descripcion from dbo.Ruta where (RUTClave = VIS.RUTClave)) as Ruta, ")
        sConsulta.AppendLine("convert(datetime, convert(varchar(20), TRP.FechaHoraAlta, 112)) as Fecha, TRP.TransProdID, TPD.ProductoClave, ")
        sConsulta.AppendLine("(select Nombre from dbo.Producto where (ProductoClave = TPD.ProductoClave)) as Producto, TPD.TipoUnidad, TPD.Cantidad as CantidadVenta, ")
        sConsulta.AppendLine("TPD.Subtotal as ImporteVenta, 0 as CantidadDevolucion, 0 as ImporteDevolucion, 0 as CantidadCambio, 0 as ImporteCambio ")
        sConsulta.AppendLine("from TransProd TRP ")
        sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ")
        sConsulta.AppendLine("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave ")
        sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI from AgendaVendedor) AGV on AGV.DiaClave = TRP.DiaClave and AGV.VendedorId = VIS.VendedorID ")
        sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorID ")
        sConsulta.AppendLine(pvCondicion & " ")
        sConsulta.AppendLine("and TRP.Tipo = 1 and TRP.TipoFase in (select Fase from @TiposFase) and tpd.promocion<>2 ")
        sConsulta.AppendLine("union all ")
        sConsulta.AppendLine("select ALN.Clave as ALNClave, ALN.Clave + ' ' + ALN.Nombre as CEDI, ")
        sConsulta.AppendLine("VEN.Nombre as Vendedor, VIS.RUTClave, ")
        sConsulta.AppendLine("(select Descripcion from dbo.Ruta  where (RUTClave = VIS.RUTClave)) as Ruta, ")
        sConsulta.AppendLine("convert(datetime, convert(varchar(20), TRP.FechaHoraAlta, 112)) as Expr1, TRP.TransProdID, TPD.ProductoClave, ")
        sConsulta.AppendLine("(select Nombre from dbo.Producto where (ProductoClave = TPD.ProductoClave)) as Producto, TPD.TipoUnidad, 0 as Expr2, 0 as Expr3, TPD.Cantidad, ")
        sConsulta.AppendLine("TPD.Cantidad * isnull ((select top 1 Precio from dbo.PrecioProductoVig where (TRP.FechaHoraAlta between PPVFechaInicio and FechaFin) and (ProductoClave = TPD.ProductoClave) and (PRUTipoUnidad= TPD.TipoUnidad) order by MFechaHora asc), 0) as Importe, ")
        sConsulta.AppendLine("0 as Expr4, 0 as Expr5 ")
        sConsulta.AppendLine("from TransProd TRP ")
        sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ")
        sConsulta.AppendLine("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave ")
        sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI from AgendaVendedor) AGV on AGV.DiaClave = TRP.DiaClave and AGV.VendedorId = VIS.VendedorID ")
        sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorID ")
        sConsulta.AppendLine(pvCondicion & " ")
        sConsulta.AppendLine("and TRP.Tipo = 3 and TRP.TipoFase = 1 and (TPD.PROMOCION<>2 OR TPD.PROMOCION IS NULL) ")
        sConsulta.AppendLine("union all ")
        sConsulta.AppendLine("select ALN.Clave as ALNClave, ALN.Clave + ' ' + ALN.Nombre as CEDI, VEN.Nombre as Vendedor, VIS.RUTClave, ")
        sConsulta.AppendLine("(select Descripcion from dbo.Ruta where (RUTClave = VIS.RUTClave)) as Ruta, ")
        sConsulta.AppendLine("convert(datetime, convert(varchar(20), TRP.FechaHoraAlta, 112)) as Expr1, TRP.TransProdID, TPD.ProductoClave, ")
        sConsulta.AppendLine("(select Nombre from dbo.Producto where (ProductoClave = TPD.ProductoClave)) as Producto, TPD.TipoUnidad, 0 as Expr2, 0 as Expr3, 0 as Expr4, 0 as Expr5, TPD.Cantidad, TPD.SubTotal as Importe ")
        sConsulta.AppendLine("from TransProd TRP ")
        sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ")
        sConsulta.AppendLine("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave ")
        sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI from AgendaVendedor) AGV on AGV.DiaClave = TRP.DiaClave and AGV.VendedorId = VIS.VendedorID ")
        sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorID ")
        sConsulta.AppendLine(pvCondicion & " ")
        sConsulta.AppendLine("and TRP.Tipo = 9 and TRP.TipoFase = 1 and TRP.TipoMovimiento = 1 and (TPD.PROMOCION<>2 OR TPD.PROMOCION IS NULL)")
        sConsulta.AppendLine(")as t1 ")

        If pvConversionKg Then
            sConsulta.AppendLine("select VRE.ALNClave, VRE.CEDI, PRO.ProductoClave as Clave, ESQ.Clave + '-' + ESQ.Nombre as Esquema, VRE.Fecha, VRE.Vendedor, ")
            sConsulta.AppendLine("VRE.RutClave as Ruta, isnull(VRE.Ruta, '') as RutaNombre, VRE.Producto, ")
            sConsulta.AppendLine("(select top 1 VAD.Descripcion from VAVDescripcion VAD where VAD.VARCodigo = 'UNIDADV' and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' and VAD.VAVClave = VRE.TipoUnidad) as Unidad, ")
            sConsulta.AppendLine("sum(VRE.CantidadVenta) as VentaCant, sum(VRE.CantidadVenta * PRD.Factor) as VentaCantUnit, isnull(sum(VRE.CantidadVenta * PRU.KgLts), 0) as VentaKg, ")
            sConsulta.AppendLine("sum(VRE.ImporteVenta) as VentaDinero, sum(VRE.CantidadDevolucion) as DevolucionCant, sum(VRE.CantidadDevolucion * PRD.Factor) as DevolucionCantUnit, ")
            sConsulta.AppendLine("isnull(sum(VRE.CantidadDevolucion * PRU.KgLts), 0) as DevolucionKg, sum(VRE.ImporteDevolucion) as DevolucionDinero, ")
            sConsulta.AppendLine("sum(VRE.CantidadCambio) as CambioCant, sum(VRE.CantidadCambio * PRD.Factor) as CambioCantUnit, ")
            sConsulta.AppendLine("isnull(sum(VRE.CantidadCambio * PRU.KgLts), 0) as CambioKg, sum(VRE.ImporteCambio) as CambioDinero ")
            sConsulta.AppendLine("from #VentaEsquema VRE ")
            sConsulta.AppendLine("inner join Producto PRO on VRE.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRO.ProductoClave = PRD.ProductoClave and VRE.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
            sConsulta.AppendLine("inner join ProductoEsquema PRS on PRS.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join Esquema ESQ on ESQ.EsquemaId = PRS.EsquemaId ")
            sConsulta.AppendLine("inner join ProductoUnidad PRU on PRU.ProductoClave = PRD.ProductoClave and PRU.PRUTipoUnidad = PRD.PRUTipoUnidad ")
            sConsulta.AppendLine("group by VRE.Fecha, VRE.Vendedor, VRE.RutClave, VRE.Ruta, VRE.Producto, VRE.TipoUnidad, ESQ.Clave + '-' + ESQ.Nombre, PRO.ProductoClave, VRE.CEDI, VRE.ALNClave ")
        Else
            sConsulta.AppendLine("select VRE.ALNClave, VRE.CEDI, PRO.ProductoClave as clave, ESQ.Clave + '-' + ESQ.Nombre as Esquema, VRE.Fecha, VRE.Vendedor, VRE.RutClave as Ruta, ")
            sConsulta.AppendLine("isnull(VRE.Ruta, '') as RutaNombre, VRE.Producto, ")
            sConsulta.AppendLine("(select top 1 VAD.Descripcion from VAVDescripcion VAD where VAD.VARCodigo = 'UNIDADV' and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' and VAD.VAVClave = VRE.TipoUnidad) as Unidad, ")
            sConsulta.AppendLine("sum(VRE.CantidadVenta) as VentaCant, sum(VRE.CantidadVenta * PRD.Factor) as VentaCantUnit, sum(VRE.ImporteVenta) as VentaDinero, ")
            sConsulta.AppendLine("sum(VRE.CantidadDevolucion) as DevolucionCant, sum(VRE.CantidadDevolucion * PRD.Factor) as DevolucionCantUnit, sum(VRE.ImporteDevolucion) as DevolucionDinero, ")
            sConsulta.AppendLine("sum(VRE.CantidadCambio) as CambioCant, sum(VRE.CantidadCambio * PRD.Factor) as CambioCantUnit, sum(VRE.ImporteCambio) as CambioDinero ")
            sConsulta.AppendLine("from #VentaEsquema VRE ")
            sConsulta.AppendLine("inner join Producto PRO on VRE.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRO.ProductoClave = PRD.ProductoClave and VRE.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
            sConsulta.AppendLine("inner join ProductoEsquema PRS on PRS.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join Esquema ESQ on ESQ.EsquemaId = PRS.EsquemaId ")
            sConsulta.AppendLine("group by VRE.Fecha, VRE.Vendedor, VRE.RutClave, VRE.Ruta, VRE.Producto, VRE.TipoUnidad, ESQ.Clave + '-' + ESQ.Nombre, PRO.ProductoClave, VRE.CEDI, VRE.ALNClave ")
        End If
        sConsulta.AppendLine("drop table #VentaEsquema ")
        sConsulta.AppendLine("set nocount off ")

        'Session("Query") = sConsulta.ToString
        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        Return True
    End Function

    Private Function ConsultaVentasTotalesPorRuta(ByVal ins As DBConexion.cConexionSQL, ByVal pvConversionKg As Boolean, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvFecha As Boolean) As Boolean

        Dim sConsulta As New StringBuilder
        Dim sCondicion As String = ""
        Dim sCondicionALN As String = ""
        If pvFecha Then
            sCondicion = strWhereFecha(pvCondicion, "VIS.FechaHoraInicial")
            'sCondicion = strWhereFecha(pvCondicion, "TRP.FechaCaptura")
            pvCondicion = strWhereFecha(pvCondicion, "TMP.FechaCaptura")
        End If
        sCondicion = strWhereRutas(sCondicion, pvRutas, "VIS.RUTClave")
        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "TMP.RUTClave")
        pvCondicion = strWhereCentrosDistribucion(pvCondicion, "ALN.Clave")
        If (ChBoxCentroDistribucion.Checked) Then
            sCondicionALN = "where ALN.Clave = '" + DdlCentroDistribucion.SelectedValue + "' "
        End If

        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("if (select object_id('tempdb..#VenTotRuta1')) is not null drop table #VenTotRuta1 ")
        sConsulta.AppendLine("select TRP.FechaCaptura, VIS.RutClave, VIS.ClienteClave, VIS.VendedorId, TRP.DiaClave, TPD.TransProdID, TPD.TransProdDetalleID, ")
        sConsulta.AppendLine("TPD.ProductoClave, TPD.TipoUnidad, TPD.Precio, TPD.Cantidad, TPD.Promocion,(TPD.Precio * TPD.Cantidad) as Subtotal, TPD.DescuentoImp, ")
        sConsulta.AppendLine("(SELECT (CASE WHEN sum(DesImporte) IS NULL THEN 0 ELSE sum(DesImporte) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) as DescuentoCliente, ")
        sConsulta.AppendLine("(TPD.SubTotal - (SELECT (CASE WHEN sum(DesImporte) IS NULL THEN 0 ELSE sum(DesImporte) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId)) * (TRP.DescVendPor / 100) as DescuentoVendedor ")
        sConsulta.AppendLine("into #VenTotRuta1 ")
        sConsulta.AppendLine("from TransProdDetalle TPD ")
        sConsulta.AppendLine("inner join TransProd TRP on TRP.TransProdID = TPD.TransProdID ")
        sConsulta.AppendLine("inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave ")
        sConsulta.AppendLine("where TRP.Tipo = 1 and TRP.TipoFase <> 0 ")

        If Not pvConversionKg Then
            '--Sin ConversionKg
            sConsulta.AppendLine("select ALN.Clave + ' ' + ALN.Nombre as CEDI, cast(floor(cast(TMP.FechaCaptura as float)) as datetime) as Fecha, ")
            sConsulta.AppendLine("TMP.RUTClave, RUT.Descripcion as RutaNombre, VEN.Nombre as Vendedor, ESQ.Clave, ESQ.Nombre, ")
            sConsulta.AppendLine("sum(TMP.Cantidad * Factor) as Unidades, ")
            sConsulta.AppendLine("sum(case when TMP.Promocion = 1 then TMP.SubTotal else TMP.Precio * TMP.Cantidad end) as Importe, ")
            sConsulta.AppendLine("sum(TMP.DescuentoImp + TMP.DescuentoCliente + TMP.DescuentoVendedor) as Descuentos, ")
            sConsulta.AppendLine("sum(TMP.SubTotal - (TMP.DescuentoImp + TMP.DescuentoCliente + TMP.DescuentoVendedor)) as Total, ")
            sConsulta.AppendLine("count(distinct TMP.ClienteClave) as ClienteCompra, ")
            sConsulta.AppendLine("(select count(distinct case when Compra > 0 then ClienteClave else null end) as ClientesCompra ")
            sConsulta.AppendLine("from ( ")
            sConsulta.AppendLine("select cast(floor(cast(TRP1.FechaCaptura as float)) as datetime) as Fecha, VEN1.Nombre as Vendedor, VIS1.RUTClave, ")
            sConsulta.AppendLine("VIS1.ClienteClave, sum(distinct case when TransProdID is null then 0 else 1 end) as Compra ")
            sConsulta.AppendLine("from Visita VIS1 ")
            sConsulta.AppendLine("inner join Vendedor VEN1 on VEN1.VendedorID = VIS1.VendedorID ")
            sConsulta.AppendLine("left join TransProd TRP1 on TRP1.VisitaClave= VIS1.VisitaClave  and TRP1.Tipo=1 and TRP1.TipoFase <> 0 ")
            sConsulta.AppendLine("where TRP1.FechaCaptura = cast(floor(cast(TMP.FechaCaptura as float)) as datetime) and VEN1.Nombre = VEN.Nombre and VIS1.RUTClave = TMP.RUTClave ")
            sConsulta.AppendLine("group by cast(floor(cast(TRP1.FechaCaptura as float)) as datetime), VEN1.Nombre, VIS1.RUTClave, VIS1.ClienteClave ")
            sConsulta.AppendLine(")as tmp2 ) as Cobertura ")
            sConsulta.AppendLine("from #VenTotRuta1 TMP ")
            sConsulta.AppendLine("inner join Ruta RUT on RUT.RUTClave = TMP.RUTClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on VEN.VendedorID = TMP.VendedorID ")
            sConsulta.AppendLine("inner join ProductoEsquema PRS on PRS.ProductoClave = TMP.ProductoClave ")
            sConsulta.AppendLine("inner join Esquema ESQ on ESQ.EsquemaID = PRS.EsquemaID ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRD.ProductoClave = TMP.ProductoClave and PRD.ProductoClave = TMP.ProductoClave and PRD.ProductoDetClave = TMP.ProductoClave and PRD.PRUTipoUnidad = TMP.TipoUnidad ")
            sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI from AgendaVendedor) AGV on TMP.DiaClave = AGV.DiaClave and VEN.VendedorId = AGV.VendedorId ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine(pvCondicion & " ")
            sConsulta.AppendLine("group by ALN.Clave, ALN.Nombre, cast(floor(cast(TMP.FechaCaptura as float)) as datetime), VEN.Nombre, TMP.RUTClave, ")
            sConsulta.AppendLine("RUT.Descripcion, ESQ.Clave, ESQ.Nombre ")
        Else
            '--Con ConversionKg
            sConsulta.AppendLine("select ALN.Clave + ' ' + ALN.Nombre as CEDI, cast(floor(cast(TMP.FechaCaptura as float)) as datetime) as Fecha, ")
            sConsulta.AppendLine("TMP.RUTClave, RUT.Descripcion as RutaNombre, VEN.Nombre as Vendedor, ESQ.Clave, ESQ.Nombre, ")
            sConsulta.AppendLine("sum(TMP.Cantidad * Factor) as Unidades, isnull(sum(TMP.Cantidad * PRU.KgLts),0) as KiloLitro, ")
            sConsulta.AppendLine("sum(case when TMP.Promocion = 1 then TMP.SubTotal else TMP.Precio * TMP.Cantidad end) as Importe, ")
            sConsulta.AppendLine("sum(TMP.DescuentoImp + TMP.DescuentoCliente + TMP.DescuentoVendedor) as Descuentos, ")
            sConsulta.AppendLine("sum(TMP.SubTotal - (TMP.DescuentoImp + TMP.DescuentoCliente + TMP.DescuentoVendedor)) as Total, ")
            sConsulta.AppendLine("count(distinct TMP.ClienteClave) as ClienteCompra, ")
            sConsulta.AppendLine("(select count(distinct case when Compra > 0 then ClienteClave else null end) as ClientesCompra ")
            sConsulta.AppendLine("from ( ")
            sConsulta.AppendLine("select cast(floor(cast(TRP1.FechaCaptura as float)) as datetime) as Fecha, VEN1.Nombre as Vendedor, VIS1.RUTClave, ")
            sConsulta.AppendLine("VIS1.ClienteClave, sum(distinct case when TRP1.TransProdID is null then 0 else 1 end) as Compra ")
            sConsulta.AppendLine("from Visita VIS1 ")
            sConsulta.AppendLine("inner join Vendedor VEN1 on VEN1.VendedorID = VIS1.VendedorID ")
            sConsulta.AppendLine("left join TransProd TRP1 on VIS1.VisitaClave = TRP1.VisitaClave and TRP1.Tipo = 1 and TRP1.TipoFase <> 0 ")
            sConsulta.AppendLine("where TRP1.FechaCaptura = cast(floor(cast(TMP.FechaCaptura as float)) as datetime) and VEN1.Nombre = VEN.Nombre and VIS1.RUTClave = TMP.RUTclave ")
            sConsulta.AppendLine("group by cast(floor(cast(TRP1.FechaCaptura as float)) as datetime), VEN1.Nombre, VIS1.RUTClave, VIS1.ClienteClave ")
            sConsulta.AppendLine(") as tmp2 ) as Cobertura ")
            sConsulta.AppendLine("from #VenTotRuta1 TMP ")
            sConsulta.AppendLine("inner join Ruta RUT on RUT.RUTClave = TMP.RUTClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on VEN.VendedorID = TMP.VendedorID ")
            sConsulta.AppendLine("inner join ProductoEsquema PRS on PRS.ProductoClave = TMP.ProductoClave ")
            sConsulta.AppendLine("inner join Esquema ESQ on ESQ.EsquemaID = PRS.EsquemaID ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRD.ProductoClave = TMP.ProductoClave and PRD.ProductoClave = TMP.ProductoClave and PRD.ProductoDetClave = TMP.ProductoClave and PRD.PRUTipoUnidad = TMP.TipoUnidad ")
            sConsulta.AppendLine("inner join ProductoUnidad PRU on PRU.ProductoClave = TMP.ProductoClave and PRU.PRUTipoUnidad = TMP.TipoUnidad ")
            sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI from AgendaVendedor) AGV on TMP.DiaClave = AGV.DiaClave and VEN.VendedorId = AGV.VendedorId ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine(pvCondicion & " ")
            sConsulta.AppendLine("group by ALN.Clave, ALN.Nombre, cast(floor(cast(TMP.FechaCaptura as float)) as datetime), VEN.Nombre, TMP.RUTClave, ")
            sConsulta.AppendLine("RUT.Descripcion, ESQ.Clave, ESQ.Nombre ")
        End If
        sConsulta.AppendLine("drop table #VenTotRuta1 ")
        sConsulta.AppendLine("set nocount off ")
        'Session("Query") = sConsulta.ToString

        Dim dt As Data.DataTable

        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("if (select object_id('tempdb..#VenTotRuta1')) is not null drop table #VenTotRuta1 ")
        sConsulta.AppendLine("select * into #VenTotRuta1 from( ")
        sConsulta.AppendLine("select VIS.FechaHoraInicial as FechaCaptura, VIS.RutClave, VIS.ClienteClave, VIS.VendedorId, VIS.VisitaClave, VEN.Nombre, TRP.TransProdId, vis.DiaClave ")
        sConsulta.AppendLine("from Visita VIS ")
        sConsulta.AppendLine("inner join Vendedor VEN on VEN.VendedorID = VIS.VendedorID ")
        sConsulta.AppendLine("left join ImproductividadVenta IMV on IMV.VisitaClave = VIS.VisitaClave and vis.diaclave=imv.diaclave ")
        sConsulta.AppendLine("left join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and TRP.Tipo = 1 and TRP.TipoFase <> 0 ")
        sConsulta.AppendLine(sCondicion & " ")
        sConsulta.AppendLine(")as t1 ")
        sConsulta.AppendLine("if (select object_id('tempdb..#VenTotRuta2')) is not null drop table #VenTotRuta2 ")
        sConsulta.AppendLine("select * into #VenTotRuta2 from( ")
        sConsulta.AppendLine("select ALN.Clave + ' ' + ALN.Nombre as CEDI,TMP.FechaCaptura, TMP.RutClave, TMP.ClienteClave, TMP.VendedorId, TMP.VisitaClave, TMP.Nombre, TMP.TransProdId, TMP.DiaClave, AGV.ClienteClave as AGVClienteClave ")
        sConsulta.AppendLine("from #VenTotRuta1 TMP ")
        sConsulta.AppendLine("LEFT join (select distinct DiaClave, VendedorId, ClienteClave, ClaveCEDI from AgendaVendedor) AGV on TMP.DiaClave = AGV.DiaClave and TMP.VendedorId = AGV.VendedorId ")
        sConsulta.AppendLine("LEFT join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
        sConsulta.AppendLine(sCondicionALN & " ")
        sConsulta.AppendLine(")as t2 ")
        sConsulta.AppendLine("select CEDI,Fecha, Vendedor, RUTClave, count(distinct ClienteClave) as Visitados, ")
        sConsulta.AppendLine("count(distinct AgendClienteClave) as ClientesRuta, count(distinct case when Compra > 0 then ClienteClave else null end) as ClientesCompra, ")
        sConsulta.AppendLine("count(distinct case when Compra <= 0 then ClienteClave else null end) as ClientesSinCompra ")
        sConsulta.AppendLine("from( ")
        sConsulta.AppendLine("select CEDI,TMP.AGVClienteClave as AgendClienteClave, cast(floor(cast(TMP.FechaCaptura as float)) as datetime) as Fecha, ")
        sConsulta.AppendLine("TMP.Nombre as Vendedor, TMP.RUTClave, TMP.ClienteClave, ")
        sConsulta.AppendLine("sum(distinct case when TMP.VisitaClave is null then 0 else 1 end) as Improductividad, ")
        sConsulta.AppendLine("sum(distinct case when TMP.TransProdID is null then 0 else 1 end) as Compra ")
        sConsulta.AppendLine("from #VenTotRuta2 TMP ")
        sConsulta.AppendLine("group by CEDI,TMP.AGVClienteClave, cast(floor(cast(TMP.FechaCaptura as float)) as datetime), TMP.Nombre, TMP.RUTClave, TMP.ClienteClave ")
        sConsulta.AppendLine(")as TMP group by CEDI,Fecha, Vendedor, RutClave ")
        sConsulta.AppendLine("drop table #VenTotRuta1 ")
        sConsulta.AppendLine("drop table #VenTotRuta2 ")
        sConsulta.AppendLine("set nocount off ")
        Session("Query2") = sConsulta.ToString

        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("if (select object_id('tempdb..#VenTotRuta1')) is not null drop table #VenTotRuta1 ")
        sConsulta.AppendLine("select * into #VenTotRuta1 from( ")
        sConsulta.AppendLine("select VIS.FechaHoraInicial as FechaCaptura, VIS.ClienteClave, VIS.VendedorId, VEN.Nombre as VENNombre, IMV.VisitaClave, TRP.TransProdId, vis.DiaClave ")
        sConsulta.AppendLine("from Visita VIS ")
        sConsulta.AppendLine("inner join Vendedor VEN on VEN.VendedorID = VIS.VendedorID ")
        sConsulta.AppendLine("left join ImproductividadVenta IMV on IMV.VisitaClave = VIS.VisitaClave and vis.diaclave=imv.diaclave ")
        sConsulta.AppendLine("left join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and TRP.Tipo = 1 and TRP.TipoFase <> 0 ")
        sConsulta.AppendLine(sCondicion & " ")
        sConsulta.AppendLine(")as t1 ")
        sConsulta.AppendLine("if (select object_id('tempdb..#VenTotRuta2')) is not null drop table #VenTotRuta2 ")
        sConsulta.AppendLine("select * into #VenTotRuta2 from( ")
        sConsulta.AppendLine("select ALN.Clave + ' ' + ALN.Nombre as CEDI,TMP.FechaCaptura, TMP.ClienteClave, VENNombre, TMP.VisitaClave, TMP.TransProdId, TMP.DiaClave, AGV.ClienteClave as AGVClienteClave ")
        sConsulta.AppendLine("from #VenTotRuta1 TMP ")
        sConsulta.AppendLine("LEFT join (select distinct DiaClave, VendedorId, ClienteClave, ClaveCEDI from AgendaVendedor) AGV on TMP.DiaClave = AGV.DiaClave and TMP.VendedorId = AGV.VendedorId ")
        sConsulta.AppendLine("LEFT join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
        sConsulta.AppendLine(sCondicionALN & " ")
        sConsulta.AppendLine(")as t2 ")
        sConsulta.AppendLine("select CEDI, Fecha, Vendedor, count(distinct Clienteclave) as Visitados, ")
        sConsulta.AppendLine("count(distinct AgendClienteClave) as ClientesRuta, count(distinct case when Compra > 0 then ClienteClave else null end) as ClientesCompra, ")
        sConsulta.AppendLine("count(distinct case when Compra <= 0 then ClienteClave else null end) as ClientesSinCompra ")
        sConsulta.AppendLine("from( ")
        sConsulta.AppendLine("select CEDI, TMP.AGVClienteClave as AgendClienteClave, cast(floor(cast(TMP.FechaCaptura as float)) as datetime) as Fecha, ")
        sConsulta.AppendLine("VENNombre as Vendedor, TMP.ClienteClave, ")
        sConsulta.AppendLine("sum(distinct case when TMP.VisitaClave is null then 0 else 1 end) as Improductividad, ")
        sConsulta.AppendLine("sum(distinct case when TMP.TransProdID is null then 0 else 1 end) as Compra ")
        sConsulta.AppendLine("from #VenTotRuta2 TMP ")
        sConsulta.AppendLine("group by CEDI,TMP.AGVClienteClave, cast(floor(cast(TMP.FechaCaptura as float)) as datetime), TMP.VENNombre, TMP.ClienteClave ")
        sConsulta.AppendLine(")as TMP group by CEDI,Fecha, Vendedor ")
        sConsulta.AppendLine("drop table #VenTotRuta1 ")
        sConsulta.AppendLine("drop table #VenTotRuta2 ")
        sConsulta.AppendLine("set nocount off ")
        Session("Query3") = sConsulta.ToString

        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("if (select object_id('tempdb..#VenTotRuta1')) is not null drop table #VenTotRuta1 ")
        sConsulta.AppendLine("select * into #VenTotRuta1 from( ")
        sConsulta.AppendLine("select VIS.FechaHoraInicial as FechaCaptura, VIS.ClienteClave, VEN.VendedorId, IMV.VisitaClave, TRP.TransProdId, vis.DiaClave ")
        sConsulta.AppendLine("from Visita VIS ")
        sConsulta.AppendLine("inner join Vendedor VEN on VEN.VendedorID = VIS.VendedorID ")
        sConsulta.AppendLine("left join ImproductividadVenta IMV on IMV.VisitaClave = VIS.VisitaClave and vis.diaclave=imv.diaclave ")
        sConsulta.AppendLine("left join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and TRP.Tipo = 1 and TRP.TipoFase <> 0 ")
        sConsulta.AppendLine(sCondicion & " ")
        sConsulta.AppendLine(")as t1 ")
        sConsulta.AppendLine("if (select object_id('tempdb..#VenTotRuta2')) is not null drop table #VenTotRuta2 ")
        sConsulta.AppendLine("select * into #VenTotRuta2 from( ")
        sConsulta.AppendLine("select ALN.Clave + ' ' + ALN.Nombre as CEDI,TMP.FechaCaptura, TMP.ClienteClave, TMP.VendedorId, TMP.VisitaClave, TMP.TransProdId, TMP.DiaClave, AGV.ClienteClave as AGVClienteClave ")
        sConsulta.AppendLine("from #VenTotRuta1 TMP ")
        sConsulta.AppendLine("LEFT join (select distinct DiaClave, VendedorId, ClienteClave, ClaveCEDI from AgendaVendedor) AGV on TMP.DiaClave = AGV.DiaClave and TMP.VendedorId = AGV.VendedorId ")
        sConsulta.AppendLine("LEFT join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
        sConsulta.AppendLine(sCondicionALN & " ")
        sConsulta.AppendLine(")as t2 ")
        sConsulta.AppendLine("select CEDI,Fecha, count(distinct ClienteClave) as Visitados, ")
        sConsulta.AppendLine("count(distinct AgendClienteClave) as ClientesRuta, count(distinct case when Compra > 0 then ClienteClave else null end) as ClientesCompra, ")
        sConsulta.AppendLine("count(distinct case when Compra <= 0 then ClienteClave else null end) as ClientesSinCompra ")
        sConsulta.AppendLine("from( ")
        sConsulta.AppendLine("select CEDI,TMP.AGVClienteClave as AgendClienteClave, cast(floor(cast(TMP.FechaCaptura as float)) as datetime) as Fecha, ")
        sConsulta.AppendLine("TMP.ClienteClave, ")
        sConsulta.AppendLine("sum(distinct case when TMP.VisitaClave is null then 0 else 1 end) as Improductividad, ")
        sConsulta.AppendLine("sum(distinct case when TMP.TransProdID is null then 0 else 1 end) as Compra ")
        sConsulta.AppendLine("from #VenTotRuta2 TMP ")
        sConsulta.AppendLine("group by CEDI,TMP.AGVClienteClave, cast(floor(cast(TMP.FechaCaptura as float)) as datetime), TMP.ClienteClave ")
        sConsulta.AppendLine(")as TMP group by CEDI,Fecha ")
        sConsulta.AppendLine("drop table #VenTotRuta1 ")
        sConsulta.AppendLine("drop table #VenTotRuta2 ")
        sConsulta.AppendLine("set nocount off ")
        Session("Query4") = sConsulta.ToString

        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("if (select object_id('tempdb..#VenTotRuta1')) is not null drop table #VenTotRuta1 ")
        sConsulta.AppendLine("select * into #VenTotRuta1 from( ")
        sConsulta.AppendLine("select VIS.FechaHoraInicial as FechaCaptura, VIS.ClienteClave, VEN.VendedorId, IMV.VisitaClave, TRP.TransProdId, vis.DiaClave ")
        sConsulta.AppendLine("from Visita VIS ")
        sConsulta.AppendLine("inner join Vendedor VEN on VEN.VendedorID = VIS.VendedorID ")
        sConsulta.AppendLine("left join ImproductividadVenta IMV on IMV.VisitaClave = VIS.VisitaClave and vis.diaclave=imv.diaclave ")
        sConsulta.AppendLine("left join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and TRP.Tipo = 1 and TRP.TipoFase <> 0 ")
        sConsulta.AppendLine(sCondicion & " ")
        sConsulta.AppendLine(")as t1 ")
        sConsulta.AppendLine("if (select object_id('tempdb..#VenTotRuta2')) is not null drop table #VenTotRuta2 ")
        sConsulta.AppendLine("select * into #VenTotRuta2 from( ")
        sConsulta.AppendLine("select TMP.FechaCaptura, TMP.ClienteClave, TMP.VendedorId, TMP.VisitaClave, TMP.TransProdId, TMP.DiaClave, ")
        sConsulta.AppendLine("AGV.ClienteClave as AGVClienteClave, ALN.Clave as ALNClave, ALN.Nombre as ALNNombre ")
        sConsulta.AppendLine("from #VenTotRuta1 TMP ")
        sConsulta.AppendLine("LEFT join (select distinct DiaClave, VendedorId, ClienteClave, ClaveCEDI from AgendaVendedor) AGV on TMP.DiaClave = AGV.DiaClave and TMP.VendedorId = AGV.VendedorId ")
        sConsulta.AppendLine("LEFT join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
        sConsulta.AppendLine(sCondicionALN & " ")
        sConsulta.AppendLine(")as t2 ")
        sConsulta.AppendLine("Select CEDI, sum(Visitados) as Visitados from( ")
        sConsulta.AppendLine("select CEDI, Fecha,count(distinct ClienteClave) as Visitados ")
        sConsulta.AppendLine("from ")
        sConsulta.AppendLine("(select TMP.AGVClienteClave as AgendClienteClave, cast(floor(cast(TMP.FechaCaptura as float)) as datetime) as Fecha, ")
        sConsulta.AppendLine("TMP.ClienteClave, ")
        sConsulta.AppendLine("sum(distinct case when VisitaClave is null then 0 else 1 end) as Improductividad, ")
        sConsulta.AppendLine("sum(distinct case when TransProdID is null then 0 else 1 end) as Compra, ")
        sConsulta.AppendLine("ALNClave + ' ' + ALNNombre as CEDI ")
        sConsulta.AppendLine("from #VenTotRuta2 TMP ")
        sConsulta.AppendLine("group by TMP.AGVClienteClave, TMP.ALNClave, TMP.ALNNombre, cast(floor(cast(TMP.FechaCaptura as float)) as datetime), TMP.ClienteClave ")
        sConsulta.AppendLine(")as tmp group by CEDI,Fecha ) as TMP2 ")
        sConsulta.AppendLine("group by CEDI ")
        sConsulta.AppendLine("drop table #VenTotRuta1 ")
        sConsulta.AppendLine("drop table #VenTotRuta2 ")
        sConsulta.AppendLine("set nocount off ")
        Session("Query5") = sConsulta.ToString
        Return True
    End Function

    Private Function ConsultaVentasPorCliente(ByVal ins As DBConexion.cConexionSQL, ByVal pvConversionKg As Boolean, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvClientes As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        Dim sCondicionALN As String = ""
        Dim sCondicionVIS As String = ""

        sCondicionVIS = "where 1=1 "
        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "TRP.FechaCaptura")
            sCondicionVIS = strWhereFecha(sCondicionVIS, "VIS.FechaHoraInicial")
        End If
        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "VIS.RUTClave")
        pvCondicion = strWhereClientes(pvCondicion, pvClientes, "CLI.ClienteClave")
        If (ChBoxCentroDistribucion.Checked) Then
            sCondicionALN = "where ALN.Clave = '" + DdlCentroDistribucion.SelectedValue + "' "
        End If

        If pvConversionKg Then

            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("set nocount on ")
            sConsulta.AppendLine("if (select object_id('tempdb..#TmpVentas')) is not null drop table #TmpVentas ")
            sConsulta.AppendLine("select * into #TmpVentas from( ")
            sConsulta.AppendLine("select TRP.TransProdId, TRP.VisitaClave, TRP.DiaClave, TRP.FechaCaptura, ")
            sConsulta.AppendLine("TPD.ProductoClave, TPD.TipoUnidad, TPD.Cantidad, (TPD.Precio * TPD.Cantidad) as Importe, ")
            sConsulta.AppendLine("((SELECT (CASE WHEN sum(DesImporte) IS NULL THEN 0 ELSE sum(DesImporte) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) ) as Descuento,  TPD.DescuentoImp as DescuentoImp,TPD.SubTotal,TRP.DescVendPor, ")
            sConsulta.AppendLine("VIS.VendedorId, VIS.RutClave, VIS.FechaHoraInicial, CLI.Clave AS ClienteClave, ")
            sConsulta.AppendLine("VEN.Nombre as VENNombre, PRS.EsquemaId, ESQ.Clave + '-' + ESQ.Nombre as ESQNombre, ")
            sConsulta.AppendLine("CLI.RazonSocial as CLIRazonSocial, PRD.Factor , PRU.KgLts, ")
            sConsulta.AppendLine("(CASE WHEN Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) THEN 1 ELSE 0 END) EnAgenda ")
            sConsulta.AppendLine(",CLI.ClienteClave as ClienteClaveID ") '-##
            sConsulta.AppendLine("from TransProd TRP ")
            sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransprodID = TPD.TransprodID ")
            sConsulta.AppendLine("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave ")
            sConsulta.AppendLine("inner join Dia on Dia.DiaClave = VIS.DiaClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorID = VEN.VendedorID ")
            sConsulta.AppendLine("inner join ProductoEsquema PRS on TPD.ProductoClave = PRS.ProductoClave ")
            sConsulta.AppendLine("inner join Esquema ESQ on PRS.EsquemaID = ESQ.EsquemaID ")
            sConsulta.AppendLine("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRD.ProductoClave = TPD.ProductoClave and PRD.PRUTipoUnidad = TPD.TipoUnidad ")
            sConsulta.AppendLine("inner join ProductoUnidad PRU on PRU.ProductoClave = TPD.ProductoClave and PRU.PRUTipoUnidad = TPD.TipoUnidad ")
            sConsulta.AppendLine(pvCondicion & " and (TRP.Tipo = 1 And TRP.TipoFase <>0  and TPD.Promocion <> 2) ")
            sConsulta.AppendLine("group by TRP.TransProdId, TRP.VisitaClave, TRP.DiaClave, TRP.FechaCaptura, TPD.TransProdDetalleId, ")
            sConsulta.AppendLine("TPD.ProductoClave, TPD.TipoUnidad, TPD.Cantidad, (TPD.Precio * TPD.Cantidad),  TPD.DescuentoImp, ")
            sConsulta.AppendLine("TPD.SubTotal,TRP.DescVendPor, ")
            sConsulta.AppendLine("VIS.VendedorId, VIS.RutClave, VIS.FechaHoraInicial, CLI.Clave, ")
            sConsulta.AppendLine("VEN.Nombre, PRS.EsquemaId, ESQ.Clave + '-' + ESQ.Nombre, ")
            sConsulta.AppendLine("CLI.RazonSocial, PRD.Factor, PRU.KgLts, DIA.FechaCaptura ")
            sConsulta.AppendLine(", CLI.ClienteClave ") '-##
            sConsulta.AppendLine(")as t1 ")

            sConsulta.AppendLine("if (select object_id('tempdb..#TmpVentas2')) is not null drop table #TmpVentas2 ")
            sConsulta.AppendLine("select * into #TmpVentas2 from( ")
            sConsulta.AppendLine("select TMP.TransProdId, TMP.VisitaClave, TMP.DiaClave, TMP.FechaCaptura, ")
            sConsulta.AppendLine("TMP.ProductoClave, TMP.TipoUnidad, TMP.Cantidad, TMP.Importe, ")
            sConsulta.AppendLine("(TMP.Descuento +DescuentoImp+ ((TMP.SubTotal - TMP.Descuento)*(TMP.DescVendPor/100))) as Descuento, ")
            sConsulta.AppendLine("(CASE WHEN TMP.EnAgenda=1 THEN (TMP.Importe-(TMP.Descuento +DescuentoImp+ ((TMP.SubTotal - TMP.Descuento)*(TMP.DescVendPor/100)))) ELSE 0 END) as TotalEnAgenda, ")
            sConsulta.AppendLine("(CASE WHEN TMP.EnAgenda=0 THEN (TMP.Importe-(TMP.Descuento +DescuentoImp+ ((TMP.SubTotal - TMP.Descuento)*(TMP.DescVendPor/100)))) ELSE 0 END) as TotalFueraAgenda, ")
            sConsulta.AppendLine("TMP.VendedorId, TMP.RutClave, TMP.FechaHoraInicial, TMP.ClienteClave, ")
            sConsulta.AppendLine("TMP.VENNombre, TMP.EsquemaId, TMP.ESQNombre, TMP.CLIRazonSocial, ")
            sConsulta.AppendLine("TMP.Factor, ALN.Clave as ALNClave, ALN.Nombre as ALNNombre , TMP.KgLts ")
            sConsulta.AppendLine(",TMP.ClienteClaveID as ClienteClaveID ") '-##
            sConsulta.AppendLine("from #TmpVentas TMP ")
            sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI from AgendaVendedor) AGV on TMP.DiaClave = AGV.DiaClave and TMP.VendedorId = AGV.VendedorId ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine(sCondicionALN)
            sConsulta.AppendLine(")as t2 ")

            sConsulta.AppendLine("if (select object_id('tempdb..#TmpVentas3')) is not null drop table #TmpVentas3 ")
            sConsulta.AppendLine("select * into #TmpVentas3 from( ")
            sConsulta.AppendLine("select AGV.ClaveCEDI as ALNClave, VIS.VendedorId, VIS.RutClave, VIS.ClienteClave, ")
            sConsulta.AppendLine("Convert(varchar(20),VIS.FechaHoraInicial,103) as FechaHoraInicial, Convert(varchar(20),DIA.FechaCaptura,103) as FechaCaptura ")
            sConsulta.AppendLine("from Visita VIS ")
            sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI from AgendaVendedor) AGV on VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorId ")
            sConsulta.AppendLine("inner join Dia ON Dia.DiaClave=VIS.DiaClave ")
            sConsulta.AppendLine(sCondicionVIS)
            sConsulta.AppendLine(")as t3 ")

            sConsulta.AppendLine("if (select object_id('tempdb..#TmpVentas4')) is not null drop table #TmpVentas4 ")
            sConsulta.AppendLine("select * into #TmpVentas4 from( ")
            sConsulta.AppendLine("select FechaCaptura, ALNClave, VendedorId, RutClave, ClienteClave, EsquemaId ")
            sConsulta.AppendLine(", ClienteClaveID ") '-##
            sConsulta.AppendLine("from #TmpVentas2 ")
            sConsulta.AppendLine("group by FechaCaptura, ALNClave, VendedorId, RutClave, ClienteClave, EsquemaId ")
            sConsulta.AppendLine(", ClienteClaveID ") '-##
            sConsulta.AppendLine(")as t4 ")

            sConsulta.AppendLine("select ALNClave + ' ' + ALNNombre as CEDI, ")
            sConsulta.AppendLine("(select distinct count(*) from #TmpVentas3 VIS1 where  VIS1.ALNClave = TMP.ALNClave and VIS1.VendedorID = TMP.VendedorID and VIS1.RutClave = TMP.RutClave and VIS1.ClienteClave = ")
            sConsulta.AppendLine(" TMP.ClienteClaveID ") '-##
            sConsulta.AppendLine("AND VIS1.FechaHoraInicial = VIS1.FechaCaptura) as NoVisitaClienteEnAgenda, ")
            sConsulta.AppendLine("(select distinct count(*) from #TmpVentas3 VIS1 where  VIS1.ALNClave = TMP.ALNClave and VIS1.VendedorID = TMP.VendedorID and VIS1.RutClave = TMP.RutClave and VIS1.ClienteClave = ")
            sConsulta.AppendLine(" TMP.ClienteClaveID ") '-##
            sConsulta.AppendLine("AND VIS1.FechaHoraInicial <> VIS1.FechaCaptura) as NoVisitaClienteFueraAgenda, ")
            sConsulta.AppendLine("(select distinct count(*) from #TmpVentas3 VIS1 where  VIS1.ALNClave = TMP.ALNClave and VIS1.VendedorID = TMP.VendedorID and VIS1.RutClave = TMP.RutClave) as NoVisitaRuta, ")
            sConsulta.AppendLine("(select distinct count(*) from #TmpVentas3 VIS1 where  VIS1.ALNClave = TMP.ALNClave and VIS1.VendedorID = TMP.VendedorID) as NoVisitaVendedor, ")
            sConsulta.AppendLine("(select distinct count(*) from #TmpVentas3 VIS1 where  VIS1.ALNClave = TMP.ALNClave) as NoVisitaAlmacen, ")
            sConsulta.AppendLine("(select distinct count(*) from #TmpVentas3 VIS1) as NoVisitaTotales, ")
            sConsulta.AppendLine("VENNombre as Vendedor, RutClave as Ruta, ")
            sConsulta.AppendLine("(select top 1 RUT.RUTClave + ' ' + RUT.Descripcion from Ruta RUT where RUT.RutClave = TMP.RutClave) as RutaNombre, ")
            sConsulta.AppendLine("convert(varchar(16), CLI.Clave) + ' ' + CLIRazonSocial as Cliente, ESQNombre as Esquema, ")
            sConsulta.AppendLine("(select distinct count(*) from #TmpVentas4 TMV where TMV.VendedorID = TMP.VendedorID and TMV.RutClave = TMP.RutClave ")
            'sConsulta.AppendLine("and TMV.ClienteClave=TMP.ClienteClave ")
            sConsulta.AppendLine(" and TMV.ClienteClaveId=TMP.ClienteClaveID ") '-##
            sConsulta.AppendLine(" and TMV.EsquemaId=TMP.EsquemaId) as DiasCompra, ")
            sConsulta.AppendLine("ProductoClave as ProductoClave, (select PRO.Nombre from Producto PRO where PRO.ProductoClave = TMP.ProductoClave) as Producto, ")
            sConsulta.AppendLine("sum(Factor * Cantidad) as Unidades, sum(Importe) as Importe , sum(Descuento) as Descuento, sum(Importe - Descuento) as Total, sum(TMP.TotalEnAgenda) as TotalEnAgenda, sum(TMP.TotalFueraAgenda) as TotalFueraAgenda, isnull(sum(Cantidad * KgLts), 0) as KiloLitro ")
            sConsulta.AppendLine("from #TmpVentas2 TMP ")
            sConsulta.AppendLine("inner join Cliente CLI ON CLI.ClienteClave=TMP.ClienteClave ")
            sConsulta.AppendLine("group by ALNClave, ALNNombre, convert(datetime, convert(varchar(10), FechaCaptura, 112)), ")
            sConsulta.AppendLine("convert(datetime, convert(varchar(10), FechaHoraInicial, 112)), VendedorID, VENNombre, RutClave, TMP.ClienteClave, CLI.Clave, ")
            sConsulta.AppendLine("CLIRazonSocial, ESQNombre, ProductoClave, FechaCaptura, EsquemaId ")
            sConsulta.AppendLine(", ClienteClaveID ") '-##
            sConsulta.AppendLine("order by Vendedor, Ruta, CLI.Clave ")
            sConsulta.AppendLine("drop table #TmpVentas ")
            sConsulta.AppendLine("drop table #TmpVentas2 ")
            sConsulta.AppendLine("drop table #TmpVentas3 ")
            sConsulta.AppendLine("drop table #TmpVentas4 ")
            sConsulta.AppendLine("set nocount off ")

        Else

            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("set nocount on ")
            sConsulta.AppendLine("if (select object_id('tempdb..#TmpVentas')) is not null drop table #TmpVentas ")
            sConsulta.AppendLine("select * into #TmpVentas from( ")
            sConsulta.AppendLine("select TRP.TransProdId, TRP.VisitaClave, TRP.DiaClave, TRP.FechaCaptura, ")
            sConsulta.AppendLine("TPD.ProductoClave, TPD.TipoUnidad, TPD.Cantidad, (TPD.Precio * TPD.Cantidad) as Importe, ")
            sConsulta.AppendLine("((SELECT (CASE WHEN sum(DesImporte) IS NULL THEN 0 ELSE sum(DesImporte) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId)) as Descuento,  TPD.DescuentoImp as  DescuentoImp ,TPD.SubTotal,TRP.DescVendPor, ")
            sConsulta.AppendLine("VIS.VendedorId, VIS.RutClave, VIS.FechaHoraInicial, CLI.Clave AS ClienteClave, ")
            sConsulta.AppendLine("VEN.Nombre as VENNombre, PRS.EsquemaId, ESQ.Clave + '-' + ESQ.Nombre as ESQNombre, ")
            sConsulta.AppendLine("CLI.RazonSocial as CLIRazonSocial, PRD.Factor, ")
            sConsulta.AppendLine("(CASE WHEN Convert(varchar(20),DIA.FechaCaptura,103) = Convert(varchar(20),VIS.FechaHoraInicial,103) THEN 1 ELSE 0 END) EnAgenda ")
            sConsulta.AppendLine(",CLI.ClienteClave as ClienteClaveID ") '-##
            sConsulta.AppendLine("from TransProd TRP ")
            sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransprodID = TPD.TransprodID ")
            sConsulta.AppendLine("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave ")
            sConsulta.AppendLine("inner join Dia on Dia.DiaClave = VIS.DiaClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorID = VEN.VendedorID ")
            sConsulta.AppendLine("inner join ProductoEsquema PRS on TPD.ProductoClave = PRS.ProductoClave ")
            sConsulta.AppendLine("inner join Esquema ESQ on PRS.EsquemaID = ESQ.EsquemaID ")
            sConsulta.AppendLine("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRD.ProductoClave = TPD.ProductoClave and PRD.PRUTipoUnidad = TPD.TipoUnidad ")
            sConsulta.AppendLine(pvCondicion & " and (TRP.Tipo = 1 And TRP.TipoFase <>0 and TPD.Promocion <> 2 ) ")
            sConsulta.AppendLine("group by TRP.TransProdId, TRP.VisitaClave, TRP.DiaClave, TRP.FechaCaptura, TPD.TransProdDetalleId, ")
            sConsulta.AppendLine("TPD.ProductoClave, TPD.TipoUnidad, TPD.Cantidad, (TPD.Precio * TPD.Cantidad),  TPD.DescuentoImp, ")
            sConsulta.AppendLine("TPD.SubTotal,TRP.DescVendPor, ")
            sConsulta.AppendLine("VIS.VendedorId, VIS.RutClave, VIS.FechaHoraInicial, CLI.Clave, ")
            sConsulta.AppendLine("VEN.Nombre, PRS.EsquemaId, ESQ.Clave + '-' + ESQ.Nombre, ")
            sConsulta.AppendLine("CLI.RazonSocial, PRD.Factor, DIA.FechaCaptura ")
            sConsulta.AppendLine(", CLI.ClienteClave ") '-##
            sConsulta.AppendLine(")as t1 ")

            sConsulta.AppendLine("if (select object_id('tempdb..#TmpVentas2')) is not null drop table #TmpVentas2 ")
            sConsulta.AppendLine("select * into #TmpVentas2 from( ")
            sConsulta.AppendLine("select TMP.TransProdId, TMP.VisitaClave, TMP.DiaClave, TMP.FechaCaptura, ")
            sConsulta.AppendLine("TMP.ProductoClave, TMP.TipoUnidad, TMP.Cantidad, TMP.Importe, ")
            sConsulta.AppendLine("(TMP.Descuento +DescuentoImp+ ((TMP.SubTotal - TMP.Descuento)*(TMP.DescVendPor/100))) as Descuento, ")
            sConsulta.AppendLine("(CASE WHEN TMP.EnAgenda=1 THEN (TMP.Importe-(TMP.Descuento +DescuentoImp+ ((TMP.SubTotal - TMP.Descuento)*(TMP.DescVendPor/100)))) ELSE 0 END) as TotalEnAgenda, ")
            sConsulta.AppendLine("(CASE WHEN TMP.EnAgenda=0 THEN (TMP.Importe-(TMP.Descuento +DescuentoImp+ ((TMP.SubTotal - TMP.Descuento)*(TMP.DescVendPor/100)))) ELSE 0 END) as TotalFueraAgenda, ")
            sConsulta.AppendLine("TMP.VendedorId, TMP.RutClave, TMP.FechaHoraInicial, TMP.ClienteClave, ")
            sConsulta.AppendLine("TMP.VENNombre, TMP.EsquemaId, TMP.ESQNombre, TMP.CLIRazonSocial, ")
            sConsulta.AppendLine("TMP.Factor, ALN.Clave as ALNClave, ALN.Nombre as ALNNombre ")
            sConsulta.AppendLine(",TMP.ClienteClaveID as ClienteClaveID ") '-##
            sConsulta.AppendLine("from #TmpVentas TMP ")
            sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI from AgendaVendedor) AGV on TMP.DiaClave = AGV.DiaClave and TMP.VendedorId = AGV.VendedorId ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine(sCondicionALN)
            sConsulta.AppendLine(")as t2 ")

            sConsulta.AppendLine("if (select object_id('tempdb..#TmpVentas3')) is not null drop table #TmpVentas3 ")
            sConsulta.AppendLine("select * into #TmpVentas3 from( ")
            sConsulta.AppendLine("select AGV.ClaveCEDI as ALNClave, VIS.VendedorId, VIS.RutClave, VIS.ClienteClave, ")
            sConsulta.AppendLine("Convert(varchar(20),VIS.FechaHoraInicial,103) as FechaHoraInicial, Convert(varchar(20),DIA.FechaCaptura,103) as FechaCaptura ")
            sConsulta.AppendLine("from Visita VIS ")
            sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI from AgendaVendedor) AGV on VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorId ")
            sConsulta.AppendLine("inner join Dia ON Dia.DiaClave=VIS.DiaClave ")
            sConsulta.AppendLine(sCondicionVIS)
            sConsulta.AppendLine(")as t3 ")

            sConsulta.AppendLine("if (select object_id('tempdb..#TmpVentas4')) is not null drop table #TmpVentas4 ")
            sConsulta.AppendLine("select * into #TmpVentas4 from( ")
            sConsulta.AppendLine("select FechaCaptura, ALNClave, VendedorId, RutClave, ClienteClave, EsquemaId ")
            sConsulta.AppendLine(", ClienteClaveID ") '-##
            sConsulta.AppendLine(" from #TmpVentas2 ")
            sConsulta.AppendLine("group by FechaCaptura, ALNClave, VendedorId, RutClave, ClienteClave, EsquemaId ")
            sConsulta.AppendLine(", ClienteClaveID ") '-##
            sConsulta.AppendLine(")as t4 ")

            sConsulta.AppendLine("select ALNClave + ' ' + ALNNombre as CEDI, ")
            sConsulta.AppendLine("(select distinct count(*) from #TmpVentas3 VIS1 where  VIS1.ALNClave = TMP.ALNClave and VIS1.VendedorID = TMP.VendedorID and VIS1.RutClave = TMP.RutClave and VIS1.ClienteClave = ")
            sConsulta.AppendLine(" TMP.ClienteClaveID ") '-##
            sConsulta.AppendLine(" AND VIS1.FechaHoraInicial = VIS1.FechaCaptura) as NoVisitaClienteEnAgenda, ")
            sConsulta.AppendLine("(select distinct count(*) from #TmpVentas3 VIS1 where  VIS1.ALNClave = TMP.ALNClave and VIS1.VendedorID = TMP.VendedorID and VIS1.RutClave = TMP.RutClave and VIS1.ClienteClave = ")
            sConsulta.AppendLine(" TMP.ClienteClaveID ") '-##
            sConsulta.AppendLine("AND VIS1.FechaHoraInicial <> VIS1.FechaCaptura) as NoVisitaClienteFueraAgenda, ")
            sConsulta.AppendLine("(select distinct count(*) from #TmpVentas3 VIS1 where  VIS1.ALNClave = TMP.ALNClave and VIS1.VendedorID = TMP.VendedorID and VIS1.RutClave = TMP.RutClave) as NoVisitaRuta, ")
            sConsulta.AppendLine("(select distinct count(*) from #TmpVentas3 VIS1 where  VIS1.ALNClave = TMP.ALNClave and VIS1.VendedorID = TMP.VendedorID) as NoVisitaVendedor, ")
            sConsulta.AppendLine("(select distinct count(*) from #TmpVentas3 VIS1 where  VIS1.ALNClave = TMP.ALNClave) as NoVisitaAlmacen, ")
            sConsulta.AppendLine("(select distinct count(*) from #TmpVentas3 VIS1) as NoVisitaTotales, ")
            sConsulta.AppendLine("VENNombre as Vendedor, RutClave as Ruta, ")
            sConsulta.AppendLine("(select top 1 RUT.RUTClave + ' ' + RUT.Descripcion from Ruta RUT where RUT.RutClave = TMP.RutClave) as RutaNombre, ")
            sConsulta.AppendLine("convert(varchar(16), CLI.Clave) + ' ' + CLIRazonSocial as Cliente, ESQNombre as Esquema, ")
            sConsulta.AppendLine("(select distinct count(*) from #TmpVentas4 TMV where TMV.VendedorID = TMP.VendedorID and TMV.RutClave = TMP.RutClave ")
            'sConsulta.AppendLine("and TMV.ClienteClave=TMP.ClienteClave ")
            sConsulta.AppendLine(" and TMV.ClienteClaveId=TMP.ClienteClaveID ") '-##
            sConsulta.AppendLine(" and TMV.EsquemaId=TMP.EsquemaId) as DiasCompra, ")
            sConsulta.AppendLine("ProductoClave as ProductoClave, (select PRO.Nombre from Producto PRO where PRO.ProductoClave = TMP.ProductoClave) as Producto, ")
            sConsulta.AppendLine("sum(Factor * Cantidad) as Unidades, sum(Importe) as Importe , sum(Descuento) as Descuento, sum(Importe - Descuento) as Total, sum(TMP.TotalEnAgenda) as TotalEnAgenda, sum(TMP.TotalFueraAgenda) as TotalFueraAgenda ")
            sConsulta.AppendLine("from #TmpVentas2 TMP ")
            sConsulta.AppendLine("inner join Cliente CLI ON CLI.ClienteClave=TMP.ClienteClave ")
            sConsulta.AppendLine("group by ALNClave, ALNNombre, convert(datetime, convert(varchar(10), FechaCaptura, 112)), ")
            sConsulta.AppendLine("convert(datetime, convert(varchar(10), FechaHoraInicial, 112)), VendedorID, VENNombre, RutClave, TMP.ClienteClave, CLI.Clave, ")
            sConsulta.AppendLine("CLIRazonSocial, ESQNombre, ProductoClave, FechaCaptura, EsquemaId ")
            sConsulta.AppendLine(", ClienteClaveID ") '-##
            sConsulta.AppendLine("order by Vendedor, Ruta, CLI.Clave ")
            sConsulta.AppendLine("drop table #TmpVentas ")
            sConsulta.AppendLine("drop table #TmpVentas2 ")
            sConsulta.AppendLine("drop table #TmpVentas3 ")
            sConsulta.AppendLine("drop table #TmpVentas4 ")
            sConsulta.AppendLine("set nocount off ")

        End If
        'Session("Query") = sConsulta.ToString

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        Return True
    End Function

    Private Function ConsultaCargas(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        Dim pvCondicionCEDI As String = String.Empty
        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "FechaHoraAlta")
        End If

        pvCondicionCEDI = strWhereCentrosDistribucion(pvCondicionCEDI, "ALN.Clave")

        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("SET NOCOUNT ON if (select object_id('tempdb..#TmpCargas')) is not null drop table #TmpCargas ")
        sConsulta.AppendLine("Select CEDI = case When TipoFase = 1 Then (Select Top 1 ClaveCEDI from AgendaVendedor AGV where  AGV.DiaClave = TRP.DiaClave and VEN.USUId = TRP.MUsuarioID) Else TRP.Notas End,TRP.Folio, TipoFase, VAD.Descripcion as DescripcionFase, ")
        sConsulta.AppendLine("Convert(DateTime, Convert(varchar(20),TRP.FechaHoraAlta,112)) as FechaHoraAlta, TPD.ProductoClave,TPD.TipoUnidad,VAD2.Descripcion as TipoUnidadDes, TPD.Cantidad,USU.Clave + ' ' + VEN.Nombre as Vendedor into #TmpCargas ")
        sConsulta.AppendLine("from (Select DiaClave,TransProdID, TipoFase,Folio, Tipo, Notas, MUsuarioID, FechaHoraAlta from TransProd where Tipo=2) TRP ")
        'sConsulta.AppendLine("inner join Dia on Dia.DiaClave = TRP.DiaClave ")
        sConsulta.AppendLine("inner join  (Select TransProdID, ProductoClave,TipoUnidad,Cantidad from TransProdDetalle) TPD on TPD.TransProdID = TRP.TransProdID ")
        sConsulta.AppendLine("inner join (Select VAVClave,Descripcion from VAVDescripcion where VARCodigo ='TRPFASE' and VADTipoLenguaje = '" & Session("lenguaje") & "' ) VAD on  VAD.VAVClave = TRP.TipoFase ")
        sConsulta.AppendLine("inner join VAVDescripcion VAD2 on VAD2.VARCodigo ='UNIDADV' and VAD2.VAVClave = TPD.TipoUnidad and VAD2.VADTipoLenguaje = '" & Session("lenguaje") & "' ")
        sConsulta.AppendLine("inner join (Select VendedorID, Nombre, UsuId from Vendedor) VEN on VEN.UsuID = TRP.MUsuarioID ")
        sConsulta.AppendLine("inner join Usuario USU on USU.UsuID = TRP.MUsuarioID ")
        sConsulta.AppendLine(pvCondicion)

        sConsulta.AppendLine("Select ALN.Clave + ' ' + ALN.Nombre as CEDI, TPD.FechaHoraAlta as Fecha, TPD.ProductoClave as Clave, PRO.Nombre as Producto, ")
        sConsulta.AppendLine("TPD.TipoUnidadDes as Unidad, TPD.Cantidad, PRD.Factor as Piezas, TPD.Vendedor, TPD.Folio, TPD.TipoFase, TPD.DescripcionFase ")
        sConsulta.AppendLine("from #TmpCargas TPD ")
        sConsulta.AppendLine("inner join (Select ProductoClave, Nombre from Producto) PRO on TPD.ProductoClave = PRO.ProductoClave ")
        sConsulta.AppendLine("inner join (Select ProductoClave, PRUTipoUnidad, ProductoDetClave, Factor from ProductoDetalle) PRD on PRD.ProductoClave = PRO.ProductoClave ")
        sConsulta.AppendLine("and PRD.PRUTipoUnidad = TPD.TipoUnidad and PRD.ProductoDetClave = PRO.ProductoClave ")
        sConsulta.AppendLine("inner join Almacen ALN on ALN.Clave = CEDI ")
        sConsulta.AppendLine(pvCondicionCEDI)
        sConsulta.AppendLine("order by CEDI,Fecha,Vendedor,Folio,TPD.ProductoClave,TipoUnidad ")
        sConsulta.AppendLine(" if (select object_id('tempdb..#TmpCargas')) is not null drop table #TmpCargas SET NOCOUNT OFF ")
        'Session("Query") = sConsulta.ToString

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("SET NOCOUNT ON if (select object_id('tempdb..#TmpCargas')) is not null drop table #TmpCargas ")
        sConsulta.AppendLine("Select CEDI = case When TipoFase = 1 Then (Select Top 1 ClaveCEDI from AgendaVendedor AGV where  AGV.DiaClave = TRP.DiaClave and VEN.USUId = TRP.MUsuarioID) Else TRP.Notas End, Convert(DateTime, Convert(varchar(20),TRP.FechaHoraAlta,112)) as FechaHoraAlta, TRP.Folio, VAD.Descripcion as TipoFase, ")
        sConsulta.AppendLine("TPD.ProductoClave,TPD.TipoUnidad,VAD2.Descripcion as TipoUnidadDes, TPD.Cantidad into #TmpCargas ")
        sConsulta.AppendLine("from (Select DiaClave,TransProdID, TipoFase, Folio, Tipo, Notas, MUsuarioID, FechaHoraAlta from TransProd where Tipo=2) TRP ")
        'sConsulta.AppendLine("inner join Dia on Dia.DiaClave = TRP.DiaClave ")
        sConsulta.AppendLine("inner join  (Select TransProdID, ProductoClave,TipoUnidad,Cantidad from TransProdDetalle) TPD on TPD.TransProdID = TRP.TransProdID ")
        sConsulta.AppendLine("inner join (Select VAVClave,Descripcion from VAVDescripcion where VARCodigo ='TRPFASE' and VADTipoLenguaje = '" & Session("lenguaje") & "' ) VAD on  VAD.VAVClave = TRP.TipoFase ")
        sConsulta.AppendLine("inner join VAVDescripcion VAD2 on VAD2.VARCodigo ='UNIDADV' and VAD2.VAVClave = TPD.TipoUnidad and VAD2.VADTipoLenguaje = '" & Session("lenguaje") & "' ")
        sConsulta.AppendLine("inner join (Select VendedorID, Nombre, UsuId from Vendedor) VEN on VEN.UsuID = TRP.MUsuarioID ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine("and TipoFase <> 0 ")

        sConsulta.AppendLine("Select ALN.Clave + ' ' + ALN.Nombre as CEDI , TPD.FechaHoraAlta as Fecha,TPD.ProductoClave as Clave, PRO.Nombre as Producto, TPD.TipoUnidadDes as Unidad,sum(TPD.Cantidad) as Cantidad, PRD.Factor as Piezas ")
        sConsulta.AppendLine("from #TmpCargas TPD ")
        sConsulta.AppendLine("inner join (Select ProductoClave, Nombre from Producto) PRO on TPD.ProductoClave = PRO.ProductoClave ")
        sConsulta.AppendLine("inner join (Select ProductoClave, PRUTipoUnidad, ProductoDetClave, Factor from ProductoDetalle) PRD on PRD.ProductoClave = PRO.ProductoClave ")
        sConsulta.AppendLine("and PRD.PRUTipoUnidad = TPD.TipoUnidad and PRD.ProductoDetClave = PRO.ProductoClave ")
        sConsulta.AppendLine("inner join Almacen ALN on ALN.Clave = CEDI ")
        sConsulta.AppendLine(pvCondicionCEDI)
        sConsulta.AppendLine("group by ALN.Clave + ' ' + ALN.Nombre , TPD.FechaHoraAlta,TPD.ProductoClave, PRO.Nombre , TPD.TipoUnidadDes, PRD.Factor ")
        sConsulta.AppendLine("order by CEDI,Fecha,TPD.ProductoClave,Unidad ")
        sConsulta.AppendLine(" if (select object_id('tempdb..#TmpCargas')) is not null drop table #TmpCargas SET NOCOUNT OFF ")

        Session("Query2") = sConsulta.ToString

        Return True

    End Function

    Private Function ConsultaLiquidacion(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvClientes As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        pvCondicion = ""
        If chboxVendedor.Checked Then
            'pvCondicion = "where VENNombre = '" + ddlVendedor.Text + "' "
            pvCondicion = "where VENVendedorId = '" + ddlVendedor.Text + "' "
        Else
            pvCondicion = "where 1 = 1 "
        End If
        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, " fecha ")
        Else
            pvCondicion &= " and fecha = '" & ins.ObtenerFecha.Date.ToString("s") & "' "
        End If
        'pvCondicion = strWhereRutas(pvCondicion, pvRutas, "RUTClave")
        pvCondicion = strWhereCentrosDistribucion(pvCondicion, "ClaveCEDI")

        'If ins.EjecutarComandoScalar("select top 1 inventario from conhist order by conhistfechainicio desc") = 0 Then
        'End If



        sConsulta.Append("SET ANSI_WARNINGS OFF ")
        sConsulta.Append("SELECT ClaveCEDI, ALMNombre, USUClave, VENVendedorId, VENNombre, ProductoClave, PRDNombre, sum(Carga) as Carga, sum(Devolucion)+Sum(Reclasificado) as Devolucion, sum(Frio)-Sum(Reclasificado) as Frio, sum(Reclasificado) as Reclasificacion, ")
        sConsulta.Append("sum(Otro) as Otro, sum (DevolucionCte) * -1 as DevolucionCte, ImpDevolucionCte=(sum(DevolucionCte) * avg(ImporteUnitario)), sum(Ajuste) as Ajuste, BonificacionAjuste=(sum(BonificacionAjuste) * avg(ImporteUnitario)), ImpAjuste=(sum(Ajuste) * avg(ImporteUnitario)), sum(Venta) as Venta, sum(Importe) as Importe, sum(CharolaCarga) as CharolaCarga, sum(CharolaVacia) as CharolaVacia, ")
        sConsulta.Append("Faltantes=(sum(Carga)-sum(Devolucion)-sum(Ajuste)-sum(Venta)-sum(Otro)-sum(frio)+sum(DevolucionCte)), ")
        sConsulta.Append("ImpFaltante=((sum(Carga)-sum(Devolucion)-sum(Ajuste)-sum(Venta)-sum(Otro)-sum(frio)+sum(DevolucionCte)) * avg(ImporteUnitario)) FROM ")
        sConsulta.Append("(SELECT ClaveCEDI, ALMNombre, Fecha, DiaClave, USUClave, VENVendedorId, VENNombre, Tipo, ProductoClave, PRDNombre, Carga, Devolucion, Frio, Reclasificado, DevolucionCte, Otro=(Cambio2+Promocion-Cambio1), Ajuste,bonificacionajuste, Venta, ImporteUnitario, Importe=(SubTotal- DescCliPor -((SubTotal-DescCliPor) * DescVendPor / 100) ) + (Impuesto-DescCliPorImp-((Impuesto-DescCliPorImp) * DescVendPor / 100)), CharolaCarga, CharolaVacia FROM ")
        sConsulta.Append("(SELECT distinct TPD.TransProdId,TPD.TransProdDetalleId,AGV.ClaveCEDI, ALM.Nombre as ALMNombre, TRP.DiaClave, dia.fechacaptura AS Fecha, USU.Clave AS USUClave, VEN.VendedorId as VENVendedorId, VEN.Nombre as VENNombre, ")
        sConsulta.Append("TRP.Tipo, TPD.ProductoClave, PRD.Nombre as PRDNombre, ")
        sConsulta.Append("Carga=(SELECT CASE WHEN TRP.Tipo=2 THEN TPD.Cantidad * PDD.Factor WHEN TRP.Tipo=23 THEN TPD.Cantidad ELSE 0 END), ")
        sConsulta.Append("Devolucion=(SELECT CASE WHEN TRP.Tipo=7 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.Append("Frio=(SELECT CASE WHEN TRP.Tipo=4 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.Append("Reclasificado=(SELECT CASE WHEN TRP.Tipo=22 THEN TPD.Cantidad * PDD.Factor ELSE 0 END),")
        sConsulta.Append("Ajuste=(SELECT CASE WHEN TRP.Tipo=6 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.Append("BonificacionAjuste=(SELECT CASE WHEN TRP.Tipo=6 and trp.tipomotivo=6 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.Append("Cambio1=(SELECT CASE WHEN TRP.Tipo=9 AND TRP.TipoMovimiento=1 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.Append("Cambio2=(SELECT CASE WHEN TRP.Tipo=9 AND TRP.TipoMovimiento=2 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.Append("DevolucionCte=(SELECT CASE WHEN TRP.Tipo=3 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.Append("Promocion=(SELECT CASE WHEN TRP.Tipo=1 AND TPD.Total=0 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.Append("Venta=(SELECT CASE WHEN TRP.Tipo=1 AND TPD.Total>0 and tpd.promocion<>2 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.Append("ImporteUnitario=(SELECT Top 1 Precio FROM PrecioProductoVig AS PPV INNER JOIN Precio as PRE ON PRE.PrecioClave=PPV.PrecioClave AND PRE.TipoEstado=1 WHERE PPV.ProductoClave=TPD.ProductoClave AND PPV.PRUTipoUnidad=(SELECT TOP 1 PRD.PRUTipoUnidad FROM ProductoDetalle AS PRD WHERE PRD.ProductoClave=TPD.ProductoClave Order by PRD.Factor ASC) AND PPVFechaInicio <=dia.fechacaptura AND FechaFin >=dia.fechacaptura Order by Precio Desc), ")
        sConsulta.Append("SubTotal=(SELECT CASE WHEN TRP.Tipo=1  AND TPD.Total>0 THEN TPD.Subtotal ELSE 0 END), ")
        sConsulta.Append("DescCliPor=(SELECT CASE WHEN TRP.Tipo=1  AND TPD.Total>0 THEN (SELECT (CASE WHEN sum(DesImporte) IS NULL THEN 0 ELSE sum(DesImporte) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) ELSE 0 End), ")
        sConsulta.Append("DescVendPor=(SELECT CASE WHEN TRP.Tipo=1 AND TPD.Total>0 THEN (SELECT CASE WHEN TRP.DescVendPor IS NULL THEN 0 ELSE TRP.DescVendPor END) ELSE 0 END), ")
        sConsulta.Append("Impuesto=(SELECT CASE WHEN TRP.Tipo=1  AND TPD.Total>0 THEN (SELECT CASE WHEN TPD.Impuesto IS NULL THEN 0 ELSE TPD.Impuesto END) ELSE 0 END), ")
        sConsulta.Append("DescCliPorImp=(SELECT CASE WHEN TRP.Tipo=1  AND TPD.Total>0 THEN (SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE sum(DesImpuesto) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) ELSE 0 End), ")
        sConsulta.Append("CharolaCarga=0, CharolaVacia=0 ")
        sConsulta.Append("FROM TransProd as TRP ")
        sConsulta.Append("INNER JOIN TransProdDetalle as TPD ON TPD.TransProdId=TRP.TransProdId ")
        sConsulta.Append("INNER JOIN dia on dia.diaclave =trp.diaclave ")
        sConsulta.Append("INNER JOIN Producto as PRD ON PRD.ProductoClave=TPD.ProductoClave AND PRD.Tipo<>5 ")
        sConsulta.Append("INNER JOIN ProductoDetalle as PDD ON PDD.ProductoClave=TPD.ProductoClave AND PDD.PRUTipoUnidad=TPD.TipoUnidad AND PDD.ProductoDetClave=TPD.ProductoClave ")
        sConsulta.Append("INNER JOIN Usuario as USU ON USU.USUId=TRP.MUsuarioId ")
        sConsulta.Append("INNER JOIN Vendedor as VEN ON VEN.USUId=TRP.MUsuarioId AND VEN.TipoEstado=1 AND VEN.Baja=0 ")
        sConsulta.Append("INNER JOIN (SELECT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor GROUP BY DiaClave, VendedorId, ClaveCEDI) as AGV ON AGV.DiaClave=TRP.DiaClave AND AGV.VendedorId=VEN.VendedorId ")
        sConsulta.Append("INNER JOIN Almacen as ALM ON ALM.Clave=AGV.ClaveCEDI ")
        sConsulta.Append("WHERE TRP.Tipo IN (1,2,3,4,6,7,9,22,23) ")
        sConsulta.Append("AND TRP.TipoFase<>0 ")
        sConsulta.Append(") AS Liquidacion ")
        sConsulta.Append(") AS Liquidacion ")
        sConsulta.Append(pvCondicion)
        sConsulta.Append("GROUP BY ClaveCEDI, ALMNombre, USUClave, VENVendedorId, VENNombre, ProductoClave, PRDNombre ")
        sConsulta.Append("Order by ClaveCEDI, VENNombre ")

        'Session("Query") = sConsulta.ToString

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        sConsulta = New StringBuilder
        sConsulta.Append("SET ANSI_WARNINGS OFF ")
        sConsulta.Append("SELECT ClaveCEDI, ALMNombre, Fecha, DiaClave, USUClave, VENVendedorId, VENNombre, ProductoClave, PRDNombre, Carga=0, Devolucion=0, Frio=0, ")
        sConsulta.Append("Otro=0, DevolucionCte=0, ImpDevolucionCte=0, Ajuste=0, ImpAjuste=0, Venta=0, Importe=0, sum(CharolaCarga) as CharolaCarga, sum(CharolaVacia) as CharolaVacia, ")
        sConsulta.Append("Faltantes=0, ImpFaltante=0 FROM ")
        sConsulta.Append("(SELECT AGV.ClaveCEDI, ALM.Nombre as ALMNombre, dia.fechacaptura AS Fecha, TRP.DiaClave, USU.Clave AS USUClave, VEN.VendedorId as VENVendedorId, VEN.Nombre as VENNombre, ")
        sConsulta.Append("TRP.Tipo, TPD.ProductoClave, PRD.Nombre as PRDNombre, ")
        sConsulta.Append("CharolaCarga=(SELECT CASE WHEN (TRP.Tipo=2 AND PRD.Tipo=5) THEN TPD.Cantidad WHEN (TRP.Tipo=23) THEN TPD.Cantidad ELSE 0 END), ")
        sConsulta.Append("CharolaVacia=(SELECT CASE WHEN (TRP.Tipo IN (4,6,7) AND PRD.Tipo=5) THEN TPD.Cantidad ELSE 0 END) ")
        sConsulta.Append("FROM TransProd as TRP ")
        sConsulta.Append("INNER JOIN TransProdDetalle as TPD ON TPD.TransProdId=TRP.TransProdId ")
        sConsulta.Append("INNER JOIN dia on dia.diaclave=trp.diaclave ")
        sConsulta.Append("INNER JOIN Producto as PRD ON PRD.ProductoClave=TPD.ProductoClave AND PRD.Tipo=5 ")
        sConsulta.Append("INNER JOIN ProductoDetalle as PDD ON PDD.ProductoClave=TPD.ProductoClave AND PDD.PRUTipoUnidad=TPD.TipoUnidad AND PDD.ProductoDetClave=TPD.ProductoClave ")
        sConsulta.Append("INNER JOIN Usuario as USU ON USU.USUId=TRP.MUsuarioId ")
        sConsulta.Append("INNER JOIN Vendedor as VEN ON VEN.USUId=TRP.MUsuarioId AND VEN.TipoEstado=1 AND VEN.Baja=0 ")
        sConsulta.Append("INNER JOIN (SELECT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor GROUP BY DiaClave, VendedorId, ClaveCEDI) as AGV ON AGV.DiaClave=TRP.DiaClave AND AGV.VendedorId=VEN.VendedorId ")
        sConsulta.Append("INNER JOIN Almacen as ALM ON ALM.Clave=AGV.ClaveCEDI ")
        sConsulta.Append("WHERE TRP.Tipo IN (1,2,3,4,6,7,9,23) ")
        sConsulta.Append("AND TRP.TipoFase<>0 ")
        sConsulta.Append(") AS Liquidacion ")
        sConsulta.Append(pvCondicion)
        sConsulta.Append("GROUP BY ClaveCEDI, ALMNombre, Fecha, DiaClave, USUClave, VENVendedorId, VENNombre, ProductoClave, PRDNombre ")
        sConsulta.Append("Order by ClaveCEDI, Fecha, VENNombre ")

        Session("Query2") = sConsulta.ToString

        Session("RutasVendedor") = ""
        If ddlVendedor.Text <> "" Then
            sConsulta = New StringBuilder
            sConsulta.Append("SET ANSI_WARNINGS OFF ")
            sConsulta.Append(" select dbo.FNObtenerRutasVendedor('" & ddlVendedor.Text & "')  ")

            dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
            If dt.Rows.Count > 0 Then
                Session("RutasVendedor") = dt.Rows(0).Item(0)
            End If
        End If


        Return True
    End Function

    Private Function ConsultaLiquidacionLactigurth(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String) As Boolean
        Dim sConsulta As StringBuilder

        'Sección VentasProductos
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("Select ProductoClave, PRONombre, sum(Carga) as Cargas, sum(Ajuste) as Ajustes, sum(DevolucionAlmacen) as DevolucionesAlmacen, ")
        sConsulta.AppendLine("sum(Descargas) as Descargas,sum(Promociones) as Promociones, sum(Venta) as Ventas, sum(Precio) as Precio, sum((SubTotal- DescCliPor -((SubTotal-DescCliPor) * DescVendPor / 100) ) + (Impuesto-DescCliPorImp-((Impuesto-DescCliPorImp) * DescVendPor / 100))) as Importe ")
        sConsulta.AppendLine("from(SELECT VEN.Nombre as VENNombre,  DIA.FechaCaptura AS FechaHoraAlta, ")
        sConsulta.AppendLine("TRP.Tipo, TPD.ProductoClave, PRO.Nombre as PRONombre, ")
        sConsulta.AppendLine("Carga=(SELECT CASE WHEN TRP.Tipo=2 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Ajuste=(SELECT CASE WHEN TRP.Tipo=6 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("DevolucionAlmacen=(SELECT CASE WHEN TRP.Tipo=4 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Descargas=(SELECT CASE WHEN TRP.Tipo=7 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Promociones=(SELECT CASE WHEN trp.tipo=1 and TPD.promocion=2 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Venta=(SELECT CASE WHEN TRP.Tipo=1 AND TPD.Total>0 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Precio = (SELECT CASE WHEN TRP.Tipo=1 AND TPD.Total>0 THEN TPD.Precio * TPD.Cantidad ELSE 0 END),")
        sConsulta.AppendLine("SubTotal=(SELECT CASE WHEN TRP.Tipo=1  AND TPD.Total>0 THEN TPD.Subtotal ELSE 0 END), ")
        sConsulta.AppendLine("DescCliPor=(SELECT CASE WHEN TRP.Tipo=1  AND TPD.Total>0 THEN (SELECT (CASE WHEN sum(DesImporte) IS NULL THEN 0 ELSE sum(DesImporte) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) ELSE 0 End), ")
        sConsulta.AppendLine("DescVendPor=(SELECT CASE WHEN TRP.Tipo=1 AND TPD.Total>0 THEN (SELECT CASE WHEN TRP.DescVendPor IS NULL THEN 0 ELSE TRP.DescVendPor END) ELSE 0 END), ")
        sConsulta.AppendLine("Impuesto=(SELECT CASE WHEN TRP.Tipo=1  AND TPD.Total>0 THEN (SELECT CASE WHEN TPD.Impuesto IS NULL THEN 0 ELSE TPD.Impuesto END) ELSE 0 END), ")
        sConsulta.AppendLine("DescCliPorImp=(SELECT CASE WHEN TRP.Tipo=1  AND TPD.Total>0 THEN (SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE sum(DesImpuesto) END) ")
        sConsulta.AppendLine("FROM TpdDes AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) ELSE 0 End) ")
        sConsulta.AppendLine("FROM TransProd as TRP INNER JOIN TransProdDetalle as TPD ON TPD.TransProdId=TRP.TransProdId ")
        sConsulta.AppendLine("INNER JOIN Producto as PRO ON PRO.ProductoClave=TPD.ProductoClave ")
        sConsulta.AppendLine("INNER JOIN ProductoDetalle as PDD ON PDD.ProductoClave=TPD.ProductoClave AND PDD.PRUTipoUnidad=TPD.TipoUnidad AND PDD.PRUTipoUnidad=TPD.TipoUnidad AND PDD.ProductoDetClave=TPD.ProductoClave ")
        sConsulta.AppendLine("INNER JOIN Usuario as USU ON USU.USUId=TRP.MUsuarioId INNER JOIN Vendedor as VEN ON VEN.USUId=TRP.MUsuarioId AND VEN.TipoEstado=1 AND VEN.Baja=0 ")
        sConsulta.AppendLine("INNER JOIN Dia on TRP.DiaClave = DIA.DiaClave ")
        sConsulta.AppendLine("WHERE TRP.Tipo IN (1,2,4,6,7) AND TRP.TipoFase<>0  ")
        Dim sCondicionVentas As String = String.Empty
        If chboxVendedor.Checked Then
            'sCondicionVentas = "where VENNombre = '" + ddlVendedor.Text + "' "
            sCondicionVentas = "and VEN.VendedorId = '" + ddlVendedor.Text + "' "
        Else
            'sCondicionVentas = "where 1 = 1 "
        End If
        If chboxFecha.Checked Then
            sConsulta.AppendLine(strWhereFecha(sCondicionVentas, "DIA.FechaCaptura"))
        Else
            sConsulta.AppendLine(sCondicionVentas)
        End If
        sConsulta.AppendLine(") as Liquidacion GROUP BY ProductoClave, PRONombre order by ProductoClave ")

        Session("VentasProductos") = sConsulta.ToString
        Dim dt As Data.DataTable = ins.EjecutarConsulta(Session("VentasProductos"), IntCommandTimeOut)
        If (dt.Rows.Count = 0) Then
            Return False
        End If
        Session("subreport0") = dt
        'Sección Cobranza en Cheques
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("select TRP.Notas AS Factura,TRP.Folio, VAD.Descripcion as Banco, ABD.Referencia, convert(datetime,Convert(varchar(20),DIA.FechaCaptura,112)) as FechaAbono, sum(ABD.Importe) as Importe ")
        sConsulta.AppendLine("from Abono ABN inner join ABNDetalle ABD on ABN.ABNId = ABD.ABNId and ABD.TipoPago = 2 ")
        sConsulta.AppendLine("inner join ABNTrp ABT on ABT.ABNId = ABN.ABNId ")
        sConsulta.AppendLine("inner join TransProd TRP on TRP.TransProdId = ABT.TransProdID ")
        sConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VAVClave = ABD.TipoBanco and VARCodigo = 'TBANCO' and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' ")
        sConsulta.AppendLine("inner join Visita VIS on VIS.VisitaClave = ABN.VisitaClave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VEN.VendedorID = VIS.VendedorID ")
        sConsulta.AppendLine("INNER JOIN Dia on Dia.DiaClave = ABN.DiaClave ")
        If chboxFecha.Checked Then
            sConsulta.AppendLine(strWhereFecha(pvCondicion, "DIA.FechaCaptura"))
        Else
            sConsulta.AppendLine(pvCondicion)
        End If
        sConsulta.AppendLine("group by TRP.Folio, TRP.Notas, VAD.Descripcion, ABD.Referencia, convert(datetime,Convert(varchar(20),DIA.FechaCaptura,112)) order by TRP.Folio ")

        Session("CobranzaCheques") = sConsulta.ToString

        'Seccion Gastos Efectuados
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("Select GAS.Folio, VAD.Descripcion as Concepto, GAS.Importe, GAS.Porcentaje, GAS.Impuesto, GAS.Total ")
        sConsulta.AppendLine("from Gasto GAS inner join Vendedor VEN on GAS.VendedorID = VEN.VendedorID ")
        sConsulta.AppendLine("inner join Dia ON GAS.DiaClave = DIA.DiaClave ")
        sConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VARCodigo = 'GASTIPO' and VAD.VAVClave = GAS.TipoConcepto and VAD.VADTipoLenguaje ='" & Session("lenguaje") & "' ")
        If chboxFecha.Checked Then
            sConsulta.AppendLine(strWhereFecha(pvCondicion, "DIA.FechaCaptura"))
        Else
            sConsulta.AppendLine(pvCondicion)
        End If
        sConsulta.AppendLine("order by GAS.Folio ")
        Session("Gastos") = sConsulta.ToString

        'Seccion Creditos Otorgados
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("select TRP.Notas AS Factura, TRP.Folio, DIA.FechaCaptura as Fecha, CLI.Clave + ' ' + CLI.NombreCorto as Cliente,TRP.Total as Importe, TRP.SALDO ,CASE WHEN CLE.EsquemaID is null Then 0 ELSE 1 END as Autoservicio ")
        sConsulta.AppendLine("from TransProd TRP inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave and TRP.Tipo = 1 and TRP.TipoFase <>0 and TRP.SALDO>0 ") 'not in(")
        'sConsulta.AppendLine("Select ABT.TransProdID from ABNTrp ABT inner join abono ABN on ABN.ABNId = ABT.ABNId where ABT.TransProdID = TRP.TransProdID and ABN.DiaClave = TRP.DiaClave) ")
        sConsulta.AppendLine("inner join Cliente CLI on CLI.ClienteClave = VIS.ClienteClave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VEN.VendedorID = VIS.VendedorID ")
        sConsulta.AppendLine("left join ClienteEsquema CLE on CLI.ClienteClave = CLE.ClienteClave and CLE.EsquemaID=(Select EsquemaID from Esquema where Clave='AUTOSERV') ")
        sConsulta.AppendLine("INNER JOIN Dia on TRP.DiaClave = DIA.DiaClave ")
        If chboxFecha.Checked Then
            sConsulta.AppendLine(strWhereFecha(pvCondicion, "DIA.FechaCaptura"))
        Else
            sConsulta.AppendLine(pvCondicion)
        End If
        sConsulta.AppendLine("order by TRP.Folio ")

        Session("Creditos") = sConsulta.ToString

        'Sección Cobranza Ventas Anteriores
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("Select Notas AS Factura, Folio, FechaHoraAlta as Fecha, TRPTotal, ABNTotal,TipoPago, Referencia, sum(Importe) as Importe ")
        sConsulta.AppendLine("from(Select TRP.Notas, TRP.Folio, Dia.FechaCaptura as FechaHoraAlta, TRP.Total as TRPTotal, ")
        sConsulta.AppendLine("isnull((Select sum(ABN.Total) from Abono ABN INNER JOIN Dia ON ABN.DiaClave = DIA.DiaClave inner join ABNTrp on ABNTrp.TransProdID = TRP.TransProdID and ABNTrp.ABNId = ABN.ABNID ")
        If chboxFecha.Checked Then
            sConsulta.AppendLine(strWhereFecha("", "DIA.FechaCaptura"))
        End If
        sConsulta.AppendLine("),0) as ABNTotal, VAD.Descripcion as TipoPago, ABD.Referencia, ABD.Importe as Importe ")
        sConsulta.AppendLine("from TransProd TRP inner join ABNTrp ABT on ABT.TransProdID = TRP.TransProdID and TRP.Tipo = 1 and TRP.TipoFase <>0 ")
        sConsulta.AppendLine("inner join Abono AB on AB.ABNId = ABT.ABNId ")
        sConsulta.AppendLine("inner join ABNDetalle ABD on ABD.ABNId = AB.ABNId ")
        sConsulta.AppendLine("inner join VIsita VIS on VIS.VisitaClave = TRP.VisitaClave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VEN.VendedorID = VIS.VendedorID ")
        sConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VARCodigo ='PAGO' and ABD.TipoPago = VAD.VAVClave and VADTipoLenguaje = '" & Session("lenguaje") & "' ")
        sConsulta.AppendLine("INNER JOIN Dia Dia1 ON DIA1.DiaClave = AB.DiaClave ")
        sConsulta.AppendLine("INNER JOIN Dia ON TRP.DiaClave = DIA.DiaClave ")
        sConsulta.AppendLine(pvCondicion)
        If chboxFecha.Checked Then
            sConsulta.AppendLine(strWhereFecha("", "DIA1.FechaCaptura"))
            sConsulta.AppendLine(" and DIA.FechaCaptura<'" & FechaInicioPrimeraHora() & "'")
        Else
            sConsulta.AppendLine(" and DIA.FechaCaptura<'" & DateSerial(2900, 1, 1).ToString("s") & "'")
        End If
        sConsulta.AppendLine(") as CobranzaAnteriores group by Folio, Notas, FechaHoraAlta, TRPTotal, ABNTotal,TipoPago, Referencia order by Folio ")

        Session("CobranzaAnteriores") = sConsulta.ToString

        'DevolucionMala
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("Select case When sum(TotalDevolucion) is null Then 0 else  sum(TotalDevolucion) END as TotalDevolucion from(Select TPD.Cantidad * ")
        sConsulta.AppendLine("(Select case When max(Precio) is null then 0 else max(Precio) END from Precio PRE inner join PrecioProductoVig PPV on PRE.PrecioClave = PPV.PrecioClave where PRE.TipoEstado = 1 and PPV.TipoEstado = 1 and TPD.ProductoClave = PPV.ProductoClave ")
        sConsulta.AppendLine("and TPD.TipoUnidad = PPV.PRUTipoUnidad and (TRP.FechaHoraAlta between PPV.PPVFechaInicio and PPV.FechaFin) ) as TotalDevolucion ")
        sConsulta.AppendLine("from TransProd TRP inner join TransProdDEtalle TPD on TPD.TransProdID = TRP.TransProdId and TRP.Tipo = 4 and TRP.TipoFase<>0 inner join Vendedor VEN on VEN.UsuId = TRP.MUsuarioID and VEN.TipoEstado = 1 and VEN.Baja = 0 ")
        sConsulta.AppendLine("INNER JOIN Dia ON TRP.DiaClave = DIA.DiaClave ")
        If chboxFecha.Checked Then
            sConsulta.AppendLine(strWhereFecha(pvCondicion, "DIA.FechaCaptura"))
        Else
            sConsulta.AppendLine(pvCondicion)
        End If
        sConsulta.AppendLine(") as DevolucionMala")

        Session("DevolucionMala") = sConsulta.ToString

        'Degustacion
        Session("Degustacion") = Me.txtDegustacion.Text

        'Cheques Devueltos
        Session("ChequesDevueltos") = Me.txtChequesDevueltos.Text

        'Efectivo
        If chboxFecha.Checked Then
            Session("TotalEfectivo") = "Select  CASE When sum(ABD.Importe) is null Then 0 Else sum(ABD.Importe) END as Importe from Abono ABN inner join ABNDetalle ABD on ABN.ABNId = ABD.ABNId and ABD.TipoPago<>2 inner join Visita VIS on VIS.VisitaClave = ABN.VisitaClave inner join Vendedor VEN on VEN.VendedorID = VIS.VendedorID INNER JOIN Dia on Dia.DiaClave = ABN.DiaClave " & strWhereFecha(pvCondicion, "DIA.FechaCaptura")
        Else
            Session("TotalEfectivo") = "Select  CASE When sum(ABD.Importe) is null Then 0 Else sum(ABD.Importe) END as Importe from Abono ABN inner join ABNDetalle ABD on ABN.ABNId = ABD.ABNId and ABD.TipoPago<>2 inner join Visita VIS on VIS.VisitaClave = ABN.VisitaClave inner join Vendedor VEN on VEN.VendedorID = VIS.VendedorID " & pvCondicion
        End If

        ''TotalCalculoComision
        'If chboxFecha.Checked Then
        '    Session("TotalCalculoComision") = "Select  CASE When sum(ABD.Importe) is null Then 0 Else sum(ABD.Importe) END as Importe from Abono ABN inner join ABNDetalle ABD on ABN.ABNId = ABD.ABNId inner join Visita VIS on VIS.VisitaClave = ABN.VisitaClave inner join Vendedor VEN on VEN.VendedorID = VIS.VendedorID INNER JOIN Dia on Dia.DiaClave = ABN.DiaClave " & strWhereFecha(pvCondicion, "DIA.FechaCaptura")
        'Else
        '    Session("TotalCalculoComision") = "Select  CASE When sum(ABD.Importe) is null Then 0 Else sum(ABD.Importe) END as Importe from Abono ABN inner join ABNDetalle ABD on ABN.ABNId = ABD.ABNId inner join Visita VIS on VIS.VisitaClave = ABN.VisitaClave inner join Vendedor VEN on VEN.VendedorID = VIS.VendedorID " & pvCondicion
        'End If

        'PorcentajeComision
        Session("PorcentajeComision") = Me.txtComision.Text

        Return True
    End Function

    Private Function ConsultaMovSinInSinVis(ByVal ins As DBConexion.cConexionSQL) As Boolean
        Dim sConsulta As New StringBuilder
        Dim pvCondicion As String = ""
        If chboxFecha.Checked Then
            pvCondicion = strWhereFecha(pvCondicion, "TP.FechaHoraAlta ")
        End If
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("select A.ClaveCEDI + ' ' + ALM.Nombre as ClaveCEDI,TP.Folio, TP.DiaClave,USR.Clave + ' ' + V.Nombre as VendedorId,  ")
        sConsulta.AppendLine("TPD.ProductoClave, P.Nombre, TU.Descripcion, ")
        sConsulta.AppendLine("TPD.Cantidad ,(TPD.Cantidad* PD.FactoR)as cantTotal ")
        sConsulta.AppendLine("from transprod TP ")
        sConsulta.AppendLine("inner join transproddetalle TPD on TPD.TransProdId = TP.TransProdId ")
        sConsulta.AppendLine("inner join vendedor V on V.USUId = TP.MUsuarioId ")
        sConsulta.AppendLine("inner join Usuario USR on USR.USUId = V.USUId ")
        sConsulta.AppendLine("inner join (Select distinct ClaveCEDI,VendedorID, DiaCLave FROM AgendaVendedor) A on A.VendedorID =V.VendedorId AND A.DiaCLave = TP.DiaCLave ")
        sConsulta.AppendLine("inner join Dia D on D.DiaClave = TP.DiaCLave ")
        sConsulta.AppendLine("inner join producto P on P.ProductoClave = TPD.ProductoClave ")
        sConsulta.AppendLine("inner join productodetalle PD on PD.ProductoClave = TPD.ProductoClave  and PD.ProductoDetClave = TPD.ProductoClave and PD.PRUTipoUnidad = TPD.TipoUnidad ")
        sConsulta.AppendLine("inner join VAVDescripcion  TU on varcodigo = 'unidadv' and VAVClave = TPD.TipoUnidad and VADTipoLenguaje= '" & Session("lenguaje") & "' ")
        sConsulta.AppendLine("inner join almacen ALM on ALM.Clave = A.ClaveCEDI ")

        If chboxVendedor.Checked Then
            'sConsulta.AppendLine(" where V.Nombre = '" + ddlVendedor.SelectedValue + "'")
            sConsulta.AppendLine(" where V.VendedorId = '" + ddlVendedor.SelectedValue + "'")
        Else
            sConsulta.AppendLine(" where 1 = 1 ")
        End If
        If pvCondicion.Trim().Length > 0 Then
            sConsulta.AppendLine(pvCondicion)
        End If
        If ChBoxCentroDistribucion.Checked Then
            sConsulta.AppendLine(" AND A.ClaveCEDI =  '" + DdlCentroDistribucion.SelectedValue + "'")
        End If
        sConsulta.AppendLine(" AND TP.Tipo = 19 ")
        'Session("Query") = sConsulta.ToString()



        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        Return True
    End Function

    Private Function ConsultaMovSinInEnVis(ByVal ins As DBConexion.cConexionSQL, ByVal pvDetallado As Boolean, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvClientes As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        Dim sCondicionALN As String = ""
        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "TRP.FechaHoraAlta")
        End If
        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "VIS.RUTClave")
        pvCondicion = strWhereClientes(pvCondicion, pvClientes, "CLI.ClienteClave")
        If (ChBoxCentroDistribucion.Checked) Then
            sCondicionALN = "where ALN.Clave = '" + DdlCentroDistribucion.SelectedValue + "' "
        End If

        If pvDetallado Then
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF set nocount on  ")

            sConsulta.AppendLine("IF (SELECT     object_id('tempdb..#Temp1')) IS NOT NULL DROP TABLE #Temp1 ")
            sConsulta.AppendLine("SELECT * INTO #Temp1 ")
            sConsulta.AppendLine("FROM         (SELECT     TRP.TransProdID, TPD.Transproddetalleid, TRP.DiaClave, TRP.FechaCaptura, TRP.Folio, (CASE WHEN TRP.DescVendPor IS NULL  ")
            sConsulta.AppendLine("THEN 0 ELSE TRP.DescVendPor END) AS DescVendPor, ")
            sConsulta.AppendLine("TRP.ClienteClave, TPD.ProductoClave, TPD.Precio, TPD.Cantidad,TPD.Cantidad*PD.FACTOR AS CANTUNI, (CASE WHEN TPD.DescuentoImp IS NULL  ")
            sConsulta.AppendLine("THEN 0 ELSE TPD.DescuentoImp END) AS DescProducto, TPD.Precio * TPD.Cantidad AS TPDSubTotal, ")
            sConsulta.AppendLine("isnull((SELECT     SUM(DesImporte)  ")
            sConsulta.AppendLine("FROM          TpdDes AS TDD ")
            sConsulta.AppendLine("WHERE      TDD.TransProdId = TRP.TransProdId AND TDD.TransProdDetalleId = TPD.TransProdDetalleId),0) AS DescuentoCliente, ")
            sConsulta.AppendLine("isnull(TPD.Impuesto - ((TPD.Impuesto-isnull((SELECT     SUM(DesImpuesto) FROM          TpdDes AS TDD WHERE      TDD.TransProdId = TRP.TransProdId AND TDD.TransProdDetalleId = TPD.TransProdDetalleId),0)) * TRP.DescVendPor/100) - ")
            sConsulta.AppendLine("isnull((SELECT     SUM(DesImpuesto) ")
            sConsulta.AppendLine("FROM          TpdDes AS TDD ")
            sConsulta.AppendLine("WHERE      TDD.TransProdId = TRP.TransProdId AND TDD.TransProdDetalleId = TPD.TransProdDetalleId),0), 0) AS Impuesto, ")
            sConsulta.AppendLine("TPD.TipoUnidad, PRO.Nombre AS PRONombre, (CASE WHEN TPD.promocion = 2 THEN '*' ELSE '' END) AS promocion, VAD.Descripcion as unidad ")
            sConsulta.AppendLine("FROM          TransProd TRP INNER JOIN ")
            sConsulta.AppendLine("TransProdDetalle TPD ON TRP.TransProdID = TPD.TransProdID INNER JOIN ")
            sConsulta.AppendLine("Producto PRO ON TPD.ProductoClave = PRO.ProductoClave INNER JOIN ")
            sConsulta.AppendLine("productodetalle PD on PD.productoclave = TPD.Productoclave and PD.PRUTipounidad = TPD.tipounidad inner join ")
            sConsulta.AppendLine("VAVDescripcion VAD ON TPD.TipoUnidad = VAD.VAVClave AND (VAD.VARCodigo = 'UNIDADV') AND (VAD.VADTipoLenguaje = '" & Session("lenguaje") & "') ")
            sConsulta.AppendLine("WHERE     (TRP.Tipo = 21) AND (TRP.TipoFase <> 0) ")
            If pvFecha Then
                sConsulta.AppendLine(strWhereFecha("", "TRP.FechaHoraAlta"))
            End If
            sConsulta.AppendLine(" ) t1 ")

            sConsulta.AppendLine("IF (SELECT     object_id('tempdb..#Temp2')) IS NOT NULL DROP TABLE #Temp2 ")
            sConsulta.AppendLine("SELECT     * INTO            #Temp2 ")
            sConsulta.AppendLine("FROM         (SELECT DISTINCT  ")
            sConsulta.AppendLine("TRP.TransProdID, TRP.DiaClave, VEN.Nombre AS vendedor, VEN.VendedorID, VIS.RUTClave, CLI.Clave + ' ' + CLI.NombreCorto as RazonSocial,  ")
            sConsulta.AppendLine("AGV.ClaveCEDI, AGV.ClaveCEDI AS ALNClave, TRP.FechaCaptura, TRP.Folio, ")
            sConsulta.AppendLine("(SELECT     ALN.Nombre ")
            sConsulta.AppendLine("FROM          Almacen ALN ")
            sConsulta.AppendLine("WHERE      AGV.ClaveCEDI = ALN.Clave) AS ALNNombre, ")
            sConsulta.AppendLine("(SELECT     RUT.Descripcion ")
            sConsulta.AppendLine("FROM          Ruta RUT ")
            sConsulta.AppendLine("WHERE      VIS.RUTClave = RUT.RUTClave) AS RUTDescripcion ")
            sConsulta.AppendLine("FROM          TransProd TRP INNER JOIN ")
            sConsulta.AppendLine("AgendaVendedor AGV ON TRP.DiaClave = AGV.DiaClave INNER JOIN ")
            sConsulta.AppendLine("Vendedor VEN ON AGV.VendedorId = VEN.VendedorID INNER JOIN ")
            sConsulta.AppendLine("Visita VIS ON TRP.VisitaClave = VIS.VisitaClave AND VEN.VendedorID = VIS.VendedorID INNER JOIN ")
            sConsulta.AppendLine("Cliente CLI ON TRP.ClienteClave = CLI.ClienteClave ")
            If pvCondicion = String.Empty Then
                sConsulta.AppendLine(sCondicionALN)
            Else
                sConsulta.AppendLine(pvCondicion)
                If (ChBoxCentroDistribucion.Checked) Then
                    sConsulta.AppendLine(" AND AGV.ClaveCEDI = '" + DdlCentroDistribucion.SelectedValue + "' ")
                End If
            End If
            sConsulta.AppendLine(" AND (TRP.Tipo = 21) AND (TRP.TipoFase <> 0) )t2 ")

            sConsulta.AppendLine("SELECT  Distinct #Temp2.Transprodid, Transproddetalleid, #Temp2.FechaCaptura AS Fecha, vendedor, RUTClave + ' ' + RUTDescripcion AS Ruta,  ")
            sConsulta.AppendLine("#Temp2.Folio, RazonSocial AS Cliente, ProductoClave AS Clave, PRONombre AS Producto, Unidad,  ")
            sConsulta.AppendLine("Precio AS PrecioU, ALNClave + ' ' + ALNNombre AS CEDI, Cantidad AS Cant,CANTUNI, TPDSubTotal AS SubTotal,  ")
            sConsulta.AppendLine("DescProducto, DescuentoCliente, (TPDSubTotal - DescProducto - DescuentoCliente ) * DescVendPor / 100 AS DescVend,  ")
            sConsulta.AppendLine("Impuesto, (TPDSubTotal - DescProducto - DescuentoCliente - ((TPDSubTotal- DescProducto - DescuentoCliente ) * DescVendPor / 100) + Impuesto) AS Total,  ")
            sConsulta.AppendLine("promocion ")
            sConsulta.AppendLine("FROM         #Temp1 RIGHT OUTER JOIN ")
            sConsulta.AppendLine("#Temp2 ON #temp1.Transprodid = #temp2.TransProdId ")

            sConsulta.AppendLine("DROP TABLE #Temp1 ")
            sConsulta.AppendLine("DROP TABLE #Temp2 ")
            sConsulta.AppendLine("set nocount OFF ")

        Else
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("set nocount on ")
            sConsulta.AppendLine("if (select object_id('tempdb..#Tmp1')) is not null drop table #Tmp1 ")
            sConsulta.AppendLine("select * into #Tmp1 from( ")
            sConsulta.AppendLine("select TRP.TransProdId, TRP.FechaCaptura, TRP.Folio, TRP.Total, TRP.DiaClave, CLI.NombreCorto as CLIRazonSocial, CLI.Clave as CLIClave, ")
            sConsulta.AppendLine("VEN.Nombre as VENNombre, VEN.VendedorID, RUT.RutClave, RUT.Descripcion as RUTDescripcion ")
            sConsulta.AppendLine("from TransProd TRP ")
            sConsulta.AppendLine("inner join Cliente CLI on CLI.ClienteClave = TRP.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on VIS.RUTClave = RUT.RUTClave ")
            sConsulta.AppendLine(pvCondicion & " and TRP.Tipo = 21 and TRP.TipoFase <> 0 ")
            sConsulta.AppendLine(")as t1 ")
            sConsulta.AppendLine("if (select object_id('tempdb..#Tmp2')) is not null drop table #Tmp2 ")
            sConsulta.AppendLine("select * into #Tmp2 from( ")
            sConsulta.AppendLine("select TMP.TransProdId, TMP.FechaCaptura, TMP.Folio, TMP.Total, TMP.DiaClave, TMP.CLIRazonSocial, TMP.CLIClave, TMP.VENNombre, ")
            sConsulta.AppendLine("TMP.VendedorID, TMP.RutClave, TMP.RUTDescripcion, ALN.Clave as ALNClave, ALN.Nombre as ALNNombre ")
            sConsulta.AppendLine("from #Tmp1 TMP ")
            sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI from AgendaVendedor) AGV on TMP.DiaClave = AGV.DiaClave and TMP.VendedorId = AGV.VendedorId ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine(sCondicionALN & ")as t2 ")
            sConsulta.AppendLine("select distinct TransProdId, FechaCaptura as Fecha, VENNombre as Vendedor, RutClave + ' ' + RUTDescripcion as Ruta, ")
            sConsulta.AppendLine("Folio, CLIRazonSocial as Cliente, CLIClave as Clave, ALNClave + ' ' + ALNNombre as CEDI, Total ")
            sConsulta.AppendLine("from #Tmp2  ")
            sConsulta.AppendLine("drop table #Tmp1 ")
            sConsulta.AppendLine("drop table #Tmp2 ")
            sConsulta.AppendLine("set nocount off ")
        End If
        'Session("Query") = sConsulta.ToSing()

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        'Query 2
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")

        sConsulta.AppendLine("SELECT     * ")
        sConsulta.AppendLine("FROM         (SELECT     CEDI, Clave, Producto, Unidad, SUM(Cantidad) AS CantidadTotal,SUM(Cantuni) AS Cantuni, SUM(Total) AS Total, SUM(prom) AS promocion, SUM(cant)  ")
        sConsulta.AppendLine("AS cantidad ")
        sConsulta.AppendLine("FROM          (SELECT  DISTINCT   Transprodid, Transproddetalleid, ClienteClave, (ALNClave + ' ' + ALNNombre) AS CEDI, ProductoClave AS Clave, PRONombre AS Producto, Unidad, Cantidad,CantUni,  ")
        sConsulta.AppendLine("isnull((TPDTotal),0) AS Total, CASE WHEN promocion = 2 THEN cantidad ELSE 0 END AS prom,  ")
        sConsulta.AppendLine("CASE WHEN promocion <> 2 THEN cantidad ELSE 0 END AS cant ")
        sConsulta.AppendLine("FROM          (SELECT   Transprodid, Transproddetalleid, TMP.ProductoClave, TMP.Cantidad,tmp.cantuni, ")
        sConsulta.AppendLine("(SubTotal - DescuentoCliente - DescProducto - ((SubTotal- DescProducto - DescuentoCliente ) * DescVendPor / 100) + TDDImpuesto) AS TPDTotal, ")

        sConsulta.AppendLine("TMP.DescVendPor, TMP.DiaClave, TMP.ClienteClave, ")
        sConsulta.AppendLine("TMP.PRONombre, TMP.Unidad, TMP.VendedorId, ALNClave, ALNNombre, TMP.Promocion ")
        sConsulta.AppendLine("FROM          (SELECT   TRP.Transprodid, TPD.Transproddetalleid,  TPD.ProductoClave, TPD.Cantidad,tpd.cantidad*pd.factor as cantuni, TRP.DescVendPor, TPD.Precio *TPD.cantidad as subtotal, ")
        sConsulta.AppendLine("TPD.DescuentoImp as DescProducto, ")
        sConsulta.AppendLine("isnull((SELECT     SUM(DesImporte) FROM TpdDes AS TDD ")
        sConsulta.AppendLine("WHERE     TDD.TransProdId = TRP.TransProdId AND TDD.TransProdDetalleId = TPD.TransProdDetalleId), 0)  ")
        sConsulta.AppendLine("AS DescuentoCliente,  ")
        sConsulta.AppendLine("isnull(TPD.Impuesto -  ((TPD.Impuesto-isnull((SELECT     SUM(DesImpuesto) FROM          TpdDes AS TDD WHERE      TDD.TransProdId = TRP.TransProdId AND TDD.TransProdDetalleId = TPD.TransProdDetalleId),0)) * TRP.DescVendPor/100) - ")
        sConsulta.AppendLine("isnull((SELECT     SUM(DesImpuesto) FROM TpdDes AS TDD ")
        sConsulta.AppendLine("WHERE     TDD.TransProdId = TRP.TransProdId AND TDD.TransProdDetalleId = TPD.TransProdDetalleId), 0), 0) AS TDDImpuesto, ")

        sConsulta.AppendLine("TRP.DiaClave, TRP.ClienteClave, PRO.Nombre AS PRONombre,  ")
        sConsulta.AppendLine("VAD.Descripcion AS Unidad, VEN.VendedorId, (case when TPD.Promocion is null then 0 else tpd.promocion end) as Promocion, ")
        sConsulta.AppendLine("(SELECT     TOP 1 ALN.Nombre ")
        sConsulta.AppendLine("FROM          Almacen ALN INNER JOIN ")
        sConsulta.AppendLine("AgendaVendedor AGV ON ALN.Clave = AGV.ClaveCEDI ")
        If sCondicionALN = "" Then
            sConsulta.AppendLine("WHERE (AGV.DiaClave = TRP.DiaClave And AGV.VendedorId = VEN.VendedorID)) AS ALNNombre, ")
        Else
            sConsulta.AppendLine(sCondicionALN & " AND (AGV.DiaClave = TRP.DiaClave And AGV.VendedorId = VEN.VendedorID)) AS ALNNombre, ")
        End If
        sConsulta.AppendLine("(SELECT     TOP 1 ALN.Clave ")
        sConsulta.AppendLine("FROM          Almacen ALN INNER JOIN ")
        sConsulta.AppendLine("AgendaVendedor AGV ON ALN.Clave = AGV.ClaveCEDI ")
        If sCondicionALN = "" Then
            sConsulta.AppendLine("WHERE (AGV.DiaClave = TRP.DiaClave And AGV.VendedorId = VEN.VendedorID) ) AS ALNClave  ")
        Else
            sConsulta.AppendLine(sCondicionALN & " AND (AGV.DiaClave = TRP.DiaClave And AGV.VendedorId = VEN.VendedorID) ) AS ALNClave  ")
        End If
        sConsulta.AppendLine("FROM          TransProdDetalle TPD INNER JOIN ")
        sConsulta.AppendLine("TransProd TRP ON TRP.TransProdId = TPD.TransProdId INNER JOIN ")
        sConsulta.AppendLine("Producto PRO ON TPD.ProductoClave = PRO.ProductoClave INNER JOIN ")
        sConsulta.AppendLine("productodetalle PD on PD.productoclave = TPD.Productoclave and PD.PRUTipounidad = TPD.tipounidad inner join ")
        sConsulta.AppendLine("VAVDescripcion VAD ON VAD.VARCodigo = 'UNIDADV' AND VAD.VAVClave = TPD.TipoUnidad AND  ")
        sConsulta.AppendLine("VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' INNER JOIN ")
        sConsulta.AppendLine("Visita VIS ON VIS.VisitaClave = TRP.VisitaClave INNER JOIN ")
        sConsulta.AppendLine("Cliente CLI ON CLI.ClienteClave = TRP.ClienteClave INNER JOIN ")
        sConsulta.AppendLine("Vendedor VEN ON VIS.VendedorId = VEN.VendedorId INNER JOIN ")
        sConsulta.AppendLine("Ruta RUT ON VIS.RUTClave = RUT.RUTClave ")
        sConsulta.AppendLine(pvCondicion & "AND TRP.Tipo = 21 AND TRP.TipoFase <> 0 ")
        sConsulta.AppendLine(") AS TMP)  AS t3) AS t1 ")
        sConsulta.AppendLine("GROUP BY CEDI, Clave, Producto, Unidad) t4 ")

        sConsulta.AppendLine("set nocount off ")

        Session("Query2") = sConsulta.ToString

        Return True
    End Function

    Private Function ConsultaProduccion(ByVal ins As DBConexion.cConexionSQL) As Boolean
        Dim sConsulta As New StringBuilder
        Dim pvCondicion As String = ""
        If chboxFecha.Checked Then
            pvCondicion = strWhereFecha(pvCondicion, "D.FechaCaptura ")
        Else
            pvCondicion = " and convert(datetime,Convert(varchar(20),D.FechaCaptura,112)) = '" & System.DateTime.Now.Date.ToString("s") & "' "
        End If
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("select TPD.ProductoClave,TU.Descripcion ,P.Nombre,(TPD.Cantidad*PD.Factor) as Unidad, ")
        sConsulta.AppendLine("P.CantidadProduccion,PD2.Factor as FactorUnidadProduccion, D.Fechacaptura, (A.ClaveCEDI+' ' + ALM.Nombre) as ClaveCEDI, ")
        sConsulta.AppendLine("case P.CantidadProduccion when 0 then 0 else ((TPD.Cantidad * PD.Factor)/PD2.Factor)/(P.CantidadProduccion) end   as ReqMasa  ")
        sConsulta.AppendLine("from transprod TP ")
        sConsulta.AppendLine("inner join transproddetalle TPD on TPD.TransProdID = TP.TransProdID ")
        sConsulta.AppendLine("inner join usuario U on u.usuid=tp.musuarioid inner join vendedor v on U.USUId = V.usuID ")
        sConsulta.AppendLine("inner join Dia D on D.DiaClave = TP.DiaCLave ")
        sConsulta.AppendLine("inner join (Select distinct ClaveCEDI, DiaCLave,vendedorid FROM AgendaVendedor) A on A.DiaCLave = TP.DiaCLave and a.vendedorid=v.vendedorid ")
        sConsulta.AppendLine("inner join producto P on P.Productoclave = TPD.Productoclave ")
        sConsulta.AppendLine("left join VAVDescripcion  TU on varcodigo = 'unidadv' and VAVClave = P.UnidadProduccion and VADTipoLenguaje= '" & Session("lenguaje") & "' ")
        sConsulta.AppendLine("inner join productodetalle PD on PD.productoclave = TPD.Productoclave and PD.PRUTipounidad = TPD.tipounidad ")
        sConsulta.AppendLine("left join productodetalle PD2 on PD2.productoclave = TPD.Productoclave and PD2.PRUTipounidad = P.unidadProduccion ")
        sConsulta.AppendLine("inner join almacen ALM on ALM.clave = A.ClaveCEDI")
        sConsulta.AppendLine(" where tp.tipo = 2 ")
        If chboxVendedor.Checked Then
            'sConsulta.AppendLine(" AND V.Nombre = '" + ddlVendedor.SelectedValue + "'")
            sConsulta.AppendLine(" AND V.VendedorId = '" + ddlVendedor.SelectedValue + "'")
        End If
        If pvCondicion.Trim().Length > 0 Then
            sConsulta.AppendLine(pvCondicion)
        End If
        If ChBoxCentroDistribucion.Checked Then
            sConsulta.AppendLine(" AND A.ClaveCEDI =  '" + DdlCentroDistribucion.SelectedValue + "'")
        End If

        'Session("Query") = sConsulta.ToString()

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        Return True
    End Function

    Private Function ConsultaEncuesta(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvClientes As ArrayList) As Boolean
        Dim sConsulta As New StringBuilder


        pvCondicion = strWhereClientes(pvCondicion, pvClientes, "CL.ClienteClave")
        If chboxFecha.Checked Then pvCondicion = strWhereFecha(pvCondicion, "EN.HoraInicio")

        If ChBoxCentroDistribucion.Checked Then pvCondicion = strWhereCentrosDistribucion(pvCondicion, "cedi.clave")
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("SELECT rut.descripcion as ruta,ven.nombre as vendedor,cedi.clave+' '+cedi.nombre as cedi,VS.ClienteClave, CL.Clave, CL.NombreCorto, CE.CENClave, CE.Descripcion as DescripcionEncuesta, EN.HoraInicio, EN.HoraFin, ")
        sConsulta.AppendLine("Tipo=(SELECT Descripcion FROM VAVDescripcion WHERE VARCodigo = 'TENC' and VAVClave = cast(CE.Tipo as VarChar(20)) and VADTipoLenguaje = '" & Session("lenguaje") & "'), ")
        sConsulta.AppendLine("Fase=(SELECT Descripcion FROM VAVDescripcion WHERE VARCodigo = 'ENCFASE' and VAVClave = cast(EN.Fase as VarChar(20)) and VADTipoLenguaje = '" & Session("lenguaje") & "'), ")
        sConsulta.AppendLine("EN.ENCId ")
        sConsulta.AppendLine("FROM Visita  VS ")
        sConsulta.AppendLine("inner join  Cliente as CL on CL.ClienteClave = VS.ClienteClave ")
        sConsulta.AppendLine("inner join Encuesta as EN on EN.VisitaClave=VS.VisitaClave AND EN.DiaClave=VS.DiaClave ")
        sConsulta.AppendLine("inner join  ConfigEncuesta as CE on CE.CENClave=EN.CENClave ")
        sConsulta.AppendLine("inner join  ruta as rut on rut.rutclave=vs.rutclave ")
        sConsulta.AppendLine("inner join  vendedor as ven on ven.vendedorid= VS.vendedorid ")
        sConsulta.AppendLine("inner join  agendavendedor as ag on ag.vendedorid = ven.vendedorid and ag.diaclave=vs.diaclave and  ag.clienteclave=vs.clienteclave ")
        sConsulta.AppendLine("inner join  almacen as cedi on ag.clavecedi=cedi.clave ")

        'sConsulta.AppendLine("FROM Visita AS VS, Cliente as CL, Encuesta as EN, ConfigEncuesta as CE ")
        'sConsulta.AppendLine("WHERE(CL.ClienteClave = VS.ClienteClave) ")
        'sConsulta.AppendLine("AND EN.VisitaClave=VS.VisitaClave AND EN.DiaClave=VS.DiaClave ")
        'sConsulta.AppendLine("AND CE.CENClave=EN.CENClave ")
        ''sConsulta.AppendLine("AND VS.ClienteClave like  @pvClienteClave ")
        sConsulta.AppendLine(pvCondicion)

        'Session("Query") = sConsulta.ToString

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        pvCondicion = pvCondicion.Replace("where", " and ")
        sConsulta = New StringBuilder

        '---------------------------RESPUESTAS DE TEXTO---------------------------------
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("SELECT * FROM ( ")
        sConsulta.AppendLine("SELECT ET.ENCId, ET.ENPId, CP.CEPNumero, EP.OrdenAplicacion, ")
        sConsulta.AppendLine("(CASE WHEN (SELECT CEP.TipoRespuesta FROM ENCPregunta ENP ")
        sConsulta.AppendLine("INNER JOIN CENPregunta CEP ON CEP.CENClave=ENP.CENClave AND CEP.CEPNumero=ENP.CEPNumero ")
        sConsulta.AppendLine("WHERE ENP.ENCId=EN.ENCId AND ENP.CENClave=CP.CENClave AND ENP.OrdenAplicacion=EP.OrdenAplicacion-1)= 7 THEN ")
        sConsulta.AppendLine("(SELECT ENP.CEPNumero FROM ENCPregunta ENP ")
        sConsulta.AppendLine("WHERE ENP.ENCId=EN.ENCId AND ENP.CENClave=EP.CENClave AND ENP.OrdenAplicacion=EP.OrdenAplicacion-1) ELSE NULL END) as PreguntaAnterior, ")
        sConsulta.AppendLine("TipoRespuesta=(SELECT Descripcion FROM VAVDescripcion WHERE VARCodigo = 'TENCR' and VAVClave = cast(CP.TipoRespuesta as VarChar(20)) and VADTipoLenguaje = '" & Session("lenguaje") & "'), ")
        sConsulta.AppendLine("TipoOperador=NULL,TipoCondicion=NULL, CP.Descripcion as DescripcionPregunta, NULL as Valor, ET.Descripcion as Respuesta, NULL as Imagen ")
        sConsulta.AppendLine("FROM Visita VS ")
        sConsulta.AppendLine("INNER JOIN Encuesta EN ON EN.VisitaClave = VS.VisitaClave And EN.DiaClave = VS.DiaClave ")
        sConsulta.AppendLine("INNER JOIN ENCPregunta EP ON EP.ENCId=EN.ENCId ")
        sConsulta.AppendLine("INNER JOIN CENPregunta CP ON CP.CENClave=EP.CENClave AND CP.CEPNumero=EP.CEPNumero ")
        sConsulta.AppendLine("LEFT JOIN ENPRespTexto ET ON ET.ENCId=EP.ENCId AND ET.ENPId=EP.ENPId ")
        sConsulta.AppendLine("INNER JOIN Cliente CL ON CL.ClienteClave=VS.ClienteClave ")
        sConsulta.AppendLine("inner join  ruta as rut on rut.rutclave=vs.rutclave ")
        sConsulta.AppendLine("inner join  vendedor as ven on ven.vendedorid= VS.vendedorid ")
        sConsulta.AppendLine("inner join  agendavendedor as ag on ag.vendedorid = ven.vendedorid and ag.diaclave=vs.diaclave and  ag.clienteclave=vs.clienteclave ")
        sConsulta.AppendLine("inner join  almacen as cedi on ag.clavecedi=cedi.clave")
        sConsulta.AppendLine(" WHERE CP.TipoRespuesta = 1 ")
        'sConsulta.AppendLine("AND VS.ClienteClave like  @pvClienteClave ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine(" UNION ALL ")

        '---------------------------RESPUESTAS NUMERICA---------------------------------
        sConsulta.AppendLine("SELECT EU.ENCId, EU.ENPId, CP.CEPNumero, EP.OrdenAplicacion, ")
        sConsulta.AppendLine("(CASE WHEN (SELECT CEP.TipoRespuesta FROM ENCPregunta ENP ")
        sConsulta.AppendLine("INNER JOIN CENPregunta CEP ON CEP.CENClave=ENP.CENClave AND CEP.CEPNumero=ENP.CEPNumero ")
        sConsulta.AppendLine("WHERE ENP.ENCId=EN.ENCId AND ENP.CENClave=CP.CENClave AND ENP.OrdenAplicacion=EP.OrdenAplicacion-1)= 7 THEN ")
        sConsulta.AppendLine("(SELECT ENP.CEPNumero FROM ENCPregunta ENP ")
        sConsulta.AppendLine("WHERE ENP.ENCId=EN.ENCId AND ENP.CENClave=EP.CENClave AND ENP.OrdenAplicacion=EP.OrdenAplicacion-1) ELSE NULL END) as PreguntaAnterior, ")
        sConsulta.AppendLine("TipoRespuesta=(SELECT Descripcion FROM VAVDescripcion WHERE VARCodigo = 'TENCR' and VAVClave = cast(CP.TipoRespuesta as VarChar(20)) and VADTipoLenguaje = '" & Session("lenguaje") & "'), ")
        sConsulta.AppendLine("TipoOperador=NULL,TipoCondicion=NULL, CP.Descripcion as DescripcionPregunta, convert(varchar(100),EU.Valor) as Valor, '' as Respuesta, NULL as Imagen ")
        sConsulta.AppendLine("FROM Visita VS ")
        sConsulta.AppendLine("INNER JOIN Encuesta EN ON EN.VisitaClave = VS.VisitaClave And EN.DiaClave = VS.DiaClave ")
        sConsulta.AppendLine("INNER JOIN ENCPregunta EP ON EP.ENCId=EN.ENCId ")
        sConsulta.AppendLine("INNER JOIN CENPregunta CP ON CP.CENClave=EP.CENClave AND CP.CEPNumero=EP.CEPNumero ")
        sConsulta.AppendLine("LEFT JOIN ENPRespNumero EU ON EU.ENCId=EP.ENCId AND EU.ENPId=EP.ENPId ")
        sConsulta.AppendLine("INNER JOIN Cliente CL ON CL.ClienteClave=VS.ClienteClave ")
        sConsulta.AppendLine("inner join  ruta as rut on rut.rutclave=vs.rutclave ")
        sConsulta.AppendLine("inner join  vendedor as ven on ven.vendedorid= VS.vendedorid ")
        sConsulta.AppendLine("inner join  agendavendedor as ag on ag.vendedorid = ven.vendedorid and ag.diaclave=vs.diaclave and  ag.clienteclave=vs.clienteclave  ")
        sConsulta.AppendLine("inner join  almacen as cedi on ag.clavecedi=cedi.clave ")
        sConsulta.AppendLine("WHERE CP.TipoRespuesta = 2 ")
        'sConsulta.AppendLine("AND VS.ClienteClave like  @pvClienteClave ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine(" UNION ALL ")

        '------------------------RESPUESTAS OPCIONAL UNICA-------------------------------
        sConsulta.AppendLine("SELECT EO.ENCId, EO.ENPId, CP.CEPNumero, EP.OrdenAplicacion, ")
        sConsulta.AppendLine("(CASE WHEN (SELECT CEP.TipoRespuesta FROM ENCPregunta ENP ")
        sConsulta.AppendLine("INNER JOIN CENPregunta CEP ON CEP.CENClave=ENP.CENClave AND CEP.CEPNumero=ENP.CEPNumero ")
        sConsulta.AppendLine("WHERE ENP.ENCId=EN.ENCId AND ENP.CENClave=CP.CENClave AND ENP.OrdenAplicacion=EP.OrdenAplicacion-1)= 7 THEN ")
        sConsulta.AppendLine("(SELECT ENP.CEPNumero FROM ENCPregunta ENP ")
        sConsulta.AppendLine("WHERE ENP.ENCId=EN.ENCId AND ENP.CENClave=EP.CENClave AND ENP.OrdenAplicacion=EP.OrdenAplicacion-1) ELSE NULL END) as PreguntaAnterior, ")
        sConsulta.AppendLine("TipoRespuesta=(SELECT Descripcion FROM VAVDescripcion WHERE VARCodigo = 'TENCR' and VAVClave = cast(CP.TipoRespuesta as VarChar(20)) and VADTipoLenguaje = '" & Session("lenguaje") & "'), ")
        sConsulta.AppendLine("TipoOperador=NULL,TipoCondicion=NULL, CP.Descripcion as DescripcionPregunta, EO.Valor, '' as Respuesta, NULL as Imagen ")
        sConsulta.AppendLine("FROM Visita VS ")
        sConsulta.AppendLine("INNER JOIN Encuesta EN ON EN.VisitaClave = VS.VisitaClave And EN.DiaClave = VS.DiaClave ")
        sConsulta.AppendLine("INNER JOIN ENCPregunta EP ON EP.ENCId=EN.ENCId ")
        sConsulta.AppendLine("INNER JOIN CENPregunta CP ON CP.CENClave=EP.CENClave AND CP.CEPNumero=EP.CEPNumero ")
        sConsulta.AppendLine("INNER JOIN CEPRespOpcional CRO ON CP.CENClave=CRO.CENClave AND CP.CEPNumero=CRO.CEPNumero ")
        sConsulta.AppendLine("INNER JOIN ENPRespOpcional EO ON EO.ENCId=EP.ENCId AND EO.ENPId=EP.ENPId  ")
        sConsulta.AppendLine("INNER JOIN Cliente CL ON CL.ClienteClave=VS.ClienteClave ")
        sConsulta.AppendLine("inner join  ruta as rut on rut.rutclave=vs.rutclave ")
        sConsulta.AppendLine("inner join  vendedor as ven on ven.vendedorid= VS.vendedorid ")
        sConsulta.AppendLine("inner join  agendavendedor as ag on ag.vendedorid = ven.vendedorid and ag.diaclave=vs.diaclave and  ag.clienteclave=vs.clienteclave ")
        sConsulta.AppendLine("inner join  almacen as cedi on ag.clavecedi=cedi.clave ")
        'sConsulta.AppendLine("AND VS.ClienteClave like  @pvClienteClave ")
        sConsulta.AppendLine("WHERE CP.TipoRespuesta = 3  and CRO.maximo=1 ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine(" UNION ALL ")

        '----------------------RESPUESTAS OPCIONAL MULTIPLE------------------------------
        sConsulta.AppendLine("SELECT EO.ENCId, EO.ENPId, CP.CEPNumero, EP.OrdenAplicacion, ")
        sConsulta.AppendLine("(CASE WHEN (SELECT CEP.TipoRespuesta FROM ENCPregunta ENP ")
        sConsulta.AppendLine("INNER JOIN CENPregunta CEP ON CEP.CENClave=ENP.CENClave AND CEP.CEPNumero=ENP.CEPNumero ")
        sConsulta.AppendLine("WHERE ENP.ENCId=EN.ENCId AND ENP.CENClave=CP.CENClave AND ENP.OrdenAplicacion=EP.OrdenAplicacion-1)= 7 THEN ")
        sConsulta.AppendLine("(SELECT ENP.CEPNumero FROM ENCPregunta ENP ")
        sConsulta.AppendLine("WHERE ENP.ENCId=EN.ENCId AND ENP.CENClave=EP.CENClave AND ENP.OrdenAplicacion=EP.OrdenAplicacion-1) ELSE NULL END) as PreguntaAnterior, ")
        sConsulta.AppendLine("TipoRespuesta=(SELECT Descripcion FROM VAVDescripcion WHERE VARCodigo = 'TENCR' and VAVClave = cast(CP.TipoRespuesta as VarChar(20)) and VADTipoLenguaje = '" & Session("lenguaje") & "'), ")
        sConsulta.AppendLine("TipoOperador=NULL,TipoCondicion=NULL, CP.Descripcion as DescripcionPregunta, EO.Valor, CO.Descripcion as Respuesta, NULL as Imagen ")
        sConsulta.AppendLine("FROM Visita VS ")
        sConsulta.AppendLine("INNER JOIN Encuesta EN ON EN.VisitaClave = VS.VisitaClave And EN.DiaClave = VS.DiaClave ")
        sConsulta.AppendLine("INNER JOIN ENCPregunta EP ON EP.ENCId=EN.ENCId ")
        sConsulta.AppendLine("INNER JOIN CENPregunta CP ON CP.CENClave=EP.CENClave AND CP.CEPNumero=EP.CEPNumero ")
        sConsulta.AppendLine("INNER JOIN CEPRespOpcional CRO ON CP.CENClave=CRO.CENClave AND CP.CEPNumero=CRO.CEPNumero ")
        sConsulta.AppendLine("INNER JOIN ENPRespOpcional EO ON EO.ENCId=EP.ENCId AND EO.ENPId=EP.ENPId ")
        sConsulta.AppendLine("INNER JOIN CROOpcion CO ON CO.COOId=EO.COOId ")
        sConsulta.AppendLine("INNER JOIN Cliente CL ON CL.ClienteClave=VS.ClienteClave ")
        sConsulta.AppendLine("inner join  ruta as rut on rut.rutclave=vs.rutclave ")
        sConsulta.AppendLine("inner join  vendedor as ven on ven.vendedorid= VS.vendedorid ")
        sConsulta.AppendLine("inner join  agendavendedor as ag on ag.vendedorid = ven.vendedorid and ag.diaclave=vs.diaclave and  ag.clienteclave=vs.clienteclave  ")
        sConsulta.AppendLine("inner join  almacen as cedi on ag.clavecedi=cedi.clave ")
        'sConsulta.AppendLine("AND VS.ClienteClave like  @pvClienteClave ")
        sConsulta.AppendLine("WHERE CP.TipoRespuesta = 3  and ((CRO.minimo>=1 and CRO.maximo >1)or cro.tipolimite=1) ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine(" UNION ALL ")

        '---------------------------RESPUESTAS DE CODIGO DE BARRAS------------------------------
        sConsulta.AppendLine("SELECT EC.ENCId, EC.ENPId, CP.CEPNumero, EP.OrdenAplicacion, ")
        sConsulta.AppendLine("(CASE WHEN (SELECT CEP.TipoRespuesta FROM ENCPregunta ENP ")
        sConsulta.AppendLine("INNER JOIN CENPregunta CEP ON CEP.CENClave=ENP.CENClave AND CEP.CEPNumero=ENP.CEPNumero ")
        sConsulta.AppendLine("WHERE ENP.ENCId=EN.ENCId AND ENP.CENClave=CP.CENClave AND ENP.OrdenAplicacion=EP.OrdenAplicacion-1)= 7 THEN ")
        sConsulta.AppendLine("(SELECT ENP.CEPNumero FROM ENCPregunta ENP ")
        sConsulta.AppendLine("WHERE ENP.ENCId=EN.ENCId AND ENP.CENClave=EP.CENClave AND ENP.OrdenAplicacion=EP.OrdenAplicacion-1) ELSE NULL END) as PreguntaAnterior, ")
        sConsulta.AppendLine("TipoRespuesta=(SELECT Descripcion FROM VAVDescripcion WHERE VARCodigo = 'TENCR' and VAVClave = cast(CP.TipoRespuesta as VarChar(20)) and VADTipoLenguaje = '" & Session("lenguaje") & "'), ")
        sConsulta.AppendLine("TipoOperador=NULL,TipoCondicion=NULL, CP.Descripcion as DescripcionPregunta, NULL as Valor, EC.Codigo as Respuesta, NULL as Imagen ")
        sConsulta.AppendLine("FROM Visita VS ")
        sConsulta.AppendLine("INNER JOIN Encuesta EN ON EN.VisitaClave = VS.VisitaClave And EN.DiaClave = VS.DiaClave ")
        sConsulta.AppendLine("INNER JOIN ENCPregunta EP ON EP.ENCId=EN.ENCId ")
        sConsulta.AppendLine("INNER JOIN CENPregunta CP ON CP.CENClave=EP.CENClave AND CP.CEPNumero=EP.CEPNumero ")
        sConsulta.AppendLine("LEFT JOIN ENPRespCodigo EC ON EC.ENCId=EP.ENCId AND EC.ENPId=EP.ENPId ")
        sConsulta.AppendLine("INNER JOIN Cliente CL ON CL.ClienteClave=VS.ClienteClave ")
        sConsulta.AppendLine("inner join  ruta as rut on rut.rutclave=vs.rutclave ")
        sConsulta.AppendLine("inner join  vendedor as ven on ven.vendedorid= VS.vendedorid ")
        sConsulta.AppendLine("inner join  agendavendedor as ag on ag.vendedorid = ven.vendedorid and ag.diaclave=vs.diaclave and  ag.clienteclave=vs.clienteclave ")
        sConsulta.AppendLine("inner join  almacen as cedi on ag.clavecedi=cedi.clave ")
        sConsulta.AppendLine("WHERE CP.TipoRespuesta = 4 ")
        'sConsulta.AppendLine("AND VS.ClienteClave like  @pvClienteClave  ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine(" UNION ALL ")

        '---------------------------RESPUESTAS DE IMAGEN------------------------------
        sConsulta.AppendLine("SELECT EI.ENCId, EI.ENPId, CP.CEPNumero, EP.OrdenAplicacion, ")
        sConsulta.AppendLine("(CASE WHEN (SELECT CEP.TipoRespuesta FROM ENCPregunta ENP ")
        sConsulta.AppendLine("INNER JOIN CENPregunta CEP ON CEP.CENClave=ENP.CENClave AND CEP.CEPNumero=ENP.CEPNumero ")
        sConsulta.AppendLine("WHERE ENP.ENCId=EN.ENCId AND ENP.CENClave=CP.CENClave AND ENP.OrdenAplicacion=EP.OrdenAplicacion-1)= 7 THEN ")
        sConsulta.AppendLine("(SELECT ENP.CEPNumero FROM ENCPregunta ENP ")
        sConsulta.AppendLine("WHERE ENP.ENCId=EN.ENCId AND ENP.CENClave=EP.CENClave AND ENP.OrdenAplicacion=EP.OrdenAplicacion-1) ELSE NULL END) as PreguntaAnterior, ")
        sConsulta.AppendLine("TipoRespuesta='#IMG#'+(SELECT Descripcion FROM VAVDescripcion WHERE VARCodigo = 'TENCR' and VAVClave = cast(CP.TipoRespuesta as VarChar(20)) and VADTipoLenguaje = '" & Session("lenguaje") & "'), ")
        sConsulta.AppendLine("TipoOperador=NULL,TipoCondicion=NULL, CP.Descripcion as DescripcionPregunta, NULL as Valor, NULL as Respuesta, EI.Imagen ")
        sConsulta.AppendLine("FROM Visita VS ")
        sConsulta.AppendLine("INNER JOIN Encuesta EN ON EN.VisitaClave = VS.VisitaClave And EN.DiaClave = VS.DiaClave ")
        sConsulta.AppendLine("INNER JOIN ENCPregunta EP ON EP.ENCId=EN.ENCId ")
        sConsulta.AppendLine("INNER JOIN CENPregunta CP ON CP.CENClave=EP.CENClave AND CP.CEPNumero=EP.CEPNumero ")
        sConsulta.AppendLine("LEFT JOIN ENPRespImagen EI ON EI.ENCId=EP.ENCId AND EI.ENPId=EP.ENPId ")
        sConsulta.AppendLine("INNER JOIN Cliente CL ON CL.ClienteClave=VS.ClienteClave ")
        sConsulta.AppendLine("inner join  ruta as rut on rut.rutclave=vs.rutclave ")
        sConsulta.AppendLine("inner join  vendedor as ven on ven.vendedorid= VS.vendedorid ")
        sConsulta.AppendLine("inner join  agendavendedor as ag on ag.vendedorid = ven.vendedorid and ag.diaclave=vs.diaclave and  ag.clienteclave=vs.clienteclave ")
        sConsulta.AppendLine("inner join  almacen as cedi on ag.clavecedi=cedi.clave ")
        sConsulta.AppendLine("WHERE CP.TipoRespuesta = 5 ")
        'sConsulta.AppendLine("AND VS.ClienteClave like  @pvClienteClave ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine(" UNION ALL ")

        '----------------------RESPUESTAS MATRICIALES------------------------------------
        sConsulta.AppendLine("SELECT RM.ENCId, RM.ENPId, CP.CEPNumero, EP.OrdenAplicacion, ")
        sConsulta.AppendLine("(CASE WHEN (SELECT CEP.TipoRespuesta FROM ENCPregunta ENP ")
        sConsulta.AppendLine("INNER JOIN CENPregunta CEP ON CEP.CENClave=ENP.CENClave AND CEP.CEPNumero=ENP.CEPNumero ")
        sConsulta.AppendLine("WHERE ENP.ENCId=EN.ENCId AND ENP.CENClave=CP.CENClave AND ENP.OrdenAplicacion=EP.OrdenAplicacion-1)= 7 THEN ")
        sConsulta.AppendLine("(SELECT ENP.CEPNumero FROM ENCPregunta ENP ")
        sConsulta.AppendLine("WHERE ENP.ENCId=EN.ENCId AND ENP.CENClave=EP.CENClave AND ENP.OrdenAplicacion=EP.OrdenAplicacion-1) ELSE NULL END) as PreguntaAnterior, ")
        sConsulta.AppendLine("TipoRespuesta=(SELECT Descripcion FROM VAVDescripcion WHERE VARCodigo = 'TENCR' and VAVClave = cast(CP.TipoRespuesta as VarChar(20)) and VADTipoLenguaje = '" & Session("lenguaje") & "'), ")
        sConsulta.AppendLine("TipoOperador=NULL,TipoCondicion=NULL, (CP.Descripcion + ' - ' + PM.Descripcion) as DescripcionPregunta, NULL as Valor, EM.Descripcion as Respuesta, NULL as Imagen ")
        sConsulta.AppendLine("FROM Visita VS ")
        sConsulta.AppendLine("INNER JOIN Encuesta EN ON EN.VisitaClave = VS.VisitaClave And EN.DiaClave = VS.DiaClave ")
        sConsulta.AppendLine("INNER JOIN ENCPregunta EP ON EP.ENCId=EN.ENCId ")
        sConsulta.AppendLine("INNER JOIN CENPregunta CP ON CP.CENClave=EP.CENClave AND CP.CEPNumero=EP.CEPNumero ")
        sConsulta.AppendLine("LEFT JOIN ENPRespMatricial RM ON RM.ENCId=EP.ENCId AND RM.ENPId=EP.ENPId ")
        sConsulta.AppendLine("INNER JOIN CEPPregMatricial PM ON PM.CENClave=RM.CENClave AND PM.CEPNumero=RM.CEPNumero AND PM.CPMNumero=RM.CPMNumero ")
        sConsulta.AppendLine("INNER JOIN CEPRespMatricial EM ON EM.CENClave=RM.CENClave1 AND EM.CEPNumero=RM.CEPNumero1 AND EM.CRMNumero=RM.CRMNumero ")
        sConsulta.AppendLine("INNER JOIN Cliente CL ON CL.ClienteClave=VS.ClienteClave ")
        sConsulta.AppendLine("inner join  ruta as rut on rut.rutclave=vs.rutclave ")
        sConsulta.AppendLine("inner join  vendedor as ven on ven.vendedorid= VS.vendedorid ")
        sConsulta.AppendLine("inner join  agendavendedor as ag on ag.vendedorid = ven.vendedorid and ag.diaclave=vs.diaclave and  ag.clienteclave=vs.clienteclave ")
        sConsulta.AppendLine("inner join  almacen as cedi on ag.clavecedi=cedi.clave ")
        sConsulta.AppendLine("WHERE CP.TipoRespuesta = 6 ")
        'sConsulta.AppendLine("AND VS.ClienteClave like  @pvClienteClave ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine(" UNION ALL ")

        '----------------------RESPUESTAS TIPO SALTO------------------------------------
        sConsulta.AppendLine("SELECT ENCId, ENPId, CEPNumero, OrdenAplicacion, PreguntaAnterior, TipoRespuesta, TipoOperador, TipoCondicion, ")
        sConsulta.AppendLine("DescripcionPregunta= DescripcionPregunta + ' ' + CASE WHEN TipoOperador is NULL THEN '' ELSE TipoOperador END + ' ' + TipoCondicion + ' ' + Valor, ")
        sConsulta.AppendLine("NULL, NULL, NULL FROM ")
        sConsulta.AppendLine("( ")
        sConsulta.AppendLine("SELECT EN.ENCId, DS.ENPId COLLATE DATABASE_DEFAULT AS ENPId, ")
        sConsulta.AppendLine("DS.CEPNumero, DS.OrdenAplicacion, PreguntaAnterior=NULL, ")
        sConsulta.AppendLine("TipoRespuesta=(SELECT Descripcion FROM VAVDescripcion WHERE VARCodigo = 'TENCR' and VAVClave = cast(CP.TipoRespuesta as VarChar(20)) and VADTipoLenguaje = 'EM'), ")
        sConsulta.AppendLine("TipoOperador=(SELECT Descripcion FROM VAVDescripcion WHERE VARCodigo = 'OPETIPO' and VAVClave = cast(DS.TipoOperador as VarChar(20)) and VADTipoLenguaje = 'EM'), ")
        sConsulta.AppendLine("TipoCondicion=(SELECT Descripcion FROM VAVDescripcion WHERE VARCodigo = 'TCOND' and VAVClave = cast(DS.TipoCondicion as VarChar(20)) and VADTipoLenguaje = 'EM'), ")
        sConsulta.AppendLine("DS.Descripcion COLLATE DATABASE_DEFAULT as DescripcionPregunta, DS.Valor COLLATE DATABASE_DEFAULT as Valor, NULL as Respuesta, NULL as Imagen ")
        sConsulta.AppendLine("FROM fn_DespliegaSaltos() DS ")
        sConsulta.AppendLine("INNER JOIN Encuesta EN ON EN.ENCId COLLATE DATABASE_DEFAULT=DS.ENCId ")
        sConsulta.AppendLine("INNER JOIN Visita VS ON VS.VisitaClave=EN.VisitaClave AND VS.DiaClave=EN.DiaClave ")
        sConsulta.AppendLine("INNER JOIN CENPregunta CP ON CP.CENClave=DS.CENClave COLLATE DATABASE_DEFAULT AND CP.CEPNumero=DS.CEPNumero ")
        sConsulta.AppendLine("INNER JOIN Cliente CL ON CL.ClienteClave=VS.ClienteClave ")
        sConsulta.AppendLine("inner join  ruta as rut on rut.rutclave=vs.rutclave ")
        sConsulta.AppendLine("inner join  vendedor as ven on ven.vendedorid= VS.vendedorid ")
        sConsulta.AppendLine("inner join  agendavendedor as ag on ag.vendedorid = ven.vendedorid and ag.diaclave=vs.diaclave and  ag.clienteclave=vs.clienteclave ")
        sConsulta.AppendLine("inner join  almacen as cedi on ag.clavecedi=cedi.clave ")
        sConsulta.AppendLine(" WHERE CP.TipoRespuesta = 7 ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine(") as Saltos ")


        sConsulta.AppendLine(") AS Respuestas ORDER BY OrdenAplicacion, CEPNumero ")

        Session("Query2") = sConsulta.ToString

        Return True
    End Function

    Private Function ConsultaVentasPorVendedor(ByVal ins As DBConexion.cConexionSQL, ByVal pvDetallado As Boolean) As Boolean
        Dim strFechaIni As String = ""
        Dim strFechaFin As String = ""
        Dim sFecha As String()
        sFecha = txtFInicio.Text.Split("/")
        Dim dFechaIni As New Date(sFecha(2), sFecha(1), sFecha(0))

        strFechaIni = "'" & dFechaIni.Date.ToString("s") & "' "
        strFechaFin = "'" & dFechaIni.Date.AddDays(1).ToString("s") & "' "
        If chboxFecha.Checked = False Then
            strFechaIni = "'" & Date.Now.Date.ToString("s") & "' "
            strFechaFin = "'" & Date.Now.Date.AddDays(1).ToString("s") & "' "
        End If

        Dim strSQL As String = "SET DATEFIRST 5 "

        If pvDetallado Then
            strSQL &= "SET ANSI_WARNINGS OFF "
            strSQL &= "declare @tipo int "
            strSQL &= "Set @tipo = (select top 1 Case Cobrarventas when 0 then 8 else 1 end from conhist order by mfechahora desc) "
            strSQL &= "SELECT distinct USU.Clave, VEN.Nombre "
            strSQL &= "FROM transprod TRP "
            strSQL &= "inner join dia on dia.diaclave = trp.diaclave "
            strSQL &= "INNER JOIN visita VIS on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave "
            strSQL &= "INNER JOIN vendedor VEN on VEN.VendedorID = VIS.VendedorID "
            strSQL &= "INNER JOIN usuario USU on USU.USUId = VEN.USUId "
            strSQL &= "INNER JOIN (Select distinct VendedorId, ClaveCEDI, DiaCLave, RUTClave FROM AgendaVendedor) A on A.DiaClave = TRP.DiaClave and A.VendedorId = VIS.VendedorID "
            strSQL &= "where TRP.tipo = @tipo AND (TRP.TipoFase = 1 OR TRP.TipoFase = 2 OR TRP.TipoFase = case @tipo when 8 then 1 else 3 end ) "
            strSQL &= "AND dia.fechacaptura BETWEEN DATEADD(day,-DATEPART(dw," & strFechaIni & ")," & strFechaIni & ") "
            strSQL &= "AND DATEADD(day,-DATEPART(dw," & strFechaFin & ")+6," & strFechaFin & ") "
            If ChBoxCentroDistribucion.Checked Then
                strSQL &= "AND A.ClaveCEDI =  '" + DdlCentroDistribucion.SelectedValue + "' "
            End If
            strSQL &= "GROUP BY usu.Clave, VEN.Nombre, DATEPART(YEAR,dia.fechacaptura),DATEPART(wk,dia.fechacaptura) "

            'Session("Query") = strSQL

            Dim dt As Data.DataTable
            dt = ins.EjecutarConsulta(strSQL.ToString, IntCommandTimeOut)
            If dt.Rows.Count = 0 Then
                Return False
            End If
            Session("DataTable") = dt

            strSQL &= "SET ANSI_WARNINGS OFF "
            strSQL = "SET DATEFIRST 5 "
            strSQL &= "declare @tipo int "
            strSQL &= "Set @tipo = (select top 1 Case Cobrarventas when 0 then 8 else 1 end from conhist order by mfechahora desc) "
            strSQL &= "select USu.Clave,A.RUTClave, sum(TRP.Total) as Total "
            strSQL &= "from TransProd TRP "
            strSQL &= "inner join dia on dia.diaclave = trp.diaclave "
            strSQL &= "INNER JOIN visita VIS on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave "
            strSQL &= "INNER JOIN vendedor VEN on VEN.VendedorID = VIS.VendedorID "
            strSQL &= "INNER JOIN usuario USU on USU.USUId = VEN.USUId "
            strSQL &= "INNER JOIN (Select distinct VendedorId, ClaveCEDI, DiaCLave, RUTClave FROM AgendaVendedor) A on A.DiaClave = TRP.DiaClave and A.VendedorId = VIS.VendedorID "
            strSQL &= "where TRP.tipo = @tipo  "
            strSQL &= "AND (TRP.TipoFase = 1 OR TRP.TipoFase = 2 OR TRP.TipoFase = case @tipo when 8 then 1 else 3 end ) "
            strSQL &= "AND  ( dia.fechacaptura>=  " & strFechaIni & " and  dia.fechacaptura < " & strFechaFin & ")  "
            If ChBoxCentroDistribucion.Checked Then
                strSQL &= "AND A.ClaveCEDI =  '" + DdlCentroDistribucion.SelectedValue + "' "
            End If
            strSQL &= "group by USu.Clave, VEN.Nombre,A.RUTClave "

            Session("Query2") = strSQL

            strSQL &= "SET ANSI_WARNINGS OFF "
            strSQL = "SET DATEFIRST 5 "
            strSQL &= "declare @tipo int "
            strSQL &= "Set @tipo = (select top 1 Case Cobrarventas when 0 then 8 else 1 end from conhist order by mfechahora desc) "
            strSQL &= "SELECT USU.Clave, DATEPART(YEAR,DIA.FechaCaptura) AS Ano, "
            strSQL &= "DATEPART(wk,DIA.FechaCaptura) AS Semana, "
            strSQL &= "MIN(DATEADD(day,-DATEPART(dw,DIA.FechaCaptura)+1,DIA.FechaCaptura)) AS SemanaIni, "
            strSQL &= "MIN(DATEADD(day,-DATEPART(dw,DIA.FechaCaptura)+7,DIA.FechaCaptura)) AS SemanaFin, "
            strSQL &= "SUM(COALESCE(total,0)) AS Total "
            strSQL &= "FROM transprod TRP "
            strSQL &= "inner join dia on dia.diaclave = trp.diaclave "
            strSQL &= "INNER JOIN visita VIS on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave "
            strSQL &= "INNER JOIN vendedor VEN on VEN.VendedorID = VIS.VendedorID "
            strSQL &= "INNER JOIN usuario USU on USU.USUId = VEN.USUId "
            strSQL &= "INNER JOIN (Select distinct VendedorId, ClaveCEDI, DiaCLave, RUTClave FROM AgendaVendedor) A on A.DiaClave = TRP.DiaClave and A.VendedorId = VIS.VendedorID "
            strSQL &= "where TRP.tipo = @tipo AND (TRP.TipoFase = 1 OR TRP.TipoFase = 2 OR TRP.TipoFase = case @tipo when 8 then 1 else 3 end ) "
            strSQL &= "AND Dia.FechaCaptura BETWEEN DATEADD(day,-DATEPART(dw," & strFechaIni & ")+1," & strFechaIni & ") "
            strSQL &= "AND DATEADD(day,-DATEPART(dw," & strFechaFin & ")+7," & strFechaFin & ") "
            If ChBoxCentroDistribucion.Checked Then
                strSQL &= "AND A.ClaveCEDI =  '" + DdlCentroDistribucion.SelectedValue + "' "
            End If
            strSQL &= "GROUP BY usu.Clave, DATEPART(YEAR,Dia.FechaCaptura),DATEPART(wk,Dia.FechaCaptura) "
            Session("Query3") = strSQL
        Else
            Dim sConsulta As New StringBuilder

            sConsulta.AppendLine("SET DATEFIRST 5 ")
            sConsulta.AppendLine("SET NOCOUNT ON ")
            sConsulta.AppendLine("declare @Fecha as datetime ")
            sConsulta.AppendLine("set @Fecha = " & strFechaIni & " ")
            sConsulta.AppendLine("declare @Fecha1 as datetime ")
            sConsulta.AppendLine("set @Fecha1 = dateadd(day, 1, @Fecha) ")

            sConsulta.AppendLine("if (select object_id('tempdb..#TmpUltimaDev')) is not null drop table #TmpUltimaDev ")
            sConsulta.AppendLine("select * into #TmpUltimaDev from( ")
            sConsulta.AppendLine("	select VEN.VendedorId, max(Dia.FechaCaptura ) as FechaUltimaDevolucion ")
            sConsulta.AppendLine("	from TransProd TRP ")
            sConsulta.AppendLine("	inner join Vendedor VEN on VEN.USUId = TRP.MUsuarioId and VEN.TipoEstado = 1 and VEN.Baja = 0 ")
            sConsulta.AppendLine("	inner join Dia on TRP.DiaClave = Dia.DiaClave and Dia.FechaCaptura < @Fecha ")
            sConsulta.AppendLine("	where TRP.Tipo = 4 and TRP.TipoFase <> 0 ")
            sConsulta.AppendLine("	group by VEN.VendedorId ")
            sConsulta.AppendLine(")as t1 ")

            sConsulta.AppendLine("if (select object_id('tempdb..#TmpDevolucion')) is not null drop table #TmpDevolucion ")
            sConsulta.AppendLine("select * into #TmpDevolucion from( ")
            sConsulta.AppendLine("	select distinct VEN.VendedorId ")
            sConsulta.AppendLine("	from Vendedor VEN ")
            sConsulta.AppendLine("	inner join TransProd TRP on VEN.USUId = TRP.MUsuarioId and TRP.Tipo = 4 and TRP.TipoFase <> 0 ")
            sConsulta.AppendLine("	inner join Dia on TRP.DiaClave = Dia.DiaClave and Dia.FechaCaptura = @Fecha ")
            sConsulta.AppendLine("	where VEN.TipoEstado = 1 and VEN.Baja = 0 ")
            sConsulta.AppendLine(")as t2 ")

            sConsulta.AppendLine("if (select object_id('tempdb..#TmpPrimeraCarga')) is not null drop table #TmpPrimeraCarga ")
            sConsulta.AppendLine("select * into #TmpPrimeraCarga from( ")
            sConsulta.AppendLine("	select VEN.VendedorId, min(Dia.FechaCaptura) as FechaPrimerCarga ")
            sConsulta.AppendLine("	from TransProd TRP ")
            sConsulta.AppendLine("	inner join Dia on TRP.DiaClave = Dia.DiaClave ")
            sConsulta.AppendLine("	inner join Vendedor VEN on VEN.USUId=TRP.MUsuarioId and VEN.TipoEstado=1 and VEN.Baja=0 ")
            sConsulta.AppendLine("	inner join #TmpDevolucion DEV on VEN.VendedorId = DEV.VendedorId ")
            sConsulta.AppendLine("	left join #TmpUltimaDev TMP on VEN.VendedorId = TMP.VendedorId ")
            sConsulta.AppendLine("	where TRP.Tipo = 2 and TRP.TipoFase <> 0 ")
            sConsulta.AppendLine("	and ((not TMP.FechaUltimaDevolucion is null and Dia.FechaCaptura > TMP.FechaUltimaDevolucion) or TMP.FechaUltimaDevolucion is null) ")
            sConsulta.AppendLine("	and Dia.FechaCaptura <= @Fecha ")
            sConsulta.AppendLine("	group by VEN.VendedorId ")
            sConsulta.AppendLine(")as t3 ")

            sConsulta.AppendLine("if (select object_id('tempdb..#TmpMovsSemana')) is not null drop table #TmpMovsSemana ")
            sConsulta.AppendLine("select * into #TmpMovsSemana from( ")
            sConsulta.AppendLine("select Dia.DiaClave, Dia.FechaCaptura, VEN.VendedorId, TPD.TransProdId, TRP.Tipo, TRP.TipoMovimiento, TRP.TipoMotivo, TRP.DescVendPor, ")
            sConsulta.AppendLine("TPD.TransProdDetalleId, TPD.ProductoClave, TPD.TipoUnidad, TPD.Cantidad, TPD.Total, TPD.SubTotal, TPD.Promocion, TPD.Impuesto, ")
            sConsulta.AppendLine("PDD.Factor ")
            sConsulta.AppendLine("FROM TransProd as TRP ")
            sConsulta.AppendLine("INNER JOIN TransProdDetalle as TPD ON TPD.TransProdId=TRP.TransProdId ")
            sConsulta.AppendLine("INNER JOIN dia on dia.diaclave =trp.diaclave ")
            sConsulta.AppendLine("INNER JOIN Producto as PRD ON PRD.ProductoClave=TPD.ProductoClave AND PRD.Tipo<>5 ")
            sConsulta.AppendLine("INNER JOIN ProductoDetalle as PDD ON PDD.ProductoClave=TPD.ProductoClave AND PDD.PRUTipoUnidad=TPD.TipoUnidad AND PDD.ProductoDetClave=TPD.ProductoClave ")
            sConsulta.AppendLine("INNER JOIN Usuario as USU ON USU.USUId=TRP.MUsuarioId ")
            sConsulta.AppendLine("INNER JOIN Vendedor as VEN ON VEN.USUId=TRP.MUsuarioId AND VEN.TipoEstado=1 AND VEN.Baja=0 ")
            sConsulta.AppendLine("INNER JOIN (SELECT distinct DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor GROUP BY DiaClave, VendedorId, ClaveCEDI) as AGV ON AGV.DiaClave=TRP.DiaClave AND AGV.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("WHERE TRP.Tipo IN (1,2,3,4,6,7,9,22,23) AND TRP.TipoFase<>0 ")
            sConsulta.AppendLine("and Dia.FechaCaptura BETWEEN DATEADD(day,-DATEPART(dw,@Fecha)+1, @Fecha) AND DATEADD(day,-DATEPART(dw, @Fecha)+7, @Fecha) ")
            If ChBoxCentroDistribucion.Checked Then
                strSQL &= "and AGV.ClaveCEDI =  '" + DdlCentroDistribucion.SelectedValue + "' "
            End If
            sConsulta.AppendLine(")as t4 ")

            'Liquidacion diaria
            sConsulta.AppendLine("select USU.Clave, VEN.Nombre, t1.Total ")
            sConsulta.AppendLine("from Vendedor VEN ")
            sConsulta.AppendLine("inner join Usuario USU on VEN.UsuId = USU.UsuId and USU.Activo = 1 ")
            sConsulta.AppendLine("left join ( ")
            sConsulta.AppendLine("select VendedorId, sum(Importe) as Total from ( ")
            sConsulta.AppendLine("SELECT VendedorId, ProductoClave, ")
            sConsulta.AppendLine("Importe = (sum(Importe) ")
            sConsulta.AppendLine("+ ((sum(Carga)-sum(Devolucion)-sum(Ajuste)-sum(Venta)-sum(Otro)-sum(frio)+sum(DevolucionCte)) * avg(ImporteUnitario)) ")
            sConsulta.AppendLine("- (sum(DevolucionCte) * avg(ImporteUnitario)) ")
            sConsulta.AppendLine("+ (sum(Ajuste) * avg(ImporteUnitario)) ")
            sConsulta.AppendLine("- (sum(BonificacionAjuste) * avg(ImporteUnitario))) ")
            sConsulta.AppendLine("FROM ( ")
            sConsulta.AppendLine("SELECT FechaCaptura, VendedorId, ProductoClave, Carga, Devolucion, Frio, Reclasificado, DevolucionCte, Otro=(Cambio2+Promocion-Cambio1), ")
            sConsulta.AppendLine("Ajuste,bonificacionajuste, Venta, ImporteUnitario, ")
            sConsulta.AppendLine("Importe=(SubTotal- DescCliPor -((SubTotal-DescCliPor) * DescVendPor / 100) ) + (Impuesto-DescCliPorImp-((Impuesto-DescCliPorImp) * DescVendPor / 100)) ")
            sConsulta.AppendLine("FROM ( ")
            sConsulta.AppendLine("SELECT distinct TransProdId, TransProdDetalleId, DiaClave, FechaCaptura, ")
            sConsulta.AppendLine("MOV.VendedorId, Tipo, ProductoClave, ")
            sConsulta.AppendLine("Carga=(SELECT CASE WHEN Tipo=2 THEN Cantidad * Factor WHEN Tipo=23 THEN Cantidad ELSE 0 END), ")
            sConsulta.AppendLine("Devolucion=(SELECT CASE WHEN Tipo=7 THEN Cantidad * Factor ELSE 0 END), ")
            sConsulta.AppendLine("Frio=(SELECT CASE WHEN Tipo=4 THEN Cantidad * Factor ELSE 0 END), ")
            sConsulta.AppendLine("Reclasificado=(SELECT CASE WHEN Tipo=22 THEN Cantidad * Factor ELSE 0 END), ")
            sConsulta.AppendLine("Ajuste=(SELECT CASE WHEN Tipo=6 THEN Cantidad * Factor ELSE 0 END), ")
            sConsulta.AppendLine("BonificacionAjuste=(SELECT CASE WHEN Tipo=6 and tipomotivo=6 THEN Cantidad * Factor ELSE 0 END), ")
            sConsulta.AppendLine("Cambio1=(SELECT CASE WHEN Tipo=9 AND TipoMovimiento=1 THEN Cantidad * Factor ELSE 0 END), ")
            sConsulta.AppendLine("Cambio2=(SELECT CASE WHEN Tipo=9 AND TipoMovimiento=2 THEN Cantidad * Factor ELSE 0 END), ")
            sConsulta.AppendLine("DevolucionCte=(SELECT CASE WHEN Tipo=3 THEN Cantidad * Factor ELSE 0 END), ")
            sConsulta.AppendLine("Promocion=(SELECT CASE WHEN Tipo=1 AND Total=0 THEN Cantidad * Factor ELSE 0 END), ")
            sConsulta.AppendLine("Venta=(SELECT CASE WHEN Tipo=1 AND Total>0 and promocion<>2 THEN Cantidad * Factor ELSE 0 END), ")
            sConsulta.AppendLine("ImporteUnitario=(SELECT Top 1 Precio FROM PrecioProductoVig AS PPV INNER JOIN Precio as PRE ON ")
            sConsulta.AppendLine("PRE.PrecioClave=PPV.PrecioClave AND PRE.TipoEstado=1 WHERE PPV.ProductoClave=MOV.ProductoClave ")
            sConsulta.AppendLine("AND PPV.PRUTipoUnidad=(SELECT TOP 1 PRD.PRUTipoUnidad FROM ProductoDetalle AS PRD WHERE PRD.ProductoClave=MOV.ProductoClave Order by PRD.Factor ASC) AND PPVFechaInicio <=fechacaptura AND FechaFin >=fechacaptura Order by Precio Desc), ")
            sConsulta.AppendLine("SubTotal=(SELECT CASE WHEN Tipo=1  AND Total>0 THEN Subtotal ELSE 0 END), DescCliPor=(SELECT CASE WHEN Tipo=1  AND Total>0 THEN (SELECT (CASE WHEN sum(DesImporte) IS NULL THEN 0 ELSE sum(DesImporte) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=MOV.TransProdId AND TDD.TransProdDetalleId=MOV.TransProdDetalleId) ELSE 0 End), ")
            sConsulta.AppendLine("DescVendPor=(SELECT CASE WHEN Tipo=1 AND Total>0 THEN (SELECT CASE WHEN DescVendPor IS NULL THEN 0 ELSE DescVendPor END) ELSE 0 END), ")
            sConsulta.AppendLine("Impuesto=(SELECT CASE WHEN Tipo=1  AND Total>0 THEN (SELECT CASE WHEN Impuesto IS NULL THEN 0 ELSE Impuesto END) ELSE 0 END), ")
            sConsulta.AppendLine("DescCliPorImp=(SELECT CASE WHEN Tipo=1 AND Total>0 THEN (SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE sum(DesImpuesto) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=MOV.TransProdId AND TDD.TransProdDetalleId=MOV.TransProdDetalleId) ELSE 0 End) ")
            sConsulta.AppendLine("from #TmpMovsSemana MOV ")
            sConsulta.AppendLine("inner join #TmpPrimeraCarga TMP on MOV.VendedorId = TMP.VendedorId and (MOV.FechaCaptura >= TMP.FechaPrimerCarga and MOV.FechaCaptura < @Fecha1) ")
            sConsulta.AppendLine(") AS Liquidacion ")
            sConsulta.AppendLine(") AS LIQ ")
            sConsulta.AppendLine("GROUP BY VendedorId, ProductoClave ")
            sConsulta.AppendLine(") as t ")
            sConsulta.AppendLine("group by VendedorId ")
            sConsulta.AppendLine(") as t1 on VEN.VendedorId = t1.VendedorId ")
            sConsulta.AppendLine("where VEN.TipoEstado = 1 and VEN.Baja = 0 ")
            sConsulta.AppendLine("order by USU.Clave ")

            'Liquidacion semanal 
            sConsulta.AppendLine("select USU.Clave, (DATEADD(day,-DATEPART(dw,@Fecha)+1,@Fecha)) AS SemanaIni, ")
            sConsulta.AppendLine("(DATEADD(day,-DATEPART(dw,@Fecha)+7,@Fecha)) AS SemanaFin, ")
            sConsulta.AppendLine("sum(Importe) as Total from ( ")
            sConsulta.AppendLine("SELECT VendedorId, ProductoClave, ")
            sConsulta.AppendLine("Importe = (sum(Importe) ")
            sConsulta.AppendLine("+ ((sum(Carga)-sum(Devolucion)-sum(Ajuste)-sum(Venta)-sum(Otro)-sum(frio)+sum(DevolucionCte)) * avg(ImporteUnitario)) ")
            sConsulta.AppendLine("- (sum(DevolucionCte) * avg(ImporteUnitario)) ")
            sConsulta.AppendLine("+ (sum(Ajuste) * avg(ImporteUnitario)) ")
            sConsulta.AppendLine("- (sum(BonificacionAjuste) * avg(ImporteUnitario))) ")
            sConsulta.AppendLine("FROM ( ")
            sConsulta.AppendLine("SELECT FechaCaptura, VendedorId, ProductoClave, Carga, Devolucion, Frio, Reclasificado, DevolucionCte, Otro=(Cambio2+Promocion-Cambio1), ")
            sConsulta.AppendLine("Ajuste,bonificacionajuste, Venta, ImporteUnitario, ")
            sConsulta.AppendLine("Importe=(SubTotal- DescCliPor -((SubTotal-DescCliPor) * DescVendPor / 100) ) + (Impuesto-DescCliPorImp-((Impuesto-DescCliPorImp) * DescVendPor / 100)) ")
            sConsulta.AppendLine("FROM ( ")
            sConsulta.AppendLine("SELECT distinct TransProdId, TransProdDetalleId, DiaClave, FechaCaptura, ")
            sConsulta.AppendLine("MOV.VendedorId, Tipo, ProductoClave, ")
            sConsulta.AppendLine("Carga=(SELECT CASE WHEN Tipo=2 THEN Cantidad * Factor WHEN Tipo=23 THEN Cantidad ELSE 0 END), ")
            sConsulta.AppendLine("Devolucion=(SELECT CASE WHEN Tipo=7 THEN Cantidad * Factor ELSE 0 END), ")
            sConsulta.AppendLine("Frio=(SELECT CASE WHEN Tipo=4 THEN Cantidad * Factor ELSE 0 END), ")
            sConsulta.AppendLine("Reclasificado=(SELECT CASE WHEN Tipo=22 THEN Cantidad * Factor ELSE 0 END), ")
            sConsulta.AppendLine("Ajuste=(SELECT CASE WHEN Tipo=6 THEN Cantidad * Factor ELSE 0 END), ")
            sConsulta.AppendLine("BonificacionAjuste=(SELECT CASE WHEN Tipo=6 and tipomotivo=6 THEN Cantidad * Factor ELSE 0 END), ")
            sConsulta.AppendLine("Cambio1=(SELECT CASE WHEN Tipo=9 AND TipoMovimiento=1 THEN Cantidad * Factor ELSE 0 END), ")
            sConsulta.AppendLine("Cambio2=(SELECT CASE WHEN Tipo=9 AND TipoMovimiento=2 THEN Cantidad * Factor ELSE 0 END), ")
            sConsulta.AppendLine("DevolucionCte=(SELECT CASE WHEN Tipo=3 THEN Cantidad * Factor ELSE 0 END), ")
            sConsulta.AppendLine("Promocion=(SELECT CASE WHEN Tipo=1 AND Total=0 THEN Cantidad * Factor ELSE 0 END), ")
            sConsulta.AppendLine("Venta=(SELECT CASE WHEN Tipo=1 AND Total>0 and promocion<>2 THEN Cantidad * Factor ELSE 0 END), ")
            sConsulta.AppendLine("ImporteUnitario=(SELECT Top 1 Precio FROM PrecioProductoVig AS PPV INNER JOIN Precio as PRE ON ")
            sConsulta.AppendLine("PRE.PrecioClave=PPV.PrecioClave AND PRE.TipoEstado=1 WHERE PPV.ProductoClave=MOV.ProductoClave ")
            sConsulta.AppendLine("AND PPV.PRUTipoUnidad=(SELECT TOP 1 PRD.PRUTipoUnidad FROM ProductoDetalle AS PRD WHERE PRD.ProductoClave=MOV.ProductoClave Order by PRD.Factor ASC) AND PPVFechaInicio <=fechacaptura AND FechaFin >=fechacaptura Order by Precio Desc), ")
            sConsulta.AppendLine("SubTotal=(SELECT CASE WHEN Tipo=1  AND Total>0 THEN Subtotal ELSE 0 END), DescCliPor=(SELECT CASE WHEN Tipo=1  AND Total>0 THEN (SELECT (CASE WHEN sum(DesImporte) IS NULL THEN 0 ELSE sum(DesImporte) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=MOV.TransProdId AND TDD.TransProdDetalleId=MOV.TransProdDetalleId) ELSE 0 End), ")
            sConsulta.AppendLine("DescVendPor=(SELECT CASE WHEN Tipo=1 AND Total>0 THEN (SELECT CASE WHEN DescVendPor IS NULL THEN 0 ELSE DescVendPor END) ELSE 0 END), ")
            sConsulta.AppendLine("Impuesto=(SELECT CASE WHEN Tipo=1  AND Total>0 THEN (SELECT CASE WHEN Impuesto IS NULL THEN 0 ELSE Impuesto END) ELSE 0 END), ")
            sConsulta.AppendLine("DescCliPorImp=(SELECT CASE WHEN Tipo=1 AND Total>0 THEN (SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE sum(DesImpuesto) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=MOV.TransProdId AND TDD.TransProdDetalleId=MOV.TransProdDetalleId) ELSE 0 End) ")
            sConsulta.AppendLine("from #TmpMovsSemana MOV ")
            sConsulta.AppendLine(") AS Liquidacion ")
            sConsulta.AppendLine(") AS LIQ ")
            sConsulta.AppendLine("GROUP BY VendedorId, ProductoClave ")
            sConsulta.AppendLine(") as LIQ ")
            sConsulta.AppendLine("inner join Vendedor VEN on LIQ.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Usuario USU on VEN.USUId = USU.USUId ")
            sConsulta.AppendLine("group by USU.Clave ")

            'Productos
            sConsulta.AppendLine("select ProductoClave, Nombre, sum(Piezas) as Piezas, ")
            sConsulta.AppendLine("sum((SubTotal - DescuentoCliente - ((SubTotal - DescuentoCliente) * (DescVendPor / 100))) + (Impuesto - DescClienteImpuesto - ((Impuesto - DescClienteImpuesto) * (DescVendPor / 100)))) as Importe ")
            sConsulta.AppendLine("from ( ")
            sConsulta.AppendLine("select MOV.ProductoClave, PRO.Nombre, PRD.Factor * MOV.Cantidad as Piezas, ")
            sConsulta.AppendLine("(select (case when sum(DesImporte) is null then 0 else sum(DesImporte) end) from TpdDes as TDD where TDD.TransProdId=MOV.TransProdId and TDD.TransProdDetalleId=MOV.TransProdDetalleId) as DescuentoCliente, ")
            sConsulta.AppendLine("MOV.SubTotal, MOV.DescVendPor, MOV.Impuesto, ")
            sConsulta.AppendLine("(select (case when sum(DesImpuesto) is null then 0 else sum(DesImpuesto) end) from TpdDes as TDD where TDD.TransProdId=MOV.TransProdId and TDD.TransProdDetalleId=MOV.TransProdDetalleId) as DescClienteImpuesto ")
            sConsulta.AppendLine("from #TmpMovsSemana MOV ")
            sConsulta.AppendLine("inner join Producto PRO on PRO.ProductoClave = MOV.ProductoClave ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on MOV.ProductoClave = PRD.ProductoClave and MOV.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
            sConsulta.AppendLine("inner join #TmpPrimeraCarga TMP on MOV.VendedorId = TMP.VendedorId and (MOV.FechaCaptura >= TMP.FechaPrimerCarga and MOV.FechaCaptura < @Fecha1) ")
            sConsulta.AppendLine("where MOV.Tipo = 1 and MOV.Promocion <> 2 ")
            sConsulta.AppendLine(") as t ")
            sConsulta.AppendLine("group by ProductoClave, Nombre ")
            sConsulta.AppendLine("order by ProductoClave ")

            sConsulta.AppendLine("drop table #TmpUltimaDev ")
            sConsulta.AppendLine("drop table #TmpDevolucion ")
            sConsulta.AppendLine("drop table #TmpPrimeraCarga ")
            sConsulta.AppendLine("drop table #TmpMovsSemana ")
            sConsulta.AppendLine("SET NOCOUNT OFF ")

            Dim dsVentas As Data.DataSet
            dsVentas = ins.EjecutarConsultaDataSet(sConsulta.ToString, "Ventas")

            If Not dsVentas Is Nothing Then
                If dsVentas.Tables(1).Rows.Count = 0 Then
                    Return False
                End If
                Session("Ventas") = dsVentas
            End If
        End If

        Return True
    End Function

    Private Function ConsultaDevolucionesCambiosVendedor(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvClientes As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "TRP.FechaHoraAlta")
        End If
        pvCondicion = strWhereCentrosDistribucion(pvCondicion, "ALN.Clave")
        pvCondicion = strWhereClientes(pvCondicion, pvClientes, "CLI.ClienteClave")

        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("select ALN.Clave + ' ' + ALN.Nombre as CEDI, TRP.FechaHoraAlta, CLI.Clave as ClienteClave, CLI.RazonSocial, TPD.ProductoClave, ")
        sConsulta.AppendLine("PRO.Nombre as ProductoNombre, VAD.Descripcion as Unidad, PRD.Factor,  PPV.Precio, ")
        sConsulta.AppendLine("case TRP.Tipo when 3 then TPD.Cantidad else 0 end 'CantidadDevuelta', ")
        sConsulta.AppendLine("case TRP.Tipo when 3 then TPD.Cantidad * PPV.Precio else 0 end 'ImporteDevuelto', ")
        sConsulta.AppendLine("case when TRP.Tipo = 9 AND TRP.TipoMovimiento= 1 then TPD.Cantidad else 0 end 'CantidadCambiada', ")
        sConsulta.AppendLine("case when TRP.Tipo = 9 AND TRP.TipoMovimiento= 1 then TPD.Cantidad * PPV.Precio else 0 end 'ImporteCambiado', ")
        sConsulta.AppendLine("case TRP.Tipo when 3 then TPD.Cantidad * PRD.Factor else 0 end 'UnidadesDevueltas', ")
        sConsulta.AppendLine("case when TRP.Tipo = 9 AND TRP.TipoMovimiento= 1 then TPD.Cantidad * PRD.Factor else 0 end 'UnidadesCambiadas', ")
        sConsulta.AppendLine("case when TRP.Tipo = 9 AND TRP.TipoMovimiento= 2 then TPD.Cantidad else 0 end 'CantidadCambiadaPor', ")
        sConsulta.AppendLine("case when TRP.Tipo = 9 AND TRP.TipoMovimiento= 2 then TPD.Cantidad * PPV.Precio else 0 end 'ImporteCambiadoPor', ")
        sConsulta.AppendLine("case when TRP.Tipo = 9 AND TRP.TipoMovimiento= 2 then TPD.Cantidad * PRD.Factor else 0 end 'UnidadesCambiadasPor', ")
        sConsulta.AppendLine("VEN.VendedorId AS VendedorId, VEN.nombre as Vendedor ")
        sConsulta.AppendLine("from TransProd TRP ")
        sConsulta.AppendLine("inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ")
        sConsulta.AppendLine("inner join Cliente CLI on CLI.ClienteClave = VIS.ClienteClave ")
        sConsulta.AppendLine("inner join TransProdDetalle TPD on TPD.TransProdID = TRP.TransProdID ")
        sConsulta.AppendLine("inner join Producto PRO on PRO.ProductoClave = TPD.ProductoClave ")
        sConsulta.AppendLine("inner join ProductoDetalle PRD on PRD.ProductoClave= PRO.ProductoClave and PRD.PRUTipoUnidad = TPD.TipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ")
        sConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VAVClave = TPD.TipoUnidad and VAD.VARCodigo = 'UNIDADV' and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' ")
        sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorID = VEN.VendedorID ")
        sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI from AgendaVendedor) AGV on TRP.DiaClave = AGV.DiaClave and VEN.VendedorId = AGV.VendedorId ")
        sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
        sConsulta.AppendLine("inner join PrecioProductoVig PPV on PPV.ProductoClave = TPD.ProductoClave and PPV.PRUTipoUnidad = TPD.TipoUnidad and TRP.FechaHoraAlta >= PPV.PPVFechaInicio and TRP.FechaHoraAlta <= PPV.FechaFin ")
        sConsulta.AppendLine("and PPV.PrecioClave = ( select TOP 1 PE.PrecioClave ")
        sConsulta.AppendLine("from precioclienteesquema PE ")
        sConsulta.AppendLine("where PE.Esquemaid in (select EsquemaId from clienteesquema where ClienteClave = CLI.ClienteClave) ")
        sConsulta.AppendLine("AND PE.ModuloMovDetalleClave in ( ")
        sConsulta.AppendLine("select ModuloMovDetalleClave from modulomovdetalle where tipoindice = 9 and tipotransprod = 1 and tipoestado = 1)) ")

        If (Session("Vendedor") <> "") Then
            'pvCondicion &= " AND VEN.Nombre = '" & Session("Vendedor") & "'"
            pvCondicion &= " AND VEN.VendedorId = '" & Session("VendedorId") & "'"
        End If
        sConsulta.AppendLine(pvCondicion & " and (TRP.Tipo = 3 Or TRP.Tipo = 9) ")
        'Session("Query") = sConsulta.ToString

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt
        Return True
    End Function

    Private Function ConsultaSumaPorRuta(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder

        Dim consultafechaVisita As String = ""
        If pvFecha Then

            consultafechaVisita = strWhereFecha(pvCondicion, "V.FechaHoraInicial")
            pvCondicion = strWhereFecha(pvCondicion, "V.FechaHoraInicial")
        End If

        If (ChBoxCentroDistribucion.Checked) Then
            pvCondicion = pvCondicion & " AND AGV.ClaveCEDI = '" + DdlCentroDistribucion.SelectedValue + "' "
        End If

        'sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        'sConsulta.AppendLine("set nocount on ")
        'sConsulta.AppendLine("select *, dbo.FNImproVentaMotClien(T.RUTClave, T.Fecha) AS Impro, ")
        'sConsulta.AppendLine("(SELECT  Count(Distinct AV.ClienteClave) ")
        'sConsulta.AppendLine("FROM AgendaVendedor AV ")
        'sConsulta.AppendLine("WHERE AV.DiaClave in( SELECT distinct TP.DiaClave ")
        'sConsulta.AppendLine("FROM TransProd TP ")
        'sConsulta.AppendLine("WHERE (FechahoraAlta BETWEEN T.Fecha AND DATEADD(dd,1,T.Fecha)) AND (TP.VisitaClave  <> '')) ")
        'sConsulta.AppendLine("AND AV.RUTClave = T.RUTClave) AS AVisitar, ")
        'sConsulta.AppendLine("(SELECT  Count(Distinct V.ClienteClave) ")
        'sConsulta.AppendLine("FROM Visita V ")
        'sConsulta.AppendLine("WHERE V.VisitaClave in(SELECT distinct TP.VisitaClave ")
        'sConsulta.AppendLine("FROM TransProd TP ")
        'sConsulta.AppendLine("WHERE (FechahoraAlta BETWEEN T.Fecha AND DATEADD(dd,1,T.Fecha)) AND (TP.VisitaClave  <> '')) ")
        'sConsulta.AppendLine("AND V.RUTClave = T.RUTClave) AS Visitados, ")
        'sConsulta.AppendLine("(SELECT  Count(distinct V.ClienteClave) ")
        'sConsulta.AppendLine("FROM ImproductividadVenta IV ")
        'sConsulta.AppendLine("INNER JOIN Visita V ON IV.Visitaclave = V.VisitaClave ")
        'sConsulta.AppendLine("WHERE IV.VisitaClave in( SELECT distinct TP.VisitaClave ")
        'sConsulta.AppendLine("FROM TransProd TP ")
        'sConsulta.AppendLine("WHERE (FechahoraAlta BETWEEN T.Fecha AND DATEADD(dd,1,T.Fecha)) AND (TP.VisitaClave  <> '')) ")
        'sConsulta.AppendLine("AND V.RUTClave = T.RUTClave) AS ImproCont, ")
        'sConsulta.AppendLine("(SELECT sum( DATEDIFF ( ss , FechaHoraInicial , FechaHoraFinal)) ")
        'sConsulta.AppendLine("FROM Visita V ")
        'sConsulta.AppendLine("WHERE V.VisitaClave in( SELECT distinct TP.VisitaClave ")
        'sConsulta.AppendLine("FROM TransProd TP ")
        'sConsulta.AppendLine("WHERE (FechahoraAlta BETWEEN T.Fecha  AND DATEADD(dd,1,T.Fecha )) AND (TP.VisitaClave  <> '')) ")
        'sConsulta.AppendLine("AND V.RUTClave = T.RUTClave) as TiempoVisita, ")
        'sConsulta.AppendLine("(SELECT DATEDIFF ( ss , min(FechaHoraInicial), max(FechaHoraFinal)) ")
        'sConsulta.AppendLine("FROM Visita V ")
        'sConsulta.AppendLine("WHERE V.VisitaClave in( SELECT distinct TP.VisitaClave ")
        'sConsulta.AppendLine("FROM TransProd TP ")
        'sConsulta.AppendLine("WHERE (FechahoraAlta BETWEEN T.Fecha  AND DATEADD(dd,1,T.Fecha )) AND (TP.VisitaClave  <> '')) ")
        'sConsulta.AppendLine("AND V.RUTClave = T.RUTClave) as TiempoRecorrido ")
        'sConsulta.AppendLine("FROM(SELECT distinct Convert(datetime,Convert(Varchar(10),TP.FechahoraAlta,103),103) As Fecha, V.RUTClave, R.Descripcion ")
        'sConsulta.AppendLine("FROM TransProd TP ")
        'sConsulta.AppendLine("inner join visita V on V.VisitaClave = TP.VisitaClave ")
        'sConsulta.AppendLine("INNER JOIN (SELECT distinct DiaClave, VendedorId, RUTClave, ClaveCEDI FROM AgendaVendedor) AGV ON AGV.DiaClave =TP.DiaClave AND AGV.VendedorId = V.VendedorId AND AGV.RUTClave=V.RUTClave ")
        'sConsulta.AppendLine("Inner Join Ruta R ON R.RUTClave = V.RUTClave ")
        'sConsulta.AppendLine(pvCondicion & " AND TP.VisitaClave <> '' )AS T ")
        'sConsulta.AppendLine("set nocount off ")

        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("SELECT T.Fecha,T.RUTClave,R.Descripcion, ")
        sConsulta.AppendLine("dbo.FNImproVentaMotClien(T.RUTClave, T.Fecha) AS Impro, ")
        sConsulta.AppendLine("(	SELECT COUNT(DISTINCT AV.clienteclave) ")
        sConsulta.AppendLine("FROM agendavendedor AV ")
        sConsulta.AppendLine("INNER JOIN visita V ON V.DiaClave = AV.DiaClave AND V.RUTClave = AV.RUTClave ")
        sConsulta.AppendLine("WHERE (V.FechahoraInicial BETWEEN T.Fecha AND DATEADD(dd,1,T.Fecha)) ")
        sConsulta.AppendLine("AND (AV.RUTClave = T.RUTClave)) AS AVisitar, ")
        sConsulta.AppendLine("(	SELECT Count(DISTINCT V.clienteclave) from visita V ")
        sConsulta.AppendLine("WHERE (V.FechahoraInicial BETWEEN T.Fecha AND DATEADD(dd,1,T.Fecha)) ")
        sConsulta.AppendLine("AND (V.RUTClave = T.RUTClave)) AS Visitados, ")
        sConsulta.AppendLine("(	SELECT  Count(distinct V.ClienteClave) ")
        sConsulta.AppendLine("FROM ImproductividadVenta IV ")
        sConsulta.AppendLine("INNER JOIN Visita V ON IV.Visitaclave = V.VisitaClave  and IV.DiaClave=V.DiaClave ")
        sConsulta.AppendLine("WHERE (V.FechahoraInicial BETWEEN T.Fecha AND DATEADD(dd,1,T.Fecha)) ")
        sConsulta.AppendLine("AND (V.RUTClave = T.RUTClave)) AS ImproCont, ")
        sConsulta.AppendLine("(	SELECT sum( DATEDIFF ( ss , FechaHoraInicial , FechaHoraFinal)) ")
        sConsulta.AppendLine("FROM Visita V ")
        sConsulta.AppendLine("WHERE (V.FechahoraInicial BETWEEN T.Fecha AND DATEADD(dd,1,T.Fecha)) ")
        sConsulta.AppendLine("AND (V.RUTClave = T.RUTClave)) as TiempoVisita, ")
        sConsulta.AppendLine("(	SELECT DATEDIFF ( ss , min(FechaHoraInicial), max(FechaHoraFinal)) ")
        sConsulta.AppendLine("FROM Visita V ")
        sConsulta.AppendLine("WHERE (V.FechahoraInicial BETWEEN T.Fecha AND DATEADD(dd,1,T.Fecha)) ")
        sConsulta.AppendLine("AND (V.RUTClave = T.RUTClave)) as TiempoRecorrido ")
        sConsulta.AppendLine("FROM (	SELECT Convert(datetime,Convert(Varchar(10),V.FechaHoraInicial,103),103) As Fecha,V.RUTClave ")
        sConsulta.AppendLine("FROM Visita V ")
        sConsulta.AppendLine("INNER JOIN AgendaVendedor AGV ON AGV.DiaClave =V.DiaClave AND AGV.RUTClave=V.RUTClave ")
        sConsulta.AppendLine(pvCondicion & " group by Convert(datetime,Convert(Varchar(10),V.FechaHoraInicial,103),103),V.RUTClave)AS T ")
        sConsulta.AppendLine("Inner Join Ruta R ON R.RUTClave = T.RUTClave  ")
        sConsulta.AppendLine("order by Fecha, T.RutClave ")

        sConsulta.AppendLine("set nocount off ")

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt
        sConsulta = New StringBuilder()

        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("SELECT Fecha,RUTClave, Nombre,Sum(KiloLitros) as Kilolitros,sum(((TPDSubTotal - DescuentoImp - DescuentoCliente) - ((TPDSubTotal - DescuentoCliente) * DescVendPor / 100) + (Impuesto - (Impuesto * DescVendPor / 100)))) as Total, count(distinct clienteclave) as cantidad FROM ")
        sConsulta.AppendLine("(SELECT  Convert(datetime,Convert(Varchar(10),TP.FechahoraAlta,103),103) As Fecha,TP.FechahoraAlta, V.RUTClave, E.Nombre, (TPD.Cantidad * PU.KgLts) AS KiloLitros, ")
        sConsulta.AppendLine("(TPD.Precio * TPD.Cantidad) as TPDSubTotal, TPD.DescuentoImp , ")
        sConsulta.AppendLine("(SELECT (CASE WHEN sum(DesImporte) IS NULL THEN 0 ELSE sum(DesImporte) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) as DescuentoCliente, ")
        sConsulta.AppendLine("(TPD.Impuesto - (SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE sum(DesImpuesto) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId)) as Impuesto, ")
        sConsulta.AppendLine("TP.DescVendPor, TP.clienteclave FROM TransProd TP ")
        sConsulta.AppendLine("INNER JoiN Visita V ON V.VisitaClave = TP.VisitaClave and V.DiaClave = TP.DiaClave ")
        sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD ON TP.TransProdID = TPD.TransProdID ")
        sConsulta.AppendLine("INNER JOIN Producto P ON P.ProductoClave = TPD.ProductoClave ")
        sConsulta.AppendLine("INNER JOIN ProductoEsquema PE ON PE.ProductoClave = TPD.ProductoClave ")
        sConsulta.AppendLine("INNER JOIN ProductoUnidad PU ON PU.ProductoClave = TPD.ProductoClave AND PU.PRUTipoUnidad = TPD.TipoUnidad ")
        sConsulta.AppendLine("INNER JOIN Esquema E ON E.EsquemaId = PE.Esquemaid AND E.EsquemaIDPadre is NULL and E.Tipo = 2 ")
        sConsulta.AppendLine("WHERE TP.Tipo = 1 and TP.TipoFase = 2 " & strWhereFecha("", "TP.FechaHoraAlta", True) & " ) AS A ")
        sConsulta.AppendLine("Group By Fecha,RUTClave, Nombre ")
        sConsulta.AppendLine("set nocount off ")

        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        Session("DataTable1") = dt

        sConsulta = New StringBuilder()
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("SELECT  Cast(IV.TipoMotivo as varchar(20))+' - '+ VR.Descripcion ")
        sConsulta.AppendLine("FROM ImproductividadVenta IV ")
        sConsulta.AppendLine("INNER JOIN Visita V ON IV.Visitaclave = V.VisitaClave and IV.DiaClave=V.DiaClave ")
        sConsulta.AppendLine("inner join VAVDescripcion VR on VR.varcodigo = 'MOTIMPRO' AND VR.VAVClave = IV.TipoMotivo AND VADTipoLenguaje = '" + Session("lenguaje").ToString() + "' ")
        sConsulta.AppendLine(consultafechaVisita)
        sConsulta.AppendLine(" GROUP BY IV.TipoMotivo,VR.Descripcion ")
        sConsulta.AppendLine("set nocount off ")

        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        Dim motsnocompra As String = ""
        For Each fila As Data.DataRow In dt.Rows
            motsnocompra &= fila(0).ToString() + ", "
        Next

        If (motsnocompra.Length > 2) Then
            motsnocompra = motsnocompra.Substring(0, motsnocompra.Length - 2)
        End If

        Session("DataTable2") = motsnocompra

        Return True
    End Function

    Private Function ConsultaAgrupadoPorFamilia(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder

        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "TRP.FechaHoraAlta")
        End If
        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "VIS.RUTClave")
        'pvCondicion = strWhereClientes(pvCondicion, pvClientes, "CLI.ClienteClave")
        If (ChBoxCentroDistribucion.Checked) Then
            pvCondicion = pvCondicion & " AND ALM.Clave = '" + DdlCentroDistribucion.SelectedValue + "' "
        End If

        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("SELECT (RUT.RUTClave + ' - ' + RUT.Descripcion) AS RUTNombre, (CLI.ClienteClave + ' - ' + CLI.RazonSocial) AS CLINombre, ")
        sConsulta.AppendLine("ESQ.Nombre AS ESQNombre, (PRD.Factor * TRD.Cantidad) AS Cantidad ")
        sConsulta.AppendLine("FROM TransProd TRP ")
        sConsulta.AppendLine("INNER JOIN Visita VIS ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave ")
        sConsulta.AppendLine("INNER JOIN Ruta RUT ON RUT.RUTClave=VIS.RUTClave ")
        sConsulta.AppendLine("INNER JOIN Cliente CLI ON CLI.ClienteClave = VIS.ClienteClave ")
        sConsulta.AppendLine("INNER JOIN (SELECT DISTINCT DiaClave, VendedorId, RUTClave, ClaveCEDI FROM AgendaVendedor) AGV ON AGV.DiaClave =TRP.DiaClave AND AGV.VendedorId = VIS.VendedorId AND AGV.RUTClave=VIS.RUTClave ")
        sConsulta.AppendLine("INNER JOIN Almacen ALM ON ALM.Clave = AGV.ClaveCEDI ")
        sConsulta.AppendLine("INNER JOIN TransProdDetalle TRD ON TRD.TransProdID=TRP.TransProdId ")
        sConsulta.AppendLine("INNER JOIN ProductoEsquema PRE ON PRE.ProductoClave=TRD.ProductoClave ")
        sConsulta.AppendLine("INNER JOIN Esquema ESQ ON ESQ.EsquemaId=PRE.EsquemaID AND ESQ.Tipo=2 AND ESQ.TipoEstado=1 AND ESQ.Baja=0 AND ESQ.Orden=1 ")
        'sConsulta.AppendLine("INNER JOIN Esquema ESQ ON ESQ.EsquemaId=PRE.EsquemaID AND ESQ.Tipo=2 AND ESQ.TipoEstado=1 AND ESQ.Baja=0 ")
        sConsulta.AppendLine("INNER JOIN ProductoDetalle PRD ON PRD.ProductoClave=TRD.ProductoClave AND PRD.PRUTipoUnidad=TRD.TipoUnidad AND PRD.ProductoClave = PRD.ProductoDetClave ")
        sConsulta.AppendLine(pvCondicion & " AND TRP.Tipo = 1 And TRP.TipoFase <> 0 and trd.promocion<>2 ")
        sConsulta.AppendLine("set nocount off ")

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        Return True
    End Function

    Private Function ConsultaDetalladoxFamilia(ByVal ins As DBConexion.cConexionSQL, ByVal pvRutas As ArrayList, ByVal pvEsquemas As ArrayList, ByVal pvClientes As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        Dim sCondicion As String = String.Empty
        If pvFecha Then
            sCondicion = strWhereFecha(sCondicion, "TRP.FechaHoraAlta")
        End If
        sCondicion = strWhereClientes(sCondicion, pvClientes, "CLI.ClienteClave")
        sCondicion = strWhereRutas(sCondicion, pvRutas, "VIS.RUTClave")
        sCondicion = strWhereCentrosDistribucion(sCondicion, "AGV.ClaveCEDI")
        sCondicion = strWhereEsquema(sCondicion, pvEsquemas, "ESQ.EsquemaID")

        'If (ChBoxCentroDistribucion.Checked) Then
        '    sCondicionALN = "where ALN.Clave = '" + DdlCentroDistribucion.SelectedValue + "' "
        'End If

        'sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("Select VIS.RUTClave + ' ' + RUT.Descripcion as Ruta,ESQ.Clave as EsquemaClave,ESQ.Nombre as EsquemaNombre, ")
        sConsulta.AppendLine("CLI.Clave + ' - ' + CLI.RazonSocial as Cliente, PRO.ProductoClave + ' - '  + PRO.Nombre as Producto, sum(TPD.Cantidad * PRD.Factor) as Cantidad ")
        sConsulta.AppendLine("from TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ")
        sConsulta.AppendLine("inner join Ruta RUT on RUT.RUTClave = VIS.RUTClave ")
        sConsulta.AppendLine("inner join AgendaVendedor AGV on  VIS.ClienteClave = AGV.ClienteClave and VIS.DiaClave = AGV.DiaClave and VIS.VendedorID = AGV.VendedorID and VIS.RUTClave = AGV.RUTClave ")
        sConsulta.AppendLine("inner join Cliente CLI on CLI.ClienteClave = VIS.ClienteClave ")
        sConsulta.AppendLine("inner join TransProdDetalle TPD on TPD.TransProdID = TRP.TransProdID ")
        sConsulta.AppendLine("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ")
        sConsulta.AppendLine("inner join ProductoEsquema PRS on PRS.ProductoClave = PRO.ProductoClave ")
        sConsulta.AppendLine("inner join Esquema ESQ on PRS.EsquemaID = ESQ.EsquemaID and ESQ.Tipo = 2 and ESQ.TipoEstado = 1 and ESQ.Baja = 0 and ESQ.Orden = 1 ")
        sConsulta.AppendLine("inner join ProductoDetalle PRD on PRD.ProductoClave = TPD.ProductoClave and PRD.PRUTipoUnidad = TPD.TipoUnidad and PRD.ProductoDetClave = TPD.ProductoClave ")
        sConsulta.AppendLine("where TRP.Tipo = 1 and TRP.TipoFase <> 0 and tpd.promocion<>2 ")

        sConsulta.AppendLine(sCondicion)

        sConsulta.AppendLine("group by VIS.RUTClave + ' ' + RUT.Descripcion,ESQ.Clave,ESQ.Nombre,CLI.Clave + ' - ' + CLI.RazonSocial,PRO.ProductoClave + ' - ' + PRO.Nombre ")

        sConsulta.AppendLine("set nocount off ")

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        Return True
    End Function

    Private Function ConsultaPromociones(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvCobrarVentas As Boolean, ByVal pvRutas As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        Dim sConsultaAnio As New StringBuilder
        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "TRP.FechaHoraAlta")
        End If
        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "VIS.RUTClave")
        pvCondicion = strWhereCentrosDistribucion(pvCondicion, "AGV.ClaveCEDI")

        'sConsulta.AppendLine("SET ANSI_WARNINGS OFF set nocount on SELECT ALMNombre,RUTClave,FechaHoraAlta,MesAnio,Mes,USUClave,VENNombre,Cuota,Total,(CASE cuota WHEN 0 THEN 0 ELSE ((Total/Cuota)*100) END) as PorAvance,(Cuota-Total) as DifMeta,ImpPromocion,(Total-ImpPromocion) as DifPromocion,(Total/ImpPromocion) as PorPromocion FROM (SELECT 	ALMNombre,	RUTClave,	FechaHoraAlta,	MesAnio,	Mes,	USUClave,	VENNombre,		(SELECT CASE WHEN Min(CUV.Minimo) IS NULL THEN 0 ELSE Min(CUV.Minimo) END FROM CUOVEN CUV 		INNER JOIN Cuota CUO ON CUO.CUOClave=CUV.CUOClave WHERE CUO.FechaInicio <= FechaHoraAlta AND CUO.FechaFin >= FechaHoraAlta AND CUV.VendedorId = Resultado.VendedorId AND CUV.Tipo=2 AND CUV.Estado=1) as Cuota,	 SUM(Total) as Total,	 SUM(ImpPromocion) as ImpPromocion,	(SUM(Total)-SUM(ImpPromocion)) as DifPromocion,	(SUM(Total)/SUM(ImpPromocion)) as PorPromocion  FROM	( SELECT ALMNombre,	RUTClave, TransProdId,FechaHoraAlta,MesAnio,(SELECT Descripcion FROM VAVDescripcion WHERE VARCodigo='MES' AND VAVClave=Mes AND VADTipoLenguaje='EM') as Mes,USUClave,VendedorId,VENNombre,sum(Total) as Total,SUM(ImpPromocion) as ImpPromocion FROM( SELECT distinct (TRP.TransProdId),Alm.Clave+' '+ALM.Nombre as ALMNombre,AGV.RUTClave, Convert(VarChar(20), TRP.FechaHoraAlta,110) as FechaHoraAlta,(DatePart(mm,TRP.FechaHoraAlta)) as Mes, (ltrim(str(DatePart(yyyy,TRP.FechaHoraAlta))) + ltrim(str(DatePart(mm,TRP.FechaHoraAlta)))) as MesAnio, USU.Clave as USUClave,VEN.VendedorId, VEN.Nombre AS VENNombre, TRP.Total,(SELECT sum( PPV.Precio*tpd.cantidad) FROM PrecioProductoVig PPV INNER JOIN TransProdDetalle TPD ON TPD.TransProdId=TRP.TransProdId AND TPD.Promocion=1 AND TPD.Precio=0 WHERE PPV.PPVFechaInicio <= TRP.FechaHoraAlta AND PPV.FechaFin >= TRP.FechaHoraAlta AND PPV.ProductoClave=TPD.ProductoClave) as ImpPromocion FROM TransProd TRP INNER JOIN Visita VIS ON VIS.VisitaClave=TRP.VisitaClave AND VIS.DiaClave=TRP.DiaClave INNER JOIN Vendedor VEN ON VEN.VendedorId=VIS.VendedorId iNNER JOIN Usuario USU ON USU.USUId=VEN.USUId INNER Join (SELECT DISTINCT DiaClave, VendedorId, RUTClave, ClaveCEDI FROM AgendaVendedor) AGV ON AGV.DiaClave =TRP.DiaClave AND AGV.VendedorId = VIS.VendedorId AND AGV.RUTClave=VIS.RUTClave INNER JOIN Almacen ALM ON ALM.Clave=AGV.ClaveCEDI ")

        sConsulta.AppendLine("SET ANSI_WARNINGS OFF  ")
        sConsulta.AppendLine("set nocount on  ")
        sConsulta.AppendLine("SELECT ALMNombre,RUTClave,FechaHoraAlta,MesAnio,Mes,USUClave,VENNombre,CUOClave as clavecuota,Cuota,Total, ")
        sConsulta.AppendLine("(CASE cuota WHEN 0 THEN 0 ELSE ((Total/Cuota)*100) END) as PorAvance, ")
        sConsulta.AppendLine("(Cuota-Total) as DifMeta,ImpPromocion,(Total-ImpPromocion) as DifPromocion,(CASE Total WHEN 0 THEN 0 ELSE (ImpPromocion/Total*100) END) as PorPromocion  ")
        sConsulta.AppendLine("FROM ")
        sConsulta.AppendLine("(SELECT ALMNombre, RUTClave, FechaHoraAlta, MesAnio, Mes, USUClave, VENNombre,  ")
        sConsulta.AppendLine("CUO.CUOClave,	(CASE WHEN Min(CUV.Minimo) IS NULL THEN 0 ELSE Min(CUV.Minimo) END  )	 as Cuota,  ")
        sConsulta.AppendLine("SUM(Total) as Total, SUM(ImpPromocion) as ImpPromocion,	(SUM(Total)-SUM(ImpPromocion)) as DifPromocion,	 ")
        sConsulta.AppendLine("(SUM(Total)/SUM(ImpPromocion)) as PorPromocion ")
        sConsulta.AppendLine("FROM ")

        sConsulta.AppendLine("(SELECT TransProdId ,ALMNombre,RUTClave, FechaHoraAlta, 	 ")
        sConsulta.AppendLine("(SELECT Descripcion FROM VAVDescripcion WHERE VARCodigo='MES' AND VAVClave=Mes AND VADTipoLenguaje='" & Session("lenguaje") & "') as Mes, ")
        sConsulta.AppendLine("MesAnio,USUClave,VendedorId, VENNombre, avg(Total) as Total, (sum(ImpTot) + sum(Impuesto) -(CASE WHEN sum(ImpTot) >0 THEN dbo.FNCalcularDescuentoCliente(ClienteClave, sum(ImpTot), sum(Impuesto), avg(DescVendPor)) ELSE 0 END)) as ImpPromocion ")
        sConsulta.AppendLine("FROM( SELECT TransProdId ,ALMNombre,RUTClave, Convert(VarChar(20), FechaHoraAlta,110) as FechaHoraAlta, Mes, MesAnio,USUClave,VendedorId, VENNombre, Total, ImpTot, ")
        sConsulta.AppendLine("( dbo.FNCalcularImpuesto(ProductoClave, ClienteClave, FechaHoraAlta, ImpTot))as Impuesto,ClienteClave, DescVendPor ")
        sConsulta.AppendLine("FROM(SELECT TRP.TransProdId ,Alm.Clave+' '+ALM.Nombre as ALMNombre,AGV.RUTClave, TRP.FechaHoraAlta as FechaHoraAlta,  ")
        sConsulta.AppendLine("(DatePart(mm,TRP.FechaHoraAlta)) as Mes,(ltrim(str(DatePart(yyyy,TRP.FechaHoraAlta))) + ltrim(str(DatePart(mm,TRP.FechaHoraAlta)))) as MesAnio,  ")
        sConsulta.AppendLine("USU.Clave as USUClave,VEN.VendedorId, VEN.Nombre AS VENNombre, TRP.Total,  ")
        sConsulta.AppendLine("(	CASE WHEN TPD.Promocion=2 THEN (dbo.FNCalculaImporteProductoPromocion(TPD.ProductoClave,TPD.TipoUnidad,VIS.VendedorId,TRP.ClienteClave, ")
        sConsulta.AppendLine("TRP.PCEModuloMovDetClave, TRP.FechaHoraAlta, TPD.Cantidad,(TPD.Cantidad * dbo.FNObtenerPrecio(TRP.PCEPrecioClave, TPD.ProductoClave, TPD.TipoUnidad, TRP.FechaHoraAlta) ))) ELSE 0 END) as ImpTot, ")
        sConsulta.AppendLine("VIS.ClienteClave, TPD.ProductoClave, TRP.DescVendPor ")
        sConsulta.AppendLine("FROM TransProd TRP ")
        sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD ON TPD.TransProdId=TRP.TransProdId ")
        sConsulta.AppendLine("INNER JOIN Visita VIS ON VIS.VisitaClave=TRP.VisitaClave AND VIS.DiaClave=TRP.DiaClave  ")
        sConsulta.AppendLine("INNER JOIN Vendedor VEN ON VEN.VendedorId=VIS.VendedorId  ")
        sConsulta.AppendLine("INNER JOIN Usuario USU ON USU.USUId=VEN.USUId  ")
        sConsulta.AppendLine("INNER JOIN (SELECT DISTINCT DiaClave, VendedorId, RUTClave, ClaveCEDI FROM AgendaVendedor) AGV ON AGV.DiaClave =TRP.DiaClave AND AGV.VendedorId = VIS.VendedorId AND AGV.RUTClave=VIS.RUTClave ")
        sConsulta.AppendLine("INNER JOIN Almacen ALM ON ALM.Clave=AGV.ClaveCEDI ")


        sConsulta.AppendLine(pvCondicion)
        'If Not pvCobrarVentas Then 'Facturas
        '    sConsulta.AppendLine(" AND TRP.Tipo=8 AND TRP.TipoFase in (1,2)  ) AS Resultado GROUP BY ALMNombre, RUTClave, TransProdId, FechaHoraAlta, MesAnio, Mes, USUClave, VendedorId, VENNombre ) AS Resultado GROUP BY ALMNombre, RUTClave, FechaHoraAlta, MesAnio, Mes, USUClave, VendedorId, VENNombre ) AS Resultado ")
        'Else
        sConsulta.AppendLine(" AND TRP.Tipo = 1 And TRP.TipoFase <> 0 ) as Resul ) AS Resultado GROUP By TransProdId ,ALMNombre,RUTClave, FechaHoraAlta, Mes, MesAnio,USUClave,VendedorId, VENNombre, ClienteClave ) AS Resultado  inner join CUOVEN CUV ON CUV.VendedorId = Resultado.VendedorId	INNER JOIN Cuota CUO ON CUO.CUOClave=CUV.CUOClave  	WHERE CUO.FechaInicio <= FechaHoraAlta AND CUO.FechaFin >= FechaHoraAlta AND CUV.Tipo=2 AND CUV.Estado=1  GROUP BY ALMNombre, RUTClave, FechaHoraAlta, MesAnio, Mes, USUClave, RESULTADO.VendedorId, VENNombre,CUO.CUOClave ) AS Resultado ")
        'End If
        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        Return True
    End Function

    Private Function ConsultaDiarioActividades(ByVal ins As DBConexion.cConexionSQL, ByVal pvRutas As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        Dim sCondicion As String
        Dim sCondicionVis As String
        Dim sCondicionNoVis As String

        If chboxVendedor.Checked Then
            sCondicion = "where VendedorId = '" + ddlVendedor.Text + "' "
            sCondicionVis = "where VEN.VendedorId = '" + ddlVendedor.Text + "' "
            sCondicionNoVis = "where VEN.VendedorId = '" + ddlVendedor.Text + "' "
        Else
            sCondicion = "where 1 = 1 "
            sCondicionVis = "where 1 = 1 "
            sCondicionNoVis = "where 1 = 1 "
        End If

        If pvFecha Then
            sCondicion = strWhereFecha(sCondicion, "convert(datetime, DiaClave, 103)")
            sCondicionVis = strWhereFecha(sCondicionVis, "VIS.FechaHoraInicial")
            sCondicionNoVis = strWhereFecha(sCondicionNoVis, "convert(datetime, AGV.DiaClave, 103)")
        End If

        sCondicion = strWhereRutas(sCondicion, pvRutas, "RUTClave")
        sCondicionVis = strWhereRutas(sCondicionVis, pvRutas, "VIS.RUTClave")
        sCondicionNoVis = strWhereRutas(sCondicionNoVis, pvRutas, "AGV.RUTClave")

        sCondicion = strWhereCentrosDistribucion(sCondicion, "ClaveCEDI")
        sCondicionVis = strWhereCentrosDistribucion(sCondicionVis, "alm.Clave")
        sCondicionNoVis = strWhereCentrosDistribucion(sCondicionNoVis, "AGV.ClaveCEDI")

        sConsulta.AppendLine("select * from AgendaVendedor ")
        sConsulta.AppendLine(sCondicion & " ")
        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If

        '--Visitados
        sConsulta = New StringBuilder
        sConsulta.AppendLine("set ansi_warnings off ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("if (select object_id('tempdb..#TmpDiario')) is not null drop table #TmpDiario ")
        sConsulta.AppendLine("select * into #TmpDiario from( select ALM.Clave as ALMClave, ALM.Nombre as ALMNombre, VEN.Nombre as VENNombre, RUT.RUTClave, RUT.Descripcion as RUTDescripcion, SEC.Orden as SECOrden, cli.Clave as clienteclave, cli.clienteClave as clienteclaver, CLI.RazonSocial as CLIRazonSocial, VIS.FueraFrecuencia, VIS.CodigoLeido, VIS.FechaHoraInicial, VIS.FechaHoraFinal, VIS.VisitaClave, case when VEN.JornadaTrabajo = 1 then isnull(VEJ.VEJFechaInicial,VIS.FechaHoraInicial) else VIS.FechaHoraInicial end as HoraInicialJornada, case when VEN.JornadaTrabajo = 1 then isnull(VEJ.FechaFinal,VIS.FechaHoraFinal) else VIS.FechaHoraFinal end as HoraFinalJornada from Visita VIS inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId left join VendedorJornada VEJ on VEN.VendedorId = VEJ.VendedorId and VIS.DiaClave = VEJ.DiaClave AND VEJ.DiaClave is not null LEFT join (select distinct DiaClave, VendedorId, RUTClave, ClienteClave, ClaveCEDI,frecuenciaclave from AgendaVendedor) AGV on VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorId and VIS.RutClave = AGV.RutClave and VIS.ClienteClave = AGV.ClienteClave INNER JOIN vencentrodisthist  VENCEN    on vis.fechahorainicial between vencen.vchfechainicial and vencen.fechafinal and VENCEN.vendedorid=Ven.vendedorid inner join Almacen ALM on VENCen.almacenid = ALM.almacenid inner join Ruta RUT on VIS.RUTClave = RUT.RUTClave inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave LEFT join   Secuencia SEc on SEc.RUTClave = RUT.RUTClave and SEc.ClienteClave = CLI.ClienteClave and agv.frecuenciaclave=sec.frecuenciaclave ")
        sConsulta.AppendLine(sCondicionVis & " ")
        sConsulta.AppendLine(")as t1 ")
        sConsulta.AppendLine("select cast(floor(cast(FechaHoraInicial as float)) as datetime) as Fecha, ALMClave + ' ' + ALMNombre as CEDI, VENNombre as Vendedor, ")
        sConsulta.AppendLine("RUTClave + ' ' + RUTDescripcion as Ruta, SECOrden as Secuencia, ClienteClave as Clave, CLIRazonSocial as NombreCliente, ")
        sConsulta.AppendLine("FueraDeFrecuencia = (select case when FueraFrecuencia = 1 then '*' else '' end), ")
        sConsulta.AppendLine("ImpFueraDeFrecuencia = (select case when FueraFrecuencia = 1 then 1 else 0 end), ")
        sConsulta.AppendLine("CodigoNoLeido = (select case when CodigoLeido = 0 then '*' else '' end), ")
        sConsulta.AppendLine("ImpCodigoNoLeido = (select case when CodigoLeido = 0 then 1 else 0 end), ")
        sConsulta.AppendLine("FechaHoraInicial as HoraInicio, FechaHoraFinal as HoraFin, datediff(s, FechaHoraInicial, FechaHoraFinal) as SegundosVisita, ")
        sConsulta.AppendLine("(select top 1 case when count(*) > 0 then 'SI' else 'NO' end from TransProd TRP where TRP.Tipo = 1 and TRP.TipoFase <> 0 and TRP.VisitaClave = TMP.VisitaClave and TRP.ClienteClave = TMP.ClienteClaver) as Venta, ")
        sConsulta.AppendLine("convert(varchar(25), isnull((select VAD.Descripcion from ImproductividadVenta IMV inner join VAVDescripcion VAD on IMV.TipoMotivo = VAD.VAVClave where IMV.VisitaClave = TMP.VisitaClave and VAD.VARCodigo = 'MOTIMPRO' and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "'), '')) as Concepto, ")
        sConsulta.AppendLine("(select sum(TRP.Total) from TransProd TRP where TRP.Tipo = 1 and TRP.TipoFase <> 0 and TRP.VisitaClave = TMP.VisitaClave and TRP.ClienteClave = TMP.ClienteClaver) as TotalVenta, HoraInicialJornada, HoraFinalJornada  ")
        sConsulta.AppendLine("from #TmpDiario TMP ")
        sConsulta.AppendLine("group by convert(varchar(10), FechaHoraInicial, 103), ALMClave, ALMNombre, VENNombre, RUTClave, RUTDescripcion, SECOrden, ClienteClave, ClienteClaver, CLIRazonSocial, ")
        sConsulta.AppendLine("FueraFrecuencia, CodigoLeido, FechaHoraInicial, FechaHoraFinal, VisitaClave, HoraInicialJornada, HoraFinalJornada ")
        sConsulta.AppendLine("order by FechaHoraInicial ")
        sConsulta.AppendLine("drop table #TmpDiario ")
        sConsulta.AppendLine("set nocount off ")
        Session("Visitados") = sConsulta.ToString

        '--No Visitados
        sConsulta = New StringBuilder
        sConsulta.AppendLine("select cast(floor(cast(Dia.FechaCaptura as float)) as datetime) as Fecha, (ALM.Clave + ' ' + ALM.Nombre) as CEDI, VEN.Nombre as Vendedor, (AGV.RUTClave + ' ' + RUT.Descripcion) as Ruta,  (SELECT TOP 1 ORDEN FROM SECUENCIA SEC WHERE SEC.RUTClave = AGV.RUTClave and SEC.ClienteClave = AGV.ClienteClave and  agv.frecuenciaclave=sec.frecuenciaclave) as Secuencia,  CLI.Clave as Clave, CLI.RazonSocial as NombreCliente  from (SELECT Distinct frecuenciaclave, RUTClave, DiaClave, ClaveCEDI, VendedorId, ClienteClave FROM  AgendaVendedor ) AGV inner join Dia on Dia.DiaClave = AGV.DiaClave inner join Almacen ALM on AGV.ClaveCEDI = ALM.Clave inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave  ")
        sConsulta.AppendLine(sCondicionNoVis & " ")
        sConsulta.AppendLine("and AGV.ClienteClave not in (select distinct ClienteClave from Visita VIS where AGV.DiaClave = convert(varchar(10), vis.FechaHoraInicial, 103) and AGV.VendedorId = VIS.VendedorId and AGV.RUTClave = VIS.RUTClave and AGV.ClienteClave = VIS.ClienteClave) ")
        sConsulta.AppendLine("order by SECUENCIA ")
        Session("NoVisitados") = sConsulta.ToString

        '--Totales
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("select * into #TmpDiario from( select Dia.FechaCaptura as Fecha, AGV.DiaClave, AGV.ClaveCEDI, ALM.Nombre as ALMNombre, AGV.VendedorId, VEN.Nombre as VENNombre, AGV.RutClave, RUT.Descripcion as RUTDescripcion, vis.ClienteClave as AGVClienteClave from visita vis left join (select distinct DiaClave, ClaveCEDI, VendedorId, RUTClave, ClienteClave from AgendaVendedor) AGV  on agv.vendedorid=vis.vendedorid and agv.diaclave=vis.diaclave inner join Vendedor VEN on vis.VendedorId = VEN.VendedorId inner join Dia on Dia.DiaClave = vis.DiaClave left join Almacen ALM on AGV.ClaveCEDI = ALM.Clave left join Ruta RUT on AGV.RUTClave = RUT.RUTClave ")
        sConsulta.AppendLine(sCondicionNoVis & " and vis.diaclave=convert(varchar(10), vis.FechaHoraInicial, 103)")
        sConsulta.AppendLine(")as t1 ")
        sConsulta.AppendLine("select distinct cast(floor(cast(TMP.Fecha as float)) as datetime) as Fecha, TMP.ClaveCEDI + ' ' + TMP.ALMNombre as CEDI, TMP.VENNombre as Vendedor, TMP.RutClave + ' ' + TMP.RUTDescripcion as Ruta, TMP.AGVClienteClave, case when VIS.CodigoLeido = 0 then VIS.ClienteClave else NULL end as CodigoNoLeido, case when VIS.FueraFrecuencia = 0 then VIS.ClienteClave else NULL end as VISClienteClave, case when VIS.FueraFrecuencia = 1 then VIS.ClienteClave else NULL end as VISClienteClaveFF, case when VIS.FueraFrecuencia = 0 then (case when TRP.TransProdId is null then TRP.TransProdId else VIS.ClienteClave end) else NULL end as VTAClienteClave, case when VIS.FueraFrecuencia = 1 then (case when TRP.TransProdId is null then TRP.TransProdId else VIS.ClienteClave end) else NULL end as VTAClienteClaveFF from #TmpDiario TMP left join Visita VIS on TMP.DiaClave = VIS.DiaClave and TMP.AGVClienteClave = VIS.ClienteClave and TMP.VendedorId = VIS.VendedorId and TMP.RutClave = VIS.RutClave left join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and trp.tipo=1 and trp.tipofase<>0 order by cast(floor(cast(TMP.Fecha as float)) as datetime), TMP.ClaveCEDI + ' ' + TMP.ALMNombre, TMP.VENNombre, TMP.RutClave + ' ' + TMP.RUTDescripcion ")
        sConsulta.AppendLine("drop table #TmpDiario ")
        sConsulta.AppendLine("set nocount off ")
        Session("Totales") = sConsulta.ToString

        '--Cuotas
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("if (select object_id('tempdb..#TmpDiario')) is not null drop table #TmpDiario ")
        sConsulta.AppendLine("select * into #TmpDiario from( ")
        sConsulta.AppendLine("select Dia.FechaCaptura as Fecha, AGV.DiaClave, AGV.ClaveCEDI, ALM.Nombre as ALMNombre, AGV.VendedorId, VEN.Nombre as VENNombre, ")
        sConsulta.AppendLine("AGV.RutClave, RUT.Descripcion as RUTDescripcion ")
        sConsulta.AppendLine("from (select distinct DiaClave, ClaveCEDI, VendedorId, RUTClave from AgendaVendedor) AGV ")
        sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ")
        sConsulta.AppendLine("inner join Dia on Dia.DiaClave = AGV.DiaClave ")
        sConsulta.AppendLine("inner join Almacen ALM on AGV.ClaveCEDI = ALM.Clave ")
        sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave ")
        sConsulta.AppendLine(sCondicionNoVis & " ")
        '--where 
        sConsulta.AppendLine(")as t1 ")
        sConsulta.AppendLine("select distinct cast(floor(cast(TMP.Fecha as float)) as datetime) as Fecha, ClaveCEDI + ' ' + ALMNombre as CEDI, VENNombre as Vendedor, ")
        sConsulta.AppendLine("RUTClave + ' ' + RUTDescripcion as Ruta, sum(CUV.Minimo) as Meta, sum(CUC.Cantidad) as Acumulado, ")
        sConsulta.AppendLine("sum( CUV.Minimo - CUC.Cantidad ) as Diferencia, ")
        sConsulta.AppendLine("max(case when datediff(d, getdate(), CUO.FechaFin) < 0 then 0 else datediff(d, getdate(), CUO.FechaFin) end) as RestoDias ")
        sConsulta.AppendLine("from #TmpDiario TMP ")
        sConsulta.AppendLine("inner join CuoVen CUV on TMP.VendedorId = CUV.VendedorId and CUV.Tipo= 2 and CUV.Estado = 1 ")
        sConsulta.AppendLine("inner join Cuota CUO on CUV.CUOClave = CUO.CUOClave and CUO.Estado = 1 and CUO.Baja = 0 and TMP.Fecha between CUO.FechaInicio and CUO.FechaFin ")
        sConsulta.AppendLine("inner join CuotaCumplida CUC on CUO.CUOClave = CUC.CUOClave AND CUV.VendedorId = CUC.VendedorId ")
        sConsulta.AppendLine("group by cast(floor(cast(TMP.Fecha as float)) as datetime), ClaveCEDI + ' ' + ALMNombre, VENNombre, RUTClave + ' ' + RUTDescripcion ")

        sConsulta.AppendLine("drop table #TmpDiario ")
        sConsulta.AppendLine("set nocount off ")
        Session("Cuotas") = sConsulta.ToString

        Return True
    End Function

    Private Function ConsultaVentaDiario(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder

        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "TRP.FechaHoraAlta")
        End If
        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "VIS.RUTClave")
        If (ChBoxCentroDistribucion.Checked) Then
            pvCondicion = pvCondicion & " AND ALM.Clave = '" + DdlCentroDistribucion.SelectedValue + "' "
        End If

        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")

        'sConsulta.AppendLine("SELECT ALMClave, ALMNombre, RUTClave, VendedorId, VENNombre, EsquemaId, ESQNombre, FechaHoraAlta, ProductoClave, PRONombre, AVG(Precio) as Precio, TotalClientesEnRuta, ")
        'sConsulta.AppendLine("ClientesVentaEnRuta, SUM(PiezasEnRuta) as PiezasEnRuta, SUM(TotalEnRuta) as TotalEnRuta, TotalClienteFueraRuta, ")
        'sConsulta.AppendLine("ClientesVentaFueraRuta, SUM(PiezasFueraRuta) as PiezasFueraRuta, SUM(TotalFueraRuta) as TotalFueraRuta FROM ")
        'sConsulta.AppendLine("( ")
        'sConsulta.AppendLine("SELECT ALM.Clave as ALMClave, ALM.Nombre as ALMNombre, AGV.RUTClave, VEN.VendedorId, VEN.Nombre as VENNombre, ESQ.EsquemaId, ESQ.Nombre as ESQNombre, Convert(VarChar(20), TRP.FechaHoraAlta,110) as FechaHoraAlta, TPD.ProductoClave, PRO.Nombre as PRONombre, TPD.Precio, ")
        'sConsulta.AppendLine("(SELECT Count(*) FROM AgendaVendedor AGV2 WHERE AGV2.DiaClave =TRP.DiaClave AND AGV2.VendedorId = VIS.VendedorId AND AGV2.RUTClave=VIS.RUTClave AND AGV2.ClaveCEDI=ALM.Clave) as TotalClientesEnRuta, ")
        'sConsulta.AppendLine("(SELECT Count(*) FROM Visita VIS2 ")
        'sConsulta.AppendLine("INNER JOIN TransProd TRP2 ON TRP2.VisitaClave=VIS2.VisitaClave AND TRP2.DiaClave=VIS2.DiaClave AND TRP2.Tipo=1 AND TRP2.TipoFase<>0 AND Convert(VarChar(20), TRP2.FechaHoraAlta,110)=Convert(VarChar(20), TRP.FechaHoraAlta,110) AND TRP2.TransProdId IN (SELECT TransProdId FROM TransProdDetalle TPD2 WHERE TPD2.ProductoClave=TPD.ProductoClave AND TPD2.Precio<>0 AND TPD2.Subtotal<>0 AND TPD2.Total<>0) ")
        'sConsulta.AppendLine("WHERE VIS2.DiaClave = VIS.DiaClave And VIS2.VendedorId = VIS.VendedorId And VIS2.RUTClave = VIS.RUTClave And VIS2.FueraFrecuencia = 0 ")
        'sConsulta.AppendLine(") as ClientesVentaEnRuta, ")
        'sConsulta.AppendLine("(CASE VIS.FueraFrecuencia WHEN 0 THEN (TPD.Cantidad * PRD.Factor) ELSE 0 END) as PiezasEnRuta, ")
        'sConsulta.AppendLine("(CASE VIS.FueraFrecuencia WHEN 0 THEN  ")
        'sConsulta.AppendLine("((TPD.Precio * TPD.Cantidad)  ")
        'sConsulta.AppendLine("- TPD.DescuentoImp ")
        'sConsulta.AppendLine("- ISNULL((SELECT sum(DesImporte) FROM TPDDES WHERE TPDDES.TransProdId=TRP.TransProdId AND TPDDES.TransProdDetalleId=TPD.TransPRodDetalleId),0) ")
        'sConsulta.AppendLine("- (TRP.DescVendPor * TPD.Subtotal / 100) ")
        'sConsulta.AppendLine("+ (TPD.Impuesto - (TRP.DescVendPor * TPD.Impuesto / 100) - (TPD.Impuesto * (CASE TPD.SubTotal WHEN 0 THEN 0 ELSE ")
        'sConsulta.AppendLine("(ISNULL((SELECT sum(DesImporte) FROM TPDDES WHERE TPDDES.TransProdId=TRP.TransProdId AND TPDDES.TransProdDetalleId=TPD.TransPRodDetalleId),0)/TPD.SubTotal)END)))) ELSE 0 END) AS TotalEnRuta, ")
        'sConsulta.AppendLine("(SELECT Count(*) FROM Visita VIS2  ")
        'sConsulta.AppendLine("WHERE VIS2.DiaClave = VIS.DiaClave And VIS2.VendedorId = VIS.VendedorId And VIS2.RUTClave = VIS.RUTClave And VIS2.FueraFrecuencia = 1 ")
        'sConsulta.AppendLine(") as TotalClienteFueraRuta, ")
        'sConsulta.AppendLine("(SELECT Count(*) FROM Visita VIS2 ")
        'sConsulta.AppendLine("INNER JOIN TransProd TRP2 ON TRP2.VisitaClave=VIS2.VisitaClave AND TRP2.DiaClave=VIS2.DiaClave AND TRP2.Tipo=1 AND TRP2.TipoFase<>0 AND Convert(VarChar(20), TRP2.FechaHoraAlta,110)=Convert(VarChar(20), TRP.FechaHoraAlta,110) AND TRP2.TransProdId IN (SELECT TransProdId FROM TransProdDetalle TPD2 WHERE TPD2.ProductoClave=TPD.ProductoClave AND TPD2.Precio<>0 AND TPD2.Subtotal<>0 AND TPD2.Total<>0) ")
        'sConsulta.AppendLine("WHERE VIS2.DiaClave = VIS.DiaClave And VIS2.VendedorId = VIS.VendedorId And VIS2.RUTClave = VIS.RUTClave And VIS2.FueraFrecuencia = 1 ")
        'sConsulta.AppendLine(") as ClientesVentaFueraRuta, ")
        'sConsulta.AppendLine("(CASE VIS.FueraFrecuencia WHEN 1 THEN (TPD.Cantidad * PRD.Factor) ELSE 0 END) as PiezasFueraRuta, ")
        'sConsulta.AppendLine("(CASE VIS.FueraFrecuencia WHEN 1 THEN ")
        'sConsulta.AppendLine("((TPD.Precio * TPD.Cantidad) ")
        'sConsulta.AppendLine("- TPD.DescuentoImp ")
        'sConsulta.AppendLine("- ISNULL((SELECT sum(DesImporte) FROM TPDDES WHERE TPDDES.TransProdId=TRP.TransProdId AND TPDDES.TransProdDetalleId=TPD.TransPRodDetalleId),0) ")
        'sConsulta.AppendLine("- (TRP.DescVendPor * TPD.Subtotal / 100) ")
        'sConsulta.AppendLine("+ (TPD.Impuesto - (TRP.DescVendPor * TPD.Impuesto / 100) - (TPD.Impuesto * (CASE TPD.SubTotal WHEN 0 THEN 0 ELSE ")
        'sConsulta.AppendLine("(ISNULL((SELECT sum(DesImporte) FROM TPDDES WHERE TPDDES.TransProdId=TRP.TransProdId AND TPDDES.TransProdDetalleId=TPD.TransPRodDetalleId),0)/TPD.SubTotal)END)))) ELSE 0 END) AS TotalFueraRuta ")
        'sConsulta.AppendLine("FROM TransProd TRP ")
        'sConsulta.AppendLine("INNER JOIN Visita VIS ON VIS.VisitaClave=TRP.VisitaClave AND VIS.DiaClave=TRP.DiaClave ")
        'sConsulta.AppendLine("INNER JOIN Vendedor VEN ON VEN.VendedorId=VIS.VendedorId ")
        'sConsulta.AppendLine("INNER JOIN (SELECT DISTINCT DiaClave, VendedorId, RUTClave, ClaveCEDI FROM AgendaVendedor) AGV ON AGV.DiaClave =TRP.DiaClave AND AGV.VendedorId = VIS.VendedorId AND AGV.RUTClave=VIS.RUTClave ")
        'sConsulta.AppendLine("INNER JOIN Almacen ALM ON ALM.Clave=AGV.ClaveCEDI ")
        'sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD ON TPD.TransProdId=TRP.TransProdId AND TPD.Precio<>0 AND TPD.Subtotal<>0 AND TPD.Total<>0 ")
        'sConsulta.AppendLine("INNER JOIN ProductoEsquema PRE ON PRE.ProductoClave=TPD.ProductoClave ")
        'sConsulta.AppendLine("INNER JOIN Esquema ESQ ON ESQ.EsquemaId=PRE.EsquemaId ")
        'sConsulta.AppendLine("INNER JOIN Producto PRO ON PRO.ProductoClave=TPD.ProductoClave ")
        'sConsulta.AppendLine("INNER JOIN ProductoDetalle PRD ON PRD.ProductoClave=PRO.ProductoClave ")
        'sConsulta.AppendLine(pvCondicion & " AND TRP.Tipo = 1 And TRP.TipoFase <> 0 ")
        'sConsulta.AppendLine(") as Resultados ")
        'sConsulta.AppendLine("GROUP BY ALMClave, ALMNombre, RUTClave, VendedorId, VENNombre, EsquemaId, ESQNombre, FechaHoraAlta, ProductoClave, PRONombre,Resultados.TotalClientesEnRuta,Resultados.ClientesVentaFueraRuta,Resultados.TotalClienteFueraRuta,Resultados.ClientesVentaEnRuta ")

        sConsulta.AppendLine("Select ALMClave, ALMNombre, RUTClave, VendedorId, VENNombre, EsquemaId, ESQNombre, FechaHoraAlta, ProductoClave, PRONombre, Avg(Precio) as Precio, ")
        sConsulta.AppendLine("sum(TotalClientesEnRuta) As TotalClientesEnRuta, sum(ClientesVentaEnRuta) As ClientesVentaEnRuta, sum(PiezasEnRuta) as PiezasEnRuta, sum(TotalEnRuta) as TotalEnRuta, ")
        sConsulta.AppendLine("sum(TotalClienteFueraRuta) as TotalClienteFueraRuta, sum(ClientesVentaFueraRuta) As ClientesVentaFueraRuta,	sum(PiezasFueraRuta) as PiezasFueraRuta, sum(TotalFueraRuta) as TotalFueraRuta ")
        sConsulta.AppendLine("FROM( Select ALMClave, ALMNombre, RUTClave, VendedorId, VENNombre,EsquemaId, ESQNombre, FechaHoraAlta, ProductoClave, PRONombre, Precio, ")
        sConsulta.AppendLine("(select count(distinct ClienteClave) FROM agendavendedor AV where AV.clavecedi = T.ALMClave and AV.VendedorId = T.VendedorId and AV.diaclave = T.DiaClave and AV.rutClave = RUTClave) As TotalClientesEnRuta, ")
        sConsulta.AppendLine("count(distinct ClienteClave) As ClientesVentaEnRuta,sum(Cantidad) as PiezasEnRuta, sum(Total) as TotalEnRuta, ")
        sConsulta.AppendLine("(select count(distinct V.ClienteClave) from visita V WHERE V.diaclave =T.DiaClave and V.VendedorId = T.VendedorId  and V.RUTClave = T.RUTClave and FueraFrecuencia = 1) as TotalClienteFueraRuta, ")
        sConsulta.AppendLine("count(distinct ClienteClave1) As ClientesVentaFueraRuta, sum(Cantidad1) as PiezasFueraRuta, sum(Total1) as TotalFueraRuta, DiaClave ")
        sConsulta.AppendLine("FROM(SELECT ALM.Clave as ALMClave, ALM.Nombre as ALMNombre, AGV.RUTClave, VEN.VendedorId, VEN.Nombre as VENNombre, ESQ.EsquemaId, ESQ.Nombre as ESQNombre,  ")
        sConsulta.AppendLine("Convert(VarChar(20), TRP.FechaHoraAlta,110) as FechaHoraAlta, TPD.ProductoClave, PRO.Nombre as PRONombre, TPD.Precio, TRP.DiaClave,  ")
        sConsulta.AppendLine("(	CASE VIS.FueraFrecuencia WHEN 0 THEN isnull((TPD.Cantidad * PRD.Factor),0) ELSE 0 END) as Cantidad,  ")
        sConsulta.AppendLine("(	CASE VIS.FueraFrecuencia WHEN 0 THEN (isnull((SELECT (TPD.SubTotal - sum(TDS.DesImporte) -((TPD.SubTotal - sum(TDS.DesImporte)) * (TRP.DescVendPor/100)))+ ")
        sConsulta.AppendLine("(TPD.Impuesto- sum(TDS.DesImpuesto)+ ((TPD.Impuesto- sum(TDS.DesImpuesto))*(TRP.DescVendPor/100))) FROM TpdDes TDS  ")
        sConsulta.AppendLine("WHERE TDS.TransProdId = TRP.TransProdId AND TDS.TransProdDetalleId = TPD.TransProdDetalleId  ), ")
        sConsulta.AppendLine("(TPD.SubTotal -	(TPD.SubTotal * (TRP.DescVendPor/100)))+(TPD.Impuesto -	( TPD.Impuesto*(TRP.DescVendPor/100))))) ELSE 0 END) as Total, ")
        sConsulta.AppendLine("(	CASE VIS.FueraFrecuencia WHEN 0 THEN Vis.ClienteClave Else null end ) as ClienteClave, ")
        sConsulta.AppendLine("(	CASE VIS.FueraFrecuencia WHEN 1 THEN isnull((TPD.Cantidad * PRD.Factor),-44) ELSE 0 END) as Cantidad1, ")
        sConsulta.AppendLine("(	CASE VIS.FueraFrecuencia WHEN 1 THEN(isnull((SELECT (TPD.SubTotal - sum(TDS.DesImporte) - ((TPD.SubTotal - sum(TDS.DesImporte)) * (TRP.DescVendPor/100)))+ ")
        sConsulta.AppendLine("(TPD.Impuesto- sum(TDS.DesImpuesto)+((TPD.Impuesto- sum(TDS.DesImpuesto))*(TRP.DescVendPor/100))) FROM TpdDes TDS ")
        sConsulta.AppendLine("WHERE TDS.TransProdId = TRP.TransProdId AND TDS.TransProdDetalleId = TPD.TransProdDetalleId  ), ")
        sConsulta.AppendLine("(TPD.SubTotal -	(TPD.SubTotal * (TRP.DescVendPor/100)))+(TPD.Impuesto -	( TPD.Impuesto*(TRP.DescVendPor/100))))) ELSE 0 END) as Total1, ")
        sConsulta.AppendLine("(	CASE VIS.FueraFrecuencia WHEN 1 THEN Vis.ClienteClave Else null end ) as ClienteClave1 ")
        sConsulta.AppendLine("FROM TransProd TRP ")
        sConsulta.AppendLine("INNER JOIN Visita VIS ON VIS.VisitaClave=TRP.VisitaClave AND VIS.DiaClave=TRP.DiaClave  ")
        sConsulta.AppendLine("INNER JOIN Vendedor VEN ON VEN.VendedorId=VIS.VendedorId ")
        sConsulta.AppendLine("INNER JOIN (SELECT DISTINCT DiaClave, VendedorId, RUTClave, ClaveCEDI FROM AgendaVendedor) AGV ON AGV.DiaClave =TRP.DiaClave AND AGV.VendedorId = VIS.VendedorId AND AGV.RUTClave=VIS.RUTClave ")
        sConsulta.AppendLine("INNER JOIN Almacen ALM ON ALM.Clave=AGV.ClaveCEDI ")
        sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD ON TPD.TransProdId=TRP.TransProdId AND TPD.Precio<>0 AND TPD.Subtotal<>0 AND TPD.Total<>0 ")
        sConsulta.AppendLine("INNER JOIN ProductoEsquema PRE ON PRE.ProductoClave=TPD.ProductoClave ")
        sConsulta.AppendLine("INNER JOIN Esquema ESQ ON ESQ.EsquemaId=PRE.EsquemaId ")
        sConsulta.AppendLine("INNER JOIN Producto PRO ON PRO.ProductoClave=TPD.ProductoClave ")
        sConsulta.AppendLine("INNER JOIN ProductoDetalle PRD ON PRD.ProductoClave=PRO.ProductoClave ")
        sConsulta.AppendLine(pvCondicion & " AND TRP.Tipo = 1 And TRP.TipoFase <> 0 and tpd.promocion<>2 ")
        sConsulta.AppendLine(") as T group by ALMClave, ALMNombre, RUTClave, VendedorId, VENNombre, EsquemaId, ESQNombre, FechaHoraAlta, ProductoClave, PRONombre, Precio, DiaClave ")
        sConsulta.AppendLine(") as Tabla group by ALMClave, ALMNombre, RUTClave, VendedorId, VENNombre, EsquemaId, ESQNombre, FechaHoraAlta, ProductoClave, PRONombre ")

        sConsulta.AppendLine("set nocount off ")

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        Return True
    End Function

    Private Function ConsultaLiquidacionPascual(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As StringBuilder
        Dim consTemp As String = ""
        If Not IsNothing(Session("VendedorId")) And Session("VendedorId") <> "" Then
            consTemp = " AND V.VendedorId = '" + Session("VendedorId").ToString() + "'"
        End If

        If pvFecha Then
            consTemp &= strWhereFecha(consTemp, "convert(datetime,DiaClave,103)")
        End If



        If (ChBoxCentroDistribucion.Checked) Then
            consTemp &= " AND ALM1.Clave = '" + DdlCentroDistribucion.SelectedValue + "' "
        End If
        'Sección Liquidos
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("Select ProductoClave, PRONombre, (")
        sConsulta.AppendLine(" SELECT SUM(TD.Cantidad * PD.Factor ) FROM TransProd as TR ")
        sConsulta.AppendLine(" INNER JOIN TransProdDetalle as TD ON TD.TransProdId=TR.TransProdId ")
        sConsulta.AppendLine(" INNER JOIN Producto as PR ON PR.ProductoClave=TD.ProductoClave  ")
        sConsulta.AppendLine(" INNER JOIN ProductoDetalle as PD ON PD.ProductoClave=PR.ProductoClave AND PD.PRUTipoUnidad=TD.TipoUnidad AND PD.ProductoDetClave=PR.ProductoClave ")
        sConsulta.AppendLine(" INNER JOIN Vendedor as V ON V.USUId=TR.MUsuarioId AND V.TipoEstado=1 AND V.Baja=0 ")
        sConsulta.AppendLine(" INNER JOIN VENCENTRODISTHIST as Vc ON V.vendedorid=Vc.vendedorid and convert(datetime,tr.DiaClave,103) between vc.vchfechainicial and vc.fechafinal ")
        sConsulta.AppendLine(" INNER JOIN almacen as alm1 ON alm1.almacenid=Vc.almacenid  ")
        sConsulta.AppendLine(" WHERE TR.Tipo=2 " + consTemp + " and PR.ProductoClave = Liquidacion.ProductoClave ")
        sConsulta.AppendLine(") as Cargas, sum(Ajuste) as Ajustes, sum(DevolucionAlmacen) as DevolucionesAlmacen, ")
        sConsulta.AppendLine("sum(Descargas) as Descargas, ((")
        sConsulta.AppendLine(" SELECT SUM(TD.Cantidad * PD.Factor ) FROM TransProd as TR ")
        sConsulta.AppendLine(" INNER JOIN TransProdDetalle as TD ON TD.TransProdId=TR.TransProdId ")
        sConsulta.AppendLine(" INNER JOIN Producto as PR ON PR.ProductoClave=TD.ProductoClave  ")
        sConsulta.AppendLine(" INNER JOIN ProductoDetalle as PD ON PD.ProductoClave=PR.ProductoClave AND PD.PRUTipoUnidad=TD.TipoUnidad AND PD.ProductoDetClave=PR.ProductoClave ")
        sConsulta.AppendLine(" INNER JOIN Vendedor as V ON V.USUId=TR.MUsuarioId AND V.TipoEstado=1 AND V.Baja=0 ")
        sConsulta.AppendLine(" INNER JOIN VENCENTRODISTHIST as Vc ON V.vendedorid=Vc.vendedorid and convert(datetime,tr.DiaClave,103) between vc.vchfechainicial and vc.fechafinal ")
        sConsulta.AppendLine(" INNER JOIN almacen as alm1 ON alm1.almacenid=Vc.almacenid  ")
        sConsulta.AppendLine(" WHERE TR.Tipo=2 " + consTemp + " and PR.ProductoClave = Liquidacion.ProductoClave ")
        sConsulta.AppendLine(")-sum(Descargas)-sum(Ajuste)) as VentaBruta, sum(Venta) as Ventas,sum(Promocion) as Promocion, ")
        sConsulta.AppendLine("sum(Precio) as Precio, sum((Subtotal - DescCliPor - DescVendPor) + (Impuesto - DescCliPorImp)) as Importe ")
        sConsulta.AppendLine("From ")
        sConsulta.AppendLine("( ")
        sConsulta.AppendLine("SELECT VEN.Nombre as VENNombre,  TRP.FechaHoraAlta, ")
        sConsulta.AppendLine("TRP.Tipo, TPD.ProductoClave, PRO.Nombre as PRONombre, ")
        sConsulta.AppendLine("Carga=(SELECT CASE WHEN TRP.Tipo=2 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Ajuste=(SELECT CASE WHEN TRP.Tipo=6 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("DevolucionAlmacen=(SELECT CASE WHEN TRP.Tipo=4 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Descargas=(SELECT CASE WHEN TRP.Tipo=7 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Venta=(SELECT CASE WHEN TRP.Tipo=1 AND TPD.Total>0 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Promocion=(SELECT CASE WHEN TRP.Tipo=1 AND TPD.Total=0 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Precio = (SELECT CASE WHEN TRP.Tipo=1 AND TPD.Total>0 THEN TPD.Precio * TPD.Cantidad ELSE 0 END), ")
        sConsulta.AppendLine("SubTotal=(SELECT CASE WHEN TRP.Tipo=1  AND TPD.Total>0 THEN TPD.Subtotal ELSE 0 END), ")
        sConsulta.AppendLine("DescCliPor=(SELECT CASE WHEN TRP.Tipo=1  AND TPD.Total>0 THEN (SELECT (CASE WHEN sum(DesImporte) IS NULL THEN 0 ELSE sum(DesImporte) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) ELSE 0 End), ")
        sConsulta.AppendLine("DescVendPor=(SELECT CASE WHEN TRP.Tipo=1 AND TPD.Total>0 THEN (SELECT CASE WHEN TRP.DescVendPor IS NULL THEN 0 ELSE TRP.DescVendPor END) ELSE 0 END), ")
        sConsulta.AppendLine("Impuesto=(SELECT CASE WHEN TRP.Tipo=1  AND TPD.Total>0 THEN (SELECT CASE WHEN TPD.Impuesto IS NULL THEN 0 ELSE TPD.Impuesto END) ELSE 0 END), ")
        sConsulta.AppendLine("DescCliPorImp=(SELECT CASE WHEN TRP.Tipo=1  AND TPD.Total>0 THEN (SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE sum(DesImpuesto) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) ELSE 0 End) ")
        sConsulta.AppendLine("FROM TransProd as TRP INNER JOIN TransProdDetalle as TPD ON TPD.TransProdId=TRP.TransProdId ")
        sConsulta.AppendLine("INNER JOIN Producto as PRO ON PRO.ProductoClave=TPD.ProductoClave ")
        sConsulta.AppendLine("INNER JOIN ProductoDetalle as PDD ON PDD.ProductoClave=TPD.ProductoClave AND PDD.PRUTipoUnidad=TPD.TipoUnidad AND PDD.ProductoDetClave=TPD.ProductoClave ")
        sConsulta.AppendLine("INNER JOIN Usuario as USU ON USU.USUId=TRP.MUsuarioId ")
        sConsulta.AppendLine("INNER JOIN Vendedor as VEN ON VEN.USUId=TRP.MUsuarioId AND VEN.TipoEstado=1 AND VEN.Baja=0 ")
        sConsulta.AppendLine("INNER JOIN VENCENTRODISTHIST as Vcd ON Ven.vendedorid=Vcd.vendedorid and convert(datetime,trp.DiaClave,103) between vcd.vchfechainicial and vcd.fechafinal ")
        sConsulta.AppendLine("INNER JOIN almacen as alm ON alm.almacenid=Vcd.almacenid  ")
        sConsulta.AppendLine("WHERE TRP.Tipo IN (1,2,4,6,7) AND TRP.TipoFase<>0  ")

        Dim sCondicionVentas As String = String.Empty
        If chboxVendedor.Checked Then
            sCondicionVentas = "and VEN.VendedorId = '" + ddlVendedor.Text + "' "
        End If
        If chboxFecha.Checked Then
            sConsulta.AppendLine(strWhereFecha(sCondicionVentas, "FechaHoraAlta"))
        Else
            sConsulta.AppendLine(sCondicionVentas)
        End If
        If (ChBoxCentroDistribucion.Checked) Then
            Session("CEDI") = Me.DdlCentroDistribucion.SelectedItem.Text
            sConsulta.AppendLine(" AND alm.clave = '" + DdlCentroDistribucion.SelectedValue + "' ")
        Else
            Session("CEDI") = ""
        End If
        sConsulta.AppendLine(") as Liquidacion GROUP BY ProductoClave, PRONombre order by ProductoClave ")

        Session("VentasProductos") = sConsulta.ToString


        'Seccion Embalajes
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("SELECT ProductoClave, PRONombre, PROTipo, SUM(Salen) as Salen, SUM(Entran) as Entran, (SUM(Salen)-SUM(Entran)) as DifBruta, ")
        sConsulta.AppendLine("SUM(Promociones) as Promociones, (AVG(Precio) * (SUM(Salen)-SUM(Entran))) as DifImporte ")
        sConsulta.AppendLine("FROM( SELECT PRO.ProductoClave, PRO.Nombre as PRONombre, ")
        sConsulta.AppendLine("(SELECT Descripcion FROM VAVDescripcion WHERE VarCodigo = 'PROTIPO' and VAVClave=PRO.Tipo and VADTipoLenguaje = 'EM') as PROTipo, ")
        sConsulta.AppendLine("Salen=(CASE WHEN TRP.Tipo=2 THEN TPD.Cantidad * PDD.Factor * PDD1.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Entran=(CASE WHEN TRP.Tipo IN (4,6,7,15) THEN TPD.Cantidad * PDD.Factor * PDD1.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Promociones=(CASE WHEN TRP.Tipo=1 AND TPD.Total=0 THEN TPD.Cantidad * PDD.Factor * PDD1.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Precio=isnull((SELECT TOP 1 Precio FROM PrecioProductoVig PPV WHERE PPV.ProductoClave=PRO.ProductoClave AND PPV.TipoEstado=1 AND PPV.PPVFechaInicio <= TRP.FechaHoraAlta AND PPV.FechaFin >= TRP.FechaHoraAlta),0) ")
        sConsulta.AppendLine("FROM transprod TRP ")
        sConsulta.AppendLine("INNER JOIN transproddetalle TPD on TRP.transprodid = TPD.transprodid  ")
        sConsulta.AppendLine("INNER JOIN productodetalle PDD on PDD.Productoclave = TPD.productoclave  AND PDD.ProductoDetClave <> TPD.productoclave AND PDD.PRUTipoUnidad =  TPD.Tipounidad and PDD.prestamo = 1 ")
        sConsulta.AppendLine("INNER JOIN producto PRO on PRO.productoclave = PDD.ProductoDetClave ")
        sConsulta.AppendLine("INNER JOIN productodetalle PDD1 on  PDD1.Productoclave = TPD.productoclave AND PDD1.ProductoDetClave = TPD.productoclave AND PDD1.PRUTipoUnidad =  TPD.Tipounidad ")
        sConsulta.AppendLine("INNER JOIN Usuario as USU ON USU.USUId=TRP.MUsuarioId ")
        sConsulta.AppendLine("INNER JOIN Vendedor as VEN ON VEN.USUId=TRP.MUsuarioId AND VEN.TipoEstado=1 AND VEN.Baja=0 ")
        sConsulta.AppendLine("INNER JOIN (SELECT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor GROUP BY DiaClave, VendedorId, ClaveCEDI) as AGV ON AGV.DiaClave=TRP.DiaClave AND AGV.VendedorId=VEN.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Almacen as ALM ON ALM.Clave=AGV.ClaveCEDI ")
        If chboxFecha.Checked Then
            sConsulta.AppendLine(strWhereFecha(sCondicionVentas, "TRP.FechaHoraAlta"))
        Else
            sConsulta.AppendLine(sCondicionVentas)
        End If
        If (ChBoxCentroDistribucion.Checked) Then
            sConsulta.AppendLine(" AND alm.clave = '" + DdlCentroDistribucion.SelectedValue + "' ")
        End If
        sConsulta.AppendLine(" AND TRP.Tipo IN (1,2,4,6,7,15) AND TRP.TipoFase<>0 ")

        sConsulta.AppendLine("UNION SELECT PRO.ProductoClave, PRO.Nombre as PRONombre, ")
        sConsulta.AppendLine("(SELECT Descripcion FROM VAVDescripcion WHERE VarCodigo = 'PROTIPO' and VAVClave=PRO.Tipo and VADTipoLenguaje = 'EM') as PROTipo, ")
        sConsulta.AppendLine("Salen=(CASE WHEN TRP.Tipo=2 THEN TPD.Cantidad * PDD1.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Entran=(CASE WHEN TRP.Tipo IN (4,6,7,15) THEN TPD.Cantidad * PDD1.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Promociones=(CASE WHEN TRP.Tipo=1 AND TPD.Total=0 THEN TPD.Cantidad * PDD1.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Precio=isnull((SELECT TOP 1 Precio FROM PrecioProductoVig PPV WHERE PPV.ProductoClave=PRO.ProductoClave AND PPV.TipoEstado=1 AND PPV.PPVFechaInicio <= TRP.FechaHoraAlta AND PPV.FechaFin >= TRP.FechaHoraAlta),0) ")
        sConsulta.AppendLine("FROM transprod TRP ")
        sConsulta.AppendLine("INNER JOIN transproddetalle TPD on TRP.transprodid = TPD.transprodid  ")
        sConsulta.AppendLine("INNER JOIN producto PRO on PRO.productoclave = TPD.productoclave ")
        sConsulta.AppendLine("INNER JOIN productodetalle PDD1 on  PDD1.Productoclave = TPD.productoclave AND PDD1.ProductoDetClave = TPD.productoclave AND PDD1.PRUTipoUnidad =  TPD.Tipounidad ")
        sConsulta.AppendLine("INNER JOIN Usuario as USU ON USU.USUId=TRP.MUsuarioId ")
        sConsulta.AppendLine("INNER JOIN Vendedor as VEN ON VEN.USUId=TRP.MUsuarioId AND VEN.TipoEstado=1 AND VEN.Baja=0 ")
        sConsulta.AppendLine("INNER JOIN (SELECT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor GROUP BY DiaClave, VendedorId, ClaveCEDI) as AGV ON AGV.DiaClave=TRP.DiaClave AND AGV.VendedorId=VEN.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Almacen as ALM ON ALM.Clave=AGV.ClaveCEDI ")
        If chboxFecha.Checked Then
            sConsulta.AppendLine(strWhereFecha(sCondicionVentas, "TRP.FechaHoraAlta"))
        Else
            sConsulta.AppendLine(sCondicionVentas)
        End If
        If (ChBoxCentroDistribucion.Checked) Then
            sConsulta.AppendLine(" AND alm.clave = '" + DdlCentroDistribucion.SelectedValue + "' ")
        End If
        sConsulta.AppendLine(" AND TRP.Tipo IN (1,2,4,6,7,15) AND TRP.TipoFase<>0 AND PRO.Contenido = 1 ")
        sConsulta.AppendLine(") as Resultado ")
        sConsulta.AppendLine("GROUP BY ProductoClave, PRONombre, PROTipo ")

        Session("Embalajes") = sConsulta.ToString

        'Sección Cobranza en Cheques
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")

        sConsulta.AppendLine("SELECT TRP.Folio, VAD.Descripcion as Banco, ABD.Referencia, convert(datetime,Convert(varchar(20),ABN.FechaAbono,112)) as FechaAbono, sum(ABD.Importe) as Importe ")
        sConsulta.AppendLine("FROM Abono ABN ")
        sConsulta.AppendLine("INNER JOIN ABNDetalle ABD on ABN.ABNId = ABD.ABNId and ABD.TipoPago = 2 ")
        sConsulta.AppendLine("INNER JOIN ABNTrp ABT on ABT.ABNId = ABN.ABNId ")
        sConsulta.AppendLine("INNER JOIN TransProd TRP on TRP.TransProdId = ABT.TransProdID ")
        sConsulta.AppendLine("INNER JOIN VAVDescripcion VAD on VAD.VAVClave = ABD.TipoBanco and VARCodigo = 'TBANCO' and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' ")
        sConsulta.AppendLine("INNER JOIN Visita VIS on VIS.VisitaClave = ABN.VisitaClave ")
        sConsulta.AppendLine("INNER JOIN Vendedor VEN on VEN.VendedorID = VIS.VendedorID ")
        sConsulta.AppendLine("INNER JOIN VENCENTRODISTHIST as Vcd ON Ven.vendedorid=Vcd.vendedorid and convert(datetime,trp.DiaClave,103) between vcd.vchfechainicial and vcd.fechafinal ")
        sConsulta.AppendLine("INNER JOIN almacen as alm ON alm.almacenid=Vcd.almacenid  ")
        If chboxFecha.Checked Then
            sConsulta.AppendLine(strWhereFecha(pvCondicion, "ABN.FechaAbono"))
        Else
            sConsulta.AppendLine(pvCondicion)
        End If
        If (ChBoxCentroDistribucion.Checked) Then
            sConsulta.AppendLine(" AND alm.clave = '" + DdlCentroDistribucion.SelectedValue + "' ")
        End If
        sConsulta.AppendLine("GROUP BY TRP.Folio, VAD.Descripcion, ABD.Referencia, convert(datetime,Convert(varchar(20),ABN.FechaAbono,112)) ")
        sConsulta.AppendLine("ORDER BY TRP.Folio ")

        Session("CobranzaCheques") = sConsulta.ToString


        'Seccion Creditos Otorgados
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("select TRP.Folio, TRP.FechaHoraAlta as Fecha, CLI.Clave + ' ' + CLI.NombreCorto as Cliente,TRP.Total as Importe, TRP.Saldo, CASE WHEN CLE.EsquemaID is null Then 0 ELSE 1 END as Autoservicio ")
        sConsulta.AppendLine("from TransProd TRP inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave inner join Cliente CLI on CLI.ClienteClave = VIS.ClienteClave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VEN.VendedorID = VIS.VendedorID ")
        sConsulta.AppendLine("INNER JOIN VENCENTRODISTHIST as Vcd ON Ven.vendedorid=Vcd.vendedorid and convert(datetime,trp.DiaClave,103) between vcd.vchfechainicial and vcd.fechafinal ")
        sConsulta.AppendLine("INNER JOIN almacen as alm ON alm.almacenid=Vcd.almacenid  ")
        sConsulta.AppendLine("left join ClienteEsquema CLE on CLI.ClienteClave = CLE.ClienteClave and CLE.EsquemaID=(Select EsquemaID from Esquema where Clave='AUTOSERV') ")
        If chboxFecha.Checked Then
            sConsulta.AppendLine(strWhereFecha(pvCondicion, "TRP.FechaHoraAlta"))
        Else
            sConsulta.AppendLine(pvCondicion)
        End If
        If (ChBoxCentroDistribucion.Checked) Then
            sConsulta.AppendLine(" AND alm.clave = '" + DdlCentroDistribucion.SelectedValue + "' ")
        End If
        sConsulta.AppendLine(" AND TRP.Tipo = 1 and TRP.TipoFase <>0 AND TRP.Saldo >0 ")
        sConsulta.AppendLine("order by TRP.Folio ")

        Session("Creditos") = sConsulta.ToString


        'Sección Cobranza Ventas Anteriores
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("Select Folio, FechaHoraAlta as Fecha, TRPTotal, ABNTotal,TipoPago, Referencia, sum(Importe) as Importe ")
        sConsulta.AppendLine("from(Select TRP.Folio, TRP.FechaHoraAlta, TRP.Total as TRPTotal, ")
        sConsulta.AppendLine("(Select sum(ABN.Total) from Abono ABN inner join ABNTrp on ABNTrp.TransProdID = TRP.TransProdID and ABNTrp.ABNId = ABN.ABNID ")
        If chboxFecha.Checked Then
            sConsulta.AppendLine("and ABN.FechaAbono<='" & FechaFinUltimaHora() & "'")
        End If
        sConsulta.AppendLine(") as ABNTotal, VAD.Descripcion as TipoPago, ABD.Referencia, ABD.Importe as Importe ")
        sConsulta.AppendLine("from TransProd TRP inner join ABNTrp ABT on ABT.TransProdID = TRP.TransProdID and TRP.Tipo = 1 and TRP.TipoFase <>0 ")
        sConsulta.AppendLine("inner join ABNDetalle ABD on ABD.ABNId = ABT.ABNId ")
        sConsulta.AppendLine("inner join VIsita VIS on VIS.VisitaClave = TRP.VisitaClave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VEN.VendedorID = VIS.VendedorID ")
        sConsulta.AppendLine("INNER JOIN VENCENTRODISTHIST as Vcd ON Ven.vendedorid=Vcd.vendedorid and convert(datetime,trp.DiaClave,103) between vcd.vchfechainicial and vcd.fechafinal ")
        sConsulta.AppendLine("INNER JOIN almacen as alm ON alm.almacenid=Vcd.almacenid  ")
        sConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VARCodigo ='PAGO' and ABD.TipoPago = VAD.VAVClave and VADTipoLenguaje = '" & Session("lenguaje") & "' ")
        If chboxFecha.Checked Then
            sConsulta.AppendLine(strWhereFecha(pvCondicion, "ABT.FechaHora"))
            sConsulta.AppendLine(" and TRP.FechaHoraAlta<'" & FechaInicioPrimeraHora() & "'")
        Else
            sConsulta.AppendLine(pvCondicion)
            sConsulta.AppendLine(" and TRP.FechaHoraAlta<'" & DateSerial(1900, 1, 1).ToString("s") & "'")
        End If
        If (ChBoxCentroDistribucion.Checked) Then
            sConsulta.AppendLine(" AND alm.clave = '" + DdlCentroDistribucion.SelectedValue + "' ")
        End If
        sConsulta.AppendLine(") as CobranzaAnteriores group by Folio, FechaHoraAlta, TRPTotal, ABNTotal,TipoPago, Referencia order by Folio ")

        Session("CobranzaAnteriores") = sConsulta.ToString


        'Efectivo
        If chboxFecha.Checked Then
            Session("TotalEfectivo") = "Select  CASE When sum(ABD.Importe) is null Then 0 Else sum(ABD.Importe) END as Importe from Abono ABN inner join ABNDetalle ABD on ABN.ABNId = ABD.ABNId and ABD.TipoPago<>2 inner join Visita VIS on VIS.VisitaClave = ABN.VisitaClave inner join Vendedor VEN on VEN.VendedorID = VIS.VendedorID " & strWhereFecha(pvCondicion, "ABN.FechaAbono")
        Else
            Session("TotalEfectivo") = "Select  CASE When sum(ABD.Importe) is null Then 0 Else sum(ABD.Importe) END as Importe from Abono ABN inner join ABNDetalle ABD on ABN.ABNId = ABD.ABNId and ABD.TipoPago<>2 inner join Visita VIS on VIS.VisitaClave = ABN.VisitaClave inner join Vendedor VEN on VEN.VendedorID = VIS.VendedorID " & pvCondicion
        End If

        'TotalCalculoComision
        If chboxFecha.Checked Then
            Session("TotalCalculoComision") = "Select  CASE When sum(ABD.Importe) is null Then 0 Else sum(ABD.Importe) END as Importe from Abono ABN inner join ABNDetalle ABD on ABN.ABNId = ABD.ABNId inner join Visita VIS on VIS.VisitaClave = ABN.VisitaClave inner join Vendedor VEN on VEN.VendedorID = VIS.VendedorID " & strWhereFecha(pvCondicion, "ABN.FechaAbono")
        Else
            Session("TotalCalculoComision") = "Select  CASE When sum(ABD.Importe) is null Then 0 Else sum(ABD.Importe) END as Importe from Abono ABN inner join ABNDetalle ABD on ABN.ABNId = ABD.ABNId inner join Visita VIS on VIS.VisitaClave = ABN.VisitaClave inner join Vendedor VEN on VEN.VendedorID = VIS.VendedorID " & pvCondicion
        End If

        'PorcentajeComision
        Session("PorcentajeComision") = Me.txtComision.Text

        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("SELECT Tipo, PROTipo, ProductoClave, PRONombre, sum(Cantidad) as Cantidad, min(Precio) as Importe  ")
        sConsulta.AppendLine("FROM(select PRO.Tipo, PRO.ProductoClave, PRO.Nombre as PRONombre, PP.Cantidad, ")
        sConsulta.AppendLine("(SELECT Descripcion FROM VAVDescripcion WHERE VarCodigo = 'PROTIPO' and VAVClave=PRO.Tipo and VADTipoLenguaje = 'EM') as PROTipo, ")
        sConsulta.AppendLine("Precio=isnull((SELECT TOP 1 Precio FROM PrecioProductoVig PPV WHERE PPV.ProductoClave=PRO.ProductoClave AND PPV.TipoEstado=1 AND PPV.PPVFechaInicio <= TRP.FechaHoraAlta AND PPV.FechaFin >= TRP.FechaHoraAlta),0) ")
        sConsulta.AppendLine("from productoprestamo PP ")
        sConsulta.AppendLine("inner join Transprod TRP on TRP.TransProdId = PP.TransProdID ")
        sConsulta.AppendLine("INNER JOIN producto PRO on PRO.productoclave = PP.ProductoDetClave ")
        sConsulta.AppendLine("INNER JOIN Visita as Vis ON TRP.VisitaClave = VIS.VisitaClave ")
        sConsulta.AppendLine("INNER JOIN Vendedor as VEN ON VEN.VendedorId=VIS.VendedorId AND VEN.TipoEstado=1 AND VEN.Baja=0 ")
        sConsulta.AppendLine("INNER JOIN VENCENTRODISTHIST as Vcd ON Ven.vendedorid=Vcd.vendedorid and convert(datetime,trp.DiaClave,103) between vcd.vchfechainicial and vcd.fechafinal ")
        sConsulta.AppendLine("INNER JOIN almacen as alm ON alm.almacenid=Vcd.almacenid WHERE 1=1 ")
        If Not IsNothing(Session("VendedorId")) And Session("VendedorId") <> "" Then
            sConsulta.AppendLine(" AND VEN.VendedorId = '" + Session("VendedorId").ToString() + "'")
        End If
        If (ChBoxCentroDistribucion.Checked) Then
            sConsulta.AppendLine(" AND alm.clave = '" + DdlCentroDistribucion.SelectedValue + "' ")
        End If
        sConsulta.AppendLine(") as Prods GROUP BY Tipo, ProductoClave, PRONombre, PROTipo ")

        Session("ProdAcum") = sConsulta.ToString()

        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("Select isnull((SELECT  Sum(TRP.Saldo) ")
        sConsulta.AppendLine("FROM TransProd as TRP ")
        sConsulta.AppendLine("INNER JOIN Visita as Vis ON TRP.VisitaClave = VIS.VisitaClave and vis.diaclave= trp.diaclave ")
        sConsulta.AppendLine("INNER JOIN Vendedor as VEN ON VEN.VendedorId=VIS.VendedorId AND VEN.TipoEstado=1 AND VEN.Baja=0  ")
        sConsulta.AppendLine("INNER JOIN VENCENTRODISTHIST as Vcd ON Ven.vendedorid=Vcd.vendedorid and convert(datetime,trp.DiaClave,103) between vcd.vchfechainicial and vcd.fechafinal ")
        sConsulta.AppendLine("INNER JOIN almacen as alm ON alm.almacenid=Vcd.almacenid   ")
        sConsulta.AppendLine("WHERE TRP.Tipo = 1 AND TRP.TipoFase<>0  AND TRP.Saldo >0 ")
        If Not IsNothing(Session("VendedorId")) And Session("VendedorId") <> "" Then
            sConsulta.AppendLine(" AND VEN.VendedorId = '" + Session("VendedorId").ToString() + "'")
        End If
        If (ChBoxCentroDistribucion.Checked) Then
            sConsulta.AppendLine(" AND alm.clave = '" + DdlCentroDistribucion.SelectedValue + "' ")
        End If
        sConsulta.AppendLine(" ),0)")
        Dim objTemp As Object = ins.EjecutarComandoScalar(sConsulta.ToString())

        Session("SaldosVentas") = objTemp
        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(Session("VentasProductos"), IntCommandTimeOut)
        If (dt.Rows.Count > 0) Then
            Session("VentasProductos") = dt
            Return True
        Else
            Return False
        End If
    End Function

    Private Function ConsultaVentasGat(ByVal ins As DBConexion.cConexionSQL, ByVal pvDetallado As Boolean, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvClientes As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        Dim sCondicionALN As String = ""
        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "convert(datetime, trp.DiaClave, 103)")
        End If
        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "VIS.RUTClave")
        pvCondicion = strWhereClientes(pvCondicion, pvClientes, "CLI.ClienteClave")
        If (ChBoxCentroDistribucion.Checked) Then
            sCondicionALN = "where ALN.Clave = '" + DdlCentroDistribucion.SelectedValue + "' "
        End If

        If pvDetallado Then
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("set nocount on ")
            sConsulta.AppendLine("select FechaCaptura as Fecha,dbo.fnclientedomicilio(clienteclave,'1','" & Session("lenguaje") & "')  as domfiscal,dbo.fnclientedomicilio(clienteclave,'2','" & Session("lenguaje") & "')  as dompuntoentrega, VENNombre as Vendedor, RUTClave + ' ' + RUTDescripcion as Ruta, ")
            sConsulta.AppendLine("TMP.TransProdID,Folio, RazonSocial as Cliente, ProductoClave as Clave, PRONombre as Producto, Unidad, ")
            sConsulta.AppendLine("Precio as PrecioU, ALNClave + ' ' + ALNNombre as CEDI, Cantidad as Cant, TPDSubtotal as SubTotal, DescuentoImp as DescProducto, ")
            sConsulta.AppendLine("DescuentoCliente, ((TPDSubTotal - DescuentoCliente - DescuentoImp ) * DescVendPor / 100) as DescVend, ")
            sConsulta.AppendLine("Impuesto - (Impuesto * DescVendPor / 100)  as Impuesto, ")
            sConsulta.AppendLine("((TPDSubTotal - DescuentoImp - DescuentoCliente) - ((TPDSubTotal - DescuentoCliente - DescuentoImp ) * DescVendPor / 100) + (Impuesto - (Impuesto * DescVendPor / 100))) as Total ")
            sConsulta.AppendLine("from (")
            sConsulta.AppendLine("select TMP.DiaClave, TMP.FechaCaptura, TMP.TransProdID,TMP.Folio, TMP.DescVendPor, ")
            sConsulta.AppendLine("TMP.TRPSubtotal, TMP.ClienteClave, TMP.RazonSocial, TMP.ProductoClave, TMP.Precio, ")
            sConsulta.AppendLine("TMP.Cantidad, TMP.DescuentoCliente, TMP.DescuentoImp, TMP.TPDSubtotal, TMP.Impuesto, TMP.TipoUnidad, ")
            sConsulta.AppendLine("TMP.PRONombre, TMP.Unidad, TMP.RutClave, TMP.VendedorId, TMP.VENNombre, ")
            sConsulta.AppendLine("ALN.Clave as ALNClave, ALN.Nombre as ALNNombre, RUT.Descripcion as RUTDescripcion ")
            sConsulta.AppendLine("from (")
            sConsulta.AppendLine("select TRP.DiaClave, TRP.FechaCaptura, TRP.TransProdID,TRP.Folio, TRP.DescVendPor, TRP.Subtotal as TRPSubtotal, TRP.ClienteClave, ")
            sConsulta.AppendLine("Cli.clave+' - '+CLI.RazonSocial as razonsocial, TPD.ProductoClave, TPD.Precio, TPD.Cantidad, TPD.DescuentoImp, ")
            sConsulta.AppendLine("(TPD.Precio * TPD.Cantidad) as TPDSubTotal, ")
            sConsulta.AppendLine("(SELECT (CASE WHEN sum(DesImporte) IS NULL THEN 0 ELSE sum(DesImporte) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) as DescuentoCliente, ")
            sConsulta.AppendLine("(TPD.Impuesto - (SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE sum(DesImpuesto) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId)) as Impuesto, ")
            sConsulta.AppendLine("TPD.TipoUnidad, PRO.Nombre as PRONombre, ")
            sConsulta.AppendLine("VAD.Descripcion as Unidad, VIS.RutClave, VEN.VendedorId, VEN.Nombre as VENNombre ")
            sConsulta.AppendLine("from TransProd TRP ")
            sConsulta.AppendLine("inner join Cliente CLI on CLI.ClienteClave = TRP.ClienteClave ")
            sConsulta.AppendLine("inner join TransProdDetalle TPD on TPD.TransProdId = TRP.TransProdId ")
            sConsulta.AppendLine("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VARCodigo = 'UNIDADV' and VAD.VAVClave = TPD.TipoUnidad and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' ")
            sConsulta.AppendLine("inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine(pvCondicion & " and TRP.Tipo = 1 and TRP.TipoFase <> 0 ")
            sConsulta.AppendLine(") TMP ")
            sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI from AgendaVendedor) AGV on TMP.DiaClave = AGV.DiaClave and TMP.VendedorId = AGV.VendedorId ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine("inner join Ruta RUT on TMP.RUTClave = RUT.RUTClave ")
            sConsulta.AppendLine(sCondicionALN & ") TMP ")
            sConsulta.AppendLine("set nocount off ")
        Else
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("set nocount on ")
            sConsulta.AppendLine("select distinct FechaCaptura as Fecha, VENNombre as Vendedor, RutClave + ' ' + RUTDescripcion as Ruta, ")
            sConsulta.AppendLine("TMP.TransProdId, Folio, CLIRazonSocial as Cliente, CLIClave as Clave, ALNClave + ' ' + ALNNombre as CEDI, Total ")
            sConsulta.AppendLine("from (")
            sConsulta.AppendLine("select TMP.FechaCaptura, TMP.Folio, TMP.TransProdId, TMP.Total, TMP.DiaClave, TMP.CLIRazonSocial, TMP.CLIClave, TMP.VENNombre, ")
            sConsulta.AppendLine("TMP.VendedorID, TMP.RutClave, TMP.RUTDescripcion, ALN.Clave as ALNClave, ALN.Nombre as ALNNombre ")
            sConsulta.AppendLine("from (")
            sConsulta.AppendLine("select TRP.FechaCaptura, TRP.Folio, TRP.TransProdId, TRP.Total, TRP.DiaClave, CLI.RazonSocial as CLIRazonSocial, CLI.Clave as CLIClave, ")
            sConsulta.AppendLine("VEN.Nombre as VENNombre, VEN.VendedorID, RUT.RutClave, RUT.Descripcion as RUTDescripcion ")
            sConsulta.AppendLine("from TransProd TRP ")
            sConsulta.AppendLine("inner join Cliente CLI on CLI.ClienteClave = TRP.ClienteClave ")
            sConsulta.AppendLine("inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join Ruta RUT on VIS.RUTClave = RUT.RUTClave ")
            sConsulta.AppendLine(pvCondicion & " and TRP.Tipo = 1 and TRP.TipoFase <> 0 ")
            sConsulta.AppendLine(") TMP ")
            sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI from AgendaVendedor) AGV on TMP.DiaClave = AGV.DiaClave and TMP.VendedorId = AGV.VendedorId ")
            sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
            sConsulta.AppendLine(sCondicionALN & ") TMP ")
            sConsulta.AppendLine("set nocount off ")
        End If

        'Session("Query") = sConsulta.ToString

        Dim dt As Data.DataTable
        'System.Diagnostics.Debug.WriteLine(sConsulta.ToString)
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt
        'System.Diagnostics.Debug.WriteLine(dt.Rows.Count)

        'Query 2
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("select CEDI, Clave, Producto, Unidad, ")
        sConsulta.AppendLine("sum(Cantidad) as Cantidad, sum(Total) as Total ")
        sConsulta.AppendLine("from(	select ClienteClave, (ALNClave + ' ' + ALNNombre) as CEDI, ProductoClave as Clave, ")
        sConsulta.AppendLine("PRONombre as Producto, Unidad, Cantidad, TPDTotal as Total ")
        sConsulta.AppendLine("from (")
        sConsulta.AppendLine("select TMP.ProductoClave, TMP.Cantidad, ")
        sConsulta.AppendLine("(SubTotal - DescuentoCliente -((SubTotal - DescuentoCliente) * DescVendPor / 100)) + (Impuesto - DescuentoClienteImpuesto -((Impuesto - DescuentoClienteImpuesto) * DescVendPor / 100)) as TPDtotal, ")
        sConsulta.AppendLine("TMP.Impuesto, TMP.DescVendPor,TMP.DiaClave, TMP.ClienteClave, TMP.PRONombre, TMP.Unidad, ")
        sConsulta.AppendLine("TMP.VendedorId, ALN.Clave as ALNClave, ALN.Nombre as ALNNombre ")
        sConsulta.AppendLine("from (")
        sConsulta.AppendLine("select TPD.ProductoClave, TPD.Cantidad, TPD.Impuesto, TRP.DescVendPor, TPD.SubTotal, ")
        sConsulta.AppendLine("(SELECT (CASE WHEN sum(DesImporte) IS NULL THEN 0 ELSE sum(DesImporte) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) as DescuentoCliente, ")
        sConsulta.AppendLine("(SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE sum(DesImpuesto) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) as DescuentoClienteImpuesto, ")
        sConsulta.AppendLine("TRP.DiaClave, TRP.ClienteClave, PRO.Nombre as PRONombre, VAD.Descripcion as Unidad, VEN.VendedorId ")
        sConsulta.AppendLine("from TransProdDetalle TPD ")
        sConsulta.AppendLine("inner join TransProd TRP on TRP.TransProdId = TPD.TransProdId ")
        sConsulta.AppendLine("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ")
        sConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VARCodigo = 'UNIDADV' and VAD.VAVClave = TPD.TipoUnidad and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' ")
        sConsulta.AppendLine("inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave ")
        sConsulta.AppendLine("inner join Cliente CLI on CLI.ClienteClave = TRP.ClienteClave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
        sConsulta.AppendLine("inner join Ruta RUT on VIS.RUTClave = RUT.RUTClave ")
        sConsulta.AppendLine(pvCondicion & " and TRP.Tipo = 1 and TRP.TipoFase <> 0 ")
        sConsulta.AppendLine(") TMP ")
        sConsulta.AppendLine("inner join (select distinct DiaClave, VendedorId, ClaveCEDI from AgendaVendedor) AGV on TMP.DiaClave = AGV.DiaClave and TMP.VendedorId = AGV.VendedorId ")
        sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
        sConsulta.AppendLine(sCondicionALN & ") TMP ")
        sConsulta.AppendLine(") as t1 group by CEDI, Clave, Producto, Unidad ")
        sConsulta.AppendLine("set nocount off ")

        Session("Query2") = sConsulta.ToString

        Return True
    End Function

    Private Function ConsultaVentasElPanque(ByVal ins As DBConexion.cConexionSQL, ByVal pvDetallado As Boolean, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder

        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "DIA.FechaCaptura")
        End If
        pvCondicion = strWhereCentrosDistribucion(pvCondicion, "ALM.Clave")
        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "VIS.RUTClave")

        If pvDetallado Then
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("set nocount on ")
            sConsulta.AppendLine("SELECT ALM.Clave as ALMClave, ALM.Nombre as ALMNombre, VEN.Nombre as VENNombre, RUT.RUTClave, RUT.Descripcion as RUTDescripcion, DIA.FechaCaptura, ")
            sConsulta.AppendLine("TRP.TransProdId, CLI.Clave as CLIClave, CLI.RazonSocial, CLI.NombreContacto, CLI.TelefonoContacto, ")
            sConsulta.AppendLine("TRP.Folio, TRP.FechaHoraAlta, TRP.FechaCancelacion, ")
            sConsulta.AppendLine("TRP.TipoFase, VAD.Descripcion as TipoFaseDescripcion, TRP.Total, ")
            sConsulta.AppendLine("(CASE WHEN TRP.TipoFase=2 THEN TRP.Total * -1 ELSE TRP.Total END) as Suma, ")
            sConsulta.AppendLine("TPD.ProductoClave, PRO.Nombre as ProductoNombre, TPD.TipoUnidad, VAD1.Descripcion as TipoUnidadDescripcion, TPD.Cantidad ")
            sConsulta.AppendLine("FROM TransProd TRP ")
            sConsulta.AppendLine("INNER JOIN VAVDescripcion VAD on VAD.VAVClave = TRP.TipoFase and VAD.VARCodigo = 'TRPFASE' and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "'  ")
            sConsulta.AppendLine("INNER JOIN Visita VIS on VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave=TRP.DiaClave ")
            sConsulta.AppendLine("INNER JOIN DIA ON DIA.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("INNER JOIN Cliente CLI ON ClI.ClienteClave=TRP.ClienteClave ")
            sConsulta.AppendLine("INNER JOIN Vendedor VEN ON VEN.USUId=TRP.MUsuarioId ")
            sConsulta.AppendLine("INNER JOIN AgendaVendedor AGV ON AGV.DiaClave=TRP.DiaClave And AGV.VendedorId=VEN.VendedorId AND AGV.ClienteClave=VIS.ClienteClave AND AGV.RUTClave=VIS.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Ruta RUT ON RUT.RUTClave=VIS.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Almacen as ALM ON ALM.Clave=AGV.ClaveCEDI ")
            sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD ON TPD.TransProdId=TRP.TransProdId ")
            sConsulta.AppendLine("INNER JOIN VAVDescripcion VAD1 on VAD1.VAVClave = TPD.TipoUnidad and VAD1.VARCodigo = 'UNIDADV' and VAD1.VADTipoLenguaje = '" & Session("lenguaje") & "'  ")
            sConsulta.AppendLine("INNER JOIN Producto PRO ON PRO.ProductoClave=TPD.ProductoClave ")
            sConsulta.AppendLine(pvCondicion)
            sConsulta.AppendLine(" AND TRP.Tipo=1 AND TRP.TipoFase in (0,2) ")
            sConsulta.AppendLine("set nocount off ")
        Else
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("set nocount on ")
            sConsulta.AppendLine("SELECT '' as ProductoClave,'' as TipoUnidadDescripcion, ALM.Clave as ALMClave, ALM.Nombre as ALMNombre, VEN.Nombre as VENNombre, RUT.RUTClave, RUT.Descripcion as RUTDescripcion, DIA.FechaCaptura, ")
            sConsulta.AppendLine("TRP.TransProdId, CLI.Clave as CLIClave, CLI.RazonSocial, CLI.NombreContacto, CLI.TelefonoContacto, ")
            sConsulta.AppendLine("TRP.Folio, TRP.FechaHoraAlta, TRP.FechaCancelacion, ")
            sConsulta.AppendLine("TRP.TipoFase, VAD.Descripcion as TipoFaseDescripcion, TRP.Total, ")
            sConsulta.AppendLine("(CASE WHEN TRP.TipoFase=2 THEN TRP.Total * -1 ELSE TRP.Total END) as Suma ")
            sConsulta.AppendLine("FROM TransProd TRP ")
            sConsulta.AppendLine("INNER JOIN VAVDescripcion VAD on VAD.VAVClave = TRP.TipoFase and VARCodigo = 'TRPFASE' and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' ")
            sConsulta.AppendLine("INNER JOIN Visita VIS on VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave=TRP.DiaClave ")
            sConsulta.AppendLine("INNER JOIN DIA ON DIA.DiaClave = TRP.DiaClave ")
            sConsulta.AppendLine("INNER JOIN Cliente CLI ON ClI.ClienteClave=TRP.ClienteClave ")
            sConsulta.AppendLine("INNER JOIN Vendedor VEN ON VEN.USUId=TRP.MUsuarioId ")
            sConsulta.AppendLine("INNER JOIN AgendaVendedor AGV ON AGV.DiaClave=TRP.DiaClave And AGV.VendedorId=VEN.VendedorId AND AGV.ClienteClave=VIS.ClienteClave AND AGV.RUTClave=VIS.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Ruta RUT ON RUT.RUTClave=VIS.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Almacen as ALM ON ALM.Clave=AGV.ClaveCEDI ")
            sConsulta.AppendLine(pvCondicion)
            sConsulta.AppendLine(" AND TRP.Tipo=1 AND TRP.TipoFase in (0,2) ")
            sConsulta.AppendLine("set nocount off ")
        End If

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        'Query 2
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("SELECT distinct CLI.Clave as CLIClave, (CLD.Calle + ' ' + CLD.Numero + ' <b>'+(select descripcion from mendetalle where menclave='cldcolonia' and medtipolenguaje = '" + Session("lenguaje") + "')+':</b> ' + CLD.Colonia) as Domicilio ")
        sConsulta.AppendLine("FROM TransProd TRP ")
        sConsulta.AppendLine("INNER JOIN Visita VIS on VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave=TRP.DiaClave ")
        sConsulta.AppendLine("INNER JOIN DIA ON DIA.DiaClave = TRP.DiaClave ")
        sConsulta.AppendLine("INNER JOIN Cliente CLI ON ClI.ClienteClave=TRP.ClienteClave ")
        sConsulta.AppendLine("INNER JOIN ClienteDomicilio CLD ON CLD.ClienteClave=CLI.ClienteClave AND CLD.Tipo=2 ")
        sConsulta.AppendLine("INNER JOIN Vendedor VEN ON VEN.VendedorId=VIS.VendedorId ")
        sConsulta.AppendLine("INNER JOIN AgendaVendedor AGV ON AGV.DiaClave=TRP.DiaClave And AGV.VendedorId=VEN.VendedorId AND AGV.ClienteClave=VIS.ClienteClave AND AGV.RUTClave=VIS.RUTClave ")
        sConsulta.AppendLine("INNER JOIN Ruta RUT ON RUT.RUTClave=VIS.RUTClave ")
        sConsulta.AppendLine("INNER JOIN Almacen as ALM ON ALM.Clave=AGV.ClaveCEDI ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine(" AND TRP.Tipo=1 AND TRP.TipoFase in (0,2) ")
        sConsulta.AppendLine("set nocount off ")

        Session("Query2") = sConsulta.ToString
        Return True
    End Function

    Private Function ConsultaProductosOtorgadosPromocion(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvFecha As Boolean) As Boolean
        pvCondicion = pvCondicion.Replace("where", " and ")
        Dim pvCondicionTemp3 As String = pvCondicion
        Dim pvCondicionFechaTRP As String = ""
        Dim pvCondicionFechaPN As String = ""
        Dim sConsulta As New StringBuilder

        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "TRP.FechaHoraAlta")
            pvCondicionFechaTRP = strWhereFecha("", "TRP.FechaHoraAlta")
            pvCondicionFechaPN = strWhereFecha("", "pn.Fechafase")
        End If
        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "VIS.RUTClave")
        pvCondicionTemp3 = strWhereRutas(pvCondicionTemp3, pvRutas, "VIS.RUTClave")
        'pvCondicion = strWhereClientes(pvCondicion, pvClientes, "CLI.ClienteClave")

        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine(" select ")
        sConsulta.AppendLine(" cliente=cli.clave + ' ' + cli.nombrecorto, ")
        sConsulta.AppendLine(" pedido= trp.folio,  ")
        sConsulta.AppendLine(" fecha=trp.fechahoraalta , ")
        sConsulta.AppendLine(" promocion=promo.nombre , ")
        sConsulta.AppendLine(" producto=tpd.productoclave+' '+pro.nombre, ")
        sConsulta.AppendLine(" unidad=unidad.descripcion, ")
        sConsulta.AppendLine(" cantidad=tpd.cantidad, ")
        sConsulta.AppendLine(" ruta=vis.rutclave, ")
        sConsulta.AppendLine(" vendedor=ven.nombre, ")
        sConsulta.AppendLine(" fechasurtido=trp.fechasurtido ")
        sConsulta.AppendLine(" from transprod trp ")
        sConsulta.AppendLine(" inner join transproddetalle tpd on  trp.transprodid=tpd.transprodid ")
        sConsulta.AppendLine(" inner join promocion promo on tpd.promocionclave=promo.promocionclave ")
        sConsulta.AppendLine(" inner join producto pro on pro.productoclave=tpd.productoclave ")
        sConsulta.AppendLine(" inner join visita vis on vis.visitaclave=trp.visitaclave")
        sConsulta.AppendLine(" inner join vendedor ven on vis.vendedorid=ven.vendedorid")
        sConsulta.AppendLine(" inner join cliente cli on cli.clienteclave=vis.clienteclave")
        sConsulta.AppendLine(" inner join vavdescripcion unidad on varcodigo='unidadv' and vavclave=tpd.tipounidad and vadtipolenguaje='" + Session("lenguaje") + "' ")
        sConsulta.AppendLine(" where  trp.tipo in (1) and trp.tipofase<>0 " + pvCondicion)
        sConsulta.AppendLine(" union all ")
        sConsulta.AppendLine(" select ")
        sConsulta.AppendLine(" cliente=cli.clave + ' ' + cli.nombrecorto, ")
        sConsulta.AppendLine(" pedido= trp2.folio , ")
        sConsulta.AppendLine(" fecha=trp2.fechahoraalta  , ")
        sConsulta.AppendLine(" promocion=promo2.nombre   , ")
        sConsulta.AppendLine(" producto=tpd.productoclave+' '+pro.nombre, ")
        sConsulta.AppendLine(" unidad=unidad.descripcion, ")
        sConsulta.AppendLine(" cantidad=tpd.cantidad, ")
        sConsulta.AppendLine(" ruta=vis.rutclave, ")
        sConsulta.AppendLine(" vendedor=ven.nombre, ")
        sConsulta.AppendLine(" fechasurtido=trp.fechasurtido ")
        sConsulta.AppendLine(" from transprod trp ")
        sConsulta.AppendLine(" inner join transproddetalle tpd on  trp.transprodid=tpd.transprodid ")
        sConsulta.AppendLine(" inner join promocion promo on tpd.promocionclave=promo.promocionclave ")
        sConsulta.AppendLine(" inner join producto pro on pro.productoclave=tpd.productoclave ")
        sConsulta.AppendLine(" inner join productonegado pn on tpd.prgid=pn.prgid ")
        sConsulta.AppendLine(" inner join transprod trp2 on pn.transprodid=trp2.transprodid ")
        sConsulta.AppendLine(" inner join promocion promo2 on pn.promocionclave=promo2.promocionclave ")
        sConsulta.AppendLine(" inner join visita vis on vis.visitaclave=trp.visitaclave")
        sConsulta.AppendLine(" inner join vendedor ven on vis.vendedorid=ven.vendedorid")
        sConsulta.AppendLine(" inner join cliente cli on cli.clienteclave=vis.clienteclave")
        sConsulta.AppendLine(" inner join vavdescripcion unidad on varcodigo='unidadv' and vavclave=tpd.tipounidad and vadtipolenguaje='" + Session("lenguaje") + "' ")
        sConsulta.AppendLine(" where  trp.tipo in (20) and trp.tipofase<>0 " + pvCondicion)
        sConsulta.AppendLine(" set nocount Off ")
        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt
        sConsulta = New StringBuilder

        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine(" IF (SELECT object_id('tempdb..#Temp1')) IS NOT NULL DROP TABLE #Temp1 ")
        sConsulta.AppendLine(" SELECT * INTO #Temp1 FROM ")
        sConsulta.AppendLine(" (select  trp.transprodid, ")
        sConsulta.AppendLine(" pn.cantidad, ")
        sConsulta.AppendLine(" pedido = trp.folio,  ")
        sConsulta.AppendLine(" promocion = promo.nombre,  ")
        sConsulta.AppendLine(" fecha = trp.fechahoraalta,  ")
        sConsulta.AppendLine(" producto = pn.productoclave + ' ' + pro.nombre,  ")
        sConsulta.AppendLine(" unidad = unidad.descripcion, ")
        sConsulta.AppendLine(" saldo= pn.cantidad - isnull((select sum(td.cantidad) from transproddetalle td ")
        sConsulta.AppendLine("      inner join transprod T on td.transprodid = t.transprodid  ")
        sConsulta.AppendLine("      where  td.prgid = pn.prgid  " + pvCondicionFechaTRP + " ),0),")
        sConsulta.AppendLine(" fase = CASE WHEN 1 = 1 " + pvCondicionFechaPN + " THEN ")
        sConsulta.AppendLine("      (SELECT     DESCRIPCION ")
        sConsulta.AppendLine("      FROM vavdescripcion ")
        sConsulta.AppendLine("      WHERE      VARCODIGO = 'prgfase' AND vadtipolenguaje = '" + Session("lenguaje") + "' AND vavclave = pn.tipofaseprp) ELSE ")
        sConsulta.AppendLine("      (SELECT     DESCRIPCION ")
        sConsulta.AppendLine("      FROM vavdescripcion ")
        sConsulta.AppendLine("      WHERE      VARCODIGO = 'prgfase' AND vadtipolenguaje = '" + Session("lenguaje") + "' AND vavclave = 1) END, ")
        sConsulta.AppendLine(" fechafase = CASE WHEN 1 = 1 " + pvCondicionFechaPN + " THEN pn.fechafase ELSE trp.fechahoraalta END ")
        sConsulta.AppendLine(" from productonegado PN  ")
        sConsulta.AppendLine(" inner join transprod TRP on PN.transprodid = TRP.transprodid  ")
        sConsulta.AppendLine(" inner join Promocion promo on pn.promocionclave = promo.promocionclave ")
        sConsulta.AppendLine(" inner join producto pro on pro.productoclave = pn.productoclave ")
        sConsulta.AppendLine(" inner join vavdescripcion unidad ON varcodigo = 'unidadv' AND vavclave = pn.tipounidad AND vadtipolenguaje = '" + Session("lenguaje") + "' ")
        sConsulta.AppendLine(" where  (PN.tipoFasePRP = 1 and trp.tipofase <> 0  and trp.tipo=1 " + pvCondicionFechaTRP + " ) ")
        sConsulta.AppendLine(" or  ")
        sConsulta.AppendLine(" (PN.tipoFasePRP = 1  and trp.tipofase <> 0  and trp.tipo=20  " + pvCondicionFechaTRP + " ) ")
        sConsulta.AppendLine(" ) as t1 ")

        sConsulta.AppendLine(" IF (SELECT object_id('tempdb..#Temp2')) IS NOT NULL DROP TABLE #Temp2 ")
        sConsulta.AppendLine(" SELECT * INTO #Temp2 FROM ")
        sConsulta.AppendLine(" (Select t1.* from  ")
        sConsulta.AppendLine(" (select tpd.transprodid, ")
        sConsulta.AppendLine(" pn.cantidad, ")
        sConsulta.AppendLine(" pedido = PEDIDO.folio,  ")
        sConsulta.AppendLine(" promocion = promo.nombre,  ")
        sConsulta.AppendLine(" fecha = trp.fechahoraalta,  ")
        sConsulta.AppendLine(" producto = pn.productoclave + ' ' + pro.nombre,  ")
        sConsulta.AppendLine(" unidad = unidad.descripcion, ")
        sConsulta.AppendLine(" saldo=pn.cantidad -isnull(( ")
        sConsulta.AppendLine("      select sum(td.cantidad) from transproddetalle td ")
        sConsulta.AppendLine("      inner join transprod T on td.transprodid = t.transprodid  ")
        sConsulta.AppendLine("      where tpd.prgid = td.prgid " + pvCondicionFechaTRP + " ),0) , ")
        sConsulta.AppendLine(" fase = CASE WHEN 1 = 1 " + pvCondicionFechaPN + "")
        sConsulta.AppendLine("      THEN ")
        sConsulta.AppendLine("      (SELECT     DESCRIPCION ")
        sConsulta.AppendLine("      FROM vavdescripcion ")
        sConsulta.AppendLine("      WHERE      VARCODIGO = 'prgfase' AND vadtipolenguaje = '" + Session("lenguaje") + "' AND vavclave = pn.tipofaseprp) ELSE ")
        sConsulta.AppendLine("      (SELECT     DESCRIPCION ")
        sConsulta.AppendLine("      FROM vavdescripcion ")
        sConsulta.AppendLine("      WHERE      VARCODIGO = 'prgfase' AND vadtipolenguaje = '" + Session("lenguaje") + "' AND vavclave = 1) END, ")
        sConsulta.AppendLine(" fechafase = CASE WHEN 1 = 1 " + pvCondicionFechaPN + "")
        sConsulta.AppendLine(" THEN pn.fechafase ELSE trp.fechahoraalta END ")
        sConsulta.AppendLine(" from productonegado PN  ")
        sConsulta.AppendLine(" inner join transproddetalle tpd on tpd.prgid = pn.prgid   ")
        sConsulta.AppendLine(" inner join transprod TRP on tpd.transprodid = TRP.transprodid  ")
        sConsulta.AppendLine(" inner join Transprod Pedido on PN.transprodid =  Pedido.transprodid  ")
        sConsulta.AppendLine(" inner join Promocion promo on pn.promocionclave = promo.promocionclave ")
        sConsulta.AppendLine(" inner join producto pro on pro.productoclave = pn.productoclave ")
        sConsulta.AppendLine(" inner join vavdescripcion unidad ON varcodigo = 'unidadv' AND vavclave = pn.tipounidad AND vadtipolenguaje = '" + Session("lenguaje") + "' ")
        sConsulta.AppendLine(" where (PN.tipoFasePRP = 2  and trp.tipofase <> 0  and trp.tipo=1 " + pvCondicionFechaTRP + " ) ")
        sConsulta.AppendLine(" or ")
        sConsulta.AppendLine(" (PN.tipoFasePRP = 2  and trp.tipofase <> 0  and trp.tipo=20  " + pvCondicionFechaTRP + " ) ")
        sConsulta.AppendLine(" ) as t1 ")
        sConsulta.AppendLine(" inner join  transprod TRP2 on TRP2.transprodid = t1.transprodid ")
        If pvFecha Then
            sConsulta.AppendLine(" where 1 = 1 " + strWhereFecha("", "TRP2.FechaSurtido") + " ")
        End If
        sConsulta.AppendLine(" ) as t2 ")

        sConsulta.AppendLine(" IF (SELECT object_id('tempdb..#Temp3')) IS NOT NULL DROP TABLE #Temp3 ")
        sConsulta.AppendLine(" SELECT * INTO #Temp3 FROM ")
        sConsulta.AppendLine(" (Select  ")
        sConsulta.AppendLine(" TRP.transprodid,  ")
        sConsulta.AppendLine(" ven.nombre as vendedor,  ")
        sConsulta.AppendLine(" cliente= (vis.clienteclave + ' ' + cli.nombrecorto) , ")
        sConsulta.AppendLine(" vis.rutclave as ruta ")
        sConsulta.AppendLine(" from Transprod TRP ")
        sConsulta.AppendLine(" inner join Visita VIS on vis.VisitaClave = trp.VisitaClave  ")
        sConsulta.AppendLine(" inner join vendedor VEN on vis.VendedorID = ven.VendedorID ")
        sConsulta.AppendLine(" inner join Cliente CLI on cli.clienteclave = vis.clienteclave ")
        sConsulta.AppendLine(" where  1=1 " & pvCondicionTemp3 & " ")
        sConsulta.AppendLine(" ) as t2 ")

        sConsulta.AppendLine(" select cliente, pedido, fecha, promocion, producto, unidad, cantidad, ruta, vendedor, saldo, fase, fechafase ")
        sConsulta.AppendLine(" from(  select * from #temp1 ")
        sConsulta.AppendLine(" union all ")
        sConsulta.AppendLine(" select * from #temp2) as t4 ")
        sConsulta.AppendLine(" inner join #temp3 on #temp3.transprodid = t4.transprodid ")

        sConsulta.AppendLine(" DROP TABLE #Temp1 ")
        sConsulta.AppendLine(" DROP TABLE #Temp2 ")
        sConsulta.AppendLine(" DROP TABLE #Temp3 ")
        sConsulta.AppendLine("set nocount Off ")

        Session("Query2") = sConsulta.ToString

        Return True
    End Function

    Private Function ConsultaLiquidacionBajoCero(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As StringBuilder

        'Ventas por Producto
        sConsulta = New StringBuilder

        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("select VendedorId, DiaClave, ALMClave, ProductoClave, PRONombre, InventarioInicial, Recarga, Bonificacion, Merma, CambiosDano, Promocion,Cancelacion, ")
        sConsulta.AppendLine("(InventarioInicial + Recarga - Bonificacion - Merma - CambiosDano - Ventas - Promocion - Cancelacion) as InventarioFinal, ")
        sConsulta.AppendLine("Ventas, Precio, Importe, Simbolo from ( ")
        sConsulta.AppendLine("Select VendedorId, DiaClave, ALMClave, ProductoClave, PRONombre, ")
        sConsulta.AppendLine("ISNULL((SELECT SUM(TD.Cantidad * PD.Factor) FROM TransProd as TR ")
        sConsulta.AppendLine("INNER JOIN TransProdDetalle as TD ON TD.TransProdId=TR.TransProdId ")
        sConsulta.AppendLine("INNER JOIN Producto as PR ON PR.ProductoClave=TD.ProductoClave ")
        sConsulta.AppendLine("INNER JOIN ProductoDetalle as PD ON PD.ProductoClave=PR.ProductoClave AND PD.PRUTipoUnidad=TD.TipoUnidad AND PD.ProductoDetClave=PR.ProductoClave ")
        sConsulta.AppendLine("INNER JOIN Vendedor as V ON V.USUId=TR.MUsuarioId AND V.TipoEstado=1 AND V.Baja=0 ")
        sConsulta.AppendLine("INNER JOIN VENCENTRODISTHIST as Vc ON V.vendedorid=Vc.vendedorid and convert(datetime,tr.DiaClave,103) between vc.vchfechainicial and vc.fechafinal ")
        sConsulta.AppendLine("INNER JOIN almacen as alm1 ON alm1.almacenid=Vc.almacenid ")
        sConsulta.AppendLine("WHERE TR.Tipo=23 and TR.TipoFase <> 0 and PR.ProductoClave = Liquidacion.ProductoClave AND V.VendedorId=Liquidacion.VendedorId and ")
        sConsulta.AppendLine("(SELECT TOP 1 convert(datetime,TRPD.DiaClave,103) FROM TRANSPROD TRPD ")
        sConsulta.AppendLine("INNER JOIN TransProdDetalle as TDd ON TDd.TransProdId=TRpd.TransProdId ")
        sConsulta.AppendLine("INNER JOIN Producto as PRr ON PRr.ProductoClave=TDd.ProductoClave ")
        sConsulta.AppendLine("INNER JOIN ProductoDetalle as PDd ON PDd.ProductoClave=PRr.ProductoClave AND PDd.PRUTipoUnidad=TDd.TipoUnidad AND PDd.ProductoDetClave=PRr.ProductoClave ")
        sConsulta.AppendLine("INNER JOIN Vendedor as Vv ON Vv.USUId=TRpd.MUsuarioId AND Vv.TipoEstado=1 AND Vv.Baja=0 ")
        sConsulta.AppendLine("INNER JOIN VENCENTRODISTHIST as Vcc ON Vv.vendedorid=Vcc.vendedorid and convert(datetime,trpd.DiaClave,103) between vcc.vchfechainicial and vcc.fechafinal ")
        sConsulta.AppendLine("INNER JOIN almacen as alm2 ON alm2.almacenid=Vcc.almacenid ")
        sConsulta.AppendLine("WHERE TRPD.Tipo=23 and TRPD.TipoFase <> 0 and PRr.ProductoClave = Liquidacion.ProductoClave AND Vv.VendedorId=Liquidacion.VendedorId and ")
        sConsulta.AppendLine("(SELECT MAX(convert(datetime,AGV.DiaClave,103)) FROM AgendaVendedor AGV WHERE convert(datetime,Liquidacion.DiaClave,103)>convert(datetime,AGV.DiaClave,103) AND AGV.VendedorId=Liquidacion.VendedorId)=convert(datetime,TRPD.DiaClave,103) ORDER BY convert(datetime,TRPD.DiaClave,103) desc  )=convert(datetime,TR.DiaClave,103) and alm1.Clave=Liquidacion.ALMClave ")
        sConsulta.AppendLine("),0) as InventarioInicial, ")
        sConsulta.AppendLine("(SELECT MAX(convert(datetime,AGV.DiaClave,103)) FROM AgendaVendedor AGV WHERE convert(datetime,Liquidacion.DiaClave,103)>convert(datetime,AGV.DiaClave,103) AND AGV.VendedorId=Liquidacion.VendedorId) as AGVDiaClave, ")
        sConsulta.AppendLine("ISNULL((SELECT SUM(TD.Cantidad * PD.Factor ) FROM TransProd as TR ")
        sConsulta.AppendLine("INNER JOIN TransProdDetalle as TD ON TD.TransProdId=TR.TransProdId ")
        sConsulta.AppendLine("INNER JOIN Producto as PR ON PR.ProductoClave=TD.ProductoClave ")
        sConsulta.AppendLine("INNER JOIN ProductoDetalle as PD ON PD.ProductoClave=PR.ProductoClave AND PD.PRUTipoUnidad=TD.TipoUnidad AND PD.ProductoDetClave=PR.ProductoClave ")
        sConsulta.AppendLine("INNER JOIN Vendedor as V ON V.USUId=TR.MUsuarioId AND V.TipoEstado=1 AND V.Baja=0 ")
        sConsulta.AppendLine("INNER JOIN VENCENTRODISTHIST as Vc ON V.vendedorid=Vc.vendedorid and convert(datetime,tr.DiaClave,103) between vc.vchfechainicial and vc.fechafinal ")
        sConsulta.AppendLine("INNER JOIN almacen as alm1 ON alm1.almacenid=Vc.almacenid ")
        sConsulta.AppendLine("WHERE(TR.Tipo = 2 And TR.TipoFase <> 0 And PR.ProductoClave = Liquidacion.ProductoClave And V.VendedorId = Liquidacion.VendedorId And TR.DiaClave = Liquidacion.DiaClave And alm1.Clave = Liquidacion.ALMClave) ")
        sConsulta.AppendLine("),0) as Recarga, ")
        sConsulta.AppendLine("sum(Bonificacion) as Bonificacion, sum(Merma) as Merma, sum(CambiosDano) as CambiosDano, sum(Promocion) as Promocion, sum(Cancelacion) as Cancelacion, ")
        sConsulta.AppendLine("sum(Venta) as Ventas, sum(Precio) as Precio, sum((Subtotal - DescCliPor - DescVendPor) + (Impuesto - DescCliPorImp)) as Importe,")
        sConsulta.AppendLine("(SELECT Simbolo FROM Moneda WHERE Moneda.MonedaId=(SELECT TOP 1 MonedaId FROM CONHist ORDER BY MFechaHora DESC)) as Simbolo ")
        sConsulta.AppendLine("From( ")
        sConsulta.AppendLine("SELECT VEN.VendedorId, VEN.Nombre as VENNombre,  TRP.DiaClave, ALM.Clave as ALMClave, ")
        sConsulta.AppendLine("TRP.Tipo, TPD.ProductoClave, PRO.Nombre as PRONombre, ")
        sConsulta.AppendLine("Bonificacion=(SELECT CASE WHEN TRP.Tipo=9 AND TRP.TipoMovimiento=2 and TRP.TransProdId in (select FacturaId from TransProd where Tipo=9 and TipoMovimiento=1 and TipoMotivo=4) THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Merma=(SELECT CASE WHEN TRP.Tipo=6 AND TRP.TipoMotivo<>4 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("CambiosDano=(SELECT CASE WHEN TRP.Tipo=9 AND TRP.TipoMovimiento=2 and TRP.TransProdId not in (select FacturaId from TransProd where Tipo=9 and TipoMovimiento=1 and TipoMotivo=4) THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Promocion=(SELECT CASE WHEN TRP.Tipo=1 AND TPD.Promocion=2 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Cancelacion=(SELECT CASE WHEN TRP.Tipo=7 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Venta=(SELECT CASE WHEN TRP.Tipo=1 AND TPD.Promocion<>2 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Precio = (SELECT CASE WHEN TRP.Tipo=1 AND TPD.Total>0 THEN TPD.Precio * TPD.Cantidad ELSE 0 END), ")
        sConsulta.AppendLine("SubTotal=(SELECT CASE WHEN TRP.Tipo=1  AND TPD.Total>0 THEN TPD.Subtotal ELSE 0 END), ")
        sConsulta.AppendLine("DescCliPor=(SELECT CASE WHEN TRP.Tipo=1  AND TPD.Total>0 THEN (SELECT (CASE WHEN sum(DesImporte) IS NULL THEN 0 ELSE sum(DesImporte) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) ELSE 0 End), ")
        sConsulta.AppendLine("DescVendPor=(SELECT CASE WHEN TRP.Tipo=1  AND TPD.Total>0 THEN TPD.Subtotal- (SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE sum(DesImpuesto) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) ELSE 0 END)*(SELECT CASE WHEN TRP.Tipo=1 AND TPD.Total>0 THEN (SELECT CASE WHEN TRP.DescVendPor IS NULL THEN 0 ELSE TRP.DescVendPor END) ELSE 0 END)/100, ")
        sConsulta.AppendLine("Impuesto=(SELECT CASE WHEN TRP.Tipo=1  AND TPD.Total>0 THEN (SELECT CASE WHEN TPD.Impuesto IS NULL THEN 0 ELSE TPD.Impuesto END) ELSE 0 END), ")
        sConsulta.AppendLine("DescCliPorImp=(SELECT CASE WHEN TRP.Tipo=1  AND TPD.Total>0 THEN (SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE sum(DesImpuesto) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) ELSE 0 End) ")
        sConsulta.AppendLine("FROM TransProd as TRP INNER JOIN TransProdDetalle as TPD ON TPD.TransProdId=TRP.TransProdId ")
        sConsulta.AppendLine("left join TransProd as TRP1 on TRP.FacturaId = TRP1.TransProdId ")
        sConsulta.AppendLine("INNER JOIN Producto as PRO ON PRO.ProductoClave=TPD.ProductoClave ")
        sConsulta.AppendLine("INNER JOIN ProductoDetalle as PDD ON PDD.ProductoClave=TPD.ProductoClave AND PDD.PRUTipoUnidad=TPD.TipoUnidad AND PDD.ProductoDetClave=TPD.ProductoClave ")
        sConsulta.AppendLine("INNER JOIN Usuario as USU ON USU.USUId=TRP.MUsuarioId ")
        sConsulta.AppendLine("INNER JOIN Vendedor as VEN ON VEN.USUId=TRP.MUsuarioId AND VEN.TipoEstado=1 AND VEN.Baja=0 ")
        sConsulta.AppendLine("INNER JOIN VENCENTRODISTHIST as Vcd ON Ven.vendedorid=Vcd.vendedorid and convert(datetime,trp.DiaClave,103) between vcd.vchfechainicial and vcd.fechafinal ")
        sConsulta.AppendLine("INNER JOIN almacen as alm ON alm.almacenid=Vcd.almacenid ")
        sConsulta.AppendLine("WHERE TRP.Tipo IN (1,2,6,9,7) AND TRP.TipoFase<>0 ")

        Dim sCondicionVentas As String = String.Empty
        If chboxVendedor.Checked Then
            sCondicionVentas = "and VEN.VendedorId = '" + ddlVendedor.Text + "' "
        End If
        If chboxFecha.Checked Then
            sConsulta.AppendLine(strWhereFecha(sCondicionVentas, "Convert(datetime,TRP.DiaClave,103)"))
        Else
            sConsulta.AppendLine(sCondicionVentas)
        End If
        If (ChBoxCentroDistribucion.Checked) Then
            Session("CEDI") = Me.DdlCentroDistribucion.SelectedItem.Text
            sConsulta.AppendLine(" AND alm.clave = '" + DdlCentroDistribucion.SelectedValue + "' ")
        Else
            Session("CEDI") = ""
        End If
        sConsulta.AppendLine(" UNION ALL ")
        sConsulta.AppendLine("select  VEN.VendedorId, VEN.Nombre as VENNombre,  TRP.DiaClave, ALM.Clave as ALMClave, TRP.Tipo, TPD.ProductoClave, PRO.Nombre as PRONombre, ")
        sConsulta.AppendLine(" Bonificacion=0,Merma=0,CambiosDano=0,Promocion=0,Cancelacion=0,Venta=0,Precio = 0, SubTotal=0,DescCliPor=0,DescVendPor=0, Impuesto=0, DescCliPorImp=0 ")
        sConsulta.AppendLine("FROM TransProd as TRP INNER JOIN TransProdDetalle as TPD ON TPD.TransProdId=TRP.TransProdId ")
        sConsulta.AppendLine("INNER JOIN Producto as PRO ON PRO.ProductoClave=TPD.ProductoClave ")
        sConsulta.AppendLine("INNER JOIN ProductoDetalle as PDD ON PDD.ProductoClave=TPD.ProductoClave AND PDD.PRUTipoUnidad=TPD.TipoUnidad AND PDD.ProductoDetClave=TPD.ProductoClave ")
        sConsulta.AppendLine("INNER JOIN Usuario as USU ON USU.USUId=TRP.MUsuarioId ")
        sConsulta.AppendLine("INNER JOIN Vendedor as VEN ON VEN.USUId=TRP.MUsuarioId AND VEN.TipoEstado=1 AND VEN.Baja=0 ")
        sConsulta.AppendLine("INNER JOIN VENCENTRODISTHIST as Vcd ON Ven.vendedorid=Vcd.vendedorid and convert(datetime,trp.DiaClave,103) between vcd.vchfechainicial and vcd.fechafinal ")
        sConsulta.AppendLine("INNER JOIN almacen as alm ON alm.almacenid=Vcd.almacenid  ")
        sConsulta.AppendLine("WHERE TRP.Tipo=23 AND TRP.TipoFase<>0   ")

        If chboxVendedor.Checked Then
            sCondicionVentas = "and VEN.VendedorId = '" + ddlVendedor.Text + "' "
        End If


        If chboxFecha.Checked Then
            sConsulta.AppendLine(strWhereFecha(sCondicionVentas, "Convert(datetime,TRP.DiaClave,103)"))
        Else
            sConsulta.AppendLine(sCondicionVentas)
        End If

        If (ChBoxCentroDistribucion.Checked) Then
            Session("CEDI") = Me.DdlCentroDistribucion.SelectedItem.Text
            sConsulta.AppendLine(" AND alm.clave = '" + DdlCentroDistribucion.SelectedValue + "' ")
        Else
            Session("CEDI") = ""
        End If



        sConsulta.AppendLine(" UNION ALL ")
        sConsulta.AppendLine("select  VEN.VendedorId, VEN.Nombre as VENNombre, ")
        sConsulta.AppendLine("(SELECT CONVERT(varchar(20),MIN(convert(datetime,AGV.DiaClave,103)),103) FROM AgendaVendedor AGV WHERE convert(datetime,TRP.DiaClave,103)<convert(datetime,AGV.DiaClave,103) AND AGV.VendedorId=VEN.VendedorId) as DiaClave, ")
        sConsulta.AppendLine("ALM.Clave as ALMClave, TRP.Tipo, TPD.ProductoClave, PRO.Nombre as PRONombre, ")
        sConsulta.AppendLine(" Bonificacion=0,Merma=0,CambiosDano=0,Promocion=0,Cancelacion=0,Venta=0,Precio = 0, SubTotal=0,DescCliPor=0,DescVendPor=0, Impuesto=0, DescCliPorImp=0 ")
        sConsulta.AppendLine("FROM TransProd as TRP INNER JOIN TransProdDetalle as TPD ON TPD.TransProdId=TRP.TransProdId ")
        sConsulta.AppendLine("INNER JOIN Producto as PRO ON PRO.ProductoClave=TPD.ProductoClave ")
        sConsulta.AppendLine("INNER JOIN ProductoDetalle as PDD ON PDD.ProductoClave=TPD.ProductoClave AND PDD.PRUTipoUnidad=TPD.TipoUnidad AND PDD.ProductoDetClave=TPD.ProductoClave ")
        sConsulta.AppendLine("INNER JOIN Usuario as USU ON USU.USUId=TRP.MUsuarioId ")
        sConsulta.AppendLine("INNER JOIN Vendedor as VEN ON VEN.USUId=TRP.MUsuarioId AND VEN.TipoEstado=1 AND VEN.Baja=0 ")
        sConsulta.AppendLine("INNER JOIN VENCENTRODISTHIST as Vcd ON Ven.vendedorid=Vcd.vendedorid and convert(datetime,trp.DiaClave,103) between vcd.vchfechainicial and vcd.fechafinal ")
        sConsulta.AppendLine("INNER JOIN almacen as alm ON alm.almacenid=Vcd.almacenid  ")
        sConsulta.AppendLine("WHERE TRP.Tipo=23 AND TRP.TipoFase<>0   ")

        If chboxVendedor.Checked Then
            sCondicionVentas = "and VEN.VendedorId = '" + ddlVendedor.Text + "' "
        End If


        If chboxFecha.Checked Then
            sConsulta.AppendLine(strWhereFecha(sCondicionVentas, "(SELECT MIN(convert(datetime,AGV.DiaClave,103)) FROM AgendaVendedor AGV WHERE convert(datetime,TRP.DiaClave,103)<convert(datetime,AGV.DiaClave,103) AND AGV.VendedorId=VEN.VendedorId)"))
        Else
            sConsulta.AppendLine(sCondicionVentas)
        End If

        If (ChBoxCentroDistribucion.Checked) Then
            Session("CEDI") = Me.DdlCentroDistribucion.SelectedItem.Text
            sConsulta.AppendLine(" AND alm.clave = '" + DdlCentroDistribucion.SelectedValue + "' ")
        Else
            Session("CEDI") = ""
        End If


        sConsulta.AppendLine(") as Liquidacion GROUP BY VendedorId, DiaClave, ALMClave, ProductoClave, PRONombre ")
        sConsulta.AppendLine(")as Liquidacion order by ProductoClave ")

        Session("VentasProductos") = sConsulta.ToString


        'Seccion Gastos Efectuados
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("SELECT VendedorId, DiaClave, Folio, ")
        sConsulta.AppendLine("(SELECT Descripcion FROM VAVDescripcion VAD WHERE VAD.VAVClave = Gasto.TipoConcepto AND VAD.VARCodigo = 'GASTIPO' AND VAD.VADTipoLenguaje = '" + Session("lenguaje") + "') as Concepto, ")
        sConsulta.AppendLine("Comentario as Kilometros, Total as Litros FROM Gasto ")
        sConsulta.AppendLine("WHERE 1=1 ")

        If chboxVendedor.Checked Then
            sConsulta.AppendLine("and Gasto.VendedorId = '" + ddlVendedor.Text + "' ")
        End If
        If chboxFecha.Checked Then
            sConsulta.AppendLine(strWhereFecha("", "Convert(datetime,Gasto.DiaClave,103)"))
        End If

        Session("Gastos") = sConsulta.ToString

        'Sección Ventas Efectivo
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("SELECT VEN.VendedorID, TRP.DiaClave, ALM.Clave as ALMClave, TRP.Folio, TRP.FechaHoraAlta, (CLI.Clave + ' ' + CLI.RazonSocial) as Cliente, ")
        sConsulta.AppendLine("(SELECT Simbolo FROM Moneda WHERE Moneda.MonedaId=(SELECT TOP 1 MonedaId FROM CONHist ORDER BY MFechaHora DESC)) as Simbolo, TRP.Total ")
        sConsulta.AppendLine("FROM TransProd TRP ")
        sConsulta.AppendLine("INNER JOIN Visita VIS on VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave=TRP.DiaClave ")
        sConsulta.AppendLine("INNER JOIN Cliente CLI ON CLI.ClienteClave=TRP.ClienteClave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VEN.VendedorID = VIS.VendedorID ")
        sConsulta.AppendLine("INNER JOIN VENCENTRODISTHIST as Vcd ON Ven.vendedorid=Vcd.vendedorid and convert(datetime,trp.DiaClave,103) between vcd.vchfechainicial and vcd.fechafinal ")
        sConsulta.AppendLine("INNER JOIN almacen as alm ON alm.almacenid=Vcd.almacenid ")
        sConsulta.AppendLine("WHERE TRP.Tipo = 1 And TRP.TipoFase <> 0 And TRP.CFVTipo = 1 ")

        If chboxVendedor.Checked Then
            sConsulta.AppendLine("and VEN.VendedorId = '" + ddlVendedor.Text + "' ")
        End If
        If chboxFecha.Checked Then
            sConsulta.AppendLine(strWhereFecha("", "Convert(datetime,TRP.DiaClave,103)"))
        End If
        If (ChBoxCentroDistribucion.Checked) Then
            sConsulta.AppendLine(" AND alm.clave = '" + DdlCentroDistribucion.SelectedValue + "' ")
        End If

        Session("VentasEfectivo") = sConsulta.ToString

        'Sección Ventas Credito
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("SELECT VEN.VendedorID, TRP.DiaClave, ALM.Clave as ALMClave, TRP.Folio, TRP.FechaHoraAlta, (CLI.Clave + ' ' + CLI.RazonSocial) as Cliente, ")
        sConsulta.AppendLine("(SELECT Simbolo FROM Moneda WHERE Moneda.MonedaId=(SELECT TOP 1 MonedaId FROM CONHist ORDER BY MFechaHora DESC)) as Simbolo, TRP.Total ")
        sConsulta.AppendLine("FROM TransProd TRP ")
        sConsulta.AppendLine("INNER JOIN Visita VIS on VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave=TRP.DiaClave ")
        sConsulta.AppendLine("INNER JOIN Cliente CLI ON CLI.ClienteClave=TRP.ClienteClave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VEN.VendedorID = VIS.VendedorID ")
        sConsulta.AppendLine("INNER JOIN VENCENTRODISTHIST as Vcd ON Ven.vendedorid=Vcd.vendedorid and convert(datetime,trp.DiaClave,103) between vcd.vchfechainicial and vcd.fechafinal ")
        sConsulta.AppendLine("INNER JOIN almacen as alm ON alm.almacenid=Vcd.almacenid ")
        sConsulta.AppendLine("WHERE TRP.Tipo=1 AND TRP.TipoFase<>0 AND TRP.CFVTipo=2 ")

        If chboxVendedor.Checked Then
            sConsulta.AppendLine("and VEN.VendedorId = '" + ddlVendedor.Text + "' ")
        End If
        If chboxFecha.Checked Then
            sConsulta.AppendLine(strWhereFecha("", "Convert(datetime,TRP.DiaClave,103)"))
        End If
        If (ChBoxCentroDistribucion.Checked) Then
            sConsulta.AppendLine(" AND alm.clave = '" + DdlCentroDistribucion.SelectedValue + "' ")
        End If

        Session("VentasCredito") = sConsulta.ToString


        'Seccion Depositos y Efectivo
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("SELECT VendedorId, FechaPreLiquidacion, Tipo, Denominacion, Cantidad, Referencia, Ficha, Banco, ")
        sConsulta.AppendLine("(SELECT Simbolo FROM Moneda WHERE Moneda.MonedaId=(SELECT TOP 1 MonedaId FROM CONHist ORDER BY MFechaHora DESC)) as Simbolo, Importe ")
        sConsulta.AppendLine("FROM ")
        sConsulta.AppendLine("( ")
        sConsulta.AppendLine("SELECT VendedorId, FechaPreLiquidacion, (SELECT Descripcion FROM MENDetalle WHERE MENClave='XEfectivo' AND MEDTipoLenguaje='" + Session("lenguaje") + "') as Tipo, ")
        sConsulta.AppendLine("Denominacion, sum(Cantidad) as Cantidad, Referencia = '', Ficha = '', Banco='', ")
        sConsulta.AppendLine("(cast(Denominacion as float) * sum(Cantidad)) as Importe ")
        sConsulta.AppendLine("FROM ")
        sConsulta.AppendLine("( ")
        sConsulta.AppendLine("SELECT PLI.VendedorId, convert(datetime, convert(varchar(10), PLI.FechaPreLiquidacion, 112)) as FechaPreLiquidacion, (SELECT Descripcion FROM VAVDescripcion VAD WHERE VAD.VAVClave = PLE.TipoEfectivo AND VAD.VARCodigo = 'DENOMINA' AND VAD.VADTipoLenguaje = '" + Session("lenguaje") + "') as Denominacion, ")
        sConsulta.AppendLine("PLE.Cantidad ")
        sConsulta.AppendLine("FROM Preliquidacion PLI ")
        sConsulta.AppendLine("INNER JOIN PLIEfectivo PLE ON PLE.PLIId=PLI.PLIId ")
        sConsulta.AppendLine("WHERE 1=1 ")

        If chboxVendedor.Checked Then
            sConsulta.AppendLine("and PLI.VendedorId = '" + ddlVendedor.Text + "' ")
        End If
        If chboxFecha.Checked Then
            sConsulta.AppendLine(strWhereFecha("", "PLI.FechaPreliquidacion"))
        End If

        sConsulta.AppendLine(") as Resultado ")
        sConsulta.AppendLine("GROUP BY VendedorId, FechaPreLiquidacion, Denominacion ")

        sConsulta.AppendLine("UNION ALL ")

        sConsulta.AppendLine("SELECT PLI.VendedorId, convert(datetime, convert(varchar(10), PLI.FechaPreLiquidacion, 112)) as FechaPreLiquidacion, ")
        sConsulta.AppendLine("(SELECT Descripcion FROM MENDetalle WHERE MENClave='XDeposito' AND MEDTipoLenguaje='" + Session("lenguaje") + "') as Tipo, ")
        sConsulta.AppendLine("Denominacion='', Cantidad=0, PLB.Referencia, PLB.Ficha, ")
        sConsulta.AppendLine("(SELECT Descripcion FROM VAVDescripcion VAD WHERE VAD.VAVClave = PLB.TipoBanco AND VAD.VARCodigo = 'TBANCO' AND VAD.VADTipoLenguaje = '" + Session("lenguaje") + "') as Banco, ")
        sConsulta.AppendLine("PLB.Total ")
        sConsulta.AppendLine("FROM Preliquidacion PLI ")
        sConsulta.AppendLine("INNER JOIN PLIBancario PLB ON PLB.PLIId=PLI.PLIId ")
        sConsulta.AppendLine("WHERE 1=1 ")

        If chboxVendedor.Checked Then
            sConsulta.AppendLine("and PLI.VendedorId = '" + ddlVendedor.Text + "' ")
        End If
        If chboxFecha.Checked Then
            sConsulta.AppendLine(strWhereFecha("", "PLI.FechaPreliquidacion"))
        End If

        sConsulta.AppendLine(") as Resultado ")

        Session("DepositosEfectivo") = sConsulta.ToString

        'Seccion Resumen
        'sConsulta = New StringBuilder
        'sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        'sConsulta.AppendLine("SELECT USUClave, VendedorId, VENNombre, ALMClave, ALMNombre, (SELECT Simbolo FROM Moneda WHERE Moneda.MonedaId=(SELECT TOP 1 MonedaId FROM CONHist ORDER BY MFechaHora DESC)) as Simbolo, ")
        'sConsulta.AppendLine("sum(TotalCredito) as TotalCredito, sum(TotalVenta) as TotalVenta, (SELECT TOP 1 NombreEmpresa FROM Configuracion) as NombreEmpresa ")
        'sConsulta.AppendLine("FROM ")
        'sConsulta.AppendLine("( ")
        'sConsulta.AppendLine("Select USUClave, VendedorId, VENNombre, ALMClave, ALMNombre, TotalCredito=0, sum((Subtotal - DescCliPor - DescVendPor) + (Impuesto - DescCliPorImp)) as TotalVenta ")
        'sConsulta.AppendLine("From ")
        'sConsulta.AppendLine("( ")
        'sConsulta.AppendLine("SELECT USU.Clave as USUClave, VEN.VendedorId, VEN.Nombre as VENNombre, ALM.Clave as ALMClave, ALM.Nombre as ALMNombre, ")
        'sConsulta.AppendLine("Precio = (SELECT CASE WHEN TRP.Tipo=1 AND TPD.Total>0 THEN TPD.Precio * TPD.Cantidad ELSE 0 END), ")
        'sConsulta.AppendLine("SubTotal=(SELECT CASE WHEN TRP.Tipo=1  AND TPD.Total>0 THEN TPD.Subtotal ELSE 0 END), ")
        'sConsulta.AppendLine("DescCliPor=(SELECT CASE WHEN TRP.Tipo=1  AND TPD.Total>0 THEN (SELECT (CASE WHEN sum(DesImporte) IS NULL THEN 0 ELSE sum(DesImporte) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) ELSE 0 End), ")
        'sConsulta.AppendLine("DescVendPor=(SELECT CASE WHEN TRP.Tipo=1 AND TPD.Total>0 THEN (SELECT CASE WHEN TRP.DescVendPor IS NULL THEN 0 ELSE TRP.DescVendPor END) ELSE 0 END), ")
        'sConsulta.AppendLine("Impuesto=(SELECT CASE WHEN TRP.Tipo=1  AND TPD.Total>0 THEN (SELECT CASE WHEN TPD.Impuesto IS NULL THEN 0 ELSE TPD.Impuesto END) ELSE 0 END), ")
        'sConsulta.AppendLine("DescCliPorImp=(SELECT CASE WHEN TRP.Tipo=1  AND TPD.Total>0 THEN (SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE sum(DesImpuesto) END) FROM TpdDes AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) ELSE 0 End) ")
        'sConsulta.AppendLine("FROM TransProd as TRP INNER JOIN TransProdDetalle as TPD ON TPD.TransProdId=TRP.TransProdId ")
        'sConsulta.AppendLine("INNER JOIN Producto as PRO ON PRO.ProductoClave=TPD.ProductoClave ")
        'sConsulta.AppendLine("INNER JOIN ProductoDetalle as PDD ON PDD.ProductoClave=TPD.ProductoClave AND PDD.PRUTipoUnidad=TPD.TipoUnidad AND PDD.ProductoDetClave=TPD.ProductoClave ")
        'sConsulta.AppendLine("INNER JOIN Usuario as USU ON USU.USUId=TRP.MUsuarioId ")
        'sConsulta.AppendLine("INNER JOIN Vendedor as VEN ON VEN.USUId=TRP.MUsuarioId AND VEN.TipoEstado=1 AND VEN.Baja=0 ")
        'sConsulta.AppendLine("INNER JOIN VENCENTRODISTHIST as Vcd ON Ven.vendedorid=Vcd.vendedorid and convert(datetime,trp.DiaClave,103) between vcd.vchfechainicial and vcd.fechafinal ")
        'sConsulta.AppendLine("INNER JOIN almacen as alm ON alm.almacenid=Vcd.almacenid  ")
        'sConsulta.AppendLine("WHERE TRP.Tipo IN (1,2,6,9) AND TRP.TipoFase<>0  ")

        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("SELECT USUClave, VendedorId, VENNombre, ALMClave, ALMNombre, (SELECT Simbolo FROM Moneda WHERE Moneda.MonedaId=(SELECT TOP 1 MonedaId FROM CONHist ORDER BY MFechaHora DESC)) as Simbolo, ")
        sConsulta.AppendLine("sum(TotalCredito) as TotalCredito, sum(TotalVenta) as TotalVenta, (SELECT TOP 1 NombreEmpresa FROM Configuracion) as NombreEmpresa ")
        sConsulta.AppendLine("FROM ")
        sConsulta.AppendLine("( ")
        sConsulta.AppendLine("Select USUClave, VendedorId, VENNombre, ALMClave, ALMNombre, TotalCredito=0, sum(total) as TotalVenta ")
        sConsulta.AppendLine("From ")
        sConsulta.AppendLine("( ")
        sConsulta.AppendLine("SELECT USU.Clave as USUClave, VEN.VendedorId, VEN.Nombre as VENNombre, ALM.Clave as ALMClave, ALM.Nombre as ALMNombre, ")
        sConsulta.AppendLine("trp.total ")
        sConsulta.AppendLine("FROM TransProd as TRP  ")
        sConsulta.AppendLine("INNER JOIN Usuario as USU ON USU.USUId=TRP.MUsuarioId ")
        sConsulta.AppendLine("INNER JOIN Vendedor as VEN ON VEN.USUId=TRP.MUsuarioId AND VEN.TipoEstado=1 AND VEN.Baja=0 ")
        sConsulta.AppendLine("INNER JOIN VENCENTRODISTHIST as Vcd ON Ven.vendedorid=Vcd.vendedorid and convert(datetime,trp.DiaClave,103) between vcd.vchfechainicial and vcd.fechafinal ")
        sConsulta.AppendLine("INNER JOIN almacen as alm ON alm.almacenid=Vcd.almacenid  ")
        sConsulta.AppendLine("WHERE  TRP.TipoFase<>0  ")

        If chboxVendedor.Checked Then
            sConsulta.AppendLine("and VEN.VendedorId = '" + ddlVendedor.Text + "' ")
        End If
        If chboxFecha.Checked Then
            sConsulta.AppendLine(strWhereFecha("", "Convert(datetime,TRP.DiaClave,103)"))
        End If
        If (ChBoxCentroDistribucion.Checked) Then
            sConsulta.AppendLine(" AND alm.clave = '" + DdlCentroDistribucion.SelectedValue + "' ")
        End If

        sConsulta.AppendLine(") as Liquidacion GROUP BY USUClave, VendedorId, VENNombre, ALMClave, ALMNombre ")
        sConsulta.AppendLine("union all ")
        sConsulta.AppendLine("SELECT USU.Clave as USUClave, VEN.VendedorID, VEN.Nombre as VENNombre, ALM.Clave as ALMClave, ALM.Nombre as ALMNombre, sum(TRP.Total) as TotalCredito, TotalVentas=0 ")
        sConsulta.AppendLine("FROM TransProd TRP ")
        sConsulta.AppendLine("INNER JOIN Visita VIS on VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave=TRP.DiaClave ")
        sConsulta.AppendLine("INNER JOIN Cliente CLI ON CLI.ClienteClave=TRP.ClienteClave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VEN.VendedorID = VIS.VendedorID ")
        sConsulta.AppendLine("INNER JOIN Usuario as USU ON USU.USUId=VEN.USUId ")
        sConsulta.AppendLine("INNER JOIN VENCENTRODISTHIST as Vcd ON Ven.vendedorid=Vcd.vendedorid and convert(datetime,trp.DiaClave,103) between vcd.vchfechainicial and vcd.fechafinal ")
        sConsulta.AppendLine("INNER JOIN almacen as alm ON alm.almacenid=Vcd.almacenid  ")
        sConsulta.AppendLine("WHERE  TRP.TipoFase<>0 AND TRP.CFVTipo=2 ")

        If chboxVendedor.Checked Then
            sConsulta.AppendLine("and VEN.VendedorId = '" + ddlVendedor.Text + "' ")
        End If
        If chboxFecha.Checked Then
            sConsulta.AppendLine(strWhereFecha("", "Convert(datetime,TRP.DiaClave,103)"))
        End If
        If (ChBoxCentroDistribucion.Checked) Then
            sConsulta.AppendLine(" AND alm.clave = '" + DdlCentroDistribucion.SelectedValue + "' ")
        End If

        sConsulta.AppendLine("GROUP BY USU.Clave, VEN.VendedorID, VEN.Nombre, ALM.Clave, ALM.Nombre ")
        sConsulta.AppendLine(") as Resultado ")
        sConsulta.AppendLine("GROUP BY USUClave, VendedorId, VENNombre, ALMClave, ALMNombre ")

        Session("Resumen") = sConsulta.ToString


        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(Session("Resumen"), IntCommandTimeOut)
        If (dt.Rows.Count > 0) Then
            Session("Resumen") = dt
            Return True
        Else
            Return False
        End If
    End Function

    Private Function ConsultaActivosBajoCero(ByVal ins As DBConexion.cConexionSQL, ByVal pvTipoActivo As enActivo, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvClientes As ArrayList, ByVal pvActivos As ArrayList) As Boolean
        Dim sConsulta As New StringBuilder
        Dim oMensaje As New DBConexion.cMensaje

        If pvTipoActivo = enActivo.Asginados Then
            If chboxVendedor.Checked Then
                pvCondicion = "where VEN.VendedorId = '" + ddlVendedor.SelectedValue + "' "
            Else
                pvCondicion = "where 1=1 "
            End If
            pvCondicion = strWhereCentrosDistribucion(pvCondicion, "ALM.Clave")
            pvCondicion = strWhereRutas(pvCondicion, pvRutas, "RUT.RUTClave")
            pvCondicion = strWhereClientes(pvCondicion, pvClientes, "CLI.ClienteClave")

            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("set nocount on ")
            sConsulta.AppendLine("SELECT ALM.Clave as ALMClave, ALM.Nombre as ALMNombre, VEN.VendedorId, VEN.Nombre as VENNombre, RUT.RUTClave, RUT.Descripcion as RUTDescripcion, ")
            sConsulta.AppendLine("CLI.Clave as ClienteClave, CLI.RazonSocial, ACT.ActivoClave, ACT.Nombre, ")
            sConsulta.AppendLine("(SELECT Descripcion FROM VAVDescripcion VAD WHERE VAD.VAVClave = ACT.Tipo AND VAD.VARCodigo = 'ACITIPO' AND VAD.VADTipoLenguaje = 'EM') as Tipo, ")
            sConsulta.AppendLine("ACT.IdElectronico, ACT.Altura, ACT.Ancho, ACT.Profundidad, ")
            sConsulta.AppendLine("(SELECT Descripcion FROM VAVDescripcion VAD WHERE VAD.VAVClave = ACT.TipoFase AND VAD.VARCodigo = 'ACIFASE' AND VAD.VADTipoLenguaje = 'EM') as TipoFase, ")
            sConsulta.AppendLine("(SELECT Descripcion FROM VAVDescripcion VAD WHERE VAD.VAVClave = ACT.TipoEstado AND VAD.VARCodigo = 'EDOREG' AND VAD.VADTipoLenguaje = 'EM') as TipoEstado, ")
            sConsulta.AppendLine("(SELECT TOP 1 ACS.FechaServicio FROM ActivoServicio ACS WHERE ACS.ActivoClave=ACT.ActivoClave ORDER BY FechaServicio Desc) as FechaServicio ")
            sConsulta.AppendLine("FROM Activo ACT ")
            sConsulta.AppendLine("INNER JOIN (SELECT ActivoClave, MAX(Fecha) as Fecha FROM ActivoClienteHist GROUP BY ActivoClave) ACH1 ON ACH1.ActivoClave=ACT.ActivoClave ")
            sConsulta.AppendLine("INNER JOIN ActivoClienteHist ACH ON ACH.ActivoClave=ACH1.ActivoClave AND ACH.Fecha=ACH1.Fecha  and ach.asignacion=2")
            sConsulta.AppendLine("INNER JOIN Vendedor VEN ON VEN.USUId=ACH.MUsuarioId ")
            sConsulta.AppendLine("INNER JOIN (SELECT VDH.VendedorId, VDH.AlmacenId, MAX(VDH.VCHFechaInicial) as FechaInicial FROM VENCentroDistHist VDH GROUP BY VDH.VendedorId, VDH.AlmacenId) VDH1 ON VDH1.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("INNER JOIN Almacen ALM ON ALM.AlmacenId=VDH1.AlmacenId ")
            sConsulta.AppendLine("INNER JOIN VenRut VRT ON VRT.VendedorId=VEN.VendedorId AND VRT.TipoEstado=1 ")
            sConsulta.AppendLine("INNER JOIN Ruta RUT ON RUT.RUTClave=VRT.RUTClave ")
            sConsulta.AppendLine("inner join (select distinct rutclave,clienteclave from secuencia) as sec on sec.rutclave=RUT.RUTClave")
            sConsulta.AppendLine("INNER JOIN Cliente CLI ON CLI.ClienteClave=ACH.ClienteClave and cli.ClienteClave=sec.ClienteClave ")
            sConsulta.AppendLine(pvCondicion)
            sConsulta.AppendLine("set nocount off ")

            Session("TipoReporte") = "Asignados"
            Session("Nombre") = Session("Nombre") & " - " & oMensaje.RecuperarDescripcion("XAsignados")
        ElseIf pvTipoActivo = enActivo.NoAsignados Then
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("set nocount on ")
            sConsulta.AppendLine("SELECT ACT.ActivoClave, ACT.Nombre, ")
            sConsulta.AppendLine("(SELECT Descripcion FROM VAVDescripcion VAD WHERE VAD.VAVClave = ACT.Tipo AND VAD.VARCodigo = 'ACITIPO' AND VAD.VADTipoLenguaje = 'EM') as Tipo, ")
            sConsulta.AppendLine("ACT.IdElectronico, ACT.Altura, ACT.Ancho, ACT.Profundidad, ")
            sConsulta.AppendLine("(SELECT Descripcion FROM VAVDescripcion VAD WHERE VAD.VAVClave = ACT.TipoFase AND VAD.VARCodigo = 'ACIFASE' AND VAD.VADTipoLenguaje = 'EM') as TipoFase, ")
            sConsulta.AppendLine("(SELECT Descripcion FROM VAVDescripcion VAD WHERE VAD.VAVClave = ACT.TipoEstado AND VAD.VARCodigo = 'EDOREG' AND VAD.VADTipoLenguaje = 'EM') as TipoEstado, ")
            sConsulta.AppendLine("(SELECT TOP 1 ACS.FechaServicio FROM ActivoServicio ACS WHERE ACS.ActivoClave=ACT.ActivoClave ORDER BY FechaServicio Desc) as FechaServicio ")
            sConsulta.AppendLine("FROM Activo ACT ")
            sConsulta.AppendLine("INNER JOIN (SELECT ActivoClave, MAX(Fecha) as Fecha FROM ActivoClienteHist  GROUP BY ActivoClave) ACH1 ON ACH1.ActivoClave=ACT.ActivoClave ")
            sConsulta.AppendLine("INNER JOIN ActivoClienteHist ACH ON ACH.ActivoClave=ACH1.ActivoClave AND ACH.Fecha=ACH1.Fecha  and ACH.asignacion =1 ")
            sConsulta.AppendLine("set nocount off ")

            Session("TipoReporte") = "NoAsignados"
            Session("Nombre") = Session("Nombre") & " - " & oMensaje.RecuperarDescripcion("XNoAsignados")
        ElseIf pvTipoActivo = enActivo.PorFiltro Then
            pvCondicion = "WHERE 1=1 "
            pvCondicion = strWhereActivos(pvCondicion, pvActivos, "Resultado.ActivoClave")

            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("set nocount on ")
            sConsulta.AppendLine("SELECT RUTClave, RUTDescripcion, ClienteClave, RazonSocial, ActivoClave, Nombre, Tipo, IdElectronico, Altura, Ancho, Profundidad, TipoFase, TipoEstado, ")
            sConsulta.AppendLine("(SELECT TOP 1 ACS.FechaServicio FROM ActivoServicio ACS WHERE ACS.ActivoClave=Resultado.ActivoClave ORDER BY ACS.FechaServicio Desc) as FechaServicio, ")
            sConsulta.AppendLine("Asignado ")
            sConsulta.AppendLine("FROM ")
            sConsulta.AppendLine("( ")
            sConsulta.AppendLine("SELECT RUT.RUTClave, RUT.Descripcion as RUTDescripcion, ")
            sConsulta.AppendLine("CLI.Clave as ClienteClave, CLI.RazonSocial, ACT.ActivoClave, ACT.Nombre,  ")
            sConsulta.AppendLine("(SELECT Descripcion FROM VAVDescripcion VAD WHERE VAD.VAVClave = ACT.Tipo AND VAD.VARCodigo = 'ACITIPO' AND VAD.VADTipoLenguaje = 'EM') as Tipo, ")
            sConsulta.AppendLine("ACT.IdElectronico, ACT.Altura, ACT.Ancho, ACT.Profundidad, ")
            sConsulta.AppendLine("(SELECT Descripcion FROM VAVDescripcion VAD WHERE VAD.VAVClave = ACT.TipoFase AND VAD.VARCodigo = 'ACIFASE' AND VAD.VADTipoLenguaje = 'EM') as TipoFase, ")
            sConsulta.AppendLine("(SELECT Descripcion FROM VAVDescripcion VAD WHERE VAD.VAVClave = ACT.TipoEstado AND VAD.VARCodigo = 'EDOREG' AND VAD.VADTipoLenguaje = 'EM') as TipoEstado, ")
            sConsulta.AppendLine("Asignado=1 ")
            sConsulta.AppendLine("FROM Activo ACT ")
            sConsulta.AppendLine("INNER JOIN (SELECT ActivoClave, MAX(Fecha) as Fecha FROM ActivoClienteHist GROUP BY ActivoClave) ACH1 ON ACH1.ActivoClave=ACT.ActivoClave ")
            sConsulta.AppendLine("INNER JOIN ActivoClienteHist ACH ON ACH.ActivoClave=ACH1.ActivoClave AND ACH.Fecha=ACH1.Fecha and ach.asignacion=2 ")
            sConsulta.AppendLine("INNER JOIN Vendedor VEN ON VEN.USUId=ACH.MUsuarioId ")
            sConsulta.AppendLine("INNER JOIN (SELECT VDH.VendedorId, VDH.AlmacenId, MAX(VDH.VCHFechaInicial) as FechaInicial FROM VENCentroDistHist VDH GROUP BY VDH.VendedorId, VDH.AlmacenId) VDH1 ON VDH1.VendedorId=VEN.VendedorId ")
            sConsulta.AppendLine("INNER JOIN VenRut VRT ON VRT.VendedorId=VEN.VendedorId AND VRT.TipoEstado=1 ")
            sConsulta.AppendLine("INNER JOIN Ruta RUT ON RUT.RUTClave=VRT.RUTClave ")
            sConsulta.AppendLine("INNER JOIN Cliente CLI ON CLI.ClienteClave=ACH.ClienteClave ")
            sConsulta.AppendLine("UNION ALL ")
            sConsulta.AppendLine("SELECT RUTClave='', RUTDescripcion='', ClienteClave='', RazonSocial='', ACT.ActivoClave, ACT.Nombre,  ")
            sConsulta.AppendLine("(SELECT Descripcion FROM VAVDescripcion VAD WHERE VAD.VAVClave = ACT.Tipo AND VAD.VARCodigo = 'ACITIPO' AND VAD.VADTipoLenguaje = 'EM') as Tipo, ")
            sConsulta.AppendLine("ACT.IdElectronico, ACT.Altura, ACT.Ancho, ACT.Profundidad, ")
            sConsulta.AppendLine("(SELECT Descripcion FROM VAVDescripcion VAD WHERE VAD.VAVClave = ACT.TipoFase AND VAD.VARCodigo = 'ACIFASE' AND VAD.VADTipoLenguaje = 'EM') as TipoFase, ")
            sConsulta.AppendLine("(SELECT Descripcion FROM VAVDescripcion VAD WHERE VAD.VAVClave = ACT.TipoEstado AND VAD.VARCodigo = 'EDOREG' AND VAD.VADTipoLenguaje = 'EM') as TipoEstado, ")
            sConsulta.AppendLine("Asignado=0 ")
            sConsulta.AppendLine("FROM Activo ACT ")
            sConsulta.AppendLine("INNER JOIN (SELECT ActivoClave, MAX(Fecha) as Fecha FROM ActivoClienteHist GROUP BY ActivoClave) ACH1 ON ACH1.ActivoClave=ACT.ActivoClave ")
            sConsulta.AppendLine("INNER JOIN ActivoClienteHist ACH ON ACH.ActivoClave=ACH1.ActivoClave AND ACH.Fecha=ACH1.Fecha  and ach.asignacion=1 ")
            sConsulta.AppendLine(") as Resultado ")
            sConsulta.AppendLine(pvCondicion)
            sConsulta.AppendLine("set nocount off ")

            Session("TipoReporte") = "PorFiltro"
        End If

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        Return True
    End Function

    Private Function ConsultaMercadeoBajoCero(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvClientes As ArrayList) As Boolean
        Dim sConsulta As New StringBuilder
        If chboxFecha.Checked Then
            pvCondicion = strWhereFecha(pvCondicion, "MER.MFechaHora")
        End If
        pvCondicion = strWhereCentrosDistribucion(pvCondicion, "ALN.Clave")
        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "RUT.RutClave")
        pvCondicion = strWhereClientes(pvCondicion, pvClientes, "CLI.ClienteClave")

        sConsulta.AppendLine("declare @pvLenguaje as varchar(3) ")
        sConsulta.AppendLine("set @pvLenguaje = '" + Session("lenguaje") + "' ")
        sConsulta.AppendLine("select ALN.Clave + ' - ' + ALN.Nombre as Almacen, VEN.Nombre as Vendedor, RUT.RutClave + ' - ' + RUT.Descripcion as Ruta, ")
        sConsulta.AppendLine("CLI.ClienteClave + ' - ' + CLI.RazonSocial as Cliente, MER.MFechaHora as Fecha, MPR.Producto, ")
        sConsulta.AppendLine("(case when MRD.Tipo = 0 then MRD.Tipo2 else (select Descripcion from VAVDescripcion where VARCodigo = 'MRDTipo' and VAVClave = MRD.Tipo AND VADTipoLenguaje = @pvLenguaje) end) as Tipo, ")
        sConsulta.AppendLine("(case when MRD.Presentacion = 0 then MRD.Presentacion2 else (select Descripcion from VAVDescripcion where VARCodigo = 'MRDPres' and VAVClave = MRD.Presentacion and VADTipoLenguaje = @pvLenguaje) end) as Presentacion, ")
        sConsulta.AppendLine("(case when MRD.Ubicacion = 0 then MRD.Ubicacion2 else (select Descripcion from VAVDescripcion where VARCodigo = 'MRDUbica' and VAVClave = MRD.Ubicacion and VADTipoLenguaje = @pvLenguaje) end) as Ubicacion, ")
        sConsulta.AppendLine("MEP.Proveedor, MRD.VentaAnterior, MRD.Cantidad, MRD.Precio, MRD.Cantidad * MRD.Precio as Total ")
        sConsulta.AppendLine("from MERDetalle MRD ")
        sConsulta.AppendLine("inner join Visita VIS on MRD.VisitaClave = VIS.VisitaClave and MRD.DiaClave = VIS.DiaClave ")
        sConsulta.AppendLine("inner join AgendaVendedor AGV on VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorId ")
        sConsulta.AppendLine("and VIS.RutClave = AGV.RutClave and VIS.ClienteClave = AGV.ClienteClave ")
        sConsulta.AppendLine("inner join Almacen ALN on AGV.ClaveCEDI = ALN.Clave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
        sConsulta.AppendLine("inner join Ruta RUT on VIS.RutClave = RUT.RutClave ")
        sConsulta.AppendLine("inner join MERCli MRC on MRD.MERId = MRC.MERId ")
        sConsulta.AppendLine("inner join Cliente CLI on MRC.ClienteClave = CLI.ClienteClave ")
        sConsulta.AppendLine("inner join Mercadeo MER on MRD.MERId = MER.MERId ")
        sConsulta.AppendLine("inner join MercadeoProducto MPR on MER.MPRId = MPR.MPRId ")
        sConsulta.AppendLine("inner join MercadeoProveedor MEP on MER.MEPId = MEP.MEPId ")
        sConsulta.AppendLine(pvCondicion)

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        Return True
    End Function

    Private Function ConsultaVentaSaldo(ByVal ins As DBConexion.cConexionSQL, ByVal pvDetallado As Boolean, ByVal pvClientes As ArrayList, ByVal pvCondicion As String, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder

        Dim sFecha As String()
        sFecha = txtFInicio.Text.Split("/")
        Dim dFechaIni As New Date(sFecha(2), sFecha(1), sFecha(0))
        pvCondicion &= " and convert(datetime,Convert(varchar(20), DIA.FechaCaptura ,112)) <= '" & dFechaIni.Date.ToString("s") & "' "
        pvCondicion = strWhereCentrosDistribucion(pvCondicion, "ALM.Clave")
        pvCondicion = strWhereClientes(pvCondicion, pvClientes, "Vis.clienteclave")

        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine(" SELECT ALM.Nombre AS CEDI, VEN.Nombre AS Vendedor, TRP.Notas AS Factura, TRP.Folio AS Venta, DIA.FechaCaptura AS Fecha, CLI.Clave AS Clave, CLI.RazonSocial AS Cliente, TRP.Total AS Importe, ")
        sConsulta.AppendLine(" ISNULL( (TRP.Total - (SELECT SUM(AbnTrp.Importe) FROM Abono INNER JOIN AbnTrp ON Abono.ABNId = AbnTrp.ABNId AND AbnTrp.TransProdID = TRP.TransProdID )),TRP.Total) AS Saldo ")
        sConsulta.AppendLine(" FROM TransProd TRP ")

        sConsulta.AppendLine(" INNER JOIN Dia DIA ON DIA.DiaClave = TRP.DiaClave ")
        sConsulta.AppendLine(" INNER JOIN Visita VIS ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave ")
        sConsulta.AppendLine(" INNER JOIN Cliente CLI ON CLI.ClienteClave = VIS.ClienteClave ")
        sConsulta.AppendLine(" INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorID ")
        sConsulta.AppendLine(" INNER JOIN VENCentroDistHist VEH ON  VEH.VendedorId = VEN.VendedorID AND DIA.FechaCaptura <= VEH.FechaFinal AND DIA.FechaCaptura >= VEH.VCHFechaInicial ")
        sConsulta.AppendLine(" INNER JOIN Almacen ALM ON ALM.AlmacenID = VEH.AlmacenId ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine(" AND TRP.Tipo = 1 AND TRP.TipoFase <> 0 and Saldo > 0")


        sConsulta.AppendLine(" set nocount off ")

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        Return True
    End Function

    Private Function ConsultaLiquidacionPoblana(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String) As Boolean
        'Movimientos
        Dim sConsulta As New StringBuilder
        Dim sCondicionMovs As String = ""
        Dim sCondicionPreliq As String = ""

        pvCondicion = strWhereCentrosDistribucion(pvCondicion, "ALM.Clave")
        sCondicionMovs = pvCondicion
        sCondicionPreliq = pvCondicion
        If chboxFecha.Checked Then
            Dim sFecha As String()
            sFecha = txtFInicio.Text.Split("/")
            Dim dFechaIni As New Date(sFecha(2), sFecha(1), sFecha(0))

            pvCondicion = strWhereFecha(pvCondicion, "TRP.FechaHoraAlta", True)
            sCondicionMovs &= " AND ((TRP.Tipo = 2 " & strWhereFecha("", "Dia.FechaCaptura", True) & ") OR (TRP.Tipo in( 1,3,7,9,24) " & strWhereFecha("", "TRP.FechaHoraAlta") & ") OR (TRP.TIPO=23 and Dia.FechaCaptura = (Select max(Dia2.FechaCaptura) as FechaCaptura from TransProd TRP2 inner join Dia Dia2 on TRP2.DiaClave = Dia2.Diaclave where " & " Dia2.FechaCaptura < '" & dFechaIni.Date.ToString("s") & "' " & " and TRP2.Tipo = 23 and TRP2.MUsuarioID =VEN.USUId))) "
            sCondicionPreliq = strWhereFecha(sCondicionPreliq, "ABN.FechaHora")
        End If


        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("SELECT ClaveCEDI, ALMNombre, VendedorId, VENNombre, ProductoClave, PRONombre, ")
        sConsulta.AppendLine("SUM(InvInicial) AS InvInicial, SUM(CambioEnt) AS CambioEnt, SUM(CambioSal) AS CambioSal, SUM(Consignacion) AS Consignacion, ")
        sConsulta.AppendLine("SUM(DevolucionCons) AS DevolucionCons, SUM(Promocion) AS Promocion, SUM(Descarga) AS Descarga, SUM(Venta) AS Venta, ")
        sConsulta.AppendLine("SUM((SubTotal- DescCliPor -((SubTotal-DescCliPor) * DescVendPor / 100) ) + (Impuesto-DescCliPorImp-((Impuesto-DescCliPorImp) * DescVendPor / 100))) AS Importe ")
        sConsulta.AppendLine("FROM( ")
        sConsulta.AppendLine("SELECT AGV.ClaveCEDI, ALM.Nombre as ALMNombre, VEN.VendedorId, VEN.Nombre as VENNombre, ")
        sConsulta.AppendLine("DIA.FechaCaptura AS FechaHoraAlta, TRP.Tipo, TPD.ProductoClave, PRO.Nombre AS PRONombre, ")
        sConsulta.AppendLine("InvInicial = (SELECT CASE WHEN TRP.Tipo = 2 OR TRP.Tipo = 23 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("CambioEnt = (SELECT CASE WHEN TRP.Tipo = 9 AND TRP.TipoMovimiento = 1 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("CambioSal = (SELECT CASE WHEN TRP.Tipo = 9 AND TRP.TipoMovimiento = 2 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Consignacion = (SELECT CASE WHEN TRP.Tipo = 24 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("DevolucionCons = (SELECT CASE WHEN TRP.Tipo = 3 AND TRP.TipoMovimiento = 1 AND TRP.TipoMotivo = 12 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Promocion = (SELECT CASE WHEN TRP.Tipo = 1 AND TPD.Promocion = 2 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Descarga =(SELECT CASE WHEN TRP.Tipo = 7 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Venta = (SELECT CASE WHEN TRP.Tipo = 1 AND TPD.Promocion <> 2 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("SubTotal = (SELECT CASE WHEN TRP.Tipo = 1  AND TPD.Total > 0 THEN TPD.Subtotal ELSE 0 END), ")
        sConsulta.AppendLine("DescCliPor = (SELECT CASE WHEN TRP.Tipo = 1  AND TPD.Total > 0 THEN (SELECT (CASE WHEN SUM(DesImporte) IS NULL THEN 0 ELSE SUM(DesImporte) END) FROM TpdDes AS TDD WHERE TDD.TransProdId = TRP.TransProdId AND TDD.TransProdDetalleId = TPD.TransProdDetalleId) ELSE 0 END), ")
        sConsulta.AppendLine("DescVendPor = (SELECT CASE WHEN TRP.Tipo = 1 AND TPD.Total > 0 THEN (SELECT CASE WHEN TRP.DescVendPor IS NULL THEN 0 ELSE TRP.DescVendPor END) ELSE 0 END), ")
        sConsulta.AppendLine("Impuesto = (SELECT CASE WHEN TRP.Tipo = 1  AND TPD.Total > 0 THEN (SELECT CASE WHEN TPD.Impuesto IS NULL THEN 0 ELSE TPD.Impuesto END) ELSE 0 END), ")
        sConsulta.AppendLine("DescCliPorImp=(SELECT CASE WHEN TRP.Tipo=1  AND TPD.Total>0 THEN (SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE sum(DesImpuesto) END) ")
        sConsulta.AppendLine("FROM TpdDes AS TDD WHERE TDD.TransProdId = TRP.TransProdId AND TDD.TransProdDetalleId = TPD.TransProdDetalleId) ELSE 0 END) ")
        sConsulta.AppendLine("FROM TransProd AS TRP ")
        sConsulta.AppendLine("INNER JOIN Dia ON TRP.DiaClave = DIA.DiaClave ")
        sConsulta.AppendLine("INNER JOIN TransProdDetalle AS TPD ON TPD.TransProdId = TRP.TransProdId ")
        sConsulta.AppendLine("INNER JOIN Producto AS PRO ON PRO.ProductoClave = TPD.ProductoClave ")
        sConsulta.AppendLine("INNER JOIN ProductoDetalle AS PDD ON PDD.ProductoClave = TPD.ProductoClave AND PDD.PRUTipoUnidad = TPD.TipoUnidad AND PDD.PRUTipoUnidad = TPD.TipoUnidad AND PDD.ProductoDetClave = TPD.ProductoClave ")
        sConsulta.AppendLine("INNER JOIN Vendedor AS VEN ON VEN.USUId = TRP.MUsuarioId AND VEN.TipoEstado = 1 AND VEN.Baja = 0 ")
        sConsulta.AppendLine("INNER JOIN (SELECT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor GROUP BY DiaClave, VendedorId, ClaveCEDI) as AGV ON AGV.DiaClave=TRP.DiaClave AND AGV.VendedorId=VEN.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Almacen as ALM ON ALM.Clave=AGV.ClaveCEDI ")
        sConsulta.AppendLine(sCondicionMovs & " ")
        sConsulta.AppendLine("AND TRP.Tipo IN (1,2,3,7,9,24,23) AND TRP.TipoFase <> 0 ")
        sConsulta.AppendLine(")AS Liquidacion ")
        sConsulta.AppendLine("GROUP BY ClaveCEDI, ALMNombre, VendedorId, VENNombre, ProductoClave, PRONombre ")
        sConsulta.AppendLine("ORDER BY ClaveCEDI, ALMNombre, VendedorId, VENNombre, ProductoClave ")
        Session("Movimientos") = sConsulta.ToString

        'Ventas CONTADO
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("SELECT AGV.ClaveCEDI, ALM.Nombre AS ALMNombre, VEN.VendedorId, VEN.Nombre AS VENNombre, ")
        sConsulta.AppendLine("TRP.Folio, TRP.FechaHoraAlta, convert(nvarchar(16), CLI.Clave) + ' ' + CLI.RazonSocial AS Cliente, TRP.Total,TRP.TipoFase ")
        sConsulta.AppendLine("FROM TransProd TRP ")
        sConsulta.AppendLine("INNER JOIN Cliente CLI ON TRP.ClienteClave = CLI.ClienteClave ")
        sConsulta.AppendLine("INNER JOIN Vendedor AS VEN ON VEN.USUId = TRP.MUsuarioId AND VEN.TipoEstado = 1 AND VEN.Baja = 0 ")
        sConsulta.AppendLine("INNER JOIN (SELECT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor GROUP BY DiaClave, VendedorId, ClaveCEDI) AS AGV ON AGV.DiaClave=TRP.DiaClave AND AGV.VendedorId=VEN.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Almacen as ALM ON ALM.Clave=AGV.ClaveCEDI ")
        sConsulta.AppendLine(pvCondicion & " ")
        sConsulta.AppendLine("AND TRP.Tipo = 1 AND  TRP.CFVTipo = 1 ")
        sConsulta.AppendLine("ORDER BY ClaveCEDI, ALMNombre, VEN.VendedorId, VENNombre, TRP.FechaHoraAlta ")
        Session("VentasContado") = sConsulta.ToString

        'Ventas CREDITO
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("SELECT AGV.ClaveCEDI, ALM.Nombre as ALMNombre, VEN.VendedorId, VEN.Nombre as VENNombre, ")
        sConsulta.AppendLine("TRP.Folio, TRP.FechaHoraAlta, convert(nvarchar(16), CLI.Clave) + ' ' + CLI.RazonSocial AS Cliente, TRP.Total,TRP.TipoFase ")
        sConsulta.AppendLine("FROM TransProd TRP ")
        sConsulta.AppendLine("INNER JOIN Cliente CLI ON TRP.ClienteClave = CLI.ClienteClave ")
        sConsulta.AppendLine("INNER JOIN Vendedor AS VEN ON VEN.USUId = TRP.MUsuarioId AND VEN.TipoEstado = 1 AND VEN.Baja = 0 ")
        sConsulta.AppendLine("INNER JOIN (SELECT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor GROUP BY DiaClave, VendedorId, ClaveCEDI) as AGV ON AGV.DiaClave=TRP.DiaClave AND AGV.VendedorId=VEN.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Almacen as ALM ON ALM.Clave=AGV.ClaveCEDI ")
        sConsulta.AppendLine(pvCondicion & " ")
        sConsulta.AppendLine("AND TRP.Tipo = 1  AND TRP.CFVTipo = 2 ")
        sConsulta.AppendLine("ORDER BY ClaveCEDI, ALMNombre, VEN.VendedorId, VENNombre, TRP.FechaHoraAlta ")
        Session("VentasCredito") = sConsulta.ToString

        'Ventas CONSIGNACION
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("SELECT AGV.ClaveCEDI, ALM.Nombre as ALMNombre, VEN.VendedorId, VEN.Nombre as VENNombre, ")
        sConsulta.AppendLine("TRP.Folio, TRP.FechaHoraAlta, convert(nvarchar(16), CLI.Clave) + ' ' + CLI.RazonSocial AS Cliente, TRP.Total ")
        sConsulta.AppendLine("FROM TransProd TRP ")
        sConsulta.AppendLine("INNER JOIN Cliente CLI ON TRP.ClienteClave = CLI.ClienteClave ")
        sConsulta.AppendLine("INNER JOIN Vendedor AS VEN ON VEN.USUId = TRP.MUsuarioId AND VEN.TipoEstado = 1 AND VEN.Baja = 0 ")
        sConsulta.AppendLine("INNER JOIN (SELECT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor GROUP BY DiaClave, VendedorId, ClaveCEDI) as AGV ON AGV.DiaClave=TRP.DiaClave AND AGV.VendedorId=VEN.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Almacen as ALM ON ALM.Clave=AGV.ClaveCEDI ")
        sConsulta.AppendLine(pvCondicion & " ")
        sConsulta.AppendLine("AND TRP.Tipo = 24 AND TRP.TipoFase <> 0 ")
        sConsulta.AppendLine("ORDER BY ClaveCEDI, ALMNombre, VEN.VendedorId, VENNombre, TRP.FechaHoraAlta ")
        Session("VentasConsignacion") = sConsulta.ToString

        'Denominacion
        sConsulta = New StringBuilder
        sConsulta.AppendLine("select Grupo, case when Grupo = '1' then ")
        sConsulta.AppendLine("(select Descripcion from MENDetalle where MENClave = 'XBillete' and MEDTipoLenguaje = '" & Session("lenguaje") & "') else ")
        sConsulta.AppendLine("(select Descripcion from MENDetalle where MENClave = 'XMonedas' and MEDTipoLenguaje = '" & Session("lenguaje") & "') ")
        sConsulta.AppendLine("end as NombreGrupo, VAD.Descripcion ")
        sConsulta.AppendLine("from VARValor VAV ")
        sConsulta.AppendLine("inner join VAVDescripcion VAD on VAV.VARCodigo = VAD.VARCodigo and VAV.VAVClave = VAD.VAVClave ")
        sConsulta.AppendLine("where VAV.VARCodigo = 'DENOMINA' and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' ")
        sConsulta.AppendLine("order by Grupo desc, convert(float, VAD.Descripcion) ")
        Session("Desglose") = sConsulta.ToString

        'Vendedores
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("SET NOCOUNT ON ")
        sConsulta.AppendLine("if (select object_id('tempdb..#tmpPreliq')) is not null drop table #tmpPreliq ")
        sConsulta.AppendLine("select * into #tmpPreliq from ( ")
        sConsulta.AppendLine("SELECT AGV.ClaveCEDI, ALM.Nombre as ALMNombre, VEN.VendedorId, VEN.Nombre as VENNombre, SUM(ABN.Importe) as Abonos ")
        sConsulta.AppendLine("FROM AbnTrp ABN ")
        sConsulta.AppendLine("INNER JOIN TransProd TRP ON ABN.TransProdId = TRP.TransProdId ")
        sConsulta.AppendLine("INNER JOIN Vendedor AS VEN ON VEN.USUId = TRP.MUsuarioId AND VEN.TipoEstado = 1 AND VEN.Baja = 0 ")
        sConsulta.AppendLine("INNER JOIN (SELECT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor GROUP BY DiaClave, VendedorId, ClaveCEDI) as AGV ON AGV.DiaClave=TRP.DiaClave AND AGV.VendedorId=VEN.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Almacen as ALM ON ALM.Clave=AGV.ClaveCEDI ")
        sConsulta.AppendLine(sCondicionPreliq & " ")
        sConsulta.AppendLine("AND TRP.TipoFase <> 0 AND ((TRP.Tipo = 1 AND TRP.CFVTipo = 2) OR TRP.Tipo = 24) ")
        sConsulta.AppendLine("GROUP BY AGV.ClaveCEDI, ALM.Nombre, VEN.VendedorId, VEN.Nombre ")
        sConsulta.AppendLine(")as t1 ")
        sConsulta.AppendLine("if (select object_id('tempdb..#tmpVend')) is not null drop table #tmpVend ")
        sConsulta.AppendLine("select * into #tmpVend from ( ")
        sConsulta.AppendLine("SELECT DISTINCT AGV.ClaveCEDI, ALM.Nombre as ALMNombre, VEN.VendedorId, VEN.Nombre as VENNombre ")
        sConsulta.AppendLine("FROM TransProd TRP ")
        sConsulta.AppendLine("INNER JOIN Vendedor AS VEN ON VEN.USUId = TRP.MUsuarioId AND VEN.TipoEstado = 1 AND VEN.Baja = 0 ")
        sConsulta.AppendLine("INNER JOIN (SELECT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor GROUP BY DiaClave, VendedorId, ClaveCEDI) as AGV ON AGV.DiaClave=TRP.DiaClave AND AGV.VendedorId=VEN.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Almacen as ALM ON ALM.Clave=AGV.ClaveCEDI ")
        sConsulta.AppendLine(pvCondicion & " ")
        sConsulta.AppendLine("AND TRP.Tipo IN (1,2,3,7,9,24) AND TRP.TipoFase <> 0 ")
        sConsulta.AppendLine("UNION ")
        sConsulta.AppendLine("SELECT DISTINCT AGV.ClaveCEDI, ALM.Nombre as ALMNombre, VEN.VendedorId, VEN.Nombre as VENNombre ")
        sConsulta.AppendLine("FROM AbnTrp ABN ")
        sConsulta.AppendLine("INNER JOIN TransProd TRP ON ABN.TransProdId = TRP.TransProdId ")
        sConsulta.AppendLine("INNER JOIN Vendedor AS VEN ON VEN.USUId = TRP.MUsuarioId AND VEN.TipoEstado = 1 AND VEN.Baja = 0 ")
        sConsulta.AppendLine("INNER JOIN (SELECT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor GROUP BY DiaClave, VendedorId, ClaveCEDI) as AGV ON AGV.DiaClave=TRP.DiaClave AND AGV.VendedorId=VEN.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Almacen as ALM ON ALM.Clave=AGV.ClaveCEDI ")
        sConsulta.AppendLine(pvCondicion & " ")
        sConsulta.AppendLine("AND TRP.TipoFase <> 0 AND ((TRP.Tipo = 1 AND TRP.CFVTipo = 2) OR TRP.Tipo = 24) ")
        sConsulta.AppendLine(")as t1 ")
        sConsulta.AppendLine("select VEN.ClaveCEDI, VEN.ALMNombre, VEN.VendedorId, VEN.VENNombre, isnull(PRE.Abonos, 0) as Cobranza ")
        sConsulta.AppendLine("from #tmpVend VEN ")
        sConsulta.AppendLine("left join #tmpPreliq PRE on VEN.ClaveCEDI = PRE.ClaveCEDI and VEN.VendedorId = PRE.VendedorId ")
        sConsulta.AppendLine("order by VEN.ClaveCEDI, VEN.VendedorId ")
        sConsulta.AppendLine("drop table #tmpPreliq ")
        sConsulta.AppendLine("drop table #tmpVend ")
        sConsulta.AppendLine("SET NOCOUNT OFF ")

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If (dt.Rows.Count > 0) Then
            Session("Vendedores") = dt
            Return True
        Else
            Return False
        End If
    End Function

    Private Function ConsultaCuotasVentaDISPOSUR(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        Dim sFecha() As String
        Dim dFechaIni As Date

        If pvFecha Then
            sFecha = txtFInicio.Text.Split("/")
            dFechaIni = New Date(sFecha(2), sFecha(1), sFecha(0))

            pvCondicion &= " and " & DBConexion.cConexionSQL.UniFechaSQL(dFechaIni.Date) & " between CUO.FechaInicio and CUO.FechaFin "
        Else
            dFechaIni = ins.ObtenerFecha
        End If
        pvCondicion = strWhereCentrosDistribucion(pvCondicion, "ALM.Clave")

        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("Declare @FechaFinal datetime ")
        sConsulta.AppendLine("SET @FechaFinal=" & DBConexion.cConexionSQL.UniFechaSQL(dFechaIni.Date))
        sConsulta.AppendLine("SELECT ALM.Clave as ALMClave, ALM.Clave + ' ' + ALM.Nombre as Almacen, VEN.VendedorId, ")
        sConsulta.AppendLine("USU.Clave + ' ' + VEN.Nombre as Vendedor, CUO.CUOClave, CUO.CUOClave + ' ' + CUO.Descripcion as Cuota, ")
        sConsulta.AppendLine("(convert(varchar(20),CUO.FechaInicio,103) + ' ' + (SELECT Descripcion FROM MENDetalle WHERE MENClave='XA' AND MEDTipoLenguaje='" & Session("lenguaje") & "') + ' ' + convert(varchar(20),CUO.FechaFin,103)) as Periodo, ")
        sConsulta.AppendLine("(DATEDIFF(dd,CUO.FechaInicio,CUO.FechaFin)) as DiasPeriodo, ")
        sConsulta.AppendLine("(SELECT CASE WHEN CUO.FechaFin < @FechaFinal THEN DATEDIFF(dd,CUO.FechaInicio,CUO.FechaFin) ELSE DATEDIFF(dd,CUO.FechaInicio,@FechaFinal) END) as DiasTranscurridos, ")
        sConsulta.AppendLine("(SELECT CASE WHEN CUO.FechaFin > @FechaFinal THEN DATEDIFF(dd,@FechaFinal,CUO.FechaFin) ELSE 0 END) as DiasFaltantes, ")
        sConsulta.AppendLine("(SELECT isnull(AVG(Porcentaje),0) FROM (SELECT (SELECT CASE WHEN (CUC.Cantidad/CUE.Minimo*100) > 100 THEN 100 ELSE (CUC.Cantidad/CUE.Minimo*100) END) AS Porcentaje FROM CUOEsquema CUE INNER JOIN CUECCU CUC ON CUC.CUOClave=CUO.CUOClave AND CUC.EsquemaId=CUE.EsquemaId AND CUC.VendedorId=VEN.VendedorId WHERE CUE.CUOClave=CUO.CUOClave AND CUE.Estado=1 AND CUE.Tipo=1) AS Resultado) as EsquemaProductoAvance, ")
        sConsulta.AppendLine("(SELECT isnull(AVG(Porcentaje),0) FROM (SELECT (SELECT CASE WHEN (CUC.Cantidad/CUE.Minimo*100) > 100 THEN 100 ELSE (CUC.Cantidad/CUE.Minimo*100) END) AS Porcentaje FROM CUOEsquema CUE INNER JOIN CUECCU CUC ON CUC.CUOClave=CUO.CUOClave AND CUC.EsquemaId=CUE.EsquemaId AND CUC.VendedorId=VEN.VendedorId WHERE CUE.CUOClave=CUO.CUOClave AND CUE.Estado=1 AND CUE.Tipo=2) AS Resultado) as EsquemaEfectivoAvance, ")
        sConsulta.AppendLine("(SELECT isnull(AVG(Porcentaje),0) FROM (SELECT (SELECT CASE WHEN (CUC.Cantidad/CUP.Minimo*100) > 100 THEN 100 ELSE (CUC.Cantidad/CUP.Minimo*100) END) AS Porcentaje FROM CUOProducto CUP INNER JOIN CUPCCU CUC ON CUC.CUOClave=CUO.CUOClave AND CUC.ProductoClave=CUP.ProductoClave AND CUC.VendedorId=VEN.VendedorId WHERE CUP.CUOClave=CUO.CUOClave AND CUP.Estado=1 AND CUP.Tipo=1) AS Resultado) AS ProductoProductoAvance, ")
        sConsulta.AppendLine("(SELECT isnull(AVG(Porcentaje),0) FROM (SELECT (SELECT CASE WHEN (CUC.Cantidad/CUP.Minimo*100) > 100 THEN 100 ELSE (CUC.Cantidad/CUP.Minimo*100) END) AS Porcentaje FROM CUOProducto CUP INNER JOIN CUPCCU CUC ON CUC.CUOClave=CUO.CUOClave AND CUC.ProductoClave=CUP.ProductoClave AND CUC.VendedorId=VEN.VendedorId WHERE CUP.CUOClave=CUO.CUOClave AND CUP.Estado=1 AND CUP.Tipo=2) AS Resultado) AS ProductoEfectivoAvance, ")
        sConsulta.AppendLine("(SELECT isnull(AVG(Porcentaje),0) FROM (SELECT (SELECT CASE WHEN (CUC.Cantidad/CUL.Minimo*100) > 100 THEN 100 ELSE (CUC.Cantidad/CUL.Minimo*100) END) AS Porcentaje FROM CUOCliente CUL INNER JOIN CUCCCU CUC ON CUC.CUOClave=CUO.CUOClave AND CUC.ClienteClave=CUL.ClienteClave AND CUC.VendedorId=VEN.VendedorId WHERE CUL.CUOClave=CUO.CUOClave AND CUL.Estado=1 AND CUL.Tipo=1) AS Resultado) AS ClienteProductoAvance, ")
        sConsulta.AppendLine("(SELECT isnull(AVG(Porcentaje),0) FROM (SELECT (SELECT CASE WHEN (CUC.Cantidad/CUL.Minimo*100) > 100 THEN 100 ELSE (CUC.Cantidad/CUL.Minimo*100) END) AS Porcentaje FROM CUOCliente CUL INNER JOIN CUCCCU CUC ON CUC.CUOClave=CUO.CUOClave AND CUC.ClienteClave=CUL.ClienteClave AND CUC.VendedorId=VEN.VendedorId WHERE CUL.CUOClave=CUO.CUOClave AND CUL.Estado=1 AND CUL.Tipo=2) AS Resultado) AS ClienteEfectivoAvance, ")
        sConsulta.AppendLine("(SELECT isnull(AVG(Porcentaje),0) FROM (SELECT (SELECT CASE WHEN (CUC.Cantidad/CUV.Minimo*100) > 100 THEN 100 ELSE (CUC.Cantidad/CUV.Minimo*100) END) AS Porcentaje FROM CUOVEN CUV INNER JOIN CuotaCumplida CUC ON CUC.CUOClave=CUO.CUOClave AND CUC.VendedorId=VEN.VendedorId WHERE CUV.CUOClave=CUV.CUOClave AND CUV.Estado=1 AND CUV.Tipo=1) AS Resultado) AS VendedorProductoAvance, ")
        sConsulta.AppendLine("(SELECT isnull(AVG(Porcentaje),0) FROM (SELECT (SELECT CASE WHEN (CUC.Cantidad/CUV.Minimo*100) > 100 THEN 100 ELSE (CUC.Cantidad/CUV.Minimo*100) END) AS Porcentaje FROM CUOVEN CUV INNER JOIN CuotaCumplida CUC ON CUC.CUOClave=CUO.CUOClave AND CUC.VendedorId=VEN.VendedorId WHERE CUV.CUOClave=CUV.CUOClave AND CUV.Estado=1 AND CUV.Tipo=2) AS Resultado) AS VendedorEfectivoAvance ")
        sConsulta.AppendLine("FROM Cuota CUO ")
        sConsulta.AppendLine("INNER JOIN CUOVEN CUV ON CUV.CUOClave=CUV.CUOClave AND CUV.Estado=1 ")
        sConsulta.AppendLine("INNER JOIN Vendedor VEN ON VEN.VendedorId=CUV.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Usuario USU ON USU.USUId=VEN.USUId ")
        sConsulta.AppendLine("INNER JOIN (SELECT AGV.VendedorId, AGV.ClaveCEDI FROM AgendaVendedor AGV GROUP BY AGV.VendedorId, AGV.ClaveCEDI) as AGV on CUV.VendedorId = AGV.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Almacen ALM ON ALM.Clave=AGV.ClaveCEDI ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine(" AND CUO.Estado=1 AND CUO.Baja=0 ")
        sConsulta.AppendLine(" set nocount off ")

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        '------------ ESQUEMAS --------------
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("SELECT ALM.Clave as ALMClave, VEN.VendedorId, CUO.CUOClave, (SELECT Descripcion FROM MENDetalle WHERE MENClave='XEsquema' AND MEDTipoLenguaje='" & Session("lenguaje") & "') as Tipo, ")
        sConsulta.AppendLine("(ESQ.Clave + ' ' + ESQ.Nombre) as Descripcion, CUE.Minimo as ProductoMinimo, EfectivoMinimo=0, CUC.Cantidad as ProductoAvance, ")
        sConsulta.AppendLine("EfectivoAvance=0, (SELECT CASE WHEN (CUC.Cantidad/CUE.Minimo*100) > 100 THEN 100 ELSE (CUC.Cantidad/CUE.Minimo*100)END) as Porcentaje, ")
        sConsulta.AppendLine("(SELECT CASE WHEN (CUE.Minimo-CUC.Cantidad) < 0 THEN 0 ELSE (CUE.Minimo-CUC.Cantidad)END) as ProductoFaltante, EfectivoFaltante =0, ")
        sConsulta.AppendLine("(SELECT CASE WHEN ((CUE.Minimo-CUC.Cantidad)/CUE.Minimo*100) < 0 THEN 0 ELSE ((CUE.Minimo-CUC.Cantidad)/CUE.Minimo*100)END) as PorcentajeFaltante ")
        sConsulta.AppendLine("FROM Cuota CUO ")
        sConsulta.AppendLine("INNER JOIN CUOVEN CUV ON CUV.CUOClave=CUV.CUOClave AND CUV.Estado=1 ")
        sConsulta.AppendLine("INNER JOIN Vendedor VEN ON VEN.VendedorId=CUV.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Usuario USU ON USU.USUId=VEN.USUId ")
        sConsulta.AppendLine("INNER JOIN (SELECT AGV.VendedorId, AGV.ClaveCEDI FROM AgendaVendedor AGV GROUP BY AGV.VendedorId, AGV.ClaveCEDI) as AGV on CUV.VendedorId = AGV.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Almacen ALM ON ALM.Clave=AGV.ClaveCEDI ")
        sConsulta.AppendLine("INNER JOIN CUOEsquema CUE ON CUE.CUOClave=CUO.CUOClave AND CUE.Estado=1 AND CUE.Tipo=1 ")
        sConsulta.AppendLine("INNER JOIN Esquema ESQ ON ESQ.EsquemaId=CUE.EsquemaId ")
        sConsulta.AppendLine("INNER JOIN CUECCU CUC ON CUC.CUOClave=CUO.CUOClave AND CUC.EsquemaId=ESQ.EsquemaId AND CUC.VendedorId=VEN.VendedorId ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine(" AND CUO.Estado=1 AND CUO.Baja=0 ")

        sConsulta.AppendLine("UNION ALL ")

        sConsulta.AppendLine("SELECT ALM.Clave as ALMClave, VEN.VendedorId, CUO.CUOClave, (SELECT Descripcion FROM MENDetalle WHERE MENClave='XEsquema' AND MEDTipoLenguaje='" & Session("lenguaje") & "') as Tipo, ")
        sConsulta.AppendLine("(ESQ.Clave + ' ' + ESQ.Nombre) as Descripcion, ProductoMinimo=0, CUE.Minimo as EfectivoMinimo, ProductoAvance=0, ")
        sConsulta.AppendLine("CUC.Cantidad as EfectivoAvance, (SELECT CASE WHEN (CUC.Cantidad/CUE.Minimo*100) > 100 THEN 100 ELSE (CUC.Cantidad/CUE.Minimo*100) END) as Porcentaje, ")
        sConsulta.AppendLine("ProductoFaltante=0, (SELECT CASE WHEN (CUE.Minimo-CUC.Cantidad) < 0 THEN 0 ELSE (CUE.Minimo-CUC.Cantidad) END) as EfectivoFaltante, ")
        sConsulta.AppendLine("(SELECT CASE WHEN ((CUE.Minimo-CUC.Cantidad)/CUE.Minimo*100) < 0 THEN 0 ELSE ((CUE.Minimo-CUC.Cantidad)/CUE.Minimo*100) END) as PorcentajeFaltante ")
        sConsulta.AppendLine("FROM Cuota CUO ")
        sConsulta.AppendLine("INNER JOIN CUOVEN CUV ON CUV.CUOClave=CUV.CUOClave AND CUV.Estado=1 ")
        sConsulta.AppendLine("INNER JOIN Vendedor VEN ON VEN.VendedorId=CUV.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Usuario USU ON USU.USUId=VEN.USUId ")
        sConsulta.AppendLine("INNER JOIN (SELECT AGV.VendedorId, AGV.ClaveCEDI FROM AgendaVendedor AGV GROUP BY AGV.VendedorId, AGV.ClaveCEDI) as AGV on CUV.VendedorId = AGV.VendedorId  ")
        sConsulta.AppendLine("INNER JOIN Almacen ALM ON ALM.Clave=AGV.ClaveCEDI ")
        sConsulta.AppendLine("INNER JOIN CUOEsquema CUE ON CUE.CUOClave=CUO.CUOClave AND CUE.Estado=1 AND CUE.Tipo=2 ")
        sConsulta.AppendLine("INNER JOIN Esquema ESQ ON ESQ.EsquemaId=CUE.EsquemaId ")
        sConsulta.AppendLine("INNER JOIN CUECCU CUC ON CUC.CUOClave=CUO.CUOClave AND CUC.EsquemaId=ESQ.EsquemaId AND CUC.VendedorId=VEN.VendedorId ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine(" AND CUO.Estado=1 AND CUO.Baja=0 ")
        sConsulta.AppendLine(" set nocount off ")
        Session("Query1") = sConsulta.ToString

        '------------ PRODUCTOS --------------
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("SELECT ALM.Clave as ALMClave, VEN.VendedorId, CUO.CUOClave, (SELECT Descripcion FROM MENDetalle WHERE MENClave='XProductos' AND MEDTipoLenguaje='" & Session("lenguaje") & "') as Tipo, ")
        sConsulta.AppendLine("(PRO.ProductoClave + ' ' + PRO.Nombre) as Descripcion, CUP.Minimo as ProductoMinimo, EfectivoMinimo=0, CUC.Cantidad as ProductoAvance, ")
        sConsulta.AppendLine("EfectivoAvance=0, (SELECT CASE WHEN (CUC.Cantidad/CUP.Minimo*100) > 100 THEN 100 ELSE (CUC.Cantidad/CUP.Minimo*100) END) as Porcentaje, ")
        sConsulta.AppendLine("(SELECT CASE WHEN (CUP.Minimo-CUC.Cantidad) < 0 THEN 0 ELSE (CUP.Minimo-CUC.Cantidad) END) as ProductoFaltante, EfectivoFaltante =0, ")
        sConsulta.AppendLine("(SELECT CASE WHEN ((CUP.Minimo-CUC.Cantidad)/CUP.Minimo*100) < 0 THEN 0 ELSE ((CUP.Minimo-CUC.Cantidad)/CUP.Minimo*100) END) as PorcentajeFaltante ")
        sConsulta.AppendLine("FROM Cuota CUO ")
        sConsulta.AppendLine("INNER JOIN CUOVEN CUV ON CUV.CUOClave=CUV.CUOClave AND CUV.Estado=1 ")
        sConsulta.AppendLine("INNER JOIN Vendedor VEN ON VEN.VendedorId=CUV.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Usuario USU ON USU.USUId=VEN.USUId ")
        sConsulta.AppendLine("INNER JOIN (SELECT AGV.VendedorId, AGV.ClaveCEDI FROM AgendaVendedor AGV GROUP BY AGV.VendedorId, AGV.ClaveCEDI) as AGV on CUV.VendedorId = AGV.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Almacen ALM ON ALM.Clave=AGV.ClaveCEDI ")
        sConsulta.AppendLine("INNER JOIN CUOProducto CUP ON CUP.CUOClave=CUO.CUOClave AND CUP.Estado=1 AND CUP.Tipo=1 ")
        sConsulta.AppendLine("INNER JOIN Producto PRO ON PRO.ProductoClave=CUP.ProductoClave ")
        sConsulta.AppendLine("INNER JOIN CUPCCU CUC ON CUC.CUOClave=CUO.CUOClave AND CUC.ProductoClave=PRO.ProductoClave AND CUC.VendedorId=VEN.VendedorId ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine(" AND CUO.Estado=1 AND CUO.Baja=0 ")

        sConsulta.AppendLine("UNION ALL ")

        sConsulta.AppendLine("SELECT ALM.Clave as ALMClave, VEN.VendedorId, CUO.CUOClave, (SELECT Descripcion FROM MENDetalle WHERE MENClave='XProductos' AND MEDTipoLenguaje='" & Session("lenguaje") & "') as Tipo, ")
        sConsulta.AppendLine("(PRO.ProductoClave + ' ' + PRO.Nombre) as Descripcion, ProductoMinimo=0, CUP.Minimo as EfectivoMinimo, ProductoAvance=0, ")
        sConsulta.AppendLine("CUC.Cantidad as EfectivoAvance, (SELECT CASE WHEN (CUC.Cantidad/CUP.Minimo*100) > 100 THEN 100 ELSE (CUC.Cantidad/CUP.Minimo*100) END) as Porcentaje, ")
        sConsulta.AppendLine("ProductoFaltante=0, (SELECT CASE WHEN (CUP.Minimo-CUC.Cantidad) < 0 THEN 0 ELSE (CUP.Minimo-CUC.Cantidad) END) as EfectivoFaltante, ")
        sConsulta.AppendLine("(SELECT CASE WHEN ((CUP.Minimo-CUC.Cantidad)/CUP.Minimo*100) < 0 THEN 0 ELSE ((CUP.Minimo-CUC.Cantidad)/CUP.Minimo*100) END) as PorcentajeFaltante ")
        sConsulta.AppendLine("FROM Cuota CUO ")
        sConsulta.AppendLine("INNER JOIN CUOVEN CUV ON CUV.CUOClave=CUV.CUOClave AND CUV.Estado=1 ")
        sConsulta.AppendLine("INNER JOIN Vendedor VEN ON VEN.VendedorId=CUV.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Usuario USU ON USU.USUId=VEN.USUId ")
        sConsulta.AppendLine("INNER JOIN (SELECT AGV.VendedorId, AGV.ClaveCEDI FROM AgendaVendedor AGV GROUP BY AGV.VendedorId, AGV.ClaveCEDI) as AGV on CUV.VendedorId = AGV.VendedorId  ")
        sConsulta.AppendLine("INNER JOIN Almacen ALM ON ALM.Clave=AGV.ClaveCEDI ")
        sConsulta.AppendLine("INNER JOIN CUOProducto CUP ON CUP.CUOClave=CUO.CUOClave AND CUP.Estado=1 AND CUP.Tipo=2 ")
        sConsulta.AppendLine("INNER JOIN Producto PRO ON PRO.ProductoClave=CUP.ProductoClave ")
        sConsulta.AppendLine("INNER JOIN CUPCCU CUC ON CUC.CUOClave=CUO.CUOClave AND CUC.ProductoClave=PRO.ProductoClave AND CUC.VendedorId=VEN.VendedorId ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine(" AND CUO.Estado=1 AND CUO.Baja=0 ")
        sConsulta.AppendLine(" set nocount off ")
        Session("Query2") = sConsulta.ToString

        '------------ CLIENTES --------------
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("SELECT ALM.Clave as ALMClave, VEN.VendedorId, CUO.CUOClave, (SELECT Descripcion FROM MENDetalle WHERE MENClave='XAClientes' AND MEDTipoLenguaje='" & Session("lenguaje") & "') as Tipo, ")
        sConsulta.AppendLine("(CLI.Clave + ' ' + CLI.NombreCorto) as Descripcion, CUL.Minimo as ProductoMinimo, EfectivoMinimo=0, CUC.Cantidad as ProductoAvance, ")
        sConsulta.AppendLine("EfectivoAvance=0, (SELECT CASE WHEN (CUC.Cantidad/CUL.Minimo*100) > 100 THEN 100 ELSE (CUC.Cantidad/CUL.Minimo*100) END) as Porcentaje, ")
        sConsulta.AppendLine("(SELECT CASE WHEN (CUL.Minimo-CUC.Cantidad) < 0 THEN 0 ELSE (CUL.Minimo-CUC.Cantidad) END) as ProductoFaltante, EfectivoFaltante =0, ")
        sConsulta.AppendLine("(SELECT CASE WHEN ((CUL.Minimo-CUC.Cantidad)/CUL.Minimo*100) < 0 THEN 0 ELSE ((CUL.Minimo-CUC.Cantidad)/CUL.Minimo*100) END) as PorcentajeFaltante ")
        sConsulta.AppendLine("FROM Cuota CUO ")
        sConsulta.AppendLine("INNER JOIN CUOVEN CUV ON CUV.CUOClave=CUV.CUOClave AND CUV.Estado=1 ")
        sConsulta.AppendLine("INNER JOIN Vendedor VEN ON VEN.VendedorId=CUV.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Usuario USU ON USU.USUId=VEN.USUId ")
        sConsulta.AppendLine("INNER JOIN (SELECT AGV.VendedorId, AGV.ClaveCEDI FROM AgendaVendedor AGV GROUP BY AGV.VendedorId, AGV.ClaveCEDI) as AGV on CUV.VendedorId = AGV.VendedorId  ")
        sConsulta.AppendLine("INNER JOIN Almacen ALM ON ALM.Clave=AGV.ClaveCEDI ")
        sConsulta.AppendLine("INNER JOIN CUOCliente CUL ON CUL.CUOClave=CUO.CUOClave AND CUL.Estado=1 AND CUL.Tipo=1 ")
        sConsulta.AppendLine("INNER JOIN Cliente CLI ON CLI.ClienteClave=CUL.ClienteClave ")
        sConsulta.AppendLine("INNER JOIN CUCCCU CUC ON CUC.CUOClave=CUO.CUOClave AND CUC.ClienteClave=CLI.ClienteClave AND CUC.VendedorId=VEN.VendedorId ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine(" AND CUO.Estado=1 AND CUO.Baja=0 ")

        sConsulta.AppendLine("UNION ALL ")

        sConsulta.AppendLine("SELECT ALM.Clave as ALMClave, VEN.VendedorId, CUO.CUOClave, (SELECT Descripcion FROM MENDetalle WHERE MENClave='XAClientes' AND MEDTipoLenguaje='" & Session("lenguaje") & "') as Tipo, ")
        sConsulta.AppendLine("(CLI.Clave + ' ' + CLI.NombreCorto) as Descripcion, ProductoMinimo=0, CUL.Minimo as EfectivoMinimo, ProductoAvance=0, ")
        sConsulta.AppendLine("CUC.Cantidad as EfectivoAvance, (SELECT CASE WHEN (CUC.Cantidad/CUL.Minimo*100) > 100 THEN 100 ELSE (CUC.Cantidad/CUL.Minimo*100) END) as Porcentaje, ")
        sConsulta.AppendLine("ProductoFaltante=0, (SELECT CASE WHEN (CUL.Minimo-CUC.Cantidad) < 0 THEN 0 ELSE (CUL.Minimo-CUC.Cantidad) END) as EfectivoFaltante, ")
        sConsulta.AppendLine("(SELECT CASE WHEN ((CUL.Minimo-CUC.Cantidad)/CUL.Minimo*100) < 0 THEN 0 ELSE ((CUL.Minimo-CUC.Cantidad)/CUL.Minimo*100) END) as PorcentajeFaltante ")
        sConsulta.AppendLine("FROM Cuota CUO ")
        sConsulta.AppendLine("INNER JOIN CUOVEN CUV ON CUV.CUOClave=CUV.CUOClave AND CUV.Estado=1 ")
        sConsulta.AppendLine("INNER JOIN Vendedor VEN ON VEN.VendedorId=CUV.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Usuario USU ON USU.USUId=VEN.USUId ")
        sConsulta.AppendLine("INNER JOIN (SELECT AGV.VendedorId, AGV.ClaveCEDI FROM AgendaVendedor AGV GROUP BY AGV.VendedorId, AGV.ClaveCEDI) as AGV on CUV.VendedorId = AGV.VendedorId  ")
        sConsulta.AppendLine("INNER JOIN Almacen ALM ON ALM.Clave=AGV.ClaveCEDI ")
        sConsulta.AppendLine("INNER JOIN CUOCliente CUL ON CUL.CUOClave=CUO.CUOClave AND CUL.Estado=1 AND CUL.Tipo=2 ")
        sConsulta.AppendLine("INNER JOIN Cliente CLI ON CLI.ClienteClave=CUL.ClienteClave ")
        sConsulta.AppendLine("INNER JOIN CUCCCU CUC ON CUC.CUOClave=CUO.CUOClave AND CUC.ClienteClave=CLI.ClienteClave AND CUC.VendedorId=VEN.VendedorId ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine(" AND CUO.Estado=1 AND CUO.Baja=0 ")
        sConsulta.AppendLine(" set nocount off ")
        Session("Query3") = sConsulta.ToString

        '------------ VENDEDOR --------------
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("SELECT ALM.Clave as ALMClave, VEN.VendedorId, CUO.CUOClave, (SELECT Descripcion FROM MENDetalle WHERE MENClave='XVendedores' AND MEDTipoLenguaje='" & Session("lenguaje") & "') as Tipo, ")
        sConsulta.AppendLine("(USU.Clave + ' ' + VEN.Nombre) as Descripcion, CUV.Minimo as ProductoMinimo, EfectivoMinimo=0, CUC.Cantidad as ProductoAvance, ")
        sConsulta.AppendLine("EfectivoAvance=0, (SELECT CASE WHEN (CUC.Cantidad/CUV.Minimo*100) > 100 THEN 100 ELSE (CUC.Cantidad/CUV.Minimo*100) END) as Porcentaje, ")
        sConsulta.AppendLine("(SELECT CASE WHEN (CUV.Minimo-CUC.Cantidad) < 0 THEN 0 ELSE (CUV.Minimo-CUC.Cantidad) END) as ProductoFaltante, EfectivoFaltante =0, ")
        sConsulta.AppendLine("(SELECT CASE WHEN ((CUV.Minimo-CUC.Cantidad)/CUV.Minimo*100) < 0 THEN 0 ELSE ((CUV.Minimo-CUC.Cantidad)/CUV.Minimo*100) END) as PorcentajeFaltante ")
        sConsulta.AppendLine("FROM Cuota CUO ")
        sConsulta.AppendLine("INNER JOIN CUOVEN CUV ON CUV.CUOClave=CUV.CUOClave AND CUV.Estado=1 AND CUV.Tipo=1 ")
        sConsulta.AppendLine("INNER JOIN Vendedor VEN ON VEN.VendedorId=CUV.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Usuario USU ON USU.USUId=VEN.USUId ")
        sConsulta.AppendLine("INNER JOIN (SELECT AGV.VendedorId, AGV.ClaveCEDI FROM AgendaVendedor AGV GROUP BY AGV.VendedorId, AGV.ClaveCEDI) as AGV on CUV.VendedorId = AGV.VendedorId  ")
        sConsulta.AppendLine("INNER JOIN Almacen ALM ON ALM.Clave=AGV.ClaveCEDI ")
        sConsulta.AppendLine("INNER JOIN CuotaCumplida CUC ON CUC.CUOClave=CUO.CUOClave AND CUC.VendedorId=VEN.VendedorId ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine(" AND CUO.Estado=1 AND CUO.Baja=0 ")

        sConsulta.AppendLine("UNION ALL ")

        sConsulta.AppendLine("SELECT ALM.Clave as ALMClave, VEN.VendedorId, CUO.CUOClave, (SELECT Descripcion FROM MENDetalle WHERE MENClave='XVendedores' AND MEDTipoLenguaje='" & Session("lenguaje") & "') as Tipo, ")
        sConsulta.AppendLine("(USU.Clave + ' ' + VEN.Nombre) as Descripcion, ProductoMinimo=0, CUV.Minimo as EfectivoMinimo, ProductoAvance=0, ")
        sConsulta.AppendLine("CUC.Cantidad as EfectivoAvance, (SELECT CASE WHEN (CUC.Cantidad/CUV.Minimo*100) > 100 THEN 100 ELSE (CUC.Cantidad/CUV.Minimo*100) END) as Porcentaje, ")
        sConsulta.AppendLine("ProductoFaltante=0, (SELECT CASE WHEN (CUV.Minimo-CUC.Cantidad) < 0 THEN 0 ELSE (CUV.Minimo-CUC.Cantidad) END) as EfectivoFaltante, ")
        sConsulta.AppendLine("(SELECT CASE WHEN ((CUV.Minimo-CUC.Cantidad)/CUV.Minimo*100) < 0 THEN 0 ELSE ((CUV.Minimo-CUC.Cantidad)/CUV.Minimo*100) END) as PorcentajeFaltante ")
        sConsulta.AppendLine("FROM Cuota CUO ")
        sConsulta.AppendLine("INNER JOIN CUOVEN CUV ON CUV.CUOClave=CUV.CUOClave AND CUV.Estado=1 AND CUV.Tipo=2 ")
        sConsulta.AppendLine("INNER JOIN Vendedor VEN ON VEN.VendedorId=CUV.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Usuario USU ON USU.USUId=VEN.USUId ")
        sConsulta.AppendLine("INNER JOIN (SELECT AGV.VendedorId, AGV.ClaveCEDI FROM AgendaVendedor AGV GROUP BY AGV.VendedorId, AGV.ClaveCEDI) as AGV on CUV.VendedorId = AGV.VendedorId  ")
        sConsulta.AppendLine("INNER JOIN Almacen ALM ON ALM.Clave=AGV.ClaveCEDI ")
        sConsulta.AppendLine("INNER JOIN CuotaCumplida CUC ON CUC.CUOClave=CUO.CUOClave AND CUC.VendedorId=VEN.VendedorId ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine(" AND CUO.Estado=1 AND CUO.Baja=0 ")
        sConsulta.AppendLine(" set nocount off ")
        Session("Query4") = sConsulta.ToString
        Return True
    End Function
    ' Devoluciones y Cambios (DISPOSUR)
    Private Function ConsultaDevolucionesCambiosDISPOSUR(ByVal ins As DBConexion.cConexionSQL, ByVal pvClientes As ArrayList, ByVal pvCondicion As String, ByVal pvFecha As Boolean, ByVal pvRutas As ArrayList) As Boolean

        If chboxFecha.Checked Then
            pvCondicion = strWhereFecha(pvCondicion, "TRP.FechaHoraAlta")
        End If

        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "RUT.RutClave")
        pvCondicion = strWhereClientes(pvCondicion, pvClientes, "CLI.ClienteClave")

        Dim sConsulta As New StringBuilder

        ' Consulta Devolucion Consignacion
        sConsulta.AppendLine(" SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine(" SET NOCOUNT OFF ")

        sConsulta.AppendLine(" DECLARE @Conversion BIT ")
        sConsulta.AppendLine(" SELECT TOP 1 @Conversion = ConversionKg FROM CONHist ORDER BY CONHistFechaInicio DESC  ")

        sConsulta.AppendLine(" SELECT FOLIO,PRODUCTOCLAVE AS CLAVE,PRONOMBRE AS PRODUCTO,UNIDAD,CONVERSION,PRECIO,CANTIDAD, ")
        sConsulta.AppendLine(" [Kg/Lts]as KgLts,CANTIDAD*PRECIO AS IMPORTE, VendedorId,VENNOMBRE AS NOMBRE,clienteid,razonsocial,rutaid,descripcion,")
        sConsulta.AppendLine(" fechahoraalta,factor,subtotal ")
        sConsulta.AppendLine(" FROM (")

        sConsulta.AppendLine("     select ")

        sConsulta.AppendLine(" 		    (select folio from transprod t2  ")
        sConsulta.AppendLine(" 	        where t2.transprodid=( select distinct transprodid1 from TrpTpd t1 where t1.transprodid=trp.transprodid))AS FOLIO,")

        sConsulta.AppendLine("     	    (select TRT.PRECIO from transprod t2 ")
        sConsulta.AppendLine(" 	        INNER JOIN TRANSPRODDETALLE TPD1 ON T2.TRANSPRODID=TPD1.TRANSPRODID ")
        sConsulta.AppendLine("     	    INNER JOIN TrpTpd TRT ON  TRT.TRANSPRODID1=TPD1.TRANSPRODID AND TRt.TRANSPRODdETALLEID=TPD1.TRANSPROdDETALLEID  ")
        sConsulta.AppendLine("     	    where TPD.PRODUCTOCLAVE=TPD1.PRODUCTOCLAVE  AND TPD.TIPOUNIDAD = TPD1.TIPOUNIDAD")
        sConsulta.AppendLine("     	    AND t2.transprodid=( select distinct transprodid1 from TrpTpd t1 where t1.transprodid=trp.transprodid))AS PRECIO,")

        sConsulta.AppendLine("     TPD.PRODUCTOCLAVE,PRO.NOMBRE AS PRONOMBRE,VAD.Descripcion as unidad,CASE @Conversion WHEN 1 THEN PRU.KgLts END AS Conversion,  ")
        sConsulta.AppendLine("     TPD.Cantidad,CASE @Conversion WHEN 1 THEN TPD.Cantidad *pRU.KgLts END AS [Kg/Lts],")
        sConsulta.AppendLine("     VEN.VendedorID AS VendedorId,VEN.NOMBRE AS VENNOMBRE,CLI.Clave AS ClienteId,")
        sConsulta.AppendLine("     CLI.RazonSocial,RUT.RUTClave AS RutaId,RUT.Descripcion,TRP.FechaHoraAlta,")
        sConsulta.AppendLine("     PD.FACTOR * TPD.CANTIDAD AS FACTOR, tpd.subtotal")

        sConsulta.AppendLine("     from transprod trp  ")
        sConsulta.AppendLine("     inner join TransProdDetalle tpd on trp.transprodid = tpd.transprodid")
        sConsulta.AppendLine("     INNER JOIN PRODUCTO PRO ON tpd.PRODUCTOCLAVE=PRO.PRODUCTOCLAVE")
        sConsulta.AppendLine("     INNER JOIN ProductoUnidad PRU ON PRU.ProductoClave = PRO.ProductoClave AND PRU.PRUTipoUnidad = TPD.TipoUnidad")
        sConsulta.AppendLine("     inner join VAVDescripcion VAD on VAD.VARCodigo = 'UNIDADV' and VAD.VAVClave = TPD.TipoUnidad and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' ")
        sConsulta.AppendLine("     INNER JOIN Visita VIS ON VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave")
        sConsulta.AppendLine("     INNER JOIN Cliente CLI ON CLI.ClienteClave = VIS.ClienteClave")
        sConsulta.AppendLine("     INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorID")
        sConsulta.AppendLine("     INNER JOIN Ruta RUT ON RUT.RUTClave = VIS.RUTClave")
        sConsulta.AppendLine("     INNER JOIN ProductoDetalle PD ON PD.ProductoClave = PRO.ProductoClave AND PD.PRUTipoUnidad = PRU.PRUTipoUnidad AND PD.ProductoDetClave =  TPD.ProductoClave ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine("	   and TRP.tipo = 3 and TRP.tipoFase = 1  and TRP.transprodid in (select distinct transprodid from trptpd trt where  TRT.TransProdID = TRP.TransProdID ) ")


        sConsulta.AppendLine(" )AS T1")
        sConsulta.AppendLine(" SET NOCOUNT OFF ")

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If

        Session("Devolucion") = dt

        ' Consulta Cambios Consignacion 

        sConsulta = New StringBuilder

        sConsulta.AppendLine(" SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine(" SET NOCOUNT OFF ")

        sConsulta.AppendLine(" DECLARE @Conversion BIT ")
        sConsulta.AppendLine(" SELECT TOP 1 @Conversion = ConversionKg FROM CONHist ORDER BY CONHistFechaInicio DESC  ")

        sConsulta.AppendLine(" SELECT  ")
        sConsulta.AppendLine(" 	TRP.Folio AS Folio ")
        sConsulta.AppendLine(" 	,TRP.TipoMovimiento ")
        sConsulta.AppendLine(" 	,TRD.ProductoClave AS Clave ")
        sConsulta.AppendLine(" 	,(SELECT Nombre FROM Producto WHERE ProductoClave = TRD.ProductoClave) AS Producto ")
        sConsulta.AppendLine(" 	,vad.descripcion AS Unidad ")
        sConsulta.AppendLine(" 	,CASE @Conversion ")
        sConsulta.AppendLine(" 		WHEN 1 THEN PRU.KgLts ")
        sConsulta.AppendLine(" 	 END AS Conversion ")
        sConsulta.AppendLine(" 	,PPV.Precio ")
        sConsulta.AppendLine(" 	,CASE ")
        sConsulta.AppendLine(" 		WHEN TRP.TipoMovimiento = 1 THEN TRD.Cantidad ")
        sConsulta.AppendLine(" 			ELSE 0 ")
        sConsulta.AppendLine(" 	END AS CantidadEnt ")
        sConsulta.AppendLine(" 	,CASE ")
        sConsulta.AppendLine(" 		WHEN TRP.TipoMovimiento = 1 ")
        sConsulta.AppendLine(" 		THEN CASE @Conversion ")
        sConsulta.AppendLine(" 			 WHEN 1 THEN (TRD.Cantidad * (SELECT KgLts FROM ProductoUnidad WHERE ProductoClave = TRD.ProductoClave AND PRUTipoUnidad = TRD.TipoUnidad ) ) ")
        sConsulta.AppendLine(" 			 END ")
        sConsulta.AppendLine(" 		ELSE 0 ")
        sConsulta.AppendLine(" 	END AS [KgLtsEnt] ")
        sConsulta.AppendLine(" 	,CASE ")
        sConsulta.AppendLine(" 		WHEN TRP.TipoMovimiento = 1 THEN (TRD.Cantidad * PPV.Precio) ")
        sConsulta.AppendLine(" 		ELSE 0 ")
        sConsulta.AppendLine(" 	END AS ImporteEnt ")
        sConsulta.AppendLine(" 	,CASE ")
        sConsulta.AppendLine(" 		WHEN TRP.TipoMovimiento = 2 THEN TRD.Cantidad ")
        sConsulta.AppendLine(" 		ELSE 0 ")
        sConsulta.AppendLine(" 	END AS CantidadSal ")
        sConsulta.AppendLine(" 	,CASE ")
        sConsulta.AppendLine(" 		WHEN TRP.TipoMovimiento = 2 ")
        sConsulta.AppendLine(" 		THEN CASE @Conversion ")
        sConsulta.AppendLine(" 			 WHEN 1 THEN (TRD.Cantidad * (SELECT KgLts FROM ProductoUnidad WHERE ProductoClave = TRD.ProductoClave AND PRUTipoUnidad = TRD.TipoUnidad ) ) ")
        sConsulta.AppendLine(" 			 END ")
        sConsulta.AppendLine(" 		ELSE 0 ")
        sConsulta.AppendLine(" 	END AS [KgLtsSal] ")
        sConsulta.AppendLine(" 	,CASE ")
        sConsulta.AppendLine(" 		WHEN TRP.TipoMovimiento = 2 THEN (TRD.Cantidad * PPV.Precio) ")
        sConsulta.AppendLine(" 		ELSE 0 ")
        sConsulta.AppendLine(" 	END AS ImporteSal ")
        sConsulta.AppendLine(" 	,VEN.VendedorID AS VendedorId ")
        sConsulta.AppendLine(" 	,VEN.Nombre ")
        sConsulta.AppendLine(" 	,CLI.Clave AS ClienteId ")
        sConsulta.AppendLine(" 	,CLI.RazonSocial ")
        sConsulta.AppendLine(" 	,RUT.RUTClave AS RutaId ")
        sConsulta.AppendLine(" 	,RUT.Descripcion ")
        sConsulta.AppendLine(" 	,TRP.TipoMovimiento ")
        sConsulta.AppendLine(" 	,dateadd(dd,0, datediff(dd,0,TRP.FechaHoraAlta)) AS FechaHoraAlta ")
        sConsulta.AppendLine(" 	,CASE ")
        sConsulta.AppendLine(" 		WHEN TRP.TipoMovimiento = 1 ")
        sConsulta.AppendLine(" 		THEN (TRD.Cantidad * (SELECT Factor FROM ProductoDetalle WHERE ProductoClave = PRU.ProductoClave AND PRUTipoUnidad = PRU.PRUTipoUnidad AND ProductoDetClave =  TRD.ProductoClave)) ")
        sConsulta.AppendLine(" 		ELSE 0 ")
        sConsulta.AppendLine(" 	END AS FactorEntrada ")
        sConsulta.AppendLine(" 	,CASE ")
        sConsulta.AppendLine(" 		WHEN TRP.TipoMovimiento = 1 THEN TRD.Subtotal ")
        sConsulta.AppendLine(" 		ELSE 0 ")
        sConsulta.AppendLine(" 	END AS SubTotalEntrada ")
        sConsulta.AppendLine(" 	,CASE ")
        sConsulta.AppendLine(" 		WHEN TRP.TipoMovimiento = 2 ")
        sConsulta.AppendLine(" 		THEN (TRD.Cantidad * (SELECT Factor FROM ProductoDetalle WHERE ProductoClave = PRU.ProductoClave AND PRUTipoUnidad = PRU.PRUTipoUnidad AND ProductoDetClave =  TRD.ProductoClave)) ")
        sConsulta.AppendLine(" 		ELSE 0 ")
        sConsulta.AppendLine(" 	END AS FactorSalida ")
        sConsulta.AppendLine(" 	,CASE ")
        sConsulta.AppendLine(" 		WHEN TRP.TipoMovimiento = 2 THEN TRD.Subtotal ")
        sConsulta.AppendLine(" 		ELSE 0 ")
        sConsulta.AppendLine(" 	END AS SubTotalSalida ")
        sConsulta.AppendLine(" FROM TransProd TRP ")
        sConsulta.AppendLine(" INNER JOIN TransProdDetalle TRD ")
        sConsulta.AppendLine(" 	ON TRD.TransProdID = TRP.TransProdID ")
        sConsulta.AppendLine(" INNER JOIN ProductoUnidad PRU ")
        sConsulta.AppendLine(" 	ON PRU.ProductoClave = TRD.ProductoClave AND PRU.PRUTipoUnidad = TRD.TipoUnidad ")
        sConsulta.AppendLine(" inner join Visita VIS ")
        sConsulta.AppendLine(" 	on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ")
        sConsulta.AppendLine(" inner join Cliente CLI ")
        sConsulta.AppendLine(" 	on CLI.ClienteClave = VIS.ClienteClave ")
        sConsulta.AppendLine(" INNER JOIN Vendedor VEN ")
        sConsulta.AppendLine(" 	ON VEN.VendedorID = VIS.VendedorID ")
        sConsulta.AppendLine("     inner join VAVDescripcion VAD on VAD.VARCodigo = 'UNIDADV' and VAD.VAVClave = TRD.TipoUnidad and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' ")
        sConsulta.AppendLine(" INNER JOIN Ruta RUT ")
        sConsulta.AppendLine(" 	ON RUT.RUTClave = VIS.RUTClave ")
        sConsulta.AppendLine(" inner join PrecioProductoVig PPV on PPV.ProductoClave = TRD.ProductoClave and PPV.PRUTipoUnidad = TRD.TipoUnidad and TRP.FechaHoraAlta >= PPV.PPVFechaInicio and TRP.FechaHoraAlta <= PPV.FechaFin and PPV.PrecioClave = (select TOP 1 PE.PrecioClave from precioclienteesquema PE where PE.Esquemaid in (select EsquemaId from clienteesquema where clienteesquema.ClienteClave = CLI.ClienteClave) AND PE.ModuloMovDetalleClave in (select ModuloMovDetalleClave from modulomovdetalle where tipoindice = 9 and tipotransprod = 1 and tipoestado = 1)) ")

        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine(" AND TRP.Tipo = 9 AND TRP.TipoFase = 1 AND TRP.TipoMovimiento IN (1,2) ")

        sConsulta.AppendLine(" SET NOCOUNT OFF ")

        Session("Cambios") = sConsulta.ToString()

        Return True
    End Function

    Private Function ConsultaConsignacion(ByVal ins As DBConexion.cConexionSQL, ByVal pvDetallado As Boolean, ByVal pvConversionKg As Boolean, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvClientes As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        Dim sCondicion2 As String = pvCondicion
        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "TRP.FechaHoraAlta")
            sCondicion2 = strWhereFecha(sCondicion2, "TRP.FechaHoraAlta")
        End If
        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "RUT.RUTClave")
        sCondicion2 = strWhereRutas(sCondicion2, pvRutas, "RUT.RUTClave")
        pvCondicion = strWhereCentrosDistribucion(pvCondicion, "AGV.ClaveCEDI")
        sCondicion2 = strWhereCentrosDistribucion(sCondicion2, "AGV.ClaveCEDI")
        pvCondicion = strWhereClientes(pvCondicion, pvClientes, "CLI.ClienteClave")

        If pvDetallado Then
            '----------------- DETALLE DE VENTA ----------------
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("SET NOCOUNT ON ")
            sConsulta.AppendLine("select ALM.Clave as ALMClave, ALM.Nombre as ALMNombre, VEN.VendedorId, VEN.Nombre as VENNombre, ")
            sConsulta.AppendLine("convert(varchar(20),TRP.FechaHoraAlta,103) as FechaHoraAlta, RUT.RUTClave, RUT.Descripcion as RUTDescripcion, TRP.TransProdId, TRP.Folio, ")
            sConsulta.AppendLine("CLI.Clave + ' ' + substring(CLI.RazonSocial,1,40) as RazonSocial, CLI.NombreContacto, TPD.ProductoClave, PRO.Nombre, VAD.Descripcion as TipoUnidad, ")
            sConsulta.AppendLine("TPD.Cantidad, (PRD.Factor * TPD.Cantidad) as CantidadTotal, TPD.Precio, ")
            If pvConversionKg Then
                sConsulta.AppendLine("(TPD.Cantidad * PRU.KgLts) as KgLts, ")
            End If
            sConsulta.AppendLine("TPD.Subtotal, TPD.Impuesto, TPD.Total ")
            sConsulta.AppendLine("from TransProd TRP ")
            sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransprodID = TPD.TransprodID ")
            sConsulta.AppendLine("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave AND VIS.DiaClave=TRP.DiaClave ")
            sConsulta.AppendLine("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Ruta RUT on VIS.RUTClave = RUT.RUTClave ")
            sConsulta.AppendLine("inner join Producto PRO on PRO.ProductoClave=TPD.ProductoClave ")
            sConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VARCodigo = 'UNIDADV' and VAD.VAVClave = TPD.TipoUnidad and VAD.VADTipoLenguaje='" & Session("lenguaje") & "' ")
            sConsulta.AppendLine("inner join ProductoUnidad PRU on PRU.ProductoClave = TPD.ProductoClave and PRU.PRUTipoUnidad = TPD.TipoUnidad ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRD.ProductoClave = TPD.ProductoClave AND PRD.ProductoDetClave = TPD.ProductoClave and PRD.PRUTipoUnidad = TPD.TipoUnidad ")
            sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join (SELECT AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, AGV.ClienteClave, AGV.ClaveCEDI FROM AgendaVendedor AGV GROUP BY AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, AGV.ClienteClave, AGV.ClaveCEDI) as AGV on TRP.DiaClave = AGV.DiaClave and VEN.VendedorId = AGV.VendedorId  and VIS.ClienteClave = AGV.ClienteClave and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join Almacen ALM on AGV.ClaveCEDI = ALM.Clave ")
            sConsulta.AppendLine(pvCondicion)
            sConsulta.AppendLine(" AND TRP.Tipo=24 AND TRP.TipoFase<>0 ")
            Session("Query0") = sConsulta.ToString

            '-------------- COBRANZA EFECTUADA --------------
            sConsulta = New StringBuilder
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("SET NOCOUNT ON ")
            sConsulta.AppendLine("select ALM.Clave as ALMClave, ALM.Nombre as ALMNombre, VEN.VendedorId, VEN.Nombre as VENNombre, convert(datetime,convert(varchar(20),TRP.FechaHoraAlta,103),103) as FechaHoraAlta, RUT.RUTClave, RUT.Descripcion as RUTDescripcion, ")
            sConsulta.AppendLine("TRP.TransProdId, TRP.Total as SaldoInicial, ABT.FechaHora, ABT.Importe, ")
            sConsulta.AppendLine("(SELECT (SELECT CASE WHEN SUM(TRT.Total) IS NULL THEN 0 ELSE SUM(TRT.Total) END) FROM TRPTPD TRT WHERE TRT.TransProdId1=TRP.TransProdId) AS Devoluciones, ")
            sConsulta.AppendLine("TRP.Saldo ")
            sConsulta.AppendLine("from TransProd TRP ")
            sConsulta.AppendLine("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave AND VIS.DiaClave=TRP.DiaClave ")
            sConsulta.AppendLine("inner join Ruta RUT on VIS.RUTClave = RUT.RUTClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join (SELECT AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, AGV.ClienteClave, AGV.ClaveCEDI FROM AgendaVendedor AGV GROUP BY AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, AGV.ClienteClave, AGV.ClaveCEDI) as AGV on TRP.DiaClave = AGV.DiaClave and VEN.VendedorId = AGV.VendedorId  and VIS.ClienteClave = AGV.ClienteClave and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join Almacen ALM on AGV.ClaveCEDI = ALM.Clave ")
            sConsulta.AppendLine("inner join ABNTRP ABT on ABT.TransProdId=TRP.TransProdId ")
            sConsulta.AppendLine(sCondicion2)
            sConsulta.AppendLine(" AND TRP.Tipo=24 AND TRP.TipoFase<>0 ")
            Session("QueryD1") = sConsulta.ToString

            '----------------- DETALLE 3 ----------------
            sConsulta = New StringBuilder
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("SET NOCOUNT ON ")
            sConsulta.AppendLine("select TPD.ProductoClave, PRO.Nombre, VAD.Descripcion as TipoUnidad, ")
            sConsulta.AppendLine("SUM(TPD.Cantidad) as Cantidad, ")
            If pvConversionKg Then
                sConsulta.AppendLine("SUM(TPD.Cantidad * PRU.KgLts) as KgLts, ")
            End If
            sConsulta.AppendLine("SUM(TPD.Total) as Total ")
            sConsulta.AppendLine("from TransProd TRP ")
            sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransprodID = TPD.TransprodID ")
            sConsulta.AppendLine("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave AND VIS.DiaClave=TRP.DiaClave ")
            sConsulta.AppendLine("inner join Ruta RUT on VIS.RUTClave = RUT.RUTClave ")
            sConsulta.AppendLine("inner join Producto PRO on PRO.ProductoClave=TPD.ProductoClave ")
            sConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VARCodigo = 'UNIDADV' and VAD.VAVClave = TPD.TipoUnidad and VAD.VADTipoLenguaje='" & Session("lenguaje") & "' ")
            sConsulta.AppendLine("inner join ProductoUnidad PRU on PRU.ProductoClave = TPD.ProductoClave and PRU.PRUTipoUnidad = TPD.TipoUnidad ")
            sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join (SELECT AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, AGV.ClienteClave, AGV.ClaveCEDI FROM AgendaVendedor AGV GROUP BY AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, AGV.ClienteClave, AGV.ClaveCEDI) as AGV on TRP.DiaClave = AGV.DiaClave and VEN.VendedorId = AGV.VendedorId  and VIS.ClienteClave = AGV.ClienteClave and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join Almacen ALM on AGV.ClaveCEDI = ALM.Clave ")
            sConsulta.AppendLine(sCondicion2)
            sConsulta.AppendLine(" AND TRP.Tipo=24 AND TRP.TipoFase<>0 ")
            sConsulta.AppendLine("group by TPD.ProductoClave, PRO.Nombre, VAD.Descripcion ")
            Session("QueryD2") = sConsulta.ToString

        Else 'General
            '----------------- DETALLE DE VENTA ----------------
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("SET NOCOUNT ON ")
            sConsulta.AppendLine("select ALM.Clave as ALMClave, ALM.Nombre as ALMNombre, VEN.VendedorId, VEN.Nombre as VENNombre, convert(datetime,convert(varchar(20),TRP.FechaHoraAlta,103),103) as FechaHoraAlta, ")
            sConsulta.AppendLine("RUT.RUTClave, RUT.Descripcion as RUTDescripcion, TRP.TransProdId, TRP.Folio, CLI.ClienteClave, ")
            sConsulta.AppendLine("CLI.Clave + ' ' + substring(CLI.RazonSocial,1,40) as RazonSocial, substring(CLI.NombreContacto,1,30) as NombreContacto, TRP.Total ")
            sConsulta.AppendLine("from TransProd TRP ")
            sConsulta.AppendLine("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave AND VIS.DiaClave=TRP.DiaClave ")
            sConsulta.AppendLine("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ")
            sConsulta.AppendLine("inner join Ruta RUT on VIS.RUTClave = RUT.RUTClave ")
            sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join (SELECT AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, AGV.ClienteClave, AGV.ClaveCEDI FROM AgendaVendedor AGV GROUP BY AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, AGV.ClienteClave, AGV.ClaveCEDI) as AGV on TRP.DiaClave = AGV.DiaClave and VEN.VendedorId = AGV.VendedorId  and VIS.ClienteClave = AGV.ClienteClave and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join Almacen ALM on AGV.ClaveCEDI = ALM.Clave ")
            sConsulta.AppendLine(pvCondicion)
            sConsulta.AppendLine(" AND TRP.Tipo=24 AND TRP.TipoFase<>0 ")
            Session("Query0") = sConsulta.ToString

            '----------------- DETALLE 2 ----------------
            sConsulta = New StringBuilder
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
            sConsulta.AppendLine("SET NOCOUNT ON ")
            sConsulta.AppendLine("select ALM.Clave as ALMClave, ALM.Nombre as ALMNombre, TPD.ProductoClave, PRO.Nombre, ")
            sConsulta.AppendLine("VAD.Descripcion as TipoUnidad, SUM(TPD.Cantidad) as Cantidad, SUM(PRD.Factor * TPD.Cantidad) as CantidadTotal, ")
            If pvConversionKg Then
                sConsulta.AppendLine("SUM(TPD.Cantidad * PRU.KgLts) as KgLts, ")
            End If
            sConsulta.AppendLine("SUM(TPD.Total) as Total ")
            sConsulta.AppendLine("from TransProd TRP ")
            sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransprodID = TPD.TransprodID ")
            sConsulta.AppendLine("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave AND VIS.DiaClave=TRP.DiaClave ")
            sConsulta.AppendLine("inner join Ruta RUT on VIS.RUTClave = RUT.RUTClave ")
            sConsulta.AppendLine("inner join Producto PRO on PRO.ProductoClave=TPD.ProductoClave ")
            sConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VARCodigo = 'UNIDADV' and VAD.VAVClave = TPD.TipoUnidad and VAD.VADTipoLenguaje='" & Session("lenguaje") & "' ")
            sConsulta.AppendLine("inner join ProductoUnidad PRU on PRU.ProductoClave = TPD.ProductoClave and PRU.PRUTipoUnidad = TPD.TipoUnidad ")
            sConsulta.AppendLine("inner join ProductoDetalle PRD on PRD.ProductoClave = TPD.ProductoClave AND PRD.ProductoDetClave = TPD.ProductoClave and PRD.PRUTipoUnidad = TPD.TipoUnidad ")
            sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
            sConsulta.AppendLine("inner join (SELECT AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, AGV.ClienteClave, AGV.ClaveCEDI FROM AgendaVendedor AGV GROUP BY AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, AGV.ClienteClave, AGV.ClaveCEDI) as AGV on TRP.DiaClave = AGV.DiaClave and VEN.VendedorId = AGV.VendedorId  and VIS.ClienteClave = AGV.ClienteClave and VIS.RUTClave = AGV.RUTClave ")
            sConsulta.AppendLine("inner join Almacen ALM on AGV.ClaveCEDI = ALM.Clave ")
            sConsulta.AppendLine(sCondicion2)
            sConsulta.AppendLine(" AND TRP.Tipo=24 AND TRP.TipoFase<>0 ")
            sConsulta.AppendLine("group by ALM.Clave, ALM.Nombre, TPD.ProductoClave, PRO.Nombre, VAD.Descripcion ")
            Session("QueryG1") = sConsulta.ToString

        End If

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(Session("Query0"), IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        Return True
    End Function

    Private Function ConsultaExportarEncuestas(ByVal ins As DBConexion.cConexionSQL, ByVal pvRutas As ArrayList) As Boolean
        Dim sConsulta As New StringBuilder
        Dim sCENClave As String
        Dim sCondicion As String = ""
        'Dim dsEncuestas As New DataSet
        If Not tvEncuesta.SelectedNode.Parent Is Nothing Then
            sCENClave = tvEncuesta.SelectedNode.Value
            Session("EncuestaNombre") = sCENClave & " - " & tvEncuesta.SelectedNode.Text
            Session("EncuestaTipo") = tvEncuesta.SelectedNode.Parent.Text
            sCENClave = sCENClave.Replace("'", "''")
        Else
            sCENClave = Nothing
            Return False
        End If

        If chboxFecha.Checked Then
            sCondicion = strWhereFecha(sCondicion, "Dia.FechaCaptura")
        End If
        sCondicion = strWhereRutas(sCondicion, pvRutas, "VIS.RUTClave")

        sConsulta = New StringBuilder
        sConsulta.AppendLine("select ENC.ENCId, VIS.RUTClave, (select top 1 ESQ.Clave from Esquema ESQ inner join ClienteEsquema CE on CE.Esquemaid = ESQ.EsquemaId and CE.ClienteClave = CLI.ClienteClave) as RUTA, ")
        sConsulta.AppendLine("VIS.DiaClave, (dbo.FNObtenerValorReferencia('ENCFASE', ENC.Fase)) as fase, VIS.ClienteClave, CLI.NombreCorto, CLI.RazonSocial, CLI.IdElectronico, CLI.FechaNacimiento, CLI.VigExclusividad, ")
        sConsulta.AppendLine("CLD.Calle, CLD.Numero, CLD.NumInt, CLD.Colonia, CLD.Localidad, CLD.Entidad, CLD.CodigoPostal, CLD.ReferenciaDom, str(CLD.CoordenadaX,20,12) as CoordenadaX, str(CLD.CoordenadaY,20,12) as CoordenadaY ")
        sConsulta.AppendLine("from Encuesta ENC ")
        sConsulta.AppendLine("inner join Visita VIS on ENC.VisitaClave = VIS.VisitaClave ")
        sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ")
        sConsulta.AppendLine("inner join ClienteDomicilio CLD on CLI.ClienteClave = CLD.ClienteClave and CLD.Tipo = 2 ")
        sConsulta.AppendLine("where ENC.CENClave = '" & sCENClave & "' " & sCondicion)

        Dim dtClientes As Data.DataTable
        dtClientes = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dtClientes.Rows.Count = 0 Then
            Return False
        End If
        dtClientes.TableName = "Clientes"
        'dsEncuestas.Tables.Add(dtClientes)

        Session("ClientesEncuestados") = dtClientes

        sConsulta = New StringBuilder
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("select * into #tmpMatriz from( ")
        sConsulta.AppendLine("select CPM.CENClave, CPM.CEPNumero, CPM.CPMNumero, CRM.CRMNumero, CRM.TipoValor ")
        sConsulta.AppendLine("from CEPPregMatricial CPM ")
        sConsulta.AppendLine("inner join CEPRespMatricial CRM on CPM.CENClave = CRM.CENClave and CPM.CEPNumero = CRM.CEPNumero ")
        sConsulta.AppendLine("where CPM.CENClave = '" & sCENClave & "' ")
        sConsulta.AppendLine(")as t ")

        sConsulta.AppendLine("select ENCId,CEPNumero,Pregunta,orden,replace(replace(Respuesta,CHAR(13),''),char(10),'') as respuesta from (   ")



        '--Texto 
        sConsulta.AppendLine("select ENC.ENCId, CRT.CEPNumero, convert(varchar(32), CRT.CEPNumero) as Pregunta, convert(varchar(32), CRT.CEPNumero) as Pregunta1, convert(varchar(32), CRT.CEPNumero) as Pregunta2, convert(varchar(32), CRT.CEPNumero) as Pregunta3 ,case when ENP.ENCId IS NULL then '*NA' else ERT.Descripcion  end  as Respuesta, CEN.Orden   ")
        sConsulta.AppendLine("from Encuesta ENC ")
        sConsulta.AppendLine("inner join Visita VIS on ENC.VisitaClave = VIS.VisitaClave ")
        sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("right join CEPRespTexto CRT on ENC.CENClave = CRT.CENClave ")
        sConsulta.AppendLine("INNER JOIN CENPregunta CEN ON CEN.CENClave = CRT.CENClave AND CEN.CEPNumero = CRT.CEPNumero ")
        sConsulta.AppendLine("left join ENCPregunta ENP on ENC.ENCId = ENP.ENCId and CRT.CENClave= ENP.CENClave and CRT.CEPNumero = ENP.CEPNumero ")
        sConsulta.AppendLine("left join ENPRespTexto ERT on ENP.ENCId = ERT.ENCId and ENP.ENPId = ERT.ENPId ")
        sConsulta.AppendLine("where ENC.CENClave = '" & sCENClave & "' " & sCondicion)
        sConsulta.AppendLine("union all ")
        '--Numero 
        sConsulta.AppendLine("select ENC.ENCId, CRN.CEPNumero, convert(varchar(32), CRN.CEPNumero) as Pregunta, convert(varchar(32), CRN.CEPNumero) as Pregunta1, convert(varchar(32), CRN.CEPNumero) as Pregunta2, convert(varchar(32), CRN.CEPNumero) as Pregunta3,case when ENP.ENCId IS NULL then '*NA' else convert(varchar(100), ERN.Valor) end  as Respuesta, CEN.Orden    ")
        sConsulta.AppendLine("from Encuesta ENC ")
        sConsulta.AppendLine("inner join Visita VIS on ENC.VisitaClave = VIS.VisitaClave ")
        sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("right join CEPRespNumero CRN on ENC.CENClave = CRN.CENClave ")
        sConsulta.AppendLine("INNER JOIN CENPregunta CEN ON CEN.CENClave = CRN.CENClave AND CEN.CEPNumero = CRN.CEPNumero ")
        sConsulta.AppendLine("left join ENCPregunta ENP on ENC.ENCId = ENP.ENCId and CRN.CENClave= ENP.CENClave and CRN.CEPNumero = ENP.CEPNumero ")
        sConsulta.AppendLine("left join ENPRespNumero ERN on ENP.ENCId = ERN.ENCId and ENP.ENPId = ERN.ENPId ")
        sConsulta.AppendLine("where ENC.CENClave = '" & sCENClave & "' " & sCondicion)
        sConsulta.AppendLine("union all ")
        '--Opcional
        sConsulta.AppendLine("select ENC.ENCId, COO.CEPNumero,convert(varchar(16), COO.CEPNumero) + '_' + convert(varchar(16), COO.Numero) as Pregunta,  convert(varchar(32), COO.CEPNumero) as Pregunta1, convert(varchar(32), COO.Numero) as Pregunta2,'' as Pregunta3, ")
        sConsulta.AppendLine("case when ENP.ENCId IS NULL then '*NA' else case when CRO.TipoSeleccion = 1 then case when ERO.EROId is null then '' else COO.Descripcion end else isnull(ERO.Valor, '') end  end  as Respuesta, CEN.Orden  ")
        sConsulta.AppendLine("from Encuesta ENC ")
        sConsulta.AppendLine("inner join Visita VIS on ENC.VisitaClave = VIS.VisitaClave ")
        sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("right join CEPRespOpcional CRO on ENC.CENClave = CRO.CENClave ")
        sConsulta.AppendLine("INNER JOIN CENPregunta CEN ON CEN.CENClave = CRO.CENClave AND CEN.CEPNumero = CRO.CEPNumero ")
        sConsulta.AppendLine("right join CROOpcion COO on CRO.CENClave = COO.CENClave and CRO.CEPNumero = COO.CEPNumero and CRO.CROId = COO.CROId ")
        sConsulta.AppendLine("left join ENCPregunta ENP on ENC.ENCId = ENP.ENCId and COO.CENClave= ENP.CENClave and COO.CEPNumero = ENP.CEPNumero ")
        sConsulta.AppendLine("left join ENPRespOpcional ERO on ENP.ENCId = ERO.ENCId and ENP.ENPId = ERO.ENPId and COO.CROId = ERO.CROId and COO.COOId = ERO.COOId ")
        sConsulta.AppendLine("where ENC.CENClave = '" & sCENClave & "' " & sCondicion)
        sConsulta.AppendLine("union all ")
        '--Codigo 
        sConsulta.AppendLine("select ENC.ENCId, CRC.CEPNumero, convert(varchar(32), CRC.CEPNumero) as Pregunta, convert(varchar(32), CRC.CEPNumero) as Pregunta1, convert(varchar(32), CRC.CEPNumero) as Pregunta2, convert(varchar(32), CRC.CEPNumero) as Pregunta3,case when ENP.ENCId IS NULL then '*NA' else ERC.Codigo   end as Respuesta, CEN.Orden  ")
        sConsulta.AppendLine("from Encuesta ENC ")
        sConsulta.AppendLine("inner join Visita VIS on ENC.VisitaClave = VIS.VisitaClave ")
        sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("right join CEPRespCodigo CRC on ENC.CENClave = CRC.CENClave ")
        sConsulta.AppendLine("INNER JOIN CENPregunta CEN ON CEN.CENClave = CRC.CENClave AND CEN.CEPNumero = CRC.CEPNumero ")
        sConsulta.AppendLine("left join ENCPregunta ENP on ENC.ENCId = ENP.ENCId and CRC.CENClave= ENP.CENClave and CRC.CEPNumero = ENP.CEPNumero ")
        sConsulta.AppendLine("left join ENPRespCodigo ERC on ENP.ENCId = ERC.ENCId and ENP.ENPId = ERC.ENPId ")
        sConsulta.AppendLine("where ENC.CENClave = '" & sCENClave & "' " & sCondicion)
        sConsulta.AppendLine("union all ")
        '--Matricial 
        sConsulta.AppendLine("select ENC.ENCId, MAT.CEPNumero, convert(varchar(16), MAT.CEPNumero) + '_' + convert(varchar(16), MAT.CPMNumero) + '_' + convert(varchar(16), MAT.CRMNumero) as Pregunta, convert(varchar(16), MAT.CEPNumero) as Pregunta1, convert(varchar(16), MAT.CPMNumero) as Pregunta2, convert(varchar(16), MAT.CRMNumero) as Pregunta3,  ")
        sConsulta.AppendLine("case when ENP.ENCId IS NULL then '*NA' else  case when MAT.TipoValor = 1 then case when ERM.ERMId is null then '' else 'SI' end else ERM.Valor end  end as Respuesta, CEN.Orden   ")
        sConsulta.AppendLine("from Encuesta ENC ")
        sConsulta.AppendLine("inner join Visita VIS on ENC.VisitaClave = VIS.VisitaClave ")
        sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("right join #tmpMatriz MAT on ENC.CENClave = MAT.CENClave ")
        sConsulta.AppendLine("INNER JOIN CENPregunta CEN ON CEN.CENClave = MAT.CENClave AND CEN.CEPNumero = MAT.CEPNumero ")
        sConsulta.AppendLine("left join ENCPregunta ENP on ENC.ENCId = ENP.ENCId and MAT.CENClave= ENP.CENClave and MAT.CEPNumero = ENP.CEPNumero ")
        sConsulta.AppendLine("left join ENPRespMatricial ERM on ENP.ENCId = ERM.ENCId and ENP.ENPId = ERM.ENPId ")
        sConsulta.AppendLine("and MAT.CENClave = ERM.CENClave and MAT.CEPNumero = ERM.CEPNumero and MAT.CPMNumero = ERM.CPMNumero ")
        sConsulta.AppendLine("and MAT.CENClave = ERM.CENClave1 and MAT.CEPNumero = ERM.CEPNumero1 and MAT.CRMNumero = ERM.CRMNumero ")
        sConsulta.AppendLine("where ENC.CENClave = '" & sCENClave & "' " & sCondicion)
        sConsulta.AppendLine("union all ")
        '--GPS Altitud
        'sConsulta.AppendLine("select ENC.ENCId, CRG.CEPNumero, convert(varchar(32), CRG.CEPNumero) + '_Altitud' as Pregunta,convert(varchar(32), CRG.CEPNumero)  as Pregunta1, '1' as Pregunta2, '' as Pregunta3,case when ENP.ENCId IS NULL then '*NA' else convert(varchar(100), ERG.Altitud)  end  as Respuesta, CEN.Orden   ")
        'sConsulta.AppendLine("from Encuesta ENC ")
        'sConsulta.AppendLine("inner join Visita VIS on ENC.VisitaClave = VIS.VisitaClave ")
        'sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        'sConsulta.AppendLine("right join CEPRespGPS CRG on ENC.CENClave = CRG.CENClave ")
        'sConsulta.AppendLine("INNER JOIN CENPregunta CEN ON CEN.CENClave = CRG.CENClave AND CEN.CEPNumero = CRG.CEPNumero ")
        'sConsulta.AppendLine("left join ENCPregunta ENP on ENC.ENCId = ENP.ENCId and CRG.CENClave= ENP.CENClave and CRG.CEPNumero = ENP.CEPNumero ")
        'sConsulta.AppendLine("left join ENPRespGPS ERG on ENP.ENCId = ERG.ENCId and ENP.ENPId = ERG.ENPId ")
        'sConsulta.AppendLine("where ENC.CENClave = '" & sCENClave & "' " & sCondicion)
        'sConsulta.AppendLine("union all ")
        '--GPS Latitud
        sConsulta.AppendLine("select ENC.ENCId, CRG.CEPNumero, convert(varchar(32), CRG.CEPNumero) + '_Latitud' as Pregunta,convert(varchar(32), CRG.CEPNumero)  as Pregunta1, '2' as Pregunta2, '' as Pregunta3,case when ENP.ENCId IS NULL then '*NA' else str(ERG.Latitud,20,12)  end  as Respuesta, CEN.Orden    ")
        sConsulta.AppendLine("from Encuesta ENC ")
        sConsulta.AppendLine("inner join Visita VIS on ENC.VisitaClave = VIS.VisitaClave ")
        sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("right join CEPRespGPS CRG on ENC.CENClave = CRG.CENClave ")
        sConsulta.AppendLine("INNER JOIN CENPregunta CEN ON CEN.CENClave = CRG.CENClave AND CEN.CEPNumero = CRG.CEPNumero ")
        sConsulta.AppendLine("left join ENCPregunta ENP on ENC.ENCId = ENP.ENCId and CRG.CENClave= ENP.CENClave and CRG.CEPNumero = ENP.CEPNumero ")
        sConsulta.AppendLine("left join ENPRespGPS ERG on ENP.ENCId = ERG.ENCId and ENP.ENPId = ERG.ENPId ")
        sConsulta.AppendLine("where ENC.CENClave = '" & sCENClave & "' " & sCondicion)
        sConsulta.AppendLine("union all ")
        '--GPS Longitud
        sConsulta.AppendLine("select ENC.ENCId, CRG.CEPNumero, convert(varchar(32), CRG.CEPNumero) + '_Longitud' as Pregunta,convert(varchar(32), CRG.CEPNumero)  as Pregunta1, '3' as Pregunta2, '' as Pregunta3,case when ENP.ENCId IS NULL then '*NA' else str(ERG.Longitud,20,12)  end  as Respuesta, CEN.Orden    ")
        sConsulta.AppendLine("from Encuesta ENC ")
        sConsulta.AppendLine("inner join Visita VIS on ENC.VisitaClave = VIS.VisitaClave ")
        sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("right join CEPRespGPS CRG on ENC.CENClave = CRG.CENClave ")
        sConsulta.AppendLine("INNER JOIN CENPregunta CEN ON CEN.CENClave = CRG.CENClave AND CEN.CEPNumero = CRG.CEPNumero ")
        sConsulta.AppendLine("left join ENCPregunta ENP on ENC.ENCId = ENP.ENCId and CRG.CENClave= ENP.CENClave and CRG.CEPNumero = ENP.CEPNumero ")
        sConsulta.AppendLine("left join ENPRespGPS ERG on ENP.ENCId = ERG.ENCId and ENP.ENPId = ERG.ENPId ")
        sConsulta.AppendLine("where ENC.CENClave = '" & sCENClave & "' " & sCondicion)
        sConsulta.AppendLine(")as t ")
        sConsulta.AppendLine("order by ENCId, Orden, CEPNumero,convert(int,pregunta1),convert(int,pregunta2),convert(int,pregunta3)  ")
        sConsulta.AppendLine("drop table #tmpMatriz ")
        sConsulta.AppendLine("set nocount off ")
        'Session("Encuestas") = sConsulta.ToString

        Dim dtEncuestas As DataTable
        dtEncuestas = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        dtEncuestas.TableName = "Encuestas"
        'dsEncuestas.Tables.Add(dtEncuestas)

        Session("EncuestasAplicadas") = dtEncuestas
        'ExportarEncuestasCSV(dtClientes, dtEncuestas)

        Return True
    End Function

    Private Function ConsultaClientesNoVisitados(ByVal ins As DBConexion.cConexionSQL, ByVal pvRutas As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        Dim pvCondicion As String = ""
        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "AGV.RUTClave")
        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "DIA.FechaCaptura")
        End If

        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("SELECT distinct DIA.FechaCaptura, (RUT.RUTClave + '-' + RUT.Descripcion) AS Deposito,Es.Clave As Ruta, ")
        sConsulta.AppendLine("  CLI.Clave, CLI.RazonSocial, CLI.IdElectronico, CLD.Calle , CLD.Numero, ")
        sConsulta.AppendLine("  CLD.NumInt, CLD.Colonia, CLD.Localidad, CLD.Poblacion, CLD.Entidad, ")
        sConsulta.AppendLine("  CLD.CodigoPostal, CLD.ReferenciaDom, str(CLD.CoordenadaX, 20, 12) as CoordenadaX, str(CLD.CoordenadaY, 20, 12) as CoordenadaY ")
        sConsulta.AppendLine("FROM AgendaVendedor AGV ")
        sConsulta.AppendLine("INNER JOIN DIA ON DIA.DiaClave = AGV.DiaClave ")
        sConsulta.AppendLine("INNER JOIN Ruta RUT ON RUT.RUTClave = AGV.RUTClave ")
        sConsulta.AppendLine("INNER JOIN Cliente CLI ON CLI.ClienteClave = AGV.ClienteClave ")
        sConsulta.AppendLine("INNER JOIN ClienteDomicilio CLD ON CLD.ClienteClave = CLI.ClienteClave AND CLD.Tipo= 2 ")
        sConsulta.AppendLine("INNER JOIN ClienteEsquema CE ON CE.ClienteClave = Cli.ClienteClave ")
        sConsulta.AppendLine("inner join Esquema Es on CE.EsquemaID = Es.EsquemaID ")
        sConsulta.AppendLine("WHERE AGV.ClienteClave NOT IN (	SELECT VIS.ClienteClave ")
        sConsulta.AppendLine("                                  FROM Visita VIS ")
        sConsulta.AppendLine("                                  WHERE VIS.DiaClave = AGV.DiaClave ) ")
        sConsulta.AppendLine(pvCondicion)
        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt
        Return True
    End Function

    Private Function ConsultaPuntosRecorrido(ByVal ins As DBConexion.cConexionSQL, ByVal pvRutas As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder
        Dim pvCondicion As String = ""
        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "GPS.RUTClave")
        If pvFecha Then
            pvCondicion = strWhereFecha(pvCondicion, "DIA.FechaCaptura")
        End If

        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("SELECT DIA.FechaCaptura AS  DiaTrabajo, (RUT.RUTClave +'-'+RUT.Descripcion) AS Ruta, ")
        sConsulta.AppendLine("str(GPS.CoordenadaX, 20, 12) AS LongitudX, str(GPS.CoordenadaY, 20, 12) AS LatitudY, VEN.Nombre AS Vendedor")
        sConsulta.AppendLine("FROM PuntoGPS GPS ")
        sConsulta.AppendLine("INNER JOIN Dia ON DIA.DiaClave = GPS.DiaClave ")
        sConsulta.AppendLine("INNER JOIN Vendedor VEN ON VEN.VendedorId = GPS.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Ruta RUT ON RUT.RUTClave = GPS.RUTClave ")
        sConsulta.AppendLine("WHERE 1 = 1 ")
        sConsulta.AppendLine(pvCondicion)
        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt
        Return True
    End Function
    'Public Sub MensajeAArchivo(ByVal sMensaje As String)
    '    Dim oFile As New IO.FileStream("IPSM/Route/Coordenadas.txt", IO.FileMode.OpenOrCreate, IO.FileAccess.ReadWrite)
    '    Dim w As IO.StreamWriter = New IO.StreamWriter(oFile)
    '    w.BaseStream.Seek(0, IO.SeekOrigin.End)
    '    'w.Write("Log Entry : {0}", vbCrLf)
    '    'w.WriteLine("{0} {1}{2}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString(), vbCrLf)
    '    w.WriteLine("{0}{1}", sMensaje, vbCrLf)
    '    w.Flush()
    '    oFile.Close()
    'End Sub

    Private Function ConsultaSugeridoCargaPorReparto(ByVal ins As DBConexion.cConexionSQL, ByVal pvConversionKg As Boolean, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvEsquemas As ArrayList) As Boolean
        Dim sConsulta As New StringBuilder
        Dim aEsquemas As ArrayList = New ArrayList
        Dim sEsquemas As String = ""
        'Dim sCondicion As String
        pvCondicion = strWhereCentrosDistribucion(pvCondicion, "AGV.ClaveCEDI")
        pvCondicion = strWhereRutas(pvCondicion, pvRutas, "VIS.RUTClave")

        For Each sEsquemaId As String In pvEsquemas
            aEsquemas.Add(sEsquemaId)
            BuscarEsquemasHijos(ins, sEsquemaId, aEsquemas)
        Next
        For Each sEsquemaId As String In aEsquemas
            sEsquemas &= "'" & sEsquemaId & "',"
        Next
        If sEsquemas.Length > 0 Then sEsquemas = Left(sEsquemas, sEsquemas.Length - 1)

        If pvConversionKg Then
            sConsulta.AppendLine("select ALM.Clave as ClaveCEDI, ALM.Nombre as NombreCEDI, VIS.RUTClave, VEN.VendedorId, VEN.Nombre as NombreVEN, T1.ProductoClave, PRO.Nombre as NombrePRO, dbo.fnObtenerValorReferencia('UNIDADV', T1.TipoUnidad) as Unidad, sum(T1.Cantidad) as Cantidad, sum(T1.Cantidad) * PRU.KgLts as KgLts ")
            sConsulta.AppendLine("from ( ")
            sConsulta.AppendLine("select TRP.VisitaClave, TPD.ProductoClave, TPD.TipoUnidad, TPD.Cantidad ")
            sConsulta.AppendLine("from TransProd TRP ")
            sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ")
            sConsulta.AppendLine("where TRP.Tipo = 1 and TRP.TipoFase = 1 ")
            sConsulta.AppendLine("union all ")
            sConsulta.AppendLine("select TRP.VisitaClave, PRN.ProductoClave, PRN.TipoUnidad, PRN.Cantidad ")
            sConsulta.AppendLine("from TransProd TRP ")
            sConsulta.AppendLine("inner join ProductoNegado PRN on TRP.TransProdId = PRN.TransProdId ")
            sConsulta.AppendLine("where PRN.TipoFasePRP = 1 ")
            sConsulta.AppendLine(") as T1 ")
            sConsulta.AppendLine("inner join Producto PRO on T1.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join ProductoUnidad PRU on T1.ProductoClave = PRU.ProductoClave and T1.TipoUnidad = PRU.PRUTipoUnidad ")
            sConsulta.AppendLine("inner join Visita VIS on T1.VisitaClave = VIS.VisitaClave ")
            sConsulta.AppendLine("inner join AgendaVendedor AGV on VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorId and VIS.ClienteClave = AGV.ClienteClave ")
            sConsulta.AppendLine("inner join Almacen ALM on AGV.ClaveCEDI = ALM.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
            If sEsquemas.Length > 0 Then
                sConsulta.AppendLine("inner join ProductoEsquema PRE on T1.ProductoClave = PRE.ProductoClave and EsquemaId in (" & sEsquemas & ") ")
            End If
            sConsulta.AppendLine(pvCondicion)
            sConsulta.AppendLine("group by ALM.Clave, ALM.Nombre, VIS.RUTClave, VEN.Nombre, VEN.VendedorId, T1.ProductoClave, PRO.Nombre, T1.TipoUnidad, KgLts ")
            sConsulta.AppendLine("order by ALM.Clave, ALM.Nombre, VIS.RUTClave, VEN.Nombre, VEN.VendedorId, T1.ProductoClave, PRO.Nombre, T1.TipoUnidad ")
        Else
            sConsulta.AppendLine("select ALM.Clave as ClaveCEDI, ALM.Nombre as NombreCEDI, VIS.RUTClave, VEN.VendedorId, VEN.Nombre as NombreVEN, T1.ProductoClave, PRO.Nombre as NombrePRO, dbo.fnObtenerValorReferencia('UNIDADV', T1.TipoUnidad) as Unidad, sum(T1.Cantidad) as Cantidad ")
            sConsulta.AppendLine("from ( ")
            sConsulta.AppendLine("select TRP.VisitaClave, TPD.ProductoClave, TPD.TipoUnidad, TPD.Cantidad ")
            sConsulta.AppendLine("from TransProd TRP ")
            sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ")
            sConsulta.AppendLine("where TRP.Tipo = 1 and TRP.TipoFase = 1 ")
            sConsulta.AppendLine("union all ")
            sConsulta.AppendLine("select TRP.VisitaClave, PRN.ProductoClave, PRN.TipoUnidad, PRN.Cantidad ")
            sConsulta.AppendLine("from TransProd TRP ")
            sConsulta.AppendLine("inner join ProductoNegado PRN on TRP.TransProdId = PRN.TransProdId ")
            sConsulta.AppendLine("where PRN.TipoFasePRP = 1 ")
            sConsulta.AppendLine(") as T1 ")
            sConsulta.AppendLine("inner join Producto PRO on T1.ProductoClave = PRO.ProductoClave ")
            sConsulta.AppendLine("inner join Visita VIS on T1.VisitaClave = VIS.VisitaClave ")
            sConsulta.AppendLine("inner join AgendaVendedor AGV on VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorId and VIS.ClienteClave = AGV.ClienteClave ")
            sConsulta.AppendLine("inner join Almacen ALM on AGV.ClaveCEDI = ALM.Clave ")
            sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
            If sEsquemas.Length > 0 Then
                sConsulta.AppendLine("inner join ProductoEsquema PRE on T1.ProductoClave = PRE.ProductoClave and EsquemaId in (" & sEsquemas & ") ")
            End If
            sConsulta.AppendLine(pvCondicion)
            sConsulta.AppendLine("group by ALM.Clave, ALM.Nombre, VIS.RUTClave, VEN.Nombre, VEN.VendedorId, T1.ProductoClave, PRO.Nombre, T1.TipoUnidad ")
            sConsulta.AppendLine("order by ALM.Clave, ALM.Nombre, VIS.RUTClave, VEN.Nombre, VEN.VendedorId, T1.ProductoClave, PRO.Nombre, T1.TipoUnidad ")
        End If

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt
        Return True
    End Function

    Private Function ConsultaDevolucionesFrioPanque(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder

        pvCondicion = ""
        pvCondicion = strWhereCentrosDistribucion(pvCondicion, "ALM.Clave")

        sConsulta.AppendLine("SET ANSI_WARNINGS on ")
        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("")
        sConsulta.AppendLine("SET DATEFIRST 5")
        sConsulta.AppendLine("declare @fecha as datetime")
        sConsulta.AppendLine("set @fecha='" & FechaInicioPrimeraHora() & "'")

        sConsulta.AppendLine("if (select object_id('tempdb..#TmpFechas')) is not null drop table #TmpFechas ")
        sConsulta.AppendLine("select * into #TmpFechas from( ")
        sConsulta.AppendLine("select VendedorId, DATEADD(d,-DATEPART(weekday,@fecha)+1,@fecha) as Fecha, PrimeraFecha FROM dbo.FNPrimerDiaCarga(@fecha, 1) ")
        sConsulta.AppendLine("union all ")
        sConsulta.AppendLine("select VendedorId, DATEADD(d,-DATEPART(weekday,@fecha)+2,@fecha) as Fecha, PrimeraFecha FROM dbo.FNPrimerDiaCarga(@fecha, 2) ")
        sConsulta.AppendLine("union all ")
        sConsulta.AppendLine("select VendedorId, DATEADD(d,-DATEPART(weekday,@fecha)+3,@fecha) as Fecha, PrimeraFecha FROM dbo.FNPrimerDiaCarga(@fecha, 3) ")
        sConsulta.AppendLine("union all ")
        sConsulta.AppendLine("select VendedorId, DATEADD(d,-DATEPART(weekday,@fecha)+4,@fecha) as Fecha, PrimeraFecha FROM dbo.FNPrimerDiaCarga(@fecha, 4) ")
        sConsulta.AppendLine("union all ")
        sConsulta.AppendLine("select VendedorId, DATEADD(d,-DATEPART(weekday,@fecha)+5,@fecha) as Fecha, PrimeraFecha FROM dbo.FNPrimerDiaCarga(@fecha, 5) ")
        sConsulta.AppendLine("union all ")
        sConsulta.AppendLine("select VendedorId, DATEADD(d,-DATEPART(weekday,@fecha)+6,@fecha) as Fecha, PrimeraFecha FROM dbo.FNPrimerDiaCarga(@fecha, 6) ")
        sConsulta.AppendLine("union all ")
        sConsulta.AppendLine("select VendedorId, DATEADD(d,-DATEPART(weekday,@fecha)+7,@fecha) as Fecha, PrimeraFecha FROM dbo.FNPrimerDiaCarga(@fecha, 7) ")
        sConsulta.AppendLine(") as T1 ")

        sConsulta.AppendLine("select clave ,nombre,viernes as inicioV,jueves as FinJ,")
        sConsulta.AppendLine("sum(DevolucionViernes)+sum(ReclasificadoViernes) as DevolucionViernes,sum(FrioViernes)-sum(ReclasificadoViernes) as FrioViernes ,Sum(cargaviernes) as CargaViernes,")
        sConsulta.AppendLine("sum(DevolucionSabado)+sum(ReclasificadoSabado) as DevolucionSabado,sum(FrioSabado)-sum(ReclasificadoSabado) as FrioSabado ,Sum(cargasabado) as CargaSabado,")
        sConsulta.AppendLine("sum(DevolucionDomingo)+sum(ReclasificadoDomingo) as DevolucionDomingo,sum(FrioDomingo)-sum(ReclasificadoDomingo) as FrioDomingo ,Sum(cargadomingo) as CargaDomingo,")
        sConsulta.AppendLine("sum(DevolucionLunes)+sum(ReclasificadoLunes) as DevolucionLunes,sum(FrioLunes)-sum(ReclasificadoLunes) as FrioLunes ,Sum(cargalunes) as CargaLunes,")
        sConsulta.AppendLine("sum(DevolucionMartes)+sum(ReclasificadoMartes) as DevolucionMartes,sum(FrioMartes)-sum(ReclasificadoMartes) as FrioMartes ,Sum(cargamartes) as CargaMartes,")
        sConsulta.AppendLine("sum(DevolucionMiercoles)+sum(ReclasificadoMiercoles) as DevolucionMiercoles,sum(FrioMiercoles)-sum(ReclasificadoMiercoles) as FrioMiercoles ,Sum(CargaMiercoles) as CargaMiercoles,")
        sConsulta.AppendLine("sum(DevolucionJueves)+sum(ReclasificadoJueves) as DevolucionJueves,sum(FrioJueves)-sum(ReclasificadoJueves) as FrioJueves,Sum(cargajueves) as CargaJueves")
        sConsulta.AppendLine("")
        sConsulta.AppendLine("from")
        sConsulta.AppendLine("(")
        sConsulta.AppendLine("		select USU.Clave,VEN.Nombre,DATEADD(d,-DATEPART(weekday,@fecha)+1,@fecha) as viernes,DATEADD(d,-DATEPART(weekday,@fecha)+7,@fecha)as jueves, ")
        sConsulta.AppendLine("")
        sConsulta.AppendLine("		DevolucionViernes=(SELECT CASE WHEN TRP.Tipo=7 and DATEADD(d,-DATEPART(weekday,@fecha)+1,@fecha) = dia.FechaCaptura THEN TPD.Cantidad * PDD.Factor ELSE 0 END),")
        sConsulta.AppendLine("		FrioViernes=(SELECT CASE WHEN TRP.Tipo=4  and DATEADD(d,-DATEPART(weekday,@fecha)+1,@fecha) = dia.FechaCaptura THEN TPD.Cantidad * PDD.Factor ELSE 0 END),")
        sConsulta.AppendLine("		CargaViernes=(select case when (select PrimeraFecha from #TmpFechas where VendedorId = VEN.VendedorId and Fecha = DATEADD(d,-DATEPART(weekday,@fecha)+1,@fecha)) = dia.FechaCaptura then (SELECT CASE WHEN TRP.Tipo=2 THEN TPD.Cantidad * PDD.Factor WHEN TRP.Tipo=23 THEN TPD.Cantidad ELSE 0 END)else 0 end),")
        sConsulta.AppendLine("		ReclasificadoViernes=(SELECT CASE WHEN TRP.Tipo=22  and DATEADD(d,-DATEPART(weekday,@fecha)+1,@fecha) = dia.FechaCaptura THEN TPD.Cantidad * PDD.Factor ELSE 0 END),")
        sConsulta.AppendLine("")
        sConsulta.AppendLine("		DevolucionSabado=(SELECT CASE WHEN TRP.Tipo=7 and DATEADD(d,-DATEPART(weekday,@fecha)+2,@fecha) = dia.FechaCaptura THEN TPD.Cantidad * PDD.Factor ELSE 0 END),")
        sConsulta.AppendLine("		FrioSabado=(SELECT CASE WHEN TRP.Tipo=4  and DATEADD(d,-DATEPART(weekday,@fecha)+2,@fecha) = dia.FechaCaptura  THEN TPD.Cantidad * PDD.Factor ELSE 0 END),")
        sConsulta.AppendLine("		CargaSabado=(select case when (select PrimeraFecha from #TmpFechas where VendedorId = VEN.VendedorId and Fecha = DATEADD(d,-DATEPART(weekday,@fecha)+2,@fecha)) = dia.FechaCaptura then (SELECT CASE WHEN TRP.Tipo=2 THEN TPD.Cantidad * PDD.Factor WHEN TRP.Tipo=23 THEN TPD.Cantidad ELSE 0 END)else 0 end),")
        sConsulta.AppendLine("		ReclasificadoSabado=(SELECT CASE WHEN TRP.Tipo=22  and DATEADD(d,-DATEPART(weekday,@fecha)+2,@fecha) = dia.FechaCaptura THEN TPD.Cantidad * PDD.Factor ELSE 0 END),")
        sConsulta.AppendLine("")
        sConsulta.AppendLine("		DevolucionDomingo=(SELECT CASE WHEN TRP.Tipo=7 and DATEADD(d,-DATEPART(weekday,@fecha)+3,@fecha) = dia.FechaCaptura THEN TPD.Cantidad * PDD.Factor ELSE 0 END),")
        sConsulta.AppendLine("		FrioDomingo=(SELECT CASE WHEN TRP.Tipo=4  and DATEADD(d,-DATEPART(weekday,@fecha)+3,@fecha) =dia.FechaCaptura  THEN TPD.Cantidad * PDD.Factor ELSE 0 END),")
        sConsulta.AppendLine("		CargaDomingo=(select case when (select PrimeraFecha from #TmpFechas where VendedorId = VEN.VendedorId and Fecha = DATEADD(d,-DATEPART(weekday,@fecha)+3,@fecha)) = dia.FechaCaptura then (SELECT CASE WHEN TRP.Tipo=2 THEN TPD.Cantidad * PDD.Factor WHEN TRP.Tipo=23 THEN TPD.Cantidad ELSE 0 END)else 0 end),")
        sConsulta.AppendLine("		ReclasificadoDomingo=(SELECT CASE WHEN TRP.Tipo=22  and DATEADD(d,-DATEPART(weekday,@fecha)+3,@fecha) = dia.FechaCaptura THEN TPD.Cantidad * PDD.Factor ELSE 0 END),")
        sConsulta.AppendLine("")
        sConsulta.AppendLine("		DevolucionLunes=(SELECT CASE WHEN TRP.Tipo=7 and DATEADD(d,-DATEPART(weekday,@fecha)+4,@fecha) = dia.FechaCaptura THEN TPD.Cantidad * PDD.Factor ELSE 0 END),")
        sConsulta.AppendLine("		FrioLunes=(SELECT CASE WHEN TRP.Tipo=4  and DATEADD(d,-DATEPART(weekday,@fecha)+4,@fecha) = dia.FechaCaptura  THEN TPD.Cantidad * PDD.Factor ELSE 0 END),")
        sConsulta.AppendLine("		CargaLunes=(select case when (select PrimeraFecha from #TmpFechas where VendedorId = VEN.VendedorId and Fecha = DATEADD(d,-DATEPART(weekday,@fecha)+4,@fecha)) = dia.FechaCaptura then (SELECT CASE WHEN TRP.Tipo=2 THEN TPD.Cantidad * PDD.Factor WHEN TRP.Tipo=23 THEN TPD.Cantidad ELSE 0 END)else 0 end),")
        sConsulta.AppendLine("		ReclasificadoLunes=(SELECT CASE WHEN TRP.Tipo=22  and DATEADD(d,-DATEPART(weekday,@fecha)+4,@fecha) = dia.FechaCaptura THEN TPD.Cantidad * PDD.Factor ELSE 0 END),")
        sConsulta.AppendLine("")
        sConsulta.AppendLine("		DevolucionMartes=(SELECT CASE WHEN TRP.Tipo=7 and DATEADD(d,-DATEPART(weekday,@fecha)+5,@fecha) =dia.FechaCaptura THEN TPD.Cantidad * PDD.Factor ELSE 0 END),")
        sConsulta.AppendLine("		FrioMartes=(SELECT CASE WHEN TRP.Tipo=4  and DATEADD(d,-DATEPART(weekday,@fecha)+5,@fecha) = dia.FechaCaptura THEN TPD.Cantidad * PDD.Factor ELSE 0 END),")
        sConsulta.AppendLine("		CargaMartes=(select case when (select PrimeraFecha from #TmpFechas where VendedorId = VEN.VendedorId and Fecha = DATEADD(d,-DATEPART(weekday,@fecha)+5,@fecha)) = dia.FechaCaptura then (SELECT CASE WHEN TRP.Tipo=2 THEN TPD.Cantidad * PDD.Factor WHEN TRP.Tipo=23 THEN TPD.Cantidad ELSE 0 END)else 0 end),")
        sConsulta.AppendLine("		ReclasificadoMartes=(SELECT CASE WHEN TRP.Tipo=22  and DATEADD(d,-DATEPART(weekday,@fecha)+5,@fecha) = dia.FechaCaptura THEN TPD.Cantidad * PDD.Factor ELSE 0 END),")
        sConsulta.AppendLine("")
        sConsulta.AppendLine("		DevolucionMiercoles=(SELECT CASE WHEN TRP.Tipo=7 and DATEADD(d,-DATEPART(weekday,@fecha)+6,@fecha) = dia.FechaCaptura THEN TPD.Cantidad * PDD.Factor ELSE 0 END),")
        sConsulta.AppendLine("		FrioMiercoles=(SELECT CASE WHEN TRP.Tipo=4  and DATEADD(d,-DATEPART(weekday,@fecha)+6,@fecha) =dia.FechaCaptura  THEN TPD.Cantidad * PDD.Factor ELSE 0 END),")
        sConsulta.AppendLine("		CargaMiercoles=(select case when (select PrimeraFecha from #TmpFechas where VendedorId = VEN.VendedorId and Fecha = DATEADD(d,-DATEPART(weekday,@fecha)+6,@fecha)) = dia.FechaCaptura then (SELECT CASE WHEN TRP.Tipo=2 THEN TPD.Cantidad * PDD.Factor WHEN TRP.Tipo=23 THEN TPD.Cantidad ELSE 0 END)else 0 end),")
        sConsulta.AppendLine("		ReclasificadoMiercoles=(SELECT CASE WHEN TRP.Tipo=22  and DATEADD(d,-DATEPART(weekday,@fecha)+6,@fecha) = dia.FechaCaptura THEN TPD.Cantidad * PDD.Factor ELSE 0 END),")
        sConsulta.AppendLine("")
        sConsulta.AppendLine("		DevolucionJueves=(SELECT CASE WHEN TRP.Tipo=7 and DATEADD(d,-DATEPART(weekday,@fecha)+7,@fecha) =dia.FechaCaptura THEN TPD.Cantidad * PDD.Factor ELSE 0 END),")
        sConsulta.AppendLine("		FrioJueves=(SELECT CASE WHEN TRP.Tipo=4  and DATEADD(d,-DATEPART(weekday,@fecha)+7,@fecha) = dia.FechaCaptura  THEN TPD.Cantidad * PDD.Factor ELSE 0 END),")
        sConsulta.AppendLine("		CargaJueves=(select case when (select PrimeraFecha from #TmpFechas where VendedorId = VEN.VendedorId and Fecha = DATEADD(d,-DATEPART(weekday,@fecha)+7,@fecha)) = dia.FechaCaptura then (SELECT CASE WHEN TRP.Tipo=2 THEN TPD.Cantidad * PDD.Factor WHEN TRP.Tipo=23 THEN TPD.Cantidad ELSE 0 END)else 0 end),")
        sConsulta.AppendLine("		ReclasificadoJueves=(SELECT CASE WHEN TRP.Tipo=22  and DATEADD(d,-DATEPART(weekday,@fecha)+7,@fecha) = dia.FechaCaptura THEN TPD.Cantidad * PDD.Factor ELSE 0 END)")
        sConsulta.AppendLine("")
        sConsulta.AppendLine("		from TransProd TRP")
        sConsulta.AppendLine("      INNER JOIN TransProdDetalle as TPD ON TPD.TransProdId=TRP.TransProdId")
        sConsulta.AppendLine("      INNER JOIN dia on dia.diaclave =trp.diaclave ")
        sConsulta.AppendLine("      INNER JOIN Producto as PRD ON PRD.ProductoClave=TPD.ProductoClave AND PRD.Tipo<>5 ")
        sConsulta.AppendLine("      INNER JOIN ProductoDetalle as PDD ON PDD.ProductoClave=TPD.ProductoClave AND PDD.PRUTipoUnidad=TPD.TipoUnidad AND PDD.ProductoDetClave=TPD.ProductoClave ")
        sConsulta.AppendLine("      INNER JOIN Usuario as USU ON USU.USUId=TRP.MUsuarioId ")
        sConsulta.AppendLine("      INNER JOIN Vendedor as VEN ON VEN.USUId=TRP.MUsuarioId AND VEN.TipoEstado=1 AND VEN.Baja=0 ")
        sConsulta.AppendLine("      INNER JOIN (SELECT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor GROUP BY DiaClave, VendedorId, ClaveCEDI) as AGV ON AGV.DiaClave=TRP.DiaClave AND AGV.VendedorId=VEN.VendedorId ")
        sConsulta.AppendLine("      INNER JOIN Almacen as ALM ON ALM.Clave=AGV.ClaveCEDI ")
        sConsulta.AppendLine("      WHERE ((TRP.Tipo IN (7,4,23,22) and dia.FechaCaptura  between DATEADD(d,-DATEPART(weekday,@fecha)+1,@fecha) and DATEADD(d,7-DATEPART(weekday,@fecha),@fecha)) ")
        sConsulta.AppendLine("      or (TRP.Tipo = 2 and dia.FechaCaptura between isnull((select PrimeraFecha from #TmpFechas where VendedorId = VEN.VendedorId and Fecha = DATEADD(d,-DATEPART(weekday,@fecha)+1,@fecha)), DATEADD(d,-DATEPART(weekday,@fecha)+1,@fecha)) and DATEADD(d,7-DATEPART(weekday,@fecha),@fecha))) ")
        sConsulta.AppendLine("      and trp.TipoFase<>0  " & pvCondicion)
        sConsulta.AppendLine("")
        sConsulta.AppendLine(")as t1 ")
        sConsulta.AppendLine("group by Clave,nombre,viernes,jueves")
        sConsulta.AppendLine("set nocount off ")


        Dim dt As Data.DataTable
        Dim dInicio As Date = Now
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        Dim dFin As Date = Now
        Dim nSegs As Long = DateDiff(DateInterval.Second, dInicio, dFin)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        Return True
    End Function

    Private Function ConsultaInventarioDeProductoTerminadoPanque(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvFecha As Boolean) As Boolean
        Dim sConsulta As New StringBuilder

        pvCondicion = strWhereFecha(pvCondicion, " Dia.FechaCaptura ")
        pvCondicion = strWhereCentrosDistribucion(pvCondicion, " AGV.ClaveCEDI ")

        Dim sFecha As String()
        sFecha = txtFInicio.Text.Split("/")
        Dim dFechaIni As New Date(sFecha(2), sFecha(1), sFecha(0))
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF SET NOCOUNT ON ")
        sConsulta.AppendLine("if (select object_id('tempdb..#TmpProductoTerminado')) is not null drop table #TmpProductoTerminado ")
        sConsulta.AppendLine("select ProductoClave, sum(existenciaAnterior) as existenciaAnterior, sum(cargas) as cargas, sum(sobrantesProduccion) as sobrantesProduccion  ")
        sConsulta.AppendLine("INTO [#TmpProductoTerminado] from ( ")

        'Existencia Anterior 

        Dim validaCargaSugerida As New StringBuilder()
        validaCargaSugerida.AppendLine("select COUNT(*) ")
        validaCargaSugerida.AppendLine("from TransProd TRP ")
        validaCargaSugerida.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ")
        validaCargaSugerida.AppendLine("inner join Dia on TRP.DiaClave = Dia.DiaClave ")
        validaCargaSugerida.AppendLine("inner join ProductoDetalle PRO on TPD.ProductoClave = PRO.ProductoClave and TPD.TipoUnidad = PRO.PRUTipoUnidad  and PRO.productoDetClave =TPD.ProductoClave ")
        validaCargaSugerida.AppendLine("inner join (SELECT DiaClave, ClaveCEDI FROM AgendaVendedor GROUP BY DiaClave, ClaveCEDI) as AGV ON AGV.DiaClave=TRP.DiaClave ")
        validaCargaSugerida.AppendLine("WHERE '" & dFechaIni.Date.ToString("s") & "' = Dia.FechaCaptura " & strWhereCentrosDistribucion("", "AGV.ClaveCEDI ") & " and TRP.Tipo in(2) and TRP.TipoFase =1 and TipoMotivo = 9  ")

        If (Convert.ToInt32(ins.EjecutarComandoScalar(validaCargaSugerida.ToString())) > 0) Then
            sConsulta.AppendLine("select pro.productoclave, isnull(sum(tpd.cantidad*pro.factor),0) as ExistenciaAnterior, 0 as Cargas, 0 as SobrantesProduccion ")
            sConsulta.AppendLine("from TransProd TRP ")
            sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ")
            sConsulta.AppendLine("inner join Dia on TRP.DiaClave = Dia.DiaClave ")
            sConsulta.AppendLine("inner join ProductoDetalle PRO on TPD.ProductoClave = PRO.ProductoClave and TPD.TipoUnidad = PRO.PRUTipoUnidad  and PRO.productoDetClave =TPD.ProductoClave ")
            sConsulta.AppendLine("inner join (SELECT DiaClave, ClaveCEDI FROM AgendaVendedor GROUP BY DiaClave, ClaveCEDI) as AGV ON AGV.DiaClave=TRP.DiaClave ")
            sConsulta.AppendLine("WHERE '" & dFechaIni.Date.ToString("s") & "' = Dia.FechaCaptura " & strWhereCentrosDistribucion("", "AGV.ClaveCEDI ") & " and TRP.Tipo in(2) and TRP.TipoFase =1 and TipoMotivo = 9  ")
            sConsulta.AppendLine("group by pro.productoclave  ")
        Else
            sConsulta.AppendLine("select pro.productoclave, isnull(sum(tpd.cantidad*pro.factor),0) as ExistenciaAnterior, 0 as cargas, 0 as SobrantesProduccion  ")
            sConsulta.AppendLine("from TransProd TRP  ")
            sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId  ")
            sConsulta.AppendLine("INNER JOIN ProductoDetalle PRO on TPD.ProductoClave = PRO.ProductoClave and TPD.TipoUnidad = PRO.PRUTipoUnidad 	and PRO.productoDetClave =TPD.ProductoClave ")
            sConsulta.AppendLine("inner join (SELECT DiaClave, ClaveCEDI FROM AgendaVendedor GROUP BY DiaClave, ClaveCEDI) as AGV ON AGV.DiaClave=TRP.DiaClave  ")
            sConsulta.AppendLine("inner join Dia on Dia.Diaclave=trp.diaclave ")
            sConsulta.AppendLine("where TRP.Tipo in(7) and TRP.TipoFase =1  " & strWhereCentrosDistribucion("", "AGV.ClaveCEDI ") & " ")
            sConsulta.AppendLine("and (SELECT MAX(convert(datetime,DIA.FechaCaptura,103)) ")
            sConsulta.AppendLine("from AgendaVendedor AGV  ")
            sConsulta.AppendLine("inner join Dia on AGV.DiaClave = Dia.DiaClave  ")
            sConsulta.AppendLine("WHERE '" & dFechaIni.Date.ToString("s") & "' > Dia.FechaCaptura) = dia.fechacaptura ")
            sConsulta.AppendLine("group by pro.productoclave ")
        End If

        'Cargas 
        sConsulta.AppendLine("union ")
        sConsulta.AppendLine("select pro.productoclave, 0 as ExistenciaAnterior, isnull(sum(tpd.cantidad*pro.factor),0) as Cargas, 0 as SobrantesProduccion ")
        sConsulta.AppendLine("from TransProd TRP ")
        sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ")
        sConsulta.AppendLine("inner join Dia on TRP.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("inner join ProductoDetalle PRO on TPD.ProductoClave = PRO.ProductoClave and TPD.TipoUnidad = PRO.PRUTipoUnidad  and PRO.productoDetClave =TPD.ProductoClave ")
        sConsulta.AppendLine("inner join (SELECT DiaClave, ClaveCEDI FROM AgendaVendedor GROUP BY DiaClave, ClaveCEDI) as AGV ON AGV.DiaClave=TRP.DiaClave ")
        sConsulta.AppendLine("WHERE '" & dFechaIni.Date.ToString("s") & "' = Dia.FechaCaptura " & strWhereCentrosDistribucion("", "AGV.ClaveCEDI ") & " and TRP.Tipo in(2) and TRP.TipoFase =1 and TipoMotivo <> 9  ")
        sConsulta.AppendLine("group by pro.productoclave  ")

        'Sobrante de Producción
        sConsulta.AppendLine("union ")
        sConsulta.AppendLine("select pro.productoclave, 0 as ExistenciaAnterior, 0 as Cargas, isnull(sum(tpd.cantidad*pro.factor),0) as SobrantesProduccion ")
        sConsulta.AppendLine("from TransProd TRP ")
        sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ")
        sConsulta.AppendLine("inner join ProductoDetalle PRO on TPD.ProductoClave = PRO.ProductoClave  and TPD.TipoUnidad = PRO.PRUTipoUnidad  and PRO.productoDetClave =TPD.ProductoClave ")
        sConsulta.AppendLine("where TRP.Tipo in(25) and TRP.TipoFase =1 and '" & dFechaIni.Date.ToString("s") & "' = TRP.FechaHoraAlta " & strWhereCentrosDistribucion("", "TRP.notas") & " ")
        sConsulta.AppendLine("group by pro.productoclave ) as t group by ProductoClave ")

        sConsulta.AppendLine("select TPD.ProductoClave as clave, PRO.Nombre as producto, TPD.ExistenciaAnterior, TPD.Cargas, TPD.SobrantesProduccion as sobranteProduccion, ")
        sConsulta.AppendLine("(TPD.ExistenciaAnterior+ TPD.Cargas+ TPD.SobrantesProduccion) as ExistenciaTotal,  ")
        sConsulta.AppendLine("(select top 1 precio from precioProductoVig PPV  ")
        sConsulta.AppendLine("where PPV.ProductoClave = TPD.ProductoClave and PrecioClave='LISTA01' ")
        sConsulta.AppendLine("and ('" & dFechaIni.Date.ToString("s") & "' >= PPV.PPVFechaInicio and '" & dFechaIni.Date.ToString("s") & "' <=ppv.FechaFin  and PPV.TipoEstado=1 ) order by PRUTipoUnidad) as precioUnitario, ")
        sConsulta.AppendLine("((TPD.ExistenciaAnterior+ TPD.Cargas+ TPD.SobrantesProduccion) * (select top 1 precio from precioProductoVig PPV  ")
        sConsulta.AppendLine("where PPV.ProductoClave = TPD.ProductoClave and PrecioClave='LISTA01' ")
        sConsulta.AppendLine("and ('" & dFechaIni.Date.ToString("s") & "' >= PPV.PPVFechaInicio and '" & dFechaIni.Date.ToString("s") & "' <=ppv.FechaFin and PPV.TipoEstado=1 ) order by PRUTipoUnidad )) as Importe ")
        sConsulta.AppendLine("from #TmpProductoTerminado as TPD ")
        sConsulta.AppendLine("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ")
        sConsulta.AppendLine("drop table #TmpProductoTerminado ")
        sConsulta.AppendLine("SET NOCOUNT OFF")

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt
        Return True

    End Function

    Private Function ConsultaResumenVentasRutaVendedor(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String) As Boolean
        Dim sConsulta As New StringBuilder
        Dim sCondConsignacion As String = ""
        Dim sFecha1 As String = ""
        Dim sFecha2 As String = ""
        If ChBoxCentroDistribucion.Checked Then
            pvCondicion = strWhereCentrosDistribucion(pvCondicion, " AGV.ClaveCEDI ")
        End If
        sCondConsignacion = pvCondicion

        If chboxFecha.Checked Then
            pvCondicion = strWhereFecha(pvCondicion, " Dia.FechaCaptura ")
            sFecha1 = strWhereFecha("", "Dia.FechaCaptura").Remove(0, 4)
            sFecha2 = strWhereFecha("", "TRP.FechaFacturacion").Remove(0, 4)
        End If

        sConsulta = New StringBuilder
        sConsulta.AppendLine("select distinct AGV.ClaveCEDI, T1.RutClave, T1.VendedorID, VEN.Nombre, ALM.Nombre as ALMNombre from ( ")
        sConsulta.AppendLine("select distinct VIS.VendedorId, VIS.DiaClave, VIS.RutClave ")
        sConsulta.AppendLine("from Visita VIS ")
        sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave and ((TRP.Tipo = 1 and TRP.TipoFase <> 0) or (TRP.Tipo = 24 and TRP.TipoFase = 6)) ")
        sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        If chboxFecha.Checked Then
            sConsulta.AppendLine("where ((TRP.Tipo = 1 and " & sFecha1 & " ) or (TRP.Tipo = 24 and " & sFecha2 & " ))")
        End If
        sConsulta.AppendLine("union ")
        sConsulta.AppendLine("select distinct VIS.VendedorId, VIS.DiaClave, VIS.RutClave ")
        sConsulta.AppendLine("from Visita VIS ")
        sConsulta.AppendLine("inner join Abono ABN on ABN.VisitaClave = VIS.VisitaClave and ABN.DiaClave = VIS.DiaClave ")
        sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        If chboxFecha.Checked Then
            sConsulta.AppendLine("where " & sFecha1 & " ")
        End If
        sConsulta.AppendLine(") as T1 ")
        sConsulta.AppendLine("inner join Vendedor VEN on T1.VendedorId = VEN.VendedorId ")
        sConsulta.AppendLine("inner join Dia on T1.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("inner join (select distinct VendedorId, DiaClave, ClaveCEDI from AgendaVendedor) AGV on T1.VendedorId = AGV.VendedorId and T1.DiaClave = AGV.DiaClave ")
        sConsulta.AppendLine("inner join Almacen ALM on AGV.ClaveCEDI = ALM.Clave ")
        sConsulta.AppendLine(sCondConsignacion)
        sConsulta.AppendLine("order by AGV.ClaveCEDI, T1.RutClave, T1.VendedorID ")
        Dim dtVendedores As Data.DataTable
        dtVendedores = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dtVendedores.Rows.Count = 0 Then
            Return False
        End If
        dtVendedores.TableName = "RutaVendedor"
        Session("RutaVendedor") = dtVendedores

        sConsulta = New StringBuilder
        sConsulta.AppendLine("select AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId, TPD.ProductoClave, PRO.Nombre, PRO.Contenido, case when TPD.Promocion <> 2 then 0 else 1 end as Promocion, ")
        sConsulta.AppendLine("sum( case when TRP.Tipo = 1 then TPD.Cantidad * PRD.Factor else (TPD.Cantidad - isnull(TTP.Cantidad, 0)) * PRD.Factor end ) as Cantidad ")
        sConsulta.AppendLine("from TransProd TRP ")
        sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ")
        sConsulta.AppendLine("left join TrpTpd TTP on TPD.TransProdId = TTP.TransProdId1 and TPD.TransProdDetalleId = TTP.TransProdDetalleId ")
        sConsulta.AppendLine("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ")
        sConsulta.AppendLine("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ")
        sConsulta.AppendLine("inner join ProductoDetalle PRD on TPD.ProductoClave = PRD.ProductoClave and PRD.ProductoClave = PRD.ProductoDetClave and TPD.TipoUnidad = PRD.PRUTipoUnidad ")
        sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("inner join (select distinct VendedorId, DiaClave, ClaveCEDI from AgendaVendedor) AGV on VIS.VendedorId = AGV.VendedorId and VIS.DiaClave = AGV.DiaClave ")
        sConsulta.AppendLine(sCondConsignacion)
        If chboxFecha.Checked Then
            sConsulta.AppendLine("and ((TRP.Tipo = 1 and " & sFecha1 & " ) or (TRP.Tipo = 24 and " & sFecha2 & " ))")
        End If
        sConsulta.AppendLine("and ((TRP.Tipo = 1 and TRP.TipoFase <> 0) or (TRP.Tipo = 24 and TRP.TipoFase = 6)) ")
        sConsulta.AppendLine("group by AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId, TPD.ProductoClave, PRO.Nombre, PRO.Contenido, case when TPD.Promocion <> 2 then 0 else 1 end ")
        sConsulta.AppendLine("order by AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId, TPD.ProductoClave ")
        Session("Productos") = sConsulta.ToString

        sConsulta = New StringBuilder
        sConsulta.AppendLine("select distinct AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId, PRE.EsquemaId, ESQ.Nombre, ")
        sConsulta.AppendLine("sum( case when TRP.Tipo = 1 then TPD.Cantidad * PRD.Factor else (TPD.Cantidad - isnull(TTP.Cantidad, 0)) * PRD.Factor end ) as Cantidad ")
        sConsulta.AppendLine("from TransProd TRP ")
        sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ")
        sConsulta.AppendLine("left join TrpTpd TTP on TPD.TransProdId = TTP.TransProdId1 and TPD.TransProdDetalleId = TTP.TransProdDetalleId ")
        sConsulta.AppendLine("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ")
        sConsulta.AppendLine("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave and PRO.Contenido = 1 ")
        sConsulta.AppendLine("inner join ProductoEsquema PRE on TPD.ProductoClave = PRE.ProductoClave ")
        sConsulta.AppendLine("inner join Esquema ESQ on PRE.EsquemaId = ESQ.EsquemaId ")
        sConsulta.AppendLine("inner join ProductoDetalle PRD on TPD.ProductoClave = PRD.ProductoClave and PRD.ProductoClave = PRD.ProductoDetClave and TPD.TipoUnidad = PRD.PRUTipoUnidad ")
        sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("inner join (select distinct VendedorId, DiaClave, ClaveCEDI from AgendaVendedor) AGV on VIS.VendedorId = AGV.VendedorId and VIS.DiaClave = AGV.DiaClave ")
        sConsulta.AppendLine(sCondConsignacion)
        If chboxFecha.Checked Then
            sConsulta.AppendLine("and ((TRP.Tipo = 1 and " & sFecha1 & " ) or (TRP.Tipo = 24 and " & sFecha2 & " ))")
        End If
        sConsulta.AppendLine("and ((TRP.Tipo = 1 and TRP.TipoFase <> 0) or (TRP.Tipo = 24 and TRP.TipoFase = 6)) and TPD.Promocion <> 2 ")
        sConsulta.AppendLine("group by AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId, PRE.EsquemaId, ESQ.Nombre ")
        sConsulta.AppendLine("order by AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId ")
        Session("Esquemas") = sConsulta.ToString

        sConsulta = New StringBuilder
        sConsulta.AppendLine("select AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId, ")
        sConsulta.AppendLine("sum (case when TRP.Tipo = 3 then TPD.Cantidad * PRD.Factor else 0 end) as CantidadDev, ")
        sConsulta.AppendLine("sum (case TRP.Tipo when 1 then TPD.Cantidad * PRD.Factor when 24 then (TPD.Cantidad - isnull(TTP.Cantidad, 0)) * PRD.Factor else 0 end) as CantidadVta ")
        sConsulta.AppendLine("from TransProd TRP ")
        sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ")
        sConsulta.AppendLine("left join TrpTpd TTP on TPD.TransProdId = TTP.TransProdId1 and TPD.TransProdDetalleId = TTP.TransProdDetalleId ")
        sConsulta.AppendLine("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ")
        sConsulta.AppendLine("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave and PRO.Contenido = 1 ")
        sConsulta.AppendLine("inner join ProductoDetalle PRD on TPD.ProductoClave = PRD.ProductoClave and PRD.ProductoClave = PRD.ProductoDetClave and TPD.TipoUnidad = PRD.PRUTipoUnidad ")
        sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("inner join (select distinct VendedorId, DiaClave, ClaveCEDI from AgendaVendedor) AGV on VIS.VendedorId = AGV.VendedorId and VIS.DiaClave = AGV.DiaClave ")
        sConsulta.AppendLine(sCondConsignacion)
        If chboxFecha.Checked Then
            sConsulta.AppendLine("and ((TRP.Tipo in (1,3) and " & sFecha1 & " ) or (TRP.Tipo = 24 and " & sFecha2 & " ))")
        End If
        sConsulta.AppendLine("and ((TRP.Tipo in (1, 3) and TRP.TipoFase <> 0) or (TRP.Tipo = 24 and TRP.TipoFase = 6))  and (TPD.Promocion <> 2 or TPD.Promocion is null) ")
        sConsulta.AppendLine("group by AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId ")
        sConsulta.AppendLine("order by AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId ")
        Session("Contenidos") = sConsulta.ToString

        sConsulta = New StringBuilder
        sConsulta.AppendLine("select ClaveCEDI, RUTClave, VendedorId, sum(Venta) as Venta, sum(DescProducto + DescCliente + DescVendedor) as Descuento, ")
        sConsulta.AppendLine("sum(DescProducto + DescCliente + DescVendedor) / sum(Venta) * 100 as PorcentajeDescuento, ")
        sConsulta.AppendLine("sum(Venta) - sum(DescProducto + DescCliente + DescVendedor) as SubTotal, ")
        sConsulta.AppendLine("sum(VentaCredito) as VentaCredito ")
        sConsulta.AppendLine("from ( ")
        sConsulta.AppendLine("select AGV.ClaveCEDI, VIS.VendedorId, VIS.RUTClave, ")
        sConsulta.AppendLine("case when TRP.Tipo = 1 then TRP.Total else TRP.Total - (select sum(Total) from TrpTpd where TRP.TransProdId = TrpTpd.TransProdId1) end as Venta, ")
        sConsulta.AppendLine("isnull((select sum(isnull(TPD.DescuentoImp, 0)) from TransProdDetalle TPD where TPD.TransProdId = TRP.TransProdId), 0) as DescProducto, ")
        sConsulta.AppendLine("TRP.DescuentoImp as DescCliente, TRP.DescuentoVendedor as DescVendedor, ")
        sConsulta.AppendLine("case when TRP.CFVTipo = 2 then TRP.Total else 0 end as VentaCredito ")
        sConsulta.AppendLine("from TransProd TRP ")
        sConsulta.AppendLine("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
        sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("inner join (select distinct VendedorId, DiaClave, ClaveCEDI from AgendaVendedor) AGV on VIS.VendedorId = AGV.VendedorId and VIS.DiaClave = AGV.DiaClave ")
        sConsulta.AppendLine(sCondConsignacion)
        If chboxFecha.Checked Then
            sConsulta.AppendLine("and ((TRP.Tipo = 1 and " & sFecha1 & " ) or (TRP.Tipo = 24 and " & sFecha2 & " ))")
        End If
        sConsulta.AppendLine("and ((TRP.Tipo = 1 and TRP.TipoFase <> 0) or (TRP.Tipo = 24 and TRP.TipoFase = 6)) ")
        sConsulta.AppendLine(")as t1 ")
        sConsulta.AppendLine("group by ClaveCEDI, RUTClave, VendedorId ")
        sConsulta.AppendLine("order by ClaveCEDI, RUTClave, VendedorId ")
        Session("Totales") = sConsulta.ToString

        sConsulta = New StringBuilder
        sConsulta.AppendLine("select AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId, sum(ABT.Importe) as AbonoCredito ")
        sConsulta.AppendLine("from AbnTrp ABT ")
        sConsulta.AppendLine("inner join Abono ABN on ABT.ABNId = ABN.ABNId ")
        sConsulta.AppendLine("inner join Visita VIS on ABN.VisitaClave = VIS.VisitaClave and ABN.DiaClave = VIS.DiaClave ")
        sConsulta.AppendLine("inner join TransProd TRP on ABT.TransProdId = TRP.TransProdId and TRP.CFVTipo = 2 ")
        sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("inner join (select distinct VendedorId, DiaClave, ClaveCEDI from AgendaVendedor) AGV on VIS.VendedorId = AGV.VendedorId and VIS.DiaClave = AGV.DiaClave ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine("group by AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId ")
        sConsulta.AppendLine("order by AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId ")
        Session("AbonoCredito") = sConsulta.ToString

        sConsulta = New StringBuilder
        sConsulta.AppendLine("select AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId, sum(ABN.Total) as AbonoTotal ")
        sConsulta.AppendLine("from Abono ABN ")
        sConsulta.AppendLine("inner join Visita VIS on ABN.VisitaClave = VIS.VisitaClave and ABN.DiaClave = VIS.DiaClave ")
        sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("inner join (select distinct VendedorId, DiaClave, ClaveCEDI from AgendaVendedor) AGV on VIS.VendedorId = AGV.VendedorId and VIS.DiaClave = AGV.DiaClave ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine("group by AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId ")
        sConsulta.AppendLine("order by AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId ")
        Session("AbonoTotal") = sConsulta.ToString

        sConsulta = New StringBuilder
        sConsulta.AppendLine("select distinct AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId, TRP.PCEPrecioClave ")
        sConsulta.AppendLine("from TransProd TRP ")
        sConsulta.AppendLine("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ")
        sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("inner join (select distinct VendedorId, DiaClave, ClaveCEDI from AgendaVendedor) AGV on VIS.VendedorId = AGV.VendedorId and VIS.DiaClave = AGV.DiaClave ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine("and TRP.Tipo = 1 and TRP.TipoFase = 0 ")
        sConsulta.AppendLine("order by AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId ")
        Session("ListaPrecios") = sConsulta.ToString

        Return True
    End Function

    Private Function ConsultaResumenVentasCliente(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvEsquemaId As String) As Boolean
        Dim sConsulta As New StringBuilder
        Dim sCondicion As String = ""
        Dim sCondConsignacion As String = ""
        Dim sFecha1 As String = ""
        Dim sFecha2 As String = ""
        Dim sEsquemas As String = ""

        If pvEsquemaId <> "" Then
            Dim aEsquemas As ArrayList = New ArrayList
            aEsquemas.Add(pvEsquemaId)
            BuscarEsquemasHijos(ins, pvEsquemaId, aEsquemas)
            For Each sEsquemaId As String In aEsquemas
                sEsquemas &= "'" & sEsquemaId & "',"
            Next
            If sEsquemas.Length > 0 Then sEsquemas = Left(sEsquemas, sEsquemas.Length - 1)
        End If

        If ChBoxCentroDistribucion.Checked Then
            pvCondicion = strWhereCentrosDistribucion(pvCondicion, " AGV.ClaveCEDI ")
        End If
        sCondicion = pvCondicion
        If chboxRuta.Checked Then
            sCondicion = strWhereRutas(sCondicion, pvRutas, "T1.RutClave")
            pvCondicion = strWhereRutas(pvCondicion, pvRutas, "VIS.RutClave")
        End If
        pvCondicion = pvCondicion.Replace("VEN.", "VIS.")
        sCondConsignacion = pvCondicion
        If chboxFecha.Checked Then
            pvCondicion = strWhereFecha(pvCondicion, " Dia.FechaCaptura ")
            sFecha1 = strWhereFecha("", "Dia.FechaCaptura").Remove(0, 4)
            sFecha2 = strWhereFecha("", "TRP.FechaFacturacion").Remove(0, 4)
        End If
        If sEsquemas <> "" Then
            sCondicion &= " and CEE.EsquemaId in (" & sEsquemas & ") "
            pvCondicion &= " and CEE.EsquemaId in (" & sEsquemas & ") "
            sCondConsignacion &= " and CEE.EsquemaId in (" & sEsquemas & ") "
        End If


        sConsulta = New StringBuilder
        sConsulta.AppendLine("select distinct AGV.ClaveCEDI, ALM.Nombre as ALMNombre, T1.RutClave, T1.VendedorID, VEN.Nombre as VENNombre, T1.ClienteClave, CLI.Clave as CLIClave, CLI.RazonSocial as CLINombre from ( ")
        sConsulta.AppendLine("select distinct VIS.RutClave, VIS.VendedorId, VIS.DiaClave, VIS.ClienteClave ")
        sConsulta.AppendLine("from Visita VIS ")
        sConsulta.AppendLine("inner join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave and ((TRP.Tipo = 1 and TRP.TipoFase <> 0) or (TRP.Tipo = 24 and TRP.TipoFase = 6)) ")
        sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        If chboxFecha.Checked Then
            sConsulta.AppendLine("where ((TRP.Tipo = 1 and " & sFecha1 & " ) or (TRP.Tipo = 24 and " & sFecha2 & " ))")
        End If
        sConsulta.AppendLine("union ")
        sConsulta.AppendLine("select distinct VIS.RutClave, VIS.VendedorId, VIS.DiaClave, VIS.ClienteClave ")
        sConsulta.AppendLine("from Visita VIS ")
        sConsulta.AppendLine("inner join Abono ABN on ABN.VisitaClave = VIS.VisitaClave and ABN.DiaClave = VIS.DiaClave ")
        sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        If chboxFecha.Checked Then
            sConsulta.AppendLine("where " & sFecha1 & " ")
        End If
        sConsulta.AppendLine(") as T1 ")
        sConsulta.AppendLine("inner join Vendedor VEN on T1.VendedorId = VEN.VendedorId ")
        sConsulta.AppendLine("inner join Dia on T1.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("inner join (select distinct VendedorId, DiaClave, ClaveCEDI from AgendaVendedor) AGV on T1.VendedorId = AGV.VendedorId and T1.DiaClave = AGV.DiaClave ")
        sConsulta.AppendLine("inner join Almacen ALM on AGV.ClaveCEDI = ALM.Clave ")
        sConsulta.AppendLine("inner join Cliente CLI on T1.ClienteClave = CLI.ClienteClave ")
        sConsulta.AppendLine("inner join ClienteEsquema CEE on CLI.ClienteClave = CEE.ClienteClave and CEE.TipoEstado = 1 ")
        sConsulta.AppendLine(sCondicion)
        sConsulta.AppendLine("order by AGV.ClaveCEDI, T1.RutClave, VEN.Nombre, CLI.Clave ")
        Dim dtVendedores As Data.DataTable
        dtVendedores = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dtVendedores.Rows.Count = 0 Then
            Return False
        End If
        dtVendedores.TableName = "RutaVendedor"
        Session("RutaVendedor") = dtVendedores

        sConsulta = New StringBuilder
        sConsulta.AppendLine("select AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId, VIS.ClienteClave, TPD.ProductoClave, PRO.Nombre, PRO.Contenido, case when TPD.Promocion <> 2 then 0 else 1 end as Promocion, ")
        sConsulta.AppendLine("sum( case when TRP.Tipo = 1 then TPD.Cantidad * PRD.Factor else (TPD.Cantidad - isnull(TTP.Cantidad, 0)) * PRD.Factor end ) as Cantidad ")
        sConsulta.AppendLine("from TransProd TRP ")
        sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ")
        sConsulta.AppendLine("left join TrpTpd TTP on TPD.TransProdId = TTP.TransProdId1 and TPD.TransProdDetalleId = TTP.TransProdDetalleId ")
        sConsulta.AppendLine("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ")
        sConsulta.AppendLine("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ")
        sConsulta.AppendLine("inner join ProductoDetalle PRD on TPD.ProductoClave = PRD.ProductoClave and PRD.ProductoClave = PRD.ProductoDetClave and TPD.TipoUnidad = PRD.PRUTipoUnidad ")
        sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("inner join (select distinct VendedorId, DiaClave, ClaveCEDI from AgendaVendedor) AGV on VIS.VendedorId = AGV.VendedorId and VIS.DiaClave = AGV.DiaClave ")
        sConsulta.AppendLine("inner join ClienteEsquema CEE on VIS.ClienteClave = CEE.ClienteClave and CEE.TipoEstado = 1 ")
        sConsulta.AppendLine(sCondConsignacion)
        If chboxFecha.Checked Then
            sConsulta.AppendLine("and ((TRP.Tipo = 1 and " & sFecha1 & " ) or (TRP.Tipo = 24 and " & sFecha2 & " ))")
        End If
        sConsulta.AppendLine("and ((TRP.Tipo = 1 and TRP.TipoFase <> 0) or (TRP.Tipo = 24 and TRP.TipoFase = 6)) ")
        sConsulta.AppendLine("group by AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId, VIS.ClienteClave, TPD.ProductoClave, PRO.Nombre, PRO.Contenido, case when TPD.Promocion <> 2 then 0 else 1 end ")
        sConsulta.AppendLine("order by AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId, VIS.ClienteClave, TPD.ProductoClave ")
        Session("Productos") = sConsulta.ToString

        sConsulta = New StringBuilder
        sConsulta.AppendLine("select distinct AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId, VIS.ClienteClave, PRE.EsquemaId, ESQ.Nombre, ")
        sConsulta.AppendLine("sum( case when TRP.Tipo = 1 then TPD.Cantidad * PRD.Factor else (TPD.Cantidad - isnull(TTP.Cantidad, 0)) * PRD.Factor end ) as Cantidad ")
        sConsulta.AppendLine("from TransProd TRP ")
        sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ")
        sConsulta.AppendLine("left join TrpTpd TTP on TPD.TransProdId = TTP.TransProdId1 and TPD.TransProdDetalleId = TTP.TransProdDetalleId ")
        sConsulta.AppendLine("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ")
        sConsulta.AppendLine("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave and PRO.Contenido = 1 ")
        sConsulta.AppendLine("inner join ProductoEsquema PRE on TPD.ProductoClave = PRE.ProductoClave ")
        sConsulta.AppendLine("inner join Esquema ESQ on PRE.EsquemaId = ESQ.EsquemaId ")
        sConsulta.AppendLine("inner join ProductoDetalle PRD on TPD.ProductoClave = PRD.ProductoClave and PRD.ProductoClave = PRD.ProductoDetClave and TPD.TipoUnidad = PRD.PRUTipoUnidad ")
        sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("inner join (select distinct VendedorId, DiaClave, ClaveCEDI from AgendaVendedor) AGV on VIS.VendedorId = AGV.VendedorId and VIS.DiaClave = AGV.DiaClave ")
        sConsulta.AppendLine("inner join ClienteEsquema CEE on VIS.ClienteClave = CEE.ClienteClave and CEE.TipoEstado = 1 ")
        sConsulta.AppendLine(sCondConsignacion)
        If chboxFecha.Checked Then
            sConsulta.AppendLine("and ((TRP.Tipo = 1 and " & sFecha1 & " ) or (TRP.Tipo = 24 and " & sFecha2 & " ))")
        End If
        sConsulta.AppendLine("and ((TRP.Tipo = 1 and TRP.TipoFase <> 0) or (TRP.Tipo = 24 and TRP.TipoFase = 6)) and TPD.Promocion <> 2 ")
        sConsulta.AppendLine("group by AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId, VIS.ClienteClave, PRE.EsquemaId, ESQ.Nombre ")
        sConsulta.AppendLine("order by AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId, VIS.ClienteClave ")
        Session("Esquemas") = sConsulta.ToString

        sConsulta = New StringBuilder
        sConsulta.AppendLine("select AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId, VIS.ClienteClave, ")
        sConsulta.AppendLine("sum (case when TRP.Tipo = 3 then TPD.Cantidad * PRD.Factor else 0 end) as CantidadDev, ")
        sConsulta.AppendLine("sum (case TRP.Tipo when 1 then TPD.Cantidad * PRD.Factor when 24 then (TPD.Cantidad - isnull(TTP.Cantidad, 0)) * PRD.Factor else 0 end) as CantidadVta ")
        sConsulta.AppendLine("from TransProd TRP ")
        sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ")
        sConsulta.AppendLine("left join TrpTpd TTP on TPD.TransProdId = TTP.TransProdId1 and TPD.TransProdDetalleId = TTP.TransProdDetalleId ")
        sConsulta.AppendLine("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ")
        sConsulta.AppendLine("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave and PRO.Contenido = 1 ")
        sConsulta.AppendLine("inner join ProductoDetalle PRD on TPD.ProductoClave = PRD.ProductoClave and PRD.ProductoClave = PRD.ProductoDetClave and TPD.TipoUnidad = PRD.PRUTipoUnidad ")
        sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("inner join (select distinct VendedorId, DiaClave, ClaveCEDI from AgendaVendedor) AGV on VIS.VendedorId = AGV.VendedorId and VIS.DiaClave = AGV.DiaClave ")
        sConsulta.AppendLine("inner join ClienteEsquema CEE on VIS.ClienteClave = CEE.ClienteClave and CEE.TipoEstado = 1 ")
        sConsulta.AppendLine(sCondConsignacion)
        If chboxFecha.Checked Then
            sConsulta.AppendLine("and ((TRP.Tipo in (1,3) and " & sFecha1 & " ) or (TRP.Tipo = 24 and " & sFecha2 & " ))")
        End If
        sConsulta.AppendLine("and ((TRP.Tipo in (1, 3) and TRP.TipoFase <> 0) or (TRP.Tipo = 24 and TRP.TipoFase = 6))  and (TPD.Promocion <> 2 or TPD.Promocion is null) ")
        sConsulta.AppendLine("group by AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId, VIS.ClienteClave ")
        sConsulta.AppendLine("order by AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId, VIS.ClienteClave ")
        Session("Contenidos") = sConsulta.ToString

        sConsulta = New StringBuilder
        sConsulta.AppendLine("select ClaveCEDI, RUTClave, VendedorId, ClienteClave, sum(Venta) as Venta, sum(DescProducto + DescCliente + DescVendedor) as Descuento, ")
        sConsulta.AppendLine("sum(DescProducto + DescCliente + DescVendedor) / sum(Venta) * 100 as PorcentajeDescuento, ")
        sConsulta.AppendLine("sum(Venta) - sum(DescProducto + DescCliente + DescVendedor) as SubTotal, ")
        sConsulta.AppendLine("sum(VentaCredito) as VentaCredito ")
        sConsulta.AppendLine("from ( ")
        sConsulta.AppendLine("select AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId, VIS.ClienteClave, ")
        sConsulta.AppendLine("case when TRP.Tipo = 1 then TRP.Total else TRP.Total - (select sum(Total) from TrpTpd where TRP.TransProdId = TrpTpd.TransProdId1) end as Venta, ")
        sConsulta.AppendLine("isnull((select sum(isnull(TPD.DescuentoImp, 0)) from TransProdDetalle TPD where TPD.TransProdId = TRP.TransProdId), 0) as DescProducto, ")
        sConsulta.AppendLine("TRP.DescuentoImp as DescCliente, TRP.DescuentoVendedor as DescVendedor, ")
        sConsulta.AppendLine("case when TRP.CFVTipo = 2 then TRP.Total else 0 end as VentaCredito ")
        sConsulta.AppendLine("from TransProd TRP ")
        sConsulta.AppendLine("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId ")
        sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("inner join (select distinct VendedorId, DiaClave, ClaveCEDI from AgendaVendedor) AGV on VIS.VendedorId = AGV.VendedorId and VIS.DiaClave = AGV.DiaClave ")
        sConsulta.AppendLine("inner join ClienteEsquema CEE on VIS.ClienteClave = CEE.ClienteClave and CEE.TipoEstado = 1 ")
        sConsulta.AppendLine(sCondConsignacion)
        If chboxFecha.Checked Then
            sConsulta.AppendLine("and ((TRP.Tipo = 1 and " & sFecha1 & " ) or (TRP.Tipo = 24 and " & sFecha2 & " ))")
        End If
        sConsulta.AppendLine("and ((TRP.Tipo = 1 and TRP.TipoFase <> 0) or (TRP.Tipo = 24 and TRP.TipoFase = 6)) ")
        sConsulta.AppendLine(")as t1 ")
        sConsulta.AppendLine("group by ClaveCEDI, RUTClave, VendedorId, ClienteClave ")
        sConsulta.AppendLine("order by ClaveCEDI, RUTClave, VendedorId, ClienteClave ")
        Session("Totales") = sConsulta.ToString

        sConsulta = New StringBuilder
        sConsulta.AppendLine("select AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId, VIS.ClienteClave, sum(ABT.Importe) as AbonoCredito ")
        sConsulta.AppendLine("from AbnTrp ABT ")
        sConsulta.AppendLine("inner join Abono ABN on ABT.ABNId = ABN.ABNId ")
        sConsulta.AppendLine("inner join Visita VIS on ABN.VisitaClave = VIS.VisitaClave and ABN.DiaClave = VIS.DiaClave ")
        sConsulta.AppendLine("inner join TransProd TRP on ABT.TransProdId = TRP.TransProdId and TRP.CFVTipo = 2 ")
        sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("inner join (select distinct VendedorId, DiaClave, ClaveCEDI from AgendaVendedor) AGV on VIS.VendedorId = AGV.VendedorId and VIS.DiaClave = AGV.DiaClave ")
        sConsulta.AppendLine("inner join ClienteEsquema CEE on VIS.ClienteClave = CEE.ClienteClave and CEE.TipoEstado = 1 ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine("group by AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId, VIS.ClienteClave ")
        sConsulta.AppendLine("order by AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId, VIS.ClienteClave ")
        Session("AbonoCredito") = sConsulta.ToString

        sConsulta = New StringBuilder
        sConsulta.AppendLine("select AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId, VIS.ClienteClave, sum(ABN.Total) as AbonoTotal ")
        sConsulta.AppendLine("from Abono ABN ")
        sConsulta.AppendLine("inner join Visita VIS on ABN.VisitaClave = VIS.VisitaClave and ABN.DiaClave = VIS.DiaClave ")
        sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("inner join (select distinct VendedorId, DiaClave, ClaveCEDI from AgendaVendedor) AGV on VIS.VendedorId = AGV.VendedorId and VIS.DiaClave = AGV.DiaClave ")
        sConsulta.AppendLine("inner join ClienteEsquema CEE on VIS.ClienteClave = CEE.ClienteClave and CEE.TipoEstado = 1 ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine("group by AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId, VIS.ClienteClave ")
        sConsulta.AppendLine("order by AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId, VIS.ClienteClave ")
        Session("AbonoTotal") = sConsulta.ToString

        sConsulta = New StringBuilder
        sConsulta.AppendLine("select distinct AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId, VIS.ClienteClave, TRP.PCEPrecioClave ")
        sConsulta.AppendLine("from TransProd TRP ")
        sConsulta.AppendLine("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ")
        sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("inner join (select distinct VendedorId, DiaClave, ClaveCEDI from AgendaVendedor) AGV on VIS.VendedorId = AGV.VendedorId and VIS.DiaClave = AGV.DiaClave ")
        sConsulta.AppendLine("inner join ClienteEsquema CEE on VIS.ClienteClave = CEE.ClienteClave and CEE.TipoEstado = 1 ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine("and TRP.Tipo = 1 and TRP.TipoFase <> 0 ")
        sConsulta.AppendLine("order by AGV.ClaveCEDI, VIS.RUTClave, VIS.VendedorId, VIS.ClienteClave ")
        Session("ListaPrecios") = sConsulta.ToString

        Return True
    End Function

    Private Function ConsultaSaldosPorCliente(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String, ByVal pvRutas As ArrayList, ByVal pvClientes As ArrayList) As Boolean
        Dim sConsulta As New StringBuilder
        Dim sFecha As String = ""

        If ChBoxCentroDistribucion.Checked Then
            pvCondicion = strWhereCentrosDistribucion(pvCondicion, "ALM.Clave")
        End If
        If chboxRuta.Checked Then
            pvCondicion = strWhereRutas(pvCondicion, pvRutas, "SEC.RUTClave")
        End If
        If chboxFecha.Checked Then
            sFecha = strWhereFecha(sFecha, "Dia.FechaCaptura").Replace("=", "<=")
            pvCondicion &= sFecha
        End If
        pvCondicion = strWhereClientes(pvCondicion, pvClientes, "VIS.ClienteClave")
        pvCondicion = pvCondicion.Replace("VEN.", "VIS.")

        sConsulta.AppendLine("set nocount on ")
        sConsulta.AppendLine("if (select object_id('tempdb..#TmpVentas')) is not null drop table #TmpVentas ")
        sConsulta.AppendLine("select * into #TmpVentas from ( ")

        sConsulta.AppendLine("select CEDI.AlmacenId, SEC.RUTClave, VIS.VendedorId, CLI.Clave as ClienteClave, sum(TRP.Total) as TotalVenta, sum(isnull(TotalDevConsignacion, 0)) as TotalDevConsignacion ")
        sConsulta.AppendLine("from TransProd TRP ")
        sConsulta.AppendLine("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ")
        sConsulta.AppendLine("inner join Dia on TRP.DiaClave = DIA.DiaClave ")
        sConsulta.AppendLine("left join (select Transprodid1, sum(isnull(TTP.Total, 0)) as TotalDevConsignacion from TrpTpd TTP group by transprodid1) TT on TRP.TransProdId = TT.TransProdId1 ")
        sConsulta.AppendLine("inner join (select VendedorId, AlmacenId from VENCentroDistHist where FechaFinal >= '" & ObtenerFecha(txtFInicio.Text).ToString("s") & "' and VCHFechaInicial <= '" & ObtenerFecha(txtFInicio.Text).ToString("s") & "') as CEDI on VIS.VendedorID = CEDI.VendedorId ")
        sConsulta.AppendLine("inner join (select distinct ClienteClave, RUTClave from Secuencia where not RUTClave is null) as SEC on VIS.ClienteClave = SEC.ClienteClave ")
        sConsulta.AppendLine("inner join Almacen ALM on ALM.AlmacenID = CEDI.AlmacenId ")
        sConsulta.AppendLine("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine("and TRP.Tipo in (1, 24) and TRP.TipoFase <> 0 ")
        sConsulta.AppendLine("group by CEDI.AlmacenId, SEC.RUTClave, VIS.VendedorId, CLI.Clave ")
        sConsulta.AppendLine(") as T1 ")

        sConsulta.AppendLine("select ALM.Clave as ClaveCEDI, ALM.Nombre as ALMNombre, TV.RUTClave, TV.VendedorId, VEN.Nombre as VENNombre, CLI.Clave as ClienteClave, CLI.RazonSocial, CLI.NombreContacto, ")
        sConsulta.AppendLine("isnull(TV.TotalVenta, 0) as TotalVenta, isnull(TV.TotalDevConsignacion, 0) as TotalDevConsignacion, isnull(TA.TotalAbono, 0) as TotalAbono ")
        sConsulta.AppendLine("from #TmpVentas TV ")
        sConsulta.AppendLine("left join ( ")
        sConsulta.AppendLine("select CEDI.AlmacenId, SEC.RUTClave, VIS.VendedorId, VIS.ClienteClave, sum(ABN.Total) as TotalAbono ")
        sConsulta.AppendLine("from Abono ABN ")
        sConsulta.AppendLine("inner join Visita VIS on ABN.VisitaClave = VIS.VisitaClave and ABN.DiaClave = VIS.DiaClave ")
        sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("inner join (select VendedorId, AlmacenId from VENCentroDistHist where FechaFinal >= '" & ObtenerFecha(txtFInicio.Text).ToString("s") & "' and VCHFechaInicial <= '" & ObtenerFecha(txtFInicio.Text).ToString("s") & "') as CEDI on VIS.VendedorID = CEDI.VendedorId ")
        sConsulta.AppendLine("inner join (select distinct ClienteClave, RUTClave from Secuencia where not RUTClave is null) as SEC on VIS.ClienteClave = SEC.ClienteClave ")
        sConsulta.AppendLine("inner join Almacen ALM on ALM.AlmacenID = CEDI.AlmacenId ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine("group by CEDI.AlmacenId, SEC.RUTClave, VIS.VendedorId, VIS.ClienteClave ")
        sConsulta.AppendLine(") as TA on TV.AlmacenId = TA.AlmacenId  and TV.RUTClave = TA.RUTClave and TV.VendedorId = TA.VendedorId and TV.ClienteClave = TA.ClienteClave ")
        sConsulta.AppendLine("inner join Almacen ALM on TV.AlmacenId = ALM.AlmacenId ")
        sConsulta.AppendLine("inner join Vendedor VEN on TV.VendedorId = VEN.VendedorId ")
        sConsulta.AppendLine("inner join Cliente CLI on TV.ClienteClave = CLI.ClienteClave ")
        sConsulta.AppendLine("where isnull(TotalVenta,0) - isnull(TotalDevConsignacion,0) - isnull(TotalAbono,0) <> 0 ")
        sConsulta.AppendLine("order by TV.AlmacenId, TV.RUTClave, VEN.Nombre, CLI.Clave ")

        sConsulta.AppendLine("drop table #TmpVentas ")
        sConsulta.AppendLine("set nocount off ")

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt
        Return True
    End Function

    Private Function ConsultaLiquidacionModelo(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String) As Boolean
        Dim sConsulta As New StringBuilder
        Dim sCondicionMovs As String
        If ChBoxCentroDistribucion.Checked Then
            pvCondicion = strWhereCentrosDistribucion(pvCondicion, "AGV.ClaveCEDI")
        End If
        'If chboxFecha.Checked Then
        '    pvCondicion = strWhereFecha(pvCondicion, "Dia.FechaCaptura")
        'End If
        sCondicionMovs = pvCondicion
        If chboxFecha.Checked Then
            Dim sFecha As String()
            sFecha = txtFInicio.Text.Split("/")
            Dim dFechaIni As New Date(sFecha(2), sFecha(1), sFecha(0))

            pvCondicion = strWhereFecha(pvCondicion, "Dia.FechaCaptura")
            sCondicionMovs &= " AND ((TRP.Tipo in(1,2,4,7,24) " & strWhereFecha("", "Dia.FechaCaptura") & ") OR (TRP.Tipo = 23 and Dia.FechaCaptura = (Select max(Dia2.FechaCaptura) as FechaCaptura from TransProd TRP2 inner join Dia Dia2 on TRP2.DiaClave = Dia2.Diaclave where " & " convert(datetime,Convert(varchar(20),Dia2.FechaCaptura,112)) < '" & dFechaIni.Date.ToString("s") & "' " & " and TRP2.Tipo = 23 and TRP2.MUsuarioID =VEN.USUId))) "
        End If

        '--Vendedores
        sConsulta.AppendLine("SET NOCOUNT ON ")
        sConsulta.AppendLine("SELECT DISTINCT AGV.ClaveCEDI, ALM.Clave AS ALMClave, ALM.Nombre AS ALMNombre, VEN.VendedorId, USU.Clave AS USUClave, VEN.Nombre AS VENNombre ")
        sConsulta.AppendLine("FROM TransProd TRP ")
        sConsulta.AppendLine("INNER JOIN Dia ON TRP.DiaClave = DIA.DiaClave ")
        sConsulta.AppendLine("INNER JOIN Vendedor AS VEN ON VEN.USUId = TRP.MUsuarioId AND VEN.TipoEstado = 1 AND VEN.Baja = 0 ")
        sConsulta.AppendLine("INNER JOIN Usuario AS USU ON VEN.USUId = USU.USUId ")
        sConsulta.AppendLine("INNER JOIN (SELECT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor GROUP BY DiaClave, VendedorId, ClaveCEDI) as AGV ON AGV.DiaClave=TRP.DiaClave AND AGV.VendedorId=VEN.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Almacen as ALM ON ALM.Clave=AGV.ClaveCEDI ")
        sConsulta.AppendLine(sCondicionMovs)
        sConsulta.AppendLine("AND ((TRP.Tipo IN (1,2,4,7,24) AND TRP.TipoFase <> 0) OR (TRP.Tipo = 23 AND TRP.TipoFase = 1)) ")
        sConsulta.AppendLine("UNION ")
        sConsulta.AppendLine("SELECT DISTINCT AGV.ClaveCEDI, ALM.Clave AS ALMClave, ALM.Nombre AS ALMNombre, VEN.VendedorId, USU.Clave AS USUClave, VEN.Nombre AS VENNombre ")
        sConsulta.AppendLine("FROM ProductoPrestamoCli PPC ")
        sConsulta.AppendLine("INNER JOIN (SELECT DISTINCT VendedorId, DiaClave, ClaveCEDI, ClienteClave FROM AgendaVendedor) AGV ON PPC.ClienteClave = AGV.ClienteClave ")
        sConsulta.AppendLine("INNER JOIN Dia ON AGV.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("INNER JOIN Vendedor AS VEN ON AGV.VendedorId = VEN.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Usuario AS USU ON VEN.USUId = USU.USUId ")
        sConsulta.AppendLine("INNER JOIN Almacen AS ALM ON ALM.Clave=AGV.ClaveCEDI ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine("AND Saldo > 0 ")
        sConsulta.AppendLine("SET NOCOUNT OFF ")

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        '--Movimientos
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET NOCOUNT ON ")
        sConsulta.AppendLine("if (select object_id('tempdb..#TmpMovs')) is not null drop table #TmpMovs ")
        sConsulta.AppendLine("select * into #TmpMovs from ( ")
        sConsulta.AppendLine("SELECT TRP.TransProdId , TRP.Tipo, TRP.TipoFase, TRP.DescVendPor, ")
        sConsulta.AppendLine("TPD.TransProdDetalleId, TPD.ProductoClave, TPD.TipoUnidad, TPD.Cantidad as TPDCantidad, TPD.Promocion, TPD.Total as TPDTotal, ")
        sConsulta.AppendLine("TPD.SubTotal, TPD.Impuesto, ")
        sConsulta.AppendLine("isnull(TTP.Cantidad, 0) as TTPCantidad, isnull(TTP.Total, 0) as TTPTotal, ")
        sConsulta.AppendLine("VEN.VendedorId, VEN.Nombre as VENNombre, AGV.ClaveCEDI, Dia.FechaCaptura ")
        sConsulta.AppendLine("FROM TransProd AS TRP ")
        sConsulta.AppendLine("INNER JOIN TransProdDetalle AS TPD ON TPD.TransProdId = TRP.TransProdId ")
        sConsulta.AppendLine("LEFT JOIN TrpTpd TTP ON TPD.TransProdId = TTP.TransProdId1 AND TPD.TransProdDetalleId = TTP.TransProdDetalleId ")
        sConsulta.AppendLine("INNER JOIN Vendedor AS VEN ON VEN.USUId = TRP.MUsuarioId AND VEN.TipoEstado = 1 AND VEN.Baja = 0 ")
        sConsulta.AppendLine("INNER JOIN (SELECT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor GROUP BY DiaClave, VendedorId, ClaveCEDI) as AGV ON AGV.DiaClave=TRP.DiaClave AND AGV.VendedorId=VEN.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Dia ON TRP.DiaClave = DIA.DiaClave ")
        sConsulta.AppendLine(sCondicionMovs)
        sConsulta.AppendLine("AND ((TRP.Tipo IN (1,2,4,7,24) AND TRP.TipoFase <> 0) OR (TRP.Tipo = 23 AND TRP.TipoFase = 1)) ")
        sConsulta.AppendLine(")as t1 ")

        sConsulta.AppendLine("SELECT ClaveCEDI, VendedorId, ProductoClave, PRONombre, ")
        sConsulta.AppendLine("SUM(InvInicial) as InvInicial, SUM(Carga) AS Carga, SUM(DevolucionAlm) AS DevolucionAlm, SUM(Descarga) AS Descarga, SUM(Promocion) AS Promocion, ")
        sConsulta.AppendLine("SUM(Consignacion) AS Consignacion, SUM(Venta) AS Venta, ")
        sConsulta.AppendLine("SUM((SubTotal- DescCliPor -((SubTotal-DescCliPor) * DescVendPor / 100)) + (Impuesto-DescCliPorImp-((Impuesto-DescCliPorImp) * DescVendPor / 100)) + TotalConsignacion) AS Importe ")
        sConsulta.AppendLine("FROM( ")
        sConsulta.AppendLine("SELECT MOV.ClaveCEDI, MOV.VendedorId, ")
        sConsulta.AppendLine("MOV.FechaCaptura AS FechaHoraAlta, MOV.Tipo, MOV.ProductoClave, PRO.Nombre AS PRONombre, ")
        sConsulta.AppendLine("InvInicial = (SELECT CASE WHEN MOV.Tipo = 23 THEN MOV.TPDCantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Carga = (SELECT CASE WHEN MOV.Tipo = 2 THEN MOV.TPDCantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("DevolucionAlm = (SELECT CASE WHEN MOV.Tipo = 4 THEN MOV.TPDCantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Descarga =(SELECT CASE WHEN MOV.Tipo = 7 THEN MOV.TPDCantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Promocion = (SELECT CASE WHEN MOV.Tipo = 1 AND MOV.Promocion = 2 THEN MOV.TPDCantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Consignacion = (SELECT CASE WHEN MOV.Tipo = 24 THEN MOV.TPDCantidad * PDD.Factor ELSE 0 END), ")
        sConsulta.AppendLine("Venta = (SELECT CASE MOV.Tipo WHEN 1 THEN CASE WHEN isnull(MOV.Promocion,0) <> 2 THEN MOV.TPDCantidad * PDD.Factor ELSE 0 END WHEN 24 THEN CASE WHEN MOV.TipoFase = 6 THEN (MOV.TPDCantidad - MOV.TTPCantidad) * PDD.Factor ELSE 0 END ELSE 0 END), ")
        sConsulta.AppendLine("SubTotal = (SELECT CASE WHEN MOV.Tipo = 1  AND MOV.TPDTotal > 0 THEN MOV.Subtotal ELSE 0 END), ")
        sConsulta.AppendLine("DescCliPor = (SELECT CASE WHEN MOV.Tipo = 1  AND MOV.TPDTotal > 0 THEN (SELECT (CASE WHEN SUM(DesImporte) IS NULL THEN 0 ELSE SUM(DesImporte) END) FROM TpdDes AS TDD WHERE TDD.TransProdId = MOV.TransProdId AND TDD.TransProdDetalleId = MOV.TransProdDetalleId) ELSE 0 END), ")
        sConsulta.AppendLine("DescVendPor = (SELECT CASE WHEN MOV.Tipo = 1 AND MOV.TPDTotal > 0 THEN (SELECT CASE WHEN MOV.DescVendPor IS NULL THEN 0 ELSE MOV.DescVendPor END) ELSE 0 END), ")
        sConsulta.AppendLine("Impuesto = (SELECT CASE WHEN MOV.Tipo = 1  AND MOV.TPDTotal > 0 THEN (SELECT CASE WHEN MOV.Impuesto IS NULL THEN 0 ELSE MOV.Impuesto END) ELSE 0 END), ")
        sConsulta.AppendLine("DescCliPorImp=(SELECT CASE WHEN MOV.Tipo=1  AND MOV.TPDTotal > 0 THEN (SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE sum(DesImpuesto) END) FROM TpdDes AS TDD WHERE TDD.TransProdId = MOV.TransProdId AND TDD.TransProdDetalleId = MOV.TransProdDetalleId) ELSE 0 END), ")
        sConsulta.AppendLine("TotalConsignacion = (SELECT CASE WHEN MOV.Tipo = 24 AND MOV.TipoFase = 6 THEN MOV.TPDTotal - MOV.TTPTotal ELSE 0 END) ")
        sConsulta.AppendLine("FROM #TmpMovs MOV ")
        sConsulta.AppendLine("INNER JOIN Producto AS PRO ON PRO.ProductoClave = MOV.ProductoClave ")
        sConsulta.AppendLine("INNER JOIN ProductoDetalle AS PDD ON PDD.ProductoClave = MOV.ProductoClave AND PDD.PRUTipoUnidad = MOV.TipoUnidad AND PDD.ProductoDetClave = MOV.ProductoClave ")
        sConsulta.AppendLine(")AS Liquidacion ")
        sConsulta.AppendLine("GROUP BY ClaveCEDI, VendedorId, ProductoClave, PRONombre ")
        sConsulta.AppendLine("ORDER BY ClaveCEDI, VendedorId, ProductoClave ")

        sConsulta.AppendLine("DROP TABLE #TmpMovs ")
        sConsulta.AppendLine("SET NOCOUNT OFF ")
        Session("Movimientos") = sConsulta.ToString

        '--Ventas 
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET NOCOUNT ON ")
        sConsulta.AppendLine("SELECT AGV.ClaveCEDI, VEN.VendedorId, ")
        sConsulta.AppendLine("sum(case when TRP.CFVTipo = 1 then TRP.Total else 0 end) as Contado, ")
        sConsulta.AppendLine("sum(case when TRP.CFVTipo = 2 then TRP.Total else 0 end) as Credito ")
        sConsulta.AppendLine("FROM TransProd TRP ")
        sConsulta.AppendLine("INNER JOIN Dia ON TRP.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("INNER JOIN Vendedor AS VEN ON VEN.USUId = TRP.MUsuarioId AND VEN.TipoEstado = 1 AND VEN.Baja = 0 ")
        sConsulta.AppendLine("INNER JOIN (SELECT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor GROUP BY DiaClave, VendedorId, ClaveCEDI) AS AGV ON AGV.DiaClave=TRP.DiaClave AND AGV.VendedorId=VEN.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Almacen as ALM ON ALM.Clave=AGV.ClaveCEDI ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine("AND TRP.Tipo = 1 AND TRP.TipoFase <> 0 ")
        sConsulta.AppendLine("GROUP BY ClaveCEDI, VEN.VendedorId ")
        sConsulta.AppendLine("SET NOCOUNT OFF ")
        Session("Ventas") = sConsulta.ToString

        '--Cobranza
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET NOCOUNT ON ")
        sConsulta.AppendLine("SELECT AGV.ClaveCEDI, VEN.VendedorId, ")
        sConsulta.AppendLine("sum(case when TRP.CFVTipo = 1 then ABN.Total else 0 end) as Contado, ")
        sConsulta.AppendLine("sum(case when TRP.CFVTipo = 2 then ABN.Total else 0 end) as Credito ")
        sConsulta.AppendLine("FROM TransProd TRP ")
        sConsulta.AppendLine("INNER JOIN Dia ON TRP.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("INNER JOIN AbnTrp ABT ON TRP.TransProdId = ABT.TransProdId ")
        sConsulta.AppendLine("INNER JOIN Abono ABN on ABT.ABNId = ABN.ABNId ")
        sConsulta.AppendLine("INNER JOIN Vendedor AS VEN ON VEN.USUId = TRP.MUsuarioId AND VEN.TipoEstado = 1 AND VEN.Baja = 0 ")
        sConsulta.AppendLine("INNER JOIN (SELECT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor GROUP BY DiaClave, VendedorId, ClaveCEDI) AS AGV ON AGV.DiaClave=TRP.DiaClave AND AGV.VendedorId=VEN.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Almacen AS ALM ON ALM.Clave=AGV.ClaveCEDI ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine("AND TRP.Tipo = 1 AND TRP.TipoFase <> 0 ")
        sConsulta.AppendLine("GROUP BY ClaveCEDI, VEN.VendedorId ")
        sConsulta.AppendLine("SET NOCOUNT OFF ")
        Session("Cobranza") = sConsulta.ToString

        '--Envases
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET NOCOUNT ON ")
        sConsulta.AppendLine("SELECT AGV.ClaveCEDI, VEN.VendedorId, PPC.ProductoClave, PRO.Nombre as PRONombre, sum(PPC.Saldo) as Saldo ")
        sConsulta.AppendLine("FROM ProductoPrestamoCli PPC ")
        sConsulta.AppendLine("INNER JOIN Producto PRO ON PPC.ProductoClave = PRO.ProductoClave ")
        sConsulta.AppendLine("INNER JOIN (SELECT DISTINCT VendedorId, DiaClave, ClaveCEDI, ClienteClave FROM AgendaVendedor) AGV ON PPC.ClienteClave = AGV.ClienteClave ")
        sConsulta.AppendLine("INNER JOIN Dia ON AGV.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("INNER JOIN Vendedor AS VEN ON AGV.VendedorId = VEN.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Almacen AS ALM ON ALM.Clave=AGV.ClaveCEDI ")
        sConsulta.AppendLine(pvCondicion)
        sConsulta.AppendLine("AND Saldo > 0 ")
        sConsulta.AppendLine("GROUP BY AGV.ClaveCEDI, VEN.VendedorId, PPC.ProductoClave, PRO.Nombre ")
        sConsulta.AppendLine("SET NOCOUNT OFF ")
        Session("Envases") = sConsulta.ToString

        Return True
    End Function

    Private Function ConsultaLiquidacionSuKarne(ByVal ins As DBConexion.cConexionSQL, ByVal pvCondicion As String) As Boolean
        Dim sConsulta As New StringBuilder
        Dim sCondicionMovs As String
        Dim sCondicionCob As String
        Dim sCondicionPre As String

        If ChBoxCentroDistribucion.Checked Then
            pvCondicion = strWhereCentrosDistribucion(pvCondicion, "AGV.ClaveCEDI")
        End If
        'If chboxFecha.Checked Then
        '    pvCondicion = strWhereFecha(pvCondicion, "Dia.FechaCaptura")
        'End If
        sCondicionMovs = pvCondicion
        sCondicionCob = pvCondicion
        sCondicionPre = pvCondicion

        If chboxFecha.Checked Then
            Dim sFecha As String()
            sFecha = txtFInicio.Text.Split("/")
            Dim dFechaIni As New Date(sFecha(2), sFecha(1), sFecha(0))

            pvCondicion = strWhereFecha(pvCondicion, "Dia.FechaCaptura", True)
            sCondicionPre = strWhereFecha(sCondicionPre, "convert(datetime,convert(varchar ,P.FechaPreLiquidacion,110),110)", True)
            sCondicionMovs &= " AND ((TRP.Tipo in(1,2,4,7,24) " & strWhereFecha("", "Dia.FechaCaptura") & ") OR (TRP.Tipo = 23 and Dia.FechaCaptura = (Select max(Dia2.FechaCaptura) as FechaCaptura from TransProd TRP2 inner join Dia Dia2 on TRP2.DiaClave = Dia2.Diaclave where " & " convert(datetime,Convert(varchar(20),Dia2.FechaCaptura,112)) < '" & dFechaIni.Date.ToString("s") & "' " & " and TRP2.Tipo = 23 and TRP2.MUsuarioID =VEN.USUId))) "
        End If

        '--Vendedores
        sConsulta.AppendLine("SET NOCOUNT ON ")

        sConsulta.AppendLine("if (select object_id('tempdb..#TmpALM')) is not null drop table #TmpALM ")
        sConsulta.AppendLine("select * into #TmpALM from ( ")
        sConsulta.AppendLine("select ALM.Clave as ClaveCEDI,ALM.Nombre,agv.vendedorid from VenCentroDistHist AGV ")
        sConsulta.AppendLine("INNER JOIN ALMACEN ALM on AGV.AlmacenID = ALM.AlmacenID ")
        sConsulta.AppendLine("where AGV.VCHFechaInicial =( ")
        sConsulta.AppendLine("select top 1 VCHFechaInicial from VenCentroDistHist where vendedorid =AGV.VendedorID order by VCHFechaInicial desc) ) as t1 ")

        sConsulta.AppendLine("SELECT DISTINCT AGV.ClaveCEDI, ALM.Clave AS ALMClave, ALM.Nombre AS ALMNombre, VEN.VendedorId, USU.Clave AS USUClave, VEN.Nombre AS VENNombre ")
        sConsulta.AppendLine("FROM TransProd TRP ")
        sConsulta.AppendLine("INNER JOIN Dia ON TRP.DiaClave = DIA.DiaClave ")
        sConsulta.AppendLine("INNER JOIN Vendedor AS VEN ON VEN.USUId = TRP.MUsuarioId AND VEN.TipoEstado = 1 AND VEN.Baja = 0 ")
        sConsulta.AppendLine("INNER JOIN Usuario AS USU ON VEN.USUId = USU.USUId ")
        sConsulta.AppendLine("INNER JOIN (SELECT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor GROUP BY DiaClave, VendedorId, ClaveCEDI) as AGV ON AGV.DiaClave=TRP.DiaClave AND AGV.VendedorId=VEN.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Almacen as ALM ON ALM.Clave=AGV.ClaveCEDI ")
        sConsulta.AppendLine(sCondicionMovs)
        sConsulta.AppendLine("AND ((TRP.Tipo IN (1,2,4,7,24) AND TRP.TipoFase <> 0) OR (TRP.Tipo = 23 AND TRP.TipoFase = 1)) ")

        sConsulta.AppendLine("union Select distinct ")
        sConsulta.AppendLine("AGV.ClaveCEDI as ClaveCEDI, AGV.ClaveCEDI as ALMClave, AGV.nombre as ALMNombre,VEN.VendedorId, USU.Clave AS USUClave, VEN.Nombre AS VENNombre  ")
        sConsulta.AppendLine("FROM Abono ABN ")
        sConsulta.AppendLine("INNER JOIN Dia ON ABN.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("inner join abntrp ABT on ABT.ABNId = ABN.ABNId ")
        sConsulta.AppendLine("INNER JOIN TransProd TRP ON  TRP.TransProdId = ABT.TransProdId ")
        sConsulta.AppendLine("INNER JOIN Vendedor AS VEN ON VEN.USUId = TRP.MUsuarioId AND VEN.TipoEstado = 1 AND VEN.Baja = 0 ")
        sConsulta.AppendLine("INNER JOIN Usuario AS USU ON VEN.USUId = USU.USUId ")
        sConsulta.AppendLine("INNER JOIN #TmpALM AGV on AGV.vendedorid=VEN.vendedorid   ")
        sConsulta.AppendLine(pvCondicion & " AND TRP.Tipo = 1 AND TRP.TipoFase <> 0 ")
        sConsulta.AppendLine("SET NOCOUNT OFF ")
        sConsulta.AppendLine("drop table #TmpALM ")

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)

        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        '--Movimientos
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET NOCOUNT ON ")
        sConsulta.AppendLine("if (select object_id('tempdb..#TmpMovs')) is not null drop table #TmpMovs ")
        sConsulta.AppendLine("select * into #TmpMovs from ( ")
        sConsulta.AppendLine("SELECT distinct TRP.TransProdId , TRP.Tipo, TRP.TipoFase, TRP.DescVendPor, ")
        sConsulta.AppendLine("(select fechacaptura from dia where diaclave = TRP.DiaClave) as FechaCapturaVenta, ")
        sConsulta.AppendLine("(select fechacaptura from dia where diaclave = TRP.DiaClave1) as FechaCapturaPedido, ")
        sConsulta.AppendLine("(select RutClave from visita where visitaclave = TRP.visitaclave and diaclave=trp.diaclave) as RutClaveVenta, ")
        sConsulta.AppendLine("TPD.TransProdDetalleId, TPD.ProductoClave, TPD.TipoUnidad, TPD.Cantidad as TPDCantidad, TPD.Cantidad1 as TPDCantidad1, TPD.Promocion, TPD.Total as TPDTotal, ")
        sConsulta.AppendLine("TPD.SubTotal, TPD.Impuesto, ")
        sConsulta.AppendLine("isnull(TTP.Cantidad, 0) as TTPCantidad, isnull(TTP.Total, 0) as TTPTotal, ")
        sConsulta.AppendLine("VEN.VendedorId, VEN.Nombre as VENNombre, AGV.ClaveCEDI, Dia.FechaCaptura,TRP.TipoCambio ")
        sConsulta.AppendLine("FROM TransProd AS TRP ")
        sConsulta.AppendLine("INNER JOIN TransProdDetalle AS TPD ON TPD.TransProdId = TRP.TransProdId ")
        sConsulta.AppendLine("LEFT JOIN TrpTpd TTP ON TPD.TransProdId = TTP.TransProdId1 AND TPD.TransProdDetalleId = TTP.TransProdDetalleId ")
        sConsulta.AppendLine("INNER JOIN Vendedor AS VEN ON VEN.USUId = TRP.MUsuarioId AND VEN.TipoEstado = 1 AND VEN.Baja = 0 ")
        sConsulta.AppendLine("INNER JOIN (SELECT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor GROUP BY DiaClave, VendedorId, ClaveCEDI) as AGV ON (AGV.DiaClave=TRP.DiaClave or AGV.DiaClave=TRP.DiaClave1) AND AGV.VendedorId=VEN.VendedorId ")
        sConsulta.AppendLine("INNER JOIN Dia ON TRP.DiaClave = DIA.DiaClave or Dia.DiaClave =TRP.DiaClave1 ")
        sConsulta.AppendLine("left join visita VIS on trp.visitaclave= vis.visitaclave or trp.visitaclave1= vis.visitaclave ")
        sConsulta.AppendLine(sCondicionMovs)
        sConsulta.AppendLine("AND ((TRP.Tipo IN (1,2,7) AND TRP.TipoFase <> 0)) ")
        sConsulta.AppendLine(")as t1 ")

        sConsulta.AppendLine("SELECT ClaveCEDI, VendedorId, ProductoClave, PRONombre,  ")
        sConsulta.AppendLine("(select top 1 VAD.Descripcion from VAVDescripcion VAD where VAD.VARCodigo = 'UNIDADV' and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' and VAD.VAVClave = TipoUnidad) as TipoUnidad, ")
        sConsulta.AppendLine("SUM(Carga) AS Carga, SUM(Piezas) AS Piezas, SUM(Descarga) AS Descarga, SUM(Venta) AS Venta, sum(FacturasSurtidas)-sum(PiezasBon) as FacturasSurtidas, ")
        sConsulta.AppendLine("SUM(((SubTotal- DescCliPor -((SubTotal-DescCliPor) * DescVendPor / 100)) + (Impuesto-DescCliPorImp-((Impuesto-DescCliPorImp) * DescVendPor / 100)))* tipocambio) - (sum(bonificacion * tipocambio )) AS Importe  ")
        sConsulta.AppendLine("FROM( ")
        sConsulta.AppendLine("SELECT MOV.ClaveCEDI, MOV.VendedorId, ")
        sConsulta.AppendLine("MOV.FechaCaptura AS FechaHoraAlta, MOV.Tipo, MOV.ProductoClave, PRO.Nombre AS PRONombre, MOV.TipoUnidad, MOV.TipoCambio, ")
        sConsulta.AppendLine("Carga = (SELECT CASE WHEN MOV.Tipo = 2 THEN MOV.TPDCantidad ELSE 0 END), ")
        sConsulta.AppendLine("Piezas = (SELECT CASE WHEN MOV.Tipo = 1 and MOV.TipoFase<>0 and isnull(MOV.Promocion,0) <> 2 and RutClaveVenta <> 'RUT001' " & strWhereFecha("", "MOV.FechaCapturaVenta", True) & " THEN MOV.TPDCantidad1 ELSE 0 END), ")
        sConsulta.AppendLine("Descarga =(SELECT CASE WHEN MOV.Tipo = 7 THEN MOV.TPDCantidad  ELSE 0 END), ")
        sConsulta.AppendLine("FacturasSurtidas = (SELECT CASE WHEN MOV.Tipo = 1 and MOV.TipoFase=2 and isnull(MOV.Promocion,0) <> 2 " & strWhereFecha("", "MOV.FechaCapturaPedido", True) & " ")
        sConsulta.AppendLine("AND ( (1=1 " & strWhereFecha("", "MOV.FechaCapturaVenta", CondicionFecha.Diferente) & " ) or (1=1 " & strWhereFecha("", "MOV.FechaCapturaVenta", CondicionFecha.Igual) & " and RutClaveVenta ='RUT001') )  THEN MOV.TPDCantidad  ELSE 0 END ), ")
        sConsulta.AppendLine("Venta = (SELECT CASE MOV.Tipo WHEN 1 THEN CASE WHEN isnull(MOV.Promocion,0) <> 2 " & strWhereFecha("", "MOV.FechaCapturaVenta", True) & " and RutClaveVenta <> 'RUT001' THEN MOV.TPDCantidad ELSE 0 END WHEN 24 THEN CASE WHEN MOV.TipoFase = 6 THEN (MOV.TPDCantidad - MOV.TTPCantidad) ELSE 0 END ELSE 0 END), ")
        sConsulta.AppendLine("SubTotal = (SELECT CASE WHEN MOV.Tipo = 1 and MOV.TipoFase=2 AND MOV.TPDTotal > 0 THEN MOV.Subtotal ELSE 0 END), ")
        sConsulta.AppendLine("DescCliPor = (SELECT CASE WHEN MOV.Tipo = 1  AND MOV.TPDTotal > 0 THEN (SELECT (CASE WHEN SUM(DesImporte) IS NULL THEN 0 ELSE SUM(DesImporte) END) FROM TpdDes AS TDD WHERE TDD.TransProdId = MOV.TransProdId AND TDD.TransProdDetalleId = MOV.TransProdDetalleId) ELSE 0 END), ")
        sConsulta.AppendLine("DescVendPor = (SELECT CASE WHEN MOV.Tipo = 1 AND MOV.TPDTotal > 0 THEN (SELECT CASE WHEN MOV.DescVendPor IS NULL THEN 0 ELSE MOV.DescVendPor END) ELSE 0 END), ")
        sConsulta.AppendLine("Impuesto = (SELECT CASE WHEN MOV.Tipo = 1  AND MOV.TPDTotal > 0 THEN (SELECT CASE WHEN MOV.Impuesto IS NULL THEN 0 ELSE MOV.Impuesto END) ELSE 0 END), ")
        sConsulta.AppendLine("DescCliPorImp=(SELECT CASE WHEN MOV.Tipo=1  AND MOV.TPDTotal > 0 THEN (SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE sum(DesImpuesto) END) FROM TpdDes AS TDD WHERE TDD.TransProdId = MOV.TransProdId AND TDD.TransProdDetalleId = MOV.TransProdDetalleId) ELSE 0 END), ")
        sConsulta.AppendLine("Bonificacion= isnull((select BOND.total from transprod BON inner join transproddetalle BOND on BON.Transprodid=BOND.transprodid where BON.facturaid=mov.transprodid and BON.tipo=12 and mov.TransProdDetalleId=BOND.transproddetalleid),0), ")
        sConsulta.AppendLine("PiezasBon= isnull((select BOND.cantidad from transprod BON inner join transproddetalle BOND on BON.Transprodid=BOND.transprodid where BON.facturaid=mov.transprodid and BON.tipo=12 and mov.TransProdDetalleId=BOND.transproddetalleid),0) ")

        sConsulta.AppendLine("FROM #TmpMovs MOV ")
        sConsulta.AppendLine("INNER JOIN Producto AS PRO ON PRO.ProductoClave = MOV.ProductoClave ")
        sConsulta.AppendLine(")AS Liquidacion ")
        sConsulta.AppendLine("GROUP BY ClaveCEDI, VendedorId, ProductoClave, PRONombre,TipoUnidad ")
        sConsulta.AppendLine("ORDER BY ClaveCEDI, VendedorId, ProductoClave,TipoUnidad ")


        sConsulta.AppendLine("DROP TABLE #TmpMovs ")
        sConsulta.AppendLine("SET NOCOUNT OFF ")
        Session("Movimientos") = sConsulta.ToString

        'Sección Ventas Efectivo
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("SELECT distinct VEN.VendedorID, TRP.DiaClave, AGV.ClaveCEDI as ALMClave, TRP.Folio, TRP.FechaHoraAlta, (CLI.Clave + ' ' + CLI.RazonSocial) as Cliente, ")
        sConsulta.AppendLine("(SELECT Simbolo FROM Moneda WHERE Moneda.MonedaId=(SELECT TOP 1 MonedaId FROM CONHist ORDER BY MFechaHora DESC)) as Simbolo, ")
        sConsulta.AppendLine("(TRP.Total - isnull((select BON.total from transprod BON where BON.facturaid=trp.transprodid and tipo=12),0))*TRP.TipoCambio as Total ")
        sConsulta.AppendLine("FROM TransProd TRP ")
        sConsulta.AppendLine("INNER JOIN Dia on DIA.DiaClave =TRP.DiaClave or DIA.DiaClave =TRP.DiaClave1 ")
        sConsulta.AppendLine("INNER JOIN Cliente CLI ON CLI.ClienteClave=TRP.ClienteClave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VEN.USUID = TRP.MUsuarioID  ")
        sConsulta.AppendLine("INNER JOIN (SELECT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor GROUP BY DiaClave, VendedorId, ClaveCEDI) as AGV ON (AGV.DiaClave=TRP.DiaClave or AGV.DiaClave=TRP.DiaClave1) AND AGV.VendedorId=VEN.VendedorId ")
        sConsulta.AppendLine(pvCondicion & " AND TRP.Tipo = 1 and TRP.CFVTipo = 1 AND ( TRP.TipoFase <> 0 or (trp.tipoFase=2 And TRP.DiaClave1 <> null )) ")
        Session("VentasEfectivo") = sConsulta.ToString

        'Sección Ventas Credito
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        sConsulta.AppendLine("SELECT distinct VEN.VendedorID, TRP.DiaClave, AGV.ClaveCEDI as ALMClave, TRP.Folio, TRP.FechaHoraAlta, (CLI.Clave + ' ' + CLI.RazonSocial) as Cliente, ")
        sConsulta.AppendLine("(SELECT Simbolo FROM Moneda WHERE Moneda.MonedaId=(SELECT TOP 1 MonedaId FROM CONHist ORDER BY MFechaHora DESC)) as Simbolo, ")
        sConsulta.AppendLine("(TRP.Total - isnull((select BON.total from transprod BON where BON.facturaid=trp.transprodid and tipo=12),0))*TRP.TipoCambio as Total ")
        sConsulta.AppendLine("FROM TransProd TRP ")
        sConsulta.AppendLine("INNER JOIN Dia on DIA.DiaClave =TRP.DiaClave or DIA.DiaClave =TRP.DiaClave1 ")
        sConsulta.AppendLine("INNER JOIN Cliente CLI ON CLI.ClienteClave=TRP.ClienteClave ")
        sConsulta.AppendLine("inner join Vendedor VEN on VEN.USUID = TRP.MUsuarioID ")
        sConsulta.AppendLine("INNER JOIN (SELECT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor GROUP BY DiaClave, VendedorId, ClaveCEDI) as AGV ON (AGV.DiaClave=TRP.DiaClave or AGV.DiaClave=TRP.DiaClave1) AND AGV.VendedorId=VEN.VendedorId ")
        sConsulta.AppendLine(pvCondicion & " AND TRP.Tipo = 1 and TRP.CFVTipo = 2 AND ( TRP.TipoFase <> 0 or (trp.tipoFase=2 And TRP.DiaClave1 <> null )) ")
        Session("VentasCredito") = sConsulta.ToString

        ''--Cobranza
        'sConsulta = New StringBuilder
        'sConsulta.AppendLine("SET NOCOUNT ON ")
        'sConsulta.AppendLine("SELECT AGV.ClaveCEDI, VEN.VendedorId, ")
        'sConsulta.AppendLine("sum(case when TRP.CFVTipo = 1 then ABN.Total else 0 end) as Contado, ")
        'sConsulta.AppendLine("sum(case when TRP.CFVTipo = 2 then ABN.Total else 0 end) as Credito ")
        'sConsulta.AppendLine("FROM TransProd TRP ")
        'sConsulta.AppendLine("INNER JOIN Dia ON TRP.DiaClave = Dia.DiaClave or dia.diaClave=trp.diaclave1 ")
        'sConsulta.AppendLine("INNER JOIN AbnTrp ABT ON TRP.TransProdId = ABT.TransProdId ")
        'sConsulta.AppendLine("INNER JOIN Abono ABN on ABT.ABNId = ABN.ABNId ")
        'sConsulta.AppendLine("INNER JOIN Vendedor AS VEN ON VEN.USUId = TRP.MUsuarioId AND VEN.TipoEstado = 1 AND VEN.Baja = 0 ")
        'sConsulta.AppendLine("INNER JOIN (SELECT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor GROUP BY DiaClave, VendedorId, ClaveCEDI) AS AGV ON (AGV.DiaClave=TRP.DiaClave or AGV.DiaClave=TRP.DiaClave1) AND AGV.VendedorId=VEN.VendedorId ")
        'sConsulta.AppendLine(pvCondicion)
        'sConsulta.AppendLine("AND TRP.Tipo = 1 AND TRP.TipoFase <> 0 ")
        'sConsulta.AppendLine("GROUP BY ClaveCEDI, VEN.VendedorId ")
        'sConsulta.AppendLine("SET NOCOUNT OFF ")
        'Session("Cobranza") = sConsulta.ToString

        'Sección Cobranza Ventas Desglozado
        sConsulta = New StringBuilder
        sConsulta.AppendLine("SET NOCOUNT ON ")
        sConsulta.AppendLine("if (select object_id('tempdb..#TmpALM')) is not null drop table #TmpALM ")
        sConsulta.AppendLine("select * into #TmpALM from ( ")
        sConsulta.AppendLine("select ALM.Clave as ClaveCEDI,ALM.Nombre,agv.vendedorid from VenCentroDistHist AGV ")
        sConsulta.AppendLine("INNER JOIN ALMACEN ALM on AGV.AlmacenID = ALM.AlmacenID ")
        sConsulta.AppendLine("where AGV.VCHFechaInicial =( ")
        sConsulta.AppendLine("select top 1 VCHFechaInicial from VenCentroDistHist where vendedorid =AGV.VendedorID order by VCHFechaInicial desc) ) as t1 ")
        sConsulta.AppendLine("SELECT AGV.ClaveCEDI , VEN.VendedorId, TRP.Folio, Dia.FechaCaptura as Fecha, ")
        sConsulta.AppendLine("TRP.Total - isnull((select BON.total from transprod BON where BON.facturaid=trp.transprodid and tipo=12),0) as Total, ")
        sConsulta.AppendLine("TRP.CFVTipo,(CLI.Clave + ' ' + CLI.RazonSocial) as Cliente,M.Nombre as Moneda, ")

        sConsulta.AppendLine("isnull((	Select sum(Adet.Importe ) from Abono ABN  ")
        sConsulta.AppendLine("inner join ABNDetalle Adet on ABN.ABNId = Adet.ABNId ")
        sConsulta.AppendLine("INNER JOIN Dia ON ABN.DiaClave = DIA.DiaClave  ")
        sConsulta.AppendLine("inner join ABNTrp on ABNTrp.TransProdID = TRP.TransProdID and ABNTrp.ABNId = ABN.ABNID  ")
        sConsulta.AppendLine("where 1=1  and adet.MonedaId=1 " & strWhereFecha("", "DIA.FechaCaptura", True) & " ),0) as ImportePesos, ")

        sConsulta.AppendLine("isnull((	Select sum(Adet.Importe ) from Abono ABN  ")
        sConsulta.AppendLine("inner join ABNDetalle Adet on ABN.ABNId = Adet.ABNId ")
        sConsulta.AppendLine("INNER JOIN Dia ON ABN.DiaClave = DIA.DiaClave  ")
        sConsulta.AppendLine("inner join ABNTrp on ABNTrp.TransProdID = TRP.TransProdID and ABNTrp.ABNId = ABN.ABNID  ")
        sConsulta.AppendLine("where 1=1  and adet.MonedaId=2 " & strWhereFecha("", "DIA.FechaCaptura", True) & " ),0) as ImporteDolares ")

        sConsulta.AppendLine("FROM Abono ABN ")
        sConsulta.AppendLine("INNER JOIN Dia ON ABN.DiaClave = Dia.DiaClave ")
        sConsulta.AppendLine("inner join abntrp ABT on ABT.ABNId = ABN.ABNId ")
        sConsulta.AppendLine("INNER JOIN TransProd TRP ON  TRP.TransProdId = ABT.TransProdId ")
        sConsulta.AppendLine("inner join Moneda M on M.MonedaID =TRP.MonedaId ")
        sConsulta.AppendLine("INNER JOIN Cliente CLI ON CLI.ClienteClave=TRP.ClienteClave ")
        sConsulta.AppendLine("INNER JOIN Vendedor AS VEN ON VEN.USUId = TRP.MUsuarioId AND VEN.TipoEstado = 1 AND VEN.Baja = 0 ")
        sConsulta.AppendLine("INNER JOIN #TmpALM AGV on AGV.vendedorid=VEN.vendedorid   ")
        sConsulta.AppendLine(pvCondicion & "AND TRP.Tipo = 1 AND TRP.TipoFase <> 0 ")
        sConsulta.AppendLine("SET NOCOUNT OFF ")
     
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        Session("VentaCobranzaDesglozado") = dt



        'Sección Preliquidacion  Efe
        sConsulta = New StringBuilder

        sConsulta.AppendLine("if (select object_id('tempdb..#TmpALM')) is not null drop table #TmpALM ")
        sConsulta.AppendLine("select * into #TmpALM from ( ")
        sConsulta.AppendLine("select ALM.Clave as ClaveCEDI,ALM.Nombre,agv.vendedorid from VenCentroDistHist AGV ")
        sConsulta.AppendLine("INNER JOIN ALMACEN ALM on AGV.AlmacenID = ALM.AlmacenID ")
        sConsulta.AppendLine("where AGV.VCHFechaInicial =( ")
        sConsulta.AppendLine("select top 1 VCHFechaInicial from VenCentroDistHist where vendedorid =AGV.VendedorID order by VCHFechaInicial desc) ) as t1 ")

        sConsulta.AppendLine("select M.Nombre As Moneda,PE.Cantidad,D.Descripcion,D.Valor,V.Descripcion as Grupo ,AGV.ClaveCedi,P.VendedorId")
        sConsulta.AppendLine("from PreLiquidacion  P")
        sConsulta.AppendLine("inner join PLIEfectivo PE on PE.PLIId=P.PLIId")
        sConsulta.AppendLine("inner join Denominacion D on D.DenominacionId=PE.DenominacionID")
        sConsulta.AppendLine("inner join VAVDescripcion V on V.VARCodigo='Denomina' and V.VAVClave=D.Grupo and V.VADTipoLenguaje='" + Session("lenguaje") + "'")
        sConsulta.AppendLine("inner join Moneda M on M.MonedaID=P.MonedaID")
        sConsulta.AppendLine("inner join #TmpALM AGV on P.VendedorId =AGV.VendedorId")
        sConsulta.AppendLine("inner join Vendedor ven on AGV.vendedorid=ven.VendedorID")
        sConsulta.AppendLine(sCondicionPre)

        sConsulta.AppendLine("drop table #TmpALM ")


        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        Session("PreliquidacionEfe") = dt

        'Sección Preliquidacion  Depositos y Cheques

        sConsulta = New StringBuilder

        sConsulta.AppendLine("if (select object_id('tempdb..#TmpALM')) is not null drop table #TmpALM ")
        sConsulta.AppendLine("select * into #TmpALM from ( ")
        sConsulta.AppendLine("select ALM.Clave as ClaveCEDI,ALM.Nombre,agv.vendedorid from VenCentroDistHist AGV ")
        sConsulta.AppendLine("INNER JOIN ALMACEN ALM on AGV.AlmacenID = ALM.AlmacenID ")
        sConsulta.AppendLine("where AGV.VCHFechaInicial =( ")
        sConsulta.AppendLine("select top 1 VCHFechaInicial from VenCentroDistHist where vendedorid =AGV.VendedorID order by VCHFechaInicial desc) ) as t1 ")

        sConsulta.AppendLine("declare @Cheque as varchar(16)")
        sConsulta.AppendLine("declare @Deposito as varchar(16)")
        sConsulta.AppendLine("select @Cheque=Descripcion from MENDetalle M where MENClave='XCheque' and M.MEDTipoLenguaje='" + Session("lenguaje") + "' ")
        sConsulta.AppendLine("select @Deposito=Descripcion from MENDetalle M where MENClave='XDeposito' and M.MEDTipoLenguaje='" + Session("lenguaje") + "' ")

        sConsulta.AppendLine("select @Deposito as tipo, M.Nombre As Moneda,AGV.ClaveCedi,P.VendedorId,PB.Total as Importe,PB.Referencia,V.Descripcion as Banco")
        sConsulta.AppendLine("from PreLiquidacion  P")
        sConsulta.AppendLine("inner join PLIBancario  PB on PB.PLIId=P.PLIId")
        sConsulta.AppendLine("inner join VAVDescripcion V on  V.VARCodigo='TBanco' and PB.TipoBanco = V.VAVClave and V.VADTipoLenguaje='" + Session("lenguaje") + "' ")
        sConsulta.AppendLine("inner join Moneda M on M.MonedaID=P.MonedaID")
        sConsulta.AppendLine("inner join #TmpALM AGV on P.VendedorId =AGV.VendedorId")
        sConsulta.AppendLine("inner join Vendedor ven on AGV.vendedorid=ven.VendedorID")
        sConsulta.AppendLine(sCondicionPre)
        sConsulta.AppendLine("union")
        sConsulta.AppendLine("select @Cheque as tipo,M.Nombre as Moneda,AGV.ClaveCedi,AGV.VendedorId,AD.Importe,AD.Referencia,Vav.Descripcion as Banco")
        sConsulta.AppendLine(" from Abono A")
        sConsulta.AppendLine("INNER JOIN Dia ON A.DiaClave = Dia.DiaClave")
        sConsulta.AppendLine("inner join ABNDetalle AD on AD.ABNId=A.ABNId")
        sConsulta.AppendLine("inner join VAVDescripcion Vav on  Vav.VARCodigo='TBanco' and AD.TipoBanco = Vav.VAVClave and Vav.VADTipoLenguaje='" + Session("lenguaje") + "' ")
        sConsulta.AppendLine("inner join Moneda M on M.MonedaID=AD.MonedaID")
        sConsulta.AppendLine("inner join Visita V on V.VisitaClave =A.VisitaClave and V.DiaClave =A.DiaClave")
        sConsulta.AppendLine("inner join #TmpALM AGV on AGV.VendedorId =V.VendedorId")
        sConsulta.AppendLine("inner join Vendedor ven on AGV.vendedorid=ven.VendedorID")
        sConsulta.AppendLine(pvCondicion + "and  AD.TipoPago in (9,2)")

        sConsulta.AppendLine("drop table #TmpALM ")


        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        Session("PreliquidacionDep") = dt


        'sConsulta.AppendLine("SET ANSI_WARNINGS OFF ")
        'sConsulta.AppendLine("Select Notas AS Factura, Folio, FechaHoraAlta as Fecha, TRPTotal, ABNTotal,TipoPago, Referencia, sum(Importe) as Importe ")
        'sConsulta.AppendLine("from(Select TRP.Notas, TRP.Folio, Dia.FechaCaptura as FechaHoraAlta, TRP.Total as TRPTotal, ")
        'sConsulta.AppendLine("isnull((Select sum(ABN.Total) from Abono ABN INNER JOIN Dia ON ABN.DiaClave = DIA.DiaClave inner join ABNTrp on ABNTrp.TransProdID = TRP.TransProdID and ABNTrp.ABNId = ABN.ABNID ")
        'If chboxFecha.Checked Then
        '    sConsulta.AppendLine(strWhereFecha("", "DIA.FechaCaptura"))
        'End If
        'sConsulta.AppendLine("),0) as ABNTotal, VAD.Descripcion as TipoPago, ABD.Referencia, ABD.Importe as Importe ")
        'sConsulta.AppendLine("from TransProd TRP inner join ABNTrp ABT on ABT.TransProdID = TRP.TransProdID and TRP.Tipo = 1 and TRP.TipoFase <>0 ")
        'sConsulta.AppendLine("inner join Abono AB on AB.ABNId = ABT.ABNId ")
        'sConsulta.AppendLine("inner join ABNDetalle ABD on ABD.ABNId = AB.ABNId ")
        'sConsulta.AppendLine("inner join VIsita VIS on VIS.VisitaClave = TRP.VisitaClave ")
        'sConsulta.AppendLine("inner join Vendedor VEN on VEN.VendedorID = VIS.VendedorID ")
        'sConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VARCodigo ='PAGO' and ABD.TipoPago = VAD.VAVClave and VADTipoLenguaje = '" & Session("lenguaje") & "' ")
        'sConsulta.AppendLine("INNER JOIN Dia Dia1 ON TRP.DiaClave = DIA1.DiaClave ")
        'sConsulta.AppendLine("INNER JOIN Dia ON DIA.DiaClave = AB.DiaClave ")
        'sConsulta.AppendLine(pvCondicion & " and DIA1.FechaCaptura<'" & FechaInicioPrimeraHora() & "' ")
        'sConsulta.AppendLine(") as CobranzaAnteriores group by Folio, Notas, FechaHoraAlta, TRPTotal, ABNTotal,TipoPago, Referencia order by Folio ")
        'Session("CobranzaAnteriores") = sConsulta.ToString

        Return True
    End Function

    Private Function ConsultaFolios(ByVal ins As DBConexion.cConexionSQL) As Boolean
        Dim sConsulta As New StringBuilder

        sConsulta.Append("SET ANSI_WARNINGS OFF ")
        sConsulta.Append("set nocount on ")
        sConsulta.Append("DECLARE @tipoCentro bit ")
        sConsulta.Append("IF (Select count(*) from centroExpedicion where TipoEstado = 1 and Tipo = 1) =0 ")
        sConsulta.Append("set @tipoCentro = 0 ")
        sConsulta.Append("Else ")
        sConsulta.Append("set @tipoCentro = 1 ")
        sConsulta.Append("if (select object_id('tempdb..#Dias')) is not null drop table #Dias ")
        sConsulta.Append("Select  TRP.DiaClave , TPD.FolioId , TPD.FOSId, Dia.FechaCaptura into #Dias ")
        sConsulta.Append("from TRPDatoFiscal TPD ")
        sConsulta.Append("inner join TransProd TRP on TPD.TransProdID = TRP.TransProdID ")
        sConsulta.Append("inner join Dia on Dia.DiaClave = TRP.DiaClave ")
        sConsulta.Append("where not TPD.FOSId is null ")
        sConsulta.Append("group by TRP.DiaClave, TPD.FolioId , TPD.FOSId, Dia.FechaCaptura ")
        sConsulta.Append("if (select object_id('tempdb..#UltDoc')) is not null drop table #UltDoc ")
        sConsulta.Append("Select TPD.FOSId, TPD.FolioId, COUNT(*) as NumDocumentos into #UltDoc ")
        sConsulta.Append("from TRPDatoFiscal TPD ")
        sConsulta.Append("inner join TransProd TRP on TPD.TransProdID = TRP.TransProdID ")
        sConsulta.Append("inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave and  VIS.DiaClave  = TRP.DiaClave ")
        sConsulta.Append("where VIS.DiaClave + TPD.FOSId + TPD.FolioId  in ")
        sConsulta.Append("(Select TOP 7 DiaClave + FOSId + FolioId from #Dias  where #Dias.FOSId = TPD.FOSId and #Dias.FolioID = TPD.FolioId order by #Dias.FechaCaptura desc) ")
        sConsulta.Append("group by TPD.FOSId, TPD.FolioId ")
        sConsulta.Append("if (select object_id('tempdb..#FOSHistVigentes')) is not null drop table #FOSHistVigentes ")
        sConsulta.Append("Select FSH.* into #FOSHistVigentes from FOSHist FSH where FSH.FSHFechaInicio =(Select MAX(FSHFechaInicio) from FOSHist where FOSHist.FolioID = FSH.FolioID and FOSHist.FOSId = FSH.FOSId ) ")
        sConsulta.Append("Select CEE.CentroExpID, CEE.Nombre, CEF.NumCertificado, CEF.FechaInicial, CEF.FechaFinal, FOS.Serie, VAD.Descripcion  as TipoComprobante,  USU.Clave as Vendedor ,")
        sConsulta.Append("FHV.Inicio, FHV.Fin, (FHV.Inicio + FOS.Usados) - 1 as FolioActual, isnull(UDO.NumDocumentos, 0) as DoctosSemanal, isnull(ROUND((UDO.NumDocumentos * 1.00)/7,2),0) as PromDiario, ((FHV.Fin + 1) - FHV.Inicio) - FOS.Usados as Disponibles, ")
        sConsulta.Append("isnull(round(((((FHV.Fin + 1) - FHV.Inicio) - FOS.Usados)/ ROUND((UDO.NumDocumentos * 1.00)/7,2)  ),2),0) as DiasFolio, FOS.Aprobacion, FOS.AnioAprobacion,FOS.Usados ")
        sConsulta.Append("from CentroExpedicion CEE ")
        sConsulta.Append("inner join CertificadoFolio CEF on CEE.NumCertificado = CEF.NumCertificado  and CEE.Tipo =  @tipoCentro ")
        sConsulta.Append("inner join #FOSHistVigentes FHV on CEE.NumCertificado = FHV.NumCertificado ")
        sConsulta.Append("inner join FolioSolicitado FOS on FOS.FolioID = FHV.FolioID and FOS.FOSId  = FHV.FOSId ")
        sConsulta.Append("inner join VAVDescripcion VAD on VAD.VARCodigo = 'FOLTIPO' and VAD.VAVClave = FOS.TipoComprobante and VAD.VADTipoLenguaje = '" & Session("lenguaje") & "' ")
        sConsulta.Append("inner join Vendedor VEN on VEN.VendedorID = FHV.VendedorID ")
        sConsulta.Append("inner join Usuario USU on VEN.USUId = USU.USUId ")
        sConsulta.Append("left join #UltDoc UDO on UDO.FolioId = FOS.FolioID and UDO.FOSId = FOS.FOSId  ")
        sConsulta.Append("where GETDATE() between CEF.FechaInicial and CEF.FechaFinal ")
        sConsulta.Append("DROP TABLE #Dias ")
        sConsulta.Append("DROP Table #UltDoc ")
        sConsulta.Append("DROP TABLE #FOSHistVigentes ")
        sConsulta.Append("set nocount off ")

        Dim dt As Data.DataTable
        dt = ins.EjecutarConsulta(sConsulta.ToString, IntCommandTimeOut)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Session("DataTable") = dt

        Return True
    End Function

    'Private Function EjecutarConsultaDataSet(ByVal pvConsultaSQL As String, ByVal ins As DBConexion.cConexionSQL) As Data.DataSet
    '    Dim DataSetRetorno As New Data.DataSet
    '    Try

    '        Dim oDataAdapter As Data.OleDb.OleDbDataAdapter
    '        oDataAdapter = New Data.OleDb.OleDbDataAdapter(pvConsultaSQL, ins.Conexion)
    '        oDataAdapter.SelectCommand.Transaction = ins.ObtenerTran
    '        oDataAdapter.SelectCommand.CommandTimeout = pvTimeOut
    '        oDataAdapter.Fill(DataSetRetorno)
    '        oDataAdapter.Dispose()
    '    Catch ex As Data.OleDb.OleDbException
    '    End Try
    '    Return DataSetRetorno
    'End Function

#End Region

#Region "Condiciones"
    Function ObtenerFecha(ByVal sFecha As String) As Date
        Dim aFecha As String()
        aFecha = sFecha.Split("/")
        Dim dFechaIni As New Date(aFecha(2), aFecha(1), aFecha(0))
        Return dFechaIni
    End Function

    Enum CondicionFecha
        Igual = 0
        Diferente = 1
        MayorQue = 2
        MenorQue = 3
        MayorIgual = 4
        MenorIgual = 5
        Entre = 6
    End Enum

    Function strWhereFecha(ByVal where As String, ByVal campoFecha As String, ByVal pvCondicion As CondicionFecha) As String
        Dim sFecha As String()
        sFecha = txtFInicio.Text.Split("/")
        Dim dFechaIni As New Date(sFecha(2), sFecha(1), sFecha(0))
        Select Case pvCondicion
            Case 0 '=
                where &= " and " & campoFecha & " between '" & dFechaIni.Date.ToString("s") & "' and '" & sFecha(2) & "-" & sFecha(1) & "-" & sFecha(0) & "T23:59:59' "
            Case 1 '<>
                where &= " and CONVERT(nvarchar(10)," & campoFecha & ",126)+'T00:00:00' <> '" & dFechaIni.Date.ToString("s") & "'  "
            Case 2 '>
                where &= " and CONVERT(nvarchar(10)," & campoFecha & ",126)+'T00:00:00' > '" & dFechaIni.Date.ToString("s") & "'  "
            Case 3 '<
                where &= " and CONVERT(nvarchar(10)," & campoFecha & ",126)+'T00:00:00' < '" & dFechaIni.Date.ToString("s") & "'  "
            Case 4 '>=
                where &= " and CONVERT(nvarchar(10)," & campoFecha & ",126)+'T00:00:00' >= '" & dFechaIni.Date.ToString("s") & "'  "
            Case 5 '<=
                where &= " and CONVERT(nvarchar(10)," & campoFecha & ",126)+'T00:00:00' <= '" & dFechaIni.Date.ToString("s") & "'  "
            Case 6 '/
                sFecha = txtFFinal.Text.Split("/")
                Dim dFechaFin As New Date(sFecha(2), sFecha(1), sFecha(0))
                where &= " and CONVERT(nvarchar(10)," & campoFecha & ",126)+'T00:00:00' between '" & dFechaIni.Date.ToString("s") & "' and '" & dFechaFin.Date.ToString("s") & "' "
        End Select
        Return where
    End Function

    Function strWhereFecha(ByVal where As String, ByVal campoFecha As String, Optional ByVal pvEsFecha As Boolean = False) As String
        Dim sFecha As String()
        sFecha = txtFInicio.Text.Split("/")
        Dim dFechaIni As New Date(sFecha(2), sFecha(1), sFecha(0))
        Select Case ddlFecha.SelectedIndex
            Case 0 '=
                If pvEsFecha = False Then
                    where &= " and convert(datetime,Convert(varchar(20)," & campoFecha & ",112)) = '" & dFechaIni.Date.ToString("s") & "' "
                Else
                    where &= " and " & campoFecha & " between '" & dFechaIni.Date.ToString("s") & "' and '" & sFecha(2) & "-" & sFecha(1) & "-" & sFecha(0) & "T23:59:59' "
                End If
            Case 1 '<>
                If pvEsFecha = False Then
                    where &= " and convert(datetime,Convert(varchar(20)," & campoFecha & ",112)) <> '" & dFechaIni.Date.ToString("s") & "' "
                Else
                    where &= " and CONVERT(nvarchar(10)," & campoFecha & ",126)+'T00:00:00' <> '" & dFechaIni.Date.ToString("s") & "'  "
                End If
            Case 2 '>
                If pvEsFecha = False Then
                    where &= " and convert(datetime,Convert(varchar(20)," & campoFecha & ",112)) > '" & dFechaIni.Date.ToString("s") & "' "
                Else
                    where &= " and CONVERT(nvarchar(10)," & campoFecha & ",126)+'T00:00:00' > '" & dFechaIni.Date.ToString("s") & "'  "
                End If
            Case 3 '<
                If pvEsFecha = False Then
                    where &= " and convert(datetime,Convert(varchar(20)," & campoFecha & ",112)) < '" & dFechaIni.Date.ToString("s") & "' "
                Else
                    where &= " and CONVERT(nvarchar(10)," & campoFecha & ",126)+'T00:00:00' < '" & dFechaIni.Date.ToString("s") & "'  "
                End If
            Case 4 '>=
                If pvEsFecha = False Then
                    where &= " and convert(datetime,Convert(varchar(20)," & campoFecha & ",112)) >= '" & dFechaIni.Date.ToString("s") & "' "
                Else
                    where &= " and CONVERT(nvarchar(10)," & campoFecha & ",126)+'T00:00:00' >= '" & dFechaIni.Date.ToString("s") & "'  "
                End If
            Case 5 '<=
                If pvEsFecha = False Then
                    where &= " and convert(datetime,Convert(varchar(20)," & campoFecha & ",112)) <= '" & dFechaIni.Date.ToString("s") & "' "
                Else
                    where &= " and CONVERT(nvarchar(10)," & campoFecha & ",126)+'T00:00:00' <= '" & dFechaIni.Date.ToString("s") & "'  "
                End If
            Case 6 '/
                sFecha = txtFFinal.Text.Split("/")
                Dim dFechaFin As New Date(sFecha(2), sFecha(1), sFecha(0))
                If pvEsFecha = False Then
                    where &= " and convert(datetime,Convert(varchar(20)," & campoFecha & ",112)) between '" & dFechaIni.Date.ToString("s") & "' and '" & dFechaFin.Date.ToString("s") & "' "
                Else
                    where &= " and CONVERT(nvarchar(10)," & campoFecha & ",126)+'T00:00:00' between '" & dFechaIni.Date.ToString("s") & "' and '" & dFechaFin.Date.ToString("s") & "' "
                End If
        End Select
        Return where
    End Function

    Function FechaFinUltimaHora() As String
        Dim sFecha As String()
        sFecha = txtFFinal.Text.Split("/")
        Dim dFechaFin As New Date(sFecha(2), sFecha(1), sFecha(0), 23, 59, 59)
        Return dFechaFin.ToString("s")
    End Function

    Function FechaInicioPrimeraHora() As String
        Dim sFecha As String()
        sFecha = txtFInicio.Text.Split("/")
        Dim dFechaIni As New Date(sFecha(2), sFecha(1), sFecha(0), 0, 0, 0)
        Return dFechaIni.ToString("s")
    End Function

    Function strWhereFechaPremios(ByVal where As String) As String
        Dim sFecha As String()
        sFecha = txtFInicio.Text.Split("/")
        Dim dFechaIni As New Date(sFecha(2), sFecha(1), sFecha(0))
        If (chboxFecha.Checked = False) Then
        ElseIf ddlFecha.SelectedIndex = 6 Then 'cuando seleccionen "ENTRE" fecha1 y fecha2
            If (CheckFechas()) Then
                sFecha = txtFFinal.Text.Split("/")
                Dim dFechaFin As New Date(sFecha(2), sFecha(1), sFecha(0))
                where = "where "
                where &= "'" & dFechaIni.Date.ToString("s") & "' <= convert(datetime, convert(varchar(20), CAD.FechaInicial, 112)) and "
                where &= "'" & dFechaFin.Date.ToString("s") & "' >= convert(datetime, convert(varchar(20), CAD.FechaInicial, 112)) "
            End If
        ElseIf ddlFecha.SelectedIndex = 0 Then
            where = "where "
            where &= "(convert(datetime, convert(varchar(20), CAD.FechaInicial, 112)) > '" & dFechaIni.Date.ToString("s") & "' or convert(datetime, convert(varchar(20), CAR.FechaInicial, 112)) = '" & dFechaIni.Date.ToString("s") & "') "
            where &= "and (convert(datetime, convert(varchar(20), CAD.FechaFinal, 112)) < '" & dFechaIni.Date.ToString("s") & "' or convert(datetime, convert(varchar(20), CAR.FechaInicial, 112)) = '" & dFechaIni.Date.ToString("s") & "') "
        ElseIf ddlFecha.SelectedIndex = 1 Then
            where = "where "
            where &= "convert(datetime, convert(varchar(20), CAD.FechaInicial, 112)) < '" & dFechaIni.Date.ToString("s") & "' "
            where &= "and convert(datetime, convert(varchar(20), CAD.FechaFinal, 112)) > '" & dFechaIni.Date.ToString("s") & "' "
        ElseIf ddlFecha.SelectedIndex = 2 Then
            where = "where "
            where &= "convert(datetime, convert(varchar(20), CAD.FechaInicial, 112)) > '" & dFechaIni.Date.ToString("s") & "' "
        ElseIf ddlFecha.SelectedIndex = 3 Then
            where = "where "
            where &= "convert(datetime, convert(varchar(20), CAD.FechaFinal, 112)) < '" & dFechaIni.Date.ToString("s") & "' "
        ElseIf ddlFecha.SelectedIndex = 4 Then
            where = "where "
            where &= "convert(datetime, convert(varchar(20), CAD.FechaInicial, 112)) >= '" & dFechaIni.Date.ToString("s") & "' "
        ElseIf ddlFecha.SelectedIndex = 5 Then
            where = "where "
            where &= "convert(datetime, convert(varchar(20), CAD.FechaFinal, 112)) <= '" & dFechaIni.Date.ToString("s") & "' "
        End If
        Return where
    End Function

    Function strWhereClientes(ByVal where As String, ByVal clientes As ArrayList, ByVal campoCliente As String) As String
        If (clientes.Count > 0) Then
            where &= " and " & campoCliente & " in ("
            For i As Integer = 0 To clientes.Count - 1
                where &= "'" & clientes(i).ToString.Replace("'", "''") & "',"
            Next
            where = where.Remove(where.Length - 1, 1)
            where &= ") "
        End If

        Return where
    End Function

    Function strWhereRutas(ByVal where As String, ByVal rutas As ArrayList, ByVal campoRuta As String) As String
        If (rutas.Count > 0) Then
            where &= " and " & campoRuta & " in ("
            For i As Integer = 0 To rutas.Count - 1
                where &= "'" & rutas(i).ToString.Replace("'", "''") & "',"
            Next
            where = where.Remove(where.Length - 1, 1)
            where &= ") "
        End If

        Return where
    End Function

    Function strWhereEsquema(ByVal where As String, ByVal Esquemas As ArrayList, ByVal campoEsquema As String) As String
        If (Esquemas.Count > 0) Then
            where &= " and " & campoEsquema & " in ("
            For i As Integer = 0 To Esquemas.Count - 1
                where &= "'" & Esquemas(i).ToString.Replace("'", "''") & "',"
            Next
            where = where.Remove(where.Length - 1, 1)
            where &= ") "
        End If

        Return where
    End Function

    Function strWhereCentrosDistribucion(ByVal where As String, ByVal campoAlmacen As String) As String
        If (ChBoxCentroDistribucion.Checked) Then
            where += " and " & campoAlmacen & " = '" + DdlCentroDistribucion.SelectedValue + "' "
        End If
        Return where
    End Function

    Function strWhereActivos(ByVal where As String, ByVal Activos As ArrayList, ByVal campoCliente As String) As String
        If (Activos.Count > 0) Then
            where &= " and " & campoCliente & " in ("
            For i As Integer = 0 To Activos.Count - 1
                where &= "'" & Activos(i).ToString.Replace("'", "''") & "',"
            Next
            where = where.Remove(where.Length - 1, 1)
            where &= ") "
        End If

        Return where
    End Function
#End Region

    Protected Sub tvEsquema_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ins As New DBConexion.cConexionSQL()
        Dim Mensaje As New DBConexion.cMensaje

        'GuardaChecksRutas()
        Dim dat As Data.DataTable
        Dim aRutas As ArrayList = GetRutas()
        Dim sRutas As String = ""
        If aRutas.Count > 0 Then
            For Each sRuta As String In aRutas
                If sRutas = "" Then
                    sRutas = "'" & sRuta.Replace("'", "''") & "'"
                Else
                    sRutas = sRutas & ",'" & sRuta.Replace("'", "''") & "'"
                End If
            Next
        End If

        If tvEsquema.SelectedNode Is Nothing Then
            GridEXCliente.Visible = False
            Label3.Visible = False
            UpdatePanel1.Update()
            UpdatePanel8.Update()
            Exit Sub

        Else
            If (tvEsquema.SelectedNode.Text = Mensaje.RecuperarDescripcion("XTodos")) Then
                If aRutas.Count > 0 Then
                    dat = ins.EjecutarConsulta("SELECT distinct c.ClienteClave,c.Clave,C.RazonSocial  FROM Cliente C inner join ClienteEsquema D on C.ClienteClave = D.ClienteClave inner join esquema E on D.EsquemaID = E.EsquemaID and E.tipo=1 inner join Secuencia S on S.ClienteClave=C.ClienteClave AND S.RUTClave IN (" & sRutas & ")")
                Else
                    dat = ins.EjecutarConsulta("SELECT distinct c.ClienteClave,c.Clave,C.RazonSocial  FROM Cliente C inner join ClienteEsquema D on C.ClienteClave = D.ClienteClave inner join esquema E on D.EsquemaID = E.EsquemaID and E.tipo=1")
                End If
            Else
                If aRutas.Count > 0 Then
                    dat = ins.EjecutarConsulta("SELECT distinct c.ClienteClave,c.Clave,C.RazonSocial FROM Cliente C inner join ClienteEsquema D on C.ClienteClave = D.ClienteClave inner join esquema E on D.EsquemaID = E.EsquemaID and E.tipo=1 inner join Secuencia S on S.ClienteClave=C.ClienteClave AND S.RUTClave IN (" & sRutas & ") WHERE E.EsquemaID ='" & tvEsquema.SelectedNode.Value & "'")
                Else
                    dat = ins.EjecutarConsulta("SELECT distinct c.ClienteClave,c.Clave,C.RazonSocial FROM Cliente C inner join ClienteEsquema D on C.ClienteClave = D.ClienteClave inner join esquema E on D.EsquemaID = E.EsquemaID and E.tipo=1 WHERE E.EsquemaID ='" & tvEsquema.SelectedNode.Value & "'")
                End If
            End If
        End If
        'dat.Columns.Add(New Data.DataColumn("checks", GetType(Boolean)))
        Session("tblClientes") = dat
        'GridView2.Columns(2).HeaderText = mensaje.RecuperarDescripcion("Xcliente")
        'GridView2.PageIndex = 0
        'GridView2.DataSource = dat
        'GridView2.DataBind()
        If (dat.Rows.Count > 0) Then
            GridEXCliente.Visible = True
            Label3.Visible = True
        Else
            GridEXCliente.Visible = False
            Label3.Visible = False
        End If
        GridEXCliente.DataSource = dat
        GridEXCliente.DataBind()
        UpdatePanel8.Update()
        If dat.Rows.Count = 0 Then
            Dim strError As String = ins.EjecutarComandoScalar("SELECT Descripcion from mendetalle where menclave = 'E0485' and MEDTipoLenguaje ='" + Session("lenguaje") + "'")
            lbError.Text = strError
            'CheckTodosClientes.Visible = False
        Else
            lbError.Text = String.Empty
            'CheckTodosClientes.Visible = True
            'CheckTodosClientes.Checked = False
        End If
        'ins.Desconectar()
        'UpdatePanel8.Update()
        UpdatePanel9.Update()
        UpdatePanel1.Update()
    End Sub

    Protected Sub tvEncuesta_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'If Not tvEncuesta.SelectedNode.Parent Is Nothing Then
        '    Session("CENClave") = tvEncuesta.SelectedNode.Value
        'Else
        '    Session("CENClave") = Nothing
        'End If
    End Sub

End Class
