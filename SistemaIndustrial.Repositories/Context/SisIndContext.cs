using SistemaIndustrial.Repositories.Extension;
using SistemaIndustrial.Repositories.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIndustrial.Repositories.Context
{
    public class SisIndContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public SisIndContext(DbContextOptions<SisIndContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddMapping(new AnimalMap());
            modelBuilder.AddMapping(new PecuaristaMap());
            modelBuilder.AddMapping(new CompraGadoMap());
            modelBuilder.AddMapping(new CompraGadoItemMap());
        }
    }
}
