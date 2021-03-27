using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IAccessoriesDAL
    {
        public bool DeleteAccessories(int id);
        public List<Accessories> GetAccessories();
        public bool InsertAccessories(Accessories accessories);
        public bool UpdateAccessories(Accessories accessories, int id);
        public Accessories GetAccessoriesbyId(int id);
    }
}