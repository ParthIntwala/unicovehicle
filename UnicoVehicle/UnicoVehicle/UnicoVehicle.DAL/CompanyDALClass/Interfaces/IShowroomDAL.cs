using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IShowroomDAL
    {
        public bool DeleteShowroom(int id);
        public List<Showroom> GetShowroom();
        public Showroom GetShowroombyId(int id);
        public bool InsertShowroom(Showroom showroom);
        public bool UpdateShowroom(Showroom showroom, int id);
        public List<Showroom> GetShowroombyDistrict(int districtId);
        public List<Showroom> GetShowroombyCompany(int companyId);
    }
}