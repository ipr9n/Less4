using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using X_Comm.Models;

namespace X_Comm.Services.Interfaces
{
    public interface IUserService
    {
        void UpdateOnline(string userId);
        List<User> GetAllUsers();
        bool IsBlocked(string userId);
        bool IsDeleted(string userId);
        void BlockUsers(string[] usersId);
        void UnBlockUsers(string[] usersId);
        void DeleteUsers(string[] usersId);
    }
}