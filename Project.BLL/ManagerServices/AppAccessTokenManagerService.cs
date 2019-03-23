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
    class AppAccessTokenManagerService : IAppAccessTokenManagerService
    {
        private FileLogService _logger;
        DALFacade _dALFacade;

        public AppAccessTokenManagerService(DALFacade dALFacade)
        {
            _logger = new FileLogService(typeof(IUserManagerService));
            _dALFacade = dALFacade;
        }

        public AppAccessTokens Add(AppAccessTokens item, Users actionUser)
        {
            return _dALFacade.AppAccessTokenRepository.Add(item, actionUser);
        }

        public bool Delete(string token, Users actionUser)
        {
            return _dALFacade.AppAccessTokenRepository.Delete(token, actionUser);
        }

        public AppAccessTokens Get(string token)
        {
            return _dALFacade.AppAccessTokenRepository.Get(token);
        }

        public GList<AppAccessTokens> List(int? pageIndex, int? pageSize, Expression<Func<AppAccessTokens, bool>> where, string sortBy, ListSortDirection? sortDirection)
        {
            return _dALFacade.AppAccessTokenRepository.List(pageIndex, pageSize, where, sortBy, sortDirection);
        }

        public bool Update(AppAccessTokens item, Users actionUser)
        {
            return _dALFacade.AppAccessTokenRepository.Update(item, actionUser);
        }
    }
}
