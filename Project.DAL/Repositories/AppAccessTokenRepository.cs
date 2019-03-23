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
    class AppAccessTokenRepository : IAppAccessTokenRepository
    {
        private FileLogService _logger;
        TemplateDBContext _context;

        public AppAccessTokenRepository(TemplateDBContext context)
        {
            _logger = new FileLogService(typeof(IUserRepository));
            _context = context;
        }

        public AppAccessTokens Add(AppAccessTokens item, Users actionUser)
        {
            try
            {
                if (item != null)
                {
                    item.AddedDate = DateTime.Now;
                    item.UpdatedDate = DateTime.Now;

                    _context.AppAccessTokens.Add(item);
                    _context.SaveChanges();
                    Task.Factory.StartNew(() => {
                        new ActionLogRepository(_context).Add(enActionTypes.ADD.ToInt(), enModules.AppAccessTokens.ToInt(), item, actionUser);
                    });
                    return item;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + ex.Message, ex);
            }
            return null;
        }

        public bool Delete(string token, Users actionUser)
        {
            try
            {
                var item = Get(token);

                if (item != null)
                {
                    item.Status = (byte)enStatus.DELETED;
                    item.UpdatedDate = DateTime.Now;

                    _context.SaveChanges();
                    Task.Factory.StartNew(() => {
                        new ActionLogRepository(_context).Add(enActionTypes.DELETE.ToInt(), enModules.AppAccessTokens.ToInt(), item, actionUser);
                    });
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + ex.Message, ex);
            }
            return false;
        }

        public AppAccessTokens Get(string token)
        {
            try
            {
                return List(0, 1, x => x.Token == token, null, null).List.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + ex.Message, ex);
                return null;
            }
        }

        public GList<AppAccessTokens> List(int? pageIndex, int? pageSize, Expression<Func<AppAccessTokens, bool>> where, string sortBy, ListSortDirection? sortDirection)
        {
            try
            {
                GList<AppAccessTokens> lstToReturn = new GList<AppAccessTokens>();

                var objs = _context.AppAccessTokens.Where(x => x.Status != (byte)enStatus.DELETED);

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
                    x.Token,
                    x.UserId,
                    x.ExpiryDate,
                    x.AppId,
                    x.DeviceToken,
                    x.AppVersion,
                    x.DevicePlatform,
                    x.PlatformVersion,
                    x.DeviceType,
                    x.DeviceId,
                    x.IpAddress,
                    x.AllowNotifications,
                    x.Status,
                    x.AddedDate,
                    x.UpdatedDate,

                }).AsEnumerable().Select(x => new AppAccessTokens()
                {
                    Token = x.Token,
                    UserId = x.UserId,
                    ExpiryDate = x.ExpiryDate,
                    AppId = x.AppId,
                    DeviceToken = x.DeviceToken,
                    AppVersion = x.AppVersion,
                    DevicePlatform = x.DevicePlatform,
                    PlatformVersion = x.PlatformVersion,
                    DeviceType = x.DeviceType,
                    DeviceId = x.DeviceId,
                    IpAddress = x.IpAddress,
                    AllowNotifications = x.AllowNotifications,
                    Status = x.Status,
                    AddedDate = x.AddedDate,
                    UpdatedDate = x.UpdatedDate,

                }).ToList();

                return lstToReturn;
            }
            catch (Exception ex)
            {
                _logger.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + ex.Message, ex);
                return null;
            }
        }

        public bool Update(AppAccessTokens item, Users actionUser)
        {
            try
            {
                if (item != null)
                {
                    var dbItem = Get(item.Token);

                    if (dbItem != null)
                    {
                        dbItem.AppVersion = item.AppVersion;
                        dbItem.DevicePlatform = item.DevicePlatform;
                        dbItem.PlatformVersion = item.PlatformVersion;
                        dbItem.DeviceType = item.DeviceType;
                        dbItem.DeviceId = item.DeviceId;
                        dbItem.IpAddress = item.IpAddress;
                        dbItem.AllowNotifications = item.AllowNotifications;
                        dbItem.Status = item.Status;
                        dbItem.UpdatedDate = DateTime.Now;

                        _context.SaveChanges();
                        Task.Factory.StartNew(() => {
                            new ActionLogRepository(_context).Add(enActionTypes.UPDATE.ToInt(), enModules.AppAccessTokens.ToInt(), dbItem, actionUser);
                        });
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + ex.Message, ex);
            }
            return false;
        }
    }
}
