using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIndustrial.Domain.Base.Abstractions
{
    public abstract class Entity
    {
        [Key, Column(Order = 0)]
        public int Id { get; set; }
    }
}
