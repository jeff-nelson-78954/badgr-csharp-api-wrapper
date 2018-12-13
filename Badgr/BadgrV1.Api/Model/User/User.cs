using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgrV1.Api.Model
{
    public class User: UserUpdate
    {
        public User()
        {

        }
        public User(Token token)
        {
            this.Token = token;
        }

        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "agreed_terms_version")]
        public int AgreedTermsVersion { get; set; }

        [JsonProperty(PropertyName = "marketing_opt_in")]
        public bool MarketinOptIn { get; set; }

        [JsonProperty(PropertyName = "latest_terms_version")]
        public int LatestTermsVersion { get; set; }
    }
}
