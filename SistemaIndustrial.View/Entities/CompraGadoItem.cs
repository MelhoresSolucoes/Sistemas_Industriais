using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIndustrial.View.Entities
{
    public class CompraGadoItem 
    {
        public int Id { get; set; }
        public int IdCompraGado { get; set; }
        public int IdAnimal { get; set; }
        public int Quantidade { get; set; }
        public virtual CompraGado CompraGado { get; set; }
        public virtual Animal Animal { get; set; }
        public decimal Total { get; set; }

    }
}
