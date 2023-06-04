using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class UnitModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? UnitId { get; set; }
        public string UnitName { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
    }
}
