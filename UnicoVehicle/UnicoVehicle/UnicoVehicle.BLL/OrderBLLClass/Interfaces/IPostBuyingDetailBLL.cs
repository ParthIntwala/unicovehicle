using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IPostBuyingDetailBLL
    {
        public PostBuyingDetail GetbyId(int id);
        public bool InsertPostBuyingDetail(PostBuyingDetail postBuyingDetail);
        public bool UpdatePostBuyingDetail(PostBuyingDetail postBuyingDetail, int postBuyingDetailId);
    }
}