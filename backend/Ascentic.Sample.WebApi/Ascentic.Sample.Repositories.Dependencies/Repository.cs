﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ascentic.Sample.Repositories.Dependencies
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        #region Fiedls

        protected readonly DbContext Context;

        protected readonly DbSet<T> DbSet;

        #endregion

        #region Constructor

        protected Repository(DbContext dbContext)
        {
            Context = dbContext;
            DbSet = Context.Set<T>();
        }

        #endregion

        #region Implementation

        /// <summary>
        /// Get collection of T
        /// </summary>
        /// <param name="filter">filters</param>
        /// <param name="orderBy">orders</param>
        /// <param name="includeProperties">include items</param>
        /// <returns>collection of T</returns>
        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.AsNoTracking().Where(filter);
            }

            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return orderBy == null ? await query.ToListAsync() : await orderBy.Invoke(query).AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Get collection of T
        /// </summary>
        /// <param name="filter">filters</param>
        /// <param name="orderBy">orders</param>
        /// <param name="includeProperties">include items</param>
        /// <returns>collection of T</returns>
        public async Task<int> Count(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.AsNoTracking().Where(filter);
            }

            return await query.CountAsync();
        }

        /// <summary>
        /// Find a object of T
        /// </summary>
        /// <param name="id">Id of the T</param>
        /// <returns>object of T</returns>
        public async Task<T> Find(object id)
        {
            return await DbSet.FindAsync(id);
        }

        /// <summary>
        /// Add a entity of T
        /// </summary>
        /// <param name="entity">entity of T</param>
        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        /// <summary>
        /// Delete a entity of T
        /// </summary>
        /// <param name="id">Id of the T</param>
        public void Delete(object id)
        {
            var entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Delete a entity of T
        /// </summary>
        /// <param name="entityToDelete">Object of T</param>
        public void Delete(T entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }

            DbSet.Remove(entityToDelete);
        }

        /// <summary>
        /// Update entity of T
        /// </summary>
        /// <param name="entityToUpdate">entity of T</param>
        public void Update(T entityToUpdate)
        {
            if (Context.Entry(entityToUpdate).State == EntityState.Detached)
            {
                DbSet.Attach(entityToUpdate);
            }

            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        /// <summary>
        /// If object avaiable get it or pass null of type T
        /// </summary>
        /// <param name="filter">filters</param>
        /// <param name="orderBy">orders</param>
        /// <param name="includeProperties">include items</param>
        /// <returns>Entity of T</returns>
        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return orderBy == null ? await query.FirstOrDefaultAsync() : await orderBy.Invoke(query).FirstOrDefaultAsync();
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query;
        }
        #endregion
    }
}
