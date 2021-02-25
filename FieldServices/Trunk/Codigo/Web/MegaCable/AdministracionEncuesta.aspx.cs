using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PREMEG.Acceso;
using MODMEG;
using System.Data.Objects.DataClasses;
using AjaxControlToolkit;

public partial class AdministracionEncuesta : System.Web.UI.Page
{

    private Encuesta encActual
    {
        get
        {
            if (Session["EditarEncuesta"] == null)
                return null;
            return (Encuesta)Session["EditarEncuesta"];
        }
        set
        {
            Session["EditarEncuesta"] = value;
        }
    }
    private List<Pregunta> pregEncuesta
    {
        get
        {
            return (List<Pregunta>)Session["PreguntaEncuesta"];
        }
        set
        {
            Session["PreguntaEncuesta"] = value;
        }
    }
    private List<PreguntaOpcion> opcionesPregunta
    {
        get
        {
            return (List<PreguntaOpcion>)Session["OpcionesPregunta"];
        }
        set
        {
            Session["OpcionesPregunta"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            AdministrarEncuesta controladora = new AdministrarEncuesta();
            List<ValorReferencia> lista = controladora.ObtenerTiposEncuestas();
            cmbTipo.DataSource = lista;
            cmbTipo.DataTextField = "Descripcion";
            cmbTipo.DataValueField = "Valor";
            cmbTipo.DataBind();
            Session["TiposPregunta"] = controladora.ObtenerTiposPregunta();
            if ((encActual != null)&&(encActual.ClaveEncuesta != null))
            {
                lblTitulo.Text = UtilMensaje.ObtenerMensaje("#ModificarEncuesta");
                pregEncuesta = controladora.ObtenerPreguntas(encActual);
                opcionesPregunta = controladora.ObtenerOpcionesPreguntas(encActual);
                PresentarEncuesta(encActual);
            }
            else
            {
                encActual = new Encuesta();
                pregEncuesta = new List<Pregunta>();
                opcionesPregunta = new List<PreguntaOpcion>();
            }
            dlPreguntas.DataBind();
        }
    }

    private void PresentarEncuesta(Encuesta enc)
    {
        txtClave.Text = enc.ClaveEncuesta;
        txtNombre.Text = enc.Nombre;
        chkActivo.Checked = enc.Estado;
        cmbTipo.SelectedValue = enc.Tipo.ToString();
    }
    protected void imgAceptar_Click(object sender, ImageClickEventArgs e)
    {
        AdministrarEncuesta controladora = new AdministrarEncuesta();
        encActual.Nombre = txtNombre.Text;
        encActual.Tipo = Convert.ToInt16(cmbTipo.SelectedValue);
        encActual.Estado = chkActivo.Checked;
        if (encActual.ClaveEncuesta == null)
        {
            encActual.ClaveEncuesta = txtClave.Text;
            encActual.Fecha = DateTime.Now;
            controladora.RegistrarEncuesta(encActual, pregEncuesta, opcionesPregunta);
        }
        else
        controladora.ActualizarEncuesta(encActual, pregEncuesta, opcionesPregunta);
        Response.Redirect("NavegacionEncuesta.aspx");
    }
    protected void imgCancelar_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("NavegacionEncuesta.aspx");
    }
    protected void dlPreguntas_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "NuevaPregunta")
        {
            dlPreguntas.EditIndex = -1;
            dlPreguntas.InsertItemPosition = InsertItemPosition.LastItem;
            dlPreguntas.DataBind();
            Session["OpcionesPreguntaEditando"] = new List<PreguntaOpcion>();
            if (dlPreguntas.InsertItem != null)
            {
                cPreguntaOpcion p = (cPreguntaOpcion)dlPreguntas.InsertItem.FindControl("PreguntaOpcion1");
                p.IdPregunta = Guid.NewGuid();
                p.Opciones = new List<PreguntaOpcion>();
                p.DataBind();
               
                p.Visible = true;
            }
            dlPreguntas.DataBind();
            //UtilEtiquetas.CargarEtiquetas(dlPreguntas);
        }
        else if (e.CommandName == "Cancel")
        {
            dlPreguntas.InsertItemPosition = InsertItemPosition.None;
        }
        else if (e.CommandName == "Subir")
        {
            Guid o = (Guid)dlPreguntas.SelectedValue;
            Pregunta pre = (from p in pregEncuesta where p.IdPregunta == o select p).FirstOrDefault();
            if ((pre != null) && (pre.Orden > 0))
            {
                Pregunta otra = (from p in pregEncuesta where p.Orden == pre.Orden - 1 select p).FirstOrDefault();
                if (otra != null)
                {
                    otra.Orden = pre.Orden;
                    pre.Orden--;
                    dlPreguntas.SelectedIndex--;
                    dlPreguntas.DataBind();
                }
            }
            
        }
        else if (e.CommandName == "Bajar")
        {
            Guid o = (Guid)dlPreguntas.SelectedValue;
            Pregunta pre = (from p in pregEncuesta where p.IdPregunta == o select p).FirstOrDefault();
            short ultimoorden = pregEncuesta.Max(p => p.Orden);
            if (pre.Orden < ultimoorden)
            {
                Pregunta otra = (from p in pregEncuesta where p.Orden == pre.Orden + 1 select p).FirstOrDefault();
                otra.Orden = pre.Orden;
                pre.Orden++;
                dlPreguntas.SelectedIndex++;
                dlPreguntas.DataBind();
            }

        }
    }
    protected void dlPreguntas_ItemInserting(object sender, ListViewInsertEventArgs e)
    {
        object oPre = dlPreguntas.InsertItem.FindControl("PreguntaOpcion1");
        if (oPre != null)
        {
            cPreguntaOpcion PreguntaOpcion1 = (cPreguntaOpcion)oPre;
            Pregunta pre = new Pregunta();
            pre.IdPregunta = PreguntaOpcion1.IdPregunta;
            pre.Descripcion = e.Values["Descripcion"].ToString();
            pre.TipoPregunta = Convert.ToInt16(e.Values["TipoPregunta"]);
            pre.Orden = (short)(pregEncuesta.Count == 0 ? 0 : pregEncuesta.Max(p => p.Orden) + 1);
            if (encActual.ClaveEncuesta != null)
                pre.ClaveEncuesta = encActual.ClaveEncuesta;

            List<ValorReferencia> valoresPregunta = (List<ValorReferencia>)Session["TiposPregunta"];
            ValorReferencia val = (from vr in valoresPregunta where vr.Valor == pre.TipoPregunta select vr).FirstOrDefault();
            pre.ValorReferencia = val;
            pregEncuesta.Add(pre);

            foreach (PreguntaOpcion o in PreguntaOpcion1.Opciones)
                opcionesPregunta.Add(o);
            dlPreguntas.InsertItemPosition = InsertItemPosition.None;
        }
        e.Cancel = true;
    }
    protected void dsPreguntas_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        pregEncuesta= pregEncuesta.OrderBy(p => p.Orden).ToList();
        e.Result = pregEncuesta;
    }

    protected void dlPreguntas_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.DisplayIndex == dlPreguntas.EditIndex)
        {
            Pregunta pre = (Pregunta)e.Item.DataItem;
            cPreguntaOpcion p = (cPreguntaOpcion)e.Item.FindControl("PreguntaOpcion1");
            
                List<PreguntaOpcion> lista = (from o in opcionesPregunta where o.IdPregunta == pre.IdPregunta select o).ToList();
                p.Opciones = lista;
                p.IdPregunta = pre.IdPregunta;
                p.DataBind();
                p.Visible = (pre.TipoPregunta == 22);
        }
    }

    protected void dsTiposPregunta_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = Session["TiposPregunta"];
    }
    protected void cmbTipoPreg_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (dlPreguntas.EditIndex != -1)
        {
            ComboBox cmb = (ComboBox)dlPreguntas.EditItem.FindControl("cmbTipoPreg");
            int i = Convert.ToInt32(cmb.SelectedValue);

            cPreguntaOpcion p = (cPreguntaOpcion)dlPreguntas.EditItem.FindControl("PreguntaOpcion1");
            p.Visible = (i == 22);
        }
        else
        {
            ComboBox cmb = (ComboBox)dlPreguntas.InsertItem.FindControl("cmbTipoPreg");
            int i = Convert.ToInt32(cmb.SelectedValue);

            cPreguntaOpcion p = (cPreguntaOpcion)dlPreguntas.InsertItem.FindControl("PreguntaOpcion1");
            p.Visible = (i == 22);
        }
    }

    protected void dlPreguntas_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {
        Guid idPregunta = new Guid(e.Keys["IdPregunta"].ToString());
        Pregunta pre = (from p in pregEncuesta where p.IdPregunta == idPregunta select p).FirstOrDefault();
        if (pre != null)
        {
            cPreguntaOpcion p = (cPreguntaOpcion)dlPreguntas.EditItem.FindControl("PreguntaOpcion1");

            
                List<PreguntaOpcion> original = (from o in opcionesPregunta where o.IdPregunta == pre.IdPregunta select o).ToList();

                foreach (PreguntaOpcion o in original)
                    if (!p.Opciones.Contains(o))
                        opcionesPregunta.Remove(o);
                    else if (opcionesPregunta[opcionesPregunta.IndexOf(o)].Descripcion != o.Descripcion)
                        opcionesPregunta[opcionesPregunta.IndexOf(o)].Descripcion = o.Descripcion;

                foreach (PreguntaOpcion o in p.Opciones)
                    if (!original.Contains(o))
                        opcionesPregunta.Add(o);
            pre.Descripcion = e.NewValues["Descripcion"].ToString();
            

            pre.TipoPregunta = Convert.ToInt16(e.NewValues["TipoPregunta"]);
            ValorReferencia valores = ((List<ValorReferencia>)Session["TiposPregunta"]).Where(v => v.Valor == pre.TipoPregunta).FirstOrDefault();
            pre.ValorReferencia = new ValorReferencia() { Valor = valores.Valor, Descripcion = valores.Descripcion };
            dlPreguntas.EditIndex = -1;
        }
        e.Cancel = true;
    }

    protected void dlPreguntas_ItemEditing(object sender, ListViewEditEventArgs e)
    {
        dlPreguntas.InsertItemPosition = InsertItemPosition.None;
    }



    protected void dlPreguntas_DataBound(object sender, EventArgs e)
    {
        UtilEtiquetas.CargarEtiquetas(dlPreguntas);
    }
}