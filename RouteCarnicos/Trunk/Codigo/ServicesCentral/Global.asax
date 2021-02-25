<%@ Application Language="VB" %>

<script runat="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
        Dim connString As System.Configuration.ConnectionStringSettings
        connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ROUTE")
           ServicesCentral.Configuracion.CadenaConexionSQL = connString.ConnectionString
        ServicesCentral.Configuracion.Directorio = MobileClient.ConexionSQL.EjecutarCmdScalarStrSQL("select Top 1 DirectorioSDF from conhist where CONHistFechaInicio <=getdate() order by  CONHistFechaInicio desc")
        connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("FIREBIRD")
        ServicesCentral.Configuracion.CadenaConexionFirebird = connString.ConnectionString
        AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", True)
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
        Dim connString As System.Configuration.ConnectionStringSettings
        connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ROUTE")
        ServicesCentral.Configuracion.CadenaConexionSQL = connString.ConnectionString
        connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("FIREBIRD")
        ServicesCentral.Configuracion.CadenaConexionFirebird = connString.ConnectionString
           ServicesCentral.Configuracion.Directorio  =MobileClient.ConexionSQL.EjecutarCmdScalarStrSQL ("select Top 1 DirectorioSDF from conhist where CONHistFechaInicio <=getdate() order by  CONHistFechaInicio desc")
        
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub

    Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As System.EventArgs)
        ServicesCentral.Configuracion.Directorio = MobileClient.ConexionSQL.EjecutarCmdScalarStrSQL("select Top 1 DirectorioSDF from conhist where CONHistFechaInicio <=getdate() order by  CONHistFechaInicio desc")
    End Sub
</script>