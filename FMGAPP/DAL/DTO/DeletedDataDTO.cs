using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMGAPP.DAL.DTO
{
    public class DeletedDataDTO
    {
        public List<OfferingsDetailDTO> Offerings { get; set; }
        public List<ExpenditureTitleDetailDTO> ExpenditureTitles { get; set; }
        public List<ExpenditureDetailDTO> Expenditures { get; set; }
        public List<ImageDocumentDetailDTO> ImageDocuments { get; set; }
        public List<OtherDocumentsDetailDTO> OtherDocuments { get; set; }
        public List<OfferingStatusDetailDTO> OfferingStatuses { get; set; }
    }
}
