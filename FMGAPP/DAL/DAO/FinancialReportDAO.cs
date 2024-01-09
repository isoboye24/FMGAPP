using FMGAPP.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace FMGAPP.DAL.DAO
{
    public class FinancialReportDAO : FMGContext, IDAO<FinancialReportDetailDTO, FINANCIAL_REPORT>
    {
        public bool Delete(FINANCIAL_REPORT entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(FINANCIAL_REPORT entity)
        {
            try
            {
                db.FINANCIAL_REPORT.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<FinancialReportDetailDTO> Select()
        {
            try
            {
                List<FinancialReportDetailDTO> financialReports = new List<FinancialReportDetailDTO>();
                var list = (from f in db.FINANCIAL_REPORT.Where(x => x.isDeleted == false)
                            join m in db.MONTHs on f.monthID equals m.monthID
                            select new
                            {
                                financialReportID = f.financialReportID,
                                totalOfferings = f.totalOfferings,
                                totalExpenditures = f.totalExpenditures,
                                summary = f.summary,
                                monthID = f.monthID,
                                monthName = m.monthName,
                                year = f.year
                            }).OrderByDescending(x => x.year).ThenByDescending(x => x.monthID).ToList();
                foreach (var item in list)
                {
                    FinancialReportDetailDTO dto = new FinancialReportDetailDTO();
                    dto.FinancialReportID = item.financialReportID;
                    dto.TotalOfferings = item.totalOfferings;
                    dto.TotalOfferingsWithCurrency = "€ " + item.totalOfferings;
                    dto.TotalExpenditures = item.totalExpenditures;
                    dto.TotalExpendituresWithCurrency = "€ " + item.totalExpenditures;
                    dto.TotalBalance = item.totalOfferings - item.totalExpenditures;
                    dto.TotalBalanceWithCurrency = "€ " + dto.TotalBalance;
                    dto.Summary = item.summary;
                    dto.MonthID = item.monthID;
                    dto.MonthName = item.monthName;
                    dto.Year = item.year;
                    financialReports.Add(dto);
                }
                return financialReports;
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
                var list = db.FINANCIAL_REPORT.Where(x => x.isDeleted == false).OrderByDescending(x=>x.year).ToList();                            
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
        public List<OFFERING> CheckOfferings(int month, int year)
        {
            try
            {
                List<OFFERING> list = db.OFFERINGs.Where(x => x.isDeleted == false && x.year == year && x.monthID == month).ToList();
                return list;                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal TotalOffering(int month, int year)
        {
            try
            {
                decimal totalOfferings = 0;
                var list = db.OFFERINGs.Where(x => x.isDeleted == false && x.year == year && x.monthID == month).ToList();
                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        totalOfferings += item.offerings;
                    }
                }
                else
                {
                    totalOfferings = 0;
                }
                return totalOfferings;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<OFFERING> CheckOfferingsAmount(int month, int year)
        {
            try
            {
                List<OFFERING> list = db.OFFERINGs.Where(x => x.isDeleted == false && x.year == year && x.monthID == month && x.offerings > 0).ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<EXPENDITURE> CheckExpenditure(int month, int year)
        {
            try
            {
                List<EXPENDITURE> list = db.EXPENDITUREs.Where(x => x.isDeleted == false && x.year == year && x.monthID == month).ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<EXPENDITURE> CheckExpenditureAmount(int month, int year)
        {
            try
            {
                List<EXPENDITURE> list = db.EXPENDITUREs.Where(x => x.isDeleted == false && x.year == year && x.monthID == month && x.amountSpent > 0).ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal TotalExpenditures(int month, int year)
        {
            try
            {
                decimal totalExpenditures = 0;
                var list = db.EXPENDITUREs.Where(x => x.isDeleted == false && x.year == year && x.monthID == month).ToList();
                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        totalExpenditures += item.amountSpent;
                    }
                }
                else
                {
                    totalExpenditures = 0;
                }
                return totalExpenditures;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(FINANCIAL_REPORT entity)
        {
            try
            {
                FINANCIAL_REPORT financialReport = db.FINANCIAL_REPORT.First(x=>x.financialReportID == entity.financialReportID);
                financialReport.totalOfferings = entity.totalOfferings;
                financialReport.totalExpenditures = entity.totalExpenditures;
                financialReport.summary = entity.summary;
                financialReport.monthID = entity.monthID;
                financialReport.year = entity.year;
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
