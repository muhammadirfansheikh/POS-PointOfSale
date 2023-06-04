using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class RecieveablePayableModel : CommonModel
    {
        public int? COAID { get; set; }
        public decimal? Amount { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
        public int? BranchID { get; set; }
        public int? PaymentModeID { get; set; }
        public int? PaymentAccountID { get; set; }
        public int? VoucherIDD { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string InvoiceNo { get; set; }
        public string ChequeNo { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public bool? IS_IN { get; set; }
        public decimal? Rate { get; set; }
        public int? VendorID { get; set; }
        public int? CustomerID { get; set; }
        public List<REC_PAY_COA_Model> lst_REC_PAY_COA { get; set; }
        public List<REC_PAY_PAYMENT_Model> lst_REC_PAY_PAYMENT { get; set; }
        public bool? IS_CASH { get; set; }
    }
    public class REC_PAY_COA_Model
    {
        public int COAID { get; set; }
        public decimal AMOUNT { get; set; }
        public decimal RATE { get; set; }
    }
    public class REC_PAY_PAYMENT_Model
    {
        public int PAYMENT_ACCOUNT_ID { get; set; }
        public decimal AMOUNT { get; set; }
        public string INVOICENO { get; set; }
        public string CHEQUENO { get; set; }
        public int PAYMENTMODEID { get; set; }
    }
}
