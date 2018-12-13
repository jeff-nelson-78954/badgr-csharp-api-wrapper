using Badgr.Utilities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BadgrV1.Api.Model
{
    public class UserEmailUpdate: UserEmailAdd
    {
        public UserEmailUpdate()
        {
            Variants = new List<string>();
        }

        public UserEmailUpdate(Token token)
        {
            this.Token = token;
            Variants = new List<string>();
        }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "verified")]
        public bool Verified { get; set; }

        [JsonProperty(PropertyName = "primary")]
        public string Primary { get; set; }

        [JsonProperty(PropertyName = "variants")]
        public List<string> Variants { get; set; }

        public UserEmail Update()
        {
            var email = HtmlUtilities.GetResults<UserEmailUpdate, UserEmail>(string.Format("{0}/v1/user/emails/{1}", BadgrUrl, Id), this, TokenHeader, "PUT");
            email.Token = Token;
            return email;
        }
        public void Delete()
        {
            HtmlUtilities.GetResults<object>(string.Format("{0}/v1/user/emails/{1}", BadgrUrl, Id), TokenHeader, "DELETE");
        }
    }
}
