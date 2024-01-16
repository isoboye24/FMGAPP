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
    public class LoginBLL
    {
        LoginDAO dao = new LoginDAO();
        public LoginDTO Select()
        {
            LoginDTO dto = new LoginDTO();
            dto.Logins = dao.Select();
            return dto;
        }
        //public bool Insert(LoginDetailDTO entity)
        //{
        //    LOGIN login = new LOGIN();
        //    login.username = entity.Username;
        //    login.password = entity.Password;
        //    return dao.Insert(login);
        //}


        public List<LOGIN> CheckLoginInfo(string user, string pass)
        {
            return dao.CheckLoginInfo(user, pass);
        }

        public bool Update(LoginDetailDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
