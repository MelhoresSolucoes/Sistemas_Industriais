using SistemaIndustrial.Domain.Entities;
using SistemaIndustrial.Repositories.Base.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIndustrial.Repositories.Mapping
{
    public class CompraGadoMap : EntityMapping<CompraGado>
    {
        public override void Map(EntityTypeBuilder<CompraGado> entity)
        {
            entity.ToTable("CompraGado");
            entity.HasKey(a => a.Id);
            
            entity.Property(a => a.Id)
                .HasColumnName("Id")
                .HasColumnType("INT")
                .ValueGeneratedOnAdd();

            entity.Property(b => b.DataEntrega)
                .IsRequired(true);

            entity.HasOne(c => c.Pecuarista)
                .WithMany()
                .HasForeignKey(c => c.IdPecuarista)
                .IsRequired(true);

        }
    }
}
