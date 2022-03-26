using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YZAERU_SG1_21_22_2.Repository.Context;
using YZAERU_SG1_21_22_2.Repository.Interfaces;

namespace YZAERU_SG1_21_22_2.Repository.Repositories
{
    public abstract class MovieRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        /// <summary>
        /// Gets dbContext variable.
        /// </summary>
        protected DbContext Context { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieRepository{TEntity, TKey}"/> class.
        /// </summary>
        /// <param name="context">DbContext instance.</param>
        public MovieRepository(DbContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="entity">Entity instace.</param>
        public void Delete(TEntity entity)
        {
            this.Context.Remove(entity);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Equals ovverid.
        /// </summary>
        /// <param name="obj">Another Entity.</param>
        /// <returns>Result of equals.</returns>
        public override bool Equals(object obj)
        {
            return obj is MovieRepository<TEntity, TKey> repository &&
                   EqualityComparer<DbContext>.Default.Equals(this.Context, repository.Context);
        }

        /// <summary>
        /// Getl items of an entity.
        /// </summary>
        /// <returns>List of an enetity.</returns>
        public IQueryable<TEntity> ReadAll()
        {
            return this.Context.Set<TEntity>();
        }

        /// <summary>
        /// Get enetiy by id abstract method.
        /// </summary>
        /// <param name="id">Int type.</param>
        /// <returns>One item of an entity.</returns>
        public abstract TEntity GetById(TKey id);

        /// <summary>
        /// Insert a new item.
        /// </summary>
        /// <param name="entity">Inserted item.</param>
        /// <returns>insterted entity.</returns>
        public TEntity Insert(TEntity entity)
        {
            var result = this.Context.Add(entity);
            this.Context.SaveChanges();

            return result.Entity;
        }

        /// <summary>
        /// Update a entity.
        /// </summary>
        /// <param name="entity">An enetity what i will update.</param>
        /// <returns>Updated entity.</returns>
        public TEntity Update(TEntity entity)
        {
            var result = this.Context.Update(entity);
            this.Context.SaveChanges();

            return result.Entity;
        }

        /// <summary>
        /// Create HashtoMovie.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return this.Context.Model.GetHashCode();
        }
    }
}
