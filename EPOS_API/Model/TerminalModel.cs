using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class TerminalModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? TerminalId { get; set; }
        public string TerminalName { get; set; }
        public string Prefix { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
        public int? BranchId { get; set; }
    }

    public class RevokeAccessTerminalModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? TerminalDetailId { get; set; }
      
    }
}
