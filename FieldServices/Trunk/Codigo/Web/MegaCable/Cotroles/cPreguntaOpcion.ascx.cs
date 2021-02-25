using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MODMEG;
using System.Data.Objects.DataClasses;

public partial class cPreguntaOpcion : System.Web.UI.UserControl
{
    public List<PreguntaOpcion> Opciones
    {
        get
        {
            if (Session["OpcionesPreguntaEditando"] == null)
                Session["OpcionesPreguntaEditando"] = new List<PreguntaOpcion>();
            return (List<PreguntaOpcion>)Session["OpcionesPreguntaEditando"];
        }
        set
        {
            Session["OpcionesPreguntaEditando"] = value;
        }
    }
    public Guid IdPregunta
    {
        get
        {
            if (Session["IdPreguntaEditando"] == null)
                Session["IdPreguntaEditando"] = Guid.NewGuid();
            return (Guid)Session["IdPreguntaEditando"];
        }
        set
        {
            Session["IdPreguntaEditando"] = value;
        }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public void PoblarDataList()
    {
        dlOpciones.DataBind();

    }
    
    protected void dsOpciones_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        if (Opciones != null)
            e.Result = Opciones;
        else
            e.Cancel = true;
    }
    protected void imgAgregar_Click(object sender, ImageClickEventArgs e)
    {
        PreguntaOpcion po = new PreguntaOpcion();
        po.IdPregunta = IdPregunta;
        po.IdPreguntaOpcion = Guid.NewGuid();
        po.Descripcion = txtAgregar.Text;
        Opciones.Add(po);
        dlOpciones.DataBind();
        txtAgregar.Text = "";
 
    }
    protected void dlOpciones_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "Actualizar")
        {
            Guid idpreguntaopcion = (Guid)dlOpciones.DataKeys[e.Item.DataItemIndex].Value;
            PreguntaOpcion p = (from pre in Opciones where pre.IdPreguntaOpcion == idpreguntaopcion select pre).FirstOrDefault();
            if (p != null)
            {
                TextBox txt = (TextBox)e.Item.FindControl("txtElemento");
                p.Descripcion = txt.Text;
            }
            dlOpciones.EditIndex = -1;
            dlOpciones.DataBind();
        }
        else if (e.CommandName == "Eliminar")
        {
            Guid idpreguntaopcion = (Guid)dlOpciones.DataKeys[e.Item.DataItemIndex].Value;
            PreguntaOpcion p = (from pre in Opciones where pre.IdPreguntaOpcion == idpreguntaopcion select pre).FirstOrDefault();
            if (p != null)
            {
                Opciones.Remove(p);
            }

            dlOpciones.EditIndex = -1;
            dlOpciones.DataBind();
        }
        
    }

}