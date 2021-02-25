﻿Imports AmesolREQMLog

Partial Public Class catStatus
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            fillGrid()
        End If
    End Sub

    Private Sub fillGrid()
        Try
            Dim dt As New DataTable
            Dim oCatalog As New clsStatus(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            dt = oCatalog.ObtenerDatos()

            If gvStatus.DataSource = Nothing Then
                dt.Rows.Add(dt.NewRow())
            End If
            gvStatus.DataSource = dt
            gvStatus.DataBind()
        Catch ex As Exception

        End Try

    End Sub


    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            Dim oCatalog As New clsStatus(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            oCatalog.Nombre = CType(gvStatus.FooterRow.FindControl("txtNombre"), TextBox).Text
            oCatalog.NuevoRegistro()
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gvStatus_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvStatus.RowCancelingEdit
        Try
            gvStatus.EditIndex = -1
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub gvStatus_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvStatus.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                If CType(e.Row.FindControl("lblID"), Label).Text = String.Empty Then
                    CType(e.Row.FindControl("ibEdit"), ImageButton).Visible = False
                    CType(e.Row.FindControl("ibDelete"), ImageButton).Visible = False
                Else
                    CType(e.Row.FindControl("ibDelete"), ImageButton).Attributes.Add("onclick", "javascript:return confirm('Esta seguro de eliminar el registro " & gvStatus.DataKeys.Item(e.Row.RowIndex).Value & "');")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gvStatus_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvStatus.RowDeleting
        Try
            Dim oCatalog As New clsStatus(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            oCatalog.ID = CType(gvStatus.Rows(e.RowIndex).FindControl("lblID"), Label).Text
            oCatalog.EliminarRegistro()
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gvStatus_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvStatus.RowEditing
        Try
            gvStatus.EditIndex = e.NewEditIndex
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub gvStatus_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvStatus.RowUpdating
        Try
            Dim oCatalog As New clsStatus(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            oCatalog.Nombre = CType(gvStatus.Rows(e.RowIndex).FindControl("txtNombre"), TextBox).Text
            oCatalog.ID = CType(gvStatus.Rows(e.RowIndex).FindControl("lblID"), Label).Text
            oCatalog.EditarRegistro()
            gvStatus.EditIndex = -1
            fillGrid()
        Catch ex As Exception

        End Try
    End Sub
End Class