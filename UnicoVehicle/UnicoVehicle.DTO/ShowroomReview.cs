using System;
namespace UnicoVehicle.DTO
{
    public class ShowroomReview
    {
        public int ShowroomReviewId { get; set; }
        public Miscellaneous.Showroom Showroom { get; set; }
        public Miscellaneous.User User { get; set; }
        public string Review { get; set; }
    }
}
