using FMGAPP.DAL;
using FMGAPP.DAL.DAO;
using FMGAPP.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMGAPP.BLL
{
    public class OtherDocumentsBLL : IBLL<OtherDocumentDTO, OtherDocumentsDetailDTO>
    {
        OtherDocumentsDAO dao = new OtherDocumentsDAO();
        MonthDAO monthDAO = new MonthDAO();
        public bool Delete(OtherDocumentsDetailDTO entity)
        {
            TEXT_DOCUMENT document = new TEXT_DOCUMENT();
            document.documentTextID = entity.DocumentID;
            return dao.Delete(document);
        }
        public bool DeletePermanently(OtherDocumentsDetailDTO entity)
        {
            TEXT_DOCUMENT document = new TEXT_DOCUMENT();
            document.documentTextID = entity.DocumentID;
            return dao.DeletePermanently(document);
        }

        public bool GetBack(OtherDocumentsDetailDTO entity)
        {
            return dao.GetBack(entity.DocumentID);
        }

        public bool Insert(OtherDocumentsDetailDTO entity)
        {
            TEXT_DOCUMENT document = new TEXT_DOCUMENT();
            document.documentName = entity.DocumentName;
            document.documentPath = entity.DocumentPath;
            document.documentType = entity.DocumentType;
            document.day = entity.Day;
            document.monthID = entity.MonthID;
            document.year = entity.Year;
            return dao.Insert(document);
        }

        public OtherDocumentDTO Select()
        {
            OtherDocumentDTO dto = new OtherDocumentDTO();
            dto.Months = monthDAO.Select();
            dto.OtherDocuments = dao.Select();
            dto.Years = dao.SelectOnlyYears();
            dto.DocumentTypes = dao.SelectOnlyDocumentTypes();
            return dto;
        }

        public bool Update(OtherDocumentsDetailDTO entity)
        {
            TEXT_DOCUMENT document = new TEXT_DOCUMENT();
            document.documentTextID = entity.DocumentID;
            document.documentName = entity.DocumentName;
            document.documentPath = entity.DocumentPath;
            document.documentType = entity.DocumentType;
            document.day = entity.Day;
            document.monthID = entity.MonthID;
            document.year = entity.Year;
            return dao.Update(document);
        }
    }
}
