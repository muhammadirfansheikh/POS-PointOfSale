using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class WastageModel
    {
        public int OperationId { get; set; }
        public int? WastageId { get; set; }
        public string Date { get; set; }
        public int? BranchId { get; set; }
        public string WastageNumber { get; set; }
        public bool? IsSubmit { get; set; }
        public int? UserId { get; set; }
        public string UserIP { get; set; }
        public int CompanyId { get; set; }
        public List<WastageDetail> WastageDetail { get; set; }
    }

    public class WastageDetail
    {
        public int? WastageDetailId { get; set; }
        public int? ProductDetailId { get; set; }
        public int? QtyInLevel2 { get; set; }
        public float? Level2UnitId { get; set; }
        public int? BatchId { get; set; }

    }
}
