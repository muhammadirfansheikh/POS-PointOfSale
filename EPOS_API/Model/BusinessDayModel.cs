using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class BusinessDayModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public string UserIP { get; set; }
        public int UserId { get; set; }
        public int? BusinessDayId { get; set; }
        public int? ShiftDetailId { get; set; }
        public int? TerminalDetailId { get; set; }
        public int? ShiftId { get; set; }
        public int? TerminalId { get; set; }
        public int? TerminalOpeningAmount { get; set; }
        public int? TerminalClosingAmount { get; set; }
        public string UniqueId { get; set; }
    }
}
