using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class PosReportsModel
    {
        public int OperationId { get; set; }
        public int? BranchId { get; set; }
        public int? BusinessDayId { get; set; }
        public int? ShiftDetailId { get; set; }
        public int? TerminalDetailId { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int UserId { get; set; } 
    }

    public class ReportModel
    {
        public int CompanyId { get; set; }
        public int? BranchId { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int OperationId { get; set; }
    }

    public class RequisitionDetailReportModel
    {
        public int RequisitionId { get; set; }
        public int? BranchId { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
    }

    public class DemandDetailReportModel
    {
        public int DemandId { get; set; }
        public int? BranchId { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
    }
    public class PODetailReportModel
    {
        public int POId { get; set; }
        public int? BranchId { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
    }

    public class GRNDetailReportModel
    {
        public int GRNId { get; set; }
        public int? BranchId { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
    }
}
