using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DPEP.Common.DAL.Model
{
    public class Captcha
    {
        [Required]
        [JsonProperty(PropertyName = "g-recaptcha-response")]
        public string ResponseCaptcha { get; set; }
    }
}