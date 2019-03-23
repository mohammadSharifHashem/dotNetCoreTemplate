using CommonLib.AppSettings;
using CommonLib.AppUtilities;
using CommonLib.Loggers;
using Project.ApplicationLib.Extensions;
using Project.DAL.IRepositories;
using Project.Entity.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project.DAL.Repositories
{
    class RegisteredAppRepository : IRegisteredAppRepository
    {
        private FileLogService _logger;
        TemplateDBContext _context;

        public RegisteredAppRepository(TemplateDBContext context)
        {
            _logger = new FileLogService(typeof(IRegisteredAppRepository));
            _context = context;
        }

        public RegisteredApps Get(string appId)
        {
            try
            {
                return List(0, 1, x => x.AppId == appId, null, null).List.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + ex.Message, ex);
                return null;
            }
        }

        public GList<RegisteredApps> List(int? pageIndex, int? pageSize, Expression<Func<RegisteredApps, bool>> where, string sortBy, ListSortDirection? sortDirection)
        {
            try
            {
                GList<RegisteredApps> lstToReturn = new GList<RegisteredApps>();

                var objs = _context.RegisteredApps.Where(x => x.Status != (byte)enStatus.DELETED);

                if (where != null) objs = objs.Where(where);

                if (sortDirection == null) sortDirection = ListSortDirection.Ascending;

                if (sortBy != null)
                    objs = objs.OrderBy(sortBy, sortDirection.Value);

                if (pageIndex != null && pageSize != null)
                {
                    if (sortBy == null)
                        objs = objs.OrderBy(x => x.AddedDate);

                    lstToReturn.SetPaging(pageIndex.Value, pageSize.Value, objs.Count());

                    objs = objs.Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value);
                }

                lstToReturn.List = objs.Select(x => new
                {
                    x.AppId,
                    x.AppSecret,

                    x.IosCertificateFile,
                    x.IosCertificatePassword,

                    x.AndroidApiKey,

                    x.FacebookAppId,
                    x.FacebookAppSecret,

                    x.GoogleAppId,
                    x.GoogleAppSecret,

                    x.GoogleApiKeyIos,
                    x.GoogleApiKeyAndroid,
                    x.GoogleApiKeyWeb,

                    x.IosVersionNumber,
                    x.IosIsMandatoryVersionUpdate,
                    x.AndroidVersionNumber,
                    x.AndroidIsMandatoryVersionUpdate,

                    x.IsExternal,
                    x.AccessTokenExpiryInMins,
                    x.IosLowerVersionsExpiryDate,
                    x.AndroidLowerVersionsExpiryDate,
                    x.VersionExpiryNotifyDays,

                    x.Status,
                    x.AddedDate,

                }).AsEnumerable().Select(x => new RegisteredApps()
                {
                    AppId = x.AppId,
                    AppSecret = x.AppSecret,

                    IosCertificateFile = x.IosCertificateFile,
                    IosCertificatePassword = x.IosCertificatePassword,

                    AndroidApiKey = x.AndroidApiKey,

                    FacebookAppId = x.FacebookAppId,
                    FacebookAppSecret = x.FacebookAppSecret,

                    GoogleAppId = x.GoogleAppId,
                    GoogleAppSecret = x.GoogleAppSecret,

                    GoogleApiKeyIos = x.GoogleApiKeyIos,
                    GoogleApiKeyAndroid = x.GoogleApiKeyAndroid,
                    GoogleApiKeyWeb = x.GoogleApiKeyWeb,

                    IosVersionNumber = x.IosVersionNumber,
                    IosIsMandatoryVersionUpdate = x.IosIsMandatoryVersionUpdate,
                    AndroidVersionNumber = x.AndroidVersionNumber,
                    AndroidIsMandatoryVersionUpdate = x.AndroidIsMandatoryVersionUpdate,

                    IsExternal = x.IsExternal,
                    AccessTokenExpiryInMins = x.AccessTokenExpiryInMins,
                    IosLowerVersionsExpiryDate = x.IosLowerVersionsExpiryDate,
                    AndroidLowerVersionsExpiryDate = x.AndroidLowerVersionsExpiryDate,
                    VersionExpiryNotifyDays = x.VersionExpiryNotifyDays,

                    Status = x.Status,
                    AddedDate = x.AddedDate,

                }).ToList();

                return lstToReturn;
            }
            catch (Exception ex)
            {
                _logger.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + ex.Message, ex);
                return null;
            }
        }
    }
}
