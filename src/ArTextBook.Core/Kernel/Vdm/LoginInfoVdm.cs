using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Alva.ArTextBook.Kernel.Vdm
{
    public class LoginInfoVdm
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("verifyCode")]
        public string verifyCode { get; set; }
    }
}
