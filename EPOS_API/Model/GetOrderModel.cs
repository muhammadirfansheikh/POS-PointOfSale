using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model

{
    public class GetOrderModel
    {

        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? BranchId { get; set; }
        public int? AreaId { get; set; }
        public string OrderNumber { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public int? OrderModeId { get; set; }
        public int? OrderSourceId { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int? StatusId { get; set; }
        public int? UserId { get; set; }
        public int? CityId { get; set; }
    }
}
