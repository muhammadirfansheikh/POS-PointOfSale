using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class UserLoginAuthModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int? BranchId { get; set; }
    }
}
