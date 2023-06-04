using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class CategoryModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? CategoryId { get; set; }
        public int? DepartmentId { get; set; }
        public string CategoryName { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
        public string CategoryImage { get; set; }
    }
}
