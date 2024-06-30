using FMGAPP.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMGAPP.DAL.DAO
{
    public class OfferingStatusDAO : FMGContext, IDAO<OfferingStatusDetailDTO, OFFERING_STATUS>
    {
        public bool Delete(OFFERING_STATUS entity)
        {
            try
            {
                OFFERING_STATUS offeringStatus = db.OFFERING_STATUS.First(x => x.offeringStatusID == entity.offeringStatusID);
                offeringStatus.isDeleted = true;
                offeringStatus.deletedDate = DateTime.Today;
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
                OFFERING_STATUS offeringStatus = db.OFFERING_STATUS.First(x => x.offeringStatusID == ID);
                offeringStatus.isDeleted = false;
                offeringStatus.deletedDate = null;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public bool DeletePermanently(OFFERING_STATUS entity)
        {
            try
            {
                OFFERING_STATUS expenditure = db.OFFERING_STATUS.First(x => x.offeringStatusID == entity.offeringStatusID);
                db.OFFERING_STATUS.Remove(expenditure);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(OFFERING_STATUS entity)
        {
            try
            {
                db.OFFERING_STATUS.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OfferingStatusDetailDTO> Select(bool isDeleted)
        {
            try
            {
                List<OfferingStatusDetailDTO> offeringStatuses = new List<OfferingStatusDetailDTO>();
                var list = db.OFFERING_STATUS.Where(x => x.isDeleted == isDeleted).ToList();
                foreach (var status in list)
                {
                    OfferingStatusDetailDTO dto = new OfferingStatusDetailDTO();
                    dto.OfferingStatusID = status.offeringStatusID;
                    dto.OfferingStatus = status.offeringStatus;
                    offeringStatuses.Add(dto);
                }
                return offeringStatuses;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OfferingStatusDetailDTO> Select()
        {
            try
            {
                List<OfferingStatusDetailDTO> offeringStatuses = new List<OfferingStatusDetailDTO>();
                var list = db.OFFERING_STATUS.Where(x => x.isDeleted == false).ToList();
                foreach (var status in list) 
                {
                    OfferingStatusDetailDTO dto = new OfferingStatusDetailDTO();
                    dto.OfferingStatusID = status.offeringStatusID;
                    dto.OfferingStatus = status.offeringStatus;
                    offeringStatuses.Add(dto);
                }
                return offeringStatuses;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(OFFERING_STATUS entity)
        {
            try
            {
                OFFERING_STATUS offStatus = db.OFFERING_STATUS.First(x => x.offeringStatusID == entity.offeringStatusID);
                offStatus.offeringStatus = entity.offeringStatus;
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
