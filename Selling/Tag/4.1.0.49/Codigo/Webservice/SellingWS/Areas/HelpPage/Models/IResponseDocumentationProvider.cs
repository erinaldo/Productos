using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;

namespace SellingWS.Areas.HelpPage.Models
{
    public interface IResponseDocumentationProvider
    {
        string GetResponseDocumentation(HttpActionDescriptor actionDescriptor);
    }
}