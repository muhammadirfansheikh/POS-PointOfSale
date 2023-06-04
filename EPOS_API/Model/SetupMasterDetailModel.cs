using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class SetupMasterDetailModel
    {
        public int OperationId { get; set; }
        public int SetupMasterId { get; set; }
        public int? ParentId { get; set; }
        public string SetupDetailName { get; set; }
        public string Flex1 { get; set; }
        public string Flex2 { get; set; }
        public string Flex3 { get; set; }
        public int? SetupDetailId { get; set; }
        public int? UserId { get; set; }
        public string UserIP { get; set; }
        public int? CompanyId { get; set; }
    }
}
