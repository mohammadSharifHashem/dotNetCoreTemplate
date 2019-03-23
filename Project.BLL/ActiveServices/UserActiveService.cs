using CommonLib.AppSettings;
using CommonLib.AppUtilities;
using CommonLib.Loggers;
using Project.Entity.Models;
using System;
using Project.ApplicationLib.Extensions;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Linq;
using Project.BLL.ActiveServices.Interfaces;

namespace Project.BLL.ActiveServices
{
    class UserActiveService : IUserActiveService
    {
        private FileLogService _logger;
        BLLFacade _bLLFacade;

        public UserActiveService (BLLFacade bLLFacade)
        {
            _logger = new FileLogService(typeof(IUserActiveService));
            _bLLFacade = bLLFacade;
        }

        public Users Add(Users item, Users actionUser)
        {
            item.Status = (byte)enStatus.ACTIVE;
            return _bLLFacade.UserManagerService.Add(item, actionUser);
        }

        public Users Get(long id)
        {
            return List(0, 1, x => x.UserId == id, null, null).List.FirstOrDefault();
        }

        public Users GetSystemUser()
        {
            return List(0, 1, x => x.UserTypeId == enUserTypes.SYSTEM.ToInt(), null, null).List.FirstOrDefault();
        }

        public bool IsClientExists(string username)
        {
            var lst = List(0, 1, x => x.UserTypeId == enUserTypes.CLIENT.ToInt() && x.Username == username, null, null).List;
            return lst != null && lst.Count > 0; 
        }

        public GList<Users> List(int? pageIndex, int? pageSize, Expression<Func<Users, bool>> where, string sortBy, ListSortDirection? sortDirection)
        {
            Expression<Func<Users, bool>> mainWhere = (a => a.Status == (byte)enStatus.ACTIVE);
            Expression<Func<Users, bool>> customWhere = where ?? (x => true == true);
            var whereToApply = mainWhere.And<Users>(customWhere);

            return _bLLFacade.UserManagerService.List(pageIndex, pageSize, whereToApply, sortBy, sortDirection);
        }

        public bool Update(Users item, Users actionUser)
        {
            return _bLLFacade.UserManagerService.Update(item, actionUser);
        }
    }
}
