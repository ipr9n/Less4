using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using X_Comm.Models;

namespace X_Comm.EF
{
    public class AppUserManager : UserManager<User>
    {
        public AppUserManager(IUserStore<User> store)
            : base(store)
        {
        }
        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options,
            IOwinContext context)
        {
            IdentContext db = context.Get<IdentContext>();
            AppUserManager manager = new AppUserManager(new UserStore<User>(db));

            manager.PasswordValidator = new PasswordValidator
            {
                RequireNonLetterOrDigit = false,
                RequireDigit = false
            };

            return manager;
        }
    }
}