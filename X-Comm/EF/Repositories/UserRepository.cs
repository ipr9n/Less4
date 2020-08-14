
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using X_Comm.EF.Interfaces;
using X_Comm.Models;

namespace X_Comm.EF.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IdentContext _db;

        public UserRepository()
        {
            _db = IdentContext.Create();
        }

        public List<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public void Remove(User user)
        {
            _db.Users.Remove(user);
            _db.SaveChanges();
        }
    }
}