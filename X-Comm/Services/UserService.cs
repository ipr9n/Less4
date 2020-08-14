using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using X_Comm.EF;
using X_Comm.EF.Interfaces;
using X_Comm.Models;
using X_Comm.Services.Interfaces;

namespace X_Comm.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository repository)
        {
            _userRepository = repository;
        }
        public void UpdateOnline(string userId)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Id == userId);
            user.LastOnline = DateTime.Now;
            _userRepository.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public void BlockUsers(string[] usersId)
        {
            foreach (var userId in usersId)
            {
                var user = _userRepository.GetAll().First(x => x.Id == userId);
                user.IsBlocked = true;

                _userRepository.SaveChanges();
            }
        }

        public void DeleteUsers(string[] usersId)
        {
            foreach (var userId in usersId)
            {
                var user = _userRepository.GetAll().First(x => x.Id == userId);

                if (user != null)
                    _userRepository.Remove(user);
            }
        }

        public bool IsBlocked(string userId) => 
            _userRepository.GetAll().First(x => x.Id == userId).IsBlocked ? true : false;

        public bool IsDeleted(string userId) =>
            _userRepository.GetAll().FirstOrDefault(x=>x.Id==userId) == null ? true : false;

        public void UnBlockUsers(string[] usersId)
        {
            foreach (var userId in usersId)
            {
                var user = _userRepository.GetAll().First(x => x.Id == userId);
                user.IsBlocked = false;

                _userRepository.SaveChanges();
            }
        }
    }
}