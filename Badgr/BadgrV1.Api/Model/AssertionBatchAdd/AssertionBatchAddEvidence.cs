using Newtonsoft.Json;

namespace BadgrV1.Api.Model
{
    public class AssertionBatchAddEvidence
    {
        [JsonProperty(PropertyName = "evidence_url")]
        public string EvidenceUrl { get; set; }
    }
}
