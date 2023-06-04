using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class PurchaseOrderModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? VendorId { get; set; }
        public int? POId { get; set; }
        public int? BranchId { get; set; }
        public bool IsSubmit { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
        public List<PODetail> PODetail { get; set; }
        public string Date { get; set; }
        public string PONumber { get; set; }
        public int? RequisitionId { get; set; }
    }
    public class PODetail
    {
        public int? ProductDetailId { get; set; }
        public int? RequisitionDetailId { get; set; }
        public float PurchaseUnitPrice { get; set; }
        public float SubTotal { get; set; }
        public float TaxAmount { get; set; }
        public float Discount { get; set; }
        public float NetAmount { get; set; }
        public int? BatchId { get; set; }
        public float PurchaseQuantity { get; set; }
        public float IssueQuantity { get; set; }
        public float ConsumeQuantity { get; set; }
        public int? PurchaseUnitId { get; set; }
        public int? IssueUnitId { get; set; }
        public int? ConsumeUnitId { get; set; }
    }
}
