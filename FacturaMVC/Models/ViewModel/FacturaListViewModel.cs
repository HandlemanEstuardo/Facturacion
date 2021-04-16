using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturaMVC.Models.ViewModel
{
    public class FacturaListViewModel
    {
        public int id { get; set; }
        public int idVenta { get; set; }
        public int cantidad { get; set; }
        public string nombre { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal total { get; set; }
    }
}