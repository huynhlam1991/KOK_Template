using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KOK_Template.Models.Identity
{
    public class Permission
    {
        public int PermissionID { get; set; }

        [Required]
        public string PermissionKey { get; set; }

        [Required]
        public string DisplayName { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}