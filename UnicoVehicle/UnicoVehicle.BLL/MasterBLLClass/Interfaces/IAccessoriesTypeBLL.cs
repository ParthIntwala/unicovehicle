using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IAccessoriesTypeBLL
    {
        public bool DeleteAccessoriesType(int id);
        public List<AccessoriesType> Get();
        public AccessoriesType GetAccessoriesTypebyId(int id);
        public bool InsertAccessoriesType(string country);
        public bool UpdateAccessoriesType(string accessoriesType, int accessoriesTypeId);
    }
}