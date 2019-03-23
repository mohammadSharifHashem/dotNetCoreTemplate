using Project.ApplicationLib.Mailer;
using Project.BLL.ActiveServices;
using Project.BLL.ActiveServices.Interfaces;
using Project.BLL.Helpers;
using Project.BLL.Helpers.Interfaces;
using Project.BLL.ManagerServices;
using Project.BLL.ManagerServices.Interfaces;

namespace Project.BLL
{
    public class BLLFacade
    {

        #region Manager Services

        internal IUserManagerService UserManagerService
        {
            get
            {
                return new UserManagerService(new DAL.DALFacade());
            }
        }

        internal IRegisterdAppManagerService RegisterdAppManagerService
        {
            get
            {
                return new RegisterdAppManagerService(new DAL.DALFacade());
            }
        }

        internal IAppAccessTokenManagerService AppAccessTokenManagerService
        {
            get
            {
                return new AppAccessTokenManagerService(new DAL.DALFacade());
            }
        }

        #endregion

        #region Active Services

        public IUserActiveService UserActiveService
        {
            get
            {
                return new UserActiveService(new BLLFacade());
            }
        }

        public IRegisterdAppActiveService RegisterdAppActiveService
        {
            get
            {
                return new RegisterdAppActiveService(new BLLFacade());
            }
        }

        public IAppAccessTokenActiveService AppAccessTokenActiveService
        {
            get
            {
                return new AppAccessTokenActiveService(new BLLFacade());
            }
        }

        #endregion

        #region Helpers

        public ISecurityHelper SecurityHelper
        {
            get
            {
                return new SecurityHelper(new BLLFacade());
            }
        }

        public IAuthHelper AuthHelper
        {
            get
            {
                return new AuthHelper(new BLLFacade());
            }
        }

        #endregion
    }
}
