using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using AjaxControlToolkit;

/// <summary>
/// Descripción breve de UtilEtiquetas
/// </summary>
public class UtilEtiquetas
{
	public UtilEtiquetas()
	{
		
	}
    public static void CargarEtiquetas(Page pagina)
    {
        if (pagina.Title.StartsWith("#"))
            pagina.Title = UtilMensaje.ObtenerMensaje(pagina.Title);
        foreach (Control c in pagina.Controls)
        {
            CargarEtiquetas(c);
        }
    }
    public static void CargarEtiquetas(Control control)
    {
        if (control.GetType() == typeof(Label))
        {
            Label lbl = (Label)control;
            if (lbl.Text.StartsWith("#"))
                lbl.Text = UtilMensaje.ObtenerMensaje(lbl.Text);
            if (lbl.ToolTip.StartsWith("#"))
                lbl.ToolTip = UtilMensaje.ObtenerMensaje(lbl.ToolTip);
            
        }
        else if (control.GetType() == typeof(Button))
        {
            Button btn = (Button)control;
            if (btn.Text.StartsWith("#"))
                btn.Text = UtilMensaje.ObtenerMensaje(btn.Text);
            if (btn.ToolTip.StartsWith("#"))
                btn.ToolTip = UtilMensaje.ObtenerMensaje(btn.ToolTip);

        }
        else if (control.GetType() == typeof(ImageButton))
        {
            ImageButton btn = (ImageButton)control;
            if (btn.ToolTip.StartsWith("#"))
                btn.ToolTip = UtilMensaje.ObtenerMensaje(btn.ToolTip);

        }
        else if (control.GetType() == typeof(LinkButton))
        {
            LinkButton lnk = (LinkButton)control;
            if (lnk.Text.StartsWith("#"))
                lnk.Text = UtilMensaje.ObtenerMensaje(lnk.Text);
            if (lnk.ToolTip.StartsWith("#"))
                lnk.ToolTip = UtilMensaje.ObtenerMensaje(lnk.ToolTip);
        }
        else if (control.GetType() == typeof(CheckBox))
        {
            CheckBox chk = (CheckBox)control;
            if (chk.Text.StartsWith("#"))
                chk.Text = UtilMensaje.ObtenerMensaje(chk.Text);
            if (chk.ToolTip.StartsWith("#"))
                chk.ToolTip = UtilMensaje.ObtenerMensaje(chk.ToolTip);

        }
        else if (control.GetType() == typeof(ComboBox))
        {
            ComboBox cmb = (ComboBox)control;
            if (cmb.Text.StartsWith("#"))
                cmb.Text = UtilMensaje.ObtenerMensaje(cmb.Text);
            if (cmb.ToolTip.StartsWith("#"))
                cmb.ToolTip = UtilMensaje.ObtenerMensaje(cmb.ToolTip);
            foreach (ListItem l in cmb.Items)
            {
                if (l.Text.StartsWith("#"))
                    l.Text = UtilMensaje.ObtenerMensaje(l.Text);
            }
        }
        else if ((control.GetType() == typeof(RequiredFieldValidator)) || (control.GetType() == typeof(CustomValidator)) || (control.GetType() == typeof(CompareValidator)))
        {
            BaseValidator rfv = (BaseValidator)control;
            if (rfv.ErrorMessage.StartsWith("#"))
                rfv.ErrorMessage = UtilMensaje.ObtenerMensaje(rfv.ErrorMessage);
            if (rfv.ToolTip.StartsWith("#"))
                rfv.ToolTip = UtilMensaje.ObtenerMensaje(rfv.ToolTip);

        }

        else if (control.GetType() == typeof(LoginStatus))
        {
            LoginStatus login = (LoginStatus)control;

            if (login.LoginText.StartsWith("#"))
                login.LoginText = UtilMensaje.ObtenerMensaje(login.LoginText);
            if (login.LogoutText.StartsWith("#"))
                login.LogoutText = UtilMensaje.ObtenerMensaje(login.LogoutText);
        }
        foreach (Control c in control.Controls)
        {
            CargarEtiquetas(c);
        }
    }
}