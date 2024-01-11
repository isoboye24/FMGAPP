using FMGAPP.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMGAPP.DAL.DAO
{
    public class OtherDocumentsDAO : FMGContext, IDAO<OtherDocumentsDetailDTO, TEXT_DOCUMENT>
    {
        public bool Delete(TEXT_DOCUMENT entity)
        {
            try
            {
                TEXT_DOCUMENT document = db.TEXT_DOCUMENT.First(x => x.documentTextID == entity.documentTextID);
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

        public bool Insert(TEXT_DOCUMENT entity)
        {
            try
            {
                db.TEXT_DOCUMENT.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OtherDocumentsDetailDTO> Select()
        {
            try
            {
                List<OtherDocumentsDetailDTO> documents = new List<OtherDocumentsDetailDTO>();
                var list = (from t in db.TEXT_DOCUMENT.Where(x => x.isDeleted == false)
                            join m in db.MONTHs on t.monthID equals m.monthID
                            select new
                            {
                                documentID = t.documentTextID,
                                documentName = t.documentName,
                                documentType = t.documentType,
                                documentPath = t.documentPath,
                                day = t.day,
                                monthID = t.monthID,
                                monthName = m.monthName,
                                year = t.year
                            }).OrderByDescending(x => x.year).ThenByDescending(x => x.monthID).ThenByDescending(x => x.day).ThenBy(x => x.documentName).ToList();
                foreach (var item in list)
                {
                    OtherDocumentsDetailDTO dto = new OtherDocumentsDetailDTO();
                    dto.DocumentID = item.documentID;
                    dto.DocumentName = item.documentName;
                    dto.DocumentPath = item.documentPath;
                    dto.DocumentType = item.documentType;
                    dto.Day = item.day;
                    dto.MonthID = item.monthID;
                    dto.MonthName = item.monthName;
                    dto.Year = item.year;
                    documents.Add(dto);
                }
                return documents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<int> SelectOnlyYears()
        {
            try
            {
                List<int> years = new List<int>();
                List<int> AllYears = new List<int>();
                var list = db.TEXT_DOCUMENT.Where(x => x.isDeleted == false).OrderByDescending(x => x.year).ToList();
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
        public List<string> SelectOnlyDocumentTypes()
        {
            try
            {
                List<string> documentTypes = new List<string>();
                List<string> AllDocumentTypes = new List<string>();
                var list = db.TEXT_DOCUMENT.Where(x => x.isDeleted == false).OrderBy(x => x.documentType).ToList();
                foreach (var item in list)
                {
                    AllDocumentTypes.Add(item.documentType);
                }
                documentTypes = AllDocumentTypes.Distinct().ToList();
                return documentTypes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(TEXT_DOCUMENT entity)
        {
            try
            {
                TEXT_DOCUMENT document = db.TEXT_DOCUMENT.First(x => x.documentTextID == entity.documentTextID);
                document.documentName = entity.documentName;
                document.documentPath = entity.documentPath;
                document.documentType = entity.documentType;
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
