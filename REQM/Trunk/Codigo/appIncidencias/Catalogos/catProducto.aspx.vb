Imports AmesolREQMLog

Partial Public Class catProducto
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            fillGrid()
        End If
    End Sub

    Private Sub fillGrid()
        Try
            Dim dt As New DataTable
            Dim oCatalog As New clsProducto(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            dt = oCatalog.ObtenerDatos()

            If gvProducto.DataSource = Nothing Then
                dt.Rows.Add(dt.NewRow())
            End If
            gvProducto.DataSource = dt
            gvProducto.DataBind()
        Catch ex As Exception

        End Try

    End Sub


    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            Dim oCatalog As New clsProducto(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            oCatalog.Nombre = CType(gvProducto.FooterRow.FindControl("txtNombre"), TextBox).Text
            oCatalog.Descripcion = CType(gvProducto.FooterRow.FindControl("txtDescripcion"), TextBox).Text
            oCatalog.NuevoRegistro()
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gvProducto_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvProducto.RowCancelingEdit
        Try
            gvProducto.EditIndex = -1
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub gvProducto_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvProducto.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                If CType(e.Row.FindControl("lblID"), Label).Text = String.Empty Then
                    CType(e.Row.FindControl("ibEdit"), ImageButton).Visible = False
                    CType(e.Row.FindControl("ibDelete"), ImageButton).Visible = False
                Else
                    CType(e.Row.FindControl("ibDelete"), ImageButton).Attributes.Add("onclick", "javascript:return confirm('Esta seguro de eliminar el registro " & gvProducto.DataKeys.Item(e.Row.RowIndex).Value & "');")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gvProducto_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvProducto.RowDeleting
        Try
            Dim oCatalog As New clsProducto(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            oCatalog.ID = CType(gvProducto.Rows(e.RowIndex).FindControl("lblID"), Label).Text
            oCatalog.EliminarRegistro()
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gvProducto_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvProducto.RowEditing
        Try
            gvProducto.EditIndex = e.NewEditIndex
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub gvProducto_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvProducto.RowUpdating
        Try
            Dim oCatalog As New clsProducto(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            oCatalog.Nombre = CType(gvProducto.Rows(e.RowIndex).FindControl("txtNombre"), TextBox).Text
            oCatalog.Descripcion = CType(gvProducto.Rows(e.RowIndex).FindControl("txtDescripcion"), TextBox).Text
            oCatalog.ID = CType(gvProducto.Rows(e.RowIndex).FindControl("lblID"), Label).Text
            oCatalog.EditarRegistro()
            gvProducto.EditIndex = -1
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub

End Class