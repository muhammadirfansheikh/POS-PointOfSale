using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class MenuModel
    {
        public bool DisplayInPos { get; set; }
        public bool DisplayInWeb { get; set; }
        public bool DisplayInOdms { get; set; }
        public bool DisplayInMobile { get; set; }
        public int? BranchId { get; set; }
        public string Barcode { get; set; }
        public int CompanyId { get; set; }
    }

    public class InitialModel
    {
        public int OperationId { get; set; }
        public int BranchId { get; set; }
        public int UserId { get; set; }
    }
}
