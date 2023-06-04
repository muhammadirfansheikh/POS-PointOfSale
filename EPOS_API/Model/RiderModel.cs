using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class RiderModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? RiderId { get; set; }
        public string? RiderName { get; set; }
        public string? RiderCnic { get; set; }
        public string? Contact1 { get; set; }
        public string? Contact2 { get; set; }
        public string? Address { get; set; }
        public int? BranchId { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }

    }
}
