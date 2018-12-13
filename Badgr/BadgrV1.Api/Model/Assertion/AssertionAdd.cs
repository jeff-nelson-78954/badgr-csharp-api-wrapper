using System.Collections.Generic;
using Badgr.Utilities;
using Newtonsoft.Json;

namespace BadgrV1.Api.Model
{
    public class AssertionAdd:BadgrApiEntity
    {
        public AssertionAdd()
        {

        }
        public AssertionAdd(Token token)
        {
            this.Token = token;
        }
        [JsonProperty(PropertyName = "issuer")]
        public string Issuer { get; set; }

        [JsonProperty(PropertyName = "badge_class")]
        public string BadgeClass { get; set; }

        [JsonProperty(PropertyName = "recipient_type")]
        public string RecipientType { get; set; }

        [JsonProperty(PropertyName = "recipient_identifier")]
        public string RecipientIdentifier { get; set; }

        [JsonProperty(PropertyName = "narrative")]
        public string Narrative { get; set; }

        [JsonProperty(PropertyName = "create_notification")]
        public bool CreateNotification { get; set; }

        [JsonProperty(PropertyName = "evidence_items")]
        public List<AssertionEvidence> EvidenceItems { get; set; }

        public Assertion Issue()
        {
            var assertion =  HtmlUtilities.GetResults<AssertionAdd,Assertion>(string.Format("{0}/v1/issuer/issuers/{1}/badges/{2}/assertions", BadgrUrl, Issuer, BadgeClass), this, TokenHeader);
            assertion.Token = Token;
            return assertion;
        }
    }
}
