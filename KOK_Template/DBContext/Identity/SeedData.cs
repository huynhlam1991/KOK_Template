using Identity.Models;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using KOK_Template.Repositories;

namespace KOK_Template.DBContext.Identity
{
    public class SeedData
    {
        IdentityDbContext context;
        public SeedData(IdentityDbContext context)
        {
            this.context = context;
        }
        public void MigrateData()
        {
            var idManager = new IdentityRepository();
            List<Role> applicationRoles = new List<Role>();

            applicationRoles.Add(new Role { Name = "SA" });
            applicationRoles.Add(new Role { Name = "Admin" });
            foreach (var role in applicationRoles)
            {
                context.Roles.AddOrUpdate(r => r.Name, role);
            }
            context.SaveChanges();
            // Init User and assign to role

            if (!context.Users.Any(x => x.UserName == "sa"))
            {
                var saUser = new ApplicationUser
                {
                    UserName = "sa",
                    FullName = "Hồ Huỳnh Lâm",
                    EmailConfirmed = true,
                    IsDeleted = true
                };
                idManager.CreateUser(saUser, "Q.wertyuiop123");
                idManager.AddUserToRole(saUser.Id, "SA");
            }

            if (!context.Users.Any(x => x.UserName == "admin"))
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "admin",
                    FullName = "Admin",
                    EmailConfirmed = true,
                    IsDeleted = true
                };
                idManager.CreateUser(adminUser, "adminQAZ.123");
                idManager.AddUserToRole(adminUser.Id, "Admin");
            }

            // Init permission
            //List<Permission> applicationPermisstions = new List<Permission>();

            //applicationPermisstions.Add(new Permission { PermissionKey = "PermissionKey", DisplayName = "DisplayName" });
            
            //foreach (var permission in applicationPermisstions)
            //{
            //    context.Permission.AddOrUpdate(p => p.PermissionKey, permission);
            //}
            //context.SaveChanges();
        }
    }
}