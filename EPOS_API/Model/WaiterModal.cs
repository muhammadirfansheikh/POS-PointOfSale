using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class WaiterModal
    {

        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? WaiterId { get; set; }
        public string? WaiterName { get; set; }
        public string? WaiterCnic { get; set; }
        public string? Contact1 { get; set; }
        public string? Contact2 { get; set; }
        public string? Address { get; set; }
        public int? BranchId { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }

    }
}
