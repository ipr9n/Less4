using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace X_Comm.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastOnline { get; set; }
        public string Status { get; set; }
    }
}