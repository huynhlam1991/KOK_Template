using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TranLe_pj.Models
{
    public class UserAccountModel
    {
        [Required(ErrorMessage = "Không được bỏ trống.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống.")]
        [StringLength(100, ErrorMessage = "Mật khẩu tối đa {0} ký tự và ít nhất {2} ký tự.", MinimumLength = 6)]
        public string PassWord { get; set; }
    }
}