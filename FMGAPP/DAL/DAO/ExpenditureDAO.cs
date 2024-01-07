using FMGAPP.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMGAPP.DAL.DAO
{
    public class ExpenditureDAO : FMGContext, IDAO<ExpenditureDetailDTO, EXPENDITURE>
    {
        public bool Delete(EXPENDITURE entity)
        {            
            try
            {
                EXPENDITURE expenditure = db.EXPENDITUREs.First(x=>x.expenditureID == entity.expenditureID);
                expenditure.isDeleted = true;
                expenditure.deletedDate = DateTime.Today;
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

        public bool Insert(EXPENDITURE entity)
        {
            try
            {
                db.EXPENDITUREs.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ExpenditureDetailDTO> Select()
        {
            try
            {
                List<ExpenditureDetailDTO> expenditures = new List<ExpenditureDetailDTO>();
                var list = (from e in db.EXPENDITUREs.Where(x => x.isDeleted == false)
                            join m in db.MONTHs on e.monthID equals m.monthID
                            join et in db.EXPENDITURE_TITLE.Where(x => x.isDeleted == false) on e.expenditureTitleID equals et.expenditureTitleID
                            select new
                            {
                                expenditureID = e.expenditureID,
                                amountSpent = e.amountSpent,
                                summary = e.summary,
                                day = e.day,
                                monthID = e.monthID,
                                monthName = m.monthName,
                                year = e.year,
                                expenditureTitleID = e.expenditureTitleID,
                                expenditureTitle = et.expenditureTitle,
                            }).OrderByDescending(x => x.year).ThenByDescending(x => x.monthID).ThenByDescending(x => x.day).ToList();
                foreach (var item in list)
                {
                    ExpenditureDetailDTO dto = new ExpenditureDetailDTO();
                    dto.ExpenditureID = item.expenditureID;
                    dto.AmountSpent = item.amountSpent;
                    dto.Summary = item.summary;
                    dto.Day = item.day;
                    dto.MonthID = item.monthID;
                    dto.MonthName = item.monthName;
                    dto.Year = item.year;
                    dto.ExpenditureTitleID = item.expenditureTitleID;
                    dto.ExpenditureTitle = item.expenditureTitle;
                    expenditures.Add(dto);
                }
                return expenditures;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(EXPENDITURE entity)
        {
            try
            {
                EXPENDITURE expenditure = db.EXPENDITUREs.First(x=>x.expenditureID == entity.expenditureID);
                expenditure.amountSpent = entity.amountSpent;
                expenditure.summary = entity.summary;
                expenditure.day = entity.day;
                expenditure.monthID = entity.monthID;
                expenditure.year = entity.year;
                expenditure.expenditureTitleID = entity.expenditureTitleID;
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
