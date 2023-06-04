using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class GstModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? GstId { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
        public string GstName { get; set; }
        public int? CityId { get; set; }
        public float? GstPercentage { get; set; }
        public int? PaymentModeId { get; set; }
        
    }
}
