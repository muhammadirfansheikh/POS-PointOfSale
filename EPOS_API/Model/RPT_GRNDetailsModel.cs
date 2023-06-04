using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class RPT_GRNDetailsModel
    {
        public int? GRId { get; set; }
        public int? BranchId { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
    }
}
