<%@ WebHandler Language="C#" Class="ObtenerImagen" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.IO;

public class ObtenerImagen : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        string ClaveSucursal = context.Request["cs"];
        string archivo = context.Request["a"];
        if (context.Application["Parametros"] == null)
        {
            PREMEG.Acceso.GenerarReportes rep = new PREMEG.Acceso.GenerarReportes();
            context.Application["Parametros"] = rep.ObtenerParametros();
        }
        if (!(context.Application["Parametros"] == null))
        {
            Dictionary<string, Dictionary<string, string>> parametros = (Dictionary<string, Dictionary<string, string>>)context.Application["Parametros"];
            context.Response.ContentType = "image/png";
            context.Response.AppendHeader("Content-Disposition", "attachment;filename=" + archivo + ".png");
            if (parametros[ClaveSucursal].ContainsKey("RUTAIMAGENSERV"))
            {
                string ruta = Path.Combine(parametros[ClaveSucursal]["RUTAIMAGENSERV"], archivo + ".png");
                if (File.Exists(ruta))
                    context.Response.TransmitFile(ruta);
            }
            context.Response.End();
        }
        else
            context.Response.End();
        //
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}