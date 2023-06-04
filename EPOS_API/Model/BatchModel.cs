using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class BatchModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? BatchId { get; set; }
        public int? ProductDetailId { get; set; }
        public float? Quantity { get; set; }
        public float? Price { get; set; }
        public string ManufactureDate { get; set; }
        public string ExpiryDate { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
        public int? CategoryId { get; set; }
        public int? ProductId { get; set; }
        public int? ProductSizeId { get; set; }
        public int? FlavorId { get; set; }
        public string BatchNumber { get; set; }
    }
}
