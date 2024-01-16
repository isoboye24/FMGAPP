using FMGAPP.DAL.DAO;
using FMGAPP.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMGAPP.BLL
{
    public class DeletedDataBLL
    {
        OfferingDAO offeringDAO = new OfferingDAO();
        ExpenditureTitleDAO expTitleDAO = new ExpenditureTitleDAO();
        ExpenditureDAO expDAO = new ExpenditureDAO();
        ImageDocumentDAO imageDocDAO = new ImageDocumentDAO();
        OtherDocumentsDAO otherDocsDAO = new OtherDocumentsDAO();
        public DeletedDataDTO Select(bool isDeleted)
        {
            DeletedDataDTO dto = new DeletedDataDTO();
            dto.Offerings = offeringDAO.Select(isDeleted);
            dto.ExpenditureTitles = expTitleDAO.Select(isDeleted);
            dto.Expenditures = expDAO.Select(isDeleted);
            dto.ImageDocuments = imageDocDAO.Select(isDeleted);
            dto.OtherDocuments = otherDocsDAO.Select(isDeleted);
            return dto;
        }
    }
}
