using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class AccessoriesBLL : IAccessoriesBLL
    {
        private readonly IAccessoriesDAL _accessoriesDAL;
        private readonly IAccessoryBrandDAL _accessoryBrandDAL;
        private readonly IVehicleNameBLL _vehicleNameBLL;
        private readonly IAccessoriesTypeBLL _accessoriesTypeBLL;
        bool _status;

        public AccessoriesBLL(IAccessoriesDAL accessoriesDAL, IAccessoryBrandDAL accessoryBrandDAL, IVehicleNameBLL vehicleNameBLL, IAccessoriesTypeBLL accessoriesTypeBLL)
        {
            _accessoriesDAL = accessoriesDAL;
            _accessoryBrandDAL = accessoryBrandDAL;
            _vehicleNameBLL = vehicleNameBLL;
            _accessoriesTypeBLL = accessoriesTypeBLL;
        }

        public List<Accessories> Get()
        {
            List<Accessories> _accesories = _accessoriesDAL.GetAccessories();

            foreach(Accessories accessories in _accesories)
            {
                accessories.AccessoriesType = _accessoriesTypeBLL.GetAccessoriesTypebyId(accessories.AccessoriesType.AccessoriesTypeId);
                accessories.VehicleName = _vehicleNameBLL.GetVehicleNamebyId(accessories.VehicleName.VehicleNameId);
                accessories.AccessoryBrand = _accessoryBrandDAL.GetAccessoryBrandbyId(accessories.AccessoryBrand.AccessoryBrandId);
            }

            return _accesories;
        }

        public Accessories GetAccessoriesbyId(int id)
        {
            Accessories accessories = _accessoriesDAL.GetAccessoriesbyId(id);

            if(accessories.AccessoriesId != 0)
            {
                accessories.AccessoriesType = _accessoriesTypeBLL.GetAccessoriesTypebyId(accessories.AccessoriesType.AccessoriesTypeId);
                accessories.VehicleName = _vehicleNameBLL.GetVehicleNamebyId(accessories.VehicleName.VehicleNameId);
                accessories.AccessoryBrand = _accessoryBrandDAL.GetAccessoryBrandbyId(accessories.AccessoryBrand.AccessoryBrandId);
            }

            return accessories;
        }

        public bool InsertAccessories(Accessories accessories)
        {
            _status = _accessoriesDAL.InsertAccessories(accessories);
            return _status;
        }

        public bool UpdateAccessories(Accessories accessories, int id)
        {
            _status = _accessoriesDAL.UpdateAccessories(accessories, id);
            return _status;
        }

        public bool DeleteAccessories(int id)
        {
            _status = _accessoriesDAL.DeleteAccessories(id);
            return _status;
        }
    }
}
