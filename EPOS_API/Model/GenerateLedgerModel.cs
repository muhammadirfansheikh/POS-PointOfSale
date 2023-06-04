using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class GenerateLedgerModel
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string COAID { get; set; }
        public int? CustomerID { get; set; }
        public int? VendorID { get; set; }
        public int? CompanyID { get; set; }
        public int? BranchID { get; set; }
    }
}
