using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IAccessoryBrandDAL
    {
        public bool DeleteAccessoryBrand(int id);
        public List<AccessoryBrand> GetAccessoryBrand();
        public bool InsertAccessoryBrand(string accessoryBrand);
        public AccessoryBrand GetAccessoryBrandbyId(int id);
    }
}