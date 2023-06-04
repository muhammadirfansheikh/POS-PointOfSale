using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class VendorModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? VendorId { get; set; }
        public string VendorName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
        public List<PocDetail> PocDetail { get; set; }

    }

    public class PocDetail
    {
        public string PocName { get; set; }
        public string PocContact { get; set; }
        public string Email { get; set; }
    }
}
