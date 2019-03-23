using CommonLib.AppUtilities;
using Project.Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;

namespace Project.BLL.ActiveServices.Interfaces
{
    public interface IAppAccessTokenActiveService
    {
        GList<AppAccessTokens> List(int? pageIndex, int? pageSize, Expression<Func<AppAccessTokens, bool>> where, string sortBy, ListSortDirection? sortDirection);

        GList<AppAccessTokens> GetAppAccessTokenByDeviceToken(string deviceToken);

        AppAccessTokens GetAppAccessTokenByTokenDeviceToken(string token, string deviceToken);

        AppAccessTokens GenerateAccessForUser(Users user, string appId, string deviceToken, Users actionUser);

        AppAccessTokens Add(AppAccessTokens item, Users actionUser);
    }
}
