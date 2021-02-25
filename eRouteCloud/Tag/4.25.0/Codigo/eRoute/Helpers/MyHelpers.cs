using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace eRoute.Helpers
{
    public static class MyHelpers
    {
        public static MvcHtmlString ImageActionLink(this HtmlHelper html, string imageSource, string linkText, string commandText)
        {
            string imageActionLink = string.Format("<a href=\"{0}\" style=\"border: none; color:#B30000\"><img width=\"16\" height=\"16\" src=\"{1}\" /> {2} </a>", linkText, imageSource, commandText);           
            //string imageActionLink = string.Format("<a href=\"{0}\" style=\"border: none; color:#B30000\" data-ng-class=\"{3}'disabled':{4}{5}\"><img width=\"16\" height=\"16\" src=\"{1}\" /> {2} </a>", linkText, imageSource, commandText, "{", !enabled, "}");
            return new MvcHtmlString(imageActionLink);
        }

        public static MvcHtmlString ImageAction(this HtmlHelper html, string imageSource, string linkText, string tooltip)
        {
            string imageActionLink = String.Format("<a href='{0}' data-toggle='tooltip' title='{1}'><img width=\"16\" height=\"16\" src=\"{2}\" /></a>", linkText, tooltip, imageSource);
            return new MvcHtmlString(imageActionLink);
        }

        public static MvcHtmlString ImageAction(this HtmlHelper html, string imageSource, string linkText, string tooltip, string id)
        {
            string imageActionLink = String.Format("<a href='{0}' data-toggle='tooltip' title='{1}'><img width=\"16\" height=\"16\" src=\"{2}\" id=\"{3}\" /></a>", linkText, tooltip, imageSource, id);
            return new MvcHtmlString(imageActionLink);
        }

        public static MvcHtmlString ImageButton(this HtmlHelper html, string imageSource, string linkText, string tooltip) {
            string imageActionLink = string.Format("<a ng-click=\"{0}\" href=\"\" data-toggle=\"tooltip\" title=\"{1}\" style=\"border:none; color:#B30000\"><img width=\"16\" height=\"16\" src=\"{2}\"/></a>", linkText, tooltip, imageSource);            
            return new MvcHtmlString(imageActionLink);
        }
        public static MvcHtmlString ImageButton(this HtmlHelper html, string imageSource, string linkText, string tooltip, string clase)
        {
            string imageActionLink = string.Format("<a ng-click=\"{0}\" href=\"\" data-toggle=\"tooltip\" title=\"{1}\" style=\"border:none; color:#B30000\" class=\"{3}\"><img width=\"16\" height=\"16\" src=\"{2}\"/></a>", linkText, tooltip, imageSource, clase);
            return new MvcHtmlString(imageActionLink);
        }
        public static MvcHtmlString ImageButton(this HtmlHelper html, string imageSource, string linkText, string tooltip, string clase, string texto)
        {
            string imageActionLink = string.Format("<a ng-click=\"{0}\" href=\"\" data-toggle=\"tooltip\" title=\"{1}\" style=\"border:none; color:#B30000\" class=\"{3}\"><img style=\"position:relative; top:-1px; right:4px;\" width=\"16\" height=\"16\" src=\"{2}\"/>{4}</a>", linkText, tooltip, imageSource, clase,texto);
            return new MvcHtmlString(imageActionLink);
        }

        public static MvcHtmlString ImageButtonLink(this HtmlHelper html, string imageSource, string linkText, string commandText)
        {
            string imageActionLink = string.Format("<a ng-click=\"{0}\" href=\"\" style=\"border:none; color:#B30000\"><img width=\"16\" height=\"16\" src=\"{1}\"/> {2} </a>", linkText, imageSource, commandText);
            return new MvcHtmlString(imageActionLink);
        }

        //<a href = "" >< span class="fa fa-sign-out pull-right eroute-menubutton logo-collapsed" title="Acerca de" style="padding:20px;font-size:25px; color:#E11500;" aria-hidden="true" data-toggle="collapse"></span></a>

        
    }
}