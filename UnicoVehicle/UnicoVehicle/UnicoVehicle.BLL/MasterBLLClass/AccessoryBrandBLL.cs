using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class AccessoryBrandBLL : IAccessoryBrandBLL
    {
        private readonly IAccessoryBrandDAL _accessoryBrandDAL;
        bool _status;

        public AccessoryBrandBLL(IAccessoryBrandDAL accessoryBrandDAL)
        {
            _accessoryBrandDAL = accessoryBrandDAL;
        }

        public List<AccessoryBrand> Get()
        {
            List<AccessoryBrand> _accesoryBrand = _accessoryBrandDAL.GetAccessoryBrand();
            return _accesoryBrand;
        }

        public bool InsertTransmissionType(string accessoryBrand)
        {
            _status = _accessoryBrandDAL.InsertAccessoryBrand(accessoryBrand);
            return _status;
        }

        public bool DeleteTransmissionType(int id)
        {
            _status = _accessoryBrandDAL.DeleteAccessoryBrand(id);
            return _status;
        }
    }
}
