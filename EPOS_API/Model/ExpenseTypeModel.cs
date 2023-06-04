using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class ExpenseTypeModel : CommonModel
    {
        public int? ExpenseTypeID { get; set; }
        public string ExpenseTypeName { get; set; }
        public int CompanyId { get; set; }
    }
    
}
