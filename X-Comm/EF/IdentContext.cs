using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using X_Comm.Models;

namespace X_Comm.EF
{
    public class IdentContext : IdentityDbContext<User>
    {
        public IdentContext() : base("IdentityDb") { }

        public static IdentContext Create()
        {
            return new IdentContext();
        }
    }
}
