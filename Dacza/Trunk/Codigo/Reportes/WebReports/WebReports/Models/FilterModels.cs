using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace WebReports.Models
{
    public class FilterModels
    {
        public class FilterOrdenTrabajo
        {
            [Required]
            [Display(Name = "Sucursal")]
            public string Sucursal { get; set; }

            [DataType(DataType.Date)]
            [Display(Name = "Fecha Inicial")]
            public DateTime? FechaIni { get; set; }

            [DataType(DataType.Date)]
            [Display(Name = "Fecha Final")]
            public DateTime? FechaFin { get; set; }

            [Display(Name = "Estado")]
            public byte Fase { get; set; }

            [Display(Name = "Folio")]
            public string Folio { get; set; }

            [Display(Name = "Vin")]
            public string Vin { get; set; }

            [Display(Name = "Cliente")]
            public string Cliente { get; set; }
        }

        public class FilterRefacciones
        {
            [Required]
            [Display(Name = "Sucursal")]
            public string Sucursal { get; set; }

            [DataType(DataType.Date)]
            [Display(Name = "Fecha Inicial")]
            public DateTime? FechaIni { get; set; }

            [DataType(DataType.Date)]
            [Display(Name = "Fecha Final")]
            public DateTime? FechaFin { get; set; }

            [Display(Name = "Taller")]
            public string Taller { get; set; }

            [Display(Name = "Vin")]
            public string Vin { get; set; }

            [Display(Name = "Parte")]
            public string Parte { get; set; }

            [Display(Name = "Seleccion")]
            public string Seleccion { get; set; }
        }

        public class FilterInventario
        {
            [Required]
            [Display(Name = "Sucursal")]
            public string Sucursal { get; set; }

            [Display(Name = "Taller")]
            public string Taller { get; set; }
        }

        public class FilterRecargas
        {
            [Required]
            [Display(Name = "Sucursal")]
            public string Sucursal { get; set; }

            [DataType(DataType.Date)]
            [Display(Name = "Fecha Inicial")]
            public DateTime? FechaIni { get; set; }

            [DataType(DataType.Date)]
            [Display(Name = "Fecha Final")]
            public DateTime? FechaFin { get; set; }

            [Display(Name = "Taller")]
            public string Taller { get; set; }

            [Display(Name = "Estado")]
            public byte Fase { get; set; }
        }
    }
}