using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

public partial class Cotroles_ComboBox2 : ComboBox 
{
    
    public TextBox getTextBoxControl(ComboBox cb)
    {
        return TextBoxControl;
    }

    public void setTextBoxValue(string val)
    {
        TextBoxControl.Text = val; ;
    }




}