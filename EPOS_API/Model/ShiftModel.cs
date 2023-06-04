using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class ShiftModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? ShiftId { get; set; }
        public string ShiftName { get; set; }
        public string Prefix { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
    }
}
