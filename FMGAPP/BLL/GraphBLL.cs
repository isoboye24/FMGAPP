using FMGAPP.DAL.DAO;
using FMGAPP.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMGAPP.BLL
{
    public class GraphBLL
    {
        GraphDAO dao = new GraphDAO();
        public GraphDTO GetMonthlyGraphDataWithStatus(int status, int year)
        {
            GraphDTO dto = new GraphDTO();
            dto.GraphData = dao.GetMonthlyGraphDataWithStatus(status, year);
            return dto;
        }
        public GraphDTO SelectYearlyReportWithStatus(int status)
        {
            GraphDTO dto = new GraphDTO();
            dto.GraphData = dao.SelectYearlyReportWithStatus(status);
            return dto;
        }
    }
}
