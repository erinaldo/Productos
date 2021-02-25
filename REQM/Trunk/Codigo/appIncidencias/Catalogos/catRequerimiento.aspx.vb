Imports AmesolREQMLog

Partial Public Class catRequerimiento
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            fillGrid()
            fillCombos()
        End If

    End Sub

    Private Sub gvRequerimientos_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvRequerimientos.PageIndexChanged

    End Sub

    Private Sub gvRequerimientos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvRequerimientos.PageIndexChanging
        gvRequerimientos.PageIndex = e.NewPageIndex
        fillGrid()
    End Sub

    Private Sub gvRequerimientos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvRequerimientos.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                CType(e.Row.FindControl("lnkHistorial"), LinkButton).Attributes.Add("onclick", "javascript:var oReturnValue = window.showModalDialog('popHistory.aspx?ID=" & gvRequerimientos.DataKeys.Item(e.Row.RowIndex).Value & "','','dialogHeight:500,dialogWidth:600,resizable:no, scroll:yes,status:no');")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gvRequerimientos_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvRequerimientos.RowEditing
        Try
            Response.Redirect("../Default.aspx?ID=" & gvRequerimientos.DataKeys.Item(e.NewEditIndex).Value)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Try
            Dim oRequerimiento As New clsRequerimiento(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())

            oRequerimiento.ID = IIf(txtID.Text = String.Empty, 0, txtID.Text)
            oRequerimiento.Funcionalidad = ddlFuncionalidad.SelectedValue
            oRequerimiento.Modulo = ddlModulo.SelectedValue
            oRequerimiento.Fuente = txtFuente.Text.Trim
            oRequerimiento.Descripcion = txtDescripcion.Text.Trim
            oRequerimiento.Proyecto = ddlProyecto.SelectedValue
            oRequerimiento.Producto = ddlProducto.SelectedValue
            oRequerimiento.Folio = txtFolios.Text.Trim()
            oRequerimiento.Version = txtVersion.Text.Trim()

            fillGrid(oRequerimiento)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fillGrid(ByVal oRequerimiento As clsRequerimiento)
        Try            
            gvRequerimientos.DataSource = oRequerimiento.obtenerRequerimientos(txtDateB.Text, txtDateE.Text)
            gvRequerimientos.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub fillGrid()
        Try
            Dim oRequerimiento As New clsRequerimiento(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            fillGrid(oRequerimiento)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub fillCombos()
        Try
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

            ddlModulo.DataSource = AmesolREQMLog.clsUtil.fillCombo("Modulo", "vchNombre", "iModuloID", ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString(), "vchNombre")
            ddlModulo.DataValueField = "Value"
            ddlModulo.DataTextField = "Text"
            ddlModulo.DataBind()
            'Dim it3 As New ListItem("Seleccione uno", 0)
            ddlModulo.Items.Insert(0, it)

            ddlFuncionalidad.DataSource = AmesolREQMLog.clsUtil.fillCombo("Funcionalidad", "vchNombre", "iFuncionalidadID", ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString(), "vchNombre")
            ddlFuncionalidad.DataValueField = "Value"
            ddlFuncionalidad.DataTextField = "Text"
            ddlFuncionalidad.DataBind()
            'Dim it3 As New ListItem("Seleccione uno", 0)
            ddlFuncionalidad.Items.Insert(0, it)

        Catch ex As Exception

        End Try
    End Sub
End Class