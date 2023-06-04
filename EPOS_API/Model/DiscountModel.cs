using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class DiscountModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? DiscountId { get; set; }
        public float? DiscountPercent { get; set; }
        public string DiscountTimeStart { get; set; }
        public string DiscountTimeEnd { get; set; }
        public string DiscountName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int? DiscountTypeId { get; set; }
        public string AreaId { get; set; }
        public string BranchId { get; set; }
        public string OrderMode { get; set; }
        public string OrderType { get; set; }
        public string ProductDetail { get; set; }
        public bool IsActiveInWeb { get; set; }
        public bool IsActiveInPOS { get; set; }
        public bool IsActiveInODMS { get; set; }
        public bool IsActiveInMobile { get; set; }
        public string UserIP { get; set; }
        public int UserId { get; set; }
        public List<DiscountAvailability> DiscountAvailability { get; set; }
    }

    public class DiscountAvailability
    {
        public int? DiscountId { get; set; }
        public int? DayId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}