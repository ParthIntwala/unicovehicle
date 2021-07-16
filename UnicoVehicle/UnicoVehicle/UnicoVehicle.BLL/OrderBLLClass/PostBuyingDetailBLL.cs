using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class PostBuyingDetailBLL : IPostBuyingDetailBLL
    {
        private readonly IPostBuyingDetailDAL _postBuyingDetailDAL;
        private readonly IInsuranceTypeBLL _insuranceTypeBLL;
        private readonly IMiscellaneousCallsDAL _miscellaneousCallsDAL;
        bool _status;

        public PostBuyingDetailBLL(IPostBuyingDetailDAL postBuyingDetailDAL, IInsuranceTypeBLL insuranceTypeBLL, IMiscellaneousCallsDAL miscellaneousCallsDAL)
        {
            _postBuyingDetailDAL = postBuyingDetailDAL;
            _insuranceTypeBLL = insuranceTypeBLL;
            _miscellaneousCallsDAL = miscellaneousCallsDAL;
        }

        public PostBuyingDetail GetbyId(int id)
        {
            PostBuyingDetail _postBuyingDetail = _postBuyingDetailDAL.GetPostBuyingDetailbyId(id);

            if (_postBuyingDetail.PostBuyingDetailId != 0)
            {
                _postBuyingDetail.InsuranceType = _insuranceTypeBLL.GetInsuranceTypebyId(_postBuyingDetail.InsuranceType.InsuranceTypeId);
                _postBuyingDetail.InsuranceCompany = _miscellaneousCallsDAL.GetInsuranceCompanybyId(_postBuyingDetail.InsuranceCompany.InsuranceCompanyId);
            }

            return _postBuyingDetail;
        }

        public bool InsertPostBuyingDetail(PostBuyingDetail postBuyingDetail)
        {
            _status = _postBuyingDetailDAL.InsertPostBuyingDetail(postBuyingDetail);
            return _status;
        }

        public bool UpdatePostBuyingDetail(PostBuyingDetail postBuyingDetail, int postBuyingDetailId)
        {
            _status = _postBuyingDetailDAL.UpdatePostBuyingDetail(postBuyingDetail, postBuyingDetailId);
            return _status;
        }
    }
}
