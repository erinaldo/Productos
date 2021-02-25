
Partial Class Errores
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Mensaje As New DBConexion.cMensaje

        Try
            lbError.Text = Mensaje.RecuperarDescripcion("XWEBError")
            lblRegresar.Text = Mensaje.RecuperarDescripcion("XInicio")
        Catch ex As Exception
            Session("_ErrValor") = Session("_ErrValor") & "    |   " & ex.Message
        End Try
        lbErrorDesc.InnerHtml = Session("_ErrValor")
        'Dim existe As Boolean = IO.File.Exists(Server.MapPath("ErrorLog.htm"))
        Try

            Using arch As New System.IO.StreamWriter(Server.MapPath("ErrorLog.htm"), True)
                'If Not existe Then
                '    arch.WriteLine("<html><head><title>Log de Errores</title></head><body>")

                'End If
                arch.WriteLine("<b style=""color:Black""><br/><br/><br/>Usuario: <b>" & HttpContext.Current.User.Identity.Name & "</b>")
                arch.WriteLine("<br/><br/>Fecha: <b>" & DateTime.Now.ToString() & "</b></b>")
                arch.WriteLine("<br/><br/>" & Session("_ErrValor"))
                'If Not existe Then
                '    arch.WriteLine("</body></html>")
                'End If
                arch.Flush()
                arch.Close()
            End Using
        Catch ex As Exception
            'errorError.InnerText = "No se puedo grabar el archivo: " + Err.Description
        End Try

    End Sub
End Class
