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

        public override Prosumer Add(Prosumer prosumer)
        {
            prosumer.Id = 0;
            return Context.Set<Prosumer>().Add(prosumer).Entity;
        }

        public Prosumer Update(Prosumer entity)
        {
            return Update(entity, null);
        }

        public override Prosumer Update(Prosumer entity, object key)
        {
            var target = Context.Set<Prosumer>().Include(p => p.SmartMeter)
                .SingleOrDefault(p => p.Id == entity.Id);

            if (target != null)
            {
                entity.SmartMeter.Id = target.SmartMeter.Id;
                entity.SmartMeter.Prosumer = target.SmartMeter.Prosumer;
                entity.SmartMeter.ProsumerId = target.SmartMeter.ProsumerId;
  
                Context.Entry(target).CurrentValues.SetValues(entity);
                Context.Entry(target.SmartMeter).CurrentValues.SetValues(entity.SmartMeter);
                return target;
            }

            return null;
        }

        public Prosumer Remove(int key)
        {
            var target = Context.Set<Prosumer>().SingleOrDefault(p => p.Id == key);
            return Remove(target);
        }

        private new Prosumer Remove(Prosumer entity)
        {
            if (entity != null)
            {
                return base.Remove(entity);
            }

            return null;
        }

        public override async Task<Prosumer> GetAsync(object key)
        {
            return await Context.Set<Prosumer>().Include(p => p.SmartMeter).FirstOrDefaultAsync(p => p.Id == (int) key);
        }
    }
}