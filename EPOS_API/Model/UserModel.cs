using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class UserModel
    {

        public int OperationId { get; set; }
        public int? UserId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public bool IsEnable { get; set; }
        public bool IsActive { get; set; }
        public string UserIP { get; set; }
        public string BranchIds { get; set; }
        public int? CompanyId { get; set; }
        public string EmailAddress { get; set; }
        public int? User_Id { get; set; }
    }
}
