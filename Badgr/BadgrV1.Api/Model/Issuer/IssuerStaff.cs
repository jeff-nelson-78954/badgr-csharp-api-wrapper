using Newtonsoft.Json;

namespace BadgrV1.Api.Model
{
    public class IssuerStaff
    {
        [JsonProperty(PropertyName = "user")]
        public IssuerStaffUser User { get; set; }
        /// <summary>
        /// [ staff, editor, owner ]
        /// </summary>
        [JsonProperty(PropertyName = "role")]
        public string Role { get; set; }
    }
}
