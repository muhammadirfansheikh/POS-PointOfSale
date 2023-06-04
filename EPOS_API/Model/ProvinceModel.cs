using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class ProvinceModel
    {
        public int OperationId { get; set; }
        public string ProvinceName { get; set; }
        public int? ProvinceId { get; set; }
        public int? CountryId { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
    }
}