using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class UserLoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        //public string FullName { get; set; }
        //public string UserId { get; set; }
        //public string CompanyId { get; set; }
        //public string RoleId { get; set; }
        //public string RoleName { get; set; }
        //public string CompanyName { get; set; }
    }

    public class ChangePasswordModel
    {
        public int UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string UserName { get; set; }
    }
}
