using Newtonsoft.Json;

namespace AspNet.Security.OAuth.Intita
{
    public class IntitaUser
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("middleName")]
        public string MiddleName { get; set; }
        [JsonProperty("secondName")]
        public string SecondName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
