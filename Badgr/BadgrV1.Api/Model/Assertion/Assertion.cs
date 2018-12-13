using Newtonsoft.Json;

namespace BadgrV1.Api.Model
{
    public class Assertion: AssertionUpdate
    {
        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty(PropertyName = "created_by")]
        public string CreatedBy { get; set; }        

        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }

        [JsonProperty(PropertyName = "revoked")]
        public bool Revoked { get; set; }

        [JsonProperty(PropertyName = "expires")]
        public string Expires { get; set; }

        [JsonProperty(PropertyName = "hashed")]
        public bool Hashed { get; set; }

        [JsonProperty(PropertyName = "public_url")]
        public string PublicUrl { get; set; }
    }
}
