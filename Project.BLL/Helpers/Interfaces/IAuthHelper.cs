using Project.BLL.BusinessObjects;
using Project.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.Helpers.Interfaces
{
    public interface IAuthHelper
    {
        SignupBO SignupAndAuthorize();
    }
}
