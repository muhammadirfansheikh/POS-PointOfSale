using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class ExtraChargesModel
    {
        public int OperationId { get; set; }
        public int? ExtraChargesId { get; set; }
        public string ExtraChargesName { get; set; }
        public int? OrderModeId { get; set; }
        public bool? IsPercent { get; set; }
        public float ChargesValue { get; set; }
        public int UserId { get; set; }
        public int UserIP { get; set; }
        public int CompanyId { get; set; }
    }
}
