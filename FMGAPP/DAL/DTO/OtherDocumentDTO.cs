using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMGAPP.DAL.DTO
{
    public class OtherDocumentDTO
    {
        public List<OtherDocumentsDetailDTO> OtherDocuments { get; set; }
        public List<MonthDetailDTO> Months { get; set; }
        public List<int> Years { get; set; }
        public List<string> DocumentTypes { get; set; }
    }
}
