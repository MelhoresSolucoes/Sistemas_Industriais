using SistemaIndustrial.Domain.Base.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIndustrial.Domain.Entities
{
    public class Animal : Entity
    {
        [Required]
        public string Descricao { get; set; }
        [Required]
        public Decimal Preco { get; set; }
    }
}
