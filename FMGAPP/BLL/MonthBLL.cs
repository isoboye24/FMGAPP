using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMGAPP.DAL.DAO;
using FMGAPP.DAL.DTO;

namespace FMGAPP.BLL
{
    public class MonthBLL
    {
        MonthDAO dao = new MonthDAO();
        public MonthDTO Select()
        {
            MonthDTO dto = new MonthDTO();
            dto.Months = dao.Select();
            return dto;
        }
    }
}
