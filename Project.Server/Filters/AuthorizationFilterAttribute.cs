using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Server.Filters
{
    public class AuthorizationFilterAttribute : Attribute, IAuthorizationFilter
    {
        private static Dictionary<string, string> AllowedApps = new Dictionary<string, string>();
        //private readonly UInt64 requestMaxAgeInSeconds = 60;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            throw new NotImplementedException();
        }
    }
}
