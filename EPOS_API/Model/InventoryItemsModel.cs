using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class InventoryItemsModel
    {

        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? ProductDetailId { get; set; }
        public int? ProductId { get; set; }
        public float? Price { get; set; }
        public float? TaxPercent { get; set; }
        public bool OnlyForDeal { get; set; }
        public bool IsEnable { get; set; }
        public string BranchIds { get; set; }
        public int? SizeId { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
        public int? FlavorId { get; set; }
        public int? CategoryId { get; set; }
        public List<ProductDetailBarcode> ProductDetailBarcode { get; set; }
        public bool IsSaleable { get; set; }
        public bool IsProduction { get; set; }
        public int? PurchaseUnitId { get; set; }
        public int? IssuanceUnitId { get; set; }
        public int? ConsumeUnitId { get; set; }
        public float PurchaseIssueConversion { get; set; }
        public float IssueConsumeConversion { get; set; }
        public string SKU { get; set; }
        public int? ParentProductDetailId { get; set; }
        public float ReOrderQuantity { get; set; }
 
    }
}
