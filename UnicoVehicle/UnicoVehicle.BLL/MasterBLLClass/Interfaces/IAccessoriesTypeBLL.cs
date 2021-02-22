using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IAccessoriesTypeBLL
    {
        bool DeleteAccessoriesType(int id);
        List<AccessoriesType> Get();
        AccessoriesType GetAccessoriesTypebyId(int id);
        bool InsertAccessoriesType(string country);
        bool UpdateAccessoriesType(string accessoriesType, int accessoriesTypeId);
    }
}