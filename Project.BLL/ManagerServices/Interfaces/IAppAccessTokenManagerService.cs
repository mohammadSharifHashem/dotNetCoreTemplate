using CommonLib.AppUtilities;
using Project.Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;

namespace Project.BLL.ManagerServices.Interfaces
{
    public interface IAppAccessTokenManagerService
    {
        GList<AppAccessTokens> List(int? pageIndex, int? pageSize, Expression<Func<AppAccessTokens, bool>> where, string sortBy, ListSortDirection? sortDirection);

        AppAccessTokens Get(string token);

        AppAccessTokens Add(AppAccessTokens item, Users actionUser);

        bool Update(AppAccessTokens item, Users actionUser);

        bool Delete(string token, Users actionUser);
    }
}
