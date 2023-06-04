using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class ProductDetail
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? ProductDetailId { get; set; }
        public int? ProductId { get; set; }
        public float? Price { get; set; }
        public float? TaxPercent { get; set; }
        public bool OnlyForDeal { get; set; }
        //public bool IsDeal { get; set; }
        public bool IsEnable { get; set; }
        public string BranchIds { get; set; }
        public int? SizeId { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
        public int? FlavorId { get; set; }
        public int? CategoryId { get; set; }
        public List<ProductDetailBarcode> ProductDetailBarcode { get; set; }
        public List<ProductDetailProperty> ProductDetailProperty { get; set; }
        public bool? IsTopping { get; set; }
    }

    public class ProductDetailBarcode
    {
        public int? ProductDetailId { get; set; }
        public string ProductCode { get; set; }
    }

    public class ProductDetailProperty
    {
        public int? ProductDetailId { get; set; }
        public int? ProductPropertyId { get; set; }
        public float Price { get; set; }
    }

    public class ProductDetailMapping
    {
        public int? OperationId { get; set; }
        public int? CompanyId { get; set; }
        public int? BranchId { get; set; }
        public int? CategoryId { get; set; }
        public int? ProductId { get; set; }
        public int? SizeId { get; set; }
        public int? VariantId { get; set; }
        public int? CityId { get; set; }
        public int? ProductBranchId { get; set; }
        public bool IsEnable { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public int? UserId { get; set; }
        public List<ProductAvailability> ProductAvailability { get; set; }
    }

    public class ProductAvailability
    {
        public int? ProductBranchId { get; set; }
        public int? DayId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
