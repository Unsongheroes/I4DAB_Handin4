using System;
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

        public void Commit()
        {
            Context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await Context.SaveChangesAsync();
        }

        public IProsumerRepository Prosumers => _prosumers ?? (_prosumers = new ProsumerRepository(Context));
    }
}