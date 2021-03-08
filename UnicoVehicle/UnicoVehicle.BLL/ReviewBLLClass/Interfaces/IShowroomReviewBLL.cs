using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IShowroomReviewBLL
    {
        public bool DeleteShowroomReview(int id);
        public List<ShowroomReview> Get();
        public ShowroomReview GetShowroomReviewbyId(int id);
        public bool InsertShowroomReview(ShowroomReview showroomReview);
        public bool UpdateShowroomReview(ShowroomReview showroomReview, int userId);
    }
}