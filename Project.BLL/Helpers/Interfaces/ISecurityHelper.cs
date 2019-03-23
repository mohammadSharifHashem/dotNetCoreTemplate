using Project.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.Helpers.Interfaces
{
    public interface ISecurityHelper
    {
        bool IsAppExists(string appId, Users actionUser);

        string GenerateVerificationString();
    }
}
