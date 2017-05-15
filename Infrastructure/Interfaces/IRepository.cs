using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IRepository<TEntity> 
    {
         Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
         IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
         IQueryable<TEntity> GetAll();

         Task Create(TEntity entity);
         Task CreateMany(IEnumerable<TEntity> entities);
         Task Update(TEntity entity);
         Task Delete(TEntity entity);
    }
}