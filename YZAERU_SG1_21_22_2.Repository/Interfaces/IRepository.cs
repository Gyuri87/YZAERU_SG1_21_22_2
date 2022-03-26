using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YZAERU_SG1_21_22_2.Repository.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        
        IQueryable<TEntity> ReadAll();

        TEntity GetById(TKey id);

        TEntity Insert(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
