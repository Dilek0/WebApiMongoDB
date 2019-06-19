
using DilekSaylan.Assessment.Data.Infrastructure;
using DilekSaylan.Assessment.Models;

namespace DilekSaylan.Assessment.Data.Repositories
{
    public class RecordRepository:BaseRepository<Record>, IRecordRepository
    {
        public RecordRepository(IMongoContext context) : base(context)
        {
        }
    }
}
