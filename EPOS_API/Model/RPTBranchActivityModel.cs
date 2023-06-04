using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class RPTBranchActivityModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? BranchId { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int? ProductDtl { get; set; }
    }
}
