using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoRentStore.API.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> FetchAll();
        TEntity Get(int id);
        IQueryable<TEntity> Query { get; }
        void Add(TEntity entity);
        int Delete(TEntity entity);
        int Update(TEntity entity);
        void Save();
    }
}
