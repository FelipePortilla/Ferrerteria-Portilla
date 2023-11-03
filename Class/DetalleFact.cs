using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria_Portilla.Class
{
    public class DetalleFact
    {
        public int Id { get; set; }
        public int NroFact { get; set; }
        public int IdProd { get; set; }
        public int Cantidad { get; set; }
        public int Valor { get; set; }
    }
}