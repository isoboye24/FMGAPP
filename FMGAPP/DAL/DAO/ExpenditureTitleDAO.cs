using FMGAPP.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMGAPP.DAL.DAO
{
    public class ExpenditureTitleDAO : FMGContext, IDAO<ExpenditureTitleDetailDTO, EXPENDITURE_TITLE>
    {
        public bool Delete(EXPENDITURE_TITLE entity)
        {
            try
            {
                EXPENDITURE_TITLE title = db.EXPENDITURE_TITLE.First(x=>x.expenditureTitleID == entity.expenditureTitleID);
                title.isDeleted = true;
                title.deletedDate = DateTime.Today;
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

        public bool Insert(EXPENDITURE_TITLE entity)
        {
            try
            {
                db.EXPENDITURE_TITLE.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ExpenditureTitleDetailDTO> Select()
        {
            try
            {
                List<ExpenditureTitleDetailDTO> expenditureTitles = new List<ExpenditureTitleDetailDTO>();
                var list = db.EXPENDITURE_TITLE.Where(x => x.isDeleted == false).ToList();
                foreach (var item in list)
                {
                    ExpenditureTitleDetailDTO dto = new ExpenditureTitleDetailDTO();
                    dto.ExpenditureTitleID = item.expenditureTitleID;
                    dto.ExpenditureTitle = item.expenditureTitle;
                    expenditureTitles.Add(dto);
                }
                return expenditureTitles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(EXPENDITURE_TITLE entity)
        {
            try
            {
                EXPENDITURE_TITLE title = db.EXPENDITURE_TITLE.First(x=>x.expenditureTitleID == entity.expenditureTitleID);
                title.expenditureTitle = entity.expenditureTitle;
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
