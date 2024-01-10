using FMGAPP.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMGAPP.DAL.DAO
{
    public class ImageDocumentDAO : FMGContext, IDAO<ImageDocumentDetailDTO, IMAGE_DOCUMENT>
    {
        public bool Delete(IMAGE_DOCUMENT entity)
        {
            try
            {
                IMAGE_DOCUMENT document = db.IMAGE_DOCUMENT.First(x=>x.documentImageID == entity.documentImageID);
                document.isDeleted = true;
                document.deletedDate = DateTime.Today;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(IMAGE_DOCUMENT entity)
        {
            try
            {
                db.IMAGE_DOCUMENT.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ImageDocumentDetailDTO> Select()
        {
            List<ImageDocumentDetailDTO> documents = new List<ImageDocumentDetailDTO>();
            var list = (from i in db.IMAGE_DOCUMENT.Where(x => x.isDeleted == false)
                        join m in db.MONTHs on i.monthID equals m.monthID
                        select new
                        {
                            imageDocumentID = i.documentImageID,
                            imagePath = i.imagePath,
                            documentName = i.imageCaption,
                            summary = i.summary,
                            day = i.day,
                            monthID = i.monthID,
                            monthName = m.monthName,
                            year = i.year
                        }).OrderByDescending(x => x.year).ThenByDescending(x => x.monthID).ThenByDescending(x => x.day).ThenBy(x => x.documentName).ToList();
            foreach (var item in list)
            {
                ImageDocumentDetailDTO dto = new ImageDocumentDetailDTO();
                dto.DocumentImageID = item.imageDocumentID;
                dto.ImagePath = item.imagePath;
                dto.DocumentName = item.documentName;
                dto.Summary = item.summary;
                dto.Day = item.day;
                dto.MonthID = item.monthID;
                dto.MonthName = item.monthName;
                dto.Year = item.year;
                documents.Add(dto);
            }
            return documents;
        }
        public List<int> SelectOnlyYears()
        {
            try
            {
                List<int> years = new List<int>();
                List<int> AllYears = new List<int>();
                var list = db.IMAGE_DOCUMENT.Where(x => x.isDeleted == false).OrderByDescending(x => x.year).ToList();
                foreach (var item in list)
                {
                    AllYears.Add(item.year);
                }
                years = AllYears.Distinct().ToList();
                return years;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(IMAGE_DOCUMENT entity)
        {
            try
            {
                IMAGE_DOCUMENT document = db.IMAGE_DOCUMENT.First(x => x.documentImageID == entity.documentImageID);
                document.imageCaption = entity.imageCaption;
                document.imagePath = entity.imagePath;
                document.summary = entity.summary;
                document.day = entity.day;
                document.monthID = entity.monthID;
                document.year = entity.year;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
