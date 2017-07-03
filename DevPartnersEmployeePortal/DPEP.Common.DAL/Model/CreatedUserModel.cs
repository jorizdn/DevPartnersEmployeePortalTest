using Newtonsoft.Json;

namespace DPEP.Common.DAL.Model
{
    public class CreatedUserModel
    {
        public string Username { get; set; }
        [JsonProperty(PropertyName = "id")]
        public string GUID { get; set; }
        public string Role { get; set; }
        public ClaimType Claim { get; set; }
        public string ReferenceCode { get; set; }
        public string Token { get; set; }
        public string Href { get; set; }
    }
    public class ClaimType
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
