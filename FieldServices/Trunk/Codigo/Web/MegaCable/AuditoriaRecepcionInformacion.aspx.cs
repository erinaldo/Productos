using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PREMEG.Acceso;
using MODMEG;

public partial class AuditoriaRecepcionInformacion : System.Web.UI.Page, IAuditoriaRecepcionInformacion
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AuditarRecepcionInformacion controladora = new AuditarRecepcionInformacion(this);
            List<Sucursal> lista = controladora.ObtenerSucursales();
            cmbSucursal.DataSource = lista;
            cmbSucursal.DataValueField = "ClaveSucursal";
            cmbSucursal.DataTextField = "Nombre";
            cmbSucursal.DataBind();
            /*txtFecha.Text = DateTime.Today.ToString("dd MMMM yyyy");
            hidFecha.Value = DateTime.Today.ToShortDateString();*/
            //txtFecha_CalendarExtender.SelectedDate = DateTime.Today;
        }
    }
    protected void btnGenerar_Click(object sender, EventArgs e)
    {
        AuditarRecepcionInformacion controladora = new AuditarRecepcionInformacion(this);
        controladora.ObtenerAuditoria(cmbSucursal.SelectedValue, Convert.ToDateTime(hidFecha.Value));
        
    }

    public int NoCuadrillas
    {
        
        set
        {
            txtNoCuadrillas.Text = value.ToString();
        }
    }

    public int CuadrillasSalieronDeBase
    {
        
        set
        {
            txtSalieron.Text = value.ToString();
        }
    }
    public int CuadrillasRegresaronABase
    {

        set
        {
            txtRefresaron.Text = value.ToString();
        }
    }

    public int TNNoCuadrillas
    {

        set
        {
            fldTNNoCuadrillas.Text = value.ToString();
        }
    }

    public int TNCuadrillasSalieronDeBase
    {

        set
        {
            fldTNSalieron.Text = value.ToString();
        }
    }
    public int TNCuadrillasRegresaronABase
    {

        set
        {
            fldTNRegresaron.Text = value.ToString();
        }
    }

    public void PoblarAuditoria(List<AuditarRecepcionInformacion.ElementoAuditoriaRecepcion> auditoria)
    {
        Session["ListaAuditoriaRecepcion"] = auditoria;
        FiltrarDatos();
        
    }
    private void FiltrarDatos()
    {
        List<AuditarRecepcionInformacion.ElementoAuditoriaRecepcion> lista = (List<AuditarRecepcionInformacion.ElementoAuditoriaRecepcion>)Session["ListaAuditoriaRecepcion"];

        TextBox filEstado = (TextBox)dlAuditoria.FindControl("filEstado");
        TextBox filCuadrilla = (TextBox)dlAuditoria.FindControl("filCuadrilla");


        List<AuditarRecepcionInformacion.ElementoAuditoriaRecepcion> listaFiltrada = lista.Where(l => l.ClaveCuadrilla.ToUpper().Contains(filCuadrilla == null ? "" : filCuadrilla.Text.ToUpper())
            && l.Estado.ToUpper().Contains(filEstado == null ? "" : filEstado.Text.ToUpper())).ToList();
        if(listaFiltrada.Count == 0)
            listaFiltrada.Add(new AuditarRecepcionInformacion.ElementoAuditoriaRecepcion());
        Session["ListaAuditoriaRecepcionFiltrada"] = listaFiltrada;
        PresentarGrid();

    }
    private void PresentarGrid()
    {
        dlAuditoria.DataSource = Session["ListaAuditoriaRecepcionFiltrada"];
        dlAuditoria.DataBind();
        updAuditoria.Update();
        updNacional.Update();
    }

    protected void dlAuditoria_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "Filtrar")
            FiltrarDatos();
        else if (e.CommandName == "QuitarFiltro")
        {
            TextBox filEstado = (TextBox)dlAuditoria.FindControl("filEstado");
            TextBox filCuadrilla = (TextBox)dlAuditoria.FindControl("filCuadrilla");
            filEstado.Text = "";
            filCuadrilla.Text = "";
            FiltrarDatos();
        }
    }
    protected void dlAuditoria_DataBound(object sender, EventArgs e)
    {
        UtilEtiquetas.CargarEtiquetas(dlAuditoria);
    }
}