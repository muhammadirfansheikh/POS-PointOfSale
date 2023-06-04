using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class RPTIssuanceDetailsModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? BranchId { get; set; }
        public string InvDateFrm { get; set; }
        public string InvDateTo { get; set; }
    }
}
