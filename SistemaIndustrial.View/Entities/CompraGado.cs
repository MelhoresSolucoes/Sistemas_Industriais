using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIndustrial.View.Entities
{
    public class CompraGado 
    {
        public int Id { get; set; }
        public int IdPecuarista { get; set; }
        public DateTime DataEntrega { get; set; }
        public decimal Total { get; set; }
        public virtual Pecuarista Pecuarista { get; set; }
        
    }
    public class CustomResponse<T>
    {
        bool success { get; set; }
        public T data { get; set; }
    }
}
