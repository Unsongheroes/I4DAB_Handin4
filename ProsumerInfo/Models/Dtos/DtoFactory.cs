using ProsumerInfo.Interfaces;

namespace ProsumerInfo.Models.Dtos
{
    public class DtoFactory : IDtoFactory
    {
        public ProsumerFullDto CreateFullDto(Prosumer prosumer)
        {
            var dto = new ProsumerFullDto
            {
                Id = prosumer.Id,
                PublicKey = prosumer.PublicKey,
                Type = prosumer.Type,
                SmartMeter = new SmartMeterDto
                {
                    GeneratedPower = prosumer.SmartMeter.GeneratedPower,
                    UsedPower = prosumer.SmartMeter.UsedPower
                }
            };
            return dto;
        }

        public ProsumerDto CreateDto(Prosumer prosumer)
        {
            var dto = new ProsumerDto {Id = prosumer.Id, PublicKey = prosumer.PublicKey, Type = prosumer.Type};
            return dto;
        }
    }
}