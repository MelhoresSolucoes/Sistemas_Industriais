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
    public class CompraGadoItemMap : EntityMapping<CompraGadoItem>
    {
        public override void Map(EntityTypeBuilder<CompraGadoItem> entity)
        {
            entity.ToTable("CompraGadoItem");
            entity.HasKey(a => new { a.Id, a.IdAnimal, a.IdCompraGado });

            entity.Property(b => b.Quantidade)
                 .IsRequired(true);

            entity.Property(a => a.Id)
                .HasColumnName("Id")
                .HasColumnType("INT")
                .ValueGeneratedOnAdd();

            entity.HasOne(c => c.CompraGado)
                .WithMany()
                .HasForeignKey(c => c.IdCompraGado)
                .IsRequired(true);
            
            entity.HasOne(c => c.Animal)
                .WithMany()
                .HasForeignKey(c => c.IdAnimal)
                .IsRequired(true);

        }
    }
}
