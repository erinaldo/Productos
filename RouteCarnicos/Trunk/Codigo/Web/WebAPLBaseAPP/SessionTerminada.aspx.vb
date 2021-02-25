
Partial Class Reports_SessionTerminada
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
         Dim mensaje As New DBConexion.cMensaje

        lbSesionT.Text = mensaje.RecuperarDescripcion("I0163")
        lblRegresar.Text = mensaje.RecuperarDescripcion("XInicio")
    End Sub
End Class
