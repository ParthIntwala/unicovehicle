using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IAccessoriesTypeDAL
    {
        public bool DeleteAccessoriesType(int id);
        public AccessoriesType GetAccessoriesTypebyId(int id);
        public List<AccessoriesType> GetAccessoryType();
        public bool InsertAccessoriesType(string accessoriesType);
        public bool UpdateAccessoriesType(string accessoriesType, int accessoriesTypeId);
    }
}