using SistemaIndustrial.Domain.Base.Abstractions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIndustrial.Repositories.Base.Abstractions
{
    public abstract class EntityMapping<TEntity> where TEntity : Entity
    {
        public abstract void Map(EntityTypeBuilder<TEntity> entity);
    }
}
