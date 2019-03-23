using CommonLib.AppSettings;
using CommonLib.AppUtilities;
using CommonLib.Loggers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Project.DAL.IRepositories;
using Project.Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Project.DAL.Repositories
{
    class ActionLogRepository : IActionLogRepository
    {
        private FileLogService _logger;
        TemplateDBContext _context;

        public ActionLogRepository(TemplateDBContext context)
        {
            _logger = new FileLogService(typeof(IActionLogRepository));
            _context = context;
        }

        public void Add(int actionTypeId, int moduleId, object item, Users actionUser)
        {
            try
            {
                ActionLogs obj = new ActionLogs
                {
                    ActionTypeId = actionTypeId,
                    ModuleId = moduleId,
                    UserId = actionUser.UserId,
                    Date = DateTime.Now,
                    Status = (byte)enStatus.ACTIVE
                };

                var settings = new JsonSerializerSettings
                {
                    ContractResolver = ShouldSerializeContractResolver.Instance
                };

                var json = JsonConvert.SerializeObject(item, settings);
                obj.Data = json;

                _context.ActionLogs.Add(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + ex.Message, ex);
            }
        }

        private class ShouldSerializeContractResolver : DefaultContractResolver
        {
            public static readonly ShouldSerializeContractResolver Instance = new ShouldSerializeContractResolver();

            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                JsonProperty property = base.CreateProperty(member, memberSerialization);

                if (property.PropertyName == "_entityWrapper")
                {
                    property.Ignored = true;
                }
                else if (property.DeclaringType.GetProperty(property.PropertyName).GetGetMethod().IsVirtual)
                {
                    property.Ignored = true;
                }
                return property;
            }
        }
    }
}
