using CommonLib.AppUtilities;
using Project.Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;

namespace Project.BLL.ManagerServices.Interfaces
{
    public interface IRegisterdAppManagerService
    {
        GList<RegisteredApps> List(int? pageIndex, int? pageSize, Expression<Func<RegisteredApps, bool>> where, string sortBy, ListSortDirection? sortDirection);

        RegisteredApps Get(string appId);
    }
}
