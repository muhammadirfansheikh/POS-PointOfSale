using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class BankModel: CommonModel
    {
        public int? BankId { get; set; }
        public string BankName { get; set; }
        public int CompanyID { get; set; }
        public int? BranchID { get; set; }
        public List<BankDetailModel> BankDetail { get; set; }
    }
    public class BankDetailModel
    {
        public string AccountNo { get; set; }
        public int? BankDetailId { get; set; }
        public decimal OpeningBalance { get; set; }
        
    }
   
}
