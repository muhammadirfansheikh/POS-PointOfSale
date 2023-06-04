using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class ClosingInventoryModel
    {
            public int OperationId { get; set; }
            public int CompanyId { get; set; }
            public int? BranchId { get; set; }
            public bool IsSubmit { get; set; }
            public int? CloseId { get; set; }
            public string Date { get; set; }
            public int UserId { get; set; }
            public string UserIP { get; set; }
            public List<ClosingDetail> ClosingDetail { get; set; }
    }

    public class ClosingDetail
    {
        public int ProductDetailId { get; set; }
        public int BatchId { get; set; }
        public float IssueQuantity { get; set; }
        public int IssueUnitId { get; set; }
    }
}
