using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class WebOrderModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? BranchId { get; set; }
        public int? AreaId { get; set; }
        public bool IsWeb { get; set; }
        public bool IsMobile { get; set; }
    }

    public class WebCustomerDetail
    {
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Remarks { get; set; }
        public string LandMark { get; set; }
        public int? AreaId { get; set; }
        public int? BranchId { get; set; }
    }
}
