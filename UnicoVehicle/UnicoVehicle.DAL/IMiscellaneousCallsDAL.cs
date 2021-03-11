using UnicoVehicle.DTO.Miscellaneous;

namespace UnicoVehicle.DAL
{
    public interface IMiscellaneousCallsDAL
    {
        public District GetDistrictbyId(int id);
        public Company GetCompanybyId(int id);
        public InsuranceCompany GetInsuranceCompanybyId(int id);
        public State GetStatebyId(int id);
        public Showroom GetShowroombyId(int id);
        public Vehicle GetVehiclebyId(int id);
    }
}