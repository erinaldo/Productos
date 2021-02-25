<%@ Application Language="VB" %>

<script runat="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
        Dim exe As System.Exception = Server.GetLastError.InnerException()
        Session("_ErrValor") = "<b style=""color:Red""><br/>Error Encabezado: " & Server.GetLastError.Message & "<br/>"
        Session("_ErrValor") += "<b style=""color:Red""><br/>Error: " & exe.Message & "<br/><br/>Metodo: " & exe.TargetSite.Name & "<br/><br/>Stack: " & exe.StackTrace & "</b>"
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub
       
</script>