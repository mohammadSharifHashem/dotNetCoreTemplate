using CommonLib.AppUtilities;
using Project.Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;

namespace Project.BLL.ActiveServices.Interfaces
{
    public interface IUserActiveService
    {
        GList<Users> List(int? pageIndex, int? pageSize, Expression<Func<Users, bool>> where, string sortBy, ListSortDirection? sortDirection);

        Users Add(Users item, Users actionUser);

        bool Update(Users item, Users actionUser);

        Users Get(long id);

        Users GetSystemUser();

        bool IsClientExists(string username);
    }
}
