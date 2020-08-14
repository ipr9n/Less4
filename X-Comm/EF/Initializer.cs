using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using X_Comm.Models;

namespace X_Comm.EF.Repositories
{
    public class Initializer : DropCreateDatabaseIfModelChanges<IdentContext>
    {
        protected override void Seed(IdentContext context)
        {
            var userManager = new AppUserManager(new UserStore<User>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем две роли
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };
            var role3 = new IdentityRole {Name = "block"};

            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);

            // создаем пользователей
            var admin = new User { Email = "ipr9nka@gmail.com",Name = "Eugene",UserName = "ipr9nka@gmail.com", LastOnline = DateTime.Now, RegisterDate = DateTime.Now};
            string password = "123456";
            var result = userManager.Create(admin, password);
            userManager.Create(new User() { Email = "ipr9nka@gmail.com", UserName = "ipr9nka@gmail.com", Name = "Test", LastOnline = DateTime.Now, RegisterDate = DateTime.Now }, password);
            userManager.Create(new User() { Email = "iprenka@gmail.com", UserName = "iprenka@gmail.com" , Name = "Test", LastOnline = DateTime.Now, RegisterDate = DateTime.Now }, password);
            userManager.Create(new User() { Email = "inka@gmail.com", UserName = "inka@gmail.com" , Name = "Test", LastOnline = DateTime.Now, RegisterDate = DateTime.Now }, password);
            userManager.Create(new User() { Email = "ir9nka@gmail.com", UserName = "ir9nka@gmail.com", Name = "Test", LastOnline = DateTime.Now, RegisterDate = DateTime.Now }, password);
            userManager.Create(new User() { Email = "ipka@gmail.com", UserName = "ipka@gmail.com" , Name = "Test", LastOnline = DateTime.Now, RegisterDate = DateTime.Now }, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }

            base.Seed(context);
        }
    }
}