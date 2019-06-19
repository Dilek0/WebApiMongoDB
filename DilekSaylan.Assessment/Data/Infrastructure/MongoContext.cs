
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DilekSaylan.Assessment.Data.Infrastructure
{
    public class MongoContext : IMongoContext
    {
        private IMongoDatabase Database { get; set; }
        private readonly List<Func<Task>> _commands;

        public MongoContext(IConfiguration configuration)
        {
            
            _commands = new List<Func<Task>>();

            var mongoClient = new MongoClient(configuration.GetSection("MongoSettings").GetSection("Connection").Value);

            Database = mongoClient.GetDatabase(configuration.GetSection("MongoSettings").GetSection("DatabaseName").Value);



        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return Database.GetCollection<T>(name);
        }

        public async Task<int> SaveChanges()
        {
            var commandTasks = _commands.Select(c => c());
            await Task.WhenAll(commandTasks);
            return _commands.Count;
        }

        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        }
    }
}
