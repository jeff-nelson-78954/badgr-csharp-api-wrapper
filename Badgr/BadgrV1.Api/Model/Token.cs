using Badgr.Utilities;
using Newtonsoft.Json;
using System;

namespace BadgrV1.Api.Model
{
    public class Token: BadgrEntity
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }
        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }
        [JsonProperty(PropertyName = "expires_in")]
        public string ExpiresIn { get; set; }
        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; set; }
        [JsonProperty(PropertyName = "scope")]
        public string Scope { get; set; }

        public void GetToken(string username, string password)
        {
            var temp = HtmlUtilities.GetResults<Token>(string.Format("{0}/o/token?username={1}&password={2}", BadgrUrl, username, password),null,"POST");

            if (temp == null)
                throw new Exception("Could get get auth token from badgr.");
            else
                PropertyCopy.Copy(temp, this);
        }
    }
}
