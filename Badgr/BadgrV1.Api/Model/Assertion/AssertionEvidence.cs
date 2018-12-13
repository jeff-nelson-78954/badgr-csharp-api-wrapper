using Newtonsoft.Json;

namespace BadgrV1.Api.Model
{
    public class AssertionEvidence
    {
        [JsonProperty(PropertyName = "narrative")]
        public string Narrative { get; set; }

        [JsonProperty(PropertyName = "evidence_url")]
        public string EvidenceUrl { get; set; }

        [JsonProperty(PropertyName = "expiration")]
        public string Expiration { get; set; }
    }
}
