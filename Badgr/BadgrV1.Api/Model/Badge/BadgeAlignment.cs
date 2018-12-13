using Newtonsoft.Json;

namespace BadgrV1.Api.Model
{
    public class BadgeAlignment
    {
        [JsonProperty(PropertyName = "target_name")]
        public string TargetName { get; set; }

        [JsonProperty(PropertyName = "target_url")]
        public string TargetUrl { get; set; }

        [JsonProperty(PropertyName = "target_description")]
        public string TargetDescription { get; set; }

        [JsonProperty(PropertyName = "target_framework")]
        public string TargetFramework { get; set; }

        [JsonProperty(PropertyName = "target_code")]
        public string TargetCode { get; set; }
    }
}
