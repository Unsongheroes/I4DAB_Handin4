using System;
using System.Threading.Tasks;

namespace ProsumerInfo.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
        IProsumerRepository Prosumers { get; }
    }
}