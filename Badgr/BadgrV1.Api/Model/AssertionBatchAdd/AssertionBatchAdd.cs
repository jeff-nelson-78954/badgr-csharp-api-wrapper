using Badgr.Utilities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BadgrV1.Api.Model
{
    public class AssertionBatchAdd : BadgrApiEntity
    {
        public AssertionBatchAdd()
        {
            Assertions = new List<AssertionBatchAddAssertion>();
        }
        public AssertionBatchAdd(Token token)
        {
            this.Token = token;
            Assertions = new List<AssertionBatchAddAssertion>();
        }
        [JsonProperty(PropertyName = "assertions")]
        public List<AssertionBatchAddAssertion> Assertions { get; set; }

        [JsonProperty(PropertyName = "badge_class")]
        public string BadgeClass { get; set; }

        [JsonProperty(PropertyName = "create_notification")]
        public bool CreateNotification { get; set; }

        [JsonProperty(PropertyName = "issuer")]
        public string Issuer { get; set; }

        public void BatchIssue()
        {
             HtmlUtilities.GetResults<AssertionBatchAdd,List<AssertionBatchAdd>>(string.Format("{0}/v1/issuer/issuers/{1}/badges/{2}/batchAssertions", BadgrUrl, Issuer, BadgeClass), this, TokenHeader);
        }
    }
}
