using SistemaIndustrial.Domain.Base.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIndustrial.Repositories.Base.Interfaces
{
    internal interface IDatabaseRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Delete(TEntity entity, string action = null);
        void Delete(IEnumerable<TEntity> manyEntities, string action = null);

        Task<TEntity> SaveOrUpdateAsync(TEntity entity, Guid? currentUserId = null, bool saveAction = false, string action = null);
        Task<IEnumerable<TEntity>> SaveOrUpdateAsync(IEnumerable<TEntity> manyEntities, Guid? currentUserId = null, string action = null);


        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);
    }
}
