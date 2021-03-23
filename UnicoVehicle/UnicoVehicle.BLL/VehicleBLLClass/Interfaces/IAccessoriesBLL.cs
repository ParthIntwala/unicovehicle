using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IAccessoriesBLL
    {
        public bool DeleteAccessories(int id);
        public List<Accessories> Get();
        public bool InsertAccessories(Accessories accessories);
        public bool UpdateAccessories(Accessories accessories, int id);
        public Accessories GetAccessoriesbyId(int id);
    }
}