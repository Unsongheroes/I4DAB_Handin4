using System;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault.Models;

namespace ProsumerInfo.Interfaces
{
    public interface IUnitOfWork
    {
        IDbResult Commit();
        Task<IDbResult> CommitAsync();
        IProsumerRepository Prosumers { get; }
    }

    public interface IDbResult
    {
        DbStatusCode StatusCode { get; }
        object Error { get; }
    }

    public enum DbStatusCode
    {
        Success,
        Error,
        ConcurrentError,
        UniqueValueExistsError
    }
            
}