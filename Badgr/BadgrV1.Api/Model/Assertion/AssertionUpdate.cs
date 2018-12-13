using Badgr.Utilities;
using Newtonsoft.Json;

namespace BadgrV1.Api.Model
{
    public class AssertionUpdate: AssertionAdd
    {
        public AssertionUpdate()
        {

        }
        public AssertionUpdate(Token token)
        {
            this.Token = token;
        }

        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }

        [JsonProperty(PropertyName = "revocation_reason")]
        public string RevocationReason { get; set; }

        public Assertion Update()
        {
            var assertion = HtmlUtilities.GetResults<AssertionUpdate, Assertion>(string.Format("{0}/v1/issuer/issuers/{1}/badges/{2}/assertions/{3}", BadgrUrl, Issuer, BadgeClass, Slug), this, TokenHeader,"PUT");
            assertion.Token = Token;
            return assertion;
        }
        public void Revoke()
        {
            var assertion = HtmlUtilities.GetResults<AssertionUpdate, Assertion>(string.Format("{0}/v1/issuer/issuers/{1}/badges/{2}/assertions/{3}", BadgrUrl, Issuer, BadgeClass, Slug), this, TokenHeader, "DELETE");            
        }
    }
}
