using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class CashBookModel
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int CompanyId { get; set; }
        public int? BranchId { get; set; }
        public bool? IsCash { get; set; }
       // public bool IsPettyCash { get; set; } 
	}
}
