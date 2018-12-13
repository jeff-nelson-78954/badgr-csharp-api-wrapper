using Newtonsoft.Json;

namespace BadgrV1.Api.Model
{
    public class UserPasswordResetRequest: BadgrEntity
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        
    }
}
