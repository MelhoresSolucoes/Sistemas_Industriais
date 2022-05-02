using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIndustrial.View.Entities
{
    public class CompraGadoViewModel 
    {
        public int Id { get; set; }
        public DateTime DataEntrega { get; set; }
        public decimal Total { get; set; }
        public string Pecuarista { get; set; }
        
    }

}
