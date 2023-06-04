using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class TransferModel
    {
        public int OperationId { get; set; }
        public int? BranchIdFrom { get; set; }
        public int? BranchIdTo { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
        public bool IsSubmit { get; set; }
        public int CompanyId { get; set; }
        public int? TransferId { get; set; }
        public string Date { get; set; }
        public string TransferNumber { get; set; }
        public string RefNumber { get; set; }
        public List<TransferDetail> TransferDetail { get; set; }
    }

    public class TransferDetail
    {
        public int? TransferDetailId { get; set; }
        public int? ProductDetailId { get; set; }
        public int? BatchId { get; set; }
        public float QtyInLevel2 { get; set; }
        public int? Level2UnitId { get; set; }
    }
}
