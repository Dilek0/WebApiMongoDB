﻿using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace DilekSaylan.Assessment.Data.Infrastructure
{
    public interface IMongoContext:IDisposable
    {
        void AddCommand(Func<Task> func);
        Task<int> SaveChanges();
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
