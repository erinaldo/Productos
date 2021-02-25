Imports AmesolREQMLog

Partial Public Class catCliente
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            fillGrid()
        End If
    End Sub
    Private Sub fillGrid()
        Try
            Dim dt As New DataTable
            Dim oCatalog As New clsCliente(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            dt = oCatalog.ObtenerDatos()

            If gvCliente.DataSource = Nothing Then
                dt.Rows.Add(dt.NewRow())
            End If
            gvCliente.DataSource = dt
            gvCliente.DataBind()
        Catch ex As Exception

        End Try

    End Sub


    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            Dim oCatalog As New clsCliente(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            oCatalog.Nombre = CType(gvCliente.FooterRow.FindControl("txtNombre"), TextBox).Text
            oCatalog.NuevoRegistro()
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gvCliente_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvCliente.RowCancelingEdit
        Try
            gvCliente.EditIndex = -1
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub gvCliente_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCliente.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                If CType(e.Row.FindControl("lblID"), Label).Text = String.Empty Then
                    CType(e.Row.FindControl("ibEdit"), ImageButton).Visible = False
                    CType(e.Row.FindControl("ibDelete"), ImageButton).Visible = False
                Else
                    CType(e.Row.FindControl("ibDelete"), ImageButton).Attributes.Add("onclick", "javascript:return confirm('Esta seguro de eliminar el registro " & gvCliente.DataKeys.Item(e.Row.RowIndex).Value & "');")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gvCliente_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvCliente.RowDeleting
        Try
            Dim oCatalog As New clsCliente(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            oCatalog.ID = CType(gvCliente.Rows(e.RowIndex).FindControl("lblID"), Label).Text
            oCatalog.EliminarRegistro()
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gvCliente_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvCliente.RowEditing
        Try
            gvCliente.EditIndex = e.NewEditIndex
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub gvCliente_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvCliente.RowUpdating
        Try
            Dim oCatalog As New clsCliente(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            oCatalog.Nombre = CType(gvCliente.Rows(e.RowIndex).FindControl("txtNombre"), TextBox).Text
            oCatalog.ID = CType(gvCliente.Rows(e.RowIndex).FindControl("lblID"), Label).Text
            oCatalog.EditarRegistro()
            gvCliente.EditIndex = -1
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub

End Class