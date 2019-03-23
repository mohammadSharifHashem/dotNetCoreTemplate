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
    class RegisterdAppManagerService : IRegisterdAppManagerService
    {
        private FileLogService _logger;
        DALFacade _dALFacade;

        public RegisterdAppManagerService(DALFacade dALFacade)
        {
            _logger = new FileLogService(typeof(IUserManagerService));
            _dALFacade = dALFacade;
        }

        public RegisteredApps Get(string appId)
        {
            return _dALFacade.RegisteredAppRepository.Get(appId);
        }

        public GList<RegisteredApps> List(int? pageIndex, int? pageSize, Expression<Func<RegisteredApps, bool>> where, string sortBy, ListSortDirection? sortDirection)
        {
            return _dALFacade.RegisteredAppRepository.List(pageIndex, pageSize, where, sortBy, sortDirection);
        }
    }
}
