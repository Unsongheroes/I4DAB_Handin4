using Newtonsoft.Json;

namespace ProsumerInfo.Models.Dtos
{
    public class ProsumerDto
    {
        public int Id { get; set; }
        [JsonRequired]
        public string PublicKey { get; set; }
        [JsonRequired]
        public string Type { get; set; }
    }
}