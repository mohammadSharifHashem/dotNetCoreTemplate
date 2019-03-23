using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using CommonLib.Loggers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NWebsec.AspNetCore.Mvc;
using Project.ApplicationLib.Controllers;
using Project.ApplicationLib.Controllers.Filters;
using Project.Server.Controllers.RequestObjects;

namespace Project.Server.Controllers
{
    namespace RequestObjects
    {
        
    }

    [XContentTypeOptions]
    [XDownloadOptions]
    [XFrameOptions(Policy = XFrameOptionsPolicy.SameOrigin)]
    [XXssProtection]
    //[RequireHttps]
    public class AuthController : BaseAPIController
    {
        private static FileLogService _logger = new FileLogService(typeof(AuthController));

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Test");
        }

        [HttpPost]
        [ValidateModel]
        public IActionResult Post([FromForm] BaseRO dto)
        {
            return Ok(dto);
        }
    }
}