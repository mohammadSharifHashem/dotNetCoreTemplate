using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Project.Server.Controllers.RequestObjects
{
    public class BaseRO
    {
        [Required(ErrorMessage = "AppId is required")]
        [DataMember(IsRequired = true)]
        public string AppId { get; set; }

        [Required(ErrorMessage = "AppSecret is required")]
        [DataMember(IsRequired = true)]
        public string AppSecret { get; set; }

        [Required(ErrorMessage = "DeviceToken is required")]
        [DataMember(IsRequired = true)]
        public string DeviceToken { get; set; }
    }
}
