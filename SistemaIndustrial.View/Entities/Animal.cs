using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIndustrial.View.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Preco { get; set; }
    }
}
