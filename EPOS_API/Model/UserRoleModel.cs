using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class UserRoleModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
    }
}
