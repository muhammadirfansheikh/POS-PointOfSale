using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class GetDiscountModel
    {
        public int? OrderModeId { get; set; }
        public int? AreaId { get; set; }
        public int? OrderMasterId { get; set; }
        public int? OrderSourceId { get; set; }
        public int? BranchId { get; set; }
        public string Date { get; set; }
        public bool IsActiveInWeb { get; set; }
        public bool IsActiveInPOS { get; set; }
        public bool IsActiveInODMS { get; set; }
        public bool IsActiveInMobile { get; set; }

    }
}
