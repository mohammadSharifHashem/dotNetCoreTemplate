using CommonLib.Loggers;
using Project.BLL.Helpers.Interfaces;
using Project.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.Helpers
{
    class SecurityHelper : ISecurityHelper
    {
        private FileLogService _logger;
        BLLFacade _bLLFacade;

        public SecurityHelper(BLLFacade bLLFacade)
        {
            _logger = new FileLogService(typeof(ISecurityHelper));
            _bLLFacade = bLLFacade;
        }

        public string GenerateVerificationString()
        {
            try
            {
                var firstNum = new Random().Next(999);
                var secondNum = new Random().Next(999);
                return firstNum + "-" + secondNum;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                return null;
            }
        }

        public bool IsAppExists(string appId, Users actionUser)
        {
            try
            {
                RegisteredApps app = _bLLFacade.RegisterdAppActiveService.Get(appId);
                return app != null;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                return false;
            }
        }
    }
}
