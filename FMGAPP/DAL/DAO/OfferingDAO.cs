using FMGAPP.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMGAPP.DAL.DAO
{
    public class OfferingDAO : FMGContext, IDAO<OfferingsDetailDTO, OFFERING>
    {
        public bool Delete(OFFERING entity)
        {
            try
            {
                OFFERING offering = db.OFFERINGs.First(x=>x.offeringID == entity.offeringID);
                offering.isDeleted = true;
                offering.deletedDate = DateTime.Today;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeletePermanently(OFFERING entity)
        {
            try
            {
                OFFERING offering = db.OFFERINGs.First(x=>x.offeringID == entity.offeringID);
                db.OFFERINGs.Remove(offering);
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
                OFFERING offering = db.OFFERINGs.First(x => x.offeringID == ID);
                offering.isDeleted = false;
                offering.deletedDate = null;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(OFFERING entity)
        {
            try
            {
                db.OFFERINGs.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OfferingsDetailDTO> Select()
        {
            try
            {
                List<OfferingsDetailDTO> offerings = new List<OfferingsDetailDTO>();
                var list = (from o in db.OFFERINGs.Where(x => x.isDeleted == false)
                            join m in db.MONTHs on o.monthID equals m.monthID
                            select new
                            {
                                offeringID = o.offeringID,
                                offerings = o.offerings,
                                summary = o.summary,
                                day = o.day,
                                monthID = o.monthID,
                                monthName = m.monthName,
                                year = o.year
                            }).OrderByDescending(x => x.year).ThenByDescending(x => x.monthID).ThenByDescending(x => x.day).ToList();
                foreach (var item in list)
                {
                    OfferingsDetailDTO dto = new OfferingsDetailDTO();
                    dto.OfferingID = item.offeringID;
                    dto.Offering = item.offerings;
                    dto.OfferingWithCurrency = "€ " + item.offerings;
                    dto.Summary = item.summary;
                    dto.Day = item.day;
                    dto.MonthID = item.monthID;
                    dto.MonthName = item.monthName;
                    dto.Year = item.year;
                    offerings.Add(dto);
                }
                return offerings;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OfferingsDetailDTO> Select(bool isDeleted)
        {
            try
            {
                List<OfferingsDetailDTO> offerings = new List<OfferingsDetailDTO>();
                var list = (from o in db.OFFERINGs.Where(x => x.isDeleted == isDeleted)
                            join m in db.MONTHs on o.monthID equals m.monthID
                            select new
                            {
                                offeringID = o.offeringID,
                                offerings = o.offerings,
                                summary = o.summary,
                                day = o.day,
                                monthID = o.monthID,
                                monthName = m.monthName,
                                year = o.year
                            }).OrderByDescending(x => x.year).ThenByDescending(x => x.monthID).ThenByDescending(x => x.day).ToList();
                foreach (var item in list)
                {
                    OfferingsDetailDTO dto = new OfferingsDetailDTO();
                    dto.OfferingID = item.offeringID;
                    dto.Offering = item.offerings;
                    dto.OfferingWithCurrency = "€ " + item.offerings;
                    dto.Summary = item.summary;
                    dto.Day = item.day;
                    dto.MonthID = item.monthID;
                    dto.MonthName = item.monthName;
                    dto.Year = item.year;
                    offerings.Add(dto);
                }
                return offerings;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(OFFERING entity)
        {
            try
            {
                OFFERING offering = db.OFFERINGs.First(x => x.offeringID == entity.offeringID);
                offering.offerings = entity.offerings;
                offering.summary = entity.summary;
                offering.day = entity.day;
                offering.monthID = entity.monthID;
                offering.year = entity.year;
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
