using SistemaIndustrial.Domain.Base.Abstractions;
using Microsoft.EntityFrameworkCore;
using SistemaIndustrial.Repositories.Base.Interfaces;

namespace SistemaIndustrial.Repositories.Base.Abstractions
{
    public abstract class DatabaseRepository<TEntity> : IDatabaseRepository<TEntity> where TEntity : Entity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> set;

        public DatabaseRepository(DbContext context)
        {
            this.set = context.Set<TEntity>();
            _context = context;
        }
        public void Delete(TEntity entity, string action = null)
        {
            this.set.Remove(entity);
            _context.SaveChanges();
        }

        public void Delete(IEnumerable<TEntity> manyEntities, string action = null)
        {
            this.set.RemoveRange(manyEntities);
            _context.SaveChanges();
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.set.AsQueryable();
        }

        public TEntity GetById(int id)
        {
            TEntity entity;

            try
            {
                entity = this.set.Find(id);
                return entity;
            }
            catch (Exception)
            {
                entity = this.set.Where(o => o.Id == id).SingleOrDefault();
                return entity;
            }

        }

        public TEntity Save(TEntity entity)
        {
            var result = this.set.Add(entity);
            return result.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            var result = this.set.Update(entity);
            return result.Entity;
        }

        public async Task<TEntity> SaveOrUpdateAsync(TEntity entity, Guid? currentUserId = null, bool saveAction = false, string action = null)
        {
            if (entity.Id > 0)
            {
                var updated = this.set.Update(entity);
                await updated.Context.SaveChangesAsync();
                return this.GetById(updated.Entity.Id);
            }
            var added = await this.set.AddAsync(entity);
            await added.Context.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<IEnumerable<TEntity>> SaveOrUpdateAsync(IEnumerable<TEntity> manyEntities, Guid? currentUserId = null, string action = null)
        {
            if (manyEntities.Any(c => c.Id > 0))
            {
                this.set.UpdateRange(manyEntities);
                return manyEntities;
            }

            await this.set.AddRangeAsync(manyEntities);
            return manyEntities;
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            return this.set.FindAsync(id).AsTask();
        }

        public void Dispose()
        {
        }
    }
}
