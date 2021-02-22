using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class AccessoriesTypeBLL : IAccessoriesTypeBLL
    {
        private readonly IAccessoriesTypeDAL _accessoriesTypeDAL;
        bool _status;

        public AccessoriesTypeBLL(IAccessoriesTypeDAL accessoriesTypeDAL)
        {
            _accessoriesTypeDAL = accessoriesTypeDAL;
        }

        public List<AccessoriesType> Get()
        {
            List<AccessoriesType> _accessoriesType = _accessoriesTypeDAL.GetAccessoryType();
            return _accessoriesType;
        }

        public AccessoriesType GetAccessoriesTypebyId(int id)
        {
            AccessoriesType _country = _accessoriesTypeDAL.GetAccessoriesTypebyId(id);
            return _country;
        }

        public bool InsertAccessoriesType(string country)
        {
            _status = _accessoriesTypeDAL.InsertAccessoriesType(country);
            return _status;
        }

        public bool DeleteAccessoriesType(int id)
        {
            _status = _accessoriesTypeDAL.DeleteAccessoriesType(id);
            return _status;
        }

        public bool UpdateAccessoriesType(string accessoriesType, int accessoriesTypeId)
        {
            _status = _accessoriesTypeDAL.UpdateAccessoriesType(accessoriesType, accessoriesTypeId);
            return _status;
        }
    }
}
