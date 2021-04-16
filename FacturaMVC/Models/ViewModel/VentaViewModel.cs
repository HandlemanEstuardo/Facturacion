using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacturaMVC.Models.ViewModel
{
    public class VentaViewModel
    {
        [Display(Name = "Nombre del Cliente")]
        public string nombre { get; set; }
        [Display(Name = "Nit")]
        public int nit { get; set;}
        [Display(Name ="Fecha")]
        [DataType(DataType.Date)]
        public  DateTime fecha { get; set; }
        

        public List<Detalle> detalle { get; set; }
    }

    public class Detalle
    {
        
        public int cantidad { get; set; }
       
        public string nombre { get; set; }
        
        public decimal precioUnitario { get; set; }

       
    }


}