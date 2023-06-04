using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class OrderStatusModeMappingModel : CommonModel
    {
        public int OrderStatusModeMappingId { get; set; }
        public int OrderStatusId { get; set; }
        public int OrderModeId { get; set; }
        public bool IsActive { get; set; }
    }
    
   
}
