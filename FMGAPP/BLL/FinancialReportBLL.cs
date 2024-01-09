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
    public class FinancialReportBLL : IBLL<FinancialReportDTO, FinancialReportDetailDTO>
    {
        MonthDAO monthDAO = new MonthDAO();
        FinancialReportDAO dao = new FinancialReportDAO();
        public bool Delete(FinancialReportDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(FinancialReportDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(FinancialReportDetailDTO entity)
        {
            FINANCIAL_REPORT financialReport = new FINANCIAL_REPORT();
            financialReport.totalOfferings = entity.TotalOfferings;
            financialReport.totalExpenditures = entity.TotalExpenditures;
            financialReport.summary = entity.Summary;
            financialReport.monthID = entity.MonthID;
            financialReport.year = entity.Year;
            return dao.Insert(financialReport);
        }

        public FinancialReportDTO Select()
        {
            FinancialReportDTO dto = new FinancialReportDTO();
            dto.Months = monthDAO.Select();
            dto.FinancialReports = dao.Select();
            dto.Years = dao.SelectOnlyYears();
            return dto;
        }
        public List<OFFERING> CheckOfferings(int month, int year)
        {
            return dao.CheckOfferings(month, year);
        }
        public List<OFFERING> CheckOfferingsAmount(int month, int year)
        {
            return dao.CheckOfferingsAmount(month, year);
        }
        public decimal TotalOffering(int month, int year)
        {
            return dao.TotalOffering(month, year);
        }
        public List<EXPENDITURE> CheckExpenditure(int month, int year)
        {
            return dao.CheckExpenditure(month, year);
        }
        public List<EXPENDITURE> CheckExpenditureAmount(int month, int year)
        {
            return dao.CheckExpenditureAmount(month, year);
        }
        public decimal TotalExpenditures(int month, int year)
        {
            return dao.TotalExpenditures(month, year);
        }

        public bool Update(FinancialReportDetailDTO entity)
        {
            FINANCIAL_REPORT financialReport = new FINANCIAL_REPORT();
            financialReport.financialReportID = entity.FinancialReportID;
            financialReport.totalOfferings = entity.TotalOfferings;
            financialReport.totalExpenditures = entity.TotalExpenditures;
            financialReport.summary = entity.Summary;
            financialReport.monthID = entity.MonthID;
            financialReport.year = entity.Year;
            return dao.Update(financialReport);
        }
    }
}
