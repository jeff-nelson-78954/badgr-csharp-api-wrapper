using Badgr.Utilities;
using Newtonsoft.Json;

namespace BadgrV1.Api.Model
{
    public  class UserPasswordReset : BadgrEntity
    {
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        public void Recover()
        {
             HtmlUtilities.GetResults<UserPasswordReset, object>(string.Format("{0}/v1/user/forgot-password", BadgrUrl), this, null, "PUT");
        }
    }
}
