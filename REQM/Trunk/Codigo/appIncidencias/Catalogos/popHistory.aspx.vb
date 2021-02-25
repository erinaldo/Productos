Public Partial Class popHistory
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            fillGrid()
            btnClose.Attributes.Add("onclick", "javascript:return window.close();")
        End If

    End Sub

    Private Sub fillGrid()
        Try
            Dim oDB As New AmesolREQMLog.clsDB(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            With oDB
                .AddParameter("@ID", SqlDbType.Int, Request.QueryString("ID"))
                gvHistorial.DataSource = .ToDatatable("obtenerHistorial", CommandType.StoredProcedure)
            End With
            gvHistorial.DataBind()
        Catch ex As Exception

        End Try
    End Sub

End Class