using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class TemplateModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public string UserIP { get; set; }
        public int UserId { get; set; }
        public int? TemplateId { get; set; }
        public int? TemplateTypeId { get; set; }
        public string TemplateName { get; set; }
        public string TemplateHtml { get; set; }
    }
}
