using Newtonsoft.Json;

namespace BadgrV1.Api.Model
{
    public abstract class BadgrApiEntity: BadgrEntity
    {
        [JsonIgnore]
        public Token Token { get; set; }
        [JsonIgnore]
        public string TokenHeader
        {
            get
            {
                if(Token != null)
                {
                    return string.Format("Bearer {0}", Token.AccessToken);
                }
                return "";
            }
        }
    }
}
