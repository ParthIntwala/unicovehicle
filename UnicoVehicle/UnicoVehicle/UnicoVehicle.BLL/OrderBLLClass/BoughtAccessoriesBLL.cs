using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class BoughtAccessoriesBLL : IBoughtAccessoriesBLL
    {
        private readonly IBoughtAccessoriesDAL _boughtAccessoriesDAL;
        private readonly IAccessoriesBLL _accessoriesBLL;
        bool _status;

        public BoughtAccessoriesBLL(IBoughtAccessoriesDAL boughtAccessoriesDAL, IAccessoriesBLL accessoriesBLL)
        {
            _boughtAccessoriesDAL = boughtAccessoriesDAL;
            _accessoriesBLL = accessoriesBLL;
        }

        public List<BoughtAccessories> GetbyId(int id)
        {
            List<BoughtAccessories> _boughtAccessories = _boughtAccessoriesDAL.GetBoughtAccessoriesbyId(id);

            foreach (BoughtAccessories boughtAccessories in _boughtAccessories)
            {
                boughtAccessories.Accessories = _accessoriesBLL.GetAccessoriesbyId(boughtAccessories.Accessories.AccessoriesId);
            }

            return _boughtAccessories;
        }

        public bool InsertPostBuyingDetail(List<BoughtAccessories> boughtAccessories, int id)
        {
            foreach(BoughtAccessories bought in boughtAccessories)
            {
                _status = _boughtAccessoriesDAL.InsertPostBuyingDetail(bought, id);

                if(!_status)
                {
                    return false;
                }
            }
            return _status;
        }

        public bool UpdatePostBuyingDetail(List<BoughtAccessories> boughtAccessories, int orderId)
        {
            _status = _boughtAccessoriesDAL.DeleteBoughtAccessories(orderId);

            if (_status)
            {
                foreach (BoughtAccessories bought in boughtAccessories)
                {
                    _status = _boughtAccessoriesDAL.InsertPostBuyingDetail(bought, orderId);

                    if (!_status)
                    {
                        return false;
                    }
                }
            }

            return _status;
        }
    }
}
