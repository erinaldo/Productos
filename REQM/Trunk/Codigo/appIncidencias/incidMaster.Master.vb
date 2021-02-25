Public Partial Class incidMaster
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("User") Is Nothing Then
            Response.Redirect("Login.aspx", True)
        End If
    End Sub

End Class