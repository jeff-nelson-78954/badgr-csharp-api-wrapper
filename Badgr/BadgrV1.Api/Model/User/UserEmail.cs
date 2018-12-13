using Newtonsoft.Json;
using System.Collections.Generic;

namespace BadgrV1.Api.Model
{
    public class UserEmail: UserEmailUpdate
    {
        public UserEmail(Token token)
        {
            this.Token = token;
        }

        //public UserEmail()
        //{
        //    Variants = new List<string>();
        //}
        //[JsonProperty(PropertyName = "id")]
        //public int id { get; set; }

        //[JsonProperty(PropertyName = "verified")]
        //public bool Verified { get; set; }

        //[JsonProperty(PropertyName = "primary")]
        //public string Primary { get; set; }

        //[JsonProperty(PropertyName = "variants")]
        //public List<string> Variants { get; set; }
    }
}
