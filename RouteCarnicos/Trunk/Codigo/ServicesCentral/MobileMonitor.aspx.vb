
Partial Class MobileMonitor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Dim dir As New System.IO.DirectoryInfo(ServicesCentral.Configuracion.Directorio + "\LogInt")
            If dir.Exists Then
                dlCarpetas.DataSource = dir.GetDirectories()
                dlCarpetas.DataBind()
            End If
        End If
    End Sub
End Class
