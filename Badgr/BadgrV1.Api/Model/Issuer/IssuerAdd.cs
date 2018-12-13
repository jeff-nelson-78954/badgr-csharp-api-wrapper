using System.Collections.Generic;
using Badgr.Utilities;
using Newtonsoft.Json;

namespace BadgrV1.Api.Model
{
    public class IssuerAdd : BadgrApiEntity
    {
        public IssuerAdd()
        {
        }
        public IssuerAdd(Token token)
        {
            this.Token = token;
        }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }

        /// <summary>
        /// Email must be a verified email address in badger
        /// Url must be in a correct format http://www.test.com 
        /// </summary>
        /// <returns></returns>
        public Issuer Add()
        {
            var issuer = HtmlUtilities.GetResults<IssuerAdd, Issuer>(string.Format("{0}/v1/issuer/issuers", BadgrUrl), this, TokenHeader);
            issuer.Token = Token;
            return issuer;
        }
    }
}
