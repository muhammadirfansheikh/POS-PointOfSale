using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class DepartmentModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string SizeName { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
    }
}
