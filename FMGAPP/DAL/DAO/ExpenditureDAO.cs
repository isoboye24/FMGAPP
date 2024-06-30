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

        public bool DeletePermanently(EXPENDITURE entity)
        {
            try
            {
                EXPENDITURE expenditure = db.EXPENDITUREs.First(x => x.expenditureID == entity.expenditureID);
                db.EXPENDITUREs.Remove(expenditure);
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
            try
            {
                EXPENDITURE expenditure = db.EXPENDITUREs.First(x => x.expenditureID == ID);
                expenditure.isDeleted = false;
                expenditure.deletedDate = null;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal TotalExpensesThisMonth(int month)
        {
            try
            {
                List<decimal> expenditures = new List<decimal>();
                var list = db.EXPENDITUREs.Where(x => x.monthID == month && x.isDeleted == false);                
                foreach (var item in list )
                {
                    expenditures.Add(item.amountSpent);
                }
                decimal total = expenditures.Sum();
                return total;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal TotalExpensesThisYear(int year)
        {
            try
            {
                List<decimal> expenditures = new List<decimal>();
                var list = db.EXPENDITUREs.Where(x => x.year == year && x.isDeleted == false);                
                foreach (var item in list )
                {
                    expenditures.Add(item.amountSpent);
                }
                decimal total = expenditures.Sum();
                return total;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                                expenditureDate = e.expenditureDate,
                                isDeleted = e.isDeleted
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
                    dto.ExpenditureDate = item.expenditureDate;
                    dto.ExpenditureTitleID = item.expenditureTitleID;
                    dto.ExpenditureTitle = item.expenditureTitle;
                    dto.isExpenditureTitleDeleted = item.isDeleted;
                    expenditures.Add(dto);
                }
                return expenditures;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ExpenditureDetailDTO> Select(bool isDeleted)
        {
            try
            {
                List<ExpenditureDetailDTO> expenditures = new List<ExpenditureDetailDTO>();
                var list = (from e in db.EXPENDITUREs.Where(x => x.isDeleted == isDeleted)
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
                                expenditureDate = e.expenditureDate,
                                isDeleted = e.isDeleted
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
                    dto.ExpenditureDate = item.expenditureDate;
                    dto.ExpenditureTitleID = item.expenditureTitleID;
                    dto.ExpenditureTitle = item.expenditureTitle;
                    dto.isExpenditureTitleDeleted = item.isDeleted;
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
                expenditure.expenditureDate = entity.expenditureDate;
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
