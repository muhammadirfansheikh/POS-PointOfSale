using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class ProductModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? ProductId { get; set; }
        public int? ProductCategoryId { get; set; }
        public string ProductName { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
        public bool DisplayInPos { get; set; }
        public bool DisplayInWeb { get; set; }
        public bool DisplayInOdms { get; set; }
        public bool DisplayInMobile { get; set; }
        public bool? IsDeal { get; set; }
        public string ProductImage { get; set; }
        public bool? IsExpiryMandatory { get; set; }
    }
}
