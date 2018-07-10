using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ascentic.Sample.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        // RETRIEVE METHODS
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        Task<TEntity> Find(object id);

        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        Task<int> Count(Expression<Func<TEntity, bool>> filter = null);

        // MODIFICATION METHODS
        void Add(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);
    }
}
