using Newtonsoft.Json;
using System.Configuration;

namespace BadgrV1.Api.Model
{
    public class BadgrEntity
    {
        [JsonIgnore]
        public string BadgrUrl
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("BadgrUrl");
            }
        }
    }
}
