using Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using KOK_Template.Models.Identity;

namespace KOK_Template.Repositories
{
    public class IdentityRepository
    {
        RoleManager<Role> _roleManager = new RoleManager<Role>(
            new RoleStore<Role>(new KOK_Template.DBContext.IdentityDbContext()));

        UserManager<ApplicationUser> _userManager = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(new KOK_Template.DBContext.IdentityDbContext()));

        KOK_Template.DBContext.IdentityDbContext _db = new KOK_Template.DBContext.IdentityDbContext();

        public IEnumerable<Permission> getAllPermissions()
        {
            return _db.Permission.ToList();
        }

        //public IEnumerable<RoleViewModel> GetAllAvaibleRolesWithPermisstions(bool withoutSystemRoles = true)
        //{
        //    if (withoutSystemRoles)
        //    {
        //        return _roleManager.Roles.Select(e => new RoleViewModel
        //        {
        //            Id = e.Id,
        //            Name = e.Name,
        //            Description = e.Description,
        //            Permissions = e.RolePermissions.Select(x => new PermissionViewModel
        //            {
        //                DisplayName = x.Permissions.DisplayName,
        //                PermissionKey = x.Permissions.PermissionKey,
        //                PermissionID = x.PermissionID
        //            })
        //        }).Where(x => x.Name != ApplicationIdentityInfo.RoleName_SuperAdmin && x.Name != ApplicationIdentityInfo.RoleName_Admin);
        //    }
        //    return _roleManager.Roles.Select(e => new RoleViewModel
        //    {
        //        Id = e.Id,
        //        Name = e.Name,
        //        Description = e.Description,
        //        Permissions = e.RolePermissions.Select(x => new PermissionViewModel
        //        {
        //            DisplayName = x.Permissions.DisplayName,
        //            PermissionKey = x.Permissions.PermissionKey
        //        })
        //    });
        //}

        //public IEnumerable<RoleViewModel> GetAllAvaibleRoles()
        //{
        //    return _roleManager.Roles.Select(e => new RoleViewModel
        //    {
        //        Id = e.Id,
        //        Name = e.Name
        //    }).Where(x => x.Name != ApplicationIdentityInfo.RoleName_SuperAdmin);
        //}
        //public IEnumerable<UserViewModel> GetAllAvaibleUsers()
        //{
        //    return _db.Users.Select(u => new UserViewModel
        //    {
        //        Id = u.Id,
        //        UserName = u.UserName,
        //        FullName = u.FullName,
        //        IsActive = u.IsDeleted,
        //        Roles = _db.Roles.Where(r => u.Roles.Select(x => x.RoleId).Contains(r.Id))
        //        .Select(y => new RoleViewModel
        //        {
        //            Id = y.Id,
        //            Name = y.Name
        //        })
        //    }).Where(x =>
        //        !x.Roles.Select(r => r.Name).Contains(ApplicationIdentityInfo.RoleName_SuperAdmin) &&
        //        !x.Roles.Select(r => r.Name).Contains(ApplicationIdentityInfo.RoleName_Admin)
        //    );
        //    //var query = from u in _db.Users
        //    //            where u.Roles.Any(r =>
        //    //                (from r1 in _db.Roles
        //    //                 where r1.Name != ApplicationIdentityInfo.RoleName_Admin && r1.Name != ApplicationIdentityInfo.RoleName_SuperAdmin
        //    //                 select r1)
        //    //                .Any(r1 => r1.Id == r.RoleId))
        //    //            select u;
        //    //return query;
        //}

        public bool RoleExists(string name)
        {
            return _roleManager.RoleExists(name);
        }

        public bool UserNameExists(string name)
        {
            return _userManager.FindByName(name) == null ? false : true;
        }
        public bool EmailExists(string email)
        {
            return _userManager.FindByEmail(email) == null ? false : true;
        }
        public Role FindRoleByName(string name)
        {
            return _roleManager.FindByName(name);
        }

        public Role FindRoleById(string Id)
        {
            return _roleManager.FindById(Id);
        }
        public Permission FindPermissionByKey(string permisstionKey)
        {
            return this._db.Permission.Where(x => x.PermissionKey == permisstionKey).FirstOrDefault();
        }

        public bool CreateRole(string name, string description = "")
        {
            // Swap Role for IdentityRole:
            var idResult = _roleManager.Create(new Role(name, description));
            return idResult.Succeeded;
        }
        public bool UpdateRole(Role role)
        {
            // Swap Role for IdentityRole:
            var idResult = _roleManager.Update(role);
            return idResult.Succeeded;
        }
        public bool CreateUser(ApplicationUser user, string password)
        {
            var idResult = _userManager.Create(user, password);
            return idResult.Succeeded;
        }

        public bool UpdateUser(ApplicationUser user)
        {
            var idResult = _userManager.Update(user);
            return idResult.Succeeded;
        }

        public void UpdateUserPassWord(ApplicationUser user, string newPassword)
        {
            var result = _userManager.PasswordHasher.VerifyHashedPassword(user.PasswordHash, newPassword);
            if (result != PasswordVerificationResult.Success)
            {
                _userManager.ResetPassword(user.Id, _userManager.GeneratePasswordResetToken(user.Id), newPassword);
            }
        }

        public bool AddUserToRole(string userId, string roleName)
        {
            var idResult = _userManager.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }
        public bool AddUserToRoles(string userId, string[] roles)
        {
            var idResult = _userManager.AddToRoles(userId, roles);
            return idResult.Succeeded;
        }

        public void ClearUserRoles(string userId)
        {
            var user = _userManager.FindById(userId);
            var currentRoles = new List<IdentityUserRole>();

            currentRoles.AddRange(user.Roles);
            foreach (var role in currentRoles)
            {
                _userManager.RemoveFromRole(userId, role.RoleId);
            }
        }

        public ICollection<IdentityUserRole> GetAllUserRoles(string userName)
        {
            var user = _userManager.FindByName(userName);
            if (user != null)
            {
                return user.Roles;
            }
            return null;
        }

        public void RemoveFromRole(string userId, string roleName)
        {
            _userManager.RemoveFromRole(userId, roleName);
        }


        public void DeleteRole(string roleId)
        {
            var roleUsers = _db.Users.Where(u => u.Roles.Any(r => r.RoleId == roleId));
            var role = _db.Roles.Find(roleId);

            foreach (var user in roleUsers)
            {
                this.RemoveFromRole(user.Id, role.Name);
            }
            _db.Roles.Remove(role);
            _db.SaveChanges();
        }
        public ApplicationUser FindUserByUserName(string userName)
        {
            var idResult = _userManager.FindByName(userName);
            return idResult;
        }
    }
}