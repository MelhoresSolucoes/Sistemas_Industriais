﻿using SistemaIndustrial.Domain.Entities;
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
    public class PecuaristaMap : EntityMapping<Pecuarista>
    {
        public override void Map(EntityTypeBuilder<Pecuarista> entity)
        {
            entity.ToTable("Pecuarista");
            entity.HasKey(a => a.Id);

            entity.Property(a => a.Id)
                .HasColumnName("Id")
                .HasColumnType("INT")
                .ValueGeneratedOnAdd();
        }
    }
}
