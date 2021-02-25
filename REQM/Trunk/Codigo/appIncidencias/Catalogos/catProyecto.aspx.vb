Imports AmesolREQMLog

Partial Public Class catProyecto
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            fillGrid()
        End If
    End Sub

    Private Sub fillGrid()
        Try
            Dim dt As New DataTable
            Dim oCatalog As New clsProyecto(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            dt = oCatalog.ObtenerDatos()

            If gvProyecto.DataSource = Nothing Then
                dt.Rows.Add(dt.NewRow())
            End If
            gvProyecto.DataSource = dt
            gvProyecto.DataBind()
        Catch ex As Exception

        End Try

    End Sub


    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            Dim oCatalog As New clsProyecto(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())

            oCatalog.Nombre = CType(gvProyecto.FooterRow.FindControl("txtNombre"), TextBox).Text
            oCatalog.Descripcion = CType(gvProyecto.FooterRow.FindControl("txtDescripcion"), TextBox).Text
            oCatalog.NuevoRegistro()
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gvProyecto_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvProyecto.RowCancelingEdit
        Try
            gvProyecto.EditIndex = -1
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub gvProyecto_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvProyecto.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                If CType(e.Row.FindControl("lblID"), Label).Text = String.Empty Then
                    CType(e.Row.FindControl("ibEdit"), ImageButton).Visible = False
                    CType(e.Row.FindControl("ibDelete"), ImageButton).Visible = False
                Else
                    CType(e.Row.FindControl("ibDelete"), ImageButton).Attributes.Add("onclick", "javascript:return confirm('Esta seguro de eliminar el registro " & gvProyecto.DataKeys.Item(e.Row.RowIndex).Value & "');")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gvProyecto_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvProyecto.RowDeleting
        Try
            Dim oCatalog As New clsProyecto(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())

            oCatalog.ID = CType(gvProyecto.Rows(e.RowIndex).FindControl("lblID"), Label).Text
            oCatalog.EliminarRegistro()
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gvProyecto_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvProyecto.RowEditing
        Try
            gvProyecto.EditIndex = e.NewEditIndex
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub gvProyecto_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvProyecto.RowUpdating
        Try
            Dim oCatalog As New clsProyecto(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())

            oCatalog.Nombre = CType(gvProyecto.Rows(e.RowIndex).FindControl("txtNombre"), TextBox).Text
            oCatalog.Descripcion = CType(gvProyecto.Rows(e.RowIndex).FindControl("txtDescripcion"), TextBox).Text
            oCatalog.ID = CType(gvProyecto.Rows(e.RowIndex).FindControl("lblID"), Label).Text
            oCatalog.EditarRegistro()
            gvProyecto.EditIndex = -1
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub


End Class