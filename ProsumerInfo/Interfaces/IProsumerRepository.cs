using System.Threading.Tasks;
using ProsumerInfo.Models;

namespace ProsumerInfo.Interfaces
{
    public interface IProsumerRepository : IRepository<Prosumer>
    {
        Prosumer Update(Prosumer entity);
        Prosumer Remove(int key);
    }
}