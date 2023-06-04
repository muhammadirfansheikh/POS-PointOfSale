using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class MenuItemModel
    {
        public int OperationId { get; set; }
        public int? MenuId { get; set; }
        public int? Parent_Id { get; set; }
        public string Menu_Name { get; set; }
        public string Menu_URL { get; set; }
        public bool Is_Displayed_In_Menu { get; set; }
        public int? UserId { get; set; }
        public string UserIP { get; set; }
        public bool SortOrder { get; set; }

    }
}
