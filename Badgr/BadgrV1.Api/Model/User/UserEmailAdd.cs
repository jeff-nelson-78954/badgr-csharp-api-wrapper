using System.Collections.Generic;
using Badgr.Utilities;
using Newtonsoft.Json;

namespace BadgrV1.Api.Model
{
    public class UserEmailAdd : BadgrApiEntity
    {
        public UserEmailAdd()
        {

        }
        public UserEmailAdd(Token token)
        {
            this.Token = token;
        }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        public UserEmail Add()
        {
            var email = HtmlUtilities.GetResults<UserEmailAdd, UserEmail>(string.Format("{0}/v1/user/emails", BadgrUrl), this, TokenHeader);
            email.Token = Token;
            return email;
        }
    }
}
