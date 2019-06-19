using System;
using System.Threading.Tasks;

namespace DilekSaylan.Assessment.Data.Infrastructure
{
    public interface IUnitOfWork:IDisposable
    {
        Task<bool> Commit();
    }
}
