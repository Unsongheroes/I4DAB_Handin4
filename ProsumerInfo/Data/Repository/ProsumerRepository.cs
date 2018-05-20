using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProsumerInfo.Interfaces;
using ProsumerInfo.Models;

namespace ProsumerInfo.Data.Repository
{
    public class ProsumerRepository : BaseRepository<Prosumer>, IProsumerRepository
    {
        public ProsumerRepository(DbContext context) : base(context)
        {
        }

        public override Prosumer Update(Prosumer entity, object key)
        {
            var target = Context.Set<Prosumer>().Where(p => p.Id == entity.Id).Include(p => p.SmartMeter)
                .SingleOrDefault();

            if (target != null)
            {
                entity.SmartMeter.Id = target.SmartMeter.Id;
                // Update parent
                Context.Entry(target).CurrentValues.SetValues(entity);
                Context.Entry(target.SmartMeter).CurrentValues.SetValues(entity.SmartMeter);
                return target;
            }

            return null;
        }

        public override Prosumer Remove(Prosumer entity)
        {
            var target = Context.Set<Prosumer>().Where(p => p.Id == entity.Id).Include(p => p.SmartMeter)
                .SingleOrDefault();

            if (target != null)
            {
                Context.Set<SmartMeter>().Remove(target.SmartMeter);
                return Context.Set<Prosumer>().Remove(entity).Entity;
            }

            return null;
        }

        public override async Task<Prosumer> GetAsync(object key)
        {
            return await Context.Set<Prosumer>().Include(p => p.SmartMeter).FirstOrDefaultAsync(p => p.Id == (int) key);
        }
    }
}