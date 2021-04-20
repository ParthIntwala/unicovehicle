using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IShowroomReviewDAL
    {
        public bool DeleteShowroomReview(int id);
        public List<ShowroomReview> GetShowroomReviewbyUser(int id);
        public List<ShowroomReview> GetShowroomReviewbyShowroom(int id);
        public ShowroomReview GetShowroomReviewbyId(int id);
        public bool InsertShowroomReview(ShowroomReview showroomReview);
        public bool UpdateShowroomReview(ShowroomReview showroomReview, int id);
    }
}