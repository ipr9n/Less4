using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using X_Comm.Models;

namespace X_Comm.EF.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
        void SaveChanges();
        void Remove(User user);
    }
}