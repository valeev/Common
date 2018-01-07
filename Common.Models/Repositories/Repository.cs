using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Common.Models
{
    /// <summary>
    /// Generic repository based on EF
    /// </summary>
    /// <typeparam name="T">Type of entity for the repository.</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public Repository(DbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException("dbContext", "The object dbContext can not be null");
            DbSet = DbContext.Set<T>();
        }

        #endregion

        #region Protected properties

        /// <summary>
        /// The EF DbContect used by the repository
        /// </summary>
        protected DbContext DbContext { get; set; }

        /// <summary>
        /// DbSet exposing the entities of the repository
        /// </summary>
        protected DbSet<T> DbSet { get; set; }

        #endregion

        /// <summary>
        /// Get all entities in the repository
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        /// <summary>
        /// Get an entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(int id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// Add an entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Add(T entity)
        {
            var dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            var dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        /// <summary>
        /// Delete an entity by id
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return;
            Delete(entity);
        }

        /// <summary>
        /// Delete a range of entity
        /// </summary>
        /// <param name="entities"></param>
        public virtual void Delete(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }
    }
}
