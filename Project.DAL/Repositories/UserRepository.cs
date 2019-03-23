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
    class UserRepository : IUserRepository
    {
        private FileLogService _logger;
        TemplateDBContext _context;

        public UserRepository(TemplateDBContext context)
        {
            _logger = new FileLogService(typeof(IUserRepository));
            _context = context;
        }

        public GList<Users> List(int? pageIndex, int? pageSize, Expression<Func<Users, bool>> where, string sortBy, ListSortDirection? sortDirection)
        {
            try
            {
                GList<Users> lstToReturn = new GList<Users>();

                var objs = _context.Users.Where(x => x.Status != (byte)enStatus.DELETED);

                if (where != null) objs = objs.Where(where);

                if (sortDirection == null) sortDirection = ListSortDirection.Ascending;

                if (sortBy != null)
                    objs = objs.OrderBy(sortBy, sortDirection.Value);

                if (pageIndex != null && pageSize != null)
                {
                    if (sortBy == null)
                        objs = objs.OrderBy(x => x.UserId);

                    lstToReturn.SetPaging(pageIndex.Value, pageSize.Value, objs.Count());

                    objs = objs.Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value);
                }

                lstToReturn.List = objs.Select(x => new
                {

                    x.UserId,
                    x.UserTypeId,
                    x.Username,

                    x.FirstName,
                    x.LastName,

                    x.IsVerificationEmailSent,
                    x.VerificationToken,
                    x.Approved,

                    x.Status,
                    x.AddedDate,
                    x.UpdatedDate,

                }).AsEnumerable().Select(x => new Users()
                {

                    UserId = x.UserId,
                    UserTypeId = x.UserTypeId,
                    Username = x.Username,

                    FirstName = x.FirstName,
                    LastName = x.LastName,

                    IsVerificationEmailSent = x.IsVerificationEmailSent,
                    VerificationToken = x.VerificationToken,
                    Approved = x.Approved,

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

        public Users Get(long id)
        {
            try
            {
                return List(0, 1, x => x.UserId == id, null, null).List.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + ex.Message, ex);
                return null;
            }
        }

        public Users Add(Users item, Users actionUser)
        {
            try
            {
                if (item != null)
                {
                    item.AddedBy = actionUser.UserId;
                    item.AddedDate = DateTime.Now;
                    item.UpdatedDate = DateTime.Now;

                    _context.Users.Add(item);
                    _context.SaveChanges();
                    Task.Factory.StartNew(() => {
                        new ActionLogRepository(_context).Add(enActionTypes.ADD.ToInt(), enModules.Users.ToInt(), item, actionUser);
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

        public bool Update(Users item, Users actionUser)
        {
            try
            {
                if (item != null)
                {
                    var dbItem = Get(item.UserId);

                    if (dbItem != null)
                    {
                        dbItem.UserTypeId = item.UserTypeId;
                        dbItem.Username = item.Username;
                        dbItem.FirstName = item.FirstName;
                        dbItem.LastName = item.LastName;
                        dbItem.IsVerificationEmailSent = item.IsVerificationEmailSent;
                        dbItem.VerificationToken = item.VerificationToken;
                        dbItem.Approved = item.Approved;
                        dbItem.Status = item.Status;
                        dbItem.UpdatedDate = DateTime.Now;

                        _context.SaveChanges();
                        Task.Factory.StartNew(() => {
                            new ActionLogRepository(_context).Add(enActionTypes.UPDATE.ToInt(), enModules.Users.ToInt(), dbItem, actionUser);
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

        public bool Delete(long id, Users actionUser)
        {
            try
            {
                var item = Get(id);

                if (item != null)
                {
                    item.Status = (byte)enStatus.DELETED;
                    item.UpdatedDate = DateTime.Now;
                    
                    _context.SaveChanges();
                    Task.Factory.StartNew(() => {
                        new ActionLogRepository(_context).Add(enActionTypes.DELETE.ToInt(), enModules.Users.ToInt(), item, actionUser);
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
    }
}
