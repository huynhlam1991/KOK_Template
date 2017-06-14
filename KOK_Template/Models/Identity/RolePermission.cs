using Identity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KOK_Template.Models.Identity
{
    public class RolePermission
    {
        public int RolePermissionID { get; set; }
        [Required]
        public string RoleId { get; set; }

        [Required]
        public int PermissionID { get; set; }

        public virtual Role Roles { get; set; }

        public virtual Permission Permissions { get; set; }
    }
}