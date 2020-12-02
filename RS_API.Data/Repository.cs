using Microsoft.EntityFrameworkCore;
using RS_API.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RS_API.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity<int>
    {
        private readonly RSDbContext context;

        public Repository(RSDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public virtual Task<TEntity> GetByIdAsync(int id)
        {
            if(id == default)
                throw new ArgumentException($"Invalid argument value '{id}' for {nameof(id)}");

            return context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<IList<TEntity>> GetAsync()
        {
            return await context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public virtual void Add(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            context.Set<TEntity>().Add(item);
        }

        public virtual void Update(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
 
            context.Set<TEntity>().Update(item);   
        }

        public virtual async Task<bool> SaveAsync()
        {
            return await context.SaveChangesAsync() >= 0;
        }
    }
}
