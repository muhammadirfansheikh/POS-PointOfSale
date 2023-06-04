using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class CityModel
    {
        public int OperationId { get; set; }
        public int? ProvinceId { get; set; }
        public string CityName { get; set; }
        public int? CityId { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
        public int? CountryId { get; set; }
    }
}