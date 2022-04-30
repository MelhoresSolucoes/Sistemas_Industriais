using SistemaIndustrial.Domain.Base.Abstractions;
using SistemaIndustrial.Repositories.Base.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIndustrial.Repositories.Extension
{
    internal static class ModelBuilderExtension
    {
        public static void AddMapping<TEntity>(this ModelBuilder builder, EntityMapping<TEntity> mapping) where TEntity : Entity
        {
            builder.Entity<TEntity>(mapping.Map);
        }
    }
}
