namespace ProsumerInfo.Models.Dtos
{
    public class ProsumerFullDto
    {
        public int Id { get; set; }
        public string PublicKey { get; set; }
        public string Type { get; set; }
        public SmartMeterDto SmartMeter { get; set; }
    }

    public class SmartMeterDto
    {
        public int GeneratedPower { get; set; }
        public int UsedPower { get; set; }
    }
}