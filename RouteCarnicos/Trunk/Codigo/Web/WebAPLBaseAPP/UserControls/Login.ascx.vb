
Partial Class UserControls_Login
    Inherits System.Web.UI.UserControl

Private vcUsuario As DBManager.cUsuario

Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not Page.IsPostBack Then
            vcUsuario = New DBManager.cUsuario
            Try
                Session("lenguaje") = DBConexion.cMensaje.ObtenerLenguaje
            Catch ex As Exception
                Me.lblError.Text = ex.Message
            End Try
        End If

        
    End Sub

    Protected Sub Button1_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        
        Dim ins As New DBConexion.cConexionSQL
        vcUsuario = New DBManager.cUsuario
        Dim RepPer As Integer
        Dim PerAct As Boolean

        If vcUsuario.RecuperarClave(ebLogin.Text) = True Then
            PerAct = ins.EjecutarComandoScalar("select activo from perfil  where PERClave='" & vcUsuario.PERClave & "'")
            RepPer = ins.EjecutarComandoScalar("select count(*) from intusu where permiso like '%E%' and USUId='" & vcUsuario.USUId & "' AND (ACTId like '" & "ReporteW%' or ACTId like '" & "MapaW%') AND INTTipoInterfaz=3")
            RepPer += ins.EjecutarComandoScalar("select count(*) from intper where permiso like '%E%' and PERClave='" & vcUsuario.PERClave & "' AND (ACTId like '" & "ReporteW%' or ACTId like '" & "MapaW%') AND INTTipoInterfaz=3")

            Dim vlPassword As String = DBManager.cUsuario.SimpleCrypt(vcUsuario.ClaveAcceso)

            If ebPassword.Text = vlPassword Then
                Dim vcMensaje As New DBConexion.cMensaje
                If PerAct Then


                    If (RepPer > 0) Then
                        'lbGeneral.cParametros.UsuarioID = vcUsuario.USUId
                        Session("UsuarioID") = vcUsuario.USUId
                        'Response.Redirect("MenuBase.aspx")
                        System.Web.Security.FormsAuthentication.RedirectFromLoginPage(ebLogin.Text, False)
                    Else
                        'lblError.Text = "[E0650] El Usuario no tiene permisos para ingresar"
                        lblError.Text = vcMensaje.RecuperarDescripcion("E0650")
                    End If
                Else
                    'lblError.Text = "[E0649] El Perfil del usuario no se encuentra Activo"
                    lblError.Text = vcMensaje.RecuperarDescripcion("E0649")
                End If

            Else
                lblError.Text = "Incorrect Password"
            End If
            Else
                lblError.Text = "Login Does Not Exists"
            End If
    End Sub
End Class

