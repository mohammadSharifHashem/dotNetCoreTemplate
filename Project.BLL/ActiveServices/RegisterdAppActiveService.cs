using CommonLib.AppSettings;
using CommonLib.AppUtilities;
using CommonLib.Loggers;
using Project.Entity.Models;
using System;
using Project.ApplicationLib.Extensions;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Linq;
using Project.BLL.BusinessObjects;
using Project.BLL.ActiveServices.Interfaces;

namespace Project.BLL.ActiveServices
{
    class RegisterdAppActiveService : IRegisterdAppActiveService
    {
        private FileLogService _logger;
        BLLFacade _bLLFacade;

        public RegisterdAppActiveService(BLLFacade bLLFacade)
        {
            _logger = new FileLogService(typeof(IRegisterdAppActiveService));
            _bLLFacade = bLLFacade;
        }

        public RegisteredAppValidityBO CheckRegisteredAppValidity(string appId, string appSecret)
        {
            RegisteredApps registeredApp = Get(appId);

            if (registeredApp == null)
            {
                return new RegisteredAppValidityBO()
                {
                    IsValidApp = false,
                    ErrorMessage = "Invalid App Id",
                };
            }

            if (registeredApp.IsExternal)
            {
                return new RegisteredAppValidityBO()
                {
                    IsValidApp = false,
                    ErrorMessage = "Invalid App",
                };
            }
            
            if (registeredApp.AppSecret != appSecret)
            {
                return new RegisteredAppValidityBO()
                {
                    IsValidApp = false,
                    ErrorMessage = "Invalid App Secret",
                };
            }

            return new RegisteredAppValidityBO()
            {
                ErrorMessage = "",
                IsValidApp = true,
            };

        }

        public RegisteredApps Get(string appId)
        {
            return List(0, 1, x => x.AppId == appId, null, null).List.FirstOrDefault();
        }

        public GList<RegisteredApps> List(int? pageIndex, int? pageSize, Expression<Func<RegisteredApps, bool>> where, string sortBy, ListSortDirection? sortDirection)
        {
            Expression<Func<RegisteredApps, bool>> mainWhere = (a => a.Status == (byte)enStatus.ACTIVE);
            Expression<Func<RegisteredApps, bool>> customWhere = where ?? (x => true == true);
            var whereToApply = mainWhere.And<RegisteredApps>(customWhere);

            return _bLLFacade.RegisterdAppManagerService.List(pageIndex, pageSize, whereToApply, sortBy, sortDirection);
        }
    }
}
