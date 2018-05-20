using ProsumerInfo.Models;
using ProsumerInfo.Models.Dtos;

namespace ProsumerInfo.Interfaces
{
    public interface IDtoFactory
    {
        ProsumerFullDto CreateFullDto(Prosumer prosumer);
        ProsumerDto CreateDto(Prosumer prosumer);
    }
}