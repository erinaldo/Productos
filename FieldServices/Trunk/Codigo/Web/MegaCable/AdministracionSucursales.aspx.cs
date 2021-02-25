using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PREMEG.Catalogos;
using MODMEG;
using PREMEG.Util;
using AjaxControlToolkit;

public partial class AdministracionSucursales : System.Web.UI.Page, IAdministrarSucursales
{
    AdministrarSucursalesControlador control;

    private List<Sucursal> Sucursales {
        get {
            return (List<Sucursal>)Session["Sucursales"];
        }
        set {
            Session["Sucursales"] = value;   
        }    
    }
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            control = new AdministrarSucursalesControlador(this);        
            
            FiltroNombre = "";            
            FiltroClave = "";
            FiltroCiudad = "";
            FiltroRegion = "";
            FiltroEstado = "T";


            Sucursales = control.ObtenerSucursalesInicio();
            ViewState["ComboCiudades"] = control.ObtenerCiudades();
            ViewState["ComboRegiones"] = control.ObtenerRegionesActivas();
        }
    }


    #region FILTROS
    
    private string FiltroClave
    {
        set
        {
            ViewState["FiltroClave"] = value;
        }
        get
        {
            return ViewState["FiltroClave"].ToString();
        }
    }
    
    private string FiltroNombre
    {
        set
        {
            ViewState["FiltroNombre"] = value;
        }
        get
        {
            return ViewState["FiltroNombre"].ToString();
        }
    }

    private string FiltroCiudad
    {
        set
        {
            ViewState["FiltroCiudad"] = value;
        }
        get
        {
            return ViewState["FiltroCiudad"].ToString();
        }
    }

    private string FiltroRegion
    {
        set
        {
            ViewState["FiltroRegion"] = value;
        }
        get
        {
            return ViewState["FiltroRegion"].ToString();
        }
    }

    private string FiltroEstado
    {
        set
        {
            ViewState["FiltroEstado"] = value;
        }
        get
        {
            return ViewState["FiltroEstado"].ToString();
        }
    }

    #endregion

    private List<Sucursal> ObtenerDataSource()
    {
        Sucursal s = new Sucursal();        
        List<Sucursal> sucursal = Sucursales;
        
        List<Sucursal> res = sucursal.Where(
            obj => obj.ClaveSucursal.ToUpper().Contains(FiltroClave) &&
                obj.Nombre.ToUpper().Contains(FiltroNombre) &&
                obj.Ciudad.Nombre.ToUpper().Contains(FiltroCiudad) &&
                obj.Region.Nombre.ToUpper().Contains(FiltroRegion) &&                
                ((obj.Estado == (FiltroEstado == "A" ? true : false)) || (FiltroEstado == "T"))
        ).ToList();
        
        if (res.Count == 0)
            res.Add(new Sucursal());
        return res;
        
    }

    protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = ObtenerDataSource();
        
    }

    /*protected void Nuevo_Registro_Click(object sender, ImageClickEventArgs e) {
        dlSucursales.EditIndex = -1;       
        dlSucursales.InsertItemPosition = InsertItemPosition.FirstItem;             
        //((LinkButton)sender).Visible = false;
    }*/
    protected void Nuevo_Registro_Click(object sender, EventArgs e)
    {
        dlSucursales.EditIndex = -1;
        dlSucursales.InsertItemPosition = InsertItemPosition.FirstItem;
    }

    protected void dlSucursales_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "Guardar")
        {
            dlSucursales.EditIndex = -1;
            dlSucursales.DataBind();
        }

        if (e.CommandName == "Edit") {
            dlSucursales.InsertItemPosition = InsertItemPosition.None;
        
        }


        if (e.CommandName == "Cancel")
        {
            dlSucursales.InsertItemPosition = InsertItemPosition.None;
        }

        


        if (e.CommandName == "Filtrar")
        {
            TextBox filClave = (TextBox)dlSucursales.FindControl("filClave");
            if (filClave == null)
                filClave = (TextBox)e.Item.FindControl("filClave");

            TextBox filNombre = (TextBox)dlSucursales.FindControl("filNombre");
            if (filNombre == null)
                filNombre = (TextBox)e.Item.FindControl("filNombre");

            TextBox filCiudad = (TextBox)dlSucursales.FindControl("filCiudad");
            if (filCiudad == null)
                filCiudad = (TextBox)e.Item.FindControl("filCiudad");

            TextBox filRegion = (TextBox)dlSucursales.FindControl("filRegion");
            if (filRegion == null)
                filRegion = (TextBox)e.Item.FindControl("filRegion");
            
            ComboBox cmbEstado = (ComboBox)dlSucursales.FindControl("cmbEstado");
            if (cmbEstado == null)
                cmbEstado = (ComboBox)e.Item.FindControl("cmbEstado");

            FiltroClave = filClave.Text.Trim().ToUpper();
            FiltroNombre = filNombre.Text.Trim().ToUpper();
            FiltroCiudad = filCiudad.Text.Trim().ToUpper();
            FiltroRegion = filRegion.Text.Trim().ToUpper();
            FiltroEstado = cmbEstado.SelectedValue.Trim().ToUpper();
            dlSucursales.InsertItemPosition = InsertItemPosition.None;
            dlSucursales.EditIndex = -1;
            dlSucursales.DataBind();
        }        
        else if (e.CommandName == "QuitarFiltro")
        {
            TextBox filClave = (TextBox)dlSucursales.FindControl("filClave");            
            if (filClave == null)
                filClave = (TextBox)e.Item.FindControl("filClave");
            
            TextBox filNombre = (TextBox)dlSucursales.FindControl("filNombre");            
            if (filNombre == null)
                filNombre = (TextBox)e.Item.FindControl("filNombre");
            
            TextBox filCiudad = (TextBox)dlSucursales.FindControl("filCiudad");            
            if (filCiudad == null)
                filCiudad = (TextBox)e.Item.FindControl("filCiudad");

            TextBox filRegion = (TextBox)dlSucursales.FindControl("filRegion");
            if (filRegion == null)
                filRegion = (TextBox)e.Item.FindControl("filRegion");

            ComboBox cmbEstado = (ComboBox)dlSucursales.FindControl("cmbEstado");
            if (cmbEstado == null)
                cmbEstado = (ComboBox)e.Item.FindControl("cmbEstado");

            filClave.Text = "";
            filNombre.Text = "";
            filCiudad.Text = "";
            filRegion.Text = "";
            cmbEstado.Items.FindByValue("T").Selected = true;

            FiltroClave = "";
            FiltroNombre = "";
            FiltroCiudad = "";
            FiltroCiudad = "";
            FiltroEstado = "T";
            dlSucursales.DataBind();
        }


    }

    protected void dsCiudades_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = ViewState["ComboCiudades"];
    }

    protected void dsRegiones_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = ViewState["ComboRegiones"];
    }
    
    /// 
    /// </summary>
    /// <param name="usuarios"></param>

    protected void dlSucursales_ItemInserting(object sender, ListViewInsertEventArgs e)
    {
        control = new AdministrarSucursalesControlador(this);

        Sucursal sucursal = new Sucursal();
        sucursal.ClaveSucursal = e.Values["ClaveSucursal"].ToString();
        sucursal.Nombre = e.Values["Nombre"].ToString();
        sucursal.ClaveCiudad = e.Values["ClaveCiudad"].ToString();
        sucursal.ClaveRegion = e.Values["ClaveRegion"].ToString();
        sucursal.Estado = (bool)e.Values["Estado"];
        sucursal.CodigoBarrasLlegada = e.Values["CodigoBarrasLlegada"].ToString();
        sucursal.CodigoBarrasSalida = e.Values["CodigoBarrasSalida"].ToString();

        control.Insertar(sucursal);

        Sucursales = control.ObtenerSucursalesInicio();
        dlSucursales.DataBind();
        dlSucursales.InsertItemPosition = InsertItemPosition.None;
        e.Cancel = true;        
    }

    protected void dlSucursales_ItemUpdating(object sender, ListViewUpdateEventArgs e) {
        control = new AdministrarSucursalesControlador(this);

        Sucursal sucursal = new Sucursal();
        sucursal.ClaveSucursal = e.Keys["ClaveSucursal"].ToString();
        sucursal.Nombre = e.NewValues["Nombre"].ToString();
        sucursal.ClaveCiudad = e.NewValues["ClaveCiudad"].ToString();                        
        sucursal.ClaveRegion = e.NewValues["ClaveRegion"].ToString();                                
        sucursal.Estado = (bool)e.NewValues["Estado"];
        sucursal.CodigoBarrasLlegada = e.NewValues["CodigoBarrasLlegada"].ToString();
        sucursal.CodigoBarrasSalida = e.NewValues["CodigoBarrasSalida"].ToString();
        
        control.Actualizar(sucursal);        
        
        control = new AdministrarSucursalesControlador(this);
        Sucursales = control.ObtenerSucursalesInicio();
        dlSucursales.DataBind();
        dlSucursales.EditIndex = -1;                
        e.Cancel = true;
    }
    
    protected void dlSucursales_ItemCreated(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.InsertItem)
        {
            CheckBox chkEstado = (CheckBox)e.Item.FindControl("chkActivo");
            if (chkEstado != null)
            {
                chkEstado.Checked = true;
            }
        }
    }

    protected void dlSucursales_DataBound(object sender, EventArgs e)
    {
        UtilEtiquetas.CargarEtiquetas(dlSucursales);
    }

    public void validaClave(object source, ServerValidateEventArgs e)
    {
        if (dlSucursales.InsertItem != null) {
            TextBox clave = (TextBox)dlSucursales.InsertItem.FindControl("txtClave");
            if (clave != null && clave.Text != string.Empty) {
                control = new AdministrarSucursalesControlador(this);
                Sucursal obj = null;
                obj = control.ObtenerSucursal(clave.Text);

                if (obj == null) {
                    e.IsValid = true;
                    return;
                }
            }
            e.IsValid = false;
        }
    }

    public void validaEstadoSucursal(object source, ServerValidateEventArgs e)
    {

        CheckBox estado = (CheckBox)this.dlSucursales.EditItem.FindControl("chkActivo");
        string clave = ((TextBox)this.dlSucursales.EditItem.FindControl("txtClave")).Text;
        
        if (estado == null)
            return;

        if (estado.Checked == false) {
            control = new AdministrarSucursalesControlador(this);
            e.IsValid = control.validaEstadoSucursal(clave);
        }

        
    }

    


#region IAdministrarSucursales Members

 void  IAdministrarSucursales.PresentaListaSucursales(Sucursal[] Sucursales)
{
    int  i = 0;
 	//throw new NotImplementedException();
}

#endregion
 protected void dlSucursales_PagePropertiesChanged(object sender, EventArgs e)
 {
     dlSucursales.EditIndex = -1;
     dlSucursales.InsertItemPosition = InsertItemPosition.None;
 }
}