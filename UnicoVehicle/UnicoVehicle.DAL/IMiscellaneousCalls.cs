using UnicoVehicle.DTO.Miscellaneous;

namespace UnicoVehicle.DAL
{
    public interface IMiscellaneousCalls
    {
        public District GetDistrictbyId(int id);
        public Company GetCompanybyId(int id);
        public InsuranceCompany GetInsuranceCompanybyId(int id);
        public State GetStatebyId(int id);
        public Showroom GetShowroombyId(int id);
    }
}