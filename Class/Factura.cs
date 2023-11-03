using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria_Portilla.Class
{
    public class Factura
    {
        public int NroFact { get; set; }
        public DateOnly Fecha { get; set; }
        public int IdCliente { get; set; }
        public int TotalFactura { get; set; }
        public  List<int> ListProductos { get; set; }
    }
}