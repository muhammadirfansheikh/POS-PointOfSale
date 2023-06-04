using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class DocumentModel
    {
        public int? DocTypeId { get; set; }
        public string DocAttachmentPath { get; set; }
        public int? RelationId { get; set; }
        public string FileName { get; set; }
        public string FileGeneratedName { get; set; }
    }
}
