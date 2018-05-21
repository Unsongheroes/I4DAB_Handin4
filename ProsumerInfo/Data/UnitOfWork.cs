using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProsumerInfo.Data.Repository;
using ProsumerInfo.Interfaces;

namespace ProsumerInfo.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected DbContext Context;

        private IProsumerRepository _prosumers;

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public DbResult Commit()
        {
            try
            {
                Context.SaveChanges();
                return new DbResult(DbStatusCode.Success);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return new DbResult(DbStatusCode.ConcurrentError, e.Message);
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException is SqlException innerException && innerException.Number == 2601) // Unique Index duplicate value
                {
                    return new DbResult(DbStatusCode.UniqueValueExistsError, innerException.Message);
                }

                return new DbResult(DbStatusCode.Error, e.Message);
            }
            catch (Exception e)
            {
                return new DbResult(DbStatusCode.Error, e.Message);
            }
        }

        public async Task<DbResult> CommitAsync()
        {
            try
            {
                await Context.SaveChangesAsync();
                return new DbResult(DbStatusCode.Success);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return new DbResult(DbStatusCode.ConcurrentError, e.Message);
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException is SqlException innerException && innerException.Number == 2601) // Unique Index duplicate value
                {
                    return new DbResult(DbStatusCode.UniqueValueExistsError, innerException.Message);
                }

                return new DbResult(DbStatusCode.Error, e.Message);
            }
            catch (Exception e)
            {
                return new DbResult(DbStatusCode.Error, e.Message);
            }
        }

        public IProsumerRepository Prosumers => _prosumers ?? (_prosumers = new ProsumerRepository(Context));
    }
}