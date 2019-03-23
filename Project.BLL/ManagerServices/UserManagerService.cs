using CommonLib.AppUtilities;
using CommonLib.Loggers;
using Project.BLL.ManagerServices.Interfaces;
using Project.DAL;
using Project.Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;

namespace Project.BLL.ManagerServices
{
    class UserManagerService : IUserManagerService
    {
        private FileLogService _logger;
        DALFacade _dALFacade;

        public UserManagerService(DALFacade dALFacade)
        {
            _logger = new FileLogService(typeof(IUserManagerService));
            _dALFacade = dALFacade;
        }

        public Users Add(Users item, Users actionUser)
        {
            return _dALFacade.UserRepository.Add(item, actionUser);
        }

        public bool Delete(long id, Users actionUser)
        {
            return _dALFacade.UserRepository.Delete(id, actionUser);
        }

        public Users Get(long id)
        {
            return _dALFacade.UserRepository.Get(id);
        }

        public GList<Users> List(int? pageIndex, int? pageSize, Expression<Func<Users, bool>> where, string sortBy, ListSortDirection? sortDirection)
        {
            return _dALFacade.UserRepository.List(pageIndex, pageSize, where, sortBy, sortDirection);
        }

        public bool Update(Users item, Users actionUser)
        {
            return _dALFacade.UserRepository.Update(item, actionUser);
        }
    }
}
