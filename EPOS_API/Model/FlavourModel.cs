using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class FlavourModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public int? FlavourId { get; set; }
        public string FlavourName { get; set; }
        public string SizeName { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }

    }
}
