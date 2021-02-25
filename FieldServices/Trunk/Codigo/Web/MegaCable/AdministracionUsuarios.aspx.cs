using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PREMEG.Acceso;
using System.Data.Objects;
using AjaxControlToolkit;
using MODMEG;

public partial class Default2 : System.Web.UI.Page, IAdministracionUsuarios
{

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
    private string FiltroPerfil
    {
        set
        {
            ViewState["FiltroPerfil"] = value;
        }
        get
        {
            return ViewState["FiltroPerfil"].ToString();
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
    private string FiltroCuadrilla
    {
        set
        {
            ViewState["FiltroCuadrilla"] = value;
        }
        get
        {
            return ViewState["FiltroCuadrilla"].ToString();
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
    {//TODO: Ver lo de la seleccion del usuario para mostrar sus datos
        if (!this.IsPostBack)
        {
            FiltroNombre = "";
            FiltroClave = "";
            FiltroPerfil = "";
            FiltroSucursal = "";
            FiltroCuadrilla = "";
            FiltroEstado = "T";
            
            AdministrarUsuarios control = new AdministrarUsuarios(this);
            Session["TablaUsuarios"] = control.ObtenerUsuariosInicio();
            CatalogosCargados = false;
            
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "CargarAlgo", "alert(\"cargado\")", false);
        }
        
    }
    private List<AdministrarUsuarios.ListaUsuarios> ObtenerDataSource()
    {
        List<AdministrarUsuarios.ListaUsuarios> usuario = (List<AdministrarUsuarios.ListaUsuarios>)Session["TablaUsuarios"];
        List<AdministrarUsuarios.ListaUsuarios> res = usuario.Where(usu =>
            usu.ClaveUsuario.ToUpper().Contains(FiltroClave) &&
            usu.Nombre.ToUpper().Contains(FiltroNombre) &&
            usu.NombrePerfil.ToUpper().Contains(FiltroPerfil) &&
            usu.NombreSucursal.ToUpper().Contains(FiltroSucursal) &&
            (FiltroCuadrilla == "" || (usu.ClaveCuadrilla != null && usu.ClaveCuadrilla.ToUpper().Contains(FiltroCuadrilla))) &&
            ((usu.Estado == (FiltroEstado == "A" ? true : false)) || (FiltroEstado == "T"))).ToList();
        if (res.Count == 0)
            res.Add(new AdministrarUsuarios.ListaUsuarios
            {
                ClaveUsuario = "",
                Nombre = "",
                NombrePerfil = "",
                NombreSucursal = "",
                Estado = false,
                ClavePerfil = "",
                Contrasenia = "",
                Tipo = 1,
                ClaveCuadrilla = "",
                ClaveSucursal = ""
            });
        return res;
    }


    public void PresentaListaUsuarios(MODMEG.Usuario[] usuarios)
    {
        throw new NotImplementedException();
    }
    protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = ObtenerDataSource();
    }


    protected void dlUsuarios_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "Guardar")
        {
            if (Page.IsValid)
            {
                TextBox txtNombre = (TextBox)e.Item.FindControl("txtNombre");
                TextBox txtContrasenia = (TextBox)e.Item.FindControl("txtContrasenia");
                ComboBox cmbPerfil = (ComboBox)e.Item.FindControl("cmbPerfil");
                ComboBox cmbTipo = (ComboBox)e.Item.FindControl("cmbTipo");
                ComboBox cmbCuadrilla = (ComboBox)e.Item.FindControl("cmbCuadrilla");
                ComboBox cmbSucursal = (ComboBox)e.Item.FindControl("cmbSucursal");

                CheckBox chkActivo = (CheckBox)e.Item.FindControl("chkActivo");
                //if (ValidarDatos((short?)Convert.ToInt16(cmbTipo.SelectedValue), cmbCuadrilla.SelectedValue))
                //{
                AdministrarUsuarios control = new AdministrarUsuarios(this);
                if (control.ActualizarUsuario(dlUsuarios.DataKeys[dlUsuarios.EditIndex].Value.ToString(),
                    cmbPerfil.SelectedValue,
                    (cmbCuadrilla.Visible ? cmbCuadrilla.SelectedValue : null),
                    cmbSucursal.SelectedValue,
                    Convert.ToInt16(cmbTipo.SelectedValue),
                    txtContrasenia.Text,
                    txtNombre.Text,
                    chkActivo.Checked))
                {
                    Session["TablaUsuarios"] = control.ObtenerUsuariosInicio();


                    dlUsuarios.EditIndex = -1;
                    dlUsuarios.DataBind();
                }

                //}
            }
        }
        
        else if (e.CommandName == "Filtrar")
        {
            TextBox filClave = (TextBox)dlUsuarios.FindControl("filClave");
            if (filClave == null)
                filClave = (TextBox)e.Item.FindControl("filClave");
            TextBox filNombre = (TextBox)dlUsuarios.FindControl("filNombre");
            if (filNombre == null)
                filNombre = (TextBox)e.Item.FindControl("filNombre");
            TextBox filPerfil = (TextBox)dlUsuarios.FindControl("filPerfil");
            if (filPerfil == null)
                filPerfil = (TextBox)e.Item.FindControl("filPerfil");
            TextBox filSucursal = (TextBox)dlUsuarios.FindControl("filSucursal");
            if (filSucursal == null)
                filSucursal = (TextBox)e.Item.FindControl("filSucursal");
            TextBox filCuadrilla = (TextBox)dlUsuarios.FindControl("filCuadrilla");
            if (filCuadrilla == null)
                filCuadrilla = (TextBox)e.Item.FindControl("filCuadrilla");
            ComboBox cmbEstado = (ComboBox)dlUsuarios.FindControl("cmbEstado");
            if (cmbEstado == null)
                cmbEstado = (ComboBox)e.Item.FindControl("cmbEstado");

            FiltroClave = filClave.Text.Trim().ToUpper();
            FiltroNombre = filNombre.Text.Trim().ToUpper();
            FiltroPerfil = filPerfil.Text.Trim().ToUpper();
            FiltroSucursal = filSucursal.Text.Trim().ToUpper();
            FiltroCuadrilla = filCuadrilla.Text.Trim().ToUpper();
            FiltroEstado = cmbEstado.SelectedValue.Trim().ToUpper();
            dlUsuarios.InsertItemPosition = InsertItemPosition.None;
            dlUsuarios.EditIndex = -1;
            dlUsuarios.DataBind();
        }
        else if (e.CommandName == "QuitarFiltro")
        {
            TextBox filClave = (TextBox)dlUsuarios.FindControl("filClave");
            if (filClave == null)
                filClave = (TextBox)e.Item.FindControl("filClave");
            TextBox filNombre = (TextBox)dlUsuarios.FindControl("filNombre");
            if (filNombre == null)
                filNombre = (TextBox)e.Item.FindControl("filNombre");
            TextBox filPerfil = (TextBox)dlUsuarios.FindControl("filPerfil");
            if (filPerfil == null)
                filPerfil = (TextBox)e.Item.FindControl("filClave");
            TextBox filSucursal = (TextBox)dlUsuarios.FindControl("filSucursal");
            if (filSucursal == null)
                filSucursal = (TextBox)e.Item.FindControl("filSucursal");
            TextBox filCuadrilla = (TextBox)dlUsuarios.FindControl("filCuadrilla");
            if (filCuadrilla == null)
                filCuadrilla = (TextBox)e.Item.FindControl("filCuadrilla");
            ComboBox cmbEstado = (ComboBox)dlUsuarios.FindControl("cmbEstado");
            if (cmbEstado == null)
                cmbEstado = (ComboBox)e.Item.FindControl("cmbEstado");

            filClave.Text = "";
            filNombre.Text = "";
            filPerfil.Text = "";
            filSucursal.Text = "";
            filCuadrilla.Text = "";
            cmbEstado.Items.FindByValue("T").Selected = true;

            FiltroClave = "";
            FiltroNombre = "";
            FiltroPerfil = "";
            FiltroSucursal = "";
            FiltroCuadrilla = "";
            FiltroEstado = "T";
            dlUsuarios.DataBind();
        }
        else if (e.CommandName == "Cancel")
        {
            dlUsuarios.InsertItemPosition = InsertItemPosition.None;
        }
    }
    protected void dsPerfiles_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = Session["ComboPerfiles"];
    }

    protected void dlUsuarios_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.DisplayIndex == dlUsuarios.EditIndex)
        {
            AdministrarUsuarios.ListaUsuarios usu = (AdministrarUsuarios.ListaUsuarios)e.Item.DataItem;
            ComboBox cmb = (ComboBox)e.Item.FindControl("cmbPerfil");
            if ((cmb != null) && (usu.ClavePerfil != null))
            {
                ListItem item = cmb.Items.FindByValue(usu.ClavePerfil);
                if (item != null)                    
                    item.Selected = true;
                /*else
                    cmb.BackColor = System.Drawing.Color.FromArgb(255, 255, 157);*/
            }
            cmb = (ComboBox)e.Item.FindControl("cmbTipo");
            if ((cmb != null) && (usu.Tipo != null))
            {
                ListItem item = cmb.Items.FindByValue(usu.Tipo.ToString());
                if (item != null)
                {
                    cmb.SelectedValue = item.Value;
                    item.Selected = true;
                    
                    
                }
                /*else
                    cmb.BackColor = System.Drawing.Color.FromArgb(255, 255, 157);*/
            }
            cmb = (ComboBox)e.Item.FindControl("cmbSucursal");
            if ((cmb != null) && (usu.ClaveSucursal != null))
            {
                //cmb.SelectedIndex = -1;
                ListItem item = cmb.Items.FindByValue(usu.ClaveSucursal);
                if (item != null)
                {
                    item.Selected = true;
                    cmb.SelectedValue = item.Value;
                    ComboBox cmbCuadrilla = (ComboBox)e.Item.FindControl("cmbCuadrilla");
                    ComboBox cmbTipo = (ComboBox)e.Item.FindControl("cmbTipo");
                    Label lblCuadrilla = (Label)e.Item.FindControl("lblCuadrilla");
                    MostrarCuadrilla(cmbTipo, lblCuadrilla, cmbCuadrilla, cmb);
                }
                /*else
                    cmb.BackColor = System.Drawing.Color.FromArgb(255, 255, 157);*/
            }
            cmb = (ComboBox)e.Item.FindControl("cmbCuadrilla");
            if ((cmb != null) && (usu.ClaveCuadrilla != null))
            {
                ListItem item = cmb.Items.FindByValue(usu.ClaveCuadrilla);
                if (item != null)
                {
                    item.Selected = true;
                    cmb.SelectedValue = item.Value;
                }
                /*else
                    cmb.BackColor = System.Drawing.Color.FromArgb(255, 255, 157);*/
            }
            
        }
    }

    protected void dlUsuarios_ItemEditing(object sender, ListViewEditEventArgs e)
    {
        dlUsuarios.InsertItemPosition = InsertItemPosition.None;
        if ( !CatalogosCargados)
        {
            AdministrarUsuarios control = new AdministrarUsuarios(this);
            control.CrearModificarPerfil();
        }

    }
    public void CargarCatalogos(object perfiles, object valores, object sucursales, object cuadrillas)
    {
        Session["ComboPerfiles"] = perfiles;
        Session["ComboValores"] = valores;
        Session["ComboSucursales"] = sucursales;
        Session["ComboCuadrillas"] = cuadrillas;

    }
    protected void dsTipos_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = Session["ComboValores"];
        
    }

    protected void dsCuadrillas_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        
        e.Result = Session["ComboCuadrillasFiltradas"] == null ? Session["ComboCuadrillas"] : Session["ComboCuadrillasFiltradas"];
    }
    protected void dsSucursales_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = Session["ComboSucursales"];
    }
    protected void dlUsuarios_DataBound(object sender, EventArgs e)
    {
        UtilEtiquetas.CargarEtiquetas(dlUsuarios);
        if (dlUsuarios.InsertItem != null)
        {
            Label lblCuadrilla = (Label)dlUsuarios.InsertItem.FindControl("lblCuadrilla");
            ComboBox cmbCuadrilla = (ComboBox)dlUsuarios.InsertItem.FindControl("cmbCuadrilla");
            ComboBox cmbTipo = (ComboBox)dlUsuarios.InsertItem.FindControl("cmbTipo");
            ComboBox cmbSucursal = (ComboBox)dlUsuarios.InsertItem.FindControl("cmbSucursal");
            MostrarCuadrilla(cmbTipo, lblCuadrilla, cmbCuadrilla, cmbSucursal);
        }
    }
    protected void cmbSucursal_SelectedIndexChanged(object source, EventArgs e)
    {
        ComboBox cmbCuadrilla;
        ComboBox cmbSucursal;
        Label lblCuadrilla;
        ComboBox cmbTipo;
        if (dlUsuarios.EditIndex != -1)
        {
            cmbCuadrilla = (ComboBox)dlUsuarios.EditItem.FindControl("cmbCuadrilla");
            lblCuadrilla = (Label)dlUsuarios.EditItem.FindControl("lblCuadrilla");
            cmbSucursal = (ComboBox)dlUsuarios.EditItem.FindControl("cmbSucursal");
            cmbTipo = (ComboBox)dlUsuarios.EditItem.FindControl("cmbTipo");
        }
        else
        {
            cmbCuadrilla = (ComboBox)dlUsuarios.InsertItem.FindControl("cmbCuadrilla");
            lblCuadrilla = (Label)dlUsuarios.InsertItem.FindControl("lblCuadrilla");
            cmbSucursal = (ComboBox)dlUsuarios.InsertItem.FindControl("cmbSucursal");
            cmbTipo = (ComboBox)dlUsuarios.InsertItem.FindControl("cmbTipo");
        }
        MostrarCuadrilla(cmbTipo, lblCuadrilla, cmbCuadrilla, cmbSucursal);
    }
    protected void cmbTipo_SelectedIndexChanged(object source, EventArgs e)
    {
        ComboBox cmbCuadrilla ;
        ComboBox cmbSucursal;
        Label lblCuadrilla;
        if (dlUsuarios.EditIndex != -1)
        {
            cmbCuadrilla = (ComboBox)dlUsuarios.EditItem.FindControl("cmbCuadrilla");
            lblCuadrilla = (Label)dlUsuarios.EditItem.FindControl("lblCuadrilla");
            cmbSucursal = (ComboBox)dlUsuarios.EditItem.FindControl("cmbSucursal");
        }
        else
        {
            cmbCuadrilla = (ComboBox)dlUsuarios.InsertItem.FindControl("cmbCuadrilla");
            lblCuadrilla = (Label)dlUsuarios.InsertItem.FindControl("lblCuadrilla");
            cmbSucursal = (ComboBox)dlUsuarios.InsertItem.FindControl("cmbSucursal");
        }
        ComboBox cmbTipo = (ComboBox)source;
        MostrarCuadrilla(cmbTipo, lblCuadrilla, cmbCuadrilla, cmbSucursal);
    }

    
    private void MostrarCuadrilla(ComboBox cmbTipo, Label lblCuadrilla, ComboBox cmbCuadrilla, ComboBox cmbSucursal)
    {
        List<PREMEG.Acceso.AdministrarUsuarios.ListaValoresReferencia> valores = (List<PREMEG.Acceso.AdministrarUsuarios.ListaValoresReferencia>)Session["ComboValores"];
        List<AdministrarUsuarios.EleCuadrilla> cuadrillas = (List<AdministrarUsuarios.EleCuadrilla>)Session["ComboCuadrillas"];
        Session["ComboCuadrillasFiltradas"] = cuadrillas.Where(c => c.ClaveSucursal == cmbSucursal.SelectedValue).ToList();
        if (valores.Exists(v => v.Valor == Convert.ToInt16(cmbTipo.SelectedValue) && v.Grupo == 1))
        {
            lblCuadrilla.Visible = true;
            cmbCuadrilla.Visible = true;

            cuadrillas = (List<AdministrarUsuarios.EleCuadrilla>)Session["ComboCuadrillasFiltradas"];
            cmbCuadrilla.DataBind();
            if (cuadrillas.Count == 0)
                cmbCuadrilla.Items.Add(new ListItem("", ""));
        }
        else
        {
            lblCuadrilla.Visible = false;
            cmbCuadrilla.Visible = false;
        }
    }
    /*protected void Nuevo_Registro_Click(object sender, EventArgs e)
    {
        if (!CatalogosCargados)
        {
            AdministrarUsuarios control = new AdministrarUsuarios(this);
            control.CrearModificarPerfil();
        }
        dlUsuarios.EditIndex = -1;
        dlUsuarios.InsertItemPosition = InsertItemPosition.FirstItem;

    }*/
    protected void Nuevo_Registro_Click(object sender, EventArgs e)
    {
        if (!CatalogosCargados)
        {
            AdministrarUsuarios control = new AdministrarUsuarios(this);
            control.CrearModificarPerfil();
        }
        dlUsuarios.EditIndex = -1;
        dlUsuarios.InsertItemPosition = InsertItemPosition.FirstItem;
    }
    protected void dlUsuarios_ItemInserting(object sender, ListViewInsertEventArgs e)
    {
        if (Page.IsValid)
        {
            AdministrarUsuarios control = new AdministrarUsuarios(this);
            CheckBox chk = (CheckBox)e.Item.FindControl("chkActivo");
            ComboBox cmbCuadrilla = (ComboBox)e.Item.FindControl("cmbCuadrilla");
            control.RegistrarUsuario(e.Values["ClaveUsuario"].ToString(), e.Values["ClavePerfil"].ToString(), (cmbCuadrilla.SelectedValue == null || cmbCuadrilla.SelectedValue == "" ? null : cmbCuadrilla.SelectedValue), e.Values["ClaveSucursal"].ToString(), Convert.ToInt16(e.Values["Tipo"]), e.Values["Contrasenia"].ToString(), e.Values["Nombre"].ToString(), chk.Checked);
            Session["TablaUsuarios"] = control.ObtenerUsuariosInicio();
            dlUsuarios.InsertItemPosition = InsertItemPosition.None;
            dlUsuarios.DataBind();
            e.Cancel = true;
        }
    }


    public void ValidarDatos(object source, ServerValidateEventArgs e)
    {
        bool estado = false;
        string ClaveUsuario = "";
        string ClaveCuadrilla = "";
        CustomValidator validador = null;
        if (this.dlUsuarios.EditIndex != -1)
        {
            estado = ((CheckBox)this.dlUsuarios.EditItem.FindControl("chkActivo")).Checked;
            ClaveUsuario = ((TextBox)this.dlUsuarios.EditItem.FindControl("txtClave")).Text;
            ClaveCuadrilla = ((ComboBox)this.dlUsuarios.EditItem.FindControl("cmbCuadrilla")).SelectedValue;
            validador = (CustomValidator)this.dlUsuarios.EditItem.FindControl("CustomValidator5");
        }
        else
        {
            estado = ((CheckBox)this.dlUsuarios.InsertItem.FindControl("chkActivo")).Checked;
            ClaveUsuario = ((TextBox)this.dlUsuarios.InsertItem.FindControl("txtClave")).Text;
            ClaveCuadrilla = ((ComboBox)this.dlUsuarios.InsertItem.FindControl("cmbCuadrilla")).SelectedValue;
            validador = (CustomValidator)this.dlUsuarios.InsertItem.FindControl("CustomValidator5");
        }

        AdministrarUsuarios control = new AdministrarUsuarios(this);
        AdministrarUsuarios.ResultadoValidacion resultado = control.ValidarDatos(estado, ClaveUsuario, ClaveCuadrilla, (this.dlUsuarios.EditIndex == -1));
        switch (resultado)
        {
            /*case AdministrarUsuarios.ResultadoValidacion.CuadrillaAsignada :
                validador.ErrorMessage = UtilMensaje.ObtenerMensaje("");
                break;*/
            case AdministrarUsuarios.ResultadoValidacion.Relacionado:
                validador.ErrorMessage = UtilMensaje.ObtenerMensaje("#ME0025");
                break;
            case AdministrarUsuarios.ResultadoValidacion.UsuarioExistente:
                validador.ErrorMessage = UtilMensaje.ObtenerMensaje("#MI0008");
                break;
                
        }
        e.IsValid = (resultado == AdministrarUsuarios.ResultadoValidacion.TodoBien);


    }

    protected void dlUsuarios_PagePropertiesChanged(object sender, EventArgs e)
    {
        dlUsuarios.EditIndex = -1;
        dlUsuarios.InsertItemPosition = InsertItemPosition.None;
    }
}