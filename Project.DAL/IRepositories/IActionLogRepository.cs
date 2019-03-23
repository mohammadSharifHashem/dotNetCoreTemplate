using CommonLib.AppUtilities;
using Project.Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;

namespace Project.DAL.IRepositories
{
    public interface IActionLogRepository
    {
        void Add(int actionTypeId, int moduleId, object item, Users actionUser);
    }
}
