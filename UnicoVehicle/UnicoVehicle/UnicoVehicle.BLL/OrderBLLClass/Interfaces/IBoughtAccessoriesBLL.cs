using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IBoughtAccessoriesBLL
    {
        public List<BoughtAccessories> GetbyId(int id);
        public bool InsertPostBuyingDetail(List<BoughtAccessories> boughtAccessories, int id);
        public bool UpdatePostBuyingDetail(List<BoughtAccessories> boughtAccessories, int orderId);
    }
}