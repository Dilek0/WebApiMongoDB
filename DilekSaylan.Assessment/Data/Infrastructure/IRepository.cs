
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DilekSaylan.Assessment.Data.Infrastructure
{
    public interface IRepository<TEntity>:IDisposable where TEntity: class
    {
        void Add(TEntity obj);
        Task<TEntity> GetById(string id);
        Task<IEnumerable<TEntity>> GetAll();
        void Update(TEntity obj, string id);
        void Remove(string id);
    }
}
