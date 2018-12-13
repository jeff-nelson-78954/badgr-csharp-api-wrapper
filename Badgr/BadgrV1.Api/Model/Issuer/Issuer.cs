using Newtonsoft.Json;
using System.Collections.Generic;

namespace BadgrV1.Api.Model
{
    public class Issuer: IssuerUpdate
    {
        public Issuer()
        {
            Staff = new List<IssuerStaff>();
        }
        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty(PropertyName = "created_by")]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "staff")]
        public List<IssuerStaff> Staff { get; set; }
    }
}
