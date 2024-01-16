using FMGAPP.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMGAPP.DAL.DAO
{
    public class LoginDAO : FMGContext
    {
        public List<LoginDetailDTO> Select()
        {
            List<LoginDetailDTO> info = new List<LoginDetailDTO>();
            var list = db.LOGINs.ToList();
            foreach (var item in list)
            {
                LoginDetailDTO dto = new LoginDetailDTO();
                dto.LoginID = item.loginID;
                dto.Username = item.username;
                dto.Password = item.password;
                info.Add(dto);
            }
            return info;
        }
        //public bool Insert(LOGIN entity)
        //{
        //    try
        //    {
        //        db.LOGINs.Add(entity);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        public List<LOGIN> CheckLoginInfo(string user, string pass)
        {
            List<LOGIN> list = db.LOGINs.Where(x=>x.username == user && x.password == pass).ToList();
            return list;
        }

        public bool Update(LOGIN entity)
        {
            throw new NotImplementedException();
        }
    }
}
