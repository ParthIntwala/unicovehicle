﻿using System;
namespace UnicoVehicle.DTO
{
    public class VehicleReview
    {
        public int VehicleReviewId { get; set; }
        public User User { get; set; }
        public Vehicle Vehicle { get; set; }
        public string Review { get; set; }
    }
}
