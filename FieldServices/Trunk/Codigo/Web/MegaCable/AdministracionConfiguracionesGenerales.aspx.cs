using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PREMEG.Catalogos;
using MODMEG;
using AjaxControlToolkit;
using MEGACABLE.CONTROLS;

public partial class AdministracionConfiguracionesGenerales : System.Web.UI.Page, IAdministrarConfiguraciones
{

    AdministrarConfiguracionesControlador control;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            control = new AdministrarConfiguracionesControlador(this);
            FiltroSucursal = "";
            FiltroParametro = "";
            FiltroValor = "";
           
            Configuraciones = control.ObtenerConfiguracionesInicio();
            ViewState["ComboSucursales"] = control.ObtenerSucursales();
            ViewState["ComboValorConfiguracion"] = control.ObtenerValorConfiguracion();
            ViewState["ComboValorReferencia"] = control.ObtenerValorReferencia("");
        }
    }

    private List<Configuracion> Configuraciones
    {
        get
        {
            return (List<Configuracion>)ViewState["Configuraciones"];
        }
        set
        {
            ViewState["Configuraciones"] = value;
        }
    }

    #region

    private string FiltroSucursal
    {
        set
        {
            ViewState["FiltroSucursal"] = value;
        }
        get
        {
            return ViewState["FiltroSucursal"].ToString();
        }
    }

    private string FiltroParametro
    {
        set
        {
            ViewState["FiltroParametro"] = value;
        }
        get
        {
            return ViewState["FiltroParametro"].ToString();
        }
    }

    private string FiltroValor
    {
        set
        {
            ViewState["FiltroValor"] = value;
        }
        get
        {
            return ViewState["FiltroValor"].ToString();
        }
    }

    

    #endregion

    private List<Configuracion> ObtenerDataSource()
    {
        List<Configuracion> configuracion = Configuraciones;
        List<Configuracion> res = configuracion.Where(
            obj => obj.Sucursal.ClaveSucursal.ToUpper().Contains(FiltroSucursal) &&
                obj.ValorConfiguracion.Parametro.ToUpper().Contains(FiltroParametro) &&
                obj.Valor.ToUpper().Contains(FiltroValor)
                ).ToList();

        if (res.Count == 0)
            res.Add(new Configuracion());
        return res;
    }

    protected void dsConfiguracion_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = ObtenerDataSource();
    }

    protected void dsSucursales_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = ViewState["ComboSucursales"];
    }

    protected void dsValorConfiguracion_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {        
        e.Result = ViewState["ComboValorConfiguracion"];
    }
        
    protected void dsValorReferencia_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {                        
        e.Result = ViewState["ComboValorReferencia"];
    }

    protected void dlConfiguracion_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "Guardar")
        {
            dlConfiguracion.EditIndex = -1;
            dlConfiguracion.DataBind();
        }

        if (e.CommandName == "Insert")
        {


        }

        if (e.CommandName == "Cancel")
        {
            dlConfiguracion.InsertItemPosition = InsertItemPosition.None;
        }

        if (e.CommandName == "Filtrar")
        {
            TextBox filSucursal = (TextBox)dlConfiguracion.FindControl("filSucursal");
            if (filSucursal == null)
                filSucursal = (TextBox)e.Item.FindControl("filSucursal");

            TextBox filParametro = (TextBox)dlConfiguracion.FindControl("filParametro");
            if (filParametro == null)
                filParametro = (TextBox)e.Item.FindControl("filParametro");

            TextBox filValor = (TextBox)dlConfiguracion.FindControl("filValor");
            if (filValor == null)
                filValor = (TextBox)e.Item.FindControl("filValor");


            FiltroSucursal = filSucursal.Text.Trim().ToUpper();
            FiltroParametro = filParametro.Text.Trim().ToUpper();
            FiltroValor = filValor.Text.Trim().ToUpper();

            dlConfiguracion.InsertItemPosition = InsertItemPosition.None;
            dlConfiguracion.EditIndex = -1;
            dlConfiguracion.DataBind();
        }
        else if (e.CommandName == "QuitarFiltro")
        {
            TextBox filSucursal = (TextBox)dlConfiguracion.FindControl("filSucursal");
            if (filSucursal == null)
                filSucursal = (TextBox)e.Item.FindControl("filSucursal");

            TextBox filParametro = (TextBox)dlConfiguracion.FindControl("filParametro");
            if (filParametro == null)
                filParametro = (TextBox)e.Item.FindControl("filParametro");

            TextBox filValor = (TextBox)dlConfiguracion.FindControl("filValor");
            if (filValor == null)
                filValor = (TextBox)e.Item.FindControl("filValor");


            filSucursal.Text = "";
            filParametro.Text = "";
            filValor.Text = "";

            FiltroSucursal = "";
            FiltroParametro = "";
            FiltroValor = "";


            dlConfiguracion.DataBind();
        }
    }

    protected void Nuevo_Registro_Click(object sender, EventArgs e)
    {
        dlConfiguracion.EditIndex = -1;
        dlConfiguracion.InsertItemPosition = InsertItemPosition.FirstItem;
    }
    /*protected void Nuevo_Registro_Click(object sender, ImageClickEventArgs e)
    {
        dlConfiguracion.EditIndex = -1;
        dlConfiguracion.InsertItemPosition = InsertItemPosition.FirstItem;
        //((LinkButton)sender).Visible = false;
    }*/

    protected void valorConfiguracion_indexChange(object sender, EventArgs e)
    {
        control = new AdministrarConfiguracionesControlador(this);
        ComboBox combo1 = null;
        ComboBox2 combo2 = null;
        // comboBox2 = null; 
        // TextBox txtValor = null;

        if (dlConfiguracion.InsertItem != null)
        {
            combo1 = ((AjaxControlToolkit.ComboBox)dlConfiguracion.InsertItem.FindControl("cmbParametro"));
            combo2 = (ComboBox2)dlConfiguracion.InsertItem.FindControl("cmbValor");
        }
        if (dlConfiguracion.EditItem != null)
        {
            combo1 = ((AjaxControlToolkit.ComboBox)dlConfiguracion.EditItem.FindControl("cmbParametro"));
            combo2 = (ComboBox2)dlConfiguracion.EditItem.FindControl("cmbValor");
        }
        if (combo1 == null || combo2 == null)
            return;

        
        ValorConfiguracion valorConfiguracion = control.ObtenerValorConfiguracion(combo1.SelectedValue.ToString());
        ViewState["ComboValorReferencia"] = control.ObtenerValorReferencia(valorConfiguracion.Clave);
        

        //txtValor = (TextBox)dlConfiguracion.InsertItem.FindControl("txtValor");
        
        
        if (((List<PREMEG.Util.objCombo>)ViewState["ComboValorReferencia"]).Count == 0)
        {
            combo2.DropDownStyle = ComboBoxStyle.Simple;
            combo2.Items.Clear();
            combo2.Items.Insert(0, "");
            return;
        }
        combo2.DropDownStyle = ComboBoxStyle.DropDownList;        
        combo2.DataBind();        
    }

    /// 
    /// </summary>
    /// <param name="usuarios"></param>
    protected void dlConfiguracion_ItemInserting(object sender, ListViewInsertEventArgs e)
    {
        Configuracion configuracion = new Configuracion();
        configuracion.Parametro = e.Values["Parametro"].ToString();
        configuracion.ClaveSucursal = e.Values["ClaveSucursal"].ToString();
        ComboBox2 combo2 = (ComboBox2)dlConfiguracion.InsertItem.FindControl("cmbValor");
        configuracion.Valor = combo2.SelectedValue.ToString();

        control = new AdministrarConfiguracionesControlador(this);
        control.Insertar(configuracion);
        Configuraciones = control.ObtenerConfiguracionesInicio();
        dlConfiguracion.DataBind();
        dlConfiguracion.InsertItemPosition = InsertItemPosition.None;
        
        e.Cancel = true;

      
    }

    protected void dlConfiguracion_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {
        Configuracion configuracion = new Configuracion();
        configuracion.Parametro = e.Keys["Parametro"].ToString();
        configuracion.ClaveSucursal = e.Keys["ClaveSucursal"].ToString();
        ComboBox2 combo2 = (ComboBox2)dlConfiguracion.EditItem.FindControl("cmbValor");
        configuracion.Valor = combo2.SelectedValue.ToString();

        control = new AdministrarConfiguracionesControlador(this);
        control.Actualizar(configuracion);
        Configuraciones = control.ObtenerConfiguracionesInicio();
        dlConfiguracion.DataBind();
        dlConfiguracion.EditIndex = -1;
        e.Cancel = true;
    }

    protected void dlConfiguracion_ItemCreated(object sender, ListViewItemEventArgs e)
    {        
        if ((ComboBox)e.Item.FindControl("cmbParametro") != null) {
            int i = 0;
        }

        if ((ComboBox)e.Item.FindControl("cmbValor") != null)
        {
            int i = 0;
        }
        
        if (e.Item.ItemType == ListViewItemType.InsertItem)
        {
            int i = 0;            
        }

        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            int i = 0; 
        }
    }

    protected void dlConfiguracion_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        UtilEtiquetas.CargarEtiquetas(dlConfiguracion);
    }

    #region IAdministrarConfiguraciones Members

    public void PresentaListaConfiguraciones(Configuracion[] Configuaracion)
    {
        throw new NotImplementedException();
    }

    #endregion

    protected void cmbValordsda_DataBound(object sender, EventArgs e)
    {
        int i = 0;
    }

    protected void dlConfiguracion_PreRender(object sender, EventArgs e)        
    {
        control = new AdministrarConfiguracionesControlador(this);
        ComboBox combo1 = null;
        ComboBox2 combo2 = null;
        

        if (dlConfiguracion.InsertItem != null)
        {
            combo1 = ((AjaxControlToolkit.ComboBox)dlConfiguracion.InsertItem.FindControl("cmbParametro"));
            combo2 = (ComboBox2)dlConfiguracion.InsertItem.FindControl("cmbValor");
        }
        
        if (dlConfiguracion.EditItem != null)
        {
            combo1 = ((AjaxControlToolkit.ComboBox)dlConfiguracion.EditItem.FindControl("cmbParametro"));
            combo2 = (ComboBox2)dlConfiguracion.EditItem.FindControl("cmbValor");
        }
                
        if (combo1 != null && combo2 != null)
        {
            ValorConfiguracion valorConfiguracion = control.ObtenerValorConfiguracion(combo1.SelectedValue.ToString());
            ViewState["ComboValorReferencia"] = control.ObtenerValorReferencia(valorConfiguracion.Clave);

            if (dlConfiguracion.InsertItem != null)
            {
                if (((List<PREMEG.Util.objCombo>)ViewState["ComboValorReferencia"]).Count == 0)
                {
                    combo2.DropDownStyle = ComboBoxStyle.Simple;
                    combo2.Items.Clear();
                    combo2.Texto = "";                    
                    return;
                }             
            }

            if (dlConfiguracion.EditItem != null)
            {

                HiddenField valor = (HiddenField)dlConfiguracion.EditItem.FindControl("HValor");
                if (((List<PREMEG.Util.objCombo>)ViewState["ComboValorReferencia"]).Count == 0)
                {
                    combo2.DropDownStyle = ComboBoxStyle.Simple;
                    combo2.Items.Clear();
                    combo2.Texto = valor.Value;                    
                    return;
                }               
                combo2.SelectedValue = valor.Value;
            }
                        
            combo2.DropDownStyle = ComboBoxStyle.DropDownList;
            combo2.DataBind();
            
        }
    }


    public void validaClave(object source, ServerValidateEventArgs e)
    {
        if (this.dlConfiguracion.InsertItem != null)
        {
            ComboBox cmbSucursal = (ComboBox)dlConfiguracion.InsertItem.FindControl("cmbSucursal");
            ComboBox cmbParametro = (ComboBox)dlConfiguracion.InsertItem.FindControl("cmbParametro");

            if (cmbSucursal != null && cmbParametro != null)
            {
                control = new AdministrarConfiguracionesControlador(this);
                Configuracion obj = null;

                obj = control.ObtenerConfiguraciones(cmbSucursal.SelectedValue, cmbParametro.SelectedValue);

                if (obj == null)
                {
                    e.IsValid = true;
                    return;
                }
            }
            
            e.IsValid = false;
        }
    }

    protected void dlConfiguracion_PagePropertiesChanged(object sender, EventArgs e)
    {
        dlConfiguracion.EditIndex = -1;
        dlConfiguracion.InsertItemPosition = InsertItemPosition.None;
    }
}