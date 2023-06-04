using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class BranchReceivingModel
    {
        public int OperationId { get; set; }
        public int? BranchId { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
        public bool IsSubmit { get; set; }
        public int CompanyId { get; set; }
        public int? ReceivingId { get; set; }
        public string Date { get; set; }
        public string ReceivingNumber { get; set; }
        public int? IssuanceId { get; set; }
        public int? TransferId { get; set; }
        public List<BranchReceivingDetail> BranchReceivingDetail { get; set; }
    }

    public class BranchReceivingDetail
    {
        public int? ReceivingDetailId { get; set; }
        public int? ProductDetailId { get; set; }
        public int? BatchId { get; set; }
        public float QtyInLevel2 { get; set; }
        public int? Level2UnitId { get; set; }
        public int? TransferDetailId { get; set; }
        public int? IssuanceDetailId { get; set; }
    }

}
