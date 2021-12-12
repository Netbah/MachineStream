namespace MachineStream.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter= null, int top = 100);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);
    }
}