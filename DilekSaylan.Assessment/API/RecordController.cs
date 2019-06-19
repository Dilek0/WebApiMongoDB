
using DilekSaylan.Assessment.Data.Infrastructure;
using DilekSaylan.Assessment.Models;

using Microsoft.AspNetCore.Mvc;

namespace DilekSaylan.Assessment.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : MongoApiController<Record>
    {
        public RecordController(IRepository<Record> repository, IUnitOfWork uow) :base(repository, uow)
        {
            
        }
    }
}