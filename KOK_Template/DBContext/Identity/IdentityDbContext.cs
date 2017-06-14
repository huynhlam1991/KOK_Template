using Identity.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using KOK_Template.Models.Identity;

namespace KOK_Template.DBContext
{
    public class IdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Permission> Permission { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
        public IdentityDbContext()
            : base("IdentityConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<IdentityDbContext>());
        }

        public static IdentityDbContext Create()
        {
            return new IdentityDbContext();
        }
    }
}