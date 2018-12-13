using Badgr.Utilities;
using Newtonsoft.Json;

namespace BadgrV1.Api.Model
{
    public class IssuerUpdate: IssuerAdd
    {
        public IssuerUpdate()
        {

        }
        public IssuerUpdate(Token token)
        {
            this.Token = token;
        }
        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }
        public Issuer Update()
        {
            var issuer = HtmlUtilities.GetResults<IssuerUpdate, Issuer>(string.Format("{0}/v1/issuer/issuers/{1}", BadgrUrl, Slug), this, TokenHeader, "PUT");
            issuer.Token = Token;
            return issuer;
        }
        public void Delete()
        {
            var issuer = HtmlUtilities.GetResults<IssuerUpdate, Issuer>(string.Format("{0}/v1/issuer/issuers/{1}", BadgrUrl, Slug), this, TokenHeader, "DELETE");
        }
    }
}
