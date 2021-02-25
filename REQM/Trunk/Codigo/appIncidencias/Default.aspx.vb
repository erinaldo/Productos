Imports AmesolREQMLog
Partial Public Class wfrmFormularioReq
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            fillCombos()
            btnCancelar.Attributes.Add("onclick", "javascript:return confirm('La informacion se perdera, esta seguro?');")

            If Not Request.QueryString("ID") = String.Empty Then
                lblNota.Visible = True
                txtEditNota.Visible = True
                llenarForma()
            End If


        End If
        If Not IsNothing(Session("Tabla")) Then
            If Not Session("Values").rows.count = 0 Then
                FillLists()
            End If
        End If


    End Sub
    Private Sub llenarForma()
        Try

            Dim oRequerimiento As New clsRequerimiento(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            oRequerimiento.ID = Request.QueryString("ID")
            oRequerimiento.llenarObjeto()
            ddlProducto.Items.FindByValue(oRequerimiento.Producto).Selected = True
            ddlProyecto.Items.FindByValue(oRequerimiento.Proyecto).Selected = True
            ddlFuncionalidad.Items.FindByValue(oRequerimiento.Funcionalidad).Selected = True
            txtFuente.Text = oRequerimiento.Fuente
            txtRequerimiento.Text = oRequerimiento.Descripcion
            ddlEstado.Items.FindByValue(oRequerimiento.Estado).Selected = True
            ddlPrioridad.Items.FindByValue(oRequerimiento.Prioridad).Selected = True

            fillVersions(ddlProducto.SelectedValue, True)

            Dim oCliente As New clsCliente(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            lbClientes.DataSource = oCliente.ObtenerDatos(Request.QueryString("ID"))
            lbClientes.DataTextField = "Nombre"
            lbClientes.DataValueField = "iClienteID"
            lbClientes.DataBind()

            Dim oModulo As New clsModulo(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            lbModulos.DataSource = oModulo.ObtenerDatos(Request.QueryString("ID"))
            lbModulos.DataTextField = "vchNombre"
            lbModulos.DataValueField = "iModuloID"
            lbModulos.DataBind()

            Dim oCasoPrueba As New clsCasoPrueba(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            lbCasoPrueba.DataSource = oCasoPrueba.ObtenerDatos(Request.QueryString("ID"))
            lbCasoPrueba.DataTextField = "vchNombre"
            lbCasoPrueba.DataValueField = "iCasoPruebaID"
            lbCasoPrueba.DataBind()

            Dim oCasoUso As New clsCasoUso(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            Dim dt As DataTable = oCasoUso.ObtenerDatos(Request.QueryString("ID"))
            Dim dc As New DataColumn("Descripcion", GetType(String))
            dc.Expression = "vchNombre + ' ' + ISNULL(vchDescripcion, '')"
            dt.Columns.Add(dc)
            lbCasoUso.DataSource = dt
            lbCasoUso.DataTextField = "Descripcion"
            lbCasoUso.DataValueField = "iCasoUsoID"
            lbCasoUso.DataBind()

            Dim oEspecificacion As New clsEspecificacion(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            lbEspecificacion.DataSource = oEspecificacion.ObtenerDatos(Request.QueryString("ID"))
            lbEspecificacion.DataTextField = "vchNombre"
            lbEspecificacion.DataValueField = "iEspecificacionID"
            lbEspecificacion.DataBind()

            Dim oComponente As New clsComponente(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            lbComponentes.DataSource = oComponente.ObtenerDatos(Request.QueryString("ID"))
            lbComponentes.DataTextField = "vchNombre"
            lbComponentes.DataValueField = "iComponenteID"
            lbComponentes.DataBind()

            lbFolios.DataSource = oRequerimiento.obtenerFolios(Request.QueryString("ID"))
            lbFolios.DataTextField = "iFolio"
            lbFolios.DataValueField = "iFolio"
            lbFolios.DataBind()

        Catch ex As Exception
            showERROR(ex.Message, "llenarForma")
        End Try
    End Sub
    Private Sub ddlProducto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlProducto.SelectedIndexChanged
        Try
            'lbVersions.Items.Clear()
            'lbSelectedVer.Items.Clear()

            fillVersions(ddlProducto.SelectedValue)

        Catch ex As Exception
            showERROR(ex.Message, "ddlProducto_SelectedIndexChanged")
        End Try
    End Sub
    Private Sub fillCombos()
        Try
            ddlPrioridad.Items.Clear()
            ddlPrioridad.Items.Add(New ListItem("Alto", "3"))
            ddlPrioridad.Items.Add(New ListItem("Medio", "2"))
            ddlPrioridad.Items.Add(New ListItem("Bajo", "1"))

            ddlEstado.Items.Clear()
            ddlEstado.Items.Add(New ListItem("Finalizado", "3"))
            ddlEstado.Items.Add(New ListItem("En proceso", "2"))
            ddlEstado.Items.Add(New ListItem("Cancelado", "1"))

            ddlProducto.DataSource = AmesolREQMLog.clsUtil.fillCombo("Producto", "vchNombre", "iProductoID", ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString(), "vchNombre")
            ddlProducto.DataValueField = "Value"
            ddlProducto.DataTextField = "Text"
            ddlProducto.DataBind()
            Dim it As New ListItem("Seleccione uno", 0)
            ddlProducto.Items.Insert(0, it)

            ddlProyecto.DataSource = AmesolREQMLog.clsUtil.fillCombo("Proyecto", "vchNombre", "iProyectoID", ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString(), "vchNombre")
            ddlProyecto.DataValueField = "Value"
            ddlProyecto.DataTextField = "Text"
            ddlProyecto.DataBind()
            'Dim it2 As New ListItem("Seleccione uno", 0)
            ddlProyecto.Items.Insert(0, it)

            ddlFuncionalidad.DataSource = AmesolREQMLog.clsUtil.fillCombo("Funcionalidad", "vchNombre", "iFuncionalidadID", ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString(), "vchNombre")
            ddlFuncionalidad.DataValueField = "Value"
            ddlFuncionalidad.DataTextField = "Text"
            ddlFuncionalidad.DataBind()
            'Dim it3 As New ListItem("Seleccione uno", 0)
            ddlFuncionalidad.Items.Insert(0, it)

            gvVersiones.DataBind()
        Catch ex As Exception
            showERROR(ex.Message, "fillCombos")
        End Try
    End Sub
    Private Sub FillLists()
        Try
            Select Case Session("Tabla").ToString.ToUpper
                Case "CASOUSO"
                    lbCasoUso.DataSource = Session("Values")
                    lbCasoUso.DataTextField = "Text"
                    lbCasoUso.DataValueField = "Value"
                    lbCasoUso.DataBind()
                    'Session("CasoUso") = Nothing
                Case "CASOPRUEBA"
                    lbCasoPrueba.DataSource = Session("Values")
                    lbCasoPrueba.DataTextField = "Text"
                    lbCasoPrueba.DataValueField = "Value"
                    lbCasoPrueba.DataBind()
                    'Session("CasoPrueba") = Nothing
                Case "ESPECIFICACION"
                    lbEspecificacion.DataSource = Session("Values")
                    lbEspecificacion.DataTextField = "Text"
                    lbEspecificacion.DataValueField = "Value"
                    lbEspecificacion.DataBind()
                    'Session("Especificacion") = Nothing
                Case "COMPONENTE"
                    lbComponentes.DataSource = Session("Values")
                    lbComponentes.DataTextField = "Text"
                    lbComponentes.DataValueField = "Value"
                    lbComponentes.DataBind()
                Case "MODULO"
                    lbModulos.DataSource = Session("Values")
                    lbModulos.DataTextField = "Text"
                    lbModulos.DataValueField = "Value"
                    lbModulos.DataBind()
                Case "CLIENTE"
                    lbClientes.DataSource = Session("Values")
                    lbClientes.DataTextField = "Text"
                    lbClientes.DataValueField = "Value"
                    lbClientes.DataBind()
            End Select
            'Session("Values") = Nothing
            Session("Tabla") = String.Empty
        Catch ex As Exception
            showERROR(ex.Message, "FillLists")
        End Try
    End Sub
    Private Sub fillVersions(ByVal ProductID As Integer, Optional ByVal isEdit As Boolean = False)
        Try
            Dim oVersion As New clsVersion(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            If isEdit Then

                gvVersiones.DataSource = oVersion.obtenerVersiones(ProductID, Request.QueryString("ID"))
                'lbVersions.DataSource = oVersion.obtenerVersiones(ProductID, Request.QueryString("ID"))
                'lbSelectedVer.DataSource = oVersion.ObtenerVersionesActivas(ProductID, Request.QueryString("ID"))
                'lbSelectedVer.DataTextField = "Version"
                'lbSelectedVer.DataValueField = "ID"
                'lbSelectedVer.DataBind()
            Else
                gvVersiones.DataSource = oVersion.obtenerVersiones(ProductID)
                'lbVersions.DataSource = oVersion.obtenerVersiones(ProductID)
            End If
            gvVersiones.DataBind()

            'lbVersions.DataTextField = "Version"
            'lbVersions.DataValueField = "ID"
            'lbVersions.DataBind()
        Catch ex As Exception
            showERROR(ex.Message, "fillVersions")
        End Try
    End Sub
    Private Sub clearInfo()
        Try

            ddlProducto.SelectedIndex = 0
            ddlProyecto.SelectedIndex = 0
            ddlFuncionalidad.SelectedIndex = 0
            ddlEstado.SelectedIndex = 0
            ddlPrioridad.SelectedIndex = 0

            txtFuente.Text = String.Empty
            txtRequerimiento.Text = String.Empty

            lbClientes.Items.Clear()
            lbModulos.Items.Clear()
            lbCasoPrueba.Items.Clear()
            lbCasoUso.Items.Clear()
            lbEspecificacion.Items.Clear()
            lbComponentes.Items.Clear()
            lbFolios.Items.Clear()

        Catch ex As Exception
            showERROR(ex.Message, "clearInfo")
        End Try
    End Sub

    Protected Sub ibSearchCliente_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibSearchCliente.Click
        Try
            ScriptManager.RegisterStartupScript(Page, Page.GetType, "pop", "var oReturnValue = window.showModalDialog('popMultipleSelection.aspx?Tabla=Cliente', '','dialogHeight:500,dialogWidth:600,resizable:no, scroll:yes,status:no'); __doPostBack('UpdatePanel13', ''); ", True)
        Catch ex As Exception
            showERROR(ex.Message, "ibSearchCliente")
        End Try

    End Sub

    Protected Sub ibSearchModulo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibSearchModulo.Click
        Try
            ScriptManager.RegisterStartupScript(Page, Page.GetType, "pop", "var oReturnValue = window.showModalDialog('popMultipleSelection.aspx?Tabla=Modulo', '','dialogHeight:500,dialogWidth:600,resizable:no, scroll:yes,status:no'); __doPostBack('updListModulo', ''); ", True)
        Catch ex As Exception
            showERROR(ex.Message, "ibSearchModulo")
        End Try
    End Sub

    Protected Sub ibSearchCU_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibSearchCU.Click
        Try
            ScriptManager.RegisterStartupScript(Page, Page.GetType, "pop", "var oReturnValue = window.showModalDialog('popMultipleSelection.aspx?Tabla=CasoUso', '','dialogHeight:500,dialogWidth:600,resizable:no, scroll:yes,status:no'); __doPostBack('UpdatePanel4', ''); ", True)
        Catch ex As Exception
            showERROR(ex.Message, "ibSearchCU")
        End Try
    End Sub
    Protected Sub ibSearchCP_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibSearchCP.Click
        Try
            ScriptManager.RegisterStartupScript(Page, Page.GetType, "pop", "var oReturnValue = window.showModalDialog('popMultipleSelection.aspx?Tabla=CasoPrueba', '','dialogHeight:500,dialogWidth:600,resizable:no, scroll:yes,status:no'); __doPostBack('UpdatePanel8', '');", True)

        Catch ex As Exception
            showERROR(ex.Message, "SearchCP")
        End Try
    End Sub
    Protected Sub ibSearchCO_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibSearchCO.Click
        Try
            ScriptManager.RegisterStartupScript(Page, Page.GetType, "pop", "var oReturnValue = window.showModalDialog('popMultipleSelection.aspx?Tabla=Componente', '','dialogHeight:500,dialogWidth:600,resizable:no, scroll:yes,status:no'); __doPostBack('UpdatePanel6', '');", True)

        Catch ex As Exception
            showERROR(ex.Message, "SearchCO")
        End Try
    End Sub
    Protected Sub ibSearchE_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibSearchE.Click
        Try
            ScriptManager.RegisterStartupScript(Page, Page.GetType, "pop", "var oReturnValue = window.showModalDialog('popMultipleSelection.aspx?Tabla=Especificacion', '','dialogHeight:500,dialogWidth:600,resizable:no, scroll:yes,status:no'); __doPostBack('UpdatePane10', '');", True)

        Catch ex As Exception
            showERROR(ex.Message, "SearchE")
        End Try
    End Sub
    Protected Sub ibAddCliente_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibAddCliente.Click
        Try
            Dim it As New ListItem
            Dim item As String() = txtNewCliente.Text.Split(New Char() {"|"c})
            it.Text = item(0).Trim
            it.Value = item(1).Trim
            If Not lbClientes.Items.Contains(it) Then
                lbClientes.Items.Add(it)
            End If

            txtNewCliente.Text = String.Empty
            txtNewCliente.Focus()

        Catch ex As Exception
            showERROR(ex.Message, "AddComponente")
        End Try
    End Sub
    Protected Sub ibAddModulo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibAddModulo.Click
        Try
            Dim it As New ListItem
            Dim item As String() = txtNewModulo.Text.Split(New Char() {"|"c})
            it.Text = item(0).Trim
            it.Value = item(1).Trim
            If Not lbModulos.Items.Contains(it) Then
                lbModulos.Items.Add(it)
            End If

            txtNewModulo.Text = String.Empty
            txtNewModulo.Focus()

        Catch ex As Exception
            showERROR(ex.Message, "AddComponente")
        End Try
    End Sub
    Protected Sub ibAddFolio_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibAddFolio.Click
        Try
            If Not txtFolio.Text = String.Empty Then
                Dim it As New ListItem(txtFolio.Text.Trim)
                If Not lbFolios.Items.Contains(it) Then
                    lbFolios.Items.Add(txtFolio.Text.Trim)
                End If

                txtFolio.Text = String.Empty
                txtFolio.Focus()

            End If
        Catch ex As Exception
            showERROR(ex.Message, "AddFolio")
        End Try
    End Sub
    Protected Sub ibAddComponente_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibAddComponente.Click
        Try
            Dim it As New ListItem
            Dim item As String() = txtNewComponente.Text.Split(New Char() {"|"c})
            it.Text = item(0).Trim
            it.Value = item(1).Trim
            If Not lbComponentes.Items.Contains(it) Then
                lbComponentes.Items.Add(it)
            End If

            txtNewComponente.Text = String.Empty
            txtNewComponente.Focus()

        Catch ex As Exception
            showERROR(ex.Message, "AddComponente")
        End Try
    End Sub
    Protected Sub ibAddCasoUso_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibAddCasoUso.Click
        Try
            Dim it As New ListItem
            Dim item As String() = txtNewCasoUso.Text.Split(New Char() {"|"c})
            it.Text = item(0).Trim
            it.Value = item(1).Trim
            If Not lbCasoUso.Items.Contains(it) Then
                lbCasoUso.Items.Add(it)
            End If

            txtNewCasoUso.Text = String.Empty
            txtNewCasoUso.Focus()
        Catch ex As Exception
            showERROR(ex.Message, "AddCasoUso")
        End Try
    End Sub
    Protected Sub ibAddCasoPrueba_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibAddCasoPrueba.Click
        Try
            Dim it As New ListItem
            Dim item As String() = txtNewCasoPrueba.Text.Split(New Char() {"|"c})
            it.Text = item(0).Trim
            it.Value = item(1).Trim
            If Not lbCasoPrueba.Items.Contains(it) Then
                lbCasoPrueba.Items.Add(it)
            End If

            txtNewCasoPrueba.Text = String.Empty
            txtNewCasoPrueba.Focus()

        Catch ex As Exception
            showERROR(ex.Message, "CasoPrueba")
        End Try
    End Sub
    Protected Sub ibAddEspecificacion_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibAddEspecificacion.Click
        Try
            Dim it As New ListItem
            Dim item As String() = txtEspecificacion.Text.Split(New Char() {"|"c})
            it.Text = item(0).Trim
            it.Value = item(1).Trim
            If Not lbEspecificacion.Items.Contains(it) Then
                lbEspecificacion.Items.Add(it)
            End If

            txtEspecificacion.Text = String.Empty
            txtEspecificacion.Focus()
        Catch ex As Exception
            showERROR(ex.Message, "AddEspecificacion")
        End Try
    End Sub
    Protected Sub ibRemoveCasoUso_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibRemoveCasoUso.Click
        Try
            If lbCasoUso.SelectedIndex <> -1 Then
                lbCasoUso.Items.RemoveAt(lbCasoUso.SelectedIndex)
            End If
        Catch ex As Exception
            showERROR(ex.Message, "RemoveCasoUso")
        End Try
    End Sub
    Protected Sub ibRemoveComponente_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibRemoveComponente.Click
        Try
            If lbComponentes.SelectedIndex <> -1 Then
                lbComponentes.Items.RemoveAt(lbComponentes.SelectedIndex)
            End If
        Catch ex As Exception
            showERROR(ex.Message, "RemoveComponente")
        End Try
    End Sub
    Protected Sub ibRemoveCasoPrueba_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibRemoveCasoPrueba.Click
        Try
            If lbCasoPrueba.SelectedIndex <> -1 Then
                lbCasoPrueba.Items.RemoveAt(lbCasoPrueba.SelectedIndex)
            End If
        Catch ex As Exception
            showERROR(ex.Message, "RemoveCasoPrueba")
        End Try
    End Sub
    Protected Sub ibRemoveEspecificacion_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibRemoveEspecificacion.Click
        Try
            If lbEspecificacion.SelectedIndex <> -1 Then
                lbEspecificacion.Items.RemoveAt(lbEspecificacion.SelectedIndex)
            End If
        Catch ex As Exception
            showERROR(ex.Message, "RemoveEspecificacion")
        End Try
    End Sub


    Protected Sub ibRemoveCliente_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibRemoveCliente.Click
        Try
            If lbClientes.SelectedIndex <> -1 Then
                lbClientes.Items.RemoveAt(lbClientes.SelectedIndex)
            End If
        Catch ex As Exception
            showERROR(ex.Message, "RemoveCliente")
        End Try
    End Sub
    Protected Sub ibRemoveModulo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibRemoveModulo.Click
        Try
            If lbModulos.SelectedIndex <> -1 Then
                lbModulos.Items.RemoveAt(lbModulos.SelectedIndex)
            End If
        Catch ex As Exception
            showERROR(ex.Message, "RemoveModulo")
        End Try
    End Sub
    Protected Sub ibRemoveFolio_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibRemoveFolio.Click
        Try
            If lbFolios.SelectedIndex <> -1 Then
                lbFolios.Items.RemoveAt(lbFolios.SelectedIndex)
            End If
        Catch ex As Exception
            showERROR(ex.Message, "RemoveFolio")
        End Try
    End Sub
    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAceptar.Click
        Try
            Dim oRequerimiento As New clsRequerimiento(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            oRequerimiento.Proyecto = ddlProyecto.SelectedValue
            oRequerimiento.Producto = ddlProducto.SelectedValue
            oRequerimiento.Prioridad = Convert.ToInt16(ddlPrioridad.SelectedValue)
            oRequerimiento.Estado = Convert.ToInt16(ddlEstado.SelectedValue)
            oRequerimiento.Funcionalidad = ddlFuncionalidad.SelectedValue
            oRequerimiento.Descripcion = txtRequerimiento.Text
            oRequerimiento.Fuente = txtFuente.Text

            If Request.QueryString("ID") = String.Empty Then

                oRequerimiento.InsertarReq()
            Else
                oRequerimiento.ID = Request.QueryString("ID")
                oRequerimiento.EditarReq(txtEditNota.Text.Trim)
            End If


            obtenerTablasRelaciones(oRequerimiento)

            If oRequerimiento.actualizarRelaciones() Then


                If Not Request.QueryString("ID") = String.Empty Then
                    ScriptManager.RegisterStartupScript(Page, Page.GetType, "done", "alert('El requerimiento se ha editado exitosamente con un ID:" & oRequerimiento.ID & "'); window.location.href('Catalogos/catRequerimiento.aspx');", True)

                Else
                    ScriptManager.RegisterStartupScript(Page, Page.GetType, "done", "alert('El requerimiento se ha creado exitosamente con un ID:" & oRequerimiento.ID & "');", True)
                    'clearInfo()
                End If

            Else
                Throw New Exception("Se ha producido un error al agregar las relaciones del request, ningun cambio sera realizado en la base de datos!!!")
            End If


        Catch ex As Exception
            showERROR(ex.Message, "Agregar/Editar registro")
        End Try
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            If Request.QueryString("ID") = String.Empty Then
                clearInfo()
            Else
                ScriptManager.RegisterStartupScript(Page, Page.GetType, "return", "javascript:window.location.href('../Catalogos/catRequerimiento.aspx')", True)
            End If

        Catch ex As Exception
            showERROR(ex.Message, "Cancelar")
        End Try
    End Sub
    Private Sub obtenerTablasRelaciones(ByVal oRequerimiento As clsRequerimiento)
        'FillLists()
        Try
            Dim CP As New DataTable("CP")
            Dim CU As New DataTable("CU")
            Dim CO As New DataTable("CO")
            Dim E As New DataTable("E")
            Dim V As New DataTable("V")
            Dim F As New DataTable("F")
            Dim C As New DataTable("C")
            Dim M As New DataTable("M")

            CP.Columns.Add("CasoPruebaID")
            CU.Columns.Add("CasoUsoID")
            CO.Columns.Add("ComponenteID")
            E.Columns.Add("EspecificacionID")
            F.Columns.Add("FolioID")
            V.Columns.Add("VersionID")
            V.Columns.Add("StatusID")
            M.Columns.Add("ModuloID")
            C.Columns.Add("ClienteID")

            For Each i As ListItem In lbFolios.Items

                Dim r As DataRow = F.NewRow()
                r.Item(0) = i.Value
                F.Rows.Add(r)
            Next
            If F.Rows.Count > 0 Then
                oRequerimiento.Folios = F
            End If


            For Each i As ListItem In lbCasoPrueba.Items

                Dim r As DataRow = CP.NewRow()
                r.Item(0) = i.Value
                CP.Rows.Add(r)
            Next
            If CP.Rows.Count > 0 Then
                oRequerimiento.CasosPrueba = CP
            End If

            For Each i As ListItem In lbCasoUso.Items

                Dim r As DataRow = CU.NewRow()
                r.Item(0) = i.Value
                CU.Rows.Add(r)
            Next
            If CU.Rows.Count > 0 Then
                oRequerimiento.CasosUso = CU
            End If

            For Each i As ListItem In lbComponentes.Items

                Dim r As DataRow = CO.NewRow()
                r.Item(0) = i.Value
                CO.Rows.Add(r)
            Next
            If CO.Rows.Count > 0 Then
                oRequerimiento.Componentes = CO
            End If

            For Each i As ListItem In lbEspecificacion.Items

                Dim r As DataRow = E.NewRow()
                r.Item(0) = i.Value
                E.Rows.Add(r)
            Next
            If E.Rows.Count > 0 Then
                oRequerimiento.Especificaciones = E
            End If
            For Each dr As GridViewRow In gvVersiones.Rows
                Dim r As DataRow = V.NewRow()
                If CType(dr.FindControl("chkAsignado"), CheckBox).Checked Then
                    r.Item("StatusID") = CType(dr.FindControl("ddlStatus"), DropDownList).SelectedValue
                    r.Item("VersionID") = CType(dr.FindControl("lblVersionID"), Label).Text
                    V.Rows.Add(r)
                End If
            Next
            If V.Rows.Count > 0 Then
                oRequerimiento.Versiones = V
            End If

            For Each i As ListItem In lbModulos.Items
                Dim r As DataRow = M.NewRow()
                r.Item(0) = i.Value
                M.Rows.Add(r)
            Next
            If M.Rows.Count > 0 Then
                oRequerimiento.Modulos = M
            End If

            For Each i As ListItem In lbClientes.Items
                Dim r As DataRow = C.NewRow()
                r.Item(0) = i.Value
                C.Rows.Add(r)
            Next
            If C.Rows.Count > 0 Then
                oRequerimiento.Clientes = C
            End If

        Catch ex As Exception
            showERROR(ex.Message, "ObtenerTablasRelaciones")
        End Try
    End Sub

    Protected Sub chkAll_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        For Each dr As GridViewRow In gvVersiones.Rows
            If dr.RowType = DataControlRowType.DataRow Then
                If sender.checked Then
                    CType(dr.FindControl("chkAsignado"), CheckBox).Checked = True
                Else
                    CType(dr.FindControl("chkAsignado"), CheckBox).Checked = False
                End If

            End If
        Next
    End Sub
    Private Sub showERROR(ByVal msg As String, ByVal metodo As String)
        ScriptManager.RegisterStartupScript(Page, Page.GetType, "Error", "alert('" & msg & " in " & metodo & "');", True)
    End Sub





End Class