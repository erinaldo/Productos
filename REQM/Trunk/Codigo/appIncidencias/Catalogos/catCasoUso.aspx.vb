Imports AmesolREQMLog

Partial Public Class catCasoUso
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            fillGrid()
        End If
    End Sub

    Private Sub fillGrid()
        Try

            Dim dt As New DataTable
            Dim oCatalog As New clsCasoUso(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            dt = oCatalog.ObtenerDatos()

            If gvCasoUso.DataSource = Nothing Then
                dt.Rows.Add(dt.NewRow())
            End If
            gvCasoUso.DataSource = dt
            gvCasoUso.DataBind()
        Catch ex As Exception

        End Try

    End Sub


    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            Dim oCatalog As New clsCasoUso(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            oCatalog.Nombre = CType(gvCasoUso.FooterRow.FindControl("txtNombre"), TextBox).Text
            oCatalog.Descripcion = CType(gvCasoUso.FooterRow.FindControl("txtDescripcion"), TextBox).Text
            oCatalog.NuevoRegistro()
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gvCasoUso_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvCasoUso.RowCancelingEdit
        Try
            gvCasoUso.EditIndex = -1
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub gvCasoUso_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCasoUso.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                If CType(e.Row.FindControl("lblID"), Label).Text = String.Empty Then
                    CType(e.Row.FindControl("ibEdit"), ImageButton).Visible = False
                    CType(e.Row.FindControl("ibDelete"), ImageButton).Visible = False
                Else
                    CType(e.Row.FindControl("ibDelete"), ImageButton).Attributes.Add("onclick", "javascript:return confirm('Esta seguro de eliminar el registro " & gvCasoUso.DataKeys.Item(e.Row.RowIndex).Value & "');")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gvCasoUso_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvCasoUso.RowDeleting
        Try
            Dim oCatalog As New clsCasoUso(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            oCatalog.ID = CType(gvCasoUso.Rows(e.RowIndex).FindControl("lblID"), Label).Text
            oCatalog.EliminarRegistro()
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gvCasoUso_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvCasoUso.RowEditing
        Try
            gvCasoUso.EditIndex = e.NewEditIndex
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub gvCasoUso_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvCasoUso.RowUpdating
        Try
            Dim oCatalog As New clsCasoUso(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            oCatalog.Nombre = CType(gvCasoUso.Rows(e.RowIndex).FindControl("txtNombre"), TextBox).Text
            oCatalog.ID = CType(gvCasoUso.Rows(e.RowIndex).FindControl("lblID"), Label).Text
            oCatalog.Descripcion = CType(gvCasoUso.Rows(e.RowIndex).FindControl("txtDescripcion"), TextBox).Text
            oCatalog.EditarRegistro()
            gvCasoUso.EditIndex = -1
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub

End Class