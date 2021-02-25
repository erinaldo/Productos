using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PREMEG.Acceso;
using MODMEG;

public partial class AdministracionVehiculos : System.Web.UI.Page, PREMEG.Acceso.IAdministracionVehiculos
{
    private bool CatalogosCargados
    {
        set
        {
            ViewState["CatalogosCargados"] = value;
        }
        get
        {
            return Convert.ToBoolean(ViewState["CatalogosCargados"]);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //TODO: Ver lo de la seleccion del vehiculo para mostrar sus datos
        if (!this.IsPostBack)
        {
            AdministrarVehiculos control = new AdministrarVehiculos(this);
            Session["TablaVehiculos"] = control.ObtenerVehiculos();
            FiltrarVehiculos("", "", "", "", "", 0);
            CatalogosCargados = false;
            //UtilEtiquetas.CargarEtiquetas(this);
        }
    }

    private void FiltrarVehiculos(string NumeroEconomico, string Placas, string Marca, string Submarca,string Sucursal, short Modelo)
    {
        
        List<Vehiculo> todos = (List<Vehiculo>)Session["TablaVehiculos"];
        var filtrado = from veh in todos
                       where
                           veh.NumeroEconomicoVh.ToUpper().Contains(NumeroEconomico.ToUpper()) &&
                           veh.Placas.ToUpper().Contains(Placas.ToUpper()) &&
                           veh.Marca.ToUpper().Contains(Marca.ToUpper()) &&
                           veh.SubMarca.ToUpper().Contains(Submarca.ToUpper()) &&
                           veh.Sucursal.Nombre.ToUpper().Contains(Sucursal.ToUpper()) &&
                           (Modelo == 0 ? true : veh.Modelo == Modelo)
                       select veh;
        List<Vehiculo> res =filtrado.ToList();
        if (res.Count == 0)
            res.Add(new Vehiculo());
        Session["TablaFiltraVehiculos"] = res;
    }
    
    protected void dsVehiculos_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = Session["TablaFiltraVehiculos"];
    }
    protected void dsSucursales_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = Session["ComboSucursales"];
    }

    private void CargarCatalogos()
    {
        if (!CatalogosCargados)
        {
            AdministrarVehiculos control = new AdministrarVehiculos(this);
            Session["ComboSucursales"] = control.ObtenerSucursales();
            CatalogosCargados = true;
        }
    }
    /*protected void Nuevo_Registro_Click(object sender, ImageClickEventArgs e)
    {
        CargarCatalogos();
        dlVehiculos.EditIndex = -1;
        dlVehiculos.InsertItemPosition = InsertItemPosition.FirstItem;

        //dlVehiculos.DataBind();
    }*/
    protected void Nuevo_Registro_Click(object sender, EventArgs e)
    {
        CargarCatalogos();
        dlVehiculos.EditIndex = -1;
        dlVehiculos.InsertItemPosition = InsertItemPosition.FirstItem;
    }
    protected void dlVehiculos_ItemInserting(object sender, ListViewInsertEventArgs e)
    {
        AdministrarVehiculos control = new AdministrarVehiculos(this);
        Vehiculo veh = new Vehiculo();

        veh.NumeroEconomicoVh = e.Values["NumeroEconomicoVh"].ToString();
        veh.Marca = e.Values["Marca"].ToString();
        veh.SubMarca = e.Values["SubMarca"].ToString();
        veh.ClaveSucursal = e.Values["ClaveSucursal"].ToString();
        veh.CodigoBarras = e.Values["CodigoBarras"].ToString();
        veh.Placas = e.Values["Placas"].ToString();
        short modelo = 0;
        short.TryParse(e.Values["Modelo"] == null ? "0" : e.Values["Modelo"].ToString(), out modelo);
        veh.Modelo = modelo;
        decimal kminicial = 0;
        decimal.TryParse(e.Values["KmInicial"] == null ? "0" : e.Values["KmInicial"].ToString(), out kminicial);
        veh.KmInicial = kminicial;
        decimal kmfinal = 0;
        decimal.TryParse(e.Values["KmFinal"] == null ? "0" : e.Values["KmFinal"].ToString(), out kmfinal);
        veh.KmFinal = kmfinal;

        if (control.RegistrarVehiculo(veh))
        {

            Session["TablaVehiculos"] = control.ObtenerVehiculos();
            FiltrarVehiculos();
        }

        dlVehiculos.InsertItemPosition = InsertItemPosition.None;
        dlVehiculos.EditIndex = -1;
        dlVehiculos.DataBind();
        e.Cancel = true;
    }
    protected void dlVehiculos_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "Filtrar")
        {
            FiltrarVehiculos();
            dlVehiculos.DataBind();
        }
        else if (e.CommandName == "QuitarFiltro")
        {
            TextBox filNumeroEconomico = (TextBox)dlVehiculos.FindControl("filNumeroEconomico");
            TextBox filPlacas = (TextBox)dlVehiculos.FindControl("filPlacas");
            TextBox filMarca = (TextBox)dlVehiculos.FindControl("filMarca");
            TextBox filSubmarca = (TextBox)dlVehiculos.FindControl("filSubmarca");
            TextBox filSucursal = (TextBox)dlVehiculos.FindControl("filSucursal");
            TextBox filModelo = (TextBox)dlVehiculos.FindControl("filModelo");
            filNumeroEconomico.Text = "";
            filPlacas.Text = "";
            filMarca.Text = "";
            filSubmarca.Text = "";
            filSucursal.Text = "";
            filModelo.Text = "";
            FiltrarVehiculos();
            dlVehiculos.DataBind();
        }
    }
    private void FiltrarVehiculos()
    {
        TextBox filNumeroEconomico = (TextBox)dlVehiculos.FindControl("filNumeroEconomico");
        TextBox filPlacas = (TextBox)dlVehiculos.FindControl("filPlacas");
        TextBox filMarca = (TextBox)dlVehiculos.FindControl("filMarca");
        TextBox filSubmarca = (TextBox)dlVehiculos.FindControl("filSubmarca");
        TextBox filSucursal = (TextBox)dlVehiculos.FindControl("filSucursal");
        TextBox filModelo = (TextBox)dlVehiculos.FindControl("filModelo");
        short modelo = 0;
        short.TryParse(filModelo.Text.Trim(), out modelo);
        FiltrarVehiculos(
            filNumeroEconomico.Text.Trim(),
            filPlacas.Text.Trim(),
            filMarca.Text.Trim(),
            filSubmarca.Text.Trim(),
            filSucursal.Text.Trim(),
            modelo);

    }
    protected void dlVehiculos_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {
        AdministrarVehiculos control = new AdministrarVehiculos(this);
        Vehiculo veh = new Vehiculo();
        veh.NumeroEconomicoVh = e.NewValues["NumeroEconomicoVh"].ToString();
        veh.Marca = e.NewValues["Marca"].ToString();
        veh.SubMarca = e.NewValues["SubMarca"].ToString();
        veh.ClaveSucursal = e.NewValues["ClaveSucursal"].ToString();
        veh.CodigoBarras = e.NewValues["CodigoBarras"].ToString();
        veh.Placas = e.NewValues["Placas"].ToString();
        short modelo = 0;
        short.TryParse(e.NewValues["Modelo"].ToString(), out modelo);
        veh.Modelo = modelo;
        decimal kminicial = 0;
        decimal.TryParse(e.NewValues["KmInicial"] == null ? "0" : e.NewValues["KmInicial"].ToString(), out kminicial);
        veh.KmInicial = kminicial;
        decimal kmfinal = 0;
        decimal.TryParse(e.NewValues["KmFinal"] == null ? "0" : e.NewValues["KmFinal"].ToString(), out kmfinal);
        veh.KmFinal = kmfinal;

        if (control.ActualizarVehiculo(veh)){

            Session["TablaVehiculos"] = control.ObtenerVehiculos();
            FiltrarVehiculos();
        }

        dlVehiculos.InsertItemPosition = InsertItemPosition.None;
        dlVehiculos.EditIndex = -1;
        dlVehiculos.DataBind();
        e.Cancel = true;
    }

    protected void dlVehiculos_ItemEditing(object sender, ListViewEditEventArgs e)
    {
        dlVehiculos.InsertItemPosition = InsertItemPosition.None;
        CargarCatalogos();
    }


    protected void dlVehiculos_DataBound(object sender, EventArgs e)
    {
        if(dlVehiculos.EditItem != null)
            UtilEtiquetas.CargarEtiquetas(dlVehiculos.EditItem);
        if (dlVehiculos.InsertItem != null)
            UtilEtiquetas.CargarEtiquetas(dlVehiculos.InsertItem);

    }
    protected void dlVehiculos_ItemCanceling(object sender, ListViewCancelEventArgs e)
    {
        dlVehiculos.EditIndex = -1;
        dlVehiculos.InsertItemPosition = InsertItemPosition.None;
        dlVehiculos.DataBind();
    }
    protected void dlVehiculos_PagePropertiesChanged(object sender, EventArgs e)
    {
        dlVehiculos.EditIndex = -1;
        dlVehiculos.InsertItemPosition = InsertItemPosition.None;
    }
}