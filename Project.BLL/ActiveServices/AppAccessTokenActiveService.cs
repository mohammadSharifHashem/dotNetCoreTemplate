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
using CommonLib.Helpers;

namespace Project.BLL.ActiveServices
{
    class AppAccessTokenActiveService : IAppAccessTokenActiveService
    {
        private FileLogService _logger;
        BLLFacade _bLLFacade;

        public AppAccessTokenActiveService(BLLFacade bLLFacade)
        {
            _logger = new FileLogService(typeof(IUserActiveService));
            _bLLFacade = bLLFacade;
        }

        public AppAccessTokens Add(AppAccessTokens item, Users actionUser)
        {
            item.Status = (byte)enStatus.ACTIVE;
            return _bLLFacade.AppAccessTokenManagerService.Add(item, actionUser);
        }

        public AppAccessTokens GenerateAccessForUser(Users user, string appId, string deviceToken, Users actionUser)
        {
            try
            {
                var appAccessToken = new AppAccessTokens()
                {
                    Token = TokenHelper.GenerateUserAccessToken(user.UserId),
                    DeviceToken = deviceToken,
                    AppId = appId,
                    AllowNotifications = true,
                };

                return Add(appAccessToken, actionUser);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                return null;
            }
        }

        public GList<AppAccessTokens> GetAppAccessTokenByDeviceToken(string deviceToken)
        {
            return List(null, null, x => x.DeviceToken == deviceToken, null, null);
        }

        public AppAccessTokens GetAppAccessTokenByTokenDeviceToken(string token, string deviceToken)
        {
            return List(null, null, x => x.Token == token && x.DeviceToken == deviceToken, null, null).List.FirstOrDefault();
        }

        public GList<AppAccessTokens> List(int? pageIndex, int? pageSize, Expression<Func<AppAccessTokens, bool>> where, string sortBy, ListSortDirection? sortDirection)
        {
            Expression<Func<AppAccessTokens, bool>> mainWhere = (a => a.Status == (byte)enStatus.ACTIVE);
            Expression<Func<AppAccessTokens, bool>> customWhere = where ?? (x => true == true);
            var whereToApply = mainWhere.And<AppAccessTokens>(customWhere);

            return _bLLFacade.AppAccessTokenManagerService.List(pageIndex, pageSize, whereToApply, sortBy, sortDirection);
        }
    }
}
