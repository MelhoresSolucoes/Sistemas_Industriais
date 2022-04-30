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
    public class CompraGadoItemRepository : DatabaseRepository<CompraGadoItem>
    {
        public CompraGadoItemRepository(DbContext context) : base(context)
        {
        }

        public IQueryable<CompraGadoItem> GetAllWithOthersEntities()
        {
            return this.set
                .Include(c => c.CompraGado)
                .Include(c => c.Animal)
                .AsQueryable();

        }

        public IQueryable<CompraGadoItem> GetAllByCompraGadoId(int idCompraGado)
        {
            return this.set
                .Include(c => c.CompraGado)
                .Where(c => c.IdCompraGado == idCompraGado)
                .AsQueryable();
        }
    }
}
