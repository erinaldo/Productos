using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MODMEG;
using PREMEG.Catalogos;
using AjaxControlToolkit;

public partial class AdministracionTerminales : System.Web.UI.Page, IAdministrarTerminales
{
    AdministrarTerminalesControlador control;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            control = new AdministrarTerminalesControlador(this);            
            FiltroClave = "";
            FiltroModelo = "";
            FiltroNumeroSerie = "";
            FiltroSucursal = "";
            FiltroComentario = "";
            FiltroFase = 0;
            FiltroGPS = "T";
            
            Terminales = control.ObtenerTerminalesInicio();
            ViewState["ComboSucursales"] = control.ObtenerSucursales();
            ViewState["ComboValorReferencia"] = control.ObtenerValorReferencia();
        }
    }

    private List<Terminal> Terminales
    {
        get
        {
            return (List<Terminal>)Session["Terminales"];
        }
        set
        {
            Session["Terminales"] = value;
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

    private string FiltroModelo
    {
        set
        {
            ViewState["FiltroModelo"] = value;
        }
        get
        {
            return ViewState["FiltroModelo"].ToString();
        }
    }

    private string FiltroNumeroSerie
    {
        set
        {
            ViewState["FiltroNumeroSerie"] = value;
        }
        get
        {
            return ViewState["FiltroNumeroSerie"].ToString();
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
    private string FiltroComentario
    {
        set
        {
            ViewState["FiltroComentario"] = value;
        }
        get
        {
            return ViewState["FiltroComentario"].ToString();
        }
    }

    private int FiltroFase
    {
        set
        {
            ViewState["FiltroFase"] = value;
        }
        get
        {
            return (int)ViewState["FiltroFase"];
        }
    }

    private string FiltroGPS
    {
        set
        {
            ViewState["FiltroGPS"] = value;
        }
        get
        {
            return ViewState["FiltroGPS"].ToString();
        }
    }

    #endregion

    private List<Terminal> ObtenerDataSource()
    {

        //TODO: jvaldes checar listado fase
        List<Terminal> terminal = Terminales;
        List<Terminal> res = terminal.Where(
            obj => obj.ClaveTerminal.ToUpper().Contains(FiltroClave) && 
                obj.Modelo.ToUpper().Contains(FiltroModelo) &&
                obj.NumeroSerie.ToUpper().Contains(FiltroNumeroSerie) &&
                obj.Sucursal.Nombre.ToUpper().Contains(FiltroSucursal) &&
                (FiltroComentario == "" || (obj.Comentario != null && obj.Comentario.ToUpper().Contains(FiltroComentario))) &&
                (FiltroFase == 0 || obj.Fase == FiltroFase) &&
                ((obj.GPS == (FiltroGPS == "A" ? true : false)) || (FiltroGPS  == "T"))                
                ).ToList();

        if (res.Count == 0)
            res.Add(new Terminal());
        return res;
    }
    
    protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = ObtenerDataSource();

    }

    /*protected void Nuevo_Registro_Click(object sender, ImageClickEventArgs e)
    {
        dlTerminales.EditIndex = -1;
        dlTerminales.InsertItemPosition = InsertItemPosition.FirstItem;
        //((LinkButton)sender).Visible = false;
    }*/
    protected void Nuevo_Registro_Click(object sender, EventArgs e)
    {
        dlTerminales.EditIndex = -1;
        dlTerminales.InsertItemPosition = InsertItemPosition.FirstItem;
    }
    protected void dlTerminales_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "Guardar")
        {
            dlTerminales.EditIndex = -1;
            dlTerminales.DataBind();
        }

        if (e.CommandName == "Edit")
        {
            dlTerminales.InsertItemPosition = InsertItemPosition.None;

        }

        if (e.CommandName == "Cancel")
        {
            dlTerminales.InsertItemPosition = InsertItemPosition.None;
        }

        if (e.CommandName == "Filtrar")
        {
            TextBox filClave = (TextBox)dlTerminales.FindControl("filClave");
            if (filClave == null)
                filClave = (TextBox)e.Item.FindControl("filClave");

            TextBox filModelo = (TextBox)dlTerminales.FindControl("filModelo");
            if (filModelo == null)
                filModelo = (TextBox)e.Item.FindControl("filModelo");

            TextBox filNoSerie = (TextBox)dlTerminales.FindControl("filNoSerie");
            if (filNoSerie == null)
                filNoSerie = (TextBox)e.Item.FindControl("filNoSerie");

            TextBox filSucursal = (TextBox)dlTerminales.FindControl("filSucursal");
            if (filSucursal == null)
                filSucursal = (TextBox)e.Item.FindControl("filSucursal");

            TextBox filComentario = (TextBox)dlTerminales.FindControl("filComentario");
            if (filComentario == null)
                filComentario = (TextBox)e.Item.FindControl("filComentario");

            ComboBox filFase = (ComboBox)dlTerminales.FindControl("filFase");
            if (filFase == null)
                filFase = (ComboBox)e.Item.FindControl("filFase");

            ComboBox cmbGPS = (ComboBox)dlTerminales.FindControl("cmbGPS");
            if (cmbGPS == null)
                cmbGPS = (ComboBox)e.Item.FindControl("cmbGPS");

            FiltroClave = filClave.Text.Trim().ToUpper();
            FiltroModelo = filModelo.Text.Trim().ToUpper();
            FiltroNumeroSerie = filNoSerie.Text.Trim().ToUpper();
            FiltroSucursal = filSucursal.Text.Trim().ToUpper();
            FiltroComentario = filComentario.Text.Trim().ToUpper();
            FiltroFase = int.Parse(filFase.SelectedValue);
            FiltroGPS = cmbGPS.SelectedValue.Trim().ToUpper();
            dlTerminales.InsertItemPosition = InsertItemPosition.None;
            dlTerminales.EditIndex = -1;
            dlTerminales.DataBind();
        }
        else if (e.CommandName == "QuitarFiltro")
        {
            TextBox filClave = (TextBox)dlTerminales.FindControl("filClave");
            if (filClave == null)
                filClave = (TextBox)e.Item.FindControl("filClave");

            TextBox filModelo = (TextBox)dlTerminales.FindControl("filModelo");
            if (filModelo == null)
                filModelo = (TextBox)e.Item.FindControl("filModelo");

            TextBox filNoSerie = (TextBox)dlTerminales.FindControl("filNoSerie");
            if (filNoSerie == null)
                filNoSerie = (TextBox)e.Item.FindControl("filNoSerie");

            TextBox filSucursal = (TextBox)dlTerminales.FindControl("filSucursal");
            if (filSucursal == null)
                filSucursal = (TextBox)e.Item.FindControl("filSucursal");

            TextBox filComentario = (TextBox)dlTerminales.FindControl("filComentario");
            if (filComentario == null)
                filComentario = (TextBox)e.Item.FindControl("filSucursal");

            ComboBox filFase = (ComboBox)dlTerminales.FindControl("filFase");
            if (filFase == null)
                filFase = (ComboBox)e.Item.FindControl("filFase");

            ComboBox cmbGPS = (ComboBox)dlTerminales.FindControl("cmbGPS");
            if (cmbGPS == null)
                cmbGPS = (ComboBox)e.Item.FindControl("cmbGPS");

            filClave.Text = "";
            filModelo.Text = "";
            filNoSerie.Text = "";
            filSucursal.Text = "";
            filComentario.Text = "";
            filFase.Text = "";
            cmbGPS.Items.FindByValue("T").Selected = true;

            FiltroClave = "";
            FiltroModelo = "";
            FiltroNumeroSerie = "";
            FiltroSucursal = "";
            FiltroComentario = "";
            FiltroFase = 0;
            FiltroGPS = "T";
            dlTerminales.DataBind();
        }
    }

    protected void dsSucursales_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = ViewState["ComboSucursales"];
    }

    protected void dsValorReferencia_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = ViewState["ComboValorReferencia"];
    }
    protected void dsFaseFilter_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        List<PREMEG.Util.objCombo> list = (List<PREMEG.Util.objCombo>)ViewState["ComboValorReferencia"];
        
        list = list.Select(x => new PREMEG.Util.objCombo() { Clave = x.Clave, ClaveSucursal = x.ClaveSucursal, Texto = x.Texto }).ToList();
        list.Insert(0, new PREMEG.Util.objCombo()
        {
            Clave = "0",
            ClaveSucursal = "0",
            Texto = "Todas"
        });
        e.Result = list;
    }



    /// 
    /// </summary>
    /// <param name="usuarios"></param>
    protected void dlTerminales_ItemInserting(object sender, ListViewInsertEventArgs e)
    {        
        Terminal terminal = new Terminal();       
        terminal.ClaveTerminal = e.Values["ClaveTerminal"].ToString();
        terminal.ClaveSucursal = e.Values["ClaveSucursal"].ToString();
        terminal.Modelo = e.Values["Modelo"].ToString();
        terminal.NumeroSerie = e.Values["NumeroSerie"].ToString();
        terminal.GPS = (bool)e.Values["GPS"];
        terminal.Fase = Convert.ToSByte(e.Values["Fase"].ToString());


        terminal.Comentario = e.Values["Comentario"].ToString();         

        control = new AdministrarTerminalesControlador(this);
        control.Insertar(terminal);
        Terminales = control.ObtenerTerminalesInicio();
        dlTerminales.DataBind();
        dlTerminales.InsertItemPosition = InsertItemPosition.None;        
        e.Cancel = true;
    }

    protected void dlTerminales_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {        
        Terminal terminal = new Terminal();
        terminal.ClaveTerminal = e.Keys["ClaveTerminal"].ToString();
        terminal.ClaveSucursal = e.NewValues["ClaveSucursal"].ToString();        
        terminal.Modelo = e.NewValues["Modelo"].ToString();
        terminal.NumeroSerie = e.NewValues["NumeroSerie"].ToString();
        terminal.GPS = (bool)e.NewValues["GPS"];
        terminal.Fase = Convert.ToSByte(e.NewValues["Fase"].ToString()); ;
        terminal.Comentario = e.NewValues["Comentario"].ToString();        
        control = new AdministrarTerminalesControlador(this);
        control.Actualizar(terminal);
        Terminales = control.ObtenerTerminalesInicio();
        dlTerminales.DataBind();
        dlTerminales.EditIndex = -1;
        e.Cancel = true;
    }

    protected void dlTerminales_ItemCreated(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.InsertItem)
        {
            //CheckBox chkEstado = (CheckBox)e.Item.FindControl("chkActivo");
            //if (chkEstado != null)
            //{
            //    chkEstado.Checked = true;
            //}
        }
    }


    
    
    protected void dlTerminales_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        UtilEtiquetas.CargarEtiquetas(dlTerminales);
    }

    #region IAdministrarTerminales Members

    void IAdministrarTerminales.PresentaListaTerminales(Terminal[] Terminales)
    {
        throw new NotImplementedException();
    }


    public void validaClave(object source, ServerValidateEventArgs e)
    {
        if (dlTerminales.InsertItem != null)
        {
            TextBox clave = (TextBox)dlTerminales.InsertItem.FindControl("txtClave");
            if (clave != null && clave.Text != string.Empty)
            {
                control = new AdministrarTerminalesControlador(this);
                Terminal obj = null;
                
                obj = control.ObtenerTerminales(clave.Text);

                if (obj == null)
                {
                    e.IsValid = true;
                    return;
                }
            }
            e.IsValid = false;
        }
    }


    #endregion
    protected void dlTerminales_PagePropertiesChanged(object sender, EventArgs e)
    {
        dlTerminales.EditIndex = -1;
        dlTerminales.InsertItemPosition = InsertItemPosition.None;
    }
}