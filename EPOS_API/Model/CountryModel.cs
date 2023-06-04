using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class CountryModel
    {
        public int OperationId { get; set; }
        public string CountryName { get; set; }
        public int? CountryId { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
    }
}