using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace X_Comm.Models
{
    public class User : IdentityUser
    {
        public DateTime RegisterDate { get; set; }
        public DateTime LastOnline { get; set; }
        public string Name { get; set; }
        public bool IsBlocked { get; set; }
        public User()
        {
        }
    }
}