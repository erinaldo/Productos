using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AjaxControlToolkit;
using System.ComponentModel;


namespace MEGACABLE.CONTROLS
{
    [ToolboxItem(true)]
    public class ComboBox2: ComboBox 
    {
        public string Texto {
            get {
                return TextBoxControl.Text;
            }
            set {
                TextBoxControl.Text = value;
            }
        }
    }
}
