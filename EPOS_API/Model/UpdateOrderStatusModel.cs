using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class UpdateOrderStatusModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int OrderMasterId { get; set; }
        public int OrderStatusId { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int UserId { get; set; }
    }
}
