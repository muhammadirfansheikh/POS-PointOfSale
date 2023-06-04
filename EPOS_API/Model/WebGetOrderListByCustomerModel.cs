using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class WebGetOrderListByCustomerModel
    {
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public int CompanyId { get; set; }
    }
}
