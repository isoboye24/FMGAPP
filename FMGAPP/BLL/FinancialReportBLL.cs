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
    public class FinancialReportBLL
    {
        MonthDAO monthDAO = new MonthDAO();
        FinancialReportDAO dao = new FinancialReportDAO();
        public FinancialReportDTO Select()
        {
            FinancialReportDTO dto = new FinancialReportDTO();
            dto.Months = monthDAO.Select();
            dto.FinancialReports = dao.Select();
            return dto;
        }
        public FinancialReportDTO SelectYearlyReport()
        {
            FinancialReportDTO dto = new FinancialReportDTO();
            dto.FinancialReports = dao.SelectYearlyReport();
            return dto;
        }
        public decimal TotalOffering()
        {
            return dao.TotalOffering();
        }
        public decimal TotalExpenditures()
        {
            return dao.TotalExpenditures();
        }
    }
}
