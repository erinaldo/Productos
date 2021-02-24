using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace WebReports.Models
{
    public class ViewModels
    {
        public class ViewRefacciones
        {
            [Display(Name = "Taller")]
            public WebReports.Models.Taller Taller { get; set; }

            [Display(Name = "Folio")]
            public string Folio { get; set; }

            [Display(Name = "Fecha")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            public DateTime? Fecha { get; set; }

            [Display(Name = "Vin")]
            public string Vin { get; set; }

            [Display(Name = "No. Parte")]
            public string ClaveArticulo { get; set; }

            [Display(Name = "Descripcion")]
            public string DescripcionArticulo { get; set; }
        }
    }
}