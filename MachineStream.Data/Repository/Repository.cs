namespace MachineStream.Data.Repository
{
    using Database;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly MachineContext _context;
        internal DbSet<TEntity> _dbSet;

        public Repository(MachineContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, int top = 100)
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter).Take(top);;
            }

            return query.AsNoTracking().ToList();
        }
        

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
            }

            try
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated {ex.Message}");
            }
        }
    }
}