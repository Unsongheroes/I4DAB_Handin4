using Newtonsoft.Json;

namespace ProsumerInfo.Models.Dtos
{
    public class ProsumerFullDto
    {
        public int Id { get; set; }
        [JsonRequired]
        public string PublicKey { get; set; }
        [JsonRequired]
        public string Type { get; set; }
        [JsonRequired]
        public SmartMeterDto SmartMeter { get; set; }
    }

    public class SmartMeterDto
    {
        [JsonRequired]
        public int GeneratedPower { get; set; }
        [JsonRequired]
        public int UsedPower { get; set; }
    }
}