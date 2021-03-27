using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IStateBLL
    {
        public bool DeleteState(int id);
        public List<State> Get(int id);
        public State GetStatebyId(int id);
        public bool InsertState(string state, int countryId);
    }
}