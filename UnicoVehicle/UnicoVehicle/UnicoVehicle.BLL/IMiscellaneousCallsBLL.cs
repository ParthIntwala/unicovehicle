using UnicoVehicle.DTO.Miscellaneous;

namespace UnicoVehicle.BLL
{
    public interface IMiscellaneousCallsBLL
    {
        public Showroom GetShowroombyId(int id);
        public Vehicle GetVehiclebyId(int id);
    }
}