using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class RecipeModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? RecipeId { get; set; }
        public int? ProductDetailId { get; set; }
        public int? SubRecipeItemId { get; set; }
        public string ItemCode { get; set; }
        public int UserId { get; set; }
        public int? CategoryId { get; set; }
        public string UserIP { get; set; }
        public string ProductName { get; set; }
        public List<RecipeDetail> RecipeDetail { get; set; }

    }
    public class RecipeDetail
    {
        public int? ProductDetailId { get; set; }
        public float ConsumeQty { get; set; }
        public int? ConsumeUnitID { get; set; }
        public int? OrderModeID { get; set; }
    }
}
