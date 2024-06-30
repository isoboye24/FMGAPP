using FMGAPP.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace FMGAPP.DAL.DAO
{
    public class GraphDAO : FMGContext
    {        
        public List<GraphDetailDTO> GetMonthlyGraphDataWithStatus(int status, int year)
        {
            List<GraphDetailDTO> graphData = new List<GraphDetailDTO>();
            List<int> monthIDCollection = new List<int>();
            List<int> monthIDs = new List<int>();
            List<decimal> totalOfferingCollection = new List<decimal>();

            if (year > 0 && status > 0) 
            {
                var OfferingsMonthsInYear = db.OFFERINGs.Where(x => x.isDeleted == false && x.year == year && x.offeringStatusID == status).ToList();
                foreach (var item in OfferingsMonthsInYear)
                {
                    monthIDCollection.Add(item.monthID);
                }
                monthIDs = monthIDCollection.Distinct().OrderBy(monthID => monthID).ToList();
                monthIDCollection.Clear();
                foreach (var monthItem in monthIDs)
                {
                    GraphDetailDTO dto = new GraphDetailDTO();
                    dto.GraphID += 1;
                    dto.Month = General.ConventIntToMonth(monthItem);
                    var Offerings = db.OFFERINGs.Where(x => x.isDeleted == false && x.monthID == monthItem && x.offeringStatusID == status && x.year == year).ToList();
                    foreach (var offering in Offerings)
                    {
                        totalOfferingCollection.Add(offering.offerings);
                    }
                    dto.TotalOffering = totalOfferingCollection.Sum();
                    graphData.Add(dto);                    
                    totalOfferingCollection.Clear();
                }
                return graphData;
            }           
            else 
            {               
                MessageBox.Show("No graph");
                return null;              
            }
        }

        public List<GraphDetailDTO> SelectYearlyReportWithStatus(int status)
        {
            List<GraphDetailDTO> graphData = new List<GraphDetailDTO>();
            List<int> yearCollection = new List<int>();
            List<int> years = new List<int>();
            List<decimal> totalOfferingCollection = new List<decimal>();

            if (status > 0)
            {
                var OfferingsInYear = db.OFFERINGs.Where(x => x.isDeleted == false && x.offeringStatusID == status).ToList();
                foreach (var item in OfferingsInYear)
                {
                    yearCollection.Add(item.year);
                }
                years = yearCollection.Distinct().OrderBy(year => year).ToList();
                foreach (var year in years)
                {
                    GraphDetailDTO dto = new GraphDetailDTO();
                    dto.GraphID += 1;
                    dto.Month = "";
                    var Offerings = db.OFFERINGs.Where(x => x.isDeleted == false && x.offeringStatusID == status && x.year == year).ToList();
                    foreach (var offering in Offerings)
                    {
                        totalOfferingCollection.Add(offering.offerings);
                    }
                    dto.TotalOffering = totalOfferingCollection.Sum();
                    graphData.Add(dto);
                    totalOfferingCollection.Clear();
                }
                return graphData;
            }
            else
            {
                MessageBox.Show("No graph for zero year");
                return null;
            }
        }
    }
}
