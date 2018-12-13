using Badgr.Utilities;
using Newtonsoft.Json;

namespace BadgrV1.Api.Model
{
    public class BadgeUpdate: BadgeAdd
    {
        public BadgeUpdate()
        {

        }
        public BadgeUpdate(Token token)
        {
            this.Token = token;
        }

        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }

        public Badge Update(string issuerSlug)
        {
            var badge = HtmlUtilities.GetResults<BadgeUpdate, Badge>(string.Format("{0}/v1/issuer/issuers/{1}/badges/{2}", BadgrUrl, issuerSlug, Slug), this, TokenHeader, "PUT");
            badge.Token = Token;
            return badge;
        }
        /// <summary>
        /// All instances of the badge class must be revoked before you can delete it.
        /// </summary>
        /// <param name="issuerSlug"></param>
        public void Delete(string issuerSlug)
        {
            HtmlUtilities.GetResults<Badge>(string.Format("{0}/v1/issuer/issuers/{1}/badges/{2}", BadgrUrl, issuerSlug, Slug), TokenHeader, "DELETE");
        }

    }
}
