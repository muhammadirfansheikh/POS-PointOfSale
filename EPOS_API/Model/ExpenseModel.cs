using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class ExpenseModel
    {
        public int? ExpenseTypeID { get; set; }
        public decimal? ExpenseAmount { get; set; }
        public bool? IsActive { get; set; }
        public int OperationId { get; set; }
        public int CompanyID { get; set; } 
        public int? BranchID { get; set; } 
        public int? PaymentModeID { get; set; }
        public int? PaymentAccountID { get; set; }
        public int? ExpenseID { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string InvoiceNo { get; set; }
        public int UserID { get; set; }
        public string  UserIP { get; set; }
        public string ChequeNo { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}
