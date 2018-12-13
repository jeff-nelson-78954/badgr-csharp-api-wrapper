using Newtonsoft.Json;

namespace BadgrV1.Api.Model
{
    public class IssuerStaffUser
    {
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }

        [JsonProperty(PropertyName = "agreed_terms_version")]
        public int AgreedTermsVersion { get; set; }

        [JsonProperty(PropertyName = "marketing_opt_in")]
        public bool MarketingOptIn { get; set; }

        [JsonProperty(PropertyName = "latest_terms_version")]
        public int LatestTermsVersion { get; set; }
    }
}
