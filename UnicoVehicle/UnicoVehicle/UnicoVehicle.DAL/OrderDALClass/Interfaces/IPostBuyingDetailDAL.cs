using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IPostBuyingDetailDAL
    {
        public PostBuyingDetail GetPostBuyingDetailbyId(int id);
        public bool InsertPostBuyingDetail(PostBuyingDetail postBuyingDetail);
        public bool UpdatePostBuyingDetail(PostBuyingDetail postBuyingDetail, int id);
    }
}