Imports AmesolREQMLog

Partial Public Class wfrProductoVsVersion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            fillddl()
        End If
    End Sub

    Private Sub fillddl()
        Try
            ddlProduct.DataSource = clsUtil.fillCombo("Producto", "vchNombre", "iProductoID", ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString(), "vchNombre")
            ddlProduct.DataTextField = "Text"
            ddlProduct.DataValueField = "Value"
            ddlProduct.DataBind()
            Dim it As New ListItem("Seleccione uno", 0)
            ddlProduct.Items.Insert(0, it)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub fillgrid()
        Try
            gvProdVersion.DataSource = obtenerDatos()
            gvProdVersion.DataBind()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ddlProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlProduct.SelectedIndexChanged
        Try
            If ddlProduct.SelectedIndex = 0 Then
                gvProdVersion.Visible = False
            Else
                gvProdVersion.Visible = True
            End If
            fillgrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Function obtenerDatos() As DataTable
        Try

            Dim DB As New clsDB(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            With DB
                .AddParameter("@ProductoID", SqlDbType.Int, ddlProduct.SelectedValue)
                Return .ToDatatable("ProductoVsVersion", CommandType.StoredProcedure)
            End With
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Protected Sub chkAsignado_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim DB As New clsDB(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            Dim ID As Integer = sender.Parent.parent.findcontrol("lblID").Text
            With DB
                .AddParameter("@ProductoID", SqlDbType.Int, ddlProduct.SelectedValue)
                .AddParameter("@VersionID", SqlDbType.Int, ID)
                .AddParameter("@Asignado", SqlDbType.Bit, sender.Checked)
                .ExecuteCmd("ActualizarRelacionProVer", CommandType.StoredProcedure)
            End With
        Catch ex As Exception

        End Try

    End Sub
End Class