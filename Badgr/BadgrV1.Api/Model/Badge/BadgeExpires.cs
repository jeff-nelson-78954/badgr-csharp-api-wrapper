using Newtonsoft.Json;


namespace BadgrV1.Api.Model
{
    public class BadgeExpires
    {
        [JsonProperty(PropertyName = "amount")]
        public int? Amount { get; set; }

        /// <summary>
        /// days, weeks, months, years
        /// </summary>
        [JsonProperty(PropertyName = "duration")]
        public string Duration { get; set; }
    }
}
