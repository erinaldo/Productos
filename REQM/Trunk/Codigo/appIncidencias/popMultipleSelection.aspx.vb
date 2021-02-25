Public Partial Class popMultipleSelection
    Inherits System.Web.UI.Page
    Private nombreTabla As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then


            btnCancelar.Attributes.Add("onclick", "javascript:window.close();")
            nombreTabla = Request.QueryString("Tabla")
            fillGrid()
        End If
    End Sub

    Public Sub fillGrid()
        Try
            Dim dt As DataTable = AmesolREQMLog.clsUtil.obtenerDatos(nombreTabla, ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            If Not dt.Columns.Contains("Descripcion") Then
                gvSeleccion.Columns(3).Visible = False
                dt.Columns.Add("Descripcion")
            End If
            gvSeleccion.DataSource = dt
            gvSeleccion.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAceptar.Click
        Try




            Session("Values") = Nothing

            Session("Tabla") = Request.QueryString("Tabla")
            Dim dt As New DataTable
            dt.Columns.Add("Text")
            dt.Columns.Add("Value")




            For Each r As GridViewRow In gvSeleccion.Rows
                If CType(r.FindControl("chkSelected"), CheckBox).Checked Then
                    Dim dr As DataRow = dt.NewRow
                    dr("Text") = CType(r.FindControl("lblNombre"), Label).Text + " " + CType(r.FindControl("lblDescripcion"), Label).Text
                    dr("Value") = CType(r.FindControl("lblID"), Label).Text
                    dt.Rows.Add(dr)
                End If
            Next

            'Select Case Session("Tabla").ToString.ToUpper
            '    Case "CASOUSO"
            '        Session("CasoUso") = li
            '    Case "CASOPRUEBA"
            '        Session("CasoPrueba") = li
            '    Case "ESPECIFICACION"
            '        Session("Especificacion") = li
            '    Case "COMPONENTE"
            '        Session("Componente") = li
            '        'Case "FOLIO"
            '        '    lbFolios.DataSource = Session("Values")
            '        '    lbFolios.DataBind()
            'End Select
            Session("Values") = dt
            Dim scpt As String = "window.close();"
            ScriptManager.RegisterStartupScript(Page, Page.GetType, "Close", scpt, True)

        Catch ex As Exception

        End Try

    End Sub
End Class