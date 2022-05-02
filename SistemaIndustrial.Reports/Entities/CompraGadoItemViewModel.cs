using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIndustrial.View.Entities
{
    public class CompraGadoItemViewModel 
    {
        public int Id { get; set; }
        public int IdCompraGado { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public decimal Total { get; set; }

    }
}
