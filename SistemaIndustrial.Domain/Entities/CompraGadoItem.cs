using SistemaIndustrial.Domain.Base.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIndustrial.Domain.Entities
{
    public class CompraGadoItem :Entity
    {
        [Required]
        public int IdCompraGado { get; set; }
        [Required]
        public int IdAnimal { get; set; }
        [Required]
        public int Quantidade { get; set; }
        public virtual CompraGado? CompraGado { get; set; }
        public virtual Animal? Animal { get; set; }
        public decimal Total { get; set; }

    }
}
