using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DilekSaylan.Assessment.Data.Infrastructure;
using Microsoft.AspNetCore.Mvc;


namespace DilekSaylan.Assessment.API
{
    
    public abstract class MongoApiController<TEntity> : Controller where TEntity: class
    {
        
        protected readonly IRepository<TEntity> _repository;
        protected readonly IUnitOfWork _uow;

        public MongoApiController(IRepository<TEntity> repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            var entities = await _repository.GetAll();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(string id)
        {
            var entity = await _repository.GetById(id);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity entity)
        {
            _repository.Add(entity);
           // var test = await _repository.GetById(id);
            await _uow.Commit();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TEntity>> Put(TEntity entity,string id)
        {
            _repository.Update(entity, id);
            await _uow.Commit();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            _repository.Remove(id);

            var testEntity = await _repository.GetById(id);
            await _uow.Commit();
            testEntity = await _repository.GetById(id);
            return Ok();
        }

    }
}