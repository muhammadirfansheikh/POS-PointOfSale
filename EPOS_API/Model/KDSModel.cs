using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class KDSModel
    {
        public int OperationId { get; set; }
        public int? BranchId { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
        public int CompanyId { get; set; }
        public int OrderMasterId { get; set; }
        public string OrderDetailLogStr { get; set; }
    }
}
