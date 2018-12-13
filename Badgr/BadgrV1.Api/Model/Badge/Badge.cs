using Newtonsoft.Json;

namespace BadgrV1.Api.Model
{
    public class Badge: BadgeUpdate
    {
        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty(PropertyName = "created_by")]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "issuer")]
        public string Issuer{ get; set; }
    }
}
