using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IShowroomBLL
    {
        public bool DeleteShowroom(int id);
        public List<Showroom> Get();
        public Showroom GetShowroombyId(int id);
        public bool InsertShowroom(Showroom showroom);
        public bool UpdateShowroom(Showroom showroom, int showroomId);
        public List<Showroom> GetDistrict(int districtId);
        public List<Showroom> GetCompany(int companyId);
    }
}