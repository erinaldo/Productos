
Imports AmesolREQMLog
Partial Public Class catModulo
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            fillGrid()
        End If
    End Sub

    Private Sub fillGrid()
        Try
            Dim dt As New DataTable
            Dim oCatalog As New clsModulo(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            dt = oCatalog.ObtenerDatos()

            If gvModulo.DataSource = Nothing Then
                dt.Rows.Add(dt.NewRow())
            End If
            gvModulo.DataSource = dt
            gvModulo.DataBind()
        Catch ex As Exception

        End Try

    End Sub


    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            Dim oCatalog As New clsModulo(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            oCatalog.Nombre = CType(gvModulo.FooterRow.FindControl("txtNombre"), TextBox).Text
            oCatalog.NuevoRegistro()
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gvModulo_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvModulo.RowCancelingEdit
        Try
            gvModulo.EditIndex = -1
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub gvModulo_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvModulo.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                If CType(e.Row.FindControl("lblID"), Label).Text = String.Empty Then
                    CType(e.Row.FindControl("ibEdit"), ImageButton).Visible = False
                    CType(e.Row.FindControl("ibDelete"), ImageButton).Visible = False
                Else
                    CType(e.Row.FindControl("ibDelete"), ImageButton).Attributes.Add("onclick", "javascript:return confirm('Esta seguro de eliminar el registro " & gvModulo.DataKeys.Item(e.Row.RowIndex).Value & "');")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gvModulo_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvModulo.RowDeleting
        Try
            Dim oCatalog As New clsModulo(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            oCatalog.ID = CType(gvModulo.Rows(e.RowIndex).FindControl("lblID"), Label).Text
            oCatalog.EliminarRegistro()
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gvModulo_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvModulo.RowEditing
        Try
            gvModulo.EditIndex = e.NewEditIndex
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub gvModulo_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvModulo.RowUpdating
        Try
            Dim oCatalog As New clsModulo(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            oCatalog.Nombre = CType(gvModulo.Rows(e.RowIndex).FindControl("txtNombre"), TextBox).Text
            oCatalog.ID = CType(gvModulo.Rows(e.RowIndex).FindControl("lblID"), Label).Text
            oCatalog.EditarRegistro()
            gvModulo.EditIndex = -1
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub

End Class