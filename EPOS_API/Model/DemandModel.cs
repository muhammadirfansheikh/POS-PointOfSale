using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class DemandModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? DemandMasterId { get; set; }
        public int? StatusId { get; set; }
        public int? BranchId { get; set; }
        public bool IsSubmit { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
        public List<DemandDetailList> DemandDetailList { get; set; }
        public string DemandDate { get; set; }
        public string DemandNumber { get; set; }
    }

    public class DemandDetailList
    {
        public int? DemandDetailId { get; set; }
        public int? DemandMasterId { get; set; }
        public int? ProductDetailId { get; set; }
        public float DemandQuantityInIssue { get; set; }
        //public int? DemandUnitInIssue { get; set; }
        //public float QuantityInConsume { get; set; }
        //public int? ConsumeUnitId { get; set; }

    }


}
