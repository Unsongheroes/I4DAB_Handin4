using System;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault.Models;

namespace ProsumerInfo.Interfaces
{
    public interface IUnitOfWork
    {
        DbResult Commit();
        Task<DbResult> CommitAsync();
        IProsumerRepository Prosumers { get; }
    }

    public struct DbResult
    {
        public DbStatusCode StatusCode { get; }
        public object Error { get; }

        public DbResult(DbStatusCode status, object error)
        {
            StatusCode = status;
            Error = error;
        }

        public DbResult(DbStatusCode status) : this(status, null) { }
    }

    public enum DbStatusCode
    {
        Success,
        Error,
        ConcurrentError,
        UniqueValueExistsError
    }
            
}