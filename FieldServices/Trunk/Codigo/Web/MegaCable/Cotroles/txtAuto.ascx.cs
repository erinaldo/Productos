using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cotroles_txtAuto : System.Web.UI.UserControl
{
    string _id;
    public Cotroles_txtAuto() {

        _id = Guid.NewGuid().ToString();
    }


    public string MetodoConsulta {
        get {
            if (this.ViewState[this._id + "MetodoConsulta"] == null)
                return "";

            return this.ViewState[this._id + "MetodoConsulta"].ToString();
        }
        set {
            this.ViewState[this._id + "MetodoConsulta"] = value;        
        }    
    }

    public string Retraso {
        get
        {
            if (this.ViewState[this._id + "Retraso"] == null)
                return "";
            return this.ViewState[this._id + "Retraso"].ToString();
        }
        set
        {
            this.ViewState[this._id + "Retraso"] = value;
        }        
    }



    public string ValorSeleccionado {
        get
        {
            return hValor.Value;
        }
        set
        {
            hValor.Value = value;
        }                
    }

    public string TextoSeleccionado
    {
        get
        {
            return hTexto.Value;
        }
        set
        {
            hTexto.Value = value;
        }
    }


    public string CampoValor
    {
        get
        {
            if (this.ViewState[this._id + "CampoValor"] == null)
                return "";
            return this.ViewState[this._id + "CampoValor"].ToString();
        }
        set
        {
            this.ViewState[this._id + "CampoValor"] = value;
        }
    }

    public string CampoTexto
    {
        get
        {
            if (this.ViewState[this._id + "CampoTexto"] == null)
                return "";
            return this.ViewState[this._id + "CampoTexto"].ToString();
        }
        set
        {
            this.ViewState[this._id + "CampoTexto"] = value;
        }
    }



   

    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
}