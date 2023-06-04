using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class BranchModel
    {

        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? BranchId { get; set; }
        public string BranchName { get; set; }
        public int? CityId { get; set; }
        public bool IsEnable { get; set; }
        public string NTNNumber { get; set; }
        public string NTNName { get; set; }
        public bool? IsWarehouse { get; set; }
        public string BusinessDayStartTime { get; set; }
        public string BusinessDayEndTime { get; set; }
        public bool IsCallCenter { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
        public List<BranchDetail> BranchDetail { get; set; }
    }

    public class BranchDetail
    {
        public int? BranchId { get; set; }
        public int? AreaId { get; set; }
        public int? DeliveryTime { get; set; }
        public float MinimumOrder { get; set; }
        public float DeliveryCharges { get; set; }
        public int? AlternateBranch1 { get; set; }
        public int? AlternateBranch2 { get; set; }
        public int? AlternateBranch3 { get; set; }
        public int? DeliveryTime1 { get; set; }
        public int? DeliveryTime2 { get; set; }
        public int? DeliveryTime3 { get; set; }
        public bool IsEnable { get; set; }
    }
}
