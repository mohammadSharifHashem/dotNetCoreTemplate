using Project.DAL.IRepositories;
using Project.DAL.Repositories;
using Project.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL
{
    public class DALFacade
    {
        public IUserRepository UserRepository
        {
            get
            {
                return new UserRepository(new TemplateDBContext());
            }
        }

        public IRegisteredAppRepository RegisteredAppRepository
        {
            get
            {
                return new RegisteredAppRepository(new TemplateDBContext());
            }
        }

        public IAppAccessTokenRepository AppAccessTokenRepository
        {
            get
            {
                return new AppAccessTokenRepository(new TemplateDBContext());
            }
        }
    }
}
