using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class RequisitionModel
    {

        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? RequisitionId { get; set; }
        public int? BranchId { get; set; }
        public bool IsSubmit { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
        public List<RequisitionDetail> RequisitionDetail { get; set; }
        public string Date { get; set; }
        public string RequisitionNumber { get; set; }

    }

    public class RequisitionDetail
    {
        public int? ProductDetailId { get; set; }
        public float RequestedQuantityInPurchase { get; set; }
        public int? PurchaseUnitId { get; set; }
    }
}
