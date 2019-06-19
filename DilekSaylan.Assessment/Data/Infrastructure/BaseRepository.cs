
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DilekSaylan.Assessment.Data.Infrastructure
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoContext _context;
        protected readonly IMongoCollection<TEntity> DbSet;

        public BaseRepository(IMongoContext context)
        {
            _context = context;
            DbSet = _context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual void Add(TEntity obj)
        {
            _context.AddCommand(() => DbSet.InsertOneAsync(obj));
        }

       
        public async virtual Task<IEnumerable<TEntity>> GetAll()
        {
            var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }

        public virtual async Task<TEntity> GetById(string id)
        {
            var docId = new ObjectId(id);
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", docId));
            return data.SingleOrDefault();
        }

        public virtual void Remove(string id)
        {
            var docId = new ObjectId(id);
            _context.AddCommand(() => DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", docId)));
        }

        public virtual void Update(TEntity obj, string id)
        {
            var docId = new ObjectId(id);
            _context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", docId), obj));
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

       
    }
}
