using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class AdjustmentModel
    {
        public int OperationId { get; set; }
        public int? AdjustmentId { get; set; }
        public string Date { get; set; }
        public int? BranchId { get; set; }
        public string AdjustmentNumber { get; set; }
        public bool? IsSubmit { get; set; }
        public int? UserId { get; set; }
        public string UserIP { get; set; }
        public int CompanyId { get; set; }
        public List<AdjustmentDetail> AdjustmentDetail { get; set; }
    }

    public class AdjustmentDetail
    {
        public int? AdjustmentDetailId { get; set; }
        public int? AdjustmentId { get; set; }
        public int? ProductDetailId { get; set; }
        public float? QtyInLevel2 { get; set; }
        public int? TypeId { get; set; }
        public int? BatchId { get; set; }
    }
}
