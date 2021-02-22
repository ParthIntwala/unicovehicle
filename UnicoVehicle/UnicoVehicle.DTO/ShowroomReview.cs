using System;
namespace UnicoVehicle.DTO
{
    public class ShowroomReview
    {
        public int ShowroomReviewId { get; set; }
        public Showroom Showroom { get; set; }
        public User User { get; set; }
        public string Review { get; set; }
    }
}
