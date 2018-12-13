using System.Collections.Generic;
using Newtonsoft.Json;


namespace BadgrV1.Api.Model
{
    public class AssertionBatchAddAssertion : BadgrApiEntity
    {
        public AssertionBatchAddAssertion()
        {

        }
        public AssertionBatchAddAssertion(Token token)
        {
            this.Token = token;
        }
        [JsonProperty(PropertyName = "recipient_identifier")]
        public string RecipientIdentifier { get; set; }

        [JsonProperty(PropertyName = "evidence_items")]
        public List<AssertionBatchAddEvidence> EvidenceItems { get; set; }
    }
}
