using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class DealModel
    {
        public int? OperationId { get; set; }
        public int? CompanyId { get; set; }
        public int? ProductDetailId { get; set; }
        public int UserId { get; set; }
        public int? CategoryId { get; set; }
        public string? DealName { get; set; }
        public List<tblDealItemDetail> tblDealItemDetail { get; set; }
        public List<tblDealDescription> tblDealDescription { get; set; }
    }
    public class tblDealItemDetail
    {
        public int? DealItemId { get; set; }
        public string DealOptionName { get; set; }
        public int? ProductDetailId { get; set; }
        public int Quantity { get; set; }
        public bool IsToppingAllowed { get; set; }
        public int? SizeId { get; set; }
        public int? ProductPropertyId { get; set; }
        public int SortOrder { get; set; }
        public int MaxQuantity { get; set; }
    }

    public class tblDealDescription
    {
        public int? DealDescId { get; set; }
        public int? DealItemId { get; set; }
        public int? ProductDetailId { get; set; }
        public int SortOrder { get; set; }
        public float Price { get; set; }
    }
}
