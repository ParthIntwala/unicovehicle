using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IBoughtAccessoriesDAL
    {
        public bool DeleteBoughtAccessories(int id);
        public List<BoughtAccessories> GetBoughtAccessoriesbyId(int id);
        public bool InsertPostBuyingDetail(BoughtAccessories boughtAccessories, int id);
    }
}