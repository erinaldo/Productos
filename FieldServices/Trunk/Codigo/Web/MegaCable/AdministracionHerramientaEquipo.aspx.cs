using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PREMEG.Catalogos;
using MODMEG;
using AjaxControlToolkit;
using PREMEG.Util;

public partial class AdministracionHerramientaEquipo : System.Web.UI.Page , IAdministrarHerramientasEquipo
{
    AdministrarHerramientasEquipoControlador control;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            control = new AdministrarHerramientasEquipoControlador(this);
            FiltroClave = "";
            FiltroDescripcion = "";
            FiltroNoEmpleado= "";
            FiltroSucursal = "";
            FiltroEstado = "T";

            Herramientas = control.ObtenerActivos();
            ComboUsuarios = control.ObtenerUsuarios();
            Sucursales = control.ObtenerSucursales();
            SucursalSeleccionada = "";
        }
    }

    private string SucursalSeleccionada
    {
        get
        {
            return ViewState["SucursalSeleccionada"].ToString();
        }
        set
        {
            ViewState["SucursalSeleccionada"] = value;
        }
    }
    private List<objCombo> ComboUsuarios
    {
        get
        {
            return (List<objCombo>)ViewState["ComboUsuarios"];
        }
        set
        {
            ViewState["ComboUsuarios"] = value;
        }
    }

    private List<Sucursal> Sucursales
    {
        get
        {
            return (List<Sucursal>)ViewState["Sucursales"];
        }
        set
        {
            ViewState["Sucursales"] = value;
        }
    }
    private List<ActivoFijo> Herramientas
    {
        get
        {
            return (List<ActivoFijo>)ViewState["Herramientas"];
        }
        set
        {
            ViewState["Herramientas"] = value;
        }
    }

    #region

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

    private string FiltroDescripcion 
    {
        set
        {
            ViewState["FiltroDescripcion"] = value;
        }
        get
        {
            return ViewState["FiltroDescripcion"].ToString();
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
    private string FiltroNoEmpleado
    {
        set
        {
            ViewState["FiltroNoEmpleado"] = value;
        }
        get
        {
            return ViewState["FiltroNoEmpleado"].ToString();
        }
    }
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

    #endregion

    private List<ActivoFijo> ObtenerDataSource()
    {        
        List<ActivoFijo> lista = Herramientas;
        List<ActivoFijo> res = lista.Where(
            obj => obj.ClaveActivo.ToUpper().Contains(FiltroClave) &&
                obj.Descripcion.ToUpper().Contains(FiltroDescripcion) &&
                obj.Usuario.ClaveUsuario.ToUpper().Contains(FiltroNoEmpleado) &&
                obj.Usuario.Sucursal.Nombre.ToUpper().Contains(FiltroSucursal) &&
                ((obj.Estado == (FiltroEstado == "A" ? true : false)) || (FiltroEstado == "T"))
                ).ToList();

        if (res.Count == 0)
            res.Add(new ActivoFijo());
        return res;
    }


   
    protected void dsActivoFijo_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = ObtenerDataSource();

    }

    protected void dsSucursales_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = Sucursales;
    }

    /*protected void Nuevo_Registro_Click(object sender, ImageClickEventArgs e)
    {
        dlActivoFijo.EditIndex = -1;
        dlActivoFijo.InsertItemPosition = InsertItemPosition.FirstItem;
        
        //((LinkButton)sender).Visible = false;
    }*/
    protected void Nuevo_Registro_Click(object sender, EventArgs e)
    {
        dlActivoFijo.EditIndex = -1;
        dlActivoFijo.InsertItemPosition = InsertItemPosition.FirstItem;
    }

    protected void dlActivoFijo_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "Guardar")
        {
            dlActivoFijo.EditIndex = -1;
            dlActivoFijo.DataBind();
        }
        else if (e.CommandName == "Cancelar")
        {
            //if (dlActivoFijo.InsertItemPosition != InsertItemPosition.None)
            dlActivoFijo.InsertItemPosition = InsertItemPosition.None;
            dlActivoFijo.EditIndex = -1;
        }
        else if (e.CommandName == "Filtrar")
        {
            TextBox filClave = (TextBox)dlActivoFijo.FindControl("filClave");
            if (filClave == null)
                filClave = (TextBox)e.Item.FindControl("filClave");

            TextBox filDescripcion = (TextBox)dlActivoFijo.FindControl("filDescripcion");
            if (filDescripcion == null)
                filDescripcion = (TextBox)e.Item.FindControl("filDescripcion");

            TextBox filNoEmpleado = (TextBox)dlActivoFijo.FindControl("filNoEmpleado");
            if (filNoEmpleado == null)
                filNoEmpleado = (TextBox)e.Item.FindControl("filNoEmpleado");

            TextBox filSucursal = (TextBox)dlActivoFijo.FindControl("filSucursal");
            if (filSucursal == null)
                filSucursal = (TextBox)e.Item.FindControl("filSucursal");


            ComboBox cmbEstado = (ComboBox)dlActivoFijo.FindControl("cmbEstado");

            if (cmbEstado == null)
                cmbEstado = (ComboBox)e.Item.FindControl("cmbEstado");

            FiltroClave = filClave.Text.Trim().ToUpper();
            FiltroDescripcion = filDescripcion.Text.Trim().ToUpper();
            FiltroNoEmpleado = filNoEmpleado.Text.Trim().ToUpper();
            FiltroSucursal = filSucursal.Text.Trim().ToUpper();
            FiltroEstado = cmbEstado.SelectedValue.Trim().ToUpper();
            dlActivoFijo.InsertItemPosition = InsertItemPosition.None;
            dlActivoFijo.EditIndex = -1;
            dlActivoFijo.DataBind();
        }
        else if (e.CommandName == "QuitarFiltro")
        {
            TextBox filClave = (TextBox)dlActivoFijo.FindControl("filClave");
            if (filClave == null)
                filClave = (TextBox)e.Item.FindControl("filClave");

            TextBox filDescripcion = (TextBox)dlActivoFijo.FindControl("filDescripcion");
            if (filDescripcion == null)
                filDescripcion = (TextBox)e.Item.FindControl("filDescripcion");

            TextBox filNoEmpleado = (TextBox)dlActivoFijo.FindControl("filNoEmpleado");
            if (filNoEmpleado == null)
                filNoEmpleado = (TextBox)e.Item.FindControl("filNoEmpleado");

            TextBox filSucursal = (TextBox)dlActivoFijo.FindControl("filSucursal");
            if (filSucursal == null)
                filSucursal = (TextBox)e.Item.FindControl("filSucursal");

            ComboBox cmbEstado = (ComboBox)dlActivoFijo.FindControl("cmbEstado");

            if (cmbEstado == null)
                cmbEstado = (ComboBox)e.Item.FindControl("cmbEstado");

            filClave.Text = "";
            filDescripcion.Text = "";
            filNoEmpleado.Text = "";
            filSucursal.Text = "";
            cmbEstado.Items.FindByValue("T").Selected = true;

            FiltroClave = "";
            FiltroDescripcion = "";
            FiltroSucursal = "";
            FiltroNoEmpleado = "";
            FiltroEstado = "T";
            dlActivoFijo.DataBind();
        }
        else if (e.CommandName == "Edit")
        {
            dlActivoFijo.InsertItemPosition = InsertItemPosition.None;
        }
        
    }

    protected void dsUsuarios_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        if (SucursalSeleccionada == "")
            e.Result = ComboUsuarios.ToList();
        else
            e.Result = ComboUsuarios.Where(x => x.ClaveSucursal == SucursalSeleccionada).ToList();
    }


    /// 
    /// </summary>
    /// <param name="usuarios"></param>
    protected void dlActivoFijo_ItemInserting(object sender, ListViewInsertEventArgs e)
    {
        ActivoFijo  obj = new ActivoFijo();
        obj.ClaveActivo = e.Values["ClaveActivo"].ToString();

        ComboBox cmbUsuario = (ComboBox)e.Item.FindControl("cmbUsuario");
        obj.ClaveUsuario = cmbUsuario.SelectedValue;
        obj.Descripcion = e.Values["Descripcion"].ToString();
        obj.NumeroSerie = e.Values["NumeroSerie"].ToString();
        obj.Estado = (bool)e.Values["Estado"];
       
        control = new AdministrarHerramientasEquipoControlador(this);
        control.Insertar(obj);
        Herramientas = control.ObtenerActivos();
        dlActivoFijo.DataBind();
        dlActivoFijo.InsertItemPosition = InsertItemPosition.None;
        e.Cancel = true;
    }

    protected void dlActivoFijo_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {
        ActivoFijo obj = new ActivoFijo();
        obj.ClaveActivo = e.Keys["ClaveActivo"].ToString();
        ComboBox cmbUsuario = (ComboBox )dlActivoFijo.EditItem.FindControl("cmbUsuario");
        obj.ClaveUsuario= cmbUsuario.SelectedValue;
        obj.Descripcion = e.NewValues["Descripcion"].ToString();
        obj.NumeroSerie= e.NewValues["NumeroSerie"].ToString();
        obj.Estado = (bool)e.NewValues["Estado"];

        control = new AdministrarHerramientasEquipoControlador(this);
        control.Actualizar(obj);
        Herramientas= control.ObtenerActivos();
        dlActivoFijo.DataBind();
        dlActivoFijo.EditIndex = -1;
        e.Cancel = true;
    }

    
   
    protected void dlActivoFijo_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.DisplayIndex == dlActivoFijo.EditIndex)
        {
            ComboBox cmbSucursal = (ComboBox) e.Item.FindControl("cmbSucursal");
            ActivoFijo act = (ActivoFijo)e.Item.DataItem;
            cmbSucursal.SelectedValue = act.Usuario.ClaveSucursal;
            SucursalSeleccionada = act.Usuario.ClaveSucursal;
            ComboBox cmbUsuario = (ComboBox)e.Item.FindControl("cmbUsuario");
            cmbUsuario.DataBind();
            if (cmbUsuario.Items.Count == 0)
            {
                cmbUsuario.Text = "";
                cmbUsuario.SelectedIndex = -1;
            }
            else
                cmbUsuario.SelectedValue = act.Usuario.ClaveUsuario;
        }
        UtilEtiquetas.CargarEtiquetas(dlActivoFijo);
    }


    public void validaClave(object source, ServerValidateEventArgs e)
    {
        if (dlActivoFijo.InsertItem != null)
        {
            TextBox clave = (TextBox)this.dlActivoFijo.InsertItem.FindControl("txtClave");
            if (clave != null && clave.Text != string.Empty)
            {
                control = new AdministrarHerramientasEquipoControlador(this);
                ActivoFijo obj = null;
                obj = control.ObtenerActivos(clave.Text);


                if (obj == null)
                {
                    e.IsValid = true;
                    return;
                }
            }
            e.IsValid = false;
        }
    }


    protected void dlActivoFijo_ItemCreated(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.InsertItem)
        {
            CheckBox chkEstado = (CheckBox)e.Item.FindControl("chkEstado");
            if (chkEstado != null)
            {
                chkEstado.Checked = true;
            }

            ComboBox cmbSucursal = (ComboBox)e.Item.FindControl("cmbSucursal");
            cmbSucursal.SelectedIndex = 0;
        }
    }

    protected void cmbSucursal_OnSelected(object sender, EventArgs e)
    {
        ComboBox combo = ((ComboBox)sender);
        SucursalSeleccionada = combo.SelectedValue;
        ComboBox cmbUsuario = (ComboBox)combo.Parent.FindControl("cmbUsuario");
        cmbUsuario.DataBind();
    }
    protected void cmbSucursal_Bound(object sender, EventArgs e)
    {
        if (SucursalSeleccionada == "")
            SucursalSeleccionada = ((ComboBox)sender).SelectedValue;
    }
    protected void cmbUsuario_Bound(object sender, EventArgs e)
    {
        ComboBox cmbUsuario = (ComboBox)sender;
        if (cmbUsuario.Items.Count == 0)
            cmbUsuario.SelectedIndex = -1;
    }

    public void validaEstado(object source, ServerValidateEventArgs e)
    {

        CheckBox estado = (CheckBox)this.dlActivoFijo.EditItem.FindControl("chkActivo");
        string clave = ((TextBox)this.dlActivoFijo.EditItem.FindControl("txtClave")).Text;

        if (estado == null)
            return;

        if (estado.Checked == false)
        {
            control = new AdministrarHerramientasEquipoControlador(this);
            e.IsValid = control.validaEstadoHerramientas(clave);
        }


    }
    protected void dlActivoFijo_PagePropertiesChanged(object sender, EventArgs e)
    {
        dlActivoFijo.EditIndex = -1;
        dlActivoFijo.InsertItemPosition = InsertItemPosition.None;
    }

    protected void dlActivoFijo_PreRender(object sender, EventArgs e)
    {
    }
    protected void dlActivoFijo_DataBinding(object sender, EventArgs e)
    {

    }
}