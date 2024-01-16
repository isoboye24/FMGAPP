using FMGAPP.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace FMGAPP.DAL.DAO
{
    public class FinancialReportDAO : FMGContext
    {
        public List<FinancialReportDetailDTO> Select()
        {
            List<FinancialReportDetailDTO> financialReports = new List<FinancialReportDetailDTO>();
            List<int> monthIDCollection = new List<int>();
            List<int> monthIDs = new List<int>();
            List<int> yearsCollection = new List<int>();
            List<int> years = new List<int>();
            List<decimal> totalOfferingCollection = new List<decimal>();
            List<decimal> totalExpenditure = new List<decimal>();

            var OfferingYear = db.OFFERINGs.Where(x => x.isDeleted == false).ToList();
            foreach (var item in OfferingYear)
            {                
                yearsCollection.Add(item.year);                
            }
            years = yearsCollection.Distinct().OrderByDescending(year => year).ToList();
            foreach (var yearItem in years)
            {
                var OfferingMonth = db.OFFERINGs.Where(x => x.isDeleted == false && x.year == yearItem).ToList();
                foreach (var item in OfferingMonth)
                {
                    monthIDCollection.Add(item.monthID);
                }
                monthIDs = monthIDCollection.Distinct().OrderByDescending(monthID => monthID).ToList();
                monthIDCollection.Clear();
                foreach (var monthItem in monthIDs)
                {
                    FinancialReportDetailDTO dto = new FinancialReportDetailDTO();
                    dto.FinancialReportID += 1;
                    dto.MonthID = monthItem;
                    dto.Year = yearItem;
                    var Offerings = db.OFFERINGs.Where(x => x.isDeleted == false && x.monthID == monthItem).ToList();
                    foreach (var offering in Offerings)
                    {
                        totalOfferingCollection.Add(offering.offerings);
                    }
                    dto.TotalOfferings = totalOfferingCollection.Sum();
                    dto.TotalOfferingsWithCurrency = "€ " + dto.TotalOfferings;

                    var Expenditures = db.EXPENDITUREs.Where(x => x.isDeleted == false && x.monthID == monthItem).ToList();
                    foreach (var expenditure in Expenditures)
                    {
                        totalExpenditure.Add(expenditure.amountSpent);
                    }
                    dto.TotalExpenditures = totalExpenditure.Sum();
                    dto.TotalExpendituresWithCurrency = "€ " + dto.TotalExpenditures;
                    dto.TotalBalance = dto.TotalOfferings - dto.TotalExpenditures;
                    dto.TotalBalanceWithCurrency = "€ " + dto.TotalBalance;
                    dto.MonthName = General.ConventIntToMonth(monthItem);
                    financialReports.Add(dto);
                    totalOfferingCollection.Clear();
                    totalExpenditure.Clear();
                }
            }
            return financialReports;
        }

        public List<FinancialReportDetailDTO> SelectYearlyReport()
        {
            List<FinancialReportDetailDTO> financialReports = new List<FinancialReportDetailDTO>();
            List<int> yearsCollection = new List<int>();
            List<int> years = new List<int>();
            List<decimal> totalOfferingCollection = new List<decimal>();
            List<decimal> totalExpenditure = new List<decimal>();

            var OfferingYear = db.OFFERINGs.Where(x => x.isDeleted == false).ToList();
            foreach (var item in OfferingYear)
            {
                yearsCollection.Add(item.year);
            }
            years = yearsCollection.Distinct().OrderByDescending(year => year).ToList();
            foreach (var yearItem in years)
            {
                FinancialReportDetailDTO dto = new FinancialReportDetailDTO();
                dto.FinancialReportID += 1;
                dto.Year = yearItem;
                dto.MonthID = 0;
                dto.MonthName = "";
                var Offerings = db.OFFERINGs.Where(x => x.isDeleted == false && x.year == yearItem).ToList();
                foreach (var offering in Offerings)
                {
                    totalOfferingCollection.Add(offering.offerings);
                }
                dto.TotalOfferings = totalOfferingCollection.Sum();
                dto.TotalOfferingsWithCurrency = "€ " + dto.TotalOfferings;

                var Expenditures = db.EXPENDITUREs.Where(x => x.isDeleted == false && x.year == yearItem).ToList();
                foreach (var expenditure in Expenditures)
                {
                    totalExpenditure.Add(expenditure.amountSpent);
                }
                dto.TotalExpenditures = totalExpenditure.Sum();
                dto.TotalExpendituresWithCurrency = "€ " + dto.TotalExpenditures;
                dto.TotalBalance = dto.TotalOfferings - dto.TotalExpenditures;
                dto.TotalBalanceWithCurrency = "€ " + dto.TotalBalance;
                financialReports.Add(dto);
                totalOfferingCollection.Clear();
                totalExpenditure.Clear();
            }
            return financialReports;
        }

        public decimal TotalOffering()
        {
            try
            {
                decimal totalOfferings = 0;
                var list = db.OFFERINGs.Where(x => x.isDeleted == false).ToList();
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

        public decimal TotalExpenditures()
        {
            try
            {
                decimal totalExpenditures = 0;
                var list = db.EXPENDITUREs.Where(x => x.isDeleted == false).ToList();
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

    }
}
