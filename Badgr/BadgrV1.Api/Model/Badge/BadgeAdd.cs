using System.Collections.Generic;
using Badgr.Utilities;
using Newtonsoft.Json;

namespace BadgrV1.Api.Model
{
    public class BadgeAdd : BadgrApiEntity
    {
        public BadgeAdd()
        {
            Tags = new List<string>();
            Alignments = new List<BadgeAlignment>();
        }
        public BadgeAdd(Token token)
        {
            this.Token = token;
        }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }

        [JsonProperty(PropertyName = "criteria_text")]
        public string CriteriaText { get; set; }

        [JsonProperty(PropertyName = "criteria_url")]
        public string CriteriaUrl { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags { get; set; }

        [JsonProperty(PropertyName = "expires")]
        public BadgeExpires Expires { get; set; }

        [JsonProperty(PropertyName = "alignment")]
        public List<BadgeAlignment> Alignments { get; set; }

        public Badge Add(string issuerSlug)
        {
            var badge = HtmlUtilities.GetResults<BadgeAdd, Badge>(string.Format("{0}/v1/issuer/issuers/{1}/badges", BadgrUrl, issuerSlug), this, TokenHeader);
            badge.Token = Token;
            return badge;
        }
    }
}
