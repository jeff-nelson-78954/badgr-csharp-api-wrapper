using Badgr.Utilities;
using Newtonsoft.Json;

namespace BadgrV1.Api.Model
{
    public class UserUpdate : BadgrApiEntity
    {
        public UserUpdate()
        {

        }
        public UserUpdate(Token token)
        {
            this.Token = token;
        }        

        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }        

        public UserUpdate Update()
        {
            var user = HtmlUtilities.GetResults<UserUpdate, User>(string.Format("{0}/v1/user/profile", BadgrUrl), this, TokenHeader, "PUT");
            user.Token = Token;
            return user;
        }

    }
}
