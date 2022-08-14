using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularJS_Proj.Models
{
    public class ContactModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("session")]
        public string Session { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("captchaKey")]
        public string captchaKey { get; set; }
    }
}
