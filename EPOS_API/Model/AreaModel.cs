using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class AreaModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? AreaId { get; set; }
        public string AreaName { get; set; }
        public int? CityId { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
        public bool IsEnable { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int? ProvinceId { get; set; }
        public int? CountryId { get; set; }
    }
}
