using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class SubRecipeProductionModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? ProductionId { get; set; }
        public int? BranchId { get; set; }
        public bool IsSubmit { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
        public string Date { get; set; }
        public string ProductionNumber { get; set; }
        public List<SubRecipeProductionDetailList> SubRecipeProductionDetailList { get; set; }
    }
    public class SubRecipeProductionDetailList
    {
        public int? ProductionDetailId { get; set; }
        public int? ProductDetailId { get; set; }
        public float? QtyInLevel2 { get; set; }
        public int? Level2UnitID { get; set; }
    }
}
