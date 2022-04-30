using SistemaIndustrial.Domain.Base.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIndustrial.Domain.Entities
{
    public class CompraGado :Entity
    {
        [Required]
        public int IdPecuarista { get; set; }
        [Required]
        public DateTime DataEntrega { get; set; }
        public decimal Total { get; set; }
       
        public virtual Pecuarista? Pecuarista { get; set; }
        
    }
}
