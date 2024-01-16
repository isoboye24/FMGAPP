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
    public class ImageDocumentBLL : IBLL<ImageDocumentDTO, ImageDocumentDetailDTO>
    {
        ImageDocumentDAO dao = new ImageDocumentDAO();
        MonthDAO monthDAO = new MonthDAO();
        public bool Delete(ImageDocumentDetailDTO entity)
        {
            IMAGE_DOCUMENT document = new IMAGE_DOCUMENT();
            document.documentImageID = entity.DocumentImageID;
            return dao.Delete(document);
        }
        public bool DeletePermanently(ImageDocumentDetailDTO entity)
        {
            IMAGE_DOCUMENT document = new IMAGE_DOCUMENT();
            document.documentImageID = entity.DocumentImageID;
            return dao.DeletePermanently(document);
        }

        public bool GetBack(ImageDocumentDetailDTO entity)
        {
            return dao.GetBack(entity.DocumentImageID);
        }

        public bool Insert(ImageDocumentDetailDTO entity)
        {
            IMAGE_DOCUMENT document = new IMAGE_DOCUMENT();
            document.imageCaption = entity.DocumentName;
            document.imagePath = entity.ImagePath;
            document.summary = entity.Summary;
            document.day = entity.Day;
            document.monthID = entity.MonthID;
            document.year = entity.Year;
            return dao.Insert(document);
        }

        public ImageDocumentDTO Select()
        {
            ImageDocumentDTO dto = new ImageDocumentDTO();
            dto.Months = monthDAO.Select();
            dto.ImageDocuments = dao.Select();
            dto.Years = dao.SelectOnlyYears();
            return dto;
        }

        public bool Update(ImageDocumentDetailDTO entity)
        {
            IMAGE_DOCUMENT document = new IMAGE_DOCUMENT();
            document.documentImageID = entity.DocumentImageID;
            document.imageCaption = entity.DocumentName;
            document.imagePath = entity.ImagePath;
            document.summary = entity.Summary;
            document.day = entity.Day;
            document.monthID = entity.MonthID;
            document.year = entity.Year;
            return dao.Update(document);
        }
    }
}
