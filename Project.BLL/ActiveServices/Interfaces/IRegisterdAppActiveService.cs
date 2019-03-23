using CommonLib.AppUtilities;
using Project.BLL.BusinessObjects;
using Project.Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;

namespace Project.BLL.ActiveServices.Interfaces
{
    public interface IRegisterdAppActiveService
    {
        RegisteredApps Get(string appId);

        GList<RegisteredApps> List(int? pageIndex, int? pageSize, Expression<Func<RegisteredApps, bool>> where, string sortBy, ListSortDirection? sortDirection);

        RegisteredAppValidityBO CheckRegisteredAppValidity(string appId, string appSecret);
    }
}
