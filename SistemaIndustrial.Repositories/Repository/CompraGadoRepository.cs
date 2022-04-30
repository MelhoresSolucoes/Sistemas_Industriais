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
    public class CompraGadoRepository : DatabaseRepository<CompraGado>
    {
        public CompraGadoRepository(DbContext context) : base(context)
        {
        }

        public IQueryable<CompraGado> GetAllWithOthersEntities()
        {
            return this.set
                .Include(c => c.Pecuarista)
                .AsQueryable();

        }

        public IQueryable<CompraGado> GetAllByPecuaristaId(long idPecuarista)
        {
            return this.set
                .Include(c => c.Pecuarista)
                .Where(c => c.IdPecuarista == idPecuarista)
                .AsQueryable();
        }
    }
}
