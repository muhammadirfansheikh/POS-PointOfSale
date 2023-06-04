using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class ComplainCategoryModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? ComplainCategoryId { get; set; }
        public string ComplainCategoryName { get; set; }
        public int? ComplainTypeId { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
    }

    public class ComplainModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? OrderMasterId { get; set; }
        public int? ComplainMasterId { get; set; }
        public int? ComplainStatusId { get; set; }
        public int? ComplainTypeId { get; set; }
        public int? ComplainCategoryId { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
        public string Remarks { get; set; }
        public string ComplainNumber { get; set; }
    }
}
