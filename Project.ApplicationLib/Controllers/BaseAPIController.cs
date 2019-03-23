using Microsoft.AspNetCore.Mvc;
using NWebsec.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;

namespace Project.ApplicationLib.Controllers
{
    [XContentTypeOptions]
    [XDownloadOptions]
    [XFrameOptions(Policy = XFrameOptionsPolicy.SameOrigin)]
    [XXssProtection]
    //[RequireHttps]
    public class BaseAPIController : ControllerBase
    {
        
    }
}
