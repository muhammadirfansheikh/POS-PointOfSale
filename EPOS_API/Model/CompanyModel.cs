using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class CompanyModel
    {
        public int OperationId { get; set; }
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int NoOfTerminals { get; set; }
        public int BusinessTypeId { get; set; }
        public string CompanyCode { get; set; }
        public int CountryId { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
        public string CompanyLogo { get; set; }
        public string EmailAddress { get; set; }
        public string Contact1 { get; set; }
        public string Contact2 { get; set; }
        public List<CompanyPocDetail> CompanyPocDetail { get; set; }
    }

    public class CompanyPocDetail
    {
        public string PocName { get; set; }
        public string PocContact1 { get; set; }
        public string PocContact2 { get; set; }
        public string PocEmailAddress { get; set; }
        public int? CompanyId { get; set; }
    }
}
