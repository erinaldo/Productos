using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PREMEG.Acceso;

public partial class GeneracionReportes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            GenerarReportes controladora = new GenerarReportes();
            cmbReportes.DataSource = controladora.ObtenerReportes();
            cmbReportes.DataValueField = "Valor";
            cmbReportes.DataTextField = "Descripcion";
            cmbReportes.DataBind();

            cmbFecha.Items.Add(new ListItem(UtilMensaje.ObtenerMensaje("#IGUAL"), "0"));
            cmbFecha.Items.Add(new ListItem(UtilMensaje.ObtenerMensaje("#ENTRE"), "1"));
            if (Application["Parametros"] == null)
                Application["Parametros"] = controladora.ObtenerParametros();

            CustomValidator1.Text = UtilMensaje.ObtenerMensaje("#MI0040");
        }
    }
    protected void btnGenerar_Click(object sender, EventArgs e)
    {
        /*string tipo = cmbReportes.SelectedValue;
        GenerarReportes controladora = new GenerarReportes();

        DateTime fecha1 = Convert.ToDateTime(hidFecha1.Value);
        DateTime fecha2 = Convert.ToDateTime(hidFecha2.Value);
        if (cmbFecha.SelectedValue == "0")
            fecha2 = fecha1.AddDays(1);


        switch(controladora.ValidarExistenciaInformacion(tipo, fecha1, fecha2))
        {
            case GenerarReportes.DatosExistentes.Reporte :
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "pop", "javascript:window.open('GenerarReporte.aspx?tipo=" + tipo + "&f1=" + fecha1 + "&f2=" + fecha2 + "','" + tipo + "','menubar=0,scrollbars=1,toolbar=0,resizable=1');", true);
                break;
            case GenerarReportes.DatosExistentes.Mapa:
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "pop", "javascript:window.open('GenerarMapa.aspx?tipo=" + tipo + "&f1=" + fecha1 + "&f2=" + fecha2 + "','" + tipo + "','menubar=0');", true);
                break;
            case GenerarReportes.DatosExistentes.Ninguno:
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "pop", "javascript:alert('" + UtilMensaje.ObtenerMensaje("#MI0040") + "')", true);
                break;
        }*/
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        string tipo = cmbReportes.SelectedValue;
        GenerarReportes controladora = new GenerarReportes();

        DateTime fecha1 = Convert.ToDateTime(hidFecha1.Value);
        DateTime fecha2 = Convert.ToDateTime(hidFecha2.Value);
        if (cmbFecha.SelectedValue == "0")
            fecha2 = fecha1.AddDays(1);

        switch (controladora.ValidarExistenciaInformacion(tipo, fecha1, fecha2))
        {
            case GenerarReportes.DatosExistentes.Reporte:
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "pop", "javascript:MostrarReporte(1,'" + fecha1 + "','" + fecha2 + "'," + tipo.ToString() + ",'" + Guid.NewGuid().ToString() + "');", true);
                break;
            case GenerarReportes.DatosExistentes.Mapa:
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "pop", "javascript:MostrarReporte(2,'" + fecha1 + "','" + fecha2 + "'," + tipo.ToString() + ",'" + Guid.NewGuid().ToString() + "');", true);
                break;
            case GenerarReportes.DatosExistentes.Ninguno:
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "pop", "javascript:CargarCalendarios();", true);
                
                args.IsValid = false;
                break;
        }
    }
    protected void cmbFecha_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbFecha.SelectedValue == "0")
            txtFecha2.Visible = false;
        else
            txtFecha2.Visible = true;
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "pop", "javascript:CargarCalendarios();", true);
    }
}