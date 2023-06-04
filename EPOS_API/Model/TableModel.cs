using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class TableModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? TableId { get; set; }
        public string TableName { get; set; }
        public int? BranchId { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
    }
}
