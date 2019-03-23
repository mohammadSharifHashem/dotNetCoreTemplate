using CommonLib.Loggers;
using Project.BLL.BusinessObjects;
using Project.BLL.Helpers.Interfaces;

namespace Project.BLL.Helpers
{
    class AuthHelper : IAuthHelper
    {
        private FileLogService _logger;
        BLLFacade _bLLFacade;

        public AuthHelper(BLLFacade bLLFacade)
        {
            _logger = new FileLogService(typeof(ISecurityHelper));
            _bLLFacade = bLLFacade;
        }

        public SignupBO SignupAndAuthorize()
        {
            throw new System.NotImplementedException();
        }
    }
}
