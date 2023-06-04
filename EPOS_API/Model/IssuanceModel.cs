using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class IssuanceModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? IssuanceMasterId { get; set; }
        public int? DemandMasterId { get; set; }
        public float? TotalIssuanceQuantity { get; set; }
        public int? BranchId { get; set; }
        public bool IsSubmit { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
        public List<IssuanceDetailList> IssuanceDetailList { get; set; }
        public string IssuanceDate { get; set; }
        public string IssuanceNumber { get; set; }
    }
    public class IssuanceDetailList
    {
        public int? ProductDetailId { get; set; }
        public float? DemandQuantityInIssue { get; set; }
        public int? DemandMasterId { get; set; }
        public int? DemandDetailId { get; set; }
        public float? DemandQuantityInConsume { get; set; }
        public float IssuanceQuantity { get; set; }
        public int? IssuanceMasterId { get; set; }
        public int? IssuanceDetailId { get; set; }
        public int? IssuanceUnit { get; set; }
        public int? BatchId { get; set; }
    }
}
