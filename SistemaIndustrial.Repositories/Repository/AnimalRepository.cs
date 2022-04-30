using SistemaIndustrial.Domain.Entities;
using SistemaIndustrial.Repositories.Base.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIndustrial.Repositories.Repository
{
    public class AnimalRepository : DatabaseRepository<Animal>
    {
        public AnimalRepository(DbContext context) : base(context)
        {
        }

    }
}
