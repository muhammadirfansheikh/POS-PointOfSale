using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class PayOFFSModel:CommonModel
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int COAID { get; set; } 
        public int CompanyId { get; set; }
        public int? BranchId { get; set; }
    }
}
