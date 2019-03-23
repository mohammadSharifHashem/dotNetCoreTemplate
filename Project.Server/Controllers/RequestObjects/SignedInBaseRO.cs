using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Project.Server.Controllers.RequestObjects
{
    public class SignedInBaseRO
    {
        [Required(ErrorMessage = "DeviceToken is required")]
        [DataMember(IsRequired = true)]
        public string DeviceToken { get; set; }

        [Required(ErrorMessage = "Token is required")]
        [DataMember(IsRequired = true)]
        public string Token { get; set; }
    }
}
